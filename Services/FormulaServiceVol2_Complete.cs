using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═════════════════════════════════════════════════════════════
    //  VOLUME 2 — PARTE III: ESTATÍSTICA AVANÇADA (COMPLETO)
    //  PARTE IV: COMPUTAÇÃO AVANÇADA (COMPLETO)
    //  PARTE V: ENGENHARIA AVANÇADA (COMPLETO)
    //  PARTE VI: BIOLOGIA MATEMÁTICA (COMPLETO)
    // ═════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 11. SÉRIES TEMPORAIS
    // ─────────────────────────────────────────────────────
    private void AdicionarSeriesTemporaisCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_st01", CodigoCompendio = "066", Nome = "AIC (Critério de Informação de Akaike)",
                Categoria = "Vol2: Séries Temporais", SubCategoria = "Seleção de Modelos",
                Expressao = "AIC = -2·ln(L) + 2k",
                ExprTexto = "AIC = -2 ln(L) + 2k",
                Icone = "📊",
                Descricao = "O Critério de Informação de Akaike (AIC) balanceia ajuste do modelo (verossimilhança L) com complexidade (número de parâmetros k). Modelos com menor AIC são preferidos. Usado para selecionar ordem de modelos ARMA, ARIMA, etc.",
                Criador = "Hirotugu Akaike",
                AnoOrigin = "1974",
                ExemploPratico = "Modelo A (k=2, ln(L)=-100): AIC=204. Modelo B (k=5, ln(L)=-95): AIC=200. Escolher B (menor AIC). AR(1) vs AR(2): calcular AIC de ambos e escolher o menor.",
                Variaveis = [
                    new() { Simbolo = "lnL", Nome = "ln(L)", Descricao = "Log-verossimilhança", ValorPadrao = -100, Unidade = "" },
                    new() { Simbolo = "k", Nome = "k (parâmetros)", Descricao = "Número de parâmetros", ValorPadrao = 3, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "AIC",
                UnidadeResultado = "",
                Calcular = vars => -2 * vars["lnL"] + 2 * vars["k"]
            },

            new Formula
            {
                Id = "v2_st02", CodigoCompendio = "067", Nome = "BIC (Critério Bayesiano de Schwarz)",
                Categoria = "Vol2: Séries Temporais", SubCategoria = "Seleção de Modelos",
                Expressao = "BIC = -2·ln(L) + k·ln(n)",
                ExprTexto = "BIC = -2 ln(L) + k ln(n)",
                Icone = "📊",
                Descricao = "O BIC penaliza mais fortemente a complexidade que o AIC, especialmente para amostras grandes (n). BIC tende a selecionar modelos mais parcimoniosos. Para n<8, AIC penaliza mais; para n≥8, BIC penaliza mais.",
                Criador = "Gideon Schwarz",
                AnoOrigin = "1978",
                ExemploPratico = "n=100, k=3, ln(L)=-100: BIC=200+3·ln(100)=200+13.8≈214. Comparar com AIC=206. Para n grande, BIC favorece modelos mais simples que AIC.",
                Variaveis = [
                    new() { Simbolo = "lnL", Nome = "ln(L)", Descricao = "Log-verossimilhança", ValorPadrao = -100, Unidade = "" },
                    new() { Simbolo = "k", Nome = "k (parâmetros)", Descricao = "Número de parâmetros", ValorPadrao = 3, ValorMin = 1, Unidade = "" },
                    new() { Simbolo = "n", Nome = "n (tamanho amostra)", Descricao = "Tamanho da amostra", ValorPadrao = 100, ValorMin = 2, Unidade = "" },
                ],
                VariavelResultado = "BIC",
                UnidadeResultado = "",
                Calcular = vars => -2 * vars["lnL"] + vars["k"] * Math.Log(vars["n"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 12. ANÁLISE MULTIVARIADA
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseMultivariadaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_pca01", CodigoCompendio = "068", Nome = "Variância Explicada por Componente Principal",
                Categoria = "Vol2: Análise Multivariada", SubCategoria = "PCA",
                Expressao = "Var_expl = λₖ / Σλᵢ",
                ExprTexto = "Var_explicada = λₖ / Σλᵢ",
                Icone = "📊",
                Descricao = "A proporção da variância total explicada pela k-ésima componente principal é λₖ dividido pela soma de todos os autovalores. Autovalores grandes indicam direções de maior variância nos dados. PCA maximiza variância capturada.",
                Criador = "Karl Pearson / Harold Hotelling",
                AnoOrigin = "1901 / 1933",
                ExemploPratico = "Se λ={10,5,2,1,0.5}, soma=18.5. PC1 explica 10/18.5≈54%. PC2 explica 5/18.5≈27%. PC1+PC2 explicam 81%. Geralmente escolhem-se PCs que explicam >90% da variância.",
                Variaveis = [
                    new() { Simbolo = "lambda_k", Nome = "λₖ", Descricao = "Autovalor da k-ésima componente", ValorPadrao = 10, ValorMin = 0, Unidade = "" },
                    new() { Simbolo = "soma_lambda", Nome = "Σλᵢ", Descricao = "Soma de todos os autovalores", ValorPadrao = 18.5, ValorMin = 0.001, Unidade = "" },
                ],
                VariavelResultado = "Proporção variância",
                UnidadeResultado = "",
                Calcular = vars => vars["lambda_k"] / vars["soma_lambda"]
            },

            new Formula
            {
                Id = "v2_cl01", CodigoCompendio = "069", Nome = "Distância de Mahalanobis",
                Categoria = "Vol2: Análise Multivariada", SubCategoria = "Clustering",
                Expressao = "d²(x,y) = (x-y)ᵀ Σ⁻¹ (x-y)",
                ExprTexto = "d²(x,y) = (x-y)ᵀ Σ⁻¹ (x-y)",
                Icone = "📊",
                Descricao = "A distância de Mahalanobis leva em conta a covariância entre variáveis. Se Σ=I (identidade), reduz-se à distância euclidiana. Útil quando variáveis têm escalas diferentes ou são correlacionadas. Usada em detecção de outliers multivariados.",
                Criador = "Prasanta Chandra Mahalanobis",
                AnoOrigin = "1936",
                ExemploPratico = "Para Σ=I (variáveis independentes): d² = Σ(xᵢ-yᵢ)² (Euclidiana). Se variáveis têm variâncias diferentes, Mahalanobis normaliza automaticamente. Distância >3 do centróide pode indicar outlier.",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", Descricao = "Primeira dimensão de x", ValorPadrao = 2, Unidade = "" },
                    new() { Simbolo = "x2", Nome = "x₂", Descricao = "Segunda dimensão de x", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "y1", Nome = "y₁", Descricao = "Primeira dimensão de y", ValorPadrao = 5, Unidade = "" },
                    new() { Simbolo = "y2", Nome = "y₂", Descricao = "Segunda dimensão de y", ValorPadrao = 6, Unidade = "" },
                ],
                VariavelResultado = "d² (Σ=I)",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x1"] - vars["y1"], 2) + Math.Pow(vars["x2"] - vars["y2"], 2)
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 13. ESTATÍSTICA BAYESIANA
    // ─────────────────────────────────────────────────────
    private void AdicionarEstatisticaBayesianaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_bay01", CodigoCompendio = "070", Nome = "Teorema de Bayes p(θ|x) ∝ p(x|θ)p(θ)",
                Categoria = "Vol2: Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "p(θ|x) = p(x|θ)·p(θ) / p(x)",
                ExprTexto = "posterior ∝ verossimilhança × priori",
                Icone = "📊",
                Descricao = "O Teorema de Bayes atualiza nossa crença sobre parâmetro θ (priori) usando dados observados x (verossimilhança) para obter distribuição a posteriori. É a base da estatística bayesiana. p(x)=∫p(x|θ)p(θ)dθ é a evidência (normalização).",
                Criador = "Thomas Bayes / Pierre-Simon Laplace",
                AnoOrigin = "1763 / 1774",
                ExemploPratico = "Teste médico: P(doença|positivo)=P(positivo|doença)·P(doença)/P(positivo). Se sensibilidade=99%, prevalência=1%, taxa de falso positivo=5%: P(doença|positivo) apenas≈ 16.5% (não 99%!).",
                Variaveis = [
                    new() { Simbolo = "L", Nome = "p(x|θ)", Descricao = "Verossimilhança", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Unidade = "" },
                    new() { Simbolo = "prior", Nome = "p(θ)", Descricao = "Probabilidade a priori", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Unidade = "" },
                    new() { Simbolo = "px", Nome = "p(x)", Descricao = "Evidência (normalização)", ValorPadrao = 0.5, ValorMin = 0.001, ValorMax = 1, Unidade = "" },
                ],
                VariavelResultado = "p(θ|x)",
                UnidadeResultado = "",
                Calcular = vars => (vars["L"] * vars["prior"]) / vars["px"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 14. TEORIA DOS GRAFOS
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaGrafosCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_tg01", CodigoCompendio = "071", Nome = "Handshaking Lemma: Σ deg(v) = 2m",
                Categoria = "Vol2: Teoria dos Grafos", SubCategoria = "Conceitos Fundamentais",
                Expressao = "Σ deg(v) = 2·|E|",
                ExprTexto = "Soma dos graus = 2 × número de arestas",
                Icone = "🔗",
                Descricao = "A soma dos graus de todos os vértices é o dobro do número de arestas, pois cada aresta contribui com 2 para a soma total (uma vez para cada extremidade). Consequência: número de vértices de grau ímpar é sempre par.",
                Criador = "Leonhard Euler",
                AnoOrigin = "1736",
                ExemploPratico = "Grafo com E=5 arestas: soma dos graus=10. Se vértices têm graus {3,2,2,3}: soma=10 ✓. Triângulo (3 vértices, 3 arestas): cada vértice grau 2, soma=6=2·3 ✓. Impossível ter grafo com graus {1,2,3} (soma ímpar!).",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "|E| (arestas)", Descricao = "Número de arestas no grafo", ValorPadrao = 5, ValorMin = 0, Unidade = "" },
                ],
                VariavelResultado = "Σ deg(v)",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["m"]
            },

            new Formula
            {
                Id = "v2_tg02", CodigoCompendio = "072", Nome = "Número de Arestas em Grafo Completo Kₙ",
                Categoria = "Vol2: Teoria dos Grafos", SubCategoria = "Grafos Especiais",
                Expressao = "m = n(n-1)/2",
                ExprTexto = "m = C(n,2) = n(n-1)/2",
                Icone = "🔗",
                Descricao = "Um grafo completo Kₙ possui uma aresta entre cada par de vértices. Com n vértices, há C(n,2) pares possíveis. Cada vértice tem grau n-1 (conectado a todos os outros).",
                Criador = "Teoria de Grafos Clássica",
                AnoOrigin = "~1850",
                ExemploPratico = "K₃ (triângulo): 3·2/2=3 arestas. K₄: 4·3/2=6 arestas. K₅: 10 arestas. K₁₀: 45 arestas. K₁₀₀: 4950 arestas. Internet: se n=10⁹ computadores todos conectados: ~5×10¹⁷ conexões!",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "n (vértices)", Descricao = "Número de vértices", ValorPadrao = 5, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "m (arestas)",
                UnidadeResultado = "",
                Calcular = vars => {
                    double n = vars["n"];
                    return n * (n - 1) / 2.0;
                }
            },

            new Formula
            {
                Id = "v2_tg03", CodigoCompendio = "073", Nome = "Fórmula de Euler Planar: V - E + F = 2",
                Categoria = "Vol2: Teoria dos Grafos", SubCategoria = "Grafos Planares",
                Expressao = "V - E + F = 2",
                ExprTexto = "Vértices - Arestas + Faces = 2",
                Icone = "🔗",
                Descricao = "Para qualquer grafo planar conexo: V-E+F=2 (característica de Euler). Faces incluem a face externa infinita. Válido para poliedros convexos. Fundamental na topologia e teoria de grafos planares.",
                Criador = "Leonhard Euler",
                AnoOrigin = "1750",
                ExemploPratico = "Triângulo: V=3, E=3, F=2 (dentro+fora) → 3-3+2=2 ✓. Cubo: V=8, E=12, F=6 → 8-12+6=2 ✓. Tetraedro: V=4, E=6, F=4 → 4-6+4=2 ✓. Árvore planar: F=1 sempre.",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "V (vértices)", Descricao = "Número de vértices", ValorPadrao = 8, ValorMin = 1, Unidade = "" },
                    new() { Simbolo = "E", Nome = "E (arestas)", Descricao = "Número de arestas", ValorPadrao = 12, ValorMin = 0, Unidade = "" },
                    new() { Simbolo = "F", Nome = "F (faces)", Descricao = "Número de faces", ValorPadrao = 6, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "χ (Euler)",
                UnidadeResultado = "",
                Calcular = vars => vars["V"] - vars["E"] + vars["F"]
            },

            new Formula
            {
                Id = "v2_tg04", CodigoCompendio = "074", Nome = "Árvore: m = n - 1",
                Categoria = "Vol2: Teoria dos Grafos", SubCategoria = "Árvores",
                Expressao = "m = n - 1",
                ExprTexto = "Arestas = Vértices - 1 (para árvore)",
                Icone = "🔗",
                Descricao = "Uma árvore é um grafo conexo acíclico. Toda árvore com n vértices tem exatamente n-1 arestas. Adicionar uma aresta cria um ciclo. Remover uma aresta desconecta o grafo. Árvores geradora de grafo G: subgrafo árvore contendo todos os vértices.",
                Criador = "Teoria de Árvores / Arthur Cayley",
                AnoOrigin = "~1850",
                ExemploPratico = "Árvore binária com 7 nós: 6 arestas. Estrela K_{1,n-1}: n vértices, n-1 arestas. Caminho com n vértices: n-1 arestas. Floresta com k árvores e n vértices: n-k arestas.",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "n (vértices)", Descricao = "Número de vértices", ValorPadrao = 10, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "m (arestas)",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] - 1
            },

            new Formula
            {
                Id = "v2_tg05", CodigoCompendio = "075", Nome = "Fórmula de Cayley: nⁿ⁻² árvores",
                Categoria = "Vol2: Teoria dos Grafos", SubCategoria = "Árvores",
                Expressao = "T(n) = nⁿ⁻²",
                ExprTexto = "Número de árvores rotuladas em n vértices = nⁿ⁻²",
                Icone = "🔗",
                Descricao = "O número de árvores distintas com n vértices rotulados é nⁿ⁻². Resultado surpreendente e elegante da combinatória. Para n=2: 2⁰=1 (uma aresta). Para n=3: 3¹=3 árvores.",
                Criador = "Arthur Cayley",
                AnoOrigin = "1889",
                ExemploPratico = "n=2: 1 árvore. n=3: 3 árvores. n=4: 16 árvores. n=5: 125 árvores. n=10: 10⁸ árvores. Aplicações: árvores geradoras, análise de redes, algoritmos probabilísticos.",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "n (vértices)", Descricao = "Número de vértices", ValorPadrao = 5, ValorMin = 1, ValorMax = 15, Unidade = "" },
                ],
                VariavelResultado = "T(n)",
                UnidadeResultado = "árvores",
                Calcular = vars => Math.Pow(vars["n"], vars["n"] - 2)
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 15. PROCESSAMENTO DE SINAIS DIGITAIS
    // ─────────────────────────────────────────────────────
    private void AdicionarProcessamentoSinaisCompleto()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_dsp01", CodigoCompendio = "076", Nome = "Teorema de Nyquist fs ≥ 2fmax",
                Categoria = "Vol2: Processamento de Sinais", SubCategoria = "Amostragem",
                Expressao = "fs ≥ 2·fmax",
                ExprTexto = "Taxa de amostragem ≥ 2 × frequência máxima",
                Icone = "📡",
                Descricao = "O Teorema de Nyquist-Shannon estabelece que para reconstruir perfeitamente um sinal de frequência máxima fmax, a taxa de amostragem fs deve ser pelo menos 2fmax (frequência de Nyquist). Caso contrário, ocorre aliasing (distorção).",
                Criador = "Harry Nyquist / Claude Shannon",
                AnoOrigin = "1928 / 1949",
                ExemploPratico = "Áudio CD: fmax=20 kHz → fs=44.1 kHz (>2·20 kHz, com margem). Telefone: fmax≈3.4 kHz → fs=8 kHz. Se fmax=1 kHz e fs=1.5 kHz (<2fmax): aliasing! Câmeras: 30 fps captura até 15 Hz de movimento.",
                Variaveis = [
                    new() { Simbolo = "fmax", Nome = "fmax", Descricao = "Frequência máxima do sinal", ValorPadrao = 20000, ValorMin = 1, Unidade = "Hz" },
                ],
                VariavelResultado = "fs_min",
                UnidadeResultado = "Hz",
                Calcular = vars => 2 * vars["fmax"]
            },

            new Formula
            {
                Id = "v2_dsp02", CodigoCompendio = "077", Nome = "Frequência de Nyquist fN = fs/2",
                Categoria = "Vol2: Processamento de Sinais", SubCategoria = "Amostragem",
                Expressao = "fN = fs / 2",
                ExprTexto = "Frequência de Nyquist = Taxa de amostragem / 2",
                Icone = "📡",
                Descricao = "A frequência de Nyquist é a maior frequência que pode ser representada sem aliasing dado uma taxa de amostragem fs. Componentes espectrais acima de fN sofrem aliasing (rebatimento no espectro).",
                Criador = "Harry Nyquist",
                AnoOrigin = "1928",
                ExemploPratico = "CD (fs=44.1 kHz): fN=22.05 kHz. Telefone (fs=8 kHz): fN=4 kHz. Vídeo 60 fps: fN=30 Hz. Filtros anti-aliasing removem frequências >fN antes da amostragem.",
                Variaveis = [
                    new() { Simbolo = "fs", Nome = "fs", Descricao = "Taxa de amostragem", ValorPadrao = 44100, ValorMin = 1, Unidade = "Hz" },
                ],
                VariavelResultado = "fN",
                UnidadeResultado = "Hz",
                Calcular = vars => vars["fs"] / 2.0
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 18. CONTROLE AUTOMÁTICO
    // ─────────────────────────────────────────────────────
    private void AdicionarControleAutomaticoCompleto()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_ca01", CodigoCompendio = "078", Nome = "Controlador PID: u(t) = Kp·e + Ki·∫e + Kd·ė",
                Categoria = "Vol2: Controle Automático", SubCategoria = "Controladores",
                Expressao = "u(t) = Kp·e(t) + Ki·∫e(t)dt + Kd·de/dt",
                ExprTexto = "Saída = Proporcional + Integral + Derivativo",
                Icone = "🎛️",
                Descricao = "O controlador PID combina três ações: Proporcional (resposta ao erro atual), Integral (elimina erro estacionário acumulado) e Derivativa (antecipa mudanças futuras). É o controlador mais usado na indústria.",
                Criador = "Nicolas Minorsky / Industry",
                AnoOrigin = "1922 / Desenvolvimento ao longo do século 20",
                ExemploPratico = "Termostato: Kp reage ao erro atual de temperatura. Ki elimina offset. Kd previne overshooting. Controle de velocidade de motor, nível de tanque, piloto automático de aviões e navios. Sintonia: Ziegler-Nichols.",
                Variaveis = [
                    new() { Simbolo = "e", Nome = "e(t)", Descricao = "Erro atual (setpoint - medição)", ValorPadrao = 5, Unidade = "unidade" },
                    new() { Simbolo = "int_e", Nome = "∫e dt", Descricao = "Integral do erro", ValorPadrao = 10, Unidade = "unidade·s" },
                    new() { Simbolo = "de", Nome = "de/dt", Descricao = "Derivada do erro", ValorPadrao = 0.5, Unidade = "unidade/s" },
                    new() { Simbolo = "Kp", Nome = "Kp", Descricao = "Ganho proporcional", ValorPadrao = 2, ValorMin = 0, Unidade = "" },
                    new() { Simbolo = "Ki", Nome = "Ki", Descricao = "Ganho integral", ValorPadrao = 0.1, ValorMin = 0, Unidade = "1/s" },
                    new() { Simbolo = "Kd", Nome = "Kd", Descricao = "Ganho derivativo", ValorPadrao = 0.5, ValorMin = 0, Unidade = "s" },
                ],
                VariavelResultado = "u(t)",
                UnidadeResultado = "unidade",
                Calcular = vars => vars["Kp"] * vars["e"] + vars["Ki"] * vars["int_e"] + vars["Kd"] * vars["de"]
            },

            new Formula
            {
                Id = "v2_ca02", CodigoCompendio = "079", Nome = "Tempo de Acomodação ts ≈ 4/(ζωn)",
                Categoria = "Vol2: Controle Automático", SubCategoria = "Resposta Transitória",
                Expressao = "ts ≈ 4 / (ζ·ωn)",
                ExprTexto = "Tempo de acomodação (critério 2%) ≈ 4/(ζωn)",
                Icone = "🎛️",
                Descricao = "O tempo de acomodação ts é o tempo para a resposta entrar e permanecer dentro de ±2% do valor final. Para sistema de 2ª ordem subamortecido: ts≈4/(ζωn). ζ: coeficiente de amortecimento. ωn: frequência natural não amortecida.",
                Criador = "Teoria de Controle Clássica",
                AnoOrigin = "~1940",
                ExemploPratico = "Sistema com ζ=0.7, ωn=10 rad/s: ts≈4/(0.7·10)=0.57 s. Se ζ=0.5 (mais oscilatório): ts≈0.8 s. Se ωn=20 (mais rápido): ts≈0.29 s. Projeto: escolher ζ,ωn para ts desejado.",
                Variaveis = [
                    new() { Simbolo = "zeta", Nome = "ζ", Descricao = "Coeficiente de amortecimento", ValorPadrao = 0.7, ValorMin = 0.001, ValorMax = 1.5, Unidade = "" },
                    new() { Simbolo = "omega_n", Nome = "ωn", Descricao = "Frequência natural não amortecida", ValorPadrao = 10, ValorMin = 0.001, Unidade = "rad/s" },
                ],
                VariavelResultado = "ts",
                UnidadeResultado = "s",
                Calcular = vars => 4.0 / (vars["zeta"] * vars["omega_n"])
            },

            new Formula
            {
                Id = "v2_ca03", CodigoCompendio = "080", Nome = "Overshoot Percentual %OS",
                Categoria = " Vol2: Controle Automático", SubCategoria = "Resposta Transitória",
                Expressao = "%OS = 100·exp(-πζ / √(1-ζ²))",
                ExprTexto ="%OS = 100 exp(-πζ/√(1-ζ²))",
                Icone = "🎛️",
                Descricao = "O overshoot percentual mede o quanto a resposta ultrapassa o valor final. Depende apenas de ζ (coeficiente de amortecimento). ζ=0: %OS=100% (oscilatório puro). ζ=0.7: %OS≈5%. ζ=1: %OS=0% (criticamente amortecido).",
                Criador = "Teoria de Controle Clássica",
                AnoOrigin = "~1940",
                ExemploPratico = "ζ=0.5: %OS=100·e^(-π·0.5/√0.75)≈16.3%. ζ=0.7: %OS≈4.6%. ζ=1: %OS=0%. Especificação comum: %OS≤10% → ζ≥0.6. Sintonizar controlador para ζ desejado.",
                Variaveis = [
                    new() { Simbolo = "zeta", Nome = "ζ", Descricao = "Coeficiente de amortecimento", ValorPadrao = 0.5, ValorMin = 0.001, ValorMax = 0.999, Unidade = "" },
                ],
                VariavelResultado = "%OS",
                UnidadeResultado = "%",
                Calcular = vars => {
                    double zeta = vars["zeta"];
                    if (zeta >= 1) return 0; // Sobreamortecido/criticamente amortecido
                    return 100 * Math.Exp(-Math.PI * zeta / Math.Sqrt(1 - zeta * zeta));
                }
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 21. DINÂMICA DE POPULAÇÕES E EPIDEMIOLOGIA
    // ─────────────────────────────────────────────────────
    private void AdicionarDinamicaPopulacoesCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_pop01", CodigoCompendio = "081", Nome = "Crescimento Malthusiano N(t) = N₀e^(rt)",
                Categoria = "Vol2: Biologia Matemática", SubCategoria = "Dinâmica de Populações",
                Expressao = "N(t) = N₀ · e^(rt)",
                ExprTexto = "N(t) = N₀ e^(rt)",
                Icone = "🧬",
                Descricao = "O modelo de Malthus descreve crescimento exponencial sem restrições: dN/dt=rN. r>0: crescimento exponencial. r<0: decaimento exponencial. Válido para populações pequenas com recursos ilimitados. Tempo de duplicação: T₂=ln(2)/r.",
                Criador = "Thomas Robert Malthus",
                AnoOrigin = "1798",
                ExemploPratico = "Bactérias: r=0.5/h, N₀=100 → N(2h)=100e^(0.5·2)=100e≈272. Crescimento humano histórico (simplificado): r≈0.012/ano. Tempo de duplicação: ln(2)/0.012≈58 anos.",
                Variaveis = [
                    new() { Simbolo = "N0", Nome = "N₀", Descricao = "População inicial", ValorPadrao = 100, ValorMin = 1, Unidade = "indivíduos" },
                    new() { Simbolo = "r", Nome = "r", Descricao = "Taxa de crescimento", ValorPadrao = 0.1, Unidade = "1/tempo" },
                    new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", ValorPadrao = 10, ValorMin = 0, Unidade = "tempo" },
                ],
                VariavelResultado = "N(t)",
                UnidadeResultado = "indivíduos",
                Calcular = vars => vars["N0"] * Math.Exp(vars["r"] * vars["t"])
            },

            new Formula
            {
                Id = "v2_pop02", CodigoCompendio = "082", Nome = "Modelo Logístico N(t) = K/(1+(K/N₀-1)e^(-rt))",
                Categoria = "Vol2: Biologia Matemática", SubCategoria = "Dinâmica de Populações",
                Expressao = "N(t) = K / (1 + (K/N₀ - 1)·e^(-rt))",
                ExprTexto = "N(t) = K / (1 + ((K-N₀)/N₀) e^(-rt))",
                Icone = "🧬",
                Descricao = "O modelo logístico de Verhulst incorpora capacidade de suporte K: dN/dt=rN(1-N/K). Crescimento sigmóide: lento, depois rápido, depois satura em K. Mais realista que Malthus. Ponto de inflexão em N=K/2.",
                Criador = "Pierre François Verhulst",
                AnoOrigin = "1838",
                ExemploPratico = "Leveduras em cultura: K=1000, N₀=10, r=0.5 → N(5)=1000/(1+99e^(-2.5))≈924. População de peixes em lago: K determinado por recursos. t→∞: N→K (capacidade de suporte).",
                Variaveis = [
                    new() { Simbolo = "K", Nome = "K", Descricao = "Capacidade de suporte", ValorPadrao = 1000, ValorMin = 1, Unidade = "indivíduos" },
                    new() { Simbolo = "N0", Nome = "N₀", Descricao = "População inicial", ValorPadrao = 10, ValorMin = 0.1, Unidade = "indivíduos" },
                    new() { Simbolo = "r", Nome = "r", Descricao = "Taxa de crescimento", ValorPadrao = 0.5, ValorMin = 0.001, Unidade = "1/tempo" },
                    new() { Simbolo = "t", Nome = "t", Descricao = "Tempo", ValorPadrao = 10, ValorMin = 0, Unidade = "tempo" },
                ],
                VariavelResultado = "N(t)",
                UnidadeResultado = "indivíduos",
                Calcular = vars => {
                    double K = vars["K"], N0 = vars["N0"], r = vars["r"], t = vars["t"];
                    return K / (1 + (K / N0 - 1) * Math.Exp(-r * t));
                }
            },

            new Formula
            {
                Id = "v2_sir01", CodigoCompendio = "083", Nome = "Número Básico de Reprodução R₀ = β/γ",
                Categoria = "Vol2: Biologia Matemática", SubCategoria = "Epidemiologia",
                Expressao = "R₀ = β / γ",
                ExprTexto = "R₀ = β/γ",
                Icone = "🧬",
                Descricao = "O número básico de reprodução R₀ é o número médio de infecções secundárias causadas por um indivíduo infectado em população completamente suscetível. β: taxa de transmissão. γ: taxa de recuperação. R₀>1: epidemia. R₀<1: doença desaparece.",
                Criador = "Kermack & McKendrick / Epidemiologia Matemática",
                AnoOrigin = "1927",
                ExemploPratico = "Gripe sazonal: R₀≈1.3. Sarampo: R₀≈12-18 (muito contagioso!). COVID-19 (variante original): R₀≈2.5. Se R₀=3: cada infectado gera 3 novos casos. Imunidade de rebanho: vacinação >1-1/R₀. Para R₀=3: >66.7%.",
                Variaveis = [
                    new() { Simbolo = "beta", Nome = "β", Descricao = "Taxa de transmissão", ValorPadrao = 0.5, ValorMin = 0.001, Unidade = "1/tempo" },
                    new() { Simbolo = "gamma", Nome = "γ", Descricao = "Taxa de recuperação", ValorPadrao = 0.2, ValorMin = 0.001, Unidade = "1/tempo" },
                ],
                VariavelResultado = "R₀",
                UnidadeResultado = "",
                Calcular = vars => vars["beta"] / vars["gamma"]
            },

            new Formula
            {
                Id = "v2_sir02", CodigoCompendio = "084", Nome = "Limiar de Imunidade de Rebanho 1 - 1/R₀",
                Categoria = "Vol2: Biologia Matemática", SubCategoria = "Epidemiologia",
                Expressao = "p_crit = 1 - 1/R₀",
                ExprTexto = "Proporção crítica vacinada = 1 - 1/R₀",
                Icone = "🧬",
                Descricao = "Para impedir disseminação epidêmica, uma fração p>1-1/R₀ da população deve ser imune (vacinada ou já infectada). Quanto maior R₀, maior a cobertura vacinal necessária. Protege também os não-vacinados (imunidade coletiva).",
                Criador = "Teoria Epidemiológica",
                AnoOrigin = "~1970",
                ExemploPratico = "Sarampo (R₀=15): p>1-1/15≈93.3% (exige alta cobertura!). Gripe (R₀=1.5): p>33.3%. Pólio (R₀≈5-7): p>80-86%. Sem vacina suficiente: doença ressurge (ex: sarampo em comunidades não-vacinadas).",
                Variaveis = [
                    new() { Simbolo = "R0", Nome = "R₀", Descricao = "Número básico de reprodução", ValorPadrao = 3, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "p_crit",
                UnidadeResultado = "",
                Calcular = vars => 1 - 1.0 / vars["R0"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 22. FARMACOCINÉTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarFarmacocineticaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_fk01", CodigoCompendio = "085", Nome = "Meia-Vida t₁/₂ = ln(2)/K",
                Categoria = "Vol2: Farmacoc inética", SubCategoria = "1-Compartimento",
                Expressao = "t₁/₂ = ln(2) / K",
                ExprTexto = "t₁/₂ = 0.693 / K",
                Icone = "💊",
                Descricao = "A meia-vida é o tempo para a concentração plasmática cair pela metade. K: constante de eliminação. Independente da dose ou concentração inicial. Após 5 meias-vidas, ~97% da droga é eliminada. Fundamental para determinação de intervalos de dose.",
                Criador = "Farmacocinética Clássica",
                AnoOrigin = "~1950",
                ExemploPratico = "Aspirina: t₁/₂≈20 min. Paracetamol: t₁/₂≈2-3h. Digoxina: t₁/₂≈36-48h (dose 1× ao dia). Warfarina: t₁/₂≈40h. Após 10h com t₁/₂=2h: restam (1/2)^5=3.125% da dose inicial.",
                Variaveis = [
                    new() { Simbolo = "K", Nome = "K", Descricao = "Constante de eliminação", ValorPadrao = 0.1, ValorMin = 0.001, Unidade = "1/h" },
                ],
                VariavelResultado = "t₁/₂",
                UnidadeResultado = "h",
                Calcular = vars => Math.Log(2) / vars["K"]
            },

            new Formula
            {
                Id = "v2_fk02", CodigoCompendio = "086", Nome = "Clearance Cl = K·Vd",
                Categoria = "Vol2: Farmacocinética", SubCategoria = "Parâmetros Farmacocinéticos",
                Expressao = "Cl = K · Vd",
                ExprTexto = "Clearance = K × Volume de Distribuição",
                Icone = "💊",
                Descricao = "O clearance é o volume de plasma completamente depurado da droga por unidade de tempo. Relaciona eliminação (K) com distribuição (Vd). Cl alto: eliminação rápida. Usado para calcular dose de manutenção: Dose=Cl·Css·τ.",
                Criador = "Farmacocinética",
                AnoOrigin = "~1960",
                ExemploPratico = "Creatinina (clearance renal): ~120 mL/min (homem adulto saudável). Droga com Vd=50L e K=0.2/h: Cl=50·0.2=10 L/h. Para Css=5 mg/L: taxa de infusão=10·5=50 mg/h.",
                Variaveis = [
                    new() { Simbolo = "K", Nome = "K", Descricao = "Constante de eliminação", ValorPadrao = 0.1, ValorMin = 0.001, Unidade = "1/h" },
                    new() { Simbolo = "Vd", Nome = "Vd", Descricao = "Volume de distribuição", ValorPadrao = 50, ValorMin = 1, Unidade = "L" },
                ],
                VariavelResultado = "Cl",
                UnidadeResultado = "L/h",
                Calcular = vars => vars["K"] * vars["Vd"]
            },

            new Formula
            {
                Id = "v2_fk03", CodigoCompendio = "087", Nome = "Concentração após Dose IV Bolus C(t) = C₀·e^(-Kt)",
                Categoria = "Vol2: Farmacocinética", SubCategoria = "1-Compartimento",
                Expressao = "C(t) = C₀ · e^(-K·t)",
                ExprTexto = "C(t) = (Dose/Vd) e^(-Kt)",
                Icone = "💊",
                Descricao = "Após dose intravenosa em bolus, a concentração plasmática decai exponencialmente. C₀=Dose/Vd: concentração inicial. Modelo de 1-compartimento assume distribuição instantânea e eliminação de primeira ordem.",
                Criador = "Teorell / Farmacocinética Compartmental",
                AnoOrigin = "1937",
                ExemploPratico = "Dose 500 mg, Vd=50L → C₀=10 mg/L. Se K=0.2/h, após 5h: C=10e^(-0.2·5)=10e^(-1)≈3.68 mg/L. Após 3 meias-vidas (~10.4h): C≈1.25 mg/L.",
                Variaveis = [
                    new() { Simbolo = "C0", Nome = "C₀", Descricao = "Concentração inicial (Dose/Vd)", ValorPadrao = 10, ValorMin = 0.001, Unidade = "mg/L" },
                    new() { Simbolo = "K", Nome = "K", Descricao = "Constante de eliminação", ValorPadrao = 0.2, ValorMin = 0.001, Unidade = "1/h" },
                    new() { Simbolo = "t", Nome = "t", Descricao = "Tempo após dose", ValorPadrao = 5, ValorMin = 0, Unidade = "h" },
                ],
                VariavelResultado = "C(t)",
                UnidadeResultado = "mg/L",
                Calcular = vars => vars["C0"] * Math.Exp(-vars["K"] * vars["t"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 23. NEUROCIÊNCIA - HODGKIN-HUXLEY
    // ─────────────────────────────────────────────────────
    private void AdicionarNeurocienciaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_hh01", CodigoCompendio = "088", Nome = "Potencial de Nernst E = (RT/zF)·ln([X]out/[X]in)",
                Categoria = "Vol2: Neurociência", SubCategoria = "Eletrofisiologia",
                Expressao = "E = (RT/zF) · ln([X]out / [X]in)",
                ExprTexto = "E = (RT/zF) ln([X]₀ᵤₜ/[X]ᵢₙ)",
                Icone = "🧠",
                Descricao = "A equação de Nernst calcula o potencial de equilíbrio para um íon através da membrana. R: constante dos gases (8.314 J/(mol·K)). T: temperatura (K). z: valência do íon. F: constante de Faraday (96485 C/mol). A 37°C: E≈61.5/z·log₁₀([X]out/[X]in) mV.",
                Criador = "Walther Nernst",
                AnoOrigin = "1889",
                ExemploPratico = "K⁺ (neurônio típico): [K]in≈140 mM, [K]out≈5 mM, z=+1 → EK≈-85 mV. Na⁺: [Na]in≈15 mM, [Na]out≈145 mM → ENa≈+60 mV. Cl⁻: z=-1, ECl≈-65 mV. Potencial de repouso ≈ -70 mV (próximo de EK, dominado por permeabilidade a K⁺).",
                Variaveis = [
                    new() { Simbolo = "X_out", Nome = "[X]out", Descricao = "Concentração externa (mM)", ValorPadrao = 5, ValorMin = 0.001, Unidade = "mM" },
                    new() { Simbolo = "X_in", Nome = "[X]in", Descricao = "Concentração interna (mM)", ValorPadrao = 140, ValorMin = 0.001, Unidade = "mM" },
                    new() { Simbolo = "z", Nome = "z", Descricao = "Valência do íon", ValorPadrao = 1, Unidade = "" },
                    new() { Simbolo = "T", Nome = "T", Descricao = "Temperatura", ValorPadrao = 310, ValorMin = 273, Unidade = "K" },
                ],
                VariavelResultado = "E",
                UnidadeResultado = "mV",
                Calcular = vars => {
                    double R = 8.314, F = 96485;
                    double factor = (R * vars["T"]) / (vars["z"] * F);
                    return factor * Math.Log(vars["X_out"] / vars["X_in"]) * 1000; // Converter V para mV
                }
            },

            new Formula
            {
                Id = "v2_hh02", CodigoCompendio = "089", Nome = "Tempo de Subida do Potencial de Ação",
                Categoria = "Vol2: Neurociência", SubCategoria = "Potencial de Ação",
                Expressao = "Δt_rise ≈ 1 ms (típico)",
                ExprTexto = "Tempo de subida do PA ≈ 0.5-1 ms",
                Icone = "🧠",
                Descricao = "O potencial de ação (PA) é um pulso elétrico rápido que viaja ao longo do axônio. Fase de subida (~1 ms): abertura de canais de Na⁺, despolarização de -70mV para +40mV. Fase de descida: inativação de Na⁺ e abertura de K⁺. Período refratário: ~2-3 ms.",
                Criador = "Hodgkin & Huxley",
                AnoOrigin = "1952",
                ExemploPratico = "Neurônio gigante de lula: PA dura ~2 ms total. Subida ultrapassa 0 mV até ~+40 mV. Velocidade de propagação: axônio mielinizado ~100 m/s, não-mielinizado ~1 m/s. Frequência máxima de disparo: ~500 Hz (limitado por período refratário).",
                Variaveis = [
                    new() { Simbolo = "V_rest", Nome = "V_repouso", Descricao = "Potencial de repouso", ValorPadrao = -70, Unidade = "mV" },
                    new() { Simbolo = "V_peak", Nome = "V_pico", Descricao = "Potencial de pico", ValorPadrao = 40, Unidade = "mV" },
                ],
                VariavelResultado = "ΔV",
                UnidadeResultado = "mV",
                Calcular = vars => vars["V_peak"] - vars["V_rest"]
            },
        ]);
    }
}
