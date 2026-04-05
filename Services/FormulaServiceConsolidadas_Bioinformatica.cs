using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Bioinformática
    /// Fórmulas reais e bibliografadas da subárea Bioinformática
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Bioinformatica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3501",
                    CodigoCompendio = "CBIOINF-001",
                    Nome = "Identidade de Sequências",
                    Categoria = "Bioinformática",
                    SubCategoria = "Comparação de Sequências",
                    Expressao = "I = (M / L) × 100",
                    Descricao = "Percentual de identidade entre duas sequências biológicas.",
                    Criador = "Prática em bioinformática",
                    AnoOrigin = "séc. XXI",
                    ReferenciaBibliografica = "Altschul, S. F. et al. J. Mol. Biol., 1990.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Número de matches", Simbolo = "M", Unidade = "", ValorPadrao = 80 },
                        new Variavel { Nome = "Comprimento da sequência", Simbolo = "L", Unidade = "", ValorPadrao = 100 }
                    },
                    Calcular = inputs => (inputs["Número de matches"] / inputs["Comprimento da sequência"]) * 100,
                    VariavelResultado = "Identidade",
                    UnidadeResultado = "%"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
