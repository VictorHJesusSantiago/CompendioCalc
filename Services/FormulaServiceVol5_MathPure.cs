using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 5 — PARTE I: MATEMÁTICA PURA — CAPÍTULOS FINAIS
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 1. TEORIA DE LIE E REPRESENTAÇÕES
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaLieRepresentacoes()
    {
        _formulas.AddRange([
            // 1.1 Álgebras de Lie Semissimples [LI1-LI12]
            new Formula
            {
                Id = "5_li01", Nome = "Identidade de Jacobi", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "[[x,y],z] + [[y,z],x] + [[z,x],y] = 0",
                ExprTexto = "[[x,y],z]+[[y,z],x]+[[z,x],y]=0",
                Icone = "[,]",
                Descricao = "Identidade fundamental de álgebras de Lie junto com anticomutatividade [x,y]=-[y,x]. Define a estrutura de Lie e garante que a representação adjunta é um homomorfismo de álgebras.",
                Criador = "Carl Gustav Jacob Jacobi / Sophus Lie",
                AnoOrigin = "1873",
                ExemploPratico = "Exemplo: Para sl(2), verificar Jacobi com matrizes H,E,F padrão onde [H,E]=2E. Usando valores escalares simplificados: x=1, y=2, z=3 → comutadores triplos somam aproximadamente 0.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Elemento x da álgebra", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "y", Nome = "Elemento y", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "z", Nome = "Elemento z", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Jacobi (≈0)",
                UnidadeResultado = "",
                Calcular = vars => {
                    var x = vars["x"]; var y = vars["y"]; var z = vars["z"];
                    var xy = x*y - y*x; var yz = y*z - z*y; var zx = z*x - x*z;
                    return Math.Abs((xy*z - z*xy) + (yz*x - x*yz) + (zx*y - y*zx));
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li02", Nome = "Forma de Killing", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "B(x,y) = tr(ad(x)·ad(y))",
                ExprTexto = "B(x,y) = tr(ad(x)ad(y))",
                Icone = "B",
                Descricao = "Forma bilinear simétrica invariante. ad(x) é o operador adjunto: ad(x)(y)=[x,y]. O traço da composição dá uma métrica na álgebra. Não-degenerada ↔ álgebra semissimples.",
                Criador = "Wilhelm Killing",
                AnoOrigin = "1888",
                ExemploPratico = "Exemplo: Para sl(n), B(H,H)=2n; para so(n), B(X,Y)=(n-2)tr(XY). Simplificado: ad(x)=2, ad(y)=3 → B≈6 (traço como produto).",
                Variaveis = [ new() { Simbolo = "adx", Nome = "ad(x) operador adjunto", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ady", Nome = "ad(y) operador adjunto", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "B(x,y)",
                UnidadeResultado = "",
                Calcular = vars => vars["adx"] * vars["ady"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li03", Nome = "Critério de Cartan", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "g semissimples ↔ B não-degenerada",
                ExprTexto = "g semissimples ⟺ det(B)≠0",
                Icone = "C",
                Descricao = "Caracterização de álgebras de Lie semissimples: equivalente a forma de Killing não-degenerada. Semissimples significa sem ideais abelianos não-triviais (radicais abelianos).",
                Criador = "Élie Cartan",
                AnoOrigin = "1894",
                ExemploPratico = "Exemplo: sl(n,ℂ) é semissimples (B não-degenerada); álgebra de Heisenberg NÃO é (B degenerada). Teste: det(B)=5≠0 → semissimples.",
                Variaveis = [ new() { Simbolo = "detB", Nome = "Determinante da forma de Killing", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Semissimples? (1=sim, 0=não)",
                UnidadeResultado = "",
                Calcular = vars => vars["detB"] != 0 ? 1.0 : 0.0,
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li04", Nome = "Subálgebra de Cartan", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "h ⊂ g: abeliana maximal;  h = span{H₁,...,Hᵣ}",
                ExprTexto = "h abeliana maximal; dim(h)=rank(g)",
                Icone = "h",
                Descricao = "Subálgebra de Cartan: subespaço abeliano ([H₁,H₂]=0) maximal formado por elementos semissimples. Sua dimensão r=rank(g) é fundamental para classificação.",
                Criador = "Élie Cartan",
                AnoOrigin = "1894",
                ExemploPratico = "Exemplo: sl(n) tem rank n-1 (matrizes diagonais de traço 0); so(2n) tem rank n (geradores de rotações). Para n=4 (sl(4)): rank=3.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n (para sl(n) ou outro tipo)", ValorPadrao = 4, ValorMin = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "rank(g) [para sl(n)]",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] - 1,
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li05", Nome = "Decomposição de Raízes", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "g = h ⊕ ⊕_α g_α;  [H,X_α] = α(H)X_α",
                ExprTexto = "g = h ⊕ Σ_α g_α; [H,X_α]=α(H)X_α",
                Icone = "⊕",
                Descricao = "Decomposição em espaços de peso: g split em subálgebra de Cartan h e espaços-raiz g_α (autoespaços de ad(h)). Cada raiz α:h→ℂ é funcional linear. Estrutura fundamental da teoria.",
                ExemploPratico = "Exemplo: sl(3) tem dim=8, rank=2 → h de dim 2, mais 6 espaços-raiz (α₁,α₂,-α₁,-α₂,α₁+α₂,-(α₁+α₂)). Total 2+6=8.",
                Variaveis = [ new() { Simbolo = "dimh", Nome = "dim(h) = rank", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "numRaizes", Nome = "Número de raízes (pares ±α)", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dim(g) = dim(h) + #raízes",
                UnidadeResultado = "",
                Calcular = vars => vars["dimh"] + vars["numRaizes"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li06", Nome = "Sistema de Raízes Φ", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "α∈Φ → -α∈Φ;  ⟨α,β⟩ = 2(α,β)/(α,α) ∈ ℤ",
                ExprTexto = "Φ fechado sob negação; ⟨α,β⟩ inteiro",
                Icone = "Φ",
                Descricao = "Sistema de raízes Φ em espaço euclidiano satisfaz: (1) fechado sob -α, (2) reflexão s_α preserva Φ, (3) ⟨α,β⟩ inteiro (produto de Cartan). Classifica álgebras semissimples.",
                ExemploPratico = "Exemplo: Para sl(3), raízes e₁-e₂, e₂-e₃, e₁-e₃ e opostas. Produto de Cartan: α=(e₁-e₂), β=(e₂-e₃) → ⟨α,β⟩=-1 (inteiro).",
                Variaveis = [ new() { Simbolo = "alpha", Nome = "Raiz α (norma ao quadrado)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "beta", Nome = "Raiz β (norma ao quadrado)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "alphaBeta", Nome = "(α,β) produto escalar", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "⟨α,β⟩",
                UnidadeResultado = "",
                Calcular = vars => Math.Round(2 * vars["alphaBeta"] / vars["alpha"]),
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },            new Formula
            {
                Id = "5_li07", Nome = "Raízes Simples Δ", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "Δ = {α₁,...,αᵣ};  r = rank(g)",
                ExprTexto = "Δ = base de raízes simples; |Δ|=rank",
                Icone = "Δ",
                Descricao = "Raízes simples: base minimal de raízes positivas. Toda raiz positiva é combinação não-negativa das simples. Número de raízes simples = rank. Determina completamente a álgebra.",
                ExemploPratico = "Exemplo: sl(3) tem rank=2, raízes simples α₁=e₁-e₂, α₂=e₂-e₃. Todas as outras raízes α₁+α₂, -α₁, -α₂, -(α₁+α₂) derivam destas.",
                Variaveis = [ new() { Simbolo = "r", Nome = "rank(g)", ValorPadrao = 2, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "|Δ| = rank",
                UnidadeResultado = "",
                Calcular = vars => vars["r"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li08", Nome = "Matriz de Cartan A", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "A_{ij} = ⟨α_i,α_j⟩ = 2(α_i,α_j)/(α_j,α_j)",
                ExprTexto = "A_{ij} = 2(α_i·α_j)/(α_j)²",
                Icone = "A",
                Descricao = "Matriz de Cartan codifica todo o sistema de raízes: A_{ii}=2, A_{ij}·A_{ji}∈{0,1,2,3} para i≠j. Determina a álgebra unicamente a menos de isomorfismo. Base para classificação via Dynkin.",
                Criador = "Élie Cartan",
                AnoOrigin = "1894",
                ExemploPratico = "Exemplo: sl(3) tipo A₂ tem A=[[2,-1],[-1,2]]. Calculando entrada: α₁·α₂=-1, α₂²=2 → A_{12}=2·(-1)/2=-1.",
                Variaveis = [ new() { Simbolo = "alphai", Nome = "α_i (componente)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "alphaj", Nome = "α_j", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "alphajSq", Nome = "(α_j,α_j)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "A_{ij}",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["alphai"] * vars["alphaj"] / vars["alphajSq"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li09", Nome = "Diagrama de Dynkin", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "Clássicos: A_n,B_n,C_n,D_n;  Excepcionais: G₂,F₄,E₆,E₇,E₈",
                ExprTexto = "4 séries infinitas + 5 excepcionais",
                Icone = "Dyn",
                Descricao = "Diagramas de Dynkin classificam completamente álgebras de Lie semissimples simples complexas. Séries clássicas: A_n=sl(n+1), B_n=so(2n+1), C_n=sp(2n), D_n=so(2n). Excepcionais: G₂,F₄,E₆,E₇,E₈ são únicos.",
                Criador = "Eugene Dynkin",
                AnoOrigin = "1947",
                ExemploPratico = "Exemplo: E₈ (maior excepcional) tem rank 8, dim=248. A₄≅sl(5) tem dim=24. Tipo 1(A₄): n=4 → dim=(4+1)²-1=24.",
                Variaveis = [ new() { Simbolo = "tipo", Nome = "Tipo (1=A,2=B,3=C,4=D,9=E₈)", ValorPadrao = 1, ValorMin = 1, ValorMax = 9, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 4, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dim(g)",
                UnidadeResultado = "",
                Calcular = vars => {
                    var tipo = (int)vars["tipo"]; var n = (int)vars["n"];
                    if (tipo == 1) return (n+1)*(n+1) - 1; // A_n = sl(n+1)
                    if (tipo == 2) return n*(2*n+1); // B_n = so(2n+1)
                    if (tipo == 3) return n*(2*n+1); // C_n = sp(2n)
                    if (tipo == 4) return n*(2*n-1); // D_n = so(2n)
                    if (tipo == 9) return 248; // E₈
                    return n * n;
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li10", Nome = "sl(2,ℂ) Protótipo", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "[H,E] = 2E;  [H,F] = -2F;  [E,F] = H",
                ExprTexto = "[H,E]=2E; [H,F]=-2F; [E,F]=H",
                Icone = "sl₂",
                Descricao = "sl(2,ℂ) é o protótipo fundamental: dim=3, base {H,E,F}. Toda álgebra de Lie semissimples contém múltiplas cópias de sl(2) (subalgebras sl₂). Representações irredutíveis rotuladas por spin j=0,½,1,3/2,...",
                ExemploPratico = "Exemplo: H=[[1,0],[0,-1]], E=[[0,1],[0,0]], F=[[0,0],[1,0]]. Comutador [H,E]=HE-EH=2E. Simplificado: H=1,E=0.5 → [H,E]=2·0.5=1.",
                Variaveis = [ new() { Simbolo = "H", Nome = "Elemento H (Cartan)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "E", Nome = "Elemento E (raising)", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "[H,E] = 2E",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["E"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li11", Nome = "Grupo de Weyl W", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "s_α: λ → λ - ⟨λ,α⟩α  (reflexão em raiz α)",
                ExprTexto = "s_α(λ) = λ - ⟨λ,α⟩α",
                Icone = "W",
                Descricao = "Grupo de Weyl W: gerado por reflexões s_α nas raízes simples. Age em espaço de pesos h* preservando sistema de raízes. Para sl(n): W≅S_n (simétrico); so(2n): W=(ℤ/2)^n⋊S_n.",
                Criador = "Hermann Weyl",
                AnoOrigin = "1925",
                ExemploPratico = "Exemplo: λ=5, ⟨λ,α⟩=2, α=3 → s_α(λ)=5-2·3=-1. Para sl(3): W≅S₃ com 6 elementos (permutações de 3 raízes).",
                Variaveis = [ new() { Simbolo = "lambda", Nome = "Peso λ", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "inner", Nome = "⟨λ,α⟩", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "alpha", Nome = "Raiz α", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "s_α(λ)",
                UnidadeResultado = "",
                Calcular = vars => vars["lambda"] - vars["inner"] * vars["alpha"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_li12", Nome = "Fórmula de Dimensão de Weyl", Categoria = "Teoria de Lie", SubCategoria = "Álgebras de Lie Semissimples",
                Expressao = "dim V(λ) = Π_{α>0} (⟨λ+ρ,α⟩ / ⟨ρ,α⟩);  ρ = ½Σ_{α>0} α",
                ExprTexto = "dim V(λ) = Π_α (⟨λ+ρ,α⟩/⟨ρ,α⟩); ρ=semissoma",
                Icone = "dim",
                Descricao = "Fórmula de Weyl para dimensão de representação irredutível de peso dominante λ. ρ=semissoma de raízes positivas =(1,1,...,1) em coordenadas simples. Fundamental para teoria de representações.",
                Criador = "Hermann Weyl",
                AnoOrigin = "1925",
                ExemploPratico = "Exemplo: sl(3) representação adjunta λ=(1,1), 3 raízes positivas. Com valores médios ⟨λ+ρ,α⟩=3, ⟨ρ,α⟩=1 → dim≈3³=27 (não exato, mas dim(ad sl(3))=8).",
                Variaveis = [ new() { Simbolo = "lambdaRho", Nome = "⟨λ+ρ,α⟩ médio", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rhoAlpha", Nome = "⟨ρ,α⟩ médio", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "nRaizes", Nome = "Número de raízes positivas", ValorPadrao = 3, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dim V(λ) (estimativa)",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["lambdaRho"] / vars["rhoAlpha"], vars["nRaizes"]),
                Unidades = "",
            },

            // 1.2 Teoria das Representações [TR1-TR9]
            new Formula
            {
                Id = "5_tr01", Nome = "Representação de Grupo ρ", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "ρ: G → GL(V);  ρ(gh) = ρ(g)ρ(h)",
                ExprTexto = "ρ: G→GL(V); ρ(gh)=ρ(g)ρ(h)",
                Icone = "ρ",
                Descricao = "Representação: homomorfismo de grupo G em operadores lineares GL(V) preservando estrutura. Permite estudar grupo abstrato via matrizes. Representação fiel se ker(ρ)={e}.",
                ExemploPratico = "Exemplo: G=ℤ/3ℤ={0,1,2}, V=ℂ³. ρ(1)=rotação 2π/3. Verificar: ρ(1+1)=ρ(2)=ρ(1)². Simplificado: ρ(g)=2, ρ(h)=3 → ρ(gh)≈6.",
                Variaveis = [ new() { Simbolo = "rhog", Nome = "ρ(g) (escalar repr.)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rhoh", Nome = "ρ(h)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "ρ(gh)",
                UnidadeResultado = "",
                Calcular = vars => vars["rhog"] * vars["rhoh"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr02", Nome = "Caractere χ", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "χ_ρ(g) = tr(ρ(g))",
                ExprTexto = "χ(g) = tr(ρ(g))",
                Icone = "χ",
                Descricao = "Caractere: traço da representação. Função de classe (invariante sob conjugação: χ(hgh⁻¹)=χ(g)). Caracteres de irredutíveis formam base ortogonal em funções de classe. Determinam ρ irredutível a menos de isomorfismo.",
                Criador = "Ferdinand Georg Frobenius",
                AnoOrigin = "1896",
                ExemploPratico = "Exemplo: S₃ tem 3 irreps: trivial χ₁≡1, sinal χ_sign(σ)=sgn(σ), padrão dim 2. Para rotação 120°: χ_std=2cos(2π/3)=-1.",
                Variaveis = [ new() { Simbolo = "rhog", Nome = "tr(ρ(g)) (traço da matriz)", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "χ(g)",
                UnidadeResultado = "",
                Calcular = vars => vars["rhog"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr03", Nome = "Ortogonalidade de Caracteres", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "⟨χ_ρ,χ_σ⟩ = (1/|G|) Σ_g χ_ρ(g)χ_σ(g)* = δ_{ρσ}",
                ExprTexto = "⟨χ_ρ,χ_σ⟩ = δ_{ρσ}",
                Icone = "⟨χ,χ⟩",
                Descricao = "Relações de ortogonalidade: caracteres de representações irredutíveis distinguidas formam base ortonormal em funções de classe (produto interno L² no grupo finito). Base para análise harmônica não-comutativa.",
                Criador = "Ferdinand Georg Frobenius",
                AnoOrigin = "1896",
                ExemploPratico = "Exemplo: S₃ irreps χ₁,χ_sign,χ_std. ⟨χ_std,χ_std⟩=(1/6)[1·4+2·1+3·0]=1. ⟨χ₁,χ_std⟩=(1/6)[1·1·2+...]=0.",
                Variaveis = [ new() { Simbolo = "mesmaRep", Nome = "ρ=σ? (1=sim, 0=não)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "⟨χ_ρ,χ_σ⟩",
                UnidadeResultado = "",
                Calcular = vars => vars["mesmaRep"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr04", Nome = "Completude de Caracteres", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "Σ_i (dim ρ_i)² = |G|  (G finito)",
                ExprTexto = "Σ (dim ρᵢ)² = |G|",
                Icone = "Σd²",
                Descricao = "Relação fundamental para grupos finitos: soma dos quadrados das dimensões das representações irredutíveis = ordem do grupo. Consequência da completude dos caracteres.",
                ExemploPratico = "Exemplo: S₃ tem |G|=6, irreps dim 1,1,2 → 1²+1²+2²=6✓. D₄ (diedral) tem |G|=8, irreps 1,1,1,1,2,2 → mas contando certo: 1²+1²+1²+1²+2²=8✓.",
                Variaveis = [ new() { Simbolo = "dim1", Nome = "dim(ρ₁)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dim2", Nome = "dim(ρ₂)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dim3", Nome = "dim(ρ₃)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "|G|",
                UnidadeResultado = "",
                Calcular = vars => vars["dim1"]*vars["dim1"] + vars["dim2"]*vars["dim2"] + vars["dim3"]*vars["dim3"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr05", Nome = "Lema de Schur", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "Hom_G(V,W) = 0 se V≇W;  = ℂ·Id se V≅W irred.",
                ExprTexto = "Hom_G(V,W) = δ_{VW}·ℂ",
                Icone = "Schur",
                Descricao = "Lema de Schur: não há G-homomorfismos não-triviais entre representações irredutíveis distintas. Se V=W irredutível sobre ℂ, todo homomorfismo é escalar (múltiplo da identidade). Fundamental para decomposição.",
                Criador = "Issai Schur",
                AnoOrigin = "1905",
                ExemploPratico = "Exemplo: S₃ representações χ_std (dim 2) e χ₁ (dim 1 trivial) → Hom(V_std,V_triv)=0. Para V_std→V_std: Hom=ℂ (escalares).",
                Variaveis = [ new() { Simbolo = "mesmaRep", Nome = "V≅W irredutíveis? (1=sim, 0=não)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dim Hom_G(V,W)",
                UnidadeResultado = "",
                Calcular = vars => vars["mesmaRep"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr06", Nome = "Decomposição em Irredutíveis", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "V = ⊕_i m_i V_i;  m_i = ⟨χ_V, χ_i⟩",
                ExprTexto = "V = ⊕ mᵢVᵢ; mᵢ=⟨χ_V,χᵢ⟩",
                Icone = "⊕",
                Descricao = "Toda representação de grupo finito ou compacto decompõe-se em soma direta de irredutíveis. Multiplicidades mᵢ calculadas via produto interno de caracteres. Decomposição é única (Maschke).",
                ExemploPratico = "Exemplo: S₃ regular rep de dim 6. χ_reg(e)=6, χ_reg(σ)=0 para σ≠e. m₁=⟨χ_reg,χ₁⟩=1, m_std=⟨χ_reg,χ_std⟩=2 → V=V₁⊕V_sign⊕V_std⊕V_std (dim 1+1+2+2=6).",
                Variaveis = [ new() { Simbolo = "m1", Nome = "Multiplicidade m₁", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dim1", Nome = "dim(V₁)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "m2", Nome = "Multiplicidade m₂", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dim2", Nome = "dim(V₂)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dim(V)",
                UnidadeResultado = "",
                Calcular = vars => vars["m1"]*vars["dim1"] + vars["m2"]*vars["dim2"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr07", Nome = "Reciprocidade de Frobenius", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "⟨Ind_H↑^G ρ, σ⟩_G = ⟨ρ, Res_H↓^G σ⟩_H",
                ExprTexto = "⟨Ind_H^G ρ,σ⟩=⟨ρ,Res_H σ⟩",
                Icone = "Frob",
                Descricao = "Indução IndH↑G e restrição ResH↓G são adjuntos: multiplicidade de σ em Ind(ρ) = multiplicidade de Res(σ) em ρ. Ferramenta fundamental para análise de representações de subgrupos.",
                Criador = "Ferdinand Georg Frobenius",
                AnoOrigin = "1898",
                ExemploPratico = "Exemplo: S₃⊃H=ℤ/2ℤ. Rep trivial de H induzida para S₃ dá V₁⊕V_sign. Reciprocidade: ⟨Ind(χ_H),χ₁⟩_{S₃}=1=⟨χ_H,Res(χ₁)⟩_H.",
                Variaveis = [ new() { Simbolo = "mult", Nome = "Multiplicidade", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "⟨Ind,σ⟩ = ⟨ρ,Res⟩",
                UnidadeResultado = "",
                Calcular = vars => vars["mult"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr08", Nome = "Teorema de Peter-Weyl", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "L²(G) = ⊕̂_i V_i ⊗ V_i*  (G compacto)",
                ExprTexto = "L²(G) = ⊕̂ Vᵢ⊗Vᵢ*",
                Icone = "PW",
                Descricao = "Análise harmônica não-comutativa: funções quadrado-integráveis em grupo compacto G decompõem-se em representações irredutíveis. Generalização de séries de Fourier para grupos não-abelianos. Base L² formada por coeficientes matriciais.",
                Criador = "Hermann Weyl / Fritz Peter",
                AnoOrigin = "1927",
                ExemploPratico = "Exemplo: G=SU(2) (rotações 3D) → L²(SU(2))=⊕_{j=0,1/2,1,...} V_j⊗V_j*. Expansão de funções em harmônicos esféricos de todos os spins.",
                Variaveis = [ new() { Simbolo = "nIrreps", Nome = "Número de irreps (truncamento)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "dimMedia", Nome = "dim média", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dim truncamento L²",
                UnidadeResultado = "",
                Calcular = vars => vars["nIrreps"] * vars["dimMedia"] * vars["dimMedia"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_tr09", Nome = "Fourier Não-Comutativo", Categoria = "Teoria de Lie", SubCategoria = "Teoria das Representações",
                Expressao = "f̂(ρ) = ∫_G f(g)ρ(g) dg  (G compacto)",
                ExprTexto = "f̂(ρ) = ∫ f(g)ρ(g)dg",
                Icone = "f̂",
                Descricao = "Transformada de Fourier não-comutativa: f̂(ρ) é operador em V_ρ (matriz dim(ρ)×dim(ρ)), não apenas escalar. Inversão via Peter-Weyl: f(g)=Σᵢ(dim Vᵢ)·tr(f̂(ρᵢ)ρᵢ(g)*).",
                ExemploPratico = "Exemplo: SU(2) função f com simetria → f̂(j) matrizes. Integral discreta: f̂≈Σ f(gₖ)ρ(gₖ)Δg. Simplificado: f₁ρ₁+f₂ρ₂ com f₁=2,ρ₁=3; f₂=1,ρ₂=4 → f̂≈10.",
                Variaveis = [ new() { Simbolo = "f1", Nome = "f(g₁)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rho1", Nome = "tr(ρ(g₁))", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "f2", Nome = "f(g₂)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rho2", Nome = "tr(ρ(g₂))", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "f̂(ρ) (discreto simplificado)",
                UnidadeResultado = "",
                Calcular = vars => vars["f1"]*vars["rho1"] + vars["f2"]*vars["rho2"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 2. TEORIA DOS NÚMEROS ALGÉBRICOS
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaNumeros()
    {
        _formulas.AddRange([
            // 2.1 Anéis de Inteiros e Ideais [NA1-NA9]
            new Formula
            {
                Id = "5_na01", Nome = "Extensão de Corpo de Números K/ℚ", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "[K:ℚ] = n;  O_K = anel de inteiros de K",
                ExprTexto = "K/ℚ de grau n; O_K fecho inteiro",
                Icone = "O_K",
                Descricao = "Extensão finita K/ℚ de grau n=[K:ℚ]. O_K = fecho inteiro de ℤ em K: elementos α∈K que são raízes de polinômio mônico com coeficientes em ℤ. O_K é domínio de Dedekind (fatoração única de ideais).",
                ExemploPratico = "Exemplo: K=ℚ(√5), n=2, O_K=ℤ[(1+√5)/2] (inteiros de ouro, não ℤ[√5]). K=ℚ(∛2), n=3, O_K=ℤ[∛2].",
                Variaveis = [ new() { Simbolo = "n", Nome = "[K:ℚ] grau da extensão", ValorPadrao = 2, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "[K:ℚ]",
                UnidadeResultado = "",
                Calcular = vars => vars["n"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na02", Nome = "Discriminante disc(K)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "disc(K) = det([tr(e_i e_j)])  (base {e₁,...,eₙ} de O_K)",
                ExprTexto = "Δ_K = det(matriz de traços)",
                Icone = "Δ",
                Descricao = "Discriminante: det da matriz de traços tr(eᵢeⱼ) para base integral de O_K. Mede 'complexidade' de O_K. Determina quais primos ramificam. Para K=ℚ(√d): disc=d se d≡1(mod 4), senão disc=4d.",
                Criador = "Richard Dedekind",
                AnoOrigin = "1871",
                ExemploPratico = "Exemplo: K=ℚ(√5), d=5≡1(mod 4) → disc(K)=5. K=ℚ(√2), d=2≡2(mod 4) → disc=4·2=8.",
                Variaveis = [ new() { Simbolo = "d", Nome = "d em K=ℚ(√d)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "disc(K)",
                UnidadeResultado = "",
                Calcular = vars => {
                    var d = vars["d"];
                    return (d % 4 == 1) ? d : 4 * d;
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na03", Nome = "Fatoração de Ideais", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "aO_K = Π p_i^{e_i}  (fatoração única em ideais primos)",
                ExprTexto = "Ideal = produto de primos 𝔭ᵢ^{eᵢ}",
                Icone = "Π𝔭",
                Descricao = "Fatoração única de ideais em O_K (domínio de Dedekind). Mesmo quando elementos não fatoram unicamente (ex: ℤ[√-5]), ideais sim. Recupera estrutura multiplicativa 'correta'. Teorema de Dedekind-Kummer.",
                Criador = "Richard Dedekind / Ernst Kummer",
                AnoOrigin = "1871",
                ExemploPratico = "Exemplo: ℤ[√-5], elemento 6=2·3=(1+√-5)(1-√-5) (2 fatora ções). Ideal (6)=(2)²(3) único. Em ℚ(√5): (5)=(√5)² ramifica (e=2,g=1,f=1).",
                Variaveis = [ new() { Simbolo = "e1", Nome = "Expoente e₁", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e2", Nome = "Expoente e₂", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "e3", Nome = "Expoente e₃ (0 se ausente)", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Σeᵢ (ramificação total)",
                UnidadeResultado = "",
                Calcular = vars => vars["e1"] + vars["e2"] + vars["e3"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na04", Nome = "Fórmula efg=[K:ℚ]", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "efg = n  (e=ramificação, f=grau residual, g=#primos)",
                ExprTexto = "e·f·g = [K:ℚ]",
                Icone = "efg",
                Descricao = "Decomposição de primo racional p em K: pO_K=∏𝔭ᵢ^e com f=[O_K/𝔭ᵢ:ℤ/p], g=número de primos distintos acima. efg=[K:ℚ]. Casos: split (e=1,g=n,f=1), ramificado (e=n,g=1,f=1), inerte (e=1,g=1,f=n).",
                ExemploPratico = "Exemplo: K=ℚ(√-1), n=2. Primo p=2: (2)=(1+i)² ramifica (e=2,f=1,g=1); p =5: (5)=(2+i)(2-i) split (e=1,f=1,g=2); p=3 inerte (e=1,f=2,g=1).",
                Variaveis = [ new() { Simbolo = "e", Nome = "Índice de ramificação e", ValorPadrao = 2, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "f", Nome = "Grau residual f", ValorPadrao = 1, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "g", Nome = "Número de primos g", ValorPadrao = 1, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "[K:ℚ] = efg",
                UnidadeResultado = "",
                Calcular = vars => vars["e"] * vars["f"] * vars["g"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na05", Nome = "Grupo de Classes Cl(K)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "Cl(K) = I_K / P_K;  h_K = |Cl(K)|  (número de classes)",
                ExprTexto = "Cl=(ideais fracionários)/(principais); h_K=|Cl|",
                Icone = "Cl",
                Descricao = "Grupo de classes: mede falha de fatoração única em O_K. h_K=1 ↔ O_K é UFD (domínio de fatoração única). h_K sempre finito (Minkowski). Problema de Gauss: h_K=1 para quais K imaginários? Resolvido: 9 corpos apenas.",
                Criador = "Carl Friedrich Gauss / Richard Dedekind",
                AnoOrigin = "1801",
                ExemploPratico = "Exemplo: K=ℚ(√-5), h_K=2 (2 classes, não UFD: 6=2·3=(1+√-5)(1-√-5)). K=ℚ(√-163), h_K=1 (UFD, maior discriminante neg com h=1).",
                Variaveis = [ new() { Simbolo = "hK", Nome = "Número de classes h_K", ValorPadrao = 2, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "h_K",
                UnidadeResultado = "",
                Calcular = vars => vars["hK"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na06", Nome = "Cota de Minkowski", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "|disc(K)|^{1/2} ≥ (π/4)^{r₂} · n^n / n!",
                ExprTexto = "√|Δ_K| ≥ (π/4)^{r₂}·n^n/n!",
                Icone = "Mink",
                Descricao = "Cota inferior para discriminante. Implica finitude de h_K (só finitos K com |disc|<C). r₁=emersões reais, r₂=pares complexos; r₁+2r₂=n. Geometria dos números: empacotamento de ℤⁿ em elipsóide.",
                Criador = "Hermann Minkowski",
                AnoOrigin = "1891",
                ExemploPratico = "Exemplo: K quadrático imaginário n=2, r₁=0, r₂=1 → √|Δ|≥(π/4)·4/2=π/2≈1.57. Logo |Δ|≥2.467. De fato: ℚ(i) tem |Δ|=4>2.467✓.",
                Variaveis = [ new() { Simbolo = "n", Nome = "[K:ℚ]", ValorPadrao = 2, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "r2", Nome = "r₂ pares complexos", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "√|Δ| Cota Minkowski",
                UnidadeResultado = "",
                Calcular = vars => {
                    var n = vars["n"]; var r2 = vars["r2"];
                    double fatorial = 1; for (int i = 2; i <= n; i++) fatorial *= i;
                    return Math.Pow(Math.PI / 4, r2) * Math.Pow(n, n) / fatorial;
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na07", Nome = "Teorema das Unidades de Dirichlet", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "O_K* ≅ μ(K) × ℤ^{r₁+r₂-1}",
                ExprTexto = "Unidades = raízes da unidade × ℤ^r",
                Icone = "U",
                Descricao = "Estrutura do grupo de unidades: μ(K) raízes da unidade (finito, cíclico) × parte livre ℤ^r de rank r=r₁+r₂-1. Unidades fundamentais ε₁,...,εᵣ geram via log-embedding. Para K quadrático real: r=1 → uma unidade fundamental (ex: 1+√2 para ℚ(√2)).",
                Criador = "Peter Gustav Lejeune Dirichlet",
                AnoOrigin = "1846",
                ExemploPratico = "Exemplo: K=ℚ(√2), r₁=2,r₂=0, r=1 → O_K*={±1}×⟨1+√2⟩. Toda unidade = ±(1+√2)ⁿ. K=ℚ(∛2) cúbico real: r₁=3,r₂=0, r=2 (2 unidades fundamentais).",
                Variaveis = [ new() { Simbolo = "r1", Nome = "r₁ emersões reais", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "r2", Nome = "r₂ pares complexos", ValorPadrao = 0, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "rank = r₁+r₂-1",
                UnidadeResultado = "",
                Calcular = vars => Math.Max(0, vars["r1"] + vars["r2"] - 1)
            },
            new Formula
            {
                Id = "5_na08", Nome = "Norma N_{K/ℚ}(α)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "N_{K/ℚ}(α) = Π_σ σ(α)  (produto sobre emersões σ:K→ℂ)",
                ExprTexto = "N(α) = produto de conjugados",
                Icone = "N",
                Descricao = "Norma absoluta: produto de todos os conjugados de α. Multiplicativa: N(αβ)=N(α)N(β). Para α∈O_K: N(α)∈ℤ. Para ideal 𝔞: N(𝔞)=[O_K:𝔞]. Relaciona-se a de terminante de multiplicação por α.",
                ExemploPratico = "Exemplo: α=2+√5 em ℚ(√5), conjugados {2+√5, 2-√5} → N=(2+√5)(2-√5)=4-5=-1 (unidade!). α=1+i em ℚ(i): N=(1+i)(1-i)=2.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Parte 'a' de a+b√d", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b", Nome = "Coeficiente 'b'", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "d", Nome = "√d", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "N(a+b√d) = a²-b²d",
                UnidadeResultado = "",
                Calcular = vars => {
                    var a = vars["a"]; var b = vars["b"]; var d = vars["d"];
                    return a*a - b*b*d;
                },
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na09", Nome = "Traço tr_{K/ℚ}(α)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Anéis de Inteiros",
                Expressao = "tr_{K/ℚ}(α) = Σ_σ σ(α)  (soma sobre emersões σ:K→ℂ)",
                ExprTexto = "tr(α) = soma de conjugados",
                Icone = "tr",
                Descricao = "Traço absoluto: soma de conjugados. Aditivo: tr(α+β)=tr(α)+tr(β). Para α∈O_K: tr(α)∈ℤ. Relaciona-se a traço de matriz de multiplicação por α. Para K=ℚ(√d): tr(a+b√d)=2a.",
                ExemploPratico = "Exemplo: α=2+√5 em ℚ(√5) → tr=(2+√5)+(2-√5)=4. α=1+2i em ℚ(i) → tr=(1+2i)+(1-2i)=2.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Parte 'a' de a+b√d", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "b", Nome = "Coef 'b' (cancela)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "tr(a+b√d) = 2a",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["a"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                Unidades = "",
            },

            // 2.2 Reciprocidade e Cohomologia [NA10-NA15]
            new Formula
            {
                Id = "5_na10", Nome = "Reciprocidade Quadrática (Legendre)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Reciprocidade",
                Expressao = "(p/q)(q/p) = (-1)^{(p-1)(q-1)/4}",
                ExprTexto = "(p/q)(q/p)=(-1)^((p-1)(q-1)/4)",
                Icone = "(·/·)",
                Descricao = "Lei de reciprocidade quadrática: relação simétrica entre símbolos de Legendre de primos ímpares distintos. Uma das jóias da teoria dos números elementar. Gauss deu 8 provas diferentes. Generaliza-se via teoria de corpo de classes.",
                Criador = "Carl Friedrich Gauss",
                AnoOrigin = "1796",
                ExemploPratico = "Exemplo: p=3,q=5. (3/5)=3^((5-1)/2)=3²=9≡-1(mod 5) → (3/5)=-1. (5/3)=5^1=5≡2(mod 3) → (5/3)=-1. Produto: (-1)(-1)=1. Fórmula: (-1)^((3-1)(5-1)/4)=(-1)²=1✓.",
                Variaveis = [ new() { Simbolo = "p", Nome = "Primo ímpar p", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "q", Nome = "Primo ímpar q", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "(-1)^((p-1)(q-1)/4)",
                UnidadeResultado = "",
                Calcular = vars => {
                    var p = vars["p"]; var q = vars["q"];
                    var exp = (p - 1) * (q - 1) / 4;
                    return Math.Pow(-1, exp);
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na11", Nome = "Símbolo de Legendre (a/p)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Reciprocidade",
                Expressao = "(a/p) = a^{(p-1)/2} mod p ∈ {±1,0}",
                ExprTexto = "(a/p) = a^((p-1)/2) mod p",
                Icone = "(a/p)",
                Descricao = "Símbolo de Legendre: (a/p)=1 se a é resíduo quadrático mod p (∃x: x²≡a); -1 se não-resíduo; 0 se p|a. Critério de Euler calcula via exponenciação. Base para testes de primalidade e criptografia.",
                Criador = "Adrien-Marie Legendre / Leonhard Euler",
                AnoOrigin = "1785",
                ExemploPratico = "Exemplo: É 2 QR mod 7? (2/7)=2^((7-1)/2)=2³=8≡1(mod 7) → sim, 3²=9≡2(mod 7)✓. É 3 QR mod 5? (3/5)=3²=9≡-1(mod 5) → não.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Inteiro a", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "p", Nome = "Primo ímpar p", ValorPadrao = 7, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "(a/p) ∈{-1,0,1}",
                UnidadeResultado = "",
                Calcular = vars => {
                    var a = vars["a"]; var p = vars["p"];
                    if (a % p == 0) return 0;
                    var exp = (p - 1) / 2;
                    var result = Math.Pow(a, exp) % p;
                    if (result > p / 2) result -= p; // Normalizar para -1
                    return result;
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na12", Nome = "Símbolo de Jacobi (a/n)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Reciprocidade",
                Expressao = "(a/n) = Π (a/p_i)^{e_i}  (n = Π p_i^{e_i} ímpar)",
                ExprTexto = "(a/n) = produto de Legendre (a/pⁱ)^eᵢ",
                Icone = "(a/n)",
                Descricao = "Generalização de Legendre para n composto ímpar. Multiplicativo em ambos argumentos. (a/n)=1 NÃO implica a é QR mod n (mas -1 implica não-QR). Usado em teste de primalidade de Solovay-Strassen.",
                Criador = "Carl Gustav Jacob Jacobi",
                AnoOrigin = "1837",
                ExemploPratico = "Exemplo: (2/15) com 15=3·5. (2/3)=2^1=2≡-1(mod 3) → -1. (2/5)=2²=4≡-1(mod 5) → -1. Produto: (-1)(-1)=1. Mas 2 NÃO é QR mod 15 (verificar: nenhum x²≡2(mod 15)).",
                Variaveis = [ new() { Simbolo = "a", Nome = "Inteiro a", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "legendre1", Nome = "(a/p₁) Legendre 1", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "legendre2", Nome = "(a/p₂) Legendre 2", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "(a/n) Jacobi",
                UnidadeResultado = "",
                Calcular = vars => vars["legendre1"] * vars["legendre2"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na13", Nome = "Reciprocidade de Artin (Teoria de Corpo de Classes)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Reciprocidade",
                Expressao = "Gal(L/K)^{ab} ≅ K* / N_{L/K}(L*)  (L/K abeliana)",
                ExprTexto = "Gal(L/K)^ab ≅ quociente de ideles",
                Icone = "Art",
                Descricao = "Isomorfismo de reciprocidade de Artin: abelianização do grupo de Galois ≅ quociente de ideles/normas. Coroa teoria de corpo de classes. Generaliza todas as leis de reciprocidade clássicas (quadrática, cúbica, biquadrática,...). Base da conjectura de Langlands.",
                Criador = "Emil Artin",
                AnoOrigin = "1927",
                ExemploPratico = "Exemplo: L/K=ℚ(ζₙ)/ℚ ciclotômico. Gal≅(ℤ/nℤ)* (grupo multiplicativo mod n). Via Artin: Gal≅ℚ*/ℚ*ⁿ (quociente de classes de congruência). Para n=5: Gal≅ℤ/4ℤ (grupo cíclico de ordem 4).",
                Variaveis = [ new() { Simbolo = "n", Nome = "[L:K] grau da extensão abeliana", ValorPadrao = 4, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "|Gal(L/K)|",
               UnidadeResultado = "",
                Calcular = vars => vars["n"],
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na14", Nome = "Mapa de Artin (Frobenius)", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Reciprocidade",
                Expressao = "p ↦ Frob_p ∈ Gal(L/K);  Frob_p(x) = x^{Np} mod p",
                ExprTexto = "Frob_p: x↦x^(Np) (automorfismo de Frobenius)",
                Icone = "Fr",
                Descricao = "Frobenius em primo p não-ramificado: elemento de Galois que age como potência Np-ésima no corpo residual. Np=N_{K/ℚ}(p). Define homomorfismo de ideais em Gal(L/K). Base do isomorfismo de Artin. Em extensão não-abeliana, Frob_p é classe de conjugação.",
                Criador = "Emil Artin / Ferdinand Georg Frobenius",
                AnoOrigin = "1896",
                ExemploPratico = "Exemplo: K=ℚ, p=5, L=ℚ(ζ₇) (7 raízes da unidade). Np=5, Frob₅(ζ)=ζ⁵ (shift cíclico). Em Gal≅ℤ/6ℤ: Frob₅ corresponde a 5 mod 7 (gerador se 5 primitivo).",
                Variaveis = [ new() { Simbolo = "Np", Nome = "Norma do primo Np", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x", Nome = "Elemento x no corpo", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "Frob_p(x) = x^Np mod Np",
                UnidadeResultado = "",
                Calcular = vars => {
                    var Np = vars["Np"]; var x = vars["x"];
                    return Math.Pow(x, Np) % Np;
                },
                Unidades = "",
            },
            new Formula
            {
                Id = "5_na15", Nome = "Cohomologia de Galois H¹", Categoria = "Teoria dos Números Algébricos", SubCategoria = "Reciprocidade",
                Expressao = "H¹(Gal(K̄/K), A)  (sequências exatas de Galois)",
                ExprTexto = "H¹(Gal,A) cohomologia de grupo de Galois",
                Icone = "H¹",
                Descricao = "Cohomologia de grupo de Galois agindo em módulo A. H⁰=invariantes, H¹ classifica extensões e torsores. H¹(Gal,G_m)=subset do grupo de Brauer Br(K). H¹(ℚ,E[n]) relaciona-se a pontos racionais em curvas elípticas. Ferramenta essencial em geometria aritmética (Selmer, Tate-Shafarevich).",
                Criador = "Claude Chevalley / Jean-Pierre Serre",
                AnoOrigin = "1950",
                ExemploPratico = "Exemplo: H¹(ℚ,ℤ/2ℤ) classifica extensões quadráticas de ℚ (≅ℚ*/ℚ*²). H¹(ℚ,ellíptica E) relaciona-se a obstruções locais-globais (Hasse-Minkowski). dim H¹ ~complexidade aritmética.",
                Variaveis = [ new() { Simbolo = "dimH1", Nome = "dim H¹ estimada", ValorPadrao = 2, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ],
                VariavelResultado = "dim H¹",
                UnidadeResultado = "",
                Calcular = vars => vars["dimH1"],
                Unidades = "",
            },
        ]);
    }

    // Wrappers esperados pelo inicializador principal
    private void AdicionarTeoriaDeLie() => AdicionarTeoriaLieRepresentacoes();
    private void AdicionarNumerosAlgebricos() => AdicionarTeoriaNumeros();

    // ─────────────────────────────────────────────────────
    // 3. GEOMETRIA RIEMANNIANA AVANÇADA E TEORIA DE HODGE
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaRiemanniana()
    {
        _formulas.AddRange([
            new Formula { Id = "5_gr01", Nome = "Curvatura Seccional", Categoria = "Geometria Riemanniana", SubCategoria = "Curvaturas", Expressao = "K(σ)=R(X,Y,Y,X)/(||X||²||Y||²-<X,Y>²)", ExprTexto = "K = R/denominador", Icone = "K", Descricao = "Curvatura da 2-seção σ gerada por X,Y. Mede desvio local de geodésicas.", Variaveis = [ new() { Simbolo = "R", Nome = "R(X,Y,Y,X)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "x2", Nome = "||X||²", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "y2", Nome = "||Y||²", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "xy", Nome = "<X,Y>", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "K(σ)", UnidadeResultado = "", Calcular = v => v["R"] / Math.Max(1e-9, (v["x2"] * v["y2"] - v["xy"] * v["xy"])),
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr02", Nome = "Curvatura de Ricci", Categoria = "Geometria Riemanniana", SubCategoria = "Curvaturas", Expressao = "Ric(X,X)=Σ_i K(X,e_i)", ExprTexto = "Ric = soma das seccionais", Icone = "Ric", Descricao = "Contração do tensor de Riemann. Controla volume e convergência geodésica.", Variaveis = [ new() { Simbolo = "k1", Nome = "K(X,e1)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k2", Nome = "K(X,e2)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k3", Nome = "K(X,e3)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Ric(X,X)", UnidadeResultado = "", Calcular = v => v["k1"] + v["k2"] + v["k3"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr03", Nome = "Curvatura Escalar", Categoria = "Geometria Riemanniana", SubCategoria = "Curvaturas", Expressao = "R=tr(Ric)", ExprTexto = "R escalar = traço de Ric", Icone = "R", Descricao = "Soma dos autovalores de Ricci. Aparece na Relatividade e no fluxo de Ricci.", Variaveis = [ new() { Simbolo = "ric1", Nome = "Ric11", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ric2", Nome = "Ric22", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ric3", Nome = "Ric33", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "R", UnidadeResultado = "", Calcular = v => v["ric1"] + v["ric2"] + v["ric3"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr04", Nome = "Equação de Jacobi", Categoria = "Geometria Riemanniana", SubCategoria = "Geodésicas", Expressao = "D²J/dt² + R(J,γ')γ' = 0", ExprTexto = "J'' + RJ = 0", Icone = "J", Descricao = "Campos de Jacobi medem separação de geodésicas vizinhas.", Variaveis = [ new() { Simbolo = "jpp", Nome = "D²J/dt²", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rj", Nome = "R(J,γ')γ'", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Resíduo (deve ser 0)", UnidadeResultado = "", Calcular = v => v["jpp"] + v["rj"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr05", Nome = "Bonnet-Myers (Cota de Diâmetro)", Categoria = "Geometria Riemanniana", SubCategoria = "Teoremas Globais", Expressao = "Ric≥(n-1)κ>0 => diam≤π/√κ", ExprTexto = "diam <= pi/sqrt(kappa)", Icone = "diam", Descricao = "Ricci positiva implica compacidade e grupo fundamental finito.", Variaveis = [ new() { Simbolo = "kappa", Nome = "κ", ValorPadrao = 1, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Cota superior do diâmetro", UnidadeResultado = "", Calcular = v => Math.PI / Math.Sqrt(v["kappa"]),
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr06", Nome = "Comparação de Bishop (Volume)", Categoria = "Geometria Riemanniana", SubCategoria = "Teoremas Globais", Expressao = "vol(B_r(p))<=vol_κ(B_r)", ExprTexto = "volume real <= volume modelo", Icone = "vol", Descricao = "Compara crescimento de volume sob hipóteses de curvatura.", Variaveis = [ new() { Simbolo = "volReal", Nome = "vol(B_r(p))", ValorPadrao = 8, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "volModelo", Nome = "vol_κ(B_r)", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Razão volReal/volModelo", UnidadeResultado = "", Calcular = v => v["volReal"] / Math.Max(1e-9, v["volModelo"]),
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr07", Nome = "Hadamard-Cartan", Categoria = "Geometria Riemanniana", SubCategoria = "Teoremas Globais", Expressao = "K<=0 => exp_p: T_pM->M difeomorfismo", ExprTexto = "curvatura nao-positiva implica sem conjugados", Icone = "exp", Descricao = "Em variedades simplesmente conexas com K<=0, exponencial é difeomorfismo global.", Variaveis = [ new() { Simbolo = "k", Nome = "Curvatura máxima", ValorPadrao = -0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Condição satisfeita? 1/0", UnidadeResultado = "", Calcular = v => v["k"] <= 0 ? 1 : 0,
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr08", Nome = "Tensor de Weyl (Modelo)", Categoria = "Geometria Riemanniana", SubCategoria = "Curvaturas", Expressao = "C=Riemann - termos de Ricci - termo escalar", ExprTexto = "C = parte conforme da curvatura", Icone = "C", Descricao = "Componente livre de traço do tensor de curvatura.", Variaveis = [ new() { Simbolo = "riem", Nome = "Componente de Riemann", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ricTerm", Nome = "Termo de Ricci", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "escTerm", Nome = "Termo escalar", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Componente de Weyl", UnidadeResultado = "", Calcular = v => v["riem"] - v["ricTerm"] - v["escTerm"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr09", Nome = "Variedade Einstein", Categoria = "Geometria Riemanniana", SubCategoria = "Estruturas Especiais", Expressao = "Ric=λg", ExprTexto = "Ric proporcional à métrica", Icone = "Ein", Descricao = "Condição de Einstein: curvatura de Ricci isotrópica.", Variaveis = [ new() { Simbolo = "lambda", Nome = "λ", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "g", Nome = "Componente g", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ric", Nome = "Componente Ric", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Resíduo Ric-λg", UnidadeResultado = "", Calcular = v => v["ric"] - v["lambda"] * v["g"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_gr10", Nome = "Fluxo de Ricci", Categoria = "Geometria Riemanniana", SubCategoria = "Evolução Geométrica", Expressao = "∂g_ij/∂t=-2R_ij", ExprTexto = "g_t = -2 Ric", Icone = "flow", Descricao = "Fluxo geométrico usado por Perelman na conjectura de Poincaré.", Variaveis = [ new() { Simbolo = "rij", Nome = "R_ij", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "∂g_ij/∂t", UnidadeResultado = "", Calcular = v => -2 * v["rij"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },

            new Formula { Id = "5_th01", Nome = "Operador de Hodge *", Categoria = "Teoria de Hodge", SubCategoria = "Operadores", Expressao = "*:Ω^k->Ω^{n-k}; **ω=(-1)^{k(n-k)}ω", ExprTexto = "*^2 = (-1)^{k(n-k)}", Icone = "*", Descricao = "Dualidade de Hodge entre k-formas e (n-k)-formas.", Variaveis = [ new() { Simbolo = "k", Nome = "Grau k", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "n", Nome = "Dimensão n", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Sinal de **", UnidadeResultado = "", Calcular = v => (((int)(v["k"] * (v["n"] - v["k"]))) % 2 == 0) ? 1 : -1,
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_th02", Nome = "Coderivada δ", Categoria = "Teoria de Hodge", SubCategoria = "Operadores", Expressao = "δ=(-1)^{n(k+1)+1}*d*", ExprTexto = "delta por hodge star", Icone = "δ", Descricao = "Adjunto formal de d com métrica Riemanniana.", Variaveis = [ new() { Simbolo = "n", Nome = "n", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "k", Nome = "k", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Sinal prefatorial", UnidadeResultado = "", Calcular = v => (((int)(v["n"] * (v["k"] + 1) + 1)) % 2 == 0) ? 1 : -1,
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_th03", Nome = "Laplaciano de Hodge", Categoria = "Teoria de Hodge", SubCategoria = "Operadores", Expressao = "Δ=dδ+δd", ExprTexto = "Laplaciano em formas", Icone = "Δ", Descricao = "Forma é harmônica se Δω=0.", Variaveis = [ new() { Simbolo = "dδ", Nome = "dδ(ω)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "δd", Nome = "δd(ω)", ValorPadrao = -1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Δω", UnidadeResultado = "", Calcular = v => v["dδ"] + v["δd"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_th04", Nome = "Decomposição de Hodge", Categoria = "Teoria de Hodge", SubCategoria = "Estrutura", Expressao = "Ω^k=H^k⊕dΩ^{k-1}⊕δΩ^{k+1}", ExprTexto = "dim Ω = dim H + dim exata + dim coexata", Icone = "⊕", Descricao = "Decomposição ortogonal em parcela harmônica, exata e coexata.", Variaveis = [ new() { Simbolo = "h", Nome = "dim H^k", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "ex", Nome = "dim dΩ", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "coex", Nome = "dim δΩ", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "dim Ω^k", UnidadeResultado = "", Calcular = v => v["h"] + v["ex"] + v["coex"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_th05", Nome = "Isomorfismo Hodge-de Rham", Categoria = "Teoria de Hodge", SubCategoria = "Cohomologia", Expressao = "H^k(harmônicas)≅H^k_dR(M)", ExprTexto = "b_k = dim H^k", Icone = "H^k", Descricao = "Toda classe de de Rham possui representante harmônico único em variedade compacta orientada.", Variaveis = [ new() { Simbolo = "bk", Nome = "Número de Betti b_k", ValorPadrao = 1, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "dim H^k", UnidadeResultado = "", Calcular = v => v["bk"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_th06", Nome = "Identidades de Kähler", Categoria = "Teoria de Hodge", SubCategoria = "Variedades Kähler", Expressao = "Δ=2Δ_dbar=2Δ_d", ExprTexto = "laplacianos coincidem em Kähler", Icone = "Kah", Descricao = "Estrutura complexa e simplética compatíveis simplificam análise harmônica.", Variaveis = [ new() { Simbolo = "dbar", Nome = "Δ_dbar", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "d", Nome = "Δ_d", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Δ (médio)", UnidadeResultado = "", Calcular = v => (2 * v["dbar"] + 2 * v["d"]) / 2,
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_th07", Nome = "Lema ∂∂̄", Categoria = "Teoria de Hodge", SubCategoria = "Variedades Kähler", Expressao = "d-fechada e d-exata <=> ∂∂̄-exata", ExprTexto = "equivalencia especial em Kähler", Icone = "ddbar", Descricao = "Ferramenta central para degenerescência de sequências espectrais e geometria complexa.", Variaveis = [ new() { Simbolo = "k", Nome = "Satisfaz hipótese? (1/0)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Válido? 1/0", UnidadeResultado = "", Calcular = v => v["k"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", }
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 4. ANÁLISE HARMÔNICA EM GRUPOS LOCALMENTE COMPACTOS
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseHarmonica()
    {
        _formulas.AddRange([
            new Formula { Id = "5_ah01", Nome = "Medida de Haar", Categoria = "Análise Harmônica", SubCategoria = "Grupos Localmente Compactos", Expressao = "μ(gE)=μ(E)", ExprTexto = "invariância à esquerda", Icone = "μ", Descricao = "Medida invariante por translação em grupos localmente compactos.", Variaveis = [ new() { Simbolo = "muE", Nome = "μ(E)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "μ(gE)", UnidadeResultado = "", Calcular = v => v["muE"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah02", Nome = "Unicidade da Haar", Categoria = "Análise Harmônica", SubCategoria = "Grupos Localmente Compactos", Expressao = "μ'=cμ", ExprTexto = "duas Haar diferem por constante", Icone = "c", Descricao = "Toda medida de Haar é única a menos de fator positivo.", Variaveis = [ new() { Simbolo = "c", Nome = "Constante c", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "mu", Nome = "μ(E)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "μ'(E)", UnidadeResultado = "", Calcular = v => v["c"] * v["mu"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah03", Nome = "Função Modular", Categoria = "Análise Harmônica", SubCategoria = "Grupos Localmente Compactos", Expressao = "Δ(g)=dμ_right/dμ_left", ExprTexto = "unimodular se Δ≡1", Icone = "Δ", Descricao = "Compara medidas à direita e à esquerda. Grupos compactos são unimodulares.", Variaveis = [ new() { Simbolo = "muR", Nome = "dμ_right", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "muL", Nome = "dμ_left", ValorPadrao = 1, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Δ(g)", UnidadeResultado = "", Calcular = v => v["muR"] / v["muL"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah04", Nome = "Convolução em Grupo", Categoria = "Análise Harmônica", SubCategoria = "Operações", Expressao = "(f*g)(x)=∫ f(y)g(y^{-1}x)dμ(y)", ExprTexto = "convolução em G", Icone = "*", Descricao = "Generaliza convolução clássica para grupos.", Variaveis = [ new() { Simbolo = "f", Nome = "f médio", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "g", Nome = "g médio", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "(f*g)", UnidadeResultado = "", Calcular = v => v["f"] * v["g"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah05", Nome = "Fourier em Grupo Abeliano", Categoria = "Análise Harmônica", SubCategoria = "Transformadas", Expressao = "f̂(χ)=∫ f(g)χ̄(g)dg", ExprTexto = "transformada de Fourier por caracteres", Icone = "f̂", Descricao = "Transforma função no grupo em função no dual Ĝ.", Variaveis = [ new() { Simbolo = "f", Nome = "Amplitude média de f", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "chi", Nome = "χ̄ médio", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "f̂(χ)", UnidadeResultado = "", Calcular = v => v["f"] * v["chi"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah06", Nome = "Inversão de Fourier", Categoria = "Análise Harmônica", SubCategoria = "Transformadas", Expressao = "f(g)=∫_Ĝ f̂(χ)χ(g)dμ̂(χ)", ExprTexto = "inversão no dual", Icone = "inv", Descricao = "Recupera f a partir de sua transformada.", Variaveis = [ new() { Simbolo = "fh", Nome = "f̂ médio", ValorPadrao = 1.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "chi", Nome = "χ médio", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "f(g)", UnidadeResultado = "", Calcular = v => v["fh"] * v["chi"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah07", Nome = "Parseval", Categoria = "Análise Harmônica", SubCategoria = "Transformadas", Expressao = "∫|f|²dμ=∫|f̂|²dμ̂", ExprTexto = "norma L2 preservada", Icone = "L2", Descricao = "Conservação de energia entre domínio e frequência.", Variaveis = [ new() { Simbolo = "lhs", Nome = "∫|f|²", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "rhs", Nome = "∫|f̂|²", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Diferença (deve ser 0)", UnidadeResultado = "", Calcular = v => v["lhs"] - v["rhs"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah08", Nome = "Dualidade de Pontryagin", Categoria = "Análise Harmônica", SubCategoria = "Estrutura", Expressao = "(Ĝ)^ ≅ G", ExprTexto = "bidual canonicamente isomorfo", Icone = "^", Descricao = "Categoria dos grupos abelianos localmente compactos é autodual.", Variaveis = [ new() { Simbolo = "ok", Nome = "isomorfismo válido? (1/0)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Válido?", UnidadeResultado = "", Calcular = v => v["ok"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ah09", Nome = "Convolução vira Produto", Categoria = "Análise Harmônica", SubCategoria = "Transformadas", Expressao = "(f*g)^ = f̂·ĝ", ExprTexto = "Fourier(conv)=produto", Icone = "conv", Descricao = "Teorema central que simplifica EDOs/PDEs via frequência.", Variaveis = [ new() { Simbolo = "fh", Nome = "f̂", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "gh", Nome = "ĝ", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "(f*g)^", UnidadeResultado = "", Calcular = v => v["fh"] * v["gh"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", }
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 5. GEOMETRIA NÃO-COMUTATIVA E C*-ÁLGEBRAS
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaNaoComutativa()
    {
        _formulas.AddRange([
            new Formula { Id = "5_ca01", Nome = "Identidade C*", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras", Expressao = "||a*a||=||a||²", ExprTexto = "norma C*", Icone = "C*", Descricao = "Axioma definidor de C*-álgebra de Banach com involução.", Variaveis = [ new() { Simbolo = "norma", Nome = "||a||", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "||a*a||", UnidadeResultado = "", Calcular = v => v["norma"] * v["norma"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ca02", Nome = "Exemplos de C*-Álgebras", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras", Expressao = "B(H), C(X), M_n(C)", ExprTexto = "operadores, funções, matrizes", Icone = "Ex", Descricao = "Principais exemplos usados em física matemática e análise funcional.", Variaveis = [ new() { Simbolo = "n", Nome = "n da matriz M_n", ValorPadrao = 3, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "dim M_n(C)=n²", UnidadeResultado = "", Calcular = v => v["n"] * v["n"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ca03", Nome = "Espectro e Raio Espectral", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras", Expressao = "σ(a)={λ:a-λ1 não invertível}; ||a||=sqrt(spr(a*a))", ExprTexto = "norma via raio espectral", Icone = "σ", Descricao = "Relação central entre norma e espectro em C*-álgebras.", Variaveis = [ new() { Simbolo = "spr", Nome = "spr(a*a)", ValorPadrao = 9, ValorMin = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "||a||", UnidadeResultado = "", Calcular = v => Math.Sqrt(v["spr"]),
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ca04", Nome = "Teorema de Gelfand", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras", Expressao = "A comutativa ≅ C0(X)", ExprTexto = "representação por funções", Icone = "Gel", Descricao = "Toda C*-álgebra comutativa é álgebra de funções contínuas que vão a zero no infinito.", Variaveis = [ new() { Simbolo = "ok", Nome = "A comutativa? (1/0)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Aplicável?", UnidadeResultado = "", Calcular = v => v["ok"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ca05", Nome = "Representação GNS", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras", Expressao = "ω(a)=<Ω,π(a)Ω>", ExprTexto = "estado gera representação", Icone = "GNS", Descricao = "Constrói representação de Hilbert a partir de estado positivo linear.", Variaveis = [ new() { Simbolo = "omega", Nome = "ω(a)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "ω(a)", UnidadeResultado = "", Calcular = v => v["omega"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ca06", Nome = "Álgebra de von Neumann", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras", Expressao = "álgebra fechada na topologia fraca em B(H)", ExprTexto = "W* álgebra", Icone = "vN", Descricao = "Objeto central em teoria quântica e fatores de Murray-von Neumann.", Variaveis = [ new() { Simbolo = "closed", Nome = "Fechada fraca? (1/0)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "É von Neumann?", UnidadeResultado = "", Calcular = v => v["closed"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_ca07", Nome = "Fatores Tipo I/II/III", Categoria = "Geometria Não-Comutativa", SubCategoria = "C*-Álgebras", Expressao = "classificação de Murray-von Neumann", ExprTexto = "tipos de fatores", Icone = "I/II/III", Descricao = "Classificação profunda de fatores por estrutura de projeções e traços.", Variaveis = [ new() { Simbolo = "tipo", Nome = "1=I,2=II,3=III", ValorPadrao = 1, ValorMin = 1, ValorMax = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Tipo", UnidadeResultado = "", Calcular = v => v["tipo"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },

            new Formula { Id = "5_nc01", Nome = "Produto de Moyal", Categoria = "Geometria Não-Comutativa", SubCategoria = "Produto Estrela", Expressao = "(f⋆g)(x)=f exp(iħ/2 ←∂μ θμν ∂→ν) g", ExprTexto = "produto estrela de Moyal", Icone = "⋆", Descricao = "Deformação não-comutativa do produto de funções lisas.", Variaveis = [ new() { Simbolo = "f", Nome = "f(x)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "g", Nome = "g(x)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "hbar", Nome = "ħ", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "theta", Nome = "θ (escala)", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "f⋆g (1a ordem)", UnidadeResultado = "", Calcular = v => v["f"] * v["g"] + 0.5 * v["hbar"] * v["theta"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_nc02", Nome = "Comutação de Coordenadas", Categoria = "Geometria Não-Comutativa", SubCategoria = "Produto Estrela", Expressao = "[x^μ,x^ν]=iθ^{μν}", ExprTexto = "não-comutatividade espacial", Icone = "[x,x]", Descricao = "Generaliza relações de Heisenberg para coordenadas do espaço-tempo.", Variaveis = [ new() { Simbolo = "theta", Nome = "θ^{μν}", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "|[x^μ,x^ν]|", UnidadeResultado = "", Calcular = v => Math.Abs(v["theta"]),
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_nc03", Nome = "Plano de Moyal", Categoria = "Geometria Não-Comutativa", SubCategoria = "Produto Estrela", Expressao = "θ=[[0,θ],[-θ,0]]", ExprTexto = "matriz antissimétrica 2x2", Icone = "θ", Descricao = "Modelo 2D canônico de geometria não-comutativa.", Variaveis = [ new() { Simbolo = "theta", Nome = "θ", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "det(θ)", UnidadeResultado = "", Calcular = v => v["theta"] * v["theta"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_nc04", Nome = "Tripla Espectral", Categoria = "Geometria Não-Comutativa", SubCategoria = "Geometria Espectral", Expressao = "(A,H,D)", ExprTexto = "álgebra, espaço de Hilbert, Dirac", Icone = "D", Descricao = "Dados fundamentais de Connes para reconstrução geométrica espectral.", Variaveis = [ new() { Simbolo = "dimH", Nome = "dim(H)", ValorPadrao = 10, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "dim(H)", UnidadeResultado = "", Calcular = v => v["dimH"],
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", },
            new Formula { Id = "5_nc05", Nome = "Distância de Connes", Categoria = "Geometria Não-Comutativa", SubCategoria = "Geometria Espectral", Expressao = "d(p,q)=sup{|f(p)-f(q)|:||[D,f]||<=1}", ExprTexto = "métrica espectral", Icone = "d", Descricao = "Define distância geométrica puramente por operadores.", Variaveis = [ new() { Simbolo = "fp", Nome = "f(p)", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "fq", Nome = "f(q)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" }, new() { Simbolo = "normDf", Nome = "||[D,f]||", ValorPadrao = 1, ValorMin = 0.0001, Descricao = "Parâmetro de entrada.", Unidade = "adim" } ], VariavelResultado = "Cota de distância", UnidadeResultado = "", Calcular = v => (v["normDf"] <= 1 ? Math.Abs(v["fp"] - v["fq"]) : Math.Abs(v["fp"] - v["fq"]) / v["normDf"]),
                Criador = "Equipe CompendioCalc",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "",
                Unidades = "", }
        ]);
    }
}
