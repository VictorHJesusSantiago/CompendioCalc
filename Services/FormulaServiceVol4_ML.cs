using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 4 — PARTE III: MACHINE LEARNING, ESTATÍSTICA AVANÇADA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 10. APRENDIZADO POR REFORÇO
    // ─────────────────────────────────────────────────────
    private void AdicionarAprendizadoReforco()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_rl01", Nome = "Processo de Decisão de Markov (MDP)", Categoria = "Aprendizado por Reforço", SubCategoria = "Fundamentos de RL",
                Expressao = "(S, A, P, R, γ); P(s'|s,a), R(s,a)",
                ExprTexto = "MDP = (S,A,P,R,γ)",
                Icone = "MDP",
                Descricao = "Framework para decisão sequencial: estados S, ações A, transições P(s'|s,a), recompensa R, desconto γ∈[0,1). Objetivo: maximizar retorno cumulativo descontado.",
                ExemploPratico = "Exemplo: |S|=10 estados, |A|=4 ações, R=5.0, γ=0.9 → cardinalidade MDP = 10×4×10 = 400 transições possíveis",
                Variaveis = [ new() { Simbolo = "|S|", Nome = "Número de estados |S|", ValorPadrao = 10, ValorMin = 2 }, new() { Simbolo = "|A|", Nome = "Número de ações |A|", ValorPadrao = 4, ValorMin = 1 } ],
                VariavelResultado = "|S|×|A|×|S| (transições)",
                UnidadeResultado = "",
                Calcular = vars => vars["|S|"] * vars["|A|"] * vars["|S|"]
            },
            new Formula
            {
                Id = "4_rl02", Nome = "Retorno Descontado", Categoria = "Aprendizado por Reforço", SubCategoria = "Fundamentos de RL",
                Expressao = "Gₜ = Σ_{k=0}^∞ γᵏ Rₜ₊ₖ₊₁",
                ExprTexto = "Gₜ = Σγᵏ·Rₜ₊ₖ₊₁",
                Icone = "G",
                Descricao = "Soma descontada de recompensas futuras. γ<1 garante convergência e prioriza recompensas imediatas. γ=0.99 é comum em problemas de horizonte longo.",
                ExemploPratico = "Exemplo: Recompensa R=10, desconto γ=0.9 → retorno infinito G = R/(1-γ) = 10/(1-0.9) = 100",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa por passo R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Fator de desconto γ", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 0.999 } ],
                VariavelResultado = "G (retorno descontado)",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] / (1.0 - vars["γ"])
            },
            new Formula
            {
                Id = "4_rl03", Nome = "Função Valor-Estado V(s)", Categoria = "Aprendizado por Reforço", SubCategoria = "Fundamentos de RL",
                Expressao = "Vπ(s) = E_π[Gₜ | Sₜ=s]",
                ExprTexto = "V^π(s) = 𝔼π[Gₜ|Sₜ=s]",
                Icone = "V",
                Descricao = "Valor esperado do retorno partindo de s seguindo política π. V*(s) = max_π Vπ(s) é a função valor ótima. Solução: equação de Bellman.",
                ExemploPratico = "Exemplo: Estado com R=5, γ=0.9, V(s')=20 → V(s) = R + γ·V(s') = 5 + 0.9×20 = 23",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa imediata R", ValorPadrao = 5 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "V'", Nome = "Valor próximo estado V(s')", ValorPadrao = 20 } ],
                VariavelResultado = "V(s)",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] + vars["γ"] * vars["V'"]
            },
            new Formula
            {
                Id = "4_rl04", Nome = "Função Valor-Ação Q(s,a)", Categoria = "Aprendizado por Reforço", SubCategoria = "Fundamentos de RL",
                Expressao = "Qπ(s,a) = E_π[Gₜ | Sₜ=s, Aₜ=a]",
                ExprTexto = "Q^π(s,a) = 𝔼π[Gₜ|Sₜ=s,Aₜ=a]",
                Icone = "Q",
                Descricao = "Valor de tomar ação a em estado s e depois seguir π. Q*(s,a) → política ótima: π*(s) = argmax_a Q*(s,a).",
                ExemploPratico = "Exemplo: Após ação: R=10, γ=0.9, maxQ'=15 → Q(s,a) = 10 + 0.9×15 = 23.5",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa imediata R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "maxQ'", Nome = "max Q(s',a')", ValorPadrao = 15 } ],
                VariavelResultado = "Q(s,a)",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] + vars["γ"] * vars["maxQ'"]
            },
            new Formula
            {
                Id = "4_rl05", Nome = "Equação de Bellman (V)", Categoria = "Aprendizado por Reforço", SubCategoria = "Fundamentos de RL",
                Expressao = "Vπ(s) = Σₐπ(a|s)Σs'P(s'|s,a)[R+γVπ(s')]",
                ExprTexto = "Vπ(s) = Σₐπ(a|s)Σₛ'P(s'|s,a)[R+γVπ(s')]",
                Icone = "Bell",
                Descricao = "Relação recursiva: valor = recompensa imediata + valor descontado do próximo estado. Base de programação dinâmica para MDPs.",
                Criador = "Richard Bellman",
                AnoOrigin = "1957",
                ExemploPratico = "Exemplo: Estado com R=5, γ=0.9, V_próx=20, π(a)=0.5 → V = 0.5[5+0.9×20] = 11.25",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 5 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "V'", Nome = "V próximo estado", ValorPadrao = 20 }, new() { Simbolo = "π", Nome = "Prob política π(a|s)", ValorPadrao = 0.5 } ],
                VariavelResultado = "V(s)",
                UnidadeResultado = "",
                Calcular = vars => vars["π"] * (vars["R"] + vars["γ"] * vars["V'"])
            },
            new Formula
            {
                Id = "4_rl06", Nome = "Equação de Optimalidade de Bellman", Categoria = "Aprendizado por Reforço", SubCategoria = "Fundamentos de RL",
                Expressao = "V*(s)=max_a Σs'P(s'|s,a)[R+γV*(s')]",
                ExprTexto = "V*(s) = maxₐ Σₛ'P[R+γV*(s')]",
                Icone = "V*",
                Descricao = "Versão ótima: escolhe a melhor ação. Ponto fixo da iteração de valor. Solução exata por programação dinâmica (policy iteration, value iteration).",
                ExemploPratico = "Exemplo: max_a com R=10, γ=0.95, V*(s')=100 → V*(s) = max[10+0.95×100] = 105",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.95 }, new() { Simbolo = "V*", Nome = "V* próximo", ValorPadrao = 100 } ],
                VariavelResultado = "V*(s)",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] + vars["γ"] * vars["V*"]
            },
            new Formula
            {
                Id = "4_rl07", Nome = "Temporal Difference TD(0)", Categoria = "Aprendizado por Reforço", SubCategoria = "Métodos TD",
                Expressao = "V(s) ← V(s) + α[R + γV(s') - V(s)]",
                ExprTexto = "V(s) ← V(s)+α[R+γV(s')−V(s)]",
                Icone = "TD",
                Descricao = "Atualização bootstrapping: usa estimativa V(s') ao invés de retorno completo. Online, incremental. Combina ideias de Monte Carlo e programação dinâmica.",
                Criador = "Richard Sutton",
                AnoOrigin = "1988",
                ExemploPratico = "Exemplo: V=15, α=0.1, R=10, γ=0.9, V'=20 → V_novo = 15 + 0.1[10+0.9×20−15] = 16.3",
                Variaveis = [ new() { Simbolo = "V", Nome = "V(s) atual", ValorPadrao = 15 }, new() { Simbolo = "α", Nome = "Taxa aprendizado α", ValorPadrao = 0.1 }, new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "V'", Nome = "V(s') próximo", ValorPadrao = 20 } ],
                VariavelResultado = "V_novo",
                UnidadeResultado = "",
                Calcular = vars => vars["V"] + vars["α"] * (vars["R"] + vars["γ"] * vars["V'"] - vars["V"])
            },
            new Formula
            {
                Id = "4_rl08", Nome = "SARSA", Categoria = "Aprendizado por Reforço", SubCategoria = "Métodos TD",
                Expressao = "Q(s,a) ← Q(s,a) + α[R+γQ(s',a')-Q(s,a)]",
                ExprTexto = "Q(s,a) ← Q(s,a)+α[R+γQ(s',a')−Q(s,a)]",
                Icone = "SARSA",
                Descricao = "On-policy TD: atualiza Q usando a ação a' realmente tomada em s'. Nome: S,A,R,S',A'. Converge para Q^π sob condições padrão.",
                ExemploPratico = "Exemplo: Q=15, α=0.1, R=8, γ=0.9, Q'=18 → Q_novo = 15 + 0.1[8+0.9×18−15] = 15.12",
                Variaveis = [ new() { Simbolo = "Q", Nome = "Q(s,a) atual", ValorPadrao = 15 }, new() { Simbolo = "α", Nome = "Taxa aprendizado α", ValorPadrao = 0.1 }, new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 8 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "Q'", Nome = "Q(s',a') tomado", ValorPadrao = 18 } ],
                VariavelResultado = "Q_novo",
                UnidadeResultado = "",
                Calcular = vars => vars["Q"] + vars["α"] * (vars["R"] + vars["γ"] * vars["Q'"] - vars["Q"])
            },
            new Formula
            {
                Id = "4_rl09", Nome = "Q-Learning", Categoria = "Aprendizado por Reforço", SubCategoria = "Métodos TD",
                Expressao = "Q(s,a) ← Q(s,a) + α[R+γ max_{a'}Q(s',a')-Q(s,a)]",
                ExprTexto = "Q(s,a) ← Q+α[R+γ maxₐ'Q(s',a')−Q]",
                Icone = "QL",
                Descricao = "Off-policy TD: usa max sobre ações (não a ação efetivamente tomada). Converge para Q* independente da política de exploração (ε-greedy).",
                Criador = "Christopher Watkins",
                AnoOrigin = "1989",
                ExemploPratico = "Exemplo: Q=15, α=0.1, R=10, γ=0.9, maxQ'=20 → Q_novo = 15 + 0.1[10+0.9×20−15] = 15.3",
                Variaveis = [ new() { Simbolo = "Q", Nome = "Q(s,a) atual", ValorPadrao = 15 }, new() { Simbolo = "α", Nome = "Taxa aprendizado α", ValorPadrao = 0.1 }, new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "maxQ'", Nome = "max Q(s',a')", ValorPadrao = 20 } ],
                VariavelResultado = "Q_novo",
                UnidadeResultado = "",
                Calcular = vars => vars["Q"] + vars["α"] * (vars["R"] + vars["γ"] * vars["maxQ'"] - vars["Q"])
            },
            new Formula
            {
                Id = "4_rl10", Nome = "DQN (Deep Q-Network)", Categoria = "Aprendizado por Reforço", SubCategoria = "Deep RL",
                Expressao = "L(θ) = E[(R+γ max_{a'}Q(s',a';θ⁻) - Q(s,a;θ))²]",
                ExprTexto = "L(θ) = 𝔼[(R+γmaxₐ'Q(s',a';θ⁻)−Q(s,a;θ))²]",
                Icone = "DQN",
                Descricao = "Q-learning com rede neural: introduz experience replay e target network θ⁻ para estabilidade. Breakthrough: Atari games com performance humana.",
                Criador = "DeepMind (Mnih et al.)",
                AnoOrigin = "2013",
                ExemploPratico = "Exemplo: Q=15, R=10, γ=0.9, maxQ'=20 → erro = 10+0.9×20−15 = 3 → L = 3² = 9",
                Variaveis = [ new() { Simbolo = "Q", Nome = "Q(s,a;θ)", ValorPadrao = 15 }, new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "maxQ'", Nome = "max Q(s',·;θ⁻)", ValorPadrao = 20 } ],
                VariavelResultado = "L(θ) (loss)",
                UnidadeResultado = "",
                Calcular = vars => { var err = vars["R"] + vars["γ"] * vars["maxQ'"] - vars["Q"]; return err * err; }
            },
            new Formula
            {
                Id = "4_rl11", Nome = "Double DQN", Categoria = "Aprendizado por Reforço", SubCategoria = "Deep RL",
                Expressao = "y = R + γQ(s', argmax_{a'}Q(s',a';θ); θ⁻)",
                ExprTexto = "y = R+γQ(s',argmax Q(s',a';θ);θ⁻)",
                Icone = "DDQN",
                Descricao = "Correge overestimation de DQN: seleciona ação com rede online θ mas avalia com target θ⁻. Melhora estabilidade e desempenho.",
                ExemploPratico = "Exemplo: R=10, γ=0.95, Q_target=25 → y = 10 + 0.95×25 = 33.75",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.95 }, new() { Simbolo = "Q_t", Nome = "Q target", ValorPadrao = 25 } ],
                VariavelResultado = "y (TD target)",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] + vars["γ"] * vars["Q_t"]
            },
            new Formula
            {
                Id = "4_rl12", Nome = "Policy Gradient (REINFORCE)", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "∇_θ J = E_π[∇_θ ln π(a|s;θ) · Gₜ]",
                ExprTexto = "∇θJ = 𝔼[∇θ ln π(a|s;θ)·Gₜ]",
                Icone = "PG",
                Descricao = "Teorema do gradiente de política: atualiza parâmetros θ na direção que aumenta probabilidade de ações com alto retorno. Monte Carlo: usa Gₜ completo.",
                Criador = "Ronald Williams",
                AnoOrigin = "1992",
                ExemploPratico = "Exemplo: ln π=-1.5, G=50 → gradiente = ln(π)×G = -1.5×50 = -75 (diminui prob desta ação)",
                Variaveis = [ new() { Simbolo = "lnπ", Nome = "ln π(a|s;θ)", ValorPadrao = -1.5 }, new() { Simbolo = "G", Nome = "Retorno Gₜ", ValorPadrao = 50 } ],
                VariavelResultado = "∇J (gradiente)",
                UnidadeResultado = "",
                Calcular = vars => vars["lnπ"] * vars["G"]
            },
            new Formula
            {
                Id = "4_rl13", Nome = "REINFORCE com Baseline", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "∇_θ J = E[∇_θ ln π(a|s;θ)(Gₜ - b(s))]",
                ExprTexto = "∇θJ = 𝔼[∇θ ln π·(Gₜ−b(s))]",
                Icone = "b(s)",
                Descricao = "Baseline b(s) (tipicamente V(s)) reduz variância sem introduzir viés. Gₜ-V(s) = estimativa de vantagem. Melhora significativa na prática.",
                ExemploPratico = "Exemplo: ln π=-1.2, G=50, baseline V=45 → gradiente = -1.2×(50−45) = -6",
                Variaveis = [ new() { Simbolo = "lnπ", Nome = "ln π(a|s;θ)", ValorPadrao = -1.2 }, new() { Simbolo = "G", Nome = "Retorno Gₜ", ValorPadrao = 50 }, new() { Simbolo = "b", Nome = "Baseline b(s)", ValorPadrao = 45 } ],
                VariavelResultado = "∇J (gradiente)",
                UnidadeResultado = "",
                Calcular = vars => vars["lnπ"] * (vars["G"] - vars["b"])
            },
            new Formula
            {
                Id = "4_rl14", Nome = "Função Vantagem", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "A(s,a) = Q(s,a) - V(s)",
                ExprTexto = "A(s,a) = Q(s,a)−V(s)",
                Icone = "A",
                Descricao = "Mede quão melhor é a ação a comparada à média em s. A>0: ação acima da média. Usado em A2C/A3C/PPO como sinal de gradiente.",
                ExemploPratico = "Exemplo: Q(s,a)=25, V(s)=20 → A(s,a) = 25−20 = 5 (ação 5 pontos melhor que média)",
                Variaveis = [ new() { Simbolo = "Q", Nome = "Q(s,a)", ValorPadrao = 25 }, new() { Simbolo = "V", Nome = "V(s)", ValorPadrao = 20 } ],
                VariavelResultado = "A(s,a) (vantagem)",
                UnidadeResultado = "",
                Calcular = vars => vars["Q"] - vars["V"]
            },
            new Formula
            {
                Id = "4_rl15", Nome = "Actor-Critic (A2C)", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "Actor: ∇θ ln π·δ;  Critic: δ=R+γV(s')-V(s)",
                ExprTexto = "Actor: ∇θ ln π·δ; Critic: TD error δ",
                Icone = "A2C",
                Descricao = "Combina policy gradient (actor) com estimator de valor (critic). Actor atualiza política; Critic estima vantagem via TD error δ. Menor variância que REINFORCE puro.",
                ExemploPratico = "Exemplo: R=10, γ=0.9, V'=20, V=18 → δ = 10+0.9×20−18 = 10 (sinal critic)",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "V'", Nome = "V(s')", ValorPadrao = 20 }, new() { Simbolo = "V", Nome = "V(s)", ValorPadrao = 18 } ],
                VariavelResultado = "δ (TD error)",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] + vars["γ"] * vars["V'"] - vars["V"]
            },
            new Formula
            {
                Id = "4_rl16", Nome = "A3C", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "Workers paralelos → gradiantes assíncronos para rede global",
                ExprTexto = "A3C: workers paralelos, atualização assíncrona",
                Icone = "A3C",
                Descricao = "Asynchronous Advantage Actor-Critic: múltiplos workers exploram em paralelo, enviando gradientes de forma assíncrona. Substitui experience replay por paralelismo.",
                Criador = "DeepMind (Mnih et al.)",
                AnoOrigin = "2016",
                ExemploPratico = "Exemplo: 8 workers, cada calcula gradiente local, agrega na rede global (speedup ~6-8x)",
                Variaveis = [ new() { Simbolo = "n_workers", Nome = "Número de workers", ValorPadrao = 8, ValorMin = 1 } ],
                VariavelResultado = "Speedup teórico",
                UnidadeResultado = "",
                Calcular = vars => vars["n_workers"] * 0.8
            },
            new Formula
            {
                Id = "4_rl17", Nome = "PPO (Proximal Policy Optimization)", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "L(θ)=E[min(rₜ(θ)Âₜ, clip(rₜ,1±ε)Âₜ)]",
                ExprTexto = "L=𝔼[min(rₜÂₜ,clip(rₜ,1±ε)Âₜ)]",
                Icone = "PPO",
                Descricao = "Restringe atualização de política via clipping: rₜ=π_new/π_old. Evita passos muito grandes. Simples, eficiente, default em muitas aplicações (robótica, RLHF/ChatGPT).",
                Criador = "OpenAI (Schulman et al.)",
                AnoOrigin = "2017",
                ExemploPratico = "Exemplo: r=1.25 (ratio), A=10 (advantage), ε=0.2 → clip(1.25, 0.8, 1.2) = 1.2 → min(1.25×10, 1.2×10) = 12",
                Variaveis = [ new() { Simbolo = "r", Nome = "Ratio π_new/π_old", ValorPadrao = 1.25 }, new() { Simbolo = "A", Nome = "Vantagem A", ValorPadrao = 10 }, new() { Simbolo = "ε", Nome = "Clip ε", ValorPadrao = 0.2 } ],
                VariavelResultado = "L(θ) (objetivo clipped)",
                UnidadeResultado = "",
                Calcular = vars => { var rClip = Math.Max(1-vars["ε"], Math.Min(1+vars["ε"], vars["r"])); return Math.Min(vars["r"] * vars["A"], rClip * vars["A"]); }
            },
            new Formula
            {
                Id = "4_rl18", Nome = "TRPO (Trust Region Policy Opt.)", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "max_θ E[rₜÂₜ]  s.t. KL(π_old‖π_new) ≤ δ",
                ExprTexto = "maxθ 𝔼[rₜÂₜ] s.t. KL≤δ",
                Icone = "TRPO",
                Descricao = "Restrição explícita de trust region via KL-divergence. Garante melhoria monótona teórica. PPO é simplificação prática (clip ≈ trust region).",
                Criador = "John Schulman et al.",
                AnoOrigin = "2015",
                ExemploPratico = "Exemplo: δ=0.01 (max KL), KL=0.008 → inside trust region (condição satisfeita)",
                Variaveis = [ new() { Simbolo = "δ", Nome = "Max KL δ", ValorPadrao = 0.01 }, new() { Simbolo = "KL", Nome = "KL atual", ValorPadrao = 0.008 } ],
                VariavelResultado = "margem (δ-KL)",
                UnidadeResultado = "",
                Calcular = vars => vars["δ"] - vars["KL"]
            },
            new Formula
            {
                Id = "4_rl19", Nome = "SAC (Soft Actor-Critic)", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "J(π) = E[Σ γᵗ(R + αH(π(·|s)))]",
                ExprTexto = "J=𝔼[Σγᵗ(R+αH(π))]",
                Icone = "SAC",
                Descricao = "Maximiza retorno + entropia da política (α = temperatura). Exploração automática, robustez. Off-policy, estável. Estado da arte em controle contínuo.",
                Criador = "Haarnoja et al. (Berkeley)",
                AnoOrigin = "2018",
                ExemploPratico = "Exemplo: R=10, α=0.2, H=1.5 (entropia) → objetivo = R + α·H = 10 + 0.2×1.5 = 10.3",
                Variaveis = [ new() { Simbolo = "R", Nome = "Recompensa R", ValorPadrao = 10 }, new() { Simbolo = "α", Nome = "Temperatura α", ValorPadrao = 0.2 }, new() { Simbolo = "H", Nome = "Entropia H(π)", ValorPadrao = 1.5 } ],
                VariavelResultado = "J(π) (objetivo)",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] + vars["α"] * vars["H"]
            },
            new Formula
            {
                Id = "4_rl20", Nome = "Generalized Advantage Estimation (GAE)", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "Â_GAE = Σ_{l=0}^∞ (γλ)ˡ δₜ₊ₗ;  δ=R+γV'-V",
                ExprTexto = "Â_GAE = Σ(γλ)ˡδₜ₊ₗ",
                Icone = "GAE",
                Descricao = "Média exponencial de estimadores de vantagem de n-passos. λ=0: TD(0) baixa variância/alto viés. λ=1: Monte Carlo alta variância/sem viés. λ=0.95 é comum.",
                Criador = "Schulman et al.",
                AnoOrigin = "2016",
                ExemploPratico = "Exemplo: δ=10 (TD error), γ=0.9, λ=0.95 → peso exponencial (γλ) = 0.855",
                Variaveis = [ new() { Simbolo = "δ", Nome = "TD error δ", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "Desconto γ", ValorPadrao = 0.9 }, new() { Simbolo = "λ", Nome = "Lambda λ", ValorPadrao = 0.95 } ],
                VariavelResultado = "Peso (γλ)",
                UnidadeResultado = "",
                Calcular = vars => vars["γ"] * vars["λ"]
            },
            new Formula
            {
                Id = "4_rl21", Nome = "RLHF (RL from Human Feedback)", Categoria = "Aprendizado por Reforço", SubCategoria = "Policy Gradient",
                Expressao = "max_θ E[R_φ(x,y)] - β·KL(π_θ‖π_ref)",
                ExprTexto = "maxθ 𝔼[Rφ(x,y)]−β·KL(πθ‖πref)",
                Icone = "RLHF",
                Descricao = "Treina modelo de recompensa R_φ a partir de preferências humanas, depois otimiza política com PPO mantendo KL próximo do modelo de referência. Base de ChatGPT/Claude/etc.",
                ExemploPratico = "Exemplo: R=8.5 (reward model), β=0.05, KL=0.1 → objetivo = 8.5 − 0.05×0.1 = 8.495",
                Variaveis = [ new() { Simbolo = "R", Nome = "Reward R_φ", ValorPadrao = 8.5 }, new() { Simbolo = "β", Nome = "Coef KL β", ValorPadrao = 0.05 }, new() { Simbolo = "KL", Nome = "KL(π‖π_ref)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Objetivo RLHF",
                UnidadeResultado = "",
                Calcular = vars => vars["R"] - vars["β"] * vars["KL"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 11. REDES NEURAIS EM GRAFOS E GEOMETRIA PROFUNDA
    // ─────────────────────────────────────────────────────
    private void AdicionarGNNGeometriaProfunda()
    {
        _formulas.AddRange([
            // 11.1 GNN
            new Formula
            {
                Id = "4_gn01", Nome = "GCN (Graph Convolutional Network)", Categoria = "GNN e Geometria Profunda", SubCategoria = "GNN",
                Expressao = "H⁽ˡ⁺¹⁾ = σ(D̃⁻¹/²ÃD̃⁻¹/²H⁽ˡ⁾W⁽ˡ⁾)",
                ExprTexto = "H'=σ(D̃⁻½ÃD̃⁻½HW)",
                Icone = "GCN",
                Descricao = "Convolução espectral simplificada em grafos. Ã=A+I (auto-loops), D̃=grau. Primeira ordem de filtros de Chebyshev. Propagação tipo difusão no grafo.",
                Criador = "Thomas Kipf / Max Welling",
                AnoOrigin = "2017",
                ExemploPratico = "Exemplo: H da camada l, |V|=100 nós, d=64 features → D̃⁻½ normaliza graus, resultado shape [100, d_out]",
                Variaveis = [ new() { Simbolo = "|V|", Nome = "Número de nós |V|", ValorPadrao = 100, ValorMin = 2 }, new() { Simbolo = "d", Nome = "Dimensão features d", ValorPadrao = 64 } ],
                VariavelResultado = "|V|×d (shape saída)",
                UnidadeResultado = "",
                Calcular = vars => vars["|V|"] * vars["d"]
            },
            new Formula
            {
                Id = "4_gn02", Nome = "GAT (Graph Attention Network)", Categoria = "GNN e Geometria Profunda", SubCategoria = "GNN",
                Expressao = "h'ᵢ = σ(Σⱼ αᵢⱼ Whⱼ); αᵢⱼ=softmax(a·[Whᵢ‖Whⱼ])",
                ExprTexto = "h'ᵢ=σ(Σαᵢⱼ·Whⱼ); αᵢⱼ via atenção",
                Icone = "GAT",
                Descricao = "Pesos de atenção aprendidos para vizinhos: αᵢⱼ depende dos features de i e j. Multi-head attention concatenada. Permite ponderar vizinhos diferentemente.",
                Criador = "Petar Veličković et al.",
                AnoOrigin = "2018",
                ExemploPratico = "Exemplo: 8 cabeças atenção, avg grau=5 vizinhos → calcula 8 pesos αij per vizinho, concatena",
                Variaveis = [ new() { Simbolo = "K", Nome = "Heads atenção K", ValorPadrao = 8, ValorMin = 1 }, new() { Simbolo = "d_k", Nome = "Dim per head", ValorPadrao = 8 } ],
                VariavelResultado = "d_out = K×d_k",
                UnidadeResultado = "",
                Calcular = vars => vars["K"] * vars["d_k"]
            },
            new Formula
            {
                Id = "4_gn03", Nome = "GraphSAGE", Categoria = "GNN e Geometria Profunda", SubCategoria = "GNN",
                Expressao = "h'ᵢ = σ(W·[hᵢ ‖ AGG({hⱼ: j∈N(i)})])",
                ExprTexto = "h'ᵢ = σ(W·[hᵢ‖AGG(N(i))])",
                Icone = "SAGE",
                Descricao = "Sample and Aggregate: amostra vizinhos e agrega (mean, LSTM, pool). Indutivo: funciona em nós não vistos no treino. Escalável para grafos grandes.",
                Criador = "Hamilton / Ying / Leskovec",
                AnoOrigin = "2017",
                ExemploPratico = "Exemplo: Sample S=10 vizinhos, d=128 feature dim → agregar 10 vetores → concat [d, d] = 2d",
                Variaveis = [ new() { Simbolo = "S", Nome = "Sample size S", ValorPadrao = 10, ValorMin = 1 }, new() { Simbolo = "d", Nome = "Feature dim d", ValorPadrao = 128 } ],
                VariavelResultado = "concat dim = 2d",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["d"]
            },
            new Formula
            {
                Id = "4_gn04", Nome = "Message Passing Neural Network (MPNN)", Categoria = "GNN e Geometria Profunda", SubCategoria = "GNN",
                Expressao = "mᵢ = Σⱼ M(hᵢ,hⱼ,eᵢⱼ); h'ᵢ=U(hᵢ,mᵢ)",
                ExprTexto = "mᵢ=Σⱼ M(hᵢ,hⱼ,eᵢⱼ); h'ᵢ=U(hᵢ,mᵢ)",
                Icone = "MPNN",
                Descricao = "Framework unificador: message function M, update function U. Engloba GCN, GAT, SchNet como casos especiais. Inclui features de aresta eᵢⱼ.",
                Criador = "Gilmer et al.",
                AnoOrigin = "2017",
                ExemploPratico = "Exemplo: |E|=500 arestas, cada aresta processa mensagem M(hi,hj,eij) → agrega 500 mensagens",
                Variaveis = [ new() { Simbolo = "|E|", Nome = "Número arestas |E|", ValorPadrao = 500, ValorMin = 1 }, new() { Simbolo = "d_msg", Nome = "Dim mensagem", ValorPadrao = 64 } ],
                VariavelResultado = "|E|×d_msg (total)",
                UnidadeResultado = "",
                Calcular = vars => vars["|E|"] * vars["d_msg"]
            },
            new Formula
            {
                Id = "4_gn05", Nome = "GIN (Graph Isomorphism Network)", Categoria = "GNN e Geometria Profunda", SubCategoria = "GNN",
                Expressao = "h'ᵢ = MLP((1+ε)hᵢ + Σⱼhⱼ)",
                ExprTexto = "h'ᵢ = MLP((1+ε)hᵢ+Σⱼhⱼ)",
                Icone = "GIN",
                Descricao = "Tão poderoso quanto WL test (Weisfeiler-Lehman) para distinguir grafos. ε aprendível ou fixo. Sum aggregation é mais expressivo que mean/max.",
                Criador = "Xu et al.",
                AnoOrigin = "2019",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_gn06", Nome = "Readout Global (Graph-Level)", Categoria = "GNN e Geometria Profunda", SubCategoria = "GNN",
                Expressao = "hG = READOUT({hᵢ: i∈G}) (mean, sum, attn pool)",
                ExprTexto = "hG = READOUT({hᵢ})",
                Icone = "pool",
                Descricao = "Agrega representações de nós para representação do grafo inteiro. Sum pooling: mais expressivo. Hierarchical pooling (DiffPool, TopK) para grafos grandes.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            // 11.2 Geometria Profunda e Equivariância
            new Formula
            {
                Id = "4_ge01", Nome = "Equivariância E(n)", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria Profunda",
                Expressao = "f(ρ_in(g)·x) = ρ_out(g)·f(x)  ∀g∈E(n)",
                ExprTexto = "f(ρᵢₙ(g)x) = ρₒᵤₜ(g)f(x) ∀g∈E(n)",
                Icone = "E(n)",
                Descricao = "Rede equivariante sob rotações, translações, reflexões. Features vetoriais/tensoriais transformam covarientemente. Essencial para moléculas, proteínas, pontos 3D.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_ge02", Nome = "EGNN (E(n) Equivariant GNN)", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria Profunda",
                Expressao = "xᵢ'=xᵢ+Σⱼ(xᵢ-xⱼ)φ(mᵢⱼ); hᵢ'=ψ(hᵢ,Σmᵢⱼ)",
                ExprTexto = "x'ᵢ=xᵢ+Σ(xᵢ−xⱼ)φ(m); h'ᵢ=ψ(hᵢ,Σm)",
                Icone = "EGNN",
                Descricao = "Coordenadas atualizam equivariantemente, features invariantemente. Simples e eficiente. Mensagens dependem de distâncias (invariante) e features dos nós.",
                Criador = "Satorras / Hoogeboom / Welling",
                AnoOrigin = "2021",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "xᵢ", Nome = "xᵢ", ValorPadrao = 10 }, new() { Simbolo = "Σ", Nome = "Σ", ValorPadrao = 5 } ],
                VariavelResultado = "ᵢ",
                UnidadeResultado = "",
                Calcular = vars => vars["xᵢ"] + vars["Σ"]
            },
            new Formula
            {
                Id = "4_ge03", Nome = "SE(3)-Transformer", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria Profunda",
                Expressao = "Features tipo-l: transformam sob rep. irredutível Dˡ de SO(3)",
                ExprTexto = "Features tipo-l sob Dˡ(SO(3)): l=0 escalar, l=1 vetor, l=2 tensor",
                Icone = "SE3",
                Descricao = "Attention mechanism equivariante com features de diferentes tipos (escalares, vetores, tensores). Usa harmônicos esféricos e coeficientes de Clebsch-Gordan.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_ge04", Nome = "AlphaFold2 (Evoformer)", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria Profunda",
                Expressao = "MSA + pair rep. + SE(3)-aware structure module → 3D coords",
                ExprTexto = "MSA ⊗ pair → Evoformer → Structure Module → coords 3D",
                Icone = "AF2",
                Descricao = "Predição de estrutura de proteínas com precisão experimental. Evoformer: atenção MSA ↔ pair. Structure module: coordenadas SE(3) equivariantes. Revolução em biologia estrutural.",
                Criador = "DeepMind (Jumper et al.)",
                AnoOrigin = "2021",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_ge05", Nome = "Harmônicos Esféricos", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria Profunda",
                Expressao = "Y^m_l(θ,φ): base para rep. irredutíveis de SO(3)",
                ExprTexto = "Yₗᵐ(θ,φ): base de rep. irred. SO(3)",
                Icone = "Yₗᵐ",
                Descricao = "Base angular para features equivariantes. l=0: escalar (1 comp.), l=1: vetor (3 comp.), l=2: tensor simétrico (5 comp.). Produto tensorial usa coef. de CG.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            // 11.3 Geometria da Informação
            new Formula
            {
                Id = "4_gi01", Nome = "Métrica de Fisher", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria da Informação",
                Expressao = "gᵢⱼ(θ) = E[∂ᵢ ln p · ∂ⱼ ln p]",
                ExprTexto = "gᵢⱼ = 𝔼[∂ᵢln p·∂ⱼln p]",
                Icone = "Fisher",
                Descricao = "Tensor métrico no espaço de distribuições paramétricas. Curvatura intrínseca mede 'distinguibilidade' de distribuições vizinhas. Base de Natural Gradient.",
                Criador = "Ronald Fisher / C.R. Rao",
                AnoOrigin = "1945",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "4_gi02", Nome = "Natural Gradient", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria da Informação",
                Expressao = "θ ← θ - η F⁻¹(θ)∇L(θ)",
                ExprTexto = "θ ← θ−η·F⁻¹∇L",
                Icone = "NG",
                Descricao = "Gradiente no espaço de Fisher (não euclidiano): corrige pela geometria do espaço de parâmetros. Invariante sob reparametrização. Adam ≈ aproximação diagonal.",
                Criador = "Shun'ichi Amari",
                AnoOrigin = "1998",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_gi03", Nome = "α-Conexão de Amari", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria da Informação",
                Expressao = "Família de conexões Γ⁽ᵅ⁾; α=1 (e-conexão), α=-1 (m-conexão)",
                ExprTexto = "Γ⁽ᵅ⁾: e-conexão(α=1), m-conexão(α=−1)",
                Icone = "∇ᵅ",
                Descricao = "Família uniparamétrica de conexões afins duais. α=±1 são duais Fisher-flat. Geodésicas e-conexão = família exponencial. Estrutura dualmente plana → projeções de Pythagorean.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_gi04", Nome = "Divergência de Bregman", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria da Informação",
                Expressao = "D_F(p‖q) = F(p) - F(q) - ∇F(q)·(p-q)",
                ExprTexto = "D_F(p‖q) = F(p)−F(q)−⟨∇F(q),p−q⟩",
                Icone = "D_F",
                Descricao = "Generalização de divergência via função convexa F. KL = Bregman com F=-entropia. Projeção de Bregman = projeção geodésica na geometria dual. Usada em clustering e boosting.",
                Criador = "Lev Bregman",
                AnoOrigin = "1967",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_gi05", Nome = "Curvatura de Fisher do Modelo Normal", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria da Informação",
                Expressao = "ds² = dμ²/σ² + 2dσ²/σ²  (Poincaré half-plane!)",
                ExprTexto = "ds²=dμ²/σ²+2dσ²/σ²",
                Icone = "ℋ",
                Descricao = "Espaço de normais (μ,σ) com métrica de Fisher é isométrico ao semiplano de Poincaré (curvatura -½). Geometria hiperbólica emerge naturalmente da estatística!",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "dμ²", Nome = "dμ²", ValorPadrao = 10 }, new() { Simbolo = "σ²", Nome = "σ²", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "ds²",
                UnidadeResultado = "",
                Calcular = vars => vars["dμ²"] / vars["σ²"]
            },
            new Formula
            {
                Id = "4_gi06", Nome = "Distância de Wasserstein (Info-Geom)", Categoria = "GNN e Geometria Profunda", SubCategoria = "Geometria da Informação",
                Expressao = "W₂²(N(μ₁,Σ₁),N(μ₂,Σ₂)) = ‖μ₁-μ₂‖² + Tr(...)",
                ExprTexto = "W₂²(N₁,N₂)=‖Δμ‖²+Tr(Σ₁+Σ₂−2(Σ₁½Σ₂Σ₁½)½)",
                Icone = "W₂",
                Descricao = "Distância de Wasserstein-2 entre gaussianas: fórmula fechada. Combina deslocamento de média + deformação de covariância. Geometria de Otto no espaço de medidas.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 12. TRANSPORTE ÓTIMO, WAVELETS E TDA
    // ─────────────────────────────────────────────────────
    private void AdicionarTransporteOtimoTDA()
    {
        _formulas.AddRange([
            // 12.1 Transporte Ótimo
            new Formula
            {
                Id = "4_to01", Nome = "Problema de Monge", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "inf_{T: T#μ=ν} ∫ c(x,T(x))dμ(x)",
                ExprTexto = "inf_{T#μ=ν} ∫c(x,T(x))dμ",
                Icone = "Monge",
                Descricao = "Encontrar mapa T que transporta medida μ para ν com custo mínimo. T#μ=ν (push-forward). Problema original (1781): mover terra com mínimo esforço.",
                Criador = "Gaspard Monge",
                AnoOrigin = "1781",
                ExemploPratico = "Exemplo: c=2.5 e π=0.4 => custo=1.0.",
                Variaveis = [ new() { Simbolo = "c", Nome = "Custo medio c", ValorPadrao = 2.5, ValorMin = 0 }, new() { Simbolo = "π", Nome = "Massa transportada π", ValorPadrao = 0.4, ValorMin = 0 } ],
                VariavelResultado = "Custo",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] * vars["π"]
            },
            new Formula
            {
                Id = "4_to02", Nome = "Problema de Kantorovich (Relaxação)", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "inf_{π∈Π(μ,ν)} ∫∫ c(x,y)dπ(x,y)",
                ExprTexto = "inf_{π∈Π(μ,ν)} ∫∫c(x,y)dπ",
                Icone = "Kant",
                Descricao = "Relaxação de Monge: permite planos de transporte (splitting de massa). Π(μ,ν) = acoplamentos com marginais μ e ν. Dual: Kantorovich-Rubinstein. Sempre tem solução.",
                Criador = "Leonid Kantorovich",
                AnoOrigin = "1942",
                ExemploPratico = "Exemplo: c=2.0 e π=0.35 => OT=0.7.",
                Variaveis = [ new() { Simbolo = "c", Nome = "Custo medio c", ValorPadrao = 2.0, ValorMin = 0 }, new() { Simbolo = "π", Nome = "Plano π", ValorPadrao = 0.35, ValorMin = 0 } ],
                VariavelResultado = "OT",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] * vars["π"]
            },
            new Formula
            {
                Id = "4_to03", Nome = "Distância de Wasserstein-p", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "Wₚ(μ,ν) = (inf_{π∈Π} ∫∫d(x,y)ᵖdπ)^{1/p}",
                ExprTexto = "Wₚ = (inf_π∫∫dᵖdπ)^{1/p}",
                Icone = "Wₚ",
                Descricao = "Métrica no espaço de medidas de probabilidade. W₁ = Earth Mover's Distance. W₂ mais usada (geometria de Otto). Metriza convergência fraca + momentos.",
                ExemploPratico = "Exemplo: W=1.6, p=2 => Wp≈1.2649.",
                Variaveis = [ new() { Simbolo = "W", Nome = "Energia Wp^p", ValorPadrao = 1.6, ValorMin = 0 }, new() { Simbolo = "p", Nome = "Ordem p", ValorPadrao = 2, ValorMin = 1 } ],
                VariavelResultado = "W_p",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["W"], 1.0 / vars["p"])
            },
            new Formula
            {
                Id = "4_to04", Nome = "Sinkhorn (OT Regularizado)", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "OT_ε(μ,ν) = inf_π ∫c dπ + ε·KL(π‖μ⊗ν)",
                ExprTexto = "OTε = inf_π∫cdπ+ε·KL(π‖μ⊗ν)",
                Icone = "Sink",
                Descricao = "Regularização entrópica: torna OT diferenciável e computável O(n²/ε). Algoritmo de Sinkhorn = iterações de normalização de linhas/colunas. GPU-friendly.",
                Criador = "Richard Sinkhorn / Marco Cuturi (ML)",
                AnoOrigin = "1964/2013",
                ExemploPratico = "Exemplo: cπ=1.2, ε=0.1, KL=0.8 => OTε=1.28.",
                Variaveis = [ new() { Simbolo = "cπ", Nome = "<c,π>", ValorPadrao = 1.2 }, new() { Simbolo = "ε", Nome = "Regularizacao ε", ValorPadrao = 0.1, ValorMin = 0 }, new() { Simbolo = "KL", Nome = "Divergencia KL", ValorPadrao = 0.8, ValorMin = 0 } ],
                VariavelResultado = "OT_ε",
                UnidadeResultado = "",
                Calcular = vars => vars["cπ"] + vars["ε"] * vars["KL"]
            },
            new Formula
            {
                Id = "4_to05", Nome = "Mapa de Brenier", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "T = ∇φ  (custo c=|x-y|²; μ abs. contínua)",
                ExprTexto = "T=∇φ (c=|x−y|², μ≪Lebesgue)",
                Icone = "∇φ",
                Descricao = "Para custo quadrático: mapa ótimo é gradiente de função convexa φ (potencial de Brenier). Unicidade da solução de Monge. Conexão com convexidade e Monge-Ampère.",
                Criador = "Yann Brenier",
                AnoOrigin = "1991",
                ExemploPratico = "Exemplo: ||∇φ||=1.4 => magnitude do mapa T=1.4.",
                Variaveis = [ new() { Simbolo = "∇", Nome = "Norma do gradiente ∇φ", ValorPadrao = 1.4, ValorMin = 0 } ],
                VariavelResultado = "T",
                UnidadeResultado = "",
                Calcular = vars => vars["∇"]
            },
            new Formula
            {
                Id = "4_to06", Nome = "Equação de Monge-Ampère", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "det(D²φ) = f(x)/g(∇φ(x))",
                ExprTexto = "det(D²φ) = f/g∘∇φ",
                Icone = "MA",
                Descricao = "PDE associada ao transporte ótimo quadrático: T=∇φ satisfaz esta equação. EDP totalmente não-linear. Regularidade de Caffarelli: φ é C^{1,α} sob condições de convexidade.",
                ExemploPratico = "Exemplo: f=1.2, g=0.9 => det(D²φ)≈1.3333.",
                Variaveis = [ new() { Simbolo = "f", Nome = "Densidade origem f", ValorPadrao = 1.2, ValorMin = 0 }, new() { Simbolo = "g", Nome = "Densidade destino g", ValorPadrao = 0.9, ValorMin = 0.0001 } ],
                VariavelResultado = "det(D²φ)",
                UnidadeResultado = "",
                Calcular = vars => vars["f"] / vars["g"]
            },
            new Formula
            {
                Id = "4_to07", Nome = "Dualidade de Kantorovich-Rubinstein", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "W₁(μ,ν) = sup_{‖f‖_Lip≤1} ∫f d(μ-ν)",
                ExprTexto = "W₁ = sup_{‖f‖_Lip≤1}(∫fdμ−∫fdν)",
                Icone = "KR",
                Descricao = "Dual de W₁: supremo sobre funções 1-Lipschitz. Base do WGAN (Wasserstein GAN): discriminador ≈ função Lipschitz, generator minimiza W₁.",
                ExemploPratico = "Exemplo: ∫f dμ=0.8 e ∫f dν=0.2 => W1 dual=0.6.",
                Variaveis = [ new() { Simbolo = "μ", Nome = "Media em μ", ValorPadrao = 0.8 }, new() { Simbolo = "ν", Nome = "Media em ν", ValorPadrao = 0.2 } ],
                VariavelResultado = "W1 dual",
                UnidadeResultado = "",
                Calcular = vars => Math.Abs(vars["μ"] - vars["ν"])
            },
            new Formula
            {
                Id = "4_to08", Nome = "Custo Esperado de Transporte", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "C(π)=Σᵢⱼ cᵢⱼ·πᵢⱼ",
                ExprTexto = "C(pi)=sum c_ij*pi_ij",
                Icone = "cπ",
                Descricao = "Custo total do plano de transporte π com matriz de custo c. Base de problemas discretos de OT.",
                ExemploPratico = "Exemplo: c=2.5, π=0.4 => contribuição média 1.0.",
                Variaveis = [ new() { Simbolo = "c", Nome = "Custo médio c", ValorPadrao = 2.5, ValorMin = 0 }, new() { Simbolo = "π", Nome = "Massa transportada π", ValorPadrao = 0.4, ValorMin = 0 } ],
                VariavelResultado = "C(π)",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] * vars["π"]
            },
            new Formula
            {
                Id = "4_to09", Nome = "Restrições de Marginais", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "Σⱼπᵢⱼ=μᵢ e Σᵢπᵢⱼ=νⱼ",
                ExprTexto = "row(pi)=mu, col(pi)=nu",
                Icone = "marg",
                Descricao = "Valida se o plano π respeita marginais de origem μ e destino ν.",
                ExemploPratico = "Exemplo: μ=1.0 e ν=0.95 => desbalanceamento 0.05.",
                Variaveis = [ new() { Simbolo = "μ", Nome = "Massa origem μ", ValorPadrao = 1.0, ValorMin = 0 }, new() { Simbolo = "ν", Nome = "Massa destino ν", ValorPadrao = 0.95, ValorMin = 0 } ],
                VariavelResultado = "|μ-ν|",
                UnidadeResultado = "",
                Calcular = vars => Math.Abs(vars["μ"] - vars["ν"])
            },
            new Formula
            {
                Id = "4_to10", Nome = "Distância de Wasserstein-1", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "W₁(μ,ν)=inf_{π∈Π(μ,ν)} Σ cᵢⱼπᵢⱼ",
                ExprTexto = "W1=min_pi <c,pi>",
                Icone = "W1",
                Descricao = "Earth Mover's Distance com custo linear. Mede esforço mínimo de realocação de massa.",
                ExemploPratico = "Exemplo: custo ótimo aproximado com c=3 e π=0.2 => W1~0.6.",
                Variaveis = [ new() { Simbolo = "c", Nome = "Custo c", ValorPadrao = 3.0, ValorMin = 0 }, new() { Simbolo = "π", Nome = "Plano ótimo π", ValorPadrao = 0.2, ValorMin = 0 } ],
                VariavelResultado = "W₁",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] * vars["π"]
            },
            new Formula
            {
                Id = "4_to11", Nome = "Distância de Wasserstein-2", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "W₂(μ,ν)=\u221a(inf_{π} Σ c²ᵢⱼπᵢⱼ)",
                ExprTexto = "W2=sqrt(min_pi sum c^2*pi)",
                Icone = "W2",
                Descricao = "Métrica quadrática de OT, comum em visão computacional e modelagem generativa.",
                ExemploPratico = "Exemplo: c=2 e π=0.25 => W2=sqrt(1)=1.",
                Variaveis = [ new() { Simbolo = "c", Nome = "Custo c", ValorPadrao = 2.0, ValorMin = 0 }, new() { Simbolo = "π", Nome = "Plano π", ValorPadrao = 0.25, ValorMin = 0 } ],
                VariavelResultado = "W₂",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["c"] * vars["c"] * vars["π"])
            },
            new Formula
            {
                Id = "4_to12", Nome = "Sinkhorn Divergence", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "S_ε(μ,ν)=OT_ε(μ,ν)-½OT_ε(μ,μ)-½OT_ε(ν,ν)",
                ExprTexto = "S_eps = OT(mu,nu)-0.5 OT(mu,mu)-0.5 OT(nu,nu)",
                Icone = "Sε",
                Descricao = "Corrige viés entrópico de OT_ε e preserva boas propriedades métricas em prática.",
                ExemploPratico = "Exemplo: OTmn=1.4, OTmm=1.0, OTnn=0.8 => Sε=0.5.",
                Variaveis = [ new() { Simbolo = "OTμν", Nome = "OT_ε(μ,ν)", ValorPadrao = 1.4 }, new() { Simbolo = "OTμμ", Nome = "OT_ε(μ,μ)", ValorPadrao = 1.0 }, new() { Simbolo = "OTνν", Nome = "OT_ε(ν,ν)", ValorPadrao = 0.8 } ],
                VariavelResultado = "S_ε",
                UnidadeResultado = "",
                Calcular = vars => vars["OTμν"] - 0.5 * vars["OTμμ"] - 0.5 * vars["OTνν"]
            },
            new Formula
            {
                Id = "4_to13", Nome = "Barycenter de Wasserstein", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "μ*=argmin_μ Σ_k λ_k W²(μ,μ_k)",
                ExprTexto = "mu*=argmin sum lambda_k W2^2(mu,mu_k)",
                Icone = "bar",
                Descricao = "Média geométrica de distribuições no espaço de Wasserstein.",
                ExemploPratico = "Exemplo: λ=0.6 e W=2.0 => contribuição 2.4.",
                Variaveis = [ new() { Simbolo = "λ", Nome = "Peso λ", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "W", Nome = "Distância W", ValorPadrao = 2.0, ValorMin = 0 } ],
                VariavelResultado = "λW²",
                UnidadeResultado = "",
                Calcular = vars => vars["λ"] * vars["W"] * vars["W"]
            },
            new Formula
            {
                Id = "4_to14", Nome = "Fluxo de Gradiente em Wasserstein", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "∂_tρ = ∇·(ρ∇(δF/δρ))",
                ExprTexto = "rho_t = div(rho grad deltaF/deltarho)",
                Icone = "flow",
                Descricao = "Equação de continuidade induzida por fluxo de gradiente no espaço de medidas.",
                ExemploPratico = "Exemplo: ρ=0.8 e gradiente=0.5 => fluxo 0.4.",
                Variaveis = [ new() { Simbolo = "ρ", Nome = "Densidade ρ", ValorPadrao = 0.8, ValorMin = 0 }, new() { Simbolo = "g", Nome = "Gradiente efetivo", ValorPadrao = 0.5 } ],
                VariavelResultado = "ρg",
                UnidadeResultado = "",
                Calcular = vars => vars["ρ"] * vars["g"]
            },
            new Formula
            {
                Id = "4_to15", Nome = "Custo Regularizado por Entropia", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Transporte Ótimo",
                Expressao = "OT_ε=⟨c,π⟩+εΣπᵢⱼ(log πᵢⱼ-1)",
                ExprTexto = "OTeps=<c,pi>+eps*H(pi)",
                Icone = "eps",
                Descricao = "Objetivo usado em Sinkhorn com termo entrópico para suavização e estabilidade numérica.",
                ExemploPratico = "Exemplo: cπ=1.2, ε=0.1, H=-2 => custo=1.0.",
                Variaveis = [ new() { Simbolo = "cπ", Nome = "Produto interno <c,π>", ValorPadrao = 1.2 }, new() { Simbolo = "ε", Nome = "Regularização ε", ValorPadrao = 0.1, ValorMin = 0 }, new() { Simbolo = "H", Nome = "Termo entrópico", ValorPadrao = -2.0 } ],
                VariavelResultado = "OT_ε",
                UnidadeResultado = "",
                Calcular = vars => vars["cπ"] + vars["ε"] * vars["H"]
            },
            // 12.2 Wavelets
            new Formula
            {
                Id = "4_wv01", Nome = "Transformada Wavelet Contínua (CWT)", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Wavelets",
                Expressao = "Wf(a,b) = (1/√a)∫f(t)ψ*((t-b)/a)dt",
                ExprTexto = "Wf(a,b) = (1/√a)∫f·ψ*((t−b)/a)dt",
                Icone = "CWT",
                Descricao = "Análise tempo-frequência: ψ dilatada por a, transladada por b. Resolução adaptativa: alta freq → boa resolução temporal; baixa freq → boa resolução frequencial.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "4_wv02", Nome = "Transformada Wavelet Discreta (DWT)", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Wavelets",
                Expressao = "d_{j,k} = ⟨f, ψ_{j,k}⟩;  ψ_{j,k}=2^{j/2}ψ(2ʲt-k)",
                ExprTexto = "d_{j,k}=⟨f,ψ_{j,k}⟩; ψ_{j,k}=2^{j/2}ψ(2ʲt−k)",
                Icone = "DWT",
                Descricao = "Amostragem diádica (a=2⁻ʲ, b=k·2⁻ʲ). Coeficientes wavelet capturam detalhes em cada escala. Algoritmo piramidal O(n): decompõe em aproximação + detalhe.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "d_", Nome = "d_", ValorPadrao = 1 }, new() { Simbolo = "j", Nome = "j", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["d_"] + vars["j"]
            },
            new Formula
            {
                Id = "4_wv03", Nome = "Multirresolução (MRA)", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Wavelets",
                Expressao = "V₀ ⊂ V₁ ⊂ ...; Wⱼ = Vⱼ₊₁ ∩ Vⱼ⊥;  L²=⊕Wⱼ",
                ExprTexto = "Vⱼ⊂Vⱼ₊₁; Wⱼ=Vⱼ₊₁⊖Vⱼ; L²=⊕Wⱼ",
                Icone = "MRA",
                Descricao = "Hierarquia de espaços de aproximação Vⱼ. Complemento ortogonal Wⱼ contém detalhes na escala j. Função de escala φ gera Vⱼ; wavelet ψ gera Wⱼ.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_wv04", Nome = "Wavelet de Haar", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Wavelets",
                Expressao = "ψ(t) = 1 (0≤t<½); -1 (½≤t<1); 0 (resto)",
                ExprTexto = "ψ_Haar: +1 em [0,½), −1 em [½,1)",
                Icone = "Haar",
                Descricao = "Wavelet mais simples: descontinua, 1 momento de anulação. Base ortonormal de L². Primeira wavelet historicamente (1909). Usada como building block conceitual.",
                Criador = "Alfréd Haar",
                AnoOrigin = "1909",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "psi", Nome = "psi", ValorPadrao = 1 }, new() { Simbolo = "em", Nome = "em", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["psi"] + vars["em"]
            },
            new Formula
            {
                Id = "4_wv05", Nome = "Wavelets de Daubechies", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Wavelets",
                Expressao = "Suporte compacto + N momentos de anulação; D2=Haar, D4, D6...",
                ExprTexto = "db-N: suporte compacto, N momentos nulos",
                Icone = "db",
                Descricao = "Família ortonormal de suporte compacto com máxima regularidade para dado suporte. db-1=Haar. db-N: suporte 2N-1, N nulo momentos. Padrão para análise de sinais.",
                Criador = "Ingrid Daubechies",
                AnoOrigin = "1988",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "db", Nome = "db", ValorPadrao = 1 }, new() { Simbolo = "N", Nome = "N", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["db"] + vars["N"]
            },
            new Formula
            {
                Id = "4_wv06", Nome = "Compressão Wavelet", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Wavelets",
                Expressao = "f ≈ Σ_{|d_{j,k}|>τ} d_{j,k}·ψ_{j,k}  (threshold τ)",
                ExprTexto = "f ≈ Σ_{|d|>τ} d·ψ (thresholding)",
                Icone = "τ",
                Descricao = "Coeficientes pequenos descartados: representação esparsa. JPEG2000 usa wavelets (melhor que DCT para bordas). Denoising: soft/hard thresholding nos d_{j,k}.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "f", Nome = "f", ValorPadrao = 1 }, new() { Simbolo = "_", Nome = "_", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["f"] + vars["_"]
            },
            new Formula
            {
                Id = "4_wv07", Nome = "Scattering Transform", Categoria = "Transporte Ótimo e TDA", SubCategoria = "Wavelets",
                Expressao = "S[p]f = |f * ψ_{λ₁}| * ψ_{λ₂}| * ... * φ_J",
                ExprTexto = "Sf = ⋯||f*ψ₁|*ψ₂|*⋯*φ_J",
                Icone = "Sc",
                Descricao = "Cascata de wavelets + módulo + averaging: invariante por translação, estável por deformação. Sem parâmetros aprendidos. Inspiração para CNNs profundas.",
                Criador = "Stéphane Mallat",
                AnoOrigin = "2012",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Sf", Nome = "Sf", ValorPadrao = 1 }, new() { Simbolo = "f", Nome = "f", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Sf"] + vars["f"]
            },
            // 12.3 Topological Data Analysis (TDA)
            new Formula
            {
                Id = "4_td01", Nome = "Complexo de Vietoris-Rips", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "VR_ε(X) = {σ: diam(σ)≤ε};  cresce com ε",
                ExprTexto = "VR_ε(X) = {σ⊂X: diam(σ)≤ε}",
                Icone = "VR",
                Descricao = "Simplicial complex a partir de nuvem de pontos: simplexo σ incluído se todos pares de vértices têm distância ≤ε. Variando ε → filtração para homologia persistente.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "VR_", Nome = "VR_", ValorPadrao = 1 }, new() { Simbolo = "epsilon", Nome = "epsilon", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["VR_"] + vars["epsilon"]
            },
            new Formula
            {
                Id = "4_td02", Nome = "Complexo de Čech", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "C_ε(X) = {σ: ∩_{x∈σ}B(x,ε)≠∅}",
                ExprTexto = "C_ε(X) = {σ: bolas de raio ε se intersectam}",
                Icone = "Čech",
                Descricao = "Nerve do recobrimento por bolas: σ incluído se bolas de raio ε centradas nos vértices de σ têm interseção comum. Teorema do Nerve garante tipo de homotopia de ∪B(x,ε).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "C_", Nome = "C_", ValorPadrao = 1 }, new() { Simbolo = "epsilon", Nome = "epsilon", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["C_"] + vars["epsilon"]
            },
            new Formula
            {
                Id = "4_td03", Nome = "Homologia Persistente", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "VR_{ε₁} ↪ VR_{ε₂} ↪ ... → Hₖ(ε₁) → Hₖ(ε₂) → ...",
                ExprTexto = "Hₖ(ε₁)→Hₖ(ε₂)→⋯ (filtração)",
                Icone = "PH",
                Descricao = "Rastreia nascimento e morte de classes de homologia ao longo da filtração. Features persistentes (longa vida) = topologia real; curta vida = ruído. Diagrama de persistência.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "epsilon", Nome = "epsilon", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["epsilon"]
            },
            new Formula
            {
                Id = "4_td04", Nome = "Diagrama de Persistência", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "Dgm = {(bᵢ,dᵢ): nascimento bᵢ, morte dᵢ}",
                ExprTexto = "Dgm = {(bᵢ,dᵢ)} ⊂ {(b,d): d>b}",
                Icone = "Dgm",
                Descricao = "Resumo da homologia persistente: cada ponto (b,d) = feature com nascimento b e morte d. Persistência = d-b. Pontos longe da diagonal = features significativas.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Dgm", Nome = "Dgm", ValorPadrao = 1 }, new() { Simbolo = "b", Nome = "b", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Dgm"] + vars["b"]
            },
            new Formula
            {
                Id = "4_td05", Nome = "Distância de Bottleneck", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "d_B(Dgm₁,Dgm₂) = inf_γ sup_x ‖x-γ(x)‖∞",
                ExprTexto = "d_B = inf_γ supₓ‖x−γ(x)‖∞",
                Icone = "d_B",
                Descricao = "Métrica entre diagramas de persistência: matching ótimo entre pontos (incluindo diagonal). Estabilidade: mudança pequena nos dados → mudança pequena no diagrama.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "d_B", Nome = "d_B", ValorPadrao = 1 }, new() { Simbolo = "gamma", Nome = "gamma", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["d_B"] + vars["gamma"]
            },
            new Formula
            {
                Id = "4_td06", Nome = "Teorema de Estabilidade (TDA)", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "d_B(Dgm(f), Dgm(g)) ≤ ‖f-g‖∞",
                ExprTexto = "d_B(Dgm f, Dgm g) ≤ ‖f−g‖∞",
                Icone = "estab",
                Descricao = "Resultado fundamental: mudança L∞ nos dados limita mudança na persistência. Garante robustez da homologia persistente a perturbações/ruído.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "d_B", Nome = "d_B", ValorPadrao = 1 }, new() { Simbolo = "Dgm", Nome = "Dgm", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["d_B"] + vars["Dgm"]
            },
            new Formula
            {
                Id = "4_td07", Nome = "Paisagem de Persistência", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "λₖ(t) = kth-largest tent function sobre (bᵢ,dᵢ)",
                ExprTexto = "λₖ(t): k-ésima maior tent function",
                Icone = "λ",
                Descricao = "Representação funcional do diagrama de persistência: funções reais que vivem em espaço de Banach. Permitir média, variância, testes estatísticos.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "lambda_", Nome = "lambda_", ValorPadrao = 1 }, new() { Simbolo = "t", Nome = "t", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["lambda_"] + vars["t"]
            },
            new Formula
            {
                Id = "4_td08", Nome = "Algoritmo Mapper", Categoria = "Transporte Ótimo e TDA", SubCategoria = "TDA",
                Expressao = "f: X→ℝ; cobertura de f(X); nerve do pull-back",
                ExprTexto = "Mapper: filter→cover→cluster→nerve",
                Icone = "Map",
                Descricao = "Compressão topológica de dados: função filtro f, cobertura do espaço filtro, clustering em cada elemento, nerve do resultado. Produz grafo/simplicial complex resumindo a forma dos dados.",
                Criador = "Gurjeet Singh / Facundo Mémoli / Gunnar Carlsson",
                AnoOrigin = "2007",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "", Calcular = vars => vars["x"] + vars["n"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 13. INFERÊNCIA CAUSAL E ECONOMETRIA AVANÇADA
    // ─────────────────────────────────────────────────────
    private void AdicionarInferenciaCausal()
    {
        _formulas.AddRange([
            // 13.1 Inferência Causal
            new Formula
            {
                Id = "4_ic01", Nome = "Operador do (Pearl)", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "P(Y|do(X=x)) ≠ P(Y|X=x) em geral",
                ExprTexto = "P(Y|do(X=x)) ≠ P(Y|X=x)",
                Icone = "do",
                Descricao = "Intervenção ≠ observação. do(X=x) = fixar X em x (cortar setas entrantes no DAG). P(Y|do(X)) responde 'e se mudássemos X?', não 'e se observássemos X?'.",
                Criador = "Judea Pearl",
                AnoOrigin = "1995",
                ExemploPratico = "Exemplo: Pdo=0.62 e Pobs=0.47 => Δdo=0.15.",
                Variaveis = [ new() { Simbolo = "Pdo", Nome = "P(Y|do(X=x))", ValorPadrao = 0.62, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "Pobs", Nome = "P(Y|X=x)", ValorPadrao = 0.47, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Δ_do",
                UnidadeResultado = "",
                Calcular = vars => vars["Pdo"] - vars["Pobs"]
            },
            new Formula
            {
                Id = "4_ic02", Nome = "Fórmula de Ajuste (Backdoor)", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "P(Y|do(X)) = Σ_z P(Y|X,Z=z)P(Z=z)",
                ExprTexto = "P(Y|do(X)) = Σz P(Y|X,z)P(z)",
                Icone = "BD",
                Descricao = "Critério de backdoor: se Z bloqueia todos caminhos confundidores (backdoor) de X a Y, controlar por Z identifica efeito causal. Resultado fundamental da epidemiologia e econometria.",
                ExemploPratico = "Exemplo: P(Y|X,Z)=0.65 e P(Z)=0.4 => P(Y|do(X))=0.26.",
                Variaveis = [ new() { Simbolo = "PYXZ", Nome = "P(Y|X,Z)", ValorPadrao = 0.65, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "PZ", Nome = "P(Z)", ValorPadrao = 0.4, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "P(Y|do(X))",
                UnidadeResultado = "",
                Calcular = vars => vars["PYXZ"] * vars["PZ"]
            },
            new Formula
            {
                Id = "4_ic03", Nome = "Efeito Causal Médio (ATE)", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "ATE = E[Y(1)-Y(0)] = E[Y|do(X=1)]-E[Y|do(X=0)]",
                ExprTexto = "ATE = 𝔼[Y(1)−Y(0)]",
                Icone = "ATE",
                Descricao = "Diferença média entre resultado com tratamento Y(1) e sem Y(0). Problema fundamental: nunca observamos ambos para o mesmo indivíduo (contrafactual). Solução: randomização ou ajuste.",
                ExemploPratico = "Exemplo: Y1=0.78 e Y0=0.61 => ATE=0.17.",
                Variaveis = [ new() { Simbolo = "Y1", Nome = "Resultado potencial Y(1)", ValorPadrao = 0.78 }, new() { Simbolo = "Y0", Nome = "Resultado potencial Y(0)", ValorPadrao = 0.61 } ],
                VariavelResultado = "ATE",
                UnidadeResultado = "",
                Calcular = vars => vars["Y1"] - vars["Y0"]
            },
            new Formula
            {
                Id = "4_ic04", Nome = "Efeito Local (LATE/CATE)", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "LATE = E[Y(1)-Y(0)|tipo=complier]",
                ExprTexto = "LATE = 𝔼[Y(1)−Y(0)|compliers]",
                Icone = "LATE",
                Descricao = "Efeito médio local para subpopulação que responde ao instrumento (compliers). Estimado via Wald ratio: (E[Y|Z=1]-E[Y|Z=0])/(E[X|Z=1]-E[X|Z=0]).",
                ExemploPratico = "Exemplo: EYz1-EYz0=0.12 e EXz1-EXz0=0.6 => LATE=0.2.",
                Variaveis = [ new() { Simbolo = "EYz1", Nome = "E[Y|Z=1]", ValorPadrao = 0.62 }, new() { Simbolo = "EYz0", Nome = "E[Y|Z=0]", ValorPadrao = 0.50 }, new() { Simbolo = "EXz1", Nome = "E[X|Z=1]", ValorPadrao = 0.80 }, new() { Simbolo = "EXz0", Nome = "E[X|Z=0]", ValorPadrao = 0.20 } ],
                VariavelResultado = "LATE",
                UnidadeResultado = "",
                Calcular = vars =>
                {
                    var den = vars["EXz1"] - vars["EXz0"];
                    return Math.Abs(den) < 1e-12 ? 0.0 : (vars["EYz1"] - vars["EYz0"]) / den;
                }
            },
            new Formula
            {
                Id = "4_ic05", Nome = "Fórmula do Frontdoor", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "P(Y|do(X))=Σ_m P(M=m|X)Σ_x' P(Y|X=x',M=m)P(X=x')",
                ExprTexto = "P(Y|do(X))=Σm P(m|X)Σx'P(Y|x',m)P(x')",
                Icone = "FD",
                Descricao = "Quando backdoor não é satisfeito mas mediador M é observado: identifica efeito causal via frontdoor criterion. X→M→Y com confundidor X←U→Y.",
                ExemploPratico = "Exemplo: P(M|X)=0.7, P(Y|X',M)=0.5, P(X')=0.6 => frontdoor=0.21.",
                Variaveis = [ new() { Simbolo = "PMX", Nome = "P(M|X)", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "PYXM", Nome = "P(Y|X',M)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "PXp", Nome = "P(X')", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "P(Y|do(X))",
                UnidadeResultado = "",
                Calcular = vars => vars["PMX"] * vars["PYXM"] * vars["PXp"]
            },
            new Formula
            {
                Id = "4_ic06", Nome = "do-Calculus (3 Regras)", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "Regras 1,2,3 de Pearl: inserção/remoção de observação, intervenção, contrafactual",
                ExprTexto = "3 regras do do-calculus (completo para ID)",
                Icone = "R123",
                Descricao = "Sistema axiomático completo: três regras que permitem simplificar P(Y|do(X),Z) usando d-separação no DAG mutilado. Completo: se efeito é identificável, do-calculus o encontra.",
                ExemploPratico = "Exemplo: regras aplicáveis r1=1,r2=0,r3=1 => score=2.",
                Variaveis = [ new() { Simbolo = "r1", Nome = "Regra 1 aplicavel (0/1)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "r2", Nome = "Regra 2 aplicavel (0/1)", ValorPadrao = 0, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "r3", Nome = "Regra 3 aplicavel (0/1)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Score_do",
                UnidadeResultado = "",
                Calcular = vars => vars["r1"] + vars["r2"] + vars["r3"]
            },
            new Formula
            {
                Id = "4_ic07", Nome = "SCM (Structural Causal Model)", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "Xᵢ = fᵢ(PAᵢ, Uᵢ); DAG G + funções f + ruído U",
                ExprTexto = "Xᵢ=fᵢ(PAᵢ,Uᵢ); DAG G, funções f, ruído U",
                Icone = "SCM",
                Descricao = "Modelo causal estrutural: cada variável é função de seus pais (PAᵢ) e ruído exógeno Uᵢ. DAG codifica estrutura causal. Permite intervenções e contrafactuais.",
                ExemploPratico = "Exemplo: PA=0.7, U=0.2 e b=0.9 => X=0.83.",
                Variaveis = [ new() { Simbolo = "PA", Nome = "Componente dos pais PA", ValorPadrao = 0.7 }, new() { Simbolo = "U", Nome = "Ruido exogeno U", ValorPadrao = 0.2 }, new() { Simbolo = "b", Nome = "Peso b", ValorPadrao = 0.9 } ],
                VariavelResultado = "X_i",
                UnidadeResultado = "",
                Calcular = vars => vars["b"] * vars["PA"] + vars["U"]
            },
            new Formula
            {
                Id = "4_ic08", Nome = "Propensity Score", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "e(X) = P(T=1|X); ATE via IPW: E[YT/e-(Y(1-T))/(1-e)]",
                ExprTexto = "e(X)=P(T=1|X); IPW: Σ YT/e−Y(1−T)/(1−e)",
                Icone = "PS",
                Descricao = "Probabilidade de tratamento dado covariáveis. Inverse Probability Weighting: repondera observações para simular randomização. Rosenbaum-Rubin (1983).",
                Criador = "Paul Rosenbaum / Donald Rubin",
                AnoOrigin = "1983",
                ExemploPratico = "Exemplo: Y=1.2, T=1, e=0.7 => escore IPW≈1.7143.",
                Variaveis = [ new() { Simbolo = "Y", Nome = "Resultado Y", ValorPadrao = 1.2 }, new() { Simbolo = "T", Nome = "Tratamento T (0/1)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "e", Nome = "Propensity e(X)", ValorPadrao = 0.7, ValorMin = 0.01, ValorMax = 0.99 } ],
                VariavelResultado = "IPW",
                UnidadeResultado = "",
                Calcular = vars =>
                {
                    var e = vars["e"];
                    return vars["Y"] * (vars["T"] / e - (1.0 - vars["T"]) / (1.0 - e));
                }
            },
            new Formula
            {
                Id = "4_ic09", Nome = "Double Machine Learning", Categoria = "Inferência Causal", SubCategoria = "Causalidade",
                Expressao = "θ̂ = (1/n)Σ ψ(Wᵢ; θ, η̂₋ᵢ) = 0  (cross-fitted)",
                ExprTexto = "θ̂: Neyman-orthogonal, cross-fitted ML",
                Icone = "DML",
                Descricao = "Usa ML para estimar nuisance parameters η (propensity, outcome model), mas com ortogonalidade de Neyman e cross-fitting para evitar regularization bias. √n-consistente.",
                Criador = "Victor Chernozhukov et al.",
                AnoOrigin = "2018",
                ExemploPratico = "Exemplo: Y=1.4, m=1.1, T=0.8, e=0.3 => θ≈0.6.",
                Variaveis = [ new() { Simbolo = "Y", Nome = "Outcome Y", ValorPadrao = 1.4 }, new() { Simbolo = "m", Nome = "Modelo de outcome m(X)", ValorPadrao = 1.1 }, new() { Simbolo = "T", Nome = "Tratamento T", ValorPadrao = 0.8 }, new() { Simbolo = "e", Nome = "Propensity e(X)", ValorPadrao = 0.3 } ],
                VariavelResultado = "θ_DML",
                UnidadeResultado = "",
                Calcular = vars =>
                {
                    var den = vars["T"] - vars["e"];
                    return Math.Abs(den) < 1e-12 ? 0.0 : (vars["Y"] - vars["m"]) / den;
                }
            },
            // 13.2 Econometria Avançada
            new Formula
            {
                Id = "4_ec01", Nome = "Variáveis Instrumentais (IV)", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "β̂_IV = (Z'X)⁻¹Z'Y;  Cov(Z,ε)=0, Cov(Z,X)≠0",
                ExprTexto = "β̂_IV=(Z'X)⁻¹Z'Y; Z⊥ε, Z↛X≠0",
                Icone = "IV",
                Descricao = "Z instrumento: correlacionado com X (relevância), não com ε (exclusão). IV recupera efeito causal mesmo com endogeneidade. 2SLS: primeiro estágio X̂=Z'π̂, segundo Y=X̂β.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "4_ec02", Nome = "GMM (Método Generalizado de Momentos)", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "θ̂_GMM = argmin_θ [g(θ)]'W[g(θ)];  g=condições de momento",
                ExprTexto = "θ̂=argminθ g(θ)'Wg(θ)",
                Icone = "GMM",
                Descricao = "Framework unificador: E[m(X,θ₀)]=0 são condições de momento. OLS, IV, MLE são casos especiais. W ótimo = inversa da variância assintótica.",
                Criador = "Lars Peter Hansen",
                AnoOrigin = "1982",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "4_ec03", Nome = "Efeitos Fixos (Painel)", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "Yᵢₜ = αᵢ + X'ᵢₜβ + εᵢₜ;  within-estimator",
                ExprTexto = "Yᵢₜ=αᵢ+Xᵢₜ'β+εᵢₜ (FE: within)",
                Icone = "FE",
                Descricao = "Controla heterogeneidade não-observada constante no tempo (αᵢ) via demean ou first-differences. Elimina viés de variável omitida time-invariant.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "αᵢ", Nome = "αᵢ", ValorPadrao = 10 }, new() { Simbolo = "Xᵢₜ", Nome = "Xᵢₜ", ValorPadrao = 5 } ],
                VariavelResultado = "Yᵢₜ",
                UnidadeResultado = "",
                Calcular = vars => vars["αᵢ"] + vars["Xᵢₜ"]
            },
            new Formula
            {
                Id = "4_ec04", Nome = "Efeitos Aleatórios (Painel)", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "Yᵢₜ = α + X'ᵢₜβ + uᵢ + εᵢₜ;  uᵢ~(0,σ²_u)",
                ExprTexto = "Yᵢₜ=α+Xᵢₜ'β+uᵢ+εᵢₜ (RE: GLS)",
                Icone = "RE",
                Descricao = "αᵢ = α+uᵢ com uᵢ aleatório e independente de X. Mais eficiente que FE se hipótese é correta. Estimador GLS. Testável via Hausman.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "α", Nome = "α", ValorPadrao = 10 }, new() { Simbolo = "Xᵢₜ", Nome = "Xᵢₜ", ValorPadrao = 5 } ],
                VariavelResultado = "Yᵢₜ",
                UnidadeResultado = "",
                Calcular = vars => vars["α"] + vars["Xᵢₜ"]
            },
            new Formula
            {
                Id = "4_ec05", Nome = "Teste de Hausman", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "H = (β̂_FE-β̂_RE)'[V_FE-V_RE]⁻¹(β̂_FE-β̂_RE) ~ χ²",
                ExprTexto = "H=(β̂FE−β̂RE)'(VFE−VRE)⁻¹(β̂FE−β̂RE)→χ²",
                Icone = "Haus",
                Descricao = "Testa FE vs RE: H₀: uᵢ independente de Xᵢₜ (RE consistente e eficiente). Se rejeitado → FE preferido. Baseado na diferença dos estimadores.",
                Criador = "Jerry Hausman",
                AnoOrigin = "1978",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "4_ec06", Nome = "Diferença-em-Diferenças (DiD)", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "δ̂ = (Ȳ_{T,post}-Ȳ_{T,pre}) - (Ȳ_{C,post}-Ȳ_{C,pre})",
                ExprTexto = "δ̂ = (ȲT,post−ȲT,pre)−(ȲC,post−ȲC,pre)",
                Icone = "DiD",
                Descricao = "Quasi-experimental: compara mudança pré-pós entre tratados e controles. Hipótese: tendências paralelas (na ausência de tratamento). Muito usado em avaliação de políticas.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "4_ec07", Nome = "Regressão Descontínua (RDD)", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "τ = lim_{x↓c}E[Y|X=x] - lim_{x↑c}E[Y|X=x]",
                ExprTexto = "τ = lim_{x↓c}E[Y|x]−lim_{x↑c}E[Y|x]",
                Icone = "RDD",
                Descricao = "Efeito causal no cutoff c: tratamento atribuído por X>c. Descontinuidade em E[Y|X] em c identifica efeito local. Sharp (determinístico) ou fuzzy (probabilístico). Design quasi-experimental forte.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (amostra)", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "p", Nome = "p (probabilidade)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["p"]
            },
            new Formula
            {
                Id = "4_ec08", Nome = "Controle Sintético", Categoria = "Inferência Causal", SubCategoria = "Econometria",
                Expressao = "Ŷ₁ₜ = Σⱼwⱼ*Yⱼₜ;  w* minimiza ‖X₁-X₀w‖",
                ExprTexto = "Ŷ₁ₜ = Σwⱼ*Yⱼₜ (controle sintético)",
                Icone = "SC",
                Descricao = "Constrói contrafactual como combinação convexa de unidades de controle que minimiza diferença pré-tratamento. Para case studies comparativos (1 unidade tratada).",
                Criador = "Alberto Abadie et al.",
                AnoOrigin = "2003",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Σwⱼ", Nome = "Σwⱼ", ValorPadrao = 5 }, new() { Simbolo = "Yⱼₜ", Nome = "Yⱼₜ", ValorPadrao = 3 } ],
                VariavelResultado = "Ŷ₁ₜ",
                UnidadeResultado = "",
                Calcular = vars => vars["Σwⱼ"] * vars["Yⱼₜ"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 14. ALTA DIMENSIONALIDADE, LASSO E MATRIZES ALEATÓRIAS
    // ─────────────────────────────────────────────────────
    private void AdicionarAltaDimensionalidade()
    {
        _formulas.AddRange([
            // 14.1 Regularização e Esparsidade
            new Formula
            {
                Id = "4_hd01", Nome = "Ridge Regression", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "β̂_ridge = argmin ‖Y-Xβ‖² + λ‖β‖²₂",
                ExprTexto = "β̂_ridge = (X'X+λI)⁻¹X'Y",
                Icone = "L₂",
                Descricao = "Penalidade L₂: encolhe coeficientes mas não zera. Solução fechada: (X'X+λI)⁻¹X'Y. Equivalente MAP com prior normal. Resolve multicolinearidade.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "beta", Nome = "beta", ValorPadrao = 1 }, new() { Simbolo = "X", Nome = "X", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["beta"] + vars["X"]
            },
            new Formula
            {
                Id = "4_hd02", Nome = "LASSO", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "β̂_lasso = argmin ‖Y-Xβ‖² + λ‖β‖₁",
                ExprTexto = "β̂_lasso = argmin‖Y−Xβ‖²+λ‖β‖₁",
                Icone = "L₁",
                Descricao = "Least Absolute Shrinkage and Selection Operator: penalidade L₁ produz esparsidade (|βⱼ|=0). Seleção de variáveis automática. Não tem forma fechada; resolvido por LARS, coordinate descent.",
                Criador = "Robert Tibshirani",
                AnoOrigin = "1996",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "beta", Nome = "beta", ValorPadrao = 1 }, new() { Simbolo = "Y", Nome = "Y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["beta"] + vars["Y"]
            },
            new Formula
            {
                Id = "4_hd03", Nome = "Elastic Net", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "argmin ‖Y-Xβ‖² + λ₁‖β‖₁ + λ₂‖β‖²₂",
                ExprTexto = "min‖Y−Xβ‖²+λ₁‖β‖₁+λ₂‖β‖²₂",
                Icone = "EN",
                Descricao = "Combina L₁ (esparsidade) e L₂ (grouping effect). Melhor que LASSO quando covariáveis correlacionadas: seleciona grupos ao invés de indivíduos arbitrários.",
                Criador = "Hui Zou / Trevor Hastie",
                AnoOrigin = "2005",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Y", Nome = "Y", ValorPadrao = 1 }, new() { Simbolo = "X", Nome = "X", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["Y"] + vars["X"]
            },
            new Formula
            {
                Id = "4_hd04", Nome = "Oracle Inequality (LASSO)", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "‖β̂-β*‖² ≤ C·s·log(p)/n  (com prob. alta)",
                ExprTexto = "‖β̂−β*‖² ≤ C·s·log(p)/n w.h.p.",
                Icone = "oracle",
                Descricao = "LASSO atinge taxa ótima s·log(p)/n (s=esparsidade, p=dimensão, n=amostras) sob condição de compatibilidade/RE. Adapta-se à esparsidade desconhecida.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "4_hd05", Nome = "Compressed Sensing (RIP)", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "(1-δ)‖x‖² ≤ ‖Φx‖² ≤ (1+δ)‖x‖²  (∀x s-esparso)",
                ExprTexto = "RIP: (1−δ)‖x‖²≤‖Φx‖²≤(1+δ)‖x‖² ∀x s-sparse",
                Icone = "RIP",
                Descricao = "Restricted Isometry Property: medições aleatórias Φ preservam norma de sinais esparsos. m=O(s log(p/s)) medições bastam. Matrizes gaussianas, sub-gaussianas satisfazem RIP.",
                Criador = "Emmanuel Candès / Terence Tao / David Donoho",
                AnoOrigin = "2006",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "RIP", Nome = "RIP", ValorPadrao = 1 }, new() { Simbolo = "delta", Nome = "delta", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["RIP"] + vars["delta"]
            },
            new Formula
            {
                Id = "4_hd06", Nome = "Dantzig Selector", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "min ‖β‖₁  s.t.  ‖X'(Y-Xβ)‖∞ ≤ λ",
                ExprTexto = "min ‖β‖₁ s.t. ‖X'(Y−Xβ)‖∞≤λ",
                Icone = "DS",
                Descricao = "Alternativa ao LASSO: minimiza L₁ sujeito a correlação residual limitada. Programa linear. Mesma taxa ótima s·log(p)/n sob RIP.",
                Criador = "Emmanuel Candès / Terence Tao",
                AnoOrigin = "2007",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "beta", Nome = "beta", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["beta"] + vars["s"]
            },
            new Formula
            {
                Id = "4_hd07", Nome = "Group LASSO", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "min ‖Y-Xβ‖² + λΣ_g √|g| ‖β_g‖₂",
                ExprTexto = "min‖Y−Xβ‖²+λΣ√|g|·‖βg‖₂",
                Icone = "GL",
                Descricao = "Penaliza grupos de covariáveis conjuntamente: zera grupo inteiro ou mantém. Útil quando variáveis têm estrutura natural (dummies categóricas, wavelets em uma escala).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "4_hd08", Nome = "Taxa Minimax Esparsa", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "erro ~ (s·log p)/n",
                ExprTexto = "rate = s log(p)/n",
                Icone = "rate",
                Descricao = "Escala de erro típica em regressão esparsa para p grande.",
                ExemploPratico = "Exemplo: s=10, p=1000, n=500 => ~0.138.",
                Variaveis = [ new() { Simbolo = "s", Nome = "Esparsidade s", ValorPadrao = 10, ValorMin = 1 }, new() { Simbolo = "p", Nome = "Dimensão p", ValorPadrao = 1000, ValorMin = 2 }, new() { Simbolo = "n", Nome = "Amostras n", ValorPadrao = 500, ValorMin = 1 } ],
                VariavelResultado = "(s log p)/n",
                UnidadeResultado = "",
                Calcular = vars => vars["s"] * Math.Log(vars["p"]) / vars["n"]
            },
            new Formula
            {
                Id = "4_hd09", Nome = "Correção de Múltiplos Testes (BH)", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "p_(i) ≤ (i/m)·q",
                ExprTexto = "BH threshold = i*q/m",
                Icone = "BH",
                Descricao = "Limiar de Benjamini-Hochberg para controlar FDR em cenários de alta dimensão.",
                ExemploPratico = "Exemplo: i=20, m=1000, q=0.1 => 0.002.",
                Variaveis = [ new() { Simbolo = "i", Nome = "Índice i", ValorPadrao = 20, ValorMin = 1 }, new() { Simbolo = "m", Nome = "Número de testes m", ValorPadrao = 1000, ValorMin = 1 }, new() { Simbolo = "q", Nome = "FDR alvo q", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "(i/m)q",
                UnidadeResultado = "",
                Calcular = vars => (vars["i"] / vars["m"]) * vars["q"]
            },
            new Formula
            {
                Id = "4_hd10", Nome = "Debiased LASSO", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "β~ = β^lasso + M X'(y-Xβ^lasso)/n",
                ExprTexto = "beta_tilde = beta_lasso + correction",
                Icone = "deb",
                Descricao = "Correção assintoticamente normal para inferência em coeficientes de modelos esparsos.",
                ExemploPratico = "Exemplo: β_lasso=0.7 e correção=0.05 => 0.75.",
                Variaveis = [ new() { Simbolo = "βl", Nome = "Estimativa LASSO", ValorPadrao = 0.7 }, new() { Simbolo = "corr", Nome = "Termo de correção", ValorPadrao = 0.05 } ],
                VariavelResultado = "β~",
                UnidadeResultado = "",
                Calcular = vars => vars["βl"] + vars["corr"]
            },
            new Formula
            {
                Id = "4_hd11", Nome = "Sinal-Ruído Efetivo", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "SNR = ‖Xβ‖²/(nσ²)",
                ExprTexto = "snr = signal/(n*sigma2)",
                Icone = "snr",
                Descricao = "Métrica de detectabilidade para modelos lineares em alta dimensão.",
                ExemploPratico = "Exemplo: sinal=120, n=400, σ²=0.5 => 0.6.",
                Variaveis = [ new() { Simbolo = "sig", Nome = "Energia de sinal", ValorPadrao = 120, ValorMin = 0 }, new() { Simbolo = "n", Nome = "Amostras n", ValorPadrao = 400, ValorMin = 1 }, new() { Simbolo = "σ²", Nome = "Variância do ruído", ValorPadrao = 0.5, ValorMin = 0.0001 } ],
                VariavelResultado = "SNR",
                UnidadeResultado = "",
                Calcular = vars => vars["sig"] / (vars["n"] * vars["σ²"])
            },
            new Formula
            {
                Id = "4_hd12", Nome = "Desvio de Generalização", Categoria = "Alta Dimensionalidade", SubCategoria = "Regularização",
                Expressao = "gap = R_test - R_train",
                ExprTexto = "gap = test - train",
                Icone = "gap",
                Descricao = "Mede overfitting em regimes p>>n.",
                ExemploPratico = "Exemplo: risco treino=0.12 e teste=0.20 => gap=0.08.",
                Variaveis = [ new() { Simbolo = "Rtr", Nome = "Risco treino", ValorPadrao = 0.12, ValorMin = 0 }, new() { Simbolo = "Rte", Nome = "Risco teste", ValorPadrao = 0.20, ValorMin = 0 } ],
                VariavelResultado = "gap",
                UnidadeResultado = "",
                Calcular = vars => vars["Rte"] - vars["Rtr"]
            },
            // 14.2 Teoria de Matrizes Aleatórias
            new Formula
            {
                Id = "4_rm01", Nome = "Ensemble GOE", Categoria = "Alta Dimensionalidade", SubCategoria = "Matrizes Aleatórias",
                Expressao = "GOE: H = (A+A')/2; Aᵢⱼ~N(0,1);  β=1",
                ExprTexto = "GOE: H=(A+Aᵀ)/2; Aᵢⱼ~N(0,1); β=1",
                Icone = "GOE",
                Descricao = "Gaussian Orthogonal Ensemble: matrizes simétricas reais com entradas gaussianas. β=1 (Dyson index). Modelar sistemas quânticos com simetria de reversão temporal.",
                Criador = "Eugene Wigner",
                AnoOrigin = "1955",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "GOE", Nome = "GOE", ValorPadrao = 1 }, new() { Simbolo = "H", Nome = "H", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["GOE"] + vars["H"]
            },
            new Formula
            {
                Id = "4_rm02", Nome = "Ensemble GUE", Categoria = "Alta Dimensionalidade", SubCategoria = "Matrizes Aleatórias",
                Expressao = "GUE: H = (A+A*)/2; Aᵢⱼ~N_ℂ(0,1);  β=2",
                ExprTexto = "GUE: H=(A+A†)/2; Aᵢⱼ~Nℂ; β=2",
                Icone = "GUE",
                Descricao = "Gaussian Unitary Ensemble: matrizes hermitianas complexas. Repulsão de autovalores mais forte que GOE. Espaçamento de nível segue distribuição de sine kernel.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "GUE", Nome = "GUE", ValorPadrao = 1 }, new() { Simbolo = "H", Nome = "H", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["GUE"] + vars["H"]
            },
            new Formula
            {
                Id = "4_rm03", Nome = "Lei do Semicírculo de Wigner", Categoria = "Alta Dimensionalidade", SubCategoria = "Matrizes Aleatórias",
                Expressao = "ρ(x) = (2πσ²)⁻¹ √(4σ²-x²)  |x|≤2σ",
                ExprTexto = "ρ(x) = √(4σ²−x²)/2πσ²; |x|≤2σ",
                Icone = "⌒",
                Descricao = "Lei limite dos autovalores de Wigner: distribuição empírica → semicírculo. Universalidade: vale para qualquer distribuição de entradas com momentos finitos. σ² = variância das entradas.",
                Criador = "Eugene Wigner",
                AnoOrigin = "1955",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "4_rm04", Nome = "Lei de Marchenko-Pastur", Categoria = "Alta Dimensionalidade", SubCategoria = "Matrizes Aleatórias",
                Expressao = "ρ(x) = √((λ₊-x)(x-λ₋))/(2πγx);  γ=p/n",
                ExprTexto = "ρ(x)=√(λ₊−x)(x−λ₋)/2πγx; γ=p/n",
                Icone = "MP",
                Descricao = "Distribuição limite dos autovalores de S=X'X/n (covariância amostral) quando p/n→γ. λ±=(1±√γ)². Se γ>1: massa em 0. Fundamental para PCA em alta dimensão.",
                Criador = "Vladimir Marchenko / Leonid Pastur",
                AnoOrigin = "1967",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 10 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "γ",
                UnidadeResultado = "",
                Calcular = vars => vars["p"] / vars["n"]
            },
            new Formula
            {
                Id = "4_rm05", Nome = "Distribuição de Tracy-Widom", Categoria = "Alta Dimensionalidade", SubCategoria = "Matrizes Aleatórias",
                Expressao = "P(λ_max ≤ 2√n + n⁻¹/⁶ s) → F_β(s) (Tracy-Widom)",
                ExprTexto = "P(λmax ≤ 2√n+n⁻¹ᐟ⁶s) → F_β(s)",
                Icone = "TW",
                Descricao = "Distribuição do maior autovalor (centrado e reescalado). Universalidade surpreendente: aparece em longest increasing subsequence, KPZ, processos de crescimento.",
                Criador = "Craig Tracy / Harold Widom",
                AnoOrigin = "1994",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "4_rm06", Nome = "Spike Model (BBP Transition)", Categoria = "Alta Dimensionalidade", SubCategoria = "Matrizes Aleatórias",
                Expressao = "Se λ_signal > 1+√γ → 'spike' emerge de MP;  senão, invisível",
                ExprTexto = "λ>1+√γ: spike detectável; senão: perdido no ruído",
                Icone = "BBP",
                Descricao = "Transição de fase de Baik-Ben Arous-Péché: sinal em covariância só é detectável se SNR excede limiar √γ. PCA falha abaixo do limiar. Fundamental para estatística de alta dimensão.",
                Criador = "Baik / Ben Arous / Péché",
                AnoOrigin = "2005",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
        ]);
    }
}
