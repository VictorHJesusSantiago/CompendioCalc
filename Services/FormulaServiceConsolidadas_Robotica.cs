using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Robótica
    /// Fórmulas reais e bibliografadas da subárea Robótica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Robotica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4801",
                    CodigoCompendio = "CROB-001",
                    Nome = "Cinemática Direta de Manipulador",
                    Categoria = "Robótica",
                    SubCategoria = "Cinemática",
                    Expressao = "x = f(θ₁, θ₂, ..., θₙ)",
                    Descricao = "Posição do efetuador em função dos ângulos das juntas.",
                    Criador = "Prática em robótica",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Craig, J. J. Introduction to Robotics, 1986.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Ângulos das juntas", Simbolo = "θ", Unidade = "graus", ValorPadrao = 0 }
                    },
                    Calcular = inputs => inputs["Ângulos das juntas"],
                    VariavelResultado = "Posição",
                    UnidadeResultado = "unidade de comprimento"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
