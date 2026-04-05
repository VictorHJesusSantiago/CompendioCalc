using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Filosofia
    /// Fórmulas reais e bibliografadas da área de Filosofia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Filosofia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1001",
                    CodigoCompendio = "CFIL-001",
                    Nome = "Paradoxo do Mentiroso",
                    Categoria = "Filosofia",
                    SubCategoria = "Lógica",
                    Expressao = "Esta frase é falsa.",
                    Descricao = "Exemplo clássico de autorreferência e paradoxo lógico.",
                    Criador = "Epimênides de Creta",
                    AnoOrigin = "c. 600 a.C.",
                    ReferenciaBibliografica = "Priest, G. The Liar Paradox, Stanford Encyclopedia of Philosophy.",
                    Variaveis = new List<Variavel>(),
                    Calcular = inputs => double.NaN,
                    VariavelResultado = "Paradoxo",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
