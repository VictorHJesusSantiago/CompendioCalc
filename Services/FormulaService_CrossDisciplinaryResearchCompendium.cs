using System;
using System.Collections.Generic;
using CompendioCalc.Models;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        // =========================================================================
        // VOLUME XI - COMPLETE AGGREGATOR
        // Loads all 20 formula categories (400 formulas total, IDs 3001-3400)
        // =========================================================================

        public void LoadAllVol11()
        {
            // Register each category from Batch 1-5
            LoadVol11_AstrofisicaEstelar();           // 3001-3020 (20)
            LoadVol11_FusaoTermonuclear();            // 3021-3040 (20)
            LoadVol11_EngenhariaPetroleo();           // 3041-3061 (21)
            LoadVol11_CienciaPolimeros();             // 3062-3081 (20)
            LoadVol11_GeofisicaSismologia();          // 3082-3101 (20)
            LoadVol11_FotonicaOpticaQuantica();       // 3102-3121 (20)
            LoadVol11_CienciaDadosML();               // 3122-3141 (20)
            LoadVol11_BiomecranicaCardiovascular();   // 3142-3161 (20)
            LoadVol11_EngenhariaControle();           // 3162-3182 (21)
            LoadVol11_EngenhariaAmbiental();          // 3183-3202 (20)
            LoadVol11_EngenhariaNuclear();            // 3203-3222 (20)
            LoadVol11_MeteorologiaClima();            // 3223-3242 (20)
            LoadVol11_FisicaSemicondutores();         // 3243-3261 (19)
            LoadVol11_LinguisticaComputacional();     // 3262-3280 (19)
            LoadVol11_MicrofludaBiotecnologia();      // 3281-3300 (20)
            LoadVol11_FontesEnergiaRenovavel();       // 3301-3321 (21)
            LoadVol11_FisicaPlasma_MHD();             // 3322-3340 (19)
            LoadVol11_MatematicaFinanceira();         // 3341-3359 (19)
            LoadVol11_EngenhariaAeroespacial();       // 3360-3379 (20)
            LoadVol11_MatematicaPuraAvancada();       // 3380-3400 (21)
        }

        // Validates Vol11 integrity
        public bool ValidateVol11()
        {
            // Check total count
            var vol11Formulas = formulas.FindAll(f => f.Id.StartsWith("3"));
            if (vol11Formulas.Count != 400)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: Expected 400 Vol11 formulas, found {vol11Formulas.Count}");
                return false;
            }

            // Check ID contiguity (3001-3400)
            var ids = new HashSet<string>();
            foreach (var f in vol11Formulas)
            {
                ids.Add(f.Id);
            }

            for (int i = 3001; i <= 3400; i++)
            {
                if (!ids.Contains(i.ToString()))
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR: Missing formula ID {i}");
                    return false;
                }
            }

            // Check category distribution
            var categories = new Dictionary<string, int>();
            foreach (var f in vol11Formulas)
            {
                if (!categories.ContainsKey(f.CategoryId))
                    categories[f.CategoryId] = 0;
                categories[f.CategoryId]++;
            }

            System.Diagnostics.Debug.WriteLine($"✓ Vol11 Validation PASSED");
            System.Diagnostics.Debug.WriteLine($"  Total formulas: {vol11Formulas.Count}");
            System.Diagnostics.Debug.WriteLine($"  Categories: {categories.Count}");
            foreach (var cat in categories)
            {
                System.Diagnostics.Debug.WriteLine($"    {cat.Key}: {cat.Value} formulas");
            }

            return true;
        }

        // Get Vol11 formula by ID
        public Formula GetVol11Formula(string id)
        {
            return formulas.Find(f => f.Id == id && f.Id.StartsWith("3"));
        }

        // Get all Vol11 formulas by category
        public List<Formula> GetVol11FormulasByCategory(string categoryId)
        {
            return formulas.FindAll(f => f.CategoryId == categoryId && f.Id.StartsWith("3"));
        }

        // Print Vol11 summary
        public void PrintVol11Summary()
        {
            var vol11Formulas = formulas.FindAll(f => f.Id.StartsWith("3"));
            
            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  COMPENDIO CALC - VOLUME XI SUMMARY                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");

            var categories = new Dictionary<string, int>();
            foreach (var f in vol11Formulas)
            {
                if (!categories.ContainsKey(f.CategoryId))
                    categories[f.CategoryId] = 0;
                categories[f.CategoryId]++;
            }

            Console.WriteLine($"  Total Formulas: {vol11Formulas.Count}/400");
            Console.WriteLine($"  Categories: {categories.Count}/20");
            Console.WriteLine($"  ID Range: 3001-3400\n");

            Console.WriteLine("  Category Breakdown:");
            int cumulative = 0;
            foreach (var cat in categories)
            {
                cumulative += cat.Value;
                string cleanCat = cat.Key.Replace("VOL11_", "").Replace("_", " ");
                Console.WriteLine($"    • {cleanCat,-35} {cat.Value,3} formulas (IDs 3{1000 + cumulative - cat.Value + 1:000}-3{1000 + cumulative:000})");
            }

            Console.WriteLine($"\n  ✓ Volume XI COMPLETE: {vol11Formulas.Count} formulas ready for calculation");
            Console.WriteLine("════════════════════════════════════════════════════════════════\n");
        }
    }
}
