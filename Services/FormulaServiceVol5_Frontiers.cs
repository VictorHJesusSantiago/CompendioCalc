using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 5 — PARTE VII: FRONTEIRAS (Seções 20-26)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 20. PRIVACIDADE DIFERENCIAL
    // ─────────────────────────────────────────────────────
    private void AdicionarPrivacidadeDiferencial()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_dp01", Nome = "Definição ε-DP", Categoria = "Privacidade Diferencial", SubCategoria = "Fundamentos de DP",
                Expressao = "P[M(D)∈S] ≤ eᵋ·P[M(D')∈S]  ∀D~D', ∀S",
                ExprTexto = "P[M(D)∈S] ≤ eᵋ·P[M(D')∈S]",
                Icone = "ε",
                Descricao = "ε-privacidade diferencial: mecanismo M é ε-DP se saída é quase idêntica para bancos D e D' que diferem em um registro. Menor ε = mais privacidade.",
                Criador = "Cynthia Dwork",
                AnoOrigin = "2006",
            },
            new Formula
            {
                Id = "5_dp02", Nome = "Mecanismo de Laplace", Categoria = "Privacidade Diferencial", SubCategoria = "Fundamentos de DP",
                Expressao = "M(D) = f(D) + Lap(Δf/ε);  Δf = sensibilidade",
                ExprTexto = "M(D) = f(D) + Lap(Δf/ε)",
                Icone = "Lap",
                Descricao = "Mecanismo de Laplace: adiciona ruído Laplace proporcional à sensibilidade da consulta dividida por ε. Mecanismo fundamental de ε-DP para consultas numéricas.",
            },
            new Formula
            {
                Id = "5_dp03", Nome = "Mecanismo Gaussiano", Categoria = "Privacidade Diferencial", SubCategoria = "Fundamentos de DP",
                Expressao = "M(D) = f(D) + N(0, σ²);  σ ≥ Δf·√(2 ln(1.25/δ))/ε",
                ExprTexto = "M(D) = f(D) + N(0, Δf²·2ln(1.25/δ)/ε²)",
                Icone = "Gs",
                Descricao = "Mecanismo Gaussiano: para (ε,δ)-DP. Adiciona ruído gaussiano. σ proporcional a sensibilidade L2. Mais natural para altas dimensões que Laplace.",
            },
            new Formula
            {
                Id = "5_dp04", Nome = "Composição Sequencial", Categoria = "Privacidade Diferencial", SubCategoria = "Fundamentos de DP",
                Expressao = "k mecanismos εi-DP → (Σεi)-DP  (composição básica)",
                ExprTexto = "k× εi-DP → Σεi-DP (seq. comp.)",
                Icone = "Σε",
                Descricao = "Composição sequencial: privacidade degrada aditivamente. k consultas εi-DP resultam em (Σεi)-DP. Composição avançada: cresce como √k (com δ>0).",
            },
            new Formula
            {
                Id = "5_dp05", Nome = "Composição Avançada", Categoria = "Privacidade Diferencial", SubCategoria = "Fundamentos de DP",
                Expressao = "k× ε-DP → (ε√(2k·ln(1/δ)) + kε(eᵋ-1), kδ)-DP",
                ExprTexto = "k× ε-DP → O(ε√k)-DP (avançada)",
                Icone = "√k",
                Descricao = "Composição avançada: k mecanismos ε-DP compõem como O(ε√k) ao permitir δ>0. Moments accountant (Abadi 2016) é ainda mais apertado.",
            },
            new Formula
            {
                Id = "5_dp06", Nome = "Mecanismo Exponencial", Categoria = "Privacidade Diferencial", SubCategoria = "Mecanismos Avançados",
                Expressao = "P[M(D)=r] ∝ exp(ε·u(D,r)/(2Δu))",
                ExprTexto = "P(r) ∝ exp(εu(D,r)/(2Δu))",
                Icone = "Exp",
                Descricao = "Mecanismo exponencial: para saídas não-numéricas. Seleciona resultado com probabilidade proporcional a exp de utilidade. Aplicações: seleção, leilões, otimização.",
            },
            new Formula
            {
                Id = "5_dp07", Nome = "DP-SGD", Categoria = "Privacidade Diferencial", SubCategoria = "Mecanismos Avançados",
                Expressao = "g̃t = (1/B)(Σ clip(gi, C) + N(0, σ²C²I))",
                ExprTexto = "DP-SGD: clip gradientes + ruído gaussiano",
                Icone = "SGD",
                Descricao = "DP-SGD: treinamento de deep learning com DP. Clip gradientes individuais, adiciona ruído gaussiano. Moments accountant rastreia privacidade total.",
                Criador = "Abadi et al.",
                AnoOrigin = "2016",
            },
            new Formula
            {
                Id = "5_dp08", Nome = "Rényi DP (RDP)", Categoria = "Privacidade Diferencial", SubCategoria = "Mecanismos Avançados",
                Expressao = "Dα(M(D) || M(D')) ≤ ε;  composição: soma de εs",
                ExprTexto = "RDP: Rényi divergence ≤ ε; composição aditiva",
                Icone = "Rα",
                Descricao = "Rényi DP: usa divergência de Rényi de ordem α. Composição aditiva exata. Converte para (ε,δ)-DP. Análise mais apertada que composição avançada.",
            },
            new Formula
            {
                Id = "5_dp09", Nome = "Local DP (LDP)", Categoria = "Privacidade Diferencial", SubCategoria = "Mecanismos Avançados",
                Expressao = "Cada usuário perturba dado localmente antes de enviar",
                ExprTexto = "LDP: perturbação local sem confiança no servidor",
                Icone = "LDP",
                Descricao = "DP Local: cada indivíduo randomiza seu dado antes de compartilhar. Sem necessidade de servidor confiável. RAPPOR (Google), implementações da Apple.",
            },
            new Formula
            {
                Id = "5_dp10", Nome = "Randomized Response", Categoria = "Privacidade Diferencial", SubCategoria = "Mecanismos Avançados",
                Expressao = "P(responder verdade) = p;  P(responder aleatório) = 1-p",
                ExprTexto = "P(verdade)=p, P(aleatório)=1-p",
                Icone = "RR",
                Descricao = "Randomized response (Warner 1965): técnica clássica de LDP. Respondente cola moeda para decidir se responde verdade ou aleatório. Precursor de DP.",
                Criador = "Stanley Warner",
                AnoOrigin = "1965",
            },
            new Formula
            {
                Id = "5_dp11", Nome = "Privacidade e Utilidade (Tradeoff)", Categoria = "Privacidade Diferencial", SubCategoria = "Mecanismos Avançados",
                Expressao = "Erro ∝ Δf/ε  (Laplace);  minimax: Ω(1/(nε²)) para média",
                ExprTexto = "Erro ~ Δf/ε; minimax Ω(1/nε²)",
                Icone = "PU",
                Descricao = "Tradeoff privacidade-utilidade: erro adicionado proporcional a sensibilidade/ε. Limites fundamentais: erro minimax Ω(1/(nε²)) para média com n registros.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 21. BLOCKCHAIN E CONSENSO DISTRIBUÍDO
    // ─────────────────────────────────────────────────────
    private void AdicionarBlockchainConsenso()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_bc01", Nome = "Hash Criptográfico", Categoria = "Blockchain e Consenso", SubCategoria = "Fundamentos Blockchain",
                Expressao = "H: {0,1}* → {0,1}ⁿ;  pré-imagem, colisão, 2ª pré-imagem resistente",
                ExprTexto = "H: {0,1}*→{0,1}ⁿ; resistente a colisão",
                Icone = "#",
                Descricao = "Função hash criptográfica: mapeia dados para digest fixo (256 bits). Propriedades: resistência a pré-imagem, 2ª pré-imagem e colisão. SHA-256 no Bitcoin.",
            },
            new Formula
            {
                Id = "5_bc02", Nome = "Merkle Tree", Categoria = "Blockchain e Consenso", SubCategoria = "Fundamentos Blockchain",
                Expressao = "Raiz = H(H(H(tx1)||H(tx2)) || H(H(tx3)||H(tx4)))",
                ExprTexto = "Raiz = hash(hash pares recursivo)",
                Icone = "MT",
                Descricao = "Árvore de Merkle: estrutura de hash hierárquica. Raiz resume todas transações. Prova de inclusão em O(log n). Usada em blocos Bitcoin, Ethereum, certificados.",
                Criador = "Ralph Merkle",
                AnoOrigin = "1979",
            },
            new Formula
            {
                Id = "5_bc03", Nome = "Proof of Work (PoW)", Categoria = "Blockchain e Consenso", SubCategoria = "Mecanismos de Consenso",
                Expressao = "Encontrar nonce: H(block || nonce) < target;  dificuldade ∝ 1/target",
                ExprTexto = "H(bloco||nonce) < target (PoW)",
                Icone = "PoW",
                Descricao = "Proof of Work: minerador busca nonce que produza hash abaixo do target. Dificuldade ajustada para ~10 min/bloco (Bitcoin). Custo energético garante segurança.",
            },
            new Formula
            {
                Id = "5_bc04", Nome = "Proof of Stake (PoS)", Categoria = "Blockchain e Consenso", SubCategoria = "Mecanismos de Consenso",
                Expressao = "P(validador) ∝ stake;  slash condition se mau comportamento",
                ExprTexto = "P(validar) ∝ stake; slash se malicioso",
                Icone = "PoS",
                Descricao = "Proof of Stake: validadores eleitos proporcionalmente ao stake. Ethereum 2.0 usa Casper. Menos energia que PoW. Slashing penaliza ataques.",
            },
            new Formula
            {
                Id = "5_bc05", Nome = "Generais Bizantinos (BFT)", Categoria = "Blockchain e Consenso", SubCategoria = "Mecanismos de Consenso",
                Expressao = "Tolerância: n ≥ 3f+1 para f falhas bizantinas",
                ExprTexto = "BFT: n ≥ 3f+1 (f falhas bizantinas)",
                Icone = "BFT",
                Descricao = "Problema dos Generais Bizantinos: consenso com falhas arbitrárias requer n≥3f+1. PBFT: O(n²) mensagens. Base teórica de blockchains permissionadas.",
                Criador = "Lamport / Shostak / Pease",
                AnoOrigin = "1982",
            },
            new Formula
            {
                Id = "5_bc06", Nome = "Protocolo Nakamoto", Categoria = "Blockchain e Consenso", SubCategoria = "Mecanismos de Consenso",
                Expressao = "Cadeia mais longa = válida;  P(ataque) = (q/p)^z",
                ExprTexto = "Longest chain; P(ataque)=(q/p)^z",
                Icone = "Nak",
                Descricao = "Consenso de Nakamoto: regra da cadeia mais longa + PoW. Probabilidade de ataque de duplo gasto diminui exponencialmente com z confirmações.",
                Criador = "Satoshi Nakamoto",
                AnoOrigin = "2008",
            },
            new Formula
            {
                Id = "5_bc07", Nome = "Smart Contract (Gas)", Categoria = "Blockchain e Consenso", SubCategoria = "Smart Contracts",
                Expressao = "Custo = gas_usado × gas_price;  EVM executa bytecode",
                ExprTexto = "Custo = gas × gasPrice (EVM)",
                Icone = "⛽",
                Descricao = "Smart contracts em Ethereum: código executado na EVM. Gas mede computação (previne loops infinitos). Custo = gas × preço. Solidity é a linguagem principal.",
            },
            new Formula
            {
                Id = "5_bc08", Nome = "Token ERC-20", Categoria = "Blockchain e Consenso", SubCategoria = "Smart Contracts",
                Expressao = "transfer(to, value);  approve(spender, value);  transferFrom(from, to, value)",
                ExprTexto = "ERC-20: transfer/approve/transferFrom",
                Icone = "ERC",
                Descricao = "ERC-20: padrão de token fungível em Ethereum. Interface: totalSupply, balanceOf, transfer, approve, transferFrom. Base de DeFi e ICOs.",
            },
            new Formula
            {
                Id = "5_bc09", Nome = "Algoritmo de Seleção de UTXO", Categoria = "Blockchain e Consenso", SubCategoria = "Smart Contracts",
                Expressao = "Σ inputs ≥ output + fee;  troco = Σinputs - output - fee",
                ExprTexto = "Σinputs ≥ output+fee; troco=resto",
                Icone = "UTX",
                Descricao = "Modelo UTXO (Bitcoin): transação consome UTXOs como inputs e cria novos como outputs. Soma inputs ≥ soma outputs + fee. Troco retorna ao remetente.",
            },
            new Formula
            {
                Id = "5_bc10", Nome = "Consenso Avalanche", Categoria = "Blockchain e Consenso", SubCategoria = "Mecanismos de Consenso",
                Expressao = "Amostragem repetida de k nós;  supermajoria α → decisão",
                ExprTexto = "Snowball: amostra k nós, α supermajoria",
                Icone = "Av",
                Descricao = "Consenso Avalanche: família de protocolos de metaestabilidade. Nó amostra k peers repetidamente; tendência acumula em contadores. Finalidade sub-segundo.",
                Criador = "Team Rocket / Emin Gün Sirer",
                AnoOrigin = "2018",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 22. COMPUTAÇÃO QUÂNTICA TOPOLÓGICA
    // ─────────────────────────────────────────────────────
    private void AdicionarComputacaoQuanticaTopologica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_qt01", Nome = "Anyon", Categoria = "Computação Quântica Topológica", SubCategoria = "Anyons e Topologia",
                Expressao = "ψ(r₁,r₂) = e^(iθ)·ψ(r₂,r₁);  θ ≠ 0, π (não bóson nem férmion)",
                ExprTexto = "Anyon: troca → e^(iθ), θ∈(0,π)",
                Icone = "An",
                Descricao = "Anyons: quasipartículas em 2D com estatística fracionária. Troca produz fase e^(iθ). Anyons não-abelianos: troca produz transformação unitária no espaço degenerado.",
            },
            new Formula
            {
                Id = "5_qt02", Nome = "Grupo de Braid", Categoria = "Computação Quântica Topológica", SubCategoria = "Anyons e Topologia",
                Expressao = "σi·σj = σj·σi (|i-j|≥2);  σi·σi+1·σi = σi+1·σi·σi+1",
                ExprTexto = "Braid: σiσi+1σi = σi+1σiσi+1",
                Icone = "Br",
                Descricao = "Grupo de braid: descreve tranças de partículas em 2+1D. Relação de Yang-Baxter σiσi+1σi = σi+1σiσi+1. Representações dão portas quânticas.",
            },
            new Formula
            {
                Id = "5_qt03", Nome = "Fibonacci Anyons", Categoria = "Computação Quântica Topológica", SubCategoria = "Anyons e Topologia",
                Expressao = "τ × τ = 1 + τ;  dim(n anyons) = Fib(n+1)",
                ExprTexto = "τ×τ=1+τ; dim=Fibonacci(n+1)",
                Icone = "Fb",
                Descricao = "Fibonacci anyons: anyons não-abelianos com regra de fusão τ×τ=1+τ. Espaço de Hilbert cresce como Fibonacci. Universais para computação quântica por braiding.",
            },
            new Formula
            {
                Id = "5_qt04", Nome = "Código Tórico (Kitaev)", Categoria = "Computação Quântica Topológica", SubCategoria = "Códigos Topológicos",
                Expressao = "Av = Π σx;  Bp = Π σz;  2 qubits lógicos num toro",
                ExprTexto = "Av=Πσx, Bp=Πσz; 2 qubits no toro",
                Icone = "TC",
                Descricao = "Código tórico de Kitaev: código quântico topológico em reticulado. Estabilizadores Av (vértice) e Bp (plaqueta). Erros detectados por anyons. Distância d=L.",
                Criador = "Alexei Kitaev",
                AnoOrigin = "1997",
            },
            new Formula
            {
                Id = "5_qt05", Nome = "Código de Superfície", Categoria = "Computação Quântica Topológica", SubCategoria = "Códigos Topológicos",
                Expressao = "[[L², 1, L]];  threshold ~1% erro por porta",
                ExprTexto = "[[L²,1,L]]; threshold ~1%",
                Icone = "Sf",
                Descricao = "Código de superfície: variante planar do tórico. 1 qubit lógico, distância L, L² qubits físicos. Threshold ~1% com decodificador MWPM. Favorito para hardware.",
            },
            new Formula
            {
                Id = "5_qt06", Nome = "Proteção Topológica", Categoria = "Computação Quântica Topológica", SubCategoria = "Códigos Topológicos",
                Expressao = "Taxa de erro ∼ e^(-αL);  L=distância do código",
                ExprTexto = "Erro ~ e^(-αL) (supressão exponencial)",
                Icone = "TP",
                Descricao = "Proteção topológica: erros locais não corrompem informação codificada topologicamente. Supressão exponencial em L. Motivação para computação quântica topológica.",
            },
            new Formula
            {
                Id = "5_qt07", Nome = "Invariante de Jones (TQFT)", Categoria = "Computação Quântica Topológica", SubCategoria = "Anyons e Topologia",
                Expressao = "VL(t): invariante de nós;  TQFT computa via path integral",
                ExprTexto = "VL(t): invariante de Jones via TQFT",
                Icone = "VL",
                Descricao = "Invariante de Jones: polinômio de nós computável via TQFT (Witten). Conecta teoria de nós, QFT de Chern-Simons e computação quântica topológica.",
                Criador = "Vaughan Jones",
                AnoOrigin = "1984",
            },
            new Formula
            {
                Id = "5_qt08", Nome = "Modelo de Levin-Wen", Categoria = "Computação Quântica Topológica", SubCategoria = "Códigos Topológicos",
                Expressao = "String-net: Σ configs × 6j-symbols;  ground state topológico",
                ExprTexto = "String-net: configs × 6j-symbols",
                Icone = "LW",
                Descricao = "Modelo de Levin-Wen: Hamiltoniano de string-net em reticulado. Ground state topológico descreve fases topológicas 2D. Generaliza código tórico para categorias de fusão.",
                Criador = "Levin / Wen",
                AnoOrigin = "2005",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 23. IA EXPLICÁVEL (XAI)
    // ─────────────────────────────────────────────────────
    private void AdicionarIAExplicavel()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_xa01", Nome = "LIME", Categoria = "IA Explicável", SubCategoria = "Métodos de Explicação",
                Expressao = "argmin_g L(f, g, πx) + Ω(g);  g=modelo local interpretável",
                ExprTexto = "LIME: min L(f,g,πx)+Ω(g) local",
                Icone = "LM",
                Descricao = "LIME: explica predição individual perturbando entrada e ajustando modelo linear local. Agnóstico ao modelo. Produz importância de features por instância.",
                Criador = "Ribeiro / Singh / Guestrin",
                AnoOrigin = "2016",
            },
            new Formula
            {
                Id = "5_xa02", Nome = "SHAP (Shapley Additive)", Categoria = "IA Explicável", SubCategoria = "Métodos de Explicação",
                Expressao = "φi = Σ_{S⊆N\\{i}} |S|!(n-|S|-1)!/n! [f(S∪{i})-f(S)]",
                ExprTexto = "SHAP: φi = Σ contrib. marginal ponderada",
                Icone = "SH",
                Descricao = "SHAP: valores de Shapley para explicação de ML. Única atribuição que satisfaz eficiência, simetria, dummy e aditividade. TreeSHAP, DeepSHAP, KernelSHAP.",
                Criador = "Lundberg / Lee",
                AnoOrigin = "2017",
            },
            new Formula
            {
                Id = "5_xa03", Nome = "Contrafactuais", Categoria = "IA Explicável", SubCategoria = "Métodos de Explicação",
                Expressao = "argmin_x' d(x,x')  s.t. f(x') ≠ f(x)",
                ExprTexto = "CF: min d(x,x') s.t. f(x')≠f(x)",
                Icone = "CF",
                Descricao = "Explicação contrafactual: menor mudança na entrada que altera a predição. 'Se X fosse Y, resultado seria Z.' Ação direta para o usuário.",
            },
            new Formula
            {
                Id = "5_xa04", Nome = "Grad-CAM", Categoria = "IA Explicável", SubCategoria = "Explicação Visual",
                Expressao = "Lc = ReLU(Σk αk·Ak);  αk = (1/Z)Σij ∂yc/∂Akij",
                ExprTexto = "GradCAM: ReLU(Σ αk·Ak); αk=grad mean",
                Icone = "GC",
                Descricao = "Grad-CAM: visualiza importância espacial em CNNs. Pesos = gradiente médio global da classe c em cada feature map. Heatmap sobre a imagem.",
                Criador = "Selvaraju et al.",
                AnoOrigin = "2017",
            },
            new Formula
            {
                Id = "5_xa05", Nome = "Attention Rollout", Categoria = "IA Explicável", SubCategoria = "Explicação Visual",
                Expressao = "R = Π_{l=1}^L (0.5·Ãl + 0.5·I);  Ã normalizado",
                ExprTexto = "Rollout: R = Π(0.5Ã+0.5I) camadas",
                Icone = "AR",
                Descricao = "Attention Rollout: propaga atenção pelas camadas do Transformer. Produto de matrizes de atenção com residual. Mapa de relevância de tokens.",
            },
            new Formula
            {
                Id = "5_xa06", Nome = "Integrated Gradients", Categoria = "IA Explicável", SubCategoria = "Métodos de Explicação",
                Expressao = "IGi(x) = (xi-x'i)·∫₀¹ (∂F/∂xi)(x'+α(x-x')) dα",
                ExprTexto = "IG = (x-x')·∫₀¹ ∇F(x'+α(x-x'))dα",
                Icone = "IG",
                Descricao = "Integrated Gradients: atribuição que satisfaz axiomas de sensibilidade e invariância à implementação. Integra gradientes ao longo de caminho linear baseline→input.",
                Criador = "Sundararajan / Taly / Yan",
                AnoOrigin = "2017",
            },
            new Formula
            {
                Id = "5_xa07", Nome = "Faithfulness (Métrica)", Categoria = "IA Explicável", SubCategoria = "Avaliação de Explicações",
                Expressao = "Corr(attribution rank, perturbation impact)",
                ExprTexto = "Faithfulness: corr(importância, impacto perturbação)",
                Icone = "Fa",
                Descricao = "Fidelidade: avalia se explicação corresponde ao modelo real. Mede correlação entre importância atribuída e impacto na predição ao remover features. Métricas: AOPC, sufficiency.",
            },
            new Formula
            {
                Id = "5_xa08", Nome = "Concept Bottleneck Model", Categoria = "IA Explicável", SubCategoria = "Avaliação de Explicações",
                Expressao = "x → conceitos c → predição y;  intervenção em c possível",
                ExprTexto = "x→conceitos→y (bottleneck)",
                Icone = "CB",
                Descricao = "Concept Bottleneck: rede prediz conceitos interpretáveis primeiro, depois classe final. Permite intervenção humana nos conceitos. Interpretável by design.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 24. COMPUTAÇÃO DNA E NEUROMÓRFICA
    // ─────────────────────────────────────────────────────
    private void AdicionarComputacaoDNANeuromorfica()
    {
        _formulas.AddRange([
            // 24.1 Computação DNA
            new Formula
            {
                Id = "5_dn01", Nome = "DNA Computing (Adleman)", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação DNA",
                Expressao = "Codificar → Misturar → Selecionar → Amplificar → Detectar",
                ExprTexto = "DNA: Codificar→Misturar→Selecionar→Amplificar",
                Icone = "DNA",
                Descricao = "Computação com DNA (Adleman 1994): resolução de Hamiltonian Path com moléculas. Codifica vértices em oligonucleotídeos, hibridização gera caminhos, gel seleciona.",
                Criador = "Leonard Adleman",
                AnoOrigin = "1994",
            },
            new Formula
            {
                Id = "5_dn02", Nome = "DNA Storage", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação DNA",
                Expressao = "Densidade: ~1 EB/mm³;  4 bases → 2 bits/nucleotídeo",
                ExprTexto = "DNA storage: ~2 bits/nt, 1 EB/mm³",
                Icone = "St",
                Descricao = "Armazenamento em DNA: densidade ultra-alta (~1 exabyte/mm³). Codifica bits em bases (A,T,C,G). Desafios: custo de síntese/sequenciamento, taxa de erro, acesso aleatório.",
            },
            new Formula
            {
                Id = "5_dn03", Nome = "Strand Displacement", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação DNA",
                Expressao = "Toehold + invasão → deslocamento de fita → sinal",
                ExprTexto = "Toehold→invasão→deslocamento",
                Icone = "SD",
                Descricao = "Strand displacement: mecanismo de troca de fitas via toehold. Base de circuitos de DNA. Portas AND, OR, NOT implementadas. Cascatas de sinalização molecular.",
            },
            new Formula
            {
                Id = "5_dn04", Nome = "DNA Origami", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação DNA",
                Expressao = "Scaffold (7249 nt) + ~200 staples → nanostrutura 2D/3D",
                ExprTexto = "Scaffold+staples→nanostrutura (origami)",
                Icone = "Ori",
                Descricao = "DNA Origami (Rothemund 2006): fita longa scaffold dobrada em forma arbitrária por ~200 staple strands curtos. Nanoestruturas precisas para sensores e drug delivery.",
                Criador = "Paul Rothemund",
                AnoOrigin = "2006",
            },
            new Formula
            {
                Id = "5_dn05", Nome = "CRISPR como Computação", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação DNA",
                Expressao = "gRNA + Cas9 → edição condicional;  portas lógicas in vivo",
                ExprTexto = "CRISPR: gRNA+Cas9→edit; lógica in vivo",
                Icone = "CR",
                Descricao = "CRISPR como circuito lógico: guias RNA programam Cas9/dCas9 para ativar/reprimir genes condicionalmente. Portas lógicas e registradores de memória celular.",
            },

            // 24.2 Computação Neuromórfica
            new Formula
            {
                Id = "5_dn06", Nome = "Neurônio LIF (Leaky Integrate-and-Fire)", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação Neuromórfica",
                Expressao = "τm·dV/dt = -(V-EL) + R·I;  V≥Vth → spike, V→Vreset",
                ExprTexto = "τ·dV/dt=-(V-EL)+RI; V≥Vth→spike",
                Icone = "LIF",
                Descricao = "Leaky Integrate-and-Fire: modelo neuronal simples. Tensão integra correntes com leak. Ao atingir limiar, dispara spike e reseta. Base de chips neuromórficos.",
            },
            new Formula
            {
                Id = "5_dn07", Nome = "STDP (Spike-Timing Dependent Plasticity)", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação Neuromórfica",
                Expressao = "Δw = A+·exp(-Δt/τ+) se Δt>0;  A-·exp(Δt/τ-) se Δt<0",
                ExprTexto = "STDP: Δw ~ exp(-|Δt|/τ); sinal por timing",
                Icone = "ST",
                Descricao = "STDP: regra de aprendizado hebbiana temporal. Pré antes de pós → potenciação. Pós antes de pré → depressão. Base de aprendizado em hardware neuromórfico.",
            },
            new Formula
            {
                Id = "5_dn08", Nome = "SNN (Spiking Neural Network)", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação Neuromórfica",
                Expressao = "Spike trains;  evento-driven;  temporal coding",
                ExprTexto = "SNN: spike trains, evento-driven",
                Icone = "SNN",
                Descricao = "SNN: redes neurais de spikes. Comunicação por pulsos discretos. Eficientes em energia (~20 fJ/spike). Implementadas em Loihi (Intel), TrueNorth (IBM), SpiNNaker.",
            },
            new Formula
            {
                Id = "5_dn09", Nome = "Memristor", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação Neuromórfica",
                Expressao = "V = M(q)·I;  M=memristância (função da carga ou fluxo acumulado)",
                ExprTexto = "V = M(q)·I (memristor)",
                Icone = "Mr",
                Descricao = "Memristor: componente passivo cuja resistência depende do histórico. Emula sinapse (peso análogo). Arrays de memristores para computação in-memory e crossbar.",
                Criador = "Leon Chua (teoria)",
                AnoOrigin = "1971",
            },
            new Formula
            {
                Id = "5_dn10", Nome = "Eficiência Energética Neuromórfica", Categoria = "Computação DNA e Neuromórfica", SubCategoria = "Computação Neuromórfica",
                Expressao = "Loihi: ~100× mais eficiente que GPU para inferência SNN",
                ExprTexto = "Neuromórfico: ~100× eficiência vs GPU",
                Icone = "⚡",
                Descricao = "Vantagem energética: chips neuromórficos processam spikes assincronamente, consumindo ~mW vs ~100W de GPUs. Ideal para edge AI, robótica e sensores always-on.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 25. BIOQUÍMICA ESTRUTURAL
    // ─────────────────────────────────────────────────────
    private void AdicionarBioquimicaEstrutural()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_bq01", Nome = "Michaelis-Menten", Categoria = "Bioquímica Estrutural", SubCategoria = "Cinética Enzimática",
                Expressao = "v = Vmax·[S]/(Km + [S])",
                ExprTexto = "v = Vmax·[S]/(Km+[S])",
                Icone = "MM",
                Descricao = "Equação de Michaelis-Menten: cinética enzimática. v=velocidade, Vmax=velocidade máxima, Km=constante de Michaelis (afinidade). Derivada do mecanismo E+S↔ES→E+P.",
                Criador = "Michaelis / Menten",
                AnoOrigin = "1913",
            },
            new Formula
            {
                Id = "5_bq02", Nome = "Equação de Hill", Categoria = "Bioquímica Estrutural", SubCategoria = "Cinética Enzimática",
                Expressao = "θ = [L]ⁿ/(Kd + [L]ⁿ);  n=coeficiente de Hill",
                ExprTexto = "θ = [L]ⁿ/(Kd+[L]ⁿ) (Hill)",
                Icone = "Hl",
                Descricao = "Equação de Hill: modela cooperatividade na ligação de ligantes. n>1 cooperatividade positiva (hemoglobina n≈2.8), n<1 negativa, n=1 não-cooperativa.",
                Criador = "Archibald Hill",
                AnoOrigin = "1910",
            },
            new Formula
            {
                Id = "5_bq03", Nome = "Lei de Bragg (Cristalografia)", Categoria = "Bioquímica Estrutural", SubCategoria = "Cristalografia de Proteínas",
                Expressao = "nλ = 2d·sin(θ)",
                ExprTexto = "nλ = 2d·sinθ (Bragg)",
                Icone = "Bg",
                Descricao = "Lei de Bragg: condição de difração construtiva em cristais. Base da cristalografia de raios-X para resolver estruturas de proteínas. d=espaçamento, θ=ângulo.",
                Criador = "W.H. & W.L. Bragg",
                AnoOrigin = "1913",
            },
            new Formula
            {
                Id = "5_bq04", Nome = "Fator de Estrutura", Categoria = "Bioquímica Estrutural", SubCategoria = "Cristalografia de Proteínas",
                Expressao = "F(hkl) = Σj fj·exp(2πi(hxj+kyj+lzj))",
                ExprTexto = "F(hkl) = Σ fj·e^(2πi(hx+ky+lz))",
                Icone = "Fhkl",
                Descricao = "Fator de estrutura: amplitude de difração para reflexão (hkl). Problema de fase: |F| medido mas fase perdida. Métodos: MAD, MR, SAD para resolver.",
            },
            new Formula
            {
                Id = "5_bq05", Nome = "Ramachandran Plot", Categoria = "Bioquímica Estrutural", SubCategoria = "Cristalografia de Proteínas",
                Expressao = "Ângulos (φ, ψ) do backbone;  regiões permitidas vs proibidas",
                ExprTexto = "(φ,ψ): regiões permitidas do backbone",
                Icone = "Rm",
                Descricao = "Diagrama de Ramachandran: mapa de ângulos diedros φ (C-N-Cα-C) e ψ (N-Cα-C-N) do backbone proteico. Colisões estéricas definem regiões permitidas.",
                Criador = "G.N. Ramachandran",
                AnoOrigin = "1963",
            },
            new Formula
            {
                Id = "5_bq06", Nome = "AlphaFold (Predição de Estrutura)", Categoria = "Bioquímica Estrutural", SubCategoria = "Predição Estrutural",
                Expressao = "MSA + templates → Evoformer → Structure Module → coordenadas 3D",
                ExprTexto = "AlphaFold: MSA→Evoformer→Structure→3D",
                Icone = "AF",
                Descricao = "AlphaFold2: prediz estrutura 3D de proteínas a partir da sequência. Evoformer processa MSA e pares. Acurácia experimental. Revolucionou biologia estrutural.",
                Criador = "DeepMind",
                AnoOrigin = "2020",
            },
            new Formula
            {
                Id = "5_bq07", Nome = "RMSD (Comparação Estrutural)", Categoria = "Bioquímica Estrutural", SubCategoria = "Predição Estrutural",
                Expressao = "RMSD = √(Σᵢ ||rᵢ - r'ᵢ||²/N)  após alinhamento ótimo",
                ExprTexto = "RMSD = √(Σ||r-r'||²/N)",
                Icone = "RM",
                Descricao = "RMSD: raiz da média dos quadrados das distâncias entre átomos correspondentes após superposição ótima. Mede similaridade estrutural. <2Å = muito similar.",
            },
            new Formula
            {
                Id = "5_bq08", Nome = "Energia Livre de Ligação", Categoria = "Bioquímica Estrutural", SubCategoria = "Termodinâmica de Ligação",
                Expressao = "ΔG = ΔH - TΔS = -RT·ln(Ka)",
                ExprTexto = "ΔG = ΔH-TΔS = -RT·ln(Ka)",
                Icone = "ΔG",
                Descricao = "Energia livre de ligação: ΔG determina espontaneidade. Ka = constante de associação. ΔG negativo = ligação favorável. Docking e scoring functions estimam ΔG.",
            },
            new Formula
            {
                Id = "5_bq09", Nome = "Potencial de Lennard-Jones", Categoria = "Bioquímica Estrutural", SubCategoria = "Termodinâmica de Ligação",
                Expressao = "V(r) = 4ε[(σ/r)¹² - (σ/r)⁶]",
                ExprTexto = "V(r) = 4ε[(σ/r)¹²-(σ/r)⁶]",
                Icone = "LJ",
                Descricao = "Potencial de Lennard-Jones: modela interação de van der Waals. Repulsão r⁻¹² e atração r⁻⁶. Parâmetros ε (profundidade) e σ (distância). Usado em MD de proteínas.",
            },
            new Formula
            {
                Id = "5_bq10", Nome = "Campo de Força (MD)", Categoria = "Bioquímica Estrutural", SubCategoria = "Termodinâmica de Ligação",
                Expressao = "V = Σ bonds + Σ angles + Σ dihedrals + Σ LJ + Σ Coulomb",
                ExprTexto = "V = Vbond+Vangle+Vdih+VLJ+VCoulomb",
                Icone = "FF",
                Descricao = "Campo de força para dinâmica molecular: soma de termos para ligações, ângulos, diedros, van der Waals e eletrostática. AMBER, CHARMM, OPLS. Simula dinâmica de proteínas.",
            },
            new Formula
            {
                Id = "5_bq11", Nome = "Equação de Henderson-Hasselbalch", Categoria = "Bioquímica Estrutural", SubCategoria = "Termodinâmica de Ligação",
                Expressao = "pH = pKa + log([A⁻]/[HA])",
                ExprTexto = "pH = pKa + log([A⁻]/[HA])",
                Icone = "pH",
                Descricao = "Henderson-Hasselbalch: relaciona pH, pKa e razão base/ácido. Fundamental para entender protonação de resíduos de proteínas e tampões biológicos.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 26. REDES DE HOPFIELD E ECOLOGIA MATEMÁTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarHopfieldEcologia()
    {
        _formulas.AddRange([
            // 26.1 Redes de Hopfield
            new Formula
            {
                Id = "5_hp01", Nome = "Rede de Hopfield", Categoria = "Hopfield e Ecologia", SubCategoria = "Redes de Hopfield",
                Expressao = "wij = (1/N)Σμ ξᵢᵘ·ξⱼᵘ;  sᵢ(t+1) = sgn(Σⱼ wij·sⱼ(t))",
                ExprTexto = "wij=Σξiξj/N; si=sgn(Σwij·sj)",
                Icone = "Hp",
                Descricao = "Rede de Hopfield: memória associativa. Pesos de Hebb: wij = correlação entre padrões. Dinâmica converge a atratores (memórias). Capacidade ~0.14N padrões.",
                Criador = "John Hopfield",
                AnoOrigin = "1982",
            },
            new Formula
            {
                Id = "5_hp02", Nome = "Energia de Hopfield", Categoria = "Hopfield e Ecologia", SubCategoria = "Redes de Hopfield",
                Expressao = "E = -(1/2)Σᵢⱼ wij·sᵢ·sⱼ - Σᵢ θᵢ·sᵢ",
                ExprTexto = "E = -(1/2)Σwij·si·sj - Σθi·si",
                Icone = "EH",
                Descricao = "Função de energia da rede de Hopfield: decresce ou mantém-se a cada atualização assíncrona. Mínimos locais = padrões memorizados. Análogo a spin glass.",
            },
            new Formula
            {
                Id = "5_hp03", Nome = "Modern Hopfield (Attention)", Categoria = "Hopfield e Ecologia", SubCategoria = "Redes de Hopfield",
                Expressao = "E = -log(Σμ exp(β·ξᵘ·x)) + cte;  update ∝ softmax",
                ExprTexto = "Modern Hopfield: E=-log Σ exp(βξ·x)",
                Icone = "MH",
                Descricao = "Redes de Hopfield modernas (Ramsauer 2021): energia com interação exponencial. Capacidade exponencial em dimensão. Conexão direta com atenção de Transformers.",
                Criador = "Ramsauer et al.",
                AnoOrigin = "2021",
            },
            new Formula
            {
                Id = "5_hp04", Nome = "Máquina de Boltzmann", Categoria = "Hopfield e Ecologia", SubCategoria = "Redes de Hopfield",
                Expressao = "P(v,h) ∝ exp(-E(v,h));  E = -Σ wij·vi·hj - Σ bi·vi - Σ cj·hj",
                ExprTexto = "P(v,h) ∝ e^(-E); E=-Σwij·vi·hj-...",
                Icone = "BM",
                Descricao = "Máquina de Boltzmann: modelo generativo estocástico. RBM (restrita) com camadas visível/oculta. Treinamento por contrastive divergence. Pré-treinamento de deep nets.",
                Criador = "Hinton / Sejnowski",
                AnoOrigin = "1985",
            },

            // 26.2 Ecologia Matemática
            new Formula
            {
                Id = "5_ec01", Nome = "Equação Logística", Categoria = "Hopfield e Ecologia", SubCategoria = "Ecologia Matemática",
                Expressao = "dN/dt = rN(1 - N/K);  K=capacidade de carga",
                ExprTexto = "dN/dt = rN(1-N/K) (logística)",
                Icone = "Lg",
                Descricao = "Crescimento logístico: população cresce exponencialmente quando pequena, desacelera ao se aproximar da capacidade de carga K. Modelo clássico de ecologia.",
                Criador = "Pierre-François Verhulst",
                AnoOrigin = "1838",
            },
            new Formula
            {
                Id = "5_ec02", Nome = "Lotka-Volterra (Predador-Presa)", Categoria = "Hopfield e Ecologia", SubCategoria = "Ecologia Matemática",
                Expressao = "dx/dt = αx - βxy;  dy/dt = δxy - γy",
                ExprTexto = "x'=αx-βxy; y'=δxy-γy (Lotka-Volterra)",
                Icone = "LV",
                Descricao = "Equações de Lotka-Volterra: presa x cresce e é consumida; predador y cresce com presa e morre. Oscilações periódicas. Modelo fundamental de interação ecológica.",
                Criador = "Lotka / Volterra",
                AnoOrigin = "1926",
            },
            new Formula
            {
                Id = "5_ec03", Nome = "Competição (Lotka-Volterra)", Categoria = "Hopfield e Ecologia", SubCategoria = "Ecologia Matemática",
                Expressao = "dNi/dt = riNi(1 - (Ni + αijNj)/Ki);  coexistência se αij < Ki/Kj",
                ExprTexto = "Ni' = riNi(1-(Ni+αNj)/Ki)",
                Icone = "Cp",
                Descricao = "Competição interespecífica: duas espécies competem por recurso. Coexistência se competição intraespecífica > interespecífica. Princípio de exclusão competitiva.",
            },
            new Formula
            {
                Id = "5_ec04", Nome = "Metapopulação (Levins)", Categoria = "Hopfield e Ecologia", SubCategoria = "Ecologia Matemática",
                Expressao = "dp/dt = cp(1-p) - ep;  equilíbrio: p* = 1 - e/c",
                ExprTexto = "dp/dt = cp(1-p)-ep (Levins)",
                Icone = "Mp",
                Descricao = "Modelo de metapopulação de Levins: patches ocupados colonizam vazios (taxa c), sofrem extinção local (taxa e). Equilíbrio p*=1-e/c. Conservação de habitats fragmentados.",
                Criador = "Richard Levins",
                AnoOrigin = "1969",
            },
            new Formula
            {
                Id = "5_ec05", Nome = "Diversidade de Shannon (Ecologia)", Categoria = "Hopfield e Ecologia", SubCategoria = "Ecologia Matemática",
                Expressao = "H' = -Σᵢ pᵢ·ln(pᵢ);  equitabilidade J = H'/ln(S)",
                ExprTexto = "H' = -Σpi·ln(pi); J=H'/ln(S)",
                Icone = "H'",
                Descricao = "Índice de Shannon: mede diversidade de espécies combinando riqueza (S) e uniformidade (equitabilidade J). Mais alto = mais diverso. Usado em ecologia e repertório imune.",
            },
            new Formula
            {
                Id = "5_ec06", Nome = "Espécie-Área (SAR)", Categoria = "Hopfield e Ecologia", SubCategoria = "Ecologia Matemática",
                Expressao = "S = c·Aᶻ;  z ≈ 0.15-0.35  (ilhas)",
                ExprTexto = "S = cAᶻ (espécie-área)",
                Icone = "SA",
                Descricao = "Relação espécie-área: número de espécies cresce como potência da área. z~0.25 para ilhas. Base de biogeografia de ilhas e conservação (MacArthur-Wilson).",
            },
        ]);
    }
}
