using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Medicina
    /// Fórmulas reais e bibliografadas da área de Medicina
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Medicina()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C801",
                    CodigoCompendio = "CMED-001",
                    Nome = "Índice de Massa Corporal (IMC)",
                    Categoria = "Medicina",
                    SubCategoria = "Clínica Geral",
                    Expressao = "IMC = peso / altura²",
                    Descricao = "O IMC é utilizado para avaliar se o peso está adequado à altura.",
                    Criador = "Adolphe Quetelet",
                    AnoOrigin = "1832",
                    ReferenciaBibliografica = "Quetelet, A. A Treatise on Man, 1832.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Peso", Simbolo = "peso", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Altura", Simbolo = "altura", Unidade = "m", ValorPadrao = 1.75 }
                    },
                    Calcular = inputs => inputs["Peso"] / (inputs["Altura"] * inputs["Altura"]),
                    VariavelResultado = "IMC",
                    UnidadeResultado = "kg/m²"
                },
                new Formula
                {
                    Id = "C802",
                    CodigoCompendio = "CMED-002",
                    Nome = "Taxa de Filtração Glomerular (TFG) - Cockcroft-Gault",
                    Categoria = "Medicina",
                    SubCategoria = "Nefrologia",
                    Expressao = "TFG = [(140 - idade) × peso] / (72 × creatinina)",
                    Descricao = "Estimativa da função renal em adultos.",
                    Criador = "Cockcroft & Gault",
                    AnoOrigin = "1976",
                    ReferenciaBibliografica = "Cockcroft, D. W.; Gault, M. H. Nephron, 1976.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Idade", Simbolo = "idade", Unidade = "anos", ValorPadrao = 40 },
                        new Variavel { Nome = "Peso", Simbolo = "peso", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Creatinina", Simbolo = "creatinina", Unidade = "mg/dL", ValorPadrao = 1 }
                    },
                    Calcular = inputs => ((140 - inputs["Idade"]) * inputs["Peso"]) / (72 * inputs["Creatinina"]),
                    VariavelResultado = "TFG",
                    UnidadeResultado = "mL/min"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
