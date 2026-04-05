using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Inteligência Artificial
    /// Fórmulas reais e bibliografadas da subárea Inteligência Artificial
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_InteligenciaArtificial()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4601",
                    CodigoCompendio = "CIA-001",
                    Nome = "Função de Ativação Sigmóide",
                    Categoria = "Inteligência Artificial",
                    SubCategoria = "Redes Neurais",
                    Expressao = "σ(x) = 1 / (1 + e^{-x})",
                    Descricao = "Função de ativação clássica em redes neurais artificiais.",
                    Criador = "Warren McCulloch & Walter Pitts",
                    AnoOrigin = "1943",
                    ReferenciaBibliografica = "McCulloch, W. S.; Pitts, W. Bull. Math. Biophys., 1943.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Entrada", Simbolo = "x", Unidade = "", ValorPadrao = 0 }
                    },
                    Calcular = inputs => 1.0 / (1.0 + System.Math.Exp(-inputs["Entrada"])),
                    VariavelResultado = "Saída",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
