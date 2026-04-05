using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Epidemiologia
    /// Fórmulas reais e bibliografadas da subárea Epidemiologia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Epidemiologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3801",
                    CodigoCompendio = "CEPI-001",
                    Nome = "Taxa de Incidência",
                    Categoria = "Epidemiologia",
                    SubCategoria = "Indicadores Epidemiológicos",
                    Expressao = "TI = (Casos Novos / População Exposta) × 1000",
                    Descricao = "Número de casos novos de uma doença por mil habitantes expostos.",
                    Criador = "Indicador epidemiológico",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Epidemiologia, OMS.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Casos Novos", Simbolo = "Casos", Unidade = "", ValorPadrao = 50 },
                        new Variavel { Nome = "População Exposta", Simbolo = "População", Unidade = "", ValorPadrao = 10000 }
                    },
                    Calcular = inputs => (inputs["Casos Novos"] / inputs["População Exposta"]) * 1000,
                    VariavelResultado = "Taxa de Incidência",
                    UnidadeResultado = "por mil"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
