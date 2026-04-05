using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Computação Quântica
    /// Fórmulas reais e bibliografadas da área multidisciplinar Computação Quântica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_ComputacaoQuantica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5401",
                    CodigoCompendio = "CQUANT-001",
                    Nome = "Porta Hadamard",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Portas Lógicas Quânticas",
                    Expressao = "H = (1/√2)·[[1,1],[1,-1]]",
                    Descricao = "Matriz da porta Hadamard, fundamental em algoritmos quânticos.",
                    Criador = "Jacques Hadamard",
                    AnoOrigin = "1893",
                    ReferenciaBibliografica = "Hadamard, J. Bull. Sci. Math., 1893.",
                    Variaveis = new List<Variavel>(),
                    Calcular = inputs => 0, // Representação simbólica
                    VariavelResultado = "Matriz Hadamard",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
