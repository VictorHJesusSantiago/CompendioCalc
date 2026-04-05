using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia de Produção
    /// Fórmulas reais e bibliografadas da subárea Engenharia de Produção
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaProducao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3101",
                    CodigoCompendio = "CEPROD-001",
                    Nome = "Eficiência de Produção",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Gestão da Produção",
                    Expressao = "Ef = (Produção Real / Produção Planejada) × 100",
                    Descricao = "Percentual de eficiência de um processo produtivo.",
                    Criador = "Prática industrial",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Normas de gestão da produção.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Produção Real", Simbolo = "PR", Unidade = "unidades", ValorPadrao = 900 },
                        new Variavel { Nome = "Produção Planejada", Simbolo = "PP", Unidade = "unidades", ValorPadrao = 1000 }
                    },
                    Calcular = inputs => (inputs["Produção Real"] / inputs["Produção Planejada"]) * 100,
                    VariavelResultado = "Eficiência",
                    UnidadeResultado = "%"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
