using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE VII: CIÊNCIA DE MATERIAIS E METALURGIA
    // Mecânica dos materiais, cristalografia, difusão, fases
    // 20 fórmulas (125-144)
    // ========================================

    public static Formula V8_MAT125_LeiHooke()
    {
        return new Formula
        {
            Id = "V8-MAT125",
            CodigoCompendio = "125",
            Nome = "Lei de Hooke — Elasticidade",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Mecânica dos Materiais",
            Expressao = "σ = E * ε",
            ExprTexto = "Tensão-deformação",
            Descricao = "σ=tensão (Pa), E=módulo Young (Pa), ε=deformação (adimensional). Regime elástico.",
            Criador = "Robert Hooke",
            AnoOrigin = "1660",
            ExemploPratico = "Aço: E=200GPa, ε=0,001 → σ=200MPa. τ=G·γ (cisalhamento). G=E/(2(1+ν))",
            Unidades = "Pa",
            VariavelResultado = "sigma",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E", Nome = "Módulo de Young", Descricao = "E", Unidade = "Pa", ValorPadrao = 200e9, ValorMin = 1e6, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "epsilon", Nome = "Deformação", Descricao = "ε", Unidade = "", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E = inputs["E"];
                double epsilon = inputs["epsilon"];
                
                return E * epsilon;
            }
        };
    }

    public static Formula V8_MAT126_TensaoCisalhamento()
    {
        return new Formula
        {
            Id = "V8-MAT126",
            CodigoCompendio = "126",
            Nome = "Módulo de Cisalhamento — G",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Propriedades Elásticas",
            Expressao = "G = E / (2 * (1 + ν))",
            ExprTexto = "Módulo cisalhante",
            Descricao = "G=módulo cisalhamento (Pa), E=Young (Pa), ν=coef. Poisson. Relação entre constantes elásticas.",
            Criador = "Teoria elasticidade",
            AnoOrigin = "~1800s",
            ExemploPratico = "E=200GPa, ν=0,3 → G≈76,9GPa. Aço: ν≈0,27-0,30. Borracha: ν≈0,5 (incompressível)",
            Unidades = "Pa",
            VariavelResultado = "G",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E", Nome = "Módulo de Young", Descricao = "E", Unidade = "Pa", ValorPadrao = 200e9, ValorMin = 1e6, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "nu", Nome = "Coef. Poisson", Descricao = "ν", Unidade = "", ValorPadrao = 0.3, ValorMin = -1, ValorMax = 0.5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E = inputs["E"];
                double nu = inputs["nu"];
                
                return E / (2 * (1 + nu));
            }
        };
    }

    public static Formula V8_MAT127_LeiGriffith()
    {
        return new Formula
        {
            Id = "V8-MAT127",
            CodigoCompendio = "127",
            Nome = "Critério de Griffith — Fratura",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Mecânica da Fratura",
            Expressao = "σf = sqrt((2 * E * γs) / (π * a))",
            ExprTexto = "Tensão de fratura",
            Descricao = "σf=tensão fratura (Pa), γs=energia superficial (J/m²), a=comprimento trinca (m), E=Young (Pa).",
            Criador = "A. A. Griffith",
            AnoOrigin = "1921",
            ExemploPratico = "Vidro: E=70GPa, γs=1J/m², a=1mm → σf≈67MPa. KIC=Yσ√(πa): fator intensidade tensão",
            Unidades = "Pa",
            VariavelResultado = "sigma_f",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E", Nome = "Módulo de Young", Descricao = "E", Unidade = "Pa", ValorPadrao = 70e9, ValorMin = 1e6, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "gamma_s", Nome = "Energia superficial", Descricao = "γs", Unidade = "J/m²", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Comprimento trinca", Descricao = "a", Unidade = "m", ValorPadrao = 0.001, ValorMin = 1e-6, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E = inputs["E"];
                double gamma_s = inputs["gamma_s"];
                double a = inputs["a"];
                
                return Math.Sqrt((2 * E * gamma_s) / (Math.PI * a));
            }
        };
    }

    public static Formula V8_MAT128_DifusaoFick1()
    {
        return new Formula
        {
            Id = "V8-MAT128",
            CodigoCompendio = "128",
            Nome = "1ª Lei de Fick — Difusão",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Difusão",
            Expressao = "J = -D * (dC/dx)",
            ExprTexto = "Fluxo de difusão",
            Descricao = "J=fluxo (mol/m²/s), D=coef. difusão (m²/s), dC/dx=gradiente concentração (mol/m⁴).",
            Criador = "Adolf Fick",
            AnoOrigin = "1855",
            ExemploPratico = "D=1e-9m²/s (sólido), dC/dx=1000mol/m⁴ → J=1e-6mol/m²/s. Estado estacionário",
            Unidades = "mol/m²/s",
            VariavelResultado = "J",
            UnidadeResultado = "mol/m²/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "D", Nome = "Coef. difusão", Descricao = "D", Unidade = "m²/s", ValorPadrao = 1e-9, ValorMin = 1e-20, ValorMax = 1e-4, Obrigatoria = true },
                new() { Simbolo = "dC_dx", Nome = "Gradiente concentração", Descricao = "dC/dx", Unidade = "mol/m⁴", ValorPadrao = 1000, ValorMin = -1e10, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double D = inputs["D"];
                double dC_dx = inputs["dC_dx"];
                
                return -D * dC_dx;
            }
        };
    }

    public static Formula V8_MAT129_DifusaoFick2()
    {
        return new Formula
        {
            Id = "V8-MAT129",
            CodigoCompendio = "129",
            Nome = "2ª Lei de Fick — Difusão Transiente",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Difusão",
            Expressao = "dC/dt = D * d²C/dx²",
            ExprTexto = "Equação difusão",
            Descricao = "Não-estacionário. Solução: C(x,t)=Cs+(C0-Cs)·erf(x/(2√Dt)) (semi-infinito).",
            Criador = "Adolf Fick",
            AnoOrigin = "1855",
            ExemploPratico = "Carburização aço: Cs=1,2%C, C0=0,2%C, D=2e-11m²/s, t=10h → perfil C(x)",
            Unidades = "mol/m³/s",
            VariavelResultado = "dC_dt_approx",
            UnidadeResultado = "mol/m³/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "D", Nome = "Coef. difusão", Descricao = "D", Unidade = "m²/s", ValorPadrao = 2e-11, ValorMin = 1e-20, ValorMax = 1e-4, Obrigatoria = true },
                new() { Simbolo = "d2C_dx2", Nome = "d²C/dx²", Descricao = "Curvatura conc.", Unidade = "mol/m⁵", ValorPadrao = 1e6, ValorMin = -1e10, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double D = inputs["D"];
                double d2C_dx2 = inputs["d2C_dx2"];
                
                return D * d2C_dx2;
            }
        };
    }

    public static Formula V8_MAT130_EquacaoArrhenius_Difusao()
    {
        return new Formula
        {
            Id = "V8-MAT130",
            CodigoCompendio = "130",
            Nome = "Arrhenius — Coef. Difusão",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Difusão",
            Expressao = "D = D0 * exp(-Q / (R * T))",
            ExprTexto = "Dependência temperatura",
            Descricao = "D0=fator pré-exponencial (m²/s), Q=energia ativação (J/mol), R=8,314J/mol/K, T=temp (K).",
            Criador = "Arrhenius aplicado à difusão",
            AnoOrigin = "~1900s",
            ExemploPratico = "C em Fe-α: D0=6,2e-7m²/s, Q=80kJ/mol, T=900°C(1173K) → D≈1,5e-11m²/s",
            Unidades = "m²/s",
            VariavelResultado = "D",
            UnidadeResultado = "m²/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "D0", Nome = "Fator pré-exponencial", Descricao = "D0", Unidade = "m²/s", ValorPadrao = 6.2e-7, ValorMin = 1e-10, ValorMax = 1e-3, Obrigatoria = true },
                new() { Simbolo = "Q", Nome = "Energia ativação", Descricao = "Q", Unidade = "J/mol", ValorPadrao = 80000, ValorMin = 1000, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Const. gases", Descricao = "R", Unidade = "J/mol/K", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "K", ValorPadrao = 1173, ValorMin = 100, ValorMax = 3000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double D0 = inputs["D0"];
                double Q = inputs["Q"];
                double R = inputs["R"];
                double T = inputs["T"];
                
                return D0 * Math.Exp(-Q / (R * T));
            }
        };
    }

    public static Formula V8_MAT131_LeiBragg()
    {
        return new Formula
        {
            Id = "V8-MAT131",
            CodigoCompendio = "131",
            Nome = "Lei de Bragg — Difração de Raios X",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Cristalografia",
            Expressao = "n * λ = 2 * d * sin(θ)",
            ExprTexto = "Condição de difração",
            Descricao = "n=ordem, λ=comprimento onda (m), d=espaçamento interplanar (m), θ=ângulo incidência (rad).",
            Criador = "William Lawrence Bragg, William Henry Bragg",
            AnoOrigin = "1913",
            ExemploPratico = "Cu Kα: λ=0,154nm, d=0,2nm, n=1 → θ=sin⁻¹(0,385)≈22,6°. Determina estrutura cristalina",
            Unidades = "rad",
            VariavelResultado = "theta",
            UnidadeResultado = "rad",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Ordem difração", Descricao = "n", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "lambda", Nome = "Comprimento onda", Descricao = "λ", Unidade = "m", ValorPadrao = 1.54e-10, ValorMin = 1e-12, ValorMax = 1e-8, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Espaçamento d", Descricao = "d", Unidade = "m", ValorPadrao = 2e-10, ValorMin = 1e-11, ValorMax = 1e-8, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double lambda = inputs["lambda"];
                double d = inputs["d"];
                
                double sin_theta = (n * lambda) / (2 * d);
                if (sin_theta > 1) return double.NaN; // Sem difração
                
                return Math.Asin(sin_theta);
            }
        };
    }

    public static Formula V8_MAT132_EspacamentoInterplanar_Cubico()
    {
        return new Formula
        {
            Id = "V8-MAT132",
            CodigoCompendio = "132",
            Nome = "Espaçamento Interplanar — Sistema Cúbico",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Cristalografia",
            Expressao = "d_hkl = a / sqrt(h² + k² + l²)",
            ExprTexto = "Espaçamento (hkl)",
            Descricao = "a=parâmetro rede (m), (hkl)=índices Miller. Cúbico simples, BCC, FCC.",
            Criador = "Cristalografia",
            AnoOrigin = "~1900s",
            ExemploPratico = "Al (FCC): a=0,405nm, (111) → d=0,405/√3≈0,234nm. Cu: a=0,361nm",
            Unidades = "m",
            VariavelResultado = "d_hkl",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Parâmetro rede", Descricao = "a", Unidade = "m", ValorPadrao = 4.05e-10, ValorMin = 1e-11, ValorMax = 1e-8, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Índice h", Descricao = "h", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Índice k", Descricao = "k", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "l", Nome = "Índice l", Descricao = "l", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double h = inputs["h"];
                double k = inputs["k"];
                double l = inputs["l"];
                
                double denom = Math.Sqrt(h * h + k * k + l * l);
                if (denom == 0) return double.NaN;
                
                return a / denom;
            }
        };
    }

    public static Formula V8_MAT133_FatorEmpacotamento_FCC()
    {
        return new Formula
        {
            Id = "V8-MAT133",
            CodigoCompendio = "133",
            Nome = "Fator de Empacotamento Atômico — FCC",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Estruturas Cristalinas",
            Expressao = "APF = (n * (4/3) * π * r³) / a³",
            ExprTexto = "Fração volumétrica",
            Descricao = "n=átomos/célula (FCC: 4), r=raio atômico, a=parâmetro rede. FCC: a=2r√2.",
            Criador = "Cristalografia",
            AnoOrigin = "~1900s",
            ExemploPratico = "FCC: APF=0,74. BCC: APF=0,68. HCP: APF=0,74. FCC e HCP: máximo denso",
            Unidades = "adimensional",
            VariavelResultado = "APF",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Átomos/célula", Descricao = "n", Unidade = "", ValorPadrao = 4, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Raio atômico", Descricao = "r", Unidade = "m", ValorPadrao = 1.43e-10, ValorMin = 1e-11, ValorMax = 1e-9, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Parâmetro rede", Descricao = "a", Unidade = "m", ValorPadrao = 4.05e-10, ValorMin = 1e-11, ValorMax = 1e-8, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double r = inputs["r"];
                double a = inputs["a"];
                
                double volume_atoms = n * (4.0 / 3.0) * Math.PI * r * r * r;
                double volume_cell = a * a * a;
                
                return volume_atoms / volume_cell;
            }
        };
    }

    public static Formula V8_MAT134_DensidadeTeorica()
    {
        return new Formula
        {
            Id = "V8-MAT134",
            CodigoCompendio = "134",
            Nome = "Densidade Teórica de Cristal",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Propriedades",
            Expressao = "ρ = (n * A) / (Vc * NA)",
            ExprTexto = "Densidade calculada",
            Descricao = "n=átomos/célula, A=massa atômica (g/mol), Vc=volume célula (cm³), NA=Avogadro (6,022e23).",
            Criador = "Cristalografia",
            AnoOrigin = "~1900s",
            ExemploPratico = "Cu FCC: n=4, A=63,5g/mol, a=3,61Å → ρ≈8,93g/cm³. Experimental: ρ≈8,96g/cm³",
            Unidades = "g/cm³",
            VariavelResultado = "rho",
            UnidadeResultado = "g/cm³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Átomos/célula", Descricao = "n", Unidade = "", ValorPadrao = 4, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "Massa atômica", Descricao = "A", Unidade = "g/mol", ValorPadrao = 63.5, ValorMin = 1, ValorMax = 300, Obrigatoria = true },
                new() { Simbolo = "Vc", Nome = "Volume célula", Descricao = "Vc", Unidade = "cm³", ValorPadrao = 4.7e-23, ValorMin = 1e-30, ValorMax = 1e-20, Obrigatoria = true },
                new() { Simbolo = "NA", Nome = "Número Avogadro", Descricao = "NA", Unidade = "1/mol", ValorPadrao = 6.022e23, ValorMin = 6.022e23, ValorMax = 6.022e23, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double A = inputs["A"];
                double Vc = inputs["Vc"];
                double NA = inputs["NA"];
                
                return (n * A) / (Vc * NA);
            }
        };
    }

    public static Formula V8_MAT135_RegrasHumeRothery()
    {
        return new Formula
        {
            Id = "V8-MAT135",
            CodigoCompendio = "135",
            Nome = "Regra de Hume-Rothery — Solubilidade Sólida",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Ligas e Fases",
            Expressao = "Δr = (|r_soluto - r_solvente| / r_solvente) * 100%",
            ExprTexto = "Diferença raio atômico",
            Descricao = "Δr<15%: alta solubilidade. Também: valência, eletronegatividade, estrutura cristalina.",
            Criador = "William Hume-Rothery",
            AnoOrigin = "1926",
            ExemploPratico = "Cu (r=1,28Å) + Ni (r=1,25Å): Δr≈2,3% → solúvel (bronze níquel). Zn: 33% → limitado",
            Unidades = "%",
            VariavelResultado = "delta_r",
            UnidadeResultado = "%",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "r_soluto", Nome = "Raio soluto", Descricao = "r_soluto", Unidade = "Å", ValorPadrao = 1.25, ValorMin = 0.5, ValorMax = 3, Obrigatoria = true },
                new() { Simbolo = "r_solvente", Nome = "Raio solvente", Descricao = "r_solvente", Unidade = "Å", ValorPadrao = 1.28, ValorMin = 0.5, ValorMax = 3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double r_soluto = inputs["r_soluto"];
                double r_solvente = inputs["r_solvente"];
                
                return Math.Abs(r_soluto - r_solvente) / r_solvente * 100;
            }
        };
    }

    public static Formula V8_MAT136_EquacaoGibbs_Fase()
    {
        return new Formula
        {
            Id = "V8-MAT136",
            CodigoCompendio = "136",
            Nome = "Regra das Fases de Gibbs",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Equilíbrio de Fases",
            Expressao = "F = C - P + 2",
            ExprTexto = "Graus de liberdade",
            Descricao = "F=liberdade, C=componentes, P=fases. Pressão e temperatura constantes: F=C-P+1.",
            Criador = "Josiah Willard Gibbs",
            AnoOrigin = "1876",
            ExemploPratico = "H2O: C=1. Vapor: P=1 → F=2 (T,P). Sólido+líquido+vapor: P=3 → F=0 (ponto triplo)",
            Unidades = "adimensional",
            VariavelResultado = "F",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C", Nome = "Componentes", Descricao = "C", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "P", Nome = "Fases", Descricao = "P", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C = inputs["C"];
                double P = inputs["P"];
                
                return C - P + 2;
            }
        };
    }

    public static Formula V8_MAT137_RegraAlavanca()
    {
        return new Formula
        {
            Id = "V8-MAT137",
            CodigoCompendio = "137",
            Nome = "Regra da Alavanca — Diagrama de Fases",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Equilíbrio de Fases",
            Expressao = "Wα = (C0 - CL) / (Cα - CL); WL = (Cα - C0) / (Cα - CL)",
            ExprTexto = "Fração de fases",
            Descricao = "Wα, WL=frações massa α e líquido. C0=comp. global, Cα,CL=comp. fases no tie-line.",
            Criador = "Termodinâmica de fases",
            AnoOrigin = "~1900s",
            ExemploPratico = "Liga Pb-Sn: C0=40%Sn, T=200°C. α: 18%Sn, L: 62%Sn → Wα=0,5, WL=0,5",
            Unidades = "fração",
            VariavelResultado = "W_alpha",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C0", Nome = "Composição global", Descricao = "C0", Unidade = "%", ValorPadrao = 40, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "CL", Nome = "Comp. líquido", Descricao = "CL", Unidade = "%", ValorPadrao = 62, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "C_alpha", Nome = "Comp. fase α", Descricao = "Cα", Unidade = "%", ValorPadrao = 18, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C0 = inputs["C0"];
                double CL = inputs["CL"];
                double C_alpha = inputs["C_alpha"];
                
                double denom = C_alpha - CL;
                if (Math.Abs(denom) < 1e-6) return double.NaN;
                
                return (C0 - CL) / denom;
            }
        };
    }

    public static Formula V8_MAT138_EquacaoScheil()
    {
        return new Formula
        {
            Id = "V8-MAT138",
            CodigoCompendio = "138",
            Nome = "Equação de Scheil — Solidificação Não-Equilibrada",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Solidificação",
            Expressao = "Cs = k * C0 * (1 - fs)^(k-1)",
            ExprTexto = "Segregação",
            Descricao = "Cs=comp. sólido, k=coef. partição, C0=comp. inicial, fs=fração solidificada.",
            Criador = "Erich Scheil",
            AnoOrigin = "1942",
            ExemploPratico = "k=0,3, C0=1%Si, fs=0,5 → Cs≈0,21%Si. Resfriamento rápido: sem difusão no sólido",
            Unidades = "%",
            VariavelResultado = "Cs",
            UnidadeResultado = "%",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Coef. partição", Descricao = "k", Unidade = "", ValorPadrao = 0.3, ValorMin = 0.01, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "C0", Nome = "Comp. inicial", Descricao = "C0", Unidade = "%", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "fs", Nome = "Fração solidificada", Descricao = "fs", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double C0 = inputs["C0"];
                double fs = inputs["fs"];
                
                return k * C0 * Math.Pow(1 - fs, k - 1);
            }
        };
    }

    public static Formula V8_MAT139_EquacaoHallPetch()
    {
        return new Formula
        {
            Id = "V8-MAT139",
            CodigoCompendio = "139",
            Nome = "Relação de Hall-Petch — Endurecimento por Grão",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Propriedades Mecânicas",
            Expressao = "σy = σ0 + k * d^(-1/2)",
            ExprTexto = "Tensão de escoamento",
            Descricao = "σy=limite escoamento (Pa), σ0=tensão fricção (Pa), k=constante (Pa·m^1/2), d=tamanho grão (m).",
            Criador = "Hall (1951), Petch (1953)",
            AnoOrigin = "1951, 1953",
            ExemploPratico = "Aço: σ0=70MPa, k=0,74MPa·m^1/2, d=10μm → σy≈304MPa. Grão fino: maior resistência",
            Unidades = "Pa",
            VariavelResultado = "sigma_y",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sigma_0", Nome = "Tensão fricção", Descricao = "σ0", Unidade = "Pa", ValorPadrao = 70e6, ValorMin = 1e6, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Constante Hall-Petch", Descricao = "k", Unidade = "Pa·m^1/2", ValorPadrao = 0.74e6, ValorMin = 0, ValorMax = 10e6, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Tamanho grão", Descricao = "d", Unidade = "m", ValorPadrao = 10e-6, ValorMin = 1e-9, ValorMax = 1e-3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sigma_0 = inputs["sigma_0"];
                double k = inputs["k"];
                double d = inputs["d"];
                
                return sigma_0 + k * Math.Pow(d, -0.5);
            }
        };
    }

    public static Formula V8_MAT140_DurezaBrinell()
    {
        return new Formula
        {
            Id = "V8-MAT140",
            CodigoCompendio = "140",
            Nome = "Dureza Brinell",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Propriedades Mecânicas",
            Expressao = "HB = (2*P) / (π*D*(D - sqrt(D² - d²)))",
            ExprTexto = "Número Brinell",
            Descricao = "P=carga (N), D=diâmetro esfera (mm), d=diâmetro impressão (mm). HB≈3,0·σy (aço).",
            Criador = "Johan August Brinell",
            AnoOrigin = "1900",
            ExemploPratico = "P=3000N, D=10mm, d=4mm → HB≈127. Vickers: HV=1,854·P/d². Rockwell: escalas",
            Unidades = "HB",
            VariavelResultado = "HB",
            UnidadeResultado = "HB",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "Carga", Descricao = "P", Unidade = "N", ValorPadrao = 3000, ValorMin = 10, ValorMax = 30000, Obrigatoria = true },
                new() { Simbolo = "D", Nome = "Diâmetro esfera", Descricao = "D", Unidade = "mm", ValorPadrao = 10, ValorMin = 1, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Diâmetro impressão", Descricao = "d", Unidade = "mm", ValorPadrao = 4, ValorMin = 0.1, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double D = inputs["D"];
                double d = inputs["d"];
                
                double area = Math.PI * D * (D - Math.Sqrt(D * D - d * d));
                
                return (2 * P) / area;
            }
        };
    }

    public static Formula V8_MAT141_EquacaoCoffin_Manson()
    {
        return new Formula
        {
            Id = "V8-MAT141",
            CodigoCompendio = "141",
            Nome = "Coffin-Manson — Fadiga de Baixo Ciclo",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Fadiga",
            Expressao = "Δεp / 2 = εf' * (2*Nf)^c",
            ExprTexto = "Deformação plástica",
            Descricao = "Δεp/2=amplitude deform. plástica, Nf=ciclos até falha, εf'=coef. ductilidade, c≈-0,5 a -0,7.",
            Criador = "Coffin (1954), Manson (1953)",
            AnoOrigin = "1953, 1954",
            ExemploPratico = "εf'=0,5, c=-0,6, Nf=1000 → Δεp/2≈0,0079. Baixo ciclo: Δε>0,001. Alto: S-N curve",
            Unidades = "adimensional",
            VariavelResultado = "delta_eps_p_half",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "eps_f_prime", Nome = "Coef. ductilidade", Descricao = "εf'", Unidade = "", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "Nf", Nome = "Ciclos até falha", Descricao = "Nf", Unidade = "", ValorPadrao = 1000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Expoente c", Descricao = "c", Unidade = "", ValorPadrao = -0.6, ValorMin = -1, ValorMax = 0, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double eps_f_prime = inputs["eps_f_prime"];
                double Nf = inputs["Nf"];
                double c = inputs["c"];
                
                return eps_f_prime * Math.Pow(2 * Nf, c);
            }
        };
    }

    public static Formula V8_MAT142_TaxaCrescimentoFadiga_Paris()
    {
        return new Formula
        {
            Id = "V8-MAT142",
            CodigoCompendio = "142",
            Nome = "Lei de Paris — Propagação de Trinca por Fadiga",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Fadiga",
            Expressao = "da/dN = C * (ΔK)^m",
            ExprTexto = "Taxa crescimento trinca",
            Descricao = "da/dN=crescimento/ciclo (m/ciclo), ΔK=variação fator intensidade tensão (Pa·m^1/2), C,m: constantes.",
            Criador = "Paul Paris",
            AnoOrigin = "1963",
            ExemploPratico = "Aço: C=1e-11, m=3, ΔK=20MPa·√m → da/dN=8e-6mm/ciclo. m típico: 2-4",
            Unidades = "m/ciclo",
            VariavelResultado = "da_dN",
            UnidadeResultado = "m/ciclo",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C", Nome = "Constante C", Descricao = "C", Unidade = "", ValorPadrao = 1e-11, ValorMin = 1e-15, ValorMax = 1e-8, Obrigatoria = true },
                new() { Simbolo = "delta_K", Nome = "ΔK", Descricao = "ΔK", Unidade = "Pa·m^1/2", ValorPadrao = 20e6, ValorMin = 1e6, ValorMax = 1e8, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "Expoente m", Descricao = "m", Unidade = "", ValorPadrao = 3, ValorMin = 1, ValorMax = 6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C = inputs["C"];
                double delta_K = inputs["delta_K"];
                double m = inputs["m"];
                
                return C * Math.Pow(delta_K, m);
            }
        };
    }

    public static Formula V8_MAT143_FluidezFundido()
    {
        return new Formula
        {
            Id = "V8-MAT143",
            CodigoCompendio = "143",
            Nome = "Fluidez de Metal Fundido — Empirical",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Fundição",
            Expressao = "L = k * sqrt((Tp - Tmold) / μ)",
            ExprTexto = "Comprimento fluido",
            Descricao = "L=comprimento (m), Tp=temp. pouring (K), Tmold=temp. molde (K), μ=viscosidade (Pa·s), k: empírico.",
            Criador = "Fundição empírica",
            AnoOrigin = "~1950s",
            ExemploPratico = "Al: Tp=973K, Tmold=573K, μ=0,001Pa·s, k=0,1 → L≈2m. Fluidez: importante para peças finas",
            Unidades = "m",
            VariavelResultado = "L",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Constante k", Descricao = "k", Unidade = "", ValorPadrao = 0.1, ValorMin = 0.01, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "Tp", Nome = "Temp. pouring", Descricao = "Tp", Unidade = "K", ValorPadrao = 973, ValorMin = 300, ValorMax = 3000, Obrigatoria = true },
                new() { Simbolo = "Tmold", Nome = "Temp. molde", Descricao = "Tmold", Unidade = "K", ValorPadrao = 573, ValorMin = 300, ValorMax = 2000, Obrigatoria = true },
                new() { Simbolo = "mu", Nome = "Viscosidade", Descricao = "μ", Unidade = "Pa·s", ValorPadrao = 0.001, ValorMin = 1e-6, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double Tp = inputs["Tp"];
                double Tmold = inputs["Tmold"];
                double mu = inputs["mu"];
                
                return k * Math.Sqrt((Tp - Tmold) / mu);
            }
        };
    }

    public static Formula V8_MAT144_ModuloVolumetrico()
    {
        return new Formula
        {
            Id = "V8-MAT144",
            CodigoCompendio = "144",
            Nome = "Módulo Volumétrico (Bulk Modulus)",
            Categoria = "Ciência de Materiais",
            SubCategoria = "Propriedades Elásticas",
            Expressao = "K = E / (3 * (1 - 2*ν))",
            ExprTexto = "Módulo volumétrico",
            Descricao = "K=bulk modulus (Pa), E=Young (Pa), ν=Poisson. K=resistência à compressão hidrostática.",
            Criador = "Teoria elasticidade",
            AnoOrigin = "~1800s",
            ExemploPratico = "Aço: E=200GPa, ν=0,3 → K≈167GPa. Diamante: K≈540GPa (incompressível). Água: K≈2,2GPa",
            Unidades = "Pa",
            VariavelResultado = "K",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E", Nome = "Módulo de Young", Descricao = "E", Unidade = "Pa", ValorPadrao = 200e9, ValorMin = 1e6, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "nu", Nome = "Coef. Poisson", Descricao = "ν", Unidade = "", ValorPadrao = 0.3, ValorMin = -1, ValorMax = 0.5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E = inputs["E"];
                double nu = inputs["nu"];
                
                return E / (3 * (1 - 2 * nu));
            }
        };
    }
}
