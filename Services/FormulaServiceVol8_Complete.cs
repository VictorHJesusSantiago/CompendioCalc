using CompendioCalc.Models;
using System.Linq;
using System.Reflection;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - COMPLETE
    // Total: 341 fórmulas em 18 áreas temáticas
    // ========================================

    public static List<Formula> GetVolume8Formulas()
    {
        var methods = typeof(FormulaService)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name.StartsWith("V8_", System.StringComparison.Ordinal)
                && m.ReturnType == typeof(Formula)
                && m.GetParameters().Length == 0)
            .OrderBy(m => m.Name);

        var formulas = new List<Formula>();
        foreach (var method in methods)
        {
            if (method.Invoke(null, null) is Formula formula)
            {
                formulas.Add(formula);
            }
        }

        return formulas
            .OrderBy(f => int.TryParse(f.CodigoCompendio, out var code) ? code : int.MaxValue)
            .ThenBy(f => f.CodigoCompendio)
            .ToList();
    }

    public static CategoriaInfo GetVolume8Info()
    {
        return new CategoriaInfo
        {
            Nome = "Volume VIII - Fronteiras do Conhecimento",
            Descricao = "Novas disciplinas: Química Analítica, Bioquímica, Neurociência, Robótica, Visão Computacional, Hidrologia, Materiais, Meteorologia, Oceanografia, Cosmologia, Econometria, NLP, Plasma, Confiabilidade, Óptica, Psicofísica, Alimentos e Música",
            Icone = "🔬",
            Cor = "#9C27B0",
            TotalFormulas = 341
        };
    }
}
