using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE IX: OCEANOGRAFIA
    // Ondas, correntes, maré, propriedades da água do mar
    // 19 fórmulas (165-183)
    // ========================================

    public static Formula V8_OCE165_VelocidadeOnda()
    {
        return new Formula
        {
            Id = "V8-OCE165",
            CodigoCompendio = "165",
            Nome = "Velocidade de Onda de Águas Profundas",
            Categoria = "Oceanografia",
            SubCategoria = "Ondas",
            Expressao = "c = sqrt(g * λ / (2 * π))",
            ExprTexto = "Velocidade fase",
            Descricao = "c=velocidade (m/s), g=9,81m/s², λ=comprimento onda (m). Profundidade >λ/2: águas profundas.",
            Criador = "Teoria ondas lineares",
            AnoOrigin = "~1800s",
            ExemploPratico = "λ=100m → c≈12,5m/s. Período T=λ/c≈8s. Tsunami: λ~200km → c≈200m/s (560km/h)",
            Unidades = "m/s",
            VariavelResultado = "c",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "lambda", Nome = "Comprimento onda", Descricao = "λ", Unidade = "m", ValorPadrao = 100, ValorMin = 1, ValorMax = 1000000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double g = inputs["g"];
                double lambda = inputs["lambda"];
                
                return Math.Sqrt(g * lambda / (2 * Math.PI));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE166_PeriodoOnda()
    {
        return new Formula
        {
            Id = "V8-OCE166",
            CodigoCompendio = "166",
            Nome = "Período de Onda",
            Categoria = "Oceanografia",
            SubCategoria = "Ondas",
            Expressao = "T = λ / c",
            ExprTexto = "Período",
            Descricao = "T=período (s), λ=comprimento (m), c=velocidade (m/s). Ou T=2π·√(λ/(2πg)) para águas profundas.",
            Criador = "Ondas oceânicas",
            AnoOrigin = "~1800s",
            ExemploPratico = "λ=100m, c=12,5m/s → T=8s. Tempestade: T=10-15s. Tsunami: T~10-60min",
            Unidades = "s",
            VariavelResultado = "T",
            UnidadeResultado = "s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "Comprimento onda", Descricao = "λ", Unidade = "m", ValorPadrao = 100, ValorMin = 1, ValorMax = 500000, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Velocidade", Descricao = "c", Unidade = "m/s", ValorPadrao = 12.5, ValorMin = 0.1, ValorMax = 300, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                double c = inputs["c"];
                
                return lambda / c;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE167_AlturaSignificativa()
    {
        return new Formula
        {
            Id = "V8-OCE167",
            CodigoCompendio = "167",
            Nome = "Altura Significativa — Hs",
            Categoria = "Oceanografia",
            SubCategoria = "Ondas",
            Expressao = "Hs = 4 * sqrt(m0)",
            ExprTexto = "Altura significativa (espectral)",
            Descricao = "m0=momento ordem zero do espectro (m²). Hs=média 1/3 ondas maiores. Padrão engenharia.",
            Criador = "Oceanografia estatística",
            AnoOrigin = "~1940s",
            ExemploPratico = "m0=1m² → Hs=4m. Tempestade: Hs>6m. Sea state 5: Hs=4-6m (rough)",
            Unidades = "m",
            VariavelResultado = "Hs",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m0", Nome = "Momento m0", Descricao = "Variância espectro", Unidade = "m²", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m0 = inputs["m0"];
                
                return 4 * Math.Sqrt(m0);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE168_EscalaBeaufort()
    {
        return new Formula
        {
            Id = "V8-OCE168",
            CodigoCompendio = "168",
            Nome = "Escala Beaufort — Velocidade Vento (empírica)",
            Categoria = "Oceanografia",
            SubCategoria = "Vento e Ondas",
            Expressao = "B = 0.836 * v^(2/3)",
            ExprTexto = "Número Beaufort",
            Descricao = "B=força Beaufort (0-12), v=vento 10m (m/s). B=0: calmo. B=6: vento forte (10-12m/s). B=12: furacão (>33m/s).",
            Criador = "Francis Beaufort",
            AnoOrigin = "1805",
            ExemploPratico = "v=15m/s → B≈5,3 (fresh breeze). v=30m/s → B≈9 (strong gale). B=12: v≥33m/s",
            Unidades = "adimensional",
            VariavelResultado = "B",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v", Nome = "Velocidade vento", Descricao = "v", Unidade = "m/s", ValorPadrao = 15, ValorMin = 0, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v = inputs["v"];
                
                return 0.836 * Math.Pow(v, 2.0 / 3.0);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE169_SalinidadePratica()
    {
        return new Formula
        {
            Id = "V8-OCE169",
            CodigoCompendio = "169",
            Nome = "Salinidade Prática — PSU",
            Categoria = "Oceanografia",
            SubCategoria = "Propriedades da Água",
            Expressao = "S = (C / C_ref) * 35 PSU",
            ExprTexto = "Salinidade (simplificado)",
            Descricao = "C=condutividade (S/m), C_ref=padrão KCl. PSU≈g/kg. Mar: 33-37PSU. Oceano médio: 35PSU.",
            Criador = "PSS-78 (Practical Salinity Scale)",
            AnoOrigin = "1978",
            ExemploPratico = "C=C_ref → S=35PSU. Mediterrâneo: 38-39PSU. Mar Báltico: 7-8PSU. Rio: <0,5PSU",
            Unidades = "PSU",
            VariavelResultado = "S",
            UnidadeResultado = "PSU",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C", Nome = "Condutividade", Descricao = "C", Unidade = "S/m", ValorPadrao = 5, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "C_ref", Nome = "Condut. referência", Descricao = "C_ref", Unidade = "S/m", ValorPadrao = 5, ValorMin = 1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C = inputs["C"];
                double C_ref = inputs["C_ref"];
                
                return (C / C_ref) * 35;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE170_DensidadeAguaMar()
    {
        return new Formula
        {
            Id = "V8-OCE170",
            CodigoCompendio = "170",
            Nome = "Densidade da Água do Mar — ρ (empírica linear)",
            Categoria = "Oceanografia",
            SubCategoria = "Propriedades da Água",
            Expressao = "ρ = ρ0 + α_S * (S - S0) - β_T * (T - T0)",
            ExprTexto = "Densidade",
            Descricao = "ρ0=1025kg/m³ (S0=35PSU, T0=10°C), α_S≈0,78kg/m³/PSU, β_T≈0,2kg/m³/°C. Linear aproximado EOS.",
            Criador = "Equação de estado água mar (UNESCO)",
            AnoOrigin = "~1980",
            ExemploPratico = "S=35PSU, T=10°C → ρ=1025kg/m³. S=38PSU, T=15°C → ρ≈1026kg/m³. Gelo: <1027kg/m³",
            Unidades = "kg/m³",
            VariavelResultado = "rho",
            UnidadeResultado = "kg/m³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "rho0", Nome = "ρ referência", Descricao = "ρ0", Unidade = "kg/m³", ValorPadrao = 1025, ValorMin = 1020, ValorMax = 1030, Obrigatoria = true },
                new() { Simbolo = "alpha_S", Nome = "α_S", Descricao = "Coef. salinidade", Unidade = "kg/m³/PSU", ValorPadrao = 0.78, ValorMin = 0.7, ValorMax = 0.85, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Salinidade", Descricao = "S", Unidade = "PSU", ValorPadrao = 35, ValorMin = 0, ValorMax = 45, Obrigatoria = true },
                new() { Simbolo = "S0", Nome = "S referência", Descricao = "S0", Unidade = "PSU", ValorPadrao = 35, ValorMin = 30, ValorMax = 40, Obrigatoria = true },
                new() { Simbolo = "beta_T", Nome = "β_T", Descricao = "Coef. temperatura", Unidade = "kg/m³/°C", ValorPadrao = 0.2, ValorMin = 0.1, ValorMax = 0.3, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "°C", ValorPadrao = 10, ValorMin = -2, ValorMax = 35, Obrigatoria = true },
                new() { Simbolo = "T0", Nome = "T referência", Descricao = "T0", Unidade = "°C", ValorPadrao = 10, ValorMin = 0, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double rho0 = inputs["rho0"];
                double alpha_S = inputs["alpha_S"];
                double S = inputs["S"];
                double S0 = inputs["S0"];
                double beta_T = inputs["beta_T"];
                double T = inputs["T"];
                double T0 = inputs["T0"];
                
                return rho0 + alpha_S * (S - S0) - beta_T * (T - T0);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE171_PerfilSonarCTD()
    {
        return new Formula
        {
            Id = "V8-OCE171",
            CodigoCompendio = "171",
            Nome = "Velocidade do Som na Água do Mar — Mackenzie",
            Categoria = "Oceanografia",
            SubCategoria = "Acústica Subaquática",
            Expressao = "c = 1448.96 + 4.591*T - 0.05304*T² + 0.0002374*T³ + (1.34-0.01*T)*(S-35) + 0.016*z",
            ExprTexto = "Velocidade som",
            Descricao = "T=temp (°C), S=salinidade (PSU), z=profundidade (m). Mackenzie equation (1981).",
            Criador = "Mackenzie",
            AnoOrigin = "1981",
            ExemploPratico = "T=10°C, S=35PSU, z=1000m → c≈1506m/s. Superfície: ~1500m/s. Fundo: ~1550m/s",
            Unidades = "m/s",
            VariavelResultado = "c",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "°C", ValorPadrao = 10, ValorMin = 0, ValorMax = 30, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Salinidade", Descricao = "S", Unidade = "PSU", ValorPadrao = 35, ValorMin = 25, ValorMax = 40, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "Profundidade", Descricao = "z", Unidade = "m", ValorPadrao = 1000, ValorMin = 0, ValorMax = 11000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T = inputs["T"];
                double S = inputs["S"];
                double z = inputs["z"];
                
                return 1448.96 + 4.591 * T - 0.05304 * T * T + 0.0002374 * T * T * T
                       + (1.34 - 0.01 * T) * (S - 35)
                       + 0.016 * z;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE172_AbsorcaoAcustica()
    {
        return new Formula
        {
            Id = "V8-OCE172",
            CodigoCompendio = "172",
            Nome = "Absorção Acústica em Água do Mar — α (simplificado)",
            Categoria = "Oceanografia",
            SubCategoria = "Acústica Subaquática",
            Expressao = "α = A * f²",
            ExprTexto = "Coeficiente absorção",
            Descricao = "α=absorção (dB/km), f=frequência (kHz), A~0,03-0,1 (depende T, S, pH). Francois-Garrison mais completo.",
            Criador = "Acústica submarina",
            AnoOrigin = "~1960s",
            ExemploPratico = "f=10kHz, A=0,05 → α=5dB/km. 100kHz: α~500dB/km. Baixa freq: menor absorção",
            Unidades = "dB/km",
            VariavelResultado = "alpha",
            UnidadeResultado = "dB/km",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "Constante A", Descricao = "A", Unidade = "dB/km/kHz²", ValorPadrao = 0.05, ValorMin = 0.01, ValorMax = 0.2, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "Frequência", Descricao = "f", Unidade = "kHz", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 500, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double f = inputs["f"];
                
                return A * f * f;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE173_TransporteMarea()
    {
        return new Formula
        {
            Id = "V8-OCE173",
            CodigoCompendio = "173",
            Nome = "Transporte de Maré — M2",
            Categoria = "Oceanografia",
            SubCategoria = "Maré",
            Expressao = "U = (η * g * k) / ω",
            ExprTexto = "Velocidade maré",
            Descricao = "η=amplitude maré (m), g=9,81m/s², k=número onda (rad/m), ω=freq. angular (rad/s). M2: 12,42h.",
            Criador = "Teoria maré dinâmica",
            AnoOrigin = "~1900s",
            ExemploPratico = "η=1m, λ=100km (k≈6,28e-5), ω=1,4e-4rad/s (M2) → U≈0,44m/s. Estuário: U>1m/s",
            Unidades = "m/s",
            VariavelResultado = "U",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "eta", Nome = "Amplitude maré", Descricao = "η", Unidade = "m", ValorPadrao = 1, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Número onda", Descricao = "k", Unidade = "rad/m", ValorPadrao = 6.28e-5, ValorMin = 1e-6, ValorMax = 0.01, Obrigatoria = true },
                new() { Simbolo = "omega", Nome = "Frequência angular", Descricao = "ω", Unidade = "rad/s", ValorPadrao = 1.4e-4, ValorMin = 1e-6, ValorMax = 0.001, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double eta = inputs["eta"];
                double g = inputs["g"];
                double k = inputs["k"];
                double omega = inputs["omega"];
                
                return (eta * g * k) / omega;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE174_NumeroFroude_Densimetrico()
    {
        return new Formula
        {
            Id = "V8-OCE174",
            CodigoCompendio = "174",
            Nome = "Número de Froude Densimétrico",
            Categoria = "Oceanografia",
            SubCategoria = "Dinâmica de Correntes",
            Expressao = "Fr = U / sqrt(g' * h)",
            ExprTexto = "Froude densimétrico",
            Descricao = "U=velocidade (m/s), g'=g·Δρ/ρ (gravidade reduzida), h=profundidade (m). Correntes estratificadas.",
            Criador = "Hidráulica estratificada",
            AnoOrigin = "~1950s",
            ExemploPratico = "U=0,5m/s, g'=0,01m/s² (Δρ/ρ=0,001), h=50m → Fr≈0,7. Fr>1: supercrítico",
            Unidades = "adimensional",
            VariavelResultado = "Fr",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "U", Nome = "Velocidade", Descricao = "U", Unidade = "m/s", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "g_prime", Nome = "g'", Descricao = "Gravidade reduzida", Unidade = "m/s²", ValorPadrao = 0.01, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Profundidade", Descricao = "h", Unidade = "m", ValorPadrao = 50, ValorMin = 1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double U = inputs["U"];
                double g_prime = inputs["g_prime"];
                double h = inputs["h"];
                
                return U / Math.Sqrt(g_prime * h);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE175_RaioRossbyDeformacao()
    {
        return new Formula
        {
            Id = "V8-OCE175",
            CodigoCompendio = "175",
            Nome = "Raio de Rossby de Deformação",
            Categoria = "Oceanografia",
            SubCategoria = "Dinâmica de Correntes",
            Expressao = "Ld = sqrt(g' * h) / f",
            ExprTexto = "Raio Rossby",
            Descricao = "g'=gravidade reduzida (m/s²), h=profundidade (m), f=Coriolis (s⁻¹). Escala vórtices.",
            Criador = "Dinâmica geofísica",
            AnoOrigin = "~1950s",
            ExemploPratico = "g'=0,02m/s², h=1000m, f=1e-4s⁻¹ → Ld≈45km. Vórtices oceânicos: ~Ld. Trópicos: Ld>100km",
            Unidades = "m",
            VariavelResultado = "Ld",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "g_prime", Nome = "g'", Descricao = "Gravidade reduzida", Unidade = "m/s²", ValorPadrao = 0.02, ValorMin = 0.001, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Profundidade", Descricao = "h", Unidade = "m", ValorPadrao = 1000, ValorMin = 100, ValorMax = 5000, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "Coriolis", Descricao = "f", Unidade = "s⁻¹", ValorPadrao = 1e-4, ValorMin = 1e-6, ValorMax = 2e-4, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double g_prime = inputs["g_prime"];
                double h = inputs["h"];
                double f = inputs["f"];
                
                return Math.Sqrt(g_prime * h) / f;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE176_TransporteSverdrup()
    {
        return new Formula
        {
            Id = "V8-OCE176",
            CodigoCompendio = "176",
            Nome = "Transporte de Sverdrup",
            Categoria = "Oceanografia",
            SubCategoria = "Circulação Oceânica",
            Expressao = "V = (1 / β) * (∂τ / ∂x)",
            ExprTexto = "Transporte meridional (simplificado)",
            Descricao = "β=df/dy (gradiente Coriolis), ∂τ/∂x=curl tensão vento (Pa/m). Circulação em giros.",
            Criador = "Harald Sverdrup",
            AnoOrigin = "1947",
            ExemploPratico = "β=2e-11m⁻¹s⁻¹, ∂τ/∂x=1e-7Pa/m → V≈5Sv (1Sv=10⁶m³/s). Corrente Brasil: ~10Sv",
            Unidades = "m²/s",
            VariavelResultado = "V",
            UnidadeResultado = "m²/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "beta", Nome = "β", Descricao = "df/dy", Unidade = "m⁻¹s⁻¹", ValorPadrao = 2e-11, ValorMin = 1e-12, ValorMax = 1e-10, Obrigatoria = true },
                new() { Simbolo = "dtau_dx", Nome = "∂τ/∂x", Descricao = "Curl vento", Unidade = "Pa/m", ValorPadrao = 1e-7, ValorMin = -1e-6, ValorMax = 1e-6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double beta = inputs["beta"];
                double dtau_dx = inputs["dtau_dx"];
                
                if (Math.Abs(beta) < 1e-20) return 0;
                
                return (1 / beta) * dtau_dx;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE177_NumeroEkman()
    {
        return new Formula
        {
            Id = "V8-OCE177",
            CodigoCompendio = "177",
            Nome = "Número de Ekman",
            Categoria = "Oceanografia",
            SubCategoria = "Dinâmica de Correntes",
            Expressao = "Ek = ν / (f * h²)",
            ExprTexto = "Ekman",
            Descricao = "ν=viscosidade turbulenta (m²/s), f=Coriolis (s⁻¹), h=profundidade (m). Ek<<1: rotacional dominante.",
            Criador = "Dinâmica rotacional",
            AnoOrigin = "~1900s",
            ExemploPratico = "ν=0,01m²/s, f=1e-4s⁻¹, h=100m → Ek=1e-8. Camada Ekman superficial: ~10-100m",
            Unidades = "adimensional",
            VariavelResultado = "Ek",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "nu", Nome = "Viscosidade", Descricao = "ν", Unidade = "m²/s", ValorPadrao = 0.01, ValorMin = 0.0001, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "Coriolis", Descricao = "f", Unidade = "s⁻¹", ValorPadrao = 1e-4, ValorMin = 1e-6, ValorMax = 2e-4, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Profundidade", Descricao = "h", Unidade = "m", ValorPadrao = 100, ValorMin = 10, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double nu = inputs["nu"];
                double f = inputs["f"];
                double h = inputs["h"];
                
                return nu / (f * h * h);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE178_ProfundidadeEkman()
    {
        return new Formula
        {
            Id = "V8-OCE178",
            CodigoCompendio = "178",
            Nome = "Profundidade da Camada de Ekman",
            Categoria = "Oceanografia",
            SubCategoria = "Dinâmica de Correntes",
            Expressao = "D = sqrt(2 * ν / f)",
            ExprTexto = "Profundidade Ekman",
            Descricao = "ν=viscosidade turbulenta (m²/s), f=Coriolis (s⁻¹). Espiral Ekman: vento → corrente 45° direita (NH).",
            Criador = "Vagn Walfrid Ekman",
            AnoOrigin = "1905",
            ExemploPratico = "ν=0,01m²/s, f=1e-4s⁻¹ → D≈45m. Latitudes médias: 20-50m. Trópicos: >100m",
            Unidades = "m",
            VariavelResultado = "D",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "nu", Nome = "Viscosidade", Descricao = "ν", Unidade = "m²/s", ValorPadrao = 0.01, ValorMin = 0.001, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "Coriolis", Descricao = "f", Unidade = "s⁻¹", ValorPadrao = 1e-4, ValorMin = 1e-6, ValorMax = 2e-4, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double nu = inputs["nu"];
                double f = inputs["f"];
                
                return Math.Sqrt(2 * nu / f);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE179_PressaoHidrostaticaOceano()
    {
        return new Formula
        {
            Id = "V8-OCE179",
            CodigoCompendio = "179",
            Nome = "Pressão Hidrostática Oceânica",
            Categoria = "Oceanografia",
            SubCategoria = "Propriedades da Água",
            Expressao = "P = P_atm + ρ * g * z",
            ExprTexto = "Pressão",
            Descricao = "P_atm=101325Pa, ρ=1025kg/m³ (mar), g=9,81m/s², z=profundidade (m). ~1atm cada 10m.",
            Criador = "Hidrostática",
            AnoOrigin = "~1600s",
            ExemploPratico = "z=100m → P≈1,1MPa (11atm). Fossa Marianas (z=11000m): P≈110MPa (1100atm)",
            Unidades = "Pa",
            VariavelResultado = "P",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P_atm", Nome = "Pressão atmosférica", Descricao = "P_atm", Unidade = "Pa", ValorPadrao = 101325, ValorMin = 95000, ValorMax = 110000, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "ρ", Unidade = "kg/m³", ValorPadrao = 1025, ValorMin = 1000, ValorMax = 1030, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "Profundidade", Descricao = "z", Unidade = "m", ValorPadrao = 100, ValorMin = 0, ValorMax = 11000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P_atm = inputs["P_atm"];
                double rho = inputs["rho"];
                double g = inputs["g"];
                double z = inputs["z"];
                
                return P_atm + rho * g * z;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE180_pH_AguaMar()
    {
        return new Formula
        {
            Id = "V8-OCE180",
            CodigoCompendio = "180",
            Nome = "pH da Água do Mar — Alcalinidade (simplificado)",
            Categoria = "Oceanografia",
            SubCategoria = "Química Oceânica",
            Expressao = "pH = -log10([H+])",
            ExprTexto = "pH",
            Descricao = "[H+]=concentração íons hidrogênio (mol/L). Mar: pH~8,1. Acidificação: pH↓ (CO₂↑).",
            Criador = "Sørensen",
            AnoOrigin = "1909",
            ExemploPratico = "[H+]=7,94e-9mol/L → pH=8,1 (água mar típica). pH<7: ácido. pH>7: básico",
            Unidades = "adimensional",
            VariavelResultado = "pH",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "H_plus", Nome = "[H+]", Descricao = "Concentração H+", Unidade = "mol/L", ValorPadrao = 7.94e-9, ValorMin = 1e-14, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double H_plus = inputs["H_plus"];
                
                if (H_plus <= 0) return double.NaN;
                
                return -Math.Log10(H_plus);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE181_ClorofilaTransparencia()
    {
        return new Formula
        {
            Id = "V8-OCE181",
            CodigoCompendio = "181",
            Nome = "Profundidade de Secchi — Transparência",
            Categoria = "Oceanografia",
            SubCategoria = "Ótica Oceânica",
            Expressao = "Zs = ln(Kd) / (-Kd)",
            ExprTexto = "Profundidade Secchi (empírica)",
            Descricao = "Zs=profundidade (m), Kd=coef. atenuação difusa (m⁻¹). Disco Secchi: visibilidade água.",
            Criador = "Angelo Secchi",
            AnoOrigin = "1865",
            ExemploPratico = "Kd=0,1m⁻¹ → Zs~23m (água clara). Kd=1m⁻¹ → Zs~2,3m (turva). Oceano oligotrófico: >30m",
            Unidades = "m",
            VariavelResultado = "Zs",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Kd", Nome = "Coef. atenuação", Descricao = "Kd", Unidade = "m⁻¹", ValorPadrao = 0.1, ValorMin = 0.01, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Kd = inputs["Kd"];
                
                // Empírica: Zs ≈ 1.7/Kd (aproximação comum)
                return 1.7 / Kd;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE182_ProducaoPrimaria()
    {
        return new Formula
        {
            Id = "V8-OCE182",
            CodigoCompendio = "182",
            Nome = "Produção Primária — Taxa Fotossíntese (simplificada)",
            Categoria = "Oceanografia",
            SubCategoria = "Biogeoquímica",
            Expressao = "PP = α * I * B",
            ExprTexto = "Produção primária",
            Descricao = "α=eficiência fotossintética (mgC/mgChl/h/(W/m²)), I=irradiância (W/m²), B=biomassa clorofila (mgChl/m³).",
            Criador = "Oceanografia biológica",
            AnoOrigin = "~1960s",
            ExemploPratico = "α=0,01, I=100W/m², B=1mgChl/m³ → PP=1mgC/m³/h. Oceano: 50GtC/ano total",
            Unidades = "mgC/m³/h",
            VariavelResultado = "PP",
            UnidadeResultado = "mgC/m³/h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "alpha", Nome = "Eficiência α", Descricao = "α", Unidade = "mgC/mgChl/h/(W/m²)", ValorPadrao = 0.01, ValorMin = 0.001, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Irradiância", Descricao = "I", Unidade = "W/m²", ValorPadrao = 100, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Biomassa clorofila", Descricao = "B", Unidade = "mgChl/m³", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double alpha = inputs["alpha"];
                double I = inputs["I"];
                double B = inputs["B"];
                
                return alpha * I * B;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OCE183_FluxoCO2_ArMar()
    {
        return new Formula
        {
            Id = "V8-OCE183",
            CodigoCompendio = "183",
            Nome = "Fluxo de CO₂ Ar-Mar",
            Categoria = "Oceanografia",
            SubCategoria = "Biogeoquímica",
            Expressao = "F = k * K0 * ΔpCO2",
            ExprTexto = "Fluxo CO₂",
            Descricao = "k=velocidade transferência (m/s), K0=solubilidade CO₂ (mol/L/atm), ΔpCO2=diferença pressão parcial (atm).",
            Criador = "Química oceânica",
            AnoOrigin = "~1970s",
            ExemploPratico = "k=5e-5m/s, K0=0,034mol/L/atm, ΔpCO2=10μatm (mar-ar) → F≈1,7mmol/m²/dia. Sumidouro C oceânico",
            Unidades = "mol/m²/s",
            VariavelResultado = "F",
            UnidadeResultado = "mol/m²/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Velocidade transferência", Descricao = "k", Unidade = "m/s", ValorPadrao = 5e-5, ValorMin = 1e-6, ValorMax = 1e-3, Obrigatoria = true },
                new() { Simbolo = "K0", Nome = "Solubilidade CO₂", Descricao = "K0", Unidade = "mol/L/atm", ValorPadrao = 0.034, ValorMin = 0.02, ValorMax = 0.05, Obrigatoria = true },
                new() { Simbolo = "delta_pCO2", Nome = "ΔpCO2", Descricao = "Δp mar-ar", Unidade = "atm", ValorPadrao = 1e-5, ValorMin = -1e-3, ValorMax = 1e-3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double K0 = inputs["K0"];
                double delta_pCO2 = inputs["delta_pCO2"];
                
                return k * K0 * delta_pCO2;
            },
            Icone = "∑",
        };
    }
}
