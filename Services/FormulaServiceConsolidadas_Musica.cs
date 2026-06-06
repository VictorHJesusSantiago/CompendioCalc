using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Musica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4801", Nome = "Frequência de Nota Musical (Temperamento Igual)",
                    Categoria = "Música", SubCategoria = "Teoria Musical / Acústica",
                    Expressao = "fn = f0 × 2^(n/12)",
                    Descricao = "Frequência de nota n semitons acima de f0 no temperamento igual de 12 divisões por oitava.",
                    Criador = "Mersenne M / Werkmeister A", AnoOrigin = "1636 / 1691",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed. 2001.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência de referência (f0)", Simbolo = "f0", Unidade = "Hz", ValorPadrao = 440 },
                        new Variavel { Nome = "Número de semitons (n)", Simbolo = "n", Unidade = "", ValorPadrao = 12 }
                    },
                    Calcular = v => v["f0"] * Math.Pow(2, v["n"] / 12.0),
                    VariavelResultado = "fn", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4802", Nome = "Intervalo em Cents",
                    Categoria = "Música", SubCategoria = "Microtonalidade",
                    Expressao = "c = 1200 × log2(f2 / f1)",
                    Descricao = "Medida logarítmica de intervalo musical; 1 semitom = 100 cents; 1 oitava = 1200 cents.",
                    Criador = "Ellis AJ", AnoOrigin = "1885",
                    ReferenciaBibliografica = "Ellis AJ. In: Helmholtz H. On the Sensations of Tone, 1885.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência 1 (f1)", Simbolo = "f1", Unidade = "Hz", ValorPadrao = 440, ValorMin = 1e-6 },
                        new Variavel { Nome = "Frequência 2 (f2)", Simbolo = "f2", Unidade = "Hz", ValorPadrao = 880 }
                    },
                    Calcular = v => 1200 * Math.Log(v["f2"] / v["f1"]) / Math.Log(2),
                    VariavelResultado = "c", UnidadeResultado = "cents"
                },
                new Formula
                {
                    Id = "C4803", Nome = "Frequência Fundamental de Corda Vibrante",
                    Categoria = "Música", SubCategoria = "Acústica Musical",
                    Expressao = "f1 = (1/2L) × sqrt(T/μ)",
                    Descricao = "Frequência fundamental de corda de comprimento L, tensão T e massa linear μ (lei de Mersenne).",
                    Criador = "Mersenne M", AnoOrigin = "1636",
                    ReferenciaBibliografica = "Mersenne M. Harmonie Universelle, 1636.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Comprimento (L)", Simbolo = "L", Unidade = "m", ValorPadrao = 0.65, ValorMin = 0.001 },
                        new Variavel { Nome = "Tensão (T)", Simbolo = "T", Unidade = "N", ValorPadrao = 100 },
                        new Variavel { Nome = "Massa linear (μ)", Simbolo = "μ", Unidade = "kg/m", ValorPadrao = 0.001, ValorMin = 1e-10 }
                    },
                    Calcular = v => (1.0 / (2*v["L"])) * Math.Sqrt(v["T"] / v["μ"]),
                    VariavelResultado = "f1", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4804", Nome = "Frequência Fundamental de Tubo Aberto",
                    Categoria = "Música", SubCategoria = "Acústica Musical",
                    Expressao = "f1 = v / (2L)",
                    Descricao = "Frequência fundamental de tubo cilíndrico aberto nas duas extremidades; antinodo nos dois lados.",
                    Criador = "Bernoulli D", AnoOrigin = "1729",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade do som (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 343 },
                        new Variavel { Nome = "Comprimento do tubo (L)", Simbolo = "L", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0.001 }
                    },
                    Calcular = v => v["v"] / (2 * v["L"]),
                    VariavelResultado = "f1", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4805", Nome = "Frequência Fundamental de Tubo Fechado",
                    Categoria = "Música", SubCategoria = "Acústica Musical",
                    Expressao = "f1 = v / (4L)",
                    Descricao = "Frequência fundamental de tubo fechado em uma extremidade; nó na extremidade fechada, antinodo na aberta.",
                    Criador = "Bernoulli D", AnoOrigin = "1729",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade do som (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 343 },
                        new Variavel { Nome = "Comprimento do tubo (L)", Simbolo = "L", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0.001 }
                    },
                    Calcular = v => v["v"] / (4 * v["L"]),
                    VariavelResultado = "f1", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4806", Nome = "Batimentos Acústicos",
                    Categoria = "Música", SubCategoria = "Acústica Musical",
                    Expressao = "fb = |f1 − f2|",
                    Descricao = "Frequência de pulsação gerada pela superposição de duas ondas de frequências ligeiramente diferentes; usada na afinação.",
                    Criador = "Mersenne M", AnoOrigin = "1636",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência 1 (f1)", Simbolo = "f1", Unidade = "Hz", ValorPadrao = 440 },
                        new Variavel { Nome = "Frequência 2 (f2)", Simbolo = "f2", Unidade = "Hz", ValorPadrao = 442 }
                    },
                    Calcular = v => Math.Abs(v["f1"] - v["f2"]),
                    VariavelResultado = "fb", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4807", Nome = "Tempo de Reverberação (Fórmula de Sabine)",
                    Categoria = "Música", SubCategoria = "Acústica Arquitetônica",
                    Expressao = "T60 = 0,161 × V / A",
                    Descricao = "Tempo para o nível sonoro decair 60 dB após extinção da fonte; A = absorção total (m² Sabine).",
                    Criador = "Sabine WC", AnoOrigin = "1900",
                    ReferenciaBibliografica = "Sabine WC. Am Architect, 1900. Reprinted in Reverberation and Other Topics, 1922.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Volume da sala (V)", Simbolo = "V", Unidade = "m³", ValorPadrao = 500, ValorMin = 0.001 },
                        new Variavel { Nome = "Absorção total (A)", Simbolo = "A", Unidade = "m²Sabine", ValorPadrao = 100, ValorMin = 0.001 }
                    },
                    Calcular = v => 0.161 * v["V"] / v["A"],
                    VariavelResultado = "T60", UnidadeResultado = "s"
                },
                new Formula
                {
                    Id = "C4808", Nome = "Tempo de Reverberação (Fórmula de Eyring)",
                    Categoria = "Música", SubCategoria = "Acústica Arquitetônica",
                    Expressao = "T60 = −0,161 × V / (S × ln(1 − α̅))",
                    Descricao = "Versão melhorada da fórmula de Sabine, mais precisa para salas com alta absorção.",
                    Criador = "Eyring CF", AnoOrigin = "1930",
                    ReferenciaBibliografica = "Eyring CF. J Acoust Soc Am, 1930.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Volume da sala (V)", Simbolo = "V", Unidade = "m³", ValorPadrao = 500, ValorMin = 0.001 },
                        new Variavel { Nome = "Área total das superfícies (S)", Simbolo = "S", Unidade = "m²", ValorPadrao = 600, ValorMin = 0.001 },
                        new Variavel { Nome = "Coeficiente médio de absorção (α̅)", Simbolo = "alpha", Unidade = "", ValorPadrao = 0.2, ValorMin = 0.001, ValorMax = 0.999 }
                    },
                    Calcular = v => -0.161 * v["V"] / (v["S"] * Math.Log(1 - v["alpha"])),
                    VariavelResultado = "T60", UnidadeResultado = "s"
                },
                new Formula
                {
                    Id = "C4809", Nome = "Nível de Pressão Sonora (SPL)",
                    Categoria = "Música", SubCategoria = "Acústica",
                    Expressao = "SPL = 20 × log10(p / p0)",
                    Descricao = "Nível de pressão sonora em decibéis; p0 = 20 μPa (limiar de audição humana).",
                    Criador = "Bell AG (nome em homenagem)", AnoOrigin = "1920",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Pressão sonora (p)", Simbolo = "p", Unidade = "Pa", ValorPadrao = 0.02, ValorMin = 1e-10 },
                        new Variavel { Nome = "Pressão de referência (p0)", Simbolo = "p0", Unidade = "Pa", ValorPadrao = 20e-6, ValorMin = 1e-15 }
                    },
                    Calcular = v => 20 * Math.Log10(v["p"] / v["p0"]),
                    VariavelResultado = "SPL", UnidadeResultado = "dB"
                },
                new Formula
                {
                    Id = "C4810", Nome = "Frequências Harmônicas de Corda",
                    Categoria = "Música", SubCategoria = "Acústica Musical",
                    Expressao = "fn = n × f1",
                    Descricao = "Frequências dos harmônicos superiores de corda vibrante; n=1 é fundamental, n=2 é oitava, etc.",
                    Criador = "Pitágoras (observação) / Bernoulli D (teoria)", AnoOrigin = "séc. VI a.C.",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número do harmônico (n)", Simbolo = "n", Unidade = "", ValorPadrao = 2, ValorMin = 1 },
                        new Variavel { Nome = "Frequência fundamental (f1)", Simbolo = "f1", Unidade = "Hz", ValorPadrao = 440 }
                    },
                    Calcular = v => v["n"] * v["f1"],
                    VariavelResultado = "fn", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4811", Nome = "Velocidade do Som no Ar",
                    Categoria = "Música", SubCategoria = "Acústica",
                    Expressao = "v = 331 + 0,6 × T",
                    Descricao = "Velocidade do som no ar em função da temperatura T em °C; afeta afinação de instrumentos de sopro.",
                    Criador = "Miller DG (fórmula simplificada)", AnoOrigin = "1916",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura do ar (T)", Simbolo = "T", Unidade = "°C", ValorPadrao = 20 }
                    },
                    Calcular = v => 331.0 + 0.6 * v["T"],
                    VariavelResultado = "v", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C4812", Nome = "Quinta Justa de Pitágoras",
                    Categoria = "Música", SubCategoria = "Teoria Musical",
                    Expressao = "f_quinta = f0 × (3/2)",
                    Descricao = "Relação de frequências da quinta justa pitagórica; razão 3:2 entre frequências.",
                    Criador = "Pitágoras", AnoOrigin = "séc. VI a.C.",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência fundamental (f0)", Simbolo = "f0", Unidade = "Hz", ValorPadrao = 440 }
                    },
                    Calcular = v => v["f0"] * 1.5,
                    VariavelResultado = "f_quinta", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4813", Nome = "Relação Sinal-Ruído de Áudio (SNR)",
                    Categoria = "Música", SubCategoria = "Engenharia de Áudio",
                    Expressao = "SNR = 20 × log10(Vs / Vn)",
                    Descricao = "Relação entre amplitude do sinal desejado e do ruído; mede qualidade de gravação/reprodução.",
                    Criador = "Prática de engenharia de áudio", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Pohlmann KC. Principles of Digital Audio, 6ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tensão do sinal (Vs)", Simbolo = "Vs", Unidade = "V", ValorPadrao = 1, ValorMin = 1e-10 },
                        new Variavel { Nome = "Tensão do ruído (Vn)", Simbolo = "Vn", Unidade = "V", ValorPadrao = 0.001, ValorMin = 1e-15 }
                    },
                    Calcular = v => 20 * Math.Log10(v["Vs"] / v["Vn"]),
                    VariavelResultado = "SNR", UnidadeResultado = "dB"
                },
                new Formula
                {
                    Id = "C4814", Nome = "Frequência de Ressonância de Sala (Modos Axiais)",
                    Categoria = "Música", SubCategoria = "Acústica Arquitetônica",
                    Expressao = "f_modos = (v/2) × sqrt((p/L)² + (q/W)² + (r/H)²)",
                    Descricao = "Frequências de modos normais de sala retangular; p,q,r são inteiros representando modos axiais.",
                    Criador = "Rayleigh JWS", AnoOrigin = "1877",
                    ReferenciaBibliografica = "Everest FA. Master Handbook of Acoustics, 5ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade do som (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 343 },
                        new Variavel { Nome = "Comprimento (L)", Simbolo = "L", Unidade = "m", ValorPadrao = 10, ValorMin = 0.001 },
                        new Variavel { Nome = "Largura (W)", Simbolo = "W", Unidade = "m", ValorPadrao = 6, ValorMin = 0.001 },
                        new Variavel { Nome = "Altura (H)", Simbolo = "H", Unidade = "m", ValorPadrao = 3, ValorMin = 0.001 },
                        new Variavel { Nome = "Modo p (comprimento)", Simbolo = "p", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Modo q (largura)", Simbolo = "q", Unidade = "", ValorPadrao = 0 },
                        new Variavel { Nome = "Modo r (altura)", Simbolo = "r", Unidade = "", ValorPadrao = 0 }
                    },
                    Calcular = v => (v["v"]/2) * Math.Sqrt(Math.Pow(v["p"]/v["L"],2) + Math.Pow(v["q"]/v["W"],2) + Math.Pow(v["r"]/v["H"],2)),
                    VariavelResultado = "f_modos", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4815", Nome = "Comprimento de Onda Sonora",
                    Categoria = "Música", SubCategoria = "Acústica",
                    Expressao = "λ = v / f",
                    Descricao = "Comprimento de onda de som de frequência f na velocidade v; base para dimensionar tubos e caixas acústicas.",
                    Criador = "Teoria ondulatória clássica", AnoOrigin = "séc. XVII",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade do som (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 343 },
                        new Variavel { Nome = "Frequência (f)", Simbolo = "f", Unidade = "Hz", ValorPadrao = 440, ValorMin = 0.001 }
                    },
                    Calcular = v => v["v"] / v["f"],
                    VariavelResultado = "λ", UnidadeResultado = "m"
                },
                new Formula
                {
                    Id = "C4816", Nome = "Intensidade Sonora",
                    Categoria = "Música", SubCategoria = "Acústica",
                    Expressao = "I = p² / (ρ × c)",
                    Descricao = "Intensidade sonora (potência por área) em função da pressão, densidade e velocidade do som.",
                    Criador = "Rayleigh JWS", AnoOrigin = "1877",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Pressão sonora (p)", Simbolo = "p", Unidade = "Pa", ValorPadrao = 1 },
                        new Variavel { Nome = "Densidade do ar (ρ)", Simbolo = "ρ", Unidade = "kg/m³", ValorPadrao = 1.21, ValorMin = 1e-6 },
                        new Variavel { Nome = "Velocidade do som (c)", Simbolo = "c", Unidade = "m/s", ValorPadrao = 343, ValorMin = 1 }
                    },
                    Calcular = v => v["p"]*v["p"] / (v["ρ"] * v["c"]),
                    VariavelResultado = "I", UnidadeResultado = "W/m²"
                },
                new Formula
                {
                    Id = "C4817", Nome = "Nível de Intensidade Sonora (IL)",
                    Categoria = "Música", SubCategoria = "Acústica",
                    Expressao = "IL = 10 × log10(I / I0)",
                    Descricao = "Nível de intensidade em decibéis; I0 = 10⁻¹² W/m² (limiar de audição).",
                    Criador = "Bell AG (nome em homenagem)", AnoOrigin = "1920",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Intensidade sonora (I)", Simbolo = "I", Unidade = "W/m²", ValorPadrao = 1e-6, ValorMin = 1e-20 },
                        new Variavel { Nome = "Intensidade de referência (I0)", Simbolo = "I0", Unidade = "W/m²", ValorPadrao = 1e-12, ValorMin = 1e-30 }
                    },
                    Calcular = v => 10 * Math.Log10(v["I"] / v["I0"]),
                    VariavelResultado = "IL", UnidadeResultado = "dB"
                },
                new Formula
                {
                    Id = "C4818", Nome = "Taxa de Amostragem de Nyquist",
                    Categoria = "Música", SubCategoria = "Engenharia de Áudio Digital",
                    Expressao = "fs ≥ 2 × fmax",
                    Descricao = "Taxa de amostragem mínima para reconstruir sinal sem aliasing; base do áudio digital (CD: 44,1 kHz).",
                    Criador = "Nyquist H / Shannon CE", AnoOrigin = "1928 / 1949",
                    ReferenciaBibliografica = "Nyquist H. Trans AIEE, 1928; Shannon CE. Proc IRE, 1949.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência máxima (fmax)", Simbolo = "fmax", Unidade = "Hz", ValorPadrao = 20000 }
                    },
                    Calcular = v => 2 * v["fmax"],
                    VariavelResultado = "fs_min", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4819", Nome = "Resolução de Amplitude (Bits de Áudio)",
                    Categoria = "Música", SubCategoria = "Engenharia de Áudio Digital",
                    Expressao = "DR = 20 × log10(2^n) ≈ 6,02 × n",
                    Descricao = "Faixa dinâmica máxima de sistema de áudio digital com n bits por amostra (CD: 16 bits ≈ 96 dB).",
                    Criador = "Prática de engenharia de áudio", AnoOrigin = "1970",
                    ReferenciaBibliografica = "Pohlmann KC. Principles of Digital Audio, 6ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de bits (n)", Simbolo = "n", Unidade = "bits", ValorPadrao = 16, ValorMin = 1 }
                    },
                    Calcular = v => 6.0206 * v["n"],
                    VariavelResultado = "DR", UnidadeResultado = "dB"
                },
                new Formula
                {
                    Id = "C4820", Nome = "Efeito Doppler Sonoro",
                    Categoria = "Música", SubCategoria = "Acústica",
                    Expressao = "f' = f × (v + vo) / (v − vs)",
                    Descricao = "Frequência percebida por observador em movimento vo quando fonte se aproxima com velocidade vs.",
                    Criador = "Doppler CJ", AnoOrigin = "1842",
                    ReferenciaBibliografica = "Doppler CJ. Abh Konigl Bohm Ges Wiss, 1842.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência da fonte (f)", Simbolo = "f", Unidade = "Hz", ValorPadrao = 440 },
                        new Variavel { Nome = "Velocidade do som (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 343 },
                        new Variavel { Nome = "Velocidade do observador (vo)", Simbolo = "vo", Unidade = "m/s", ValorPadrao = 0 },
                        new Variavel { Nome = "Velocidade da fonte (vs)", Simbolo = "vs", Unidade = "m/s", ValorPadrao = 10, ValorMin = -342, ValorMax = 342 }
                    },
                    Calcular = v => v["f"] * (v["v"] + v["vo"]) / (v["v"] - v["vs"]),
                    VariavelResultado = "f'", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4821", Nome = "Frequência de Modo de Helmholtz (Ressonador)",
                    Categoria = "Música", SubCategoria = "Acústica Musical",
                    Expressao = "f_H = (c/2π) × sqrt(A / (V × L_ef))",
                    Descricao = "Frequência de ressonância de cavidade de Helmholtz; modelo de caixas acústicas e corpos de violão.",
                    Criador = "Helmholtz HvH", AnoOrigin = "1860",
                    ReferenciaBibliografica = "Helmholtz HvH. On the Sensations of Tone, 1875.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade do som (c)", Simbolo = "c", Unidade = "m/s", ValorPadrao = 343 },
                        new Variavel { Nome = "Área do gargalo (A)", Simbolo = "A", Unidade = "m²", ValorPadrao = 0.001, ValorMin = 1e-10 },
                        new Variavel { Nome = "Volume da cavidade (V)", Simbolo = "V", Unidade = "m³", ValorPadrao = 0.01, ValorMin = 1e-10 },
                        new Variavel { Nome = "Comprimento efetivo do gargalo (L_ef)", Simbolo = "L_ef", Unidade = "m", ValorPadrao = 0.05, ValorMin = 1e-6 }
                    },
                    Calcular = v => (v["c"] / (2 * Math.PI)) * Math.Sqrt(v["A"] / (v["V"] * v["L_ef"])),
                    VariavelResultado = "f_H", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4822", Nome = "Quarta Justa Pitagórica",
                    Categoria = "Música", SubCategoria = "Teoria Musical",
                    Expressao = "f_quarta = f0 × (4/3)",
                    Descricao = "Relação de frequências da quarta justa; razão 4:3 entre frequências, formando consonância perfeita.",
                    Criador = "Pitágoras", AnoOrigin = "séc. VI a.C.",
                    ReferenciaBibliografica = "Rossing TD et al. The Science of Sound, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência fundamental (f0)", Simbolo = "f0", Unidade = "Hz", ValorPadrao = 440 }
                    },
                    Calcular = v => v["f0"] * (4.0/3),
                    VariavelResultado = "f_quarta", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4823", Nome = "Coeficiente de Absorção Sonora",
                    Categoria = "Música", SubCategoria = "Acústica Arquitetônica",
                    Expressao = "α = 1 − (Ir / Ii)",
                    Descricao = "Fração de energia sonora absorvida por superfície; α=0 reflexão total, α=1 absorção total.",
                    Criador = "Sabine WC", AnoOrigin = "1900",
                    ReferenciaBibliografica = "Everest FA. Master Handbook of Acoustics, 5ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Intensidade incidente (Ii)", Simbolo = "Ii", Unidade = "W/m²", ValorPadrao = 1, ValorMin = 1e-15 },
                        new Variavel { Nome = "Intensidade refletida (Ir)", Simbolo = "Ir", Unidade = "W/m²", ValorPadrao = 0.7 }
                    },
                    Calcular = v => 1 - v["Ir"] / v["Ii"],
                    VariavelResultado = "α", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C4824", Nome = "Transposição de Instrumento (Frequência Relativa)",
                    Categoria = "Música", SubCategoria = "Teoria Musical",
                    Expressao = "f_transposta = f0 × 2^(semitons/12)",
                    Descricao = "Frequência de nota transposta por número de semitons acima (+) ou abaixo (−) da original.",
                    Criador = "Prática musical", AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Piston W. Harmony, 5ª ed. 1987.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência original (f0)", Simbolo = "f0", Unidade = "Hz", ValorPadrao = 440 },
                        new Variavel { Nome = "Número de semitons", Simbolo = "semitons", Unidade = "", ValorPadrao = 7 }
                    },
                    Calcular = v => v["f0"] * Math.Pow(2, v["semitons"] / 12.0),
                    VariavelResultado = "f_transposta", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C4825", Nome = "Tempo de Delay Musical (BPM → ms)",
                    Categoria = "Música", SubCategoria = "Produção Musical",
                    Expressao = "T_colcheia = 60000 / (BPM × 2)",
                    Descricao = "Duração em milissegundos de uma colcheia ao dado andamento em batidas por minuto.",
                    Criador = "Prática de produção musical", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Izhaki R. Mixing Audio, 3ª ed. Focal Press.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Andamento (BPM)", Simbolo = "BPM", Unidade = "bpm", ValorPadrao = 120, ValorMin = 1 }
                    },
                    Calcular = v => 60000.0 / (v["BPM"] * 2),
                    VariavelResultado = "T_colcheia", UnidadeResultado = "ms"
                }
            });
        }
    }
}
