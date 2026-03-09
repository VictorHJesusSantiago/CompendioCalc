using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XVIII: ACÚSTICA MUSICAL
    // Razões de frequência, série harmônica, vibração cordas/tubos, reverberação
    // 19 fórmulas (323-341)
    // ========================================

    public static Formula V8_MUS323_RazaoFrequenciaOitava()
    {
        return new Formula
        {
            Id = "V8-MUS323",
            CodigoCompendio = "323",
            Nome = "Razão de Oitava — 2:1",
            Categoria = "Acústica Musical",
            SubCategoria = "Intervalos Musicais",
            Expressao = "f₂ = 2 * f₁",
            ExprTexto = "Octave ratio",
            Descricao = "Oitava: f₂=2·f₁. A4=440Hz → A5=880Hz. Universal: percepção logarítmica. Pitágoras ~500 a.C.",
            Criador = "Pitágoras / escola pitagórica",
            AnoOrigin = "~500 a.C.",
            ExemploPratico = "f₁=440Hz (A4) → f₂=880Hz (A5). C4=261,6Hz → C5=523,2Hz (dobrar frequência)",
            Unidades = "Hz",
            VariavelResultado = "f2",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f1", Nome = "f₁", Descricao = "Frequência base", Unidade = "Hz", ValorPadrao = 440, ValorMin = 20, ValorMax = 20000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                return 2 * inputs["f1"];
            }
        };
    }

    public static Formula V8_MUS324_RazaoQuintaJusta()
    {
        return new Formula
        {
            Id = "V8-MUS324",
            CodigoCompendio = "324",
            Nome = "Razão de Quinta Justa — 3:2",
            Categoria = "Acústica Musical",
            SubCategoria = "Intervalos Musicais",
            Expressao = "f₂ = (3/2) * f₁",
            ExprTexto = "Perfect fifth ratio",
            Descricao = "Quinta justa: 3:2 (afinação justa). C→G. Harmônico 3/2. Pitágoras.",
            Criador = "Pitágoras",
            AnoOrigin = "~500 a.C.",
            ExemploPratico = "C4=261,6Hz → G4=392,4Hz (3/2×261,6). Violino: quintas perfeitas entre cordas",
            Unidades = "Hz",
            VariavelResultado = "f2",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f1", Nome = "f₁", Descricao = "Frequência base", Unidade = "Hz", ValorPadrao = 261.6, ValorMin = 20, ValorMax = 20000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                return (3.0 / 2.0) * inputs["f1"];
            }
        };
    }

    public static Formula V8_MUS325_TemperamentoIgual()
    {
        return new Formula
        {
            Id = "V8-MUS325",
            CodigoCompendio = "325",
            Nome = "Temperamento Igual — Semitom",
            Categoria = "Acústica Musical",
            SubCategoria = "Afinação",
            Expressao = "f_n = f₀ * 2^(n/12)",
            ExprTexto = "Equal temperament",
            Descricao = "n=semitons acima f₀. 12 semitons=oitava. 2^(1/12)≈1,0595. J.S. Bach (consolidação ~1722).",
            Criador = "Zhu Zaiyu (~1584) / consolidação Bach (1722)",
            AnoOrigin = "1584 (teoria), ~1722 (prática)",
            ExemploPratico = "A4=440Hz, n=3 (C5) → f≈523,25Hz. n=12 (A5)=880Hz. Piano moderno: 12-TET",
            Unidades = "Hz",
            VariavelResultado = "f_n",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f0", Nome = "f₀", Descricao = "Frequência ref", Unidade = "Hz", ValorPadrao = 440, ValorMin = 20, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "n", Descricao = "Semitons", Unidade = "semitons", ValorPadrao = 3, ValorMin = -48, ValorMax = 48, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f0 = inputs["f0"];
                double n = inputs["n"];
                
                return f0 * Math.Pow(2, n / 12);
            }
        };
    }

    public static Formula V8_MUS326_SerieHarmonica()
    {
        return new Formula
        {
            Id = "V8-MUS326",
            CodigoCompendio = "326",
            Nome = "Série Harmônica — f_n",
            Categoria = "Acústica Musical",
            SubCategoria = "Harmônicos",
            Expressao = "f_n = n * f₀",
            ExprTexto = "Harmonic series",
            Descricao = "f_n=n-ésimo harmônico, n=1,2,3,... f₀=fundamental. Timbre: espectro harmônicos. Mersenne 1636.",
            Criador = "Marin Mersenne",
            AnoOrigin = "1636",
            ExemploPratico = "f₀=100Hz: f₁=100, f₂=200 (oitava), f₃=300 (quinta), f₄=400 (2×oitava), ...",
            Unidades = "Hz",
            VariavelResultado = "f_n",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "n", Descricao = "Número harmônico", Unidade = "", ValorPadrao = 2, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "f0", Nome = "f₀", Descricao = "Fundamental", Unidade = "Hz", ValorPadrao = 100, ValorMin = 20, ValorMax = 5000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double f0 = inputs["f0"];
                
                return n * f0;
            }
        };
    }

    public static Formula V8_MUS327_FrequenciaCordaVibrante()
    {
        return new Formula
        {
            Id = "V8-MUS327",
            CodigoCompendio = "327",
            Nome = "Frequência Corda Vibrante — f",
            Categoria = "Acústica Musical",
            SubCategoria = "Cordas",
            Expressao = "f = (1 / (2*L)) * sqrt(T / μ)",
            ExprTexto = "Vibrating string",
            Descricao = "L=comprimento, T=tensão (N), μ=densidade linear (kg/m). Mersenne 1636, Taylor 1713.",
            Criador = "Marin Mersenne (1636) / Brook Taylor (1713)",
            AnoOrigin = "1636-1713",
            ExemploPratico = "L=0,65m (violão), T=80N, μ=0,001kg/m → f≈194Hz (≈G3). L↓: f↑ (trastes)",
            Unidades = "Hz",
            VariavelResultado = "f",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L", Nome = "L", Descricao = "Comprimento", Unidade = "m", ValorPadrao = 0.65, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "T", Descricao = "Tensão", Unidade = "N", ValorPadrao = 80, ValorMin = 1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "mu", Nome = "μ", Descricao = "Densidade linear", Unidade = "kg/m", ValorPadrao = 0.001, ValorMin = 1e-6, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L = inputs["L"];
                double T = inputs["T"];
                double mu = inputs["mu"];
                
                return (1 / (2 * L)) * Math.Sqrt(T / mu);
            }
        };
    }

    public static Formula V8_MUS328_FrequenciaTuboAberto()
    {
        return new Formula
        {
            Id = "V8-MUS328",
            CodigoCompendio = "328",
            Nome = "Frequência Tubo Aberto — f_n",
            Categoria = "Acústica Musical",
            SubCategoria = "Tubos Sonoros",
            Expressao = "f_n = n * v / (2*L)",
            ExprTexto = "Open pipe",
            Descricao = "n=1,2,3,... (todos harmônicos). L=comprimento, v=velocidade som. Flauta, órgão. Taylor.",
            Criador = "Brook Taylor / Daniel Bernoulli",
            AnoOrigin = "~1730s",
            ExemploPratico = "L=0,5m, v=343m/s, n=1 → f₁≈343Hz. n=2: f₂≈686Hz (oitava). Órgão: tubos longos",
            Unidades = "Hz",
            VariavelResultado = "f_n",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "n", Descricao = "Harmônico", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "v", Descricao = "Velocidade som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 300, ValorMax = 400, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "L", Descricao = "Comprimento", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double v = inputs["v"];
                double L = inputs["L"];
                
                return n * v / (2 * L);
            }
        };
    }

    public static Formula V8_MUS329_FrequenciaTuboFechado()
    {
        return new Formula
        {
            Id = "V8-MUS329",
            CodigoCompendio = "329",
            Nome = "Frequência Tubo Fechado — f_n",
            Categoria = "Acústica Musical",
            SubCategoria = "Tubos Sonoros",
            Expressao = "f_n = (2n - 1) * v / (4*L)",
            ExprTexto = "Closed pipe",
            Descricao = "n=1,2,3,... (só ímpares). L=comprimento. Clarinete: c/ palheta=fechado. Bernoulli.",
            Criador = "Daniel Bernoulli",
            AnoOrigin = "~1730s",
            ExemploPratico = "L=0,6m, v=343m/s → f₁≈143Hz (n=1), f₂≈429Hz (n=2, 3× fundamental). Clarinete",
            Unidades = "Hz",
            VariavelResultado = "f_n",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "n", Descricao = "Modo (1,2,3...)", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "v", Descricao = "Velocidade som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 300, ValorMax = 400, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "L", Descricao = "Comprimento", Unidade = "m", ValorPadrao = 0.6, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double v = inputs["v"];
                double L = inputs["L"];
                
                return (2 * n - 1) * v / (4 * L);
            }
        };
    }

    public static Formula V8_MUS330_RessonadorHelmholtz()
    {
        return new Formula
        {
            Id = "V8-MUS330",
            CodigoCompendio = "330",
            Nome = "Ressonador de Helmholtz — f₀",
            Categoria = "Acústica Musical",
            SubCategoria = "Ressonância",
            Expressao = "f₀ = (v / (2π)) * sqrt(A / (V * L_eff))",
            ExprTexto = "Helmholtz resonator",
            Descricao = "A=área gargalo, V=volume cavidade, L_eff=compr. efetivo gargalo. Garrafa: ressoador. 1860.",
            Criador = "Hermann von Helmholtz",
            AnoOrigin = "1860",
            ExemploPratico = "V=0,001m³ (1L), A=0,0001m² (1cm²), L_eff=0,02m, v=343 → f₀≈122Hz. Ocarina, garrafa",
            Unidades = "Hz",
            VariavelResultado = "f0",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v", Nome = "v", Descricao = "Velocidade som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 300, ValorMax = 400, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "A", Descricao = "Área gargalo", Unidade = "m^2", ValorPadrao = 0.0001, ValorMin = 1e-6, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "V", Nome = "V", Descricao = "Volume cavidade", Unidade = "m^3", ValorPadrao = 0.001, ValorMin = 1e-6, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "L_eff", Nome = "L_eff", Descricao = "Compr. efetivo", Unidade = "m", ValorPadrao = 0.02, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v = inputs["v"];
                double A = inputs["A"];
                double V = inputs["V"];
                double L_eff = inputs["L_eff"];
                
                return (v / (2 * Math.PI)) * Math.Sqrt(A / (V * L_eff));
            }
        };
    }

    public static Formula V8_MUS331_VelocidadeSom_Newton()
    {
        return new Formula
        {
            Id = "V8-MUS331",
            CodigoCompendio = "331",
            Nome = "Velocidade do Som — Newton-Laplace",
            Categoria = "Acústica Musical",
            SubCategoria = "Ondas Sonoras",
            Expressao = "v = sqrt(γ * P / ρ)",
            ExprTexto = "Speed of sound (Newton 1687, Laplace 1816 γ)",
            Descricao = "γ=razão calores específicos (ar: 1,4), P=pressão, ρ=densidade. Newton 1687, Laplace 1816 γ.",
            Criador = "Isaac Newton (1687) / Pierre-Simon Laplace (1816)",
            AnoOrigin = "1687-1816",
            ExemploPratico = "γ=1,4 (ar), P=101325Pa, ρ=1,225kg/m³ → v≈343m/s (20°C). T↑: v↑ (~0,6m/s per °C)",
            Unidades = "m/s",
            VariavelResultado = "v",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "gamma", Nome = "γ", Descricao = "Razão Cp/Cv", Unidade = "", ValorPadrao = 1.4, ValorMin = 1, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "P", Nome = "P", Descricao = "Pressão", Unidade = "Pa", ValorPadrao = 101325, ValorMin = 10000, ValorMax = 200000, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "ρ", Descricao = "Densidade", Unidade = "kg/m^3", ValorPadrao = 1.225, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double gamma = inputs["gamma"];
                double P = inputs["P"];
                double rho = inputs["rho"];
                
                return Math.Sqrt(gamma * P / rho);
            }
        };
    }

    public static Formula V8_MUS332_IntensidadeSonora()
    {
        return new Formula
        {
            Id = "V8-MUS332",
            CodigoCompendio = "332",
            Nome = "Intensidade Sonora — I",
            Categoria = "Acústica Musical",
            SubCategoria = "Ondas Sonoras",
            Expressao = "I = P^2 / (2 * ρ * v)",
            ExprTexto = "Sound intensity",
            Descricao = "P=pressão RMS (Pa), ρ=densidade ar, v=velocidade som. I₀=10^-12 W/m² (limiar audição).",
            Criador = "Acústica física",
            AnoOrigin = "~1800s",
            ExemploPratico = "P=0,02Pa (conversação), ρ=1,225kg/m³, v=343m/s → I≈4,76×10^-7 W/m² (≈60dB SPL)",
            Unidades = "W/m^2",
            VariavelResultado = "I",
            UnidadeResultado = "W/m^2",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "P", Descricao = "Pressão RMS", Unidade = "Pa", ValorPadrao = 0.02, ValorMin = 1e-12, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "ρ", Descricao = "Densidade", Unidade = "kg/m^3", ValorPadrao = 1.225, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "v", Descricao = "Velocidade som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 300, ValorMax = 400, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double rho = inputs["rho"];
                double v = inputs["v"];
                
                return P * P / (2 * rho * v);
            }
        };
    }

    public static Formula V8_MUS333_NivelPressaoSonora_SPL()
    {
        return new Formula
        {
            Id = "V8-MUS333",
            CodigoCompendio = "333",
            Nome = "Nível de Pressão Sonora — SPL",
            Categoria = "Acústica Musical",
            SubCategoria = "Decibéis",
            Expressao = "SPL = 20 * log₁₀(P / P_ref)",
            ExprTexto = "Sound Pressure Level",
            Descricao = "P=pressão RMS, P_ref=20μPa (limiar audição). SPL em dB. 0dB=limiar, 120dB=dor.",
            Criador = "Escala decibel (Alexander Graham Bell ~1920s)",
            AnoOrigin = "~1920s",
            ExemploPratico = "P=2Pa (música alta) → SPL≈100dB. P=0,0002Pa (sussurro) → SPL≈20dB. +20dB=10× pressão",
            Unidades = "dB SPL",
            VariavelResultado = "SPL",
            UnidadeResultado = "dB SPL",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "P", Descricao = "Pressão RMS", Unidade = "Pa", ValorPadrao = 2, ValorMin = 1e-12, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "P_ref", Nome = "P_ref", Descricao = "Pressão ref", Unidade = "Pa", ValorPadrao = 20e-6, ValorMin = 1e-12, ValorMax = 1e-3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double P_ref = inputs["P_ref"];
                
                return 20 * Math.Log10(P / P_ref);
            }
        };
    }

    public static Formula V8_MUS334_EfeitoDoppler_Audio()
    {
        return new Formula
        {
            Id = "V8-MUS334",
            CodigoCompendio = "334",
            Nome = "Efeito Doppler — f'",
            Categoria = "Acústica Musical",
            SubCategoria = "Ondas Sonoras",
            Expressao = "f' = f * (v + v_obs) / (v - v_fonte)",
            ExprTexto = "Doppler effect",
            Descricao = "v=vel. som, v_obs=vel. observador, v_fonte=vel. fonte. Aproxima: f↑. Christian Doppler 1842.",
            Criador = "Christian Doppler",
            AnoOrigin = "1842",
            ExemploPratico = "f=440Hz (ambulância), v_fonte=30m/s, v_obs=0, v=343 → f'≈482Hz (+42Hz pitch↑)",
            Unidades = "Hz",
            VariavelResultado = "f_prime",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f", Nome = "f", Descricao = "Freq. emitida", Unidade = "Hz", ValorPadrao = 440, ValorMin = 20, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "v", Descricao = "Velocidade som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 300, ValorMax = 400, Obrigatoria = true },
                new() { Simbolo = "v_obs", Nome = "v_obs", Descricao = "Vel. observador", Unidade = "m/s", ValorPadrao = 0, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "v_fonte", Nome = "v_fonte", Descricao = "Vel. fonte", Unidade = "m/s", ValorPadrao = 30, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f = inputs["f"];
                double v = inputs["v"];
                double v_obs = inputs["v_obs"];
                double v_fonte = inputs["v_fonte"];
                
                return f * (v + v_obs) / (v - v_fonte);
            }
        };
    }

    public static Formula V8_MUS335_Batimentos_Frequencia()
    {
        return new Formula
        {
            Id = "V8-MUS335",
            CodigoCompendio = "335",
            Nome = "Frequência de Batimentos — f_beat",
            Categoria = "Acústica Musical",
            SubCategoria = "Interferência",
            Expressao = "f_beat = |f₁ - f₂|",
            ExprTexto = "Beat frequency",
            Descricao = "f₁,f₂=frequências próximas. Batimentos: modulação amplitude. Afinação: batimentos→0. Helmholtz.",
            Criador = "Acústica (Helmholtz sistematizou ~1860s)",
            AnoOrigin = "~1860s",
            ExemploPratico = "f₁=440Hz (A4), f₂=442Hz → f_beat=2Hz (2 batimentos/s). Afinadores: batimentos lentos",
            Unidades = "Hz",
            VariavelResultado = "f_beat",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f1", Nome = "f₁", Descricao = "Frequência 1", Unidade = "Hz", ValorPadrao = 440, ValorMin = 20, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "f2", Nome = "f₂", Descricao = "Frequência 2", Unidade = "Hz", ValorPadrao = 442, ValorMin = 20, ValorMax = 20000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f1 = inputs["f1"];
                double f2 = inputs["f2"];
                
                return Math.Abs(f1 - f2);
            }
        };
    }

    public static Formula V8_MUS336_TempoReverberacao_Sabine()
    {
        return new Formula
        {
            Id = "V8-MUS336",
            CodigoCompendio = "336",
            Nome = "Tempo de Reverberação — RT60 (Sabine)",
            Categoria = "Acústica Musical",
            SubCategoria = "Reverberação",
            Expressao = "RT60 = 0.161 * V / A",
            ExprTexto = "Sabine's reverberation formula",
            Descricao = "V=volume (m³), A=absorção total (m²). RT60: tempo cair 60dB. Wallace Sabine 1898.",
            Criador = "Wallace Clement Sabine",
            AnoOrigin = "1898",
            ExemploPratico = "V=5000m³ (sala concerto), A=500m² (Sabins) → RT60≈1,6s. Ópera: 1,5-2s ideal",
            Unidades = "s",
            VariavelResultado = "RT60",
            UnidadeResultado = "s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "V", Nome = "V", Descricao = "Volume sala", Unidade = "m^3", ValorPadrao = 5000, ValorMin = 10, ValorMax = 100000, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "A", Descricao = "Absorção total", Unidade = "m^2 (Sabins)", ValorPadrao = 500, ValorMin = 1, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double V = inputs["V"];
                double A = inputs["A"];
                
                return 0.161 * V / A;
            }
        };
    }

    public static Formula V8_MUS337_AbsorcaoAcustica()
    {
        return new Formula
        {
            Id = "V8-MUS337",
            CodigoCompendio = "337",
            Nome = "Coeficiente de Absorção — α",
            Categoria = "Acústica Musical",
            SubCategoria = "Absorção",
            Expressao = "α = E_absorvida / E_incidente",
            ExprTexto = "Absorption coefficient",
            Descricao = "α∈[0,1]. α=0: reflexão total. α=1: absorção total. Materiais: α variável com frequência. Sabine.",
            Criador = "Wallace Sabine",
            AnoOrigin = "~1898",
            ExemploPratico = "Cortina pesada: α≈0,6-0,8 (boa absorção). Concreto: α≈0,01-0,05 (refletivo). Salas: α misto",
            Unidades = "adimensional",
            VariavelResultado = "alpha",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E_abs", Nome = "E_absorvida", Descricao = "Energia absorvida", Unidade = "", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "E_inc", Nome = "E_incidente", Descricao = "Energia incidente", Unidade = "", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E_abs = inputs["E_abs"];
                double E_inc = inputs["E_inc"];
                
                return E_abs / E_inc;
            }
        };
    }

    public static Formula V8_MUS338_CentsIntervalo()
    {
        return new Formula
        {
            Id = "V8-MUS338",
            CodigoCompendio = "338",
            Nome = "Cents — Intervalo Musical",
            Categoria = "Acústica Musical",
            SubCategoria = "Intervalos Musicais",
            Expressao = "cents = 1200 * log₂(f₂ / f₁)",
            ExprTexto = "Cents (1 semitom=100 cents)",
            Descricao = "Medida logarítmica intervalo. 1200 cents=oitava. 100 cents=semitom (12-TET). Ellis 1885.",
            Criador = "Alexander John Ellis",
            AnoOrigin = "1885",
            ExemploPratico = "f₁=440Hz, f₂=880Hz → 1200 cents (oitava). f₂=466,16Hz (A#) → 100 cents (semitom)",
            Unidades = "cents",
            VariavelResultado = "cents",
            UnidadeResultado = "cents",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f1", Nome = "f₁", Descricao = "Frequência 1", Unidade = "Hz", ValorPadrao = 440, ValorMin = 20, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "f2", Nome = "f₂", Descricao = "Frequência 2", Unidade = "Hz", ValorPadrao = 880, ValorMin = 20, ValorMax = 20000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f1 = inputs["f1"];
                double f2 = inputs["f2"];
                
                return 1200 * Math.Log2(f2 / f1);
            }
        };
    }

    public static Formula V8_MUS339_ImpedanciaAcustica()
    {
        return new Formula
        {
            Id = "V8-MUS339",
            CodigoCompendio = "339",
            Nome = "Impedância Acústica — Z",
            Categoria = "Acústica Musical",
            SubCategoria = "Ondas Sonoras",
            Expressao = "Z = ρ * v",
            ExprTexto = "Acoustic impedance",
            Descricao = "ρ=densidade, v=velocidade som. Z=resistência propagação. Ar: Z≈420 Rayl. Reflexão: ΔZ.",
            Criador = "Acústica (Lord Rayleigh sistematizou)",
            AnoOrigin = "~1880s",
            ExemploPratico = "ρ=1,225kg/m³, v=343m/s → Z≈420 Pa·s/m (Rayl). Água: Z≈1,5×10⁶ Rayl (3500× ar)",
            Unidades = "Pa·s/m",
            VariavelResultado = "Z",
            UnidadeResultado = "Pa·s/m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "rho", Nome = "ρ", Descricao = "Densidade", Unidade = "kg/m^3", ValorPadrao = 1.225, ValorMin = 0.1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "v", Descricao = "Velocidade som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 100, ValorMax = 6000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double rho = inputs["rho"];
                double v = inputs["v"];
                
                return rho * v;
            }
        };
    }

    public static Formula V8_MUS340_CoeficienteReflexao()
    {
        return new Formula
        {
            Id = "V8-MUS340",
            CodigoCompendio = "340",
            Nome = "Coeficiente de Reflexão — R",
            Categoria = "Acústica Musical",
            SubCategoria = "Reflexão",
            Expressao = "R = (Z₂ - Z₁) / (Z₂ + Z₁)",
            ExprTexto = "Reflection coefficient",
            Descricao = "Z₁,Z₂=impedâncias meios. R∈[-1,1]. R=0: casamento perfeito. R=±1: reflexão total. Rayleigh.",
            Criador = "Lord Rayleigh",
            AnoOrigin = "~1880s",
            ExemploPratico = "Ar→água: Z₁≈420, Z₂≈1,5×10⁶ → R≈0,9994 (99,94% reflete, 0,06% transmite)",
            Unidades = "adimensional",
            VariavelResultado = "R",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Z1", Nome = "Z₁", Descricao = "Impedância 1", Unidade = "Pa·s/m", ValorPadrao = 420, ValorMin = 1, ValorMax = 1e7, Obrigatoria = true },
                new() { Simbolo = "Z2", Nome = "Z₂", Descricao = "Impedância 2", Unidade = "Pa·s/m", ValorPadrao = 1.5e6, ValorMin = 1, ValorMax = 1e7, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Z1 = inputs["Z1"];
                double Z2 = inputs["Z2"];
                
                return (Z2 - Z1) / (Z2 + Z1);
            }
        };
    }

    public static Formula V8_MUS341_ComprimentoOnda()
    {
        return new Formula
        {
            Id = "V8-MUS341",
            CodigoCompendio = "341",
            Nome = "Comprimento de Onda — λ",
            Categoria = "Acústica Musical",
            SubCategoria = "Ondas Sonoras",
            Expressao = "λ = v / f",
            ExprTexto = "Wavelength",
            Descricao = "v=velocidade som, f=frequência. λ=distância espacial 1 ciclo. Grave: λ longo. Agudo: λ curto.",
            Criador = "Física ondulatória clássica",
            AnoOrigin = "~1600s-1700s",
            ExemploPratico = "f=1kHz, v=343m/s → λ≈0,343m=34,3cm. f=100Hz → λ≈3,43m (graves: λ grande)",
            Unidades = "m",
            VariavelResultado = "lambda",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v", Nome = "v", Descricao = "Velocidade som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 300, ValorMax = 400, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "f", Descricao = "Frequência", Unidade = "Hz", ValorPadrao = 1000, ValorMin = 20, ValorMax = 20000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v = inputs["v"];
                double f = inputs["f"];
                
                return v / f;
            }
        };
    }
}
