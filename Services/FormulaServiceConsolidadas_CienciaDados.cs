using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Ciência de Dados
    /// Fórmulas reais e bibliografadas da subárea Ciência de Dados
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_CienciaDados()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4701",
                    CodigoCompendio = "CCID-001",
                    Nome = "Coeficiente de Correlação de Pearson",
                    Categoria = "Ciência de Dados",
                    SubCategoria = "Estatística",
                    Expressao = "r = Σ[(xᵢ-μₓ)(yᵢ-μᵧ)] / [n·σₓ·σᵧ]",
                    Descricao = "Mede a correlação linear entre duas variáveis.",
                    Criador = "Karl Pearson",
                    AnoOrigin = "1895",
                    ReferenciaBibliografica = "Pearson, K. Proceedings of the Royal Society, 1895.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Soma dos produtos dos desvios", Simbolo = "Σ[(xᵢ-μₓ)(yᵢ-μᵧ)]", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "n", Simbolo = "n", Unidade = "", ValorPadrao = 5 },
                        new Variavel { Nome = "Desvio padrão x", Simbolo = "σₓ", Unidade = "", ValorPadrao = 2 },
                        new Variavel { Nome = "Desvio padrão y", Simbolo = "σᵧ", Unidade = "", ValorPadrao = 2 }
                    },
                    Calcular = inputs => inputs["Soma dos produtos dos desvios"] / (inputs["n"] * inputs["Desvio padrão x"] * inputs["Desvio padrão y"]),
                    VariavelResultado = "Correlação",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
