using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XV: ÓPTICA AVANÇADA
    // Raios gaussianos, fibras ópticas, óptica não-linear, interferometria
    // 16 fórmulas (275-290)
    // ========================================

    public static Formula V8_OPTICA275_RayleighRange()
    {
        return new Formula
        {
            Id = "V8-OPTICA275",
            CodigoCompendio = "275",
            Nome = "Distância de Rayleigh — z_R",
            Categoria = "Óptica Avançada",
            SubCategoria = "Raios Gaussianos",
            Expressao = "z_R = π * w₀² / λ",
            ExprTexto = "Rayleigh range",
            Descricao = "w₀=cintura raio (beam waist), λ=comprimento onda. z_R: distância onde w(z)=√2·w₀. Lord Rayleigh.",
            Criador = "John William Strutt (Lord Rayleigh)",
            AnoOrigin = "~1881",
            ExemploPratico = "w₀=100μm, λ=632,8nm (HeNe) → z_R≈49,7mm. Lasers: feixe colimado sobre 2·z_R",
            Unidades = "m",
            VariavelResultado = "z_R",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "w0", Nome = "w₀", Descricao = "Cintura raio", Unidade = "m", ValorPadrao = 100e-6, ValorMin = 1e-9, ValorMax = 0.01, Obrigatoria = true },
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento onda", Unidade = "m", ValorPadrao = 632.8e-9, ValorMin = 100e-9, ValorMax = 100e-6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double w0 = inputs["w0"];
                double lambda = inputs["lambda"];
                
                return Math.PI * w0 * w0 / lambda;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA276_RaioGaussiano_Propagacao()
    {
        return new Formula
        {
            Id = "V8-OPTICA276",
            CodigoCompendio = "276",
            Nome = "Raio Gaussiano — Propagação w(z)",
            Categoria = "Óptica Avançada",
            SubCategoria = "Raios Gaussianos",
            Expressao = "w(z) = w₀ * sqrt(1 + (z/z_R)²)",
            ExprTexto = "Gaussian beam radius",
            Descricao = "w₀=cintura, z_R=distância Rayleigh. w(z)=raio do feixe em z. Hipérbole: expande distante w₀.",
            Criador = "Óptica gaussiana",
            AnoOrigin = "~1960s",
            ExemploPratico = "w₀=100μm, z_R=50mm, z=50mm → w(50mm)≈141μm (√2·w₀). z=100mm: w≈224μm",
            Unidades = "m",
            VariavelResultado = "w_z",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "w0", Nome = "w₀", Descricao = "Cintura raio", Unidade = "m", ValorPadrao = 100e-6, ValorMin = 1e-9, ValorMax = 0.01, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "z", Descricao = "Distância", Unidade = "m", ValorPadrao = 0.05, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "z_R", Nome = "z_R", Descricao = "Dist. Rayleigh", Unidade = "m", ValorPadrao = 0.05, ValorMin = 1e-6, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double w0 = inputs["w0"];
                double z = inputs["z"];
                double z_R = inputs["z_R"];
                
                return w0 * Math.Sqrt(1 + (z / z_R) * (z / z_R));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA277_Divergencia_FeixeGaussiano()
    {
        return new Formula
        {
            Id = "V8-OPTICA277",
            CodigoCompendio = "277",
            Nome = "Divergência Feixe Gaussiano — θ",
            Categoria = "Óptica Avançada",
            SubCategoria = "Raios Gaussianos",
            Expressao = "θ = λ / (π * w₀)",
            ExprTexto = "Beam divergence",
            Descricao = "θ=ângulo divergência (rad), w₀=cintura, λ=comprimento onda. Semi-ângulo cone distante.",
            Criador = "Óptica gaussiana",
            AnoOrigin = "~1960s",
            ExemploPratico = "w₀=1mm, λ=1μm → θ≈0,318mrad≈0,018°. w₀ pequeno: divergência alta (difração)",
            Unidades = "rad",
            VariavelResultado = "theta",
            UnidadeResultado = "rad",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento onda", Unidade = "m", ValorPadrao = 1e-6, ValorMin = 100e-9, ValorMax = 100e-6, Obrigatoria = true },
                new() { Simbolo = "w0", Nome = "w₀", Descricao = "Cintura raio", Unidade = "m", ValorPadrao = 1e-3, ValorMin = 1e-9, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                double w0 = inputs["w0"];
                
                return lambda / (Math.PI * w0);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA278_NumeroV_FibraOptica()
    {
        return new Formula
        {
            Id = "V8-OPTICA278",
            CodigoCompendio = "278",
            Nome = "Número V — Fibra Óptica",
            Categoria = "Óptica Avançada",
            SubCategoria = "Fibras Ópticas",
            Expressao = "V = (2π * a / λ) * NA",
            ExprTexto = "V-number",
            Descricao = "a=raio núcleo, λ=comprimento onda, NA=abertura numérica. V<2,405: monomodo. V>2,405: multimodo.",
            Criador = "Teoria fibras ópticas",
            AnoOrigin = "~1970s",
            ExemploPratico = "a=4,5μm, λ=1,55μm, NA=0,12 → V≈2,19 (monomodo). a=25μm: V≈12 (multimodo ~100 modos)",
            Unidades = "adimensional",
            VariavelResultado = "V",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "a", Descricao = "Raio núcleo", Unidade = "m", ValorPadrao = 4.5e-6, ValorMin = 1e-9, ValorMax = 1e-3, Obrigatoria = true },
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento onda", Unidade = "m", ValorPadrao = 1.55e-6, ValorMin = 500e-9, ValorMax = 10e-6, Obrigatoria = true },
                new() { Simbolo = "NA", Nome = "NA", Descricao = "Abertura numérica", Unidade = "", ValorPadrao = 0.12, ValorMin = 0.01, ValorMax = 0.5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double lambda = inputs["lambda"];
                double NA = inputs["NA"];
                
                return (2 * Math.PI * a / lambda) * NA;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA279_AberturaNumerica_NA()
    {
        return new Formula
        {
            Id = "V8-OPTICA279",
            CodigoCompendio = "279",
            Nome = "Abertura Numérica — NA",
            Categoria = "Óptica Avançada",
            SubCategoria = "Fibras Ópticas",
            Expressao = "NA = sqrt(n₁² - n₂²)",
            ExprTexto = "Numerical aperture",
            Descricao = "n₁=índice núcleo, n₂=índice casca. NA=sen(θ_max): ângulo aceitação. NA↑ → mais luz capturada.",
            Criador = "Óptica geométrica / Ernst Abbe",
            AnoOrigin = "~1870s",
            ExemploPratico = "n₁=1,48 (núcleo), n₂=1,46 (casca) → NA≈0,242. θ_max=arcsin(0,242)≈14°",
            Unidades = "adimensional",
            VariavelResultado = "NA",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n1", Nome = "n₁", Descricao = "Índice núcleo", Unidade = "", ValorPadrao = 1.48, ValorMin = 1, ValorMax = 4, Obrigatoria = true },
                new() { Simbolo = "n2", Nome = "n₂", Descricao = "Índice casca", Unidade = "", ValorPadrao = 1.46, ValorMin = 1, ValorMax = 4, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n1 = inputs["n1"];
                double n2 = inputs["n2"];
                
                return Math.Sqrt(n1 * n1 - n2 * n2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA280_AtenuacaoFibra()
    {
        return new Formula
        {
            Id = "V8-OPTICA280",
            CodigoCompendio = "280",
            Nome = "Atenuação Fibra Óptica — α (dB/km)",
            Categoria = "Óptica Avançada",
            SubCategoria = "Fibras Ópticas",
            Expressao = "P_out = P_in * 10^(-α*L/10)",
            ExprTexto = "Fiber attenuation",
            Descricao = "α=atenuação (dB/km), L=comprimento (km). 1550nm: α≈0,2dB/km. 1310nm: α≈0,35dB/km.",
            Criador = "Telecomunicações ópticas",
            AnoOrigin = "~1970s",
            ExemploPratico = "P_in=1mW, α=0,2dB/km, L=100km → P_out≈0,01mW (20dB perda total). Amplificadores EDFA",
            Unidades = "mW",
            VariavelResultado = "P_out",
            UnidadeResultado = "mW",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P_in", Nome = "P_in", Descricao = "Potência entrada", Unidade = "mW", ValorPadrao = 1, ValorMin = 1e-6, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "alpha", Nome = "α", Descricao = "Atenuação", Unidade = "dB/km", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "L", Descricao = "Comprimento", Unidade = "km", ValorPadrao = 100, ValorMin = 0, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P_in = inputs["P_in"];
                double alpha = inputs["alpha"];
                double L = inputs["L"];
                
                return P_in * Math.Pow(10, -alpha * L / 10);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA281_DispersaoCromatica()
    {
        return new Formula
        {
            Id = "V8-OPTICA281",
            CodigoCompendio = "281",
            Nome = "Dispersão Cromática — D (ps/(nm·km))",
            Categoria = "Óptica Avançada",
            SubCategoria = "Fibras Ópticas",
            Expressao = "Δτ = D * Δλ * L",
            ExprTexto = "Chromatic dispersion",
            Descricao = "Δτ=alargamento pulso, Δλ=largura espectral, L=comprimento. 1550nm: D≈17ps/(nm·km).",
            Criador = "Óptica de fibras",
            AnoOrigin = "~1970s",
            ExemploPratico = "D=17ps/(nm·km), Δλ=1nm (laser), L=100km → Δτ=1,7ns (alargamento temporal)",
            Unidades = "ps",
            VariavelResultado = "delta_tau",
            UnidadeResultado = "ps",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "D", Nome = "D", Descricao = "Dispersão", Unidade = "ps/(nm·km)", ValorPadrao = 17, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "delta_lambda", Nome = "Δλ", Descricao = "Largura espectral", Unidade = "nm", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "L", Descricao = "Comprimento", Unidade = "km", ValorPadrao = 100, ValorMin = 0, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double D = inputs["D"];
                double delta_lambda = inputs["delta_lambda"];
                double L = inputs["L"];
                
                return D * delta_lambda * L;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA282_SusceptibilidadeNaoLinear_Chi2()
    {
        return new Formula
        {
            Id = "V8-OPTICA282",
            CodigoCompendio = "282",
            Nome = "Polarização Não-Linear — χ⁽²⁾ (SHG)",
            Categoria = "Óptica Avançada",
            SubCategoria = "Óptica Não-Linear",
            Expressao = "P_NL = ε₀ * χ⁽²⁾ * E²",
            ExprTexto = "χ⁽²⁾ SHG",
            Descricao = "χ⁽²⁾=susceptibilidade 2ª ordem (pm/V típico), E=campo elétrico. SHG: ω→2ω (dobrar frequência).",
            Criador = "Peter Franken (primeiro SHG observado)",
            AnoOrigin = "1961",
            ExemploPratico = "1064nm (Nd:YAG) + BBO crystal → 532nm (verde). χ⁽²⁾~2pm/V. Aplicação: lasers verdes",
            Unidades = "C/m^2",
            VariavelResultado = "P_NL",
            UnidadeResultado = "C/m^2",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "chi2", Nome = "χ⁽²⁾", Descricao = "Susceptibilidade", Unidade = "pm/V", ValorPadrao = 2, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "E", Nome = "E", Descricao = "Campo elétrico", Unidade = "V/m", ValorPadrao = 1e7, ValorMin = 1e3, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double chi2_pm_per_V = inputs["chi2"];
                double E = inputs["E"];
                
                double chi2 = chi2_pm_per_V * 1e-12; // pm/V → m/V
                double epsilon_0 = 8.854e-12;
                
                return epsilon_0 * chi2 * E * E;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA283_EfeitoKerr_IndiceRefracaoNL()
    {
        return new Formula
        {
            Id = "V8-OPTICA283",
            CodigoCompendio = "283",
            Nome = "Efeito Kerr Óptico — n(I)",
            Categoria = "Óptica Avançada",
            SubCategoria = "Óptica Não-Linear",
            Expressao = "n(I) = n₀ + n₂ * I",
            ExprTexto = "Kerr effect",
            Descricao = "n₀=índice linear, n₂=coef. não-linear (m²/W), I=intensidade. Self-focusing, solitons. Kerr 1875.",
            Criador = "John Kerr (efeito eletro-óptico 1875, óptico: ~1960s)",
            AnoOrigin = "1875 (eletro), ~1964 (óptico)",
            ExemploPratico = "Sílica: n₂≈2,6×10^-20 m²/W. I=10GW/cm²→Δn≈2,6×10^-6. Fibras: solitons temporais",
            Unidades = "adimensional",
            VariavelResultado = "n_I",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n0", Nome = "n₀", Descricao = "Índice linear", Unidade = "", ValorPadrao = 1.45, ValorMin = 1, ValorMax = 4, Obrigatoria = true },
                new() { Simbolo = "n2", Nome = "n₂", Descricao = "Coef. não-linear", Unidade = "m²/W", ValorPadrao = 2.6e-20, ValorMin = 0, ValorMax = 1e-18, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "I", Descricao = "Intensidade", Unidade = "W/m²", ValorPadrao = 1e13, ValorMin = 1, ValorMax = 1e20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n0 = inputs["n0"];
                double n2 = inputs["n2"];
                double I = inputs["I"];
                
                return n0 + n2 * I;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA284_ComprimentoCoerencia()
    {
        return new Formula
        {
            Id = "V8-OPTICA284",
            CodigoCompendio = "284",
            Nome = "Comprimento de Coerência — L_c",
            Categoria = "Óptica Avançada",
            SubCategoria = "Coerência",
            Expressao = "L_c = c * τ_c = λ² / Δλ",
            ExprTexto = "Coherence length",
            Descricao = "τ_c=tempo coerência, Δλ=largura espectral. L_c↑: laser coerente. Interferometria precisa.",
            Criador = "Teoria coerência óptica",
            AnoOrigin = "~1950s",
            ExemploPratico = "λ=632,8nm, Δλ=0,002nm (HeNe) → L_c≈20cm. LED: L_c~μm. Interferometria: requer L_c",
            Unidades = "m",
            VariavelResultado = "L_c",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento onda", Unidade = "m", ValorPadrao = 632.8e-9, ValorMin = 100e-9, ValorMax = 10e-6, Obrigatoria = true },
                new() { Simbolo = "delta_lambda", Nome = "Δλ", Descricao = "Largura espectral", Unidade = "m", ValorPadrao = 2e-12, ValorMin = 1e-15, ValorMax = 1e-6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                double delta_lambda = inputs["delta_lambda"];
                
                return lambda * lambda / delta_lambda;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA285_VisibilidadeFranjas()
    {
        return new Formula
        {
            Id = "V8-OPTICA285",
            CodigoCompendio = "285",
            Nome = "Visibilidade de Franjas — V",
            Categoria = "Óptica Avançada",
            SubCategoria = "Interferometria",
            Expressao = "V = (I_max - I_min) / (I_max + I_min)",
            ExprTexto = "Fringe visibility",
            Descricao = "I_max,I_min=intensidades máxima/mínima. V=1: franjas perfeitas. V=0: sem contraste. Michelson.",
            Criador = "Albert Michelson",
            AnoOrigin = "~1880s",
            ExemploPratico = "I_max=100, I_min=10 → V≈0,818 (bom contraste). V>0,5: coerência suficiente",
            Unidades = "adimensional",
            VariavelResultado = "V",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "I_max", Nome = "I_max", Descricao = "Intensidade máxima", Unidade = "", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "I_min", Nome = "I_min", Descricao = "Intensidade mínima", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double I_max = inputs["I_max"];
                double I_min = inputs["I_min"];
                
                return (I_max - I_min) / (I_max + I_min);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA286_LimiteDifracaoRayleigh()
    {
        return new Formula
        {
            Id = "V8-OPTICA286",
            CodigoCompendio = "286",
            Nome = "Limite de Difração Rayleigh — Resolução Angular",
            Categoria = "Óptica Avançada",
            SubCategoria = "Difração e Resolução",
            Expressao = "θ_min = 1.22 * λ / D",
            ExprTexto = "Rayleigh criterion",
            Descricao = "θ_min=resolução angular (rad), D=diâmetro abertura, λ=comprimento onda. Telescópios, microscópios.",
            Criador = "Lord Rayleigh",
            AnoOrigin = "1879",
            ExemploPratico = "D=1m (telescópio), λ=550nm → θ_min≈0,67μrad≈0,14 arcsec. Hubble: D=2,4m",
            Unidades = "rad",
            VariavelResultado = "theta_min",
            UnidadeResultado = "rad",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento onda", Unidade = "m", ValorPadrao = 550e-9, ValorMin = 100e-9, ValorMax = 10e-6, Obrigatoria = true },
                new() { Simbolo = "D", Nome = "D", Descricao = "Diâmetro abertura", Unidade = "m", ValorPadrao = 1, ValorMin = 1e-6, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                double D = inputs["D"];
                
                return 1.22 * lambda / D;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA287_RazaoStrehl()
    {
        return new Formula
        {
            Id = "V8-OPTICA287",
            CodigoCompendio = "287",
            Nome = "Razão de Strehl — SR",
            Categoria = "Óptica Avançada",
            SubCategoria = "Qualidade Óptica",
            Expressao = "SR = exp(-(2π * σ / λ)²)",
            ExprTexto = "Strehl ratio",
            Descricao = "σ=RMS erro frente de onda, λ=comprimento onda. SR>0,8: diffraction-limited. Karl Strehl 1902.",
            Criador = "Karl Strehl",
            AnoOrigin = "1902",
            ExemploPratico = "λ=500nm, σ=λ/14≈36nm → SR≈0,8 (Rayleigh λ/4 criterion). Óptica adaptativa: SR~0,6-0,9",
            Unidades = "adimensional",
            VariavelResultado = "SR",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sigma", Nome = "σ", Descricao = "RMS erro", Unidade = "m", ValorPadrao = 36e-9, ValorMin = 0, ValorMax = 10e-6, Obrigatoria = true },
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento onda", Unidade = "m", ValorPadrao = 500e-9, ValorMin = 100e-9, ValorMax = 10e-6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sigma = inputs["sigma"];
                double lambda = inputs["lambda"];
                
                double phase_error = 2 * Math.PI * sigma / lambda;
                
                return Math.Exp(-phase_error * phase_error);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA288_ParametroQ_CavidadeLaser()
    {
        return new Formula
        {
            Id = "V8-OPTICA288",
            CodigoCompendio = "288",
            Nome = "Parâmetro Q — Cavidade Laser",
            Categoria = "Óptica Avançada",
            SubCategoria = "Lasers",
            Expressao = "Q = 2π * ν * (energia armazenada) / (potência dissipada)",
            ExprTexto = "Q factor (simplificado: Q≈ν/Δν)",
            Descricao = "ν=frequência ressonância, Δν=largura linha. Q alto: cavidade mais seletiva. Q-switching.",
            Criador = "Engenharia de ressoadores",
            AnoOrigin = "~1960s",
            ExemploPratico = "ν=5×10^14 Hz (600nm), Δν=1GHz → Q≈5×10^5. Cavidades estáveis: Q~10^6-10^9",
            Unidades = "adimensional",
            VariavelResultado = "Q",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "nu", Nome = "ν", Descricao = "Frequência", Unidade = "Hz", ValorPadrao = 5e14, ValorMin = 1e12, ValorMax = 1e16, Obrigatoria = true },
                new() { Simbolo = "delta_nu", Nome = "Δν", Descricao = "Largura linha", Unidade = "Hz", ValorPadrao = 1e9, ValorMin = 1e3, ValorMax = 1e12, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double nu = inputs["nu"];
                double delta_nu = inputs["delta_nu"];
                
                return nu / delta_nu;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA289_FrequenciaModosLongitudinais()
    {
        return new Formula
        {
            Id = "V8-OPTICA289",
            CodigoCompendio = "289",
            Nome = "Espaçamento Modos Longitudinais — Δν",
            Categoria = "Óptica Avançada",
            SubCategoria = "Lasers",
            Expressao = "Δν = c / (2 * L * n)",
            ExprTexto = "FSR (Free Spectral Range)",
            Descricao = "L=comprimento cavidade, n=índice refração. Δν=separação entre modos sucessivos. FSR.",
            Criador = "Teoria de cavidades ópticas",
            AnoOrigin = "~1960s",
            ExemploPratico = "L=1m, n=1 → Δν=150MHz. L=30cm (HeNe) → Δν=500MHz. Modos: q=1,2,3,...",
            Unidades = "Hz",
            VariavelResultado = "delta_nu",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L", Nome = "L", Descricao = "Comprimento cavidade", Unidade = "m", ValorPadrao = 1, ValorMin = 1e-6, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "n", Descricao = "Índice refração", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 4, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L = inputs["L"];
                double n = inputs["n"];
                
                double c = 299792458; // m/s
                
                return c / (2 * L * n);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_OPTICA290_DensidadePotenciaFeixe()
    {
        return new Formula
        {
            Id = "V8-OPTICA290",
            CodigoCompendio = "290",
            Nome = "Densidade de Potência — I (feixe gaussiano)",
            Categoria = "Óptica Avançada",
            SubCategoria = "Raios Gaussianos",
            Expressao = "I(r) = I₀ * exp(-2 * r² / w²)",
            ExprTexto = "Gaussian intensity",
            Descricao = "I₀=intensidade pico (r=0), r=raio, w=raio feixe. Perfil gaussiano: I cai para I₀/e² em r=w.",
            Criador = "Óptica gaussiana",
            AnoOrigin = "~1960s",
            ExemploPratico = "I₀=1kW/cm², w=1mm, r=1mm → I≈135W/cm² (≈13,5%). Lasers: perfil TEM00",
            Unidades = "W/m^2",
            VariavelResultado = "I_r",
            UnidadeResultado = "W/m^2",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "I0", Nome = "I₀", Descricao = "Intensidade pico", Unidade = "W/m^2", ValorPadrao = 1e7, ValorMin = 1, ValorMax = 1e20, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "r", Descricao = "Raio posição", Unidade = "m", ValorPadrao = 1e-3, ValorMin = 0, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "w", Nome = "w", Descricao = "Raio feixe", Unidade = "m", ValorPadrao = 1e-3, ValorMin = 1e-9, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double I0 = inputs["I0"];
                double r = inputs["r"];
                double w = inputs["w"];
                
                return I0 * Math.Exp(-2 * r * r / (w * w));
            },
            Icone = "∑",
        };
    }
}
