using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // =============================================================
    // VOLUME 3 - IMPLEMENTACAO CALCULAVEL (COMPLETA POR SECAO)
    // =============================================================

    private static double NormCdf(double x)
    {
        // Aproximacao de Abramowitz-Stegun para Phi(x), sem dependencia de Math.Erf.
        double absX = Math.Abs(x);
        double t = 1.0 / (1.0 + 0.2316419 * absX);
        double d = 0.3989422804014327 * Math.Exp(-0.5 * absX * absX);
        double poly = t * (0.319381530 + t * (-0.356563782 + t * (1.781477937 + t * (-1.821255978 + t * 1.330274429))));
        double cdf = 1.0 - d * poly;
        return x >= 0 ? cdf : 1.0 - cdf;
    }

    // 1) Analise Funcional
    private void AdicionarAnaliseFuncionalCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_af01", CodigoCompendio = "090", Nome = "Norma lp (2D)", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Banach",
                Expressao = "||x||_p = (|x1|^p + |x2|^p)^(1/p)", ExprTexto = "Norma lp", Icone = "||",
                Descricao = "Norma lp em R2, base para espacos de Banach.", Criador = "Frigyes Riesz", AnoOrigin = "1910",
                ExemploPratico = "x=(3,4), p=2 => ||x||=5.",
                Variaveis = [ new() { Simbolo = "x1", Nome = "x1", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x2", Nome = "x2", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "p", Nome = "p", ValorPadrao = 2, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "||x||_p", Calcular = v => Math.Pow(Math.Pow(Math.Abs(v["x1"]), v["p"]) + Math.Pow(Math.Abs(v["x2"]), v["p"]), 1.0 / v["p"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_af02", CodigoCompendio = "091", Nome = "Norma sup", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Banach",
                Expressao = "||x||_inf = max(|x1|,|x2|)", ExprTexto = "Norma sup", Icone = "||",
                Descricao = "Norma infinito (supremo) em R2.", Criador = "Chebyshev", AnoOrigin = "1850",
                ExemploPratico = "x=(-2,5) => ||x||_inf=5.",
                Variaveis = [ new() { Simbolo = "x1", Nome = "x1", ValorPadrao = -2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x2", Nome = "x2", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "||x||_inf", Calcular = v => Math.Max(Math.Abs(v["x1"]), Math.Abs(v["x2"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_af03", CodigoCompendio = "092", Nome = "Holder (limite superior)", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Banach",
                Expressao = "|<f,g>| <= ||f||p ||g||q", ExprTexto = "Desigualdade de Holder", Icone = "||",
                Descricao = "Calcula o limite superior da desigualdade de Holder a partir das normas.", Criador = "Otto Holder", AnoOrigin = "1889",
                ExemploPratico = "||f||2=3, ||g||2=4 => limite 12.",
                Variaveis = [ new() { Simbolo = "nf", Nome = "||f||p", ValorPadrao = 3, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ng", Nome = "||g||q", ValorPadrao = 4, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Limite", Calcular = v => v["nf"] * v["ng"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ah01", CodigoCompendio = "093", Nome = "Norma induzida por produto interno", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Hilbert",
                Expressao = "||x|| = sqrt(<x,x>)", ExprTexto = "Norma de Hilbert", Icone = "<>",
                Descricao = "Norma induzida por produto interno.", Criador = "David Hilbert", AnoOrigin = "1904",
                ExemploPratico = "<x,x>=25 => ||x||=5.",
                Variaveis = [ new() { Simbolo = "xx", Nome = "<x,x>", ValorPadrao = 25, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "||x||", Calcular = v => Math.Sqrt(v["xx"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ah02", CodigoCompendio = "094", Nome = "Cauchy-Schwarz (limite)", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Hilbert",
                Expressao = "|<x,y>| <= ||x|| ||y||", ExprTexto = "Cauchy-Schwarz", Icone = "<>",
                Descricao = "Limite superior para o produto interno.", Criador = "Cauchy / Schwarz", AnoOrigin = "1821/1885",
                ExemploPratico = "||x||=2, ||y||=7 => |<x,y>| <= 14.",
                Variaveis = [ new() { Simbolo = "nx", Nome = "||x||", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ny", Nome = "||y||", ValorPadrao = 7, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Limite", Calcular = v => v["nx"] * v["ny"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_te01", CodigoCompendio = "095", Nome = "Norma Hilbert-Schmidt (2 vetores)", Categoria = "Vol3: Analise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "||T||_HS = sqrt(sum ||Te_i||^2)", ExprTexto = "Norma Hilbert-Schmidt", Icone = "sigma",
                Descricao = "Norma HS aproximada por duas imagens de base ortonormal.", Criador = "Hilbert / Schmidt", AnoOrigin = "1907",
                ExemploPratico = "||Te1||=3, ||Te2||=4 => ||T||HS=5.",
                Variaveis = [ new() { Simbolo = "te1", Nome = "||Te1||", ValorPadrao = 3, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "te2", Nome = "||Te2||", ValorPadrao = 4, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "||T||HS", Calcular = v => Math.Sqrt(v["te1"] * v["te1"] + v["te2"] * v["te2"]),
                Unidades = "",
            },
        ]);
    }

    // 2) Teoria da Medida
    private void AdicionarTeoriaMedidaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_tm01", CodigoCompendio = "096", Nome = "Medida de Lebesgue em intervalo", Categoria = "Vol3: Teoria da Medida", SubCategoria = "Medidas",
                Expressao = "m([a,b]) = b-a", ExprTexto = "Medida de Lebesgue", Icone = "mu",
                Descricao = "Comprimento de intervalo real.", Criador = "Henri Lebesgue", AnoOrigin = "1902",
                ExemploPratico = "[2,5] => medida 3.",
                Variaveis = [ new() { Simbolo = "a", Nome = "a", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b", Nome = "b", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "m", Calcular = v => v["b"] - v["a"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_il01", CodigoCompendio = "097", Nome = "Integral de funcao constante", Categoria = "Vol3: Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "int_a^b c dmu = c(b-a)", ExprTexto = "Integral de constante", Icone = "int",
                Descricao = "Caso base da integral de Lebesgue para funcao simples.", Criador = "Henri Lebesgue", AnoOrigin = "1902",
                ExemploPratico = "c=4, [0,3] => 12.",
                Variaveis = [ new() { Simbolo = "c", Nome = "constante", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "a", Nome = "a", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b", Nome = "b", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Integral", Calcular = v => v["c"] * (v["b"] - v["a"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_rn01", CodigoCompendio = "098", Nome = "Derivada de Radon-Nikodym (densidade)", Categoria = "Vol3: Teoria da Medida", SubCategoria = "Radon-Nikodym",
                Expressao = "nu(A)=int_A f dmu", ExprTexto = "f = dnu/dmu", Icone = "dnu",
                Descricao = "Calcula nu(A) quando f e mu(A) sao conhecidos por media: nu=f*mu(A).", Criador = "Radon / Nikodym", AnoOrigin = "1913/1930",
                ExemploPratico = "f=2.5, mu(A)=4 => nu(A)=10.",
                Variaveis = [ new() { Simbolo = "f", Nome = "densidade", ValorPadrao = 2.5, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "muA", Nome = "mu(A)", ValorPadrao = 4, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "nu(A)", Calcular = v => v["f"] * v["muA"],
                Unidades = "",
            },
        ]);
    }

    // 3) Teoria das Categorias
    private void AdicionarTeoriaCategoriasCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_tc01", CodigoCompendio = "099", Nome = "Cardinalidade do produto cartesiano", Categoria = "Vol3: Teoria das Categorias", SubCategoria = "Construcao Universal",
                Expressao = "|A x B| = |A||B|", ExprTexto = "Produto universal em Set", Icone = "cat",
                Descricao = "No caso da categoria Set, produto coincide com produto cartesiano.", Criador = "Categoria Set", AnoOrigin = "1945",
                ExemploPratico = "|A|=3, |B|=5 => |A x B|=15.",
                Variaveis = [ new() { Simbolo = "na", Nome = "|A|", ValorPadrao = 3, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nb", Nome = "|B|", ValorPadrao = 5, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "|A x B|", Calcular = v => v["na"] * v["nb"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_tc02", CodigoCompendio = "100", Nome = "Cardinalidade do coproduto disjunto", Categoria = "Vol3: Teoria das Categorias", SubCategoria = "Construcao Universal",
                Expressao = "|A + B| = |A|+|B|", ExprTexto = "Coproduto em Set", Icone = "cat",
                Descricao = "No caso Set, coproduto e uniao disjunta.", Criador = "Categoria Set", AnoOrigin = "1945",
                ExemploPratico = "|A|=4, |B|=7 => 11.",
                Variaveis = [ new() { Simbolo = "na", Nome = "|A|", ValorPadrao = 4, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nb", Nome = "|B|", ValorPadrao = 7, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "|A+B|", Calcular = v => v["na"] + v["nb"],
                Unidades = "",
            },
        ]);
    }

    // 4) Analise Numerica
    private void AdicionarAnaliseNumericaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_an01", CodigoCompendio = "101", Nome = "Interpolacao linear", Categoria = "Vol3: Analise Numerica", SubCategoria = "Interpolacao",
                Expressao = "p(x)=y0 + (y1-y0)(x-x0)/(x1-x0)", ExprTexto = "Interpolacao de Lagrange n=1", Icone = "num",
                Descricao = "Caso basico de Lagrange/Newton para dois pontos.", Criador = "Lagrange", AnoOrigin = "1795",
                ExemploPratico = "(0,2),(10,12), x=4 => p(4)=6.",
                Variaveis = [ new() { Simbolo = "x0", Nome = "x0", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "y0", Nome = "y0", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x1", Nome = "x1", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "y1", Nome = "y1", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x", Nome = "x", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "p(x)", Calcular = v => v["y0"] + (v["y1"] - v["y0"]) * (v["x"] - v["x0"]) / (v["x1"] - v["x0"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_an02", CodigoCompendio = "102", Nome = "Regra do trapezio simples", Categoria = "Vol3: Analise Numerica", SubCategoria = "Integracao",
                Expressao = "int_a^b f dx ~= (b-a)(f(a)+f(b))/2", ExprTexto = "Trapezio", Icone = "num",
                Descricao = "Integracao numerica de 1a ordem.", Criador = "Newton-Cotes", AnoOrigin = "1676",
                ExemploPratico = "f(a)=1, f(b)=5, a=0, b=2 => 6.",
                Variaveis = [ new() { Simbolo = "a", Nome = "a", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b", Nome = "b", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fa", Nome = "f(a)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fb", Nome = "f(b)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Integral", Calcular = v => (v["b"] - v["a"]) * (v["fa"] + v["fb"]) / 2.0,
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_an03", CodigoCompendio = "103", Nome = "Simpson 1/3", Categoria = "Vol3: Analise Numerica", SubCategoria = "Integracao",
                Expressao = "int_a^b f dx ~= (b-a)(f(a)+4f(m)+f(b))/6", ExprTexto = "Simpson 1/3", Icone = "num",
                Descricao = "Regra de Simpson para um painel.", Criador = "Thomas Simpson", AnoOrigin = "1743",
                ExemploPratico = "a=0,b=2,fa=1,fm=2,fb=5 => 14/3.",
                Variaveis = [ new() { Simbolo = "a", Nome = "a", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b", Nome = "b", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fa", Nome = "f(a)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fm", Nome = "f(m)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fb", Nome = "f(b)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Integral", Calcular = v => (v["b"] - v["a"]) * (v["fa"] + 4 * v["fm"] + v["fb"]) / 6.0,
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_an04", CodigoCompendio = "104", Nome = "Euler explicito", Categoria = "Vol3: Analise Numerica", SubCategoria = "EDOs",
                Expressao = "y_{n+1}=y_n+h f(t_n,y_n)", ExprTexto = "Metodo de Euler", Icone = "num",
                Descricao = "Passo de integracao de EDO de 1a ordem.", Criador = "Leonhard Euler", AnoOrigin = "1768",
                ExemploPratico = "y=1, h=0.1, f=3 => y_next=1.3.",
                Variaveis = [ new() { Simbolo = "y", Nome = "y_n", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "h", Nome = "h", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "f", Nome = "f(t_n,y_n)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "y_{n+1}", Calcular = v => v["y"] + v["h"] * v["f"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_an05", CodigoCompendio = "105", Nome = "Numero de condicao", Categoria = "Vol3: Analise Numerica", SubCategoria = "Algebra Linear Numerica",
                Expressao = "kappa(A)=sigma_max/sigma_min", ExprTexto = "Condicionamento", Icone = "num",
                Descricao = "Sensibilidade da solucao linear a perturbacoes.", Criador = "Wilkinson", AnoOrigin = "1963",
                ExemploPratico = "sigma_max=100, sigma_min=0.5 => kappa=200.",
                Variaveis = [ new() { Simbolo = "smax", Nome = "sigma_max", ValorPadrao = 100, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "smin", Nome = "sigma_min", ValorPadrao = 0.5, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "kappa", Calcular = v => v["smax"] / v["smin"],
                Unidades = "",
            },
        ]);
    }

    // 5) Geometria Algebrica e Curvas Elipticas
    private void AdicionarGeometriaAlgebricaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_ga01", CodigoCompendio = "106", Nome = "Genero de curva plana lisa", Categoria = "Vol3: Geometria Algebrica", SubCategoria = "Variedades",
                Expressao = "g=(d-1)(d-2)/2", ExprTexto = "Genero", Icone = "alg",
                Descricao = "Genero de curva plana nao singular de grau d.", Criador = "Plucker", AnoOrigin = "1860",
                ExemploPratico = "d=3 => g=1 (curva eliptica cubica lisa).",
                Variaveis = [ new() { Simbolo = "d", Nome = "grau d", ValorPadrao = 3, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "g", Calcular = v => (v["d"] - 1) * (v["d"] - 2) / 2.0,
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ce01", CodigoCompendio = "107", Nome = "Discriminante de Weierstrass", Categoria = "Vol3: Geometria Algebrica", SubCategoria = "Curvas Elipticas",
                Expressao = "Delta=-16(4a^3+27b^2)", ExprTexto = "Nao singular se Delta != 0", Icone = "ec",
                Descricao = "Condicao de nao singularidade de y^2=x^3+ax+b.", Criador = "Weierstrass", AnoOrigin = "1854",
                ExemploPratico = "a=-1,b=1 => Delta=-16( -4 + 27 )=-368 !=0.",
                Variaveis = [ new() { Simbolo = "a", Nome = "a", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b", Nome = "b", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Delta", Calcular = v => -16 * (4 * Math.Pow(v["a"], 3) + 27 * Math.Pow(v["b"], 2)),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ce02", CodigoCompendio = "108", Nome = "Soma de pontos - inclinacao secante", Categoria = "Vol3: Geometria Algebrica", SubCategoria = "Curvas Elipticas",
                Expressao = "lambda=(y2-y1)/(x2-x1)", ExprTexto = "Inclinacao para P!=Q", Icone = "ec",
                Descricao = "Passo central da regra de adicao em curvas elipticas.", Criador = "Geometria corda-tangente", AnoOrigin = "Sec. XIX",
                ExemploPratico = "(1,2) e (3,6) => lambda=2.",
                Variaveis = [ new() { Simbolo = "x1", Nome = "x1", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "y1", Nome = "y1", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x2", Nome = "x2", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "y2", Nome = "y2", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "lambda", Calcular = v => (v["y2"] - v["y1"]) / (v["x2"] - v["x1"]),
                Unidades = "",
            },
        ]);
    }

    // 6) Logica Matematica
    private void AdicionarLogicaMatematicaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_lm01", CodigoCompendio = "109", Nome = "Avaliacao de implicacao", Categoria = "Vol3: Logica Matematica", SubCategoria = "Primeira Ordem",
                Expressao = "p->q equivale (!p) ou q", ExprTexto = "Implicacao booleana", Icone = "log",
                Descricao = "Retorna 1 para verdadeiro e 0 para falso em p->q.", Criador = "Logica classica", AnoOrigin = "Aristoteles",
                ExemploPratico = "p=1,q=0 => falso (0).",
                Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "q", Nome = "q", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "p->q", Calcular = v => (v["p"] < 0.5 || v["q"] > 0.5) ? 1 : 0,
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_gd01", CodigoCompendio = "110", Nome = "Codificacao de Godel simplificada", Categoria = "Vol3: Logica Matematica", SubCategoria = "Incompletude",
                Expressao = "codigo = p1^a1 p2^a2 ...", ExprTexto = "Numero de Godel (modelo simplificado)", Icone = "log",
                Descricao = "Calcula codigo com duas letras usando primos 2 e 3.", Criador = "Kurt Godel", AnoOrigin = "1931",
                ExemploPratico = "a1=3,a2=2 => 2^3*3^2=72.",
                Variaveis = [ new() { Simbolo = "a1", Nome = "expoente 2", ValorPadrao = 3, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "a2", Nome = "expoente 3", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "codigo", Calcular = v => Math.Pow(2, v["a1"]) * Math.Pow(3, v["a2"]),
                Unidades = "",
            },
        ]);
    }

    // 7) Materia Condensada
    private void AdicionarMateriaCondensadaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_mc01", CodigoCompendio = "111", Nome = "Dispersao eletron livre", Categoria = "Vol3: Materia Condensada", SubCategoria = "Bandas",
                Expressao = "E=hbar^2 k^2/(2m)", ExprTexto = "Relacao de dispersao", Icone = "mc",
                Descricao = "Energia de particula livre em funcao de k.", Criador = "Mecanica Quantica", AnoOrigin = "1926",
                ExemploPratico = "k maior => energia quadratica maior.",
                Variaveis = [ new() { Simbolo = "hbar", Nome = "hbar", ValorPadrao = 1.054571817e-34, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k", Nome = "k", ValorPadrao = 1e10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "m", Nome = "m", ValorPadrao = 9.10938356e-31, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "E", UnidadeResultado = "J", Calcular = v => v["hbar"] * v["hbar"] * v["k"] * v["k"] / (2 * v["m"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_mc02", CodigoCompendio = "112", Nome = "Condutividade de Drude", Categoria = "Vol3: Materia Condensada", SubCategoria = "Transporte",
                Expressao = "sigma=ne^2 tau/m", ExprTexto = "Modelo de Drude", Icone = "mc",
                Descricao = "Condutividade eletrica DC em metal classico.", Criador = "Paul Drude", AnoOrigin = "1900",
                ExemploPratico = "n=8.5e28, tau=2.5e-14 -> ordem 1e7 S/m.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n", ValorPadrao = 8.5e28, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 1.602176634e-19, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "tau", Nome = "tau", ValorPadrao = 2.5e-14, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "m", Nome = "m", ValorPadrao = 9.10938356e-31, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "sigma", UnidadeResultado = "S/m", Calcular = v => v["n"] * v["e"] * v["e"] * v["tau"] / v["m"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_sc01", CodigoCompendio = "113", Nome = "Quantum de fluxo", Categoria = "Vol3: Materia Condensada", SubCategoria = "Supercondutividade BCS",
                Expressao = "Phi0=h/(2e)", ExprTexto = "Fluxo quantizado", Icone = "mc",
                Descricao = "Quantum de fluxo em supercondutores.", Criador = "BCS / London", AnoOrigin = "1957",
                ExemploPratico = "Valor padrao ~2.07e-15 Wb.",
                Variaveis = [ new() { Simbolo = "h", Nome = "h", ValorPadrao = 6.62607015e-34, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 1.602176634e-19, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Phi0", UnidadeResultado = "Wb", Calcular = v => v["h"] / (2 * v["e"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_fn01", CodigoCompendio = "114", Nome = "Lei T^3 de Debye (aprox)", Categoria = "Vol3: Materia Condensada", SubCategoria = "Fonons",
                Expressao = "Cv~(12 pi^4/5) NkB (T/thetaD)^3", ExprTexto = "Baixa temperatura", Icone = "mc",
                Descricao = "Capacidade calorifica fononica em T << thetaD.", Criador = "Peter Debye", AnoOrigin = "1912",
                ExemploPratico = "Aumenta cubicamente com temperatura.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "kB", Nome = "kB", ValorPadrao = 1.380649e-23, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 20, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "thetaD", Nome = "thetaD", ValorPadrao = 300, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Cv", UnidadeResultado = "J/K", Calcular = v => (12 * Math.Pow(Math.PI, 4) / 5.0) * v["N"] * v["kB"] * Math.Pow(v["T"] / v["thetaD"], 3),
                Unidades = "",
            },
        ]);
    }

    // 8) Caos e Fractais
    private void AdicionarCaosFractaisCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_ca01", CodigoCompendio = "115", Nome = "Mapa logistico (1 passo)", Categoria = "Vol3: Caos e Fractais", SubCategoria = "Sistemas Dinamicos",
                Expressao = "x_{n+1}=r x_n (1-x_n)", ExprTexto = "Mapa logistico", Icone = "chaos",
                Descricao = "Iteracao classica com caos para r~3.57..4.", Criador = "Verhulst / May", AnoOrigin = "1845/1976",
                ExemploPratico = "r=3.9, x=0.4 => x_next=0.936.",
                Variaveis = [ new() { Simbolo = "r", Nome = "r", ValorPadrao = 3.9, ValorMin = 0, ValorMax = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x", Nome = "x_n", ValorPadrao = 0.4, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "x_{n+1}", Calcular = v => v["r"] * v["x"] * (1 - v["x"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_lz01", CodigoCompendio = "116", Nome = "Divergencia de trajetorias", Categoria = "Vol3: Caos e Fractais", SubCategoria = "Lorenz",
                Expressao = "delta(t)=delta0 e^{lambda t}", ExprTexto = "Expoente de Lyapunov", Icone = "chaos",
                Descricao = "Sensibilidade a condicoes iniciais.", Criador = "Lyapunov", AnoOrigin = "1892",
                ExemploPratico = "lambda=0.9,t=5,delta0=1e-6 => ~9e-5.",
                Variaveis = [ new() { Simbolo = "delta0", Nome = "delta0", ValorPadrao = 1e-6, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 0.9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "t", Nome = "t", ValorPadrao = 5, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "delta(t)", Calcular = v => v["delta0"] * Math.Exp(v["lambda"] * v["t"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_fr01", CodigoCompendio = "117", Nome = "Dimensao fractal autossimilar", Categoria = "Vol3: Caos e Fractais", SubCategoria = "Fractais",
                Expressao = "d=log(N)/log(1/r)", ExprTexto = "Hausdorff autossimilar", Icone = "chaos",
                Descricao = "Dimensao para fractais com N copias em escala r.", Criador = "Hausdorff", AnoOrigin = "1918",
                ExemploPratico = "Cantor: N=2,r=1/3 => 0.631.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N", ValorPadrao = 2, ValorMin = 1.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "r", Nome = "r", ValorPadrao = 1.0/3.0, ValorMin = 0.0001, ValorMax = 0.9999, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "d", Calcular = v => Math.Log(v["N"]) / Math.Log(1.0 / v["r"]),
                Unidades = "",
            },
        ]);
    }

    // 9) Fisica de Plasmas
    private void AdicionarFisicaPlasmasCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_pl01", CodigoCompendio = "118", Nome = "Comprimento de Debye", Categoria = "Vol3: Fisica de Plasmas", SubCategoria = "Fundamentos",
                Expressao = "lambdaD=sqrt(eps0 kB T /(n e^2))", ExprTexto = "Debye", Icone = "plasma",
                Descricao = "Escala de blindagem eletrostatica no plasma.", Criador = "Peter Debye", AnoOrigin = "1923",
                ExemploPratico = "T alta aumenta lambdaD; n alta diminui lambdaD.",
                Variaveis = [ new() { Simbolo = "eps0", Nome = "eps0", ValorPadrao = 8.8541878128e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "kB", Nome = "kB", ValorPadrao = 1.380649e-23, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1e5, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1e18, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 1.602176634e-19, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "lambdaD", UnidadeResultado = "m", Calcular = v => Math.Sqrt(v["eps0"] * v["kB"] * v["T"] / (v["n"] * v["e"] * v["e"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_pl02", CodigoCompendio = "119", Nome = "Frequencia de plasma", Categoria = "Vol3: Fisica de Plasmas", SubCategoria = "Fundamentos",
                Expressao = "omega_p=sqrt(n e^2 /(eps0 me))", ExprTexto = "Frequencia plasmatica", Icone = "plasma",
                Descricao = "Oscilacao coletiva de eletrons.", Criador = "Tonks / Langmuir", AnoOrigin = "1929",
                ExemploPratico = "n alto eleva omega_p.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n", ValorPadrao = 1e18, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 1.602176634e-19, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "eps0", Nome = "eps0", ValorPadrao = 8.8541878128e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "me", Nome = "me", ValorPadrao = 9.10938356e-31, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "omega_p", UnidadeResultado = "rad/s", Calcular = v => Math.Sqrt(v["n"] * v["e"] * v["e"] / (v["eps0"] * v["me"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_mh01", CodigoCompendio = "120", Nome = "Velocidade de Alfven", Categoria = "Vol3: Fisica de Plasmas", SubCategoria = "MHD",
                Expressao = "vA=B/sqrt(mu0 rho)", ExprTexto = "Onda de Alfven", Icone = "plasma",
                Descricao = "Velocidade de propagacao magnetohidrodinamica.", Criador = "Hannes Alfven", AnoOrigin = "1942",
                ExemploPratico = "B=0.01 T, rho=1e-6 kg/m3.",
                Variaveis = [ new() { Simbolo = "B", Nome = "B", ValorPadrao = 0.01, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mu0", Nome = "mu0", ValorPadrao = 4e-7 * Math.PI, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rho", Nome = "rho", ValorPadrao = 1e-6, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "vA", UnidadeResultado = "m/s", Calcular = v => v["B"] / Math.Sqrt(v["mu0"] * v["rho"]),
                Unidades = "",
            },
        ]);
    }

    // 10) Fisica Nuclear
    private void AdicionarFisicaNuclearCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_nu01", CodigoCompendio = "121", Nome = "Raio nuclear", Categoria = "Vol3: Fisica Nuclear", SubCategoria = "Estrutura Nuclear",
                Expressao = "R=R0 A^(1/3)", ExprTexto = "Raio nuclear", Icone = "nuc",
                Descricao = "Estimativa empirica do raio do nucleo.", Criador = "Modelo de gota", AnoOrigin = "1930",
                ExemploPratico = "A=56 => R~4.6 fm com R0=1.2 fm.",
                Variaveis = [ new() { Simbolo = "R0", Nome = "R0", ValorPadrao = 1.2, Unidade = "fm", Descricao = "Parâmetro de entrada." }, new() { Simbolo = "A", Nome = "A", ValorPadrao = 56, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "R", UnidadeResultado = "fm", Calcular = v => v["R0"] * Math.Pow(v["A"], 1.0 / 3.0),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_nu02", CodigoCompendio = "122", Nome = "Q-valor", Categoria = "Vol3: Fisica Nuclear", SubCategoria = "Reacoes",
                Expressao = "Q=(mi-mf)c^2", ExprTexto = "Energia da reacao", Icone = "nuc",
                Descricao = "Energia liberada/absorvida em reacoes nucleares.", Criador = "Fisica nuclear", AnoOrigin = "Sec. XX",
                ExemploPratico = "Se mi>mf, Q positivo (exoenergetica).",
                Variaveis = [ new() { Simbolo = "mi", Nome = "massa inicial", ValorPadrao = 1.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mf", Nome = "massa final", ValorPadrao = 1.0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "c", Nome = "c", ValorPadrao = 299792458, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Q", UnidadeResultado = "J", Calcular = v => (v["mi"] - v["mf"]) * v["c"] * v["c"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_nu03", CodigoCompendio = "123", Nome = "Secao de choque", Categoria = "Vol3: Fisica Nuclear", SubCategoria = "Reacoes",
                Expressao = "Nreac=sigma I n L", ExprTexto = "Taxa de reacoes", Icone = "nuc",
                Descricao = "Relaciona secao de choque com numero de reacoes.", Criador = "Fisica de colisoes", AnoOrigin = "Sec. XX",
                ExemploPratico = "sigma em barn, converter para m2.",
                Variaveis = [ new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 1e-28, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "I", Nome = "fluxo I", ValorPadrao = 1e12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "densidade n", ValorPadrao = 1e24, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "L", Nome = "espessura L", ValorPadrao = 1e-3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Nreac", Calcular = v => v["sigma"] * v["I"] * v["n"] * v["L"],
                Unidades = "",
            },
        ]);
    }

    // 11) Optica Quantica
    private void AdicionarOpticaQuanticaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_oq01", CodigoCompendio = "124", Nome = "Energia de modo quantizado", Categoria = "Vol3: Optica Quantica", SubCategoria = "Campo Quantizado",
                Expressao = "E=hbar omega (n+1/2)", ExprTexto = "Oscilador harmonico quantico", Icone = "oq",
                Descricao = "Energia de numero de fotons n em um modo.", Criador = "Planck / Dirac", AnoOrigin = "1900/1927",
                ExemploPratico = "n=0 ainda possui energia de ponto zero.",
                Variaveis = [ new() { Simbolo = "hbar", Nome = "hbar", ValorPadrao = 1.054571817e-34, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "omega", Nome = "omega", ValorPadrao = 3e15, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "E", UnidadeResultado = "J", Calcular = v => v["hbar"] * v["omega"] * (v["n"] + 0.5),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_oq02", CodigoCompendio = "125", Nome = "Media de fotons em estado coerente", Categoria = "Vol3: Optica Quantica", SubCategoria = "Laser",
                Expressao = "<n>=|alpha|^2", ExprTexto = "Estado coerente", Icone = "oq",
                Descricao = "Numero medio de fotons em estado coerente.", Criador = "Roy Glauber", AnoOrigin = "1963",
                ExemploPratico = "alpha=2 => <n>=4.",
                Variaveis = [ new() { Simbolo = "alpha", Nome = "|alpha|", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "<n>", Calcular = v => v["alpha"] * v["alpha"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_oq03", CodigoCompendio = "126", Nome = "CHSH maximo quantico", Categoria = "Vol3: Optica Quantica", SubCategoria = "Emaranhamento",
                Expressao = "Smax=2*sqrt(2)", ExprTexto = "Limite de Tsirelson", Icone = "oq",
                Descricao = "Violacao maxima quantica da desigualdade CHSH.", Criador = "Tsirelson", AnoOrigin = "1980",
                ExemploPratico = "Sclassico<=2; Squantico<=2.828.",
                Variaveis = [], VariavelResultado = "Smax", Calcular = _ => 2 * Math.Sqrt(2),
                Unidades = "",
            },
        ]);
    }

    // 12) Sobrevivencia
    private void AdicionarAnaliseSobrevivenciaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_sv01", CodigoCompendio = "127", Nome = "Sobrevivencia complementar", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Fundamentos",
                Expressao = "S(t)=1-F(t)", ExprTexto = "Funcao de sobrevivencia", Icone = "sv",
                Descricao = "Probabilidade de sobreviver alem de t.", Criador = "Estatistica atuarial", AnoOrigin = "Sec. XIX",
                ExemploPratico = "F=0.3 => S=0.7.",
                Variaveis = [ new() { Simbolo = "F", Nome = "F(t)", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "S(t)", Calcular = v => 1 - v["F"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_sv02", CodigoCompendio = "128", Nome = "Hazard acumulado", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Fundamentos",
                Expressao = "H(t)=-ln S(t)", ExprTexto = "Risco acumulado", Icone = "sv",
                Descricao = "Transformacao entre S e H.", Criador = "Nelson-Aalen", AnoOrigin = "1972",
                ExemploPratico = "S=0.2 => H~1.609.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S(t)", ValorPadrao = 0.2, ValorMin = 0.0001, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "H(t)", Calcular = v => -Math.Log(v["S"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_sv03", CodigoCompendio = "129", Nome = "Modelo de Cox (HR)", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Cox",
                Expressao = "HR=exp(beta)", ExprTexto = "Hazard ratio", Icone = "sv",
                Descricao = "Razao de risco associada a uma covariavel.", Criador = "David Cox", AnoOrigin = "1972",
                ExemploPratico = "beta=0.69 => HR~2.",
                Variaveis = [ new() { Simbolo = "beta", Nome = "beta", ValorPadrao = 0.69, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "HR", Calcular = v => Math.Exp(v["beta"]),
                Unidades = "",
            },
        ]);
    }

    // 13) Valores extremos e copulas
    private void AdicionarValoresExtremosCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_ve01", CodigoCompendio = "130", Nome = "Gumbel CDF", Categoria = "Vol3: Valores Extremos e Copulas", SubCategoria = "GEV",
                Expressao = "F=exp(-exp(-(x-mu)/sigma))", ExprTexto = "Caso xi=0", Icone = "ve",
                Descricao = "Distribuicao de Gumbel para maximos.", Criador = "Emil Gumbel", AnoOrigin = "1935",
                ExemploPratico = "x=mu => F=e^-1=0.3679.",
                Variaveis = [ new() { Simbolo = "x", Nome = "x", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 2, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "F", Calcular = v => Math.Exp(-Math.Exp(-(v["x"] - v["mu"]) / v["sigma"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ve02", CodigoCompendio = "131", Nome = "VaR normal", Categoria = "Vol3: Valores Extremos e Copulas", SubCategoria = "Risco",
                Expressao = "VaR=mu+z_alpha sigma", ExprTexto = "Value at Risk", Icone = "ve",
                Descricao = "Quantil de perda sob normalidade.", Criador = "RiskMetrics", AnoOrigin = "1994",
                ExemploPratico = "mu=0,z=2.326,sigma=1% => 2.326%.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "z", Nome = "z_alpha", ValorPadrao = 2.326, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 0.01, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "VaR", Calcular = v => v["mu"] + v["z"] * v["sigma"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_co01", CodigoCompendio = "132", Nome = "Copula de Clayton", Categoria = "Vol3: Valores Extremos e Copulas", SubCategoria = "Copulas",
                Expressao = "C=(u^-theta+v^-theta-1)^(-1/theta)", ExprTexto = "Copula Archimedeana", Icone = "ve",
                Descricao = "Modela dependencia de cauda inferior.", Criador = "David Clayton", AnoOrigin = "1978",
                ExemploPratico = "u=0.5,v=0.7,theta=2.",
                Variaveis = [ new() { Simbolo = "u", Nome = "u", ValorPadrao = 0.5, ValorMin = 0.0001, ValorMax = 0.9999, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "v", Nome = "v", ValorPadrao = 0.7, ValorMin = 0.0001, ValorMax = 0.9999, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "theta", Nome = "theta", ValorPadrao = 2, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "C(u,v)", Calcular = x => Math.Pow(Math.Pow(x["u"], -x["theta"]) + Math.Pow(x["v"], -x["theta"]) - 1.0, -1.0 / x["theta"]),
                Unidades = "",
            },
        ]);
    }

    // 14) Geoestatistica
    private void AdicionarGeoestatisticaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_ge01", CodigoCompendio = "133", Nome = "Semivariograma", Categoria = "Vol3: Geoestatistica", SubCategoria = "Variograma",
                Expressao = "gamma(h)=0.5 Var[Z(x+h)-Z(x)]", ExprTexto = "Semivariograma", Icone = "geo",
                Descricao = "Medida de dependencia espacial.", Criador = "Matheron", AnoOrigin = "1963",
                ExemploPratico = "Se Var=4 => gamma=2.",
                Variaveis = [ new() { Simbolo = "var", Nome = "Var diff", ValorPadrao = 4, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "gamma", Calcular = v => 0.5 * v["var"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ge02", CodigoCompendio = "134", Nome = "Covariancia exponencial", Categoria = "Vol3: Geoestatistica", SubCategoria = "Modelos",
                Expressao = "C(h)=sigma^2 exp(-h/a)", ExprTexto = "Modelo exponencial", Icone = "geo",
                Descricao = "Modelo de covariancia com decaimento exponencial.", Criador = "Geoestatistica classica", AnoOrigin = "Sec. XX",
                ExemploPratico = "h=a => C=sigma^2/e.",
                Variaveis = [ new() { Simbolo = "sigma2", Nome = "sigma^2", ValorPadrao = 9, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "h", Nome = "h", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "a", Nome = "alcance", ValorPadrao = 3, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "C(h)", Calcular = v => v["sigma2"] * Math.Exp(-v["h"] / v["a"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ge03", CodigoCompendio = "135", Nome = "Kriging ordinario (estimador linear)", Categoria = "Vol3: Geoestatistica", SubCategoria = "Kriging",
                Expressao = "Zhat=sum lambda_i Z_i", ExprTexto = "Interpolacao linear", Icone = "geo",
                Descricao = "Estimativa em x0 com 3 amostras e pesos.", Criador = "Danie Krige / Matheron", AnoOrigin = "1951/1963",
                ExemploPratico = "Pesos somam 1 para nao viesado.",
                Variaveis = [ new() { Simbolo = "l1", Nome = "lambda1", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "l2", Nome = "lambda2", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "l3", Nome = "lambda3", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "z1", Nome = "Z1", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "z2", Nome = "Z2", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "z3", Nome = "Z3", ValorPadrao = 11, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Zhat", Calcular = v => v["l1"] * v["z1"] + v["l2"] * v["z2"] + v["l3"] * v["z3"],
                Unidades = "",
            },
        ]);
    }

    // 15) Mecanica da fratura
    private void AdicionarMecanicaFraturaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_mf01", CodigoCompendio = "136", Nome = "Fator de intensidade KI", Categoria = "Vol3: Mecanica da Fratura", SubCategoria = "LEFM",
                Expressao = "KI=sigma sqrt(pi a) F", ExprTexto = "SIF modo I", Icone = "eng",
                Descricao = "Parametro de ponta de trinca para modo de abertura.", Criador = "George Irwin", AnoOrigin = "1957",
                ExemploPratico = "sigma=100MPa,a=0.01m,F=1 => KI~17.7 MPa*sqrt(m).",
                Variaveis = [ new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 100, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "a", Nome = "a", ValorPadrao = 0.01, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "F", Nome = "F", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "KI", Calcular = v => v["sigma"] * Math.Sqrt(Math.PI * v["a"]) * v["F"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_fd01", CodigoCompendio = "137", Nome = "Lei de Paris", Categoria = "Vol3: Mecanica da Fratura", SubCategoria = "Fadiga",
                Expressao = "da/dN=C (DeltaK)^m", ExprTexto = "Crescimento de trinca", Icone = "eng",
                Descricao = "Taxa de propagacao por fadiga em regime Paris.", Criador = "Paris-Erdogan", AnoOrigin = "1963",
                ExemploPratico = "C=1e-12,m=3,DeltaK=20 => 8e-9 m/ciclo.",
                Variaveis = [ new() { Simbolo = "C", Nome = "C", ValorPadrao = 1e-12, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "DeltaK", Nome = "DeltaK", ValorPadrao = 20, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "m", Nome = "m", ValorPadrao = 3, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "da/dN", Calcular = v => v["C"] * Math.Pow(v["DeltaK"], v["m"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_fd02", CodigoCompendio = "138", Nome = "Dano acumulado de Miner", Categoria = "Vol3: Mecanica da Fratura", SubCategoria = "Fadiga",
                Expressao = "D=sum n_i/N_i", ExprTexto = "Falha quando D>=1", Icone = "eng",
                Descricao = "Regra linear de dano acumulado.", Criador = "Palmgren-Miner", AnoOrigin = "1945",
                ExemploPratico = "n1/N1=0.3 e n2/N2=0.8 => D=1.1 (falha).",
                Variaveis = [ new() { Simbolo = "d1", Nome = "n1/N1", ValorPadrao = 0.3, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "d2", Nome = "n2/N2", ValorPadrao = 0.8, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "D", Calcular = v => v["d1"] + v["d2"],
                Unidades = "",
            },
        ]);
    }

    // 16) CFD
    private void AdicionarCFDTurbulenciaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_ns01", CodigoCompendio = "139", Nome = "Numero de Reynolds", Categoria = "Vol3: CFD e Turbulencia", SubCategoria = "Navier-Stokes",
                Expressao = "Re=UL/nu", ExprTexto = "Regime de escoamento", Icone = "cfd",
                Descricao = "Razao entre forcas inerciais e viscosas.", Criador = "Osborne Reynolds", AnoOrigin = "1883",
                ExemploPratico = "U=2,L=0.5,nu=1e-6 => Re=1e6.",
                Variaveis = [ new() { Simbolo = "U", Nome = "U", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "L", Nome = "L", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nu", Nome = "nu", ValorPadrao = 1e-6, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Re", Calcular = v => v["U"] * v["L"] / v["nu"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_tb01", CodigoCompendio = "140", Nome = "Viscosidade turbulenta k-epsilon", Categoria = "Vol3: CFD e Turbulencia", SubCategoria = "Modelos RANS",
                Expressao = "nu_t=Cmu k^2/epsilon", ExprTexto = "Fechamento k-epsilon", Icone = "cfd",
                Descricao = "Modelo classico de viscosidade turbulenta.", Criador = "Launder-Spalding", AnoOrigin = "1974",
                ExemploPratico = "Cmu=0.09,k=0.5,eps=0.05 => nu_t=0.45.",
                Variaveis = [ new() { Simbolo = "Cmu", Nome = "Cmu", ValorPadrao = 0.09, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k", Nome = "k", ValorPadrao = 0.5, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "eps", Nome = "epsilon", ValorPadrao = 0.05, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "nu_t", Calcular = v => v["Cmu"] * v["k"] * v["k"] / v["eps"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_cf01", CodigoCompendio = "141", Nome = "CFL", Categoria = "Vol3: CFD e Turbulencia", SubCategoria = "Metodos Numericos",
                Expressao = "CFL=u dt/dx", ExprTexto = "Condicao de Courant", Icone = "cfd",
                Descricao = "Estabilidade de esquemas explicitos.", Criador = "Courant-Friedrichs-Lewy", AnoOrigin = "1928",
                ExemploPratico = "u=10,dt=1e-3,dx=0.02 => CFL=0.5.",
                Variaveis = [ new() { Simbolo = "u", Nome = "u", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dt", Nome = "dt", ValorPadrao = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dx", Nome = "dx", ValorPadrao = 0.02, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "CFL", Calcular = v => v["u"] * v["dt"] / v["dx"],
                Unidades = "",
            },
        ]);
    }

    // 17) Robotica
    private void AdicionarRoboticaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_rb01", CodigoCompendio = "142", Nome = "Jacobiano planar 2R (det)", Categoria = "Vol3: Robotica", SubCategoria = "Cinematica",
                Expressao = "det(J)=l1 l2 sin(q2)", ExprTexto = "Singularidade quando det(J)=0", Icone = "rb",
                Descricao = "Determinante do Jacobiano para manipulador planar 2R.", Criador = "Robotica classica", AnoOrigin = "Sec. XX",
                ExemploPratico = "q2=0 => singular.",
                Variaveis = [ new() { Simbolo = "l1", Nome = "l1", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "l2", Nome = "l2", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "q2", Nome = "q2", ValorPadrao = 1.0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "detJ", Calcular = v => v["l1"] * v["l2"] * Math.Sin(v["q2"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_rb02", CodigoCompendio = "143", Nome = "Controle PD (1 junta)", Categoria = "Vol3: Robotica", SubCategoria = "Dinamica e Controle",
                Expressao = "tau=Kp e + Kv edot", ExprTexto = "Torque computado simplificado", Icone = "rb",
                Descricao = "Lei de controle proporcional-derivativa.", Criador = "Controle classico", AnoOrigin = "Sec. XX",
                ExemploPratico = "Kp=100,Kv=20,e=0.1,edot=-0.05 => tau=9.",
                Variaveis = [ new() { Simbolo = "Kp", Nome = "Kp", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Kv", Nome = "Kv", ValorPadrao = 20, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "edot", Nome = "edot", ValorPadrao = -0.05, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "tau", Calcular = v => v["Kp"] * v["e"] + v["Kv"] * v["edot"],
                Unidades = "",
            },
        ]);
    }

    // 18) Sistemas de Potencia
    private void AdicionarSistemasPotenciaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_sp01", CodigoCompendio = "144", Nome = "Corrente de curto trifasico", Categoria = "Vol3: Sistemas de Potencia", SubCategoria = "Curto-Circuito",
                Expressao = "Icc=V/(sqrt(3) Zth)", ExprTexto = "Curto 3-fases", Icone = "pow",
                Descricao = "Corrente simetrica de curto no barramento.", Criador = "Sistemas eletricos", AnoOrigin = "Sec. XX",
                ExemploPratico = "V=13.8kV, Zth=0.5ohm => Icc~15.9kA.",
                Variaveis = [ new() { Simbolo = "V", Nome = "V", ValorPadrao = 13800, Unidade = "V", Descricao = "Parâmetro de entrada." }, new() { Simbolo = "Zth", Nome = "Zth", ValorPadrao = 0.5, ValorMin = 1e-9, Unidade = "ohm", Descricao = "Parâmetro de entrada." } ],
                VariavelResultado = "Icc", UnidadeResultado = "A", Calcular = v => v["V"] / (Math.Sqrt(3) * v["Zth"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_sp02", CodigoCompendio = "145", Nome = "Equacao swing (aceleracao)", Categoria = "Vol3: Sistemas de Potencia", SubCategoria = "Estabilidade",
                Expressao = "ddelta=(Pm-Pe)/M", ExprTexto = "Estabilidade transitoria", Icone = "pow",
                Descricao = "Aceleracao angular da maquina sincrona.", Criador = "Steinmetz", AnoOrigin = "Sec. XX",
                ExemploPratico = "Pm>Pe acelera rotor.",
                Variaveis = [ new() { Simbolo = "Pm", Nome = "Pm", ValorPadrao = 1.0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Pe", Nome = "Pe", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "M", Nome = "M", ValorPadrao = 5, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "ddelta", Calcular = v => (v["Pm"] - v["Pe"]) / v["M"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_sp03", CodigoCompendio = "146", Nome = "Fluxo de carga DC", Categoria = "Vol3: Sistemas de Potencia", SubCategoria = "Fluxo de Carga",
                Expressao = "P=B theta", ExprTexto = "Aproximacao linear", Icone = "pow",
                Descricao = "Potencia ativa aproximada em rede linearizada.", Criador = "Analise de sistemas", AnoOrigin = "Sec. XX",
                ExemploPratico = "B=12, theta=0.05 => P=0.6 pu.",
                Variaveis = [ new() { Simbolo = "B", Nome = "B", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "theta", Nome = "theta", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "P", Calcular = v => v["B"] * v["theta"],
                Unidades = "",
            },
        ]);
    }

    // 19) Financas
    private void AdicionarFinancasQuantitativasCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_mk01", CodigoCompendio = "147", Nome = "Retorno esperado da carteira (2 ativos)", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Markowitz",
                Expressao = "E[Rp]=w1 mu1 + w2 mu2", ExprTexto = "Retorno medio ponderado", Icone = "fin",
                Descricao = "Retorno esperado de carteira com dois ativos.", Criador = "Harry Markowitz", AnoOrigin = "1952",
                ExemploPratico = "w=(0.6,0.4), mu=(10%,5%) => 8%.",
                Variaveis = [ new() { Simbolo = "w1", Nome = "w1", ValorPadrao = 0.6, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mu1", Nome = "mu1", ValorPadrao = 0.10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "w2", Nome = "w2", ValorPadrao = 0.4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mu2", Nome = "mu2", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "E[Rp]", Calcular = v => v["w1"] * v["mu1"] + v["w2"] * v["mu2"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_mk02", CodigoCompendio = "148", Nome = "Sharpe ratio", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Markowitz",
                Expressao = "SR=(Rp-Rf)/sigma", ExprTexto = "Indice de Sharpe", Icone = "fin",
                Descricao = "Retorno excedente por unidade de risco.", Criador = "William Sharpe", AnoOrigin = "1966",
                ExemploPratico = "Rp=0.12,Rf=0.03,sigma=0.15 => 0.6.",
                Variaveis = [ new() { Simbolo = "Rp", Nome = "Rp", ValorPadrao = 0.12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Rf", Nome = "Rf", ValorPadrao = 0.03, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 0.15, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "SR", Calcular = v => (v["Rp"] - v["Rf"]) / v["sigma"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_capm01", CodigoCompendio = "149", Nome = "CAPM", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "CAPM e APT",
                Expressao = "E[Ri]=Rf+beta(E[Rm]-Rf)", ExprTexto = "CAPM", Icone = "fin",
                Descricao = "Retorno exigido para risco sistematico beta.", Criador = "Sharpe-Lintner-Mossin", AnoOrigin = "1964",
                ExemploPratico = "Rf=3%, beta=1.2, Rm=10% => 11.4%.",
                Variaveis = [ new() { Simbolo = "Rf", Nome = "Rf", ValorPadrao = 0.03, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "beta", Nome = "beta", ValorPadrao = 1.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Rm", Nome = "E[Rm]", ValorPadrao = 0.10, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "E[Ri]", Calcular = v => v["Rf"] + v["beta"] * (v["Rm"] - v["Rf"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_gr01", CodigoCompendio = "150", Nome = "Black-Scholes Call", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Gregas e Opcoes",
                Expressao = "C=S N(d1)-K e^{-rT} N(d2)", ExprTexto = "Opcao de compra europeia", Icone = "fin",
                Descricao = "Preco de call pelo modelo de Black-Scholes-Merton.", Criador = "Black-Scholes-Merton", AnoOrigin = "1973",
                ExemploPratico = "S=100,K=100,r=5%,sigma=20%,T=1 => C~10.45.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 100, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "K", Nome = "K", ValorPadrao = 100, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "r", Nome = "r", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 0.2, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "C", Calcular = v => {
                    double d1 = (Math.Log(v["S"] / v["K"]) + (v["r"] + 0.5 * v["sigma"] * v["sigma"]) * v["T"]) / (v["sigma"] * Math.Sqrt(v["T"]));
                    double d2 = d1 - v["sigma"] * Math.Sqrt(v["T"]);
                    return v["S"] * NormCdf(d1) - v["K"] * Math.Exp(-v["r"] * v["T"]) * NormCdf(d2);
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ri01", CodigoCompendio = "151", Nome = "VaR parametrico", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Risco",
                Expressao = "VaR=mu+z sigma", ExprTexto = "Value at Risk", Icone = "fin",
                Descricao = "Estimativa de perda por quantil normal.", Criador = "RiskMetrics", AnoOrigin = "1994",
                ExemploPratico = "mu=0,z=2.326,sigma=1% => 2.326%.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "z", Nome = "z", ValorPadrao = 2.326, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 0.01, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "VaR", Calcular = v => v["mu"] + v["z"] * v["sigma"],
                Unidades = "",
            },
        ]);
    }

    // 20) Pesquisa Operacional
    private void AdicionarPesquisaOperacionalCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_po01", CodigoCompendio = "152", Nome = "Valor objetivo linear", Categoria = "Vol3: Pesquisa Operacional", SubCategoria = "Programacao Linear",
                Expressao = "z=c1 x1 + c2 x2", ExprTexto = "Funcao objetivo", Icone = "po",
                Descricao = "Avalia funcao objetivo de PL com 2 variaveis.", Criador = "George Dantzig", AnoOrigin = "1947",
                ExemploPratico = "c=(5,3), x=(4,2) => z=26.",
                Variaveis = [ new() { Simbolo = "c1", Nome = "c1", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x1", Nome = "x1", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "c2", Nome = "c2", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x2", Nome = "x2", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "z", Calcular = v => v["c1"] * v["x1"] + v["c2"] * v["x2"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_po02", CodigoCompendio = "153", Nome = "M/M/1 - numero medio no sistema", Categoria = "Vol3: Pesquisa Operacional", SubCategoria = "Filas",
                Expressao = "L=rho/(1-rho), rho=lambda/mu", ExprTexto = "Fila M/M/1", Icone = "po",
                Descricao = "Numero esperado de clientes no sistema.", Criador = "Kendall", AnoOrigin = "1953",
                ExemploPratico = "lambda=4,mu=5 => L=4.",
                Variaveis = [ new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 4, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 5, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "L", Calcular = v => {
                    double rho = v["lambda"] / v["mu"];
                    return rho / (1 - rho);
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_po03", CodigoCompendio = "154", Nome = "Lei de Little", Categoria = "Vol3: Pesquisa Operacional", SubCategoria = "Filas",
                Expressao = "W=L/lambda", ExprTexto = "Tempo medio no sistema", Icone = "po",
                Descricao = "Relaciona ocupacao media e tempo medio.", Criador = "John Little", AnoOrigin = "1961",
                ExemploPratico = "L=20, lambda=4 => W=5.",
                Variaveis = [ new() { Simbolo = "L", Nome = "L", ValorPadrao = 20, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 4, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "W", Calcular = v => v["L"] / v["lambda"],
                Unidades = "",
            },
        ]);
    }

    // 21) Ciencias do Clima
    private void AdicionarCienciasClimaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_cl01", CodigoCompendio = "155", Nome = "Parametro de Coriolis", Categoria = "Vol3: Ciencias do Clima", SubCategoria = "Atmosfera",
                Expressao = "f=2 Omega sin(phi)", ExprTexto = "Coriolis", Icone = "cl",
                Descricao = "Parametro dinamico atmosferico/oceanico.", Criador = "Gaspard Coriolis", AnoOrigin = "1835",
                ExemploPratico = "phi=45deg => f~1.03e-4 s^-1.",
                Variaveis = [ new() { Simbolo = "Omega", Nome = "Omega", ValorPadrao = 7.2921159e-5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "phi", Nome = "phi (rad)", ValorPadrao = Math.PI / 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "f", UnidadeResultado = "1/s", Calcular = v => 2 * v["Omega"] * Math.Sin(v["phi"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_cl02", CodigoCompendio = "156", Nome = "EBM 0D (taxa de aquecimento)", Categoria = "Vol3: Ciencias do Clima", SubCategoria = "Carbono e Clima",
                Expressao = "dTdt=(S(1-alpha)/4 - eps sigma T^4)/C", ExprTexto = "Balanco de energia", Icone = "cl",
                Descricao = "Modelo simples de clima global (0D).", Criador = "Budyko / Sellers", AnoOrigin = "1969",
                ExemploPratico = "Forcamento positivo => dTdt>0.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 1361, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "alpha", Nome = "alpha", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "eps", Nome = "eps", ValorPadrao = 1.0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigmaSB", Nome = "sigma", ValorPadrao = 5.670374419e-8, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 288, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "C", Nome = "C", ValorPadrao = 1e8, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dT/dt", Calcular = v => (v["S"] * (1 - v["alpha"]) / 4.0 - v["eps"] * v["sigmaSB"] * Math.Pow(v["T"], 4)) / v["C"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_cl03", CodigoCompendio = "157", Nome = "Sensibilidade climatica ECS", Categoria = "Vol3: Ciencias do Clima", SubCategoria = "Carbono e Clima",
                Expressao = "ECS=F2xCO2/|lambda|", ExprTexto = "Resposta de equilibrio", Icone = "cl",
                Descricao = "Aquecimento de equilibrio para duplicacao de CO2.", Criador = "Climatologia moderna", AnoOrigin = "Sec. XX",
                ExemploPratico = "F2x=3.7, lambda=-1 => ECS=3.7 C.",
                Variaveis = [ new() { Simbolo = "F2x", Nome = "F2xCO2", ValorPadrao = 3.7, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = -1.0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "ECS", UnidadeResultado = "degC", Calcular = v => v["F2x"] / Math.Abs(v["lambda"]),
                Unidades = "",
            },
        ]);
    }

    // 22) Bioinformatica
    private void AdicionarBioinformaticaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_bi01", CodigoCompendio = "158", Nome = "Needleman-Wunsch (passo local)", Categoria = "Vol3: Bioinformatica", SubCategoria = "Alinhamento",
                Expressao = "F(i,j)=max(diag+s, up-gap, left-gap)", ExprTexto = "Recorrencia global", Icone = "bio",
                Descricao = "Passo de DP para alinhamento global.", Criador = "Needleman-Wunsch", AnoOrigin = "1970",
                ExemploPratico = "diag=5,s=2,up=4,left=3,gap=2 => max(7,2,1)=7.",
                Variaveis = [ new() { Simbolo = "diag", Nome = "F(i-1,j-1)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "s", Nome = "score", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "up", Nome = "F(i-1,j)", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "left", Nome = "F(i,j-1)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "gap", Nome = "gap", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "F(i,j)", Calcular = v => Math.Max(v["diag"] + v["s"], Math.Max(v["up"] - v["gap"], v["left"] - v["gap"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_bi02", CodigoCompendio = "159", Nome = "Distancia de Jukes-Cantor", Categoria = "Vol3: Bioinformatica", SubCategoria = "Filogenia",
                Expressao = "d=-(3/4) ln(1-4p/3)", ExprTexto = "Correcao de substituicoes", Icone = "bio",
                Descricao = "Distancia evolutiva corrigida para multiplas mutacoes.", Criador = "Jukes-Cantor", AnoOrigin = "1969",
                ExemploPratico = "p=0.1 => d~0.107.",
                Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 0.74, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "d", Calcular = v => -0.75 * Math.Log(1 - 4 * v["p"] / 3.0),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ev01", CodigoCompendio = "160", Nome = "Equacao do replicador", Categoria = "Vol3: Bioinformatica", SubCategoria = "Dinamica Evolutiva",
                Expressao = "xdot_i = x_i (f_i - fbar)", ExprTexto = "Dinamica de frequencias", Icone = "bio",
                Descricao = "Evolucao de frequencia de estrategia i.", Criador = "Taylor-Jonker", AnoOrigin = "1978",
                ExemploPratico = "x=0.3,fi=1.2,fbar=1 => xdot=0.06.",
                Variaveis = [ new() { Simbolo = "x", Nome = "x_i", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fi", Nome = "f_i", ValorPadrao = 1.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fbar", Nome = "f_bar", ValorPadrao = 1.0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "xdot_i", Calcular = v => v["x"] * (v["fi"] - v["fbar"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_bs01", CodigoCompendio = "161", Nome = "FBA objetivo linear", Categoria = "Vol3: Bioinformatica", SubCategoria = "Biologia de Sistemas",
                Expressao = "max z=c^T v", ExprTexto = "Flux Balance Analysis", Icone = "bio",
                Descricao = "Valor de objetivo metabolico para fluxo candidato.", Criador = "Varma-Palsson", AnoOrigin = "1994",
                ExemploPratico = "c=(1,0.2), v=(10,5) => z=11.",
                Variaveis = [ new() { Simbolo = "c1", Nome = "c1", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "v1", Nome = "v1", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "c2", Nome = "c2", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "v2", Nome = "v2", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "z", Calcular = v => v["c1"] * v["v1"] + v["c2"] * v["v2"],
                Unidades = "",
            },
        ]);
    }

    // 23) Acustica e Vibroacustica
    private void AdicionarAcusticaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3_ac01", CodigoCompendio = "162", Nome = "Velocidade do som no ar", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Acustica Fundamental",
                Expressao = "c=331.3 sqrt(1+T/273)", ExprTexto = "Aproximacao no ar", Icone = "ac",
                Descricao = "Velocidade do som em funcao da temperatura em Celsius.", Criador = "Acustica classica", AnoOrigin = "Sec. XIX",
                ExemploPratico = "T=20C => c~343 m/s.",
                Variaveis = [ new() { Simbolo = "T", Nome = "T (C)", ValorPadrao = 20, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "c", UnidadeResultado = "m/s", Calcular = v => 331.3 * Math.Sqrt(1 + v["T"] / 273.0),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ac02", CodigoCompendio = "163", Nome = "SPL", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Acustica Fundamental",
                Expressao = "SPL=20 log10(prms/pref)", ExprTexto = "Nivel de pressao sonora", Icone = "ac",
                Descricao = "Nivel sonoro em dB relativo a 20 uPa.", Criador = "Acustica", AnoOrigin = "Sec. XX",
                ExemploPratico = "prms=0.2 Pa => SPL~80 dB.",
                Variaveis = [ new() { Simbolo = "prms", Nome = "p_rms", ValorPadrao = 0.2, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "pref", Nome = "p_ref", ValorPadrao = 20e-6, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "SPL", UnidadeResultado = "dB", Calcular = v => 20 * Math.Log10(v["prms"] / v["pref"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_ac03", CodigoCompendio = "164", Nome = "Sabine TR60", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Acustica de Salas",
                Expressao = "TR60=0.161 V/A", ExprTexto = "Tempo de reverberacao", Icone = "ac",
                Descricao = "Tempo para decaimento de 60 dB em sala.", Criador = "Wallace Sabine", AnoOrigin = "1898",
                ExemploPratico = "V=200, A=40 => TR60=0.805 s.",
                Variaveis = [ new() { Simbolo = "V", Nome = "V", ValorPadrao = 200, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "A", Nome = "A absorcao", ValorPadrao = 40, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "TR60", UnidadeResultado = "s", Calcular = v => 0.161 * v["V"] / v["A"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3_vb01", CodigoCompendio = "165", Nome = "Frequencia natural SDOF", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Vibracoes",
                Expressao = "omega_n=sqrt(k/m)", ExprTexto = "Sistema massa-mola", Icone = "ac",
                Descricao = "Frequencia natural angular de 1 GDL.", Criador = "Dinamica classica", AnoOrigin = "Sec. XVIII",
                ExemploPratico = "k=1000,m=10 => omega_n=10 rad/s.",
                Variaveis = [ new() { Simbolo = "k", Nome = "k", ValorPadrao = 1000, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "m", Nome = "m", ValorPadrao = 10, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "omega_n", UnidadeResultado = "rad/s", Calcular = v => Math.Sqrt(v["k"] / v["m"]),
                Unidades = "",
            },
        ]);
    }

    // Complemento literal do Volume III: formulas adicionais por item.
    private void AdicionarVolume3Complementos()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v3x_af04", Nome = "Lei do paralelogramo (lado esquerdo)", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Hilbert",
                Expressao = "||x+y||^2 + ||x-y||^2", ExprTexto = "Lado esquerdo da identidade", Icone = "||",
                Descricao = "Calcula o lado esquerdo da lei do paralelogramo para verificacao numerica.", Criador = "Jordan-von Neumann", AnoOrigin = "1935",
                ExemploPratico = "nxpy=5, nxmy=1 => 26.",
                Variaveis = [ new() { Simbolo = "nxpy", Nome = "||x+y||", ValorPadrao = 5, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nxmy", Nome = "||x-y||", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "LHS", Calcular = v => v["nxpy"] * v["nxpy"] + v["nxmy"] * v["nxmy"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_te02", Nome = "Espectro de matriz diagonal 2x2 (autovalores)", Categoria = "Vol3: Analise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "sigma(A)={a11,a22} para A diagonal", ExprTexto = "Autovalores de diagonal", Icone = "sigma",
                Descricao = "Para matriz diagonal 2x2, os autovalores sao os elementos da diagonal.", Criador = "Teoria espectral", AnoOrigin = "Sec. XX",
                ExemploPratico = "diag(2,5) => espectro {2,5}; resultado retorna maximo.",
                Variaveis = [ new() { Simbolo = "a11", Nome = "a11", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "a22", Nome = "a22", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "lambda_max", Calcular = v => Math.Max(v["a11"], v["a22"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_tm02", Nome = "Medida de contar em conjunto finito", Categoria = "Vol3: Teoria da Medida", SubCategoria = "Medidas",
                Expressao = "mu(A)=|A|", ExprTexto = "Counting measure", Icone = "mu",
                Descricao = "Medida de contar de conjunto finito.", Criador = "Medida discreta", AnoOrigin = "Sec. XIX",
                ExemploPratico = "|A|=17 => mu(A)=17.",
                Variaveis = [ new() { Simbolo = "cardA", Nome = "|A|", ValorPadrao = 17, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "mu(A)", Calcular = v => v["cardA"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_il02", Nome = "Fatou (limite inferior comparativo)", Categoria = "Vol3: Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "int liminf fn <= liminf int fn", ExprTexto = "Gap de Fatou", Icone = "int",
                Descricao = "Retorna diferenca liminf(int fn)-int(liminf fn), que deve ser >=0.", Criador = "Pierre Fatou", AnoOrigin = "1906",
                ExemploPratico = "se gap=0, ha convergencia no limite.",
                Variaveis = [ new() { Simbolo = "lhs", Nome = "int liminf fn", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rhs", Nome = "liminf int fn", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "gap", Calcular = v => v["rhs"] - v["lhs"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_tc03", Nome = "Adjuncao em Set (contagem simplificada)", Categoria = "Vol3: Teoria das Categorias", SubCategoria = "Construcao Universal",
                Expressao = "|Hom(AxB,C)|=|Hom(A,C^B)|", ExprTexto = "Correspondencia de cardinalidades", Icone = "cat",
                Descricao = "Verificacao numerica em cardinalidades finitas em Set: |C|^(|A||B|).", Criador = "Mac Lane", AnoOrigin = "1945",
                ExemploPratico = "|A|=2,|B|=3,|C|=2 => 2^6=64.",
                Variaveis = [ new() { Simbolo = "na", Nome = "|A|", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nb", Nome = "|B|", ValorPadrao = 3, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nc", Nome = "|C|", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "contagem", Calcular = v => Math.Pow(v["nc"], v["na"] * v["nb"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_an06", Nome = "Runge-Kutta 4 (um passo)", Categoria = "Vol3: Analise Numerica", SubCategoria = "EDOs",
                Expressao = "y_{n+1}=y_n+(k1+2k2+2k3+k4)/6", ExprTexto = "RK4", Icone = "num",
                Descricao = "Passo de RK4 a partir dos incrementos k1..k4 ja avaliados.", Criador = "Runge-Kutta", AnoOrigin = "1901",
                ExemploPratico = "k=(1,2,2,1), y=0 => y_next=1.6667.",
                Variaveis = [ new() { Simbolo = "y", Nome = "y_n", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k1", Nome = "k1", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k2", Nome = "k2", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k3", Nome = "k3", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k4", Nome = "k4", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "y_{n+1}", Calcular = v => v["y"] + (v["k1"] + 2 * v["k2"] + 2 * v["k3"] + v["k4"]) / 6.0,
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_an07", Nome = "Conjugado gradiente (alpha)", Categoria = "Vol3: Analise Numerica", SubCategoria = "Algebra Linear Numerica",
                Expressao = "alpha=(r^T r)/(d^T A d)", ExprTexto = "Passo do CG", Icone = "num",
                Descricao = "Passo do metodo do gradiente conjugado para matriz SPD.", Criador = "Hestenes-Stiefel", AnoOrigin = "1952",
                ExemploPratico = "rt_r=4, dtAd=20 => alpha=0.2.",
                Variaveis = [ new() { Simbolo = "rtr", Nome = "r^T r", ValorPadrao = 4, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dtAd", Nome = "d^T A d", ValorPadrao = 20, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "alpha", Calcular = v => v["rtr"] / v["dtAd"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ce03", Nome = "Curva eliptica - inclinacao tangente", Categoria = "Vol3: Geometria Algebrica", SubCategoria = "Curvas Elipticas",
                Expressao = "lambda=(3x1^2+a)/(2y1)", ExprTexto = "Dobramento de ponto", Icone = "ec",
                Descricao = "Inclinacao para P=Q no metodo corda-tangente.", Criador = "Weierstrass", AnoOrigin = "Sec. XIX",
                ExemploPratico = "x1=1,y1=2,a=-1 => lambda=0.5.",
                Variaveis = [ new() { Simbolo = "x1", Nome = "x1", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "y1", Nome = "y1", ValorPadrao = 2, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "a", Nome = "a", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "lambda", Calcular = v => (3 * v["x1"] * v["x1"] + v["a"]) / (2 * v["y1"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_lm02", Nome = "Formula booleana de compacidade (toy)", Categoria = "Vol3: Logica Matematica", SubCategoria = "Primeira Ordem",
                Expressao = "sat_global = prod sat_local_i", ExprTexto = "Agregacao finita", Icone = "log",
                Descricao = "Agrega satisfatibilidade de subconjuntos finitos em modelo toy (1/0).", Criador = "Godel", AnoOrigin = "1930",
                ExemploPratico = "1,1,0 => 0.",
                Variaveis = [ new() { Simbolo = "s1", Nome = "sat1", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "s2", Nome = "sat2", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "s3", Nome = "sat3", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "sat", Calcular = v => v["s1"] * v["s2"] * v["s3"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_mc03", Nome = "Coeficiente Hall classico", Categoria = "Vol3: Materia Condensada", SubCategoria = "Bandas",
                Expressao = "RH=-1/(n e)", ExprTexto = "Efeito Hall", Icone = "mc",
                Descricao = "Coeficiente Hall no modelo classico de um portador.", Criador = "Edwin Hall", AnoOrigin = "1879",
                ExemploPratico = "n=1e22 => RH pequeno e negativo para eletrons.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n", ValorPadrao = 1e22, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 1.602176634e-19, ValorMin = 1e-30, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "RH", Calcular = v => -1.0 / (v["n"] * v["e"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_sc02", Nome = "Comprimento de penetracao de London", Categoria = "Vol3: Materia Condensada", SubCategoria = "Supercondutividade BCS",
                Expressao = "lambdaL=sqrt(m c^2 /(4 pi ns e^2))", ExprTexto = "Efeito Meissner", Icone = "mc",
                Descricao = "Profundidade de penetracao de campo em supercondutor.", Criador = "London", AnoOrigin = "1935",
                ExemploPratico = "ns maior reduz lambdaL.",
                Variaveis = [ new() { Simbolo = "m", Nome = "m", ValorPadrao = 9.10938356e-31, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "c", Nome = "c", ValorPadrao = 299792458, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ns", Nome = "ns", ValorPadrao = 1e28, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 1.602176634e-19, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "lambdaL", Calcular = v => Math.Sqrt(v["m"] * v["c"] * v["c"] / (4 * Math.PI * v["ns"] * v["e"] * v["e"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ca02", Nome = "Bifurcacao pitchfork normal", Categoria = "Vol3: Caos e Fractais", SubCategoria = "Sistemas Dinamicos",
                Expressao = "xdot=mu x - x^3", ExprTexto = "Pitchfork", Icone = "chaos",
                Descricao = "Campo vetorial normal form de bifurcacao pitchfork.", Criador = "Teoria de bifurcacao", AnoOrigin = "Sec. XX",
                ExemploPratico = "mu=1,x=0.5 => xdot=0.375.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x", Nome = "x", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "xdot", Calcular = v => v["mu"] * v["x"] - Math.Pow(v["x"], 3),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_fr02", Nome = "Mandelbrot (1 iteracao)", Categoria = "Vol3: Caos e Fractais", SubCategoria = "Fractais",
                Expressao = "z1=z0^2+c", ExprTexto = "Modulo apos 1 passo", Icone = "chaos",
                Descricao = "Calcula |z1| para z0 e c reais simplificados.", Criador = "Benoit Mandelbrot", AnoOrigin = "1980",
                ExemploPratico = "z0=0,c=0.3 => |z1|=0.3.",
                Variaveis = [ new() { Simbolo = "z0", Nome = "z0 (real)", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "c", Nome = "c (real)", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "|z1|", Calcular = v => Math.Abs(v["z0"] * v["z0"] + v["c"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_pl03", Nome = "Beta de plasma", Categoria = "Vol3: Fisica de Plasmas", SubCategoria = "MHD",
                Expressao = "beta=2 mu0 p / B^2", ExprTexto = "Pressao termica x magnetica", Icone = "plasma",
                Descricao = "Compara contribuicao de pressao termica e magnetica.", Criador = "MHD", AnoOrigin = "Sec. XX",
                ExemploPratico = "beta>1: termica domina.",
                Variaveis = [ new() { Simbolo = "mu0", Nome = "mu0", ValorPadrao = 4e-7 * Math.PI, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "p", Nome = "p", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "B", Nome = "B", ValorPadrao = 0.01, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "beta", Calcular = v => 2 * v["mu0"] * v["p"] / (v["B"] * v["B"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_nu04", Nome = "Energia de ligacao por nucleon", Categoria = "Vol3: Fisica Nuclear", SubCategoria = "Estrutura Nuclear",
                Expressao = "B/A", ExprTexto = "Estabilidade nuclear", Icone = "nuc",
                Descricao = "Energia de ligacao media por nucleon.", Criador = "Weizsacker", AnoOrigin = "1935",
                ExemploPratico = "B=492 MeV, A=56 => 8.79 MeV/nucleon.",
                Variaveis = [ new() { Simbolo = "B", Nome = "B", ValorPadrao = 492, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "A", Nome = "A", ValorPadrao = 56, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "B/A", Calcular = v => v["B"] / v["A"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_oq04", Nome = "Poisson de estado coerente", Categoria = "Vol3: Optica Quantica", SubCategoria = "Laser",
                Expressao = "P(n)=exp(-mu) mu^n / n!", ExprTexto = "Distribuicao de fotons", Icone = "oq",
                Descricao = "Probabilidade de n fotons para media mu em estado coerente.", Criador = "Roy Glauber", AnoOrigin = "1963",
                ExemploPratico = "mu=2,n=2 => P~0.2707.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 2, ValorMin = 0, ValorMax = 20, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "P(n)", Calcular = v => {
                    int n = (int)Math.Round(v["n"]);
                    double fact = 1;
                    for (int i = 2; i <= n; i++) fact *= i;
                    return Math.Exp(-v["mu"]) * Math.Pow(v["mu"], n) / fact;
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_sv04", Nome = "Hazard Weibull", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Fundamentos",
                Expressao = "h(t)=lambda gamma (lambda t)^(gamma-1)", ExprTexto = "Hazard Weibull", Icone = "sv",
                Descricao = "Taxa de risco instantanea no modelo Weibull parametrizado por lambda e gamma.", Criador = "Waloddi Weibull", AnoOrigin = "1951",
                ExemploPratico = "gamma>1 hazard crescente.",
                Variaveis = [ new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 0.1, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "gamma", Nome = "gamma", ValorPadrao = 1.5, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "t", Nome = "t", ValorPadrao = 5, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "h(t)", Calcular = v => v["lambda"] * v["gamma"] * Math.Pow(v["lambda"] * v["t"], v["gamma"] - 1),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ve03", Nome = "CVaR normal (aprox)", Categoria = "Vol3: Valores Extremos e Copulas", SubCategoria = "Risco",
                Expressao = "CVaR=mu+sigma phi(z)/(1-alpha)", ExprTexto = "Expected shortfall normal", Icone = "ve",
                Descricao = "Estimativa de expected shortfall sob normalidade padrao.", Criador = "Gestao de risco", AnoOrigin = "Sec. XX",
                ExemploPratico = "alpha=0.99, z=2.326.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 0.01, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "z", Nome = "z", ValorPadrao = 2.326, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "alpha", Nome = "alpha", ValorPadrao = 0.99, ValorMin = 0.5, ValorMax = 0.9999, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "CVaR", Calcular = v => {
                    double phi = 0.3989422804014327 * Math.Exp(-0.5 * v["z"] * v["z"]);
                    return v["mu"] + v["sigma"] * phi / (1 - v["alpha"]);
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ge04", Nome = "Nugget (efeito pepita)", Categoria = "Vol3: Geoestatistica", SubCategoria = "Variograma",
                Expressao = "nugget=gamma(0+)", ExprTexto = "Variabilidade micro-escala", Icone = "geo",
                Descricao = "Semivariancia no limite de separacao zero.", Criador = "Matheron", AnoOrigin = "1963",
                ExemploPratico = "nugget alto indica ruido de medicao.",
                Variaveis = [ new() { Simbolo = "g0", Nome = "gamma(0+)", ValorPadrao = 0.2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "nugget", Calcular = v => v["g0"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_mf03", Nome = "Taxa de liberacao de energia", Categoria = "Vol3: Mecanica da Fratura", SubCategoria = "LEFM",
                Expressao = "G=KI^2 (1-nu^2)/E", ExprTexto = "Plano de deformacao", Icone = "eng",
                Descricao = "Taxa energetica de fratura para modo I.", Criador = "Irwin", AnoOrigin = "1957",
                ExemploPratico = "KI=30,nu=0.3,E=210000 MPa.",
                Variaveis = [ new() { Simbolo = "KI", Nome = "KI", ValorPadrao = 30, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nu", Nome = "nu", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 0.49, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "E", Nome = "E", ValorPadrao = 210000, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "G", Calcular = v => v["KI"] * v["KI"] * (1 - v["nu"] * v["nu"]) / v["E"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ns02", Nome = "Numero de Prandtl", Categoria = "Vol3: CFD e Turbulencia", SubCategoria = "Navier-Stokes",
                Expressao = "Pr=nu/alpha", ExprTexto = "Difusividade momento x termica", Icone = "cfd",
                Descricao = "Compara difusao de quantidade de movimento e calor.", Criador = "Ludwig Prandtl", AnoOrigin = "1904",
                ExemploPratico = "ar ~0.7, agua ~7.",
                Variaveis = [ new() { Simbolo = "nu", Nome = "nu", ValorPadrao = 1.5e-5, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "alpha", Nome = "alpha", ValorPadrao = 2.1e-5, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Pr", Calcular = v => v["nu"] / v["alpha"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_rb03", Nome = "Cinematica direta 2R (x)", Categoria = "Vol3: Robotica", SubCategoria = "Cinematica",
                Expressao = "x=l1 cos q1 + l2 cos(q1+q2)", ExprTexto = "Posicao x do efetuador", Icone = "rb",
                Descricao = "Componente x da cinematica direta de manipulador planar 2R.", Criador = "Robotica classica", AnoOrigin = "Sec. XX",
                ExemploPratico = "l1=l2=1,q1=0,q2=0 => x=2.",
                Variaveis = [ new() { Simbolo = "l1", Nome = "l1", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "l2", Nome = "l2", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "q1", Nome = "q1", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "q2", Nome = "q2", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "x", Calcular = v => v["l1"] * Math.Cos(v["q1"]) + v["l2"] * Math.Cos(v["q1"] + v["q2"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_sp04", Nome = "Potencia eletrica da maquina sincrona", Categoria = "Vol3: Sistemas de Potencia", SubCategoria = "Estabilidade",
                Expressao = "Pe=E' V / X' sin(delta)", ExprTexto = "Equacao classica", Icone = "pow",
                Descricao = "Potencia transferida em modelo de maquina sincrona simplificado.", Criador = "Teoria de potencia", AnoOrigin = "Sec. XX",
                ExemploPratico = "E'=1.1,V=1,X'=0.6,delta=30deg => Pe~0.916.",
                Variaveis = [ new() { Simbolo = "Ep", Nome = "E'", ValorPadrao = 1.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "V", Nome = "V", ValorPadrao = 1.0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Xp", Nome = "X'", ValorPadrao = 0.6, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "delta", Nome = "delta", ValorPadrao = Math.PI / 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Pe", Calcular = v => v["Ep"] * v["V"] * Math.Sin(v["delta"]) / v["Xp"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_gr02", Nome = "Delta de call (Black-Scholes)", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Gregas e Opcoes",
                Expressao = "Delta=N(d1)", ExprTexto = "Sensibilidade ao spot", Icone = "fin",
                Descricao = "Delta da call europeia no modelo BSM.", Criador = "Black-Scholes-Merton", AnoOrigin = "1973",
                ExemploPratico = "ATM com baixa taxa e 1 ano => Delta ~0.5.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 100, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "K", Nome = "K", ValorPadrao = 100, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "r", Nome = "r", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 0.2, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Delta", Calcular = v => {
                    double d1 = (Math.Log(v["S"] / v["K"]) + (v["r"] + 0.5 * v["sigma"] * v["sigma"]) * v["T"]) / (v["sigma"] * Math.Sqrt(v["T"]));
                    return NormCdf(d1);
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_po04", Nome = "Knapsack 0-1 (2 itens)", Categoria = "Vol3: Pesquisa Operacional", SubCategoria = "Programacao Inteira",
                Expressao = "valor=p1 x1 + p2 x2", ExprTexto = "Objetivo da mochila", Icone = "po",
                Descricao = "Avalia valor total de selecao binaria de 2 itens.", Criador = "Dantzig", AnoOrigin = "1957",
                ExemploPratico = "p=(10,7),x=(1,0) => 10.",
                Variaveis = [ new() { Simbolo = "p1", Nome = "p1", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x1", Nome = "x1", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "p2", Nome = "p2", ValorPadrao = 7, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x2", Nome = "x2", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "valor", Calcular = v => v["p1"] * v["x1"] + v["p2"] * v["x2"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_cl04", Nome = "Vento geostrofico (ug)", Categoria = "Vol3: Ciencias do Clima", SubCategoria = "Atmosfera",
                Expressao = "ug=-(1/(rho f)) dp/dy", ExprTexto = "Componente zonal geostrofica", Icone = "cl",
                Descricao = "Aproximacao geostrofica para escoamento de grande escala.", Criador = "Meteorologia dinamica", AnoOrigin = "Sec. XX",
                ExemploPratico = "dp/dy negativo gera ug positivo no hemisferio norte.",
                Variaveis = [ new() { Simbolo = "rho", Nome = "rho", ValorPadrao = 1.2, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "f", Nome = "f", ValorPadrao = 1e-4, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dpdy", Nome = "dp/dy", ValorPadrao = -0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "ug", Calcular = v => -(1.0 / (v["rho"] * v["f"])) * v["dpdy"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_bi03", Nome = "Hardy-Weinberg (heterozigoto)", Categoria = "Vol3: Bioinformatica", SubCategoria = "Dinamica Evolutiva",
                Expressao = "2pq", ExprTexto = "Frequencia Aa", Icone = "bio",
                Descricao = "Frequencia de heterozigotos no equilibrio HW.", Criador = "Hardy-Weinberg", AnoOrigin = "1908",
                ExemploPratico = "p=0.7,q=0.3 => 0.42.",
                Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "q", Nome = "q", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "2pq", Calcular = v => 2 * v["p"] * v["q"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ac04", Nome = "Modo de sala retangular", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Acustica de Salas",
                Expressao = "f_nmp=(c/2)*sqrt((n/Lx)^2+(m/Ly)^2+(p/Lz)^2)", ExprTexto = "Frequencia modal", Icone = "ac",
                Descricao = "Frequencias proprias acusticas de sala retangular.", Criador = "Acustica de salas", AnoOrigin = "Sec. XX",
                ExemploPratico = "modo (1,0,0) em Lx=5m com c=343 => 34.3 Hz.",
                Variaveis = [ new() { Simbolo = "c", Nome = "c", ValorPadrao = 343, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "m", Nome = "m", ValorPadrao = 0, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "p", Nome = "p", ValorPadrao = 0, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Lx", Nome = "Lx", ValorPadrao = 5, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Ly", Nome = "Ly", ValorPadrao = 4, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Lz", Nome = "Lz", ValorPadrao = 3, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "f_nmp", UnidadeResultado = "Hz", Calcular = v => (v["c"] / 2.0) * Math.Sqrt(Math.Pow(v["n"] / v["Lx"], 2) + Math.Pow(v["m"] / v["Ly"], 2) + Math.Pow(v["p"] / v["Lz"], 2)),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_sv05", Nome = "Kaplan-Meier (um evento)", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Kaplan-Meier",
                Expressao = "S*=S_prev*(1-d/n)", ExprTexto = "Atualizacao KM", Icone = "sv",
                Descricao = "Atualiza a curva KM em um tempo de evento.", Criador = "Kaplan-Meier", AnoOrigin = "1958",
                ExemploPratico = "S_prev=0.8,d=2,n=10 => S*=0.64.",
                Variaveis = [ new() { Simbolo = "Sprev", Nome = "S_prev", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "d", Nome = "d", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 10, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "S_new", Calcular = v => v["Sprev"] * (1 - v["d"] / v["n"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_sv06", Nome = "Greenwood (incremento)", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Kaplan-Meier",
                Expressao = "inc=d/(n(n-d))", ExprTexto = "Termo de Greenwood", Icone = "sv",
                Descricao = "Incremento da variancia de Greenwood por tempo de evento.", Criador = "Greenwood", AnoOrigin = "1926",
                ExemploPratico = "d=1,n=20 => 1/(20*19)=0.00263.",
                Variaveis = [ new() { Simbolo = "d", Nome = "d", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 20, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "inc", Calcular = v => v["d"] / (v["n"] * (v["n"] - v["d"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_sv07", Nome = "Log-rank (estatistica)", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Kaplan-Meier",
                Expressao = "chi2=(O-E)^2/V", ExprTexto = "Teste log-rank", Icone = "sv",
                Descricao = "Estatistica qui-quadrado de comparacao de curvas.", Criador = "Mantel", AnoOrigin = "1966",
                ExemploPratico = "O-E=4, V=8 => chi2=2.",
                Variaveis = [ new() { Simbolo = "OE", Nome = "O-E", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "V", Nome = "V", ValorPadrao = 8, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "chi2", Calcular = v => v["OE"] * v["OE"] / v["V"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_co02", Nome = "Copula de Gumbel", Categoria = "Vol3: Valores Extremos e Copulas", SubCategoria = "Copulas",
                Expressao = "C=exp(-(((-ln u)^theta+(-ln v)^theta)^(1/theta)))", ExprTexto = "Dependencia de cauda superior", Icone = "ve",
                Descricao = "Copula de Gumbel para modelar dependencia em extremos superiores.", Criador = "Gumbel-Hougaard", AnoOrigin = "1960",
                ExemploPratico = "u=0.8,v=0.9,theta=2.",
                Variaveis = [ new() { Simbolo = "u", Nome = "u", ValorPadrao = 0.8, ValorMin = 1e-6, ValorMax = 0.999999, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "v", Nome = "v", ValorPadrao = 0.9, ValorMin = 1e-6, ValorMax = 0.999999, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "theta", Nome = "theta", ValorPadrao = 2, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "C", Calcular = x => Math.Exp(-Math.Pow(Math.Pow(-Math.Log(x["u"]), x["theta"]) + Math.Pow(-Math.Log(x["v"]), x["theta"]), 1.0 / x["theta"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ge05", Nome = "Variancia de kriging", Categoria = "Vol3: Geoestatistica", SubCategoria = "Kriging",
                Expressao = "sigmaK2=gamma0^T lambda + mu", ExprTexto = "Incerteza da estimativa", Icone = "geo",
                Descricao = "Forma compacta da variancia de kriging ordinario (entrada agregada).", Criador = "Matheron", AnoOrigin = "1963",
                ExemploPratico = "term=0.7, mu=0.1 => 0.8.",
                Variaveis = [ new() { Simbolo = "term", Nome = "gamma0^T lambda", ValorPadrao = 0.7, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "sigmaK2", Calcular = v => v["term"] + v["mu"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_fd03", Nome = "Criterio de Goodman", Categoria = "Vol3: Mecanica da Fratura", SubCategoria = "Fadiga",
                Expressao = "sigmaa/Se + sigmam/Su", ExprTexto = "Falha quando >=1", Icone = "eng",
                Descricao = "Indice de utilizacao de fadiga com tensao media.", Criador = "John Goodman", AnoOrigin = "1899",
                ExemploPratico = "0.4+0.3=0.7 (seguro).",
                Variaveis = [ new() { Simbolo = "sigmaa", Nome = "sigma_a", ValorPadrao = 160, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Se", Nome = "Se", ValorPadrao = 400, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "sigmam", Nome = "sigma_m", ValorPadrao = 120, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Su", Nome = "Su", ValorPadrao = 800, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "indice", Calcular = v => v["sigmaa"] / v["Se"] + v["sigmam"] / v["Su"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ns03", Nome = "Numero de Nusselt", Categoria = "Vol3: CFD e Turbulencia", SubCategoria = "Navier-Stokes",
                Expressao = "Nu=hL/k", ExprTexto = "Transferencia convectiva adimensional", Icone = "cfd",
                Descricao = "Razao entre transferencia convectiva e condutiva.", Criador = "Wilhelm Nusselt", AnoOrigin = "1915",
                ExemploPratico = "h=50,L=0.1,k=0.6 => Nu=8.33.",
                Variaveis = [ new() { Simbolo = "h", Nome = "h", ValorPadrao = 50, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "L", Nome = "L", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k", Nome = "k", ValorPadrao = 0.6, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Nu", Calcular = v => v["h"] * v["L"] / v["k"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_rb04", Nome = "Indicador de singularidade Jacobiana", Categoria = "Vol3: Robotica", SubCategoria = "Cinematica",
                Expressao = "singular se |detJ|<eps", ExprTexto = "Teste numerico", Icone = "rb",
                Descricao = "Retorna 1 para singular e 0 para nao singular.", Criador = "Robotica classica", AnoOrigin = "Sec. XX",
                ExemploPratico = "detJ=1e-8, eps=1e-6 => singular.",
                Variaveis = [ new() { Simbolo = "detJ", Nome = "detJ", ValorPadrao = 1e-8, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "eps", Nome = "eps", ValorPadrao = 1e-6, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "isSingular", Calcular = v => Math.Abs(v["detJ"]) < v["eps"] ? 1 : 0,
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_sp05", Nome = "Passo Newton-Raphson (escalar)", Categoria = "Vol3: Sistemas de Potencia", SubCategoria = "Fluxo de Carga",
                Expressao = "x_new=x-old f/J", ExprTexto = "Atualizacao NR", Icone = "pow",
                Descricao = "Passo escalar do Newton-Raphson para mismatch de fluxo.", Criador = "Newton-Raphson", AnoOrigin = "Sec. XVII",
                ExemploPratico = "x=0.1,f=0.02,J=0.5 => x_new=0.06.",
                Variaveis = [ new() { Simbolo = "x", Nome = "x_old", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "f", Nome = "mismatch", ValorPadrao = 0.02, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "J", Nome = "Jacobiano", ValorPadrao = 0.5, ValorMin = 1e-12, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "x_new", Calcular = v => v["x"] - v["f"] / v["J"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_gr03", Nome = "Paridade put-call", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Gregas e Opcoes",
                Expressao = "C-P=S-Kexp(-rT)", ExprTexto = "Arbitragem", Icone = "fin",
                Descricao = "Relacao de arbitragem entre call e put europeias.", Criador = "Hans Stoll", AnoOrigin = "1969",
                ExemploPratico = "S=100,K=100,r=5%,T=1 => C-P=4.877.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "K", Nome = "K", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "r", Nome = "r", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "C-P", Calcular = v => v["S"] - v["K"] * Math.Exp(-v["r"] * v["T"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_fn02", Nome = "APT 2 fatores", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "CAPM e APT",
                Expressao = "E[Ri]=Rf+beta1 lambda1 + beta2 lambda2", ExprTexto = "Arbitrage Pricing Theory", Icone = "fin",
                Descricao = "Retorno esperado por modelo multifatorial simples.", Criador = "Stephen Ross", AnoOrigin = "1976",
                ExemploPratico = "Rf=3%, betas=(1.2,0.5), lambdas=(4%,2%) => 8.8%.",
                Variaveis = [ new() { Simbolo = "Rf", Nome = "Rf", ValorPadrao = 0.03, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b1", Nome = "beta1", ValorPadrao = 1.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "l1", Nome = "lambda1", ValorPadrao = 0.04, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b2", Nome = "beta2", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "l2", Nome = "lambda2", ValorPadrao = 0.02, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "E[Ri]", Calcular = v => v["Rf"] + v["b1"] * v["l1"] + v["b2"] * v["l2"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_cl05", Nome = "Relacao de dispersao de Rossby", Categoria = "Vol3: Ciencias do Clima", SubCategoria = "ENSO e Ondas",
                Expressao = "omega=-beta k/(k^2+l^2+1/R^2)", ExprTexto = "Onda de Rossby", Icone = "cl",
                Descricao = "Frequencia angular de ondas planetarias de Rossby.", Criador = "Carl-Gustaf Rossby", AnoOrigin = "1939",
                ExemploPratico = "beta pequeno => ondas lentas de grande escala.",
                Variaveis = [ new() { Simbolo = "beta", Nome = "beta", ValorPadrao = 2e-11, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k", Nome = "k", ValorPadrao = 1e-6, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "l", Nome = "l", ValorPadrao = 0.5e-6, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "R", Nome = "R", ValorPadrao = 1e6, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "omega", Calcular = v => -v["beta"] * v["k"] / (v["k"] * v["k"] + v["l"] * v["l"] + 1.0 / (v["R"] * v["R"])),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_cl06", Nome = "Oscilador ENSO atrasado", Categoria = "Vol3: Ciencias do Clima", SubCategoria = "ENSO e Ondas",
                Expressao = "dT/dt=b T(t)-c T(t-tau)", ExprTexto = "Modelo atrasado", Icone = "cl",
                Descricao = "Taxa de variacao de T em oscilador ENSO simplificado.", Criador = "Suarez-Schopf", AnoOrigin = "1988",
                ExemploPratico = "b=0.3,c=0.2,T=1,Tlag=0.6 => dT/dt=0.18.",
                Variaveis = [ new() { Simbolo = "b", Nome = "b", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "T", Nome = "T(t)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "c", Nome = "c", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "Tlag", Nome = "T(t-tau)", ValorPadrao = 0.6, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dT/dt", Calcular = v => v["b"] * v["T"] - v["c"] * v["Tlag"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_bi04", Nome = "BLAST E-value", Categoria = "Vol3: Bioinformatica", SubCategoria = "Alinhamento",
                Expressao = "E=m n exp(-lambda S)", ExprTexto = "Hits esperados ao acaso", Icone = "bio",
                Descricao = "Valor esperado de alinhamentos com score >=S por acaso.", Criador = "Altschul et al.", AnoOrigin = "1990",
                ExemploPratico = "E<1e-5 geralmente significativo.",
                Variaveis = [ new() { Simbolo = "m", Nome = "m", ValorPadrao = 1000, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1e6, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 0.267, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "S", Nome = "S", ValorPadrao = 50, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "E-value", Calcular = v => v["m"] * v["n"] * Math.Exp(-v["lambda"] * v["S"]),
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ev02", Nome = "Equacao de Price (termo de selecao)", Categoria = "Vol3: Bioinformatica", SubCategoria = "Dinamica Evolutiva",
                Expressao = "DeltaZ=Cov(w,z)/wbar", ExprTexto = "Termo principal de selecao", Icone = "bio",
                Descricao = "Contribuicao de selecao para mudanca media de traço.", Criador = "George Price", AnoOrigin = "1970",
                ExemploPratico = "Cov=0.12,wbar=1.5 => 0.08.",
                Variaveis = [ new() { Simbolo = "cov", Nome = "Cov(w,z)", ValorPadrao = 0.12, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "wbar", Nome = "wbar", ValorPadrao = 1.5, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "DeltaZ", Calcular = v => v["cov"] / v["wbar"],
                Unidades = "",
            },
            new Formula
            {
                Id = "v3x_ac05", Nome = "Intensidade acustica", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Acustica Fundamental",
                Expressao = "I=prms^2/(rho c)", ExprTexto = "Fluxo de energia sonora", Icone = "ac",
                Descricao = "Intensidade sonora media em onda plana.", Criador = "Acustica classica", AnoOrigin = "Sec. XIX",
                ExemploPratico = "prms=0.2,rho=1.2,c=343 => I~9.7e-5 W/m2.",
                Variaveis = [ new() { Simbolo = "prms", Nome = "prms", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rho", Nome = "rho", ValorPadrao = 1.2, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "c", Nome = "c", ValorPadrao = 343, ValorMin = 1e-9, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "I", UnidadeResultado = "W/m2", Calcular = v => v["prms"] * v["prms"] / (v["rho"] * v["c"]),
                Unidades = "",
            },
        ]);
    }
}
