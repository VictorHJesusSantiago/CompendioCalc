using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Química
    /// Fórmulas reais e bibliografadas da área de Química
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Quimica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C101",
                    CodigoCompendio = "CQ-001",
                    Nome = "Lei dos Gases Ideais",
                    Categoria = "Química",
                    SubCategoria = "Fisico-Química",
                    Expressao = "PV = nRT",
                    Descricao = "Relaciona pressão, volume, quantidade de matéria e temperatura de um gás ideal.",
                    Criador = "Emil Clapeyron",
                    AnoOrigin = "1834",
                    ReferenciaBibliografica = "Clapeyron, E. Mémoire sur la puissance motrice de la chaleur, 1834.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Pressão", Simbolo = "P", Unidade = "Pa", ValorPadrao = 101325 },
                        new Variavel { Nome = "Volume", Simbolo = "V", Unidade = "m³", ValorPadrao = 1 },
                        new Variavel { Nome = "Quantidade de matéria", Simbolo = "n", Unidade = "mol", ValorPadrao = 1 },
                        new Variavel { Nome = "Constante dos gases", Simbolo = "R", Unidade = "J/(mol·K)", ValorPadrao = 8.314 },
                        new Variavel { Nome = "Temperatura", Simbolo = "T", Unidade = "K", ValorPadrao = 273.15 }
                    },
                    Calcular = inputs => inputs["Pressão"] * inputs["Volume"] - inputs["Quantidade de matéria"] * inputs["Constante dos gases"] * inputs["Temperatura"],
                    VariavelResultado = "Resultado",
                    UnidadeResultado = "J"
                },
                new Formula
                {
                    Id = "C102",
                    CodigoCompendio = "CQ-002",
                    Nome = "Lei de Hess",
                    Categoria = "Química",
                    SubCategoria = "Termoquímica",
                    Expressao = "ΔH = ΣΔH_produtos - ΣΔH_reagentes",
                    Descricao = "A variação de entalpia de uma reação é igual à soma das entalpias dos produtos menos a dos reagentes.",
                    Criador = "Germain Hess",
                    AnoOrigin = "1840",
                    ReferenciaBibliografica = "Hess, G. S. Thermochemische Untersuchungen, 1840.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ΔH_produtos", Simbolo = "ΔH_produtos", Unidade = "kJ/mol", ValorPadrao = 0 },
                        new Variavel { Nome = "ΔH_reagentes", Simbolo = "ΔH_reagentes", Unidade = "kJ/mol", ValorPadrao = 0 }
                    },
                    Calcular = inputs => inputs["ΔH_produtos"] - inputs["ΔH_reagentes"],
                    VariavelResultado = "ΔH",
                    UnidadeResultado = "kJ/mol"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
