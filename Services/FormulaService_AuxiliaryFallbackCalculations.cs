using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    private static double CalculoPadrao(Dictionary<string, double> vars)
    {
        if (vars.TryGetValue("x", out var x) && vars.TryGetValue("n", out var n))
        {
            return Math.Pow(x, n);
        }

        if (vars.TryGetValue("x", out x) && vars.TryGetValue("y", out var y))
        {
            return x + y;
        }

        if (vars.TryGetValue("a", out var a) && vars.TryGetValue("b", out var b))
        {
            return a + b;
        }

        foreach (var item in vars)
        {
            return item.Value;
        }

        return 0;
    }
}
