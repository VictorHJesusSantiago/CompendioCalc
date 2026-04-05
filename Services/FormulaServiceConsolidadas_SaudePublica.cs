using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Saúde Pública
    /// Fórmulas reais e bibliografadas da subárea Saúde Pública
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_SaudePublica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3701",
                    CodigoCompendio = "CSPUB-001",
                    Nome = "Taxa de Mortalidade Infantil",
                    Categoria = "Saúde Pública",
                    SubCategoria = "Epidemiologia",
                    Expressao = "TMI = (Óbitos < 1 ano / Nascidos Vivos) × 1000",
                    Descricao = "Número de óbitos de menores de 1 ano por mil nascidos vivos.",
                    Criador = "Indicador epidemiológico",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Ministério da Saúde, Indicadores de Saúde.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Óbitos < 1 ano", Simbolo = "Óbitos", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "Nascidos Vivos", Simbolo = "Nascidos", Unidade = "", ValorPadrao = 1000 }
                    },
                    Calcular = inputs => (inputs["Óbitos < 1 ano"] / inputs["Nascidos Vivos"]) * 1000,
                    VariavelResultado = "TMI",
                    UnidadeResultado = "por mil"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
