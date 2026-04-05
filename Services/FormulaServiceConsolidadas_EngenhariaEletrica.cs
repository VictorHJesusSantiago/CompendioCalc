using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia Elétrica
    /// Fórmulas reais e bibliografadas da área de Engenharia Elétrica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaEletrica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2301",
                    CodigoCompendio = "CEELE-001",
                    Nome = "Lei de Ohm",
                    Categoria = "Engenharia Elétrica",
                    SubCategoria = "Circuitos Elétricos",
                    Expressao = "V = R·I",
                    Descricao = "A tensão em um resistor é igual ao produto da resistência pela corrente.",
                    Criador = "Georg Ohm",
                    AnoOrigin = "1827",
                    ReferenciaBibliografica = "Ohm, G. S. Die galvanische Kette, mathematisch bearbeitet, 1827.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Resistência", Simbolo = "R", Unidade = "Ω", ValorPadrao = 10 },
                        new Variavel { Nome = "Corrente", Simbolo = "I", Unidade = "A", ValorPadrao = 2 }
                    },
                    Calcular = inputs => inputs["Resistência"] * inputs["Corrente"],
                    VariavelResultado = "Tensão",
                    UnidadeResultado = "V"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
