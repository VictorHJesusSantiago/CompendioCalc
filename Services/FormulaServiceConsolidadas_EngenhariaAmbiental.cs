using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia Ambiental
    /// Fórmulas reais e bibliografadas da subárea Engenharia Ambiental
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaAmbiental()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3201",
                    CodigoCompendio = "CEAMB-001",
                    Nome = "Carga Poluidora",
                    Categoria = "Engenharia Ambiental",
                    SubCategoria = "Gestão Ambiental",
                    Expressao = "C = Q × C₀",
                    Descricao = "A carga poluidora é o produto da vazão pelo teor de poluente.",
                    Criador = "Prática ambiental",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Normas ambientais.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Vazão", Simbolo = "Q", Unidade = "L/s", ValorPadrao = 100 },
                        new Variavel { Nome = "Concentração de poluente", Simbolo = "C₀", Unidade = "mg/L", ValorPadrao = 50 }
                    },
                    Calcular = inputs => inputs["Vazão"] * inputs["Concentração de poluente"],
                    VariavelResultado = "Carga Poluidora",
                    UnidadeResultado = "mg/s"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
