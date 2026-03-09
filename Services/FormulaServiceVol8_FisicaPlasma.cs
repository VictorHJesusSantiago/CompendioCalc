using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XIII: FÍSICA DE PLASMA
    // Debye length, plasma frequency, MHD, fusão nuclear, confinamento magnético
    // 15 fórmulas (244-258)
    // ========================================

    public static Formula V8_PLASMA244_ComprimentoDebye()
    {
        return new Formula
        {
            Id = "V8-PLASMA244",
            CodigoCompendio = "244",
            Nome = "Comprimento de Debye — λD",
            Categoria = "Física de Plasma",
            SubCategoria = "Parâmetros Fundamentais",
            Expressao = "λ_D = sqrt(ε0 * k_B * T_e / (n_e * e²))",
            ExprTexto = "Debye length",
            Descricao = "ε0=permissividade vácuo, T_e=temperatura eletrôns (K), n_e=densidade, e=carga e. Blindagem eletrostática.",
            Criador = "Peter Debye e Erich Hückel",
            AnoOrigin = "1923",
            ExemploPratico = "T_e=1eV≈11600K, n_e=10^16 m^-3 → λ_D≈7,4μm. Plasma: sistemas λ>>λ_D",
            Unidades = "m",
            VariavelResultado = "lambda_D",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T_e", Nome = "T_e", Descricao = "Temp. eletrôns", Unidade = "K", ValorPadrao = 11600, ValorMin = 100, ValorMax = 1e8, Obrigatoria = true },
                new() { Simbolo = "n_e", Nome = "n_e", Descricao = "Densidade eletrôns", Unidade = "m^-3", ValorPadrao = 1e16, ValorMin = 1e12, ValorMax = 1e30, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T_e = inputs["T_e"];
                double n_e = inputs["n_e"];
                
                // Constantes
                double epsilon_0 = 8.854e-12; // F/m
                double k_B = 1.380649e-23; // J/K
                double e = 1.602e-19; // C
                
                return Math.Sqrt((epsilon_0 * k_B * T_e) / (n_e * e * e));
            }
        };
    }

    public static Formula V8_PLASMA245_FrequenciaPlasma()
    {
        return new Formula
        {
            Id = "V8-PLASMA245",
            CodigoCompendio = "245",
            Nome = "Frequência de Plasma — ωpe",
            Categoria = "Física de Plasma",
            SubCategoria = "Parâmetros Fundamentais",
            Expressao = "ω_pe = sqrt(n_e * e² / (ε0 * m_e))",
            ExprTexto = "Plasma frequency",
            Descricao = "n_e=densidade eletrôns, e=carga, m_e=massa eletrôn. Oscilação coletiva eletrôns. Langmuir 1928.",
            Criador = "Irving Langmuir",
            AnoOrigin = "1928",
            ExemploPratico = "n_e=10^18 m^-3 → f_pe≈9GHz. Ondas EM f<f_pe: refletidas (ionosfera)",
            Unidades = "rad/s",
            VariavelResultado = "omega_pe",
            UnidadeResultado = "rad/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n_e", Nome = "n_e", Descricao = "Densidade eletrôns", Unidade = "m^-3", ValorPadrao = 1e18, ValorMin = 1e12, ValorMax = 1e30, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n_e = inputs["n_e"];
                
                double epsilon_0 = 8.854e-12;
                double e = 1.602e-19;
                double m_e = 9.109e-31; // kg
                
                return Math.Sqrt((n_e * e * e) / (epsilon_0 * m_e));
            }
        };
    }

    public static Formula V8_PLASMA246_FrequenciaCiclotron()
    {
        return new Formula
        {
            Id = "V8-PLASMA246",
            CodigoCompendio = "246",
            Nome = "Frequência de Cíclotron — ωc",
            Categoria = "Física de Plasma",
            SubCategoria = "Plasma Magnetizado",
            Expressao = "ω_c = (q * B) / m",
            ExprTexto = "Cyclotron frequency",
            Descricao = "q=carga partícula, B=campo magnético, m=massa. Gyrofrequency: partícula espirala em B.",
            Criador = "Ernest Lawrence (cíclotron)",
            AnoOrigin = "1929",
            ExemploPratico = "B=1T, eletrôn → f_ce≈28GHz. Próton: f_cp≈15MHz (mp/me≈1836)",
            Unidades = "rad/s",
            VariavelResultado = "omega_c",
            UnidadeResultado = "rad/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "q", Nome = "Carga", Descricao = "q", Unidade = "C", ValorPadrao = 1.602e-19, ValorMin = 1e-20, ValorMax = 1e-18, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Campo B", Descricao = "B", Unidade = "T", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "Massa", Descricao = "m", Unidade = "kg", ValorPadrao = 9.109e-31, ValorMin = 1e-32, ValorMax = 1e-25, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double q = inputs["q"];
                double B = inputs["B"];
                double m = inputs["m"];
                
                return (q * B) / m;
            }
        };
    }

    public static Formula V8_PLASMA247_RaioLarmor()
    {
        return new Formula
        {
            Id = "V8-PLASMA247",
            CodigoCompendio = "247",
            Nome = "Raio de Larmor — rL",
            Categoria = "Física de Plasma",
            SubCategoria = "Plasma Magnetizado",
            Expressao = "r_L = (m * v_perp) / (q * B)",
            ExprTexto = "Larmor radius (gyroradius)",
            Descricao = "v_perp=velocidade perpendicular a B. Raio órbita hélicoidal. Larmor 1897.",
            Criador = "Joseph Larmor",
            AnoOrigin = "1897",
            ExemploPratico = "v_perp=10^6 m/s, B=1T, eletrôn → r_L≈0,006mm. Tokamak: r_L<<raio plasma",
            Unidades = "m",
            VariavelResultado = "r_L",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Massa", Descricao = "m", Unidade = "kg", ValorPadrao = 9.109e-31, ValorMin = 1e-32, ValorMax = 1e-25, Obrigatoria = true },
                new() { Simbolo = "v_perp", Nome = "v⊥", Descricao = "Velocidade perp.", Unidade = "m/s", ValorPadrao = 1e6, ValorMin = 100, ValorMax = 1e8, Obrigatoria = true },
                new() { Simbolo = "q", Nome = "Carga", Descricao = "q", Unidade = "C", ValorPadrao = 1.602e-19, ValorMin = 1e-20, ValorMax = 1e-18, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Campo B", Descricao = "B", Unidade = "T", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double v_perp = inputs["v_perp"];
                double q = inputs["q"];
                double B = inputs["B"];
                
                return (m * v_perp) / (q * B);
            }
        };
    }

    public static Formula V8_PLASMA248_VelocidadeAlfven()
    {
        return new Formula
        {
            Id = "V8-PLASMA248",
            CodigoCompendio = "248",
            Nome = "Velocidade de Alfvén — vA",
            Categoria = "Física de Plasma",
            SubCategoria = "MHD (Magnetohidrodinâmica)",
            Expressao = "v_A = B / sqrt(μ0 * ρ)",
            ExprTexto = "Alfvén velocity",
            Descricao = "B=campo magnético, μ0=permeabilidade, ρ=densidade massa. Ondas Alfvén: MHD ideal. Nobel 1970.",
            Criador = "Hannes Alfvén",
            AnoOrigin = "1942",
            ExemploPratico = "B=0,1T, n=10^19 m^-3 (H plasma ρ≈1,67e-8 kg/m³) → v_A≈2,2×10^6 m/s. Tokamak típico",
            Unidades = "m/s",
            VariavelResultado = "v_A",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "B", Nome = "Campo B", Descricao = "B", Unidade = "T", ValorPadrao = 0.1, ValorMin = 1e-6, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "ρ", Descricao = "Densidade massa", Unidade = "kg/m^3", ValorPadrao = 1.67e-8, ValorMin = 1e-15, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double B = inputs["B"];
                double rho = inputs["rho"];
                
                double mu_0 = 4 * Math.PI * 1e-7; // H/m
                
                return B / Math.Sqrt(mu_0 * rho);
            }
        };
    }

    public static Formula V8_PLASMA249_Beta_Plasma()
    {
        return new Formula
        {
            Id = "V8-PLASMA249",
            CodigoCompendio = "249",
            Nome = "Beta do Plasma — β",
            Categoria = "Física de Plasma",
            SubCategoria = "Confinamento Magnético",
            Expressao = "β = (2 * μ0 * p) / B²",
            ExprTexto = "Plasma beta",
            Descricao = "p=pressão plasma, B=campo. β=razão pressão cinética/magnética. β<<1: dominado campo. ITER: β~5%.",
            Criador = "Física de fusão",
            AnoOrigin = "~1950s",
            ExemploPratico = "p=10^5 Pa, B=5T → β≈0,01 (1%). Tokamak: β<10%. Z-pinch: β~1 (instável)",
            Unidades = "adimensional",
            VariavelResultado = "beta",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "p", Nome = "Pressão", Descricao = "p", Unidade = "Pa", ValorPadrao = 1e5, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Campo B", Descricao = "B", Unidade = "T", ValorPadrao = 5, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double p = inputs["p"];
                double B = inputs["B"];
                
                double mu_0 = 4 * Math.PI * 1e-7;
                
                return (2 * mu_0 * p) / (B * B);
            }
        };
    }

    public static Formula V8_PLASMA250_CriterioLawson()
    {
        return new Formula
        {
            Id = "V8-PLASMA250",
            CodigoCompendio = "250",
            Nome = "Critério de Lawson — Fusão D-T",
            Categoria = "Física de Plasma",
            SubCategoria = "Fusão Nuclear",
            Expressao = "n * τ_E ≥ 10^20 m^-3·s (T≈10keV)",
            ExprTexto = "Lawson criterion",
            Descricao = "n=densidade, τ_E=tempo confinamento energia. D-T: n·τ_E≥10^20. Ignição: Q=∞. Lawson 1957.",
            Criador = "John D. Lawson",
            AnoOrigin = "1957",
            ExemploPratico = "ITER: n≈10^20 m^-3, τ_E≈3s → n·τ_E≈3×10^20 (Q≈10). NIF: confinamento inercial",
            Unidades = "m^-3·s",
            VariavelResultado = "n_tau",
            UnidadeResultado = "m^-3·s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "n", Descricao = "Densidade", Unidade = "m^-3", ValorPadrao = 1e20, ValorMin = 1e18, ValorMax = 1e25, Obrigatoria = true },
                new() { Simbolo = "tau_E", Nome = "τ_E", Descricao = "Tempo confinamento", Unidade = "s", ValorPadrao = 3, ValorMin = 1e-9, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double tau_E = inputs["tau_E"];
                
                return n * tau_E;
            }
        };
    }

    public static Formula V8_PLASMA251_TaxaReacaoFusaoDT()
    {
        return new Formula
        {
            Id = "V8-PLASMA251",
            CodigoCompendio = "251",
            Nome = "Taxa de Reação Fusão D-T — <σv>",
            Categoria = "Física de Plasma",
            SubCategoria = "Fusão Nuclear",
            Expressao = "R = n_D * n_T * <σv>",
            ExprTexto = "Fusion rate",
            Descricao = "n_D,n_T=densidades, <σv>=reatividade (m³/s). D+T→⁴He+n+17,6MeV. Pico <σv> a T≈70keV.",
            Criador = "Física nuclear",
            AnoOrigin = "~1950s",
            ExemploPratico = "n_D=n_T=5×10^19 m^-3, <σv>≈10^-22 m³/s (T=10keV) → R≈2,5×10^17 reações/(m³·s)",
            Unidades = "reações/(m^3·s)",
            VariavelResultado = "R",
            UnidadeResultado = "reações/(m^3·s)",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n_D", Nome = "n_D", Descricao = "Densidade D", Unidade = "m^-3", ValorPadrao = 5e19, ValorMin = 1e18, ValorMax = 1e25, Obrigatoria = true },
                new() { Simbolo = "n_T", Nome = "n_T", Descricao = "Densidade T", Unidade = "m^-3", ValorPadrao = 5e19, ValorMin = 1e18, ValorMax = 1e25, Obrigatoria = true },
                new() { Simbolo = "sigma_v", Nome = "<σv>", Descricao = "Reatividade", Unidade = "m^3/s", ValorPadrao = 1e-22, ValorMin = 1e-30, ValorMax = 1e-20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n_D = inputs["n_D"];
                double n_T = inputs["n_T"];
                double sigma_v = inputs["sigma_v"];
                
                return n_D * n_T * sigma_v;
            }
        };
    }

    public static Formula V8_PLASMA252_PotenciaFusao()
    {
        return new Formula
        {
            Id = "V8-PLASMA252",
            CodigoCompendio = "252",
            Nome = "Potência de Fusão — P_fus",
            Categoria = "Física de Plasma",
            SubCategoria = "Fusão Nuclear",
            Expressao = "P_fus = R * E_fus * V",
            ExprTexto = "Fusion power",
            Descricao = "R=taxa reação, E_fus=energia/reação (17,6MeV para D-T), V=volume plasma. Watts.",
            Criador = "Engenharia de fusão",
            AnoOrigin = "~1960s",
            ExemploPratico = "R=2,5×10^17 m^-3·s, E=17,6MeV≈2,8×10^-12 J, V=1000m³ → P≈700MW (ITER-like)",
            Unidades = "W",
            VariavelResultado = "P_fus",
            UnidadeResultado = "W",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R", Nome = "R", Descricao = "Taxa reação", Unidade = "m^-3·s^-1", ValorPadrao = 2.5e17, ValorMin = 0, ValorMax = 1e25, Obrigatoria = true },
                new() { Simbolo = "E_fus", Nome = "E_fus", Descricao = "Energia/reação", Unidade = "J", ValorPadrao = 2.8e-12, ValorMin = 1e-13, ValorMax = 1e-10, Obrigatoria = true },
                new() { Simbolo = "V", Nome = "Volume", Descricao = "V", Unidade = "m^3", ValorPadrao = 1000, ValorMin = 0.001, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R = inputs["R"];
                double E_fus = inputs["E_fus"];
                double V = inputs["V"];
                
                return R * E_fus * V;
            }
        };
    }

    public static Formula V8_PLASMA253_FatorQ_Fusao()
    {
        return new Formula
        {
            Id = "V8-PLASMA253",
            CodigoCompendio = "253",
            Nome = "Fator de Ganho Fusão — Q",
            Categoria = "Física de Plasma",
            SubCategoria = "Fusão Nuclear",
            Expressao = "Q = P_fus / P_heat",
            ExprTexto = "Fusion Q",
            Descricao = "P_fus=potência fusão, P_heat=potência aquecimento. Q=1: break-even. Q=10: ITER. Q=∞: ignição.",
            Criador = "Engenharia de fusão",
            AnoOrigin = "~1970s",
            ExemploPratico = "P_fus=500MW, P_heat=50MW → Q=10 (ITER objetivo). NIF 2022: Q>1 (confinamento inercial)",
            Unidades = "adimensional",
            VariavelResultado = "Q",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P_fus", Nome = "P_fus", Descricao = "Potência fusão", Unidade = "W", ValorPadrao = 5e8, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "P_heat", Nome = "P_heat", Descricao = "Potência aquecim.", Unidade = "W", ValorPadrao = 5e7, ValorMin = 1e3, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P_fus = inputs["P_fus"];
                double P_heat = inputs["P_heat"];
                
                return P_fus / P_heat;
            }
        };
    }

    public static Formula V8_PLASMA254_EquacaoSaha()
    {
        return new Formula
        {
            Id = "V8-PLASMA254",
            CodigoCompendio = "254",
            Nome = "Equação de Saha — Ionização Térmica",
            Categoria = "Física de Plasma",
            SubCategoria = "Equilíbrio Termodinâmico",
            Expressao = "n_i * n_e / n_0 = (2 * π * m_e * k_B * T / h²)^(3/2) * (g_i/g_0) * exp(-E_ion/(k_B*T))",
            ExprTexto = "Saha equation",
            Descricao = "n_i,n_e,n_0=densidades (íon, eletrôn, neutro), E_ion=energia ionização, g=pesos estatísticos. Saha 1920.",
            Criador = "Meghnad Saha",
            AnoOrigin = "1920",
            ExemploPratico = "Hidrogênio: E_ion=13,6eV. T=10000K → parcialmente ionizado. T>50000K: totalmente ionizado",
            Unidades = "adimensional (razão)",
            VariavelResultado = "ratio_approx",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T", Nome = "T", Descricao = "Temperatura", Unidade = "K", ValorPadrao = 10000, ValorMin = 1000, ValorMax = 1e8, Obrigatoria = true },
                new() { Simbolo = "E_ion", Nome = "E_ion", Descricao = "Energia ionização", Unidade = "eV", ValorPadrao = 13.6, ValorMin = 1, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T = inputs["T"];
                double E_ion_eV = inputs["E_ion"];
                
                double k_B = 1.380649e-23; // J/K
                double E_ion = E_ion_eV * 1.602e-19; // J
                
                // Parte exponencial (dominante)
                return Math.Exp(-E_ion / (k_B * T));
            }
        };
    }

    public static Formula V8_PLASMA255_DifusaoBohm()
    {
        return new Formula
        {
            Id = "V8-PLASMA255",
            CodigoCompendio = "255",
            Nome = "Difusão de Bohm — DB",
            Categoria = "Física de Plasma",
            SubCategoria = "Transporte",
            Expressao = "D_B = (1/16) * (k_B * T_e) / (e * B)",
            ExprTexto = "Bohm diffusion",
            Descricao = "T_e=temperatura eletrôns, B=campo. Limite empírico difusão perpendicular. David Bohm 1949.",
            Criador = "David Bohm",
            AnoOrigin = "1949",
            ExemploPratico = "T_e=1keV≈1,16×10^7K, B=5T → D_B≈0,3m²/s. Tokamaks modernos: neoclássico < Bohm",
            Unidades = "m^2/s",
            VariavelResultado = "D_B",
            UnidadeResultado = "m^2/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T_e", Nome = "T_e", Descricao = "Temp. eletrôns", Unidade = "K", ValorPadrao = 1.16e7, ValorMin = 1000, ValorMax = 1e8, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Campo B", Descricao = "B", Unidade = "T", ValorPadrao = 5, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T_e = inputs["T_e"];
                double B = inputs["B"];
                
                double k_B = 1.380649e-23;
                double e = 1.602e-19;
                
                return (1.0 / 16.0) * (k_B * T_e) / (e * B);
            }
        };
    }

    public static Formula V8_PLASMA256_VelocidadeDriftE_CrossB()
    {
        return new Formula
        {
            Id = "V8-PLASMA256",
            CodigoCompendio = "256",
            Nome = "Velocidade Drift E×B",
            Categoria = "Física de Plasma",
            SubCategoria = "Plasma Magnetizado",
            Expressao = "v_drift = E × B / B²",
            ExprTexto = "E×B drift",
            Descricao = "E=campo elétrico, B=campo magnético. Deriva perpendicular E e B. Independente carga/massa.",
            Criador = "Movimento partícula carregada",
            AnoOrigin = "~1950s",
            ExemploPratico = "E=1000V/m, B=1T → v_drift=1000m/s. Deriva elétrons e íons mesma direção",
            Unidades = "m/s",
            VariavelResultado = "v_drift",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E", Nome = "E", Descricao = "Campo elétrico", Unidade = "V/m", ValorPadrao = 1000, ValorMin = 0.01, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "B", Descricao = "Campo magnético", Unidade = "T", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E = inputs["E"];
                double B = inputs["B"];
                
                return E / B; // Magnitude |E×B|/B² assumindo E⊥B
            }
        };
    }

    public static Formula V8_PLASMA257_TempoConfinamentoEnergia()
    {
        return new Formula
        {
            Id = "V8-PLASMA257",
            CodigoCompendio = "257",
            Nome = "Tempo de Confinamento de Energia — τE",
            Categoria = "Física de Plasma",
            SubCategoria = "Confinamento Magnético",
            Expressao = "τ_E = W / P_loss",
            ExprTexto = "Energy confinement time",
            Descricao = "W=energia térmica plasma, P_loss=potência perdida (radiação, condução, convecção). Tokamak: τ_E~s.",
            Criador = "Física de fusão",
            AnoOrigin = "~1960s",
            ExemploPratico = "W=300MJ, P_loss=100MW → τ_E=3s. ITER: τ_E~3-4s esperado. Escalamento: IPB98(y,2)",
            Unidades = "s",
            VariavelResultado = "tau_E",
            UnidadeResultado = "s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "W", Nome = "W", Descricao = "Energia térmica", Unidade = "J", ValorPadrao = 3e8, ValorMin = 1e3, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "P_loss", Nome = "P_loss", Descricao = "Potência perdida", Unidade = "W", ValorPadrao = 1e8, ValorMin = 1e3, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double W = inputs["W"];
                double P_loss = inputs["P_loss"];
                
                return W / P_loss;
            }
        };
    }

    public static Formula V8_PLASMA258_PressaoMagnetica()
    {
        return new Formula
        {
            Id = "V8-PLASMA258",
            CodigoCompendio = "258",
            Nome = "Pressão Magnética — P_mag",
            Categoria = "Física de Plasma",
            SubCategoria = "MHD (Magnetohidrodinâmica)",
            Expressao = "P_mag = B² / (2 * μ0)",
            ExprTexto = "Magnetic pressure",
            Descricao = "B=campo magnético, μ0=permeabilidade. Força magnética por unidade área. Confina plasma.",
            Criador = "Eletromagnetismo / MHD",
            AnoOrigin = "~1940s",
            ExemploPratico = "B=5T → P_mag≈10MPa≈100atm. ITER: B~5,3T. Pinch magnético: P_mag equilibra P_plasma",
            Unidades = "Pa",
            VariavelResultado = "P_mag",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "B", Nome = "Campo B", Descricao = "B", Unidade = "T", ValorPadrao = 5, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double B = inputs["B"];
                
                double mu_0 = 4 * Math.PI * 1e-7;
                
                return (B * B) / (2 * mu_0);
            }
        };
    }
}
