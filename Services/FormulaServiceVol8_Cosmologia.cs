using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE X: COSMOLOGIA
    // Expansão universo, Big Bang, energia escura, radiação cósmica
    // 19 fórmulas (184-202)
    // ========================================

    public static Formula V8_COS184_LeiHubble()
    {
        return new Formula
        {
            Id = "V8-COS184",
            CodigoCompendio = "184",
            Nome = "Lei de Hubble",
            Categoria = "Cosmologia",
            SubCategoria = "Expansão do Universo",
            Expressao = "v = H0 * d",
            ExprTexto = "Velocidade recessão",
            Descricao = "v=velocidade recessão (km/s), H0=const. Hubble (km/s/Mpc), d=distância (Mpc). H0≈70km/s/Mpc.",
            Criador = "Edwin Hubble",
            AnoOrigin = "1929",
            ExemploPratico = "d=100Mpc, H0=70km/s/Mpc → v=7000km/s. Galáxias distantes: afastamento proporcional à distância",
            Unidades = "km/s",
            VariavelResultado = "v",
            UnidadeResultado = "km/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "H0", Nome = "Constante Hubble", Descricao = "H0", Unidade = "km/s/Mpc", ValorPadrao = 70, ValorMin = 60, ValorMax = 80, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Distância", Descricao = "d", Unidade = "Mpc", ValorPadrao = 100, ValorMin = 0.1, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double H0 = inputs["H0"];
                double d = inputs["d"];
                
                return H0 * d;
            }
        };
    }

    public static Formula V8_COS185_RedshiftCosmologico()
    {
        return new Formula
        {
            Id = "V8-COS185",
            CodigoCompendio = "185",
            Nome = "Redshift Cosmológico — z",
            Categoria = "Cosmologia",
            SubCategoria = "Expansão do Universo",
            Expressao = "z = (λ_obs - λ_emit) / λ_emit",
            ExprTexto = "Redshift",
            Descricao = "λ_obs=comprimento onda observado (nm), λ_emit=emitido (nm). z>0: afastamento. z=(a_now/a_then)-1.",
            Criador = "Cosmologia",
            AnoOrigin = "~1920s",
            ExemploPratico = "λ_emit=486nm (Hβ), λ_obs=583nm → z≈0,2 (v≈0,2c). CMB: z≈1100 (recombinação)",
            Unidades = "adimensional",
            VariavelResultado = "z",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda_obs", Nome = "λ observado", Descricao = "λ_obs", Unidade = "nm", ValorPadrao = 583, ValorMin = 100, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "lambda_emit", Nome = "λ emitido", Descricao = "λ_emit", Unidade = "nm", ValorPadrao = 486, ValorMin = 100, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda_obs = inputs["lambda_obs"];
                double lambda_emit = inputs["lambda_emit"];
                
                return (lambda_obs - lambda_emit) / lambda_emit;
            }
        };
    }

    public static Formula V8_COS186_DistanciaComovente()
    {
        return new Formula
        {
            Id = "V8-COS186",
            CodigoCompendio = "186",
            Nome = "Distância Comóvel — Universo Plano (aproximado)",
            Categoria = "Cosmologia",
            SubCategoria = "Geometria do Universo",
            Expressao = "Dc = (c / H0) * ln(1 + z)",
            ExprTexto = "Distância comóvel (simplificado)",
            Descricao = "c=3e5km/s, H0=70km/s/Mpc, z=redshift. Integral exata: matéria/Λ. Baixo z: Dc≈cz/H0.",
            Criador = "Cosmologia moderna",
            AnoOrigin = "~1930s",
            ExemploPratico = "z=1, H0=70km/s/Mpc → Dc≈3000Mpc (9,8Gly). CMB (z=1100): Dc≈14Gpc (46Gly)",
            Unidades = "Mpc",
            VariavelResultado = "Dc",
            UnidadeResultado = "Mpc",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "c", Nome = "Velocidade luz", Descricao = "c", Unidade = "km/s", ValorPadrao = 299792, ValorMin = 299792, ValorMax = 299792, Obrigatoria = true },
                new() { Simbolo = "H0", Nome = "Hubble", Descricao = "H0", Unidade = "km/s/Mpc", ValorPadrao = 70, ValorMin = 60, ValorMax = 80, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "Redshift", Descricao = "z", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 1100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double c = inputs["c"];
                double H0 = inputs["H0"];
                double z = inputs["z"];
                
                return (c / H0) * Math.Log(1 + z);
            }
        };
    }

    public static Formula V8_COS187_IdadeUniverso()
    {
        return new Formula
        {
            Id = "V8-COS187",
            CodigoCompendio = "187",
            Nome = "Idade do Universo — t0 (matéria dominante simplificado)",
            Categoria = "Cosmologia",
            SubCategoria = "Evolução do Universo",
            Expressao = "t0 = (2/3) / H0",
            ExprTexto = "Idade universo (Einstein-de Sitter)",
            Descricao = "H0=const. Hubble (s⁻¹). Modelo Ωm=1, ΩΛ=0. ΛCDM: t0≈13,8Gyr (H0=70km/s/Mpc).",
            Criador = "Friedmann, Einstein-de Sitter",
            AnoOrigin = "1922, 1932",
            ExemploPratico = "H0=70km/s/Mpc (2,27e-18s⁻¹) → t0≈9,3Gyr. ΛCDM real: t0≈13,8Gyr (energia escura)",
            Unidades = "s",
            VariavelResultado = "t0",
            UnidadeResultado = "s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "H0_si", Nome = "H0", Descricao = "H0 em s⁻¹", Unidade = "s⁻¹", ValorPadrao = 2.27e-18, ValorMin = 1.9e-18, ValorMax = 2.6e-18, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double H0_si = inputs["H0_si"];
                
                return (2.0 / 3.0) / H0_si;
            }
        };
    }

    public static Formula V8_COS188_ParametroDensidade()
    {
        return new Formula
        {
            Id = "V8-COS188",
            CodigoCompendio = "188",
            Nome = "Parâmetro de Densidade — Ω",
            Categoria = "Cosmologia",
            SubCategoria = "Geometria do Universo",
            Expressao = "Ω = ρ / ρ_crit",
            ExprTexto = "Parâmetro densidade",
            Descricao = "ρ=densidade energia (J/m³), ρ_crit=3H²/(8πG). Ω=1: plano. Ω>1: fechado. Ω<1: aberto.",
            Criador = "Friedmann",
            AnoOrigin = "1922",
            ExemploPratico = "ρ_crit≈9,2e-10J/m³ (H0=70). ΛCDM: Ωm≈0,3, ΩΛ≈0,7, Ω_total≈1 (plano)",
            Unidades = "adimensional",
            VariavelResultado = "Omega",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "ρ", Unidade = "J/m³", ValorPadrao = 3e-10, ValorMin = 1e-15, ValorMax = 1e-5, Obrigatoria = true },
                new() { Simbolo = "rho_crit", Nome = "ρ crítica", Descricao = "ρ_crit", Unidade = "J/m³", ValorPadrao = 9.2e-10, ValorMin = 1e-10, ValorMax = 1e-8, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double rho = inputs["rho"];
                double rho_crit = inputs["rho_crit"];
                
                return rho / rho_crit;
            }
        };
    }

    public static Formula V8_COS189_DensidadeCritica()
    {
        return new Formula
        {
            Id = "V8-COS189",
            CodigoCompendio = "189",
            Nome = "Densidade Crítica do Universo — ρ_crit",
            Categoria = "Cosmologia",
            SubCategoria = "Geometria do Universo",
            Expressao = "ρ_crit = (3 * H² / (8 * π * G))",
            ExprTexto = "Densidade crítica",
            Descricao = "H=Hubble (s⁻¹), G=6,674e-11m³/kg/s². ρ_crit separa universo fechado/aberto.",
            Criador = "Friedmann",
            AnoOrigin = "1922",
            ExemploPratico = "H0=70km/s/Mpc (2,27e-18s⁻¹) → ρ_crit≈9,2e-27kg/m³ (~5,5 átomos H/m³)",
            Unidades = "kg/m³",
            VariavelResultado = "rho_crit",
            UnidadeResultado = "kg/m³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "H", Nome = "Hubble", Descricao = "H", Unidade = "s⁻¹", ValorPadrao = 2.27e-18, ValorMin = 1.9e-18, ValorMax = 2.6e-18, Obrigatoria = true },
                new() { Simbolo = "G", Nome = "Const. gravitacional", Descricao = "G", Unidade = "m³/kg/s²", ValorPadrao = 6.674e-11, ValorMin = 6.674e-11, ValorMax = 6.674e-11, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double H = inputs["H"];
                double G = inputs["G"];
                
                return (3 * H * H) / (8 * Math.PI * G);
            }
        };
    }

    public static Formula V8_COS190_EquacaoFriedmann1()
    {
        return new Formula
        {
            Id = "V8-COS190",
            CodigoCompendio = "190",
            Nome = "Primeira Equação de Friedmann",
            Categoria = "Cosmologia",
            SubCategoria = "Dinâmica do Universo",
            Expressao = "H² = (8 * π * G * ρ / 3) - (k * c² / a²)",
            ExprTexto = "Friedmann 1",
            Descricao = "H=Hubble(t), ρ=densidade(t), k=curvatura (0,+1,-1), a=fator escala. k=0: plano.",
            Criador = "Alexander Friedmann",
            AnoOrigin = "1922",
            ExemploPratico = "k=0 (plano): H²=(8πGρ)/3. Ω=1 → ρ=ρ_crit. Determina expansão do universo",
            Unidades = "s⁻²",
            VariavelResultado = "H_squared",
            UnidadeResultado = "s⁻²",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "G", Nome = "G", Descricao = "G", Unidade = "m³/kg/s²", ValorPadrao = 6.674e-11, ValorMin = 6.674e-11, ValorMax = 6.674e-11, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "ρ", Unidade = "kg/m³", ValorPadrao = 9.2e-27, ValorMin = 1e-30, ValorMax = 1e-20, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Curvatura", Descricao = "k", Unidade = "", ValorPadrao = 0, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "c", Descricao = "c", Unidade = "m/s", ValorPadrao = 299792458, ValorMin = 299792458, ValorMax = 299792458, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Fator escala", Descricao = "a", Unidade = "", ValorPadrao = 1, ValorMin = 1e-10, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double G = inputs["G"];
                double rho = inputs["rho"];
                double k = inputs["k"];
                double c = inputs["c"];
                double a = inputs["a"];
                
                return (8 * Math.PI * G * rho / 3) - (k * c * c / (a * a));
            }
        };
    }

    public static Formula V8_COS191_EquacaoFriedmann2()
    {
        return new Formula
        {
            Id = "V8-COS191",
            CodigoCompendio = "191",
            Nome = "Segunda Equação de Friedmann — Aceleração",
            Categoria = "Cosmologia",
            SubCategoria = "Dinâmica do Universo",
            Expressao = "ä/a = -(4 * π * G / 3) * (ρ + 3P/c²)",
            ExprTexto = "Friedmann 2",
            Descricao = "ä=d²a/dt², P=pressão. ρ+3P/c²>0: desaceleração. P<-ρc²/3: aceleração (energia escura).",
            Criador = "Alexander Friedmann",
            AnoOrigin = "1922",
            ExemploPratico = "Energia escura: P=-ρΛc² (eq. estado w=-1) → ä>0 (universo acelera). Observado 1998",
            Unidades = "s⁻²",
            VariavelResultado = "a_double_dot_over_a",
            UnidadeResultado = "s⁻²",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "G", Nome = "G", Descricao = "G", Unidade = "m³/kg/s²", ValorPadrao = 6.674e-11, ValorMin = 6.674e-11, ValorMax = 6.674e-11, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "ρ", Unidade = "kg/m³", ValorPadrao = 9.2e-27, ValorMin = 1e-30, ValorMax = 1e-20, Obrigatoria = true },
                new() { Simbolo = "P", Nome = "Pressão", Descricao = "P", Unidade = "Pa", ValorPadrao = -8.3e-10, ValorMin = -1e-5, ValorMax = 1e-5, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "c", Descricao = "c", Unidade = "m/s", ValorPadrao = 299792458, ValorMin = 299792458, ValorMax = 299792458, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double G = inputs["G"];
                double rho = inputs["rho"];
                double P = inputs["P"];
                double c = inputs["c"];
                
                return -(4 * Math.PI * G / 3) * (rho + 3 * P / (c * c));
            }
        };
    }

    public static Formula V8_COS192_EquacaoEstadoEnergiaEscura()
    {
        return new Formula
        {
            Id = "V8-COS192",
            CodigoCompendio = "192",
            Nome = "Equação de Estado — Energia Escura (w)",
            Categoria = "Cosmologia",
            SubCategoria = "Energia Escura",
            Expressao = "w = P / (ρ * c²)",
            ExprTexto = "Parâmetro w",
            Descricao = "P=pressão (Pa), ρ=densidade (kg/m³). Constante cosmol.: w=-1. Quintessência: w≈-0,8. Matéria: w=0.",
            Criador = "Cosmologia moderna",
            AnoOrigin = "~1990s",
            ExemploPratico = "w=-1: Λ (vácuo). w=-0,8: quintessência. w=0: matéria. w=1/3: radiação",
            Unidades = "adimensional",
            VariavelResultado = "w",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "Pressão", Descricao = "P", Unidade = "Pa", ValorPadrao = -8.3e-10, ValorMin = -1e-5, ValorMax = 1e-5, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "ρ", Unidade = "kg/m³", ValorPadrao = 9.2e-27, ValorMin = 1e-30, ValorMax = 1e-20, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "c", Descricao = "c", Unidade = "m/s", ValorPadrao = 299792458, ValorMin = 299792458, ValorMax = 299792458, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double rho = inputs["rho"];
                double c = inputs["c"];
                
                if (Math.Abs(rho) < 1e-40) return 0;
                
                return P / (rho * c * c);
            }
        };
    }

    public static Formula V8_COS193_TemperaturaCMB()
    {
        return new Formula
        {
            Id = "V8-COS193",
            CodigoCompendio = "193",
            Nome = "Temperatura da Radiação Cósmica de Fundo — CMB",
            Categoria = "Cosmologia",
            SubCategoria = "Radiação Cósmica",
            Expressao = "T = T0 * (1 + z)",
            ExprTexto = "Temperatura CMB",
            Descricao = "T0=2,7255K (hoje), z=redshift. Recombinação (z≈1100): T≈3000K. Resfriamento adiabático.",
            Criador = "Penzias & Wilson (descoberta CMB)",
            AnoOrigin = "1965",
            ExemploPratico = "z=1100 (recombinação) → T≈3000K. z=10 (reioniz.): T≈30K. Hoje: T0=2,7255K",
            Unidades = "K",
            VariavelResultado = "T",
            UnidadeResultado = "K",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T0", Nome = "T hoje", Descricao = "T0", Unidade = "K", ValorPadrao = 2.7255, ValorMin = 2.7, ValorMax = 2.8, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "Redshift", Descricao = "z", Unidade = "", ValorPadrao = 1100, ValorMin = 0, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T0 = inputs["T0"];
                double z = inputs["z"];
                
                return T0 * (1 + z);
            }
        };
    }

    public static Formula V8_COS194_DensidadeEnergiaRadiacao()
    {
        return new Formula
        {
            Id = "V8-COS194",
            CodigoCompendio = "194",
            Nome = "Densidade de Energia da Radiação — Stefan-Boltzmann",
            Categoria = "Cosmologia",
            SubCategoria = "Radiação Cósmica",
            Expressao = "u = (4 * σ / c) * T⁴",
            ExprTexto = "Densidade energia radiação",
            Descricao = "σ=5,67e-8W/m²/K⁴, c=3e8m/s, T=temp (K). CMB: T=2,73K → u≈4,2e-14J/m³.",
            Criador = "Stefan-Boltzmann",
            AnoOrigin = "1879-1884",
            ExemploPratico = "T=2,73K → u≈4,2e-14J/m³. Recombinação (T=3000K): u≈10⁸J/m³ (dominava universo primordial)",
            Unidades = "J/m³",
            VariavelResultado = "u",
            UnidadeResultado = "J/m³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sigma", Nome = "σ Stefan-Boltzmann", Descricao = "σ", Unidade = "W/m²/K⁴", ValorPadrao = 5.67e-8, ValorMin = 5.67e-8, ValorMax = 5.67e-8, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "c", Descricao = "c", Unidade = "m/s", ValorPadrao = 299792458, ValorMin = 299792458, ValorMax = 299792458, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "K", ValorPadrao = 2.73, ValorMin = 1, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sigma = inputs["sigma"];
                double c = inputs["c"];
                double T = inputs["T"];
                
                return (4 * sigma / c) * Math.Pow(T, 4);
            }
        };
    }

    public static Formula V8_COS195_MassaJeans()
    {
        return new Formula
        {
            Id = "V8-COS195",
            CodigoCompendio = "195",
            Nome = "Massa de Jeans — Colapso Gravitacional",
            Categoria = "Cosmologia",
            SubCategoria = "Formação de Estruturas",
            Expressao = "MJ = (5 * kB * T / (G * μ * mH))^(3/2) * (3 / (4 * π * ρ))^(1/2)",
            ExprTexto = "Massa Jeans (simplificado)",
            Descricao = "kB=1,38e-23J/K, G=6,67e-11, μ≈0,6 (gás), mH=1,67e-27kg, ρ=densidade (kg/m³). Nuvem colapsa se M>MJ.",
            Criador = "James Hopwood Jeans",
            AnoOrigin = "1902",
            ExemploPratico = "T=10K, ρ=1e-20kg/m³ → MJ≈10³M☉. Nuvens moleculares: MJ~1M☉-10⁴M☉ (forma estrelas)",
            Unidades = "kg",
            VariavelResultado = "MJ",
            UnidadeResultado = "kg",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "kB", Nome = "k Boltzmann", Descricao = "kB", Unidade = "J/K", ValorPadrao = 1.38e-23, ValorMin = 1.38e-23, ValorMax = 1.38e-23, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "K", ValorPadrao = 10, ValorMin = 1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "G", Nome = "G", Descricao = "G", Unidade = "m³/kg/s²", ValorPadrao = 6.674e-11, ValorMin = 6.674e-11, ValorMax = 6.674e-11, Obrigatoria = true },
                new() { Simbolo = "mu", Nome = "μ", Descricao = "Peso molecular médio", Unidade = "", ValorPadrao = 0.6, ValorMin = 0.5, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "mH", Nome = "Massa H", Descricao = "mH", Unidade = "kg", ValorPadrao = 1.67e-27, ValorMin = 1.67e-27, ValorMax = 1.67e-27, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "ρ", Unidade = "kg/m³", ValorPadrao = 1e-20, ValorMin = 1e-30, ValorMax = 1e-10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double kB = inputs["kB"];
                double T = inputs["T"];
                double G = inputs["G"];
                double mu = inputs["mu"];
                double mH = inputs["mH"];
                double rho = inputs["rho"];
                
                double cs_squared = (5 * kB * T) / (G * mu * mH);
                double MJ = Math.Pow(cs_squared, 1.5) * Math.Pow(3 / (4 * Math.PI * rho), 0.5);
                
                return MJ;
            }
        };
    }

    public static Formula V8_COS196_DistanciaLuminosidade()
    {
        return new Formula
        {
            Id = "V8-COS196",
            CodigoCompendio = "196",
            Nome = "Distância de Luminosidade — dL",
            Categoria = "Cosmologia",
            SubCategoria = "Medidas de Distância",
            Expressao = "dL = sqrt(L / (4 * π * F))",
            ExprTexto = "Distância luminosidade",
            Descricao = "L=luminosidade intrínseca (W), F=fluxo observado (W/m²). Redshift: dL=(1+z)·Dc.",
            Criador = "Astronomia",
            AnoOrigin = "~1900s",
            ExemploPratico = "L=3,8e26W (Sol), F=1360W/m² (Terra) → dL≈1,5e11m (1AU). Supernovas Ia: velas padrão",
            Unidades = "m",
            VariavelResultado = "dL",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L", Nome = "Luminosidade", Descricao = "L", Unidade = "W", ValorPadrao = 3.8e26, ValorMin = 1e20, ValorMax = 1e40, Obrigatoria = true },
                new() { Simbolo = "F", Nome = "Fluxo", Descricao = "F", Unidade = "W/m²", ValorPadrao = 1360, ValorMin = 1e-30, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L = inputs["L"];
                double F = inputs["F"];
                
                return Math.Sqrt(L / (4 * Math.PI * F));
            }
        };
    }

    public static Formula V8_COS197_DistanciaAngular()
    {
        return new Formula
        {
            Id = "V8-COS197",
            CodigoCompendio = "197",
            Nome = "Distância Angular — dA",
            Categoria = "Cosmologia",
            SubCategoria = "Medidas de Distância",
            Expressao = "dA = D / θ",
            ExprTexto = "Distância angular",
            Descricao = "D=tamanho físico (m), θ=ângulo (rad). Redshift: dA=Dc/(1+z). CMB: dA≈14Mpc/(1+1100).",
            Criador = "Astronomia",
            AnoOrigin = "~1900s",
            ExemploPratico = "D=1AU (1,5e11m), θ=1arcsec (4,85e-6rad) → dA≈206265AU≈3,26ly (definição parsec)",
            Unidades = "m",
            VariavelResultado = "dA",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "D", Nome = "Tamanho físico", Descricao = "D", Unidade = "m", ValorPadrao = 1.5e11, ValorMin = 1, ValorMax = 1e25, Obrigatoria = true },
                new() { Simbolo = "theta", Nome = "Ângulo", Descricao = "θ", Unidade = "rad", ValorPadrao = 4.85e-6, ValorMin = 1e-10, ValorMax = Math.PI, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double D = inputs["D"];
                double theta = inputs["theta"];
                
                return D / theta;
            }
        };
    }

    public static Formula V8_COS198_ModuloDistancia()
    {
        return new Formula
        {
            Id = "V8-COS198",
            CodigoCompendio = "198",
            Nome = "Módulo de Distância — m-M",
            Categoria = "Cosmologia",
            SubCategoria = "Medidas de Distância",
            Expressao = "m - M = 5 * log10(dL / 10pc)",
            ExprTexto = "Módulo distância",
            Descricao = "m=magnitude aparente, M=magnitude absoluta, dL=distância luminosidade (pc). 1pc=3,086e16m.",
            Criador = "Fotometria astronômica",
            AnoOrigin = "~1900s",
            ExemploPratico = "dL=100pc → m-M=5. Supernova Ia (M≈-19,3): dL=1Gpc → m≈24,7 (limiar telescópios)",
            Unidades = "mag",
            VariavelResultado = "m_minus_M",
            UnidadeResultado = "mag",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "dL", Nome = "Distância luminosidade", Descricao = "dL", Unidade = "pc", ValorPadrao = 100, ValorMin = 0.1, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double dL = inputs["dL"];
                
                return 5 * Math.Log10(dL / 10);
            }
        };
    }

    public static Formula V8_COS199_FatorEscalaFuncaoTempo()
    {
        return new Formula
        {
            Id = "V8-COS199",
            CodigoCompendio = "199",
            Nome = "Fator de Escala — a(t) (Einstein-de Sitter)",
            Categoria = "Cosmologia",
            SubCategoria = "Evolução do Universo",
            Expressao = "a = (t / t0)^(2/3)",
            ExprTexto = "Fator escala (matéria dominante)",
            Descricao = "t=tempo desde Big Bang (s), t0=idade universo (s). Ωm=1, ΩΛ=0. Hoje: a(t0)=1.",
            Criador = "Einstein-de Sitter",
            AnoOrigin = "1932",
            ExemploPratico = "t=t0/2 → a≈0,63 (z≈0,6). Recombinação (z=1100): a≈1/1101≈9e-4 (379kyr)",
            Unidades = "adimensional",
            VariavelResultado = "a",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "t", Unidade = "s", ValorPadrao = 2.2e17, ValorMin = 1e10, ValorMax = 1e18, Obrigatoria = true },
                new() { Simbolo = "t0", Nome = "Idade universo", Descricao = "t0", Unidade = "s", ValorPadrao = 4.35e17, ValorMin = 4e17, ValorMax = 5e17, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t = inputs["t"];
                double t0 = inputs["t0"];
                
                return Math.Pow(t / t0, 2.0 / 3.0);
            }
        };
    }

    public static Formula V8_COS200_TempoRecombinacao()
    {
        return new Formula
        {
            Id = "V8-COS200",
            CodigoCompendio = "200",
            Nome = "Tempo de Recombinação — t_rec (aproximado)",
            Categoria = "Cosmologia",
            SubCategoria = "História Cósmica",
            Expressao = "t_rec = 379000 yr * (1 yr / 3.156e7 s)",
            ExprTexto = "Tempo recombinação",
            Descricao = "t_rec≈379kyr após Big Bang. z≈1100, T≈3000K. Átomos neutros formam, CMB descola.",
            Criador = "Cosmologia moderna (Planck)",
            AnoOrigin = "~2013",
            ExemploPratico = "t_rec≈1,2e13s (379kyr). a≈1/1101. Depois: Idade Escura → reionização (z≈10, t≈500Myr)",
            Unidades = "s",
            VariavelResultado = "t_rec",
            UnidadeResultado = "s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t_rec_yr", Nome = "t_rec", Descricao = "t_rec em anos", Unidade = "yr", ValorPadrao = 379000, ValorMin = 370000, ValorMax = 390000, Obrigatoria = true },
                new() { Simbolo = "yr_to_s", Nome = "Conversão", Descricao = "1yr em s", Unidade = "s/yr", ValorPadrao = 3.156e7, ValorMin = 3.156e7, ValorMax = 3.156e7, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t_rec_yr = inputs["t_rec_yr"];
                double yr_to_s = inputs["yr_to_s"];
                
                return t_rec_yr * yr_to_s;
            }
        };
    }

    public static Formula V8_COS201_EscalaHorizonteCosmologico()
    {
        return new Formula
        {
            Id = "V8-COS201",
            CodigoCompendio = "201",
            Nome = "Raio do Horizonte de Hubble",
            Categoria = "Cosmologia",
            SubCategoria = "Geometria do Universo",
            Expressao = "RH = c / H",
            ExprTexto = "Horizonte Hubble",
            Descricao = "c=3e8m/s, H=Hubble(t) (s⁻¹). RH≈c/H0≈4400Mpc (14Gly). Limite causal em FRW.",
            Criador = "Cosmologia relativística",
            AnoOrigin = "~1930s",
            ExemploPratico = "H0=70km/s/Mpc → RH≈4,3Gpc≈14Gly. Horizonte partícula (integral): ~46Gly (comoving)",
            Unidades = "m",
            VariavelResultado = "RH",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "c", Nome = "c", Descricao = "c", Unidade = "m/s", ValorPadrao = 299792458, ValorMin = 299792458, ValorMax = 299792458, Obrigatoria = true },
                new() { Simbolo = "H", Nome = "Hubble", Descricao = "H", Unidade = "s⁻¹", ValorPadrao = 2.27e-18, ValorMin = 1.9e-18, ValorMax = 2.6e-18, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double c = inputs["c"];
                double H = inputs["H"];
                
                return c / H;
            }
        };
    }

    public static Formula V8_COS202_RazaoAbundanciaHelio()
    {
        return new Formula
        {
            Id = "V8-COS202",
            CodigoCompendio = "202",
            Nome = "Abundância Primordial de Hélio — Yp",
            Categoria = "Cosmologia",
            SubCategoria = "Nucleossíntese Primordial",
            Expressao = "Yp = (4 * nHe) / (nH + 4 * nHe)",
            ExprTexto = "Fração massa He",
            Descricao = "nHe=densidade numérica He, nH=densidade H. Nucleossíntese Big Bang: Yp≈0,24-0,25 (75%H, 25%He massa).",
            Criador = "Gamow, Alpher, Herman (BBN)",
            AnoOrigin = "1948",
            ExemploPratico = "nH/nHe≈12 → Yp≈0,25. Determina baryon density. Observado: Yp≈0,245 (consistente BBN)",
            Unidades = "adimensional",
            VariavelResultado = "Yp",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "nHe", Nome = "Densidade He", Descricao = "nHe", Unidade = "m⁻³", ValorPadrao = 1e26, ValorMin = 1e20, ValorMax = 1e30, Obrigatoria = true },
                new() { Simbolo = "nH", Nome = "Densidade H", Descricao = "nH", Unidade = "m⁻³", ValorPadrao = 1.2e27, ValorMin = 1e20, ValorMax = 1e30, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double nHe = inputs["nHe"];
                double nH = inputs["nH"];
                
                return (4 * nHe) / (nH + 4 * nHe);
            }
        };
    }
}
