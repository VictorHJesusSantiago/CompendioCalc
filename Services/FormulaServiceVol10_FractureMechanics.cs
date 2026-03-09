using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XVI
    /// MECÂNICA DE FRATURA AVANÇADA E FADIGA
    /// Fórmulas V10-300 a V10-318 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_FractureMechanics()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3888",
                    CodigoCompendio = "V10-300",
                    Nome = "Fator de Intensidade de Tensão — Modo I",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Propagação de Trinca",
                    Expressao = @"K_I = Y·σ·√(π·a)",
                    Descricao = "K_I: fator intensidade tensão (modo I: abertura). Y: fator geométrico. a: comprimento trinca. Fratura quando K_I ≥ K_IC (tenacidade).",
                    ExemploPratico = "Aço estrutural: K_IC≈50 MPa√m. Vidro: K_IC≈0.7 MPa√m. Alumínio 7075-T6: K_IC≈25 MPa√m.",
                    Criador = "Irwin (1957, J. Appl. Mech.)",
                    AnoOrigin = "1957",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tensão σ (MPa)", Simbolo = "σ", Unidade = "MPa", ValorPadrao = 100 },
                        new Variavel { Nome = "Comprimento a (mm)", Simbolo = "a", Unidade = "mm", ValorPadrao = 10 },
                        new Variavel { Nome = "Fator Y", Simbolo = "Y", Unidade = "", ValorPadrao = 1.12 }
                    },
                    VariavelResultado = "K_I",
                    UnidadeResultado = "MPa√m",
                    Calcular = inputs =>
                    {
                        double sigma = inputs["Tensão σ (MPa)"];
                        double a_mm = inputs["Comprimento a (mm)"];
                        double Y = inputs["Fator Y"];
                        
                        double a_m = a_mm / 1000.0;
                        double K_I = Y * sigma * Math.Sqrt(Math.PI * a_m);
                        return K_I;
                    },
                    Icone = "🔧"
                },

                // V10-301: Tenacidade à Fratura K_IC
                new Formula
                {
                    Id = "3889",
                    CodigoCompendio = "V10-301",
                    Nome = "Tenacidade K_IC — Critério Fratura",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Tenacidade",
                    Expressao = @"K_I ≥ K_IC → fratura; ASTM E399 plane strain",
                    Descricao = "K_IC: plane strain fracture toughness. Aço estrutural: K_IC≈50 MPa√m. Vidro: K_IC≈0.7. Alumínio 7075-T6: K_IC≈25. Titânio Ti-6Al-4V: K_IC≈50-110 MPa√m.",
                    ExemploPratico = "Trinca a=10mm, σ=100MPa, Y=1.12→K_I=1.12·100·√(π·0.01)≈19.8 MPa√m. Aço K_IC=50→seguro (margem 50/19.8≈2.5). Vidro K_IC=0.7→falha imediata.",
                    Criador = "Irwin (1957, LEFM); ASTM E399 (1970 standard plane strain)",
                    AnoOrigin = "1957",
                    VariavelResultado = "margem_seguranca",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K_I (MPa√m)", Simbolo = "KI", Unidade = "MPa√m", ValorPadrao = 19.8 },
                        new Variavel { Nome = "K_IC material (MPa√m)", Simbolo = "KIC", Unidade = "MPa√m", ValorPadrao = 50 }
                    },
                    Calcular = inputs =>
                    {
                        double KI = inputs["K_I (MPa√m)"];
                        double KIC = inputs["K_IC material (MPa√m)"];
                        
                        if (KI <= 0) return 999;
                        double margem = KIC / KI;
                        return margem;
                    },
                    Icone = "🔧"
                },

                // V10-302: Critério de Griffith
                new Formula
                {
                    Id = "3890",
                    CodigoCompendio = "V10-302",
                    Nome = "Critério de Griffith — Fratura Frágil",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Fratura Elástica",
                    Expressao = @"σ_f = √((2·E·γ)/(π·a)); γ: energia superficial",
                    Descricao = "Fratura frágil (vidro, cerâmica). γ: energia superfície (~1 J/m² típico). Griffith (1921) vidro: σ_f∝1/√a. a↓→σ_f↑ (fibras strong).",
                    ExemploPratico = "Vidro E=70GPa, γ=1 J/m², a=1mm→σ_f=√(2·70e9·1/(π·0.001))≈6.7 MPa. a=10µm (fibra)→σ_f≈67 MPa (10× stronger). Flaw sensitivity.",
                    Criador = "Griffith (1921, Proc Royal Soc A, glass crack theory)",
                    AnoOrigin = "1921",
                    VariavelResultado = "sigma_f",
                    UnidadeResultado = "MPa",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "E módulo (GPa)", Simbolo = "E", Unidade = "GPa", ValorPadrao = 70 },
                        new Variavel { Nome = "γ energia sup (J/m²)", Simbolo = "gamma", Unidade = "J/m²", ValorPadrao = 1 },
                        new Variavel { Nome = "a comprimento (mm)", Simbolo = "a", Unidade = "mm", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double E_GPa = inputs["E módulo (GPa)"];
                        double gamma = inputs["γ energia sup (J/m²)"];
                        double a_mm = inputs["a comprimento (mm)"];
                        
                        double E = E_GPa * 1e9;
                        double a_m = a_mm / 1000;
                        
                        double sigma_f_Pa = Math.Sqrt((2 * E * gamma) / (Math.PI * a_m));
                        double sigma_f_MPa = sigma_f_Pa / 1e6;
                        return sigma_f_MPa;
                    },
                    Icone = "🔧"
                },

                // V10-303: Integral J (Rice)
                new Formula
                {
                    Id = "3891",
                    CodigoCompendio = "V10-303",
                    Nome = "Integral J (Rice) — EPFM",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Fratura Elasto-Plástica",
                    Expressao = @"J = ∫(W·dy − T·(∂u/∂x)·ds); path-independent",
                    Descricao = "J-integral: energia fratura (EPFM). J≥J_IC→fratura dúctil. Equivale G (LEFM): J=(K_I²/E') para elástico. Rice (1968, Nobel consideration). ASTM E1820.",
                    ExemploPratico = "Aço dúctil J_IC≈200 kJ/m². K_I=50 MPa√m, E'=200GPa→J=(50e6)²/(200e9)≈12.5 kJ/m² (LEFM). Plasticidade: J>G (HRR fields).",
                    Criador = "Rice (1968, J. Appl. Mech., path-independent integral)",
                    AnoOrigin = "1968",
                    VariavelResultado = "J",
                    UnidadeResultado = "kJ/m²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K_I (MPa√m)", Simbolo = "KI", Unidade = "MPa√m", ValorPadrao = 50 },
                        new Variavel { Nome = "E' efetivo (GPa)", Simbolo = "Ep", Unidade = "GPa", ValorPadrao = 200 }
                    },
                    Calcular = inputs =>
                    {
                        double KI = inputs["K_I (MPa√m)"];
                        double Ep_GPa = inputs["E' efetivo (GPa)"];
                        
                        double KI_Pa = KI * 1e6;
                        double Ep = Ep_GPa * 1e9;
                        
                        double J = (KI_Pa * KI_Pa) / Ep;
                        double J_kJ = J / 1000;
                        return J_kJ;
                    },
                    Icone = "🔧"
                },

                // V10-304: Lei de Paris (Fadiga)
                new Formula
                {
                    Id = "3892",
                    CodigoCompendio = "V10-304",
                    Nome = "Lei de Paris — Propagação Fadiga",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Fadiga",
                    Expressao = @"da/dN = C·(ΔK)^m; região II Paris",
                    Descricao = "Crescimento trinca cíclica. C, m: constantes material. Aço: C≈10^-12 (unidades MPa√m, m), m≈3. Região II: 10^-8 a 10^-6 m/ciclo. Walker, Forman: R-ratio.",
                    ExemploPratico = "Aço C=3e-12, m=3, ΔK=20 MPa√m→da/dN=3e-12·(20)³=2.4e-8 m/ciclo. N=10^6 ciclos→Δa≈24 mm. a₀=1mm→a_f≈25mm (critical a_c calc).",
                    Criador = "Paris-Erdogan (1963, J. Basic Eng., fatigue crack growth empirical law)",
                    AnoOrigin = "1963",
                    VariavelResultado = "da_dN",
                    UnidadeResultado = "m/ciclo (×10^-8)",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "C constante (×10^-12)", Simbolo = "C", Unidade = "×10^-12", ValorPadrao = 3 },
                        new Variavel { Nome = "m expoente", Simbolo = "m", Unidade = "", ValorPadrao = 3 },
                        new Variavel { Nome = "ΔK (MPa√m)", Simbolo = "DK", Unidade = "MPa√m", ValorPadrao = 20 }
                    },
                    Calcular = inputs =>
                    {
                        double C_e12 = inputs["C constante (×10^-12)"];
                        double m = inputs["m expoente"];
                        double DK = inputs["ΔK (MPa√m)"];
                        
                        double C = C_e12 * 1e-12;
                        double da_dN = C * Math.Pow(DK, m);
                        double da_dN_e8 = da_dN * 1e8;
                        return da_dN_e8;
                    },
                    Icone = "🔧"
                },

                // V10-305: Zona Plástica de Irwin
                new Formula
                {
                    Id = "3893",
                    CodigoCompendio = "V10-305",
                    Nome = "Zona Plástica r_p (Irwin)",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Plasticidade",
                    Expressao = @"r_p = (1/(2·π))·(K_I/σ_y)²; plane stress",
                    Descricao = "Zona plástica ponta trinca. Plane stress: r_p=(1/2π)(K_I/σ_y)². Plane strain: r_p/3 (triaxialidade). Small-scale yielding (SSY): r_p<<a.",
                    ExemploPratico = "Aço K_I=40 MPa√m, σ_y=400 MPa→r_p=(1/6.28)·(40/400)²≈1.6 mm. LEFM válido se r_p<a/50. a=100mm→r_p<2mm OK.",
                    Criador = "Irwin (1960, plastic zone correction); Dugdale (1960, strip-yield model)",
                    AnoOrigin = "1960",
                    VariavelResultado = "r_p",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K_I (MPa√m)", Simbolo = "KI", Unidade = "MPa√m", ValorPadrao = 40 },
                        new Variavel { Nome = "σ_y escoamento (MPa)", Simbolo = "sigma_y", Unidade = "MPa", ValorPadrao = 400 }
                    },
                    Calcular = inputs =>
                    {
                        double KI = inputs["K_I (MPa√m)"];
                        double sigma_y = inputs["σ_y escoamento (MPa)"];
                        
                        double r_p_m = (1 / (2 * Math.PI)) * Math.Pow(KI / sigma_y, 2);
                        double r_p_mm = r_p_m * 1000;
                        return r_p_mm;
                    },
                    Icone = "🔧"
                },

                // V10-306: CTOD Crack Tip Opening Displacement
                new Formula
                {
                    Id = "3894",
                    CodigoCompendio = "V10-306",
                    Nome = "CTOD δ — Abertura Ponta Trinca",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Parâmetros EPFM",
                    Expressao = @"δ = (4/π)·(K_I²/(E'·σ_y)); Wells (1961)",
                    Descricao = "Crack Tip Opening Displacement. δ≥δ_c→fratura. Relaciona J: δ=J/(m·σ_y), m≈2 (Shih 1981). BS 7448 test standard. Welding assessment.",
                    ExemploPratico = "Aço K_I=50 MPa√m, E'=200GPa, σ_y=400MPa→δ=(4/π)·(50·10^6)²/(200·10^9·400·10^6)≈0.032 mm. δ_c≈0.05-0.5mm típico structural steel.",
                    Criador = "Wells (1961, COD concept); BS 7448 (British Standard CTOD testing)",
                    AnoOrigin = "1961",
                    VariavelResultado = "delta",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K_I (MPa√m)", Simbolo = "KI", Unidade = "MPa√m", ValorPadrao = 50 },
                        new Variavel { Nome = "E' (GPa)", Simbolo = "Ep", Unidade = "GPa", ValorPadrao = 200 },
                        new Variavel { Nome = "σ_y (MPa)", Simbolo = "sigma_y", Unidade = "MPa", ValorPadrao = 400 }
                    },
                    Calcular = inputs =>
                    {
                        double KI = inputs["K_I (MPa√m)"];
                        double Ep_GPa = inputs["E' (GPa)"];
                        double sigma_y = inputs["σ_y (MPa)"];
                        
                        double KI_Pa = KI * 1e6;
                        double Ep = Ep_GPa * 1e9;
                        double sigma_y_Pa = sigma_y * 1e6;
                        
                        double delta_m = (4 / Math.PI) * (KI_Pa * KI_Pa) / (Ep * sigma_y_Pa);
                        double delta_mm = delta_m * 1000;
                        return delta_mm;
                    },
                    Icone = "🔧"
                },

                // V10-307: Charpy V-notch Impact
                new Formula
                {
                    Id = "3895",
                    CodigoCompendio = "V10-307",
                    Nome = "Charpy CVN — Energia Impacto",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Tenacidade ao Impacto",
                    Expressao = @"CVN = m·g·h·(cos(β)−cos(α)); energia absorvida",
                    Descricao = "Charpy V-notch: corpo 10×10×55mm, entalhe 2mm 45°. Pêndulo m≈25kg, h=0.8m, α≈150°. Aço dúctil: CVN>40 J. Frágil: CVN<20 J. DBTT (transition temperature).",
                    ExemploPratico = "Pêndulo m=25kg, h=0.8m, α=150°, β=120° (após impacto)→CVN=25·9.8·0.8·(cos120°−cos150°)≈25·9.8·0.8·(0.366)≈71.4 J. Aço ASTM A36: CVN≈27 J @ 20°C.",
                    Criador = "Charpy (1901, impact pendulum test); ASTM E23 (standard test method)",
                    AnoOrigin = "1901",
                    VariavelResultado = "CVN",
                    UnidadeResultado = "J",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m pêndulo (kg)", Simbolo = "m", Unidade = "kg", ValorPadrao = 25 },
                        new Variavel { Nome = "h altura (m)", Simbolo = "h", Unidade = "m", ValorPadrao = 0.8 },
                        new Variavel { Nome = "α inicial (°)", Simbolo = "alpha", Unidade = "°", ValorPadrao = 150 },
                        new Variavel { Nome = "β final (°)", Simbolo = "beta", Unidade = "°", ValorPadrao = 120 }
                    },
                    Calcular = inputs =>
                    {
                        double m = inputs["m pêndulo (kg)"];
                        double h = inputs["h altura (m)"];
                        double alpha_deg = inputs["α inicial (°)"];
                        double beta_deg = inputs["β final (°)"];
                        
                        double alpha_rad = alpha_deg * Math.PI / 180;
                        double beta_rad = beta_deg * Math.PI / 180;
                        double g = 9.8;
                        
                        double CVN = m * g * h * (Math.Cos(beta_rad) - Math.Cos(alpha_rad));
                        return CVN;
                    },
                    Icone = "🔧"
                },

                // V10-308: Transição Dúctil-Frágil (DBTT)
                new Formula
                {
                    Id = "3896",
                    CodigoCompendio = "V10-308",
                    Nome = "DBTT — Temperatura Transição",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Transição Dúctil-Frágil",
                    Expressao = @"T_DBTT: CVN(T) sharp drop; BCC metais",
                    Descricao = "Ductile-Brittle Transition Temperature. BCC (aço, W): DBTT presente. FCC (Al, Cu), HCP (Ti): sem DBTT (dúctil sempre). Titanic: T<T_DBTT fratura frágil.",
                    ExemploPratico = "Aço carbono: DBTT≈−20 a +20°C. Aço baixa liga: DBTT≈−50°C (Ni adição). Teste Charpy: T<DBTT→CVN<20J (frágil). T>DBTT→CVN>50J (dúctil). Projeto: T_serviço>DBTT+margin.",
                    Criador = "Diversos; observação empírica aços século XX; Cottrell (teoria dislocation mobility)",
                    AnoOrigin = "1940",
                    VariavelResultado = "T_DBTT",
                    UnidadeResultado = "°C",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "T operação (°C)", Simbolo = "T_op", Unidade = "°C", ValorPadrao = -10 },
                        new Variavel { Nome = "T_DBTT material (°C)", Simbolo = "T_DBTT", Unidade = "°C", ValorPadrao = 0 }
                    },
                    Calcular = inputs =>
                    {
                        double T_op = inputs["T operação (°C)"];
                        double T_DBTT = inputs["T_DBTT material (°C)"];
                        
                        double margin = T_op - T_DBTT;
                        return margin;
                    },
                    Icone = "🔧"
                },

                // V10-309: Curva R (Resistência)
                new Formula
                {
                    Id = "3897",
                    CodigoCompendio = "V10-309",
                    Nome = "Curva R — Resistência J_R(Δa)",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Rasgamento Dúctil",
                    Expressao = @"J_R = J₀ + C₁·(Δa)^C₂; tearing modulus T=dJ_R/da",
                    Descricao = "R-curve: resistência cresce com Δa (crack extension). Materiais dúcteis: rising J_R (pop-in arrest). Frágeis: J_R flat. ASTM E1820 test. Tearing modulus T.",
                    ExemploPratico = "Aço dúctil J₀=100 kJ/m², C₁=5000 kJ/m³, C₂=0.5→Δa=2mm→J_R=100+5000·(0.002)^0.5≈100+223≈323 kJ/m². Instabilidade: J_aplicado tangente J_R.",
                    Criador = "Diversos; Ernst-Paris (1979, tearing modulus T); ASTM E1820 (J_R testing)",
                    AnoOrigin = "1979",
                    VariavelResultado = "J_R",
                    UnidadeResultado = "kJ/m²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "J₀ inicial (kJ/m²)", Simbolo = "J0", Unidade = "kJ/m²", ValorPadrao = 100 },
                        new Variavel { Nome = "C₁ (kJ/m³)", Simbolo = "C1", Unidade = "kJ/m³", ValorPadrao = 5000 },
                        new Variavel { Nome = "C₂ expoente", Simbolo = "C2", Unidade = "", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Δa extensão (mm)", Simbolo = "Da", Unidade = "mm", ValorPadrao = 2 }
                    },
                    Calcular = inputs =>
                    {
                        double J0 = inputs["J₀ inicial (kJ/m²)"];
                        double C1 = inputs["C₁ (kJ/m³)"];
                        double C2 = inputs["C₂ expoente"];
                        double Da_mm = inputs["Δa extensão (mm)"];
                        
                        double Da_m = Da_mm / 1000;
                        double J_R = J0 + C1 * Math.Pow(Da_m, C2);
                        return J_R;
                    },
                    Icone = "🔧"
                },

                // V10-310: Modo Misto (K_eq)
                new Formula
                {
                    Id = "3898",
                    CodigoCompendio = "V10-310",
                    Nome = "Modo Misto K_eq — I+II+III",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Carregamento Misto",
                    Expressao = @"K_eq = √(K_I² + K_II² + K_III²/(1+ν)); simplified",
                    Descricao = "Modo I: abertura. Modo II: cisalhamento in-plane. Modo III: cisalhamento out-of-plane (torção). Fratura: K_eq≥K_IC. Criteria: max tangential stress, strain energy density.",
                    ExemploPratico = "K_I=30, K_II=20, K_III=10 MPa√m, ν=0.3→K_eq=√(900+400+100/1.3)≈√1377≈37.1 MPa√m. Predomina modo I. Mixed-mode fracture toughness testing.",
                    Criador = "Diversos; Erdogan-Sih (1963, mixed-mode criteria); Williams (1957, stress field modes)",
                    AnoOrigin = "1957",
                    VariavelResultado = "K_eq",
                    UnidadeResultado = "MPa√m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K_I (MPa√m)", Simbolo = "KI", Unidade = "MPa√m", ValorPadrao = 30 },
                        new Variavel { Nome = "K_II (MPa√m)", Simbolo = "KII", Unidade = "MPa√m", ValorPadrao = 20 },
                        new Variavel { Nome = "K_III (MPa√m)", Simbolo = "KIII", Unidade = "MPa√m", ValorPadrao = 10 },
                        new Variavel { Nome = "ν Poisson", Simbolo = "nu", Unidade = "", ValorPadrao = 0.3 }
                    },
                    Calcular = inputs =>
                    {
                        double KI = inputs["K_I (MPa√m)"];
                        double KII = inputs["K_II (MPa√m)"];
                        double KIII = inputs["K_III (MPa√m)"];
                        double nu = inputs["ν Poisson"];
                        
                        double K_eq = Math.Sqrt(KI * KI + KII * KII + (KIII * KIII) / (1 + nu));
                        return K_eq;
                    },
                    Icone = "🔧"
                },

                // V10-311: Compact Tension C(T) Specimen
                new Formula
                {
                    Id = "3899",
                    CodigoCompendio = "V10-311",
                    Nome = "C(T) Specimen — K_I Calculation",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Ensaio Experimental",
                    Expressao = @"K_I = (P/(B·√W))·f(a/W); ASTM E1820",
                    Descricao = "Compact Tension corpo de prova. P: carga. B: espessura. W: largura. a: comprimento trinca. f(a/W): polynomial ASTM. Typical a/W≈0.5. Laminado side-grooved.",
                    ExemploPratico = "C(T) P=10kN, B=25mm, W=50mm, a/W=0.5→f≈9.4 (ASTM)→K_I=(10000/(25·√50))·9.4≈10000·9.4/(25·7.07)≈532 N/mm^(3/2)=16.8 MPa√m.",
                    Criador = "ASTM E1820 (standard test method J_IC, K_IC); ASTM E399 (plane strain K_IC)",
                    AnoOrigin = "1970",
                    VariavelResultado = "K_I",
                    UnidadeResultado = "MPa√m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "P carga (kN)", Simbolo = "P", Unidade = "kN", ValorPadrao = 10 },
                        new Variavel { Nome = "B espessura (mm)", Simbolo = "B", Unidade = "mm", ValorPadrao = 25 },
                        new Variavel { Nome = "W largura (mm)", Simbolo = "W", Unidade = "mm", ValorPadrao = 50 },
                        new Variavel { Nome = "f(a/W) função", Simbolo = "f", Unidade = "", ValorPadrao = 9.4 }
                    },
                    Calcular = inputs =>
                    {
                        double P_kN = inputs["P carga (kN)"];
                        double B_mm = inputs["B espessura (mm)"];
                        double W_mm = inputs["W largura (mm)"];
                        double f = inputs["f(a/W) função"];
                        
                        double P_N = P_kN * 1000;
                        double K_I_SI = (P_N / (B_mm * Math.Sqrt(W_mm))) * f;
                        double K_I_MPa = K_I_SI * Math.Sqrt(1000) / 1000;
                        return K_I_MPa;
                    },
                    Icone = "🔧"
                },

                // V10-312: Weibull Statistics (Failure Probability)
                new Formula
                {
                    Id = "3900",
                    CodigoCompendio = "V10-312",
                    Nome = "Weibull — Probabilidade Falha Frágil",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Estatística de Falha",
                    Expressao = @"P_f = 1 − exp(−(σ/σ₀)^m); m: módulo Weibull",
                    Descricao = "Fratura frágil (cerâmica, vidro): falha probabilística (flaw distribution). m: Weibull modulus (m alto: less scatter). Cerâmica: m≈5-15. Vidro: m≈5. Metais dúcteis: m>20.",
                    ExemploPratico = "Cerâmica σ₀=300 MPa, m=10, σ=250 MPa→P_f=1−exp(−(250/300)^10)≈1−exp(−0.056)≈0.054 (5.4% falha). σ=350 MPa→P_f≈43%. Teste 20 amostras: fail distribution.",
                    Criador = "Weibull (1939, statistical theory fracture); aplicação cerâmicas 1950s",
                    AnoOrigin = "1939",
                    VariavelResultado = "P_f",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ aplicada (MPa)", Simbolo = "sigma", Unidade = "MPa", ValorPadrao = 250 },
                        new Variavel { Nome = "σ₀ escala (MPa)", Simbolo = "sigma0", Unidade = "MPa", ValorPadrao = 300 },
                        new Variavel { Nome = "m módulo Weibull", Simbolo = "m", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double sigma = inputs["σ aplicada (MPa)"];
                        double sigma0 = inputs["σ₀ escala (MPa)"];
                        double m = inputs["m módulo Weibull"];
                        
                        if (sigma0 == 0) return 0;
                        double P_f = 1 - Math.Exp(-Math.Pow(sigma / sigma0, m));
                        double P_f_pct = P_f * 100;
                        return P_f_pct;
                    },
                    Icone = "🔧"
                },

                // V10-313: T-Stress (Constraint)
                new Formula
                {
                    Id = "3901",
                    CodigoCompendio = "V10-313",
                    Nome = "T-Stress — Constraint Effect",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Constraint",
                    Expressao = @"σ_ij = (K_I/(√(2πr)))·f_ij(θ) + T·δ_1i·δ_1j + ...",
                    Descricao = "T-stress: termo não-singular Williams expansion. T>0: positive constraint (triaxial, lower toughness). T<0: loss constraint (higher apparent toughness). Geometry dependent.",
                    ExemploPratico = "C(T) specimen: T≈−0.5·σ_ref (negative). SENB: T≈+0.3·σ_ref (positive). Deep crack: T→0 (high constraint≈plane strain). Shallow crack: |T| large (constraint loss).",
                    Criador = "Williams (1957, stress field expansion); Larsson-Carlsson (1973, T-stress effect on plastic zone); Betegón-Hancock (1991, two-parameter fracture)",
                    AnoOrigin = "1957",
                    VariavelResultado = "T",
                    UnidadeResultado = "MPa",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ_ref tensão ref (MPa)", Simbolo = "sigma_ref", Unidade = "MPa", ValorPadrao = 100 },
                        new Variavel { Nome = "Fator geométrico β", Simbolo = "beta", Unidade = "", ValorPadrao = -0.5 }
                    },
                    Calcular = inputs =>
                    {
                        double sigma_ref = inputs["σ_ref tensão ref (MPa)"];
                        double beta = inputs["Fator geométrico β"];
                        
                        double T = beta * sigma_ref;
                        return T;
                    },
                    Icone = "🔧"
                },

                // V10-314: Threshold ΔK_th (Fadiga)
                new Formula
                {
                    Id = "3902",
                    CodigoCompendio = "V10-314",
                    Nome = "Threshold ΔK_th — Limite Fadiga",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Fadiga",
                    Expressao = @"da/dN → 0 quando ΔK < ΔK_th; região I Paris",
                    Descricao = "ΔK_th: threshold stress intensity range. ΔK<ΔK_th: crack arrest (não propaga). Aço: ΔK_th≈5-10 MPa√m (R=0). R>0: ΔK_th↓ (closure effect). Long cracks vs short cracks.",
                    ExemploPratico = "Aço estrutural R=0: ΔK_th≈7 MPa√m. R=0.5: ΔK_th≈3 MPa√m. ΔK=5 MPa√m<7→arrest. ΔK=10>7→propagation Paris da/dN≈10^-9 m/cycle slow. Infinite life se ΔK<ΔK_th sempre.",
                    Criador = "Diversos; Elber (1971, crack closure mechanism); Suresh (1998, Fatigue of Materials review)",
                    AnoOrigin = "1971",
                    VariavelResultado = "arrest",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ΔK aplicado (MPa√m)", Simbolo = "DK", Unidade = "MPa√m", ValorPadrao = 5 },
                        new Variavel { Nome = "ΔK_th material (MPa√m)", Simbolo = "DKth", Unidade = "MPa√m", ValorPadrao = 7 }
                    },
                    Calcular = inputs =>
                    {
                        double DK = inputs["ΔK aplicado (MPa√m)"];
                        double DKth = inputs["ΔK_th material (MPa√m)"];
                        
                        // Retorna 1=arrest, 0=propaga
                        double arrest = DK < DKth ? 1 : 0;
                        return arrest;
                    },
                    Icone = "🔧"
                },

                // V10-315: Forman Equation (Região III)
                new Formula
                {
                    Id = "3903",
                    CodigoCompendio = "V10-315",
                    Nome = "Equação de Forman — Região III",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Fadiga",
                    Expressao = @"da/dN = C·(ΔK)^n/((1−R)·K_IC − ΔK); unstable",
                    Descricao = "Forman equation: da/dN→∞ quando ΔK→(1−R)·K_IC (região III Paris, unstable). Considera R-ratio e K_IC. Paris simples: região II only. Walker equation: R-ratio general.",
                    ExemploPratico = "Aço C=1e-11, n=3, R=0.1, K_IC=50 MPa√m, ΔK=30→da/dN=1e-11·(30)³/((0.9)·50−30)=27000e-11/(45−30)=1.8e-6 m/cycle (rápido unstable). ΔK=40→27× faster.",
                    Criador = "Forman (1967, fatigue crack growth equation region III)",
                    AnoOrigin = "1967",
                    VariavelResultado = "da_dN",
                    UnidadeResultado = "m/ciclo (×10^-6)",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "C constante (×10^-11)", Simbolo = "C", Unidade = "×10^-11", ValorPadrao = 1 },
                        new Variavel { Nome = "n expoente", Simbolo = "n", Unidade = "", ValorPadrao = 3 },
                        new Variavel { Nome = "ΔK (MPa√m)", Simbolo = "DK", Unidade = "MPa√m", ValorPadrao = 30 },
                        new Variavel { Nome = "R ratio", Simbolo = "R", Unidade = "", ValorPadrao = 0.1 },
                        new Variavel { Nome = "K_IC (MPa√m)", Simbolo = "KIC", Unidade = "MPa√m", ValorPadrao = 50 }
                    },
                    Calcular = inputs =>
                    {
                        double C_e11 = inputs["C constante (×10^-11)"];
                        double n = inputs["n expoente"];
                        double DK = inputs["ΔK (MPa√m)"];
                        double R = inputs["R ratio"];
                        double KIC = inputs["K_IC (MPa√m)"];
                        
                        double C = C_e11 * 1e-11;
                        double denominator = (1 - R) * KIC - DK;
                        if (denominator <= 0) return 1e10; // Unstable
                        
                        double da_dN = C * Math.Pow(DK, n) / denominator;
                        double da_dN_e6 = da_dN * 1e6;
                        return da_dN_e6;
                    },
                    Icone = "🔧"
                },

                // V10-316: HRR Field (Elastic-Plastic)
                new Formula
                {
                    Id = "3904",
                    CodigoCompendio = "V10-316",
                    Nome = "HRR Field — Elastic-Plastic Singularit",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "EPFM",
                    Expressao = @"σ_ij = σ₀·(J/(α·σ₀·ε₀·I_n·r))^(1/(n+1))·σ̃_ij(θ,n)",
                    Descricao = "Hutchinson-Rice-Rosengren singular field EPFM. n: Ramberg-Osgood exponent (n≈10 typical). r^(−1/(n+1)) singularity (weaker than 1/√r LEFM). Dominância J perto ponta trinca (SSY).",
                    ExemploPratico = "Power-law hardening σ=σ₀·(ε/ε₀)^n, n=10. Zona HRR: r<2 J/(σ_y). Aço J=100 kJ/m², σ_y=400 MPa→r<0.5 mm. Crack blunting δ_t≈J/(2σ_y)≈0.125 mm.",
                    Criador = "Hutchinson (1968); Rice-Rosengren (1968, J-dominance EPFM crack-tip fields)",
                    AnoOrigin = "1968",
                    VariavelResultado = "r_HRR",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "J (kJ/m²)", Simbolo = "J", Unidade = "kJ/m²", ValorPadrao = 100 },
                        new Variavel { Nome = "σ_y escoamento (MPa)", Simbolo = "sigma_y", Unidade = "MPa", ValorPadrao = 400 }
                    },
                    Calcular = inputs =>
                    {
                        double J_kJ = inputs["J (kJ/m²)"];
                        double sigma_y = inputs["σ_y escoamento (MPa)"];
                        
                        double J = J_kJ * 1000;
                        double sigma_y_Pa = sigma_y * 1e6;
                        
                        double r_m = 2 * J / sigma_y_Pa;
                        double r_mm = r_m * 1000;
                        return r_mm;
                    },
                    Icone = "🔧"
                },

                // V10-317: Vida à Fadiga N_f (Integração Paris)
                new Formula
                {
                    Id = "3905",
                    CodigoCompendio = "V10-317",
                    Nome = "Vida à Fadiga N_f — Integração Paris",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Fadiga",
                    Expressao = @"N_f = ∫[a₀ to a_c] da/(C·(Y·σ·√(πa))^m); ciclos até fratura",
                    Descricao = "Integração Lei Paris a₀→a_c. Y constante→simples: N_f≈2/((m−2)·C·(Y·σ·√π)^m)·(a₀^(1−m/2)−a_c^(1−m/2)). m=3 típico aço. Critical a_c: K_I=K_IC.",
                    ExemploPratico = "Aço a₀=1mm, C=3e-12, m=3, Y=1.1, σ=100MPa, K_IC=50→a_c=(K_IC/(Y·σ·√π))²=(50/(1.1·100·√π))²≈0.0521 m=52.1mm. N_f≈∫→2/(1·3e-12·(1.1·100·√π)³)·(0.001^(−0.5)−0.0521^(−0.5))≈10^6 ciclos.",
                    Criador = "Integração da Lei de Paris (Paris 1963); cálculo vida residual estruturas",
                    AnoOrigin = "1963",
                    VariavelResultado = "N_f",
                    UnidadeResultado = "ciclos (×10^5)",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "a₀ inicial (mm)", Simbolo = "a0", Unidade = "mm", ValorPadrao = 1 },
                        new Variavel { Nome = "a_c crítica (mm)", Simbolo = "ac", Unidade = "mm", ValorPadrao = 52.1 }
                    },
                    Calcular = inputs =>
                    {
                        double a0_mm = inputs["a₀ inicial (mm)"];
                        double ac_mm = inputs["a_c crítica (mm)"];
                        
                        // Aproximação m=3 simplificada
                        double C = 3e-12;
                        double m = 3;
                        double Y = 1.1;
                        double sigma = 100;
                        
                        double factor = Y * sigma * Math.Sqrt(Math.PI);
                        double a0_m = a0_mm / 1000;
                        double ac_m = ac_mm / 1000;
                        
                        double N_f = 2 / ((m - 2) * C * Math.Pow(factor, m)) * (Math.Pow(a0_m, 1 - m / 2) - Math.Pow(ac_m, 1 - m / 2));
                        double N_f_e5 = N_f / 1e5;
                        return N_f_e5;
                    },
                    Icone = "🔧"
                },

                // V10-318: Small-Scale Yielding (SSY) Criterion
                new Formula
                {
                    Id = "3906",
                    CodigoCompendio = "V10-318",
                    Nome = "SSY Criterion — LEFM Validade",
                    Categoria = "Mecânica de Fratura",
                    SubCategoria = "Validade LEFM",
                    Expressao = @"a, B, (W−a) ≥ 2.5·(K_IC/σ_y)²; ASTM E399",
                    Descricao = "Small-Scale Yielding: r_p<<dimensões. ASTM E399 plane strain: a,B,(W−a)≥2.5(K_IC/σ_y)². Ensure triaxialidade. Specimen size critical. Tipo C(T): B≥25mm típico aço.",
                    ExemploPratico = "Aço K_IC=50 MPa√m, σ_y=400 MPa→min=2.5·(50/400)²=2.5·0.0156≈39 mm. B=25mm insuficiente (plane stress). B=50mm OK (plane strain valid). Ensaios miniatura: J-integral EPFM.",
                    Criador = "ASTM E399 (1970, standard test method plane strain K_IC, size requirements)",
                    AnoOrigin = "1970",
                    VariavelResultado = "dim_min",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K_IC (MPa√m)", Simbolo = "KIC", Unidade = "MPa√m", ValorPadrao = 50 },
                        new Variavel { Nome = "σ_y (MPa)", Simbolo = "sigma_y", Unidade = "MPa", ValorPadrao = 400 }
                    },
                    Calcular = inputs =>
                    {
                        double KIC = inputs["K_IC (MPa√m)"];
                        double sigma_y = inputs["σ_y (MPa)"];
                        
                        if (sigma_y == 0) return 0;
                        double dim_min_m = 2.5 * Math.Pow(KIC / sigma_y, 2);
                        double dim_min_mm = dim_min_m * 1000;
                        return dim_min_mm;
                    },
                    Icone = "🔧"
                }
            });
        }
    }
}
