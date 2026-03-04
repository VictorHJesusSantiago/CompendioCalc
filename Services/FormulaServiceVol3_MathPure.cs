using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 3 — PARTE I: MATEMÁTICA PURA AVANÇADA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 1. ANÁLISE FUNCIONAL
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseFuncional()
    {
        _formulas.AddRange([
            // 1.1 Espaços de Banach
            new Formula
            {
                Id = "3_af01", Nome = "Axiomas de Norma", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "||x|| ≥ 0; ||x||=0 ↔ x=0; ||αx||=|α|||x||; ||x+y||≤||x||+||y||",
                ExprTexto = "‖x‖ ≥ 0; ‖x‖=0 ⟺ x=0; ‖αx‖=|α|‖x‖; ‖x+y‖≤‖x‖+‖y‖",
                Icone = "‖‖",
                Descricao = "Uma norma em um espaço vetorial satisfaz: positividade, igualdade a zero somente para vetor nulo, homogeneidade absoluta e desigualdade triangular.",
                Criador = "Stefan Banach",
                AnoOrigin = "1920",
            },
            new Formula
            {
                Id = "3_af02", Nome = "Espaço de Banach (Definição)", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "Espaço normado completo: toda sequência de Cauchy converge",
                ExprTexto = "Espaço normado (X,‖·‖) onde toda sequência de Cauchy converge em X",
                Icone = "‖‖",
                Descricao = "Um espaço de Banach é um espaço normado completo, ou seja, toda sequência de Cauchy tem limite no espaço. Exemplos: ℝⁿ, Lᵖ(Ω), C[a,b] com norma sup.",
                Criador = "Stefan Banach",
                AnoOrigin = "1922",
            },
            new Formula
            {
                Id = "3_af03", Nome = "Norma ℓᵖ", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "||x||_p = (Σ|xᵢ|ᵖ)^(1/p)  (1≤p<∞)",
                ExprTexto = "‖x‖_p = (Σ|xᵢ|ᵖ)^(1/p)",
                Icone = "‖‖",
                Descricao = "Norma p de um vetor no espaço de sequências ℓᵖ. Para p=1 soma dos valores abs., p=2 norma euclidiana.",
                Criador = "Frigyes Riesz",
                AnoOrigin = "1910",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", Descricao = "Componente 1", ValorPadrao = 3 },
                    new() { Simbolo = "x2", Nome = "x₂", Descricao = "Componente 2", ValorPadrao = 4 },
                    new() { Simbolo = "p", Nome = "p", Descricao = "Expoente (≥1)", ValorPadrao = 2, ValorMin = 1 },
                ],
                VariavelResultado = "‖x‖_p",
                Calcular = v => Math.Pow(Math.Pow(Math.Abs(v["x1"]), v["p"]) + Math.Pow(Math.Abs(v["x2"]), v["p"]), 1.0 / v["p"])
            },
            new Formula
            {
                Id = "3_af04", Nome = "Norma Sup (ℓ∞)", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "||x||_∞ = sup|xᵢ|",
                ExprTexto = "‖x‖_∞ = sup|xᵢ| = max|xᵢ|",
                Icone = "‖‖",
                Descricao = "A norma supremo é o máximo dos valores absolutos das componentes. É o limite da norma p quando p→∞.",
                Criador = "Pafnuty Chebyshev",
                AnoOrigin = "~1850",
            },
            new Formula
            {
                Id = "3_af05", Nome = "Espaço Lᵖ(Ω)", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "||f||_p = (∫|f|ᵖdμ)^(1/p)",
                ExprTexto = "‖f‖_p = (∫|f|ᵖdμ)^(1/p)",
                Icone = "‖‖",
                Descricao = "Espaço de funções mensuráveis f com ∫|f|ᵖdμ < ∞. São espaços de Banach para 1≤p≤∞. Para p=2 é espaço de Hilbert.",
                Criador = "Henri Lebesgue / Frigyes Riesz",
                AnoOrigin = "1910",
            },
            new Formula
            {
                Id = "3_af06", Nome = "Desigualdade de Hölder", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "∫|fg| ≤ ||f||_p · ||g||_q;  1/p+1/q=1",
                ExprTexto = "∫|fg| ≤ ‖f‖_p · ‖g‖_q;  1/p+1/q=1",
                Icone = "‖‖",
                Descricao = "Generaliza Cauchy-Schwarz (p=q=2). Fundamental para provar que Lᵖ é espaço vetorial e que o dual de Lᵖ é Lᵍ.",
                Criador = "Otto Hölder",
                AnoOrigin = "1889",
            },
            new Formula
            {
                Id = "3_af07", Nome = "Desigualdade de Minkowski", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "||f+g||_p ≤ ||f||_p + ||g||_p",
                ExprTexto = "‖f+g‖_p ≤ ‖f‖_p + ‖g‖_p",
                Icone = "‖‖",
                Descricao = "Desigualdade triangular para normas Lᵖ. Demonstra-se usando Hölder. Garante que ‖·‖_p é de fato uma norma.",
                Criador = "Hermann Minkowski",
                AnoOrigin = "1896",
            },
            new Formula
            {
                Id = "3_af08", Nome = "Teorema de Hahn-Banach", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "f em M⊂X ⟹ ∃F em X: F|_M=f; ||F||=||f||",
                ExprTexto = "f em M⊂X ⟹ ∃F em X: F|_M=f; ‖F‖=‖f‖",
                Icone = "‖‖",
                Descricao = "Todo funcional linear contínuo em um subespaço pode ser estendido a todo o espaço preservando a norma. Pilha base da análise funcional.",
                Criador = "Hans Hahn / Stefan Banach",
                AnoOrigin = "1927-1929",
            },
            new Formula
            {
                Id = "3_af09", Nome = "Teorema do Ponto Fixo de Schauder", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "T:K→K compacto, K convexo fechado ⟹ ∃x*: T(x*)=x*",
                ExprTexto = "T:K→K compacto, K convexo fechado ⟹ ∃x*: T(x*)=x*",
                Icone = "‖‖",
                Descricao = "Generalização do ponto fixo de Brouwer para espaços de Banach. Um operador compacto mapeando um convexo fechado e limitado em si possui ponto fixo.",
                Criador = "Juliusz Schauder",
                AnoOrigin = "1930",
            },
            new Formula
            {
                Id = "3_af10", Nome = "Princípio da Limitação Uniforme (Banach-Steinhaus)", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "sup_n ||Tₙ(x)|| < ∞ ∀x ⟹ sup_n ||Tₙ|| < ∞",
                ExprTexto = "supₙ ‖Tₙ(x)‖ < ∞ ∀x ⟹ supₙ ‖Tₙ‖ < ∞",
                Icone = "‖‖",
                Descricao = "Se operadores lineares contínuos são pontualmente limitados em um Banach, são uniformemente limitados em norma. Consequência do teorema de Baire.",
                Criador = "Stefan Banach / Hugo Steinhaus",
                AnoOrigin = "1927",
            },
            new Formula
            {
                Id = "3_af11", Nome = "Teorema da Aplicação Aberta", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "T:X→Y sobrejetivo, X,Y Banach ⟹ T leva abertos em abertos",
                ExprTexto = "T:X→Y sobrejetivo, X,Y Banach ⟹ T leva abertos em abertos",
                Icone = "‖‖",
                Descricao = "Um operador linear contínuo e sobrejetivo entre espaços de Banach é uma aplicação aberta. Consequência: bijeção contínua entre Banach tem inversa contínua.",
                Criador = "Stefan Banach / Juliusz Schauder",
                AnoOrigin = "1929-1930",
            },
            new Formula
            {
                Id = "3_af12", Nome = "Teorema do Gráfico Fechado", Categoria = "Análise Funcional", SubCategoria = "Espaços de Banach",
                Expressao = "T:X→Y linear; gráfico fechado em X×Y ⟹ T contínuo",
                ExprTexto = "T:X→Y linear; gráfico fechado em X×Y ⟹ T contínuo",
                Icone = "‖‖",
                Descricao = "Um operador linear entre Banach cujo gráfico é fechado é automaticamente contínuo. Equivale ao Teorema da Aplicação Aberta.",
                Criador = "Stefan Banach",
                AnoOrigin = "1932",
            },
            // 1.2 Espaços de Hilbert
            new Formula
            {
                Id = "3_ah01", Nome = "Produto Interno — Axiomas", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "⟨x,y⟩: ⟨x,x⟩≥0; ⟨αx,y⟩=α⟨x,y⟩; ⟨x,y⟩=⟨y,x⟩*",
                ExprTexto = "⟨x,y⟩: ⟨x,x⟩≥0; ⟨αx,y⟩=α⟨x,y⟩; ⟨x,y⟩=⟨y,x⟩*",
                Icone = "⟨,⟩",
                Descricao = "Produto interno: positividade, linearidade no 1º argumento e simetria conjugada. Induz norma e topologia no espaço.",
                Criador = "David Hilbert",
                AnoOrigin = "~1904",
            },
            new Formula
            {
                Id = "3_ah02", Nome = "Norma Induzida pelo Produto Interno", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "||x|| = √⟨x,x⟩",
                ExprTexto = "‖x‖ = √⟨x,x⟩",
                Icone = "⟨,⟩",
                Descricao = "A norma induzida por um produto interno. Todo espaço de Hilbert é um Banach, mas nem todo Banach é Hilbert (precisa satisfazer lei do paralelogramo).",
                Criador = "David Hilbert",
                AnoOrigin = "~1904",
            },
            new Formula
            {
                Id = "3_ah03", Nome = "Desigualdade de Cauchy-Schwarz", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "|⟨x,y⟩| ≤ ||x||·||y||",
                ExprTexto = "|⟨x,y⟩| ≤ ‖x‖·‖y‖",
                Icone = "⟨,⟩",
                Descricao = "Desigualdade fundamental válida em qualquer espaço com produto interno. Igualdade ocorre se e somente se x e y são linearmente dependentes.",
                Criador = "Augustin-Louis Cauchy / Hermann Schwarz",
                AnoOrigin = "1821-1885",
            },
            new Formula
            {
                Id = "3_ah04", Nome = "Lei do Paralelogramo", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "||x+y||² + ||x-y||² = 2(||x||² + ||y||²)",
                ExprTexto = "‖x+y‖² + ‖x−y‖² = 2(‖x‖² + ‖y‖²)",
                Icone = "⟨,⟩",
                Descricao = "Caracteriza normas vindas de produto interno. Um Banach é Hilbert ⟺ a norma satisfaz esta identidade (teorema de von Neumann-Jordan).",
                Criador = "John von Neumann / Pascual Jordan",
                AnoOrigin = "1935",
            },
            new Formula
            {
                Id = "3_ah05", Nome = "Ortogonalidade", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "x ⊥ y  ⟺  ⟨x,y⟩ = 0",
                ExprTexto = "x ⊥ y  ⟺  ⟨x,y⟩ = 0",
                Icone = "⟨,⟩",
                Descricao = "Dois vetores são ortogonais quando seu produto interno é zero. Generaliza perpendicularidade euclidiana para espaços de dimensão infinita.",
                Criador = "David Hilbert",
                AnoOrigin = "~1904",
            },
            new Formula
            {
                Id = "3_ah06", Nome = "Projeção Ortogonal", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "Px = argmin_{y∈M} ||x-y||",
                ExprTexto = "Px = argmin_{y∈M} ‖x−y‖",
                Icone = "⟨,⟩",
                Descricao = "Para subespaço fechado M em Hilbert, todo vetor tem uma única melhor aproximação em M. O projetor P é linear, idempotente e autoadjunto.",
                Criador = "David Hilbert / Erhard Schmidt",
                AnoOrigin = "1907",
            },
            new Formula
            {
                Id = "3_ah07", Nome = "Teorema da Representação de Riesz", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "f∈H* ⟺ ∃!y∈H: f(x)=⟨x,y⟩",
                ExprTexto = "f∈H* ⟺ ∃!y∈H: f(x)=⟨x,y⟩",
                Icone = "⟨,⟩",
                Descricao = "Todo funcional linear contínuo em um Hilbert é representável como produto interno com um vetor único. H*≅H (isomorfismo anti-linear).",
                Criador = "Frigyes Riesz",
                AnoOrigin = "1907",
            },
            new Formula
            {
                Id = "3_ah08", Nome = "Base Ortonormal", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "{eᵢ}: ⟨eᵢ,eⱼ⟩ = δᵢⱼ",
                ExprTexto = "{eᵢ}: ⟨eᵢ,eⱼ⟩ = δᵢⱼ",
                Icone = "⟨,⟩",
                Descricao = "Conjunto ortonormal completo (base de Hilbert). Vetores são mutuamente ortogonais e normalizados. Todo Hilbert separável possui base ortonormal enumerável.",
                Criador = "Erhard Schmidt",
                AnoOrigin = "1907",
            },
            new Formula
            {
                Id = "3_ah09", Nome = "Expansão de Fourier Generalizada", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "x = Σ⟨x,eᵢ⟩eᵢ",
                ExprTexto = "x = Σ⟨x,eᵢ⟩eᵢ",
                Icone = "⟨,⟩",
                Descricao = "Todo vetor em Hilbert pode ser decomposto como série de componentes ortogonais. Os coeficientes ⟨x,eᵢ⟩ são os 'coeficientes de Fourier generalizados'.",
                Criador = "David Hilbert",
                AnoOrigin = "~1906",
            },
            new Formula
            {
                Id = "3_ah10", Nome = "Identidade de Parseval", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "||x||² = Σ|⟨x,eᵢ⟩|²",
                ExprTexto = "‖x‖² = Σ|⟨x,eᵢ⟩|²",
                Icone = "⟨,⟩",
                Descricao = "A energia total do vetor é a soma das energias de cada componente de Fourier. Generaliza o teorema de Parseval para séries de Fourier abstratas.",
                Criador = "Marc-Antoine Parseval",
                AnoOrigin = "1799 (generalizado ~1907)",
            },
            new Formula
            {
                Id = "3_ah11", Nome = "Espaço L²(a,b)", Categoria = "Análise Funcional", SubCategoria = "Espaços de Hilbert",
                Expressao = "⟨f,g⟩ = ∫ₐᵇ f(x)g*(x)dx",
                ExprTexto = "⟨f,g⟩ = ∫ₐᵇ f(x)g*(x)dx",
                Icone = "⟨,⟩",
                Descricao = "O espaço L² com produto interno dado pela integral. É o espaço de Hilbert mais importante em física quântica e análise de Fourier.",
                Criador = "Henri Lebesgue / Frigyes Riesz",
                AnoOrigin = "~1907",
            },
            // 1.3 Teoria Espectral
            new Formula
            {
                Id = "3_te01", Nome = "Operador Autoadjunto", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "⟨Ax,y⟩ = ⟨x,Ay⟩  (T*=T)",
                ExprTexto = "⟨Ax,y⟩ = ⟨x,Ay⟩  (T*=T)",
                Icone = "σ(T)",
                Descricao = "Operador igual a seu adjunto. Autovalores são reais e autovetores de autovalores distintos são ortogonais. Central em mecânica quântica (observáveis).",
                Criador = "David Hilbert",
                AnoOrigin = "~1906",
            },
            new Formula
            {
                Id = "3_te02", Nome = "Espectro de um Operador", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "σ(T) = {λ ∈ ℂ : T-λI não é invertível}",
                ExprTexto = "σ(T) = {λ ∈ ℂ : T−λI não é invertível}",
                Icone = "σ(T)",
                Descricao = "O espectro generaliza autovalores para operadores em espaços de dimensão infinita. Para autoadjuntos, σ(T)⊂ℝ.",
                Criador = "David Hilbert",
                AnoOrigin = "1906",
            },
            new Formula
            {
                Id = "3_te03", Nome = "Espectro Pontual (Autovalores)", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "Ax = λx ⟹ λ ∈ σₚ(T)",
                ExprTexto = "Ax = λx ⟹ λ ∈ σₚ(T)",
                Icone = "σ(T)",
                Descricao = "Autovalores verdadeiros onde T-λI tem núcleo não-trivial. Em dimensão finita, σ(T)=σₚ(T).",
                Criador = "David Hilbert",
                AnoOrigin = "1906",
            },
            new Formula
            {
                Id = "3_te04", Nome = "Espectro Contínuo e Residual", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "σ(T) = σₚ(T) ∪ σc(T) ∪ σr(T)",
                ExprTexto = "σ(T) = σₚ(T) ∪ σ_c(T) ∪ σ_r(T)",
                Icone = "σ(T)",
                Descricao = "O espectro decompõe-se em pontual (autovalores), contínuo (T-λI injetivo, imagem densa mas não todo H) e residual (imagem não densa).",
                Criador = "David Hilbert",
                AnoOrigin = "1906",
            },
            new Formula
            {
                Id = "3_te05", Nome = "Teorema Espectral", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "A autoadjunto ⟹ A = ∫λ dE(λ)",
                ExprTexto = "A autoadjunto ⟹ A = ∫λ dE(λ)",
                Icone = "σ(T)",
                Descricao = "Todo operador autoadjunto em Hilbert é representável como integral espectral. Generaliza diagonalização de matrizes hermitianas para dimensão infinita.",
                Criador = "David Hilbert / John von Neumann",
                AnoOrigin = "1906-1932",
            },
            new Formula
            {
                Id = "3_te06", Nome = "Operador Compacto", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "T:H→H; T leva conjuntos limitados em pré-compactos",
                ExprTexto = "T:H→H; T leva conjuntos limitados em pré-compactos",
                Icone = "σ(T)",
                Descricao = "Operador compacto mapeia a bola unitária em conjunto com fecho compacto. São limites de operadores de imagem finita (rank finito).",
                Criador = "Frigyes Riesz / David Hilbert",
                AnoOrigin = "~1907",
            },
            new Formula
            {
                Id = "3_te07", Nome = "Norma de Hilbert-Schmidt", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "||T||²_HS = Σᵢ ||Teᵢ||² < ∞",
                ExprTexto = "‖T‖²_HS = Σᵢ ‖Teᵢ‖² < ∞",
                Icone = "σ(T)",
                Descricao = "Operador de Hilbert-Schmidt: a soma dos quadrados das normas das imagens de uma base ortonormal é finita. Todo HS é compacto.",
                Criador = "Erhard Schmidt",
                AnoOrigin = "1907",
            },
            new Formula
            {
                Id = "3_te08", Nome = "Alternativa de Fredholm", Categoria = "Análise Funcional", SubCategoria = "Teoria Espectral",
                Expressao = "T compacto; σ(T)\\{0} = {autovalores discretos de multiplicidade finita}",
                ExprTexto = "T compacto; σ(T)∖{0} = {autovalores discretos de mult. finita}",
                Icone = "σ(T)",
                Descricao = "Para operadores compactos, o espectro não-nulo é enumerável, consiste apenas de autovalores de multiplicidade finita, e pode acumular somente em 0.",
                Criador = "Erik Ivar Fredholm",
                AnoOrigin = "1903",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 2. TEORIA DA MEDIDA E INTEGRAÇÃO
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaMedida()
    {
        _formulas.AddRange([
            // 2.1 σ-Álgebras e Medidas
            new Formula
            {
                Id = "3_tm01", Nome = "σ-Álgebra — Axiomas", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "F: ∅∈F; A∈F → Aᶜ∈F; Aᵢ∈F → ∪Aᵢ∈F",
                ExprTexto = "ℱ: ∅∈ℱ; A∈ℱ → Aᶜ∈ℱ; Aᵢ∈ℱ → ∪Aᵢ∈ℱ",
                Icone = "μ",
                Descricao = "Uma σ-álgebra é uma família de subconjuntos fechada para complemento e uniões enumeráveis. Contém o conjunto vazio e o espaço todo.",
                Criador = "Émile Borel / Henri Lebesgue",
                AnoOrigin = "~1901",
            },
            new Formula
            {
                Id = "3_tm02", Nome = "Medida — Axiomas", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "μ(∅)=0; μ(∪Aᵢ) = Σμ(Aᵢ) (disjuntos)",
                ExprTexto = "μ(∅)=0; μ(∪Aᵢ) = Σμ(Aᵢ)  (σ-aditividade)",
                Icone = "μ",
                Descricao = "Medida: função μ:F→[0,∞] com medida do vazio zero e σ-aditividade (soma de medidas de conjuntos disjuntos = medida da união).",
                Criador = "Henri Lebesgue",
                AnoOrigin = "1902",
            },
            new Formula
            {
                Id = "3_tm03", Nome = "Espaço de Medida (Ω,F,μ)", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "(Ω, F, μ): conjunto + σ-álgebra + medida",
                ExprTexto = "(Ω, ℱ, μ): conjunto + σ-álgebra + medida",
                Icone = "μ",
                Descricao = "Tríade fundamental: Ω é o espaço amostral, F (σ-álgebra) os conjuntos mensuráveis, μ atribui tamanho. (ℝ, Borel, Lebesgue) é o exemplo canônico.",
                Criador = "Henri Lebesgue",
                AnoOrigin = "1902",
            },
            new Formula
            {
                Id = "3_tm04", Nome = "Medida de Lebesgue em ℝ", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "m([a,b]) = b - a",
                ExprTexto = "m([a,b]) = b − a",
                Icone = "μ",
                Descricao = "A medida de Lebesgue estende o conceito de comprimento para uma classe muito mais ampla de subconjuntos de ℝ que a medida de Jordan-Riemann.",
                Criador = "Henri Lebesgue",
                AnoOrigin = "1902",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Extremo inferior", ValorPadrao = 0 },
                    new() { Simbolo = "b", Nome = "Extremo superior", ValorPadrao = 1 },
                ],
                VariavelResultado = "m([a,b])",
                Calcular = v => v["b"] - v["a"]
            },
            new Formula
            {
                Id = "3_tm05", Nome = "Medida de Borel", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "σ-álgebra gerada pelos abertos de ℝⁿ",
                ExprTexto = "ℬ(ℝⁿ) = σ(abertos de ℝⁿ)",
                Icone = "μ",
                Descricao = "A menor σ-álgebra contendo todos os conjuntos abertos. Contém abertos, fechados, compactos, Gδ, Fσ, etc.",
                Criador = "Émile Borel",
                AnoOrigin = "1898",
            },
            new Formula
            {
                Id = "3_tm06", Nome = "Medida de Contagem", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "μ({x}) = 1  ∀x",
                ExprTexto = "μ({x}) = 1  ∀x;  μ(A) = |A|",
                Icone = "μ",
                Descricao = "Atribui a cada ponto peso 1. A medida de um conjunto é seu número de elementos. A integral em relação a ela é a soma.",
                Criador = "Teoria de medida clássica",
            },
            new Formula
            {
                Id = "3_tm07", Nome = "Continuidade por cima", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "Aₙ↓A, μ(A₁)<∞ ⟹ μ(Aₙ)→μ(A)",
                ExprTexto = "Aₙ↓A, μ(A₁)<∞ ⟹ μ(Aₙ)→μ(A)",
                Icone = "μ",
                Descricao = "Para sequência decrescente de conjuntos com medida finita, a medida do limite é o limite das medidas.",
                Criador = "Henri Lebesgue",
                AnoOrigin = "~1902",
            },
            new Formula
            {
                Id = "3_tm08", Nome = "Continuidade por baixo", Categoria = "Teoria da Medida", SubCategoria = "σ-Álgebras e Medidas",
                Expressao = "Aₙ↑A ⟹ μ(Aₙ) → μ(A)",
                ExprTexto = "Aₙ↑A ⟹ μ(Aₙ) → μ(A)",
                Icone = "μ",
                Descricao = "Para sequência crescente de conjuntos, a medida converge para a medida da união. Não exige hipótese de medida finita.",
                Criador = "Henri Lebesgue",
                AnoOrigin = "~1902",
            },
            // 2.2 Integral de Lebesgue
            new Formula
            {
                Id = "3_il01", Nome = "Integral de Lebesgue — Definição (f≥0)", Categoria = "Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "∫f dμ = sup{∫s dμ : s simples, s≤f}",
                ExprTexto = "∫f dμ = sup{∫s dμ : s simples, s≤f}",
                Icone = "∫μ",
                Descricao = "Para funções mensuráveis não-negativas, a integral é definida como supremo das integrais de funções simples dominadas. Sempre existe (pode ser ∞).",
                Criador = "Henri Lebesgue",
                AnoOrigin = "1902",
            },
            new Formula
            {
                Id = "3_il02", Nome = "Integral de Lebesgue — Geral", Categoria = "Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "∫f dμ = ∫f⁺dμ - ∫f⁻dμ; f⁺=max(f,0), f⁻=max(-f,0)",
                ExprTexto = "∫f dμ = ∫f⁺dμ − ∫f⁻dμ",
                Icone = "∫μ",
                Descricao = "Decompõe f em partes positiva e negativa. A integral existe (é finita) quando ambas as partes são integráveis, i.e., f ∈ L¹.",
                Criador = "Henri Lebesgue",
                AnoOrigin = "1902",
            },
            new Formula
            {
                Id = "3_il03", Nome = "Teorema da Convergência Monótona (Beppo-Levi)", Categoria = "Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "fₙ↑f (crescente, não-neg.) ⟹ ∫fₙ → ∫f",
                ExprTexto = "fₙ↑f ⟹ ∫fₙdμ → ∫fdμ",
                Icone = "∫μ",
                Descricao = "Se funções mensuráveis não-negativas crescem pontualmente para f, as integrais convergem. Permite trocar limite com integral para sequências monótonas.",
                Criador = "Beppo Levi",
                AnoOrigin = "1906",
            },
            new Formula
            {
                Id = "3_il04", Nome = "Teorema da Convergência Dominada (Lebesgue)", Categoria = "Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "|fₙ|≤g, g∈L¹; fₙ→f q.t.p. ⟹ ∫fₙ→∫f",
                ExprTexto = "|fₙ|≤g, g∈L¹; fₙ→f q.t.p. ⟹ ∫fₙdμ→∫fdμ",
                Icone = "∫μ",
                Descricao = "O teorema mais poderoso de convergência: se fₙ converge pontualmente e é dominada por uma função integrável, então a integral do limite é o limite das integrais.",
                Criador = "Henri Lebesgue",
                AnoOrigin = "1910",
            },
            new Formula
            {
                Id = "3_il05", Nome = "Lema de Fatou", Categoria = "Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "∫ liminf fₙ ≤ liminf ∫fₙ",
                ExprTexto = "∫ liminf fₙ dμ ≤ liminf ∫fₙ dμ",
                Icone = "∫μ",
                Descricao = "Desigualdade crucial: para funções não-negativas mensuráveis, a integral do liminf é no máximo o liminf das integrais. Pode haver perda de massa no limite.",
                Criador = "Pierre Fatou",
                AnoOrigin = "1906",
            },
            new Formula
            {
                Id = "3_il06", Nome = "Teorema de Fubini", Categoria = "Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "∫∫f(x,y)dxdy = ∫(∫f(x,y)dx)dy  (f∈L¹(X×Y))",
                ExprTexto = "∫∫f dμ⊗ν = ∫(∫f dx)dy = ∫(∫f dy)dx",
                Icone = "∫μ",
                Descricao = "Se f é integrável em relação à medida produto, as integrais iteradas em qualquer ordem coincidem com a integral dupla.",
                Criador = "Guido Fubini",
                AnoOrigin = "1907",
            },
            new Formula
            {
                Id = "3_il07", Nome = "Teorema de Tonelli", Categoria = "Teoria da Medida", SubCategoria = "Integral de Lebesgue",
                Expressao = "f ≥ 0 mensurável ⟹ Fubini se aplica sem L¹",
                ExprTexto = "f ≥ 0 mensurável ⟹ ∫∫f = ∫(∫f dx)dy",
                Icone = "∫μ",
                Descricao = "Versão de Fubini para funções não-negativas: a troca de ordem é sempre permitida, sem exigir integrabilidade prévia (o resultado pode ser ∞).",
                Criador = "Leonida Tonelli",
                AnoOrigin = "1909",
            },
            // 2.3 Derivada de Radon-Nikodym
            new Formula
            {
                Id = "3_rn01", Nome = "Continuidade Absoluta (ν≪μ)", Categoria = "Teoria da Medida", SubCategoria = "Radon-Nikodym",
                Expressao = "ν ≪ μ:  μ(A)=0 ⟹ ν(A)=0",
                ExprTexto = "ν ≪ μ:  μ(A)=0 ⟹ ν(A)=0",
                Icone = "dν/dμ",
                Descricao = "ν é absolutamente contínua em relação a μ se todo conjunto de μ-medida zero tem ν-medida zero. Condição para existência de densidade.",
                Criador = "Johann Radon / Otto Nikodym",
                AnoOrigin = "1913-1930",
            },
            new Formula
            {
                Id = "3_rn02", Nome = "Teorema de Radon-Nikodym", Categoria = "Teoria da Medida", SubCategoria = "Radon-Nikodym",
                Expressao = "ν≪μ ⟹ ∃!f≥0: ν(A) = ∫_A f dμ;  f = dν/dμ",
                ExprTexto = "ν≪μ ⟹ ∃!f: ν(A)=∫_A f dμ;  f=dν/dμ",
                Icone = "dν/dμ",
                Descricao = "Se ν≪μ com μ σ-finita, existe uma 'derivada' f=dν/dμ (única q.t.p.) tal que ν se obtém integrando f em relação a μ. Fundamental em probabilidade.",
                Criador = "Johann Radon / Otto Nikodym",
                AnoOrigin = "1913-1930",
            },
            new Formula
            {
                Id = "3_rn03", Nome = "Decomposição de Lebesgue", Categoria = "Teoria da Medida", SubCategoria = "Radon-Nikodym",
                Expressao = "μ = μ_ac + μ_s  (absolutamente contínua + singular)",
                ExprTexto = "μ = μ_ac + μ_s",
                Icone = "dν/dμ",
                Descricao = "Toda medida σ-finita decompõe-se unicamente em parte absolutamente contínua (tem densidade) e parte singular em relação a outra medida.",
                Criador = "Henri Lebesgue",
                AnoOrigin = "~1910",
            },
            new Formula
            {
                Id = "3_rn04", Nome = "Espaço Dual de Lᵖ", Categoria = "Teoria da Medida", SubCategoria = "Radon-Nikodym",
                Expressao = "(Lᵖ)* ≅ Lᵍ;  1/p + 1/q = 1  (1<p<∞)",
                ExprTexto = "(Lᵖ)* ≅ Lᵍ;  1/p+1/q=1",
                Icone = "dν/dμ",
                Descricao = "O dual topológico de Lᵖ é identificado com Lᵍ (expoente conjugado). Todo funcional contínuo em Lᵖ é da forma f↦∫fg dμ com g∈Lᵍ.",
                Criador = "Frigyes Riesz",
                AnoOrigin = "~1910",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 3. TEORIA DAS CATEGORIAS
    // ─────────────────────────────────────────────────────
    private void AdicionarTeoriaCategorias()
    {
        _formulas.AddRange([
            // 3.1 Fundamentos
            new Formula
            {
                Id = "3_tc01", Nome = "Categoria — Definição", Categoria = "Teoria das Categorias", SubCategoria = "Fundamentos",
                Expressao = "C: Ob(C), Hom(A,B), composição assoc., identidades",
                ExprTexto = "C: Ob(C), Hom(A,B), ∘ associativa, id_A",
                Icone = "⇒",
                Descricao = "Uma categoria consiste de objetos, morfismos entre objetos, composição associativa e morfismos identidade. Ex.: Set (conjuntos), Grp (grupos), Top (espaços topológicos).",
                Criador = "Samuel Eilenberg / Saunders Mac Lane",
                AnoOrigin = "1945",
            },
            new Formula
            {
                Id = "3_tc02", Nome = "Funtor", Categoria = "Teoria das Categorias", SubCategoria = "Fundamentos",
                Expressao = "F:C→D: F(f∘g)=F(f)∘F(g); F(id_A)=id_{F(A)}",
                ExprTexto = "F:C→D: F(f∘g)=F(f)∘F(g); F(id_A)=id_{F(A)}",
                Icone = "⇒",
                Descricao = "Mapeamento entre categorias que preserva composição e identidades. Generaliza homomorfismo. Um funtor é 'um morfismo de categorias'.",
                Criador = "Samuel Eilenberg / Saunders Mac Lane",
                AnoOrigin = "1945",
            },
            new Formula
            {
                Id = "3_tc03", Nome = "Funtor Covariante vs Contravariante", Categoria = "Teoria das Categorias", SubCategoria = "Fundamentos",
                Expressao = "Covariante: preserva setas; Contravariante: inverte setas",
                ExprTexto = "Covariante: A→B ⟹ F(A)→F(B); Contravariante: inverte",
                Icone = "⇒",
                Descricao = "Funtor covariante preserva a direção dos morfismos. Contravariante inverte: se f:A→B, então F(f):F(B)→F(A). Ex.: dual de espaços vetoriais é contravariante.",
                Criador = "Eilenberg / Mac Lane",
                AnoOrigin = "1945",
            },
            new Formula
            {
                Id = "3_tc04", Nome = "Transformação Natural", Categoria = "Teoria das Categorias", SubCategoria = "Fundamentos",
                Expressao = "η:F⇒G; η_A:F(A)→G(A); comutatividade com morfismos",
                ExprTexto = "η:F⇒G; η_A:F(A)→G(A); G(f)∘η_A=η_B∘F(f)",
                Icone = "⇒",
                Descricao = "Família de morfismos η_A:F(A)→G(A) que comuta com todos os morfismos. Um 'morfismo de funtores'. Motivou a criação da teoria das categorias.",
                Criador = "Eilenberg / Mac Lane",
                AnoOrigin = "1945",
            },
            new Formula
            {
                Id = "3_tc05", Nome = "Isomorfismo Natural", Categoria = "Teoria das Categorias", SubCategoria = "Fundamentos",
                Expressao = "η:F⇒G isomorfismo natural ↔ η_A isomorfismo ∀A",
                ExprTexto = "η:F≅G ⟺ η_A é isomorfismo ∀A",
                Icone = "⇒",
                Descricao = "Transformação natural onde cada componente η_A é isomorfismo. Relaciona funtores de forma canônica. Ex.: V≅V** (espaço vetorial e seu bidual).",
                Criador = "Eilenberg / Mac Lane",
                AnoOrigin = "1945",
            },
            // 3.2 Construções Universais
            new Formula
            {
                Id = "3_tc06", Nome = "Produto Categórico", Categoria = "Teoria das Categorias", SubCategoria = "Construções Universais",
                Expressao = "A×B com π₁:A×B→A, π₂:A×B→B (universais)",
                ExprTexto = "A×B; π₁:A×B→A, π₂:A×B→B",
                Icone = "×",
                Descricao = "Generaliza produto cartesiano: A×B é o objeto universal com projeções. Em Set é produto cartesiano, em Grp é produto direto.",
                Criador = "Saunders Mac Lane",
                AnoOrigin = "~1950",
            },
            new Formula
            {
                Id = "3_tc07", Nome = "Coproduto (Soma)", Categoria = "Teoria das Categorias", SubCategoria = "Construções Universais",
                Expressao = "A+B com ι₁:A→A+B, ι₂:B→A+B (universais)",
                ExprTexto = "A⊔B; ι₁:A→A⊔B, ι₂:B→A⊔B",
                Icone = "+",
                Descricao = "Dual do produto: união disjunta em Set, soma livre em Grp, soma direta em Ab. A propriedade universal é 'de dentro para fora'.",
                Criador = "Saunders Mac Lane",
                AnoOrigin = "~1950",
            },
            new Formula
            {
                Id = "3_tc08", Nome = "Limite", Categoria = "Teoria das Categorias", SubCategoria = "Construções Universais",
                Expressao = "lim D = cone universal sobre diagrama D",
                ExprTexto = "lim D = cone universal sobre D",
                Icone = "lim",
                Descricao = "Generaliza produto, equalizador, pullback. É o cone terminal sobre um diagrama: todo outro cone fatora unicamente por ele.",
                Criador = "Saunders Mac Lane",
                AnoOrigin = "~1960",
            },
            new Formula
            {
                Id = "3_tc09", Nome = "Colimite", Categoria = "Teoria das Categorias", SubCategoria = "Construções Universais",
                Expressao = "colim D = cocone universal sob diagrama D",
                ExprTexto = "colim D = cocone universal sob D",
                Icone = "colim",
                Descricao = "Dual do limite. Generaliza coproduto, coequalizador, pushout. Cocone inicial sob o diagrama.",
                Criador = "Saunders Mac Lane",
                AnoOrigin = "~1960",
            },
            new Formula
            {
                Id = "3_tc10", Nome = "Adjunção (F⊣G)", Categoria = "Teoria das Categorias", SubCategoria = "Construções Universais",
                Expressao = "F⊣G ↔ Hom(FA,B) ≅ Hom(A,GB) natural em A,B",
                ExprTexto = "F⊣G ⟺ Hom(FA,B) ≅ Hom(A,GB)",
                Icone = "⊣",
                Descricao = "Par de funtores adjuntos: 'melhor aproximação' em cada direção. Fundamental em toda a matemática: livre⊣esquecimento, Σ⊣Δ⊣Π, etc.",
                Criador = "Daniel Kan",
                AnoOrigin = "1958",
            },
            new Formula
            {
                Id = "3_tc11", Nome = "Lema de Yoneda", Categoria = "Teoria das Categorias", SubCategoria = "Construções Universais",
                Expressao = "Nat(Hom(A,-),F) ≅ F(A)",
                ExprTexto = "Nat(Hom(A,−),F) ≅ F(A)",
                Icone = "Y",
                Descricao = "O resultado mais profundo da teoria: transformações naturais do funtor representável Hom(A,-) em F bijetam com F(A). 'Objects are determined by their morphisms.'",
                Criador = "Nobuo Yoneda",
                AnoOrigin = "1954",
            },
            new Formula
            {
                Id = "3_tc12", Nome = "Topos", Categoria = "Teoria das Categorias", SubCategoria = "Construções Universais",
                Expressao = "Categoria com subobject classifier Ω e exponenciais",
                ExprTexto = "Topos: classificador de subobjetos Ω + exponenciais Bᴬ",
                Icone = "Ω",
                Descricao = "Topos elementar generaliza a categoria dos conjuntos: tem produtos finitos, exponenciais e classificador de subobjetos. Base para lógica categórica e geometria algébrica.",
                Criador = "Alexander Grothendieck / F. William Lawvere",
                AnoOrigin = "1963-1970",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 4. ANÁLISE NUMÉRICA
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseNumerica()
    {
        _formulas.AddRange([
            // 4.1 Interpolação e Aproximação
            new Formula
            {
                Id = "3_an01", Nome = "Interpolação de Lagrange", Categoria = "Análise Numérica", SubCategoria = "Interpolação e Aproximação",
                Expressao = "p(x) = Σᵢ f(xᵢ)·Lᵢ(x); Lᵢ(x)=Πⱼ≠ᵢ(x-xⱼ)/(xᵢ-xⱼ)",
                ExprTexto = "p(x) = Σᵢ f(xᵢ)·Lᵢ(x)",
                Icone = "≈",
                Descricao = "Polinômio interpolante de grau ≤n passando por n+1 pontos. Os polinômios de base Lᵢ valem 1 em xᵢ e 0 nos demais nós.",
                Criador = "Joseph-Louis Lagrange",
                AnoOrigin = "1795",
                Variaveis = [
                    new() { Simbolo = "x0", Nome = "x₀", ValorPadrao = 0 },
                    new() { Simbolo = "y0", Nome = "f(x₀)", ValorPadrao = 1 },
                    new() { Simbolo = "x1", Nome = "x₁", ValorPadrao = 1 },
                    new() { Simbolo = "y1", Nome = "f(x₁)", ValorPadrao = 3 },
                    new() { Simbolo = "x", Nome = "x (avaliar)", ValorPadrao = 0.5 },
                ],
                VariavelResultado = "p(x)",
                Calcular = v => {
                    double x = v["x"];
                    double L0 = (x - v["x1"]) / (v["x0"] - v["x1"]);
                    double L1 = (x - v["x0"]) / (v["x1"] - v["x0"]);
                    return v["y0"] * L0 + v["y1"] * L1;
                }
            },
            new Formula
            {
                Id = "3_an02", Nome = "Erro da Interpolação Polinomial", Categoria = "Análise Numérica", SubCategoria = "Interpolação e Aproximação",
                Expressao = "f(x)-p(x) = f⁽ⁿ⁺¹⁾(ξ)/(n+1)! · Π(x-xᵢ)",
                ExprTexto = "f(x)−p(x) = f⁽ⁿ⁺¹⁾(ξ)/(n+1)! · Πᵢ(x−xᵢ)",
                Icone = "≈",
                Descricao = "O erro de interpolação depende da derivada (n+1)-ésima de f e do produto das distâncias aos nós. Escolha de nós (Chebyshev) minimiza o erro.",
                Criador = "Joseph-Louis Lagrange",
                AnoOrigin = "~1795",
            },
            new Formula
            {
                Id = "3_an03", Nome = "Diferenças Divididas de Newton", Categoria = "Análise Numérica", SubCategoria = "Interpolação e Aproximação",
                Expressao = "f[x₀,...,xₙ] = (f[x₁,...,xₙ]-f[x₀,...,xₙ₋₁])/(xₙ-x₀)",
                ExprTexto = "f[x₀,...,xₙ] = (f[x₁,...,xₙ]−f[x₀,...,xₙ₋₁])/(xₙ−x₀)",
                Icone = "≈",
                Descricao = "Diferenças divididas para construção recursiva do polinômio interpolador. Forma de Newton permite adicionar nós incrementalmente.",
                Criador = "Isaac Newton",
                AnoOrigin = "~1687",
            },
            new Formula
            {
                Id = "3_an04", Nome = "Spline Cúbica", Categoria = "Análise Numérica", SubCategoria = "Interpolação e Aproximação",
                Expressao = "Sᵢ(x) = aᵢ+bᵢ(x-xᵢ)+cᵢ(x-xᵢ)²+dᵢ(x-xᵢ)³",
                ExprTexto = "Sᵢ(x) = aᵢ+bᵢ(x−xᵢ)+cᵢ(x−xᵢ)²+dᵢ(x−xᵢ)³",
                Icone = "≈",
                Descricao = "Polinômio de grau 3 por pedaço com continuidade C². Evita oscilações de Runge da interpolação de grau alto. Muito usada em CAD e gráficos.",
                Criador = "Isaac Jacob Schoenberg",
                AnoOrigin = "1946",
            },
            new Formula
            {
                Id = "3_an05", Nome = "Nós de Chebyshev", Categoria = "Análise Numérica", SubCategoria = "Interpolação e Aproximação",
                Expressao = "xᵢ = cos((2i+1)π/(2n))  minimizam erro de interpolação",
                ExprTexto = "xᵢ = cos((2i+1)π/(2(n+1)))",
                Icone = "≈",
                Descricao = "Raízes dos polinômios de Chebyshev. Distribuição ótima de nós que minimiza o máximo de |Π(x-xᵢ)|, evitando fenômeno de Runge.",
                Criador = "Pafnuty Chebyshev",
                AnoOrigin = "~1854",
            },
            new Formula
            {
                Id = "3_an06", Nome = "Mínimos Quadrados (Eq. Normais)", Categoria = "Análise Numérica", SubCategoria = "Interpolação e Aproximação",
                Expressao = "AᵀAx = Aᵀb  →  min ||Ax-b||₂",
                ExprTexto = "AᵀAx = Aᵀb  →  min ‖Ax−b‖₂",
                Icone = "≈",
                Descricao = "Solução que minimiza o resíduo quadrático. As equações normais projetam b no espaço coluna de A. Condicionamento: κ(AᵀA) = κ(A)².",
                Criador = "Carl Friedrich Gauss / Adrien-Marie Legendre",
                AnoOrigin = "1795-1809",
            },
            // 4.2 Integração Numérica
            new Formula
            {
                Id = "3_an07", Nome = "Regra do Trapézio", Categoria = "Análise Numérica", SubCategoria = "Integração Numérica",
                Expressao = "∫ₐᵇf ≈ h/2·(f(a)+2f(x₁)+...+2f(xₙ₋₁)+f(b))",
                ExprTexto = "∫ₐᵇf ≈ h/2·(f(a)+2Σf(xᵢ)+f(b))",
                Icone = "≈",
                Descricao = "Aproxima a integral por soma de áreas de trapézios. Ordem de convergência O(h²). Surpreendentemente eficaz para funções periódicas.",
                Criador = "Método clássico; formalizado por Euler e Newton-Cotes",
                AnoOrigin = "~1700",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 },
                    new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 },
                    new() { Simbolo = "fa", Nome = "f(a)", ValorPadrao = 0 },
                    new() { Simbolo = "fb", Nome = "f(b)", ValorPadrao = 1 },
                ],
                VariavelResultado = "∫f",
                Calcular = v => (v["b"] - v["a"]) / 2.0 * (v["fa"] + v["fb"])
            },
            new Formula
            {
                Id = "3_an08", Nome = "Erro do Trapézio", Categoria = "Análise Numérica", SubCategoria = "Integração Numérica",
                Expressao = "E = -(b-a)h²f''(ξ)/12",
                ExprTexto = "E = −(b−a)h²f″(ξ)/12",
                Icone = "≈",
                Descricao = "O erro é proporcional a h² e à segunda derivada de f. Funções com f''=0 (lineares) são integradas exatamente.",
                Criador = "Análise de erro Newton-Cotes",
            },
            new Formula
            {
                Id = "3_an09", Nome = "Regra de Simpson 1/3", Categoria = "Análise Numérica", SubCategoria = "Integração Numérica",
                Expressao = "∫ₐᵇf ≈ h/3·(f(a)+4f(m)+f(b));  h=(b-a)/2",
                ExprTexto = "∫ₐᵇf ≈ h/3·(f(a)+4f(m)+f(b))",
                Icone = "≈",
                Descricao = "Aproximação parabólica. Exata para polinômios até grau 3. Erro O(h⁴) — muito mais precisa que o trapézio com mesmo número de pontos.",
                Criador = "Thomas Simpson",
                AnoOrigin = "1743",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 },
                    new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 },
                    new() { Simbolo = "fa", Nome = "f(a)", ValorPadrao = 0 },
                    new() { Simbolo = "fm", Nome = "f(m)", Descricao = "Valor no ponto médio", ValorPadrao = 0.5 },
                    new() { Simbolo = "fb", Nome = "f(b)", ValorPadrao = 1 },
                ],
                VariavelResultado = "∫f",
                Calcular = v => {
                    double h = (v["b"] - v["a"]) / 2.0;
                    return h / 3.0 * (v["fa"] + 4 * v["fm"] + v["fb"]);
                }
            },
            new Formula
            {
                Id = "3_an10", Nome = "Erro de Simpson", Categoria = "Análise Numérica", SubCategoria = "Integração Numérica",
                Expressao = "E = -(b-a)h⁴f⁽⁴⁾(ξ)/180",
                ExprTexto = "E = −(b−a)h⁴f⁽⁴⁾(ξ)/180",
                Icone = "≈",
                Descricao = "Erro proporcional a h⁴ e à quarta derivada. Polinômios de grau ≤3 são integrados exatamente (precisão superior à esperada).",
                Criador = "Thomas Simpson / Análise de erro",
            },
            new Formula
            {
                Id = "3_an11", Nome = "Quadratura de Gauss-Legendre", Categoria = "Análise Numérica", SubCategoria = "Integração Numérica",
                Expressao = "∫₋₁¹f ≈ Σᵢwᵢf(xᵢ);  exato para grau ≤ 2n-1",
                ExprTexto = "∫₋₁¹f ≈ Σᵢwᵢf(xᵢ)",
                Icone = "≈",
                Descricao = "Escolhe nós e pesos otimamente: com n pontos, integra exatamente polinômios de grau até 2n-1. Nós são raízes dos polinômios de Legendre.",
                Criador = "Carl Friedrich Gauss",
                AnoOrigin = "1814",
            },
            new Formula
            {
                Id = "3_an12", Nome = "Extrapolação de Romberg", Categoria = "Análise Numérica", SubCategoria = "Integração Numérica",
                Expressao = "R(n,m) = (4ᵐR(n,m-1) - R(n-1,m-1))/(4ᵐ-1)",
                ExprTexto = "R(n,m) = (4ᵐR(n,m−1) − R(n−1,m−1))/(4ᵐ−1)",
                Icone = "≈",
                Descricao = "Combina regras do trapézio com diferentes passos h para eliminar termos de erro sucessivos. Converge rapidamente para funções suaves.",
                Criador = "Werner Romberg",
                AnoOrigin = "1955",
            },
            // 4.3 EDOs Numéricas
            new Formula
            {
                Id = "3_an13", Nome = "Método de Euler Explícito", Categoria = "Análise Numérica", SubCategoria = "EDOs Numéricas",
                Expressao = "yₙ₊₁ = yₙ + h·f(tₙ,yₙ)",
                ExprTexto = "yₙ₊₁ = yₙ + h·f(tₙ,yₙ)",
                Icone = "≈",
                Descricao = "Método mais simples para EDOs. Aproximação de 1ª ordem: segue a tangente por um passo h. Erro local O(h²), global O(h).",
                Criador = "Leonhard Euler",
                AnoOrigin = "1768",
                Variaveis = [
                    new() { Simbolo = "yn", Nome = "yₙ (estado atual)", ValorPadrao = 1 },
                    new() { Simbolo = "h", Nome = "Passo h", ValorPadrao = 0.1, ValorMin = 0.001 },
                    new() { Simbolo = "fn", Nome = "f(tₙ,yₙ)", Descricao = "Valor da derivada", ValorPadrao = -1 },
                ],
                VariavelResultado = "yₙ₊₁",
                Calcular = v => v["yn"] + v["h"] * v["fn"]
            },
            new Formula
            {
                Id = "3_an14", Nome = "Runge-Kutta 4ª Ordem (RK4)", Categoria = "Análise Numérica", SubCategoria = "EDOs Numéricas",
                Expressao = "yₙ₊₁ = yₙ + (k₁+2k₂+2k₃+k₄)/6",
                ExprTexto = "yₙ₊₁ = yₙ + (k₁+2k₂+2k₃+k₄)/6",
                Icone = "RK4",
                Descricao = "O método de referência para EDOs. Avalia a derivada em 4 pontos. Erro local O(h⁵), global O(h⁴). Ótimo equilíbrio custo/precisão.",
                Criador = "Carl Runge / Martin Kutta",
                AnoOrigin = "1901",
            },
            new Formula
            {
                Id = "3_an15", Nome = "RK4 — Etapas k₁ e k₂", Categoria = "Análise Numérica", SubCategoria = "EDOs Numéricas",
                Expressao = "k₁=hf(tₙ,yₙ); k₂=hf(tₙ+h/2, yₙ+k₁/2)",
                ExprTexto = "k₁=hf(tₙ,yₙ); k₂=hf(tₙ+h/2, yₙ+k₁/2)",
                Icone = "RK4",
                Descricao = "Primeira e segunda avaliação: k₁ é inclinação no início, k₂ é inclinação no ponto médio usando k₁ como predição.",
                Criador = "Runge / Kutta",
                AnoOrigin = "1901",
            },
            new Formula
            {
                Id = "3_an16", Nome = "RK4 — Etapas k₃ e k₄", Categoria = "Análise Numérica", SubCategoria = "EDOs Numéricas",
                Expressao = "k₃=hf(tₙ+h/2, yₙ+k₂/2); k₄=hf(tₙ+h, yₙ+k₃)",
                ExprTexto = "k₃=hf(tₙ+h/2, yₙ+k₂/2); k₄=hf(tₙ+h, yₙ+k₃)",
                Icone = "RK4",
                Descricao = "Terceira e quarta avaliação: k₃ refina o ponto médio com k₂, k₄ usa k₃ para avaliar no final do intervalo.",
                Criador = "Runge / Kutta",
                AnoOrigin = "1901",
            },
            new Formula
            {
                Id = "3_an17", Nome = "RK4 — Fórmula de Atualização", Categoria = "Análise Numérica", SubCategoria = "EDOs Numéricas",
                Expressao = "yₙ₊₁ = yₙ + (k₁+2k₂+2k₃+k₄)/6",
                ExprTexto = "yₙ₊₁ = yₙ + (k₁+2k₂+2k₃+k₄)/6",
                Icone = "RK4",
                Descricao = "Média ponderada: k₁ e k₄ com peso 1/6, k₂ e k₃ com peso 1/3. A ponderação vem da quadratura de Simpson aplicada à integral da ODE.",
                Criador = "Runge / Kutta",
                AnoOrigin = "1901",
            },
            new Formula
            {
                Id = "3_an18", Nome = "Adams-Bashforth 4 Passos", Categoria = "Análise Numérica", SubCategoria = "EDOs Numéricas",
                Expressao = "yₙ₊₁ = yₙ + (h/24)(55fₙ-59fₙ₋₁+37fₙ₋₂-9fₙ₋₃)",
                ExprTexto = "yₙ₊₁ = yₙ + (h/24)(55fₙ−59fₙ₋₁+37fₙ₋₂−9fₙ₋₃)",
                Icone = "≈",
                Descricao = "Método multi-passo explícito de 4ª ordem. Usa 4 valores anteriores da derivada. Mais eficiente que RK4 para problemas suaves (1 avaliação por passo).",
                Criador = "John Couch Adams / Francis Bashforth",
                AnoOrigin = "1883",
            },
            new Formula
            {
                Id = "3_an19", Nome = "Estabilidade Absoluta", Categoria = "Análise Numérica", SubCategoria = "EDOs Numéricas",
                Expressao = "h·λ deve pertencer à região de estabilidade do método",
                ExprTexto = "h·λ ∈ região de estabilidade ⟹ |yₙ| limitado",
                Icone = "≈",
                Descricao = "Para y'=λy (λ<0), o método numérico é estável se hλ está na região de estabilidade. Impõe restrição no passo h. Métodos implícitos têm regiões maiores.",
                Criador = "Germund Dahlquist",
                AnoOrigin = "1956",
            },
            // 4.4 Álgebra Linear Numérica e Elementos Finitos
            new Formula
            {
                Id = "3_an20", Nome = "Gradiente Conjugado", Categoria = "Análise Numérica", SubCategoria = "Álgebra Linear Numérica",
                Expressao = "xₖ₊₁ = xₖ+αₖdₖ;  αₖ = rₖᵀrₖ/(dₖᵀAdₖ)",
                ExprTexto = "xₖ₊₁ = xₖ+αₖdₖ;  αₖ = rₖᵀrₖ/(dₖᵀAdₖ)",
                Icone = "≈",
                Descricao = "Resolve Ax=b (A simétrica definida positiva) em no máximo n passos. Conjuga direções de busca para convergência ótima. O mais eficiente método iterativo para SPD.",
                Criador = "Magnus Hestenes / Eduard Stiefel",
                AnoOrigin = "1952",
            },
            new Formula
            {
                Id = "3_an21", Nome = "GMRES", Categoria = "Análise Numérica", SubCategoria = "Álgebra Linear Numérica",
                Expressao = "min ||b-Axₖ|| no subespaço de Krylov Kₖ(A,r₀)",
                ExprTexto = "xₖ ∈ x₀+Kₖ:  min ‖b−Axₖ‖",
                Icone = "≈",
                Descricao = "Minimiza o resíduo no subespaço de Krylov. Funciona para matrizes não-simétricas. Padrão para sistemas lineares grandes esparsos.",
                Criador = "Yousef Saad / Martin Schultz",
                AnoOrigin = "1986",
            },
            new Formula
            {
                Id = "3_an22", Nome = "Número de Condição", Categoria = "Análise Numérica", SubCategoria = "Álgebra Linear Numérica",
                Expressao = "κ(A) = ||A||·||A⁻¹|| = σ_max/σ_min",
                ExprTexto = "κ(A) = ‖A‖·‖A⁻¹‖ = σ_max/σ_min",
                Icone = "κ",
                Descricao = "Mede a sensibilidade da solução a perturbações nos dados. κ grande = mal condicionado. Perda de dígitos significativos ≈ log₁₀(κ).",
                Criador = "Alan Turing / John von Neumann",
                AnoOrigin = "~1948",
                Variaveis = [
                    new() { Simbolo = "smax", Nome = "σ_max", Descricao = "Maior valor singular", ValorPadrao = 10, ValorMin = 0.001 },
                    new() { Simbolo = "smin", Nome = "σ_min", Descricao = "Menor valor singular", ValorPadrao = 0.01, ValorMin = 0.001 },
                ],
                VariavelResultado = "κ(A)",
                Calcular = v => v["smax"] / v["smin"]
            },
            new Formula
            {
                Id = "3_an23", Nome = "Formulação Fraca (FEM)", Categoria = "Análise Numérica", SubCategoria = "Elementos Finitos",
                Expressao = "a(u,v) = L(v) ∀v∈V;  a(u,v)=∫∇u·∇v dΩ;  L(v)=∫fv dΩ",
                ExprTexto = "a(u,v) = L(v) ∀v∈V",
                Icone = "FEM",
                Descricao = "A formulação variacional transforma a EDP em encontrar u tal que a forma bilinear a(u,v) iguala o funcional L(v) para toda função teste v.",
                Criador = "Alexander Hrennikoff / Richard Courant",
                AnoOrigin = "1941-1943",
            },
            new Formula
            {
                Id = "3_an24", Nome = "Método de Galerkin", Categoria = "Análise Numérica", SubCategoria = "Elementos Finitos",
                Expressao = "u_h = Σcⱼφⱼ;  Kc = f;  Kᵢⱼ = a(φⱼ,φᵢ)",
                ExprTexto = "u_h = Σcⱼφⱼ;  Kc = f",
                Icone = "FEM",
                Descricao = "Aproxima u no subespaço de dimensão finita Vₕ. Resulta em sistema linear Kc=f onde K é a matriz de rigidez e f o vetor de carga.",
                Criador = "Boris Galerkin",
                AnoOrigin = "1915",
            },
            new Formula
            {
                Id = "3_an25", Nome = "Estimativa de Erro FEM", Categoria = "Análise Numérica", SubCategoria = "Elementos Finitos",
                Expressao = "||u-u_h||_H¹ ≤ Chᵏ||u||_H^(k+1)",
                ExprTexto = "‖u−u_h‖_H¹ ≤ Chᵏ‖u‖_Hᵏ⁺¹",
                Icone = "FEM",
                Descricao = "A taxa de convergência em H¹ é O(hᵏ) para elementos de grau k. Dobrando a malha (h/2) reduz o erro por fator 2ᵏ. Teoria de Céa-Strang.",
                Criador = "Jean Céa / Gilbert Strang",
                AnoOrigin = "1964-1972",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 5. GEOMETRIA ALGÉBRICA E CURVAS ELÍPTICAS
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaAlgebrica()
    {
        _formulas.AddRange([
            // 5.1 Variedades Algébricas
            new Formula
            {
                Id = "3_ga01", Nome = "Variedade Afim", Categoria = "Geometria Algébrica", SubCategoria = "Variedades Algébricas",
                Expressao = "V(I) = {x∈kⁿ : f(x)=0 ∀f∈I}",
                ExprTexto = "V(I) = {x∈kⁿ : f(x)=0 ∀f∈I}",
                Icone = "∩",
                Descricao = "O conjunto de zeros comuns de um ideal de polinômios. Curvas, superfícies e variedades de dimensão superior são exemplos.",
                Criador = "David Hilbert / André Weil",
                AnoOrigin = "~1890-1946",
            },
            new Formula
            {
                Id = "3_ga02", Nome = "Ideal de Variedade", Categoria = "Geometria Algébrica", SubCategoria = "Variedades Algébricas",
                Expressao = "I(V) = {f∈k[x₁,...,xₙ] : f(x)=0 ∀x∈V}",
                ExprTexto = "I(V) = {f∈k[x] : f|_V=0}",
                Icone = "∩",
                Descricao = "Correspondência variedade→ideal: o conjunto de todos os polinômios que se anulam na variedade V. É sempre um ideal radical.",
                Criador = "David Hilbert",
                AnoOrigin = "~1893",
            },
            new Formula
            {
                Id = "3_ga03", Nome = "Nullstellensatz de Hilbert", Categoria = "Geometria Algébrica", SubCategoria = "Variedades Algébricas",
                Expressao = "I(V(I)) = √I  (radical do ideal)",
                ExprTexto = "I(V(I)) = √I",
                Icone = "∩",
                Descricao = "O 'teorema dos zeros': a correspondência V↔I estabelece bijeção entre variedades e ideais radicais. Ponte fundamental entre álgebra e geometria.",
                Criador = "David Hilbert",
                AnoOrigin = "1893",
            },
            new Formula
            {
                Id = "3_ga04", Nome = "Dimensão de Variedade", Categoria = "Geometria Algébrica", SubCategoria = "Variedades Algébricas",
                Expressao = "dim V = grau de transcendência do corpo de funções",
                ExprTexto = "dim V = tr.deg_k k(V)",
                Icone = "∩",
                Descricao = "A dimensão algébrica é o grau de transcendência do corpo de funções racionais sobre k. Coincide com a dimensão topológica para variedades suaves.",
                Criador = "Alexander Grothendieck / Emmy Noether",
            },
            new Formula
            {
                Id = "3_ga05", Nome = "Teorema de Bézout", Categoria = "Geometria Algébrica", SubCategoria = "Variedades Algébricas",
                Expressao = "|V(f)∩V(g)| = deg(f)·deg(g)  (contando multiplicidades)",
                ExprTexto = "|V(f)∩V(g)| = deg(f)·deg(g)",
                Icone = "∩",
                Descricao = "Duas curvas planas de graus d e e se intersectam em exatamente d·e pontos no plano projetivo, contando multiplicidades. Ex.: reta cruza cônica em 2 pontos.",
                Criador = "Étienne Bézout",
                AnoOrigin = "1779",
                Variaveis = [
                    new() { Simbolo = "d", Nome = "deg(f)", Descricao = "Grau da 1ª curva", ValorPadrao = 2, ValorMin = 1 },
                    new() { Simbolo = "e", Nome = "deg(g)", Descricao = "Grau da 2ª curva", ValorPadrao = 3, ValorMin = 1 },
                ],
                VariavelResultado = "Interseções",
                Calcular = v => v["d"] * v["e"]
            },
            new Formula
            {
                Id = "3_ga06", Nome = "Gênero de Curva Plana Lisa", Categoria = "Geometria Algébrica", SubCategoria = "Variedades Algébricas",
                Expressao = "g = (d-1)(d-2)/2",
                ExprTexto = "g = (d−1)(d−2)/2",
                Icone = "∩",
                Descricao = "Uma curva plana não-singular de grau d tem gênero (d-1)(d-2)/2. Ex.: reta g=0, cônica g=0, cúbica g=1, quártica g=3.",
                Criador = "Bernhard Riemann / Max Noether",
                AnoOrigin = "~1857",
                Variaveis = [
                    new() { Simbolo = "d", Nome = "Grau d", ValorPadrao = 3, ValorMin = 1 },
                ],
                VariavelResultado = "Gênero g",
                Calcular = v => (v["d"] - 1) * (v["d"] - 2) / 2.0
            },
            // 5.2 Curvas Elípticas
            new Formula
            {
                Id = "3_ce01", Nome = "Curva Elíptica — Forma de Weierstrass", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "y² = x³ + ax + b",
                ExprTexto = "y² = x³ + ax + b",
                Icone = "E",
                Descricao = "Forma padrão de uma curva elíptica. É uma curva de gênero 1 com um ponto base (grupo abeliano). Fundamental em criptografia e teoria dos números.",
                Criador = "Karl Weierstrass",
                AnoOrigin = "~1860",
            },
            new Formula
            {
                Id = "3_ce02", Nome = "Discriminante de Curva Elíptica", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "Δ = -16(4a³+27b²) ≠ 0  (não-singular)",
                ExprTexto = "Δ = −16(4a³+27b²) ≠ 0",
                Icone = "E",
                Descricao = "Para a curva ser não-singular (elíptica), o discriminante deve ser não-nulo. Δ=0 implica ponto singular (cúspide ou nó).",
                Criador = "Teoria clássica de curvas",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Coeficiente a", ValorPadrao = -1 },
                    new() { Simbolo = "b", Nome = "Coeficiente b", ValorPadrao = 1 },
                ],
                VariavelResultado = "Δ",
                Calcular = v => -16.0 * (4 * Math.Pow(v["a"], 3) + 27 * Math.Pow(v["b"], 2))
            },
            new Formula
            {
                Id = "3_ce03", Nome = "Adição em Curva Elíptica", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "P+Q = R; R = -(reta PQ ∩ E) via corda-tangente",
                ExprTexto = "P+Q = R via método corda-tangente",
                Icone = "E",
                Descricao = "A reta passando por P e Q intersecta E num terceiro ponto; refletindo-o sobre o eixo x obtemos P+Q. Esta operação forma um grupo abeliano.",
                Criador = "Henri Poincaré",
                AnoOrigin = "~1901",
            },
            new Formula
            {
                Id = "3_ce04", Nome = "Inclinação da Corda (P≠Q)", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "λ = (y₂-y₁)/(x₂-x₁)",
                ExprTexto = "λ = (y₂−y₁)/(x₂−x₁)",
                Icone = "E",
                Descricao = "Inclinação da reta secante passando por dois pontos distintos da curva. Usada no cálculo de P+Q.",
                Criador = "Método da corda",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", ValorPadrao = 0 },
                    new() { Simbolo = "y1", Nome = "y₁", ValorPadrao = 1 },
                    new() { Simbolo = "x2", Nome = "x₂", ValorPadrao = 1 },
                    new() { Simbolo = "y2", Nome = "y₂", ValorPadrao = 1 },
                ],
                VariavelResultado = "λ",
                Calcular = v => (v["y2"] - v["y1"]) / (v["x2"] - v["x1"])
            },
            new Formula
            {
                Id = "3_ce05", Nome = "Inclinação da Tangente (P=Q)", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "λ = (3x₁²+a)/(2y₁)",
                ExprTexto = "λ = (3x₁²+a)/(2y₁)",
                Icone = "E",
                Descricao = "Inclinação da tangente à curva em P, usada para calcular P+P=2P (duplicação de ponto). Derivada implícita de y²=x³+ax+b.",
                Criador = "Cálculo diferencial aplicado",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", ValorPadrao = 1 },
                    new() { Simbolo = "y1", Nome = "y₁", ValorPadrao = 1 },
                    new() { Simbolo = "a", Nome = "a", ValorPadrao = -1 },
                ],
                VariavelResultado = "λ",
                Calcular = v => (3 * v["x1"] * v["x1"] + v["a"]) / (2 * v["y1"])
            },
            new Formula
            {
                Id = "3_ce06", Nome = "Coordenadas do Ponto Soma", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "x₃ = λ²-x₁-x₂;  y₃ = λ(x₁-x₃)-y₁",
                ExprTexto = "x₃ = λ²−x₁−x₂;  y₃ = λ(x₁−x₃)−y₁",
                Icone = "E",
                Descricao = "Fórmulas explícitas para as coordenadas de P+Q a partir de λ. x₃ vem de Vieta; y₃ da equação da reta substituída na curva.",
                Criador = "Aritmética de curvas elípticas",
            },
            new Formula
            {
                Id = "3_ce07", Nome = "Grupo E(k)", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "(E,+) é grupo abeliano com O (ponto no infinito) como identidade",
                ExprTexto = "(E(k),+) grupo abeliano; O = identidade",
                Icone = "E",
                Descricao = "Os pontos de uma curva elíptica sobre um corpo k formam um grupo abeliano com a adição geométrica. O ponto no infinito é a identidade.",
                Criador = "Henri Poincaré",
                AnoOrigin = "~1901",
            },
            new Formula
            {
                Id = "3_ce08", Nome = "Teorema de Mordell-Weil", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "E(ℚ) é grupo abeliano finitamente gerado",
                ExprTexto = "E(ℚ) ≅ ℤʳ ⊕ E(ℚ)_tors",
                Icone = "E",
                Descricao = "Os pontos racionais de uma curva elíptica formam grupo finitamente gerado: parte livre de rank r (possivelmente 0) + subgrupo de torção finito.",
                Criador = "Louis Mordell / André Weil",
                AnoOrigin = "1922-1928",
            },
            new Formula
            {
                Id = "3_ce09", Nome = "Rank de Curva Elíptica", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "E(ℚ) ≅ ℤʳ ⊕ E(ℚ)_tors;  r = rank",
                ExprTexto = "r = rank de E(ℚ)",
                Icone = "E",
                Descricao = "O rank r mede quantos pontos racionais independentes geram o grupo. r=0 significa finitos pontos racionais. A conjectura de Birch-Swinnerton-Dyer relaciona r com L(E,s).",
                Criador = "Louis Mordell",
                AnoOrigin = "1922",
            },
            new Formula
            {
                Id = "3_ce10", Nome = "ECDLP — Problema do Log Discreto Elíptico", Categoria = "Geometria Algébrica", SubCategoria = "Curvas Elípticas",
                Expressao = "Dado P, Q=kP; encontrar k é computacionalmente difícil",
                ExprTexto = "Q=kP ⟹ encontrar k é exponencialmente difícil",
                Icone = "🔐",
                Descricao = "Base da criptografia de curvas elípticas (ECC). Multiplicação k·P é rápida (O(log k)) mas inverter é exponencial. Permite chaves menores que RSA para mesma segurança.",
                Criador = "Neal Koblitz / Victor Miller",
                AnoOrigin = "1985",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 6. LÓGICA MATEMÁTICA E TEORIA DOS MODELOS
    // ─────────────────────────────────────────────────────
    private void AdicionarLogicaMatematica()
    {
        _formulas.AddRange([
            // 6.1 Lógica de Primeira Ordem
            new Formula
            {
                Id = "3_lm01", Nome = "Sintaxe da Lógica de 1ª Ordem", Categoria = "Lógica Matemática", SubCategoria = "Lógica de Primeira Ordem",
                Expressao = "∀x φ(x); ∃x φ(x); φ∧ψ; φ∨ψ; ¬φ; φ→ψ",
                ExprTexto = "∀x φ(x); ∃x φ(x); φ∧ψ; φ∨ψ; ¬φ; φ→ψ",
                Icone = "⊢",
                Descricao = "Os blocos da lógica de 1ª ordem: quantificadores (∀,∃), conectivos lógicos (∧,∨,¬,→), variáveis, constantes, funções e predicados.",
                Criador = "Gottlob Frege",
                AnoOrigin = "1879",
            },
            new Formula
            {
                Id = "3_lm02", Nome = "Semântica (Satisfação)", Categoria = "Lógica Matemática", SubCategoria = "Lógica de Primeira Ordem",
                Expressao = "M ⊨ φ  (M é modelo de φ)",
                ExprTexto = "M ⊨ φ  (M satisfaz φ)",
                Icone = "⊨",
                Descricao = "M⊨φ significa que a fórmula φ é verdadeira na estrutura M (modelo). A semântica de Tarski atribui verdade relativa a interpretações.",
                Criador = "Alfred Tarski",
                AnoOrigin = "1933",
            },
            new Formula
            {
                Id = "3_lm03", Nome = "Completude de Gödel", Categoria = "Lógica Matemática", SubCategoria = "Lógica de Primeira Ordem",
                Expressao = "⊢ φ  ⟺  ⊨ φ  (provável ↔ válido)",
                ExprTexto = "⊢ φ  ⟺  ⊨ φ",
                Icone = "⊢",
                Descricao = "Uma fórmula é provável no cálculo de predicados se e somente se é verdadeira em todos os modelos. Conecta sintaxe (prova) e semântica (verdade).",
                Criador = "Kurt Gödel",
                AnoOrigin = "1929",
            },
            new Formula
            {
                Id = "3_lm04", Nome = "Compacidade", Categoria = "Lógica Matemática", SubCategoria = "Lógica de Primeira Ordem",
                Expressao = "T ⊨ φ  ⟺  ∃T₀⊂T finito: T₀ ⊨ φ",
                ExprTexto = "T ⊨ φ  ⟺  ∃T₀⊆T finito: T₀ ⊨ φ",
                Icone = "⊨",
                Descricao = "Uma teoria tem modelo se e somente se todo subconjunto finito tem modelo. Permite construir modelos infinitos e provar existência via consistência finita.",
                Criador = "Kurt Gödel (consequência da completude)",
                AnoOrigin = "1930",
            },
            new Formula
            {
                Id = "3_lm05", Nome = "Löwenheim-Skolem", Categoria = "Lógica Matemática", SubCategoria = "Lógica de Primeira Ordem",
                Expressao = "Teoria com modelo infinito ⟹ tem modelos de toda cardinalidade",
                ExprTexto = "T tem modelo infinito ⟹ T tem modelos de todo cardinal κ≥|T|",
                Icone = "⊨",
                Descricao = "Uma teoria de 1ª ordem com modelo infinito tem modelos de todos os cardinais infinitos. A lógica de 1ª ordem não pode distinguir entre infinitos de tamanhos diferentes.",
                Criador = "Leopold Löwenheim / Thoralf Skolem",
                AnoOrigin = "1915-1920",
            },
            // 6.2 Incompletude de Gödel
            new Formula
            {
                Id = "3_gd01", Nome = "1º Teorema de Incompletude de Gödel", Categoria = "Lógica Matemática", SubCategoria = "Incompletude de Gödel",
                Expressao = "T consistente + recursiva + contendo PA ⟹ ∃φ indecidível em T",
                ExprTexto = "T cons. + rec. + PA ⟹ ∃φ: T⊬φ e T⊬¬φ",
                Icone = "⊬",
                Descricao = "Qualquer sistema formal consistente capaz de expressar aritmética básica contém sentenças verdadeiras que não podem ser provadas nem refutadas dentro do sistema.",
                Criador = "Kurt Gödel",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "3_gd02", Nome = "2º Teorema de Incompletude de Gödel", Categoria = "Lógica Matemática", SubCategoria = "Incompletude de Gödel",
                Expressao = "T consistente ⟹ T ⊬ Con(T)",
                ExprTexto = "T consistente ⟹ T não prova sua própria consistência",
                Icone = "⊬",
                Descricao = "Um sistema consistente não pode provar sua própria consistência. Encerrou o programa de Hilbert de fundamentar toda a matemática, mostrando limites inerentes de sistemas formais.",
                Criador = "Kurt Gödel",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "3_gd03", Nome = "Número de Gödel", Categoria = "Lógica Matemática", SubCategoria = "Incompletude de Gödel",
                Expressao = "⌈φ⌉ = codificação de fórmulas como inteiros",
                ExprTexto = "⌈φ⌉ : fórmula → ℕ (gödelização)",
                Icone = "⌈⌉",
                Descricao = "Cada fórmula e prova é codificada unicamente como número natural. Permite que a aritmética 'fale sobre' suas próprias fórmulas — chave para auto-referência.",
                Criador = "Kurt Gödel",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "3_gd04", Nome = "Sentença de Gödel (Auto-referência)", Categoria = "Lógica Matemática", SubCategoria = "Incompletude de Gödel",
                Expressao = "G ↔ ¬Prov(⌈G⌉)",
                ExprTexto = "G ↔ ¬Prov(⌈G⌉)  ('G diz: eu não sou provável')",
                Icone = "G",
                Descricao = "A sentença G afirma 'eu não tenho prova em T'. Se T é consistente, G é verdadeira mas indemonstrável. Análoga ao paradoxo do mentiroso, porém sobre provabilidade.",
                Criador = "Kurt Gödel",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "3_gd05", Nome = "Teorema de Tarski (Indefinibilidade da Verdade)", Categoria = "Lógica Matemática", SubCategoria = "Incompletude de Gödel",
                Expressao = "Verdade aritmética não é definível na própria aritmética",
                ExprTexto = "¬∃ fórmula True(x) em PA que capture verdade aritmética",
                Icone = "⊬",
                Descricao = "Não existe fórmula na linguagem da aritmética que defina exatamente o conjunto das sentenças verdadeiras. Mais forte que Gödel: verdade é mais 'complexa' que provabilidade.",
                Criador = "Alfred Tarski",
                AnoOrigin = "1936",
            },
        ]);
    }
}
