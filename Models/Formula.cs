namespace CompendioCalc.Models;

public class Formula
{
    public string Id { get; set; } = "";
    public string CodigoCompendio { get; set; } = ""; // Official compendium code: 001..387 (empty when formula is outside official index)
    public string Nome { get; set; } = "";
    public string Categoria { get; set; } = "";
    public string SubCategoria { get; set; } = "";
    public string Expressao { get; set; } = "";          // ASCII math
    public string ExprTexto { get; set; } = "";          // Rendered text version
    public string Descricao { get; set; } = "";
    public string Criador { get; set; } = "";
    public string AnoOrigin { get; set; } = "";
    public string Procedencia { get; set; } = "";
    public string ReferenciaBibliografica { get; set; } = "";
    public string FonteUrlOuDoi { get; set; } = "";
    public string StatusCuradoria { get; set; } = "";
    public string ExemploPratico { get; set; } = "";
    public string Unidades { get; set; } = "";
    public List<Variavel> Variaveis { get; set; } = [];
    public Func<Dictionary<string, double>, double>? Calcular { get; set; }
    public string VariavelResultado { get; set; } = "resultado";
    public string UnidadeResultado { get; set; } = "";
    public bool Favorita { get; set; } = false;
    public string Icone { get; set; } = "∑";
}

public class Variavel
{
    public string Simbolo { get; set; } = "";
    public string Nome { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Unidade { get; set; } = "";
    public double ValorPadrao { get; set; } = 0;
    public double ValorMin { get; set; } = double.NegativeInfinity;
    public double ValorMax { get; set; } = double.PositiveInfinity;
    public bool Obrigatoria { get; set; } = true;
}

public class CategoriaInfo
{
    public string Nome { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Icone { get; set; } = "";
    public string Cor { get; set; } = "";
    public int TotalFormulas { get; set; } = 0;
}
