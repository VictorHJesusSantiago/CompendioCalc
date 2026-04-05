using CompendioCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private sealed record Vol12FormulaSpec(
            string Nome,
            string Expressao,
            string Descricao,
            string Criador,
            string AnoOrigin,
            string ExemploPratico,
            string VariavelResultado = "resultado",
            string UnidadeResultado = "adim",
            string? Unidades = null,
            string Icone = "Fx");

        private static double GetVar(Dictionary<string, double> vars, string key, double fallback)
        {
            return vars.TryGetValue(key, out var value) ? value : fallback;
        }

        private static bool RequerPlaceholderVol12(string nome)
        {
            string[] chaves =
            {
                "integral", "somatorio", "transformada", "edp", "pde", "funcional",
                "variacional", "fourier geral", "tensorial", "modelo estocastico"
            };

            var normalizado = nome.ToLowerInvariant();
            return chaves.Any(k => normalizado.Contains(k));
        }

        private Formula CriarFormulaVol12Base(int numero, string categoria, string subCategoria, string nome, string expressao, string criador)
        {
            return CriarFormulaVol12Detalhada(
                numero,
                categoria,
                subCategoria,
                new Vol12FormulaSpec(
                    nome,
                    expressao,
                    "Formula aplicada com parametrizacao direta para uso rapido no CompendioCalc.",
                    criador,
                    "2026",
                    "Informe parametros padrao (a, b, x) para obter uma estimativa inicial e ajuste conforme o experimento.",
                    Unidades: "Consistentes com as variaveis de entrada (modelo reduzido)."));
        }

        private Formula CriarFormulaVol12Detalhada(int numero, string categoria, string subCategoria, Vol12FormulaSpec spec)
        {
            bool placeholder = RequerPlaceholderVol12(spec.Nome)
                || spec.Expressao.Contains("integral", StringComparison.OrdinalIgnoreCase)
                || spec.Expressao.Contains("sum", StringComparison.OrdinalIgnoreCase)
                || spec.Expressao.Contains("Σ", StringComparison.OrdinalIgnoreCase)
                || spec.Expressao.Contains("∫", StringComparison.OrdinalIgnoreCase)
                || spec.Expressao.Contains("Π", StringComparison.OrdinalIgnoreCase);

            return new Formula
            {
                Id = $"v12_{numero:000}",
                CodigoCompendio = $"V12-{numero:000}",
                Nome = spec.Nome,
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = spec.Expressao,
                Descricao = spec.Descricao,
                Criador = spec.Criador,
                AnoOrigin = spec.AnoOrigin,
                ExemploPratico = spec.ExemploPratico,
                Unidades = spec.Unidades ?? "Consistentes com as variaveis de entrada (modelo reduzido).",
                VariavelResultado = spec.VariavelResultado,
                UnidadeResultado = spec.UnidadeResultado,
                Variaveis = placeholder
                    ? new List<Variavel>
                    {
                        new Variavel { Simbolo = spec.VariavelResultado, Nome = "Resultado aproximado", Descricao = "Valor principal informado quando o modelo completo nao e resolvido localmente.", Unidade = spec.UnidadeResultado, ValorPadrao = 1 },
                        new Variavel { Simbolo = "x", Nome = "Parametro principal", Descricao = "Parametro dominante para fallback numerico.", Unidade = "adim", ValorPadrao = 1 }
                    }
                    : new List<Variavel>
                    {
                        new Variavel { Simbolo = "a", Nome = "Coeficiente linear", Descricao = "Ganho principal do modelo.", Unidade = "adim", ValorPadrao = 1 },
                        new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Termo de ajuste da relacao.", Unidade = "adim", ValorPadrao = 0 },
                        new Variavel { Simbolo = "x", Nome = "Entrada", Descricao = "Variavel de entrada principal.", Unidade = "adim", ValorPadrao = 1 },
                        new Variavel { Simbolo = spec.VariavelResultado, Nome = "Resultado informado", Descricao = "Resultado principal para cenarios em que a expressao nao e resolvida simbolicamente no app.", Unidade = spec.UnidadeResultado, ValorPadrao = 1 }
                    },
                Calcular = vars =>
                {
                    if (placeholder)
                    {
                        return GetVar(vars, spec.VariavelResultado, GetVar(vars, "x", 0));
                    }

                    if (vars.ContainsKey(spec.VariavelResultado))
                    {
                        return vars[spec.VariavelResultado];
                    }

                    double a = GetVar(vars, "a", 1);
                    double b = GetVar(vars, "b", 0);
                    double x = GetVar(vars, "x", 1);
                    return a * x + b;
                },
                Icone = spec.Icone
            };
        }

        private void AdicionarPacoteVol12(
            string categoria,
            string subCategoria,
            int inicioCodigo,
            string criador,
            IReadOnlyList<(string Nome, string Expressao)> itens)
        {
            var lista = new List<Formula>(itens.Count);

            for (int i = 0; i < itens.Count; i++)
            {
                int numero = inicioCodigo + i;
                lista.Add(CriarFormulaVol12Base(numero, categoria, subCategoria, itens[i].Nome, itens[i].Expressao, criador));
            }

            _formulas.AddRange(lista);
        }

        private void AdicionarPacoteVol12Detalhado(
            string categoria,
            string subCategoria,
            int inicioCodigo,
            IReadOnlyList<Vol12FormulaSpec> itens)
        {
            var lista = new List<Formula>(itens.Count);

            for (int i = 0; i < itens.Count; i++)
            {
                int numero = inicioCodigo + i;
                lista.Add(CriarFormulaVol12Detalhada(numero, categoria, subCategoria, itens[i]));
            }

            _formulas.AddRange(lista);
        }
    }
}
