namespace CompendioCalc.Models;

public enum CompendioStatus
{
    Ok,
    Faltante,
    Divergente,
}

public class CompendioIndiceItem
{
    public string Codigo { get; set; } = "";
    public string NomeEsperado { get; set; } = "";
}

public class CompendioRelatorioItem
{
    public string Codigo { get; set; } = "";
    public string NomeEsperado { get; set; } = "";
    public CompendioStatus Status { get; set; }
    public string Observacao { get; set; } = "";
    public List<string> FormulaIds { get; set; } = [];
    public List<string> FormulaNomes { get; set; } = [];
}

public class CompendioExtraItem
{
    public string FormulaId { get; set; } = "";
    public string FormulaNome { get; set; } = "";
    public string Categoria { get; set; } = "";
    public string CodigoCompendioAtual { get; set; } = "";
    public string Observacao { get; set; } = "";
}

public class CompendioRelatorio
{
    public DateTime GeradoEmUtc { get; set; } = DateTime.UtcNow;
    public int TotalIndices { get; set; }
    public int TotalOk { get; set; }
    public int TotalFaltante { get; set; }
    public int TotalDivergente { get; set; }
    public int TotalFormulasForaCompendioOficial { get; set; }
    public List<CompendioRelatorioItem> Itens { get; set; } = [];
    public List<CompendioExtraItem> FormulasForaCompendioOficial { get; set; } = [];
    public List<string> AlertasGerais { get; set; } = [];
}
