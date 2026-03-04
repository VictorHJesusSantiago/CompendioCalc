using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 4 — PARTE V: BIOLOGIA, MEDICINA E PSICOMETRIA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 19. MORFOGÊNESE, PADRÕES DE TURING E REDES NEURAIS BIOLÓGICAS
    // ─────────────────────────────────────────────────────
    private void AdicionarMorfogeneseTuring()
    {
        _formulas.AddRange([
            // 19.1 Padrões de Turing
            new Formula
            {
                Id = "4_tu01", Nome = "Reação-Difusão (Geral)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = D_u∇²u + f(u,v);  ∂v/∂t = D_v∇²v + g(u,v)",
                ExprTexto = "∂u/∂t=Du∇²u+f(u,v); ∂v/∂t=Dv∇²v+g(u,v)",
                Icone = "RD",
                Descricao = "Sistema de reação-difusão com dois morfogênios u (ativador) e v (inibidor). Turing: se Dv≫Du, estado homogêneo pode ser instável → formação espontânea de padrões.",
                Criador = "Alan Turing",
                AnoOrigin = "1952",
            },
            new Formula
            {
                Id = "4_tu02", Nome = "Condição de Instabilidade de Turing", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "fu+gv < 0, fu·gv-fg·gu > 0, Dv·fu+Du·gv > 0",
                ExprTexto = "tr(J)<0,det(J)>0, Dv·fu+Du·gv>0",
                Icone = "ins",
                Descricao = "Estado homogêneo localmente estável (traço<0, det>0), mas difusão desestabiliza: existe k² tal que Re(λ(k²))>0. Requer Dv/Du > limiar crítico (razão de difusividade).",
            },
            new Formula
            {
                Id = "4_tu03", Nome = "Modelo de Gierer-Meinhardt", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂a/∂t = Da∇²a + ρ(a²/h) - μa + ρ₀;  ∂h/∂t = Dh∇²h + ρ'a² - νh",
                ExprTexto = "ȧ=Da∇²a+ρa²/h−μa; ḣ=Dh∇²h+ρ'a²−νh",
                Icone = "GM",
                Descricao = "Ativador-Inibidor: a = ativador (autocatálise a²), h = inibidor (longo alcance, Dh≫Da). Gera manchas, listras (zebra, leopardo). Modelo seminal em biologia do desenvolvimento.",
                Criador = "Alfred Gierer / Hans Meinhardt",
                AnoOrigin = "1972",
            },
            new Formula
            {
                Id = "4_tu04", Nome = "Modelo de Gray-Scott", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = Du∇²u - uv² + F(1-u);  ∂v/∂t = Dv∇²v + uv² - (F+k)v",
                ExprTexto = "u̇=Du∇²u−uv²+F(1−u); v̇=Dv∇²v+uv²−(F+k)v",
                Icone = "GS",
                Descricao = "Modelo com cinética autocatalítica cúbica. Riquíssima variedade de padrões: manchas, listras, labirintos, solitons, caos espaço-temporal. F = taxa de alimentação, k = taxa de remoção.",
            },
            new Formula
            {
                Id = "4_tu05", Nome = "Equação de Swift-Hohenberg", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = εu - (1+∇²)²u - u³",
                ExprTexto = "u̇ = εu−(1+∇²)²u−u³",
                Icone = "SH",
                Descricao = "Modelo canônico para formação de padrões com comprimento de onda preferencial k=1. Bifurcação em ε=0. Usado em convecção de Rayleigh-Bénard, cristais líquidos, óptica.",
                Criador = "Jack Swift / Pierre Hohenberg",
                AnoOrigin = "1977",
            },
            new Formula
            {
                Id = "4_tu06", Nome = "Equação de Cahn-Hilliard", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂c/∂t = M∇²(∂F/∂c - κ∇²c);  F = ¼(c²-1)²",
                ExprTexto = "∂c/∂t = M∇²(δF/δc); F=free energy",
                Icone = "CH",
                Descricao = "Separação de fases com conservação de massa: c = concentração, F = energia livre de Ginzburg-Landau, κ = rigidez da interface. Decomposição espinodal, coalescência de domínios.",
                Criador = "John Cahn / John Hilliard",
                AnoOrigin = "1958",
            },
            new Formula
            {
                Id = "4_tu07", Nome = "Quimiotaxia (Keller-Segel)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂ρ/∂t = D∇²ρ - χ∇·(ρ∇c);  ∂c/∂t = Dc∇²c + αρ - βc",
                ExprTexto = "ρ̇=D∇²ρ−χ∇·(ρ∇c); ċ=Dc∇²c+αρ−βc",
                Icone = "KS",
                Descricao = "Células ρ migram em direção ao gradiente do quimioatrativo c (χ>0). Agregação pode levar a blow-up em tempo finito (2D: se massa > 8π/χ). Modelo de Dictyostelium, angiogênese.",
                Criador = "Evelyn Keller / Lee Segel",
                AnoOrigin = "1970",
            },
            new Formula
            {
                Id = "4_tu08", Nome = "Onda de Propagação (Fisher-KPP)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = D∇²u + ru(1-u);  velocidade mínima c* = 2√(rD)",
                ExprTexto = "u̇=D∇²u+ru(1−u); c*=2√(rD)",
                Icone = "KPP",
                Descricao = "Frente de onda viajante em reação-difusão logística. c* = velocidade mínima de propagação: selecionada para condições iniciais compactas. Invasão de espécies, propagação de genes.",
                Criador = "Fisher / Kolmogorov-Petrovsky-Piskunov",
                AnoOrigin = "1937",
            },
            // 19.2 Redes Neurais Biológicas
            new Formula
            {
                Id = "4_wc01", Nome = "Modelo de Wilson-Cowan", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "τₑĖ = -E + Sₑ(wₑₑE - wₑᵢI + Iₑₓₜ)",
                ExprTexto = "τeĖ = −E+Se(weeE−weiI+Iext)",
                Icone = "WC",
                Descricao = "Taxa de disparo da população excitatória E. Se = sigmoide. wee = peso E→E, wei = peso I→E. Base de modelos de campo médio cortical: gera oscilações, bifurcações.",
                Criador = "Hugh Wilson / Jack Cowan",
                AnoOrigin = "1972",
            },
            new Formula
            {
                Id = "4_wc02", Nome = "Wilson-Cowan (Inibitória)", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "τᵢİ = -I + Sᵢ(wᵢₑE - wᵢᵢI + Iᵢₑₓₜ)",
                ExprTexto = "τiİ = −I+Si(wieE−wiiI+Iiext)",
                Icone = "WCi",
                Descricao = "População inibitória I recebe excitação de E (wie) e auto-inibição (wii). Balanço E/I crucial: desequilíbrio → epilepsia (excesso E) ou coma (excesso I).",
            },
            new Formula
            {
                Id = "4_wc03", Nome = "Bifurcação de Hopf (Oscilações)", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "tr(J)=0 → ciclo limite;  ω = √(det J) no limiar",
                ExprTexto = "tr(J)=0: Hopf → oscilações com ω=√detJ",
                Icone = "Hopf",
                Descricao = "Transição de ponto fixo estável para ciclo limite: par de autovalores complexos cruza eixo imaginário. Gera ritmos cerebrais (α~10Hz, γ~40Hz). Supercrítica = suave, subcrítica = abrupta.",
            },
            new Formula
            {
                Id = "4_wc04", Nome = "Neural Field Equation", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "τ∂u/∂t = -u + ∫w(x-x')S(u(x'))dx' + I(x)",
                ExprTexto = "τu̇ = −u+∫w(x−x')S(u)dx'+I",
                Icone = "NFE",
                Descricao = "Teoria de campo neural (Amari/Wilson-Cowan contínuo): w = kernel de conectividade (Mexican hat: excitação local, inibição lateral). Gera bumps de atividade (memória de trabalho), ondas.",
                Criador = "Shun-ichi Amari",
                AnoOrigin = "1977",
            },
            new Formula
            {
                Id = "4_wc05", Nome = "FitzHugh-Nagumo", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "v̇ = v - v³/3 - w + I;  ẇ = ε(v + a - bw)",
                ExprTexto = "v̇=v−v³/3−w+I; ẇ=ε(v+a−bw)",
                Icone = "FHN",
                Descricao = "Simplificação de Hodgkin-Huxley para 2D: v = voltagem (rápida), w = recuperação (lenta, ε≪1). Excitabilidade, oscilações, bistabilidade dependendo de parâmetros a,b,I.",
                Criador = "Richard FitzHugh / Jinichi Nagumo",
                AnoOrigin = "1961",
            },
            new Formula
            {
                Id = "4_wc06", Nome = "Izhikevich (Neurônio)", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "v̇ = 0.04v² + 5v + 140 - u + I;  u̇ = a(bv-u); if v≥30: v→c, u→u+d",
                ExprTexto = "v̇=0.04v²+5v+140−u+I; u̇=a(bv−u)",
                Icone = "Izh",
                Descricao = "Modelo de neurônio computacionalmente eficiente (2 variáveis + reset) que reproduz ~20 padrões de disparo biológicos variando a,b,c,d. Simula redes de 10⁶ neurônios em tempo real.",
                Criador = "Eugene Izhikevich",
                AnoOrigin = "2003",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 20. RECONSTRUÇÃO DE IMAGEM MÉDICA
    // ─────────────────────────────────────────────────────
    private void AdicionarImagemMedica()
    {
        _formulas.AddRange([
            // 20.1 Tomografia Computadorizada
            new Formula
            {
                Id = "4_ct01", Nome = "Transformada de Radon", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "Rf(θ,s) = ∫∫ f(x,y)δ(xcosθ+ysinθ-s)dxdy",
                ExprTexto = "Rf(θ,s) = ∫f·δ(xcosθ+ysinθ−s)dA",
                Icone = "R",
                Descricao = "Integral de f ao longo da reta xcosθ+ysinθ=s: projeção no ângulo θ. CT coleta projeções em muitos ângulos. Problema inverso: reconstruir f a partir de Rf.",
                Criador = "Johann Radon",
                AnoOrigin = "1917",
            },
            new Formula
            {
                Id = "4_ct02", Nome = "Teorema da Fatia de Fourier", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "F₁D{Rf(θ,·)}(ω) = F₂D{f}(ωcosθ, ωsinθ)",
                ExprTexto = "FT(projeção θ) = FT₂D ao longo de θ",
                Icone = "FST",
                Descricao = "Transformada de Fourier 1D da projeção no ângulo θ = fatia da TF 2D de f na mesma direção. Base teórica de todos os métodos de reconstrução tomográfica.",
            },
            new Formula
            {
                Id = "4_ct03", Nome = "Retroprojeção Filtrada (FBP)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "f(x,y) = ∫₀^π [p_θ * h](xcosθ+ysinθ) dθ",
                ExprTexto = "f = ∫₀^π (pθ*h)(xcosθ+ysinθ)dθ",
                Icone = "FBP",
                Descricao = "Algoritmo padrão de CT: filtrar projeções com kernel rampa (|ω|) e retroprojetar. O(N³) para imagem N×N. Rápido e robusto. Usado em scanners clínicos desde anos 1970.",
            },
            new Formula
            {
                Id = "4_ct04", Nome = "Reconstrução Iterativa (MBIR)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "x̂ = argmin_x ‖Ax-b‖² + λR(x)",
                ExprTexto = "x̂ = argmin ‖Ax−b‖²+λR(x)",
                Icone = "MBIR",
                Descricao = "Reconstrução model-based: A = operador de projeção, b = sinograma medido, R = regularização (TV, wavelets). Superior a FBP para dose baixa e dados incompletos. Custo: iterações O(N²) de projeção.",
            },
            new Formula
            {
                Id = "4_ct05", Nome = "Número de CT (Hounsfield)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "HU = 1000·(μ-μ_água)/μ_água",
                ExprTexto = "HU = 1000(μ−μágua)/μágua",
                Icone = "HU",
                Descricao = "Escala padronizada: ar = -1000 HU, água = 0 HU, osso = +1000 HU. μ = coeficiente de atenuação linear. Janela/nível: soft tissue ~40/400, pulmão ~-600/1500.",
                Criador = "Godfrey Hounsfield",
                AnoOrigin = "1971",
            },
            new Formula
            {
                Id = "4_ct06", Nome = "Dose de Radiação (CTDI)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "CTDI = (1/nT)∫D(z)dz;  DLP = CTDI×L",
                ExprTexto = "CTDI = (1/nT)∫D(z)dz; DLP=CTDI·L",
                Icone = "CTDI",
                Descricao = "CT Dose Index: dose média de um corte. DLP = Dose Length Product = CTDI × comprimento scan. Dose efetiva E = k·DLP (k~0.015 mSv/mGy·cm para abdômen). Princípio ALARA.",
            },
            // 20.2 PET/SPECT
            new Formula
            {
                Id = "4_pt01", Nome = "Modelo PET de Emissão", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "λᵢ = Σⱼ aᵢⱼ xⱼ + rᵢ + sᵢ (contagens esperadas na LOR i)",
                ExprTexto = "λᵢ = Σⱼaᵢⱼxⱼ+rᵢ+sᵢ",
                Icone = "PET",
                Descricao = "Modelo linear de emissão/detecção: x = atividade no voxel j, a = system matrix (geometria+atenuação+PSF), r = randoms, s = scatter. Estatística Poisson: Yi ~ Poisson(λi).",
            },
            new Formula
            {
                Id = "4_pt02", Nome = "MLEM (ML-EM)", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "xⱼ^{k+1} = (xⱼ^k / Σᵢaᵢⱼ) Σᵢ aᵢⱼ yᵢ/(Σₘ aᵢₘ xₘ^k)",
                ExprTexto = "xⱼ^{n+1} = xⱼⁿ/(Σaᵢⱼ)·Σ aᵢⱼyᵢ/(Axⁿ)ᵢ",
                Icone = "MLEM",
                Descricao = "Maximum Likelihood - Expectation Maximization: algoritmo iterativo para reconstrução PET. Preserva positividade, monotonicamente aumenta likelihood. Convergência lenta → ruidoso.",
                Criador = "Shepp / Vardi",
                AnoOrigin = "1982",
            },
            new Formula
            {
                Id = "4_pt03", Nome = "OSEM", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "MLEM com subsets: 1 iteração OSEM = S sub-iterações (S subsets)",
                ExprTexto = "OSEM: MLEM com S subsets → S× mais rápido",
                Icone = "OSEM",
                Descricao = "Ordered Subsets EM: divide projeções em S subsets e atualiza imagem a cada subset. ~S× aceleração vs MLEM. Padrão clínico (2-3 iterações × 21 subsets). Não converge exatamente.",
                Criador = "Hudson / Larkin",
                AnoOrigin = "1994",
            },
            new Formula
            {
                Id = "4_pt04", Nome = "SUV (Standardized Uptake Value)", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "SUV = C_tissue / (D_inj/W)",
                ExprTexto = "SUV = Ctissue/(Dinj/W)",
                Icone = "SUV",
                Descricao = "PET semi-quantitativo: concentração no tecido normalizada por dose injetada/peso. SUV=1 → captação média. Tumores: SUV>2.5 suspeito de malignidade. Usado em oncologia/estadiamento.",
            },
            // 20.3 Biomecânica / Imagem Funcional
            new Formula
            {
                Id = "4_bm01", Nome = "Hiperelasticidade (Geral)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "S = ∂W/∂E;  P = ∂W/∂F (S=2°PK, P=1°PK)",
                ExprTexto = "S = ∂W/∂E; P = ∂W/∂F (tensores de PK)",
                Icone = "W",
                Descricao = "Materiais hiperelásticos: tensão derivada de potencial de energia de deformação W. S = 2º Piola-Kirchhoff, P = 1º PK, F = gradiente de deformação. Tecidos biológicos, elastômeros.",
            },
            new Formula
            {
                Id = "4_bm02", Nome = "Neo-Hookean", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "W = (μ/2)(I₁-3) + (κ/2)(J-1)²",
                ExprTexto = "W = (μ/2)(I₁−3)+(κ/2)(J−1)²",
                Icone = "NH",
                Descricao = "Modelo hiperelástico mais simples: μ = módulo de cisalhamento, κ = bulk modulus, I₁ = primeiro invariante de C, J = det(F). Boa para deformações ~30%. Base para modelos mais complexos.",
            },
            new Formula
            {
                Id = "4_bm03", Nome = "Mooney-Rivlin", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "W = C₁₀(I₁-3) + C₀₁(I₂-3)",
                ExprTexto = "W = C₁₀(Ī₁−3)+C₀₁(Ī₂−3)",
                Icone = "MR",
                Descricao = "Extensão de Neo-Hookean com segundo invariante I₂. Dois parâmetros materiais. Melhor ajuste para borrachas e tecidos moles para deformações moderadas (~100%).",
                Criador = "Melvin Mooney / Ronald Rivlin",
            },
            new Formula
            {
                Id = "4_bm04", Nome = "Modelo de Ogden", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "W = Σₚ (μₚ/αₚ)(λ₁^αₚ + λ₂^αₚ + λ₃^αₚ - 3)",
                ExprTexto = "W = Σₚ(μₚ/αₚ)(λ₁^αₚ+λ₂^αₚ+λ₃^αₚ−3)",
                Icone = "Ogden",
                Descricao = "Modelo generalizado com N termos, cada um com (μₚ,αₚ). Ajusta bem dados experimentais de borracha até 700% deformação. Usual: N=3 (6 parâmetros).",
                Criador = "Raymond Ogden",
                AnoOrigin = "1972",
            },
            new Formula
            {
                Id = "4_bm05", Nome = "Viscoelasticidade (Maxwell)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "σ + (η/E)σ̇ = η·ε̇  (série: mola+amortecedor)",
                ExprTexto = "σ+(η/E)σ̇ = ηε̇ (Maxwell)",
                Icone = "Mx",
                Descricao = "Material viscoelástico: relaxação exponencial σ(t)=σ₀e^{-t/τ}, τ=η/E. Fluido sob carga constante (creep ilimitado). Série de Maxwell: espectro de relaxação.",
            },
            new Formula
            {
                Id = "4_bm06", Nome = "Viscoelasticidade (Kelvin-Voigt)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "σ = Eε + ηε̇  (paralelo: mola + amortecedor)",
                ExprTexto = "σ = Eε+ηε̇ (Kelvin-Voigt)",
                Icone = "KV",
                Descricao = "Sólido viscoelástico: creep limitado ε(t)=(σ₀/E)(1-e^{-t/τ}). Não relaxa tensão sob deformação constante. Modelo de tecidos biológicos sob carga cíclica.",
            },
            new Formula
            {
                Id = "4_bm07", Nome = "Elastografia (Onda de Cisalhamento)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "E ≈ 3ρv²_s  (módulo de Young ≈ 3ρ·(vel. cisalhamento)²)",
                ExprTexto = "E ≈ 3ρvs²",
                Icone = "SWE",
                Descricao = "Imagem de rigidez tecidual via ultrassom: mede velocidade de onda de cisalhamento vs. E~3ρvs² (tecido mole ~incompressível). Fibrose hepática: F0~5kPa, F4~25kPa. Não-invasivo.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 21. PSICOMETRIA E IRT
    // ─────────────────────────────────────────────────────
    private void AdicionarPsicometriaIRT()
    {
        _formulas.AddRange([
            // 21.1 Teoria da Resposta ao Item (IRT)
            new Formula
            {
                Id = "4_ir01", Nome = "Modelo Rasch (1PL)", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = e^{θ-b} / (1+e^{θ-b})",
                ExprTexto = "P(X=1|θ) = exp(θ−b)/(1+exp(θ−b))",
                Icone = "1PL",
                Descricao = "Modelo com um parâmetro: b = dificuldade do item. P=50% quando θ=b. Todos os itens igualmente discriminantes. Objetividade específica: comparação de pessoas independe dos itens.",
                Criador = "Georg Rasch",
                AnoOrigin = "1960",
            },
            new Formula
            {
                Id = "4_ir02", Nome = "Modelo 2PL", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = 1 / (1+e^{-a(θ-b)})",
                ExprTexto = "P = 1/(1+exp(−a(θ−b)))",
                Icone = "2PL",
                Descricao = "Dois parâmetros: a = discriminação (inclinação), b = dificuldade. a alto → curva mais íngreme → item discrimina melhor entre θ vizinhos. Lord & Novick (1968).",
            },
            new Formula
            {
                Id = "4_ir03", Nome = "Modelo 3PL", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = c + (1-c) / (1+e^{-a(θ-b)})",
                ExprTexto = "P = c+(1−c)/(1+exp(−a(θ−b)))",
                Icone = "3PL",
                Descricao = "Três parâmetros: + c = pseudo-adivinhação (assíntota inferior). Para itens de múltipla escolha com k opções, c~1/k. Usado em testes adaptativos (CAT) e vestibulares.",
                Criador = "Allan Birnbaum",
                AnoOrigin = "1968",
            },
            new Formula
            {
                Id = "4_ir04", Nome = "Modelo 4PL", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = c + (d-c) / (1+e^{-a(θ-b)})",
                ExprTexto = "P = c+(d−c)/(1+exp(−a(θ−b)))",
                Icone = "4PL",
                Descricao = "Quatro parâmetros: + d = assíntota superior (d<1: desatenção/erro em θ alto). Raramente usado na prática (sobreparametrizado). Modela comportamento de respondentes descuidados.",
            },
            new Formula
            {
                Id = "4_ir05", Nome = "Função de Informação do Item", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "I(θ) = [P'(θ)]² / [P(θ)(1-P(θ))]",
                ExprTexto = "I(θ) = [P'(θ)]²/[P(θ)(1−P(θ))]",
                Icone = "I(θ)",
                Descricao = "Informação de Fisher para um item: quanta informação sobre θ o item fornece. Máxima em θ≈b. Para 2PL: I_max=a²/4 em θ=b. Base para seleção de itens em CAT.",
            },
            new Formula
            {
                Id = "4_ir06", Nome = "Informação do Teste", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "I_test(θ) = Σᵢ Iᵢ(θ);  SE(θ) = 1/√I_test(θ)",
                ExprTexto = "Itest = ΣIᵢ(θ); SE=1/√Itest",
                Icone = "SE",
                Descricao = "Soma das informações dos itens (independência local). SE = erro padrão de medida: diminui com mais itens informativos naquele θ. Design de teste: maximizar I na faixa de θ desejada.",
            },
            new Formula
            {
                Id = "4_ir07", Nome = "Estimação MLE (θ̂)", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "θ̂ = argmax_θ Πᵢ Pᵢ(θ)^xᵢ (1-Pᵢ(θ))^{1-xᵢ}",
                ExprTexto = "θ̂ = argmax Π Pᵢ^xᵢ(1−Pᵢ)^{1−xᵢ}",
                Icone = "MLE",
                Descricao = "Máxima verossimilhança para estimar habilidade. Resolve ∂logL/∂θ=0 (Newton-Raphson). Não definido para scores perfeitos (0 ou n). Alternativa: EAP (Bayes com prior).",
            },
            new Formula
            {
                Id = "4_ir08", Nome = "DIF (Differential Item Functioning)", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "DIF: P(X=1|θ,grupo) ≠ P(X=1|θ)  (viés do item)",
                ExprTexto = "DIF: P(X=1|θ,g₁) ≠ P(X=1|θ,g₂)",
                Icone = "DIF",
                Descricao = "Item funciona diferentemente em grupos (sexo, etnia, etc.) controlando por θ. Uniforme (b difere) ou não-uniforme (a difere). Métodos: Mantel-Haenszel, logistic regression, LR IRT.",
            },
            // 21.2 SEM (Modelagem de Equações Estruturais)
            new Formula
            {
                Id = "4_sm01", Nome = "CFA (Análise Fatorial Confirmatória)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "x = Λξ + δ;  Σ = ΛΦΛ' + Θ",
                ExprTexto = "x=Λξ+δ; Σ=ΛΦΛ'+Θ",
                Icone = "CFA",
                Descricao = "Modelo de medida: x = indicadores observados, ξ = fatores latentes, Λ = cargas fatoriais, Φ = covariância entre fatores, Θ = variância dos erros. Confirma estrutura teórica.",
            },
            new Formula
            {
                Id = "4_sm02", Nome = "Modelo Estrutural (SEM)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "η = Bη + Γξ + ζ  (variáveis latentes endógenas)",
                ExprTexto = "η = Bη+Γξ+ζ",
                Icone = "SEM",
                Descricao = "Equações estruturais entre variáveis latentes: η = endógenas, ξ = exógenas, B = efeitos entre endógenas, Γ = efeitos de exógenas, ζ = distúrbios. Path analysis com latentes.",
            },
            new Formula
            {
                Id = "4_sm03", Nome = "Equações de Medida (Completo)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "x = Λₓξ + δ  (exógenas);  y = Λᵧη + ε  (endógenas)",
                ExprTexto = "x=Λxξ+δ; y=Λyη+ε",
                Icone = "meas",
                Descricao = "Modelo completo LISREL: dois modelos de medida (x→ξ, y→η) + modelo estrutural (ξ→η). Estimação: ML, WLS, DWLS. Identificação: regra 3-indicadores ou marker variable.",
            },
            new Formula
            {
                Id = "4_sm04", Nome = "Índices de Ajuste (SEM)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "CFI = 1-(χ²_m-df_m)/(χ²_0-df_0);  RMSEA = √((χ²/df-1)/N)",
                ExprTexto = "CFI, RMSEA, TLI, SRMR",
                Icone = "fit",
                Descricao = "CFI≥0.95 (comparativo), RMSEA≤0.06 (aproximação), SRMR≤0.08 (resíduos), TLI≥0.95. χ² = discrepância modelo vs dados. Hu & Bentler (1999): cutoffs combinados.",
            },
        ]);
    }
}
