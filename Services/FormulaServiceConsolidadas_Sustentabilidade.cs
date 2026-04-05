using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Sustentabilidade
    /// Fórmulas reais e bibliografadas da área multidisciplinar Sustentabilidade
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Sustentabilidade()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5101",
                    CodigoCompendio = "CSUST-001",
                    Nome = "Índice de Sustentabilidade Ambiental (ISA)",
                    Categoria = "Sustentabilidade",
                    SubCategoria = "Indicadores Ambientais",
                    Expressao = "ISA = Σ(Peso_i × Indicador_i)",
                    Descricao = "Índice composto ponderado para avaliação de sustentabilidade.",
                    Criador = "Prática multidisciplinar",
                    AnoOrigin = "séc. XXI",
                    ReferenciaBibliografica = "Manual de Indicadores de Sustentabilidade.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Peso do indicador", Simbolo = "Peso_i", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Valor do indicador", Simbolo = "Indicador_i", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs => inputs["Peso do indicador"] * inputs["Valor do indicador"],
                    VariavelResultado = "ISA",
                    UnidadeResultado = "unidade composta"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
