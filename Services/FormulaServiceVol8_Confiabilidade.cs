using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XIV: CONFIABILIDADE E ENGENHARIA DE MANUTENÇÃO
    // MTBF, MTTF, Weibull, availability, failure rate, sistemas série/paralelo
    // 16 fórmulas (259-274)
    // ========================================

    public static Formula V8_REL259_MTBF()
    {
        return new Formula
        {
            Id = "V8-REL259",
            CodigoCompendio = "259",
            Nome = "Mean Time Between Failures — MTBF",
            Categoria = "Confiabilidade",
            SubCategoria = "Métricas de Confiabilidade",
            Expressao = "MTBF = Total Operating Time / Number of Failures",
            ExprTexto = "MTBF",
            Descricao = "Tempo médio entre falhas (sistemas reparáveis). MTBF alto: mais confiável. Unidade: horas típico.",
            Criador = "Engenharia de confiabilidade",
            AnoOrigin = "~1950s",
            ExemploPratico = "10000h operação, 5 falhas → MTBF=2000h. Disponibilidade: A=MTBF/(MTBF+MTTR)",
            Unidades = "h",
            VariavelResultado = "MTBF",
            UnidadeResultado = "h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "total_time", Nome = "Tempo total", Descricao = "Operating time", Unidade = "h", ValorPadrao = 10000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "n_failures", Nome = "Falhas", Descricao = "Number of failures", Unidade = "", ValorPadrao = 5, ValorMin = 1, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double total_time = inputs["total_time"];
                double n_failures = inputs["n_failures"];
                
                return total_time / n_failures;
            }
        };
    }

    public static Formula V8_REL260_MTTF()
    {
        return new Formula
        {
            Id = "V8-REL260",
            CodigoCompendio = "260",
            Nome = "Mean Time To Failure — MTTF",
            Categoria = "Confiabilidade",
            SubCategoria = "Métricas de Confiabilidade",
            Expressao = "MTTF = ∫₀^∞ R(t) dt",
            ExprTexto = "MTTF (exponencial: 1/λ)",
            Descricao = "Tempo médio até falha (sistemas não reparáveis). MTTF=1/λ para exponencial. R(t)=confiabilidade.",
            Criador = "Engenharia de confiabilidade",
            AnoOrigin = "~1950s",
            ExemploPratico = "λ=0,001 falhas/h → MTTF=1000h. Componentes: lâmpadas, baterias (não reparáveis)",
            Unidades = "h",
            VariavelResultado = "MTTF",
            UnidadeResultado = "h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Failure rate", Unidade = "1/h", ValorPadrao = 0.001, ValorMin = 1e-9, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                
                return 1.0 / lambda;
            }
        };
    }

    public static Formula V8_REL261_TaxaFalha()
    {
        return new Formula
        {
            Id = "V8-REL261",
            CodigoCompendio = "261",
            Nome = "Taxa de Falha — λ(t)",
            Categoria = "Confiabilidade",
            SubCategoria = "Métricas de Confiabilidade",
            Expressao = "λ(t) = f(t) / R(t)",
            ExprTexto = "Failure rate (hazard)",
            Descricao = "f(t)=densidade falha, R(t)=confiabilidade. λ constante: distribuição exponencial. Curva banheira.",
            Criador = "Engenharia de confiabilidade",
            AnoOrigin = "~1950s",
            ExemploPratico = "Bathtub: mortalidade infantil (λ↓) → vida útil (λ~const) → desgaste (λ↑)",
            Unidades = "1/h",
            VariavelResultado = "lambda",
            UnidadeResultado = "1/h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f_t", Nome = "f(t)", Descricao = "Densidade falha", Unidade = "1/h", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "R_t", Nome = "R(t)", Descricao = "Confiabilidade", Unidade = "", ValorPadrao = 0.9, ValorMin = 0.01, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f_t = inputs["f_t"];
                double R_t = inputs["R_t"];
                
                return f_t / R_t;
            }
        };
    }

    public static Formula V8_REL262_ConfiabilidadeExponencial()
    {
        return new Formula
        {
            Id = "V8-REL262",
            CodigoCompendio = "262",
            Nome = "Confiabilidade — Distribuição Exponencial",
            Categoria = "Confiabilidade",
            SubCategoria = "Modelos de Confiabilidade",
            Expressao = "R(t) = exp(-λ * t)",
            ExprTexto = "R(t) exponencial",
            Descricao = "λ=taxa falha constante. Memoryless: P(T>t+s|T>t)=P(T>s). Vida útil componentes eletrônicos.",
            Criador = "Estatística de confiabilidade",
            AnoOrigin = "~1950s",
            ExemploPratico = "λ=0,0001/h, t=1000h → R(1000h)≈0,905 (90,5% sobrevivência). t=10000h → R≈0,368",
            Unidades = "adimensional",
            VariavelResultado = "R_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Taxa falha", Unidade = "1/h", ValorPadrao = 0.0001, ValorMin = 1e-9, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "h", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                double t = inputs["t"];
                
                return Math.Exp(-lambda * t);
            }
        };
    }

    public static Formula V8_REL263_DistribuicaoWeibull_Confiabilidade()
    {
        return new Formula
        {
            Id = "V8-REL263",
            CodigoCompendio = "263",
            Nome = "Confiabilidade — Distribuição Weibull",
            Categoria = "Confiabilidade",
            SubCategoria = "Modelos de Confiabilidade",
            Expressao = "R(t) = exp(-(t/η)^β)",
            ExprTexto = "Weibull R(t)",
            Descricao = "η=escala (vida característica), β=forma. β<1: mortalidade infantil. β=1: exponencial. β>1: desgaste.",
            Criador = "Waloddi Weibull",
            AnoOrigin = "1951",
            ExemploPratico = "η=10000h, β=2 (desgaste): t=10000h → R≈0,368. t=5000h → R≈0,778. β=3: fadiga",
            Unidades = "adimensional",
            VariavelResultado = "R_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "h", ValorPadrao = 10000, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "eta", Nome = "η", Descricao = "Escala", Unidade = "h", ValorPadrao = 10000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "beta", Nome = "β", Descricao = "Forma", Unidade = "", ValorPadrao = 2, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t = inputs["t"];
                double eta = inputs["eta"];
                double beta = inputs["beta"];
                
                return Math.Exp(-Math.Pow(t / eta, beta));
            }
        };
    }

    public static Formula V8_REL264_TaxaFalha_Weibull()
    {
        return new Formula
        {
            Id = "V8-REL264",
            CodigoCompendio = "264",
            Nome = "Taxa de Falha Weibull — λ(t)",
            Categoria = "Confiabilidade",
            SubCategoria = "Modelos de Confiabilidade",
            Expressao = "λ(t) = (β/η) * (t/η)^(β-1)",
            ExprTexto = "Weibull hazard",
            Descricao = "η=escala, β=forma. Curva banheira modelável: β<1 (DFR), β=1 (CFR), β>1 (IFR).",
            Criador = "Waloddi Weibull",
            AnoOrigin = "1951",
            ExemploPratico = "η=10000, β=2: λ(t) cresce linearmente (desgaste). β=0,5: λ(t) decrescente (burn-in)",
            Unidades = "1/h",
            VariavelResultado = "lambda_t",
            UnidadeResultado = "1/h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "h", ValorPadrao = 5000, ValorMin = 0.01, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "eta", Nome = "η", Descricao = "Escala", Unidade = "h", ValorPadrao = 10000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "beta", Nome = "β", Descricao = "Forma", Unidade = "", ValorPadrao = 2, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double t = inputs["t"];
                double eta = inputs["eta"];
                double beta = inputs["beta"];
                
                return (beta / eta) * Math.Pow(t / eta, beta - 1);
            }
        };
    }

    public static Formula V8_REL265_Disponibilidade()
    {
        return new Formula
        {
            Id = "V8-REL265",
            CodigoCompendio = "265",
            Nome = "Disponibilidade — A",
            Categoria = "Confiabilidade",
            SubCategoria = "Métricas de Manutenção",
            Expressao = "A = MTBF / (MTBF + MTTR)",
            ExprTexto = "Availability",
            Descricao = "MTBF=tempo entre falhas, MTTR=tempo médio reparo. A∈[0,1]. 5-nines: A=0,99999 (5,26min/ano).",
            Criador = "Engenharia de manutenção",
            AnoOrigin = "~1960s",
            ExemploPratico = "MTBF=2000h, MTTR=10h → A≈0,9950 (99,5%). A=0,999: 8,76h downtime/ano",
            Unidades = "adimensional",
            VariavelResultado = "A",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "MTBF", Nome = "MTBF", Descricao = "Mean time between failures", Unidade = "h", ValorPadrao = 2000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "MTTR", Nome = "MTTR", Descricao = "Mean time to repair", Unidade = "h", ValorPadrao = 10, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double MTBF = inputs["MTBF"];
                double MTTR = inputs["MTTR"];
                
                return MTBF / (MTBF + MTTR);
            }
        };
    }

    public static Formula V8_REL266_ConfiabilidadeSerie()
    {
        return new Formula
        {
            Id = "V8-REL266",
            CodigoCompendio = "266",
            Nome = "Confiabilidade Sistema Série",
            Categoria = "Confiabilidade",
            SubCategoria = "Sistemas",
            Expressao = "R_sys = R1 * R2 * ... * Rn",
            ExprTexto = "Series reliability",
            Descricao = "Sistema falha se qualquer componente falha. R_sys≤min(R_i). n↑ → R_sys↓ rapidamente.",
            Criador = "Teoria de confiabilidade",
            AnoOrigin = "~1950s",
            ExemploPratico = "3 componentes: R1=0,9, R2=0,9, R3=0,9 → R_sys=0,729 (72,9%). 10 comp.: R_sys≈0,349",
            Unidades = "adimensional",
            VariavelResultado = "R_sys",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R1", Nome = "R1", Descricao = "Confiab. comp. 1", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "R2", Nome = "R2", Descricao = "Confiab. comp. 2", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "R3", Nome = "R3", Descricao = "Confiab. comp. 3", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R1 = inputs["R1"];
                double R2 = inputs["R2"];
                double R3 = inputs["R3"];
                
                return R1 * R2 * R3;
            }
        };
    }

    public static Formula V8_REL267_ConfiabilidadeParalelo()
    {
        return new Formula
        {
            Id = "V8-REL267",
            CodigoCompendio = "267",
            Nome = "Confiabilidade Sistema Paralelo",
            Categoria = "Confiabilidade",
            SubCategoria = "Sistemas",
            Expressao = "R_sys = 1 - (1-R1) * (1-R2) * ... * (1-Rn)",
            ExprTexto = "Parallel reliability",
            Descricao = "Redundância: sistema funciona se ≥1 componente funciona. R_sys≥max(R_i). Aumenta confiabilidade.",
            Criador = "Teoria de confiabilidade",
            AnoOrigin = "~1950s",
            ExemploPratico = "2 comp. R=0,9 → R_sys=1-(0,1)²=0,99 (99%). 3 comp.: R_sys=0,999 (redundância tripla)",
            Unidades = "adimensional",
            VariavelResultado = "R_sys",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R1", Nome = "R1", Descricao = "Confiab. comp. 1", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "R2", Nome = "R2", Descricao = "Confiab. comp. 2", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R1 = inputs["R1"];
                double R2 = inputs["R2"];
                
                return 1 - (1 - R1) * (1 - R2);
            }
        };
    }

    public static Formula V8_REL268_FatorMelhoria_Redundancia()
    {
        return new Formula
        {
            Id = "V8-REL268",
            CodigoCompendio = "268",
            Nome = "Fator de Melhoria — Redundância",
            Categoria = "Confiabilidade",
            SubCategoria = "Redundância",
            Expressao = "IF = R_sys_redundant / R_sys_original",
            ExprTexto = "Improvement factor",
            Descricao = "IF>1: melhoria. Redundância paralela: IF significativo. Custo vs benefício.",
            Criador = "Engenharia de confiabilidade",
            AnoOrigin = "~1960s",
            ExemploPratico = "R_orig=0,9, R_redund=0,99 → IF≈1,1 (10% melhoria). Triplo: IF até 1,11",
            Unidades = "adimensional",
            VariavelResultado = "IF",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R_redundant", Nome = "R redundante", Descricao = "Confiab. com redundância", Unidade = "", ValorPadrao = 0.99, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "R_original", Nome = "R original", Descricao = "Confiab. original", Unidade = "", ValorPadrao = 0.9, ValorMin = 0.01, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R_redundant = inputs["R_redundant"];
                double R_original = inputs["R_original"];
                
                return R_redundant / R_original;
            }
        };
    }

    public static Formula V8_REL269_MTTR()
    {
        return new Formula
        {
            Id = "V8-REL269",
            CodigoCompendio = "269",
            Nome = "Mean Time To Repair — MTTR",
            Categoria = "Confiabilidade",
            SubCategoria = "Métricas de Manutenção",
            Expressao = "MTTR = Total Repair Time / Number of Repairs",
            ExprTexto = "MTTR",
            Descricao = "Tempo médio reparo. MTTR baixo: boa manutenibilidade. Inclui diagnóstico, reparo, teste.",
            Criador = "Engenharia de manutenção",
            AnoOrigin = "~1960s",
            ExemploPratico = "200h reparo total, 20 reparos → MTTR=10h. Objetivo: MTTR<<MTBF para alta disponibilidade",
            Unidades = "h",
            VariavelResultado = "MTTR",
            UnidadeResultado = "h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "total_repair_time", Nome = "Tempo total reparo", Descricao = "Total repair time", Unidade = "h", ValorPadrao = 200, ValorMin = 0.01, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "n_repairs", Nome = "Número reparos", Descricao = "Number of repairs", Unidade = "", ValorPadrao = 20, ValorMin = 1, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double total_repair_time = inputs["total_repair_time"];
                double n_repairs = inputs["n_repairs"];
                
                return total_repair_time / n_repairs;
            }
        };
    }

    public static Formula V8_REL270_MDT()
    {
        return new Formula
        {
            Id = "V8-REL270",
            CodigoCompendio = "270",
            Nome = "Mean Down Time — MDT",
            Categoria = "Confiabilidade",
            SubCategoria = "Métricas de Manutenção",
            Expressao = "MDT = MTTR + MLDT",
            ExprTexto = "MDT",
            Descricao = "MLDT=mean logistic delay time (espera peças, equipe). MDT>MTTR. Indisponibilidade total.",
            Criador = "Engenharia de manutenibilidade",
            AnoOrigin = "~1970s",
            ExemploPratico = "MTTR=5h (reparo efetivo), MLDT=3h (logística) → MDT=8h (tempo total parada)",
            Unidades = "h",
            VariavelResultado = "MDT",
            UnidadeResultado = "h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "MTTR", Nome = "MTTR", Descricao = "Mean time to repair", Unidade = "h", ValorPadrao = 5, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "MLDT", Nome = "MLDT", Descricao = "Mean logistic delay", Unidade = "h", ValorPadrao = 3, ValorMin = 0, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double MTTR = inputs["MTTR"];
                double MLDT = inputs["MLDT"];
                
                return MTTR + MLDT;
            }
        };
    }

    public static Formula V8_REL271_Manutenibilidade()
    {
        return new Formula
        {
            Id = "V8-REL271",
            CodigoCompendio = "271",
            Nome = "Manutenibilidade — M(t)",
            Categoria = "Confiabilidade",
            SubCategoria = "Manutenibilidade",
            Expressao = "M(t) = 1 - exp(-μ * t)",
            ExprTexto = "Maintainability (exponencial)",
            Descricao = "μ=taxa reparo (1/MTTR). M(t)=probabilidade reparo completado até t. M(MTTR)≈0,632.",
            Criador = "Engenharia de manutenibilidade",
            AnoOrigin = "~1960s",
            ExemploPratico = "MTTR=10h → μ=0,1/h. M(10h)≈0,632 (63,2%). M(30h)≈0,95 (95% reparado)",
            Unidades = "adimensional",
            VariavelResultado = "M_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "mu", Nome = "μ", Descricao = "Taxa reparo", Unidade = "1/h", ValorPadrao = 0.1, ValorMin = 1e-6, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", Unidade = "h", ValorPadrao = 10, ValorMin = 0, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double mu = inputs["mu"];
                double t = inputs["t"];
                
                return 1 - Math.Exp(-mu * t);
            }
        };
    }

    public static Formula V8_REL272_FIT()
    {
        return new Formula
        {
            Id = "V8-REL272",
            CodigoCompendio = "272",
            Nome = "Failures In Time — FIT",
            Categoria = "Confiabilidade",
            SubCategoria = "Métricas de Confiabilidade",
            Expressao = "FIT = λ * 10^9",
            ExprTexto = "FIT rate",
            Descricao = "λ=taxa falha (1/h). FIT=falhas/10^9h. Eletrônica: típico 10-1000 FIT. FIT=1: MTBF≈114000 anos.",
            Criador = "Indústria semicondutores",
            AnoOrigin = "~1970s",
            ExemploPratico = "λ=10^-7/h → FIT=100. MTBF=10^7h≈1141anos. Componente: FIT=50 (muito confiável)",
            Unidades = "FIT",
            VariavelResultado = "FIT",
            UnidadeResultado = "FIT",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "λ", Descricao = "Taxa falha", Unidade = "1/h", ValorPadrao = 1e-7, ValorMin = 1e-12, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                
                return lambda * 1e9;
            }
        };
    }

    public static Formula V8_REL273_FMEA_RPN()
    {
        return new Formula
        {
            Id = "V8-REL273",
            CodigoCompendio = "273",
            Nome = "Risk Priority Number — RPN (FMEA)",
            Categoria = "Confiabilidade",
            SubCategoria = "Análise de Falhas",
            Expressao = "RPN = S * O * D",
            ExprTexto = "RPN",
            Descricao = "S=severidade, O=ocorrência, D=detecção (1-10 cada). RPN alto: priorizar ação. FMEA: NASA ~1960s.",
            Criador = "NASA / Indústria automotiva",
            AnoOrigin = "~1960s",
            ExemploPratico = "S=9 (crítico), O=4 (ocasional), D=3 (alta detect.) → RPN=108. RPN>100: ação corretiva",
            Unidades = "adimensional",
            VariavelResultado = "RPN",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "S", Nome = "Severidade", Descricao = "Severity (1-10)", Unidade = "", ValorPadrao = 9, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "O", Nome = "Ocorrência", Descricao = "Occurrence (1-10)", Unidade = "", ValorPadrao = 4, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "D", Nome = "Detecção", Descricao = "Detection (1-10)", Unidade = "", ValorPadrao = 3, ValorMin = 1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double S = inputs["S"];
                double O = inputs["O"];
                double D = inputs["D"];
                
                return S * O * D;
            }
        };
    }

    public static Formula V8_REL274_CustoVidaUtil_LCC()
    {
        return new Formula
        {
            Id = "V8-REL274",
            CodigoCompendio = "274",
            Nome = "Life Cycle Cost — LCC (simplificado)",
            Categoria = "Confiabilidade",
            SubCategoria = "Economia da Manutenção",
            Expressao = "LCC = C_acquisition + C_operation + C_maintenance + C_disposal",
            ExprTexto = "LCC",
            Descricao = "Custo total vida: aquisição, operação, manutenção, descarte. Análise TCO (Total Cost of Ownership).",
            Criador = "Engenharia econômica",
            AnoOrigin = "~1970s",
            ExemploPratico = "Equip.: C_acq=$100k, C_op=$50k/ano×10 anos, C_maint=$200k, C_disp=$10k → LCC=$810k",
            Unidades = "adimensional",
            VariavelResultado = "LCC",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C_acq", Nome = "Aquisição", Descricao = "Custo aquisição", Unidade = "", ValorPadrao = 100000, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "C_op", Nome = "Operação", Descricao = "Custo operação", Unidade = "", ValorPadrao = 500000, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "C_maint", Nome = "Manutenção", Descricao = "Custo manutenção", Unidade = "", ValorPadrao = 200000, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "C_disp", Nome = "Descarte", Descricao = "Custo descarte", Unidade = "", ValorPadrao = 10000, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C_acq = inputs["C_acq"];
                double C_op = inputs["C_op"];
                double C_maint = inputs["C_maint"];
                double C_disp = inputs["C_disp"];
                
                return C_acq + C_op + C_maint + C_disp;
            }
        };
    }
}
