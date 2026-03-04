using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 5 — PARTE I: MATEMÁTICA PURA (Seções 1-5)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 1. TEORIA DE LIE E REPRESENTAÇÕES
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaDeLie()
    {
        _formulas.AddRange([
            // 1.1 Álgebras de Lie Semissimples
            new Formula
            {
                Id = "5_li01", Nome = "Álgebra de Lie g", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "[x,y] = -[y,x];  [[x,y],z]+[[y,z],x]+[[z,x],y] = 0",
                ExprTexto = "[x,y]=-[y,x]; identidade de Jacobi",
                Icone = "𝔤",
                Descricao = "Álgebra de Lie: espaço vetorial com colchete bilinear antissimétrico satisfazendo a identidade de Jacobi. Base da teoria de grupos contínuos.",
                Criador = "Sophus Lie",
                AnoOrigin = "1888",
            },
            new Formula
            {
                Id = "5_li02", Nome = "Forma de Killing", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "B(x,y) = tr(ad(x)·ad(y))",
                ExprTexto = "B(x,y) = tr(ad(x)·ad(y))",
                Icone = "B",
                Descricao = "Forma bilinear simétrica associada a uma álgebra de Lie. ad(x): representação adjunta, y↦[x,y]. Fundamental para classificação.",
                Criador = "Wilhelm Killing",
                AnoOrigin = "1888",
            },
            new Formula
            {
                Id = "5_li03", Nome = "Critério de Cartan", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "g semissimples ↔ B não-degenerada",
                ExprTexto = "g semissimples ⟺ det(B) ≠ 0",
                Icone = "SS",
                Descricao = "Uma álgebra de Lie é semissimples se e somente se sua forma de Killing é não-degenerada. Critério essencial para classificação.",
                Criador = "Élie Cartan",
                AnoOrigin = "1894",
            },
            new Formula
            {
                Id = "5_li04", Nome = "Subálgebra de Cartan", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "h ⊂ g abeliana maximal;  h = span{H₁,...,Hᵣ}",
                ExprTexto = "h = subálgebra abeliana maximal; r = rank(g)",
                Icone = "h",
                Descricao = "Subálgebra de Cartan: subespaço abeliano maximal formado por elementos semissimples. Seu rank r determina a dimensão do sistema de raízes.",
                Criador = "Élie Cartan",
            },
            new Formula
            {
                Id = "5_li05", Nome = "Decomposição de Raízes", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "g = h ⊕ ⊕_α gα;  [H,Xα] = α(H)Xα",
                ExprTexto = "g = h ⊕ ⊕_α gα; [H,Xα]=α(H)Xα",
                Icone = "Φ",
                Descricao = "Decomposição em espaços de peso (raízes): g se decompõe em subálgebra de Cartan h mais espaços-raiz gα. Cada raiz α é um funcional linear em h.",
            },
            new Formula
            {
                Id = "5_li06", Nome = "Sistema de Raízes Φ", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "α∈Φ → -α∈Φ;  ⟨α,β⟩ = 2(α,β)/(α,α) ∈ ℤ",
                ExprTexto = "⟨α,β⟩ = 2(α,β)/(α,α) ∈ ℤ",
                Icone = "Φ",
                Descricao = "Sistema de raízes: conjunto finito em espaço euclidiano satisfazendo axiomas de simetria e inteireza. Classifica álgebras de Lie semissimples.",
            },
            new Formula
            {
                Id = "5_li07", Nome = "Raízes Simples", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "Δ = {α₁,...,αᵣ};  r = rank(g)",
                ExprTexto = "Δ = {α₁,...,αᵣ}; r = rank",
                Icone = "Δ",
                Descricao = "Raízes simples: subconjunto minimal de raízes positivas que gera todo o sistema. Número de raízes simples = rank da álgebra.",
            },
            new Formula
            {
                Id = "5_li08", Nome = "Matriz de Cartan", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "Aᵢⱼ = ⟨αᵢ,αⱼ⟩ = 2(αᵢ,αⱼ)/(αⱼ,αⱼ)",
                ExprTexto = "Aᵢⱼ = 2(αᵢ,αⱼ)/(αⱼ,αⱼ)",
                Icone = "A",
                Descricao = "Matriz de Cartan: codifica toda a informação do sistema de raízes. Aᵢᵢ=2; Aᵢⱼ∈{0,-1,-2,-3} para i≠j. Determina a álgebra unicamente.",
                Criador = "Élie Cartan",
            },
            new Formula
            {
                Id = "5_li09", Nome = "Diagrama de Dynkin", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "Clássicos: Aₙ,Bₙ,Cₙ,Dₙ;  Excepcionais: G₂,F₄,E₆,E₇,E₈",
                ExprTexto = "Tipos: Aₙ Bₙ Cₙ Dₙ G₂ F₄ E₆ E₇ E₈",
                Icone = "D",
                Descricao = "Diagramas de Dynkin classificam todas as álgebras de Lie semissimples simples complexas. 4 séries infinitas (clássicas) + 5 excepcionais.",
                Criador = "Eugene Dynkin",
                AnoOrigin = "1947",
            },
            new Formula
            {
                Id = "5_li10", Nome = "sl(2,ℂ) — Protótipo", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "[H,E]=2E;  [H,F]=-2F;  [E,F]=H",
                ExprTexto = "[H,E]=2E; [H,F]=-2F; [E,F]=H",
                Icone = "sl₂",
                Descricao = "Álgebra de Lie mais simples não-abeliana: sl(2,ℂ). Protótipo para toda a teoria. Representações irredutíveis classificadas por peso máximo inteiro ≥0.",
            },
            new Formula
            {
                Id = "5_li11", Nome = "Grupo de Weyl", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "W: reflexões sα(λ) = λ - ⟨λ,α⟩α",
                ExprTexto = "sα(λ) = λ - ⟨λ,α⟩α",
                Icone = "W",
                Descricao = "Grupo de Weyl: grupo finito gerado por reflexões nas raízes. Simetria fundamental do sistema de raízes. Grupo de simetria do diagrama de Dynkin.",
                Criador = "Hermann Weyl",
            },
            new Formula
            {
                Id = "5_li12", Nome = "Fórmula de Dimensão de Weyl", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "dim V(λ) = Π_{α>0} ⟨λ+ρ,α⟩/⟨ρ,α⟩;  ρ = ½Σ_{α>0} α",
                ExprTexto = "dim V(λ) = Π(⟨λ+ρ,α⟩/⟨ρ,α⟩)",
                Icone = "dim",
                Descricao = "Fórmula de Weyl para a dimensão da representação irredutível de peso máximo λ. ρ é a semi-soma das raízes positivas (vetor de Weyl).",
                Criador = "Hermann Weyl",
                AnoOrigin = "1925",
            },

            // 1.2 Teoria das Representações
            new Formula
            {
                Id = "5_tr01", Nome = "Representação de Grupo", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "ρ: G → GL(V);  ρ(gh) = ρ(g)ρ(h)",
                ExprTexto = "ρ: G→GL(V); ρ(gh)=ρ(g)ρ(h)",
                Icone = "ρ",
                Descricao = "Representação: homomorfismo de grupo em operadores lineares invertíveis. Permite estudar grupos abstratos via álgebra linear.",
            },
            new Formula
            {
                Id = "5_tr02", Nome = "Caractere", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "χ_ρ(g) = tr(ρ(g))",
                ExprTexto = "χ_ρ(g) = tr(ρ(g))",
                Icone = "χ",
                Descricao = "Caractere de uma representação: traço da matriz. Invariante por conjugação, identifica representações de forma eficiente.",
            },
            new Formula
            {
                Id = "5_tr03", Nome = "Ortogonalidade de Caracteres", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "⟨χ_ρ,χ_σ⟩ = (1/|G|) Σ_g χ_ρ(g)χ_σ(g)* = δ_{ρσ}",
                ExprTexto = "⟨χ_ρ,χ_σ⟩ = δ_{ρσ}",
                Icone = "⊥",
                Descricao = "Relações de ortogonalidade: caracteres de representações irredutíveis distintas são ortogonais. Base do método de análise de Fourier em grupos finitos.",
            },
            new Formula
            {
                Id = "5_tr04", Nome = "Completude", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "Σᵢ (dim ρᵢ)² = |G|",
                ExprTexto = "Σ(dim ρᵢ)² = |G|",
                Icone = "Σ",
                Descricao = "Soma dos quadrados das dimensões das representações irredutíveis iguala a ordem do grupo finito. Restrição fundamental.",
            },
            new Formula
            {
                Id = "5_tr05", Nome = "Lema de Schur", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "Hom_G(V,W)=0 se V≇W irred.; = ℂ·Id se V≅W irred.",
                ExprTexto = "HomG(V,W)=0 (V≇W); =ℂ·Id (V≅W)",
                Icone = "S",
                Descricao = "Lema de Schur: um morfismo entre representações irredutíveis é zero ou isomorfismo. Sobre ℂ, endomorfismos são múltiplos da identidade.",
                Criador = "Issai Schur",
                AnoOrigin = "1905",
            },
            new Formula
            {
                Id = "5_tr06", Nome = "Decomposição em Irredutíveis", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "V = ⊕ᵢ mᵢVᵢ;  mᵢ = ⟨χ_V,χᵢ⟩",
                ExprTexto = "V = ⊕ mᵢVᵢ; mᵢ=⟨χV,χᵢ⟩",
                Icone = "⊕",
                Descricao = "Toda representação se decompõe em irredutíveis (Maschke). Multiplicidade mᵢ calculada pelo produto interno de caracteres.",
            },
            new Formula
            {
                Id = "5_tr07", Nome = "Reciprocidade de Frobenius", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "⟨Ind_H↑G ρ, σ⟩_G = ⟨ρ, Res_H↓G σ⟩_H",
                ExprTexto = "⟨Ind↑ρ,σ⟩G = ⟨ρ,Res↓σ⟩H",
                Icone = "↑↓",
                Descricao = "Reciprocidade de Frobenius: indução e restrição são adjuntos. Fundamental para construir representações de grupos grandes a partir de subgrupos.",
                Criador = "Ferdinand Georg Frobenius",
                AnoOrigin = "1898",
            },
            new Formula
            {
                Id = "5_tr08", Nome = "Teorema de Peter-Weyl", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "L²(G) = ⊕̂ᵢ Vᵢ ⊗ V*ᵢ   (G compacto)",
                ExprTexto = "L²(G) = ⊕̂ Vᵢ⊗V*ᵢ",
                Icone = "L²",
                Descricao = "Para G compacto, L²(G) se decompõe como soma direta de Vᵢ⊗V*ᵢ sobre todas as representações irredutíveis. Generaliza séries de Fourier.",
                Criador = "Fritz Peter / Hermann Weyl",
                AnoOrigin = "1927",
            },
            new Formula
            {
                Id = "5_tr09", Nome = "Fourier Não-Comutativo", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "f̂(ρ) = ∫_G f(g)ρ(g) dg   (G compacto)",
                ExprTexto = "f̂(ρ) = ∫G f(g)ρ(g)dg",
                Icone = "f̂",
                Descricao = "Transformada de Fourier em grupo compacto não-abeliano: para cada representação irredutível ρ, f̂(ρ) é uma matriz. Generaliza Fourier clássica.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 2. TEORIA DOS NÚMEROS ALGÉBRICOS
    // ─────────────────────────────────────────────────────
    private void AdicionarNumerosAlgebricos()
    {
        _formulas.AddRange([
            // 2.1 Anéis de Inteiros e Ideais
            new Formula
            {
                Id = "5_na01", Nome = "Extensão K/ℚ e Anel de Inteiros", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "K/ℚ de grau n;  O_K = anel de inteiros de K",
                ExprTexto = "[K:ℚ] = n; O_K = inteiros algébricos em K",
                Icone = "O_K",
                Descricao = "Extensão de corpos de grau n sobre ℚ. O anel de inteiros O_K generaliza ℤ: elementos de K que são raízes de polinômios mônicos em ℤ[x].",
            },
            new Formula
            {
                Id = "5_na02", Nome = "Discriminante", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "disc(K) = det([tr(eᵢeⱼ)])",
                ExprTexto = "disc(K) = det(tr(eᵢeⱼ))",
                Icone = "Δ",
                Descricao = "Discriminante do corpo: determinante da matriz de traços sobre uma base de O_K. Mede a 'complexidade' aritmética. Primo p ramifica se p | disc.",
            },
            new Formula
            {
                Id = "5_na03", Nome = "Fatoração Única de Ideais", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "aO_K = Π pᵢ^{eᵢ}   (fatoração única em ideais primos)",
                ExprTexto = "aO_K = Π pᵢ^eᵢ (única)",
                Icone = "Π",
                Descricao = "Em O_K, todo ideal não-nulo se fatora unicamente como produto de ideais primos (teorema de Dedekind). Generaliza fatoração única em ℤ.",
                Criador = "Richard Dedekind",
                AnoOrigin = "1871",
            },
            new Formula
            {
                Id = "5_na04", Nome = "Relação efg = n", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "Σ eᵢfᵢ = n;  e=ramificação, f=grau residual",
                ExprTexto = "Σ eᵢfᵢ = [K:ℚ]",
                Icone = "efg",
                Descricao = "Para p primo racional: pO_K = Π pᵢ^eᵢ; fᵢ=[O_K/pᵢ:𝔽_p]. A soma efg=n particiona o grau da extensão.",
            },
            new Formula
            {
                Id = "5_na05", Nome = "Grupo de Classes", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "Cl(K) = I_K / P_K;  h_K = |Cl(K)|",
                ExprTexto = "Cl(K)=I_K/P_K; h_K=|Cl(K)|",
                Icone = "Cl",
                Descricao = "Grupo de classes: ideais fracionários módulo ideais principais. h_K mede a falha da fatoração única em elementos. h_K=1 ⟺ O_K é DFU.",
            },
            new Formula
            {
                Id = "5_na06", Nome = "Cota de Minkowski", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "|disc(K)|^{1/2} ≥ (π/4)^{r₂} · nⁿ/n!",
                ExprTexto = "√|disc| ≥ (π/4)^r₂ · nⁿ/n!",
                Icone = "M",
                Descricao = "Cota de Minkowski para o discriminante. r₂ = pares complexos de mergulhos. Implica que todo ideal não-trivial tem norma limitada.",
                Criador = "Hermann Minkowski",
            },
            new Formula
            {
                Id = "5_na07", Nome = "Teorema de Unidades de Dirichlet", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "O*_K ≅ μ(K) × ℤ^{r₁+r₂-1}",
                ExprTexto = "O*_K ≅ μ(K) × ℤ^(r₁+r₂-1)",
                Icone = "U",
                Descricao = "Grupo de unidades: parte de torção (raízes da unidade) × parte livre de rank r₁+r₂-1. r₁=mergulhos reais, r₂=pares complexos.",
                Criador = "Peter Gustav Lejeune Dirichlet",
                AnoOrigin = "1846",
            },
            new Formula
            {
                Id = "5_na08", Nome = "Norma de Corpo", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "N_{K/ℚ}(α) = Π_σ σ(α)",
                ExprTexto = "N(α) = Π σ(α)",
                Icone = "N",
                Descricao = "Norma: produto sobre todos os mergulhos σ:K→ℂ. Multiplicativa: N(αβ)=N(α)N(β). N(α)∈ℤ para α∈O_K.",
            },
            new Formula
            {
                Id = "5_na09", Nome = "Traço de Corpo", Categoria = "Números Algébricos", SubCategoria = "Anéis de Inteiros e Ideais",
                Expressao = "tr_{K/ℚ}(α) = Σ_σ σ(α)",
                ExprTexto = "tr(α) = Σ σ(α)",
                Icone = "tr",
                Descricao = "Traço: soma sobre todos os mergulhos. Aditivo: tr(α+β)=tr(α)+tr(β). Usado para definir a forma de Killing e o discriminante.",
            },

            // 2.2 Reciprocidade e Cohomologia
            new Formula
            {
                Id = "5_na10", Nome = "Reciprocidade Quadrática", Categoria = "Números Algébricos", SubCategoria = "Reciprocidade e Cohomologia",
                Expressao = "(p/q)(q/p) = (-1)^{(p-1)(q-1)/4}",
                ExprTexto = "(p/q)(q/p)=(-1)^((p-1)(q-1)/4)",
                Icone = "R",
                Descricao = "Lei de reciprocidade quadrática de Gauss-Legendre: relaciona solubilidade de x²≡p mod q com x²≡q mod p. 'Theorema aureum'.",
                Criador = "Carl Friedrich Gauss",
                AnoOrigin = "1801",
            },
            new Formula
            {
                Id = "5_na11", Nome = "Símbolo de Legendre", Categoria = "Números Algébricos", SubCategoria = "Reciprocidade e Cohomologia",
                Expressao = "(a/p) = a^{(p-1)/2} mod p ∈ {±1}",
                ExprTexto = "(a/p) = a^((p-1)/2) mod p",
                Icone = "L",
                Descricao = "Símbolo de Legendre: (a/p)=1 se a é resíduo quadrático mod p, -1 caso contrário, 0 se p|a. Critério de Euler.",
                Criador = "Adrien-Marie Legendre",
            },
            new Formula
            {
                Id = "5_na12", Nome = "Símbolo de Jacobi", Categoria = "Números Algébricos", SubCategoria = "Reciprocidade e Cohomologia",
                Expressao = "(a/n) = Π (a/pᵢ)^{eᵢ};  n = Π pᵢ^{eᵢ}",
                ExprTexto = "(a/n) = Π(a/pᵢ)^eᵢ",
                Icone = "J",
                Descricao = "Generalização do símbolo de Legendre para módulos compostos. Multiplicativo mas (a/n)=1 não garante residuosidade quadrática.",
                Criador = "Carl Gustav Jacob Jacobi",
            },
            new Formula
            {
                Id = "5_na13", Nome = "Reciprocidade de Artin", Categoria = "Números Algébricos", SubCategoria = "Reciprocidade e Cohomologia",
                Expressao = "Gal(L/K)^{ab} ≅ K*/N_{L/K}(L*)",
                ExprTexto = "Gal(L/K)^ab ≅ K*/N(L*)",
                Icone = "Art",
                Descricao = "Lei de reciprocidade de Artin: isomorfismo entre grupo de Galois abelianizado e quociente de ideles. Coração da teoria de corpo de classes.",
                Criador = "Emil Artin",
                AnoOrigin = "1927",
            },
            new Formula
            {
                Id = "5_na14", Nome = "Mapa de Artin (Frobenius)", Categoria = "Números Algébricos", SubCategoria = "Reciprocidade e Cohomologia",
                Expressao = "p → Frob_p ∈ Gal(L/K);  Frob_p(x) = x^{Np} mod p",
                ExprTexto = "Frobp(x) = x^(Np) mod p",
                Icone = "Fr",
                Descricao = "Mapa de Artin associa a cada primo não-ramificado p o automorfismo de Frobenius. Conecta aritmética local com simetrias globais.",
            },
            new Formula
            {
                Id = "5_na15", Nome = "Cohomologia de Galois", Categoria = "Números Algébricos", SubCategoria = "Reciprocidade e Cohomologia",
                Expressao = "H¹(Gal(K̄/K), A);  sequências exatas de Galois",
                ExprTexto = "H¹(Gal(K̄/K), A)",
                Icone = "H¹",
                Descricao = "Cohomologia de Galois: ferramenta algébrica para estudar extensões, torcidos e obstruções. H¹ classifica torcidos, H² classifica extensões de grupos.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 3. GEOMETRIA RIEMANNIANA AVANÇADA E TEORIA DE HODGE
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaRiemanniana()
    {
        _formulas.AddRange([
            // 3.1 Geometria Riemanniana
            new Formula
            {
                Id = "5_gr01", Nome = "Curvatura Seccional", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "K(σ) = R(X,Y,Y,X) / (‖X‖²‖Y‖² - ⟨X,Y⟩²)",
                ExprTexto = "K(σ) = R(X,Y,Y,X)/(|X|²|Y|²-⟨X,Y⟩²)",
                Icone = "K",
                Descricao = "Curvatura seccional: curvatura intrínseca de um plano σ tangente gerado por X,Y. Generaliza curvatura gaussiana de superfícies.",
                Criador = "Bernhard Riemann",
                AnoOrigin = "1854",
            },
            new Formula
            {
                Id = "5_gr02", Nome = "Curvatura de Ricci", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "Ric(X,X) = Σᵢ K(X,eᵢ)",
                ExprTexto = "Ric(X,X) = Σ K(X,eᵢ)",
                Icone = "Ric",
                Descricao = "Curvatura de Ricci: média de curvaturas seccionais em planos contendo X. Tensor simétrico (0,2). Aparece nas equações de Einstein.",
                Criador = "Gregorio Ricci-Curbastro",
            },
            new Formula
            {
                Id = "5_gr03", Nome = "Curvatura Escalar", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "R = tr(Ric) = Σᵢ,ⱼ K(eᵢ,eⱼ)",
                ExprTexto = "R = tr(Ric)",
                Icone = "R",
                Descricao = "Curvatura escalar: traço da curvatura de Ricci. Escalar que resume toda a curvatura em um ponto. Aparece na ação de Einstein-Hilbert.",
            },
            new Formula
            {
                Id = "5_gr04", Nome = "Equação de Jacobi", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "D²J/dt² + R(J,γ')γ' = 0",
                ExprTexto = "D²J/dt² + R(J,γ')γ'=0",
                Icone = "J",
                Descricao = "Campos de Jacobi: variações geodésicas satisfazem esta EDO. Medem como geodésicas vizinhas convergem (K>0) ou divergem (K<0).",
            },
            new Formula
            {
                Id = "5_gr05", Nome = "Teorema de Bonnet-Myers", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "Ric ≥ (n-1)κ > 0  →  diam ≤ π/√κ,  π₁ finito",
                ExprTexto = "Ric≥(n-1)κ>0 ⟹ diam≤π/√κ",
                Icone = "BM",
                Descricao = "Se Ricci é limitada inferiormente por constante positiva, a variedade é compacta com diâmetro limitado e grupo fundamental finito.",
                Criador = "Ossian Bonnet / Sumner B. Myers",
            },
            new Formula
            {
                Id = "5_gr06", Nome = "Comparação de Bishop", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "vol(B_r(p)) ≤ vol_κ(B_r)   (se Ric ≥ (n-1)κ)",
                ExprTexto = "vol(Br) ≤ volκ(Br) se Ric≥(n-1)κ",
                Icone = "V",
                Descricao = "Comparação de volumes de Bishop-Gromov: bolas em variedade com Ricci limitada inferiormente têm volume ≤ ao modelo de curvatura constante.",
            },
            new Formula
            {
                Id = "5_gr07", Nome = "Teorema de Hadamard-Cartan", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "K ≤ 0  →  exp_p: T_pM → M é difeomorfismo",
                ExprTexto = "K≤0 ⟹ exp_p difeomorfismo",
                Icone = "HC",
                Descricao = "Se curvatura seccional ≤ 0 e M completa simplesmente conexa, a exponencial é difeomorfismo global. M é difeomorfa a ℝⁿ.",
                Criador = "Jacques Hadamard / Élie Cartan",
            },
            new Formula
            {
                Id = "5_gr08", Nome = "Tensor de Weyl", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "Cᵢⱼₖₗ = Rᵢⱼₖₗ - componentes Ricci − R/(n(n-1))·g∧g",
                ExprTexto = "C = R - Ric componentes - Rg∧g/(n(n-1))",
                Icone = "C",
                Descricao = "Tensor de Weyl: parte conformalmente invariante da curvatura. C=0 ⟺ conformalmente plana (em dim≥4). Invariante conforme fundamental.",
                Criador = "Hermann Weyl",
            },
            new Formula
            {
                Id = "5_gr09", Nome = "Variedade Einstein", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "Ric = λg",
                ExprTexto = "Ric = λg",
                Icone = "E",
                Descricao = "Variedade Einstein: curvatura de Ricci proporcional à métrica. Generalização de espaços de curvatura constante. Solução das equações de Einstein no vácuo.",
            },
            new Formula
            {
                Id = "5_gr10", Nome = "Fluxo de Ricci", Categoria = "Geometria Riemanniana", SubCategoria = "Geometria Riemanniana",
                Expressao = "∂gᵢⱼ/∂t = -2Rᵢⱼ",
                ExprTexto = "∂g/∂t = -2Ric",
                Icone = "RF",
                Descricao = "Fluxo de Ricci: EDP parabólica que deforma a métrica na direção oposta à curvatura de Ricci. Usado por Perelman para provar a conjectura de Poincaré.",
                Criador = "Richard Hamilton / Grigori Perelman",
                AnoOrigin = "1982",
            },

            // 3.2 Teoria de Hodge
            new Formula
            {
                Id = "5_th01", Nome = "Operador Estrela de Hodge", Categoria = "Geometria Riemanniana", SubCategoria = "Teoria de Hodge",
                Expressao = "*: Ωᵏ(M) → Ωⁿ⁻ᵏ(M);  *² = (-1)^{k(n-k)}",
                ExprTexto = "*: Ωᵏ→Ωⁿ⁻ᵏ; *²=(-1)^(k(n-k))",
                Icone = "⋆",
                Descricao = "Operador estrela de Hodge: isomorfismo entre k-formas e (n-k)-formas usando a métrica e orientação. Fundamental para eletromagnetismo e análise.",
                Criador = "W.V.D. Hodge",
            },
            new Formula
            {
                Id = "5_th02", Nome = "Coderivada δ", Categoria = "Geometria Riemanniana", SubCategoria = "Teoria de Hodge",
                Expressao = "δ = (-1)^{n(k+1)+1} *d*;  δ: Ωᵏ → Ωᵏ⁻¹",
                ExprTexto = "δ = (-1)^(n(k+1)+1) *d*",
                Icone = "δ",
                Descricao = "Coderivada: adjunta formal de d em relação ao produto L². Diminui o grau da forma. Divergência generalizada.",
            },
            new Formula
            {
                Id = "5_th03", Nome = "Laplaciano de Hodge", Categoria = "Geometria Riemanniana", SubCategoria = "Teoria de Hodge",
                Expressao = "Δ = dδ + δd;  harmônica se Δω = 0",
                ExprTexto = "Δ = dδ+δd; Δω=0 harmônica",
                Icone = "Δ",
                Descricao = "Laplaciano de Hodge generaliza o laplaciano usual. Formas harmônicas: Δω=0 ⟺ dω=0 e δω=0 (fechada e co-fechada).",
            },
            new Formula
            {
                Id = "5_th04", Nome = "Decomposição de Hodge", Categoria = "Geometria Riemanniana", SubCategoria = "Teoria de Hodge",
                Expressao = "Ωᵏ = ℋᵏ ⊕ d(Ωᵏ⁻¹) ⊕ δ(Ωᵏ⁺¹)",
                ExprTexto = "Ωᵏ = Hᵏ ⊕ dΩ ⊕ δΩ",
                Icone = "⊕",
                Descricao = "Decomposição ortogonal de Hodge: toda k-forma se decompõe unicamente em harmônica + exata + co-exata. Análogo de Fourier em variedades.",
                Criador = "W.V.D. Hodge",
                AnoOrigin = "1941",
            },
            new Formula
            {
                Id = "5_th05", Nome = "Isomorfismo de Hodge", Categoria = "Geometria Riemanniana", SubCategoria = "Teoria de Hodge",
                Expressao = "ℋᵏ ≅ H^k_{dR}(M)",
                ExprTexto = "Hᵏ_harm ≅ Hᵏ_dR(M)",
                Icone = "≅",
                Descricao = "Formas harmônicas representam classes de cohomologia de de Rham. Conecta análise (EDP) com topologia (cohomologia).",
            },
            new Formula
            {
                Id = "5_th06", Nome = "Identidades de Kähler", Categoria = "Geometria Riemanniana", SubCategoria = "Teoria de Hodge",
                Expressao = "Δ = 2Δ_∂̄ = 2Δ_∂   (variedade de Kähler)",
                ExprTexto = "Δ = 2Δ∂̄ = 2Δ∂ (Kähler)",
                Icone = "K",
                Descricao = "Em variedades de Kähler, o laplaciano d se relaciona com os laplacianos ∂ e ∂̄. Implica decomposição de Hodge em tipos (p,q).",
            },
            new Formula
            {
                Id = "5_th07", Nome = "∂∂̄-Lema", Categoria = "Geometria Riemanniana", SubCategoria = "Teoria de Hodge",
                Expressao = "Em Kähler: d-fechada e d-exata ⟺ ∂∂̄-exata",
                ExprTexto = "d-fechada ∧ d-exata ⟺ ∂∂̄-exata",
                Icone = "∂∂̄",
                Descricao = "O ∂∂̄-lema é válido em variedades de Kähler compactas. Formas que são simultâneamente d-fechadas e d-exatas podem ser escritas como ∂∂̄ de algo.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 4. ANÁLISE HARMÔNICA EM GRUPOS LOCALMENTE COMPACTOS
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseHarmonica()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_ah01", Nome = "Medida de Haar", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "μ: medida esquerda-invariante em G localmente compacto",
                ExprTexto = "μ(gA) = μ(A) ∀g∈G, A Borel",
                Icone = "μ",
                Descricao = "Medida de Haar: única medida regular (a menos de escalar) invariante por translações à esquerda. Existe para todo grupo localmente compacto.",
                Criador = "Alfréd Haar",
                AnoOrigin = "1933",
            },
            new Formula
            {
                Id = "5_ah02", Nome = "Unicidade da Medida de Haar", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "μ e μ' Haar ⟹ μ' = c·μ  (c > 0)",
                ExprTexto = "μ' = cμ para c>0",
                Icone = "c",
                Descricao = "A medida de Haar é única a menos de multiplicação por constante positiva. Fundamental para análise harmônica abstrata.",
            },
            new Formula
            {
                Id = "5_ah03", Nome = "Função Modular", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "Δ(g) = dμ_right/dμ_left;  G unimodular se Δ ≡ 1",
                ExprTexto = "Δ(g) = dμR/dμL; unimodular se Δ≡1",
                Icone = "Δ",
                Descricao = "Função modular mede a diferença entre medidas de Haar esquerda e direita. Grupos compactos, abelianos e semissimples são unimodulares.",
            },
            new Formula
            {
                Id = "5_ah04", Nome = "Convolução em Grupo", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "(f∗g)(x) = ∫_G f(y)g(y⁻¹x) dμ(y)",
                ExprTexto = "(f*g)(x) = ∫ f(y)g(y⁻¹x)dμ(y)",
                Icone = "∗",
                Descricao = "Convolução em grupo localmente compacto usando a medida de Haar. L¹(G) com convolução forma uma álgebra de Banach.",
            },
            new Formula
            {
                Id = "5_ah05", Nome = "Transformada de Fourier (G abeliano)", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "f̂(χ) = ∫_G f(g)χ̄(g) dg;  χ ∈ Ĝ",
                ExprTexto = "f̂(χ) = ∫G f(g)χ̄(g)dg",
                Icone = "f̂",
                Descricao = "Transformada de Fourier em grupo abeliano localmente compacto. χ são caracteres (homomorfismos G→S¹). Ĝ é o grupo dual.",
            },
            new Formula
            {
                Id = "5_ah06", Nome = "Fórmula de Inversão", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "f(g) = ∫_Ĝ f̂(χ)χ(g) dμ̂(χ)",
                ExprTexto = "f(g) = ∫Ĝ f̂(χ)χ(g)dμ̂(χ)",
                Icone = "f⁻",
                Descricao = "Fórmula de inversão de Fourier em grupo localmente compacto abeliano. Recupera f a partir de f̂ usando a medida de Haar no dual.",
            },
            new Formula
            {
                Id = "5_ah07", Nome = "Identidade de Parseval", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "∫_G |f|² dμ = ∫_Ĝ |f̂|² dμ̂",
                ExprTexto = "∫|f|²dμ = ∫|f̂|²dμ̂",
                Icone = "‖‖",
                Descricao = "Identidade de Parseval: a transformada de Fourier preserva a norma L². Isometria entre L²(G) e L²(Ĝ).",
            },
            new Formula
            {
                Id = "5_ah08", Nome = "Dualidade de Pontryagin", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "G abeliano localmente compacto ⟹ (Ĝ)^ ≅ G",
                ExprTexto = "(Ĝ)^ ≅ G naturalmente",
                Icone = "^^",
                Descricao = "Dualidade de Pontryagin: o bidual é canonicamente isomorfo ao grupo original. Simetria perfeita entre G e Ĝ.",
                Criador = "Lev Pontryagin",
                AnoOrigin = "1934",
            },
            new Formula
            {
                Id = "5_ah09", Nome = "Convolução-Produto", Categoria = "Análise Harmônica", SubCategoria = "Medida de Haar e Transformada",
                Expressao = "(f∗g)^ = f̂ · ĝ",
                ExprTexto = "(f*g)^ = f̂·ĝ",
                Icone = "∗→·",
                Descricao = "A transformada de Fourier converte convolução em multiplicação pontual. Princípio fundamental que simplifica equações de convolução.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 5. GEOMETRIA NÃO-COMUTATIVA E C*-ÁLGEBRAS
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaNaoComutativa()
    {
        _formulas.AddRange([
            // 5.1 C*-Álgebras
            new Formula
            {
                Id = "5_ca01", Nome = "C*-Álgebra", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras",
                Expressao = "A: álgebra de Banach com *-involução;  ‖a*a‖ = ‖a‖²",
                ExprTexto = "‖a*a‖ = ‖a‖² (identidade C*)",
                Icone = "C*",
                Descricao = "C*-álgebra: álgebra de Banach com involução satisfazendo a identidade C*. Modelo algébrico para observáveis em mecânica quântica.",
            },
            new Formula
            {
                Id = "5_ca02", Nome = "Exemplos de C*-Álgebras", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras",
                Expressao = "B(H) operadores;  C(X) funções;  Mₙ(ℂ) matrizes",
                ExprTexto = "B(H), C(X), Mₙ(ℂ)",
                Icone = "ex",
                Descricao = "Exemplos fundamentais: B(H) operadores limitados em Hilbert (não-comutativa), C(X) funções contínuas (comutativa), Mₙ(ℂ) matrizes n×n.",
            },
            new Formula
            {
                Id = "5_ca03", Nome = "Espectro e Raio Espectral", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras",
                Expressao = "σ(a) = {λ: a-λ1 não invertível};  ‖a‖ = √(spr(a*a))",
                ExprTexto = "σ(a)={λ: a-λ1 ∉ inv}; ‖a‖=√spr(a*a)",
                Icone = "σ",
                Descricao = "Espectro de um elemento: conjunto de escalares onde a-λ não é invertível. Na C*-álgebra, norma é determinada pelo raio espectral.",
            },
            new Formula
            {
                Id = "5_ca04", Nome = "Teorema de Gelfand", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras",
                Expressao = "C*-álgebra comutativa ≅ C₀(X);  X = espaço de Gelfand",
                ExprTexto = "A comut. ≅ C₀(X)",
                Icone = "G",
                Descricao = "Teorema de Gelfand-Naimark: toda C*-álgebra comutativa é isomorfa a C₀(X) para espaço localmente compacto X. Dualidade álgebra ↔ topologia.",
                Criador = "Israel Gelfand / Mark Naimark",
                AnoOrigin = "1943",
            },
            new Formula
            {
                Id = "5_ca05", Nome = "Representação GNS", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras",
                Expressao = "ω:A→ℂ estado → (π,H,Ω) com ω(a) = ⟨Ω,π(a)Ω⟩",
                ExprTexto = "ω(a)=⟨Ω,π(a)Ω⟩ (GNS)",
                Icone = "GNS",
                Descricao = "Construção GNS (Gelfand-Naimark-Segal): de um estado ω constrói-se representação em espaço de Hilbert. Toda C*-álgebra é concreta.",
            },
            new Formula
            {
                Id = "5_ca06", Nome = "Álgebra de von Neumann", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras",
                Expressao = "C*-álgebra fechada na topologia fraca em B(H)",
                ExprTexto = "M = M'' (bicomutante, von Neumann)",
                Icone = "vN",
                Descricao = "Álgebra de von Neumann: C*-subálgebra de B(H) fechada na topologia operador-fraco. Equivale à bicomutante M=M'' (teorema do bicomutante).",
                Criador = "John von Neumann",
            },
            new Formula
            {
                Id = "5_ca07", Nome = "Fatores Tipo I, II, III", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras",
                Expressao = "Classificação de von Neumann-Murray:  I, II₁, II∞, III",
                ExprTexto = "Fatores: I, II₁, II∞, III",
                Icone = "F",
                Descricao = "Classificação de fatores (álgebras de von Neumann com centro trivial). Tipo I: matrizes/B(H). Tipo II: traço finito/infinito. Tipo III: sem traço.",
                Criador = "F.J. Murray / J. von Neumann",
                AnoOrigin = "1936",
            },

            // 5.2 Produto de Moyal e Espaço Não-Comutativo
            new Formula
            {
                Id = "5_nc01", Nome = "Produto de Moyal (Star Product)", Categoria = "Geometria Não-Comutativa", SubCategoria = "Espaço Não-Comutativo",
                Expressao = "(f⋆g)(x) = f(x)·exp(iℏ/2 ←∂μ θ^{μν} ∂→_ν)·g(x)",
                ExprTexto = "(f⋆g) = f·exp(iℏ/2 ∂θ∂)·g",
                Icone = "⋆",
                Descricao = "Produto de Moyal: deformação do produto pontual de funções usando derivadas parciais. Quantização por deformação do espaço de fase.",
                Criador = "José Enrique Moyal",
                AnoOrigin = "1949",
            },
            new Formula
            {
                Id = "5_nc02", Nome = "Coordenadas Não-Comutativas", Categoria = "Geometria Não-Comutativa", SubCategoria = "Espaço Não-Comutativo",
                Expressao = "[x̂^μ, x̂^ν] = iθ^{μν}",
                ExprTexto = "[x̂μ, x̂ν] = iθμν",
                Icone = "[,]",
                Descricao = "Relações de comutação entre coordenadas do espaço não-comutativo. θ é uma matriz antissimétrica constante. Analogia com [x,p]=iℏ.",
            },
            new Formula
            {
                Id = "5_nc03", Nome = "Plano de Moyal", Categoria = "Geometria Não-Comutativa", SubCategoria = "Espaço Não-Comutativo",
                Expressao = "θ = [[0,θ],[-θ,0]];  relação de incerteza Δx¹Δx² ≥ θ/2",
                ExprTexto = "θ=[[0,θ],[-θ,0]]; ΔxΔy≥θ/2",
                Icone = "θ",
                Descricao = "Plano de Moyal: caso 2D com θ constante. Induz relação de incerteza generalizada entre coordenadas espaciais.",
            },
            new Formula
            {
                Id = "5_nc04", Nome = "Terna Espectral de Connes", Categoria = "Geometria Não-Comutativa", SubCategoria = "Espaço Não-Comutativo",
                Expressao = "(A, H, D);  A=álgebra, H=Hilbert, D=Dirac",
                ExprTexto = "Terna (A,H,D)",
                Icone = "D",
                Descricao = "Geometria espectral (Connes): substituir variedade por terna espectral (álgebra, espaço de Hilbert, operador de Dirac). Geometria sem pontos.",
                Criador = "Alain Connes",
                AnoOrigin = "1994",
            },
            new Formula
            {
                Id = "5_nc05", Nome = "Distância de Connes", Categoria = "Geometria Não-Comutativa", SubCategoria = "Espaço Não-Comutativo",
                Expressao = "d(p,q) = sup{|f(p)-f(q)| : ‖[D,f]‖ ≤ 1}",
                ExprTexto = "d(p,q)=sup{|f(p)-f(q)|: ‖[D,f]‖≤1}",
                Icone = "d",
                Descricao = "Distância de Connes: métrica recuperada da terna espectral usando o operador de Dirac. Generaliza distância geodésica para espaços não-comutativos.",
                Criador = "Alain Connes",
            },
        ]);
    }
}
