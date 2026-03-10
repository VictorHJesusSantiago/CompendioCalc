using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XVII: ENGENHARIA DE ALIMENTOS
    // Transferência de calor, esterilização, atividade de água, cinética de secagem
    // 16 fórmulas (307-322)
    // ========================================

    public static Formula V8_FOOD307_ValorD_Esterilizacao()
    {
        return new Formula
        {
            Id = "V8-FOOD307",
            CodigoCompendio = "307",
            Nome = "Valor D — Tempo Redução Decimal",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Esterilização",
            Expressao = "D = t / log₁₀(N₀ / N)",
            ExprTexto = "D-value",
            Descricao = "D=tempo (min) reduzir população 90% (1 log). N₀=inicial, N=final. Clostridium: D₁₂₁°C~0,2min.",
            Criador = "Microbiologia alimentar",
            AnoOrigin = "~1920s-1930s",
            ExemploPratico = "N₀=10⁶, N=10⁵, t=2min → D=2min (redução decimal). 12D process: 10^12→1 sporo",
            Unidades = "min",
            VariavelResultado = "D",
            UnidadeResultado = "min",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "min", ValorPadrao = 2, ValorMin = 0.01, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "N0", Nome = "N₀", Descricao = "Pop. inicial", Unidade = "CFU", ValorPadrao = 1e6, ValorMin = 1, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "N", Nome = "N", Descricao = "Pop. final", Unidade = "CFU", ValorPadrao = 1e5, ValorMin = 0.001, ValorMax = 1e12, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t = inputs["t"];
                double N0 = inputs["N0"];
                double N = inputs["N"];
                
                return t / Math.Log10(N0 / N);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD308_ValorZ_DependenciaTemperatura()
    {
        return new Formula
        {
            Id = "V8-FOOD308",
            CodigoCompendio = "308",
            Nome = "Valor Z — Dependência Térmica D",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Esterilização",
            Expressao = "z = ΔT / log₁₀(D₁ / D₂)",
            ExprTexto = "z-value",
            Descricao = "z=aumento temperatura para D↓90%. z↑: resistente. Clostridium: z≈10°C. Bigelow.",
            Criador = "Wilbur Atwater Bigelow",
            AnoOrigin = "~1920",
            ExemploPratico = "D₁₂₁°C=0,2min, D₁₃₁°C=0,02min, ΔT=10°C → z=10°C (reduz D 10× a cada 10°C)",
            Unidades = "°C",
            VariavelResultado = "z",
            UnidadeResultado = "°C",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "delta_T", Nome = "ΔT", Descricao = "Delta temperatura", Unidade = "°C", ValorPadrao = 10, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "D1", Nome = "D₁", Descricao = "D em T₁", Unidade = "min", ValorPadrao = 0.2, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "D2", Nome = "D₂", Descricao = "D em T₂", Unidade = "min", ValorPadrao = 0.02, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double delta_T = inputs["delta_T"];
                double D1 = inputs["D1"];
                double D2 = inputs["D2"];
                
                return delta_T / Math.Log10(D1 / D2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD309_ValorF_Letalidade()
    {
        return new Formula
        {
            Id = "V8-FOOD309",
            CodigoCompendio = "309",
            Nome = "Valor F — Letalidade Térmica",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Esterilização",
            Expressao = "F₀ = ∫ 10^((T-T_ref)/z) dt",
            ExprTexto = "F-value (simplificado: F₀≈t para T=T_ref)",
            Descricao = "F₀=letalidade equivalente a T_ref (121°C), z=10°C. F₀>3min: baixa acidez. Bigelow.",
            Criador = "Wilbur Bigelow / Samuel Cate Prescott",
            AnoOrigin = "~1920",
            ExemploPratico = "T=121°C, z=10°C, t=3min → F₀≈3min (processo 12D). F₀=5-15min típico enlatados",
            Unidades = "min",
            VariavelResultado = "F0",
            UnidadeResultado = "min",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "min", ValorPadrao = 3, ValorMin = 0.01, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "T", Descricao = "Temperatura", Unidade = "°C", ValorPadrao = 121, ValorMin = 50, ValorMax = 150, Obrigatoria = true },
                new() { Simbolo = "T_ref", Nome = "T_ref", Descricao = "Temp. referência", Unidade = "°C", ValorPadrao = 121, ValorMin = 100, ValorMax = 130, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "z", Descricao = "z-value", Unidade = "°C", ValorPadrao = 10, ValorMin = 1, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t = inputs["t"];
                double T = inputs["T"];
                double T_ref = inputs["T_ref"];
                double z = inputs["z"];
                
                // Simplificação: assumindo T constante
                return t * Math.Pow(10, (T - T_ref) / z);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD310_AtividadeAgua_aw()
    {
        return new Formula
        {
            Id = "V8-FOOD310",
            CodigoCompendio = "310",
            Nome = "Atividade de Água — aw",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Propriedades Físicas",
            Expressao = "a_w = P / P₀ = ERH / 100",
            ExprTexto = "Water activity",
            Descricao = "P=pressão vapor alimento, P₀=água pura, ERH=umidade relativa equilíbrio. aw<0,6: estável.",
            Criador = "William James Scott",
            AnoOrigin = "1953-1957",
            ExemploPratico = "ERH=60% → aw=0,6 (limite crescimento bactérias). Bolachas: aw~0,3. Frutas frescas: aw~0,98",
            Unidades = "adimensional",
            VariavelResultado = "a_w",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "ERH", Nome = "ERH", Descricao = "Umidade relativa eq.", Unidade = "%", ValorPadrao = 60, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double ERH = inputs["ERH"];
                
                return ERH / 100;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD311_IsotermaSorcao_GAB()
    {
        return new Formula
        {
            Id = "V8-FOOD311",
            CodigoCompendio = "311",
            Nome = "Isoterma Sorção GAB — Umidade",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Propriedades Físicas",
            Expressao = "M = (M₀ * C * K * a_w) / ((1 - K*a_w) * (1 - K*a_w + C*K*a_w))",
            ExprTexto = "GAB equation",
            Descricao = "M=umidade, M₀=monocamada, C,K=constantes. Guggenheim-Anderson-de Boer 1938-1968.",
            Criador = "Guggenheim (1966) / Anderson (1946) / de Boer (1968)",
            AnoOrigin = "1966-1968",
            ExemploPratico = "M₀=5%, C=10, K=0,8, aw=0,5 → M≈8% (umidade equilíbrio). Alimentos secos: M vs aw",
            Unidades = "%",
            VariavelResultado = "M",
            UnidadeResultado = "%",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "M0", Nome = "M₀", Descricao = "Monocamada", Unidade = "%", ValorPadrao = 5, ValorMin = 0.1, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "C", Nome = "C", Descricao = "Constante C", Unidade = "", ValorPadrao = 10, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "K", Nome = "K", Descricao = "Constante K", Unidade = "", ValorPadrao = 0.8, ValorMin = 0.1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "a_w", Nome = "a_w", Descricao = "Atividade água", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double M0 = inputs["M0"];
                double C = inputs["C"];
                double K = inputs["K"];
                double a_w = inputs["a_w"];
                
                double numerator = M0 * C * K * a_w;
                double denominator = (1 - K * a_w) * (1 - K * a_w + C * K * a_w);
                
                return numerator / denominator;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD312_CineticaSecagem_Henderson()
    {
        return new Formula
        {
            Id = "V8-FOOD312",
            CodigoCompendio = "312",
            Nome = "Cinética de Secagem — Henderson-Pabis",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Secagem",
            Expressao = "MR = a * exp(-k * t)",
            ExprTexto = "MR (Moisture Ratio)",
            Descricao = "MR=(M-Me)/(M0-Me), a~1, k=constante taxa (1/h). Henderson-Pabis 1961.",
            Criador = "S.M. Henderson / A.B. Pabis",
            AnoOrigin = "1961",
            ExemploPratico = "a=1, k=0,5/h, t=2h → MR≈0,368 (36,8% umidade removível restante). Ar quente: k↑",
            Unidades = "adimensional",
            VariavelResultado = "MR",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "a", Descricao = "Constante", Unidade = "", ValorPadrao = 1, ValorMin = 0.5, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "k", Descricao = "Taxa secagem", Unidade = "1/h", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "h", ValorPadrao = 2, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double k = inputs["k"];
                double t = inputs["t"];
                
                return a * Math.Exp(-k * t);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD313_TransferenciaCalor_Fourier()
    {
        return new Formula
        {
            Id = "V8-FOOD313",
            CodigoCompendio = "313",
            Nome = "Lei de Fourier — Transferência Calor",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Transferência de Calor",
            Expressao = "q = -k * A * dT/dx",
            ExprTexto = "Fourier's law",
            Descricao = "q=taxa calor (W), k=condutividade térmica (W/(m·K)), A=área. Alimentos: k~0,3-0,6.",
            Criador = "Jean-Baptiste Joseph Fourier",
            AnoOrigin = "1822",
            ExemploPratico = "k=0,5 W/(m·K), A=1m², dT/dx=100K/m → q=50W. Congelamento: k↑ com gelo",
            Unidades = "W",
            VariavelResultado = "q",
            UnidadeResultado = "W",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "k", Descricao = "Condutividade", Unidade = "W/(m·K)", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "A", Descricao = "Área", Unidade = "m^2", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "gradT", Nome = "dT/dx", Descricao = "Gradiente T", Unidade = "K/m", ValorPadrao = 100, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double A = inputs["A"];
                double gradT = inputs["gradT"];
                
                return -k * A * gradT;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD314_NumBiot_TransfCalor()
    {
        return new Formula
        {
            Id = "V8-FOOD314",
            CodigoCompendio = "314",
            Nome = "Número de Biot — Bi",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Transferência de Calor",
            Expressao = "Bi = h * L / k",
            ExprTexto = "Biot number",
            Descricao = "h=coef. convecção (W/(m²·K)), L=comp. característico, k=condutividade. Bi<0,1: lumped. Biot 1804.",
            Criador = "Jean-Baptiste Biot",
            AnoOrigin = "1804",
            ExemploPratico = "h=100 W/(m²·K), L=0,01m, k=0,5 W/(m·K) → Bi=2 (gradiente interno significativo)",
            Unidades = "adimensional",
            VariavelResultado = "Bi",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "h", Nome = "h", Descricao = "Coef. convecção", Unidade = "W/(m^2·K)", ValorPadrao = 100, ValorMin = 1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "L", Descricao = "Comprimento", Unidade = "m", ValorPadrao = 0.01, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "k", Descricao = "Condutividade", Unidade = "W/(m·K)", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double h = inputs["h"];
                double L = inputs["L"];
                double k = inputs["k"];
                
                return h * L / k;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD315_ValorQ10_Reacoes()
    {
        return new Formula
        {
            Id = "V8-FOOD315",
            CodigoCompendio = "315",
            Nome = "Coeficiente Q₁₀ — Reações",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Cinética de Reações",
            Expressao = "Q₁₀ = (k₂ / k₁)^(10 / (T₂ - T₁))",
            ExprTexto = "Q10 coefficient",
            Descricao = "k=taxa reação, T₁,T₂=temperaturas. Q₁₀≈2-4 reactions enzimáticas. Van't Hoff.",
            Criador = "Jacobus Henricus van 't Hoff",
            AnoOrigin = "~1884",
            ExemploPratico = "k₁=0,1 a 20°C, k₂=0,4 a 30°C → Q₁₀=4 (taxa 4× a cada +10°C). Spoilage: Q₁₀~2",
            Unidades = "adimensional",
            VariavelResultado = "Q10",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k1", Nome = "k₁", Descricao = "Taxa em T₁", Unidade = "1/tempo", ValorPadrao = 0.1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "k2", Nome = "k₂", Descricao = "Taxa em T₂", Unidade = "1/tempo", ValorPadrao = 0.4, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "T1", Nome = "T₁", Descricao = "Temperatura 1", Unidade = "°C", ValorPadrao = 20, ValorMin = -50, ValorMax = 150, Obrigatoria = true },
                new() { Simbolo = "T2", Nome = "T₂", Descricao = "Temperatura 2", Unidade = "°C", ValorPadrao = 30, ValorMin = -50, ValorMax = 150, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k1 = inputs["k1"];
                double k2 = inputs["k2"];
                double T1 = inputs["T1"];
                double T2 = inputs["T2"];
                
                return Math.Pow(k2 / k1, 10 / (T2 - T1));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD316_EscurecimentoEnzimatico()
    {
        return new Formula
        {
            Id = "V8-FOOD316",
            CodigoCompendio = "316",
            Nome = "Taxa Escurecimento Enzimático — V",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Cinética de Reações",
            Expressao = "V = V_max * [S] / (K_m + [S])",
            ExprTexto = "Michaelis-Menten (PPO)",
            Descricao = "V=taxa escurecimento (polifenoloxidase PPO), [S]=substrato (fenol). K_m~mM. Browning.",
            Criador = "Leonor Michaelis / Maud Menten",
            AnoOrigin = "1913",
            ExemploPratico = "V_max=10 μmol/min, [S]=5mM, K_m=2mM → V≈7,14 μmol/min. Maçãs: escurecer PPO",
            Unidades = "μmol/min",
            VariavelResultado = "V",
            UnidadeResultado = "μmol/min",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "V_max", Nome = "V_max", Descricao = "Velocidade máx", Unidade = "μmol/min", ValorPadrao = 10, ValorMin = 0.01, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "[S]", Descricao = "Conc. substrato", Unidade = "mM", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "K_m", Nome = "K_m", Descricao = "Constante Michaelis", Unidade = "mM", ValorPadrao = 2, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double V_max = inputs["V_max"];
                double S = inputs["S"];
                double K_m = inputs["K_m"];
                
                return V_max * S / (K_m + S);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD317_PasteurizacaoLeite()
    {
        return new Formula
        {
            Id = "V8-FOOD317",
            CodigoCompendio = "317",
            Nome = "Pasteurização Leite — P-value",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Esterilização",
            Expressao = "P = ∫ 10^((T-T_ref)/z) dt  (T_ref=72°C, z=7°C)",
            ExprTexto = "P-value (simplificado)",
            Descricao = "P=letalidade Coxiella burnetii (febre Q). HTST: 72°C/15s. UHT: 135°C/2-5s. Pasteur 1864.",
            Criador = "Louis Pasteur",
            AnoOrigin = "1864",
            ExemploPratico = "T=72°C, t=15s, T_ref=72°C, z=7°C → P≈15s (HTST). UHT 135°C/2s: P>>15s",
            Unidades = "s",
            VariavelResultado = "P",
            UnidadeResultado = "s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "s", ValorPadrao = 15, ValorMin = 0.1, ValorMax = 600, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "T", Descricao = "Temperatura", Unidade = "°C", ValorPadrao = 72, ValorMin = 60, ValorMax = 150, Obrigatoria = true },
                new() { Simbolo = "T_ref", Nome = "T_ref", Descricao = "Temp. ref", Unidade = "°C", ValorPadrao = 72, ValorMin = 60, ValorMax = 80, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "z", Descricao = "z-value", Unidade = "°C", ValorPadrao = 7, ValorMin = 1, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t = inputs["t"];
                double T = inputs["T"];
                double T_ref = inputs["T_ref"];
                double z = inputs["z"];
                
                return t * Math.Pow(10, (T - T_ref) / z);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD318_ReacaoMaillard_Cinetica()
    {
        return new Formula
        {
            Id = "V8-FOOD318",
            CodigoCompendio = "318",
            Nome = "Reação de Maillard — Taxa",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Cinética de Reações",
            Expressao = "k = A * exp(-E_a / (R * T))",
            ExprTexto = "Arrhenius for Maillard",
            Descricao = "k=taxa browning, E_a~50-150 kJ/mol. aw↓: taxa↓. Maillard: AA + açúcar → melanoidinas. 1912.",
            Criador = "Louis-Camille Maillard",
            AnoOrigin = "1912",
            ExemploPratico = "A=10^10 1/s, E_a=100 kJ/mol, T=120°C → k≈100 1/s. Assados: Maillard flavor",
            Unidades = "1/s",
            VariavelResultado = "k",
            UnidadeResultado = "1/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "A", Descricao = "Fator pré-exp", Unidade = "1/s", ValorPadrao = 1e10, ValorMin = 1e5, ValorMax = 1e20, Obrigatoria = true },
                new() { Simbolo = "E_a", Nome = "E_a", Descricao = "Energia ativação", Unidade = "kJ/mol", ValorPadrao = 100, ValorMin = 10, ValorMax = 300, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "T", Descricao = "Temperatura", Unidade = "K", ValorPadrao = 393, ValorMin = 273, ValorMax = 500, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double E_a = inputs["E_a"];
                double T = inputs["T"];
                
                double R = 8.314; // J/(mol·K)
                
                return A * Math.Exp(-E_a * 1000 / (R * T));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD319_IndicePeroxido_Oxidacao()
    {
        return new Formula
        {
            Id = "V8-FOOD319",
            CodigoCompendio = "319",
            Nome = "Índice de Peróxido — PV",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Qualidade Lipídica",
            Expressao = "PV = (V_sample - V_blank) * N * 1000 / m",
            ExprTexto = "Peroxide value",
            Descricao = "PV=meq O₂/kg óleo (oxidação primária). V=mL tiossulfato, N=normalidade, m=massa. PV<10: fresco.",
            Criador = "Análise lipídica",
            AnoOrigin = "~1950s",
            ExemploPratico = "V_sample=5mL, V_blank=0,1mL, N=0,01, m=2g → PV≈24,5 meq/kg (oxidação moderada)",
            Unidades = "meq/kg",
            VariavelResultado = "PV",
            UnidadeResultado = "meq/kg",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "V_sample", Nome = "V_sample", Descricao = "Vol. amostra", Unidade = "mL", ValorPadrao = 5, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "V_blank", Nome = "V_blank", Descricao = "Vol. branco", Unidade = "mL", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "N", Nome = "N", Descricao = "Normalidade", Unidade = "N", ValorPadrao = 0.01, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "m", Descricao = "Massa amostra", Unidade = "g", ValorPadrao = 2, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double V_sample = inputs["V_sample"];
                double V_blank = inputs["V_blank"];
                double N = inputs["N"];
                double m = inputs["m"];
                
                return (V_sample - V_blank) * N * 1000 / m;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD320_IndiceTBA_Rancidez()
    {
        return new Formula
        {
            Id = "V8-FOOD320",
            CodigoCompendio = "320",
            Nome = "Índice TBA — Rancidez",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Qualidade Lipídica",
            Expressao = "TBA = (A * V * 72,6) / (m * 1000)",
            ExprTexto = "TBA value",
            Descricao = "TBA=mg malonaldeído/kg (oxidação secundária). A=absorbância 532nm, V=vol, m=massa. TBA>1: ranço.",
            Criador = "Teste ácido tiobarbitúrico",
            AnoOrigin = "~1950s",
            ExemploPratico = "A=0,5, V=5mL, m=10g → TBA≈1,815 mg/kg (início ranço perceptível). Carnes: TBA↑",
            Unidades = "mg/kg",
            VariavelResultado = "TBA",
            UnidadeResultado = "mg/kg",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "A", Descricao = "Absorbância", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "V", Nome = "V", Descricao = "Volume", Unidade = "mL", ValorPadrao = 5, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "m", Descricao = "Massa", Unidade = "g", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double V = inputs["V"];
                double m = inputs["m"];
                
                return (A * V * 72.6) / (m * 1000);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD321_TempoVidaUtil_Q10()
    {
        return new Formula
        {
            Id = "V8-FOOD321",
            CodigoCompendio = "321",
            Nome = "Vida Útil — Dependência Temperatura (Q₁₀)",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Shelf Life",
            Expressao = "t₂ = t₁ * Q₁₀^((T₁ - T₂) / 10)",
            ExprTexto = "Shelf life vs T",
            Descricao = "t₁,t₂=vida útil em T₁,T₂. Q₁₀=2-3 típico. Refrigeração↑vida. Arrhenius simplificado.",
            Criador = "Cinética deterioração",
            AnoOrigin = "~1980s",
            ExemploPratico = "t₁=30 dias (25°C), T₁=25°C, T₂=5°C, Q₁₀=2 → t₂≈120 dias (refrigerado 4×)",
            Unidades = "dias",
            VariavelResultado = "t2",
            UnidadeResultado = "dias",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t1", Nome = "t₁", Descricao = "Vida em T₁", Unidade = "dias", ValorPadrao = 30, ValorMin = 0.1, ValorMax = 3650, Obrigatoria = true },
                new() { Simbolo = "T1", Nome = "T₁", Descricao = "Temperatura 1", Unidade = "°C", ValorPadrao = 25, ValorMin = -50, ValorMax = 150, Obrigatoria = true },
                new() { Simbolo = "T2", Nome = "T₂", Descricao = "Temperatura 2", Unidade = "°C", ValorPadrao = 5, ValorMin = -50, ValorMax = 150, Obrigatoria = true },
                new() { Simbolo = "Q10", Nome = "Q₁₀", Descricao = "Coef. Q10", Unidade = "", ValorPadrao = 2, ValorMin = 1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t1 = inputs["t1"];
                double T1 = inputs["T1"];
                double T2 = inputs["T2"];
                double Q10 = inputs["Q10"];
                
                return t1 * Math.Pow(Q10, (T1 - T2) / 10);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_FOOD322_ReologiaPotencia_Herschel_Bulkley()
    {
        return new Formula
        {
            Id = "V8-FOOD322",
            CodigoCompendio = "322",
            Nome = "Reologia — Herschel-Bulkley",
            Categoria = "Engenharia de Alimentos",
            SubCategoria = "Propriedades Reológicas",
            Expressao = "τ = τ₀ + K * γ^n",
            ExprTexto = "Herschel-Bulkley model",
            Descricao = "τ=tensão cisalh., τ₀=tensão cedência, K=consistência, n=índice fluxo. Herschel 1926.",
            Criador = "Winslow H. Herschel / Ronald Bulkley",
            AnoOrigin = "1926",
            ExemploPratico = "τ₀=10Pa (maionese), K=5Pa·s^n, n=0,5, γ=10/s → τ≈25,8Pa. n<1: pseudoplástico",
            Unidades = "Pa",
            VariavelResultado = "tau",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "tau0", Nome = "τ₀", Descricao = "Tensão cedência", Unidade = "Pa", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "K", Nome = "K", Descricao = "Consistência", Unidade = "Pa·s^n", ValorPadrao = 5, ValorMin = 0.01, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "gamma", Nome = "γ", Descricao = "Taxa cisalh.", Unidade = "1/s", ValorPadrao = 10, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "n", Descricao = "Índice fluxo", Unidade = "", ValorPadrao = 0.5, ValorMin = 0.1, ValorMax = 2, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double tau0 = inputs["tau0"];
                double K = inputs["K"];
                double gamma = inputs["gamma"];
                double n = inputs["n"];
                
                return tau0 + K * Math.Pow(gamma, n);
            },
            Icone = "∑",
        };
    }
}
