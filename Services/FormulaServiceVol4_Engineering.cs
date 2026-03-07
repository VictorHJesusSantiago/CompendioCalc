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
                ExemploPratico = "Exemplo: v_ref=10, Lf^n h=3, LgLf^(n-1) h=2 → u = (10−3)/2 = 3.5",
                Variaveis = [ new() { Simbolo = "v", Nome = "Entrada virtual v", ValorPadrao = 10 }, new() { Simbolo = "Lfh", Nome = "Lf^n h", ValorPadrao = 3 }, new() { Simbolo = "LgLfh", Nome = "LgLf^(n-1) h", ValorPadrao = 2, ValorMin = 0.01 } ],
                VariavelResultado = "u (controle)",
                UnidadeResultado = "",
                Calcular = vars => (vars["v"] - vars["Lfh"]) / vars["LgLfh"]
            },
            new Formula
            {
                Id = "4_nl02", Nome = "Derivada de Lie", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "Lfh = (∂h/∂x)·f(x);  Lfᵏh = Lf(Lf^{k-1}h)",
                ExprTexto = "Lfh = ∇h·f; Lfᵏh = Lf(Lf^{k-1}h)",
                Icone = "Lf",
                Descricao = "Derivada direcional ao longo do campo vetorial f. Essencial em controle não-linear: acessibilidade, observabilidade, grau relativo são expressos via derivadas de Lie.",
                ExemploPratico = "Exemplo: ∇h=[1, 2], f=[3, 4] → Lf h = ∇h·f = 1×3 + 2×4 = 11",
                Variaveis = [ new() { Simbolo = "∇h1", Nome = "∇h componente 1", ValorPadrao = 1 }, new() { Simbolo = "∇h2", Nome = "∇h componente 2", ValorPadrao = 2 }, new() { Simbolo = "f1", Nome = "f componente 1", ValorPadrao = 3 }, new() { Simbolo = "f2", Nome = "f componente 2", ValorPadrao = 4 } ],
                VariavelResultado = "Lf h",
                UnidadeResultado = "",
                Calcular = vars => vars["∇h1"] * vars["f1"] + vars["∇h2"] * vars["f2"]
            },
            new Formula
            {
                Id = "4_nl03", Nome = "Backstepping", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "Sistema em forma triangular; cada passo adiciona Lyapunov",
                ExprTexto = "x₁→x₂→⋯→u: design recursivo de Lyapunov",
                Icone = "←",
                Descricao = "Design recursivo para sistemas em forma cascata estrita: trata cada estado como 'controle virtual' do subsistema anterior. Soma funções de Lyapunov parciais. Garante estabilidade global.",
                ExemploPratico = "Exemplo: 3 etapas recursivas, cada adiciona termo kᵢ² à Lyapunov → V_total = k₁² + k₂² + k₃²",
                Variaveis = [ new() { Simbolo = "k1", Nome = "Ganho etapa 1 k₁", ValorPadrao = 2 }, new() { Simbolo = "k2", Nome = "Ganho etapa 2 k₂", ValorPadrao = 1.5 }, new() { Simbolo = "k3", Nome = "Ganho etapa 3 k₃", ValorPadrao = 1 } ],
                VariavelResultado = "V_total (Lyapunov)",
                UnidadeResultado = "",
                Calcular = vars => vars["k1"]*vars["k1"] + vars["k2"]*vars["k2"] + vars["k3"]*vars["k3"]
            },
            new Formula
            {
                Id = "4_nl04", Nome = "Sliding Mode Control (SMC)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "s(x) = 0 (superfície);  u = u_eq + u_sw;  u_sw = -K·sign(s)",
                ExprTexto = "u = u_eq−K·sign(s); s(x)=0",
                Icone = "SMC",
                Descricao = "Força trajetória para superfície de deslizamento s=0 via controle descontínuo. Robusto a incertezas e perturbações matching. Chattering = vibração de alta frequência (solução: boundary layer).",
                ExemploPratico = "Exemplo: u_eq=5, K=3, s=2 → u_sw = −3×sign(2) = −3 → u = 5−3 = 2",
                Variaveis = [ new() { Simbolo = "u_eq", Nome = "Controle equivalente u_eq", ValorPadrao = 5 }, new() { Simbolo = "K", Nome = "Ganho chaveamento K", ValorPadrao = 3 }, new() { Simbolo = "s", Nome = "Superfície s", ValorPadrao = 2 } ],
                VariavelResultado = "u (controle)",
                UnidadeResultado = "",
                Calcular = vars => vars["u_eq"] - vars["K"] * Math.Sign(vars["s"])
            },
            new Formula
            {
                Id = "4_nl05", Nome = "MRAC (Controle Adaptativo)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "θ̇ = -Γ·e·φ;  e = y - y_m (erro de modelo)",
                ExprTexto = "θ̇ = −Γeφ; e = y−yₘ",
                Icone = "MRAC",
                Descricao = "Model Reference Adaptive Control: ajusta parâmetros θ online para rastrear modelo de referência. Γ = ganho de adaptação. Baseado em Lyapunov ou passividade.",
                ExemploPratico = "Exemplo: y_planta=10, y_modelo=8 → e = 10−8 = 2 (erro rastreamento)",
                Variaveis = [ new() { Simbolo = "y", Nome = "Saída planta y", ValorPadrao = 10 }, new() { Simbolo = "y_m", Nome = "Saída modelo y_m", ValorPadrao = 8 } ],
                VariavelResultado = "e (erro)",
                UnidadeResultado = "",
                Calcular = vars => vars["y"] - vars["yₘ"]
            },
            new Formula
            {
                Id = "4_nl06", Nome = "Estabilidade de Lyapunov (Revisitada)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "V(x)>0, V̇(x)≤-W(x)<0 ⟹ estabilidade assintótica global",
                ExprTexto = "V>0, V̇≤−W<0 ⟹ GAS",
                Icone = "V̇",
                Descricao = "Função de Lyapunov: 'energia generalizada' que decresce ao longo de trajetórias. V>0 e V̇<0 ⟹ equilíbrio estável. LaSalle: V̇≤0 basta se {V̇=0} não contém trajetórias não-triviais.",
                ExemploPratico = "Exemplo: V=x²+y²=5, V̇=-2x²-3y²=-13 → V̇<0 confirma estabilidade assintótica",
                Variaveis = [ new() { Simbolo = "V", Nome = "Lyapunov V(x)", ValorPadrao = 5, ValorMin = 0.001 }, new() { Simbolo = "V̇", Nome = "Derivada V̇(x)", ValorPadrao = -13 } ],
                VariavelResultado = "Razão V̇/V",
                UnidadeResultado = "",
                Calcular = vars => vars["V̇"] / vars["V"]
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
                ExemploPratico = "Exemplo: LfV=2, LgV=3, k=1 → u_Sontag = −1×3 = −3 (controle estabilizante)",
                Variaveis = [ new() { Simbolo = "LfV", Nome = "LfV", ValorPadrao = 2 }, new() { Simbolo = "LgV", Nome = "LgV", ValorPadrao = 3 }, new() { Simbolo = "k", Nome = "Ganho k", ValorPadrao = 1 } ],
                VariavelResultado = "u_Sontag",
                UnidadeResultado = "",
                Calcular = vars => -vars["k"] * vars["LgV"]
            },
            new Formula
            {
                Id = "4_nl08", Nome = "CBF (Control Barrier Function)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "LfB + LgB·u + α(B) ≥ 0  (mantém B(x)≥0)",
                ExprTexto = "LfB+LgB·u+α(B)≥0 → segurança",
                Icone = "CBF",
                Descricao = "Garante que estado nunca sai do conjunto seguro {B(x)≥0}. Combinado com CLF via QP: min ‖u-u_nom‖² s.t. CLF e CBF. Controle seguro com garantias formais.",
                ExemploPratico = "Exemplo: LfB=-2, LgB=1, u=5, α(B)=0.5 → -2+1×5+0.5 = 3.5 ≥ 0 (seguro)",
                Variaveis = [ new() { Simbolo = "LfB", Nome = "LfB", ValorPadrao = -2 }, new() { Simbolo = "LgB", Nome = "LgB", ValorPadrao = 1 }, new() { Simbolo = "u", Nome = "Controle u", ValorPadrao = 5 }, new() { Simbolo = "αB", Nome = "α(B)", ValorPadrao = 0.5 } ],
                VariavelResultado = "condição CBF",
                UnidadeResultado = "",
                Calcular = vars => vars["LfB"] + vars["LgB"] * vars["u"] + vars["αB"]
            },
            new Formula
            {
                Id = "4_nl09", Nome = "Passividade", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "V̇ ≤ u'y  (entrada u, saída y, storage V)",
                ExprTexto = "V̇ ≤ u'y (passividade)",
                Icone = "pass",
                Descricao = "Sistema passivo: energia armazenada ≤ energia fornecida. Interconexão de sistemas passivos é passiva. Feedback negativo de passivo → estável. Teoria de portas (Willems).",
                ExemploPratico = "Exemplo: u=10, y=8, V̇=70 → excesso = u'y−V̇ = 10×8−70 = 10 ≥ 0 (passivo)",
                Variaveis = [ new() { Simbolo = "u", Nome = "Entrada u", ValorPadrao = 10 }, new() { Simbolo = "y", Nome = "Saída y", ValorPadrao = 8 }, new() { Simbolo = "V̇", Nome = "V̇ storage", ValorPadrao = 70 } ],
                VariavelResultado = "excesso u'y−V̇",
                UnidadeResultado = "",
                Calcular = vars => vars["u"] * vars["y"] - vars["V̇"]
            },
            new Formula
            {
                Id = "4_nl10", Nome = "Gain Scheduling", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Não-Linear",
                Expressao = "u = K(ρ)·x;  ρ = parâmetro variável (scheduling var.)",
                ExprTexto = "u = K(ρ)x; ρ=scheduling variable",
                Icone = "GS",
                Descricao = "Família de controladores lineares K(ρ) parametrizada por variável de scheduling ρ (ponto de operação). LPV → interpola entre múltiplos designs lineares. Usado em aviação, motores.",
                ExemploPratico = "Exemplo: K(ρ)=2ρ, x=5, ρ=1.5 → u = K(ρ)×x = 2×1.5×5 = 15",
                Variaveis = [ new() { Simbolo = "x", Nome = "Estado x", ValorPadrao = 5 }, new() { Simbolo = "ρ", Nome = "Scheduling ρ", ValorPadrao = 1.5 }, new() { Simbolo = "c", Nome = "Coef K(ρ)=c×ρ", ValorPadrao = 2 } ],
                VariavelResultado = "u (controle)",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] * vars["ρ"] * vars["x"]
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
                ExemploPratico = "Exemplo: ∂H/∂x=-5, ∂H/∂p=3 → ṗ=−(−5)=5, ẋ=3 (equações adjuntas)",
                Variaveis = [ new() { Simbolo = "∂Hx", Nome = "∂H/∂x", ValorPadrao = -5 }, new() { Simbolo = "∂Hp", Nome = "∂H/∂p", ValorPadrao = 3 } ],
                VariavelResultado = "ṗ (adjunto)",
                UnidadeResultado = "",
                Calcular = vars => -vars["∂Hx"]
            },
            new Formula
            {
                Id = "4_oc02", Nome = "Regulador Linear Quadrático (LQR)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "min ∫(x'Qx + u'Ru)dt;  u* = -R⁻¹B'Px",
                ExprTexto = "min∫(x'Qx+u'Ru)dt; u*=−R⁻¹B'Px",
                Icone = "LQR",
                Descricao = "Controle ótimo para sistema linear com custo quadrático: solução em forma de feedback u=-Kx. P = solução da equação algébrica de Riccati. Margens de estabilidade garantidas (60° fase, ∞ ganho).",
                ExemploPratico = "Exemplo: R=2, B'Px=6 → u* = −(1/2)×6 = −3 (controle ótimo LQR)",
                Variaveis = [ new() { Simbolo = "R", Nome = "Peso controle R", ValorPadrao = 2, ValorMin = 0.01 }, new() { Simbolo = "BPx", Nome = "B'Px", ValorPadrao = 6 } ],
                VariavelResultado = "u* (ótimo)",
                UnidadeResultado = "",
                Calcular = vars => -(1.0 / vars["R"]) * vars["BPx"]
            },
            new Formula
            {
                Id = "4_oc03", Nome = "Equação de Riccati (Algébrica)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "A'P + PA - PBR⁻¹B'P + Q = 0",
                ExprTexto = "A'P+PA−PBR⁻¹B'P+Q=0",
                Icone = "ARE",
                Descricao = "Equação algébrica (tempo infinito) ou diferencial (tempo finito) de Riccati. Solução P define ganho ótimo K=R⁻¹B'P. Existência: (A,B) controlável, (A,Q½) observável.",
                ExemploPratico = "Exemplo: A'P+PA=10, −PBR⁻¹B'P=-3, Q=8 → soma = 10−3+8 = 15 (deve ser 0)",
                Variaveis = [ new() { Simbolo = "AP", Nome = "A'P+PA", ValorPadrao = 10 }, new() { Simbolo = "PBP", Nome = "−PBR⁻¹B'P", ValorPadrao = -3 }, new() { Simbolo = "Q", Nome = "Peso Q", ValorPadrao = 8 } ],
                VariavelResultado = "residual Riccati",
                UnidadeResultado = "",
                Calcular = vars => vars["AP"] + vars["PBP"] + vars["Q"]
            },
            new Formula
            {
                Id = "4_oc04", Nome = "Equação de Hamilton-Jacobi-Bellman", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "min_u [L(x,u) + ∇V·f(x,u)] = 0  (V = valor ótimo)",
                ExprTexto = "minᵤ[L+∇V·f]=0 (HJB)",
                Icone = "HJB",
                Descricao = "EDP para função valor ótima V(x,t). Suficiente (não apenas necessário como PMP). Caso linear-quadrático → Riccati. Em geral: maldição da dimensionalidade. Soluções viscosas.",
                ExemploPratico = "Exemplo: L(x,u)=5, ∇V·f=12 → HJB = min_u[5+12] = 17 (deve ser 0)",
                Variaveis = [ new() { Simbolo = "L", Nome = "Custo L(x,u)", ValorPadrao = 5 }, new() { Simbolo = "∇Vf", Nome = "∇V·f", ValorPadrao = 12 } ],
                VariavelResultado = "HJB lado esquerdo",
                UnidadeResultado = "",
                Calcular = vars => vars["L"] + vars["∇Vf"]
            },
            new Formula
            {
                Id = "4_oc05", Nome = "Controle Bang-Bang", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "H = p'f(x) + p'g(x)u → u* = u_max·sign(p'g)",
                ExprTexto = "u* = u_max·sign(p'g) (bang-bang)",
                Icone = "⬛",
                Descricao = "Quando H é linear em u com u limitado: controle ótimo alterna entre extremos. Solução típica de tempo mínimo com saturação. Número de switchings determinado pela dimensão.",
                ExemploPratico = "Exemplo: u_max=10, p'g=−2 → u* = 10×sign(−2) = 10×(−1) = −10",
                Variaveis = [ new() { Simbolo = "u_max", Nome = "Limite u_max", ValorPadrao = 10 }, new() { Simbolo = "pg", Nome = "p'g", ValorPadrao = -2 } ],
                VariavelResultado = "u* (bang-bang)",
                UnidadeResultado = "",
                Calcular = vars => vars["u_max"] * Math.Sign(vars["pg"])
            },
            new Formula
            {
                Id = "4_oc06", Nome = "Model Predictive Control (MPC)", Categoria = "Controle Não-Linear e Ótimo", SubCategoria = "Controle Ótimo",
                Expressao = "min_{u₀,...,u_{N-1}} Σ l(xₖ,uₖ) + V_f(x_N)  s.t. xₖ₊₁=f(xₖ,uₖ)",
                ExprTexto = "min Σl(x,u)+V_f(x_N) s.t. dinâmica+restrições",
                Icone = "MPC",
                Descricao = "Otimização online em horizonte finito N: resolve a cada passo, aplica u₀, recede horizonte. Trata restrições de estado/controle explicitamente. Padrão industrial (processos químicos, robótica).",
                ExemploPratico = "Exemplo: Horizonte N=10, custo/passo l=2, V_f=15 → custo total ≈ 10×2+15 = 35",
                Variaveis = [ new() { Simbolo = "N", Nome = "Horizonte N", ValorPadrao = 10, ValorMin = 1 }, new() { Simbolo = "l", Nome = "Custo/passo l", ValorPadrao = 2 }, new() { Simbolo = "V_f", Nome = "Custo terminal V_f", ValorPadrao = 15 } ],
                VariavelResultado = "Custo total (aprox)",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["l"] + vars["V_f"]
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
                ExemploPratico = "Exemplo: Custo imediato l=3, V* futuro=18 → V* corrente = min[3+18] = 21",
                Variaveis = [ new() { Simbolo = "l", Nome = "Custo imediato l", ValorPadrao = 3 }, new() { Simbolo = "V_next", Nome = "V* futuro", ValorPadrao = 18 } ],
                VariavelResultado = "V* (ótimo)",
                UnidadeResultado = "",
                Calcular = vars => vars["l"] + vars["V_next"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "phi", Nome = "phi", ValorPadrao = 1 }, new() { Simbolo = "q", Nome = "q", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["phi"] + vars["q"]
            },
            new Formula
            {
                Id = "4_sc02", Nome = "Equação de Continuidade (Elétrons)", Categoria = "Dispositivos Semicondutores", SubCategoria = "Equações Fundamentais",
                Expressao = "∂n/∂t = (1/q)∇·Jₙ + G - R",
                ExprTexto = "∂n/∂t = (1/q)∇·Jₙ+G−R",
                Icone = "∂n",
                Descricao = "Conservação de portadores: variação temporal = divergência de corrente + geração G - recombinação R. Analogamente para buracos com sinal oposto da corrente.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n", ValorPadrao = 1 }, new() { Simbolo = "t", Nome = "t", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] + vars["t"]
            },
            new Formula
            {
                Id = "4_sc03", Nome = "Corrente Drift-Diffusion", Categoria = "Dispositivos Semicondutores", SubCategoria = "Equações Fundamentais",
                Expressao = "Jₙ = qnμₙE + qDₙ∇n;  Jₚ = qpμₚE - qDₚ∇p",
                ExprTexto = "Jₙ = qnμₙE+qDₙ∇n; Jₚ = qpμₚE−qDₚ∇p",
                Icone = "J",
                Descricao = "Corrente = drift (campo E) + difusão (gradiente de concentração). μ = mobilidade, D = coeficiente de difusão. Modelo padrão para simulação de dispositivos.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "qn", Nome = "qn", ValorPadrao = 1 }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["qn"] + vars["mu"]
            },
            new Formula
            {
                Id = "4_sc04", Nome = "Relação de Einstein", Categoria = "Dispositivos Semicondutores", SubCategoria = "Equações Fundamentais",
                Expressao = "Dₙ/μₙ = kT/q = V_T ≈ 26 mV (300K)",
                ExprTexto = "D/μ = kT/q = V_T ≈ 26mV",
                Icone = "V_T",
                Descricao = "Relaciona difusão e mobilidade via potencial térmico. V_T = kT/q ≈ 26 mV a 300K. Consequência do equilíbrio termodinâmico (fluctuation-dissipation).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "kT", Nome = "kT", ValorPadrao = 10 }, new() { Simbolo = "q", Nome = "q", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "μ",
                UnidadeResultado = "",
                Calcular = vars => vars["kT"] / vars["q"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "np", Nome = "np", ValorPadrao = 1 }, new() { Simbolo = "tau", Nome = "tau", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["np"] + vars["tau"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            new Formula
            {
                Id = "4_sc07", Nome = "Largura da Região de Depleção", Categoria = "Dispositivos Semicondutores", SubCategoria = "Junção p-n",
                Expressao = "W = √(2ε(Vbi-V)(1/NA+1/ND)/q)",
                ExprTexto = "W = √(2ε(Vbi−V)(N_A⁻¹+N_D⁻¹)/q)",
                Icone = "W",
                Descricao = "Zona de depleção em junção p-n abrupta. Vbi = potencial built-in. Cresce com reversa (V<0), diminui com direta. C = εA/W → capacitância variável (varactor).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "4_sc08", Nome = "Potencial Built-in", Categoria = "Dispositivos Semicondutores", SubCategoria = "Junção p-n",
                Expressao = "V_bi = (kT/q)ln(N_A·N_D/nᵢ²)",
                ExprTexto = "Vbi = (kT/q)ln(NA·ND/nᵢ²)",
                Icone = "Vbi",
                Descricao = "Barreira de potencial no equilíbrio: ~0.7V para Si, ~0.3V para Ge, ~1.1V para GaAs. Determina tensão de threshold do diodo e capacitância de depleção.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "4_sc09", Nome = "Corrente de Saturação", Categoria = "Dispositivos Semicondutores", SubCategoria = "Junção p-n",
                Expressao = "I_s = qA(Dₚpₙ₀/Lₚ + Dₙnₚ₀/Lₙ)",
                ExprTexto = "Iₛ = qA(Dₚpₙ₀/Lₚ+Dₙnₚ₀/Lₙ)",
                Icone = "Iₛ",
                Descricao = "Corrente reversa de saturação: portadores minoritários difundindo pela junção. A = área, L = comprimento de difusão (√Dτ). Muito sensível à temperatura (dobra a cada ~10°C).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "qA", Nome = "qA", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["qA"]
            },
            new Formula
            {
                Id = "4_sc10", Nome = "MOSFET (Corrente Triodo)", Categoria = "Dispositivos Semicondutores", SubCategoria = "MOSFET",
                Expressao = "I_D = μₙCₒₓ(W/L)[(V_GS-V_th)V_DS - V²_DS/2]",
                ExprTexto = "I_D = μCox(W/L)[(VGS−Vth)VDS−VDS²/2]",
                Icone = "MOS",
                Descricao = "Região triodo (linear): V_DS < V_GS-V_th. Transistor age como resistência controlada. Cox = capacitância do óxido de gate. W/L = razão de aspecto.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "I_D", Nome = "I_D", ValorPadrao = 1 }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["I_D"] + vars["mu"]
            },
            new Formula
            {
                Id = "4_sc11", Nome = "MOSFET (Corrente Saturação)", Categoria = "Dispositivos Semicondutores", SubCategoria = "MOSFET",
                Expressao = "I_D = (μₙCₒₓ/2)(W/L)(V_GS-V_th)²",
                ExprTexto = "I_D = (μCox/2)(W/L)(VGS−Vth)²",
                Icone = "sat",
                Descricao = "Região de saturação: V_DS ≥ V_GS-V_th. Corrente 'constante' (modulação de canal λ: I_D·(1+λV_DS)). Base de amplificadores e circuitos digitais. Quadrática em Vgs-Vth.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "I_D", Nome = "I_D", ValorPadrao = 1 }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["I_D"] + vars["mu"]
            },
            new Formula
            {
                Id = "4_sc12", Nome = "Tensão de Threshold", Categoria = "Dispositivos Semicondutores", SubCategoria = "MOSFET",
                Expressao = "V_th = V_FB + 2φ_F + √(2εqNA·2φ_F)/Cₒₓ",
                ExprTexto = "Vth = VFB+2φF+Qd/Cox",
                Icone = "Vth",
                Descricao = "Tensão de gate para inversão do canal. VFB = flat-band, φF = potencial de Fermi no bulk, Qd = carga de depleção. Ajuste por implantação iônica.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "VFB", Nome = "VFB", ValorPadrao = 10 }, new() { Simbolo = "2φF", Nome = "2φF", ValorPadrao = 5 } ],
                VariavelResultado = "Vth",
                UnidadeResultado = "",
                Calcular = vars => vars["VFB"] + vars["2φF"]
            },
            new Formula
            {
                Id = "4_sc13", Nome = "BJT (Corrente IC)", Categoria = "Dispositivos Semicondutores", SubCategoria = "BJT",
                Expressao = "I_C = I_S · e^{V_BE/V_T}",
                ExprTexto = "IC = IS·e^{VBE/VT}",
                Icone = "BJT",
                Descricao = "Transistor bipolar na região ativa: corrente de coletor exponencial na tensão base-emissor. β = IC/IB = ganho de corrente. Modelo de Ebers-Moll para todas regiões.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "IS", Nome = "IS", ValorPadrao = 5 }, new() { Simbolo = "e", Nome = "e", ValorPadrao = 3 } ],
                VariavelResultado = "IC",
                UnidadeResultado = "",
                Calcular = vars => vars["IS"] * vars["e"]
            },
            new Formula
            {
                Id = "4_sc14", Nome = "Corrente de Tunelamento (FN)", Categoria = "Dispositivos Semicondutores", SubCategoria = "Efeitos Quânticos",
                Expressao = "J_FN = AE² exp(-B/E);  A,B dependem de m*, φ_B",
                ExprTexto = "J_FN = AE²exp(−B/E)",
                Icone = "FN",
                Descricao = "Tunelamento Fowler-Nordheim: corrente exponencial em 1/E. Limitante em óxidos ultrafinos (<2nm). Mecanismo de escrita em memórias Flash. A,B = constantes do material.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "AE", Nome = "AE", ValorPadrao = 5 } ],
                VariavelResultado = "J_FN",
                UnidadeResultado = "",
                Calcular = vars => vars["AE"] * vars["AE"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "d", Nome = "d", ValorPadrao = 1 }, new() { Simbolo = "x", Nome = "x", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["d"] + vars["x"]
            },
            new Formula
            {
                Id = "4_cd03", Nome = "Bound de Singleton", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "d_min ≤ n-k+1  (código [n,k,d])",
                ExprTexto = "d ≤ n−k+1 (Singleton bound)",
                Icone = "Sing",
                Descricao = "Limite superior: distância mínima ≤ n-k+1. Códigos MDS (Maximum Distance Separable: Reed-Solomon) atingem igualdade. n=comprimento, k=dimensão.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "d", Nome = "d", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["d"] + vars["n"]
            },
            new Formula
            {
                Id = "4_cd04", Nome = "Códigos LDPC", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "H esparsa; decodificação por belief propagation (iterativa)",
                ExprTexto = "H esparsa; decode: message passing (BP)",
                Icone = "LDPC",
                Descricao = "Low-Density Parity-Check: matriz de paridade H esparsa. Decodificação iterativa por passagem de mensagens no grafo de Tanner. Performance próxima de Shannon. 5G NR, Wi-Fi 6.",
                Criador = "Robert Gallager (1963) / redescoberto 1990s",
                ExemploPratico = "Exemplo: Matriz de paridade H com 1000 bits e eficiência de verificação check=0.95 → score = 950",
                Variaveis = [ new() { Simbolo = "H", Nome = "Tamanho matriz H", ValorPadrao = 1000, ValorMin = 1 }, new() { Simbolo = "check", Nome = "Eficiência check", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Score",
                UnidadeResultado = "",
                Calcular = vars => vars["H"] * vars["check"]
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
                ExemploPratico = "Exemplo: 2 codificadores RSC recursivos com ganho=3.5 dB cada → ganho total ≈ 7.0 dB",
                Variaveis = [ new() { Simbolo = "RSC", Nome = "Número de RSC", ValorPadrao = 2, ValorMin = 1, ValorMax = 4 }, new() { Simbolo = "gain", Nome = "Ganho por RSC (dB)", ValorPadrao = 3.5 } ],
                VariavelResultado = "Ganho total",
                UnidadeResultado = "dB",
                Calcular = vars => vars["RSC"] * vars["gain"]
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
                ExemploPratico = "Exemplo: Canal com capacidade W=100 Mbps → polarização produz W⁺ e W⁻: soma W⁺+W⁻=W=100",
                Variaveis = [ new() { Simbolo = "W", Nome = "Capacidade W (Mbps)", ValorPadrao = 100, ValorMin = 0.001 } ],
                VariavelResultado = "W (conservado)",
                UnidadeResultado = "Mbps",
                Calcular = vars => vars["W"]
            },
            new Formula
            {
                Id = "4_cd07", Nome = "Capacidade MIMO", Categoria = "Codificação e Comunicações", SubCategoria = "Codificação",
                Expressao = "C = log₂ det(I + (SNR/Nₜ)HH†)  bits/s/Hz",
                ExprTexto = "C = log₂det(I+SNR·HH†/Nt)",
                Icone = "MIMO",
                Descricao = "Capacidade cresce linearmente com min(Nₜ,Nᵣ) antenas (multiplexação espacial). H = matriz de canal Nr×Nt. Massive MIMO (5G): centenas de antenas na estação base.",
                ExemploPratico = "Exemplo: SNR=20 dB=100 linear, determinante det(I+SNR×HH†)=16 → C=log₂(16)=4 bits/s/Hz",
                Variaveis = [ new() { Simbolo = "det", Nome = "det(I+SNR×HH†)", ValorPadrao = 16, ValorMin = 1 } ],
                VariavelResultado = "C",
                UnidadeResultado = "bits/s/Hz",
                Calcular = vars => Math.Log(vars["det"], 2)
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
                ExemploPratico = "Exemplo: Matriz Alamouti 2×2 fornece ganho de diversidade Order=2 (duas antenas, duas cópias)",
                Variaveis = [ new() { Simbolo = "Nt", Nome = "Número antenas Tx", ValorPadrao = 2, ValorMin = 2, ValorMax = 4 } ],
                VariavelResultado = "Ordem divers.",
                UnidadeResultado = "",
                Calcular = vars => vars["Nt"]
            },
            // 17.2 OFDM e Comunicações
            new Formula
            {
                Id = "4_of01", Nome = "OFDM (Orthogonal FDM)", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "x(t) = Σₖ Xₖ e^{j2πkΔft};  Δf = 1/T",
                ExprTexto = "x(t) = Σ Xₖe^{j2πkΔft}; Δf=1/T",
                Icone = "OFDM",
                Descricao = "Divide banda larga em subportadoras ortogonais estreitas: canal seletivo em frequência → múltiplos canais planos. IFFT no transmissor, FFT no receptor. 4G/5G, Wi-Fi, DVB.",
                ExemploPratico = "Exemplo: Símbolo OFDM de duração T=50 μs → espaçamento de subportadoras Δf=1/T=1/(50e-6)=20 kHz",
                Variaveis = [ new() { Simbolo = "T", Nome = "Duração símb. T (μs)", ValorPadrao = 50, ValorMin = 0.001 } ],
                VariavelResultado = "Δf",
                UnidadeResultado = "kHz",
                Calcular = vars => 1000.0 / vars["T"]
            },
            new Formula
            {
                Id = "4_of02", Nome = "Prefixo Cíclico", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "CP ≥ τ_max (delay spread máximo);  converte linear em circular",
                ExprTexto = "L_CP ≥ τmax; converte conv. linear→circular",
                Icone = "CP",
                Descricao = "Cópia da cauda do símbolo OFDM adicionada ao início. Transforma convolução linear do canal em circular → multiplicação no domínio da frequência. Elimina ISI entre símbolos.",
                ExemploPratico = "Exemplo: Delay spread máx τ_max=5 μs, T=64 μs → L_CP ≥ 5 μs; fracção overhead = 5/64 ≈ 7.8%",
                Variaveis = [ new() { Simbolo = "tau", Nome = "Delay spread τ (μs)", ValorPadrao = 5, ValorMin = 0 }, new() { Simbolo = "T", Nome = "Duração T (μs)", ValorPadrao = 64, ValorMin = 0.001 } ],
                VariavelResultado = "Overhead %",
                UnidadeResultado = "%",
                Calcular = vars => 100 * vars["tau"] / vars["T"]
            },
            new Formula
            {
                Id = "4_of03", Nome = "PAPR (Peak-to-Average Power Ratio)", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "PAPR = max|x(t)|² / E[|x(t)|²] ≤ N (dB)",
                ExprTexto = "PAPR = max|x|²/𝔼[|x|²]",
                Icone = "PAPR",
                Descricao = "Problema do OFDM: soma de N subcarriers pode ter picos altos (até N·Pmédia). Requer amplificador com grande back-off → ineficiente. Soluções: clipping, SLM, PTS.",
                ExemploPratico = "Exemplo: OFDM com N=64 subportadoras → PAPR_max = 10×log₁₀(64) = 18.1 dB (limite superior)",
                Variaveis = [ new() { Simbolo = "N", Nome = "N subportadoras", ValorPadrao = 64, ValorMin = 2 } ],
                VariavelResultado = "PAPR_max",
                UnidadeResultado = "dB",
                Calcular = vars => 10 * Math.Log10(vars["N"])
            },
            new Formula
            {
                Id = "4_of04", Nome = "Equalização de Canal OFDM", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "X̂ₖ = Yₖ/Hₖ  (zero-forcing por subportadora)",
                ExprTexto = "X̂ₖ = Yₖ/Hₖ (ZF per subcarrier)",
                Icone = "eq",
                Descricao = "Graças ao CP, equalização no domínio da frequência é simples: dividir por Hₖ (resposta do canal na subcarrier k). O(N log N) vs O(N²) para equalização temporal.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Yₖ", Nome = "Yₖ", ValorPadrao = 10 }, new() { Simbolo = "Hₖ", Nome = "Hₖ", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "ₖ",
                UnidadeResultado = "",
                Calcular = vars => vars["Yₖ"] / vars["Hₖ"]
            },
            new Formula
            {
                Id = "4_of05", Nome = "QAM (Modulação)", Categoria = "Codificação e Comunicações", SubCategoria = "OFDM",
                Expressao = "s(t) = Aᵢcos(2πft) - Aqsin(2πft); log₂M bits/símbolo",
                ExprTexto = "QAM-M: log₂M bits/símbolo",
                Icone = "QAM",
                Descricao = "Quadrature Amplitude Modulation: modula amplitude em I e Q. M-QAM: 16, 64, 256, 1024 pontos na constelação. Maior M → mais bits mas mais sensível a ruído. BER ~ erfc(√(3SNR/2(M-1))).",
                ExemploPratico = "Exemplo: 256-QAM → log₂(256) = 8 bits/símbolo (alta eficiência espectral, requer alto SNR)",
                Variaveis = [ new() { Simbolo = "M", Nome = "Constelação M-QAM", ValorPadrao = 256, ValorMin = 2 } ],
                VariavelResultado = "bits/símb",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["M"], 2)
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
                ExemploPratico = "Exemplo: Profundidade h=2.5 m, velocidade u=1.2 m/s, declividade fundo S₀=0.001 rad → flux hu=3.0 m²/s",
                Variaveis = [ new() { Simbolo = "h", Nome = "Profundidade h (m)", ValorPadrao = 2.5, ValorMin = 0.001 }, new() { Simbolo = "u", Nome = "Velocidade u (m/s)", ValorPadrao = 1.2 } ],
                VariavelResultado = "hu",
                UnidadeResultado = "m²/s",
                Calcular = vars => vars["h"] * vars["u"]
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
                ExemploPratico = "Exemplo: n=0.03 (concreto), Rh=1.5 m, S=0.002 → V = (1/0.03)×1.5^{2/3}×0.002^{1/2} ≈ 1.75 m/s",
                Variaveis = [ new() { Simbolo = "n", Nome = "Coef. Manning n", ValorPadrao = 0.03, ValorMin = 0.001 }, new() { Simbolo = "Rh", Nome = "Raio hidráulico Rh (m)", ValorPadrao = 1.5, ValorMin = 0.001 }, new() { Simbolo = "S", Nome = "Declividade S", ValorPadrao = 0.002, ValorMin = 0 } ],
                VariavelResultado = "V",
                UnidadeResultado = "m/s",
                Calcular = vars => (1.0 / vars["n"]) * Math.Pow(vars["Rh"], 2.0 / 3.0) * Math.Pow(vars["S"], 0.5)
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
                ExemploPratico = "Exemplo: K=1e-4 m/s, A=50 m², dh/dL=0.05 → Q = 1e-4×50×0.05 = 2.5e-4 m³/s",
                Variaveis = [ new() { Simbolo = "K", Nome = "Condutividade K (m/s)", ValorPadrao = 0.0001, ValorMin = 0 }, new() { Simbolo = "A", Nome = "Área A (m²)", ValorPadrao = 50, ValorMin = 0.001 }, new() { Simbolo = "dh_dL", Nome = "Gradiente dh/dL", ValorPadrao = 0.05 } ],
                VariavelResultado = "Q",
                UnidadeResultado = "m³/s",
                Calcular = vars => vars["K"] * vars["A"] * vars["dh_dL"]
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
                ExemploPratico = "Exemplo: Umidade θ inicial=0.25, variação Δθ/Δt=-0.001 s⁻¹ (secando) → |Δθ/Δt|=0.001",
                Variaveis = [ new() { Simbolo = "theta", Nome = "Umidade θ", ValorPadrao = 0.25, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "dtheta", Nome = "Δθ/Δt", ValorPadrao = -0.001 } ],
                VariavelResultado = "|Δθ/Δt|",
                UnidadeResultado = "s⁻¹",
                Calcular = vars => Math.Abs(vars["dtheta"])
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
                ExemploPratico = "Exemplo: n=1.5 → m = 1-1/1.5 = 1-0.667 = 0.333 (parâmetro m de van Genuchten)",
                Variaveis = [ new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 1.5, ValorMin = 1.001 } ],
                VariavelResultado = "m",
                UnidadeResultado = "",
                Calcular = vars => 1.0 - 1.0 / vars["n"]
            },
            new Formula
            {
                Id = "4_hy06", Nome = "Equação de Advecção-Dispersão", Categoria = "Hidrologia e Combustão", SubCategoria = "Hidrologia",
                Expressao = "∂C/∂t = D∇²C - v·∇C + R(C)",
                ExprTexto = "∂C/∂t = D∇²C−v·∇C+R",
                Icone = "ADE",
                Descricao = "Transporte de solutos em meios porosos: advecção (v·∇C) + dispersão (D∇²C) + reações R. D = dispersão mecânica + difusão molecular. Modelagem de contaminação de aquíferos.",
                ExemploPratico = "Exemplo: Concentração C=50 mg/L varia por dispersão D∇²C=-2.0 e advecção v·∇C=3.5 → ∂C/∂t=-5.5 mg/L/s",
                Variaveis = [ new() { Simbolo = "D_lap", Nome = "D∇²C", ValorPadrao = -2.0 }, new() { Simbolo = "v_grad", Nome = "v·∇C", ValorPadrao = 3.5 }, new() { Simbolo = "R", Nome = "Reação R", ValorPadrao = 0 } ],
                VariavelResultado = "∂C/∂t",
                UnidadeResultado = "mg/L/s",
                Calcular = vars => vars["D_lap"] - vars["v_grad"] + vars["R"]
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
                ExemploPratico = "Exemplo: 2º invariante desviador J₂=90 MPa² → σ_eq = √(3×90) = 16.43 MPa",
                Variaveis = [ new() { Simbolo = "J2", Nome = "2º invari. desviador J₂ (MPa²)", ValorPadrao = 90, ValorMin = 0 } ],
                VariavelResultado = "σ_eq",
                UnidadeResultado = "MPa",
                Calcular = vars => Math.Sqrt(3 * vars["J2"])
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
                ExemploPratico = "Exemplo: σ₁=100 MPa, σ₃=40 MPa → τ_max = (100-40)/2 = 30 MPa",
                Variaveis = [ new() { Simbolo = "sigma1", Nome = "Tensão princ. σ₁ (MPa)", ValorPadrao = 100 }, new() { Simbolo = "sigma3", Nome = "Tensão princ. σ₃ (MPa)", ValorPadrao = 40 } ],
                VariavelResultado = "τ_max",
                UnidadeResultado = "MPa",
                Calcular = vars => (vars["sigma1"] - vars["sigma3"]) / 2.0
            },
            new Formula
            {
                Id = "4_pl03", Nome = "Lei de Fluxo Associada", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "ε̇ᵖ = λ̇ · ∂f/∂σ  (f = superfície de escoamento)",
                ExprTexto = "ε̇ᵖ = λ̇·∂f/∂σ",
                Icone = "ε̇ᵖ",
                Descricao = "Deformação plástica normal à superfície de escoamento f(σ)=0 no espaço de tensões. λ̇≥0 (multiplicador plástico) determinado pela condição de consistência. Princípio de Hill.",
                ExemploPratico = "Exemplo: Multiplicador plástico λ̇=0.005, gradiente ∂f/∂σ=12 → ε̇ᵖ = 0.005×12 = 0.06 s⁻¹",
                Variaveis = [ new() { Simbolo = "lambda_", Nome = "Multiplic. λ̇ (s⁻¹)", ValorPadrao = 0.005, ValorMin = 0 }, new() { Simbolo = "df_dsigma", Nome = "Grad. ∂f/∂σ", ValorPadrao = 12 } ],
                VariavelResultado = "ε̇ᵖ",
                UnidadeResultado = "s⁻¹",
                Calcular = vars => vars["lambda_"] * vars["df_dsigma"]
            },
            new Formula
            {
                Id = "4_pl04", Nome = "Endurecimento Isotrópico", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "f(σ,κ) = σ_eq - σ_Y(κ) = 0;  κ = ∫dε_p (acumulada)",
                ExprTexto = "f=σeq−σY(κ)=0; κ=∫dεp",
                Icone = "κ",
                Descricao = "Superfície de escoamento expande uniformemente com deformação plástica acumulada κ. σY(κ) = curva tensão-deformação. Não captura efeito Bauschinger.",
                ExemploPratico = "Exemplo: Tensão equiv. σ_eq=250 MPa, limite escoam. σ_Y(κ)=200 MPa → f = 250-200 = 50 MPa (elasto-plástico)",
                Variaveis = [ new() { Simbolo = "σeq", Nome = "Tensão equiv. σ_eq (MPa)", ValorPadrao = 250 }, new() { Simbolo = "σY", Nome = "Limite σ_Y(κ) (MPa)", ValorPadrao = 200 } ],
                VariavelResultado = "f",
                UnidadeResultado = "MPa",
                Calcular = vars => vars["σeq"] - vars["σY"]
            },
            new Formula
            {
                Id = "4_pl05", Nome = "Endurecimento Cinemático", Categoria = "Hidrologia e Combustão", SubCategoria = "Plasticidade",
                Expressao = "f(σ-α) = 0; α̇ = c·ε̇ᵖ (backstress translada)",
                ExprTexto = "f(σ−α)=0; α̇=c·ε̇ᵖ",
                Icone = "α",
                Descricao = "Superfície translada (não expande): center α move na direção da deformação plástica. Captura efeito Bauschinger (limite menor em reversão). Modelo de Prager, Armstrong-Frederick.",
                ExemploPratico = "Exemplo: Centro backstress α=20 MPa desloca superfície de escoamento → tensão efetiva σ-α controla",
                Variaveis = [ new() { Simbolo = "σ", Nome = "Tensão σ (MPa)", ValorPadrao = 250 }, new() { Simbolo = "α", Nome = "Backstress α (MPa)", ValorPadrao = 20 } ],
                VariavelResultado = "σ-α",
                UnidadeResultado = "MPa",
                Calcular = vars => vars["σ"] - vars["α"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            // 18.3 Combustão
            new Formula
            {
                Id = "4_cb01", Nome = "Número de Damköhler", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "Da = τ_flow / τ_chem",
                ExprTexto = "Da = τflow/τchem",
                Icone = "Da",
                Descricao = "Razão entre tempos de transporte e reação. Da≫1: reação rápida, mistura controla. Da≪1: reação lenta, cinética controla. Da~1: regime mais complexo (interação).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Da", Nome = "Da", ValorPadrao = 1 }, new() { Simbolo = "tau", Nome = "tau", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Da"] + vars["tau"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "O", Nome = "O", ValorPadrao = 1 }, new() { Simbolo = "NO", Nome = "NO", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["O"] + vars["NO"]
            },
            new Formula
            {
                Id = "4_cb03", Nome = "Velocidade de Chama Laminar", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "S_L ~ √(α·ω̇);  α=difusividade, ω̇=taxa reação",
                ExprTexto = "SL ~ √(α·ω̇)",
                Icone = "SL",
                Descricao = "Velocidade de propagação de chama pré-misturada. Balanço difusão-reação: SL aumenta com difusividade térmica e taxa de reação. CH₄/ar: ~40 cm/s. H₂/ar: ~200 cm/s.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "A", Nome = "A", ValorPadrao = 2 }, new() { Simbolo = "Tⁿ", Nome = "Tⁿ", ValorPadrao = 3 }, new() { Simbolo = "exp", Nome = "exp", ValorPadrao = 4 } ],
                VariavelResultado = "k",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * vars["Tⁿ"] * vars["exp"]
            },
            new Formula
            {
                Id = "4_cb05", Nome = "Espessura de Chama", Categoria = "Hidrologia e Combustão", SubCategoria = "Combustão",
                Expressao = "δ_L = α/S_L  (difusividade/velocidade)",
                ExprTexto = "δL = α/SL",
                Icone = "δ",
                Descricao = "Espessura de chama laminar: ~0.1-1 mm para hidrocarbonetos em condições atmosféricas. Escala onde difusão molecular e reação se equilibram. Ka = (δL/η)² = número de Karlovitz (turbulência).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "α", Nome = "α", ValorPadrao = 10 }, new() { Simbolo = "SL", Nome = "SL", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "δL",
                UnidadeResultado = "",
                Calcular = vars => vars["α"] / vars["SL"]
            },
        ]);
    }
}
