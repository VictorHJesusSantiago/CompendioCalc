using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Ciência dos Materiais
    /// Fórmulas reais e bibliografadas da área multidisciplinar Ciência dos Materiais
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_CienciaMateriais()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5501",
                    CodigoCompendio = "CCMAT-001",
                    Nome = "Fração Molar",
                    Categoria = "Ciência dos Materiais",
                    SubCategoria = "Misturas",
                    Expressao = "xᵢ = nᵢ / n_total",
                    Descricao = "A fração molar de um componente em uma mistura.",
                    Criador = "Prática em materiais",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Ciência dos Materiais.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Número de mols do componente", Simbolo = "nᵢ", Unidade = "mol", ValorPadrao = 1 },
                        new Variavel { Nome = "Número total de mols", Simbolo = "n_total", Unidade = "mol", ValorPadrao = 10 }
                    },
                    Calcular = inputs => inputs["Número de mols do componente"] / inputs["Número total de mols"],
                    VariavelResultado = "Fração Molar",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
