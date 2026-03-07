using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // Pacote final para fechar cobertura do Volume III com formulas calculaveis.
    private void AdicionarVolume3FechamentoTotal()
    {
        _formulas.AddRange([
            // Analise funcional e medida
            new Formula
            {
                Id = "v3z_af06", Nome = "AF6 Holder - cota do produto integral", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Banach",
                Expressao = "int|fg| <= ||f||p ||g||q", ExprTexto = "Cota de Holder", Icone = "v3",
                Descricao = "Retorna a cota superior do produto integral pela desigualdade de Holder.", Criador = "Otto Holder", AnoOrigin = "1889",
                ExemploPratico = "nf=2.5, ng=4.0 => cota 10.",
                Variaveis = [ new() { Simbolo = "nf", Nome = "||f||p", ValorPadrao = 2.5, ValorMin = 0 }, new() { Simbolo = "ng", Nome = "||g||q", ValorPadrao = 4.0, ValorMin = 0 } ],
                VariavelResultado = "cota", Calcular = v => v["nf"] * v["ng"]
            },
            new Formula
            {
                Id = "v3z_af07", Nome = "AF7 Minkowski - lado direito", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Banach",
                Expressao = "||f+g||p <= ||f||p + ||g||p", ExprTexto = "Cota Minkowski", Icone = "v3",
                Descricao = "Retorna a cota da norma da soma em Lp.", Criador = "Hermann Minkowski", AnoOrigin = "1896",
                ExemploPratico = "nf=3, ng=5 => cota 8.",
                Variaveis = [ new() { Simbolo = "nf", Nome = "||f||p", ValorPadrao = 3, ValorMin = 0 }, new() { Simbolo = "ng", Nome = "||g||p", ValorPadrao = 5, ValorMin = 0 } ],
                VariavelResultado = "cota", Calcular = v => v["nf"] + v["ng"]
            },
            new Formula
            {
                Id = "v3z_ah10", Nome = "AH10 Parseval (soma de coeficientes)", Categoria = "Vol3: Analise Funcional", SubCategoria = "Espacos de Hilbert",
                Expressao = "||x||^2 = sum |<x,ei>|^2", ExprTexto = "Parseval", Icone = "v3",
                Descricao = "Calcula a soma quadratica de tres coeficientes de Fourier.", Criador = "Marc-Antoine Parseval", AnoOrigin = "1799",
                ExemploPratico = "c=(3,4,12) => norma^2=169.",
                Variaveis = [ new() { Simbolo = "c1", Nome = "coef 1", ValorPadrao = 3 }, new() { Simbolo = "c2", Nome = "coef 2", ValorPadrao = 4 }, new() { Simbolo = "c3", Nome = "coef 3", ValorPadrao = 12 } ],
                VariavelResultado = "norma2", Calcular = v => v["c1"] * v["c1"] + v["c2"] * v["c2"] + v["c3"] * v["c3"]
            },
            new Formula
            {
                Id = "v3z_tm07", Nome = "TM7 Continuidade por cima (delta)", Categoria = "Vol3: Teoria da Medida", SubCategoria = "sigma-algebras e medidas",
                Expressao = "An decresce A => mu(An)->mu(A)", ExprTexto = "Delta de convergencia", Icone = "v3",
                Descricao = "Retorna diferenca |mu(An)-mu(A)| para verificar convergencia por cima.", Criador = "Caratheodory", AnoOrigin = "1914",
                ExemploPratico = "muAn=2.01, muA=2 => delta 0.01.",
                Variaveis = [ new() { Simbolo = "muAn", Nome = "mu(An)", ValorPadrao = 2.01, ValorMin = 0 }, new() { Simbolo = "muA", Nome = "mu(A)", ValorPadrao = 2, ValorMin = 0 } ],
                VariavelResultado = "delta", Calcular = v => Math.Abs(v["muAn"] - v["muA"])
            },
            new Formula
            {
                Id = "v3z_il06", Nome = "IL6 Fubini (soma separavel)", Categoria = "Vol3: Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "int int f(x,y)=int g(x) int h(y)", ExprTexto = "Fubini em caso separavel", Icone = "v3",
                Descricao = "Caso f(x,y)=g(x)h(y): integral dupla e produto das integrais.", Criador = "Guido Fubini", AnoOrigin = "1907",
                ExemploPratico = "Ig=3, Ih=4 => I2D=12.",
                Variaveis = [ new() { Simbolo = "Ig", Nome = "int g", ValorPadrao = 3 }, new() { Simbolo = "Ih", Nome = "int h", ValorPadrao = 4 } ],
                VariavelResultado = "I2D", Calcular = v => v["Ig"] * v["Ih"]
            },
            new Formula
            {
                Id = "v3z_rn04", Nome = "RN4 Dual Lp-Lq (funcional)", Categoria = "Vol3: Teoria da Medida", SubCategoria = "Radon-Nikodym",
                Expressao = "f(x)=int x(t) y(t) dt", ExprTexto = "Emparelhamento dual", Icone = "v3",
                Descricao = "Emparelhamento dual simplificado por soma discreta de 3 pontos.", Criador = "Riesz", AnoOrigin = "1910",
                ExemploPratico = "x=(1,2,3), y=(4,5,6) => 32.",
                Variaveis = [ new() { Simbolo = "x1", Nome = "x1", ValorPadrao = 1 }, new() { Simbolo = "x2", Nome = "x2", ValorPadrao = 2 }, new() { Simbolo = "x3", Nome = "x3", ValorPadrao = 3 }, new() { Simbolo = "y1", Nome = "y1", ValorPadrao = 4 }, new() { Simbolo = "y2", Nome = "y2", ValorPadrao = 5 }, new() { Simbolo = "y3", Nome = "y3", ValorPadrao = 6 } ],
                VariavelResultado = "<x,y>", Calcular = v => v["x1"] * v["y1"] + v["x2"] * v["y2"] + v["x3"] * v["y3"]
            },

            // Categorias, numerica, geometria, logica
            new Formula
            {
                Id = "v3z_tc11", Nome = "TC11 Yoneda (contagem em Set)", Categoria = "Vol3: Teoria das Categorias", SubCategoria = "Construcoes Universais",
                Expressao = "Nat(Hom(A,-),F) ~= F(A)", ExprTexto = "Lema de Yoneda", Icone = "v3",
                Descricao = "No caso finito em Set, retorna cardinalidade F(A).", Criador = "Nobuo Yoneda", AnoOrigin = "1954",
                ExemploPratico = "|F(A)|=9.",
                Variaveis = [ new() { Simbolo = "FA", Nome = "|F(A)|", ValorPadrao = 9, ValorMin = 0 } ],
                VariavelResultado = "card", Calcular = v => v["FA"]
            },
            new Formula
            {
                Id = "v3z_an08", Nome = "AN8 Erro trapezio (modulo)", Categoria = "Vol3: Analise Numerica", SubCategoria = "Integracao Numerica",
                Expressao = "E=-(b-a)h^2 f''(xi)/12", ExprTexto = "Erro do trapezio", Icone = "v3",
                Descricao = "Calcula modulo do erro de trapezio com derivada segunda estimada.", Criador = "Newton-Cotes", AnoOrigin = "Sec. XVIII",
                ExemploPratico = "(b-a)=2,h=0.1,f2=5 => erro~0.0083.",
                Variaveis = [ new() { Simbolo = "L", Nome = "(b-a)", ValorPadrao = 2, ValorMin = 0 }, new() { Simbolo = "h", Nome = "h", ValorPadrao = 0.1, ValorMin = 0 }, new() { Simbolo = "f2", Nome = "f''(xi)", ValorPadrao = 5 } ],
                VariavelResultado = "|E|", Calcular = v => Math.Abs(-(v["L"] * v["h"] * v["h"] * v["f2"]) / 12.0)
            },
            new Formula
            {
                Id = "v3z_an10", Nome = "AN10 Erro Simpson (modulo)", Categoria = "Vol3: Analise Numerica", SubCategoria = "Integracao Numerica",
                Expressao = "E=-(b-a)h^4 f''''(xi)/180", ExprTexto = "Erro de Simpson", Icone = "v3",
                Descricao = "Calcula modulo do erro de Simpson com derivada quarta estimada.", Criador = "Thomas Simpson", AnoOrigin = "1743",
                ExemploPratico = "L=2,h=0.1,f4=8 => ~8.9e-5.",
                Variaveis = [ new() { Simbolo = "L", Nome = "(b-a)", ValorPadrao = 2, ValorMin = 0 }, new() { Simbolo = "h", Nome = "h", ValorPadrao = 0.1, ValorMin = 0 }, new() { Simbolo = "f4", Nome = "f''''(xi)", ValorPadrao = 8 } ],
                VariavelResultado = "|E|", Calcular = v => Math.Abs(-(v["L"] * Math.Pow(v["h"], 4) * v["f4"]) / 180.0)
            },
            new Formula
            {
                Id = "v3z_an18", Nome = "AN18 Adams-Bashforth 4 passos", Categoria = "Vol3: Analise Numerica", SubCategoria = "EDOs Numericas",
                Expressao = "y_{n+1}=y_n+h/24(55fn-59fn1+37fn2-9fn3)", ExprTexto = "AB4", Icone = "v3",
                Descricao = "Atualizacao explicita de quarta ordem com historico de derivadas.", Criador = "Adams-Bashforth", AnoOrigin = "1883",
                ExemploPratico = "yn=1,h=0.1, fn=(2,1.5,1.3,1.1) => 1.1867.",
                Variaveis = [ new() { Simbolo = "yn", Nome = "y_n", ValorPadrao = 1 }, new() { Simbolo = "h", Nome = "h", ValorPadrao = 0.1 }, new() { Simbolo = "fn", Nome = "f_n", ValorPadrao = 2 }, new() { Simbolo = "fn1", Nome = "f_{n-1}", ValorPadrao = 1.5 }, new() { Simbolo = "fn2", Nome = "f_{n-2}", ValorPadrao = 1.3 }, new() { Simbolo = "fn3", Nome = "f_{n-3}", ValorPadrao = 1.1 } ],
                VariavelResultado = "y_{n+1}", Calcular = v => v["yn"] + (v["h"] / 24.0) * (55 * v["fn"] - 59 * v["fn1"] + 37 * v["fn2"] - 9 * v["fn3"])
            },
            new Formula
            {
                Id = "v3z_ga05", Nome = "GA5 Bezout (contagem teorica)", Categoria = "Vol3: Geometria Algebrica", SubCategoria = "Variedades Algebricas",
                Expressao = "N=deg(f)deg(g)", ExprTexto = "Intersecoes com multiplicidade", Icone = "v3",
                Descricao = "Contagem teorica de intersecoes em caso generico plano projetivo.", Criador = "Etienne Bezout", AnoOrigin = "1779",
                ExemploPratico = "deg 3 e 4 => 12.",
                Variaveis = [ new() { Simbolo = "df", Nome = "deg(f)", ValorPadrao = 3, ValorMin = 0 }, new() { Simbolo = "dg", Nome = "deg(g)", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "N", Calcular = v => v["df"] * v["dg"]
            },
            new Formula
            {
                Id = "v3z_ce10", Nome = "CE10 Dificuldade ECDLP (bits)", Categoria = "Vol3: Geometria Algebrica", SubCategoria = "Curvas Elipticas",
                Expressao = "seguranca ~ log2(n)/2", ExprTexto = "Estimativa rho de Pollard", Icone = "v3",
                Descricao = "Estimativa de seguranca em bits para ordem n do grupo (ataque sqrt(n)).", Criador = "Pollard", AnoOrigin = "1978",
                ExemploPratico = "n~2^256 => seguranca ~128 bits.",
                Variaveis = [ new() { Simbolo = "bitsN", Nome = "log2(n)", ValorPadrao = 256, ValorMin = 1 } ],
                VariavelResultado = "bitsSeg", Calcular = v => v["bitsN"] / 2.0
            },
            new Formula
            {
                Id = "v3z_g1", Nome = "G1 Incompletude (indicador toy)", Categoria = "Vol3: Logica Matematica", SubCategoria = "Incompletude de Godel",
                Expressao = "ind=consistente*rica", ExprTexto = "Condicao para existencia de sentenca indecidivel", Icone = "v3",
                Descricao = "Indicador didatico: 1 quando premissas do teorema estao ativas no modelo simplificado.", Criador = "Kurt Godel", AnoOrigin = "1931",
                ExemploPratico = "cons=1,rica=1 => 1.",
                Variaveis = [ new() { Simbolo = "cons", Nome = "consistente", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "rica", Nome = "contendo aritmetica", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "ind", Calcular = v => v["cons"] * v["rica"]
            },

            // Fisica avancada
            new Formula
            {
                Id = "v3z_sc01", Nome = "SC1 Temperatura critica BCS", Categoria = "Vol3: Materia Condensada", SubCategoria = "Supercondutividade BCS",
                Expressao = "Tc=(1.13 hbar omegaD/kB) exp(-1/(N0V))", ExprTexto = "Transicao supercondutora", Icone = "v3",
                Descricao = "Temperatura critica no modelo BCS fraco acoplamento.", Criador = "Bardeen-Cooper-Schrieffer", AnoOrigin = "1957",
                ExemploPratico = "N0V maior eleva Tc exponencialmente.",
                Variaveis = [ new() { Simbolo = "hbar", Nome = "hbar", ValorPadrao = 1.054571817e-34 }, new() { Simbolo = "omegaD", Nome = "omegaD", ValorPadrao = 5e13, ValorMin = 1 }, new() { Simbolo = "kB", Nome = "kB", ValorPadrao = 1.380649e-23 }, new() { Simbolo = "N0V", Nome = "N(0)V", ValorPadrao = 0.3, ValorMin = 1e-6 } ],
                VariavelResultado = "Tc", UnidadeResultado = "K", Calcular = v => (1.13 * v["hbar"] * v["omegaD"] / v["kB"]) * Math.Exp(-1.0 / v["N0V"])
            },
            new Formula
            {
                Id = "v3z_fn02", Nome = "FN2 Debye integral (aprox discreta)", Categoria = "Vol3: Materia Condensada", SubCategoria = "Fonons",
                Expressao = "Cv=9NkB(T/thetaD)^3 * I", ExprTexto = "Modelo de Debye", Icone = "v3",
                Descricao = "Calcula Cv a partir do valor numerico I da integral de Debye.", Criador = "Peter Debye", AnoOrigin = "1912",
                ExemploPratico = "N=1, T/theta=0.1, I=6.49.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N", ValorPadrao = 1, ValorMin = 0 }, new() { Simbolo = "kB", Nome = "kB", ValorPadrao = 1.380649e-23 }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 30, ValorMin = 0.001 }, new() { Simbolo = "thetaD", Nome = "thetaD", ValorPadrao = 300, ValorMin = 0.001 }, new() { Simbolo = "I", Nome = "integral Debye", ValorPadrao = 6.49, ValorMin = 0 } ],
                VariavelResultado = "Cv", Calcular = v => 9 * v["N"] * v["kB"] * Math.Pow(v["T"] / v["thetaD"], 3) * v["I"]
            },
            new Formula
            {
                Id = "v3z_lz07", Nome = "LZ7 Dimensao Kaplan-Yorke", Categoria = "Vol3: Caos e Fractais", SubCategoria = "Atratores de Lorenz",
                Expressao = "dKY=j+(sum_{i<=j} li)/|l_{j+1}|", ExprTexto = "Dimensao fractal dinamica", Icone = "v3",
                Descricao = "Dimensao de Kaplan-Yorke para 3 expoentes de Lyapunov.", Criador = "Kaplan-Yorke", AnoOrigin = "1979",
                ExemploPratico = "l=(0.9,0,-14.5) => ~2.06.",
                Variaveis = [ new() { Simbolo = "l1", Nome = "lambda1", ValorPadrao = 0.9 }, new() { Simbolo = "l2", Nome = "lambda2", ValorPadrao = 0.0 }, new() { Simbolo = "l3", Nome = "lambda3", ValorPadrao = -14.5 } ],
                VariavelResultado = "dKY", Calcular = v => 2.0 + (v["l1"] + v["l2"]) / Math.Abs(v["l3"])
            },
            new Formula
            {
                Id = "v3z_pl04", Nome = "PL4 Criterio de plasma (Lambda)", Categoria = "Vol3: Fisica de Plasmas", SubCategoria = "Fundamentos",
                Expressao = "Lambda=n lambdaD^3", ExprTexto = "Parametro de plasma", Icone = "v3",
                Descricao = "Numero de particulas por esfera de Debye; idealmente muito maior que 1.", Criador = "Langmuir", AnoOrigin = "1929",
                ExemploPratico = "n=1e18, lambdaD=1e-4 => Lambda=1e6.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n", ValorPadrao = 1e18, ValorMin = 0 }, new() { Simbolo = "lambdaD", Nome = "lambdaD", ValorPadrao = 1e-4, ValorMin = 0 } ],
                VariavelResultado = "Lambda", Calcular = v => v["n"] * Math.Pow(v["lambdaD"], 3)
            },
            new Formula
            {
                Id = "v3z_nu10", Nome = "NU10 Taxa de reacoes por secao de choque", Categoria = "Vol3: Fisica Nuclear", SubCategoria = "Reacoes e Decaimentos",
                Expressao = "N=sigma I n L", ExprTexto = "Taxa de colisoes", Icone = "v3",
                Descricao = "Taxa de reacao nucleares em alvo fino.", Criador = "Fisica de colisoes", AnoOrigin = "Sec. XX",
                ExemploPratico = "sigma=1e-28, I=1e12, n=1e24, L=1e-3 => 1e5.",
                Variaveis = [ new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 1e-28 }, new() { Simbolo = "I", Nome = "I", ValorPadrao = 1e12 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1e24 }, new() { Simbolo = "L", Nome = "L", ValorPadrao = 1e-3 } ],
                VariavelResultado = "N", Calcular = v => v["sigma"] * v["I"] * v["n"] * v["L"]
            },
            new Formula
            {
                Id = "v3z_oq10", Nome = "OQ10 Ganho saturado do laser", Categoria = "Vol3: Optica Quantica", SubCategoria = "Estados coerentes e laser",
                Expressao = "g=g0/(1+((nu-nu0)^2/DeltaNu^2)) * 1/(1+I/Isat)", ExprTexto = "Perfil Lorentz + saturacao", Icone = "v3",
                Descricao = "Ganho espectral com alargamento e saturacao de intensidade.", Criador = "Teoria de laser", AnoOrigin = "Sec. XX",
                ExemploPratico = "Na ressonancia e baixa I, ganho ~g0.",
                Variaveis = [ new() { Simbolo = "g0", Nome = "g0", ValorPadrao = 10 }, new() { Simbolo = "nu", Nome = "nu", ValorPadrao = 100 }, new() { Simbolo = "nu0", Nome = "nu0", ValorPadrao = 100 }, new() { Simbolo = "DeltaNu", Nome = "DeltaNu", ValorPadrao = 5, ValorMin = 1e-9 }, new() { Simbolo = "I", Nome = "I", ValorPadrao = 1 }, new() { Simbolo = "Isat", Nome = "Isat", ValorPadrao = 10, ValorMin = 1e-9 } ],
                VariavelResultado = "g", Calcular = v => v["g0"] / (1 + Math.Pow((v["nu"] - v["nu0"]) / v["DeltaNu"], 2)) / (1 + v["I"] / v["Isat"])
            },

            // Estatistica, engenharia, financas, PO, clima, bio, acustica
            new Formula
            {
                Id = "v3z_sv06", Nome = "SV6 Sobrevivencia Weibull", Categoria = "Vol3: Analise de Sobrevivencia", SubCategoria = "Funcoes Fundamentais",
                Expressao = "S(t)=exp(-(lambda t)^gamma)", ExprTexto = "Sobrevivencia Weibull", Icone = "v3",
                Descricao = "Sobrevivencia no modelo Weibull com forma gamma.", Criador = "Waloddi Weibull", AnoOrigin = "1951",
                ExemploPratico = "lambda=0.1,gamma=2,t=5 => S~0.7788.",
                Variaveis = [ new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 0.1, ValorMin = 1e-9 }, new() { Simbolo = "gamma", Nome = "gamma", ValorPadrao = 2, ValorMin = 1e-9 }, new() { Simbolo = "t", Nome = "t", ValorPadrao = 5, ValorMin = 0 } ],
                VariavelResultado = "S(t)", Calcular = v => Math.Exp(-Math.Pow(v["lambda"] * v["t"], v["gamma"]))
            },
            new Formula
            {
                Id = "v3z_ve07", Nome = "VE7 Value at Risk por quantil", Categoria = "Vol3: Valores Extremos e Copulas", SubCategoria = "Valores Extremos",
                Expressao = "VaR_alpha=quantil", ExprTexto = "Entrada direta de quantil", Icone = "v3",
                Descricao = "Modelo operacional quando o quantil ja foi estimado externamente.", Criador = "Gestao de risco", AnoOrigin = "Sec. XX",
                ExemploPratico = "quantil=2.4% => VaR=2.4%.",
                Variaveis = [ new() { Simbolo = "q", Nome = "quantil", ValorPadrao = 0.024 } ],
                VariavelResultado = "VaR", Calcular = v => v["q"]
            },
            new Formula
            {
                Id = "v3z_ge10", Nome = "GE10 Variancia de kriging (forma linear)", Categoria = "Vol3: Geoestatistica", SubCategoria = "Kriging",
                Expressao = "sigmaK2=gamma0^T lambda + mu", ExprTexto = "Incerteza do kriging", Icone = "v3",
                Descricao = "Forma reduzida do erro de estimacao por kriging.", Criador = "Matheron", AnoOrigin = "1963",
                ExemploPratico = "term=0.9,mu=0.2 => 1.1.",
                Variaveis = [ new() { Simbolo = "term", Nome = "gamma0^T lambda", ValorPadrao = 0.9 }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 0.2 } ],
                VariavelResultado = "sigmaK2", Calcular = v => v["term"] + v["mu"]
            },
            new Formula
            {
                Id = "v3z_fd02", Nome = "FD2 Limite de fadiga corrigido", Categoria = "Vol3: Mecanica da Fratura", SubCategoria = "Fadiga",
                Expressao = "Se=ka kb kc kd ke Se'", ExprTexto = "Correcao de superficie/tamanho/carga", Icone = "v3",
                Descricao = "Limite de fadiga corrigido por fatores empiricos.", Criador = "Shigley", AnoOrigin = "Sec. XX",
                ExemploPratico = "fatores 0.8,0.9,1,1,0.95 e Se'=300 => 205.2.",
                Variaveis = [ new() { Simbolo = "ka", Nome = "ka", ValorPadrao = 0.8 }, new() { Simbolo = "kb", Nome = "kb", ValorPadrao = 0.9 }, new() { Simbolo = "kc", Nome = "kc", ValorPadrao = 1 }, new() { Simbolo = "kd", Nome = "kd", ValorPadrao = 1 }, new() { Simbolo = "ke", Nome = "ke", ValorPadrao = 0.95 }, new() { Simbolo = "Sep", Nome = "Se'", ValorPadrao = 300 } ],
                VariavelResultado = "Se", Calcular = v => v["ka"] * v["kb"] * v["kc"] * v["kd"] * v["ke"] * v["Sep"]
            },
            new Formula
            {
                Id = "v3z_tb09", Nome = "TB9 Smagorinsky nu_sgs", Categoria = "Vol3: CFD e Turbulencia", SubCategoria = "Modelos de Turbulencia",
                Expressao = "nu_sgs=Cs^2 Delta^2 |S|", ExprTexto = "LES sub-grade", Icone = "v3",
                Descricao = "Viscosidade sub-malha no modelo de Smagorinsky.", Criador = "Smagorinsky", AnoOrigin = "1963",
                ExemploPratico = "Cs=0.17,Delta=0.02,S=100 => 0.01156.",
                Variaveis = [ new() { Simbolo = "Cs", Nome = "Cs", ValorPadrao = 0.17, ValorMin = 0 }, new() { Simbolo = "Delta", Nome = "Delta", ValorPadrao = 0.02, ValorMin = 0 }, new() { Simbolo = "Sabs", Nome = "|S|", ValorPadrao = 100, ValorMin = 0 } ],
                VariavelResultado = "nu_sgs", Calcular = v => v["Cs"] * v["Cs"] * v["Delta"] * v["Delta"] * v["Sabs"]
            },
            new Formula
            {
                Id = "v3z_rb13", Nome = "RB13 Torque computado (1 GDL)", Categoria = "Vol3: Robotica", SubCategoria = "Dinamica",
                Expressao = "tau=M(qdd_d+Kv edot+Kp e)+C+G", ExprTexto = "Controle inverso simplificado", Icone = "v3",
                Descricao = "Lei de torque computado em 1 grau de liberdade.", Criador = "Robotica moderna", AnoOrigin = "Sec. XX",
                ExemploPratico = "M=2,qdd=1,Kv=10,edot=0.1,Kp=50,e=0.02,C=0.3,G=1 => 5.3.",
                Variaveis = [ new() { Simbolo = "M", Nome = "M", ValorPadrao = 2 }, new() { Simbolo = "qdd", Nome = "qdd_d", ValorPadrao = 1 }, new() { Simbolo = "Kv", Nome = "Kv", ValorPadrao = 10 }, new() { Simbolo = "edot", Nome = "edot", ValorPadrao = 0.1 }, new() { Simbolo = "Kp", Nome = "Kp", ValorPadrao = 50 }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 0.02 }, new() { Simbolo = "C", Nome = "C", ValorPadrao = 0.3 }, new() { Simbolo = "G", Nome = "G", ValorPadrao = 1 } ],
                VariavelResultado = "tau", Calcular = v => v["M"] * (v["qdd"] + v["Kv"] * v["edot"] + v["Kp"] * v["e"]) + v["C"] + v["G"]
            },
            new Formula
            {
                Id = "v3z_sp07", Nome = "SP7 Potencia de curto em base", Categoria = "Vol3: Sistemas de Potencia", SubCategoria = "Curto-Circuito",
                Expressao = "MVAcc=MVAbase/Zpu", ExprTexto = "Capacidade de curto", Icone = "v3",
                Descricao = "Converte impedancia por unidade em potencia de curto-circuito.", Criador = "Sistemas de potencia", AnoOrigin = "Sec. XX",
                ExemploPratico = "base=100, Zpu=0.2 => 500 MVA.",
                Variaveis = [ new() { Simbolo = "base", Nome = "MVAbase", ValorPadrao = 100, ValorMin = 1e-9 }, new() { Simbolo = "Zpu", Nome = "Zpu", ValorPadrao = 0.2, ValorMin = 1e-9 } ],
                VariavelResultado = "MVAcc", UnidadeResultado = "MVA", Calcular = v => v["base"] / v["Zpu"]
            },
            new Formula
            {
                Id = "v3z_gr04", Nome = "GR4 Vega", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Gregas das Opcoes",
                Expressao = "Vega=S sqrt(T) n(d1)", ExprTexto = "Sensibilidade a volatilidade", Icone = "v3",
                Descricao = "Vega de Black-Scholes (normal padrao no d1).", Criador = "Black-Scholes-Merton", AnoOrigin = "1973",
                ExemploPratico = "S=100,T=1,d1=0 => n(d1)=0.3989 => vega=39.89.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 100 }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1, ValorMin = 0 }, new() { Simbolo = "d1", Nome = "d1", ValorPadrao = 0 } ],
                VariavelResultado = "Vega", Calcular = v => v["S"] * Math.Sqrt(v["T"]) * (0.3989422804014327 * Math.Exp(-0.5 * v["d1"] * v["d1"]))
            },
            new Formula
            {
                Id = "v3z_ri02", Nome = "RI2 Expected Shortfall discreto", Categoria = "Vol3: Financas Quantitativas", SubCategoria = "Modelos de Risco",
                Expressao = "ES=media das perdas acima do VaR", ExprTexto = "Expected shortfall empirico", Icone = "v3",
                Descricao = "Media de tres perdas na cauda para aproximacao empirica de ES.", Criador = "Acerbi-Tasche", AnoOrigin = "2002",
                ExemploPratico = "(5,6,8)% => 6.33%.",
                Variaveis = [ new() { Simbolo = "l1", Nome = "perda1", ValorPadrao = 0.05 }, new() { Simbolo = "l2", Nome = "perda2", ValorPadrao = 0.06 }, new() { Simbolo = "l3", Nome = "perda3", ValorPadrao = 0.08 } ],
                VariavelResultado = "ES", Calcular = v => (v["l1"] + v["l2"] + v["l3"]) / 3.0
            },
            new Formula
            {
                Id = "v3z_po08", Nome = "PO8 Bellman (passo)", Categoria = "Vol3: Pesquisa Operacional", SubCategoria = "Programacao Dinamica",
                Expressao = "V=max_a[r+gamma Vnext]", ExprTexto = "Atualizacao Bellman", Icone = "v3",
                Descricao = "Atualizacao de valor para duas acoes candidatas.", Criador = "Richard Bellman", AnoOrigin = "1957",
                ExemploPratico = "a1=2+0.9*5=6.5, a2=3+0.9*3=5.7 => 6.5.",
                Variaveis = [ new() { Simbolo = "r1", Nome = "r1", ValorPadrao = 2 }, new() { Simbolo = "v1", Nome = "Vnext1", ValorPadrao = 5 }, new() { Simbolo = "r2", Nome = "r2", ValorPadrao = 3 }, new() { Simbolo = "v2", Nome = "Vnext2", ValorPadrao = 3 }, new() { Simbolo = "gamma", Nome = "gamma", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "V", Calcular = v => Math.Max(v["r1"] + v["gamma"] * v["v1"], v["r2"] + v["gamma"] * v["v2"])
            },
            new Formula
            {
                Id = "v3z_tf04", Nome = "TF4 M/G/1 Pollaczek-Khinchine", Categoria = "Vol3: Pesquisa Operacional", SubCategoria = "Teoria das Filas",
                Expressao = "Wq=lambda E[S^2]/(2(1-rho))", ExprTexto = "Espera media na fila", Icone = "v3",
                Descricao = "Tempo medio de espera na fila para M/G/1.", Criador = "Pollaczek-Khinchine", AnoOrigin = "1930",
                ExemploPratico = "lambda=0.8, ES2=3, rho=0.6 => Wq=3.",
                Variaveis = [ new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 0.8, ValorMin = 0 }, new() { Simbolo = "ES2", Nome = "E[S^2]", ValorPadrao = 3, ValorMin = 0 }, new() { Simbolo = "rho", Nome = "rho", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 0.999 } ],
                VariavelResultado = "Wq", Calcular = v => v["lambda"] * v["ES2"] / (2 * (1 - v["rho"]))
            },
            new Formula
            {
                Id = "v3z_cl12", Nome = "CL12 Forcamento 2xCO2", Categoria = "Vol3: Ciencias do Clima", SubCategoria = "Modelos de Carbono e Clima",
                Expressao = "F2xCO2~3.7 W/m2", ExprTexto = "Forcamento radiativo padrao", Icone = "v3",
                Descricao = "Constante de forca radiativa para duplicacao de CO2.", Criador = "IPCC", AnoOrigin = "Sec. XX",
                ExemploPratico = "Entrada direta para modelos EBM.",
                Variaveis = [ new() { Simbolo = "F", Nome = "F2xCO2", ValorPadrao = 3.7 } ],
                VariavelResultado = "F2x", UnidadeResultado = "W/m2", Calcular = v => v["F"]
            },
            new Formula
            {
                Id = "v3z_bi06", Nome = "BI6 BLAST E-value", Categoria = "Vol3: Bioinformatica", SubCategoria = "Alinhamento de Sequencias",
                Expressao = "E=m n exp(-lambda S)", ExprTexto = "Significancia de alinhamento", Icone = "v3",
                Descricao = "Numero esperado de hits ao acaso para score S.", Criador = "Altschul et al.", AnoOrigin = "1990",
                ExemploPratico = "m=1e3,n=1e6,lambda=0.267,S=50 => E pequeno.",
                Variaveis = [ new() { Simbolo = "m", Nome = "m", ValorPadrao = 1000, ValorMin = 1 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1e6, ValorMin = 1 }, new() { Simbolo = "lambda", Nome = "lambda", ValorPadrao = 0.267, ValorMin = 1e-9 }, new() { Simbolo = "S", Nome = "S", ValorPadrao = 50 } ],
                VariavelResultado = "E", Calcular = v => v["m"] * v["n"] * Math.Exp(-v["lambda"] * v["S"])
            },
            new Formula
            {
                Id = "v3z_bs04", Nome = "BS4 Hill (cooperatividade)", Categoria = "Vol3: Bioinformatica", SubCategoria = "Biologia de Sistemas",
                Expressao = "v=Vmax S^n /(Km^n + S^n)", ExprTexto = "Equacao de Hill", Icone = "v3",
                Descricao = "Cinética cooperativa em regulacao bioquimica.", Criador = "Archibald Hill", AnoOrigin = "1910",
                ExemploPratico = "Vmax=1, Km=2, n=2, S=2 => 0.5.",
                Variaveis = [ new() { Simbolo = "Vmax", Nome = "Vmax", ValorPadrao = 1, ValorMin = 0 }, new() { Simbolo = "Km", Nome = "Km", ValorPadrao = 2, ValorMin = 1e-9 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 2, ValorMin = 1e-9 }, new() { Simbolo = "S", Nome = "S", ValorPadrao = 2, ValorMin = 0 } ],
                VariavelResultado = "v", Calcular = v => v["Vmax"] * Math.Pow(v["S"], v["n"]) / (Math.Pow(v["Km"], v["n"]) + Math.Pow(v["S"], v["n"]))
            },
            new Formula
            {
                Id = "v3z_ac07", Nome = "AC7 Nivel de intensidade sonora", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Acustica Fundamental",
                Expressao = "IL=10 log10(I/Iref)", ExprTexto = "Nivel em dB", Icone = "v3",
                Descricao = "Nivel de intensidade sonora relativo a Iref=1e-12 W/m2.", Criador = "Acustica", AnoOrigin = "Sec. XX",
                ExemploPratico = "I=1e-6 => 60 dB.",
                Variaveis = [ new() { Simbolo = "I", Nome = "I", ValorPadrao = 1e-6, ValorMin = 1e-20 }, new() { Simbolo = "Iref", Nome = "Iref", ValorPadrao = 1e-12, ValorMin = 1e-20 } ],
                VariavelResultado = "IL", UnidadeResultado = "dB", Calcular = v => 10 * Math.Log10(v["I"] / v["Iref"])
            },
            new Formula
            {
                Id = "v3z_vb02", Nome = "VB2 Frequencia amortecida", Categoria = "Vol3: Acustica e Vibroacustica", SubCategoria = "Vibracoes Estruturais",
                Expressao = "wd=wn sqrt(1-zeta^2)", ExprTexto = "Resposta subamortecida", Icone = "v3",
                Descricao = "Frequencia natural amortecida de sistema SDOF.", Criador = "Dinamica de vibracoes", AnoOrigin = "Sec. XIX",
                ExemploPratico = "wn=10,zeta=0.1 => wd=9.95.",
                Variaveis = [ new() { Simbolo = "wn", Nome = "omega_n", ValorPadrao = 10, ValorMin = 0 }, new() { Simbolo = "zeta", Nome = "zeta", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 0.999 } ],
                VariavelResultado = "wd", UnidadeResultado = "rad/s", Calcular = v => v["wn"] * Math.Sqrt(1 - v["zeta"] * v["zeta"])
            },
        ]);
    }
}
