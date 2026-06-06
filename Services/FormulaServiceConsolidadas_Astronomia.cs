using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Astronomia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C3601", Nome = "Lei de Hubble-Lemaître",
                    Categoria = "Astronomia", SubCategoria = "Cosmologia",
                    Expressao = "v = H0 × d",
                    Descricao = "Velocidade de recessão de galáxia proporcional à distância; evidência da expansão do universo.",
                    Criador = "Lemaître G / Hubble E", AnoOrigin = "1927 / 1929",
                    ReferenciaBibliografica = "Hubble E. Proc Natl Acad Sci, 1929.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de Hubble (H0)", Simbolo = "H0", Unidade = "km/s/Mpc", ValorPadrao = 67.4 },
                        new Variavel { Nome = "Distância (d)", Simbolo = "d", Unidade = "Mpc", ValorPadrao = 100 }
                    },
                    Calcular = v => v["H0"] * v["d"],
                    VariavelResultado = "v", UnidadeResultado = "km/s"
                },
                new Formula
                {
                    Id = "C3602", Nome = "Terceira Lei de Kepler",
                    Categoria = "Astronomia", SubCategoria = "Mecânica Celeste",
                    Expressao = "T = 2π × sqrt(a³ / GM)",
                    Descricao = "Período orbital proporcional ao semieixo maior à potência 3/2; fundamento da mecânica orbital.",
                    Criador = "Kepler J", AnoOrigin = "1619",
                    ReferenciaBibliografica = "Kepler J. Harmonices Mundi, 1619.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa central (M)", Simbolo = "M", Unidade = "kg", ValorPadrao = 1.989e30, ValorMin = 1 },
                        new Variavel { Nome = "Semieixo maior (a)", Simbolo = "a", Unidade = "m", ValorPadrao = 1.496e11, ValorMin = 1 }
                    },
                    Calcular = v => 2 * Math.PI * Math.Sqrt(Math.Pow(v["a"], 3) / (6.674e-11 * v["M"])),
                    VariavelResultado = "T", UnidadeResultado = "s"
                },
                new Formula
                {
                    Id = "C3603", Nome = "Luminosidade Estelar (Stefan-Boltzmann)",
                    Categoria = "Astronomia", SubCategoria = "Astrofísica Estelar",
                    Expressao = "L = 4π × R² × σ × T⁴",
                    Descricao = "Potência total irradiada por estrela modelada como corpo negro; depende de raio e temperatura efetiva.",
                    Criador = "Stefan J / Boltzmann L", AnoOrigin = "1879 / 1884",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Raio estelar (R)", Simbolo = "R", Unidade = "m", ValorPadrao = 6.96e8 },
                        new Variavel { Nome = "Temperatura efetiva (T)", Simbolo = "T", Unidade = "K", ValorPadrao = 5778, ValorMin = 1 }
                    },
                    Calcular = v => 4 * Math.PI * v["R"]*v["R"] * 5.670374419e-8 * Math.Pow(v["T"], 4),
                    VariavelResultado = "L", UnidadeResultado = "W"
                },
                new Formula
                {
                    Id = "C3604", Nome = "Módulo de Distância",
                    Categoria = "Astronomia", SubCategoria = "Astrometria",
                    Expressao = "μ = 5 × log10(d / 10 pc)",
                    Descricao = "Diferença entre magnitude aparente e absoluta; permite calcular distância de objetos celestes.",
                    Criador = "Pogson N", AnoOrigin = "1856",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Distância (d)", Simbolo = "d", Unidade = "pc", ValorPadrao = 100, ValorMin = 0.001 }
                    },
                    Calcular = v => 5 * Math.Log10(v["d"] / 10.0),
                    VariavelResultado = "μ", UnidadeResultado = "mag"
                },
                new Formula
                {
                    Id = "C3605", Nome = "Velocidade de Escape",
                    Categoria = "Astronomia", SubCategoria = "Mecânica Celeste",
                    Expressao = "ve = sqrt(2GM / R)",
                    Descricao = "Velocidade mínima para que um objeto escape do campo gravitacional de um corpo celeste.",
                    Criador = "Newton I (derivado)", AnoOrigin = "1687",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa do corpo (M)", Simbolo = "M", Unidade = "kg", ValorPadrao = 5.972e24, ValorMin = 1 },
                        new Variavel { Nome = "Raio do corpo (R)", Simbolo = "R", Unidade = "m", ValorPadrao = 6.371e6, ValorMin = 1 }
                    },
                    Calcular = v => Math.Sqrt(2 * 6.674e-11 * v["M"] / v["R"]),
                    VariavelResultado = "ve", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C3606", Nome = "Raio de Schwarzschild",
                    Categoria = "Astronomia", SubCategoria = "Relatividade / Buracos Negros",
                    Expressao = "rs = 2GM / c²",
                    Descricao = "Raio do horizonte de eventos de um buraco negro de Schwarzschild (não rotativo, sem carga).",
                    Criador = "Schwarzschild K", AnoOrigin = "1916",
                    ReferenciaBibliografica = "Schwarzschild K. Sitzungsber Preuss Akad Wiss, 1916.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa do objeto (M)", Simbolo = "M", Unidade = "kg", ValorPadrao = 1.989e30, ValorMin = 1 }
                    },
                    Calcular = v => 2 * 6.674e-11 * v["M"] / (2.998e8 * 2.998e8),
                    VariavelResultado = "rs", UnidadeResultado = "m"
                },
                new Formula
                {
                    Id = "C3607", Nome = "Paralaxe Estelar",
                    Categoria = "Astronomia", SubCategoria = "Astrometria",
                    Expressao = "d = 1 / p",
                    Descricao = "Distância em parsecs é o inverso do ângulo de paralaxe em arco-segundos.",
                    Criador = "Bessel FW", AnoOrigin = "1838",
                    ReferenciaBibliografica = "Bessel FW. Astron Nachr, 1838.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Paralaxe (p)", Simbolo = "p", Unidade = "arco-s", ValorPadrao = 0.1, ValorMin = 1e-6 }
                    },
                    Calcular = v => 1.0 / v["p"],
                    VariavelResultado = "d", UnidadeResultado = "pc"
                },
                new Formula
                {
                    Id = "C3608", Nome = "Desvio para o Vermelho Cosmológico",
                    Categoria = "Astronomia", SubCategoria = "Cosmologia",
                    Expressao = "z = (λobs − λem) / λem",
                    Descricao = "Desvio espectral para o vermelho causado pela expansão do universo ou movimento de recessão.",
                    Criador = "Slipher VM / Hubble E", AnoOrigin = "1913 / 1929",
                    ReferenciaBibliografica = "Ryden B. Introduction to Cosmology, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Comprimento de onda observado (λobs)", Simbolo = "λobs", Unidade = "nm", ValorPadrao = 660 },
                        new Variavel { Nome = "Comprimento de onda emitido (λem)", Simbolo = "λem", Unidade = "nm", ValorPadrao = 656, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["λobs"] - v["λem"]) / v["λem"],
                    VariavelResultado = "z", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C3609", Nome = "Lei do Deslocamento de Wien",
                    Categoria = "Astronomia", SubCategoria = "Astrofísica",
                    Expressao = "λmax = b / T",
                    Descricao = "Comprimento de onda de emissão máxima de corpo negro; permite estimar temperatura estelar pelo espectro.",
                    Criador = "Wien W", AnoOrigin = "1893",
                    ReferenciaBibliografica = "Wien W. Ann Phys, 1893.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura (T)", Simbolo = "T", Unidade = "K", ValorPadrao = 5778, ValorMin = 1 }
                    },
                    Calcular = v => 2.897771955e-3 / v["T"],
                    VariavelResultado = "λmax", UnidadeResultado = "m"
                },
                new Formula
                {
                    Id = "C3610", Nome = "Tempo de Vida na Sequência Principal",
                    Categoria = "Astronomia", SubCategoria = "Evolução Estelar",
                    Expressao = "tMS ≈ t☉ × (M/M☉) / (L/L☉)",
                    Descricao = "Estimativa do tempo de queima de hidrogênio proporcional à massa e inversamente à luminosidade.",
                    Criador = "Prática astrofísica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa em M☉", Simbolo = "M_Msun", Unidade = "M☉", ValorPadrao = 1 },
                        new Variavel { Nome = "Luminosidade em L☉", Simbolo = "L_Lsun", Unidade = "L☉", ValorPadrao = 1, ValorMin = 1e-10 },
                        new Variavel { Nome = "Vida do Sol (t☉)", Simbolo = "t_sun", Unidade = "Ga", ValorPadrao = 10 }
                    },
                    Calcular = v => v["t_sun"] * v["M_Msun"] / v["L_Lsun"],
                    VariavelResultado = "tMS", UnidadeResultado = "Ga"
                },
                new Formula
                {
                    Id = "C3611", Nome = "Velocidade Orbital Circular",
                    Categoria = "Astronomia", SubCategoria = "Mecânica Celeste",
                    Expressao = "v = sqrt(GM / r)",
                    Descricao = "Velocidade de corpo em órbita circular; equilíbrio entre gravidade e força centrípeta.",
                    Criador = "Newton I", AnoOrigin = "1687",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa central (M)", Simbolo = "M", Unidade = "kg", ValorPadrao = 1.989e30, ValorMin = 1 },
                        new Variavel { Nome = "Raio orbital (r)", Simbolo = "r", Unidade = "m", ValorPadrao = 1.496e11, ValorMin = 1 }
                    },
                    Calcular = v => Math.Sqrt(6.674e-11 * v["M"] / v["r"]),
                    VariavelResultado = "v", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C3612", Nome = "Limite de Roche",
                    Categoria = "Astronomia", SubCategoria = "Mecânica Celeste",
                    Expressao = "d = 2,44 × R × (M/m)^(1/3)",
                    Descricao = "Distância mínima à qual satélite líquido pode existir sem ser destruído pelas forças de maré.",
                    Criador = "Roche EÀ", AnoOrigin = "1848",
                    ReferenciaBibliografica = "Roche EÀ. Ann de l'Obs de Paris, 1848.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Raio do primário (R)", Simbolo = "R", Unidade = "m", ValorPadrao = 7.15e7 },
                        new Variavel { Nome = "Massa do primário (M)", Simbolo = "M", Unidade = "kg", ValorPadrao = 1.898e27, ValorMin = 1 },
                        new Variavel { Nome = "Massa do satélite (m)", Simbolo = "m", Unidade = "kg", ValorPadrao = 7.342e22, ValorMin = 1 }
                    },
                    Calcular = v => 2.44 * v["R"] * Math.Pow(v["M"] / v["m"], 1.0/3),
                    VariavelResultado = "d_Roche", UnidadeResultado = "m"
                },
                new Formula
                {
                    Id = "C3613", Nome = "Magnitude Absoluta de Estrela",
                    Categoria = "Astronomia", SubCategoria = "Fotometria",
                    Expressao = "M = m − 5 × log10(d) + 5",
                    Descricao = "Brilho intrínseco que a estrela teria a 10 parsecs; descontado efeito da distância.",
                    Criador = "Pogson N", AnoOrigin = "1856",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Magnitude aparente (m)", Simbolo = "m", Unidade = "mag", ValorPadrao = 5 },
                        new Variavel { Nome = "Distância (d)", Simbolo = "d", Unidade = "pc", ValorPadrao = 100, ValorMin = 0.001 }
                    },
                    Calcular = v => v["m"] - 5 * Math.Log10(v["d"]) + 5,
                    VariavelResultado = "M", UnidadeResultado = "mag"
                },
                new Formula
                {
                    Id = "C3614", Nome = "Lei de Bode-Titius",
                    Categoria = "Astronomia", SubCategoria = "Mecânica Celeste",
                    Expressao = "a_n = 0,4 + 0,3 × 2^n (UA)",
                    Descricao = "Sequência empírica que aproxima as distâncias planetárias ao Sol.",
                    Criador = "Titius JD / Bode JE", AnoOrigin = "1766 / 1772",
                    ReferenciaBibliografica = "Nieto MM. The Titius-Bode Law of Planetary Distances. Pergamon, 1972.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Índice n (0=Vénus, 1=Terra...)", Simbolo = "n", Unidade = "", ValorPadrao = 0 }
                    },
                    Calcular = v => 0.4 + 0.3 * Math.Pow(2, v["n"]),
                    VariavelResultado = "a_n", UnidadeResultado = "UA"
                },
                new Formula
                {
                    Id = "C3615", Nome = "Energia de Ligação Gravitacional",
                    Categoria = "Astronomia", SubCategoria = "Astrofísica",
                    Expressao = "U = -(3/5) × G × M² / R",
                    Descricao = "Energia potencial gravitacional de esfera homogênea de massa M e raio R.",
                    Criador = "Newton I (derivado)", AnoOrigin = "1687",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa (M)", Simbolo = "M", Unidade = "kg", ValorPadrao = 1.989e30, ValorMin = 1 },
                        new Variavel { Nome = "Raio (R)", Simbolo = "R", Unidade = "m", ValorPadrao = 6.96e8, ValorMin = 1 }
                    },
                    Calcular = v => -(3.0/5) * 6.674e-11 * v["M"]*v["M"] / v["R"],
                    VariavelResultado = "U", UnidadeResultado = "J"
                },
                new Formula
                {
                    Id = "C3616", Nome = "Massa por Curva de Rotação Galáctica",
                    Categoria = "Astronomia", SubCategoria = "Galáxias",
                    Expressao = "M = v² × r / G",
                    Descricao = "Massa do corpo central estimada pela velocidade orbital e raio; base para inferência de matéria escura.",
                    Criador = "Rubin VC / Ford WK", AnoOrigin = "1970",
                    ReferenciaBibliografica = "Rubin VC, Ford WK. Astrophys J, 1970.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade orbital (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 220000 },
                        new Variavel { Nome = "Raio orbital (r)", Simbolo = "r", Unidade = "m", ValorPadrao = 2.5e20 }
                    },
                    Calcular = v => v["v"]*v["v"] * v["r"] / 6.674e-11,
                    VariavelResultado = "M", UnidadeResultado = "kg"
                },
                new Formula
                {
                    Id = "C3617", Nome = "Radiação de Corpo Negro — Lei de Planck",
                    Categoria = "Astronomia", SubCategoria = "Astrofísica",
                    Expressao = "Bν = (2hν³/c²) / (e^(hν/kT) − 1)",
                    Descricao = "Espectro de emissão de corpo negro; fundamento da astrofísica de espectros estelares.",
                    Criador = "Planck M", AnoOrigin = "1900",
                    ReferenciaBibliografica = "Planck M. Ann Phys, 1901.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência (ν)", Simbolo = "ν", Unidade = "Hz", ValorPadrao = 3e14, ValorMin = 1 },
                        new Variavel { Nome = "Temperatura (T)", Simbolo = "T", Unidade = "K", ValorPadrao = 5778, ValorMin = 1 }
                    },
                    Calcular = v => {
                        double h = 6.626e-34; double c = 2.998e8; double kB = 1.381e-23;
                        return (2*h*Math.Pow(v["ν"],3)/(c*c)) / (Math.Exp(h*v["ν"]/(kB*v["T"])) - 1);
                    },
                    VariavelResultado = "Bν", UnidadeResultado = "W/(m²·Hz·sr)"
                },
                new Formula
                {
                    Id = "C3618", Nome = "Relação Massa-Luminosidade Estelar",
                    Categoria = "Astronomia", SubCategoria = "Astrofísica Estelar",
                    Expressao = "L/L☉ ≈ (M/M☉)^4",
                    Descricao = "Relação empírica entre massa e luminosidade para estrelas da sequência principal.",
                    Criador = "Eddington AS", AnoOrigin = "1924",
                    ReferenciaBibliografica = "Eddington AS. Mon Not R Astron Soc, 1924.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa em M☉", Simbolo = "M_Msun", Unidade = "M☉", ValorPadrao = 2, ValorMin = 0.1 }
                    },
                    Calcular = v => Math.Pow(v["M_Msun"], 4),
                    VariavelResultado = "L/L☉", UnidadeResultado = "L☉"
                },
                new Formula
                {
                    Id = "C3619", Nome = "Distância pela Relação de Leavitt (Cefeidas)",
                    Categoria = "Astronomia", SubCategoria = "Astrometria",
                    Expressao = "d = 10^((m − M + 5)/5)",
                    Descricao = "Distância de Cefeida usando magnitude aparente e absoluta derivada da relação período-luminosidade.",
                    Criador = "Leavitt HS", AnoOrigin = "1912",
                    ReferenciaBibliografica = "Leavitt HS, Pickering EC. Harvard Obs Circ, 1912.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Magnitude aparente (m)", Simbolo = "m", Unidade = "mag", ValorPadrao = 18 },
                        new Variavel { Nome = "Magnitude absoluta (M)", Simbolo = "M_abs", Unidade = "mag", ValorPadrao = -3 }
                    },
                    Calcular = v => Math.Pow(10, (v["m"] - v["M_abs"] + 5) / 5.0),
                    VariavelResultado = "d", UnidadeResultado = "pc"
                },
                new Formula
                {
                    Id = "C3620", Nome = "Temperatura de Equilíbrio de Planeta",
                    Categoria = "Astronomia", SubCategoria = "Planetologia",
                    Expressao = "Teq = T☉ × sqrt(R☉/(2d)) × (1−A)^(1/4)",
                    Descricao = "Temperatura de equilíbrio de planeta irradiado pelo Sol; considera albedo e distância.",
                    Criador = "Prática astrofísica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Carroll BW, Ostlie DA. An Introduction to Modern Astrophysics, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura do Sol (T☉)", Simbolo = "T_sun", Unidade = "K", ValorPadrao = 5778 },
                        new Variavel { Nome = "Raio do Sol (R☉)", Simbolo = "R_sun", Unidade = "m", ValorPadrao = 6.96e8 },
                        new Variavel { Nome = "Distância ao Sol (d)", Simbolo = "d", Unidade = "m", ValorPadrao = 1.496e11, ValorMin = 1 },
                        new Variavel { Nome = "Albedo de Bond (A)", Simbolo = "A", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["T_sun"] * Math.Sqrt(v["R_sun"] / (2*v["d"])) * Math.Pow(1 - v["A"], 0.25),
                    VariavelResultado = "Teq", UnidadeResultado = "K"
                },
                new Formula
                {
                    Id = "C3621", Nome = "Extinção Interestelar",
                    Categoria = "Astronomia", SubCategoria = "Meio Interestelar",
                    Expressao = "A_V = 1,086 × τ_V",
                    Descricao = "Extinção visual em magnitudes relacionada à profundidade óptica do meio interestelar.",
                    Criador = "Cardelli JA et al.", AnoOrigin = "1989",
                    ReferenciaBibliografica = "Cardelli JA et al. Astrophys J, 1989.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Profundidade óptica (τ_V)", Simbolo = "τ_V", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = v => 1.086 * v["τ_V"],
                    VariavelResultado = "A_V", UnidadeResultado = "mag"
                },
                new Formula
                {
                    Id = "C3622", Nome = "Momento Angular Orbital",
                    Categoria = "Astronomia", SubCategoria = "Mecânica Celeste",
                    Expressao = "L = m × v × r",
                    Descricao = "Momento angular de corpo em órbita circular; conservado em órbitas Keplerianas.",
                    Criador = "Newton I", AnoOrigin = "1687",
                    ReferenciaBibliografica = "Murray CD, Dermott SF. Solar System Dynamics. Cambridge, 1999.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Massa do objeto (m)", Simbolo = "m", Unidade = "kg", ValorPadrao = 5.972e24 },
                        new Variavel { Nome = "Velocidade orbital (v)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 29780 },
                        new Variavel { Nome = "Raio orbital (r)", Simbolo = "r", Unidade = "m", ValorPadrao = 1.496e11 }
                    },
                    Calcular = v => v["m"] * v["v"] * v["r"],
                    VariavelResultado = "L", UnidadeResultado = "kg·m²/s"
                },
                new Formula
                {
                    Id = "C3623", Nome = "Frequência de Larmor (Plasma Astrofísico)",
                    Categoria = "Astronomia", SubCategoria = "Astrofísica de Plasma",
                    Expressao = "ωc = q × B / m",
                    Descricao = "Frequência de giro de partícula carregada em campo magnético; importante em ventos estelares.",
                    Criador = "Larmor J", AnoOrigin = "1897",
                    ReferenciaBibliografica = "Longair MS. High Energy Astrophysics, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Carga da partícula (q)", Simbolo = "q", Unidade = "C", ValorPadrao = 1.602e-19 },
                        new Variavel { Nome = "Campo magnético (B)", Simbolo = "B", Unidade = "T", ValorPadrao = 1e-5 },
                        new Variavel { Nome = "Massa da partícula (m)", Simbolo = "m_p", Unidade = "kg", ValorPadrao = 9.109e-31, ValorMin = 1e-40 }
                    },
                    Calcular = v => v["q"] * v["B"] / v["m_p"],
                    VariavelResultado = "ωc", UnidadeResultado = "rad/s"
                },
                new Formula
                {
                    Id = "C3624", Nome = "Magnitude Limite de Telescópio",
                    Categoria = "Astronomia", SubCategoria = "Instrumentação",
                    Expressao = "mlim ≈ 2,1 + 5 × log10(D_mm)",
                    Descricao = "Magnitude estelar limite observável com telescópio de abertura D mm em boas condições.",
                    Criador = "Prática observacional", AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Sidgwick JB. Amateur Astronomer's Handbook. Dover, 1980.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Diâmetro da objetiva (D)", Simbolo = "D", Unidade = "mm", ValorPadrao = 200, ValorMin = 1 }
                    },
                    Calcular = v => 2.1 + 5 * Math.Log10(v["D"]),
                    VariavelResultado = "mlim", UnidadeResultado = "mag"
                },
                new Formula
                {
                    Id = "C3625", Nome = "Período de Precessão Orbital",
                    Categoria = "Astronomia", SubCategoria = "Mecânica Celeste",
                    Expressao = "P_prec = 2π / Ω_prec",
                    Descricao = "Período de precessão do eixo de rotação de planeta; Ω_prec é a taxa de precessão angular.",
                    Criador = "Hiparcus (descoberta) / Newton I (teoria)", AnoOrigin = "127 a.C.",
                    ReferenciaBibliografica = "Murray CD, Dermott SF. Solar System Dynamics. Cambridge, 1999.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Taxa de precessão (Ω_prec)", Simbolo = "Ω_prec", Unidade = "rad/ano", ValorPadrao = 0.000245, ValorMin = 1e-10 }
                    },
                    Calcular = v => 2 * Math.PI / v["Ω_prec"],
                    VariavelResultado = "P_prec", UnidadeResultado = "anos"
                }
            });
        }
    }
}
