using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Biotecnologia
    /// Fórmulas reais e bibliografadas da subárea Biotecnologia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Biotecnologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3601",
                    CodigoCompendio = "CBIOTEC-001",
                    Nome = "Rendimento de Fermentação",
                    Categoria = "Biotecnologia",
                    SubCategoria = "Processos Fermentativos",
                    Expressao = "Y = (Produto / Substrato) × 100",
                    Descricao = "Percentual de rendimento de um processo fermentativo.",
                    Criador = "Prática em biotecnologia",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Biotecnologia Industrial.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Produto", Simbolo = "Produto", Unidade = "g", ValorPadrao = 50 },
                        new Variavel { Nome = "Substrato", Simbolo = "Substrato", Unidade = "g", ValorPadrao = 100 }
                    },
                    Calcular = inputs => (inputs["Produto"] / inputs["Substrato"]) * 100,
                    VariavelResultado = "Rendimento",
                    UnidadeResultado = "%"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
