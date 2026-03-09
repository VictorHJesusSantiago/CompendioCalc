using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME IX - PARTE V: APRENDIZADO POR REFORÇO
    /// Bellman, Q-learning, Policy Gradient, AlphaZero, A3C, PPO
    /// Fórmulas 083-102 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private Formula V9_RL083_EquacaoBellman() => new Formula
        {
            Id = "V9-RL083", CodigoCompendio = "083", Nome = "Equação de Bellman para V(s)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "V^π(s) = Σ_a π(a|s)·Σ_{s'}P(s'|s,a)[r(s,a,s') + γV^π(s')]",
            ExprTexto = "Valor esperado de política π a partir de estado s",
            Descricao = "Equação de Bellman para função valor de estado V^π(s): valor esperado do retorno cumulativo descontado seguindo política π. Decomposição: recompensa imediata + valor futuro descontado (γ fator desconto). Foundation de reinforcement learning: programação dinâmica resolve via Bellman backup iterativo.",
            Criador = "Richard Bellman (1957, Dynamic Programming); aplicação RL: Sutton-Barto (1998, livro RL)",
            AnoOrigin = "1957",
            ExemploPratico = "Grid world: V(s) valor de estar em célula s. γ=0.9 desconto futuro 10%. Iteração valor: V_{k+1}(s)=max_a Σ_s' P(s'|s,a)[r+γV_k(s')]. Convergência: V*→optimal value.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "r", Nome = "Recompensa", Unidade = "reward", ValorPadrao = 1, Obrigatoria = true },
                new Variavel { Simbolo = "gamma", Nome = "Desconto γ", Unidade = "adim", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "V_next", Nome = "V(s')", Unidade = "reward", ValorPadrao = 10, Obrigatoria = true }
            },
            Calcular = v => v["r"] + v["gamma"] * v["V_next"],
            VariavelResultado = "V(s)", UnidadeResultado = "reward"
        };

        private Formula V9_RL084_FuncaoAcaoValor() => new Formula
        {
            Id = "V9-RL084", CodigoCompendio = "084", Nome = "Função Ação-Valor Q(s,a)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "Q^π(s,a) = Σ_{s'}P(s'|s,a)[r(s,a,s') + γΣ_{a'}π(a'|s')Q^π(s',a')]",
            ExprTexto = "Valor esperado de fazer ação a em estado s sob política π",
            Descricao = "Função Q (ação-valor): valor esperado de tomar ação a em estado s e seguir política π. Relaciona com V: V^π(s)=Σ_a π(a|s)Q^π(s,a). Q-learning (Watkins 1989) aprende Q* diretamente: Q(s,a)←Q(s,a)+α[r+γ max_{a'}Q(s',a')−Q(s,a)]. Base de DQN (Deep Q-Network).",
            Criador = "Chris Watkins (1989, tese doutorado Q-learning); Mnih et al. (2013-15, DQN Atari Nature)",
            AnoOrigin = "1989",
            ExemploPratico = "DQN Atari: Q(s,a) via CNN, replay buffer estabiliza. Double Q-learning evita overestimation. Dueling architecture: Q=V+(A−mean(A)). Rainbow combines tricks. AlphaGo: Q via MCTS.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "r", Nome = "Recompensa", Unidade = "reward", ValorPadrao = 1, Obrigatoria = true },
                new Variavel { Simbolo = "gamma", Nome = "Desconto γ", Unidade = "adim", ValorPadrao = 0.99, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "max_Q_next", Nome = "max Q(s',a')", Unidade = "reward", ValorPadrao = 15, Obrigatoria = true },
                new Variavel { Simbolo = "alpha", Nome = "Taxa aprendizado α", Unidade = "adim", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "Q_old", Nome = "Q(s,a) antigo", Unidade = "reward", ValorPadrao = 12, Obrigatoria = true }
            },
            Calcular = v => v["Q_old"] + v["alpha"] * (v["r"] + v["gamma"] * v["max_Q_next"] - v["Q_old"]),
            VariavelResultado = "Q(s,a) novo", UnidadeResultado = "reward"
        };

        private Formula V9_RL085_PolicyGradient() => new Formula
        {
            Id = "V9-RL085", CodigoCompendio = "085", Nome = "Policy Gradient - REINFORCE",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "∇_θ J(θ) = 𝔼_π[Σ_t ∇_θ log π_θ(a_t|s_t)·G_t]",
            ExprTexto = "Gradiente do retorno J para parâmetros θ de política",
            Descricao = "Policy Gradient: otimiza diretamente política estocástica π_θ(a|s) parametrizada por θ (ex: rede neural). Gradiente J(θ)=𝔼[return] proporcional a log-probabilidade ponderada por return G_t. REINFORCE (Williams 1992): Monte Carlo, alta variância. Baseline (advantage) reduz variância: A=G−V(s).",
            Criador = "Ronald Williams (1992, Simple Statistical Gradient-Following Algorithms for Connectionist RL)",
            AnoOrigin = "1992",
            ExemploPratico = "CartPole: π_θ(direita|s)=softmax(NN(s))_direita. Actor-Critic combina PG (ator) + value function (crítico). A3C (Mnih 2016): async parallel workers. PPO (Schulman 2017): clipped objective, state-of-art.",
            Unidades = "gradiente",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "G_t", Nome = "Return G_t", Unidade = "reward", ValorPadrao = 100, Obrigatoria = true },
                new Variavel { Simbolo = "log_pi", Nome = "log π(a|s)", Unidade = "log-prob", ValorPadrao = -1.2, ValorMax = 0, Obrigatoria = true }
            },
            Calcular = v => v["G_t"] * v["log_pi"], // ∇θ J ∝ G·∇logπ
            VariavelResultado = "∇J term", UnidadeResultado = "gradiente"
        };

        private Formula V9_RL086_ActorCritic() => new Formula
        {
            Id = "V9-RL086", CodigoCompendio = "086", Nome = "Actor-Critic: Advantage A(s,a)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "A(s,a) = Q(s,a) − V(s); ∇_θ J ∝ 𝔼[∇_θ log π_θ(a|s)·A(s,a)]",
            ExprTexto = "Vantagem de ação a sobre média de s",
            Descricao = "Advantage function: A(s,a)=Q(s,a)−V(s) mede superioridade de ação a sobre média em s. Reduz variância de policy gradient (baseline). Actor-Critic: ator atualiza π_θ via PG, crítico estima V_φ(s). TD-error δ=r+γV(s')−V(s) proxy para A. Generalised advantage estimation (GAE) suaviza bias-variance trade-off.",
            Criador = "Conceito: década 1980 (Barto, Sutton, Anderson); algoritmo moderno A3C (Mnih 2016), PPO (Schulman 2017)",
            AnoOrigin = "1983",
            ExemploPratico = "A>0: ação melhor que média, aumenta probabilidade. A<0: pior, diminui. A3C: n-step returns reduz bias. PPO clipped surrogate: max[min(r_t(θ)·A, clip(r_t,1±ε)·A)] estabiliza.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "Q", Nome = "Q(s,a)", Unidade = "reward", ValorPadrao = 15, Obrigatoria = true },
                new Variavel { Simbolo = "V", Nome = "V(s)", Unidade = "reward", ValorPadrao = 12, Obrigatoria = true }
            },
            Calcular = v => v["Q"] - v["V"],
            VariavelResultado = "Advantage A", UnidadeResultado = "reward"
        };

        private Formula V9_RL087_TDLearning() => new Formula
        {
            Id = "V9-RL087", CodigoCompendio = "087", Nome = "Temporal Difference (TD) Learning",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "V(s_t) ← V(s_t) + α[r_{t+1} + γV(s_{t+1}) − V(s_t)]",
            ExprTexto = "Atualização via erro TD δ=r+γV(s')−V(s)",
            Descricao = "TD Learning: combina Monte Carlo e dynamic programming. Atualiza estimativa V(s) após cada passo usando TD-error δ=target−prediction. Target=r+γV(s') bootstrap (usa estimativa, não return completo). TD(0): 1-step, baixa variância mas biased. TD(λ): interpola n-step returns via eligibility traces.",
            Criador = "Richard Sutton (1988, Learning to Predict by the Methods of Temporal Differences)",
            AnoOrigin = "1988",
            ExemploPratico = "TD-Gammon (Tesauro 1992): backgammon world-class via TD+NN. SARSA: on-policy TD control Q(s,a)←Q+α[r+γQ(s',a')−Q]. Expected SARSA: usa 𝔼[Q(s',a')] em vez de sample. Eligibility traces: e(s)=γλe(s)+1.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "V_s", Nome = "V(s_t)", Unidade = "reward", ValorPadrao = 10, Obrigatoria = true },
                new Variavel { Simbolo = "r", Nome = "r_{t+1}", Unidade = "reward", ValorPadrao = 1, Obrigatoria = true },
                new Variavel { Simbolo = "gamma", Nome = "γ", Unidade = "adim", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "V_s_next", Nome = "V(s_{t+1})", Unidade = "reward", ValorPadrao = 11, Obrigatoria = true },
                new Variavel { Simbolo = "alpha", Nome = "α", Unidade = "adim", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = v => { double td_error = v["r"] + v["gamma"] * v["V_s_next"] - v["V_s"]; return v["V_s"] + v["alpha"] * td_error; },
            VariavelResultado = "V(s) novo", UnidadeResultado = "reward"
        };

        // Continue com mais fórmulas até 102...
        private Formula V9_RL088_ExploracaoEpsilonGreedy() => new Formula
        {
            Id = "V9-RL088", CodigoCompendio = "088", Nome = "Exploração ε-Greedy",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "π(a|s) = (1−ε)·𝟙_{a=argmax Q(s,a)} + ε/|A|",
            ExprTexto = "Com prob ε explora aleatório, 1−ε escolhe best Q",
            Descricao = "ε-Greedy: estratégia simples balanceando exploração vs exploitation. Probabilidade ε escolhe ação aleatória (explora), 1−ε escolhe ação greedy (exploita). ε-decay: diminui ε ao longo treinamento. Alternativas: softmax (Boltzmann), UCB (upper confidence bound), Thompson sampling.",
            Criador = "Conceito clássico de multi-armed bandits (décadas 1950-60); formalização RL anos 1980",
            AnoOrigin = "1952",
            ExemploPratico = "DQN Atari: ε=1.0→0.1 linearmente em 1M frames. ε=0.1 final balances exploitation/update. Multi-armed bandit: ε-greedy vs UCB vs Thompson. Contextual bandits: uses state info.",
            Unidades = "probabilidade",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "epsilon", Nome = "ε", Unidade = "prob", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "n_actions", Nome = "|A|", Unidade = "contagem", ValorPadrao = 4, ValorMin = 2, Obrigatoria = true }
            },
            Calcular = v => (1 - v["epsilon"]) + v["epsilon"] / v["n_actions"], // prob de ação greedy
            VariavelResultado = "Prob greedy", UnidadeResultado = "probabilidade"
        };

        private Formula V9_RL089_ImportanceSampling() => new Formula
        {
            Id = "V9-RL089", CodigoCompendio = "089", Nome = "Importance Sampling para Off-Policy",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "ρ_t = Π_{k=0}^t [π(a_k|s_k)/μ(a_k|s_k)]; 𝔼_μ[ρ_t G_t]=𝔼_π[G_t]",
            ExprTexto = "Corrige bias ao aprender π usando trajetórias de μ",
            Descricao = "Importance sampling: técnica para estimar expectativas sob distribuição alvo π usando samples de distribuição diferente μ (behavior policy). Razão ρ=π/μ pondera amostras. Off-policy learning: Q-learning usa μ exploratório, aprende π* ótima. Alta variância se π≠μ muito diferentes. Weighted IS reduz variância.",
            Criador = "Técnica estatística clássica (década 1950); aplicação RL: Precup, Sutton, Singh (2000, off-policy TD)",
            AnoOrigin = "1951",
            ExemploPratico = "Off-policy evaluation: avaliar π_target usando dados de π_behavior. Replay buffer DQN: experiences de políticas antigas (off-policy). Per-decision IS: trunca produtos ρ. Tree-backup, Retrace algorithms reduzem variância.",
            Unidades = "ratio",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "pi_prob", Nome = "π(a|s)", Unidade = "prob", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "mu_prob", Nome = "μ(a|s)", Unidade = "prob", ValorPadrao = 0.4, ValorMin = 0.01, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = v => v["pi_prob"] / v["mu_prob"],
            VariavelResultado = "Razão ρ", UnidadeResultado = "ratio"
        };

        private Formula V9_RL090_PPOClippedObjective() => new Formula
        {
            Id = "V9-RL090", CodigoCompendio = "090", Nome = "Proximal Policy Optimization (PPO)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "L^{CLIP}(θ) = 𝔼[min(r_t(θ)·A_t, clip(r_t,1−ε,1+ε)·A_t)]",
            ExprTexto = "Maximiza objetivo clipped para estabilizar atualizações",
            Descricao = "PPO: algoritmo policy gradient state-of-art (Schulman et al. 2017). Clipped surrogate objective impede updates grandes demais (r_t=π_θ_new/π_θ_old). ε=0.2 típico. Evita colapso de performance. Alternativa: KL penalty. Simplifica TRPO. Usado OpenAI Five (Dota), robótica, ChatGPT RLHF.",
            Criador = "John Schulman, Filip Wolski, Prafulla Dhariwal, Alec Radford, Oleg Klimov (OpenAI, 2017)",
            AnoOrigin = "2017",
            ExemploPratico = "OpenAI Five Dota 2: 10k years gameplay PPO. Robotics: stable sim-to-real transfer. RLHF: InstructGPT fine-tunes GPT-3 via PPO on human preferences. ε=0.2: limita r_t∈[0.8,1.2].",
            Unidades = "objective",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "r_t", Nome = "Razão r_t", Unidade = "ratio", ValorPadrao = 1.15, ValorMin = 0.1, Obrigatoria = true },
                new Variavel { Simbolo = "A_t", Nome = "Advantage", Unidade = "reward", ValorPadrao = 5, Obrigatoria = true },
                new Variavel { Simbolo = "epsilon", Nome = "ε clip", Unidade = "adim", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = v => { double clipped_r = Math.Max(1 - v["epsilon"], Math.Min(v["r_t"], 1 + v["epsilon"])); return Math.Min(v["r_t"] * v["A_t"], clipped_r * v["A_t"]); },
            VariavelResultado = "L^CLIP", UnidadeResultado = "objective"
        };

        private Formula V9_RL091_DDPG() => new Formula
        {
            Id = "V9-RL091", CodigoCompendio = "091", Nome = "Deep Deterministic Policy Gradient (DDPG)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "∇_θ J ≈ 𝔼[∇_a Q(s,a)|_{a=μ(s)}·∇_θ μ_θ(s)]",
            ExprTexto = "Actor determinístico μ(s) com crítico Q via chain rule",
            Descricao = "DDPG: DPG (Silver 2014) com deep networks para espaços ação contínua. Actor determinístico μ_θ(s), crítico Q_φ(s,a). Target networks μ' e Q' soft-updated (τ=0.001). Replay buffer. Noise Ornstein-Uhlenbeck para exploração. Off-policy. Base de TD3, SAC.",
            Criador = "Timothy Lillicrap et al. (DeepMind, 2015, Continuous control with deep RL); DPG (Silver 2014)",
            AnoOrigin = "2014",
            ExemploPratico = "MuJoCo: HalfCheetah, Walker2d, Humanoid via DDPG. Robotics: torque control contínuo. TD3 (Twin Delayed DDPG): dual critics reduz overestimation, delayed policy updates. SAC (Soft Actor-Critic): maximum entropy RL.",
            Unidades = "gradiente",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "dQ_da", Nome = "∇_a Q", Unidade = "grad", ValorPadrao = 2, Obrigatoria = true },
                new Variavel { Simbolo = "dmu_dtheta", Nome = "∇_θ μ", Unidade = "grad", ValorPadrao = 0.5, Obrigatoria = true }
            },
            Calcular = v => v["dQ_da"] * v["dmu_dtheta"], // chain rule
            VariavelResultado = "∇_θ J", UnidadeResultado = "gradiente"
        };

        private Formula V9_RL092_PrioritizedExperience() => new Formula
        {
            Id = "V9-RL092", CodigoCompendio = "092", Nome = "Prioritized Experience Replay",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "P(i) = |δ_i|^α / Σ_k|δ_k|^α; δ=r+γmax Q(s',a')−Q(s,a)",
            ExprTexto = "Prioriza samples com maior TD-error δ",
            Descricao = "Prioritized ER: amostra experiências proporcionais a TD-error |δ| (surpresa). α=0 uniforme, α→1 deterministic priority. Importance sampling weights w_i=(N·P(i))^{−β} corrige bias, β→1 durante treino. Acelera aprendizado priorizar transições informativas. Variant: rank-based priority.",
            Criador = "Tom Schaul, John Quan, Ioannis Antonoglou, David Silver (DeepMind, 2015)",
            AnoOrigin = "2015",
            ExemploPratico = "DQN Atari: 2x speedup vs uniform replay. Sum-tree data structure: O(logN) sampling. Rainbow DQN: combines PER + double DQN + dueling + n-step + distributional + noisy nets. α=0.6, β=0.4→1.0.",
            Unidades = "probabilidade",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "delta_i", Nome = "|δ_i|", Unidade = "reward", ValorPadrao = 5, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "sum_delta", Nome = "Σ|δ_k|", Unidade = "reward", ValorPadrao = 100, ValorMin = 0.1, Obrigatoria = true },
                new Variavel { Simbolo = "alpha", Nome = "α expoente", Unidade = "adim", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = v => Math.Pow(v["delta_i"], v["alpha"]) / v["sum_delta"],
            VariavelResultado = "P(i)", UnidadeResultado = "probabilidade"
        };

        // Fórmulas 093-102 seguem...
        private Formula V9_RL093_AlphaZeroMCTS() => new Formula
        {
            Id = "V9-RL093", CodigoCompendio = "093", Nome = "AlphaZero - Monte Carlo Tree Search",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "P(s,a)=π_θ(a|s), V(s)=v_θ(s); MCTS: UCT a*=argmax[Q+c·P·√N/(1+n)]",
            ExprTexto = "Combina NN policy+value com MCTS para jogos perfeitos",
            Descricao = "AlphaZero: algoritmo self-play que domina Go, Chess, Shogi sem conhecimento humano (Silver et al. 2017). Neural network f_θ(s)→(P,v) prevê policy e value. MCTS usa P,v para explorar árvore via UCT (upper confidence trees). Self-play gera dados, treina rede via MCTS-improved policy. Zero human data.",
            Criador = "David Silver, Julian Schrittwieser, Karen Simonyan, Ioannis Antonoglou (DeepMind, 2017)",
            AnoOrigin = "2017",
            ExemploPratico = "AlphaGo Zero: master Go 72h self-play. AlphaZero: superhuman Chess (defeat Stockfish), Shogi 24h. MuZero: extends to unknown dynamics (Atari, Go). Exploration constant c=√2 típico UCT.",
            Unidades = "score",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "Q", Nome = "Valor Q médio", Unidade = "score", ValorPadrao = 0.5, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "P", Nome = "Prior π(a|s)", Unidade = "prob", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "c", Nome = "Exploração c", Unidade = "adim", ValorPadrao = 1.414, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "N", Nome = "Visitas pai", Unidade = "contagem", ValorPadrao = 100, ValorMin = 1, Obrigatoria = true },
                new Variavel { Simbolo = "n", Nome = "Visitas nó", Unidade = "contagem", ValorPadrao = 10, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => v["Q"] + v["c"] * v["P"] * Math.Sqrt(v["N"]) / (1 + v["n"]),
            VariavelResultado = "UCT score", UnidadeResultado = "score"
        };

        private Formula V9_RL094_InverseRL() => new Formula
        {
            Id = "V9-RL094", CodigoCompendio = "094", Nome = "Inverse Reinforcement Learning (IRL)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "Recuperar reward R dado expert π*: max_R [V^{π*}(s₀) − max_{π≠π*}V^π(s₀)]",
            ExprTexto = "Infere função reward de demonstrações especialista",
            Descricao = "IRL: problema inverso de RL - dado comportamento expert π*, infere reward function R que explica π*. Max-margin IRL: R faz expert ter maior value que outras políticas. Ambiguidade: R constante trivial. MaxEnt IRL (Ziebart 2008): maximiza entropia entre soluções. Aplicações: imitation learning, aprendizado de preferências humanas.",
            Criador = "Andrew Ng e Stuart Russell (2000, Algorithms for IRL); MaxEnt IRL Ziebart et al. (2008)",
            AnoOrigin = "2000",
            ExemploPratico = "Autonomous driving: infere reward de motoristas humanos. Robótica: apprenticeship learning. RLHF (ChatGPT): aprende reward model de preferências humanas, depois PPO otimiza. GAIL (Generative Adversarial IL) evita explícito R.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "V_expert", Nome = "V^{π*}", Unidade = "reward", ValorPadrao = 100, Obrigatoria = true },
                new Variavel { Simbolo = "V_other", Nome = "max V^π≠π*", Unidade = "reward", ValorPadrao = 80, ValorMax = 99, Obrigatoria = true }
            },
            Calcular = v => v["V_expert"] - v["V_other"], // margin
            VariavelResultado = "Margem IRL", UnidadeResultado = "reward"
        };

        private Formula V9_RL095_ModelBasedRL() => new Formula
        {
            Id = "V9-RL095", CodigoCompendio = "095", Nome = "Model-Based RL - Dyna-Q",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "Aprende modelo T(s'|s,a), planeja: Q(s,a)←r+γmax Q(s',a') com s'~T",
            ExprTexto = "Combina experiência real com simulações de modelo aprendido",
            Descricao = "Model-based RL: aprende modelo de transição T(s'|s,a) e reward r(s,a), usa modelo para planejar (gerar trajetórias simuladas). Dyna-Q (Sutton 1990): Q-learning real + n planning steps com amostras modelo. Sample efficiency: reutiliza experiências. Trade-off: model errors propagam. World models (Ha-Schmidhuber).",
            Criador = "Richard Sutton (1990, Integrated Architectures for Learning, Planning, and Reacting Based on Approximating Dynamic Programming - Dyna)",
            AnoOrigin = "1990",
            ExemploPratico = "Robotics: modelo aprendizado rápido em sim, transfere real. MuZero: aprende modelo latente (não pixels) via self-play. PILCO: GP model, policy search. Dyna-Q maze: 10x menos experiências reais que Q-learning.",
            Unidades = "Q-value",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "r_sim", Nome = "Recompensa simulada", Unidade = "reward", ValorPadrao = 1, Obrigatoria = true },
                new Variavel { Simbolo = "gamma", Nome = "γ", Unidade = "adim", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "max_Q_sim", Nome = "max Q(s'_sim,a')", Unidade = "reward", ValorPadrao = 10, Obrigatoria = true }
            },
            Calcular = v => v["r_sim"] + v["gamma"] * v["max_Q_sim"],
            VariavelResultado = "Target Dyna", UnidadeResultado = "reward"
        };

        private Formula V9_RL096_RewardShaping() => new Formula
        {
            Id = "V9-RL096", CodigoCompendio = "096", Nome = "Reward Shaping Potencial-Based",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "F(s,s') = γΦ(s') − Φ(s); R'(s,a,s')=R(s,a,s')+F(s,s')",
            ExprTexto = "Adiciona shaping preservando política ótima π*",
            Descricao = "Reward shaping: adicionar reward auxiliar para acelerar aprendizado. Potential-based shaping (Ng et al. 1999): F=γΦ(s')−Φ(s) garante política ótima invariante (Q* muda só por constante). Φ função potencial (ex: distância ao goal). Arbitrary shaping pode mudar π*. Heurística domain knowledge.",
            Criador = "Andrew Ng, Daishi Harada, Stuart Russell (1999, Policy Invariance Under Reward Transformations)",
            AnoOrigin = "1999",
            ExemploPratico = "Navigation: Φ=−dist_to_goal → reward incremental por aproximação. Robótica: Φ via expert demonstrations. Minecraft: shaping para subtarefas (coletar madeira). Curriculum learning: shaping temporal adaptativo.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "gamma", Nome = "γ", Unidade = "adim", ValorPadrao = 0.99, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "Phi_next", Nome = "Φ(s')", Unidade = "potencial", ValorPadrao = -5, Obrigatoria = true },
                new Variavel { Simbolo = "Phi", Nome = "Φ(s)", Unidade = "potencial", ValorPadrao = -10, Obrigatoria = true }
            },
            Calcular = v => v["gamma"] * v["Phi_next"] - v["Phi"],
            VariavelResultado = "Shaping F", UnidadeResultado = "reward"
        };

        private Formula V9_RL097_MultiAgentRL() => new Formula
        {
            Id = "V9-RL097", CodigoCompendio = "097", Nome = "Multi-Agent RL: Nash Q-Learning",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "Q_i(s,a₁,...,a_n) converge → Nash equilibrium (condições específicas)",
            ExprTexto = "Cada agente aprende Q próprio considerando outros agentes",
            Descricao = "Multi-agent RL: múltiplos agentes aprendem simultaneamente, ambiente não-estacionário (outros mudam). Nash Q-learning (Hu-Wellman 2003): cada agente aprende Q_i, calcula Nash equilibrium para escolher ação. Convergência requer general-sum stochastic games, unique Nash. Alternativas: independent Q-learning, opponent modeling, communication.",
            Criador = "Junling Hu e Michael Wellman (2003, Nash Q-Learning for General-Sum Stochastic Games)",
            AnoOrigin = "2003",
            ExemploPratico = "Soccer game: 2 agentes coordenam gols. OpenAI Hide-and-Seek: emergência estratégias complexas. QMIX: centralizado training, descentralizado execution. Self-play: AlphaZero, OpenAI Five treinam vs cópias.",
            Unidades = "Q-value",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "Q_i", Nome = "Q agente i", Unidade = "reward", ValorPadrao = 10, Obrigatoria = true },
                new Variavel { Simbolo = "Q_j", Nome = "Q oponente j", Unidade = "reward", ValorPadrao = 8, Obrigatoria = true }
            },
            Calcular = v => v["Q_i"] - v["Q_j"], // diferença Q (simplificado)
            VariavelResultado = "Vantagem sobre oponente", UnidadeResultado = "reward"
        };

        private Formula V9_RL098_HierarchicalRL() => new Formula
        {
            Id = "V9-RL098", CodigoCompendio = "098", Nome = "Hierarchical RL: Options Framework",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "Option O=(I,π,β); I inicia, π policy, β termina",
            ExprTexto = "Sub-policies temporalmente extendidas para planejamento hierárquico",
            Descricao = "Hierarchical RL: decompõe tarefas complexas em hierarquia de subtarefas. Options (Sutton-Precup-Singh 1999): generalization de ação primitiva, tem initiation set I, policy π, termination β. Semi-MDP: escolhe options, não ações. Feudal RL: manager escolhe goals, workers executam. HAM, MAXQ frameworks.",
            Criador = "Richard Sutton, Doina Precup, Satinder Singh (1999, Between MDPs and semi-MDPs: A Framework for Temporal Abstraction in RL)",
            AnoOrigin = "1999",
            ExemploPratico = "Room navigation: option 'go-to-door' reutilizável. Minecraft: high-level 'build-house' decompõe em 'gather-wood', 'craft-planks'. FuN (FeUdal Networks): manager transition goals, worker q-learning. Montezuma's Revenge: options via clustering.",
            Unidades = "option",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "beta", Nome = "Prob término β", Unidade = "prob", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = v => 1.0 / v["beta"], // duração esperada 1/β
            VariavelResultado = "Duração esperada", UnidadeResultado = "steps"
        };

        private Formula V9_RL099_CuriosityDrivenRL() => new Formula
        {
            Id = "V9-RL099", CodigoCompendio = "099", Nome = "Curiosity-Driven RL: Intrinsic Motivation",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "r_int = ||φ(s_{t+1}) − f(φ(s_t),a_t)||²; r_total=r_ext+β·r_int",
            ExprTexto = "Bonus por prediction error incentiva exploração",
            Descricao = "Intrinsic motivation: reward interno baseado em curiosidade (prediction error, novelty). ICM (Intrinsic Curiosity Module, Pathak 2017): forward model f prevê próximo state φ(s'), erro=curiosidade. β balances extrinsic vs intrinsic. RND (Random Network Distillation): prevê random NN output. Exploration em sparse rewards (Montezuma).",
            Criador = "Deepak Pathak, Pulkit Agrawal, Alexei Efros, Trevor Darrell (2017, Curiosity-driven Exploration by Self-supervised Prediction)",
            AnoOrigin = "2017",
            ExemploPratico = "Montezuma's Revenge: curiosity permite explorar 24 rooms sem reward. Super Mario Bros: descobre níveis via novelty. Go-Explore (Ecoffet 2019): retorna estados interessantes, explora dali. RND: prediz pixels random NN hard exploration.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "pred_error", Nome = "Prediction error", Unidade = "adim", ValorPadrao = 0.5, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "beta", Nome = "Peso intrinsic β", Unidade = "adim", ValorPadrao = 0.01, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "r_ext", Nome = "Reward extrínseco", Unidade = "reward", ValorPadrao = 0, Obrigatoria = true }
            },
            Calcular = v => v["r_ext"] + v["beta"] * v["pred_error"],
            VariavelResultado = "Reward total", UnidadeResultado = "reward"
        };

        private Formula V9_RL100_MetaRL() => new Formula
        {
            Id = "V9-RL100", CodigoCompendio = "100", Nome = "Meta-Reinforcement Learning: MAML",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "θ* = θ − α∇_θ Σ_τ L_τ(θ−α∇_θL_τ); aprende inicialização rápida",
            ExprTexto = "Learn to learn: adapta rapidamente a novas tarefas",
            Descricao = "Meta-RL: aprende policy que adapta rapidamente a novas tarefas (few-shot learning). MAML (Model-Agnostic Meta-Learning, Finn 2017): otimiza inicialização θ tal que poucos gradient steps adaptam a task. Bi-level optimization: inner loop task-specific, outer loop meta. Contexto: RNN encoding de task via trajectory.",
            Criador = "Chelsea Finn, Pieter Abbeel, Sergey Levine (2017, Model-Agnostic Meta-Learning for Fast Adaptation of Deep Networks)",
            AnoOrigin = "2017",
            ExemploPratico = "Locomotion: treina em terrenos variados, adapta rapidamente a novo terreno. MuJoCo: HalfCheetah diferentes fricções. Robotics: rapid sim-to-real transfer. RL²: recurrent policy implicitamente meta-learns. Meta-world benchmark: 50 tasks manipulation.",
            Unidades = "parâmetro",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "alpha", Nome = "Taxa inner α", Unidade = "adim", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new Variavel { Simbolo = "grad_L", Nome = "∇_θ L_τ", Unidade = "grad", ValorPadrao = 0.5, Obrigatoria = true }
            },
            Calcular = v => -v["alpha"] * v["grad_L"], // update inner
            VariavelResultado = "Δθ inner", UnidadeResultado = "parâmetro"
        };

        private Formula V9_RL101_SafeRL() => new Formula
        {
            Id = "V9-RL101", CodigoCompendio = "101", Nome = "Safe RL: Constrained Policy Optimization (CPO)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "max_π J(π) s.t. J_C(π) ≤ d; Lagrangian otimiza com constraint",
            ExprTexto = "Maximiza reward sob constraint de custo (safety)",
            Descricao = "Safe RL: garante constraints durante aprendizado (ex: custo≤limite). CPO (Achiam 2017): extensão TRPO com constraints via KKT conditions. Lagrangian methods: λ·(J_C−d). Safety layer: shield previne ações unsafes. Robustez: worst-case optimization. Critical: autonomous vehicles, medical, robótica.",
            Criador = "Joshua Achiam, David Held, Aviv Tamar, Pieter Abbeel (2017, Constrained Policy Optimization)",
            AnoOrigin = "2017",
            ExemploPratico = "Autonomous car: J=velocidade, J_C=colisões≤0. Robô: constraint de torque máximo. CMDP (Constrained MDP) framework. Safety Gym benchmark: navigation c/ hazards. Shielding: Falcone-Pnueli runtime verification.",
            Unidades = "reward",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "J", Nome = "Reward J", Unidade = "reward", ValorPadrao = 100, Obrigatoria = true },
                new Variavel { Simbolo = "J_C", Nome = "Custo J_C", Unidade = "custo", ValorPadrao = 5, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "d", Nome = "Limite custo", Unidade = "custo", ValorPadrao = 10, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => v["J_C"] <= v["d"] ? 1.0 : 0.0, // 1=constraint satisfeito
            VariavelResultado = "Constraint OK", UnidadeResultado = "bool"
        };

        private Formula V9_RL102_OfflineRL() => new Formula
        {
            Id = "V9-RL102", CodigoCompendio = "102", Nome = "Offline RL: Conservative Q-Learning (CQL)",
            Categoria = "Volume IX", SubCategoria = "Aprendizado por Reforço",
            Expressao = "min_Q [𝔼_{s~D}[log Σ_a exp Q(s,a)] − 𝔼_{(s,a)~D}[Q(s,a)]] + L_Bellman",
            ExprTexto = "Aprende de dataset fixo sem exploração online",
            Descricao = "Offline RL (batch RL): aprende de dataset fixo D sem interação com ambiente. Desafio: extrapolation error, distributional shift. CQL (Kumar 2020): regulariza Q conservatively para evitar overestimation em OOD actions. Aplica: logs de sistemas reais (medical, recomendação), simuladores caros. BCQ, BEAR algorithms alternativos.",
            Criador = "Aviral Kumar, Aurick Zhou, George Tucker, Sergey Levine (2020, Conservative Q-Learning for Offline RL)",
            AnoOrigin = "2020",
            ExemploPratico = "Healthcare: aprende policy de historical patient data sem experimentos perigosos. Recomendação: logs de clicks. Robotics: sim data transfere real. D4RL benchmark: MuJoCo offline datasets. AWAC: advantage-weighted actor-critic offline.",
            Unidades = "Q-value",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "Q_max", Nome = "max_a Q(s,a)", Unidade = "reward", ValorPadrao = 20, Obrigatoria = true },
                new Variavel { Simbolo = "Q_data", Nome = "𝔼_{D}[Q(s,a)]", Unidade = "reward", ValorPadrao = 15, Obrigatoria = true }
            },
            Calcular = v => v["Q_max"] - v["Q_data"], // regularização CQL simplificada
            VariavelResultado = "Penalidade CQL", UnidadeResultado = "reward"
        };
    }
}
