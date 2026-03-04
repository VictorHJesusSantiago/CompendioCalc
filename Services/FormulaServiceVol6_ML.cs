using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 6 — PARTE III: ESTATÍSTICA / ML AVANÇADO (Seções 10-12)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 10. NORMALIZING FLOWS, NEURAL ODEs, EBMs E STATE SPACES
    // ─────────────────────────────────────────────────────
    private void AdicionarNormalizingFlows()
    {
        _formulas.AddRange([
            // 10.1 Normalizing Flows
            new Formula
            {
                Id = "6_nf01", Nome = "Change of Variables (Flow)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Normalizing Flows",
                Expressao = "log p(x) = log p(z) - log|det(∂f/∂z)|;  x = f(z)",
                ExprTexto = "log p(x) = log p(z) − log|det J_f|; change of variables",
                Icone = "f",
                Descricao = "Fórmula de mudança de variáveis para normalizing flows: densidade pr(x) obtida da base p(z) via jacobiano da transformação invertível f.",
                Criador = "Danilo Rezende / Shakir Mohamed",
                AnoOrigin = "2015",
            },
            new Formula
            {
                Id = "6_nf02", Nome = "RealNVP", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Normalizing Flows",
                Expressao = "y₁=x₁;  y₂=x₂⊙exp(s(x₁))+t(x₁);  det J=exp(Σs)",
                ExprTexto = "RealNVP: y₁=x₁, y₂=x₂·exp(s(x₁))+t(x₁); det trivial",
                Icone = "NVP",
                Descricao = "RealNVP: acoplamento afim que divide dados em duas metades. Jacobiano triangular → determinante trivial O(d). Invertível por construção. Base de flows modernos.",
                Criador = "Laurent Dinh / Jascha Sohl-Dickstein / Samy Bengio",
                AnoOrigin = "2016",
            },
            new Formula
            {
                Id = "6_nf03", Nome = "GLOW (1×1 Convolution)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Normalizing Flows",
                Expressao = "log|det W| = h·w·log|det W̃|;  W̃ ∈ ℝ^{c×c}",
                ExprTexto = "Glow: convolução 1×1 invertível com det computável O(c³)",
                Icone = "Glow",
                Descricao = "Glow: normalizing flow com convolução 1×1 invertível (substituindo permutação). Permite geração de imagens de alta resolução. Decomposição LU para eficiência.",
                Criador = "Diederik Kingma / Prafulla Dhariwal",
                AnoOrigin = "2018",
            },
            new Formula
            {
                Id = "6_nf04", Nome = "Continuous Normalizing Flow (CNF)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Normalizing Flows",
                Expressao = "dz/dt = f(z,t);  ∂log p(z)/∂t = -tr(∂f/∂z)",
                ExprTexto = "dz/dt = f(z,t); d·log p/dt = −tr(df/dz) (instantaneous change)",
                Icone = "CNF",
                Descricao = "CNF: normalizing flow contínuo no tempo via ODE. Evolução da log-densidade pelo traço do jacobiano (equação de continuidade). Não necessita arquitetura invertível.",
                Criador = "Ricky Chen / Yulia Rubanova / Jesse Bettencourt / David Duvenaud",
                AnoOrigin = "2018",
            },
            new Formula
            {
                Id = "6_nf05", Nome = "Estimador de Hutchinson (Traço)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Normalizing Flows",
                Expressao = "tr(A) = E[v^T A v];  v ~ N(0,I) ou Rademacher",
                ExprTexto = "tr(A) = E[vᵀAv]; estimador estocástico de traço",
                Icone = "tr",
                Descricao = "Estimador de Hutchinson: aproxima tr(J) via E[vᵀJv] com v aleatório. Evita computar jacobiano completo em CNFs. Complexidade O(d) por amostra.",
                Criador = "Michael Hutchinson",
                AnoOrigin = "1989",
            },
            new Formula
            {
                Id = "6_nf06", Nome = "Neural Spline Flow", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Normalizing Flows",
                Expressao = "f(x) = spline racional-quadrática monotônica;  det J analítico",
                ExprTexto = "Spline flow: transformação monotônica por spline racional → det analítico",
                Icone = "NSF",
                Descricao = "Neural spline flow: usa splines racionais-quadráticas monotônicas como transformação elementar. Muito flexível e exata. Jacobiano analítico por segmento.",
                Criador = "Conor Durkan / Artur Bekasov / Iain Murray / George Papamakarios",
                AnoOrigin = "2019",
            },
            new Formula
            {
                Id = "6_nf07", Nome = "Variational Dequantization", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Normalizing Flows",
                Expressao = "log p(x) ≥ E_q[log p(x+u) - log q(u|x)];  u ~ q(·|x)",
                ExprTexto = "Dequantização variacional: log p(x) ≥ E_q[log p(x+u)−log q(u|x)]",
                Icone = "DQ",
                Descricao = "Dequantização variacional: adiciona ruído u com distribuição aprendida q(u|x) a dados discretos. Melhora log-likelihood de flows em dados inteiros (imagens).",
                Criador = "Jonathan Ho / Xi Chen / Aravind Srinivas / Yan Duan / Pieter Abbeel",
                AnoOrigin = "2019",
            },

            // 10.2 Neural ODEs
            new Formula
            {
                Id = "6_no01", Nome = "Neural ODE", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Neural ODEs",
                Expressao = "dh/dt = f_θ(h,t);  h(T) = h(0) + ∫₀ᵀ f_θ(h,t) dt",
                ExprTexto = "dh/dt = fθ(h,t); estado oculto evolui por ODE paramétrica",
                Icone = "NODE",
                Descricao = "Neural ODE: camadas de rede neural como ODE contínua. Estado oculto evolui por fθ. Memória O(1) via método adjunto. Profundidade adaptativa pelo solver.",
                Criador = "Ricky Chen / Yulia Rubanova / Jesse Bettencourt / David Duvenaud",
                AnoOrigin = "2018",
            },
            new Formula
            {
                Id = "6_no02", Nome = "Método Adjunto (Neural ODE)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Neural ODEs",
                Expressao = "a(t) = -∂L/∂h(t);  da/dt = -a(t)ᵀ ∂f/∂h;  dL/dθ = -∫ aᵀ ∂f/∂θ dt",
                ExprTexto = "Adjunto: a(t)=−∂L/∂h; da/dt=−aᵀ·∂f/∂h; integra backward",
                Icone = "adj",
                Descricao = "Método adjunto para gradientes em Neural ODE: integra estado adjunto backward no tempo. Memória O(1) independente da profundidade. Análogo a backprop contínuo.",
                Criador = "Lev Pontryagin (original) / Chen et al. (neural)",
                AnoOrigin = "2018",
            },
            new Formula
            {
                Id = "6_no03", Nome = "Augmented Neural ODE", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Neural ODEs",
                Expressao = "d/dt [h; a] = [f_θ(h,a,t); g_θ(h,a,t)];  a = dimensão extra",
                ExprTexto = "Augmented: aumenta espaço de estado [h;a] para cruzar trajetórias",
                Icone = "ANODE",
                Descricao = "Augmented Neural ODE: adiciona dimensões extras para permitir que trajetórias se cruzem em projeção. Resolve limitação de bijetividade do espaço original.",
                Criador = "Emilien Dupont / Arnaud Doucet / Yee Whye Teh",
                AnoOrigin = "2019",
            },
            new Formula
            {
                Id = "6_no04", Nome = "Latent ODE", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Neural ODEs",
                Expressao = "z₀ ~ q(z₀|x);  z(t) = ODESolve(f_θ, z₀, t);  x(t) ~ p(x|z(t))",
                ExprTexto = "Latent ODE: encoder → z₀ → ODE → decoder em cada tempo",
                Icone = "LODE",
                Descricao = "Latent ODE: VAE com dinâmica latente via Neural ODE. Encoder RNN produz z₀, ODE evolui no espaço latente, decoder produz observações. Séries temporais irregulares.",
                Criador = "Yulia Rubanova / Ricky Chen / David Duvenaud",
                AnoOrigin = "2019",
            },
            new Formula
            {
                Id = "6_no05", Nome = "Neural SDE", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Neural ODEs",
                Expressao = "dX = f_θ(X,t)dt + g_θ(X,t)dW",
                ExprTexto = "Neural SDE: drift fθ + difusão gθ·dW estocástico",
                Icone = "NSDE",
                Descricao = "Neural SDE: extensão estocástica da Neural ODE. Drift e difusão parametrizados por redes. Modela incerteza e conecta score matching a dinâmicas generativas.",
                Criador = "Xuechen Li / Ting-Kam Leonard Wong / Ricky Chen / David Duvenaud",
                AnoOrigin = "2020",
            },
            new Formula
            {
                Id = "6_no06", Nome = "Neural CDE (Controlled DE)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "Neural ODEs",
                Expressao = "dz = f_θ(z) dX;  X(t) = interpolação do sinal de entrada",
                ExprTexto = "Neural CDE: dz = fθ(z)·dX; controlada pelo sinal de entrada X",
                Icone = "CDE",
                Descricao = "Neural CDE: equação diferencial controlada pelo caminho de entrada X. Modelo contínuo para séries temporais irregulares. Generaliza RNNs e Neural ODEs.",
                Criador = "Patrick Kidger / James Morrill / James Foster / Terry Lyons",
                AnoOrigin = "2020",
            },

            // 10.3 EBMs e State Space Models
            new Formula
            {
                Id = "6_eb01", Nome = "Energy-Based Model (EBM)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "EBMs e State Spaces",
                Expressao = "p_θ(x) = exp(-E_θ(x)) / Z_θ;  Z_θ = ∫ exp(-E_θ(x)) dx",
                ExprTexto = "p(x) = exp(−Eθ(x))/Z; modelo baseado em energia",
                Icone = "E",
                Descricao = "Energy-Based Model: define distribuição via função de energia Eθ. Treinamento por contrastive divergence ou score matching. Z intratável em geral.",
                Criador = "Yann LeCun / Sumit Chopra / Raia Hadsell",
                AnoOrigin = "2006",
            },
            new Formula
            {
                Id = "6_eb02", Nome = "Score Matching", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "EBMs e State Spaces",
                Expressao = "L = E_p[½‖s_θ(x)‖² + tr(∂s_θ/∂x)];  s_θ ≈ ∇log p",
                ExprTexto = "Score matching: L = E[½‖sθ‖² + tr(∂sθ/∂x)]; aprende ∇log p",
                Icone = "SM",
                Descricao = "Score matching: treina rede sθ para aproximar o score ∇log p(x) sem conhecer Z. Perda envolve traço do jacobiano. Base de modelos de difusão.",
                Criador = "Aapo Hyvärinen",
                AnoOrigin = "2005",
            },
            new Formula
            {
                Id = "6_eb03", Nome = "Langevin Dynamics (Amostragem)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "EBMs e State Spaces",
                Expressao = "x_{t+1} = x_t + (ε/2)∇log p(x_t) + √ε · z;  z ~ N(0,I)",
                ExprTexto = "Langevin: xₜ₊₁ = xₜ + (ε/2)·∇log p + √ε·z",
                Icone = "LD",
                Descricao = "Langevin MCMC: amostra de p(x) via gradiente do log da densidade (score) + ruído gaussiano. Converge para a distribuição alvo quando ε→0.",
                Criador = "Paul Langevin (original) / Gareth Roberts / Richard Tweedie (MALA)",
                AnoOrigin = "1996",
            },
            new Formula
            {
                Id = "6_eb04", Nome = "Contrastive Divergence", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "EBMs e State Spaces",
                Expressao = "∂L/∂θ ≈ E_data[∂E/∂θ] - E_{CD-k}[∂E/∂θ]",
                ExprTexto = "CD-k: gradiente ≈ ⟨∂E/∂θ⟩_data − ⟨∂E/∂θ⟩_{k-steps MCMC}",
                Icone = "CD",
                Descricao = "Contrastive divergence: aproxima gradiente da log-likelihood de EBMs executando k passos de MCMC em vez de convergir. CD-1 usado em RBMs.",
                Criador = "Geoffrey Hinton",
                AnoOrigin = "2002",
            },
            new Formula
            {
                Id = "6_ss01", Nome = "State Space Model (S4)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "EBMs e State Spaces",
                Expressao = "x'(t) = Ax(t) + Bu(t);  y(t) = Cx(t) + Du(t)",
                ExprTexto = "SSM: x'=Ax+Bu, y=Cx+Du; espaço de estados linear contínuo",
                Icone = "S4",
                Descricao = "Structured State Space for Sequences (S4): modelo linear de espaço de estados com matriz A estruturada (HiPPO). Captura dependências de longo alcance eficientemente.",
                Criador = "Albert Gu / Karan Goel / Christopher Ré",
                AnoOrigin = "2021",
            },
            new Formula
            {
                Id = "6_ss02", Nome = "Mamba (Selective SSM)", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "EBMs e State Spaces",
                Expressao = "B(t)=s_B(x(t)), C(t)=s_C(x(t)), Δ(t)=softplus(s_Δ(x(t)))",
                ExprTexto = "Mamba: B,C,Δ dependentes da entrada (seletivo)",
                Icone = "Mb",
                Descricao = "Mamba: SSM seletivo onde parâmetros B,C,Δ dependem da entrada. Combina eficiência O(n) de SSMs com seletividade de Transformers. Alternativa competitiva.",
                Criador = "Albert Gu / Tri Dao",
                AnoOrigin = "2023",
            },
            new Formula
            {
                Id = "6_ss03", Nome = "Discretização ZOH do SSM", Categoria = "Normalizing Flows e Neural ODEs", SubCategoria = "EBMs e State Spaces",
                Expressao = "Ā = exp(ΔA);  B̄ = (ΔA)⁻¹(Ā-I)·ΔB",
                ExprTexto = "ZOH: Ā=exp(Δ·A), B̄=(Δ·A)⁻¹(Ā−I)·Δ·B",
                Icone = "ZOH",
                Descricao = "Discretização Zero-Order Hold: converte SSM contínuo em recorrência discreta. Ā=exp(ΔA) garante estabilidade. Permite convolução global O(n log n) via FFT.",
                Criador = "Albert Gu / Karan Goel / Christopher Ré",
                AnoOrigin = "2021",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 11. FLOW MATCHING, KAN, RESERVOIR COMPUTING E META-LEARNING
    // ─────────────────────────────────────────────────────
    private void AdicionarFlowMatchingMeta()
    {
        _formulas.AddRange([
            // 11.1 Flow Matching
            new Formula
            {
                Id = "6_fm01", Nome = "Conditional Flow Matching", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Flow Matching",
                Expressao = "L_CFM = E_{t,x₁}[‖v_θ(ψ_t(x₀),t) - u_t(ψ_t(x₀)|x₁)‖²]",
                ExprTexto = "LCFM = E[‖vθ(ψt(x₀),t) − ut(ψt(x₀)|x₁)‖²]",
                Icone = "CFM",
                Descricao = "Conditional flow matching: treina campo vetorial vθ para aproximar fluxo condicional ut. Mais simples que score matching; não requer simulação de SDE durante treino.",
                Criador = "Yaron Lipman / Ricky Chen / Heli Ben-Hamu / Maximilian Nickel",
                AnoOrigin = "2022",
            },
            new Formula
            {
                Id = "6_fm02", Nome = "Optimal Transport CFM", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Flow Matching",
                Expressao = "ψ_t(x₀|x₁) = (1-t)x₀ + tx₁ (caminho retilíneo OT)",
                ExprTexto = "OT-CFM: ψt = (1−t)x₀ + t·x₁; interpolação linear ótima",
                Icone = "OT",
                Descricao = "OT-CFM: flow matching com caminhos de transporte ótimo retilíneos. Interpolação linear entre ruído x₀ e dado x₁. Treinamento estável e rápido.",
                Criador = "Alexander Tong / Nikolay Malkin / Guillaume Huguet / Yanlei Zhang",
                AnoOrigin = "2023",
            },
            new Formula
            {
                Id = "6_fm03", Nome = "Rectified Flow", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Flow Matching",
                Expressao = "L = E[‖v_θ(x_t,t) - (x₁-x₀)‖²];  x_t = tx₁+(1-t)x₀",
                ExprTexto = "Rectified flow: minimiza ‖vθ−(x₁−x₀)‖² com interpolação linear",
                Icone = "RF",
                Descricao = "Rectified flow: aprende campo vetorial alvo (x₁−x₀) constante ao longo de caminhos retos. Iteração de 'reflow' endireita trajetórias para amostragem em poucos passos.",
                Criador = "Xingchao Liu / Chengyue Gong / Qiang Liu",
                AnoOrigin = "2022",
            },
            new Formula
            {
                Id = "6_fm04", Nome = "Stochastic Interpolant", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Flow Matching",
                Expressao = "x_t = α_t x₀ + β_t x₁ + σ_t ε;  ε ~ N(0,I)",
                ExprTexto = "Interpolante: xt = αt·x₀ + βt·x₁ + σt·ε; ruído Gaussian adicionado",
                Icone = "SI",
                Descricao = "Interpolante estocástico: framework unificado para difusão e flow matching. Parâmetros αt, βt, σt generalizam esquemas de ruído. Inclui DDPM e flow matching como casos.",
                Criador = "Michael Albergo / Nicholas Boffi / Eric Vanden-Eijnden",
                AnoOrigin = "2023",
            },
            new Formula
            {
                Id = "6_fm05", Nome = "Consistency Model", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Flow Matching",
                Expressao = "f_θ(x_t, t) = f_θ(x_{t'}, t')  ∀t,t'  (mesma trajetória)",
                ExprTexto = "Consistency: f(xₜ,t) = f(xₜ',t') ao longo da trajetória PF ODE",
                Icone = "CM",
                Descricao = "Consistency model: mapeia qualquer ponto de uma trajetória de difusão diretamente para a origem. Geração em um passo ou poucos passos sem solver iterativo.",
                Criador = "Yang Song / Prafulla Dhariwal / Mark Chen / Ilya Sutskever",
                AnoOrigin = "2023",
            },
            new Formula
            {
                Id = "6_fm06", Nome = "Guided Flow / Classifier-Free Guidance", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Flow Matching",
                Expressao = "ṽ = (1+w)v_θ(x,t,c) - w·v_θ(x,t,∅)",
                ExprTexto = "CFG: ṽ = (1+w)·vθ(x,t,c) − w·vθ(x,t,∅); amplifica condição",
                Icone = "CFG",
                Descricao = "Classifier-free guidance: combina modelo condicional e incondicional com peso w para amplificar a influência da condição c. Melhora qualidade/diversidade de geração.",
                Criador = "Jonathan Ho / Tim Salimans",
                AnoOrigin = "2022",
            },

            // 11.2 KAN e Reservoir Computing
            new Formula
            {
                Id = "6_ka01", Nome = "Kolmogorov-Arnold Network (KAN)", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "KAN e Reservoir Computing",
                Expressao = "f(x) = Σⱼ φⱼ(Σᵢ ψᵢⱼ(xᵢ));  ativações nas arestas, não nos nós",
                ExprTexto = "KAN: f(x) = Σ φⱼ(Σ ψij(xi)); funções aprendidas nas arestas",
                Icone = "KAN",
                Descricao = "KAN: rede baseada no teorema de Kolmogorov-Arnold. Funções de ativação aprendíveis (splines) nas arestas em vez de nós fixos. Interpretável e eficiente para EDPs.",
                Criador = "Ziming Liu / Yixuan Wang / Sachin Vaidya / Max Tegmark",
                AnoOrigin = "2024",
            },
            new Formula
            {
                Id = "6_ka02", Nome = "Teorema de Kolmogorov-Arnold", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "KAN e Reservoir Computing",
                Expressao = "f(x₁,...,xₙ) = Σ_{q=0}^{2n} Φ_q(Σ_{p=1}^n φ_{q,p}(xₚ))",
                ExprTexto = "f(x₁,...,xₙ) = Σ Φq(Σ φqp(xp)); decomposição em funções 1D",
                Icone = "KA",
                Descricao = "Teorema de representação de Kolmogorov-Arnold: toda função contínua multivariada é composição de somas e funções contínuas de uma variável. Base teórica das KANs.",
                Criador = "Andrey Kolmogorov / Vladimir Arnold",
                AnoOrigin = "1957",
            },
            new Formula
            {
                Id = "6_rc01", Nome = "Echo State Network (ESN)", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "KAN e Reservoir Computing",
                Expressao = "x(t+1) = tanh(W_in u(t) + W x(t));  y = W_out x(t)",
                ExprTexto = "ESN: x(t+1) = tanh(Win·u + W·x); W fixo, W_out aprendido",
                Icone = "ESN",
                Descricao = "Echo State Network: reservoir computing com pesos internos W fixos (aleatórios, ρ(W)<1). Apenas W_out é treinado por regressão linear. Eficiente para séries temporais.",
                Criador = "Herbert Jaeger",
                AnoOrigin = "2001",
            },
            new Formula
            {
                Id = "6_rc02", Nome = "Echo State Property", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "KAN e Reservoir Computing",
                Expressao = "ρ(W) < 1 (raio espectral);  efeito de entrada desvanece assintoticamente",
                ExprTexto = "ESP: ρ(W) < 1 garante que estado depende apenas de entrada recente",
                Icone = "ρ",
                Descricao = "Echo state property: raio espectral ρ(W)<1 garante que o reservatório esquece condições iniciais. Condição necessária (não suficiente) para estabilidade.",
                Criador = "Herbert Jaeger",
                AnoOrigin = "2001",
            },
            new Formula
            {
                Id = "6_rc03", Nome = "Liquid State Machine", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "KAN e Reservoir Computing",
                Expressao = "x(t) = (L_M u)(t);  rede SNN recorrente como circuito líquido",
                ExprTexto = "LSM: reservatório de neurônios spiking + readout linear",
                Icone = "LSM",
                Descricao = "Liquid State Machine: reservoir computing com neurônios spiking (rede recorrente de pulsos). Separação de entradas pelo reservatório + camada de saída treinável.",
                Criador = "Wolfgang Maass / Thomas Natschläger / Henry Markram",
                AnoOrigin = "2002",
            },
            new Formula
            {
                Id = "6_rc04", Nome = "Next Generation Reservoir Computing", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "KAN e Reservoir Computing",
                Expressao = "W_out = Y · X^T(X X^T + αI)⁻¹ (regressão ridge)",
                ExprTexto = "W_out por ridge regression: (YXᵀ)(XXᵀ+αI)⁻¹",
                Icone = "NGRC",
                Descricao = "NGRC: reservoir computing sem reservatório explícito — usa features não-lineares de delays temporais. Treinamento por ridge regression. Simples e eficaz para caos.",
                Criador = "Daniel Gauthier / Erik Bollt / Aaron Griffith",
                AnoOrigin = "2021",
            },

            // 11.3 Meta-Learning e RLHF
            new Formula
            {
                Id = "6_ml01", Nome = "MAML (Meta-Learning)", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Meta-Learning e RLHF",
                Expressao = "θ* = θ - α∇_θ Σᵢ L_Tᵢ(θ - β∇_θ L_Tᵢ(θ))",
                ExprTexto = "MAML: θ* = θ − α·∇Σ L_Ti(θ−β·∇L_Ti(θ)); gradient through gradient",
                Icone = "MAML",
                Descricao = "MAML: aprende inicialização θ que permite adaptação rápida a novas tarefas com poucos gradientes. Meta-gradiente via diferenciação through inner loop.",
                Criador = "Chelsea Finn / Pieter Abbeel / Sergey Levine",
                AnoOrigin = "2017",
            },
            new Formula
            {
                Id = "6_ml02", Nome = "Prototypical Networks", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Meta-Learning e RLHF",
                Expressao = "p(y=k|x) = softmax(-d(f_θ(x), c_k));  c_k = (1/|S_k|)Σ f_θ(xᵢ)",
                ExprTexto = "Proto: p(y=k|x) ∝ exp(−d(fθ(x), cₖ)); cₖ = média da classe",
                Icone = "PN",
                Descricao = "Prototypical Networks: classifica por distância ao protótipo (centróide) de cada classe no espaço de embedding. Simples e eficaz para few-shot classification.",
                Criador = "Jake Snell / Kevin Swersky / Richard Zemel",
                AnoOrigin = "2017",
            },
            new Formula
            {
                Id = "6_ml03", Nome = "Reptile", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Meta-Learning e RLHF",
                Expressao = "θ ← θ + ε(θ̃ᵢ - θ);  θ̃ᵢ = SGD^k(θ, Tᵢ)",
                ExprTexto = "Reptile: θ ← θ + ε·(θ̃−θ); θ̃ após k passos SGD na tarefa",
                Icone = "Rp",
                Descricao = "Reptile: meta-learning de primeira ordem. Média a direção θ̃−θ sobre tarefas. Não requer hessiana como MAML. Aproxima gradiente do meta-objetivo.",
                Criador = "Alex Nichol / Joshua Achiam / John Schulman",
                AnoOrigin = "2018",
            },
            new Formula
            {
                Id = "6_ml04", Nome = "In-Context Learning (ICL)", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Meta-Learning e RLHF",
                Expressao = "p(y|x, D_k) = Transformer(prompt = [x₁,y₁,...,xₖ,yₖ,x])",
                ExprTexto = "ICL: modelo condiciona em exemplos no prompt sem atualizar pesos",
                Icone = "ICL",
                Descricao = "In-context learning: LLMs aprendem nova tarefa do prompt com exemplos, sem fine-tuning. Transformer implementa implicitamente algo semelhante a gradient descent.",
                Criador = "Tom Brown / Benjamin Mann / OpenAI",
                AnoOrigin = "2020",
            },
            new Formula
            {
                Id = "6_ml05", Nome = "RLHF (PPO para LLMs)", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Meta-Learning e RLHF",
                Expressao = "max_π E[r_φ(x,y)] - β·KL(π‖π_ref);  r_φ = reward model",
                ExprTexto = "RLHF: max E[reward] − β·KL(π‖πref); alinha modelo com preferências",
                Icone = "RLHF",
                Descricao = "RLHF: treina LLM com feedback humano via reward model + PPO. Penalidade KL impede divergência da política de referência. Alinhamento de ChatGPT, Claude etc.",
                Criador = "Paul Christiano / Jan Leike / OpenAI / Anthropic",
                AnoOrigin = "2017",
            },
            new Formula
            {
                Id = "6_ml06", Nome = "DPO (Direct Preference Optimization)", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Meta-Learning e RLHF",
                Expressao = "L_DPO = -E[log σ(β log(π_θ(y_w|x)/π_ref(y_w|x)) - β log(π_θ(y_l|x)/π_ref(y_l|x)))]",
                ExprTexto = "DPO: L = −E[log σ(β·log πθ(yw)/πref(yw) − β·log πθ(yl)/πref(yl))]",
                Icone = "DPO",
                Descricao = "DPO: otimiza preferências diretamente no modelo sem reward model separado. Reparametriza RLHF como classificação sobre pares preferidos/rejeitados.",
                Criador = "Rafael Rafailov / Archit Sharma / Eric Mitchell / Stefano Ermon",
                AnoOrigin = "2023",
            },
            new Formula
            {
                Id = "6_ml07", Nome = "Constitutional AI (RLAIF)", Categoria = "Flow Matching e Meta-Learning", SubCategoria = "Meta-Learning e RLHF",
                Expressao = "r(x,y) ← LLM_judge(x, y, princípios);  π ← RLHF(r)",
                ExprTexto = "CAI: LLM julga segundo princípios → reward → RLHF",
                Icone = "CAI",
                Descricao = "Constitutional AI: LLM auto-avalia e revisa respostas segundo princípios constitucionais. Feedback de AI substitui parcialmente feedback humano (RLAIF). Escala alinhamento.",
                Criador = "Yuntao Bai / Saurav Kadavath / Anthropic",
                AnoOrigin = "2022",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 12. INFORMATION BOTTLENECK, PAC-BAYES E KERNEL METHODS
    // ─────────────────────────────────────────────────────
    private void AdicionarInfoBottleneckKernels()
    {
        _formulas.AddRange([
            // 12.1 Information Bottleneck
            new Formula
            {
                Id = "6_ib01", Nome = "Information Bottleneck", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Information Bottleneck",
                Expressao = "min_{p(t|x)} I(X;T) - β·I(T;Y)",
                ExprTexto = "IB: min I(X;T) − β·I(T;Y); comprimir X preservando Y",
                Icone = "IB",
                Descricao = "Information bottleneck: encontra representação T que comprime X (baixa I(X;T)) mas preserva informação sobre Y (alta I(T;Y)). β controla trade-off.",
                Criador = "Naftali Tishby / Fernando Pereira / William Bialek",
                AnoOrigin = "1999",
            },
            new Formula
            {
                Id = "6_ib02", Nome = "Deep Information Bottleneck", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Information Bottleneck",
                Expressao = "L = L_CE + β·I(X;Z);  I(X;Z) ≤ KL(q(Z|X)‖p(Z))",
                ExprTexto = "Deep IB: L = cross-entropy + β·KL(encoder‖prior)",
                Icone = "DIB",
                Descricao = "Deep IB: aplica IB a redes profundas usando bound variacional. Relacionado a VAE: encoder comprime, decoder decodifica. β controla regularização informacional.",
                Criador = "Alexander Alemi / Ian Fischer / Joshua Dillon / Kevin Murphy",
                AnoOrigin = "2016",
            },
            new Formula
            {
                Id = "6_ib03", Nome = "Curva de Informação", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Information Bottleneck",
                Expressao = "I(T;Y) = F(I(X;T));  curva côncava crescente no plano (I(X;T), I(T;Y))",
                ExprTexto = "Curva IB: I(T;Y) vs I(X;T) forma fronteira côncava ótima",
                Icone = "IC",
                Descricao = "Curva de informação: fronteira Pareto-ótima no plano compressão vs predição. Cada β gera um ponto. Transições de fase podem ocorrer em β críticos.",
                Criador = "Naftali Tishby / Fernando Pereira / William Bialek",
                AnoOrigin = "1999",
            },
            new Formula
            {
                Id = "6_ib04", Nome = "IB como Rate-Distortion", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Information Bottleneck",
                Expressao = "R(D) = min_{p(t|x): E[d]≤D} I(X;T);  distorção d = -log p(Y|T)",
                ExprTexto = "IB = rate-distortion com d = −log p(Y|T)",
                Icone = "RD",
                Descricao = "IB como rate-distortion: IB é caso especial de teoria rate-distortion de Shannon com distorção relevante (informação sobre Y perdida). Conecta ML à teoria da informação.",
                Criador = "Naftali Tishby",
                AnoOrigin = "1999",
            },

            // 12.2 PAC-Bayes
            new Formula
            {
                Id = "6_pb01", Nome = "Bound PAC-Bayes (McAllester)", Categoria = "Information Bottleneck e Kernels", SubCategoria = "PAC-Bayes",
                Expressao = "E_ρ[L(h)] ≤ E_ρ[L̂(h)] + √((KL(ρ‖π)+ln(n/δ))/(2n))",
                ExprTexto = "PAC-Bayes: risco ≤ risco empírico + √(KL+ln(n/δ))/(2n))",
                Icone = "PB",
                Descricao = "Bound PAC-Bayes: o risco esperado sob ρ é controlado pelo risco empírico mais KL(ρ‖π)/n. π = prior, ρ = posterior. Bound mais apertado que VC para redes.",
                Criador = "David McAllester",
                AnoOrigin = "1999",
            },
            new Formula
            {
                Id = "6_pb02", Nome = "PAC-Bayes-kl (Catoni/Maurer)", Categoria = "Information Bottleneck e Kernels", SubCategoria = "PAC-Bayes",
                Expressao = "kl(E_ρ[L̂] ‖ E_ρ[L]) ≤ (KL(ρ‖π) + ln(2√n/δ))/n",
                ExprTexto = "kl-PAC-Bayes: divergência kl entre empírico e verdadeiro ≤ (KL+log)/n",
                Icone = "kl",
                Descricao = "PAC-Bayes-kl: versão mais apertada usando divergência kl binomial. Permite bounds não-vacuosos para redes neurais com compressão de pesos.",
                Criador = "Andreas Maurer",
                AnoOrigin = "2004",
            },
            new Formula
            {
                Id = "6_pb03", Nome = "PAC-Bayes com Ruído Gaussiano", Categoria = "Information Bottleneck e Kernels", SubCategoria = "PAC-Bayes",
                Expressao = "ρ = N(w, σ²I);  π = N(0, λ²I);  KL = ‖w‖²/(2λ²) + d·ln(λ/σ) + ...",
                ExprTexto = "KL(N(w,σ²)‖N(0,λ²)) = ‖w‖²/(2λ²)+d·ln(λ/σ)−d/2+dσ²/(2λ²)",
                Icone = "Gσ",
                Descricao = "PAC-Bayes Gaussiano: posterior ρ = Gaussiana centrada nos pesos treinados. KL penaliza norma dos pesos e relação de variâncias. Bounds não-vacuosos para DNNs.",
                Criador = "Gintare Karolina Dziugaite / Daniel Roy",
                AnoOrigin = "2017",
            },
            new Formula
            {
                Id = "6_pb04", Nome = "Generalização via Flatness (PAC-Bayes)", Categoria = "Information Bottleneck e Kernels", SubCategoria = "PAC-Bayes",
                Expressao = "E_{u~N(0,σ²)}[L(w+u)] ≈ L(w) + (σ²/2)tr(H);  H = Hessiana",
                ExprTexto = "Flatness: E[L(w+u)] ≈ L(w)+σ²·tr(H)/2; mínimos planos generalizam",
                Icone = "H",
                Descricao = "Conexão PAC-Bayes-flatness: mínimos planos (baixo tr(H)) toleram perturbação gaussiana sem aumentar a perda. Explica por que SGD generaliza — prefere mínimos planos.",
                Criador = "Sepp Hochreiter / Jürgen Schmidhuber (flatness) / Dziugaite-Roy (PAC-Bayes)",
                AnoOrigin = "1997",
            },

            // 12.3 Kernel Methods Avançados
            new Formula
            {
                Id = "6_km01", Nome = "Neural Tangent Kernel (NTK)", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Kernel Methods",
                Expressao = "Θ(x,x') = ⟨∂f_θ/∂θ(x), ∂f_θ/∂θ(x')⟩;  Θ → Θ∞ quando largura→∞",
                ExprTexto = "NTK: Θ(x,x') = ⟨∇θf(x),∇θf(x')⟩; converge com largura→∞",
                Icone = "NTK",
                Descricao = "Neural Tangent Kernel: no limite de largura infinita, rede treinada com GD é equivalente a regressão kernel com NTK constante Θ∞. Lineariza a dinâmica.",
                Criador = "Arthur Jacot / Franck Gabriel / Clément Hongler",
                AnoOrigin = "2018",
            },
            new Formula
            {
                Id = "6_km02", Nome = "Kernel de Processo Gaussiano Neural", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Kernel Methods",
                Expressao = "K^L(x,x') = σ²_b + σ²_w E[φ(h)φ(h')];  h,h' ~ GP com K^{L-1}",
                ExprTexto = "NNGP: kernel da rede → GP no limite de largura infinita",
                Icone = "NNGP",
                Descricao = "NNGP kernel: redes com largura infinita convergem para processos gaussianos. Kernel K^L é recursão sobre camadas. Predição exata sem treinamento.",
                Criador = "Jaehoon Lee / Yasaman Bahri / Roman Novak / Samuel Schoenholz / Jeffrey Pennington / Jascha Sohl-Dickstein",
                AnoOrigin = "2018",
            },
            new Formula
            {
                Id = "6_km03", Nome = "Random Fourier Features", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Kernel Methods",
                Expressao = "k(x,y) ≈ z(x)ᵀz(y);  z(x) = √(2/D)[cos(ωⱼᵀx+bⱼ)]_{j=1}^D",
                ExprTexto = "RFF: k(x,y) ≈ z(x)ᵀz(y); z = cos(ωᵀx+b) features aleatórias",
                Icone = "RFF",
                Descricao = "Random Fourier Features: aproxima kernel shift-invariante por features aleatórias via teorema de Bochner. O(nD) em vez de O(n²). Escalabiliza métodos de kernel.",
                Criador = "Ali Rahimi / Benjamin Recht",
                AnoOrigin = "2007",
            },
            new Formula
            {
                Id = "6_km04", Nome = "Kernel Mean Embedding", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Kernel Methods",
                Expressao = "μ_P = E_{x~P}[k(x,·)] ∈ H;  MMD²(P,Q) = ‖μ_P - μ_Q‖²_H",
                ExprTexto = "μP = E[k(x,·)]; MMD = ‖μP−μQ‖ em RKHS",
                Icone = "MMD",
                Descricao = "Kernel mean embedding: representa distribuição P como elemento μP no RKHS. MMD mede distância entre distribuições. Kernel característico ⇒ MMD=0 iff P=Q.",
                Criador = "Alex Smola / Arthur Gretton / Kenji Fukumizu",
                AnoOrigin = "2007",
            },
            new Formula
            {
                Id = "6_km05", Nome = "RKHS e Teorema do Representante", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Kernel Methods",
                Expressao = "f* = argmin Σᵢ L(yᵢ,f(xᵢ)) + λ‖f‖²_H  ⇒  f* = Σᵢ αᵢ k(xᵢ,·)",
                ExprTexto = "Representante: min L+λ‖f‖² → f* = Σ αᵢ·k(xᵢ,·)",
                Icone = "R",
                Descricao = "Teorema do representante: solução ótima regularizada no RKHS é combinação linear de kernel nos pontos de treino. Reduz otimização infinito-dimensional a finita.",
                Criador = "Bernhard Schölkopf / Ralf Herbrich / Alex Smola",
                AnoOrigin = "2001",
            },
            new Formula
            {
                Id = "6_km06", Nome = "Sparse GP (Inducing Points)", Categoria = "Information Bottleneck e Kernels", SubCategoria = "Kernel Methods",
                Expressao = "p(f|y) ≈ q(f) = ∫ p(f|u)q(u)du;  u = f(Z), Z = inducing",
                ExprTexto = "Sparse GP: q(f) = ∫ p(f|u)·q(u)du; u nos inducing points Z",
                Icone = "SGP",
                Descricao = "GP esparso: aproxima posterior usando m≪n inducing points. ELBO variacional. Complexidade O(nm²) em vez de O(n³). SVGP para minibatches.",
                Criador = "Michalis Titsias / James Hensman",
                AnoOrigin = "2009",
            },
        ]);
    }
}
