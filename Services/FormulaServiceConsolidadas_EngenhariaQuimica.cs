using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia Química
    /// Fórmulas reais e bibliografadas da área de Engenharia Química
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaQuimica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2401",
                    CodigoCompendio = "CEQUI-001",
                    Nome = "Rendimento de Reação",
                    Categoria = "Engenharia Química",
                    SubCategoria = "Reações Químicas",
                    Expressao = "R% = (Produto Obtido / Produto Teórico) × 100",
                    Descricao = "Percentual de rendimento de uma reação química.",
                    Criador = "Prática laboratorial",
                    AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Normas de laboratório químico.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Produto Obtido", Simbolo = "PO", Unidade = "g", ValorPadrao = 80 },
                        new Variavel { Nome = "Produto Teórico", Simbolo = "PT", Unidade = "g", ValorPadrao = 100 }
                    },
                    Calcular = inputs => (inputs["Produto Obtido"] / inputs["Produto Teórico"]) * 100,
                    VariavelResultado = "Rendimento",
                    UnidadeResultado = "%"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
