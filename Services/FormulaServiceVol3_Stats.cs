using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 3 — PARTE III: ESTATÍSTICA AVANÇADA E GEOESTATÍSTICA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 12. ANÁLISE DE SOBREVIVÊNCIA
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseSobrevivencia()
    {
        _formulas.AddRange([
            // 12.1 Funções Fundamentais
            new Formula
            {
                Id = "3_sv01", Nome = "Função de Sobrevivência", Categoria = "Análise de Sobrevivência", SubCategoria = "Funções Fundamentais",
                Expressao = "S(t) = P(T > t) = 1 - F(t)",
                ExprTexto = "S(t) = P(T>t) = 1 − F(t)",
                Icone = "S(t)",
                Descricao = "Probabilidade de sobreviver além do tempo t. S(0)=1, S(∞)=0, S é não-crescente. Complementar da CDF da variável de tempo de falha T.",
                Criador = "Estatística atuarial",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "3_sv02", Nome = "Função de Hazard (Taxa Instantânea)", Categoria = "Análise de Sobrevivência", SubCategoria = "Funções Fundamentais",
                Expressao = "h(t) = f(t)/S(t) = -d/dt ln S(t)",
                ExprTexto = "h(t) = f(t)/S(t) = −d ln S(t)/dt",
                Icone = "h(t)",
                Descricao = "Taxa instantânea de falha dado que sobreviveu até t. Não é probabilidade (pode ser >1). Forma de banheira: alta no início, mínima, alta no final.",
                Criador = "Estatística de confiabilidade",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "3_sv03", Nome = "Hazard Cumulativo", Categoria = "Análise de Sobrevivência", SubCategoria = "Funções Fundamentais",
                Expressao = "H(t) = ∫₀^t h(u)du = -ln S(t)",
                ExprTexto = "H(t) = ∫₀ᵗ h(u)du = −ln S(t)",
                Icone = "H(t)",
                Descricao = "Integral do hazard. Relação direta com sobrevivência: S(t) = exp(-H(t)). Estimador de Nelson-Aalen é alternativa não-paramétrica.",
                Criador = "Estatística de sobrevivência",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "3_sv04", Nome = "Modelo Exponencial", Categoria = "Análise de Sobrevivência", SubCategoria = "Funções Fundamentais",
                Expressao = "S(t) = e^(-λt);  h(t) = λ (constante)",
                ExprTexto = "S(t) = e^(−λt);  h(t) = λ",
                Icone = "exp",
                Descricao = "Hazard constante: 'sem memória' (idade não importa). Tempo médio = 1/λ. Modelo mais simples de sobrevivência; subconjunto de Weibull com k=1.",
                Criador = "Modelagem de confiabilidade",
                Variaveis = [
                    new() { Simbolo = "lambda", Nome = "λ (taxa)", ValorPadrao = 0.1, ValorMin = 0.001 },
                    new() { Simbolo = "t", Nome = "t (tempo)", ValorPadrao = 5, ValorMin = 0 },
                ],
                VariavelResultado = "S(t)",
                Calcular = v => Math.Exp(-v["lambda"] * v["t"])
            },
            new Formula
            {
                Id = "3_sv05", Nome = "Modelo de Weibull", Categoria = "Análise de Sobrevivência", SubCategoria = "Funções Fundamentais",
                Expressao = "S(t) = exp(-(t/λ)^k);  h(t) = (k/λ)(t/λ)^(k-1)",
                ExprTexto = "S(t) = e^(−(t/λ)ᵏ);  h(t) = (k/λ)(t/λ)^(k−1)",
                Icone = "W",
                Descricao = "k<1: hazard decrescente (mortalidade infantil); k=1: exponencial; k>1: hazard crescente (desgaste). Muito usado em engenharia e medicina.",
                Criador = "Waloddi Weibull",
                AnoOrigin = "1951",
                Variaveis = [
                    new() { Simbolo = "t", Nome = "t", ValorPadrao = 5, ValorMin = 0 },
                    new() { Simbolo = "lambda", Nome = "λ (escala)", ValorPadrao = 10, ValorMin = 0.01 },
                    new() { Simbolo = "k", Nome = "k (forma)", ValorPadrao = 1.5, ValorMin = 0.01 },
                ],
                VariavelResultado = "S(t)",
                Calcular = v => Math.Exp(-Math.Pow(v["t"] / v["lambda"], v["k"]))
            },
            // 12.2 Kaplan-Meier e Censura
            new Formula
            {
                Id = "3_sv06", Nome = "Estimador de Kaplan-Meier", Categoria = "Análise de Sobrevivência", SubCategoria = "Kaplan-Meier",
                Expressao = "Ŝ(t) = Πᵢ:tᵢ≤t (1 - dᵢ/nᵢ)",
                ExprTexto = "Ŝ(t) = ∏_{tᵢ≤t} (1 − dᵢ/nᵢ)",
                Icone = "KM",
                Descricao = "Estimador não-paramétrico da sobrevivência. dᵢ = óbitos no tempo tᵢ, nᵢ = em risco. Lida com censura à direita. Curva em escada.",
                Criador = "Edward Kaplan / Paul Meier",
                AnoOrigin = "1958",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "3_sv07", Nome = "Erro Padrão de Greenwood", Categoria = "Análise de Sobrevivência", SubCategoria = "Kaplan-Meier",
                Expressao = "Var(Ŝ(t)) ≈ Ŝ(t)² Σᵢ dᵢ/(nᵢ(nᵢ-dᵢ))",
                ExprTexto = "Var(Ŝ) ≈ Ŝ² Σ dᵢ/(nᵢ(nᵢ−dᵢ))",
                Icone = "SE",
                Descricao = "Variância de Greenwood para Kaplan-Meier. Permite construir intervalos de confiança para S(t). Fundamental para determinar incerteza das curvas de sobrevivência.",
                Criador = "Major Greenwood",
                AnoOrigin = "1926",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "3_sv08", Nome = "Teste Log-Rank", Categoria = "Análise de Sobrevivência", SubCategoria = "Kaplan-Meier",
                Expressao = "χ² = (Σ(O₁ᵢ-E₁ᵢ))²/Σ(Var₁ᵢ)  ~χ²(1)",
                ExprTexto = "χ² = (ΣOᵢ−ΣEᵢ)²/ΣVarᵢ ∼ χ²(1)",
                Icone = "χ²",
                Descricao = "Teste padrão para comparar curvas de sobrevivência de dois grupos. H₀: sobrevivência igual. Mais potente quando hazards proporcionais. Ponderação uniforme.",
                Criador = "Nathan Mantel / Richard Peto",
                AnoOrigin = "1966/1972",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "3_sv09", Nome = "Censura à Direita", Categoria = "Análise de Sobrevivência", SubCategoria = "Kaplan-Meier",
                Expressao = "Observar Yᵢ = min(Tᵢ, Cᵢ);  δᵢ = 𝟙(Tᵢ≤Cᵢ)",
                ExprTexto = "Yᵢ = min(Tᵢ,Cᵢ);  δᵢ = 𝟙(Tᵢ≤Cᵢ)",
                Icone = "C",
                Descricao = "O indivíduo é observado até min(evento,censura). Se censurado (δ=0), sabemos apenas T>C. Ignorar censura causa viés. KM a incorpora naturalmente.",
                Criador = "Kaplan & Meier / Estatística de sobrevivência",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            // 12.3 Modelo de Cox
            new Formula
            {
                Id = "3_sv10", Nome = "Modelo de Riscos Proporcionais de Cox", Categoria = "Análise de Sobrevivência", SubCategoria = "Modelo de Cox",
                Expressao = "h(t|X) = h₀(t)·exp(β₁X₁+...+βpXp)",
                ExprTexto = "h(t|X) = h₀(t)·eᵝ'ˣ",
                Icone = "Cox",
                Descricao = "Hazard é h₀(t) vezes fator multiplicativo das covariáveis. Semiparamétrico: h₀ não precisa ser especificado. Mais usado em estudos clínicos.",
                Criador = "David Cox",
                AnoOrigin = "1972",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "3_sv11", Nome = "Verossimilhança Parcial de Cox", Categoria = "Análise de Sobrevivência", SubCategoria = "Modelo de Cox",
                Expressao = "PL(β) = Πᵢ:δᵢ=1 [eᵝ'ˣⁱ / Σⱼ∈R(tᵢ) eᵝ'ˣʲ]",
                ExprTexto = "PL(β) = ∏_{δᵢ=1} eᵝ'ˣⁱ/Σⱼ∈Rᵢ eᵝ'ˣʲ",
                Icone = "PL",
                Descricao = "Elimina h₀(t) desconhecido (cancelamento elegante). Estima β sem precisar modelar o hazard basal. Maximizada por Newton-Raphson.",
                Criador = "David Cox",
                AnoOrigin = "1975",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "3_sv12", Nome = "Hazard Ratio", Categoria = "Análise de Sobrevivência", SubCategoria = "Modelo de Cox",
                Expressao = "HR = h(t|X=1)/h(t|X=0) = eᵝ",
                ExprTexto = "HR = eᵝ",
                Icone = "HR",
                Descricao = "Razão de hazards entre dois grupos. HR=2 → grupo X=1 tem o dobro do risco. Constante no tempo (proporcionalidade). Intervalo de confiança: exp(β±zSE).",
                Criador = "David Cox",
                AnoOrigin = "1972",
                Variaveis = [
                    new() { Simbolo = "beta", Nome = "β (coeficiente)", ValorPadrao = 0.5 },
                ],
                VariavelResultado = "HR",
                Calcular = v => Math.Exp(v["beta"])
            },
            new Formula
            {
                Id = "3_sv13", Nome = "Nelson-Aalen", Categoria = "Análise de Sobrevivência", SubCategoria = "Kaplan-Meier",
                Expressao = "Ĥ(t) = Σᵢ:tᵢ≤t dᵢ/nᵢ",
                ExprTexto = "Ĥ(t) = Σ_{tᵢ≤t} dᵢ/nᵢ",
                Icone = "Ĥ",
                Descricao = "Estimador não-paramétrico do hazard cumulativo. Mais robusto em amostras pequenas que -ln(KM). Incrementos dᵢ/nᵢ nos tempos de evento.",
                Criador = "Wayne Nelson / Odd Aalen",
                AnoOrigin = "1972/1978",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "3_sv14", Nome = "Tempo de Vida Médio Restrito (RMST)", Categoria = "Análise de Sobrevivência", SubCategoria = "Modelo de Cox",
                Expressao = "RMST(τ) = ∫₀^τ S(t)dt",
                ExprTexto = "RMST(τ) = ∫₀^τ S(t)dt",
                Icone = "μτ",
                Descricao = "Área sob a curva de sobrevivência até τ. Alternativa ao HR quando proporcionalidade não se sustenta. Intuitivo: tempo médio de vida até o horizonte τ.",
                Criador = "Biostatística moderna",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 13. VALORES EXTREMOS E CÓPULAS
    // ─────────────────────────────────────────────────────
    private void AdicionarValoresExtremos()
    {
        _formulas.AddRange([
            // 13.1 Teoria de Valores Extremos (EVT)
            new Formula
            {
                Id = "3_ve01", Nome = "Teorema de Fisher-Tippett-Gnedenko", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Valores Extremos",
                Expressao = "Mₙ(normalizado) →ᵈ GEV(μ,σ,ξ)",
                ExprTexto = "max(X₁,...,Xₙ) normalizado → GEV(μ,σ,ξ)",
                Icone = "GEV",
                Descricao = "O máximo de n variáveis i.i.d. (normalizado) converge para uma das 3 distribuições extremas: Gumbel (ξ=0), Fréchet (ξ>0) ou Weibull (ξ<0). Central da EVT.",
                Criador = "Fisher-Tippett / Gnedenko",
                AnoOrigin = "1928/1943",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "GEV", Nome = "GEV", ValorPadrao = 1 }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["GEV"] + vars["mu"]
            },
            new Formula
            {
                Id = "3_ve02", Nome = "CDF da GEV", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Valores Extremos",
                Expressao = "G(x) = exp(-(1+ξ(x-μ)/σ)^(-1/ξ))  ξ≠0",
                ExprTexto = "G(x) = exp(−(1+ξ(x−μ)/σ)^(−1/ξ))",
                Icone = "GEV",
                Descricao = "Distribuição Generalizada de Valores Extremos unificada. ξ=0: Gumbel (caudas leves); ξ>0: Fréchet (caudas pesadas); ξ<0: Weibull reversa (limitada).",
                Criador = "Fisher-Tippett-Gnedenko",
                AnoOrigin = "1928",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            new Formula
            {
                Id = "3_ve03", Nome = "Distribuição de Pareto Generalizada (GPD)", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Valores Extremos",
                Expressao = "H(y) = 1-(1+ξy/σ̃)^(-1/ξ)  (y>0, ξ≠0)",
                ExprTexto = "H(y) = 1−(1+ξy/σ̃)^(−1/ξ)",
                Icone = "GPD",
                Descricao = "Distribuição condicional das excedências sobre um limiar u. Método POT (peaks over threshold). Mais eficiente que block maxima para dados escassos.",
                Criador = "Pickands / Balkema-de Haan",
                AnoOrigin = "1975",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "H", Nome = "H", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["H"] + vars["y"]
            },
            new Formula
            {
                Id = "3_ve04", Nome = "Valor em Risco Extremo (VaR-EVT)", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Valores Extremos",
                Expressao = "VaR_p = u + (σ̃/ξ)((np/Nu)^(-ξ)-1)",
                ExprTexto = "VaRₚ = u + (σ̃/ξ)((np/Nᵤ)^(−ξ)−1)",
                Icone = "$",
                Descricao = "VaR extrapolado via GPD para probabilidades muito pequenas (1 em 1000 anos). Mais confiável que VaR paramétrico normal para caudas pesadas.",
                Criador = "Risco financeiro + EVT",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "u", Nome = "u", ValorPadrao = 1 }, new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["u"] + vars["sigma"]
            },
            new Formula
            {
                Id = "3_ve05", Nome = "Expected Shortfall (CVaR)", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Valores Extremos",
                Expressao = "ES_α = VaR_α + (σ̃+ξ(VaR_α-u))/(1-ξ)",
                ExprTexto = "ESα = VaRα + (σ̃+ξ(VaRα−u))/(1−ξ)",
                Icone = "ES",
                Descricao = "Perda esperada dado que excede VaR. Medida coerente de risco (diferente do VaR). Requerida por Basel III/IV para capital bancário.",
                Criador = "Acerbi & Tasche / Basel III",
                AnoOrigin = "2002",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "ES", Nome = "ES", ValorPadrao = 1 }, new() { Simbolo = "alpha", Nome = "alpha", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["ES"] + vars["alpha"]
            },
            // 13.2 Cópulas
            new Formula
            {
                Id = "3_co01", Nome = "Teorema de Sklar", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Cópulas",
                Expressao = "F(x₁,...,xd) = C(F₁(x₁),...,Fd(xd))",
                ExprTexto = "F(x₁,...,xd) = C(F₁(x₁),...,Fd(xd))",
                Icone = "C",
                Descricao = "Qualquer distribuição conjunta pode ser decomposta em marginais + cópula. A cópula captura a estrutura de dependência pura, separada das distribuições marginais.",
                Criador = "Abe Sklar",
                AnoOrigin = "1959",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "F", Nome = "F", ValorPadrao = 1 }, new() { Simbolo = "xd", Nome = "xd", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["F"] + vars["xd"]
            },
            new Formula
            {
                Id = "3_co02", Nome = "Densidade da Cópula", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Cópulas",
                Expressao = "f(x₁,...,xd) = c(F₁,...,Fd)·∏fᵢ(xᵢ)",
                ExprTexto = "f(x₁,...,xd) = c(u₁,...,ud)·∏fᵢ(xᵢ)",
                Icone = "c",
                Descricao = "A densidade conjunta separa-se em produto das marginais vezes a densidade da cópula c. Facilita modelagem e estimação (IFM: marginais primeiro, depois cópula).",
                Criador = "Teoria de cópulas",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "f", Nome = "f", ValorPadrao = 1 }, new() { Simbolo = "xd", Nome = "xd", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["f"] + vars["xd"]
            },
            new Formula
            {
                Id = "3_co03", Nome = "Cópula Gaussiana", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Cópulas",
                Expressao = "C(u₁,u₂) = Φ₂(Φ⁻¹(u₁),Φ⁻¹(u₂); ρ)",
                ExprTexto = "C(u₁,u₂) = Φ₂(Φ⁻¹(u₁),Φ⁻¹(u₂); ρ)",
                Icone = "Φ",
                Descricao = "Dependência capturada pela correlação ρ da normal bivariada. Sem dependência de cauda. Usada erroneamente em CDOs pre-2008 (subestimava risco extremo).",
                Criador = "David X. Li",
                AnoOrigin = "2000",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "C", Nome = "C", ValorPadrao = 1 }, new() { Simbolo = "rho", Nome = "rho", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["C"] + vars["rho"]
            },
            new Formula
            {
                Id = "3_co04", Nome = "Cópula de Clayton", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Cópulas",
                Expressao = "C(u₁,u₂) = (u₁^(-θ) + u₂^(-θ) - 1)^(-1/θ)",
                ExprTexto = "C(u₁,u₂) = (u₁⁻ᶿ+u₂⁻ᶿ−1)^(−1/θ)",
                Icone = "Clayton",
                Descricao = "Dependência assimétrica: forte na cauda inferior (crashes conjuntos), fraca na superior. θ>0 controla intensidade. Popular em finanças e seguros.",
                Criador = "David Clayton",
                AnoOrigin = "1978",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "C", Nome = "C", ValorPadrao = 1 }, new() { Simbolo = "theta", Nome = "theta", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["C"] + vars["theta"]
            },
            new Formula
            {
                Id = "3_co05", Nome = "Cópula de Gumbel", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Cópulas",
                Expressao = "C(u₁,u₂) = exp(-((- ln u₁)^θ+(-ln u₂)^θ)^(1/θ))",
                ExprTexto = "C(u₁,u₂) = exp(−((−ln u₁)ᶿ+(−ln u₂)ᶿ)^(1/θ))",
                Icone = "Gumbel",
                Descricao = "Dependência forte na cauda superior (booms conjuntos). Oposta à Clayton. Caso particular de cópula extrema. θ≥1; θ=1 independência.",
                Criador = "Emil Gumbel",
                AnoOrigin = "~1960",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            new Formula
            {
                Id = "3_co06", Nome = "Tau de Kendall vs Cópula", Categoria = "Valores Extremos e Cópulas", SubCategoria = "Cópulas",
                Expressao = "τ = 4∫∫C(u₁,u₂)dC - 1",
                ExprTexto = "τ = 4∫∫C(u₁,u₂)dC − 1",
                Icone = "τ",
                Descricao = "Concordância entre pares: τ depende apenas da cópula (não das marginais). Para Clayton: τ=θ/(θ+2); Gumbel: τ=1-1/θ. Alternativa robusta à correlação de Pearson.",
                Criador = "Maurice Kendall / Teoria de cópulas",
                AnoOrigin = "1938",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 14. GEOESTATÍSTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarGeoestatistica()
    {
        _formulas.AddRange([
            // 14.1 Variograma
            new Formula
            {
                Id = "3_ge01", Nome = "Semivariograma Experimental", Categoria = "Geoestatística", SubCategoria = "Variograma",
                Expressao = "γ̂(h) = (1/2N(h)) Σ (Z(sᵢ)-Z(sⱼ))²",
                ExprTexto = "γ̂(h) = (1/(2N(h))) Σ (Z(sᵢ)−Z(sⱼ))²",
                Icone = "γ",
                Descricao = "Metade da variância média das diferenças entre pares de pontos separados por distância h. Quantifica autocorrelação espacial. Base da geoestatística.",
                Criador = "Danie G. Krige / Georges Matheron",
                AnoOrigin = "1951/1963",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "3_ge02", Nome = "Efeito Pepita (Nugget)", Categoria = "Geoestatística", SubCategoria = "Variograma",
                Expressao = "γ(0) = c₀ > 0 (descontinuidade na origem)",
                ExprTexto = "γ(0⁺) = c₀ (nugget)",
                Icone = "c₀",
                Descricao = "Variação a distância zero: erro de medição + microvariabilidade. γ não é zero na origem (descontinuidade). Nugget puro = ausência de correlação espacial.",
                Criador = "Georges Matheron",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "3_ge03", Nome = "Modelo Esférico", Categoria = "Geoestatística", SubCategoria = "Variograma",
                Expressao = "γ(h) = c₀+c[1.5h/a - 0.5(h/a)³] (h≤a); c₀+c (h>a)",
                ExprTexto = "γ(h) = c₀+c[3h/(2a)−h³/(2a³)] para h≤a",
                Icone = "Sph",
                Descricao = "Modelo teórico mais usado: alcance a (além → sem correlação), patamar c₀+c (variância total), nugget c₀. Transição suave com alcance finito.",
                Criador = "Georges Matheron",
                AnoOrigin = "1963",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "3_ge04", Nome = "Modelo Exponencial", Categoria = "Geoestatística", SubCategoria = "Variograma",
                Expressao = "γ(h) = c₀ + c(1 - e^(-h/a))",
                ExprTexto = "γ(h) = c₀ + c(1−e^(−h/a))",
                Icone = "Exp",
                Descricao = "Atinge patamar assintoticamente (alcance efetivo ≈ 3a). Correlação nunca desaparece completamente. Bom para variáveis suaves.",
                Criador = "Teoria de variogramas",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            new Formula
            {
                Id = "3_ge05", Nome = "Modelo Gaussiano", Categoria = "Geoestatística", SubCategoria = "Variograma",
                Expressao = "γ(h) = c₀ + c(1 - e^(-h²/a²))",
                ExprTexto = "γ(h) = c₀ + c(1−e^(−h²/a²))",
                Icone = "Gau",
                Descricao = "Comportamento parabólico na origem (suavíssimo). Para variáveis muito contínuas e diferenciáveis. Pode causar instabilidade numérica em kriging.",
                Criador = "Teoria de variogramas",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            // 14.2 Kriging
            new Formula
            {
                Id = "3_ge06", Nome = "Kriging Ordinário (Preditor)", Categoria = "Geoestatística", SubCategoria = "Kriging",
                Expressao = "Ẑ(s₀) = Σᵢ λᵢ Z(sᵢ);  Σλᵢ = 1",
                ExprTexto = "Ẑ(s₀) = Σᵢ λᵢ Z(sᵢ);  Σλᵢ=1",
                Icone = "KO",
                Descricao = "Melhor preditor linear não-viesado (BLUE). Pesos λᵢ dependem do variograma e das posições. Restrição Σλᵢ=1 garante não-viés sem conhecer a média.",
                Criador = "Georges Matheron (formulação) / D.G. Krige",
                AnoOrigin = "1963/1951",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "3_ge07", Nome = "Sistema de Kriging", Categoria = "Geoestatística", SubCategoria = "Kriging",
                Expressao = "Σⱼ λⱼγ(sᵢ,sⱼ) + μ = γ(sᵢ,s₀)  ∀i;  Σλⱼ=1",
                ExprTexto = "Σⱼ λⱼγᵢⱼ + μ = γᵢ₀;  Σλⱼ=1",
                Icone = "Kλ",
                Descricao = "Sistema linear: variograma entre dados (γᵢⱼ) e entre dados e ponto a estimar (γᵢ₀). μ = multiplicador de Lagrange. Resolve para λ₁,...,λₙ.",
                Criador = "Georges Matheron",
                AnoOrigin = "1963",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "3_ge08", Nome = "Variância de Kriging", Categoria = "Geoestatística", SubCategoria = "Kriging",
                Expressao = "σ²_KO = Σᵢ λᵢγ(sᵢ,s₀) + μ",
                ExprTexto = "σ²_KO = Σᵢ λᵢγᵢ₀ + μ",
                Icone = "σ²",
                Descricao = "Fornece incerteza da estimativa em cada ponto. Depende apenas da geometria dos dados e do variograma, não dos valores observados. Mapas de incerteza.",
                Criador = "Georges Matheron",
                AnoOrigin = "1963",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "3_ge09", Nome = "Kriging Universal", Categoria = "Geoestatística", SubCategoria = "Kriging",
                Expressao = "Z(s) = m(s) + ε(s);  m(s) = Σ fₖ(s)βₖ",
                ExprTexto = "Z(s) = Σβₖfₖ(s) + ε(s)",
                Icone = "KU",
                Descricao = "Generaliza kriging ordinário para média não-constante (trend). m(s) = combinação linear de funções base. Estima trend e resíduo simultaneamente.",
                Criador = "Georges Matheron",
                AnoOrigin = "1969",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "3_ge10", Nome = "Validação Cruzada", Categoria = "Geoestatística", SubCategoria = "Kriging",
                Expressao = "Retirar cada ponto, estimar pelos restantes, avaliar erro",
                ExprTexto = "RMSE_CV = √(Σ(Z(sᵢ)−Ẑ₋ᵢ)²/n)",
                Icone = "CV",
                Descricao = "Remove um ponto de cada vez (leave-one-out) e estima pelo kriging com os restantes. Compara Ẑ com Z real. Avalia qualidade do modelo de variograma.",
                Criador = "Prática geoestatística",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "3_ge11", Nome = "Cokriging", Categoria = "Geoestatística", SubCategoria = "Kriging",
                Expressao = "Ẑ₁(s₀) = Σ λ₁ᵢZ₁(sᵢ) + Σ λ₂ⱼZ₂(sⱼ)",
                ExprTexto = "Ẑ₁(s₀) = Σ λ₁ᵢZ₁(sᵢ) + Σ λ₂ⱼZ₂(sⱼ)",
                Icone = "CoK",
                Descricao = "Usa variável auxiliar correlacionada (ex.: Z₂=altitude) para melhorar a estimativa de Z₁. Necessita variograma cruzado. Mais dados → menor variância.",
                Criador = "Georges Matheron / André Journel",
                AnoOrigin = "~1970",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
        ]);
    }
}
