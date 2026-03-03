using CompendioCalc.Models;

namespace CompendioCalc.Services;

public class HistoricoItem
{
    public string FormulaId { get; set; } = "";
    public string FormulaNome { get; set; } = "";
    public Dictionary<string, double> Entradas { get; set; } = [];
    public double Resultado { get; set; }
    public string UnidadeResultado { get; set; } = "";
    public DateTime Timestamp { get; set; } = DateTime.Now;
}

public class CalculadoraService
{
    private readonly List<HistoricoItem> _historico = [];
    public event Action? OnHistoricoChanged;

    public IEnumerable<HistoricoItem> Historico => _historico.AsEnumerable().Reverse();

    public double Calcular(Formula formula, Dictionary<string, double> inputs)
    {
        if (formula.Calcular == null) return double.NaN;

        try
        {
            double resultado = formula.Calcular(inputs);
            _historico.Add(new HistoricoItem
            {
                FormulaId = formula.Id,
                FormulaNome = formula.Nome,
                Entradas = new Dictionary<string, double>(inputs),
                Resultado = resultado,
                UnidadeResultado = formula.UnidadeResultado,
                Timestamp = DateTime.Now
            });
            if (_historico.Count > 50) _historico.RemoveAt(0);
            OnHistoricoChanged?.Invoke();
            return resultado;
        }
        catch
        {
            return double.NaN;
        }
    }

    public void LimparHistorico()
    {
        _historico.Clear();
        OnHistoricoChanged?.Invoke();
    }
}
