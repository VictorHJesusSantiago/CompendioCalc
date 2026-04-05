using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Música
    /// Fórmulas reais e bibliografadas da área de Música
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Musica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2101",
                    CodigoCompendio = "CMUS-001",
                    Nome = "Frequência da N-ésima Nota",
                    Categoria = "Música",
                    SubCategoria = "Acústica Musical",
                    Expressao = "f = f₀ × 2^(n/12)",
                    Descricao = "Calcula a frequência de uma nota na escala temperada.",
                    Criador = "Sistema temperado ocidental",
                    AnoOrigin = "séc. XVIII",
                    ReferenciaBibliografica = "Helmholtz, H. Die Lehre von den Tonempfindungen, 1863.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Frequência base", Simbolo = "f₀", Unidade = "Hz", ValorPadrao = 440 },
                        new Variavel { Nome = "Número de semitons", Simbolo = "n", Unidade = "", ValorPadrao = 0 }
                    },
                    Calcular = inputs => inputs["Frequência base"] * System.Math.Pow(2, inputs["Número de semitons"] / 12),
                    VariavelResultado = "Frequência",
                    UnidadeResultado = "Hz"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
