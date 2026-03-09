using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE I: QUÍMICA ANALÍTICA E FÍSICO-QUÍMICA
    // Equilíbrio, cinética, eletroquímica e termodinâmica química
    // 21 fórmulas (001-021)
    // ========================================

    public static Formula V8_QA001_EquacaoNernst()
    {
        return new Formula
        {
            Id = "V8-QA001",
            CodigoCompendio = "001",
            Nome = "Equação de Nernst",
            Categoria = "Química Analítica",
            SubCategoria = "Eletroquímica",
            Expressao = "E = E° - (R*T/(n*F)) * ln(Q)",
            ExprTexto = "Potencial de eletrodo em função da composição",
            Descricao = "Potencial de eletrodo em função da composição da solução. A 25°C simplifica para E=E°-(0,0592/n)·log Q. Fundamental para pH metros e células eletroquímicas.",
            Criador = "Walther Nernst",
            AnoOrigin = "1889",
            ExemploPratico = "Cu²⁺/Cu: E°=0,34V, [Cu²⁺]=0,01M → E=0,34-0,0296×2=0,28V. pH metro: E=cte-0,0592·pH a 25°C",
            Unidades = "V (volts)",
            VariavelResultado = "E",
            UnidadeResultado = "V",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E0", Nome = "Potencial padrão", Descricao = "Potencial padrão do eletrodo", Unidade = "V", ValorPadrao = 0.34, ValorMin = -5, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal dos gases", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 298.15, ValorMin = 0, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Elétrons transferidos", Descricao = "Número de elétrons na reação", Unidade = "", ValorPadrao = 2, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "F", Nome = "Constante de Faraday", Descricao = "Carga de 1 mol de elétrons", Unidade = "C/mol", ValorPadrao = 96485, ValorMin = 96485, ValorMax = 96485, Obrigatoria = true },
                new() { Simbolo = "Q", Nome = "Quociente reacional", Descricao = "Razão produtos/reagentes", Unidade = "", ValorPadrao = 0.01, ValorMin = 1e-10, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E0 = inputs["E0"];
                double R = inputs["R"];
                double T = inputs["T"];
                double n = inputs["n"];
                double F = inputs["F"];
                double Q = inputs["Q"];
                return E0 - (R * T / (n * F)) * Math.Log(Q);
            }
        };
    }

    public static Formula V8_QA002_LeiBeerLambert()
    {
        return new Formula
        {
            Id = "V8-QA002",
            CodigoCompendio = "002",
            Nome = "Lei de Beer-Lambert",
            Categoria = "Química Analítica",
            SubCategoria = "Espectrofotometria",
            Expressao = "A = ε * c * l",
            ExprTexto = "Absorbância proporcional à concentração",
            Descricao = "Absorbância proporcional à concentração c e ao caminho óptico l. Válida para A<1,5 (soluções diluídas). Fundamental em análise quantitativa.",
            Criador = "Beer, Lambert",
            AnoOrigin = "1852",
            ExemploPratico = "ε=8600 L·mol⁻¹·cm⁻¹, l=1cm, A=0,43 → c=5×10⁻⁵mol/L. Proteína a 280nm: ε≈50.000 L·mol⁻¹·cm⁻¹",
            Unidades = "adimensional",
            VariavelResultado = "A",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "epsilon", Nome = "Absortividade molar", Descricao = "Coeficiente de extinção molar", Unidade = "L/(mol·cm)", ValorPadrao = 8600, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Concentração", Descricao = "Concentração molar da solução", Unidade = "mol/L", ValorPadrao = 5e-5, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "l", Nome = "Caminho óptico", Descricao = "Comprimento da cubeta", Unidade = "cm", ValorPadrao = 1, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double epsilon = inputs["epsilon"];
                double c = inputs["c"];
                double l = inputs["l"];
                return epsilon * c * l;
            }
        };
    }

    public static Formula V8_QA003_ProdutoSolubilidade()
    {
        return new Formula
        {
            Id = "V8-QA003",
            CodigoCompendio = "003",
            Nome = "Produto de Solubilidade",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrio Iônico",
            Expressao = "Ksp = [M^n+]^a * [X^n-]^b",
            ExprTexto = "Constante de solubilidade",
            Descricao = "Equilíbrio de dissolução de sal pouco solúvel MₐXᵦ ⇌ aM + bX. Permite calcular solubilidade molar.",
            Criador = "Wilhelm Ostwald",
            AnoOrigin = "1890",
            ExemploPratico = "BaSO₄: Ksp=1,1×10⁻¹⁰ → [Ba²⁺]=√(Ksp)=1,05×10⁻⁵mol/L. Precipitação seletiva de íons metálicos",
            Unidades = "(mol/L)^(a+b)",
            VariavelResultado = "S",
            UnidadeResultado = "mol/L",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Ksp", Nome = "Produto de solubilidade", Descricao = "Constante de solubilidade", Unidade = "", ValorPadrao = 1.1e-10, ValorMin = 1e-50, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Coeficiente cátion", Descricao = "Número de cátion na fórmula", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Coeficiente ânion", Descricao = "Número de ânion na fórmula", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Ksp = inputs["Ksp"];
                double a = inputs["a"];
                double b = inputs["b"];
                // Para M_a X_b: S = (Ksp / (a^a * b^b))^(1/(a+b))
                double den = Math.Pow(a, a) * Math.Pow(b, b);
                return Math.Pow(Ksp / den, 1.0 / (a + b));
            }
        };
    }

    public static Formula V8_QA004_EquacaoArrhenius()
    {
        return new Formula
        {
            Id = "V8-QA004",
            CodigoCompendio = "004",
            Nome = "Equação de Arrhenius",
            Categoria = "Química Analítica",
            SubCategoria = "Cinética Química",
            Expressao = "k = A * exp(-Ea / (R*T))",
            ExprTexto = "Constante de velocidade vs temperatura",
            Descricao = "Constante de velocidade de reação vs temperatura. Lineariza: ln k = ln A - Ea/RT. Ea da inclinação.",
            Criador = "Svante Arrhenius",
            AnoOrigin = "1889",
            ExemploPratico = "Ea=50kJ/mol: k dobra a cada ~10°C perto de 25°C (regra de van't Hoff). Pasteurização: destruição rápida em T alta",
            Unidades = "depende da ordem",
            VariavelResultado = "k",
            UnidadeResultado = "s⁻¹ ou L/(mol·s)",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "Fator pré-exponencial", Descricao = "Frequência de colisões", Unidade = "s⁻¹", ValorPadrao = 1e13, ValorMin = 1, ValorMax = 1e20, Obrigatoria = true },
                new() { Simbolo = "Ea", Nome = "Energia de ativação", Descricao = "Barreira energética", Unidade = "J/mol", ValorPadrao = 50000, ValorMin = 0, ValorMax = 500000, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 298.15, ValorMin = 0, ValorMax = 2000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double Ea = inputs["Ea"];
                double R = inputs["R"];
                double T = inputs["T"];
                return A * Math.Exp(-Ea / (R * T));
            }
        };
    }

    public static Formula V8_QA005_LeiVelocidadeReacao()
    {
        return new Formula
        {
            Id = "V8-QA005",
            CodigoCompendio = "005",
            Nome = "Lei da Velocidade de Reação",
            Categoria = "Química Analítica",
            SubCategoria = "Cinética Química",
            Expressao = "v = k * [A]^m * [B]^n",
            ExprTexto = "Taxa de reação vs concentrações",
            Descricao = "Taxa de reação proporcional às concentrações com ordens m e n (determinadas experimentalmente).",
            Criador = "Guldberg e Waage",
            AnoOrigin = "1864",
            ExemploPratico = "2NO+O₂→2NO₂: v=k[NO]²[O₂] (3ª ordem total). Hidrólise de sacarose: pseudo-1ª ordem em H₂O",
            Unidades = "mol/(L·s)",
            VariavelResultado = "v",
            UnidadeResultado = "mol/(L·s)",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Constante de velocidade", Descricao = "Constante cinética", Unidade = "varia", ValorPadrao = 0.1, ValorMin = 1e-10, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "Concentração de A", Descricao = "Concentração do reagente A", Unidade = "mol/L", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "Ordem em A", Descricao = "Ordem de reação em A", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 3, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Concentração de B", Descricao = "Concentração do reagente B", Unidade = "mol/L", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Ordem em B", Descricao = "Ordem de reação em B", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double A = inputs["A"];
                double m = inputs["m"];
                double B = inputs["B"];
                double n = inputs["n"];
                return k * Math.Pow(A, m) * Math.Pow(B, n);
            }
        };
    }

    public static Formula V8_QA006_LeiHess()
    {
        return new Formula
        {
            Id = "V8-QA006",
            CodigoCompendio = "006",
            Nome = "Lei de Hess",
            Categoria = "Química Analítica",
            SubCategoria = "Termoquímica",
            Expressao = "ΔH_reacao = Σ ΔHf(prod) - Σ ΔHf(reat)",
            ExprTexto = "Entalpia independente do caminho",
            Descricao = "Entalpia total independente do caminho (função de estado). Combinar equações termoquímicas algebricamente.",
            Criador = "Germain Hess",
            AnoOrigin = "1840",
            ExemploPratico = "Combustão da glicose: ΔH=6(-393,5)+6(-285,8)-(-1274)=-2802kJ/mol. Formação do NH₃: -92kJ/mol",
            Unidades = "kJ/mol",
            VariavelResultado = "ΔH",
            UnidadeResultado = "kJ/mol",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "DHf_prod", Nome = "Entalpia de formação produtos", Descricao = "Soma de ΔHf dos produtos", Unidade = "kJ/mol", ValorPadrao = -1000, ValorMin = -10000, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "DHf_reat", Nome = "Entalpia de formação reagentes", Descricao = "Soma de ΔHf dos reagentes", Unidade = "kJ/mol", ValorPadrao = -500, ValorMin = -10000, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double DHf_prod = inputs["DHf_prod"];
                double DHf_reat = inputs["DHf_reat"];
                return DHf_prod - DHf_reat;
            }
        };
    }

    public static Formula V8_QA007_PressaoOsmotica()
    {
        return new Formula
        {
            Id = "V8-QA007",
            CodigoCompendio = "007",
            Nome = "Pressão Osmótica de van't Hoff",
            Categoria = "Química Analítica",
            SubCategoria = "Propriedades Coligativas",
            Expressao = "π = i * c * R * T",
            ExprTexto = "Pressão osmótica de solução",
            Descricao = "Pressão osmótica de solução diluída. i=fator de dissociação (NaCl: i≈2). Osmose reversa e diálise.",
            Criador = "Jacobus van't Hoff",
            AnoOrigin = "1887",
            ExemploPratico = "Soro fisiológico NaCl 0,9%: c=0,154M, i=2, T=310K → π≈793kPa≈7,7atm. Membranas RO: pressão de operação",
            Unidades = "Pa",
            VariavelResultado = "π",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "i", Nome = "Fator de van't Hoff", Descricao = "Fator de dissociação", Unidade = "", ValorPadrao = 2, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Concentração", Descricao = "Concentração molar", Unidade = "mol/L", ValorPadrao = 0.154, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 310, ValorMin = 0, ValorMax = 500, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double i = inputs["i"];
                double c = inputs["c"];
                double R = inputs["R"];
                double T = inputs["T"];
                return i * c * R * T * 1000; // Convertendo para Pa (c em mol/L)
            }
        };
    }

    public static Formula V8_QA008_ConstanteEquilibrio()
    {
        return new Formula
        {
            Id = "V8-QA008",
            CodigoCompendio = "008",
            Nome = "Constante de Equilíbrio Kc",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrio Químico",
            Expressao = "Kc = [produtos]^p / [reagentes]^r",
            ExprTexto = "Razão produtos/reagentes no equilíbrio",
            Descricao = "ΔG°=-RT·ln K. K>1: produtos favorecidos. K<10⁻³: reação praticamente não ocorre.",
            Criador = "Guldberg e Waage",
            AnoOrigin = "1864",
            ExemploPratico = "H₂+I₂ ⇌ 2HI: Kc=53 a 450°C → ΔG°=-9,8kJ/mol. Síntese de amônia: K alto mas cinética lenta",
            Unidades = "varia com reação",
            VariavelResultado = "Kc",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "prod", Nome = "Concentração produtos", Descricao = "Produto das [produtos]^coef", Unidade = "mol/L", ValorPadrao = 4, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "reag", Nome = "Concentração reagentes", Descricao = "Produto das [reagentes]^coef", Unidade = "mol/L", ValorPadrao = 1, ValorMin = 1e-10, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double prod = inputs["prod"];
                double reag = inputs["reag"];
                return prod / reag;
            }
        };
    }

    public static Formula V8_QA009_pH_Acido_Base()
    {
        return new Formula
        {
            Id = "V8-QA009",
            CodigoCompendio = "009",
            Nome = "pH de Ácido e Base Fortes",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrio Ácido-Base",
            Expressao = "pH = -log[H+]",
            ExprTexto = "Escala de acidez",
            Descricao = "Ácido forte: [H⁺]=C. Base forte: [OH⁻]=C, pH=14+log[OH⁻]. Kw=10⁻¹⁴ a 25°C.",
            Criador = "Søren Sørensen",
            AnoOrigin = "1909",
            ExemploPratico = "HCl 0,01M: pH=2. NaOH 0,1M: pH=13. Sangue arterial: pH=7,40±0,05 (regulado por tampão bicarbonato)",
            Unidades = "adimensional",
            VariavelResultado = "pH",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "H", Nome = "Concentração de H+", Descricao = "Concentração de íons H+", Unidade = "mol/L", ValorPadrao = 0.01, ValorMin = 1e-14, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double H = inputs["H"];
                return -Math.Log10(H);
            }
        };
    }

    public static Formula V8_QA010_EletroliseFaraday()
    {
        return new Formula
        {
            Id = "V8-QA010",
            CodigoCompendio = "010",
            Nome = "Eletrólise — Lei de Faraday",
            Categoria = "Química Analítica",
            SubCategoria = "Eletroquímica",
            Expressao = "m = (M * I * t) / (n * F)",
            ExprTexto = "Massa depositada em eletrólise",
            Descricao = "Massa depositada em eletrólise. M=molar, I=corrente, t=tempo, n=elétrons, F=96485C/mol.",
            Criador = "Michael Faraday",
            AnoOrigin = "1833",
            ExemploPratico = "Eletrodeposição de Cu: M=63,5g/mol, n=2, I=2A, t=3600s → m=2,37g. Galvanoplastia industrial",
            Unidades = "g",
            VariavelResultado = "m",
            UnidadeResultado = "g",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "M", Nome = "Massa molar", Descricao = "Massa molar do elemento", Unidade = "g/mol", ValorPadrao = 63.5, ValorMin = 1, ValorMax = 300, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente", Descricao = "Corrente elétrica", Unidade = "A", ValorPadrao = 2, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo de eletrólise", Unidade = "s", ValorPadrao = 3600, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Elétrons", Descricao = "Número de elétrons", Unidade = "", ValorPadrao = 2, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "F", Nome = "Constante de Faraday", Descricao = "Carga de 1 mol de elétrons", Unidade = "C/mol", ValorPadrao = 96485, ValorMin = 96485, ValorMax = 96485, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double M = inputs["M"];
                double I = inputs["I"];
                double t = inputs["t"];
                double n = inputs["n"];
                double F = inputs["F"];
                return (M * I * t) / (n * F);
            }
        };
    }

    public static Formula V8_QA011_GibbsEspontaneidade()
    {
        return new Formula
        {
            Id = "V8-QA011",
            CodigoCompendio = "011",
            Nome = "Gibbs — Espontaneidade",
            Categoria = "Química Analítica",
            SubCategoria = "Termodinâmica",
            Expressao = "ΔG = ΔH - T*ΔS",
            ExprTexto = "Energia livre de Gibbs",
            Descricao = "ΔG<0: espontâneo. ΔG=0: equilíbrio. ΔG=ΔG°+RT·ln Q. ΔG°=-RT·ln K.",
            Criador = "Josiah Gibbs",
            AnoOrigin = "1876",
            ExemploPratico = "Combustão: ΔH=-890kJ/mol, ΔS=+3J/(mol·K) a 298K → ΔG=-890,9kJ/mol. Sempre espontânea",
            Unidades = "J/mol",
            VariavelResultado = "ΔG",
            UnidadeResultado = "J/mol",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "DH", Nome = "Variação de entalpia", Descricao = "Calor da reação", Unidade = "J/mol", ValorPadrao = -890000, ValorMin = -1e7, ValorMax = 1e7, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 298, ValorMin = 0, ValorMax = 2000, Obrigatoria = true },
                new() { Simbolo = "DS", Nome = "Variação de entropia", Descricao = "Mudança de desordem", Unidade = "J/(mol·K)", ValorPadrao = 3, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double DH = inputs["DH"];
                double T = inputs["T"];
                double DS = inputs["DS"];
                return DH - T * DS;
            }
        };
    }

    public static Formula V8_QA012_ClausiusClapeyron()
    {
        return new Formula
        {
            Id = "V8-QA012",
            CodigoCompendio = "012",
            Nome = "Clausius-Clapeyron",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrios de Fase",
            Expressao = "ln(p2/p1) = -(ΔHvap/R) * (1/T2 - 1/T1)",
            ExprTexto = "Pressão de vapor vs temperatura",
            Descricao = "Pressão de vapor vs temperatura. Determina ΔHvap de medidas de pressão de ebulição.",
            Criador = "Clausius, Clapeyron",
            AnoOrigin = "1850",
            ExemploPratico = "Água: p₁=1atm a 100°C, ΔHvap=40,7kJ/mol. Calcular p a 80°C → 0,467atm. Destilação",
            Unidades = "adimensional",
            VariavelResultado = "ln_ratio",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "DHvap", Nome = "Entalpia de vaporização", Descricao = "Calor de vaporização", Unidade = "J/mol", ValorPadrao = 40700, ValorMin = 0, ValorMax = 200000, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T1", Nome = "Temperatura inicial", Descricao = "Primeira temperatura", Unidade = "K", ValorPadrao = 373.15, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "T2", Nome = "Temperatura final", Descricao = "Segunda temperatura", Unidade = "K", ValorPadrao = 353.15, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double DHvap = inputs["DHvap"];
                double R = inputs["R"];
                double T1 = inputs["T1"];
                double T2 = inputs["T2"];
                return -(DHvap / R) * (1.0 / T2 - 1.0 / T1);
            }
        };
    }

    public static Formula V8_QA013_GrauDissociacao()
    {
        return new Formula
        {
            Id = "V8-QA013",
            CodigoCompendio = "013",
            Nome = "Grau de Dissociação de Ácido Fraco",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrio Ácido-Base",
            Expressao = "α = sqrt(Ka/C)",
            ExprTexto = "Fração dissociada",
            Descricao = "Fração dissociada. pH de ácido fraco: [H⁺]=√(Ka·C).",
            Criador = "Wilhelm Ostwald",
            AnoOrigin = "1888",
            ExemploPratico = "CH₃COOH 0,1M: Ka=1,8×10⁻⁵ → α=0,0134=1,34%. [H⁺]=1,34×10⁻³M → pH=2,87",
            Unidades = "adimensional",
            VariavelResultado = "α",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Ka", Nome = "Constante de acidez", Descricao = "Constante de dissociação", Unidade = "", ValorPadrao = 1.8e-5, ValorMin = 1e-20, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "C", Nome = "Concentração", Descricao = "Concentração inicial", Unidade = "mol/L", ValorPadrao = 0.1, ValorMin = 1e-10, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Ka = inputs["Ka"];
                double C = inputs["C"];
                return Math.Sqrt(Ka / C);
            }
        };
    }

    public static Formula V8_QA014_DebyeHuckel()
    {
        return new Formula
        {
            Id = "V8-QA014",
            CodigoCompendio = "014",
            Nome = "Equação de Debye-Hückel",
            Categoria = "Química Analítica",
            SubCategoria = "Eletroquímica",
            Expressao = "log(γ±) = -A * |z+ * z-| * sqrt(I)",
            ExprTexto = "Coeficiente de atividade",
            Descricao = "Coeficiente de atividade de eletrólito forte em solução diluída. I=força iônica.",
            Criador = "Debye e Hückel",
            AnoOrigin = "1923",
            ExemploPratico = "NaCl 0,01M: I=0,01, A=0,509 → log γ±=-0,051 → γ±=0,889. Células eletroquímicas precisas",
            Unidades = "adimensional",
            VariavelResultado = "log_gamma",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "Constante de Debye-Hückel", Descricao = "Constante do solvente", Unidade = "", ValorPadrao = 0.509, ValorMin = 0, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "z_pos", Nome = "Carga do cátion", Descricao = "Valência do cátion", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 4, Obrigatoria = true },
                new() { Simbolo = "z_neg", Nome = "Carga do ânion", Descricao = "Valência do ânion", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 4, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Força iônica", Descricao = "Força iônica da solução", Unidade = "mol/L", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double z_pos = inputs["z_pos"];
                double z_neg = inputs["z_neg"];
                double I = inputs["I"];
                return -A * Math.Abs(z_pos * z_neg) * Math.Sqrt(I);
            }
        };
    }

    public static Formula V8_QA015_Cinetica1aOrdem()
    {
        return new Formula
        {
            Id = "V8-QA015",
            CodigoCompendio = "015",
            Nome = "Cinética de 1ª Ordem",
            Categoria = "Química Analítica",
            SubCategoria = "Cinética Química",
            Expressao = "[A]t = [A]0 * exp(-k*t)",
            ExprTexto = "Concentração em função do tempo",
            Descricao = "Integração da lei de velocidade de 1ª ordem. t½ = ln2/k independe da concentração inicial.",
            Criador = "Wilhelmy",
            AnoOrigin = "1850",
            ExemploPratico = "Decomposição do H₂O₂: k=0,001/s → t½=693s≈12min. Carbono-14: t½=5730 anos",
            Unidades = "mol/L",
            VariavelResultado = "[A]t",
            UnidadeResultado = "mol/L",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A0", Nome = "Concentração inicial", Descricao = "[A] em t=0", Unidade = "mol/L", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Constante de velocidade", Descricao = "Constante cinética", Unidade = "s⁻¹", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo decorrido", Unidade = "s", ValorPadrao = 693, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A0 = inputs["A0"];
                double k = inputs["k"];
                double t = inputs["t"];
                return A0 * Math.Exp(-k * t);
            }
        };
    }

    public static Formula V8_QA016_Cinetica2aOrdem()
    {
        return new Formula
        {
            Id = "V8-QA016",
            CodigoCompendio = "016",
            Nome = "Cinética de 2ª Ordem",
            Categoria = "Química Analítica",
            SubCategoria = "Cinética Química",
            Expressao = "1/[A]t = 1/[A]0 + k*t",
            ExprTexto = "Inverso da concentração vs tempo",
            Descricao = "Integração de 2ª ordem. t½=1/(k·[A]₀). Plot 1/[A] vs t é reta.",
            Criador = "Harcourt e Esson",
            AnoOrigin = "1865",
            ExemploPratico = "Saponificação: k=0,1L/(mol·s), [A]₀=0,1M → t½=100s. Reação bimolecular: A+B→P",
            Unidades = "L/mol",
            VariavelResultado = "1/[A]t",
            UnidadeResultado = "L/mol",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A0", Nome = "Concentração inicial", Descricao = "[A] em t=0", Unidade = "mol/L", ValorPadrao = 0.1, ValorMin = 0.001, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Constante de velocidade", Descricao = "Constante cinética", Unidade = "L/(mol·s)", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo decorrido", Unidade = "s", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A0 = inputs["A0"];
                double k = inputs["k"];
                double t = inputs["t"];
                return 1.0 / A0 + k * t;
            }
        };
    }

    public static Formula V8_QA017_TeoriaEstadoTransicao()
    {
        return new Formula
        {
            Id = "V8-QA017",
            CodigoCompendio = "017",
            Nome = "Teoria do Estado de Transição — Eyring",
            Categoria = "Química Analítica",
            SubCategoria = "Cinética Química",
            Expressao = "k = (kB*T/h) * exp(-ΔG‡/(R*T))",
            ExprTexto = "Taxa vs barreira energética",
            Descricao = "ΔG‡=ΔH‡-TΔS‡. Correlaciona k com barreira energética. Catalisador reduz ΔG‡.",
            Criador = "Henry Eyring",
            AnoOrigin = "1935",
            ExemploPratico = "ΔG‡=60kJ/mol a 25°C: k≈0,8s⁻¹. Enzima: reduz ΔG‡ em 40kJ/mol → k aumenta 10⁷×",
            Unidades = "s⁻¹",
            VariavelResultado = "k",
            UnidadeResultado = "s⁻¹",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "kB", Nome = "Constante de Boltzmann", Descricao = "Constante de Boltzmann", Unidade = "J/K", ValorPadrao = 1.380649e-23, ValorMin = 1.380649e-23, ValorMax = 1.380649e-23, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 298, ValorMin = 0, ValorMax = 2000, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Constante de Planck", Descricao = "Constante de Planck", Unidade = "J·s", ValorPadrao = 6.62607015e-34, ValorMin = 6.62607015e-34, ValorMax = 6.62607015e-34, Obrigatoria = true },
                new() { Simbolo = "DG_ativ", Nome = "Energia livre de ativação", Descricao = "ΔG‡", Unidade = "J/mol", ValorPadrao = 60000, ValorMin = 0, ValorMax = 500000, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double kB = inputs["kB"];
                double T = inputs["T"];
                double h = inputs["h"];
                double DG_ativ = inputs["DG_ativ"];
                double R = inputs["R"];
                return (kB * T / h) * Math.Exp(-DG_ativ / (R * T));
            }
        };
    }

    public static Formula V8_QA018_SolubilidadeTemperatura()
    {
        return new Formula
        {
            Id = "V8-QA018",
            CodigoCompendio = "018",
            Nome = "Solubilidade vs Temperatura — van't Hoff",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrio Químico",
            Expressao = "d(ln K)/dT = ΔH°/(R*T²)",
            ExprTexto = "Variação de K com temperatura",
            Descricao = "K de solubilidade: ΔH<0 → solubilidade cai com T. ΔH>0: aumenta.",
            Criador = "Jacobus van't Hoff",
            AnoOrigin = "1884",
            ExemploPratico = "Ca(OH)₂: solubilidade cai com T (ΔH<0). CaCl₂: aumenta. Incrustações em caldeiras",
            Unidades = "1/K",
            VariavelResultado = "dlnK_dT",
            UnidadeResultado = "1/K",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "DH0", Nome = "Entalpia padrão", Descricao = "ΔH° da reação", Unidade = "J/mol", ValorPadrao = 50000, ValorMin = -500000, ValorMax = 500000, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 298, ValorMin = 0, ValorMax = 500, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double DH0 = inputs["DH0"];
                double R = inputs["R"];
                double T = inputs["T"];
                return DH0 / (R * T * T);
            }
        };
    }

    public static Formula V8_QA019_TampaoHendersonHasselbalch()
    {
        return new Formula
        {
            Id = "V8-QA019",
            CodigoCompendio = "019",
            Nome = "Tampão — Henderson-Hasselbalch",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrio Ácido-Base",
            Expressao = "pH = pKa + log([A-]/[HA])",
            ExprTexto = "pH de solução tampão",
            Descricao = "pH de tampão em função da razão base/ácido conjugado. Válida quando razão entre 0,1 e 10.",
            Criador = "Henderson e Hasselbalch",
            AnoOrigin = "1908",
            ExemploPratico = "Tampão fosfato PBS: pKa=7,20; [A⁻]/[HA]=1,6 → pH=7,40. Base do fluido fisiológico",
            Unidades = "adimensional",
            VariavelResultado = "pH",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "pKa", Nome = "pKa do ácido", Descricao = "-log(Ka)", Unidade = "", ValorPadrao = 7.20, ValorMin = 0, ValorMax = 14, Obrigatoria = true },
                new() { Simbolo = "A_neg", Nome = "Concentração da base", Descricao = "[A⁻]", Unidade = "mol/L", ValorPadrao = 1.6, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "HA", Nome = "Concentração do ácido", Descricao = "[HA]", Unidade = "mol/L", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double pKa = inputs["pKa"];
                double A_neg = inputs["A_neg"];
                double HA = inputs["HA"];
                return pKa + Math.Log10(A_neg / HA);
            }
        };
    }

    public static Formula V8_QA020_AcidoPoliprotico()
    {
        return new Formula
        {
            Id = "V8-QA020",
            CodigoCompendio = "020",
            Nome = "Equilíbrio de Ácido Poliprótico",
            Categoria = "Química Analítica",
            SubCategoria = "Equilíbrio Ácido-Base",
            Expressao = "Ka1 >> Ka2 >> Ka3",
            ExprTexto = "Constantes sucessivas de dissociação",
            Descricao = "H₃PO₄: Ka₁=7,1×10⁻³, Ka₂=6,3×10⁻⁸, Ka₃=4,2×10⁻¹³. Tratamento sequencial de cada equilíbrio.",
            Criador = "Base de química analítica",
            AnoOrigin = "~1900",
            ExemploPratico = "pH de H₃PO₄ 0,1M ≈ pH de ácido monoprótico com Ka₁. Tampões biológicos: fosfato, citrato",
            Unidades = "",
            VariavelResultado = "pH1",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Ka1", Nome = "Primeira constante", Descricao = "Ka₁", Unidade = "", ValorPadrao = 7.1e-3, ValorMin = 1e-20, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "C", Nome = "Concentração", Descricao = "Concentração do ácido", Unidade = "mol/L", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Ka1 = inputs["Ka1"];
                double C = inputs["C"];
                double H = Math.Sqrt(Ka1 * C);
                return -Math.Log10(H);
            }
        };
    }

    public static Formula V8_QA021_CalorCombustao()
    {
        return new Formula
        {
            Id = "V8-QA021",
            CodigoCompendio = "021",
            Nome = "Calor de Combustão — Bomba Calorimétrica",
            Categoria = "Química Analítica",
            SubCategoria = "Termoquímica",
            Expressao = "Q = -Cv * ΔT * m_calorímetro",
            ExprTexto = "Calor de combustão a volume constante",
            Descricao = "Calor de combustão a volume constante. Converter para ΔH: ΔH=ΔU+Δn_gas·RT.",
            Criador = "Berthelot",
            AnoOrigin = "1880",
            ExemploPratico = "Sacarose: ΔHcomb=-5640kJ/mol=-16,5kJ/g. Bomba calorimétrica: 4 cifras significativas",
            Unidades = "J",
            VariavelResultado = "Q",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Cv", Nome = "Capacidade calorífica", Descricao = "Cv do calorímetro", Unidade = "J/K", ValorPadrao = 10000, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "DT", Nome = "Variação de temperatura", Descricao = "ΔT medido", Unidade = "K", ValorPadrao = 5, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "Massa da amostra", Descricao = "Massa queimada", Unidade = "g", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Cv = inputs["Cv"];
                double DT = inputs["DT"];
                double m = inputs["m"];
                return -Cv * DT; // Negativo pois combustão é exotérmica
            }
        };
    }
}
