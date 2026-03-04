using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 6 — PARTE I: MATEMÁTICA PURA AVANÇADA (Seções 1-5)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 1. ∞-CATEGORIAS, CATEGORIAS DERIVADAS E TEORIA DE TIPOS
    // ─────────────────────────────────────────────────────
    private void AdicionarInfCategorias()
    {
        _formulas.AddRange([
            // 1.1 Categorias Derivadas
            new Formula
            {
                Id = "6_der01", Nome = "Categoria Derivada D(A)", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "D(A) = K(A)[Qis⁻¹]",
                ExprTexto = "D(A) = categoria homotópica localizada nos quase-isomorfismos",
                Icone = "D",
                Descricao = "Categoria derivada D(A): localização da categoria homotópica K(A) nos quase-isomorfismos. Foundacional para álgebra homológica moderna.",
                Criador = "Jean-Louis Verdier",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "6_der02", Nome = "Triângulo Distinto", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "X → Y → Z → X[1]",
                ExprTexto = "X → Y → Z → X[1]; rotação de triângulos distintos",
                Icone = "△",
                Descricao = "Triângulo distinto: sequência X→Y→Z→X[1] na categoria derivada. Generaliza sequências exatas curtas; axiomas de Puppe.",
                Criador = "Jean-Louis Verdier",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "6_der03", Nome = "Functor Derivado Rf", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "RⁿF(A) = Hⁿ(F(I•));  0→A→I⁰→I¹→...",
                ExprTexto = "RⁿF(A) = n-ésima cohomologia de F aplicado à resolução injetiva",
                Icone = "R",
                Descricao = "Functor derivado à direita: aplica-se F a uma resolução injetiva e toma-se cohomologia. Base para Ext, sheaf cohomology.",
                Criador = "Henri Cartan / Samuel Eilenberg",
                AnoOrigin = "1956",
            },
            new Formula
            {
                Id = "6_der04", Nome = "Sequência Espectral de Grothendieck", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "E₂^{p,q} = RᵖF(RqG(A)) ⟹ Rⁿ(F∘G)(A)",
                ExprTexto = "E₂^{p,q} = RᵖF(RqG(A)) converge para Rⁿ(F∘G)(A)",
                Icone = "E₂",
                Descricao = "Sequência espectral de Grothendieck para composição de functores derivados. Ferramenta fundamental de cálculo homológico.",
                Criador = "Alexander Grothendieck",
                AnoOrigin = "1957",
            },
            new Formula
            {
                Id = "6_der05", Nome = "Complexo de Koszul", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "K(x₁,...,xₙ) = ⊗ᵢ (R →^{xᵢ} R)",
                ExprTexto = "K(x₁,...,xₙ) = produto tensorial dos complexos (R → R) por xᵢ",
                Icone = "K",
                Descricao = "Complexo de Koszul: resolução livre canônica associada a uma sequência regular. Calcula Tor e Ext para ideais.",
                Criador = "Jean-Louis Koszul",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_der06", Nome = "D^b(Coh X) e Reconstrução", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "D^b(Coh X) ≅ D^b(Coh Y) ⇒ X ≅ Y (se ωₓ amplo ou anti-amplo)",
                ExprTexto = "Teorema de Bondal-Orlov: D^b determina a variedade",
                Icone = "Db",
                Descricao = "Teorema de reconstrução de Bondal-Orlov: a categoria derivada limitada de feixes coerentes determina a variedade quando o canônico é amplo.",
                Criador = "Alexei Bondal / Dmitri Orlov",
                AnoOrigin = "2001",
            },
            new Formula
            {
                Id = "6_der07", Nome = "Equivalência de Morita Derivada", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "D(A-Mod) ≅ D(B-Mod) ↔ ∃ tilting complex T",
                ExprTexto = "Equivalência derivada ⟺ existência de complexo tilting",
                Icone = "≃",
                Descricao = "Teorema de Rickard: duas álgebras são derivadamente equivalentes se e somente se existe um complexo tilting. Generaliza Morita clássico.",
                Criador = "Jeremy Rickard",
                AnoOrigin = "1989",
            },
            new Formula
            {
                Id = "6_der08", Nome = "t-Estrutura", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Categorias Derivadas",
                Expressao = "D = (D≤⁰, D≥⁰);  coração A = D≤⁰ ∩ D≥⁰",
                ExprTexto = "t-estrutura: par (D≤⁰, D≥⁰) com coração abeliano A",
                Icone = "t",
                Descricao = "t-Estrutura em categoria triangulada: decomposição que recupera uma categoria abeliana (o coração). Essencial em D-módulos e perverse sheaves.",
                Criador = "Alexander Beilinson / Joseph Bernstein / Pierre Deligne",
                AnoOrigin = "1982",
            },

            // 1.2 ∞-Categorias Quasicategóricas
            new Formula
            {
                Id = "6_inf01", Nome = "Quasicategoria", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "∞-Categorias Quasicategóricas",
                Expressao = "Λⁿᵢ → X  tem extensão Δⁿ → X  (0 < i < n)",
                ExprTexto = "Inner horn filling: todo chifre interno tem preenchimento",
                Icone = "Λ",
                Descricao = "Quasicategoria (∞-categoria fraca): conjunto simplicial satisfazendo a condição de preenchimento de chifres internos. Modelo de Joyal-Lurie para (∞,1)-categorias.",
                Criador = "André Joyal",
                AnoOrigin = "2002",
            },
            new Formula
            {
                Id = "6_inf02", Nome = "Espaço de Mapeamento", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "∞-Categorias Quasicategóricas",
                Expressao = "Map_C(x,y) = {f : Δ¹→C | f(0)=x, f(1)=y}",
                ExprTexto = "Map(x,y) = espaço de Kan (tipo de homotopia)",
                Icone = "Map",
                Descricao = "Espaço de mapeamento numa quasicategoria: complexo de Kan dos morfismos de x a y. Generaliza Hom-sets para ∞-categorias.",
                Criador = "Jacob Lurie",
                AnoOrigin = "2009",
            },
            new Formula
            {
                Id = "6_inf03", Nome = "Limite e Colimite ∞-Categóricos", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "∞-Categorias Quasicategóricas",
                Expressao = "lim F = terminal em C_{/F};  colim F = inicial em C_{F/}",
                ExprTexto = "lim F = objeto terminal na fatia; colim = inicial",
                Icone = "lim",
                Descricao = "Limites e colimites homotópicos em ∞-categorias: definidos via objetos terminais/iniciais em categorias-fatia. Substituem limites derivados.",
                Criador = "Jacob Lurie",
                AnoOrigin = "2009",
            },
            new Formula
            {
                Id = "6_inf04", Nome = "Adjunção ∞-Categórica", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "∞-Categorias Quasicategóricas",
                Expressao = "Map_D(F(x),y) ≃ Map_C(x,G(y))",
                ExprTexto = "F ⊣ G: equivalência de espaços de mapeamento",
                Icone = "⊣",
                Descricao = "Adjunção em ∞-categorias: equivalência natural de espaços de mapeamento. Generaliza adjunções clássicas preservando informação homotópica.",
                Criador = "Jacob Lurie",
                AnoOrigin = "2009",
            },
            new Formula
            {
                Id = "6_inf05", Nome = "Localização de Dwyer-Kan", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "∞-Categorias Quasicategóricas",
                Expressao = "L_W(C) : C → C[W⁻¹] (localização simplicial)",
                ExprTexto = "Localização: inverte classe W de morfismos homotopicamente",
                Icone = "L",
                Descricao = "Localização de Dwyer-Kan: constrói a ∞-categoria onde morfismos em W se tornam equivalências. Precursor da teoria de ∞-categorias.",
                Criador = "William Dwyer / Daniel Kan",
                AnoOrigin = "1980",
            },
            new Formula
            {
                Id = "6_inf06", Nome = "∞-Topos", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "∞-Categorias Quasicategóricas",
                Expressao = "Sh_∞(C,τ) = localização exata à esquerda de Fun(C^op, Spaces)",
                ExprTexto = "∞-Topos = feixes de espaços sobre um sítio (C,τ)",
                Icone = "Sh",
                Descricao = "∞-Topos de Lurie: análogo homotópico de topos de Grothendieck. Feixes de espaços satisfazendo descent. Base da geometria derivada.",
                Criador = "Jacob Lurie",
                AnoOrigin = "2009",
            },
            new Formula
            {
                Id = "6_inf07", Nome = "Lema de Yoneda ∞-Categórico", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "∞-Categorias Quasicategóricas",
                Expressao = "Nat(y(c), F) ≃ F(c);  y: C ↪ Fun(C^op, Spaces)",
                ExprTexto = "Yoneda ∞: transformações naturais de y(c) em F ≃ F(c)",
                Icone = "y",
                Descricao = "Lema de Yoneda para ∞-categorias: o functor representável é plenamente fiel e Nat(y(c),F) ≃ F(c). Pilar da álgebra superior.",
                Criador = "Jacob Lurie",
                AnoOrigin = "2009",
            },

            // 1.3 Teoria Homotópica de Tipos (HoTT)
            new Formula
            {
                Id = "6_ht01", Nome = "Tipo Identidade", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Teoria Homotópica de Tipos",
                Expressao = "Id_A(a,b) : Type;  refl_a : Id_A(a,a)",
                ExprTexto = "Id_A(a,b) = tipo dos caminhos de a até b",
                Icone = "Id",
                Descricao = "Tipo identidade em HoTT: para cada a,b:A existe o tipo Id_A(a,b). O construtor refl_a é o caminho constante. Base da homotopia em tipos.",
                Criador = "Per Martin-Löf",
                AnoOrigin = "1975",
            },
            new Formula
            {
                Id = "6_ht02", Nome = "Universo Tipo U", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Teoria Homotópica de Tipos",
                Expressao = "A : U  ↔  El(A) é tipo;  U₀ : U₁ : U₂ : ...",
                ExprTexto = "Hierarquia de universos: U₀ : U₁ : U₂ : ...",
                Icone = "U",
                Descricao = "Universos em HoTT: U é um tipo cujos termos são tipos. Hierarquia cumulativa U₀ ⊂ U₁ ⊂ ... evita paradoxos tipo Russell.",
                Criador = "Per Martin-Löf",
                AnoOrigin = "1984",
            },
            new Formula
            {
                Id = "6_ht03", Nome = "Axioma de Univalência", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Teoria Homotópica de Tipos",
                Expressao = "(A =_U B) ≃ (A ≃ B)",
                ExprTexto = "Univalência: identidade de tipos ≃ equivalência de tipos",
                Icone = "UA",
                Descricao = "Axioma de univalência de Voevodsky: identificação no universo U é equivalente a equivalência de tipos. Fundamental em HoTT, conecta igualdade e isomorfismo.",
                Criador = "Vladimir Voevodsky",
                AnoOrigin = "2006",
            },
            new Formula
            {
                Id = "6_ht04", Nome = "Higher Inductive Type", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Teoria Homotópica de Tipos",
                Expressao = "S¹: base : S¹,  loop : base =_{S¹} base",
                ExprTexto = "S¹ gerado por ponto base e loop",
                Icone = "S¹",
                Descricao = "Tipo indutivo superior: define espaços por geradores de pontos e caminhos. S¹ tem um ponto base e um loop, realizando o círculo homotópico.",
                Criador = "Peter Lumsdaine / Guillaume Brunerie",
                AnoOrigin = "2012",
            },
            new Formula
            {
                Id = "6_ht05", Nome = "Fibração via Tipos Dependentes", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Teoria Homotópica de Tipos",
                Expressao = "B : A → U  corresponde a  p : (Σ_{a:A} B(a)) → A",
                ExprTexto = "Tipo dependente B(a) ↔ fibração com projeção Σ→A",
                Icone = "Σ",
                Descricao = "Correspondência Grothendieck em HoTT: famílias de tipos B:A→U correspondem a fibrações (Σ-tipos). Ponte entre lógica dependente e topologia.",
                Criador = "Vladimir Voevodsky",
                AnoOrigin = "2010",
            },
            new Formula
            {
                Id = "6_ht06", Nome = "π₁(S¹) = ℤ", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Teoria Homotópica de Tipos",
                Expressao = "π₁(S¹) ≃ ℤ;  Ω(S¹,base) ≃ ℤ",
                ExprTexto = "Grupo fundamental do círculo = ℤ (prova em HoTT)",
                Icone = "π₁",
                Descricao = "Cálculo de π₁(S¹)=ℤ puramente em HoTT sem pontos: usa recobrimento universal como tipo dependente sobre S¹. Marco da homotopia sintética.",
                Criador = "Michael Shulman",
                AnoOrigin = "2011",
            },
            new Formula
            {
                Id = "6_ht07", Nome = "Truncação n-Tipos", Categoria = "∞-Categorias e Teoria de Tipos", SubCategoria = "Teoria Homotópica de Tipos",
                Expressao = "‖A‖ₙ = n-truncação;  isProp(A) ↔ ∀x,y:A, x=y",
                ExprTexto = "‖A‖ₙ = truncação; isProp = todos os elementos são iguais",
                Icone = "‖‖",
                Descricao = "Truncação homotópica: ‖A‖ₙ força A a ter informação homotópica apenas até nível n. isProp (n=-1), isSet (n=0). Controle de níveis em HoTT.",
                Criador = "Vladimir Voevodsky",
                AnoOrigin = "2010",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 2. SISTEMAS INTEGRÁVEIS E TQFTs
    // ─────────────────────────────────────────────────────
    private void AdicionarSistemasIntegraveis()
    {
        _formulas.AddRange([
            // 2.1 Sistemas Integráveis
            new Formula
            {
                Id = "6_si01", Nome = "Equação KdV", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "uₜ + 6u·uₓ + uₓₓₓ = 0",
                ExprTexto = "∂u/∂t + 6u·∂u/∂x + ∂³u/∂x³ = 0",
                Icone = "KdV",
                Descricao = "Equação de Korteweg-de Vries: modelo de ondas solitárias em águas rasas. Protótipo de EDP integrável com sólitons.",
                Criador = "Diederik Korteweg / Gustav de Vries",
                AnoOrigin = "1895",
            },
            new Formula
            {
                Id = "6_si02", Nome = "Par de Lax", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "dL/dt = [P, L];  ψₓ = Lψ, ψₜ = Pψ",
                ExprTexto = "dL/dt = [P,L]; isospectralidade garante integrais de movimento",
                Icone = "Lax",
                Descricao = "Representação de Lax: L,P operadores com dL/dt=[P,L]. Espectro de L é conservado, gerando infinitas quantidades conservadas.",
                Criador = "Peter Lax",
                AnoOrigin = "1968",
            },
            new Formula
            {
                Id = "6_si03", Nome = "Inverse Scattering Transform", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "u(x,0) →^{scattering} S(k,0) →^{evolução} S(k,t) →^{inverso} u(x,t)",
                ExprTexto = "IST: scattering direto → evolução → scattering inverso",
                Icone = "IST",
                Descricao = "Transformada de scattering inverso: método para resolver a KdV e outras EDPs integráveis. Análogo não-linear da transformada de Fourier.",
                Criador = "Clifford Gardner / John Greene / Martin Kruskal / Robert Miura",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "6_si04", Nome = "Sóliton de N-corpos", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "u(x,t) = 2 ∂²/∂x² ln det(I + A(x,t))",
                ExprTexto = "u = 2·d²/dx²·ln·det(I+A) solução de N-sólitons",
                Icone = "N",
                Descricao = "Fórmula de N-sólitons via IST: solução exata da KdV como logaritmo do determinante. Sólitons interagem elasticamente.",
                Criador = "Vladimir Zakharov / Alexei Shabat",
                AnoOrigin = "1971",
            },
            new Formula
            {
                Id = "6_si05", Nome = "Sistema de Toda", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "d²qₙ/dt² = e^{qₙ₋₁-qₙ} - e^{qₙ-qₙ₊₁}",
                ExprTexto = "q̈ₙ = exp(qₙ₋₁−qₙ) − exp(qₙ−qₙ₊₁)",
                Icone = "Td",
                Descricao = "Cadeia de Toda: sistema integrável de partículas com interação exponencial. Importante em teoria de matrizes aleatórias e álgebras de Lie.",
                Criador = "Morikazu Toda",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "6_si06", Nome = "Equação Sine-Gordon", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "φₜₜ - φₓₓ + sin(φ) = 0",
                ExprTexto = "∂²φ/∂t² − ∂²φ/∂x² + sin(φ) = 0",
                Icone = "SG",
                Descricao = "Equação Sine-Gordon: EDP integrável com sólitons topológicos (kinks/antikinks). Aparece em teoria de campo e cristais.",
                Criador = "Edmond Bour",
                AnoOrigin = "1862",
            },
            new Formula
            {
                Id = "6_si07", Nome = "Equação NLS", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "iψₜ + ψₓₓ + 2|ψ|²ψ = 0",
                ExprTexto = "i·∂ψ/∂t + ∂²ψ/∂x² + 2|ψ|²ψ = 0",
                Icone = "NLS",
                Descricao = "Equação de Schrödinger não-linear: integrável via IST, modela fibras ópticas e ondas em águas profundas. Sólitons de envelope.",
                Criador = "Vladimir Zakharov / Alexei Shabat",
                AnoOrigin = "1972",
            },
            new Formula
            {
                Id = "6_si08", Nome = "Hierarquia KP", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "(uₜ + 6uuₓ + uₓₓₓ)ₓ + 3u_{yy} = 0",
                ExprTexto = "∂ₓ(uₜ+6u·uₓ+uₓₓₓ) + 3·u_{yy} = 0",
                Icone = "KP",
                Descricao = "Equação de Kadomtsev-Petviashvili: generalização 2D da KdV. Hierarquia KP conecta integrabilidade, Grassmanianas e moduli de curvas.",
                Criador = "Boris Kadomtsev / Vladimir Petviashvili",
                AnoOrigin = "1970",
            },
            new Formula
            {
                Id = "6_si09", Nome = "Equações de Yang-Baxter", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "R₁₂R₁₃R₂₃ = R₂₃R₁₃R₁₂",
                ExprTexto = "R₁₂·R₁₃·R₂₃ = R₂₃·R₁₃·R₁₂",
                Icone = "YB",
                Descricao = "Equação de Yang-Baxter: condição de consistência para integrabilidade. A R-matrix gera simetrias quânticas (grupos quânticos).",
                Criador = "Chen-Ning Yang / Rodney Baxter",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "6_si10", Nome = "Teorema de Liouville-Arnold", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "Sistemas Integráveis",
                Expressao = "n integrais em involução {Fᵢ,Fⱼ}=0 ⇒ toros invariantes Tⁿ",
                ExprTexto = "n integrais independentes em involução → fluxo em toros",
                Icone = "T",
                Descricao = "Teorema de Liouville-Arnold: sistema hamiltoniano com n integrais independentes em involução é integrável por quadraturas. Órbitas em toros.",
                Criador = "Joseph Liouville / Vladimir Arnold",
                AnoOrigin = "1855",
            },

            // 2.2 TQFTs
            new Formula
            {
                Id = "6_tf01", Nome = "TQFT de Atiyah", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "TQFTs",
                Expressao = "Z: nCob → Vect;  Z(Σ₁ ∪ Σ₂) = Z(Σ₁)⊗Z(Σ₂)",
                ExprTexto = "Z: functor monoidal de cobordismos para espaços vetoriais",
                Icone = "Z",
                Descricao = "TQFT (Atiyah): functor monoidal simétrico da categoria de cobordismos para Vect. Axiomas: multiplicatividade, functorialidade, involução.",
                Criador = "Michael Atiyah",
                AnoOrigin = "1988",
            },
            new Formula
            {
                Id = "6_tf02", Nome = "Invariante de Chern-Simons", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "TQFTs",
                Expressao = "CS(A) = k/(4π) ∫_M tr(A∧dA + ⅔A∧A∧A)",
                ExprTexto = "CS(A) = (k/4π)·∫ tr(A∧dA + 2/3·A∧A∧A)",
                Icone = "CS",
                Descricao = "Ação de Chern-Simons: funcional topológico 3D para conexão A. Gera a TQFT de Witten e invariantes de nós (polinômio de Jones).",
                Criador = "Shiing-Shen Chern / James Simons",
                AnoOrigin = "1974",
            },
            new Formula
            {
                Id = "6_tf03", Nome = "Invariante de Witten-Reshetikhin-Turaev", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "TQFTs",
                Expressao = "Z_WRT(M) = Σ_λ (dim_q λ)² · e^{2πi·c(λ)/(k+h∨)}",
                ExprTexto = "ZWRT(M) = soma sobre representações com dimensões quânticas",
                Icone = "WRT",
                Descricao = "Invariante WRT de 3-variedades: soma sobre representações do grupo quântico a uma raiz da unidade. Quantização rigorosa de Chern-Simons.",
                Criador = "Edward Witten / Nicolai Reshetikhin / Vladimir Turaev",
                AnoOrigin = "1991",
            },
            new Formula
            {
                Id = "6_tf04", Nome = "Polinômio de Jones via TQFT", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "TQFTs",
                Expressao = "V_L(q) = ⟨L⟩_{CS,k};  q = e^{2πi/(k+2)}",
                ExprTexto = "V_L(q) = valor esperado de Wilson loop em Chern-Simons",
                Icone = "V",
                Descricao = "Polinômio de Jones: invariante de nós obtido como valor esperado de Wilson loop na TQFT de Chern-Simons. q = raiz da unidade.",
                Criador = "Edward Witten",
                AnoOrigin = "1989",
            },
            new Formula
            {
                Id = "6_tf05", Nome = "Modelo de Turaev-Viro", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "TQFTs",
                Expressao = "Z_TV(M) = Σ_{colorações} ∏_tet |6j-symbol|²",
                ExprTexto = "ZTV = soma sobre triangulações com símbolos 6j",
                Icone = "TV",
                Descricao = "Invariante de Turaev-Viro: TQFT 3D definida por state sum sobre triangulações. Usa símbolos 6j quânticos de categorias de fusão.",
                Criador = "Vladimir Turaev / Oleg Viro",
                AnoOrigin = "1992",
            },
            new Formula
            {
                Id = "6_tf06", Nome = "2d TQFT e Álgebras de Frobenius", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "TQFTs",
                Expressao = "2-TQFT ↔ álgebra de Frobenius comutativa (A, μ, η, Δ, ε)",
                ExprTexto = "TQFTs 2D ↔ álgebras de Frobenius comutativas",
                Icone = "Fr",
                Descricao = "Classificação de 2d TQFTs: equivalência com álgebras de Frobenius comutativas. Multiplicação = calça, comultiplicação = calça invertida.",
                Criador = "Lowell Abrams",
                AnoOrigin = "1996",
            },
            new Formula
            {
                Id = "6_tf07", Nome = "Cobordismo Estendido (Hipótese de Baez-Dolan)", Categoria = "Sistemas Integráveis e TQFTs", SubCategoria = "TQFTs",
                Expressao = "Z: Bord_n^{fr} → C  determinado por Z(pt) (objeto plenamente dualizável)",
                ExprTexto = "TQFT estendida determinada por Z(ponto) plenamente dualizável",
                Icone = "Bd",
                Descricao = "Hipótese do cobordismo (Baez-Dolan, provada por Lurie): TQFT estendida n-dimensional plenamente determinada pelo valor no ponto, que é objeto plenamente dualizável.",
                Criador = "John Baez / James Dolan",
                AnoOrigin = "1995",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 3. GEOMETRIA TROPICAL, TEORIA DOS NÓS E COMBINATÓRIA ALGÉBRICA
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaTropicalNos()
    {
        _formulas.AddRange([
            // 3.1 Geometria Tropical
            new Formula
            {
                Id = "6_tr01", Nome = "Semianél Tropical", Categoria = "Geometria Tropical e Nós", SubCategoria = "Geometria Tropical",
                Expressao = "(ℝ∪{-∞}, ⊕=max, ⊙=+)",
                ExprTexto = "(ℝ∪{−∞}, max, +): soma=max, produto=soma usual",
                Icone = "⊕",
                Descricao = "Semianél tropical: números reais com soma=max e produto=soma usual. Base da geometria tropical que \"lineariza\" problemas algébricos.",
                Criador = "Imre Simon",
                AnoOrigin = "1988",
            },
            new Formula
            {
                Id = "6_tr02", Nome = "Curva Tropical", Categoria = "Geometria Tropical e Nós", SubCategoria = "Geometria Tropical",
                Expressao = "Trop(V(f)) = {x ∈ ℝⁿ : max é atingido ≥ 2 vezes em f^{trop}}",
                ExprTexto = "Curva tropical = locus onde máximo do polinômio tropical é não-único",
                Icone = "T",
                Descricao = "Variedade tropical: conjunto dos pontos onde o máximo no polinômio tropical é atingido por pelo menos dois monômios. Grafo planar ponderado.",
                Criador = "Grigory Mikhalkin",
                AnoOrigin = "2004",
            },
            new Formula
            {
                Id = "6_tr03", Nome = "Teorema de Correspondência de Mikhalkin", Categoria = "Geometria Tropical e Nós", SubCategoria = "Geometria Tropical",
                Expressao = "N_d = Σ_{C trop} mult(C);  mult(C) = ∏_{v} mult(v)",
                ExprTexto = "Nₔ(gênero g) = soma de multiplicidades de curvas tropicais",
                Icone = "Nd",
                Descricao = "Correspondência de Mikhalkin: conta curvas algébricas via curvas tropicais com multiplicidades. Revolucionou enumeração de curvas.",
                Criador = "Grigory Mikhalkin",
                AnoOrigin = "2005",
            },
            new Formula
            {
                Id = "6_tr04", Nome = "Politopo de Newton Tropical", Categoria = "Geometria Tropical e Nós", SubCategoria = "Geometria Tropical",
                Expressao = "Subdiv(Newt(f)) dual à curva Trop(f)",
                ExprTexto = "Subdivisão dual do politopo de Newton ↔ curva tropical",
                Icone = "Δ",
                Descricao = "Dualidade de Newton: a curva tropical de f é dual à subdivisão regular do politopo de Newton. Conecta combinatória convexa e geometria tropical.",
                Criador = "Grigory Mikhalkin",
                AnoOrigin = "2004",
            },
            new Formula
            {
                Id = "6_tr05", Nome = "Grassmanniana Tropical", Categoria = "Geometria Tropical e Nós", SubCategoria = "Geometria Tropical",
                Expressao = "TrGr(k,n): matróide valuada M com relações de Plücker tropicais",
                ExprTexto = "TrGr(k,n) = espaço de matróides valuadas satisfazendo Plücker tropical",
                Icone = "Gr",
                Descricao = "Grassmanniana tropical: parametriza subespaços tropicais via matróides valuadas. Conecta combinatória de matróides e geometria algébrica tropical.",
                Criador = "David Speyer / Bernd Sturmfels",
                AnoOrigin = "2004",
            },
            new Formula
            {
                Id = "6_tr06", Nome = "Fórmula de Gênero Tropical", Categoria = "Geometria Tropical e Nós", SubCategoria = "Geometria Tropical",
                Expressao = "g(Γ) = b₁(Γ) = |E| - |V| + 1",
                ExprTexto = "g(Γ) = primeiro número de Betti = |arestas|−|vértices|+1",
                Icone = "g",
                Descricao = "Gênero de curva tropical: primeiro número de Betti do grafo Γ. Análogo tropical do gênero de curvas algébricas clássicas.",
                Criador = "Grigory Mikhalkin",
                AnoOrigin = "2006",
            },
            new Formula
            {
                Id = "6_tr07", Nome = "Variedade Tropical de Bergman", Categoria = "Geometria Tropical e Nós", SubCategoria = "Geometria Tropical",
                Expressao = "B(M) = {w ∈ ℝⁿ : M_w é matróide de laço}",
                ExprTexto = "B(M) = conjunto de vetores peso para os quais a matróide induzida é loop-free",
                Icone = "B",
                Descricao = "Fan de Bergman: tropicalização do complemento de arranjo de hiperplanos. Estrutura combinatória rica ligada a matróides.",
                Criador = "George Bergman",
                AnoOrigin = "1971",
            },

            // 3.2 Teoria dos Nós
            new Formula
            {
                Id = "6_kn01", Nome = "Polinômio de Alexander", Categoria = "Geometria Tropical e Nós", SubCategoria = "Teoria dos Nós",
                Expressao = "Δ_K(t) = det(tS - S^T);  S = matriz de Seifert",
                ExprTexto = "Δ_K(t) = det(t·Seifert − Seifert^T)",
                Icone = "Δ",
                Descricao = "Polinômio de Alexander: primeiro invariante polinomial de nós, calculado via matriz de Seifert. Detecta gênero e fatoração de nós.",
                Criador = "James Alexander",
                AnoOrigin = "1928",
            },
            new Formula
            {
                Id = "6_kn02", Nome = "Polinômio de Jones", Categoria = "Geometria Tropical e Nós", SubCategoria = "Teoria dos Nós",
                Expressao = "t⁻¹V(L₊) - tV(L₋) = (t^{1/2} - t^{-1/2})V(L₀)",
                ExprTexto = "Relação skein: t⁻¹V(L₊) − tV(L₋) = (√t−1/√t)V(L₀)",
                Icone = "V",
                Descricao = "Polinômio de Jones: invariante de nós orientados via relação skein. Distingue nós que Alexander não diferencia. Conecta-se a física (CS).",
                Criador = "Vaughan Jones",
                AnoOrigin = "1984",
            },
            new Formula
            {
                Id = "6_kn03", Nome = "Invariante HOMFLY-PT", Categoria = "Geometria Tropical e Nós", SubCategoria = "Teoria dos Nós",
                Expressao = "αP(L₊) + α⁻¹P(L₋) = zP(L₀)",
                ExprTexto = "α·P(L₊)+α⁻¹·P(L₋)=z·P(L₀); generaliza Jones e Alexander",
                Icone = "P",
                Descricao = "Invariante HOMFLY-PT: polinômio de duas variáveis que generaliza Jones e Alexander. Relação skein com parâmetros α e z.",
                Criador = "Freyd / Yetter / Hoste / Lickorish / Millett / Ocneanu / Przytycki / Traczyk",
                AnoOrigin = "1985",
            },
            new Formula
            {
                Id = "6_kn04", Nome = "Número de Cruzamento e Writhe", Categoria = "Geometria Tropical e Nós", SubCategoria = "Teoria dos Nós",
                Expressao = "w(D) = Σᵢ εᵢ;  c(K) = min_D |crossings(D)|",
                ExprTexto = "writhe = soma dos sinais de cruzamento; c(K) = mínimo de cruzamentos",
                Icone = "w",
                Descricao = "Writhe: soma algébrica dos sinais de cruzamento. Número de cruzamento c(K): mínimo de cruzamentos sobre todos os diagramas do nó.",
                Criador = "Kurt Reidemeister",
                AnoOrigin = "1927",
            },
            new Formula
            {
                Id = "6_kn05", Nome = "Bracket de Kauffman", Categoria = "Geometria Tropical e Nós", SubCategoria = "Teoria dos Nós",
                Expressao = "⟨K⟩ = A⟨K₀⟩ + A⁻¹⟨K∞⟩;  ⟨○⟩ = 1",
                ExprTexto = "⟨K⟩ = A·⟨resolução 0⟩ + A⁻¹·⟨resolução ∞⟩",
                Icone = "⟨⟩",
                Descricao = "Bracket de Kauffman: invariante de links não-orientados via state sum. Normalizado pelo writhe, recupera o polinômio de Jones.",
                Criador = "Louis Kauffman",
                AnoOrigin = "1987",
            },
            new Formula
            {
                Id = "6_kn06", Nome = "Grupo do Nó", Categoria = "Geometria Tropical e Nós", SubCategoria = "Teoria dos Nós",
                Expressao = "π₁(S³ \\ K) = ⟨g₁,...,gₙ | r₁,...,rₙ₋₁⟩ (Wirtinger)",
                ExprTexto = "π₁(S³∖K) = apresentação de Wirtinger do grupo do nó",
                Icone = "π₁",
                Descricao = "Grupo do nó: grupo fundamental do complemento do nó em S³. Apresentação de Wirtinger a partir do diagrama. Invariante completo mas difícil de comparar.",
                Criador = "Wilhelm Wirtinger",
                AnoOrigin = "1905",
            },
            new Formula
            {
                Id = "6_kn07", Nome = "Homologia de Khovanov", Categoria = "Geometria Tropical e Nós", SubCategoria = "Teoria dos Nós",
                Expressao = "Kh(K) = ⊕_{i,j} Kh^{i,j}(K);  χ_q(Kh) = V_K(q)",
                ExprTexto = "Kh(K) = homologia bi-graduada; Euler graded = Jones",
                Icone = "Kh",
                Descricao = "Homologia de Khovanov: categorificação do polinômio de Jones. Homologia bi-graduada cujo Euler graduado é V_K. Detecta o unknot.",
                Criador = "Mikhail Khovanov",
                AnoOrigin = "1999",
            },

            // 3.3 Combinatória Algébrica
            new Formula
            {
                Id = "6_ca01", Nome = "Matróide", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "M = (E, I);  se A∈I e B∈I, |A|<|B| → ∃b∈B\\A: A∪{b}∈I",
                ExprTexto = "Matróide: (E,I) com propriedade de troca de bases",
                Icone = "M",
                Descricao = "Matróide: abstração de independência linear. Axioma de troca garante que todas as bases têm o mesmo tamanho. Unifica grafos e vetores.",
                Criador = "Hassler Whitney",
                AnoOrigin = "1935",
            },
            new Formula
            {
                Id = "6_ca02", Nome = "Polinômio Cromático", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "P(G,k) = Σ_{A⊆E} (-1)^{|A|} k^{c(A)}",
                ExprTexto = "P(G,k) = soma sobre subgrafos com alternância de sinais",
                Icone = "P",
                Descricao = "Polinômio cromático: conta colorações próprias de G com k cores. Caso especial do polinômio de Tutte. Conjectura de Rota verificada por Huh.",
                Criador = "George David Birkhoff",
                AnoOrigin = "1912",
            },
            new Formula
            {
                Id = "6_ca03", Nome = "Polinômio de Tutte", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "T(G;x,y) = Σ_{A⊆E} (x-1)^{r(E)-r(A)} (y-1)^{|A|-r(A)}",
                ExprTexto = "T(G;x,y) = soma sobre subconjuntos com rank e nulidade",
                Icone = "T",
                Descricao = "Polinômio de Tutte: invariante universal de grafos e matróides. Especializa para cromático, Jones, confiabilidade e função de partição de Potts.",
                Criador = "William Thomas Tutte",
                AnoOrigin = "1954",
            },
            new Formula
            {
                Id = "6_ca04", Nome = "Funções de Schur", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "s_λ(x) = det(x_i^{λ_j+n-j}) / det(x_i^{n-j})",
                ExprTexto = "s_λ = det(x_i^{λ_j+n−j})/Vandermonde",
                Icone = "sλ",
                Descricao = "Funções de Schur: base do anel de funções simétricas indexadas por partições. Caracteres de GL(n). Fórmula de Weyl como quociente de determinantes.",
                Criador = "Issai Schur",
                AnoOrigin = "1901",
            },
            new Formula
            {
                Id = "6_ca05", Nome = "Regra de Littlewood-Richardson", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "s_μ · s_ν = Σ_λ c^λ_{μν} s_λ;  c^λ_{μν} via tableaux",
                ExprTexto = "sμ·sν = Σ c^λ_{μν}·sλ; coeficientes LR contados por tableaux",
                Icone = "LR",
                Descricao = "Regra de Littlewood-Richardson: produto de funções de Schur. Coeficientes c^λ_{μν} contados por tableaux de Young semi-standard com condição de reticulado.",
                Criador = "Dudley Littlewood / Archibald Richardson",
                AnoOrigin = "1934",
            },
            new Formula
            {
                Id = "6_ca06", Nome = "Álgebra de Hopf Combinatória", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "Δ(s_λ) = Σ_{μ⊆λ} s_μ ⊗ s_{λ/μ}",
                ExprTexto = "Comultiplicação: Δ(sλ) = Σ sμ⊗s_{λ/μ} sobre sub-partições",
                Icone = "Δ",
                Descricao = "Álgebra de Hopf das funções simétricas: comultiplicação via funções skew-Schur. Estrutura de Hopf permeia toda a combinatória algébrica.",
                Criador = "Ira Gessel",
                AnoOrigin = "1984",
            },
            new Formula
            {
                Id = "6_ca07", Nome = "Fórmula de Hook-Length", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "f^λ = n! / ∏_{u∈λ} h(u)",
                ExprTexto = "f^λ = n!/∏ h(u); h(u) = comprimento do gancho da célula u",
                Icone = "f",
                Descricao = "Fórmula de hook-length: conta o número de tableaux de Young standard de forma λ. h(u) = hook length da célula u no diagrama.",
                Criador = "James Frame / Gilbert Robinson / Robert Thrall",
                AnoOrigin = "1954",
            },
            new Formula
            {
                Id = "6_ca08", Nome = "Polinômio de Kazhdan-Lusztig", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "P_{x,w}(q) definido por C'_w = Σ_{x≤w} P_{x,w}(q) T_x",
                ExprTexto = "P_{x,w}(q): base canônica de Kazhdan-Lusztig da álgebra de Hecke",
                Icone = "KL",
                Descricao = "Polinômios de Kazhdan-Lusztig: definidos pela base canônica da álgebra de Hecke. Calculam multiplicidades em representações e cohomologia de intersection.",
                Criador = "David Kazhdan / George Lusztig",
                AnoOrigin = "1979",
            },
            new Formula
            {
                Id = "6_ca09", Nome = "Conjectura de Rota (Log-Concavidade)", Categoria = "Geometria Tropical e Nós", SubCategoria = "Combinatória Algébrica",
                Expressao = "a_k² ≥ a_{k-1}·a_{k+1};  a_k = |{flats de rank k}|",
                ExprTexto = "Sequência de Whitney é log-côncava: aₖ² ≥ aₖ₋₁·aₖ₊₁",
                Icone = "LC",
                Descricao = "Conjectura de Rota (provada por Adiprasito-Huh-Katz 2018): coeficientes do polinômio característico de matróides formam sequência log-côncava.",
                Criador = "Gian-Carlo Rota",
                AnoOrigin = "1971",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 4. ESPAÇOS DE SOBOLEV, DISTRIBUIÇÕES E ANÁLISE NÃO-STANDARD
    // ─────────────────────────────────────────────────────
    private void AdicionarSobolevDistribuicoes()
    {
        _formulas.AddRange([
            // 4.1 Espaços de Sobolev
            new Formula
            {
                Id = "6_so01", Nome = "Espaço de Sobolev W^{k,p}", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "W^{k,p}(Ω) = {u ∈ Lᵖ : D^α u ∈ Lᵖ, |α|≤k}",
                ExprTexto = "W^{k,p} = funções Lp com derivadas fracas até ordem k em Lp",
                Icone = "W",
                Descricao = "Espaço de Sobolev: funções em Lᵖ com todas as derivadas fracas até ordem k também em Lᵖ. Espaço natural para EDPs com soluções fracas.",
                Criador = "Sergei Sobolev",
                AnoOrigin = "1938",
            },
            new Formula
            {
                Id = "6_so02", Nome = "Imersão de Sobolev", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "W^{k,p}(ℝⁿ) ↪ Lq(ℝⁿ),  1/q = 1/p - k/n  (kp < n)",
                ExprTexto = "W^{k,p} ⊂ Lq com 1/q=1/p−k/n quando kp<n",
                Icone = "↪",
                Descricao = "Teorema de imersão de Sobolev: W^{k,p} se imerge continuamente em Lq com expoente determinado por p,k,n. Fundamental para regularidade de EDPs.",
                Criador = "Sergei Sobolev",
                AnoOrigin = "1938",
            },
            new Formula
            {
                Id = "6_so03", Nome = "Desigualdade de Poincaré", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "‖u - ū‖_Lp ≤ C·‖∇u‖_Lp",
                ExprTexto = "‖u−média‖_Lp ≤ C·‖∇u‖_Lp",
                Icone = "P",
                Descricao = "Desigualdade de Poincaré: controla a oscilação de u por seu gradiente. C depende do domínio. Essencial para coercividade em problemas elípticos.",
                Criador = "Henri Poincaré",
                AnoOrigin = "1890",
            },
            new Formula
            {
                Id = "6_so04", Nome = "Teorema de Traços", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "γ: W^{1,p}(Ω) → W^{1-1/p,p}(∂Ω)  é contínuo e sobrejetivo",
                ExprTexto = "Operador traço γ: W^{1,p}(Ω) → W^{1−1/p,p}(∂Ω)",
                Icone = "γ",
                Descricao = "Teorema de traços: restrição ao bordo ∂Ω é operador contínuo e sobrejetivo. Permite formular condições de contorno para soluções fracas.",
                Criador = "Emilio Gagliardo",
                AnoOrigin = "1957",
            },
            new Formula
            {
                Id = "6_so05", Nome = "Imersão Compacta de Rellich-Kondrachov", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "W^{1,p}(Ω) ↪↪ Lq(Ω),  q < np/(n-p)  (Ω limitado)",
                ExprTexto = "W^{1,p} compactamente imerso em Lq para q < p*",
                Icone = "↪↪",
                Descricao = "Teorema de Rellich-Kondrachov: imersão compacta de W^{1,p} em Lq (q < expoente crítico). Garante convergência de subsequências — chave para existência de soluções.",
                Criador = "Franz Rellich / Vladimir Kondrachov",
                AnoOrigin = "1930",
            },
            new Formula
            {
                Id = "6_so06", Nome = "Desigualdade de Gagliardo-Nirenberg", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "‖D^j u‖_Lp ≤ C ‖D^m u‖_Lr^θ ‖u‖_Lq^{1-θ}",
                ExprTexto = "‖Dʲu‖_Lp ≤ C·‖Dᵐu‖_Lr^θ·‖u‖_Lq^{1−θ} (interpolação)",
                Icone = "GN",
                Descricao = "Desigualdade de Gagliardo-Nirenberg: interpolação entre derivadas de diferentes ordens. Conecta normas Sobolev e Lp com expoente θ determinado por escala.",
                Criador = "Emilio Gagliardo / Louis Nirenberg",
                AnoOrigin = "1959",
            },
            new Formula
            {
                Id = "6_so07", Nome = "Espaço H^s (Sobolev Fracionário)", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "H^s(ℝⁿ) = {u : ∫(1+|ξ|²)^s |û(ξ)|² dξ < ∞}",
                ExprTexto = "H^s = {u: (1+|ξ|²)^{s/2}·û ∈ L²} (s real)",
                Icone = "Hs",
                Descricao = "Espaço de Sobolev fracionário H^s: definido via transformada de Fourier com peso (1+|ξ|²)^s. Permite derivadas de ordem não-inteira s∈ℝ.",
                Criador = "Lars Hörmander",
                AnoOrigin = "1963",
            },
            new Formula
            {
                Id = "6_so08", Nome = "Teorema de Lax-Milgram", Categoria = "Sobolev e Distribuições", SubCategoria = "Espaços de Sobolev",
                Expressao = "a(u,v) coerciva e contínua em H ⇒ ∃! u : a(u,v)=F(v) ∀v",
                ExprTexto = "Forma bilinear coerciva garante existência e unicidade da solução fraca",
                Icone = "LM",
                Descricao = "Teorema de Lax-Milgram: forma bilinear contínua e coerciva em espaço de Hilbert garante existência e unicidade de solução fraca. Motor de EDPs elípticas.",
                Criador = "Peter Lax / Arthur Milgram",
                AnoOrigin = "1954",
            },

            // 4.2 Distribuições de Schwartz
            new Formula
            {
                Id = "6_ds01", Nome = "Distribuição (Funcional Generalizada)", Categoria = "Sobolev e Distribuições", SubCategoria = "Distribuições de Schwartz",
                Expressao = "T ∈ D'(Ω) : φ ↦ ⟨T,φ⟩;  D(Ω) = C_c^∞(Ω)",
                ExprTexto = "T ∈ D': funcional linear contínuo sobre funções-teste C_c^∞",
                Icone = "D'",
                Descricao = "Distribuição: funcional linear contínuo sobre o espaço de funções-teste C_c^∞. Generaliza funções: delta de Dirac, valor principal, etc.",
                Criador = "Laurent Schwartz",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_ds02", Nome = "Delta de Dirac", Categoria = "Sobolev e Distribuições", SubCategoria = "Distribuições de Schwartz",
                Expressao = "⟨δ_a, φ⟩ = φ(a);  δ(x) = 0 (x≠0), ∫δ dx = 1",
                ExprTexto = "⟨δₐ,φ⟩ = φ(a); avaliação pontual como distribuição",
                Icone = "δ",
                Descricao = "Delta de Dirac: distribuição de avaliação pontual. Não é função mas funcional: ⟨δ_a,φ⟩=φ(a). Indispensável em física e engenharia.",
                Criador = "Paul Dirac",
                AnoOrigin = "1930",
            },
            new Formula
            {
                Id = "6_ds03", Nome = "Derivada Distribucional", Categoria = "Sobolev e Distribuições", SubCategoria = "Distribuições de Schwartz",
                Expressao = "⟨D^α T, φ⟩ = (-1)^{|α|} ⟨T, D^α φ⟩",
                ExprTexto = "⟨DᵅT,φ⟩ = (−1)^|α|·⟨T,Dᵅφ⟩ (integração por partes generalizada)",
                Icone = "D",
                Descricao = "Derivada distribucional: definida por dualidade via integração por partes. Toda distribuição é infinitamente diferenciável. Derivada de Heaviside = delta.",
                Criador = "Laurent Schwartz",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_ds04", Nome = "Espaço de Schwartz S", Categoria = "Sobolev e Distribuições", SubCategoria = "Distribuições de Schwartz",
                Expressao = "S(ℝⁿ) = {φ ∈ C^∞ : sup |x^α D^β φ| < ∞, ∀α,β}",
                ExprTexto = "S = funções C^∞ de decaimento rápido com todas as derivadas",
                Icone = "S",
                Descricao = "Espaço de Schwartz: funções C^∞ que decaem mais rápido que qualquer polinômio. Domínio natural da transformada de Fourier. S' = distribuições temperadas.",
                Criador = "Laurent Schwartz",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_ds05", Nome = "Transformada de Fourier em S'", Categoria = "Sobolev e Distribuições", SubCategoria = "Distribuições de Schwartz",
                Expressao = "⟨F[T], φ⟩ = ⟨T, F[φ]⟩;  F[δ] = 1",
                ExprTexto = "⟨FT,φ⟩ = ⟨T,Fφ⟩; Fourier de δ = constante 1",
                Icone = "F",
                Descricao = "Transformada de Fourier em distribuições temperadas: definida por dualidade. F é isomorfismo de S' para S'. F[δ]=1 e F[1]=δ.",
                Criador = "Laurent Schwartz",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_ds06", Nome = "Solução Fundamental (Função de Green)", Categoria = "Sobolev e Distribuições", SubCategoria = "Distribuições de Schwartz",
                Expressao = "P(D)E = δ;  u = E * f  resolve  P(D)u = f",
                ExprTexto = "P(D)E = δ → u = E∗f resolve P(D)u=f por convolução",
                Icone = "E",
                Descricao = "Solução fundamental: distribuição E com P(D)E=δ. Solução de P(D)u=f obtida por convolução u=E*f. Teorema de Malgrange-Ehrenpreis garante existência.",
                Criador = "Laurent Schwartz",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_ds07", Nome = "Teorema do Núcleo de Schwartz", Categoria = "Sobolev e Distribuições", SubCategoria = "Distribuições de Schwartz",
                Expressao = "T: S(ℝⁿ)→S'(ℝᵐ) contínua ↔ ∃K ∈ S'(ℝⁿ⁺ᵐ): T(φ)(ψ)=K(φ⊗ψ)",
                ExprTexto = "Operador contínuo S→S' ↔ distribuição kernel K em S'(ℝⁿ⁺ᵐ)",
                Icone = "K",
                Descricao = "Teorema do núcleo de Schwartz: todo operador linear contínuo de S para S' é dado por um kernel distribucional. Generaliza representação integral.",
                Criador = "Laurent Schwartz",
                AnoOrigin = "1952",
            },

            // 4.3 Análise Não-Standard
            new Formula
            {
                Id = "6_na01", Nome = "Ultrapotência *ℝ", Categoria = "Sobolev e Distribuições", SubCategoria = "Análise Não-Standard",
                Expressao = "*ℝ = ℝ^ℕ / U;  U ultrafiltro livre sobre ℕ",
                ExprTexto = "*ℝ = ultrapotência de ℝ por ultrafiltro não-principal",
                Icone = "*ℝ",
                Descricao = "Hiperreais: corpo ordenado *ℝ contendo infinitesimais e infinitos. Construção via ultrapotência de ℝ modulo ultrafiltro livre sobre ℕ.",
                Criador = "Abraham Robinson",
                AnoOrigin = "1966",
            },
            new Formula
            {
                Id = "6_na02", Nome = "Princípio de Transferência", Categoria = "Sobolev e Distribuições", SubCategoria = "Análise Não-Standard",
                Expressao = "φ(r₁,...,rₙ) verdadeira em ℝ  ↔  *φ(*r₁,...,*rₙ) verdadeira em *ℝ",
                ExprTexto = "Sentença de 1ª ordem verdadeira em ℝ ↔ verdadeira em *ℝ",
                Icone = "⟺",
                Descricao = "Princípio de transferência: toda sentença de primeira ordem verdadeira em ℝ é verdadeira em *ℝ e vice-versa. Equivalência elementar ℝ ≡ *ℝ.",
                Criador = "Abraham Robinson",
                AnoOrigin = "1966",
            },
            new Formula
            {
                Id = "6_na03", Nome = "Infinitesimal e Mônada", Categoria = "Sobolev e Distribuições", SubCategoria = "Análise Não-Standard",
                Expressao = "ε infinitesimal: |ε| < 1/n ∀n∈ℕ;  mon(a) = {x: x≈a}",
                ExprTexto = "ε infinitesimal ↔ |ε|<1/n ∀n∈ℕ; mônada = vizinhança infinitesimal",
                Icone = "ε",
                Descricao = "Infinitesimais: elementos positivos de *ℝ menores que todo racional positivo. Mônada de a: conjunto dos x infinitamente próximos de a. Formaliza cálculo de Leibniz.",
                Criador = "Abraham Robinson",
                AnoOrigin = "1966",
            },
            new Formula
            {
                Id = "6_na04", Nome = "Parte Standard", Categoria = "Sobolev e Distribuições", SubCategoria = "Análise Não-Standard",
                Expressao = "st: *ℝ_fin → ℝ;  st(x) = único r∈ℝ com x ≈ r",
                ExprTexto = "st(x) = parte standard: número real mais próximo de x finito",
                Icone = "st",
                Descricao = "Parte standard: mapa de *ℝ finito para ℝ. st(x) é o único real infinitamente próximo de x. Conecta cálculo não-standard ao clássico.",
                Criador = "Abraham Robinson",
                AnoOrigin = "1966",
            },
            new Formula
            {
                Id = "6_na05", Nome = "Derivada via Infinitesimais", Categoria = "Sobolev e Distribuições", SubCategoria = "Análise Não-Standard",
                Expressao = "f'(a) = st((f(a+ε)-f(a))/ε),  ε≈0, ε≠0",
                ExprTexto = "f'(a) = st[(f(a+ε)−f(a))/ε] para ε infinitesimal",
                Icone = "d",
                Descricao = "Derivada não-standard: quociente (f(a+ε)-f(a))/ε para infinitesimal ε, seguido de parte standard. Realiza a intuição original de Leibniz.",
                Criador = "Abraham Robinson",
                AnoOrigin = "1966",
            },
            new Formula
            {
                Id = "6_na06", Nome = "Integral via Soma Hiperfinita", Categoria = "Sobolev e Distribuições", SubCategoria = "Análise Não-Standard",
                Expressao = "∫_a^b f dx = st(Σ_{i=0}^{N-1} f(a+iΔx)·Δx),  N∈*ℕ\\ℕ, Δx=(b-a)/N",
                ExprTexto = "∫f dx = st(Σ hiperfinita de Riemann) com N infinito",
                Icone = "∫",
                Descricao = "Integral não-standard: soma de Riemann hiperfinita com N infinito termos e Δx infinitesimal, seguida de parte standard. Definição construtiva e intuitiva.",
                Criador = "Abraham Robinson",
                AnoOrigin = "1966",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 5. LÓGICA MODAL, TEORIA DOS CONJUNTOS E COMPUTABILIDADE
    // ─────────────────────────────────────────────────────
    private void AdicionarLogicaModalComputabilidade()
    {
        _formulas.AddRange([
            // 5.1 Lógica Modal
            new Formula
            {
                Id = "6_lm01", Nome = "Axioma K (Distribuição)", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Lógica Modal",
                Expressao = "□(p→q) → (□p→□q)",
                ExprTexto = "□(p→q) → (□p→□q) axioma de distribuição",
                Icone = "K",
                Descricao = "Axioma K: se é necessário que p implique q, e p é necessário, então q é necessário. Axioma base de toda lógica modal normal.",
                Criador = "Saul Kripke",
                AnoOrigin = "1963",
            },
            new Formula
            {
                Id = "6_lm02", Nome = "Axioma T (Reflexividade)", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Lógica Modal",
                Expressao = "□p → p",
                ExprTexto = "□p → p: o que é necessário é verdadeiro",
                Icone = "T",
                Descricao = "Axioma T: se p é necessário, então p é verdadeiro. Corresponde a relação de acessibilidade reflexiva. Sistema modal T = K + T.",
                Criador = "Robert Feys",
                AnoOrigin = "1937",
            },
            new Formula
            {
                Id = "6_lm03", Nome = "Axioma S4 (Transitividade)", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Lógica Modal",
                Expressao = "□p → □□p",
                ExprTexto = "□p → □□p: necessidade é necessariamente necessária",
                Icone = "S4",
                Descricao = "Axioma 4: necessidade é iterável. Com T, define S4 com relação pré-ordem. Lógica do conhecimento (o que sei, sei que sei).",
                Criador = "Clarence Irving Lewis",
                AnoOrigin = "1932",
            },
            new Formula
            {
                Id = "6_lm04", Nome = "Axioma S5 (Equivalência)", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Lógica Modal",
                Expressao = "◇p → □◇p",
                ExprTexto = "◇p → □◇p: possibilidade é necessariamente possível",
                Icone = "S5",
                Descricao = "Axioma 5: se algo é possível, é necessariamente possível. S5 = K+T+5, relação de equivalência. Lógica metafísica por excelência.",
                Criador = "Clarence Irving Lewis",
                AnoOrigin = "1932",
            },
            new Formula
            {
                Id = "6_lm05", Nome = "Semântica de Kripke", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Lógica Modal",
                Expressao = "M,w ⊨ □φ  ↔  ∀v(wRv → M,v ⊨ φ)",
                ExprTexto = "□φ verdadeiro em w ⟺ φ verdadeiro em todos os mundos acessíveis",
                Icone = "W",
                Descricao = "Semântica de Kripke: □φ é verdadeiro no mundo w sse φ é verdadeiro em todo mundo v acessível de w. Modelo: (W,R,V) mundos, relação, valoração.",
                Criador = "Saul Kripke",
                AnoOrigin = "1963",
            },
            new Formula
            {
                Id = "6_lm06", Nome = "Lógica Temporal LTL", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Lógica Modal",
                Expressao = "Gφ (sempre), Fφ (eventualmente), φUψ (until), Xφ (next)",
                ExprTexto = "G=sempre, F=eventualmente, U=until, X=next estado",
                Icone = "G",
                Descricao = "Lógica temporal linear (LTL): modalidades temporais para especificação de sistemas. G(p)='sempre p', F(p)='eventualmente p'. Base de model checking.",
                Criador = "Amir Pnueli",
                AnoOrigin = "1977",
            },
            new Formula
            {
                Id = "6_lm07", Nome = "Lógica Epistêmica", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Lógica Modal",
                Expressao = "K_i φ → φ;  K_i φ → K_i K_i φ;  C_G φ = ∧_i K_i C_G φ",
                ExprTexto = "Kᵢφ = agente i sabe φ; C_G = conhecimento comum",
                Icone = "K",
                Descricao = "Lógica epistêmica: K_i φ = agente i sabe φ. Satisfaz T e 4. C_G = conhecimento comum: todos sabem que todos sabem... Essencial em jogos e protocolos.",
                Criador = "Jaakko Hintikka",
                AnoOrigin = "1962",
            },

            // 5.2 Teoria dos Conjuntos (ZFC e além)
            new Formula
            {
                Id = "6_zf01", Nome = "Axiomas ZFC", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Teoria dos Conjuntos",
                Expressao = "ZFC = {Ext, Par, União, Potência, Inf, Sep, Rep, Fund, AC}",
                ExprTexto = "ZFC: 9 axiomas — Extensionalidade, Par, União, Potência, Infinito, Separação, Reposição, Fundação, Escolha",
                Icone = "ZF",
                Descricao = "Axiomas de Zermelo-Fraenkel com Escolha: fundamento padrão da matemática. Cada axioma garante existência de conjuntos específicos.",
                Criador = "Ernst Zermelo / Abraham Fraenkel",
                AnoOrigin = "1922",
            },
            new Formula
            {
                Id = "6_zf02", Nome = "Hipótese do Contínuo", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Teoria dos Conjuntos",
                Expressao = "CH: ∄ S com ℵ₀ < |S| < 2^{ℵ₀}",
                ExprTexto = "CH: não existe cardinal entre ℵ₀ e 2^{ℵ₀}",
                Icone = "CH",
                Descricao = "Hipótese do contínuo: não existe conjunto com cardinalidade entre ℕ e ℝ. Independente de ZFC (Gödel: consistente; Cohen: irrefutável).",
                Criador = "Georg Cantor",
                AnoOrigin = "1878",
            },
            new Formula
            {
                Id = "6_zf03", Nome = "Forcing de Cohen", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Teoria dos Conjuntos",
                Expressao = "p ⊩ φ  (condição p força sentença φ);  M[G] extensão genérica",
                ExprTexto = "Forcing: p⊩φ → extensão M[G] satisfaz φ",
                Icone = "⊩",
                Descricao = "Forcing de Cohen: técnica para construir modelos de ZFC com propriedades específicas. Prova independência de CH adicionando genéricos.",
                Criador = "Paul Cohen",
                AnoOrigin = "1963",
            },
            new Formula
            {
                Id = "6_zf04", Nome = "Grandes Cardinais (Inacessível)", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Teoria dos Conjuntos",
                Expressao = "κ inacessível: regular, limite forte (∀λ<κ, 2^λ<κ)",
                ExprTexto = "κ inacessível: incofinal regular e 2^λ<κ para todo λ<κ",
                Icone = "κ",
                Descricao = "Cardinal inacessível: não atingível por potência nem por cofinalidade. V_κ modela ZFC. Grande cardinal mais fraco; hierarquia: mensurável, Woodin, supercompacto...",
                Criador = "Wacław Sierpiński / Alfred Tarski",
                AnoOrigin = "1930",
            },
            new Formula
            {
                Id = "6_zf05", Nome = "Axioma de Determinação (AD)", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Teoria dos Conjuntos",
                Expressao = "AD: todo jogo de Gale-Stewart A ⊆ ω^ω é determinado",
                ExprTexto = "AD: todo jogo infinito sobre ω tem estratégia vencedora",
                Icone = "AD",
                Descricao = "Axioma de determinação: todo jogo infinito de informação perfeita sobre naturais é determinado. Incompatível com AC pleno mas consistente com DC.",
                Criador = "Jan Mycielski / Hugo Steinhaus",
                AnoOrigin = "1962",
            },
            new Formula
            {
                Id = "6_zf06", Nome = "Universo Construtível L", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Teoria dos Conjuntos",
                Expressao = "L = ∪_α L_α;  L₀=∅, L_{α+1}=Def(L_α), L_λ=∪_{α<λ}L_α",
                ExprTexto = "L = hierarquia construtível: cada nível = subconjuntos definíveis do anterior",
                Icone = "L",
                Descricao = "Universo construtível de Gödel: L contém apenas conjuntos definíveis. V=L implica GCH e AC. Modelo interno minimal de ZFC.",
                Criador = "Kurt Gödel",
                AnoOrigin = "1938",
            },
            new Formula
            {
                Id = "6_zf07", Nome = "Ordinais e Indução Transfinita", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Teoria dos Conjuntos",
                Expressao = "α = {β : β < α};  f(α) definida por f↾α (indução transfinita)",
                ExprTexto = "Ordinal α = {β<α}; define f(α) a partir de f nos predecessores",
                Icone = "ω",
                Descricao = "Ordinais de von Neumann e indução transfinita: cada ordinal é o conjunto de seus predecessores. Permite definir funções sobre todos os ordinais recursivamente.",
                Criador = "John von Neumann",
                AnoOrigin = "1923",
            },

            // 5.3 Computabilidade Avançada
            new Formula
            {
                Id = "6_tu01", Nome = "Graus de Turing", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Computabilidade Avançada",
                Expressao = "A ≤_T B  ↔  A computável com oráculo B;  deg(A) = {B: A≡_T B}",
                ExprTexto = "A ≤_T B: A computável com oráculo B; grau = classe de equivalência",
                Icone = "≤T",
                Descricao = "Graus de Turing: A ≤_T B se A é computável com oráculo para B. Estrutura parcialmente ordenada dos graus mede complexidade computacional relativa.",
                Criador = "Alan Turing / Emil Post",
                AnoOrigin = "1944",
            },
            new Formula
            {
                Id = "6_tu02", Nome = "Salto de Turing", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Computabilidade Avançada",
                Expressao = "A' = {e : Φ_e^A(e)↓};  0' = K (problema da parada)",
                ExprTexto = "A' = halting problem relativo a A; 0' = problema da parada",
                Icone = "'",
                Descricao = "Salto de Turing A': problema da parada relativo ao oráculo A. 0'=K. A < A' < A'' < ... gera hierarquia aritmética infinita.",
                Criador = "Alan Turing",
                AnoOrigin = "1939",
            },
            new Formula
            {
                Id = "6_tu03", Nome = "Hierarquia Aritmética", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Computabilidade Avançada",
                Expressao = "Σ⁰ₙ: ∃x₁∀x₂...R(x₁,...,xₙ,y);  Σ⁰₁ = r.e.",
                ExprTexto = "Σ⁰ₙ = n quantificadores alternados; Σ⁰₁ = recursivamente enumerável",
                Icone = "Σ",
                Descricao = "Hierarquia aritmética: classifica conjuntos pela complexidade de quantificadores. Σ⁰₁=r.e., Π⁰₁=co-r.e. Cada nível contém problemas estritamente mais difíceis.",
                Criador = "Stephen Kleene / Andrzej Mostowski",
                AnoOrigin = "1943",
            },
            new Formula
            {
                Id = "6_tu04", Nome = "Teorema de Post", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Computabilidade Avançada",
                Expressao = "A ∈ Σ⁰ₙ₊₁ ↔ A é r.e. em 0^{(n)};  Δ⁰ₙ = Σ⁰ₙ ∩ Π⁰ₙ",
                ExprTexto = "A∈Σ⁰ₙ₊₁ ⟺ A r.e. em 0^(n); Δ⁰ₙ = decidível em 0^(n-1)",
                Icone = "Δ",
                Descricao = "Teorema de Post: conecta hierarquia aritmética aos saltos de Turing. Σ⁰ₙ₊₁ = conjuntos r.e. em 0^(n). Δ⁰ₙ = conjuntos decidíveis com oráculo 0^(n-1).",
                Criador = "Emil Post",
                AnoOrigin = "1944",
            },
            new Formula
            {
                Id = "6_tu05", Nome = "Teorema de Rice", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Computabilidade Avançada",
                Expressao = "A = {e : φ_e ∈ P}, P propriedade não-trivial → A indecidível",
                ExprTexto = "Propriedade não-trivial de funções computáveis é indecidível",
                Icone = "R",
                Descricao = "Teorema de Rice: toda propriedade não-trivial das funções parciais computáveis é indecidível. Generaliza a indecidibilidade do problema da parada.",
                Criador = "Henry Gordon Rice",
                AnoOrigin = "1953",
            },
            new Formula
            {
                Id = "6_tu06", Nome = "Complexidade de Kolmogorov", Categoria = "Lógica Modal e Computabilidade", SubCategoria = "Computabilidade Avançada",
                Expressao = "K(x) = min{|p| : U(p) = x};  K(x) ≤ |x| + c",
                ExprTexto = "K(x) = menor programa que gera x; K(x) ≤ |x|+c",
                Icone = "K",
                Descricao = "Complexidade de Kolmogorov: K(x) = comprimento do menor programa que gera x em máquina universal. Incomputável mas fundamenta aleatoriedade algorítmica.",
                Criador = "Andrey Kolmogorov / Ray Solomonoff / Gregory Chaitin",
                AnoOrigin = "1965",
            },
        ]);
    }
}
