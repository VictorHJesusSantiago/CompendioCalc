using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 5 — PARTE IV: COMPUTAÇÃO (Seções 12-15)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 12. ALGORITMOS DE APROXIMAÇÃO E COMPLEXIDADE DE CIRCUITOS
    // ─────────────────────────────────────────────────────
    private void AdicionarAlgoritmosAproximacao()
    {
        _formulas.AddRange([
            // 12.1 Algoritmos de Aproximação
            new Formula
            {
                Id = "5_ap01", Nome = "Razão de Aproximação", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "ρ = max(C(x)/OPT(x), OPT(x)/C(x))",
                ExprTexto = "ρ = max(C/OPT, OPT/C)",
                Icone = "ρ",
                Descricao = "Razão de aproximação: pior caso da razão entre solução do algoritmo e ótimo. ρ-aproximação garante solução dentro de fator ρ do ótimo.",
            },
            new Formula
            {
                Id = "5_ap02", Nome = "Vertex Cover (2-aprox.)", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "Matching maximal → |C| ≤ 2·OPT",
                ExprTexto = "VC: matching maximal → 2-aprox",
                Icone = "VC",
                Descricao = "Vertex Cover 2-aproximação: encontre matching maximal e tome ambos vértices de cada aresta. Simples, 2-aproximação. Melhorar para 2-ε é aberto.",
            },
            new Formula
            {
                Id = "5_ap03", Nome = "TSP Métrico (Christofides)", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "MST + matching mínimo de ímpares → 3/2-aprox",
                ExprTexto = "Christofides: 3/2-aprox para TSP métrico",
                Icone = "TSP",
                Descricao = "Algoritmo de Christofides-Serdyukov para TSP métrico: MST + matching perfeito de mínimo peso nos vértices de grau ímpar. Razão 3/2.",
                Criador = "Nicos Christofides",
                AnoOrigin = "1976",
            },
            new Formula
            {
                Id = "5_ap04", Nome = "Set Cover (ln n)", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "Set Cover guloso: razão H(n) = Σ_{k=1}^n 1/k ≈ ln n",
                ExprTexto = "Set Cover guloso: Hn ≈ ln(n)-aprox",
                Icone = "SC",
                Descricao = "Set Cover: algoritmo guloso (escolha conjunto que cobre mais) atinge razão H(n)≈ln(n). Essencialmente ótimo sob P≠NP.",
            },
            new Formula
            {
                Id = "5_ap05", Nome = "FPTAS (Knapsack)", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "(1-ε)-aprox em tempo poly(n, 1/ε)",
                ExprTexto = "FPTAS: (1-ε)-aprox em O(n²/ε)",
                Icone = "FP",
                Descricao = "FPTAS para Knapsack: escala e arredonda lucros, aplica PD. (1-ε)-aproximação em tempo polinomial em n e 1/ε. Melhor possível para NP-hard.",
            },
            new Formula
            {
                Id = "5_ap06", Nome = "Relaxação LP + Arredondamento", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "LP(I) ≤ OPT(I);  arredondamento → solução inteira",
                ExprTexto = "LP relax → arredondamento ≤ ρ·OPT",
                Icone = "LP",
                Descricao = "Relaxação LP: resolve versão contínua (LP) do problema inteiro. Gap de integralidade limita a razão. Arredondamento probabilístico ou determinístico.",
            },
            new Formula
            {
                Id = "5_ap07", Nome = "Inaprogramabilidade (PCP)", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "PCP: NP = PCP[O(log n), O(1)]",
                ExprTexto = "NP = PCP[logn, O(1)]",
                Icone = "PCP",
                Descricao = "Teorema PCP: toda prova NP pode ser verificada lendo O(1) bits aleatórios. Implica inaproximabilidade de MAX-3SAT dentro de fator 7/8+ε.",
            },
            new Formula
            {
                Id = "5_ap08", Nome = "Unique Games Conjecture", Categoria = "Algoritmos de Aproximação", SubCategoria = "Algoritmos de Aproximação",
                Expressao = "UGC → razor ótimas para muitos problemas",
                ExprTexto = "UGC: limites de inaproximabilidade apertados",
                Icone = "UG",
                Descricao = "Conjectura de Jogos Únicos (Khot 2002): se verdadeira, determina a razão ótima de aproximação para muitos problemas (Vertex Cover, MAX-CUT, etc.).",
                Criador = "Subhash Khot",
                AnoOrigin = "2002",
            },

            // 12.2 Complexidade de Circuitos
            new Formula
            {
                Id = "5_cc01", Nome = "Circuito Booleano", Categoria = "Algoritmos de Aproximação", SubCategoria = "Complexidade de Circuitos",
                Expressao = "C: {0,1}ⁿ → {0,1};  portas AND, OR, NOT",
                ExprTexto = "C: {0,1}ⁿ→{0,1}; AND,OR,NOT",
                Icone = "⊞",
                Descricao = "Circuito booleano: DAG de portas lógicas. Tamanho = nº de portas. Profundidade = maior caminho entrada-saída. Modelo não-uniforme de computação.",
            },
            new Formula
            {
                Id = "5_cc02", Nome = "P/poly", Categoria = "Algoritmos de Aproximação", SubCategoria = "Complexidade de Circuitos",
                Expressao = "P/poly: problemas com circuitos de tamanho polinomial",
                ExprTexto = "P/poly: circuitos poly(n)",
                Icone = "P/",
                Descricao = "P/poly: classe de linguagens decidíveis por famílias de circuitos de tamanho polinomial. Contém P e linguagens unárias. BPP ⊂ P/poly.",
            },
            new Formula
            {
                Id = "5_cc03", Nome = "Limiar de Shannon", Categoria = "Algoritmos de Aproximação", SubCategoria = "Complexidade de Circuitos",
                Expressao = "Função genérica requer Ω(2ⁿ/n) portas",
                ExprTexto = "Quase toda f requer ~2ⁿ/n portas",
                Icone = "2ⁿ",
                Descricao = "Resultado de Shannon (1949): quase toda função booleana requer circuitos de tamanho exponencial. Argumento de contagem. Funções 'difíceis' são genéricas.",
                Criador = "Claude Shannon",
                AnoOrigin = "1949",
            },
            new Formula
            {
                Id = "5_cc04", Nome = "AC⁰ e Paridade", Categoria = "Algoritmos de Aproximação", SubCategoria = "Complexidade de Circuitos",
                Expressao = "PARITY ∉ AC⁰  (profundidade constante, fan-in ilimitado)",
                ExprTexto = "PARITY ∉ AC⁰",
                Icone = "AC⁰",
                Descricao = "AC⁰: circuitos de profundidade constante e fan-in ilimitado, tamanho polinomial. Não computa paridade (Furst-Saxe-Sipser / Håstad).",
            },
            new Formula
            {
                Id = "5_cc05", Nome = "Classe NC", Categoria = "Algoritmos de Aproximação", SubCategoria = "Complexidade de Circuitos",
                Expressao = "NCᵏ: profundidade O(logᵏ n), tamanho poly(n), fan-in 2",
                ExprTexto = "NCᵏ: prof O(logᵏn), tam poly(n)",
                Icone = "NC",
                Descricao = "NC (Nick's Class): problemas eficientemente paralelizáveis. NC¹⊂NC²⊂...⊂P. NC = P? é questão aberta fundamental (P-completude).",
            },
            new Formula
            {
                Id = "5_cc06", Nome = "Fórmula vs Circuito", Categoria = "Algoritmos de Aproximação", SubCategoria = "Complexidade de Circuitos",
                Expressao = "Fórmula: fan-out=1 (árvore); L(f) vs C(f)",
                ExprTexto = "Fórmula ⊆ Circuito; L(f)≥C(f)",
                Icone = "F≤C",
                Descricao = "Fórmula: circuito em árvore (cada porta usada uma vez). Tamanho de fórmula L(f) ≥ tamanho de circuito C(f). Separação parcial com Andreev.",
            },
            new Formula
            {
                Id = "5_cc07", Nome = "Comunicação e Circuitos", Categoria = "Algoritmos de Aproximação", SubCategoria = "Complexidade de Circuitos",
                Expressao = "Complexidade de comunicação → limitantes inferiores de circuitos",
                ExprTexto = "Comunic. → lower bounds de circuitos",
                Icone = "CC",
                Descricao = "Conexão: limitantes inferiores em complexidade de comunicação implicam limitantes para profundidade de circuitos. Técnica de Karchmer-Wigderson.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 13. REDES DE COMPUTADORES E PROTOCOLOS
    // ─────────────────────────────────────────────────────
    private void AdicionarRedesComputadores()
    {
        _formulas.AddRange([
            // 13.1 Fundamentos e Modelo OSI
            new Formula
            {
                Id = "5_rc01", Nome = "Modelo OSI (7 Camadas)", Categoria = "Redes de Computadores", SubCategoria = "Fundamentos de Redes",
                Expressao = "Física → Enlace → Rede → Transporte → Sessão → Apresentação → Aplicação",
                ExprTexto = "7 camadas: Fís/Enl/Rede/Trans/Ses/Apr/Apl",
                Icone = "OSI",
                Descricao = "Modelo OSI: arquitetura de referência com 7 camadas. Cada camada provê serviços à superior. Encapsulamento de protocolos em stack.",
            },
            new Formula
            {
                Id = "5_rc02", Nome = "TCP/IP (4 Camadas)", Categoria = "Redes de Computadores", SubCategoria = "Fundamentos de Redes",
                Expressao = "Enlace → Internet → Transporte → Aplicação",
                ExprTexto = "4 camadas: Enlace/Internet/Transporte/Aplicação",
                Icone = "TCP",
                Descricao = "Modelo TCP/IP: pilha prática de 4 camadas. IP na camada Internet (roteamento), TCP/UDP no transporte, HTTP/DNS/etc na aplicação.",
            },
            new Formula
            {
                Id = "5_rc03", Nome = "Lei de Shannon (Canal)", Categoria = "Redes de Computadores", SubCategoria = "Fundamentos de Redes",
                Expressao = "C = B·log₂(1 + SNR)",
                ExprTexto = "C = B·log₂(1+SNR) bits/s",
                Icone = "C",
                Descricao = "Capacidade de Shannon: taxa máxima de transmissão sem erro em canal com ruído. B=bandwidth (Hz), SNR=signal-to-noise ratio.",
                Criador = "Claude Shannon",
                AnoOrigin = "1948",
            },
            new Formula
            {
                Id = "5_rc04", Nome = "Throughput e Latência", Categoria = "Redes de Computadores", SubCategoria = "Fundamentos de Redes",
                Expressao = "Delay = prop + trans + queue + proc;  BDP = BW × RTT",
                ExprTexto = "Delay = dprop+dtrans+dqueue+dproc",
                Icone = "D",
                Descricao = "Componentes de atraso: propagação (distância/velocidade), transmissão (bits/taxa), fila e processamento. BDP = produto largura-atraso.",
            },
            new Formula
            {
                Id = "5_rc05", Nome = "CSMA/CD", Categoria = "Redes de Computadores", SubCategoria = "Fundamentos de Redes",
                Expressao = "Carrier Sense; enviar; detectar colisão → backoff exponencial",
                ExprTexto = "Listen→Send→Detect collision→Backoff",
                Icone = "CD",
                Descricao = "CSMA/CD: protocolo de acesso ao meio da Ethernet. Escuta antes de transmitir, detecta colisão e aplica backoff exponencial binário.",
            },
            new Formula
            {
                Id = "5_rc06", Nome = "Algoritmo de Dijkstra (OSPF)", Categoria = "Redes de Computadores", SubCategoria = "Fundamentos de Redes",
                Expressao = "Shortest-path: d[v] = min(d[v], d[u]+w(u,v))",
                ExprTexto = "d[v] = min(d[v], d[u]+w(u,v))",
                Icone = "SPF",
                Descricao = "Dijkstra para roteamento OSPF (link-state): calcula árvore de menores caminhos. Complexidade O((V+E)logV) com heap. Cada roteador tem visão global.",
            },

            // 13.2 Protocolos de Transporte
            new Formula
            {
                Id = "5_rc07", Nome = "Controle de Congestionamento TCP", Categoria = "Redes de Computadores", SubCategoria = "Protocolos de Transporte",
                Expressao = "AIMD: cwnd+1 por RTT (aditivo); cwnd/2 em perda (multiplicativo)",
                ExprTexto = "AIMD: +1/RTT; /2 em perda",
                Icone = "cwnd",
                Descricao = "TCP AIMD (Additive Increase, Multiplicative Decrease): janela cresce linearmente, cai pela metade em perda. Convergência a fair-share provada.",
            },
            new Formula
            {
                Id = "5_rc08", Nome = "Slow Start", Categoria = "Redes de Computadores", SubCategoria = "Protocolos de Transporte",
                Expressao = "cwnd *= 2 por RTT até ssthresh",
                ExprTexto = "cwnd dobra/RTT até ssthresh",
                Icone = "SS",
                Descricao = "TCP Slow Start: crescimento exponencial da janela de congestionamento até atingir limiar ssthresh, depois cresce linearmente (congestion avoidance).",
            },
            new Formula
            {
                Id = "5_rc09", Nome = "Throughput TCP (Mathis)", Categoria = "Redes de Computadores", SubCategoria = "Protocolos de Transporte",
                Expressao = "Throughput ≤ MSS / (RTT·√p)",
                ExprTexto = "T ≈ MSS/(RTT·√p)",
                Icone = "T",
                Descricao = "Fórmula de Mathis: throughput TCP limitado por MSS/(RTT·√p), onde p=taxa de perda. Mostra dependência inversa em latência e raiz de perda.",
            },
            new Formula
            {
                Id = "5_rc10", Nome = "TCP Fast Retransmit", Categoria = "Redes de Computadores", SubCategoria = "Protocolos de Transporte",
                Expressao = "3 ACKs duplicados → retransmissão imediata (sem timeout)",
                ExprTexto = "3 dup ACKs → retransmissão rápida",
                Icone = "FR",
                Descricao = "Fast Retransmit: ao receber 3 ACKs duplicados, retransmite segmento sem esperar timeout. Fast Recovery: ssthresh=cwnd/2 e continua.",
            },
            new Formula
            {
                Id = "5_rc11", Nome = "BBR", Categoria = "Redes de Computadores", SubCategoria = "Protocolos de Transporte",
                Expressao = "BTLBw × RTprop;  estima bandwidth e RTT mínimo",
                ExprTexto = "rate = BTLBw × RTprop",
                Icone = "BBR",
                Descricao = "BBR (Bottleneck Bandwidth and RTT): congestion control do Google. Modela enlace gargalo por bandwidth e RTT. Melhor que CUBIC em WANs longas.",
                Criador = "Google / Neal Cardwell",
                AnoOrigin = "2016",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 14. COMPILADORES, AUTÔMATOS E GRAMÁTICAS FORMAIS
    // ─────────────────────────────────────────────────────
    private void AdicionarCompiladoresAutomatos()
    {
        _formulas.AddRange([
            // 14.1 Gramáticas e Autômatos
            new Formula
            {
                Id = "5_ch01", Nome = "Hierarquia de Chomsky", Categoria = "Compiladores e Autômatos", SubCategoria = "Gramáticas e Autômatos",
                Expressao = "Regular ⊂ Livre-Contexto ⊂ Sensível-Contexto ⊂ Recursivamente Enumerável",
                ExprTexto = "Tipo 3⊂Tipo 2⊂Tipo 1⊂Tipo 0",
                Icone = "CH",
                Descricao = "Hierarquia de Chomsky: classifica gramáticas/linguagens em 4 tipos com poder expressivo crescente e autômatos correspondentes.",
                Criador = "Noam Chomsky",
                AnoOrigin = "1956",
            },
            new Formula
            {
                Id = "5_ch02", Nome = "AFD (Autômato Finito Determinístico)", Categoria = "Compiladores e Autômatos", SubCategoria = "Gramáticas e Autômatos",
                Expressao = "(Q, Σ, δ, q₀, F);  δ: Q×Σ → Q",
                ExprTexto = "AFD: (Q,Σ,δ,q₀,F); δ determinístico",
                Icone = "AFD",
                Descricao = "AFD: máquina de estados finitos determinística. Reconhece linguagens regulares. Equivalente a expressões regulares (Kleene).",
            },
            new Formula
            {
                Id = "5_ch03", Nome = "Lema do Bombeamento (Regulares)", Categoria = "Compiladores e Autômatos", SubCategoria = "Gramáticas e Autômatos",
                Expressao = "∃p: w∈L, |w|≥p → w=xyz, |xy|≤p, |y|>0, ∀i xyⁱz∈L",
                ExprTexto = "w=xyz; |xy|≤p, y≠ε; xyⁱz∈L ∀i≥0",
                Icone = "PL",
                Descricao = "Pumping Lemma para linguagens regulares: toda palavra suficientemente longa tem substring que pode ser 'bombeada'. Prova que certas linguagens não são regulares.",
            },
            new Formula
            {
                Id = "5_ch04", Nome = "Autômato de Pilha (PDA)", Categoria = "Compiladores e Autômatos", SubCategoria = "Gramáticas e Autômatos",
                Expressao = "(Q, Σ, Γ, δ, q₀, Z₀, F);  δ: Q×(Σ∪{ε})×Γ → P(Q×Γ*)",
                ExprTexto = "PDA: AFD + pilha; equivale a CFG",
                Icone = "PDA",
                Descricao = "Autômato de pilha: autômato finito com pilha auxiliar. Reconhece linguagens livres de contexto. Equivale a gramáticas livres de contexto (CFG).",
            },
            new Formula
            {
                Id = "5_ch05", Nome = "Gramática Livre de Contexto (CFG)", Categoria = "Compiladores e Autômatos", SubCategoria = "Gramáticas e Autômatos",
                Expressao = "G = (V, Σ, R, S);  A → α  (A∈V, α∈(V∪Σ)*)",
                ExprTexto = "G=(V,Σ,R,S); A→α",
                Icone = "CFG",
                Descricao = "CFG: regras de produção A→α. Cada regra substitui um não-terminal. Descreve linguagens de programação, XML, etc. Base de parsers.",
            },
            new Formula
            {
                Id = "5_ch06", Nome = "CYK (Parsing)", Categoria = "Compiladores e Autômatos", SubCategoria = "Gramáticas e Autômatos",
                Expressao = "CNF + programação dinâmica: O(n³|G|)",
                ExprTexto = "CYK: O(n³|G|) para CFG em CNF",
                Icone = "CYK",
                Descricao = "Algoritmo de Cocke-Younger-Kasami: parsing bottom-up para CFG em forma normal de Chomsky. Programação dinâmica em O(n³) no comprimento da string.",
            },

            // 14.2 Compiladores
            new Formula
            {
                Id = "5_ch07", Nome = "Análise Léxica (Scanner)", Categoria = "Compiladores e Autômatos", SubCategoria = "Compiladores",
                Expressao = "Regex → NFA → DFA → tabela de transição",
                ExprTexto = "Regex→NFA→DFA→scanner",
                Icone = "Lex",
                Descricao = "Análise léxica: converte cadeia de caracteres em tokens usando autômatos finitos. Ferramentas: lex/flex. Baseada em expressões regulares.",
            },
            new Formula
            {
                Id = "5_ch08", Nome = "Parser LL(1)", Categoria = "Compiladores e Autômatos", SubCategoria = "Compiladores",
                Expressao = "Top-down, preditivo;  FIRST/FOLLOW sets",
                ExprTexto = "LL(1): top-down com FIRST/FOLLOW",
                Icone = "LL",
                Descricao = "Parser LL(1): análise sintática top-down preditivo. Lê da esquerda, produz derivação esquerda, 1 token de lookahead. Requer gramática não-ambígua.",
            },
            new Formula
            {
                Id = "5_ch09", Nome = "Parser LR(1)", Categoria = "Compiladores e Autômatos", SubCategoria = "Compiladores",
                Expressao = "Bottom-up, shift-reduce;  estados LR(1) com items",
                ExprTexto = "LR(1): bottom-up shift-reduce",
                Icone = "LR",
                Descricao = "Parser LR(1): análise bottom-up com autômato de items. Mais poderoso que LL(1). Variantes: SLR, LALR(1) (usado em yacc/bison).",
            },
            new Formula
            {
                Id = "5_ch10", Nome = "SSA (Static Single Assignment)", Categoria = "Compiladores e Autômatos", SubCategoria = "Compiladores",
                Expressao = "Cada variável definida exatamente uma vez;  φ-funções nos merges",
                ExprTexto = "SSA: cada var def. 1×; φ em joins",
                Icone = "SSA",
                Descricao = "SSA: representação intermediária onde cada variável é atribuída uma vez. Simplifica otimizações. φ-funções selecionam valores em pontos de junção do CFG.",
            },
            new Formula
            {
                Id = "5_ch11", Nome = "Alocação de Registradores (Graph Coloring)", Categoria = "Compiladores e Autômatos", SubCategoria = "Compiladores",
                Expressao = "Grafo de interferência;  k-coloração ↔ k registradores",
                ExprTexto = "k-coloração do grafo de interferência",
                Icone = "Reg",
                Descricao = "Alocação de registradores via coloração de grafos: variáveis que coexistem formam arestas. k-coloração atribui k registradores. NP-hard, heurísticas eficazes.",
            },
            new Formula
            {
                Id = "5_ch12", Nome = "Fases do Compilador", Categoria = "Compiladores e Autômatos", SubCategoria = "Compiladores",
                Expressao = "Léxico → Sintático → Semântico → IR → Otimização → Geração de Código",
                ExprTexto = "Lex→Parse→Semantic→IR→Opt→CodeGen",
                Icone = "CC",
                Descricao = "Pipeline clássico de compilação: análise léxica, sintática, semântica, geração de representação intermediária, otimizações e geração de código final.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 15. COMPUTAÇÃO PARALELA E DISTRIBUÍDA
    // ─────────────────────────────────────────────────────
    private void AdicionarComputacaoParalela()
    {
        _formulas.AddRange([
            // 15.1 Leis Fundamentais
            new Formula
            {
                Id = "5_pa01", Nome = "Lei de Amdahl", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "S(p) = 1/(s + (1-s)/p);  s=fração serial",
                ExprTexto = "S(p) = 1/(s+(1-s)/p)",
                Icone = "Am",
                Descricao = "Lei de Amdahl: speedup máximo limitado pela fração serial s. Com p→∞, S→1/s. 10% serial → speedup máximo 10×.",
                Criador = "Gene Amdahl",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "5_pa02", Nome = "Lei de Gustafson", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "S(p) = (1-s)p + s;  escala o problema",
                ExprTexto = "S(p) = s+(1-s)p (scaled speedup)",
                Icone = "Gu",
                Descricao = "Lei de Gustafson: perspectiva de speedup escalado. Se o problema cresce com p, speedup é linear. Complementa Amdahl com visão otimista.",
                Criador = "John Gustafson",
                AnoOrigin = "1988",
            },
            new Formula
            {
                Id = "5_pa03", Nome = "Eficiência Paralela", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "E(p) = S(p)/p = T₁/(p·Tp);  ideal: E = 1",
                ExprTexto = "E(p) = S(p)/p = T₁/(pTp)",
                Icone = "E",
                Descricao = "Eficiência: fração do speedup linear atingido. E=1 ideal. Overhead paralelo (comunicação, sincronização, desequilíbrio) reduz E.",
            },
            new Formula
            {
                Id = "5_pa04", Nome = "Work-Span (Brent)", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "Tp ≥ max(T₁/p, T∞);  Tp ≤ T₁/p + T∞",
                ExprTexto = "T₁/p ≤ Tp ≤ T₁/p + T∞",
                Icone = "WS",
                Descricao = "Modelo Work-Span: T₁=trabalho total, T∞=profundidade (caminho crítico). Paralelismo=T₁/T∞. Teorema de Brent limita Tp.",
            },
            new Formula
            {
                Id = "5_pa05", Nome = "BSP (Bulk Synchronous Parallel)", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "Superstep: computação local + comunicação + barreira",
                ExprTexto = "BSP: comp + comm + barrier (supersteps)",
                Icone = "BSP",
                Descricao = "Modelo BSP: computação organizada em supersteps com computação local, comunicação global e barreira de sincronização. Análise de custo previsível.",
                Criador = "Leslie Valiant",
                AnoOrigin = "1990",
            },
            new Formula
            {
                Id = "5_pa06", Nome = "PRAM", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "EREW, CREW, CRCW;  p processadores, memória compartilhada",
                ExprTexto = "PRAM: EREW⊂CREW⊂CRCW",
                Icone = "P",
                Descricao = "PRAM: modelo teórico com memória compartilhada. EREW (exclusive read/write), CREW (concurrent read), CRCW (concurrent read/write). Simula algoritmos paralelos.",
            },
            new Formula
            {
                Id = "5_pa07", Nome = "MapReduce", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "Map: (k,v) → [(k',v')];  Reduce: (k',[v'₁,...]) → (k',v'')",
                ExprTexto = "Map(k,v)→(k',v'); Reduce(k',vs)→r",
                Icone = "MR",
                Descricao = "MapReduce: modelo de programação para processamento distribuído de dados massivos. Map produz pares chave-valor, Reduce agrega por chave.",
                Criador = "Jeffrey Dean / Sanjay Ghemawat",
                AnoOrigin = "2004",
            },
            new Formula
            {
                Id = "5_pa08", Nome = "Complexidade de Comunicação", Categoria = "Computação Paralela", SubCategoria = "Leis Fundamentais",
                Expressao = "Latência α, bandwidth 1/β;  T = α + nβ",
                ExprTexto = "Tcomm = α + nβ",
                Icone = "αβ",
                Descricao = "Modelo de comunicação ponto-a-ponto: α=latência (startup), β=inverso de bandwidth. Custo de enviar n palavras: α+nβ.",
            },

            // 15.2 Algoritmos Distribuídos
            new Formula
            {
                Id = "5_pa09", Nome = "Consenso (FLP)", Categoria = "Computação Paralela", SubCategoria = "Algoritmos Distribuídos",
                Expressao = "Impossível consenso determinístico com 1 falha em assíncrono",
                ExprTexto = "FLP: impossível consenso det. + 1 falha + assíncrono",
                Icone = "FLP",
                Descricao = "Resultado FLP (Fischer-Lynch-Paterson): impossibilidade de consenso determinístico em sistema assíncrono com pelo menos 1 falha de crash.",
                Criador = "Fischer / Lynch / Paterson",
                AnoOrigin = "1985",
            },
            new Formula
            {
                Id = "5_pa10", Nome = "Paxos", Categoria = "Computação Paralela", SubCategoria = "Algoritmos Distribuídos",
                Expressao = "Prepare(n) → Promise(n,v);  Accept(n,v) → Accepted",
                ExprTexto = "Paxos: Prepare→Promise→Accept→Accepted",
                Icone = "Pax",
                Descricao = "Paxos: protocolo de consenso tolerante a falhas de crash. Garante acordo com maioria de processos corretos. Base do Chubby/ZooKeeper/etcd.",
                Criador = "Leslie Lamport",
                AnoOrigin = "1989",
            },
            new Formula
            {
                Id = "5_pa11", Nome = "Raft", Categoria = "Computação Paralela", SubCategoria = "Algoritmos Distribuídos",
                Expressao = "Leader election → Log replication → Safety",
                ExprTexto = "Raft: Leader→LogRepl→Safety",
                Icone = "Raft",
                Descricao = "Raft: protocolo de consenso compreensível. Equivalente a Paxos em segurança mas mais intuitivo. Líder replicado com log ordenado.",
                Criador = "Diego Ongaro / John Ousterhout",
                AnoOrigin = "2014",
            },
            new Formula
            {
                Id = "5_pa12", Nome = "Relógios de Lamport", Categoria = "Computação Paralela", SubCategoria = "Algoritmos Distribuídos",
                Expressao = "C(a) < C(b) se a → b  (causalidade)",
                ExprTexto = "a→b ⟹ C(a)<C(b)",
                Icone = "⏰",
                Descricao = "Relógios lógicos de Lamport: ordem parcial de eventos distribuídos. Incrementa em evento local; max+1 ao receber. Capta relação happens-before.",
                Criador = "Leslie Lamport",
                AnoOrigin = "1978",
            },
            new Formula
            {
                Id = "5_pa13", Nome = "Relógios Vetoriais", Categoria = "Computação Paralela", SubCategoria = "Algoritmos Distribuídos",
                Expressao = "V[i] = max(V[i], V'[i])  em recepção",
                ExprTexto = "V[i]=max(V[i],V'[i]) (merge vetorial)",
                Icone = "V",
                Descricao = "Relógios vetoriais: captam causalidade completa. V(a) < V(b) ↔ a→b. Detectam concorrência (eventos incomparáveis). Usados em BD distribuído.",
            },
            new Formula
            {
                Id = "5_pa14", Nome = "Teorema CAP", Categoria = "Computação Paralela", SubCategoria = "Algoritmos Distribuídos",
                Expressao = "Consistência + Disponibilidade + Tolerância a partições: escolha 2 de 3",
                ExprTexto = "CAP: escolha 2 de {C,A,P}",
                Icone = "CAP",
                Descricao = "Teorema CAP (Brewer): em presença de partição de rede, sistema distribuído deve escolher entre consistência e disponibilidade. Base de design de NoSQL.",
                Criador = "Eric Brewer",
                AnoOrigin = "2000",
            },
        ]);
    }
}
