using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia
    /// Fórmulas reais e bibliografadas da área de Engenharia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Engenharia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C401",
                    CodigoCompendio = "CE-001",
                    Nome = "Tensão Normal (Lei de Hooke)",
                    Categoria = "Engenharia",
                    SubCategoria = "Mecânica dos Materiais",
                    Expressao = "σ = E·ε",
                    Descricao = "A tensão normal é proporcional à deformação, constante de proporcionalidade é o módulo de Young.",
                    Criador = "Robert Hooke",
                    AnoOrigin = "1678",
                    ReferenciaBibliografica = "Hooke, R. Lectures de Potentia Restitutiva, 1678.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Módulo de Young", Simbolo = "E", Unidade = "Pa", ValorPadrao = 2e11 },
                        new Variavel { Nome = "Deformação", Simbolo = "ε", Unidade = "", ValorPadrao = 0.001 }
                    },
                    Calcular = inputs => inputs["Módulo de Young"] * inputs["Deformação"],
                    VariavelResultado = "Tensão",
                    UnidadeResultado = "Pa"
                },
                new Formula
                {
                    Id = "C402",
                    CodigoCompendio = "CE-002",
                    Nome = "Vazão em Tubulação (Equação de Continuidade)",
                    Categoria = "Engenharia",
                    SubCategoria = "Hidráulica",
                    Expressao = "Q = v·A",
                    Descricao = "A vazão volumétrica é o produto da velocidade média pela área da seção transversal.",
                    Criador = "Princípio da continuidade",
                    AnoOrigin = "séc. XVIII",
                    ReferenciaBibliografica = "Princípios clássicos de hidráulica.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Velocidade média", Simbolo = "v", Unidade = "m/s", ValorPadrao = 1 },
                        new Variavel { Nome = "Área", Simbolo = "A", Unidade = "m²", ValorPadrao = 1 }
                    },
                    Calcular = inputs => inputs["Velocidade média"] * inputs["Área"],
                    VariavelResultado = "Vazão",
                    UnidadeResultado = "m³/s"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
