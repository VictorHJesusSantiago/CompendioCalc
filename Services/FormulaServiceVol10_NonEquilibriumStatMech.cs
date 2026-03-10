using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XX
    /// MECÂNICA ESTATÍSTICA DE NÃO-EQUILÍBRIO
    /// Fórmulas V10-377 a V10-395 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_NonEquilibriumStatMech()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3965",
                    CodigoCompendio = "V10-377",
                    Nome = "Teorema de Flutuação de Jarzynski",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Relações de Flutuação",
                    Expressao = @"⟨e^(−βW)⟩ = e^(−βΔF)",
                    Descricao = "Relaciona trabalho (W) irreversível com variação de energia livre (ΔF). β=1/(k_BT). Válido para processos arbitrariamente rápidos fora do equilíbrio.",
                    ExemploPratico = "Puxar molécula DNA com AFM: W_diss>ΔF sempre, mas ⟨e^(−βW)⟩ = e^(−βΔF). Recupera 2ª lei: ⟨W⟩≥ΔF (desigualdade de Jensen).",
                    Criador = "Jarzynski (1997, Phys. Rev. Lett.)",
                    AnoOrigin = "1997",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Trabalho W (kJ/mol)", Simbolo = "W", Unidade = "kJ/mol", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ΔF (kJ/mol)", Simbolo = "ΔF", Unidade = "kJ/mol", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Temperatura T (K)", Simbolo = "T", Unidade = "K", ValorPadrao = 300, Descricao = "Parâmetro de entrada." }
                    },
                    VariavelResultado = "W_diss",
                    UnidadeResultado = "kJ/mol",
                    Calcular = inputs =>
                    {
                        double W = inputs["Trabalho W (kJ/mol)"];
                        double deltaF = inputs["ΔF (kJ/mol)"];
                        _ = inputs["Temperatura T (K)"];
                        
                        double W_diss = W - deltaF;
                        return W_diss;
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-378: Teorema de Crooks
                new Formula
                {
                    Id = "3966",
                    CodigoCompendio = "V10-378",
                    Nome = "Teorema de Flutuação de Crooks",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Relações de Flutuação",
                    Expressao = @"P_F(W)/P_R(−W) = exp((W−ΔF)/(k_BT))",
                    Descricao = "Relaciona distribuições de trabalho forward e reverse; cruza em W=ΔF.",
                    ExemploPratico = "Se W=12, ΔF=8 kJ/mol a 300K, razão forward/reverse é exponencialmente alta.",
                    Criador = "Gavin Crooks",
                    AnoOrigin = "1999",
                    VariavelResultado = "ratio",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "W (kJ/mol)", Simbolo = "W", Unidade = "kJ/mol", ValorPadrao = 12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ΔF (kJ/mol)", Simbolo = "dF", Unidade = "kJ/mol", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "T (K)", Simbolo = "T", Unidade = "K", ValorPadrao = 300, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double W = inputs["W (kJ/mol)"];
                        double dF = inputs["ΔF (kJ/mol)"];
                        double T = inputs["T (K)"];
                        if (T <= 0) return 0;
                        double R = 0.008314;
                        return Math.Exp((W - dF) / (R * T));
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-379: Produção de entropia
                new Formula
                {
                    Id = "3967",
                    CodigoCompendio = "V10-379",
                    Nome = "Taxa de Produção de Entropia",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Termodinâmica Irreversível",
                    Expressao = @"σ = Σ J_i·X_i ≥ 0",
                    Descricao = "Produto de fluxos termodinâmicos por forças conjugadas. Deve ser não-negativo.",
                    ExemploPratico = "Condução térmica unidimensional: σ = J_q·∇(1/T).",
                    Criador = "Prigogine",
                    AnoOrigin = "1947",
                    VariavelResultado = "sigma",
                    UnidadeResultado = "W/(m³·K)",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "J fluxo", Simbolo = "J", Unidade = "SI", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "X força", Simbolo = "X", Unidade = "SI", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["J fluxo"] * inputs["X força"],
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-380: Relações de Onsager
                new Formula
                {
                    Id = "3968",
                    CodigoCompendio = "V10-380",
                    Nome = "Relações de Reciprocidade de Onsager",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Coeficientes de Transporte",
                    Expressao = @"L_ij = L_ji",
                    Descricao = "Perto do equilíbrio e sob simetria de reversão temporal, matriz de transporte é simétrica.",
                    ExemploPratico = "Termodifusão e efeito Soret-Dufour obedecem acoplamento recíproco.",
                    Criador = "Lars Onsager",
                    AnoOrigin = "1931",
                    VariavelResultado = "delta_L",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "L_ij", Simbolo = "Lij", Unidade = "", ValorPadrao = 1.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "L_ji", Simbolo = "Lji", Unidade = "", ValorPadrao = 1.7, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => Math.Abs(inputs["L_ij"] - inputs["L_ji"]),
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-381: Flutuação-dissipação
                new Formula
                {
                    Id = "3969",
                    CodigoCompendio = "V10-381",
                    Nome = "Teorema Flutuação-Dissipação",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Resposta Linear",
                    Expressao = @"S(ω) = 2k_BT·Re[χ(ω)]/ω",
                    Descricao = "Relaciona espectro de flutuações com susceptibilidade dissipativa.",
                    ExemploPratico = "Ruído térmico de resistor (Nyquist) emerge como caso particular.",
                    Criador = "Callen-Welton / Kubo",
                    AnoOrigin = "1951",
                    VariavelResultado = "S",
                    UnidadeResultado = "SI",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "T (K)", Simbolo = "T", Unidade = "K", ValorPadrao = 300, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Re[χ(ω)]", Simbolo = "chi", Unidade = "", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ω (rad/s)", Simbolo = "w", Unidade = "rad/s", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double T = inputs["T (K)"];
                        double chi = inputs["Re[χ(ω)]"];
                        double w = inputs["ω (rad/s)"];
                        if (w == 0) return 0;
                        double kB = 1.380649e-23;
                        return 2 * kB * T * chi / w;
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-382: Equação de Fokker-Planck (drift)
                new Formula
                {
                    Id = "3970",
                    CodigoCompendio = "V10-382",
                    Nome = "Fokker-Planck — Velocidade de Drift",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Processos Estocásticos",
                    Expressao = @"∂P/∂t = −∂(A·P)/∂x + D·∂²P/∂x²",
                    Descricao = "Dinâmica de densidade de probabilidade com drift A e difusão D.",
                    ExemploPratico = "Com A>0, distribuição desloca para x maior ao longo do tempo.",
                    Criador = "Fokker, Planck",
                    AnoOrigin = "1914",
                    VariavelResultado = "Pe",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "A drift", Simbolo = "A", Unidade = "", ValorPadrao = 0.4, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "D difusão", Simbolo = "D", Unidade = "", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "L escala", Simbolo = "L", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double A = inputs["A drift"];
                        double D = inputs["D difusão"];
                        double L = inputs["L escala"];
                        if (D == 0) return 0;
                        return A * L / D;
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-383: Einstein-Smoluchowski
                new Formula
                {
                    Id = "3971",
                    CodigoCompendio = "V10-383",
                    Nome = "Relação de Einstein",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Difusão",
                    Expressao = @"D = μ·k_BT",
                    Descricao = "Conecta mobilidade e difusão para partículas brownianas.",
                    ExemploPratico = "μ=4e7 m/(N·s), T=300K → D≈1.66e-13 m²/s.",
                    Criador = "Albert Einstein",
                    AnoOrigin = "1905",
                    VariavelResultado = "D",
                    UnidadeResultado = "m²/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "μ mobilidade (m/N·s)", Simbolo = "mu", Unidade = "m/N·s", ValorPadrao = 4e7, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "T (K)", Simbolo = "T", Unidade = "K", ValorPadrao = 300, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => 1.380649e-23 * inputs["T (K)"] * inputs["μ mobilidade (m/N·s)"],
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-384: Caminhada aleatória
                new Formula
                {
                    Id = "3972",
                    CodigoCompendio = "V10-384",
                    Nome = "Deslocamento Quadrático Médio",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Difusão",
                    Expressao = @"⟨x²⟩ = 2Dt",
                    Descricao = "Em 1D, crescimento linear no tempo para difusão normal.",
                    ExemploPratico = "D=1e-9 m²/s, t=100 s → ⟨x²⟩=2e-7 m², RMS≈0.45 mm.",
                    Criador = "Smoluchowski",
                    AnoOrigin = "1906",
                    VariavelResultado = "x2",
                    UnidadeResultado = "m²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "D (m²/s)", Simbolo = "D", Unidade = "m²/s", ValorPadrao = 1e-9, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (s)", Simbolo = "t", Unidade = "s", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => 2 * inputs["D (m²/s)"] * inputs["t (s)"],
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-385: Equação mestra discreta
                new Formula
                {
                    Id = "3973",
                    CodigoCompendio = "V10-385",
                    Nome = "Equação Mestra — Taxa Líquida",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Processos Markovianos",
                    Expressao = @"dP_i/dt = Σ_j(W_jiP_j − W_ijP_i)",
                    Descricao = "Evolução probabilística em espaço de estados discreto.",
                    ExemploPratico = "Dois estados com taxas assimétricas geram relaxação exponencial para estado estacionário.",
                    Criador = "Kolmogorov",
                    AnoOrigin = "1931",
                    VariavelResultado = "dPdt",
                    UnidadeResultado = "1/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Entrada ΣWjiPj", Simbolo = "in", Unidade = "1/s", ValorPadrao = 0.35, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Saída ΣWijPi", Simbolo = "out", Unidade = "1/s", ValorPadrao = 0.20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["Entrada ΣWjiPj"] - inputs["Saída ΣWijPi"],
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-386: Balanço detalhado
                new Formula
                {
                    Id = "3974",
                    CodigoCompendio = "V10-386",
                    Nome = "Condição de Balanço Detalhado",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Equilíbrio Estocástico",
                    Expressao = @"W_ij·P_i^* = W_ji·P_j^*",
                    Descricao = "No equilíbrio microscópico, fluxos entre pares de estados se cancelam.",
                    ExemploPratico = "Se W12P1*=0.12 e W21P2*=0.10, desvio=0.02 indica fora do equilíbrio.",
                    Criador = "Boltzmann-Gibbs",
                    AnoOrigin = "1870",
                    VariavelResultado = "delta",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "W_ij·P_i*", Simbolo = "a", Unidade = "", ValorPadrao = 0.12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "W_ji·P_j*", Simbolo = "b", Unidade = "", ValorPadrao = 0.10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => Math.Abs(inputs["W_ij·P_i*"] - inputs["W_ji·P_j*"]),
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-387: H-teorema
                new Formula
                {
                    Id = "3975",
                    CodigoCompendio = "V10-387",
                    Nome = "H-Teorema de Boltzmann",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Irreversibilidade",
                    Expressao = @"dH/dt ≤ 0, H=∫f ln f dΓ",
                    Descricao = "Formaliza tendência ao equilíbrio em gases diluídos via diminuição de H.",
                    ExemploPratico = "Em relaxação colisional, H cai monotonicamente até estado estacionário.",
                    Criador = "Ludwig Boltzmann",
                    AnoOrigin = "1872",
                    VariavelResultado = "dHdt",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Taxa colisional", Simbolo = "c", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => -Math.Abs(inputs["Taxa colisional"]),
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-388: Relaxação exponencial
                new Formula
                {
                    Id = "3976",
                    CodigoCompendio = "V10-388",
                    Nome = "Relaxação para Equilíbrio",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Cinética",
                    Expressao = @"A(t)=A_eq+(A0−A_eq)e^(−t/τ)",
                    Descricao = "Muitos observáveis macroscópicos relaxam exponencialmente.",
                    ExemploPratico = "A0=10, Aeq=2, τ=5 s, t=10 s → A≈3.08.",
                    Criador = "Cinética linear",
                    AnoOrigin = "1900",
                    VariavelResultado = "A",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "A0", Simbolo = "A0", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "A_eq", Simbolo = "Aeq", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "τ (s)", Simbolo = "tau", Unidade = "s", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (s)", Simbolo = "t", Unidade = "s", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double A0 = inputs["A0"];
                        double Aeq = inputs["A_eq"];
                        double tau = inputs["τ (s)"];
                        double t = inputs["t (s)"];
                        if (tau <= 0) return Aeq;
                        return Aeq + (A0 - Aeq) * Math.Exp(-t / tau);
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-389: Kramers rate
                new Formula
                {
                    Id = "3977",
                    CodigoCompendio = "V10-389",
                    Nome = "Taxa de Escape de Kramers",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Ativação Térmica",
                    Expressao = @"k ≈ ν0·exp(−ΔU/(k_BT))",
                    Descricao = "Taxa de escape sobre barreira potencial por flutuações térmicas.",
                    ExemploPratico = "ν0=1e9 s^-1, ΔU=20kBT → k≈2.06 s^-1.",
                    Criador = "Hendrik Kramers",
                    AnoOrigin = "1940",
                    VariavelResultado = "k",
                    UnidadeResultado = "1/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ν0 (1/s)", Simbolo = "nu0", Unidade = "1/s", ValorPadrao = 1e9, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ΔU/(kBT)", Simbolo = "u", Unidade = "", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["ν0 (1/s)"] * Math.Exp(-inputs["ΔU/(kBT)"]),
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-390: Número de Péclet
                new Formula
                {
                    Id = "3978",
                    CodigoCompendio = "V10-390",
                    Nome = "Número de Péclet",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Transporte",
                    Expressao = @"Pe = vL/D",
                    Descricao = "Compara advecção e difusão. Pe>>1 advecção domina; Pe<<1 difusão domina.",
                    ExemploPratico = "v=1e-3 m/s, L=1e-3 m, D=1e-9 m²/s → Pe=1000.",
                    Criador = "Mecânica dos fluidos",
                    AnoOrigin = "1920",
                    VariavelResultado = "Pe",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 1e-3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "L (m)", Simbolo = "L", Unidade = "m", ValorPadrao = 1e-3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "D (m²/s)", Simbolo = "D", Unidade = "m²/s", ValorPadrao = 1e-9, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double D = inputs["D (m²/s)"];
                        if (D == 0) return 0;
                        return inputs["v (m/s)"] * inputs["L (m)"] / D;
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-391: Reynolds entrópico (produção normalizada)
                new Formula
                {
                    Id = "3979",
                    CodigoCompendio = "V10-391",
                    Nome = "Produção Entropia Normalizada",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Métricas",
                    Expressao = @"Π = σ/σ_ref",
                    Descricao = "Índice adimensional para comparar regimes dissipativos distintos.",
                    ExemploPratico = "σ=0.45, σ_ref=0.30 → Π=1.5.",
                    Criador = "Análise dimensional",
                    AnoOrigin = "2000",
                    VariavelResultado = "Pi",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ", Simbolo = "s", Unidade = "", ValorPadrao = 0.45, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ_ref", Simbolo = "sr", Unidade = "", ValorPadrao = 0.30, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double sr = inputs["σ_ref"];
                        if (sr == 0) return 0;
                        return inputs["σ"] / sr;
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-392: Tempo de correlação
                new Formula
                {
                    Id = "3980",
                    CodigoCompendio = "V10-392",
                    Nome = "Tempo de Correlação",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Flutuações",
                    Expressao = @"C(t)=C0·exp(−t/τ_c)",
                    Descricao = "Decaimento temporal de autocorrelação em processo markoviano simples.",
                    ExemploPratico = "C0=1, τ_c=2 s, t=4 s → C=0.135.",
                    Criador = "Teoria de processos estocásticos",
                    AnoOrigin = "1930",
                    VariavelResultado = "C",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "C0", Simbolo = "C0", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "τ_c (s)", Simbolo = "tc", Unidade = "s", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (s)", Simbolo = "t", Unidade = "s", ValorPadrao = 4, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double C0 = inputs["C0"];
                        double tc = inputs["τ_c (s)"];
                        double t = inputs["t (s)"];
                        if (tc <= 0) return 0;
                        return C0 * Math.Exp(-t / tc);
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-393: Princípio de mínima produção (linear)
                new Formula
                {
                    Id = "3981",
                    CodigoCompendio = "V10-393",
                    Nome = "Princípio de Mínima Produção de Entropia",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Estados Estacionários",
                    Expressao = @"δσ = 0 (próximo do equilíbrio)",
                    Descricao = "Para sistemas lineares próximos ao equilíbrio, estado estacionário minimiza produção de entropia.",
                    ExemploPratico = "Em rede resistiva linear, distribuição de correntes estacionária minimiza dissipação total.",
                    Criador = "Ilya Prigogine",
                    AnoOrigin = "1947",
                    VariavelResultado = "sigma_min",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ atual", Simbolo = "s", Unidade = "", ValorPadrao = 0.42, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ candidato", Simbolo = "sc", Unidade = "", ValorPadrao = 0.40, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => Math.Min(inputs["σ atual"], inputs["σ candidato"]),
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-394: Teorema central limite para fluxos
                new Formula
                {
                    Id = "3982",
                    CodigoCompendio = "V10-394",
                    Nome = "Erro Padrão de Média de Fluxo",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Estatística de Medidas",
                    Expressao = @"SE = σ/√N",
                    Descricao = "Incerteza da média de observáveis estocásticos medidos em N amostras independentes.",
                    ExemploPratico = "σ=0.8, N=100 → SE=0.08.",
                    Criador = "Estatística clássica",
                    AnoOrigin = "1900",
                    VariavelResultado = "SE",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ desvio", Simbolo = "sigma", Unidade = "", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "N amostras", Simbolo = "N", Unidade = "", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double sigma = inputs["σ desvio"];
                        double N = inputs["N amostras"];
                        if (N <= 0) return 0;
                        return sigma / Math.Sqrt(N);
                    },
                    Icone = "📈",
                    Unidades = "",
                },

                // V10-395: Função de partição efetiva (2 estados)
                new Formula
                {
                    Id = "3983",
                    CodigoCompendio = "V10-395",
                    Nome = "Sistema de Dois Estados fora do Equilíbrio",
                    Categoria = "Mecânica Estatística de Não-Equilíbrio",
                    SubCategoria = "Modelos Mínimos",
                    Expressao = @"p1 = k21/(k12+k21), p2 = 1−p1",
                    Descricao = "Estado estacionário para dois estados com taxas de transição constantes.",
                    ExemploPratico = "k12=3 s^-1, k21=1 s^-1 → p1=0.25, p2=0.75.",
                    Criador = "Cinética de dois estados",
                    AnoOrigin = "1930",
                    VariavelResultado = "p1",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k12 (1/s)", Simbolo = "k12", Unidade = "1/s", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k21 (1/s)", Simbolo = "k21", Unidade = "1/s", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double k12 = inputs["k12 (1/s)"];
                        double k21 = inputs["k21 (1/s)"];
                        double den = k12 + k21;
                        if (den <= 0) return 0;
                        return k21 / den;
                    },
                    Icone = "📈",
                    Unidades = "",
                }
            });
        }
    }
}
