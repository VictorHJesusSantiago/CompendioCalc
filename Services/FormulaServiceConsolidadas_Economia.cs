using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Economia
    /// Fórmulas reais e bibliografadas da área de Economia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Economia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C701",
                    CodigoCompendio = "CECO-001",
                    Nome = "Elasticidade-preço da demanda",
                    Categoria = "Economia",
                    SubCategoria = "Microeconomia",
                    Expressao = "E = (ΔQ/Q) / (ΔP/P)",
                    Descricao = "Mede a sensibilidade da quantidade demandada em relação ao preço.",
                    Criador = "Alfred Marshall",
                    AnoOrigin = "1890",
                    ReferenciaBibliografica = "Marshall, A. Principles of Economics, 1890.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Variação da quantidade", Simbolo = "ΔQ", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Quantidade inicial", Simbolo = "Q", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Variação do preço", Simbolo = "ΔP", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Preço inicial", Simbolo = "P", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs => (inputs["Variação da quantidade"] / inputs["Quantidade inicial"]) / (inputs["Variação do preço"] / inputs["Preço inicial"]),
                    VariavelResultado = "Elasticidade",
                    UnidadeResultado = ""
                },
                new Formula
                {
                    Id = "C702",
                    CodigoCompendio = "CECO-002",
                    Nome = "PIB nominal",
                    Categoria = "Economia",
                    SubCategoria = "Macroeconomia",
                    Expressao = "PIB = Σpᵢ·qᵢ",
                    Descricao = "O Produto Interno Bruto nominal é a soma dos valores de mercado de todos os bens finais produzidos.",
                    Criador = "Simon Kuznets",
                    AnoOrigin = "1934",
                    ReferenciaBibliografica = "Kuznets, S. National Income, 1929–32, 1934.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Soma dos valores de mercado", Simbolo = "Σpᵢ·qᵢ", Unidade = "moeda", ValorPadrao = 1000000 }
                    },
                    Calcular = inputs => inputs["Soma dos valores de mercado"],
                    VariavelResultado = "PIB",
                    UnidadeResultado = "moeda"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
