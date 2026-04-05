using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia Biomédica
    /// Fórmulas reais e bibliografadas da área multidisciplinar Engenharia Biomédica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaBiomedica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5301",
                    CodigoCompendio = "CBIOMED-001",
                    Nome = "Índice de Perfusão Tecidual",
                    Categoria = "Engenharia Biomédica",
                    SubCategoria = "Fisiologia Aplicada",
                    Expressao = "IPT = (Débito Cardíaco / Massa Corporal)",
                    Descricao = "Índice utilizado para avaliar a perfusão de tecidos.",
                    Criador = "Prática biomédica",
                    AnoOrigin = "séc. XXI",
                    ReferenciaBibliografica = "Manual de Engenharia Biomédica.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Débito Cardíaco", Simbolo = "DC", Unidade = "L/min", ValorPadrao = 5 },
                        new Variavel { Nome = "Massa Corporal", Simbolo = "MC", Unidade = "kg", ValorPadrao = 70 }
                    },
                    Calcular = inputs => inputs["Débito Cardíaco"] / inputs["Massa Corporal"],
                    VariavelResultado = "IPT",
                    UnidadeResultado = "L/min/kg"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
