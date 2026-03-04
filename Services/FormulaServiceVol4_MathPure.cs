using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 4 — PARTE I: MATEMÁTICA PURA AVANÇADA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 1. GEOMETRIA SIMPLÉTICA E VARIEDADES DE POISSON
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaSipletica()
    {
        _formulas.AddRange([
            // 1.1 Formas Simpléticas
            new Formula
            {
                Id = "4_gs01", Nome = "Forma Simplética", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "ω ∈ Ω²(M): dω=0 (fechada) e ωⁿ≠0 (não-degenerada)",
                ExprTexto = "ω ∈ Ω²(M): dω=0, ωⁿ≠0",
                Icone = "ω",
                Descricao = "Uma forma simplética é uma 2-forma diferencial fechada e não-degenerada em M de dimensão 2n. Base da mecânica hamiltoniana e geometria simplética.",
                Criador = "Joseph-Louis Lagrange / William Rowan Hamilton",
            },
            new Formula
            {
                Id = "4_gs02", Nome = "Condições Simplética", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "dω = 0 (fechada) e ωⁿ ≠ 0 (não-degenerada; dim M = 2n)",
                ExprTexto = "dω=0; ωⁿ≠0; dim M=2n",
                Icone = "ωⁿ",
                Descricao = "Fechada: sem 'bordo' local; não-degenerada: isomorfismo TM→T*M. Toda variedade simplética é par-dimensional e orientável.",
            },
            new Formula
            {
                Id = "4_gs03", Nome = "Forma Canônica de Darboux", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "ω = Σᵢ dpᵢ ∧ dqᵢ  (em T*Q)",
                ExprTexto = "ω = Σᵢ dpᵢ∧dqᵢ",
                Icone = "dp∧dq",
                Descricao = "No fibrado cotangente T*Q com coordenadas (q,p), a forma simplética canônica. Coordenadas de posição q e momento p.",
                Criador = "Jean Gaston Darboux",
                AnoOrigin = "1882",
            },
            new Formula
            {
                Id = "4_gs04", Nome = "Teorema de Darboux", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "Toda var. simplética é localmente (ℝ²ⁿ, ω_can)",
                ExprTexto = "Localmente: (M,ω) ≅ (ℝ²ⁿ, Σdpᵢ∧dqᵢ)",
                Icone = "D",
                Descricao = "Não existem invariantes locais em geometria simplética (contraste com Riemanniana onde curvatura é local). Toda variedade simplética é localmente equivalente à canônica.",
                Criador = "Jean Gaston Darboux",
                AnoOrigin = "1882",
            },
            new Formula
            {
                Id = "4_gs05", Nome = "Campo Hamiltoniano", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "ι_{X_H}ω = dH  ↔  X_H = J·∇H",
                ExprTexto = "ι(X_H)ω = dH;  X_H = J∇H",
                Icone = "X_H",
                Descricao = "O campo vetorial hamiltoniano X_H é definido pela contração interior com ω. Em coordenadas canônicas: q̇=∂H/∂p, ṗ=-∂H/∂q (equações de Hamilton).",
                Criador = "William Rowan Hamilton",
                AnoOrigin = "1833",
            },
            new Formula
            {
                Id = "4_gs06", Nome = "Estrutura Quase-Complexa Canônica", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "J = [[0, I];[-I, 0]]; J²=-I",
                ExprTexto = "J = [[0,I],[-I,0]]; J²=−I",
                Icone = "J",
                Descricao = "Matriz simplética padrão 2n×2n. J² = -I (estrutura complexa). Transforma coordenadas de posição em momento e vice-versa.",
            },
            new Formula
            {
                Id = "4_gs07", Nome = "Teorema de Liouville (Simplético)", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "L_{X_H}ω = 0  (fluxo preserva ω)",
                ExprTexto = "ℒ_{X_H}ω = 0",
                Icone = "ℒ",
                Descricao = "O fluxo hamiltoniano preserva a forma simplética (e portanto o volume de fase). Fundamento da mecânica estatística: volume no espaço de fase é conservado.",
                Criador = "Joseph Liouville",
                AnoOrigin = "1838",
            },
            new Formula
            {
                Id = "4_gs08", Nome = "Volume de Liouville", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "dVol = ωⁿ/n!  (preservado pelo fluxo)",
                ExprTexto = "dVol = ωⁿ/n!",
                Icone = "Vol",
                Descricao = "A forma volume simplética é ωⁿ/n!, que é preservada pelo fluxo hamiltoniano. Toda variedade simplética é orientável e tem volume natural.",
            },
            new Formula
            {
                Id = "4_gs09", Nome = "Redução Simplética (Marsden-Weinstein)", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "M//G = μ⁻¹(0)/G",
                ExprTexto = "M//G = μ⁻¹(0)/G",
                Icone = "//",
                Descricao = "Redução por simetria: dado grupo G agindo em (M,ω) com mapa momento μ, o quociente μ⁻¹(0)/G herda estrutura simplética de dimensão dim M - 2·dim G.",
                Criador = "Jerrold Marsden / Alan Weinstein",
                AnoOrigin = "1974",
            },
            new Formula
            {
                Id = "4_gs10", Nome = "Mapa Momento", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "μ: M → g*;  {μₐ,μᵦ} = μ_{[a,b]}",
                ExprTexto = "μ: M→g*; {μₐ,μᵦ}=μ_{[a,b]}",
                Icone = "μ",
                Descricao = "Mapa momento codifica a ação de um grupo de Lie G em (M,ω). Homomorfismo de álgebras de Lie: colchete de Poisson dos momentos = momento do colchete de Lie.",
                Criador = "Bertram Kostant / Jean-Marie Souriau",
                AnoOrigin = "1966/1970",
            },
            // 1.2 Variedades de Poisson
            new Formula
            {
                Id = "4_pv01", Nome = "Colchete de Poisson", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "{f,g}: bilinear, antissimétrico, Jacobi, Leibniz",
                ExprTexto = "{f,g}:C∞×C∞→C∞; antissim, Jacobi, Leibniz",
                Icone = "{,}",
                Descricao = "Estrutura de Poisson: colchete bilinear antissimétrico satisfazendo identidade de Jacobi e regra de Leibniz. Generaliza variedades simpléticas (pode ser degenerado).",
                Criador = "Siméon Denis Poisson",
                AnoOrigin = "1809",
            },
            new Formula
            {
                Id = "4_pv02", Nome = "Tensor de Poisson", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "{f,g} = Πⁱʲ ∂ᵢf·∂ⱼg",
                ExprTexto = "{f,g} = Πⁱʲ∂ᵢf·∂ⱼg",
                Icone = "Π",
                Descricao = "O bivetor Π codifica o colchete de Poisson. Em coordenadas: Πⁱʲ = {xⁱ,xʲ}. Antissimétrico: Πⁱʲ = -Πʲⁱ.",
            },
            new Formula
            {
                Id = "4_pv03", Nome = "Condição de Jacobi (Poisson)", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "Σ Πⁱˡ∂ₗΠʲᵏ + permutações cíclicas = 0",
                ExprTexto = "[Π,Π]_SN = 0 (Schouten-Nijenhuis)",
                Icone = "SN",
                Descricao = "Condição de integrabilidade: o colchete de Schouten-Nijenhuis de Π consigo mesmo é zero. Equivalente à identidade de Jacobi para {,}.",
            },
            new Formula
            {
                Id = "4_pv04", Nome = "Simplético como Poisson Não-Degenerado", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "Π = ω⁻¹  (caso não-degenerado)",
                ExprTexto = "Π = ω⁻¹ (simplético ↔ Poisson não-deg.)",
                Icone = "ω⁻¹",
                Descricao = "Quando Π é não-degenerado (invertível), existe forma simplética ω = Π⁻¹. Variedades simpléticas são caso especial de variedades de Poisson.",
            },
            new Formula
            {
                Id = "4_pv05", Nome = "Folheação Simplética", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "Folhas de Π são variedades simpléticas",
                ExprTexto = "Folhas simpléticas: subvariedades simpléticas maximais",
                Icone = "🍃",
                Descricao = "Toda variedade de Poisson se decompõe em folhas simpléticas de dimensão = rank local de Π. A dinâmica hamiltoniana fica contida em cada folha.",
                Criador = "Alan Weinstein",
                AnoOrigin = "1983",
            },
            // 1.3 Quantização Geométrica
            new Formula
            {
                Id = "4_qg01", Nome = "Pré-Quantização (Fibrado de Linha)", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "Linha de fibra L → M com curvatura ω/ℏ",
                ExprTexto = "L→M; curv(∇)=ω/ℏ",
                Icone = "L",
                Descricao = "Condição de quantização: ω/2πℏ deve ser classe inteira em H²(M,ℤ). Seções de L são os 'estados quânticos' antes de polarização.",
                Criador = "Bertram Kostant / Jean-Marie Souriau",
                AnoOrigin = "1970",
            },
            new Formula
            {
                Id = "4_qg02", Nome = "Operador de Pré-Quantização", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "Q̂(f) = -iℏ∇_{X_f} + f",
                ExprTexto = "Q̂(f) = −iℏ∇_{X_f} + f",
                Icone = "Q̂",
                Descricao = "Operador que associa a cada observável f um operador em seções de L. Preserva o colchete de Poisson: [Q̂(f),Q̂(g)] = -iℏQ̂({f,g}).",
            },
            new Formula
            {
                Id = "4_qg03", Nome = "Polarização", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "P ⊂ TM^ℂ lagrangiano; ∇_X ψ = 0 ∀X ∈ P",
                ExprTexto = "P⊂TMℂ lagrangiano; ∇_Xψ=0 ∀X∈P",
                Icone = "P",
                Descricao = "Polarização reduz o espaço de Hilbert: seções covariabilis constantes ao longo de P. Elimina 'metade dos graus de liberdade' para obter mecânica quântica usual.",
            },
            new Formula
            {
                Id = "4_qg04", Nome = "Polarização Vertical", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "ψ depende só de q → Mecânica Quântica usual",
                ExprTexto = "ψ=ψ(q); ∂ψ/∂p=0",
                Icone = "q",
                Descricao = "Escolhendo polarização vertical (∂/∂p), seções dependem só de q: recupera representação de Schrödinger. p̂=-iℏ∂/∂q.",
            },
            new Formula
            {
                Id = "4_qg05", Nome = "Correção Metaplética", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "Half-form bundle para medida correta",
                ExprTexto = "√(volume bundle) → medida L² correta",
                Icone = "½",
                Descricao = "Para obter o produto interno L² correto no espaço de Hilbert, multiplica-se por half-forms (raiz quadrada do fibrado canônico). Corrige fatores de normalização.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 2. TOPOLOGIA ALGÉBRICA AVANÇADA
    // ─────────────────────────────────────────────────────
    private void AdicionarTopologiaAlgebricaAvancada()
    {
        _formulas.AddRange([
            // 2.1 Sequências Espectrais
            new Formula
            {
                Id = "4_se01", Nome = "Sequência Espectral", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Sequências Espectrais",
                Expressao = "(Eʳₚ,q, dʳ); dʳ: Eʳₚ,q → Eʳₚ₋ᵣ,q₊ᵣ₋₁",
                ExprTexto = "(Eʳ_{p,q}, dʳ);  bigrau de dʳ = (−r,r−1)",
                Icone = "Eʳ",
                Descricao = "Ferramenta algébrica computacional: sequência de páginas Eʳ, cada uma com diferencial dʳ. Cada página é a homologia da anterior. Converge a graded associated do objeto desejado.",
                Criador = "Jean Leray",
                AnoOrigin = "1946",
            },
            new Formula
            {
                Id = "4_se02", Nome = "Página Sucessiva", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Sequências Espectrais",
                Expressao = "Eʳ⁺¹ₚ,q = H(Eʳₚ,q, dʳ) = ker(dʳ)/Im(dʳ)",
                ExprTexto = "Eʳ⁺¹ = ker dʳ/Im dʳ",
                Icone = "Hd",
                Descricao = "Cada página é a homologia da anterior. Sequência colapsa quando dʳ=0 para r≥r₀. Informação é refinada a cada página.",
            },
            new Formula
            {
                Id = "4_se03", Nome = "Sequência Espectral de Serre", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Sequências Espectrais",
                Expressao = "Hₚ(B; Hq(F)) ⟹ Hₚ₊q(E)  (F→E→B fibração)",
                ExprTexto = "E²_{p,q}=Hₚ(B;Hq(F)) ⟹ Hₚ₊q(E)",
                Icone = "SS",
                Descricao = "Para fibração F→E→B: a E² página tem Hₚ(B; Hq(F)), e a sequência converge para H*(E). Calcula homologia do espaço total a partir de base e fibra.",
                Criador = "Jean-Pierre Serre",
                AnoOrigin = "1951",
            },
            new Formula
            {
                Id = "4_se04", Nome = "Leray-Hirsch", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Sequências Espectrais",
                Expressao = "H*(E) ≅ H*(B) ⊗ H*(F)  (se classes globais existem)",
                ExprTexto = "H*(E) ≅ H*(B)⊗H*(F)",
                Icone = "LH",
                Descricao = "Se a fibração admite classes de cohomologia que restringem a geradores de H*(F): a cohomologia do espaço total é produto tensorial (sem torsão).",
                Criador = "Jean Leray / Guy Hirsch",
            },
            new Formula
            {
                Id = "4_se05", Nome = "Sequência Espectral de Adams", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Sequências Espectrais",
                Expressao = "Ext^{s,t}_{A}(ℤ₂,ℤ₂) ⟹ π_{t-s}^s(S⁰)",
                ExprTexto = "Ext_A^{s,t}(ℤ₂,ℤ₂) ⟹ π_{t−s}(S⁰)",
                Icone = "Adams",
                Descricao = "Calcula grupos de homotopia estáveis de esferas π*(S⁰) a partir do Ext sobre a álgebra de Steenrod A. Ferramenta central da topologia estável.",
                Criador = "J. Frank Adams",
                AnoOrigin = "1958",
            },
            // 2.2 K-Teoria
            new Formula
            {
                Id = "4_kt01", Nome = "K⁰(X) — Grupo de Grothendieck", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "K⁰(X) = Grupo de Grothendieck de fibrados vetoriais sobre X",
                ExprTexto = "K⁰(X) = Groth(Vect(X))",
                Icone = "K⁰",
                Descricao = "Grupo abeliano gerado por classes de isomorfismo de fibrados vetoriais sobre X. Diferenças formais [E]-[F]. Informação topológica refinada.",
                Criador = "Alexander Grothendieck / Michael Atiyah / Friedrich Hirzebruch",
                AnoOrigin = "1959",
            },
            new Formula
            {
                Id = "4_kt02", Nome = "K-Teoria Reduzida", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "K̃⁰(X) = K⁰(X)/K⁰(pt) = ker(K⁰(X)→ℤ)",
                ExprTexto = "K̃⁰(X) = K⁰(X)/K⁰(pt)",
                Icone = "K̃",
                Descricao = "Remove o fator trivial (dimensão do fibrado): classes 'essencialmente' não-triviais. Mais adequada para suspensões e sequências exatas.",
            },
            new Formula
            {
                Id = "4_kt03", Nome = "Periodicidade de Bott", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "Kⁿ(X) ≅ Kⁿ⁺²(X)  (período 2)",
                ExprTexto = "Kⁿ(X) ≅ Kⁿ⁺²(X)",
                Icone = "Bott",
                Descricao = "Resultado profundo: K-teoria complexa é 2-periódica. Análogo real: 8-periódico. Extremamente poderoso para cálculos. Implica π₂(BU)=ℤ.",
                Criador = "Raoul Bott",
                AnoOrigin = "1959",
            },
            new Formula
            {
                Id = "4_kt04", Nome = "Sequência Exata de K-Teoria", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "...→K¹(A)→K⁰(X,A)→K⁰(X)→K⁰(A)→...",
                ExprTexto = "⋯→K¹(A)→K⁰(X,A)→K⁰(X)→K⁰(A)→⋯",
                Icone = "→",
                Descricao = "Sequência exata longa de um par (X,A): conecta K-teoria de X, A e quociente. Ferramenta computacional fundamental.",
            },
            new Formula
            {
                Id = "4_kt05", Nome = "Teorema do Índice (Atiyah-Singer)", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "ind(D) = ∫_M Â(M)·ch(E)",
                ExprTexto = "ind(D) = ∫_M Â(M)·ch(E)",
                Icone = "ind",
                Descricao = "Índice analítico de operador elíptico D = integral de classes características. Conecta análise (dim ker - dim coker) com topologia (classes de Chern e A-hat).",
                Criador = "Michael Atiyah / Isadore Singer",
                AnoOrigin = "1963",
            },
            new Formula
            {
                Id = "4_kt06", Nome = "Classe Â (A-hat)", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "Â(M) = ∏ (xᵢ/2)/(sinh(xᵢ/2))",
                ExprTexto = "Â(M) = ∏(xᵢ/2)/sinh(xᵢ/2)",
                Icone = "Â",
                Descricao = "Classe característica usada no teorema do índice para operador de Dirac. xᵢ = classes de Chern da variedade. Para variedade de spin, Â∈ℤ.",
            },
            new Formula
            {
                Id = "4_kt07", Nome = "Caractere de Chern", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "ch(E) = tr(exp(F/2πi)) = Σ rₖ(E)/k!",
                ExprTexto = "ch(E) = tr(e^{F/2πi})",
                Icone = "ch",
                Descricao = "Homomorfismo de anel ch: K(X)→H*(X;ℚ). Traduz informação de K-teoria em cohomologia racional. F = curvatura da conexão no fibrado E.",
            },
            // 2.3 Álgebra Homológica
            new Formula
            {
                Id = "4_ah01", Nome = "Complexo de Cadeia", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "... → Cₙ →^∂ Cₙ₋₁ → ...; ∂² = 0",
                ExprTexto = "⋯→Cₙ →∂→ Cₙ₋₁→⋯; ∂²=0",
                Icone = "∂²=0",
                Descricao = "Sequência de módulos conectados por homomorfismos (bordos) cuja composição é zero. Condição ∂²=0 permite definir homologia como ker/im.",
            },
            new Formula
            {
                Id = "4_ah02", Nome = "Grupo de Homologia", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Hₙ(C) = ker ∂ₙ / Im ∂ₙ₊₁",
                ExprTexto = "Hₙ = ker ∂ₙ/Im ∂ₙ₊₁",
                Icone = "Hₙ",
                Descricao = "Ciclos (ker ∂) módulo bordos (Im ∂): mede 'buracos' n-dimensionais. H₀=componentes, H₁=loops, H₂=cavidades. Invariante topológico fundamental.",
            },
            new Formula
            {
                Id = "4_ah03", Nome = "Resolução Projetiva", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "0 ← M ← P₀ ← P₁ ← P₂ ← ...",
                ExprTexto = "0←M←P₀←P₁←P₂←⋯ (Pᵢ projetivo)",
                Icone = "P•",
                Descricao = "Substitui M por módulos projetivos (que 'levantam' homomorfismos). Permite calcular Tor e Ext. Sempre existe; não é única mas é única a menos de homotopia.",
            },
            new Formula
            {
                Id = "4_ah04", Nome = "Funtor Tor", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Torₙᴿ(M,N) = Hₙ(P• ⊗ᴿ N)",
                ExprTexto = "Torₙ(M,N) = Hₙ(P•⊗N)",
                Icone = "Tor",
                Descricao = "Funtor derivado do produto tensorial. Tor₀=M⊗N. Tor mede 'falha de exatidão' do tensor. Tor₁(ℤ/m,ℤ/n) = ℤ/gcd(m,n).",
            },
            new Formula
            {
                Id = "4_ah05", Nome = "Funtor Ext", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Extⁿᴿ(M,N) = Hⁿ(Hom_R(P•,N))",
                ExprTexto = "Extⁿ(M,N) = Hⁿ(Hom(P•,N))",
                Icone = "Ext",
                Descricao = "Funtor derivado de Hom. Ext⁰=Hom. Ext¹ classifica extensões 0→N→E→M→0. Central em cohomologia de grupos e álgebras de Lie.",
            },
            new Formula
            {
                Id = "4_ah06", Nome = "Sequência Exata Longa (Tor)", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "0→A→B→C→0 induz ...→Torₙ(A)→Torₙ(B)→Torₙ(C)→Torₙ₋₁(A)→...",
                ExprTexto = "⋯→Torₙ(C)→Torₙ₋₁(A)→Torₙ₋₁(B)→⋯",
                Icone = "⋯",
                Descricao = "Sequência exata curta induz sequência exata longa em Tor (e Ext). Mapa de conexão δ: Torₙ(C)→Torₙ₋₁(A). Ferramenta computacional essencial.",
            },
            new Formula
            {
                Id = "4_ah07", Nome = "Lema da Serpente", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Diagrama comutativo com linhas exatas → sequência exata longa",
                ExprTexto = "ker f→ker g→ker h →δ→ coker f→coker g→coker h",
                Icone = "🐍",
                Descricao = "Dado diagrama comutativo com linhas exatas, existe sequência exata conectando kernels e cokernels via mapa δ 'serpente'. Base de muitas sequências exatas longas.",
            },
            new Formula
            {
                Id = "4_ah08", Nome = "Fórmula de Künneth", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Hₙ(X×Y) = ⊕_{p+q=n} Hₚ(X)⊗Hq(Y) ⊕ ⊕ Tor(Hₚ,Hq)",
                ExprTexto = "Hₙ(X×Y) = ⊕ Hₚ(X)⊗Hq(Y) ⊕ Tor",
                Icone = "×",
                Descricao = "Homologia de produto: dominada pelo tensor dos fatores mais correção de Tor (torsão). Sobre corpo (ℚ,ℝ): Tor=0 e fórmula simplifica.",
                Criador = "Hermann Künneth",
                AnoOrigin = "1923",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 3. FORMAS MODULARES E FUNÇÕES L
    // ─────────────────────────────────────────────────────
    private void AdicionarFormasModulares()
    {
        _formulas.AddRange([
            // 3.1 Formas Modulares
            new Formula
            {
                Id = "4_fm01", Nome = "Grupo Modular SL₂(ℤ)", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "SL₂(ℤ) = {[[a,b],[c,d]]: ad-bc=1, a,b,c,d∈ℤ}",
                ExprTexto = "SL₂(ℤ) = {γ∈M₂(ℤ): det γ=1}",
                Icone = "SL₂",
                Descricao = "Grupo de matrizes 2×2 inteiras com determinante 1. Gerado por T=[[1,1],[0,1]] (τ→τ+1) e S=[[0,-1],[1,0]] (τ→-1/τ). Age no semiplano superior H.",
            },
            new Formula
            {
                Id = "4_fm02", Nome = "Ação do Grupo Modular", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "γτ = (aτ+b)/(cτ+d); γ∈SL₂(ℤ), τ∈H",
                ExprTexto = "γ·τ = (aτ+b)/(cτ+d)",
                Icone = "γτ",
                Descricao = "Transformação de Möbius: SL₂(ℤ) age por automorfismos do semiplano H={τ∈ℂ: Im τ > 0}. Domínio fundamental: |τ|≥1, |Re τ|≤½.",
            },
            new Formula
            {
                Id = "4_fm03", Nome = "Forma Modular de Peso k", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "f(γτ) = (cτ+d)^k f(τ)",
                ExprTexto = "f(γτ) = (cτ+d)ᵏf(τ)",
                Icone = "Mₖ",
                Descricao = "Função holomorfa em H satisfazendo lei de transformação modular mais condição de holomorfismo nas cúspides. Espaço Mₖ(SL₂(ℤ)) é finito-dimensional.",
            },
            new Formula
            {
                Id = "4_fm04", Nome = "Expansão de Fourier (q-expansão)", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "f(τ) = Σ_{n=0}^∞ aₙ qⁿ;  q = e^{2πiτ}",
                ExprTexto = "f(τ) = Σₙaₙqⁿ; q=e²ᵖⁱᵗ",
                Icone = "q",
                Descricao = "Periodicidade f(τ+1)=f(τ) permite expansão em q=e^{2πiτ}. Coeficientes aₙ codificam informação aritmética profunda (número de representações, pontos em variedades...).",
            },
            new Formula
            {
                Id = "4_fm05", Nome = "Séries de Eisenstein", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "G_k(τ) = Σ'_{m,n∈ℤ} (mτ+n)^{-k}  (k≥4 par)",
                ExprTexto = "Gₖ(τ) = Σ'(mτ+n)⁻ᵏ",
                Icone = "Gₖ",
                Descricao = "Formas modulares mais simples: somas sobre reticulado ℤ+ℤτ. G₄ e G₆ geram o anel de formas modulares. Σ' exclui (m,n)=(0,0).",
                Criador = "Gotthold Eisenstein",
                AnoOrigin = "~1847",
            },
            new Formula
            {
                Id = "4_fm06", Nome = "G₄ e G₆ Normalizadas", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "E₄=1+240Σσ₃(n)qⁿ; E₆=1-504Σσ₅(n)qⁿ",
                ExprTexto = "E₄ = 1+240Σσ₃(n)qⁿ; E₆ = 1−504Σσ₅(n)qⁿ",
                Icone = "E₄E₆",
                Descricao = "σₖ(n) = soma dos k-ésimos potências dos divisores de n. E₄,E₆ geram o anel graduado ⊕Mₖ. dim Mₖ cresce linearmente com k.",
            },
            new Formula
            {
                Id = "4_fm07", Nome = "Discriminante Modular Δ", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "Δ(τ) = (2π)¹² η(τ)²⁴;  η = q^{1/24} ∏ₙ(1-qⁿ)",
                ExprTexto = "Δ = (2π)¹²η²⁴;  η = q^{1/24}∏(1−qⁿ)",
                Icone = "Δ",
                Descricao = "Única forma cúspide de peso 12 (a menos de escalar). Δ = (E₄³-E₆²)/1728. Função de Ramanujan: Δ=Σ τ(n)qⁿ; τ(n) = coeficiente de Ramanujan.",
                Criador = "Richard Dedekind / Srinivasa Ramanujan",
            },
            new Formula
            {
                Id = "4_fm08", Nome = "j-Invariante", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "j(τ) = E₄³/Δ = q⁻¹+744+196884q+...",
                ExprTexto = "j(τ) = E₄³/Δ = q⁻¹+744+196884q+⋯",
                Icone = "j",
                Descricao = "Função modular de peso 0 (invariante). Gera o corpo de funções modulares. j classifica curvas elípticas sobre ℂ. Coef. 196884 = dim da rep. mínima do grupo Monstro (Monstrous Moonshine).",
            },
            new Formula
            {
                Id = "4_fm09", Nome = "Operadores de Hecke", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "Tₙf = nᵏ⁻¹ Σ_{ad=n} Σ_{b=0}^{d-1} d⁻ᵏ f((aτ+b)/d)",
                ExprTexto = "Tₙf = nᵏ⁻¹ Σ d⁻ᵏf((aτ+b)/d)",
                Icone = "Tₙ",
                Descricao = "Operadores lineares em Mₖ que comutam entre si. Autoformas simultâneas de todos Tₙ → autovalores = coeficientes de Fourier. Estrutura aritmética profunda.",
                Criador = "Erich Hecke",
                AnoOrigin = "1937",
            },
            new Formula
            {
                Id = "4_fm10", Nome = "Forma Cúspide", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "a₀ = 0; f ∈ Sₖ(SL₂(ℤ));  dim S₁₂ = 1 (gerado por Δ)",
                ExprTexto = "Sₖ = {f∈Mₖ: a₀=0}",
                Icone = "Sₖ",
                Descricao = "Forma modular que se anula nas cúspides. Espaço Sₖ = ker(Mₖ→ℂ). dim S₁₂=1, dim S₂₄=2. Produto de Petersson torna Sₖ espaço de Hilbert.",
            },
            // 3.2 Funções L e Hipótese de Riemann
            new Formula
            {
                Id = "4_fl01", Nome = "Função Zeta de Riemann", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "ζ(s) = Σ n⁻ˢ = ∏ (1-p⁻ˢ)⁻¹  (Re s > 1)",
                ExprTexto = "ζ(s) = Σn⁻ˢ = ∏ₚ(1−p⁻ˢ)⁻¹",
                Icone = "ζ",
                Descricao = "Produto de Euler sobre primos ↔ soma de Dirichlet: ponte entre análise e teoria dos números. Polo simples em s=1. Extensão meromorfa a ℂ.",
                Criador = "Bernhard Riemann / Leonhard Euler",
                AnoOrigin = "1859/1737",
            },
            new Formula
            {
                Id = "4_fl02", Nome = "Equação Funcional de ζ", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "ξ(s) = ξ(1-s);  ξ(s) = ½s(s-1)π^{-s/2}Γ(s/2)ζ(s)",
                ExprTexto = "ξ(s) = ξ(1−s);  ξ = ½s(s−1)π⁻ˢ/²Γ(s/2)ζ(s)",
                Icone = "ξ",
                Descricao = "Simetria s↔1-s da zeta completada. Consequência da transformação de Poisson/Jacobi. Generaliza para todas funções L (conjecturas de Langlands).",
                Criador = "Bernhard Riemann",
                AnoOrigin = "1859",
            },
            new Formula
            {
                Id = "4_fl03", Nome = "Zeros Triviais de ζ", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "s = -2, -4, -6, ...  (inteiros negativos pares)",
                ExprTexto = "ζ(-2n)=0 ∀n∈ℕ",
                Icone = "0",
                Descricao = "Zeros 'óbvios' vindo do fator Γ(s/2). Todos os outros zeros (não-triviais) estão na faixa crítica 0<Re s<1.",
            },
            new Formula
            {
                Id = "4_fl04", Nome = "Hipótese de Riemann", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "Zeros não-triviais: Re(s) = ½  (ABERTO)",
                ExprTexto = "ζ(s)=0, s não-triv. ⟹ Re(s)=½ (?)",
                Icone = "½",
                Descricao = "O mais famoso problema aberto da matemática (Millennium Prize). Equivalente a: erro no TPN é O(√x·ln x). Verificado para os primeiros 10¹³ zeros.",
                Criador = "Bernhard Riemann",
                AnoOrigin = "1859",
            },
            new Formula
            {
                Id = "4_fl05", Nome = "Função L de Dirichlet", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "L(s,χ) = Σ χ(n)/nˢ = ∏ (1-χ(p)p⁻ˢ)⁻¹",
                ExprTexto = "L(s,χ) = Σχ(n)n⁻ˢ = ∏(1−χ(p)p⁻ˢ)⁻¹",
                Icone = "L(χ)",
                Descricao = "Generalização de ζ com carácter χ: detecta primos em progressões aritméticas. L(1,χ)≠0 para χ≠χ₀ é essencial para o teorema de Dirichlet.",
                Criador = "Peter Gustav Lejeune Dirichlet",
                AnoOrigin = "1837",
            },
            new Formula
            {
                Id = "4_fl06", Nome = "Teorema de Dirichlet (Primos em PA)", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "gcd(a,q)=1 ⟹ infinitos primos p≡a (mod q)",
                ExprTexto = "gcd(a,q)=1 ⟹ ∞ primos ≡a(mod q)",
                Icone = "PA",
                Descricao = "Existem infinitos primos em qualquer progressão aritmética a, a+q, a+2q,... com gcd(a,q)=1. Demonstrado usando L(1,χ)≠0.",
                Criador = "Peter Gustav Lejeune Dirichlet",
                AnoOrigin = "1837",
            },
            new Formula
            {
                Id = "4_fl07", Nome = "Função L de Forma Modular", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "L(s,f) = Σ aₙn⁻ˢ  (Fator de Euler por forma modular f)",
                ExprTexto = "L(s,f) = Σaₙn⁻ˢ = ∏ₚ(1−aₚp⁻ˢ+p^{k−1−2s})⁻¹",
                Icone = "L(f)",
                Descricao = "Coeficientes de Fourier de forma modular geram função L com equação funcional e fator de Euler. Programa de Langlands: todas funções L vêm de formas automorfas.",
            },
            new Formula
            {
                Id = "4_fl08", Nome = "Conjectura de Birch e Swinnerton-Dyer", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "ord_{s=1} L(E,s) = rank E(ℚ)  (Millennium Prize)",
                ExprTexto = "ords=1 L(E,s) = rank E(ℚ)",
                Icone = "BSD",
                Descricao = "Ordem de anulamento de L(E,s) em s=1 = rank do grupo de Mordell-Weil E(ℚ). Conecta análise (função L) com aritmética (pontos racionais). Millennium Prize Problem.",
                Criador = "Bryan Birch / Peter Swinnerton-Dyer",
                AnoOrigin = "1965",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 4. TEORIA ERGÓDICA
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaErgodica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_er01", Nome = "Sistema Dinâmico Medido", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "(X, F, μ, T);  T: X→X preserva medida",
                ExprTexto = "(X,ℱ,μ,T); μ(T⁻¹A)=μ(A)",
                Icone = "T",
                Descricao = "Espaço de probabilidade (X,F,μ) com transformação mensurável T que preserva μ. Modelo abstrato para evolução temporal determinística com invariância estatística.",
            },
            new Formula
            {
                Id = "4_er02", Nome = "Ergodicidade", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "T⁻¹A = A ⟹ μ(A) = 0 ou μ(A) = 1",
                ExprTexto = "T⁻¹A=A ⟹ μ(A)∈{0,1}",
                Icone = "erg",
                Descricao = "Conjuntos invariantes são triviais: o sistema não pode ser decomposto em partes invariantes. Implicação: média temporal = média espacial (para quase toda órbita).",
            },
            new Formula
            {
                Id = "4_er03", Nome = "Teorema Ergódico de Birkhoff", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "(1/N) Σ_{n=0}^{N-1} f(Tⁿx) → ∫f dμ  μ-q.t.p.",
                ExprTexto = "(1/N)Σf(Tⁿx) → ∫f dμ  q.t.p.",
                Icone = "B",
                Descricao = "Média temporal converge pontualmente à média espacial para sistema ergódico. Resultado central: justifica uso de médias temporais em mecânica estatística.",
                Criador = "George David Birkhoff",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "4_er04", Nome = "Teorema Ergódico de von Neumann", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "(1/N) Σ f∘Tⁿ → ∫f dμ  (convergência em L²)",
                ExprTexto = "‖(1/N)Σf∘Tⁿ − ∫f‖₂ → 0",
                Icone = "L²",
                Descricao = "Convergência em norma L² (mais fraca que Birkhoff mas anterior). Usa análise espectral do operador unitário Uf=f∘T.",
                Criador = "John von Neumann",
                AnoOrigin = "1932",
            },
            new Formula
            {
                Id = "4_er05", Nome = "Mixing Forte", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "μ(A ∩ T⁻ⁿB) → μ(A)·μ(B)  quando n→∞",
                ExprTexto = "μ(A∩T⁻ⁿB) → μ(A)μ(B)",
                Icone = "mix",
                Descricao = "Correlações decaem: eventos passados e futuros tornam-se assintoticamente independentes. Mixing forte ⟹ ergódico (mas não vice-versa).",
            },
            new Formula
            {
                Id = "4_er06", Nome = "Entropia de Kolmogorov-Sinai", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "h(T) = sup_P h(T,P)",
                ExprTexto = "h(T) = supₚ h(T,P)",
                Icone = "h(T)",
                Descricao = "Supremo da taxa de criação de informação sobre todas partições mensuráveis. Mede a 'imprevisibilidade intrínseca' do sistema. h(T)>0 ⟹ caos.",
                Criador = "Andrey Kolmogorov / Yakov Sinai",
                AnoOrigin = "1958/1959",
            },
            new Formula
            {
                Id = "4_er07", Nome = "Entropia de Partição", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "h(T,P) = lim_{n→∞} H(P ∨ T⁻¹P ∨...∨ T^{-n+1}P)/n",
                ExprTexto = "h(T,P) = lim H(∨ᵢT⁻ⁱP)/n",
                Icone = "h(P)",
                Descricao = "Taxa de crescimento da entropia de Shannon da partição refinada iterativamente. H(Q) = -Σμ(Qᵢ)log μ(Qᵢ). Mede informação nova por iteração.",
            },
            new Formula
            {
                Id = "4_er08", Nome = "Teorema de Ornstein", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "Bernoulli shifts com mesma entropia são isomorfos",
                ExprTexto = "h(B₁)=h(B₂) ⟹ B₁≅B₂",
                Icone = "≅",
                Descricao = "A entropia classifica completamente os shifts de Bernoulli. Resultado profundo: entropia é o único invariante para essa classe de sistemas.",
                Criador = "Donald Ornstein",
                AnoOrigin = "1970",
            },
            new Formula
            {
                Id = "4_er09", Nome = "Princípio Variacional (Entropia Topológica)", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "h_top(T) = sup_μ h_μ(T)",
                ExprTexto = "htop(T) = supμ hμ(T)",
                Icone = "htop",
                Descricao = "Entropia topológica = supremo da entropia métrica sobre todas medidas invariantes. Medida que atinge o supremo = medida de máxima entropia.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 5. ANÁLISE p-ÁDICA E ARITMÉTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarAnalisePAdica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_pa01", Nome = "Valor Absoluto p-Ádico", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "|x|_p = p^{-vₚ(x)};  vₚ(pᵃ·m/n) = a",
                ExprTexto = "|x|ₚ = p⁻ᵛₚ⁽ˣ⁾; vₚ(pᵃm/n)=a",
                Icone = "|·|ₚ",
                Descricao = "Valoração p-ádica: |pⁿ|ₚ = p⁻ⁿ. Quanto mais divisível por p, menor o valor absoluto. Inverte a noção de 'tamanho': potências de p são pequenas!",
            },
            new Formula
            {
                Id = "4_pa02", Nome = "Desigualdade Ultramétrica", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "|x+y|_p ≤ max(|x|_p, |y|_p)",
                ExprTexto = "|x+y|ₚ ≤ max(|x|ₚ,|y|ₚ)",
                Icone = "ultra",
                Descricao = "Mais forte que desigualdade triangular: soma nunca excede o maior. Consequências: todo triângulo é isósceles, toda bola é aberta E fechada, toda bola é simultaneamente bola centrada em qualquer de seus pontos.",
            },
            new Formula
            {
                Id = "4_pa03", Nome = "Corpo ℚₚ", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "ℚₚ = completamento de ℚ em |·|_p",
                ExprTexto = "ℚₚ = compl(ℚ, |·|ₚ)",
                Icone = "ℚₚ",
                Descricao = "Analogamente a ℝ = completamento de ℚ em |·|∞, ℚₚ é outro completamento. Para cada primo p, um mundo aritmético diferente. Teoria de corpos locais.",
            },
            new Formula
            {
                Id = "4_pa04", Nome = "Inteiros p-Ádicos", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "ℤₚ = {x ∈ ℚₚ : |x|_p ≤ 1}",
                ExprTexto = "ℤₚ = {x∈ℚₚ: |x|ₚ≤1}",
                Icone = "ℤₚ",
                Descricao = "Disco unitário = anel de inteiros p-ádicos. Compacto, principal. Todo x∈ℤₚ tem representação como série em potências de p (análogo de expansão decimal).",
            },
            new Formula
            {
                Id = "4_pa05", Nome = "Expansão p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "x = Σ_{n=vₚ(x)}^∞ aₙpⁿ;  aₙ ∈ {0,...,p-1}",
                ExprTexto = "x = Σₙ aₙpⁿ; aₙ∈{0,…,p−1}",
                Icone = "Σaₙpⁿ",
                Descricao = "Todo x∈ℚₚ se escreve como série de Laurent em p (potências negativas finitas). Ex.: -1 = (p-1)+(p-1)p+(p-1)p²+... em ℤₚ.",
            },
            new Formula
            {
                Id = "4_pa06", Nome = "Fórmula do Produto de Ostrowski", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "|x|_∞ · ∏_p |x|_p = 1  ∀x ∈ ℚ*",
                ExprTexto = "|x|∞·∏ₚ|x|ₚ = 1 ∀x∈ℚ*",
                Icone = "∏",
                Descricao = "Fórmula do produto: as valorações 'cobrem' toda a informação aritmética. Todos os valores absolutos de ℚ são |·|∞ e |·|ₚ (Ostrowski). Adèles unifiam todos.",
                Criador = "Alexander Ostrowski",
                AnoOrigin = "1916",
            },
            new Formula
            {
                Id = "4_pa07", Nome = "Lema de Hensel", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "f(a)≡0 mod p, f'(a)≢0 mod p ⟹ ∃!x∈ℤₚ: f(x)=0",
                ExprTexto = "f(a)≡0(p), f'(a)≢0(p) ⟹ ∃!raiz em ℤₚ",
                Icone = "H",
                Descricao = "Análogo p-ádico do teorema da função implícita: raiz simples mod p levanta a raiz exata em ℤₚ. Newton p-ádico. Ferramenta essencial para solubilidade local.",
                Criador = "Kurt Hensel",
                AnoOrigin = "1897",
            },
            new Formula
            {
                Id = "4_pa08", Nome = "Função Zeta p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "ζₚ(s) interpola ζ(1-n) para inteiros n≥1 positivos",
                ExprTexto = "ζₚ(s): interpolação p-ádica de ζ(1−n)",
                Icone = "ζₚ",
                Descricao = "Função L p-ádica de Kubota-Leopoldt: interpola continuamente (p-adicamente) os valores ζ(-n) = -Bₙ₊₁/(n+1) (números de Bernoulli). Conexão com teoria de Iwasawa.",
                Criador = "Tomio Kubota / Heinrich-Wolfgang Leopoldt",
                AnoOrigin = "1964",
            },
        ]);
    }
}
