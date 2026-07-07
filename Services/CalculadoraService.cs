using System.Text.Json;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public class HistoricoItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
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
    public string FormulaVersion { get; set; } = "1.0.0";
    public string Title { get; set; } = "";
    public string Note { get; set; } = "";
    public List<string> Tags { get; set; } = [];
    public string Project { get; set; } = "";
    public bool Favorite { get; set; }
    public bool Archived { get; set; }
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
                ,FormulaVersion = formula.Metadata.Versao
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

    public IEnumerable<HistoricoItem> Search(
        string? query = null,
        string? formulaId = null,
        string? category = null,
        DateTime? from = null,
        DateTime? to = null,
        bool includeArchived = false)
    {
        IEnumerable<HistoricoItem> result = _historico;
        if (!includeArchived) result = result.Where(item => !item.Archived);
        if (!string.IsNullOrWhiteSpace(query))
            result = result.Where(item =>
                item.FormulaNome.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                item.Note.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                item.Tags.Any(tag => tag.Contains(query, StringComparison.OrdinalIgnoreCase)));
        if (!string.IsNullOrWhiteSpace(formulaId))
            result = result.Where(item => item.FormulaId.Equals(formulaId, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(category))
            result = result.Where(item => item.Categoria.Equals(category, StringComparison.OrdinalIgnoreCase));
        if (from.HasValue) result = result.Where(item => item.Timestamp >= from.Value);
        if (to.HasValue) result = result.Where(item => item.Timestamp <= to.Value);
        return result.OrderByDescending(item => item.Timestamp);
    }

    public void Update(HistoricoItem item)
    {
        var index = _historico.FindIndex(existing => existing.Id == item.Id);
        if (index < 0) throw new KeyNotFoundException(item.Id);
        _historico[index] = item;
        SalvarHistorico();
        OnHistoricoChanged?.Invoke();
    }

    public void DeletePeriod(DateTime from, DateTime to)
    {
        _historico.RemoveAll(item => item.Timestamp >= from && item.Timestamp <= to);
        SalvarHistorico();
        OnHistoricoChanged?.Invoke();
    }

    public string ExportJson() => JsonSerializer.Serialize(_historico, new JsonSerializerOptions(_jsonOpts)
    {
        WriteIndented = true
    });

    public void ImportJson(string json, bool merge = true)
    {
        var imported = JsonSerializer.Deserialize<List<HistoricoItem>>(json, _jsonOpts)
                       ?? throw new InvalidDataException("Histórico inválido.");
        if (merge)
        {
            var existing = _historico.Select(item => item.Id).ToHashSet(StringComparer.OrdinalIgnoreCase);
            _historico.AddRange(imported.Where(item => existing.Add(item.Id)));
        }
        else
        {
            _historico = imported;
        }
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
