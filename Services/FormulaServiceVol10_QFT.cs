using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE VIII
    /// MECÂNICA QUÂNTICA DE CAMPOS (QFT) — INTRODUÇÃO
    /// Fórmulas V10-142 a V10-160 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_QFT()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3730",
                    CodigoCompendio = "V10-142",
                    Nome = "Lagrangiana de Klein-Gordon",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Campos Escalares",
                    Expressao = @"ℒ = ½(∂_μφ)(∂^μφ) − ½m²φ²",
                    Descricao = "Campo escalar relativístico. Equação de movimento: (□ + m²)φ = 0. m: massa da partícula.",
                    ExemploPratico = "Bóson de Higgs: campo escalar com m≈125 GeV/c². Pions: aproximadamente Klein-Gordon.",
                    Criador = "Klein (1926); Gordon (1926)",
                    AnoOrigin = "1926",
                    VariavelResultado = "compton",
                    UnidadeResultado = "fm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Massa m (GeV/c²)", Simbolo = "m", Unidade = "GeV/c²", ValorPadrao = 125 }
                    },
                    Calcular = inputs =>
                    {
                        double m = inputs["Massa m (GeV/c²)"];
                        double hbar_c = 0.197; // GeV·fm
                        double compton = hbar_c / m;
                        return compton;
                    },
                    Icone = "⚛️"
                },

                // V10-143: Lagrangiana de Dirac
                new Formula
                {
                    Id = "3731",
                    CodigoCompendio = "V10-143",
                    Nome = "Lagrangiana de Dirac",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Campos Fermiônicos",
                    Expressao = @"ℒ = ψ̄(iγ^μ∂_μ − m)ψ",
                    Descricao = "Campo espinorial (férmions spin-½). ψ̄=ψ†γ⁰. Equação Dirac: (iγ^μ∂_μ − m)ψ=0. Prediz antipartículas, spin, momento magnético anômalo.",
                    ExemploPratico = "Elétron: m_e=0.511 MeV/c². Momento magnético: g≈2.002 (QED correção ~α/2π). Positron: antipartícula prevista Dirac 1928, descoberta Anderson 1932 (Nobel 1936).",
                    Criador = "Dirac (1928, Proc. R. Soc., Nobel 1933)",
                    AnoOrigin = "1928",
                    VariavelResultado = "m_e",
                    UnidadeResultado = "MeV/c²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tipo (1=e,2=μ,3=quark u)", Simbolo = "tipo", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        int tipo = (int)inputs["Tipo (1=e,2=μ,3=quark u)"];
                        double m = 0;
                        switch (tipo)
                        {
                            case 1: m = 0.511; break; // elétron
                            case 2: m = 105.7; break; // múon
                            case 3: m = 2.2; break; // quark u
                        }
                        return m;
                    },
                    Icone = "⚛️"
                },

                // V10-144: Regras de Feynman — Propagador
                new Formula
                {
                    Id = "3732",
                    CodigoCompendio = "V10-144",
                    Nome = "Propagador de Férmion",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Diagramas de Feynman",
                    Expressao = @"S_F(p) = i/(p̸ − m + iε)",
                    Descricao = "Propagador férmion momentum p. p̸=γ^μp_μ. iε: prescrição Feynman (causalidade). Polo em p²=m² (partícula on-shell).",
                    ExemploPratico = "Scattering e⁻e⁻: propagador fóton 1/q². Pair production γ→e⁺e⁻: threshold √s≥2m_e. Virtual particles: p²≠m² (off-shell).",
                    Criador = "Feynman (1948, Phys. Rev., Nobel 1965); Dyson (1949, notação)",
                    AnoOrigin = "1948",
                    VariavelResultado = "prop",
                    UnidadeResultado = "1/GeV²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "p² (GeV²)", Simbolo = "p2", Unidade = "GeV²", ValorPadrao = 1 },
                        new Variavel { Nome = "m (GeV/c²)", Simbolo = "m", Unidade = "GeV/c²", ValorPadrao = 0.0005 }
                    },
                    Calcular = inputs =>
                    {
                        double p2 = inputs["p² (GeV²)"];
                        double m = inputs["m (GeV/c²)"];
                        
                        double denominator = p2 - m * m;
                        if (Math.Abs(denominator) < 1e-6) return 1e6; // perto do polo
                        
                        double prop = 1.0 / Math.Abs(denominator);
                        return prop;
                    },
                    Icone = "⚛️"
                },

                // V10-145: Constante de Acoplamento QED
                new Formula
                {
                    Id = "3733",
                    CodigoCompendio = "V10-145",
                    Nome = "Constante de Estrutura Fina α",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "QED",
                    Expressao = @"α = e²/(4πε₀ℏc) ≈ 1/137",
                    Descricao = "Força acoplamento eletromagnético. α~10^-2: perturbação válida. Running α: varia com energia Q² (renormalização). α(m_Z)≈1/128.",
                    ExemploPratico = "Vértice e-γ: fator ~√α. Amplitude ∝ α^n (n vértices). e⁺e⁻→γ→μ⁺μ⁻: ordem α². Lamb shift: correção ~α⁵ (QED test ~10^-12 precisão).",
                    Criador = "Sommerfeld (1916, espectroscopia); QED (Feynman-Schwinger-Tomonaga 1940s, Nobel 1965)",
                    AnoOrigin = "1916",
                    VariavelResultado = "α",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Escala Q (GeV)", Simbolo = "Q", Unidade = "GeV", ValorPadrao = 0.511e-3 }
                    },
                    Calcular = inputs =>
                    {
                        double Q = inputs["Escala Q (GeV)"];
                        
                        // Running coupling (simplified)
                        double alpha_0 = 1.0 / 137.036;
                        double m_e = 0.511e-3; // GeV
                        
                        if (Q < m_e) return alpha_0;
                        
                        // α(Q) ≈ α₀/(1 − (α₀/3π)·ln(Q²/m_e²))
                        double log_term = Math.Log(Q * Q / (m_e * m_e));
                        double alpha_Q = alpha_0 / (1 - (alpha_0 / (3 * Math.PI)) * log_term);
                        
                        return alpha_Q;
                    },
                    Icone = "⚛️"
                },

                // V10-146: Seção de Choque QED
                new Formula
                {
                    Id = "3734",
                    CodigoCompendio = "V10-146",
                    Nome = "Seção de Choque Mott",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Scattering",
                    Expressao = @"dσ/dΩ = (α²/4E²)·(1/sin⁴(θ/2))",
                    Descricao = "Scattering elétron-núcleo (spin neglected). θ: ângulo espalhamento. Rutherford: limite clássico. Forma Mott: correção relativística.",
                    ExemploPratico = "e⁻ + Au (Z=79) a E=1 MeV: θ=10°→dσ/dΩ≈10³ barn/sr. θ=90°→~1 barn/sr. Geiger-Marsden (1909): descoberta núcleo atômico.",
                    Criador = "Mott (1929, Proc. R. Soc.); Rutherford (1911, clássico)",
                    AnoOrigin = "1929",
                    VariavelResultado = "dsigma_dOmega",
                    UnidadeResultado = "barn/sr",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "E (MeV)", Simbolo = "E", Unidade = "MeV", ValorPadrao = 1 },
                        new Variavel { Nome = "θ (graus)", Simbolo = "theta", Unidade = "graus", ValorPadrao = 90 },
                        new Variavel { Nome = "Z (carga núcleo)", Simbolo = "Z", Unidade = "", ValorPadrao = 79 }
                    },
                    Calcular = inputs =>
                    {
                        double E = inputs["E (MeV)"];
                        double theta_deg = inputs["θ (graus)"];
                        double Z = inputs["Z (carga núcleo)"];
                        
                        double alpha = 1.0 / 137.036;
                        double theta_rad = theta_deg * Math.PI / 180;
                        
                        double sin_half = Math.Sin(theta_rad / 2);
                        if (sin_half < 1e-6) return 1e10;
                        
                        double E_GeV = E / 1000;
                        double factor = (alpha * alpha * Z * Z) / (4 * E_GeV * E_GeV);
                        double dsigma = factor / Math.Pow(sin_half, 4);
                        
                        // Convert to barn/sr (1 GeV^-2 = 0.389 mb)
                        double dsigma_barn = dsigma * 0.389e6; // barn/sr
                        
                        return dsigma_barn;
                    },
                    Icone = "⚛️"
                },

                // V10-147: Renormalização
                new Formula
                {
                    Id = "3735",
                    CodigoCompendio = "V10-147",
                    Nome = "Função Beta QED",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Renormalização",
                    Expressao = @"β(α) = dα/d(ln μ) = (2α²)/(3π) + O(α³)",
                    Descricao = "Running coupling: α cresce com energia. β>0: não-assintoticamente livre (Landau pole ~10^286 GeV). Vacuum polarization: fermion loops blindam carga.",
                    ExemploPratico = "α(m_e)≈1/137→α(m_Z)≈1/128 (~7% aumento). α(10^19 GeV)≈1/20? (extrapolação). Comparison: QCD β<0 (assintotic freedom, Nobel 2004).",
                    Criador = "Gell-Mann-Low (1954, renormalization group); Callan-Symanzik (1970)",
                    AnoOrigin = "1954",
                    VariavelResultado = "β",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "α", Simbolo = "alpha", Unidade = "", ValorPadrao = 1.0 / 137 }
                    },
                    Calcular = inputs =>
                    {
                        double alpha = inputs["α"];
                        
                        // Leading order beta function
                        double beta = (2 * alpha * alpha) / (3 * Math.PI);
                        
                        return beta;
                    },
                    Icone = "⚛️"
                },

                // V10-148: Anomalia Momento Magnético
                new Formula
                {
                    Id = "3736",
                    CodigoCompendio = "V10-148",
                    Nome = "Momento Magnético Anômalo (g−2)",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Correções Radiativas",
                    Expressao = @"a_e = (g−2)/2 = α/(2π) + O(α²)",
                    Descricao = "Dirac: g=2. QED correções: g>2. a_e medido ~10^-12 precisão (melhor teste QED). Vertex correction: Schwinger 1948 (α/2π).",
                    ExemploPratico = "Elétron: a_e=0.00115965218073(28) (exp). Teoria: a_e^QED+a_e^hadronic+a_e^weak. Múon: a_μ discrepância ~4σ (nova física?).",
                    Criador = "Schwinger (1948, Phys. Rev., primeiro cálculo α/2π)",
                    AnoOrigin = "1948",
                    VariavelResultado = "a_e",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Ordem perturbação", Simbolo = "ordem", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        int ordem = (int)inputs["Ordem perturbação"];
                        double alpha = 1.0 / 137.036;
                        
                        double a_e = 0;
                        if (ordem >= 1) a_e += alpha / (2 * Math.PI); // Schwinger term
                        if (ordem >= 2) a_e += -0.328478965 * Math.Pow(alpha / Math.PI, 2); // 2-loop
                        if (ordem >= 3) a_e += 1.181241456 * Math.Pow(alpha / Math.PI, 3); // 3-loop
                        
                        return a_e;
                    },
                    Icone = "⚛️"
                },

                // V10-149: Quebra Espontânea Simetria
                new Formula
                {
                    Id = "3737",
                    CodigoCompendio = "V10-149",
                    Nome = "Potencial Higgs (Mexican Hat)",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Quebra de Simetria",
                    Expressao = @"V(φ) = −μ²φ² + λφ⁴",
                    Descricao = "μ²>0: mínimo em φ≠0 (quebra espontânea). φ₀=√(μ²/2λ). Goldstone bosons: massless (se simetria contínua). Higgs mechanism: gauge bosons ganham massa.",
                    ExemploPratico = "Higgs VEV: v≈246 GeV. Massa W/Z: m_W=g·v/2≈80 GeV. Massa Higgs: m_h²=2λv². λ≈0.13. Nobel 2013 (Higgs, Englert).",
                    Criador = "Goldstone (1961); Higgs-Englert-Brout (1964, mecanismo Higgs)",
                    AnoOrigin = "1964",
                    VariavelResultado = "φ₀",
                    UnidadeResultado = "GeV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "μ² (GeV²)", Simbolo = "mu2", Unidade = "GeV²", ValorPadrao = 1e4 },
                        new Variavel { Nome = "λ", Simbolo = "lambda", Unidade = "", ValorPadrao = 0.13 }
                    },
                    Calcular = inputs =>
                    {
                        double mu2 = inputs["μ² (GeV²)"];
                        double lambda = inputs["λ"];
                        
                        if (lambda <= 0 || mu2 <= 0) return 0;
                        
                        double phi0 = Math.Sqrt(mu2 / (2 * lambda));
                        return phi0;
                    },
                    Icone = "⚛️"
                },

                // V10-150: Unitariedade
                new Formula
                {
                    Id = "3738",
                    CodigoCompendio = "V10-150",
                    Nome = "Limite de Unitariedade — Amplitude Parcial",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Vínculos Teóricos",
                    Expressao = @"|a_ℓ| ≤ 1; σ_total ≤ (4π/k²)·Σ(2ℓ+1)",
                    Descricao = "Amplitude parcial unitária: |a_ℓ|≤1. Violação: teoria inconsistente (nova física). WW scattering: divergiria sem Higgs (unitarização).",
                    ExemploPratico = "W⁺W⁻→W⁺W⁻: sem Higgs, viola unitariedade √s~1 TeV. Higgs cancela: m_h<1 TeV predito. Descoberta 2012: m_h=125 GeV confirmou.",
                    Criador = "Princípio geral mecânica quântica; aplicado EW (Lee-Quigg-Thacker 1977)",
                    AnoOrigin = "1977",
                    VariavelResultado = "s_max",
                    UnidadeResultado = "GeV²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_W (GeV)", Simbolo = "m_W", Unidade = "GeV", ValorPadrao = 80 }
                    },
                    Calcular = inputs =>
                    {
                        double m_W = inputs["m_W (GeV)"];
                        
                        // Unitarity violation scale (approximate)
                        double s_max = 16 * Math.PI * m_W * m_W / 3;
                        
                        return s_max;
                    },
                    Icone = "⚛️"
                },

                // V10-151: Teorema CPT
                new Formula
                {
                    Id = "3739",
                    CodigoCompendio = "V10-151",
                    Nome = "Teorema CPT",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Simetrias Fundamentais",
                    Expressao = @"m_particle = m_antiparticle; τ_particle = τ_antiparticle",
                    Descricao = "CPT (Charge-Parity-Time): simetria exata QFT locais Lorentz-invariantes. Violação CPT: nova física radical. Tested: m_K⁰−m_K̄⁰<10^-18 GeV.",
                    ExemploPratico = "Kaon neutral: Δm/m<10^-18. Antihydrogen: compare espectro com H (~10^-12). CP violation (K, B mesons): OK se T violado também (CPT conservado).",
                    Criador = "Lüders (1954); Pauli (1955, formulação geral)",
                    AnoOrigin = "1954",
                    VariavelResultado = "Δm_relativo",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Δm (GeV)", Simbolo = "Dm", Unidade = "GeV", ValorPadrao = 1e-18 },
                        new Variavel { Nome = "m (GeV)", Simbolo = "m", Unidade = "GeV", ValorPadrao = 0.5 }
                    },
                    Calcular = inputs =>
                    {
                        double Dm = inputs["Δm (GeV)"];
                        double m = inputs["m (GeV)"];
                        
                        if (m == 0) return 0;
                        double Dm_rel = Dm / m;
                        return Dm_rel;
                    },
                    Icone = "⚛️"
                },

                // V10-152: Matriz S (Scattering)
                new Formula
                {
                    Id = "3740",
                    CodigoCompendio = "V10-152",
                    Nome = "Matriz S e Seção de Choque",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Teoria de Scattering",
                    Expressao = @"σ = ∫|M|²·dΠ_LIPS",
                    Descricao = "S-matrix: ⟨f|S|i⟩. M: amplitude invariante. dΠ_LIPS: espaço fase Lorentz-invariante. σ∝|M|². Unitaridade: SS†=1→optical theorem.",
                    ExemploPratico = "e⁺e⁻→μ⁺μ⁻: σ=(4πα²)/(3s). √s=91 GeV (Z⁰ pole): σ~30 nb (ressonância). LEP: mediu Z width Γ_Z=2.5 GeV.",
                    Criador = "Wheeler (1937, S-matrix); Heisenberg (1943, formalismo); LSZ (1955, reduction formula)",
                    AnoOrigin = "1955",
                    VariavelResultado = "σ",
                    UnidadeResultado = "pb",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "√s (GeV)", Simbolo = "sqrt_s", Unidade = "GeV", ValorPadrao = 10 },
                        new Variavel { Nome = "Processo (1=ee→μμ,2=qq̄)", Simbolo = "proc", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double sqrt_s = inputs["√s (GeV)"];
                        int proc = (int)inputs["Processo (1=ee→μμ,2=qq̄)"];
                        
                        double alpha = 1.0 / 137;
                        double s = sqrt_s * sqrt_s;
                        
                        double sigma_GeV2 = 0;
                        if (proc == 1) // e+e- -> mu+mu-
                        {
                            sigma_GeV2 = (4 * Math.PI * alpha * alpha) / (3 * s);
                        }
                        else // e+e- -> hadrons (simplified)
                        {
                            double R = 3.5; // sum of quark charges squared × 3 colors
                            sigma_GeV2 = R * (4 * Math.PI * alpha * alpha) / (3 * s);
                        }
                        
                        // Convert GeV^-2 to pb (1 GeV^-2 = 0.389 mb = 3.89e8 pb)
                        double sigma_pb = sigma_GeV2 * 3.89e8;
                        
                        return sigma_pb;
                    },
                    Icone = "⚛️"
                },

                // V10-153: Cromodinâmica Quântica (QCD)
                new Formula
                {
                    Id = "3741",
                    CodigoCompendio = "V10-153",
                    Nome = "Running Coupling QCD α_s(Q)",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "QCD",
                    Expressao = @"α_s(Q²) = α_s(μ²)/[1 + β₀α_s(μ²)·ln(Q²/μ²)]",
                    Descricao = "β₀=(11C_A−2n_f)/(12π) <0: assintotic freedom (Nobel 2004). Q↑: α_s↓ (quarks livres). Q↓: α_s↑ (confinamento). n_f: sabores ativos.",
                    ExemploPratico = "α_s(m_Z)≈0.118. α_s(1 GeV)≈0.5 (perturbação falha). α_s(100 GeV)≈0.08. Λ_QCD≈200 MeV: escala confinamento. Jets: manifestação quarks/gluons.",
                    Criador = "Gross-Wilczek, Politzer (1973, assintotic freedom, Nobel 2004)",
                    AnoOrigin = "1973",
                    VariavelResultado = "α_s",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Q (GeV)", Simbolo = "Q", Unidade = "GeV", ValorPadrao = 91 }
                    },
                    Calcular = inputs =>
                    {
                        double Q = inputs["Q (GeV)"];
                        
                        // Reference point
                        double mu = 91.2; // m_Z GeV
                        double alpha_s_mu = 0.118;
                        
                        if (Q < 0.5) return 1.0; // non-perturbative regime
                        
                        // Beta function (leading order, n_f=5 for Q~m_Z)
                        int n_f = (Q > 4.2) ? 5 : 4; // b quark threshold
                        double beta0 = (11 * 3 - 2 * n_f) / (12 * Math.PI); // C_A=3 for SU(3)
                        
                        double log_ratio = Math.Log(Q * Q / (mu * mu));
                        double alpha_s_Q = alpha_s_mu / (1 + beta0 * alpha_s_mu * log_ratio);
                        
                        return alpha_s_Q;
                    },
                    Icone = "⚛️"
                },

                // V10-154: Confinamento de Cor
                new Formula
                {
                    Id = "3742",
                    CodigoCompendio = "V10-154",
                    Nome = "Potencial Cornell (Confinamento)",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "QCD Não-Perturbativa",
                    Expressao = @"V(r) = −4α_s/(3r) + σ·r",
                    Descricao = "Coulomb curta distância + linear longa (string tension σ). σ≈1 GeV/fm: força constante ~16 tons! Impossível separar quarks: confinamento.",
                    ExemploPratico = "Charmonium (cc̄): níveis J/ψ, ψ(2S). σ≈0.9 GeV/fm. Separar qq̄ >1 fm: cria novos pares→hadronização (mesons/baryons). Lattice QCD: simula.",
                    Criador = "Cornell potential (Eichten et al. 1975); Wilson (1974, lattice QCD)",
                    AnoOrigin = "1975",
                    VariavelResultado = "V",
                    UnidadeResultado = "GeV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "r (fm)", Simbolo = "r", Unidade = "fm", ValorPadrao = 1 },
                        new Variavel { Nome = "σ (GeV/fm)", Simbolo = "sigma", Unidade = "GeV/fm", ValorPadrao = 0.9 }
                    },
                    Calcular = inputs =>
                    {
                        double r = inputs["r (fm)"];
                        double sigma = inputs["σ (GeV/fm)"];
                        
                        if (r <= 0) return double.PositiveInfinity;
                        
                        double alpha_s = 0.3; // typical at ~1 GeV scale
                        double hbar_c = 0.197; // GeV·fm
                        
                        double V_Coulomb = -4 * alpha_s * hbar_c / (3 * r);
                        double V_linear = sigma * r;
                        double V = V_Coulomb + V_linear;
                        
                        return V;
                    },
                    Icone = "⚛️"
                },

                // V10-155: Teorema Óptico
                new Formula
                {
                    Id = "3743",
                    CodigoCompendio = "V10-155",
                    Nome = "Teorema Óptico",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Unitariedade",
                    Expressao = @"σ_total = (4π/k)·Im[f(0)]",
                    Descricao = "Relaciona seção de choque total com parte imaginária amplitude forward (θ=0). Consequência unitariedade SS†=1. Analogia: luz (extinção=scattering+absorção).",
                    ExemploPratico = "pp scattering: σ_total≈100 mb (√s=14 TeV, LHC). Im[f(0)] grande: muitas interações inelásticas. Difração: pico forward.",
                    Criador = "Bohr-Peierls-Placzek (1939); formalismo moderno (anos 1950s)",
                    AnoOrigin = "1939",
                    VariavelResultado = "σ_total",
                    UnidadeResultado = "mb",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k (GeV)", Simbolo = "k", Unidade = "GeV", ValorPadrao = 7000 },
                        new Variavel { Nome = "Im[f(0)] (GeV^-1)", Simbolo = "Im_f", Unidade = "GeV^-1", ValorPadrao = 50 }
                    },
                    Calcular = inputs =>
                    {
                        double k = inputs["k (GeV)"];
                        double Im_f = inputs["Im[f(0)] (GeV^-1)"];
                        
                        if (k == 0) return 0;
                        
                        double sigma_GeV2 = (4 * Math.PI / k) * Im_f;
                        
                        // Convert GeV^-2 to mb (1 GeV^-2 = 0.389 mb)
                        double sigma_mb = sigma_GeV2 * 0.389;
                        
                        return sigma_mb;
                    },
                    Icone = "⚛️"
                },

                // V10-156: Fórmula de Breit-Wigner
                new Formula
                {
                    Id = "3744",
                    CodigoCompendio = "V10-156",
                    Nome = "Ressonância de Breit-Wigner",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Partículas Instáveis",
                    Expressao = @"σ(s) ∝ Γ_i·Γ_f/[(s−M²)² + M²Γ²]",
                    Descricao = "Ressonância massa M, largura total Γ. Γ_i: produção, Γ_f: decaimento. Pico em √s=M. τ=ℏ/Γ: lifetime. Γ/M: resolução natural.",
                    ExemploPratico = "Z⁰ boson: M=91.2 GeV, Γ=2.5 GeV→τ≈3×10^-25s. Pico LEP. ρ meson: M=770 MeV, Γ=150 MeV (largo: τ~10^-24s). Top quark: Γ_t≈1.4 GeV (decai antes hadronizar).",
                    Criador = "Breit e Wigner (1936, Phys. Rev.)",
                    AnoOrigin = "1936",
                    VariavelResultado = "σ_peak",
                    UnidadeResultado = "nb",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "M (GeV)", Simbolo = "M", Unidade = "GeV", ValorPadrao = 91.2 },
                        new Variavel { Nome = "Γ (GeV)", Simbolo = "Gamma", Unidade = "GeV", ValorPadrao = 2.5 },
                        new Variavel { Nome = "√s (GeV)", Simbolo = "sqrt_s", Unidade = "GeV", ValorPadrao = 91.2 }
                    },
                    Calcular = inputs =>
                    {
                        double M = inputs["M (GeV)"];
                        double Gamma = inputs["Γ (GeV)"];
                        double sqrt_s = inputs["√s (GeV)"];
                        
                        double s = sqrt_s * sqrt_s;
                        double M2 = M * M;
                        
                        double denominator = Math.Pow(s - M2, 2) + M2 * Gamma * Gamma;
                        if (denominator == 0) return 1e10;
                        
                        // Simplified peak cross section (arbitrary normalization)
                        double sigma_rel = 1.0 / denominator;
                        
                        // Scale to typical Z peak (~30 nb)
                        double sigma_nb = sigma_rel * 30 * denominator / (M2 * Gamma * Gamma) * Math.Pow(M2 * Gamma * Gamma, 1);
                        sigma_nb = 30000 * Gamma * Gamma / denominator; // proper normalization
                        
                        return sigma_nb;
                    },
                    Icone = "⚛️"
                },

                // V10-157: Mecanismo Seesaw (Neutrinos)
                new Formula
                {
                    Id = "3745",
                    CodigoCompendio = "V10-157",
                    Nome = "Mecanismo Seesaw — Massa de Neutrinos",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Física Além do Modelo Padrão",
                    Expressao = @"m_ν ≈ m_D²/M_R",
                    Descricao = "Neutrinos: massa pequena via seesaw. m_D~100 GeV (Dirac), M_R~10^15 GeV (Majorana right-handed)→m_ν~0.1 eV. Oscilações neutrinos: Nobel 2015.",
                    ExemploPratico = "m_D=100 GeV, M_R=10^14 GeV: m_ν≈0.1 eV (range observado). Δm²_atm≈2.5×10^-3 eV². Leptogenesis: explica assimetria baryon/antibaryon.",
                    Criador = "Minkowski (1977); Gell-Mann-Ramond-Slansky (1979); Yanagida (1979)",
                    AnoOrigin = "1977",
                    VariavelResultado = "m_ν",
                    UnidadeResultado = "eV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_D (GeV)", Simbolo = "m_D", Unidade = "GeV", ValorPadrao = 100 },
                        new Variavel { Nome = "M_R (GeV)", Simbolo = "M_R", Unidade = "GeV", ValorPadrao = 1e14 }
                    },
                    Calcular = inputs =>
                    {
                        double m_D = inputs["m_D (GeV)"];
                        double M_R = inputs["M_R (GeV)"];
                        
                        if (M_R == 0) return double.PositiveInfinity;
                        
                        double m_nu_GeV = (m_D * m_D) / M_R;
                        double m_nu_eV = m_nu_GeV * 1e9; // GeV to eV
                        
                        return m_nu_eV;
                    },
                    Icone = "⚛️"
                },

                // V10-158: Anomalias Quirais
                new Formula
                {
                    Id = "3746",
                    CodigoCompendio = "V10-158",
                    Nome = "Anomalia Quiral QCD (π⁰→γγ)",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Anomalias",
                    Expressao = @"Γ(π⁰→γγ) = (α²m_π³)/(64π³f_π²)",
                    Descricao = "Decay rate π⁰→2γ. Anomalia: simetria quiral clássica quebrada quanticamente. Triangle diagram (AVV). f_π≈92 MeV: pion decay constant.",
                    ExemploPratico = "m_π=135 MeV, f_π=92 MeV: Γ≈7.7 eV→τ≈8×10^-17s. Branching ratio ~99%. Predição QED+anomalia: acordo <1%. Adler-Bell-Jackiw (1969).",
                    Criador = "Adler (1969); Bell-Jackiw (1969, anomalia quiral)",
                    AnoOrigin = "1969",
                    VariavelResultado = "Γ",
                    UnidadeResultado = "eV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_π (MeV)", Simbolo = "m_pi", Unidade = "MeV", ValorPadrao = 135 },
                        new Variavel { Nome = "f_π (MeV)", Simbolo = "f_pi", Unidade = "MeV", ValorPadrao = 92 }
                    },
                    Calcular = inputs =>
                    {
                        double m_pi_MeV = inputs["m_π (MeV)"];
                        double f_pi_MeV = inputs["f_π (MeV)"];
                        
                        double alpha = 1.0 / 137;
                        double m_pi_eV = m_pi_MeV * 1e6;
                        double f_pi_eV = f_pi_MeV * 1e6;
                        
                        double Gamma_eV = (alpha * alpha * Math.Pow(m_pi_eV, 3)) / (64 * Math.Pow(Math.PI, 3) * f_pi_eV * f_pi_eV);
                        
                        return Gamma_eV;
                    },
                    Icone = "⚛️"
                },

                // V10-159: Produção de Pares
                new Formula
                {
                    Id = "3747",
                    CodigoCompendio = "V10-159",
                    Nome = "Threshold Produção de Pares",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Produção de Partículas",
                    Expressao = @"√s_threshold = 2m (par partícula-antipartícula)",
                    Descricao = "Energia mínima centro de massa. γγ→e⁺e⁻: √s≥2m_e=1.02 MeV. e⁺e⁻→tt̄: √s≥2m_t≈350 GeV. Phase space suppression perto threshold.",
                    ExemploPratico = "LEP-II: √s=209 GeV→não produz tt̄ (m_t=173 GeV). LHC pp: √s=14 TeV→abundante tt̄. Cosmic rays: γ+CMB→e⁺e⁻ (GZK cutoff).",
                    Criador = "Conservação energia-momento relativístico (Einstein 1905); pair production (Dirac 1930)",
                    AnoOrigin = "1930",
                    VariavelResultado = "s_threshold",
                    UnidadeResultado = "GeV²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m (GeV/c²)", Simbolo = "m", Unidade = "GeV/c²", ValorPadrao = 173 }
                    },
                    Calcular = inputs =>
                    {
                        double m = inputs["m (GeV/c²)"];
                        double s_threshold = 4 * m * m;
                        return s_threshold;
                    },
                    Icone = "⚛️"
                },

                // V10-160: Integração Funcional
                new Formula
                {
                    Id = "3748",
                    CodigoCompendio = "V10-160",
                    Nome = "Path Integral de Feynman",
                    Categoria = "Mecânica Quântica de Campos",
                    SubCategoria = "Formulação Path Integral",
                    Expressao = @"Z = ∫𝒟φ·exp(iS[φ]/ℏ); S = ∫ℒ·d⁴x",
                    Descricao = "Função partição: soma sobre todas configurações campo. S: ação. Instântons, tunneling quântico. Lattice: Wick rotation (Euclidean path integral).",
                    ExemploPratico = "QCD lattice: calcula espectro hadrons a partir primeiros princípios. Instantons: violação número baryon (sphaleron). 't Hooft: soluções clássicas Euclidean.",
                    Criador = "Feynman (1948, QM path integral); generalizado QFT (anos 1950s-1960s)",
                    AnoOrigin = "1948",
                    VariavelResultado = "S_ação",
                    UnidadeResultado = "ℏ",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ℒ (GeV⁴)", Simbolo = "L", Unidade = "GeV⁴", ValorPadrao = 1 },
                        new Variavel { Nome = "Volume (fm⁴)", Simbolo = "V", Unidade = "fm⁴", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double L_GeV4 = inputs["ℒ (GeV⁴)"];
                        double V_fm4 = inputs["Volume (fm⁴)"];
                        
                        // Convert volume to GeV^-4 (1 fm = 5.068 GeV^-1)
                        double V_GeV4_inv = V_fm4 * Math.Pow(5.068, 4);
                        
                        double S_GeV = L_GeV4 * V_GeV4_inv; // action in GeV (natural units ℏ=1)
                        
                        return S_GeV;
                    },
                    Icone = "⚛️"
                }
            });
        }
    }
}
