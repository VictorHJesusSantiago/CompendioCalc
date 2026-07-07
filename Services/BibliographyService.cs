using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public enum CitationStyle { Abnt, Apa, Vancouver, Ieee }

public sealed class BibliographyService
{
    private static readonly Regex DoiPattern =
        new(@"^10\.\d{4,9}/[-._;()/:A-Z0-9]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public bool ValidateDoi(string doi) =>
        DoiPattern.IsMatch(doi.Trim().Replace("https://doi.org/", "", StringComparison.OrdinalIgnoreCase));

    public bool ValidateIsbn(string isbn)
    {
        var digits = Regex.Replace(isbn, "[^0-9Xx]", "");
        if (digits.Length == 10)
        {
            var sum = 0;
            for (var i = 0; i < 10; i++)
            {
                var value = i == 9 && char.ToUpperInvariant(digits[i]) == 'X' ? 10 : digits[i] - '0';
                if (value is < 0 or > 10) return false;
                sum += (10 - i) * value;
            }
            return sum % 11 == 0;
        }
        if (digits.Length == 13 && digits.All(char.IsDigit))
        {
            var sum = digits.Take(12).Select((c, i) => (c - '0') * (i % 2 == 0 ? 1 : 3)).Sum();
            return (10 - sum % 10) % 10 == digits[12] - '0';
        }
        return false;
    }

    public bool ValidateIssn(string issn)
    {
        var digits = Regex.Replace(issn, "[^0-9Xx]", "");
        if (digits.Length != 8) return false;
        var sum = 0;
        for (var i = 0; i < 8; i++)
        {
            var value = i == 7 && char.ToUpperInvariant(digits[i]) == 'X' ? 10 : digits[i] - '0';
            if (value is < 0 or > 10) return false;
            sum += value * (8 - i);
        }
        return sum % 11 == 0;
    }

    public string Format(ReferenciaBibliografica reference, CitationStyle style)
    {
        var authors = reference.Autores.Count == 0 ? "AUTORIA DESCONHECIDA" : string.Join("; ", reference.Autores);
        return style switch
        {
            CitationStyle.Abnt =>
                $"{authors.ToUpperInvariant()}. {reference.Titulo}. {reference.Edicao} {reference.Editora}, {reference.Ano}. {Identifier(reference)}".Trim(),
            CitationStyle.Apa =>
                $"{string.Join(", ", reference.Autores)} ({reference.Ano}). {reference.Titulo}. {reference.Editora}. {Identifier(reference)}".Trim(),
            CitationStyle.Vancouver =>
                $"{string.Join(", ", reference.Autores)}. {reference.Titulo}. {reference.Editora}; {reference.Ano}. {Identifier(reference)}".Trim(),
            CitationStyle.Ieee =>
                $"{string.Join(", ", reference.Autores)}, “{reference.Titulo},” {reference.Editora}, {reference.Ano}. {Identifier(reference)}".Trim(),
            _ => throw new ArgumentOutOfRangeException(nameof(style))
        };
    }

    public string ExportBibTex(ReferenciaBibliografica reference)
    {
        var key = Slug((reference.Autores.FirstOrDefault() ?? "anon") + reference.Ano);
        var type = reference.Tipo.Equals("primaria", StringComparison.OrdinalIgnoreCase) ? "article" : "book";
        return $"@{type}{{{key},\n  title = {{{reference.Titulo}}},\n  author = {{{string.Join(" and ", reference.Autores)}}},\n" +
               $"  year = {{{reference.Ano}}},\n  publisher = {{{reference.Editora}}},\n  doi = {{{reference.Doi}}},\n" +
               $"  isbn = {{{reference.Isbn}}}\n}}";
    }

    public string ExportRis(ReferenciaBibliografica reference)
    {
        var builder = new StringBuilder("TY  - ").AppendLine(reference.Tipo == "primaria" ? "JOUR" : "BOOK");
        foreach (var author in reference.Autores) builder.Append("AU  - ").AppendLine(author);
        builder.Append("TI  - ").AppendLine(reference.Titulo)
            .Append("PY  - ").AppendLine(reference.Ano)
            .Append("PB  - ").AppendLine(reference.Editora);
        if (!string.IsNullOrWhiteSpace(reference.Doi)) builder.Append("DO  - ").AppendLine(reference.Doi);
        if (!string.IsNullOrWhiteSpace(reference.Isbn)) builder.Append("SN  - ").AppendLine(reference.Isbn);
        return builder.AppendLine("ER  -").ToString();
    }

    public string ComputeFileHash(string path)
    {
        using var stream = File.OpenRead(path);
        return Convert.ToHexString(SHA256.HashData(stream)).ToLowerInvariant();
    }

    public IReadOnlyList<IGrouping<string, ReferenciaBibliografica>> FindDuplicates(
        IEnumerable<ReferenciaBibliografica> references) =>
        references.GroupBy(reference =>
                !string.IsNullOrWhiteSpace(reference.Doi)
                    ? "doi:" + reference.Doi.Trim().ToLowerInvariant()
                    : Slug(reference.Titulo + string.Join("", reference.Autores) + reference.Ano))
            .Where(group => group.Count() > 1)
            .ToArray();

    private static string Identifier(ReferenciaBibliografica reference) =>
        !string.IsNullOrWhiteSpace(reference.Doi) ? $"doi:{reference.Doi}" :
        !string.IsNullOrWhiteSpace(reference.Isbn) ? $"ISBN {reference.Isbn}" : "";

    private static string Slug(string value) =>
        Regex.Replace(value.Normalize(NormalizationForm.FormD), @"[^A-Za-z0-9]+", "").ToLowerInvariant();
}
