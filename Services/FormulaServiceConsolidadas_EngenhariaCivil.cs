using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia Civil
    /// Fórmulas reais e bibliografadas da área de Engenharia Civil
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaCivil()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2201",
                    CodigoCompendio = "CECIV-001",
                    Nome = "Tensão de Compressão em Pilar",
                    Categoria = "Engenharia Civil",
                    SubCategoria = "Estruturas",
                    Expressao = "σ = N / A",
                    Descricao = "A tensão de compressão é a força normal dividida pela área da seção transversal.",
                    Criador = "Prática de engenharia",
                    AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Normas técnicas de estruturas.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Força Normal", Simbolo = "N", Unidade = "kN", ValorPadrao = 100 },
                        new Variavel { Nome = "Área", Simbolo = "A", Unidade = "cm²", ValorPadrao = 200 }
                    },
                    Calcular = inputs => inputs["Força Normal"] / inputs["Área"],
                    VariavelResultado = "Tensão",
                    UnidadeResultado = "kN/cm²"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
