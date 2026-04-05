using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Matemática
    /// Fórmulas reais e bibliografadas da área de Matemática
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Matematica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C201",
                    CodigoCompendio = "CM-001",
                    Nome = "Teorema de Pitágoras",
                    Categoria = "Matemática",
                    SubCategoria = "Geometria",
                    Expressao = "a² + b² = c²",
                    Descricao = "Em um triângulo retângulo, o quadrado da hipotenusa é igual à soma dos quadrados dos catetos.",
                    Criador = "Pitágoras de Samos",
                    AnoOrigin = "c. 530 a.C.",
                    ReferenciaBibliografica = "Euclides, Elementos, Livro I, Proposição 47.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Cateto a", Simbolo = "a", Unidade = "", ValorPadrao = 3 },
                        new Variavel { Nome = "Cateto b", Simbolo = "b", Unidade = "", ValorPadrao = 4 }
                    },
                    Calcular = inputs => System.Math.Sqrt(inputs["Cateto a"] * inputs["Cateto a"] + inputs["Cateto b"] * inputs["Cateto b"]),
                    VariavelResultado = "Hipotenusa",
                    UnidadeResultado = ""
                },
                new Formula
                {
                    Id = "C202",
                    CodigoCompendio = "CM-002",
                    Nome = "Fórmula de Bhaskara (Resolução de Equação Quadrática)",
                    Categoria = "Matemática",
                    SubCategoria = "Álgebra",
                    Expressao = "x = [-b ± sqrt(b²-4ac)]/(2a)",
                    Descricao = "Resolve equações do segundo grau.",
                    Criador = "Bhaskara Akaria",
                    AnoOrigin = "c. 628 d.C.",
                    ReferenciaBibliografica = "Bhaskara II, Siddhanta Shiromani, 1150.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "a", Simbolo = "a", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "b", Simbolo = "b", Unidade = "", ValorPadrao = -3 },
                        new Variavel { Nome = "c", Simbolo = "c", Unidade = "", ValorPadrao = 2 }
                    },
                    Calcular = inputs => {
                        double a = inputs["a"];
                        double b = inputs["b"];
                        double c = inputs["c"];
                        double delta = b * b - 4 * a * c;
                        return (-b + System.Math.Sqrt(delta)) / (2 * a); // retorna uma das raízes
                    },
                    VariavelResultado = "x",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
