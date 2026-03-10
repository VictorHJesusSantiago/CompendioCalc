using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME XII - ORQUESTRADOR PRINCIPAL
    /// COMPÊNDIO GERAL DE EQUAÇÕES - VOLUME XII
    /// Horizontes da Ciência — Novas Fronteiras do Saber (Edição 2026)
    /// </summary>
    public partial class FormulaService
    {
        public void AdicionarFormulasVol12()
        {
            AdicionarFormulasVol12_Cristalografia();
            AdicionarFormulasVol12_Literal();
        }
    }
}
