using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia de Materiais
    /// Fórmulas reais e bibliografadas da subárea Engenharia de Materiais
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaMateriais()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3001",
                    CodigoCompendio = "CEMAT-001",
                    Nome = "Módulo de Young",
                    Categoria = "Engenharia de Materiais",
                    SubCategoria = "Propriedades Mecânicas",
                    Expressao = "E = σ/ε",
                    Descricao = "O módulo de Young é a razão entre tensão e deformação.",
                    Criador = "Thomas Young",
                    AnoOrigin = "1807",
                    ReferenciaBibliografica = "Young, T. A Course of Lectures on Natural Philosophy, 1807.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tensão", Simbolo = "σ", Unidade = "Pa", ValorPadrao = 1000000 },
                        new Variavel { Nome = "Deformação", Simbolo = "ε", Unidade = "", ValorPadrao = 0.001 }
                    },
                    Calcular = inputs => inputs["Tensão"] / inputs["Deformação"],
                    VariavelResultado = "Módulo de Young",
                    UnidadeResultado = "Pa"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
