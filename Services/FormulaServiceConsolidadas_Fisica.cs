using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Física
    /// Fórmulas reais e bibliografadas da área de Física
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Fisica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C001",
                    CodigoCompendio = "CF-001",
                    Nome = "Segunda Lei de Newton",
                    Categoria = "Física",
                    SubCategoria = "Mecânica",
                    Expressao = "F = m·a",
                    Descricao = "A força resultante sobre um corpo é igual ao produto da massa pela aceleração.",
                    Criador = "Isaac Newton",
                    AnoOrigin = "1687",
                    ReferenciaBibliografica = "Newton, I. Philosophiæ Naturalis Principia Mathematica, 1687.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Massa", Simbolo = "m", Unidade = "kg", ValorPadrao = 1 },
                        new Variavel { Nome = "Aceleração", Simbolo = "a", Unidade = "m/s²", ValorPadrao = 1 }
                    },
                    Calcular = inputs => inputs["Massa"] * inputs["Aceleração"],
                    VariavelResultado = "Força",
                    UnidadeResultado = "N"
                },
                new Formula
                {
                    Id = "C002",
                    CodigoCompendio = "CF-002",
                    Nome = "Lei de Coulomb",
                    Categoria = "Física",
                    SubCategoria = "Eletromagnetismo",
                    Expressao = "F = k·|q1·q2|/r²",
                    Descricao = "A força entre duas cargas puntiformes é proporcional ao produto das cargas e inversamente proporcional ao quadrado da distância entre elas.",
                    Criador = "Charles Coulomb",
                    AnoOrigin = "1785",
                    ReferenciaBibliografica = "Coulomb, C. H. Mémoires de l'Académie Royale des Sciences, 1785.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Carga 1", Simbolo = "q1", Unidade = "C", ValorPadrao = 1 },
                        new Variavel { Nome = "Carga 2", Simbolo = "q2", Unidade = "C", ValorPadrao = 1 },
                        new Variavel { Nome = "Distância", Simbolo = "r", Unidade = "m", ValorPadrao = 1 },
                        new Variavel { Nome = "Constante", Simbolo = "k", Unidade = "N·m²/C²", ValorPadrao = 8.9875517923e9 }
                    },
                    Calcular = inputs => inputs["Constante"] * System.Math.Abs(inputs["Carga 1"] * inputs["Carga 2"]) / (inputs["Distância"] * inputs["Distância"]),
                    VariavelResultado = "Força",
                    UnidadeResultado = "N"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
