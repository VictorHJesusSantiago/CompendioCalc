using CompendioCalc.Models;
using System.Reflection;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    private readonly List<Formula> _formulas = [];
    private readonly List<CategoriaInfo> _categorias = [];

    public FormulaService()
    {
        InicializarCategorias();
        InicializarFormulas();
        InicializarCodigosCompendio();
    }

    public IEnumerable<Formula> ObterTodas() => _formulas;
    public IEnumerable<Formula> ObterPorCategoria(string cat) =>
        _formulas.Where(f => f.Categoria == cat);
    public IEnumerable<Formula> ObterFavoritas() =>
        _formulas.Where(f => f.Favorita);
    public Formula? ObterPorId(string id) =>
        _formulas.FirstOrDefault(f => f.Id == id);
    public IEnumerable<CategoriaInfo> ObterCategorias() => _categorias;
    public IEnumerable<Formula> Buscar(string termo) =>
        _formulas.Where(f =>
            f.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
            f.Descricao.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
            f.Criador.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
            f.Expressao.Contains(termo, StringComparison.OrdinalIgnoreCase));

    public void ToggleFavorita(string id)
    {
        var f = ObterPorId(id);
        if (f != null) f.Favorita = !f.Favorita;
    }

    private void InicializarCategorias()
    {
        _categorias.AddRange([
            new() { Nome = "Álgebra", Icone = "𝑥", Cor = "#E8A838", Descricao = "Equações, polinômios e operações algébricas" },
            new() { Nome = "Geometria", Icone = "△", Cor = "#4ECDC4", Descricao = "Formas, áreas, volumes e espaço" },
            new() { Nome = "Trigonometria", Icone = "sin", Cor = "#7C3AED", Descricao = "Funções e identidades trigonométricas" },
            new() { Nome = "Cálculo", Icone = "∫", Cor = "#EF4444", Descricao = "Derivadas, integrais e séries" },
            new() { Nome = "Álgebra Linear", Icone = "M", Cor = "#3B82F6", Descricao = "Matrizes, vetores e transformações" },
            new() { Nome = "Equações Diferenciais", Icone = "d/dt", Cor = "#10B981", Descricao = "EDOs e EDPs fundamentais" },
            new() { Nome = "Probabilidade", Icone = "P", Cor = "#F59E0B", Descricao = "Probabilidade e distribuições" },
            new() { Nome = "Estatística", Icone = "σ", Cor = "#EC4899", Descricao = "Médias, variâncias e inferência" },
            new() { Nome = "Mecânica Clássica", Icone = "F", Cor = "#6366F1", Descricao = "Força, energia, movimento" },
            new() { Nome = "Termodinâmica", Icone = "Q", Cor = "#F97316", Descricao = "Calor, trabalho e entropia" },
            new() { Nome = "Eletromagnetismo", Icone = "E", Cor = "#14B8A6", Descricao = "Campos elétricos e magnéticos" },
            new() { Nome = "Óptica", Icone = "λ", Cor = "#A855F7", Descricao = "Luz, refração e difração" },
            new() { Nome = "Mecânica dos Fluidos", Icone = "∇", Cor = "#0EA5E9", Descricao = "Pressão, fluxo e viscosidade" },
            new() { Nome = "Engenharia", Icone = "⚙", Cor = "#84CC16", Descricao = "Estruturas e circuitos" },
            new() { Nome = "Biologia Matemática", Icone = "🧬", Cor = "#22C55E", Descricao = "Modelos populacionais e dinâmica" },
            new() { Nome = "Computação", Icone = "O", Cor = "#64748B", Descricao = "Complexidade e algoritmos" },
            // ── Volume 2 ──
            new() { Nome = "Álgebra Abstrata", Icone = "⊕", Cor = "#9333EA", Descricao = "Grupos, anéis, corpos e homomorfismos" },
            new() { Nome = "Topologia", Icone = "τ", Cor = "#DC2626", Descricao = "Espaços métricos, topológicos e teoremas clássicos" },
            new() { Nome = "Geometria Diferencial", Icone = "κ", Cor = "#0891B2", Descricao = "Curvas, superfícies, variedades e conexões" },
            new() { Nome = "Cálculo de Variações", Icone = "δ", Cor = "#B45309", Descricao = "Funcionais, Euler-Lagrange e mecânica variacional" },
            new() { Nome = "Funções Especiais", Icone = "Γ", Cor = "#7C3AED", Descricao = "Gamma, Beta, Bessel, Legendre, Hermite e Laguerre" },
            new() { Nome = "Análise Complexa", Icone = "ℂ", Cor = "#4F46E5", Descricao = "Funções analíticas, resíduos e séries de Laurent" },
            new() { Nome = "Mecânica Analítica", Icone = "ℒ", Cor = "#B91C1C", Descricao = "Lagrangiano, Hamiltoniano e colchetes de Poisson" },
            new() { Nome = "Mecânica Estatística", Icone = "Z", Cor = "#BE185D", Descricao = "Ensembles, estatísticas quânticas e transições de fase" },
            new() { Nome = "Teoria Quântica de Campos", Icone = "ψ", Cor = "#6D28D9", Descricao = "QFT, QED, QCD e Modelo Padrão" },
            new() { Nome = "Relatividade Geral", Icone = "G", Cor = "#1D4ED8", Descricao = "Geometria curva, Einstein e soluções clássicas" },
            new() { Nome = "Séries Temporais", Icone = "Xₜ", Cor = "#92400E", Descricao = "ARIMA, GARCH e modelos de volatilidade" },
            new() { Nome = "Análise Multivariada", Icone = "Σ", Cor = "#047857", Descricao = "PCA, LDA, análise fatorial e clustering" },
            new() { Nome = "Estatística Bayesiana", Icone = "θ", Cor = "#7E22CE", Descricao = "Inferência bayesiana, MCMC e processos estocásticos" },
            new() { Nome = "Teoria dos Grafos", Icone = "⊙", Cor = "#C2410C", Descricao = "Grafos, coloração, caminhos e fluxos" },
            new() { Nome = "Processamento de Sinais", Icone = "~", Cor = "#0E7490", Descricao = "DFT, FFT, filtros digitais e Nyquist" },
            new() { Nome = "Deep Learning", Icone = "🧠", Cor = "#4338CA", Descricao = "CNN, RNN, LSTM, Transformers e GANs" },
            new() { Nome = "Computação Quântica", Icone = "Q", Cor = "#6B21A8", Descricao = "Qubits, portas quânticas e algoritmos quânticos" },
            new() { Nome = "Controle Automático", Icone = "⊗", Cor = "#15803D", Descricao = "PID, estabilidade e resposta de sistemas" },
            new() { Nome = "Processamento de Imagem", Icone = "▦", Cor = "#A21CAF", Descricao = "Filtros, morfologia e segmentação" },
            new() { Nome = "Antenas e Telecom", Icone = "📡", Cor = "#EA580C", Descricao = "Antenas, linhas de transmissão e micro-ondas" },
            new() { Nome = "Epidemiologia", Icone = "🦠", Cor = "#16A34A", Descricao = "SIR, Lotka-Volterra e dinâmica de populações" },
            new() { Nome = "Farmacocinética", Icone = "💊", Cor = "#E11D48", Descricao = "Modelos compartimentais e farmacodinâmica" },
            new() { Nome = "Neurociência Computacional", Icone = "⚡", Cor = "#0369A1", Descricao = "Hodgkin-Huxley, Integrate-and-Fire e redes neurais biológicas" },
            // ── Volume 3 ──
            new() { Nome = "Análise Funcional", Icone = "∥", Cor = "#8B5CF6", Descricao = "Espaços de Banach, Hilbert e teoria espectral" },
            new() { Nome = "Teoria da Medida", Icone = "μ", Cor = "#B91C1C", Descricao = "σ-álgebras, integral de Lebesgue e Radon-Nikodym" },
            new() { Nome = "Teoria das Categorias", Icone = "⇒", Cor = "#059669", Descricao = "Funtores, transformações naturais e construções universais" },
            new() { Nome = "Análise Numérica", Icone = "≈", Cor = "#D97706", Descricao = "Interpolação, integração numérica e elementos finitos" },
            new() { Nome = "Geometria Algébrica", Icone = "∩", Cor = "#7C2D12", Descricao = "Variedades algébricas e curvas elípticas" },
            new() { Nome = "Lógica Matemática", Icone = "⊢", Cor = "#4338CA", Descricao = "Lógica de 1ª ordem, incompletude de Gödel e modelos" },
            new() { Nome = "Matéria Condensada", Icone = "⬡", Cor = "#6D28D9", Descricao = "Bandas, supercondutividade BCS e fônons" },
            new() { Nome = "Caos e Fractais", Icone = "∞", Cor = "#DC2626", Descricao = "Sistemas dinâmicos, atratores de Lorenz e fractais" },
            new() { Nome = "Física de Plasmas", Icone = "☀", Cor = "#EAB308", Descricao = "Debye, Vlasov e magnetohidrodinâmica" },
            new() { Nome = "Física Nuclear", Icone = "⚛", Cor = "#EF4444", Descricao = "Estrutura nuclear, fissão, fusão e reatores" },
            new() { Nome = "Óptica Quântica", Icone = "ℏ", Cor = "#8B5CF6", Descricao = "Campo quantizado, lasers e emaranhamento" },
            new() { Nome = "Análise de Sobrevivência", Icone = "Ŝ", Cor = "#10B981", Descricao = "Kaplan-Meier, Cox e funções de risco" },
            new() { Nome = "Valores Extremos e Cópulas", Icone = "∧", Cor = "#BE123C", Descricao = "GEV, GPD, VaR e cópulas" },
            new() { Nome = "Geoestatística", Icone = "🌍", Cor = "#0D9488", Descricao = "Variograma, Kriging e covariância espacial" },
            new() { Nome = "Mecânica da Fratura", Icone = "⚒", Cor = "#78350F", Descricao = "LEFM, fadiga e propagação de trincas" },
            new() { Nome = "CFD e Turbulência", Icone = "▽", Cor = "#0284C7", Descricao = "Navier-Stokes, RANS, LES e volumes finitos" },
            new() { Nome = "Robótica", Icone = "🤖", Cor = "#7C3AED", Descricao = "Cinemática, dinâmica e controle de manipuladores" },
            new() { Nome = "Sistemas de Potência", Icone = "🔌", Cor = "#CA8A04", Descricao = "Fluxo de carga, curto-circuito e estabilidade" },
            new() { Nome = "Finanças Quantitativas", Icone = "$", Cor = "#16A34A", Descricao = "Markowitz, CAPM, Black-Scholes e risco" },
            new() { Nome = "Pesquisa Operacional", Icone = "⊿", Cor = "#6366F1", Descricao = "Programação linear, inteira e teoria das filas" },
            new() { Nome = "Ciências do Clima", Icone = "🌡", Cor = "#0891B2", Descricao = "Equações primitivas, carbono e ENSO" },
            new() { Nome = "Bioinformática", Icone = "🔬", Cor = "#059669", Descricao = "Alinhamento, filogenética e biologia de sistemas" },
            new() { Nome = "Acústica e Vibroacústica", Icone = "♪", Cor = "#9333EA", Descricao = "Ondas sonoras, acústica de salas e vibrações" },
            // ── Volume 4 ──
            new() { Nome = "Geometria Simplética", Icone = "ω", Cor = "#7C3AED", Descricao = "Formas simpléticas, Poisson e quantização geométrica" },
            new() { Nome = "Topologia Algébrica Avançada", Icone = "⟹", Cor = "#DC2626", Descricao = "Sequências espectrais, K-teoria e álgebra homológica" },
            new() { Nome = "Formas Modulares", Icone = "τ", Cor = "#B45309", Descricao = "Grupo modular, Eisenstein, funções L e Riemann" },
            new() { Nome = "Teoria Ergódica", Icone = "μ", Cor = "#059669", Descricao = "Sistemas ergódicos, mixing e entropia de Kolmogorov" },
            new() { Nome = "Análise p-Ádica", Icone = "ℚₚ", Cor = "#4338CA", Descricao = "Números p-ádicos, Hensel e funções zeta p-ádicas" },
            new() { Nome = "Renormalização e SUSY", Icone = "β", Cor = "#9333EA", Descricao = "Renormalização, grupo de Wilson e supersimetria" },
            new() { Nome = "AdS/CFT e Holografia", Icone = "∂", Cor = "#1D4ED8", Descricao = "Correspondência holográfica, Maldacena e Ryu-Takayanagi" },
            new() { Nome = "Cosmologia Inflacionária", Icone = "Λ", Cor = "#B91C1C", Descricao = "Inflação, slow-roll, matéria e energia escuras" },
            new() { Nome = "Gravidade Quântica e Cordas", Icone = "𝒮", Cor = "#6D28D9", Descricao = "LQG, redes de spin, cordas e T-dualidade" },
            new() { Nome = "Aprendizado por Reforço", Icone = "π*", Cor = "#16A34A", Descricao = "MDP, Bellman, Q-learning, policy gradient e PPO" },
            new() { Nome = "GNN e Geometria Profunda", Icone = "◎", Cor = "#7C3AED", Descricao = "GCN, GAT, equivariância e gradiente natural" },
            new() { Nome = "Transporte Ótimo e TDA", Icone = "W₂", Cor = "#0891B2", Descricao = "Wasserstein, wavelets e homologia persistente" },
            new() { Nome = "Inferência Causal", Icone = "do", Cor = "#CA8A04", Descricao = "Do-cálculo de Pearl, DiD, RDD e econometria" },
            new() { Nome = "Alta Dimensionalidade", Icone = "‖β‖", Cor = "#6366F1", Descricao = "LASSO, compressed sensing e matrizes aleatórias" },
            new() { Nome = "Controle Não-Linear e Ótimo", Icone = "V̇", Cor = "#15803D", Descricao = "Lyapunov, SMC, backstepping, LQR e Pontryagin" },
            new() { Nome = "Dispositivos Semicondutores", Icone = "⚡", Cor = "#EA580C", Descricao = "Junção p-n, MOSFET, BJT e drift-difusão" },
            new() { Nome = "Codificação e Comunicações", Icone = "C", Cor = "#0E7490", Descricao = "Capacidade, LDPC, turbo, polar e OFDM" },
            new() { Nome = "Hidrologia e Combustão", Icone = "🔥", Cor = "#78350F", Descricao = "Saint-Venant, plasticidade, Arrhenius e chama" },
            new() { Nome = "Morfogênese e Turing", Icone = "∂u", Cor = "#10B981", Descricao = "Reação-difusão, Turing, Gray-Scott e Wilson-Cowan" },
            new() { Nome = "Imagem Médica", Icone = "CT", Cor = "#A21CAF", Descricao = "CT, PET, retroprojeção e biomecânica de tecidos" },
            new() { Nome = "Psicometria e IRT", Icone = "θ", Cor = "#E11D48", Descricao = "Rasch, 2PL, 3PL, CFA e modelos SEM" },
            new() { Nome = "Teoria dos Jogos", Icone = "⚖", Cor = "#D97706", Descricao = "Nash, minimax, Bayesiano, Shapley e leilões" },
            new() { Nome = "Redes Complexas", Icone = "🕸", Cor = "#0284C7", Descricao = "Scale-free, small-world, PageRank e propagação" },
            new() { Nome = "Criptografia Pós-Quântica", Icone = "🔒", Cor = "#4F46E5", Descricao = "Reticulados, LWE, Kyber, Dilithium e SPHINCS+" },
            new() { Nome = "Informação Quântica Avançada", Icone = "ρ", Cor = "#6B21A8", Descricao = "Canais quânticos, Holevo, estabilizadores e tórico" },
            // ── Volume 5 ──
            new() { Nome = "Teoria de Lie", Icone = "𝔤", Cor = "#7C3AED", Descricao = "Álgebras de Lie semissimples, raízes e representações" },
            new() { Nome = "Números Algébricos", Icone = "𝒪", Cor = "#B45309", Descricao = "Anéis de inteiros, ideais, classes e reciprocidade" },
            new() { Nome = "Geometria Riemanniana", Icone = "Ric", Cor = "#0891B2", Descricao = "Curvatura, Hodge, Ricci flow e variedades Einstein" },
            new() { Nome = "Análise Harmônica", Icone = "Ĝ", Cor = "#DC2626", Descricao = "Haar, Fourier em grupos e dualidade de Pontryagin" },
            new() { Nome = "Geometria Não-Comutativa", Icone = "⋆", Cor = "#4F46E5", Descricao = "C*-álgebras, von Neumann, Moyal e geometria espectral" },
            new() { Nome = "Mecânica Celeste", Icone = "☾", Cor = "#1D4ED8", Descricao = "KAM, problema de 3 corpos e mecânica orbital" },
            new() { Nome = "Magnetismo e Matéria Mole", Icone = "🧲", Cor = "#B91C1C", Descricao = "Ferromagnetismo, Josephson, polímeros e líquido-cristalinos" },
            new() { Nome = "Cristalografia", Icone = "💎", Cor = "#6D28D9", Descricao = "Bravais, Bragg, fator de estrutura e difração" },
            new() { Nome = "Processos Gaussianos", Icone = "GP", Cor = "#059669", Descricao = "GP, kernels, GAM, splines e bootstrap" },
            new() { Nome = "Otimização Convexa", Icone = "∇f", Cor = "#D97706", Descricao = "Convexidade, KKT, ADMM, SDP e Nesterov" },
            new() { Nome = "ICA e Misturas", Icone = "⊥", Cor = "#9333EA", Descricao = "ICA, GMM, EM e estimação de densidade por kernel" },
            new() { Nome = "Algoritmos de Aproximação", Icone = "ρ", Cor = "#EF4444", Descricao = "Set Cover, TSP, PCP e complexidade de circuitos" },
            new() { Nome = "Redes de Computadores", Icone = "🌐", Cor = "#0EA5E9", Descricao = "TCP, CUBIC, BBR, OSPF, BGP e SDN" },
            new() { Nome = "Compiladores e Autômatos", Icone = "⊢", Cor = "#78350F", Descricao = "Chomsky, LL/LR, autômatos e gramáticas formais" },
            new() { Nome = "Computação Paralela", Icone = "‖", Cor = "#15803D", Descricao = "Amdahl, BSP, MapReduce, Paxos e BFT" },
            new() { Nome = "Macroeconomia DSGE", Icone = "Yₜ", Cor = "#CA8A04", Descricao = "RBC, New Keynesian, Taylor e microeconomia avançada" },
            new() { Nome = "Econofísica", Icone = "📈", Cor = "#E11D48", Descricao = "Pareto, volatilidade, modelos de opinião e Bass" },
            new() { Nome = "Genética Quantitativa", Icone = "h²", Cor = "#16A34A", Descricao = "Herdabilidade, GWAS, BLUP e score poligênico" },
            new() { Nome = "Imunologia Computacional", Icone = "🛡", Cor = "#0369A1", Descricao = "Modelo HIV de Perelson e resposta imune adaptativa" },
            new() { Nome = "Privacidade Diferencial", Icone = "ε", Cor = "#7C2D12", Descricao = "DP, Laplace, Gaussiano, Rényi e aprendizado federado" },
            new() { Nome = "Blockchain e Consenso", Icone = "⛓", Cor = "#4338CA", Descricao = "PoW, PoS, Merkle, smart contracts e ZK-SNARK" },
            new() { Nome = "Computação Quântica Topológica", Icone = "τ", Cor = "#6B21A8", Descricao = "Anyons, Majoranas, Kitaev e CNOT topológico" },
            new() { Nome = "IA Explicável", Icone = "φ", Cor = "#EA580C", Descricao = "SHAP, LIME, Grad-CAM e Integrated Gradients" },
            new() { Nome = "Computação DNA e Neuromórfica", Icone = "🧬", Cor = "#10B981", Descricao = "DNA computing, CRN, SNN, STDP e neuromórficos" },
            new() { Nome = "Bioquímica Estrutural", Icone = "🔬", Cor = "#A21CAF", Descricao = "Dobramento de proteínas, Ramachandran e dinâmica molecular" },
            new() { Nome = "Hopfield e Ecologia", Icone = "⟲", Cor = "#64748B", Descricao = "Redes de Hopfield, memória associativa e metacomunidades" },
            // ── Volume 6 ──
            new() { Nome = "∞-Categorias e Teoria de Tipos", Icone = "∞", Cor = "#7C3AED", Descricao = "Categorias derivadas, ∞-categorias e teoria homotópica de tipos" },
            new() { Nome = "Sistemas Integráveis e TQFTs", Icone = "τ", Cor = "#DC2626", Descricao = "Equação de KdV, Lax pairs e TQFTs de Witten-Atiyah" },
            new() { Nome = "Geometria Tropical e Nós", Icone = "⊕", Cor = "#B45309", Descricao = "Geometria tropical, invariantes de nós e combinatória algébrica" },
            new() { Nome = "Sobolev e Distribuições", Icone = "W", Cor = "#059669", Descricao = "Espaços de Sobolev, distribuições de Schwartz e análise não-standard" },
            new() { Nome = "Lógica Modal e Computabilidade", Icone = "□", Cor = "#4338CA", Descricao = "Lógica modal, axiomas de ZFC e teoria da computabilidade" },
            new() { Nome = "Transporte Quântico e Topologia", Icone = "σ", Cor = "#1D4ED8", Descricao = "Landauer, efeito Hall quântico, isolantes topológicos e polârons" },
            new() { Nome = "Óptica Não-Linear e Atômica", Icone = "χ", Cor = "#B91C1C", Descricao = "Óptica não-linear, física atômica e física de superfícies" },
            new() { Nome = "Reologia e Biofísica de Membranas", Icone = "η", Cor = "#6D28D9", Descricao = "Reologia, eletrodinâmica em meios e biofísica de membranas" },
            new() { Nome = "Astrofísica e Gravitação Numérica", Icone = "★", Cor = "#0891B2", Descricao = "Estrelas de nêutrons, mecânica celeste avançada e relatividade numérica" },
            new() { Nome = "Normalizing Flows e Neural ODEs", Icone = "f⁻¹", Cor = "#16A34A", Descricao = "Normalizing flows, neural ODEs, EBMs e state space models" },
            new() { Nome = "Flow Matching e Meta-Learning", Icone = "ψ", Cor = "#9333EA", Descricao = "Flow matching, KAN, reservoir computing e meta-learning" },
            new() { Nome = "Information Bottleneck e Kernels", Icone = "I", Cor = "#EF4444", Descricao = "Information bottleneck, PAC-Bayes e métodos de kernel" },
            new() { Nome = "Fotônica e MEMS", Icone = "λ", Cor = "#EA580C", Descricao = "Fotônica integrada, MEMS/NEMS e tribologia" },
            new() { Nome = "Tráfego e Transferência Radiativa", Icone = "L", Cor = "#0E7490", Descricao = "Engenharia de tráfego, transferência radiativa e iluminação" },
            new() { Nome = "Sísmica e Eletroquímica", Icone = "⚡", Cor = "#78350F", Descricao = "Engenharia sísmica, eletroquímica e confiabilidade" },
            new() { Nome = "Biologia Sintética e scRNA-seq", Icone = "🧬", Cor = "#10B981", Descricao = "Biologia sintética, scRNA-seq e docking molecular" },
            new() { Nome = "Radiobiologia e fMRI", Icone = "☢", Cor = "#A21CAF", Descricao = "Radiobiologia, fMRI e cronobiologia" },
            new() { Nome = "Design de Mecanismos", Icone = "⚖", Cor = "#D97706", Descricao = "Leilões, matching, escolha social e teoria de Myerson" },
            new() { Nome = "Active Inference e Cognição", Icone = "F", Cor = "#E11D48", Descricao = "Active inference, psicologia computacional e linguística" },
            new() { Nome = "Geodesia e Ciências da Terra", Icone = "🌍", Cor = "#0284C7", Descricao = "Geodesia, química atmosférica e ciências oceânicas" },
            new() { Nome = "Visão Computacional e SLAM", Icone = "👁", Cor = "#4F46E5", Descricao = "Visão computacional avançada e robótica probabilística" },
            new() { Nome = "Verificação Formal e CPS", Icone = "✓", Cor = "#15803D", Descricao = "Verificação formal, sistemas cyber-físicos e tempo real" },
            new() { Nome = "Computação Quântica Avançada v2", Icone = "Q", Cor = "#6B21A8", Descricao = "Circuitos quânticos, comunicação quântica e memórias" },
            new() { Nome = "Plasma e Tokamak", Icone = "⊛", Cor = "#CA8A04", Descricao = "Plasma confinado, MHD e física de tokamak" },
            new() { Nome = "Teoria Conforme e SLE", Icone = "c", Cor = "#64748B", Descricao = "CFT, SLE estocástica e geometria discreta" },

            // ═══ VOLUME 7 — Novas categorias ═══
            // PARTE I — Matemática Elementar
            new() { Nome = "Matemática Elementar", Icone = "➕", Cor = "#2563EB", Descricao = "Operações fundamentais, porcentagem, regra de três e progressões" },
            // PARTE II — Saúde
            new() { Nome = "Farmácia", Icone = "💊", Cor = "#DC2626", Descricao = "Farmacocinética, diluições e dosagens" },
            new() { Nome = "Medicina", Icone = "🏥", Cor = "#B91C1C", Descricao = "Fisiologia, hemodinâmica e índices clínicos" },
            new() { Nome = "Medicina Veterinária", Icone = "🐾", Cor = "#92400E", Descricao = "Dosagem veterinária e taxa metabólica" },
            new() { Nome = "Nutrição", Icone = "🥗", Cor = "#16A34A", Descricao = "Metabolismo basal, IMC e gasto energético" },
            new() { Nome = "Física Médica", Icone = "☢", Cor = "#7C3AED", Descricao = "Dosimetria, radioterapia e decaimento radioativo" },
            new() { Nome = "Imagiologia", Icone = "📡", Cor = "#0891B2", Descricao = "Raios X, ultrassom e ressonância magnética" },
            // PARTE III — Agro-Ambiente
            new() { Nome = "Agronomia", Icone = "🌾", Cor = "#65A30D", Descricao = "Irrigação, evapotranspiração e correção de solo" },
            new() { Nome = "Ciências Florestais", Icone = "🌲", Cor = "#166534", Descricao = "Volume de madeira, biomassa e crescimento florestal" },
            new() { Nome = "Engenharia Ambiental", Icone = "♻", Cor = "#059669", Descricao = "Qualidade da água, DBO e tratamento de efluentes" },
            // PARTE IV — Engenharia
            new() { Nome = "Engenharia Civil", Icone = "🏗", Cor = "#78716C", Descricao = "Estruturas, concreto armado e geotecnia" },
            new() { Nome = "Engenharia Elétrica", Icone = "⚡", Cor = "#EAB308", Descricao = "Circuitos, potência e máquinas elétricas" },
            new() { Nome = "Engenharia Mecânica", Icone = "⚙", Cor = "#57534E", Descricao = "Resistência dos materiais, mecanismos e fadiga" },
            new() { Nome = "Engenharia Química", Icone = "⚗", Cor = "#A21CAF", Descricao = "Reatores, transferência de massa e catálise" },
            new() { Nome = "Engenharia Aeroespacial", Icone = "✈", Cor = "#1D4ED8", Descricao = "Aerodinâmica, propulsão e órbitas" },
            new() { Nome = "Engenharia Naval", Icone = "🚢", Cor = "#0369A1", Descricao = "Flutuabilidade, estabilidade e resistência ao avanço" },
            new() { Nome = "Engenharia de Controle", Icone = "🎛", Cor = "#6D28D9", Descricao = "PID, estabilidade e funções de transferência" },
            new() { Nome = "Fenômenos de Transporte", Icone = "↹", Cor = "#0D9488", Descricao = "Transferência de calor, massa e momento" },
            new() { Nome = "Energia Renovável", Icone = "🌿", Cor = "#4D7C0F", Descricao = "Solar, eólica, biomassa e eficiência energética" },
            new() { Nome = "Mecânica das Vibrações", Icone = "〰", Cor = "#B45309", Descricao = "Sistemas vibratórios, amortecimento e ressonância" },
            // PARTE V — Economia e Finanças
            new() { Nome = "Economia", Icone = "📈", Cor = "#0F766E", Descricao = "PIB, inflação, oferta e demanda" },
            new() { Nome = "Ciência Atuarial", Icone = "📋", Cor = "#4338CA", Descricao = "Reservas, anuidades e tábuas de mortalidade" },
            new() { Nome = "Microeconomia", Icone = "🏪", Cor = "#0E7490", Descricao = "Elasticidade, utilidade e equilíbrio de mercado" },
            new() { Nome = "Macroeconomia", Icone = "🏛", Cor = "#1E40AF", Descricao = "Multiplicador fiscal, IS-LM e política monetária" },
            // PARTE VI — Terra e Física
            new() { Nome = "Química Analítica", Icone = "🧪", Cor = "#9333EA", Descricao = "Titulação, espectrofotometria e cromatografia" },
            new() { Nome = "Geodésia e Topografia", Icone = "📏", Cor = "#0284C7", Descricao = "Levantamento, projeções e coordenadas geográficas" },
            new() { Nome = "Astronomia", Icone = "🔭", Cor = "#1E3A5F", Descricao = "Leis de Kepler, magnitudes e cosmologia observacional" },
            new() { Nome = "Geofísica", Icone = "🌋", Cor = "#9A3412", Descricao = "Sismologia, gravimetria e magnetismo terrestre" },
            new() { Nome = "Geoquímica", Icone = "Gq", Cor = "#78350F", Descricao = "Isótopos, datação radiométrica e geocronologia" },
            new() { Nome = "Oceanografia", Icone = "🌊", Cor = "#0E7490", Descricao = "Marés, correntes e salinidade oceânica" },
            new() { Nome = "Eletroquímica", Icone = "🔌", Cor = "#D97706", Descricao = "Células galvânicas, eletrólise e equação de Nernst" },
            new() { Nome = "Ciência dos Materiais", Icone = "🔩", Cor = "#475569", Descricao = "Propriedades mecânicas, cristalografia e difusão" },
            // PARTE VII — Bio-Comp-IA
            new() { Nome = "Ciências Esportivas", Icone = "🏃", Cor = "#059669", Descricao = "VO₂máx, gasto energético e fisiologia do exercício" },
            new() { Nome = "Biomecânica", Icone = "🦴", Cor = "#78716C", Descricao = "Torque articular, centro de massa e análise de marcha" },
            new() { Nome = "Bioestatística", Icone = "📊", Cor = "#7C3AED", Descricao = "Odds ratio, tamanho amostral e testes de hipótese" },
            new() { Nome = "Ecologia", Icone = "🌿", Cor = "#166534", Descricao = "Diversidade, cadeias tróficas e modelos populacionais" },
            new() { Nome = "Teoria das Redes", Icone = "🕸", Cor = "#4338CA", Descricao = "Grafos, redes complexas e mundos pequenos" },
            new() { Nome = "Psicofísica", Icone = "ψ", Cor = "#BE185D", Descricao = "Percepção sensorial, Weber-Fechner e Stevens" },
            new() { Nome = "Metrologia", Icone = "📐", Cor = "#64748B", Descricao = "Incerteza de medição, calibração e rastreabilidade" },
            new() { Nome = "Sistemas Complexos", Icone = "🔄", Cor = "#9333EA", Descricao = "Caos, fractais, Lyapunov e dinâmica não-linear" },
            new() { Nome = "Inteligência Artificial", Icone = "🤖", Cor = "#2563EB", Descricao = "Redes neurais, gradiente descendente e classificação" },
            // PARTE VIII + IX — Artes, Jogos, Foto
            new() { Nome = "Artesanato e Ofícios", Icone = "✂", Cor = "#D97706", Descricao = "Costura, marcenaria, cerâmica, culinária e ofícios" },
            new() { Nome = "Jogos e Recreação", Icone = "🎲", Cor = "#DC2626", Descricao = "Probabilidade em jogos, Elo, apostas e recreação" },
            new() { Nome = "Fotografia", Icone = "📸", Cor = "#1E40AF", Descricao = "Exposição, profundidade de campo e óptica fotográfica" },
            // PARTE X — Tecnologias Emergentes
            new() { Nome = "Criptografia", Icone = "🔐", Cor = "#4338CA", Descricao = "Cifras, RSA, curvas elípticas e entropia" },
            new() { Nome = "Computação Gráfica", Icone = "💡", Cor = "#7C3AED", Descricao = "Iluminação, transformações e interpolação" },
            new() { Nome = "Balística", Icone = "🎯", Cor = "#78350F", Descricao = "Trajetória de projéteis e coeficiente balístico" },
            new() { Nome = "Tecnologias Emergentes", Icone = "🔬", Cor = "#059669", Descricao = "5G, energia, blockchain, impressão 3D, CRISPR e quântica" },
            
            // ═══ VOLUME 8 e 9 — Categorias novas adicionadas ═══
            new() { Nome = "Teoria Jogos", Icone = "🎮", Cor = "#D97706", Descricao = "Nash, Bayesiano, Shapley, leilões, barganha e jogos dinâmicos" },
            new() { Nome = "Topologia Algébrica", Icone = "🔁", Cor = "#DC2626", Descricao = "Homologia, cohomologia, grupo fundamental, espectros e CW complexos" },
            new() { Nome = "Física Estatística", Icone = "⚡", Cor = "#BE185D", Descricao = "Boltzmann, entropia, partição, transições de fase e renormalização" },
            new() { Nome = "Controle Ótimo", Icone = "🎛", Cor = "#15803D", Descricao = "Pontryagin, Hamilton-Jacobi-Bellman, LQR, MPC e sistemas dinâmicos" },
            new() { Nome = "Aprendizado Reforço", Icone = "🧠", Cor = "#16A34A", Descricao = "MDP, Bellman, Q-Learning, SARSA, policy gradient, PPO e Actor-Critic" },
            
            // ═══ EXPANSÃO MASSIVA — 60+ novas categorias por domínio ═══
            // ─── FÍSICA AVANÇADA ───
            new() { Nome = "Mecânica Quântica I", Icone = "ψ", Cor = "#7C3AED", Descricao = "Equação de Schrödinger, operadores e autoestados" },
            new() { Nome = "Mecânica Quântica II", Icone = "Ĥ", Cor = "#6D28D9", Descricao = "Perturbação, WKB e segunda quantização" },
            new() { Nome = "Física de Plasma Avançada", Icone = "☀", Cor = "#EAB308", Descricao = "Magnetohidrodinâmica, instabilidades e pinch" },
            new() { Nome = "Física de Baixas Temperaturas", Icone = "❄", Cor = "#06B6D4", Descricao = "Hélio líquido, supercondutividade e superfluidez" },
            new() { Nome = "Astrofísica Estelar", Icone = "⭐", Cor = "#FBBF24", Descricao = "Evolução estelar, nucleossíntese e estrutura interna" },
            new() { Nome = "Cosmologia Moderna", Icone = "🌌", Cor = "#1E3A8A", Descricao = "Big Bang, inflação, matéria escura e energia escura" },
            new() { Nome = "Relatividade Especial", Icone = "c", Cor = "#1D4ED8", Descricao = "Transformações de Lorentz e espaço-tempo de Minkowski" },
            new() { Nome = "Relatividade Geral Avançada", Icone = "G", Cor = "#0E7490", Descricao = "Geodésicas, buraco negro e equações de Einstein" },
            new() { Nome = "Gravitação Quântica", Icone = "🌀", Cor = "#8B5CF6", Descricao = "Quantização da gravidade e gravidade de loop" },
            new() { Nome = "Teoria de Cordas", Icone = "∿", Cor = "#6B21A8", Descricao = "Branas, dualidades e compactificação" },
            new() { Nome = "Física da Matéria Escura", Icone = "💫", Cor = "#4C1D95", Descricao = "WIMPs, axions e detecção direta" },
            new() { Nome = "Física de Neutrinos", Icone = "ν", Cor = "#7C2D12", Descricao = "Oscilação de neutrinos e detecção" },
            
            // ─── MATEMÁTICA PURA AVANÇADA ───
            new() { Nome = "Análise Real Avançada", Icone = "ℝ", Cor = "#991B1B", Descricao = "Lebesgue, Radon-Nikodym e teorema convergência monótona" },
            new() { Nome = "Análise Complexa Profunda", Icone = "ℂ", Cor = "#4F46E5", Descricao = "Funções holomorfas, singularidades e superfícies de Riemann" },
            new() { Nome = "Álgebra Comutativa", Icone = "⊗", Cor = "#9333EA", Descricao = "Ideais, módulos, localização e noetherianidade" },
            new() { Nome = "Geometria Algébrica I", Icone = "𝒱", Cor = "#7C2D12", Descricao = "Variedades afins, esquemas e morfismos" },
            new() { Nome = "Geometria Algébrica II", Icone = "𝒪", Cor = "#7C2D12", Descricao = "Cohomologia de feixes e dualidade Serre" },
            new() { Nome = "Teoria dos Números Analítica", Icone = "ℓ", Cor = "#B45309", Descricao = "Funções zeta, distribuição de primos e hipótese de Riemann" },
            new() { Nome = "Teoria dos Números Algébrica", Icone = "𝒪ₖ", Cor = "#B45309", Descricao = "Corpos numéricos, ideais e leis de reciprocidade" },
            new() { Nome = "Formas Automórficas", Icone = "f", Cor = "#92400E", Descricao = "Grupo modular, formas modulares e séries de Eisenstein" },
            new() { Nome = "Representações de Galois", Icone = "ρ", Cor = "#78350F", Descricao = "Representações absolutas e deformações" },
            new() { Nome = "Geometria Simplética Avançada", Icone = "ω", Cor = "#7C3AED", Descricao = "Subvariedades lagrangianas e homologia floer" },
            new() { Nome = "Geometria Kähler", Icone = "₍ω₎", Cor = "#A855F7", Descricao = "Formas Kähler, curvatura de Ricci e superfícies" },
            new() { Nome = "Lógica Matemática Avançada", Icone = "⊧", Cor = "#4338CA", Descricao = "Teorema incompletude, teoria de modelos e computabilidade" },
            new() { Nome = "Teoria das Categorias Avançada", Icone = "⇒", Cor = "#059669", Descricao = "∞-categorias, derivadores e derivada functores" },
            
            // ─── ENGENHARIA CIVIL E CONSTRUÇÃO ───
            new() { Nome = "Engenharia Civil Estrutural", Icone = "🏗", Cor = "#78350F", Descricao = "Análise estrutural, armaduras e dimensionamento" },
            new() { Nome = "Engenharia de Solos", Icone = "🏜", Cor = "#92400E", Descricao = "Compactação, capacidade portante e fundações" },
            new() { Nome = "Engenharia Hidráulica", Icone = "💧", Cor = "#0E7490", Descricao = "Escoamento, fricção e sistemas de abastecimento" },
            new() { Nome = "Engenharia de Transportes", Icone = "🛣", Cor = "#475569", Descricao = "Tráfego, pavimentação e geometria viária" },
            
            // ─── ENGENHARIA MECÂNICA ───
            new() { Nome = "Dinâmica de Máquinas", Icone = "⚙", Cor = "#78350F", Descricao = "Mecanismos, cames e equilíbrio de rotores" },
            new() { Nome = "Resistência dos Materiais", Icone = "σ", Cor = "#92400E", Descricao = "Tensão, deformação, torção e flambagem" },
            new() { Nome = "Termoenergética e Motores", Icone = "🔥", Cor = "#DC2626", Descricao = "Ciclos termodinâmicos, motor e compressor" },
            new() { Nome = "Máquinas de Fluxo", Icone = "〰", Cor = "#0891B2", Descricao = "Bombas, turbinas e ventiladores" },
            new() { Nome = "Elementos de Máquinas", Icone = "⚡", Cor = "#EA580C", Descricao = "Engrenagens, rolamentos, correntes e correias" },
            new() { Nome = "Vibração Mecânica", Icone = "≈", Cor = "#B45309", Descricao = "Oscilações, ressonância e amortecimento" },
            new() { Nome = "Usinagem e Tecnologia Mecânica", Icone = "⚒", Cor = "#78350F", Descricao = "Torneamento, fresagem, qualidade de superfície" },
            
            // ─── ENGENHARIA ELÉTRICA ───
            new() { Nome = "Circuitos Elétricos I", Icone = "⚡", Cor = "#DC2626", Descricao = "Lei Ohm, Kirchhoff, análise nodal e análise de malhas" },
            new() { Nome = "Circuitos Elétricos II", Icone = "AC", Cor = "#991B1B", Descricao = "CA, impedância, ressonância e potência" },
            new() { Nome = "Eletromagnetismo Aplicado", Icone = "B", Cor = "#14B8A6", Descricao = "Campos, indução e máquinas elétricas" },
            new() { Nome = "Máquinas Elétricas", Icone = "M", Cor = "#0891B2", Descricao = "Motor CC, motor CA, transformador e gerador" },
            new() { Nome = "Sistemas de Potência", Icone = "🔌", Cor = "#CA8A04", Descricao = "Transmissão, distribuição, fluxo de carga" },
            new() { Nome = "Eletrônica Analógica", Icone = "◇", Cor = "#7C3AED", Descricao = "Transistores, amplificadores e osciladores" },
            new() { Nome = "Eletrônica Digital", Icone = "►", Cor = "#6D28D9", Descricao = "Lógica digital, flip-flops, microprocessadores" },
            new() { Nome = "Processamento de Sinais", Icone = "~", Cor = "#0E7490", Descricao = "FFT, filtros digitais e transformadas" },
            new() { Nome = "Sistemas de Controle I", Icone = "⊂", Cor = "#15803D", Descricao = "Funções transferência, resposta temporal" },
            new() { Nome = "Sistemas de Controle II", Icone = "⊃", Cor = "#106B37", Descricao = "Lugar das raízes, Bode, Nyquist e estabilidade" },
            
            // ─── ENGENHARIA QUÍMICA ───
            new() { Nome = "Termodinâmica Química", Icone = "ΔG", Cor = "#BE185D", Descricao = "Equilíbrio químico, potencial químico e fugacidade" },
            new() { Nome = "Cinética Química", Icone = "k", Cor = "#DB2777", Descricao = "Ordem reação, konstante velocidade e mecanismo" },
            new() { Nome = "Reatores Químicos", Icone = "🔬", Cor = "#9333EA", Descricao = "CSTR, PFR, RTD e conversão reação" },
            new() { Nome = "Separação e Purificação", Icone = "⬍", Cor = "#7C3AED", Descricao = "Destilação, absorção, extração, crystallização" },
            new() { Nome = "Transferência de Calor e Massa", Icone = "∇T", Cor = "#DC2626", Descricao = "Condução, convecção, radiação e evaporação" },
            new() { Nome = "Catálise", Icone = "→", Cor = "#EA580C", Descricao = "Mecanismos catalíticos e tipos de catalisadores" },
            
            // ─── BIOLOGIA E BIOQUÍMICA ───
            new() { Nome = "Biologia Molecular Avançada", Icone = "🧬", Cor = "#10B981", Descricao = "Replicação DNA, transcrição, tradução" },
            new() { Nome = "Genética Molecular", Icone = "📍", Cor = "#059669", Descricao = "Mutação, recombinação, epigenética" },
            new() { Nome = "Bioquímica Metabólica", Icone = "⊙", Cor = "#065F46", Descricao = "Glicolise, Krebs, fosforilação oxidativa" },
            new() { Nome = "Bioquímica Estrutural", Icone = "🔗", Cor = "#047857", Descricao = "Proteínas, enzimas, estrutura 3D" },
            new() { Nome = "Fisiologia Animal", Icone = "🫀", Cor = "#A21CAF", Descricao = "Sistemas corporais, homeostase, endócrino" },
            new() { Nome = "Fisiologia Vegetal", Icone = "🌿", Cor = "#15803D", Descricao = "Fotossíntese, transpiração, crescimento" },
            new() { Nome = "Microbiologia", Icone = "🦠", Cor = "#DC2626", Descricao = "Bactérias, vírus, fungos e parasitas" },
            new() { Nome = "Imunologia", Icone = "🛡", Cor = "#0369A1", Descricao = "Антигены, anticorpos, sistema imune adaptativo" },
            new() { Nome = "Ecologia de Populações", Icone = "📈", Cor = "#059669", Descricao = "Crescimento, competição, predação, sucessão" },
            new() { Nome = "Ecologia de Comunidades", Icone = "🌲", Cor = "#166534", Descricao = "Biodiversidade, redes tróficas, ciclos biogeoquímicos" },
            new() { Nome = "Biologia Evolutiva", Icone = "🔄", Cor = "#065F46", Descricao = "Seleção natural, deriva genética, especiação" },
            new() { Nome = "Biologia Comportamental", Icone = "🦁", Cor = "#92400E", Descricao = "Etologia, aprendizado animal, comunicação" },
            new() { Nome = "Neurobiologia", Icone = "🧠", Cor = "#7C3AED", Descricao = "Neurônios, sinapses, potencial ação, neurotransmissores" },
            new() { Nome = "Psicologia Evolutiva", Icone = "👥", Cor = "#6D28D9", Descricao = "Comportamento humano e origem" },
            new() { Nome = "Toxicologia", Icone = "☠", Cor = "#DC2626", Descricao = "Toxinas, dose-resposta e mecanismo tóxico" },
            new() { Nome = "Farmacologia", Icone = "💊", Cor = "#E11D48", Descricao = "Fármacos, receptores, agonistas e antagonistas" },
            
            // ─── CIÊNCIA DA COMPUTAÇÃO ───
            new() { Nome = "Estruturas de Dados", Icone = "📦", Cor = "#64748B", Descricao = "Listas, árvores, grafos, hash tables" },
            new() { Nome = "Algoritmos I", Icone = "F→O", Cor = "#475569", Descricao = "Busca, ordenação, PD, guloso" },
            new() { Nome = "Algoritmos II", Icone = "NP", Cor = "#334155", Descricao = "Grafos, fluxo, emparelhamento" },
            new() { Nome = "Compiladores e Intérpretes", Icone = "⟨⟩", Cor = "#78350F", Descricao = "Léxica, sintaxe, semântica, geração código" },
            new() { Nome = "Linguagens de Programação", Icone = "{ }", Cor = "#92400E", Descricao = "Paradigmas imperativo, funcional, orientado objeto" },
            new() { Nome = "Engenharia de Software", Icone = "🔨", Cor = "#B45309", Descricao = "Design patterns, refatoração, testes" },
            new() { Nome = "Bases de Dados I", Icone = "🗄", Cor = "#0E7490", Descricao = "Modelo relacional, SQL, normalização" },
            new() { Nome = "Bases de Dados II", Icone = "DB", Cor = "#0891B2", Descricao = "Índices, transações, ACID, NoSQL" },
            new() { Nome = "Redes de Computadores I", Icone = "🌐", Cor = "#0EA5E9", Descricao = "OSI, TCP/IP, HTTP, DNS" },
            new() { Nome = "Redes de Computadores II", Icone = "📡", Cor = "#0284C7", Descricao = "Roteamento, congestionamento, QoS" },
            new() { Nome = "Criptografia Clássica", Icone = "🔐", Cor = "#4338CA", Descricao = "Cifras simétricas, DES, AES" },
            new() { Nome = "Criptografia Assimétrica", Icone = "🔒", Cor = "#4F46E5", Descricao = "RSA, ECC, assinatura digital" },
            new() { Nome = "Segurança da Informação", Icone = "🛡", Cor = "#6366F1", Descricao = "Malware, phishing, autenticação, autorização" },
            new() { Nome = "Visão Computacional I", Icone = "👁", Cor = "#A21CAF", Descricao = "Processamento imagem, filtros, detecção bordas" },
            new() { Nome = "Visão Computacional II", Icone = "🔍", Cor = "#C084FC", Descricao = "Reconhecimento objeto, segmentação, rastreamento" },
            new() { Nome = "Processamento Linguagem Natural", Icone = "📝", Cor = "#7C3AED", Descricao = "Tokenização, POS tagging, análise sintática" },
            new() { Nome = "Machine Learning Clássico", Icone = "🤖", Cor = "#6B21A8", Descricao = "SVM, random forest, regressão, clustering" },
            new() { Nome = "Deep Learning I", Icone = "🧠", Cor = "#5B21B6", Descricao = "Redes neurais, backpropagation, CNN, RNN" },
            new() { Nome = "Deep Learning II", Icone = "Σ", Cor = "#6D28D9", Descricao = "LSTM, Transformers, GANs, attention" },
            new() { Nome = "Processamento Distribuído", Icone = "||", Cor = "#15803D", Descricao = "MapReduce, Spark, sistemas distribuídos" },
            new() { Nome = "Computação em Nuvem", Icone = "☁", Cor = "#0EA5E9", Descricao = "AWS, Azure, Google Cloud, containerização" },
            
            // ─── MATEMÁTICA DISCRETA E LÓGICA ───
            new() { Nome = "Teoria dos Grafos Avançada", Icone = "⊙", Cor = "#C2410C", Descricao = "Coloração, Hamiltoniano, euleriano, planaridade" },
            new() { Nome = "Combinatória", Icone = "⊂", Cor = "#DC2626", Descricao = "Permutações, combinações, princípio inclusão-exclusão" },
            new() { Nome = "Teoria da Codificação", Icone = "0101", Cor = "#EA580C", Descricao = "Códigos linear, Hamming, Reed-Solomon" },
            
            // ─── ESTATÍSTICA AVANÇADA ───
            new() { Nome = "Análise Multivariada Avançada", Icone = "Σ", Cor = "#047857", Descricao = "Análise fator, componentes principais, discriminante" },
            new() { Nome = "Séries Temporais Avançada", Icone = "Xₜ", Cor = "#92400E", Descricao = "ARIMA, GARCH, decomposição sazonal" },
            new() { Nome = "Métodos Bayesianos Avançados", Icone = "θ", Cor = "#7E22CE", Descricao = "MCMC, inferência variacional, hierarchical models" },
            new() { Nome = "Estatística Não-Paramétrica", Icone = "F", Cor = "#6B21A8", Descricao = "Testes permutação, bootstrap, resampling" },
            new() { Nome = "Análise de Sobrevivência Avançada", Icone = "Ŝ", Cor = "#10B981", Descricao = "Kaplan-Meier, Cox, competing risks" },

            // ─── VOLUME XI ───
            new() { Nome = "Vol XI - Astrofisica Estelar", Icone = "★", Cor = "#1D4ED8", Descricao = "Equacoes de estrutura e evolucao estelar" },
            new() { Nome = "Vol XI - Fusao Termonuclear", Icone = "☢", Cor = "#B91C1C", Descricao = "Confinamento, ignicao e ganho energetico em plasma" },
            new() { Nome = "Vol XI - Engenharia de Petroleo", Icone = "🛢", Cor = "#92400E", Descricao = "Reservatorios, escoamento e produtividade" },
            new() { Nome = "Vol XI - Ciencia de Polimeros", Icone = "🧪", Cor = "#7C3AED", Descricao = "Reologia, cinetica e propriedades de polimeros" },
            new() { Nome = "Vol XI - Geofisica e Sismologia", Icone = "🌍", Cor = "#0F766E", Descricao = "Ondas sismicas, energia e risco geofisico" },
            new() { Nome = "Vol XI - Fotonica e Optica Quantica", Icone = "💡", Cor = "#EA580C", Descricao = "Interacao luz-materia e sistemas fotonicos" },
            new() { Nome = "Vol XI - Ciencia de Dados e ML", Icone = "🧠", Cor = "#6D28D9", Descricao = "Modelagem estatistica e aprendizado de maquina" },
            new() { Nome = "Vol XI - Biomecanica Cardiovascular", Icone = "🫀", Cor = "#BE185D", Descricao = "Hemodinamica e mecanica de tecidos cardiovasculares" },
            new() { Nome = "Vol XI - Engenharia de Controle", Icone = "🎛", Cor = "#15803D", Descricao = "Projeto, estabilidade e robustez de controladores" },
            new() { Nome = "Vol XI - Engenharia Ambiental", Icone = "♻", Cor = "#16A34A", Descricao = "Balancos, remocao de poluentes e risco ambiental" },
            new() { Nome = "Vol XI - Engenharia Nuclear", Icone = "⚛", Cor = "#334155", Descricao = "Criticidade, termohidraulica e seguranca nuclear" },
            new() { Nome = "Vol XI - Meteorologia e Clima", Icone = "🌦", Cor = "#0284C7", Descricao = "Indicadores atmosfericos e dinamica climatica" },
            new() { Nome = "Vol XI - Fisica de Semicondutores", Icone = "🔋", Cor = "#4F46E5", Descricao = "Transporte de portadores e dispositivos" },
            new() { Nome = "Vol XI - Linguistica Computacional", Icone = "🗣", Cor = "#0EA5E9", Descricao = "Modelos probabilisticos e metricas de linguagem" },
            new() { Nome = "Vol XI - Microfluidica e Biotecnologia", Icone = "🧫", Cor = "#0D9488", Descricao = "Escoamento em microescala e bioprocessos" },
            new() { Nome = "Vol XI - Fontes de Energia Renovavel", Icone = "☀", Cor = "#CA8A04", Descricao = "Conversao e eficiencia em sistemas renovaveis" },
            new() { Nome = "Vol XI - Fisica de Plasma e MHD", Icone = "🌐", Cor = "#2563EB", Descricao = "Estabilidade magnetica e transporte em plasma" },
            new() { Nome = "Vol XI - Matematica Financeira", Icone = "💰", Cor = "#059669", Descricao = "Desconto, risco e avaliacao de projetos" },
            new() { Nome = "Vol XI - Engenharia Aeroespacial", Icone = "✈", Cor = "#9333EA", Descricao = "Desempenho aerodinamico e propulsao" },
            new() { Nome = "Vol XI - Matematica Pura Avancada", Icone = "∞", Cor = "#7C2D12", Descricao = "Modelos abstratos e criterios de convergencia" },
        ]);
    }

    private void InicializarFormulas()
    {
        AdicionarAlgebra();
        AdicionarGeometria();
        AdicionarTrigonometria();
        AdicionarCalculo();
        AdicionarAlgebraLinear();
        AdicionarEquacoesDiferenciais();
        AdicionarProbabilidade();
        AdicionarEstatistica();
        AdicionarMecanicaClassica();
        AdicionarTermodinamica();
        AdicionarEletromagnetismo();
        AdicionarOptica();
        AdicionarMecanicaFluidos();
            AdicionarEngenharia();

            // ══════════════════════════════════════════════════════════
            // VOLUME 2 — COMPLETO: Matemática, Física, Stats, Computação, Engenharia, Bio
            // ══════════════════════════════════════════════════════════
                AdicionarMatematicaPuraAvancada(); // Álgebra Abstrata, Topologia, Geometria Diferencial, Cálculo de Variações, Funções Especiais, Análise Complexa
                AdicionarFisicaAvancada(); // Mecânica Lagrangiana/Hamiltoniana, Mecânica Estatística, Relatividade Geral
            AdicionarSeriesTemporaisCompleta();
            AdicionarAnaliseMultivariadaCompleta();
            AdicionarEstatisticaBayesianaCompleta();
            AdicionarTeoriaGrafosCompleta();
            AdicionarProcessamentoSinaisCompleto();
            AdicionarDeepLearningCompleto();
            AdicionarComputacaoQuanticaCompleto();
            AdicionarControleAutomaticoCompleto();
            AdicionarAntenasCompleto();
            AdicionarProcessamentoImagemCompleto();
            AdicionarDinamicaPopulacoesCompleta();
            AdicionarFarmacocineticaCompleta();
            AdicionarNeurocienciaCompleta();
        AdicionarBiologiaMatematica();
        AdicionarComputacao();

        // ══════════════════════════════════════════════════════════
        // VOLUME 2 — RESTAURAÇÃO: Fórmulas originais detalhadas
        // ══════════════════════════════════════════════════════════
        AdicionarAlgebraAbstrata();
        AdicionarTopologia();
        AdicionarGeometriaDiferencial();
        AdicionarCalculoVariacoes();
        AdicionarFuncoesEspeciais();
        AdicionarAnaliseComplexa();
        AdicionarMecanicaAnalitica();
        AdicionarMecanicaEstatistica();
        AdicionarTeoriaQuanticaCampos();
        AdicionarRelatividadeGeral();
        AdicionarSeriesTemporais();
        AdicionarAnaliseMultivariada();
        AdicionarEstatisticaBayesiana();
        AdicionarTeoriaGrafos();
        AdicionarProcessamentoSinais();
        AdicionarDeepLearning();
        AdicionarComputacaoQuantica();
        AdicionarControleAutomatico();
        AdicionarProcessamentoImagem();
        AdicionarAntenaseTelecom();
        AdicionarEpidemiologia();
        AdicionarFarmacocinetica();
        AdicionarNeurocienciaComputacional();
        AdicionarAlgebraAbstrataCompleta();
        AdicionarTopologiaCompleta();
        AdicionarGeometriaDiferencialCompleta();
        AdicionarCalculoVariacoesCompleto();
        AdicionarFuncoesEspeciaisCompleta();
        AdicionarAnaliseComplexaCompleta();
        AdicionarMecanicaLagrangianaCompleta();
        AdicionarMecanicaEstatisticaCompleta();
        AdicionarRelatividadeGeralCompleta();

        // ── Volume 3 (versao calculavel completa) ──
        AdicionarAnaliseFuncionalCompleta();
        AdicionarTeoriaMedidaCompleta();
        AdicionarTeoriaCategoriasCompleta();
        AdicionarAnaliseNumericaCompleta();
        AdicionarGeometriaAlgebricaCompleta();
        AdicionarLogicaMatematicaCompleta();
        AdicionarMateriaCondensadaCompleta();
        AdicionarCaosFractaisCompleta();
        AdicionarFisicaPlasmasCompleta();
        AdicionarFisicaNuclearCompleta();
        AdicionarOpticaQuanticaCompleta();
        AdicionarAnaliseSobrevivenciaCompleta();
        AdicionarValoresExtremosCompleta();
        AdicionarGeoestatisticaCompleta();
        AdicionarMecanicaFraturaCompleta();
        AdicionarCFDTurbulenciaCompleta();
        AdicionarRoboticaCompleta();
        AdicionarSistemasPotenciaCompleta();
        AdicionarFinancasQuantitativasCompleta();
        AdicionarPesquisaOperacionalCompleta();
        AdicionarCienciasClimaCompleta();
        AdicionarBioinformaticaCompleta();
        AdicionarAcusticaCompleta();
        AdicionarVolume3Complementos();
        AdicionarVolume3FechamentoTotal();

        // ══════════════════════════════════════════════════════════
        // VOLUME 3 — RESTAURAÇÃO: Fórmulas originais detalhadas
        // ══════════════════════════════════════════════════════════
        AdicionarAnaliseFuncional();
        AdicionarTeoriaMedida();
        AdicionarTeoriaCategorias();
        AdicionarAnaliseNumerica();
        AdicionarGeometriaAlgebrica();
        AdicionarLogicaMatematica();
        AdicionarMateriaCondensada();
        AdicionarCaosFractais();
        AdicionarFisicaPlasmas();
        AdicionarFisicaNuclear();
        AdicionarOpticaQuantica();
        AdicionarAnaliseSobrevivencia();
        AdicionarValoresExtremos();
        AdicionarGeoestatistica();
        AdicionarMecanicaFratura();
        AdicionarCFDTurbulencia();
        AdicionarRobotica();
        AdicionarSistemasPotencia();
        AdicionarFinancasQuantitativas();
        AdicionarPesquisaOperacional();
        AdicionarCienciasClima();
        AdicionarBioinformatica();
        AdicionarAcustica();

        // ── Volume 4 ──
        AdicionarGeometriaSipletica();
        AdicionarTopologiaAlgebricaAvancada();
        AdicionarFormasModulares();
        AdicionarTeoriaErgodica();
        AdicionarAnalisePAdica();
        AdicionarRenormalizacaoSUSY();
        AdicionarAdSCFT();
        AdicionarCosmologiaInflacionaria();
        AdicionarGravidadeQuanticaCordas();
        AdicionarAprendizadoReforco();
        AdicionarGNNGeometriaProfunda();
        AdicionarTransporteOtimoTDA();
        AdicionarInferenciaCausal();
        AdicionarAltaDimensionalidade();
        AdicionarControleNaoLinearOtimo();
        AdicionarDispositivosSemicondutores();
        AdicionarCodificacaoComunicacoes();
        AdicionarHidrologiaCombustao();
        AdicionarMorfogeneseTuring();
        AdicionarImagemMedica();
        AdicionarPsicometriaIRT();
        AdicionarTeoriaDosJogos();
        AdicionarRedesComplexas();
        AdicionarCriptografiaPosQuantica();
        AdicionarInfoQuanticaAvancada();

        // ── Volume 5 ──
        AdicionarTeoriaDeLie();
        AdicionarNumerosAlgebricos();
        AdicionarGeometriaRiemanniana();
        AdicionarAnaliseHarmonica();
        AdicionarGeometriaNaoComutativa();
        AdicionarMecanicaCeleste();
        AdicionarMagnetismoMateriaMole();
        AdicionarCristalografia();
        AdicionarProcessosGaussianos();
        AdicionarOtimizacaoConvexa();
        AdicionarICAMisturas();
        AdicionarAlgoritmosAproximacao();
        AdicionarRedesComputadores();
        AdicionarCompiladoresAutomatos();
        AdicionarComputacaoParalela();
        AdicionarMacroeconomiaDSGE();
        AdicionarDSGEAvancado();
        AdicionarMicroeconomiaAvancada();
        AdicionarEconofisica();
        AdicionarSociofisica();
        AdicionarGeneticaQuantitativa();
        AdicionarGeneticaQuantitativaAvancada();
        AdicionarImunologiaComputacional();
        AdicionarImunologiaAvancada();
        AdicionarPrivacidadeDiferencial();
        AdicionarAprendizadoFederado();
        AdicionarBlockchainConsenso();
        AdicionarComputacaoQuanticaTopologica();
        AdicionarIAExplicavel();
        AdicionarComputacaoDNANeuromorfica();
        AdicionarBioquimicaEstrutural();
        AdicionarHopfieldEcologia();
        AdicionarTeoriaLieRepresentacoes();
        AdicionarTeoriaNumeros();

        // ── Volume 6 ──
        AdicionarInfCategorias();
        AdicionarSistemasIntegraveis();
        AdicionarGeometriaTropicalNos();
        AdicionarSobolevDistribuicoes();
        AdicionarLogicaModalComputabilidade();
        AdicionarTransporteQuanticoTopologia();
        AdicionarOpticaNaoLinear();
        AdicionarReologiaBiofisica();
        AdicionarAstrofisicaGravitacao();
        AdicionarNormalizingFlows();
        AdicionarFlowMatchingMeta();
        AdicionarInfoBottleneckKernels();
        AdicionarFotonicaMEMS();
        AdicionarTrafegoRadiativa();
        AdicionarSismicaEletroquimica();
        AdicionarBiologiaSintetica();
        AdicionarRadiobiologiaFMRI();
        AdicionarDesignMecanismos();
        AdicionarActiveInference();
        AdicionarGeodesiaTerrestre();
        AdicionarVisaoComputacional();
        AdicionarVerificacaoFormal();
        AdicionarComputacaoQuanticaAvancadaV2();
        AdicionarPlasmaTokamak();
        AdicionarTeoriaConformeSLE();

        // ═══ VOLUME 7 ═══
        AdicionarVol7MatematicaElementar();
        AdicionarVol7Saude();
        AdicionarVol7AgroAmbiente();
        AdicionarVol7Engenharia();
        AdicionarVol7EconFinancas();
        AdicionarVol7TerraFisica();
        AdicionarVol7JogosFoto();
        AdicionarVol7BioCompIA();
        AdicionarVol7Artesanato();
        AdicionarVol7TechEmergente();

        // ═══ VOLUME 9 — COMPÊNDIO GERAL DE EQUAÇÕES ═══
        // 360 fórmulas: Teoria dos Jogos até Relatividade Geral
        InicializarFormulasVol9();

    // ═══ VOLUME 10 — COMPÊNDIO GERAL DE EQUAÇÕES ═══
    // 395 fórmulas: Computação Quântica até Mecânica Estatística de Não-Equilíbrio
    AdicionarFormulasVol10();

    // ═══ VOLUME 11 — COMPÊNDIO GERAL DE EQUAÇÕES ═══
    // 400 fórmulas: 20 áreas avançadas com descrição, exemplo, variáveis e origem
    AdicionarFormulasVol11();

    // ═══ FÓRMULAS FALTANTES (GERADOR AUTOMÁTICO) ═══
        // Adiciona 310 fórmulas dinâmicas para atingir 3588 total
        // 102 do V9 (001-102) + 65 V1-V7 distribuídas
        _formulas.AddRange(FormulaGeneradorFaltantes.GerarFormulasAusentes());

        // ═══ CARREGAMENTO DE V8 VIA FACTORY ═══
        // V1 e V5 JÁ são carregados via métodos diretos (AdicionarAlgebra, AdicionarTeoriaDeLie, etc.)
        // V8 APENAS é carregado via factory, então precisa ser incluído aqui
        AdicionarFormulasFactoryV8();

        // Harmoniza categorias para evitar fórmulas em buckets genéricos/inconsistentes.
        NormalizarCategoriasDasFormulas();

        // Update category counts
        foreach (var cat in _categorias)
        {
            cat.TotalFormulas = _formulas.Count(f => f.Categoria == cat.Nome);
        }
    }

    private void AdicionarFormulasFactoryV8()
    {
        var formulasFactory = typeof(FormulaService)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m =>
                m.ReturnType == typeof(Formula)
                && m.GetParameters().Length == 0
                && m.Name.StartsWith("V8_", StringComparison.Ordinal))
            .OrderBy(m => m.Name, StringComparer.Ordinal)
            .Select(m => m.Invoke(null, null) as Formula)
            .Where(f => f is not null)
            .Cast<Formula>();

        _formulas.AddRange(formulasFactory);
    }

    private void NormalizarCategoriasDasFormulas()
    {
        var aliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Teoria Jogos"] = "Teoria dos Jogos",
            ["Aprendizado Reforço"] = "Aprendizado por Reforço",
            ["Controle Ótimo"] = "Controle Não-Linear e Ótimo",
            ["Física Estatística"] = "Mecânica Estatística",
            ["Topologia Algébrica"] = "Topologia Algébrica Avançada",
            ["Matemática Aplicada"] = "Matemática Elementar"
        };

        foreach (var f in _formulas)
        {
            var categoria = (f.Categoria ?? string.Empty).Trim();
            var subCategoria = (f.SubCategoria ?? string.Empty).Trim();

            // Volume IX usa área em SubCategoria; promove para categoria principal.
            if (categoria.Equals("Volume IX", StringComparison.OrdinalIgnoreCase)
                && !string.IsNullOrWhiteSpace(subCategoria))
            {
                categoria = subCategoria;
            }

            if (aliases.TryGetValue(categoria, out var canonica))
            {
                categoria = canonica;
            }

            if (string.IsNullOrWhiteSpace(categoria) && !string.IsNullOrWhiteSpace(subCategoria))
            {
                categoria = subCategoria;
            }

            if (!string.IsNullOrWhiteSpace(categoria))
            {
                f.Categoria = categoria;
            }
        }
    }

    private void AdicionarFormulasFactoryVol1EVol5()
    {
        var formulasFactory = typeof(FormulaService)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m =>
                m.ReturnType == typeof(Formula)
                && m.GetParameters().Length == 0
                && (m.Name.StartsWith("V1_", StringComparison.Ordinal)
                    || m.Name.StartsWith("V5_", StringComparison.Ordinal)
                    || m.Name.StartsWith("V8_", StringComparison.Ordinal)))
            .OrderBy(m => m.Name, StringComparer.Ordinal)
            .Select(m => m.Invoke(null, null) as Formula)
            .Where(f => f is not null)
            .Cast<Formula>();

        _formulas.AddRange(formulasFactory);
    }

    // ─────────────────────────────────────────────────────
    // ÁLGEBRA
    // ─────────────────────────────────────────────────────
    private void AdicionarAlgebra()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "alg001", Nome = "Equação do 2º Grau (Fórmula de Bhaskara)", Categoria = "Álgebra",
                Expressao = "x = (-b ± √(b²-4ac)) / 2a",
                ExprTexto = "x = (−b ± √(b²−4ac)) / 2a",
                Icone = "𝑥²",
                Descricao = "Resolve toda equação quadrática ax²+bx+c=0. O discriminante Δ=b²-4ac determina a natureza das raízes: Δ>0 duas raízes reais distintas, Δ=0 raiz dupla, Δ<0 raízes complexas.",
                Criador = "Bhāskara II (Índia, séc. XII); generalização do método babilônico",
                AnoOrigin = "~1150 d.C.",
                ExemploPratico = "Calcular quando uma bola atingirá o solo: h(t)=−5t²+20t+2=0. Com a=−5, b=20, c=2 → t≈4.1s",
                Unidades = "Adimensional (raízes numéricas)",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Coeficiente a", Descricao = "Coeficiente do termo quadrático (≠ 0)", ValorPadrao = 1 },
                    new() { Simbolo = "b", Nome = "Coeficiente b", Descricao = "Coeficiente do termo linear", ValorPadrao = -5 },
                    new() { Simbolo = "c", Nome = "Coeficiente c", Descricao = "Termo independente", ValorPadrao = 6 },
                ],
                VariavelResultado = "Δ (discriminante)",
                UnidadeResultado = "",
                Calcular = vars => {
                    double a = vars["a"], b = vars["b"], c = vars["c"];
                    return b * b - 4 * a * c; // Retorna discriminante; UI mostra raízes
                }
            },
            new Formula
            {
                Id = "alg002", Nome = "Progressão Aritmética — Termo Geral", Categoria = "Álgebra",
                Expressao = "aₙ = a₁ + (n-1)·r",
                ExprTexto = "aₙ = a₁ + (n − 1) · r",
                Icone = "PA",
                Descricao = "Calcula o n-ésimo termo de uma PA com primeiro termo a₁ e razão r. A diferença entre termos consecutivos é sempre igual a r.",
                Criador = "Conhecimento matemático antigo; sistematizado por Euclides (~300 a.C.)",
                AnoOrigin = "Antiguidade",
                ExemploPratico = "Salário: R$2.000 no mês 1, aumento de R$150/mês. Salário no mês 12: a₁₂ = 2000+(12-1)×150 = R$3.650",
                Variaveis = [
                    new() { Simbolo = "a1", Nome = "Primeiro Termo (a₁)", Descricao = "Valor do primeiro elemento da sequência", ValorPadrao = 2 },
                    new() { Simbolo = "r", Nome = "Razão (r)", Descricao = "Diferença entre termos consecutivos", ValorPadrao = 3 },
                    new() { Simbolo = "n", Nome = "Posição (n)", Descricao = "Índice do termo desejado", ValorPadrao = 10, ValorMin = 1 },
                ],
                VariavelResultado = "aₙ",
                Calcular = vars => vars["a1"] + (vars["n"] - 1) * vars["r"]
            },
            new Formula
            {
                Id = "alg003", Nome = "Progressão Aritmética — Soma", Categoria = "Álgebra",
                Expressao = "Sₙ = n·(a₁ + aₙ) / 2",
                ExprTexto = "Sₙ = n · (a₁ + aₙ) / 2",
                Icone = "ΣPA",
                Descricao = "Soma dos n primeiros termos de uma PA. Equivale a multiplicar a média dos extremos pelo número de termos. Gauss a descobriu aos 10 anos somando 1+2+…+100=5050.",
                Criador = "Carl Friedrich Gauss (1777–1855); lenda dos 10 anos de idade",
                ExemploPratico = "Número total de assentos em teatro com 20 fileiras: 1ª fileira 10, última 48 (PA). S₂₀=20×(10+48)/2=580 assentos",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Número de termos (n)", ValorPadrao = 20, ValorMin = 1 },
                    new() { Simbolo = "a1", Nome = "Primeiro Termo (a₁)", ValorPadrao = 10 },
                    new() { Simbolo = "an", Nome = "Último Termo (aₙ)", ValorPadrao = 48 },
                ],
                VariavelResultado = "Sₙ",
                Calcular = vars => vars["n"] * (vars["a1"] + vars["an"]) / 2.0
            },
            new Formula
            {
                Id = "alg004", Nome = "Progressão Geométrica — Termo Geral", Categoria = "Álgebra",
                Expressao = "aₙ = a₁ · qⁿ⁻¹",
                ExprTexto = "aₙ = a₁ · q^(n−1)",
                Icone = "PG",
                Descricao = "Calcula o n-ésimo termo de uma PG com razão q. A razão entre termos consecutivos é sempre q. Modelagem de crescimento exponencial.",
                Criador = "Euclides; Arquimedes; Teoria desenvolvida na Grécia Antiga",
                ExemploPratico = "Investimento com juros compostos de 10% ao mês. Valor após 6 meses: a₆ = 1000×1,1⁵ = R$1.610,51",
                Variaveis = [
                    new() { Simbolo = "a1", Nome = "Primeiro Termo (a₁)", ValorPadrao = 1000 },
                    new() { Simbolo = "q", Nome = "Razão (q)", Descricao = "Fator multiplicativo entre termos", ValorPadrao = 1.1 },
                    new() { Simbolo = "n", Nome = "Posição (n)", ValorPadrao = 6, ValorMin = 1 },
                ],
                VariavelResultado = "aₙ",
                Calcular = vars => vars["a1"] * Math.Pow(vars["q"], vars["n"] - 1)
            },
            new Formula
            {
                Id = "alg005", Nome = "Juros Compostos", Categoria = "Álgebra",
                Expressao = "M = C · (1 + i)ⁿ",
                ExprTexto = "M = C · (1 + i)^n",
                Icone = "J%",
                Descricao = "Montante M após n períodos de capital C a taxa i por período. Os juros de cada período incidem sobre o montante acumulado, gerando crescimento exponencial.",
                Criador = "Fibonacci (Liber Abaci, 1202); formalizado por matemáticos medievais europeus",
                AnoOrigin = "1202",
                ExemploPratico = "R$10.000 aplicados por 2 anos a 12% ao ano: M = 10000×(1,12)² = R$12.544. Comparar com juros simples: R$12.400",
                Unidades = "Reais, dólares, ou qualquer moeda",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "Capital (C)", Descricao = "Valor inicial investido", ValorPadrao = 10000 },
                    new() { Simbolo = "i", Nome = "Taxa de juros (i)", Descricao = "Taxa por período (0.12 = 12%)", ValorPadrao = 0.12 },
                    new() { Simbolo = "n", Nome = "Número de períodos (n)", ValorPadrao = 2, ValorMin = 0 },
                ],
                VariavelResultado = "M (Montante)",
                Calcular = vars => vars["C"] * Math.Pow(1 + vars["i"], vars["n"])
            },
            new Formula
            {
                Id = "alg006", Nome = "Binômio de Newton — Coeficiente", Categoria = "Álgebra",
                Expressao = "C(n,k) = n! / (k!·(n-k)!)",
                ExprTexto = "C(n,k) = n! / (k! · (n−k)!)",
                Icone = "C(n,k)",
                Descricao = "Coeficiente binomial, número de formas de escolher k elementos de n sem ordem. Base do Binômio de Newton: (a+b)ⁿ = Σ C(n,k)·aⁿ⁻ᵏ·bᵏ. Aparece no Triângulo de Pascal.",
                Criador = "Pascal (Traité du triangle arithmétique, 1654); baseado em trabalhos anteriores de Al-Karaji e Yang Hui",
                ExemploPratico = "Número de maneiras de escolher 3 projetos de 10: C(10,3)=120. Em apostas, probabilidade de 6 em 60: C(60,6)=50.063.860",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Total (n)", Descricao = "Total de elementos", ValorPadrao = 10, ValorMin = 0 },
                    new() { Simbolo = "k", Nome = "Escolhidos (k)", Descricao = "Quantidade a escolher (k≤n)", ValorPadrao = 3, ValorMin = 0 },
                ],
                VariavelResultado = "C(n,k)",
                Calcular = vars => {
                    int n = (int)vars["n"], k = (int)vars["k"];
                    if (k > n || k < 0) return double.NaN;
                    return Fatorial(n) / (Fatorial(k) * Fatorial(n - k));
                }
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // GEOMETRIA
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometria()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "geo001", Nome = "Teorema de Pitágoras", Categoria = "Geometria",
                Expressao = "c² = a² + b²",
                ExprTexto = "c² = a² + b²",
                Icone = "△",
                Descricao = "Em um triângulo retângulo, o quadrado da hipotenusa (c) é igual à soma dos quadrados dos catetos (a, b). Um dos resultados mais fundamentais da matemática.",
                Criador = "Pitágoras de Samos (~570–495 a.C.); conhecido pelos babilônios ~1000 anos antes",
                AnoOrigin = "~530 a.C.",
                ExemploPratico = "Calcular a diagonal de uma tela 16×9 polegadas: c=√(256+81)=√337≈18.4 polegadas (tela de ~18 polegadas)",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Cateto a", ValorPadrao = 3, ValorMin = 0 },
                    new() { Simbolo = "b", Nome = "Cateto b", ValorPadrao = 4, ValorMin = 0 },
                ],
                VariavelResultado = "c (Hipotenusa)",
                Calcular = vars => Math.Sqrt(vars["a"] * vars["a"] + vars["b"] * vars["b"])
            },
            new Formula
            {
                Id = "geo002", Nome = "Área do Triângulo (Heron)", Categoria = "Geometria",
                Expressao = "A = √(s(s-a)(s-b)(s-c));  s=(a+b+c)/2",
                ExprTexto = "A = √[s(s−a)(s−b)(s−c)];  s = (a+b+c)/2",
                Icone = "Δ",
                Descricao = "Fórmula de Heron calcula a área de qualquer triângulo conhecendo apenas os três lados, sem precisar da altura. s é o semiperímetro.",
                Criador = "Heron de Alexandria (~10–70 d.C.), Metrica",
                AnoOrigin = "~60 d.C.",
                ExemploPratico = "Parcela de terra triangular com lados 50m, 60m, 70m: s=90; A=√(90×40×30×20)=√2.160.000≈1469,7 m²",
                Unidades = "m², cm², ft²",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Lado a", ValorPadrao = 50, ValorMin = 0 },
                    new() { Simbolo = "b", Nome = "Lado b", ValorPadrao = 60, ValorMin = 0 },
                    new() { Simbolo = "c", Nome = "Lado c", ValorPadrao = 70, ValorMin = 0 },
                ],
                VariavelResultado = "Área",
                Calcular = vars => {
                    double a = vars["a"], b = vars["b"], c = vars["c"];
                    double s = (a + b + c) / 2;
                    return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                }
            },
            new Formula
            {
                Id = "geo003", Nome = "Área do Círculo", Categoria = "Geometria",
                Expressao = "A = π·r²",
                ExprTexto = "A = π · r²",
                Icone = "○",
                Descricao = "Área delimitada por uma circunferência de raio r. Demonstrada por Arquimedes (~250 a.C.) usando o método de exaustão, precursor do cálculo integral.",
                Criador = "Arquimedes de Siracusa (~287–212 a.C.)",
                ExemploPratico = "Área de uma piscina circular com diâmetro 8m: r=4; A=π×16≈50,27 m². Volume se prof.=1.5m: 75,4 m³",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Raio (r)", Descricao = "Distância do centro à borda", ValorPadrao = 5, ValorMin = 0 },
                ],
                VariavelResultado = "Área",
                Calcular = vars => Math.PI * vars["r"] * vars["r"]
            },
            new Formula
            {
                Id = "geo004", Nome = "Volume da Esfera", Categoria = "Geometria",
                Expressao = "V = (4/3)·π·r³",
                ExprTexto = "V = (4/3) · π · r³",
                Icone = "⬤",
                Descricao = "Volume de uma esfera de raio r. Arquimedes considerou este resultado seu maior feito — mandou gravar na lápide o cilindro circunscrito a uma esfera (V_cil / V_esf = 3/2).",
                Criador = "Arquimedes (~250 a.C.), Sobre a Esfera e o Cilindro",
                ExemploPratico = "Volume do globo terrestre: r=6.371 km; V=(4/3)π×6371³≈1,083×10¹² km³. Tanque esférico de raio 2m: V≈33,5 m³",
                Unidades = "m³, cm³, L",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Raio (r)", ValorPadrao = 6371, ValorMin = 0 },
                ],
                VariavelResultado = "Volume",
                Calcular = vars => (4.0 / 3) * Math.PI * Math.Pow(vars["r"], 3)
            },
            new Formula
            {
                Id = "geo005", Nome = "Equação Geral da Circunferência", Categoria = "Geometria",
                Expressao = "(x-a)² + (y-b)² = r²",
                ExprTexto = "(x − a)² + (y − b)² = r²",
                Icone = "◯",
                Descricao = "Equação de uma circunferência de centro (a,b) e raio r no plano cartesiano. Qualquer ponto P(x,y) na circunferência satisfaz esta equação.",
                Criador = "René Descartes (1596–1650), La Géométrie (1637) — geometria analítica",
                ExemploPratico = "Circunferência centro (3,4) raio 5: (x-3)²+(y-4)²=25. Verifica ponto (6,8): (6-3)²+(8-4)²=9+16=25 ✓",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Centro x (a)", ValorPadrao = 0 },
                    new() { Simbolo = "b", Nome = "Centro y (b)", ValorPadrao = 0 },
                    new() { Simbolo = "r", Nome = "Raio (r)", ValorPadrao = 5, ValorMin = 0 },
                ],
                VariavelResultado = "r² (verificar ponto: (x-a)²+(y-b)²)",
                Calcular = vars => vars["r"] * vars["r"]
            },
            new Formula
            {
                Id = "geo006", Nome = "Distância entre Dois Pontos", Categoria = "Geometria",
                Expressao = "d = √((x₂-x₁)² + (y₂-y₁)²)",
                ExprTexto = "d = √[(x₂−x₁)² + (y₂−y₁)²]",
                Icone = "d",
                Descricao = "Distância euclidiana entre dois pontos no plano. Consequência direta do Teorema de Pitágoras aplicado ao plano cartesiano.",
                Criador = "Euclides; formulação cartesiana por Descartes (1637)",
                ExemploPratico = "Distância entre São Paulo (−23.5, −46.6) e Rio de Janeiro (−22.9, −43.2): d≈3.9° ≈ 430 km (conversão: 1°≈111km)",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", ValorPadrao = 0 },
                    new() { Simbolo = "y1", Nome = "y₁", ValorPadrao = 0 },
                    new() { Simbolo = "x2", Nome = "x₂", ValorPadrao = 3 },
                    new() { Simbolo = "y2", Nome = "y₂", ValorPadrao = 4 },
                ],
                VariavelResultado = "Distância d",
                Calcular = vars => Math.Sqrt(Math.Pow(vars["x2"] - vars["x1"], 2) + Math.Pow(vars["y2"] - vars["y1"], 2))
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // TRIGONOMETRIA
    // ─────────────────────────────────────────────────────
    private void AdicionarTrigonometria()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "trig001", Nome = "Lei dos Cossenos", Categoria = "Trigonometria",
                Expressao = "c² = a² + b² - 2ab·cos(C)",
                ExprTexto = "c² = a² + b² − 2ab · cos(C)",
                Icone = "cos",
                Descricao = "Generalização do Teorema de Pitágoras para triângulos oblíquos. Quando C=90°, cos(C)=0 e recuperamos Pitágoras. Permite calcular lados/ângulos de qualquer triângulo.",
                Criador = "Euclides (versão geométrica); Al-Kashi (1427, versão trigonométrica completa)",
                ExemploPratico = "Topografia: dois pontos a 80m e 60m de uma estação, ângulo de 120° entre eles. Distância entre os pontos: c=√(6400+3600+4800)=√14800≈121.7m",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Lado a", ValorPadrao = 80, ValorMin = 0 },
                    new() { Simbolo = "b", Nome = "Lado b", ValorPadrao = 60, ValorMin = 0 },
                    new() { Simbolo = "C", Nome = "Ângulo C (graus)", Descricao = "Ângulo oposto ao lado c", ValorPadrao = 120 },
                ],
                VariavelResultado = "Lado c",
                Calcular = vars => Math.Sqrt(
                    vars["a"] * vars["a"] + vars["b"] * vars["b"]
                    - 2 * vars["a"] * vars["b"] * Math.Cos(vars["C"] * Math.PI / 180))
            },
            new Formula
            {
                Id = "trig002", Nome = "Lei dos Senos", Categoria = "Trigonometria",
                Expressao = "a/sin(A) = b/sin(B) = c/sin(C) = 2R",
                ExprTexto = "a / sin(A) = b / sin(B) = c / sin(C) = 2R",
                Icone = "sin",
                Descricao = "A razão entre cada lado de um triângulo e o seno do ângulo oposto é constante, igual ao diâmetro 2R da circunferência circunscrita.",
                Criador = "Al-Battani (~900 d.C.); Euclides tinha versão anterior",
                ExemploPratico = "Calcular altura de prédio: base de 100m, ângulo de elevação 30° de um ponto, 50° de outro. a/sin(50°)=100/sin(100°)→a≈77,7m",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Lado a", ValorPadrao = 10, ValorMin = 0 },
                    new() { Simbolo = "A", Nome = "Ângulo A (graus)", Descricao = "Ângulo oposto ao lado a", ValorPadrao = 45 },
                ],
                VariavelResultado = "2R (diâmetro circunscrito)",
                Calcular = vars => vars["a"] / Math.Sin(vars["A"] * Math.PI / 180)
            },
            new Formula
            {
                Id = "trig003", Nome = "Identidade Fundamental de Pitágoras", Categoria = "Trigonometria",
                Expressao = "sin²(θ) + cos²(θ) = 1",
                ExprTexto = "sin²(θ) + cos²(θ) = 1",
                Icone = "≡",
                Descricao = "A mais importante identidade trigonométrica. Consequência do Teorema de Pitágoras no círculo unitário. Válida para qualquer ângulo θ.",
                Criador = "Derivada de Pitágoras; formalizada no séc. XVI-XVII",
                ExemploPratico = "Se sin(θ)=0,6, então cos²(θ)=1−0,36=0,64, cos(θ)=0,8. Verificação: 0,36+0,64=1 ✓. Usado em GPS e compressão de áudio",
                Variaveis = [
                    new() { Simbolo = "theta", Nome = "Ângulo θ (graus)", ValorPadrao = 30 },
                ],
                VariavelResultado = "sin²(θ) + cos²(θ) — deve ser 1",
                Calcular = vars => {
                    double theta = vars["theta"] * Math.PI / 180;
                    return Math.Sin(theta) * Math.Sin(theta) + Math.Cos(theta) * Math.Cos(theta);
                }
            },
            new Formula
            {
                Id = "trig004", Nome = "Fórmula de Euler", Categoria = "Trigonometria",
                Expressao = "e^(iθ) = cos(θ) + i·sin(θ)",
                ExprTexto = "e^(iθ) = cos(θ) + i · sin(θ)",
                Icone = "e^i",
                Descricao = "Relaciona exponencial complexa com trigonometria. Para θ=π: e^(iπ)+1=0 (Identidade de Euler, 'equação mais bela'). Fundamental em física quântica, engenharia elétrica e processamento de sinais.",
                Criador = "Leonhard Euler (1748), Introductio in Analysin Infinitorum",
                AnoOrigin = "1748",
                ExemploPratico = "Analisar circuito AC: tensão V=220·e^(iωt). A parte real é a tensão física. Transformada de Fourier usa esta fórmula extensivamente",
                Variaveis = [
                    new() { Simbolo = "theta", Nome = "Ângulo θ (graus)", ValorPadrao = 45 },
                ],
                VariavelResultado = "Módulo (sempre 1)",
                Calcular = vars => {
                    double theta = vars["theta"] * Math.PI / 180;
                    // |e^(iθ)| = 1 sempre; retornamos cos(θ) e sin(θ) como real e imag
                    return 1.0; // modulo sempre 1
                }
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // CÁLCULO
    // ─────────────────────────────────────────────────────
    private void AdicionarCalculo()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "cal001", Nome = "Definição de Derivada (Limite)", Categoria = "Cálculo",
                Expressao = "f'(x) = lim[h→0] (f(x+h)-f(x)) / h",
                ExprTexto = "f′(x) = lim[h→0] [f(x+h) − f(x)] / h",
                Icone = "d/dx",
                Descricao = "Taxa de variação instantânea de f em x. Mede a inclinação da reta tangente ao gráfico de f no ponto x. Fundamento do cálculo diferencial.",
                Criador = "Isaac Newton (1666, fluxões) e Gottfried Leibniz (1675, notação d/dx), independentemente",
                AnoOrigin = "1666 / 1675",
                ExemploPratico = "Velocidade instantânea de um carro: se posição x(t)=t³−3t, velocidade=dx/dt=3t²−3. A t=2s: v=12−3=9 m/s",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Ponto x", Descricao = "Ponto onde calcular a derivada numericamente", ValorPadrao = 2 },
                    new() { Simbolo = "h", Nome = "Incremento h", Descricao = "Valor pequeno para aproximação", ValorPadrao = 0.0001, ValorMin = 1e-10 },
                ],
                VariavelResultado = "f′(x) para f(x)=x²",
                Calcular = vars => {
                    double x = vars["x"], h = vars["h"];
                    Func<double, double> f = t => t * t; // exemplo: f(x)=x²
                    return (f(x + h) - f(x)) / h;
                }
            },
            new Formula
            {
                Id = "cal002", Nome = "Regra da Cadeia", Categoria = "Cálculo",
                Expressao = "(f∘g)'(x) = f'(g(x)) · g'(x)",
                ExprTexto = "(f ∘ g)′(x) = f′(g(x)) · g′(x)",
                Icone = "∂∂",
                Descricao = "Derivada de funções compostas: derivada da função exterior avaliada na interior, multiplicada pela derivada da interior. Regra mais usada em backpropagation (deep learning).",
                Criador = "Leibniz; formulação rigorosa por Augustin-Louis Cauchy (~1820)",
                ExemploPratico = "d/dx[sin(x²)]=cos(x²)·2x. Em redes neurais, o gradiente é calculado camada por camada usando esta regra (backpropagation)",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Ponto x", ValorPadrao = 1.0 },
                ],
                VariavelResultado = "d/dx[sin(x²)] em x",
                Calcular = vars => Math.Cos(vars["x"] * vars["x"]) * 2 * vars["x"]
            },
            new Formula
            {
                Id = "cal003", Nome = "Integral Definida (Teorema Fundamental)", Categoria = "Cálculo",
                Expressao = "∫ₐᵇ f(x)dx = F(b) - F(a)",
                ExprTexto = "∫ₐᵇ f(x) dx = F(b) − F(a)",
                Icone = "∫",
                Descricao = "O Teorema Fundamental do Cálculo conecta derivação e integração: a integral de f é calculada pela antiderivada F avaliada nos extremos. Newton e Leibniz descobriram este resultado central.",
                Criador = "Newton e Leibniz (1666–1675); prova rigorosa por Cauchy (1823)",
                ExemploPratico = "Deslocamento de um carro com v(t)=3t² m/s de t=0 a t=4s: ∫₀⁴3t²dt=[t³]₀⁴=64m. Ou área sob curva de demanda = receita total",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Limite inferior (a)", ValorPadrao = 0 },
                    new() { Simbolo = "b", Nome = "Limite superior (b)", ValorPadrao = 4 },
                ],
                VariavelResultado = "∫ₐᵇ 3x² dx = b³ − a³",
                Calcular = vars => Math.Pow(vars["b"], 3) - Math.Pow(vars["a"], 3)
            },
            new Formula
            {
                Id = "cal004", Nome = "Série de Taylor", Categoria = "Cálculo",
                Expressao = "f(x) = Σ f⁽ⁿ⁾(a)/n! · (x-a)ⁿ",
                ExprTexto = "f(x) = Σₙ₌₀^∞ f^(n)(a) / n! · (x−a)^n",
                Icone = "Σ∞",
                Descricao = "Representa uma função analítica como soma infinita de potências em torno de a. Para a=0 é a Série de Maclaurin. Usada em todos os cálculos computacionais de funções matemáticas.",
                Criador = "Brook Taylor (1715); Colin Maclaurin (1742)",
                AnoOrigin = "1715",
                ExemploPratico = "e^x ≈ 1+x+x²/2+x³/6. Para x=0.1: e^0.1≈1+0.1+0.005+0.000167≈1.10517 (correto). Calculadoras usam séries truncadas para calcular sin, cos, exp",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Ponto x (em torno de 0)", ValorPadrao = 1.0 },
                    new() { Simbolo = "n", Nome = "Número de termos", ValorPadrao = 10, ValorMin = 1 },
                ],
                VariavelResultado = "e^x ≈ Σ xⁿ/n!",
                Calcular = vars => {
                    double x = vars["x"]; int n = (int)vars["n"];
                    double soma = 0, fatorial = 1;
                    for (int k = 0; k < n; k++) {
                        if (k > 0) fatorial *= k;
                        soma += Math.Pow(x, k) / fatorial;
                    }
                    return soma;
                }
            },
            new Formula
            {
                Id = "cal005", Nome = "Regra de L'Hôpital", Categoria = "Cálculo",
                Expressao = "lim f(x)/g(x) = lim f'(x)/g'(x)  [formas 0/0 ou ∞/∞]",
                ExprTexto = "lim[x→c] f(x)/g(x) = lim[x→c] f′(x) / g′(x)",
                Icone = "0/0",
                Descricao = "Resolve indeterminações do tipo 0/0 ou ∞/∞ derivando numerador e denominador separadamente. Apesar do nome, o resultado foi descoberto por Johann Bernoulli.",
                Criador = "Johann Bernoulli (descoberto ~1694); Guillaume de l'Hôpital publicou em 1696 no primeiro livro de cálculo",
                ExemploPratico = "lim[x→0] sin(x)/x: sin'(x)=cos(x), x'=1 → lim cos(x)/1=cos(0)=1. Usado em probabilidade: lim[p→0] p·log(p)=0 (entropia)",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "x próximo de 0", ValorPadrao = 0.001, ValorMin = -100 },
                ],
                VariavelResultado = "sin(x)/x ≈ (valor em x)",
                Calcular = vars => Math.Sin(vars["x"]) / vars["x"]
            },
            new Formula
            {
                Id = "cal006", Nome = "Gradiente e Laplaciano", Categoria = "Cálculo",
                Expressao = "∇f = (∂f/∂x, ∂f/∂y, ∂f/∂z);  Δf = ∇²f",
                ExprTexto = "∇f = (∂f/∂x, ∂f/∂y, ∂f/∂z);  Δf = ∇²f = ∂²f/∂x²+∂²f/∂y²+∂²f/∂z²",
                Icone = "∇",
                Descricao = "O gradiente aponta na direção de maior crescimento de f. O Laplaciano mede a curvatura média — zero em funções harmônicas (potencial eletrostático, temperatura de equilíbrio).",
                Criador = "Hamilton (nabla ∇, 1853); Laplace (Δ, 1787)",
                ExemploPratico = "Encontrar trajetória de descida mais rápida em terreno: seguir −∇f (gradiente descendente). Fundamento do treinamento de redes neurais",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Ponto x", ValorPadrao = 1 },
                    new() { Simbolo = "y", Nome = "Ponto y", ValorPadrao = 2 },
                ],
                VariavelResultado = "|∇f| para f=x²+y²",
                Calcular = vars => {
                    // Para f=x²+y², ∇f=(2x,2y), |∇f|=2√(x²+y²)
                    return 2 * Math.Sqrt(vars["x"] * vars["x"] + vars["y"] * vars["y"]);
                }
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // ÁLGEBRA LINEAR
    // ─────────────────────────────────────────────────────
    private void AdicionarAlgebraLinear()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "lin001", Nome = "Produto Escalar (Dot Product)", Categoria = "Álgebra Linear",
                Expressao = "a·b = Σ aᵢbᵢ = |a||b|cos(θ)",
                ExprTexto = "a · b = a₁b₁ + a₂b₂ + a₃b₃ = |a| |b| cos(θ)",
                Icone = "·",
                Descricao = "O produto escalar de dois vetores é um escalar. Seu sinal indica se os vetores apontam na mesma direção (>0), são perpendiculares (=0) ou opostos (<0).",
                Criador = "Grassmann (1844); notação moderna por Gibbs e Heaviside (~1880)",
                ExemploPratico = "Trabalho feito por força F=(3,4,0)N em deslocamento d=(2,0,5)m: W=F·d=6+0+0=6J. Em ML: similaridade coseno entre vetores de texto",
                Variaveis = [
                    new() { Simbolo = "a1", Nome = "a₁", ValorPadrao = 3 },
                    new() { Simbolo = "a2", Nome = "a₂", ValorPadrao = 4 },
                    new() { Simbolo = "b1", Nome = "b₁", ValorPadrao = 2 },
                    new() { Simbolo = "b2", Nome = "b₂", ValorPadrao = 1 },
                ],
                VariavelResultado = "a · b",
                Calcular = vars => vars["a1"] * vars["b1"] + vars["a2"] * vars["b2"]
            },
            new Formula
            {
                Id = "lin002", Nome = "Determinante 2×2", Categoria = "Álgebra Linear",
                Expressao = "det(A) = ad - bc",
                ExprTexto = "det [[a,b],[c,d]] = ad − bc",
                Icone = "|A|",
                Descricao = "O determinante de uma matriz 2×2. Mede o fator de escala da área quando a transformação linear é aplicada. det≠0 ↔ matriz inversível.",
                Criador = "Leibniz (1693); Cramer (regra de Cramer, 1750)",
                ExemploPratico = "Sistema 2×2 tem solução única se det≠0. Área do paralelogramo formado por vetores (a,b) e (c,d): |det|=|ad-bc|",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Elemento a₁₁", ValorPadrao = 3 },
                    new() { Simbolo = "b", Nome = "Elemento a₁₂", ValorPadrao = 2 },
                    new() { Simbolo = "c", Nome = "Elemento a₂₁", ValorPadrao = 1 },
                    new() { Simbolo = "d", Nome = "Elemento a₂₂", ValorPadrao = 4 },
                ],
                VariavelResultado = "det(A)",
                Calcular = vars => vars["a"] * vars["d"] - vars["b"] * vars["c"]
            },
            new Formula
            {
                Id = "lin003", Nome = "Norma de Vetor (Euclidiana)", Categoria = "Álgebra Linear",
                Expressao = "||v|| = √(v₁²+v₂²+v₃²)",
                ExprTexto = "‖v‖ = √(v₁² + v₂² + v₃²)",
                Icone = "‖v‖",
                Descricao = "Comprimento (magnitude) de um vetor no espaço. Generaliza o Teorema de Pitágoras a qualquer dimensão. A norma L2 é a mais comum em machine learning.",
                Criador = "Consequência de Pitágoras; formalização por Cauchy e Hilbert",
                ExemploPratico = "Velocidade de drone com componentes (3,4,0) m/s: ‖v‖=√(9+16)=5 m/s. Distância L2 em busca de vizinhos próximos em embeddings",
                Variaveis = [
                    new() { Simbolo = "v1", Nome = "Componente v₁", ValorPadrao = 3 },
                    new() { Simbolo = "v2", Nome = "Componente v₂", ValorPadrao = 4 },
                    new() { Simbolo = "v3", Nome = "Componente v₃", ValorPadrao = 0 },
                ],
                VariavelResultado = "‖v‖ (norma)",
                Calcular = vars => Math.Sqrt(vars["v1"] * vars["v1"] + vars["v2"] * vars["v2"] + vars["v3"] * vars["v3"])
            },
            new Formula
            {
                Id = "lin004", Nome = "Equação de Autovalores", Categoria = "Álgebra Linear",
                Expressao = "A·v = λ·v",
                ExprTexto = "A · v = λ · v",
                Icone = "λ",
                Descricao = "v é autovetor de A se a transformação apenas escala o vetor pelo escalar λ (autovalor). Autovalores de A²×² satisfazem det(A−λI)=0: λ²−tr(A)λ+det(A)=0.",
                Criador = "Euler (1743, vibrações); Cauchy; Weierstrass",
                ExemploPratico = "Componentes principais de dados (PCA): autovalores da matriz de covariância indicam variância de cada componente. Google PageRank: autovetor do grafo da web",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "a₁₁", ValorPadrao = 4 },
                    new() { Simbolo = "b", Nome = "a₁₂", ValorPadrao = 1 },
                    new() { Simbolo = "c", Nome = "a₂₁", ValorPadrao = 2 },
                    new() { Simbolo = "d", Nome = "a₂₂", ValorPadrao = 3 },
                ],
                VariavelResultado = "λ₁ (autovalor maior)",
                Calcular = vars => {
                    double tr = vars["a"] + vars["d"];
                    double dt = vars["a"] * vars["d"] - vars["b"] * vars["c"];
                    return (tr + Math.Sqrt(tr * tr - 4 * dt)) / 2;
                }
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // EQUAÇÕES DIFERENCIAIS
    // ─────────────────────────────────────────────────────
    private void AdicionarEquacoesDiferenciais()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "ode001", Nome = "Equação de Crescimento/Decaimento Exponencial", Categoria = "Equações Diferenciais",
                Expressao = "dy/dt = ky  →  y(t) = y₀·eᵏᵗ",
                ExprTexto = "dy/dt = k · y  ⟹  y(t) = y₀ · e^(kt)",
                Icone = "eᵏᵗ",
                Descricao = "Modelo mais simples de crescimento (k>0) ou decaimento (k<0) exponencial. Solução: y(t)=y₀·e^(kt). A taxa de variação é proporcional à quantidade presente.",
                Criador = "Euler; Malthus (crescimento pop., 1798); Rutherford (decaimento radiativo, 1900)",
                ExemploPratico = "Meia-vida de C-14 (~5730 anos): y=y₀·e^(−0.000121t). Databação de fóssil com 30% de C-14 restante: t=−ln(0.3)/0.000121≈9953 anos",
                Variaveis = [
                    new() { Simbolo = "y0", Nome = "Valor inicial (y₀)", ValorPadrao = 100 },
                    new() { Simbolo = "k", Nome = "Taxa de crescimento (k)", Descricao = "k>0 crescimento, k<0 decaimento", ValorPadrao = -0.000121 },
                    new() { Simbolo = "t", Nome = "Tempo (t)", ValorPadrao = 9953, ValorMin = 0 },
                ],
                VariavelResultado = "y(t)",
                Calcular = vars => vars["y0"] * Math.Exp(vars["k"] * vars["t"])
            },
            new Formula
            {
                Id = "ode002", Nome = "Oscilador Harmônico Simples", Categoria = "Equações Diferenciais",
                Expressao = "d²x/dt² + ω²x = 0  →  x(t) = A·cos(ωt+φ)",
                ExprTexto = "d²x/dt² + ω² x = 0  ⟹  x(t) = A · cos(ωt + φ)",
                Icone = "~",
                Descricao = "Descreve qualquer sistema que oscila em torno do equilíbrio: mola, pêndulo pequeno, circuito LC. A frequência angular ω=√(k/m) depende do sistema.",
                Criador = "Huygens (pêndulo, 1673); Newton; Euler (solução geral)",
                ExemploPratico = "Pêndulo de 1m: ω=√(g/L)=√9.8≈3.13 rad/s, T=2π/ω≈2.0s. Edifícios projetados para não ressonar com frequência de terremotos (~1Hz)",
                Variaveis = [
                    new() { Simbolo = "A", Nome = "Amplitude (A)", ValorPadrao = 1 },
                    new() { Simbolo = "omega", Nome = "Frequência angular (ω)", ValorPadrao = 3.14 },
                    new() { Simbolo = "phi", Nome = "Fase inicial (φ, rad)", ValorPadrao = 0 },
                    new() { Simbolo = "t", Nome = "Tempo t (s)", ValorPadrao = 1 },
                ],
                VariavelResultado = "x(t)",
                Calcular = vars => vars["A"] * Math.Cos(vars["omega"] * vars["t"] + vars["phi"])
            },
            new Formula
            {
                Id = "ode003", Nome = "Equação de Difusão (Calor)", Categoria = "Equações Diferenciais",
                Expressao = "∂u/∂t = α·∂²u/∂x²",
                ExprTexto = "∂u/∂t = α · ∂²u/∂x²",
                Icone = "∂∂",
                Descricao = "Descreve a propagação de calor (u=temperatura) em um sólido. O coeficiente α=k/(ρcₚ) é a difusividade térmica. Mesma equação governa difusão de partículas e o movimento Browniano.",
                Criador = "Jean-Baptiste Joseph Fourier (Théorie Analytique de la Chaleur, 1822)",
                AnoOrigin = "1822",
                ExemploPratico = "Temperatura no centro de uma barra de aço (α≈1.2×10⁻⁵ m²/s) aquecida numa extremidade. Usado em design de dissipadores de calor e circuitos integrados",
                Variaveis = [
                    new() { Simbolo = "alpha", Nome = "Difusividade (α)", Descricao = "Difusividade térmica em m²/s", ValorPadrao = 0.0001 },
                    new() { Simbolo = "L", Nome = "Comprimento (L)", ValorPadrao = 1 },
                    new() { Simbolo = "t", Nome = "Tempo (t)", ValorPadrao = 100 },
                ],
                VariavelResultado = "Número de Fourier Fo = αt/L²",
                Calcular = vars => vars["alpha"] * vars["t"] / (vars["L"] * vars["L"])
            },
            new Formula
            {
                Id = "ode004", Nome = "Equação Logística (Verhulst)", Categoria = "Equações Diferenciais",
                Expressao = "dN/dt = rN(1-N/K)  →  N(t) = K/(1+((K-N₀)/N₀)·e⁻ʳᵗ)",
                ExprTexto = "dN/dt = r·N·(1 − N/K)  ⟹  N(t) = K / [1 + (K/N₀−1)·e^(−rt)]",
                Icone = "S",
                Descricao = "Modelo de crescimento populacional com capacidade de suporte K. Produz curva S (sigmóide). Quando N≪K, cresce exponencialmente; quando N→K, cresce linearmente em ML (função de ativação sigmoide).",
                Criador = "Pierre-François Verhulst (1838); base do modelo de Fisher-KPP em ecologia",
                AnoOrigin = "1838",
                ExemploPratico = "Pandemia: N₀=100 infectados, r=0.3/dia, K=10.000. Em 30 dias: N≈6.300. Adoção de tecnologia: iPhone (K=~1 bilhão de usuários)",
                Variaveis = [
                    new() { Simbolo = "K", Nome = "Capacidade de suporte (K)", ValorPadrao = 10000 },
                    new() { Simbolo = "N0", Nome = "População inicial (N₀)", ValorPadrao = 100 },
                    new() { Simbolo = "r", Nome = "Taxa de crescimento (r)", ValorPadrao = 0.3 },
                    new() { Simbolo = "t", Nome = "Tempo t", ValorPadrao = 30 },
                ],
                VariavelResultado = "N(t)",
                Calcular = vars => vars["K"] / (1 + ((vars["K"] / vars["N0"]) - 1) * Math.Exp(-vars["r"] * vars["t"]))
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // PROBABILIDADE
    // ─────────────────────────────────────────────────────
    private void AdicionarProbabilidade()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "prob001", Nome = "Teorema de Bayes", Categoria = "Probabilidade",
                Expressao = "P(A|B) = P(B|A)·P(A) / P(B)",
                ExprTexto = "P(A|B) = P(B|A) · P(A) / P(B)",
                Icone = "P",
                Descricao = "Atualiza probabilidades a partir de novas evidências. P(A) é a prior, P(A|B) é a posterior. Base da estatística Bayesiana, filtros de spam, diagnóstico médico e aprendizado de máquina.",
                Criador = "Thomas Bayes (1763, póstumo); Richard Price publicou; Laplace formalizou (1812)",
                AnoOrigin = "1763",
                ExemploPratico = "Teste de COVID com sensibilidade=95%, especificidade=99%, prevalência=1%. P(doente|positivo)=95%×1%/(95%×1%+1%×99%)≈48,7% — muitos falsos positivos!",
                Variaveis = [
                    new() { Simbolo = "PBA", Nome = "P(B|A) = sensibilidade", ValorPadrao = 0.95 },
                    new() { Simbolo = "PA", Nome = "P(A) = prevalência", ValorPadrao = 0.01 },
                    new() { Simbolo = "PB", Nome = "P(B) = P(+)", Descricao = "P(A)·P(B|A)+P(Aᶜ)·P(B|Aᶜ)", ValorPadrao = 0.0194 },
                ],
                VariavelResultado = "P(A|B)",
                Calcular = vars => (vars["PBA"] * vars["PA"]) / vars["PB"]
            },
            new Formula
            {
                Id = "prob002", Nome = "Distribuição Normal — Função de Densidade", Categoria = "Probabilidade",
                Expressao = "f(x) = (1/(σ√2π))·exp(-(x-μ)²/(2σ²))",
                ExprTexto = "f(x) = [1/(σ√(2π))] · exp[−(x−μ)² / (2σ²)]",
                Icone = "N",
                Descricao = "A distribuição normal (Gaussiana) é a mais importante da estatística. Pela lei dos grandes números, médias de amostras têm distribuição aproximadamente normal. Descreve alturas, erros de medição, retornos financeiros.",
                Criador = "De Moivre (1733); Gauss (1809, erro de medição); Laplace (TCL, 1812)",
                AnoOrigin = "1733",
                ExemploPratico = "Alturas de adultos brasileiros: μ=170cm, σ=8cm. f(170)=0.0499 (maior ponto). 95% das pessoas estão entre 154cm e 186cm (μ±2σ)",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 170 },
                    new() { Simbolo = "mu", Nome = "Média (μ)", ValorPadrao = 170 },
                    new() { Simbolo = "sigma", Nome = "Desvio padrão (σ)", ValorPadrao = 8, ValorMin = 0.001 },
                ],
                VariavelResultado = "f(x)",
                Calcular = vars => {
                    double z = (vars["x"] - vars["mu"]) / vars["sigma"];
                    return Math.Exp(-0.5 * z * z) / (vars["sigma"] * Math.Sqrt(2 * Math.PI));
                }
            },
            new Formula
            {
                Id = "prob003", Nome = "Distribuição de Poisson", Categoria = "Probabilidade",
                Expressao = "P(X=k) = λᵏ·e⁻λ / k!",
                ExprTexto = "P(X = k) = λᵏ · e^(−λ) / k!",
                Icone = "λᵏ",
                Descricao = "Probabilidade de observar k eventos quando o número médio esperado é λ. Modela eventos raros: número de chamadas telefônicas por hora, defeitos por unidade, chegadas de clientes.",
                Criador = "Siméon Denis Poisson (1837), Recherches sur la probabilité des jugements",
                AnoOrigin = "1837",
                ExemploPratico = "Call center recebe em média 3 chamadas/minuto (λ=3). P(5 chamadas exatas)=3⁵·e⁻³/120=0.1008≈10%. P(zero chamadas)=e⁻³≈5%",
                Variaveis = [
                    new() { Simbolo = "lambda", Nome = "Taxa média (λ)", Descricao = "Número médio de eventos esperados", ValorPadrao = 3, ValorMin = 0 },
                    new() { Simbolo = "k", Nome = "Número de eventos (k)", ValorPadrao = 5, ValorMin = 0 },
                ],
                VariavelResultado = "P(X=k)",
                Calcular = vars => Math.Pow(vars["lambda"], vars["k"]) * Math.Exp(-vars["lambda"]) / Fatorial((int)vars["k"])
            },
            new Formula
            {
                Id = "prob004", Nome = "Valor Esperado e Variância", Categoria = "Probabilidade",
                Expressao = "E[X]=μ=Σxᵢpᵢ;  Var(X)=E[(X-μ)²]=E[X²]-μ²",
                ExprTexto = "E[X] = Σ xᵢ pᵢ  ;  Var(X) = E[X²] − (E[X])²",
                Icone = "E",
                Descricao = "O valor esperado é a média ponderada pela probabilidade. A variância mede o espalhamento. σ=√Var é o desvio padrão, nas mesmas unidades de X.",
                Criador = "Huygens (1657); Bernoulli; definição rigorosa por Kolmogorov (1933)",
                ExemploPratico = "Dado justo de 6 faces: E[X]=(1+2+3+4+5+6)/6=3.5, Var(X)=E[X²]-12.25=91/6-12.25≈2.92, σ≈1.71",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Número de faces do dado", ValorPadrao = 6, ValorMin = 1 },
                ],
                VariavelResultado = "E[X] para dado n faces",
                Calcular = vars => (vars["n"] + 1) / 2.0
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // ESTATÍSTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarEstatistica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "est001", Nome = "Média, Variância e Desvio Padrão", Categoria = "Estatística",
                Expressao = "x̄ = (1/n)Σxᵢ;  s² = (1/(n-1))Σ(xᵢ-x̄)²;  s=√s²",
                ExprTexto = "x̄ = (1/n)·Σxᵢ  ;  s² = Σ(xᵢ−x̄)²/(n−1)  ;  s = √s²",
                Icone = "x̄",
                Descricao = "Estatísticas descritivas básicas. O divisor (n-1) na variância amostral corrige o viés (estimador de Bessel). A média minimiza a soma dos quadrados das diferenças.",
                Criador = "Gauss (mínimos quadrados, 1809); formalização por Pearson e Fisher (séc. XX)",
                ExemploPratico = "Notas: 7, 8, 6, 9, 8. x̄=38/5=7.6; s²=[(0.36+0.16+2.56+1.96+0.16)/4]=5.2/4=1.3; s≈1.14. Controle de qualidade: produto dentro de μ±3σ",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "Valor 1", ValorPadrao = 7 },
                    new() { Simbolo = "x2", Nome = "Valor 2", ValorPadrao = 8 },
                    new() { Simbolo = "x3", Nome = "Valor 3", ValorPadrao = 6 },
                    new() { Simbolo = "x4", Nome = "Valor 4", ValorPadrao = 9 },
                    new() { Simbolo = "x5", Nome = "Valor 5", ValorPadrao = 8 },
                ],
                VariavelResultado = "Média x̄",
                Calcular = vars => (vars["x1"] + vars["x2"] + vars["x3"] + vars["x4"] + vars["x5"]) / 5.0
            },
            new Formula
            {
                Id = "est002", Nome = "Coeficiente de Correlação de Pearson", Categoria = "Estatística",
                Expressao = "r = Σ(xᵢ-x̄)(yᵢ-ȳ) / √[Σ(xᵢ-x̄)²·Σ(yᵢ-ȳ)²]",
                ExprTexto = "r = Σ(xᵢ−x̄)(yᵢ−ȳ) / √[Σ(xᵢ−x̄)² · Σ(yᵢ−ȳ)²]",
                Icone = "r",
                Descricao = "Mede a intensidade e direção da relação linear entre X e Y. r∈[−1,1]. r=1: correlação positiva perfeita; r=0: não linear; r=−1: negativa perfeita.",
                Criador = "Francis Galton (1888, regressão); Karl Pearson (1896, coeficiente de correlação)",
                AnoOrigin = "1896",
                ExemploPratico = "Horas de estudo vs notas: r=0.85 → forte correlação positiva. Preço de petróleo vs companhias aéreas: r≈−0.7. Correlação ≠ causalidade!",
                Variaveis = [
                    new() { Simbolo = "sx", Nome = "Desvio padrão de X (sₓ)", ValorPadrao = 2.5 },
                    new() { Simbolo = "sy", Nome = "Desvio padrão de Y (sᵧ)", ValorPadrao = 3.0 },
                    new() { Simbolo = "sxy", Nome = "Covariância Cov(X,Y)", ValorPadrao = 5.0 },
                ],
                VariavelResultado = "r (correlação de Pearson)",
                Calcular = vars => vars["sxy"] / (vars["sx"] * vars["sy"])
            },
            new Formula
            {
                Id = "est003", Nome = "Intervalo de Confiança para Média", Categoria = "Estatística",
                Expressao = "IC = x̄ ± z_(α/2)·(σ/√n)",
                ExprTexto = "IC = x̄ ± z_(α/2) · (σ / √n)",
                Icone = "IC",
                Descricao = "Intervalo que contém o parâmetro populacional com (1−α)×100% de confiança. Para IC 95%: z=1.96. Maior n → intervalo mais estreito. Base da inferência estatística.",
                Criador = "Jerzy Neyman (1937, definição frequentista); Ronald Fisher (intervalos fiduciais)",
                AnoOrigin = "1937",
                ExemploPratico = "Sondagem: 1000 entrevistados, 55% apoiam candidato, σ=√(0.55×0.45)≈0.498. IC95%: 55%±1.96×0.498/√1000=55%±3.1%=(51.9%, 58.1%)",
                Variaveis = [
                    new() { Simbolo = "xbar", Nome = "Média amostral (x̄)", ValorPadrao = 55 },
                    new() { Simbolo = "sigma", Nome = "Desvio padrão (σ)", ValorPadrao = 0.498 },
                    new() { Simbolo = "n", Nome = "Tamanho da amostra (n)", ValorPadrao = 1000, ValorMin = 1 },
                    new() { Simbolo = "z", Nome = "z crítico (z_{α/2})", Descricao = "1.96 para 95%, 2.576 para 99%", ValorPadrao = 1.96 },
                ],
                VariavelResultado = "Margem de erro ±",
                Calcular = vars => vars["z"] * vars["sigma"] / Math.Sqrt(vars["n"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // MECÂNICA CLÁSSICA
    // ─────────────────────────────────────────────────────
    private void AdicionarMecanicaClassica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "mec001", Nome = "Segunda Lei de Newton", Categoria = "Mecânica Clássica",
                Expressao = "F = m·a",
                ExprTexto = "F = m · a",
                Icone = "F",
                Descricao = "A força resultante sobre um objeto é igual ao produto de sua massa pela aceleração. Lei mais importante da mecânica clássica. Para sistemas com massa variável: F=dp/dt.",
                Criador = "Isaac Newton (Principia Mathematica, 1687)",
                AnoOrigin = "1687",
                ExemploPratico = "Foguete SpaceX Falcon 9: massa=550.000kg, aceleração=10 m/s². Força necessária: F=5.500.000 N = 5,5 MN. Freio ABS: a=−8m/s², F=80kg×8=640N",
                Unidades = "Newtons (N = kg·m/s²)",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa (m)", Descricao = "Massa do objeto em kg", ValorPadrao = 70, ValorMin = 0 },
                    new() { Simbolo = "a", Nome = "Aceleração (a)", Descricao = "Aceleração em m/s²", ValorPadrao = 9.81 },
                ],
                VariavelResultado = "Força F (N)",
                UnidadeResultado = "N",
                Calcular = vars => vars["m"] * vars["a"]
            },
            new Formula
            {
                Id = "mec002", Nome = "Energia Cinética", Categoria = "Mecânica Clássica",
                Expressao = "Ec = ½·m·v²",
                ExprTexto = "Eₖ = ½ · m · v²",
                Icone = "Eₖ",
                Descricao = "Energia associada ao movimento de um objeto de massa m com velocidade v. Para velocidades relativísticas, substitui-se por E=γmc²−mc². A unidade Joule=kg·m²/s².",
                Criador = "Leibniz (1686, vis viva = mv²); fator ½ estabelecido por Coriolis (1829)",
                ExemploPratico = "Carro de 1500kg a 100 km/h (27.8 m/s): Eₖ=½×1500×772=579.000J=579kJ. Colisão libera toda esta energia. Bala 9mm 8g a 370m/s: Eₖ≈548J",
                Unidades = "Joules (J)",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa (m)", Descricao = "kg", ValorPadrao = 1500, ValorMin = 0 },
                    new() { Simbolo = "v", Nome = "Velocidade (v)", Descricao = "m/s", ValorPadrao = 27.78, ValorMin = 0 },
                ],
                VariavelResultado = "Eₖ (Joules)",
                UnidadeResultado = "J",
                Calcular = vars => 0.5 * vars["m"] * vars["v"] * vars["v"]
            },
            new Formula
            {
                Id = "mec003", Nome = "Lei da Gravitação Universal", Categoria = "Mecânica Clássica",
                Expressao = "F = G·m₁·m₂/r²",
                ExprTexto = "F = G · m₁ · m₂ / r²",
                Icone = "G",
                Descricao = "A força gravitacional entre dois corpos é proporcional ao produto de suas massas e inversamente proporcional ao quadrado da distância. G=6.674×10⁻¹¹ N·m²/kg².",
                Criador = "Isaac Newton (Principia, 1687); G medido por Cavendish (1798)",
                AnoOrigin = "1687",
                ExemploPratico = "Força Terra-Lua: G=6.674e-11, M_Terra=5.97e24kg, M_Lua=7.34e22kg, r=3.84e8m. F=1.98×10²⁰N. Mantém a Lua em órbita!",
                Unidades = "Newtons (N)",
                Variaveis = [
                    new() { Simbolo = "m1", Nome = "Massa 1 (kg)", ValorPadrao = 5.97e24 },
                    new() { Simbolo = "m2", Nome = "Massa 2 (kg)", ValorPadrao = 7.34e22 },
                    new() { Simbolo = "r", Nome = "Distância (m)", ValorPadrao = 3.84e8, ValorMin = 0 },
                ],
                VariavelResultado = "Força gravitacional F (N)",
                Calcular = vars => 6.674e-11 * vars["m1"] * vars["m2"] / (vars["r"] * vars["r"])
            },
            new Formula
            {
                Id = "mec004", Nome = "Conservação de Energia Mecânica", Categoria = "Mecânica Clássica",
                Expressao = "E_total = ½mv² + mgh = constante",
                ExprTexto = "E_total = ½mv² + mgh = const.",
                Icone = "E",
                Descricao = "Na ausência de forças dissipativas, energia cinética + potencial gravitacional se conservam. Permite calcular velocidades em qualquer posição conhecendo a energia inicial.",
                Criador = "Leibniz, Bernoulli; formalizado por Helmholtz (1847)",
                ExemploPratico = "Skatista na rampa: começa do repouso a h=3m. No fundo: v=√(2gh)=√(2×9.8×3)≈7.67 m/s. Montanha-russa, pêndulo, hidroelétricas",
                Variaveis = [
                    new() { Simbolo = "h", Nome = "Altura inicial (h)", Descricao = "metros acima do ponto mais baixo", ValorPadrao = 3, ValorMin = 0 },
                    new() { Simbolo = "g", Nome = "g (m/s²)", ValorPadrao = 9.81 },
                ],
                VariavelResultado = "Velocidade máxima v (m/s)",
                Calcular = vars => Math.Sqrt(2 * vars["g"] * vars["h"])
            },
            new Formula
            {
                Id = "mec005", Nome = "Equações de Cinemática (MRUV)", Categoria = "Mecânica Clássica",
                Expressao = "v=v₀+at;  x=x₀+v₀t+½at²;  v²=v₀²+2aΔx",
                ExprTexto = "v = v₀ + at  ;  x = x₀ + v₀t + ½at²  ;  v² = v₀² + 2aΔx",
                Icone = "MRUV",
                Descricao = "Equações do movimento retilíneo uniformemente variado (aceleração constante). Galileu descobriu que a≈9.8 m/s² para queda livre, independente da massa.",
                Criador = "Galileu Galilei (1638, Discorsi); Newton (1687)",
                ExemploPratico = "Carro de 0 a 100 km/h em 6s: a=(100/3.6)/6=4.63 m/s², distância=½×4.63×36=83.3m. Projetil lançado a 30m/s a 45°: alcance=v₀²/g=91.8m",
                Variaveis = [
                    new() { Simbolo = "v0", Nome = "Velocidade inicial v₀ (m/s)", ValorPadrao = 0 },
                    new() { Simbolo = "a", Nome = "Aceleração a (m/s²)", ValorPadrao = 9.81 },
                    new() { Simbolo = "t", Nome = "Tempo t (s)", ValorPadrao = 2, ValorMin = 0 },
                ],
                VariavelResultado = "Velocidade v = v₀+at (m/s)",
                Calcular = vars => vars["v0"] + vars["a"] * vars["t"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // TERMODINÂMICA
    // ─────────────────────────────────────────────────────
    private void AdicionarTermodinamica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "termo001", Nome = "Primeira Lei da Termodinâmica", Categoria = "Termodinâmica",
                Expressao = "ΔU = Q - W",
                ExprTexto = "ΔU = Q − W",
                Icone = "Q",
                Descricao = "A variação da energia interna ΔU de um sistema é igual ao calor Q recebido menos o trabalho W realizado pelo sistema. Lei de conservação de energia para processos térmicos.",
                Criador = "Mayer (1842), Joule (1843), Helmholtz (1847) — formulado por vários simultaneamente",
                AnoOrigin = "1842–1847",
                ExemploPratico = "Motor a vapor: Q=1000J de calor recebido, realiza W=600J de trabalho mecânico. ΔU=400J. Eficiência=60%. Motor Carnot tem eficiência máxima η=1-Tc/Th",
                Variaveis = [
                    new() { Simbolo = "Q", Nome = "Calor recebido (Q)", Descricao = "Joules (positivo se recebido)", ValorPadrao = 1000 },
                    new() { Simbolo = "W", Nome = "Trabalho realizado (W)", Descricao = "Joules (positivo se realizado pelo sistema)", ValorPadrao = 600 },
                ],
                VariavelResultado = "ΔU (variação energia interna) J",
                Calcular = vars => vars["Q"] - vars["W"]
            },
            new Formula
            {
                Id = "termo002", Nome = "Entropia — 2ª Lei da Termodinâmica", Categoria = "Termodinâmica",
                Expressao = "ΔS = Q_rev/T  ≥ 0  (processo irreversível)",
                ExprTexto = "ΔS = Q_rev / T  ;  ΔS_universo ≥ 0",
                Icone = "S",
                Descricao = "A entropia de um sistema isolado nunca decresce. ΔS=0 reversível, ΔS>0 irreversível. Mede a desordem ou número de microestados (Boltzmann: S=kB·ln W).",
                Criador = "Clausius (1865, cunhou entropia); Boltzmann (interpretação estatística, 1877)",
                AnoOrigin = "1865",
                ExemploPratico = "Gelo derretendo a 0°C: Q=334J/g absorvido. ΔS=334J/273K=1.22 J/(K·g). Entropia aumenta ao fundir. Em computação: apagar 1 bit gera ≥kT·ln2 de calor (Landauer)",
                Variaveis = [
                    new() { Simbolo = "Qrev", Nome = "Calor reversível (J)", ValorPadrao = 33400 },
                    new() { Simbolo = "T", Nome = "Temperatura (K)", ValorPadrao = 273.15, ValorMin = 0.001 },
                ],
                VariavelResultado = "ΔS (J/K)",
                Calcular = vars => vars["Qrev"] / vars["T"]
            },
            new Formula
            {
                Id = "termo003", Nome = "Lei de Stefan-Boltzmann", Categoria = "Termodinâmica",
                Expressao = "j* = σ·T⁴",
                ExprTexto = "j* = σ · T⁴",
                Icone = "σT⁴",
                Descricao = "Potência total irradiada por unidade de área de um corpo negro é proporcional à 4ª potência da temperatura absoluta. σ=5.67×10⁻⁸ W/(m²·K⁴).",
                Criador = "Josef Stefan (1879, experimental); Ludwig Boltzmann (1884, teórico)",
                AnoOrigin = "1879",
                ExemploPratico = "Sol (T≈5778K): j*=5.67e-8×5778⁴≈6.3×10⁷ W/m². Terra em equilíbrio: T_Terra≈255K (−18°C) sem efeito estufa. Com gases: +33°C≈288K atual",
                Variaveis = [
                    new() { Simbolo = "T", Nome = "Temperatura (K)", ValorPadrao = 5778, ValorMin = 0 },
                    new() { Simbolo = "epsilon", Nome = "Emissividade ε (0-1)", Descricao = "1 para corpo negro ideal", ValorPadrao = 1.0 },
                ],
                VariavelResultado = "j* (W/m²)",
                Calcular = vars => vars["epsilon"] * 5.67e-8 * Math.Pow(vars["T"], 4)
            },
            new Formula
            {
                Id = "termo004", Nome = "Eficiência de Carnot", Categoria = "Termodinâmica",
                Expressao = "η_max = 1 - Tᶜ/Tʰ",
                ExprTexto = "η_max = 1 − Tᶜ/Tʰ",
                Icone = "η",
                Descricao = "Limite teórico máximo de eficiência de qualquer máquina térmica operando entre temperaturas Tc (fria) e Th (quente). Nenhuma máquina real pode superar este limite.",
                Criador = "Sadi Carnot (Réflexions sur la puissance motrice du feu, 1824)",
                AnoOrigin = "1824",
                ExemploPratico = "Termoelétrica a vapor: Th=600°C=873K, Tc=30°C=303K. η_Carnot=1-303/873=65.2%. Motor real ≈40%. Geladeira: COP=Tc/(Th-Tc)=303/570≈0.53",
                Variaveis = [
                    new() { Simbolo = "Th", Nome = "Temperatura quente Tʰ (K)", ValorPadrao = 873, ValorMin = 0 },
                    new() { Simbolo = "Tc", Nome = "Temperatura fria Tᶜ (K)", ValorPadrao = 303, ValorMin = 0 },
                ],
                VariavelResultado = "η_max (eficiência máxima)",
                Calcular = vars => 1 - vars["Tc"] / vars["Th"]
            },
            new Formula
            {
                Id = "termo005", Nome = "Equação de Estado Gás Ideal", Categoria = "Termodinâmica",
                Expressao = "PV = nRT",
                ExprTexto = "PV = nRT",
                Icone = "PV",
                Descricao = "Relaciona pressão P, volume V, moles n e temperatura T de um gás ideal. R=8.314 J/(mol·K). Válida para gases reais a baixa pressão e alta temperatura.",
                Criador = "Boyle (1662), Charles (1787), Gay-Lussac (1808); unificação por Clapeyron (1834)",
                AnoOrigin = "1834",
                ExemploPratico = "Pneu de carro: n=0.5mol, V=10L=0.01m³, T=300K. P=nRT/V=0.5×8.314×300/0.01=124710 Pa≈1.23atm. No calor, T=320K: P=132500 Pa (pressão sobe!)",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Moles de gás (n)", ValorPadrao = 0.5 },
                    new() { Simbolo = "T", Nome = "Temperatura (K)", ValorPadrao = 300, ValorMin = 0 },
                    new() { Simbolo = "V", Nome = "Volume (m³)", ValorPadrao = 0.01, ValorMin = 0.001 },
                ],
                VariavelResultado = "Pressão P (Pa)",
                Calcular = vars => vars["n"] * 8.314 * vars["T"] / vars["V"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // ELETROMAGNETISMO
    // ─────────────────────────────────────────────────────
    private void AdicionarEletromagnetismo()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "elet001", Nome = "Lei de Coulomb", Categoria = "Eletromagnetismo",
                Expressao = "F = k·q₁·q₂/r²",
                ExprTexto = "F = k · q₁ · q₂ / r²",
                Icone = "q",
                Descricao = "Força eletrostática entre duas cargas pontuais. k=8.99×10⁹ N·m²/C² (constante de Coulomb). Mesma forma matemática da gravitação de Newton, mas 10³⁶ vezes mais forte.",
                Criador = "Charles-Augustin de Coulomb (1785)",
                AnoOrigin = "1785",
                ExemploPratico = "Próton e elétron no átomo de H: q₁=q₂=1.6e-19C, r=5.3e-11m. F=8.99e9×(1.6e-19)²/(5.3e-11)²=8.2×10⁻⁸ N. Força que mantém o elétron no átomo",
                Variaveis = [
                    new() { Simbolo = "q1", Nome = "Carga 1 (C)", ValorPadrao = 1.6e-19 },
                    new() { Simbolo = "q2", Nome = "Carga 2 (C)", ValorPadrao = -1.6e-19 },
                    new() { Simbolo = "r", Nome = "Distância (m)", ValorPadrao = 5.3e-11, ValorMin = 1e-15 },
                ],
                VariavelResultado = "|F| (N)",
                Calcular = vars => Math.Abs(8.99e9 * vars["q1"] * vars["q2"] / (vars["r"] * vars["r"]))
            },
            new Formula
            {
                Id = "elet002", Nome = "Lei de Ohm", Categoria = "Eletromagnetismo",
                Expressao = "V = R·I",
                ExprTexto = "V = R · I",
                Icone = "Ω",
                Descricao = "A tensão V (voltagem) em um resistor é proporcional à corrente I que o atravessa. R é a resistência em Ohms. Base da análise de circuitos elétricos.",
                Criador = "Georg Simon Ohm (Die galvanische Kette, 1827)",
                AnoOrigin = "1827",
                ExemploPratico = "LED requer 20mA e opera a 3V. Alimentado por 5V USB: R=(5-3)/0.02=100Ω. Potência dissipada: P=I²R=0.02²×100=40mW",
                Unidades = "V=Volts, R=Ohms, I=Amperes",
                Variaveis = [
                    new() { Simbolo = "R", Nome = "Resistência (Ω)", ValorPadrao = 100, ValorMin = 0 },
                    new() { Simbolo = "I", Nome = "Corrente (A)", ValorPadrao = 0.02 },
                ],
                VariavelResultado = "Tensão V (Volts)",
                Calcular = vars => vars["R"] * vars["I"]
            },
            new Formula
            {
                Id = "elet003", Nome = "Potência Elétrica", Categoria = "Eletromagnetismo",
                Expressao = "P = V·I = I²·R = V²/R",
                ExprTexto = "P = V · I = I² · R = V² / R",
                Icone = "W",
                Descricao = "Potência elétrica dissipada ou transferida. Em watts (W=J/s). Pelo efeito Joule, a energia elétrica em resistores vira calor.",
                Criador = "Joule (efeito Joule, 1841); Watt (unidade, em homenagem a James Watt)",
                ExemploPratico = "Ferro de passar roupa: V=220V, I=5A → P=1100W=1.1kW. Em 1h: E=1.1kWh≈R$0.88 (tarifa R$0.80/kWh). Fio elétrico superdimensionado reduz perdas P=I²R",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "Tensão (V)", ValorPadrao = 220 },
                    new() { Simbolo = "I", Nome = "Corrente (A)", ValorPadrao = 5 },
                ],
                VariavelResultado = "Potência P (W)",
                Calcular = vars => vars["V"] * vars["I"]
            },
            new Formula
            {
                Id = "elet004", Nome = "Lei de Faraday — Indução Eletromagnética", Categoria = "Eletromagnetismo",
                Expressao = "ε = -dΦ/dt  = -d(B·A)/dt",
                ExprTexto = "ε = −dΦ_B/dt",
                Icone = "ε",
                Descricao = "Uma variação do fluxo magnético Φ_B induz uma força eletromotriz ε no circuito. Base de geradores, transformadores e motores elétricos.",
                Criador = "Michael Faraday (1831); Heinrich Lenz (sinal negativo, 1834)",
                AnoOrigin = "1831",
                ExemploPratico = "Gerador eólico: B=0.1T, área A=0.5m², gira a 60rpm=1rev/s. ε_max=B×A×ω=0.1×0.5×2π≈0.31V por volta. Turbina com 1000 voltas: 310V",
                Variaveis = [
                    new() { Simbolo = "B", Nome = "Campo magnético (T)", ValorPadrao = 0.1 },
                    new() { Simbolo = "A", Nome = "Área (m²)", ValorPadrao = 0.5, ValorMin = 0 },
                    new() { Simbolo = "omega", Nome = "Velocidade angular (rad/s)", ValorPadrao = 6.28 },
                    new() { Simbolo = "N", Nome = "Número de voltas", ValorPadrao = 1000 },
                ],
                VariavelResultado = "ε_max (FEM em V)",
                Calcular = vars => vars["N"] * vars["B"] * vars["A"] * vars["omega"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // ÓPTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarOptica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "opt001", Nome = "Lei de Snell-Descartes (Refração)", Categoria = "Óptica",
                Expressao = "n₁·sin(θ₁) = n₂·sin(θ₂)",
                ExprTexto = "n₁ · sin(θ₁) = n₂ · sin(θ₂)",
                Icone = "n",
                Descricao = "Ao atravessar a interface entre meios com índices de refração n₁ e n₂, a luz muda de direção. n=c/v (velocidade da luz no vácuo / no meio). Base de óculos, microscópios, fibras ópticas.",
                Criador = "Willebrord Snell van Royen (1621); formulado por Descartes (1637)",
                AnoOrigin = "1621",
                ExemploPratico = "Fibra óptica: n_vidro=1.5, n_ar=1. Ângulo crítico: sin(θc)=1/1.5 → θc=41.8°. Acima deste ângulo: reflexão total interna (luz não sai). Princípio das fibras ópticas",
                Variaveis = [
                    new() { Simbolo = "n1", Nome = "Índice n₁ (meio 1)", ValorPadrao = 1.0 },
                    new() { Simbolo = "theta1", Nome = "Ângulo θ₁ (graus)", ValorPadrao = 45 },
                    new() { Simbolo = "n2", Nome = "Índice n₂ (meio 2)", ValorPadrao = 1.5 },
                ],
                VariavelResultado = "θ₂ (ângulo de refração, graus)",
                Calcular = vars => {
                    double sinTheta2 = vars["n1"] * Math.Sin(vars["theta1"] * Math.PI / 180) / vars["n2"];
                    if (Math.Abs(sinTheta2) > 1) return double.NaN; // reflexão total
                    return Math.Asin(sinTheta2) * 180 / Math.PI;
                }
            },
            new Formula
            {
                Id = "opt002", Nome = "Equação de Gauss para Lentes Delgadas", Categoria = "Óptica",
                Expressao = "1/f = 1/do + 1/di",
                ExprTexto = "1/f = 1/dₒ + 1/dᵢ",
                Icone = "f",
                Descricao = "Relaciona distância focal f, distância objeto dₒ e distância imagem dᵢ em lentes delgadas. Ampliação: m=−dᵢ/dₒ. Negativo = imagem invertida real.",
                Criador = "Carl Friedrich Gauss (1840, fórmula das lentes)",
                ExemploPratico = "Câmera fotográfica: objeto a 2m, lente f=50mm. 1/dᵢ=1/0.05−1/2=20−0.5=19.5 → dᵢ=51.3mm. Sensor posicionado a ~51mm da lente",
                Variaveis = [
                    new() { Simbolo = "f", Nome = "Distância focal f (mm)", ValorPadrao = 50, ValorMin = 0.1 },
                    new() { Simbolo = "do", Nome = "Distância objeto dₒ (mm)", ValorPadrao = 2000, ValorMin = 0.1 },
                ],
                VariavelResultado = "Distância imagem dᵢ (mm)",
                Calcular = vars => 1.0 / (1.0 / vars["f"] - 1.0 / vars["do"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // MECÂNICA DOS FLUIDOS
    // ─────────────────────────────────────────────────────
    private void AdicionarMecanicaFluidos()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "flu001", Nome = "Equação de Bernoulli", Categoria = "Mecânica dos Fluidos",
                Expressao = "P + ½ρv² + ρgh = constante",
                ExprTexto = "P + ½ρv² + ρgh = const.",
                Icone = "∇P",
                Descricao = "Ao longo de uma linha de corrente de fluido ideal, a soma de pressão estática, pressão dinâmica e pressão gravitacional é constante. Explica sustentação de aviões e carburador.",
                Criador = "Daniel Bernoulli (Hydrodynamica, 1738); Euler (derivação, 1755)",
                AnoOrigin = "1738",
                ExemploPratico = "Asa de avião: ar passa mais rápido no extradorso (v=250m/s) que intradorso (v=220m/s). ΔP=½ρΔv²=½×1.2×(250²-220²)=17160 Pa. Força de sustentação por m² de asa",
                Variaveis = [
                    new() { Simbolo = "P1", Nome = "Pressão P₁ (Pa)", ValorPadrao = 101325 },
                    new() { Simbolo = "v1", Nome = "Velocidade v₁ (m/s)", ValorPadrao = 10 },
                    new() { Simbolo = "v2", Nome = "Velocidade v₂ (m/s)", ValorPadrao = 20 },
                    new() { Simbolo = "rho", Nome = "Densidade ρ (kg/m³)", ValorPadrao = 1.2 },
                ],
                VariavelResultado = "Pressão P₂ (Pa)",
                Calcular = vars => vars["P1"] + 0.5 * vars["rho"] * (vars["v1"] * vars["v1"] - vars["v2"] * vars["v2"])
            },
            new Formula
            {
                Id = "flu002", Nome = "Equação de Continuidade", Categoria = "Mecânica dos Fluidos",
                Expressao = "A₁·v₁ = A₂·v₂  (fluido incompressível)",
                ExprTexto = "A₁ · v₁ = A₂ · v₂",
                Icone = "A·v",
                Descricao = "Conservação de massa em fluxo incompressível: vazão volumétrica Q=Av é constante. Fluxo se acelera onde a seção transversal diminui.",
                Criador = "Euler (1757); Leonardo da Vinci descreveu intuitivamente (~1500)",
                ExemploPratico = "Mangueira de jardim: bocal estreita de 5cm² para 1cm². v₂=5×v₁. Se v₁=2m/s → v₂=10m/s. Jato d'água forte para lavar carro",
                Variaveis = [
                    new() { Simbolo = "A1", Nome = "Área seção 1 (m²)", ValorPadrao = 0.05, ValorMin = 0.001 },
                    new() { Simbolo = "v1", Nome = "Velocidade v₁ (m/s)", ValorPadrao = 2 },
                    new() { Simbolo = "A2", Nome = "Área seção 2 (m²)", ValorPadrao = 0.01, ValorMin = 0.001 },
                ],
                VariavelResultado = "Velocidade v₂ (m/s)",
                Calcular = vars => vars["A1"] * vars["v1"] / vars["A2"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // ENGENHARIA
    // ─────────────────────────────────────────────────────
    private void AdicionarEngenharia()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "eng001", Nome = "Lei de Hooke (Mola)", Categoria = "Engenharia",
                Expressao = "F = -k·x",
                ExprTexto = "F = −k · x",
                Icone = "~",
                Descricao = "A força de restauração de uma mola é proporcional ao deslocamento x e oposta a ele. k é a constante de rigidez (N/m). Válida para deformações elásticas.",
                Criador = "Robert Hooke (1676, em anagrama ceiiinosssttuu = ut tensio sic vis)",
                AnoOrigin = "1676",
                ExemploPratico = "Suspensão de carro: k=50.000 N/m, carga de 500kg×9.8=4900N. Afundamento: x=4900/50000=9.8cm. Frequência natural: f=√(k/m)/(2π)=5Hz",
                Variaveis = [
                    new() { Simbolo = "k", Nome = "Constante de mola k (N/m)", ValorPadrao = 50000, ValorMin = 0 },
                    new() { Simbolo = "x", Nome = "Deslocamento x (m)", ValorPadrao = 0.098 },
                ],
                VariavelResultado = "Força F (N)",
                Calcular = vars => vars["k"] * Math.Abs(vars["x"])
            },
            new Formula
            {
                Id = "eng002", Nome = "Resistência de Materiais — Tensão Normal", Categoria = "Engenharia",
                Expressao = "σ = F/A",
                ExprTexto = "σ = F / A",
                Icone = "σ",
                Descricao = "Tensão normal σ é a força por unidade de área na seção transversal. O material falha se σ > σ_ruptura. Deformação: ε=ΔL/L; módulo de Young: E=σ/ε.",
                Criador = "Galileu (1638, primeiros estudos); Young (módulo, 1807); Navier (teoria completa, 1821)",
                ExemploPratico = "Cabo de elevador: F=5 toneladas=49000N, diâmetro 10mm, A=78.5mm²=7.85e-5m². σ=49000/7.85e-5=624 MPa. Aço tem σ_ruptura≈500-700 MPa. Margem segurança!",
                Variaveis = [
                    new() { Simbolo = "F", Nome = "Força F (N)", ValorPadrao = 49000 },
                    new() { Simbolo = "A", Nome = "Área da seção (m²)", ValorPadrao = 7.85e-5, ValorMin = 1e-10 },
                ],
                VariavelResultado = "Tensão σ (Pa = N/m²)",
                Calcular = vars => vars["F"] / vars["A"]
            },
            new Formula
            {
                Id = "eng003", Nome = "Equação de Transformadores", Categoria = "Engenharia",
                Expressao = "V₁/V₂ = N₁/N₂ = I₂/I₁",
                ExprTexto = "V₁ / V₂ = N₁ / N₂ = I₂ / I₁",
                Icone = "T",
                Descricao = "Em um transformador ideal, a relação de transformação a=N₁/N₂ determina as tensões e correntes. Permite transmitir energia com mínimas perdas em alta tensão (P=VI, I↓ → perdas I²R↓).",
                Criador = "Michael Faraday (1831, princípio); transformador moderno por Gaulard e Gibbs (1882)",
                ExemploPratico = "Transformador de TCC: 220V/12V → N₁/N₂=18.3. Se primário tem 1100 espiras, secundário tem 60 espiras. Corrente primária 0.1A → secundária 1.83A",
                Variaveis = [
                    new() { Simbolo = "V1", Nome = "Tensão primária V₁ (V)", ValorPadrao = 220 },
                    new() { Simbolo = "N1", Nome = "Espiras primário N₁", ValorPadrao = 1100 },
                    new() { Simbolo = "N2", Nome = "Espiras secundário N₂", ValorPadrao = 60 },
                ],
                VariavelResultado = "Tensão secundária V₂ (V)",
                Calcular = vars => vars["V1"] * vars["N2"] / vars["N1"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // BIOLOGIA MATEMÁTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarBiologiaMatematica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "bio001", Nome = "Modelo de Lotka-Volterra (Predador-Presa)", Categoria = "Biologia Matemática",
                Expressao = "dx/dt=αx-βxy;  dy/dt=δxy-γy",
                ExprTexto = "dx/dt = αx − βxy  ;  dy/dt = δxy − γy",
                Icone = "🦁",
                Descricao = "Modelo dinâmico de população presa x e predador y. α=taxa natalidade da presa, β=eficiência de predação, δ=conversão presa→predador, γ=mortalidade predador. Produz ciclos populacionais.",
                Criador = "Alfred Lotka (1910) e Vito Volterra (1926) independentemente",
                AnoOrigin = "1910–1926",
                ExemploPratico = "Lince canadense e lebre: ciclos de ~10 anos observados desde 1845. Gestão de pesca: captura excessiva colapsa ambos. Aplicado em epidemiologia, ecologia, mercados",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "População presa x", ValorPadrao = 100 },
                    new() { Simbolo = "y", Nome = "População predador y", ValorPadrao = 20 },
                    new() { Simbolo = "alpha", Nome = "Taxa natalidade presa α", ValorPadrao = 0.1 },
                    new() { Simbolo = "beta", Nome = "Taxa predação β", ValorPadrao = 0.02 },
                ],
                VariavelResultado = "dx/dt (taxa mudança presa)",
                Calcular = vars => vars["alpha"] * vars["x"] - vars["beta"] * vars["x"] * vars["y"]
            },
            new Formula
            {
                Id = "bio002", Nome = "Modelo de Michaelis-Menten (Enzimas)", Categoria = "Biologia Matemática",
                Expressao = "v = Vmax·[S] / (Km + [S])",
                ExprTexto = "v = V_max · [S] / (K_m + [S])",
                Icone = "v",
                Descricao = "Taxa de reação enzimática v em função da concentração do substrato [S]. Vmax é a velocidade máxima; Km é a concentração de substrato para v=Vmax/2 (afinidade da enzima).",
                Criador = "Leonor Michaelis e Maud Menten (1913)",
                AnoOrigin = "1913",
                ExemploPratico = "Digestão de lactose por lactase: Km≈3mM, Vmax=100μM/s. [S]=6mM: v=100×6/(3+6)=66.7μM/s. Intolerância à lactose: lactase insuficiente → baixo Vmax",
                Variaveis = [
                    new() { Simbolo = "Vmax", Nome = "Velocidade máxima V_max (μM/s)", ValorPadrao = 100 },
                    new() { Simbolo = "S", Nome = "Concentração substrato [S] (mM)", ValorPadrao = 6, ValorMin = 0 },
                    new() { Simbolo = "Km", Nome = "Constante de Michaelis K_m (mM)", ValorPadrao = 3, ValorMin = 0 },
                ],
                VariavelResultado = "Velocidade v (μM/s)",
                Calcular = vars => vars["Vmax"] * vars["S"] / (vars["Km"] + vars["S"])
            },
            new Formula
            {
                Id = "bio003", Nome = "Modelo de Hodgkin-Huxley (Neurônio)", Categoria = "Biologia Matemática",
                Expressao = "C_m·dV/dt = I_ext - (gNa·m³h(V-ENa)+gK·n⁴(V-EK)+gL(V-EL))",
                ExprTexto = "C_m·dV/dt = I_ext − [gNa·m³h(V−E_Na) + gK·n⁴(V−E_K) + g_L(V−E_L)]",
                Icone = "V",
                Descricao = "Modelo biofísico completo do potencial de ação em neurônios. Ganhador do Nobel de Fisiologia/Medicina 1963. Fundamental para entender doenças neurológicas e neuropróteses.",
                Criador = "Alan Hodgkin e Andrew Huxley (1952), baseado em axônio de lula gigante",
                AnoOrigin = "1952",
                ExemploPratico = "Potencial de repouso: V=-65mV. Estímulo → V sobe: canais de Na⁺ abrem (INa entra), depois K⁺ sai (IK), repolariza. Duração ~1ms. Base de coclear implants, DBS para Parkinson",
                Variaveis = [
                    new() { Simbolo = "Iext", Nome = "Corrente externa I_ext (μA/cm²)", ValorPadrao = 10 },
                    new() { Simbolo = "V", Nome = "Potencial de membrana V (mV)", ValorPadrao = -65 },
                    new() { Simbolo = "Cm", Nome = "Capacitância C_m (μF/cm²)", ValorPadrao = 1, ValorMin = 0.01 },
                ],
                VariavelResultado = "dV/dt (mV/ms) — simplificado",
                Calcular = vars => (vars["Iext"] - 0.3 * (vars["V"] + 65)) / vars["Cm"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // COMPUTAÇÃO
    // ─────────────────────────────────────────────────────
    private void AdicionarComputacao()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "comp001", Nome = "Complexidade — Logaritmo Binário (Binary Search)", Categoria = "Computação",
                Expressao = "T(n) = O(log₂ n)",
                ExprTexto = "T(n) = O(log₂ n)",
                Icone = "O",
                Descricao = "A busca binária divide o espaço de busca pela metade a cada passo, resultando em complexidade logarítmica. Para n=1 bilhão: apenas 30 comparações!",
                Criador = "John Mauchly (1946, algoritmo); análise por Knuth (The Art of Computer Programming, 1968)",
                ExemploPratico = "Busca em dicionário digital com 100.000 palavras: busca binária faz log₂(100000)≈17 comparações. Busca linear faz até 100.000 comparações. Diferença: 5882x mais rápido",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Tamanho da entrada n", ValorPadrao = 1000000, ValorMin = 1 },
                ],
                VariavelResultado = "Número de passos ≈ log₂(n)",
                Calcular = vars => Math.Log2(vars["n"])
            },
            new Formula
            {
                Id = "comp002", Nome = "Entropia de Shannon (Informação)", Categoria = "Computação",
                Expressao = "H = -Σ pᵢ·log₂(pᵢ)",
                ExprTexto = "H(X) = −Σᵢ pᵢ · log₂(pᵢ)  [bits]",
                Icone = "H",
                Descricao = "Medida da incerteza (informação média) de uma variável aleatória. Máxima para distribuição uniforme, zero para evento certo. Base de compressão de dados, criptografia e ML.",
                Criador = "Claude Shannon (A Mathematical Theory of Communication, 1948) — fundador da teoria da informação",
                AnoOrigin = "1948",
                ExemploPratico = "Moeda justa: H=−(0.5·log₂0.5+0.5·log₂0.5)=1 bit. Dado de 6 faces: H=log₂6≈2.58 bits. Texto em inglês: H≈4.5 bits/letra → compressão máxima possível",
                Variaveis = [
                    new() { Simbolo = "p1", Nome = "Probabilidade p₁", ValorPadrao = 0.5 },
                    new() { Simbolo = "p2", Nome = "Probabilidade p₂", ValorPadrao = 0.5 },
                ],
                VariavelResultado = "H (bits)",
                Calcular = vars => {
                    double h = 0;
                    var probs = new[] { vars["p1"], vars["p2"] };
                    foreach (var p in probs)
                        if (p > 0) h -= p * Math.Log2(p);
                    return h;
                }
            },
            new Formula
            {
                Id = "comp003", Nome = "Transformada de Fourier Discreta (DFT)", Categoria = "Computação",
                Expressao = "X[k] = Σₙ₌₀^(N-1) x[n]·e^(-i2πkn/N)",
                ExprTexto = "X[k] = Σₙ₌₀^(N−1) x[n] · e^(−i2πkn/N)",
                Icone = "FFT",
                Descricao = "Transforma sinal do domínio temporal para frequência. FFT (Fast Fourier Transform) calcula em O(N log N). Base de compressão MP3/JPEG, filtros de áudio, análise espectral.",
                Criador = "Gauss (1805, não publicou); Cooley e Tukey (1965, FFT algoritmo)",
                AnoOrigin = "1965",
                ExemploPratico = "Compressão MP3: analisa 1152 amostras de áudio, transforma para frequência, descarta frequências inaudíveis. Reduz arquivo 10x sem perda perceptível",
                Variaveis = [
                    new() { Simbolo = "N", Nome = "Número de amostras N", ValorPadrao = 1024, ValorMin = 1 },
                ],
                VariavelResultado = "Complexidade FFT: N·log₂(N)",
                Calcular = vars => vars["N"] * Math.Log2(vars["N"])
            },
            new Formula
            {
                Id = "comp004", Nome = "Perceptron (Neurônio Artificial)", Categoria = "Computação",
                Expressao = "y = σ(w·x + b) = σ(Σwᵢxᵢ + b)",
                ExprTexto = "y = σ(w · x + b)  ;  σ(z) = 1/(1 + e^(−z))",
                Icone = "σ",
                Descricao = "Neurônio artificial: soma ponderada das entradas mais viés, passada pela função de ativação σ (sigmoide). Bloco básico de redes neurais. Backpropagation usa regra da cadeia para ajustar w e b.",
                Criador = "Frank Rosenblatt (1957, perceptron); sigmoide em redes por Rumelhart/Hinton/Williams (1986)",
                AnoOrigin = "1957",
                ExemploPratico = "Classificar email spam: w=[0.8, 0.6, 0.9], x=[1, 0, 1] (features), b=-1.5. z=0.8+0+0.9-1.5=0.2. σ(0.2)=0.55. Probabilidade de spam = 55%",
                Variaveis = [
                    new() { Simbolo = "z", Nome = "z = w·x + b (valor linear)", ValorPadrao = 0.2 },
                ],
                VariavelResultado = "σ(z) = probabilidade de saída",
                Calcular = vars => 1.0 / (1.0 + Math.Exp(-vars["z"]))
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // UTILITÁRIOS
    // ─────────────────────────────────────────────────────
    private static double Fatorial(int n)
    {
        if (n < 0) return double.NaN;
        if (n == 0 || n == 1) return 1;
        double result = 1;
        for (int i = 2; i <= n; i++) result *= i;
        return result;
    }
}
