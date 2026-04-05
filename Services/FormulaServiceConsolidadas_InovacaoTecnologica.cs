using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Inovação Tecnológica
    /// Fórmulas reais e bibliografadas da área multidisciplinar Inovação Tecnológica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_InovacaoTecnologica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5201",
                    CodigoCompendio = "CINOV-001",
                    Nome = "Índice de Inovação",
                    Categoria = "Inovação Tecnológica",
                    SubCategoria = "Indicadores de Inovação",
                    Expressao = "II = (Patentes + Publicações + Startups) / População",
                    Descricao = "Indicador composto de inovação tecnológica em uma região.",
                    Criador = "Prática multidisciplinar",
                    AnoOrigin = "séc. XXI",
                    ReferenciaBibliografica = "Manual de Oslo, OCDE.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Patentes", Simbolo = "Patentes", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "Publicações", Simbolo = "Publicações", Unidade = "", ValorPadrao = 20 },
                        new Variavel { Nome = "Startups", Simbolo = "Startups", Unidade = "", ValorPadrao = 5 },
                        new Variavel { Nome = "População", Simbolo = "População", Unidade = "habitantes", ValorPadrao = 100000 }
                    },
                    Calcular = inputs => (inputs["Patentes"] + inputs["Publicações"] + inputs["Startups"]) / inputs["População"],
                    VariavelResultado = "Índice de Inovação",
                    UnidadeResultado = "por habitante"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
