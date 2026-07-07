using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CompendioCalc.Services;

public sealed record RecognitionResult(
    string Original,
    string Normalized,
    IReadOnlyList<string> Corrections,
    double Confidence,
    bool RequiresReview);

public sealed record RecognizedTable(
    IReadOnlyList<string> Headers,
    IReadOnlyList<IReadOnlyList<string>> Rows,
    char Separator);

/// <summary>
/// Pós-processador local de texto vindo de OCR, câmera ou colagem. O serviço
/// não afirma reconhecer pixels sem um modelo instalado; normaliza e valida a
/// saída de qualquer mecanismo OCR local.
/// </summary>
public sealed class MathematicalRecognitionService
{
    private static readonly (Regex Pattern, string Replacement, string Reason)[] Rules =
    [
        (new(@"\b[Ss][Qq][Rr][Tt]\s*\(", RegexOptions.Compiled), "sqrt(", "Normalizar raiz quadrada"),
        (new(@"(?<=\d)[xX×](?=\d|\()", RegexOptions.Compiled), "*", "Normalizar multiplicação"),
        (new(@"(?<=\d)[oO](?=\d)", RegexOptions.Compiled), "0", "Corrigir O confundido com zero"),
        (new(@"(?<=\d)[lI](?=\d)", RegexOptions.Compiled), "1", "Corrigir I/l confundido com um"),
        (new(@"[–—−]", RegexOptions.Compiled), "-", "Normalizar sinal de menos"),
        (new(@"[÷:](?=\s*\d)", RegexOptions.Compiled), "/", "Normalizar divisão"),
        (new(@"\s+", RegexOptions.Compiled), " ", "Normalizar espaços")
    ];

    public RecognitionResult NormalizeExpression(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return new(raw ?? "", "", [], 0, true);
        var value = raw.Trim();
        var corrections = new List<string>();
        foreach (var rule in Rules)
        {
            var updated = rule.Pattern.Replace(value, rule.Replacement);
            if (updated == value) continue;
            value = updated;
            corrections.Add(rule.Reason);
        }
        value = NormalizeSuperscripts(value, corrections);
        value = Regex.Replace(value, @"(?<=\d)\s+(?=[A-Za-z(])", "*");
        var balance = value.Count(character => character == '(') - value.Count(character => character == ')');
        if (balance > 0)
        {
            value += new string(')', balance);
            corrections.Add("Fechar parênteses ausentes");
        }
        var suspicious = value.Count(character => !(char.IsLetterOrDigit(character) ||
            char.IsWhiteSpace(character) || "+-*/^().,=_".Contains(character)));
        var confidence = Math.Clamp(1 - corrections.Count * .06 - suspicious * .1, 0, 1);
        return new(raw, value, corrections, confidence, confidence < .75 || suspicious > 0);
    }

    public RecognizedTable ParseTable(string text)
    {
        var lines = text.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (lines.Length == 0) throw new InvalidDataException("Tabela vazia.");
        var separators = new[] { ';', '\t', ',', '|' };
        var separator = separators.OrderByDescending(candidate => lines.Sum(line => line.Count(c => c == candidate))).First();
        if (!lines.Any(line => line.Contains(separator))) throw new InvalidDataException("Separador tabular não identificado.");
        var rows = lines.Select(line => ParseDelimitedLine(line, separator)).ToArray();
        var width = rows.Max(row => row.Count);
        if (rows.Any(row => row.Count != width)) throw new InvalidDataException("A tabela possui quantidades diferentes de colunas.");
        return new(rows[0], rows.Skip(1).Cast<IReadOnlyList<string>>().ToArray(), separator);
    }

    public IReadOnlyList<double> ExtractNumbers(string text)
    {
        var matches = Regex.Matches(text, @"[-+]?(?:\d+(?:[.,]\d+)?|[.,]\d+)(?:[eE][-+]?\d+)?");
        return matches.Select(match => double.Parse(match.Value.Replace(',', '.'),
            NumberStyles.Float, CultureInfo.InvariantCulture)).ToArray();
    }

    private static string NormalizeSuperscripts(string value, List<string> corrections)
    {
        const string superscripts = "⁰¹²³⁴⁵⁶⁷⁸⁹";
        var builder = new StringBuilder();
        var inExponent = false;
        foreach (var character in value)
        {
            var index = superscripts.IndexOf(character);
            if (index >= 0)
            {
                if (!inExponent) builder.Append('^');
                builder.Append(index);
                inExponent = true;
                continue;
            }
            inExponent = false;
            builder.Append(character);
        }
        var result = builder.ToString();
        if (result != value) corrections.Add("Converter expoentes Unicode");
        return result;
    }

    private static IReadOnlyList<string> ParseDelimitedLine(string line, char separator)
    {
        var cells = new List<string>();
        var current = new StringBuilder();
        var quoted = false;
        for (var i = 0; i < line.Length; i++)
        {
            var character = line[i];
            if (character == '"')
            {
                if (quoted && i + 1 < line.Length && line[i + 1] == '"') { current.Append('"'); i++; }
                else quoted = !quoted;
            }
            else if (character == separator && !quoted)
            {
                cells.Add(current.ToString().Trim());
                current.Clear();
            }
            else current.Append(character);
        }
        if (quoted) throw new InvalidDataException("Aspas não fechadas na tabela.");
        cells.Add(current.ToString().Trim());
        return cells;
    }
}
