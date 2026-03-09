using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE VI: HIDROLOGIA E RECURSOS HÍDRICOS
    // Escoamento, infiltração, precipitação, águas subterrâneas
    // 20 fórmulas (105-124)
    // ========================================

    public static Formula V8_HID105_EquacaoContinuidade()
    {
        return new Formula
        {
            Id = "V8-HID105",
            CodigoCompendio = "105",
            Nome = "Equação da Continuidade — Hidrologia",
            Categoria = "Hidrologia",
            SubCategoria = "Balanço Hídrico",
            Expressao = "Q = A * v",
            ExprTexto = "Vazão",
            Descricao = "Q=vazão (m³/s), A=área seção transversal (m²), v=velocidade média (m/s). Conservação de massa.",
            Criador = "Princípio de conservação",
            AnoOrigin = "~1700s",
            ExemploPratico = "Rio: A=10m², v=2m/s → Q=20m³/s. Fundamental para hidráulica de canais",
            Unidades = "m³/s",
            VariavelResultado = "Q",
            UnidadeResultado = "m³/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "Área seção", Descricao = "A", Unidade = "m²", ValorPadrao = 10, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "Velocidade média", Descricao = "v", Unidade = "m/s", ValorPadrao = 2, ValorMin = 0.01, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double v = inputs["v"];
                
                return A * v;
            }
        };
    }

    public static Formula V8_HID106_FormulaManning()
    {
        return new Formula
        {
            Id = "V8-HID106",
            CodigoCompendio = "106",
            Nome = "Fórmula de Manning",
            Categoria = "Hidrologia",
            SubCategoria = "Escoamento em Canais",
            Expressao = "v = (1/n) * R^(2/3) * S^(1/2)",
            ExprTexto = "Velocidade de Manning",
            Descricao = "n=coef. rugosidade, R=raio hidráulico (m), S=declividade (m/m). Escoamento uniforme.",
            Criador = "Robert Manning",
            AnoOrigin = "1889",
            ExemploPratico = "Canal: n=0,025 (concreto), R=1,5m, S=0,001 → v≈1,90m/s. n concreto: 0,012-0,015; terra: 0,025-0,030",
            Unidades = "m/s",
            VariavelResultado = "v",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Coef. Manning", Descricao = "n", Unidade = "", ValorPadrao = 0.025, ValorMin = 0.01, ValorMax = 0.15, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Raio hidráulico", Descricao = "R", Unidade = "m", ValorPadrao = 1.5, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Declividade", Descricao = "S", Unidade = "m/m", ValorPadrao = 0.001, ValorMin = 0.0001, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double R = inputs["R"];
                double S = inputs["S"];
                
                return (1.0 / n) * Math.Pow(R, 2.0 / 3.0) * Math.Sqrt(S);
            }
        };
    }

    public static Formula V8_HID107_EquacaoRationalMethod()
    {
        return new Formula
        {
            Id = "V8-HID107",
            CodigoCompendio = "107",
            Nome = "Método Racional — Escoamento Superficial",
            Categoria = "Hidrologia",
            SubCategoria = "Escoamento Superficial",
            Expressao = "Q = C * i * A",
            ExprTexto = "Vazão de pico",
            Descricao = "C=coef. escoamento, i=intensidade chuva (mm/h), A=área (km²). Q em m³/s (fator conv. implícito).",
            Criador = "Kuichling",
            AnoOrigin = "1889",
            ExemploPratico = "Bacia urbana: C=0,7, i=50mm/h, A=2km² → Q≈19,4m³/s. C asfalto: 0,7-0,95; gramado: 0,05-0,35",
            Unidades = "m³/s",
            VariavelResultado = "Q",
            UnidadeResultado = "m³/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C", Nome = "Coef. escoamento", Descricao = "C", Unidade = "", ValorPadrao = 0.7, ValorMin = 0.05, ValorMax = 0.95, Obrigatoria = true },
                new() { Simbolo = "i", Nome = "Intensidade chuva", Descricao = "i", Unidade = "mm/h", ValorPadrao = 50, ValorMin = 1, ValorMax = 300, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "Área bacia", Descricao = "A", Unidade = "km²", ValorPadrao = 2, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C = inputs["C"];
                double i = inputs["i"];
                double A = inputs["A"];
                
                // Fator conversão: 1/3,6 para mm/h·km² → m³/s
                return (C * i * A) / 3.6;
            }
        };
    }

    public static Formula V8_HID108_TempoConcentracao()
    {
        return new Formula
        {
            Id = "V8-HID108",
            CodigoCompendio = "108",
            Nome = "Tempo de Concentração — Kirpich",
            Categoria = "Hidrologia",
            SubCategoria = "Tempo de Resposta",
            Expressao = "tc = 0,0078 * (L^0,77 / S^0,385)",
            ExprTexto = "Tempo de concentração (min)",
            Descricao = "L=comprimento canal principal (m), S=declividade média (m/m). tc=minutos.",
            Criador = "Kirpich",
            AnoOrigin = "1940",
            ExemploPratico = "L=1000m, S=0,02 → tc≈13,6min. Hidrograma: pico em tc. Outros: Dooge, SCS lag",
            Unidades = "min",
            VariavelResultado = "tc",
            UnidadeResultado = "min",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L", Nome = "Comprimento", Descricao = "L", Unidade = "m", ValorPadrao = 1000, ValorMin = 10, ValorMax = 100000, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Declividade", Descricao = "S", Unidade = "m/m", ValorPadrao = 0.02, ValorMin = 0.0001, ValorMax = 0.5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L = inputs["L"];
                double S = inputs["S"];
                
                return 0.0078 * Math.Pow(L, 0.77) / Math.Pow(S, 0.385);
            }
        };
    }

    public static Formula V8_HID109_LeiDarcy()
    {
        return new Formula
        {
            Id = "V8-HID109",
            CodigoCompendio = "109",
            Nome = "Lei de Darcy — Fluxo Subsuperficial",
            Categoria = "Hidrologia",
            SubCategoria = "Águas Subterrâneas",
            Expressao = "q = -K * (dh/dl)",
            ExprTexto = "Vazão específica",
            Descricao = "q=vazão específica (m/s), K=condutividade hidráulica (m/s), dh/dl=gradiente hidráulico.",
            Criador = "Henry Darcy",
            AnoOrigin = "1856",
            ExemploPratico = "K=0,001m/s (areia fina), dh/dl=0,01 → q=1e-5m/s. Q=q·A. Aquíferos, percolação",
            Unidades = "m/s",
            VariavelResultado = "q",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "K", Nome = "Condutividade hidráulica", Descricao = "K", Unidade = "m/s", ValorPadrao = 0.001, ValorMin = 1e-10, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "dh_dl", Nome = "Gradiente hidráulico", Descricao = "dh/dl", Unidade = "", ValorPadrao = 0.01, ValorMin = 0.0001, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double K = inputs["K"];
                double dh_dl = inputs["dh_dl"];
                
                return -K * dh_dl;
            }
        };
    }

    public static Formula V8_HID110_InfiltracaoHorton()
    {
        return new Formula
        {
            Id = "V8-HID110",
            CodigoCompendio = "110",
            Nome = "Modelo de Infiltração de Horton",
            Categoria = "Hidrologia",
            SubCategoria = "Infiltração",
            Expressao = "f(t) = fc + (f0 - fc) * exp(-k * t)",
            ExprTexto = "Taxa de infiltração",
            Descricao = "f(t)=infiltração (mm/h), f0=inicial, fc=capacidade final, k=constante de decaimento.",
            Criador = "Robert E. Horton",
            AnoOrigin = "1940",
            ExemploPratico = "f0=100mm/h, fc=10mm/h, k=2h⁻¹, t=1h → f≈22mm/h. Uso em modelos hidrológicos",
            Unidades = "mm/h",
            VariavelResultado = "f",
            UnidadeResultado = "mm/h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f0", Nome = "Infiltração inicial", Descricao = "f0", Unidade = "mm/h", ValorPadrao = 100, ValorMin = 1, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "fc", Nome = "Capacidade final", Descricao = "fc", Unidade = "mm/h", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Constante decaimento", Descricao = "k", Unidade = "h⁻¹", ValorPadrao = 2, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "t", Unidade = "h", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f0 = inputs["f0"];
                double fc = inputs["fc"];
                double k = inputs["k"];
                double t = inputs["t"];
                
                return fc + (f0 - fc) * Math.Exp(-k * t);
            }
        };
    }

    public static Formula V8_HID111_EquacaoGreenAmpt()
    {
        return new Formula
        {
            Id = "V8-HID111",
            CodigoCompendio = "111",
            Nome = "Green-Ampt — Infiltração Cumulativa",
            Categoria = "Hidrologia",
            SubCategoria = "Infiltração",
            Expressao = "F = K * t + ψ * Δθ * ln(1 + F/(ψ*Δθ))",
            ExprTexto = "Infiltração acumulada (simplificada)",
            Descricao = "F=infiltração acum. (m), K=condutividade (m/s), ψ=sucção capilar (m), Δθ=déficit umidade.",
            Criador = "Green & Ampt",
            AnoOrigin = "1911",
            ExemploPratico = "K=1e-5m/s, ψ=0,1m, Δθ=0,3. Equação implícita, resolve numericamente ou aproxima",
            Unidades = "m",
            VariavelResultado = "F_approx",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "K", Nome = "Condutividade", Descricao = "K", Unidade = "m/s", ValorPadrao = 1e-5, ValorMin = 1e-10, ValorMax = 0.01, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "t", Unidade = "s", ValorPadrao = 3600, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "psi", Nome = "Sucção capilar", Descricao = "ψ", Unidade = "m", ValorPadrao = 0.1, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "delta_theta", Nome = "Déficit umidade", Descricao = "Δθ", Unidade = "", ValorPadrao = 0.3, ValorMin = 0.01, ValorMax = 0.6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double K = inputs["K"];
                double t = inputs["t"];
                double psi = inputs["psi"];
                double delta_theta = inputs["delta_theta"];
                
                // Aproximação linear inicial: F ≈ K*t
                return K * t;
            }
        };
    }

    public static Formula V8_HID112_EvapotranspiracaoPenmanMonteith()
    {
        return new Formula
        {
            Id = "V8-HID112",
            CodigoCompendio = "112",
            Nome = "Evapotranspiração — Penman-Monteith (simplificado)",
            Categoria = "Hidrologia",
            SubCategoria = "Evapotranspiração",
            Expressao = "ET0 = (Δ * Rn + γ * Ea) / (Δ + γ)",
            ExprTexto = "Evapotranspiração referência",
            Descricao = "Δ=slope vapor pressure (kPa/°C), Rn=rad. líq. (MJ/m²/d), γ=psicrométrica, Ea=aerod (mm/d).",
            Criador = "Penman, Monteith",
            AnoOrigin = "1948, 1965",
            ExemploPratico = "Δ=0,2, Rn=15, γ=0,067, Ea=3 → ET0≈11,5mm/d. FAO-56: padrão irrigação",
            Unidades = "mm/d",
            VariavelResultado = "ET0",
            UnidadeResultado = "mm/d",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Delta", Nome = "Slope vapor", Descricao = "Δ", Unidade = "kPa/°C", ValorPadrao = 0.2, ValorMin = 0.05, ValorMax = 0.5, Obrigatoria = true },
                new() { Simbolo = "Rn", Nome = "Radiação líquida", Descricao = "Rn", Unidade = "MJ/m²/d", ValorPadrao = 15, ValorMin = 0, ValorMax = 30, Obrigatoria = true },
                new() { Simbolo = "gamma", Nome = "Const. psicrométrica", Descricao = "γ", Unidade = "kPa/°C", ValorPadrao = 0.067, ValorMin = 0.05, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "Ea", Nome = "Termo aerodinâmico", Descricao = "Ea", Unidade = "mm/d", ValorPadrao = 3, ValorMin = 0, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Delta = inputs["Delta"];
                double Rn = inputs["Rn"];
                double gamma = inputs["gamma"];
                double Ea = inputs["Ea"];
                
                return (Delta * Rn + gamma * Ea) / (Delta + gamma);
            }
        };
    }

    public static Formula V8_HID113_CurvaIDF()
    {
        return new Formula
        {
            Id = "V8-HID113",
            CodigoCompendio = "113",
            Nome = "Curva IDF — Intensidade-Duração-Frequência",
            Categoria = "Hidrologia",
            SubCategoria = "Precipitação",
            Expressao = "i = (K * Tr^a) / (t + b)^c",
            ExprTexto = "Intensidade de chuva",
            Descricao = "i=intensidade (mm/h), Tr=período retorno (anos), t=duração (min), K,a,b,c: coef. regionais.",
            Criador = "Análise estatística regional",
            AnoOrigin = "~1950s",
            ExemploPratico = "K=1000, a=0,15, b=20, c=0,8, Tr=10anos, t=30min → i≈35mm/h. Projeto drenagem",
            Unidades = "mm/h",
            VariavelResultado = "i",
            UnidadeResultado = "mm/h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "K", Nome = "Coef. K", Descricao = "K", Unidade = "", ValorPadrao = 1000, ValorMin = 100, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "Tr", Nome = "Período retorno", Descricao = "Tr", Unidade = "anos", ValorPadrao = 10, ValorMin = 2, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Expoente a", Descricao = "a", Unidade = "", ValorPadrao = 0.15, ValorMin = 0.05, ValorMax = 0.3, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Duração", Descricao = "t", Unidade = "min", ValorPadrao = 30, ValorMin = 5, ValorMax = 1440, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Coef. b", Descricao = "b", Unidade = "min", ValorPadrao = 20, ValorMin = 5, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Expoente c", Descricao = "c", Unidade = "", ValorPadrao = 0.8, ValorMin = 0.5, ValorMax = 1.2, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double K = inputs["K"];
                double Tr = inputs["Tr"];
                double a = inputs["a"];
                double t = inputs["t"];
                double b = inputs["b"];
                double c = inputs["c"];
                
                return (K * Math.Pow(Tr, a)) / Math.Pow(t + b, c);
            }
        };
    }

    public static Formula V8_HID114_NumCurva_SCS()
    {
        return new Formula
        {
            Id = "V8-HID114",
            CodigoCompendio = "114",
            Nome = "Método SCS Curve Number — Escoamento Direto",
            Categoria = "Hidrologia",
            SubCategoria = "Escoamento Superficial",
            Expressao = "Q = (P - 0,2*S)² / (P + 0,8*S) para P > 0,2*S; S=(25400/CN - 254)",
            ExprTexto = "Escoamento direto",
            Descricao = "P=precip. (mm), CN=curve number (0-100), S=retenção potencial (mm), Q=runoff (mm).",
            Criador = "USDA Soil Conservation Service",
            AnoOrigin = "1954",
            ExemploPratico = "CN=75 (urban), P=100mm → S=84,7mm, Ia=16,9mm → Q≈39,5mm. CN alto: mais runoff",
            Unidades = "mm",
            VariavelResultado = "Q",
            UnidadeResultado = "mm",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "Precipitação", Descricao = "P", Unidade = "mm", ValorPadrao = 100, ValorMin = 0, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "CN", Nome = "Curve Number", Descricao = "CN", Unidade = "", ValorPadrao = 75, ValorMin = 30, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double CN = inputs["CN"];
                
                double S = (25400.0 / CN) - 254.0;
                double Ia = 0.2 * S;
                
                if (P <= Ia) return 0;
                
                double numerator = Math.Pow(P - Ia, 2);
                double denominator = P + 0.8 * S;
                
                return numerator / denominator;
            }
        };
    }

    public static Formula V8_HID115_CoefWeibull()
    {
        return new Formula
        {
            Id = "V8-HID115",
            CodigoCompendio = "115",
            Nome = "Posição de Plotagem — Weibull",
            Categoria = "Hidrologia",
            SubCategoria = "Análise de Frequência",
            Expressao = "P = m / (n + 1)",
            ExprTexto = "Probabilidade empírica",
            Descricao = "m=posição ordem, n=tamanho amostra. P=prob. excedência. Tr=1/P. Análise de cheias.",
            Criador = "Weibull",
            AnoOrigin = "1939",
            ExemploPratico = "n=20 dados vazão, 3ª maior: m=3 → P=0,143 → Tr≈7anos. Outras: Gringorten, Cunnane",
            Unidades = "adimensional",
            VariavelResultado = "P",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Ordem posição", Descricao = "m", Unidade = "", ValorPadrao = 3, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Tamanho amostra", Descricao = "n", Unidade = "", ValorPadrao = 20, ValorMin = 1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double n = inputs["n"];
                
                return m / (n + 1);
            }
        };
    }

    public static Formula V8_HID116_UnitsHydro_SCS()
    {
        return new Formula
        {
            Id = "V8-HID116",
            CodigoCompendio = "116",
            Nome = "Vazão de Pico — Hidrograma Unitário SCS",
            Categoria = "Hidrologia",
            SubCategoria = "Hidrogramas",
            Expressao = "Qp = (0,208 * A * Q_runoff) / Tp",
            ExprTexto = "Vazão de pico (m³/s)",
            Descricao = "A=área (km²), Q_runoff=lâmina escoamento (mm), Tp=tempo pico (h). Hidrograma triangular.",
            Criador = "SCS/NRCS",
            AnoOrigin = "~1970s",
            ExemploPratico = "A=10km², Q_runoff=50mm, Tp=2h → Qp≈52m³/s. Base=2,67*Tp. Uso em design",
            Unidades = "m³/s",
            VariavelResultado = "Qp",
            UnidadeResultado = "m³/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "Área bacia", Descricao = "A", Unidade = "km²", ValorPadrao = 10, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "Q_runoff", Nome = "Lâmina escoamento", Descricao = "Q_runoff", Unidade = "mm", ValorPadrao = 50, ValorMin = 1, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "Tp", Nome = "Tempo pico", Descricao = "Tp", Unidade = "h", ValorPadrao = 2, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double Q_runoff = inputs["Q_runoff"];
                double Tp = inputs["Tp"];
                
                return (0.208 * A * Q_runoff) / Tp;
            }
        };
    }

    public static Formula V8_HID117_TransmissividadeAquifero()
    {
        return new Formula
        {
            Id = "V8-HID117",
            CodigoCompendio = "117",
            Nome = "Transmissividade de Aquífero",
            Categoria = "Hidrologia",
            SubCategoria = "Águas Subterrâneas",
            Expressao = "T = K * b",
            ExprTexto = "Transmissividade",
            Descricao = "T=transmissividade (m²/s), K=condutividade hidráulica (m/s), b=espessura saturada (m).",
            Criador = "Hidrogeologia",
            AnoOrigin = "~1940s",
            ExemploPratico = "K=1e-4m/s, b=20m → T=0,002m²/s. Poços: Q=2πT·Δh/ln(r2/r1) (Thiem)",
            Unidades = "m²/s",
            VariavelResultado = "T",
            UnidadeResultado = "m²/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "K", Nome = "Condutividade hidráulica", Descricao = "K", Unidade = "m/s", ValorPadrao = 1e-4, ValorMin = 1e-10, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Espessura saturada", Descricao = "b", Unidade = "m", ValorPadrao = 20, ValorMin = 0.1, ValorMax = 500, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double K = inputs["K"];
                double b = inputs["b"];
                
                return K * b;
            }
        };
    }

    public static Formula V8_HID118_EquacaoThiem()
    {
        return new Formula
        {
            Id = "V8-HID118",
            CodigoCompendio = "118",
            Nome = "Equação de Thiem — Poço em Aquífero Confinado",
            Categoria = "Hidrologia",
            SubCategoria = "Águas Subterrâneas",
            Expressao = "Q = (2*π*T*(h1-h2)) / ln(r2/r1)",
            ExprTexto = "Vazão do poço",
            Descricao = "T=transmissividade (m²/s), h1,h2=níveis piezométricos (m), r1,r2=raios (m).",
            Criador = "Günther Thiem",
            AnoOrigin = "1906",
            ExemploPratico = "T=0,001m²/s, h1-h2=5m, r2/r1=10 → Q≈0,0136m³/s. Steady state, confinado",
            Unidades = "m³/s",
            VariavelResultado = "Q",
            UnidadeResultado = "m³/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T", Nome = "Transmissividade", Descricao = "T", Unidade = "m²/s", ValorPadrao = 0.001, ValorMin = 1e-6, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "h1_minus_h2", Nome = "Δh=h1-h2", Descricao = "h1-h2", Unidade = "m", ValorPadrao = 5, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "r2", Nome = "Raio r2", Descricao = "r2", Unidade = "m", ValorPadrao = 100, ValorMin = 1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "r1", Nome = "Raio r1", Descricao = "r1", Unidade = "m", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T = inputs["T"];
                double h1_minus_h2 = inputs["h1_minus_h2"];
                double r2 = inputs["r2"];
                double r1 = inputs["r1"];
                
                return (2 * Math.PI * T * h1_minus_h2) / Math.Log(r2 / r1);
            }
        };
    }

    public static Formula V8_HID119_CoefArmazenamento()
    {
        return new Formula
        {
            Id = "V8-HID119",
            CodigoCompendio = "119",
            Nome = "Coeficiente de Armazenamento — Aquífero Confinado",
            Categoria = "Hidrologia",
            SubCategoria = "Águas Subterrâneas",
            Expressao = "S = Ss * b",
            ExprTexto = "Armazenamento específico",
            Descricao = "S=coef. armazenamento (adimens.), Ss=armazenamento específico (1/m), b=espessura (m).",
            Criador = "Hidrogeologia",
            AnoOrigin = "~1940s",
            ExemploPratico = "Ss=1e-5m⁻¹, b=50m → S=5e-4. Confinado: S~10⁻⁵-10⁻³. Livre: Sy~0,1-0,3",
            Unidades = "adimensional",
            VariavelResultado = "S",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Ss", Nome = "Armazenamento específico", Descricao = "Ss", Unidade = "1/m", ValorPadrao = 1e-5, ValorMin = 1e-7, ValorMax = 1e-3, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Espessura", Descricao = "b", Unidade = "m", ValorPadrao = 50, ValorMin = 1, ValorMax = 500, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Ss = inputs["Ss"];
                double b = inputs["b"];
                
                return Ss * b;
            }
        };
    }

    public static Formula V8_HID120_EquacaoDupit()
    {
        return new Formula
        {
            Id = "V8-HID120",
            CodigoCompendio = "120",
            Nome = "Equação de Dupuit — Aquífero Livre",
            Categoria = "Hidrologia",
            SubCategoria = "Águas Subterrâneas",
            Expressao = "Q = (π*K*(h1²-h2²)) / ln(r2/r1)",
            ExprTexto = "Vazão em aquífero livre",
            Descricao = "K=condutividade (m/s), h1,h2=alturas nível freático (m), r1,r2=raios (m).",
            Criador = "Jules Dupuit",
            AnoOrigin = "1863",
            ExemploPratico = "K=1e-4m/s, h1=10m, h2=8m, r2/r1=10 → Q≈0,024m³/s. Aquífero não confinado (freático)",
            Unidades = "m³/s",
            VariavelResultado = "Q",
            UnidadeResultado = "m³/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "K", Nome = "Condutividade hidráulica", Descricao = "K", Unidade = "m/s", ValorPadrao = 1e-4, ValorMin = 1e-10, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "h1", Nome = "Altura h1", Descricao = "h1", Unidade = "m", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "h2", Nome = "Altura h2", Descricao = "h2", Unidade = "m", ValorPadrao = 8, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "r2", Nome = "Raio r2", Descricao = "r2", Unidade = "m", ValorPadrao = 100, ValorMin = 1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "r1", Nome = "Raio r1", Descricao = "r1", Unidade = "m", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double K = inputs["K"];
                double h1 = inputs["h1"];
                double h2 = inputs["h2"];
                double r2 = inputs["r2"];
                double r1 = inputs["r1"];
                
                return (Math.PI * K * (h1 * h1 - h2 * h2)) / Math.Log(r2 / r1);
            }
        };
    }

    public static Formula V8_HID121_BalancoLago()
    {
        return new Formula
        {
            Id = "V8-HID121",
            CodigoCompendio = "121",
            Nome = "Balanço Hídrico de Lago",
            Categoria = "Hidrologia",
            SubCategoria = "Balanço Hídrico",
            Expressao = "ΔS = P + Qin - E - Qout - G",
            ExprTexto = "Variação armazenamento",
            Descricao = "P=precipitação, Qin=entrada, E=evaporação, Qout=saída, G=infiltração. Todas em volume ou lâmina.",
            Criador = "Princípio conservação",
            AnoOrigin = "~1800s",
            ExemploPratico = "P=100mm, Qin=50mm, E=80mm, Qout=40mm, G=10mm → ΔS=20mm (subiu nível)",
            Unidades = "mm",
            VariavelResultado = "delta_S",
            UnidadeResultado = "mm",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "Precipitação", Descricao = "P", Unidade = "mm", ValorPadrao = 100, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "Qin", Nome = "Entrada", Descricao = "Qin", Unidade = "mm", ValorPadrao = 50, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "E", Nome = "Evaporação", Descricao = "E", Unidade = "mm", ValorPadrao = 80, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "Qout", Nome = "Saída", Descricao = "Qout", Unidade = "mm", ValorPadrao = 40, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "G", Nome = "Infiltração", Descricao = "G", Unidade = "mm", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double Qin = inputs["Qin"];
                double E = inputs["E"];
                double Qout = inputs["Qout"];
                double G = inputs["G"];
                
                return P + Qin - E - Qout - G;
            }
        };
    }

    public static Formula V8_HID122_VelocidadeCritica()
    {
        return new Formula
        {
            Id = "V8-HID122",
            CodigoCompendio = "122",
            Nome = "Velocidade Crítica — Início de Erosão",
            Categoria = "Hidrologia",
            SubCategoria = "Erosão e Transporte",
            Expressao = "Vc = k * sqrt(g * d * (ρs/ρw - 1))",
            ExprTexto = "Velocidade crítica",
            Descricao = "k~1 (coef.), g=gravidade (m/s²), d=diâmetro partícula (m), ρs/ρw=densidade relativa.",
            Criador = "Hjulström, Shields",
            AnoOrigin = "1935, 1936",
            ExemploPratico = "d=0,001m (areia fina), ρs/ρw=2,65, g=9,81 → Vc≈0,13m/s. Shields: τc=θc·(ρs-ρw)·g·d",
            Unidades = "m/s",
            VariavelResultado = "Vc",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Coef. empírico", Descricao = "k", Unidade = "", ValorPadrao = 1, ValorMin = 0.5, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Aceleração gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Diâmetro partícula", Descricao = "d", Unidade = "m", ValorPadrao = 0.001, ValorMin = 1e-6, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "rho_s_over_rho_w", Nome = "ρs/ρw", Descricao = "Densidade relativa", Unidade = "", ValorPadrao = 2.65, ValorMin = 1.1, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double g = inputs["g"];
                double d = inputs["d"];
                double rho_ratio = inputs["rho_s_over_rho_w"];
                
                return k * Math.Sqrt(g * d * (rho_ratio - 1));
            }
        };
    }

    public static Formula V8_HID123_EquacaoSaintVenant()
    {
        return new Formula
        {
            Id = "V8-HID123",
            CodigoCompendio = "123",
            Nome = "Saint-Venant — Conservação Momento (simplificado)",
            Categoria = "Hidrologia",
            SubCategoria = "Hidráulica de Canais",
            Expressao = "dv/dt + v*dv/dx = -g*(dz/dx + Sf)",
            ExprTexto = "Equação momento",
            Descricao = "v=velocidade, z=elevação superfície, Sf=slope fricção. Escoamento não-permanente.",
            Criador = "Adhémar Jean Claude Barré de Saint-Venant",
            AnoOrigin = "1871",
            ExemploPratico = "Propagação onda cheia em rio. Resolve numericamente com continuidade. HEC-RAS, MIKE 11",
            Unidades = "m/s²",
            VariavelResultado = "accel",
            UnidadeResultado = "m/s²",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "dz_dx", Nome = "dz/dx", Descricao = "Decliv. superfície", Unidade = "", ValorPadrao = -0.001, ValorMin = -0.1, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "Sf", Nome = "Slope fricção", Descricao = "Sf", Unidade = "", ValorPadrao = 0.0005, ValorMin = 0, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double g = inputs["g"];
                double dz_dx = inputs["dz_dx"];
                double Sf = inputs["Sf"];
                
                // Retorna aceleração gravitacional e friccional: -g*(dz/dx + Sf)
                return -g * (dz_dx + Sf);
            }
        };
    }

    public static Formula V8_HID124_NumeroFroude()
    {
        return new Formula
        {
            Id = "V8-HID124",
            CodigoCompendio = "124",
            Nome = "Número de Froude — Escoamento em Canal",
            Categoria = "Hidrologia",
            SubCategoria = "Hidráulica de Canais",
            Expressao = "Fr = v / sqrt(g * h)",
            ExprTexto = "Número de Froude",
            Descricao = "v=velocidade (m/s), h=profundidade hidráulica (m). Fr<1: subcrítico. Fr=1: crítico. Fr>1: supercrítico.",
            Criador = "William Froude",
            AnoOrigin = "1870",
            ExemploPratico = "v=2m/s, h=1m, g=9,81 → Fr≈0,64 (subcrítico). Ressalto hidráulico: Fr>1→Fr<1",
            Unidades = "adimensional",
            VariavelResultado = "Fr",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v", Nome = "Velocidade", Descricao = "v", Unidade = "m/s", ValorPadrao = 2, ValorMin = 0.01, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Profundidade hidráulica", Descricao = "h", Unidade = "m", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v = inputs["v"];
                double g = inputs["g"];
                double h = inputs["h"];
                
                return v / Math.Sqrt(g * h);
            }
        };
    }
}
