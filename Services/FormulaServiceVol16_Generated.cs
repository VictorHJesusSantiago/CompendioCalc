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
        private sealed record Vol16Spec(
            string Codigo,
            string Nome,
            string Expressao,
            string Descricao,
            string Origem,
            string Exemplo,
            string Categoria,
            string SubCategoria);

        private sealed record Vol16Override(
            string Expressao,
            string VariavelResultado,
            string UnidadeResultado,
            List<Variavel> Variaveis,
            Func<Dictionary<string, double>, double>? Calculadora = null);

        private static readonly Regex Vol16SimboloRegex = new(@"[A-Za-z_][A-Za-z0-9_]*", RegexOptions.Compiled);
        private static readonly HashSet<string> Vol16Ignorar = new(StringComparer.OrdinalIgnoreCase)
        {
            "resultado", "sin", "cos", "tan", "asin", "acos", "atan", "sqrt", "log", "log2", "ln", "exp", "abs", "min", "max", "pow", "erfc", "qfunc", "pi", "e"
        };

        private static readonly Dictionary<string, Vol16Override> Vol16Overrides = new(StringComparer.Ordinal)
        {
        };

        public void AdicionarFormulasVol16()
        {
            foreach (var spec in ObterSpecsLiteraisVol16())
            {
                _formulas.Add(CriarFormulaVol16(spec));
            }
        }

        private static Formula CriarFormulaVol16(Vol16Spec spec)
        {
            var codigoNumerico = int.TryParse(spec.Codigo, out var codigo) ? codigo : 0;
            var overrideFormula = Vol16Overrides.TryGetValue(spec.Codigo, out var formulaOverride) ? formulaOverride : null;
            var expressaoCalculavel = overrideFormula?.Expressao ?? NormalizarExpressaoCalculavelVol16(spec.Expressao);
            var variavelResultado = overrideFormula?.VariavelResultado ?? ExtrairVariavelResultadoVol16(spec.Expressao);
            var unidadeResultado = overrideFormula?.UnidadeResultado ?? "adim";
            var variaveis = overrideFormula is null
                ? ExtrairVariaveisVol16(expressaoCalculavel, spec.Descricao)
                : ClonarVariaveisVol16(overrideFormula.Variaveis);

            return new Formula
            {
                Id = $"v16_{codigoNumerico:000}",
                CodigoCompendio = $"V16-{codigoNumerico:000}",
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
                UnidadeResultado = unidadeResultado,
                Icone = "Fx",
                Variaveis = variaveis,
                Calcular = overrideFormula?.Calculadora is null
                    ? vars => CalcularExpressaoVol16(expressaoCalculavel, variaveis, vars)
                    : vars => overrideFormula.Calculadora(vars)
            };
        }

        private static Variavel NovaVariavelVol16(string simbolo, string nome, string descricao, string unidade = "adim", double valorPadrao = 1)
            => new()
            {
                Simbolo = simbolo,
                Nome = nome,
                Descricao = descricao,
                Unidade = unidade,
                ValorPadrao = valorPadrao
            };

        private static List<Variavel> ClonarVariaveisVol16(IEnumerable<Variavel> variaveis)
            => variaveis
                .Select(v => new Variavel
                {
                    Simbolo = v.Simbolo,
                    Nome = v.Nome,
                    Descricao = v.Descricao,
                    Unidade = v.Unidade,
                    ValorPadrao = v.ValorPadrao,
                    ValorMin = v.ValorMin,
                    ValorMax = v.ValorMax,
                    Obrigatoria = v.Obrigatoria
                })
                .ToList();

        private static double ValorVariavelVol16(Dictionary<string, double> vars, string simbolo, double padrao = 0)
            => vars.TryGetValue(simbolo, out var valor) ? valor : padrao;

        private static int BitVol16(Dictionary<string, double> vars, string simbolo)
            => Math.Abs((int)Math.Round(ValorVariavelVol16(vars, simbolo, 0))) % 2;

        private static double MutualInformationTermVol16(double joint, double px, double py)
            => joint > 0 && px > 0 && py > 0 ? joint * Math.Log2(joint / (px * py)) : 0;

        private static double RelativeEntropyTermVol16(double p, double q)
            => p > 0 && q > 0 ? p * Math.Log(p / q) : 0;

        private static double FidelityVol16(double psiIdeal0, double psiIdeal1, double psiReal0, double psiReal1)
        {
            var normaIdeal = psiIdeal0 * psiIdeal0 + psiIdeal1 * psiIdeal1;
            var normaReal = psiReal0 * psiReal0 + psiReal1 * psiReal1;
            if (normaIdeal <= 0 || normaReal <= 0)
            {
                return 0;
            }

            var overlap = psiIdeal0 * psiReal0 + psiIdeal1 * psiReal1;
            return (overlap * overlap) / (normaIdeal * normaReal);
        }

        private static double HammingDistanceVol16(Dictionary<string, double> vars, params (string X, string Y)[] pares)
            => pares.Count(par => BitVol16(vars, par.X) != BitVol16(vars, par.Y));

        private static List<Variavel> ExtrairVariaveisVol16(string expressao, string descricao)
        {
            var mapaDescricoes = ExtrairMapaVariaveisDaDescricaoVol16(descricao);

            return Vol16SimboloRegex
                .Matches(expressao)
                .Select(m => m.Value)
                .Where(v => !Vol16Ignorar.Contains(v))
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

        private static string ObterLadoDireitoVol16(string expressao)
        {
            var idx = expressao.IndexOf('=');
            return idx >= 0 ? expressao[(idx + 1)..].Trim() : expressao.Trim();
        }

        private static string ExtrairVariavelResultadoVol16(string expressao)
        {
            var idx = expressao.IndexOf('=');
            if (idx < 0)
            {
                return "resultado";
            }

            var lhs = NormalizarExpressaoVol16(expressao[..idx]);
            var simbolo = Vol16SimboloRegex.Match(lhs).Value;
            return string.IsNullOrWhiteSpace(simbolo) ? "resultado" : simbolo;
        }

        private static string NormalizarExpressaoCalculavelVol16(string expressao)
        {
            var primaria = expressao.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).FirstOrDefault() ?? expressao;
            var rhs = ObterLadoDireitoVol16(primaria);
            rhs = ExpandirSomaQuadraticaVol16(rhs);
            rhs = Regex.Replace(rhs, @"([A-Za-z_][A-Za-z0-9_]*)\(([^()]*)\)", match =>
            {
                var nome = match.Groups[1].Value;
                if (EhFuncaoVol16(nome))
                {
                    return match.Value;
                }

                var argumentos = match.Groups[2].Value
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(NormalizarExpressaoVol16)
                    .Where(s => !string.IsNullOrWhiteSpace(s));

                return string.Join("_", new[] { nome }.Concat(argumentos));
            });

            return NormalizarExpressaoVol16(rhs);
        }

        private static Dictionary<string, string> ExtrairMapaVariaveisDaDescricaoVol16(string descricao)
        {
            var mapa = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var normalizada = NormalizarExpressaoVol16(descricao);
            foreach (Match match in Regex.Matches(normalizada, @"\b([A-Za-z_][A-Za-z0-9_]*)\s*=\s*([^,.;]+)"))
            {
                var simbolo = match.Groups[1].Value;
                var texto = match.Groups[2].Value.Trim();
                if (!Vol16Ignorar.Contains(simbolo) && !mapa.ContainsKey(simbolo))
                {
                    mapa[simbolo] = texto;
                }
            }

            return mapa;
        }

        private static double CalcularExpressaoVol16(string expressao, List<Variavel> variaveis, Dictionary<string, double> vars)
        {
            if (vars.TryGetValue("resultado", out var resultado))
            {
                return resultado;
            }

            var rhs = ObterLadoDireitoVol16(expressao);
            if (TryAvaliarVol16(rhs, vars, out var valor))
            {
                return valor;
            }

            if (variaveis.Count > 0 && vars.TryGetValue(variaveis[0].Simbolo, out var fallback))
            {
                return fallback;
            }

            return 0;
        }

        private static bool TryAvaliarVol16(string expr, Dictionary<string, double> vars, out double resultado)
        {
            resultado = 0;
            var norm = NormalizarExpressaoVol16(expr);
            if (string.IsNullOrWhiteSpace(norm))
            {
                return false;
            }

            try
            {
                var rpn = ParaRpnVol16(TokenizarVol16(norm));
                var pilha = new Stack<double>();

                foreach (var t in rpn)
                {
                    if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out var num))
                    {
                        pilha.Push(num);
                        continue;
                    }

                    if (EhOperadorVol16(t))
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

                    if (EhFuncaoVol16(t))
                    {
                        if (!AplicarFuncaoVol16(t, pilha))
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

        private static bool AplicarFuncaoVol16(string funcao, Stack<double> pilha)
        {
            switch (funcao.ToLowerInvariant())
            {
                case "sin":
                case "cos":
                case "tan":
                case "asin":
                case "acos":
                case "atan":
                case "sqrt":
                case "log":
                case "log2":
                case "ln":
                case "exp":
                case "abs":
                case "erfc":
                case "qfunc":
                    if (pilha.Count < 1) return false;
                    var a = pilha.Pop();
                    pilha.Push(funcao.ToLowerInvariant() switch
                    {
                        "sin" => Math.Sin(a),
                        "cos" => Math.Cos(a),
                        "tan" => Math.Tan(a),
                        "asin" => Math.Asin(a),
                        "acos" => Math.Acos(a),
                        "atan" => Math.Atan(a),
                        "sqrt" => a < 0 ? 0 : Math.Sqrt(a),
                        "log" => a <= 0 ? 0 : Math.Log10(a),
                        "log2" => a <= 0 ? 0 : Math.Log2(a),
                        "ln" => a <= 0 ? 0 : Math.Log(a),
                        "exp" => Math.Exp(a),
                        "abs" => Math.Abs(a),
                        "erfc" => ErfcVol16(a),
                        "qfunc" => 0.5 * ErfcVol16(a / Math.Sqrt(2)),
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

        private static string NormalizarExpressaoVol16(string expr)
        {
            var s = expr
                .Replace("√", "sqrt")
                .Replace("×", "*")
                .Replace("·", "*")
                .Replace("−", "-")
                .Replace("–", "-")
                .Replace("÷", "/")
                .Replace("≈", "")
                .Replace("⊕", "⊕")
                .Replace(";", "")
                .Replace("[", "(")
                .Replace("]", ")")
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
                .Replace("₀", "0")
                .Replace("₁", "1")
                .Replace("₂", "2")
                .Replace("₃", "3")
                .Replace("₄", "4")
                .Replace("₅", "5")
                .Replace("₆", "6")
                .Replace("₇", "7")
                .Replace("₈", "8")
                .Replace("₉", "9")
                .Replace("⁰", "^0")
                .Replace("¹", "^1")
                .Replace("²", "^2")
                .Replace("³", "^3")
                .Replace("⁴", "^4")
                .Replace("⁵", "^5")
                .Replace("⁶", "^6")
                .Replace("⁷", "^7")
                .Replace("⁸", "^8")
                .Replace("⁹", "^9")
                .Replace("⁻", "-");

            s = s.Replace("arctan", "atan", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("arcsin", "asin", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("arccos", "acos", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("log₂", "log2", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("log2", "log2", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("Q(", "qfunc(", StringComparison.OrdinalIgnoreCase);
            s = Regex.Replace(s, @"\|([^|]+)\|", "abs($1)");

            s = Regex.Replace(s, @"[^A-Za-z0-9_+\-*/^()., ⊕]", " ");
            s = Regex.Replace(s, @"\s+", " ").Trim();
            return s;
        }

        private static List<string> TokenizarVol16(string expr)
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

            return AjustarUnarioVol16(InserirMultiplicacaoImplicitaVol16(tokens));
        }

        private static List<string> InserirMultiplicacaoImplicitaVol16(List<string> tokens)
        {
            if (tokens.Count < 2)
            {
                return tokens;
            }

            var resultado = new List<string>(tokens.Count * 2);
            for (var i = 0; i < tokens.Count; i++)
            {
                var atual = tokens[i];
                resultado.Add(atual);

                if (i == tokens.Count - 1)
                {
                    continue;
                }

                var proximo = tokens[i + 1];
                if (PrecisaMultiplicacaoImplicitaVol16(atual, proximo))
                {
                    resultado.Add("*");
                }
            }

            return resultado;
        }

        private static bool PrecisaMultiplicacaoImplicitaVol16(string atual, string proximo)
        {
            if (EhFuncaoVol16(atual) && proximo == "(")
            {
                return false;
            }

            return EhOperandoParaMultiplicacaoVol16(atual) && EhOperandoParaMultiplicacaoDireitaVol16(proximo);
        }

        private static bool EhOperandoParaMultiplicacaoVol16(string token)
            => double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _)
               || EhVariavelOuConstanteVol16(token)
               || token == ")";

        private static bool EhOperandoParaMultiplicacaoDireitaVol16(string token)
            => double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _)
               || EhVariavelOuConstanteVol16(token)
               || token == "(";

        private static List<string> AjustarUnarioVol16(List<string> tokens)
        {
            var outTokens = new List<string>();
            for (var i = 0; i < tokens.Count; i++)
            {
                var t = tokens[i];
                if (t == "-" && (i == 0 || tokens[i - 1] == "(" || EhOperadorVol16(tokens[i - 1]) || tokens[i - 1] == ","))
                {
                    outTokens.Add("0");
                }
                outTokens.Add(t);
            }

            return outTokens;
        }

        private static Queue<string> ParaRpnVol16(List<string> tokens)
        {
            var saida = new Queue<string>();
            var ops = new Stack<string>();

            for (var i = 0; i < tokens.Count; i++)
            {
                var t = tokens[i];
                if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out _) || EhVariavelOuConstanteVol16(t))
                {
                    if (EhFuncaoVol16(t) && i + 1 < tokens.Count && tokens[i + 1] == "(")
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

                if (EhOperadorVol16(t))
                {
                    while (ops.Count > 0 && EhOperadorVol16(ops.Peek()) &&
                           ((AssociatividadeEsquerdaVol16(t) && PrecedenciaVol16(t) <= PrecedenciaVol16(ops.Peek())) ||
                            (!AssociatividadeEsquerdaVol16(t) && PrecedenciaVol16(t) < PrecedenciaVol16(ops.Peek()))))
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
                    if (ops.Count > 0 && EhFuncaoVol16(ops.Peek()))
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

        private static bool EhVariavelOuConstanteVol16(string t)
            => Regex.IsMatch(t, @"^[A-Za-z_][A-Za-z0-9_]*$");

        private static bool EhOperadorVol16(string t)
            => t is "+" or "-" or "*" or "/" or "^";

        private static int PrecedenciaVol16(string op)
            => op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "^" => 3,
                _ => 0
            };

        private static bool AssociatividadeEsquerdaVol16(string op) => op != "^";

        private static bool EhFuncaoVol16(string t)
            => t.Equals("sin", StringComparison.OrdinalIgnoreCase)
                || t.Equals("cos", StringComparison.OrdinalIgnoreCase)
                || t.Equals("tan", StringComparison.OrdinalIgnoreCase)
                || t.Equals("asin", StringComparison.OrdinalIgnoreCase)
                || t.Equals("acos", StringComparison.OrdinalIgnoreCase)
                || t.Equals("atan", StringComparison.OrdinalIgnoreCase)
                || t.Equals("sqrt", StringComparison.OrdinalIgnoreCase)
                || t.Equals("log", StringComparison.OrdinalIgnoreCase)
                || t.Equals("log2", StringComparison.OrdinalIgnoreCase)
                || t.Equals("ln", StringComparison.OrdinalIgnoreCase)
                || t.Equals("exp", StringComparison.OrdinalIgnoreCase)
                || t.Equals("abs", StringComparison.OrdinalIgnoreCase)
                || t.Equals("erfc", StringComparison.OrdinalIgnoreCase)
                || t.Equals("qfunc", StringComparison.OrdinalIgnoreCase)
                || t.Equals("min", StringComparison.OrdinalIgnoreCase)
                || t.Equals("max", StringComparison.OrdinalIgnoreCase)
                || t.Equals("pow", StringComparison.OrdinalIgnoreCase);

        private static string ExpandirSomaQuadraticaVol16(string expressao)
        {
            if (!expressao.Contains('⊕'))
            {
                return expressao;
            }

            var termos = expressao
                .Split('⊕', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(t => $"({t.Trim()})^2");

            return $"sqrt({string.Join("+", termos)})";
        }

        private static double ErfcVol16(double x)
        {
            var z = Math.Abs(x);
            var t = 1.0 / (1.0 + 0.5 * z);
            var r = t * Math.Exp(-z * z - 1.26551223 +
                                 t * (1.00002368 +
                                 t * (0.37409196 +
                                 t * (0.09678418 +
                                 t * (-0.18628806 +
                                 t * (0.27886807 +
                                 t * (-1.13520398 +
                                 t * (1.48851587 +
                                 t * (-0.82215223 +
                                 t * 0.17087277)))))))));

            return x >= 0 ? r : 2 - r;
        }

        private static List<Vol16Spec> ObterSpecsLiteraisVol16()
        {
            var bruto = string.Join("\n", ObterBlocosLiteraisVol16());
            return ParsearSpecsVol16(bruto);
        }

        private static IEnumerable<string> ObterBlocosLiteraisVol16()
        {
            yield return Vol16Parte1;
            yield return Vol16Parte2;
            yield return Vol16Parte3;
            yield return Vol16Parte4;
        }

        private static List<Vol16Spec> ParsearSpecsVol16(string bruto)
        {
            var linhas = bruto.Split('\n').Select(l => l.Trim()).ToList();
            var specs = new List<Vol16Spec>(320);
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
                    var nome = ProximaLinhaNaoVaziaVol16(linhas, ref i);
                    var nivel = ProximaLinhaNaoVaziaVol16(linhas, ref i);
                    _ = nivel;
                    var expressao = ProximaLinhaNaoVaziaVol16(linhas, ref i);
                    var descricao = ColetarAtePrefixoVol16(linhas, ref i, "ORIGEM");
                    var origemLinha = ProximaLinhaNaoVaziaVol16(linhas, ref i);
                    var origem = origemLinha.StartsWith("ORIGEM", StringComparison.OrdinalIgnoreCase)
                        ? origemLinha[6..].Trim()
                        : origemLinha;
                    var exemplo = ColetarExemploVol16(linhas, ref i);

                    specs.Add(new Vol16Spec(codigo, nome, expressao, descricao, origem, exemplo, categoria, subCategoria));
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

        private static string ProximaLinhaNaoVaziaVol16(List<string> linhas, ref int indice)
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

        private static string ColetarAtePrefixoVol16(List<string> linhas, ref int indice, string prefixo)
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

        private static string ColetarExemploVol16(List<string> linhas, ref int indice)
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
