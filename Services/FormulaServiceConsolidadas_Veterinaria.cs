using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Veterinária
    /// Fórmulas reais e bibliografadas da área de Veterinária
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Veterinaria()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2701",
                    CodigoCompendio = "CVET-001",
                    Nome = "Dose de Medicamento para Animais",
                    Categoria = "Veterinária",
                    SubCategoria = "Farmacologia Animal",
                    Expressao = "Dose = Peso × Dose/kg",
                    Descricao = "Cálculo da dose de medicamento para animais baseada no peso.",
                    Criador = "Prática veterinária",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Farmacologia Veterinária.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Peso", Simbolo = "Peso", Unidade = "kg", ValorPadrao = 20 },
                        new Variavel { Nome = "Dose/kg", Simbolo = "Dose/kg", Unidade = "mg/kg", ValorPadrao = 5 }
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
