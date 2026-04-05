using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Geografia
    /// Fórmulas reais e bibliografadas da área de Geografia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Geografia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C901",
                    CodigoCompendio = "CGE-001",
                    Nome = "Densidade Demográfica",
                    Categoria = "Geografia",
                    SubCategoria = "Demografia",
                    Expressao = "D = População / Área",
                    Descricao = "A densidade demográfica é o número de habitantes por unidade de área.",
                    Criador = "Conceito clássico",
                    AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "UN Population Division, World Population Prospects.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "População", Simbolo = "População", Unidade = "habitantes", ValorPadrao = 1000000 },
                        new Variavel { Nome = "Área", Simbolo = "Área", Unidade = "km²", ValorPadrao = 1000 }
                    },
                    Calcular = inputs => inputs["População"] / inputs["Área"],
                    VariavelResultado = "Densidade",
                    UnidadeResultado = "hab/km²"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
