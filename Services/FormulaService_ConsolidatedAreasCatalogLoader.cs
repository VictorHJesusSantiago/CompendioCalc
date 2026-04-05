using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Orquestrador das Fórmulas Consolidadas
    /// Chama todos os métodos de áreas consolidadas
    /// </summary>
    public partial class FormulaService
    {
        /// <summary>
        /// Adiciona todas as fórmulas consolidadas reais e bibliografadas
        /// </summary>
        public void AdicionarFormulasConsolidadas()
        {
            AdicionarFormulasConsolidadas_Fisica();
            AdicionarFormulasConsolidadas_Quimica();
            AdicionarFormulasConsolidadas_Matematica();
            AdicionarFormulasConsolidadas_Biologia();
            AdicionarFormulasConsolidadas_Engenharia();
            AdicionarFormulasConsolidadas_Estatistica();
            AdicionarFormulasConsolidadas_Computacao();
            AdicionarFormulasConsolidadas_Economia();
            AdicionarFormulasConsolidadas_Medicina();
            AdicionarFormulasConsolidadas_Geografia();
            AdicionarFormulasConsolidadas_Filosofia();
            AdicionarFormulasConsolidadas_Sociologia();
            AdicionarFormulasConsolidadas_Psicologia();
            AdicionarFormulasConsolidadas_Artes();
            AdicionarFormulasConsolidadas_Direito();
            AdicionarFormulasConsolidadas_Administracao();
            AdicionarFormulasConsolidadas_Educacao();
            AdicionarFormulasConsolidadas_Comunicacao();
            AdicionarFormulasConsolidadas_MeioAmbiente();
            AdicionarFormulasConsolidadas_Astronomia();
            AdicionarFormulasConsolidadas_Antropologia();
            AdicionarFormulasConsolidadas_Musica();
            AdicionarFormulasConsolidadas_EngenhariaCivil();
            AdicionarFormulasConsolidadas_EngenhariaEletrica();
            AdicionarFormulasConsolidadas_EngenhariaQuimica();
            AdicionarFormulasConsolidadas_Farmacia();
            AdicionarFormulasConsolidadas_Nutricao();
            AdicionarFormulasConsolidadas_Veterinaria();
            AdicionarFormulasConsolidadas_Esportes();
            AdicionarFormulasConsolidadas_Sustentabilidade();
            AdicionarFormulasConsolidadas_InovacaoTecnologica();
            AdicionarFormulasConsolidadas_EngenhariaBiomedica();
            AdicionarFormulasConsolidadas_ComputacaoQuantica();
            AdicionarFormulasConsolidadas_CienciaMateriais();
            // ...adicione outras áreas conforme forem criadas...
        }
    }
}
