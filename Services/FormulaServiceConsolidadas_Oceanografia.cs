using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Oceanografia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C4301", Nome = "Salinidade da Água do Mar",
                    Categoria = "Oceanografia", SubCategoria = "Química Marinha",
                    Expressao = "S = (m_sal / m_água) × 1000",
                    Descricao = "Massa de sais dissolvidos por quilograma de água do mar, expressa em partes por mil (‰) ou PSU.",
                    Criador = "Convenção IOC/SCOR/IAPSO", AnoOrigin = "1978",
                    ReferenciaBibliografica = "UNESCO. The Practical Salinity Scale 1978. Tech. Papers Mar. Sci., 1981.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa de sais", Simbolo = "m_sal", Unidade = "g", ValorPadrao = 35 },
                        new Variavel { Nome = "Massa de água", Simbolo = "m_água", Unidade = "kg", ValorPadrao = 1, ValorMin = 1e-6 }
                    },
                    Calcular = v => v["m_sal"] / v["m_água"] * 1000,
                    VariavelResultado = "S", UnidadeResultado = "PSU (‰)"
                },
                new Formula
                {
                    Id = "C4302", Nome = "Pressão Hidrostática Oceânica",
                    Categoria = "Oceanografia", SubCategoria = "Física Marinha",
                    Expressao = "P = ρ × g × h",
                    Descricao = "Pressão exercida pela coluna de água sobre um objeto a profundidade h.",
                    Criador = "Pascal B", AnoOrigin = "1653",
                    ReferenciaBibliografica = "Talley L et al. Descriptive Physical Oceanography, 6ª ed. 2011.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Densidade da água do mar (ρ)", Simbolo = "ρ", Unidade = "kg/m³", ValorPadrao = 1025 },
                        new Variavel { Nome = "Aceleração gravitacional (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 },
                        new Variavel { Nome = "Profundidade (h)", Simbolo = "h", Unidade = "m", ValorPadrao = 1000 }
                    },
                    Calcular = v => v["ρ"] * v["g"] * v["h"],
                    VariavelResultado = "P", UnidadeResultado = "Pa"
                },
                new Formula
                {
                    Id = "C4303", Nome = "Velocidade do Som na Água do Mar (Mackenzie)",
                    Categoria = "Oceanografia", SubCategoria = "Acústica Submarina",
                    Expressao = "c = 1448,96 + 4,591T − 5,304×10⁻²T² + 2,374×10⁻⁴T³ + 1,340(S−35) + 1,630×10⁻²D + 1,675×10⁻⁷D²",
                    Descricao = "Equação empírica de Mackenzie para velocidade do som dependente de temperatura, salinidade e profundidade.",
                    Criador = "Mackenzie KV", AnoOrigin = "1981",
                    ReferenciaBibliografica = "Mackenzie KV. J Acoust Soc Am, 1981.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura (T)", Simbolo = "T", Unidade = "°C", ValorPadrao = 15 },
                        new Variavel { Nome = "Salinidade (S)", Simbolo = "S", Unidade = "PSU", ValorPadrao = 35 },
                        new Variavel { Nome = "Profundidade (D)", Simbolo = "D", Unidade = "m", ValorPadrao = 100 }
                    },
                    Calcular = v => {
                        double T = v["T"]; double S = v["S"]; double D = v["D"];
                        return 1448.96 + 4.591*T - 5.304e-2*T*T + 2.374e-4*T*T*T + 1.340*(S-35) + 1.630e-2*D + 1.675e-7*D*D;
                    },
                    VariavelResultado = "c", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C4304", Nome = "Frequência de Brunt-Väisälä",
                    Categoria = "Oceanografia", SubCategoria = "Oceanografia Física",
                    Expressao = "N² = -(g / ρ) × (dρ / dz)",
                    Descricao = "Frequência de oscilação de partícula de fluido em torno de posição de equilíbrio; indica estabilidade da coluna d'água.",
                    Criador = "Brunt D / Väisälä V", AnoOrigin = "1927",
                    ReferenciaBibliografica = "Pedlosky J. Geophysical Fluid Dynamics, 2ª ed. 1987.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Gravidade (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 },
                        new Variavel { Nome = "Densidade local (ρ)", Simbolo = "ρ", Unidade = "kg/m³", ValorPadrao = 1025, ValorMin = 1 },
                        new Variavel { Nome = "Gradiente de densidade (dρ/dz)", Simbolo = "drho_dz", Unidade = "kg/m⁴", ValorPadrao = -0.1 }
                    },
                    Calcular = v => -(v["g"] / v["ρ"]) * v["drho_dz"],
                    VariavelResultado = "N²", UnidadeResultado = "rad²/s²"
                },
                new Formula
                {
                    Id = "C4305", Nome = "Transporte de Ekman",
                    Categoria = "Oceanografia", SubCategoria = "Dinâmica Oceânica",
                    Expressao = "Me = τ / (ρ × f)",
                    Descricao = "Volume de água transportada perpendicularmente ao vento por efeito da força de Coriolis (camada de Ekman).",
                    Criador = "Ekman VW", AnoOrigin = "1905",
                    ReferenciaBibliografica = "Ekman VW. Arkiv Mat Astron Fysik, 1905.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tensão de cisalhamento do vento (τ)", Simbolo = "τ", Unidade = "N/m²", ValorPadrao = 0.1 },
                        new Variavel { Nome = "Densidade da água (ρ)", Simbolo = "ρ", Unidade = "kg/m³", ValorPadrao = 1025 },
                        new Variavel { Nome = "Parâmetro de Coriolis (f)", Simbolo = "f", Unidade = "rad/s", ValorPadrao = 1e-4, ValorMin = 1e-8 }
                    },
                    Calcular = v => v["τ"] / (v["ρ"] * v["f"]),
                    VariavelResultado = "Me", UnidadeResultado = "m²/s"
                },
                new Formula
                {
                    Id = "C4306", Nome = "Número de Rossby",
                    Categoria = "Oceanografia", SubCategoria = "Dinâmica Oceânica",
                    Expressao = "Ro = U / (f × L)",
                    Descricao = "Razão entre forças inerciais e força de Coriolis; indica importância da rotação terrestre no escoamento.",
                    Criador = "Rossby CG", AnoOrigin = "1939",
                    ReferenciaBibliografica = "Pedlosky J. Geophysical Fluid Dynamics, 2ª ed. 1987.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade característica (U)", Simbolo = "U", Unidade = "m/s", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Parâmetro de Coriolis (f)", Simbolo = "f", Unidade = "rad/s", ValorPadrao = 1e-4, ValorMin = 1e-10 },
                        new Variavel { Nome = "Escala de comprimento (L)", Simbolo = "L", Unidade = "m", ValorPadrao = 100000, ValorMin = 1 }
                    },
                    Calcular = v => v["U"] / (v["f"] * v["L"]),
                    VariavelResultado = "Ro", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C4307", Nome = "Energia de Onda Oceânica",
                    Categoria = "Oceanografia", SubCategoria = "Oceanografia Física",
                    Expressao = "E = (1/8) × ρ × g × H²",
                    Descricao = "Energia por unidade de área superficial de uma onda de gravidade; proporcional ao quadrado da altura de onda.",
                    Criador = "Stokes GG", AnoOrigin = "1847",
                    ReferenciaBibliografica = "Holthuijsen LH. Waves in Oceanic and Coastal Waters. Cambridge, 2007.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Densidade da água (ρ)", Simbolo = "ρ", Unidade = "kg/m³", ValorPadrao = 1025 },
                        new Variavel { Nome = "Gravidade (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 },
                        new Variavel { Nome = "Altura significativa de onda (H)", Simbolo = "H", Unidade = "m", ValorPadrao = 2 }
                    },
                    Calcular = v => 0.125 * v["ρ"] * v["g"] * v["H"] * v["H"],
                    VariavelResultado = "E", UnidadeResultado = "J/m²"
                },
                new Formula
                {
                    Id = "C4308", Nome = "Velocidade de Fase de Onda (Águas Profundas)",
                    Categoria = "Oceanografia", SubCategoria = "Oceanografia Física",
                    Expressao = "c = sqrt(g × λ / (2π))",
                    Descricao = "Velocidade de propagação de onda de gravidade em águas profundas (profundidade > λ/2).",
                    Criador = "Airy GB", AnoOrigin = "1841",
                    ReferenciaBibliografica = "Kundu PK et al. Fluid Mechanics, 6ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Gravidade (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 },
                        new Variavel { Nome = "Comprimento de onda (λ)", Simbolo = "λ", Unidade = "m", ValorPadrao = 100, ValorMin = 0.001 }
                    },
                    Calcular = v => Math.Sqrt(v["g"] * v["λ"] / (2 * Math.PI)),
                    VariavelResultado = "c", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C4309", Nome = "Fluxo de Massa de Água (Corrente)",
                    Categoria = "Oceanografia", SubCategoria = "Oceanografia Física",
                    Expressao = "Q = A × v",
                    Descricao = "Transporte volumétrico de água por uma seção transversal do oceano (em Sverdrups: 1 Sv = 10⁶ m³/s).",
                    Criador = "Prática oceanográfica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Talley L et al. Descriptive Physical Oceanography, 6ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Área da seção (A)", Simbolo = "A", Unidade = "m²", ValorPadrao = 1000000 },
                        new Variavel { Nome = "Velocidade média (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 0.1 }
                    },
                    Calcular = v => v["A"] * v["v"],
                    VariavelResultado = "Q", UnidadeResultado = "m³/s"
                },
                new Formula
                {
                    Id = "C4310", Nome = "Saturação de Oxigênio Dissolvido",
                    Categoria = "Oceanografia", SubCategoria = "Química Marinha",
                    Expressao = "OD_sat ≈ 14,62 − 0,3898T + 0,006969T² − 5,696×10⁻⁵T³",
                    Descricao = "Concentração de saturação de oxigênio dissolvido na água do mar em função da temperatura (Benson & Krause).",
                    Criador = "Benson BB, Krause D", AnoOrigin = "1984",
                    ReferenciaBibliografica = "Benson BB, Krause D. Limnol Oceanogr, 1984.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura (T)", Simbolo = "T", Unidade = "°C", ValorPadrao = 20, ValorMin = 0, ValorMax = 40 }
                    },
                    Calcular = v => { double T = v["T"]; return 14.62 - 0.3898*T + 0.006969*T*T - 5.696e-5*T*T*T; },
                    VariavelResultado = "OD_sat", UnidadeResultado = "mg/L"
                },
                new Formula
                {
                    Id = "C4311", Nome = "Estado de Saturação do Carbonato (Ω)",
                    Categoria = "Oceanografia", SubCategoria = "Química Marinha",
                    Expressao = "Ω = [Ca²⁺] × [CO₃²⁻] / Ksp",
                    Descricao = "Grau de saturação da água do mar em relação ao carbonato de cálcio; Ω>1 favorece precipitação.",
                    Criador = "Mucci A", AnoOrigin = "1983",
                    ReferenciaBibliografica = "Mucci A. Am J Sci, 1983.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "[Ca²⁺]", Simbolo = "Ca", Unidade = "mol/kg", ValorPadrao = 0.01025 },
                        new Variavel { Nome = "[CO₃²⁻]", Simbolo = "CO3", Unidade = "mol/kg", ValorPadrao = 0.000240 },
                        new Variavel { Nome = "Produto de solubilidade (Ksp)", Simbolo = "Ksp", Unidade = "mol²/kg²", ValorPadrao = 4.27e-7, ValorMin = 1e-20 }
                    },
                    Calcular = v => v["Ca"] * v["CO3"] / v["Ksp"],
                    VariavelResultado = "Ω", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C4312", Nome = "Eficiência de Transferência Trófica",
                    Categoria = "Oceanografia", SubCategoria = "Ecologia Marinha",
                    Expressao = "E = P_n+1 / P_n × 100",
                    Descricao = "Percentagem de produção de biomassa transferida de um nível trófico ao seguinte (tipicamente 10%).",
                    Criador = "Lindeman RL", AnoOrigin = "1942",
                    ReferenciaBibliografica = "Lindeman RL. Ecology, 1942.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Produção nível n+1", Simbolo = "P_n1", Unidade = "gC/m²/ano", ValorPadrao = 10 },
                        new Variavel { Nome = "Produção nível n", Simbolo = "P_n", Unidade = "gC/m²/ano", ValorPadrao = 100, ValorMin = 0.001 }
                    },
                    Calcular = v => v["P_n1"] / v["P_n"] * 100,
                    VariavelResultado = "E", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C4313", Nome = "Produção Primária Líquida (Equação de Steele)",
                    Categoria = "Oceanografia", SubCategoria = "Oceanografia Biológica",
                    Expressao = "P = Pmax × (I/Iopt) × exp(1 - I/Iopt)",
                    Descricao = "Modelo de saturação de luz para fotossíntese fitoplanctônica com fotoinibição.",
                    Criador = "Steele JH", AnoOrigin = "1962",
                    ReferenciaBibliografica = "Steele JH. Limnol Oceanogr, 1962.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Produção máxima (Pmax)", Simbolo = "Pmax", Unidade = "mgC/m³/h", ValorPadrao = 10 },
                        new Variavel { Nome = "Irradiância (I)", Simbolo = "I", Unidade = "µE/m²/s", ValorPadrao = 200 },
                        new Variavel { Nome = "Irradiância ótima (Iopt)", Simbolo = "Iopt", Unidade = "µE/m²/s", ValorPadrao = 300, ValorMin = 1 }
                    },
                    Calcular = v => v["Pmax"] * (v["I"] / v["Iopt"]) * Math.Exp(1 - v["I"] / v["Iopt"]),
                    VariavelResultado = "P", UnidadeResultado = "mgC/m³/h"
                },
                new Formula
                {
                    Id = "C4314", Nome = "Corrente Geostrópica",
                    Categoria = "Oceanografia", SubCategoria = "Dinâmica Oceânica",
                    Expressao = "U = -(g / f) × (∂η / ∂y)",
                    Descricao = "Velocidade de corrente oceânica em equilíbrio entre gradiente de pressão e força de Coriolis.",
                    Criador = "Bjerknes V / Sandström JW", AnoOrigin = "1902",
                    ReferenciaBibliografica = "Pedlosky J. Geophysical Fluid Dynamics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Gravidade (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 },
                        new Variavel { Nome = "Parâmetro de Coriolis (f)", Simbolo = "f", Unidade = "rad/s", ValorPadrao = 1e-4, ValorMin = 1e-10 },
                        new Variavel { Nome = "Gradiente de elevação (∂η/∂y)", Simbolo = "dη_dy", Unidade = "m/m", ValorPadrao = 1e-6 }
                    },
                    Calcular = v => -(v["g"] / v["f"]) * v["dη_dy"],
                    VariavelResultado = "U", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C4315", Nome = "Extinção de Luz na Água (Lei de Beer)",
                    Categoria = "Oceanografia", SubCategoria = "Óptica Marinha",
                    Expressao = "I(z) = I0 × e^(-kd × z)",
                    Descricao = "Intensidade de luz em profundidade z; kd é o coeficiente de atenuação difusa.",
                    Criador = "Beer A", AnoOrigin = "1852",
                    ReferenciaBibliografica = "Kirk JTO. Light and Photosynthesis in Aquatic Ecosystems, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Irradiância superficial (I0)", Simbolo = "I0", Unidade = "W/m²", ValorPadrao = 400 },
                        new Variavel { Nome = "Coeficiente de atenuação (kd)", Simbolo = "kd", Unidade = "m⁻¹", ValorPadrao = 0.1, ValorMin = 0.001 },
                        new Variavel { Nome = "Profundidade (z)", Simbolo = "z", Unidade = "m", ValorPadrao = 10 }
                    },
                    Calcular = v => v["I0"] * Math.Exp(-v["kd"] * v["z"]),
                    VariavelResultado = "I(z)", UnidadeResultado = "W/m²"
                },
                new Formula
                {
                    Id = "C4316", Nome = "Batimetria — Fórmula de Young",
                    Categoria = "Oceanografia", SubCategoria = "Geomorfologia Marinha",
                    Expressao = "Hmax ≈ 0,283 × U² × F^(1/2) / g^(1/2)",
                    Descricao = "Estimativa de altura máxima de onda pelo comprimento de pista (fetch) e velocidade do vento.",
                    Criador = "Young IR", AnoOrigin = "1988",
                    ReferenciaBibliografica = "Young IR. Ocean Engineering, 1988.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade do vento (U)", Simbolo = "U", Unidade = "m/s", ValorPadrao = 10 },
                        new Variavel { Nome = "Comprimento de pista (F)", Simbolo = "F", Unidade = "m", ValorPadrao = 100000 },
                        new Variavel { Nome = "Gravidade (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 }
                    },
                    Calcular = v => 0.283 * v["U"] * v["U"] * Math.Sqrt(v["F"]) / Math.Sqrt(v["g"]),
                    VariavelResultado = "Hmax", UnidadeResultado = "m"
                },
                new Formula
                {
                    Id = "C4317", Nome = "Clorofila e Produção Fitoplanctônica (VGPM)",
                    Categoria = "Oceanografia", SubCategoria = "Oceanografia Biológica",
                    Expressao = "PP = Chl × PBopt × E0 × DL × Dirr",
                    Descricao = "Modelo de produção primária vertically generalized (VGPM) baseado em clorofila superficial.",
                    Criador = "Behrenfeld MJ, Falkowski PG", AnoOrigin = "1997",
                    ReferenciaBibliografica = "Behrenfeld MJ, Falkowski PG. Limnol Oceanogr, 1997.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Clorofila superficial (Chl)", Simbolo = "Chl", Unidade = "mg/m³", ValorPadrao = 1 },
                        new Variavel { Nome = "Taxa de assimilação máxima (PBopt)", Simbolo = "PBopt", Unidade = "mgC/(mgChl·h)", ValorPadrao = 4 },
                        new Variavel { Nome = "Irradiância (E0)", Simbolo = "E0", Unidade = "Ein/m²/d", ValorPadrao = 20 },
                        new Variavel { Nome = "Comprimento do dia (DL)", Simbolo = "DL", Unidade = "h", ValorPadrao = 12 },
                        new Variavel { Nome = "Fator de irradiância (Dirr)", Simbolo = "Dirr", Unidade = "", ValorPadrao = 0.66 }
                    },
                    Calcular = v => v["Chl"] * v["PBopt"] * v["E0"] * v["DL"] * v["Dirr"],
                    VariavelResultado = "PP", UnidadeResultado = "mgC/m²/d"
                },
                new Formula
                {
                    Id = "C4318", Nome = "Altura de Maré (Análise Harmônica — Componente M2)",
                    Categoria = "Oceanografia", SubCategoria = "Marés",
                    Expressao = "η(t) = A × cos(ω × t + φ)",
                    Descricao = "Componente harmônica de maré semi-diurna lunar M2 (período ≈ 12,42 h); base da previsão de marés.",
                    Criador = "Kelvin (Lord)", AnoOrigin = "1867",
                    ReferenciaBibliografica = "Pugh DT. Tides, Surges and Mean Sea-Level. Wiley, 1987.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Amplitude (A)", Simbolo = "A", Unidade = "m", ValorPadrao = 1 },
                        new Variavel { Nome = "Frequência angular (ω = 2π/T)", Simbolo = "ω", Unidade = "rad/h", ValorPadrao = 0.5059 },
                        new Variavel { Nome = "Tempo (t)", Simbolo = "t", Unidade = "h", ValorPadrao = 6 },
                        new Variavel { Nome = "Fase inicial (φ)", Simbolo = "φ", Unidade = "rad", ValorPadrao = 0 }
                    },
                    Calcular = v => v["A"] * Math.Cos(v["ω"] * v["t"] + v["φ"]),
                    VariavelResultado = "η", UnidadeResultado = "m"
                },
                new Formula
                {
                    Id = "C4319", Nome = "Número de Richardson (Estabilidade Oceânica)",
                    Categoria = "Oceanografia", SubCategoria = "Oceanografia Física",
                    Expressao = "Ri = N² / (du/dz)²",
                    Descricao = "Razão entre forças de estratificação e forças de cisalhamento; Ri < 0,25 indica instabilidade turbulenta.",
                    Criador = "Richardson LF", AnoOrigin = "1920",
                    ReferenciaBibliografica = "Richardson LF. Proc R Soc London A, 1920.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência de Brunt-Väisälä² (N²)", Simbolo = "N2", Unidade = "rad²/s²", ValorPadrao = 1e-4 },
                        new Variavel { Nome = "Gradiente de velocidade (du/dz)", Simbolo = "dudz", Unidade = "s⁻¹", ValorPadrao = 0.01, ValorMin = 1e-10 }
                    },
                    Calcular = v => v["N2"] / (v["dudz"] * v["dudz"]),
                    VariavelResultado = "Ri", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C4320", Nome = "Temperatura Potencial Oceânica",
                    Categoria = "Oceanografia", SubCategoria = "Termodinâmica Marinha",
                    Expressao = "θ ≈ T − (g/cp) × z",
                    Descricao = "Temperatura que teria a parcela d'água se deslocada adiabaticamente à superfície; remove efeito da compressão.",
                    Criador = "Helland-Hansen B", AnoOrigin = "1912",
                    ReferenciaBibliografica = "Talley L et al. Descriptive Physical Oceanography, 6ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura in-situ (T)", Simbolo = "T", Unidade = "°C", ValorPadrao = 4 },
                        new Variavel { Nome = "Gravidade (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 },
                        new Variavel { Nome = "Calor específico (cp)", Simbolo = "cp", Unidade = "J/(kg·K)", ValorPadrao = 3990 },
                        new Variavel { Nome = "Profundidade (z)", Simbolo = "z", Unidade = "m", ValorPadrao = 1000 }
                    },
                    Calcular = v => v["T"] - (v["g"] / v["cp"]) * v["z"],
                    VariavelResultado = "θ", UnidadeResultado = "°C"
                },
                new Formula
                {
                    Id = "C4321", Nome = "Fluxo de Calor Oceano-Atmosfera",
                    Categoria = "Oceanografia", SubCategoria = "Clima Marinho",
                    Expressao = "Q = ρ × cp × CH × U × (SST − Ta)",
                    Descricao = "Fluxo de calor sensível da superfície oceânica para a atmosfera via fórmulas de transferência em massa.",
                    Criador = "Fairall CW et al.", AnoOrigin = "1996",
                    ReferenciaBibliografica = "Fairall CW et al. J Geophys Res, 1996.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Densidade do ar (ρ)", Simbolo = "ρ", Unidade = "kg/m³", ValorPadrao = 1.25 },
                        new Variavel { Nome = "Calor específico do ar (cp)", Simbolo = "cp", Unidade = "J/(kg·K)", ValorPadrao = 1005 },
                        new Variavel { Nome = "Coeficiente de transferência (CH)", Simbolo = "CH", Unidade = "", ValorPadrao = 1.3e-3 },
                        new Variavel { Nome = "Velocidade do vento (U)", Simbolo = "U", Unidade = "m/s", ValorPadrao = 7 },
                        new Variavel { Nome = "SST − Temperatura do ar (ΔT)", Simbolo = "ΔT", Unidade = "K", ValorPadrao = 2 }
                    },
                    Calcular = v => v["ρ"] * v["cp"] * v["CH"] * v["U"] * v["ΔT"],
                    VariavelResultado = "Q", UnidadeResultado = "W/m²"
                },
                new Formula
                {
                    Id = "C4322", Nome = "Zona Eufótica (Profundidade de Secchi)",
                    Categoria = "Oceanografia", SubCategoria = "Óptica Marinha",
                    Expressao = "Zeu ≈ 2,5 × Zs",
                    Descricao = "Profundidade da zona eufótica estimada a partir da profundidade de Secchi; relação empírica.",
                    Criador = "Poole HH, Atkins WRG", AnoOrigin = "1929",
                    ReferenciaBibliografica = "Kirk JTO. Light and Photosynthesis in Aquatic Ecosystems, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Profundidade de Secchi (Zs)", Simbolo = "Zs", Unidade = "m", ValorPadrao = 10 }
                    },
                    Calcular = v => 2.5 * v["Zs"],
                    VariavelResultado = "Zeu", UnidadeResultado = "m"
                },
                new Formula
                {
                    Id = "C4323", Nome = "Upwelling — Velocidade Vertical de Ekman",
                    Categoria = "Oceanografia", SubCategoria = "Dinâmica Oceânica",
                    Expressao = "w_E = curl(τ) / (ρ × f)",
                    Descricao = "Velocidade vertical de ascensão/subsidência oceânica induzida pelo rotacional do estresse do vento.",
                    Criador = "Ekman VW", AnoOrigin = "1905",
                    ReferenciaBibliografica = "Pedlosky J. Geophysical Fluid Dynamics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Rotacional do estresse do vento (curl τ)", Simbolo = "curl_tau", Unidade = "N/m³", ValorPadrao = 1e-7 },
                        new Variavel { Nome = "Densidade da água (ρ)", Simbolo = "ρ", Unidade = "kg/m³", ValorPadrao = 1025 },
                        new Variavel { Nome = "Parâmetro de Coriolis (f)", Simbolo = "f", Unidade = "rad/s", ValorPadrao = 1e-4, ValorMin = 1e-10 }
                    },
                    Calcular = v => v["curl_tau"] / (v["ρ"] * v["f"]),
                    VariavelResultado = "w_E", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C4324", Nome = "Lei de Stokes (Sedimentação de Partículas Marinhas)",
                    Categoria = "Oceanografia", SubCategoria = "Geologia Marinha",
                    Expressao = "vs = (2/9) × r² × (ρp − ρf) × g / η",
                    Descricao = "Velocidade de sedimentação de partícula esférica em fluido viscoso; governa deposição de sedimentos marinhos.",
                    Criador = "Stokes GG", AnoOrigin = "1851",
                    ReferenciaBibliografica = "Stokes GG. Trans Camb Phil Soc, 1851.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Raio da partícula (r)", Simbolo = "r", Unidade = "m", ValorPadrao = 1e-5 },
                        new Variavel { Nome = "Densidade da partícula (ρp)", Simbolo = "ρp", Unidade = "kg/m³", ValorPadrao = 2650 },
                        new Variavel { Nome = "Densidade do fluido (ρf)", Simbolo = "ρf", Unidade = "kg/m³", ValorPadrao = 1025 },
                        new Variavel { Nome = "Gravidade (g)", Simbolo = "g", Unidade = "m/s²", ValorPadrao = 9.81 },
                        new Variavel { Nome = "Viscosidade dinâmica (η)", Simbolo = "η", Unidade = "Pa·s", ValorPadrao = 0.001, ValorMin = 1e-10 }
                    },
                    Calcular = v => (2.0/9) * v["r"]*v["r"] * (v["ρp"] - v["ρf"]) * v["g"] / v["η"],
                    VariavelResultado = "vs", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C4325", Nome = "Índice de Oscilação El Niño (ONI)",
                    Categoria = "Oceanografia", SubCategoria = "Clima Marinho",
                    Expressao = "ONI = SST_media_Niño3.4 − SST_climatologia",
                    Descricao = "Anomalia de temperatura da superfície do mar na região Niño 3.4; define eventos de El Niño/La Niña.",
                    Criador = "NOAA/CPC", AnoOrigin = "1990",
                    ReferenciaBibliografica = "Trenberth KE. Bull Am Meteorol Soc, 1997.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "SST média (Niño 3.4)", Simbolo = "SST_media", Unidade = "°C", ValorPadrao = 27.5 },
                        new Variavel { Nome = "SST climatologia (média 30 anos)", Simbolo = "SST_clim", Unidade = "°C", ValorPadrao = 26.5 }
                    },
                    Calcular = v => v["SST_media"] - v["SST_clim"],
                    VariavelResultado = "ONI", UnidadeResultado = "°C"
                }
            });
        }
    }
}
