using CompendioCalc.Models;
using System.Globalization;
using System.Text.Json;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    private BibliographicIngestionReport _ultimoRelatorioIngestao = BibliographicIngestionReport.CriarVazio();

    public BibliographicIngestionReport ObterUltimoRelatorioIngestao()
        => _ultimoRelatorioIngestao.Clone();

    public string ObterUltimoRelatorioIngestaoJson()
        => JsonSerializer.Serialize(_ultimoRelatorioIngestao, new JsonSerializerOptions { WriteIndented = true });

    private int ExecutarIngestaoLotesBibliograficos(int alvoTotal, int tamanhoBloco)
    {
        var relatorio = new BibliographicIngestionReport
        {
            InicioUtc = DateTimeOffset.UtcNow,
            AlvoTotal = alvoTotal,
            TamanhoBloco = Math.Max(1, tamanhoBloco),
            TotalAntes = _formulas.Count
        };

        if (alvoTotal <= 0 || _formulas.Count >= alvoTotal)
        {
            relatorio.TotalDepois = _formulas.Count;
            relatorio.FimUtc = DateTimeOffset.UtcNow;
            _ultimoRelatorioIngestao = relatorio;
            return 0;
        }

        var bloco = Math.Max(1, tamanhoBloco);
        var diretorio = Path.Combine(AppContext.BaseDirectory, "Data", "BibliographicBatches");
        if (!Directory.Exists(diretorio))
        {
            RegistrarRejeicao(relatorio.RejeicoesPorMotivo, "diretorio-bibliografico-ausente");
            relatorio.TotalDepois = _formulas.Count;
            relatorio.FimUtc = DateTimeOffset.UtcNow;
            _ultimoRelatorioIngestao = relatorio;
            return 0;
        }

        var chavesBibliograficas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var f in _formulas)
        {
            if (!string.IsNullOrWhiteSpace(f.Id))
            {
                ids.Add(f.Id.Trim());
            }

            var chave = GerarChaveBibliografica(f.ReferenciaBibliografica, f.FonteUrlOuDoi);
            if (!string.IsNullOrWhiteSpace(chave))
            {
                chavesBibliograficas.Add(chave);
            }
        }

        var arquivos = Directory
            .EnumerateFiles(diretorio, "*.*", SearchOption.AllDirectories)
            .Where(p => p.EndsWith(".jsonl", StringComparison.OrdinalIgnoreCase)
                || p.EndsWith(".ndjson", StringComparison.OrdinalIgnoreCase)
                || p.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var adicionadas = 0;

        foreach (var arquivo in arquivos)
        {
            if (_formulas.Count >= alvoTotal)
            {
                break;
            }

            var arquivoRelatorio = new BibliographicIngestionFileReport
            {
                Arquivo = Path.GetRelativePath(diretorio, arquivo).Replace('\\', '/')
            };
            relatorio.Arquivos.Add(arquivoRelatorio);

            var indiceBloco = 0;

            foreach (var lote in LerRegistrosBibliograficosEmBlocos(arquivo, bloco))
            {
                if (_formulas.Count >= alvoTotal)
                {
                    break;
                }

                indiceBloco++;
                var blocoRelatorio = new BibliographicIngestionBlockReport
                {
                    Indice = indiceBloco,
                    Lidos = lote.Count
                };

                arquivoRelatorio.BlocosProcessados++;
                arquivoRelatorio.Lidos += lote.Count;
                relatorio.BlocosProcessados++;
                relatorio.Lidos += lote.Count;

                foreach (var registro in lote)
                {
                    if (_formulas.Count >= alvoTotal)
                    {
                        break;
                    }

                    if (!TryConverterRegistroBibliografico(registro, out var formula, out var motivoFalhaConversao))
                    {
                        RegistrarRejeicao(relatorio.RejeicoesPorMotivo, motivoFalhaConversao);
                        RegistrarRejeicao(arquivoRelatorio.RejeicoesPorMotivo, motivoFalhaConversao);
                        RegistrarRejeicao(blocoRelatorio.RejeicoesPorMotivo, motivoFalhaConversao);
                        continue;
                    }

                    var id = (formula.Id ?? string.Empty).Trim();
                    if (string.IsNullOrWhiteSpace(id) || !ids.Add(id))
                    {
                        const string motivo = "id-duplicado-ou-vazio";
                        RegistrarRejeicao(relatorio.RejeicoesPorMotivo, motivo);
                        RegistrarRejeicao(arquivoRelatorio.RejeicoesPorMotivo, motivo);
                        RegistrarRejeicao(blocoRelatorio.RejeicoesPorMotivo, motivo);
                        continue;
                    }

                    var chave = GerarChaveBibliografica(formula.ReferenciaBibliografica, formula.FonteUrlOuDoi);
                    if (string.IsNullOrWhiteSpace(chave) || !chavesBibliograficas.Add(chave))
                    {
                        const string motivo = "chave-bibliografica-duplicada-ou-vazia";
                        RegistrarRejeicao(relatorio.RejeicoesPorMotivo, motivo);
                        RegistrarRejeicao(arquivoRelatorio.RejeicoesPorMotivo, motivo);
                        RegistrarRejeicao(blocoRelatorio.RejeicoesPorMotivo, motivo);
                        continue;
                    }

                    try
                    {
                        ValidarFormulaCurada(formula);
                        _formulas.Add(formula);
                        adicionadas++;
                        blocoRelatorio.Aceitos++;
                        arquivoRelatorio.Aceitos++;
                        relatorio.Aceitos++;
                    }
                    catch
                    {
                        const string motivo = "validacao-curadoria-falhou";
                        RegistrarRejeicao(relatorio.RejeicoesPorMotivo, motivo);
                        RegistrarRejeicao(arquivoRelatorio.RejeicoesPorMotivo, motivo);
                        RegistrarRejeicao(blocoRelatorio.RejeicoesPorMotivo, motivo);
                        // Registro incompleto/invalido nao deve contaminar a carga.
                    }
                }

                arquivoRelatorio.Blocos.Add(blocoRelatorio);
            }
        }

        relatorio.TotalDepois = _formulas.Count;
        relatorio.FimUtc = DateTimeOffset.UtcNow;
        _ultimoRelatorioIngestao = relatorio;

        return adicionadas;
    }

    private static IEnumerable<List<BibliographicFormulaRecord>> LerRegistrosBibliograficosEmBlocos(string arquivo, int tamanhoBloco)
    {
        if (arquivo.EndsWith(".jsonl", StringComparison.OrdinalIgnoreCase)
            || arquivo.EndsWith(".ndjson", StringComparison.OrdinalIgnoreCase))
        {
            var atual = new List<BibliographicFormulaRecord>(tamanhoBloco);
            foreach (var linha in File.ReadLines(arquivo))
            {
                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue;
                }

                BibliographicFormulaRecord? registro;
                try
                {
                    registro = JsonSerializer.Deserialize<BibliographicFormulaRecord>(linha);
                }
                catch
                {
                    registro = null;
                }

                if (registro is null)
                {
                    continue;
                }

                atual.Add(registro);
                if (atual.Count >= tamanhoBloco)
                {
                    yield return atual;
                    atual = new List<BibliographicFormulaRecord>(tamanhoBloco);
                }
            }

            if (atual.Count > 0)
            {
                yield return atual;
            }

            yield break;
        }

        if (!arquivo.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            yield break;
        }

        List<BibliographicFormulaRecord>? registros;
        try
        {
            using var fs = File.OpenRead(arquivo);
            registros = JsonSerializer.Deserialize<List<BibliographicFormulaRecord>>(fs);
        }
        catch
        {
            registros = null;
        }

        if (registros is null || registros.Count == 0)
        {
            yield break;
        }

        for (var i = 0; i < registros.Count; i += tamanhoBloco)
        {
            yield return registros.Skip(i).Take(tamanhoBloco).ToList();
        }
    }

    private static bool TryConverterRegistroBibliografico(BibliographicFormulaRecord r, out Formula formula, out string motivoFalha)
    {
        formula = new Formula();
        motivoFalha = string.Empty;

        var id = (r.Id ?? string.Empty).Trim();
        var nome = (r.Nome ?? string.Empty).Trim();
        var categoria = (r.Categoria ?? string.Empty).Trim();
        var subCategoria = (r.SubCategoria ?? string.Empty).Trim();
        var expressao = (r.Expressao ?? string.Empty).Trim();
        var descricao = (r.Descricao ?? string.Empty).Trim();
        var exemplo = (r.ExemploPratico ?? string.Empty).Trim();
        var criador = (r.Criador ?? string.Empty).Trim();
        var ano = (r.AnoOrigin ?? string.Empty).Trim();
        var referencia = (r.ReferenciaBibliografica ?? string.Empty).Trim();
        var fonte = (r.FonteUrlOuDoi ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(id)
            || string.IsNullOrWhiteSpace(nome)
            || string.IsNullOrWhiteSpace(categoria)
            || string.IsNullOrWhiteSpace(subCategoria)
            || string.IsNullOrWhiteSpace(expressao)
            || string.IsNullOrWhiteSpace(descricao)
            || string.IsNullOrWhiteSpace(exemplo)
            || string.IsNullOrWhiteSpace(criador)
            || string.IsNullOrWhiteSpace(ano)
            || string.IsNullOrWhiteSpace(referencia)
            || string.IsNullOrWhiteSpace(fonte)
            || r.Variaveis is null
            || r.Variaveis.Count == 0)
        {
            motivoFalha = "campos-obrigatorios-ausentes";
            return false;
        }

        var variaveis = new List<Variavel>(r.Variaveis.Count);
        foreach (var v in r.Variaveis)
        {
            var simbolo = (v.Simbolo ?? string.Empty).Trim();
            var nomeVar = (v.Nome ?? string.Empty).Trim();
            var descVar = (v.Descricao ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(simbolo) || string.IsNullOrWhiteSpace(nomeVar) || string.IsNullOrWhiteSpace(descVar))
            {
                motivoFalha = "variaveis-incompletas";
                return false;
            }

            variaveis.Add(new Variavel
            {
                Simbolo = simbolo,
                Nome = nomeVar,
                Descricao = descVar,
                Unidade = (v.Unidade ?? string.Empty).Trim(),
                ValorPadrao = v.ValorPadrao,
                ValorMin = v.ValorMin,
                ValorMax = v.ValorMax,
                Obrigatoria = v.Obrigatoria
            });
        }

        var exprCalculo = (r.ExpressaoCalculo ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(exprCalculo))
        {
            exprCalculo = ExtrairLadoDireitoExpressao(expressao);
        }

        if (!SafeMathExpression.TryCompile(exprCalculo, out var func))
        {
            motivoFalha = "expressao-calculo-invalida";
            return false;
        }

        formula = new Formula
        {
            Id = id,
            CodigoCompendio = (r.CodigoCompendio ?? string.Empty).Trim(),
            Nome = nome,
            Categoria = categoria,
            SubCategoria = subCategoria,
            Expressao = expressao,
            ExprTexto = string.IsNullOrWhiteSpace(r.ExprTexto) ? expressao : r.ExprTexto.Trim(),
            Descricao = descricao,
            Criador = criador,
            AnoOrigin = ano,
            Procedencia = string.IsNullOrWhiteSpace(r.Procedencia) ? "Ingestao bibliografica em lote" : r.Procedencia.Trim(),
            ReferenciaBibliografica = referencia,
            FonteUrlOuDoi = fonte,
            StatusCuradoria = string.IsNullOrWhiteSpace(r.StatusCuradoria) ? "Curada - fonte primaria verificada" : r.StatusCuradoria.Trim(),
            ExemploPratico = exemplo,
            Unidades = (r.Unidades ?? string.Empty).Trim(),
            Variaveis = variaveis,
            Calcular = vars => func(NormalizarEntradasVariaveis(vars, variaveis)),
            VariavelResultado = string.IsNullOrWhiteSpace(r.VariavelResultado) ? "resultado" : r.VariavelResultado.Trim(),
            UnidadeResultado = (r.UnidadeResultado ?? string.Empty).Trim(),
            Favorita = false,
            Icone = string.IsNullOrWhiteSpace(r.Icone) ? "∑" : r.Icone.Trim()
        };

        return true;
    }

    private static void RegistrarRejeicao(Dictionary<string, int> mapa, string motivo)
    {
        var chave = string.IsNullOrWhiteSpace(motivo) ? "motivo-nao-informado" : motivo.Trim();
        if (!mapa.TryAdd(chave, 1))
        {
            mapa[chave]++;
        }
    }

    private static Dictionary<string, double> NormalizarEntradasVariaveis(Dictionary<string, double> origem, List<Variavel> variaveis)
    {
        var saida = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        foreach (var v in variaveis)
        {
            if (origem.TryGetValue(v.Simbolo, out var valor))
            {
                saida[v.Simbolo] = valor;
            }
            else
            {
                saida[v.Simbolo] = v.ValorPadrao;
            }
        }

        return saida;
    }

    private static string ExtrairLadoDireitoExpressao(string expressao)
    {
        var idx = expressao.IndexOf('=');
        if (idx < 0 || idx + 1 >= expressao.Length)
        {
            return expressao;
        }

        return expressao[(idx + 1)..].Trim();
    }

    private static string GerarChaveBibliografica(string? referencia, string? fonte)
    {
        var r = (referencia ?? string.Empty).Trim();
        var f = (fonte ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(r) || string.IsNullOrWhiteSpace(f))
        {
            return string.Empty;
        }

        return $"{r}||{f}";
    }

    public sealed class BibliographicIngestionReport
    {
        public DateTimeOffset InicioUtc { get; init; }
        public DateTimeOffset FimUtc { get; set; }
        public int AlvoTotal { get; init; }
        public int TamanhoBloco { get; init; }
        public int TotalAntes { get; init; }
        public int TotalDepois { get; set; }
        public int BlocosProcessados { get; set; }
        public int Lidos { get; set; }
        public int Aceitos { get; set; }
        public Dictionary<string, int> RejeicoesPorMotivo { get; } = new(StringComparer.OrdinalIgnoreCase);
        public List<BibliographicIngestionFileReport> Arquivos { get; } = [];

        public static BibliographicIngestionReport CriarVazio()
            => new()
            {
                InicioUtc = DateTimeOffset.MinValue,
                FimUtc = DateTimeOffset.MinValue,
                AlvoTotal = 0,
                TamanhoBloco = 0,
                TotalAntes = 0,
                TotalDepois = 0,
                BlocosProcessados = 0,
                Lidos = 0,
                Aceitos = 0
            };

        public BibliographicIngestionReport Clone()
        {
            var copia = new BibliographicIngestionReport
            {
                InicioUtc = InicioUtc,
                FimUtc = FimUtc,
                AlvoTotal = AlvoTotal,
                TamanhoBloco = TamanhoBloco,
                TotalAntes = TotalAntes,
                TotalDepois = TotalDepois,
                BlocosProcessados = BlocosProcessados,
                Lidos = Lidos,
                Aceitos = Aceitos
            };

            foreach (var item in RejeicoesPorMotivo)
            {
                copia.RejeicoesPorMotivo[item.Key] = item.Value;
            }

            foreach (var arquivo in Arquivos)
            {
                copia.Arquivos.Add(arquivo.Clone());
            }

            return copia;
        }
    }

    public sealed class BibliographicIngestionFileReport
    {
        public string Arquivo { get; init; } = string.Empty;
        public int BlocosProcessados { get; set; }
        public int Lidos { get; set; }
        public int Aceitos { get; set; }
        public Dictionary<string, int> RejeicoesPorMotivo { get; } = new(StringComparer.OrdinalIgnoreCase);
        public List<BibliographicIngestionBlockReport> Blocos { get; } = [];

        public BibliographicIngestionFileReport Clone()
        {
            var copia = new BibliographicIngestionFileReport
            {
                Arquivo = Arquivo,
                BlocosProcessados = BlocosProcessados,
                Lidos = Lidos,
                Aceitos = Aceitos
            };

            foreach (var item in RejeicoesPorMotivo)
            {
                copia.RejeicoesPorMotivo[item.Key] = item.Value;
            }

            foreach (var bloco in Blocos)
            {
                copia.Blocos.Add(bloco.Clone());
            }

            return copia;
        }
    }

    public sealed class BibliographicIngestionBlockReport
    {
        public int Indice { get; init; }
        public int Lidos { get; init; }
        public int Aceitos { get; set; }
        public Dictionary<string, int> RejeicoesPorMotivo { get; } = new(StringComparer.OrdinalIgnoreCase);

        public BibliographicIngestionBlockReport Clone()
        {
            var copia = new BibliographicIngestionBlockReport
            {
                Indice = Indice,
                Lidos = Lidos,
                Aceitos = Aceitos
            };

            foreach (var item in RejeicoesPorMotivo)
            {
                copia.RejeicoesPorMotivo[item.Key] = item.Value;
            }

            return copia;
        }
    }

    private sealed class BibliographicFormulaRecord
    {
        public string? Id { get; set; }
        public string? CodigoCompendio { get; set; }
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public string? SubCategoria { get; set; }
        public string? Expressao { get; set; }
        public string? ExpressaoCalculo { get; set; }
        public string? ExprTexto { get; set; }
        public string? Descricao { get; set; }
        public string? Criador { get; set; }
        public string? AnoOrigin { get; set; }
        public string? Procedencia { get; set; }
        public string? ReferenciaBibliografica { get; set; }
        public string? FonteUrlOuDoi { get; set; }
        public string? StatusCuradoria { get; set; }
        public string? ExemploPratico { get; set; }
        public string? Unidades { get; set; }
        public string? VariavelResultado { get; set; }
        public string? UnidadeResultado { get; set; }
        public string? Icone { get; set; }
        public List<BibliographicVariableRecord>? Variaveis { get; set; }
    }

    private sealed class BibliographicVariableRecord
    {
        public string? Simbolo { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Unidade { get; set; }
        public double ValorPadrao { get; set; }
        public double ValorMin { get; set; } = double.NegativeInfinity;
        public double ValorMax { get; set; } = double.PositiveInfinity;
        public bool Obrigatoria { get; set; } = true;
    }

    private static class SafeMathExpression
    {
        private static readonly HashSet<string> FuncoesUnarias = new(StringComparer.OrdinalIgnoreCase)
        {
            "sqrt", "exp", "ln", "log", "log10", "abs", "sin", "cos", "tan", "neg"
        };

        private static readonly HashSet<string> FuncoesBinarias = new(StringComparer.OrdinalIgnoreCase)
        {
            "pow", "min", "max"
        };

        private static readonly HashSet<string> FuncoesTernarias = new(StringComparer.OrdinalIgnoreCase)
        {
            "clamp"
        };

        public static bool TryCompile(string expr, out Func<Dictionary<string, double>, double> calculator)
        {
            calculator = _ => double.NaN;
            if (string.IsNullOrWhiteSpace(expr))
            {
                return false;
            }

            if (!TryTokenize(expr, out var tokens))
            {
                return false;
            }

            if (!TryToRpn(tokens, out var rpn))
            {
                return false;
            }

            calculator = vars => EvalRpn(rpn, vars);
            return true;
        }

        private static bool TryTokenize(string expr, out List<string> tokens)
        {
            tokens = [];
            var i = 0;
            while (i < expr.Length)
            {
                var c = expr[i];
                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                if (char.IsDigit(c) || c == '.')
                {
                    var ini = i;
                    i++;
                    while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
                    {
                        i++;
                    }

                    if (i < expr.Length && (expr[i] == 'e' || expr[i] == 'E'))
                    {
                        i++;
                        if (i < expr.Length && (expr[i] == '+' || expr[i] == '-'))
                        {
                            i++;
                        }
                        while (i < expr.Length && char.IsDigit(expr[i]))
                        {
                            i++;
                        }
                    }

                    tokens.Add(expr[ini..i]);
                    continue;
                }

                if (char.IsLetter(c) || c == '_')
                {
                    var ini = i;
                    i++;
                    while (i < expr.Length && (char.IsLetterOrDigit(expr[i]) || expr[i] == '_'))
                    {
                        i++;
                    }

                    tokens.Add(expr[ini..i]);
                    continue;
                }

                if ("+-*/^(),".Contains(c, StringComparison.Ordinal))
                {
                    tokens.Add(c.ToString());
                    i++;
                    continue;
                }

                return false;
            }

            return tokens.Count > 0;
        }

        private static bool TryToRpn(List<string> tokens, out List<string> output)
        {
            output = [];
            var ops = new Stack<string>();
            var prev = string.Empty;

            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                {
                    output.Add(token);
                    prev = "num";
                    continue;
                }

                if (IsIdentifier(token))
                {
                    var isFuncao = i + 1 < tokens.Count && tokens[i + 1] == "(";
                    if (isFuncao)
                    {
                        ops.Push($"func:{token}");
                    }
                    else
                    {
                        output.Add(token);
                    }

                    prev = "id";
                    continue;
                }

                if (token == ",")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        output.Add(ops.Pop());
                    }
                    prev = ",";
                    continue;
                }

                if (token == "(")
                {
                    ops.Push(token);
                    prev = "(";
                    continue;
                }

                if (token == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        output.Add(ops.Pop());
                    }

                    if (ops.Count == 0)
                    {
                        return false;
                    }

                    ops.Pop(); // remove '('

                    if (ops.Count > 0 && ops.Peek().StartsWith("func:", StringComparison.Ordinal))
                    {
                        output.Add(ops.Pop()[5..]);
                    }

                    prev = ")";
                    continue;
                }

                if (IsOperator(token))
                {
                    var op = token;
                    if (op == "-" && (string.IsNullOrWhiteSpace(prev) || prev is "(" or "," or "op"))
                    {
                        op = "neg";
                        ops.Push(op);
                        prev = "op";
                        continue;
                    }

                    while (ops.Count > 0 && IsOperator(ops.Peek())
                        && ((IsLeftAssociative(op) && Precedence(op) <= Precedence(ops.Peek()))
                            || (!IsLeftAssociative(op) && Precedence(op) < Precedence(ops.Peek()))))
                    {
                        output.Add(ops.Pop());
                    }

                    ops.Push(op);
                    prev = "op";
                    continue;
                }

                return false;
            }

            while (ops.Count > 0)
            {
                var op = ops.Pop();
                if (op is "(" or ")")
                {
                    return false;
                }

                if (op.StartsWith("func:", StringComparison.Ordinal))
                {
                    output.Add(op[5..]);
                }
                else
                {
                    output.Add(op);
                }
            }

            return output.Count > 0;
        }

        private static double EvalRpn(List<string> rpn, Dictionary<string, double> vars)
        {
            var stack = new Stack<double>();
            foreach (var token in rpn)
            {
                if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out var n))
                {
                    stack.Push(n);
                    continue;
                }

                if (IsIdentifier(token) && !IsFunction(token) && !IsOperator(token))
                {
                    if (vars.TryGetValue(token, out var v))
                    {
                        stack.Push(v);
                    }
                    else
                    {
                        stack.Push(0.0);
                    }
                    continue;
                }

                if (IsOperator(token))
                {
                    if (token == "neg")
                    {
                        var a = stack.Count > 0 ? stack.Pop() : 0.0;
                        stack.Push(-a);
                        continue;
                    }

                    var b = stack.Count > 0 ? stack.Pop() : 0.0;
                    var a2 = stack.Count > 0 ? stack.Pop() : 0.0;
                    stack.Push(token switch
                    {
                        "+" => a2 + b,
                        "-" => a2 - b,
                        "*" => a2 * b,
                        "/" => a2 / Math.Max(1e-30, b),
                        "^" => Math.Pow(a2, b),
                        _ => double.NaN
                    });
                    continue;
                }

                if (FuncoesUnarias.Contains(token))
                {
                    var a = stack.Count > 0 ? stack.Pop() : 0.0;
                    stack.Push(token.ToLowerInvariant() switch
                    {
                        "sqrt" => Math.Sqrt(Math.Max(0.0, a)),
                        "exp" => Math.Exp(a),
                        "ln" => Math.Log(Math.Max(1e-30, a)),
                        "log" => Math.Log(Math.Max(1e-30, a)),
                        "log10" => Math.Log10(Math.Max(1e-30, a)),
                        "abs" => Math.Abs(a),
                        "sin" => Math.Sin(a),
                        "cos" => Math.Cos(a),
                        "tan" => Math.Tan(a),
                        "neg" => -a,
                        _ => double.NaN
                    });
                    continue;
                }

                if (FuncoesBinarias.Contains(token))
                {
                    var b = stack.Count > 0 ? stack.Pop() : 0.0;
                    var a = stack.Count > 0 ? stack.Pop() : 0.0;
                    stack.Push(token.ToLowerInvariant() switch
                    {
                        "pow" => Math.Pow(a, b),
                        "min" => Math.Min(a, b),
                        "max" => Math.Max(a, b),
                        _ => double.NaN
                    });
                    continue;
                }

                if (FuncoesTernarias.Contains(token))
                {
                    var c = stack.Count > 0 ? stack.Pop() : 0.0;
                    var b = stack.Count > 0 ? stack.Pop() : 0.0;
                    var a = stack.Count > 0 ? stack.Pop() : 0.0;
                    stack.Push(Math.Clamp(a, b, c));
                    continue;
                }

                return double.NaN;
            }

            return stack.Count > 0 ? stack.Pop() : double.NaN;
        }

        private static bool IsIdentifier(string token)
            => !string.IsNullOrWhiteSpace(token) && (char.IsLetter(token[0]) || token[0] == '_');

        private static bool IsFunction(string token)
            => FuncoesUnarias.Contains(token) || FuncoesBinarias.Contains(token) || FuncoesTernarias.Contains(token);

        private static bool IsOperator(string token)
            => token is "+" or "-" or "*" or "/" or "^" or "neg";

        private static int Precedence(string op)
            => op switch
            {
                "neg" => 5,
                "^" => 4,
                "*" or "/" => 3,
                "+" or "-" => 2,
                _ => 1
            };

        private static bool IsLeftAssociative(string op)
            => op != "^";
    }
}
