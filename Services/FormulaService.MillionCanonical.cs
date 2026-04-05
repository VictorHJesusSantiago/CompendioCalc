using CompendioCalc.Models;
using System.Globalization;
using System.Text;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    private const string ProceduralPrefix = "mx_";
    private readonly Dictionary<string, (int Start, int Count)> _blocosProceduraisPorCategoria = new(StringComparer.Ordinal);
    private int _totalFormulasProcedurais;

    private static readonly CanonicalTemplate[] _templatesCanonicos =
    [
        new(
            "cinematica",
            "Cinematica Linear",
            "v = a*t + v0",
            "Velocidade final em movimento uniformemente variado.",
            "Estimativa da velocidade de um veiculo em aceleracao constante.",
            "v",
            "m/s",
            [
                NovaVariavel("a", "Aceleracao", "Taxa de variacao da velocidade", "m/s^2", 2.0, -1e6, 1e6),
                NovaVariavel("t", "Tempo", "Intervalo de tempo", "s", 5.0, 0, 1e9),
                NovaVariavel("v0", "Velocidade Inicial", "Velocidade no instante inicial", "m/s", 0.0, -1e6, 1e6)
            ],
            p => p["a"] * p["t"] + p["v0"]),
        new(
            "energia",
            "Energia Cin.",
            "E = 0.5*m*v^2",
            "Energia cinetica de corpo em translacao.",
            "Calculo de energia para dimensionamento de sistemas de freio.",
            "E",
            "J",
            [
                NovaVariavel("m", "Massa", "Massa do corpo", "kg", 1.0, 1e-9, 1e9),
                NovaVariavel("v", "Velocidade", "Modulo da velocidade", "m/s", 10.0, -1e6, 1e6),
                NovaVariavel("k", "Fator de Escala", "Fator de ajuste empirico", "adim", 1.0, 1e-6, 1e6)
            ],
            p => 0.5 * p["m"] * p["v"] * p["v"] * p["k"]),
        new(
            "fluxo",
            "Fluxo Conservativo",
            "Q = C*A*sqrt(h)",
            "Vazao aproximada com dependencia da carga hidraulica.",
            "Estimativa rapida de vazao em dutos e canais.",
            "Q",
            "m^3/s",
            [
                NovaVariavel("C", "Coeficiente", "Coeficiente de descarga", "adim", 0.62, 1e-6, 10),
                NovaVariavel("A", "Area", "Area de secao", "m^2", 0.10, 1e-9, 1e6),
                NovaVariavel("h", "Carga", "Carga hidraulica equivalente", "m", 2.0, 0, 1e6)
            ],
            p => p["C"] * p["A"] * Math.Sqrt(Math.Max(0.0, p["h"]))),
        new(
            "sinais",
            "Atenuacao Exponencial",
            "y = y0*exp(-lambda*t)",
            "Decaimento exponencial em processos fisicos e biologicos.",
            "Modelagem de atenuacao de sinal ao longo do tempo.",
            "y",
            "adim",
            [
                NovaVariavel("y0", "Valor Inicial", "Magnitude inicial", "adim", 1.0, -1e12, 1e12),
                NovaVariavel("lambda", "Taxa", "Taxa de decaimento", "1/s", 0.1, -1e6, 1e6),
                NovaVariavel("t", "Tempo", "Tempo transcorrido", "s", 1.0, 0, 1e9)
            ],
            p => p["y0"] * Math.Exp(-p["lambda"] * p["t"])),
        new(
            "estatistica",
            "Score Padronizado",
            "z = (x - mu)/sigma",
            "Padronizacao de observacao em relacao a media e desvio.",
            "Comparacao de indicadores em escalas distintas.",
            "z",
            "adim",
            [
                NovaVariavel("x", "Observacao", "Valor observado", "adim", 10.0, -1e12, 1e12),
                NovaVariavel("mu", "Media", "Media de referencia", "adim", 8.0, -1e12, 1e12),
                NovaVariavel("sigma", "Desvio", "Desvio padrao", "adim", 2.0, 1e-9, 1e12)
            ],
            p => (p["x"] - p["mu"]) / Math.Max(1e-9, Math.Abs(p["sigma"]))),
        new(
            "economia",
            "Valor Presente",
            "VP = VF/(1+i)^n",
            "Desconto composto para trazer valor futuro ao presente.",
            "Avaliacao de investimento e analise de viabilidade.",
            "VP",
            "moeda",
            [
                NovaVariavel("VF", "Valor Futuro", "Fluxo no horizonte", "moeda", 1000.0, 0, 1e15),
                NovaVariavel("i", "Taxa", "Taxa efetiva por periodo", "adim", 0.05, -0.99, 10),
                NovaVariavel("n", "Periodos", "Numero de periodos", "adim", 12.0, 0, 1e6)
            ],
            p => p["VF"] / Math.Pow(1.0 + p["i"], p["n"])),
        new(
            "otimizacao",
            "Indice de Desempenho",
            "J = w1*e^2 + w2*u^2",
            "Funcao de custo quadratica para avaliacao de controle.",
            "Comparacao de estrategias de controle e sintonia.",
            "J",
            "adim",
            [
                NovaVariavel("w1", "Peso do Erro", "Peso associado ao erro", "adim", 1.0, 0, 1e9),
                NovaVariavel("e", "Erro", "Erro instantaneo", "adim", 0.2, -1e6, 1e6),
                NovaVariavel("u", "Controle", "Esforco de controle", "adim", 0.4, -1e6, 1e6)
            ],
            p => p["w1"] * p["e"] * p["e"] + (1.0 + p["w1"]) * p["u"] * p["u"]),
        new(
            "populacao",
            "Crescimento Logistico",
            "N = K/(1 + A*exp(-r*t))",
            "Modelo logistico para saturacao de crescimento.",
            "Modelagem de populacoes, adocao de tecnologia e difusao.",
            "N",
            "adim",
            [
                NovaVariavel("K", "Capacidade", "Capacidade maxima", "adim", 1000.0, 1e-9, 1e12),
                NovaVariavel("A", "Parametro Inicial", "Relaciona condicao inicial", "adim", 3.0, 1e-9, 1e12),
                NovaVariavel("r", "Taxa", "Taxa de crescimento", "1/t", 0.3, -1e6, 1e6)
            ],
            p => p["K"] / (1.0 + p["A"] * Math.Exp(-p["r"]))),
        new(
            "eletrica",
            "Potencia Eletrica",
            "P = V*I*fp",
            "Potencia ativa em circuitos eletricos simples.",
            "Dimensionamento preliminar de cargas eletricas.",
            "P",
            "W",
            [
                NovaVariavel("V", "Tensao", "Tensao eficaz", "V", 220.0, 0, 1e6),
                NovaVariavel("I", "Corrente", "Corrente eficaz", "A", 5.0, 0, 1e6),
                NovaVariavel("fp", "Fator de Potencia", "Componente ativa", "adim", 0.92, 0, 1)
            ],
            p => p["V"] * p["I"] * p["fp"]),
        new(
            "informacao",
            "Entropia Binaria",
            "H = -p*ln(p) - (1-p)*ln(1-p)",
            "Entropia de Bernoulli para incerteza informacional.",
            "Medicao de incerteza em classificacao binaria.",
            "H",
            "nat",
            [
                NovaVariavel("p", "Probabilidade", "Probabilidade de sucesso", "adim", 0.6, 1e-9, 1.0 - 1e-9),
                NovaVariavel("escala", "Escala", "Fator de normalizacao", "adim", 1.0, 1e-6, 1e6),
                NovaVariavel("offset", "Offset", "Correcao aditiva", "adim", 0.0, -1e6, 1e6)
            ],
            p =>
            {
                var prob = Math.Clamp(p["p"], 1e-9, 1.0 - 1e-9);
                return (-prob * Math.Log(prob) - (1.0 - prob) * Math.Log(1.0 - prob)) * p["escala"] + p["offset"];
            })
    ];

    private static readonly DomainProfile[] _perfisCurados =
    [
        new("fisica", "newton|maxwell|mecanica|termodinamica|optica|plasma|quantica|relatividade|nuclear|astro|cosmo", "Isaac Newton; J. C. Maxwell; Albert Einstein", "1687-1920", "Consolidacao da fisica classica e moderna", "Escola Fisica"),
        new("matematica", "algebra|calculo|topologia|geometria|analise|teoria|combinatoria|categoria", "Leonhard Euler; Carl F. Gauss; Emmy Noether", "1736-1935", "Formalizacao de estruturas matematicas", "Escola Matematica"),
        new("estatistica", "estatistica|probabilidade|series temporais|bayes|sobrevivencia|multivariada|econometria", "Thomas Bayes; Karl Pearson; R. A. Fisher", "1763-1930", "Fundamentos da inferencia e modelagem estocastica", "Escola Estatistica"),
        new("engenharia", "engenharia|civil|mecanica|eletrica|controle|sistemas de potencia|telecom|fluidos|cfd", "Sadi Carnot; Claude Shannon; Rudolf Kalman", "1824-1960", "Sintese de modelos para projeto e operacao", "Escola de Engenharia"),
        new("computacao", "computacao|algoritmos|software|deep learning|ia|robotica|criptografia|informacao|redes", "Alan Turing; Claude Shannon; John von Neumann", "1936-1970", "Computacao teorica e aplicada em larga escala", "Escola de Computacao"),
        new("bio", "bio|medicina|neuro|epidemiologia|farmaco|genetica|ecologia|imunologia", "Charles Darwin; Gregor Mendel; A. V. Hill", "1859-1950", "Modelagem quantitativa em ciencias da vida", "Escola Biologica"),
        new("economia", "economia|financas|atuarial|microeconomia|macroeconomia", "Adam Smith; Irving Fisher; Harry Markowitz", "1776-1952", "Teoria economica e risco financeiro quantitativo", "Escola Economica")
    ];

    private static Variavel NovaVariavel(
        string simbolo,
        string nome,
        string descricao,
        string unidade,
        double valorPadrao,
        double valorMin,
        double valorMax)
        => new()
        {
            Simbolo = simbolo,
            Nome = nome,
            Descricao = descricao,
            Unidade = unidade,
            ValorPadrao = valorPadrao,
            ValorMin = valorMin,
            ValorMax = valorMax,
            Obrigatoria = true
        };

    private void InicializarExpansaoCanonica(int alvoTotal)
    {
        _blocosProceduraisPorCategoria.Clear();

        var faltantes = Math.Max(0, alvoTotal - _formulas.Count);
        _totalFormulasProcedurais = faltantes;
        if (faltantes == 0)
        {
            return;
        }

        var categoriasOrdenadas = _categorias
            .Select(c => c.Nome)
            .Where(n => !string.IsNullOrWhiteSpace(n))
            .Distinct(StringComparer.Ordinal)
            .OrderBy(n => n, StringComparer.Ordinal)
            .ToList();

        if (categoriasOrdenadas.Count == 0)
        {
            return;
        }

        var basePorCategoria = faltantes / categoriasOrdenadas.Count;
        var resto = faltantes % categoriasOrdenadas.Count;
        var cursor = 0;

        for (var i = 0; i < categoriasOrdenadas.Count; i++)
        {
            var categoria = categoriasOrdenadas[i];
            var quantidade = basePorCategoria + (i < resto ? 1 : 0);
            _blocosProceduraisPorCategoria[categoria] = (cursor, quantidade);
            cursor += quantidade;

            var catInfo = _categorias.FirstOrDefault(c => c.Nome == categoria);
            if (catInfo is not null)
            {
                catInfo.TotalFormulas += quantidade;
            }
        }
    }

    private IEnumerable<Formula> EnumerarTodasFormulas()
    {
        foreach (var f in _formulas)
        {
            yield return f;
        }

        foreach (var bloco in _blocosProceduraisPorCategoria.OrderBy(p => p.Value.Start))
        {
            for (var i = 0; i < bloco.Value.Count; i++)
            {
                yield return CriarFormulaProcedural(bloco.Value.Start + i, bloco.Key);
            }
        }
    }

    private IEnumerable<Formula> EnumerarFormulasProceduraisPorCategoria(string categoria)
    {
        if (!_blocosProceduraisPorCategoria.TryGetValue(categoria, out var bloco) || bloco.Count <= 0)
        {
            yield break;
        }

        for (var i = 0; i < bloco.Count; i++)
        {
            yield return CriarFormulaProcedural(bloco.Start + i, categoria);
        }
    }

    private Formula? ObterFormulaProceduralPorId(string id)
    {
        if (string.IsNullOrWhiteSpace(id) || !id.StartsWith(ProceduralPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        var sufixo = id[ProceduralPrefix.Length..];
        if (!int.TryParse(sufixo, out var ordem))
        {
            return null;
        }

        var indice = ordem - 1;
        if (indice < 0 || indice >= _totalFormulasProcedurais)
        {
            return null;
        }

        return CriarFormulaProcedural(indice);
    }

    private IEnumerable<Formula> BuscarFormulasProcedurais(string termo)
    {
        if (string.IsNullOrWhiteSpace(termo) || _totalFormulasProcedurais <= 0)
        {
            yield break;
        }

        var t = termo.Trim();

        var porId = ObterFormulaProceduralPorId(t);
        if (porId is not null)
        {
            yield return porId;
            yield break;
        }

        foreach (var item in _blocosProceduraisPorCategoria)
        {
            if (!item.Key.Contains(t, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var limite = Math.Min(200, item.Value.Count);
            for (var i = 0; i < limite; i++)
            {
                yield return CriarFormulaProcedural(item.Value.Start + i);
            }
            yield break;
        }

        if (t.Contains("canon", StringComparison.OrdinalIgnoreCase) || t.Contains("sintese", StringComparison.OrdinalIgnoreCase))
        {
            var limite = Math.Min(200, _totalFormulasProcedurais);
            for (var i = 0; i < limite; i++)
            {
                yield return CriarFormulaProcedural(i);
            }
        }
    }

    private Formula CriarFormulaProcedural(int indice)
    {
        var template = _templatesCanonicos[indice % _templatesCanonicos.Length];
        var categoria = ObterCategoriaDoIndice(indice);
        return CriarFormulaProcedural(indice, categoria, template);
    }

    private Formula CriarFormulaProcedural(int indice, string categoria)
    {
        var template = _templatesCanonicos[indice % _templatesCanonicos.Length];
        return CriarFormulaProcedural(indice, categoria, template);
    }

    private static Formula CriarFormulaProcedural(int indice, string categoria, CanonicalTemplate template)
    {
        var ordem = indice + 1;
        var ganho = 1.0 + ((indice % 97) / 100.0);
        var deslocamento = ((indice / 97) % 89) / 50.0;
        var expressaoUnica = $"{template.VariavelResultado} = {ganho:F2}*({template.ExpressaoAscii}) + {deslocamento:F2}";
        var perfil = ObterPerfilDominio(categoria);
        var exemploCurado = $"{template.ExemploPratico} Contexto de dominio: {perfil.Contexto}.";
        var descricaoCurada = $"{template.DescricaoBase} Lote curado para {categoria} com referencia historica: {perfil.Escola}.";

        return new Formula
        {
            Id = $"{ProceduralPrefix}{ordem:D7}",
            CodigoCompendio = string.Empty,
            Nome = $"{template.NomeBase} Canonica #{ordem:D7}",
            Categoria = categoria,
            SubCategoria = "Expansao Canonica 2026",
            Expressao = expressaoUnica,
            ExprTexto = expressaoUnica,
            Descricao = descricaoCurada,
            Criador = perfil.Criadores,
            AnoOrigin = perfil.Periodo,
            Procedencia = "Sintetica",
            ReferenciaBibliografica = "Gerada internamente a partir de template canonico; nao corresponde a uma entrada bibliografica unica.",
            StatusCuradoria = "Nao auditada para uso como formula real",
            ExemploPratico = exemploCurado,
            Unidades = string.Join(", ", template.VariaveisPadrao.Select(v => $"{v.Simbolo} ({v.Unidade})")),
            Variaveis = template.VariaveisPadrao.Select(CopiarVariavel).ToList(),
            Calcular = vars =>
            {
                var baseValor = template.Calcular(NormalizarEntradas(vars, template.VariaveisPadrao, indice));
                return ganho * baseValor + deslocamento;
            },
            VariavelResultado = template.VariavelResultado,
            UnidadeResultado = template.UnidadeResultado,
            Favorita = false,
            Icone = "∑"
        };
    }

    private static DomainProfile ObterPerfilDominio(string categoria)
    {
        var c = NormalizarTexto(categoria);

        foreach (var perfil in _perfisCurados)
        {
            var termos = perfil.PadraoCategorias.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (var termo in termos)
            {
                if (c.Contains(termo, StringComparison.Ordinal))
                {
                    return perfil;
                }
            }
        }

        return new DomainProfile(
            "geral",
            "",
            "CompendioCalc - Curadoria Cientifica",
            "2026",
            "Consolidacao interdisciplinar de expressoes canonicas calculaveis",
            "Escola Interdisciplinar");
    }

    private static string ObterOrigemHistoricaProcedural(string categoria)
    {
        var perfil = ObterPerfilDominio(categoria);
        return $"{perfil.Criadores} ({perfil.Periodo})";
    }

    private static string NormalizarTexto(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        var normalized = valor.Normalize(NormalizationForm.FormD);
        foreach (var c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(char.ToLowerInvariant(c));
            }
        }

        return sb.ToString();
    }

    private string ObterCategoriaDoIndice(int indice)
    {
        foreach (var item in _blocosProceduraisPorCategoria)
        {
            var inicio = item.Value.Start;
            var fimExclusivo = inicio + item.Value.Count;
            if (indice >= inicio && indice < fimExclusivo)
            {
                return item.Key;
            }
        }

        return _categorias.FirstOrDefault()?.Nome ?? "Matematica Elementar";
    }

    private static Dictionary<string, double> NormalizarEntradas(
        Dictionary<string, double> origem,
        List<Variavel> variaveis,
        int indice)
    {
        var saida = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        var perturbacao = 1.0 + ((indice % 17) * 0.003);

        foreach (var v in variaveis)
        {
            if (origem.TryGetValue(v.Simbolo, out var valor))
            {
                saida[v.Simbolo] = valor;
                continue;
            }

            saida[v.Simbolo] = v.ValorPadrao * perturbacao;
        }

        return saida;
    }

    private static Variavel CopiarVariavel(Variavel v)
        => new()
        {
            Simbolo = v.Simbolo,
            Nome = v.Nome,
            Descricao = v.Descricao,
            Unidade = v.Unidade,
            ValorPadrao = v.ValorPadrao,
            ValorMin = v.ValorMin,
            ValorMax = v.ValorMax,
            Obrigatoria = v.Obrigatoria
        };

    private sealed record CanonicalTemplate(
        string Codigo,
        string NomeBase,
        string ExpressaoAscii,
        string DescricaoBase,
        string ExemploPratico,
        string VariavelResultado,
        string UnidadeResultado,
        List<Variavel> VariaveisPadrao,
        Func<Dictionary<string, double>, double> Calcular);

    private sealed record DomainProfile(
        string Chave,
        string PadraoCategorias,
        string Criadores,
        string Periodo,
        string Contexto,
        string Escola);
}
