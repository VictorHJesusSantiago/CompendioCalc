namespace CompendioCalc.Models;

public sealed class FormulaCollection
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<string> FormulaIds { get; set; } = [];
    public List<string> Tags { get; set; } = [];
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public bool Pinned { get; set; }
}

public sealed class FormulaNote
{
    public string FormulaId { get; set; } = "";
    public string Text { get; set; } = "";
    public List<string> Tags { get; set; } = [];
    public bool Studied { get; set; }
    public bool ReviewLater { get; set; }
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public sealed class CalculationPreset
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string FormulaId { get; set; } = "";
    public string Name { get; set; } = "";
    public Dictionary<string, double> Values { get; set; } = [];
    public Dictionary<string, string> Units { get; set; } = [];
}

public sealed class SavedSearch
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "";
    public string Query { get; set; } = "";
    public Dictionary<string, string> Filters { get; set; } = [];
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public sealed class PersonalDataDocument
{
    public int SchemaVersion { get; set; } = 1;
    public List<FormulaCollection> Collections { get; set; } = [];
    public List<FormulaNote> Notes { get; set; } = [];
    public List<CalculationPreset> Presets { get; set; } = [];
    public List<SavedSearch> SavedSearches { get; set; } = [];
    public List<string> RecentFormulaIds { get; set; } = [];
}
