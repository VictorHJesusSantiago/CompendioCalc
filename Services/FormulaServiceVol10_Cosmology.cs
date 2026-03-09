using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE V
    /// COSMOLOGIA INFLACIONÁRIA E ENERGIA ESCURA
    /// Fórmulas V10-082 a V10-101 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_Cosmology()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3670",
                    CodigoCompendio = "V10-082",
                    Nome = "Equação de Friedmann",
                    Categoria = "Cosmologia",
                    SubCategoria = "Cosmologia Dinâmica",
                    Expressao = @"H² = (8πG/3)ρ − k/a² + Λ/3",
                    Descricao = "Evolução do fator de escala a(t). H: parâmetro Hubble. ρ: densidade energia. k: curvatura. Λ: constante cosmológica.",
                    ExemploPratico = "Planck 2018: Ω_Λ≈0.68, Ω_m≈0.32. Idade: t₀≈13.8 Gyr.",
                    Criador = "Friedmann (1922); base do modelo FLRW",
                    AnoOrigin = "1922",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "H0 (km/s/Mpc)", Simbolo = "H0", Unidade = "km/s/Mpc", ValorPadrao = 70 },
                        new Variavel { Nome = "Ω_m", Simbolo = "Ω_m", Unidade = "", ValorPadrao = 0.32 },
                        new Variavel { Nome = "Ω_Λ", Simbolo = "Ω_Λ", Unidade = "", ValorPadrao = 0.68 }
                    },
                    VariavelResultado = "Idade_Gyr",
                    UnidadeResultado = "Gyr",
                    Calcular = inputs =>
                    {
                        double H0 = inputs["H0 (km/s/Mpc)"];
                        double Om = inputs["Ω_m"];
                        double OL = inputs["Ω_Λ"];
                        
                        // Idade aproximada do universo (usando integral numérica simplificada)
                        // t0 ≈ (2/3H0) para universo plano dominado por Λ
                        double H0_SI = H0 * 1000 / (3.086e22); // convert to 1/s
                        double t_sec = (2.0 / 3.0) / H0_SI;
                        double t_Gyr = t_sec / (3.1536e16); // convert to Gyr
                        
                        return t_Gyr;
                    },
                    Icone = "🌌"
                },

                // V10-083: Distância de Luminosidade
                new Formula
                {
                    Id = "3671",
                    CodigoCompendio = "V10-083",
                    Nome = "Distância de Luminosidade",
                    Categoria = "Cosmologia",
                    SubCategoria = "Distâncias Cosmológicas",
                    Expressao = @"d_L = (1+z)·∫₀^z dz'/H(z')",
                    Descricao = "Distância baseada em fluxo observado vs luminosidade intrínseca. d_L = d_C(1+z) onde d_C é comoving distance. Supernovas Ia são 'velas padrão' (mesma luminosidade).",
                    ExemploPratico = "Supernova z=1: d_L≈7 Gpc (≈23 bilhões anos-luz). z=0.5: d_L≈3 Gpc. Nobel 2011 (Perlmutter, Schmidt, Riess): aceleração via d_L(z).",
                    Criador = "Hubble (1929, relação distância-redshift); Riess et al. (1998, aceleração)",
                    AnoOrigin = "1998",
                    VariavelResultado = "d_L",
                    UnidadeResultado = "Gpc",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Redshift z", Simbolo = "z", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "H0 (km/s/Mpc)", Simbolo = "H0", Unidade = "km/s/Mpc", ValorPadrao = 70 }
                    },
                    Calcular = inputs =>
                    {
                        double z = inputs["Redshift z"];
                        double H0 = inputs["H0 (km/s/Mpc)"];
                        
                        // Aproximação para universo plano (Ω_m=0.3, Ω_Λ=0.7)
                        double c = 299792.458; // km/s
                        double d_H = c / H0; // Hubble distance em Mpc
                        
                        // Aproximação analítica
                        double d_C = d_H * z * (1 + z / 2); // comoving distance aproximado
                        double d_L = d_C * (1 + z); // luminosity distance
                        
                        return d_L / 1000; // convert to Gpc
                    },
                    Icone = "🌌"
                },

                // V10-084: Parâmetro de Densidade
                new Formula
                {
                    Id = "3672",
                    CodigoCompendio = "V10-084",
                    Nome = "Parâmetro de Densidade Ω",
                    Categoria = "Cosmologia",
                    SubCategoria = "Conteúdo do Universo",
                    Expressao = @"Ω = ρ/ρ_crit; ρ_crit = 3H²/(8πG)",
                    Descricao = "Ω: densidade relativa à crítica. Ω=1: universo plano. Ω>1: fechado. Ω<1: aberto. Componentes: Ω_m (matéria), Ω_Λ (energia escura), Ω_r (radiação).",
                    ExemploPratico = "Planck 2018: Ω_m≈0.315, Ω_Λ≈0.685, Ω_total≈1.000±0.001 (plano!). ρ_crit≈10^-26 kg/m³ (5 átomos H/m³).",
                    Criador = "Friedmann (1922); Einstein-de Sitter (1932, Ω=1 modelo)",
                    AnoOrigin = "1932",
                    VariavelResultado = "rho_crit",
                    UnidadeResultado = "kg/m³",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "H0 (km/s/Mpc)", Simbolo = "H0", Unidade = "km/s/Mpc", ValorPadrao = 70 }
                    },
                    Calcular = inputs =>
                    {
                        double H0 = inputs["H0 (km/s/Mpc)"];
                        
                        double H0_SI = H0 * 1000 / (3.086e22); // convert to 1/s
                        double G = 6.674e-11; // m³/(kg·s²)
                        
                        double rho_crit = (3 * H0_SI * H0_SI) / (8 * Math.PI * G);
                        
                        return rho_crit;
                    },
                    Icone = "🌌"
                },

                // V10-085: Inflação — Número de e-folds
                new Formula
                {
                    Id = "3673",
                    CodigoCompendio = "V10-085",
                    Nome = "Inflação — Número de e-folds",
                    Categoria = "Cosmologia",
                    SubCategoria = "Inflação Cosmológica",
                    Expressao = @"N = ln(a_end/a_start) ≈ 60",
                    Descricao = "N: número de expansões exponenciais e^N durante inflação. N≈60 resolve problemas de planura e horizonte. Inflação: a(t)~e^(Ht), H quase constante.",
                    ExemploPratico = "N=60: universo expande e^60≈10^26 vezes. Duração: ~10^-32s. Resolve: por que Ω tão próximo de 1? Por que CMB uniforme (problema do horizonte)?",
                    Criador = "Guth (1981, Physical Review D); Linde (1982, chaotic inflation)",
                    AnoOrigin = "1981",
                    VariavelResultado = "N",
                    UnidadeResultado = "e-folds",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "a_final/a_inicial", Simbolo = "a_ratio", Unidade = "", ValorPadrao = 1e26 }
                    },
                    Calcular = inputs =>
                    {
                        double a_ratio = inputs["a_final/a_inicial"];
                        if (a_ratio <= 0) return 0;
                        double N = Math.Log(a_ratio);
                        return N;
                    },
                    Icone = "🌌"
                },

                // V10-086: Potencial Inflacionário
                new Formula
                {
                    Id = "3674",
                    CodigoCompendio = "V10-086",
                    Nome = "Potencial Inflacionário — Slow-Roll",
                    Categoria = "Cosmologia",
                    SubCategoria = "Inflação",
                    Expressao = @"ε = (M_pl²/2)·(V'/V)²; η = M_pl²·(V''/V)",
                    Descricao = "Parâmetros slow-roll. ε<<1, |η|<<1: inflação ocorre. ε≈1: fim da inflação. V(φ): potencial do inflaton φ. M_pl: massa de Planck.",
                    ExemploPratico = "V=m²φ²/2 (chaotic): ε=(M_pl/φ)². φ≈15M_pl no início → ε≈0.004 (slow-roll). Potencial quadrático: N≈φ²/(2M_pl²).",
                    Criador = "Linde (1982); Slow-roll formalismo (anos 1980s)",
                    AnoOrigin = "1982",
                    VariavelResultado = "ε",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "φ/M_pl", Simbolo = "phi", Unidade = "", ValorPadrao = 15 },
                        new Variavel { Nome = "Tipo potencial (1=quad,2=exp)", Simbolo = "tipo", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double phi = inputs["φ/M_pl"];
                        int tipo = (int)inputs["Tipo potencial (1=quad,2=exp)"];
                        
                        double epsilon = 0;
                        if (tipo == 1) // V = m²φ²/2
                        {
                            epsilon = 1.0 / (phi * phi);
                        }
                        else // V = V0·exp(-αφ)
                        {
                            double alpha = 0.1;
                            epsilon = alpha * alpha / 2;
                        }
                        
                        return epsilon;
                    },
                    Icone = "🌌"
                },

                // V10-087: Flutuações Primordiais
                new Formula
                {
                    Id = "3675",
                    CodigoCompendio = "V10-087",
                    Nome = "Flutuações Primordiais — Espectro de Potência",
                    Categoria = "Cosmologia",
                    SubCategoria = "Perturbações Cosmológicas",
                    Expressao = @"P_R(k) = A_s·(k/k_pivot)^(n_s−1)",
                    Descricao = "Espectro de potência escalar. A_s≈2×10^-9: amplitude. n_s≈0.96: índice espectral. n_s=1: invariância escala (Harrison-Zel'dovich). n_s<1: mais potência em grandes escalas.",
                    ExemploPratico = "Planck 2018: n_s=0.965±0.004. n_s<1: evidência inflação (não exact scale-invariance). CMB ℓ~100: flutuações δT/T≈10^-5.",
                    Criador = "Harrison (1970), Zel'dovich (1972); Observações CMB (COBE 1992, WMAP 2003, Planck 2013)",
                    AnoOrigin = "1970",
                    VariavelResultado = "P_R",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k (Mpc^-1)", Simbolo = "k", Unidade = "Mpc^-1", ValorPadrao = 0.05 },
                        new Variavel { Nome = "n_s", Simbolo = "n_s", Unidade = "", ValorPadrao = 0.965 }
                    },
                    Calcular = inputs =>
                    {
                        double k = inputs["k (Mpc^-1)"];
                        double n_s = inputs["n_s"];
                        
                        double A_s = 2.1e-9;
                        double k_pivot = 0.05; // Mpc^-1
                        
                        double P_R = A_s * Math.Pow(k / k_pivot, n_s - 1);
                        
                        return P_R * 1e9; // scaled for readability
                    },
                    Icone = "🌌"
                },

                // V10-088: Temperatura CMB
                new Formula
                {
                    Id = "3676",
                    CodigoCompendio = "V10-088",
                    Nome = "Temperatura da Radiação Cósmica de Fundo (CMB)",
                    Categoria = "Cosmologia",
                    SubCategoria = "CMB",
                    Expressao = @"T_CMB(z) = T₀·(1+z); T₀ = 2.725K",
                    Descricao = "Temperatura do CMB evolui com redshift. T₀: temperatura hoje. z=1100 (recombinação): T≈3000K. CMB é corpo negro perfeito (espectro Planck).",
                    ExemploPratico = "COBE (1990): T₀=2.725±0.002K. z=1: T=5.45K. z_rec=1089: T≈2970K (ionização H). Anisotropias: δT/T≈10^-5.",
                    Criador = "Penzias e Wilson (1965, descoberta acidental, Nobel 1978); COBE (1992, espectro corpo negro)",
                    AnoOrigin = "1965",
                    VariavelResultado = "T_CMB",
                    UnidadeResultado = "K",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Redshift z", Simbolo = "z", Unidade = "", ValorPadrao = 1089 }
                    },
                    Calcular = inputs =>
                    {
                        double z = inputs["Redshift z"];
                        double T0 = 2.725; // K
                        double T_CMB = T0 * (1 + z);
                        return T_CMB;
                    },
                    Icone = "🌌"
                },

                // V10-089: Idade do Universo
                new Formula
                {
                    Id = "3677",
                    CodigoCompendio = "V10-089",
                    Nome = "Idade do Universo — Integral de Friedmann",
                    Categoria = "Cosmologia",
                    SubCategoria = "Cronologia",
                    Expressao = @"t₀ = ∫₀^∞ dz/[(1+z)H(z)]",
                    Descricao = "Idade integrando backward. H(z)=H₀√[Ω_m(1+z)³+Ω_Λ]. Planck 2018: t₀=13.787±0.020 Gyr. Universo vazio: t₀=1/H₀≈14 Gyr. Einstein-de Sitter: t₀=2/(3H₀)≈9 Gyr.",
                    ExemploPratico = "H₀=70 km/s/Mpc, Ω_m=0.3, Ω_Λ=0.7: t₀≈13.8 Gyr. Estrela mais velha (HD 140283): 14.5±0.8 Gyr (consistente dentro de erros).",
                    Criador = "Friedmann (1922); Planck Collaboration (2018, medida precisa)",
                    AnoOrigin = "1922",
                    VariavelResultado = "t0",
                    UnidadeResultado = "Gyr",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "H0 (km/s/Mpc)", Simbolo = "H0", Unidade = "km/s/Mpc", ValorPadrao = 70 },
                        new Variavel { Nome = "Ω_m", Simbolo = "Om", Unidade = "", ValorPadrao = 0.3 },
                        new Variavel { Nome = "Ω_Λ", Simbolo = "OL", Unidade = "", ValorPadrao = 0.7 }
                    },
                    Calcular = inputs =>
                    {
                        double H0 = inputs["H0 (km/s/Mpc)"];
                        double Om = inputs["Ω_m"];
                        double OL = inputs["Ω_Λ"];
                        
                        // Aproximação analítica para ΛCDM
                        double H0_SI = H0 * 1000 / (3.086e22);
                        double t_H = 1.0 / H0_SI; // Hubble time
                        
                        // Fator de correção para ΛCDM (aproximado)
                        double omega_ratio = OL / Om;
                        double factor = (2.0 / 3.0) * Math.Log(1 + Math.Sqrt(1 + omega_ratio)) / Math.Sqrt(omega_ratio);
                        
                        double t0_sec = t_H * factor;
                        double t0_Gyr = t0_sec / (3.1536e16);
                        
                        return t0_Gyr;
                    },
                    Icone = "🌌"
                },

                // V10-090: Equação de Estado w
                new Formula
                {
                    Id = "3678",
                    CodigoCompendio = "V10-090",
                    Nome = "Equação de Estado w",
                    Categoria = "Cosmologia",
                    SubCategoria = "Energia Escura",
                    Expressao = @"w = p/ρ",
                    Descricao = "Relação pressão/densidade. Matéria: w=0. Radiação: w=1/3. Constante cosmológica: w=−1. Quintessência: −1<w<0. Phantom: w<−1 (Big Rip).",
                    ExemploPratico = "Planck+BAO: w=−1.03±0.03 (consistente Λ). w(z): evolução possível (dark energy dinâmica). w<−1: universo termina em Big Rip (~50 Gyr futuro se w=−1.5).",
                    Criador = "Constante Λ (Einstein 1917); Quintessência (Caldwell 1998)",
                    AnoOrigin = "1998",
                    VariavelResultado = "w",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tipo (1=mat,2=rad,3=Λ,4=quint)", Simbolo = "tipo", Unidade = "", ValorPadrao = 3 }
                    },
                    Calcular = inputs =>
                    {
                        int tipo = (int)inputs["Tipo (1=mat,2=rad,3=Λ,4=quint)"];
                        
                        double w = 0;
                        switch (tipo)
                        {
                            case 1: w = 0; break; // matéria
                            case 2: w = 1.0 / 3.0; break; // radiação
                            case 3: w = -1; break; // Λ
                            case 4: w = -0.8; break; // quintessência
                        }
                        
                        return w;
                    },
                    Icone = "🌌"
                },

                // V10-091: Redshift de Igualdade Matéria-Radiação
                new Formula
                {
                    Id = "3679",
                    CodigoCompendio = "V10-091",
                    Nome = "Redshift de Igualdade Matéria-Radiação",
                    Categoria = "Cosmologia",
                    SubCategoria = "Transições Cosmológicas",
                    Expressao = @"z_eq = Ω_m/Ω_r − 1 ≈ 3400",
                    Descricao = "z>z_eq: universo dominado por radiação. z<z_eq: dominado por matéria. z_eq marca transição importante para formação de estruturas (crescimento de perturbações).",
                    ExemploPratico = "Planck: z_eq≈3387. t_eq≈47,000 anos. Antes: expansão a(t)∝t^(1/2) (radiação). Depois: a(t)∝t^(2/3) (matéria).",
                    Criador = "Teoria padrão Big Bang (anos 1940s-1960s)",
                    AnoOrigin = "1960",
                    VariavelResultado = "z_eq",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Ω_m h²", Simbolo = "Omh2", Unidade = "", ValorPadrao = 0.143 },
                        new Variavel { Nome = "Ω_r h²", Simbolo = "Orh2", Unidade = "", ValorPadrao = 4.2e-5 }
                    },
                    Calcular = inputs =>
                    {
                        double Omh2 = inputs["Ω_m h²"];
                        double Orh2 = inputs["Ω_r h²"];
                        
                        if (Orh2 == 0) return 0;
                        double z_eq = (Omh2 / Orh2) - 1;
                        
                        return z_eq;
                    },
                    Icone = "🌌"
                },

                // V10-092: Horizonte de Partículas
                new Formula
                {
                    Id = "3680",
                    CodigoCompendio = "V10-092",
                    Nome = "Horizonte de Partículas (Particle Horizon)",
                    Categoria = "Cosmologia",
                    SubCategoria = "Horizontes Cosmológicos",
                    Expressao = @"d_p(t) = a(t)·∫₀^t dt'/a(t')",
                    Descricao = "Distância comoving máxima que luz viajou desde Big Bang. d_p define região causal. Universo observável hoje: d_p≈46 Gly (não 13.8 Gly por expansão!).",
                    ExemploPratico = "CMB: vemos z=1089, distância própria hoje ≈46 Gpc. Horizonte problema: regiões opostas no CMB nunca estiveram em contato causal (resolvido por inflação).",
                    Criador = "Rindler (1956, horizontes em cosmologia)",
                    AnoOrigin = "1956",
                    VariavelResultado = "d_p",
                    UnidadeResultado = "Gly",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Idade t₀ (Gyr)", Simbolo = "t0", Unidade = "Gyr", ValorPadrao = 13.8 },
                        new Variavel { Nome = "Expansão média ⟨a⟩", Simbolo = "a_avg", Unidade = "", ValorPadrao = 0.3 }
                    },
                    Calcular = inputs =>
                    {
                        double t0 = inputs["Idade t₀ (Gyr)"];
                        double a_avg = inputs["Expansão média ⟨a⟩"];
                        
                        // Aproximação: d_p ≈ c·t₀/⟨a⟩ (integrando backward)
                        double c_Gly_per_Gyr = 0.9777; // velocidade luz em Gly/Gyr
                        double d_p = (c_Gly_per_Gyr * t0) / a_avg;
                        
                        return d_p;
                    },
                    Icone = "🌌"
                },

                // V10-093: Acoustic Scale (BAO)
                new Formula
                {
                    Id = "3681",
                    CodigoCompendio = "V10-093",
                    Nome = "Escala Acústica (BAO)",
                    Categoria = "Cosmologia",
                    SubCategoria = "Oscilações Acústicas Bariônicas",
                    Expressao = @"r_s = ∫₀^t_drag c_s dt/a(t) ≈ 150 Mpc",
                    Descricao = "Escala das oscilações acústicas bariônicas. Ondas sonoras no plasma primordial 'congelam' no drag epoch. BAO: régua padrão para medir H(z) e d_A(z).",
                    ExemploPratico = "Planck: r_s≈147 Mpc. BAO survey (SDSS): pico em correlação galáxias em ~150 Mpc. z_drag≈1020. Precisão H₀: 1% graças a BAO.",
                    Criador = "Peebles-Yu (1970, predição); Eisenstein et al. (2005, SDSS detecção)",
                    AnoOrigin = "2005",
                    VariavelResultado = "r_s",
                    UnidadeResultado = "Mpc",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Velocidade som c_s/c", Simbolo = "cs", Unidade = "", ValorPadrao = 0.57 },
                        new Variavel { Nome = "Tempo drag (kyr)", Simbolo = "t_drag", Unidade = "kyr", ValorPadrao = 370 }
                    },
                    Calcular = inputs =>
                    {
                        double cs_frac = inputs["Velocidade som c_s/c"];
                        double t_drag_kyr = inputs["Tempo drag (kyr)"];
                        
                        double c = 299792.458; // km/s
                        double cs = c * cs_frac;
                        
                        // Converter tempo para segundos
                        double t_drag_s = t_drag_kyr * 1000 * 365.25 * 24 * 3600;
                        
                        // Escala acústica (aproximação)
                        double r_s_km = cs * t_drag_s / 2; // dividir por 2 pela expansão média
                        double r_s_Mpc = r_s_km / 3.086e19;
                        
                        return r_s_Mpc;
                    },
                    Icone = "🌌"
                },

                // V10-094: Lente Gravitacional Fraca
                new Formula
                {
                    Id = "3682",
                    CodigoCompendio = "V10-094",
                    Nome = "Lente Gravitacional Fraca — Convergência",
                    Categoria = "Cosmologia",
                    SubCategoria = "Lentes Gravitacionais",
                    Expressao = @"κ = Σ/Σ_crit; Σ_crit = c²/(4πG)·(D_s/(D_l·D_ls))",
                    Descricao = "κ: convergência (magnificação). Σ: densidade superficial. Σ_crit: densidade crítica. κ>1: múltiplas imagens. κ<<1: weak lensing (distorção shear).",
                    ExemploPratico = "Abell 1689: κ_max≈0.5 (strong lensing central). Cosmic shear: κ≈0.01 (mapeia matéria escura). z_l=0.5, z_s=1: Σ_crit≈1 g/cm².",
                    Criador = "Einstein (1936, predição); Walsh et al. (1979, primeira detecção múltiplas imagens)",
                    AnoOrigin = "1979",
                    VariavelResultado = "Σ_crit",
                    UnidadeResultado = "g/cm²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Distância lens D_l (Gpc)", Simbolo = "D_l", Unidade = "Gpc", ValorPadrao = 1 },
                        new Variavel { Nome = "Distância source D_s (Gpc)", Simbolo = "D_s", Unidade = "Gpc", ValorPadrao = 2 }
                    },
                    Calcular = inputs =>
                    {
                        double D_l_Gpc = inputs["Distância lens D_l (Gpc)"];
                        double D_s_Gpc = inputs["Distância source D_s (Gpc)"];
                        
                        if (D_l_Gpc >= D_s_Gpc) return 0;
                        
                        double D_ls_Gpc = D_s_Gpc - D_l_Gpc;
                        
                        double c = 2.998e8; // m/s
                        double G = 6.674e-11; // m³/(kg·s²)
                        
                        // Converter para SI
                        double D_l = D_l_Gpc * 3.086e25; // m
                        double D_s = D_s_Gpc * 3.086e25;
                        double D_ls = D_ls_Gpc * 3.086e25;
                        
                        double Sigma_crit = (c * c / (4 * Math.PI * G)) * (D_s / (D_l * D_ls));
                        
                        // Converter para g/cm²
                        double Sigma_crit_g_cm2 = Sigma_crit / 10;
                        
                        return Sigma_crit_g_cm2;
                    },
                    Icone = "🌌"
                },

                // V10-095: Espectro de Potência da Matéria
                new Formula
                {
                    Id = "3683",
                    CodigoCompendio = "V10-095",
                    Nome = "Espectro de Potência da Matéria P(k)",
                    Categoria = "Cosmologia",
                    SubCategoria = "Formação de Estruturas",
                    Expressao = @"P(k) = A·k^n·T²(k); T(k): função transfer",
                    Descricao = "Descreve flutuações de densidade em diferentes escalas. k pequeno: grandes estruturas. k grande: pequenas escalas. Pico em k~0.02 h/Mpc (escala galáctica).",
                    ExemploPratico = "SDSS: P(k) medido até k~0.2 h/Mpc. CDM: P(k)~k para k→0. Matéria escura quente (neutrinos): suprime P(k) em altas k (free-streaming).",
                    Criador = "Peebles (1980, Large-scale structure); SDSS/2dF (2000s, medidas precisas)",
                    AnoOrigin = "1980",
                    VariavelResultado = "P_k",
                    UnidadeResultado = "(Mpc/h)³",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k (h/Mpc)", Simbolo = "k", Unidade = "h/Mpc", ValorPadrao = 0.1 },
                        new Variavel { Nome = "σ₈", Simbolo = "σ8", Unidade = "", ValorPadrao = 0.81 }
                    },
                    Calcular = inputs =>
                    {
                        double k = inputs["k (h/Mpc)"];
                        double sigma8 = inputs["σ₈"];
                        
                        // Aproximação BBKS transfer function
                        double q = k / (0.073 * sigma8);
                        double T_k = Math.Log(1 + 2.34 * q) / (2.34 * q) * Math.Pow(1 + 3.89 * q + Math.Pow(16.1 * q, 2) + Math.Pow(5.46 * q, 3) + Math.Pow(6.71 * q, 4), -0.25);
                        
                        double n = 0.96; // spectral index
                        double A = 1e4; // normalization
                        
                        double P_k = A * Math.Pow(k, n) * T_k * T_k;
                        
                        return P_k;
                    },
                    Icone = "🌌"
                },

                // V10-096: Crescimento de Estruturas
                new Formula
                {
                    Id = "3684",
                    CodigoCompendio = "V10-096",
                    Nome = "Fator de Crescimento D(z)",
                    Categoria = "Cosmologia",
                    SubCategoria = "Formação de Estruturas",
                    Expressao = @"δ(z) = δ₀·D(z); D(z) = g(z)/(1+z)",
                    Descricao = "Perturbações de densidade crescem como δ∝a (era de matéria). Energia escura suprime crescimento. g(z): fator de supressão. Medido via weak lensing, redshift-space distortions.",
                    ExemploPratico = "z=1: D≈0.6 (60% do crescimento desde então). Clustering galáxias: mede σ₈(z)=σ₈·D(z)/D(0). RSD: mede fσ₈ (f: growth rate).",
                    Criador = "Peebles (1980); Heath (1977, numerical solutions)",
                    AnoOrigin = "1977",
                    VariavelResultado = "D_z",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Redshift z", Simbolo = "z", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Ω_m", Simbolo = "Om", Unidade = "", ValorPadrao = 0.3 }
                    },
                    Calcular = inputs =>
                    {
                        double z = inputs["Redshift z"];
                        double Om = inputs["Ω_m"];
                        
                        // Aproximação Carroll-Press-Turner
                        double a = 1.0 / (1 + z);
                        double Om_z = Om * Math.Pow(1 + z, 3) / (Om * Math.Pow(1 + z, 3) + (1 - Om));
                        double g_z = 2.5 * Om_z / (Math.Pow(Om_z, 4.0 / 7.0) - (1 - Om_z) + (1 + Om_z / 2) * (1 + (1 - Om_z) / 70));
                        
                        double D_z = a * g_z;
                        
                        return D_z;
                    },
                    Icone = "🌌"
                },

                // V10-097: Efeito Sunyaev-Zel'dovich (SZ)
                new Formula
                {
                    Id = "3685",
                    CodigoCompendio = "V10-097",
                    Nome = "Efeito Sunyaev-Zel'dovich (SZ)",
                    Categoria = "Cosmologia",
                    SubCategoria = "Aglomerados de Galáxias",
                    Expressao = @"ΔT/T = −2·y; y = ∫(k_B T_e)/(m_e c²)·n_e·σ_T·dl",
                    Descricao = "Distorção do CMB ao passar por gás quente em aglomerados. y: parâmetro Compton. ΔT<0 para ν<217 GHz (decremento). Independente de z!",
                    ExemploPratico = "Coma cluster: y≈2×10^-4, ΔT≈−0.5mK. Planck: detectou ~1200 clusters via SZ. Massa cluster: M∝Y_SZ (integrated y).",
                    Criador = "Sunyaev e Zel'dovich (1970, predição); Birkinshaw et al. (1984, primeira detecção)",
                    AnoOrigin = "1970",
                    VariavelResultado = "ΔT",
                    UnidadeResultado = "mK",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Parâmetro y", Simbolo = "y", Unidade = "", ValorPadrao = 2e-4 },
                        new Variavel { Nome = "T_CMB (K)", Simbolo = "T_CMB", Unidade = "K", ValorPadrao = 2.725 }
                    },
                    Calcular = inputs =>
                    {
                        double y = inputs["Parâmetro y"];
                        double T_CMB = inputs["T_CMB (K)"];
                        
                        // Efeito SZ térmico
                        double deltaT_over_T = -2 * y;
                        double deltaT_K = deltaT_over_T * T_CMB;
                        double deltaT_mK = deltaT_K * 1000;
                        
                        return deltaT_mK;
                    },
                    Icone = "🌌"
                },

                // V10-098: Massa de Neutrinos (Limite Cosmológico)
                new Formula
                {
                    Id = "3686",
                    CodigoCompendio = "V10-098",
                    Nome = "Massa de Neutrinos — Limite Cosmológico",
                    Categoria = "Cosmologia",
                    SubCategoria = "Neutrinos Cosmológicos",
                    Expressao = @"Σm_ν < 0.12 eV (95% CL, Planck+BAO)",
                    Descricao = "Neutrinos suprimem P(k) em pequenas escalas (free-streaming). Ω_ν = Σm_ν/(93.14h² eV). Planck+LSS: Σm_ν < 0.12 eV. Oscilações neutrinos: Δm²≈7.5×10^-5 eV².",
                    ExemploPratico = "3 neutrinos degenerados 0.04 eV cada: Σm_ν=0.12 eV. Hierarquia normal: m₁≈0, m₂≈0.009 eV, m₃≈0.05 eV. KATRIN: limite laboratorial ~1 eV.",
                    Criador = "Dodelson-Widrow (1994, hot dark matter); Planck (2018, limite cosmológico)",
                    AnoOrigin = "1994",
                    VariavelResultado = "Ω_ν",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Σm_ν (eV)", Simbolo = "sum_mnu", Unidade = "eV", ValorPadrao = 0.06 },
                        new Variavel { Nome = "h", Simbolo = "h", Unidade = "", ValorPadrao = 0.7 }
                    },
                    Calcular = inputs =>
                    {
                        double sum_mnu = inputs["Σm_ν (eV)"];
                        double h = inputs["h"];
                        
                        double Omega_nu = sum_mnu / (93.14 * h * h);
                        
                        return Omega_nu;
                    },
                    Icone = "🌌"
                },

                // V10-099: Função de Massa de Halos
                new Formula
                {
                    Id = "3687",
                    CodigoCompendio = "V10-099",
                    Nome = "Função de Massa de Halos (Sheth-Tormen)",
                    Categoria = "Cosmologia",
                    SubCategoria = "Halos de Matéria Escura",
                    Expressao = @"dn/dM = (ρ_m/M)·(dln σ^-1/dM)·f(σ)",
                    Descricao = "Número de halos por unidade de massa. σ(M): variância flutuações em escala M. f(σ): multiplicity function. Press-Schechter: f∝exp(−ν²/2). Sheth-Tormen: melhor fit N-body.",
                    ExemploPratico = "M=10^14 M_☉ (cluster): ~10^-6 comoving Mpc^-3. M=10^12 M_☉ (galáxia): ~0.01 Mpc^-3. Função de massa: prediz abundância clusters vs z (teste energia escura).",
                    Criador = "Press-Schechter (1974); Sheth-Tormen (1999, melhorias)",
                    AnoOrigin = "1974",
                    VariavelResultado = "n_halos",
                    UnidadeResultado = "Mpc^-3",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "log₁₀(M/M_☉)", Simbolo = "log_M", Unidade = "", ValorPadrao = 14 },
                        new Variavel { Nome = "σ(M)", Simbolo = "σ", Unidade = "", ValorPadrao = 0.5 }
                    },
                    Calcular = inputs =>
                    {
                        double log_M = inputs["log₁₀(M/M_☉)"];
                        double sigma = inputs["σ(M)"];
                        
                        double M = Math.Pow(10, log_M);
                        
                        // Press-Schechter approximation
                        double nu = 1.686 / sigma;
                        double f_sigma = Math.Sqrt(2 / Math.PI) * nu * Math.Exp(-nu * nu / 2);
                        
                        // dn/dM approximation (orden de magnitude)
                        double rho_m = 2.78e11; // M_☉/Mpc³ (h=0.7)
                        double dln_sigma_inv_dM = 0.3 / M; // approximate power-law
                        
                        double dn_dM = (rho_m / M) * dln_sigma_inv_dM * f_sigma;
                        
                        // Integrate over log bin
                        double n_halos = dn_dM * M * Math.Log(10) * 0.1; // Δlog M = 0.1
                        
                        return n_halos;
                    },
                    Icone = "🌌"
                },

                // V10-100: Parâmetro de Hubble Normalizado E(z)
                new Formula
                {
                    Id = "3688",
                    CodigoCompendio = "V10-100",
                    Nome = "Parâmetro de Hubble Normalizado E(z)",
                    Categoria = "Cosmologia",
                    SubCategoria = "Expansão do Universo",
                    Expressao = @"E(z) = H(z)/H₀ = √[Ω_m(1+z)³ + Ω_Λ]",
                    Descricao = "Evolução do parâmetro de Hubble. Flat ΛCDM: E²(z)=Ω_m(1+z)³+Ω_Λ. z→∞: E∝(1+z)^(3/2) (matéria). z→−1: E→√Ω_Λ (de Sitter).",
                    ExemploPratico = "z=1: E(1)≈1.77 (H≈123 km/s/Mpc). z=1089 (CMB): E≈4000. BAO mede E(z) via escala angular. H(z)=H₀·E(z).",
                    Criador = "Friedmann equation (1922); parametrização moderna (anos 1990s)",
                    AnoOrigin = "1990",
                    VariavelResultado = "E_z",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Redshift z", Simbolo = "z", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Ω_m", Simbolo = "Om", Unidade = "", ValorPadrao = 0.3 },
                        new Variavel { Nome = "Ω_Λ", Simbolo = "OL", Unidade = "", ValorPadrao = 0.7 }
                    },
                    Calcular = inputs =>
                    {
                        double z = inputs["Redshift z"];
                        double Om = inputs["Ω_m"];
                        double OL = inputs["Ω_Λ"];
                        
                        double E_z = Math.Sqrt(Om * Math.Pow(1 + z, 3) + OL);
                        
                        return E_z;
                    },
                    Icone = "🌌"
                },

                // V10-101: Tempo de Lookback
                new Formula
                {
                    Id = "3689",
                    CodigoCompendio = "V10-101",
                    Nome = "Tempo de Lookback",
                    Categoria = "Cosmologia",
                    SubCategoria = "Tempo Cosmológico",
                    Expressao = @"t_L(z) = ∫₀^z dz'/[(1+z')H(z')]",
                    Descricao = "Tempo desde z até hoje. z=1: t_L≈7.7 Gyr (vemos galáxia como era 7.7 Gyr atrás). z=1089 (CMB): t_L≈13.8 Gyr (quase idade do universo).",
                    ExemploPratico = "Galáxia z=2: observamos como era t_L≈10.3 Gyr atrás (~3.5 Gyr após Big Bang). Quasar z=7: t_L≈13 Gyr (apenas 0.8 Gyr após BB). High-z: maioria do tempo já passou.",
                    Criador = "Integral de Friedmann; cálculos numéricos (anos 1990s com ΛCDM)",
                    AnoOrigin = "1990",
                    VariavelResultado = "t_L",
                    UnidadeResultado = "Gyr",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Redshift z", Simbolo = "z", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "H0 (km/s/Mpc)", Simbolo = "H0", Unidade = "km/s/Mpc", ValorPadrao = 70 }
                    },
                    Calcular = inputs =>
                    {
                        double z = inputs["Redshift z"];
                        double H0 = inputs["H0 (km/s/Mpc)"];
                        
                        double H0_SI = H0 * 1000 / (3.086e22);
                        double t_H = 1.0 / H0_SI; // Hubble time
                        
                        // Aproximação para ΛCDM (Ω_m=0.3, Ω_Λ=0.7)
                        double Om = 0.3;
                        double OL = 0.7;
                        
                        // Integral aproximada
                        double integral = 0;
                        int N = 100;
                        double dz = z / N;
                        for (int i = 0; i < N; i++)
                        {
                            double z_i = i * dz + dz / 2;
                            double E_z = Math.Sqrt(Om * Math.Pow(1 + z_i, 3) + OL);
                            integral += dz / ((1 + z_i) * E_z);
                        }
                        
                        double t_L_sec = t_H * integral;
                        double t_L_Gyr = t_L_sec / (3.1536e16);
                        
                        return t_L_Gyr;
                    },
                    Icone = "🌌"
                }
            });
        }
    }
}
