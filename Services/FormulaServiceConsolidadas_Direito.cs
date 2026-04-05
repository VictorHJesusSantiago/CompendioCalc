using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Direito
    /// Fórmulas reais e bibliografadas da área de Direito
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Direito()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1401",
                    CodigoCompendio = "CDIR-001",
                    Nome = "Cálculo de Correção Monetária",
                    Categoria = "Direito",
                    SubCategoria = "Direito Econômico",
                    Expressao = "Valor Corrigido = Valor Inicial × (Índice Final / Índice Inicial)",
                    Descricao = "Usado para atualizar valores em processos judiciais.",
                    Criador = "Prática jurídica",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Cálculos Judiciais, TRF.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Valor Inicial", Simbolo = "VI", Unidade = "moeda", ValorPadrao = 1000 },
                        new Variavel { Nome = "Índice Final", Simbolo = "IF", Unidade = "", ValorPadrao = 1.2 },
                        new Variavel { Nome = "Índice Inicial", Simbolo = "II", Unidade = "", ValorPadrao = 1.0 }
                    },
                    Calcular = inputs => inputs["Valor Inicial"] * (inputs["Índice Final"] / inputs["Índice Inicial"]),
                    VariavelResultado = "Valor Corrigido",
                    UnidadeResultado = "moeda"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
