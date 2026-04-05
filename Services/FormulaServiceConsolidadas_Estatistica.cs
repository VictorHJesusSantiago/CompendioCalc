using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Estatística
    /// Fórmulas reais e bibliografadas da área de Estatística
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Estatistica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C501",
                    CodigoCompendio = "CS-001",
                    Nome = "Média Aritmética",
                    Categoria = "Estatística",
                    SubCategoria = "Medidas de Tendência Central",
                    Expressao = "\u03BC = (1/n)·Σxᵢ",
                    Descricao = "A média aritmética é a soma dos valores dividida pelo número de elementos.",
                    Criador = "Karl Pearson (popularização)",
                    AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Pearson, K. The Grammar of Science, 1892.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Soma dos valores", Simbolo = "Σxᵢ", Unidade = "", ValorPadrao = 0 },
                        new Variavel { Nome = "Quantidade de elementos", Simbolo = "n", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs => inputs["Soma dos valores"] / inputs["Quantidade de elementos"],
                    VariavelResultado = "Média",
                    UnidadeResultado = ""
                },
                new Formula
                {
                    Id = "C502",
                    CodigoCompendio = "CS-002",
                    Nome = "Desvio Padrão Amostral",
                    Categoria = "Estatística",
                    SubCategoria = "Medidas de Dispersão",
                    Expressao = "s = sqrt[Σ(xᵢ-\u03BC)²/(n-1)]",
                    Descricao = "O desvio padrão amostral mede a dispersão dos dados em relação à média.",
                    Criador = "Francis Galton (conceito)",
                    AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Galton, F. Natural Inheritance, 1889.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Soma dos quadrados dos desvios", Simbolo = "Σ(xᵢ-μ)²", Unidade = "", ValorPadrao = 0 },
                        new Variavel { Nome = "Quantidade de elementos", Simbolo = "n", Unidade = "", ValorPadrao = 2 }
                    },
                    Calcular = inputs => System.Math.Sqrt(inputs["Soma dos quadrados dos desvios"] / (inputs["Quantidade de elementos"] - 1)),
                    VariavelResultado = "Desvio padrão",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
