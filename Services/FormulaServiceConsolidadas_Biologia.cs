using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Biologia
    /// Fórmulas reais e bibliografadas da área de Biologia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Biologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C301",
                    CodigoCompendio = "CB-001",
                    Nome = "Equação de Hardy-Weinberg",
                    Categoria = "Biologia",
                    SubCategoria = "Genética Populacional",
                    Expressao = "p² + 2pq + q² = 1",
                    Descricao = "Frequências genotípicas em equilíbrio em uma população ideal.",
                    Criador = "G. H. Hardy & W. Weinberg",
                    AnoOrigin = "1908",
                    ReferenciaBibliografica = "Hardy, G. H. Science, 1908; Weinberg, W. Jahreshefte des Vereins für vaterländische Naturkunde in Württemberg, 1908.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Frequência do alelo p", Simbolo = "p", Unidade = "", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Frequência do alelo q", Simbolo = "q", Unidade = "", ValorPadrao = 0.5 }
                    },
                    Calcular = inputs => inputs["Frequência do alelo p"] * inputs["Frequência do alelo p"] + 2 * inputs["Frequência do alelo p"] * inputs["Frequência do alelo q"] + inputs["Frequência do alelo q"] * inputs["Frequência do alelo q"],
                    VariavelResultado = "Total",
                    UnidadeResultado = ""
                },
                new Formula
                {
                    Id = "C302",
                    CodigoCompendio = "CB-002",
                    Nome = "Taxa de Crescimento Populacional Exponencial",
                    Categoria = "Biologia",
                    SubCategoria = "Ecologia",
                    Expressao = "N(t) = N₀·e^(rt)",
                    Descricao = "Modelo de crescimento populacional sem limitação de recursos.",
                    Criador = "Thomas Malthus",
                    AnoOrigin = "1798",
                    ReferenciaBibliografica = "Malthus, T. R. An Essay on the Principle of Population, 1798.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "População inicial", Simbolo = "N₀", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Taxa de crescimento", Simbolo = "r", Unidade = "1/ano", ValorPadrao = 0.01 },
                        new Variavel { Nome = "Tempo", Simbolo = "t", Unidade = "anos", ValorPadrao = 10 }
                    },
                    Calcular = inputs => inputs["População inicial"] * System.Math.Exp(inputs["Taxa de crescimento"] * inputs["Tempo"]),
                    VariavelResultado = "População",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
