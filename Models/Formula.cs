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
    public FormulaMetadata Metadata { get; set; } = new();
    public List<ReferenciaBibliografica> Referencias { get; set; } = [];
    public List<ExemploResolvido> ExemplosResolvidos { get; set; } = [];
    public List<FormulaVersao> HistoricoVersoes { get; set; } = [];
    public List<string> NomesAlternativos { get; set; } = [];
    public List<string> SimbolosAlternativos { get; set; } = [];
    public List<string> PalavrasChave { get; set; } = [];
    public List<string> FormulasRelacionadas { get; set; } = [];
    public List<string> FormulasInversas { get; set; } = [];
    public List<string> PreRequisitos { get; set; } = [];
    public List<string> CondicoesValidade { get; set; } = [];
    public List<string> Singularidades { get; set; } = [];
    public List<string> Aproximacoes { get; set; } = [];
    public List<string> Limitacoes { get; set; } = [];
    public List<string> CasosParticulares { get; set; } = [];
    public List<string> CasosLimite { get; set; } = [];
    public List<string> ContraExemplos { get; set; } = [];
    public List<string> ErrosComuns { get; set; } = [];
    public List<string> AvisosSeguranca { get; set; } = [];
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

public enum NivelDificuldade
{
    NaoClassificado,
    Iniciante,
    Intermediario,
    Avancado,
    Especialista
}

public enum EstadoCuradoria
{
    Rascunho,
    EmRevisao,
    Aprovada,
    Rejeitada,
    Obsoleta
}

public sealed class FormulaMetadata
{
    public string Area { get; set; } = "";
    public string Disciplina { get; set; } = "";
    public string Topico { get; set; } = "";
    public string SubTopico { get; set; } = "";
    public string DominioMatematico { get; set; } = "";
    public string NotacaoHistorica { get; set; } = "";
    public Dictionary<string, string> ConvencoesRegionais { get; set; } = [];
    public NivelDificuldade Dificuldade { get; set; }
    public EstadoCuradoria Curadoria { get; set; } = EstadoCuradoria.Rascunho;
    public string Versao { get; set; } = "1.0.0";
    public DateTimeOffset UltimaRevisao { get; set; } = DateTimeOffset.UtcNow;
    public string ResponsavelCuradoria { get; set; } = "";
    public double PrecisaoEsperada { get; set; }
    public double MargemErroConhecida { get; set; }
    public double PontuacaoCompletude { get; set; }
    public double PontuacaoConfiabilidade { get; set; }
    public bool Obsoleta { get; set; }
    public string FormulaSubstitutaId { get; set; } = "";
}

public sealed class ReferenciaBibliografica
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Tipo { get; set; } = "secundaria";
    public string Titulo { get; set; } = "";
    public List<string> Autores { get; set; } = [];
    public string Obra { get; set; } = "";
    public string Edicao { get; set; } = "";
    public string Editora { get; set; } = "";
    public string Ano { get; set; } = "";
    public string Paginas { get; set; } = "";
    public string Capitulo { get; set; } = "";
    public string Doi { get; set; } = "";
    public string Isbn { get; set; } = "";
    public string Issn { get; set; } = "";
    public string Idioma { get; set; } = "pt-BR";
    public string NivelEvidencia { get; set; } = "";
    public string ArquivoLocal { get; set; } = "";
    public string HashSha256 { get; set; } = "";
    public string TrechoPermitido { get; set; } = "";
}

public sealed class ExemploResolvido
{
    public string Titulo { get; set; } = "";
    public string Enunciado { get; set; } = "";
    public Dictionary<string, double> Entradas { get; set; } = [];
    public List<string> Etapas { get; set; } = [];
    public double ResultadoEsperado { get; set; }
    public string UnidadeResultado { get; set; } = "";
    public double Tolerancia { get; set; } = 1e-9;
}

public sealed class FormulaVersao
{
    public string Versao { get; set; } = "";
    public DateTimeOffset Data { get; set; } = DateTimeOffset.UtcNow;
    public string Responsavel { get; set; } = "";
    public string Motivo { get; set; } = "";
    public string Expressao { get; set; } = "";
    public string HashConteudo { get; set; } = "";
}
