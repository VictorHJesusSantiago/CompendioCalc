using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Comunicação
    /// Fórmulas reais e bibliografadas da área de Comunicação
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Comunicacao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1701",
                    CodigoCompendio = "CCOM-001",
                    Nome = "Índice de Flesch (Legibilidade)",
                    Categoria = "Comunicação",
                    SubCategoria = "Linguística",
                    Expressao = "IF = 206.835 - 1.015 × (Palavras/Frases) - 84.6 × (Sílabas/Palavras)",
                    Descricao = "Mede a facilidade de leitura de um texto.",
                    Criador = "Rudolf Flesch",
                    AnoOrigin = "1948",
                    ReferenciaBibliografica = "Flesch, R. A new readability yardstick, 1948.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Palavras", Simbolo = "Palavras", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Frases", Simbolo = "Frases", Unidade = "", ValorPadrao = 5 },
                        new Variavel { Nome = "Sílabas", Simbolo = "Sílabas", Unidade = "", ValorPadrao = 150 }
                    },
                    Calcular = inputs => 206.835 - 1.015 * (inputs["Palavras"] / inputs["Frases"]) - 84.6 * (inputs["Sílabas"] / inputs["Palavras"]),
                    VariavelResultado = "Índice de Flesch",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
