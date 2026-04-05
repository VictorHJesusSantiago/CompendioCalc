using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Paleontologia
    /// Fórmulas reais e bibliografadas da subárea Paleontologia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Paleontologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4201",
                    CodigoCompendio = "CPAL-001",
                    Nome = "Idade por Decaimento Radioativo",
                    Categoria = "Paleontologia",
                    SubCategoria = "Datação",
                    Expressao = "t = (1/λ)·ln(N₀/N)",
                    Descricao = "Cálculo da idade de fósseis por decaimento radioativo.",
                    Criador = "Willard Libby",
                    AnoOrigin = "1949",
                    ReferenciaBibliografica = "Libby, W. F. Radiocarbon Dating, 1949.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Constante de decaimento", Simbolo = "λ", Unidade = "1/ano", ValorPadrao = 1.21e-4 },
                        new Variavel { Nome = "Quantidade inicial", Simbolo = "N₀", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Quantidade atual", Simbolo = "N", Unidade = "", ValorPadrao = 50 }
                    },
                    Calcular = inputs => (1 / inputs["Constante de decaimento"]) * System.Math.Log(inputs["Quantidade inicial"] / inputs["Quantidade atual"]),
                    VariavelResultado = "Idade",
                    UnidadeResultado = "anos"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
