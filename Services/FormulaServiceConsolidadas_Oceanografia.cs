using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Oceanografia
    /// Fórmulas reais e bibliografadas da subárea Oceanografia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Oceanografia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4301",
                    CodigoCompendio = "COCEANO-001",
                    Nome = "Salinidade",
                    Categoria = "Oceanografia",
                    SubCategoria = "Química Marinha",
                    Expressao = "S = (g de sais / kg de água) × 1000",
                    Descricao = "Salinidade da água do mar em partes por mil.",
                    Criador = "Prática oceanográfica",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Manual de Oceanografia Química.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Gramas de sais", Simbolo = "g de sais", Unidade = "g", ValorPadrao = 35 },
                        new Variavel { Nome = "Quilogramas de água", Simbolo = "kg de água", Unidade = "kg", ValorPadrao = 1 }
                    },
                    Calcular = inputs => (inputs["Gramas de sais"] / inputs["Quilogramas de água"]) * 1000,
                    VariavelResultado = "Salinidade",
                    UnidadeResultado = "‰"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
