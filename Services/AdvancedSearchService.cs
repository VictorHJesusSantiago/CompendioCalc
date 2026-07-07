using System.Globalization;
using System.Text;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public sealed record SearchOptions(
    string? Category = null,
    string? SubCategory = null,
    NivelDificuldade? Difficulty = null,
    EstadoCuradoria? Curation = null,
    string? Unit = null,
    string? Creator = null,
    int Limit = 100);

public sealed record SearchHit(Formula Formula, double Score, IReadOnlyList<string> MatchedFields);

public sealed class AdvancedSearchService
{
    private readonly FormulaService _formulas;
    private readonly Dictionary<string, string[]> _synonyms = new(StringComparer.OrdinalIgnoreCase)
    {
        ["velocidade"] = ["rapidez", "speed", "velocity"],
        ["força"] = ["force", "fuerza"],
        ["energia"] = ["energy", "energía"],
        ["pressão"] = ["pressure", "presión"],
        ["derivada"] = ["derivative", "derivada"],
        ["integral"] = ["integration", "integração"],
        ["média"] = ["mean", "average", "promedio"]
    };

    public AdvancedSearchService(FormulaService formulas) => _formulas = formulas;

    public IReadOnlyList<SearchHit> Search(string query, SearchOptions? options = null)
    {
        options ??= new();
        var normalized = Normalize(query);
        var terms = Expand(normalized);
        return _formulas.ObterTodas()
            .Where(formula => MatchesFilters(formula, options))
            .Select(formula => Score(formula, normalized, terms))
            .Where(hit => hit.Score > 0)
            .OrderByDescending(hit => hit.Score)
            .ThenBy(hit => hit.Formula.Nome)
            .Take(Math.Clamp(options.Limit, 1, 1000))
            .ToArray();
    }

    public IReadOnlyList<string> Suggest(string query, int limit = 8)
    {
        var normalized = Normalize(query);
        return _formulas.ObterTodas()
            .SelectMany(formula => new[] { formula.Nome, formula.Criador, formula.Categoria }
                .Concat(formula.NomesAlternativos).Concat(formula.PalavrasChave))
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Select(value => (Value: value, Score: Similarity(normalized, Normalize(value))))
            .Where(item => item.Score >= .35)
            .OrderByDescending(item => item.Score)
            .ThenBy(item => item.Value)
            .Take(limit)
            .Select(item => item.Value)
            .ToArray();
    }

    private SearchHit Score(Formula formula, string query, IReadOnlySet<string> terms)
    {
        var fields = new Dictionary<string, (string Text, double Weight)>
        {
            ["nome"] = (formula.Nome, 10),
            ["aliases"] = (string.Join(' ', formula.NomesAlternativos), 9),
            ["símbolos"] = (formula.Expressao + " " + string.Join(' ', formula.SimbolosAlternativos), 7),
            ["palavras-chave"] = (string.Join(' ', formula.PalavrasChave), 8),
            ["descrição"] = (formula.Descricao, 4),
            ["aplicação"] = (formula.ExemploPratico, 5),
            ["criador"] = (formula.Criador, 5),
            ["categoria"] = (formula.Categoria + " " + formula.SubCategoria, 4),
            ["unidades"] = (formula.Unidades + " " + formula.UnidadeResultado, 3),
            ["referência"] = (formula.ReferenciaBibliografica, 2)
        };
        var score = 0d;
        var matches = new List<string>();
        foreach (var (name, data) in fields)
        {
            var text = Normalize(data.Text);
            if (string.IsNullOrEmpty(text)) continue;
            var local = text == query ? 1 : text.StartsWith(query) ? .9 : text.Contains(query) ? .75 : 0;
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var term in terms)
            {
                if (text.Contains(term)) local = Math.Max(local, .65);
                else if (words.Any(word => Similarity(term, word) >= .78)) local = Math.Max(local, .45);
            }
            if (local <= 0) continue;
            score += local * data.Weight;
            matches.Add(name);
        }
        return new(formula, Math.Round(score, 4), matches);
    }

    private IReadOnlySet<string> Expand(string query)
    {
        var result = query.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToHashSet(StringComparer.OrdinalIgnoreCase);
        foreach (var (key, values) in _synonyms)
        {
            var normalizedKey = Normalize(key);
            if (!result.Contains(normalizedKey) && !values.Any(value => result.Contains(Normalize(value)))) continue;
            result.Add(normalizedKey);
            foreach (var value in values) result.Add(Normalize(value));
        }
        return result;
    }

    private static bool MatchesFilters(Formula formula, SearchOptions options) =>
        (string.IsNullOrWhiteSpace(options.Category) || formula.Categoria.Equals(options.Category, StringComparison.OrdinalIgnoreCase)) &&
        (string.IsNullOrWhiteSpace(options.SubCategory) || formula.SubCategoria.Equals(options.SubCategory, StringComparison.OrdinalIgnoreCase)) &&
        (!options.Difficulty.HasValue || formula.Metadata.Dificuldade == options.Difficulty) &&
        (!options.Curation.HasValue || formula.Metadata.Curadoria == options.Curation) &&
        (string.IsNullOrWhiteSpace(options.Unit) ||
         formula.UnidadeResultado.Contains(options.Unit, StringComparison.OrdinalIgnoreCase) ||
         formula.Variaveis.Any(variable => variable.Unidade.Contains(options.Unit, StringComparison.OrdinalIgnoreCase))) &&
        (string.IsNullOrWhiteSpace(options.Creator) || formula.Criador.Contains(options.Creator, StringComparison.OrdinalIgnoreCase));

    public static string Normalize(string value)
    {
        var decomposed = (value ?? "").Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder(decomposed.Length);
        foreach (var character in decomposed)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                builder.Append(char.ToLowerInvariant(character));
        }
        return builder.ToString().Normalize(NormalizationForm.FormC).Trim();
    }

    private static double Similarity(string a, string b)
    {
        if (a == b) return 1;
        if (a.Length == 0 || b.Length == 0) return 0;
        var previous = Enumerable.Range(0, b.Length + 1).ToArray();
        var current = new int[b.Length + 1];
        for (var i = 1; i <= a.Length; i++)
        {
            current[0] = i;
            for (var j = 1; j <= b.Length; j++)
                current[j] = Math.Min(Math.Min(current[j - 1] + 1, previous[j] + 1),
                    previous[j - 1] + (a[i - 1] == b[j - 1] ? 0 : 1));
            (previous, current) = (current, previous);
        }
        return 1d - (double)previous[b.Length] / Math.Max(a.Length, b.Length);
    }
}
