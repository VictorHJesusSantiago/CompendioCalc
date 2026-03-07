using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 5 — PARTE V: ECONOMIA (Seções 16-17)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 16. MACROECONOMIA DSGE
    // ─────────────────────────────────────────────────────
    private void AdicionarMacroeconomiaDSGE()
    {
        _formulas.AddRange([
            // 16.1 Modelos DSGE
            new Formula
            {
                Id = "5_ds01", Nome = "Equação de Euler do Consumo", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "u'(Ct) = β·E[u'(Ct+1)·(1+rt+1)]",
                ExprTexto = "u'(C) = β·E[u'(C')·(1+r')]",
                Icone = "Eu",
                Descricao = "Equação de Euler: condição de otimalidade intertemporal do consumidor. β=fator de desconto, u=utilidade, r=taxa de juros. Núcleo de modelos DSGE.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "u", Nome = "u", ValorPadrao = 1 }, new() { Simbolo = "C", Nome = "C", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["u"] + vars["C"]
            },
            new Formula
            {
                Id = "5_ds02", Nome = "Curva de Phillips Nova-Keynesiana", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "πt = β·Et[πt+1] + κ·xt",
                ExprTexto = "π = βE[π'] + κx",
                Icone = "NK",
                Descricao = "NKPC: inflação depende de expectativa futura e gap do produto. Derivada de firmas com preços rígidos (Calvo). κ = slope. Base da política monetária moderna.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "pi", Nome = "pi", ValorPadrao = 1 }, new() { Simbolo = "beta", Nome = "beta", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["pi"] + vars["beta"]
            },
            new Formula
            {
                Id = "5_ds03", Nome = "Regra de Taylor", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "it = r* + πt + 0.5(πt - π*) + 0.5(yt - y*)",
                ExprTexto = "i = r* + π + 0.5(π-π*) + 0.5(y-y*)",
                Icone = "TR",
                Descricao = "Regra de Taylor: taxa de juros responde à inflação e gap do produto. Benchmark de política monetária. Versões com suavização e expectativas.",
                Criador = "John Taylor",
                AnoOrigin = "1993",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "i", Nome = "i", ValorPadrao = 1 }, new() { Simbolo = "r", Nome = "r", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["i"] + vars["r"]
            },
            new Formula
            {
                Id = "5_ds04", Nome = "Modelo RBC (Real Business Cycle)", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "Y = A·Kᵅ·L¹⁻ᵅ;  choques de produtividade A",
                ExprTexto = "Y=A·Kᵅ·L¹⁻ᵅ; A estocástico",
                Icone = "RBC",
                Descricao = "Modelo RBC: flutuações econômicas causadas por choques reais de produtividade. Agente representativo otimiza. Base dos modelos DSGE.",
                Criador = "Kydland / Prescott",
                AnoOrigin = "1982",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "A", Nome = "A", ValorPadrao = 2 }, new() { Simbolo = "Kᵅ", Nome = "Kᵅ", ValorPadrao = 3 }, new() { Simbolo = "L¹", Nome = "L¹", ValorPadrao = 4 } ],
                VariavelResultado = "Y",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * vars["Kᵅ"] * vars["L¹"]
            },
            new Formula
            {
                Id = "5_ds05", Nome = "Preço de Calvo", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "Prob(ajustar preço) = 1-θ cada período;  duração média 1/(1-θ)",
                ExprTexto = "P(ajuste)=1-θ; duração=1/(1-θ)",
                Icone = "Cv",
                Descricao = "Rigidez de preços de Calvo: cada firma ajusta preço com prob 1-θ por período. Gera NKPC e dinâmica de inflação. Microfundamento padrão.",
                Criador = "Guillermo Calvo",
                AnoOrigin = "1983",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "P", Nome = "P", ValorPadrao = 1 }, new() { Simbolo = "theta", Nome = "theta", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["P"] + vars["theta"]
            },
            new Formula
            {
                Id = "5_ds06", Nome = "Equação IS (NK)", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "xt = Et[xt+1] - σ(it - Et[πt+1] - rⁿ)",
                ExprTexto = "x = E[x'] - σ(i-E[π']-rⁿ)",
                Icone = "IS",
                Descricao = "Curva IS dinâmica: gap do produto depende de expectativa futura e taxa de juros real (juros nominal less inflação esperada). σ=elasticidade intertemporal.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "x", ValorPadrao = 1 }, new() { Simbolo = "E", Nome = "E", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] + vars["E"]
            },
            new Formula
            {
                Id = "5_ds07", Nome = "Equação de Bellman", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "V(s) = max_a {u(s,a) + β·E[V(s')]}",
                ExprTexto = "V(s) = max{u(s,a)+βE[V(s')]}",
                Icone = "Bm",
                Descricao = "Equação de Bellman: princípio de otimalidade dinâmica. Valor de estado = utilidade imediata + valor descontado futuro. Resolvida por iteração ou perturbação.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "V", Nome = "V", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["V"] + vars["s"]
            },
            new Formula
            {
                Id = "5_ds08", Nome = "Log-linearização", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "x̂t = (xt - x̄)/x̄ ≈ ln(xt/x̄);  Taylor 1ª ordem em torno do steady state",
                ExprTexto = "x̂ = ln(x/x̄); aproxi. 1ª ordem",
                Icone = "LL",
                Descricao = "Log-linearização: aproximação de 1ª ordem em torno do estado estacionário. Transforma sistema não-linear em linear. Método Blanchard-Kahn para resolver.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "5_ds09", Nome = "Restrição Orçamentária do Governo", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "Bt+1/(1+it) = Bt + Gt - Tt + Transferências",
                ExprTexto = "B'/(1+i) = B + G - T + Tr",
                Icone = "Gov",
                Descricao = "Restrição fiscal: dívida pública evolui com déficit primário e juros. Condição de transversalidade: dívida não explode. Equivalência ricardiana.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "B", Nome = "B", ValorPadrao = 1 }, new() { Simbolo = "i", Nome = "i", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["B"] + vars["i"]
            },

            // 16.2 Economia Monetária
            new Formula
            {
                Id = "5_ds10", Nome = "Equação de Fisher", Categoria = "Macroeconomia DSGE", SubCategoria = "Economia Monetária",
                Expressao = "1+i = (1+r)(1+πe) ≈ i = r + πe",
                ExprTexto = "i ≈ r + πe (Fisher)",
                Icone = "Fi",
                Descricao = "Equação de Fisher: taxa nominal = taxa real + inflação esperada. Relação fundamental entre juros nominais e reais. Decomposição de tasas.",
                Criador = "Irving Fisher",
                AnoOrigin = "1930",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "i", Nome = "i", ValorPadrao = 1 }, new() { Simbolo = "r", Nome = "r", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["i"] + vars["r"]
            },
            new Formula
            {
                Id = "5_ds11", Nome = "Teoria Quantitativa da Moeda", Categoria = "Macroeconomia DSGE", SubCategoria = "Economia Monetária",
                Expressao = "M·V = P·Y",
                ExprTexto = "MV = PY (TQM)",
                Icone = "MV",
                Descricao = "TQM: oferta monetária × velocidade = nível de preços × produto real. Com V constante, M determina P. Base do monetarismo.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "MV", Nome = "MV", ValorPadrao = 1 }, new() { Simbolo = "PY", Nome = "PY", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["MV"] + vars["PY"]
            },
            new Formula
            {
                Id = "5_ds12", Nome = "Modelo de Solow (Crescimento)", Categoria = "Macroeconomia DSGE", SubCategoria = "Economia Monetária",
                Expressao = "k̇ = s·f(k) - (n+δ)·k;  steady state: s·f(k*) = (n+δ)k*",
                ExprTexto = "k̇ = sf(k)-(n+δ)k",
                Icone = "Sw",
                Descricao = "Modelo de Solow: acumulação de capital per capita. Estado estacionário quando investimento = depreciação + crescimento populacional. Resíduo de Solow = tecnologia.",
                Criador = "Robert Solow",
                AnoOrigin = "1956",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "k", Nome = "k", ValorPadrao = 1 }, new() { Simbolo = "sf", Nome = "sf", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["k"] + vars["sf"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 17. ECONOFÍSICA
    // ─────────────────────────────────────────────────────
    private void AdicionarEconofisica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_ef01", Nome = "Modelo de Ising (Mercados)", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "σi = ±1;  H = -J·Σ σi·σj - h·Σ σi",
                ExprTexto = "H = -J·Σσiσj - h·Σσi (Ising-mercado)",
                Icone = "Is",
                Descricao = "Modelo de Ising aplicado a mercados: agentes compram (+1) ou vendem (-1). Interação J modela herding. Transição de fase = crash/bolha.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "H", Nome = "H", ValorPadrao = 1 }, new() { Simbolo = "J", Nome = "J", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["H"] + vars["J"]
            },
            new Formula
            {
                Id = "5_ef02", Nome = "Lei de Potência (Retornos)", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "P(|r| > x) ∼ x⁻ᵅ;  α ≈ 3 (retornos)",
                ExprTexto = "P(|r|>x) ~ x⁻³ (cauda pesada)",
                Icone = "α",
                Descricao = "Caudas pesadas de retornos financeiros: distribuição segue lei de potência com expoente ~3 (lei cúbica inversa). Estilizado e universal.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "P", Nome = "P", ValorPadrao = 1 }, new() { Simbolo = "r", Nome = "r", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["P"] + vars["r"]
            },
            new Formula
            {
                Id = "5_ef03", Nome = "Volatility Clustering", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "Corr(|rt|, |rt+τ|) ∼ τ⁻ᵝ;  β ≈ 0.3",
                ExprTexto = "Autocorr(|r|) ~ τ^(-0.3)",
                Icone = "VC",
                Descricao = "Clustering de volatilidade: autocorrelação de retornos absolutos decai como lei de potência. Memória longa. Motivação para GARCH e modelos de vol estocástica.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "r", Nome = "r", ValorPadrao = 1 }, new() { Simbolo = "tau", Nome = "tau", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["r"] + vars["tau"]
            },
            new Formula
            {
                Id = "5_ef04", Nome = "Modelo de Minority Game", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "N agentes, 2 lados;  lado minoritário vence",
                ExprTexto = "N agentes, 2 lados; minoria vence",
                Icone = "MG",
                Descricao = "Minority Game: modelo de coordenação. Agentes usam estratégias binárias; minoria é recompensada. Transição de fase em α=P/N. Emergência de auto-organização.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"]
            },
            new Formula
            {
                Id = "5_ef05", Nome = "Random Matrix Theory (Finanças)", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "Marchenko-Pastur: ρ(λ) = (T/N)√[(λ₊-λ)(λ-λ₋)]/(2πλ)",
                ExprTexto = "MP: ρ(λ) ∝ √[(λ₊-λ)(λ-λ₋)]/λ",
                Icone = "RMT",
                Descricao = "RMT aplicada a correlações financeiras: autovalores da matriz de correlação seguem Marchenko-Pastur para ruído. Autovalores fora = sinal real.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "5_ef06", Nome = "Modelo de Percolação (Default)", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "pc = limiar de percolação;  p > pc → cluster gigante (contágio)",
                ExprTexto = "p > pc → contágio sistêmico",
                Icone = "Perc",
                Descricao = "Percolação em redes financeiras: se conectividade > limiar pc, default pode propagar por cluster gigante. Modela risco sistêmico e contágio.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 1 }, new() { Simbolo = "pc", Nome = "pc", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["p"] + vars["pc"]
            },
            new Formula
            {
                Id = "5_ef07", Nome = "Hurst Exponent", Categoria = "Econofísica", SubCategoria = "Séries Financeiras",
                Expressao = "R/S(n) ∼ nᴴ;  H>0.5 persistente, H<0.5 anti",
                ExprTexto = "R/S(n) ~ nᴴ (Hurst)",
                Icone = "H",
                Descricao = "Expoente de Hurst: mede memória longa em séries temporais financeiras. H=0.5 random walk, H>0.5 tendência, H<0.5 reversão à média. Análise R/S.",
                Criador = "Harold Hurst",
                AnoOrigin = "1951",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "R", Nome = "R", ValorPadrao = 1 }, new() { Simbolo = "S", Nome = "S", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] + vars["S"]
            },
            new Formula
            {
                Id = "5_ef08", Nome = "Multifractal (MMAR)", Categoria = "Econofísica", SubCategoria = "Séries Financeiras",
                Expressao = "X(t) = BH(θ(t));  θ = trading time multifractal",
                ExprTexto = "X(t) = BH(θ(t)); θ multifractal",
                Icone = "MF",
                Descricao = "MMAR (Multifractal Model of Asset Returns): combina movimento browniano fracionário com tempo de trading multifractal. Captura clustering e caudas pesadas simultaneamente.",
                Criador = "Benoît Mandelbrot",
                AnoOrigin = "1997",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "X", Nome = "X", ValorPadrao = 1 }, new() { Simbolo = "t", Nome = "t", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["X"] + vars["t"]
            },
            new Formula
            {
                Id = "5_ef09", Nome = "Zipf (Tamanho de Firmas)", Categoria = "Econofísica", SubCategoria = "Séries Financeiras",
                Expressao = "P(S > s) ∼ s⁻ζ;  ζ ≈ 1 (Zipf para firmas)",
                ExprTexto = "P(S>s) ~ s⁻¹ (Zipf-firmas)",
                Icone = "Zf",
                Descricao = "Lei de Zipf para tamanho de firmas: distribuição de tamanho segue lei de potência com expoente ~1. Também vale para cidades. Crescimento proporcional (Gibrat).",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "P", Nome = "P", ValorPadrao = 1 }, new() { Simbolo = "S", Nome = "S", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["P"] + vars["S"]
            },
            new Formula
            {
                Id = "5_ef10", Nome = "Pareto (Renda)", Categoria = "Econofísica", SubCategoria = "Séries Financeiras",
                Expressao = "P(X > x) = (xm/x)ᵅ para x ≥ xm",
                ExprTexto = "P(X>x) = (xm/x)ᵅ",
                Icone = "Pa",
                Descricao = "Distribuição de Pareto: modela cauda superior da distribuição de renda/riqueza. α (índice de Pareto) mede desigualdade. Menor α = mais desigual.",
                Criador = "Vilfredo Pareto",
                AnoOrigin = "1897",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "P", Nome = "P", ValorPadrao = 1 }, new() { Simbolo = "X", Nome = "X", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["P"] + vars["X"]
            },
            new Formula
            {
                Id = "5_ef11", Nome = "Modelo de Boltzmann-Gibbs (Economia)", Categoria = "Econofísica", SubCategoria = "Séries Financeiras",
                Expressao = "P(m) = (1/T)·exp(-m/T);  T = renda média",
                ExprTexto = "P(m) = e^(-m/T)/T (Boltzmann-renda)",
                Icone = "BG",
                Descricao = "Distribuição de Boltzmann-Gibbs para renda: maioria da população segue exponencial. Cauda superior segue Pareto. Resultado de trocas conservativas aleatórias.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 16.2 DSGE Avançado (Fricções Financeiras e Open Economy)
    // ─────────────────────────────────────────────────────
    private void AdicionarDSGEAvancado()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_ds13", Nome = "Acelerador Financeiro (BGG)", Categoria = "Macroeconomia DSGE", SubCategoria = "Fricções Financeiras",
                Expressao = "Rt+1 = R·s(n̄t);  s(·) = external finance premium",
                ExprTexto = "R(t+1) = R·s(n̄) (BGG)",
                Icone = "BGG",
                Descricao = "Modelo Bernanke-Gertler-Gilchrist: taxa de empréstimo depende do patrimônio líquido da firma (n̄). Financial accelerator amplifica choques via canal de crédito.",
                Criador = "Bernanke/Gertler/Gilchrist",
                AnoOrigin = "1999",
                ExemploPratico = "Com patrimônio líquido n̄=100 e taxa base R=1.05, calcule o prêmio de risco.",
                Variaveis = [ new() { Simbolo = "R", Nome = "Taxa base R", ValorPadrao = 1.05, ValorMin = 1 }, new() { Simbolo = "n", Nome = "Patrimônio n̄", ValorPadrao = 100, ValorMin = 0.01 } ],
                VariavelResultado = "Taxa efetiva",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] * (1 + 0.1 / Math.Sqrt(vars["n"]))
            },
            new Formula
            {
                Id = "5_ds14", Nome = "Mundell-Fleming DSGE", Categoria = "Macroeconomia DSGE", SubCategoria = "Open Economy",
                Expressao = "UIP: it = i*t + Et[Δst+1];  paridade descoberta de juros",
                ExprTexto = "i = i* + E[Δs] (UIP)",
                Icone = "MF",
                Descricao = "Paridade descoberta de juros: taxa doméstica = taxa externa + depreciação esperada da moeda. Núcleo de modelos DSGE de economia aberta (Galí-Monacelli).",
                Criador = "Mundell/Fleming",
                AnoOrigin = "1962",
                ExemploPratico = "Com taxa externa i*=2%, depreciação esperada Δs=1%, calcule taxa doméstica.",
                Variaveis = [ new() { Simbolo = "i*", Nome = "Taxa externa i*", ValorPadrao = 0.02 }, new() { Simbolo = "Δs", Nome = "Depreciação Δs", ValorPadrao = 0.01 } ],
                VariavelResultado = "Taxa doméstica i",
                UnidadeResultado = "",
                Calcular = vars => vars["i*"] + vars["Δs"]
            },
            new Formula
            {
                Id = "5_ds15", Nome = "Curva de Phillips Híbrida", Categoria = "Macroeconomia DSGE", SubCategoria = "Indexação",
                Expressao = "πt = γ·πt-1 + (1-γ)·β·Et[πt+1] + κ·xt",
                ExprTexto = "π = γπ₋₁ + (1-γ)βE[π'] + κx",
                Icone = "Hyb",
                Descricao = "NKPC híbrida com indexação: γ capta backward-looking (indexação), 1-γ forward-looking. Melhora fit empírico, captura inércia inflacionária.",
                ExemploPratico = "Com indexação γ=0.5, inflação passada π₋₁=0.02, expectativa E[π']=0.025, gap x=0.01, κ=0.3, calcule inflação atual.",
                Variaveis = [ new() { Simbolo = "γ", Nome = "Indexação γ", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "π₋₁", Nome = "Inflação passada π₋₁", ValorPadrao = 0.02 }, new() { Simbolo = "E[π']", Nome = "Expectativa E[π']", ValorPadrao = 0.025 }, new() { Simbolo = "x", Nome = "Gap produto x", ValorPadrao = 0.01 }, new() { Simbolo = "κ", Nome = "Slope κ", ValorPadrao = 0.3 } ],
                VariavelResultado = "Inflação π",
                UnidadeResultado = "",
                Calcular = vars => vars["γ"] * vars["π₋₁"] + (1 - vars["γ"]) * 0.99 * vars["E[π']"] + vars["κ"] * vars["x"]
            },
            new Formula
            {
                Id = "5_ds16", Nome = "Loss Function (Política Monetária)", Categoria = "Macroeconomia DSGE", SubCategoria = "Política Ótima",
                Expressao = "L = Σ βᵗ[(πt - π*)² + λ·(yt - y*)²];  λ=peso output",
                ExprTexto = "L = (π-π*)² + λ(y-y*)²",
                Icone = "Loss",
                Descricao = "Função de perda quadrática do banco central: penaliza desvios de inflação e produto. λ=peso relativo (trade-off). Base de política ótima (Clarida-Galí-Gertler).",
                Criador = "Clarida/Galí/Gertler",
                AnoOrigin = "1999",
                ExemploPratico = "Com desvio de inflação (π-π*)²=0.04, desvio de produto (y-y*)²=0.01, peso λ=0.5, calcule perda.",
                Variaveis = [ new() { Simbolo = "Δπ²", Nome = "Desvio inflação²", ValorPadrao = 0.04, ValorMin = 0 }, new() { Simbolo = "Δy²", Nome = "Desvio produto²", ValorPadrao = 0.01, ValorMin = 0 }, new() { Simbolo = "λ", Nome = "Peso output λ", ValorPadrao = 0.5, ValorMin = 0 } ],
                VariavelResultado = "Perda L",
                UnidadeResultado = "",
                Calcular = vars => vars["Δπ²"] + vars["λ"] * vars["Δy²"]
            },
            new Formula
            {
                Id = "5_ds17", Nome = "DSGE-VAR (Estimação Bayesiana)", Categoria = "Macroeconomia DSGE", SubCategoria = "Econometria",
                Expressao = "p(θ|Y) ∝ p(Y|θ)·p(θ);  combina VAR com priors DSGE",
                ExprTexto = "p(θ|Y) ∝ L(Y|θ)·prior DSGE",
                Icone = "DVAR",
                Descricao = "DSGE-VAR: estimação Bayesiana que usa modelo DSGE como prior para VAR irrestrito. Del Negro-Schorfheide. Balanceia estrutura teórica e fit empírico.",
                Criador = "Del Negro/Schorfheide",
                AnoOrigin = "2004",
                ExemploPratico = "Implementação conceitual de posterior Bayesiana: prior × likelihood.",
                Variaveis = [ new() { Simbolo = "L", Nome = "Likelihood L", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "p", Nome = "Prior p", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Posterior (não normalizado)",
                UnidadeResultado = "",
                Calcular = vars => vars["L"] * vars["p"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 16.3 MICROECONOMIA AVANÇADA
    // ─────────────────────────────────────────────────────
    private void AdicionarMicroeconomiaAvancada()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_me01", Nome = "Equilíbrio de Nash", Categoria = "Microeconomia Avançada", SubCategoria = "Teoria dos Jogos",
                Expressao = "a*i ∈ argmax ui(ai, a*-i) para todo jogador i",
                ExprTexto = "Nash: nenhum jogador desvia unilateralmente",
                Icone = "Nash",
                Descricao = "Equilíbrio de Nash: perfil de estratégias onde nenhum jogador tem incentivo para desviar unilateralmente. Conceito central de teoria dos jogos não-cooperativos.",
                Criador = "John Nash",
                AnoOrigin = "1950",
                ExemploPratico = "Exemplo conceitual: em dilema dos prisioneiros, (Confess, Confess) é Nash.",
                Variaveis = [ new() { Simbolo = "u1", Nome = "Payoff jogador 1", ValorPadrao = 5 }, new() { Simbolo = "u2", Nome = "Payoff jogador 2", ValorPadrao = 5 } ],
                VariavelResultado = "Payoff total",
                UnidadeResultado = "",
                Calcular = vars => vars["u1"] + vars["u2"]
            },
            new Formula
            {
                Id = "5_me02", Nome = "Backward Induction (Jogos Sequenciais)", Categoria = "Microeconomia Avançada", SubCategoria = "Teoria dos Jogos",
                Expressao = "Subgame Perfect Nash: resolve backward dos nós terminais",
                ExprTexto = "SPNE: indução backward em árvore de jogo",
                Icone = "BI",
                Descricao = "Indução backward: resolver jogos sequenciais de trás para frente. Elimina ameaças não-críveis. Gera equilíbrio perfeito em subjogos (SPNE).",
                Criador = "Reinhard Selten",
                AnoOrigin = "1965",
                ExemploPratico = "Exemplo: em jogo de entrada, incumbente não ataca se entrada já ocorreu (ameaça não crível).",
                Variaveis = [ new() { Simbolo = "V", Nome = "Valor nó terminal", ValorPadrao = 10 }, new() { Simbolo = "c", Nome = "Custo ação", ValorPadrao = 2 } ],
                VariavelResultado = "Valor líquido",
                UnidadeResultado = "",
                Calcular = vars => vars["V"] - vars["c"]
            },
            new Formula
            {
                Id = "5_me03", Nome = "Revelation Principle", Categoria = "Microeconomia Avançada", SubCategoria = "Design de Mecanismos",
                Expressao = "Todo mecanismo pode ser implementado via mecanismo direto truth-telling",
                ExprTexto = "Revelation: WLOG assume truth-telling",
                Icone = "Rev",
                Descricao = "Princípio da revelação: qualquer equilíbrio Bayesiano pode ser replicado por mecanismo direto onde agentes revelam verdadeiros tipos. Simplifica design de mecanismos.",
                Criador = "Roger Myerson",
                AnoOrigin = "1979",
                ExemploPratico = "Exemplo conceitual: leiloeiro pode assumir lances são valores verdadeiros (incentive-compatible).",
                Variaveis = [ new() { Simbolo = "v", Nome = "Valor verdadeiro v", ValorPadrao = 100 }, new() { Simbolo = "b", Nome = "Lance revelado b", ValorPadrao = 100 } ],
                VariavelResultado = "Ganho de verdade",
                UnidadeResultado = "",
                Calcular = vars => vars["v"] - Math.Abs(vars["v"] - vars["b"])
            },
            new Formula
            {
                Id = "5_me04", Nome = "Leilão de Vickrey (2º Preço)", Categoria = "Microeconomia Avançada", SubCategoria = "Leilões",
                Expressao = "Vencedor paga 2º maior lance;  estratégia dominante: lanç ar valor verdadeiro",
                ExprTexto = "Vickrey: paga 2º preço, incentivo verdade",
                Icone = "Vick",
                Descricao = "Leilão de Vickrey: vencedor paga segundo maior lance. Estratégia dominante é revelar valor verdadeiro. Equivalente a leilão inglês. Incentive-compatible.",
                Criador = "William Vickrey",
                AnoOrigin = "1961",
                ExemploPratico = "Jogador com valor v=100 lança 100, vence pagando 2º lance b₂=80. Payoff = 100-80 = 20.",
                Variaveis = [ new() { Simbolo = "v", Nome = "Valor verdadeiro v", ValorPadrao = 100 }, new() { Simbolo = "b₂", Nome = "2º maior lance b₂", ValorPadrao = 80 } ],
                VariavelResultado = "Payoff vencedor",
                UnidadeResultado = "",
                Calcular = vars => vars["v"] - vars["b₂"]
            },
            new Formula
            {
                Id = "5_me05", Nome = "Screening vs Signaling", Categoria = "Microeconomia Avançada", SubCategoria = "Informação Assimétrica",
                Expressao = "Screening: informado move 1º (autosseleção);  Signaling: desinformado move 1º",
                ExprTexto = "Screening: menu de contratos; Signaling: sinal custoso",
                Icone = "SS",
                Descricao = "Screening (Rothschild-Stiglitz): parte desinformada oferece menu para induzir autosseleção. Signaling (Spence): parte informada envia sinal custoso credível.",
                Criador = "Spence/Rothschild/Stiglitz",
                AnoOrigin = "1973-1976",
                ExemploPratico = "Exemplo: educação como sinal (Spence), seguros com deductibles (Rothschild-Stiglitz).",
                Variaveis = [ new() { Simbolo = "cH", Nome = "Custo sinal tipo alto", ValorPadrao = 10 }, new() { Simbolo = "cL", Nome = "Custo sinal tipo baixo", ValorPadrao = 20 } ],
                VariavelResultado = "Diferença custos (separação)",
                UnidadeResultado = "",
                Calcular = vars => vars["cL"] - vars["cH"]
            },
            new Formula
            {
                Id = "5_me06", Nome = "Hold-Up Problem (Investimentos Específicos)", Categoria = "Microeconomia Avançada", SubCategoria = "Contratos Incompletos",
                Expressao = "Subinvestimento quando contrato incompleto e investimento específico",
                ExprTexto = "Hold-up: subinvestimento ex-ante por renegociação ex-post",
                Icone = "HU",
                Descricao = "Problema de hold-up: investimentos específicos sofrem subinvestimento quando contratos são incompletos (Williamson, Grossman-Hart-Moore). Expropriação ex-post reduz incentivos ex-ante.",
                Criador = "Williamson/Grossman/Hart/Moore",
                AnoOrigin = "1985",
                ExemploPratico = "Fornecedor investe menos em máquina específica temendo renegociação ex-post.",
                Variaveis = [ new() { Simbolo = "I*", Nome = "Investimento ótimo I*", ValorPadrao = 100 }, new() { Simbolo = "I", Nome = "Investimento real I", ValorPadrao = 60 } ],
                VariavelResultado = "Subinvestimento",
                UnidadeResultado = "",
                Calcular = vars => vars["I*"] - vars["I"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 17.2 SOCIOFÍSICA (Modelos de Opinião e Redes Sociais)
    // ─────────────────────────────────────────────────────
    private void AdicionarSociofisica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_sf01", Nome = "Voter Model", Categoria = "Sociofísica", SubCategoria = "Dinâmica de Opinião",
                Expressao = "Agente adota opinião de vizinho aleatório;  deriva neutra",
                ExprTexto = "Voter: copia opinião de vizinho aleatório",
                Icone = "VM",
                Descricao = "Voter model: cada agente adota opinião de vizinho aleatório. Processo de deriva neutra. Em rede finita, convergência para consenso (absorving states ±1).",
                ExemploPratico = "Simulação: N agentes em rede, cada um copia vizinho. Tempo de consenso ~ N.",
                Variaveis = [ new() { Simbolo = "N", Nome = "Número agentes N", ValorPadrao = 100, ValorMin = 2 }, new() { Simbolo = "t", Nome = "Tempo t", ValorPadrao = 50 } ],
                VariavelResultado = "Tempo consenso estimado",
                UnidadeResultado = "passos",
                Calcular = vars => vars["N"] * Math.Log(vars["N"])
            },
            new Formula
            {
                Id = "5_sf02", Nome = "Modelo de Schelling (Segregação)", Categoria = "Sociofísica", SubCategoria = "Dinâmica de Opinião",
                Expressao = "Agentes se movem se < fração T de vizinhos são do mesmo tipo",
                ExprTexto = "Schelling: move se fração vizinhos < T",
                Icone = "Sch",
                Descricao = "Modelo de Schelling: agentes preferem vizinhança com fração ≥T do mesmo tipo. Mesmo com T pequeno (tolerância alta), emerge segregação global. Tipping point.",
                Criador = "Thomas Schelling",
                AnoOrigin = "1971",
                ExemploPratico = "Com T=0.3 (tolera 30% diferentes), sistema segrega. Ilustra efeito emergente de preferências brandas.",
                Variaveis = [ new() { Simbolo = "T", Nome = "Threshold T", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "fₛ", Nome = "Fração vizinhos mesmo tipo", ValorPadrao = 0.25, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Move? (1=sim, 0=não)",
                UnidadeResultado = "",
                Calcular = vars => vars["fₛ"] < vars["T"] ? 1.0 : 0.0
            },
            new Formula
            {
                Id = "5_sf03", Nome = "Modelo de Barabási-Albert", Categoria = "Sociofísica", SubCategoria = "Redes Sociais",
                Expressao = "P(conectar a nó i) ∝ ki;  gera rede scale-free",
                ExprTexto = "BA: attachment preferencial → scale-free",
                Icone = "BA",
                Descricao = "Modelo Barabási-Albert: crescimento de rede com attachment preferencial. Novos nós conectam preferencialmente a hubs. Gera distribuição de grau lei de potência P(k)~k⁻³.",
                Criador = "Barabási/Albert",
                AnoOrigin = "1999",
                ExemploPratico = "Simule rede: cada novo nó conecta a m nós existentes com prob ∝ ki. Emerge distribuição scale-free.",
                Variaveis = [ new() { Simbolo = "k", Nome = "Grau nó k", ValorPadrao = 10, ValorMin = 1 }, new() { Simbolo = "Σk", Nome = "Soma graus Σk", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Prob attachment",
                UnidadeResultado = "",
                Calcular = vars => vars["k"] / vars["Σk"]
            },
            new Formula
            {
                Id = "5_sf04", Nome = "Modelo de Watts-Strogatz (Pequeno Mundo)", Categoria = "Sociofísica", SubCategoria = "Redes Sociais",
                Expressao = "Rede regular + religação com prob p;  alto clustering + baixo caminho médio",
                ExprTexto = "WS: rewiring p → small-world",
                Icone = "WS",
                Descricao = "Modelo Watts-Strogatz: interpola entre rede regular (p=0) e aleatória (p=1). Para p pequeno, mantém alto clustering mas reduz drasticamente caminho médio. Small-world.",
                Criador = "Watts/Strogatz",
                AnoOrigin = "1998",
                ExemploPratico = "Com p=0.01, rede mantém clustering local mas ganha atalhos. Caminho médio ~ log(N).",
                Variaveis = [ new() { Simbolo = "p", Nome = "Prob rewiring p", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "L₀", Nome = "Caminho médio inicial L₀", ValorPadrao = 50 } ],
                VariavelResultado = "Caminho médio estimado",
                UnidadeResultado = "",
                Calcular = vars => vars["L₀"] * (1 - vars["p"] * 0.9)
            },
            new Formula
            {
                Id = "5_sf05", Nome = "Modelo SIS/SIR (Epidemiologia em Redes)", Categoria = "Sociofísica", SubCategoria = "Redes Sociais",
                Expressao = "SIS: S + I → 2I (taxa β);  I → S (taxa μ);  R₀ = β/μ",
                ExprTexto = "SIS: R₀=β/μ; epidemia se R₀>1",
                Icone = "SIS",
                Descricao = "Modelo SIS em rede: suscetível vira infectado (taxa β por vizinho infectado), infectado vira suscetível (taxa μ). Número reprodutivo R₀=β/μ. Em redes scale-free, limiar epidêmico → 0.",
                ExemploPratico = "Com β=0.3 (prob transmissão), μ=0.1 (prob recuperação), R₀=3. Epidemia se R₀>1.",
                Variaveis = [ new() { Simbolo = "β", Nome = "Taxa transmissão β", ValorPadrao = 0.3, ValorMin = 0 }, new() { Simbolo = "μ", Nome = "Taxa recuperação μ", ValorPadrao = 0.1, ValorMin = 0.001 } ],
                VariavelResultado = "Número reprodutivo R₀",
                UnidadeResultado = "",
                Calcular = vars => vars["β"] / vars["μ"]
            },
            new Formula
            {
                Id = "5_sf06", Nome = "Deffuant Model (Bounded Confidence)", Categoria = "Sociofísica", SubCategoria = "Dinâmica de Opinião",
                Expressao = "Agentes i,j interagem se |xi-xj| < ε;  xi := xi + μ(xj-xi)",
                ExprTexto = "Deffuant: converge se |x-y|<ε (bounded confidence)",
                Icone = "Def",
                Descricao = "Modelo de Deffuant: agentes só interagem e convergem opiniões se diferença < threshold ε (bounded confidence). μ=taxa de convergência. Clusters de opinião emergem.",
                Criador = "Guillaume Deffuant",
                AnoOrigin = "2000",
                ExemploPratico = "Com ε=0.2, opiniões separam em clusters se diferença inicial > ε. Polarização emerge.",
                Variaveis = [ new() { Simbolo = "xi", Nome = "Opinião agente i", ValorPadrao = 0.3 }, new() { Simbolo = "xj", Nome = "Opinião agente j", ValorPadrao = 0.5 }, new() { Simbolo = "ε", Nome = "Threshold ε", ValorPadrao = 0.2, ValorMin = 0 }, new() { Simbolo = "μ", Nome = "Taxa convergência μ", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Nova opinião i (se interagem)",
                UnidadeResultado = "",
                Calcular = vars => Math.Abs(vars["xi"] - vars["xj"]) < vars["ε"] ? vars["xi"] + vars["μ"] * (vars["xj"] - vars["xi"]) : vars["xi"]
            },
        ]);
    }
}
