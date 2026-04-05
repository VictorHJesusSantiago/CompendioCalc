using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Visão Computacional
    /// Fórmulas reais e bibliografadas da subárea Visão Computacional
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_VisaoComputacional()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4901",
                    CodigoCompendio = "CVIS-001",
                    Nome = "Transformada de Hough para Retas",
                    Categoria = "Visão Computacional",
                    SubCategoria = "Processamento de Imagens",
                    Expressao = "ρ = x·cosθ + y·sinθ",
                    Descricao = "Equação fundamental para detecção de retas em imagens.",
                    Criador = "Paul Hough",
                    AnoOrigin = "1962",
                    ReferenciaBibliografica = "Hough, P. V. C. US Patent 3069654, 1962.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x", Simbolo = "x", Unidade = "px", ValorPadrao = 0 },
                        new Variavel { Nome = "y", Simbolo = "y", Unidade = "px", ValorPadrao = 0 },
                        new Variavel { Nome = "θ", Simbolo = "θ", Unidade = "graus", ValorPadrao = 0 }
                    },
                    Calcular = inputs => inputs["x"] * System.Math.Cos(inputs["θ"]) + inputs["y"] * System.Math.Sin(inputs["θ"]),
                    VariavelResultado = "ρ",
                    UnidadeResultado = "px"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
