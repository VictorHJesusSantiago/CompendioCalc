namespace CompendioCalc.Models;

public sealed record AssistantCitation(
    string FormulaId,
    string FormulaName,
    string Expression,
    string Reference);

public sealed record AssistantAnswer(
    string Text,
    IReadOnlyList<AssistantCitation> Citations,
    IReadOnlyList<string> SuggestedActions,
    string Engine,
    bool RequiresHumanReview = false);

public sealed record FormulaComparison(
    string Summary,
    IReadOnlyList<string> Similarities,
    IReadOnlyList<string> Differences,
    IReadOnlyList<string> Warnings);
