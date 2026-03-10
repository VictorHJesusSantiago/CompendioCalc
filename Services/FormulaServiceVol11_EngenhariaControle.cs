using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        // =========================================================================
        // VOLUME XI - PARTE IX: ENGENHARIA DE CONTROLE MODERNO
        // 21 fórmulas (3162-3182)
        // =========================================================================

        private void LoadVol11_EngenhariaControle()
        {
            // 3162 - Ganho de Malha Aberta
            formulas.Add(new Formula
            {
                Id = "3162",
                CategoryId = "VOL11_CONTROLE",
                Title = "Ganho de Malha Aberta",
                Description = "K = Y_ss / U. Ganho steady-state em malha aberta. K alto: resposta rápida, menos erro. ORIGEM: teoria de controle (Nyquist, Bode). ▶ K=2: Y_ss=2·U. Instável se mal amortecido.",
                FormulaText = "K = Y_ss / U",
                ExemploPratico = "K=2 com U=10V → Y_ss=20V. Ganho elevado: resposta rápida. Ganho baixo: lento. Tradeoff: estabilidade",
                Criador = "Harry Nyquist e Hendrik Bode",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double Y_ss = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Saída steady-state
                    double U = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Entrada
                    
                    return Y_ss / U; // Ganho K
                }
            });

            // 3163 - Função de Transferência de 1ª Ordem
            formulas.Add(new Formula
            {
                Id = "3163",
                CategoryId = "VOL11_CONTROLE",
                Title = "Resposta ao Degrau — Sistema de 1ª Ordem",
                Description = "y(t) = K·U·(1 − exp(−t/τ)). Pólo em s=−1/τ. ORIGEM: análise de sistemas. ▶ τ=constante de tempo. 5τ: 99% estacionário. τ↓: resposta rápida.",
                FormulaText = "y(t) = K·U·(1 − exp(−t/τ))",
                ExemploPratico = "K=2, U=10, τ=1s. Em t=1s: y~12,6V (63%). Em t=5s: 99% de estacionário",
                Criador = "Análise de Sistemas",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double K = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho
                    double U = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Entrada
                    double t = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Tempo (s)
                    double tau = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Constante de tempo (s)
                    
                    return K * U * (1 - Math.Exp(-t / tau)); // y(t)
                }
            });

            // 3164 - Estabilidade de Routh-Hurwitz
            formulas.Add(new Formula
            {
                Id = "3164",
                CategoryId = "VOL11_CONTROLE",
                Title = "Critério de Routh-Hurwitz",
                Description = "Estabilidade via análise de coeficientes polinômio característico. Todos coeficientes > 0: condição necessária. ORIGEM: Routh (1874). ▶ Sistema estável: todos pólos Re(s)<0. Teste: tabela de Routh.",
                FormulaText = "a₀s³ + a₁s² + a₂s + a₃",
                ExemploPratico = "s³+2s²+3s+4: coeficientes >0. Teste de Routh: tabela 4 linhas. Mudanças de sinal: número pólos RHP",
                Criador = "Edward Routh e Adolf Hurwitz",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double a0 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Coef s³
                    double a1 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Coef s²
                    double a2 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Coef s
                    double a3 = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Termo constante
                    
                    // Critério: todos positive
                    return (a0 > 0 && a1 > 0 && a2 > 0 && a3 > 0) ? 1.0 : 0.0; // 1=estável, 0=instável
                }
            });

            // 3165 - Controlador PID Paralelo
            formulas.Add(new Formula
            {
                Id = "3165",
                CategoryId = "VOL11_CONTROLE",
                Title = "Controlador PID Paralelo",
                Description = "u(t) = Kₚ·e(t) + Kᵢ∫e(t)dt + Kₐ·de/dt. Proporcional+Integral+Derivativo. ORIGEM: Ziegler-Nichols (1942). ▶ Kₚ: resposta rápida. Kᵢ: elimina erro SS. Kₐ: amortecimento.",
                FormulaText = "u(t) = Kₚ·e + Kᵢ∫e dt + Kₐ·de/dt",
                ExemploPratico = "Kₚ=2, Kᵢ=0.5, Kₐ=0.1. Erro=5: u=2·5+0.5·∫5+0.1·0=10+2.5=12.5V",
                Criador = "John Ziegler e Nathaniel Nichols",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double Kp = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho proporcional
                    double Ki = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho integral
                    double Kd = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho derivativo
                    double e = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Erro
                    double integral_e = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Integral
                    double de = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Derivada
                    
                    return Kp * e + Ki * integral_e + Kd * de; // u(t)
                }
            });

            // 3166 - Margem de Fase e Ganho
            formulas.Add(new Formula
            {
                Id = "3166",
                CategoryId = "VOL11_CONTROLE",
                Title = "Margem de Fase — Estabilidade Relativa",
                Description = "PM = φ(ωc) + 180°. ωc=frequência de corte (|H|=1). ORIGEM: Bode. ▶ PM>30°: estável. PM<30°: oscilaton. PM<0°: instável. MG = −20log|H(ωφ)| em φ=−180°.",
                FormulaText = "PM = φ(ωc) + 180°",
                ExemploPratico = "ωc=10rad/s com fase=−120°: PM=60°. Bom. PM=15°: margem apertada. Oscilação provável",
                Criador = "Hendrik Bode",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double phase_wc = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Fase em ωc (graus)
                    
                    return phase_wc + 180; // PM em graus
                }
            });

            // 3167 - Resposta Subamortecida (ζ < 1)
            formulas.Add(new Formula
            {
                Id = "3167",
                CategoryId = "VOL11_CONTROLE",
                Title = "Resposta Subamortecida — Overshoot",
                Description = "OS = exp(−ζπ/√(1−ζ²))·100%. Overshoot reduz com ζ↑. ζ=0: oscilatória (sem amortecimento). ORIGEM: dinâmica de 2ª ordem. ▶ ζ=0,5: OS≈16%. ζ=0,7: OS≈5%. ζ>1: superamortecida.",
                FormulaText = "OS(%) = exp(−ζπ/√(1−ζ²))·100",
                ExemploPratico = "ζ=0,5: OS~16%. ζ=0,7: OS~5%. ζ=0,2: OS~53%. Tradeoff: velocidade vs overshoot",
                Criador = "Análise de Sistemas de 2ª Ordem",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double zeta = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Coef amortecimento
                    
                    if (zeta >= 1) return 0.0; // Superamortecida
                    
                    return Math.Exp(-zeta * Math.PI / Math.Sqrt(1 - zeta * zeta)) * 100; // OS em %
                }
            });

            // 3168 - Tempo de Acomodação (Settling Time)
            formulas.Add(new Formula
            {
                Id = "3168",
                CategoryId = "VOL11_CONTROLE",
                Title = "Tempo de Acomodação (Settling Time)",
                Description = "tₛ ≈ 4/(ζ·ωₙ). Tempo para entrar na banda ±2%. ωₙ=freq natural. ORIGEM: dinâmica. ▶ ωₙ=5rad/s, ζ=0,7: tₛ~1,14s. Reduz com ωₙ↑.",
                FormulaText = "tₛ ≈ 4/(ζ·ωₙ)",
                ExemploPratico = "ωₙ=5, ζ=0,7: tₛ~1,14s. ωₙ=10: tₛ~0,57s. Aumento de freq natural: resposta mais rápida",
                Criador = "Análise de Transientes",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double zeta = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Amortecimento
                    double wn = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Freq natural (rad/s)
                    
                    return 4 / (zeta * wn); // tₛ em segundos
                }
            });

            // 3169 - Critério de Nyquist
            formulas.Add(new Formula
            {
                Id = "3169",
                CategoryId = "VOL11_CONTROLE",
                Title = "Critério de Nyquist",
                Description = "Estabilidade: N = Z − P. N=circulações ao redor (−1,0). Z=zeros de 1+G(s)H(s) RHP. P=pólos RHP malha aberta. ORIGEM: Harry Nyquist (1932). ▶ Se P=0: precisamos N=0 → estável.",
                FormulaText = "N = Z − P",
                ExemploPratico = "P=0 (malha aberta estável). Se contorna (−1,0) N=0 vezes: estável. N≠0: instável",
                Criador = "Harry Nyquist",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double Z = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Zeros em RHP
                    double P = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Pólos em RHP malha aberta
                    
                    return Z - P; // N circulations
                }
            });

            // 3170 - Ganho Crítico (Ziegler-Nichols)
            formulas.Add(new Formula
            {
                Id = "3170",
                CategoryId = "VOL11_CONTROLE",
                Title = "Ganho Crítico (Método Ziegler-Nichols)",
                Description = "Kₚ = Kc/2.2. Kc=ganho crítico necessário para oscilação sustentada. Tperiodo=período crítico. ORIGEM: Ziegler-Nichols (1942). ▶ Método empírico: incrementar K até oscilação marginal.",
                FormulaText = "Kₚ = Kc/2.2",
                ExemploPratico = "Em oscilação marginal: Kc=10, Tperiodo=2s. PID Ziegler-Nichols: Kₚ=4.5, Kᵢ=4.5/Tperiodo, Kₐ=1.1·Kₚ·Tperiodo",
                Criador = "John Ziegler e Nathaniel Nichols",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double Kc = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho crítico
                    
                    return Kc / 2.2; // Kp
                }
            });

            // 3171 - Erro de Rastreamento (Steady-State)
            formulas.Add(new Formula
            {
                Id = "3171",
                CategoryId = "VOL11_CONTROLE",
                Title = "Erro em Regime Permanente",
                Description = "e_ss = R(s)/(1+G(s)H(s)). Erro para entrada degrau. Tipo 0: e_ss=R/(1+K). Tipo 1: e_ss=0. ORIGEM: teoria controle. ▶ Integral: elimina erro em degrau. Derivada: melhora transiente.",
                FormulaText = "e_ss = R_ss / (1 + K_p)",
                ExemploPratico = "Degrau R=10, K=5: e_ss=10/(1+5)=1.67. Aumentar K: erro reduz. Integrador: e_ss=0",
                Criador = "Teoria Clássica de Controle",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double R_ss = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Entrada steady-state
                    double K = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho de malha aberta
                    
                    return R_ss / (1 + K); // Erro SS
                }
            });

            // 3172 - Diagrama de Bode (Magnitude)
            formulas.Add(new Formula
            {
                Id = "3172",
                CategoryId = "VOL11_CONTROLE",
                Title = "Magnitude em dB (Bode)",
                Description = "|G|_dB = 20·log₁₀|G(jω)|. Frequência logarítmica. ORIGEM: Hendrik Bode (1945). ▶ +20dB/decade=pólo. −20dB/decade=zero. Cruzamento 0dB = ciclo de ganho unitário.",
                FormulaText = "|G|_dB = 20·log₁₀|G(jω)|",
                ExemploPratico = "|G|=10: 20dB. |G|=100: 40dB. |G|=0.1: −20dB. Década de frequência: 10× em ω",
                Criador = "Hendrik Bode",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double G_magnitude = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Magnitude de G
                    
                    return 20 * Math.Log10(G_magnitude); // |G| em dB
                }
            });

            // 3173 - Controlabilidade (Posto da Matriz)
            formulas.Add(new Formula
            {
                Id = "3173",
                CategoryId = "VOL11_CONTROLE",
                Title = "Controlabilidade — Matriz de Controlabilidade",
                Description = "C = [B AB A²B...Aⁿ⁻¹B]. Rank(C)=n → controlável. ORIGEM: Kalman (1960). ▶ Sistema controlável: pode-se levar qualquer estado inicial a qualquer estado final. Essencial para design de realimentação.",
                FormulaText = "Rank([B AB A²B ... Aⁿ⁻¹B]) = n",
                ExemploPratico = "Sistema 2ª ordem: verificar rank([B AB]). Rank=2: controlável. Rank<2: modos incontroláveis",
                Criador = "Rudolf Kalman",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double rank = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Rank da matriz
                    double order = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ordem do sistema
                    
                    return rank == order ? 1.0 : 0.0; // 1=controlável, 0=não
                }
            });

            // 3174 - Observabilidade
            formulas.Add(new Formula
            {
                Id = "3174",
                CategoryId = "VOL11_CONTROLE",
                Title = "Observabilidade — Matriz de Observabilidade",
                Description = "O = [C; CA; CA²; ...CA^(n−1)]. Rank(O)=n → observável. ORIGEM: Kalman (1960). ▶ Observável: pode-se deduzir estado inicial da observação de saída. Design de observador.",
                FormulaText = "Rank([C; CA; CA²; ... CA^(n-1)]) = n",
                ExemploPratico = "Sistema 2ª ordem com p=1 saída: verificar rank 2×2. Rank=2: observável. Pode construir observador",
                Criador = "Rudolf Kalman",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double rank = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Rank matriz O
                    double order = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ordem
                    
                    return rank == order ? 1.0 : 0.0; // 1=observável, 0=não
                }
            });

            // 3175 - Regulador Linear Quadrático (LQR)
            formulas.Add(new Formula
            {
                Id = "3175",
                CategoryId = "VOL11_CONTROLE",
                Title = "Índice de Desempenho LQR",
                Description = "J = ∫[x'Qx + u'Ru]dt (0→∞). Minimiza erro + esforço de controle. Q=penalidade em estado, R=penalidade em ação. ORIGEM: Bellman (1950s). ▶ Solução: u=−Kx via Riccati.",
                FormulaText = "J = ∫(x'Qx + u'Ru)dt",
                ExemploPratico = "Q↑: ênfase em reduzir erro. R↑: ênfase em economia de energia. Tradeoff: velocidade vs carga",
                Criador = "Richard Bellman",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double x = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Estado
                    double u = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ação
                    double Q = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Penalidade estado
                    double R = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Penalidade ação
                    
                    return x * x * Q + u * u * R; // J (instantâneo)
                }
            });

            // 3176 - Filtro de Kalman (Ganho de Kalman)
            formulas.Add(new Formula
            {
                Id = "3176",
                CategoryId = "VOL11_CONTROLE",
                Title = "Ganho de Kalman",
                Description = "K = P·H'/(H·P·H' + R). P=covariância predição, H=matriz saída, R=ruído. ORIGEM: Rudolf Kalman (1960). ▶ K↑: confia mais em medição. K↓: confia mais em modelo. Ótimo com Gaussiano.",
                FormulaText = "K = P·H'/(H·P·H' + R)",
                ExemploPratico = "P=1, H=1, R=0.1: K=1/1.1≈0.909. Confia muito em medição. R=1: K=0.5 (balanço)",
                Criador = "Rudolf Kalman",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double P = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Covariância
                    double H = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Matriz saída
                    double R = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ruído
                    
                    return P * H / (H * P * H + R); // Ganho Kalman
                }
            });

            // 3177 - Amortecimento Ótimo (ζ ótima para tempo mínimo)
            formulas.Add(new Formula
            {
                Id = "3177",
                CategoryId = "VOL11_CONTROLE",
                Title = "Amortecimento Ótimo (Critério ITAE)",
                Description = "ζ_opt ≈ 0,7 para mínimo tempo integral do erro absoluto. ITAE = ∫t|e|dt. ζ=0,7: bom balanço velocidade/overshoot. ORIGEM: otimização de controle. ▶ Especificação: |OS|≤5%, PM>50°.",
                FormulaText = "ζ_opt ≈ 0.7",
                ExemploPratico = "ζ=0,7: OS~4,6%, tempo de pico rápido. ζ=0,5: OS~16%. ζ>1: lento. ITAE minimizado em ζ=0,7",
                Criador = "Otimização de Controle",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double zeta = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Amortecimento
                    
                    return zeta; // Valor ótimo recomendado: 0,7
                }
            });

            // 3178 - Controlador H-infinito (Norma H∞)
            formulas.Add(new Formula
            {
                Id = "3178",
                CategoryId = "VOL11_CONTROLE",
                Title = "Norma H-Infinito",
                Description = "||G(s)||∞ = max|G(jω)| para ω∈[0,∞). Pior amplificação. ORIGEM: robust control. ▶ Objetivo: ||S||∞<γ, onde S=1/(1+GK). Rejeita perturbações.",
                FormulaText = "||G||∞ = max_ω |G(jω)|",
                ExemploPratico = "Pico de magnitude em ω=ωres: 10dB. ||G||∞=10 (linear). Robustez: limita ||GK||∞<1",
                Criador = "Robust Control Theory",
                Nivel = NivelDificuldade.Avancado,
                Calcular = parametros =>
                {
                    double max_magnitude = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Máxima magnitude
                    
                    return Math.Log10(max_magnitude) * 20; // H∞ em dB
                }
            });

            // 3179 - Alocação de Pólos
            formulas.Add(new Formula
            {
                Id = "3179",
                CategoryId = "VOL11_CONTROLE",
                Title = "Alocação de Pólos",
                Description = "λᵢ = −ζ·ωₙ ± jωₙ√(1−ζ²). Posicionar pólos em malha fechada. ORIGEM: controle clássico. ▶ Pólos mais à esquerda: resposta mais rápida. Tradeoff: esforço de controle.",
                FormulaText = "λ = −ζ·ωₙ ± jωₙ√(1−ζ²)",
                ExemploPratico = "ζ=0,7, ωₙ=5: λ=−3.5±j3.36. Transiente rápido, baixo overshoot. Realizar feedback K=[k₁ k₂]",
                Criador = "Teoria de Controle Clássica",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double zeta = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Amortecimento
                    double wn = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Freq natural
                    
                    double real_part = -zeta * wn;
                    double imag_part = wn * Math.Sqrt(1 - zeta * zeta);
                    
                    return Math.Abs(real_part); // Retorna parte real (rápidez)
                }
            });

            // 3180 - Erro de Acompanhamento em Ramp
            formulas.Add(new Formula
            {
                Id = "3180",
                CategoryId = "VOL11_CONTROLE",
                Title = "Erro em Rampa (Tipo de Sistema)",
                Description = "e_ss = a/Kv. Kv=lim sG(s) ganho velocidade. Tipo 0: e_ss=∞. Tipo 1: e_ss=a/K. ORIGEM: análise SS. ▶ Integrador: tipo 1, elimina erro em degrau.",
                FormulaText = "e_ss = a / Kv",
                ExemploPratico = "Rampa a=2, Kv=10: e_ss=0.2. Tipo 0: não segue rampa. Tipo 1: erro finito",
                Criador = "Teoria Clássica de Controle",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double a = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Inclinação da rampa
                    double Kv = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho velocidade
                    
                    return (Kv != 0) ? a / Kv : double.PositiveInfinity; // e_ss
                }
            });

            // 3181 - Frequência de Corte (−3dB)
            formulas.Add(new Formula
            {
                Id = "3181",
                CategoryId = "VOL11_CONTROLE",
                Title = "Frequência de Corte (−3dB)",
                Description = "ωc: |G(jωc)| = |G(0)|/√2. Largura de banda −3dB. ORIGEM: teoria frequência. ▶ BW↑: resposta rápida. BW↓: ruído. Tradeoff.",
                FormulaText = "ωc: |G(jωc)| = |G(0)|/√2",
                ExemploPratico = "DC gain |G(0)|=20dB. Corte: −3dB = 17dB. ωc=100rad/s. BW=100rad/s",
                Criador = "Análise em Frequência",
                Nivel = NivelDificuldade.Fundamental,
                Calcular = parametros =>
                {
                    double DC_gain = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Ganho em DC (dB)
                    
                    return DC_gain - 3; // Frequência de corte em dB
                }
            });

            // 3182 - Resposta em Frequência (Fase)
            formulas.Add(new Formula
            {
                Id = "3182",
                CategoryId = "VOL11_CONTROLE",
                Title = "Fase em Frequência (Bode)",
                Description = "φ(ω) = arctan(Im G / Re G). Atraso de fase indica 'lag'. ORIGEM: análise Bode. ▶ −90°/decade com pólo. +90°/decade com zero.",
                FormulaText = "φ(ω) = atan2(Im G, Re G)",
                ExemploPratico = "G(jω)=1/(jω+1): φ=−arctan(ω). Em ω=1: φ=−45°. Em ω=∞: φ→−90°",
                Criador = "Hendrik Bode",
                Nivel = NivelDificuldade.Intermediario,
                Calcular = parametros =>
                {
                    double Im_G = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Parte imaginária
                    double Re_G = Convert.ToDouble(parametros.GetValueOrDefault("x", 0d)); // Parte real
                    
                    double phase_rad = Math.Atan2(Im_G, Re_G);
                    return phase_rad * 180 / Math.PI; // Fase em graus
                }
            });
        }
    }
}
