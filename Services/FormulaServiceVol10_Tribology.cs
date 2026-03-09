using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XIII
    /// TRIBOLOGIA E LUBRIFICAÇÃO
    /// Fórmulas V10-239 a V10-259 (21 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_Tribology()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3827",
                    CodigoCompendio = "V10-239",
                    Nome = "Lei de Coulomb do Atrito",
                    Categoria = "Tribologia",
                    SubCategoria = "Atrito e Desgaste",
                    Expressao = @"F_f = μ·N",
                    Descricao = "Força de atrito proporcional à força normal. μ: coeficiente de atrito (estático ou dinâmico). Independente da área de contato (idealmente).",
                    ExemploPratico = "Aço-aço seco: μ_s≈0.8, μ_k≈0.6. Teflon-aço: μ≈0.04. Lubrificação reduz μ.",
                    Criador = "Coulomb (1785, teoria do atrito)",
                    AnoOrigin = "1785",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Coef atrito μ", Simbolo = "μ", Unidade = "", ValorPadrao = 0.6 },
                        new Variavel { Nome = "Força normal N (N)", Simbolo = "N", Unidade = "N", ValorPadrao = 100 }
                    },
                    VariavelResultado = "F_f",
                    UnidadeResultado = "N",
                    Calcular = inputs =>
                    {
                        double mu = inputs["Coef atrito μ"];
                        double N = inputs["Força normal N (N)"];
                        double F_f = mu * N;
                        return F_f;
                    },
                    Icone = "⚙️"
                },

                // V10-240: Curva de Stribeck
                new Formula
                {
                    Id = "3828",
                    CodigoCompendio = "V10-240",
                    Nome = "Curva de Stribeck — Regimes de Lubrificação",
                    Categoria = "Tribologia",
                    SubCategoria = "Lubrificação",
                    Expressao = @"μ = f(η·v/p); Boundary→Mixed→Hydrodynamic",
                    Descricao = "η: viscosidade, v: velocidade, p: pressão. Boundary: μ alto (contato aspereza). Hydrodyn: μ baixo (filme fluido separa). Mixed: transição.",
                    ExemploPratico = "Motor start: boundary (μ≈0.1). Running: hydrodynamic (μ≈0.001). Stribeck number S=ηv/(pR_a), S<0.1 boundary, S>10 hydrodynamic.",
                    Criador = "Stribeck (1902, curva experimental); Hersey (1914, número adimensional)",
                    AnoOrigin = "1902",
                    VariavelResultado = "regime",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "η viscosidade (Pa·s)", Simbolo = "eta", Unidade = "Pa·s", ValorPadrao = 0.1 },
                        new Variavel { Nome = "v velocidade (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 10 },
                        new Variavel { Nome = "p pressão (MPa)", Simbolo = "p", Unidade = "MPa", ValorPadrao = 5 }
                    },
                    Calcular = inputs =>
                    {
                        double eta = inputs["η viscosidade (Pa·s)"];
                        double v = inputs["v velocidade (m/s)"];
                        double p = inputs["p pressão (MPa)"];
                        
                        if (p == 0) return 0;
                        double p_Pa = p * 1e6;
                        double S = eta * v / p_Pa * 1e6; // Stribeck number (adimensional, scaled)
                        
                        // Regime: 0=boundary, 1=mixed, 2=hydrodynamic
                        double regime = S < 1 ? 0 : (S < 10 ? 1 : 2);
                        return regime;
                    },
                    Icone = "⚙️"
                },

                // V10-241: Desgaste por Archard
                new Formula
                {
                    Id = "3829",
                    CodigoCompendio = "V10-241",
                    Nome = "Equação de Archard — Taxa de Desgaste",
                    Categoria = "Tribologia",
                    SubCategoria = "Desgaste",
                    Expressao = @"V = k·(W·s)/H; k: coef desgaste adimensional",
                    Descricao = "V: volume desgastado, W: carga, s: distância deslizamento, H: dureza. k≈10^-3 (severo) a 10^-8 (mild). Adesivo, abrasivo, fadiga.",
                    ExemploPratico = "Aço: H=2GPa, W=100N, s=1000m, k=10^-5→V=100·1000·10^-5/(2×10^9)=5×10^-10 m³=0.5 mm³. Coating duro reduz k.",
                    Criador = "Archard (1953, contact and rubbing theory)",
                    AnoOrigin = "1953",
                    VariavelResultado = "V",
                    UnidadeResultado = "mm³",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k coef", Simbolo = "k", Unidade = "", ValorPadrao = 1e-5 },
                        new Variavel { Nome = "W carga (N)", Simbolo = "W", Unidade = "N", ValorPadrao = 100 },
                        new Variavel { Nome = "s distância (m)", Simbolo = "s", Unidade = "m", ValorPadrao = 1000 },
                        new Variavel { Nome = "H dureza (GPa)", Simbolo = "H", Unidade = "GPa", ValorPadrao = 2 }
                    },
                    Calcular = inputs =>
                    {
                        double k = inputs["k coef"];
                        double W = inputs["W carga (N)"];
                        double s = inputs["s distância (m)"];
                        double H = inputs["H dureza (GPa)"];
                        
                        if (H == 0) return 0;
                        double H_Pa = H * 1e9;
                        double V_m3 = k * W * s / H_Pa;
                        double V_mm3 = V_m3 * 1e9;
                        return V_mm3;
                    },
                    Icone = "⚙️"
                },

                // V10-242: Número de Reynolds (Lubrificação)
                new Formula
                {
                    Id = "3830",
                    CodigoCompendio = "V10-242",
                    Nome = "Reynolds — Lubrificação Hidrodinâmica",
                    Categoria = "Tribologia",
                    SubCategoria = "Lubrificação Fluida",
                    Expressao = @"Re = ρ·v·h/η; transição laminar-turbulento",
                    Descricao = "h: espessura filme. Re<2000: laminar (Reynolds eq válida). Re>2000: turbulento (instabilidade). Mancal: típico Re<100 (laminar).",
                    ExemploPratico = "Óleo ρ=900 kg/m³, η=0.05 Pa·s, v=5 m/s, h=50µm→Re=900·5·50e-6/0.05=4.5 (laminar). Journal bearing: laminar usual.",
                    Criador = "Reynolds (1886, theory of lubrication); Osborne Reynolds (Nobel-level pioneer)",
                    AnoOrigin = "1886",
                    VariavelResultado = "Re",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ρ (kg/m³)", Simbolo = "rho", Unidade = "kg/m³", ValorPadrao = 900 },
                        new Variavel { Nome = "v (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 5 },
                        new Variavel { Nome = "h espessura (µm)", Simbolo = "h", Unidade = "µm", ValorPadrao = 50 },
                        new Variavel { Nome = "η (Pa·s)", Simbolo = "eta", Unidade = "Pa·s", ValorPadrao = 0.05 }
                    },
                    Calcular = inputs =>
                    {
                        double rho = inputs["ρ (kg/m³)"];
                        double v = inputs["v (m/s)"];
                        double h_um = inputs["h espessura (µm)"];
                        double eta = inputs["η (Pa·s)"];
                        
                        if (eta == 0) return 0;
                        double h_m = h_um * 1e-6;
                        double Re = rho * v * h_m / eta;
                        return Re;
                    },
                    Icone = "⚙️"
                },

                // V10-243: Sommerfeld Number
                new Formula
                {
                    Id = "3831",
                    CodigoCompendio = "V10-243",
                    Nome = "Número de Sommerfeld — Mancais",
                    Categoria = "Tribologia",
                    SubCategoria = "Mancais Hidrodinâmicos",
                    Expressao = @"S = (η·n/p)·(R/C)²; n: rotação rps",
                    Descricao = "R: raio eixo, C: folga radial. S alto: filme grosso (hydrodyn). S baixo: filme fino (boundary risk). Design: S>1 típico.",
                    ExemploPratico = "η=0.03 Pa·s, n=50 rps (3000 rpm), p=2 MPa, R=50mm, C=0.1mm→(R/C)²=250000, S≈0.03·50/(2×10^6)·250000≈0.19. S<1: risco!",
                    Criador = "Sommerfeld (1904, hidrodinâmica mancais); Gümbel (1914, análise)",
                    AnoOrigin = "1904",
                    VariavelResultado = "S",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "η (Pa·s)", Simbolo = "eta", Unidade = "Pa·s", ValorPadrao = 0.03 },
                        new Variavel { Nome = "n rotação (rps)", Simbolo = "n", Unidade = "rps", ValorPadrao = 50 },
                        new Variavel { Nome = "p pressão (MPa)", Simbolo = "p", Unidade = "MPa", ValorPadrao = 2 },
                        new Variavel { Nome = "R raio (mm)", Simbolo = "R", Unidade = "mm", ValorPadrao = 50 },
                        new Variavel { Nome = "C folga (mm)", Simbolo = "C", Unidade = "mm", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double eta = inputs["η (Pa·s)"];
                        double n = inputs["n rotação (rps)"];
                        double p = inputs["p pressão (MPa)"];
                        double R = inputs["R raio (mm)"];
                        double C = inputs["C folga (mm)"];
                        
                        if (p == 0 || C == 0) return 0;
                        double p_Pa = p * 1e6;
                        double ratio = R / C;
                        double S = (eta * n / p_Pa) * ratio * ratio;
                        return S;
                    },
                    Icone = "⚙️"
                },

                // V10-244: Espessura de Filme (EHD)
                new Formula
                {
                    Id = "3832",
                    CodigoCompendio = "V10-244",
                    Nome = "Espessura Filme EHL (Hamrock-Dowson)",
                    Categoria = "Tribologia",
                    SubCategoria = "Elasto-Hidrodinâmica",
                    Expressao = @"h_min = R·k·(η₀·u)^0.67·α^0.53·(E'·R)^(-0.03)·W^(-0.067)",
                    Descricao = "EHL: elastohydrodynamic lubrication. η₀: viscosidade ambiente, α: coef pressão-viscosidade, E': módulo reduzido, W: carga. Rolamentos: h~0.1-1µm.",
                    ExemploPratico = "Rolamento: R=10mm, u=1m/s, η₀=0.05 Pa·s, α=2×10^-8/Pa, E'=200GPa, W=1000N→h_min≈0.5µm (λ=h/σ>3: full film).",
                    Criador = "Hamrock-Dowson (1977, fórmula empírica EHL); Grubin (1949, pioneiro)",
                    AnoOrigin = "1977",
                    VariavelResultado = "h_min",
                    UnidadeResultado = "µm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R raio (mm)", Simbolo = "R", Unidade = "mm", ValorPadrao = 10 },
                        new Variavel { Nome = "u velocidade (m/s)", Simbolo = "u", Unidade = "m/s", ValorPadrao = 1 },
                        new Variavel { Nome = "η₀ (Pa·s)", Simbolo = "eta0", Unidade = "Pa·s", ValorPadrao = 0.05 },
                        new Variavel { Nome = "W carga (N)", Simbolo = "W", Unidade = "N", ValorPadrao = 1000 }
                    },
                    Calcular = inputs =>
                    {
                        double R_mm = inputs["R raio (mm)"];
                        double u = inputs["u velocidade (m/s)"];
                        double eta0 = inputs["η₀ (Pa·s)"];
                        double W = inputs["W carga (N)"];
                        
                        double R_m = R_mm / 1000;
                        double alpha = 2e-8; // típico
                        double E_prime = 200e9; // Pa
                        
                        // Hamrock-Dowson simplificada
                        double h_min = 3.63 * R_m * Math.Pow(eta0 * u, 0.67) * Math.Pow(alpha, 0.53) 
                                       * Math.Pow(E_prime * R_m, -0.03) * Math.Pow(W, -0.067);
                        double h_min_um = h_min * 1e6;
                        return h_min_um;
                    },
                    Icone = "⚙️"
                },

                // V10-245: Razão Lambda (λ)
                new Formula
                {
                    Id = "3833",
                    CodigoCompendio = "V10-245",
                    Nome = "Razão Lambda (λ) — Espessura Específica",
                    Categoria = "Tribologia",
                    SubCategoria = "Análise de Filme",
                    Expressao = @"λ = h_min/σ; σ: rugosidade RMS combinada",
                    Descricao = "λ>3: full film (hydrodyn). 1<λ<3: mixed. λ<1: boundary. σ=√(σ₁²+σ₂²). Tallian criterion: λ>4 para long life bearings.",
                    ExemploPratico = "h_min=0.5µm, σ₁=σ₂=0.1µm→σ=0.14µm→λ≈3.5 (mixed-full film transition). Polido: σ<0.05µm→λ>10 (excellent).",
                    Criador = "Tallian (1967, failure mechanisms bearings); Dawson (1962, film thickness)",
                    AnoOrigin = "1967",
                    VariavelResultado = "lambda",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "h_min (µm)", Simbolo = "h", Unidade = "µm", ValorPadrao = 0.5 },
                        new Variavel { Nome = "σ₁ rugosidade 1 (µm)", Simbolo = "sigma1", Unidade = "µm", ValorPadrao = 0.1 },
                        new Variavel { Nome = "σ₂ rugosidade 2 (µm)", Simbolo = "sigma2", Unidade = "µm", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double h = inputs["h_min (µm)"];
                        double sigma1 = inputs["σ₁ rugosidade 1 (µm)"];
                        double sigma2 = inputs["σ₂ rugosidade 2 (µm)"];
                        
                        double sigma_comb = Math.Sqrt(sigma1 * sigma1 + sigma2 * sigma2);
                        if (sigma_comb == 0) return double.PositiveInfinity;
                        
                        double lambda = h / sigma_comb;
                        return lambda;
                    },
                    Icone = "⚙️"
                },

                // V10-246: Índice de Viscosidade (VI)
                new Formula
                {
                    Id = "3834",
                    CodigoCompendio = "V10-246",
                    Nome = "Índice de Viscosidade (VI)",
                    Categoria = "Tribologia",
                    SubCategoria = "Lubrificantes",
                    Expressao = @"VI = (L−U)/(L−H)×100; L,H: óleo ref 40/100°C",
                    Descricao = "VI alto: viscosidade varia pouco com T (synth: VI>140). VI baixo: varia muito (mineral: VI~95). SAE grades: multiviscosity usa VI improvers.",
                    ExemploPratico = "Mineral: VI=95 (40°C→100cSt, 100°C→10cSt). Synthetic: VI=150 (menos variação). PAO, ester: VI>120. Automotive: 5W-30 (multigrade).",
                    Criador = "Dean-Davis (1929, ASTM D2270 VI calculation)",
                    AnoOrigin = "1929",
                    VariavelResultado = "VI",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ν(40°C) (cSt)", Simbolo = "nu40", Unidade = "cSt", ValorPadrao = 100 },
                        new Variavel { Nome = "ν(100°C) (cSt)", Simbolo = "nu100", Unidade = "cSt", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double nu40 = inputs["ν(40°C) (cSt)"];
                        double nu100 = inputs["ν(100°C) (cSt)"];
                        
                        // Simplificação: VI≈95 + fator baseado em ratio
                        double ratio = nu100 / nu40;
                        double VI = 95 + (ratio - 0.1) * 500; // empírico
                        if (VI < 0) VI = 0;
                        if (VI > 200) VI = 200;
                        return VI;
                    },
                    Icone = "⚙️"
                },

                // V10-247: Pressão de Hertz
                new Formula
                {
                    Id = "3835",
                    CodigoCompendio = "V10-247",
                    Nome = "Pressão de Contato Hertz",
                    Categoria = "Tribologia",
                    SubCategoria = "Mecânica de Contato",
                    Expressao = @"p_max = (3·W)/(2·π·a·b); a,b: semi-eixos elipse",
                    Descricao = "Contato elástico. Esfera-plano: p_max=(3W)/(2πa²), a=√(3WR/(4E')). Cilindro: linha contato. Von Mises stress: yield check.",
                    ExemploPratico = "Esfera R=10mm, W=100N, E'=200GPa→a≈0.18mm→p_max≈1.9GPa (abaixo 2GPa yield aço). Rolamento: p~2-3GPa (design limit).",
                    Criador = "Hertz (1882, contact theory); aplicado tribologia (Johnson 1985 Contact Mechanics)",
                    AnoOrigin = "1882",
                    VariavelResultado = "p_max",
                    UnidadeResultado = "GPa",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "W carga (N)", Simbolo = "W", Unidade = "N", ValorPadrao = 100 },
                        new Variavel { Nome = "R raio (mm)", Simbolo = "R", Unidade = "mm", ValorPadrao = 10 },
                        new Variavel { Nome = "E' módulo (GPa)", Simbolo = "E_prime", Unidade = "GPa", ValorPadrao = 200 }
                    },
                    Calcular = inputs =>
                    {
                        double W = inputs["W carga (N)"];
                        double R_mm = inputs["R raio (mm)"];
                        double E_GPa = inputs["E' módulo (GPa)"];
                        
                        double R_m = R_mm / 1000;
                        double E_Pa = E_GPa * 1e9;
                        
                        // Esfera-plano: a = (3WR/(4E'))^(1/3)
                        double a = Math.Pow(3 * W * R_m / (4 * E_Pa), 1.0 / 3.0);
                        double p_max = 3 * W / (2 * Math.PI * a * a);
                        double p_max_GPa = p_max / 1e9;
                        return p_max_GPa;
                    },
                    Icone = "⚙️"
                },

                // V10-248: Temperatura Flash
                new Formula
                {
                    Id = "3836",
                    CodigoCompendio = "V10-248",
                    Nome = "Temperatura Flash (Atrito)",
                    Categoria = "Tribologia",
                    SubCategoria = "Termo-Tribologia",
                    Expressao = @"ΔT_flash = 0.5·μ·p·v·√(a/(k·ρ·c·v))",
                    Descricao = "Hot spots: asperezas contato. k: condutividade térmica, ρ: densidade, c: calor específico. ΔT_flash>100°C: risco oxidação, scuffing.",
                    ExemploPratico = "Aço: μ=0.4, p=1GPa, v=10m/s, a=10µm→ΔT_flash≈200°C (risco!). Lubrificante: reduz μ→menor ΔT. Gear: scuffing limit ΔT<300°C.",
                    Criador = "Blok (1937, flash temperature theory); Jaeger (1942, moving heat source)",
                    AnoOrigin = "1937",
                    VariavelResultado = "delta_T",
                    UnidadeResultado = "°C",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "μ", Simbolo = "mu", Unidade = "", ValorPadrao = 0.4 },
                        new Variavel { Nome = "p pressão (GPa)", Simbolo = "p", Unidade = "GPa", ValorPadrao = 1 },
                        new Variavel { Nome = "v velocidade (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 10 },
                        new Variavel { Nome = "a contato (µm)", Simbolo = "a", Unidade = "µm", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double mu = inputs["μ"];
                        double p_GPa = inputs["p pressão (GPa)"];
                        double v = inputs["v velocidade (m/s)"];
                        double a_um = inputs["a contato (µm)"];
                        
                        double p_Pa = p_GPa * 1e9;
                        double a_m = a_um * 1e-6;
                        
                        // Aço típico
                        double k = 50; // W/(m·K)
                        double rho = 7850; // kg/m³
                        double c = 460; // J/(kg·K)
                        
                        double delta_T = 0.5 * mu * p_Pa * v * Math.Sqrt(a_m / (k * rho * c * v));
                        return delta_T;
                    },
                    Icone = "⚙️"
                },

                // V10-249: Taxa de Desgaste Abrasivo (Rabinowicz)
                new Formula
                {
                    Id = "3837",
                    CodigoCompendio = "V10-249",
                    Nome = "Desgaste Abrasivo — Modelo Rabinowicz",
                    Categoria = "Tribologia",
                    SubCategoria = "Desgaste Abrasivo",
                    Expressao = @"V/s = k_ab·W/H; k_ab: constante abrasão",
                    Descricao = "Two-body (lixa) vs three-body (partículas soltas). k_ab≈0.1-0.5 (severo). Dureza partícula>Dureza superfície: cutting. Mining, earthmoving: high k_ab.",
                    ExemploPratico = "Escavadeira: W=10kN, H=500 HV≈5GPa, k_ab=0.2→V/s=10000·0.2/(5×10^9)=4×10^-7 m³/m=0.4 mm³/m. Hardfacing: increase H→reduce wear.",
                    Criador = "Rabinowicz (1965, friction and wear materials)",
                    AnoOrigin = "1965",
                    VariavelResultado = "V_per_s",
                    UnidadeResultado = "mm³/m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k_ab", Simbolo = "k_ab", Unidade = "", ValorPadrao = 0.2 },
                        new Variavel { Nome = "W carga (kN)", Simbolo = "W", Unidade = "kN", ValorPadrao = 10 },
                        new Variavel { Nome = "H dureza (GPa)", Simbolo = "H", Unidade = "GPa", ValorPadrao = 5 }
                    },
                    Calcular = inputs =>
                    {
                        double k_ab = inputs["k_ab"];
                        double W_kN = inputs["W carga (kN)"];
                        double H_GPa = inputs["H dureza (GPa)"];
                        
                        if (H_GPa == 0) return 0;
                        
                        double W_N = W_kN * 1000;
                        double H_Pa = H_GPa * 1e9;
                        double V_per_s_m3 = k_ab * W_N / H_Pa;
                        double V_per_s_mm3 = V_per_s_m3 * 1e9;
                        return V_per_s_mm3;
                    },
                    Icone = "⚙️"
                },

                // V10-250: Coeficiente de Atrito Estático vs Dinâmico
                new Formula
                {
                    Id = "3838",
                    CodigoCompendio = "V10-250",
                    Nome = "Relação μ_s / μ_k",
                    Categoria = "Tribologia",
                    SubCategoria = "Atrito",
                    Expressao = @"μ_s > μ_k; stick-slip quando diferença grande",
                    Descricao = "μ_s: estático (start). μ_k: cinético (sliding). Típico: μ_s/μ_k≈1.2-1.5. Stick-slip: violino, freio squealing, earthquake.",
                    ExemploPratico = "Borracha-concreto: μ_s≈1.0, μ_k≈0.7. PTFE: μ_s≈μ_k≈0.04 (no stick-slip). Grafite: lubrif sólido, μ_k<μ_s.",
                    Criador = "Coulomb (1785); stick-slip studied Rabinowicz (1950s)",
                    AnoOrigin = "1785",
                    VariavelResultado = "ratio",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "μ_s estático", Simbolo = "mu_s", Unidade = "", ValorPadrao = 1.0 },
                        new Variavel { Nome = "μ_k cinético", Simbolo = "mu_k", Unidade = "", ValorPadrao = 0.7 }
                    },
                    Calcular = inputs =>
                    {
                        double mu_s = inputs["μ_s estático"];
                        double mu_k = inputs["μ_k cinético"];
                        
                        if (mu_k == 0) return double.PositiveInfinity;
                        double ratio = mu_s / mu_k;
                        return ratio;
                    },
                    Icone = "⚙️"
                },

                // V10-251: Espessura Ótima de Lubrificante
                new Formula
                {
                    Id = "3839",
                    CodigoCompendio = "V10-251",
                    Nome = "Espessura Ótima — Lubrificação Limite",
                    Categoria = "Tribologia",
                    SubCategoria = "Lubrificação Limite",
                    Expressao = @"h_opt ≈ 5-20 nm (monocamada adsorvida)",
                    Descricao = "Boundary lubrication: moléculas polares adsorvem superfície. AW (anti-wear): ZDDP forma tribofilm 50-100nm. EP (extreme pressure): react under load.",
                    ExemploPratico = "Ácido graxo: polar head adsorve metal, cadeia hidrocarbono reduz atrito. ZDDP: Zn-dialquil-ditiofosfato, antiwear motor oil. MoS₂: solid lubricant.",
                    Criador = "Hardy-Doubleday (1922, boundary lubrication); Bowden-Tabor (1950, friction lubrication)",
                    AnoOrigin = "1922",
                    VariavelResultado = "h_opt",
                    UnidadeResultado = "nm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tipo (1=polar,2=AW)", Simbolo = "tipo", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        int tipo = (int)inputs["Tipo (1=polar,2=AW)"];
                        
                        double h_opt = tipo == 1 ? 10 : 75; // nm (monocamada vs tribofilm)
                        return h_opt;
                    },
                    Icone = "⚙️"
                },

                // V10-252: Taxa de Desgaste Oxidativo
                new Formula
                {
                    Id = "3840",
                    CodigoCompendio = "V10-252",
                    Nome = "Desgaste Oxidativo (Mild Wear)",
                    Categoria = "Tribologia",
                    SubCategoria = "Desgaste",
                    Expressao = @"V = k·W·s/H; óxido forma+remove ciclicamente",
                    Descricao = "Oxidação assistida por atrito. Filme óxido (FeO, Fe₂O₃) protege mas frágil. Mild wear: k≈10^-7 a 10^-6. T elevada acelera oxidação.",
                    ExemploPratico = "Aço 400°C: óxido grows, k≈10^-6. Room temp: k≈10^-7 (mais lento). Sliding: oxide debris→third-body abrasion. Inox: passive Cr₂O₃.",
                    Criador = "Quinn (1983, oxidational wear theory)",
                    AnoOrigin = "1983",
                    VariavelResultado = "k_oxide",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Temperatura (°C)", Simbolo = "T", Unidade = "°C", ValorPadrao = 400 }
                    },
                    Calcular = inputs =>
                    {
                        double T = inputs["Temperatura (°C)"];
                        
                        // k aumenta com T (Arrhenius-like)
                        double k_base = 1e-7;
                        double k_oxide = k_base * Math.Exp((T - 20) / 200); // empírico
                        if (k_oxide > 1e-5) k_oxide = 1e-5; // cap
                        return k_oxide;
                    },
                    Icone = "⚙️"
                },

                // V10-253: Número de Hersey
                new Formula
                {
                    Id = "3841",
                    CodigoCompendio = "V10-253",
                    Nome = "Número de Hersey — ZN/p",
                    Categoria = "Tribologia",
                    SubCategoria = "Parâmetros Adimensionais",
                    Expressao = @"Hersey = (η·N)/p; relacionado Stribeck",
                    Descricao = "Z=η viscosidade, N=velocidade, p=pressão. Hersey alto: hydrodynamic. Hersey baixo: boundary. Stribeck usa (ηN/p).",
                    ExemploPratico = "η=0.05 Pa·s, N=1000 rpm=16.7 rps, p=2 MPa→Hersey=0.05·16.7/(2×10^6)≈4.2×10^-7. Típico hydrodyn: >10^-6.",
                    Criador = "Hersey (1914, bearing lubrication parameter)",
                    AnoOrigin = "1914",
                    VariavelResultado = "Hersey",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "η (Pa·s)", Simbolo = "eta", Unidade = "Pa·s", ValorPadrao = 0.05 },
                        new Variavel { Nome = "N rotação (rpm)", Simbolo = "N", Unidade = "rpm", ValorPadrao = 1000 },
                        new Variavel { Nome = "p pressão (MPa)", Simbolo = "p", Unidade = "MPa", ValorPadrao = 2 }
                    },
                    Calcular = inputs =>
                    {
                        double eta = inputs["η (Pa·s)"];
                        double N_rpm = inputs["N rotação (rpm)"];
                        double p_MPa = inputs["p pressão (MPa)"];
                        
                        if (p_MPa == 0) return 0;
                        
                        double N_rps = N_rpm / 60;
                        double p_Pa = p_MPa * 1e6;
                        double Hersey = eta * N_rps / p_Pa;
                        return Hersey;
                    },
                    Icone = "⚙️"
                },

                // V10-254: Fadiga de Contato (Rolamento)
                new Formula
                {
                    Id = "3842",
                    CodigoCompendio = "V10-254",
                    Nome = "Vida L10 — Rolamentos",
                    Categoria = "Tribologia",
                    SubCategoria = "Fadiga de Contato",
                    Expressao = @"L_10 = (C/P)^p × 10^6 revs; p=3 (ball), p=10/3 (roller)",
                    Descricao = "C: capacidade dinâmica (catalog). P: carga equivalente. L_10: 90% sobrevivem. ISO 281. Pitting: subsurface fatigue.",
                    ExemploPratico = "Ball bearing: C=10kN, P=2kN→L_10=(10/2)³×10^6=125×10^6 rev. 3000rpm→L_10≈695 horas. Lubrificação,contaminação afetam.",
                    Criador = "Lundberg-Palmgren (1947, bearing life theory); ISO 281 (padrão)",
                    AnoOrigin = "1947",
                    VariavelResultado = "L10",
                    UnidadeResultado = "Mrev",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "C capacidade (kN)", Simbolo = "C", Unidade = "kN", ValorPadrao = 10 },
                        new Variavel { Nome = "P carga (kN)", Simbolo = "P", Unidade = "kN", ValorPadrao = 2 },
                        new Variavel { Nome = "Tipo (3=ball,3.33=roller)", Simbolo = "p", Unidade = "", ValorPadrao = 3 }
                    },
                    Calcular = inputs =>
                    {
                        double C = inputs["C capacidade (kN)"];
                        double P = inputs["P carga (kN)"];
                        double p = inputs["Tipo (3=ball,3.33=roller)"];
                        
                        if (P == 0) return double.PositiveInfinity;
                        
                        double L10 = Math.Pow(C / P, p); // em milhões de revoluções
                        return L10;
                    },
                    Icone = "⚙️"
                },

                // V10-255: Relação de Mistura (Engrenagens)
                new Formula
                {
                    Id = "3843",
                    CodigoCompendio = "V10-255",
                    Nome = "Sliding-to-Rolling Ratio (Engrenagens)",
                    Categoria = "Tribologia",
                    SubCategoria = "Engrenagens",
                    Expressao = @"SRR = |v₁−v₂|/v_mean; scuffing risk",
                    Descricao = "v₁,v₂: velocidades superfícies. Pitch line: SRR=0 (pure roll). Tip/root: SRR máximo. SRR>1: high scuffing risk. Lubrif EP needed.",
                    ExemploPratico = "Gear tip: v₁=15 m/s, v₂=10→v_mean=12.5, SRR=0.4 (moderate). Hypoid gears: SRR>1.5 (EP lubricant mandatory). Worm: SRR~5 (sliding dominant).",
                    Criador = "Merritt (1935, gear lubrication); Niemann (1960s, scuffing criteria)",
                    AnoOrigin = "1960",
                    VariavelResultado = "SRR",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v₁ (m/s)", Simbolo = "v1", Unidade = "m/s", ValorPadrao = 15 },
                        new Variavel { Nome = "v₂ (m/s)", Simbolo = "v2", Unidade = "m/s", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double v1 = inputs["v₁ (m/s)"];
                        double v2 = inputs["v₂ (m/s)"];
                        
                        double v_mean = (v1 + v2) / 2;
                        if (v_mean == 0) return 0;
                        
                        double SRR = Math.Abs(v1 - v2) / v_mean;
                        return SRR;
                    },
                    Icone = "⚙️"
                },

                // V10-256: Energia de Fretting
                new Formula
                {
                    Id = "3844",
                    CodigoCompendio = "V10-256",
                    Nome = "Desgaste por Fretting",
                    Categoria = "Tribologia",
                    SubCategoria = "Fretting",
                    Expressao = @"E_d = ∫F·dx (energia dissipada por ciclo)",
                    Descricao = "Oscilação pequena amplitude (<100µm). Oxidação in situ: debris oxidado (brown pó). Fretting fatigue: nucleação crack. Dovetail turbine, shrink fit.",
                    ExemploPratico = "Amplitude δ=50µm, F=100N→E_d≈5mJ/cycle. 10^6 cycles→50kJ dissipado. Volume wear V∝E_d. Coatings (TiN, DLC) reduce fretting.",
                    Criador = "Tomlinson (1939, fretting corrosion); Waterhouse (1972, fretting fatigue)",
                    AnoOrigin = "1939",
                    VariavelResultado = "E_d",
                    UnidadeResultado = "mJ/cycle",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "F força (N)", Simbolo = "F", Unidade = "N", ValorPadrao = 100 },
                        new Variavel { Nome = "δ amplitude (µm)", Simbolo = "delta", Unidade = "µm", ValorPadrao = 50 }
                    },
                    Calcular = inputs =>
                    {
                        double F = inputs["F força (N)"];
                        double delta_um = inputs["δ amplitude (µm)"];
                        
                        double delta_m = delta_um * 1e-6;
                        // Aproximação: E_d ≈ F·δ (ciclo completo ~4×)
                        double E_d_J = 4 * F * delta_m;
                        double E_d_mJ = E_d_J * 1000;
                        return E_d_mJ;
                    },
                    Icone = "⚙️"
                },

                // V10-257: Eficiência de Transmissão
                new Formula
                {
                    Id = "3845",
                    CodigoCompendio = "V10-257",
                    Nome = "Eficiência — Perdas por Atrito",
                    Categoria = "Tribologia",
                    SubCategoria = "Transmissão de Potência",
                    Expressao = @"η = P_out/P_in; perdas atrito mancais/engrenagens/selos",
                    Descricao = "Gear: η≈0.98-0.99 (single stage). Worm: η≈0.5-0.9 (sliding). Bearing: perdas baixas (<1%). Seal: drag torque. Chain: η≈0.97.",
                    ExemploPratico = "Gearbox 3-stage: η_stage=0.98→η_total=0.98³≈0.94 (6% loss). Worm 20:1: η≈0.75 (25% loss heat). Hybrid bearing: η>0.99.",
                    Criador = "Diversos; engenharia mecânica clássica",
                    AnoOrigin = "1900",
                    VariavelResultado = "eta",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "P_in (kW)", Simbolo = "P_in", Unidade = "kW", ValorPadrao = 100 },
                        new Variavel { Nome = "P_out (kW)", Simbolo = "P_out", Unidade = "kW", ValorPadrao = 94 }
                    },
                    Calcular = inputs =>
                    {
                        double P_in = inputs["P_in (kW)"];
                        double P_out = inputs["P_out (kW)"];
                        
                        if (P_in == 0) return 0;
                        double eta = (P_out / P_in) * 100;
                        return eta;
                    },
                    Icone = "⚙️"
                },

                // V10-258: Coeficiente de Atrito Adesivo (Bowden-Tabor)
                new Formula
                {
                    Id = "3846",
                    CodigoCompendio = "V10-258",
                    Nome = "Teoria Adesiva do Atrito (Bowden-Tabor)",
                    Categoria = "Tribologia",
                    SubCategoria = "Fundamentos",
                    Expressao = @"F_f = A_real × τ; A_real: área real contato",
                    Descricao = "A_real = W/H (dureza). τ: shear strength junções. μ=τ/p_contact. Asperezas deformam plasticamente. Adesão molecular.",
                    ExemploPratico = "W=100N, H=2GPa→A_real=50µm². τ=50MPa→F_f=2.5N→μ=0.025. Metais limpos: μ~1 (high adhesion). Óxido: reduz τ→μ<0.3.",
                    Criador = "Bowden-Tabor (1950, Friction and Lubrication of Solids)",
                    AnoOrigin = "1950",
                    VariavelResultado = "mu_calc",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "τ shear (MPa)", Simbolo = "tau", Unidade = "MPa", ValorPadrao = 50 },
                        new Variavel { Nome = "H dureza (GPa)", Simbolo = "H", Unidade = "GPa", ValorPadrao = 2 }
                    },
                    Calcular = inputs =>
                    {
                        double tau_MPa = inputs["τ shear (MPa)"];
                        double H_GPa = inputs["H dureza (GPa)"];
                        
                        if (H_GPa == 0) return 0;
                        
                        double tau_Pa = tau_MPa * 1e6;
                        double H_Pa = H_GPa * 1e9;
                        
                        // μ = τ/p, p≈H (plastic flow)
                        double mu_calc = tau_Pa / H_Pa;
                        return mu_calc;
                    },
                    Icone = "⚙️"
                },

                // V10-259: Critério de Scuffing (PV limit)
                new Formula
                {
                    Id = "3847",
                    CodigoCompendio = "V10-259",
                    Nome = "Limite PV (Pressure-Velocity)",
                    Categoria = "Tribologia",
                    SubCategoria = "Critérios de Falha",
                    Expressao = @"PV < PV_limit; scuffing/seizure threshold",
                    Descricao = "p: pressão (MPa), v: velocidade (m/s). PV_limit: material-dependent. Bronze: ~1.8 MPa·m/s. PTFE: ~0.5. Steel-steel dry: ~0.2. Lubrif increase limit.",
                    ExemploPratico = "Bushing: p=5MPa, v=0.3m/s→PV=1.5 (OK para bronze PV_lim=1.8). Dry slide: p=2MPa, v=0.5→PV=1.0 (scuff risk aço).",
                    Criador = "Diversos; design criterion estabelecido 1950s-1960s",
                    AnoOrigin = "1960",
                    VariavelResultado = "PV",
                    UnidadeResultado = "MPa·m/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "p pressão (MPa)", Simbolo = "p", Unidade = "MPa", ValorPadrao = 5 },
                        new Variavel { Nome = "v velocidade (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 0.3 }
                    },
                    Calcular = inputs =>
                    {
                        double p = inputs["p pressão (MPa)"];
                        double v = inputs["v velocidade (m/s)"];
                        
                        double PV = p * v;
                        return PV;
                    },
                    Icone = "⚙️"
                }
            });
        }
    }
}
