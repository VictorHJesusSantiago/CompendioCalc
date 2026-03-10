using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE II: BIOQUÍMICA E BIOLOGIA MOLECULAR
    // Enzimas, metabolismo, genética molecular e biofísica de proteínas
    // 21 fórmulas (022-042)
    // ========================================

    public static Formula V8_BQ022_MichaelisMenten()
    {
        return new Formula
        {
            Id = "V8-BQ022",
            CodigoCompendio = "022",
            Nome = "Michaelis-Menten",
            Categoria = "Bioquímica",
            SubCategoria = "Cinética Enzimática",
            Expressao = "v = (Vmax * [S]) / (Km + [S])",
            ExprTexto = "Velocidade enzimática",
            Descricao = "Velocidade enzimática em função do substrato. Km=[S] que dá Vmax/2. kcat=Vmax/[E]total=número de turnover.",
            Criador = "Michaelis e Menten",
            AnoOrigin = "1913",
            ExemploPratico = "Lactase: Km=10mM, [S]=10mM → v=Vmax/2. kcat(catalase)=4×10⁷s⁻¹ (enzima mais rápida)",
            Unidades = "µmol/min",
            VariavelResultado = "v",
            UnidadeResultado = "µmol/min",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Vmax", Nome = "Velocidade máxima", Descricao = "Taxa máxima de catálise", Unidade = "µmol/min", ValorPadrao = 100, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Concentração de substrato", Descricao = "[S]", Unidade = "mM", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "Km", Nome = "Constante de Michaelis", Descricao = "[S] para v=Vmax/2", Unidade = "mM", ValorPadrao = 10, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Vmax = inputs["Vmax"];
                double S = inputs["S"];
                double Km = inputs["Km"];
                return (Vmax * S) / (Km + S);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ023_EquacaoHill()
    {
        return new Formula
        {
            Id = "V8-BQ023",
            CodigoCompendio = "023",
            Nome = "Equação de Hill — Cooperatividade",
            Categoria = "Bioquímica",
            SubCategoria = "Ligação de Proteínas",
            Expressao = "θ = [L]^n / (Kd + [L]^n)",
            ExprTexto = "Fração de sítios ocupados",
            Descricao = "n>1: cooperativo positivo. n=1: hiperbólico. Hemoglobina: n≈2,8 (cooperatividade sigmoide).",
            Criador = "A.V. Hill",
            AnoOrigin = "1910",
            ExemploPratico = "Hb: n=2,8, P₅₀=26mmHg. Pulmão (pO₂=100mmHg): θ=97%. Músculo (40mmHg): θ=73%",
            Unidades = "adimensional",
            VariavelResultado = "θ",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L", Nome = "Concentração de ligante", Descricao = "[L]", Unidade = "mmHg", ValorPadrao = 100, ValorMin = 0, ValorMax = 200, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Coeficiente de Hill", Descricao = "Grau de cooperatividade", Unidade = "", ValorPadrao = 2.8, ValorMin = 0.5, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "Kd", Nome = "Constante de dissociação", Descricao = "P₅₀ ou EC₅₀", Unidade = "mmHg", ValorPadrao = 26, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L = inputs["L"];
                double n = inputs["n"];
                double Kd = inputs["Kd"];
                return Math.Pow(L, n) / (Math.Pow(Kd, n) + Math.Pow(L, n));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ024_HardyWeinberg()
    {
        return new Formula
        {
            Id = "V8-BQ024",
            CodigoCompendio = "024",
            Nome = "Hardy-Weinberg",
            Categoria = "Bioquímica",
            SubCategoria = "Genética de Populações",
            Expressao = "p² + 2pq + q² = 1; p + q = 1",
            ExprTexto = "Equilíbrio genético",
            Descricao = "Equilíbrio genético: p²(AA)+2pq(Aa)+q²(aa). Válido sem seleção, mutação, deriva genética.",
            Criador = "Hardy, Weinberg",
            AnoOrigin = "1908",
            ExemploPratico = "Fibrose cística: q=0,02 → portadores 2pq≈3,9%. Fenilcetonúria: q²=1/10.000=0,0001",
            Unidades = "frequência",
            VariavelResultado = "freq_AA",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "p", Nome = "Frequência alelo A", Descricao = "Proporção do alelo dominante", Unidade = "", ValorPadrao = 0.98, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "q", Nome = "Frequência alelo a", Descricao = "Proporção do alelo recessivo", Unidade = "", ValorPadrao = 0.02, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double p = inputs["p"];
                double q = inputs["q"];
                return p * p; // Retorna frequência de homozigotos dominantes (AA)
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ025_PCR_Amplificacao()
    {
        return new Formula
        {
            Id = "V8-BQ025",
            CodigoCompendio = "025",
            Nome = "PCR — Amplificação de DNA",
            Categoria = "Bioquímica",
            SubCategoria = "Biologia Molecular",
            Expressao = "N = N0 * (1+E)^n",
            ExprTexto = "Número de cópias após n ciclos",
            Descricao = "n ciclos, eficiência E∈(0,1). Ideal (E=1): N=N₀·2ⁿ. qPCR: Ct=-log(N₀)/log(1+E).",
            Criador = "Kary Mullis",
            AnoOrigin = "1983",
            ExemploPratico = "1 molécula, 30 ciclos, E=0,95: N≈1,7×10⁹ cópias. ddPCR: contagem absoluta de moléculas",
            Unidades = "moléculas",
            VariavelResultado = "N",
            UnidadeResultado = "moléculas",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "N0", Nome = "Cópias iniciais", Descricao = "Número inicial de moléculas", Unidade = "moléculas", ValorPadrao = 1, ValorMin = 1, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "E", Nome = "Eficiência", Descricao = "Eficiência da amplificação (0-1)", Unidade = "", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Número de ciclos", Descricao = "Ciclos de PCR", Unidade = "", ValorPadrao = 30, ValorMin = 0, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double N0 = inputs["N0"];
                double E = inputs["E"];
                double n = inputs["n"];
                return N0 * Math.Pow(1 + E, n);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ026_PotencialMembrana()
    {
        return new Formula
        {
            Id = "V8-BQ026",
            CodigoCompendio = "026",
            Nome = "Potencial de Membrana — Nernst",
            Categoria = "Bioquímica",
            SubCategoria = "Biofísica Celular",
            Expressao = "E = (R*T/(z*F)) * ln([X]out/[X]in)",
            ExprTexto = "Potencial de reversão",
            Descricao = "Potencial de reversão para íon X com carga z. Goldman-Hodgkin-Katz combina vários íons.",
            Criador = "Nernst",
            AnoOrigin = "1889",
            ExemploPratico = "K⁺: [K]out=5mM, [K]in=140mM → EK=(25,7mV)·ln(1/28)=-86mV. Repouso neuronal: -70mV",
            Unidades = "mV",
            VariavelResultado = "E",
            UnidadeResultado = "mV",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 310, ValorMin = 273, ValorMax = 350, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "Valência", Descricao = "Carga do íon", Unidade = "", ValorPadrao = 1, ValorMin = -3, ValorMax = 3, Obrigatoria = true },
                new() { Simbolo = "F", Nome = "Constante de Faraday", Descricao = "Carga de 1 mol de elétrons", Unidade = "C/mol", ValorPadrao = 96485, ValorMin = 96485, ValorMax = 96485, Obrigatoria = true },
                new() { Simbolo = "X_out", Nome = "[X] extracelular", Descricao = "Concentração fora", Unidade = "mM", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "X_in", Nome = "[X] intracelular", Descricao = "Concentração dentro", Unidade = "mM", ValorPadrao = 140, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R = inputs["R"];
                double T = inputs["T"];
                double z = inputs["z"];
                double F = inputs["F"];
                double X_out = inputs["X_out"];
                double X_in = inputs["X_in"];
                return (R * T / (z * F)) * Math.Log(X_out / X_in) * 1000; // Convertendo para mV
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ027_EnergiaLivreATP()
    {
        return new Formula
        {
            Id = "V8-BQ027",
            CodigoCompendio = "027",
            Nome = "Energia Livre de Hidrólise do ATP",
            Categoria = "Bioquímica",
            SubCategoria = "Metabolismo Energético",
            Expressao = "ΔG = ΔG°' + R*T*ln([ADP][Pi]/[ATP])",
            ExprTexto = "Energia livre da hidrólise de ATP",
            Descricao = "ΔG°'=-30,5kJ/mol. Na célula ([ATP]/[ADP]=10): ΔG≈-50kJ/mol. Motor biológico universal.",
            Criador = "Lehninger, Atkinson",
            AnoOrigin = "1977",
            ExemploPratico = "Bomba Na⁺/K⁺: consome 1ATP para transportar 3Na⁺ para fora e 2K⁺ para dentro da célula",
            Unidades = "kJ/mol",
            VariavelResultado = "ΔG",
            UnidadeResultado = "kJ/mol",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "DG0_prime", Nome = "ΔG°' padrão", Descricao = "Energia livre padrão", Unidade = "kJ/mol", ValorPadrao = -30.5, ValorMin = -100, ValorMax = 0, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 310, ValorMin = 273, ValorMax = 350, Obrigatoria = true },
                new() { Simbolo = "ADP", Nome = "Concentração ADP", Descricao = "[ADP]", Unidade = "mM", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "Pi", Nome = "Fosfato inorgânico", Descricao = "[Pi]", Unidade = "mM", ValorPadrao = 5, ValorMin = 0, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "ATP", Nome = "Concentração ATP", Descricao = "[ATP]", Unidade = "mM", ValorPadrao = 5, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double DG0_prime = inputs["DG0_prime"];
                double R = inputs["R"];
                double T = inputs["T"];
                double ADP = inputs["ADP"];
                double Pi = inputs["Pi"];
                double ATP = inputs["ATP"];
                return DG0_prime + (R * T / 1000) * Math.Log((ADP * Pi) / ATP);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ028_MichaelisMentenInibida()
    {
        return new Formula
        {
            Id = "V8-BQ028",
            CodigoCompendio = "028",
            Nome = "Equação de Michaelis-Menten Inibida",
            Categoria = "Bioquímica",
            SubCategoria = "Cinética Enzimática",
            Expressao = "v = Vmax*[S]/(α*Km + α'*[S])",
            ExprTexto = "Velocidade com inibidor",
            Descricao = "α=1+[I]/Ki (competitivo); α'=1+[I]/Ki' (incompetitivo). Misto: ambos alterados.",
            Criador = "Webb",
            AnoOrigin = "1963",
            ExemploPratico = "Metrotrexato inibe DHFR competitivamente (Ki picomolar). Inibidores de protease HIV",
            Unidades = "µmol/min",
            VariavelResultado = "v",
            UnidadeResultado = "µmol/min",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Vmax", Nome = "Velocidade máxima", Descricao = "Taxa máxima", Unidade = "µmol/min", ValorPadrao = 100, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Concentração substrato", Descricao = "[S]", Unidade = "mM", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "alpha", Nome = "Fator α", Descricao = "1+[I]/Ki", Unidade = "", ValorPadrao = 2, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "Km", Nome = "Constante Michaelis", Descricao = "Km aparente", Unidade = "mM", ValorPadrao = 10, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "alpha_prime", Nome = "Fator α'", Descricao = "1+[I]/Ki'", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Vmax = inputs["Vmax"];
                double S = inputs["S"];
                double alpha = inputs["alpha"];
                double Km = inputs["Km"];
                double alpha_prime = inputs["alpha_prime"];
                return (Vmax * S) / (alpha * Km + alpha_prime * S);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ029_LineweaverBurk()
    {
        return new Formula
        {
            Id = "V8-BQ029",
            CodigoCompendio = "029",
            Nome = "Duplo-Recíproco — Lineweaver-Burk",
            Categoria = "Bioquímica",
            SubCategoria = "Cinética Enzimática",
            Expressao = "1/v = (Km/Vmax)*(1/[S]) + 1/Vmax",
            ExprTexto = "Linearização Michaelis-Menten",
            Descricao = "Plot 1/v vs 1/[S]: reta. x-int=-1/Km, y-int=1/Vmax. Identifica tipo de inibição.",
            Criador = "Lineweaver e Burk",
            AnoOrigin = "1934",
            ExemploPratico = "Slope=Km/Vmax. Inibição competitiva: altera slope, não y-int. Não-comp.: altera y-int",
            Unidades = "min/µmol",
            VariavelResultado = "inv_v",
            UnidadeResultado = "min/µmol",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Km", Nome = "Constante Michaelis", Descricao = "Km da enzima", Unidade = "mM", ValorPadrao = 10, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "Vmax", Nome = "Velocidade máxima", Descricao = "Vmax", Unidade = "µmol/min", ValorPadrao = 100, ValorMin = 0.001, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Concentração substrato", Descricao = "[S]", Unidade = "mM", ValorPadrao = 10, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Km = inputs["Km"];
                double Vmax = inputs["Vmax"];
                double S = inputs["S"];
                return (Km / Vmax) * (1.0 / S) + (1.0 / Vmax);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ030_CoeficienteParticao()
    {
        return new Formula
        {
            Id = "V8-BQ030",
            CodigoCompendio = "030",
            Nome = "Coeficiente de Partição — logP",
            Categoria = "Bioquímica",
            SubCategoria = "Farmacocinética",
            Expressao = "logP = log([soluto]octanol / [soluto]água)",
            ExprTexto = "Lipofilicidade",
            Descricao = "Lipofilicidade. Regra de Lipinski: logP<5. Prediz absorção oral e passagem na BBB.",
            Criador = "Meyer, Overton",
            AnoOrigin = "1899",
            ExemploPratico = "Aspirina: logP=1,19; Paracetamol: logP=0,49. Morfina: logP=0,9; Fentanil: logP=4,05",
            Unidades = "adimensional",
            VariavelResultado = "logP",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C_octanol", Nome = "Concentração octanol", Descricao = "[soluto] em octanol", Unidade = "mol/L", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "C_agua", Nome = "Concentração água", Descricao = "[soluto] em água", Unidade = "mol/L", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C_octanol = inputs["C_octanol"];
                double C_agua = inputs["C_agua"];
                return Math.Log10(C_octanol / C_agua);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ031_EquacaoScatchard()
    {
        return new Formula
        {
            Id = "V8-BQ031",
            CodigoCompendio = "031",
            Nome = "Equação de Scatchard",
            Categoria = "Bioquímica",
            SubCategoria = "Ligação Receptor-Ligante",
            Expressao = "r/[L] = n/Kd - r/Kd",
            ExprTexto = "Análise de ligação",
            Descricao = "Análise de ligação receptor-ligante. Plot linear: slope=-1/Kd, y-int=n/Kd.",
            Criador = "George Scatchard",
            AnoOrigin = "1949",
            ExemploPratico = "Ensaio ELISA competitivo: Kd do anticorpo. Radioreceptor binding: Kd e Bmax",
            Unidades = "1/mM",
            VariavelResultado = "r_over_L",
            UnidadeResultado = "1/mM",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "r", Nome = "Ligante ligado / proteína", Descricao = "Razão de ligação", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "Concentração ligante livre", Descricao = "[L] livre", Unidade = "mM", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Número de sítios", Descricao = "Sítios de ligação", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "Kd", Nome = "Constante de dissociação", Descricao = "Kd", Unidade = "mM", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double r = inputs["r"];
                double L = inputs["L"];
                double n = inputs["n"];
                double Kd = inputs["Kd"];
                return n / Kd - r / Kd;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ032_EquacaoSvedberg()
    {
        return new Formula
        {
            Id = "V8-BQ032",
            CodigoCompendio = "032",
            Nome = "Equação de Svedberg",
            Categoria = "Bioquímica",
            SubCategoria = "Ultracentrifugação",
            Expressao = "M = R*T*s / (D*(1-v̄*ρ))",
            ExprTexto = "Massa molecular por sedimentação",
            Descricao = "Massa molecular de macromolécula via coef. de sedimentação s e difusão D.",
            Criador = "Theodor Svedberg",
            AnoOrigin = "1926",
            ExemploPratico = "Albumina: s=4,3S, D=6×10⁻⁷cm²/s → M≈69.000g/mol. Ultracentrifugação analítica",
            Unidades = "g/mol",
            VariavelResultado = "M",
            UnidadeResultado = "g/mol",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "Constante universal", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 293, ValorMin = 273, ValorMax = 350, Obrigatoria = true },
                new() { Simbolo = "s", Nome = "Coeficiente sedimentação", Descricao = "s em Svedberg", Unidade = "S", ValorPadrao = 4.3, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "D", Nome = "Coeficiente difusão", Descricao = "D", Unidade = "m²/s", ValorPadrao = 6e-11, ValorMin = 1e-15, ValorMax = 1e-6, Obrigatoria = true },
                new() { Simbolo = "v_bar", Nome = "Volume parcial específico", Descricao = "v̄ da proteína", Unidade = "mL/g", ValorPadrao = 0.73, ValorMin = 0.5, ValorMax = 1.5, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade do solvente", Descricao = "ρ", Unidade = "g/mL", ValorPadrao = 1.0, ValorMin = 0.8, ValorMax = 1.3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R = inputs["R"];
                double T = inputs["T"];
                double s = inputs["s"] * 1e-13; // Converter Svedberg para s
                double D = inputs["D"];
                double v_bar = inputs["v_bar"];
                double rho = inputs["rho"];
                return (R * T * s) / (D * (1 - v_bar * rho));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ033_OsmolaridadePlamatica()
    {
        return new Formula
        {
            Id = "V8-BQ033",
            CodigoCompendio = "033",
            Nome = "Osmolaridade Plasmática Calculada",
            Categoria = "Bioquímica",
            SubCategoria = "Bioquímica Clínica",
            Expressao = "Osm_calc = 2*[Na+] + [glicose]/18 + [ureia]/6",
            ExprTexto = "Osmolaridade calculada",
            Descricao = "Normal: 275-295mOsm/kg. Hiato osmolal = Osm_medida - Osm_calc > 10: suspeita de toxina.",
            Criador = "Fórmula clínica",
            AnoOrigin = "~1970",
            ExemploPratico = "[Na]=140, glicose=90mg/dL, ureia=20mg/dL → Osm=280+5+3,3=288mOsm/kg (normal)",
            Unidades = "mOsm/kg",
            VariavelResultado = "Osm",
            UnidadeResultado = "mOsm/kg",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Na", Nome = "Sódio sérico", Descricao = "[Na⁺]", Unidade = "mEq/L", ValorPadrao = 140, ValorMin = 100, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "glicose", Nome = "Glicose", Descricao = "Glicemia", Unidade = "mg/dL", ValorPadrao = 90, ValorMin = 50, ValorMax = 600, Obrigatoria = true },
                new() { Simbolo = "ureia", Nome = "Ureia", Descricao = "Ureia sérica", Unidade = "mg/dL", ValorPadrao = 20, ValorMin = 5, ValorMax = 200, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Na = inputs["Na"];
                double glicose = inputs["glicose"];
                double ureia = inputs["ureia"];
                return 2 * Na + glicose / 18 + ureia / 6;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ034_HendersonHasselbalchSangue()
    {
        return new Formula
        {
            Id = "V8-BQ034",
            CodigoCompendio = "034",
            Nome = "Henderson-Hasselbalch para Sangue",
            Categoria = "Bioquímica",
            SubCategoria = "Equilíbrio Ácido-Base",
            Expressao = "pH = 6,1 + log([HCO3-] / (0,0307*pCO2))",
            ExprTexto = "pH sanguíneo",
            Descricao = "Equilíbrio ácido-base no sangue. pCO₂ em mmHg. Base do diagnóstico gasométrico.",
            Criador = "Henderson, Hasselbalch",
            AnoOrigin = "1908",
            ExemploPratico = "[HCO₃⁻]=24mEq/L, pCO₂=40mmHg → pH=6,1+log(24/1,228)=7,40 ✓ Normal",
            Unidades = "adimensional",
            VariavelResultado = "pH",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "HCO3", Nome = "Bicarbonato", Descricao = "[HCO₃⁻]", Unidade = "mEq/L", ValorPadrao = 24, ValorMin = 5, ValorMax = 60, Obrigatoria = true },
                new() { Simbolo = "pCO2", Nome = "Pressão parcial CO₂", Descricao = "pCO₂", Unidade = "mmHg", ValorPadrao = 40, ValorMin = 10, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double HCO3 = inputs["HCO3"];
                double pCO2 = inputs["pCO2"];
                return 6.1 + Math.Log10(HCO3 / (0.0307 * pCO2));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ035_AnionGap()
    {
        return new Formula
        {
            Id = "V8-BQ035",
            CodigoCompendio = "035",
            Nome = "Ânion Gap",
            Categoria = "Bioquímica",
            SubCategoria = "Bioquímica Clínica",
            Expressao = "AG = [Na+] - ([Cl-] + [HCO3-])",
            ExprTexto = "Diferença de ânions",
            Descricao = "Normal: 8-12mEq/L. Elevado: acidose metabólica com ácidos não medidos.",
            Criador = "Emmett e Narins",
            AnoOrigin = "1977",
            ExemploPratico = "AG=140-(102+18)=20 → elevado. Mnemônico MUDPILES: Metanol, Uremia, DKA, Propileno...",
            Unidades = "mEq/L",
            VariavelResultado = "AG",
            UnidadeResultado = "mEq/L",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Na", Nome = "Sódio", Descricao = "[Na⁺]", Unidade = "mEq/L", ValorPadrao = 140, ValorMin = 100, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "Cl", Nome = "Cloreto", Descricao = "[Cl⁻]", Unidade = "mEq/L", ValorPadrao = 102, ValorMin = 80, ValorMax = 130, Obrigatoria = true },
                new() { Simbolo = "HCO3", Nome = "Bicarbonato", Descricao = "[HCO₃⁻]", Unidade = "mEq/L", ValorPadrao = 24, ValorMin = 5, ValorMax = 60, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Na = inputs["Na"];
                double Cl = inputs["Cl"];
                double HCO3 = inputs["HCO3"];
                return Na - (Cl + HCO3);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ036_ScorecardLipinski()
    {
        return new Formula
        {
            Id = "V8-BQ036",
            CodigoCompendio = "036",
            Nome = "Scorecard Lipinski — Regra de 5",
            Categoria = "Bioquímica",
            SubCategoria = "Química Medicinal",
            Expressao = "PM<500; logP<5; HBD<5; HBA<10",
            ExprTexto = "Biodisponibilidade oral",
            Descricao = "Prediz biodisponibilidade oral. Violação de 2+ regras: pobre absorção.",
            Criador = "Christopher Lipinski",
            AnoOrigin = "1997",
            ExemploPratico = "Ciclosporina: PM=1202 → viola (biodisponibilidade baixa, mas exceção). Base de drug design",
            Unidades = "score",
            VariavelResultado = "violations",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "PM", Nome = "Peso molecular", Descricao = "Massa molecular", Unidade = "g/mol", ValorPadrao = 400, ValorMin = 0, ValorMax = 2000, Obrigatoria = true },
                new() { Simbolo = "logP", Nome = "Coef. partição", Descricao = "LogP", Unidade = "", ValorPadrao = 3, ValorMin = -5, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "HBD", Nome = "Doadores H", Descricao = "H-bond donors", Unidade = "", ValorPadrao = 2, ValorMin = 0, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "HBA", Nome = "Aceitadores H", Descricao = "H-bond acceptors", Unidade = "", ValorPadrao = 6, ValorMin = 0, ValorMax = 30, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double PM = inputs["PM"];
                double logP = inputs["logP"];
                double HBD = inputs["HBD"];
                double HBA = inputs["HBA"];
                int violations = 0;
                if (PM > 500) violations++;
                if (logP > 5) violations++;
                if (HBD > 5) violations++;
                if (HBA > 10) violations++;
                return violations;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ037_NoyesWhitney()
    {
        return new Formula
        {
            Id = "V8-BQ037",
            CodigoCompendio = "037",
            Nome = "Equação de Noyes-Whitney (Dissolução)",
            Categoria = "Bioquímica",
            SubCategoria = "Farmacocinética",
            Expressao = "dC/dt = D*A*(Cs-C) / (h*V)",
            ExprTexto = "Taxa de dissolução",
            Descricao = "Taxa de dissolução de sólido. D=difusão, A=área, Cs=saturação, h=camada de difusão.",
            Criador = "Noyes e Whitney",
            AnoOrigin = "1897",
            ExemploPratico = "Reduzir h (agitação) ou aumentar A (micronização) acelera dissolução de comprimido",
            Unidades = "mol/(L·s)",
            VariavelResultado = "dC_dt",
            UnidadeResultado = "mol/(L·s)",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "D", Nome = "Coeficiente difusão", Descricao = "D", Unidade = "cm²/s", ValorPadrao = 1e-5, ValorMin = 1e-10, ValorMax = 1e-2, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "Área superficial", Descricao = "Área do sólido", Unidade = "cm²", ValorPadrao = 100, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "Cs", Nome = "Concentração saturação", Descricao = "Solubilidade", Unidade = "mol/L", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "C", Nome = "Concentração atual", Descricao = "C(t)", Unidade = "mol/L", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Espessura camada difusão", Descricao = "h", Unidade = "cm", ValorPadrao = 0.01, ValorMin = 1e-4, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "V", Nome = "Volume", Descricao = "Volume do meio", Unidade = "L", ValorPadrao = 1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double D = inputs["D"];
                double A = inputs["A"];
                double Cs = inputs["Cs"];
                double C = inputs["C"];
                double h = inputs["h"];
                double V = inputs["V"];
                return (D * A * (Cs - C)) / (h * V);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ038_FluxoDifusao()
    {
        return new Formula
        {
            Id = "V8-BQ038",
            CodigoCompendio = "038",
            Nome = "Fluxo de Difusão Transmembranar",
            Categoria = "Bioquímica",
            SubCategoria = "Biofísica Celular",
            Expressao = "J = P * (C1 - C2)",
            ExprTexto = "Fluxo através de membrana",
            Descricao = "P=coeficiente de permeabilidade (cm/s). J em mol/(cm²·s).",
            Criador = "Overton",
            AnoOrigin = "1901",
            ExemploPratico = "P = D·K/(d). Fármaco lipofílico: P alto. Água: P=10⁻³cm/s via aquaporinas",
            Unidades = "mol/(cm²·s)",
            VariavelResultado = "J",
            UnidadeResultado = "mol/(cm²·s)",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "Permeabilidade", Descricao = "Coef. de permeabilidade", Unidade = "cm/s", ValorPadrao = 1e-5, ValorMin = 1e-10, ValorMax = 1e-2, Obrigatoria = true },
                new() { Simbolo = "C1", Nome = "Concentração lado 1", Descricao = "C₁", Unidade = "mol/L", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "C2", Nome = "Concentração lado 2", Descricao = "C₂", Unidade = "mol/L", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double C1 = inputs["C1"];
                double C2 = inputs["C2"];
                return P * (C1 - C2) / 1000; // Convertendo L para cm³
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ039_CMC()
    {
        return new Formula
        {
            Id = "V8-BQ039",
            CodigoCompendio = "039",
            Nome = "Concentração Micelar Crítica — CMC",
            Categoria = "Bioquímica",
            SubCategoria = "Biofísico-Química",
            Expressao = "μ_monomer = μ_micelle",
            ExprTexto = "Equilíbrio micelar",
            Descricao = "Abaixo da CMC: surfactante como monômero. Acima: micelas formadas.",
            Criador = "Hartley, McBain",
            AnoOrigin = "1936",
            ExemploPratico = "SDS: CMC=8,2mM em água a 25°C. Emulsificação de gorduras na digestão (bile: CMC~2mM)",
            Unidades = "mM",
            VariavelResultado = "CMC_estimada",
            UnidadeResultado = "mM",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n_carbono", Nome = "Número de carbonos", Descricao = "Comprimento da cadeia", Unidade = "", ValorPadrao = 12, ValorMin = 4, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n_carbono = inputs["n_carbono"];
                // Estimativa empírica: log(CMC) ≈ A - B*n_C
                return Math.Exp(5 - 0.5 * n_carbono);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ040_ForcaIonica()
    {
        return new Formula
        {
            Id = "V8-BQ040",
            CodigoCompendio = "040",
            Nome = "Força Iônica",
            Categoria = "Bioquímica",
            SubCategoria = "Eletroquímica",
            Expressao = "I = 0,5 * Σ ci*zi²",
            ExprTexto = "Força iônica de solução",
            Descricao = "Soma ponderada pelo quadrado da carga. Governa escudo eletrostático e atividade iônica.",
            Criador = "Lewis e Randall",
            AnoOrigin = "1921",
            ExemploPratico = "NaCl 0,1M: I=0,5(0,1×1²+0,1×1²)=0,1. MgSO₄ 0,1M: I=0,5(0,1×4+0,1×4)=0,4",
            Unidades = "mol/L",
            VariavelResultado = "I",
            UnidadeResultado = "mol/L",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "c1", Nome = "Concentração íon 1", Descricao = "c₁", Unidade = "mol/L", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "z1", Nome = "Carga íon 1", Descricao = "z₁", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 4, Obrigatoria = true },
                new() { Simbolo = "c2", Nome = "Concentração íon 2", Descricao = "c₂", Unidade = "mol/L", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "z2", Nome = "Carga íon 2", Descricao = "z₂", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 4, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double c1 = inputs["c1"];
                double z1 = inputs["z1"];
                double c2 = inputs["c2"];
                double z2 = inputs["z2"];
                return 0.5 * (c1 * z1 * z1 + c2 * z2 * z2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ041_VarianciaGenetica()
    {
        return new Formula
        {
            Id = "V8-BQ041",
            CodigoCompendio = "041",
            Nome = "Variância Genética — QST vs FST",
            Categoria = "Bioquímica",
            SubCategoria = "Genética de Populações",
            Expressao = "Qst = σ²B/(σ²B + 2*σ²W)",
            ExprTexto = "Diferenciação quantitativa",
            Descricao = "Diferenciação de traços quantitativos entre populações. Qst>Fst: seleção divergente.",
            Criador = "Spitze, Merilä",
            AnoOrigin = "1993",
            ExemploPratico = "Qst(altura)=0,45 vs Fst=0,10 → seleção divergente em populações de Picea. Ecologia evolutiva",
            Unidades = "adimensional",
            VariavelResultado = "Qst",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sigma2_B", Nome = "Variância entre populações", Descricao = "σ²B", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "sigma2_W", Nome = "Variância dentro populações", Descricao = "σ²W", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sigma2_B = inputs["sigma2_B"];
                double sigma2_W = inputs["sigma2_W"];
                return sigma2_B / (sigma2_B + 2 * sigma2_W);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_BQ042_EquacaoMonod()
    {
        return new Formula
        {
            Id = "V8-BQ042",
            CodigoCompendio = "042",
            Nome = "Equação de Monod — Crescimento Microbiano",
            Categoria = "Bioquímica",
            SubCategoria = "Microbiologia",
            Expressao = "μ = μ_max * [S] / (Ks + [S])",
            ExprTexto = "Taxa de crescimento específico",
            Descricao = "Taxa de crescimento específico μ em função do substrato limitante. Análogo a Michaelis-Menten.",
            Criador = "Jacques Monod",
            AnoOrigin = "1942",
            ExemploPratico = "Levedura: μ_max=0,4/h, Ks=0,1g/L, [S]=0,5g/L → μ=0,33/h. Base de biorreatores",
            Unidades = "1/h",
            VariavelResultado = "μ",
            UnidadeResultado = "1/h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "mu_max", Nome = "Taxa máxima", Descricao = "μ_max", Unidade = "1/h", ValorPadrao = 0.4, ValorMin = 0, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Concentração substrato", Descricao = "[S]", Unidade = "g/L", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "Ks", Nome = "Constante de saturação", Descricao = "Ks", Unidade = "g/L", ValorPadrao = 0.1, ValorMin = 0.001, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double mu_max = inputs["mu_max"];
                double S = inputs["S"];
                double Ks = inputs["Ks"];
                return (mu_max * S) / (Ks + S);
            },
            Icone = "∑",
        };
    }
}
