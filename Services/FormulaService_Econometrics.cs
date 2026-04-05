using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XI: ECONOMETRIA
    // Regressão, séries temporais, testes estatísticos econômicos
    // 20 fórmulas (203-222)
    // ========================================

    public static Formula V8_ECON203_RegressaoOLS_Beta()
    {
        return new Formula
        {
            Id = "V8-ECON203",
            CodigoCompendio = "203",
            Nome = "Coeficiente de Regressão OLS — β",
            Categoria = "Econometria",
            SubCategoria = "Regressão Linear",
            Expressao = "β = Cov(X, Y) / Var(X)",
            ExprTexto = "Beta OLS",
            Descricao = "Y=β₀+β₁X+ε. β₁=Cov(X,Y)/Var(X). Mínimos quadrados ordinários (OLS).",
            Criador = "Legendre e Gauss",
            AnoOrigin = "1805-1809",
            ExemploPratico = "Cov(X,Y)=50, Var(X)=10 → β=5. Y aumenta 5 unidades por X. R²=β²·Var(X)/Var(Y)",
            Unidades = "adimensional",
            VariavelResultado = "beta",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Cov_XY", Nome = "Cov(X,Y)", Descricao = "Covariância", Unidade = "", ValorPadrao = 50, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "Var_X", Nome = "Var(X)", Descricao = "Variância X", Unidade = "", ValorPadrao = 10, ValorMin = 0.01, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Cov_XY = inputs["Cov_XY"];
                double Var_X = inputs["Var_X"];
                
                return Cov_XY / Var_X;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON204_R2_Determinacao()
    {
        return new Formula
        {
            Id = "V8-ECON204",
            CodigoCompendio = "204",
            Nome = "Coeficiente de Determinação — R²",
            Categoria = "Econometria",
            SubCategoria = "Regressão Linear",
            Expressao = "R² = 1 - (RSS / TSS)",
            ExprTexto = "R²",
            Descricao = "RSS=soma resíduos ao quadrado, TSS=soma total quadrados. R²∈[0,1]: 1=perfeito, 0=nenhuma.",
            Criador = "Estatística",
            AnoOrigin = "~1900s",
            ExemploPratico = "RSS=100, TSS=1000 → R²=0,9 (90% variância explicada). R²<0,3: fraco. R²>0,7: forte",
            Unidades = "adimensional",
            VariavelResultado = "R2",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "RSS", Nome = "RSS", Descricao = "Soma resíduos²", Unidade = "", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "TSS", Nome = "TSS", Descricao = "Soma total²", Unidade = "", ValorPadrao = 1000, ValorMin = 0.01, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double RSS = inputs["RSS"];
                double TSS = inputs["TSS"];
                
                return 1 - (RSS / TSS);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON205_R2_Ajustado()
    {
        return new Formula
        {
            Id = "V8-ECON205",
            CodigoCompendio = "205",
            Nome = "R² Ajustado",
            Categoria = "Econometria",
            SubCategoria = "Regressão Linear",
            Expressao = "R²_adj = 1 - ((1 - R²) * (n - 1) / (n - k - 1))",
            ExprTexto = "R² ajustado",
            Descricao = "n=observações, k=preditores. Penaliza por adicionar variáveis irrelevantes.",
            Criador = "Estatística",
            AnoOrigin = "~1950s",
            ExemploPratico = "R²=0,85, n=100, k=2 → R²_adj≈0,847. Mais variáveis: R²↑ sempre, R²_adj pode ↓",
            Unidades = "adimensional",
            VariavelResultado = "R2_adj",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R2", Nome = "R²", Descricao = "R²", Unidade = "", ValorPadrao = 0.85, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "n", Descricao = "Observações", Unidade = "", ValorPadrao = 100, ValorMin = 3, ValorMax = 100000, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "k", Descricao = "Preditores", Unidade = "", ValorPadrao = 2, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R2 = inputs["R2"];
                double n = inputs["n"];
                double k = inputs["k"];
                
                if (n - k - 1 <= 0) return double.NaN;
                
                return 1 - ((1 - R2) * (n - 1) / (n - k - 1));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON206_EstatisticaT()
    {
        return new Formula
        {
            Id = "V8-ECON206",
            CodigoCompendio = "206",
            Nome = "Estatística t — Teste de Hipótese",
            Categoria = "Econometria",
            SubCategoria = "Testes de Hipótese",
            Expressao = "t = (β_hat - β0) / SE(β_hat)",
            ExprTexto = "t-statistic",
            Descricao = "β_hat=estimador, β0=hipótese nula (usualmente 0), SE=erro padrão. |t|>2: significante 5%.",
            Criador = "William Sealy Gosset (Student)",
            AnoOrigin = "1908",
            ExemploPratico = "β_hat=5, SE=2 → t=2,5 (significante). |t|>t_crit(df,α): rejeita H0. df=n-k-1",
            Unidades = "adimensional",
            VariavelResultado = "t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "beta_hat", Nome = "β estimado", Descricao = "β̂", Unidade = "", ValorPadrao = 5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "beta0", Nome = "β0", Descricao = "H0", Unidade = "", ValorPadrao = 0, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "SE", Nome = "Erro padrão", Descricao = "SE", Unidade = "", ValorPadrao = 2, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double beta_hat = inputs["beta_hat"];
                double beta0 = inputs["beta0"];
                double SE = inputs["SE"];
                
                return (beta_hat - beta0) / SE;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON207_EstatisticaF()
    {
        return new Formula
        {
            Id = "V8-ECON207",
            CodigoCompendio = "207",
            Nome = "Estatística F — ANOVA Regressão",
            Categoria = "Econometria",
            SubCategoria = "Testes de Hipótese",
            Expressao = "F = (ESS / k) / (RSS / (n - k - 1))",
            ExprTexto = "F-statistic",
            Descricao = "ESS=soma quadrados explicada, RSS=resíduo, k=preditores, n=obs. Testa significância global.",
            Criador = "Ronald Fisher",
            AnoOrigin = "1918-1924",
            ExemploPratico = "ESS=900, RSS=100, k=2, n=100 → F≈437 (muito significante). F>F_crit: rejeita H0",
            Unidades = "adimensional",
            VariavelResultado = "F",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "ESS", Nome = "ESS", Descricao = "Soma explicada²", Unidade = "", ValorPadrao = 900, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "RSS", Nome = "RSS", Descricao = "Soma resíduos²", Unidade = "", ValorPadrao = 100, ValorMin = 0.01, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "k", Descricao = "Preditores", Unidade = "", ValorPadrao = 2, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "n", Descricao = "Observações", Unidade = "", ValorPadrao = 100, ValorMin = 3, ValorMax = 100000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double ESS = inputs["ESS"];
                double RSS = inputs["RSS"];
                double k = inputs["k"];
                double n = inputs["n"];
                
                if (n - k - 1 <= 0) return double.NaN;
                
                return (ESS / k) / (RSS / (n - k - 1));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON208_DurbinWatson()
    {
        return new Formula
        {
            Id = "V8-ECON208",
            CodigoCompendio = "208",
            Nome = "Estatística Durbin-Watson — Autocorrelação",
            Categoria = "Econometria",
            SubCategoria = "Diagnóstico de Regressão",
            Expressao = "DW = Σ(e_t - e_{t-1})² / Σe_t²",
            ExprTexto = "Durbin-Watson (simplificado)",
            Descricao = "e_t=resíduo tempo t. DW≈2: sem autocorr. DW<2: positiva. DW>2: negativa. DW∈[0,4].",
            Criador = "Durbin e Watson",
            AnoOrigin = "1950-1951",
            ExemploPratico = "DW=0,8: autocorr. positiva. DW=2,1: OK. DW=3,5: negativa. Séries temporais: crucial",
            Unidades = "adimensional",
            VariavelResultado = "DW",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sum_diff_sq", Nome = "Σ(e_t-e_{t-1})²", Descricao = "Soma diffs²", Unidade = "", ValorPadrao = 200, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "sum_e_sq", Nome = "Σe_t²", Descricao = "Soma resíduos²", Unidade = "", ValorPadrao = 100, ValorMin = 0.01, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sum_diff_sq = inputs["sum_diff_sq"];
                double sum_e_sq = inputs["sum_e_sq"];
                
                return sum_diff_sq / sum_e_sq;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON209_VIF()
    {
        return new Formula
        {
            Id = "V8-ECON209",
            CodigoCompendio = "209",
            Nome = "Fator de Inflação da Variância — VIF",
            Categoria = "Econometria",
            SubCategoria = "Diagnóstico de Regressão",
            Expressao = "VIF = 1 / (1 - R²_j)",
            ExprTexto = "VIF",
            Descricao = "R²_j=R² de Xj contra outros preditores. VIF>10: multicolinearidade. VIF>5: preocupante.",
            Criador = "Econometria",
            AnoOrigin = "~1970s",
            ExemploPratico = "R²_j=0,9 → VIF=10 (alta multicolinearidade). VIF=1: não correlacionado. VIF>10: remover variável",
            Unidades = "adimensional",
            VariavelResultado = "VIF",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R2_j", Nome = "R²_j", Descricao = "R² auxiliar", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 0.9999, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R2_j = inputs["R2_j"];
                
                return 1 / (1 - R2_j);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON210_AIC()
    {
        return new Formula
        {
            Id = "V8-ECON210",
            CodigoCompendio = "210",
            Nome = "Critério de Informação de Akaike — AIC",
            Categoria = "Econometria",
            SubCategoria = "Seleção de Modelos",
            Expressao = "AIC = 2k - 2ln(L)",
            ExprTexto = "AIC",
            Descricao = "k=parâmetros, L=verossimilhança. Menor AIC: melhor modelo. Penaliza complexidade.",
            Criador = "Hirotugu Akaike",
            AnoOrigin = "1974",
            ExemploPratico = "Modelo A: AIC=150. Modelo B: AIC=155 → escolher A. ΔAIC>10: forte evidência",
            Unidades = "adimensional",
            VariavelResultado = "AIC",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Parâmetros", Descricao = "k", Unidade = "", ValorPadrao = 3, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "ln_L", Nome = "ln(L)", Descricao = "Log-likelihood", Unidade = "", ValorPadrao = -50, ValorMin = -1e10, ValorMax = 0, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double ln_L = inputs["ln_L"];
                
                return 2 * k - 2 * ln_L;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON211_BIC()
    {
        return new Formula
        {
            Id = "V8-ECON211",
            CodigoCompendio = "211",
            Nome = "Critério Bayesiano de Informação — BIC",
            Categoria = "Econometria",
            SubCategoria = "Seleção de Modelos",
            Expressao = "BIC = k * ln(n) - 2ln(L)",
            ExprTexto = "BIC (Schwarz)",
            Descricao = "k=parâmetros, n=obs, L=verossimilhança. BIC penaliza mais que AIC para n grande.",
            Criador = "Gideon Schwarz",
            AnoOrigin = "1978",
            ExemploPratico = "k=3, n=100, ln(L)=-50 → BIC≈113,8. BIC>AIC para n>8. Menor BIC: melhor",
            Unidades = "adimensional",
            VariavelResultado = "BIC",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Parâmetros", Descricao = "k", Unidade = "", ValorPadrao = 3, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Observações", Descricao = "n", Unidade = "", ValorPadrao = 100, ValorMin = 2, ValorMax = 100000, Obrigatoria = true },
                new() { Simbolo = "ln_L", Nome = "ln(L)", Descricao = "Log-likelihood", Unidade = "", ValorPadrao = -50, ValorMin = -1e10, ValorMax = 0, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double n = inputs["n"];
                double ln_L = inputs["ln_L"];
                
                return k * Math.Log(n) - 2 * ln_L;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON212_ARMA_AR1()
    {
        return new Formula
        {
            Id = "V8-ECON212",
            CodigoCompendio = "212",
            Nome = "Modelo Autoregressivo AR(1)",
            Categoria = "Econometria",
            SubCategoria = "Séries Temporais",
            Expressao = "Y_t = c + φ * Y_{t-1} + ε_t",
            ExprTexto = "AR(1)",
            Descricao = "c=constante, φ=coef. autoregressivo, ε_t=ruído branco. |φ|<1: estacionário.",
            Criador = "Box e Jenkins",
            AnoOrigin = "1970",
            ExemploPratico = "Y_{t-1}=100, c=5, φ=0,8 → Y_t≈85+ε_t. φ=0,9: persistente. φ=0,3: rápida reversão",
            Unidades = "adimensional",
            VariavelResultado = "Y_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "c", Nome = "Constante", Descricao = "c", Unidade = "", ValorPadrao = 5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "phi", Nome = "φ", Descricao = "Coef. AR", Unidade = "", ValorPadrao = 0.8, ValorMin = -0.99, ValorMax = 0.99, Obrigatoria = true },
                new() { Simbolo = "Y_prev", Nome = "Y_{t-1}", Descricao = "Lag 1", Unidade = "", ValorPadrao = 100, ValorMin = -1e10, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "epsilon", Nome = "ε_t", Descricao = "Ruído", Unidade = "", ValorPadrao = 0, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double c = inputs["c"];
                double phi = inputs["phi"];
                double Y_prev = inputs["Y_prev"];
                double epsilon = inputs["epsilon"];
                
                return c + phi * Y_prev + epsilon;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON213_ARMA_MA1()
    {
        return new Formula
        {
            Id = "V8-ECON213",
            CodigoCompendio = "213",
            Nome = "Modelo Média Móvel MA(1)",
            Categoria = "Econometria",
            SubCategoria = "Séries Temporais",
            Expressao = "Y_t = μ + ε_t + θ * ε_{t-1}",
            ExprTexto = "MA(1)",
            Descricao = "μ=média, θ=coef. MA, ε_t=ruído branco. |θ|<1: invertível.",
            Criador = "Box e Jenkins",
            AnoOrigin = "1970",
            ExemploPratico = "μ=50, ε_t=2, ε_{t-1}=-1, θ=0,5 → Y_t=51,5. MA suaviza choques temporários",
            Unidades = "adimensional",
            VariavelResultado = "Y_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "mu", Nome = "μ", Descricao = "Média", Unidade = "", ValorPadrao = 50, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "epsilon_t", Nome = "ε_t", Descricao = "Ruído atual", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "theta", Nome = "θ", Descricao = "Coef. MA", Unidade = "", ValorPadrao = 0.5, ValorMin = -0.99, ValorMax = 0.99, Obrigatoria = true },
                new() { Simbolo = "epsilon_prev", Nome = "ε_{t-1}", Descricao = "Ruído lag 1", Unidade = "", ValorPadrao = -1, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double mu = inputs["mu"];
                double epsilon_t = inputs["epsilon_t"];
                double theta = inputs["theta"];
                double epsilon_prev = inputs["epsilon_prev"];
                
                return mu + epsilon_t + theta * epsilon_prev;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON214_TesteDickeyFuller()
    {
        return new Formula
        {
            Id = "V8-ECON214",
            CodigoCompendio = "214",
            Nome = "Teste Dickey-Fuller Aumentado — ADF (simplificado)",
            Categoria = "Econometria",
            SubCategoria = "Séries Temporais",
            Expressao = "ΔY_t = α + β*t + γ*Y_{t-1} + Σδ_i*ΔY_{t-i} + ε_t",
            ExprTexto = "ADF (estrutura)",
            Descricao = "Testa raiz unitária. H0: γ=0 (não estacionário). |t_γ|>valor crítico: rejeita H0 (estacionário).",
            Criador = "Dickey e Fuller",
            AnoOrigin = "1979",
            ExemploPratico = "γ=-0,2, SE(γ)=0,05 → t=-4 (rejeita H0, estacionário). t>-2: não estacionário (diferençar)",
            Unidades = "adimensional",
            VariavelResultado = "gamma_estimate",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "gamma", Nome = "γ", Descricao = "Coef. lag", Unidade = "", ValorPadrao = -0.2, ValorMin = -1, ValorMax = 0, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                return inputs["gamma"];
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON215_TesteCointegracao_Engle_Granger()
    {
        return new Formula
        {
            Id = "V8-ECON215",
            CodigoCompendio = "215",
            Nome = "Teste de Cointegração — Engle-Granger",
            Categoria = "Econometria",
            SubCategoria = "Séries Temporais",
            Expressao = "Y_t = α + β*X_t + u_t → ADF(u_t)",
            ExprTexto = "Cointegração (estrutura)",
            Descricao = "Se Y_t e X_t são I(1), mas u_t é I(0): cointegrados (relação longo prazo). Nobel 2003.",
            Criador = "Robert Engle e Clive Granger",
            AnoOrigin = "1987",
            ExemploPratico = "Preço ações: X_t, Y_t I(1). Regress: u_t=Y-βX. Se ADF(u_t) estacionário: cointegrados",
            Unidades = "adimensional",
            VariavelResultado = "beta_cointegration",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "beta", Nome = "β", Descricao = "Coef. cointeg.", Unidade = "", ValorPadrao = 0.95, ValorMin = -10, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                return inputs["beta"];
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON216_GARCH_1_1()
    {
        return new Formula
        {
            Id = "V8-ECON216",
            CodigoCompendio = "216",
            Nome = "Modelo GARCH(1,1) — Volatilidade",
            Categoria = "Econometria",
            SubCategoria = "Séries Temporais",
            Expressao = "σ²_t = ω + α*ε²_{t-1} + β*σ²_{t-1}",
            ExprTexto = "GARCH(1,1)",
            Descricao = "ω>0, α≥0, β≥0, α+β<1. σ²_t=variância condicional. Volatilidade clustering (finanças).",
            Criador = "Bollerslev",
            AnoOrigin = "1986",
            ExemploPratico = "ω=0,01, α=0,1, β=0,85, ε²_{t-1}=1, σ²_{t-1}=0,5 → σ²_t≈0,535. Persistência: β+α≈0,95",
            Unidades = "adimensional",
            VariavelResultado = "sigma2_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "omega", Nome = "ω", Descricao = "Constante", Unidade = "", ValorPadrao = 0.01, ValorMin = 0.0001, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "alpha", Nome = "α", Descricao = "Coef. ARCH", Unidade = "", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 0.5, Obrigatoria = true },
                new() { Simbolo = "epsilon_sq_prev", Nome = "ε²_{t-1}", Descricao = "Quadrado resíduo lag", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "beta", Nome = "β", Descricao = "Coef. GARCH", Unidade = "", ValorPadrao = 0.85, ValorMin = 0, ValorMax = 0.99, Obrigatoria = true },
                new() { Simbolo = "sigma2_prev", Nome = "σ²_{t-1}", Descricao = "Variância lag", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double omega = inputs["omega"];
                double alpha = inputs["alpha"];
                double epsilon_sq_prev = inputs["epsilon_sq_prev"];
                double beta = inputs["beta"];
                double sigma2_prev = inputs["sigma2_prev"];
                
                return omega + alpha * epsilon_sq_prev + beta * sigma2_prev;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON217_ElasticidadePreco()
    {
        return new Formula
        {
            Id = "V8-ECON217",
            CodigoCompendio = "217",
            Nome = "Elasticidade-Preço da Demanda — Ed",
            Categoria = "Econometria",
            SubCategoria = "Microeconomia Aplicada",
            Expressao = "Ed = (ΔQ / Q) / (ΔP / P)",
            ExprTexto = "Elasticidade",
            Descricao = "ΔQ/Q=variação %demanda, ΔP/P=variação %preço. |Ed|>1: elástico. |Ed|<1: inelástico.",
            Criador = "Alfred Marshall",
            AnoOrigin = "1890",
            ExemploPratico = "Q=100→90, P=10→11 → Ed≈-1 (unitário). Ed=-0,5: inelástico. Ed=-2: elástico",
            Unidades = "adimensional",
            VariavelResultado = "Ed",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "delta_Q_pct", Nome = "ΔQ/Q", Descricao = "Var. % demanda", Unidade = "", ValorPadrao = -0.1, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "delta_P_pct", Nome = "ΔP/P", Descricao = "Var. % preço", Unidade = "", ValorPadrao = 0.1, ValorMin = -1, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double delta_Q_pct = inputs["delta_Q_pct"];
                double delta_P_pct = inputs["delta_P_pct"];
                
                if (Math.Abs(delta_P_pct) < 1e-10) return double.PositiveInfinity;
                
                return delta_Q_pct / delta_P_pct;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON218_ValorPresente()
    {
        return new Formula
        {
            Id = "V8-ECON218",
            CodigoCompendio = "218",
            Nome = "Valor Presente Líquido — VPL",
            Categoria = "Econometria",
            SubCategoria = "Finanças Quantitativas",
            Expressao = "VPL = Σ(CF_t / (1 + r)^t) - C0",
            ExprTexto = "VPL (caso único período)",
            Descricao = "CF_t=fluxo caixa (t), r=taxa desconto, C0=investimento inicial. VPL>0: aceitar projeto.",
            Criador = "Finanças corporativas",
            AnoOrigin = "~1930s",
            ExemploPratico = "C0=1000, CF_1=300, r=0,1 → VP(CF)≈273 (1 período). VPL=Σ273-1000. >0: lucrativo",
            Unidades = "adimensional",
            VariavelResultado = "VP_single",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "CF", Nome = "Fluxo caixa", Descricao = "CF", Unidade = "", ValorPadrao = 300, ValorMin = -1e10, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Taxa desconto", Descricao = "r", Unidade = "", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Período", Descricao = "t", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double CF = inputs["CF"];
                double r = inputs["r"];
                double t = inputs["t"];
                
                return CF / Math.Pow(1 + r, t);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON219_TaxaRetornoLogaritimica()
    {
        return new Formula
        {
            Id = "V8-ECON219",
            CodigoCompendio = "219",
            Nome = "Taxa de Retorno Logarítmica — r_t",
            Categoria = "Econometria",
            SubCategoria = "Finanças Quantitativas",
            Expressao = "r_t = ln(P_t / P_{t-1})",
            ExprTexto = "Log return",
            Descricao = "P_t=preço tempo t. Log return: aditivo, assimétrico. Retorno simples: (P_t-P_{t-1})/P_{t-1}.",
            Criador = "Finanças quantitativas",
            AnoOrigin = "~1960s",
            ExemploPratico = "P_{t-1}=100, P_t=105 → r_t=ln(1,05)≈0,0488 (4,88%). Retorno simples: 5%",
            Unidades = "adimensional",
            VariavelResultado = "r_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P_t", Nome = "Preço t", Descricao = "P_t", Unidade = "", ValorPadrao = 105, ValorMin = 0.01, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "P_prev", Nome = "Preço t-1", Descricao = "P_{t-1}", Unidade = "", ValorPadrao = 100, ValorMin = 0.01, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P_t = inputs["P_t"];
                double P_prev = inputs["P_prev"];
                
                return Math.Log(P_t / P_prev);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON220_IndiceSharpRatio()
    {
        return new Formula
        {
            Id = "V8-ECON220",
            CodigoCompendio = "220",
            Nome = "Índice de Sharpe",
            Categoria = "Econometria",
            SubCategoria = "Finanças Quantitativas",
            Expressao = "SR = (R_p - R_f) / σ_p",
            ExprTexto = "Sharpe ratio",
            Descricao = "R_p=retorno portfólio, R_f=retorno livre risco, σ_p=desvio padrão. SR>1: bom. SR>2: excelente.",
            Criador = "William F. Sharpe",
            AnoOrigin = "1966",
            ExemploPratico = "R_p=12%, R_f=2%, σ_p=15% → SR≈0,67. SR=1,5: muito bom. SR<0: pior que risco livre",
            Unidades = "adimensional",
            VariavelResultado = "SR",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R_p", Nome = "Retorno portfólio", Descricao = "R_p", Unidade = "%", ValorPadrao = 12, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "R_f", Nome = "Retorno livre risco", Descricao = "R_f", Unidade = "%", ValorPadrao = 2, ValorMin = 0, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "sigma_p", Nome = "Desvio portfólio", Descricao = "σ_p", Unidade = "%", ValorPadrao = 15, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R_p = inputs["R_p"];
                double R_f = inputs["R_f"];
                double sigma_p = inputs["sigma_p"];
                
                return (R_p - R_f) / sigma_p;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON221_CAPM()
    {
        return new Formula
        {
            Id = "V8-ECON221",
            CodigoCompendio = "221",
            Nome = "Capital Asset Pricing Model — CAPM",
            Categoria = "Econometria",
            SubCategoria = "Finanças Quantitativas",
            Expressao = "E(R_i) = R_f + β_i * (E(R_m) - R_f)",
            ExprTexto = "CAPM",
            Descricao = "E(R_i)=retorno esperado ativo i, R_f=taxa livre risco, β_i=beta, E(R_m)-R_f=prêmio risco mercado.",
            Criador = "Sharpe, Lintner, Mossin",
            AnoOrigin = "1964-1966",
            ExemploPratico = "R_f=2%, E(R_m)=10%, β=1,5 → E(R_i)=14%. β>1: mais volátil que mercado. β=1: mercado",
            Unidades = "%",
            VariavelResultado = "E_Ri",
            UnidadeResultado = "%",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R_f", Nome = "Taxa livre risco", Descricao = "R_f", Unidade = "%", ValorPadrao = 2, ValorMin = 0, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "beta_i", Nome = "β_i", Descricao = "Beta ativo", Unidade = "", ValorPadrao = 1.5, ValorMin = -3, ValorMax = 3, Obrigatoria = true },
                new() { Simbolo = "E_Rm", Nome = "E(R_m)", Descricao = "Retorno mercado", Unidade = "%", ValorPadrao = 10, ValorMin = -50, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R_f = inputs["R_f"];
                double beta_i = inputs["beta_i"];
                double E_Rm = inputs["E_Rm"];
                
                return R_f + beta_i * (E_Rm - R_f);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ECON222_ModeloBlackScholes()
    {
        return new Formula
        {
            Id = "V8-ECON222",
            CodigoCompendio = "222",
            Nome = "Modelo Black-Scholes — Valor Call (simplificado)",
            Categoria = "Econometria",
            SubCategoria = "Derivativos Financeiros",
            Expressao = "C = S * N(d1) - K * exp(-r*T) * N(d2)",
            ExprTexto = "Black-Scholes (estrutura)",
            Descricao = "S=preço ação, K=strike, r=taxa, T=tempo, σ=volatilidade. d1/d2 envolvem σ√T. Nobel 1997 (Merton/Scholes).",
            Criador = "Fischer Black, Myron Scholes, Robert Merton",
            AnoOrigin = "1973",
            ExemploPratico = "S=100, K=100, r=0,05, T=1yr, σ=0,2 → C≈10,45 (valor call). Put-Call parity",
            Unidades = "adimensional",
            VariavelResultado = "C_approx",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "S", Nome = "Preço ação", Descricao = "S", Unidade = "", ValorPadrao = 100, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "K", Nome = "Strike", Descricao = "K", Unidade = "", ValorPadrao = 100, ValorMin = 0.01, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Taxa livre risco", Descricao = "r", Unidade = "", ValorPadrao = 0.05, ValorMin = 0, ValorMax = 0.5, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Tempo", Descricao = "T em anos", Unidade = "anos", ValorPadrao = 1, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double S = inputs["S"];
                double K = inputs["K"];
                double r = inputs["r"];
                double T = inputs["T"];
                
                // Aproximação: valor intrínseco descontado (simplificado)
                double intrinsic = Math.Max(0, S - K * Math.Exp(-r * T));
                
                return intrinsic; // Nota: implementação completa requer d1, d2, N(.) normal CDF
            },
            Icone = "∑",
        };
    }
}
