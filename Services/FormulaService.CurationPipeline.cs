using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    private void AdicionarPacoteCurado(string procedenciaLote, IEnumerable<Formula> formulas)
    {
        foreach (var formula in formulas)
        {
            if (string.IsNullOrWhiteSpace(formula.Procedencia))
            {
                formula.Procedencia = procedenciaLote;
            }

            if (string.IsNullOrWhiteSpace(formula.StatusCuradoria))
            {
                formula.StatusCuradoria = "Curada e auditada internamente";
            }

            ValidarFormulaCurada(formula);
            _formulas.Add(formula);
        }
    }

    private static void ValidarFormulaCurada(Formula formula)
    {
        if (string.IsNullOrWhiteSpace(formula.Id))
        {
            throw new InvalidOperationException("Formula curada sem ID.");
        }

        if (string.IsNullOrWhiteSpace(formula.Categoria) || string.IsNullOrWhiteSpace(formula.SubCategoria))
        {
            throw new InvalidOperationException($"Formula {formula.Id} sem categoria/subcategoria.");
        }

        if (string.IsNullOrWhiteSpace(formula.Expressao) || formula.Calcular is null)
        {
            throw new InvalidOperationException($"Formula {formula.Id} sem expressao calculavel.");
        }

        if (string.IsNullOrWhiteSpace(formula.ReferenciaBibliografica))
        {
            throw new InvalidOperationException($"Formula {formula.Id} sem referencia bibliografica.");
        }

        if (string.IsNullOrWhiteSpace(formula.FonteUrlOuDoi))
        {
            throw new InvalidOperationException($"Formula {formula.Id} sem URL/DOI de fonte.");
        }

        if (string.IsNullOrWhiteSpace(formula.StatusCuradoria))
        {
            throw new InvalidOperationException($"Formula {formula.Id} sem status de curadoria.");
        }
    }

    public (int Total, int ComFonte, int SemFonte, int Sinteticas) ObterIndicadoresCuradoria()
    {
        var total = _formulas.Count;
        var comFonte = _formulas.Count(f =>
            !string.IsNullOrWhiteSpace(f.ReferenciaBibliografica)
            && !string.IsNullOrWhiteSpace(f.FonteUrlOuDoi)
            && !string.IsNullOrWhiteSpace(f.StatusCuradoria));
        var sinteticas = _formulas.Count(f =>
            (f.Procedencia ?? string.Empty).Contains("sintet", StringComparison.OrdinalIgnoreCase)
            || (f.StatusCuradoria ?? string.Empty).Contains("nao auditada", StringComparison.OrdinalIgnoreCase));

        return (total, comFonte, total - comFonte, sinteticas);
    }

    public IEnumerable<Formula> ObterFormulasSemCuradoria(int take = 200)
    {
        var limite = Math.Max(1, take);
        return _formulas
            .Where(f =>
                string.IsNullOrWhiteSpace(f.ReferenciaBibliografica)
                || string.IsNullOrWhiteSpace(f.FonteUrlOuDoi)
                || string.IsNullOrWhiteSpace(f.StatusCuradoria))
            .Take(limite);
    }

    private void AdicionarLoteCuradoPilotoCristalografia()
    {
        const string categoria = "Cristalografia e Difração de Raios-X";
        const string subCategoria = "Curadoria Piloto - Fundamentos";

        var lote = new List<Formula>
        {
            new()
            {
                Id = "cur_v12_crys_001",
                CodigoCompendio = "CUR-V12-CRYS-001",
                Nome = "Lei de Bragg (calculo de theta)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "theta = asin((n*lambda)/(2*d))",
                ExprTexto = "theta = asin((n*lambda)/(2*d))",
                Descricao = "Condicao de difracao construtiva em uma familia de planos cristalinos.",
                Criador = "W. L. Bragg",
                AnoOrigin = "1913",
                Procedencia = "Curadoria manual por area - Cristalografia",
                ReferenciaBibliografica = "B. D. Cullity and S. R. Stock, Elements of X-Ray Diffraction, 3rd ed., Prentice Hall.",
                FonteUrlOuDoi = "https://books.google.com/books?id=G6kW5N8jQK0C",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Para n=1, lambda=1.5406 A e d=2.00 A, obtem-se theta aproximado de 22.65 graus.",
                Unidades = "n adim; lambda em A; d em A; theta em rad",
                VariavelResultado = "theta",
                UnidadeResultado = "rad",
                Variaveis =
                [
                    new Variavel { Simbolo = "n", Nome = "Ordem", Unidade = "adim", ValorPadrao = 1, ValorMin = 1, ValorMax = 10, Descricao = "Ordem de difracao" },
                    new Variavel { Simbolo = "lambda", Nome = "Comprimento de onda", Unidade = "A", ValorPadrao = 1.5406, ValorMin = 1e-6, ValorMax = 1e6, Descricao = "Comprimento de onda incidente" },
                    new Variavel { Simbolo = "d", Nome = "Espacamento interplanar", Unidade = "A", ValorPadrao = 2.0, ValorMin = 1e-6, ValorMax = 1e6, Descricao = "Espacamento entre planos" }
                ],
                Calcular = vars =>
                {
                    var n = vars.GetValueOrDefault("n", 1.0);
                    var lambda = vars.GetValueOrDefault("lambda", 1.5406);
                    var d = Math.Max(1e-12, vars.GetValueOrDefault("d", 2.0));
                    var arg = Math.Clamp((n * lambda) / (2.0 * d), -1.0, 1.0);
                    return Math.Asin(arg);
                },
                Icone = "💎"
            },
            new()
            {
                Id = "cur_v12_crys_002",
                CodigoCompendio = "CUR-V12-CRYS-002",
                Nome = "Equacao de Scherrer",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "tau = K*lambda/(beta*cos(theta))",
                ExprTexto = "tau = K*lambda/(beta*cos(theta))",
                Descricao = "Estimativa do tamanho medio de cristalito por alargamento de pico.",
                Criador = "P. Scherrer",
                AnoOrigin = "1918",
                Procedencia = "Curadoria manual por area - Cristalografia",
                ReferenciaBibliografica = "A. L. Patterson, The Scherrer Formula for X-Ray Particle Size Determination, Phys. Rev. 56 (1939).",
                FonteUrlOuDoi = "https://doi.org/10.1103/PhysRev.56.978",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Com K=0.9, lambda=1.5406 A, beta=0.01 rad e theta=0.35 rad, tau aproximado 148 A.",
                Unidades = "K adim; lambda em A; beta em rad; theta em rad; tau em A",
                VariavelResultado = "tau",
                UnidadeResultado = "A",
                Variaveis =
                [
                    new Variavel { Simbolo = "K", Nome = "Constante de forma", Unidade = "adim", ValorPadrao = 0.9, ValorMin = 0.1, ValorMax = 2.0, Descricao = "Fator de forma do cristalito" },
                    new Variavel { Simbolo = "lambda", Nome = "Comprimento de onda", Unidade = "A", ValorPadrao = 1.5406, ValorMin = 1e-6, ValorMax = 1e6, Descricao = "Comprimento de onda incidente" },
                    new Variavel { Simbolo = "beta", Nome = "Largura a meia altura", Unidade = "rad", ValorPadrao = 0.01, ValorMin = 1e-9, ValorMax = 10, Descricao = "FWHM em radianos" },
                    new Variavel { Simbolo = "theta", Nome = "Angulo de Bragg", Unidade = "rad", ValorPadrao = 0.35, ValorMin = 0, ValorMax = 1.56, Descricao = "Angulo de Bragg" }
                ],
                Calcular = vars =>
                {
                    var k = vars.GetValueOrDefault("K", 0.9);
                    var lambda = vars.GetValueOrDefault("lambda", 1.5406);
                    var beta = Math.Max(1e-12, vars.GetValueOrDefault("beta", 0.01));
                    var theta = vars.GetValueOrDefault("theta", 0.35);
                    var c = Math.Max(1e-12, Math.Cos(theta));
                    return (k * lambda) / (beta * c);
                },
                Icone = "💎"
            },
            new()
            {
                Id = "cur_v12_crys_003",
                CodigoCompendio = "CUR-V12-CRYS-003",
                Nome = "Espacamento interplanar cubico",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "d = a/sqrt(h^2 + k^2 + l^2)",
                ExprTexto = "d = a/sqrt(h^2 + k^2 + l^2)",
                Descricao = "Espacamento entre planos (hkl) para rede cubica.",
                Criador = "Cristalografia classica",
                AnoOrigin = "Sec. XX",
                Procedencia = "Curadoria manual por area - Cristalografia",
                ReferenciaBibliografica = "C. Kittel, Introduction to Solid State Physics, 8th ed., Wiley.",
                FonteUrlOuDoi = "https://books.google.com/books?id=1X5vYgEACAAJ",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Para a=4.05 A e (hkl)=111, d aproximado de 2.338 A.",
                Unidades = "a em A; h,k,l adim; d em A",
                VariavelResultado = "d",
                UnidadeResultado = "A",
                Variaveis =
                [
                    new Variavel { Simbolo = "a", Nome = "Parametro de rede", Unidade = "A", ValorPadrao = 4.05, ValorMin = 1e-9, ValorMax = 1e9, Descricao = "Lado da cela cubica" },
                    new Variavel { Simbolo = "h", Nome = "Indice de Miller h", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Descricao = "Indice h" },
                    new Variavel { Simbolo = "k", Nome = "Indice de Miller k", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Descricao = "Indice k" },
                    new Variavel { Simbolo = "l", Nome = "Indice de Miller l", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Descricao = "Indice l" }
                ],
                Calcular = vars =>
                {
                    var a = Math.Max(1e-12, vars.GetValueOrDefault("a", 4.05));
                    var h = vars.GetValueOrDefault("h", 1.0);
                    var k = vars.GetValueOrDefault("k", 1.0);
                    var l = vars.GetValueOrDefault("l", 1.0);
                    var denom = Math.Sqrt(Math.Max(1e-12, h * h + k * k + l * l));
                    return a / denom;
                },
                Icone = "💎"
            },
            new()
            {
                Id = "cur_v12_crys_004",
                CodigoCompendio = "CUR-V12-CRYS-004",
                Nome = "Parametro de rede cubica por d(hkl)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "a = d*sqrt(h^2 + k^2 + l^2)",
                ExprTexto = "a = d*sqrt(h^2 + k^2 + l^2)",
                Descricao = "Estimativa do parametro de rede pela indexacao de picos de difracao.",
                Criador = "Cristalografia classica",
                AnoOrigin = "Sec. XX",
                Procedencia = "Curadoria manual por area - Cristalografia",
                ReferenciaBibliografica = "B. D. Cullity and S. R. Stock, Elements of X-Ray Diffraction, 3rd ed., Prentice Hall.",
                FonteUrlOuDoi = "https://books.google.com/books?id=G6kW5N8jQK0C",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Com d(111)=2.338 A, obtem-se a aproximado de 4.049 A.",
                Unidades = "d em A; h,k,l adim; a em A",
                VariavelResultado = "a",
                UnidadeResultado = "A",
                Variaveis =
                [
                    new Variavel { Simbolo = "d", Nome = "Espacamento interplanar", Unidade = "A", ValorPadrao = 2.338, ValorMin = 1e-9, ValorMax = 1e9, Descricao = "Espacamento medido" },
                    new Variavel { Simbolo = "h", Nome = "Indice de Miller h", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Descricao = "Indice h" },
                    new Variavel { Simbolo = "k", Nome = "Indice de Miller k", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Descricao = "Indice k" },
                    new Variavel { Simbolo = "l", Nome = "Indice de Miller l", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Descricao = "Indice l" }
                ],
                Calcular = vars =>
                {
                    var d = Math.Max(1e-12, vars.GetValueOrDefault("d", 2.338));
                    var h = vars.GetValueOrDefault("h", 1.0);
                    var k = vars.GetValueOrDefault("k", 1.0);
                    var l = vars.GetValueOrDefault("l", 1.0);
                    return d * Math.Sqrt(Math.Max(1e-12, h * h + k * k + l * l));
                },
                Icone = "💎"
            },
            new()
            {
                Id = "cur_v12_crys_005",
                CodigoCompendio = "CUR-V12-CRYS-005",
                Nome = "Densidade cristalina",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "rho = (Z*M)/(N_A*a^3)",
                ExprTexto = "rho = (Z*M)/(N_A*a^3)",
                Descricao = "Densidade teorica da cela unitaria a partir de composicao e parametro de rede.",
                Criador = "Estado solido classico",
                AnoOrigin = "Sec. XX",
                Procedencia = "Curadoria manual por area - Cristalografia",
                ReferenciaBibliografica = "C. Kittel, Introduction to Solid State Physics, 8th ed., Wiley.",
                FonteUrlOuDoi = "https://books.google.com/books?id=1X5vYgEACAAJ",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Para Al (Z=4, M=26.98 g/mol, a=4.05e-8 cm), rho aproximado de 2.70 g/cm^3.",
                Unidades = "Z adim; M g/mol; N_A 1/mol; a cm; rho g/cm^3",
                VariavelResultado = "rho",
                UnidadeResultado = "g/cm^3",
                Variaveis =
                [
                    new Variavel { Simbolo = "Z", Nome = "Atomos por cela", Unidade = "adim", ValorPadrao = 4, ValorMin = 1, ValorMax = 1000, Descricao = "Numero de atomos por cela unitaria" },
                    new Variavel { Simbolo = "M", Nome = "Massa molar", Unidade = "g/mol", ValorPadrao = 26.98, ValorMin = 1e-9, ValorMax = 1e9, Descricao = "Massa molar do material" },
                    new Variavel { Simbolo = "N_A", Nome = "Constante de Avogadro", Unidade = "1/mol", ValorPadrao = 6.02214076e23, ValorMin = 1e10, ValorMax = 1e30, Descricao = "Constante de Avogadro" },
                    new Variavel { Simbolo = "a", Nome = "Parametro de rede", Unidade = "cm", ValorPadrao = 4.05e-8, ValorMin = 1e-20, ValorMax = 1e3, Descricao = "Lado da cela em cm" }
                ],
                Calcular = vars =>
                {
                    var z = Math.Max(1e-12, vars.GetValueOrDefault("Z", 4.0));
                    var m = Math.Max(1e-12, vars.GetValueOrDefault("M", 26.98));
                    var na = Math.Max(1e-12, vars.GetValueOrDefault("N_A", 6.02214076e23));
                    var a = Math.Max(1e-20, vars.GetValueOrDefault("a", 4.05e-8));
                    return (z * m) / (na * a * a * a);
                },
                Icone = "💎"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Cristalografia", lote);
    }

    private void AdicionarLoteCuradoPilotoCFD()
    {
        const string categoria = "Mecânica dos Fluidos Computacional (CFD)";
        const string subCategoria = "Curadoria Piloto - Escoamentos e Numerico";

        var lote = new List<Formula>
        {
            new()
            {
                Id = "cur_v12_cfd_001",
                CodigoCompendio = "CUR-V12-CFD-001",
                Nome = "Numero de Reynolds",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Re = rho*U*L/mu",
                ExprTexto = "Re = rho*U*L/mu",
                Descricao = "Parametro adimensional que relaciona efeitos inerciais e viscosos.",
                Criador = "Osborne Reynolds",
                AnoOrigin = "1883",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "F. M. White, Fluid Mechanics, 8th ed., McGraw-Hill.",
                FonteUrlOuDoi = "https://www.mheducation.com/highered/product/fluid-mechanics-white/M9780073529349.html",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Agua em tubo: rho=998 kg/m3, U=1 m/s, L=0.05 m, mu=1e-3 Pa.s resulta Re~49900.",
                Unidades = "rho kg/m3; U m/s; L m; mu Pa.s; Re adim",
                VariavelResultado = "Re",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Unidade = "kg/m3", ValorPadrao = 998, ValorMin = 1e-9, ValorMax = 1e9 },
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 1, ValorMin = 0, ValorMax = 1e6 },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Unidade = "m", ValorPadrao = 0.05, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Unidade = "Pa.s", ValorPadrao = 1e-3, ValorMin = 1e-12, ValorMax = 1e6 }
                ],
                Calcular = vars =>
                {
                    var rho = vars.GetValueOrDefault("rho", 998.0);
                    var u = vars.GetValueOrDefault("U", 1.0);
                    var l = Math.Max(1e-12, vars.GetValueOrDefault("L", 0.05));
                    var mu = Math.Max(1e-12, vars.GetValueOrDefault("mu", 1e-3));
                    return (rho * u * l) / mu;
                },
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_002",
                CodigoCompendio = "CUR-V12-CFD-002",
                Nome = "Numero de Mach",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Ma = U/a",
                ExprTexto = "Ma = U/a",
                Descricao = "Razao entre velocidade de escoamento e velocidade local do som.",
                Criador = "Ernst Mach",
                AnoOrigin = "Sec. XIX",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "J. D. Anderson, Modern Compressible Flow, 3rd ed., McGraw-Hill.",
                FonteUrlOuDoi = "https://www.mheducation.com/highered/product/modern-compressible-flow-anderson/M9780072424430.html",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Aerodinamica externa: U=170 m/s, a=340 m/s, Ma=0.5.",
                Unidades = "U m/s; a m/s; Ma adim",
                VariavelResultado = "Ma",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 170, ValorMin = 0, ValorMax = 1e6 },
                    new Variavel { Simbolo = "a", Nome = "Velocidade do som", Unidade = "m/s", ValorPadrao = 340, ValorMin = 1e-12, ValorMax = 1e6 }
                ],
                Calcular = vars => vars.GetValueOrDefault("U", 170.0) / Math.Max(1e-12, vars.GetValueOrDefault("a", 340.0)),
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_003",
                CodigoCompendio = "CUR-V12-CFD-003",
                Nome = "Numero de Courant (CFL)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "CFL = U*dt/dx",
                ExprTexto = "CFL = U*dt/dx",
                Descricao = "Condicao numerica de estabilidade para varios esquemas explicitos.",
                Criador = "R. Courant, K. Friedrichs, H. Lewy",
                AnoOrigin = "1928",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "R. Courant, K. Friedrichs, H. Lewy, Uber die partiellen Differenzengleichungen der mathematischen Physik, Math. Ann. 100 (1928).",
                FonteUrlOuDoi = "https://doi.org/10.1007/BF01448839",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Se U=10 m/s, dt=1e-4 s e dx=1e-2 m, CFL=0.1.",
                Unidades = "U m/s; dt s; dx m; CFL adim",
                VariavelResultado = "CFL",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 10, ValorMin = 0, ValorMax = 1e6 },
                    new Variavel { Simbolo = "dt", Nome = "Passo de tempo", Unidade = "s", ValorPadrao = 1e-4, ValorMin = 1e-12, ValorMax = 1e3 },
                    new Variavel { Simbolo = "dx", Nome = "Passo espacial", Unidade = "m", ValorPadrao = 1e-2, ValorMin = 1e-12, ValorMax = 1e3 }
                ],
                Calcular = vars => vars.GetValueOrDefault("U", 10.0) * vars.GetValueOrDefault("dt", 1e-4) / Math.Max(1e-12, vars.GetValueOrDefault("dx", 1e-2)),
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_004",
                CodigoCompendio = "CUR-V12-CFD-004",
                Nome = "Perda de carga de Darcy-Weisbach",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "dp = f*(L/D)*(rho*U^2/2)",
                ExprTexto = "dp = f*(L/D)*(rho*U^2/2)",
                Descricao = "Queda de pressao por atrito em escoamento interno plenamente desenvolvido.",
                Criador = "Darcy; Weisbach",
                AnoOrigin = "Sec. XIX",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "F. M. White, Fluid Mechanics, 8th ed., McGraw-Hill.",
                FonteUrlOuDoi = "https://www.mheducation.com/highered/product/fluid-mechanics-white/M9780073529349.html",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "f=0.02, L=10 m, D=0.1 m, rho=998, U=2 m/s resulta dp~3992 Pa.",
                Unidades = "f adim; L m; D m; rho kg/m3; U m/s; dp Pa",
                VariavelResultado = "dp",
                UnidadeResultado = "Pa",
                Variaveis =
                [
                    new Variavel { Simbolo = "f", Nome = "Fator de atrito", Unidade = "adim", ValorPadrao = 0.02, ValorMin = 1e-12, ValorMax = 1e3 },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Unidade = "m", ValorPadrao = 10, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "D", Nome = "Diametro", Unidade = "m", ValorPadrao = 0.1, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Unidade = "kg/m3", ValorPadrao = 998, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 2, ValorMin = 0, ValorMax = 1e6 }
                ],
                Calcular = vars =>
                {
                    var f = vars.GetValueOrDefault("f", 0.02);
                    var l = Math.Max(1e-12, vars.GetValueOrDefault("L", 10.0));
                    var d = Math.Max(1e-12, vars.GetValueOrDefault("D", 0.1));
                    var rho = vars.GetValueOrDefault("rho", 998.0);
                    var u = vars.GetValueOrDefault("U", 2.0);
                    return f * (l / d) * (rho * u * u / 2.0);
                },
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_005",
                CodigoCompendio = "CUR-V12-CFD-005",
                Nome = "Coeficiente de pressao",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Cp = (p - p_inf)/(0.5*rho*U_inf^2)",
                ExprTexto = "Cp = (p - p_inf)/(0.5*rho*U_inf^2)",
                Descricao = "Forma adimensional da pressao em aerodinamica externa.",
                Criador = "Aerodinamica classica",
                AnoOrigin = "Sec. XX",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "J. D. Anderson, Fundamentals of Aerodynamics, 6th ed., McGraw-Hill.",
                FonteUrlOuDoi = "https://www.mheducation.com/highered/product/fundamentals-aerodynamics-anderson/M9781259129919.html",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Se p-p_inf=250 Pa, rho=1.225 kg/m3 e U_inf=30 m/s, Cp~0.45.",
                Unidades = "p Pa; p_inf Pa; rho kg/m3; U_inf m/s; Cp adim",
                VariavelResultado = "Cp",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "p", Nome = "Pressao local", Unidade = "Pa", ValorPadrao = 101575, ValorMin = -1e12, ValorMax = 1e12 },
                    new Variavel { Simbolo = "p_inf", Nome = "Pressao de referencia", Unidade = "Pa", ValorPadrao = 101325, ValorMin = -1e12, ValorMax = 1e12 },
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Unidade = "kg/m3", ValorPadrao = 1.225, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "U_inf", Nome = "Velocidade de referencia", Unidade = "m/s", ValorPadrao = 30, ValorMin = 1e-12, ValorMax = 1e9 }
                ],
                Calcular = vars =>
                {
                    var p = vars.GetValueOrDefault("p", 101575.0);
                    var pInf = vars.GetValueOrDefault("p_inf", 101325.0);
                    var rho = Math.Max(1e-12, vars.GetValueOrDefault("rho", 1.225));
                    var uInf = Math.Max(1e-12, vars.GetValueOrDefault("U_inf", 30.0));
                    return (p - pInf) / (0.5 * rho * uInf * uInf);
                },
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_006",
                CodigoCompendio = "CUR-V12-CFD-006",
                Nome = "Numero de Peclet",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Pe = U*L/alpha",
                ExprTexto = "Pe = U*L/alpha",
                Descricao = "Compara transporte convectivo e difusivo de energia.",
                Criador = "Transferencia de calor classica",
                AnoOrigin = "Sec. XX",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "S. V. Patankar, Numerical Heat Transfer and Fluid Flow, CRC Press.",
                FonteUrlOuDoi = "https://doi.org/10.1201/9781482234213",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "U=0.5 m/s, L=0.1 m, alpha=1.4e-7 m2/s leva a Pe~3.6e5.",
                Unidades = "U m/s; L m; alpha m2/s; Pe adim",
                VariavelResultado = "Pe",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1e9 },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Unidade = "m", ValorPadrao = 0.1, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade termica", Unidade = "m2/s", ValorPadrao = 1.4e-7, ValorMin = 1e-20, ValorMax = 1e3 }
                ],
                Calcular = vars => vars.GetValueOrDefault("U", 0.5) * Math.Max(1e-12, vars.GetValueOrDefault("L", 0.1)) / Math.Max(1e-20, vars.GetValueOrDefault("alpha", 1.4e-7)),
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_007",
                CodigoCompendio = "CUR-V12-CFD-007",
                Nome = "Numero de Strouhal",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "St = f*L/U",
                ExprTexto = "St = f*L/U",
                Descricao = "Razao entre escala temporal convectiva e frequencia caracteristica.",
                Criador = "V. Strouhal",
                AnoOrigin = "1878",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "H. Schlichting and K. Gersten, Boundary-Layer Theory, 9th ed., Springer.",
                FonteUrlOuDoi = "https://doi.org/10.1007/978-3-662-52919-5",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Com f=50 Hz, L=0.02 m e U=5 m/s, St=0.2.",
                Unidades = "f Hz; L m; U m/s; St adim",
                VariavelResultado = "St",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "f", Nome = "Frequencia", Unidade = "Hz", ValorPadrao = 50, ValorMin = 0, ValorMax = 1e9 },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Unidade = "m", ValorPadrao = 0.02, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 5, ValorMin = 1e-12, ValorMax = 1e9 }
                ],
                Calcular = vars => vars.GetValueOrDefault("f", 50.0) * Math.Max(1e-12, vars.GetValueOrDefault("L", 0.02)) / Math.Max(1e-12, vars.GetValueOrDefault("U", 5.0)),
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_008",
                CodigoCompendio = "CUR-V12-CFD-008",
                Nome = "Numero de Froude",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Fr = U/sqrt(g*L)",
                ExprTexto = "Fr = U/sqrt(g*L)",
                Descricao = "Compara inercia e gravidade em escoamentos com superficie livre.",
                Criador = "W. Froude",
                AnoOrigin = "Sec. XIX",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "B. R. Munson, T. H. Okiishi, W. W. Huebsch, Fundamentals of Fluid Mechanics, Wiley.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Fundamentals+of+Fluid+Mechanics%2C+8th+Edition-p-9781119080701",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Canal aberto com U=2 m/s e L=1 m gera Fr~0.64.",
                Unidades = "U m/s; g m/s2; L m; Fr adim",
                VariavelResultado = "Fr",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 2, ValorMin = 0, ValorMax = 1e9 },
                    new Variavel { Simbolo = "g", Nome = "Gravidade", Unidade = "m/s2", ValorPadrao = 9.81, ValorMin = 1e-12, ValorMax = 1e6 },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Unidade = "m", ValorPadrao = 1, ValorMin = 1e-12, ValorMax = 1e9 }
                ],
                Calcular = vars =>
                {
                    var u = vars.GetValueOrDefault("U", 2.0);
                    var g = Math.Max(1e-12, vars.GetValueOrDefault("g", 9.81));
                    var l = Math.Max(1e-12, vars.GetValueOrDefault("L", 1.0));
                    return u / Math.Sqrt(g * l);
                },
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_009",
                CodigoCompendio = "CUR-V12-CFD-009",
                Nome = "Coeficiente de atrito na parede",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Cf = tau_w/(0.5*rho*U^2)",
                ExprTexto = "Cf = tau_w/(0.5*rho*U^2)",
                Descricao = "Forma adimensional da tensao de cisalhamento de parede.",
                Criador = "Mecanica dos fluidos classica",
                AnoOrigin = "Sec. XX",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "S. B. Pope, Turbulent Flows, Cambridge University Press.",
                FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511840531",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "tau_w=2 Pa, rho=1.225 kg/m3 e U=30 m/s fornece Cf~0.00363.",
                Unidades = "tau_w Pa; rho kg/m3; U m/s; Cf adim",
                VariavelResultado = "Cf",
                UnidadeResultado = "adim",
                Variaveis =
                [
                    new Variavel { Simbolo = "tau_w", Nome = "Tensao de parede", Unidade = "Pa", ValorPadrao = 2, ValorMin = 0, ValorMax = 1e12 },
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Unidade = "kg/m3", ValorPadrao = 1.225, ValorMin = 1e-12, ValorMax = 1e12 },
                    new Variavel { Simbolo = "U", Nome = "Velocidade", Unidade = "m/s", ValorPadrao = 30, ValorMin = 1e-12, ValorMax = 1e12 }
                ],
                Calcular = vars =>
                {
                    var tau = vars.GetValueOrDefault("tau_w", 2.0);
                    var rho = Math.Max(1e-12, vars.GetValueOrDefault("rho", 1.225));
                    var u = Math.Max(1e-12, vars.GetValueOrDefault("U", 30.0));
                    return tau / (0.5 * rho * u * u);
                },
                Icone = "🌊"
            },
            new()
            {
                Id = "cur_v12_cfd_010",
                CodigoCompendio = "CUR-V12-CFD-010",
                Nome = "Velocidade de friccao",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "u_tau = sqrt(tau_w/rho)",
                ExprTexto = "u_tau = sqrt(tau_w/rho)",
                Descricao = "Escala de velocidade associada ao cisalhamento de parede.",
                Criador = "Teoria de camada limite",
                AnoOrigin = "Sec. XX",
                Procedencia = "Curadoria manual por area - CFD",
                ReferenciaBibliografica = "H. Schlichting and K. Gersten, Boundary-Layer Theory, 9th ed., Springer.",
                FonteUrlOuDoi = "https://doi.org/10.1007/978-3-662-52919-5",
                StatusCuradoria = "Curada e auditada internamente",
                ExemploPratico = "Com tau_w=2 Pa e rho=1.225 kg/m3, u_tau~1.278 m/s.",
                Unidades = "tau_w Pa; rho kg/m3; u_tau m/s",
                VariavelResultado = "u_tau",
                UnidadeResultado = "m/s",
                Variaveis =
                [
                    new Variavel { Simbolo = "tau_w", Nome = "Tensao de parede", Unidade = "Pa", ValorPadrao = 2, ValorMin = 0, ValorMax = 1e12 },
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Unidade = "kg/m3", ValorPadrao = 1.225, ValorMin = 1e-12, ValorMax = 1e12 }
                ],
                Calcular = vars =>
                {
                    var tau = Math.Max(0, vars.GetValueOrDefault("tau_w", 2.0));
                    var rho = Math.Max(1e-12, vars.GetValueOrDefault("rho", 1.225));
                    return Math.Sqrt(tau / rho);
                },
                Icone = "🌊"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - CFD", lote);
    }

    private void AdicionarLoteCuradoPilotoTermodinamica()
    {
        const string categoria = "Termodinâmica Química";
        const string subCategoria = "Curadoria Piloto - Equilíbrio e Cinética";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_thermo_001",
                Nome = "Energia Livre de Gibbs",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔG = ΔH − T·ΔS",
                ExprTexto = "Delta G = Delta H menos T vezes Delta S",
                Criador = "J. Willard Gibbs",
                AnoOrigin = "1876",
                Descricao = "Define a espontaneidade de um processo a temperatura e pressão constantes. Quando ΔG < 0 o processo é espontâneo; quando ΔG = 0 o sistema está em equilíbrio.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 3.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dH", Nome = "Variação de entalpia", Unidade = "kJ/mol", ValorPadrao = -100.0, ValorMin = -1e9, ValorMax = 1e9 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "dS", Nome = "Variação de entropia", Unidade = "J/(mol·K)", ValorPadrao = -100.0, ValorMin = -1e6, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    var dH = vars.GetValueOrDefault("dH", -100.0) * 1000.0; // kJ → J
                    var T  = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    var dS = vars.GetValueOrDefault("dS", -100.0);
                    return (dH - T * dS) / 1000.0; // J → kJ/mol
                },
                VariavelResultado = "ΔG",
                UnidadeResultado = "kJ/mol",
                Icone = "ΔG"
            },
            new Formula
            {
                Id = "cur_v12_thermo_002",
                Nome = "Equação de van 't Hoff (equilíbrio com temperatura)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "K₂ = K₁·exp[−ΔH°/R·(1/T₂ − 1/T₁)]",
                ExprTexto = "K2 = K1 vezes exp de menos Delta H sobre R vezes (1 sobre T2 menos 1 sobre T1)",
                Criador = "Jacobus H. van 't Hoff",
                AnoOrigin = "1884",
                Descricao = "Descreve como a constante de equilíbrio termodinâmico varia com a temperatura. Derivada da equação de Gibbs-Helmholtz.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 6.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K1", Nome = "Constante de equilíbrio em T1", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-300, ValorMax = 1e300 },
                    new Variavel { Simbolo = "dH", Nome = "Entalpia padrão de reação", Unidade = "J/mol", ValorPadrao = -40000.0, ValorMin = -1e9, ValorMax = 1e9 },
                    new Variavel { Simbolo = "T1", Nome = "Temperatura de referência", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "T2", Nome = "Nova temperatura", Unidade = "K", ValorPadrao = 350.0, ValorMin = 1e-3, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    var K1 = Math.Max(1e-300, vars.GetValueOrDefault("K1", 1.0));
                    var dH = vars.GetValueOrDefault("dH", -40000.0);
                    var T1 = Math.Max(1e-3, vars.GetValueOrDefault("T1", 298.15));
                    var T2 = Math.Max(1e-3, vars.GetValueOrDefault("T2", 350.0));
                    return K1 * Math.Exp(-dH / R * (1.0 / T2 - 1.0 / T1));
                },
                VariavelResultado = "K₂",
                UnidadeResultado = "adim",
                Icone = "K"
            },
            new Formula
            {
                Id = "cur_v12_thermo_003",
                Nome = "Equação de Clausius-Clapeyron",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "P₂ = P₁·exp[−ΔH_vap/R·(1/T₂ − 1/T₁)]",
                ExprTexto = "P2 = P1 vezes exp de menos Delta H_vap sobre R vezes (1 sobre T2 menos 1 sobre T1)",
                Criador = "Rudolf Clausius / Benoît Clapeyron",
                AnoOrigin = "1850",
                Descricao = "Relaciona a pressão de vapor de um líquido puro com a temperatura, usando a entalpia de vaporização. Amplamente usada para predizer mudanças de pressão de vapor.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 4.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "P1", Nome = "Pressão de vapor em T1", Unidade = "Pa", ValorPadrao = 101325.0, ValorMin = 1e-10, ValorMax = 1e15 },
                    new Variavel { Simbolo = "dHvap", Nome = "Entalpia de vaporização", Unidade = "J/mol", ValorPadrao = 40650.0, ValorMin = 0, ValorMax = 1e9 },
                    new Variavel { Simbolo = "T1", Nome = "Temperatura de referência", Unidade = "K", ValorPadrao = 373.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "T2", Nome = "Nova temperatura", Unidade = "K", ValorPadrao = 353.15, ValorMin = 1e-3, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    var P1    = Math.Max(1e-10, vars.GetValueOrDefault("P1", 101325.0));
                    var dHvap = Math.Max(0, vars.GetValueOrDefault("dHvap", 40650.0));
                    var T1    = Math.Max(1e-3, vars.GetValueOrDefault("T1", 373.15));
                    var T2    = Math.Max(1e-3, vars.GetValueOrDefault("T2", 353.15));
                    return P1 * Math.Exp(-dHvap / R * (1.0 / T2 - 1.0 / T1));
                },
                VariavelResultado = "P₂",
                UnidadeResultado = "Pa",
                Icone = "P"
            },
            new Formula
            {
                Id = "cur_v12_thermo_004",
                Nome = "Constante de velocidade de Arrhenius",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "k = A·exp(−Eₐ/(RT))",
                ExprTexto = "k = A vezes exp de menos Ea dividido por R vezes T",
                Criador = "Svante Arrhenius",
                AnoOrigin = "1889",
                Descricao = "Descreve a dependência da constante de velocidade de reação com a temperatura. Ea é a energia de ativação e A é o fator pré-exponencial (fator de frequência).",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Laidler, K. J. Chemical Kinetics, 3ª ed., HarperCollins Publishers, 1987. Cap. 2. ISBN 978-0-06-043862-3.",
                FonteUrlOuDoi = "https://doi.org/10.1007/BF01343003",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Fator pré-exponencial", Unidade = "s⁻¹", ValorPadrao = 1e13, ValorMin = 1e-100, ValorMax = 1e100 },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativação", Unidade = "J/mol", ValorPadrao = 50000.0, ValorMin = 0, ValorMax = 1e9 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    var A  = Math.Max(1e-300, vars.GetValueOrDefault("A", 1e13));
                    var Ea = Math.Max(0, vars.GetValueOrDefault("Ea", 50000.0));
                    var T  = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    return A * Math.Exp(-Ea / (R * T));
                },
                VariavelResultado = "k",
                UnidadeResultado = "s⁻¹",
                Icone = "k"
            },
            new Formula
            {
                Id = "cur_v12_thermo_005",
                Nome = "Energia de Gibbs padrão e constante de equilíbrio",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔG° = −RT·ln K",
                ExprTexto = "Delta G grau = menos R vezes T vezes logaritmo natural de K",
                Criador = "J. Willard Gibbs",
                AnoOrigin = "1878",
                Descricao = "Relaciona a energia livre de Gibbs padrão de reação com a constante de equilíbrio termodinâmico K. Fundamental para o cálculo do equilíbrio químico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 6.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "K", Nome = "Constante de equilíbrio", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-300, ValorMax = 1e300 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    var T = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    var K = Math.Max(1e-300, vars.GetValueOrDefault("K", 1.0));
                    return -R * T * Math.Log(K);
                },
                VariavelResultado = "ΔG°",
                UnidadeResultado = "J/mol",
                Icone = "ΔG°"
            },
            new Formula
            {
                Id = "cur_v12_thermo_006",
                Nome = "Calor a pressão constante (capacidade calorífica molar)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Q = n·Cₚ·ΔT",
                ExprTexto = "Q = n vezes Cp vezes Delta T",
                Criador = "Tradição termodinâmica clássica",
                AnoOrigin = "1824",
                Descricao = "Quantidade de calor transferida a uma substância a pressão constante. Cₚ é a capacidade calorífica molar a pressão constante.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 2.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Quantidade de substância", Unidade = "mol", ValorPadrao = 1.0, ValorMin = 1e-20, ValorMax = 1e20 },
                    new Variavel { Simbolo = "Cp", Nome = "Capacidade calorífica molar a pressão constante", Unidade = "J/(mol·K)", ValorPadrao = 75.3, ValorMin = 0, ValorMax = 1e9 },
                    new Variavel { Simbolo = "dT", Nome = "Variação de temperatura", Unidade = "K", ValorPadrao = 10.0, ValorMin = -1e6, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    var n  = vars.GetValueOrDefault("n", 1.0);
                    var Cp = vars.GetValueOrDefault("Cp", 75.3);
                    var dT = vars.GetValueOrDefault("dT", 10.0);
                    return n * Cp * dT;
                },
                VariavelResultado = "Q",
                UnidadeResultado = "J",
                Icone = "Q"
            },
            new Formula
            {
                Id = "cur_v12_thermo_007",
                Nome = "Entropia de Boltzmann",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "S = k_B·ln W",
                ExprTexto = "S = k_B vezes logaritmo natural de W",
                Criador = "Ludwig Boltzmann",
                AnoOrigin = "1877",
                Descricao = "Relaciona a entropia macroscópica S com o número de microestados W acessíveis ao sistema. Fundamento da mecânica estatística.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Boltzmann, L. Über die Beziehung zwischen dem zweiten Hauptsatze der mechanischen Wärmetheorie und der Wahrscheinlichkeits-Rechnung, Wien. Ber. 76, 373 (1877).",
                FonteUrlOuDoi = "https://doi.org/10.1007/BF01443306",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "W", Nome = "Número de microestados", Unidade = "adim", ValorPadrao = 1000.0, ValorMin = 1, ValorMax = 1e300 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var W = Math.Max(1, vars.GetValueOrDefault("W", 1000.0));
                    return kB * Math.Log(W);
                },
                VariavelResultado = "S",
                UnidadeResultado = "J/K",
                Icone = "S"
            },
            new Formula
            {
                Id = "cur_v12_thermo_008",
                Nome = "Trabalho isotérmico reversível de expansão",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "W = −nRT·ln(V₂/V₁)",
                ExprTexto = "W = menos n vezes R vezes T vezes logaritmo natural de V2 sobre V1",
                Criador = "Tradição termodinâmica clássica",
                AnoOrigin = "1824",
                Descricao = "Trabalho realizado por um gás ideal em expansão isotérmica reversível. A pressão varia continuamente (pressão de equilíbrio do gás) ao longo do processo.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 2.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Quantidade de substância", Unidade = "mol", ValorPadrao = 1.0, ValorMin = 1e-20, ValorMax = 1e20 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "V1", Nome = "Volume inicial", Unidade = "m³", ValorPadrao = 0.001, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "V2", Nome = "Volume final", Unidade = "m³", ValorPadrao = 0.002, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    var n  = vars.GetValueOrDefault("n", 1.0);
                    var T  = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    var V1 = Math.Max(1e-30, vars.GetValueOrDefault("V1", 0.001));
                    var V2 = Math.Max(1e-30, vars.GetValueOrDefault("V2", 0.002));
                    return -n * R * T * Math.Log(V2 / V1);
                },
                VariavelResultado = "W",
                UnidadeResultado = "J",
                Icone = "W"
            },
            new Formula
            {
                Id = "cur_v12_thermo_009",
                Nome = "Lei de Kirchhoff (variação de entalpia com temperatura)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔH(T₂) = ΔH(T₁) + ΔCₚ·(T₂ − T₁)",
                ExprTexto = "Delta H em T2 = Delta H em T1 mais Delta Cp vezes T2 menos T1",
                Criador = "Gustav R. Kirchhoff",
                AnoOrigin = "1858",
                Descricao = "Aproximação de capacidade calorífica constante da lei de Kirchhoff. Permite corrigir a entalpia de reação de uma temperatura de referência para outra.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 2. (eq. 2C.5a)",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dH1", Nome = "Entalpia de reação em T1", Unidade = "J/mol", ValorPadrao = -285830.0, ValorMin = -1e12, ValorMax = 1e12 },
                    new Variavel { Simbolo = "dCp", Nome = "Variação de capacidade calorífica de reação ΔCp", Unidade = "J/(mol·K)", ValorPadrao = -41.0, ValorMin = -1e9, ValorMax = 1e9 },
                    new Variavel { Simbolo = "T1", Nome = "Temperatura de referência", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "T2", Nome = "Nova temperatura", Unidade = "K", ValorPadrao = 373.15, ValorMin = 1e-3, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    var dH1 = vars.GetValueOrDefault("dH1", -285830.0);
                    var dCp = vars.GetValueOrDefault("dCp", -41.0);
                    var T1  = vars.GetValueOrDefault("T1", 298.15);
                    var T2  = vars.GetValueOrDefault("T2", 373.15);
                    return dH1 + dCp * (T2 - T1);
                },
                VariavelResultado = "ΔH(T₂)",
                UnidadeResultado = "J/mol",
                Icone = "ΔH"
            },
            new Formula
            {
                Id = "cur_v12_thermo_010",
                Nome = "Potencial químico e atividade termodinâmica",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "μ = μ° + RT·ln(a)",
                ExprTexto = "mi = mi grau mais R vezes T vezes logaritmo natural de a",
                Criador = "J. Willard Gibbs",
                AnoOrigin = "1876",
                Descricao = "Descreve o potencial químico de uma espécie em função da sua atividade termodinâmica a. Fundamental para equilíbrios de fase, soluções e reações químicas.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Prausnitz, J. M.; Lichtenthaler, R. N.; de Azevedo, E. G. Molecular Thermodynamics of Fluid-Phase Equilibria, 3ª ed., Prentice Hall, 1999. Cap. 3. ISBN 978-0-13-977745-5.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/molecular-thermodynamics-of-fluid-phase-equilibria/P200000000530",
                StatusCuradoria = "Curada — fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "mu0", Nome = "Potencial químico padrão", Unidade = "J/mol", ValorPadrao = -237130.0, ValorMin = -1e12, ValorMax = 1e12 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "a", Nome = "Atividade termodinâmica", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-300, ValorMax = 1e300 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    var mu0 = vars.GetValueOrDefault("mu0", -237130.0);
                    var T   = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    var a   = Math.Max(1e-300, vars.GetValueOrDefault("a", 1.0));
                    return mu0 + R * T * Math.Log(a);
                },
                VariavelResultado = "μ",
                UnidadeResultado = "J/mol",
                Icone = "μ"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Termodinamica Quimica", lote);
    }

    private void AdicionarLoteCuradoPilotoEletroquimica()
    {
        const string categoria = "Eletroquímica";
        const string subCategoria = "Curadoria Piloto - Células e Cinética";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_echem_001",
                Nome = "Equação de Nernst",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E = E° − (RT/nF)·ln(Q)",
                ExprTexto = "E = E grau menos RT sobre nF vezes logaritmo natural de Q",
                Criador = "Walther Nernst",
                AnoOrigin = "1889",
                Descricao = "Relaciona o potencial de eletrodo com a atividade relativa de reagentes e produtos da semirreação.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Bard, A. J.; Faulkner, L. R. Electrochemical Methods: Fundamentals and Applications, 2ª ed., Wiley, 2001. Cap. 1.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Electrochemical+Methods%3A+Fundamentals+and+Applications%2C+2nd+Edition-p-9780471043720",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "E0", Nome = "Potencial padrão", Unidade = "V", ValorPadrao = 1.10, ValorMin = -1e3, ValorMax = 1e3 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "n", Nome = "Número de elétrons", Unidade = "adim", ValorPadrao = 2.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "Q", Nome = "Quociente reacional", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-300, ValorMax = 1e300 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    const double F = 96485.33212;
                    var E0 = vars.GetValueOrDefault("E0", 1.10);
                    var T = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 2.0));
                    var Q = Math.Max(1e-300, vars.GetValueOrDefault("Q", 1.0));
                    return E0 - (R * T / (n * F)) * Math.Log(Q);
                },
                VariavelResultado = "E",
                UnidadeResultado = "V",
                Icone = "E"
            },
            new Formula
            {
                Id = "cur_v12_echem_002",
                Nome = "Energia livre de Gibbs de célula eletroquímica",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔG = −nF·E",
                ExprTexto = "Delta G = menos nF vezes E",
                Criador = "J. Willard Gibbs",
                AnoOrigin = "1878",
                Descricao = "Conecta o potencial reversível da célula ao trabalho elétrico máximo e à energia livre de Gibbs da reação global.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Atkins, P.; de Paula, J. Physical Chemistry, 10ª ed., Oxford University Press, 2014. Cap. 28.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/atkins-physical-chemistry-9780198769866",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Número de elétrons", Unidade = "adim", ValorPadrao = 2.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "E", Nome = "Potencial da célula", Unidade = "V", ValorPadrao = 1.10, ValorMin = -1e3, ValorMax = 1e3 }
                },
                Calcular = vars =>
                {
                    const double F = 96485.33212;
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 2.0));
                    var E = vars.GetValueOrDefault("E", 1.10);
                    return -n * F * E;
                },
                VariavelResultado = "ΔG",
                UnidadeResultado = "J/mol",
                Icone = "ΔG"
            },
            new Formula
            {
                Id = "cur_v12_echem_003",
                Nome = "Primeira lei de Faraday da eletrólise",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "m = (MIt)/(nF)",
                ExprTexto = "m = M vezes I vezes t dividido por nF",
                Criador = "Michael Faraday",
                AnoOrigin = "1834",
                Descricao = "A massa depositada ou dissolvida em um eletrodo é proporcional à carga total que atravessa a célula.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Bockris, J. O'M.; Reddy, A. K. N. Modern Electrochemistry 1, 2ª ed., Kluwer/Plenum, 1998. Cap. 2.",
                FonteUrlOuDoi = "https://link.springer.com/book/10.1007/978-0-306-46916-7",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "M", Nome = "Massa molar", Unidade = "g/mol", ValorPadrao = 63.546, ValorMin = 1e-12, ValorMax = 1e9 },
                    new Variavel { Simbolo = "I", Nome = "Corrente elétrica", Unidade = "A", ValorPadrao = 2.0, ValorMin = 0, ValorMax = 1e9 },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Unidade = "s", ValorPadrao = 3600.0, ValorMin = 0, ValorMax = 1e12 },
                    new Variavel { Simbolo = "n", Nome = "Número de elétrons", Unidade = "adim", ValorPadrao = 2.0, ValorMin = 1, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    const double F = 96485.33212;
                    var M = Math.Max(1e-12, vars.GetValueOrDefault("M", 63.546));
                    var I = Math.Max(0, vars.GetValueOrDefault("I", 2.0));
                    var t = Math.Max(0, vars.GetValueOrDefault("t", 3600.0));
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 2.0));
                    return M * I * t / (n * F);
                },
                VariavelResultado = "m",
                UnidadeResultado = "g",
                Icone = "m"
            },
            new Formula
            {
                Id = "cur_v12_echem_004",
                Nome = "Carga elétrica transferida",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Q = I·t",
                ExprTexto = "Q = I vezes t",
                Criador = "Relação fundamental de circuitos",
                AnoOrigin = "Sec. XIX",
                Descricao = "Relação básica entre corrente elétrica e tempo, usada diretamente em balanços de eletrólise, coulometria e armazenamento eletroquímico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Newman, J.; Thomas-Alyea, K. E. Electrochemical Systems, 3ª ed., Wiley-Interscience, 2004. Cap. 1.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/0471477567",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "I", Nome = "Corrente elétrica", Unidade = "A", ValorPadrao = 2.0, ValorMin = -1e9, ValorMax = 1e9 },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Unidade = "s", ValorPadrao = 3600.0, ValorMin = 0, ValorMax = 1e12 }
                },
                Calcular = vars =>
                {
                    var I = vars.GetValueOrDefault("I", 2.0);
                    var t = Math.Max(0, vars.GetValueOrDefault("t", 3600.0));
                    return I * t;
                },
                VariavelResultado = "Q",
                UnidadeResultado = "C",
                Icone = "Q"
            },
            new Formula
            {
                Id = "cur_v12_echem_005",
                Nome = "Equação de Butler-Volmer",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "i = i0·[exp(αa·nFη/RT) − exp(−αc·nFη/RT)]",
                ExprTexto = "i = i0 vezes exponencial de alfa a nF eta sobre RT menos exponencial de menos alfa c nF eta sobre RT",
                Criador = "John Alfred Valentine Butler / Max Volmer",
                AnoOrigin = "1924",
                Descricao = "Descreve a densidade de corrente faradaica em função da sobretensão, incorporando as contribuições anódica e catódica da transferência de carga.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Bard, A. J.; Faulkner, L. R. Electrochemical Methods: Fundamentals and Applications, 2ª ed., Wiley, 2001. Cap. 3.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Electrochemical+Methods%3A+Fundamentals+and+Applications%2C+2nd+Edition-p-9780471043720",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "i0", Nome = "Corrente de troca", Unidade = "A/m²", ValorPadrao = 1.0, ValorMin = 1e-300, ValorMax = 1e300 },
                    new Variavel { Simbolo = "aa", Nome = "Coeficiente de transferência anódico", Unidade = "adim", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 },
                    new Variavel { Simbolo = "ac", Nome = "Coeficiente de transferência catódico", Unidade = "adim", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 },
                    new Variavel { Simbolo = "n", Nome = "Número de elétrons", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "eta", Nome = "Sobretensão", Unidade = "V", ValorPadrao = 0.05, ValorMin = -10, ValorMax = 10 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    const double F = 96485.33212;
                    var i0 = Math.Max(1e-300, vars.GetValueOrDefault("i0", 1.0));
                    var aa = Math.Clamp(vars.GetValueOrDefault("aa", 0.5), 0, 1);
                    var ac = Math.Clamp(vars.GetValueOrDefault("ac", 0.5), 0, 1);
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 1.0));
                    var eta = vars.GetValueOrDefault("eta", 0.05);
                    var T = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    return i0 * (Math.Exp(aa * n * F * eta / (R * T)) - Math.Exp(-ac * n * F * eta / (R * T)));
                },
                VariavelResultado = "i",
                UnidadeResultado = "A/m²",
                Icone = "i"
            },
            new Formula
            {
                Id = "cur_v12_echem_006",
                Nome = "Equação de Tafel",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "η = a + b·log10(i)",
                ExprTexto = "eta = a mais b vezes logaritmo decimal de i",
                Criador = "Julius Tafel",
                AnoOrigin = "1905",
                Descricao = "Aproximação assintótica da Butler-Volmer em grandes sobretensões, amplamente usada para extrair parâmetros cinéticos de corrosão e eletrocatálise.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Bockris, J. O'M.; Reddy, A. K. N. Modern Electrochemistry 2A, 2ª ed., Kluwer/Plenum, 2000. Cap. 8.",
                FonteUrlOuDoi = "https://link.springer.com/book/10.1007/978-1-4615-7467-0",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Intercepto de Tafel", Unidade = "V", ValorPadrao = 0.10, ValorMin = -1e3, ValorMax = 1e3 },
                    new Variavel { Simbolo = "b", Nome = "Inclinação de Tafel", Unidade = "V/dec", ValorPadrao = 0.12, ValorMin = -1e3, ValorMax = 1e3 },
                    new Variavel { Simbolo = "i", Nome = "Densidade de corrente", Unidade = "A/m²", ValorPadrao = 10.0, ValorMin = 1e-300, ValorMax = 1e300 }
                },
                Calcular = vars =>
                {
                    var a = vars.GetValueOrDefault("a", 0.10);
                    var b = vars.GetValueOrDefault("b", 0.12);
                    var i = Math.Max(1e-300, vars.GetValueOrDefault("i", 10.0));
                    return a + b * Math.Log10(i);
                },
                VariavelResultado = "η",
                UnidadeResultado = "V",
                Icone = "η"
            },
            new Formula
            {
                Id = "cur_v12_echem_007",
                Nome = "Equação de Randles-Sevcik",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ip = 2.69×10^5·n^(3/2)·A·D^(1/2)·C·v^(1/2)",
                ExprTexto = "ip = 2,69 vezes 10 elevado a 5 vezes n elevado a 3 sobre 2 vezes A vezes raiz de D vezes C vezes raiz de v",
                Criador = "John E. B. Randles / Albrecht Sevcik",
                AnoOrigin = "1948",
                Descricao = "Expressão para a corrente de pico em voltametria cíclica reversível a 298 K, conectando difusão, área do eletrodo, concentração e velocidade de varredura.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Bard, A. J.; Faulkner, L. R. Electrochemical Methods: Fundamentals and Applications, 2ª ed., Wiley, 2001. Cap. 6.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Electrochemical+Methods%3A+Fundamentals+and+Applications%2C+2nd+Edition-p-9780471043720",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Número de elétrons", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "A", Nome = "Área do eletrodo", Unidade = "cm²", ValorPadrao = 0.0707, ValorMin = 1e-12, ValorMax = 1e12 },
                    new Variavel { Simbolo = "D", Nome = "Coeficiente de difusão", Unidade = "cm²/s", ValorPadrao = 1e-5, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "C", Nome = "Concentração", Unidade = "mol/cm³", ValorPadrao = 1e-6, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "v", Nome = "Velocidade de varredura", Unidade = "V/s", ValorPadrao = 0.1, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 1.0));
                    var A = Math.Max(1e-12, vars.GetValueOrDefault("A", 0.0707));
                    var D = Math.Max(1e-30, vars.GetValueOrDefault("D", 1e-5));
                    var C = Math.Max(1e-30, vars.GetValueOrDefault("C", 1e-6));
                    var v = Math.Max(1e-30, vars.GetValueOrDefault("v", 0.1));
                    return 2.69e5 * Math.Pow(n, 1.5) * A * Math.Sqrt(D) * C * Math.Sqrt(v);
                },
                VariavelResultado = "ip",
                UnidadeResultado = "A",
                Icone = "ip"
            },
            new Formula
            {
                Id = "cur_v12_echem_008",
                Nome = "Resistência de transferência de carga",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Rct = RT/(nF·i0)",
                ExprTexto = "Rct = RT dividido por nF vezes i0",
                Criador = "Linearização de Butler-Volmer",
                AnoOrigin = "Sec. XX",
                Descricao = "Relação de baixa sobretensão entre corrente de troca e resistência de transferência de carga, importante em espectroscopia de impedância eletroquímica.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Orazem, M. E.; Tribollet, B. Electrochemical Impedance Spectroscopy, 2ª ed., Wiley, 2017. Cap. 2.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/9781118527399",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-3, ValorMax = 1e6 },
                    new Variavel { Simbolo = "n", Nome = "Número de elétrons", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "i0", Nome = "Corrente de troca", Unidade = "A", ValorPadrao = 1e-3, ValorMin = 1e-300, ValorMax = 1e300 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    const double F = 96485.33212;
                    var T = Math.Max(1e-3, vars.GetValueOrDefault("T", 298.15));
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 1.0));
                    var i0 = Math.Max(1e-300, vars.GetValueOrDefault("i0", 1e-3));
                    return R * T / (n * F * i0);
                },
                VariavelResultado = "Rct",
                UnidadeResultado = "ohm",
                Icone = "Rct"
            },
            new Formula
            {
                Id = "cur_v12_echem_009",
                Nome = "Corrente limite difusional em eletrodo plano",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "iL = nFAD·C/δ",
                ExprTexto = "iL = nFAD vezes C dividido por delta",
                Criador = "Teoria difusional clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Corrente máxima controlada por transporte de massa através de uma camada difusional estacionária em um eletrodo plano.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Newman, J.; Thomas-Alyea, K. E. Electrochemical Systems, 3ª ed., Wiley-Interscience, 2004. Cap. 13.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/0471477567",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Número de elétrons", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "A", Nome = "Área do eletrodo", Unidade = "m²", ValorPadrao = 1e-4, ValorMin = 1e-18, ValorMax = 1e18 },
                    new Variavel { Simbolo = "D", Nome = "Coeficiente de difusão", Unidade = "m²/s", ValorPadrao = 1e-9, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "C", Nome = "Concentração a granel", Unidade = "mol/m³", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "delta", Nome = "Espessura da camada difusional", Unidade = "m", ValorPadrao = 1e-4, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double F = 96485.33212;
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 1.0));
                    var A = Math.Max(1e-18, vars.GetValueOrDefault("A", 1e-4));
                    var D = Math.Max(1e-30, vars.GetValueOrDefault("D", 1e-9));
                    var C = Math.Max(1e-30, vars.GetValueOrDefault("C", 1.0));
                    var delta = Math.Max(1e-30, vars.GetValueOrDefault("delta", 1e-4));
                    return n * F * A * D * C / delta;
                },
                VariavelResultado = "iL",
                UnidadeResultado = "A",
                Icone = "iL"
            },
            new Formula
            {
                Id = "cur_v12_echem_010",
                Nome = "Equação de Stern-Geary",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "icorr = B/Rp, com B = (βa·βc)/(2.303·(βa + βc))",
                ExprTexto = "icorr = B sobre Rp, com B igual a beta a vezes beta c dividido por 2,303 vezes beta a mais beta c",
                Criador = "Morris Stern / Arnold Geary",
                AnoOrigin = "1957",
                Descricao = "Relaciona a corrente de corrosão com a resistência de polarização e as inclinações anódica e catódica de Tafel.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Stern, M.; Geary, A. L. Electrochemical Polarization: I. A Theoretical Analysis of the Shape of Polarization Curves. Journal of the Electrochemical Society 104(1), 56-63, 1957.",
                FonteUrlOuDoi = "https://doi.org/10.1149/1.2428496",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "beta_a", Nome = "Inclinação anódica de Tafel", Unidade = "V/dec", ValorPadrao = 0.12, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "beta_c", Nome = "Inclinação catódica de Tafel", Unidade = "V/dec", ValorPadrao = 0.12, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Rp", Nome = "Resistência de polarização", Unidade = "ohm·m²", ValorPadrao = 10.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var betaA = Math.Max(1e-30, vars.GetValueOrDefault("beta_a", 0.12));
                    var betaC = Math.Max(1e-30, vars.GetValueOrDefault("beta_c", 0.12));
                    var Rp = Math.Max(1e-30, vars.GetValueOrDefault("Rp", 10.0));
                    var B = (betaA * betaC) / (2.303 * (betaA + betaC));
                    return B / Rp;
                },
                VariavelResultado = "icorr",
                UnidadeResultado = "A/m²",
                Icone = "icorr"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Eletroquimica", lote);
    }

    private void AdicionarLoteCuradoPilotoMecanicaQuantica()
    {
        const string categoria = "Mecânica Quântica I";
        const string subCategoria = "Curadoria Piloto - Fundamentos";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_qm_001",
                Nome = "Comprimento de onda de de Broglie",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "λ = h/p",
                ExprTexto = "lambda = h dividido por p",
                Criador = "Louis de Broglie",
                AnoOrigin = "1924",
                Descricao = "Associa a uma partícula com momento linear p um comprimento de onda λ, ligando o comportamento corpuscular e ondulatório.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J.; Schroeter, D. F. Introduction to Quantum Mechanics, 3ª ed., Cambridge University Press, 2018. Cap. 1.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781316995433",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p", Nome = "Momento linear", Unidade = "kg·m/s", ValorPadrao = 1e-24, ValorMin = 1e-40, ValorMax = 1e10 }
                },
                Calcular = vars =>
                {
                    const double h = 6.62607015e-34;
                    var p = Math.Max(1e-40, vars.GetValueOrDefault("p", 1e-24));
                    return h / p;
                },
                VariavelResultado = "λ",
                UnidadeResultado = "m",
                Icone = "λ"
            },
            new Formula
            {
                Id = "cur_v12_qm_002",
                Nome = "Níveis de energia do poço infinito unidimensional",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E_n = n²h²/(8mL²)",
                ExprTexto = "E n = n ao quadrado vezes h ao quadrado dividido por 8 m L ao quadrado",
                Criador = "Modelo padrão de partícula na caixa",
                AnoOrigin = "Sec. XX",
                Descricao = "Autovalores de energia para uma partícula confinada em um poço de potencial infinito unidimensional de largura L.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J.; Schroeter, D. F. Introduction to Quantum Mechanics, 3ª ed., Cambridge University Press, 2018. Cap. 2.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781316995433",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Número quântico principal", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "m", Nome = "Massa da partícula", Unidade = "kg", ValorPadrao = 9.1093837015e-31, ValorMin = 1e-40, ValorMax = 1e10 },
                    new Variavel { Simbolo = "L", Nome = "Largura da caixa", Unidade = "m", ValorPadrao = 1e-9, ValorMin = 1e-30, ValorMax = 1e10 }
                },
                Calcular = vars =>
                {
                    const double h = 6.62607015e-34;
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 1.0));
                    var m = Math.Max(1e-40, vars.GetValueOrDefault("m", 9.1093837015e-31));
                    var L = Math.Max(1e-30, vars.GetValueOrDefault("L", 1e-9));
                    return n * n * h * h / (8.0 * m * L * L);
                },
                VariavelResultado = "E_n",
                UnidadeResultado = "J",
                Icone = "E"
            },
            new Formula
            {
                Id = "cur_v12_qm_003",
                Nome = "Energia do átomo de hidrogênio (modelo de Bohr)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E_n = −13.605693·Z²/n²",
                ExprTexto = "E n = menos 13,605693 vezes Z ao quadrado dividido por n ao quadrado",
                Criador = "Niels Bohr",
                AnoOrigin = "1913",
                Descricao = "Energia dos estados ligados hidrogenoides no modelo de Bohr, expressa em elétron-volt.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Eisberg, R.; Resnick, R. Quantum Physics of Atoms, Molecules, Solids, Nuclei, and Particles, 2ª ed., Wiley, 1985. Cap. 4.",
                FonteUrlOuDoi = "https://archive.org/details/quantumphysicsof00eisb",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Z", Nome = "Número atômico efetivo", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e3 },
                    new Variavel { Simbolo = "n", Nome = "Número quântico principal", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    var Z = Math.Max(1, vars.GetValueOrDefault("Z", 1.0));
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 1.0));
                    return -13.605693 * Z * Z / (n * n);
                },
                VariavelResultado = "E_n",
                UnidadeResultado = "eV",
                Icone = "E"
            },
            new Formula
            {
                Id = "cur_v12_qm_004",
                Nome = "Raio de Bohr para átomos hidrogenoides",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "r_n = a0·n²/Z",
                ExprTexto = "r n = a zero vezes n ao quadrado dividido por Z",
                Criador = "Niels Bohr",
                AnoOrigin = "1913",
                Descricao = "Raio orbital do modelo de Bohr para um sistema hidrogenoide idealizado.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Eisberg, R.; Resnick, R. Quantum Physics of Atoms, Molecules, Solids, Nuclei, and Particles, 2ª ed., Wiley, 1985. Cap. 4.",
                FonteUrlOuDoi = "https://archive.org/details/quantumphysicsof00eisb",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Número quântico principal", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e6 },
                    new Variavel { Simbolo = "Z", Nome = "Número atômico efetivo", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1, ValorMax = 1e3 }
                },
                Calcular = vars =>
                {
                    const double a0 = 5.29177210903e-11;
                    var n = Math.Max(1, vars.GetValueOrDefault("n", 1.0));
                    var Z = Math.Max(1, vars.GetValueOrDefault("Z", 1.0));
                    return a0 * n * n / Z;
                },
                VariavelResultado = "r_n",
                UnidadeResultado = "m",
                Icone = "r"
            },
            new Formula
            {
                Id = "cur_v12_qm_005",
                Nome = "Incerteza mínima no momento",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Δp_min = ħ/(2Δx)",
                ExprTexto = "Delta p mínimo = h cortado dividido por 2 Delta x",
                Criador = "Werner Heisenberg",
                AnoOrigin = "1927",
                Descricao = "Forma saturada do princípio de incerteza de Heisenberg para posição e momento.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Shankar, R. Principles of Quantum Mechanics, 2ª ed., Springer, 1994. Cap. 1.",
                FonteUrlOuDoi = "https://doi.org/10.1007/978-1-4757-0576-8",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dx", Nome = "Incerteza na posição", Unidade = "m", ValorPadrao = 1e-10, ValorMin = 1e-30, ValorMax = 1e10 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var dx = Math.Max(1e-30, vars.GetValueOrDefault("dx", 1e-10));
                    return hbar / (2.0 * dx);
                },
                VariavelResultado = "Δp_min",
                UnidadeResultado = "kg·m/s",
                Icone = "Δp"
            },
            new Formula
            {
                Id = "cur_v12_qm_006",
                Nome = "Coeficiente de transmissão por tunelamento (WKB)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "T ≈ exp(−2κL), κ = sqrt(2m(V−E))/ħ",
                ExprTexto = "T aproximadamente igual à exponencial de menos 2 kappa L",
                Criador = "Aproximação WKB",
                AnoOrigin = "1926",
                Descricao = "Estimativa do tunelamento através de uma barreira retangular para E < V no regime semiclassico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J.; Schroeter, D. F. Introduction to Quantum Mechanics, 3ª ed., Cambridge University Press, 2018. Cap. 8.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781316995433",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "m", Nome = "Massa da partícula", Unidade = "kg", ValorPadrao = 9.1093837015e-31, ValorMin = 1e-40, ValorMax = 1e10 },
                    new Variavel { Simbolo = "V", Nome = "Altura da barreira", Unidade = "J", ValorPadrao = 5e-19, ValorMin = 0, ValorMax = 1e10 },
                    new Variavel { Simbolo = "E", Nome = "Energia da partícula", Unidade = "J", ValorPadrao = 1e-19, ValorMin = 0, ValorMax = 1e10 },
                    new Variavel { Simbolo = "L", Nome = "Largura da barreira", Unidade = "m", ValorPadrao = 1e-9, ValorMin = 1e-30, ValorMax = 1e10 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var m = Math.Max(1e-40, vars.GetValueOrDefault("m", 9.1093837015e-31));
                    var V = Math.Max(0, vars.GetValueOrDefault("V", 5e-19));
                    var E = Math.Max(0, vars.GetValueOrDefault("E", 1e-19));
                    var L = Math.Max(1e-30, vars.GetValueOrDefault("L", 1e-9));
                    var delta = Math.Max(0, V - E);
                    var kappa = Math.Sqrt(2.0 * m * delta) / hbar;
                    return Math.Exp(-2.0 * kappa * L);
                },
                VariavelResultado = "T",
                UnidadeResultado = "adim",
                Icone = "T"
            },
            new Formula
            {
                Id = "cur_v12_qm_007",
                Nome = "Energia do oscilador harmônico quântico",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E_n = (n + 1/2)·ħω",
                ExprTexto = "E n = n mais um meio vezes h cortado omega",
                Criador = "Modelo do oscilador harmônico quântico",
                AnoOrigin = "Sec. XX",
                Descricao = "Espectro discreto do oscilador harmônico unidimensional, incluindo a energia de ponto zero.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Sakurai, J. J.; Napolitano, J. Modern Quantum Mechanics, 2ª ed., Cambridge University Press, 2017. Cap. 2.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108499996",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n", Nome = "Número quântico", Unidade = "adim", ValorPadrao = 0.0, ValorMin = 0, ValorMax = 1e6 },
                    new Variavel { Simbolo = "omega", Nome = "Frequência angular", Unidade = "rad/s", ValorPadrao = 1e15, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var n = Math.Max(0, vars.GetValueOrDefault("n", 0.0));
                    var omega = Math.Max(1e-30, vars.GetValueOrDefault("omega", 1e15));
                    return (n + 0.5) * hbar * omega;
                },
                VariavelResultado = "E_n",
                UnidadeResultado = "J",
                Icone = "E"
            },
            new Formula
            {
                Id = "cur_v12_qm_008",
                Nome = "Dispersão espacial no estado fundamental do oscilador harmônico",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "x_rms = sqrt(ħ/(2mω))",
                ExprTexto = "x rms = raiz de h cortado dividido por 2 m omega",
                Criador = "Oscilador harmônico quântico",
                AnoOrigin = "Sec. XX",
                Descricao = "Largura quadrática média da posição no estado fundamental do oscilador harmônico quântico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Sakurai, J. J.; Napolitano, J. Modern Quantum Mechanics, 2ª ed., Cambridge University Press, 2017. Cap. 2.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108499996",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "m", Nome = "Massa da partícula", Unidade = "kg", ValorPadrao = 9.1093837015e-31, ValorMin = 1e-40, ValorMax = 1e10 },
                    new Variavel { Simbolo = "omega", Nome = "Frequência angular", Unidade = "rad/s", ValorPadrao = 1e15, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var m = Math.Max(1e-40, vars.GetValueOrDefault("m", 9.1093837015e-31));
                    var omega = Math.Max(1e-30, vars.GetValueOrDefault("omega", 1e15));
                    return Math.Sqrt(hbar / (2.0 * m * omega));
                },
                VariavelResultado = "x_rms",
                UnidadeResultado = "m",
                Icone = "x"
            },
            new Formula
            {
                Id = "cur_v12_qm_009",
                Nome = "Densidade de probabilidade de Born",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "P = |ψ|²",
                ExprTexto = "P = módulo de psi ao quadrado",
                Criador = "Max Born",
                AnoOrigin = "1926",
                Descricao = "A probabilidade associada a uma função de onda unidimensional real ou ao módulo de uma amplitude complexa é proporcional ao quadrado do seu módulo.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Born, M. Zur Quantenmechanik der Stoßvorgänge. Zeitschrift für Physik 37, 863-867 (1926).",
                FonteUrlOuDoi = "https://doi.org/10.1007/BF01397477",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "psi", Nome = "Amplitude da função de onda", Unidade = "adim", ValorPadrao = 0.5, ValorMin = -1e15, ValorMax = 1e15 }
                },
                Calcular = vars =>
                {
                    var psi = vars.GetValueOrDefault("psi", 0.5);
                    return psi * psi;
                },
                VariavelResultado = "P",
                UnidadeResultado = "adim",
                Icone = "P"
            },
            new Formula
            {
                Id = "cur_v12_qm_010",
                Nome = "Módulo do momento angular orbital",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "|L| = sqrt(l(l+1))·ħ",
                ExprTexto = "modulo de L = raiz de l vezes l mais 1 vezes h cortado",
                Criador = "Quantização do momento angular",
                AnoOrigin = "Sec. XX",
                Descricao = "Valor do módulo do momento angular orbital em termos do número quântico azimutal l.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J.; Schroeter, D. F. Introduction to Quantum Mechanics, 3ª ed., Cambridge University Press, 2018. Cap. 4.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781316995433",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "l", Nome = "Número quântico azimutal", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 0, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var l = Math.Max(0, vars.GetValueOrDefault("l", 1.0));
                    return Math.Sqrt(l * (l + 1.0)) * hbar;
                },
                VariavelResultado = "|L|",
                UnidadeResultado = "J·s",
                Icone = "L"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Mecanica Quantica", lote);
    }

    private void AdicionarLoteCuradoPilotoEngenhariaQuimica()
    {
        const string categoria = "Engenharia Química";
        const string subCategoria = "Curadoria Piloto - Reatores e Transferência";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_che_001",
                Nome = "Conversão de reagente A",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "X = (F_A0 − F_A)/F_A0",
                ExprTexto = "X = (FA zero menos FA) dividido por FA zero",
                Criador = "Definição clássica de engenharia de reações",
                AnoOrigin = "Sec. XX",
                Descricao = "Define a fração do reagente A consumida em relação à alimentação inicial do processo reacional.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Fogler, H. S. Elements of Chemical Reaction Engineering, 5ª ed., Prentice Hall, 2016. Cap. 2.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/elements-of-chemical-reaction-engineering/P200000003276",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "FA0", Nome = "Vazão molar inicial de A", Unidade = "mol/s", ValorPadrao = 10.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "FA", Nome = "Vazão molar de A na saída", Unidade = "mol/s", ValorPadrao = 4.0, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var FA0 = Math.Max(1e-30, vars.GetValueOrDefault("FA0", 10.0));
                    var FA = Math.Max(0, vars.GetValueOrDefault("FA", 4.0));
                    return (FA0 - FA) / FA0;
                },
                VariavelResultado = "X",
                UnidadeResultado = "adim",
                Icone = "X"
            },
            new Formula
            {
                Id = "cur_v12_che_002",
                Nome = "Tempo espacial",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "τ = V/v0",
                ExprTexto = "tau = V dividido por v zero",
                Criador = "Definição clássica de escoamento reacional",
                AnoOrigin = "Sec. XX",
                Descricao = "Tempo característico associado ao volume do reator e à vazão volumétrica de alimentação.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Fogler, H. S. Elements of Chemical Reaction Engineering, 5ª ed., Prentice Hall, 2016. Cap. 4.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/elements-of-chemical-reaction-engineering/P200000003276",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "V", Nome = "Volume do reator", Unidade = "m³", ValorPadrao = 1.5, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "v0", Nome = "Vazão volumétrica de entrada", Unidade = "m³/s", ValorPadrao = 0.1, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var V = Math.Max(1e-30, vars.GetValueOrDefault("V", 1.5));
                    var v0 = Math.Max(1e-30, vars.GetValueOrDefault("v0", 0.1));
                    return V / v0;
                },
                VariavelResultado = "τ",
                UnidadeResultado = "s",
                Icone = "τ"
            },
            new Formula
            {
                Id = "cur_v12_che_003",
                Nome = "Volume de CSTR ideal",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "V = F_A0·X/(−r_A)",
                ExprTexto = "V = FA zero vezes X dividido por menos rA",
                Criador = "Projeto clássico de CSTR",
                AnoOrigin = "Sec. XX",
                Descricao = "Equação de projeto para reator tanque agitado contínuo ideal em regime permanente.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Fogler, H. S. Elements of Chemical Reaction Engineering, 5ª ed., Prentice Hall, 2016. Cap. 5.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/elements-of-chemical-reaction-engineering/P200000003276",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "FA0", Nome = "Vazão molar inicial de A", Unidade = "mol/s", ValorPadrao = 10.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "X", Nome = "Conversão desejada", Unidade = "adim", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 0.999999999 },
                    new Variavel { Simbolo = "rA", Nome = "Velocidade de desaparecimento de A", Unidade = "mol/(m³·s)", ValorPadrao = 2.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var FA0 = Math.Max(1e-30, vars.GetValueOrDefault("FA0", 10.0));
                    var X = Math.Clamp(vars.GetValueOrDefault("X", 0.8), 0, 0.999999999);
                    var rA = Math.Max(1e-30, vars.GetValueOrDefault("rA", 2.0));
                    return FA0 * X / rA;
                },
                VariavelResultado = "V",
                UnidadeResultado = "m³",
                Icone = "V"
            },
            new Formula
            {
                Id = "cur_v12_che_004",
                Nome = "Conversão em PFR de primeira ordem",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "X = 1 − exp(−kτ)",
                ExprTexto = "X = 1 menos exponencial de menos k tau",
                Criador = "Solução clássica para PFR ideal",
                AnoOrigin = "Sec. XX",
                Descricao = "Conversão de um reagente em reator tubular ideal com cinética de primeira ordem e densidade aproximadamente constante.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Fogler, H. S. Elements of Chemical Reaction Engineering, 5ª ed., Prentice Hall, 2016. Cap. 5.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/elements-of-chemical-reaction-engineering/P200000003276",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Constante cinética de primeira ordem", Unidade = "s⁻¹", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "tau", Nome = "Tempo espacial", Unidade = "s", ValorPadrao = 10.0, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var k = Math.Max(0, vars.GetValueOrDefault("k", 0.2));
                    var tau = Math.Max(0, vars.GetValueOrDefault("tau", 10.0));
                    return 1.0 - Math.Exp(-k * tau);
                },
                VariavelResultado = "X",
                UnidadeResultado = "adim",
                Icone = "X"
            },
            new Formula
            {
                Id = "cur_v12_che_005",
                Nome = "Balanço de calor em trocador",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Q = U·A·ΔT_lm",
                ExprTexto = "Q = U vezes A vezes delta T logaritmica media",
                Criador = "Projeto clássico de trocadores de calor",
                AnoOrigin = "Sec. XX",
                Descricao = "Taxa de calor transferido em um trocador usando coeficiente global, área e diferença média logarítmica de temperatura.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Incropera, F. P.; DeWitt, D. P. Fundamentals of Heat and Mass Transfer, 7ª ed., Wiley, 2011. Cap. 14.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Fundamentals+of+Heat+and+Mass+Transfer%2C+7th+Edition-p-9780470501962",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "U", Nome = "Coeficiente global de troca térmica", Unidade = "W/(m²·K)", ValorPadrao = 500.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "A", Nome = "Área de troca térmica", Unidade = "m²", ValorPadrao = 20.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "dTlm", Nome = "Diferença média logarítmica de temperatura", Unidade = "K", ValorPadrao = 25.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var U = Math.Max(1e-30, vars.GetValueOrDefault("U", 500.0));
                    var A = Math.Max(1e-30, vars.GetValueOrDefault("A", 20.0));
                    var dTlm = Math.Max(1e-30, vars.GetValueOrDefault("dTlm", 25.0));
                    return U * A * dTlm;
                },
                VariavelResultado = "Q",
                UnidadeResultado = "W",
                Icone = "Q"
            },
            new Formula
            {
                Id = "cur_v12_che_006",
                Nome = "Diferença média logarítmica de temperatura",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔT_lm = (ΔT1 − ΔT2)/ln(ΔT1/ΔT2)",
                ExprTexto = "delta T logaritmica media = delta T1 menos delta T2 dividido pelo logaritmo natural de delta T1 sobre delta T2",
                Criador = "Método LMTD",
                AnoOrigin = "Sec. XX",
                Descricao = "Diferença de temperatura equivalente para trocadores de calor com variação de gradiente térmico ao longo do equipamento.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Kern, D. Q. Process Heat Transfer, McGraw-Hill, 1950. Cap. 8.",
                FonteUrlOuDoi = "https://archive.org/details/processheattrans00kern",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dT1", Nome = "Diferença de temperatura em uma extremidade", Unidade = "K", ValorPadrao = 40.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "dT2", Nome = "Diferença de temperatura na outra extremidade", Unidade = "K", ValorPadrao = 20.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var dT1 = Math.Max(1e-30, vars.GetValueOrDefault("dT1", 40.0));
                    var dT2 = Math.Max(1e-30, vars.GetValueOrDefault("dT2", 20.0));
                    if (Math.Abs(dT1 - dT2) < 1e-12)
                    {
                        return dT1;
                    }

                    return (dT1 - dT2) / Math.Log(dT1 / dT2);
                },
                VariavelResultado = "ΔT_lm",
                UnidadeResultado = "K",
                Icone = "ΔT"
            },
            new Formula
            {
                Id = "cur_v12_che_007",
                Nome = "Fluxo molar difusivo de Fick",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "N_A = −D_AB·dC_A/dz",
                ExprTexto = "N A = menos D AB vezes derivada de C A em relação a z",
                Criador = "Adolf Fick",
                AnoOrigin = "1855",
                Descricao = "Primeira lei de Fick para difusão unidimensional em regime estacionário.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Geankoplis, C. J. Transport Processes and Separation Process Principles, 4ª ed., Prentice Hall, 2003. Cap. 2.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/transport-processes-and-separation-process-principles/P200000003463",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "DAB", Nome = "Coeficiente de difusão binária", Unidade = "m²/s", ValorPadrao = 1e-9, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "dCdz", Nome = "Gradiente de concentração", Unidade = "mol/(m⁴)", ValorPadrao = -100.0, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var DAB = Math.Max(1e-30, vars.GetValueOrDefault("DAB", 1e-9));
                    var dCdz = vars.GetValueOrDefault("dCdz", -100.0);
                    return -DAB * dCdz;
                },
                VariavelResultado = "N_A",
                UnidadeResultado = "mol/(m²·s)",
                Icone = "N"
            },
            new Formula
            {
                Id = "cur_v12_che_008",
                Nome = "Relação de volatilidade relativa",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "y = αx/[1 + (α − 1)x]",
                ExprTexto = "y = alfa x dividido por 1 mais alfa menos 1 vezes x",
                Criador = "Modelagem clássica de equilíbrio vapor-líquido",
                AnoOrigin = "Sec. XX",
                Descricao = "Relação aproximada entre composição no vapor e no líquido para sistemas binários com volatilidade relativa constante.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "McCabe, W. L.; Smith, J. C.; Harriott, P. Unit Operations of Chemical Engineering, 7ª ed., McGraw-Hill, 2005. Cap. 21.",
                FonteUrlOuDoi = "https://www.mheducation.com/highered/product/unit-operations-chemical-engineering-mccabe-smith/M9780072848236.html",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "alpha", Nome = "Volatilidade relativa", Unidade = "adim", ValorPadrao = 2.5, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "x", Nome = "Fração molar no líquido", Unidade = "adim", ValorPadrao = 0.4, ValorMin = 0, ValorMax = 1 }
                },
                Calcular = vars =>
                {
                    var alpha = Math.Max(1e-30, vars.GetValueOrDefault("alpha", 2.5));
                    var x = Math.Clamp(vars.GetValueOrDefault("x", 0.4), 0, 1);
                    return alpha * x / (1.0 + (alpha - 1.0) * x);
                },
                VariavelResultado = "y",
                UnidadeResultado = "adim",
                Icone = "y"
            },
            new Formula
            {
                Id = "cur_v12_che_009",
                Nome = "Queda de pressão pela equação de Ergun",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔP/L = 150μ(1−ε)²v/(d_p²ε³) + 1.75ρ(1−ε)v²/(d_pε³)",
                ExprTexto = "delta P sobre L pela equacao de Ergun",
                Criador = "Sabri Ergun",
                AnoOrigin = "1952",
                Descricao = "Estimativa da perda de carga em leitos empacotados combinando contribuições viscosas e inerciais.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Ergun, S. Fluid Flow through Packed Columns. Chemical Engineering Progress 48(2), 89-94, 1952.",
                FonteUrlOuDoi = "https://www.researchgate.net/publication/244155878_Fluid_Flow_through_Packed_Columns",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinâmica", Unidade = "Pa·s", ValorPadrao = 1e-3, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "eps", Nome = "Porosidade do leito", Unidade = "adim", ValorPadrao = 0.4, ValorMin = 1e-6, ValorMax = 0.999999 },
                    new Variavel { Simbolo = "v", Nome = "Velocidade superficial", Unidade = "m/s", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "dp", Nome = "Diâmetro de partícula", Unidade = "m", ValorPadrao = 5e-3, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "rho", Nome = "Densidade do fluido", Unidade = "kg/m³", ValorPadrao = 1000.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var mu = Math.Max(1e-30, vars.GetValueOrDefault("mu", 1e-3));
                    var eps = Math.Clamp(vars.GetValueOrDefault("eps", 0.4), 1e-6, 0.999999);
                    var v = Math.Max(0, vars.GetValueOrDefault("v", 0.2));
                    var dp = Math.Max(1e-30, vars.GetValueOrDefault("dp", 5e-3));
                    var rho = Math.Max(1e-30, vars.GetValueOrDefault("rho", 1000.0));
                    return 150.0 * mu * Math.Pow(1.0 - eps, 2.0) * v / (dp * dp * Math.Pow(eps, 3.0))
                        + 1.75 * rho * (1.0 - eps) * v * v / (dp * Math.Pow(eps, 3.0));
                },
                VariavelResultado = "ΔP/L",
                UnidadeResultado = "Pa/m",
                Icone = "ΔP"
            },
            new Formula
            {
                Id = "cur_v12_che_010",
                Nome = "Equação de Antoine",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "log10(P_sat) = A − B/(T + C)",
                ExprTexto = "log decimal de P sat = A menos B dividido por T mais C",
                Criador = "Louis Charles Antoine",
                AnoOrigin = "1888",
                Descricao = "Correlação empírica para pressão de vapor de um componente puro em uma faixa de temperatura especificada.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Perry, R. H.; Green, D. W. Perry's Chemical Engineers' Handbook, 8ª ed., McGraw-Hill, 2008. Seção 2.",
                FonteUrlOuDoi = "https://www.mheducation.com/highered/product/perry-s-chemical-engineers-handbook-perry-green/M9780071422949.html",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Constante A de Antoine", Unidade = "adim", ValorPadrao = 8.07131, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "B", Nome = "Constante B de Antoine", Unidade = "°C", ValorPadrao = 1730.63, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "C", Nome = "Constante C de Antoine", Unidade = "°C", ValorPadrao = 233.426, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "°C", ValorPadrao = 100.0, ValorMin = -273.15, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var A = vars.GetValueOrDefault("A", 8.07131);
                    var B = vars.GetValueOrDefault("B", 1730.63);
                    var C = vars.GetValueOrDefault("C", 233.426);
                    var T = vars.GetValueOrDefault("T", 100.0);
                    return Math.Pow(10.0, A - B / (T + C));
                },
                VariavelResultado = "P_sat",
                UnidadeResultado = "mmHg",
                Icone = "P"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Engenharia Quimica", lote);
    }

    private void AdicionarLoteCuradoPilotoQuimicaAnalitica()
    {
        const string categoria = "Química Analítica";
        const string subCategoria = "Curadoria Piloto - Titulação e Instrumentação";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_ana_001",
                Nome = "Lei de Beer-Lambert",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "A = ε·b·c",
                ExprTexto = "A = epsilon vezes b vezes c",
                Criador = "A. Beer / J. H. Lambert",
                AnoOrigin = "Sec. XIX",
                Descricao = "Relaciona a absorbância com a absortividade molar, o caminho óptico e a concentração da espécie absorvente.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Skoog, D. A.; Holler, F. J.; Crouch, S. R. Principles of Instrumental Analysis, 7ª ed., Cengage, 2017. Cap. 13.",
                FonteUrlOuDoi = "https://www.cengage.com/c/principles-of-instrumental-analysis-7e-skoog/",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "eps", Nome = "Absortividade molar", Unidade = "L/(mol·cm)", ValorPadrao = 15000.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "b", Nome = "Caminho óptico", Unidade = "cm", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "c", Nome = "Concentração", Unidade = "mol/L", ValorPadrao = 1e-4, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var eps = Math.Max(0, vars.GetValueOrDefault("eps", 15000.0));
                    var b = Math.Max(1e-30, vars.GetValueOrDefault("b", 1.0));
                    var c = Math.Max(0, vars.GetValueOrDefault("c", 1e-4));
                    return eps * b * c;
                },
                VariavelResultado = "A",
                UnidadeResultado = "adim",
                Icone = "A"
            },
            new Formula
            {
                Id = "cur_v12_ana_002",
                Nome = "Transmittância a partir da absorbância",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "T = 10^(−A)",
                ExprTexto = "T = 10 elevado a menos A",
                Criador = "Relação espectrofotométrica clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Converte absorbância em transmittância fracionária em medições ópticas.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Skoog, D. A.; Holler, F. J.; Crouch, S. R. Principles of Instrumental Analysis, 7ª ed., Cengage, 2017. Cap. 13.",
                FonteUrlOuDoi = "https://www.cengage.com/c/principles-of-instrumental-analysis-7e-skoog/",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Absorbância", Unidade = "adim", ValorPadrao = 0.500, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var A = vars.GetValueOrDefault("A", 0.500);
                    return Math.Pow(10.0, -A);
                },
                VariavelResultado = "T",
                UnidadeResultado = "adim",
                Icone = "T"
            },
            new Formula
            {
                Id = "cur_v12_ana_003",
                Nome = "pH",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "pH = −log10([H+])",
                ExprTexto = "pH = menos log decimal da concentração de H mais",
                Criador = "Søren P. L. Sørensen",
                AnoOrigin = "1909",
                Descricao = "Define o potencial hidrogeniônico em termos da atividade ou concentração efetiva de íons hidrogênio.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Harris, D. C. Quantitative Chemical Analysis, 10ª ed., W. H. Freeman, 2020. Cap. 9.",
                FonteUrlOuDoi = "https://store.macmillanlearning.com/us/product/Quantitative-Chemical-Analysis/p/1319164307",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "H", Nome = "Concentração de H+", Unidade = "mol/L", ValorPadrao = 1e-7, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var H = Math.Max(1e-300, vars.GetValueOrDefault("H", 1e-7));
                    return -Math.Log10(H);
                },
                VariavelResultado = "pH",
                UnidadeResultado = "adim",
                Icone = "pH"
            },
            new Formula
            {
                Id = "cur_v12_ana_004",
                Nome = "pOH",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "pOH = −log10([OH−])",
                ExprTexto = "pOH = menos log decimal da concentração de OH menos",
                Criador = "Convenção ácido-base clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Define o potencial hidroxiliônico em termos da atividade ou concentração efetiva de íons hidróxido.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Harris, D. C. Quantitative Chemical Analysis, 10ª ed., W. H. Freeman, 2020. Cap. 9.",
                FonteUrlOuDoi = "https://store.macmillanlearning.com/us/product/Quantitative-Chemical-Analysis/p/1319164307",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "OH", Nome = "Concentração de OH-", Unidade = "mol/L", ValorPadrao = 1e-7, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var OH = Math.Max(1e-300, vars.GetValueOrDefault("OH", 1e-7));
                    return -Math.Log10(OH);
                },
                VariavelResultado = "pOH",
                UnidadeResultado = "adim",
                Icone = "pOH"
            },
            new Formula
            {
                Id = "cur_v12_ana_005",
                Nome = "Henderson-Hasselbalch",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "pH = pKa + log10([A−]/[HA])",
                ExprTexto = "pH = pKa mais log decimal de A menos sobre HA",
                Criador = "L. J. Henderson / K. A. Hasselbalch",
                AnoOrigin = "1908",
                Descricao = "Aproximação útil para soluções tampão, relacionando pH, pKa e a razão base conjugada/ácido fraco.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Harris, D. C. Quantitative Chemical Analysis, 10ª ed., W. H. Freeman, 2020. Cap. 10.",
                FonteUrlOuDoi = "https://store.macmillanlearning.com/us/product/Quantitative-Chemical-Analysis/p/1319164307",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "pKa", Nome = "pKa do ácido", Unidade = "adim", ValorPadrao = 4.76, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Aminus", Nome = "Concentração da base conjugada", Unidade = "mol/L", ValorPadrao = 0.10, ValorMin = 1e-300, ValorMax = 1e30 },
                    new Variavel { Simbolo = "HA", Nome = "Concentração do ácido fraco", Unidade = "mol/L", ValorPadrao = 0.10, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var pKa = vars.GetValueOrDefault("pKa", 4.76);
                    var Aminus = Math.Max(1e-300, vars.GetValueOrDefault("Aminus", 0.10));
                    var HA = Math.Max(1e-300, vars.GetValueOrDefault("HA", 0.10));
                    return pKa + Math.Log10(Aminus / HA);
                },
                VariavelResultado = "pH",
                UnidadeResultado = "adim",
                Icone = "pH"
            },
            new Formula
            {
                Id = "cur_v12_ana_006",
                Nome = "Percentual de recuperação analítica",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Rec% = 100·C_encontrada/C_adicionada",
                ExprTexto = "recuperação percentual = 100 vezes concentração encontrada sobre concentração adicionada",
                Criador = "Métrica clássica de validação analítica",
                AnoOrigin = "Sec. XX",
                Descricao = "Mede a exatidão de um método pela fração do analito recuperada em ensaios de fortificação.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Eurachem Guide: The Fitness for Purpose of Analytical Methods, 2014. Seção 7.",
                FonteUrlOuDoi = "https://www.eurachem.org/index.php/publications/guides/fitness-for-purpose",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Cfound", Nome = "Concentração encontrada", Unidade = "mg/L", ValorPadrao = 95.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Cspike", Nome = "Concentração adicionada", Unidade = "mg/L", ValorPadrao = 100.0, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var Cfound = Math.Max(0, vars.GetValueOrDefault("Cfound", 95.0));
                    var Cspike = Math.Max(1e-300, vars.GetValueOrDefault("Cspike", 100.0));
                    return 100.0 * Cfound / Cspike;
                },
                VariavelResultado = "Rec%",
                UnidadeResultado = "%",
                Icone = "%"
            },
            new Formula
            {
                Id = "cur_v12_ana_007",
                Nome = "Desvio padrão relativo",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "RSD% = 100·s/x̄",
                ExprTexto = "RSD percentual = 100 vezes desvio padrão sobre média",
                Criador = "Estatística analítica clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Mede a precisão relativa de um conjunto de replicatas analíticas.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Miller, J. N.; Miller, J. C. Statistics and Chemometrics for Analytical Chemistry, 7ª ed., Pearson, 2018. Cap. 2.",
                FonteUrlOuDoi = "https://www.pearson.com/en-gb/subject-catalog/p/statistics-and-chemometrics-for-analytical-chemistry/P200000003643",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "s", Nome = "Desvio padrão", Unidade = "mesma da medida", ValorPadrao = 0.50, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "xbar", Nome = "Média amostral", Unidade = "mesma da medida", ValorPadrao = 10.0, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var s = Math.Max(0, vars.GetValueOrDefault("s", 0.50));
                    var xbar = Math.Max(1e-300, vars.GetValueOrDefault("xbar", 10.0));
                    return 100.0 * s / xbar;
                },
                VariavelResultado = "RSD%",
                UnidadeResultado = "%",
                Icone = "σ"
            },
            new Formula
            {
                Id = "cur_v12_ana_008",
                Nome = "Resolução cromatográfica",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Rs = 2(tR2 − tR1)/(w1 + w2)",
                ExprTexto = "Rs = 2 vezes tR2 menos tR1 dividido por w1 mais w2",
                Criador = "Cromatografia clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Quantifica a separação entre dois picos cromatográficos com base nos tempos de retenção e larguras de pico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Skoog, D. A.; Holler, F. J.; Crouch, S. R. Principles of Instrumental Analysis, 7ª ed., Cengage, 2017. Cap. 28.",
                FonteUrlOuDoi = "https://www.cengage.com/c/principles-of-instrumental-analysis-7e-skoog/",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "tR1", Nome = "Tempo de retenção do pico 1", Unidade = "min", ValorPadrao = 5.00, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "tR2", Nome = "Tempo de retenção do pico 2", Unidade = "min", ValorPadrao = 6.00, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "w1", Nome = "Largura do pico 1", Unidade = "min", ValorPadrao = 0.20, ValorMin = 1e-300, ValorMax = 1e30 },
                    new Variavel { Simbolo = "w2", Nome = "Largura do pico 2", Unidade = "min", ValorPadrao = 0.20, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var tR1 = Math.Max(0, vars.GetValueOrDefault("tR1", 5.00));
                    var tR2 = Math.Max(0, vars.GetValueOrDefault("tR2", 6.00));
                    var w1 = Math.Max(1e-300, vars.GetValueOrDefault("w1", 0.20));
                    var w2 = Math.Max(1e-300, vars.GetValueOrDefault("w2", 0.20));
                    return 2.0 * (tR2 - tR1) / (w1 + w2);
                },
                VariavelResultado = "Rs",
                UnidadeResultado = "adim",
                Icone = "Rs"
            },
            new Formula
            {
                Id = "cur_v12_ana_009",
                Nome = "Fator de retenção cromatográfica",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "k' = (tR − tM)/tM",
                ExprTexto = "k linha = tR menos tM dividido por tM",
                Criador = "Cromatografia clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Mede o quanto um analito fica retido na fase estacionária relativamente ao tempo morto da coluna.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Snyder, L. R.; Kirkland, J. J.; Dolan, J. W. Introduction to Modern Liquid Chromatography, 3ª ed., Wiley, 2010. Cap. 2.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/9780470508183",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "tR", Nome = "Tempo de retenção", Unidade = "min", ValorPadrao = 6.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "tM", Nome = "Tempo morto", Unidade = "min", ValorPadrao = 1.5, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var tR = Math.Max(0, vars.GetValueOrDefault("tR", 6.0));
                    var tM = Math.Max(1e-300, vars.GetValueOrDefault("tM", 1.5));
                    return (tR - tM) / tM;
                },
                VariavelResultado = "k'",
                UnidadeResultado = "adim",
                Icone = "k"
            },
            new Formula
            {
                Id = "cur_v12_ana_010",
                Nome = "Limite de detecção instrumental",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "LOD = 3·σ/m",
                ExprTexto = "LOD = 3 vezes sigma dividido por m",
                Criador = "Convenção analítica clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Estimativa operacional do limite de detecção a partir do desvio padrão do branco e da sensibilidade da curva analítica.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Miller, J. N.; Miller, J. C. Statistics and Chemometrics for Analytical Chemistry, 7ª ed., Pearson, 2018. Cap. 4.",
                FonteUrlOuDoi = "https://www.pearson.com/en-gb/subject-catalog/p/statistics-and-chemometrics-for-analytical-chemistry/P200000003643",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "sigma", Nome = "Desvio padrão do branco", Unidade = "sinal", ValorPadrao = 0.002, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "m", Nome = "Inclinação da curva analítica", Unidade = "sinal por concentração", ValorPadrao = 0.100, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var sigma = Math.Max(0, vars.GetValueOrDefault("sigma", 0.002));
                    var m = Math.Max(1e-300, vars.GetValueOrDefault("m", 0.100));
                    return 3.0 * sigma / m;
                },
                VariavelResultado = "LOD",
                UnidadeResultado = "concentração",
                Icone = "LOD"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Quimica Analitica", lote);
    }

    private void AdicionarLoteCuradoPilotoEletromagnetismoAvancado()
    {
        const string categoria = "Eletromagnetismo";
        const string subCategoria = "Curadoria Piloto - Avançado";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_em_001",
                Nome = "Fluxo elétrico por Gauss",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Φ_E = Q/ε0",
                ExprTexto = "fluxo elétrico = Q dividido por epsilon zero",
                Criador = "Carl Friedrich Gauss",
                AnoOrigin = "Sec. XIX",
                Descricao = "Fluxo elétrico total através de uma superfície fechada em função da carga líquida encerrada.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J. Introduction to Electrodynamics, 4ª ed., Cambridge University Press, 2017. Cap. 2.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108333511",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "Q", Nome = "Carga encerrada", Unidade = "C", ValorPadrao = 1e-9, ValorMin = -1e30, ValorMax = 1e30 } },
                Calcular = vars => vars.GetValueOrDefault("Q", 1e-9) / 8.8541878128e-12,
                VariavelResultado = "Φ_E",
                UnidadeResultado = "N·m²/C",
                Icone = "Φ"
            },
            new Formula
            {
                Id = "cur_v12_em_002",
                Nome = "Capacitância de placas paralelas",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "C = εA/d",
                ExprTexto = "C = epsilon vezes A dividido por d",
                Criador = "Eletrostática clássica",
                AnoOrigin = "Sec. XIX",
                Descricao = "Capacitância ideal de um capacitor de placas paralelas com dielétrico homogêneo.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J. Introduction to Electrodynamics, 4ª ed., Cambridge University Press, 2017. Cap. 2.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108333511",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "eps_r", Nome = "Permissividade relativa", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "A", Nome = "Área da placa", Unidade = "m²", ValorPadrao = 1e-2, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "d", Nome = "Separação entre placas", Unidade = "m", ValorPadrao = 1e-3, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var epsR = Math.Max(1e-30, vars.GetValueOrDefault("eps_r", 1.0));
                    var area = Math.Max(1e-30, vars.GetValueOrDefault("A", 1e-2));
                    var d = Math.Max(1e-30, vars.GetValueOrDefault("d", 1e-3));
                    return 8.8541878128e-12 * epsR * area / d;
                },
                VariavelResultado = "C",
                UnidadeResultado = "F",
                Icone = "C"
            },
            new Formula
            {
                Id = "cur_v12_em_003",
                Nome = "Densidade de energia elétrica",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "u_E = (1/2)εE²",
                ExprTexto = "u E = um meio vezes epsilon vezes E ao quadrado",
                Criador = "Eletromagnetismo clássico",
                AnoOrigin = "Sec. XIX",
                Descricao = "Energia armazenada por unidade de volume em um campo elétrico uniforme.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Jackson, J. D. Classical Electrodynamics, 3ª ed., Wiley, 1998. Cap. 6.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/9783527618460",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "eps_r", Nome = "Permissividade relativa", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "E", Nome = "Campo elétrico", Unidade = "V/m", ValorPadrao = 1e5, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var epsR = Math.Max(1e-30, vars.GetValueOrDefault("eps_r", 1.0));
                    var field = vars.GetValueOrDefault("E", 1e5);
                    return 0.5 * 8.8541878128e-12 * epsR * field * field;
                },
                VariavelResultado = "u_E",
                UnidadeResultado = "J/m³",
                Icone = "u"
            },
            new Formula
            {
                Id = "cur_v12_em_004",
                Nome = "Densidade de energia magnética",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "u_B = B²/(2μ)",
                ExprTexto = "u B = B ao quadrado dividido por 2 mu",
                Criador = "Eletromagnetismo clássico",
                AnoOrigin = "Sec. XIX",
                Descricao = "Energia armazenada por unidade de volume em um campo magnético uniforme.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Jackson, J. D. Classical Electrodynamics, 3ª ed., Wiley, 1998. Cap. 6.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/9783527618460",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "mu_r", Nome = "Permeabilidade relativa", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "B", Nome = "Campo magnético", Unidade = "T", ValorPadrao = 0.5, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var muR = Math.Max(1e-30, vars.GetValueOrDefault("mu_r", 1.0));
                    var field = vars.GetValueOrDefault("B", 0.5);
                    var mu = 4e-7 * Math.PI * muR;
                    return field * field / (2.0 * mu);
                },
                VariavelResultado = "u_B",
                UnidadeResultado = "J/m³",
                Icone = "u"
            },
            new Formula
            {
                Id = "cur_v12_em_005",
                Nome = "Indutância de solenóide longo",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "L = μN²A/l",
                ExprTexto = "L = mu vezes N ao quadrado vezes A dividido por l",
                Criador = "Magnetostática clássica",
                AnoOrigin = "Sec. XIX",
                Descricao = "Indutância aproximada de um solenóide longo com N espiras, área A e comprimento l.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J. Introduction to Electrodynamics, 4ª ed., Cambridge University Press, 2017. Cap. 7.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108333511",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "mu_r", Nome = "Permeabilidade relativa", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "N", Nome = "Número de espiras", Unidade = "adim", ValorPadrao = 500.0, ValorMin = 1, ValorMax = 1e30 },
                    new Variavel { Simbolo = "A", Nome = "Área da seção", Unidade = "m²", ValorPadrao = 1e-4, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "l", Nome = "Comprimento do solenóide", Unidade = "m", ValorPadrao = 0.2, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var muR = Math.Max(1e-30, vars.GetValueOrDefault("mu_r", 1.0));
                    var turns = Math.Max(1, vars.GetValueOrDefault("N", 500.0));
                    var area = Math.Max(1e-30, vars.GetValueOrDefault("A", 1e-4));
                    var length = Math.Max(1e-30, vars.GetValueOrDefault("l", 0.2));
                    return 4e-7 * Math.PI * muR * turns * turns * area / length;
                },
                VariavelResultado = "L",
                UnidadeResultado = "H",
                Icone = "L"
            },
            new Formula
            {
                Id = "cur_v12_em_006",
                Nome = "Frequência angular de ressonância LC",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ω0 = 1/sqrt(LC)",
                ExprTexto = "omega zero = um dividido pela raiz de L vezes C",
                Criador = "Circuitos eletromagnéticos clássicos",
                AnoOrigin = "Sec. XIX",
                Descricao = "Frequência angular natural de um circuito LC ideal sem dissipação.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Purcell, E. M.; Morin, D. J. Electricity and Magnetism, 3ª ed., Cambridge University Press, 2013. Cap. 8.",
                FonteUrlOuDoi = "https://doi.org/10.1017/CBO9781139017336",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "L", Nome = "Indutância", Unidade = "H", ValorPadrao = 1e-3, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "C", Nome = "Capacitância", Unidade = "F", ValorPadrao = 1e-6, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var L = Math.Max(1e-30, vars.GetValueOrDefault("L", 1e-3));
                    var C = Math.Max(1e-30, vars.GetValueOrDefault("C", 1e-6));
                    return 1.0 / Math.Sqrt(L * C);
                },
                VariavelResultado = "ω0",
                UnidadeResultado = "rad/s",
                Icone = "ω"
            },
            new Formula
            {
                Id = "cur_v12_em_007",
                Nome = "Módulo do vetor de Poynting",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "S = E·B/μ0",
                ExprTexto = "S = E vezes B dividido por mu zero",
                Criador = "John Henry Poynting",
                AnoOrigin = "1884",
                Descricao = "Densidade de fluxo de potência de uma onda eletromagnética plana no vácuo.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J. Introduction to Electrodynamics, 4ª ed., Cambridge University Press, 2017. Cap. 9.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108333511",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "E", Nome = "Campo elétrico", Unidade = "V/m", ValorPadrao = 100.0, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "B", Nome = "Campo magnético", Unidade = "T", ValorPadrao = 3.33564e-7, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars => vars.GetValueOrDefault("E", 100.0) * vars.GetValueOrDefault("B", 3.33564e-7) / (4e-7 * Math.PI),
                VariavelResultado = "S",
                UnidadeResultado = "W/m²",
                Icone = "S"
            },
            new Formula
            {
                Id = "cur_v12_em_008",
                Nome = "Profundidade de penetração (skin depth)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "δ = sqrt(2/(ωμσ))",
                ExprTexto = "delta = raiz de 2 dividido por omega mu sigma",
                Criador = "Eletromagnetismo em condutores",
                AnoOrigin = "Sec. XIX",
                Descricao = "Profundidade característica de decaimento de ondas eletromagnéticas em bons condutores.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Balanis, C. A. Advanced Engineering Electromagnetics, 2ª ed., Wiley, 2012. Cap. 2.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Advanced+Engineering+Electromagnetics%2C+2nd+Edition-p-9780470589489",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "omega", Nome = "Frequência angular", Unidade = "rad/s", ValorPadrao = 2 * Math.PI * 60.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "mu_r", Nome = "Permeabilidade relativa", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "sigma", Nome = "Condutividade", Unidade = "S/m", ValorPadrao = 5.8e7, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var omega = Math.Max(1e-30, vars.GetValueOrDefault("omega", 2 * Math.PI * 60.0));
                    var muR = Math.Max(1e-30, vars.GetValueOrDefault("mu_r", 1.0));
                    var sigma = Math.Max(1e-30, vars.GetValueOrDefault("sigma", 5.8e7));
                    var mu = 4e-7 * Math.PI * muR;
                    return Math.Sqrt(2.0 / (omega * mu * sigma));
                },
                VariavelResultado = "δ",
                UnidadeResultado = "m",
                Icone = "δ"
            },
            new Formula
            {
                Id = "cur_v12_em_009",
                Nome = "Impedância intrínseca do meio",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "η = sqrt(μ/ε)",
                ExprTexto = "eta = raiz de mu sobre epsilon",
                Criador = "Ondas eletromagnéticas clássicas",
                AnoOrigin = "Sec. XIX",
                Descricao = "Relação entre campos elétrico e magnético em uma onda plana num meio linear, homogêneo e isotrópico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Balanis, C. A. Advanced Engineering Electromagnetics, 2ª ed., Wiley, 2012. Cap. 2.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Advanced+Engineering+Electromagnetics%2C+2nd+Edition-p-9780470589489",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "mu_r", Nome = "Permeabilidade relativa", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "eps_r", Nome = "Permissividade relativa", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var muR = Math.Max(1e-30, vars.GetValueOrDefault("mu_r", 1.0));
                    var epsR = Math.Max(1e-30, vars.GetValueOrDefault("eps_r", 1.0));
                    var mu = 4e-7 * Math.PI * muR;
                    var eps = 8.8541878128e-12 * epsR;
                    return Math.Sqrt(mu / eps);
                },
                VariavelResultado = "η",
                UnidadeResultado = "ohm",
                Icone = "η"
            },
            new Formula
            {
                Id = "cur_v12_em_010",
                Nome = "Potência irradiada de Larmor",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "P = q²a²/(6π ε0 c³)",
                ExprTexto = "P = q ao quadrado vezes a ao quadrado dividido por 6 pi epsilon zero c ao cubo",
                Criador = "Joseph Larmor",
                AnoOrigin = "1897",
                Descricao = "Potência emitida por uma carga puntiforme não relativística acelerada no vácuo.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Jackson, J. D. Classical Electrodynamics, 3ª ed., Wiley, 1998. Cap. 14.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/9783527618460",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "q", Nome = "Carga elétrica", Unidade = "C", ValorPadrao = 1.602176634e-19, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "a", Nome = "Aceleração", Unidade = "m/s²", ValorPadrao = 1e15, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var q = vars.GetValueOrDefault("q", 1.602176634e-19);
                    var a = vars.GetValueOrDefault("a", 1e15);
                    const double eps0 = 8.8541878128e-12;
                    const double c = 299792458.0;
                    return q * q * a * a / (6.0 * Math.PI * eps0 * c * c * c);
                },
                VariavelResultado = "P",
                UnidadeResultado = "W",
                Icone = "P"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Eletromagnetismo Avancado", lote);
    }

    private void AdicionarLoteCuradoPilotoBioquimicaEstrutural()
    {
        const string categoria = "Bioquímica Estrutural";
        const string subCategoria = "Curadoria Piloto - Estrutura e Dinâmica";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_bioq_001",
                Nome = "Eficiência de FRET",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E = 1/(1 + (r/R0)^6)",
                ExprTexto = "E = um dividido por um mais r sobre R zero elevado a 6",
                Criador = "Theodor Förster",
                AnoOrigin = "1948",
                Descricao = "Eficiência de transferência de energia por ressonância entre um doador e um aceptor separados por distância r.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Lakowicz, J. R. Principles of Fluorescence Spectroscopy, 3ª ed., Springer, 2006. Cap. 13.",
                FonteUrlOuDoi = "https://doi.org/10.1007/978-0-387-46312-4",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "r", Nome = "Distância doador-aceptor", Unidade = "nm", ValorPadrao = 5.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "R0", Nome = "Raio de Förster", Unidade = "nm", ValorPadrao = 5.4, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var r = Math.Max(1e-30, vars.GetValueOrDefault("r", 5.0));
                    var r0 = Math.Max(1e-30, vars.GetValueOrDefault("R0", 5.4));
                    return 1.0 / (1.0 + Math.Pow(r / r0, 6.0));
                },
                VariavelResultado = "E",
                UnidadeResultado = "adim",
                Icone = "FRET"
            },
            new Formula
            {
                Id = "cur_v12_bioq_002",
                Nome = "Raio de giração",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Rg = sqrt(Σm_i r_i²/Σm_i)",
                ExprTexto = "Rg = raiz da soma de m i r i ao quadrado pela soma das massas",
                Criador = "Mecânica molecular clássica",
                AnoOrigin = "Sec. XX",
                Descricao = "Medida da distribuição espacial de massa de uma macromolécula em torno do centro de massa.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Cantor, C. R.; Schimmel, P. R. Biophysical Chemistry Part II, W. H. Freeman, 1980. Cap. 14.",
                FonteUrlOuDoi = "https://archive.org/details/biophysicalchemi02cant",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "sumMr2", Nome = "Soma de m_i r_i²", Unidade = "u·nm²", ValorPadrao = 1e6, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "sumM", Nome = "Soma das massas", Unidade = "u", ValorPadrao = 1e4, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars => Math.Sqrt(Math.Max(0, vars.GetValueOrDefault("sumMr2", 1e6)) / Math.Max(1e-30, vars.GetValueOrDefault("sumM", 1e4))),
                VariavelResultado = "Rg",
                UnidadeResultado = "nm",
                Icone = "Rg"
            },
            new Formula
            {
                Id = "cur_v12_bioq_003",
                Nome = "Deslocamento quadrático médio (RMSD)",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "RMSD = sqrt((1/N)Σ|r_i − r_i^ref|²)",
                ExprTexto = "RMSD = raiz da média dos desvios quadráticos em relação à referência",
                Criador = "Análise estrutural computacional",
                AnoOrigin = "Sec. XX",
                Descricao = "Mede a divergência média entre uma estrutura e uma referência após alinhamento.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Leach, A. R. Molecular Modelling: Principles and Applications, 2ª ed., Pearson, 2001. Cap. 11.",
                FonteUrlOuDoi = "https://www.pearson.com/en-gb/subject-catalog/p/molecular-modelling-principles-and-applications/P200000004368",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "sumSq", Nome = "Soma dos desvios quadráticos", Unidade = "nm²", ValorPadrao = 2.5, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "N", Nome = "Número de átomos", Unidade = "adim", ValorPadrao = 100.0, ValorMin = 1, ValorMax = 1e30 }
                },
                Calcular = vars => Math.Sqrt(Math.Max(0, vars.GetValueOrDefault("sumSq", 2.5)) / Math.Max(1, vars.GetValueOrDefault("N", 100.0))),
                VariavelResultado = "RMSD",
                UnidadeResultado = "nm",
                Icone = "RMSD"
            },
            new Formula
            {
                Id = "cur_v12_bioq_004",
                Nome = "Relação B-factor e deslocamento médio",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "<u²> = B/(8π²)",
                ExprTexto = "u ao quadrado médio = B dividido por 8 pi ao quadrado",
                Criador = "Cristalografia macromolecular",
                AnoOrigin = "Sec. XX",
                Descricao = "Relaciona o fator B isotrópico ao deslocamento quadrático médio atômico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Drenth, J. Principles of Protein X-Ray Crystallography, 3ª ed., Springer, 2007. Cap. 9.",
                FonteUrlOuDoi = "https://doi.org/10.1007/978-0-387-33334-2",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "B", Nome = "Fator B isotrópico", Unidade = "Å²", ValorPadrao = 20.0, ValorMin = 0, ValorMax = 1e30 } },
                Calcular = vars => Math.Max(0, vars.GetValueOrDefault("B", 20.0)) / (8.0 * Math.PI * Math.PI),
                VariavelResultado = "<u²>",
                UnidadeResultado = "Å²",
                Icone = "B"
            },
            new Formula
            {
                Id = "cur_v12_bioq_005",
                Nome = "Equação de Guinier",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "I(q) = I0·exp(−q²Rg²/3)",
                ExprTexto = "I de q = I zero vezes exponencial de menos q ao quadrado Rg ao quadrado sobre 3",
                Criador = "André Guinier",
                AnoOrigin = "1939",
                Descricao = "Aproximação de pequeno ângulo para espalhamento, usada para extrair o raio de giração de biomacromoléculas em solução.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Putnam, C. D. et al. X-ray solution scattering (SAXS) combined with crystallography and computation. Q. Rev. Biophys. 40(3), 191-285, 2007.",
                FonteUrlOuDoi = "https://doi.org/10.1017/S0033583507004635",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "I0", Nome = "Intensidade em q=0", Unidade = "adim", ValorPadrao = 1000.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "q", Nome = "Vetor de espalhamento", Unidade = "1/nm", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Rg", Nome = "Raio de giração", Unidade = "nm", ValorPadrao = 2.5, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var I0 = Math.Max(0, vars.GetValueOrDefault("I0", 1000.0));
                    var q = Math.Max(0, vars.GetValueOrDefault("q", 0.2));
                    var rg = Math.Max(0, vars.GetValueOrDefault("Rg", 2.5));
                    return I0 * Math.Exp(-(q * q * rg * rg) / 3.0);
                },
                VariavelResultado = "I(q)",
                UnidadeResultado = "adim",
                Icone = "I"
            },
            new Formula
            {
                Id = "cur_v12_bioq_006",
                Nome = "Stokes-Einstein para raio hidrodinâmico",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "D = kT/(6πηRh)",
                ExprTexto = "D = k T dividido por 6 pi eta Rh",
                Criador = "Einstein / Stokes",
                AnoOrigin = "1905",
                Descricao = "Relaciona o coeficiente de difusão translacional ao raio hidrodinâmico de uma partícula aproximadamente esférica.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Cantor, C. R.; Schimmel, P. R. Biophysical Chemistry Part II, W. H. Freeman, 1980. Cap. 14.",
                FonteUrlOuDoi = "https://archive.org/details/biophysicalchemi02cant",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "eta", Nome = "Viscosidade", Unidade = "Pa·s", ValorPadrao = 1e-3, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Rh", Nome = "Raio hidrodinâmico", Unidade = "m", ValorPadrao = 3e-9, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 298.15));
                    var eta = Math.Max(1e-30, vars.GetValueOrDefault("eta", 1e-3));
                    var rh = Math.Max(1e-30, vars.GetValueOrDefault("Rh", 3e-9));
                    return kB * T / (6.0 * Math.PI * eta * rh);
                },
                VariavelResultado = "D",
                UnidadeResultado = "m²/s",
                Icone = "D"
            },
            new Formula
            {
                Id = "cur_v12_bioq_007",
                Nome = "Fraçao dobrada de proteína em dois estados",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "f_N = 1/(1 + exp(ΔG/(RT)))",
                ExprTexto = "fração nativa = um dividido por um mais exponencial de Delta G sobre R T",
                Criador = "Modelo de duas populações",
                AnoOrigin = "Sec. XX",
                Descricao = "Fração de proteína no estado nativo em um modelo simplificado de equilíbrio de dois estados.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Creighton, T. E. Proteins: Structures and Molecular Properties, 2ª ed., W. H. Freeman, 1993. Cap. 9.",
                FonteUrlOuDoi = "https://archive.org/details/proteinsstructur0000crei",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dG", Nome = "Energia livre de desnaturação", Unidade = "J/mol", ValorPadrao = 20000.0, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 298.15, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double R = 8.314462618;
                    var dG = vars.GetValueOrDefault("dG", 20000.0);
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 298.15));
                    return 1.0 / (1.0 + Math.Exp(dG / (R * T)));
                },
                VariavelResultado = "f_N",
                UnidadeResultado = "adim",
                Icone = "fN"
            },
            new Formula
            {
                Id = "cur_v12_bioq_008",
                Nome = "População de protonação de grupo ionizável",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "α_prot = 1/(1 + 10^(pH − pKa))",
                ExprTexto = "alfa protonada = um dividido por um mais dez elevado a pH menos pKa",
                Criador = "Equilíbrio ácido-base aplicado a biomoléculas",
                AnoOrigin = "Sec. XX",
                Descricao = "Fração protonada de um grupo ionizável em proteínas e ácidos nucleicos.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Nelson, D. L.; Cox, M. M. Lehninger Principles of Biochemistry, 8ª ed., W. H. Freeman, 2021. Cap. 2.",
                FonteUrlOuDoi = "https://store.macmillanlearning.com/us/product/Lehninger-Principles-of-Biochemistry/p/1319228003",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "pH", Nome = "pH do meio", Unidade = "adim", ValorPadrao = 7.0, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "pKa", Nome = "pKa do grupo", Unidade = "adim", ValorPadrao = 6.0, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var pH = vars.GetValueOrDefault("pH", 7.0);
                    var pKa = vars.GetValueOrDefault("pKa", 6.0);
                    return 1.0 / (1.0 + Math.Pow(10.0, pH - pKa));
                },
                VariavelResultado = "α_prot",
                UnidadeResultado = "adim",
                Icone = "α"
            },
            new Formula
            {
                Id = "cur_v12_bioq_009",
                Nome = "Coeficiente de sedimentação",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "s = M(1 − v̄ρ)/(N_A f)",
                ExprTexto = "s = M vezes um menos v barra rho dividido por N A f",
                Criador = "Ultracentrifugação analítica",
                AnoOrigin = "Sec. XX",
                Descricao = "Relaciona massa molar, volume específico parcial, densidade do solvente e coeficiente friccional.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "van Holde, K. E.; Johnson, W. C.; Ho, P. S. Principles of Physical Biochemistry, 2ª ed., Pearson, 2006. Cap. 4.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/principles-of-physical-biochemistry/P200000006052",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "M", Nome = "Massa molar", Unidade = "kg/mol", ValorPadrao = 5e4 / 1000.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "vbar", Nome = "Volume específico parcial", Unidade = "m³/kg", ValorPadrao = 7.3e-4, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "rho", Nome = "Densidade do solvente", Unidade = "kg/m³", ValorPadrao = 1000.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "f", Nome = "Coeficiente friccional", Unidade = "kg/s", ValorPadrao = 1e-11, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double NA = 6.02214076e23;
                    var M = Math.Max(1e-30, vars.GetValueOrDefault("M", 50.0));
                    var vbar = Math.Max(0, vars.GetValueOrDefault("vbar", 7.3e-4));
                    var rho = Math.Max(0, vars.GetValueOrDefault("rho", 1000.0));
                    var f = Math.Max(1e-30, vars.GetValueOrDefault("f", 1e-11));
                    return M * (1.0 - vbar * rho) / (NA * f);
                },
                VariavelResultado = "s",
                UnidadeResultado = "s",
                Icone = "s"
            },
            new Formula
            {
                Id = "cur_v12_bioq_010",
                Nome = "Equação de Hill",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "θ = [L]^n/(K_d^n + [L]^n)",
                ExprTexto = "theta = ligante elevado a n dividido por Kd elevado a n mais ligante elevado a n",
                Criador = "Archibald Hill",
                AnoOrigin = "1910",
                Descricao = "Modelo empírico de ocupação cooperativa usado em bioquímica estrutural e ligação proteína-ligante.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Cantor, C. R.; Schimmel, P. R. Biophysical Chemistry Part III, W. H. Freeman, 1980. Cap. 17.",
                FonteUrlOuDoi = "https://archive.org/details/biophysicalchemi03cant",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "L", Nome = "Concentração de ligante", Unidade = "mol/L", ValorPadrao = 1e-6, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Kd", Nome = "Constante de dissociação", Unidade = "mol/L", ValorPadrao = 1e-6, ValorMin = 1e-300, ValorMax = 1e30 },
                    new Variavel { Simbolo = "n", Nome = "Coeficiente de Hill", Unidade = "adim", ValorPadrao = 2.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var ligand = Math.Max(0, vars.GetValueOrDefault("L", 1e-6));
                    var kd = Math.Max(1e-300, vars.GetValueOrDefault("Kd", 1e-6));
                    var n = Math.Max(1e-30, vars.GetValueOrDefault("n", 2.0));
                    var ln = Math.Pow(ligand, n);
                    var kdn = Math.Pow(kd, n);
                    return ln / (kdn + ln);
                },
                VariavelResultado = "θ",
                UnidadeResultado = "adim",
                Icone = "θ"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Bioquimica Estrutural", lote);
    }

    private void AdicionarLoteCuradoPilotoMecanicaEstatistica()
    {
        const string categoria = "Mecânica Estatística";
        const string subCategoria = "Curadoria Piloto - Ensembles e Distribuições";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_sm_001",
                Nome = "Probabilidade de Boltzmann",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "p_i = exp(−E_i/(kT))/Z",
                ExprTexto = "p i = exponencial de menos E i sobre k T dividido por Z",
                Criador = "Ludwig Boltzmann",
                AnoOrigin = "Sec. XIX",
                Descricao = "Probabilidade canônica de ocupação de um microestado de energia E_i à temperatura T.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Pathria, R. K.; Beale, P. D. Statistical Mechanics, 3ª ed., Elsevier, 2011. Cap. 3.",
                FonteUrlOuDoi = "https://www.sciencedirect.com/book/9780123821881/statistical-mechanics",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ei", Nome = "Energia do estado", Unidade = "J", ValorPadrao = 1e-21, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Z", Nome = "Função de partição", Unidade = "adim", ValorPadrao = 10.0, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var Ei = vars.GetValueOrDefault("Ei", 1e-21);
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0));
                    var Z = Math.Max(1e-300, vars.GetValueOrDefault("Z", 10.0));
                    return Math.Exp(-Ei / (kB * T)) / Z;
                },
                VariavelResultado = "p_i",
                UnidadeResultado = "adim",
                Icone = "p"
            },
            new Formula
            {
                Id = "cur_v12_sm_002",
                Nome = "Função de partição de dois níveis",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Z = g0 + g1·exp(−ΔE/(kT))",
                ExprTexto = "Z = g zero mais g um vezes exponencial de menos Delta E sobre k T",
                Criador = "Modelo de dois níveis",
                AnoOrigin = "Sec. XX",
                Descricao = "Função de partição canônica de um sistema com dois níveis de energia separados por ΔE.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Schroeder, D. V. An Introduction to Thermal Physics, Addison-Wesley, 2000. Cap. 6.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/an-introduction-to-thermal-physics/P200000003136",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "g0", Nome = "Degenerescência do nível fundamental", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "g1", Nome = "Degenerescência do nível excitado", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "dE", Nome = "Separação energética", Unidade = "J", ValorPadrao = 1e-21, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var g0 = Math.Max(0, vars.GetValueOrDefault("g0", 1.0));
                    var g1 = Math.Max(0, vars.GetValueOrDefault("g1", 1.0));
                    var dE = Math.Max(0, vars.GetValueOrDefault("dE", 1e-21));
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0));
                    return g0 + g1 * Math.Exp(-dE / (kB * T));
                },
                VariavelResultado = "Z",
                UnidadeResultado = "adim",
                Icone = "Z"
            },
            new Formula
            {
                Id = "cur_v12_sm_003",
                Nome = "Energia livre de Helmholtz",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "F = −kT·ln Z",
                ExprTexto = "F = menos k T vezes logaritmo natural de Z",
                Criador = "Hermann von Helmholtz",
                AnoOrigin = "Sec. XIX",
                Descricao = "Energia livre associada a um ensemble canônico em função da função de partição.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Pathria, R. K.; Beale, P. D. Statistical Mechanics, 3ª ed., Elsevier, 2011. Cap. 3.",
                FonteUrlOuDoi = "https://www.sciencedirect.com/book/9780123821881/statistical-mechanics",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Z", Nome = "Função de partição", Unidade = "adim", ValorPadrao = 10.0, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0));
                    var Z = Math.Max(1e-300, vars.GetValueOrDefault("Z", 10.0));
                    return -kB * T * Math.Log(Z);
                },
                VariavelResultado = "F",
                UnidadeResultado = "J",
                Icone = "F"
            },
            new Formula
            {
                Id = "cur_v12_sm_004",
                Nome = "Energia interna de sistema de dois níveis",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "U = ΔE·g1·exp(−ΔE/(kT))/Z",
                ExprTexto = "U = Delta E vezes g um vezes exponencial de menos Delta E sobre k T dividido por Z",
                Criador = "Modelo de dois níveis",
                AnoOrigin = "Sec. XX",
                Descricao = "Energia média de um sistema com estado fundamental nulo e um estado excitado de energia ΔE.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Schroeder, D. V. An Introduction to Thermal Physics, Addison-Wesley, 2000. Cap. 6.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/an-introduction-to-thermal-physics/P200000003136",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "g1", Nome = "Degenerescência excitada", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "dE", Nome = "Separação energética", Unidade = "J", ValorPadrao = 1e-21, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "Z", Nome = "Função de partição", Unidade = "adim", ValorPadrao = 2.0, ValorMin = 1e-300, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var g1 = Math.Max(0, vars.GetValueOrDefault("g1", 1.0));
                    var dE = Math.Max(0, vars.GetValueOrDefault("dE", 1e-21));
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0));
                    var Z = Math.Max(1e-300, vars.GetValueOrDefault("Z", 2.0));
                    return dE * g1 * Math.Exp(-dE / (kB * T)) / Z;
                },
                VariavelResultado = "U",
                UnidadeResultado = "J",
                Icone = "U"
            },
            new Formula
            {
                Id = "cur_v12_sm_005",
                Nome = "Entropia de Boltzmann",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "S = k·ln Ω",
                ExprTexto = "S = k vezes logaritmo natural de Omega",
                Criador = "Ludwig Boltzmann",
                AnoOrigin = "1877",
                Descricao = "Entropia associada a um número Ω de microestados equiprováveis.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Reif, F. Fundamentals of Statistical and Thermal Physics, McGraw-Hill, 1965. Cap. 2.",
                FonteUrlOuDoi = "https://archive.org/details/fundamentalsofst00reif",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "Omega", Nome = "Número de microestados", Unidade = "adim", ValorPadrao = 1e6, ValorMin = 1, ValorMax = 1e30 } },
                Calcular = vars => 1.380649e-23 * Math.Log(Math.Max(1, vars.GetValueOrDefault("Omega", 1e6))),
                VariavelResultado = "S",
                UnidadeResultado = "J/K",
                Icone = "S"
            },
            new Formula
            {
                Id = "cur_v12_sm_006",
                Nome = "Velocidade mais provável de Maxwell-Boltzmann",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "v_mp = sqrt(2kT/m)",
                ExprTexto = "v mais provável = raiz de 2 k T sobre m",
                Criador = "James Clerk Maxwell / Ludwig Boltzmann",
                AnoOrigin = "Sec. XIX",
                Descricao = "Velocidade correspondente ao pico da distribuição de Maxwell-Boltzmann.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Schroeder, D. V. An Introduction to Thermal Physics, Addison-Wesley, 2000. Cap. 6.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/an-introduction-to-thermal-physics/P200000003136",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "m", Nome = "Massa da partícula", Unidade = "kg", ValorPadrao = 4.65e-26, ValorMin = 1e-40, ValorMax = 1e30 }
                },
                Calcular = vars => Math.Sqrt(2.0 * 1.380649e-23 * Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0)) / Math.Max(1e-40, vars.GetValueOrDefault("m", 4.65e-26))),
                VariavelResultado = "v_mp",
                UnidadeResultado = "m/s",
                Icone = "v"
            },
            new Formula
            {
                Id = "cur_v12_sm_007",
                Nome = "Velocidade média de Maxwell-Boltzmann",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "<v> = sqrt(8kT/(πm))",
                ExprTexto = "velocidade média = raiz de 8 k T sobre pi m",
                Criador = "James Clerk Maxwell / Ludwig Boltzmann",
                AnoOrigin = "Sec. XIX",
                Descricao = "Valor médio da velocidade na distribuição de Maxwell-Boltzmann.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Schroeder, D. V. An Introduction to Thermal Physics, Addison-Wesley, 2000. Cap. 6.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/an-introduction-to-thermal-physics/P200000003136",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "m", Nome = "Massa da partícula", Unidade = "kg", ValorPadrao = 4.65e-26, ValorMin = 1e-40, ValorMax = 1e30 }
                },
                Calcular = vars => Math.Sqrt(8.0 * 1.380649e-23 * Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0)) / (Math.PI * Math.Max(1e-40, vars.GetValueOrDefault("m", 4.65e-26)))),
                VariavelResultado = "<v>",
                UnidadeResultado = "m/s",
                Icone = "v"
            },
            new Formula
            {
                Id = "cur_v12_sm_008",
                Nome = "Velocidade quadrática média",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "v_rms = sqrt(3kT/m)",
                ExprTexto = "v rms = raiz de 3 k T sobre m",
                Criador = "James Clerk Maxwell / Ludwig Boltzmann",
                AnoOrigin = "Sec. XIX",
                Descricao = "Raiz da velocidade média quadrática na distribuição de Maxwell-Boltzmann.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Schroeder, D. V. An Introduction to Thermal Physics, Addison-Wesley, 2000. Cap. 6.",
                FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/an-introduction-to-thermal-physics/P200000003136",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "m", Nome = "Massa da partícula", Unidade = "kg", ValorPadrao = 4.65e-26, ValorMin = 1e-40, ValorMax = 1e30 }
                },
                Calcular = vars => Math.Sqrt(3.0 * 1.380649e-23 * Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0)) / Math.Max(1e-40, vars.GetValueOrDefault("m", 4.65e-26))),
                VariavelResultado = "v_rms",
                UnidadeResultado = "m/s",
                Icone = "v"
            },
            new Formula
            {
                Id = "cur_v12_sm_009",
                Nome = "Ocupação de Fermi-Dirac",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "f = 1/(exp((E−μ)/(kT)) + 1)",
                ExprTexto = "f = um dividido por exponencial de E menos mu sobre k T mais 1",
                Criador = "Enrico Fermi / Paul Dirac",
                AnoOrigin = "1926",
                Descricao = "Ocupação média de um estado fermiónico de energia E em equilíbrio térmico e químico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Pathria, R. K.; Beale, P. D. Statistical Mechanics, 3ª ed., Elsevier, 2011. Cap. 7.",
                FonteUrlOuDoi = "https://www.sciencedirect.com/book/9780123821881/statistical-mechanics",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "E", Nome = "Energia do estado", Unidade = "J", ValorPadrao = 1e-20, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "mu", Nome = "Potencial químico", Unidade = "J", ValorPadrao = 9e-21, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var E = vars.GetValueOrDefault("E", 1e-20);
                    var mu = vars.GetValueOrDefault("mu", 9e-21);
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0));
                    return 1.0 / (Math.Exp((E - mu) / (kB * T)) + 1.0);
                },
                VariavelResultado = "f",
                UnidadeResultado = "adim",
                Icone = "f"
            },
            new Formula
            {
                Id = "cur_v12_sm_010",
                Nome = "Ocupação de Bose-Einstein",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "n̄ = 1/(exp((E−μ)/(kT)) − 1)",
                ExprTexto = "n médio = um dividido por exponencial de E menos mu sobre k T menos 1",
                Criador = "Satyendra Bose / Albert Einstein",
                AnoOrigin = "1924",
                Descricao = "Ocupação média de um estado bosônico em equilíbrio térmico e químico.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Pathria, R. K.; Beale, P. D. Statistical Mechanics, 3ª ed., Elsevier, 2011. Cap. 7.",
                FonteUrlOuDoi = "https://www.sciencedirect.com/book/9780123821881/statistical-mechanics",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "E", Nome = "Energia do estado", Unidade = "J", ValorPadrao = 1e-20, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "mu", Nome = "Potencial químico", Unidade = "J", ValorPadrao = 5e-21, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double kB = 1.380649e-23;
                    var E = vars.GetValueOrDefault("E", 1e-20);
                    var mu = vars.GetValueOrDefault("mu", 5e-21);
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0));
                    var x = Math.Exp((E - mu) / (kB * T)) - 1.0;
                    return 1.0 / Math.Max(1e-300, x);
                },
                VariavelResultado = "n̄",
                UnidadeResultado = "adim",
                Icone = "n"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Mecanica Estatistica", lote);
    }

    private void AdicionarLoteCuradoPilotoOpticaQuantica()
    {
        const string categoria = "Óptica Quântica";
        const string subCategoria = "Curadoria Piloto - Fótons e Cavidades";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_oq_001",
                Nome = "Energia de fóton",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E = hν",
                ExprTexto = "E = h vezes nu",
                Criador = "Max Planck",
                AnoOrigin = "1900",
                Descricao = "Energia associada a um fóton de frequência ν.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Loudon, R. The Quantum Theory of Light, 3ª ed., Oxford University Press, 2000. Cap. 1.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/the-quantum-theory-of-light-9780198501763",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "nu", Nome = "Frequência", Unidade = "Hz", ValorPadrao = 5e14, ValorMin = 0, ValorMax = 1e30 } },
                Calcular = vars => 6.62607015e-34 * Math.Max(0, vars.GetValueOrDefault("nu", 5e14)),
                VariavelResultado = "E",
                UnidadeResultado = "J",
                Icone = "hν"
            },
            new Formula
            {
                Id = "cur_v12_oq_002",
                Nome = "Momento de fóton",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "p = h/λ",
                ExprTexto = "p = h dividido por lambda",
                Criador = "Relação fóton-onda",
                AnoOrigin = "Sec. XX",
                Descricao = "Momento linear de um fóton em função do comprimento de onda.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Fox, M. Quantum Optics: An Introduction, Oxford University Press, 2006. Cap. 1.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/quantum-optics-an-introduction-9780198566731",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "lambda", Nome = "Comprimento de onda", Unidade = "m", ValorPadrao = 632.8e-9, ValorMin = 1e-30, ValorMax = 1e30 } },
                Calcular = vars => 6.62607015e-34 / Math.Max(1e-30, vars.GetValueOrDefault("lambda", 632.8e-9)),
                VariavelResultado = "p",
                UnidadeResultado = "kg·m/s",
                Icone = "p"
            },
            new Formula
            {
                Id = "cur_v12_oq_003",
                Nome = "Separação modal de cavidade Fabry-Pérot",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Δν = c/(2L)",
                ExprTexto = "delta nu = c dividido por 2 L",
                Criador = "Óptica de cavidades",
                AnoOrigin = "Sec. XX",
                Descricao = "Espaçamento em frequência entre modos longitudinais adjacentes de uma cavidade linear ideal.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Scully, M. O.; Zubairy, M. S. Quantum Optics, Cambridge University Press, 1997. Cap. 6.",
                FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511813993",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "L", Nome = "Comprimento da cavidade", Unidade = "m", ValorPadrao = 0.10, ValorMin = 1e-30, ValorMax = 1e30 } },
                Calcular = vars => 299792458.0 / (2.0 * Math.Max(1e-30, vars.GetValueOrDefault("L", 0.10))),
                VariavelResultado = "Δν",
                UnidadeResultado = "Hz",
                Icone = "Δν"
            },
            new Formula
            {
                Id = "cur_v12_oq_004",
                Nome = "Número médio de fótons térmicos",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "n̄ = 1/(exp(hν/(kT)) − 1)",
                ExprTexto = "n médio = um dividido por exponencial de h nu sobre k T menos 1",
                Criador = "Distribuição de Bose para campo térmico",
                AnoOrigin = "Sec. XX",
                Descricao = "Número médio de fótons térmicos em um modo de frequência ν em equilíbrio à temperatura T.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Loudon, R. The Quantum Theory of Light, 3ª ed., Oxford University Press, 2000. Cap. 5.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/the-quantum-theory-of-light-9780198501763",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "nu", Nome = "Frequência", Unidade = "Hz", ValorPadrao = 1e12, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300.0, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double h = 6.62607015e-34;
                    const double kB = 1.380649e-23;
                    var nu = Math.Max(0, vars.GetValueOrDefault("nu", 1e12));
                    var T = Math.Max(1e-30, vars.GetValueOrDefault("T", 300.0));
                    return 1.0 / Math.Max(1e-300, Math.Exp(h * nu / (kB * T)) - 1.0);
                },
                VariavelResultado = "n̄",
                UnidadeResultado = "adim",
                Icone = "n"
            },
            new Formula
            {
                Id = "cur_v12_oq_005",
                Nome = "Variância de fótons em estado coerente",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Var(n) = n̄",
                ExprTexto = "variancia do número de fótons = n médio",
                Criador = "Roy Glauber",
                AnoOrigin = "Sec. XX",
                Descricao = "Em estados coerentes, a estatística de fótons é Poissoniana e a variância iguala a média.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Gerry, C.; Knight, P. Introductory Quantum Optics, Cambridge University Press, 2005. Cap. 3.",
                FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511791239",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "nbar", Nome = "Número médio de fótons", Unidade = "adim", ValorPadrao = 10.0, ValorMin = 0, ValorMax = 1e30 } },
                Calcular = vars => Math.Max(0, vars.GetValueOrDefault("nbar", 10.0)),
                VariavelResultado = "Var(n)",
                UnidadeResultado = "adim",
                Icone = "Var"
            },
            new Formula
            {
                Id = "cur_v12_oq_006",
                Nome = "Ruído de disparo",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "σ_N = sqrt(N)",
                ExprTexto = "sigma N = raiz de N",
                Criador = "Estatística quântica da fotodetecção",
                AnoOrigin = "Sec. XX",
                Descricao = "Flutuação padrão de contagem para um processo Poissoniano de detecção de fótons.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Fox, M. Quantum Optics: An Introduction, Oxford University Press, 2006. Cap. 5.",
                FonteUrlOuDoi = "https://global.oup.com/academic/product/quantum-optics-an-introduction-9780198566731",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "N", Nome = "Número médio de contagens", Unidade = "adim", ValorPadrao = 1e6, ValorMin = 0, ValorMax = 1e30 } },
                Calcular = vars => Math.Sqrt(Math.Max(0, vars.GetValueOrDefault("N", 1e6))),
                VariavelResultado = "σ_N",
                UnidadeResultado = "adim",
                Icone = "σ"
            },
            new Formula
            {
                Id = "cur_v12_oq_007",
                Nome = "Tempo de vida radiativo",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "τ = 1/A21",
                ExprTexto = "tau = um dividido por A 21",
                Criador = "Coeficientes de Einstein",
                AnoOrigin = "1917",
                Descricao = "Tempo de vida médio de um estado excitado em função do coeficiente de emissão espontânea.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Scully, M. O.; Zubairy, M. S. Quantum Optics, Cambridge University Press, 1997. Cap. 7.",
                FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511813993",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel> { new Variavel { Simbolo = "A21", Nome = "Coeficiente de emissão espontânea", Unidade = "s⁻¹", ValorPadrao = 1e8, ValorMin = 1e-300, ValorMax = 1e30 } },
                Calcular = vars => 1.0 / Math.Max(1e-300, vars.GetValueOrDefault("A21", 1e8)),
                VariavelResultado = "τ",
                UnidadeResultado = "s",
                Icone = "τ"
            },
            new Formula
            {
                Id = "cur_v12_oq_008",
                Nome = "Fator de Purcell",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Fp = (3/(4π²))(Q/V)(λ/n)³",
                ExprTexto = "Fp = 3 sobre 4 pi ao quadrado vezes Q sobre V vezes lambda sobre n ao cubo",
                Criador = "Edward Purcell",
                AnoOrigin = "1946",
                Descricao = "Amplificação da emissão espontânea devido a confinamento modal em cavidades ópticas ressonantes.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Vahala, K. Optical microcavities. Nature 424, 839-846, 2003.",
                FonteUrlOuDoi = "https://doi.org/10.1038/nature01939",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Q", Nome = "Fator de qualidade", Unidade = "adim", ValorPadrao = 1e5, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "V", Nome = "Volume modal normalizado", Unidade = "m³", ValorPadrao = 1e-18, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "lambda", Nome = "Comprimento de onda", Unidade = "m", ValorPadrao = 1.55e-6, ValorMin = 1e-30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "n", Nome = "Índice de refração", Unidade = "adim", ValorPadrao = 3.5, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var Q = Math.Max(1e-30, vars.GetValueOrDefault("Q", 1e5));
                    var V = Math.Max(1e-30, vars.GetValueOrDefault("V", 1e-18));
                    var lambda = Math.Max(1e-30, vars.GetValueOrDefault("lambda", 1.55e-6));
                    var n = Math.Max(1e-30, vars.GetValueOrDefault("n", 3.5));
                    return (3.0 / (4.0 * Math.PI * Math.PI)) * (Q / V) * Math.Pow(lambda / n, 3.0);
                },
                VariavelResultado = "Fp",
                UnidadeResultado = "adim",
                Icone = "Fp"
            },
            new Formula
            {
                Id = "cur_v12_oq_009",
                Nome = "Número de fótons em pulso óptico",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "N = Pτ/(hν)",
                ExprTexto = "N = P tau dividido por h nu",
                Criador = "Fotônica quântica aplicada",
                AnoOrigin = "Sec. XX",
                Descricao = "Número médio de fótons contidos em um pulso de potência P e duração τ.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Saleh, B. E. A.; Teich, M. C. Fundamentals of Photonics, 3ª ed., Wiley, 2019. Cap. 19.",
                FonteUrlOuDoi = "https://www.wiley.com/en-us/Fundamentals+of+Photonics%2C+3rd+Edition-p-9781119506874",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "P", Nome = "Potência do pulso", Unidade = "W", ValorPadrao = 1e-3, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "tau", Nome = "Duração do pulso", Unidade = "s", ValorPadrao = 1e-9, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "nu", Nome = "Frequência óptica", Unidade = "Hz", ValorPadrao = 2e14, ValorMin = 1e-30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var P = Math.Max(0, vars.GetValueOrDefault("P", 1e-3));
                    var tau = Math.Max(0, vars.GetValueOrDefault("tau", 1e-9));
                    var nu = Math.Max(1e-30, vars.GetValueOrDefault("nu", 2e14));
                    return P * tau / (6.62607015e-34 * nu);
                },
                VariavelResultado = "N",
                UnidadeResultado = "adim",
                Icone = "N"
            },
            new Formula
            {
                Id = "cur_v12_oq_010",
                Nome = "Frequência de Rabi ótica",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Ω = dE0/ħ",
                ExprTexto = "Omega = d E zero dividido por h cortado",
                Criador = "Interação dipolo-radiação",
                AnoOrigin = "Sec. XX",
                Descricao = "Frequência de oscilação coerente de um sistema de dois níveis acoplado a um campo elétrico clássico quase ressonante.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Cohen-Tannoudji, C.; Dupont-Roc, J.; Grynberg, G. Atom-Photon Interactions, Wiley, 1992. Cap. 1.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/9783527618422",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "d", Nome = "Momento de dipolo de transição", Unidade = "C·m", ValorPadrao = 3e-29, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "E0", Nome = "Amplitude do campo elétrico", Unidade = "V/m", ValorPadrao = 1e3, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars => Math.Max(0, vars.GetValueOrDefault("d", 3e-29)) * Math.Max(0, vars.GetValueOrDefault("E0", 1e3)) / 1.054571817e-34,
                VariavelResultado = "Ω",
                UnidadeResultado = "rad/s",
                Icone = "Ω"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Optica Quantica", lote);
    }

    private void AdicionarLoteCuradoPilotoMecanicaQuanticaII()
    {
        const string categoria = "Mecânica Quântica II";
        const string subCategoria = "Curadoria Piloto - Perturbação e Spin";

        var lote = new List<Formula>
        {
            new Formula
            {
                Id = "cur_v12_qm2_001",
                Nome = "Correção de primeira ordem da energia",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E_n^(1) = <n0|H'|n0>",
                ExprTexto = "E n primeira ordem = valor esperado de H linha no estado nao perturbado n zero",
                Criador = "Teoria de perturbação independente do tempo",
                AnoOrigin = "Sec. XX",
                Descricao = "Primeira correção da energia em teoria de perturbação não degenerada, dada pelo valor esperado da perturbação no autoestado não perturbado.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Sakurai, J. J.; Napolitano, J. Modern Quantum Mechanics, 2ª ed., Cambridge University Press, 2017. Cap. 5.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108499996",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Hexp", Nome = "Valor esperado de H'", Unidade = "J", ValorPadrao = 1e-21, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars => vars.GetValueOrDefault("Hexp", 1e-21),
                VariavelResultado = "E_n^(1)",
                UnidadeResultado = "J",
                Icone = "E1"
            },
            new Formula
            {
                Id = "cur_v12_qm2_002",
                Nome = "Correção de segunda ordem da energia",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E_n^(2) = Σ |<m0|H'|n0>|²/(E_n0 − E_m0)",
                ExprTexto = "E n segunda ordem = soma do modulo ao quadrado do elemento de matriz dividido pela diferença de energias nao perturbadas",
                Criador = "Teoria de perturbação independente do tempo",
                AnoOrigin = "Sec. XX",
                Descricao = "Forma compacta da correção de segunda ordem em teoria de perturbação não degenerada. Aqui a soma é representada pelo valor agregado informado pelo usuário.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Griffiths, D. J.; Schroeter, D. F. Introduction to Quantum Mechanics, 3ª ed., Cambridge University Press, 2018. Cap. 6.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781316995433",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "sumTerm", Nome = "Soma agregada dos termos perturbativos", Unidade = "J", ValorPadrao = -5e-23, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars => vars.GetValueOrDefault("sumTerm", -5e-23),
                VariavelResultado = "E_n^(2)",
                UnidadeResultado = "J",
                Icone = "E2"
            },
            new Formula
            {
                Id = "cur_v12_qm2_003",
                Nome = "Probabilidade de transição dependente do tempo",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "P = |c_f(t)|²",
                ExprTexto = "P = modulo de c f de t ao quadrado",
                Criador = "Teoria de perturbação dependente do tempo",
                AnoOrigin = "Sec. XX",
                Descricao = "Probabilidade de transição para o estado final a partir da amplitude complexa de probabilidade fornecida em módulo.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Sakurai, J. J.; Napolitano, J. Modern Quantum Mechanics, 2ª ed., Cambridge University Press, 2017. Cap. 5.",
                FonteUrlOuDoi = "https://doi.org/10.1017/9781108499996",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "cf", Nome = "Módulo da amplitude c_f", Unidade = "adim", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1e15 }
                },
                Calcular = vars =>
                {
                    var cf = Math.Max(0, vars.GetValueOrDefault("cf", 0.1));
                    return cf * cf;
                },
                VariavelResultado = "P",
                UnidadeResultado = "adim",
                Icone = "P"
            },
            new Formula
            {
                Id = "cur_v12_qm2_004",
                Nome = "Regra de Ouro de Fermi",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "Γ = (2π/ħ)|M|²ρ(E_f)",
                ExprTexto = "Gamma = 2 pi sobre h cortado vezes modulo de M ao quadrado vezes densidade de estados final",
                Criador = "Enrico Fermi",
                AnoOrigin = "Sec. XX",
                Descricao = "Taxa de transição para um contínuo de estados finais a partir do elemento de matriz perturbativo e da densidade de estados.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Cohen-Tannoudji, C.; Diu, B.; Laloe, F. Quantum Mechanics, Wiley, 1977. Vol. 2, Cap. XIII.",
                FonteUrlOuDoi = "https://archive.org/details/quantummechanics02cohe",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "M", Nome = "Módulo do elemento de matriz", Unidade = "J", ValorPadrao = 1e-22, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "rho", Nome = "Densidade de estados finais", Unidade = "1/J", ValorPadrao = 1e20, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var M = Math.Max(0, vars.GetValueOrDefault("M", 1e-22));
                    var rho = Math.Max(0, vars.GetValueOrDefault("rho", 1e20));
                    return (2.0 * Math.PI / hbar) * M * M * rho;
                },
                VariavelResultado = "Γ",
                UnidadeResultado = "s⁻¹",
                Icone = "Γ"
            },
            new Formula
            {
                Id = "cur_v12_qm2_005",
                Nome = "Separação de níveis por efeito Zeeman",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔE = μ_B·g·m_j·B",
                ExprTexto = "Delta E = mu de Bohr vezes g vezes m j vezes B",
                Criador = "Pieter Zeeman",
                AnoOrigin = "1896",
                Descricao = "Deslocamento energético de um subnível magnético em campo magnético externo, no regime Zeeman linear.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Townsend, J. S. A Modern Approach to Quantum Mechanics, 2ª ed., University Science Books, 2012. Cap. 10.",
                FonteUrlOuDoi = "https://uscibooks.aip.org/books/a-modern-approach-to-quantum-mechanics/",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "g", Nome = "Fator de Landé", Unidade = "adim", ValorPadrao = 2.0, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "mj", Nome = "Número quântico magnético total", Unidade = "adim", ValorPadrao = 0.5, ValorMin = -1e6, ValorMax = 1e6 },
                    new Variavel { Simbolo = "B", Nome = "Campo magnético", Unidade = "T", ValorPadrao = 1.0, ValorMin = -1e30, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double muB = 9.2740100783e-24;
                    var g = vars.GetValueOrDefault("g", 2.0);
                    var mj = vars.GetValueOrDefault("mj", 0.5);
                    var B = vars.GetValueOrDefault("B", 1.0);
                    return muB * g * mj * B;
                },
                VariavelResultado = "ΔE",
                UnidadeResultado = "J",
                Icone = "ΔE"
            },
            new Formula
            {
                Id = "cur_v12_qm2_006",
                Nome = "Energia de acoplamento spin-órbita",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "ΔE = (A/2)[j(j+1) − l(l+1) − s(s+1)]",
                ExprTexto = "Delta E = A sobre 2 vezes j de j mais 1 menos l de l mais 1 menos s de s mais 1",
                Criador = "Acoplamento LS",
                AnoOrigin = "Sec. XX",
                Descricao = "Desdobramento energético associado ao acoplamento spin-órbita em aproximação de constante A conhecida.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Bransden, B. H.; Joachain, C. J. Physics of Atoms and Molecules, 2ª ed., Pearson, 2003. Cap. 7.",
                FonteUrlOuDoi = "https://www.pearson.com/en-gb/subject-catalog/p/physics-of-atoms-and-molecules/P200000006498",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Constante de acoplamento spin-órbita", Unidade = "J", ValorPadrao = 1e-23, ValorMin = -1e30, ValorMax = 1e30 },
                    new Variavel { Simbolo = "j", Nome = "Número quântico total", Unidade = "adim", ValorPadrao = 1.5, ValorMin = 0, ValorMax = 1e6 },
                    new Variavel { Simbolo = "l", Nome = "Número quântico orbital", Unidade = "adim", ValorPadrao = 1.0, ValorMin = 0, ValorMax = 1e6 },
                    new Variavel { Simbolo = "s", Nome = "Número quântico de spin", Unidade = "adim", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1e6 }
                },
                Calcular = vars =>
                {
                    var A = vars.GetValueOrDefault("A", 1e-23);
                    var j = Math.Max(0, vars.GetValueOrDefault("j", 1.5));
                    var l = Math.Max(0, vars.GetValueOrDefault("l", 1.0));
                    var s = Math.Max(0, vars.GetValueOrDefault("s", 0.5));
                    return 0.5 * A * (j * (j + 1.0) - l * (l + 1.0) - s * (s + 1.0));
                },
                VariavelResultado = "ΔE",
                UnidadeResultado = "J",
                Icone = "LS"
            },
            new Formula
            {
                Id = "cur_v12_qm2_007",
                Nome = "Energia de recuo do fóton",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "E_r = (ħk)²/(2m)",
                ExprTexto = "E recuo = h cortado k ao quadrado dividido por 2m",
                Criador = "Mecânica quântica atômica",
                AnoOrigin = "Sec. XX",
                Descricao = "Energia cinética adquirida por um átomo ou partícula após absorver ou emitir um fóton de número de onda k.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Metcalf, H.; van der Straten, P. Laser Cooling and Trapping, Springer, 1999. Cap. 1.",
                FonteUrlOuDoi = "https://doi.org/10.1007/978-1-4612-1470-0",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Número de onda", Unidade = "1/m", ValorPadrao = 8.06e6, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "m", Nome = "Massa da partícula", Unidade = "kg", ValorPadrao = 1.443e-25, ValorMin = 1e-40, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var k = Math.Max(0, vars.GetValueOrDefault("k", 8.06e6));
                    var m = Math.Max(1e-40, vars.GetValueOrDefault("m", 1.443e-25));
                    return (hbar * k) * (hbar * k) / (2.0 * m);
                },
                VariavelResultado = "E_r",
                UnidadeResultado = "J",
                Icone = "Er"
            },
            new Formula
            {
                Id = "cur_v12_qm2_008",
                Nome = "Frequência de Rabi ressonante",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "P_e(t) = sin²(Ωt/2)",
                ExprTexto = "P e de t = seno ao quadrado de Omega t sobre 2",
                Criador = "Isidor Rabi",
                AnoOrigin = "1937",
                Descricao = "Probabilidade de excitação de um sistema de dois níveis em ressonância exata, em termos da frequência de Rabi.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Cohen-Tannoudji, C.; Dupont-Roc, J.; Grynberg, G. Atom-Photon Interactions, Wiley, 1992. Cap. 1.",
                FonteUrlOuDoi = "https://onlinelibrary.wiley.com/doi/book/10.1002/9783527618422",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Omega", Nome = "Frequência de Rabi", Unidade = "rad/s", ValorPadrao = 1e6, ValorMin = 0, ValorMax = 1e30 },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Unidade = "s", ValorPadrao = 1e-6, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var omega = Math.Max(0, vars.GetValueOrDefault("Omega", 1e6));
                    var t = Math.Max(0, vars.GetValueOrDefault("t", 1e-6));
                    var arg = omega * t / 2.0;
                    return Math.Sin(arg) * Math.Sin(arg);
                },
                VariavelResultado = "P_e",
                UnidadeResultado = "adim",
                Icone = "Ω"
            },
            new Formula
            {
                Id = "cur_v12_qm2_009",
                Nome = "Pré-fator WKB de transmissão",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "S = ∫κ(x)dx, T ≈ exp(−2S)",
                ExprTexto = "T aproximadamente igual a exponencial de menos 2S",
                Criador = "Aproximação WKB",
                AnoOrigin = "1926",
                Descricao = "Forma compacta da transmissão semiclassica em função da ação euclidiana WKB agregada S.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Landau, L. D.; Lifshitz, E. M. Quantum Mechanics: Non-Relativistic Theory, 3ª ed., Butterworth-Heinemann, 1977. Sec. 50.",
                FonteUrlOuDoi = "https://archive.org/details/quantummechanics0003land",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "S", Nome = "Ação WKB agregada", Unidade = "adim", ValorPadrao = 3.0, ValorMin = 0, ValorMax = 1e30 }
                },
                Calcular = vars =>
                {
                    var S = Math.Max(0, vars.GetValueOrDefault("S", 3.0));
                    return Math.Exp(-2.0 * S);
                },
                VariavelResultado = "T",
                UnidadeResultado = "adim",
                Icone = "WKB"
            },
            new Formula
            {
                Id = "cur_v12_qm2_010",
                Nome = "Valor esperado do spin-z para spin 1/2",
                Categoria = categoria,
                SubCategoria = subCategoria,
                Expressao = "<S_z> = (ħ/2)(|α|² − |β|²)",
                ExprTexto = "valor esperado de Sz = h cortado sobre 2 vezes alfa ao quadrado menos beta ao quadrado",
                Criador = "Formalismo de spin 1/2",
                AnoOrigin = "Sec. XX",
                Descricao = "Valor esperado da componente z do spin para um espinor normalizado de dois componentes, usando os módulos quadrados de α e β.",
                Procedencia = "Literatura científica revisada por pares",
                ReferenciaBibliografica = "Townsend, J. S. A Modern Approach to Quantum Mechanics, 2ª ed., University Science Books, 2012. Cap. 3.",
                FonteUrlOuDoi = "https://uscibooks.aip.org/books/a-modern-approach-to-quantum-mechanics/",
                StatusCuradoria = "Curada - fonte primária verificada",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "alpha2", Nome = "Probabilidade |α|²", Unidade = "adim", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1 },
                    new Variavel { Simbolo = "beta2", Nome = "Probabilidade |β|²", Unidade = "adim", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1 }
                },
                Calcular = vars =>
                {
                    const double hbar = 1.054571817e-34;
                    var alpha2 = Math.Clamp(vars.GetValueOrDefault("alpha2", 0.8), 0, 1);
                    var beta2 = Math.Clamp(vars.GetValueOrDefault("beta2", 0.2), 0, 1);
                    return 0.5 * hbar * (alpha2 - beta2);
                },
                VariavelResultado = "<S_z>",
                UnidadeResultado = "J·s",
                Icone = "Sz"
            }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Mecanica Quantica II", lote);
    }

    private void AdicionarLoteCuradoPilotoEletromagnetismoAplicado()
    {
        const string categoria = "Eletromagnetismo Aplicado";
        const string subCategoria = "Curadoria Piloto - Máquinas e Linhas";

        var lote = new List<Formula>
        {
            new Formula { Id = "cur_v12_ema_001", Nome = "Reatância indutiva", Categoria = categoria, SubCategoria = subCategoria, Expressao = "X_L = ωL", ExprTexto = "XL = omega L", Criador = "Circuitos AC", AnoOrigin = "Sec. XX", Descricao = "Relação entre frequência angular e indutância.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Alexander, C.; Sadiku, M. Fundamentals of Electric Circuits, 6ª ed., McGraw-Hill, 2016. Cap. 9.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/fundamentals-electric-circuits-alexander-sadiku/M9781259251320.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "omega", Nome = "Frequência angular", Unidade = "rad/s", ValorPadrao = 377.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "L", Nome = "Indutância", Unidade = "H", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1e30 } }, Calcular = vars => Math.Max(0, vars.GetValueOrDefault("omega", 377.0)) * Math.Max(0, vars.GetValueOrDefault("L", 0.01)), VariavelResultado = "X_L", UnidadeResultado = "ohm", Icone = "XL" },
            new Formula { Id = "cur_v12_ema_002", Nome = "Reatância capacitiva", Categoria = categoria, SubCategoria = subCategoria, Expressao = "X_C = 1/(ωC)", ExprTexto = "XC = 1 sobre omega C", Criador = "Circuitos AC", AnoOrigin = "Sec. XX", Descricao = "Reatância de capacitor ideal.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Alexander, C.; Sadiku, M. Fundamentals of Electric Circuits, 6ª ed., McGraw-Hill, 2016. Cap. 9.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/fundamentals-electric-circuits-alexander-sadiku/M9781259251320.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "omega", Nome = "Frequência angular", Unidade = "rad/s", ValorPadrao = 377.0, ValorMin = 1e-30, ValorMax = 1e30 }, new Variavel { Simbolo = "C", Nome = "Capacitância", Unidade = "F", ValorPadrao = 100e-6, ValorMin = 1e-30, ValorMax = 1e30 } }, Calcular = vars => 1.0 / (Math.Max(1e-30, vars.GetValueOrDefault("omega", 377.0)) * Math.Max(1e-30, vars.GetValueOrDefault("C", 100e-6))), VariavelResultado = "X_C", UnidadeResultado = "ohm", Icone = "XC" },
            new Formula { Id = "cur_v12_ema_003", Nome = "Impedância série RL", Categoria = categoria, SubCategoria = subCategoria, Expressao = "|Z| = sqrt(R² + (ωL)²)", ExprTexto = "modulo Z = raiz de R ao quadrado mais omega L ao quadrado", Criador = "Circuitos AC", AnoOrigin = "Sec. XX", Descricao = "Módulo da impedância em série RL.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Alexander, C.; Sadiku, M. Fundamentals of Electric Circuits, 6ª ed., McGraw-Hill, 2016. Cap. 9.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/fundamentals-electric-circuits-alexander-sadiku/M9781259251320.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "R", Nome = "Resistência", Unidade = "ohm", ValorPadrao = 10.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "omega", Nome = "Frequência angular", Unidade = "rad/s", ValorPadrao = 377.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "L", Nome = "Indutância", Unidade = "H", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1e30 } }, Calcular = vars => { var r = Math.Max(0, vars.GetValueOrDefault("R", 10.0)); var x = Math.Max(0, vars.GetValueOrDefault("omega", 377.0)) * Math.Max(0, vars.GetValueOrDefault("L", 0.01)); return Math.Sqrt(r * r + x * x); }, VariavelResultado = "|Z|", UnidadeResultado = "ohm", Icone = "Z" },
            new Formula { Id = "cur_v12_ema_004", Nome = "Potência ativa trifásica", Categoria = categoria, SubCategoria = subCategoria, Expressao = "P = √3·V_L·I_L·cosφ", ExprTexto = "P = raiz de 3 vezes VL vezes IL vezes cos fi", Criador = "Sistemas trifásicos", AnoOrigin = "Sec. XX", Descricao = "Potência ativa em carga equilibrada trifásica.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Chapman, S. J. Electric Machinery Fundamentals, 5ª ed., McGraw-Hill, 2011. Cap. 2.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/electric-machinery-fundamentals-chapman/M9780073529547.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "VL", Nome = "Tensão de linha", Unidade = "V", ValorPadrao = 380.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "IL", Nome = "Corrente de linha", Unidade = "A", ValorPadrao = 20.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "cosphi", Nome = "Fator de potência", Unidade = "adim", ValorPadrao = 0.9, ValorMin = -1, ValorMax = 1 } }, Calcular = vars => Math.Sqrt(3.0) * Math.Max(0, vars.GetValueOrDefault("VL", 380.0)) * Math.Max(0, vars.GetValueOrDefault("IL", 20.0)) * Math.Clamp(vars.GetValueOrDefault("cosphi", 0.9), -1, 1), VariavelResultado = "P", UnidadeResultado = "W", Icone = "P" },
            new Formula { Id = "cur_v12_ema_005", Nome = "Perdas ôhmicas na linha", Categoria = categoria, SubCategoria = subCategoria, Expressao = "P_loss = I²R", ExprTexto = "Perda = I ao quadrado R", Criador = "Transmissão elétrica", AnoOrigin = "Sec. XIX", Descricao = "Perda Joule em condutor resistivo.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Stevenson, W. D. Elements of Power System Analysis, 4ª ed., McGraw-Hill, 1982. Cap. 2.", FonteUrlOuDoi = "https://archive.org/details/elementsofpowers0000stev", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "I", Nome = "Corrente", Unidade = "A", ValorPadrao = 100.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "R", Nome = "Resistência", Unidade = "ohm", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1e30 } }, Calcular = vars => { var i = Math.Max(0, vars.GetValueOrDefault("I", 100.0)); var r = Math.Max(0, vars.GetValueOrDefault("R", 0.2)); return i * i * r; }, VariavelResultado = "P_loss", UnidadeResultado = "W", Icone = "Pl" },
            new Formula { Id = "cur_v12_ema_006", Nome = "Escorregamento de motor de indução", Categoria = categoria, SubCategoria = subCategoria, Expressao = "s = (n_s − n_r)/n_s", ExprTexto = "s = ns menos nr sobre ns", Criador = "Máquinas elétricas", AnoOrigin = "Sec. XX", Descricao = "Escorregamento de rotor em relação ao campo girante.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Chapman, S. J. Electric Machinery Fundamentals, 5ª ed., McGraw-Hill, 2011. Cap. 7.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/electric-machinery-fundamentals-chapman/M9780073529547.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "ns", Nome = "Velocidade síncrona", Unidade = "rpm", ValorPadrao = 1800.0, ValorMin = 1e-30, ValorMax = 1e30 }, new Variavel { Simbolo = "nr", Nome = "Velocidade do rotor", Unidade = "rpm", ValorPadrao = 1740.0, ValorMin = 0, ValorMax = 1e30 } }, Calcular = vars => { var ns = Math.Max(1e-30, vars.GetValueOrDefault("ns", 1800.0)); var nr = Math.Max(0, vars.GetValueOrDefault("nr", 1740.0)); return (ns - nr) / ns; }, VariavelResultado = "s", UnidadeResultado = "adim", Icone = "s" },
            new Formula { Id = "cur_v12_ema_007", Nome = "Velocidade síncrona", Categoria = categoria, SubCategoria = subCategoria, Expressao = "n_s = 120f/P", ExprTexto = "ns = 120 f sobre P", Criador = "Máquinas elétricas", AnoOrigin = "Sec. XX", Descricao = "Velocidade do campo girante em máquina AC.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Fitzgerald, A. E.; Kingsley, C.; Umans, S. D. Electric Machinery, 6ª ed., McGraw-Hill, 2003. Cap. 4.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/electric-machinery-fitzgerald-kingsley/M9780071230100.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "f", Nome = "Frequência", Unidade = "Hz", ValorPadrao = 60.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "P", Nome = "Número de polos", Unidade = "adim", ValorPadrao = 4.0, ValorMin = 1, ValorMax = 1e30 } }, Calcular = vars => 120.0 * Math.Max(0, vars.GetValueOrDefault("f", 60.0)) / Math.Max(1, vars.GetValueOrDefault("P", 4.0)), VariavelResultado = "n_s", UnidadeResultado = "rpm", Icone = "ns" },
            new Formula { Id = "cur_v12_ema_008", Nome = "Força eletromotriz de transformador", Categoria = categoria, SubCategoria = subCategoria, Expressao = "E = 4.44fNΦ_max", ExprTexto = "E = 4,44 f N fi max", Criador = "Transformadores", AnoOrigin = "Sec. XX", Descricao = "FEM RMS por enrolamento em núcleo sinusoidal.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Chapman, S. J. Electric Machinery Fundamentals, 5ª ed., McGraw-Hill, 2011. Cap. 2.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/electric-machinery-fundamentals-chapman/M9780073529547.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "f", Nome = "Frequência", Unidade = "Hz", ValorPadrao = 60.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "N", Nome = "Número de espiras", Unidade = "adim", ValorPadrao = 500.0, ValorMin = 1, ValorMax = 1e30 }, new Variavel { Simbolo = "phimax", Nome = "Fluxo máximo", Unidade = "Wb", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1e30 } }, Calcular = vars => 4.44 * Math.Max(0, vars.GetValueOrDefault("f", 60.0)) * Math.Max(1, vars.GetValueOrDefault("N", 500.0)) * Math.Max(0, vars.GetValueOrDefault("phimax", 0.01)), VariavelResultado = "E", UnidadeResultado = "V", Icone = "E" },
            new Formula { Id = "cur_v12_ema_009", Nome = "Regulação de tensão aproximada", Categoria = categoria, SubCategoria = subCategoria, Expressao = "Reg% = 100(V_nl − V_fl)/V_fl", ExprTexto = "Reg percentual = 100 vezes V vazio menos V carga sobre V carga", Criador = "Transformadores", AnoOrigin = "Sec. XX", Descricao = "Variação percentual de tensão de vazio para carga nominal.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Fitzgerald, A. E.; Kingsley, C.; Umans, S. D. Electric Machinery, 6ª ed., McGraw-Hill, 2003. Cap. 2.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/electric-machinery-fitzgerald-kingsley/M9780071230100.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "Vnl", Nome = "Tensão em vazio", Unidade = "V", ValorPadrao = 230.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "Vfl", Nome = "Tensão em carga", Unidade = "V", ValorPadrao = 220.0, ValorMin = 1e-30, ValorMax = 1e30 } }, Calcular = vars => 100.0 * (Math.Max(0, vars.GetValueOrDefault("Vnl", 230.0)) - Math.Max(1e-30, vars.GetValueOrDefault("Vfl", 220.0))) / Math.Max(1e-30, vars.GetValueOrDefault("Vfl", 220.0)), VariavelResultado = "Reg%", UnidadeResultado = "%", Icone = "Reg" },
            new Formula { Id = "cur_v12_ema_010", Nome = "Eficiência elétrica", Categoria = categoria, SubCategoria = subCategoria, Expressao = "η = P_out/P_in", ExprTexto = "eta = P de saída sobre P de entrada", Criador = "Engenharia elétrica", AnoOrigin = "Sec. XIX", Descricao = "Rendimento de conversão de potência.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Chapman, S. J. Electric Machinery Fundamentals, 5ª ed., McGraw-Hill, 2011. Cap. 1.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/electric-machinery-fundamentals-chapman/M9780073529547.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel> { new Variavel { Simbolo = "Pout", Nome = "Potência de saída", Unidade = "W", ValorPadrao = 900.0, ValorMin = 0, ValorMax = 1e30 }, new Variavel { Simbolo = "Pin", Nome = "Potência de entrada", Unidade = "W", ValorPadrao = 1000.0, ValorMin = 1e-30, ValorMax = 1e30 } }, Calcular = vars => Math.Max(0, vars.GetValueOrDefault("Pout", 900.0)) / Math.Max(1e-30, vars.GetValueOrDefault("Pin", 1000.0)), VariavelResultado = "η", UnidadeResultado = "adim", Icone = "η" }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Eletromagnetismo Aplicado", lote);
    }

    private void AdicionarLoteCuradoPilotoInformacaoQuanticaAvancada()
    {
        const string categoria = "Informação Quântica Avançada";
        const string subCategoria = "Curadoria Piloto - Qubits e Canais";

        var lote = new List<Formula>
        {
            new Formula { Id = "cur_v12_qinfo_001", Nome = "Entropia binária de Shannon", Categoria = categoria, SubCategoria = subCategoria, Expressao = "H2(p) = −p log2 p − (1−p) log2(1−p)", ExprTexto = "H2 de p", Criador = "Claude Shannon", AnoOrigin = "1948", Descricao = "Entropia de uma variável binária.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Nielsen, M. A.; Chuang, I. L. Quantum Computation and Quantum Information, 10th Anniversary Ed., Cambridge University Press, 2010. Cap. 11.", FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511976667", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="p", Nome="Probabilidade", Unidade="adim", ValorPadrao=0.3, ValorMin=1e-12, ValorMax=1-1e-12}}, Calcular = vars => { var p=Math.Clamp(vars.GetValueOrDefault("p",0.3),1e-12,1-1e-12); return -p*Math.Log2(p)-(1-p)*Math.Log2(1-p); }, VariavelResultado="H2", UnidadeResultado="bits", Icone="H" },
            new Formula { Id = "cur_v12_qinfo_002", Nome = "Pureza de estado quântico", Categoria = categoria, SubCategoria = subCategoria, Expressao = "γ = Tr(ρ²)", ExprTexto = "gama = traço de rho ao quadrado", Criador = "Mecânica quântica de densidade", AnoOrigin = "Sec. XX", Descricao = "Pureza varia de 1/d até 1.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Nielsen, M. A.; Chuang, I. L. Quantum Computation and Quantum Information, 2010. Cap. 2.", FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511976667", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="trrho2", Nome="Traço de rho^2", Unidade="adim", ValorPadrao=0.8, ValorMin=0, ValorMax=1}}, Calcular = vars => Math.Clamp(vars.GetValueOrDefault("trrho2",0.8),0,1), VariavelResultado="γ", UnidadeResultado="adim", Icone="γ" },
            new Formula { Id = "cur_v12_qinfo_003", Nome = "Fidelidade de estados puros", Categoria = categoria, SubCategoria = subCategoria, Expressao = "F = |<ψ|φ>|²", ExprTexto = "F = modulo do overlap ao quadrado", Criador = "Teoria de informação quântica", AnoOrigin = "Sec. XX", Descricao = "Fidelidade entre dois estados puros.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Nielsen, M. A.; Chuang, I. L. Quantum Computation and Quantum Information, 2010. Cap. 9.", FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511976667", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="overlap", Nome="|<psi|phi>|", Unidade="adim", ValorPadrao=0.9, ValorMin=0, ValorMax=1}}, Calcular = vars => { var o=Math.Clamp(vars.GetValueOrDefault("overlap",0.9),0,1); return o*o; }, VariavelResultado="F", UnidadeResultado="adim", Icone="F" },
            new Formula { Id = "cur_v12_qinfo_004", Nome = "Concurrence para estado de Bell puro", Categoria = categoria, SubCategoria = subCategoria, Expressao = "C = 2|ad − bc|", ExprTexto = "C = 2 modulo de ad menos bc", Criador = "Wootters", AnoOrigin = "1998", Descricao = "Medida de emaranhamento para dois qubits puros.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Wootters, W. K. Entanglement of Formation of an Arbitrary State of Two Qubits. Phys. Rev. Lett. 80, 2245, 1998.", FonteUrlOuDoi = "https://doi.org/10.1103/PhysRevLett.80.2245", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="detterm", Nome="|ad-bc|", Unidade="adim", ValorPadrao=0.4, ValorMin=0, ValorMax=1}}, Calcular = vars => 2*Math.Clamp(vars.GetValueOrDefault("detterm",0.4),0,1), VariavelResultado="C", UnidadeResultado="adim", Icone="C" },
            new Formula { Id = "cur_v12_qinfo_005", Nome = "Taxa de erro quântico (QBER)", Categoria = categoria, SubCategoria = subCategoria, Expressao = "QBER = N_err/N_tot", ExprTexto = "QBER = erros sobre total", Criador = "QKD", AnoOrigin = "Sec. XX", Descricao = "Taxa de erro em protocolos de distribuição de chaves quânticas.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Scarani, V. et al. The security of practical quantum key distribution. Rev. Mod. Phys. 81, 1301 (2009).", FonteUrlOuDoi = "https://doi.org/10.1103/RevModPhys.81.1301", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="Nerr", Nome="Bits errados", Unidade="adim", ValorPadrao=50, ValorMin=0, ValorMax=1e30}, new Variavel{ Simbolo="Ntot", Nome="Bits totais", Unidade="adim", ValorPadrao=10000, ValorMin=1, ValorMax=1e30}}, Calcular = vars => Math.Max(0, vars.GetValueOrDefault("Nerr",50))/Math.Max(1, vars.GetValueOrDefault("Ntot",10000)), VariavelResultado="QBER", UnidadeResultado="adim", Icone="Q" },
            new Formula { Id = "cur_v12_qinfo_006", Nome = "Erro médio de porta", Categoria = categoria, SubCategoria = subCategoria, Expressao = "r ≈ (d−1)(1−F_avg)/d", ExprTexto = "r aproximado do fidelity medio", Criador = "Benchmarking randômico", AnoOrigin = "Sec. XXI", Descricao = "Relação aproximada entre fidelidade média e taxa de erro de porta em dimensão d.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Magesan, E.; Gambetta, J. M.; Emerson, J. Characterizing quantum gates via randomized benchmarking. Phys. Rev. A 85, 042311 (2012).", FonteUrlOuDoi = "https://doi.org/10.1103/PhysRevA.85.042311", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="d", Nome="Dimensão Hilbert", Unidade="adim", ValorPadrao=2, ValorMin=2, ValorMax=1e30}, new Variavel{ Simbolo="Favg", Nome="Fidelidade média", Unidade="adim", ValorPadrao=0.99, ValorMin=0, ValorMax=1}}, Calcular = vars => { var d=Math.Max(2,vars.GetValueOrDefault("d",2)); var f=Math.Clamp(vars.GetValueOrDefault("Favg",0.99),0,1); return ((d-1)*(1-f))/d; }, VariavelResultado="r", UnidadeResultado="adim", Icone="r" },
            new Formula { Id = "cur_v12_qinfo_007", Nome = "Tempo de coerência efetivo", Categoria = categoria, SubCategoria = subCategoria, Expressao = "1/T2 = 1/(2T1) + 1/Tphi", ExprTexto = "inverso de T2", Criador = "Ruído quântico", AnoOrigin = "Sec. XX", Descricao = "Relação entre relaxação e dephasing puro para qubits.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Ithier, G. et al. Decoherence in a superconducting quantum bit circuit. Phys. Rev. B 72, 134519 (2005).", FonteUrlOuDoi = "https://doi.org/10.1103/PhysRevB.72.134519", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="T1", Nome="Tempo T1", Unidade="s", ValorPadrao=50e-6, ValorMin=1e-30, ValorMax=1e30}, new Variavel{ Simbolo="Tphi", Nome="Tempo dephasing puro", Unidade="s", ValorPadrao=80e-6, ValorMin=1e-30, ValorMax=1e30}}, Calcular = vars => { var T1=Math.Max(1e-30,vars.GetValueOrDefault("T1",50e-6)); var Tp=Math.Max(1e-30,vars.GetValueOrDefault("Tphi",80e-6)); return 1.0/(0.5/T1 + 1.0/Tp); }, VariavelResultado="T2", UnidadeResultado="s", Icone="T2" },
            new Formula { Id = "cur_v12_qinfo_008", Nome = "Bound de Holevo (binário)", Categoria = categoria, SubCategoria = subCategoria, Expressao = "χ ≤ S(ρ) − Σp_i S(ρ_i)", ExprTexto = "chi limitado pela diferença de entropias", Criador = "Alexander Holevo", AnoOrigin = "1973", Descricao = "Limite superior para informação clássica acessível por estados quânticos.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Holevo, A. S. Bounds for the quantity of information transmitted by a quantum communication channel. Probl. Inf. Transm. 9, 177 (1973).", FonteUrlOuDoi = "https://www.mathnet.ru/eng/ppi903", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="Srho", Nome="Entropia de rho", Unidade="bits", ValorPadrao=1.0, ValorMin=0, ValorMax=1e30}, new Variavel{ Simbolo="Savg", Nome="Entropia média condicional", Unidade="bits", ValorPadrao=0.3, ValorMin=0, ValorMax=1e30}}, Calcular = vars => Math.Max(0, vars.GetValueOrDefault("Srho",1.0)-vars.GetValueOrDefault("Savg",0.3)), VariavelResultado="χ", UnidadeResultado="bits", Icone="χ" },
            new Formula { Id = "cur_v12_qinfo_009", Nome = "Probabilidade de sucesso na teletransporte ideal", Categoria = categoria, SubCategoria = subCategoria, Expressao = "P = 1 (ideal)", ExprTexto = "P igual a 1 no caso ideal", Criador = "Bennett et al.", AnoOrigin = "1993", Descricao = "Teletransporte quântico ideal tem sucesso determinístico com correção clássica.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Bennett, C. H. et al. Teleporting an unknown quantum state via dual classical and Einstein-Podolsky-Rosen channels. Phys. Rev. Lett. 70, 1895 (1993).", FonteUrlOuDoi = "https://doi.org/10.1103/PhysRevLett.70.1895", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="ideal", Nome="Indicador ideal (0/1)", Unidade="adim", ValorPadrao=1.0, ValorMin=0, ValorMax=1}}, Calcular = vars => Math.Clamp(vars.GetValueOrDefault("ideal",1.0),0,1), VariavelResultado="P", UnidadeResultado="adim", Icone="P" },
            new Formula { Id = "cur_v12_qinfo_010", Nome = "Taxa de capacidade de canal depolarizante", Categoria = categoria, SubCategoria = subCategoria, Expressao = "C ≈ 1 − H2(p)", ExprTexto = "capacidade aproximada = 1 menos entropia binária", Criador = "Teoria de canais quânticos", AnoOrigin = "Sec. XXI", Descricao = "Aproximação útil para taxa por qubit em ruído simétrico binário efetivo.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Wilde, M. M. Quantum Information Theory, 2ª ed., Cambridge University Press, 2017. Cap. 13.", FonteUrlOuDoi = "https://doi.org/10.1017/9781316809976", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{ Simbolo="p", Nome="Probabilidade de erro", Unidade="adim", ValorPadrao=0.05, ValorMin=1e-12, ValorMax=1-1e-12}}, Calcular = vars => { var p=Math.Clamp(vars.GetValueOrDefault("p",0.05),1e-12,1-1e-12); var h= -p*Math.Log2(p)-(1-p)*Math.Log2(1-p); return 1.0-h; }, VariavelResultado="C", UnidadeResultado="bits/qubit", Icone="C" }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Informacao Quantica Avancada", lote);
    }

    private void AdicionarLoteCuradoPilotoTermoenergeticaMotores()
    {
        const string categoria = "Termoenergética e Motores";
        const string subCategoria = "Curadoria Piloto - Ciclos e Performance";

        var lote = new List<Formula>
        {
            new Formula { Id = "cur_v12_tm_001", Nome = "Eficiência térmica", Categoria = categoria, SubCategoria = subCategoria, Expressao = "η = W_out/Q_in", ExprTexto = "eta = trabalho sobre calor de entrada", Criador = "Termodinâmica clássica", AnoOrigin = "Sec. XIX", Descricao = "Rendimento térmico de ciclo de potência.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Çengel, Y. A.; Boles, M. A. Thermodynamics: An Engineering Approach, 9ª ed., McGraw-Hill, 2019. Cap. 9.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/thermodynamics-engineering-approach-cengel-boles/M9781259822674.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="Wout",Nome="Trabalho útil",Unidade="J",ValorPadrao=400.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="Qin",Nome="Calor de entrada",Unidade="J",ValorPadrao=1000.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("Wout",400.0))/Math.Max(1e-30,vars.GetValueOrDefault("Qin",1000.0)), VariavelResultado="η", UnidadeResultado="adim", Icone="η" },
            new Formula { Id = "cur_v12_tm_002", Nome = "COP de refrigerador", Categoria = categoria, SubCategoria = subCategoria, Expressao = "COP_R = Q_L/W_in", ExprTexto = "COP de refrigeração", Criador = "Termodinâmica clássica", AnoOrigin = "Sec. XIX", Descricao = "Coeficiente de desempenho de refrigerador.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Çengel, Y. A.; Boles, M. A. Thermodynamics: An Engineering Approach, 9ª ed., McGraw-Hill, 2019. Cap. 10.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/thermodynamics-engineering-approach-cengel-boles/M9781259822674.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="QL",Nome="Calor removido",Unidade="J",ValorPadrao=500.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="Win",Nome="Trabalho de entrada",Unidade="J",ValorPadrao=150.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("QL",500.0))/Math.Max(1e-30,vars.GetValueOrDefault("Win",150.0)), VariavelResultado="COP_R", UnidadeResultado="adim", Icone="COP" },
            new Formula { Id = "cur_v12_tm_003", Nome = "Eficiência de Carnot", Categoria = categoria, SubCategoria = subCategoria, Expressao = "η_C = 1 − T_c/T_h", ExprTexto = "eta de Carnot", Criador = "Sadi Carnot", AnoOrigin = "1824", Descricao = "Eficiência máxima entre dois reservatórios térmicos.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Moran, M.; Shapiro, H. Fundamentals of Engineering Thermodynamics, 9ª ed., Wiley, 2018. Cap. 6.", FonteUrlOuDoi = "https://www.wiley.com/en-us/Fundamentals+of+Engineering+Thermodynamics%2C+9th+Edition-p-9781119391425", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="Tc",Nome="Temperatura fria",Unidade="K",ValorPadrao=300.0,ValorMin=1e-30,ValorMax=1e30}, new Variavel{Simbolo="Th",Nome="Temperatura quente",Unidade="K",ValorPadrao=900.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => 1.0 - Math.Max(1e-30,vars.GetValueOrDefault("Tc",300.0))/Math.Max(1e-30,vars.GetValueOrDefault("Th",900.0)), VariavelResultado="η_C", UnidadeResultado="adim", Icone="C" },
            new Formula { Id = "cur_v12_tm_004", Nome = "Eficiência Otto ideal", Categoria = categoria, SubCategoria = subCategoria, Expressao = "η_Otto = 1 − 1/r^(k−1)", ExprTexto = "eta Otto", Criador = "Ciclo Otto", AnoOrigin = "Sec. XIX", Descricao = "Rendimento ideal do ciclo Otto em função da taxa de compressão.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Heywood, J. B. Internal Combustion Engine Fundamentals, 2ª ed., McGraw-Hill, 2018. Cap. 5.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/internal-combustion-engine-fundamentals-heywood/M9781260116106.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="r",Nome="Taxa de compressão",Unidade="adim",ValorPadrao=10.0,ValorMin=1+1e-6,ValorMax=1e30}, new Variavel{Simbolo="k",Nome="Razão de calores específicos",Unidade="adim",ValorPadrao=1.4,ValorMin=1+1e-6,ValorMax=3}}, Calcular = vars => { var r=Math.Max(1+1e-6,vars.GetValueOrDefault("r",10.0)); var k=Math.Max(1+1e-6,vars.GetValueOrDefault("k",1.4)); return 1.0 - 1.0/Math.Pow(r,k-1.0); }, VariavelResultado="η_Otto", UnidadeResultado="adim", Icone="Otto" },
            new Formula { Id = "cur_v12_tm_005", Nome = "Eficiência Diesel ideal", Categoria = categoria, SubCategoria = subCategoria, Expressao = "η_D = 1 − (1/r^(k−1))·((ρ^k − 1)/(k(ρ − 1)))", ExprTexto = "eta Diesel ideal", Criador = "Ciclo Diesel", AnoOrigin = "Sec. XIX", Descricao = "Rendimento ideal do ciclo Diesel com taxa de corte ρ.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Çengel, Y. A.; Boles, M. A. Thermodynamics: An Engineering Approach, 9ª ed., McGraw-Hill, 2019. Cap. 9.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/thermodynamics-engineering-approach-cengel-boles/M9781259822674.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="r",Nome="Taxa de compressão",Unidade="adim",ValorPadrao=16.0,ValorMin=1+1e-6,ValorMax=1e30}, new Variavel{Simbolo="k",Nome="Razão de calores específicos",Unidade="adim",ValorPadrao=1.4,ValorMin=1+1e-6,ValorMax=3}, new Variavel{Simbolo="rho",Nome="Taxa de corte",Unidade="adim",ValorPadrao=2.0,ValorMin=1+1e-6,ValorMax=1e30}}, Calcular = vars => { var r=Math.Max(1+1e-6,vars.GetValueOrDefault("r",16.0)); var k=Math.Max(1+1e-6,vars.GetValueOrDefault("k",1.4)); var rho=Math.Max(1+1e-6,vars.GetValueOrDefault("rho",2.0)); return 1.0 - (1.0/Math.Pow(r,k-1.0))*((Math.Pow(rho,k)-1.0)/(k*(rho-1.0))); }, VariavelResultado="η_D", UnidadeResultado="adim", Icone="Diesel" },
            new Formula { Id = "cur_v12_tm_006", Nome = "Potência de eixo", Categoria = categoria, SubCategoria = subCategoria, Expressao = "P = 2πNT", ExprTexto = "P = 2 pi N T", Criador = "Máquinas rotativas", AnoOrigin = "Sec. XIX", Descricao = "Potência mecânica no eixo para velocidade N em rotações por segundo.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Heywood, J. B. Internal Combustion Engine Fundamentals, 2ª ed., McGraw-Hill, 2018. Cap. 1.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/internal-combustion-engine-fundamentals-heywood/M9781260116106.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="N",Nome="Rotação",Unidade="rev/s",ValorPadrao=50.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="Tq",Nome="Torque",Unidade="N·m",ValorPadrao=200.0,ValorMin=0,ValorMax=1e30}}, Calcular = vars => 2.0*Math.PI*Math.Max(0,vars.GetValueOrDefault("N",50.0))*Math.Max(0,vars.GetValueOrDefault("Tq",200.0)), VariavelResultado="P", UnidadeResultado="W", Icone="P" },
            new Formula { Id = "cur_v12_tm_007", Nome = "Consumo específico de combustível", Categoria = categoria, SubCategoria = subCategoria, Expressao = "BSFC = m_dot_f/P_b", ExprTexto = "bsfc = vazao de combustivel sobre potencia de freio", Criador = "Engenharia de motores", AnoOrigin = "Sec. XX", Descricao = "Massa de combustível por unidade de potência de eixo.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Heywood, J. B. Internal Combustion Engine Fundamentals, 2ª ed., McGraw-Hill, 2018. Cap. 3.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/internal-combustion-engine-fundamentals-heywood/M9781260116106.html", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="mdotf",Nome="Vazão mássica de combustível",Unidade="kg/s",ValorPadrao=0.01,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="Pb",Nome="Potência de freio",Unidade="W",ValorPadrao=50000.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("mdotf",0.01))/Math.Max(1e-30,vars.GetValueOrDefault("Pb",50000.0)), VariavelResultado="BSFC", UnidadeResultado="kg/J", Icone="BSFC" },
            new Formula { Id = "cur_v12_tm_008", Nome = "Eficiência isentrópica de compressor", Categoria = categoria, SubCategoria = subCategoria, Expressao = "η_c = (h2s − h1)/(h2 − h1)", ExprTexto = "eta c", Criador = "Turbomáquinas", AnoOrigin = "Sec. XX", Descricao = "Comparação do trabalho ideal com o real no compressor.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Moran, M.; Shapiro, H. Fundamentals of Engineering Thermodynamics, 9ª ed., Wiley, 2018. Cap. 8.", FonteUrlOuDoi = "https://www.wiley.com/en-us/Fundamentals+of+Engineering+Thermodynamics%2C+9th+Edition-p-9781119391425", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="h1",Nome="Entalpia de entrada",Unidade="kJ/kg",ValorPadrao=300.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="h2s",Nome="Entalpia de saída isentrópica",Unidade="kJ/kg",ValorPadrao=350.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="h2",Nome="Entalpia de saída real",Unidade="kJ/kg",ValorPadrao=370.0,ValorMin=-1e30,ValorMax=1e30}}, Calcular = vars => (vars.GetValueOrDefault("h2s",350.0)-vars.GetValueOrDefault("h1",300.0))/Math.Max(1e-30,vars.GetValueOrDefault("h2",370.0)-vars.GetValueOrDefault("h1",300.0)), VariavelResultado="η_c", UnidadeResultado="adim", Icone="ηc" },
            new Formula { Id = "cur_v12_tm_009", Nome = "Eficiência isentrópica de turbina", Categoria = categoria, SubCategoria = subCategoria, Expressao = "η_t = (h1 − h2)/(h1 − h2s)", ExprTexto = "eta t", Criador = "Turbomáquinas", AnoOrigin = "Sec. XX", Descricao = "Comparação do trabalho real com o ideal na turbina.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Moran, M.; Shapiro, H. Fundamentals of Engineering Thermodynamics, 9ª ed., Wiley, 2018. Cap. 8.", FonteUrlOuDoi = "https://www.wiley.com/en-us/Fundamentals+of+Engineering+Thermodynamics%2C+9th+Edition-p-9781119391425", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="h1",Nome="Entalpia de entrada",Unidade="kJ/kg",ValorPadrao=1200.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="h2",Nome="Entalpia de saída real",Unidade="kJ/kg",ValorPadrao=900.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="h2s",Nome="Entalpia de saída isentrópica",Unidade="kJ/kg",ValorPadrao=850.0,ValorMin=-1e30,ValorMax=1e30}}, Calcular = vars => (vars.GetValueOrDefault("h1",1200.0)-vars.GetValueOrDefault("h2",900.0))/Math.Max(1e-30,vars.GetValueOrDefault("h1",1200.0)-vars.GetValueOrDefault("h2s",850.0)), VariavelResultado="η_t", UnidadeResultado="adim", Icone="ηt" },
            new Formula { Id = "cur_v12_tm_010", Nome = "Taxa de calor em trocador", Categoria = categoria, SubCategoria = subCategoria, Expressao = "Q_dot = m_dot·cp·ΔT", ExprTexto = "Qdot = mdot cp delta T", Criador = "Transferência de calor", AnoOrigin = "Sec. XIX", Descricao = "Potência térmica trocada em escoamento monofásico.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Incropera, F. P.; DeWitt, D. P. Fundamentals of Heat and Mass Transfer, 7ª ed., Wiley, 2011. Cap. 11.", FonteUrlOuDoi = "https://www.wiley.com/en-us/Fundamentals+of+Heat+and+Mass+Transfer%2C+7th+Edition-p-9780470501962", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="mdot",Nome="Vazão mássica",Unidade="kg/s",ValorPadrao=2.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="cp",Nome="Calor específico",Unidade="J/(kg·K)",ValorPadrao=1005.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="dT",Nome="Variação de temperatura",Unidade="K",ValorPadrao=30.0,ValorMin=-1e30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("mdot",2.0))*Math.Max(0,vars.GetValueOrDefault("cp",1005.0))*vars.GetValueOrDefault("dT",30.0), VariavelResultado="Q_dot", UnidadeResultado="W", Icone="Q" }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Termoenergetica e Motores", lote);
    }

    private void AdicionarLoteCuradoPilotoGeoquimica()
    {
        const string categoria = "Geoquímica";
        const string subCategoria = "Curadoria Piloto - Isótopos e Partição";

        var lote = new List<Formula>
        {
            new Formula { Id = "cur_v12_geo_001", Nome = "Decaimento radioativo", Categoria = categoria, SubCategoria = subCategoria, Expressao = "N = N0·exp(−λt)", ExprTexto = "N = N zero exp menos lambda t", Criador = "Rutherford-Soddy", AnoOrigin = "Sec. XX", Descricao = "Número de núcleos remanescentes após tempo t.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Faure, G.; Mensing, T. M. Isotopes: Principles and Applications, 3ª ed., Wiley, 2005. Cap. 2.", FonteUrlOuDoi = "https://www.wiley.com/en-us/Isotopes%3A+Principles+and+Applications%2C+3rd+Edition-p-9780471384373", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="N0",Nome="Núcleos iniciais",Unidade="adim",ValorPadrao=1e6,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="lambda",Nome="Constante de decaimento",Unidade="1/ano",ValorPadrao=1e-9,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="t",Nome="Tempo",Unidade="ano",ValorPadrao=1e8,ValorMin=0,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("N0",1e6))*Math.Exp(-Math.Max(0,vars.GetValueOrDefault("lambda",1e-9))*Math.Max(0,vars.GetValueOrDefault("t",1e8))), VariavelResultado="N", UnidadeResultado="adim", Icone="N" },
            new Formula { Id = "cur_v12_geo_002", Nome = "Meia-vida", Categoria = categoria, SubCategoria = subCategoria, Expressao = "t1/2 = ln2/λ", ExprTexto = "meia vida = ln2 sobre lambda", Criador = "Física nuclear", AnoOrigin = "Sec. XX", Descricao = "Tempo para reduzir pela metade a quantidade de nuclídeos.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Faure, G.; Mensing, T. M. Isotopes: Principles and Applications, 3ª ed., Wiley, 2005. Cap. 2.", FonteUrlOuDoi = "https://www.wiley.com/en-us/Isotopes%3A+Principles+and+Applications%2C+3rd+Edition-p-9780471384373", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="lambda",Nome="Constante de decaimento",Unidade="1/ano",ValorPadrao=1e-9,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Log(2.0)/Math.Max(1e-30,vars.GetValueOrDefault("lambda",1e-9)), VariavelResultado="t1/2", UnidadeResultado="ano", Icone="t" },
            new Formula { Id = "cur_v12_geo_003", Nome = "Idade radiométrica", Categoria = categoria, SubCategoria = subCategoria, Expressao = "t = (1/λ)ln(1 + D/P)", ExprTexto = "idade radiometrica", Criador = "Geocronologia isotópica", AnoOrigin = "Sec. XX", Descricao = "Idade obtida por razão entre produto filho radiogênico e pai remanescente.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Dickin, A. P. Radiogenic Isotope Geology, 2ª ed., Cambridge University Press, 2005. Cap. 3.", FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511810688", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="lambda",Nome="Constante de decaimento",Unidade="1/ano",ValorPadrao=1e-9,ValorMin=1e-30,ValorMax=1e30}, new Variavel{Simbolo="D",Nome="Filho radiogênico",Unidade="mol",ValorPadrao=2.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="P",Nome="Pai remanescente",Unidade="mol",ValorPadrao=1.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => (1.0/Math.Max(1e-30,vars.GetValueOrDefault("lambda",1e-9)))*Math.Log(1.0+Math.Max(0,vars.GetValueOrDefault("D",2.0))/Math.Max(1e-30,vars.GetValueOrDefault("P",1.0))), VariavelResultado="t", UnidadeResultado="ano", Icone="age" },
            new Formula { Id = "cur_v12_geo_004", Nome = "Notação delta isotópica", Categoria = categoria, SubCategoria = subCategoria, Expressao = "δ = ((R_am/R_std) − 1)·1000", ExprTexto = "delta isotopico em por mil", Criador = "Geoquímica isotópica", AnoOrigin = "Sec. XX", Descricao = "Expressa enriquecimento isotópico relativo ao padrão.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Hoefs, J. Stable Isotope Geochemistry, 8ª ed., Springer, 2018. Cap. 1.", FonteUrlOuDoi = "https://doi.org/10.1007/978-3-319-78589-9", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="Ram",Nome="Razão isotópica da amostra",Unidade="adim",ValorPadrao=0.011,ValorMin=1e-30,ValorMax=1e30}, new Variavel{Simbolo="Rstd",Nome="Razão isotópica padrão",Unidade="adim",ValorPadrao=0.0108,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => ((Math.Max(1e-30,vars.GetValueOrDefault("Ram",0.011))/Math.Max(1e-30,vars.GetValueOrDefault("Rstd",0.0108)))-1.0)*1000.0, VariavelResultado="δ", UnidadeResultado="‰", Icone="δ" },
            new Formula { Id = "cur_v12_geo_005", Nome = "Fração de Rayleigh", Categoria = categoria, SubCategoria = subCategoria, Expressao = "R = R0·f^(α−1)", ExprTexto = "R = R0 f elevado a alfa menos 1", Criador = "Processos fracionantes", AnoOrigin = "Sec. XX", Descricao = "Evolução isotópica residual em processo de remoção progressiva.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Clark, I.; Fritz, P. Environmental Isotopes in Hydrogeology, CRC Press, 1997. Cap. 3.", FonteUrlOuDoi = "https://doi.org/10.1201/9781482267242", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="R0",Nome="Razão inicial",Unidade="adim",ValorPadrao=0.011,ValorMin=1e-30,ValorMax=1e30}, new Variavel{Simbolo="f",Nome="Fração remanescente",Unidade="adim",ValorPadrao=0.6,ValorMin=1e-30,ValorMax=1}, new Variavel{Simbolo="alpha",Nome="Fator de fracionamento",Unidade="adim",ValorPadrao=1.01,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(1e-30,vars.GetValueOrDefault("R0",0.011))*Math.Pow(Math.Clamp(vars.GetValueOrDefault("f",0.6),1e-30,1),vars.GetValueOrDefault("alpha",1.01)-1.0), VariavelResultado="R", UnidadeResultado="adim", Icone="R" },
            new Formula { Id = "cur_v12_geo_006", Nome = "Coeficiente de partição", Categoria = categoria, SubCategoria = subCategoria, Expressao = "D = C_s/C_l", ExprTexto = "D = concentracao solido sobre liquido", Criador = "Petrologia ígnea", AnoOrigin = "Sec. XX", Descricao = "Particionamento de elemento traço entre sólido e líquido.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Rollinson, H. Using Geochemical Data: Evaluation, Presentation, Interpretation, Longman, 1993. Cap. 9.", FonteUrlOuDoi = "https://www.routledge.com/Using-Geochemical-Data-Evaluation-Presentation-Interpretation/Rollinson/p/book/9780582067011", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="Cs",Nome="Concentração no sólido",Unidade="ppm",ValorPadrao=50.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="Cl",Nome="Concentração no líquido",Unidade="ppm",ValorPadrao=20.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("Cs",50.0))/Math.Max(1e-30,vars.GetValueOrDefault("Cl",20.0)), VariavelResultado="D", UnidadeResultado="adim", Icone="D" },
            new Formula { Id = "cur_v12_geo_007", Nome = "Densidade de fluxo geoquímico", Categoria = categoria, SubCategoria = subCategoria, Expressao = "J = C·q", ExprTexto = "J = C vezes vazao especifica", Criador = "Transporte geoquímico", AnoOrigin = "Sec. XX", Descricao = "Fluxo de massa por unidade de área em meio poroso por advecção simples.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Appelo, C. A. J.; Postma, D. Geochemistry, Groundwater and Pollution, 2ª ed., CRC Press, 2005. Cap. 10.", FonteUrlOuDoi = "https://doi.org/10.1201/9781439833544", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="C",Nome="Concentração",Unidade="mol/m3",ValorPadrao=0.01,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="q",Nome="Fluxo volumétrico específico",Unidade="m/s",ValorPadrao=1e-6,ValorMin=0,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("C",0.01))*Math.Max(0,vars.GetValueOrDefault("q",1e-6)), VariavelResultado="J", UnidadeResultado="mol/(m2·s)", Icone="J" },
            new Formula { Id = "cur_v12_geo_008", Nome = "Fator de enriquecimento", Categoria = categoria, SubCategoria = subCategoria, Expressao = "EF = (C_x/C_ref)_am/(C_x/C_ref)_bg", ExprTexto = "fator de enriquecimento", Criador = "Geoquímica ambiental", AnoOrigin = "Sec. XX", Descricao = "Compara razão elemento de interesse/referência com fundo geoquímico.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Reimann, C.; de Caritat, P. Chemical Elements in the Environment, Springer, 1998. Cap. 4.", FonteUrlOuDoi = "https://doi.org/10.1007/978-3-642-72016-1", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="ratioAm",Nome="Razão na amostra",Unidade="adim",ValorPadrao=2.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="ratioBg",Nome="Razão de fundo",Unidade="adim",ValorPadrao=1.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("ratioAm",2.0))/Math.Max(1e-30,vars.GetValueOrDefault("ratioBg",1.0)), VariavelResultado="EF", UnidadeResultado="adim", Icone="EF" },
            new Formula { Id = "cur_v12_geo_009", Nome = "Razão Rb-Sr isócrona", Categoria = categoria, SubCategoria = subCategoria, Expressao = "(87Sr/86Sr)_t = (87Sr/86Sr)_0 + (87Rb/86Sr)(e^{λt}−1)", ExprTexto = "equação isócrona Rb Sr", Criador = "Geocronologia Rb-Sr", AnoOrigin = "Sec. XX", Descricao = "Relação isotópica para sistema Rb-Sr em evolução fechada.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Dickin, A. P. Radiogenic Isotope Geology, 2ª ed., Cambridge University Press, 2005. Cap. 5.", FonteUrlOuDoi = "https://doi.org/10.1017/CBO9780511810688", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="Sr0",Nome="(87Sr/86Sr) inicial",Unidade="adim",ValorPadrao=0.704,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="RbSr",Nome="(87Rb/86Sr)",Unidade="adim",ValorPadrao=0.5,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="lambda",Nome="Constante de decaimento",Unidade="1/ano",ValorPadrao=1.42e-11,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="t",Nome="Tempo",Unidade="ano",ValorPadrao=1e9,ValorMin=0,ValorMax=1e30}}, Calcular = vars => vars.GetValueOrDefault("Sr0",0.704)+Math.Max(0,vars.GetValueOrDefault("RbSr",0.5))*(Math.Exp(Math.Max(0,vars.GetValueOrDefault("lambda",1.42e-11))*Math.Max(0,vars.GetValueOrDefault("t",1e9)))-1.0), VariavelResultado="(87Sr/86Sr)_t", UnidadeResultado="adim", Icone="Sr" },
            new Formula { Id = "cur_v12_geo_010", Nome = "Índice de saturação", Categoria = categoria, SubCategoria = subCategoria, Expressao = "SI = log10(IAP/Ksp)", ExprTexto = "indice de saturacao", Criador = "Geoquímica aquosa", AnoOrigin = "Sec. XX", Descricao = "Indica sub/supersaturação de mineral em solução.", Procedencia = "Literatura científica revisada por pares", ReferenciaBibliografica = "Appelo, C. A. J.; Postma, D. Geochemistry, Groundwater and Pollution, 2ª ed., CRC Press, 2005. Cap. 5.", FonteUrlOuDoi = "https://doi.org/10.1201/9781439833544", StatusCuradoria = "Curada - fonte primária verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="IAP",Nome="Produto iônico",Unidade="adim",ValorPadrao=1e-8,ValorMin=1e-300,ValorMax=1e30}, new Variavel{Simbolo="Ksp",Nome="Constante de solubilidade",Unidade="adim",ValorPadrao=1e-8,ValorMin=1e-300,ValorMax=1e30}}, Calcular = vars => Math.Log10(Math.Max(1e-300,vars.GetValueOrDefault("IAP",1e-8))/Math.Max(1e-300,vars.GetValueOrDefault("Ksp",1e-8))), VariavelResultado="SI", UnidadeResultado="adim", Icone="SI" }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Geoquimica", lote);
    }

    private void AdicionarLoteCuradoPilotoEconometria()
    {
        const string categoria = "Econometria";
        const string subCategoria = "Curadoria Piloto - Regressao e Diagnostico";

        var lote = new List<Formula>
        {
            new Formula { Id = "cur_v12_ecm_001", Nome = "Coeficiente angular OLS", Categoria = categoria, SubCategoria = subCategoria, Expressao = "beta1 = cov(x,y)/var(x)", ExprTexto = "beta 1 por minimos quadrados", Criador = "Gauss; Legendre", AnoOrigin = "Sec. XIX", Descricao = "Estimador de inclinacao em regressao linear simples por minimos quadrados ordinarios.", ExemploPratico = "Com cov=12 e varx=3, beta1=4.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Wooldridge, J. M. Introductory Econometrics: A Modern Approach, 7th ed., Cengage, 2020. Eq. (2.12).", FonteUrlOuDoi = "https://www.cengage.com/c/introductory-econometrics-a-modern-approach-7e-wooldridge/", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="cov",Nome="Covariancia amostral",Descricao="Cov(x,y)",Unidade="adim",ValorPadrao=12.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="varx",Nome="Variancia de x",Descricao="Var(x)",Unidade="adim",ValorPadrao=3.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => vars.GetValueOrDefault("cov",12.0)/Math.Max(1e-30,vars.GetValueOrDefault("varx",3.0)), VariavelResultado = "beta1", UnidadeResultado = "adim", Icone = "β" },
            new Formula { Id = "cur_v12_ecm_002", Nome = "Intercepto OLS", Categoria = categoria, SubCategoria = subCategoria, Expressao = "beta0 = y_bar - beta1*x_bar", ExprTexto = "beta 0 por minimos quadrados", Criador = "Gauss; Legendre", AnoOrigin = "Sec. XIX", Descricao = "Estimador de intercepto em regressao linear simples.", ExemploPratico = "Com ybar=20, beta1=4 e xbar=3, beta0=8.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Wooldridge, J. M. Introductory Econometrics: A Modern Approach, 7th ed., Cengage, 2020. Eq. (2.13).", FonteUrlOuDoi = "https://www.cengage.com/c/introductory-econometrics-a-modern-approach-7e-wooldridge/", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="ybar",Nome="Media de y",Descricao="y medio",Unidade="adim",ValorPadrao=20.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="beta1",Nome="Coeficiente angular",Descricao="beta1",Unidade="adim",ValorPadrao=4.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="xbar",Nome="Media de x",Descricao="x medio",Unidade="adim",ValorPadrao=3.0,ValorMin=-1e30,ValorMax=1e30}}, Calcular = vars => vars.GetValueOrDefault("ybar",20.0) - vars.GetValueOrDefault("beta1",4.0) * vars.GetValueOrDefault("xbar",3.0), VariavelResultado = "beta0", UnidadeResultado = "adim", Icone = "β" },
            new Formula { Id = "cur_v12_ecm_003", Nome = "Coeficiente de determinacao", Categoria = categoria, SubCategoria = subCategoria, Expressao = "R2 = 1 - SSR/SST", ExprTexto = "R quadrado", Criador = "Karl Pearson", AnoOrigin = "Sec. XX", Descricao = "Fracao da variancia explicada pelo modelo linear.", ExemploPratico = "Se SSR=30 e SST=120, R2=0.75.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Greene, W. H. Econometric Analysis, 8th ed., Pearson, 2018. Sec. 2.3.", FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/econometric-analysis/P200000003451", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="SSR",Nome="Soma dos quadrados dos residuos",Descricao="Residual Sum of Squares",Unidade="adim",ValorPadrao=30.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="SST",Nome="Soma total dos quadrados",Descricao="Total Sum of Squares",Unidade="adim",ValorPadrao=120.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => 1.0 - Math.Max(0,vars.GetValueOrDefault("SSR",30.0))/Math.Max(1e-30,vars.GetValueOrDefault("SST",120.0)), VariavelResultado = "R2", UnidadeResultado = "adim", Icone = "R²" },
            new Formula { Id = "cur_v12_ecm_004", Nome = "R2 ajustado", Categoria = categoria, SubCategoria = subCategoria, Expressao = "R2_adj = 1 - ((n-1)/(n-k-1))*(1-R2)", ExprTexto = "R quadrado ajustado", Criador = "Theil", AnoOrigin = "Sec. XX", Descricao = "Ajusta o R2 penalizando complexidade do modelo.", ExemploPratico = "n=100, k=3, R2=0.80 gera R2_adj ~0.793.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Gujarati, D. N.; Porter, D. C. Basic Econometrics, 5th ed., McGraw-Hill, 2009. Ch. 7.", FonteUrlOuDoi = "https://www.mheducation.com/highered/product/basic-econometrics-gujarati-porter/M9780073375779.html", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="n",Nome="Tamanho amostral",Descricao="Numero de observacoes",Unidade="adim",ValorPadrao=100,ValorMin=3,ValorMax=1e30}, new Variavel{Simbolo="k",Nome="Numero de regressoras",Descricao="Sem contar intercepto",Unidade="adim",ValorPadrao=3,ValorMin=1,ValorMax=1e30}, new Variavel{Simbolo="R2",Nome="R quadrado",Descricao="Coeficiente de determinacao",Unidade="adim",ValorPadrao=0.8,ValorMin=0,ValorMax=1}}, Calcular = vars => { var n=Math.Max(3,vars.GetValueOrDefault("n",100)); var k=Math.Max(1,vars.GetValueOrDefault("k",3)); var r2=Math.Clamp(vars.GetValueOrDefault("R2",0.8),0,1); var denom=Math.Max(1e-30,n-k-1); return 1.0 - ((n-1.0)/denom)*(1.0-r2); }, VariavelResultado = "R2_adj", UnidadeResultado = "adim", Icone = "R²" },
            new Formula { Id = "cur_v12_ecm_005", Nome = "Estatistica t", Categoria = categoria, SubCategoria = subCategoria, Expressao = "t = (beta_hat - beta0)/se(beta_hat)", ExprTexto = "teste t para coeficiente", Criador = "William S. Gosset", AnoOrigin = "1908", Descricao = "Estatistica para testar hipotese sobre coeficiente individual.", ExemploPratico = "beta_hat=1.8, beta0=0, se=0.3 => t=6.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Stock, J. H.; Watson, M. W. Introduction to Econometrics, 4th ed., Pearson, 2019. Ch. 5.", FonteUrlOuDoi = "https://www.pearson.com/en-us/subject-catalog/p/introduction-to-econometrics/P200000003155", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="bhat",Nome="Estimativa do coeficiente",Descricao="beta estimado",Unidade="adim",ValorPadrao=1.8,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="b0",Nome="Valor sob H0",Descricao="beta hipotetico",Unidade="adim",ValorPadrao=0.0,ValorMin=-1e30,ValorMax=1e30}, new Variavel{Simbolo="seb",Nome="Erro padrao",Descricao="Desvio padrao estimado",Unidade="adim",ValorPadrao=0.3,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => (vars.GetValueOrDefault("bhat",1.8)-vars.GetValueOrDefault("b0",0.0))/Math.Max(1e-30,vars.GetValueOrDefault("seb",0.3)), VariavelResultado = "t", UnidadeResultado = "adim", Icone = "t" },
            new Formula { Id = "cur_v12_ecm_006", Nome = "Estatistica F global", Categoria = categoria, SubCategoria = subCategoria, Expressao = "F = ((R2/k)/((1-R2)/(n-k-1)))", ExprTexto = "teste F global", Criador = "R. A. Fisher", AnoOrigin = "Sec. XX", Descricao = "Teste conjunto de significancia dos coeficientes da regressao.", ExemploPratico = "R2=0.6, k=4, n=120 => F~43.29.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Wooldridge, J. M. Introductory Econometrics: A Modern Approach, 7th ed., Cengage, 2020. Ch. 4.", FonteUrlOuDoi = "https://www.cengage.com/c/introductory-econometrics-a-modern-approach-7e-wooldridge/", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="R2",Nome="R quadrado",Descricao="Coeficiente de determinacao",Unidade="adim",ValorPadrao=0.6,ValorMin=0,ValorMax=1}, new Variavel{Simbolo="k",Nome="Numero de restricoes",Descricao="Numero de regressoras",Unidade="adim",ValorPadrao=4,ValorMin=1,ValorMax=1e30}, new Variavel{Simbolo="n",Nome="Tamanho amostral",Descricao="Numero de observacoes",Unidade="adim",ValorPadrao=120,ValorMin=3,ValorMax=1e30}}, Calcular = vars => { var r2=Math.Clamp(vars.GetValueOrDefault("R2",0.6),0,1); var k=Math.Max(1,vars.GetValueOrDefault("k",4)); var n=Math.Max(3,vars.GetValueOrDefault("n",120)); var num=r2/k; var den=Math.Max(1e-30,(1-r2)/Math.Max(1e-30,n-k-1)); return num/den; }, VariavelResultado = "F", UnidadeResultado = "adim", Icone = "F" },
            new Formula { Id = "cur_v12_ecm_007", Nome = "Durbin-Watson", Categoria = categoria, SubCategoria = subCategoria, Expressao = "DW = sum((e_t - e_t-1)^2)/sum(e_t^2)", ExprTexto = "estatistica Durbin Watson", Criador = "Durbin; Watson", AnoOrigin = "Sec. XX", Descricao = "Indicador de autocorrelacao serial de primeira ordem nos residuos.", ExemploPratico = "Numerador=210 e denominador=120 => DW=1.75.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Durbin, J.; Watson, G. S. Testing for Serial Correlation in Least Squares Regression. Biometrika 37(3/4), 409-428, 1950.", FonteUrlOuDoi = "https://doi.org/10.2307/2332391", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="num",Nome="Soma diferencas quadradas",Descricao="Somatorio de (e_t-e_t-1)^2",Unidade="adim",ValorPadrao=210.0,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="den",Nome="Soma residuos quadrados",Descricao="Somatorio de e_t^2",Unidade="adim",ValorPadrao=120.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("num",210.0))/Math.Max(1e-30,vars.GetValueOrDefault("den",120.0)), VariavelResultado = "DW", UnidadeResultado = "adim", Icone = "DW" },
            new Formula { Id = "cur_v12_ecm_008", Nome = "AIC", Categoria = categoria, SubCategoria = subCategoria, Expressao = "AIC = 2k - 2ln(L)", ExprTexto = "criterio de Akaike", Criador = "Hirotugu Akaike", AnoOrigin = "1974", Descricao = "Criterio de informacao para comparacao de modelos com penalizacao de parametros.", ExemploPratico = "k=5 e lnL=-120 => AIC=250.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Akaike, H. A New Look at the Statistical Model Identification. IEEE Trans. Automatic Control 19(6), 716-723, 1974.", FonteUrlOuDoi = "https://doi.org/10.1109/TAC.1974.1100705", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="k",Nome="Numero de parametros",Descricao="Complexidade do modelo",Unidade="adim",ValorPadrao=5,ValorMin=1,ValorMax=1e30}, new Variavel{Simbolo="lnL",Nome="Log-verossimilhanca",Descricao="ln(L)",Unidade="adim",ValorPadrao=-120.0,ValorMin=-1e30,ValorMax=1e30}}, Calcular = vars => 2.0*Math.Max(1,vars.GetValueOrDefault("k",5)) - 2.0*vars.GetValueOrDefault("lnL",-120.0), VariavelResultado = "AIC", UnidadeResultado = "adim", Icone = "AIC" },
            new Formula { Id = "cur_v12_ecm_009", Nome = "BIC", Categoria = categoria, SubCategoria = subCategoria, Expressao = "BIC = ln(n)k - 2ln(L)", ExprTexto = "criterio Bayesiano de informacao", Criador = "Gideon Schwarz", AnoOrigin = "1978", Descricao = "Criterio de informacao bayesiano com penalizacao crescente com tamanho amostral.", ExemploPratico = "n=200, k=5, lnL=-120 => BIC~266.49.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Schwarz, G. Estimating the Dimension of a Model. Annals of Statistics 6(2), 461-464, 1978.", FonteUrlOuDoi = "https://doi.org/10.1214/aos/1176344136", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="n",Nome="Tamanho amostral",Descricao="Numero de observacoes",Unidade="adim",ValorPadrao=200,ValorMin=1,ValorMax=1e30}, new Variavel{Simbolo="k",Nome="Numero de parametros",Descricao="Complexidade do modelo",Unidade="adim",ValorPadrao=5,ValorMin=1,ValorMax=1e30}, new Variavel{Simbolo="lnL",Nome="Log-verossimilhanca",Descricao="ln(L)",Unidade="adim",ValorPadrao=-120.0,ValorMin=-1e30,ValorMax=1e30}}, Calcular = vars => Math.Log(Math.Max(1,vars.GetValueOrDefault("n",200)))*Math.Max(1,vars.GetValueOrDefault("k",5)) - 2.0*vars.GetValueOrDefault("lnL",-120.0), VariavelResultado = "BIC", UnidadeResultado = "adim", Icone = "BIC" },
            new Formula { Id = "cur_v12_ecm_010", Nome = "Semi-elasticidade em modelo log-linear", Categoria = categoria, SubCategoria = subCategoria, Expressao = "pct = 100*(exp(beta)-1)", ExprTexto = "variacao percentual aproximada", Criador = "Hal Varian", AnoOrigin = "Sec. XX", Descricao = "Converte coeficiente em modelo com log na dependente para efeito percentual exato.", ExemploPratico = "beta=0.07 => efeito de 7.25%.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Wooldridge, J. M. Introductory Econometrics: A Modern Approach, 7th ed., Cengage, 2020. Ch. 6.", FonteUrlOuDoi = "https://www.cengage.com/c/introductory-econometrics-a-modern-approach-7e-wooldridge/", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="beta",Nome="Coeficiente estimado",Descricao="Efeito em log(y)",Unidade="adim",ValorPadrao=0.07,ValorMin=-100,ValorMax=100}}, Calcular = vars => 100.0*(Math.Exp(vars.GetValueOrDefault("beta",0.07))-1.0), VariavelResultado = "pct", UnidadeResultado = "%", Icone = "%" }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Econometria", lote);
    }

    private void AdicionarLoteCuradoPilotoEpidemiologia()
    {
        const string categoria = "Epidemiologia";
        const string subCategoria = "Curadoria Piloto - Medidas de Associacao";

        var lote = new List<Formula>
        {
            new Formula { Id = "cur_v12_epi_001", Nome = "Prevalencia", Categoria = categoria, SubCategoria = subCategoria, Expressao = "Prev = casos/populacao", ExprTexto = "prevalencia pontual", Criador = "Epidemiologia classica", AnoOrigin = "Sec. XX", Descricao = "Proporcao de individuos com a condicao em um ponto no tempo.", ExemploPratico = "500 casos em populacao 10000 => 5%.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Rothman, K. J.; Greenland, S.; Lash, T. L. Modern Epidemiology, 3rd ed., Lippincott Williams & Wilkins, 2008. Ch. 2.", FonteUrlOuDoi = "https://books.google.com/books?id=Z3vjT6f4A9wC", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="cases",Nome="Casos existentes",Descricao="Numero de casos",Unidade="adim",ValorPadrao=500,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="pop",Nome="Populacao total",Descricao="Populacao em risco",Unidade="adim",ValorPadrao=10000,ValorMin=1,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("cases",500))/Math.Max(1,vars.GetValueOrDefault("pop",10000)), VariavelResultado = "Prev", UnidadeResultado = "adim", Icone = "P" },
            new Formula { Id = "cur_v12_epi_002", Nome = "Incidencia cumulativa", Categoria = categoria, SubCategoria = subCategoria, Expressao = "CI = novos_casos/populacao_risco", ExprTexto = "incidencia cumulativa", Criador = "Epidemiologia classica", AnoOrigin = "Sec. XX", Descricao = "Risco de desenvolver o desfecho em periodo definido.", ExemploPratico = "120 novos casos em 2400 individuos de risco => 5%.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Gordis, L. Epidemiology, 6th ed., Elsevier, 2019. Ch. 3.", FonteUrlOuDoi = "https://www.elsevier.com/books/epidemiology/gordis/978-0-323-55229-5", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="new",Nome="Novos casos",Descricao="Casos incidentes",Unidade="adim",ValorPadrao=120,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="riskpop",Nome="Populacao em risco",Descricao="Individuos sob risco",Unidade="adim",ValorPadrao=2400,ValorMin=1,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("new",120))/Math.Max(1,vars.GetValueOrDefault("riskpop",2400)), VariavelResultado = "CI", UnidadeResultado = "adim", Icone = "I" },
            new Formula { Id = "cur_v12_epi_003", Nome = "Densidade de incidencia", Categoria = categoria, SubCategoria = subCategoria, Expressao = "IR = novos_casos/pessoa_tempo", ExprTexto = "taxa de incidencia", Criador = "Epidemiologia classica", AnoOrigin = "Sec. XX", Descricao = "Taxa baseada no tempo total de observacao em risco.", ExemploPratico = "90 casos em 4500 pessoa-ano => 0.02 por pessoa-ano.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Rothman, K. J. Epidemiology: An Introduction, 2nd ed., Oxford University Press, 2012. Ch. 4.", FonteUrlOuDoi = "https://global.oup.com/academic/product/epidemiology-an-introduction-9780199754557", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="new",Nome="Novos casos",Descricao="Casos incidentes",Unidade="adim",ValorPadrao=90,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="pt",Nome="Pessoa-tempo",Descricao="Soma dos tempos individuais",Unidade="pessoa-ano",ValorPadrao=4500,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("new",90))/Math.Max(1e-30,vars.GetValueOrDefault("pt",4500)), VariavelResultado = "IR", UnidadeResultado = "1/pessoa-ano", Icone = "IR" },
            new Formula { Id = "cur_v12_epi_004", Nome = "Risco relativo", Categoria = categoria, SubCategoria = subCategoria, Expressao = "RR = risco_expostos/risco_nao_expostos", ExprTexto = "risco relativo", Criador = "Cornfield", AnoOrigin = "Sec. XX", Descricao = "Compara risco entre grupos expostos e nao expostos.", ExemploPratico = "0.12/0.04 => RR=3.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Szklo, M.; Nieto, F. J. Epidemiology: Beyond the Basics, 4th ed., Jones & Bartlett, 2019. Ch. 5.", FonteUrlOuDoi = "https://www.jblearning.com/catalog/productdetails/9781284116595", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="re",Nome="Risco em expostos",Descricao="Risco acumulado",Unidade="adim",ValorPadrao=0.12,ValorMin=0,ValorMax=1}, new Variavel{Simbolo="ru",Nome="Risco em nao expostos",Descricao="Risco acumulado",Unidade="adim",ValorPadrao=0.04,ValorMin=1e-30,ValorMax=1}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("re",0.12))/Math.Max(1e-30,vars.GetValueOrDefault("ru",0.04)), VariavelResultado = "RR", UnidadeResultado = "adim", Icone = "RR" },
            new Formula { Id = "cur_v12_epi_005", Nome = "Razao de taxas", Categoria = categoria, SubCategoria = subCategoria, Expressao = "IRR = taxa_expostos/taxa_nao_expostos", ExprTexto = "razao de taxas de incidencia", Criador = "Epidemiologia moderna", AnoOrigin = "Sec. XX", Descricao = "Compara densidades de incidencia entre grupos.", ExemploPratico = "0.030/0.015 => IRR=2.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Kleinbaum, D. G.; Klein, M. Survival Analysis, 3rd ed., Springer, 2012. Ch. 2.", FonteUrlOuDoi = "https://doi.org/10.1007/978-1-4419-6646-9", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="ie",Nome="Taxa em expostos",Descricao="Incidencia por pessoa-tempo",Unidade="1/pessoa-ano",ValorPadrao=0.03,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="iu",Nome="Taxa em nao expostos",Descricao="Incidencia por pessoa-tempo",Unidade="1/pessoa-ano",ValorPadrao=0.015,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("ie",0.03))/Math.Max(1e-30,vars.GetValueOrDefault("iu",0.015)), VariavelResultado = "IRR", UnidadeResultado = "adim", Icone = "IRR" },
            new Formula { Id = "cur_v12_epi_006", Nome = "Odds ratio", Categoria = categoria, SubCategoria = subCategoria, Expressao = "OR = (a*d)/(b*c)", ExprTexto = "odds ratio 2x2", Criador = "Cornfield", AnoOrigin = "Sec. XX", Descricao = "Medida de associacao comum em estudos caso-controle.", ExemploPratico = "a=60,b=40,c=30,d=70 => OR=3.5.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Breslow, N. E.; Day, N. E. Statistical Methods in Cancer Research, Vol. I, IARC, 1980. Sec. 4.", FonteUrlOuDoi = "https://publications.iarc.fr/Book-And-Report-Series/Iarc-Scientific-Publications/Statistical-Methods-In-Cancer-Research-Volume-I-The-Analysis-Of-Case-Control-Studies-1980", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="a",Nome="Expostos com desfecho",Descricao="Celula a",Unidade="adim",ValorPadrao=60,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="b",Nome="Expostos sem desfecho",Descricao="Celula b",Unidade="adim",ValorPadrao=40,ValorMin=1e-30,ValorMax=1e30}, new Variavel{Simbolo="c",Nome="Nao expostos com desfecho",Descricao="Celula c",Unidade="adim",ValorPadrao=30,ValorMin=1e-30,ValorMax=1e30}, new Variavel{Simbolo="d",Nome="Nao expostos sem desfecho",Descricao="Celula d",Unidade="adim",ValorPadrao=70,ValorMin=0,ValorMax=1e30}}, Calcular = vars => (Math.Max(0,vars.GetValueOrDefault("a",60))*Math.Max(0,vars.GetValueOrDefault("d",70)))/(Math.Max(1e-30,vars.GetValueOrDefault("b",40))*Math.Max(1e-30,vars.GetValueOrDefault("c",30))), VariavelResultado = "OR", UnidadeResultado = "adim", Icone = "OR" },
            new Formula { Id = "cur_v12_epi_007", Nome = "Fracao atribuivel nos expostos", Categoria = categoria, SubCategoria = subCategoria, Expressao = "AFe = (RR-1)/RR", ExprTexto = "fracao atribuivel em expostos", Criador = "Miettinen", AnoOrigin = "Sec. XX", Descricao = "Proporcao do risco entre expostos atribuivel a exposicao.", ExemploPratico = "RR=3 => AFe=0.667.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Miettinen, O. S. Proportion of disease caused or prevented by a given exposure. American Journal of Epidemiology 99(5), 325-332, 1974.", FonteUrlOuDoi = "https://doi.org/10.1093/oxfordjournals.aje.a121617", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="RR",Nome="Risco relativo",Descricao="Medida de associacao",Unidade="adim",ValorPadrao=3.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => { var rr=Math.Max(1e-30,vars.GetValueOrDefault("RR",3.0)); return (rr-1.0)/rr; }, VariavelResultado = "AFe", UnidadeResultado = "adim", Icone = "AF" },
            new Formula { Id = "cur_v12_epi_008", Nome = "Fracao atribuivel populacional", Categoria = categoria, SubCategoria = subCategoria, Expressao = "PAF = Pe*(RR-1)/(1+Pe*(RR-1))", ExprTexto = "fracao atribuivel populacional", Criador = "Levin", AnoOrigin = "1953", Descricao = "Proporcao de casos na populacao atribuivel a exposicao.", ExemploPratico = "Pe=0.30, RR=2 => PAF=0.231.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Levin, M. L. The occurrence of lung cancer in man. Acta Unio Internationalis Contra Cancrum 9, 531-541, 1953.", FonteUrlOuDoi = "https://pubmed.ncbi.nlm.nih.gov/13124110/", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="Pe",Nome="Prevalencia de exposicao",Descricao="Fracao exposta",Unidade="adim",ValorPadrao=0.30,ValorMin=0,ValorMax=1}, new Variavel{Simbolo="RR",Nome="Risco relativo",Descricao="Medida de associacao",Unidade="adim",ValorPadrao=2.0,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => { var pe=Math.Clamp(vars.GetValueOrDefault("Pe",0.30),0,1); var rr=Math.Max(1e-30,vars.GetValueOrDefault("RR",2.0)); var top=pe*(rr-1.0); return top/(1.0+top); }, VariavelResultado = "PAF", UnidadeResultado = "adim", Icone = "PAF" },
            new Formula { Id = "cur_v12_epi_009", Nome = "Numero basico de reproducao", Categoria = categoria, SubCategoria = subCategoria, Expressao = "R0 = beta/gamma", ExprTexto = "R zero em SIR", Criador = "Kermack; McKendrick", AnoOrigin = "1927", Descricao = "Numero medio de infeccoes secundarias em populacao suscetivel.", ExemploPratico = "beta=0.36 e gamma=0.12 => R0=3.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "Kermack, W. O.; McKendrick, A. G. A contribution to the mathematical theory of epidemics. Proc. Royal Society A 115(772), 700-721, 1927.", FonteUrlOuDoi = "https://doi.org/10.1098/rspa.1927.0118", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="beta",Nome="Taxa de transmissao",Descricao="Contato efetivo",Unidade="1/dia",ValorPadrao=0.36,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="gamma",Nome="Taxa de remocao",Descricao="Recuperacao/remocao",Unidade="1/dia",ValorPadrao=0.12,ValorMin=1e-30,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("beta",0.36))/Math.Max(1e-30,vars.GetValueOrDefault("gamma",0.12)), VariavelResultado = "R0", UnidadeResultado = "adim", Icone = "R0" },
            new Formula { Id = "cur_v12_epi_010", Nome = "Taxa de letalidade", Categoria = categoria, SubCategoria = subCategoria, Expressao = "CFR = obitos/casos", ExprTexto = "case fatality rate", Criador = "Epidemiologia clinica", AnoOrigin = "Sec. XX", Descricao = "Proporcao de casos que evoluem para obito em um periodo.", ExemploPratico = "25 obitos em 1000 casos => CFR=2.5%.", Procedencia = "Literatura cientifica revisada por pares", ReferenciaBibliografica = "WHO. Communicable disease surveillance and response systems: Guide to monitoring and evaluating, 2006. Sec. 5.", FonteUrlOuDoi = "https://apps.who.int/iris/handle/10665/69331", StatusCuradoria = "Curada - fonte primaria verificada", Variaveis = new List<Variavel>{ new Variavel{Simbolo="deaths",Nome="Obitos",Descricao="Numero de obitos entre casos",Unidade="adim",ValorPadrao=25,ValorMin=0,ValorMax=1e30}, new Variavel{Simbolo="cases",Nome="Casos",Descricao="Numero total de casos",Unidade="adim",ValorPadrao=1000,ValorMin=1,ValorMax=1e30}}, Calcular = vars => Math.Max(0,vars.GetValueOrDefault("deaths",25))/Math.Max(1,vars.GetValueOrDefault("cases",1000)), VariavelResultado = "CFR", UnidadeResultado = "adim", Icone = "CFR" }
        };

        AdicionarPacoteCurado("Curadoria manual por area - Epidemiologia", lote);
    }
}