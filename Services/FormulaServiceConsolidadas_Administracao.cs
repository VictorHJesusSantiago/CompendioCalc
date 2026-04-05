using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Administração
    /// Fórmulas reais e bibliografadas da área de Administração
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Administracao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1501",
                    CodigoCompendio = "CADM-001",
                    Nome = "Ponto de Equilíbrio Contábil",
                    Categoria = "Administração",
                    SubCategoria = "Gestão Financeira",
                    Expressao = "PE = Custos Fixos / (Preço de Venda - Custo Variável Unitário)",
                    Descricao = "Determina o volume de vendas necessário para cobrir todos os custos.",
                    Criador = "Prática administrativa",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Gitman, L. J. Princípios de Administração Financeira.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Custos Fixos", Simbolo = "CF", Unidade = "moeda", ValorPadrao = 10000 },
                        new Variavel { Nome = "Preço de Venda", Simbolo = "PV", Unidade = "moeda", ValorPadrao = 100 },
                        new Variavel { Nome = "Custo Variável Unitário", Simbolo = "CVU", Unidade = "moeda", ValorPadrao = 60 }
                    },
                    Calcular = inputs => inputs["Custos Fixos"] / (inputs["Preço de Venda"] - inputs["Custo Variável Unitário"]),
                    VariavelResultado = "Ponto de Equilíbrio",
                    UnidadeResultado = "unidades"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
