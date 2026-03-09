using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE VI
    /// BIOLOGIA DE SISTEMAS E REDES REGULATÓRIAS
    /// Fórmulas V10-102 a V10-121 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_SystemsBiology()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3690",
                    CodigoCompendio = "V10-102",
                    Nome = "Equação de Hill — Cooperatividade",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Regulação Gênica",
                    Expressao = @"θ = [L]^n/(K_d^n + [L]^n)",
                    Descricao = "Fração de sítios ocupados. n: coeficiente Hill (cooperatividade). K_d: constante dissociação.",
                    ExemploPratico = "Hemoglobina O₂: n≈2.8. Repressor lac: n~2. Cascata sinalização: n~5-10.",
                    Criador = "Hill (1910, J. Physiol.)",
                    AnoOrigin = "1910",
                    VariavelResultado = "θ",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Concentração [L]", Simbolo = "[L]", Unidade = "M", ValorPadrao = 0.001 },
                        new Variavel { Nome = "K_d", Simbolo = "K_d", Unidade = "M", ValorPadrao = 0.001 },
                        new Variavel { Nome = "Coef Hill n", Simbolo = "n", Unidade = "", ValorPadrao = 2.8 }
                    },
                    Calcular = inputs =>
                    {
                        double L = inputs["Concentração [L]"];
                        double Kd = inputs["K_d"];
                        double n = inputs["Coef Hill n"];
                        double theta = Math.Pow(L, n) / (Math.Pow(Kd, n) + Math.Pow(L, n));
                        return theta;
                    },
                    Icone = "🧬"
                },

                // V10-103: Michaelis-Menten
                new Formula
                {
                    Id = "3691",
                    CodigoCompendio = "V10-103",
                    Nome = "Cinética de Michaelis-Menten",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Cinética Enzimática",
                    Expressao = @"v = V_max·[S]/(K_m + [S])",
                    Descricao = "Velocidade reação enzimática. V_max: velocidade máxima. K_m: constante Michaelis (afinidade substrato). [S]=K_m: v=V_max/2.",
                    ExemploPratico = "Hexokinase: K_m(glucose)≈0.1mM. Álcool desidrogenase: K_m(ethanol)≈1mM. Catalase: k_cat≈10^7 s^-1 (uma das mais rápidas).",
                    Criador = "Michaelis e Menten (1913, Biochem. Z.)",
                    AnoOrigin = "1913",
                    VariavelResultado = "v",
                    UnidadeResultado = "μM/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "[S] (mM)", Simbolo = "S", Unidade = "mM", ValorPadrao = 0.5 },
                        new Variavel { Nome = "V_max (μM/s)", Simbolo = "Vmax", Unidade = "μM/s", ValorPadrao = 100 },
                        new Variavel { Nome = "K_m (mM)", Simbolo = "Km", Unidade = "mM", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double S = inputs["[S] (mM)"];
                        double Vmax = inputs["V_max (μM/s)"];
                        double Km = inputs["K_m (mM)"];
                        
                        double v = (Vmax * S) / (Km + S);
                        return v;
                    },
                    Icone = "🧬"
                },

                // V10-104: Modelo Logístico — Crescimento Populacional
                new Formula
                {
                    Id = "3692",
                    CodigoCompendio = "V10-104",
                    Nome = "Modelo Logístico — Crescimento Celular",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Dinâmica Populacional",
                    Expressao = @"dN/dt = r·N·(1 − N/K)",
                    Descricao = "Crescimento populacional com capacidade suporte K. r: taxa crescimento. Solução: N(t)=K/(1+Ae^(-rt)). Saturação em t→∞: N→K.",
                    ExemploPratico = "E. coli: r≈1 h^-1 (dobra 42min), K≈10^9 cells/mL. Tumor: r≈0.01 dia^-1, K limitado por nutrição difusão. Fase estacionária: dN/dt→0.",
                    Criador = "Verhulst (1838); reintroduzido por Pearl-Reed (1920, biólogos)",
                    AnoOrigin = "1838",
                    VariavelResultado = "N_t",
                    UnidadeResultado = "células",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N₀ (células)", Simbolo = "N0", Unidade = "células", ValorPadrao = 1e6 },
                        new Variavel { Nome = "r (1/h)", Simbolo = "r", Unidade = "1/h", ValorPadrao = 0.5 },
                        new Variavel { Nome = "K (capacidade)", Simbolo = "K", Unidade = "células", ValorPadrao = 1e9 },
                        new Variavel { Nome = "Tempo t (h)", Simbolo = "t", Unidade = "h", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double N0 = inputs["N₀ (células)"];
                        double r = inputs["r (1/h)"];
                        double K = inputs["K (capacidade)"];
                        double t = inputs["Tempo t (h)"];
                        
                        double A = (K - N0) / N0;
                        double N_t = K / (1 + A * Math.Exp(-r * t));
                        
                        return N_t;
                    },
                    Icone = "🧬"
                },

                // V10-105: Taxa de Mutação
                new Formula
                {
                    Id = "3693",
                    CodigoCompendio = "V10-105",
                    Nome = "Taxa de Mutação por Geração",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Genética Evolutiva",
                    Expressao = @"μ = mutações/(base·geração)",
                    Descricao = "Frequência de mutações. μ humano≈10^-8/bp/geração. μ vírus RNA≈10^-4/bp/replicação (sem correção). E. coli: μ≈10^-9/bp/divisão.",
                    ExemploPratico = "Genoma humano 3×10^9 bp: ~30 mutações de novo/pessoa. HIV: μ~10^-4→alta variabilidade (escape imune). DNA polimerase fidelidade: ε≈10^-6 (com proofreading).",
                    Criador = "Luria-Delbrück (1943, flutuação test, Nobel 1969)",
                    AnoOrigin = "1943",
                    VariavelResultado = "mutações_totais",
                    UnidadeResultado = "mutações",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tamanho genoma (bp)", Simbolo = "L", Unidade = "bp", ValorPadrao = 3e9 },
                        new Variavel { Nome = "μ (/bp/geração)", Simbolo = "mu", Unidade = "", ValorPadrao = 1e-8 },
                        new Variavel { Nome = "Gerações", Simbolo = "n_gen", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double L = inputs["Tamanho genoma (bp)"];
                        double mu = inputs["μ (/bp/geração)"];
                        double n_gen = inputs["Gerações"];
                        
                        double mutacoes = L * mu * n_gen;
                        return mutacoes;
                    },
                    Icone = "🧬"
                },

                // V10-106: Seleção Natural (Fitness)
                new Formula
                {
                    Id = "3694",
                    CodigoCompendio = "V10-106",
                    Nome = "Coeficiente de Seleção s",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Evolução",
                    Expressao = @"s = 1 − w_mutante/w_WT",
                    Descricao = "s: coeficiente seleção. w: fitness relativo. s>0: deletéria. s<0: benéfica. s≈0: neutra. Fixação probability∝s (se s≠0).",
                    ExemploPratico = "Anemia falciforme: heterozigotos s≈−0.1 (vantagem malária). Letal: s=1. Quase-neutra: |s|<1/(2N_e) (drift domina). Resistência antibiótico: s~−0.5 (forte seleção).",
                    Criador = "Fisher (1930, Genetical Theory); Haldane (1927, seleção matemática)",
                    AnoOrigin = "1927",
                    VariavelResultado = "s",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Fitness mutante w_mut", Simbolo = "w_mut", Unidade = "", ValorPadrao = 0.9 },
                        new Variavel { Nome = "Fitness WT w_WT", Simbolo = "w_WT", Unidade = "", ValorPadrao = 1.0 }
                    },
                    Calcular = inputs =>
                    {
                        double w_mut = inputs["Fitness mutante w_mut"];
                        double w_WT = inputs["Fitness WT w_WT"];
                        
                        if (w_WT == 0) return 0;
                        double s = 1 - (w_mut / w_WT);
                        return s;
                    },
                    Icone = "🧬"
                },

                // V10-107: Rede Metabólica — Flux Balance Analysis (FBA)
                new Formula
                {
                    Id = "3695",
                    CodigoCompendio = "V10-107",
                    Nome = "Flux Balance Analysis (FBA)",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Metabolismo",
                    Expressao = @"max Z; S·v = 0; v_min ≤ v ≤ v_max",
                    Descricao = "Otimização fluxos metabólicos. S: matriz estoichiométrica. v: vetor fluxos. Z: objetivo (ex. biomassa). Estado estacionário: S·v=0.",
                    ExemploPratico = "E. coli: ~2000 reações, ~1000 metabólitos. FBA prediz crescimento vs glicose uptake. iJO1366: modelo genoma-escala. Objective: max biomass flux μ.",
                    Criador = "Varma-Palsson (1994, Bio/Technology); COBRA toolbox (2007)",
                    AnoOrigin = "1994",
                    VariavelResultado = "μ",
                    UnidadeResultado = "1/h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Glicose uptake (mmol/gDW/h)", Simbolo = "v_glc", Unidade = "mmol/gDW/h", ValorPadrao = 10 },
                        new Variavel { Nome = "Eficiência conversão", Simbolo = "Y", Unidade = "", ValorPadrao = 0.5 }
                    },
                    Calcular = inputs =>
                    {
                        double v_glc = inputs["Glicose uptake (mmol/gDW/h)"];
                        double Y = inputs["Eficiência conversão"];
                        
                        // Aproximação: μ ∝ v_glc × Y
                        double mu = v_glc * Y * 0.1; // growth rate
                        return mu;
                    },
                    Icone = "🧬"
                },

                // V10-108: Oscilador Repressilator
                new Formula
                {
                    Id = "3696",
                    CodigoCompendio = "V10-108",
                    Nome = "Oscilador Repressilator",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Circuitos Genéticos Sintéticos",
                    Expressao = @"dX_i/dt = α/(1 + X_{i-1}^n) − X_i",
                    Descricao = "Oscilador sintético (3 repressores em anel). Elowitz-Leibler (2000, Nature). Oscilação: n>2 (cooperatividade), α alto. Período T∝log(α).",
                    ExemploPratico = "E. coli: T≈150min (GFP pulsa). Parâmetros: α≈1000, n≈2.5. Biologia sintética: primeiro oscilador racional design. Amplitude flutuações: ruído intrínseco.",
                    Criador = "Elowitz e Leibler (2000, Nature); biologia sintética",
                    AnoOrigin = "2000",
                    VariavelResultado = "X",
                    UnidadeResultado = "nM",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "α (prod rate)", Simbolo = "alpha", Unidade = "nM/min", ValorPadrao = 1000 },
                        new Variavel { Nome = "X_{i-1} (nM)", Simbolo = "X_prev", Unidade = "nM", ValorPadrao = 100 },
                        new Variavel { Nome = "Coef Hill n", Simbolo = "n", Unidade = "", ValorPadrao = 2.5 }
                    },
                    Calcular = inputs =>
                    {
                        double alpha = inputs["α (prod rate)"];
                        double X_prev = inputs["X_{i-1} (nM)"];
                        double n = inputs["Coef Hill n"];
                        
                        double production = alpha / (1 + Math.Pow(X_prev, n));
                        // Steady state aproximado (ignoring degradation for snapshot)
                        double X = production;
                        
                        return X;
                    },
                    Icone = "🧬"
                },

                // V10-109: Taxa de Transcrição — Modelo RNAP
                new Formula
                {
                    Id = "3697",
                    CodigoCompendio = "V10-109",
                    Nome = "Taxa de Transcrição",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Expressão Gênica",
                    Expressao = @"r_tx = k_on·[RNAP]·P_promoter",
                    Descricao = "Taxa iniciação transcrição. k_on: constante ligação RNAP. P_promoter: força do promotor (0-1). [RNAP]: RNA polimerase livre.",
                    ExemploPratico = "E. coli: ~2000 RNAP/célula. Promotor forte (T7): r_tx≈1-5 mRNA/min. Promotor fraco: r_tx≈0.01/min. Velocidade elongação: ~40 nt/s.",
                    Criador = "McClure (1985, Annual Review Biochem); modelos cinéticos anos 1980s",
                    AnoOrigin = "1985",
                    VariavelResultado = "r_tx",
                    UnidadeResultado = "mRNA/min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "[RNAP] (nM)", Simbolo = "RNAP", Unidade = "nM", ValorPadrao = 100 },
                        new Variavel { Nome = "k_on (1/nM/min)", Simbolo = "k_on", Unidade = "1/nM/min", ValorPadrao = 0.01 },
                        new Variavel { Nome = "P_promoter", Simbolo = "P", Unidade = "", ValorPadrao = 0.8 }
                    },
                    Calcular = inputs =>
                    {
                        double RNAP = inputs["[RNAP] (nM)"];
                        double k_on = inputs["k_on (1/nM/min)"];
                        double P = inputs["P_promoter"];
                        
                        double r_tx = k_on * RNAP * P;
                        return r_tx;
                    },
                    Icone = "🧬"
                },

                // V10-110: Tradução — Eficiência Ribossomal
                new Formula
                {
                    Id = "3698",
                    CodigoCompendio = "V10-110",
                    Nome = "Taxa de Tradução",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Síntese Proteica",
                    Expressao = @"r_tl = k_tl·[mRNA]·[Ribosome]_free",
                    Descricao = "Taxa tradução. k_tl: constante iniciação. Velocidade elongação: ~10-20 aa/s (E. coli). RBS strength: modula k_tl (0.0001-1).",
                    ExemploPratico = "E. coli: ~20,000 ribosomes/célula (crescimento rápido). 1 mRNA → ~10-100 proteínas/lifetime. Proteína 300aa: ~15-30s síntese. Polysome: múltiplos ribosomes/mRNA.",
                    Criador = "Schaechter et al. (1958, crescimento bacteriano); modelos quantitativos anos 1970s",
                    AnoOrigin = "1970",
                    VariavelResultado = "r_tl",
                    UnidadeResultado = "proteína/min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "[mRNA] (nM)", Simbolo = "mRNA", Unidade = "nM", ValorPadrao = 10 },
                        new Variavel { Nome = "[Ribosome]_free (nM)", Simbolo = "Ribo", Unidade = "nM", ValorPadrao = 500 },
                        new Variavel { Nome = "k_tl (1/nM/min)", Simbolo = "k_tl", Unidade = "1/nM/min", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double mRNA = inputs["[mRNA] (nM)"];
                        double Ribo = inputs["[Ribosome]_free (nM)"];
                        double k_tl = inputs["k_tl (1/nM/min)"];
                        
                        double r_tl = k_tl * mRNA * Ribo;
                        return r_tl;
                    },
                    Icone = "🧬"
                },

                // V10-111: Degradação de mRNA/Proteína
                new Formula
                {
                    Id = "3699",
                    CodigoCompendio = "V10-111",
                    Nome = "Meia-vida de mRNA/Proteína",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Estabilidade Molecular",
                    Expressao = @"t_{1/2} = ln(2)/k_deg",
                    Descricao = "Tempo para [X] cair 50%. k_deg: constante degradação (1/min). mRNA E. coli: t_{1/2}≈3-8min. Proteínas: t_{1/2}≈20min-horas. Eucariotos: mRNA t_{1/2}≈horas.",
                    ExemploPratico = "mRNA instável (ARE motif): t_{1/2}≈30min. Proteína estável (histonas): t_{1/2}≈dias. Controle dinâmico: degradação rápida permite resposta rápida (transcription factors).",
                    Criador = "Conceito clássico bioquímica (anos 1960s); quantificação por pulse-chase",
                    AnoOrigin = "1960",
                    VariavelResultado = "t_half",
                    UnidadeResultado = "min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k_deg (1/min)", Simbolo = "k_deg", Unidade = "1/min", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double k_deg = inputs["k_deg (1/min)"];
                        if (k_deg == 0) return double.PositiveInfinity;
                        
                        double t_half = Math.Log(2) / k_deg;
                        return t_half;
                    },
                    Icone = "🧬"
                },

                // V10-112: Sinalização — Cascata MAPK
                new Formula
                {
                    Id = "3700",
                    CodigoCompendio = "V10-112",
                    Nome = "Cascata MAPK — Amplificação",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Transdução de Sinal",
                    Expressao = @"Amplificação = ∏(K_i); K_i = [Produto]_i/[Substrato]_i",
                    Descricao = "Cascata fosforilação (MAPKKK→MAPKK→MAPK). Cada nível amplifica sinal. 3 níveis: amplificação ~10³-10⁶. Ultrasensibilidade via cooperatividade.",
                    ExemploPratico = "ERK pathway: Ras→Raf→MEK→ERK. 1 molécula Ras ativa → ~1000 ERK-P. Tempo resposta: ~10min. Hill n≈5 (digital switch). Câncer: mutações Ras→sinal constitutivo.",
                    Criador = "Ferrell (1996, Trends Biochem Sci); Kholodenko (2000, análise teórica)",
                    AnoOrigin = "1996",
                    VariavelResultado = "Amplificação",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K_nível1", Simbolo = "K1", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "K_nível2", Simbolo = "K2", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "K_nível3", Simbolo = "K3", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double K1 = inputs["K_nível1"];
                        double K2 = inputs["K_nível2"];
                        double K3 = inputs["K_nível3"];
                        
                        double amplificacao = K1 * K2 * K3;
                        return amplificacao;
                    },
                    Icone = "🧬"
                },

                // V10-113: Quorum Sensing
                new Formula
                {
                    Id = "3701",
                    CodigoCompendio = "V10-113",
                    Nome = "Quorum Sensing — Autoindutor",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Comunicação Celular",
                    Expressao = @"[AI]_eq = k_prod·N/(k_deg + k_diff)",
                    Descricao = "Comunicação célula-célula via autoindutor (AI). N: densidade celular. k_prod: produção. k_diff: difusão. Threshold: comportamento cooperativo emerge.",
                    ExemploPratico = "V. fischeri: AHL (N-acyl homoserine lactone). N>10^8 cells/mL: bioluminescência ON. P. aeruginosa: virulência regulada por QS. Antibiofilm: inibidores QS.",
                    Criador = "Nealson et al. (1970, V. fischeri); Greenberg (1999, review quorum sensing)",
                    AnoOrigin = "1970",
                    VariavelResultado = "AI_eq",
                    UnidadeResultado = "nM",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Densidade N (cells/mL)", Simbolo = "N", Unidade = "cells/mL", ValorPadrao = 1e8 },
                        new Variavel { Nome = "k_prod (nM/cell)", Simbolo = "k_prod", Unidade = "nM/cell", ValorPadrao = 1e-6 },
                        new Variavel { Nome = "k_deg+k_diff (1/min)", Simbolo = "k_loss", Unidade = "1/min", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["Densidade N (cells/mL)"];
                        double k_prod = inputs["k_prod (nM/cell)"];
                        double k_loss = inputs["k_deg+k_diff (1/min)"];
                        
                        if (k_loss == 0) return 0;
                        double AI_eq = (k_prod * N) / k_loss;
                        return AI_eq;
                    },
                    Icone = "🧬"
                },

                // V10-114: Ciclo Celular — Controle de Cheque Points
                new Formula
                {
                    Id = "3702",
                    CodigoCompendio = "V10-114",
                    Nome = "Ciclo Celular — Tempo de Duplicação",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Proliferação Celular",
                    Expressao = @"T_cycle = T_G1 + T_S + T_G2 + T_M",
                    Descricao = "Fases: G1 (gap1), S (síntese DNA), G2 (gap2), M (mitose). Controle: ciclinas/CDKs. Checkpoints: G1/S, G2/M, spindle. p53: 'guardian of genome' (pausa se dano).",
                    ExemploPratico = "Mamíferos: T≈24h (G1≈11h, S≈8h, G2≈4h, M≈1h). E. coli: T≈20min (crescimento exponencial). Câncer: checkpoints desabilitados (mutações p53, Rb).",
                    Criador = "Howard e Pelc (1951, fases do ciclo); Hartwell (2001, Nobel, checkpoints)",
                    AnoOrigin = "1951",
                    VariavelResultado = "T_cycle",
                    UnidadeResultado = "h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "T_G1 (h)", Simbolo = "T_G1", Unidade = "h", ValorPadrao = 11 },
                        new Variavel { Nome = "T_S (h)", Simbolo = "T_S", Unidade = "h", ValorPadrao = 8 },
                        new Variavel { Nome = "T_G2 (h)", Simbolo = "T_G2", Unidade = "h", ValorPadrao = 4 },
                        new Variavel { Nome = "T_M (h)", Simbolo = "T_M", Unidade = "h", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double T_G1 = inputs["T_G1 (h)"];
                        double T_S = inputs["T_S (h)"];
                        double T_G2 = inputs["T_G2 (h)"];
                        double T_M = inputs["T_M (h)"];
                        
                        double T_cycle = T_G1 + T_S + T_G2 + T_M;
                        return T_cycle;
                    },
                    Icone = "🧬"
                },

                // V10-115: Modelo SIR — Epidemiologia
                new Formula
                {
                    Id = "3703",
                    CodigoCompendio = "V10-115",
                    Nome = "Modelo SIR — Taxa de Infecção",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Epidemiologia",
                    Expressao = @"dI/dt = β·S·I − γ·I",
                    Descricao = "Susceptível (S) → Infeccioso (I) → Recuperado (R). β: taxa transmissão. γ: taxa recuperação. R₀=β/γ: número reprodução básico. R₀>1: epidemia cresce.",
                    ExemploPratico = "Gripe: R₀≈1.3, γ≈0.5/dia (recupera 2 dias). COVID-19: R₀≈3, γ≈0.1/dia. Vacina: reduz S→aumenta threshold R₀·S/N<1. Imunidade rebanho: f>1−1/R₀.",
                    Criador = "Kermack e McKendrick (1927, Proc. R. Soc.)",
                    AnoOrigin = "1927",
                    VariavelResultado = "dI_dt",
                    UnidadeResultado = "pessoas/dia",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "S (susceptíveis)", Simbolo = "S", Unidade = "pessoas", ValorPadrao = 990 },
                        new Variavel { Nome = "I (infectados)", Simbolo = "I", Unidade = "pessoas", ValorPadrao = 10 },
                        new Variavel { Nome = "β (1/pessoa/dia)", Simbolo = "beta", Unidade = "1/pessoa/dia", ValorPadrao = 0.0005 },
                        new Variavel { Nome = "γ (1/dia)", Simbolo = "gamma", Unidade = "1/dia", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double S = inputs["S (susceptíveis)"];
                        double I = inputs["I (infectados)"];
                        double beta = inputs["β (1/pessoa/dia)"];
                        double gamma = inputs["γ (1/dia)"];
                        
                        double dI_dt = beta * S * I - gamma * I;
                        return dI_dt;
                    },
                    Icone = "🧬"
                },

                // V10-116: Diversidade — Índice de Shannon
                new Formula
                {
                    Id = "3704",
                    CodigoCompendio = "V10-116",
                    Nome = "Índice de Diversidade de Shannon",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Ecologia/Microbioma",
                    Expressao = @"H' = −Σ p_i·ln(p_i)",
                    Descricao = "Diversidade de comunidade. p_i: proporção espécie i. H'=0: monocultura. H'=ln(S): uniforme (S espécies). Microbioma intestinal: H'≈3-4.",
                    ExemploPratico = "Intestino saudável: H'≈3.5 (alta diversidade). Após antibióticos: H'≈1.5. 4 espécies iguais (25% cada): H'=ln(4)≈1.39. Doenças: correlação baixa diversidade.",
                    Criador = "Shannon (1948, teoria informação); aplicado ecologia Simpson (1949)",
                    AnoOrigin = "1948",
                    VariavelResultado = "H_prime",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "p₁", Simbolo = "p1", Unidade = "", ValorPadrao = 0.4 },
                        new Variavel { Nome = "p₂", Simbolo = "p2", Unidade = "", ValorPadrao = 0.3 },
                        new Variavel { Nome = "p₃", Simbolo = "p3", Unidade = "", ValorPadrao = 0.2 },
                        new Variavel { Nome = "p₄", Simbolo = "p4", Unidade = "", ValorPadrao = 0.1 }
                    },
                    Calcular = inputs =>
                    {
                        double p1 = inputs["p₁"];
                        double p2 = inputs["p₂"];
                        double p3 = inputs["p₃"];
                        double p4 = inputs["p₄"];
                        
                        double H = 0;
                        if (p1 > 0) H -= p1 * Math.Log(p1);
                        if (p2 > 0) H -= p2 * Math.Log(p2);
                        if (p3 > 0) H -= p3 * Math.Log(p3);
                        if (p4 > 0) H -= p4 * Math.Log(p4);
                        
                        return H;
                    },
                    Icone = "🧬"
                },

                // V10-117: Difusão de Morfógenos
                new Formula
                {
                    Id = "3705",
                    CodigoCompendio = "V10-117",
                    Nome = "Gradiente de Morfógeno — Turing",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Desenvolvimento/Morfogênese",
                    Expressao = @"λ = √(D/k_deg); c(x) = c₀·exp(−x/λ)",
                    Descricao = "Gradiente exponencial. λ: comprimento difusão. D: coeficiente difusão. c₀: concentração fonte. Padrões Turing: ativador-inibidor (D_inh>D_act).",
                    ExemploPratico = "Drosophila Bicoid: λ≈100μm (define eixo antero-posterior). Hydra: λ≈200μm organiza eixo corporal. Reação-difusão: zebra stripes, dedos.",
                    Criador = "Turing (1952, Chemical Basis of Morphogenesis); Wolpert (1969, position information)",
                    AnoOrigin = "1952",
                    VariavelResultado = "λ",
                    UnidadeResultado = "μm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "D (μm²/s)", Simbolo = "D", Unidade = "μm²/s", ValorPadrao = 10 },
                        new Variavel { Nome = "k_deg (1/s)", Simbolo = "k_deg", Unidade = "1/s", ValorPadrao = 0.001 }
                    },
                    Calcular = inputs =>
                    {
                        double D = inputs["D (μm²/s)"];
                        double k_deg = inputs["k_deg (1/s)"];
                        
                        if (k_deg == 0) return double.PositiveInfinity;
                        double lambda = Math.Sqrt(D / k_deg);
                        
                        return lambda;
                    },
                    Icone = "🧬"
                },

                // V10-118: Expressão Gênica — Ruído (Noise)
                new Formula
                {
                    Id = "3706",
                    CodigoCompendio = "V10-118",
                    Nome = "Ruído Intrínseco de Expressão Gênica",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Expressão Gênica Estocástica",
                    Expressao = @"η²_int = 1/⟨n⟩ (Poisson noise)",
                    Descricao = "η²: coeficiente variação ao quadrado (CV²). Intrínseco: flutuações mRNA/proteína. Extrínseco: variação celular. ⟨n⟩: número médio moléculas.",
                    ExemploPratico = "1 mRNA/célula: η²≈1 (CV=100%, altíssimo ruído). 100 proteínas: η²≈0.01 (CV=10%). Gene burst: amplifica ruído. Single-cell RNA-seq: mede distribuições.",
                    Criador = "Elowitz et al. (2002, Science, intrínseco vs extrínseco); Paulsson (2004, formalismo)",
                    AnoOrigin = "2002",
                    VariavelResultado = "η²",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "⟨n⟩ (moléculas)", Simbolo = "n_avg", Unidade = "moléculas", ValorPadrao = 100 }
                    },
                    Calcular = inputs =>
                    {
                        double n_avg = inputs["⟨n⟩ (moléculas)"];
                        if (n_avg == 0) return double.PositiveInfinity;
                        
                        double eta2 = 1.0 / n_avg;
                        return eta2;
                    },
                    Icone = "🧬"
                },

                // V10-119: PCR — Amplificação Exponencial
                new Formula
                {
                    Id = "3707",
                    CodigoCompendio = "V10-119",
                    Nome = "PCR — Amplificação Exponencial",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Biotecnologia",
                    Expressao = @"N_n = N₀·(1+E)^n",
                    Descricao = "Amplificação PCR. E: eficiência (0-1). E=1: duplica cada ciclo. n: número ciclos. qPCR: detecta C_t (threshold cycle).",
                    ExemploPratico = "1 cópia DNA, E=0.95, 30 ciclos: N_30≈5×10^8 (suficiente para gel). qPCR: C_t=20 (alta [inicial]), C_t=35 (baixa). ΔC_t=1: 2× diferença.",
                    Criador = "Mullis (1983, Nobel 1993, PCR invention); Higuchi (1993, qPCR real-time)",
                    AnoOrigin = "1983",
                    VariavelResultado = "N_final",
                    UnidadeResultado = "cópias",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N₀ (cópias iniciais)", Simbolo = "N0", Unidade = "cópias", ValorPadrao = 1 },
                        new Variavel { Nome = "Eficiência E", Simbolo = "E", Unidade = "", ValorPadrao = 0.95 },
                        new Variavel { Nome = "Ciclos n", Simbolo = "n", Unidade = "", ValorPadrao = 30 }
                    },
                    Calcular = inputs =>
                    {
                        double N0 = inputs["N₀ (cópias iniciais)"];
                        double E = inputs["Eficiência E"];
                        int n = (int)inputs["Ciclos n"];
                        
                        double N_final = N0 * Math.Pow(1 + E, n);
                        return N_final;
                    },
                    Icone = "🧬"
                },

                // V10-120: CRISPR — Eficiência de Edição
                new Formula
                {
                    Id = "3708",
                    CodigoCompendio = "V10-120",
                    Nome = "CRISPR — Eficiência de Knockout",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Edição Genômica",
                    Expressao = @"η_editing = n_editadas/n_total",
                    Descricao = "Eficiência CRISPR/Cas9. Fatores: design sgRNA, acessibilidade cromatina, concentração Cas9, delivery (lipofecção, eletroporação, viral). η≈10-90%.",
                    ExemploPratico = "Cell line HEK293: η≈70% (alta). Primary cells: η≈20-40% (baixa). On-target: η_KO, Off-target: minimizar. Base editing: C→T, A→G sem DSB.",
                    Criador = "Doudna e Charpentier (2012, Science, Nobel 2020); Zhang (2013, mammalian cells)",
                    AnoOrigin = "2012",
                    VariavelResultado = "η",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Células editadas", Simbolo = "n_edit", Unidade = "células", ValorPadrao = 70 },
                        new Variavel { Nome = "Células totais", Simbolo = "n_total", Unidade = "células", ValorPadrao = 100 }
                    },
                    Calcular = inputs =>
                    {
                        double n_edit = inputs["Células editadas"];
                        double n_total = inputs["Células totais"];
                        
                        if (n_total == 0) return 0;
                        double eta = (n_edit / n_total) * 100;
                        return eta;
                    },
                    Icone = "🧬"
                },

                // V10-121: Modelo de Lotka-Volterra (Predador-Presa)
                new Formula
                {
                    Id = "3709",
                    CodigoCompendio = "V10-121",
                    Nome = "Modelo Lotka-Volterra — Predador-Presa",
                    Categoria = "Biologia de Sistemas",
                    SubCategoria = "Ecologia Populacional",
                    Expressao = @"dN/dt = αN − βNP; dP/dt = δβNP − γP",
                    Descricao = "N: presas, P: predadores. α: taxa natalidade presa. β: predação. γ: mortalidade predador. δ: eficiência conversão. Oscilações periódicas (ciclo limite).",
                    ExemploPratico = "Lynx-hare (Hudson Bay): período ~10 anos. Parâmetros: α≈0.5/ano, β≈0.02, γ≈0.8/ano. Pico presas → pico predadores (defasado ~1-2 anos). Conservação: P+N−c·ln(P)−d·ln(N).",
                    Criador = "Lotka (1925, química); Volterra (1926, ecologia)",
                    AnoOrigin = "1925",
                    VariavelResultado = "dN_dt",
                    UnidadeResultado = "indivíduos/ano",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N (presas)", Simbolo = "N", Unidade = "indivíduos", ValorPadrao = 1000 },
                        new Variavel { Nome = "P (predadores)", Simbolo = "P", Unidade = "indivíduos", ValorPadrao = 50 },
                        new Variavel { Nome = "α (natalidade)", Simbolo = "alpha", Unidade = "1/ano", ValorPadrao = 0.5 },
                        new Variavel { Nome = "β (predação)", Simbolo = "beta", Unidade = "1/(ind·ano)", ValorPadrao = 0.02 }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["N (presas)"];
                        double P = inputs["P (predadores)"];
                        double alpha = inputs["α (natalidade)"];
                        double beta = inputs["β (predação)"];
                        
                        double dN_dt = alpha * N - beta * N * P;
                        return dN_dt;
                    },
                    Icone = "🧬"
                }
            });
        }
    }
}
