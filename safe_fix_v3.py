# -*- coding: utf-8 -*-
"""
safe_fix_v3.py — Preenche campos faltantes em Formula e Variavel usando parser char-by-char.

Uso:
    python safe_fix_v3.py                        # corrige todos os arquivos
    python safe_fix_v3.py --dry-run              # simula sem gravar
    python safe_fix_v3.py --batch-size 10        # em lotes de 10
    python safe_fix_v3.py --file FormulaService.cs   # arquivo específico

Estratégia:
  1. CsParser._find_block_end() rastreia profundidade de { } respeitando
     strings regulares "..." e verbatim @"..." — nunca corrompe notação matemática.
  2. Detecta comentários // de linha para não inserir vírgulas dentro deles.
  3. Aplica inserções de trás para frente (posição decrescente) para preservar offsets.
"""

import re
import sys
from pathlib import Path

SERVICES_DIR = Path("Services")

EXCLUDED = {
    "FormulaServiceVol11_Complete.cs",
    "FormulaServiceVol11_EngenhariaControle.cs",
    "FormulaServiceVol11_MatematicaFinanceira.cs",
}

# Valores padrão para campos faltando em Formula
FORMULA_DEFAULTS = {
    "SubCategoria":   "",
    "Criador":        "Equipe CompendioCalc",
    "AnoOrigin":      "Séc. XX",
    "ExemploPratico": "",
    "Unidades":       "",
    "Icone":          "∑",
}

# Valores padrão para campos faltando em Variavel
VARIAVEL_DEFAULTS = {
    "Descricao": "Parâmetro de entrada.",
    "Unidade":   "adim",
}

FORMULA_FIELDS  = list(FORMULA_DEFAULTS.keys())
VARIAVEL_FIELDS = list(VARIAVEL_DEFAULTS.keys())


# ─────────────────────────────────── Parser ────────────────────────────────────

class CsParser:
    """Parser char-by-char que respeita strings C# ao rastrear profundidade de { }."""

    def __init__(self, text: str):
        self.text = text
        self.n = len(text)

    def _find_block_end(self, brace_start: int) -> int:
        """Retorna índice do } correspondente ao { em brace_start."""
        depth = 0
        i = brace_start
        in_regular = False
        in_verbatim = False

        while i < self.n:
            ch = self.text[i]

            if in_regular:
                if ch == '\\':
                    i += 2
                    continue
                if ch == '"':
                    in_regular = False
                i += 1
                continue

            if in_verbatim:
                if ch == '"':
                    if i + 1 < self.n and self.text[i + 1] == '"':
                        i += 2
                        continue
                    in_verbatim = False
                i += 1
                continue

            if ch == '"':
                if i > 0 and self.text[i - 1] == '@':
                    in_verbatim = True
                else:
                    in_regular = True
                i += 1
                continue

            if ch == '{':
                depth += 1
            elif ch == '}':
                depth -= 1
                if depth == 0:
                    return i
            i += 1

        return -1

    def get_formula_block_positions(self) -> list:
        """Retorna lista de (brace_start, brace_end) para todos blocos new Formula { }."""
        results = []
        for m in re.finditer(r'\bnew\s+Formula\b\s*\{', self.text):
            brace_start = m.end() - 1
            brace_end = self._find_block_end(brace_start)
            if brace_end != -1:
                results.append((brace_start, brace_end))
        return results

    def get_variavel_blocks_in_range(self, range_start: int, range_end: int) -> list:
        """Retorna lista de (brace_start, brace_end) para blocos de Variavel dentro do intervalo."""
        text = self.text
        results = []
        i = range_start + 1
        MARKERS = ["new()", "new Variavel", "new ()"]

        while i < range_end:
            next_pos = range_end
            found_mk = None
            for mk in MARKERS:
                p = text.find(mk, i, range_end)
                if p != -1 and p < next_pos:
                    next_pos = p
                    found_mk = mk

            if found_mk is None:
                break

            brace_pos = text.find('{', next_pos + len(found_mk), range_end)
            if brace_pos == -1:
                i = next_pos + 1
                continue

            between = text[next_pos + len(found_mk):brace_pos]
            if re.search(r'\b(new|class|struct)\b', between):
                i = next_pos + 1
                continue

            brace_end = self._find_block_end(brace_pos)
            if brace_end == -1 or brace_end >= range_end:
                i = brace_pos + 1
                continue

            block_text = text[brace_pos:brace_end + 1]
            if re.search(r'\bSimbo?lo\s*=', block_text) or re.search(r'\bNome\s*=', block_text):
                results.append((brace_pos, brace_end))

            i = brace_end + 1

        return results


# ─────────────────────────────── Helpers ───────────────────────────────────────

def has_field(text: str, field_name: str) -> bool:
    return bool(re.search(r'\b' + re.escape(field_name) + r'\s*=', text))


def _find_line_comment_start(line: str):
    """Retorna índice de // fora de strings, ou None."""
    in_str = False
    j = 0
    while j < len(line):
        ch = line[j]
        if in_str:
            if ch == '\\':
                j += 2
                continue
            if ch == '"':
                in_str = False
        else:
            if ch == '"':
                in_str = True
            elif ch == '/' and j + 1 < len(line) and line[j + 1] == '/':
                return j
        j += 1
    return None


def find_last_nonws_pos(text: str, start: int, end: int) -> int:
    """
    Retorna índice do último char não-ws em text[start..end] que NÃO
    esteja dentro de um comentário // de linha.
    """
    i = end
    while i >= start:
        if text[i] in ' \t\n\r':
            i -= 1
            continue
        line_start = text.rfind('\n', 0, i)
        line_start = line_start + 1 if line_start != -1 else 0
        line_up_to_i = text[line_start:i + 1]
        comment_col = _find_line_comment_start(line_up_to_i)
        if comment_col is not None:
            i = line_start + comment_col - 1
            continue
        return i
    return start - 1


def detect_indent(text: str, brace_start: int, brace_end: int) -> str:
    inner = text[brace_start + 1:brace_end]
    m = re.search(r'\n([ \t]+)\w', inner)
    return m.group(1) if m else '                '


# ─────────────────────────────── Fix Logic ─────────────────────────────────────

def fix_file(path: Path, dry_run: bool = False) -> tuple:
    """Corrige campos faltantes. Retorna (formulas_fixed, variaveis_fixed, total_insertions)."""
    text = path.read_text(encoding='utf-8')
    parser = CsParser(text)

    formula_positions = parser.get_formula_block_positions()
    if not formula_positions:
        return 0, 0, 0

    insertions: list = []
    formulas_fixed  = 0
    variaveis_fixed = 0

    for brace_start, brace_end in formula_positions:
        formula_text = text[brace_start:brace_end + 1]

        # ── Campos de fórmula ──
        missing_formula = [f for f in FORMULA_FIELDS if not has_field(formula_text, f)]
        if not has_field(formula_text, 'Variaveis'):
            missing_formula.append('Variaveis')

        if missing_formula:
            indent   = detect_indent(text, brace_start, brace_end)
            last_nws = find_last_nonws_pos(text, brace_start + 1, brace_end - 1)
            last_ch  = text[last_nws] if last_nws > brace_start else '{'
            needs_comma = (last_ch not in (',', '{')) and (last_nws > brace_start)

            lines = []
            for idx, f in enumerate(missing_formula):
                val_str = 'Variaveis = []' if f == 'Variaveis' else f'{f} = "{FORMULA_DEFAULTS[f]}"'
                if idx == 0 and needs_comma:
                    lines.append(f',\n{indent}{val_str},')
                else:
                    lines.append(f'\n{indent}{val_str},')

            insertions.append((last_nws + 1, ''.join(lines)))
            formulas_fixed += 1

        # ── Campos de variável ──
        variavel_positions = parser.get_variavel_blocks_in_range(brace_start, brace_end)
        for v_start, v_end in variavel_positions:
            v_text = text[v_start:v_end + 1]
            missing_var = [f for f in VARIAVEL_FIELDS if not has_field(v_text, f)]
            if not missing_var:
                continue

            is_single  = '\n' not in text[v_start:v_end + 1]
            last_nws_v = find_last_nonws_pos(text, v_start + 1, v_end - 1)
            last_ch_v  = text[last_nws_v] if last_nws_v > v_start else '{'
            needs_comma_v = (last_ch_v not in (',', '{')) and (last_nws_v > v_start)

            if is_single:
                parts = [f', {f} = "{VARIAVEL_DEFAULTS[f]}"' for f in missing_var]
                insertion = ''.join(parts)
            else:
                v_indent = detect_indent(text, v_start, v_end)
                lines_v = []
                for idx, f in enumerate(missing_var):
                    val = VARIAVEL_DEFAULTS[f]
                    if idx == 0 and needs_comma_v:
                        lines_v.append(f',\n{v_indent}{f} = "{val}",')
                    else:
                        lines_v.append(f'\n{v_indent}{f} = "{val}",')
                insertion = ''.join(lines_v)

            insertions.append((last_nws_v + 1, insertion))
            variaveis_fixed += 1

    if insertions:
        insertions.sort(key=lambda x: x[0], reverse=True)
        result = text
        for pos, ins in insertions:
            result = result[:pos] + ins + result[pos:]
        if not dry_run:
            path.write_text(result, encoding='utf-8')

    return formulas_fixed, variaveis_fixed, len(insertions)


# ─────────────────────────────────── Main ──────────────────────────────────────

def main():
    import argparse
    ap = argparse.ArgumentParser(description='Preenche campos faltantes em Formula/Variavel.')
    ap.add_argument('--dry-run', action='store_true', help='Simula sem gravar arquivos.')
    ap.add_argument('--batch-size', type=int, default=0, metavar='N',
                    help='Processar N arquivos por vez (0 = todos).')
    ap.add_argument('--file', type=str, default='', metavar='NOME',
                    help='Processar apenas um arquivo (só o nome, ex: FormulaService.cs).')
    args = ap.parse_args()

    if args.file:
        files = [SERVICES_DIR / args.file]
    else:
        files = sorted([
            f for f in SERVICES_DIR.glob('*.cs')
            if f.name not in EXCLUDED
        ])

    batch_size = args.batch_size if args.batch_size > 0 else len(files)

    total_formulas   = 0
    total_variaveis  = 0
    total_insertions = 0
    total_fixed      = 0

    for batch_start in range(0, len(files), batch_size):
        batch = files[batch_start:batch_start + batch_size]
        b_idx   = batch_start // batch_size + 1
        b_total = (len(files) + batch_size - 1) // batch_size
        b_ffix = b_vfix = 0

        for f in batch:
            ffix, vfix, ins = fix_file(f, dry_run=args.dry_run)
            if ffix or vfix:
                print(f'  {f.name}: fórmulas={ffix}, variáveis={vfix}, inserções={ins}')
                total_fixed += 1
            total_formulas   += ffix
            total_variaveis  += vfix
            total_insertions += ins
            b_ffix += ffix
            b_vfix += vfix

        if b_total > 1:
            print(f'Lote {b_idx}/{b_total}: fórmulas={b_ffix}, variáveis={b_vfix}')

    mode = 'DRY-RUN' if args.dry_run else 'APLICADO'
    print(f'\n=== Resultado [{mode}] ===')
    print(f'Arquivos modificados : {total_fixed}')
    print(f'Fórmulas corrigidas  : {total_formulas}')
    print(f'Variáveis corrigidas : {total_variaveis}')
    print(f'Total inserções      : {total_insertions}')


if __name__ == '__main__':
    main()
