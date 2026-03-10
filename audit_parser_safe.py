# -*- coding: utf-8 -*-
"""
audit_parser_safe.py — Auditoria segura (parser char-by-char) de todas as fórmulas.

Uso:
    python audit_parser_safe.py                         # audita todos os arquivos
    python audit_parser_safe.py --batch-size 10         # em lotes de 10
    python audit_parser_safe.py --json-out relatorio.json
"""

import argparse
import glob
import json
import os
import re
from dataclasses import dataclass, field
from typing import Dict, List

EXCLUDED = {
    "FormulaServiceVol11_Complete.cs",
    "FormulaServiceVol11_EngenhariaControle.cs",
    "FormulaServiceVol11_MatematicaFinanceira.cs",
}

FORMULA_REQUIRED_FIELDS = [
    "Nome",
    "Categoria",
    "SubCategoria",
    "Descricao",
    "Criador",
    "AnoOrigin",
    "ExemploPratico",
    "Unidades",
    "Icone",
]

VARIAVEL_REQUIRED_FIELDS = [
    "Simbolo",
    "Nome",
    "Descricao",
    "Unidade",
]


@dataclass
class FileAudit:
    file: str
    formulas: int = 0
    variaveis: int = 0
    missing_formula: Dict[str, int] = field(default_factory=dict)
    missing_variavel: Dict[str, int] = field(default_factory=dict)


# ─────────────────────────────────── Parser ────────────────────────────────────

class CsParser:
    """Parser char-by-char que respeita strings C# ao rastrear profundidade de { }."""

    def __init__(self, text: str):
        self.text = text
        self.n = len(text)

    def _find_block_end(self, brace_start: int) -> int:
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

    def get_formula_blocks(self) -> List[str]:
        blocks = []
        for m in re.finditer(r'\bnew\s+Formula\b\s*\{', self.text):
            brace_start = m.end() - 1
            brace_end = self._find_block_end(brace_start)
            if brace_end != -1:
                blocks.append(self.text[brace_start:brace_end + 1])
        return blocks


def has_assignment(block: str, field_name: str) -> bool:
    return bool(re.search(r'\b' + re.escape(field_name) + r'\s*=', block))


def parse_variaveis_from_formula(formula_block: str) -> List[str]:
    out = []
    i = 0
    n = len(formula_block)

    def find_block_end_local(text: str, start: int) -> int:
        depth = 0
        j = start
        in_reg = False
        in_verb = False
        while j < len(text):
            ch = text[j]
            if in_reg:
                if ch == '\\':
                    j += 2
                    continue
                if ch == '"':
                    in_reg = False
                j += 1
                continue
            if in_verb:
                if ch == '"':
                    if j + 1 < len(text) and text[j + 1] == '"':
                        j += 2
                        continue
                    in_verb = False
                j += 1
                continue
            if ch == '"':
                if j > 0 and text[j - 1] == '@':
                    in_verb = True
                else:
                    in_reg = True
                j += 1
                continue
            if ch == '{':
                depth += 1
            elif ch == '}':
                depth -= 1
                if depth == 0:
                    return j
            j += 1
        return -1

    MARKERS = ["new()", "new Variavel", "new ()"]

    while i < n:
        next_pos = -1
        marker = None
        for mk in MARKERS:
            p = formula_block.find(mk, i)
            if p != -1 and (next_pos == -1 or p < next_pos):
                next_pos = p
                marker = mk

        if next_pos == -1:
            break

        brace_start = formula_block.find('{', next_pos + len(marker))
        if brace_start == -1:
            i = next_pos + len(marker)
            continue

        brace_end = find_block_end_local(formula_block, brace_start)
        if brace_end == -1:
            i = brace_start + 1
            continue

        block = formula_block[next_pos:brace_end + 1]
        if re.search(r'\bSimbo?lo\s*=', block) or re.search(r'\bNome\s*=', block):
            out.append(block)

        i = brace_end + 1

    return out


def audit_file(path: str) -> FileAudit:
    with open(path, "r", encoding="utf-8") as f:
        text = f.read()

    parser = CsParser(text)
    formulas = parser.get_formula_blocks()
    result = FileAudit(file=os.path.basename(path), formulas=len(formulas))

    for fb in formulas:
        for fld in FORMULA_REQUIRED_FIELDS:
            if not has_assignment(fb, fld):
                result.missing_formula[fld] = result.missing_formula.get(fld, 0) + 1

        vblocks = parse_variaveis_from_formula(fb)
        result.variaveis += len(vblocks)

        if not vblocks:
            # Variaveis = [] é válido para fórmulas constantes — só reporta se o campo nem existe
            if not has_assignment(fb, "Variaveis"):
                result.missing_formula["Variaveis"] = result.missing_formula.get("Variaveis", 0) + 1
            continue

        for vb in vblocks:
            for vf in VARIAVEL_REQUIRED_FIELDS:
                if not has_assignment(vb, vf):
                    result.missing_variavel[vf] = result.missing_variavel.get(vf, 0) + 1

    return result


def chunks(seq, size):
    for i in range(0, len(seq), size):
        yield seq[i:i + size]


def main():
    ap = argparse.ArgumentParser(description="Auditoria segura parser-based de fórmulas")
    ap.add_argument("--batch-size", type=int, default=12)
    ap.add_argument("--json-out", default="", metavar="ARQUIVO",
                    help="Salvar relatório detalhado em JSON")
    args = ap.parse_args()

    files = [
        p for p in sorted(glob.glob("Services/FormulaService*.cs"))
        if os.path.basename(p) not in EXCLUDED and not p.endswith(".bak")
    ]

    totals = {
        "files": len(files),
        "formulas": 0,
        "variaveis": 0,
        "missing_formula": {},
        "missing_variavel": {},
        "files_with_issues": 0,
    }

    detailed = []

    for bidx, batch in enumerate(chunks(files, args.batch_size), start=1):
        b_formulas = 0
        b_vars = 0
        b_issues = 0
        for fp in batch:
            r = audit_file(fp)
            b_formulas += r.formulas
            b_vars += r.variaveis
            if r.missing_formula or r.missing_variavel:
                b_issues += 1
                totals["files_with_issues"] += 1

            totals["formulas"] += r.formulas
            totals["variaveis"] += r.variaveis
            for k, v in r.missing_formula.items():
                totals["missing_formula"][k] = totals["missing_formula"].get(k, 0) + v
            for k, v in r.missing_variavel.items():
                totals["missing_variavel"][k] = totals["missing_variavel"].get(k, 0) + v

            detailed.append({
                "file": r.file,
                "formulas": r.formulas,
                "variaveis": r.variaveis,
                "missing_formula": r.missing_formula,
                "missing_variavel": r.missing_variavel,
            })

        print(f"Lote {bidx:02d}: arquivos={len(batch)} formulas={b_formulas} variaveis={b_vars} arquivos_com_issue={b_issues}")

    print(f"\nResumo Geral")
    print(f"Arquivos auditados: {totals['files']}")
    print(f"Formulas: {totals['formulas']}")
    print(f"Variaveis: {totals['variaveis']}")
    print(f"Arquivos com problemas: {totals['files_with_issues']}")
    if totals["missing_formula"]:
        print(f"Missing formula: {totals['missing_formula']}")
    if totals["missing_variavel"]:
        print(f"Missing variavel: {totals['missing_variavel']}")
    if not totals["missing_formula"] and not totals["missing_variavel"]:
        print("✓ Todos os campos preenchidos!")

    if args.json_out:
        report = {
            "summary": totals,
            "all_files": detailed,
        }
        with open(args.json_out, "w", encoding="utf-8") as f:
            json.dump(report, f, ensure_ascii=False, indent=2)
        print(f"Relatorio JSON: {args.json_out}")


if __name__ == "__main__":
    main()
