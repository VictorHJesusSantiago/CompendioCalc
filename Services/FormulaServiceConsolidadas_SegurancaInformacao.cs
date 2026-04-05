using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Segurança da Informação
    /// Fórmulas reais e bibliografadas da subárea Segurança da Informação
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_SegurancaInformacao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5001",
                    CodigoCompendio = "CSEG-001",
                    Nome = "Entropia de Shannon",
                    Categoria = "Segurança da Informação",
                    SubCategoria = "Teoria da Informação",
                    Expressao = "H = -Σpᵢ·log₂(pᵢ)",
                    Descricao = "Mede a incerteza ou aleatoriedade de uma fonte de informação.",
                    Criador = "Claude Shannon",
                    AnoOrigin = "1948",
                    ReferenciaBibliografica = "Shannon, C. E. Bell System Technical Journal, 1948.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Probabilidade pᵢ", Simbolo = "pᵢ", Unidade = "", ValorPadrao = 0.5 }
                    },
                    Calcular = inputs => -inputs["Probabilidade pᵢ"] * System.Math.Log(inputs["Probabilidade pᵢ"], 2),
                    VariavelResultado = "Entropia",
                    UnidadeResultado = "bits"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
