namespace CompendioCalc.Models;

public sealed class Exercise
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string FormulaId { get; set; } = "";
    public string Prompt { get; set; } = "";
    public Dictionary<string, double> Inputs { get; set; } = [];
    public double ExpectedAnswer { get; set; }
    public double Tolerance { get; set; } = 1e-6;
    public List<string> Hints { get; set; } = [];
    public List<string> SolutionSteps { get; set; } = [];
    public string Unit { get; set; } = "";
}

public sealed class FlashcardProgress
{
    public string FormulaId { get; set; } = "";
    public int Repetitions { get; set; }
    public double EaseFactor { get; set; } = 2.5;
    public int IntervalDays { get; set; }
    public DateTimeOffset DueAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset LastReviewAt { get; set; }
}
