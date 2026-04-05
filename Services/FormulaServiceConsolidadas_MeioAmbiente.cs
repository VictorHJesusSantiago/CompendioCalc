using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Meio Ambiente
    /// Fórmulas reais e bibliografadas da área de Meio Ambiente
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_MeioAmbiente()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C1801",
                    CodigoCompendio = "CMA-001",
                    Nome = "Pegada de Carbono (CO₂)",
                    Categoria = "Meio Ambiente",
                    SubCategoria = "Sustentabilidade",
                    Expressao = "PC = Σ(Energia × Fator de Emissão)",
                    Descricao = "Calcula a emissão total de CO₂ equivalente de atividades humanas.",
                    Criador = "Conceito ambiental",
                    AnoOrigin = "séc. XXI",
                    ReferenciaBibliografica = "IPCC Guidelines for National Greenhouse Gas Inventories.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Energia", Simbolo = "Energia", Unidade = "kWh", ValorPadrao = 1000 },
                        new Variavel { Nome = "Fator de Emissão", Simbolo = "Fator", Unidade = "kgCO₂/kWh", ValorPadrao = 0.5 }
                    },
                    Calcular = inputs => inputs["Energia"] * inputs["Fator de Emissão"],
                    VariavelResultado = "Pegada de Carbono",
                    UnidadeResultado = "kgCO₂"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
