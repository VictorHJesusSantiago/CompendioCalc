using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Nutrição
    /// Fórmulas reais e bibliografadas da área de Nutrição
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Nutricao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2601",
                    CodigoCompendio = "CNUT-001",
                    Nome = "Índice de Massa Corporal (IMC)",
                    Categoria = "Nutrição",
                    SubCategoria = "Avaliação Nutricional",
                    Expressao = "IMC = Peso / Altura²",
                    Descricao = "O IMC é utilizado para avaliar o estado nutricional.",
                    Criador = "Adolphe Quetelet",
                    AnoOrigin = "1832",
                    ReferenciaBibliografica = "Quetelet, A. A Treatise on Man, 1832.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Peso", Simbolo = "Peso", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Altura", Simbolo = "Altura", Unidade = "m", ValorPadrao = 1.75 }
                    },
                    Calcular = inputs => inputs["Peso"] / (inputs["Altura"] * inputs["Altura"]),
                    VariavelResultado = "IMC",
                    UnidadeResultado = "kg/m²"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
