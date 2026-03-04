using System.Text.Json;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public class HistoricoItem
{
    public string FormulaId { get; set; } = "";
    public string FormulaNome { get; set; } = "";
    public string Categoria { get; set; } = "";
    public string ExprTexto { get; set; } = "";
    public Dictionary<string, double> Entradas { get; set; } = [];
    public List<EntradaDetalhe> EntradasDetalhe { get; set; } = [];
    public double Resultado { get; set; }
    public string UnidadeResultado { get; set; } = "";
    public string VariavelResultado { get; set; } = "";
    public DateTime Timestamp { get; set; } = DateTime.Now;
}

/// <summary>Detalhe legível de cada entrada usada no cálculo.</summary>
public class EntradaDetalhe
{
    public string Simbolo { get; set; } = "";
    public string Nome { get; set; } = "";
    public string Unidade { get; set; } = "";
    public double Valor { get; set; }
}

public class CalculadoraService
{
    private List<HistoricoItem> _historico = [];
    public event Action? OnHistoricoChanged;

    private static readonly JsonSerializerOptions _jsonOpts = new()
    {
        WriteIndented = false,
        PropertyNameCaseInsensitive = true
    };

    public IEnumerable<HistoricoItem> Historico => _historico.AsEnumerable().Reverse();
    public int TotalHistorico => _historico.Count;

    /// <summary>Carrega histórico persistido do disco.</summary>
    public void CarregarHistorico()
    {
        try
        {
            var path = GetFilePath();
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                _historico = JsonSerializer.Deserialize<List<HistoricoItem>>(json, _jsonOpts) ?? [];
            }
        }
        catch
        {
            _historico = [];
        }
    }

    public double Calcular(Formula formula, Dictionary<string, double> inputs)
    {
        if (formula.Calcular == null) return double.NaN;

        try
        {
            double resultado = formula.Calcular(inputs);

            // Monta detalhes legíveis de cada entrada
            var detalhes = formula.Variaveis.Select(v => new EntradaDetalhe
            {
                Simbolo = v.Simbolo,
                Nome = v.Nome,
                Unidade = v.Unidade,
                Valor = inputs.TryGetValue(v.Simbolo, out var val) ? val : 0
            }).ToList();

            _historico.Add(new HistoricoItem
            {
                FormulaId = formula.Id,
                FormulaNome = formula.Nome,
                Categoria = formula.Categoria,
                ExprTexto = formula.ExprTexto,
                Entradas = new Dictionary<string, double>(inputs),
                EntradasDetalhe = detalhes,
                Resultado = resultado,
                UnidadeResultado = formula.UnidadeResultado,
                VariavelResultado = formula.VariavelResultado,
                Timestamp = DateTime.Now
            });

            SalvarHistorico();
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
        SalvarHistorico();
        OnHistoricoChanged?.Invoke();
    }

    public void RemoverItem(HistoricoItem item)
    {
        _historico.Remove(item);
        SalvarHistorico();
        OnHistoricoChanged?.Invoke();
    }

    // ── Persistência ────────────────────────────────────

    private void SalvarHistorico()
    {
        try
        {
            var json = JsonSerializer.Serialize(_historico, _jsonOpts);
            File.WriteAllText(GetFilePath(), json);
        }
        catch { /* silencioso – não bloqueia o uso do app */ }
    }

    private static string GetFilePath()
    {
        var dir = FileSystem.AppDataDirectory;
        return Path.Combine(dir, "historico.json");
    }
}
