using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Neurociências
    /// Fórmulas reais e bibliografadas da subárea Neurociências
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Neurociencias()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4001",
                    CodigoCompendio = "CNEURO-001",
                    Nome = "Potencial de Membrana (Equação de Nernst)",
                    Categoria = "Neurociências",
                    SubCategoria = "Neurofisiologia",
                    Expressao = "E = (RT/zF)·ln([ion]out/[ion]in)",
                    Descricao = "Calcula o potencial de equilíbrio de um íon através da membrana.",
                    Criador = "Walther Nernst",
                    AnoOrigin = "1888",
                    ReferenciaBibliografica = "Nernst, W. Z. Phys. Chem., 1888.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Constante dos gases", Simbolo = "R", Unidade = "J/(mol·K)", ValorPadrao = 8.314 },
                        new Variavel { Nome = "Temperatura", Simbolo = "T", Unidade = "K", ValorPadrao = 310 },
                        new Variavel { Nome = "Carga do íon", Simbolo = "z", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Constante de Faraday", Simbolo = "F", Unidade = "C/mol", ValorPadrao = 96485 },
                        new Variavel { Nome = "Concentração externa", Simbolo = "[ion]out", Unidade = "mol/L", ValorPadrao = 140 },
                        new Variavel { Nome = "Concentração interna", Simbolo = "[ion]in", Unidade = "mol/L", ValorPadrao = 10 }
                    },
                    Calcular = inputs => (inputs["Constante dos gases"] * inputs["Temperatura"] / (inputs["Carga do íon"] * inputs["Constante de Faraday"])) * System.Math.Log(inputs["Concentração externa"] / inputs["Concentração interna"]),
                    VariavelResultado = "Potencial de Membrana",
                    UnidadeResultado = "V"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
