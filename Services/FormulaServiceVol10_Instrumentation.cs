using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XIV
    /// INSTRUMENTAÇÃO E METROLOGIA
    /// Fórmulas V10-260 a V10-279 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_Instrumentation()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3848",
                    CodigoCompendio = "V10-260",
                    Nome = "Incerteza de Medição — Propagação",
                    Categoria = "Instrumentação",
                    SubCategoria = "Metrologia e Incerteza",
                    Expressao = @"u_c² = Σ(∂f/∂xᵢ)²·u²(xᵢ)",
                    Descricao = "Incerteza combinada via lei de propagação. u(xᵢ): incerteza padrão de xᵢ. Correlações via matriz covariância.",
                    ExemploPratico = "Densidade ρ=m/V: u(ρ)/ρ = √[(u(m)/m)² + (u(V)/V)²]. ISO GUM padrão.",
                    Criador = "ISO GUM (1995, Guia para Expressão da Incerteza de Medição)",
                    AnoOrigin = "1995",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "u(x₁)", Simbolo = "u1", Unidade = "", ValorPadrao = 0.1 },
                        new Variavel { Nome = "u(x₂)", Simbolo = "u2", Unidade = "", ValorPadrao = 0.2 }
                    },
                    VariavelResultado = "u_c",
                    UnidadeResultado = "",
                    Calcular = inputs =>
                    {
                        double u1 = inputs["u(x₁)"];
                        double u2 = inputs["u(x₂)"];
                        // Assume ∂f/∂xᵢ = 1 para simplificação
                        double u_c = Math.Sqrt(u1 * u1 + u2 * u2);
                        return u_c;
                    },
                    Icone = "📐"
                },

                // V10-261: Ponte de Wheatstone
                new Formula
                {
                    Id = "3849",
                    CodigoCompendio = "V10-261",
                    Nome = "Ponte de Wheatstone — Strain Gauge",
                    Categoria = "Instrumentação",
                    SubCategoria = "Transdutores",
                    Expressao = @"V_out/V_in = (R₁/(R₁+R₂) − R₃/(R₃+R₄)); ΔR→strain",
                    Descricao = "Strain gauge: ΔR/R=k·ε (k≈2 gage factor). Quarter bridge: 1 gauge ativo. Full bridge: 4 gauges (sensibilidade×4). Load cell, pressure transducer.",
                    ExemploPratico = "ε=1000µε, k=2, V_in=10V, quarter bridge→ΔV≈(k·ε/4)·V_in=2·0.001/4·10=5mV. Amplificar ×1000→5V ADC.",
                    Criador = "Wheatstone (1843); strain gauge Simmons-Ruge (1938)",
                    AnoOrigin = "1843",
                    VariavelResultado = "V_out",
                    UnidadeResultado = "mV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ε strain (µε)", Simbolo = "epsilon", Unidade = "µε", ValorPadrao = 1000 },
                        new Variavel { Nome = "k gage factor", Simbolo = "k", Unidade = "", ValorPadrao = 2 },
                        new Variavel { Nome = "V_in (V)", Simbolo = "Vin", Unidade = "V", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double epsilon = inputs["ε strain (µε)"];
                        double k = inputs["k gage factor"];
                        double Vin = inputs["V_in (V)"];
                        
                        double epsilon_abs = epsilon * 1e-6;
                        // Quarter bridge
                        double dV = (k * epsilon_abs / 4) * Vin;
                        double V_out_mV = dV * 1000;
                        return V_out_mV;
                    },
                    Icone = "📐"
                },

                // V10-262: LVDT (Linear Variable Differential Transformer)
                new Formula
                {
                    Id = "3850",
                    CodigoCompendio = "V10-262",
                    Nome = "LVDT — Sensibilidade",
                    Categoria = "Instrumentação",
                    SubCategoria = "Transdutores de Deslocamento",
                    Expressao = @"V_out = S·x; S: sensibilidade (mV/mm)",
                    Descricao = "Core ferromagnético move entre bobinas. Primária AC excitation. Secundárias diferencial. Resolução infinita (contactless). Range ±mm a ±cm.",
                    ExemploPratico = "S=100 mV/mm, x=2mm→V_out=200mV. Demodular AC→DC. Precisão 0.1%FS. Non-contact: alta durabilidade. Schaevitz pioneiro.",
                    Criador = "Schaevitz (1946, patente LVDT)",
                    AnoOrigin = "1946",
                    VariavelResultado = "V_out",
                    UnidadeResultado = "mV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "S sensibil (mV/mm)", Simbolo = "S", Unidade = "mV/mm", ValorPadrao = 100 },
                        new Variavel { Nome = "x deslocamento (mm)", Simbolo = "x", Unidade = "mm", ValorPadrao = 2 }
                    },
                    Calcular = inputs =>
                    {
                        double S = inputs["S sensibil (mV/mm)"];
                        double x = inputs["x deslocamento (mm)"];
                        
                        double V_out = S * x;
                        return V_out;
                    },
                    Icone = "📐"
                },

                // V10-263: Termopar (Seebeck)
                new Formula
                {
                    Id = "3851",
                    CodigoCompendio = "V10-263",
                    Nome = "Termopar — Efeito Seebeck",
                    Categoria = "Instrumentação",
                    SubCategoria = "Sensores de Temperatura",
                    Expressao = @"V = α·ΔT; α: coef Seebeck (µV/°C)",
                    Descricao = "Junção metais diferentes. Tipo K (Chromel-Alumel): α≈41 µV/°C, range −200 a +1250°C. Tipo J: Fe-Constantan. Tipo S: Pt-Rh (padrão).",
                    ExemploPratico = "Tipo K: ΔT=500°C→V≈41·500=20500µV=20.5mV. Cold junction compensation (0°C ref). ITS-90 tables NIST.",
                    Criador = "Seebeck (1821, descoberta efeito termoelétrico)",
                    AnoOrigin = "1821",
                    VariavelResultado = "V",
                    UnidadeResultado = "mV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "α coef (µV/°C)", Simbolo = "alpha", Unidade = "µV/°C", ValorPadrao = 41 },
                        new Variavel { Nome = "ΔT (°C)", Simbolo = "dT", Unidade = "°C", ValorPadrao = 500 }
                    },
                    Calcular = inputs =>
                    {
                        double alpha = inputs["α coef (µV/°C)"];
                        double dT = inputs["ΔT (°C)"];
                        
                        double V_uV = alpha * dT;
                        double V_mV = V_uV / 1000;
                        return V_mV;
                    },
                    Icone = "📐"
                },

                // V10-264: RTD (Resistance Temperature Detector)
                new Formula
                {
                    Id = "3852",
                    CodigoCompendio = "V10-264",
                    Nome = "RTD Pt100 — Callendar-Van Dusen",
                    Categoria = "Instrumentação",
                    SubCategoria = "Sensores de Temperatura",
                    Expressao = @"R(T) = R₀(1 + α·T + β·T²); Pt100: R₀=100Ω",
                    Descricao = "Platina: α≈0.00385/°C (padrão IEC751). Precisão ±0.1°C. Range −200 a +850°C. Self-heating: I<1mA. 4-wire elimina lead resistance.",
                    ExemploPratico = "Pt100: T=100°C→R=100·(1+0.385)=138.5Ω. ΔR≈0.385Ω/°C linear. Bridge measure R→lookup table→T.",
                    Criador = "Callendar (1887, Pt resistance thermometry); IEC 751 standard",
                    AnoOrigin = "1887",
                    VariavelResultado = "R",
                    UnidadeResultado = "Ω",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "T temperatura (°C)", Simbolo = "T", Unidade = "°C", ValorPadrao = 100 },
                        new Variavel { Nome = "R₀ (Ω)", Simbolo = "R0", Unidade = "Ω", ValorPadrao = 100 },
                        new Variavel { Nome = "α (/°C)", Simbolo = "alpha", Unidade = "/°C", ValorPadrao = 0.00385 }
                    },
                    Calcular = inputs =>
                    {
                        double T = inputs["T temperatura (°C)"];
                        double R0 = inputs["R₀ (Ω)"];
                        double alpha = inputs["α (/°C)"];
                        
                        double R = R0 * (1 + alpha * T);
                        return R;
                    },
                    Icone = "📐"
                },

                // V10-265: Piezoelétrico
                new Formula
                {
                    Id = "3853",
                    CodigoCompendio = "V10-265",
                    Nome = "Transdutor Piezoelétrico — Carga",
                    Categoria = "Instrumentação",
                    SubCategoria = "Sensores de Força/Aceleração",
                    Expressao = @"Q = d·F; d: constante piezoelétrica (pC/N)",
                    Descricao = "Quartzo: d≈2.3 pC/N. PZT: d≈400 pC/N. Charge amplifier converte Q→V. Acelerômetro: F=m·a. Dynamic measurement (AC coupled).",
                    ExemploPratico = "Accel 100g (980 m/s²), massa 10g→F=9.8N. d=400 pC/N→Q=3920 pC. Amplifier 1mV/pC→V=3.92V. Impact, vibration.",
                    Criador = "Curie brothers (1880, piezoeletricidade); Langevin (1917, transducer)",
                    AnoOrigin = "1880",
                    VariavelResultado = "Q",
                    UnidadeResultado = "pC",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "d constante (pC/N)", Simbolo = "d", Unidade = "pC/N", ValorPadrao = 400 },
                        new Variavel { Nome = "F força (N)", Simbolo = "F", Unidade = "N", ValorPadrao = 9.8 }
                    },
                    Calcular = inputs =>
                    {
                        double d = inputs["d constante (pC/N)"];
                        double F = inputs["F força (N)"];
                        
                        double Q = d * F;
                        return Q;
                    },
                    Icone = "📐"
                },

                // V10-266: Capacitivo (Deslocamento)
                new Formula
                {
                    Id = "3854",
                    CodigoCompendio = "V10-266",
                    Nome = "Sensor Capacitivo — Deslocamento",
                    Categoria = "Instrumentação",
                    SubCategoria = "Sensores de Proximidade",
                    Expressao = @"C = ε₀·ε_r·A/d; d: gap entre placas",
                    Descricao = "ε₀=8.85e-12 F/m. Δd→ΔC linear (pequenos Δd). Resolução sub-nm possível. Non-contact. Probe tip vs target. Calibração vs gap.",
                    ExemploPratico = "A=1 cm², ε_r=1 (air), d=1mm→C≈0.88 pF. Δd=10µm→ΔC≈0.009 pF (detectable). Precision machining, touchscreen.",
                    Criador = "Diversos; tecnologia sensor capacitivo estabelecida 1960s",
                    AnoOrigin = "1960",
                    VariavelResultado = "C",
                    UnidadeResultado = "pF",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "A área (cm²)", Simbolo = "A", Unidade = "cm²", ValorPadrao = 1 },
                        new Variavel { Nome = "d gap (mm)", Simbolo = "d", Unidade = "mm", ValorPadrao = 1 },
                        new Variavel { Nome = "ε_r", Simbolo = "epsilon_r", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double A_cm2 = inputs["A área (cm²)"];
                        double d_mm = inputs["d gap (mm)"];
                        double epsilon_r = inputs["ε_r"];
                        
                        double A_m2 = A_cm2 * 1e-4;
                        double d_m = d_mm * 1e-3;
                        double epsilon_0 = 8.854e-12;
                        
                        double C = epsilon_0 * epsilon_r * A_m2 / d_m;
                        double C_pF = C * 1e12;
                        return C_pF;
                    },
                    Icone = "📐"
                },

                // V10-267: Encoder Óptico
                new Formula
                {
                    Id = "3855",
                    CodigoCompendio = "V10-267",
                    Nome = "Encoder Óptico — Resolução Angular",
                    Categoria = "Instrumentação",
                    SubCategoria = "Sensores de Posição",
                    Expressao = @"Δθ = 360°/N; N: pulsos por revolução (PPR)",
                    Descricao = "Incremental: A/B quadrature (4× resolução). Absolute: Gray code (posição única). Rotary vs linear. N=1000→Δθ=0.36° (quadrature: 0.09°).",
                    ExemploPratico = "N=10000 PPR, quadrature→40000 contagens/rev→Δθ=0.009°=32.4 arcsec. CNC, robótica. Heidenhain alta precisão.",
                    Criador = "Diversos; encoder óptico comercial 1960s (Heidenhain, BEI)",
                    AnoOrigin = "1960",
                    VariavelResultado = "delta_theta",
                    UnidadeResultado = "°",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N PPR", Simbolo = "N", Unidade = "", ValorPadrao = 1000 },
                        new Variavel { Nome = "Quadrature (1=não,4=sim)", Simbolo = "quad", Unidade = "", ValorPadrao = 4 }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["N PPR"];
                        double quad = inputs["Quadrature (1=não,4=sim)"];
                        
                        double delta_theta = 360.0 / (N * quad);
                        return delta_theta;
                    },
                    Icone = "📐"
                },

                // V10-268: Amplificador de Instrumentação (CMRR)
                new Formula
                {
                    Id = "3856",
                    CodigoCompendio = "V10-268",
                    Nome = "CMRR — Rejeição de Modo Comum",
                    Categoria = "Instrumentação",
                    SubCategoria = "Condicionamento de Sinal",
                    Expressao = @"CMRR = 20·log(A_d/A_cm); A_d: ganho diferencial",
                    Descricao = "Common Mode Rejection Ratio. Típico CMRR>80dB (10000:1). INA128, AD620. Rejeita ruído 50/60Hz. 3-opamp topology (Burr-Brown).",
                    ExemploPratico = "A_d=1000, A_cm=0.1→CMRR=20·log(10000)=80dB. Ruído 1V comum-modo→saída 0.1mV. Strain gauge, thermocouple.",
                    Criador = "Burr-Brown (1960s, instrumentation amplifier 3-opamp); Analog Devices (INA series)",
                    AnoOrigin = "1965",
                    VariavelResultado = "CMRR",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "A_d ganho dif", Simbolo = "Ad", Unidade = "", ValorPadrao = 1000 },
                        new Variavel { Nome = "A_cm ganho comum", Simbolo = "Acm", Unidade = "", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double Ad = inputs["A_d ganho dif"];
                        double Acm = inputs["A_cm ganho comum"];
                        
                        if (Acm == 0) return double.PositiveInfinity;
                        double CMRR = 20 * Math.Log10(Ad / Acm);
                        return CMRR;
                    },
                    Icone = "📐"
                },

                // V10-269: ADC Resolução
                new Formula
                {
                    Id = "3857",
                    CodigoCompendio = "V10-269",
                    Nome = "Resolução ADC (LSB)",
                    Categoria = "Instrumentação",
                    SubCategoria = "Conversão Analógico-Digital",
                    Expressao = @"LSB = V_ref/(2^n); n: bits",
                    Descricao = "Quantização: erro ±0.5 LSB. 12-bit: 4096 níveis. 16-bit: 65536. 24-bit: 16.7M (precision data acquisition). ENOB (effective): ruído, INL, DNL.",
                    ExemploPratico = "V_ref=5V, n=12→LSB=5/4096≈1.22mV. Signal 2.5V→contagem 2048. Noise<LSB/2: não degrada. Oversampling melhora ENOB.",
                    Criador = "Diversos; ADC comercial 1960s; Sigma-Delta 1980s (24-bit)",
                    AnoOrigin = "1965",
                    VariavelResultado = "LSB",
                    UnidadeResultado = "mV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "V_ref (V)", Simbolo = "Vref", Unidade = "V", ValorPadrao = 5 },
                        new Variavel { Nome = "n bits", Simbolo = "n", Unidade = "", ValorPadrao = 12 }
                    },
                    Calcular = inputs =>
                    {
                        double Vref = inputs["V_ref (V)"];
                        int n = (int)inputs["n bits"];
                        
                        double LSB = Vref / Math.Pow(2, n);
                        double LSB_mV = LSB * 1000;
                        return LSB_mV;
                    },
                    Icone = "📐"
                },

                // V10-270: Teorema de Nyquist
                new Formula
                {
                    Id = "3858",
                    CodigoCompendio = "V10-270",
                    Nome = "Teorema de Nyquist — Taxa de Amostragem",
                    Categoria = "Instrumentação",
                    SubCategoria = "Aquisição de Dados",
                    Expressao = @"f_s > 2·f_max; f_max: freq máxima sinal",
                    Descricao = "Nyquist rate: 2·f_max mínimo. Prática: f_s≥10·f_max (margem). Anti-aliasing filter (lowpass) antes ADC. Aliasing: f>f_s/2→fold back.",
                    ExemploPratico = "Vibration 1kHz component→f_s>2kHz (mínimo). Usar 10kHz: oversampling, anti-alias filter 1.5kHz cutoff. Audio CD: 44.1 kHz (20kHz max).",
                    Criador = "Nyquist (1928, telegraph transmission theory); Shannon (1949, sampling theorem)",
                    AnoOrigin = "1928",
                    VariavelResultado = "f_s",
                    UnidadeResultado = "Hz",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "f_max (Hz)", Simbolo = "fmax", Unidade = "Hz", ValorPadrao = 1000 },
                        new Variavel { Nome = "Fator oversample", Simbolo = "factor", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double fmax = inputs["f_max (Hz)"];
                        double factor = inputs["Fator oversample"];
                        
                        double f_s = factor * fmax;
                        return f_s;
                    },
                    Icone = "📐"
                },

                // V10-271: Filtro Anti-Aliasing
                new Formula
                {
                    Id = "3859",
                    CodigoCompendio = "V10-271",
                    Nome = "Filtro Anti-Aliasing — Cutoff",
                    Categoria = "Instrumentação",
                    SubCategoria = "Condicionamento de Sinal",
                    Expressao = @"f_c < f_s/2; Butterworth, Chebyshev, Bessel",
                    Descricao = "Lowpass filter antes ADC. Butterworth: flat passband. Chebyshev: ripple, steeper rolloff. Bessel: phase linear. Ordem: 4th-8th típico.",
                    ExemploPratico = "f_s=10kHz→f_c<5kHz (Nyquist). Usar f_c=4kHz (margem). Butterworth 6th order: −120dB @ 5kHz (atenua alias). Active filter (opamp).",
                    Criador = "Butterworth (1930, filter theory); Chebyshev, Bessel topologies 1940s-1950s",
                    AnoOrigin = "1930",
                    VariavelResultado = "f_c",
                    UnidadeResultado = "Hz",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "f_s amostragem (Hz)", Simbolo = "fs", Unidade = "Hz", ValorPadrao = 10000 },
                        new Variavel { Nome = "Margem fator", Simbolo = "margin", Unidade = "", ValorPadrao = 0.8 }
                    },
                    Calcular = inputs =>
                    {
                        double fs = inputs["f_s amostragem (Hz)"];
                        double margin = inputs["Margem fator"];
                        
                        double f_c = (fs / 2) * margin;
                        return f_c;
                    },
                    Icone = "📐"
                },

                // V10-272: Calibração Linear (Least Squares)
                new Formula
                {
                    Id = "3860",
                    CodigoCompendio = "V10-272",
                    Nome = "Calibração Linear — Ajuste Mínimos Quadrados",
                    Categoria = "Instrumentação",
                    SubCategoria = "Calibração e Rastreabilidade",
                    Expressao = @"y = a·x + b; a=(n·Σxy−Σx·Σy)/(n·Σx²−(Σx)²)",
                    Descricao = "Least squares fit: calibration curve. Resíduos: R²>0.999 boa linearidade. Padrões rastreáveis NIST/PTB. ISO 17025 labs.",
                    ExemploPratico = "5 pontos calibração pressure transducer: (0,0.1), (50,2.0), (100,4.1), (150,6.0), (200,8.1)→slope a≈0.04 V/psi, offset b≈0.1V.",
                    Criador = "Legendre (1805, método mínimos quadrados); Gauss (1809, aplicação)",
                    AnoOrigin = "1805",
                    VariavelResultado = "a_slope",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "n pontos", Simbolo = "n", Unidade = "", ValorPadrao = 5 },
                        new Variavel { Nome = "Σxy", Simbolo = "sum_xy", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Σx", Simbolo = "sum_x", Unidade = "", ValorPadrao = 500 },
                        new Variavel { Nome = "Σy", Simbolo = "sum_y", Unidade = "", ValorPadrao = 20 },
                        new Variavel { Nome = "Σx²", Simbolo = "sum_x2", Unidade = "", ValorPadrao = 75000 }
                    },
                    Calcular = inputs =>
                    {
                        double n = inputs["n pontos"];
                        double sum_xy = inputs["Σxy"];
                        double sum_x = inputs["Σx"];
                        double sum_y = inputs["Σy"];
                        double sum_x2 = inputs["Σx²"];
                        
                        double denom = n * sum_x2 - sum_x * sum_x;
                        if (denom == 0) return 0;
                        
                        double a = (n * sum_xy - sum_x * sum_y) / denom;
                        return a;
                    },
                    Icone = "📐"
                },

                // V10-273: Coeficiente de Temperatura
                new Formula
                {
                    Id = "3861",
                    CodigoCompendio = "V10-273",
                    Nome = "Coeficiente de Temperatura (TCO)",
                    Categoria = "Instrumentação",
                    SubCategoria = "Estabilidade Térmica",
                    Expressao = @"TCO = (1/V₀)·(dV/dT); ppm/°C",
                    Descricao = "Temperature coefficient of offset/span. Precision sensors: TCO<10 ppm/°C. Compensation: Rref temperature sensing, digital correction.",
                    ExemploPratico = "Pressure sensor: V₀=5V, dV/dT=0.1mV/°C→TCO=(0.1e-3/5)×10^6=20 ppm/°C. Temp swing 50°C→drift 1000ppm=0.1% (acceptable).",
                    Criador = "Diversos; especificação padrão sensor manufacturers",
                    AnoOrigin = "1970",
                    VariavelResultado = "TCO",
                    UnidadeResultado = "ppm/°C",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "V₀ nominal (V)", Simbolo = "V0", Unidade = "V", ValorPadrao = 5 },
                        new Variavel { Nome = "dV/dT (mV/°C)", Simbolo = "dVdT", Unidade = "mV/°C", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double V0 = inputs["V₀ nominal (V)"];
                        double dVdT_mV = inputs["dV/dT (mV/°C)"];
                        
                        if (V0 == 0) return 0;
                        
                        double dVdT = dVdT_mV / 1000;
                        double TCO = (dVdT / V0) * 1e6;
                        return TCO;
                    },
                    Icone = "📐"
                },

                // V10-274: Histerese
                new Formula
                {
                    Id = "3862",
                    CodigoCompendio = "V10-274",
                    Nome = "Histerese — Máxima Diferença",
                    Categoria = "Instrumentação",
                    SubCategoria = "Características de Sensores",
                    Expressao = @"H = max|y_up − y_down|/span; % FS",
                    Descricao = "Ascending vs descending measurements differ. Mecânico: fricção, folga. Magnético: domínios. Piezoresistivo: stress relaxation. Spec típico: <0.1%FS.",
                    ExemploPratico = "Load cell 100kg FS: subida 50kg→25.05V, descida 50kg→25.00V→H=0.05V/5V span=1% (poor). Good sensor: H<0.05% (50mV).",
                    Criador = "Diversos; conceito fundamental metrologia",
                    AnoOrigin = "1850",
                    VariavelResultado = "H",
                    UnidadeResultado = "%FS",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "max diff (V)", Simbolo = "diff", Unidade = "V", ValorPadrao = 0.05 },
                        new Variavel { Nome = "span (V)", Simbolo = "span", Unidade = "V", ValorPadrao = 5 }
                    },
                    Calcular = inputs =>
                    {
                        double diff = inputs["max diff (V)"];
                        double span = inputs["span (V)"];
                        
                        if (span == 0) return 0;
                        double H = (diff / span) * 100;
                        return H;
                    },
                    Icone = "📐"
                },

                // V10-275: Linearidade (INL)
                new Formula
                {
                    Id = "3863",
                    CodigoCompendio = "V10-275",
                    Nome = "INL — Integral Non-Linearity",
                    Categoria = "Instrumentação",
                    SubCategoria = "Características de Conversores",
                    Expressao = @"INL = max|V_actual − V_ideal|/LSB",
                    Descricao = "Desvio da linha ideal (endpoints fit). ADC: INL<±0.5 LSB bom. DAC idem. Bow-shape, S-shape errors. DNL (differential): step size variation.",
                    ExemploPratico = "12-bit ADC, LSB=1.22mV, INL=±0.5 LSB→±0.61mV max deviation. Midscale code: ideal 2.500V, actual 2.501V→INL=+0.82 LSB (spec violation).",
                    Criador = "Diversos; especificação padrão ADC/DAC desde 1980s",
                    AnoOrigin = "1980",
                    VariavelResultado = "INL",
                    UnidadeResultado = "LSB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "max deviation (mV)", Simbolo = "dev", Unidade = "mV", ValorPadrao = 0.61 },
                        new Variavel { Nome = "LSB (mV)", Simbolo = "LSB", Unidade = "mV", ValorPadrao = 1.22 }
                    },
                    Calcular = inputs =>
                    {
                        double dev = inputs["max deviation (mV)"];
                        double LSB = inputs["LSB (mV)"];
                        
                        if (LSB == 0) return 0;
                        double INL = dev / LSB;
                        return INL;
                    },
                    Icone = "📐"
                },

                // V10-276: Tempo de Resposta (τ)
                new Formula
                {
                    Id = "3864",
                    CodigoCompendio = "V10-276",
                    Nome = "Tempo de Resposta τ (63.2%)",
                    Categoria = "Instrumentação",
                    SubCategoria = "Dinâmica de Sensores",
                    Expressao = @"V(t) = V_final·(1−e^(-t/τ)); 1st order",
                    Descricao = "Constante de tempo térmica, mecânica, elétrica. τ: 63.2% final. 5τ: 99.3% settled. Thermocouple: τ~0.1-10s (gauge dependent). RTD: τ~1-10s.",
                    ExemploPratico = "Thermocouple τ=1s, step 100°C→t=1s: 63°C, t=3s: 95°C, t=5s: 99.3°C. Fast response: bare wire. Slow: sheathed (protection).",
                    Criador = "Diversos; teoria sistemas 1st order (Laplace, Heaviside 1800s)",
                    AnoOrigin = "1850",
                    VariavelResultado = "V_at_t",
                    UnidadeResultado = "% final",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "t tempo (s)", Simbolo = "t", Unidade = "s", ValorPadrao = 1 },
                        new Variavel { Nome = "τ constante (s)", Simbolo = "tau", Unidade = "s", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double t = inputs["t tempo (s)"];
                        double tau = inputs["τ constante (s)"];
                        
                        if (tau == 0) return 100;
                        double fraction = 1 - Math.Exp(-t / tau);
                        double percent = fraction * 100;
                        return percent;
                    },
                    Icone = "📐"
                },

                // V10-277: Ruído (rms)
                new Formula
                {
                    Id = "3865",
                    CodigoCompendio = "V10-277",
                    Nome = "Ruído RMS — Desvio Padrão",
                    Categoria = "Instrumentação",
                    SubCategoria = "Análise de Ruído",
                    Expressao = @"V_rms = √(Σ(V_i − V_mean)²/n); n: samples",
                    Descricao = "Ruído térmico (Johnson-Nyquist), 1/f (flicker), shot noise. SNR=20·log(V_signal/V_noise). Spec: µV rms típico precision. Averaging reduz √n.",
                    ExemploPratico = "ADC: 100 samples, V_mean=5.000V, σ=0.5mV rms→SNR=20·log(5000/0.5)≈80dB. 100× averaging→σ/√100=0.05mV→SNR=100dB.",
                    Criador = "Johnson (1928, thermal noise); Nyquist (1928, noise theory)",
                    AnoOrigin = "1928",
                    VariavelResultado = "V_rms",
                    UnidadeResultado = "µV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ desvio padrão (µV)", Simbolo = "sigma", Unidade = "µV", ValorPadrao = 500 },
                        new Variavel { Nome = "n samples average", Simbolo = "n", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double sigma = inputs["σ desvio padrão (µV)"];
                        double n = inputs["n samples average"];
                        
                        double V_rms = sigma / Math.Sqrt(n);
                        return V_rms;
                    },
                    Icone = "📐"
                },

                // V10-278: Rastreabilidade (Cadeia Calibração)
                new Formula
                {
                    Id = "3866",
                    CodigoCompendio = "V10-278",
                    Nome = "Rastreabilidade — Cadeia Metrológica",
                    Categoria = "Instrumentação",
                    SubCategoria = "Calibração e Rastreabilidade",
                    Expressao = @"u_total² = u_ref² + u_transfer² + u_drift²",
                    Descricao = "Padrão primário (NIST/PTB)→secundário→trabalho→DUT. Cada transfer adiciona incerteza. ISO 17025 labs. CMC (calibration measurement capability).",
                    ExemploPratico = "Pressure: primary piston gauge (u=10 ppm)→transfer standard (u=20 ppm)→working (u=50 ppm)→u_total=√(10²+20²+50²)≈55 ppm.",
                    Criador = "Diversos; SI units metrological hierarchy estabelecida 1960 (BIPM)",
                    AnoOrigin = "1960",
                    VariavelResultado = "u_total",
                    UnidadeResultado = "ppm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "u_ref (ppm)", Simbolo = "uref", Unidade = "ppm", ValorPadrao = 10 },
                        new Variavel { Nome = "u_transfer (ppm)", Simbolo = "utrans", Unidade = "ppm", ValorPadrao = 20 },
                        new Variavel { Nome = "u_drift (ppm)", Simbolo = "udrift", Unidade = "ppm", ValorPadrao = 50 }
                    },
                    Calcular = inputs =>
                    {
                        double uref = inputs["u_ref (ppm)"];
                        double utrans = inputs["u_transfer (ppm)"];
                        double udrift = inputs["u_drift (ppm)"];
                        
                        double u_total = Math.Sqrt(uref * uref + utrans * utrans + udrift * udrift);
                        return u_total;
                    },
                    Icone = "📐"
                },

                // V10-279: Relação Sinal-Ruído (SNR)
                new Formula
                {
                    Id = "3867",
                    CodigoCompendio = "V10-279",
                    Nome = "SNR — Signal-to-Noise Ratio",
                    Categoria = "Instrumentação",
                    SubCategoria = "Qualidade de Sinal",
                    Expressao = @"SNR_dB = 20·log₁₀(V_signal/V_noise)",
                    Descricao = "SNR alto: melhor resolução. ADC: SNR≈6.02·ENOB+1.76 dB teórico. Shield, guard, differential reduce noise. Averaging: SNR melhora 10log(n) dB.",
                    ExemploPratico = "Signal 5V rms, Noise 0.5mV rms→SNR=20·log(5000/0.5)≈80dB. 12-bit ADC ideal: SNR≈74dB. 16-bit: SNR≈98dB. Audio CD: SNR≈96dB.",
                    Criador = "Shannon (1948, communication theory SNR capacity)",
                    AnoOrigin = "1948",
                    VariavelResultado = "SNR",
                    UnidadeResultado = "dB",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "V_signal (V)", Simbolo = "Vsig", Unidade = "V", ValorPadrao = 5 },
                        new Variavel { Nome = "V_noise (mV)", Simbolo = "Vnoise", Unidade = "mV", ValorPadrao = 0.5 }
                    },
                    Calcular = inputs =>
                    {
                        double Vsig = inputs["V_signal (V)"];
                        double Vnoise_mV = inputs["V_noise (mV)"];
                        
                        if (Vnoise_mV == 0) return double.PositiveInfinity;
                        
                        double Vnoise = Vnoise_mV / 1000;
                        double SNR = 20 * Math.Log10(Vsig / Vnoise);
                        return SNR;
                    },
                    Icone = "📐"
                }
            });
        }
    }
}
