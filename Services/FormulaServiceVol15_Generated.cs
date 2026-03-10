using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using CompendioCalc.Models;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private sealed record Vol15Spec(
            string Codigo,
            string Nome,
            string Expressao,
            string Descricao,
            string Origem,
            string Exemplo,
            string Categoria,
            string SubCategoria);

        private static readonly Regex Vol15SimboloRegex = new(@"[A-Za-z_][A-Za-z0-9_]*", RegexOptions.Compiled);
        private static readonly HashSet<string> Vol15Ignorar = new(StringComparer.OrdinalIgnoreCase)
        {
            "resultado", "sin", "cos", "tan", "sqrt", "log", "ln", "exp", "abs", "min", "max", "pow", "pi", "e"
        };

        public void AdicionarFormulasVol15()
        {
            foreach (var spec in ObterSpecsLiteraisVol15())
            {
                _formulas.Add(CriarFormulaVol15(spec));
            }
        }

        private static Formula CriarFormulaVol15(Vol15Spec spec)
        {
            var codigoNumerico = int.TryParse(spec.Codigo, out var codigo) ? codigo : 0;
            var expressaoCalculavel = NormalizarExpressaoCalculavelVol15(spec.Expressao);
            var variavelResultado = ExtrairVariavelResultadoVol15(spec.Expressao);
            var variaveis = ExtrairVariaveisVol15(expressaoCalculavel, spec.Descricao);

            return new Formula
            {
                Id = $"v15_{codigoNumerico:000}",
                CodigoCompendio = $"V15-{codigoNumerico:000}",
                Nome = spec.Nome,
                Categoria = spec.Categoria,
                SubCategoria = spec.SubCategoria,
                Expressao = expressaoCalculavel,
                ExprTexto = spec.Expressao,
                Descricao = spec.Descricao,
                Criador = spec.Origem,
                AnoOrigin = "2026",
                ExemploPratico = spec.Exemplo,
                Unidades = "Consistentes com as variaveis de entrada.",
                VariavelResultado = variavelResultado,
                UnidadeResultado = "adim",
                Icone = "Fx",
                Variaveis = variaveis,
                Calcular = vars => CalcularExpressaoVol15(expressaoCalculavel, variaveis, vars)
            };
        }

        private static List<Variavel> ExtrairVariaveisVol15(string expressao, string descricao)
        {
            var mapaDescricoes = ExtrairMapaVariaveisDaDescricao(descricao);

            return Vol15SimboloRegex
                .Matches(expressao)
                .Select(m => m.Value)
                .Where(v => !Vol15Ignorar.Contains(v))
                .Distinct(StringComparer.Ordinal)
                .Select(v => new Variavel
                {
                    Simbolo = v,
                    Nome = mapaDescricoes.TryGetValue(v, out var texto) ? texto : $"Variavel {v}",
                    Descricao = mapaDescricoes.TryGetValue(v, out var descricaoVariavel) ? descricaoVariavel : $"Parametro {v} da formula.",
                    Unidade = "adim",
                    ValorPadrao = 1
                })
                .ToList();
        }

        private static string ObterLadoDireitoVol15(string expressao)
        {
            var idx = expressao.IndexOf('=');
            return idx >= 0 ? expressao[(idx + 1)..].Trim() : expressao.Trim();
        }

        private static string ExtrairVariavelResultadoVol15(string expressao)
        {
            var idx = expressao.IndexOf('=');
            if (idx < 0)
            {
                return "resultado";
            }

            var lhs = NormalizarExpressao(expressao[..idx]);
            var simbolo = Vol15SimboloRegex.Match(lhs).Value;
            return string.IsNullOrWhiteSpace(simbolo) ? "resultado" : simbolo;
        }

        private static string NormalizarExpressaoCalculavelVol15(string expressao)
        {
            var primaria = expressao.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).FirstOrDefault() ?? expressao;
            var rhs = ObterLadoDireitoVol15(primaria);
            rhs = Regex.Replace(rhs, @"([A-Za-z_][A-Za-z0-9_]*)\(([^()]*)\)", match =>
            {
                var nome = match.Groups[1].Value;
                if (EhFuncao(nome))
                {
                    return match.Value;
                }

                var argumentos = match.Groups[2].Value
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(NormalizarExpressao)
                    .Where(s => !string.IsNullOrWhiteSpace(s));

                return string.Join("_", new[] { nome }.Concat(argumentos));
            });

            return NormalizarExpressao(rhs);
        }

        private static Dictionary<string, string> ExtrairMapaVariaveisDaDescricao(string descricao)
        {
            var mapa = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var normalizada = NormalizarExpressao(descricao);
            foreach (Match match in Regex.Matches(normalizada, @"\b([A-Za-z_][A-Za-z0-9_]*)\s*=\s*([^,.;]+)"))
            {
                var simbolo = match.Groups[1].Value;
                var texto = match.Groups[2].Value.Trim();
                if (!Vol15Ignorar.Contains(simbolo) && !mapa.ContainsKey(simbolo))
                {
                    mapa[simbolo] = texto;
                }
            }

            return mapa;
        }

        private static double CalcularExpressaoVol15(string expressao, List<Variavel> variaveis, Dictionary<string, double> vars)
        {
            if (vars.TryGetValue("resultado", out var resultado))
            {
                return resultado;
            }

            var rhs = ObterLadoDireitoVol15(expressao);
            if (TryAvaliar(rhs, vars, out var valor))
            {
                return valor;
            }

            if (variaveis.Count > 0 && vars.TryGetValue(variaveis[0].Simbolo, out var fallback))
            {
                return fallback;
            }

            return 0;
        }

        private static bool TryAvaliar(string expr, Dictionary<string, double> vars, out double resultado)
        {
            resultado = 0;
            var norm = NormalizarExpressao(expr);
            if (string.IsNullOrWhiteSpace(norm))
            {
                return false;
            }

            try
            {
                var rpn = ParaRpn(Tokenizar(norm));
                var pilha = new Stack<double>();

                foreach (var t in rpn)
                {
                    if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out var num))
                    {
                        pilha.Push(num);
                        continue;
                    }

                    if (EhOperador(t))
                    {
                        if (pilha.Count < 2)
                        {
                            return false;
                        }

                        var b = pilha.Pop();
                        var a = pilha.Pop();
                        pilha.Push(t switch
                        {
                            "+" => a + b,
                            "-" => a - b,
                            "*" => a * b,
                            "/" => Math.Abs(b) < 1e-12 ? 0 : a / b,
                            "^" => Math.Pow(a, b),
                            _ => 0
                        });
                        continue;
                    }

                    if (EhFuncao(t))
                    {
                        if (!AplicarFuncao(t, pilha))
                        {
                            return false;
                        }
                        continue;
                    }

                    if (string.Equals(t, "pi", StringComparison.OrdinalIgnoreCase))
                    {
                        pilha.Push(Math.PI);
                        continue;
                    }

                    if (string.Equals(t, "e", StringComparison.OrdinalIgnoreCase))
                    {
                        pilha.Push(Math.E);
                        continue;
                    }

                    pilha.Push(vars.TryGetValue(t, out var v) ? v : 1);
                }

                if (pilha.Count != 1)
                {
                    return false;
                }

                resultado = pilha.Pop();
                return !double.IsNaN(resultado) && !double.IsInfinity(resultado);
            }
            catch
            {
                return false;
            }
        }

        private static bool AplicarFuncao(string funcao, Stack<double> pilha)
        {
            switch (funcao.ToLowerInvariant())
            {
                case "sin":
                case "cos":
                case "tan":
                case "sqrt":
                case "log":
                case "ln":
                case "exp":
                case "abs":
                    if (pilha.Count < 1) return false;
                    var a = pilha.Pop();
                    pilha.Push(funcao.ToLowerInvariant() switch
                    {
                        "sin" => Math.Sin(a),
                        "cos" => Math.Cos(a),
                        "tan" => Math.Tan(a),
                        "sqrt" => a < 0 ? 0 : Math.Sqrt(a),
                        "log" => a <= 0 ? 0 : Math.Log10(a),
                        "ln" => a <= 0 ? 0 : Math.Log(a),
                        "exp" => Math.Exp(a),
                        "abs" => Math.Abs(a),
                        _ => 0
                    });
                    return true;
                case "min":
                case "max":
                case "pow":
                    if (pilha.Count < 2) return false;
                    var b = pilha.Pop();
                    var x = pilha.Pop();
                    pilha.Push(funcao.ToLowerInvariant() switch
                    {
                        "min" => Math.Min(x, b),
                        "max" => Math.Max(x, b),
                        "pow" => Math.Pow(x, b),
                        _ => 0
                    });
                    return true;
                default:
                    return false;
            }
        }

        private static string NormalizarExpressao(string expr)
        {
            var s = expr
                .Replace("×", "*")
                .Replace("·", "*")
                .Replace("−", "-")
                .Replace("–", "-")
                .Replace("÷", "/")
                .Replace("≈", "")
                .Replace(";", "")
                .Replace("σ", "sigma")
                .Replace("Δ", "d")
                .Replace("θ", "theta")
                .Replace("λ", "lambda")
                .Replace("ω", "omega")
                .Replace("μ", "mu")
                .Replace("ρ", "rho")
                .Replace("φ", "phi")
                .Replace("γ", "gamma")
                .Replace("π", "pi")
                .Replace("ℏ", "hbar")
                .Replace("²", "^2")
                .Replace("³", "^3")
                .Replace("⁴", "^4")
                .Replace("⁻", "-");

            s = Regex.Replace(s, @"[^A-Za-z0-9_+\-*/^()., ]", " ");
            s = Regex.Replace(s, @"\s+", " ").Trim();
            return s;
        }

        private static List<string> Tokenizar(string expr)
        {
            var tokens = new List<string>();
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
                    var j = i;
                    while (j < expr.Length && (char.IsDigit(expr[j]) || expr[j] == '.')) j++;
                    tokens.Add(expr[i..j]);
                    i = j;
                    continue;
                }

                if (char.IsLetter(c) || c == '_')
                {
                    var j = i;
                    while (j < expr.Length && (char.IsLetterOrDigit(expr[j]) || expr[j] == '_')) j++;
                    tokens.Add(expr[i..j]);
                    i = j;
                    continue;
                }

                if (",()+-*/^".Contains(c))
                {
                    tokens.Add(c.ToString());
                    i++;
                    continue;
                }

                i++;
            }

            return AjustarUnario(tokens);
        }

        private static List<string> AjustarUnario(List<string> tokens)
        {
            var outTokens = new List<string>();
            for (var i = 0; i < tokens.Count; i++)
            {
                var t = tokens[i];
                if (t == "-" && (i == 0 || tokens[i - 1] == "(" || EhOperador(tokens[i - 1]) || tokens[i - 1] == ","))
                {
                    outTokens.Add("0");
                }
                outTokens.Add(t);
            }

            return outTokens;
        }

        private static Queue<string> ParaRpn(List<string> tokens)
        {
            var saida = new Queue<string>();
            var ops = new Stack<string>();

            for (var i = 0; i < tokens.Count; i++)
            {
                var t = tokens[i];
                if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out _) || EhVariavelOuConstante(t))
                {
                    if (EhFuncao(t) && i + 1 < tokens.Count && tokens[i + 1] == "(")
                    {
                        ops.Push(t);
                    }
                    else
                    {
                        saida.Enqueue(t);
                    }
                    continue;
                }

                if (t == ",")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        saida.Enqueue(ops.Pop());
                    }
                    continue;
                }

                if (EhOperador(t))
                {
                    while (ops.Count > 0 && EhOperador(ops.Peek()) &&
                           ((AssociatividadeEsquerda(t) && Precedencia(t) <= Precedencia(ops.Peek())) ||
                            (!AssociatividadeEsquerda(t) && Precedencia(t) < Precedencia(ops.Peek()))))
                    {
                        saida.Enqueue(ops.Pop());
                    }
                    ops.Push(t);
                    continue;
                }

                if (t == "(")
                {
                    ops.Push(t);
                    continue;
                }

                if (t == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        saida.Enqueue(ops.Pop());
                    }
                    if (ops.Count > 0 && ops.Peek() == "(")
                    {
                        ops.Pop();
                    }
                    if (ops.Count > 0 && EhFuncao(ops.Peek()))
                    {
                        saida.Enqueue(ops.Pop());
                    }
                }
            }

            while (ops.Count > 0)
            {
                saida.Enqueue(ops.Pop());
            }

            return saida;
        }

        private static bool EhVariavelOuConstante(string t)
            => Regex.IsMatch(t, @"^[A-Za-z_][A-Za-z0-9_]*$");

        private static bool EhOperador(string t)
            => t is "+" or "-" or "*" or "/" or "^";

        private static int Precedencia(string op)
            => op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "^" => 3,
                _ => 0
            };

        private static bool AssociatividadeEsquerda(string op) => op != "^";

        private static bool EhFuncao(string t)
            => t.Equals("sin", StringComparison.OrdinalIgnoreCase)
                || t.Equals("cos", StringComparison.OrdinalIgnoreCase)
                || t.Equals("tan", StringComparison.OrdinalIgnoreCase)
                || t.Equals("sqrt", StringComparison.OrdinalIgnoreCase)
                || t.Equals("log", StringComparison.OrdinalIgnoreCase)
                || t.Equals("ln", StringComparison.OrdinalIgnoreCase)
                || t.Equals("exp", StringComparison.OrdinalIgnoreCase)
                || t.Equals("abs", StringComparison.OrdinalIgnoreCase)
                || t.Equals("min", StringComparison.OrdinalIgnoreCase)
                || t.Equals("max", StringComparison.OrdinalIgnoreCase)
                || t.Equals("pow", StringComparison.OrdinalIgnoreCase);

        private static List<Vol15Spec> ObterSpecsLiteraisVol15()
        {
            var bruto = string.Join("\n", ObterBlocosLiteraisVol15());
            return ParsearSpecsVol15(bruto);
        }

        private static IEnumerable<string> ObterBlocosLiteraisVol15()
        {
            yield return Vol15Parte1;
            yield return Vol15Parte2;
            yield return Vol15Parte3;
            yield return Vol15Parte4;
        }

        private static List<Vol15Spec> ParsearSpecsVol15(string bruto)
        {
            var linhas = bruto.Split('\n').Select(l => l.Trim()).ToList();
            var specs = new List<Vol15Spec>(320);
            string categoria = string.Empty;
            string subCategoria = string.Empty;

            for (var i = 0; i < linhas.Count; i++)
            {
                var linha = linhas[i];
                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue;
                }

                if (Regex.IsMatch(linha, @"^\d{3}$"))
                {
                    var codigo = linha;
                    var nome = ProximaLinhaNaoVazia(linhas, ref i);
                    var nivel = ProximaLinhaNaoVazia(linhas, ref i);
                    _ = nivel;
                    var expressao = ProximaLinhaNaoVazia(linhas, ref i);
                    var descricao = ColetarAtePrefixo(linhas, ref i, "ORIGEM");
                    var origemLinha = ProximaLinhaNaoVazia(linhas, ref i);
                    var origem = origemLinha.StartsWith("ORIGEM", StringComparison.OrdinalIgnoreCase)
                        ? origemLinha[6..].Trim()
                        : origemLinha;
                    var exemplo = ColetarExemplo(linhas, ref i);

                    specs.Add(new Vol15Spec(codigo, nome, expressao, descricao, origem, exemplo, categoria, subCategoria));
                    continue;
                }

                if (i + 1 < linhas.Count && !Regex.IsMatch(linha, @"^\d{3}$") && !Regex.IsMatch(linhas[i + 1], @"^\d{3}$"))
                {
                    categoria = linha;
                    subCategoria = linhas[++i];
                }
            }

            return specs;
        }

        private static string ProximaLinhaNaoVazia(List<string> linhas, ref int indice)
        {
            while (++indice < linhas.Count)
            {
                if (!string.IsNullOrWhiteSpace(linhas[indice]))
                {
                    return linhas[indice];
                }
            }

            return string.Empty;
        }

        private static string ColetarAtePrefixo(List<string> linhas, ref int indice, string prefixo)
        {
            var partes = new List<string>();
            while (indice + 1 < linhas.Count)
            {
                var proxima = linhas[indice + 1];
                if (string.IsNullOrWhiteSpace(proxima))
                {
                    indice++;
                    continue;
                }

                if (proxima.StartsWith(prefixo, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                indice++;
                partes.Add(proxima);
            }

            return string.Join(" ", partes);
        }

        private static string ColetarExemplo(List<string> linhas, ref int indice)
        {
            while (indice + 1 < linhas.Count)
            {
                var proxima = linhas[indice + 1];
                if (string.IsNullOrWhiteSpace(proxima))
                {
                    indice++;
                    continue;
                }

                if (proxima.StartsWith("▶", StringComparison.Ordinal))
                {
                    indice++;
                    return proxima[1..].Trim();
                }

                break;
            }

            return string.Empty;
        }
    }
}
