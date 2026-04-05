using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Educação
    /// Fórmulas reais e bibliografadas da área de Educação
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Educacao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1601",
                    CodigoCompendio = "CEDU-001",
                    Nome = "Taxa de Aprovação",
                    Categoria = "Educação",
                    SubCategoria = "Indicadores Educacionais",
                    Expressao = "TA = (Aprovados / Matriculados) × 100",
                    Descricao = "Percentual de alunos aprovados em relação ao total de matriculados.",
                    Criador = "Indicador educacional",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "INEP, Indicadores Educacionais.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Aprovados", Simbolo = "Aprovados", Unidade = "", ValorPadrao = 80 },
                        new Variavel { Nome = "Matriculados", Simbolo = "Matriculados", Unidade = "", ValorPadrao = 100 }
                    },
                    Calcular = inputs => (inputs["Aprovados"] / inputs["Matriculados"]) * 100,
                    VariavelResultado = "Taxa de Aprovação",
                    UnidadeResultado = "%"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
