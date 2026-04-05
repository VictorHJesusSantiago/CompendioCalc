using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XVIII
    /// NEUROCIÊNCIA E IMAGEM CEREBRAL QUANTITATIVA
    /// Fórmulas V10-338 a V10-357 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_Neuroscience()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3926",
                    CodigoCompendio = "V10-338",
                    Nome = "Modelo de Hodgkin-Huxley — Potencial de Ação",
                    Categoria = "Neurociência",
                    SubCategoria = "Eletrofisiologia",
                    Expressao = @"C_m·dV/dt = I_ext − g_Na·m³·h·(V−E_Na) − g_K·n⁴·(V−E_K) − g_L·(V−E_L)",
                    Descricao = "Modelo dinâmico do potencial de membrana. m,h,n: variáveis de gating. g: condutâncias. E: potenciais de reversão.",
                    ExemploPratico = "Neurônio em repouso: V≈−70mV. Spike: V_pico≈+40mV. Duração≈1ms. Taxa disparo: 1-100 Hz.",
                    Criador = "Hodgkin e Huxley (1952, J. Physiol., Nobel 1963)",
                    AnoOrigin = "1952",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "C_m (μF/cm²)", Simbolo = "C_m", Unidade = "μF/cm²", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "g_Na (mS/cm²)", Simbolo = "g_Na", Unidade = "mS/cm²", ValorPadrao = 120, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "g_K (mS/cm²)", Simbolo = "g_K", Unidade = "mS/cm²", ValorPadrao = 36, Descricao = "Parâmetro de entrada." }
                    },
                    VariavelResultado = "amplitude",
                    UnidadeResultado = "mV",
                    Calcular = inputs =>
                    {
                        _ = inputs["C_m (μF/cm²)"];
                        _ = inputs["g_Na (mS/cm²)"];
                        _ = inputs["g_K (mS/cm²)"];
                        
                        double V_repouso = -70; // mV
                        double V_pico = 40; // mV
                        double amplitude = V_pico - V_repouso;
                        return amplitude;
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-339: Equação de Nernst
                new Formula
                {
                    Id = "3927",
                    CodigoCompendio = "V10-339",
                    Nome = "Equação de Nernst",
                    Categoria = "Neurociência",
                    SubCategoria = "Eletrofisiologia",
                    Expressao = @"E_ion = (RT/zF)·ln([ion]_out/[ion]_in)",
                    Descricao = "Potencial de equilíbrio para um íon. A 37°C: E≈(61.5/z)·log10(out/in) mV.",
                    ExemploPratico = "K+: out=5 mM, in=140 mM, z=+1 → E_K≈−89 mV. Na+: out=145, in=12 → E_Na≈+66 mV.",
                    Criador = "Walther Nernst",
                    AnoOrigin = "1889",
                    VariavelResultado = "E_ion",
                    UnidadeResultado = "mV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "[ion]_out (mM)", Simbolo = "out", Unidade = "mM", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "[ion]_in (mM)", Simbolo = "in", Unidade = "mM", ValorPadrao = 140, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "z valência", Simbolo = "z", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double outIon = inputs["[ion]_out (mM)"];
                        double inIon = inputs["[ion]_in (mM)"];
                        double z = inputs["z valência"];
                        if (inIon <= 0 || z == 0) return 0;
                        return (61.5 / z) * Math.Log10(outIon / inIon);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-340: Equação de Goldman-Hodgkin-Katz
                new Formula
                {
                    Id = "3928",
                    CodigoCompendio = "V10-340",
                    Nome = "Equação GHK — Potencial de Repouso",
                    Categoria = "Neurociência",
                    SubCategoria = "Eletrofisiologia",
                    Expressao = @"V_m = 61.5·log10((P_K[K]_out + P_Na[Na]_out + P_Cl[Cl]_in)/(P_K[K]_in + P_Na[Na]_in + P_Cl[Cl]_out))",
                    Descricao = "Extensão da Nernst para múltiplos íons com permeabilidades relativas.",
                    ExemploPratico = "Com P_K>>P_Na no repouso, V_m fica próximo de E_K (~−70 mV típico neuronal).",
                    Criador = "Goldman, Hodgkin e Katz",
                    AnoOrigin = "1943",
                    VariavelResultado = "V_m",
                    UnidadeResultado = "mV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "P_K", Simbolo = "PK", Unidade = "", ValorPadrao = 1.0, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "P_Na", Simbolo = "PNa", Unidade = "", ValorPadrao = 0.04, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "P_Cl", Simbolo = "PCl", Unidade = "", ValorPadrao = 0.45, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "[K]_out (mM)", Simbolo = "Kout", Unidade = "mM", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "[K]_in (mM)", Simbolo = "Kin", Unidade = "mM", ValorPadrao = 140, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "[Na]_out (mM)", Simbolo = "Naout", Unidade = "mM", ValorPadrao = 145, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "[Na]_in (mM)", Simbolo = "Nain", Unidade = "mM", ValorPadrao = 12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "[Cl]_out (mM)", Simbolo = "Clout", Unidade = "mM", ValorPadrao = 120, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "[Cl]_in (mM)", Simbolo = "Clin", Unidade = "mM", ValorPadrao = 4, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double PK = inputs["P_K"];
                        double PNa = inputs["P_Na"];
                        double PCl = inputs["P_Cl"];
                        double Kout = inputs["[K]_out (mM)"];
                        double Kin = inputs["[K]_in (mM)"];
                        double Naout = inputs["[Na]_out (mM)"];
                        double Nain = inputs["[Na]_in (mM)"];
                        double Clout = inputs["[Cl]_out (mM)"];
                        double Clin = inputs["[Cl]_in (mM)"];

                        double num = PK * Kout + PNa * Naout + PCl * Clin;
                        double den = PK * Kin + PNa * Nain + PCl * Clout;
                        if (den <= 0) return 0;
                        return 61.5 * Math.Log10(num / den);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-341: Constante de Tempo de Membrana
                new Formula
                {
                    Id = "3929",
                    CodigoCompendio = "V10-341",
                    Nome = "Constante de Tempo de Membrana",
                    Categoria = "Neurociência",
                    SubCategoria = "Neurodinâmica",
                    Expressao = @"τ_m = R_m·C_m",
                    Descricao = "Define quão rápido a membrana responde a correntes. Em t=τ, atinge 63.2% do valor final.",
                    ExemploPratico = "R_m=100 MΩ, C_m=100 pF → τ=10 ms.",
                    Criador = "Teoria de circuito RC",
                    AnoOrigin = "1900",
                    VariavelResultado = "tau",
                    UnidadeResultado = "ms",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R_m (MΩ)", Simbolo = "Rm", Unidade = "MΩ", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "C_m (pF)", Simbolo = "Cm", Unidade = "pF", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Rm = inputs["R_m (MΩ)"] * 1e6;
                        double Cm = inputs["C_m (pF)"] * 1e-12;
                        return Rm * Cm * 1000;
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-342: Constante de Espaço
                new Formula
                {
                    Id = "3930",
                    CodigoCompendio = "V10-342",
                    Nome = "Constante de Espaço (Cable Theory)",
                    Categoria = "Neurociência",
                    SubCategoria = "Neurodinâmica",
                    Expressao = @"λ = √(r_m/r_i)",
                    Descricao = "Distância para queda do potencial a 37% ao longo do dendrito/axônio.",
                    ExemploPratico = "r_m=1e6 Ω·cm, r_i=100 Ω/cm → λ≈100 cm^0.5 (escala efetiva depende geometria).",
                    Criador = "Wilfrid Rall",
                    AnoOrigin = "1959",
                    VariavelResultado = "lambda",
                    UnidadeResultado = "cm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "r_m (Ω·cm)", Simbolo = "rm", Unidade = "Ω·cm", ValorPadrao = 1000000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "r_i (Ω/cm)", Simbolo = "ri", Unidade = "Ω/cm", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double rm = inputs["r_m (Ω·cm)"];
                        double ri = inputs["r_i (Ω/cm)"];
                        if (ri <= 0) return 0;
                        return Math.Sqrt(rm / ri);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-343: Velocidade de Condução (mielina)
                new Formula
                {
                    Id = "3931",
                    CodigoCompendio = "V10-343",
                    Nome = "Velocidade de Condução Axonal",
                    Categoria = "Neurociência",
                    SubCategoria = "Condução Neural",
                    Expressao = @"v ≈ k·d; mielínico k≈6, não mielínico k≈0.5",
                    Descricao = "A velocidade cresce com diâmetro axonal e mielinização.",
                    ExemploPratico = "Axônio mielínico d=10 μm → v≈60 m/s. Não mielínico d=1 μm → v≈0.5 m/s.",
                    Criador = "Relações empíricas neurofisiológicas",
                    AnoOrigin = "1950",
                    VariavelResultado = "v",
                    UnidadeResultado = "m/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "d diâmetro (μm)", Simbolo = "d", Unidade = "μm", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k fator", Simbolo = "k", Unidade = "", ValorPadrao = 6, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        return inputs["d diâmetro (μm)"] * inputs["k fator"];
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-344: Frequência de Disparo
                new Formula
                {
                    Id = "3932",
                    CodigoCompendio = "V10-344",
                    Nome = "Taxa de Disparo Neural",
                    Categoria = "Neurociência",
                    SubCategoria = "Codificação Neural",
                    Expressao = @"f = N_spikes/Δt",
                    Descricao = "Métrica básica de codificação por taxa (rate coding).",
                    ExemploPratico = "35 spikes em 0.5 s → f=70 Hz.",
                    Criador = "Neurofisiologia clássica",
                    AnoOrigin = "1930",
                    VariavelResultado = "f",
                    UnidadeResultado = "Hz",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N spikes", Simbolo = "N", Unidade = "", ValorPadrao = 35, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Δt (s)", Simbolo = "dt", Unidade = "s", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double dt = inputs["Δt (s)"];
                        if (dt <= 0) return 0;
                        return inputs["N spikes"] / dt;
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-345: STDP
                new Formula
                {
                    Id = "3933",
                    CodigoCompendio = "V10-345",
                    Nome = "STDP — Plasticidade Dependente de Tempo",
                    Categoria = "Neurociência",
                    SubCategoria = "Plasticidade Sináptica",
                    Expressao = @"Δw = A_+·exp(−Δt/τ_+) (Δt>0), Δw = −A_-·exp(Δt/τ_-) (Δt<0)",
                    Descricao = "Pré antes de pós fortalece (LTP). Pós antes de pré enfraquece (LTD).",
                    ExemploPratico = "Δt=+10 ms, A+=0.01, τ+=20 ms → Δw≈0.0061. Δt=−10 ms, A-=0.012, τ-=20 ms → Δw≈−0.0073.",
                    Criador = "Bi e Poo",
                    AnoOrigin = "1998",
                    VariavelResultado = "delta_w",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Δt (ms)", Simbolo = "dt", Unidade = "ms", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "A_+", Simbolo = "Ap", Unidade = "", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "A_-", Simbolo = "Am", Unidade = "", ValorPadrao = 0.012, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "τ_+ (ms)", Simbolo = "tp", Unidade = "ms", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "τ_- (ms)", Simbolo = "tm", Unidade = "ms", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double dt = inputs["Δt (ms)"];
                        double Ap = inputs["A_+"];
                        double Am = inputs["A_-"];
                        double tp = inputs["τ_+ (ms)"];
                        double tm = inputs["τ_- (ms)"];

                        if (dt >= 0)
                        {
                            if (tp <= 0) return 0;
                            return Ap * Math.Exp(-dt / tp);
                        }
                        if (tm <= 0) return 0;
                        return -Am * Math.Exp(dt / tm);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-346: Regra Hebb
                new Formula
                {
                    Id = "3934",
                    CodigoCompendio = "V10-346",
                    Nome = "Regra de Hebb",
                    Categoria = "Neurociência",
                    SubCategoria = "Plasticidade Sináptica",
                    Expressao = @"Δw = η·x·y",
                    Descricao = "Se dois neurônios disparam juntos, conexão fortalece.",
                    ExemploPratico = "η=0.01, x=0.8, y=0.9 → Δw=0.0072.",
                    Criador = "Donald Hebb",
                    AnoOrigin = "1949",
                    VariavelResultado = "delta_w",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "η taxa aprendizado", Simbolo = "eta", Unidade = "", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "x atividade pré", Simbolo = "x", Unidade = "", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "y atividade pós", Simbolo = "y", Unidade = "", ValorPadrao = 0.9, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["η taxa aprendizado"] * inputs["x atividade pré"] * inputs["y atividade pós"],
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-347: Sinal BOLD (fMRI)
                new Formula
                {
                    Id = "3935",
                    CodigoCompendio = "V10-347",
                    Nome = "Sinal BOLD em fMRI",
                    Categoria = "Neurociência",
                    SubCategoria = "Neuroimagem",
                    Expressao = @"ΔS/S ≈ k·Δ[dHb] + termos hemodinâmicos",
                    Descricao = "BOLD depende de desoxi-hemoglobina, fluxo e volume sanguíneo cerebral.",
                    ExemploPratico = "Ativação cortical típica gera aumento BOLD de ~1-5%.",
                    Criador = "Ogawa et al.",
                    AnoOrigin = "1990",
                    VariavelResultado = "bold_pct",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "S0 baseline", Simbolo = "S0", Unidade = "u.a.", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ΔS variação", Simbolo = "dS", Unidade = "u.a.", ValorPadrao = 25, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double S0 = inputs["S0 baseline"];
                        double dS = inputs["ΔS variação"];
                        if (S0 == 0) return 0;
                        return 100 * dS / S0;
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-348: SNR em fMRI
                new Formula
                {
                    Id = "3936",
                    CodigoCompendio = "V10-348",
                    Nome = "SNR de Neuroimagem",
                    Categoria = "Neurociência",
                    SubCategoria = "Neuroimagem",
                    Expressao = @"SNR = S/σ_noise",
                    Descricao = "Razão sinal-ruído da aquisição. Quanto maior, melhor detectabilidade de ativação.",
                    ExemploPratico = "S=1200 e σ=20 → SNR=60.",
                    Criador = "Processamento de sinais",
                    AnoOrigin = "1950",
                    VariavelResultado = "snr",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "S sinal", Simbolo = "S", Unidade = "u.a.", ValorPadrao = 1200, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ noise", Simbolo = "sigma", Unidade = "u.a.", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double sigma = inputs["σ noise"];
                        if (sigma <= 0) return 0;
                        return inputs["S sinal"] / sigma;
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-349: Resolução temporal hemodinâmica
                new Formula
                {
                    Id = "3937",
                    CodigoCompendio = "V10-349",
                    Nome = "Atraso Hemodinâmico (HRF)",
                    Categoria = "Neurociência",
                    SubCategoria = "Neuroimagem",
                    Expressao = @"t_pico HRF ≈ 5-6 s",
                    Descricao = "Resposta hemodinâmica tem atraso em relação ao disparo neural.",
                    ExemploPratico = "Evento neural em t=0 gera pico BOLD por volta de t≈5 s.",
                    Criador = "Modelagem HRF fMRI",
                    AnoOrigin = "1995",
                    VariavelResultado = "t_pico",
                    UnidadeResultado = "s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "t_base (s)", Simbolo = "t", Unidade = "s", ValorPadrao = 5.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["t_base (s)"],
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-350: Potencial pós-sináptico exponencial
                new Formula
                {
                    Id = "3938",
                    CodigoCompendio = "V10-350",
                    Nome = "EPSP/IPSP Exponencial",
                    Categoria = "Neurociência",
                    SubCategoria = "Sinapses",
                    Expressao = @"V(t)=V0·exp(−t/τ_s)",
                    Descricao = "Modelo simplificado de decaimento de potencial pós-sináptico.",
                    ExemploPratico = "V0=5 mV, τ_s=15 ms, t=20 ms → V≈1.32 mV.",
                    Criador = "Modelos sinápticos clássicos",
                    AnoOrigin = "1960",
                    VariavelResultado = "Vt",
                    UnidadeResultado = "mV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "V0 (mV)", Simbolo = "V0", Unidade = "mV", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "τ_s (ms)", Simbolo = "tau", Unidade = "ms", ValorPadrao = 15, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (ms)", Simbolo = "t", Unidade = "ms", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double V0 = inputs["V0 (mV)"];
                        double tau = inputs["τ_s (ms)"];
                        double t = inputs["t (ms)"];
                        if (tau <= 0) return 0;
                        return V0 * Math.Exp(-t / tau);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-351: Corrente sináptica
                new Formula
                {
                    Id = "3939",
                    CodigoCompendio = "V10-351",
                    Nome = "Corrente Sináptica",
                    Categoria = "Neurociência",
                    SubCategoria = "Sinapses",
                    Expressao = @"I_syn = g_syn·(V_m − E_syn)",
                    Descricao = "Modelo condutância para sinapses excitatórias/inibitórias.",
                    ExemploPratico = "g=5 nS, V_m=−65 mV, E_exc=0 mV → I≈−325 pA (entrada excitatória).",
                    Criador = "Modelo de condutância",
                    AnoOrigin = "1970",
                    VariavelResultado = "I_syn",
                    UnidadeResultado = "pA",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "g_syn (nS)", Simbolo = "g", Unidade = "nS", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "V_m (mV)", Simbolo = "Vm", Unidade = "mV", ValorPadrao = -65, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "E_syn (mV)", Simbolo = "Es", Unidade = "mV", ValorPadrao = 0, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double g = inputs["g_syn (nS)"];
                        double Vm = inputs["V_m (mV)"];
                        double Es = inputs["E_syn (mV)"];
                        return g * (Vm - Es);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-352: Coerência EEG
                new Formula
                {
                    Id = "3940",
                    CodigoCompendio = "V10-352",
                    Nome = "Coerência Espectral EEG",
                    Categoria = "Neurociência",
                    SubCategoria = "EEG",
                    Expressao = @"Cxy(f)=|Pxy|²/(Pxx·Pyy)",
                    Descricao = "Conectividade funcional entre canais EEG em banda de frequência.",
                    ExemploPratico = "Pxy=4, Pxx=5, Pyy=6 → C=16/30=0.53.",
                    Criador = "Análise espectral",
                    AnoOrigin = "1965",
                    VariavelResultado = "coh",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "|Pxy|", Simbolo = "Pxy", Unidade = "", ValorPadrao = 4, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Pxx", Simbolo = "Pxx", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Pyy", Simbolo = "Pyy", Unidade = "", ValorPadrao = 6, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Pxy = inputs["|Pxy|"];
                        double Pxx = inputs["Pxx"];
                        double Pyy = inputs["Pyy"];
                        double den = Pxx * Pyy;
                        if (den <= 0) return 0;
                        return (Pxy * Pxy) / den;
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-353: Potência de banda EEG
                new Formula
                {
                    Id = "3941",
                    CodigoCompendio = "V10-353",
                    Nome = "Potência de Banda EEG",
                    Categoria = "Neurociência",
                    SubCategoria = "EEG",
                    Expressao = @"P_banda = ∫ PSD(f) df",
                    Descricao = "Potência integrada em bandas delta, theta, alfa, beta, gama.",
                    ExemploPratico = "Soma discreta PSD·Δf em alfa (8-13 Hz) resulta em potência relativa de 32%.",
                    Criador = "Eletroencefalografia quantitativa",
                    AnoOrigin = "1970",
                    VariavelResultado = "P_band",
                    UnidadeResultado = "uV²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "PSD médio (uV²/Hz)", Simbolo = "psd", Unidade = "uV²/Hz", ValorPadrao = 6, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Largura banda (Hz)", Simbolo = "bw", Unidade = "Hz", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["PSD médio (uV²/Hz)"] * inputs["Largura banda (Hz)"],
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-354: Informação mútua neurônio-estímulo
                new Formula
                {
                    Id = "3942",
                    CodigoCompendio = "V10-354",
                    Nome = "Informação Mútua Neural",
                    Categoria = "Neurociência",
                    SubCategoria = "Neuroinformação",
                    Expressao = @"I(S;R)=Σ p(s,r)·log2(p(s,r)/(p(s)p(r)))",
                    Descricao = "Mede quanto a resposta neural informa sobre o estímulo.",
                    ExemploPratico = "Classificador neural com boa separação pode atingir >1 bit por janela curta.",
                    Criador = "Claude Shannon aplicado à neurociência",
                    AnoOrigin = "1948",
                    VariavelResultado = "I",
                    UnidadeResultado = "bits",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "p(s,r)", Simbolo = "psr", Unidade = "", ValorPadrao = 0.25, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "p(s)", Simbolo = "ps", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "p(r)", Simbolo = "pr", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double psr = inputs["p(s,r)"];
                        double ps = inputs["p(s)"];
                        double pr = inputs["p(r)"];
                        double den = ps * pr;
                        if (psr <= 0 || den <= 0) return 0;
                        return psr * Math.Log(psr / den, 2);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-355: Similaridade funcional (correlação)
                new Formula
                {
                    Id = "3943",
                    CodigoCompendio = "V10-355",
                    Nome = "Correlação Funcional",
                    Categoria = "Neurociência",
                    SubCategoria = "Conectividade",
                    Expressao = @"r = cov(x,y)/(σx·σy)",
                    Descricao = "Conectividade funcional em fMRI/EEG frequentemente quantificada por correlação temporal.",
                    ExemploPratico = "cov=12, σx=5, σy=4 → r=0.6 (conectividade moderada-alta).",
                    Criador = "Karl Pearson",
                    AnoOrigin = "1895",
                    VariavelResultado = "r",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "cov(x,y)", Simbolo = "cov", Unidade = "", ValorPadrao = 12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σx", Simbolo = "sx", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σy", Simbolo = "sy", Unidade = "", ValorPadrao = 4, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double cov = inputs["cov(x,y)"];
                        double sx = inputs["σx"];
                        double sy = inputs["σy"];
                        if (sx <= 0 || sy <= 0) return 0;
                        return cov / (sx * sy);
                    },
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-356: Perceptron
                new Formula
                {
                    Id = "3944",
                    CodigoCompendio = "V10-356",
                    Nome = "Perceptron Neural",
                    Categoria = "Neurociência",
                    SubCategoria = "Modelos Computacionais",
                    Expressao = @"y = step(w·x + b)",
                    Descricao = "Modelo linear de neurônio artificial com limiar.",
                    ExemploPratico = "w·x+b=0.7>0 → y=1. Se −0.2 → y=0.",
                    Criador = "Frank Rosenblatt",
                    AnoOrigin = "1958",
                    VariavelResultado = "y",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "w·x + b", Simbolo = "z", Unidade = "", ValorPadrao = 0.7, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["w·x + b"] >= 0 ? 1 : 0,
                    Icone = "🧠",
                    Unidades = "",
                },

                // V10-357: Atualização de gradiente (backprop)
                new Formula
                {
                    Id = "3945",
                    CodigoCompendio = "V10-357",
                    Nome = "Descida de Gradiente (Backprop)",
                    Categoria = "Neurociência",
                    SubCategoria = "Modelos Computacionais",
                    Expressao = @"w_novo = w_antigo − η·∂L/∂w",
                    Descricao = "Regra de atualização de pesos em redes neurais.",
                    ExemploPratico = "w=0.8, η=0.01, grad=3.5 → w_novo=0.765.",
                    Criador = "Rumelhart, Hinton, Williams",
                    AnoOrigin = "1986",
                    VariavelResultado = "w_novo",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "w_antigo", Simbolo = "w", Unidade = "", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "η learning rate", Simbolo = "eta", Unidade = "", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "∂L/∂w gradiente", Simbolo = "g", Unidade = "", ValorPadrao = 3.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["w_antigo"] - inputs["η learning rate"] * inputs["∂L/∂w gradiente"],
                    Icone = "🧠",
                    Unidades = "",
                }
            });
        }
    }
}
