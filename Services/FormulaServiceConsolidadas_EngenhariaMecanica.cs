using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Consolidadas - Engenharia Mecânica
    /// Fórmulas reais e bibliografadas da subárea Engenharia Mecânica
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_EngenhariaMecanica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2901",
                    CodigoCompendio = "CEMEC-001",
                    Nome = "Potência Mecânica",
                    Categoria = "Engenharia Mecânica",
                    SubCategoria = "Dinâmica",
                    Expressao = "P = F·v",
                    Descricao = "A potência é o produto da força pela velocidade.",
                    Criador = "Conceito clássico",
                    AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Normas técnicas de mecânica.",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Força", Simbolo = "F", Unidade = "N", ValorPadrao = 100 },
                        new Variavel { Nome = "Velocidade", Simbolo = "v", Unidade = "m/s", ValorPadrao = 2 }
                    },
                    Calcular = inputs => inputs["Força"] * inputs["Velocidade"],
                    VariavelResultado = "Potência",
                    UnidadeResultado = "W"
                }
                // ...adicione mais fórmulas reais e bibliografadas aqui...
            });
        }
    }
}
