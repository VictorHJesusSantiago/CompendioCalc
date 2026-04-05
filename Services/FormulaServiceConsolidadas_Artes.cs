using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Artes
    /// Fórmulas reais e bibliografadas da área de Artes
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Artes()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1301",
                    CodigoCompendio = "CART-001",
                    Nome = "Proporção Áurea",
                    Categoria = "Artes",
                    SubCategoria = "Estética",
                    Expressao = "φ = (1 + sqrt(5)) / 2",
                    Descricao = "A proporção áurea é considerada esteticamente agradável em artes visuais.",
                    Criador = "Euclides (Elementos)",
                    AnoOrigin = "c. 300 a.C.",
                    ReferenciaBibliografica = "Livio, M. The Golden Ratio, 2002.",
                    Variaveis = new List<Variavel>(),
                    Calcular = inputs => (1 + System.Math.Sqrt(5)) / 2,
                    VariavelResultado = "φ",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
