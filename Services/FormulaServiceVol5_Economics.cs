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
            },
            new Formula
            {
                Id = "5_ds02", Nome = "Curva de Phillips Nova-Keynesiana", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "πt = β·Et[πt+1] + κ·xt",
                ExprTexto = "π = βE[π'] + κx",
                Icone = "NK",
                Descricao = "NKPC: inflação depende de expectativa futura e gap do produto. Derivada de firmas com preços rígidos (Calvo). κ = slope. Base da política monetária moderna.",
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
            },
            new Formula
            {
                Id = "5_ds06", Nome = "Equação IS (NK)", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "xt = Et[xt+1] - σ(it - Et[πt+1] - rⁿ)",
                ExprTexto = "x = E[x'] - σ(i-E[π']-rⁿ)",
                Icone = "IS",
                Descricao = "Curva IS dinâmica: gap do produto depende de expectativa futura e taxa de juros real (juros nominal less inflação esperada). σ=elasticidade intertemporal.",
            },
            new Formula
            {
                Id = "5_ds07", Nome = "Equação de Bellman", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "V(s) = max_a {u(s,a) + β·E[V(s')]}",
                ExprTexto = "V(s) = max{u(s,a)+βE[V(s')]}",
                Icone = "Bm",
                Descricao = "Equação de Bellman: princípio de otimalidade dinâmica. Valor de estado = utilidade imediata + valor descontado futuro. Resolvida por iteração ou perturbação.",
            },
            new Formula
            {
                Id = "5_ds08", Nome = "Log-linearização", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "x̂t = (xt - x̄)/x̄ ≈ ln(xt/x̄);  Taylor 1ª ordem em torno do steady state",
                ExprTexto = "x̂ = ln(x/x̄); aproxi. 1ª ordem",
                Icone = "LL",
                Descricao = "Log-linearização: aproximação de 1ª ordem em torno do estado estacionário. Transforma sistema não-linear em linear. Método Blanchard-Kahn para resolver.",
            },
            new Formula
            {
                Id = "5_ds09", Nome = "Restrição Orçamentária do Governo", Categoria = "Macroeconomia DSGE", SubCategoria = "Modelos DSGE",
                Expressao = "Bt+1/(1+it) = Bt + Gt - Tt + Transferências",
                ExprTexto = "B'/(1+i) = B + G - T + Tr",
                Icone = "Gov",
                Descricao = "Restrição fiscal: dívida pública evolui com déficit primário e juros. Condição de transversalidade: dívida não explode. Equivalência ricardiana.",
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
            },
            new Formula
            {
                Id = "5_ds11", Nome = "Teoria Quantitativa da Moeda", Categoria = "Macroeconomia DSGE", SubCategoria = "Economia Monetária",
                Expressao = "M·V = P·Y",
                ExprTexto = "MV = PY (TQM)",
                Icone = "MV",
                Descricao = "TQM: oferta monetária × velocidade = nível de preços × produto real. Com V constante, M determina P. Base do monetarismo.",
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
            },
            new Formula
            {
                Id = "5_ef02", Nome = "Lei de Potência (Retornos)", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "P(|r| > x) ∼ x⁻ᵅ;  α ≈ 3 (retornos)",
                ExprTexto = "P(|r|>x) ~ x⁻³ (cauda pesada)",
                Icone = "α",
                Descricao = "Caudas pesadas de retornos financeiros: distribuição segue lei de potência com expoente ~3 (lei cúbica inversa). Estilizado e universal.",
            },
            new Formula
            {
                Id = "5_ef03", Nome = "Volatility Clustering", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "Corr(|rt|, |rt+τ|) ∼ τ⁻ᵝ;  β ≈ 0.3",
                ExprTexto = "Autocorr(|r|) ~ τ^(-0.3)",
                Icone = "VC",
                Descricao = "Clustering de volatilidade: autocorrelação de retornos absolutos decai como lei de potência. Memória longa. Motivação para GARCH e modelos de vol estocástica.",
            },
            new Formula
            {
                Id = "5_ef04", Nome = "Modelo de Minority Game", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "N agentes, 2 lados;  lado minoritário vence",
                ExprTexto = "N agentes, 2 lados; minoria vence",
                Icone = "MG",
                Descricao = "Minority Game: modelo de coordenação. Agentes usam estratégias binárias; minoria é recompensada. Transição de fase em α=P/N. Emergência de auto-organização.",
            },
            new Formula
            {
                Id = "5_ef05", Nome = "Random Matrix Theory (Finanças)", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "Marchenko-Pastur: ρ(λ) = (T/N)√[(λ₊-λ)(λ-λ₋)]/(2πλ)",
                ExprTexto = "MP: ρ(λ) ∝ √[(λ₊-λ)(λ-λ₋)]/λ",
                Icone = "RMT",
                Descricao = "RMT aplicada a correlações financeiras: autovalores da matriz de correlação seguem Marchenko-Pastur para ruído. Autovalores fora = sinal real.",
            },
            new Formula
            {
                Id = "5_ef06", Nome = "Modelo de Percolação (Default)", Categoria = "Econofísica", SubCategoria = "Modelos de Agentes",
                Expressao = "pc = limiar de percolação;  p > pc → cluster gigante (contágio)",
                ExprTexto = "p > pc → contágio sistêmico",
                Icone = "Perc",
                Descricao = "Percolação em redes financeiras: se conectividade > limiar pc, default pode propagar por cluster gigante. Modela risco sistêmico e contágio.",
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
            },
            new Formula
            {
                Id = "5_ef09", Nome = "Zipf (Tamanho de Firmas)", Categoria = "Econofísica", SubCategoria = "Séries Financeiras",
                Expressao = "P(S > s) ∼ s⁻ζ;  ζ ≈ 1 (Zipf para firmas)",
                ExprTexto = "P(S>s) ~ s⁻¹ (Zipf-firmas)",
                Icone = "Zf",
                Descricao = "Lei de Zipf para tamanho de firmas: distribuição de tamanho segue lei de potência com expoente ~1. Também vale para cidades. Crescimento proporcional (Gibrat).",
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
            },
            new Formula
            {
                Id = "5_ef11", Nome = "Modelo de Boltzmann-Gibbs (Economia)", Categoria = "Econofísica", SubCategoria = "Séries Financeiras",
                Expressao = "P(m) = (1/T)·exp(-m/T);  T = renda média",
                ExprTexto = "P(m) = e^(-m/T)/T (Boltzmann-renda)",
                Icone = "BG",
                Descricao = "Distribuição de Boltzmann-Gibbs para renda: maioria da população segue exponencial. Cauda superior segue Pareto. Resultado de trocas conservativas aleatórias.",
            },
        ]);
    }
}
