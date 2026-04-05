using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XII
    /// ACÚSTICA SUBAQUÁTICA, SONAR E OCEANOGRAFIA ACÚSTICA
    /// Fórmulas V10-220 a V10-238 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_UnderwaterAcoustics()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3808",
                    CodigoCompendio = "V10-220",
                    Nome = "Equação de Sonar — Nível de Sinal",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Sistemas Sonar",
                    Expressao = @"SL − 2TL + TS − (NL − DI) = DT",
                    Descricao = "SL: source level. TL: transmission loss. TS: target strength. NL: noise level. DI: directivity index. DT: detection threshold.",
                    ExemploPratico = "Sonar ativo: SL=220dB, TL=70dB, TS=20dB, NL=80dB, DI=20dB → SNR=20dB. Detecção possível se SNR>DT.",
                    Criador = "Urick (1983, Principles of Underwater Sound)",
                    AnoOrigin = "1983",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Source Level SL (dB)", Simbolo = "SL", Unidade = "dB", ValorPadrao = 220, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Transmission Loss TL (dB)", Simbolo = "TL", Unidade = "dB", ValorPadrao = 70, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Target Strength TS (dB)", Simbolo = "TS", Unidade = "dB", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    VariavelResultado = "SNR",
                    UnidadeResultado = "dB",
                    Calcular = inputs =>
                    {
                        double SL = inputs["Source Level SL (dB)"];
                        double TL = inputs["Transmission Loss TL (dB)"];
                        double TS = inputs["Target Strength TS (dB)"];
                        
                        double NL = 80; // Típico
                        double DI = 20; // Típico
                        
                        double SNR = SL - 2 * TL + TS - (NL - DI);
                        return SNR;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-221: Perda por Transmissão (TL)
                new Formula
                {
                    Id = "3809",
                    CodigoCompendio = "V10-221",
                    Nome = "Perda por Transmissão (Transmission Loss)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Propagação",
                    Expressao = @"TL = 20·log(r) + α·r·10^(-3) (spreading+absorption)",
                    Descricao = "r: distância (m), α: coef absorção (dB/km). Spreading: esférico (20log r) ou cilíndrico (10log r). α≈f²·depth dependent.",
                    ExemploPratico = "1 kHz, 10 km: α≈0.05 dB/km→TL=20·log(10000)+0.05·10≈80+0.5=80.5 dB. 10 kHz, same distance: α≈0.8→TL=80+8=88 dB.",
                    Criador = "Thorp (1967, absorção empírica); Urick (1983)",
                    AnoOrigin = "1967",
                    VariavelResultado = "TL",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Distância r (m)", Simbolo = "r", Unidade = "m", ValorPadrao = 10000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "α absorção (dB/km)", Simbolo = "alpha", Unidade = "dB/km", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double r = inputs["Distância r (m)"];
                        double alpha = inputs["α absorção (dB/km)"];
                        
                        if (r <= 0) return 0;
                        
                        double spreading = 20 * Math.Log10(r);
                        double absorption = alpha * r / 1000; // r em m, alpha em dB/km
                        double TL = spreading + absorption;
                        return TL;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-222: Lei de Snell (Refração)
                new Formula
                {
                    Id = "3810",
                    CodigoCompendio = "V10-222",
                    Nome = "Lei de Snell — Refração Acústica",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Propagação",
                    Expressao = @"cos(θ₁)/c₁ = cos(θ₂)/c₂",
                    Descricao = "θ: ângulo c/ vertical, c: velocidade som. Sound channel: min c→refração horizontal. Ray tracing: Bellhop, RAMSurf.",
                    ExemploPratico = "Superfície c=1500 m/s θ=30°, layer c=1450→cos(θ₂)=1450·cos(30)/1500≈0.838→θ₂≈33° (refração p/ baixo).",
                    Criador = "Snellius (1621, refração luz, adaptado som); Ewing-Worzel (1948, underwater raytracing)",
                    AnoOrigin = "1948",
                    VariavelResultado = "theta2",
                    UnidadeResultado = "graus",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "θ₁ (graus)", Simbolo = "theta1", Unidade = "graus", ValorPadrao = 30, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c₁ (m/s)", Simbolo = "c1", Unidade = "m/s", ValorPadrao = 1500, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c₂ (m/s)", Simbolo = "c2", Unidade = "m/s", ValorPadrao = 1450, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double theta1 = inputs["θ₁ (graus)"];
                        double c1 = inputs["c₁ (m/s)"];
                        double c2 = inputs["c₂ (m/s)"];
                        
                        if (c1 == 0 || c2 == 0) return 0;
                        
                        double theta1_rad = theta1 * Math.PI / 180;
                        double cos_theta2 = c2 * Math.Cos(theta1_rad) / c1;
                        
                        if (Math.Abs(cos_theta2) > 1) return double.NaN; // Total internal reflection
                        
                        double theta2_rad = Math.Acos(cos_theta2);
                        double theta2 = theta2_rad * 180 / Math.PI;
                        return theta2;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-223: Velocidade do Som (Mackenzie)
                new Formula
                {
                    Id = "3811",
                    CodigoCompendio = "V10-223",
                    Nome = "Velocidade do Som — Fórmula Mackenzie",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Propriedades do Meio",
                    Expressao = @"c = 1448.96 + 4.591T − 0.05304T² + ... + 1.340(S−35) + 0.0167D",
                    Descricao = "T: temp (°C), S: salinidade (PSU), D: profundidade (m). Precisão ~0.1 m/s. CTD: measure T,S,D→c(z) profile.",
                    ExemploPratico = "T=10°C, S=35 PSU, D=1000m→c≈1448.96+45.91−5.3+16.7≈1506 m/s. Warm surface: c~1540 m/s (tropics). Arctic: c~1440 m/s.",
                    Criador = "Mackenzie (1981, nine-term equation, simplificada); Del Grosso (mais precisa, NIST)",
                    AnoOrigin = "1981",
                    VariavelResultado = "c",
                    UnidadeResultado = "m/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Temperatura T (°C)", Simbolo = "T", Unidade = "°C", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Salinidade S (PSU)", Simbolo = "S", Unidade = "PSU", ValorPadrao = 35, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Profundidade D (m)", Simbolo = "D", Unidade = "m", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double T = inputs["Temperatura T (°C)"];
                        double S = inputs["Salinidade S (PSU)"];
                        double D = inputs["Profundidade D (m)"];
                        
                        // Mackenzie simplificada (termos principais)
                        double c = 1448.96 + 4.591 * T - 0.05304 * T * T + 0.0002374 * T * T * T
                                 + 1.340 * (S - 35) + 0.0167 * D + 2.16e-5 * D * D
                                 - 0.0107 * T * (S - 35);

                        return c;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-224: Target Strength
                new Formula
                {
                    Id = "3812",
                    CodigoCompendio = "V10-224",
                    Nome = "Target Strength (TS)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Sonar",
                    Expressao = @"TS = 10·log(σ/4π); σ: seção reta radar acústica (m²)",
                    Descricao = "Esfera: TS=10log(a²/4) (a=raio). Submarino: TS≈10-30 dB. Baleia: TS≈−10 dB. Peixe: TS≈−30 a −80 dB.",
                    ExemploPratico = "Esfera a=1m→σ=πa²=3.14 m²→TS=10log(3.14/12.57)≈−6 dB. Sub: TS~20 dB. Torpedo: TS~5 dB.",
                    Criador = "Urick (1983); Rayleigh scattering (limite ka<<1, k=onda número)",
                    AnoOrigin = "1983",
                    VariavelResultado = "TS",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Seção reta σ (m²)", Simbolo = "sigma", Unidade = "m²", ValorPadrao = 3.14, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double sigma = inputs["Seção reta σ (m²)"];
                        
                        if (sigma <= 0) return double.NegativeInfinity;
                        
                        double TS = 10 * Math.Log10(sigma / (4 * Math.PI));
                        return TS;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-225: Índice de Diretividade (DI)
                new Formula
                {
                    Id = "3813",
                    CodigoCompendio = "V10-225",
                    Nome = "Índice de Diretividade (Directivity Index)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Transdutores",
                    Expressao = @"DI = 10·log(4π/Ω) (dB); Ω: ângulo sólido efetivo (sr)",
                    Descricao = "Beamwidth θ (graus): DI≈10log(180²/θ²). Array linear L: DI≈10log(L/λ). Beamformer: processamento direcional.",
                    ExemploPratico = "Beamwidth θ=10°→DI≈10log(324)≈25 dB. Line array L=10m, f=1kHz λ=1.5m→DI≈10log(6.67)≈8 dB.",
                    Criador = "Urick (1983); beamforming (Van Veen-Buckley 1988)",
                    AnoOrigin = "1983",
                    VariavelResultado = "DI",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Beamwidth θ (graus)", Simbolo = "theta", Unidade = "graus", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double theta = inputs["Beamwidth θ (graus)"];
                        
                        if (theta == 0) return double.PositiveInfinity;
                        
                        // Aproximação: DI ≈ 10log((180/θ)²) assumindo beam circular
                        double DI = 10 * Math.Log10((180.0 / theta) * (180.0 / theta));
                        return DI;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-226: Nível de Ruído Ambiente
                new Formula
                {
                    Id = "3814",
                    CodigoCompendio = "V10-226",
                    Nome = "Ruído Ambiente (Sea State)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Ruído",
                    Expressao = @"NL = 60 + 16·log(SS) − 26·log(f/1kHz) (aproximação Wenz)",
                    Descricao = "SS: sea state (0-6). Wenz curves (1962): ruído vs frequência. Shipping: peak ~100 Hz. Breaking waves: >1 kHz. Thermal: >100 kHz.",
                    ExemploPratico = "SS=3 (moderate), f=1kHz→NL≈60+16·log(3)=67.6 dB re 1µPa. f=10kHz: NL≈67.6−26=41.6 dB (menor ruído).",
                    Criador = "Wenz (1962, classic ambient noise spectrum); Knudsen (1948, pioneiro)",
                    AnoOrigin = "1962",
                    VariavelResultado = "NL",
                    UnidadeResultado = "dB re 1µPa",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Sea State SS (0-6)", Simbolo = "SS", Unidade = "", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Frequência f (kHz)", Simbolo = "f", Unidade = "kHz", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double SS = inputs["Sea State SS (0-6)"];
                        double f = inputs["Frequência f (kHz)"];
                        
                        if (SS == 0) SS = 0.1; // Evita log(0)
                        if (f == 0) f = 0.1;
                        
                        double NL = 60 + 16 * Math.Log10(SS) - 26 * Math.Log10(f);
                        return NL;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-227: Profundidade do Canal Sonoro (SOFAR)
                new Formula
                {
                    Id = "3815",
                    CodigoCompendio = "V10-227",
                    Nome = "SOFAR Channel (Sound Fixing and Ranging)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Propagação",
                    Expressao = @"z_axis ≈ 1000-1200m (típico Atlântico); c_min refraction waveguide",
                    Descricao = "c(z): min a ~1km profundidade. Raios refratam→guia de onda natural. Transmissão longa distância (1000s km). Baleias usam channel.",
                    ExemploPratico = "Atlântico mid: z_axis≈1100m, c_min≈1490 m/s. Explosão: detected 1000 km. Blue whale calls: propagam 100-1000 km via SOFAR.",
                    Criador = "Ewing-Worzel (1948, descoberta SOFAR); explorado US Navy (1950s)",
                    AnoOrigin = "1948",
                    VariavelResultado = "z_axis",
                    UnidadeResultado = "m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Latitude graus (aprox)", Simbolo = "lat", Unidade = "graus", ValorPadrao = 40, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lat = inputs["Latitude graus (aprox)"];
                        
                        // Estimativa empírica: z_axis mais profundo em baixas latitudes
                        double z_axis = 1000 + (60 - Math.Abs(lat)) * 5; // simplificado
                        if (z_axis < 600) z_axis = 600; // Mínimo
                        if (z_axis > 1400) z_axis = 1400; // Máximo
                        
                        return z_axis;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-228: Doppler Shift
                new Formula
                {
                    Id = "3816",
                    CodigoCompendio = "V10-228",
                    Nome = "Efeito Doppler — Sonar",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Processamento",
                    Expressao = @"f_r = f_t·(c+v_r)/(c−v_t)",
                    Descricao = "v_t: velocidade transmissor (positivo aproximando), v_r: velocidade receptor. DVL (Doppler Velocity Log): mede velocidade navio.",
                    ExemploPratico = "Submarino v=10 m/s approaching, f_t=10kHz, c=1500 m/s→f_r≈10·(1500+10)/(1500−10)≈10.13 kHz (+130 Hz shift).",
                    Criador = "Doppler (1842, luz/som); aplicado sonar (WWII, U-boat detection)",
                    AnoOrigin = "1940",
                    VariavelResultado = "f_r",
                    UnidadeResultado = "kHz",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "f transmissão (kHz)", Simbolo = "f_t", Unidade = "kHz", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "v transmissor (m/s)", Simbolo = "v_t", Unidade = "m/s", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "v receptor (m/s)", Simbolo = "v_r", Unidade = "m/s", ValorPadrao = 0, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double f_t = inputs["f transmissão (kHz)"];
                        double v_t = inputs["v transmissor (m/s)"];
                        double v_r = inputs["v receptor (m/s)"];
                        
                        double c = 1500; // m/s
                        
                        double denom = c - v_t;
                        if (Math.Abs(denom) < 0.1) return double.NaN; // v→c
                        
                        double f_r = f_t * (c + v_r) / denom;
                        return f_r;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-229: Resolução Range (Chirp)
                new Formula
                {
                    Id = "3817",
                    CodigoCompendio = "V10-229",
                    Nome = "Resolução Range (Chirp Sonar)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Processamento",
                    Expressao = @"ΔR = c/(2·B); B: bandwidth",
                    Descricao = "Chirp: linear FM. Matched filter: compressão pulso. Resolução melhora com B (não duração). Synthetic aperture sonar (SAS): sub-wavelength.",
                    ExemploPratico = "B=10 kHz, c=1500 m/s→ΔR=1500/(2·10000)=0.075m=7.5cm. Narrow pulse: ΔR=c·τ/2. Chirp advantage: energia×resolução.",
                    Criador = "Klauder et al. (1960, chirp radar/sonar); matched filter (North 1943)",
                    AnoOrigin = "1960",
                    VariavelResultado = "delta_R",
                    UnidadeResultado = "m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Bandwidth B (kHz)", Simbolo = "B", Unidade = "kHz", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double B = inputs["Bandwidth B (kHz)"];
                        
                        if (B == 0) return double.PositiveInfinity;
                        
                        double c = 1500; // m/s
                        double B_Hz = B * 1000;
                        double delta_R = c / (2 * B_Hz);
                        return delta_R;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-230: Reverberation Level
                new Formula
                {
                    Id = "3818",
                    CodigoCompendio = "V10-230",
                    Nome = "Nível de Reverberação (Volume Scattering)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Sonar",
                    Expressao = @"RL = SL − 10·log(r²) + 10·log(ψcτ/2) + Sv",
                    Descricao = "Sv: volume scattering strength (dB). ψ: beamwidth, τ: pulse duration. Deep scattering layer (DSL): peixes/plâncton, Sv~−70 dB.",
                    ExemploPratico = "SL=220 dB, r=5km, ψ=10°×10°, τ=10ms, Sv=−70dB→RL≈220−74+log(…)−70≈? (complex). Reverberation limits detection.",
                    Criador = "Urick (1983); Chapman-Harris (1962, DSL characterization)",
                    AnoOrigin = "1962",
                    VariavelResultado = "RL",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "SL (dB)", Simbolo = "SL", Unidade = "dB", ValorPadrao = 220, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "r distância (km)", Simbolo = "r", Unidade = "km", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Sv scattering (dB)", Simbolo = "Sv", Unidade = "dB", ValorPadrao = -70, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double SL = inputs["SL (dB)"];
                        double r = inputs["r distância (km)"];
                        double Sv = inputs["Sv scattering (dB)"];
                        
                        if (r <= 0) return double.NegativeInfinity;
                        
                        double r_m = r * 1000;
                        // Simplificação: termo geométrico + Sv
                        double RL = SL - 10 * Math.Log10(r_m * r_m) + Sv + 30; // +30 fator típico
                        return RL;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-231: Acoustic Power
                new Formula
                {
                    Id = "3819",
                    CodigoCompendio = "V10-231",
                    Nome = "Potência Acústica (Source Level)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Transdutores",
                    Expressao = @"SL = 170.8 + 10·log(P_acoustic); P em Watts",
                    Descricao = "SL: dB re 1µPa @ 1m. P_acoustic: potência irradiada. Transducer efficiency η: P_acoustic=η·P_electric. Típico η=0.5-0.8.",
                    ExemploPratico = "Transducer η=0.6, P_elec=1kW→P_ac=600W→SL=170.8+10·log(600)≈170.8+27.8=198.6 dB. High-power: SL>220 dB.",
                    Criador = "Urick (1983); referência 1µPa @ 1m (padrão underwater acoustics)",
                    AnoOrigin = "1983",
                    VariavelResultado = "SL",
                    UnidadeResultado = "dB re 1µPa@1m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "P acústica (W)", Simbolo = "P", Unidade = "W", ValorPadrao = 600, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double P = inputs["P acústica (W)"];
                        
                        if (P <= 0) return double.NegativeInfinity;
                        
                        double SL = 170.8 + 10 * Math.Log10(P);
                        return SL;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-232: Cavitação
                new Formula
                {
                    Id = "3820",
                    CodigoCompendio = "V10-232",
                    Nome = "Limiar de Cavitação",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Fenômenos Não-Lineares",
                    Expressao = @"P_cav ≈ P_static + P_vapor; tipicamente ~0.5-1 atm acoustic pressure",
                    Descricao = "Bubble formation: pressão acústica negativa excede tensile strength água. Cavitation noise: ruído broadband. Limita source level.",
                    ExemploPratico = "10m profundidade: P_static=2 atm. P_cav≈1 atm acústico→amplitude SPL≈120 dB re 1µPa @ transducer face. Deeper: higher threshold.",
                    Criador = "Rayleigh (1917, colapso bolha); Flynn (1964, acoustic cavitation threshold)",
                    AnoOrigin = "1964",
                    VariavelResultado = "P_cav",
                    UnidadeResultado = "atm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Profundidade (m)", Simbolo = "depth", Unidade = "m", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double depth = inputs["Profundidade (m)"];
                        
                        double P_static = 1 + depth / 10; // atm
                        double P_vapor = 0.02; // atm (água, ~20°C)
                        double P_cav = P_static + P_vapor + 0.5; // +0.5 margem tensile
                        return P_cav;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-233: Array Gain
                new Formula
                {
                    Id = "3821",
                    CodigoCompendio = "V10-233",
                    Nome = "Array Gain (Beamforming)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Processamento",
                    Expressao = @"AG = 10·log(N) (ideal uncorrelated noise); N: elements",
                    Descricao = "Coherent signal, incoherent noise. Shading: reduce sidelobes, reduce AG. Adaptive beamforming (MVDR, GSC): suppress interferers.",
                    ExemploPratico = "32-element array→AG=10log(32)≈15 dB. Towed array: 100s elements→AG>20 dB. Noise-limited→AG improves SNR.",
                    Criador = "Van Veen-Buckley (1988, beamforming survey); Cox (1973, array gain)",
                    AnoOrigin = "1973",
                    VariavelResultado = "AG",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N elementos", Simbolo = "N", Unidade = "", ValorPadrao = 32, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["N elementos"];
                        
                        if (N <= 0) return 0;
                        
                        double AG = 10 * Math.Log10(N);
                        return AG;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-234: Cavidade Ressonante (Transdutor)
                new Formula
                {
                    Id = "3822",
                    CodigoCompendio = "V10-234",
                    Nome = "Frequência Ressonante Transdutor",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Transdutores",
                    Expressao = @"f_res = c/(2·L); L: comprimento cavidade",
                    Descricao = "Transdutor Tonpilz (Langevin): piezoelétrico + massa. Ressonância: máxima eficiência. Q-factor: bandwidth. Impedance matching.",
                    ExemploPratico = "L=5cm, c_ceramic≈4000 m/s→f_res=4000/(2·0.05)=40 kHz (fishfinder típico). Multibeam: 30-300 kHz.",
                    Criador = "Langevin (1917, piezo transducer); Tonpilz design (anos 1930s)",
                    AnoOrigin = "1917",
                    VariavelResultado = "f_res",
                    UnidadeResultado = "kHz",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "L comprimento (cm)", Simbolo = "L", Unidade = "cm", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c material (m/s)", Simbolo = "c", Unidade = "m/s", ValorPadrao = 4000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double L = inputs["L comprimento (cm)"];
                        double c = inputs["c material (m/s)"];
                        
                        if (L == 0) return double.PositiveInfinity;
                        
                        double L_m = L / 100;
                        double f_res = c / (2 * L_m);
                        double f_res_kHz = f_res / 1000;
                        return f_res_kHz;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-235: Relação Sinal-Reverberação
                new Formula
                {
                    Id = "3823",
                    CodigoCompendio = "V10-235",
                    Nome = "Relação Sinal-Reverberação (SRR)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Desempenho Sonar",
                    Expressao = @"SRR = SL − 2·TL + TS − RL",
                    Descricao = "RL: reverberation level. Active sonar: reverberation-limited (shallow water) vs noise-limited (deep ocean). SRR>0: detection.",
                    ExemploPratico = "SL=220, TL=60, TS=15, RL=90→SRR=220−120+15−90=25 dB. Positive SRR: echo stands out. Pulse compression helps.",
                    Criador = "Urick (1983)",
                    AnoOrigin = "1983",
                    VariavelResultado = "SRR",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "SL (dB)", Simbolo = "SL", Unidade = "dB", ValorPadrao = 220, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "TL (dB)", Simbolo = "TL", Unidade = "dB", ValorPadrao = 60, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "TS (dB)", Simbolo = "TS", Unidade = "dB", ValorPadrao = 15, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "RL (dB)", Simbolo = "RL", Unidade = "dB", ValorPadrao = 90, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double SL = inputs["SL (dB)"];
                        double TL = inputs["TL (dB)"];
                        double TS = inputs["TS (dB)"];
                        double RL = inputs["RL (dB)"];
                        
                        double SRR = SL - 2 * TL + TS - RL;
                        return SRR;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-236: Lloyd Mirror Effect
                new Formula
                {
                    Id = "3824",
                    CodigoCompendio = "V10-236",
                    Nome = "Efeito Lloyd Mirror (Interferência)",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Propagação",
                    Expressao = @"TL_interference = TL_direct + 20·log|1 + R·e^(iΔφ)|",
                    Descricao = "Som direto + reflexão superfície/fundo. R: coef reflexão (~−1 superfície livre). Δφ: diferença fase. Fringes: nulls periódicas range/depth.",
                    ExemploPratico = "Shallow water: λ/4 depth differences→constructive/destructive. f=1kHz, λ=1.5m, depths differ 0.375m→null. Ray+normal mode models.",
                    Criador = "Lloyd (1834, Lloyd mirror interferência luz, adaptado som); Pekeris (1948, normal mode theory)",
                    AnoOrigin = "1948",
                    VariavelResultado = "TL_extra",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R reflexão", Simbolo = "R", Unidade = "", ValorPadrao = -0.9, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Δφ fase (rad)", Simbolo = "dphi", Unidade = "rad", ValorPadrao = 3.14, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double R = inputs["R reflexão"];
                        double dphi = inputs["Δφ fase (rad)"];
                        
                        // Magnitude |1 + R·e^(iΔφ)|
                        double re = 1 + R * Math.Cos(dphi);
                        double im = R * Math.Sin(dphi);
                        double mag = Math.Sqrt(re * re + im * im);
                        
                        if (mag == 0) return double.NegativeInfinity;
                        
                        double TL_extra = 20 * Math.Log10(mag);
                        return TL_extra;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-237: Synthetic Aperture Sonar (SAS) — Resolução
                new Formula
                {
                    Id = "3825",
                    CodigoCompendio = "V10-237",
                    Nome = "Resolução Azimute SAS",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Imaging",
                    Expressao = @"Δy = D/2; D: apertura física",
                    Descricao = "SAS: movimento plataforma→aperture sintética. Resolução independente range (vs sonar convencional). Mine countermeasures: cm-resolution.",
                    ExemploPratico = "D=0.5m→Δy=0.25m resolution. Synthetic aperture L=10m→equivalente, mas D física pequena. Range-independent: revolucionário.",
                    Criador = "Cutrona et al. (1961, SAR conceito, adaptado SAS 1970s); Hansen (2011, SAS overview)",
                    AnoOrigin = "1970",
                    VariavelResultado = "delta_y",
                    UnidadeResultado = "m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "D apertura (m)", Simbolo = "D", Unidade = "m", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double D = inputs["D apertura (m)"];
                        
                        double delta_y = D / 2;
                        return delta_y;
                    },
                    Icone = "🌊",
                    Unidades = "",
                },

                // V10-238: Time Reversal Mirror (TRM)
                new Formula
                {
                    Id = "3826",
                    CodigoCompendio = "V10-238",
                    Nome = "Time Reversal Mirror — Focalização",
                    Categoria = "Acústica Subaquática",
                    SubCategoria = "Processamento Avançado",
                    Expressao = @"p_focus(r,t) = Σ p_n(r,−t); retransmite inversão temporal",
                    Descricao = "Recebe multipath→inverte tempo→retransmite. Campo converge foco (auto-focusing). Communications, lithotripsy, target detection.",
                    ExemploPratico = "Shallow water multipath: TRM auto-equalizes. Fink (1997): underwater video link via TRM. Dolphin biosonar: natural time-reversal processing.",
                    Criador = "Fink (1997, time reversal mirror); Kuperman et al. (1998, underwater TRM experiments)",
                    AnoOrigin = "1997",
                    VariavelResultado = "gain",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N canais", Simbolo = "N", Unidade = "", ValorPadrao = 16, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["N canais"];
                        
                        // Ganho espacial aproximado (coerente)
                        double gain = 10 * Math.Log10(N);
                        return gain;
                    },
                    Icone = "🌊",
                    Unidades = "",
                }
            });
        }
    }
}
