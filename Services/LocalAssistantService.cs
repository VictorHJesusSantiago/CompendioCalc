using System.Text;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

/// <summary>
/// Assistente offline por recuperação e regras. Não se apresenta como LLM:
/// cada resposta é montada apenas com registros locais e inclui as fontes.
/// </summary>
public sealed class LocalAssistantService
{
    private readonly AdvancedSearchService _search;
    private readonly FormulaService _formulas;

    public LocalAssistantService(AdvancedSearchService search, FormulaService formulas)
    {
        _search = search;
        _formulas = formulas;
    }

    public AssistantAnswer Ask(string question, int maxCitations = 5)
    {
        if (string.IsNullOrWhiteSpace(question))
            return new("Digite um problema ou conceito para pesquisar no compêndio.", [], [],
                "recuperação-local-v1");
        var hits = _search.Search(question, new SearchOptions(Limit: Math.Clamp(maxCitations, 1, 10)));
        if (hits.Count == 0)
            return new("Não encontrei uma fórmula local suficientemente relacionada. Tente incluir grandezas, área ou unidade.", [],
                ["Abrir busca avançada", "Consultar o glossário local"], "recuperação-local-v1");

        var best = hits[0].Formula;
        var builder = new StringBuilder()
            .Append("A fórmula local mais relacionada é ").Append(best.Nome).Append(": ")
            .Append(best.ExprTexto.Length > 0 ? best.ExprTexto : best.Expressao).Append(". ");
        if (!string.IsNullOrWhiteSpace(best.Descricao)) builder.Append(best.Descricao).Append(' ');
        if (best.CondicoesValidade.Count > 0)
            builder.Append("Condições: ").Append(string.Join("; ", best.CondicoesValidade)).Append(". ");
        if (best.AvisosSeguranca.Count > 0)
            builder.Append("Avisos: ").Append(string.Join("; ", best.AvisosSeguranca)).Append(". ");
        builder.Append("Confira unidades e hipóteses antes de calcular.");

        var citations = hits.Select(hit => hit.Formula).DistinctBy(formula => formula.Id).Take(maxCitations)
            .Select(formula => new AssistantCitation(formula.Id, formula.Nome,
                formula.ExprTexto.Length > 0 ? formula.ExprTexto : formula.Expressao,
                formula.ReferenciaBibliografica)).ToArray();
        return new(builder.ToString(), citations,
            [$"Abrir {best.Nome}", $"Calcular {best.VariavelResultado}", "Comparar fórmulas relacionadas"],
            "recuperação-local-v1", best.Metadata.PontuacaoConfiabilidade < 50);
    }

    public FormulaComparison Compare(string firstId, string secondId)
    {
        var first = _formulas.ObterPorId(firstId) ?? throw new KeyNotFoundException(firstId);
        var second = _formulas.ObterPorId(secondId) ?? throw new KeyNotFoundException(secondId);
        var firstSymbols = first.Variaveis.Select(variable => variable.Simbolo).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var secondSymbols = second.Variaveis.Select(variable => variable.Simbolo).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var similarities = new List<string>();
        var differences = new List<string>();
        var warnings = new List<string>();
        if (first.Categoria.Equals(second.Categoria, StringComparison.OrdinalIgnoreCase))
            similarities.Add($"Ambas pertencem a {first.Categoria}.");
        var shared = firstSymbols.Intersect(secondSymbols, StringComparer.OrdinalIgnoreCase).ToArray();
        if (shared.Length > 0) similarities.Add($"Variáveis em comum: {string.Join(", ", shared)}.");
        differences.Add($"Resultados: {first.VariavelResultado} ({first.UnidadeResultado}) versus {second.VariavelResultado} ({second.UnidadeResultado}).");
        var onlyFirst = firstSymbols.Except(secondSymbols, StringComparer.OrdinalIgnoreCase).ToArray();
        var onlySecond = secondSymbols.Except(firstSymbols, StringComparer.OrdinalIgnoreCase).ToArray();
        if (onlyFirst.Length > 0) differences.Add($"Somente em {first.Nome}: {string.Join(", ", onlyFirst)}.");
        if (onlySecond.Length > 0) differences.Add($"Somente em {second.Nome}: {string.Join(", ", onlySecond)}.");
        warnings.AddRange(first.AvisosSeguranca.Select(warning => $"{first.Nome}: {warning}"));
        warnings.AddRange(second.AvisosSeguranca.Select(warning => $"{second.Nome}: {warning}"));
        return new($"Comparação local entre {first.Nome} e {second.Nome}.", similarities, differences, warnings);
    }

    public AssistantAnswer Explain(string formulaId, bool simplified)
    {
        var formula = _formulas.ObterPorId(formulaId) ?? throw new KeyNotFoundException(formulaId);
        var variables = string.Join("; ", formula.Variaveis.Select(variable =>
            $"{variable.Simbolo} significa {variable.Nome}" +
            (string.IsNullOrWhiteSpace(variable.Unidade) ? "" : $" em {variable.Unidade}")));
        var text = simplified
            ? $"{formula.Nome} relaciona {variables}. O resultado é {formula.VariavelResultado}" +
              (string.IsNullOrWhiteSpace(formula.UnidadeResultado) ? "." : $" em {formula.UnidadeResultado}.")
            : $"{formula.Descricao} Expressão: {formula.Expressao}. Variáveis: {variables}. " +
              $"Domínio: {formula.Metadata.DominioMatematico}.";
        return new(text,
            [new(formula.Id, formula.Nome, formula.Expressao, formula.ReferenciaBibliografica)],
            ["Abrir calculadora", "Gerar exercício", "Ver origem"], "recuperação-local-v1");
    }
}
