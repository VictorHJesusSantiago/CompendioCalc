using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia de Petróleo
    /// Fórmulas reais e bibliografadas da subárea Engenharia de Petróleo
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaPetroleo()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3401",
                    CodigoCompendio = "CEPET-001",
                    Nome = "Fator de Volume de Óleo (Bo)",
                    Categoria = "Engenharia de Petróleo",
                    SubCategoria = "Reservatórios",
                    Expressao = "Bo = Vbarril / Vreservatório",
                    Descricao = "Relação entre o volume de óleo no reservatório e o volume produzido.",
                    Criador = "Prática de engenharia de petróleo",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Normas técnicas de petróleo.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Volume no reservatório", Simbolo = "Vreservatório", Unidade = "bbl", ValorPadrao = 1000 },
                        new Variavel { Nome = "Volume produzido", Simbolo = "Vbarril", Unidade = "bbl", ValorPadrao = 950 }
                    },
                    Calcular = inputs => inputs["Volume produzido"] / inputs["Volume no reservatório"],
                    VariavelResultado = "Fator de Volume",
                    UnidadeResultado = ""
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
