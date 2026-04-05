using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Astronomia
    /// Fórmulas reais e bibliografadas da área de Astronomia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Astronomia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1901",
                    CodigoCompendio = "CAST-001",
                    Nome = "Lei da Gravitação Universal",
                    Categoria = "Astronomia",
                    SubCategoria = "Gravitação",
                    Expressao = "F = G·(m₁·m₂)/r²",
                    Descricao = "A força gravitacional entre dois corpos é proporcional ao produto de suas massas e inversamente proporcional ao quadrado da distância entre eles.",
                    Criador = "Isaac Newton",
                    AnoOrigin = "1687",
                    ReferenciaBibliografica = "Newton, I. Philosophiæ Naturalis Principia Mathematica, 1687.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Massa 1", Simbolo = "m₁", Unidade = "kg", ValorPadrao = 1 },
                        new Variavel { Nome = "Massa 2", Simbolo = "m₂", Unidade = "kg", ValorPadrao = 1 },
                        new Variavel { Nome = "Distância", Simbolo = "r", Unidade = "m", ValorPadrao = 1 },
                        new Variavel { Nome = "Constante G", Simbolo = "G", Unidade = "N·m²/kg²", ValorPadrao = 6.67430e-11 }
                    },
                    Calcular = inputs => inputs["Constante G"] * inputs["Massa 1"] * inputs["Massa 2"] / (inputs["Distância"] * inputs["Distância"]),
                    VariavelResultado = "Força",
                    UnidadeResultado = "N"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
