using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Computação
    /// Fórmulas reais e bibliografadas da área de Computação
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Computacao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C601",
                    CodigoCompendio = "CC-001",
                    Nome = "Lei de Amdahl",
                    Categoria = "Computação",
                    SubCategoria = "Arquitetura de Computadores",
                    Expressao = "S = 1 / [(1 - p) + (p / n)]",
                    Descricao = "A aceleração máxima de um sistema paralelo é limitada pela fração sequencial do código.",
                    Criador = "Gene Amdahl",
                    AnoOrigin = "1967",
                    ReferenciaBibliografica = "Amdahl, G. M. Validity of the Single Processor Approach to Achieving Large-Scale Computing Capabilities, 1967.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Fração paralelizável", Simbolo = "p", Unidade = "", ValorPadrao = 0.9 },
                        new Variavel { Nome = "Número de processadores", Simbolo = "n", Unidade = "", ValorPadrao = 4 }
                    },
                    Calcular = inputs => 1 / ((1 - inputs["Fração paralelizável"]) + (inputs["Fração paralelizável"] / inputs["Número de processadores"])),
                    VariavelResultado = "Aceleração",
                    UnidadeResultado = ""
                },
                new Formula
                {
                    Id = "C602",
                    CodigoCompendio = "CC-002",
                    Nome = "Complexidade de Busca Binária",
                    Categoria = "Computação",
                    SubCategoria = "Algoritmos",
                    Expressao = "O(log₂ n)",
                    Descricao = "A busca binária em um vetor ordenado tem complexidade logarítmica.",
                    Criador = "John Mauchly (conceito)",
                    AnoOrigin = "1946",
                    ReferenciaBibliografica = "Knuth, D. E. The Art of Computer Programming, 1968.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tamanho do vetor", Simbolo = "n", Unidade = "", ValorPadrao = 1024 }
                    },
                    Calcular = inputs => System.Math.Log(inputs["Tamanho do vetor"], 2),
                    VariavelResultado = "Complexidade",
                    UnidadeResultado = "passos"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
