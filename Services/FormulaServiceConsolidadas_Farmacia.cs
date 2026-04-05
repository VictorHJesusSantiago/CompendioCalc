using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Farmácia
    /// Fórmulas reais e bibliografadas da área de Farmácia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Farmacia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2501",
                    CodigoCompendio = "CFAR-001",
                    Nome = "Dose Diária de Medicamento",
                    Categoria = "Farmácia",
                    SubCategoria = "Farmacologia",
                    Expressao = "Dose = (Peso × Dose/kg)",
                    Descricao = "Cálculo da dose diária de medicamento baseada no peso corporal.",
                    Criador = "Prática clínica",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Farmacologia Clínica.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Peso", Simbolo = "Peso", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Dose/kg", Simbolo = "Dose/kg", Unidade = "mg/kg", ValorPadrao = 2 }
                    },
                    Calcular = inputs => inputs["Peso"] * inputs["Dose/kg"],
                    VariavelResultado = "Dose",
                    UnidadeResultado = "mg"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
