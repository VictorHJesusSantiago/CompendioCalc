using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XVI: PSICOFÍSICA
    // Percepção sensorial, leis psicoacústicas, teoria de detecção de sinal
    // 16 fórmulas (291-306)
    // ========================================

    public static Formula V8_PSICO291_LeiWeberFechner()
    {
        return new Formula
        {
            Id = "V8-PSICO291",
            CodigoCompendio = "291",
            Nome = "Lei de Weber-Fechner — S",
            Categoria = "Psicofísica",
            SubCategoria = "Percepção Sensorial",
            Expressao = "S = k * ln(I / I₀)",
            ExprTexto = "Weber-Fechner law",
            Descricao = "S=sensação percebida, I=intensidade estímulo, I₀=limiar absoluto, k=constante. Logarítmica.",
            Criador = "Ernst Heinrich Weber (1834), Gustav Fechner (1860)",
            AnoOrigin = "1834-1860",
            ExemploPratico = "I₀=10, I=100, k=1 → S≈2,3 (percepção logarítmica). Som: dB escala logarítmica",
            Unidades = "adimensional",
            VariavelResultado = "S",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "k", Descricao = "Constante", Unidade = "", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "I", Descricao = "Intensidade estímulo", Unidade = "", ValorPadrao = 100, ValorMin = 0.001, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "I0", Nome = "I₀", Descricao = "Limiar absoluto", Unidade = "", ValorPadrao = 10, ValorMin = 0.001, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double I = inputs["I"];
                double I0 = inputs["I0"];
                
                return k * Math.Log(I / I0);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO292_LeiStevens()
    {
        return new Formula
        {
            Id = "V8-PSICO292",
            CodigoCompendio = "292",
            Nome = "Lei de Potência de Stevens — ψ",
            Categoria = "Psicofísica",
            SubCategoria = "Percepção Sensorial",
            Expressao = "ψ = k * (φ - φ₀)^β",
            ExprTexto = "Stevens' power law",
            Descricao = "ψ=magnitude percebida, φ=intensidade física, β=expoente (luz: 0,33; dor: 3,5). Stevens 1957.",
            Criador = "Stanley Smith Stevens",
            AnoOrigin = "1957",
            ExemploPratico = "β=0,5 (luminosidade), φ=100, φ₀=10, k=1 → ψ≈9,5. β>1: expansão; β<1: compressão",
            Unidades = "adimensional",
            VariavelResultado = "psi",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "k", Descricao = "Constante", Unidade = "", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "phi", Nome = "φ", Descricao = "Intensidade física", Unidade = "", ValorPadrao = 100, ValorMin = 0.001, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "phi0", Nome = "φ₀", Descricao = "Limiar absoluto", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "beta", Nome = "β", Descricao = "Expoente", Unidade = "", ValorPadrao = 0.5, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double phi = inputs["phi"];
                double phi0 = inputs["phi0"];
                double beta = inputs["beta"];
                
                return k * Math.Pow(phi - phi0, beta);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO293_FracaoWeber()
    {
        return new Formula
        {
            Id = "V8-PSICO293",
            CodigoCompendio = "293",
            Nome = "Fração de Weber — ΔI/I",
            Categoria = "Psicofísica",
            SubCategoria = "Discriminação Sensorial",
            Expressao = "ΔI / I = k (constante)",
            ExprTexto = "Weber fraction",
            Descricao = "ΔI=diferença notável (JND), I=intensidade base. k=constante Weber: visão ~2%, audição ~10%.",
            Criador = "Ernst Heinrich Weber",
            AnoOrigin = "1834",
            ExemploPratico = "I=100, k=0,02 (visão) → ΔI=2. Peso: 100g precisa +2g para perceber diferença",
            Unidades = "adimensional",
            VariavelResultado = "delta_I",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "I", Nome = "I", Descricao = "Intensidade base", Unidade = "", ValorPadrao = 100, ValorMin = 0.001, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "k", Descricao = "Constante Weber", Unidade = "", ValorPadrao = 0.02, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double I = inputs["I"];
                double k = inputs["k"];
                
                return k * I;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO294_SensibilidadeDeteccao_d_prime()
    {
        return new Formula
        {
            Id = "V8-PSICO294",
            CodigoCompendio = "294",
            Nome = "Sensibilidade d' — TDS",
            Categoria = "Psicofísica",
            SubCategoria = "Teoria Detecção Sinal",
            Expressao = "d' = Z(hit_rate) - Z(false_alarm_rate)",
            ExprTexto = "d-prime",
            Descricao = "d'=sensibilidade, Z=z-score inverso. d'>2: boa discriminação. TDS: Green & Swets 1966.",
            Criador = "David M. Green / John A. Swets",
            AnoOrigin = "1966",
            ExemploPratico = "Hit=0,8 (Z≈0,84), FA=0,2 (Z≈-0,84) → d'≈1,68. d'=0: acaso; d'>3: excelente",
            Unidades = "adimensional",
            VariavelResultado = "d_prime",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "hit_rate", Nome = "Hit rate", Descricao = "Taxa acertos", Unidade = "", ValorPadrao = 0.8, ValorMin = 0.01, ValorMax = 0.99, Obrigatoria = true },
                new() { Simbolo = "fa_rate", Nome = "False alarm", Descricao = "Taxa falsos alarmes", Unidade = "", ValorPadrao = 0.2, ValorMin = 0.01, ValorMax = 0.99, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double hit_rate = inputs["hit_rate"];
                double fa_rate = inputs["fa_rate"];
                
                // Z-score aproximação
                double Z_hit = -1.0 * Math.Sqrt(2) * ErfInv(1 - 2 * hit_rate);
                double Z_fa = -1.0 * Math.Sqrt(2) * ErfInv(1 - 2 * fa_rate);
                
                return Z_hit - Z_fa;
            },
            Icone = "∑",
        };
    }

    // Função auxiliar ErfInv para d'
    private static double ErfInv(double x)
    {
        // Aproximação de Maclaurin para erf^-1
        double a = 0.147;
        double ln_term = Math.Log(1 - x * x);
        double first_term = 2 / (Math.PI * a) + ln_term / 2;
        
        return Math.Sign(x) * Math.Sqrt(Math.Sqrt(first_term * first_term - ln_term / a) - first_term);
    }

    public static Formula V8_PSICO295_Criterio_Beta()
    {
        return new Formula
        {
            Id = "V8-PSICO295",
            CodigoCompendio = "295",
            Nome = "Critério β — TDS",
            Categoria = "Psicofísica",
            SubCategoria = "Teoria Detecção Sinal",
            Expressao = "β = f_signal(x) / f_noise(x)",
            ExprTexto = "Likelihood ratio",
            Descricao = "β=razão verossimilhança (criterião decisão). β>1: conservador; β<1: liberal. TDS.",
            Criador = "Teoria Detecção Sinal",
            AnoOrigin = "~1950s-1960s",
            ExemploPratico = "β=1: criterião neutro. β=2: conservador (evita false alarms). Medicina: β ajustado",
            Unidades = "adimensional",
            VariavelResultado = "beta",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f_signal", Nome = "f_signal", Descricao = "Densidade sinal", Unidade = "", ValorPadrao = 2, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "f_noise", Nome = "f_noise", Descricao = "Densidade ruído", Unidade = "", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f_signal = inputs["f_signal"];
                double f_noise = inputs["f_noise"];
                
                return f_signal / f_noise;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO296_LimiarAbsoluto()
    {
        return new Formula
        {
            Id = "V8-PSICO296",
            CodigoCompendio = "296",
            Nome = "Limiar Absoluto — I₀",
            Categoria = "Psicofísica",
            SubCategoria = "Limiares",
            Expressao = "P_deteccao = 0.5  (critério 50%)",
            ExprTexto = "Absolute threshold",
            Descricao = "I₀: intensidade mínima detectável 50% do tempo. Audição: 0dB SPL @ 1kHz (~20μPa).",
            Criador = "Psicofísica clássica",
            AnoOrigin = "~1860s",
            ExemploPratico = "Audição: 20μPa @ 1kHz (limiar). Visão: ~10 fótons (escotópica). Olfato: ~poucas moléculas",
            Unidades = "variável",
            VariavelResultado = "I0",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "I0", Nome = "I₀", Descricao = "Limiar absoluto", Unidade = "", ValorPadrao = 20e-6, ValorMin = 1e-12, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                return inputs["I0"];
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO297_LimiarDiferencial_JND()
    {
        return new Formula
        {
            Id = "V8-PSICO297",
            CodigoCompendio = "297",
            Nome = "Limiar Diferencial — JND",
            Categoria = "Psicofísica",
            SubCategoria = "Limiares",
            Expressao = "JND = k * I  (Weber)",
            ExprTexto = "Just Noticeable Difference",
            Descricao = "JND=menor diferença perceptível. k=constante Weber (~2% visão, ~10% audição). ΔI=JND.",
            Criador = "Ernst Heinrich Weber",
            AnoOrigin = "1834",
            ExemploPratico = "I=1000Hz (tom puro), k=0,003 (pitch) → JND≈3Hz diferença perceptível",
            Unidades = "mesma de I",
            VariavelResultado = "JND",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "I", Nome = "I", Descricao = "Intensidade base", Unidade = "", ValorPadrao = 1000, ValorMin = 0.001, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "k", Descricao = "Constante Weber", Unidade = "", ValorPadrao = 0.003, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double I = inputs["I"];
                double k = inputs["k"];
                
                return k * I;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO298_AdaptacaoSensorial()
    {
        return new Formula
        {
            Id = "V8-PSICO298",
            CodigoCompendio = "298",
            Nome = "Adaptação Sensorial — S(t)",
            Categoria = "Psicofísica",
            SubCategoria = "Adaptação",
            Expressao = "S(t) = S₀ * exp(-t / τ) + S_inf",
            ExprTexto = "Sensory adaptation",
            Descricao = "S₀=sensação inicial, S_inf=sensação adaptada, τ=constante tempo. Visão: τ~10-30min (escuro).",
            Criador = "Fisiologia sensorial",
            AnoOrigin = "~1900s",
            ExemploPratico = "S₀=100, S_inf=20, τ=5min, t=10min → S≈33,5. Adaptação escuro: sensibilidade↑1000×",
            Unidades = "adimensional",
            VariavelResultado = "S_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "S0", Nome = "S₀", Descricao = "Sensação inicial", Unidade = "", ValorPadrao = 100, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "S_inf", Nome = "S_inf", Descricao = "Sensação adaptada", Unidade = "", ValorPadrao = 20, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "tau", Nome = "τ", Descricao = "Constante tempo", Unidade = "s", ValorPadrao = 300, ValorMin = 1, ValorMax = 3600, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "s", ValorPadrao = 600, ValorMin = 0, ValorMax = 7200, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double S0 = inputs["S0"];
                double S_inf = inputs["S_inf"];
                double tau = inputs["tau"];
                double t = inputs["t"];
                
                return S0 * Math.Exp(-t / tau) + S_inf;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO299_CurvaCurvaROC_AUC()
    {
        return new Formula
        {
            Id = "V8-PSICO299",
            CodigoCompendio = "299",
            Nome = "AUC — Curva ROC (aproximação)",
            Categoria = "Psicofísica",
            SubCategoria = "Teoria Detecção Sinal",
            Expressao = "AUC ≈ Φ(d' / √2)",
            ExprTexto = "Area Under Curve",
            Descricao = "AUC=área sob curva ROC (0,5=acaso, 1=perfeito). d'=sensibilidade. Φ=cdf normal.",
            Criador = "TDS / estatística",
            AnoOrigin = "~1960s",
            ExemploPratico = "d'=1 → AUC≈0,76. d'=2 → AUC≈0,92. d'=3 → AUC≈0,98. Medicina: diagnóstico",
            Unidades = "adimensional",
            VariavelResultado = "AUC",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "d_prime", Nome = "d'", Descricao = "Sensibilidade", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double d_prime = inputs["d_prime"];
                
                // AUC ≈ Phi(d'/sqrt(2))
                double z = d_prime / Math.Sqrt(2);
                
                // CDF normal padrão aproximada
                double Phi = 0.5 * (1 + Erf(z / Math.Sqrt(2)));
                
                return Phi;
            },
            Icone = "∑",
        };
    }

    // Função auxiliar Erf
    private static double Erf(double x)
    {
        // Aproximação de Abramowitz & Stegun
        double a1 =  0.254829592;
        double a2 = -0.284496736;
        double a3 =  1.421413741;
        double a4 = -1.453152027;
        double a5 =  1.061405429;
        double p  =  0.3275911;

        int sign = x < 0 ? -1 : 1;
        x = Math.Abs(x);

        double t = 1.0 / (1.0 + p * x);
        double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

        return sign * y;
    }

    public static Formula V8_PSICO300_EscalaMagnitudeDireta()
    {
        return new Formula
        {
            Id = "V8-PSICO300",
            CodigoCompendio = "300",
            Nome = "Escala de Magnitude Direta — Stevens",
            Categoria = "Psicofísica",
            SubCategoria = "Métodos Psicofísicos",
            Expressao = "M = k * φ^β",
            ExprTexto = "Magnitude estimation",
            Descricao = "M=magnitude percebida (relato direto), φ=intensidade física, β=expoente. Stevens 1957.",
            Criador = "Stanley Smith Stevens",
            AnoOrigin = "1957",
            ExemploPratico = "β=3,5 (choque elétrico), φ=2×base → M cresce 8× (~compressão subjetiva invertida)",
            Unidades = "adimensional",
            VariavelResultado = "M",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "k", Descricao = "Constante", Unidade = "", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "phi", Nome = "φ", Descricao = "Intensidade física", Unidade = "", ValorPadrao = 10, ValorMin = 0.001, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "beta", Nome = "β", Descricao = "Expoente", Unidade = "", ValorPadrao = 1, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double phi = inputs["phi"];
                double beta = inputs["beta"];
                
                return k * Math.Pow(phi, beta);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO301_SensibilidadeContraste()
    {
        return new Formula
        {
            Id = "V8-PSICO301",
            CodigoCompendio = "301",
            Nome = "Sensibilidade ao Contraste — CS",
            Categoria = "Psicofísica",
            SubCategoria = "Visão",
            Expressao = "CS = 1 / C_threshold",
            ExprTexto = "Contrast sensitivity",
            Descricao = "C_threshold=contraste limiar Michelson=(L_max-L_min)/(L_max+L_min). CS↑: melhor visão.",
            Criador = "Visão psicofísica",
            AnoOrigin = "~1960s-1970s",
            ExemploPratico = "C_threshold=0,01 (1%) → CS=100. Função CSF: pico ~3-5 cpd (ciclos/grau)",
            Unidades = "adimensional",
            VariavelResultado = "CS",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C_threshold", Nome = "C_threshold", Descricao = "Contraste limiar", Unidade = "", ValorPadrao = 0.01, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C_threshold = inputs["C_threshold"];
                
                return 1.0 / C_threshold;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO302_TempoReacao_Hick()
    {
        return new Formula
        {
            Id = "V8-PSICO302",
            CodigoCompendio = "302",
            Nome = "Tempo de Reação — Lei de Hick",
            Categoria = "Psicofísica",
            SubCategoria = "Tempo de Resposta",
            Expressao = "RT = a + b * log₂(n)",
            ExprTexto = "Hick's law",
            Descricao = "RT=tempo reação, n=número escolhas, a=base, b=coef. (típico ~150ms/bit). Hick 1952.",
            Criador = "William Edmund Hick",
            AnoOrigin = "1952",
            ExemploPratico = "a=200ms, b=150ms/bit, n=4 → RT≈500ms. n=16 (4 bits) → RT≈800ms. IHC design",
            Unidades = "ms",
            VariavelResultado = "RT",
            UnidadeResultado = "ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "a", Descricao = "Tempo base", Unidade = "ms", ValorPadrao = 200, ValorMin = 50, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "b", Descricao = "Coeficiente", Unidade = "ms/bit", ValorPadrao = 150, ValorMin = 10, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "n", Descricao = "Número escolhas", Unidade = "", ValorPadrao = 4, ValorMin = 1, ValorMax = 256, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double n = inputs["n"];
                
                return a + b * Math.Log2(n);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO303_LeiFitts()
    {
        return new Formula
        {
            Id = "V8-PSICO303",
            CodigoCompendio = "303",
            Nome = "Lei de Fitts — Tempo de Movimento",
            Categoria = "Psicofísica",
            SubCategoria = "Controle Motor",
            Expressao = "MT = a + b * log₂(D/W + 1)",
            ExprTexto = "Fitts' law",
            Descricao = "MT=tempo movimento, D=distância, W=largura alvo. ID=log₂(D/W+1): índice dificuldade. Fitts 1954.",
            Criador = "Paul Fitts",
            AnoOrigin = "1954",
            ExemploPratico = "a=200ms, b=100ms/bit, D=100mm, W=10mm → ID≈3,46, MT≈546ms. IHC: botões grandes",
            Unidades = "ms",
            VariavelResultado = "MT",
            UnidadeResultado = "ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "a", Descricao = "Tempo base", Unidade = "ms", ValorPadrao = 200, ValorMin = 50, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "b", Descricao = "Coeficiente", Unidade = "ms/bit", ValorPadrao = 100, ValorMin = 10, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "D", Nome = "D", Descricao = "Distância", Unidade = "mm", ValorPadrao = 100, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "W", Nome = "W", Descricao = "Largura alvo", Unidade = "mm", ValorPadrao = 10, ValorMin = 1, ValorMax = 500, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double D = inputs["D"];
                double W = inputs["W"];
                
                double ID = Math.Log2(D / W + 1);
                
                return a + b * ID;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO304_LeiSterling()
    {
        return new Formula
        {
            Id = "V8-PSICO304",
            CodigoCompendio = "304",
            Nome = "Lei de Sternberg — Busca na Memória",
            Categoria = "Psicofísica",
            SubCategoria = "Memória",
            Expressao = "RT = a + b * n",
            ExprTexto = "Sternberg's memory scanning",
            Descricao = "RT=tempo, n=itens memorizado. b~38ms/item (busca serial exaustiva). Sternberg 1966.",
            Criador = "Saul Sternberg",
            AnoOrigin = "1966",
            ExemploPratico = "a=400ms, b=38ms/item, n=5 → RT≈590ms. Busca serial: slope constante",
            Unidades = "ms",
            VariavelResultado = "RT",
            UnidadeResultado = "ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "a", Descricao = "Tempo base", Unidade = "ms", ValorPadrao = 400, ValorMin = 100, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "b", Descricao = "Coeficiente", Unidade = "ms/item", ValorPadrao = 38, ValorMin = 10, ValorMax = 200, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "n", Descricao = "Itens memória", Unidade = "", ValorPadrao = 5, ValorMin = 0, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double n = inputs["n"];
                
                return a + b * n;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO305_MemoriaCapacidadeMiller()
    {
        return new Formula
        {
            Id = "V8-PSICO305",
            CodigoCompendio = "305",
            Nome = "Capacidade Memória — 7±2 Miller",
            Categoria = "Psicofísica",
            SubCategoria = "Memória",
            Expressao = "M_capacity ≈ 7 ± 2  (chunks)",
            ExprTexto = "Miller's magical number",
            Descricao = "Capacidade memória curto prazo: ~7 chunks (±2). George Miller 1956. Chunking: agrupamento.",
            Criador = "George A. Miller",
            AnoOrigin = "1956",
            ExemploPratico = "7 dígitos telefone: dentro capacidade. Chunking: 5551234 = (555)(1234) 2 chunks",
            Unidades = "chunks",
            VariavelResultado = "capacity",
            UnidadeResultado = "chunks",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "capacity", Nome = "Capacidade", Descricao = "Chunks memorizado", Unidade = "chunks", ValorPadrao = 7, ValorMin = 5, ValorMax = 9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                return inputs["capacity"];
            },
            Icone = "∑",
        };
    }

    public static Formula V8_PSICO306_CurvaPsicometrica()
    {
        return new Formula
        {
            Id = "V8-PSICO306",
            CodigoCompendio = "306",
            Nome = "Curva Psicométrica — ψ(x)",
            Categoria = "Psicofísica",
            SubCategoria = "Métodos Psicofísicos",
            Expressao = "ψ(x) = γ + (1 - γ - λ) * Φ((x - α) / β)",
            ExprTexto = "Psychometric function",
            Descricao = "γ=chance, λ=lapse, α=limiar (PSE), β=slope, Φ=cdf normal. Modela P(detecção|x).",
            Criador = "Psicofísica clássica / estatística",
            AnoOrigin = "~1880s-1900s",
            ExemploPratico = "2AFC: γ=0,5 (chance). α=10 (PSE), β=2 (slope), λ=0,02 (lapse) → curva sigmoidal",
            Unidades = "adimensional",
            VariavelResultado = "psi",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "x", Descricao = "Intensidade estímulo", Unidade = "", ValorPadrao = 10, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "alpha", Nome = "α", Descricao = "Limiar/PSE", Unidade = "", ValorPadrao = 10, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "beta", Nome = "β", Descricao = "Slope", Unidade = "", ValorPadrao = 2, ValorMin = 0.1, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "gamma", Nome = "γ", Descricao = "Chance level", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Lapse rate", Unidade = "", ValorPadrao = 0.02, ValorMin = 0, ValorMax = 0.5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double alpha = inputs["alpha"];
                double beta = inputs["beta"];
                double gamma = inputs["gamma"];
                double lambda = inputs["lambda"];
                
                double z = (x - alpha) / beta;
                double Phi = 0.5 * (1 + Erf(z / Math.Sqrt(2)));
                
                return gamma + (1 - gamma - lambda) * Phi;
            },
            Icone = "∑",
        };
    }
}
