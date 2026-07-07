using System.Text.Json;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public sealed class EducationService
{
    private readonly object _gate = new();
    private List<FlashcardProgress> _progress = [];
    private string PathName => Path.Combine(FileSystem.AppDataDirectory, "education-progress.v1.json");

    public void Load()
    {
        lock (_gate)
        {
            _progress = File.Exists(PathName)
                ? JsonSerializer.Deserialize<List<FlashcardProgress>>(File.ReadAllText(PathName)) ?? []
                : [];
        }
    }

    public Exercise GenerateExercise(Formula formula, int seed)
    {
        if (formula.Calcular is null || formula.Variaveis.Count == 0)
            throw new InvalidOperationException("A fórmula não possui cálculo executável.");
        var random = new Random(seed);
        var inputs = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        foreach (var variable in formula.Variaveis)
        {
            var min = double.IsFinite(variable.ValorMin) ? variable.ValorMin : variable.ValorPadrao - Math.Max(10, Math.Abs(variable.ValorPadrao));
            var max = double.IsFinite(variable.ValorMax) ? variable.ValorMax : variable.ValorPadrao + Math.Max(10, Math.Abs(variable.ValorPadrao));
            if (max - min > Math.Max(1e6, Math.Abs(variable.ValorPadrao) * 100))
            {
                min = variable.ValorPadrao - Math.Max(10, Math.Abs(variable.ValorPadrao));
                max = variable.ValorPadrao + Math.Max(10, Math.Abs(variable.ValorPadrao));
            }
            var value = min == max ? min : min + random.NextDouble() * (max - min);
            inputs[variable.Simbolo] = Math.Round(value, 4);
        }
        var result = formula.Calcular(inputs);
        if (!double.IsFinite(result)) throw new ArithmeticException("O exercício gerado produziu resultado não finito.");
        return new()
        {
            FormulaId = formula.Id,
            Prompt = $"Usando {formula.Nome} ({formula.ExprTexto}), calcule {formula.VariavelResultado} para os valores fornecidos.",
            Inputs = inputs,
            ExpectedAnswer = result,
            Tolerance = Math.Max(1e-8, Math.Abs(result) * 1e-6),
            Unit = formula.UnidadeResultado,
            Hints =
            [
                $"Identifique as variáveis: {string.Join(", ", formula.Variaveis.Select(variable => variable.Simbolo))}.",
                "Substitua os valores mantendo unidades compatíveis.",
                "Respeite a precedência de operações."
            ],
            SolutionSteps =
            [
                $"Expressão: {formula.Expressao}",
                $"Substituição: {string.Join("; ", inputs.Select(item => $"{item.Key}={item.Value:G8}"))}",
                $"Resultado: {result:G15} {formula.UnidadeResultado}"
            ]
        };
    }

    public bool CheckAnswer(Exercise exercise, double answer) =>
        double.IsFinite(answer) && Math.Abs(answer - exercise.ExpectedAnswer) <= exercise.Tolerance;

    public IReadOnlyList<FlashcardProgress> Due(DateTimeOffset? now = null)
    {
        var instant = now ?? DateTimeOffset.UtcNow;
        lock (_gate) return _progress.Where(item => item.DueAt <= instant).OrderBy(item => item.DueAt).ToArray();
    }

    /// <summary>Atualiza repetição espaçada pelo algoritmo SM-2; quality vai de 0 a 5.</summary>
    public FlashcardProgress Review(string formulaId, int quality, DateTimeOffset? now = null)
    {
        if (quality is < 0 or > 5) throw new ArgumentOutOfRangeException(nameof(quality));
        var instant = now ?? DateTimeOffset.UtcNow;
        lock (_gate)
        {
            var item = _progress.FirstOrDefault(progress =>
                progress.FormulaId.Equals(formulaId, StringComparison.OrdinalIgnoreCase));
            if (item is null)
            {
                item = new() { FormulaId = formulaId };
                _progress.Add(item);
            }
            if (quality < 3)
            {
                item.Repetitions = 0;
                item.IntervalDays = 1;
            }
            else
            {
                item.IntervalDays = item.Repetitions switch
                {
                    0 => 1,
                    1 => 6,
                    _ => Math.Max(1, (int)Math.Round(item.IntervalDays * item.EaseFactor))
                };
                item.Repetitions++;
            }
            item.EaseFactor = Math.Max(1.3,
                item.EaseFactor + .1 - (5 - quality) * (.08 + (5 - quality) * .02));
            item.LastReviewAt = instant;
            item.DueAt = instant.AddDays(item.IntervalDays);
            SaveUnsafe();
            return item;
        }
    }

    private void SaveUnsafe()
    {
        var temporary = PathName + ".tmp";
        File.WriteAllText(temporary, JsonSerializer.Serialize(_progress, new JsonSerializerOptions { WriteIndented = true }));
        File.Move(temporary, PathName, true);
    }
}
