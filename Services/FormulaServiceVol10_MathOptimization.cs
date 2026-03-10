using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE VII
    /// OTIMIZAÇÃO MATEMÁTICA AVANÇADA
    /// Fórmulas V10-122 a V10-141 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_MathOptimization()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3710",
                    CodigoCompendio = "V10-122",
                    Nome = "Condições KKT (Karush-Kuhn-Tucker)",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Programação Não-Linear",
                    Expressao = @"∇f(x*) + Σλᵢ·∇gᵢ(x*) = 0; λᵢ·gᵢ(x*)=0",
                    Descricao = "Condições necessárias para ótimo com restrições de desigualdade. λᵢ≥0: multiplicadores. Complementaridade: λᵢ·gᵢ=0.",
                    ExemploPratico = "SVM: maximizar margem com KKT. Portfolio optimization com restrições.",
                    Criador = "Karush (1939); Kuhn e Tucker (1951)",
                    AnoOrigin = "1939",
                    VariavelResultado = "gap",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Gap de dualidade", Simbolo = "gap", Unidade = "", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gap = inputs["Gap de dualidade"];
                        return gap;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-123: Gradiente Descendente
                new Formula
                {
                    Id = "3711",
                    CodigoCompendio = "V10-123",
                    Nome = "Gradiente Descendente",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Numérica",
                    Expressao = @"x_{k+1} = x_k − α·∇f(x_k)",
                    Descricao = "Iteração: move na direção oposta ao gradiente. α: taxa aprendizado (learning rate). Convergência: α pequeno→lento, α grande→diverge. Convexo: convergência garantida.",
                    ExemploPratico = "Deep learning: SGD com α≈0.01-0.1. Momentum: acelera (~β≈0.9). Adam: α adaptativo. Quadrática f=x²: α=0.1, x₀=10→convergência ~50 iter.",
                    Criador = "Cauchy (1847, método steepest descent); moderno ML (Robbins-Monro 1951)",
                    AnoOrigin = "1847",
                    VariavelResultado = "x_new",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x_atual", Simbolo = "x", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "∇f(x)", Simbolo = "grad", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Learning rate α", Simbolo = "alpha", Unidade = "", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x = inputs["x_atual"];
                        double grad = inputs["∇f(x)"];
                        double alpha = inputs["Learning rate α"];
                        
                        double x_new = x - alpha * grad;
                        return x_new;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-124: Método de Newton-Raphson
                new Formula
                {
                    Id = "3712",
                    CodigoCompendio = "V10-124",
                    Nome = "Método de Newton — Otimização",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Métodos de Segunda Ordem",
                    Expressao = @"x_{k+1} = x_k − H^{-1}(x_k)·∇f(x_k)",
                    Descricao = "H: matriz Hessiana (segundas derivadas). Convergência quadrática (rápida perto do ótimo). Custo: inverter H (O(n³)). Quasi-Newton: aproxima H⁻¹ (BFGS, L-BFGS).",
                    ExemploPratico = "f(x)=x²: H=2, x_{k+1}=0 (1 iteração!). ML: L-BFGS para convex. Deep learning: raro (memória O(n²) Hessiana). Região trust: combina Newton+GD.",
                    Criador = "Newton (1669, roots); aplicado otimização (séc. 20)",
                    AnoOrigin = "1669",
                    VariavelResultado = "x_new",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x_atual", Simbolo = "x", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "∇f(x)", Simbolo = "grad", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "H (Hessiana)", Simbolo = "H", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x = inputs["x_atual"];
                        double grad = inputs["∇f(x)"];
                        double H = inputs["H (Hessiana)"];
                        
                        if (H == 0) return x;
                        double x_new = x - grad / H;
                        return x_new;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-125: Programação Linear — Método Simplex
                new Formula
                {
                    Id = "3713",
                    CodigoCompendio = "V10-125",
                    Nome = "Programação Linear — Método Simplex",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Linear",
                    Expressao = @"max c^T·x; Ax ≤ b; x ≥ 0",
                    Descricao = "Simplex: percorre vértices do poliedro viável. Pior caso: exponencial. Prática: polinomial médio. Interior-point: polinomial garantido (Karmarkar 1984).",
                    ExemploPratico = "Produção: max lucro=3x₁+2x₂ sujeito a x₁+x₂≤100 (trabalho), 2x₁+x₂≤150 (material). Solução: x₁=50, x₂=50, lucro=250.",
                    Criador = "Dantzig (1947, RAND Corporation)",
                    AnoOrigin = "1947",
                    VariavelResultado = "Z_max",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x₁", Simbolo = "x1", Unidade = "", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "x₂", Simbolo = "x2", Unidade = "", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c₁", Simbolo = "c1", Unidade = "", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c₂", Simbolo = "c2", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x1 = inputs["x₁"];
                        double x2 = inputs["x₂"];
                        double c1 = inputs["c₁"];
                        double c2 = inputs["c₂"];
                        
                        double Z = c1 * x1 + c2 * x2;
                        return Z;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-126: Convexidade
                new Formula
                {
                    Id = "3714",
                    CodigoCompendio = "V10-126",
                    Nome = "Teste de Convexidade — Hessiana",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Análise Convexa",
                    Expressao = @"Convexa se H(x) ⪰ 0 ∀x (positiva semidefinida)",
                    Descricao = "f convexa: mínimo local=global. Gradiente=0→ótimo. Combinação convexa funções convexas: convexa. Normas, log-barrier, entropy: convexas.",
                    ExemploPratico = "f(x)=x²: H=2>0 convexa. f(x)=x³: H=6x não-convexa (H<0 se x<0). SVM, regressão logística: problemas convexos (solução única). Neural nets: não-convexos.",
                    Criador = "Rockafellar (1970, Convex Analysis); Boyd-Vandenberghe (2004, livro moderno)",
                    AnoOrigin = "1970",
                    VariavelResultado = "autovalor_min",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "H₁₁ (elemento Hessiana)", Simbolo = "H11", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "H₂₂", Simbolo = "H22", Unidade = "", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "H₁₂", Simbolo = "H12", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double H11 = inputs["H₁₁ (elemento Hessiana)"];
                        double H22 = inputs["H₂₂"];
                        double H12 = inputs["H₁₂"];
                        
                        // Autovalor mínimo matriz 2×2
                        double trace = H11 + H22;
                        double det = H11 * H22 - H12 * H12;
                        double lambda_min = (trace - Math.Sqrt(trace * trace - 4 * det)) / 2;
                        
                        return lambda_min; // >0: convexa
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-127: Otimização Restrita — Lagrangiano
                new Formula
                {
                    Id = "3715",
                    CodigoCompendio = "V10-127",
                    Nome = "Lagrangiano",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Restrita",
                    Expressao = @"L(x,λ) = f(x) + Σλᵢ·hᵢ(x)",
                    Descricao = "Método multiplicadores Lagrange. hᵢ(x)=0: restrições igualdade. Ótimo: ∇_x L=0, ∇_λ L=0. Interpretação: λᵢ = sensitividade f a hᵢ.",
                    ExemploPratico = "Minimizar distância (x,y) a origem com x+y=1: L=x²+y²+λ(x+y−1). Solução: x=y=0.5, λ=−1. Física: princípios variacionais (ação mínima).",
                    Criador = "Lagrange (1788, Mécanique Analytique)",
                    AnoOrigin = "1788",
                    VariavelResultado = "L",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "f(x)", Simbolo = "f", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "λ", Simbolo = "lambda", Unidade = "", ValorPadrao = -1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "h(x)", Simbolo = "h", Unidade = "", ValorPadrao = 0, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double f = inputs["f(x)"];
                        double lambda = inputs["λ"];
                        double h = inputs["h(x)"];
                        
                        double L = f + lambda * h;
                        return L;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-128: Busca em Grade (Grid Search)
                new Formula
                {
                    Id = "3716",
                    CodigoCompendio = "V10-128",
                    Nome = "Complexidade Grid Search",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Hiperparâmetros ML",
                    Expressao = @"N_eval = ∏ᵢ nᵢ (combinatória)",
                    Descricao = "Busca exaustiva combinações. nᵢ: valores por hiperparâmetro. Curse of dimensionality: exponencial. Random search: mais eficiente (Bergstra-Bengio 2012).",
                    ExemploPratico = "SVM: C∈[10⁻³,10³] (7 valores), γ∈[10⁻³,10³] (7 valores)→7×7=49 modelos. 3 params×10 valores=1000 combos. Cross-validation 5-fold: 5000 treinos!",
                    Criador = "Prática ML anos 1990s; Random search (Bergstra 2012)",
                    AnoOrigin = "1990",
                    VariavelResultado = "N_eval",
                    UnidadeResultado = "avaliações",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "n_param1", Simbolo = "n1", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "n_param2", Simbolo = "n2", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "n_param3", Simbolo = "n3", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        int n1 = (int)inputs["n_param1"];
                        int n2 = (int)inputs["n_param2"];
                        int n3 = (int)inputs["n_param3"];
                        
                        int N_eval = n1 * n2 * n3;
                        return N_eval;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-129: Simulated Annealing
                new Formula
                {
                    Id = "3717",
                    CodigoCompendio = "V10-129",
                    Nome = "Simulated Annealing — Probabilidade Aceitação",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Estocástica",
                    Expressao = @"P(aceitar) = exp(−ΔE/T)",
                    Descricao = "Aceita soluções piores com P→0 quando T→0. T: temperatura (annealing schedule). Escapa mínimos locais. Inspirado recozimento metalúrgico.",
                    ExemploPratico = "TSP 50 cidades: mínimo global difícil. T₀=100, T_k=T₀·0.95^k. ΔE=10, T=10: P≈37% aceita pior. T=1: P≈0.004% (quase greedy). Convergência: lento mas robusto.",
                    Criador = "Metropolis (1953, física); Kirkpatrick et al. (1983, otimização)",
                    AnoOrigin = "1983",
                    VariavelResultado = "P_aceita",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ΔE", Simbolo = "dE", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Temperatura T", Simbolo = "T", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double dE = inputs["ΔE"];
                        double T = inputs["Temperatura T"];
                        
                        if (T == 0) return 0;
                        if (dE <= 0) return 1; // sempre aceita melhoras
                        
                        double P = Math.Exp(-dE / T);
                        return P;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-130: Algoritmo Genético — Fitness
                new Formula
                {
                    Id = "3718",
                    CodigoCompendio = "V10-130",
                    Nome = "Algoritmo Genético — Seleção por Fitness",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Computação Evolutiva",
                    Expressao = @"P(seleção_i) = fitness_i/Σfitness_j",
                    Descricao = "Seleção proporcional fitness. Operadores: crossover (recombinação), mutação (exploração). Convergência prematura: perda diversidade. Elitismo: preserva melhores.",
                    ExemploPratico = "População 100 indivíduos, fitness=[5,3,2]. P_seleção=[0.5,0.3,0.2]. Crossover: taxa~0.8. Mutação: taxa~0.01. Gerações: 100-1000. TSP, scheduling, neural net topology.",
                    Criador = "Holland (1975, Adaptation in Natural and Artificial Systems)",
                    AnoOrigin = "1975",
                    VariavelResultado = "P_sel",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "fitness_indivíduo", Simbolo = "f_i", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "fitness_total", Simbolo = "f_total", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double f_i = inputs["fitness_indivíduo"];
                        double f_total = inputs["fitness_total"];
                        
                        if (f_total == 0) return 0;
                        double P = f_i / f_total;
                        return P;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-131: Particle Swarm Optimization (PSO)
                new Formula
                {
                    Id = "3719",
                    CodigoCompendio = "V10-131",
                    Nome = "Particle Swarm Optimization (PSO)",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização por Enxame",
                    Expressao = @"vᵢ = w·vᵢ + c₁·r₁(pᵢ−xᵢ) + c₂·r₂(g−xᵢ)",
                    Descricao = "Partículas exploram espaço busca. pᵢ: melhor pessoal. g: melhor global. w: inércia. c₁, c₂: aceleração cognitiva/social. r₁, r₂: random [0,1].",
                    ExemploPratico = "20 partículas, w=0.7, c₁=c₂=2. Função Rastrigin (multimodal): PSO encontra mínimo ~100 iterações. Simples implementar, bom multimodal. Swarm: 10-50 partículas típico.",
                    Criador = "Kennedy e Eberhart (1995, IC Neural Networks)",
                    AnoOrigin = "1995",
                    VariavelResultado = "v_new",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v_atual", Simbolo = "v", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Inércia w", Simbolo = "w", Unidade = "", ValorPadrao = 0.7, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "x_atual", Simbolo = "x", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "p_best", Simbolo = "p", Unidade = "", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "g_best", Simbolo = "g", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double v = inputs["v_atual"];
                        double w = inputs["Inércia w"];
                        double x = inputs["x_atual"];
                        double p = inputs["p_best"];
                        double g = inputs["g_best"];
                        
                        double c1 = 2, c2 = 2;
                        double r1 = 0.5, r2 = 0.5; // simplified (would be random)
                        
                        double v_new = w * v + c1 * r1 * (p - x) + c2 * r2 * (g - x);
                        return v_new;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-132: Programação Dinâmica — Bellman
                new Formula
                {
                    Id = "3720",
                    CodigoCompendio = "V10-132",
                    Nome = "Equação de Bellman — Programação Dinâmica",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Dinâmica",
                    Expressao = @"V(s) = max_a [R(s,a) + γ·V(s')]",
                    Descricao = "Valor ótimo estado s. R: recompensa imediata. γ: fator desconto. s': próximo estado. Princípio optimalidade: subestrutura ótima. Aplicações: controle, RL, caminho mínimo.",
                    ExemploPratico = "Caminho mínimo grid 10×10: DP O(n²). Mochila (knapsack): DP O(nW). Q-learning: aproxima V(s) iterativamente. γ=0.9: futuro vale 90%. Dijkstra: caso especial DP.",
                    Criador = "Bellman (1957, Dynamic Programming); RL (Sutton-Barto 1998)",
                    AnoOrigin = "1957",
                    VariavelResultado = "V_s",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R(s,a)", Simbolo = "R", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ", Simbolo = "gamma", Unidade = "", ValorPadrao = 0.9, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "V(s')", Simbolo = "V_next", Unidade = "", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double R = inputs["R(s,a)"];
                        double gamma = inputs["γ"];
                        double V_next = inputs["V(s')"];
                        
                        double V_s = R + gamma * V_next;
                        return V_s;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-133: Otimização Combinatória — Branch and Bound
                new Formula
                {
                    Id = "3721",
                    CodigoCompendio = "V10-133",
                    Nome = "Branch and Bound — Poda",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Combinatória",
                    Expressao = @"Podar nó se: bound(nó) ≤ best_solution",
                    Descricao = "Explora árvore soluções. Branching: divide problema. Bounding: limite inferior/superior. Prunning: elimina subespaços inviáveis. Usado TSP, knapsack, scheduling.",
                    ExemploPratico = "TSP 20 cidades: ~10^18 tours. B&B: explora ~10⁶ nós (poda 99.99999%). Best-first: explora nós promissores primeiro. Relaxação linear: bound comum.",
                    Criador = "Land e Doig (1960, Econometrica)",
                    AnoOrigin = "1960",
                    VariavelResultado = "poda",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "bound_nó", Simbolo = "bound", Unidade = "", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "best_solution", Simbolo = "best", Unidade = "", ValorPadrao = 120, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double bound = inputs["bound_nó"];
                        double best = inputs["best_solution"];
                        
                        double poda = (bound <= best) ? 1 : 0; // 1=poda, 0=explora
                        return poda;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-134: Regularização L1/L2
                new Formula
                {
                    Id = "3722",
                    CodigoCompendio = "V10-134",
                    Nome = "Regularização L1 (Lasso) e L2 (Ridge)",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Penalização/Regularização",
                    Expressao = @"L1: min ||Xw−y||² + λ||w||₁; L2: + λ||w||₂²",
                    Descricao = "L1: esparsidade (muitos w=0, seleção features). L2: shrinkage (w pequenos, estabilidade). Elastic net: combina L1+L2. λ: força regularização.",
                    ExemploPratico = "1000 features, 100 samples (p>n): overfitting. Lasso λ=0.1: 50 features não-zero (sparse). Ridge λ=1: todos features com w pequeno. Cross-val: escolhe λ ótimo.",
                    Criador = "Tikhonov (1943, L2); Tibshirani (1996, Lasso); Zou-Hastie (2005, Elastic net)",
                    AnoOrigin = "1996",
                    VariavelResultado = "penalty",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "λ", Simbolo = "lambda", Unidade = "", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "|w| (L1 norm)", Simbolo = "w_L1", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "||w||² (L2 norm²)", Simbolo = "w_L2_sq", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["λ"];
                        double w_L1 = inputs["|w| (L1 norm)"];
                        double w_L2_sq = inputs["||w||² (L2 norm²)"];
                        
                        // Escolher tipo regularização (exemplo L1)
                        double penalty = lambda * w_L1;
                        return penalty;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-135: Bayesian Optimization
                new Formula
                {
                    Id = "3723",
                    CodigoCompendio = "V10-135",
                    Nome = "Bayesian Optimization — Acquisition Function",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Caixa-Preta",
                    Expressao = @"α_EI(x) = E[max(0, f(x)−f*)]",
                    Descricao = "Otimiza funções caras (ML hyperparams). GP: modelo probabilístico f. EI: expected improvement. Explora vs exploita trade-off. SMAC, TPE: alternativas.",
                    ExemploPratico = "Neural net: treino=5h/config. Grid 100 configs=500h. Bayesian opt: 20 configs inteligentes~100h (~5× mais rápido). Spearmint, Hyperopt, Optuna: frameworks.",
                    Criador = "Mockus (1974); ML application (Snoek et al. 2012)",
                    AnoOrigin = "2012",
                    VariavelResultado = "alpha_EI",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "μ(x) (GP mean)", Simbolo = "mu", Unidade = "", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ(x) (GP std)", Simbolo = "sigma", Unidade = "", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f* (best)", Simbolo = "f_star", Unidade = "", ValorPadrao = 0.9, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double mu = inputs["μ(x) (GP mean)"];
                        double sigma = inputs["σ(x) (GP std)"];
                        double f_star = inputs["f* (best)"];
                        
                        if (sigma == 0) return 0;
                        
                        // Aproximação EI (simplified)
                        double Z = (mu - f_star) / sigma;
                        // Para Z>0: EI ≈ σ·(Z·Φ(Z) + φ(Z)) onde Φ=CDF, φ=PDF normal
                        // Aproximação: EI ≈ max(0, mu - f_star) se sigma pequeno
                        double alpha_EI = Math.Max(0, mu - f_star) + 0.4 * sigma;
                        
                        return alpha_EI;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-136: Método do Ponto Crítico
                new Formula
                {
                    Id = "3724",
                    CodigoCompendio = "V10-136",
                    Nome = "Análise Ponto Crítico — Teste da Segunda Derivada",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Cálculo de Variações",
                    Expressao = @"f''(x*)>0: mínimo local; f''(x*)<0: máximo local",
                    Descricao = "Ponto crítico: f'(x*)=0. Teste segunda derivada classifica. f''=0: teste inconclusivo (verificar ordem superior). Multi-variável: Hessiana determina (autovalores).",
                    ExemploPratico = "f=x⁴−4x²: f'=4x³−8x=0→x=0,±√2. x=0: f''=−8<0 máximo local. x=±√2: f''=16>0 mínimos locais. Portfolio: máximo retorno=ponto crítico função utilidade.",
                    Criador = "Cálculo clássico (Newton, Leibniz séc. 17)",
                    AnoOrigin = "1680",
                    VariavelResultado = "f_double_prime",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "f''(x*)", Simbolo = "f_2nd", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double f_2nd = inputs["f''(x*)"];
                        return f_2nd; // >0: mín; <0: máx; =0: indefinido
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-137: Otimização Multi-Objetivo — Pareto
                new Formula
                {
                    Id = "3725",
                    CodigoCompendio = "V10-137",
                    Nome = "Otimalidade de Pareto",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Multi-Objetivo",
                    Expressao = @"Pareto-ótimo: ∄x' tal que fᵢ(x')≤fᵢ(x) ∀i e ∃j: fⱼ(x')<fⱼ(x)",
                    Descricao = "Não existe x' que melhore algum objetivo sem piorar outro. Fronteira Pareto: conjunto soluções não-dominadas. Trade-offs explícitos. NSGA-II, MOEA/D: algoritmos.",
                    ExemploPratico = "Design carro: minimizar custo vs maximizar segurança. Pareto front: [(custo=10k,seg=3★), (15k,4★), (25k,5★)]. Escolha depende preferências. Weighted sum: scalariza.",
                    Criador = "Pareto (1896, economia); Engenharia (Srinivas-Deb 1994, NSGA)",
                    AnoOrigin = "1896",
                    VariavelResultado = "dominado",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "f₁(x)", Simbolo = "f1_x", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f₁(x')", Simbolo = "f1_x_prime", Unidade = "", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f₂(x)", Simbolo = "f2_x", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f₂(x')", Simbolo = "f2_x_prime", Unidade = "", ValorPadrao = 7, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double f1_x = inputs["f₁(x)"];
                        double f1_xp = inputs["f₁(x')"];
                        double f2_x = inputs["f₂(x)"];
                        double f2_xp = inputs["f₂(x')"];
                        
                        // x' domina x se: f1_xp<=f1_x AND f2_xp<=f2_x AND (strict em ao menos 1)
                        bool dominado = (f1_xp <= f1_x && f2_xp <= f2_x && (f1_xp < f1_x || f2_xp < f2_x)) ? true : false;
                        
                        return dominado ? 1 : 0;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-138: Descida de Coordenadas
                new Formula
                {
                    Id = "3726",
                    CodigoCompendio = "V10-138",
                    Nome = "Descida de Coordenadas (Coordinate Descent)",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Iterativa",
                    Expressao = @"x_i^{(k+1)} = argmin_{x_i} f(x₁^{(k+1)},…,xᵢ,…,x_n^{(k)})",
                    Descricao = "Otimiza uma variável por vez (ciclicamente). Lasso: solução analítica cada coordenada (soft-thresholding). Gauss-Seidel: caso especial. Convergência: depende smoothness.",
                    ExemploPratico = "Lasso 1000 features: coordinate descent ~10× mais rápido que gradient descent. SVM dual: SMO (coordinate ascent 2 vars por vez). EM algorithm: similar ideia.",
                    Criador = "Histórico (Gauss-Seidel 1823); ML (Friedman et al. 2007, glmnet)",
                    AnoOrigin = "2007",
                    VariavelResultado = "x_i_new",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x_i atual", Simbolo = "x_i", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "∂f/∂x_i", Simbolo = "grad_i", Unidade = "", ValorPadrao = -2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Step size", Simbolo = "alpha", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x_i = inputs["x_i atual"];
                        double grad_i = inputs["∂f/∂x_i"];
                        double alpha = inputs["Step size"];
                        
                        double x_i_new = x_i - alpha * grad_i;
                        return x_i_new;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-139: Proximal Gradient Method
                new Formula
                {
                    Id = "3727",
                    CodigoCompendio = "V10-139",
                    Nome = "Proximal Gradient Method",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Não-Suave",
                    Expressao = @"x^{k+1} = prox_{αg}(x^k − α∇f(x^k))",
                    Descricao = "Para f+g onde f smooth, g não-smooth (L1, indicador). prox: operador proximal. ISTA, FISTA (acelerado): convergência O(1/k²). Compressed sensing, imagem.",
                    ExemploPratico = "Lasso: f=||Ax−b||², g=λ||x||₁. prox_L1: soft-thresholding. Image denoising: f=fidelidade, g=TV (total variation). FISTA: 10× mais rápido que subgradient.",
                    Criador = "Moreau (1965, proximal operator); Beck-Teboulle (2009, FISTA)",
                    AnoOrigin = "2009",
                    VariavelResultado = "x_prox",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x^k", Simbolo = "x_k", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "∇f(x^k)", Simbolo = "grad", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "α", Simbolo = "alpha", Unidade = "", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "λ (L1 penalty)", Simbolo = "lambda", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x_k = inputs["x^k"];
                        double grad = inputs["∇f(x^k)"];
                        double alpha = inputs["α"];
                        double lambda = inputs["λ (L1 penalty)"];
                        
                        // Gradient step
                        double z = x_k - alpha * grad;
                        
                        // Proximal operator for L1: soft-thresholding
                        double threshold = alpha * lambda;
                        double x_prox = 0;
                        if (z > threshold) x_prox = z - threshold;
                        else if (z < -threshold) x_prox = z + threshold;
                        else x_prox = 0;
                        
                        return x_prox;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-140: Método de Powell
                new Formula
                {
                    Id = "3728",
                    CodigoCompendio = "V10-140",
                    Nome = "Método de Powell — Direções Conjugadas",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Sem Derivadas",
                    Expressao = @"Busca em D direções conjugadas; não requer ∇f",
                    Descricao = "Derivative-free. Constrói direções conjugadas iterativamente. Quadrática n-dim: converge em n iterações. Pattern search: similar. Útil quando ∇f não disponível/caro.",
                    ExemploPratico = "Função black-box (simulação física): Powell otimiza 10 params sem derivadas. Nelder-Mead: alternativa (simplex). ZAP (Powell 1964): primeiras implementações.",
                    Criador = "Powell (1964, Computer Journal)",
                    AnoOrigin = "1964",
                    VariavelResultado = "iter_convergência",
                    UnidadeResultado = "iterações",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Dimensão n", Simbolo = "n", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tipo função (1=quad,2=geral)", Simbolo = "tipo", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        int n = (int)inputs["Dimensão n"];
                        int tipo = (int)inputs["Tipo função (1=quad,2=geral)"];
                        
                        // Quadrática: ~n iterações. Geral: ~10n
                        double iter = (tipo == 1) ? n : 10 * n;
                        return iter;
                    },
                    Icone = "📊",
                    Unidades = "",
                },

                // V10-141: Subgradiente
                new Formula
                {
                    Id = "3729",
                    CodigoCompendio = "V10-141",
                    Nome = "Método do Subgradiente",
                    Categoria = "Otimização Matemática",
                    SubCategoria = "Otimização Não-Diferenciável",
                    Expressao = @"x^{k+1} = x^k − α_k·g^k; g^k ∈ ∂f(x^k)",
                    Descricao = "Para f não-diferenciável (L1, max, ReLU). g: subgradiente. ∂f: subdifferential. Convergência: α_k→0, Σα_k→∞. Mais lento que gradient (O(1/√k)).",
                    ExemploPratico = "f=|x|: ∂f(0)=[−1,1]. SVM hinge loss: não-diferenciável em margem. α_k=1/k típico. Projected subgradient: adiciona projeção em domínio viável.",
                    Criador = "Shor (1962, URSS); Polyak (1969, step size rules)",
                    AnoOrigin = "1962",
                    VariavelResultado = "x_new",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x^k", Simbolo = "x_k", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Subgradiente g", Simbolo = "g", Unidade = "", ValorPadrao = -1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "α_k", Simbolo = "alpha", Unidade = "", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x_k = inputs["x^k"];
                        double g = inputs["Subgradiente g"];
                        double alpha = inputs["α_k"];
                        
                        double x_new = x_k - alpha * g;
                        return x_new;
                    },
                    Icone = "📊",
                    Unidades = "",
                }
            });
        }
    }
}
