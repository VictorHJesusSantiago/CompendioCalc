using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Astrofísica
    /// Fórmulas reais e bibliografadas da subárea Astrofísica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Astrofisica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4101",
                    CodigoCompendio = "CASTRO-001",
                    Nome = "Lei de Hubble",
                    Categoria = "Astrofísica",
                    SubCategoria = "Cosmologia",
                    Expressao = "v = H₀·d",
                    Descricao = "A velocidade de afastamento de uma galáxia é proporcional à sua distância.",
                    Criador = "Edwin Hubble",
                    AnoOrigin = "1929",
                    ReferenciaBibliografica = "Hubble, E. PNAS, 1929.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Constante de Hubble", Simbolo = "H₀", Unidade = "km/s/Mpc", ValorPadrao = 70 },
                        new Variavel { Nome = "Distância", Simbolo = "d", Unidade = "Mpc", ValorPadrao = 1 }
                    },
                    Calcular = inputs => inputs["Constante de Hubble"] * inputs["Distância"],
                    VariavelResultado = "Velocidade",
                    UnidadeResultado = "km/s"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
