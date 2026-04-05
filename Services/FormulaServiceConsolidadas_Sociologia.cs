using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Sociologia
    /// Fórmulas reais e bibliografadas da área de Sociologia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Sociologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1101",
                    CodigoCompendio = "CSOC-001",
                    Nome = "Índice de Gini",
                    Categoria = "Sociologia",
                    SubCategoria = "Desigualdade Social",
                    Expressao = "G = A / (A + B)",
                    Descricao = "Mede a desigualdade de renda em uma população.",
                    Criador = "Corrado Gini",
                    AnoOrigin = "1912",
                    ReferenciaBibliografica = "Gini, C. Variabilità e mutabilità, 1912.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Área A", Simbolo = "A", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Área B", Simbolo = "B", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs => inputs["Área A"] / (inputs["Área A"] + inputs["Área B"]),
                    VariavelResultado = "Índice de Gini",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
