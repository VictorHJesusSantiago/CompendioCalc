using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Psicologia
    /// Fórmulas reais e bibliografadas da área de Psicologia
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Psicologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1201",
                    CodigoCompendio = "CPSI-001",
                    Nome = "Q.I. (Quociente de Inteligência)",
                    Categoria = "Psicologia",
                    SubCategoria = "Psicometria",
                    Expressao = "QI = (Idade Mental / Idade Cronológica) × 100",
                    Descricao = "Mede o desempenho intelectual em relação à média da idade.",
                    Criador = "William Stern",
                    AnoOrigin = "1912",
                    ReferenciaBibliografica = "Stern, W. The Psychological Methods of Testing Intelligence, 1912.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Idade Mental", Simbolo = "IM", Unidade = "anos", ValorPadrao = 10 },
                        new Variavel { Nome = "Idade Cronológica", Simbolo = "IC", Unidade = "anos", ValorPadrao = 10 }
                    },
                    Calcular = inputs => (inputs["Idade Mental"] / inputs["Idade Cronológica"]) * 100,
                    VariavelResultado = "QI",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
