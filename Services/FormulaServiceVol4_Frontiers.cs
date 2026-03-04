using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 4 — PARTE VI: FRONTEIRAS INTERDISCIPLINARES
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 22. TEORIA DOS JOGOS
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaDosJogos()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_tj01", Nome = "Equilíbrio de Nash", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Estratégicos",
                Expressao = "σᵢ* ∈ argmax_{σᵢ} uᵢ(σᵢ,σ₋ᵢ*)  ∀i",
                ExprTexto = "σᵢ* ∈ argmax uᵢ(σᵢ,σ*₋ᵢ) ∀i",
                Icone = "NE",
                Descricao = "Perfil de estratégias onde nenhum jogador melhora unilateralmente. Existência: todo jogo finito tem NE em estratégias mistas (Nash 1950). Pode haver múltiplos equilíbrios.",
                Criador = "John Nash",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "4_tj02", Nome = "Estratégias Mistas", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Estratégicos",
                Expressao = "σᵢ ∈ Δ(Sᵢ);  uᵢ(σ) = Σ_{s∈S} (Πⱼσⱼ(sⱼ))·uᵢ(s)",
                ExprTexto = "σᵢ∈Δ(Sᵢ); u=Σ(Πσⱼ(sⱼ))uᵢ(s)",
                Icone = "Δ",
                Descricao = "Distribuição de probabilidade sobre estratégias puras. Utilidade esperada: soma ponderada. Suporte do NE misto: todas as puras jogadas com prob>0 dão mesma utilidade esperada.",
            },
            new Formula
            {
                Id = "4_tj03", Nome = "Teorema Minimax", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Estratégicos",
                Expressao = "max_σ₁ min_σ₂ u₁ = min_σ₂ max_σ₁ u₁ = v (valor do jogo)",
                ExprTexto = "maxmin u₁ = minmax u₁ = v",
                Icone = "minmax",
                Descricao = "Jogos de soma zero: valor do jogo v existe, cada jogador garante v. Equivalente a programação linear (dualidade). Poker, xadrez (em teoria). von Neumann (1928).",
                Criador = "John von Neumann",
                AnoOrigin = "1928",
            },
            new Formula
            {
                Id = "4_tj04", Nome = "Equilíbrio Perfeito em Subjogos (SPE)", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Sequenciais",
                Expressao = "NE + racional em todo subjogo; resolve por indução retroativa",
                ExprTexto = "SPE: NE em todo subjogo (backward induction)",
                Icone = "SPE",
                Descricao = "Refinamento de Nash para jogos extensivos: estratégia é NE em todo subjogo (ameaças críveis). Indução retroativa em jogos finitos de informação perfeita. Selten (1965).",
                Criador = "Reinhard Selten",
                AnoOrigin = "1965",
            },
            new Formula
            {
                Id = "4_tj05", Nome = "Equilíbrio Bayesiano de Nash (BNE)", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Sequenciais",
                Expressao = "σᵢ*(tᵢ) ∈ argmax E_{t₋ᵢ}[uᵢ(σᵢ,σ*₋ᵢ(t₋ᵢ),tᵢ)]",
                ExprTexto = "σ*(tᵢ)∈argmax E[u|tᵢ,σ*₋ᵢ]",
                Icone = "BNE",
                Descricao = "NE com informação incompleta: tipos tᵢ (privados) com prior p(t). Cada tipo maximiza utilidade esperada dado prior sobre tipos adversários. Harsanyi (1967-68).",
                Criador = "John Harsanyi",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "4_tj06", Nome = "Leilão de Vickrey (Segundo Preço)", Categoria = "Teoria dos Jogos", SubCategoria = "Mecanismos",
                Expressao = "Estratégia dominante: bᵢ=vᵢ;  vencedor paga 2ª maior oferta",
                ExprTexto = "b*=v (verdade); paga max b₋ᵢ",
                Icone = "2nd",
                Descricao = "Leilão selado de segundo preço: revelar valor verdadeiro é dominante (incentive-compatible). Vencedor paga preço do 2º lance. Receita equivalente a inglês.",
                Criador = "William Vickrey",
                AnoOrigin = "1961",
            },
            new Formula
            {
                Id = "4_tj07", Nome = "Mecanismo VCG", Categoria = "Teoria dos Jogos", SubCategoria = "Mecanismos",
                Expressao = "pᵢ = Σⱼ≠ᵢ vⱼ(a*₋ᵢ) - Σⱼ≠ᵢ vⱼ(a*)  (externalidade)",
                ExprTexto = "pᵢ = Σⱼ≠ᵢvⱼ(a*₋ᵢ)−Σⱼ≠ᵢvⱼ(a*)",
                Icone = "VCG",
                Descricao = "Vickrey-Clarke-Groves: mecanismo truthful geral. Pagamento = externalidade imposta aos outros. Eficiente (maximiza bem-estar social) e compatível com incentivos. Aplicações: leilões, alocação.",
                Criador = "Vickrey / Clarke / Groves",
            },
            new Formula
            {
                Id = "4_tj08", Nome = "Teorema da Revelação", Categoria = "Teoria dos Jogos", SubCategoria = "Mecanismos",
                Expressao = "Todo resultado implementável por mecanismo indireto pode ser implementado por mecanismo direto truthful",
                ExprTexto = "Mecanismo indireto → direto truthful equivalente",
                Icone = "Rev",
                Descricao = "Resultado central de mechanism design: qualquer resultado alcançável pode ser obtido pedindo tipos diretamente. Foco no design: definir regra de alocação + pagamento truthful.",
            },
            new Formula
            {
                Id = "4_tj09", Nome = "Receita Esperada (Equivalência)", Categoria = "Teoria dos Jogos", SubCategoria = "Mecanismos",
                Expressao = "Rev = E[v(2:n)] = ∫₀^1 v·(1-F(v))ⁿ⁻¹ n·f(v)·(n-1)(1-F(v))... dv",
                ExprTexto = "Equiv. de receita: E[pago]=E[v₍₂:ₙ₎]",
                Icone = "REq",
                Descricao = "Revenue Equivalence Theorem: com IPV simétrico, todos os leilões eficientes dão mesma receita esperada (inglês, holandês, 1º preço, 2º preço). Myerson (1981).",
                Criador = "Roger Myerson",
                AnoOrigin = "1981",
            },
            new Formula
            {
                Id = "4_tj10", Nome = "Dinâmica do Replicador", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Evolucionários",
                Expressao = "ẋᵢ = xᵢ(fᵢ(x) - f̄(x));  f̄ = Σⱼ xⱼfⱼ",
                ExprTexto = "ẋᵢ = xᵢ(fᵢ−f̄); f̄=Σxⱼfⱼ",
                Icone = "Rep",
                Descricao = "Evolução de frequências de estratégias em populações: estratégias com fitness acima da média crescem. Pontos fixos incluem NE. Conexão biologia-economia.",
                Criador = "Taylor / Jonker",
                AnoOrigin = "1978",
            },
            new Formula
            {
                Id = "4_tj11", Nome = "ESS (Estratégia Evolutivamente Estável)", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Evolucionários",
                Expressao = "u(σ*,σ*) > u(σ,σ*) ou [u(σ*,σ*)=u(σ,σ*) e u(σ*,σ)>u(σ,σ)]",
                ExprTexto = "ESS: σ* resiste a mutantes raros",
                Icone = "ESS",
                Descricao = "Refinamento de NE para jogos evolucionários: população σ* não pode ser invadida por mutante σ raro. Mais forte que NE. Hawk-Dove: ESS misto (frequência de agressividade).",
                Criador = "John Maynard Smith",
                AnoOrigin = "1973",
            },
            new Formula
            {
                Id = "4_tj12", Nome = "Valor de Shapley", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Cooperativos",
                Expressao = "φᵢ(v) = Σ_{S⊆N\\{i}} |S|!(n-|S|-1)!/n! · [v(S∪{i})-v(S)]",
                ExprTexto = "φᵢ = Σ_S (|S|!(n−|S|−1)!/n!)[v(S∪{i})−v(S)]",
                Icone = "φ",
                Descricao = "Distribuição justa de valor em coalizão: contribuição marginal média sobre todas as ordens de chegada. Axiomas: eficiência, simetria, linearidade, nulidade. Aplicações: ML (SHAP values).",
                Criador = "Lloyd Shapley",
                AnoOrigin = "1953",
            },
            new Formula
            {
                Id = "4_tj13", Nome = "Core (Núcleo)", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Cooperativos",
                Expressao = "Core = {x: Σᵢ∈N xᵢ=v(N), Σᵢ∈S xᵢ≥v(S) ∀S⊆N}",
                ExprTexto = "Core = {x: x(N)=v(N), x(S)≥v(S) ∀S}",
                Icone = "Core",
                Descricao = "Conjunto de alocações que nenhuma coalizão quer desviar: cada grupo recebe pelo menos o que pode obter sozinho. Pode ser vazio. Bondareva-Shapley: core não-vazio ⟺ jogo balanceado.",
            },
            new Formula
            {
                Id = "4_tj14", Nome = "Negociação de Nash", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Cooperativos",
                Expressao = "(u₁*,u₂*) = argmax (u₁-d₁)(u₂-d₂)  s.t. (u₁,u₂)∈F",
                ExprTexto = "max(u₁−d₁)(u₂−d₂) s.t. (u₁,u₂)∈F",
                Icone = "NBS",
                Descricao = "Solução axiomática de barganha: maximiza produto dos ganhos sobre ponto de desacordo d. Axiomas: Pareto, simetria, invariância a transformações afins, IIA.",
                Criador = "John Nash",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "4_tj15", Nome = "Dilema do Prisioneiro (Iterado)", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Repetidos",
                Expressao = "Tit-for-Tat: coopera 1ª vez, depois espelha adversário",
                ExprTexto = "TfT: C→C; D→D (reciprocidade)",
                Icone = "PD",
                Descricao = "Jogo estágio: (C,C)>(D,D) mas D domina. Repetido infinito: cooperação sustentável se δ≥(T-R)/(T-P) (folk theorem). Torneio de Axelrod (1984): TfT venceu. Evolução da cooperação.",
            },
            new Formula
            {
                Id = "4_tj16", Nome = "Folk Theorem", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Repetidos",
                Expressao = "Qualquer payoff viável e individualmente racional é NE de jogo repetido (δ→1)",
                ExprTexto = "δ→1: qualquer u viável e IR é NE",
                Icone = "Folk",
                Descricao = "Em jogos repetidos com desconto δ suficiente: qualquer perfil de payoffs cooperativo pode ser sustentado como equilíbrio. Resultado: multiplicidade enorme de equilíbrios → poucos selecionados.",
            },
            new Formula
            {
                Id = "4_tj17", Nome = "Equilíbrio Correlacionado", Categoria = "Teoria dos Jogos", SubCategoria = "Jogos Estratégicos",
                Expressao = "Σ_{s₋ᵢ} p(sᵢ,s₋ᵢ)[uᵢ(sᵢ,s₋ᵢ)-uᵢ(s'ᵢ,s₋ᵢ)] ≥ 0  ∀i,sᵢ,s'ᵢ",
                ExprTexto = "CE: obedience constraints ∀i,sᵢ,s'ᵢ",
                Icone = "CE",
                Descricao = "Distribuição conjunta p(s) correlacionada (mediador recomenda). Conjunto convexo contendo todos NE. Pode Pareto-dominar NE. Computável via LP (vs PPAD para NE).",
                Criador = "Robert Aumann",
                AnoOrigin = "1974",
            },
            new Formula
            {
                Id = "4_tj18", Nome = "Leilão de Myerson (Ótimo)", Categoria = "Teoria dos Jogos", SubCategoria = "Mecanismos",
                Expressao = "Revenue ótima: max E[Σᵢ φᵢ(vᵢ)xᵢ]; φ = v - (1-F)/f (virtual value)",
                ExprTexto = "max E[Σφ(v)x]; φ=v−(1−F)/f",
                Icone = "Opt",
                Descricao = "Leilão ótimo de receita: aloca ao maior virtual value φ(v)=v-(1-F(v))/f(v) se φ≥0. Com distribuição regular (φ crescente): 2º preço com reserva r* onde φ(r*)=0. Prêmio Nobel 2007.",
                Criador = "Roger Myerson",
                AnoOrigin = "1981",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 23. REDES COMPLEXAS
    // ─────────────────────────────────────────────────────
    private void AdicionarRedesComplexas()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_rc01", Nome = "Distribuição de Grau", Categoria = "Redes Complexas", SubCategoria = "Propriedades",
                Expressao = "P(k): fração de nós com grau k;  ⟨k⟩ = Σ kP(k)",
                ExprTexto = "P(k): prob. grau=k; ⟨k⟩=ΣkP(k)",
                Icone = "P(k)",
                Descricao = "Distribuição de grau: propriedade mais básica de uma rede. Redes aleatórias: Poisson. Redes reais (web, social, biológica): frequentemente power-law ou heavy-tailed.",
            },
            new Formula
            {
                Id = "4_rc02", Nome = "Rede Scale-Free (Lei de Potência)", Categoria = "Redes Complexas", SubCategoria = "Propriedades",
                Expressao = "P(k) ~ k^{-γ};  tipicamente 2 < γ < 3",
                ExprTexto = "P(k) ∝ k⁻ᵞ; 2<γ<3",
                Icone = "SF",
                Descricao = "Redes livres de escala: poucos hubs com grau muito alto, muitos nós de grau baixo. Internet, redes de proteínas, citações. Robustas a falhas aleatórias, vulneráveis a ataques direcionados.",
                Criador = "Albert-László Barabási",
                AnoOrigin = "1999",
            },
            new Formula
            {
                Id = "4_rc03", Nome = "Propriedade Small-World", Categoria = "Redes Complexas", SubCategoria = "Propriedades",
                Expressao = "L ~ ln(N)/ln⟨k⟩;  C ≫ C_random",
                ExprTexto = "L∝lnN (curto); C≫Crand (clusterizado)",
                Icone = "SW",
                Descricao = "Distância média curta (logarítmica em N) + alto coeficiente de clustering. 'Seis graus de separação'. Modelo WS: rede regular + rewiring com prob. p → transição percolação.",
                Criador = "Duncan Watts / Steven Strogatz",
                AnoOrigin = "1998",
            },
            new Formula
            {
                Id = "4_rc04", Nome = "Coeficiente de Clustering", Categoria = "Redes Complexas", SubCategoria = "Propriedades",
                Expressao = "Cᵢ = 2Eᵢ/(kᵢ(kᵢ-1));  C = ⟨Cᵢ⟩",
                ExprTexto = "Cᵢ = 2Eᵢ/(kᵢ(kᵢ−1)); C=⟨Cᵢ⟩",
                Icone = "C",
                Descricao = "Fração de pares de vizinhos que são conectados. Transitividade local: 'amigos de amigos são amigos'. Redes sociais: C~0.1-0.5. Redes aleatórias: C=⟨k⟩/N → 0.",
            },
            new Formula
            {
                Id = "4_rc05", Nome = "Centralidade de Betweenness", Categoria = "Redes Complexas", SubCategoria = "Centralidade",
                Expressao = "gᵢ = Σ_{s≠t≠i} σ_st(i)/σ_st",
                ExprTexto = "gᵢ = Σ σst(i)/σst",
                Icone = "betw",
                Descricao = "Fração de caminhos mais curtos que passam pelo nó i. Alta betweenness = ponte entre comunidades. Detecção de comunidades (Girvan-Newman): remove arestas de maior betweenness.",
            },
            new Formula
            {
                Id = "4_rc06", Nome = "PageRank", Categoria = "Redes Complexas", SubCategoria = "Centralidade",
                Expressao = "PR(i) = (1-d)/N + d Σⱼ→ᵢ PR(j)/kⱼ_out",
                ExprTexto = "PR(i) = (1−d)/N+d·Σⱼ→ᵢPR(j)/kj_out",
                Icone = "PR",
                Descricao = "Importância recursiva: nó importante se apontado por nós importantes. d = damping (0.85), random surfer com teleporte. Autovetor principal de Google matrix. O(m) por iteração.",
                Criador = "Larry Page / Sergey Brin",
                AnoOrigin = "1998",
            },
            new Formula
            {
                Id = "4_rc07", Nome = "Modularidade (Newman-Girvan)", Categoria = "Redes Complexas", SubCategoria = "Comunidades",
                Expressao = "Q = (1/2m)Σᵢⱼ [Aᵢⱼ - kᵢkⱼ/(2m)]δ(cᵢ,cⱼ)",
                ExprTexto = "Q = (1/2m)Σ[Aij−kikj/2m]δ(ci,cj)",
                Icone = "Q",
                Descricao = "Qualidade de partição em comunidades: fração de arestas intra-comunidade menos esperado em rede aleatória. Q∈[-½,1], Q>0.3 = boa estrutura. Método Louvain: heurística gulosa O(n log n).",
                Criador = "Mark Newman",
                AnoOrigin = "2004",
            },
            new Formula
            {
                Id = "4_rc08", Nome = "Modelo Erdős-Rényi", Categoria = "Redes Complexas", SubCategoria = "Modelos Generativos",
                Expressao = "G(n,p): cada aresta com prob. p;  ⟨k⟩ = (n-1)p",
                ExprTexto = "G(n,p): P(aresta)=p; ⟨k⟩=(n−1)p",
                Icone = "ER",
                Descricao = "Rede aleatória clássica: grau Poisson, sem clustering, componente gigante em p=1/n (transição de fase). Modelo nulo para comparação com redes reais.",
                Criador = "Paul Erdős / Alfréd Rényi",
                AnoOrigin = "1959",
            },
            new Formula
            {
                Id = "4_rc09", Nome = "Modelo Barabási-Albert (Preferential Attachment)", Categoria = "Redes Complexas", SubCategoria = "Modelos Generativos",
                Expressao = "P(novo→i) = kᵢ/Σⱼkⱼ → P(k) ~ k⁻³",
                ExprTexto = "P(link→i) ∝ kᵢ → P(k)∝k⁻³",
                Icone = "BA",
                Descricao = "Crescimento + ligação preferencial: novos nós se conectam a nós de alto grau proporcionalmente a k. Gera γ=3 universal. 'Ricos ficam mais ricos' (efeito Matthew).",
                Criador = "Albert-László Barabási / Réka Albert",
                AnoOrigin = "1999",
            },
            new Formula
            {
                Id = "4_rc10", Nome = "Stochastic Block Model (SBM)", Categoria = "Redes Complexas", SubCategoria = "Modelos Generativos",
                Expressao = "P(Aᵢⱼ=1) = ω_{cᵢ,cⱼ};  ω = matriz de probabilidades entre blocos",
                ExprTexto = "P(Aij) = ω(ci,cj); ω=prob. entre blocos",
                Icone = "SBM",
                Descricao = "Modelo generativo com comunidades: nós pertencem a blocos (clusters), conexão depende dos blocos. Caso assortativo: ω_within > ω_between. Base teórica para detecção de comunidades.",
            },
            new Formula
            {
                Id = "4_rc11", Nome = "Percolação em Redes", Categoria = "Redes Complexas", SubCategoria = "Processos em Redes",
                Expressao = "Percolação por sítio: p_c = 1/⟨k⟩ (ER);  scale-free γ≤3: p_c→0",
                ExprTexto = "pc ≈ 1/⟨k⟩ (ER); γ≤3: pc→0",
                Icone = "perc",
                Descricao = "Remoção aleatória de nós: componente gigante sobrevive até p_c. Redes scale-free com γ≤3: resilientes a falhas aleatórias (p_c→0) mas frágeis a ataques em hubs.",
            },
            new Formula
            {
                Id = "4_rc12", Nome = "Modelo SIR em Redes", Categoria = "Redes Complexas", SubCategoria = "Processos em Redes",
                Expressao = "R₀ = β⟨k²⟩/(γ⟨k⟩);  epidemia se R₀>1",
                ExprTexto = "R₀ = β⟨k²⟩/(γ⟨k⟩); epidemia: R₀>1",
                Icone = "SIR",
                Descricao = "Epidemia em rede heterogênea: limiar depende de ⟨k²⟩/⟨k⟩ (não só ⟨k⟩). Scale-free com γ≤3: ⟨k²⟩→∞ → R₀→∞ (epidemia para qualquer β>0). Pastor-Satorras & Vespignani (2001).",
            },
            new Formula
            {
                Id = "4_rc13", Nome = "Modelo de Cascatas (Watts)", Categoria = "Redes Complexas", SubCategoria = "Processos em Redes",
                Expressao = "Nó adota se fração de vizinhos adotados ≥ limiar φ",
                ExprTexto = "Adota se (vizinhos adotados)/k ≥ φ",
                Icone = "casc",
                Descricao = "Cascata de informação/inovação: regra de threshold. Cascata global se existe componente vulnerável (grau suficientemente baixo). Paradoxo: hubs resistem e podem bloquear cascata.",
                Criador = "Duncan Watts",
                AnoOrigin = "2002",
            },
            new Formula
            {
                Id = "4_rc14", Nome = "Rede Multiplex", Categoria = "Redes Complexas", SubCategoria = "Redes Avançadas",
                Expressao = "G = (V, E₁, E₂, ..., Eₗ);  L camadas com mesmo nó set",
                ExprTexto = "G multiplex: L camadas, mesmo V",
                Icone = "mux",
                Descricao = "Mesmo conjunto de nós, múltiplos tipos de relação (layers). Ex: rede social = amizade + trabalho + família. Percolação interdependente: falha em cascata entre camadas.",
            },
            new Formula
            {
                Id = "4_rc15", Nome = "Grafo Bipartido / Projeção", Categoria = "Redes Complexas", SubCategoria = "Redes Avançadas",
                Expressao = "Projeção: A_proj = B·B' - diag(B·B')",
                ExprTexto = "A_proj = BB'−diag(BB')",
                Icone = "bip",
                Descricao = "Rede com dois tipos de nós (ex: autores-artigos, genes-doenças). Projeção: conecta nós do mesmo tipo se compartilham vizinho bipartido. Perda de informação → usar bipartido direto.",
            },
            new Formula
            {
                Id = "4_rc16", Nome = "Assortativity (Correlação de Grau)", Categoria = "Redes Complexas", SubCategoria = "Propriedades",
                Expressao = "r = (Σᵢⱼ(Aᵢⱼ-kᵢkⱼ/2m)kᵢkⱼ) / (Σᵢⱼ(kᵢδᵢⱼ-kᵢkⱼ/2m)kᵢkⱼ)",
                ExprTexto = "r = correlação de Pearson dos graus dos extremos",
                Icone = "assort",
                Descricao = "r>0: assortativa (hubs conectam a hubs — social). r<0: dissortativa (hubs a folhas — biológica, tecnológica). Mede tendência de nós similares se conectarem.",
                Criador = "Mark Newman",
                AnoOrigin = "2002",
            },
            new Formula
            {
                Id = "4_rc17", Nome = "Espectro do Laplaciano", Categoria = "Redes Complexas", SubCategoria = "Propriedades",
                Expressao = "L = D-A;  λ₁=0, λ₂=conexidade algébrica (Fiedler)",
                ExprTexto = "L=D−A; λ₁=0; λ₂=Fiedler value",
                Icone = "λ₂",
                Descricao = "Laplaciano L=D-A: λ₂>0 ⟺ grafo conectado. λ₂ mede 'gargalo' → spectral clustering (corte do vetor de Fiedler). Cheeger inequality: h(G) entre λ₂/2 e √(2λ₂).",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 24. CRIPTOGRAFIA PÓS-QUÂNTICA E RETICULADOS
    // ─────────────────────────────────────────────────────
    private void AdicionarCriptografiaPosQuantica()
    {
        _formulas.AddRange([
            // 24.1 Reticulados
            new Formula
            {
                Id = "4_lt01", Nome = "Reticulado (Definição)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Reticulados",
                Expressao = "Λ = {Bz : z∈ℤⁿ};  B∈ℝⁿˣⁿ base",
                ExprTexto = "Λ = {Bz: z∈ℤⁿ}, B=base",
                Icone = "Λ",
                Descricao = "Conjunto discreto de pontos gerados por combinações inteiras de vetores base. Dimensão n, determinante det(Λ) = |det(B)|. Estrutura algébrica rica com problemas computacionais difíceis.",
            },
            new Formula
            {
                Id = "4_lt02", Nome = "SVP (Shortest Vector Problem)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Reticulados",
                Expressao = "Encontrar v∈Λ\\{0} com ‖v‖ = λ₁(Λ)  (mínimo)",
                ExprTexto = "SVP: min ‖v‖ para v∈Λ\\{0}",
                Icone = "SVP",
                Descricao = "Problema central: encontrar vetor mais curto no reticulado. NP-hard para exato (Ajtai 1998). Melhor algoritmo: sieving 2^{0.292n}. Aproximação gap-SVP base de criptografia.",
            },
            new Formula
            {
                Id = "4_lt03", Nome = "CVP (Closest Vector Problem)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Reticulados",
                Expressao = "Dado t∈ℝⁿ, encontrar v∈Λ minimizando ‖v-t‖",
                ExprTexto = "CVP: min ‖v−t‖ para v∈Λ",
                Icone = "CVP",
                Descricao = "Vetor mais próximo de um alvo t. NP-hard. Relacionado a decodificação de códigos. Babai's nearest plane: aproximação 2^{n/2}. Usado em ataques a criptografia.",
            },
            new Formula
            {
                Id = "4_lt04", Nome = "LWE (Learning with Errors)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Reticulados",
                Expressao = "(A,b=As+e mod q);  A←ℤqⁿˣᵐ, s←ℤqⁿ, e←χ (ruído pequeno)",
                ExprTexto = "LWE: b=As+e mod q; distinguir de uniforme",
                Icone = "LWE",
                Descricao = "Learning With Errors: distinguir (A,As+e) de uniforme, ou recuperar s. Tão difícil quanto worst-case gap-SVP (Regev 2005). Base da maioria dos esquemas pós-quânticos (Kyber, FrodoKEM).",
                Criador = "Oded Regev",
                AnoOrigin = "2005",
            },
            new Formula
            {
                Id = "4_lt05", Nome = "Ring-LWE", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Reticulados",
                Expressao = "(a, b=a·s+e) ∈ Rq×Rq;  Rq = ℤq[x]/(xⁿ+1)",
                ExprTexto = "RLWE: b=as+e em Rq=ℤq[x]/(xⁿ+1)",
                Icone = "RLWE",
                Descricao = "Variante estruturada do LWE em anel de polinômios: chaves e operações O(n log n) vs O(n²). Base de Kyber/CRYSTALS. Segurança de ideal lattices. Lyubashevsky, Peikert, Regev (2010).",
            },
            new Formula
            {
                Id = "4_lt06", Nome = "SIS (Short Integer Solution)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Reticulados",
                Expressao = "Dado A∈ℤqⁿˣᵐ, encontrar x≠0 com Ax=0 mod q, ‖x‖≤β",
                ExprTexto = "SIS: Ax=0 mod q, ‖x‖≤β",
                Icone = "SIS",
                Descricao = "Encontrar vetor curto no kernel de A. Base de funções hash resistentes a colisão e esquemas de assinatura (Dilithium). Worst-case hardness: equivalente a SVP em reticulados aleatórios.",
                Criador = "Miklós Ajtai",
                AnoOrigin = "1996",
            },
            new Formula
            {
                Id = "4_lt07", Nome = "Redução de Base LLL", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Reticulados",
                Expressao = "LLL: encontra base reduzida com ‖b₁‖ ≤ 2^{(n-1)/2}λ₁;  tempo O(n⁵log³B)",
                ExprTexto = "LLL: ‖b₁‖≤2^{(n−1)/2}λ₁; polinomial",
                Icone = "LLL",
                Descricao = "Algoritmo polinomial de redução de base: encontra vetores 'razoavelmente curtos' (fator 2^{n/2} do ótimo). Usado para quebrar esquemas de baixa dimensão e em ataques a RSA com chave mal-escolhida.",
                Criador = "Lenstra / Lenstra / Lovász",
                AnoOrigin = "1982",
            },
            // 24.2 Esquemas Pós-Quânticos
            new Formula
            {
                Id = "4_pq01", Nome = "CRYSTALS-Kyber (ML-KEM)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Esquemas PQC",
                Expressao = "KEM baseado em Module-LWE; NIST padrão (FIPS 203)",
                ExprTexto = "Kyber: Module-LWE; FIPS 203 (ML-KEM)",
                Icone = "Kyber",
                Descricao = "KEM selecionado pelo NIST para padronização: encapsulamento de chave baseado em Module-LWE. Kyber-768: 128-bit segurança clássica. Chave pública ~1KB, ciphertext ~1KB. Usado em TLS 1.3 híbrido.",
            },
            new Formula
            {
                Id = "4_pq02", Nome = "CRYSTALS-Dilithium (ML-DSA)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Esquemas PQC",
                Expressao = "Assinatura baseada em Module-LWE + Fiat-Shamir; NIST FIPS 204",
                ExprTexto = "Dilithium: Module-LWE; FIPS 204 (ML-DSA)",
                Icone = "Dil",
                Descricao = "Assinatura digital selecionada pelo NIST: Fiat-Shamir com abortos sobre Module-LWE. Dilithium3: assinatura ~2.4KB, chave pública ~1.9KB. Substituição de RSA/ECDSA para era pós-quântica.",
            },
            new Formula
            {
                Id = "4_pq03", Nome = "FALCON", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Esquemas PQC",
                Expressao = "Assinatura NTRU lattice + Gaussian sampling; menor assinatura",
                ExprTexto = "FALCON: NTRU + Gaussian; sig ~666B",
                Icone = "FAL",
                Descricao = "Assinatura baseada em NTRU lattices com amostragem gaussiana (hash-and-sign). FALCON-512: assinatura ~666 bytes (menor que Dilithium). Complexidade: amostragem em tempo constante (side-channel).",
            },
            new Formula
            {
                Id = "4_pq04", Nome = "SPHINCS+ (SLH-DSA)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Esquemas PQC",
                Expressao = "Assinatura hash-based (stateless); FIPS 205",
                ExprTexto = "SPHINCS+: hash-based; FIPS 205 (SLH-DSA)",
                Icone = "SPH",
                Descricao = "Assinatura baseada apenas em funções hash (sem suposições algébricas): hyper-tree de WOTS+/FORS. Stateless (vs XMSS stateful). Assinatura ~17-49KB (grande), mas segurança conservadora.",
            },
            new Formula
            {
                Id = "4_pq05", Nome = "McEliece (Cód. Corretores)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Esquemas PQC",
                Expressao = "c = mG' + e;  G' = SGP (scrambled Goppa code)",
                ExprTexto = "c = mG'+e; G'=SGP (McEliece)",
                Icone = "McE",
                Descricao = "Criptosistema baseado em codificação (1978!): chave pública = gerador de código aleatório, decodificação privada via código Goppa. Chave pública grande (~1MB) mas IND-CCA2. Candidato alternativo NIST.",
                Criador = "Robert McEliece",
                AnoOrigin = "1978",
            },
            new Formula
            {
                Id = "4_pq06", Nome = "Algoritmo de Shor", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Motivação Quântica",
                Expressao = "Fatoração em tempo O((log N)³) quântico → RSA, ECC quebrados",
                ExprTexto = "Shor: O((logN)³) → RSA,ECC inseguros",
                Icone = "Shor",
                Descricao = "Motivo da PQC: computador quântico fatoraria e resolveria log discreto em tempo polinomial. RSA-2048 → ~4000 qubits lógicos. Timeline incerta: 2030s-2040s? Harvest-now-decrypt-later motiva migração já.",
                Criador = "Peter Shor",
                AnoOrigin = "1994",
            },
            new Formula
            {
                Id = "4_pq07", Nome = "Complexidade de Grover (Busca)", Categoria = "Criptografia Pós-Quântica", SubCategoria = "Motivação Quântica",
                Expressao = "Busca em N itens: O(√N) quântico vs O(N) clássico",
                ExprTexto = "Grover: O(√N) busca → dobra chave simétrica",
                Icone = "Grov",
                Descricao = "Aceleração quadrática genérica: AES-128 → 64 bits de segurança quântica. Solução: AES-256 para 128 bits pós-quântica. Impacto menor que Shor; criptografia simétrica sobrevive com chaves maiores.",
                Criador = "Lov Grover",
                AnoOrigin = "1996",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 25. TEORIA DA INFORMAÇÃO QUÂNTICA AVANÇADA
    // ─────────────────────────────────────────────────────
    private void AdicionarInfoQuanticaAvancada()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_qi01", Nome = "Operadores de Kraus", Categoria = "Informação Quântica Avançada", SubCategoria = "Canais Quânticos",
                Expressao = "ε(ρ) = Σₖ EₖρEₖ†;  Σₖ Eₖ†Eₖ = I",
                ExprTexto = "ε(ρ) = ΣₖEₖρEₖ†; ΣEₖ†Eₖ=I",
                Icone = "Kraus",
                Descricao = "Representação operador-soma de canal quântico completamente positivo e preservador de traço (CPTP). Eₖ = operadores de Kraus. Toda evolução aberta pode ser escrita assim (Stinespring).",
            },
            new Formula
            {
                Id = "4_qi02", Nome = "Canal Despolarizante", Categoria = "Informação Quântica Avançada", SubCategoria = "Canais Quânticos",
                Expressao = "ε(ρ) = (1-p)ρ + p·I/d",
                ExprTexto = "ε(ρ) = (1−p)ρ+pI/d",
                Icone = "dep",
                Descricao = "Modelo de ruído universal: com prob. p substitui por estado maximamente misturado I/d. Capacidade clássica: 1-H₂(p) + p·log(d-1). Limiar de correção: p < (d-1)/d.",
            },
            new Formula
            {
                Id = "4_qi03", Nome = "Canal de Amortecimento de Amplitude", Categoria = "Informação Quântica Avançada", SubCategoria = "Canais Quânticos",
                Expressao = "E₀ = [[1,0],[0,√(1-γ)]];  E₁ = [[0,√γ],[0,0]]",
                ExprTexto = "E₀=diag(1,√(1−γ)), E₁=√γ|0⟩⟨1|",
                Icone = "amp",
                Descricao = "Modelo físico de emissão espontânea: |1⟩ decai para |0⟩ com prob. γ. Tempo de relaxação T₁: γ=1-e^{-t/T₁}. Canal não-unitário mais importante em qubits supercondutores.",
            },
            new Formula
            {
                Id = "4_qi04", Nome = "Canal de Defasamento (Dephasing)", Categoria = "Informação Quântica Avançada", SubCategoria = "Canais Quânticos",
                Expressao = "ε(ρ) = (1-p)ρ + pZρZ;  Z=diag(1,-1)",
                ExprTexto = "ε(ρ) = (1−p)ρ+pZρZ",
                Icone = "deph",
                Descricao = "Perda de coerência sem perda de energia: off-diagonais multiplicadas por (1-2p). Tempo T₂: p=½(1-e^{-t/T₂}). T₂ ≤ 2T₁. Erro dominante em qubits supercondutores atuais.",
            },
            new Formula
            {
                Id = "4_qi05", Nome = "Capacidade de Holevo", Categoria = "Informação Quântica Avançada", SubCategoria = "Capacidade",
                Expressao = "χ = S(Σᵢpᵢρᵢ) - Σᵢpᵢ S(ρᵢ) ≥ I(X:Y)",
                ExprTexto = "χ = S(Σpᵢρᵢ)−ΣpᵢS(ρᵢ)",
                Icone = "χ",
                Descricao = "Limite superior da informação clássica extraível de ensemble quântico {pᵢ,ρᵢ}: máximo de I(X:Y) sobre todas as medidas. HSW theorem: alcançável com codificação de produto.",
                Criador = "Alexander Holevo",
                AnoOrigin = "1973",
            },
            new Formula
            {
                Id = "4_qi06", Nome = "Informação Coerente", Categoria = "Informação Quântica Avançada", SubCategoria = "Capacidade",
                Expressao = "I_c(ρ,N) = S(N(ρ)) - S((N⊗I)|Φ⟩)",
                ExprTexto = "Ic = S(N(ρ))−S(complementar)",
                Icone = "Ic",
                Descricao = "Capacidade quântica Q = max_ρ I_c: taxa máxima de transmissão quântica confiável. Requer regularização (super-aditiva!): Q = lim Q^(n)/n. Hashing bound: Q ≥ I_c de uso único.",
            },
            new Formula
            {
                Id = "4_qi07", Nome = "Código Estabilizador", Categoria = "Informação Quântica Avançada", SubCategoria = "Correção de Erros Quânticos",
                Expressao = "[[n,k,d]]: n qubits físicos → k lógicos, distância d; corrige ⌊(d-1)/2⌋",
                ExprTexto = "[[n,k,d]]: corrige ⌊(d−1)/2⌋ erros",
                Icone = "stab",
                Descricao = "Códigos definidos por subgrupo estabilizador S do grupo de Pauli: code space = autoespaço +1 comum. Detecção: erros no normalizador mas fora de S. Steane [[7,1,3]], Shor [[9,1,3]].",
                Criador = "Daniel Gottesman",
                AnoOrigin = "1997",
            },
            new Formula
            {
                Id = "4_qi08", Nome = "Código de Superfície", Categoria = "Informação Quântica Avançada", SubCategoria = "Correção de Erros Quânticos",
                Expressao = "[[d²+(d-1)², 1, d]] em grid 2D com estabilizadores X-plaqueta, Z-estrela",
                ExprTexto = "Surface code: [[O(d²),1,d]] em 2D",
                Icone = "surf",
                Descricao = "Código topológico em grade 2D: operações locais (próximos vizinhos). Threshold ~1% (mais alto entre códigos). d~20-30 para computação fault-tolerant. Google/IBM/Microsoft usam. O(d²) qubits físicos por lógico.",
            },
            new Formula
            {
                Id = "4_qi09", Nome = "Código Tórico", Categoria = "Informação Quântica Avançada", SubCategoria = "Correção de Erros Quânticos",
                Expressao = "[[2d², 2, d]] no torus;  operadores lógicos: loops não-contráteis",
                ExprTexto = "Toric code: [[2d²,2,d]]; k=2 no torus",
                Icone = "toric",
                Descricao = "Primeiro código topológico (Kitaev 1997): em torus codifica k=2 qubits lógicos. Anyons como excitações (violações de estabilizador). Decodificação ótima: matching de peso mínimo.",
                Criador = "Alexei Kitaev",
                AnoOrigin = "1997",
            },
            new Formula
            {
                Id = "4_qi10", Nome = "Threshold Theorem (FT)", Categoria = "Informação Quântica Avançada", SubCategoria = "Correção de Erros Quânticos",
                Expressao = "Se p_phys < p_th, computação quântica arbitrariamente longa é possível",
                ExprTexto = "p < pth → computação FT arbitrária",
                Icone = "FT",
                Descricao = "Teorema do threshold: se taxa de erro por gate p < p_th (~10⁻² a 10⁻⁴), concatenação de códigos permite computação de comprimento arbitrário. Overhead polilogarítmico. Aharonov & Ben-Or (1997).",
            },
            new Formula
            {
                Id = "4_qi11", Nome = "Emaranhamento Multipartido (GHZ)", Categoria = "Informação Quântica Avançada", SubCategoria = "Emaranhamento",
                Expressao = "|GHZ_n⟩ = (|0⟩^⊗n + |1⟩^⊗n)/√2",
                ExprTexto = "|GHZ⟩ = (|0⟩ⁿ+|1⟩ⁿ)/√2",
                Icone = "GHZ",
                Descricao = "Estado GHZ n-partido: maximamente emaranhado (entanglement genuinamente multipartido). Traço parcial → estado misturado. Usado em metrologia quântica (Heisenberg scaling), secret sharing.",
            },
            new Formula
            {
                Id = "4_qi12", Nome = "Entropia de Emaranhamento", Categoria = "Informação Quântica Avançada", SubCategoria = "Emaranhamento",
                Expressao = "E(|ψ⟩_{AB}) = S(ρ_A) = -Σᵢ λᵢ log λᵢ",
                ExprTexto = "E = S(ρA) = −Σλᵢlogλᵢ",
                Icone = "E",
                Descricao = "Medida canônica de emaranhamento para estados puros bipartidos: entropia de von Neumann da reduzida. Para |ψ⟩=Σ√λᵢ|iA⟩|iB⟩ (Schmidt), E = S(ρA). E=0 (produto) a log d (Bell).",
            },
            new Formula
            {
                Id = "4_qi13", Nome = "Distilação de Emaranhamento", Categoria = "Informação Quântica Avançada", SubCategoria = "Emaranhamento",
                Expressao = "ρ^⊗n → m pares Bell por LOCC;  taxa D(ρ) = lim m/n",
                ExprTexto = "D(ρ) = m/n (pares Bell por cópia, LOCC)",
                Icone = "dist",
                Descricao = "Concentrar emaranhamento: converter n cópias de ρ misto em m pares de Bell puros via LOCC. D(ρ) = taxa distilável ≤ E(ρ). Bound entangled: emaranhado mas D=0 (Horodecki 1998).",
            },
        ]);
    }
}
