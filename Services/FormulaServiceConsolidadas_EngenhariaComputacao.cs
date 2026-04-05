using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia de Computação
    /// Fórmulas reais e bibliografadas da subárea Engenharia de Computação
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaComputacao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3301",
                    CodigoCompendio = "CECOMP-001",
                    Nome = "Tempo de Resposta de Sistema",
                    Categoria = "Engenharia de Computação",
                    SubCategoria = "Desempenho de Sistemas",
                    Expressao = "TR = Tprocesso + Tcomunicação",
                    Descricao = "Tempo total de resposta de um sistema computacional.",
                    Criador = "Prática de computação",
                    AnoOrigin = "séc. XXI",
                    ReferenciaBibliografica = "Normas de desempenho de sistemas.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tempo de processamento", Simbolo = "Tprocesso", Unidade = "ms", ValorPadrao = 10 },
                        new Variavel { Nome = "Tempo de comunicação", Simbolo = "Tcomunicação", Unidade = "ms", ValorPadrao = 5 }
                    },
                    Calcular = inputs => inputs["Tempo de processamento"] + inputs["Tempo de comunicação"],
                    VariavelResultado = "Tempo de Resposta",
                    UnidadeResultado = "ms"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
