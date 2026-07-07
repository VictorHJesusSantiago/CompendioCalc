using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Json;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public sealed class OfflineExportService
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public string FormulaToJson(Formula formula) => JsonSerializer.Serialize(ToPortable(formula), JsonOptions);

    public string FormulaToMarkdown(Formula formula)
    {
        var builder = new StringBuilder()
            .Append("# ").AppendLine(formula.Nome).AppendLine()
            .Append("**Expressão:** `").Append(formula.Expressao).AppendLine("`  ")
            .Append("**Categoria:** ").Append(formula.Categoria).Append(" / ").AppendLine(formula.SubCategoria)
            .Append("**Criador:** ").Append(formula.Criador).Append(" (").Append(formula.AnoOrigin).AppendLine(")")
            .AppendLine().AppendLine(formula.Descricao).AppendLine()
            .AppendLine("## Variáveis").AppendLine()
            .AppendLine("| Símbolo | Nome | Unidade | Padrão |").AppendLine("|---|---|---:|---:|");
        foreach (var variable in formula.Variaveis)
            builder.Append('|').Append(variable.Simbolo).Append('|').Append(variable.Nome).Append('|')
                .Append(variable.Unidade).Append('|').Append(variable.ValorPadrao.ToString("G17", CultureInfo.InvariantCulture))
                .AppendLine("|");
        if (!string.IsNullOrWhiteSpace(formula.ReferenciaBibliografica))
            builder.AppendLine().Append("## Referência").AppendLine().AppendLine(formula.ReferenciaBibliografica);
        return builder.ToString();
    }

    public string FormulaToHtml(Formula formula)
    {
        static string H(string value) => WebUtility.HtmlEncode(value);
        var rows = string.Join("", formula.Variaveis.Select(variable =>
            $"<tr><td>{H(variable.Simbolo)}</td><td>{H(variable.Nome)}</td><td>{H(variable.Unidade)}</td><td>{variable.ValorPadrao.ToString("G17", CultureInfo.InvariantCulture)}</td></tr>"));
        return "<!doctype html><html lang=\"pt-BR\"><meta charset=\"utf-8\"><title>" + H(formula.Nome) +
               "</title><style>body{font:16px system-ui;max-width:900px;margin:auto;padding:2rem}table{border-collapse:collapse}td,th{border:1px solid #888;padding:.5rem}.expr{font-size:1.4rem}</style>" +
               $"<h1>{H(formula.Nome)}</h1><p class=\"expr\">{H(formula.ExprTexto.Length > 0 ? formula.ExprTexto : formula.Expressao)}</p>" +
               $"<p>{H(formula.Descricao)}</p><table><thead><tr><th>Símbolo</th><th>Nome</th><th>Unidade</th><th>Padrão</th></tr></thead><tbody>{rows}</tbody></table>" +
               $"<h2>Referência</h2><p>{H(formula.ReferenciaBibliografica)}</p></html>";
    }

    public string HistoryToCsv(IEnumerable<HistoricoItem> history)
    {
        static string Csv(string value) => "\"" + (value ?? "").Replace("\"", "\"\"") + "\"";
        var builder = new StringBuilder("id,data,formula,categoria,resultado,unidade,projeto,nota,tags\n");
        foreach (var item in history)
            builder.Append(Csv(item.Id)).Append(',').Append(Csv(item.Timestamp.ToString("O"))).Append(',')
                .Append(Csv(item.FormulaNome)).Append(',').Append(Csv(item.Categoria)).Append(',')
                .Append(item.Resultado.ToString("G17", CultureInfo.InvariantCulture)).Append(',')
                .Append(Csv(item.UnidadeResultado)).Append(',').Append(Csv(item.Project)).Append(',')
                .Append(Csv(item.Note)).Append(',').Append(Csv(string.Join(';', item.Tags))).AppendLine();
        return builder.ToString();
    }

    public string FormulaToLatex(Formula formula) =>
        $"\\section*{{{EscapeLatex(formula.Nome)}}}\n\\[\n{formula.Expressao}\n\\]\n{EscapeLatex(formula.Descricao)}";

    public string FormulaToSvg(Formula formula)
    {
        var text = WebUtility.HtmlEncode(formula.ExprTexto.Length > 0 ? formula.ExprTexto : formula.Expressao);
        var width = Math.Clamp(text.Length * 12 + 40, 320, 2400);
        return $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"100\" viewBox=\"0 0 {width} 100\">" +
               "<rect width=\"100%\" height=\"100%\" fill=\"transparent\"/><text x=\"20\" y=\"60\" font-family=\"serif\" font-size=\"30\" fill=\"currentColor\">" +
               text + "</text></svg>";
    }

    private static object ToPortable(Formula formula) => new
    {
        schemaVersion = 1, formula.Id, formula.CodigoCompendio, formula.Nome, formula.Categoria,
        formula.SubCategoria, formula.Expressao, formula.ExprTexto, formula.Descricao, formula.Criador,
        formula.AnoOrigin, formula.Procedencia, formula.ReferenciaBibliografica, formula.Referencias,
        formula.ExemploPratico, formula.ExemplosResolvidos, formula.Unidades, formula.Variaveis,
        formula.VariavelResultado, formula.UnidadeResultado, formula.Metadata, formula.NomesAlternativos,
        formula.PalavrasChave, formula.CondicoesValidade, formula.Singularidades, formula.AvisosSeguranca
    };

    private static string EscapeLatex(string value) => value
        .Replace("\\", "\\textbackslash{}").Replace("&", "\\&").Replace("%", "\\%")
        .Replace("$", "\\$").Replace("#", "\\#").Replace("_", "\\_")
        .Replace("{", "\\{").Replace("}", "\\}");
}
