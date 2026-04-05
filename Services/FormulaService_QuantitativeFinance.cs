using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE IX
    /// FINANÇAS QUANTITATIVAS AVANÇADAS
    /// Fórmulas V10-161 a V10-180 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_QuantFinance()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3749",
                    CodigoCompendio = "V10-161",
                    Nome = "Black-Scholes — Preço de Opção",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Precificação de Derivativos",
                    Expressao = @"C = S₀N(d₁) − Ke^(−rT)N(d₂)",
                    Descricao = "Preço call europeia. d₁=(ln(S₀/K)+(r+σ²/2)T)/(σ√T). N: distribuição normal acumulada.",
                    ExemploPratico = "S₀=$100, K=$100, r=5%, σ=20%, T=1yr: C≈$10.45. Put-call parity: P=C−S₀+Ke^(−rT).",
                    Criador = "Black e Scholes (1973, JPE); Merton (1973, Nobel 1997)",
                    AnoOrigin = "1973",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "S₀ Preço ativo", Simbolo = "S₀", Unidade = "$", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Strike K", Simbolo = "K", Unidade = "$", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Taxa r (%)", Simbolo = "r", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Volatilidade σ (%)", Simbolo = "σ", Unidade = "%", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tempo T (anos)", Simbolo = "T", Unidade = "anos", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double S0 = inputs["S₀ Preço ativo"];
                        double K = inputs["Strike K"];
                        double r = inputs["Taxa r (%)"] / 100.0;
                        double sigma = inputs["Volatilidade σ (%)"] / 100.0;
                        double T = inputs["Tempo T (anos)"];
                        
                        if (T <= 0) return S0 - K;
                        
                        double d1 = (Math.Log(S0 / K) + (r + sigma * sigma / 2) * T) / (sigma * Math.Sqrt(T));
                        double d2 = d1 - sigma * Math.Sqrt(T);
                        
                        // Aproximação normal cumulativa
                        Func<double, double> N = x =>
                        {
                            double a = 0.3193815;
                            double b = -0.3565638;
                            double c = 1.7814779;
                            double d = -1.8212560;
                            double e = 1.3302744;
                            double p = 0.2316419;
                            double t = 1.0 / (1.0 + p * Math.Abs(x));
                            double z = Math.Exp(-x * x / 2) / Math.Sqrt(2 * Math.PI);
                            double y = 1 - z * (a * t + b * t * t + c * t * t * t + d * t * t * t * t + e * t * t * t * t * t);
                            return (x >= 0) ? y : 1 - y;
                        };
                        
                        double C = S0 * N(d1) - K * Math.Exp(-r * T) * N(d2);
                        return C;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-162: Delta de Opção
                new Formula
                {
                    Id = "3750",
                    CodigoCompendio = "V10-162",
                    Nome = "Delta de Opção (∂C/∂S)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Greeks",
                    Expressao = @"Δ_call = N(d₁); Δ_put = N(d₁) − 1",
                    Descricao = "Sensibilidade preço opção ao preço ativo. Δ=0.5: at-the-money. Delta hedging: portfolio neutral (Δ_port=0).",
                    ExemploPratico = "Call ATM: Δ≈0.5. Deep ITM call: Δ→1. OTM call: Δ→0. Market makers: hedging dinâmico. Delta-neutral: lucro gamma/theta.",
                    Criador = "Black-Scholes-Merton (1973, derivadas implícitas)",
                    AnoOrigin = "1973",
                    VariavelResultado = "Δ_call",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "S₀", Simbolo = "S0", Unidade = "$", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "K", Simbolo = "K", Unidade = "$", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "r (%)", Simbolo = "r", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ (%)", Simbolo = "sigma", Unidade = "%", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "T (anos)", Simbolo = "T", Unidade = "anos", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double S0 = inputs["S₀"];
                        double K = inputs["K"];
                        double r = inputs["r (%)"] / 100;
                        double sigma = inputs["σ (%)"] / 100;
                        double T = inputs["T (anos)"];
                        
                        if (T <= 0) return (S0 > K) ? 1 : 0;
                        
                        double d1 = (Math.Log(S0 / K) + (r + sigma * sigma / 2) * T) / (sigma * Math.Sqrt(T));
                        
                        Func<double, double> N = x =>
                        {
                            double p = 0.2316419, a1 = 0.319382, a2 = -0.356563, a3 = 1.781478, a4 = -1.821256, a5 = 1.330274;
                            double t = 1 / (1 + p * Math.Abs(x));
                            double z = Math.Exp(-x * x / 2) / Math.Sqrt(2 * Math.PI);
                            double y = 1 - z * (a1 * t + a2 * t * t + a3 * Math.Pow(t, 3) + a4 * Math.Pow(t, 4) + a5 * Math.Pow(t, 5));
                            return (x >= 0) ? y : 1 - y;
                        };
                        
                        double delta_call = N(d1);
                        return delta_call;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-163: Value at Risk (VaR)
                new Formula
                {
                    Id = "3751",
                    CodigoCompendio = "V10-163",
                    Nome = "Value at Risk (VaR)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Gestão de Risco",
                    Expressao = @"VaR_α = μP − z_α·σP",
                    Descricao = "Perda máxima com confiança α (ex: 95%, 99%). z_α: quantil normal. Portfolio μ retorno, σ volatilidade. Basel III: VaR 99% 10-day.",
                    ExemploPratico = "Portfolio $10M, μ=8%/ano, σ=15%/ano: VaR_95%_1day≈0.15·$10M/√252·1.645≈$98k. VaR_99%≈$147k. 2008: falhou (fat tails, não-Gaussiano).",
                    Criador = "RiskMetrics (J.P. Morgan 1994); Till Guldimann",
                    AnoOrigin = "1994",
                    VariavelResultado = "VaR",
                    UnidadeResultado = "$",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Portfolio P ($)", Simbolo = "P", Unidade = "$", ValorPadrao = 10e6, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "μ retorno anual (%)", Simbolo = "mu", Unidade = "%", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ volat anual (%)", Simbolo = "sigma", Unidade = "%", ValorPadrao = 15, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Confiança (%)", Simbolo = "alpha", Unidade = "%", ValorPadrao = 95, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Dias", Simbolo = "days", Unidade = "dias", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double P = inputs["Portfolio P ($)"];
                        double mu_annual = inputs["μ retorno anual (%)"] / 100;
                        double sigma_annual = inputs["σ volat anual (%)"] / 100;
                        double alpha_pct = inputs["Confiança (%)"];
                        double days = inputs["Dias"];
                        
                        // Scale to daily
                        double mu_daily = mu_annual / 252;
                        double sigma_daily = sigma_annual / Math.Sqrt(252);
                        
                        // Scale to days horizon
                        double mu = mu_daily * days;
                        double sigma = sigma_daily * Math.Sqrt(days);
                        
                        // Quantile mapping (approximate)
                        double z_alpha = 0;
                        if (alpha_pct >= 99) z_alpha = 2.326;
                        else if (alpha_pct >= 95) z_alpha = 1.645;
                        else if (alpha_pct >= 90) z_alpha = 1.282;
                        else z_alpha = 1.645;
                        
                        double VaR = P * (mu - z_alpha * sigma);
                        return -VaR; // positive VaR = loss
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-164: Sharpe Ratio
                new Formula
                {
                    Id = "3752",
                    CodigoCompendio = "V10-164",
                    Nome = "Sharpe Ratio",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Performance",
                    Expressao = @"SR = (R_p − R_f)/σ_p",
                    Descricao = "Retorno ajustado ao risco. R_p: retorno portfolio, R_f: risk-free, σ_p: volatilidade. SR>1: bom. SR>2: excelente. Sortino: usa downside deviation.",
                    ExemploPratico = "Hedge fund: R_p=15%/ano, R_f=2%, σ=10%→SR=1.3. S&P 500 histórico: SR≈0.4-0.5. Medallion Fund (Renaissance): SR~2-3 (lendário).",
                    Criador = "Sharpe (1966, Nobel 1990, capital asset pricing)",
                    AnoOrigin = "1966",
                    VariavelResultado = "SR",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R_p (%)", Simbolo = "Rp", Unidade = "%", ValorPadrao = 15, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "R_f (%)", Simbolo = "Rf", Unidade = "%", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ_p (%)", Simbolo = "sigma", Unidade = "%", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Rp = inputs["R_p (%)"];
                        double Rf = inputs["R_f (%)"];
                        double sigma = inputs["σ_p (%)"];
                        
                        if (sigma == 0) return 0;
                        double SR = (Rp - Rf) / sigma;
                        return SR;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-165: CAPM — Capital Asset Pricing Model
                new Formula
                {
                    Id = "3753",
                    CodigoCompendio = "V10-165",
                    Nome = "Modelo CAPM",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Precificação de Ativos",
                    Expressao = @"E(R_i) = R_f + β_i·(E(R_m) − R_f)",
                    Descricao = "Retorno esperado função do risco sistemático β. β>1: mais volátil que mercado. Security Market Line (SML). Fama-French: 3 fatores (size, value).",
                    ExemploPratico = "Tech stock: β=1.5, R_f=2%, E(R_m)=10%→E(R)=2%+1.5·8%=14%. β<1: defensive (utilities). β>1: aggressive (tech).",
                    Criador = "Sharpe (1964, Nobel 1990); Lintner (1965); Mossin (1966)",
                    AnoOrigin = "1964",
                    VariavelResultado = "E_Ri",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R_f (%)", Simbolo = "Rf", Unidade = "%", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "β_i", Simbolo = "beta", Unidade = "", ValorPadrao = 1.5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "E(R_m) (%)", Simbolo = "Rm", Unidade = "%", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Rf = inputs["R_f (%)"];
                        double beta = inputs["β_i"];
                        double Rm = inputs["E(R_m) (%)"];
                        
                        double E_Ri = Rf + beta * (Rm - Rf);
                        return E_Ri;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-166: Volatilidade Implícita
                new Formula
                {
                    Id = "3754",
                    CodigoCompendio = "V10-166",
                    Nome = "Volatilidade Implícita (Vega)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Derivativos",
                    Expressao = @"Vega = ∂C/∂σ = S₀·φ(d₁)·√T",
                    Descricao = "Sensibilidade ao σ. φ(x)=e^(-x²/2)/√(2π). Volatility smile: σ_impl(K) não-constante. VIX: implied vol S&P 500 options (fear index).",
                    ExemploPratico = "ATM 1yr option: Vega≈0.4 (≈40 cents per 1% vol). VIX~12: low vol, ~30: high (crash). 2020 COVID: VIX=82 (recorde).",
                    Criador = "Greeks Black-Scholes (anos 1970s); VIX (CBOE 1993)",
                    AnoOrigin = "1993",
                    VariavelResultado = "Vega",
                    UnidadeResultado = "$/σ",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "S₀", Simbolo = "S0", Unidade = "$", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "K", Simbolo = "K", Unidade = "$", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "r (%)", Simbolo = "r", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ (%)", Simbolo = "sigma", Unidade = "%", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "T (anos)", Simbolo = "T", Unidade = "anos", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double S0 = inputs["S₀"];
                        double K = inputs["K"];
                        double r = inputs["r (%)"] / 100;
                        double sigma = inputs["σ (%)"] / 100;
                        double T = inputs["T (anos)"];
                        
                        if (T <= 0) return 0;
                        
                        double d1 = (Math.Log(S0 / K) + (r + sigma * sigma / 2) * T) / (sigma * Math.Sqrt(T));
                        double phi_d1 = Math.Exp(-d1 * d1 / 2) / Math.Sqrt(2 * Math.PI);
                        
                        double vega = S0 * phi_d1 * Math.Sqrt(T) / 100; // per 1% vol
                        return vega;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-167: Modelo Binomial (Cox-Ross-Rubinstein)
                new Formula
                {
                    Id = "3755",
                    CodigoCompendio = "V10-167",
                    Nome = "Modelo Binomial — Árvore de Preços",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Precificação Numérica",
                    Expressao = @"u=e^(σ√Δt); d=1/u; p=(e^(rΔt)−d)/(u−d)",
                    Descricao = "Discretização: n steps. Convergência Black-Scholes (n→∞). American options: exercício antecipado. Backward induction.",
                    ExemploPratico = "σ=20%, Δt=1/12 (monthly): u≈1.059, d≈0.944. n=100 steps: preciso <$0.01. Bermudan options: exercício em datas específicas.",
                    Criador = "Cox-Ross-Rubinstein (1979, JFE)",
                    AnoOrigin = "1979",
                    VariavelResultado = "u",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ (%)", Simbolo = "sigma", Unidade = "%", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Δt (anos)", Simbolo = "dt", Unidade = "anos", ValorPadrao = 1.0 / 12, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double sigma = inputs["σ (%)"] / 100;
                        double dt = inputs["Δt (anos)"];
                        
                        double u = Math.Exp(sigma * Math.Sqrt(dt));
                        return u;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-168: Duration de Macaulay
                new Formula
                {
                    Id = "3756",
                    CodigoCompendio = "V10-168",
                    Nome = "Duration de Macaulay",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Renda Fixa",
                    Expressao = @"D = Σ(t·CF_t·e^(-yt))/P",
                    Descricao = "Prazo médio ponderado dos fluxos. Modified duration: D_mod=D/(1+y). Convexity: segunda derivada. Immunization: D_asset=D_liability.",
                    ExemploPratico = "Bond 10yr, coupon 5%, yield 4%: D≈8.4 anos. ΔP/P≈−D_mod·Δy. Δy=+1%→ΔP≈−8%. Zero-coupon: D=maturity.",
                    Criador = "Macaulay (1938, bond duration); Redington (1952, immunization)",
                    AnoOrigin = "1938",
                    VariavelResultado = "D",
                    UnidadeResultado = "anos",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Maturity T (anos)", Simbolo = "T", Unidade = "anos", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Coupon c (%)", Simbolo = "c", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Yield y (%)", Simbolo = "y", Unidade = "%", ValorPadrao = 4, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double T = inputs["Maturity T (anos)"];
                        double c = inputs["Coupon c (%)"] / 100;
                        double y = inputs["Yield y (%)"] / 100;
                        
                        // Simplified: annual coupons + principal at maturity
                        double P = 0;
                        double weighted_sum = 0;
                        
                        for (int t = 1; t <= (int)T; t++)
                        {
                            double CF = c * 100; // annual coupon
                            if (t == (int)T) CF += 100; // principal
                            
                            double PV = CF * Math.Exp(-y * t);
                            P += PV;
                            weighted_sum += t * PV;
                        }
                        
                        if (P == 0) return T;
                        double D = weighted_sum / P;
                        return D;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-169: Modelo Vasicek (Taxa de Juros)
                new Formula
                {
                    Id = "3757",
                    CodigoCompendio = "V10-169",
                    Nome = "Modelo Vasicek — Taxa Estocástica",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Derivativos de Taxa de Juros",
                    Expressao = @"dr = a(b − r)dt + σ·dW",
                    Descricao = "Mean reversion: r→b (long-term). a: velocidade. Solução: r_t=r₀e^(-at)+b(1−e^(-at))+σ∫e^(-a(t-s))dW_s. Bonds: preço analítico.",
                    ExemploPratico = "a=0.1, b=5%, σ=2%, r₀=3%: E[r_1yr]≈3.9%, Var[r]→σ²/(2a). CIR model: σ√r (positivo). Hull-White: time-dependent b(t).",
                    Criador = "Vasicek (1977, J. Fin. Econ.)",
                    AnoOrigin = "1977",
                    VariavelResultado = "r_esperado",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "r₀ (%)", Simbolo = "r0", Unidade = "%", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "a", Simbolo = "a", Unidade = "", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "b (%)", Simbolo = "b", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (anos)", Simbolo = "t", Unidade = "anos", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double r0 = inputs["r₀ (%)"];
                        double a = inputs["a"];
                        double b = inputs["b (%)"];
                        double t = inputs["t (anos)"];
                        
                        double E_r = r0 * Math.Exp(-a * t) + b * (1 - Math.Exp(-a * t));
                        return E_r;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-170: Correlação e Copulas
                new Formula
                {
                    Id = "3758",
                    CodigoCompendio = "V10-170",
                    Nome = "Gaussian Copula (Dependência)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Risco de Crédito",
                    Expressao = @"C(u₁,u₂) = Φ_ρ(Φ^(-1)(u₁), Φ^(-1)(u₂))",
                    Descricao = "CDO pricing: joint defaults. ρ: correlação. Li (2000): Gaussian copula→CDO boom. 2008: modelo falhou (tail dependence subestimado). Student-t copula: melhor.",
                    ExemploPratico = "2 bonds: PD=5% each, ρ=0.3→P(both default)≈1.2%. ρ=0 (indep): 0.25%. CDO tranches: senior safer (low PD), equity riskier (high PD).",
                    Criador = "Li (2000, J. Fixed Income, Gaussian copula); Sklar (1959, copula theorem)",
                    AnoOrigin = "2000",
                    VariavelResultado = "P_joint",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "PD₁ (%)", Simbolo = "PD1", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "PD₂ (%)", Simbolo = "PD2", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ρ", Simbolo = "rho", Unidade = "", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double PD1 = inputs["PD₁ (%)"] / 100;
                        double PD2 = inputs["PD₂ (%)"] / 100;
                        double rho = inputs["ρ"];
                        
                        // Simplified approximation (true calc requires bivariate normal CDF)
                        // Independent case
                        double P_indep = PD1 * PD2;
                        
                        // Correlation adjustment (approximate)
                        double P_joint = P_indep * (1 + rho);
                        
                        return P_joint * 100; // percentage
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-171: Limite de Kelly
                new Formula
                {
                    Id = "3759",
                    CodigoCompendio = "V10-171",
                    Nome = "Critério de Kelly (Aposta Ótima)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Gestão de Capital",
                    Expressao = @"f* = (p·b − q)/b",
                    Descricao = "Fração ótima capital. p: prob win, q=1−p, b: odds. Maximiza log(wealth). Half-Kelly: mais conservador (f*/2). Thorp: blackjack, trading.",
                    ExemploPratico = "p=55%, b=1 (even money): f*=10%. Too aggressive: ruin risk. Sharpe ratio: f*≈SR/σ². Medallion Fund: usa Kelly (lenda diz).",
                    Criador = "Kelly (1956, Bell Labs); Thorp (1966, aplicação gambling/trading)",
                    AnoOrigin = "1956",
                    VariavelResultado = "f_star",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "p (prob win)", Simbolo = "p", Unidade = "", ValorPadrao = 0.55, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "b (odds)", Simbolo = "b", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double p = inputs["p (prob win)"];
                        double b = inputs["b (odds)"];
                        
                        double q = 1 - p;
                        if (b == 0) return 0;
                        
                        double f_star = (p * b - q) / b;
                        if (f_star < 0) f_star = 0; // don't bet if negative edge
                        
                        return f_star * 100; // percentage
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-172: Modelo Heston (Volatilidade Estocástica)
                new Formula
                {
                    Id = "3760",
                    CodigoCompendio = "V10-172",
                    Nome = "Modelo Heston — Volatilidade Estocástica",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Precificação Avançada",
                    Expressao = @"dv = κ(θ − v)dt + ξ√v·dW_v",
                    Descricao = "v=σ². dS=μS·dt+√v·S·dW_S. Correlação dW_S·dW_v=ρ·dt (leverage effect ρ<0). FFT pricing. Calibração: fit implied vol smile.",
                    ExemploPratico = "κ=2 (mean reversion), θ=0.04 (long-run variance), ξ=0.3 (vol-of-vol). ρ=−0.7 (crash: S↓→v↑). Opções exóticas: barreira, asiáticas.",
                    Criador = "Heston (1993, Rev. Fin. Studies)",
                    AnoOrigin = "1993",
                    VariavelResultado = "v_esperado",
                    UnidadeResultado = "(σ%)²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v₀ (σ%²)", Simbolo = "v0", Unidade = "(σ%)²", ValorPadrao = 0.04, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "κ", Simbolo = "kappa", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "θ (σ%²)", Simbolo = "theta", Unidade = "(σ%)²", ValorPadrao = 0.04, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (anos)", Simbolo = "t", Unidade = "anos", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double v0 = inputs["v₀ (σ%²)"];
                        double kappa = inputs["κ"];
                        double theta = inputs["θ (σ%²)"];
                        double t = inputs["t (anos)"];
                        
                        double E_v = v0 * Math.Exp(-kappa * t) + theta * (1 - Math.Exp(-kappa * t));
                        return E_v;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-173: Information Ratio
                new Formula
                {
                    Id = "3761",
                    CodigoCompendio = "V10-173",
                    Nome = "Information Ratio (IR)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Performance Ativa",
                    Expressao = @"IR = α/ω; α=R_p−R_b (excess return)",
                    Descricao = "ω: tracking error (volatilidade α). IR: skill per unit risk. IR>0.5: bom gestor ativo. Relação Sharpe: IR mede vs benchmark, SR vs risk-free.",
                    ExemploPratico = "Fund: R_p=12%, benchmark=10%, ω=3%→IR=2/3≈0.67 (bom). IR=1: excelente (raro). Passive indexing: IR≈0 (α≈0, baixo ω).",
                    Criador = "Grinold-Kahn (1999, Active Portfolio Management)",
                    AnoOrigin = "1999",
                    VariavelResultado = "IR",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R_p (%)", Simbolo = "Rp", Unidade = "%", ValorPadrao = 12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "R_b (%)", Simbolo = "Rb", Unidade = "%", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ω tracking error (%)", Simbolo = "omega", Unidade = "%", ValorPadrao = 3, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Rp = inputs["R_p (%)"];
                        double Rb = inputs["R_b (%)"];
                        double omega = inputs["ω tracking error (%)"];
                        
                        if (omega == 0) return 0;
                        
                        double alpha = Rp - Rb;
                        double IR = alpha / omega;
                        return IR;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-174: Efficient Frontier (Markowitz)
                new Formula
                {
                    Id = "3762",
                    CodigoCompendio = "V10-174",
                    Nome = "Fronteira Eficiente — Risco Mínimo",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Teoria de Portfolio",
                    Expressao = @"min σ_p² = w^T Σ w; s.t. E[R_p]=w^T μ",
                    Descricao = "Σ: matriz covariância. Quadratic programming. Capital Market Line: tangent portfolio (max Sharpe). Two-fund separation: risk-free + tangent.",
                    ExemploPratico = "2 assets: stocks (μ=10%, σ=20%), bonds (μ=5%, σ=10%), ρ=0.3. Optimal w: solve QP. Modern portfolio theory (Nobel 1990).",
                    Criador = "Markowitz (1952, J. Finance, Nobel 1990)",
                    AnoOrigin = "1952",
                    VariavelResultado = "σ_portfolio",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "σ₁ (%)", Simbolo = "sigma1", Unidade = "%", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ₂ (%)", Simbolo = "sigma2", Unidade = "%", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "w₁", Simbolo = "w1", Unidade = "", ValorPadrao = 0.6, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ρ", Simbolo = "rho", Unidade = "", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double sigma1 = inputs["σ₁ (%)"] / 100;
                        double sigma2 = inputs["σ₂ (%)"] / 100;
                        double w1 = inputs["w₁"];
                        double rho = inputs["ρ"];
                        
                        double w2 = 1 - w1;
                        
                        double var_p = w1 * w1 * sigma1 * sigma1 
                                     + w2 * w2 * sigma2 * sigma2 
                                     + 2 * w1 * w2 * rho * sigma1 * sigma2;
                        
                        double sigma_p = Math.Sqrt(var_p) * 100;
                        return sigma_p;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-175: Jump Diffusion (Merton)
                new Formula
                {
                    Id = "3763",
                    CodigoCompendio = "V10-175",
                    Nome = "Modelo Merton — Jump Diffusion",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Eventos Extremos",
                    Expressao = @"dS = μS·dt + σS·dW + S·dJ",
                    Descricao = "dJ: Poisson jumps (intensidade λ). Jump size J~N(μ_J,σ_J²). Fat tails: captura crashes. Black-Scholes: caso especial λ=0.",
                    ExemploPratico = "λ=1 jump/ano, μ_J=−5% (crash), σ_J=10%. 2008 crash: jump ~−20% (outlier). Kou model: double exponential jumps (assymetric).",
                    Criador = "Merton (1976, J. Fin. Econ.)",
                    AnoOrigin = "1976",
                    VariavelResultado = "λ",
                    UnidadeResultado = "jumps/ano",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "λ (jumps/ano)", Simbolo = "lambda", Unidade = "jumps/ano", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["λ (jumps/ano)"];
                        return lambda;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-176: Medida de Risco CVaR
                new Formula
                {
                    Id = "3764",
                    CodigoCompendio = "V10-176",
                    Nome = "Conditional VaR (CVaR / Expected Shortfall)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Gestão de Risco",
                    Expressao = @"CVaR_α = E[L | L ≥ VaR_α]",
                    Descricao = "Expected shortfall: perda média dado VaR excedido. Coherent risk measure (sub-additivo). Basel Committee: favorece CVaR sobre VaR.",
                    ExemploPratico = "VaR_95%=$100k, CVaR_95%=$150k (loss in worst 5% scenarios). Gaussian: CVaR=2.06·σ (vs VaR=1.64·σ). Fat tails: CVaR≫VaR.",
                    Criador = "Artzner et al. (1999, coherent risk measures); Rockafellar-Uryasev (2000, optimization)",
                    AnoOrigin = "1999",
                    VariavelResultado = "CVaR",
                    UnidadeResultado = "$",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "VaR ($)", Simbolo = "VaR", Unidade = "$", ValorPadrao = 100e3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tail ratio", Simbolo = "ratio", Unidade = "", ValorPadrao = 1.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double VaR = inputs["VaR ($)"];
                        double ratio = inputs["Tail ratio"];
                        
                        double CVaR = VaR * ratio;
                        return CVaR;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-177: Processo de Ornstein-Uhlenbeck
                new Formula
                {
                    Id = "3765",
                    CodigoCompendio = "V10-177",
                    Nome = "Processo Ornstein-Uhlenbeck (Mean Reverting)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Processos Estocásticos",
                    Expressao = @"dX = θ(μ − X)dt + σ·dW",
                    Descricao = "Mean reversion: commodities, interest rates, volatility. Solução: X_t=X₀e^(-θt)+μ(1−e^(-θt))+... Pairs trading: spread mean-reverting.",
                    ExemploPratico = "Oil price spread: θ=0.5 (half-life 1.4yr), μ=$70, σ=$10. X₀=$80: E[X₁]≈$74. Cointegration: statistical arbitrage.",
                    Criador = "Ornstein-Uhlenbeck (1930, física); finanças (anos 1990s pairs trading)",
                    AnoOrigin = "1930",
                    VariavelResultado = "E_X",
                    UnidadeResultado = "$",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "X₀", Simbolo = "X0", Unidade = "$", ValorPadrao = 80, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "θ", Simbolo = "theta", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "μ", Simbolo = "mu", Unidade = "$", ValorPadrao = 70, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (anos)", Simbolo = "t", Unidade = "anos", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double X0 = inputs["X₀"];
                        double theta = inputs["θ"];
                        double mu = inputs["μ"];
                        double t = inputs["t (anos)"];
                        
                        double E_X = X0 * Math.Exp(-theta * t) + mu * (1 - Math.Exp(-theta * t));
                        return E_X;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-178: Maximum Drawdown
                new Formula
                {
                    Id = "3766",
                    CodigoCompendio = "V10-178",
                    Nome = "Maximum Drawdown (MDD)",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Risco e Performance",
                    Expressao = @"MDD = max_t [(peak_t − trough_t)/peak_t]",
                    Descricao = "Maior perda pico-vale. MDD>50%: muito arriscado. Recovery: tempo para voltar ao pico. Calmar ratio: R/MDD (return/drawdown).",
                    ExemploPratico = "2008: S&P 500 MDD≈55%, recovery 5 anos. Hedge fund: MDD=20%→Calmar=15%/20%=0.75. Crypto: MDD>80% comum.",
                    Criador = "Métrica clássica (usado décadas); Calmar ratio (Young 1991)",
                    AnoOrigin = "1991",
                    VariavelResultado = "MDD",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Peak", Simbolo = "peak", Unidade = "$", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Trough", Simbolo = "trough", Unidade = "$", ValorPadrao = 60, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double peak = inputs["Peak"];
                        double trough = inputs["Trough"];
                        
                        if (peak == 0) return 0;
                        
                        double MDD = ((peak - trough) / peak) * 100;
                        return MDD;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-179: Spread de Crédito (CDS)
                new Formula
                {
                    Id = "3767",
                    CodigoCompendio = "V10-179",
                    Nome = "Credit Default Swap (CDS) Spread",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Risco de Crédito",
                    Expressao = @"s ≈ λ·LGD; λ: hazard rate, LGD: loss given default",
                    Descricao = "CDS: seguro default. s: spread (bps). LGD≈60% (recovery 40%). ISDA model: survival probability curve. 2008: Lehman CDS>1000 bps antes colapso.",
                    ExemploPratico = "Corporate: λ=2%/ano, LGD=60%→s≈120 bps. AAA: s<50 bps. Junk: s>500 bps. CDS-bond basis: arbitragem. Big Bang 2009: padronização.",
                    Criador = "J.P. Morgan (1994, Blythe Masters); ISDA model (Markit 2003)",
                    AnoOrigin = "1994",
                    VariavelResultado = "s",
                    UnidadeResultado = "bps",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "λ (%)", Simbolo = "lambda", Unidade = "%", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "LGD (%)", Simbolo = "LGD", Unidade = "%", ValorPadrao = 60, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["λ (%)"] / 100;
                        double LGD = inputs["LGD (%)"] / 100;
                        
                        double s = lambda * LGD * 10000; // bps
                        return s;
                    },
                    Icone = "💰",
                    Unidades = "",
                },

                // V10-180: Modelo Fama-French (3 Fatores)
                new Formula
                {
                    Id = "3768",
                    CodigoCompendio = "V10-180",
                    Nome = "Fama-French 3-Factor Model",
                    Categoria = "Finanças Quantitativas",
                    SubCategoria = "Precificação de Ativos",
                    Expressao = @"R_i − R_f = α + β_m(R_m−R_f) + β_s·SMB + β_v·HML",
                    Descricao = "SMB: Small Minus Big (size effect). HML: High Minus Low (value effect). R²>90% (CAPM: ~70%). Momentum: Carhart 4-factor (WML).",
                    ExemploPratico = "Value stock: β_m=1.2, β_s=0.5 (small), β_v=0.8 (value). SMB≈3%/ano, HML≈5%/ano histórico. Size anomaly weaker post-1980s.",
                    Criador = "Fama e French (1992, 1993, J. Finance); Carhart (1997, 4-factor)",
                    AnoOrigin = "1993",
                    VariavelResultado = "E_Ri",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R_f (%)", Simbolo = "Rf", Unidade = "%", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "β_m", Simbolo = "beta_m", Unidade = "", ValorPadrao = 1.2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "R_m−R_f (%)", Simbolo = "mkt_prem", Unidade = "%", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "β_s", Simbolo = "beta_s", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "SMB (%)", Simbolo = "SMB", Unidade = "%", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "β_v", Simbolo = "beta_v", Unidade = "", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "HML (%)", Simbolo = "HML", Unidade = "%", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Rf = inputs["R_f (%)"];
                        double beta_m = inputs["β_m"];
                        double mkt_prem = inputs["R_m−R_f (%)"];
                        double beta_s = inputs["β_s"];
                        double SMB = inputs["SMB (%)"];
                        double beta_v = inputs["β_v"];
                        double HML = inputs["HML (%)"];
                        
                        double E_Ri = Rf + beta_m * mkt_prem + beta_s * SMB + beta_v * HML;
                        return E_Ri;
                    },
                    Icone = "💰",
                    Unidades = "",
                }
            });
        }
    }
}
