using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        // =========================================================================
        // VOLUME XI - PARTE XVIII: MATEMÁTICA FINANCEIRA
        // 19 fórmulas (3341-3359)
        // =========================================================================

        private void LoadVol11_MatematicaFinanceira()
        {
            // 3341 - Modelo Black-Scholes (Opção Europeia)
            formulas.Add(new Formula
            {
                Id = "3341",
                CategoryId = "VOL11_FINANCE",
                Title = "Modelo Black-Scholes",
                Description = "C = S·N(d₁) - K·e^(-r·T)·N(d₂). S=preço ação, K=strike, T=tempo, r=taxa. ORIGEM: Black-Scholes (1973). ▶ Revolucionário: prêmio opção cálculo preciso. d₁,d₂ envolvem ln(S/K).",
                FormulaText = "C = S·N(d₁) − K·e^(−r·T)·N(d₂)",
                ExemploPratico = "S=100€, K=100€, r=5%, σ=20%, T=0.25: C≈10.45€",
                Criador = "Fischer Black, Myron Scholes",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double S = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Preço ação
                    double K = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Strike
                    double r = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Taxa
                    double sigma = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Volatilidade
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo (anos)
                    
                    double d1 = (Math.Log(S / K) + (r + sigma * sigma / 2) * T) / (sigma * Math.Sqrt(T));
                    double d2 = d1 - sigma * Math.Sqrt(T);
                    
                    // Approximação N(x)
                    Func<double, double> N = x =>
                    {
                        return 0.5 * (1 + Math.Tanh(0.2316419 * x * (1 + 0.319381530 * Math.Abs(x) + -0.356563782 * x * x + 1.781477937 * Math.Pow(x, 3) + -1.821255978 * Math.Pow(x, 4))));
                    };
                    
                    return S * N(d1) - K * Math.Exp(-r * T) * N(d2); // Preço call
                }
            });

            // 3342 - Volatilidade Implícita
            formulas.Add(new Formula
            {
                Id = "3342",
                CategoryId = "VOL11_FINANCE",
                Title = "Volatilidade Implícita (Newton-Raphson)",
                Description = "σ_impl: inverso Black-Scholes. Dado preço mercado, encontra σ. ORIGEM: opções. ▶ Mercado: σ_impl~20-40%. Picos: eventos/volatility smile.",
                FormulaText = "σ_impl = solve(BS_call(σ) = market_price)",
                ExemploPratico = "Preço mercado opção=12€. Iteração: σ_impl~22%",
                Criador = "Options Trading",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double market_price = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // €
                    double S = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ação
                    double K = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Strike
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo
                    
                    // Simplificado: sigma approximation
                    return Math.Sqrt(2 * Math.PI / T) * (market_price / S) * 100; // % (heurística)
                }
            });

            // 3343 - Delta Opção (Hedge Ratio)
            formulas.Add(new Formula
            {
                Id = "3343",
                CategoryId = "VOL11_FINANCE",
                Title = "Delta (∂C/∂S)",
                Description = "Δ = N(d₁). Sensibilidade preço opção vs ação. Δ=0.5: 50% delta-neutral. ORIGEM: hedging. ▶ CALL: 0<Δ<1. PUT: -1<Δ<0. Trading: delta-hedge portfolio.",
                FormulaText = "Δ = ∂C / ∂S = N(d₁)",
                ExemploPratico = "Opção call: Δ=0.6. Sobe 1€ ação → Opção sobe ~0.6€",
                Criador = "Options Greeks",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double d1 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // d₁ parâmetro
                    
                    // N(d1) approximação (CDF normal)
                    double delta = 0.5 * (1 + Math.Tanh(0.1975 * d1)); // Approximação
                    return delta; // 0 to 1
                }
            });

            // 3344 - Gamma Opção (Taxa de Delta)
            formulas.Add(new Formula
            {
                Id = "3344",
                CategoryId = "VOL11_FINANCE",
                Title = "Gamma (∂²C/∂S²)",
                Description = "Γ = ∂Δ/∂S = n(d₁)/(S·σ·√T). Convexidade. Alto Gamma: delta muda rápido. ORIGEM: hedging dinâmico. ▶ Perto vencimento: Γ alto (risco).",
                FormulaText = "Γ = n(d₁) / (S·σ·√T)",
                ExemploPratico = "S=100, σ=0.2, T=0.25: Γ~0.016. Opção sobe 1€, delta muda ~0.016",
                Criador = "Options Greeks",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double S = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Preço ação
                    double sigma = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Volatilidade
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo
                    double d1 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // d₁
                    
                    double n_d1 = Math.Exp(-d1 * d1 / 2) / Math.Sqrt(2 * Math.PI); // Distribuição normal
                    return n_d1 / (S * sigma * Math.Sqrt(T)); // Gamma
                }
            });

            // 3345 - Vega Opção (Sensibilidade Volatilidade)
            formulas.Add(new Formula
            {
                Id = "3345",
                CategoryId = "VOL11_FINANCE",
                Title = "Vega (∂C/∂σ)",
                Description = "ν = S·n(d₁)·√T. Sensibilidade volatilidade. Alto vega: risco volatilidade. ORIGEM: hedging volatilidade. ▶ Mercado: vol traders usam vega para posicionar.",
                FormulaText = "Vega = S·n(d₁)·√T",
                ExemploPratico = "Vega=20. σ +1% → Call +20€ (100 shares notional)",
                Criador = "Volatility Trading",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double S = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Preço ação
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo
                    double d1 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // d₁
                    
                    double n_d1 = Math.Exp(-d1 * d1 / 2) / Math.Sqrt(2 * Math.PI); // Distribuição normal
                    return S * n_d1 * Math.Sqrt(T) / 100; // Vega por 1% movimento
                }
            });

            // 3346 - Theta Opção (Decaimento Tempo)
            formulas.Add(new Formula
            {
                Id = "3346",
                CategoryId = "VOL11_FINANCE",
                Title = "Theta (∂C/∂T)",
                Description = "Θ = -(S·n(d₁)·σ)/(2·√T) - r·K·e^(-r·T)·N(d₂). Decaimento tempo. CALL: Θ typically <0 (perda). ORIGEM: time decay estratégia.",
                FormulaText = "Θ = −(S·n(d₁)·σ)/(2·√T) − r·K·e^(−r·T)·N(d₂)",
                ExemploPratico = "Opção call Θ=-0.5. 1 dia passa → Call perde ~0.5€ (se S,σ constante)",
                Criador = "Time Decay Trading",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double S = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Preço ação
                    double sigma = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Volatilidade
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo
                    double d1 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // d₁
                    
                    double n_d1 = Math.Exp(-d1 * d1 / 2) / Math.Sqrt(2 * Math.PI); // N(d1)
                    return -(S * n_d1 * sigma) / (2 * Math.Sqrt(T)); // Theta aproximado
                }
            });

            // 3347 - Rho Opção (Sensibilidade Taxa)
            formulas.Add(new Formula
            {
                Id = "3347",
                CategoryId = "VOL11_FINANCE",
                Title = "Rho (∂C/∂r)",
                Description = "ρ = K·T·e^(-r·T)·N(d₂). Sensibilidade taxa juros. ORIGEM: hedging taxa. ▶ Call: rho>0. PUT: rho<0. Longo prazo: rho importante.",
                FormulaText = "Rho = K·T·e^(−r·T)·N(d₂)",
                ExemploPratico = "Rho=30. Taxa +1% → Call +30€",
                Criador = "Interest Rate Risk",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double K = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Strike
                    double r = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Taxa
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo
                    double d2 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // d₂
                    
                    // N(d2) approximação
                    double N_d2 = 0.5 * (1 + Math.Tanh(0.1975 * d2));
                    return K * T * Math.Exp(-r * T) * N_d2 / 100; // Rho por 1%
                }
            });

            // 3348 - Valor em Risco (VaR) — Histórico
            formulas.Add(new Formula
            {
                Id = "3348",
                CategoryId = "VOL11_FINANCE",
                Title = "Value-at-Risk (VaR — Método Histórico)",
                Description = "VaR(p%) = -percentil_p(retornos históricos). Perda máxima p% confiança. ORIGEM: risco mercado. ▶ VaR(95%) portfolio = -5%, significado: 95% dias, perda < 5%.",
                FormulaText = "VaR(p%) = percentile(returns, p)",
                ExemploPratico = "1000 dias, VaR(99%) = -3%. Pior 1% dias: perda > 3%",
                Criador = "Risk Management",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double mean_return = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); //
                    double std_return = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // 2%

                    // VaR 95% ~ normal distribution
                    double z95 = 1.645; // 95° percentil
                    return -(mean_return - z95 * std_return) * 100; // VaR %
                }
            });

            // 3349 - Expected Shortfall (CVaR)
            formulas.Add(new Formula
            {
                Id = "3349",
                CategoryId = "VOL11_FINANCE",
                Title = "Expected Shortfall (CVaR)",
                Description = "CVaR = E[Loss | Loss > VaR]. Perda esperada além VaR. ORIGEM: risco coerente. ▶ Mais conservador que VaR. Regulatório Basel III: usa CVaR.",
                FormulaText = "CVaR = E[Loss | Loss > VaR(p%)]",
                ExemploPratico = "VaR(95%)=-5%, CVaR(95%)=-7% (pior casos)",
                Criador = "Coherent Risk",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double VaR = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // %
                    double mean_loss = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // %
                    
                    // CVaR approximation: mais extremo que VaR
                    return VaR - Math.Abs(VaR - mean_loss) * 0.5; // Simplificado
                }
            });

            // 3350 - Razão de Sharpe
            formulas.Add(new Formula
            {
                Id = "3350",
                CategoryId = "VOL11_FINANCE",
                Title = "Índice de Sharpe",
                Description = "SR = (R_p - R_f) / σ_p. R_p=retorno portfolio, R_f=taxa sem risco, σ_p=volatilidade. ORIGEM: William Sharpe (1966). ▶ Boa: SR>1. Excelente: SR>2. Compara risk-adjusted return.",
                FormulaText = "SR = (R_p − R_f) / σ_p",
                ExemploPratico = "R_p=12%, R_f=2%, σ=15%: SR=0.67",
                Criador = "William Sharpe",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double Rp = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Retorno portfolio
                    double Rf = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Taxa sem risco
                    double sigma = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Volatilidade
                    
                    return (Rp - Rf) / sigma; // Sharpe ratio
                }
            });

            // 3351 - Razão de Sortino
            formulas.Add(new Formula
            {
                Id = "3351",
                CategoryId = "VOL11_FINANCE",
                Title = "Índice de Sortino",
                Description = "SortR = (R_p - R_f) / σ_down. σ_down=volatilidade downside. Ignora upside volatilidade. ORIGEM: Frank Sortino. ▶ Melhor que Sharpe: foca downside risk.",
                FormulaText = "SortR = (R_p − R_f) / σ_down",
                ExemploPratico = "R_p=12%, R_f=2%, σ_down=8%: SortR=1.25 (melhor Sharpe)",
                Criador = "Frank Sortino",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double Rp = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Retorno
                    double Rf = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Taxa
                    double sigma_down = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Down vol
                    
                    return (Rp - Rf) / sigma_down; // Sortino ratio
                }
            });

            // 3352 - Duração Título (Duration)
            formulas.Add(new Formula
            {
                Id = "3352",
                CategoryId = "VOL11_FINANCE",
                Title = "Duration de Macaulay",
                Description = "D = Σ(t·CF_t)/(Σ CF_t·(1+y)^t). t=tempo, CF=fluxo, y=yield. ORIGEM: Frederick Macaulay. ▶ Mede sensibilidade tempo. Título 10 ano: D~7-8 anos típico.",
                FormulaText = "D = weighted average time to CF",
                ExemploPratico = "Título 10 ano, cupom 5%: D≈7.4 anos. Yield +1% → preço -7.4%",
                Criador = "Frederick Macaulay",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double V = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Valor títuloCoupon
                    double PMT = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Quop $
                    double y = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Yield
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo
                    
                    // Duration simplificada (aproximação)
                    return T / (1 + y) / 2; // Années
                }
            });

            // 3353 - Convexidade Título
            formulas.Add(new Formula
            {
                Id = "3353",
                CategoryId = "VOL11_FINANCE",
                Title = "Convexidade Score",
                Description = "Convex = Σ(t·(t+1)·CF_t)/((1+y)^(t+2)·V). Curvatura relação preço-yield. ORIGEM: portfolio imunização. ▶ Maior convexidade: melhor proteção falling rates.",
                FormulaText = "Convexity = weighted second order",
                ExemploPratico = "Título 10 ano: Convex~60-100. Calculada com duration.",
                Criador = "Bond Analytics",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double V = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Valor título
                    double y = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Yield
                    double T = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo
                    
                    // Convexidade simplificada
                    return T * T / (Math.Pow(1 + y, 2) * V);
                }
            });

            // 3354 - IRR (Internal Rate of Return)
            formulas.Add(new Formula
            {
                Id = "3354",
                CategoryId = "VOL11_FINANCE",
                Title = "Taxa Interna de Retorno (IRR)",
                Description = "Σ CF_t/(1+IRR)^t = 0. Taxa que faz NPV=0. ORIGEM: investimento análise. ▶ Compara projetos. IRR>WACC → valor criado.",
                FormulaText = "Σ CF_t / (1+IRR)^t = 0",
                ExemploPratico = "Investimento -100, +60 ano 1, +60 ano 2: IRR≈13.1%",
                Criador = "Investment Analysis",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double CF0 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Initial
                    double CF1 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ano 1
                    double CF2 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ano 2
                    
                    // Newton-Raphson simplificado
                    double irr = 0.1; // Inicial
                    for (int i = 0; i < 10; i++)
                    {
                        double npv = CF0 + CF1 / (1 + irr) + CF2 / ((1 + irr) * (1 + irr));
                        double deriv = -CF1 / ((1 + irr) * (1 + irr)) - 2 * CF2 / (Math.Pow(1 + irr, 3));
                        irr = irr - npv / deriv;
                    }
                    return irr * 100; // %
                }
            });

            // 3355 - Net Present Value (NPV)
            formulas.Add(new Formula
            {
                Id = "3355",
                CategoryId = "VOL11_FINANCE",
                Title = "Valor Presente Líquido (NPV)",
                Description = "NPV = Σ CF_t/(1+r)^t. Valor atual fluxos. r=desconto taxa. ORIGEM: finanças. ▶ Decisão: NPV>0 → aceita projeto. Sensível taxa desconto.",
                FormulaText = "NPV = Σ CF_t / (1+r)^t",
                ExemploPratico = "CF: -100, +60, +60. r=10%: NPV=4.13 (aceitar)",
                Criador = "Capital Budgeting",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double CF0 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Inicial
                    double CF1 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ano 1
                    double CF2 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ano 2
                    double r = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Taxa desconto
                    
                    return CF0 + CF1 / (1 + r) + CF2 / ((1 + r) * (1 + r)); // NPV
                }
            });

            // 3356 - Índice de Lucratividade (PI)
            formulas.Add(new Formula
            {
                Id = "3356",
                CategoryId = "VOL11_FINANCE",
                Title = "Profitability Index (PI)",
                Description = "PI = PV(fluxos futuros) / Investimento Inicial. PI>1 → valor positivo. ORIGEM: capital rationing. ▶ Ranking projetos quando restrição orçamento.",
                FormulaText = "PI = PV(inflows) / PV(outflows)",
                ExemploPratico = "PV(inflows)=150, invest=100: PI=1.5 (bom)",
                Criador = "Investment Ranking",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double PV_inflows = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // PV
                    double invest = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Investimento
                    
                    return PV_inflows / invest; // PI
                }
            });

            // 3357 - Período de Recuperação (PP) — Simple
            formulas.Add(new Formula
            {
                Id = "3357",
                CategoryId = "VOL11_FINANCE",
                Title = "Payback Period (Simples)",
                Description = "PP = Investimento Inicial / Fluxo Anual (se constante). Tempo recuperação investimento. ORIGEM: simples, intuitivo. ▶ Problema: ignora time value. PP<3 anos: aceitável startup.",
                FormulaText = "PP = Investment / Annual_CF",
                ExemploPratico = "Investimento 100, fluxo anual 30: PP=3.33 anos",
                Criador = "Project Evaluation",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double invest = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // €
                    double annual_cf = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // €/ano
                    
                    return invest / annual_cf; // Anos
                }
            });

            // 3358 - WACC (Weighted Average Cost of Capital)
            formulas.Add(new Formula
            {
                Id = "3358",
                CategoryId = "VOL11_FINANCE",
                Title = "WACC (Custo Médio Ponderado Capazl)",
                Description = "WACC = (E/V)·r_e + (D/V)·r_d·(1-T_c). E=equity, D=debt, V=total, T_c=tax rate. ORIGEM: finanças corporativas. ▶ Taxa desconto padrão. Otimação: balanço E/D.",
                FormulaText = "WACC = (E/V)·r_e + (D/V)·r_d·(1−T_c)",
                ExemploPratico = "E=100, D=50, r_e=12%, r_d=5%, T=30%: WACC=9.2%",
                Criador = "Corporate Finance",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double e = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Equity
                    double d = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Debt
                    double re = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Cost equity
                    double rd = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Cost debt
                    double Tc = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tax rate
                    
                    double V = e + d; // Total value
                    return (e / V) * re + (d / V) * rd * (1 - Tc); // WACC
                }
            });

            // 3359 - Beta Ação (CAPM)
            formulas.Add(new Formula
            {
                Id = "3359",
                CategoryId = "VOL11_FINANCE",
                Title = "Beta (CAPM Sensibilidade)",
                Description = "β = Cov(R_s, R_m) / Var(R_m). Sensibilidade retorno ação vs mercado. ORIGEM: CAPM. ▶ β=1 mercado. β>1 volátil. β<1 estável. Baixa beta: defensivo.",
                FormulaText = "β = Cov(R_s, R_m) / Var(R_m)",
                ExemploPratico = "Tech stock β=1.5 (50% mais volátil mercado)",
                Criador = "CAPM (Sharpe, Lintner, Mossin)",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double cov = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Cov(R_s,R_m)
                    double var_m = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Var(R_m)
                    
                    return cov / var_m; // Beta
                }
            });
        }
    }
}
