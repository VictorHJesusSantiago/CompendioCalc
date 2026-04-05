using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Esportes
    /// Fórmulas reais e bibliografadas da área de Esportes
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Esportes()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2801",
                    CodigoCompendio = "CESP-001",
                    Nome = "Frequência Cardíaca Máxima (FCM)",
                    Categoria = "Esportes",
                    SubCategoria = "Fisiologia do Exercício",
                    Expressao = "FCM = 220 - Idade",
                    Descricao = "Estimativa da frequência cardíaca máxima para exercícios físicos.",
                    Criador = "Prática esportiva",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Fox, S. M. Sports Medicine, 1971.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Idade", Simbolo = "Idade", Unidade = "anos", ValorPadrao = 30 }
                    },
                    Calcular = inputs => 220 - inputs["Idade"],
                    VariavelResultado = "FCM",
                    UnidadeResultado = "bpm"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
