using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME IX - PARTE IV: CONTROLE ÓTIMO E SISTEMAS DINÂMICOS
    /// Pontryagin, HJB, LQR, Kalman, Lyapunov, estabilidade
    /// Fórmulas 064-082 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private Formula V9_CTRL064_PrincipioMaximoPontryagin() => new Formula
        {
            Id = "V9-CTRL064", CodigoCompendio = "064", Nome = "Princípio do Máximo de Pontryagin",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "u*(t) = argmax_u H(x,u,λ,t); H = L + λ'f",
            ExprTexto = "Controle ótimo maximiza Hamiltoniano",
            Descricao = "Princípio do Máximo de Pontryagin (PMP): condição necessária para controle ótimo u*(t). Hamiltoniano H=L(x,u)+λ'f(x,u) onde L custo instantâneo, f dinâmica, λ coestado. ẋ=∂H/∂λ, λ̇=−∂H/∂x, u*=argmaxH. Generaliza cálculo de variações para controle com constraints.",
            Criador = "Lev Pontryagin (1956, Princípio do Máximo; livro Mathematical Theory of Optimal Processes 1962)",
            AnoOrigin = "1956",
            ExemploPratico = "Controle bang-bang: u∈{−1,+1}, H linear em u → controle nos extremos. Tempo mínimo: L=1, minimiza T. Apollo Moon landing: controle combustível ótimo. Economia: ramsey growth model otimiza consumo/investimento.",
            Unidades = "depende do problema",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "L", Nome = "Custo instantâneo", Unidade = "$/s", ValorPadrao = 1, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "lambda_f", Nome = "λ'f", Unidade = "$/s", ValorPadrao = 0.5, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["L"] + v["lambda_f"], // Hamiltoniano
            VariavelResultado = "H", UnidadeResultado = "$/s",
            Icone = "∑",
        };

        private Formula V9_CTRL065_EquacaoHamiltonJacobiBellman() => new Formula
        {
            Id = "V9-CTRL065", CodigoCompendio = "065", Nome = "Equação de Hamilton-Jacobi-Bellman (HJB)",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "−∂V/∂t = min_u [L(x,u) + (∂V/∂x)'f(x,u)]",
            ExprTexto = "PDE para função valor V(x,t)",
            Descricao = "Equação HJB: PDE satisfeita pela função valor ótimo V(x,t)=min custo futuro. Princípio de programação dinâmica de Bellman: otimalidade de subcaminhos. Controle ótimo u*(x,t) minimiza lado direito. Generalização Hamilton-Jacobi clássica para controle estocástico e determinístico.",
            Criador = "Richard Bellman (1957, Dynamic Programming); William Hamilton (1834); Carl Jacobi (1842)",
            AnoOrigin = "1957",
            ExemploPratico = "LQR: HJB se torna equação Riccati algébrica. Controle estocástico: adiciona termo difusão ½tr(σσ'V_xx). Finance: pricing opções via HJB. Robótica: path planning otimiza V=distância-ao-objetivo.",
            Unidades = "custo",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "L", Nome = "Custo instantâneo", Unidade = "$", ValorPadrao = 1, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "V_x_f", Nome = "∇V·f", Unidade = "$/s", ValorPadrao = -0.5, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["L"] + v["V_x_f"], // lado direito HJB
            VariavelResultado = "RHS HJB", UnidadeResultado = "$/s",
            Icone = "∑",
        };

        private Formula V9_CTRL066_ReguladorQuadraticoLinear() => new Formula
        {
            Id = "V9-CTRL066", CodigoCompendio = "066", Nome = "Regulador Quadrático Linear (LQR)",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "u* = −Kx = −R⁻¹B'Px; PA+A'P−PBR⁻¹B'P+Q=0",
            ExprTexto = "Ganho ótimo K via solução Riccati ARE",
            Descricao = "LQR: controle ótimo para sistema linear ẋ=Ax+Bu minimizando custo quadrático J=∫(x'Qx+u'Ru)dt. Solução: feedback u=−Kx com ganho K=R⁻¹B'P onde P satisfaz equação algébrica de Riccati (ARE). Propriedade: estabilidade garantida, margem de fase ≥60°, margem de ganho ∞.",
            Criador = "Rudolf Kalman (1960, Contributions to the Theory of Optimal Control); Riccati (1724, equação diferencial)",
            AnoOrigin = "1960",
            ExemploPratico = "Pêndulo invertido: estabiliza posição vertical via LQR. Controle aeronaves: Q penaliza desvios atitude, R penaliza esforço controle. Matlab: [K,P]=lqr(A,B,Q,R). Trade-off Q vs R: performance vs esforço.",
            Unidades = "matriz ganho",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "P11", Nome = "P[1,1]", Unidade = "adim", ValorPadrao = 10, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "B1", Nome = "B[1]", Unidade = "adim", ValorPadrao = 1, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "R", Nome = "R peso", Unidade = "adim", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["P11"] * v["B1"] / v["R"], // K simplificado 1D
            VariavelResultado = "Ganho K", UnidadeResultado = "adimensional",
            Icone = "∑",
        };

        private Formula V9_CTRL067_FiltroKalman() => new Formula
        {
            Id = "V9-CTRL067", CodigoCompendio = "067", Nome = "Filtro de Kalman",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "x̂_{k|k} = x̂_{k|k−1} + K_k(y_k − H·x̂_{k|k−1}); K_k = P_{k|k−1}H'(HP_{k|k−1}H'+R)⁻¹",
            ExprTexto = "Estimador ótimo recursivo para sistemas lineares com ruído",
            Descricao = "Filtro de Kalman: algoritmo recursivo para estimar estado x de sistema dinâmico linear com ruído Gaussiano. Predição: x̂_{k|k−1}=Ax̂_{k−1|k−1}+Bu_k, P_{k|k−1}=AP_{k−1|k−1}A'+Q. Correção: ganho Kalman K_k, update x̂ e P. Ótimo no sentido MMSE (minimum mean square error). Base de navegação inercial, GPS-INS fusion.",
            Criador = "Rudolf Kalman (1960, A New Approach to Linear Filtering and Prediction Problems); Richard Bucy (1961, extensão não-linear)",
            AnoOrigin = "1960",
            ExemploPratico = "Apollo guidance: fusão acelerômetros+giroscópios+tracking. Veículos autônomos: fusão LIDAR+IMU+câmera. Extended Kalman Filter (EKF): lineariza não-linear via Jacobiano. Unscented KF: sigma points para não-linearidade severa.",
            Unidades = "estado",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "x_pred", Nome = "x̂ predito", Unidade = "m", ValorPadrao = 10, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "y_meas", Nome = "Medição y", Unidade = "m", ValorPadrao = 10.5, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "K", Nome = "Ganho Kalman", Unidade = "adim", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["x_pred"] + v["K"] * (v["y_meas"] - v["x_pred"]),
            VariavelResultado = "x̂ corrigido", UnidadeResultado = "m",
            Icone = "∑",
        };

        private Formula V9_CTRL068_EstabilidadeLyapunov() => new Formula
        {
            Id = "V9-CTRL068", CodigoCompendio = "068", Nome = "Estabilidade de Lyapunov",
            Categoria = "Volume IX", SubCategoria = "Sistemas Dinâmicos",
            Expressao = "V(x)>0; V̇(x)<0 ∀x≠0 ⇒ estabilidade assintótica",
            ExprTexto = "Função Lyapunov positiva definida com derivada negativa",
            Descricao = "Teorema de Lyapunov: se existe função V(x) (candidata Lyapunov) tal que V>0 e V̇=∇V·f(x)<0, então origem é assintoticamente estável. Análogo a energia decrescente. Método direto (sem resolver EDOs). Construção de V não é algorítmica, requer insight. LaSalle invariance principle generaliza para V̇≤0.",
            Criador = "Aleksandr Lyapunov (1892, tese The General Problem of the Stability of Motion)",
            AnoOrigin = "1892",
            ExemploPratico = "Pêndulo amortecido: V=½mgl(1−cosθ)+½ml²θ̇², V̇=−bθ̇²<0. Sistema linear ẋ=Ax: V=x'Px, estável se PA+A'P<0 (Lyapunov equation). Controle adaptativo: Lyapunov design method constrói lei controle garantindo V̇<0.",
            Unidades = "energia",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "V", Nome = "V(x)", Unidade = "J", ValorPadrao = 10, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "V_dot", Nome = "V̇(x)", Unidade = "W", ValorPadrao = -1, ValorMax = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => (v["V"] > 0 && v["V_dot"] < 0) ? 1.0 : 0.0, // 1=estável
            VariavelResultado = "Estável", UnidadeResultado = "bool",
            Icone = "∑",
        };

        private Formula V9_CTRL069_MargemFaseGanho() => new Formula
        {
            Id = "V9-CTRL069", CodigoCompendio = "069", Nome = "Margens de Fase e Ganho - Critério de Bode",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "PM = 180° + ∠L(jω_cg); GM = 1/|L(jω_pc)|",
            ExprTexto = "PM: fase adicional tolerável; GM: ganho adicional tolerável",
            Descricao = "Margens de estabilidade: PM (phase margin) em frequência ω_cg onde |L|=1 (crossover ganho); GM (gain margin) em ω_pc onde ∠L=−180° (crossover fase). Regra prática: PM>45°, GM>6dB para robustez. Relaciona com amortecimento: PM≈100ζ (graus) para 2ª ordem. Diagrama de Bode analisa margens graficamente.",
            Criador = "Hendrik Bode (1945, Network Analysis and Feedback Amplifier Design)",
            AnoOrigin = "1945",
            ExemploPratico = "Sistema instável: PM<0 ou GM<0dB. Especificação robusta: PM≥60°, GM≥10dB. LQR garante PM≥60° e GM=∞. Lead compensator aumenta PM. Lag compensator aumenta GM.",
            Unidades = "PM em °, GM em dB",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "phase_at_wgc", Nome = "∠L(jω_cg)", Unidade = "°", ValorPadrao = -120, ValorMax = -1, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "mag_at_wpc", Nome = "|L(jω_pc)|", Unidade = "adim", ValorPadrao = 0.5, ValorMin = 0.01, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => { double PM = 180 + v["phase_at_wgc"]; double GM = 20 * Math.Log10(1.0 / v["mag_at_wpc"]); return PM; }, // retorna PM
            VariavelResultado = "Phase Margin", UnidadeResultado = "°",
            Icone = "∑",
        };

        private Formula V9_CTRL070_ControleHInfinity() => new Formula
        {
            Id = "V9-CTRL070", CodigoCompendio = "070", Nome = "Controle H∞ (H-Infinity)",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "||T_zw||_∞ < γ; norma H∞ do operador entrada-saída",
            ExprTexto = "Minimiza ganho pior-caso de perturbação a saída",
            Descricao = "Controle H∞: framework de controle robusto que minimiza norma H∞ da função transferência T_zw (perturbação w → saída z). ||T||_∞=sup_ω σ̄[T(jω)] (maior valor singular). Formulação: encontrar controlador K tal que ||T_zw||_∞<γ via Riccati equations ou LMIs. Robustez contra incertezas não-parametrizadas.",
            Criador = "George Zames (1981, Feedback and Optimal Sensitivity); Doyle-Glover-Khargonekar-Francis (1989, State-Space Solutions)",
            AnoOrigin = "1981",
            ExemploPratico = "Rejeição distúrbio + tracking: pesa S (sensibilidade) e T (complementar). μ-synthesis: iteração D-K para incertezas estruturadas. Aplicações: controle robusto aeronaves (wind gusts), antivibração.",
            Unidades = "adimensional (norma)",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "gamma", Nome = "Nível γ", Unidade = "adim", ValorPadrao = 1.5, ValorMin = 1, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["gamma"],
            VariavelResultado = "Nível H∞", UnidadeResultado = "adimensional",
            Icone = "∑",
        };

        // Continua fórmulas 071-082 (mais 12)...
        private Formula V9_CTRL071_AlocacaoPolos() => new Formula
        {
            Id = "V9-CTRL071", CodigoCompendio = "071", Nome = "Alocação de Polos via Realimentação de Estado",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "u = −Kx; polos desejados λ_i via det(sI−A+BK)=0",
            ExprTexto = "Escolhe K para colocar polos em malha fechada em λ_i desejados",
            Descricao = "Pole placement: técnica para estabilizar/ajustar resposta de sistema linear via feedback u=−Kx. Controlabilidade garante existência de K. Fórmula de Ackermann (SISO): K=−[0...0 1][B AB...A^{n−1}B]⁻¹α(A) onde α(s)=polinômio desejado. Bass-Gura (MIMO). Trade-off: polos muito rápidos requerem controle grande.",
            Criador = "J. Ackermann (1972, fórmula Ackermann para SISO); R. Bass e I. Gura (1965, MIMO)",
            AnoOrigin = "1965",
            ExemploPratico = "Sistema instável s/(s−2): realocar polo −2→−5 para resposta mais rápida. Matlab: K=place(A,B,poles). Observer-based control: separa design controlador e estimador (separation principle).",
            Unidades = "matriz ganho",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "polo_desejado", Nome = "λ desejado", Unidade = "rad/s", ValorPadrao = -5, ValorMax = -0.1, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["polo_desejado"],
            VariavelResultado = "Polo alocado", UnidadeResultado = "rad/s",
            Icone = "∑",
        };

        private Formula V9_CTRL072_ObservadorLuenberger() => new Formula
        {
            Id = "V9-CTRL072", CodigoCompendio = "072", Nome = "Observador de Luenberger",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "x̂̇ = Ax̂ + Bu + L(y − Cx̂); erro e=x−x̂: ė=(A−LC)e",
            ExprTexto = "Estimador de estado com ganho L ajustável",
            Descricao = "Observador de Luenberger: reconstrui estado não-medido x̂ a partir de entrada u e saída y. Dinâmica do erro ė=(A−LC)e, convergência se escolher L tal que (A−LC) estável. Observabilidade garante existência de L. Princípio de separação: design controlador K e observador L independentes, sistema u=−Kx̂ estável se ambos estáveis.",
            Criador = "David Luenberger (1964, Observing the State of a Linear System); Rudolf Kalman (1960, conceito dual)",
            AnoOrigin = "1964",
            ExemploPratico = "Motor DC: mede corrente, estima velocidade. Robô: IMU mede aceleração, observador estima posição. Dual LQR: Kalman filter é observador ótimo estocástico. Pole placement: alocar polos de (A−LC) mais rápidos que malha fechada.",
            Unidades = "estado",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "y", Nome = "Saída medida", Unidade = "m", ValorPadrao = 5, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "C_x_hat", Nome = "Cx̂", Unidade = "m", ValorPadrao = 4.8, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "L", Nome = "Ganho L", Unidade = "adim", ValorPadrao = 10, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["L"] * (v["y"] - v["C_x_hat"]), // correção L(y−Cx̂)
            VariavelResultado = "Correção observador", UnidadeResultado = "m/s",
            Icone = "∑",
        };

        private Formula V9_CTRL073_ControleAdaptativoMRAC() => new Formula
        {
            Id = "V9-CTRL073", CodigoCompendio = "073", Nome = "Controle Adaptativo por Modelo de Referência (MRAC)",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "e=x−x_m; θ̇=−Γe'PB (MIT rule); x_m=modelo referência",
            ExprTexto = "Ajusta parâmetros online para seguir modelo referência",
            Descricao = "MRAC: controlador adaptativo que ajusta parâmetros θ online para que planta siga modelo de referência x_m. Lei de adaptação θ̇=−Γe'PB (MIT rule) ou Lyapunov-based. Garante estabilidade se persistency of excitation. Lida com incertezas paramétricas. Direct MRAC ajusta controle, indirect MRAC identifica planta primeiro.",
            Criador = "H.P. Whitaker (1958, MIT Instrumentation Lab); início teoria moderna: Narendra-Valavani (1978)",
            AnoOrigin = "1958",
            ExemploPratico = "Aeronave: parâmetros aerodinâmicos variam com altitude/velocidade, MRAC adapta. Robô: carga desconhecida, controlador ajusta torques. F-16 VISTA: testbed controle adaptativo. Requisito: sinal de referência deve ser rico (PE condition).",
            Unidades = "parâmetro",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "e", Nome = "Erro tracking", Unidade = "m", ValorPadrao = 0.1, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "Gamma", Nome = "Taxa adaptação", Unidade = "1/s", ValorPadrao = 5, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => -v["Gamma"] * v["e"], // θ̇ simplificado 1D
            VariavelResultado = "θ̇ adaptação", UnidadeResultado = "param/s",
            Icone = "∑",
        };

        private Formula V9_CTRL074_CondicoesLMI() => new Formula
        {
            Id = "V9-CTRL074", CodigoCompendio = "074", Nome = "Condições LMI (Linear Matrix Inequality)",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "PA + A'P + Q ≺ 0 (definida negativa); P≻0",
            ExprTexto = "Lyapunov estabilidade via LMI convexo",
            Descricao = "LMI: desigualdade matricial linear F(x)=F₀+Σx_iF_i≺0 (semidefinida negativa). Aparece em Lyapunov stability, H∞ control, LQR, estimação robusta. Convexidade permite solução eficiente via interior-point methods (Boyd, Ghaoui). CVX, YALMIP, SeDuMi: solvers LMI. Reformula problemas não-convexos em convexos aproximados.",
            Criador = "Yakubovich-Kalman-Popov lemma (1960s); Stephen Boyd e Laurent El Ghaoui (1994, livro LMIs in Control)",
            AnoOrigin = "1960",
            ExemploPratico = "Estabilidade: encontrar P≻0 tal que PA+A'P≺0 (Lyapunov LMI). H2/H∞ synthesis: resolvem via LMI. Robust control: incertezas politópicas → LMI. Matlab: feasp, gevp functions.",
            Unidades = "matriz",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "lambda_max", Nome = "λ_max(LMI)", Unidade = "adim", ValorPadrao = -0.5, ValorMax = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["lambda_max"] < 0 ? 1.0 : 0.0, // 1=LMI satisfeita
            VariavelResultado = "LMI factível", UnidadeResultado = "bool",
            Icone = "∑",
        };

        private Formula V9_CTRL075_CriterioEstabilidadeNyquist() => new Formula
        {
            Id = "V9-CTRL075", CodigoCompendio = "075", Nome = "Critério de Estabilidade de Nyquist",
            Categoria = "Volume IX", SubCategoria = "Sistemas Dinâmicos",
            Expressao = "N = Z − P; N = núm envolvimentos de −1 no diagrama Nyquist",
            ExprTexto = "Contagem de envolvimentos determina estabilidade malha fechada",
            Descricao = "Teorema de Nyquist: sistema em malha fechada é estável se N (número de envolvimentos de ponto crítico −1+j0 no diagrama Nyquist de L(jω)) equals Z−P onde Z=polos instáveis MF, P=polos instáveis MA. Para estabilidade: N=−P (cancela polos instáveis MA). Gráfico: L(jω) no plano complexo para ω:0→∞.",
            Criador = "Harry Nyquist (1932, Regeneration Theory, Bell System Technical Journal)",
            AnoOrigin = "1932",
            ExemploPratico = "Sistema estável MA (P=0): Nyquist plot não envolve −1 → MF estável. Sistema instável MA (P≠0): requer N=−P envolvimentos. Margem ganho/fase: distância do Nyquist plot a −1. Feedback amplifiers: Nyquist evita Bode limitations.",
            Unidades = "contagem",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "N", Nome = "Envolvimentos", Unidade = "contagem", ValorPadrao = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "P", Nome = "Polos instáveis MA", Unidade = "contagem", ValorPadrao = 0, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["N"] + v["P"], // Z=N+P: polos instáveis MF
            VariavelResultado = "Z polos instáveis MF", UnidadeResultado = "contagem",
            Icone = "∑",
        };

        private Formula V9_CTRL076_TeoriaFloquet() => new Formula
        {
            Id = "V9-CTRL076", CodigoCompendio = "076", Nome = "Teoria de Floquet - Sistemas Periódicos",
            Categoria = "Volume IX", SubCategoria = "Sistemas Dinâmicos",
            Expressao = "x(t)=Φ(t)e^{Bt}c; Φ(t+T)=Φ(t); multiplicadores Floquet ρ=e^{μT}",
            ExprTexto = "Estabilidade via multiplicadores de Floquet",
            Descricao = "Teoria de Floquet: sistemas LTV periódicos ẋ=A(t)x com A(t+T)=A(t) têm solução x(t)=Φ(t)e^{Bt}c onde Φ periódica. Multiplicadores Floquet ρ=autovalores de Φ(T): |ρ|<1 → estável. Expoentes Floquet μ: ρ=e^{μT}. Generaliza autovalores para sistemas periódicos. Hill's equation caso especial.",
            Criador = "Gaston Floquet (1883, Sur les équations différentielles linéaires à coefficients périodiques)",
            AnoOrigin = "1883",
            ExemploPratico = "Órbitas satelitárias: órbita elíptica cria A(t) periódica. Helicopter rotor dynamics: estabilidade em hovering. Mathieu equation ÿ+(a+2qcos(2t))y=0: estável se (a,q) em regiões estabilidade. Quantum: estados Wannier-Stark.",
            Unidades = "adimensional",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "rho", Nome = "Multiplicador Floquet", Unidade = "adim", ValorPadrao = 0.95, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => Math.Abs(v["rho"]) < 1.0 ? 1.0 : 0.0, // 1=estável
            VariavelResultado = "Estabilidade Floquet", UnidadeResultado = "bool",
            Icone = "∑",
        };

        private Formula V9_CTRL077_ControleDiscreto() => new Formula
        {
            Id = "V9-CTRL077", CodigoCompendio = "077", Nome = "Controle em Tempo Discreto - Transformada Z",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "x[k+1] = Φx[k] + Γu[k]; Φ=e^{AT}, Γ=∫₀ᵀe^{Aτ}dτ·B",
            ExprTexto = "Discretização de sistema contínuo para implementação digital",
            Descricao = "Controle discreto: amostragem de sistema contínuo ẋ=Ax+Bu com período T gera sistema discreto x[k+1]=Φx[k]+Γu[k]. Φ matriz de transição, Γ ganho de entrada discreto. Transformada Z análoga a Laplace: X(z)=Z{x[k]}. Polos em |z|<1 para estabilidade. Zero-order hold (ZOH) assume u constante entre amostras.",
            Criador = "John R. Ragazzini e Lotfi Zadeh (1952, extensão sampled-data theory); teorema amostragem Shannon (1949)",
            AnoOrigin = "1952",
            ExemploPratico = "Controlador digital: DSP ou microcontrolador com T=1ms. PID discreto: método trapezoidal, backward difference, Tustin. Aliasing: Nyquist frequency ω_s/2, precisa ω<ω_s/2. Matlab: c2d(sys,T,'zoh').",
            Unidades = "matriz",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "A", Nome = "Matriz A", Unidade = "1/s", ValorPadrao = -2, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "T", Nome = "Período amostragem", Unidade = "s", ValorPadrao = 0.1, ValorMin = 0.001, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => Math.Exp(v["A"] * v["T"]), // Φ=e^{AT} escalar
            VariavelResultado = "Φ discreto", UnidadeResultado = "adimensional",
            Icone = "∑",
        };

        private Formula V9_CTRL078_EstabilidadeLyapunovDiscreta() => new Formula
        {
            Id = "V9-CTRL078", CodigoCompendio = "078", Nome = "Estabilidade Lyapunov Discreta",
            Categoria = "Volume IX", SubCategoria = "Sistemas Dinâmicos",
            Expressao = "Φ'PΦ − P = −Q ≺ 0; P≻0 ⇒ estável",
            ExprTexto = "Equação Lyapunov discreta para x[k+1]=Φx[k]",
            Descricao = "Lyapunov discreto: sistema x[k+1]=Φx[k] é estável se existe P≻0 tal que Φ'PΦ−P≺0 (equivalente: Φ'PΦ−P=−Q com Q≻0). Pode escolher Q=I. Equivalente a autovalores de Φ em |λ|<1. Função Lyapunov V[k]=x[k]'Px[k], ΔV[k]=V[k+1]−V[k]=−x[k]'Qx[k]<0.",
            Criador = "Extensão discreta de Lyapunov (1892) desenvolvida anos 1960 com computadores digitais",
            AnoOrigin = "1960",
            ExemploPratico = "Verifica estabilidade malha fechada Φ=A−BK discreto. Resolve Φ'PΦ−P+Q=0 via dlyap(Φ',Q) Matlab. Se P≻0, sistema estável. Usado em MPC, controle preditivo.",
            Unidades = "matriz",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "lambda_max_Phi", Nome = "max|λ(Φ)|", Unidade = "adim", ValorPadrao = 0.95, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["lambda_max_Phi"] < 1.0 ? 1.0 : 0.0, // 1=estável
            VariavelResultado = "Estável discreto", UnidadeResultado = "bool",
            Icone = "∑",
        };

        private Formula V9_CTRL079_BifurcacaoHopf() => new Formula
        {
            Id = "V9-CTRL079", CodigoCompendio = "079", Nome = "Bifurcação de Hopf",
            Categoria = "Volume IX", SubCategoria = "Sistemas Dinâmicos",
            Expressao = "dx/dt=μx−y−x(x²+y²); dy/dt=x+μy−y(x²+y²); μ=0 bifurcação",
            ExprTexto = "Surgimento de ciclo limite periódico via mudança de estabilidade",
            Descricao = "Bifurcação de Hopf: equilíbrio perde estabilidade e ciclo limite periódico emerge conforme parâmetro μ cruza valor crítico μ_c. Supercrítica: ciclo limite estável nasce (μ>μ_c). Subcrítica: ciclo limite instável existe (μ<μ_c), salto para outro atrator. Requer par de autovalores complexos conjugados cruzando eixo imaginário.",
            Criador = "Eberhard Hopf (1942, Abzweigung einer periodischen Lösung von einer stationären); Andronov-Witt (1930, oscilações auto-excitadas)",
            AnoOrigin = "1942",
            ExemploPratico = "Oscilador van der Pol: Hopf em μ=0. Predador-presa com ciclos. Laser: Hopf gera oscilações relaxação. Neurônios: Hodgkin-Huxley oscilações via Hopf. Clima: El Niño ciclo limite.",
            Unidades = "depende do sistema",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "mu", Nome = "Parâmetro bifurcação μ", Unidade = "adim", ValorPadrao = 0.1, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["mu"] > 0 ? 1.0 : 0.0, // 1=ciclo limite existe (supercrítico)
            VariavelResultado = "Ciclo limite", UnidadeResultado = "bool",
            Icone = "∑",
        };

        private Formula V9_CTRL080_ControlePreditivo() => new Formula
        {
            Id = "V9-CTRL080", CodigoCompendio = "080", Nome = "Controle Preditivo Baseado em Modelo (MPC)",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "min Σ_{k=0}^N (||y_k−r_k||²_Q + ||u_k||²_R) s.a. x_{k+1}=Ax_k+Bu_k",
            ExprTexto = "Otimização receding horizon com constraints",
            Descricao = "MPC: a cada passo, resolve problema de otimização finita sobre horizonte N prevendo futuro, aplica apenas primeiro controle u₀, repete (receding horizon). Lida naturalmente com constraints (u_min≤u≤u_max, y_min≤y≤y_max). Modelo prediz trajetória futura. Quadratic Programming (QP) se linear. Amplamente usado em indústria química, refinarias.",
            Criador = "J. Richalet (1978, Model Algorithmic Control IDCOM); C. Cutler e B. Ramaker (1979, Dynamic Matrix Control DMC)",
            AnoOrigin = "1978",
            ExemploPratico = "Refinaria petróleo: MPC controla colunas destilação (10-100 entradas/saídas, constraints). Veículos autônomos: MPC para trajeto ótimo com obstáculos. Tesla Autopilot: MPC layer. Teoria: estabilidade requer terminal cost/constraint.",
            Unidades = "custo",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "N", Nome = "Horizonte predição", Unidade = "passos", ValorPadrao = 10, ValorMin = 1, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "Q", Nome = "Peso Q saída", Unidade = "adim", ValorPadrao = 10, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "R", Nome = "Peso R entrada", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["N"] * (v["Q"] + v["R"]), // aproximação custo
            VariavelResultado = "Custo MPC aprox", UnidadeResultado = "adimensional",
            Icone = "∑",
        };

        private Formula V9_CTRL081_CriterioRouthHurwitz() => new Formula
        {
            Id = "V9-CTRL081", CodigoCompendio = "081", Nome = "Critério de Routh-Hurwitz",
            Categoria = "Volume IX", SubCategoria = "Sistemas Dinâmicos",
            Expressao = "a(s)=a_n s^n+...+a₁s+a₀; tabela Routh: mudanças sinal = raízes RHP",
            ExprTexto = "Teste algébrico de estabilidade sem calcular raízes",
            Descricao = "Critério de Routh-Hurwitz: algoritmo para determinar número de raízes de polinômio em semiplano direito (instáveis) sem resolver polinômio. Constrói tabela de Routh: 1ª coluna, mudanças de sinal = raízes RHP. Sistema estável ⟺ 1ª coluna toda positiva. Alternativa: Hurwitz determinants.",
            Criador = "Edward Routh (1877, Treatise on Stability of Motion); Adolf Hurwitz (1895, determinantes)",
            AnoOrigin = "1877",
            ExemploPratico = "s³+3s²+3s+1: tabela Routh toda positiva → estável. s²+s−2: mudança sinal → 1 raiz RHP, instável. Usado antes de computadores para testar estabilidade. Hoje: roots() função direta, mas Routh útil para parâmetros simbólicos.",
            Unidades = "contagem",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "n_sign_changes", Nome = "Mudanças sinal", Unidade = "contagem", ValorPadrao = 0, ValorMin = 0, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["n_sign_changes"] == 0 ? 1.0 : 0.0, // 1=estável
            VariavelResultado = "Estável Routh", UnidadeResultado = "bool",
            Icone = "∑",
        };

        private Formula V9_CTRL082_SistemasFlatDiferencial() => new Formula
        {
            Id = "V9-CTRL082", CodigoCompendio = "082", Nome = "Sistemas Flat - Linearização Diferencial",
            Categoria = "Volume IX", SubCategoria = "Controle Ótimo",
            Expressao = "x=φ(y,ẏ,...,y⁽ᵅ⁾); u=ψ(y,ẏ,...,y⁽ᵝ⁾); y=saída flat",
            ExprTexto = "Estados e controles expressam-se algebricamente via saída flat y",
            Descricao = "Sistema flat (differentially flat): existe saída y (flat output) tal que todos estados x e controles u expressam-se algebricamente em função de y e derivadas finitas. Permite planejamento trajetória: especificar y(t) → x(t),u(t) sem integrar EDO. Lineariza sistema via feedback. Classe importante de sistemas não-lineares controláveis.",
            Criador = "Michel Fliess, Jean Lévine, Philippe Martin, Pierre Rouchon (1992-95, teoria flatness diferencial)",
            AnoOrigin = "1992",
            ExemploPratico = "Quadrotor: posição (x,y,z) e yaw ψ são flat outputs → roll φ, pitch θ, thrust T algebricamente. Trailer reverse: posição traseira flat. VTOL aircraft flat. Planejamento: polynomial splines para y(t), garante suavidade.",
            Unidades = "depende do sistema",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "y", Nome = "Saída flat", Unidade = "m", ValorPadrao = 5, Obrigatoria = true, Descricao = "Parâmetro de entrada." },
                new Variavel { Simbolo = "y_dot", Nome = "ẏ", Unidade = "m/s", ValorPadrao = 1, Obrigatoria = true, Descricao = "Parâmetro de entrada." }
            },
            Calcular = v => v["y"] + v["y_dot"], // exemplo simplificado x=φ(y,ẏ)
            VariavelResultado = "Estado x via flatness", UnidadeResultado = "m",
            Icone = "∑",
        };
    }
}
