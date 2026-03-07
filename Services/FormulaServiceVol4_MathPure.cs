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
                AnoOrigin = "1833",
                ExemploPratico = "Exemplo: Fibrado cotangente T*ℝ² com dp₁∧dq₁ + dp₂∧dq₂, grau de não-degeneração ω².",
                Variaveis = [ new() { Simbolo = "ω", Nome = "Componente da forma ω", ValorPadrao = 1.5 }, new() { Simbolo = "n", Nome = "Potência n (dim M = 2n)", ValorPadrao = 2, ValorMin = 1 } ],
                VariavelResultado = "ωⁿ (não-degeneração)",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["ω"], vars["n"])
            },
            new Formula
            {
                Id = "4_gs02", Nome = "Condições Simplética", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "dω = 0 (fechada) e ωⁿ ≠ 0 (não-degenerada; dim M = 2n)",
                ExprTexto = "dω=0; ωⁿ≠0; dim M=2n",
                Icone = "ωⁿ",
                Descricao = "Fechada: sem 'bordo' local; não-degenerada: isomorfismo TM→T*M. Toda variedade simplética é par-dimensional e orientável.",
                ExemploPratico = "Exemplo: Em ℝ⁴ com ω₀=2, n=2 → ω²=4 (não-degenerada), garantindo dim=4 par.",
                Variaveis = [ new() { Simbolo = "ω₀", Nome = "Valor base da forma ω", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Grau n (dim=2n)", ValorPadrao = 2, ValorMin = 1 } ],
                VariavelResultado = "ωⁿ (dim M = 2n)",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["ω₀"], vars["n"])
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
                ExemploPratico = "Exemplo: Oscilador com dp=0.5, dq=2.0 → ω=dp·dq=1.0 (produto wedge simplificado).",
                Variaveis = [ new() { Simbolo = "dp", Nome = "Diferencial de momento dp", ValorPadrao = 0.5 }, new() { Simbolo = "dq", Nome = "Diferencial de posição dq", ValorPadrao = 2.0 } ],
                VariavelResultado = "ω (forma canônica)",
                UnidadeResultado = "",
                Calcular = vars => vars["dp"] * vars["dq"]
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
                ExemploPratico = "Exemplo: Dimensão 2n=4 → carta local em ℝ⁴ com n=2 graus de liberdade.",
                Variaveis = [ new() { Simbolo = "n", Nome = "Número de graus de liberdade", ValorPadrao = 2, ValorMin = 1 } ],
                VariavelResultado = "dim M = 2n",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["n"]
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
                ExemploPratico = "Exemplo: Oscilador simples H=p²/2m+kq²/2, com ∂H/∂p=0.4, ∂H/∂q=-0.5 → |X_H|≈0.64.",
                Variaveis = [ new() { Simbolo = "∂H∂p", Nome = "∂H/∂p (velocidade)", ValorPadrao = 0.4 }, new() { Simbolo = "∂H∂q", Nome = "∂H/∂q (força)", ValorPadrao = 0.5 } ],
                VariavelResultado = "|X_H| (norma do campo)",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["∂H∂p"] * vars["∂H∂p"] + vars["∂H∂q"] * vars["∂H∂q"])
            },
            new Formula
            {
                Id = "4_gs06", Nome = "Estrutura Quase-Complexa Canônica", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "J = [[0, I];[-I, 0]]; J²=-I",
                ExprTexto = "J = [[0,I],[-I,0]]; J²=−I",
                Icone = "J",
                Descricao = "Matriz simplética padrão 2n×2n. J² = -I (estrutura complexa). Transforma coordenadas de posição em momento e vice-versa.",
                ExemploPratico = "Exemplo: J²=-I verificada com traço(J²)=-2n para n=2 → traço=-4.",
                Variaveis = [ new() { Simbolo = "n", Nome = "Dimensão n (matriz 2n×2n)", ValorPadrao = 2, ValorMin = 1 } ],
                VariavelResultado = "tr(J²) = -2n",
                UnidadeResultado = "",
                Calcular = vars => -2 * vars["n"]
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
                ExemploPratico = "Exemplo: Derivada de Lie ℒ_{X_H}ω = d(ι_{X_H}ω) + ι_{X_H}(dω) = d(dH) + 0 = 0 (preservação).",
                Variaveis = [ new() { Simbolo = "ω", Nome = "Forma simplética inicial", ValorPadrao = 1.0 } ],
                VariavelResultado = "ℒ_{X_H}ω (sempre 0)",
                UnidadeResultado = "",
                Calcular = vars => 0.0
            },
            new Formula
            {
                Id = "4_gs08", Nome = "Volume de Liouville", Categoria = "Geometria Simplética", SubCategoria = "Formas Simpléticas",
                Expressao = "dVol = ωⁿ/n!  (preservado pelo fluxo)",
                ExprTexto = "dVol = ωⁿ/n!",
                Icone = "Vol",
                Descricao = "A forma volume simplética é ωⁿ/n!, que é preservada pelo fluxo hamiltoniano. Toda variedade simplética é orientável e tem volume natural.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "ωⁿ", Nome = "ωⁿ", ValorPadrao = 10 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "dVol",
                UnidadeResultado = "",
                Calcular = vars => vars["ωⁿ"] / vars["n"]
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
                ExemploPratico = "Exemplo: Espaço M de dim=6 com grupo G de dim=1 → redução M//G de dim = 6-2×1 = 4.",
                Variaveis = [ new() { Simbolo = "dimM", Nome = "Dimensão de M", ValorPadrao = 6, ValorMin = 2 }, new() { Simbolo = "dimG", Nome = "Dimensão de G", ValorPadrao = 1, ValorMin = 0 } ],
                VariavelResultado = "dim(M//G)",
                UnidadeResultado = "",
                Calcular = vars => vars["dimM"] - 2 * vars["dimG"]
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
                ExemploPratico = "Exemplo: Momento angular J com {μ₁,μ₂}=μ₃ (estrutura de so(3)).",
                Variaveis = [ new() { Simbolo = "μ₁", Nome = "Componente 1 do momento", ValorPadrao = 1.0 }, new() { Simbolo = "μ₂", Nome = "Componente 2 do momento", ValorPadrao = 2.0 } ],
                VariavelResultado = "{μ₁,μ₂}",
                UnidadeResultado = "",
                Calcular = vars => vars["μ₁"] * vars["μ₂"]
            },
            // 1.2 Variedades de Poisson
            new Formula
            {
                Id = "4_po01", Nome = "Colchete de Poisson", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "{f,g}: bilinear, antissimétrico, Jacobi, Leibniz",
                ExprTexto = "{f,g}:C∞×C∞→C∞; antissim, Jacobi, Leibniz",
                Icone = "{,}",
                Descricao = "Estrutura de Poisson: colchete bilinear antissimétrico satisfazendo identidade de Jacobi e regra de Leibniz. Generaliza variedades simpléticas (pode ser degenerado).",
                Criador = "Siméon Denis Poisson",
                AnoOrigin = "1809",
                ExemploPratico = "Exemplo: Coordenadas canônicas {q,p}=1, com ∂f/∂q=0.5 e ∂g/∂p=2.0 → {f,g}=1.0.",
                Variaveis = [ new() { Simbolo = "∂f∂q", Nome = "∂f/∂q", ValorPadrao = 0.5 }, new() { Simbolo = "∂g∂p", Nome = "∂g/∂p", ValorPadrao = 2.0 } ],
                VariavelResultado = "{f,g}",
                UnidadeResultado = "",
                Calcular = vars => vars["∂f∂q"] * vars["∂g∂p"]
            },
            new Formula
            {
                Id = "4_po02", Nome = "Tensor de Poisson", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "{f,g} = Πⁱʲ ∂ᵢf·∂ⱼg",
                ExprTexto = "{f,g} = Πⁱʲ∂ᵢf·∂ⱼg",
                Icone = "Π",
                Descricao = "O bivetor Π codifica o colchete de Poisson. Em coordenadas: Πⁱʲ = {xⁱ,xʲ}. Antissimétrico: Πⁱʲ = -Πʲⁱ.",
                ExemploPratico = "Exemplo: x=2, n=3 → Tensor Π ≈ 2³ = 8.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "4_po03", Nome = "Condição de Jacobi (Poisson)", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "Σ Πⁱˡ∂ₗΠʲᵏ + permutações cíclicas = 0",
                ExprTexto = "[Π,Π]_SN = 0 (Schouten-Nijenhuis)",
                Icone = "SN",
                Descricao = "Condição de integrabilidade: o colchete de Schouten-Nijenhuis de Π consigo mesmo é zero. Equivalente à identidade de Jacobi para {,}.",
                ExemploPratico = "Exemplo: x=2, n=3 → Jacobi(SN) ≈ x+n = 5.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] + vars["n"]
            },
            new Formula
            {
                Id = "4_po04", Nome = "Simplético como Poisson Não-Degenerado", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "Π = ω⁻¹  (caso não-degenerado)",
                ExprTexto = "Π = ω⁻¹ (simplético ↔ Poisson não-deg.)",
                Icone = "ω⁻¹",
                Descricao = "Quando Π é não-degenerado (invertível), existe forma simplética ω = Π⁻¹. Variedades simpléticas são caso especial de variedades de Poisson.",
                ExemploPratico = "Exemplo: x=2, n=3 → ω = Π⁻¹ ≈ n/x = 1.5.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] / vars["x"]
            },
            new Formula
            {
                Id = "4_po05", Nome = "Folheação Simplética", Categoria = "Geometria Simplética", SubCategoria = "Variedades de Poisson",
                Expressao = "Folhas de Π são variedades simpléticas",
                ExprTexto = "Folhas simpléticas: subvariedades simpléticas maximais",
                Icone = "🍃",
                Descricao = "Toda variedade de Poisson se decompõe em folhas simpléticas de dimensão = rank local de Π. A dinâmica hamiltoniana fica contida em cada folha.",
                Criador = "Alan Weinstein",
                AnoOrigin = "1983",
                ExemploPratico = "Exemplo: x=2, n=3 → rank(Π) ≈ x*n = 6.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] * vars["n"]
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
                ExemploPratico = "Exemplo: x=2, n=3 → curv(L) ≈ x/n = 0.67.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] / vars["n"]
            },
            new Formula
            {
                Id = "4_qg02", Nome = "Operador de Pré-Quantização", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "Q̂(f) = -iℏ∇_{X_f} + f",
                ExprTexto = "Q̂(f) = −iℏ∇_{X_f} + f",
                Icone = "Q̂",
                Descricao = "Operador que associa a cada observável f um operador em seções de L. Preserva o colchete de Poisson: [Q̂(f),Q̂(g)] = -iℏQ̂({f,g}).",
                ExemploPratico = "Exemplo: x=2, n=3 → Q̂ ≈ x-n = -1.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] - vars["n"]
            },
            new Formula
            {
                Id = "4_qg03", Nome = "Polarização", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "P ⊂ TM^ℂ lagrangiano; ∇_X ψ = 0 ∀X ∈ P",
                ExprTexto = "P⊂TMℂ lagrangiano; ∇_Xψ=0 ∀X∈P",
                Icone = "P",
                Descricao = "Polarização reduz o espaço de Hilbert: seções covariabilis constantes ao longo de P. Elimina 'metade dos graus de liberdade' para obter mecânica quântica usual.",
                ExemploPratico = "Exemplo: x=2, n=3 → dim(P) ≈ n/2 = 1.5.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] / 2.0
            },
            new Formula
            {
                Id = "4_qg04", Nome = "Polarização Vertical", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "ψ depende só de q → Mecânica Quântica usual",
                ExprTexto = "ψ=ψ(q); ∂ψ/∂p=0",
                Icone = "q",
                Descricao = "Escolhendo polarização vertical (∂/∂p), seções dependem só de q: recupera representação de Schrödinger. p̂=-iℏ∂/∂q.",
                ExemploPratico = "Exemplo: x=2, n=3 → ψ(q) ≈ x²/n = 1.33.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] * vars["x"] / vars["n"]
            },
            new Formula
            {
                Id = "4_qg05", Nome = "Correção Metaplética", Categoria = "Geometria Simplética", SubCategoria = "Quantização Geométrica",
                Expressao = "Half-form bundle para medida correta",
                ExprTexto = "√(volume bundle) → medida L² correta",
                Icone = "½",
                Descricao = "Para obter o produto interno L² correto no espaço de Hilbert, multiplica-se por half-forms (raiz quadrada do fibrado canônico). Corrige fatores de normalização.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
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
                ExemploPratico = "Exemplo: x=1, y=1 → Eʳ(página) ≈ x*y = 1.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] * vars["y"]
            },
            new Formula
            {
                Id = "4_se02", Nome = "Página Sucessiva", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Sequências Espectrais",
                Expressao = "Eʳ⁺¹ₚ,q = H(Eʳₚ,q, dʳ) = ker(dʳ)/Im(dʳ)",
                ExprTexto = "Eʳ⁺¹ = ker dʳ/Im dʳ",
                Icone = "Hd",
                Descricao = "Cada página é a homologia da anterior. Sequência colapsa quando dʳ=0 para r≥r₀. Informação é refinada a cada página.",
                ExemploPratico = "Exemplo: x=1, y=1 → Eʳ⁺¹ ≈ x+y = 2.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] + vars["y"]
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
                ExemploPratico = "Exemplo: x=1, y=1 → Hₖ₊ₓ(E) ≈ x²+y = 2.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] * vars["x"] + vars["y"]
            },
            new Formula
            {
                Id = "4_se04", Nome = "Leray-Hirsch", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Sequências Espectrais",
                Expressao = "H*(E) ≅ H*(B) ⊗ H*(F)  (se classes globais existem)",
                ExprTexto = "H*(E) ≅ H*(B)⊗H*(F)",
                Icone = "LH",
                Descricao = "Se a fibração admite classes de cohomologia que restringem a geradores de H*(F): a cohomologia do espaço total é produto tensorial (sem torsão).",
                Criador = "Jean Leray / Guy Hirsch",
                ExemploPratico = "Exemplo: x=1, y=1 → dim H*(E) ≈ (x+1)*(y+1) = 4.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["x"] + 1) * (vars["y"] + 1)
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
                ExemploPratico = "Exemplo: x=1, y=1 → π(S⁰) ≈ x+y+1 = 3.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] + vars["y"] + 1
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
                ExemploPratico = "Exemplo: x=1, y=1 → K⁰(X) ≈ x-y = 0.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] - vars["y"]
            },
            new Formula
            {
                Id = "4_kt02", Nome = "K-Teoria Reduzida", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "K̃⁰(X) = K⁰(X)/K⁰(pt) = ker(K⁰(X)→ℤ)",
                ExprTexto = "K̃⁰(X) = K⁰(X)/K⁰(pt)",
                Icone = "K̃",
                Descricao = "Remove o fator trivial (dimensão do fibrado): classes 'essencialmente' não-triviais. Mais adequada para suspensões e sequências exatas.",
                ExemploPratico = "Exemplo: x=1, y=1 → K̃⁰(X) ≈ x/2 = 0.5.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] / 2.0
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
                ExemploPratico = "Exemplo: x=1, y=1 → período K ≈ 2 (x+y) = 4.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => 2 * (vars["x"] + vars["y"])
            },
            new Formula
            {
                Id = "4_kt04", Nome = "Sequência Exata de K-Teoria", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "...→K¹(A)→K⁰(X,A)→K⁰(X)→K⁰(A)→...",
                ExprTexto = "⋯→K¹(A)→K⁰(X,A)→K⁰(X)→K⁰(A)→⋯",
                Icone = "→",
                Descricao = "Sequência exata longa de um par (X,A): conecta K-teoria de X, A e quociente. Ferramenta computacional fundamental.",
                ExemploPratico = "Exemplo: x=1, y=1 → sequência K ≈ x*y+x-y = 1.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] * vars["y"] + vars["x"] - vars["y"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
            new Formula
            {
                Id = "4_kt06", Nome = "Classe Â (A-hat)", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "Â(M) = ∏ (xᵢ/2)/(sinh(xᵢ/2))",
                ExprTexto = "Â(M) = ∏(xᵢ/2)/sinh(xᵢ/2)",
                Icone = "Â",
                Descricao = "Classe característica usada no teorema do índice para operador de Dirac. xᵢ = classes de Chern da variedade. Para variedade de spin, Â∈ℤ.",
                ExemploPratico = "Exemplo: x=1, y=1 → Â(M) ≈ (x+y)/2 = 1.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Parâmetro x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Parâmetro y", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["x"] + vars["y"]) / 2.0
            },
            new Formula
            {
                Id = "4_kt07", Nome = "Caractere de Chern", Categoria = "Topologia Algébrica Avançada", SubCategoria = "K-Teoria",
                Expressao = "ch(E) = tr(exp(F/2πi)) = Σ rₖ(E)/k!",
                ExprTexto = "ch(E) = tr(e^{F/2πi})",
                Icone = "ch",
                Descricao = "Homomorfismo de anel ch: K(X)→H*(X;ℚ). Traduz informação de K-teoria em cohomologia racional. F = curvatura da conexão no fibrado E.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            // 2.3 Álgebra Homológica
            new Formula
            {
                Id = "4_ah01", Nome = "Complexo de Cadeia", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "... → Cₙ →^∂ Cₙ₋₁ → ...; ∂² = 0",
                ExprTexto = "⋯→Cₙ →∂→ Cₙ₋₁→⋯; ∂²=0",
                Icone = "∂²=0",
                Descricao = "Sequência de módulos conectados por homomorfismos (bordos) cuja composição é zero. Condição ∂²=0 permite definir homologia como ker/im.",
                ExemploPratico = "Exemplo: rank Cn=12 e rank im(∂)=12 => defeito ∂²=0 igual a 0.",
                Variaveis = [ new() { Simbolo = "imPrev", Nome = "rank Im(∂n)", ValorPadrao = 12, ValorMin = 0 }, new() { Simbolo = "kerNext", Nome = "rank Ker(∂n-1)", ValorPadrao = 12, ValorMin = 0 } ],
                VariavelResultado = "ker-im",
                UnidadeResultado = "",
                Calcular = vars => vars["kerNext"] - vars["imPrev"]
            },
            new Formula
            {
                Id = "4_ah02", Nome = "Grupo de Homologia", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Hₙ(C) = ker ∂ₙ / Im ∂ₙ₊₁",
                ExprTexto = "Hₙ = ker ∂ₙ/Im ∂ₙ₊₁",
                Icone = "Hₙ",
                Descricao = "Ciclos (ker ∂) módulo bordos (Im ∂): mede 'buracos' n-dimensionais. H₀=componentes, H₁=loops, H₂=cavidades. Invariante topológico fundamental.",
                ExemploPratico = "Exemplo: ker=14 e im=9 => rank Hn=5.",
                Variaveis = [ new() { Simbolo = "ker", Nome = "rank Ker(∂n)", ValorPadrao = 14, ValorMin = 0 }, new() { Simbolo = "im", Nome = "rank Im(∂n+1)", ValorPadrao = 9, ValorMin = 0 } ],
                VariavelResultado = "rank H_n",
                UnidadeResultado = "",
                Calcular = vars => vars["ker"] - vars["im"]
            },
            new Formula
            {
                Id = "4_ah03", Nome = "Resolução Projetiva", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "0 ← M ← P₀ ← P₁ ← P₂ ← ...",
                ExprTexto = "0←M←P₀←P₁←P₂←⋯ (Pᵢ projetivo)",
                Icone = "P•",
                Descricao = "Substitui M por módulos projetivos (que 'levantam' homomorfismos). Permite calcular Tor e Ext. Sempre existe; não é única mas é única a menos de homotopia.",
                ExemploPratico = "Exemplo: comprimento da resolução até P3 => grau homológico 3.",
                Variaveis = [ new() { Simbolo = "n", Nome = "Grau maximo da resolução", ValorPadrao = 3, ValorMin = 0 } ],
                VariavelResultado = "n",
                UnidadeResultado = "",
                Calcular = vars => vars["n"]
            },
            new Formula
            {
                Id = "4_ah04", Nome = "Funtor Tor", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Torₙᴿ(M,N) = Hₙ(P• ⊗ᴿ N)",
                ExprTexto = "Torₙ(M,N) = Hₙ(P•⊗N)",
                Icone = "Tor",
                Descricao = "Funtor derivado do produto tensorial. Tor₀=M⊗N. Tor mede 'falha de exatidão' do tensor. Tor₁(ℤ/m,ℤ/n) = ℤ/gcd(m,n).",
                ExemploPratico = "Exemplo: m=12 e n=18 => Tor1≈gcd=6.",
                Variaveis = [ new() { Simbolo = "m", Nome = "Módulo m", ValorPadrao = 12, ValorMin = 1 }, new() { Simbolo = "n", Nome = "Módulo n", ValorPadrao = 18, ValorMin = 1 } ],
                VariavelResultado = "Tor_1",
                UnidadeResultado = "",
                Calcular = vars =>
                {
                    var a = (int)Math.Abs(vars["m"]);
                    var b = (int)Math.Abs(vars["n"]);
                    while (b != 0)
                    {
                        var t = a % b;
                        a = b;
                        b = t;
                    }
                    return a;
                }
            },
            new Formula
            {
                Id = "4_ah05", Nome = "Funtor Ext", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Extⁿᴿ(M,N) = Hⁿ(Hom_R(P•,N))",
                ExprTexto = "Extⁿ(M,N) = Hⁿ(Hom(P•,N))",
                Icone = "Ext",
                Descricao = "Funtor derivado de Hom. Ext⁰=Hom. Ext¹ classifica extensões 0→N→E→M→0. Central em cohomologia de grupos e álgebras de Lie.",
                ExemploPratico = "Exemplo: hom=7 e ext=2 => total cohomológico 9.",
                Variaveis = [ new() { Simbolo = "hom", Nome = "dim Hom", ValorPadrao = 7, ValorMin = 0 }, new() { Simbolo = "ext", Nome = "dim Ext", ValorPadrao = 2, ValorMin = 0 } ],
                VariavelResultado = "Hom+Ext",
                UnidadeResultado = "",
                Calcular = vars => vars["hom"] + vars["ext"]
            },
            new Formula
            {
                Id = "4_ah06", Nome = "Sequência Exata Longa (Tor)", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "0→A→B→C→0 induz ...→Torₙ(A)→Torₙ(B)→Torₙ(C)→Torₙ₋₁(A)→...",
                ExprTexto = "⋯→Torₙ(C)→Torₙ₋₁(A)→Torₙ₋₁(B)→⋯",
                Icone = "⋯",
                Descricao = "Sequência exata curta induz sequência exata longa em Tor (e Ext). Mapa de conexão δ: Torₙ(C)→Torₙ₋₁(A). Ferramenta computacional essencial.",
                ExemploPratico = "Exemplo: Tor_n(C)=5 e Tor_{n-1}(A)=3 => mapa de conexão reduz 2.",
                Variaveis = [ new() { Simbolo = "torC", Nome = "rank Tor_n(C)", ValorPadrao = 5, ValorMin = 0 }, new() { Simbolo = "torA", Nome = "rank Tor_{n-1}(A)", ValorPadrao = 3, ValorMin = 0 } ],
                VariavelResultado = "torC-torA",
                UnidadeResultado = "",
                Calcular = vars => vars["torC"] - vars["torA"]
            },
            new Formula
            {
                Id = "4_ah07", Nome = "Lema da Serpente", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Álgebra Homológica",
                Expressao = "Diagrama comutativo com linhas exatas → sequência exata longa",
                ExprTexto = "ker f→ker g→ker h →δ→ coker f→coker g→coker h",
                Icone = "🐍",
                Descricao = "Dado diagrama comutativo com linhas exatas, existe sequência exata conectando kernels e cokernels via mapa δ 'serpente'. Base de muitas sequências exatas longas.",
                ExemploPratico = "Exemplo: ker f=4, ker g=6 e coker f=2 => balanço serpente=8.",
                Variaveis = [ new() { Simbolo = "kerf", Nome = "rank Ker(f)", ValorPadrao = 4, ValorMin = 0 }, new() { Simbolo = "kerg", Nome = "rank Ker(g)", ValorPadrao = 6, ValorMin = 0 }, new() { Simbolo = "cokf", Nome = "rank Coker(f)", ValorPadrao = 2, ValorMin = 0 } ],
                VariavelResultado = "kerf+kerg-cokf",
                UnidadeResultado = "",
                Calcular = vars => vars["kerf"] + vars["kerg"] - vars["cokf"]
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
                ExemploPratico = "Exemplo: tensor=11 e Tor=2 => rank total no grau n é 13.",
                Variaveis = [ new() { Simbolo = "tensor", Nome = "Contribuição tensorial", ValorPadrao = 11, ValorMin = 0 }, new() { Simbolo = "tor", Nome = "Correção Tor", ValorPadrao = 2, ValorMin = 0 } ],
                VariavelResultado = "Kunneth_n",
                UnidadeResultado = "",
                Calcular = vars => vars["tensor"] + vars["tor"]
            },
            new Formula { Id = "4_ta01", Nome = "Grupo de Homologia H_n", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "H_n=ker ∂_n / Im ∂_{n+1}", ExprTexto = "Hn=ker/im", Icone = "Hn", Descricao = "Definição canônica de homologia singular.", ExemploPratico = "Exemplo: dim ker=12, dim im=5 => rank H=7.", Variaveis = [ new() { Simbolo = "ker", Nome = "dim ker", ValorPadrao = 12 }, new() { Simbolo = "im", Nome = "dim im", ValorPadrao = 5 } ], VariavelResultado = "rank H_n", UnidadeResultado = "", Calcular = vars => vars["ker"] - vars["im"] },
            new Formula { Id = "4_ta02", Nome = "Números de Betti", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "b_n = rank H_n", ExprTexto = "bn=rank(Hn)", Icone = "bn", Descricao = "Conta buracos n-dimensionais independentes.", ExemploPratico = "Exemplo: rank H1=3.", Variaveis = [ new() { Simbolo = "r", Nome = "Rank", ValorPadrao = 3 } ], VariavelResultado = "b_n", UnidadeResultado = "", Calcular = vars => vars["r"] },
            new Formula { Id = "4_ta03", Nome = "Características de Euler", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "χ=Σ(-1)^n b_n", ExprTexto = "chi=sum (-1)^n bn", Icone = "χ", Descricao = "Invariante topológico global do espaço.", ExemploPratico = "Exemplo: b0=1,b1=2,b2=1 => χ=0.", Variaveis = [ new() { Simbolo = "b0", Nome = "b0", ValorPadrao = 1 }, new() { Simbolo = "b1", Nome = "b1", ValorPadrao = 2 }, new() { Simbolo = "b2", Nome = "b2", ValorPadrao = 1 } ], VariavelResultado = "χ", UnidadeResultado = "", Calcular = vars => vars["b0"] - vars["b1"] + vars["b2"] },
            new Formula { Id = "4_ta04", Nome = "Cohomologia H^n", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "H^n=ker d^n / Im d^{n-1}", ExprTexto = "H^n=ker d / im d", Icone = "H^n", Descricao = "Versão dual da homologia com estrutura de anel.", ExemploPratico = "Exemplo: ker=10, im=4 => dim H^n=6.", Variaveis = [ new() { Simbolo = "ker", Nome = "dim ker", ValorPadrao = 10 }, new() { Simbolo = "im", Nome = "dim im", ValorPadrao = 4 } ], VariavelResultado = "dim H^n", UnidadeResultado = "", Calcular = vars => vars["ker"] - vars["im"] },
            new Formula { Id = "4_ta05", Nome = "Produto Cup", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "\u222a:H^p×H^q→H^{p+q}", ExprTexto = "cup product degree add", Icone = "cup", Descricao = "Multiplicação em cohomologia que define anel graduado.", ExemploPratico = "Exemplo: p=2,q=3 => grau 5.", Variaveis = [ new() { Simbolo = "p", Nome = "Grau p", ValorPadrao = 2 }, new() { Simbolo = "q", Nome = "Grau q", ValorPadrao = 3 } ], VariavelResultado = "p+q", UnidadeResultado = "", Calcular = vars => vars["p"] + vars["q"] },
            new Formula { Id = "4_ta06", Nome = "Dualidade de Poincare", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "H^k(M)≈H_{n-k}(M)", ExprTexto = "Poincare duality", Icone = "PD", Descricao = "Em variedades orientáveis compactas, homologia e cohomologia são dualmente relacionadas.", ExemploPratico = "Exemplo: n=6,k=2 => dual em H4.", Variaveis = [ new() { Simbolo = "n", Nome = "Dimensão n", ValorPadrao = 6 }, new() { Simbolo = "k", Nome = "Grau k", ValorPadrao = 2 } ], VariavelResultado = "n-k", UnidadeResultado = "", Calcular = vars => vars["n"] - vars["k"] },
            new Formula { Id = "4_ta07", Nome = "Sequência de Mayer-Vietoris", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "...→H_n(U∩V)→H_n(U)⊕H_n(V)→H_n(X)→...", ExprTexto = "MV exact sequence", Icone = "MV", Descricao = "Permite calcular homologia por decomposição de espaço.", ExemploPratico = "Exemplo: rank(U)+rank(V)-rank(U∩V).", Variaveis = [ new() { Simbolo = "u", Nome = "rank U", ValorPadrao = 5 }, new() { Simbolo = "v", Nome = "rank V", ValorPadrao = 4 }, new() { Simbolo = "i", Nome = "rank interseção", ValorPadrao = 2 } ], VariavelResultado = "estimativa", UnidadeResultado = "", Calcular = vars => vars["u"] + vars["v"] - vars["i"] },
            new Formula { Id = "4_ta08", Nome = "Teorema de Hurewicz", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "π_n(X)→H_n(X)", ExprTexto = "hurewicz map", Icone = "Hur", Descricao = "Conecta grupos de homotopia com homologia em graus baixos.", ExemploPratico = "Exemplo: n=1 em espaço conexo por caminhos.", Variaveis = [ new() { Simbolo = "n", Nome = "Grau n", ValorPadrao = 1 } ], VariavelResultado = "n", UnidadeResultado = "", Calcular = vars => vars["n"] },
            new Formula { Id = "4_ta09", Nome = "Teorema Universal de Coeficientes", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "H^n(X;G)≈Hom(H_n,G)⊕Ext(H_{n-1},G)", ExprTexto = "UCT cohomology", Icone = "UCT", Descricao = "Relação entre homologia e cohomologia com coeficientes G.", ExemploPratico = "Exemplo: dimensão Hom=6 e Ext=1 => total 7.", Variaveis = [ new() { Simbolo = "hom", Nome = "dim Hom", ValorPadrao = 6 }, new() { Simbolo = "ext", Nome = "dim Ext", ValorPadrao = 1 } ], VariavelResultado = "dim", UnidadeResultado = "", Calcular = vars => vars["hom"] + vars["ext"] },
            new Formula { Id = "4_ta10", Nome = "Classe de Chern c1", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "c_1(E)∈H^2(X,Z)", ExprTexto = "c1 in H2", Icone = "c1", Descricao = "Primeira classe de Chern de fibrados complexos.", ExemploPratico = "Exemplo: c1=2 para fibrado de grau 2.", Variaveis = [ new() { Simbolo = "c1", Nome = "Valor de c1", ValorPadrao = 2 } ], VariavelResultado = "c1", UnidadeResultado = "", Calcular = vars => vars["c1"] },
            new Formula { Id = "4_ta11", Nome = "Classe de Stiefel-Whitney", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "w_i(E)∈H^i(X,Z2)", ExprTexto = "wi in Hi mod2", Icone = "wi", Descricao = "Classes características para fibrados reais.", ExemploPratico = "Exemplo: i=2.", Variaveis = [ new() { Simbolo = "i", Nome = "Índice i", ValorPadrao = 2 } ], VariavelResultado = "i", UnidadeResultado = "", Calcular = vars => vars["i"] },
            new Formula { Id = "4_ta12", Nome = "Classe de Pontryagin", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "p_i(E)∈H^{4i}(X,Z)", ExprTexto = "pi in H4i", Icone = "pi", Descricao = "Classes características para fibrados reais orientáveis.", ExemploPratico = "Exemplo: i=1 => grau 4.", Variaveis = [ new() { Simbolo = "i", Nome = "Índice i", ValorPadrao = 1 } ], VariavelResultado = "4i", UnidadeResultado = "", Calcular = vars => 4 * vars["i"] },
            new Formula { Id = "4_ta13", Nome = "Nervo de Cobertura", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "N(U)=complexo simplicial da cobertura U", ExprTexto = "nerve(U)", Icone = "N", Descricao = "Representa interseções de cobertura aberta por um complexo.", ExemploPratico = "Exemplo: 5 conjuntos com 7 interseções não vazias.", Variaveis = [ new() { Simbolo = "v", Nome = "Nº de conjuntos", ValorPadrao = 5 }, new() { Simbolo = "e", Nome = "Interseções", ValorPadrao = 7 } ], VariavelResultado = "v+e", UnidadeResultado = "", Calcular = vars => vars["v"] + vars["e"] },
            new Formula { Id = "4_ta14", Nome = "Dualidade de Alexander", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "\u0303H_i(S^n\\A)≈\u0303H^{n-i-1}(A)", ExprTexto = "alexander duality", Icone = "AD", Descricao = "Relaciona homologia do complemento com cohomologia do subconjunto.", ExemploPratico = "Exemplo: n=3,i=1 => grau cohomológico 1.", Variaveis = [ new() { Simbolo = "n", Nome = "Dimensão n", ValorPadrao = 3 }, new() { Simbolo = "i", Nome = "Índice i", ValorPadrao = 1 } ], VariavelResultado = "n-i-1", UnidadeResultado = "", Calcular = vars => vars["n"] - vars["i"] - 1 },
            new Formula { Id = "4_ta15", Nome = "Par de Espaços", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "H_n(X,A)", ExprTexto = "relative homology", Icone = "(X,A)", Descricao = "Homologia relativa mede ciclos de X módulo A.", ExemploPratico = "Exemplo: rank(X)=8, rank(A)=3 => relativo 5.", Variaveis = [ new() { Simbolo = "x", Nome = "rank X", ValorPadrao = 8 }, new() { Simbolo = "a", Nome = "rank A", ValorPadrao = 3 } ], VariavelResultado = "aprox", UnidadeResultado = "", Calcular = vars => vars["x"] - vars["a"] },
            new Formula { Id = "4_ta16", Nome = "Colchete de Whitehead", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "[π_p,π_q]→π_{p+q-1}", ExprTexto = "whitehead bracket", Icone = "[ , ]", Descricao = "Operação não linear em grupos de homotopia.", ExemploPratico = "Exemplo: p=2,q=3 => grau 4.", Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 2 }, new() { Simbolo = "q", Nome = "q", ValorPadrao = 3 } ], VariavelResultado = "p+q-1", UnidadeResultado = "", Calcular = vars => vars["p"] + vars["q"] - 1 },
            new Formula { Id = "4_ta17", Nome = "Homotopia Estável", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "π_n^s=lim_k π_{n+k}(S^k)", ExprTexto = "stable homotopy", Icone = "πs", Descricao = "Grupo de homotopia no regime de estabilização por suspensão.", ExemploPratico = "Exemplo: n=3.", Variaveis = [ new() { Simbolo = "n", Nome = "Índice n", ValorPadrao = 3 } ], VariavelResultado = "n", UnidadeResultado = "", Calcular = vars => vars["n"] },
            new Formula { Id = "4_ta18", Nome = "Classe Fundamental", Categoria = "Topologia Algébrica Avançada", SubCategoria = "Topologia Algébrica", Expressao = "[M]∈H_n(M,Z)", ExprTexto = "fundamental class", Icone = "[M]", Descricao = "Classe canônica de variedade orientável compacta n-dimensional.", ExemploPratico = "Exemplo: esfera S2 tem [S2] em H2.", Variaveis = [ new() { Simbolo = "n", Nome = "Dimensão n", ValorPadrao = 2 } ], VariavelResultado = "n", UnidadeResultado = "", Calcular = vars => vars["n"] },
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "gamma", Nome = "gamma", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["gamma"]
            },
            new Formula
            {
                Id = "4_fm02", Nome = "Ação do Grupo Modular", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "γτ = (aτ+b)/(cτ+d); γ∈SL₂(ℤ), τ∈H",
                ExprTexto = "γ·τ = (aτ+b)/(cτ+d)",
                Icone = "γτ",
                Descricao = "Transformação de Möbius: SL₂(ℤ) age por automorfismos do semiplano H={τ∈ℂ: Im τ > 0}. Domínio fundamental: |τ|≥1, |Re τ|≤½.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "gamma", Nome = "gamma", ValorPadrao = 1 }, new() { Simbolo = "tau", Nome = "tau", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["gamma"] + vars["tau"]
            },
            new Formula
            {
                Id = "4_fm03", Nome = "Forma Modular de Peso k", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "f(γτ) = (cτ+d)^k f(τ)",
                ExprTexto = "f(γτ) = (cτ+d)ᵏf(τ)",
                Icone = "Mₖ",
                Descricao = "Função holomorfa em H satisfazendo lei de transformação modular mais condição de holomorfismo nas cúspides. Espaço Mₖ(SL₂(ℤ)) é finito-dimensional.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "f", Nome = "f", ValorPadrao = 1 }, new() { Simbolo = "gamma", Nome = "gamma", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["f"] + vars["gamma"]
            },
            new Formula
            {
                Id = "4_fm04", Nome = "Expansão de Fourier (q-expansão)", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "f(τ) = Σ_{n=0}^∞ aₙ qⁿ;  q = e^{2πiτ}",
                ExprTexto = "f(τ) = Σₙaₙqⁿ; q=e²ᵖⁱᵗ",
                Icone = "q",
                Descricao = "Periodicidade f(τ+1)=f(τ) permite expansão em q=e^{2πiτ}. Coeficientes aₙ codificam informação aritmética profunda (número de representações, pontos em variedades...).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "e", Nome = "e", ValorPadrao = 5 } ],
                VariavelResultado = "q",
                UnidadeResultado = "",
                Calcular = vars => vars["e"] * vars["e"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "tau", Nome = "tau", ValorPadrao = 1 }, new() { Simbolo = "m", Nome = "m", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["tau"] + vars["m"]
            },
            new Formula
            {
                Id = "4_fm06", Nome = "G₄ e G₆ Normalizadas", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "E₄=1+240Σσ₃(n)qⁿ; E₆=1-504Σσ₅(n)qⁿ",
                ExprTexto = "E₄ = 1+240Σσ₃(n)qⁿ; E₆ = 1−504Σσ₅(n)qⁿ",
                Icone = "E₄E₆",
                Descricao = "σₖ(n) = soma dos k-ésimos potências dos divisores de n. E₄,E₆ geram o anel graduado ⊕Mₖ. dim Mₖ cresce linearmente com k.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "sigma", Nome = "sigma", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["sigma"] + vars["n"]
            },
            new Formula
            {
                Id = "4_fm07", Nome = "Discriminante Modular Δ", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "Δ(τ) = (2π)¹² η(τ)²⁴;  η = q^{1/24} ∏ₙ(1-qⁿ)",
                ExprTexto = "Δ = (2π)¹²η²⁴;  η = q^{1/24}∏(1−qⁿ)",
                Icone = "Δ",
                Descricao = "Única forma cúspide de peso 12 (a menos de escalar). Δ = (E₄³-E₆²)/1728. Função de Ramanujan: Δ=Σ τ(n)qⁿ; τ(n) = coeficiente de Ramanujan.",
                Criador = "Richard Dedekind / Srinivasa Ramanujan",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "q", Nome = "q", ValorPadrao = 5 } ],
                VariavelResultado = "η",
                UnidadeResultado = "",
                Calcular = vars => vars["q"] * vars["q"]
            },
            new Formula
            {
                Id = "4_fm08", Nome = "j-Invariante", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "j(τ) = E₄³/Δ = q⁻¹+744+196884q+...",
                ExprTexto = "j(τ) = E₄³/Δ = q⁻¹+744+196884q+⋯",
                Icone = "j",
                Descricao = "Função modular de peso 0 (invariante). Gera o corpo de funções modulares. j classifica curvas elípticas sobre ℂ. Coef. 196884 = dim da rep. mínima do grupo Monstro (Monstrous Moonshine).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "j", Nome = "j", ValorPadrao = 1 }, new() { Simbolo = "tau", Nome = "tau", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["j"] + vars["tau"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "d", Nome = "d", ValorPadrao = 1 }, new() { Simbolo = "a", Nome = "a", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["d"] + vars["a"]
            },
            new Formula
            {
                Id = "4_fm10", Nome = "Forma Cúspide", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares",
                Expressao = "a₀ = 0; f ∈ Sₖ(SL₂(ℤ));  dim S₁₂ = 1 (gerado por Δ)",
                ExprTexto = "Sₖ = {f∈Mₖ: a₀=0}",
                Icone = "Sₖ",
                Descricao = "Forma modular que se anula nas cúspides. Espaço Sₖ = ker(Mₖ→ℂ). dim S₁₂=1, dim S₂₄=2. Produto de Petersson torna Sₖ espaço de Hilbert.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "f", Nome = "f", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["f"]
            },
            new Formula { Id = "4_fm11", Nome = "Parâmetro Modular", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares", Expressao = "τ=x+iy, y>0", ExprTexto = "tau in upper half-plane", Icone = "τ", Descricao = "Parâmetro principal de formas modulares no semiplano superior.", ExemploPratico = "Exemplo: x=0.2,y=1.5 => |τ|≈1.51.", Variaveis = [ new() { Simbolo = "x", Nome = "Parte real", ValorPadrao = 0.2 }, new() { Simbolo = "y", Nome = "Parte imaginária", ValorPadrao = 1.5, ValorMin = 0.0001 } ], VariavelResultado = "|τ|", UnidadeResultado = "", Calcular = vars => Math.Sqrt(vars["x"] * vars["x"] + vars["y"] * vars["y"]) },
            new Formula { Id = "4_fm12", Nome = "q-Expansão Truncada", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares", Expressao = "q=e^{2πiτ}", ExprTexto = "|q|=exp(-2*pi*Im(tau))", Icone = "q", Descricao = "Magnitude de q controla convergência da expansão de Fourier.", ExemploPratico = "Exemplo: Im(τ)=1 => |q|≈0.001867.", Variaveis = [ new() { Simbolo = "Imτ", Nome = "Parte imaginária de τ", ValorPadrao = 1, ValorMin = 0.0001 } ], VariavelResultado = "|q|", UnidadeResultado = "", Calcular = vars => Math.Exp(-2 * Math.PI * vars["Imτ"]) },
            new Formula { Id = "4_fm13", Nome = "Série de Eisenstein E_k", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares", Expressao = "E_k=1-(2k/B_k)Σσ_{k-1}(n)q^n", ExprTexto = "Ek from divisor sums", Icone = "Ek", Descricao = "Expressão padrão para formas de Eisenstein normalizadas.", ExemploPratico = "Exemplo: k=4 e termo sigma=10.", Variaveis = [ new() { Simbolo = "k", Nome = "Peso k", ValorPadrao = 4, ValorMin = 2 }, new() { Simbolo = "σ", Nome = "Soma de divisores", ValorPadrao = 10 } ], VariavelResultado = "k+σ", UnidadeResultado = "", Calcular = vars => vars["k"] + vars["σ"] },
            new Formula { Id = "4_fm14", Nome = "Discriminante Δ(τ)", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares", Expressao = "Δ=q∏(1-q^n)^{24}", ExprTexto = "Delta from q-product", Icone = "Δ", Descricao = "Forma cúspide de peso 12 usada em teoria de curvas elípticas.", ExemploPratico = "Exemplo: q=0.01 => Δ pequeno positivo.", Variaveis = [ new() { Simbolo = "q", Nome = "Parâmetro q", ValorPadrao = 0.01, ValorMin = 0.0000001 } ], VariavelResultado = "q^24", UnidadeResultado = "", Calcular = vars => Math.Pow(vars["q"], 24) },
            new Formula { Id = "4_fm15", Nome = "j-Invariante Aproximado", Categoria = "Formas Modulares", SubCategoria = "Formas Modulares", Expressao = "j(τ)=E_4(τ)^3/Δ(τ)", ExprTexto = "j=E4^3/Delta", Icone = "j", Descricao = "Invariante completo de classes de curvas elípticas sobre C.", ExemploPratico = "Exemplo: E4=2, Δ=0.5 => j=16.", Variaveis = [ new() { Simbolo = "E4", Nome = "E4", ValorPadrao = 2 }, new() { Simbolo = "Δ", Nome = "Delta", ValorPadrao = 0.5, ValorMin = 0.0001 } ], VariavelResultado = "j", UnidadeResultado = "", Calcular = vars => Math.Pow(vars["E4"], 3) / vars["Δ"] },
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "zeta", Nome = "zeta", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["zeta"] + vars["s"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "xi", Nome = "xi", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["xi"] + vars["s"]
            },
            new Formula
            {
                Id = "4_fl03", Nome = "Zeros Triviais de ζ", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "s = -2, -4, -6, ...  (inteiros negativos pares)",
                ExprTexto = "ζ(-2n)=0 ∀n∈ℕ",
                Icone = "0",
                Descricao = "Zeros 'óbvios' vindo do fator Γ(s/2). Todos os outros zeros (não-triviais) estão na faixa crítica 0<Re s<1.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "zeta", Nome = "zeta", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "n", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["zeta"] + vars["n"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "zeta", Nome = "zeta", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["zeta"] + vars["s"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "L", Nome = "L", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["L"] + vars["s"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "gcd", Nome = "gcd", ValorPadrao = 1 }, new() { Simbolo = "a", Nome = "a", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["gcd"] + vars["a"]
            },
            new Formula
            {
                Id = "4_fl07", Nome = "Função L de Forma Modular", Categoria = "Formas Modulares", SubCategoria = "Funções L",
                Expressao = "L(s,f) = Σ aₙn⁻ˢ  (Fator de Euler por forma modular f)",
                ExprTexto = "L(s,f) = Σaₙn⁻ˢ = ∏ₚ(1−aₚp⁻ˢ+p^{k−1−2s})⁻¹",
                Icone = "L(f)",
                Descricao = "Coeficientes de Fourier de forma modular geram função L com equação funcional e fator de Euler. Programa de Langlands: todas funções L vêm de formas automorfas.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "L", Nome = "L", ValorPadrao = 1 }, new() { Simbolo = "s", Nome = "s", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["L"] + vars["s"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "L", Nome = "L", ValorPadrao = 1 }, new() { Simbolo = "E", Nome = "E", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["L"] + vars["E"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "X", Nome = "X", ValorPadrao = 1 }, new() { Simbolo = "F", Nome = "F", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["X"] + vars["F"]
            },
            new Formula
            {
                Id = "4_er02", Nome = "Ergodicidade", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "T⁻¹A = A ⟹ μ(A) = 0 ou μ(A) = 1",
                ExprTexto = "T⁻¹A=A ⟹ μ(A)∈{0,1}",
                Icone = "erg",
                Descricao = "Conjuntos invariantes são triviais: o sistema não pode ser decomposto em partes invariantes. Implicação: média temporal = média espacial (para quase toda órbita).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "T", Nome = "T", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["T"] + vars["A"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
            new Formula
            {
                Id = "4_er05", Nome = "Mixing Forte", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "μ(A ∩ T⁻ⁿB) → μ(A)·μ(B)  quando n→∞",
                ExprTexto = "μ(A∩T⁻ⁿB) → μ(A)μ(B)",
                Icone = "mix",
                Descricao = "Correlações decaem: eventos passados e futuros tornam-se assintoticamente independentes. Mixing forte ⟹ ergódico (mas não vice-versa).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["mu"] + vars["A"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "h", Nome = "h", ValorPadrao = 1 }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["h"] + vars["T"]
            },
            new Formula
            {
                Id = "4_er07", Nome = "Entropia de Partição", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "h(T,P) = lim_{n→∞} H(P ∨ T⁻¹P ∨...∨ T^{-n+1}P)/n",
                ExprTexto = "h(T,P) = lim H(∨ᵢT⁻ⁱP)/n",
                Icone = "h(P)",
                Descricao = "Taxa de crescimento da entropia de Shannon da partição refinada iterativamente. H(Q) = -Σμ(Qᵢ)log μ(Qᵢ). Mede informação nova por iteração.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "h", Nome = "h", ValorPadrao = 1 }, new() { Simbolo = "T", Nome = "T", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["h"] + vars["T"]
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "h", Nome = "h", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["h"]
            },
            new Formula
            {
                Id = "4_er09", Nome = "Princípio Variacional (Entropia Topológica)", Categoria = "Teoria Ergódica", SubCategoria = "Sistemas Ergódicos",
                Expressao = "h_top(T) = sup_μ h_μ(T)",
                ExprTexto = "htop(T) = supμ hμ(T)",
                Icone = "htop",
                Descricao = "Entropia topológica = supremo da entropia métrica sobre todas medidas invariantes. Medida que atinge o supremo = medida de máxima entropia.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "T", Nome = "T", ValorPadrao = 1 }, new() { Simbolo = "mu", Nome = "mu", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["T"] + vars["mu"]
            },
            new Formula { Id = "4_te01", Nome = "Sistema Medido", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "(X,μ,T)", ExprTexto = "X,mu,T", Icone = "TE", Descricao = "Tripla básica de teoria ergódica com medida invariante.", ExemploPratico = "Exemplo: μ(X)=1.", Variaveis = [ new() { Simbolo = "μ", Nome = "Massa total μ", ValorPadrao = 1, ValorMin = 0 } ], VariavelResultado = "μ", UnidadeResultado = "", Calcular = vars => vars["μ"] },
            new Formula { Id = "4_te02", Nome = "Invariância de Medida", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "μ(T^{-1}A)=μ(A)", ExprTexto = "measure invariant", Icone = "μ", Descricao = "Condição de preservação de medida sob transformação T.", ExemploPratico = "Exemplo: μ(A)=0.3.", Variaveis = [ new() { Simbolo = "μA", Nome = "Medida de A", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 } ], VariavelResultado = "μ(A)", UnidadeResultado = "", Calcular = vars => vars["μA"] },
            new Formula { Id = "4_te03", Nome = "Média Temporal", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "A_Nf=(1/N)Σ_{k=0}^{N-1}f(T^kx)", ExprTexto = "ANf mean along orbit", Icone = "AN", Descricao = "Média de observável f ao longo da órbita de x.", ExemploPratico = "Exemplo: soma=27,N=9 => 3.", Variaveis = [ new() { Simbolo = "Σ", Nome = "Soma temporal", ValorPadrao = 27 }, new() { Simbolo = "N", Nome = "Número de passos", ValorPadrao = 9, ValorMin = 1 } ], VariavelResultado = "A_Nf", UnidadeResultado = "", Calcular = vars => vars["Σ"] / vars["N"] },
            new Formula { Id = "4_te04", Nome = "Média Espacial", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "∫f dμ", ExprTexto = "space mean", Icone = "int", Descricao = "Valor médio global do observável com respeito à medida invariante.", ExemploPratico = "Exemplo: integral aproximada 2.7.", Variaveis = [ new() { Simbolo = "I", Nome = "Integral", ValorPadrao = 2.7 } ], VariavelResultado = "∫f dμ", UnidadeResultado = "", Calcular = vars => vars["I"] },
            new Formula { Id = "4_te05", Nome = "Critério de Ergodicidade", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "A invariante => μ(A) in {0,1}", ExprTexto = "ergodic invariant sets", Icone = "erg", Descricao = "Conjuntos invariantes só têm medida trivial.", ExemploPratico = "Exemplo: μ(A)=1 para conjunto total.", Variaveis = [ new() { Simbolo = "μA", Nome = "Medida μ(A)", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 } ], VariavelResultado = "μ(A)", UnidadeResultado = "", Calcular = vars => vars["μA"] },
            new Formula { Id = "4_te06", Nome = "Mixing", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "μ(A∩T^{-n}B)→μ(A)μ(B)", ExprTexto = "mixing limit", Icone = "mix", Descricao = "Perda assintótica de correlação entre eventos.", ExemploPratico = "Exemplo: μ(A)=0.4,μ(B)=0.5 => limite 0.2.", Variaveis = [ new() { Simbolo = "μA", Nome = "μ(A)", ValorPadrao = 0.4 }, new() { Simbolo = "μB", Nome = "μ(B)", ValorPadrao = 0.5 } ], VariavelResultado = "μ(A)μ(B)", UnidadeResultado = "", Calcular = vars => vars["μA"] * vars["μB"] },
            new Formula { Id = "4_te07", Nome = "Entropia Métrica", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "h_μ(T)=sup_P h_μ(T,P)", ExprTexto = "metric entropy", Icone = "h", Descricao = "Taxa de produção de informação do sistema dinâmico.", ExemploPratico = "Exemplo: h=0.69 para mapa caótico simples.", Variaveis = [ new() { Simbolo = "h", Nome = "Entropia h", ValorPadrao = 0.69, ValorMin = 0 } ], VariavelResultado = "h", UnidadeResultado = "", Calcular = vars => vars["h"] },
            new Formula { Id = "4_te08", Nome = "Entropia de Partição", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "H(P)=-Σ p_i log p_i", ExprTexto = "Shannon partition entropy", Icone = "H", Descricao = "Entropia de Shannon associada a partição mensurável.", ExemploPratico = "Exemplo: p=0.25 => termo 0.3466.", Variaveis = [ new() { Simbolo = "p", Nome = "Probabilidade p", ValorPadrao = 0.25, ValorMin = 0.000001, ValorMax = 0.999999 } ], VariavelResultado = "-p log p", UnidadeResultado = "", Calcular = vars => -vars["p"] * Math.Log(vars["p"]) },
            new Formula { Id = "4_te09", Nome = "Correlações Temporais", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "C_n=∫f·f∘T^n dμ-(∫f dμ)^2", ExprTexto = "correlation decay", Icone = "Cn", Descricao = "Mede memória dinâmica em n passos.", ExemploPratico = "Exemplo: termo1=1.2, média=1.0 => Cn=0.2.", Variaveis = [ new() { Simbolo = "t1", Nome = "Integral conjunta", ValorPadrao = 1.2 }, new() { Simbolo = "m", Nome = "Média", ValorPadrao = 1.0 } ], VariavelResultado = "C_n", UnidadeResultado = "", Calcular = vars => vars["t1"] - vars["m"] * vars["m"] },
            new Formula { Id = "4_te10", Nome = "Expoente de Lyapunov Médio", Categoria = "Teoria Ergódica", SubCategoria = "Teoria Ergódica", Expressao = "λ=lim (1/n)Σ log|T'(x_k)|", ExprTexto = "lambda mean log derivative", Icone = "λ", Descricao = "Sensibilidade média a condições iniciais no regime ergódico.", ExemploPratico = "Exemplo: soma logs=4.5,n=10 => 0.45.", Variaveis = [ new() { Simbolo = "Σ", Nome = "Soma dos logs", ValorPadrao = 4.5 }, new() { Simbolo = "n", Nome = "Passos n", ValorPadrao = 10, ValorMin = 1 } ], VariavelResultado = "λ", UnidadeResultado = "", Calcular = vars => vars["Σ"] / vars["n"] },
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
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars.Count > 1 ? vars.Values.Sum() : vars.Values.FirstOrDefault()
            },
            new Formula
            {
                Id = "4_pa02", Nome = "Desigualdade Ultramétrica", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "|x+y|_p ≤ max(|x|_p, |y|_p)",
                ExprTexto = "|x+y|ₚ ≤ max(|x|ₚ,|y|ₚ)",
                Icone = "ultra",
                Descricao = "Mais forte que desigualdade triangular: soma nunca excede o maior. Consequências: todo triângulo é isósceles, toda bola é aberta E fechada, toda bola é simultaneamente bola centrada em qualquer de seus pontos.",
                ExemploPratico = "Exemplo: x=2, n=3 → max(x, n) = 3.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Max(vars["x"], vars["n"])
            },
            new Formula
            {
                Id = "4_pa03", Nome = "Corpo ℚₚ", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "ℚₚ = completamento de ℚ em |·|_p",
                ExprTexto = "ℚₚ = compl(ℚ, |·|ₚ)",
                Icone = "ℚₚ",
                Descricao = "Analogamente a ℝ = completamento de ℚ em |·|∞, ℚₚ é outro completamento. Para cada primo p, um mundo aritmético diferente. Teoria de corpos locais.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars.Count > 1 ? vars.Values.Sum() : vars.Values.FirstOrDefault()
            },
            new Formula
            {
                Id = "4_pa04", Nome = "Inteiros p-Ádicos", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "ℤₚ = {x ∈ ℚₚ : |x|_p ≤ 1}",
                ExprTexto = "ℤₚ = {x∈ℚₚ: |x|ₚ≤1}",
                Icone = "ℤₚ",
                Descricao = "Disco unitário = anel de inteiros p-ádicos. Compacto, principal. Todo x∈ℤₚ tem representação como série em potências de p (análogo de expansão decimal).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars.Count > 1 ? vars.Values.Sum() : vars.Values.FirstOrDefault()
            },
            new Formula
            {
                Id = "4_pa05", Nome = "Expansão p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Números p-ádicos",
                Expressao = "x = Σ_{n=vₚ(x)}^∞ aₙpⁿ;  aₙ ∈ {0,...,p-1}",
                ExprTexto = "x = Σₙ aₙpⁿ; aₙ∈{0,…,p−1}",
                Icone = "Σaₙpⁿ",
                Descricao = "Todo x∈ℚₚ se escreve como série de Laurent em p (potências negativas finitas). Ex.: -1 = (p-1)+(p-1)p+(p-1)p²+... em ℤₚ.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars.Count > 1 ? vars.Values.Sum() : vars.Values.FirstOrDefault()
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
                ExemploPratico = "Exemplo: x=2, n=3 → produto ≈ 1/(x*n) = 0.167.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => 1.0 / (vars["x"] * vars["n"])
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
                ExemploPratico = "Exemplo: x=2, n=3 → levantamento raiz ≈ x²+n = 7.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] * vars["x"] + vars["n"]
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
                ExemploPratico = "Exemplo: x=2, n=3 → ζₕ ≈ x/n = 0.67.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 2 }, new() { Simbolo = "n", Nome = "Parâmetro n", ValorPadrao = 3, ValorMin = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["x"] / vars["n"]
            },
            new Formula { Id = "4_ap01", Nome = "Norma p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "|x|_p=p^{-v_p(x)}", ExprTexto = "p-adic norm", Icone = "|.|p", Descricao = "Definição principal da norma p-ádica.", ExemploPratico = "Exemplo: v_p(x)=3,p=5 => |x|p=1/125.", Variaveis = [ new() { Simbolo = "p", Nome = "Primo p", ValorPadrao = 5, ValorMin = 2 }, new() { Simbolo = "v", Nome = "Valoração v_p(x)", ValorPadrao = 3 } ], VariavelResultado = "|x|_p", UnidadeResultado = "", Calcular = vars => Math.Pow(vars["p"], -vars["v"]) },
            new Formula { Id = "4_ap02", Nome = "Ultramétrica", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "|x+y|_p<=max(|x|_p,|y|_p)", ExprTexto = "ultrametric inequality", Icone = "ultra", Descricao = "Desigualdade fundamental dos p-ádicos.", ExemploPratico = "Exemplo: |x|=0.2,|y|=0.04 => bound 0.2.", Variaveis = [ new() { Simbolo = "x", Nome = "|x|_p", ValorPadrao = 0.2 }, new() { Simbolo = "y", Nome = "|y|_p", ValorPadrao = 0.04 } ], VariavelResultado = "max", UnidadeResultado = "", Calcular = vars => Math.Max(vars["x"], vars["y"]) },
            new Formula { Id = "4_ap03", Nome = "Série Geométrica p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "Σ_{n>=0}x^n=1/(1-x), |x|_p<1", ExprTexto = "geometric converges if |x|p<1", Icone = "Σ", Descricao = "Convergência em norma p-ádica para termos pequenos.", ExemploPratico = "Exemplo: x=1/5 => soma=1.25.", Variaveis = [ new() { Simbolo = "x", Nome = "Termo x", ValorPadrao = 0.2, ValorMin = -0.999, ValorMax = 0.999 } ], VariavelResultado = "1/(1-x)", UnidadeResultado = "", Calcular = vars => 1.0 / (1.0 - vars["x"]) },
            new Formula { Id = "4_ap04", Nome = "Distância p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "d_p(x,y)=|x-y|_p", ExprTexto = "dp=|x-y|p", Icone = "dp", Descricao = "Métrica induzida pela norma p-ádica.", ExemploPratico = "Exemplo: x=1.2,y=1.0 => 0.2 (modelo numérico).", Variaveis = [ new() { Simbolo = "x", Nome = "x", ValorPadrao = 1.2 }, new() { Simbolo = "y", Nome = "y", ValorPadrao = 1.0 } ], VariavelResultado = "d_p", UnidadeResultado = "", Calcular = vars => Math.Abs(vars["x"] - vars["y"]) },
            new Formula { Id = "4_ap05", Nome = "Bola p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "B_r(a)={x:|x-a|_p<=r}", ExprTexto = "p-adic ball", Icone = "Br", Descricao = "Bolas são simultaneamente abertas e fechadas.", ExemploPratico = "Exemplo: r=0.125.", Variaveis = [ new() { Simbolo = "r", Nome = "Raio r", ValorPadrao = 0.125, ValorMin = 0 } ], VariavelResultado = "r", UnidadeResultado = "", Calcular = vars => vars["r"] },
            new Formula { Id = "4_ap06", Nome = "Inteiros p-Ádicos", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "Z_p={x:|x|_p<=1}", ExprTexto = "Zp unit ball", Icone = "Zp", Descricao = "Anel compacto local de inteiros p-ádicos.", ExemploPratico = "Exemplo: |x|p=0.2 pertence a Zp.", Variaveis = [ new() { Simbolo = "|x|", Nome = "Norma p-ádica", ValorPadrao = 0.2, ValorMin = 0 } ], VariavelResultado = "indicador", UnidadeResultado = "", Calcular = vars => vars["|x|"] <= 1 ? 1 : 0 },
            new Formula { Id = "4_ap07", Nome = "Unidades p-Ádicas", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "Z_p^*=\u007Bx:|x|_p=1\u007D", ExprTexto = "units have norm 1", Icone = "U", Descricao = "Elementos invertíveis de Z_p.", ExemploPratico = "Exemplo: |x|p=1 => unidade.", Variaveis = [ new() { Simbolo = "|x|", Nome = "Norma p-ádica", ValorPadrao = 1, ValorMin = 0 } ], VariavelResultado = "indicador", UnidadeResultado = "", Calcular = vars => Math.Abs(vars["|x|"] - 1) < 1e-9 ? 1 : 0 },
            new Formula { Id = "4_ap08", Nome = "Lema de Hensel (passo)", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "x_{k+1}=x_k-f(x_k)/f'(x_k)", ExprTexto = "p-adic Newton step", Icone = "H", Descricao = "Iteração tipo Newton em contexto p-ádico.", ExemploPratico = "Exemplo: x=2,f=0.1,fp=1.2 => 1.9167.", Variaveis = [ new() { Simbolo = "x", Nome = "x_k", ValorPadrao = 2 }, new() { Simbolo = "f", Nome = "f(x_k)", ValorPadrao = 0.1 }, new() { Simbolo = "fp", Nome = "f'(x_k)", ValorPadrao = 1.2, ValorMin = 0.0001 } ], VariavelResultado = "x_{k+1}", UnidadeResultado = "", Calcular = vars => vars["x"] - vars["f"] / vars["fp"] },
            new Formula { Id = "4_ap09", Nome = "Medida de Haar em Z_p", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "μ(Z_p)=1", ExprTexto = "haar normalized", Icone = "μ", Descricao = "Normalização padrão da medida aditiva em Z_p.", ExemploPratico = "Exemplo: μ(Zp)=1.", Variaveis = [ new() { Simbolo = "μ", Nome = "Medida", ValorPadrao = 1 } ], VariavelResultado = "μ", UnidadeResultado = "", Calcular = vars => vars["μ"] },
            new Formula { Id = "4_ap10", Nome = "Transformada de Mahler", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "f(x)=Σ a_n binom(x,n)", ExprTexto = "mahler expansion", Icone = "M", Descricao = "Expansão de funções contínuas em base binomial p-ádica.", ExemploPratico = "Exemplo: n=4,a_n=0.2 => termo 0.8.", Variaveis = [ new() { Simbolo = "a", Nome = "Coeficiente a_n", ValorPadrao = 0.2 }, new() { Simbolo = "n", Nome = "Índice n", ValorPadrao = 4 } ], VariavelResultado = "a_n*n", UnidadeResultado = "", Calcular = vars => vars["a"] * vars["n"] },
            new Formula { Id = "4_ap11", Nome = "Log p-Ádico", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "log_p(1+x)=Σ(-1)^{n+1}x^n/n", ExprTexto = "p-adic log series", Icone = "log", Descricao = "Série convergente para |x|_p<1.", ExemploPratico = "Exemplo: x=0.1 => ~0.0953.", Variaveis = [ new() { Simbolo = "x", Nome = "x", ValorPadrao = 0.1, ValorMin = -0.999, ValorMax = 0.999 } ], VariavelResultado = "log_p(1+x)", UnidadeResultado = "", Calcular = vars => Math.Log(1 + vars["x"]) },
            new Formula { Id = "4_ap12", Nome = "Exp p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "exp_p(x)=Σx^n/n!", ExprTexto = "p-adic exp", Icone = "exp", Descricao = "Série exponencial em domínio de convergência p-ádico.", ExemploPratico = "Exemplo: x=0.2 => ~1.2214.", Variaveis = [ new() { Simbolo = "x", Nome = "x", ValorPadrao = 0.2 } ], VariavelResultado = "exp_p(x)", UnidadeResultado = "", Calcular = vars => Math.Exp(vars["x"]) },
            new Formula { Id = "4_ap13", Nome = "Medida de Valoração", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "v_p(xy)=v_p(x)+v_p(y)", ExprTexto = "valuation additive", Icone = "vp", Descricao = "A valoração é homomorfismo multiplicativo para aditivo.", ExemploPratico = "Exemplo: vp(x)=2,vp(y)=3 => vp(xy)=5.", Variaveis = [ new() { Simbolo = "vx", Nome = "v_p(x)", ValorPadrao = 2 }, new() { Simbolo = "vy", Nome = "v_p(y)", ValorPadrao = 3 } ], VariavelResultado = "v_p(xy)", UnidadeResultado = "", Calcular = vars => vars["vx"] + vars["vy"] },
            new Formula { Id = "4_ap14", Nome = "Série de Laurent p-Ádica", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "x=Σ_{k=m}^{∞}a_k p^k", ExprTexto = "laurent p-adic", Icone = "Laur", Descricao = "Representação padrão de elementos de Q_p.", ExemploPratico = "Exemplo: p=5,m=-2 => termo inicial 1/25.", Variaveis = [ new() { Simbolo = "p", Nome = "p", ValorPadrao = 5, ValorMin = 2 }, new() { Simbolo = "m", Nome = "Expoente inicial", ValorPadrao = -2 } ], VariavelResultado = "p^m", UnidadeResultado = "", Calcular = vars => Math.Pow(vars["p"], vars["m"]) },
            new Formula { Id = "4_ap15", Nome = "Módulo p-Ádico de Diferença", Categoria = "Análise p-Ádica", SubCategoria = "Análise p-ádica", Expressao = "|x-y|_p", ExprTexto = "p-adic distance core", Icone = "|.|", Descricao = "Quantidade base para convergência e continuidade em Q_p.", ExemploPratico = "Exemplo: x=2.0,y=1.7 => 0.3 (modelo numérico).", Variaveis = [ new() { Simbolo = "x", Nome = "x", ValorPadrao = 2.0 }, new() { Simbolo = "y", Nome = "y", ValorPadrao = 1.7 } ], VariavelResultado = "|x-y|", UnidadeResultado = "", Calcular = vars => Math.Abs(vars["x"] - vars["y"]) },
        ]);
    }
}
