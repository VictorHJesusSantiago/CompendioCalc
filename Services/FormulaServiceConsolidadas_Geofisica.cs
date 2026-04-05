using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Geofísica
    /// Fórmulas reais e bibliografadas da subárea Geofísica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Geofisica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4401",
                    CodigoCompendio = "CGEOF-001",
                    Nome = "Aceleração da Gravidade",
                    Categoria = "Geofísica",
                    SubCategoria = "Gravimetria",
                    Expressao = "g = G·(M/R²)",
                    Descricao = "A aceleração da gravidade na superfície de um corpo celeste.",
                    Criador = "Isaac Newton",
                    AnoOrigin = "1687",
                    ReferenciaBibliografica = "Newton, I. Philosophiæ Naturalis Principia Mathematica, 1687.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Constante gravitacional", Simbolo = "G", Unidade = "N·m²/kg²", ValorPadrao = 6.67430e-11 },
                        new Variavel { Nome = "Massa do corpo", Simbolo = "M", Unidade = "kg", ValorPadrao = 5.972e24 },
                        new Variavel { Nome = "Raio", Simbolo = "R", Unidade = "m", ValorPadrao = 6.371e6 }
                    },
                    Calcular = inputs => inputs["Constante gravitacional"] * inputs["Massa do corpo"] / (inputs["Raio"] * inputs["Raio"]),
                    VariavelResultado = "Aceleração da gravidade",
                    UnidadeResultado = "m/s²"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
