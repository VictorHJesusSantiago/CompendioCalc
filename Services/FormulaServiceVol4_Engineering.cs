using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 4 — PARTE IV: ENGENHARIA AVANÇADA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 15. CONTROLE NÃO-LINEAR E CONTROLE ÓTIMO
    // ─────────────────────────────────────────────────────
    private void AdicionarControleNaoLinearOtimo()
    {
        _formulas.AddRange([
            // 15.1 Controle Não-Linear
            new Formula
            {
                Id = "4_nl01", Nome = "Linearização por Realimentação", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "u = (1/LgLfⁿ⁻¹h)(v - Lfⁿh)",
                ExprTexto = "u = (v−Lf^nh)/(LgLf^{n-1}h)",
                Icone = "FBL",
                Descricao = "Transforma sistema não-linear em linear via mudança de variáveis e controle u. Derivadas de Lie Lf: grau relativo r = ordem mínima onde entrada aparece. Sistema SISO com r=n: linearização exata.",
            },
            new Formula
            {
                Id = "4_nl02", Nome = "Derivada de Lie", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "Lfh = (∂h/∂x)·f(x);  Lfᵏh = Lf(Lf^{k-1}h)",
                ExprTexto = "Lfh = ∇h·f; Lfᵏh = Lf(Lf^{k-1}h)",
                Icone = "Lf",
                Descricao = "Derivada direcional ao longo do campo vetorial f. Essencial em controle não-linear: acessibilidade, observabilidade, grau relativo são expressos via derivadas de Lie.",
            },
            new Formula
            {
                Id = "4_nl03", Nome = "Backstepping", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "Sistema em forma triangular; cada passo adiciona Lyapunov",
                ExprTexto = "x₁→x₂→⋯→u: design recursivo de Lyapunov",
                Icone = "←",
                Descricao = "Design recursivo para sistemas em forma cascata estrita: trata cada estado como 'controle virtual' do subsistema anterior. Soma funções de Lyapunov parciais. Garante estabilidade global.",
            },
            new Formula
            {
                Id = "4_nl04", Nome = "Sliding Mode Control (SMC)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "s(x) = 0 (superfície);  u = u_eq + u_sw;  u_sw = -K·sign(s)",
                ExprTexto = "u = u_eq−K·sign(s); s(x)=0",
                Icone = "SMC",
                Descricao = "Força trajetória para superfície de deslizamento s=0 via controle descontínuo. Robusto a incertezas e perturbações matching. Chattering = vibração de alta frequência (solução: boundary layer).",
            },
            new Formula
            {
                Id = "4_nl05", Nome = "MRAC (Controle Adaptativo)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "θ̇ = -Γ·e·φ;  e = y - y_m (erro de modelo)",
                ExprTexto = "θ̇ = −Γeφ; e = y−yₘ",
                Icone = "MRAC",
                Descricao = "Model Reference Adaptive Control: ajusta parâmetros θ online para rastrear modelo de referência. Γ = ganho de adaptação. Baseado em Lyapunov ou passividade.",
            },
            new Formula
            {
                Id = "4_nl06", Nome = "Estabilidade de Lyapunov (Revisitada)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "V(x)>0, V̇(x)≤-W(x)<0 ⟹ estabilidade assintótica global",
                ExprTexto = "V>0, V̇≤−W<0 ⟹ GAS",
                Icone = "V̇",
                Descricao = "Função de Lyapunov: 'energia generalizada' que decresce ao longo de trajetórias. V>0 e V̇<0 ⟹ equilíbrio estável. LaSalle: V̇≤0 basta se {V̇=0} não contém trajetórias não-triviais.",
            },
            new Formula
            {
                Id = "4_nl07", Nome = "CLF (Control Lyapunov Function)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "inf_u (LfV + LgV·u) < 0  ∀x≠0",
                ExprTexto = "inf_u(LfV+LgV·u)<0 ∀x≠0",
                Icone = "CLF",
                Descricao = "V é CLF se existe controle u que faz V̇<0 para todo x≠0. Sontag's formula: u = -kV·LgV se LgV≠0. Paradigma: encontrar CLF → controle segue automaticamente.",
                Criador = "Eduardo Sontag",
                AnoOrigin = "1983",
            },
            new Formula
            {
                Id = "4_nl08", Nome = "CBF (Control Barrier Function)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "LfB + LgB·u + α(B) ≥ 0  (mantém B(x)≥0)",
                ExprTexto = "LfB+LgB·u+α(B)≥0 → segurança",
                Icone = "CBF",
                Descricao = "Garante que estado nunca sai do conjunto seguro {B(x)≥0}. Combinado com CLF via QP: min ‖u-u_nom‖² s.t. CLF e CBF. Controle seguro com garantias formais.",
            },
            new Formula
            {
                Id = "4_nl09", Nome = "Passividade", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "V̇ ≤ u'y  (entrada u, saída y, storage V)",
                ExprTexto = "V̇ ≤ u'y (passividade)",
                Icone = "pass",
                Descricao = "Sistema passivo: energia armazenada ≤ energia fornecida. Interconexão de sistemas passivos é passiva. Feedback negativo de passivo → estável. Teoria de portas (Willems).",
            },
            new Formula
            {
                Id = "4_nl10", Nome = "Gain Scheduling", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "u = K(ρ)·x;  ρ = parâmetro variável (scheduling var.)",
                ExprTexto = "u = K(ρ)x; ρ=scheduling variable",
                Icone = "GS",
                Descricao = "Família de controladores lineares K(ρ) parametrizada por variável de scheduling ρ (ponto de operação). LPV → interpola entre múltiplos designs lineares. Usado em aviação, motores.",
            },
            // 15.2 Controle Ótimo
            new Formula
            {
                Id = "4_oc01", Nome = "Princípio Máximo de Pontryagin", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "max_u H(x,p,u);  ẋ=∂H/∂p, ṗ=-∂H/∂x",
                ExprTexto = "maxᵤ H(x,p,u); ẋ=∂H/∂p; ṗ=−∂H/∂x",
                Icone = "PMP",
                Descricao = "Condição necessária para controle ótimo: Hamiltoniano H=p'f+L maximizado em u. Equações adjuntas ṗ=-∂H/∂x. Condições de transversalidade nos tempos inicial/final.",
                Criador = "Lev Pontryagin et al.",
                AnoOrigin = "1956",
            },
            new Formula
            {
                Id = "4_oc02", Nome = "Regulador Linear Quadrático (LQR)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "min ∫(x'Qx + u'Ru)dt;  u* = -R⁻¹B'Px",
                ExprTexto = "min∫(x'Qx+u'Ru)dt; u*=−R⁻¹B'Px",
                Icone = "LQR",
                Descricao = "Controle ótimo para sistema linear com custo quadrático: solução em forma de feedback u=-Kx. P = solução da equação algébrica de Riccati. Margens de estabilidade garantidas (60° fase, ∞ ganho).",
            },
            new Formula
            {
                Id = "4_oc03", Nome = "Equação de Riccati (Algébrica)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "A'P + PA - PBR⁻¹B'P + Q = 0",
                ExprTexto = "A'P+PA−PBR⁻¹B'P+Q=0",
                Icone = "ARE",
                Descricao = "Equação algébrica (tempo infinito) ou diferencial (tempo finito) de Riccati. Solução P define ganho ótimo K=R⁻¹B'P. Existência: (A,B) controlável, (A,Q½) observável.",
            },
            new Formula
            {
                Id = "4_oc04", Nome = "Equação de Hamilton-Jacobi-Bellman", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "min_u [L(x,u) + ∇V·f(x,u)] = 0  (V = valor ótimo)",
                ExprTexto = "minᵤ[L+∇V·f]=0 (HJB)",
                Icone = "HJB",
                Descricao = "EDP para função valor ótima V(x,t). Suficiente (não apenas necessário como PMP). Caso linear-quadrático → Riccati. Em geral: maldição da dimensionalidade. Soluções viscosas.",
            },
            new Formula
            {
                Id = "4_oc05", Nome = "Controle Bang-Bang", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "H = p'f(x) + p'g(x)u → u* = u_max·sign(p'g)",
                ExprTexto = "u* = u_max·sign(p'g) (bang-bang)",
                Icone = "⬛",
                Descricao = "Quando H é linear em u com u limitado: controle ótimo alterna entre extremos. Solução típica de tempo mínimo com saturação. Número de switchings determinado pela dimensão.",
            },
            new Formula
            {
                Id = "4_oc06", Nome = "Model Predictive Control (MPC)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "min_{u₀,...,u_{N-1}} Σ l(xₖ,uₖ) + V_f(x_N)  s.t. xₖ₊₁=f(xₖ,uₖ)",
                ExprTexto = "min Σl(x,u)+V_f(x_N) s.t. dinâmica+restrições",
                Icone = "MPC",
                Descricao = "Otimização online em horizonte finito N: resolve a cada passo, aplica u₀, recede horizonte. Trata restrições de estado/controle explicitamente. Padrão industrial (processos químicos, robótica).",
            },
            new Formula
            {
                Id = "4_oc07", Nome = "Programação Dinâmica (Bellman)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "V*(xₖ) = min_u [l(xₖ,u) + V*(f(xₖ,u))]",
                ExprTexto = "V*(xₖ) = minᵤ[l+V*(f(xₖ,u))]",
                Icone = "DP",
                Descricao = "Princípio de otimalidade: suficiente e necessário. Backward induction para tempo discreto. Contínuo → HJB. Computacionalmente: O(|S|²|A|) por iteração, maldição da dimensionalidade.",
                Criador = "Richard Bellman",
                AnoOrigin = "1957",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 16. DISPOSITIVOS SEMICONDUTORES
    // ─────────────────────────────────────────────────────
    private void AdicionarDispositivosSemicondutores()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_sc01", Nome = "Equação de Poisson (Semicondutor)", Categoria = "Dispositivos Semicondutores", SubCategoria = "Equações Fundamentais",
                Expressao = "∇²φ = -q(p-n+N⁺_D-N⁻_A)/ε",
                ExprTexto = "∇²φ = −q(p−n+N_D−N_A)/ε",
                Icone = "∇²",
                Descricao = "Relaciona potencial eletrostático φ com densidades de carga: buracos p, elétrons n, doadores ionizados N_D⁺, aceitadores N_A⁻. Base da simulação de dispositivos.",
            },
            new Formula
            {
                Id = "4_sc02", Nome = "Equação de Continuidade (Elétrons)", Categoria = "Dispositivos Semicondutores", SubCategoria = "Equações Fundamentais",
                Expressao = "∂n/∂t = (1/q)∇·Jₙ + G - R",
                ExprTexto = "∂n/∂t = (1/q)∇·Jₙ+G−R",
                Icone = "∂n",
                Descricao = "Conservação de portadores: variação temporal = divergência de corrente + geração G - recombinação R. Analogamente para buracos com sinal oposto da corrente.",
            },
            new Formula
            {
                Id = "4_sc03", Nome = "Corrente Drift-Diffusion", Categoria = "Dispositivos Semicondutores", SubCategoria = "Equações Fundamentais",
                Expressao = "Jₙ = qnμₙE + qDₙ∇n;  Jₚ = qpμₚE - qDₚ∇p",
                ExprTexto = "Jₙ = qnμₙE+qDₙ∇n; Jₚ = qpμₚE−qDₚ∇p",
                Icone = "J",
                Descricao = "Corrente = drift (campo E) + difusão (gradiente de concentração). μ = mobilidade, D = coeficiente de difusão. Modelo padrão para simulação de dispositivos.",
            },
            new Formula
            {
                Id = "4_sc04", Nome = "Relação de Einstein", Categoria = "Dispositivos Semicondutores", SubCategoria = "Equações Fundamentais",
                Expressao = "Dₙ/μₙ = kT/q = V_T ≈ 26 mV (300K)",
                ExprTexto = "D/μ = kT/q = V_T ≈ 26mV",
                Icone = "V_T",
                Descricao = "Relaciona difusão e mobilidade via potencial térmico. V_T = kT/q ≈ 26 mV a 300K. Consequência do equilíbrio termodinâmico (fluctuation-dissipation).",
            },
            new Formula
            {
                Id = "4_sc05", Nome = "Recombinação SRH", Categoria = "Dispositivos Semicondutores", SubCategoria = "Recombinação",
                Expressao = "R = (np-nᵢ²)/(τₚ(n+n₁)+τₙ(p+p₁))",
                ExprTexto = "R_SRH = (np−nᵢ²)/(τₚ(n+n₁)+τₙ(p+p₁))",
                Icone = "SRH",
                Descricao = "Recombinação Shockley-Read-Hall via armadilhas (defeitos). Dominante em semicondutores indiretos (Si, Ge). τᵢ = tempo de vida. No equilíbrio np=nᵢ² → R=0.",
                Criador = "Shockley / Read / Hall",
                AnoOrigin = "1952",
            },
            new Formula
            {
                Id = "4_sc06", Nome = "Equação do Diodo de Shockley", Categoria = "Dispositivos Semicondutores", SubCategoria = "Junção p-n",
                Expressao = "I = I_s(e^{V/nV_T} - 1)",
                ExprTexto = "I = Iₛ(e^{V/nV_T}−1)",
                Icone = "diodo",
                Descricao = "Característica I-V da junção p-n. Iₛ = corrente de saturação reversa. n = fator de idealidade (1-2). Exponencial em direta, saturação em reversa. Dá ~0.7V para Si.",
                Criador = "William Shockley",
                AnoOrigin = "1949",
            },
            new Formula
            {
                Id = "4_sc07", Nome = "Largura da Região de Depleção", Categoria = "Dispositivos Semicondutores", SubCategoria = "Junção p-n",
                Expressao = "W = √(2ε(Vbi-V)(1/NA+1/ND)/q)",
                ExprTexto = "W = √(2ε(Vbi−V)(N_A⁻¹+N_D⁻¹)/q)",
                Icone = "W",
                Descricao = "Zona de depleção em junção p-n abrupta. Vbi = potencial built-in. Cresce com reversa (V<0), diminui com direta. C = εA/W → capacitância variável (varactor).",
            },
            new Formula
            {
                Id = "4_sc08", Nome = "Potencial Built-in", Categoria = "Dispositivos Semicondutores", SubCategoria = "Junção p-n",
                Expressao = "V_bi = (kT/q)ln(N_A·N_D/nᵢ²)",
                ExprTexto = "Vbi = (kT/q)ln(NA·ND/nᵢ²)",
                Icone = "Vbi",
                Descricao = "Barreira de potencial no equilíbrio: ~0.7V para Si, ~0.3V para Ge, ~1.1V para GaAs. Determina tensão de threshold do diodo e capacitância de depleção.",
            },
            new Formula
            {
                Id = "4_sc09", Nome = "Corrente de Saturação", Categoria = "Dispositivos Semicondutores", SubCategoria = "Junção p-n",
                Expressao = "I_s = qA(Dₚpₙ₀/Lₚ + Dₙnₚ₀/Lₙ)",
                ExprTexto = "Iₛ = qA(Dₚpₙ₀/Lₚ+Dₙnₚ₀/Lₙ)",
                Icone = "Iₛ",
                Descricao = "Corrente reversa de saturação: portadores minoritários difundindo pela junção. A = área, L = comprimento de difusão (√Dτ). Muito sensível à temperatura (dobra a cada ~10°C).",
            },
            new Formula
            {
                Id = "4_sc10", Nome = "MOSFET (Corrente Triodo)", Categoria = "Dispositivos Semicondutores", SubCategoria = "MOSFET",
                Expressao = "I_D = μₙCₒₓ(W/L)[(V_GS-V_th)V_DS - V²_DS/2]",
                ExprTexto = "I_D = μCox(W/L)[(VGS−Vth)VDS−VDS²/2]",
                Icone = "MOS",
                Descricao = "Região triodo (linear): V_DS < V_GS-V_th. Transistor age como resistência controlada. Cox = capacitância do óxido de gate. W/L = razão de aspecto.",
            },
            new Formula
            {
                Id = "4_sc11", Nome = "MOSFET (Corrente Saturação)", Categoria = "Dispositivos Semicondutores", SubCategoria = "MOSFET",
                Expressao = "I_D = (μₙCₒₓ/2)(W/L)(V_GS-V_th)²",
                ExprTexto = "I_D = (μCox/2)(W/L)(VGS−Vth)²",
                Icone = "sat",
                Descricao = "Região de saturação: V_DS ≥ V_GS-V_th. Corrente 'constante' (modulação de canal λ: I_D·(1+λV_DS)). Base de amplificadores e circuitos digitais. Quadrática em Vgs-Vth.",
            },
            new Formula
            {
                Id = "4_sc12", Nome = "Tensão de Threshold", Categoria = "Dispositivos Semicondutores", SubCategoria = "MOSFET",
                Expressao = "V_th = V_FB + 2φ_F + √(2εqNA·2φ_F)/Cₒₓ",
                ExprTexto = "Vth = VFB+2φF+Qd/Cox",
                Icone = "Vth",
                Descricao = "Tensão de gate para inversão do canal. VFB = flat-band, φF = potencial de Fermi no bulk, Qd = carga de depleção. Ajuste por implantação iônica.",
            },
            new Formula
            {
                Id = "4_sc13", Nome = "BJT (Corrente IC)", Categoria = "Dispositivos Semicondutores", SubCategoria = "BJT",
                Expressao = "I_C = I_S · e^{V_BE/V_T}",
                ExprTexto = "IC = IS·e^{VBE/VT}",
                Icone = "BJT",
                Descricao = "Transistor bipolar na região ativa: corrente de coletor exponencial na tensão base-emissor. β = IC/IB = ganho de corrente. Modelo de Ebers-Moll para todas regiões.",
            },
            new Formula
            {
                Id = "4_sc14", Nome = "Corrente de Tunelamento (FN)", Categoria = "Dispositivos Semicondutores", SubCategoria = "Efeitos Quânticos",
                Expressao = "J_FN = AE² exp(-B/E);  A,B dependem de m*, φ_B",
                ExprTexto = "J_FN = AE²exp(−B/E)",
                Icone = "FN",
                Descricao = "Tunelamento Fowler-Nordheim: corrente exponencial em 1/E. Limitante em óxidos ultrafinos (<2nm). Mecanismo de escrita em memórias Flash. A,B = constantes do material.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 17. TEORIA DA CODIFICAÇÃO E COMUNICAÇÕES
    // ─────────────────────────────────────────────────────
    private void AdicionarCodificacaoComunicacoes()
    {
        _formulas.AddRange([
            // 17.1 Codificação
            new Formula
            {
                Id = "4_cd01", Nome = "Capacidade do Canal AWGN", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "C = (1/2)log₂(1+SNR)  bits/símbolo",
                ExprTexto = "C = ½log₂(1+SNR) bits/uso",
                Icone = "AWGN",
                Descricao = "Limite de Shannon para canal gaussiano: taxa máxima com erro arbitrariamente pequeno. SNR = P/N₀B. Fundamental em telecomunicações. Códigos modernos (turbo, LDPC, polar) se aproximam.",
                Criador = "Claude Shannon",
                AnoOrigin = "1948",
            },
            new Formula
            {
                Id = "4_cd02", Nome = "Distância de Hamming", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "d(x,y) = |{i: xᵢ≠yᵢ}|;  d_min = min_{c≠c'} d(c,c')",
                ExprTexto = "d(x,y) = #{i:xᵢ≠yᵢ}; dmin = min d(c,c')",
                Icone = "d_H",
                Descricao = "Número de posições diferentes entre duas palavras-código. d_min determina capacidade de correção: corrige até ⌊(d_min-1)/2⌋ erros. Detecta até d_min-1 erros.",
                Criador = "Richard Hamming",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "4_cd03", Nome = "Bound de Singleton", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "d_min ≤ n-k+1  (código [n,k,d])",
                ExprTexto = "d ≤ n−k+1 (Singleton bound)",
                Icone = "Sing",
                Descricao = "Limite superior: distância mínima ≤ n-k+1. Códigos MDS (Maximum Distance Separable: Reed-Solomon) atingem igualdade. n=comprimento, k=dimensão.",
            },
            new Formula
            {
                Id = "4_cd04", Nome = "Códigos LDPC", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "H esparsa; decodificação por belief propagation (iterativa)",
                ExprTexto = "H esparsa; decode: message passing (BP)",
                Icone = "LDPC",
                Descricao = "Low-Density Parity-Check: matriz de paridade H esparsa. Decodificação iterativa por passagem de mensagens no grafo de Tanner. Performance próxima de Shannon. 5G NR, Wi-Fi 6.",
                Criador = "Robert Gallager (1963) / redescoberto 1990s",
            },
            new Formula
            {
                Id = "4_cd05", Nome = "Códigos Turbo", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "2 codificadores convolucionais + interleaver;  decode: iterativo",
                ExprTexto = "2 RSC + interleaver → decode iterativo",
                Icone = "turbo",
                Descricao = "Concatenação paralela de 2 codificadores recursivos com interleaver. Decodificação turbo (BCJR iterativo). Primeiro código a chegar perto de Shannon (~0.5 dB). 3G/4G.",
                Criador = "Claude Berrou / Alain Glavieux",
                AnoOrigin = "1993",
            },
            new Formula
            {
                Id = "4_cd06", Nome = "Códigos Polares", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "Polarização de canal: W→W⁺(bom),W⁻(ruim); n→∞ → capacidade",
                ExprTexto = "W→W⁺,W⁻ (Arıkan); atingem capacidade",
                Icone = "polar",
                Descricao = "Primeiro código provado alcançar capacidade com complexidade O(n log n). Polarização: canais se separam em perfeitos e inúteis. Enviar dados nos bons, congelar os ruins. 5G canal de controle.",
                Criador = "Erdal Arıkan",
                AnoOrigin = "2009",
            },
            new Formula
            {
                Id = "4_cd07", Nome = "Capacidade MIMO", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "C = log₂ det(I + (SNR/Nₜ)HH†)  bits/s/Hz",
                ExprTexto = "C = log₂det(I+SNR·HH†/Nt)",
                Icone = "MIMO",
                Descricao = "Capacidade cresce linearmente com min(Nₜ,Nᵣ) antenas (multiplexação espacial). H = matriz de canal Nr×Nt. Massive MIMO (5G): centenas de antenas na estação base.",
            },
            new Formula
            {
                Id = "4_cd08", Nome = "Fórmula de Alamouti (STBC)", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "X = [[s₁, -s₂*];[s₂, s₁*]]  (2×2 STBC, rate 1)",
                ExprTexto = "X = [[s₁,−s₂*],[s₂,s₁*]] (Alamouti)",
                Icone = "STBC",
                Descricao = "Código espácio-temporal para 2 antenas: taxa plena, diversidade máxima, decodificação linear (ML com complexidade linear). Usado em Wi-Fi (2×2) e LTE.",
                Criador = "Siavash Alamouti",
                AnoOrigin = "1998",
            },
            // 17.2 OFDM e Comunicações
            new Formula
            {
                Id = "4_of01", Nome = "OFDM (Orthogonal FDM)", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "x(t) = Σₖ Xₖ e^{j2πkΔft};  Δf = 1/T",
                ExprTexto = "x(t) = Σ Xₖe^{j2πkΔft}; Δf=1/T",
                Icone = "OFDM",
                Descricao = "Divide banda larga em subportadoras ortogonais estreitas: canal seletivo em frequência → múltiplos canais planos. IFFT no transmissor, FFT no receptor. 4G/5G, Wi-Fi, DVB.",
            },
            new Formula
            {
                Id = "4_of02", Nome = "Prefixo Cíclico", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "CP ≥ τ_max (delay spread máximo);  converte linear em circular",
                ExprTexto = "L_CP ≥ τmax; converte conv. linear→circular",
                Icone = "CP",
                Descricao = "Cópia da cauda do símbolo OFDM adicionada ao início. Transforma convolução linear do canal em circular → multiplicação no domínio da frequência. Elimina ISI entre símbolos.",
            },
            new Formula
            {
                Id = "4_of03", Nome = "PAPR (Peak-to-Average Power Ratio)", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "PAPR = max|x(t)|² / E[|x(t)|²] ≤ N (dB)",
                ExprTexto = "PAPR = max|x|²/𝔼[|x|²]",
                Icone = "PAPR",
                Descricao = "Problema do OFDM: soma de N subcarriers pode ter picos altos (até N·Pmédia). Requer amplificador com grande back-off → ineficiente. Soluções: clipping, SLM, PTS.",
            },
            new Formula
            {
                Id = "4_of04", Nome = "Equalização de Canal OFDM", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "X̂ₖ = Yₖ/Hₖ  (zero-forcing por subportadora)",
                ExprTexto = "X̂ₖ = Yₖ/Hₖ (ZF per subcarrier)",
                Icone = "eq",
                Descricao = "Graças ao CP, equalização no domínio da frequência é simples: dividir por Hₖ (resposta do canal na subcarrier k). O(N log N) vs O(N²) para equalização temporal.",
            },
            new Formula
            {
                Id = "4_of05", Nome = "QAM (Modulação)", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "s(t) = Aᵢcos(2πft) - Aqsin(2πft); log₂M bits/símbolo",
                ExprTexto = "QAM-M: log₂M bits/símbolo",
                Icone = "QAM",
                Descricao = "Quadrature Amplitude Modulation: modula amplitude em I e Q. M-QAM: 16, 64, 256, 1024 pontos na constelação. Maior M → mais bits mas mais sensível a ruído. BER ~ erfc(√(3SNR/2(M-1))).",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 18. HIDROLOGIA, PLASTICIDADE E COMBUSTÃO
    // ─────────────────────────────────────────────────────
    private void AdicionarHidrologiaCombustao()
    {
        _formulas.AddRange([
            // 18.1 Hidrologia e Águas Subterrâneas
            new Formula
            {
                Id = "4_hy01", Nome = "Equações de Saint-Venant", Categoria = "Hidrologia e Combustão", SubCategoria = "Hidrologia",
                Expressao = "∂h/∂t + ∂(hu)/∂x = 0;  ∂u/∂t + u∂u/∂x + g∂h/∂x = g(S₀-Sf)",
                ExprTexto = "∂h/∂t+∂(hu)/∂x=0; ∂u/∂t+u∂u/∂x+g∂h/∂x=g(S₀−Sf)",
                Icone = "SV",
                Descricao = "Águas rasas 1D: conservação de massa e momento para escoamento em canais abertos. h=profundidade, u=velocidade, S₀=declividade de fundo, Sf=declividade de atrito.",
                Criador = "Adhémar de Saint-Venant",
                AnoOrigin = "1871",
            },
            new Formula
            {
                Id = "4_hy02", Nome = "Velocidade de Manning", Categoria = "Hidrologia e Combustão", SubCategoria = "Hidrologia",
                Expressao = "V = (1/n)Rₕ^{2/3} S^{1/2}",
                ExprTexto = "V = (1/n)Rh^{2/3}S^{1/2}",
                Icone = "Mann",
                Descricao = "Velocidade média em escoamento uniforme em canal aberto. n = coeficiente de Manning (rugosidade: 0.01 liso → 0.06 vegetado). Rh = raio hidráulico = A/P.",
                Criador = "Robert Manning",
                AnoOrigin = "1889",
            },
            new Formula
            {
                Id = "4_hy03", Nome = "Lei de Darcy", Categoria = "Hidrologia e Combustão", SubCategoria = "Hidrologia",
                Expressao = "Q = -KA(dh/dL)",
                ExprTexto = "Q = −KA·dh/dL",
                Icone = "Darcy",
                Descricao = "Fluxo em meio poroso proporcional ao gradiente hidráulico. K = condutividade hidráulica. Base da hidrogeologia. Válida para regime laminar (Re < ~10 nos poros).",
                Criador = "Henry Darcy",
                AnoOrigin = "1856",
            },
            new Formula
            {
                Id = "4_hy04", Nome = "Equação de Richards", Categoria = "Hidrologia e Combustão", SubCategoria = "Hidrologia",
                Expressao = "∂θ/∂t = ∇·[K(θ)∇(h+z)]",
                ExprTexto = "∂θ/∂t = ∇·[K(θ)∇(h+z)]",
                Icone = "Rich",
                Descricao = "Fluxo não-saturado em solos: θ = umidade volumétrica, h = sucção mátrica, K(θ) = condutividade função da umidade. Altamente não-linear. Governa infiltração e recarga de aquíferos.",
                Criador = "Lorenzo Richards",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "4_hy05", Nome = "Modelo de van Genuchten", Categoria = "Hidrologia e Combustão", SubCategoria = "Hidrologia",
                Expressao = "θ(h) = θ_r + (θ_s-θ_r)/[1+(α|h|)ⁿ]ᵐ; m=1-1/n",
                ExprTexto = "Θ = [1+(α|h|)ⁿ]⁻ᵐ; m=1−1/n",
                Icone = "VG",
                Descricao = "Curva de retenção solo-água: relaciona umidade θ com sucção h. Parâmetros: α (inverso da pressão de entrada de ar), n (distribuição de poros). Amplamente usado em modelagem hidrológica.",
                Criador = "Martinus van Genuchten",
                AnoOrigin = "1980",
            },
            new Formula
            {
                Id = "4_hy06", Nome = "Equação de Advecção-Dispersão", Categoria = "Hidrologia e Combustão", SubCategoria = "Hidrologia",
                Expressao = "∂C/∂t = D∇²C - v·∇C + R(C)",
                ExprTexto = "∂C/∂t = D∇²C−v·∇C+R",
                Icone = "ADE",
                Descricao = "Transporte de solutos em meios porosos: advecção (v·∇C) + dispersão (D∇²C) + reações R. D = dispersão mecânica + difusão molecular. Modelagem de contaminação de aquíferos.",
            },
            // 18.2 Plasticidade
            new Formula
            {
                Id = "4_pl01", Nome = "Critério de von Mises", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "σ_eq = √(3J₂) = σ_Y  (escoamento)",
                ExprTexto = "σeq = √(3J₂) = σY",
                Icone = "Mises",
                Descricao = "Escoamento ocorre quando tensão equivalente (energia de distorção) atinge limite σY. J₂ = ½s:s (segundo invariante do desviador). Independe de pressão hidrostática.",
                Criador = "Richard von Mises",
                AnoOrigin = "1913",
            },
            new Formula
            {
                Id = "4_pl02", Nome = "Critério de Tresca", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "τ_max = (σ₁-σ₃)/2 = τ_Y  (máx. cisalhamento)",
                ExprTexto = "τmax = (σ₁−σ₃)/2 = τY",
                Icone = "Tresca",
                Descricao = "Escoamento quando máximo cisalhamento atinge limite. Mais conservador que von Mises (~15% menor). Hexágono inscrito na elipse de Mises no plano π.",
                Criador = "Henri Tresca",
                AnoOrigin = "1864",
            },
            new Formula
            {
                Id = "4_pl03", Nome = "Lei de Fluxo Associada", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "ε̇ᵖ = λ̇ · ∂f/∂σ  (f = superfície de escoamento)",
                ExprTexto = "ε̇ᵖ = λ̇·∂f/∂σ",
                Icone = "ε̇ᵖ",
                Descricao = "Deformação plástica normal à superfície de escoamento f(σ)=0 no espaço de tensões. λ̇≥0 (multiplicador plástico) determinado pela condição de consistência. Princípio de Hill.",
            },
            new Formula
            {
                Id = "4_pl04", Nome = "Endurecimento Isotrópico", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "f(σ,κ) = σ_eq - σ_Y(κ) = 0;  κ = ∫dε_p (acumulada)",
                ExprTexto = "f=σeq−σY(κ)=0; κ=∫dεp",
                Icone = "κ",
                Descricao = "Superfície de escoamento expande uniformemente com deformação plástica acumulada κ. σY(κ) = curva tensão-deformação. Não captura efeito Bauschinger.",
            },
            new Formula
            {
                Id = "4_pl05", Nome = "Endurecimento Cinemático", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "f(σ-α) = 0; α̇ = c·ε̇ᵖ (backstress translada)",
                ExprTexto = "f(σ−α)=0; α̇=c·ε̇ᵖ",
                Icone = "α",
                Descricao = "Superfície translada (não expande): center α move na direção da deformação plástica. Captura efeito Bauschinger (limite menor em reversão). Modelo de Prager, Armstrong-Frederick.",
            },
            new Formula
            {
                Id = "4_pl06", Nome = "Critério de Drucker-Prager", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "f = √J₂ + αI₁ - k = 0",
                ExprTexto = "f = √J₂+αI₁−k = 0",
                Icone = "DP",
                Descricao = "Extensão de Mises para materiais com atrito (solos, concreto, rochas): dependência da pressão hidrostática via I₁=tr(σ). Cone no espaço de tensões. α,k = parâmetros do material.",
                Criador = "Daniel Drucker / William Prager",
                AnoOrigin = "1952",
            },
            // 18.3 Combustão
            new Formula
            {
                Id = "4_cb01", Nome = "Número de Damköhler", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "Da = τ_flow / τ_chem",
                ExprTexto = "Da = τflow/τchem",
                Icone = "Da",
                Descricao = "Razão entre tempos de transporte e reação. Da≫1: reação rápida, mistura controla. Da≪1: reação lenta, cinética controla. Da~1: regime mais complexo (interação).",
            },
            new Formula
            {
                Id = "4_cb02", Nome = "Mecanismo de Zeldovich (NOx)", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "N₂+O → NO+N;  N+O₂ → NO+O (NOx térmico)",
                ExprTexto = "N₂+O→NO+N; N+O₂→NO+O (Zeldovich)",
                Icone = "NOx",
                Descricao = "Formação de NOx térmico: produção exponencial com temperatura (significativo >1800K). Mecanismo dominante em T alta. Redução: baixar Tmax, excesso de ar, recirculação.",
                Criador = "Yakov Zeldovich",
                AnoOrigin = "1946",
            },
            new Formula
            {
                Id = "4_cb03", Nome = "Velocidade de Chama Laminar", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "S_L ~ √(α·ω̇);  α=difusividade, ω̇=taxa reação",
                ExprTexto = "SL ~ √(α·ω̇)",
                Icone = "SL",
                Descricao = "Velocidade de propagação de chama pré-misturada. Balanço difusão-reação: SL aumenta com difusividade térmica e taxa de reação. CH₄/ar: ~40 cm/s. H₂/ar: ~200 cm/s.",
            },
            new Formula
            {
                Id = "4_cb04", Nome = "Taxa de Arrhenius", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "k(T) = A·Tⁿ·exp(-Eₐ/RT)",
                ExprTexto = "k = A·Tⁿ·exp(−Ea/RT)",
                Icone = "Arr",
                Descricao = "Taxa de reação química exponencial na temperatura. Eₐ = energia de ativação, A = fator pré-exponencial. Mecanismos detalhados: centenas de reações (GRI-Mech para CH₄ tem 325 reações).",
                Criador = "Svante Arrhenius",
                AnoOrigin = "1889",
            },
            new Formula
            {
                Id = "4_cb05", Nome = "Espessura de Chama", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "δ_L = α/S_L  (difusividade/velocidade)",
                ExprTexto = "δL = α/SL",
                Icone = "δ",
                Descricao = "Espessura de chama laminar: ~0.1-1 mm para hidrocarbonetos em condições atmosféricas. Escala onde difusão molecular e reação se equilibram. Ka = (δL/η)² = número de Karlovitz (turbulência).",
            },
        ]);
    }
}
