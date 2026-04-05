using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Genética Médica
    /// Fórmulas reais e bibliografadas da subárea Genética Médica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_GeneticaMedica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3901",
                    CodigoCompendio = "CGENMED-001",
                    Nome = "Probabilidade de Herança Autossômica Recessiva",
                    Categoria = "Genética Médica",
                    SubCategoria = "Genética de Populações",
                    Expressao = "P = q²",
                    Descricao = "Probabilidade de um indivíduo ser afetado por doença autossômica recessiva.",
                    Criador = "Conceito clássico",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Genética Médica.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Frequência do alelo recessivo", Simbolo = "q", Unidade = "", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs => inputs["Frequência do alelo recessivo"] * inputs["Frequência do alelo recessivo"],
                    VariavelResultado = "Probabilidade",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
