using System.Text.RegularExpressions;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public sealed record CatalogIssue(
    string RuleId,
    string Severity,
    string FormulaId,
    string Message);

public sealed record CatalogHealthReport(
    int Total,
    int Valid,
    double Score,
    IReadOnlyDictionary<string, int> BySeverity,
    IReadOnlyList<CatalogIssue> Issues,
    IReadOnlyDictionary<string, int> CoverageByArea);

public sealed class CatalogHealthService
{
    public CatalogHealthReport Audit(IEnumerable<Formula> source)
    {
        var formulas = source.ToList();
        var issues = new List<CatalogIssue>();
        var ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var names = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var formula in formulas)
        {
            void Add(string rule, string severity, string message) =>
                issues.Add(new(rule, severity, formula.Id, message));

            if (string.IsNullOrWhiteSpace(formula.Id)) Add("CAT-ID-001", "critical", "ID ausente.");
            else if (!ids.Add(formula.Id)) Add("CAT-ID-002", "critical", "ID duplicado.");
            if (string.IsNullOrWhiteSpace(formula.Nome)) Add("CAT-META-001", "high", "Nome ausente.");
            else
            {
                var canonicalName = Canonical(formula.Nome);
                if (names.TryGetValue(canonicalName, out var other))
                    Add("CAT-DUP-001", "high", $"Nome equivalente ao registro {other}.");
                else names[canonicalName] = formula.Id;
            }
            if (string.IsNullOrWhiteSpace(formula.Categoria)) Add("CAT-META-002", "high", "Categoria ausente.");
            if (string.IsNullOrWhiteSpace(formula.Expressao)) Add("CAT-MATH-001", "critical", "Expressão ausente.");
            if (formula.Calcular is null) Add("CAT-MATH-002", "critical", "Cálculo executável ausente.");
            if (string.IsNullOrWhiteSpace(formula.ReferenciaBibliografica) && formula.Referencias.Count == 0)
                Add("CAT-REF-001", "high", "Referência bibliográfica ausente.");
            if (string.IsNullOrWhiteSpace(formula.ExemploPratico) && formula.ExemplosResolvidos.Count == 0)
                Add("CAT-EDU-001", "medium", "Exemplo ausente.");
            if (formula.Variaveis.Count == 0) Add("CAT-VAR-001", "high", "Nenhuma variável declarada.");

            var symbols = formula.Variaveis.Select(variable => variable.Simbolo)
                .Where(symbol => !string.IsNullOrWhiteSpace(symbol)).ToHashSet(StringComparer.OrdinalIgnoreCase);
            foreach (var variable in formula.Variaveis)
            {
                if (variable.ValorMin > variable.ValorMax)
                    Add("CAT-VAR-002", "critical", $"Limites invertidos em {variable.Simbolo}.");
                if (variable.ValorPadrao < variable.ValorMin || variable.ValorPadrao > variable.ValorMax)
                    Add("CAT-VAR-003", "high", $"Valor padrão fora dos limites em {variable.Simbolo}.");
                if (!Regex.IsMatch(formula.Expressao, $@"(?<![\p{{L}}\p{{N}}_]){Regex.Escape(variable.Simbolo)}(?![\p{{L}}\p{{N}}_])",
                        RegexOptions.IgnoreCase))
                    Add("CAT-VAR-004", "low", $"Variável {variable.Simbolo} pode não ser usada na expressão.");
            }

            if (formula.Calcular is not null)
            {
                try
                {
                    var inputs = formula.Variaveis.ToDictionary(v => v.Simbolo, v => v.ValorPadrao,
                        StringComparer.OrdinalIgnoreCase);
                    var result = formula.Calcular(inputs);
                    if (!double.IsFinite(result)) Add("CAT-MATH-003", "critical", "Valor padrão produz NaN ou infinito.");
                }
                catch (Exception ex)
                {
                    Add("CAT-MATH-004", "critical", $"Cálculo padrão falhou: {ex.GetType().Name}.");
                }
            }

            formula.Metadata.PontuacaoCompletude = CompletionScore(formula);
            formula.Metadata.PontuacaoConfiabilidade = ConfidenceScore(formula);
        }

        var affected = issues.Select(issue => issue.FormulaId).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var bySeverity = issues.GroupBy(issue => issue.Severity)
            .ToDictionary(group => group.Key, group => group.Count(), StringComparer.OrdinalIgnoreCase);
        var coverage = formulas.GroupBy(formula => string.IsNullOrWhiteSpace(formula.Metadata.Area)
                ? formula.Categoria : formula.Metadata.Area)
            .ToDictionary(group => group.Key, group => group.Count(), StringComparer.OrdinalIgnoreCase);
        var score = formulas.Count == 0 ? 100 :
            Math.Round(100d * Math.Max(0, formulas.Count - affected.Count) / formulas.Count, 2);
        return new(formulas.Count, formulas.Count - affected.Count, score, bySeverity, issues, coverage);
    }

    private static double CompletionScore(Formula formula)
    {
        var checks = new[]
        {
            !string.IsNullOrWhiteSpace(formula.Nome), !string.IsNullOrWhiteSpace(formula.Categoria),
            !string.IsNullOrWhiteSpace(formula.SubCategoria), !string.IsNullOrWhiteSpace(formula.Expressao),
            !string.IsNullOrWhiteSpace(formula.Descricao), !string.IsNullOrWhiteSpace(formula.Criador),
            !string.IsNullOrWhiteSpace(formula.AnoOrigin), formula.Variaveis.Count > 0, formula.Calcular is not null,
            !string.IsNullOrWhiteSpace(formula.ExemploPratico) || formula.ExemplosResolvidos.Count > 0,
            !string.IsNullOrWhiteSpace(formula.ReferenciaBibliografica) || formula.Referencias.Count > 0,
            formula.CondicoesValidade.Count > 0, formula.PalavrasChave.Count > 0
        };
        return Math.Round(100d * checks.Count(value => value) / checks.Length, 2);
    }

    private static double ConfidenceScore(Formula formula)
    {
        var score = 20d;
        if (formula.Calcular is not null) score += 25;
        if (formula.Referencias.Any(reference => reference.Tipo.Equals("primaria", StringComparison.OrdinalIgnoreCase))) score += 25;
        else if (!string.IsNullOrWhiteSpace(formula.ReferenciaBibliografica) || formula.Referencias.Count > 0) score += 15;
        if (formula.ExemplosResolvidos.Count > 0) score += 15;
        if (formula.CondicoesValidade.Count > 0) score += 10;
        if (formula.Metadata.Curadoria == EstadoCuradoria.Aprovada) score += 5;
        return Math.Min(100, score);
    }

    private static string Canonical(string value) =>
        Regex.Replace(value.ToLowerInvariant().Normalize(), @"[^\p{L}\p{N}]", "");
}
