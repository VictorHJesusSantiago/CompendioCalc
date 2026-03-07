using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 3 — PARTE V: APLICADAS (FINANÇAS, PO, CLIMA, BIO, ACÚSTICA)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 19. FINANÇAS QUANTITATIVAS
    // ─────────────────────────────────────────────────────
    private void AdicionarFinancasQuantitativas()
    {
        _formulas.AddRange([
            // 19.1 Markowitz e CAPM
            new Formula
            {
                Id = "3_mk01", Nome = "Retorno Esperado da Carteira", Categoria = "Finanças Quantitativas", SubCategoria = "Markowitz",
                Expressao = "E[Rp] = Σ wᵢE[Rᵢ]",
                ExprTexto = "E[Rp] = Σ wᵢE[Rᵢ]",
                Icone = "E[R]",
                Descricao = "Retorno esperado da carteira é média ponderada dos retornos esperados dos ativos. Pesos wᵢ somam 1 (ou >1 com alavancagem).",
                Criador = "Harry Markowitz",
                AnoOrigin = "1952",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "E", Nome = "E", ValorPadrao = 1 }, new() { Simbolo = "Rp", Nome = "Rp", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["E"] + vars["Rp"]
            },
            new Formula
            {
                Id = "3_mk02", Nome = "Variância da Carteira", Categoria = "Finanças Quantitativas", SubCategoria = "Markowitz",
                Expressao = "σ²p = Σᵢ Σⱼ wᵢwⱼσᵢⱼ = w'Σw",
                ExprTexto = "σ²p = w'Σw",
                Icone = "σ²p",
                Descricao = "Risco da carteira depende das covariâncias (Σ) entre todos os pares. Diversificação reduz risco se correlações < 1. Base da MPT (Modern Portfolio Theory).",
                Criador = "Harry Markowitz",
                AnoOrigin = "1952",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 1 }, new() { Simbolo = "w", Nome = "w", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["sigma"] + vars["w"]
            },
            new Formula
            {
                Id = "3_mk03", Nome = "Índice de Sharpe", Categoria = "Finanças Quantitativas", SubCategoria = "Markowitz",
                Expressao = "SR = (E[Rp]-Rf)/σp",
                ExprTexto = "SR = (E[Rp]−Rf)/σp",
                Icone = "SR",
                Descricao = "Retorno excedente por unidade de risco. Carteira ótima: maximiza Sharpe na fronteira eficiente (tangente com a reta de ativos livres de risco).",
                Criador = "William Sharpe",
                AnoOrigin = "1966",
                Variaveis = [
                    new() { Simbolo = "ERp", Nome = "E[Rp] (%)", ValorPadrao = 12 },
                    new() { Simbolo = "Rf", Nome = "Rf (%)", Descricao = "Taxa livre de risco", ValorPadrao = 3 },
                    new() { Simbolo = "sigmap", Nome = "σp (%)", Descricao = "Volatilidade", ValorPadrao = 15 },
                ],
                VariavelResultado = "Sharpe Ratio",
                Calcular = v => (v["ERp"] - v["Rf"]) / v["sigmap"]
            },
            new Formula
            {
                Id = "3_mk04", Nome = "Fronteira Eficiente", Categoria = "Finanças Quantitativas", SubCategoria = "Markowitz",
                Expressao = "min w'Σw  sujeito a  w'μ=μ_target, w'1=1",
                ExprTexto = "min σ²p  s.a.  E[Rp]=μ_target;  Σwᵢ=1",
                Icone = "FE",
                Descricao = "Conjunto de carteiras que minimizam risco para dado retorno (ou maximizam retorno para dado risco). Solução por multiplicadores de Lagrange → parábola no plano σ-E[R].",
                Criador = "Harry Markowitz",
                AnoOrigin = "1952",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["sigma"] + vars["s"]
            },
            new Formula
            {
                Id = "3_mk05", Nome = "CAPM (Capital Asset Pricing Model)", Categoria = "Finanças Quantitativas", SubCategoria = "CAPM",
                Expressao = "E[Rᵢ] = Rf + βᵢ(E[Rm]-Rf)",
                ExprTexto = "E[Rᵢ] = Rf + βᵢ(E[Rm]−Rf)",
                Icone = "β",
                Descricao = "Retorno esperado = taxa livre + prêmio de risco proporcional ao beta. βᵢ = Cov(Rᵢ,Rm)/Var(Rm). β=1 → risco de mercado. β>1 → mais arriscado.",
                Criador = "William Sharpe / John Lintner / Jan Mossin",
                AnoOrigin = "1964",
                Variaveis = [
                    new() { Simbolo = "Rf", Nome = "Rf (%)", ValorPadrao = 3 },
                    new() { Simbolo = "beta", Nome = "β", ValorPadrao = 1.2 },
                    new() { Simbolo = "ERm", Nome = "E[Rm] (%)", ValorPadrao = 10 },
                ],
                VariavelResultado = "E[Rᵢ] (%)",
                UnidadeResultado = "%",
                Calcular = v => v["Rf"] + v["beta"] * (v["ERm"] - v["Rf"])
            },
            new Formula
            {
                Id = "3_mk06", Nome = "APT (Arbitrage Pricing Theory)", Categoria = "Finanças Quantitativas", SubCategoria = "CAPM",
                Expressao = "E[Rᵢ] = Rf + Σⱼ βᵢⱼ·λⱼ",
                ExprTexto = "E[Rᵢ] = Rf + Σⱼ βᵢⱼ·λⱼ",
                Icone = "APT",
                Descricao = "Generalização do CAPM: múltiplos fatores de risco (inflação, PIB, taxa de juros...). λⱼ = prêmio do fator j. Não assume carteira de mercado eficiente.",
                Criador = "Stephen Ross",
                AnoOrigin = "1976",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "E", Nome = "E", ValorPadrao = 1 }, new() { Simbolo = "Rf", Nome = "Rf", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["E"] + vars["Rf"]
            },
            // 19.2 Derivativos e Greeks
            new Formula
            {
                Id = "3_gr01", Nome = "Black-Scholes (Call Europeia)", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "C = S·N(d₁) - K·e^(-rT)·N(d₂)",
                ExprTexto = "C = S·N(d₁) − Ke⁻ʳᵀ·N(d₂)",
                Icone = "BSM",
                Descricao = "Preço de opção de compra europeia. d₁ = (ln(S/K)+(r+σ²/2)T)/(σ√T). Assume log-normal, sem dividendos, vol constante. Revolução em finanças, Nobel 1997.",
                Criador = "Fischer Black / Myron Scholes / Robert Merton",
                AnoOrigin = "1973",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 5 }, new() { Simbolo = "N", Nome = "N", ValorPadrao = 3 } ],
                VariavelResultado = "C",
                UnidadeResultado = "",
                Calcular = vars => vars["S"] * vars["N"]
            },
            new Formula
            {
                Id = "3_gr02", Nome = "d₁ e d₂ (Black-Scholes)", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "d₁ = (ln(S/K)+(r+σ²/2)T)/(σ√T);  d₂ = d₁ - σ√T",
                ExprTexto = "d₁ = (ln(S/K)+(r+σ²/2)T)/(σ√T);  d₂ = d₁−σ√T",
                Icone = "d₁d₂",
                Descricao = "d₁ é Z-score ajustado pelo risco de exercer a opção. d₂ é a probabilidade risk-neutral de exercício. N() = CDF normal padrão.",
                Criador = "Black-Scholes-Merton",
                AnoOrigin = "1973",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "d₁", Nome = "d₁", ValorPadrao = 10 }, new() { Simbolo = "σ", Nome = "σ", ValorPadrao = 5 } ],
                VariavelResultado = "d₂",
                UnidadeResultado = "",
                Calcular = vars => vars["d₁"] - vars["σ"]
            },
            new Formula
            {
                Id = "3_gr03", Nome = "Delta (Δ)", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "Δ = ∂C/∂S = N(d₁)  (call);  Δ = N(d₁)-1  (put)",
                ExprTexto = "Δ = ∂C/∂S = N(d₁)",
                Icone = "Δ",
                Descricao = "Sensibilidade do preço da opção ao preço do ativo subjacente. Δ=0.5 → at-the-money. Mede unidades do ativo para hedge delta-neutro.",
                Criador = "Black-Scholes-Merton",
                AnoOrigin = "1973",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Delta", Nome = "Delta", ValorPadrao = 1 }, new() { Simbolo = "C", Nome = "C", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Delta"] + vars["C"]
            },
            new Formula
            {
                Id = "3_gr04", Nome = "Gamma (Γ)", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "Γ = ∂²C/∂S² = n(d₁)/(Sσ√T)",
                ExprTexto = "Γ = ∂²C/∂S² = φ(d₁)/(Sσ√T)",
                Icone = "Γ",
                Descricao = "Taxa de variação do Delta. Alta perto do strike e vencimento. Gamma alto → Delta muda rápido → rebalanceamento frequente de hedge necessário.",
                Criador = "Teoria de opções",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "3_gr05", Nome = "Theta (Θ)", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "Θ = -∂C/∂T (decaimento temporal)",
                ExprTexto = "Θ = −∂C/∂T",
                Icone = "Θ",
                Descricao = "Perda de valor por unidade de tempo (time decay). Sempre negativo para opções compradas. Acelera perto do vencimento. Vendedor de opções: Θ ganha dinheiro se S parado.",
                Criador = "Teoria de opções",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "C", Nome = "C", ValorPadrao = 1 }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["C"] + vars["T"]
            },
            new Formula
            {
                Id = "3_gr06", Nome = "Vega (ν)", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "ν = ∂C/∂σ = S·n(d₁)·√T",
                ExprTexto = "ν = ∂C/∂σ = S·φ(d₁)·√T",
                Icone = "ν",
                Descricao = "Sensibilidade à volatilidade implícita. Maior para ATM e maturidade longa. Se vol sobe 1% → preço da opção sobe ν unidades. Não é letra grega formalmente.",
                Criador = "Teoria de opções",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 5 }, new() { Simbolo = "φ", Nome = "φ", ValorPadrao = 3 } ],
                VariavelResultado = "σ",
                UnidadeResultado = "",
                Calcular = vars => vars["S"] * vars["φ"]
            },
            new Formula
            {
                Id = "3_gr07", Nome = "Rho (ρ)", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "ρ = ∂C/∂r = KTe^(-rT)N(d₂)",
                ExprTexto = "ρ = ∂C/∂r = KTe⁻ʳᵀN(d₂)",
                Icone = "ρ",
                Descricao = "Sensibilidade à taxa de juros. Geralmente o Greek menos importante para equities, mais relevante para renda fixa e swaps de taxa de juros.",
                Criador = "Teoria de opções",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            new Formula
            {
                Id = "3_gr08", Nome = "Paridade Put-Call", Categoria = "Finanças Quantitativas", SubCategoria = "Derivativos e Greeks",
                Expressao = "C - P = S - Ke^(-rT)",
                ExprTexto = "C − P = S − Ke⁻ʳᵀ",
                Icone = "P-C",
                Descricao = "Relação de arbitragem para opções europeias. Violação → arbitragem livre de risco. Não depende de modelo (válida para qualquer processo do ativo).",
                Criador = "Hans Stoll",
                AnoOrigin = "1969",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "S", Nome = "S", ValorPadrao = 10 }, new() { Simbolo = "Ke", Nome = "Ke", ValorPadrao = 5 } ],
                VariavelResultado = "P",
                UnidadeResultado = "",
                Calcular = vars => vars["S"] - vars["Ke"]
            },
            // 19.3 Risco
            new Formula
            {
                Id = "3_ri01", Nome = "Value at Risk (VaR)", Categoria = "Finanças Quantitativas", SubCategoria = "Gestão de Risco",
                Expressao = "P(L > VaR_α) = 1-α  (ex.: α=99%)",
                ExprTexto = "P(L > VaRα) = 1−α",
                Icone = "VaR",
                Descricao = "Perda máxima com confiança α em horizonte h. VaR 99% 1 dia = R$1M → probabilidade 1% de perder mais que R$1M em 1 dia. Basel II/III exige VaR.",
                Criador = "J.P. Morgan (RiskMetrics)",
                AnoOrigin = "1994",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "P", Nome = "P", ValorPadrao = 1 }, new() { Simbolo = "L", Nome = "L", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["P"] + vars["L"]
            },
            new Formula
            {
                Id = "3_ri02", Nome = "VaR Paramétrico (Normal)", Categoria = "Finanças Quantitativas", SubCategoria = "Gestão de Risco",
                Expressao = "VaR_α = μ + z_α·σ  (z₀.₉₉ = 2.326)",
                ExprTexto = "VaRα = μ + zα·σ",
                Icone = "VaR-N",
                Descricao = "Sob normalidade: VaR é quantil da distribuição de P&L. Simples mas subestima risco em caudas pesadas. Extensão: VaR t-Student ou EVT.",
                Criador = "RiskMetrics / J.P. Morgan",
                AnoOrigin = "1994",
                Variaveis = [
                    new() { Simbolo = "mu", Nome = "μ (retorno médio)", ValorPadrao = 0 },
                    new() { Simbolo = "z", Nome = "z_α", Descricao = "Quantil normal (2.326 para 99%)", ValorPadrao = 2.326 },
                    new() { Simbolo = "sigma", Nome = "σ (volatilidade)", ValorPadrao = 0.02 },
                ],
                VariavelResultado = "VaR",
                Calcular = v => v["mu"] + v["z"] * v["sigma"]
            },
            new Formula
            {
                Id = "3_ri03", Nome = "Expected Shortfall (ES/CVaR)", Categoria = "Finanças Quantitativas", SubCategoria = "Gestão de Risco",
                Expressao = "ES_α = E[L | L > VaR_α]",
                ExprTexto = "ESα = E[L | L>VaRα]",
                Icone = "ES",
                Descricao = "Perda esperada dado que excedeu VaR. Medida coerente (subaditividade). ES ≥ VaR sempre. Basel IV substituiu VaR por ES para capital de mercado.",
                Criador = "Acerbi / Tasche / Basel IV",
                AnoOrigin = "2002",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "ES", Nome = "ES", ValorPadrao = 1 }, new() { Simbolo = "alpha", Nome = "alpha", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["ES"] + vars["alpha"]
            },
            new Formula
            {
                Id = "3_ri04", Nome = "CVA (Credit Valuation Adjustment)", Categoria = "Finanças Quantitativas", SubCategoria = "Gestão de Risco",
                Expressao = "CVA = (1-R)∫₀ᵀ EE(t)·dPD(0,t)",
                ExprTexto = "CVA = (1−R)∫₀ᵀ EE(t)·dPD(t)",
                Icone = "CVA",
                Descricao = "Ajuste no preço de derivativo OTC pelo risco de default da contraparte. EE=exposição esperada, PD=probabilidade de default, R=taxa de recuperação.",
                Criador = "Basel III / Precificação de crédito",
                AnoOrigin = "~2010",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 20. PESQUISA OPERACIONAL
    // ─────────────────────────────────────────────────────
    private void AdicionarPesquisaOperacional()
    {
        _formulas.AddRange([
            // 20.1 Programação Linear
            new Formula
            {
                Id = "3_po01", Nome = "Problema de Programação Linear (PL)", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Linear",
                Expressao = "min c'x  s.a.  Ax ≤ b, x ≥ 0",
                ExprTexto = "min c'x  s.a.  Ax≤b, x≥0",
                Icone = "LP",
                Descricao = "Otimização linear: objetivo linear, restrições lineares. Solução ótima sempre num vértice do poliedro viável. Aplicações: logística, produção, transporte, dieta.",
                Criador = "George Dantzig / Leonid Kantorovich",
                AnoOrigin = "1947/1939",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "c", Nome = "c", ValorPadrao = 1 }, new() { Simbolo = "x", Nome = "x", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] + vars["x"]
            },
            new Formula
            {
                Id = "3_po02", Nome = "Dual do PL", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Linear",
                Expressao = "max b'y  s.a.  A'y ≤ c, y ≥ 0",
                ExprTexto = "max b'y  s.a.  A'y≤c, y≥0",
                Icone = "Dual",
                Descricao = "Todo PL tem um dual. Na otiminalidade: c'x* = b'y* (dualidade forte). yᵢ* = preço-sombra da restrição i (valor marginal de relaxar o recurso).",
                Criador = "George Dantzig / John von Neumann",
                AnoOrigin = "1947",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "b", Nome = "b", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["b"] + vars["y"]
            },
            new Formula
            {
                Id = "3_po03", Nome = "Método Simplex", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Linear",
                Expressao = "Vértice → vértice adjacente com custo menor → ótimo",
                ExprTexto = "Pivoting: vértice → vértice → ... → ótimo",
                Icone = "△",
                Descricao = "Caminha de vértice em vértice do poliedro viável, sempre melhorando. Exponencial no pior caso (Klee-Minty), mas excelente na prática (tipicamente O(m) iterações).",
                Criador = "George Dantzig",
                AnoOrigin = "1947",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] + vars["y"]
            },
            new Formula
            {
                Id = "3_po04", Nome = "Condições KKT", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Linear",
                Expressao = "∇f + Σλᵢ∇gᵢ + Σμⱼ∇hⱼ = 0;  λᵢgᵢ=0;  λᵢ≥0",
                ExprTexto = "∇f + Σλᵢ∇gᵢ = 0;  λᵢgᵢ=0;  λ≥0",
                Icone = "KKT",
                Descricao = "Condições necessárias de otimalidade para programação não-linear com restrições. Generalização de Lagrange para desigualdades. Complementaridade: λᵢ·gᵢ=0.",
                Criador = "Karush / Kuhn-Tucker",
                AnoOrigin = "1939/1951",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "f", Nome = "f", ValorPadrao = 1 }, new() { Simbolo = "lambda_", Nome = "lambda_", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["f"] + vars["lambda_"]
            },
            new Formula
            {
                Id = "3_po05", Nome = "Método de Pontos Interiores", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Linear",
                Expressao = "Barreira: min c'x - μΣln(xᵢ)  (μ→0)",
                ExprTexto = "min c'x − μΣln(xᵢ);  μ→0",
                Icone = "IP",
                Descricao = "Alternativa ao simplex: caminha pelo interior do poliedro. Polinomial (O(n³·⁵L)). Melhor para problemas muito grandes. Karmarkar (1984) revolucionou a PL.",
                Criador = "Narendra Karmarkar",
                AnoOrigin = "1984",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            // 20.2 Programação Inteira e Combinatória
            new Formula
            {
                Id = "3_po06", Nome = "Programação Inteira (IP)", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Inteira",
                Expressao = "min c'x  s.a.  Ax≤b, x ∈ ℤⁿ",
                ExprTexto = "min c'x  s.a.  Ax≤b, x∈ℤⁿ",
                Icone = "IP",
                Descricao = "PL com variáveis inteiras. NP-difícil em geral. Métodos: Branch-and-Bound, Branch-and-Cut, planos de corte. Aplicações: scheduling, network design, facility location.",
                Criador = "Ralph Gomory / Land & Doig",
                AnoOrigin = "1958-1960",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "c", Nome = "c", ValorPadrao = 1 }, new() { Simbolo = "x", Nome = "x", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] + vars["x"]
            },
            new Formula
            {
                Id = "3_po07", Nome = "Programação Dinâmica (Princípio de Bellman)", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Inteira",
                Expressao = "V(s) = min_a {c(s,a) + V(f(s,a))}",
                ExprTexto = "V(s) = minₐ{c(s,a)+V(f(s,a))}",
                Icone = "DP",
                Descricao = "Princípio de otimalidade: solução ótima contém subsoluções ótimas. Equação de Bellman resolve recursivamente. O(estados × ações). Mochila, caminho mínimo, controle ótimo.",
                Criador = "Richard Bellman",
                AnoOrigin = "1957",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "V", Nome = "V", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["V"] + vars["s"]
            },
            new Formula
            {
                Id = "3_po08", Nome = "Problema do Caixeiro Viajante (TSP)", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Inteira",
                Expressao = "min Σ cᵢⱼxᵢⱼ  s.a.  hamiltonian tour;  NP-hard",
                ExprTexto = "min Σcᵢⱼxᵢⱼ  (ciclo hamiltoniano ótimo)",
                Icone = "TSP",
                Descricao = "Encontrar rota mais curta visitando n cidades exatamente uma vez. NP-difícil: n! rotas. Métodos: Branch-and-Cut, LKH, DP (2ⁿ). Concorde resolve até ~85000 cidades.",
                Criador = "Problema clássico de combinatória",
                AnoOrigin = "~1930",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] + vars["y"]
            },
            new Formula
            {
                Id = "3_po09", Nome = "Problema da Mochila", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Inteira",
                Expressao = "max Σvᵢxᵢ  s.a.  Σwᵢxᵢ ≤ W, xᵢ∈{0,1}",
                ExprTexto = "max Σvᵢxᵢ  s.a.  Σwᵢxᵢ≤W, xᵢ∈{0,1}",
                Icone = "🎒",
                Descricao = "Selecionar itens com maior valor total sem exceder capacidade W. NP-hard mas pseudopolinomial por DP em O(nW). Relaxação LP dá bound superior.",
                Criador = "Problema clássico",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 }, new() { Simbolo = "a", Nome = "a", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["s"] + vars["a"]
            },
            new Formula
            {
                Id = "3_po10", Nome = "Relaxação Lagrangiana", Categoria = "Pesquisa Operacional", SubCategoria = "Programação Inteira",
                Expressao = "L(λ) = min_x {c'x + λ'(Ax-b)};  max_λ L(λ) ≤ z*",
                ExprTexto = "L(λ) = minₓ{c'x+λ'(Ax−b)};  maxλ L(λ)≤z*",
                Icone = "LR",
                Descricao = "Relaxa restrições difíceis com multiplicadores λ. Dual lagrangiano dá bound inferior melhor que LP relaxado (se complicating constraints). Resolve por subgradiente.",
                Criador = "Marshall Fisher / Held-Karp",
                AnoOrigin = "1970-1974",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "L", Nome = "L", ValorPadrao = 1 }, new() { Simbolo = "lambda_", Nome = "lambda_", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["L"] + vars["lambda_"]
            },
            // 20.3 Teoria de Filas
            new Formula
            {
                Id = "3_tf01", Nome = "Fila M/M/1", Categoria = "Pesquisa Operacional", SubCategoria = "Teoria de Filas",
                Expressao = "L = ρ/(1-ρ);  ρ = λ/μ < 1",
                ExprTexto = "L = ρ/(1−ρ);  ρ=λ/μ",
                Icone = "M/M/1",
                Descricao = "Fila com chegadas Poisson(λ), serviço exponencial(μ), 1 servidor. L=clientes médios no sistema. Para ρ→1, L→∞ (congestionamento). Modelo básico de teoria de filas.",
                Criador = "Agner Krarup Erlang",
                AnoOrigin = "1909/1917",
                Variaveis = [
                    new() { Simbolo = "lambda", Nome = "λ (chegadas/s)", ValorPadrao = 0.8 },
                    new() { Simbolo = "mu", Nome = "μ (serviços/s)", ValorPadrao = 1.0 },
                ],
                VariavelResultado = "L (clientes no sistema)",
                Calcular = v => {
                    double rho = v["lambda"] / v["mu"];
                    return rho < 1 ? rho / (1 - rho) : double.PositiveInfinity;
                }
            },
            new Formula
            {
                Id = "3_tf02", Nome = "Lei de Little", Categoria = "Pesquisa Operacional", SubCategoria = "Teoria de Filas",
                Expressao = "L = λ·W",
                ExprTexto = "L = λ·W",
                Icone = "L=λW",
                Descricao = "Resultado universal: clientes médios = taxa de chegada × tempo médio no sistema. Vale para qualquer sistema estável, não depende da distribuição. Extremamente útil.",
                Criador = "John Little",
                AnoOrigin = "1961",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "λ", Nome = "λ", ValorPadrao = 5 }, new() { Simbolo = "W", Nome = "W", ValorPadrao = 3 } ],
                VariavelResultado = "L",
                UnidadeResultado = "",
                Calcular = vars => vars["λ"] * vars["W"]
            },
            new Formula
            {
                Id = "3_tf03", Nome = "Tempo Médio no Sistema M/M/1", Categoria = "Pesquisa Operacional", SubCategoria = "Teoria de Filas",
                Expressao = "W = 1/(μ-λ);  Wq = ρ/(μ-λ)",
                ExprTexto = "W = 1/(μ−λ);  Wq = ρ/(μ−λ)",
                Icone = "W",
                Descricao = "Tempo total W = espera Wq + serviço 1/μ. Diverge quando λ→μ. Aplicação: dimensionamento de call centers, servidores, linhas de produção.",
                Criador = "Erlang / Teoria de filas",
                Variaveis = [
                    new() { Simbolo = "mu", Nome = "μ (serviços/s)", ValorPadrao = 1.0 },
                    new() { Simbolo = "lambda", Nome = "λ (chegadas/s)", ValorPadrao = 0.8 },
                ],
                VariavelResultado = "W (s)",
                UnidadeResultado = "s",
                Calcular = v => v["mu"] > v["lambda"] ? 1.0 / (v["mu"] - v["lambda"]) : double.PositiveInfinity
            },
            new Formula
            {
                Id = "3_tf04", Nome = "Fila M/M/c", Categoria = "Pesquisa Operacional", SubCategoria = "Teoria de Filas",
                Expressao = "P_espera = C(c,ρ) Erlang-C;  ρ=λ/(cμ)<1",
                ExprTexto = "P(espera>0) = C(c,ρ) (Erlang-C)",
                Icone = "M/M/c",
                Descricao = "c servidores paralelos: fórmula Erlang-C para probabilidade de esperar. Aumentar c diminui espera dramaticamente. Design de call centers: dado SLA, encontrar c mínimo.",
                Criador = "Agner Krarup Erlang",
                AnoOrigin = "1917",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "P", Nome = "P", ValorPadrao = 1 }, new() { Simbolo = "C", Nome = "C", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["P"] + vars["C"]
            },
            new Formula
            {
                Id = "3_tf05", Nome = "Fórmula de Erlang-B (Bloqueio)", Categoria = "Pesquisa Operacional", SubCategoria = "Teoria de Filas",
                Expressao = "B(c,A) = (A^c/c!) / Σₖ₌₀ᶜ (Aᵏ/k!)",
                ExprTexto = "B(c,A) = (Aᶜ/c!) / Σₖ Aᵏ/k!",
                Icone = "Erlang-B",
                Descricao = "Probabilidade de bloqueio em sistema M/M/c/c (sem fila, c canais). A=λ/μ intensidade de tráfego (Erlangs). Dimensionamento de troncos telefônicos e redes.",
                Criador = "Agner Krarup Erlang",
                AnoOrigin = "1917",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "B", Nome = "B", ValorPadrao = 1 }, new() { Simbolo = "c", Nome = "c", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["B"] + vars["c"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 21. CIÊNCIAS DO CLIMA
    // ─────────────────────────────────────────────────────
    private void AdicionarCienciasClima()
    {
        _formulas.AddRange([
            // 21.1 Equações Primitivas / Dinâmica Atmosférica
            new Formula
            {
                Id = "3_cl01", Nome = "Equações Primitivas", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "Momento: Dv/Dt + fk̂×v = -∇p/ρ + F;  Continuidade; Termodinâmica",
                ExprTexto = "Dv⃗/Dt + fk̂×v⃗ = −∇p/ρ + F⃗",
                Icone = "🌡",
                Descricao = "Base dos modelos de circulação geral (GCMs): Navier-Stokes em esfera rotativa com efeito de Coriolis, equação de continuidade, equação de estado e termodinâmica.",
                Criador = "Vilhelm Bjerknes / Lewis Fry Richardson",
                AnoOrigin = "1904/1922",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Dv", Nome = "Dv", ValorPadrao = 1 }, new() { Simbolo = "Dt", Nome = "Dt", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Dv"] + vars["Dt"]
            },
            new Formula
            {
                Id = "3_cl02", Nome = "Parâmetro de Coriolis", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "f = 2Ωsin(φ)",
                ExprTexto = "f = 2Ωsin(φ)",
                Icone = "f",
                Descricao = "Força de Coriolis devida à rotação terrestre. f=0 no equador, máximo nos polos. Deflete ventos à direita (NH) e esquerda (SH). Fundamental para circulação atmosférica.",
                Criador = "Gaspard-Gustave de Coriolis",
                AnoOrigin = "1835",
                Variaveis = [
                    new() { Simbolo = "Omega", Nome = "Ω (rad/s)", ValorPadrao = 7.2921e-5 },
                    new() { Simbolo = "phi", Nome = "φ (latitude °)", ValorPadrao = 45 },
                ],
                VariavelResultado = "f (s⁻¹)",
                UnidadeResultado = "s⁻¹",
                Calcular = v => 2 * v["Omega"] * Math.Sin(v["phi"] * Math.PI / 180)
            },
            new Formula
            {
                Id = "3_cl03", Nome = "Vento Geostrófico", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "fv_g = (1/ρ)∂p/∂x;  fu_g = -(1/ρ)∂p/∂y",
                ExprTexto = "v⃗g = (k̂×∇p)/(ρf)",
                Icone = "vg",
                Descricao = "Equilíbrio Coriolis-pressão: vento paralelo às isóbaras. Boa aproximação em latitudes médias acima da camada limite. Ventos observados diferem ~10-15% do geostrófico.",
                Criador = "Meteorologia dinâmica",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "v", Nome = "v", ValorPadrao = 1 }, new() { Simbolo = "g", Nome = "g", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["v"] + vars["g"]
            },
            new Formula
            {
                Id = "3_cl04", Nome = "Equação da Vorticidade", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "D(ζ+f)/Dt = -(ζ+f)∇·v + baroclinicidade + fricção",
                ExprTexto = "D(ζ+f)/Dt = −(ζ+f)∇·v⃗ + ...",
                Icone = "ζ",
                Descricao = "Evolução da vorticidade absoluta (relativa ζ + planetária f). Conservada em fluido barotropic. Divergência → estiramento de vórtice. Base de modelos de previsão.",
                Criador = "Carl-Gustaf Rossby / Jule Charney",
                AnoOrigin = "~1939-1950",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "D", Nome = "D", ValorPadrao = 1 }, new() { Simbolo = "zeta", Nome = "zeta", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["D"] + vars["zeta"]
            },
            new Formula
            {
                Id = "3_cl05", Nome = "Vorticidade Potencial de Ertel", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "PV = ((ζ+f)/ρ)·∇θ (conservada adiabaticamente)",
                ExprTexto = "PV = (ζ+f)·∇θ/ρ",
                Icone = "PV",
                Descricao = "Quantidade conservada em escoamento adiabático e sem fricção. 'Mapa' PV diagnóstica toda a dinâmica de larga escala. Unidade: PVU (1 PVU = 10⁻⁶ K m² kg⁻¹ s⁻¹).",
                Criador = "Hans Ertel",
                AnoOrigin = "1942",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "PV", Nome = "PV", ValorPadrao = 1 }, new() { Simbolo = "zeta", Nome = "zeta", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["PV"] + vars["zeta"]
            },
            new Formula
            {
                Id = "3_cl06", Nome = "Número de Rossby", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "Ro = U/(fL)",
                ExprTexto = "Ro = U/(fL)",
                Icone = "Ro",
                Descricao = "Razão inércia/Coriolis. Ro≪1: rotação domina (grande escala, geostrófico). Ro~1: ambos importantes (mesoescala, tornado, ciclone tropical). Ro≫1: fluido não-rotante.",
                Criador = "Carl-Gustaf Rossby",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Ro", Nome = "Ro", ValorPadrao = 1 }, new() { Simbolo = "U", Nome = "U", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Ro"] + vars["U"]
            },
            new Formula
            {
                Id = "3_cl07", Nome = "Equação Hidrostática", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "∂p/∂z = -ρg",
                ExprTexto = "∂p/∂z = −ρg",
                Icone = "↕",
                Descricao = "Na vertical, pressão equilibra gravidade. Válida quando movimentos verticais são muito menores que horizontais (L≫H). Excelente para grande escala, falha em convecção.",
                Criador = "Meteorologia clássica",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 1 }, new() { Simbolo = "z", Nome = "z", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["p"] + vars["z"]
            },
            new Formula
            {
                Id = "3_cl08", Nome = "Vento Térmico", Categoria = "Ciências do Clima", SubCategoria = "Dinâmica Atmosférica",
                Expressao = "∂v_g/∂z = -(g/fT)k̂×∇T",
                ExprTexto = "∂v⃗g/∂z = −(g/(fT))k̂×∇T",
                Icone = "VT",
                Descricao = "Relação entre cisalhamento vertical do vento geostrófico e gradiente horizontal de temperatura. Jet stream em latitudes médias é consequência do gradiente polo-equador.",
                Criador = "Meteorologia dinâmica",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "v", Nome = "v", ValorPadrao = 1 }, new() { Simbolo = "g", Nome = "g", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["v"] + vars["g"]
            },
            // 21.2 Modelo de Balanço Energético e Clima
            new Formula
            {
                Id = "3_cl09", Nome = "Balanço Energético Global", Categoria = "Ciências do Clima", SubCategoria = "Balanço Energético",
                Expressao = "Ceff·dT/dt = (1-α)S₀/4 - εσT⁴ + ΔF",
                ExprTexto = "Ceff·dT/dt = (1−α)S₀/4 − εσT⁴ + ΔF",
                Icone = "EBM",
                Descricao = "Modelo de balanço energético 0D: radiação solar absorvida = radiação emitida + forçante + acúmulo. S₀≈1361 W/m², α≈0.3 (albedo), σ Stefan-Boltzmann.",
                Criador = "Mikhail Budyko / William Sellers",
                AnoOrigin = "1969",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "dT", Nome = "dT", ValorPadrao = 1 }, new() { Simbolo = "dt", Nome = "dt", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["dT"] + vars["dt"]
            },
            new Formula
            {
                Id = "3_cl10", Nome = "Sensibilidade Climática", Categoria = "Ciências do Clima", SubCategoria = "Balanço Energético",
                Expressao = "ΔT_eq = λ·ΔF;  λ ≈ 0.8 K/(W/m²)  (sem feedback)",
                ExprTexto = "ΔTeq = λ·ΔF",
                Icone = "λ",
                Descricao = "Aquecimento de equilíbrio por unidade de forçante radiativa. Com feedbacks (vapor d'água, gelo-albedo): ECS = 2.5-4.5 K por dobro de CO₂. IPCC AR6: 3°C melhor estimativa.",
                Criador = "Svante Arrhenius / Ciência do clima",
                AnoOrigin = "1896",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "λ", Nome = "λ", ValorPadrao = 5 }, new() { Simbolo = "ΔF", Nome = "ΔF", ValorPadrao = 3 } ],
                VariavelResultado = "ΔTeq",
                UnidadeResultado = "",
                Calcular = vars => vars["λ"] * vars["ΔF"]
            },
            new Formula
            {
                Id = "3_cl11", Nome = "Forçante por CO₂", Categoria = "Ciências do Clima", SubCategoria = "Balanço Energético",
                Expressao = "ΔF = 5.35·ln(C/C₀)  (W/m²)",
                ExprTexto = "ΔF = 5.35·ln(C/C₀)  W/m²",
                Icone = "CO₂",
                Descricao = "Forçante radiativa logarítmica na concentração de CO₂. Dobrar CO₂ → ΔF≈3.7 W/m². Logarítmica porque bandas de absorção já estão parcialmente saturadas.",
                Criador = "Myhre et al. / IPCC",
                AnoOrigin = "1998",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "C (ppm)", Descricao = "CO₂ atual", ValorPadrao = 420 },
                    new() { Simbolo = "C0", Nome = "C₀ (ppm)", Descricao = "CO₂ referência", ValorPadrao = 280 },
                ],
                VariavelResultado = "ΔF (W/m²)",
                UnidadeResultado = "W/m²",
                Calcular = v => 5.35 * Math.Log(v["C"] / v["C0"])
            },
            new Formula
            {
                Id = "3_cl12", Nome = "Feedback Fator de Ganho", Categoria = "Ciências do Clima", SubCategoria = "Balanço Energético",
                Expressao = "ΔT = ΔT₀/(1-f);  f = Σfᵢ  (feedbacks)",
                ExprTexto = "ΔT = ΔT₀/(1−f);  f = Σfᵢ",
                Icone = "f",
                Descricao = "Feedbacks amplificam (f>0) ou atenuam (f<0) o aquecimento direto ΔT₀. Vapor d'água f≈+0.6; gelo-albedo f≈+0.1; nuvens f≈+0.0-0.3 (maior incerteza).",
                Criador = "Ciência do sistema climático",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Delta", Nome = "Delta", ValorPadrao = 1 }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Delta"] + vars["T"]
            },
            new Formula
            {
                Id = "3_cl13", Nome = "Lei de Stefan-Boltzmann (Emissão)", Categoria = "Ciências do Clima", SubCategoria = "Balanço Energético",
                Expressao = "F_emitida = εσT⁴;  σ = 5.67×10⁻⁸ W/(m²K⁴)",
                ExprTexto = "F = εσT⁴",
                Icone = "σT⁴",
                Descricao = "Emissão térmica total de corpo negro/cinza. Terra emite ~240 W/m² (Te≈255K), superfície ~390 W/m² (Ts≈288K). Diferença = efeito estufa.",
                Criador = "Josef Stefan / Ludwig Boltzmann",
                AnoOrigin = "1879/1884",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "F", Nome = "F", ValorPadrao = 1 }, new() { Simbolo = "epsilon", Nome = "epsilon", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["F"] + vars["epsilon"]
            },
            new Formula
            {
                Id = "3_cl14", Nome = "Efeito Estufa", Categoria = "Ciências do Clima", SubCategoria = "Balanço Energético",
                Expressao = "ΔT_estufa = Ts - Te ≈ 288-255 = 33K",
                ExprTexto = "Ts − Te ≈ 33 K (efeito estufa natural)",
                Icone = "🏠",
                Descricao = "Atmosfera absorve e reemite radiação infravermelha, aquecendo a superfície ~33K acima da temperatura de equilíbrio sem atmosfera. Sem efeito estufa: Terra congelada.",
                Criador = "Joseph Fourier / Svante Arrhenius",
                AnoOrigin = "1824/1896",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Ts", Nome = "Ts", ValorPadrao = 1 }, new() { Simbolo = "Te", Nome = "Te", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Ts"] + vars["Te"]
            },
            // 21.3 Ondas Atmosféricas
            new Formula
            {
                Id = "3_cl15", Nome = "Ondas de Rossby (Planetárias)", Categoria = "Ciências do Clima", SubCategoria = "Ondas Atmosféricas",
                Expressao = "c = ū - β/(k²+l²)",
                ExprTexto = "c = ū − β/(k²+l²)",
                Icone = "🌊",
                Descricao = "Ondas de grande escala devidas ao gradiente de Coriolis (β=df/dy). Propagam para oeste relativamente ao fluxo médio. Dominam a variabilidade meteorológica de latitudes médias.",
                Criador = "Carl-Gustaf Rossby",
                AnoOrigin = "1939",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "ū", Nome = "ū", ValorPadrao = 10 }, new() { Simbolo = "β", Nome = "β", ValorPadrao = 5 } ],
                VariavelResultado = "c",
                UnidadeResultado = "",
                Calcular = vars => vars["ū"] - vars["β"]
            },
            new Formula
            {
                Id = "3_cl16", Nome = "Ondas de Kelvin Equatoriais", Categoria = "Ciências do Clima", SubCategoria = "Ondas Atmosféricas",
                Expressao = "c = √(gH) (propagam para leste sem componente meridional)",
                ExprTexto = "c = √(gH);  v=0;  decaem com |y|",
                Icone = "K",
                Descricao = "Ondas equatoriais aprisionadas que propagam para leste a √(gH). Sem velocidade meridional; decaem exponencialmente com latitude. Papel central no ENSO.",
                Criador = "Lord Kelvin / Teoria equatorial",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "3_cl17", Nome = "ENSO (Índice ONI)", Categoria = "Ciências do Clima", SubCategoria = "Ondas Atmosféricas",
                Expressao = "ONI = SST_anomaly(Niño 3.4);  El Niño: ONI≥+0.5°C por 5 meses",
                ExprTexto = "ONI = ΔSSTo(Niño 3.4);  El Niño: ONI≥+0.5°C",
                Icone = "ENSO",
                Descricao = "El Niño-Southern Oscillation: interação oceano-atmosfera no Pacífico tropical. Maior fonte de variabilidade interanual. El Niño aquece; La Niña resfria. Ciclo 2-7 anos.",
                Criador = "Jacob Bjerknes / Gilbert Walker",
                AnoOrigin = "1969/1924",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "ONI", Nome = "ONI", ValorPadrao = 1 }, new() { Simbolo = "Delta", Nome = "Delta", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["ONI"] + vars["Delta"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 22. BIOINFORMÁTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarBioinformatica()
    {
        _formulas.AddRange([
            // 22.1 Alinhamento de Sequências
            new Formula
            {
                Id = "3_bi01", Nome = "Needleman-Wunsch (Global)", Categoria = "Bioinformática", SubCategoria = "Alinhamento de Sequências",
                Expressao = "F(i,j) = max{F(i-1,j-1)+s(aᵢ,bⱼ), F(i-1,j)-d, F(i,j-1)-d}",
                ExprTexto = "F(i,j) = max{F(i−1,j−1)+s, F(i−1,j)−d, F(i,j−1)−d}",
                Icone = "NW",
                Descricao = "Alinhamento global ótimo por programação dinâmica. O(nm) tempo e espaço. s(a,b)=score de match/mismatch, d=penalidade de gap. Traceback reconstrói alinhamento.",
                Criador = "Saul Needleman / Christian Wunsch",
                AnoOrigin = "1970",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_bi02", Nome = "Smith-Waterman (Local)", Categoria = "Bioinformática", SubCategoria = "Alinhamento de Sequências",
                Expressao = "F(i,j) = max{0, F(i-1,j-1)+s, F(i-1,j)-d, F(i,j-1)-d}",
                ExprTexto = "F(i,j) = max{0, NW-termos}",
                Icone = "SW",
                Descricao = "Alinhamento local ótimo: permite início e fim em qualquer posição (máximo da matriz F). Identifica domínios conservados dentro de sequências divergentes.",
                Criador = "Temple Smith / Michael Waterman",
                AnoOrigin = "1981",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_bi03", Nome = "BLAST (Heurístico)", Categoria = "Bioinformática", SubCategoria = "Alinhamento de Sequências",
                Expressao = "Semeia palavras de comprimento w → estende hits → reporta E-value < limiar",
                ExprTexto = "Seeds → extend → E-value < threshold",
                Icone = "BLAST",
                Descricao = "Basic Local Alignment Search Tool: busca rápida em bancos de dados. Heurística (~1000× mais rápido que S-W). E-value = hits esperados ao acaso. BLAST = ferramenta mais usada em bioinformática.",
                Criador = "Stephen Altschul et al.",
                AnoOrigin = "1990",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_bi04", Nome = "E-value (BLAST)", Categoria = "Bioinformática", SubCategoria = "Alinhamento de Sequências",
                Expressao = "E = K·m·n·e^(-λS)",
                ExprTexto = "E = Kmn·e^(−λS)",
                Icone = "E",
                Descricao = "Número esperado de alinhamentos com score ≥ S ao acaso. E<10⁻⁵ geralmente significativo. K,λ dependem da matriz de substituição e composição do banco.",
                Criador = "Karlin & Altschul",
                AnoOrigin = "1990",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Kmn", Nome = "Kmn", ValorPadrao = 5 }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 3 } ],
                VariavelResultado = "E",
                UnidadeResultado = "",
                Calcular = vars => vars["Kmn"] * vars["e"]
            },
            new Formula
            {
                Id = "3_bi05", Nome = "Matriz de Substituição BLOSUM62", Categoria = "Bioinformática", SubCategoria = "Alinhamento de Sequências",
                Expressao = "s(a,b) = log₂(p(a,b)/(qₐqᵦ))",
                ExprTexto = "s(a,b) = log₂(pab/(qa·qb))",
                Icone = "BLOSUM",
                Descricao = "Odds-ratio de frequências observadas vs esperadas de pares de aminoácidos em blocos conservados a 62% identidade. Score positivo = par mais frequente que ao acaso.",
                Criador = "Steven Henikoff / Jorja Henikoff",
                AnoOrigin = "1992",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "3_bi06", Nome = "Gap Afim", Categoria = "Bioinformática", SubCategoria = "Alinhamento de Sequências",
                Expressao = "Penalidade = d + e(L-1)  (d=abertura, e=extensão)",
                ExprTexto = "Gap cost = d + e(L−1)",
                Icone = "gap",
                Descricao = "Modelo de gap afim: abertura d é cara (ex.: -11), extensão e é barata (ex.: -1). Mais biologicamente realista que gap linear (uma deleção longa = um evento).",
                Criador = "Gotoh (modelo afim)",
                AnoOrigin = "1982",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "d", Nome = "d", ValorPadrao = 10 }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 5 } ],
                VariavelResultado = "cost",
                UnidadeResultado = "",
                Calcular = vars => vars["d"] + vars["e"]
            },
            new Formula
            {
                Id = "3_bi07", Nome = "Alinhamento Múltiplo (MSA)", Categoria = "Bioinformática", SubCategoria = "Alinhamento de Sequências",
                Expressao = "Exato: O(Lⁿ) → heurísticas progressivas (ClustalW, MUSCLE)",
                ExprTexto = "MSA: NP-hard exato → heurísticas",
                Icone = "MSA",
                Descricao = "Alinhar n≥3 sequências simultaneamente. NP-hard exato. ClustalW: guia por árvore (progressivo). MUSCLE/MAFFT: iterativo. Identifica resíduos conservados para análise funcional.",
                Criador = "ClustalW (Thompson et al.)",
                AnoOrigin = "1994",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            // 22.2 Filogenética
            new Formula
            {
                Id = "3_bi08", Nome = "Modelo de Jukes-Cantor", Categoria = "Bioinformática", SubCategoria = "Filogenética",
                Expressao = "d = -3/4·ln(1-4p/3)",
                ExprTexto = "d = −¾ ln(1−4p/3)",
                Icone = "JC69",
                Descricao = "Distância evolutiva corrigida por múltiplas substituições. p = fração de sítios diferentes. Modelo mais simples: todas as substituições têm mesma taxa. Subestima saturação.",
                Criador = "Thomas Jukes / Charles Cantor",
                AnoOrigin = "1969",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "3_bi09", Nome = "Neighbor-Joining", Categoria = "Bioinformática", SubCategoria = "Filogenética",
                Expressao = "Agrupa pares com menor distância corrigida iterativamente → árvore",
                ExprTexto = "NJ: aglomera pares de menor Q iterativamente",
                Icone = "NJ",
                Descricao = "Algoritmo O(n³) para construir árvore filogenética a partir de matriz de distâncias. Não assume relógio molecular. Rápido e bom para árvores iniciais.",
                Criador = "Naruya Saitou / Masatoshi Nei",
                AnoOrigin = "1987",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_bi10", Nome = "Máxima Verossimilhança (Filogenética)", Categoria = "Bioinformática", SubCategoria = "Filogenética",
                Expressao = "L(T) = ∏_sítios P(dados_sítio | árvore T, modelo)",
                ExprTexto = "L(T) = ∏ₛ P(Dₛ|T,θ)",
                Icone = "ML",
                Descricao = "Encontra árvore T e parâmetros θ que maximizam a probabilidade dos dados. Estatisticamente consistente. Computacionalmente caro: O(n²ˢ) por sítio. RAxML, IQ-TREE.",
                Criador = "Joseph Felsenstein",
                AnoOrigin = "1981",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_bi11", Nome = "Bootstrap Filogenético", Categoria = "Bioinformática", SubCategoria = "Filogenética",
                Expressao = "Reamostrar sítios com reposição → reconstruir árvore → contar proporção de vezes que cada clado aparece",
                ExprTexto = "Reamostrar colunas → rebuild tree × 1000",
                Icone = "BS",
                Descricao = "Suporte de bootstrap: % de vezes que clado aparece em 1000+ pseudoréplicas. ≥70% é frequentemente considerado suporte 'bom'. Padrão de fato para confiança em filogenias.",
                Criador = "Joseph Felsenstein",
                AnoOrigin = "1985",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            // 22.3 Dinâmica Evolutiva
            new Formula
            {
                Id = "3_ev01", Nome = "Equação do Replicador", Categoria = "Bioinformática", SubCategoria = "Dinâmica Evolutiva",
                Expressao = "ẋᵢ = xᵢ(fᵢ - f̄);  f̄ = Σxⱼfⱼ",
                ExprTexto = "ẋᵢ = xᵢ(fᵢ−f̄)",
                Icone = "R",
                Descricao = "Frequência xᵢ cresce se fitness fᵢ > média f̄. Dinâmica sem mutação. Ligação com teoria dos jogos evolucionária: payoff ↔ fitness.",
                Criador = "Peter Taylor / Leo Jonker",
                AnoOrigin = "1978",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_ev02", Nome = "Equação de Fisher (Genética)", Categoria = "Bioinformática", SubCategoria = "Dinâmica Evolutiva",
                Expressao = "dw̄/dt = Var(w) = σ²_w",
                ExprTexto = "dw̄/dt = Var(w)",
                Icone = "F",
                Descricao = "Teorema fundamental de Fisher: taxa de aumento do fitness médio é igual à variância genética de fitness. Mais variação → evolução mais rápida.",
                Criador = "Ronald A. Fisher",
                AnoOrigin = "1930",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_ev03", Nome = "Equação de Price", Categoria = "Bioinformática", SubCategoria = "Dinâmica Evolutiva",
                Expressao = "Δz̄ = Cov(w,z)/w̄ + E(wΔz)/w̄",
                ExprTexto = "Δz̄ = Cov(w,z)/w̄ + E(wΔz)/w̄",
                Icone = "P",
                Descricao = "Mudança na média de traço z: seleção (covariância fitness-traço) + transmissão (mudança intra-indivíduo). Unifica seleção, drift, mutação. Muito geral.",
                Criador = "George R. Price",
                AnoOrigin = "1970",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_ev04", Nome = "Equilíbrio de Hardy-Weinberg", Categoria = "Bioinformática", SubCategoria = "Dinâmica Evolutiva",
                Expressao = "p² + 2pq + q² = 1  (AA, Aa, aa);  p+q=1",
                ExprTexto = "p²+2pq+q²=1 (genótipos)",
                Icone = "HW",
                Descricao = "Sem seleção, mutação, migração, drift → frequências genotípicas estáveis após 1 geração. Desvios indicam evolução atuando. Base de genética populacional.",
                Criador = "G.H. Hardy / Wilhelm Weinberg",
                AnoOrigin = "1908",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_ev05", Nome = "Deriva Genética (Modelo de Wright-Fisher)", Categoria = "Bioinformática", SubCategoria = "Dinâmica Evolutiva",
                Expressao = "P(k | n, p) = C(2N,k)·p^k·(1-p)^(2N-k)",
                ExprTexto = "X ~ Binomial(2N, p) (deriva)",
                Icone = "WF",
                Descricao = "Em população de tamanho N, frequências alélicas flutuam ao acaso (amostragem binomial). Alelo neutro fixa em ~4N gerações. Drift domina quando s < 1/(2N).",
                Criador = "Sewall Wright / Ronald Fisher",
                AnoOrigin = "~1930",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_ev06", Nome = "Relógio Molecular", Categoria = "Bioinformática", SubCategoria = "Dinâmica Evolutiva",
                Expressao = "d = 2μt  (d = divergência, μ = taxa, t = tempo)",
                ExprTexto = "d = 2μt",
                Icone = "🕐",
                Descricao = "Se taxa de substituição μ é constante, divergência entre sequências é proporcional ao tempo de separação. Calibrado com fósseis. Permite datar divergências sem registro fóssil.",
                Criador = "Emile Zuckerkandl / Linus Pauling",
                AnoOrigin = "1965",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            // 22.4 Biologia de Sistemas
            new Formula
            {
                Id = "3_bs01", Nome = "Flux Balance Analysis (FBA)", Categoria = "Bioinformática", SubCategoria = "Biologia de Sistemas",
                Expressao = "max c'v  s.a.  S·v=0, vₘᵢₙ≤v≤vₘₐₓ",
                ExprTexto = "max c'v  s.a.  Sv=0, vmin≤v≤vmax",
                Icone = "FBA",
                Descricao = "Otimização linear para prever fluxos metabólicos no estado estacionário. S = matriz estequiométrica (m×n), v = fluxos. Objetivo típico: maximizar crescimento. Sem parâmetros cinéticos!",
                Criador = "Bernhard Palsson / Jeremy Edwards",
                AnoOrigin = "~2000",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
            new Formula
            {
                Id = "3_bs02", Nome = "Modelo de Lotka-Volterra", Categoria = "Bioinformática", SubCategoria = "Biologia de Sistemas",
                Expressao = "dx/dt = αx - βxy;  dy/dt = δxy - γy",
                ExprTexto = "ẋ = αx−βxy;  ẏ = δxy−γy",
                Icone = "LV",
                Descricao = "Predador-presa: presa x cresce exponencialmente, é reduzida por predação βxy. Predador y cresce com predação δxy, morre γy. Oscilações perpétuas (sem atrito).",
                Criador = "Alfred Lotka / Vito Volterra",
                AnoOrigin = "1925/1926",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "αx", Nome = "αx", ValorPadrao = 10 }, new() { Simbolo = "βxy", Nome = "βxy", ValorPadrao = 5 } ],
                VariavelResultado = "ẋ",
                UnidadeResultado = "",
                Calcular = vars => vars["αx"] - vars["βxy"]
            },
            new Formula
            {
                Id = "3_bs03", Nome = "Equação de Hill (Cooperatividade)", Categoria = "Bioinformática", SubCategoria = "Biologia de Sistemas",
                Expressao = "Y = [S]ⁿ/(K_d^n + [S]ⁿ)",
                ExprTexto = "Y = [S]ⁿ/(Kd^n+[S]ⁿ)",
                Icone = "Hill",
                Descricao = "Fração de ligação com cooperatividade. n=1: Michaelis-Menten. n>1: cooperatividade positiva (sigmoidal, como hemoglobina n≈2.8). n<1: cooperatividade negativa. Switch biológico.",
                Criador = "Archibald Hill",
                AnoOrigin = "1910",
                Variaveis = [
                    new() { Simbolo = "S", Nome = "[S] (concentração)", ValorPadrao = 5 },
                    new() { Simbolo = "Kd", Nome = "Kd", ValorPadrao = 10 },
                    new() { Simbolo = "n", Nome = "n (Hill)", ValorPadrao = 2.8, ValorMin = 0.1 },
                ],
                VariavelResultado = "Y (fração)",
                Calcular = v => Math.Pow(v["S"], v["n"]) / (Math.Pow(v["Kd"], v["n"]) + Math.Pow(v["S"], v["n"]))
            },
            new Formula
            {
                Id = "3_bs04", Nome = "Bistabilidade (Toggle Switch)", Categoria = "Bioinformática", SubCategoria = "Biologia de Sistemas",
                Expressao = "du/dt = α₁/(1+vⁿ) - u;  dv/dt = α₂/(1+uⁿ) - v",
                ExprTexto = "u̇ = α₁/(1+vⁿ)−u;  v̇ = α₂/(1+uⁿ)−v",
                Icone = "⇌",
                Descricao = "Dois repressores que se inibem mutuamente formam um interruptor biestável. Modelo de Gardner (2000): epigenética, diferenciação celular, memória celular.",
                Criador = "Timothy Gardner / James Collins",
                AnoOrigin = "2000",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = _ => double.NaN
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 23. ACÚSTICA E VIBROACÚSTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarAcustica()
    {
        _formulas.AddRange([
            // 23.1 Acústica Fundamental
            new Formula
            {
                Id = "3_ac01", Nome = "Equação da Onda Acústica", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "∇²p - (1/c²)∂²p/∂t² = 0",
                ExprTexto = "∇²p − (1/c²)∂²p/∂t² = 0",
                Icone = "♪",
                Descricao = "Equação de onda para pressão acústica p. Linearização das equações de Euler. Válida para pequenas perturbações. c = velocidade do som no meio.",
                Criador = "Jean le Rond d'Alembert / Leonhard Euler",
                AnoOrigin = "1747/1757",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] + vars["y"]
            },
            new Formula
            {
                Id = "3_ac02", Nome = "Velocidade do Som (Gás Ideal)", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "c = √(γRT/M) = √(γp/ρ)",
                ExprTexto = "c = √(γRT/M)",
                Icone = "c",
                Descricao = "Velocidade do som em gás ideal: ar~343 m/s (20°C), He~1007, CO₂~259. Aumenta com √T (não depende de pressão em gás ideal). γ = razão de calores específicos.",
                Criador = "Isaac Newton / Pierre-Simon Laplace",
                AnoOrigin = "1687/1816",
                Variaveis = [
                    new() { Simbolo = "gamma", Nome = "γ (cp/cv)", ValorPadrao = 1.4 },
                    new() { Simbolo = "R", Nome = "R (J/(mol·K))", ValorPadrao = 8.314 },
                    new() { Simbolo = "T", Nome = "T (K)", ValorPadrao = 293.15 },
                    new() { Simbolo = "M", Nome = "M (kg/mol)", ValorPadrao = 0.029 },
                ],
                VariavelResultado = "c (m/s)",
                UnidadeResultado = "m/s",
                Calcular = v => Math.Sqrt(v["gamma"] * v["R"] * v["T"] / v["M"])
            },
            new Formula
            {
                Id = "3_ac03", Nome = "Impedância Acústica", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "Z = ρc  (Pa·s/m = Rayl)",
                ExprTexto = "Z = ρc",
                Icone = "Z",
                Descricao = "Resistência do meio à propagação de onda. Ar: 415 Rayl; Água: 1.5×10⁶ Rayl. Grande descasamento → reflexão (ar-água reflete ~99.9% da energia).",
                Criador = "Acústica clássica",
                Variaveis = [
                    new() { Simbolo = "rho", Nome = "ρ (kg/m³)", ValorPadrao = 1.225 },
                    new() { Simbolo = "c", Nome = "c (m/s)", ValorPadrao = 343 },
                ],
                VariavelResultado = "Z (Pa·s/m)",
                UnidadeResultado = "Pa·s/m",
                Calcular = v => v["rho"] * v["c"]
            },
            new Formula
            {
                Id = "3_ac04", Nome = "Nível de Pressão Sonora (SPL)", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "Lp = 20·log₁₀(p/p₀) dB;  p₀ = 20 μPa",
                ExprTexto = "Lp = 20·log₁₀(p/p₀) dB",
                Icone = "dB",
                Descricao = "Escala logarítmica de pressão sonora. 0 dB = limiar de audição. 60 dB conversa. 120 dB = dor. Ouvido tem faixa dinâmica de ~120 dB (10⁶ em pressão, 10¹² em potência).",
                Criador = "Alexander Graham Bell (unidade)",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "p (Pa)", Descricao = "Pressão sonora RMS", ValorPadrao = 0.02 },
                    new() { Simbolo = "p0", Nome = "p₀ (Pa)", Descricao = "Referência (20 μPa)", ValorPadrao = 2e-5 },
                ],
                VariavelResultado = "Lp (dB SPL)",
                UnidadeResultado = "dB",
                Calcular = v => 20 * Math.Log10(v["p"] / v["p0"])
            },
            new Formula
            {
                Id = "3_ac05", Nome = "Nível de Potência Sonora", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "Lw = 10·log₁₀(W/W₀) dB;  W₀ = 10⁻¹² W",
                ExprTexto = "Lw = 10·log₁₀(W/W₀) dB",
                Icone = "Lw",
                Descricao = "Propriedade da fonte (independente de distância). Voz normal ~60 dB, avião a jato ~160 dB. Relaciona com Lp pela diretividade e distância.",
                Criador = "Acústica",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "10", Nome = "10", ValorPadrao = 5 }, new() { Simbolo = "log₁₀", Nome = "log₁₀", ValorPadrao = 3 } ],
                VariavelResultado = "Lw",
                UnidadeResultado = "",
                Calcular = vars => vars["10"] * vars["log₁₀"]
            },
            new Formula
            {
                Id = "3_ac06", Nome = "Lei do Inverso do Quadrado", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "Lp(r₂) = Lp(r₁) - 20·log₁₀(r₂/r₁)",
                ExprTexto = "Lp(r₂) = Lp(r₁)−20log₁₀(r₂/r₁)",
                Icone = "1/r²",
                Descricao = "Fonte pontual em campo livre: -6 dB por dobro de distância. Fonte linear: -3 dB/dobro (decai como 1/r). Válida longe de superfícies refletoras.",
                Criador = "Acústica de campo livre",
                Variaveis = [
                    new() { Simbolo = "Lp1", Nome = "Lp(r₁) (dB)", ValorPadrao = 80 },
                    new() { Simbolo = "r1", Nome = "r₁ (m)", ValorPadrao = 1 },
                    new() { Simbolo = "r2", Nome = "r₂ (m)", ValorPadrao = 2 },
                ],
                VariavelResultado = "Lp(r₂) (dB)",
                UnidadeResultado = "dB",
                Calcular = v => v["Lp1"] - 20 * Math.Log10(v["r2"] / v["r1"])
            },
            new Formula
            {
                Id = "3_ac07", Nome = "Soma de Níveis de Pressão Sonora", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "Lp_total = 10·log₁₀(Σ 10^(Lpi/10))",
                ExprTexto = "Lp_total = 10·log₁₀(Σ10^(Lpᵢ/10))",
                Icone = "Σ dB",
                Descricao = "Soma de fontes incoerentes: somar potências (não dB). Duas fontes iguais → +3 dB. 10 fontes iguais → +10 dB. Regra prática: diferença ≥10 dB → fonte menor desprezível.",
                Criador = "Acústica",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "10", Nome = "10", ValorPadrao = 5 }, new() { Simbolo = "log₁₀", Nome = "log₁₀", ValorPadrao = 3 } ],
                VariavelResultado = "Lp_total",
                UnidadeResultado = "",
                Calcular = vars => vars["10"] * vars["log₁₀"]
            },
            new Formula
            {
                Id = "3_ac08", Nome = "Ponderação A (dBA)", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica Fundamental",
                Expressao = "LA = Lp + A(f)  (curva A de ponderação frequencial)",
                ExprTexto = "LA = Lp + A(f) dBA",
                Icone = "dBA",
                Descricao = "Filtro que simula resposta do ouvido humano: atenua baixas (<500 Hz) e altas (>6 kHz) frequências. dBA é a unidade de medição de ruído ambiental/ocupacional.",
                Criador = "IEC / ISO",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Lp", Nome = "Lp", ValorPadrao = 10 }, new() { Simbolo = "A", Nome = "A", ValorPadrao = 5 } ],
                VariavelResultado = "LA",
                UnidadeResultado = "",
                Calcular = vars => vars["Lp"] + vars["A"]
            },
            // 23.2 Acústica de Salas
            new Formula
            {
                Id = "3_ac09", Nome = "Tempo de Reverberação (Sabine)", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica de Salas",
                Expressao = "T₆₀ = 0.161V/A;  A = Σ αᵢSᵢ",
                ExprTexto = "T₆₀ = 0.161V/A",
                Icone = "T60",
                Descricao = "Tempo para som decair 60 dB após fonte parar. V=volume (m³), A=absorção total (m² Sabine). Sala de concerto: T≈1.5-2s. Estúdio: T≈0.3-0.5s. Fórmula de Sabine (salas pouco absorventes).",
                Criador = "Wallace Clement Sabine",
                AnoOrigin = "1898",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "V (m³)", Descricao = "Volume da sala", ValorPadrao = 500 },
                    new() { Simbolo = "A", Nome = "A (m² Sabine)", Descricao = "Absorção total", ValorPadrao = 50 },
                ],
                VariavelResultado = "T₆₀ (s)",
                UnidadeResultado = "s",
                Calcular = v => 0.161 * v["V"] / v["A"]
            },
            new Formula
            {
                Id = "3_ac10", Nome = "Fórmula de Eyring", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica de Salas",
                Expressao = "T₆₀ = 0.161V/(-S·ln(1-ᾱ))",
                ExprTexto = "T₆₀ = 0.161V/(−S·ln(1−ᾱ))",
                Icone = "Eyr",
                Descricao = "Mais precisa que Sabine para salas com alta absorção (ᾱ→1). Para Sabine: ln(1−ᾱ)≈-ᾱ. Converge para Sabine em ᾱ→0. Câmara anecóica: Eyring dá T≈0.",
                Criador = "Carl F. Eyring",
                AnoOrigin = "1930",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "3_ac11", Nome = "Distância Crítica", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica de Salas",
                Expressao = "dc = √(Q·A/(16π))",
                ExprTexto = "dc = √(QA/(16π))",
                Icone = "dc",
                Descricao = "Distância onde campo direto = campo reverberante. Dentro de dc: fonte domina (inteligibilidade boa). Fora: reverberação domina. Q = diretividade da fonte.",
                Criador = "Acústica de salas",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "3_ac12", Nome = "Inteligibilidade STI", Categoria = "Acústica e Vibroacústica", SubCategoria = "Acústica de Salas",
                Expressao = "STI ∈ [0,1]:  >0.6 bom;  >0.75 excelente",
                ExprTexto = "STI: 0→ruim, 0.6→bom, 1→perfeito",
                Icone = "STI",
                Descricao = "Speech Transmission Index: métrica objetiva de inteligibilidade da fala. Considera reverberação e ruído de fundo. Mede degradação do índice de modulação. Salas de aula: STI>0.6.",
                Criador = "Houtgast & Steeneken",
                AnoOrigin = "1971-1985",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "STI", Nome = "STI", ValorPadrao = 1 }, new() { Simbolo = "bom", Nome = "bom", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["STI"] + vars["bom"]
            },
            // 23.3 Vibrações Estruturais
            new Formula
            {
                Id = "3_vb01", Nome = "SDOF: Oscilador Amortecido", Categoria = "Acústica e Vibroacústica", SubCategoria = "Vibrações Estruturais",
                Expressao = "mẍ + cẋ + kx = F(t)",
                ExprTexto = "mẍ + cẋ + kx = F(t)",
                Icone = "SDOF",
                Descricao = "Sistema de 1 grau de liberdade (SDOF): massa m, amortecimento c, rigidez k. Modelo fundamental para vibrações. ζ=c/(2√(km)) = razão de amortecimento.",
                Criador = "Mecânica clássica",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "kx", Nome = "kx", ValorPadrao = 1 }, new() { Simbolo = "F", Nome = "F", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["kx"] + vars["F"]
            },
            new Formula
            {
                Id = "3_vb02", Nome = "Frequência Natural", Categoria = "Acústica e Vibroacústica", SubCategoria = "Vibrações Estruturais",
                Expressao = "f_n = (1/2π)√(k/m);  ω_n = √(k/m)",
                ExprTexto = "ωₙ = √(k/m);  fₙ = ωₙ/(2π)",
                Icone = "fₙ",
                Descricao = "Frequência em que o sistema oscila livremente. ωd = ωn√(1-ζ²) considerando amortecimento. Ressonância quando forçante = fn → amplificação máxima.",
                Criador = "Mecânica de vibrações",
                Variaveis = [
                    new() { Simbolo = "k", Nome = "k (N/m)", Descricao = "Rigidez", ValorPadrao = 10000 },
                    new() { Simbolo = "m", Nome = "m (kg)", ValorPadrao = 1 },
                ],
                VariavelResultado = "fₙ (Hz)",
                UnidadeResultado = "Hz",
                Calcular = v => Math.Sqrt(v["k"] / v["m"]) / (2 * Math.PI)
            },
            new Formula
            {
                Id = "3_vb03", Nome = "Fator de Amplificação (Ressonância)", Categoria = "Acústica e Vibroacústica", SubCategoria = "Vibrações Estruturais",
                Expressao = "Q = 1/(2ζ)  (amplificação na ressonância)",
                ExprTexto = "Q = 1/(2ζ)",
                Icone = "Q",
                Descricao = "Na ressonância (ω=ωn), amplitude multiplicada por Q=1/(2ζ). ζ=0.01 → Q=50 (estrutura de aço). ζ=0.05 → Q=10 (concreto). Q infinito sem amortecimento (impossível).",
                Criador = "Teoria de vibrações",
                Variaveis = [
                    new() { Simbolo = "zeta", Nome = "ζ (amortecimento)", ValorPadrao = 0.02, ValorMin = 0.001 },
                ],
                VariavelResultado = "Q (fator de qualidade)",
                Calcular = v => 1.0 / (2 * v["zeta"])
            },
            new Formula
            {
                Id = "3_vb04", Nome = "MDOF: Autovalores", Categoria = "Acústica e Vibroacústica", SubCategoria = "Vibrações Estruturais",
                Expressao = "(K - ωₙ²M)φ = 0;  det(K-ω²M)=0",
                ExprTexto = "(K−ωₙ²M)φ = 0",
                Icone = "MDOF",
                Descricao = "Sistema de múltiplos graus de liberdade: modos naturais são autovalores (ωₙ²) e autovetores (formas modais φ) do problema generalizado de autovalores.",
                Criador = "Lord Rayleigh / Teoria de vibrações",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "K", Nome = "K", ValorPadrao = 1 }, new() { Simbolo = "omega", Nome = "omega", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["K"] + vars["omega"]
            },
            new Formula
            {
                Id = "3_vb05", Nome = "Transferência Vibroacústica (FRF)", Categoria = "Acústica e Vibroacústica", SubCategoria = "Vibrações Estruturais",
                Expressao = "H(ω) = X(ω)/F(ω) = Σ φᵣφᵣᵀ/(ωᵣ²-ω²+2iζᵣωᵣω)",
                ExprTexto = "H(ω) = X/F = Σ φᵣ²/(ωᵣ²−ω²+j2ζᵣωᵣω)",
                Icone = "FRF",
                Descricao = "Função de Resposta em Frequência: soma sobre modos (superposição modal). Cada modo contribui com pico na ressonância ωᵣ. Fundamento de análise modal experimental.",
                Criador = "Análise modal / Teoria de vibrações",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "H", Nome = "H", ValorPadrao = 1 }, new() { Simbolo = "omega", Nome = "omega", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["H"] + vars["omega"]
            },
            new Formula
            {
                Id = "3_vb06", Nome = "Potência Sonora Radiada", Categoria = "Acústica e Vibroacústica", SubCategoria = "Vibrações Estruturais",
                Expressao = "W = ρcSσ_rad⟨v²⟩",
                ExprTexto = "W = ρcSσ_rad⟨v²⟩",
                Icone = "W",
                Descricao = "Potência sonora de estrutura vibrante: σ_rad = eficiência de radiação (0 a ~1). Depende da frequência, tamanho e condições de contorno. Controle de ruído: reduzir v² ou σ_rad.",
                Criador = "Vibroacústica / Lord Rayleigh",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "W", Nome = "W", ValorPadrao = 1 }, new() { Simbolo = "rho", Nome = "rho", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["W"] + vars["rho"]
            },
        ]);
    }
}
