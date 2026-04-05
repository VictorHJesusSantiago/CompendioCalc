using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Antropologia
    /// Fórmulas reais e bibliografadas da área de Antropologia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Antropologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2001",
                    CodigoCompendio = "CANT-001",
                    Nome = "Índice Cefálico",
                    Categoria = "Antropologia",
                    SubCategoria = "Antropometria",
                    Expressao = "IC = (Largura da Cabeça / Comprimento da Cabeça) × 100",
                    Descricao = "Usado para classificar tipos de crânio em estudos antropológicos.",
                    Criador = "Anders Retzius",
                    AnoOrigin = "1842",
                    ReferenciaBibliografica = "Retzius, A. Om formen af nordiska folkets cranier, 1842.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Largura da Cabeça", Simbolo = "L", Unidade = "mm", ValorPadrao = 150 },
                        new Variavel { Nome = "Comprimento da Cabeça", Simbolo = "C", Unidade = "mm", ValorPadrao = 200 }
                    },
                    Calcular = inputs => (inputs["Largura da Cabeça"] / inputs["Comprimento da Cabeça"]) * 100,
                    VariavelResultado = "Índice Cefálico",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
