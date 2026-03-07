using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═════════════════════════════════════════════════════════════
    //  VOLUME 2 — FÓRMULAS AVANÇADAS ADICIONAIS
    //  Deep Learning, Quantum Computing, Image Processing, Antenas
    // ═════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 16. DEEP LEARNING
    // ─────────────────────────────────────────────────────
    private void AdicionarDeepLearningCompleto()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_dl01", Nome = "Função de Ativação ReLU f(x) = max(0,x)",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Funções de Ativação",
                Expressao = "f(x) = max(0, x)",
                ExprTexto = "ReLU(x) = max(0,x) = x se x>0, senão 0",
                Icone = "🤖",
                Descricao = "A ReLU (Rectified Linear Unit) é a função de ativação mais usada em redes profundas. Vantagens: computacionalmente eficiente, evita vanishing gradient. Desvantagem: neurônios 'mortos' (sempre zero). Variantes: Leaky ReLU, parametric ReLU.",
                Criador = "Kunihiko Fukushima / Popular após AlexNet",
                AnoOrigin = "1969 / 2012",
                ExemploPratico = "x=-2 → ReLU=0. x=0 → 0. x=3 → 3. x=10 → 10. Derivada: 0 se x≤0, 1 se x>0 (step). AlexNet (2012) usou ReLU e venceu ImageNet. Hoje dominante em CNNs e redes profundas.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "x", Descricao = "Entrada do neurônio", ValorPadrao = 3, Unidade = "" },
                ],
                VariavelResultado = "ReLU(x)",
                UnidadeResultado = "",
                Calcular = vars => Math.Max(0, vars["x"])
            },

            new Formula
            {
                Id = "v2_dl02", Nome = "Função Sigmoid σ(x) = 1/(1+e^(-x))",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Funções de Ativação",
                Expressao = "σ(x) = 1 / (1 + e^(-x))",
                ExprTexto = "Sigmoid(x) = 1/(1+exp(-x))",
                Icone = "🤖",
                Descricao = "A função sigmoid mapeia entrada para (0,1), interpretável como probabilidade. Derivada: σ'=σ(1-σ). Usado em camadas de saída para classificação binária. Problema: vanishing gradient para |x| grandes. Substituída por ReLU em camadas ocultas.",
                Criador = "Modelos Logísticos / Redes Neurais Clássicas",
                AnoOrigin = "~1970-1980",
                ExemploPratico = "x=0 → σ=0.5. x=5 → σ≈0.993. x=-5 → σ≈0.007. x=10 → σ≈0.99995 (saturado). Usado em regressão logística, saída de GANs (generator), LSTM gates.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "x", Descricao = "Entrada", ValorPadrao = 0, Unidade = "" },
                ],
                VariavelResultado = "σ(x)",
                UnidadeResultado = "",
                Calcular = vars => 1.0 / (1 + Math.Exp(-vars["x"]))
            },

            new Formula
            {
                Id = "v2_dl03", Nome = "Tanh tanh(x) = (e^x - e^(-x))/(e^x + e^(-x))",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Funções de Ativação",
                Expressao = "tanh(x) = (e^x - e^(-x)) / (e^x + e^(-x))",
                ExprTexto = "tanh(x) = (eˣ - e⁻ˣ)/(eˣ + e⁻ˣ)",
                Icone = "🤖",
                Descricao = "A tanh mapeia entrada para (-1,1), centrada em zero. Derivada: tanh'=1-tanh². Melhor que sigmoid em camadas ocultas (média zero), mas ainda sofre vanishing gradient. Usado em RNNs e LSTMs (gates).",
                Criador = "Matemática Clássica / Redes Neurais",
                AnoOrigin = "~1980",
                ExemploPratico = "x=0 → tanh=0. x=2 → tanh≈0.964. x=-2 → tanh≈-0.964. x=5 → tanh≈0.9999 (quase saturado). Usado em LSTM (cell state update), GRU, autoencoders.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "x", Descricao = "Entrada", ValorPadrao = 1, Unidade = "" },
                ],
                VariavelResultado = "tanh(x)",
                UnidadeResultado = "",
                Calcular = vars => Math.Tanh(vars["x"])
            },

            new Formula
            {
                Id = "v2_dl04", Nome = "Erro Quadrático Médio (MSE)",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Funções de Perda",
                Expressao = "MSE = (1/n) Σ (yᵢ - ŷᵢ)²",
                ExprTexto = "MSE = (1/n) Σ (y - ŷ)²",
                Icone = "🤖",
                Descricao = "O MSE mede o erro quadrático médio entre valores verdadeiros y e predições ŷ. Usado em regressão. Derivada em relação a ŷ: 2(ŷ-y)/n. Sensível a outliers (penaliza erros grandes quadraticamente). Alternativas: MAE, Huber loss.",
                Criador = "Estatística Clássica",
                AnoOrigin = "~1800s (Gauss)",
                ExemploPratico = "y=[2,4,6], ŷ=[2.1,3.8,6.2]: MSE=(0.01+0.04+0.04)/3=0.03. Perfeitamente ajustado: MSE=0. Predições ruins podem ter MSE>1000. Usado em regressão linear, redes neurais para regressão.",
                Variaveis = [
                    new() { Simbolo = "y", Nome = "y (verdade)", Descricao = "Valor real", ValorPadrao = 5, Unidade = "" },
                    new() { Simbolo = "y_hat", Nome = "ŷ (predição)", Descricao = "Valor predito", ValorPadrao = 4.8, Unidade = "" },
                ],
                VariavelResultado = "Erro²",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["y"] - vars["y_hat"], 2)
            },

            new Formula
            {
                Id = "v2_dl05", Nome = "Entropia Cruzada H(p,q) = -Σ pᵢ log(qᵢ)",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Funções de Perda",
                Expressao = "H(p,q) = -Σ pᵢ · log(qᵢ)",
                ExprTexto = "CrossEntropy = -Σ p(x) log q(x)",
                Icone = "🤖",
                Descricao = "A entropia cruzada mede a dissimilaridade entre distribuição verdadeira p e predita q. Para classificação: p é one-hot, q é softmax output. Minimizar entropia cruzada maximiza log-verossimilhança. Padrão para classificação multiclasse.",
                Criador = "Teoria da Informação / Claude Shannon",
                AnoOrigin = "1948",
                ExemploPratico = "Classificação 3 classes: p=[00,1,0] (classe 2), q=[0.1,0.7,0.2]: H=-log(0.7)≈0.36. Se q perfeito [0,1,0]: H=0. Se q ruim [0.4,0.3,0.3]: H=-log(0.3)≈1.2. Usado em softmax+cross-entropy.",
                Variaveis = [
                    new() { Simbolo = "q_pred", Nome = "q (predição)", Descricao = "Probabilidade predita da classe verdadeira", ValorPadrao = 0.7, ValorMin = 0.0001, ValorMax = 1, Unidade = "" },
                ],
                VariavelResultado = "H",
                UnidadeResultado = "",
                Calcular = vars => -Math.Log(vars["q_pred"])
            },

            new Formula
            {
                Id = "v2_dl06", Nome = "Gradiente Descendente θ ← θ - η·∇L",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Otimização",
                Expressao = "θ_new = θ_old - η · ∇L",
                ExprTexto = "θ ← θ - learning_rate × gradient",
                Icone = "🤖",
                Descricao = "O gradiente descendente atualiza parâmetros θ na direção oposta ao gradiente da perda L. η: learning rate (passo). Convergência depende de η: muito alto → oscila/diverge, muito baixo → lento. Versões: batch, mini-batch, stochastic.",
                Criador = "Augustin-Louis Cauchy / Otimização",
                AnoOrigin = "1847",
                ExemploPratico = "θ=5, ∇L=2, η=0.1 → θ'=5-0.1·2=4.8. Iteração: 4.8→4.6→... Learning rates típicos: 0.001-0.1 para Adam, 0.01-1 para SGD. Técnicas: learning rate decay, warm-up, schedules.",
                Variaveis = [
                    new() { Simbolo = "theta", Nome = "θ", Descricao = "Parâmetro atual", ValorPadrao = 5, Unidade = "" },
                    new() { Simbolo = "grad", Nome = "∇L", Descricao = "Gradiente da perda", ValorPadrao = 2, Unidade = "" },
                    new() { Simbolo = "eta", Nome = "η", Descricao = "Learning rate", ValorPadrao = 0.1, ValorMin = 0.00001, ValorMax = 1, Unidade = "" },
                ],
                VariavelResultado = "θ_new",
                UnidadeResultado = "",
                Calcular = vars => vars["theta"] - vars["eta"] * vars["grad"]
            },

            new Formula
            {
                Id = "v2_dl07", Nome = "Momentum v ← βv + ∇L; θ ← θ - ηv",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Otimização",
                Expressao = "v = β·v + ∇L; θ = θ - η·v",
                ExprTexto = "Momentum: v ← βv + grad; θ ← θ - ηv",
                Icone = "🤖",
                Descricao = "Momentum acelera convergência acumulando gradientes passados (média exponencial móvel). β∈[0,1): típico 0.9. Reduz oscilações e acelera direções consistentes. Análogo à inércia física: 'bola' rolando ladeira abaixo.",
                Criador = "Polyak / Sutskever et al",
                AnoOrigin = "1964 / 2013",
                ExemploPratico = "β=0.9: v acumula 90% do momentum anterior + 10% do novo gradiente. Com momentum, escapa mais fácil de platôs. Usado em SGD with momentum (padrão antes de Adam). Nesterov momentum: antecipa posição futura.",
                Variaveis = [
                    new() { Simbolo = "v", Nome = "v (velocity)", Descricao = "Momentum acumulado", ValorPadrao = 0.5, Unidade = "" },
                    new() { Simbolo = "grad", Nome = "∇L", Descricao = "Gradiente atual", ValorPadrao = 1, Unidade = "" },
                    new() { Simbolo = "beta", Nome = "β", Descricao = "Coeficiente de momentum", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 0.999, Unidade = "" },
                ],
                VariavelResultado = "v_new",
                UnidadeResultado = "",
                Calcular = vars => vars["beta"] * vars["v"] + vars["grad"]
            },

            new Formula
            {
                Id = "v2_dl08", Nome = "Dropout: Regularização Probabilística",
                Categoria = "Vol2: Deep Learning", SubCategoria = "Regularização",
                Expressao = "y = x · mask (durante treino); y = p·x (inferência)",
                ExprTexto = "Dropout: desativar neurônios com prob. p durante treino",
                Icone = "🤖",
                Descricao = "Dropout desativa aleatoriamente neurônios durante treino (com probabilidade p, típico 0.5). Previne co-adaptação de neurônios (overfitting). Durante inferência: multiplicar ativações por p (ou dividir por 1-p durante treino - inverted dropout). Técnica fundamental em deep learning.",
                Criador = "Hinton et al",
                AnoOrigin = "2012",
                ExemploPratico = "Camada com 100 neurônios, p=0.5: em cada batch, ~50 neurônios desativados (zeros). Ensemble implícito: treina 2^n sub-redes. AlexNet usou dropout(0.5) em camadas FC. Batch normalization reduziu necessidade de dropout.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "x", Descricao = "Ativação do neurônio", ValorPadrao = 5, Unidade = "" },
                    new() { Simbolo = "p", Nome = "p", Descricao = "Probabilidade de manter neurônio (keep_prob)", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Unidade = "" },
                    new() { Simbolo = "active", Nome = "mask", Descricao = "1=ativo, 0=dropout", ValorPadrao = 1, Unidade = "" },
                ],
                VariavelResultado = "y_train",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] * vars["active"] // Durante treino
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 17. COMPUTAÇÃO QUÂNTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarComputacaoQuanticaCompleto()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_qc01", Nome = "Qubit: |ψ⟩ = α|0⟩ + β|1⟩",
                Categoria = "Vol2: Computação Quântica", SubCategoria = "Fundamentos",
                Expressao = "|α|² + |β|² = 1",
                ExprTexto = "Condição de normalização: |α|² + |β|² = 1",
                Icone = "⚛️",
                Descricao = "Um qubit é a unidade básica de informação quântica, em superposição de estados |0⟩ e |1⟩. α,β: amplitudes de probabilidade (complexos). |α|²: probabilidade de medir |0⟩. |β|²: probabilidade de medir |1⟩. Normalização garante probabilidades somam 1.",
                Criador = "Mecânica Quântica / Computação Quântica",
                AnoOrigin = "1980s (Feynman, Deutsch)",
                ExemploPratico = "|+⟩=(|0⟩+|1⟩)/√2: α=β=1/√2, |α|²=|β|²=0.5 (50% cada). |-⟩=(|0⟩-|1⟩)/√2. |0⟩: α=1, β=0. Com n qubits: 2^n estados simultâneos! 300 qubits > átomos no universo.",
                Variaveis = [
                    new() { Simbolo = "alpha", Nome = "α", Descricao = "Amplitude do estado |0⟩", ValorPadrao = 0.707, Unidade = "" },
                    new() { Simbolo = "beta", Nome = "β", Descricao = "Amplitude do estado |1⟩", ValorPadrao = 0.707, Unidade = "" },
                ],
                VariavelResultado = "|α|² + |β|²",
                UnidadeResultado = "",
                Calcular = vars => vars["alpha"] * vars["alpha"] + vars["beta"] * vars["beta"]
            },

            new Formula
            {
                Id = "v2_qc02", Nome = "Porta Hadamard H",
                Categoria = "Vol2: Computação Quântica", SubCategoria = "Portas Quânticas",
                Expressao = "H|0⟩ = (|0⟩+|1⟩)/√2; H|1⟩ = (|0⟩-|1⟩)/√2",
                ExprTexto = "Hadamard cria superposição equi provável",
                Icone = "⚛️",
                Descricao = "A porta Hadamard cria superposição: transforma base computacional {|0⟩,|1⟩} em base de superposição {|+⟩,|-⟩}. H²=I (aplicação dupla retorna estado original). Matriz: H=(1/√2)[[1,1],[1,-1]].",
                Criador = "Jacques Hadamard / Computação Quântica",
                AnoOrigin = "1893 (matriz) / 1990s (porta quântica)",
                ExemploPratico = "Algoritmo de Deutsch-Jozsa: aplicar H em todos qubits inicialmente. Grover: preparação de superposição uniforme. Shor: criação de estados periódicos. Teleportação quântica usa H no qubit de Alice.",
                Variaveis = [
                    new() { Simbolo = "input", Nome = "Estado entrada", Descricao = "0 para |0⟩, 1 para |1⟩", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Unidade = "" },
                ],
                VariavelResultado = "Coef. |0⟩",
                UnidadeResultado = "",
                Calcular = vars => {
                    double input = vars["input"];
                    return (input == 0) ? 1.0 / Math.Sqrt(2) : 1.0 / Math.Sqrt(2); // Coeficiente de |0⟩
                }
            },

            new Formula
            {
                Id = "v2_qc03", Nome = "Emaranhamento (Entrelaçamento) Quântico",
                Categoria = "Vol2: Computação Quântica", SubCategoria = "Fenômenos Quânticos",
                Expressao = "|Φ⁺⟩ = (|00⟩ + |11⟩) / √2",
                ExprTexto = "Estado de Bell: (|00⟩ + |11⟩)/√2",
                Icone = "⚛️",
                Descricao = "Estados emaranhados (entangled) não podem ser fatorados em produto tensorial de estados individuais. Medição em um qubit instantaneamente determina o outro (correlação não-local). Base de Bell: 4 estados maximamente emaranhados. Fundamental para teleportação quântica, criptografia quântica, computação quântica.",
                Criador = "Einstein-Podolsky-Rosen / John Bell",
                AnoOrigin = "1935 / 1964",
                ExemploPratico = "Estado |Φ⁺⟩: medir qubit 1 → |0⟩ ou |1⟩ com 50%. Se |0⟩, qubit 2 colapsa para |0⟩. Se |1⟩, qubit 2 → |1⟩. Perfeitamente correlacionados! Teleportação quântica usa par EPR. Computadores quânticos: emaranhamento gera paralelismo exponencial.",
                Variaveis = [
                    new() { Simbolo = "measurement", Nome = "Medição", Descricao = "Resultado da medição (0 ou 1)", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Unidade = "" },
                ],
                VariavelResultado = "Prob. |00⟩ ou |11⟩",
                UnidadeResultado = "",
                Calcular = vars => 0.5 // Probabilidade de medir |00⟩ ou |11⟩
            },

            new Formula
            {
                Id = "v2_qc04", Nome = "Algoritmo de Grover: Speedup O(√N)",
                Categoria = "Vol2: Computação Quântica", SubCategoria = "Algoritmos Quânticos",
                Expressao = "Iterações ≈ (π/4)√N",
                ExprTexto = "Número de iterações do algoritmo de Grover ≈ 0.785√N",
                Icone = "⚛️",
                Descricao = "O algoritmo de Grover busca em banco de dados não-ordenado em O(√N) (clássico: O(N)). Usa amplitude amplification: amplifica amplitude do item alvo, suprime outros. Quadratic speedup universal para busca não-estruturada. Requer (π/4)√N iterações (~0.785√N).",
                Criador = "Lov Grover",
                AnoOrigin = "1996",
                ExemploPratico = "N=10⁶ elementos: clássico ~10⁶ consultas, Grover ~1000 (√10⁶). N=10¹²: clássico 1 trilhão, Grover 1 milhão. Aplicações: quebra de criptografia simétrica (ex: AES-128 → efetivo 64-bit security), SAT solving, otimização.",
                Variaveis = [
                    new() { Simbolo = "N", Nome = "N", Descricao = "Tamanho do espaço de busca", ValorPadrao = 1000000, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "Iterações",
                UnidadeResultado = "",
                Calcular = vars => (Math.PI / 4.0) * Math.Sqrt(vars["N"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 20. ANTENAS E PROPAGAÇÃO
    // ─────────────────────────────────────────────────────
    private void AdicionarAntenasCompleto()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_ant01", Nome = "Equação de Friis Pr = Pt·Gt·Gr·(λ/4πd)²",
                Categoria = "Vol2: Antenas e Propagação", SubCategoria = "Propagação",
                Expressao = "Pr = Pt · Gt · Gr · (λ/(4πd))²",
                ExprTexto = "Pr = Pt Gt Gr (λ/4πd)²",
                Icone = "📡",
                Descricao = "A equação de Friis calcula potência recebida Pr em espaço livre. Pt: potência transmitida. Gt, Gr: ganhos das antenas. λ: comprimento de onda. d: distância. (λ/4πd)² é a perda de espaço livre (path loss). Válida para campo distante (d >> λ).",
                Criador = "Harald T. Friis",
                AnoOrigin = "1946",
                ExemploPratico = "Wi-Fi 2.4GHz (λ=12.5cm), Pt=100mW, Gt=Gr=1 (isotrópicas), d=10m: FSPL=(4π·10/0.125)²≈6.3×10⁶ (-68dB). Pr=100mW/6.3×10⁶≈16nW (-48dBm). Na prática: absorção, reflexões reduzem ainda mais.",
                Variaveis = [
                    new() { Simbolo = "Pt", Nome = "Pt", Descricao = "Potência transmitida", ValorPadrao = 0.1, ValorMin = 0.001, Unidade = "W" },
                    new() { Simbolo = "Gt", Nome = "Gt", Descricao = "Ganho da antena transmissora", ValorPadrao = 1, ValorMin = 0.1, Unidade = "" },
                    new() { Simbolo = "Gr", Nome = "Gr", Descricao = "Ganho da antena receptora", ValorPadrao = 1, ValorMin = 0.1, Unidade = "" },
                    new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento de onda", ValorPadrao = 0.125, ValorMin = 0.001, Unidade = "m" },
                    new() { Simbolo = "d", Nome = "d", Descricao = "Distância", ValorPadrao = 10, ValorMin = 1, Unidade = "m" },
                ],
                VariavelResultado = "Pr",
                UnidadeResultado = "W",
                Calcular = vars => {
                    double factor = vars["lambda"] / (4 * Math.PI * vars["d"]);
                    return vars["Pt"] * vars["Gt"] * vars["Gr"] * factor * factor;
                }
            },

            new Formula
            {
                Id = "v2_ant02", Nome = "Perda de Espaço Livre (FSPL) dB",
                Categoria = "Vol2: Antenas e Propagação", SubCategoria = "Propagação",
                Expressao = "FSPL(dB) = 20·log₁₀(d) + 20·log₁₀(f) + 20·log₁₀(4π/c)",
                ExprTexto = "FSPL(dB) ≈ 20log(d) + 20log(f) - 147.55",
                Icone = "📡",
                Descricao = "A perda de espaço livre em dB quantifica atenuação do sinal sem obstáculos. Aumenta 20dB/década de distância e 20dB/década de frequência. c≈3×10⁸ m/s. Simplificação: FSPL≈20log(d[km])+20log(f[MHz])+32.45 dB.",
                Criador = "Teoria de Propagação Eletromagnética",
                AnoOrigin = "~1940-1950",
                ExemploPratico = "f=2.4GHz, d=100m: FSPL≈20log(0.1)+20log(2400)+32.45=-20+67.6+32.45=80 dB. GPS (1.5GHz, satélite 20000km): FSPL≈184 dB!! (sinal muito fraco, precisa amplificação).",
                Variaveis = [
                    new() { Simbolo = "d_km", Nome = "d (km)", Descricao = "Distância em km", ValorPadrao = 1, ValorMin = 0.001, Unidade = "km" },
                    new() { Simbolo = "f_MHz", Nome = "f (MHz)", Descricao = "Frequência em MHz", ValorPadrao = 900, ValorMin = 1, Unidade = "MHz" },
                ],
                VariavelResultado = "FSPL",
                UnidadeResultado = "dB",
                Calcular = vars => 20 * Math.Log10(vars["d_km"]) + 20 * Math.Log10(vars["f_MHz"]) + 32.45
            },

            new Formula
            {
                Id = "v2_ant03", Nome = "Ganho de Antena G = 4πA/λ²",
                Categoria = "Vol2: Antenas e Propagação", SubCategoria = "Antenas",
                Expressao = "G = 4π · A / λ²",
                ExprTexto = "Ganho = 4π × Área efetiva / λ²",
                Icone = "📡",
                Descricao = "O ganho de uma antena relaciona área efetiva A com comprimento de onda λ. Ganho isotrópico (adimensional): G=1 para antena omnidirecional ideal. Antena direcional: ganho alto (concentra energia). dBi: ganho em dB relativo a isotrópica.",
                Criador = "Teoria de Antenas",
                AnoOrigin = "~1940",
                ExemploPratico = "Parábola 1m², λ=3cm (10GHz): G=4π·1/0.0009≈14000 (41.5dBi). Dipolo λ/2: G=1.64 (2.15dBi). Antena corneta: G~10-25dB. Satélites: parabólicas grandes (30-60dBi).",
                Variaveis = [
                    new() { Simbolo = "A", Nome = "A", Descricao = "Área efetiva da antena", ValorPadrao = 1, ValorMin = 0.01, Unidade = "m²" },
                    new() { Simbolo = "lambda", Nome = "λ", Descricao = "Comprimento de onda", ValorPadrao = 0.03, ValorMin = 0.001, Unidade = "m" },
                ],
                VariavelResultado = "G",
                UnidadeResultado = "",
                Calcular = vars => (4 * Math.PI * vars["A"]) / (vars["lambda"] * vars["lambda"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 19. PROCESSAMENTO DE IMAGEM (VISÃO COMPUTACIONAL)
    // ─────────────────────────────────────────────────────
    private void AdicionarProcessamentoImagemCompleto()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_img01", Nome = "Kernel Gaussiano 2D para Blur",
                Categoria = "Vol2: Processamento de Imagem", SubCategoria = "Filtros",
                Expressao = "G(x,y) = (1/2πσ²)·e^(-(x²+y²)/2σ²)",
                ExprTexto = "Gaussiano 2D: G(x,y) = (1/2πσ²) exp(-(x²+y²)/2σ²)",
                Icone = "🖼️",
                Descricao = "O filtro Gaussiano suaviza imagens, reduzindo ruído. σ: desvio padrão (controla largura do kernel). Kernel maior: mais blur. Implementado como convolução 2D. Separável: G(x,y)=G(x)·G(y) (eficiente). Usado antes de detecção de bordas (Canny).",
                Criador = "Carl Friedrich Gauss / Processamento Digital",
                AnoOrigin = "~1970-1980",
                ExemploPratico = "σ=1: kernel 3×3. σ=2: kernel 5×5 ou 7×7. Para remover ruído fino: σ≈1-2. Para blur artístico: σ≥5. Gaussian blur em Photoshop, pré-processamento de CNNs (não comum hoje - data augmentation).",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "x", Descricao = "Coordenada x (relativa ao centro)", ValorPadrao = 0, Unidade = "pixels" },
                    new() { Simbolo = "y", Nome = "y", Descricao = "Coordenada y (relativa ao centro)", ValorPadrao = 1, Unidade = "pixels" },
                    new() { Simbolo = "sigma", Nome = "σ", Descricao = "Desvio padrão do Gaussiano", ValorPadrao = 1, ValorMin = 0.1, Unidade = "pixels" },
                ],
                VariavelResultado = "G(x,y)",
                UnidadeResultado = "",
                Calcular = vars => {
                    double sigma = vars["sigma"];
                    double x = vars["x"], y = vars["y"];
                    double norm = 1.0 / (2 * Math.PI * sigma * sigma);
                    double exponent = -(x * x + y * y) / (2 * sigma * sigma);
                    return norm * Math.Exp(exponent);
                }
            },

            new Formula
            {
                Id = "v2_img02", Nome = "Filtro Sobel para Detecção de Bordas",
                Categoria = "Vol2: Processamento de Imagem", SubCategoria = "Detecção de Bordas",
                Expressao = "∇I = √(Gx² + Gy²)",
                ExprTexto = "Magnitude do gradiente: |∇I| = √(Gx² + Gy²)",
                Icone = "🖼️",
                Descricao = "O operador de Sobel detecta bordas calculando gradiente da intensidade da imagem. Gx: derivada horizontal (Sobel-x kernel). Gy: derivada vertical (Sobel-y). Magnitude: força da borda. Direção: θ=arctan(Gy/Gx). Kernels 3×3: [-1,0,1; -2,0,2; -1,0,1] para Gx.",
                Criador = "Irwin Sobel",
                AnoOrigin = "1968",
                ExemploPratico = "Gx=3, Gy=4 → |∇I|=5 (borda forte). Gx=-2, Gy=0 → |∇I|=2 (borda horizontal). Usado em: detecção de contornos, pré-processamento, feature extraction. Canny usa Sobel internamente. Alternativas: Prewitt, Scharr (mais preciso).",
                Variaveis = [
                    new() { Simbolo = "Gx", Nome = "Gx", Descricao = "Gradiente horizontal", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "Gy", Nome = "Gy", Descricao = "Gradiente vertical", ValorPadrao = 4, Unidade = "" },
                ],
                VariavelResultado = "|∇I|",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["Gx"] * vars["Gx"] + vars["Gy"] * vars["Gy"])
            },
        ]);
    }
}
