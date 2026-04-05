using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Química Analítica
    /// Fórmulas reais e bibliografadas da subárea Química Analítica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_QuimicaAnalitica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4501",
                    CodigoCompendio = "CQUIMAN-001",
                    Nome = "Concentração Molar",
                    Categoria = "Química Analítica",
                    SubCategoria = "Soluções",
                    Expressao = "M = n/V",
                    Descricao = "A concentração molar é a razão entre o número de mols e o volume da solução.",
                    Criador = "Wilhelm Ostwald",
                    AnoOrigin = "1894",
                    ReferenciaBibliografica = "Ostwald, W. Lehrbuch der allgemeinen Chemie, 1894.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Número de mols", Simbolo = "n", Unidade = "mol", ValorPadrao = 1 },
                        new Variavel { Nome = "Volume da solução", Simbolo = "V", Unidade = "L", ValorPadrao = 1 }
                    },
                    Calcular = inputs => inputs["Número de mols"] / inputs["Volume da solução"],
                    VariavelResultado = "Concentração molar",
                    UnidadeResultado = "mol/L"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
