using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═════════════════════════════════════════════════════════════
    //  VOLUME 2 — PARTE I: MATEMÁTICA PURA AVANÇADA (COMPLETO)
    // ═════════════════════════════════════════════════════════════

    private void AdicionarMatematicaPuraAvancada()
    {
        AdicionarAlgebraAbstrataCompleta();
        AdicionarTopologiaCompleta();
        AdicionarGeometriaDiferencialCompleta();
        AdicionarCalculoVariacoesCompleto();
        AdicionarFuncoesEspeciaisCompleta();
        AdicionarAnaliseComplexaCompleta();
    }

    // ─────────────────────────────────────────────────────
    // 1. ÁLGEBRA ABSTRATA COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarAlgebraAbstrataCompleta()
    {
        _formulas.AddRange([
            // 1.1 Grupos
            new Formula
            {
                Id = "v2_g01", Nome = "Ordem de Elemento em Grupo Cíclico ℤₙ",
                Categoria = "Vol2: Álgebra Abstrata", SubCategoria = "Grupos",
                Expressao = "ord(a) em ℤₙ: menor k > 0 tal que a^k ≡ 1 (mod n)",
                ExprTexto = "ord(a) em ℤₙ = menor k onde aᵏ ≡ 1 (mod n)",
                Icone = "⊕",
                Descricao = "Calcula a ordem de um elemento a no grupo multiplicativo ℤₙ. A ordem é o menor inteiro positivo k tal que a^k ≡ 1 (mod n), ou seja, o menor expoente que faz a potência retornar à identidade.",
                Criador = "Carl Friedrich Gauss / Teoria de Grupos",
                AnoOrigin = "1801",
                ExemploPratico = "Para a=2 em ℤ₇: 2¹=2, 2²=4, 2³≡1 (mod 7), então ord(2)=3. Para a=3 em ℤ₇: 3¹=3, 3²=2, 3³=6, 3⁴=4, 3⁵=5, 3⁶≡1 (mod 7), então ord(3)=6.",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Elemento a", Descricao = "Elemento do grupo (inteiro)", ValorPadrao = 2, ValorMin = 1, Unidade = "" },
                    new() { Simbolo = "n", Nome = "Módulo n", Descricao = "Ordem do grupo cíclico ℤₙ", ValorPadrao = 7, ValorMin = 2, Unidade = "" },
                ],
                VariavelResultado = "ord(a)",
                UnidadeResultado = "",
                Calcular = vars => {
                    int a = (int)vars["a"], n = (int)vars["n"];
                    if (n <= 1 || a <= 0) return double.NaN;
                    long val = a % n;
                    if (val == 0) return double.NaN;
                    for (int k = 1; k <= n; k++) {
                        if (val == 1) return k;
                        val = (val * (a % n)) % n;
                    }
                    return double.NaN;
                }
            },

            new Formula
            {
                Id = "v2_g02", Nome = "Índice de Subgrupo [G:H] = |G|/|H|",
                Categoria = "Vol2: Álgebra Abstrata", SubCategoria = "Grupos",
                Expressao = "[G:H] = |G| / |H|",
                ExprTexto = "Índice [G:H] = número de classes laterais = |G| / |H|",
                Icone = "⊕",
                Descricao = "O índice de um subgrupo H em G é o número de classes laterais (cosets) de H em G. Pelo Teorema de Lagrange, [G:H] = |G|/|H| para grupos finitos. Representa quantas cópias disjuntas de H cobrem G.",
                Criador = "Joseph-Louis Lagrange",
                AnoOrigin = "1770",
                ExemploPratico = "Se G tem 12 elementos e H tem 4 elementos, então [G:H] = 12/4 = 3, ou seja, existem 3 classes laterais de H em G. Exemplo: em ℤ₁₂, o subgrupo H={0,4,8} tem índice [ℤ₁₂:H]=3.",
                Variaveis = [
                    new() { Simbolo = "G", Nome = "|G| (ordem do grupo)", Descricao = "Número de elementos do grupo G", ValorPadrao = 12, ValorMin = 1, Unidade = "" },
                    new() { Simbolo = "H", Nome = "|H| (ordem do subgrupo)", Descricao = "Número de elementos do subgrupo H", ValorPadrao = 4, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "[G:H]",
                UnidadeResultado = "",
                Calcular = vars => {
                    if (vars["G"] < vars["H"]) return double.NaN;
                    if ((int)vars["G"] % (int)vars["H"] != 0) return double.NaN; // Violaria Lagrange
                    return vars["G"] / vars["H"];
                }
            },

            new Formula
            {
                Id = "v2_g03", Nome = "Ordem do Produto Direto |G×H|",
                Categoria = "Vol2: Álgebra Abstrata", SubCategoria = "Grupos",
                Expressao = "|G×H| = |G| · |H|",
                ExprTexto = "|G × H| = |G| · |H|",
                Icone = "⊕",
                Descricao = "O produto direto G×H é o conjunto de todos os pares ordenados (g,h) com g∈G e h∈H, com operação componente a componente. A ordem do produto direto é o produto das ordens.",
                Criador = "Teoria de Grupos Moderna",
                AnoOrigin = "~1900",
                ExemploPratico = "Se G=ℤ₃ (ordem 3) e H=ℤ₄ (ordem 4), então G×H=ℤ₃×ℤ₄ tem ordem 12. Exemplo: ℤ₂×ℤ₂ tem 4 elementos: {(0,0), (0,1), (1,0), (1,1)}.",
                Variaveis = [
                    new() { Simbolo = "G", Nome = "|G|", Descricao = "Ordem do primeiro grupo", ValorPadrao = 3, ValorMin = 1, Unidade = "" },
                    new() { Simbolo = "H", Nome = "|H|", Descricao = "Ordem do segundo grupo", ValorPadrao = 4, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "|G×H|",
                UnidadeResultado = "",
                Calcular = vars => vars["G"] * vars["H"]
            },

            // 1.2 Anéis e Corpos
            new Formula
            {
                Id = "v2_f01", Nome = "Ordem de Corpo Finito de Galois 𝔽_q",
                Categoria = "Vol2: Álgebra Abstrata", SubCategoria = "Corpos",
                Expressao = "q = p^n (p primo, n ≥ 1)",
                ExprTexto = "|𝔽_q| = pⁿ",
                Icone = "⊕",
                Descricao = "Todo corpo finito tem pⁿ elementos onde p é primo e n≥1. Para cada potência de primo q=pⁿ, existe exatamente um corpo (a menos de isomorfismo) com q elementos, denotado 𝔽_q ou GF(q). Usado em criptografia, códigos corretores de erros e teoria da informação.",
                Criador = "Évariste Galois",
                AnoOrigin = "1830",
                ExemploPratico = "𝔽₂ tem 2 elementos {0,1}. 𝔽₄=𝔽_{2²} tem 4 elementos. 𝔽₈=𝔽_{2³} tem 8 elementos. 𝔽₂₅₆=𝔽_{2⁸} (usado em AES) tem 256 elementos. 𝔽₂₅=𝔽_{5²} tem 25 elementos.",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Primo p", Descricao = "Número primo base do corpo", ValorPadrao = 2, ValorMin = 2, Unidade = "" },
                    new() { Simbolo = "n", Nome = "Expoente n", Descricao = "Potência do primo", ValorPadrao = 8, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "q = pⁿ",
                UnidadeResultado = "elementos",
                Calcular = vars => Math.Pow(vars["p"], vars["n"])
            },

            new Formula
            {
                Id = "v2_f02", Nome = "Grau de Extensão de Corpos [E:F]",
                Categoria = "Vol2: Álgebra Abstrata", SubCategoria = "Corpos",
                Expressao = "[E:F] = dim_F(E)",
                ExprTexto = "[E:F] = dimensão de E como espaço vetorial sobre F",
                Icone = "⊕",
                Descricao = "O grau da extensão E/F é a dimensão de E vista como espaço vetorial sobre F. Mede o 'tamanho' da extensão. Para extensões em torre: [E:F]=[E:K][K:F].",
                Criador = "Richard Dedekind",
                AnoOrigin = "~1880",
                ExemploPratico = "[ℂ:ℝ]=2 (base: {1,i}). [ℝ:ℚ]=∞. [ℚ(√2):ℚ]=2 (base: {1,√2}). [ℚ(∛2):ℚ]=3. [𝔽_{p^n}:𝔽_p]=n.",
                Variaveis = [
                    new() { Simbolo = "E", Nome = "dim_F(E)", Descricao = "Dimensão de E sobre F", ValorPadrao = 2, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "[E:F]",
                UnidadeResultado = "",
                Calcular = vars => vars["E"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 2. TOPOLOGIA COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarTopologiaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_top01", Nome = "Distância Euclidiana em ℝⁿ",
                Categoria = "Vol2: Topologia", SubCategoria = "Espaços Métricos",
                Expressao = "d(x,y) = √(Σ(xᵢ-yᵢ)²)",
                ExprTexto = "d(x,y) = √((x₁-y₁)² + (x₂-y₂)² + ... + (xₙ-yₙ)²)",
                Icone = "📐",
                Descricao = "A distância euclidiana é a métrica padrão em ℝⁿ, generalizando o Teorema de Pitágoras. Define a noção usual de 'distância em linha reta' entre dois pontos.",
                Criador = "Euclides / Geometria Moderna",
                AnoOrigin = "~300 a.C.",
                ExemploPratico = "Distância entre (0,0) e (3,4) em ℝ²: d=√(9+16)=5. Entre (1,2,3) e (4,6,8) em ℝ³: d=√((4-1)²+(6-2)²+(8-3)²)=√(9+16+25)=√50≈7.07.",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", Descricao = "Primeira coordenada do ponto x", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "y1", Nome = "y₁", Descricao = "Primeira coordenada do ponto y", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "x2", Nome = "x₂", Descricao = "Segunda coordenada do ponto x", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "y2", Nome = "y₂", Descricao = "Segunda coordenada do ponto y", ValorPadrao = 4, Unidade = "" },
                ],
                VariavelResultado = "d(x,y)",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(Math.Pow(vars["y1"] - vars["x1"], 2) + Math.Pow(vars["y2"] - vars["x2"], 2))
            },

            new Formula
            {
                Id = "v2_top02", Nome = "Distância de Manhattan (d₁)",
                Categoria = "Vol2: Topologia", SubCategoria = "Espaços Métricos",
                Expressao = "d₁(x,y) = Σ|xᵢ-yᵢ|",
                ExprTexto = "d₁(x,y) = |x₁-y₁| + |x₂-y₂| + ... + |xₙ-yₙ|",
                Icone = "📐",
                Descricao = "A distância de Manhattan (ou taxicab) mede a soma das diferenças absolutas das coordenadas. Nome vem do padrão de ruas em grade de Manhattan - a distância percorrida andando em ruas perpendiculares.",
                Criador = "Hermann Minkowski",
                AnoOrigin = "~1900",
                ExemploPratico = "De (0,0) a (3,4): d₁=|3-0|+|4-0|=7. De (1,2,3) a (4,6,8): d₁=|4-1|+|6-2|+|8-3|=3+4+5=12. Usado em análise urbana e otimização.",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", Descricao = "Primeira coordenada do ponto x", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "y1", Nome = "y₁", Descricao = "Primeira coordenada do ponto y", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "x2", Nome = "x₂", Descricao = "Segunda coordenada do ponto x", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "y2", Nome = "y₂", Descricao = "Segunda coordenada do ponto y", ValorPadrao = 4, Unidade = "" },
                ],
                VariavelResultado = "d₁(x,y)",
                UnidadeResultado = "",
                Calcular = vars => Math.Abs(vars["y1"] - vars["x1"]) + Math.Abs(vars["y2"] - vars["x2"])
            },

            new Formula
            {
                Id = "v2_top03", Nome = "Distância de Chebyshev (d_∞)",
                Categoria = "Vol2: Topologia", SubCategoria = "Espaços Métricos",
                Expressao = "d_∞(x,y) = max|xᵢ-yᵢ|",
                ExprTexto = "d_∞(x,y) = max{|x₁-y₁|, |x₂-y₂|, ..., |xₙ-yₙ|}",
                Icone = "📐",
                Descricao = "A distância de Chebyshev (ou do supremo) é o máximo das diferenças absolutas das coordenadas. Representa o número mínimo de jogadas para um rei de xadrez ir de uma casa a outra (movimento em 8 direções).",
                Criador = "Pafnuty Chebyshev",
                AnoOrigin = "~1850",
                ExemploPratico = "De (0,0) a (3,4): d_∞=max{3,4}=4. De (1,5) a (6,7): d_∞=max{5,2}=5. Em xadrez, o rei leva 4 jogadas para ir de (0,0) a (3,4).",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", Descricao = "Primeira coordenada do ponto x", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "y1", Nome = "y₁", Descricao = "Primeira coordenada do ponto y", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "x2", Nome = "x₂", Descricao = "Segunda coordenada do ponto x", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "y2", Nome = "y₂", Descricao = "Segunda coordenada do ponto y", ValorPadrao = 4, Unidade = "" },
                ],
                VariavelResultado = "d_∞(x,y)",
                UnidadeResultado = "",
                Calcular = vars => Math.Max(Math.Abs(vars["y1"] - vars["x1"]), Math.Abs(vars["y2"] - vars["x2"]))
            },

            new Formula
            {
                Id = "v2_top04", Nome = "Característica de Euler χ (Superfície)",
                Categoria = "Vol2: Topologia", SubCategoria = "Topologia Algébrica",
                Expressao = "χ = V - E + F",
                ExprTexto = "χ (chi) = Vértices - Arestas + Faces",
                Icone = "📐",
                Descricao = "A característica de Euler relaciona vértices, arestas e faces de um poliedro ou grafo planar. É um invariante topológico: χ(esfera)=2, χ(toro)=0, χ(superfície de gênero g)=2-2g.",
                Criador = "Leonhard Euler",
                AnoOrigin = "1750",
                ExemploPratico = "Tetraedro: V=4, E=6, F=4 → χ=4-6+4=2. Cubo: V=8, E=12, F=6 → χ=8-12+6=2. Dodecaedro: V=20, E=30, F=12 → χ=2. Toro: χ=0.",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "Vértices", Descricao = "Número de vértices", ValorPadrao = 8, ValorMin = 0, Unidade = "" },
                    new() { Simbolo = "E", Nome = "Arestas", Descricao = "Número de arestas", ValorPadrao = 12, ValorMin = 0, Unidade = "" },
                    new() { Simbolo = "F", Nome = "Faces", Descricao = "Número de faces", ValorPadrao = 6, ValorMin = 0, Unidade = "" },
                ],
                VariavelResultado = "χ",
                UnidadeResultado = "",
                Calcular = vars => vars["V"] - vars["E"] + vars["F"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 3. GEOMETRIA DIFERENCIAL COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarGeometriaDiferencialCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_gd01", Nome = "Curvatura κ de Curva Parametrizada",
                Categoria = "Vol2: Geometria Diferencial", SubCategoria = "Curvas no Espaço",
                Expressao = "κ = |α''(s)|",
                ExprTexto = "κ = |α''(s)| para parametrização por arco",
                Icone = "∿",
                Descricao = "A curvatura mede o quanto uma curva se desvia de ser uma reta. Para parametrização por comprimento de arco s (|α'(s)|=1), a curvatura é a magnitude da segunda derivada.",
                Criador = "Gauss / Teoria de Curvas",
                AnoOrigin = "~1827",
                ExemploPratico = "Círculo de raio R: κ=1/R (constante). Reta: κ=0. Quanto menor o raio, maior a curvatura. Círculo de raio 5: κ=0.2. Raio 10: κ=0.1.",
                Variaveis = [
                    new() { Simbolo = "R", Nome = "Raio", Descricao = "Raio do círculo (exemplo)", ValorPadrao = 5, ValorMin = 0.001, Unidade = "m" },
                ],
                VariavelResultado = "κ",
                UnidadeResultado = "1/m",
                Calcular = vars => 1.0 / vars["R"]
            },

            new Formula
            {
                Id = "v2_gd02", Nome = "Curvatura de Gauss K",
                Categoria = "Vol2: Geometria Diferencial", SubCategoria = "Superfícies",
                Expressao = "K = κ₁ · κ₂",
                ExprTexto = "K = κ₁ · κ₂ (produto das curvaturas principais)",
                Icone = "∿",
                Descricao = "A curvatura de Gauss é o produto das curvaturas principais κ₁ e κ₂. É um invariante intrínseco (Theorema Egregium): pode ser medido sem sair da superfície. K>0: forma de esfera/elipsóide. K=0: plano/cilindro. K<0: sela (parabolóide hiperbólico).",
                Criador = "Carl Friedrich Gauss",
                AnoOrigin = "1827 (Theorema Egregium)",
                ExemploPratico = "Esfera de raio R: K=1/R² (positiva). Plano: K=0. Parabolóide hiperbólico (sela): K<0. Cilindro: K=0 (uma curvatura é zero).",
                Variaveis = [
                    new() { Simbolo = "k1", Nome = "κ₁", Descricao = "Primeira curvatura principal", ValorPadrao = 0.2, Unidade = "1/m" },
                    new() { Simbolo = "k2", Nome = "κ₂", Descricao = "Segunda curvatura principal", ValorPadrao = 0.2, Unidade = "1/m" },
                ],
                VariavelResultado = "K",
                UnidadeResultado = "1/m²",
                Calcular = vars => vars["k1"] * vars["k2"]
            },

            new Formula
            {
                Id = "v2_gd03", Nome = "Curvatura Média H",
                Categoria = "Vol2: Geometria Diferencial", SubCategoria = "Superfícies",
                Expressao = "H = (κ₁ + κ₂) / 2",
                ExprTexto = "H = (κ₁ + κ₂) / 2 (média aritmética das curvaturas principais)",
                Icone = "∿",
                Descricao = "A curvatura média é a média aritmética das curvaturas principais. Superfícies mínimas têm H=0 (ex: catenóide, helicoide, plano). Bolhas de sabão minimizam área e têm H constante proporcional à diferença de pressão (Laplace).",
                Criador = "Leonhard Euler / Joseph-Louis Lagrange",
                AnoOrigin = "~1760",
                ExemploPratico = "Esfera de raio R: H=1/R. Plano: H=0 (superfície mínima). Cilindro de raio R: H=1/(2R). Catenóide e helicoide: H=0 (superfícies mínimas).",
                Variaveis = [
                    new() { Simbolo = "k1", Nome = "κ₁", Descricao = "Primeira curvatura principal", ValorPadrao = 0.2, Unidade = "1/m" },
                    new() { Simbolo = "k2", Nome = "κ₂", Descricao = "Segunda curvatura principal", ValorPadrao = 0.2, Unidade = "1/m" },
                ],
                VariavelResultado = "H",
                UnidadeResultado = "1/m",
                Calcular = vars => (vars["k1"] + vars["k2"]) / 2.0
            },

            new Formula
            {
                Id = "v2_gd04", Nome = "Teorema de Gauss-Bonnet",
                Categoria = "Vol2: Geometria Diferencial", SubCategoria = "Teoremas Fundamentais",
                Expressao = "∫∫_M K dA = 2π · χ(M)",
                ExprTexto = "∫∫_M K dA = 2π · χ(M)",
                Icone = "∿",
                Descricao = "O Teorema de Gauss-Bonnet conecta geometria (integral da curvatura de Gauss) com topologia (característica de Euler). Para superfície compacta orientável: a integral total da curvatura depende apenas da topologia, não da geometria específica.",
                Criador = "Carl Friedrich Gauss / Pierre Ossian Bonnet",
                AnoOrigin = "1848",
                ExemploPratico = "Esfera S²: ∫∫K dA=4π, χ(S²)=2, então 4π=2π·2 ✓. Toro T²: ∫∫K dA=0, χ(T²)=0 ✓. Superfície de gênero g: ∫∫K dA=2π(2-2g).",
                Variaveis = [
                    new() { Simbolo = "chi", Nome = "χ(M)", Descricao = "Característica de Euler da superfície", ValorPadrao = 2, Unidade = "" },
                ],
                VariavelResultado = "∫∫K dA",
                UnidadeResultado = "",
                Calcular = vars => 2 * Math.PI * vars["chi"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 4. CÁLCULO DE VARIAÇÕES COMPLETO
    // ─────────────────────────────────────────────────────
    private void AdicionarCalculoVariacoesCompleto()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_cv01", Nome = "Funcional de Comprimento de Arco",
                Categoria = "Vol2: Cálculo de Variações", SubCategoria = "Funcionais Clássicos",
                Expressao = "L[y] = ∫ₐᵇ √(1 + (dy/dx)²) dx",
                ExprTexto = "L = ∫ √(1 + y'²) dx",
                Icone = "∫",
                Descricao = "O funcional de comprimento de arco calcula o comprimento de uma curva y(x) de a até b. A curva que minimiza este funcional (geodésica em ℝ²) é a reta. Aplicação da equação de Euler-Lagrange.",
                Criador = "Jakob Bernoulli / Euler / Lagrange",
                AnoOrigin = "~1690",
                ExemploPratico = "Para segmento de reta de (0,0) a (3,4): L=√(3²+4²)=5. Para parábola y=x² de 0 a 1: L≈1.478. Para semicírculo superior raio R: L=πR.",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", Descricao = "Ponto inicial x", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "y1", Nome = "y₁", Descricao = "Ponto inicial y", ValorPadrao = 0, Unidade = "" },
                    new() { Simbolo = "x2", Nome = "x₂", Descricao = "Ponto final x", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "y2", Nome = "y₂", Descricao = "Ponto final y", ValorPadrao = 4, Unidade = "" },
                ],
                VariavelResultado = "L (reta)",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(Math.Pow(vars["x2"] - vars["x1"], 2) + Math.Pow(vars["y2"] - vars["y1"], 2))
            },

            new Formula
            {
                Id = "v2_cv02", Nome = "Hamiltoniano H = Σpᵢq̇ᵢ - L",
                Categoria = "Vol2: Cálculo de Variações", SubCategoria = "Mecânica Hamiltoniana",
                Expressao = "H = p·q̇ - L",
                ExprTexto = "H = Σ pᵢ q̇ᵢ - L (transformada de Legendre)",
                Icone = "H",
                Descricao = "O Hamiltoniano é a transformada de Legendre do Lagrangiano, representando a energia total do sistema. Para sistemas conservativos: H=T+V (energia total). As equações de Hamilton substitúem as equações de Euler-Lagrange.",
                Criador = "William Rowan Hamilton",
                AnoOrigin = "1833",
                ExemploPratico = "Pêndulo: L=½ml²θ̇²-mgl(1-cosθ). Momento p=∂L/∂θ̇=ml²θ̇. H=pθ̇-L=p²/(2ml²)+mgl(1-cosθ). Oscilador harmônico: H=p²/(2m)+½kx².",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Momento p", Descricao = "Momento generalizado", ValorPadrao = 2, Unidade = "kg·m/s" },
                    new() { Simbolo = "q", Nome = "Posição q", Descricao = "Coordenada generalizada", ValorPadrao = 1, Unidade = "m" },
                    new() { Simbolo = "m", Nome = "Massa m", Descricao = "Massa do sistema", ValorPadrao = 1, Unidade = "kg" },
                    new() { Simbolo = "k", Nome = "Constante k", Descricao = "Constante elástica", ValorPadrao = 10, Unidade = "N/m" },
                ],
                VariavelResultado = "H (oscilador)",
                UnidadeResultado = "J",
                Calcular = vars => Math.Pow(vars["p"], 2) / (2 * vars["m"]) + 0.5 * vars["k"] * Math.Pow(vars["q"], 2)
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 5. FUNÇÕES ESPECIAIS COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarFuncoesEspeciaisCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_sp01", Nome = "Função Gamma Γ(n+1) = n!",
                Categoria = "Vol2: Funções Especiais", SubCategoria = "Função Gamma",
                Expressao = "Γ(n+1) = n!",
                ExprTexto = "Γ(n+1) = n! para n inteiro não-negativo",
                Icone = "Γ",
                Descricao = "A função Gamma estende o fatorial para números complexos. Para inteiros: Γ(n+1)=n!. Definição integral: Γ(z)=∫₀^∞ t^(z-1)e^(-t)dt. Satisfaz Γ(z+1)=z·Γ(z).",
                Criador = "Leonhard Euler",
                AnoOrigin = "1729",
                ExemploPratico = "Γ(1)=0!=1. Γ(2)=1!=1. Γ(3)=2!=2. Γ(4)=3!=6. Γ(5)=4!=24. Γ(6)=5!=120. Γ(1/2)=√π≈1.772. Γ(3/2)=√π/2≈0.886.",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "n", Descricao = "Número inteiro não-negativo", ValorPadrao = 5, ValorMin = 0, Unidade = "" },
                ],
                VariavelResultado = "n!",
                UnidadeResultado = "",
                Calcular = vars => {
                    int n = (int)vars["n"];
                    if (n < 0) return double.NaN;
                    if (n > 170) return double.PositiveInfinity; // Overflow
                    double result = 1;
                    for (int i = 2; i <= n; i++) result *= i;
                    return result;
                }
            },

            new Formula
            {
                Id = "v2_sp02", Nome = "Fórmula de Stirling para n!",
                Categoria = "Vol2: Funções Especiais", SubCategoria = "Função Gamma",
                Expressao = "n! ≈ √(2πn) · (n/e)^n",
                ExprTexto = "n! ≈ √(2πn) · (n/e)ⁿ",
                Icone = "Γ",
                Descricao = "A fórmula de Stirling fornece uma aproximação assintótica excelente para fatoriais grandes. O erro relativo tende a 0 quando n→∞. Fundamental em mecânica estatística e análise de algoritmos.",
                Criador = "James Stirling / Abraham de Moivre",
                AnoOrigin = "1730",
                ExemploPratico = "10! = 3628800, Stirling ≈ 3598696 (0.8% erro). 20! ≈ 2.43×10¹⁸, Stirling muito próximo (<0.5% erro). Para n=100, praticamente exato.",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "n", Descricao = "Número inteiro grande", ValorPadrao = 10, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "n! (Stirling)",
                UnidadeResultado = "",
                Calcular = vars => {
                    double n = vars["n"];
                    return Math.Sqrt(2 * Math.PI * n) * Math.Pow(n / Math.E, n);
                }
            },

            new Formula
            {
                Id = "v2_sp03", Nome = "Função Beta B(x,y)",
                Categoria = "Vol2: Funções Especiais", SubCategoria = "Função Beta",
                Expressao = "B(x,y) = Γ(x)Γ(y) / Γ(x+y)",
                ExprTexto = "B(x,y) = Γ(x)·Γ(y) / Γ(x+y)",
                Icone = "β",
                Descricao = "A função Beta está relacionada à função Gamma e aparece em integrais de produtos de potências. Simétrica: B(x,y)=B(y,x). Usada em distribuições estatísticas (Beta, Dirichlet) e cálculos de volumes.",
                Criador = "Leonhard Euler",
                AnoOrigin = "~1730",
                ExemploPratico = "B(1,1)=Γ(1)Γ(1)/Γ(2)=1·1/1=1. B(2,3)=Γ(2)Γ(3)/Γ(5)=1·2/24=1/12. B(0.5,0.5)=π. Distribuição Beta com α=2, β=5: normalização 1/B(2,5).",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "x", Descricao = "Primeiro parâmetro", ValorPadrao = 2, ValorMin = 0.001, Unidade = "" },
                    new() { Simbolo = "y", Nome = "y", Descricao = "Segundo parâmetro", ValorPadrao = 3, ValorMin = 0.001, Unidade = "" },
                ],
                VariavelResultado = "B(x,y)",
                UnidadeResultado = "",
                Calcular = vars => {
                    // Aproximação usando Gamma para inteiros pequenos
                    // Para implementação completa, usar biblioteca especializada
                    double x = vars["x"], y = vars["y"];
                    // Caso especial para inteiros
                    if (x == Math.Floor(x) && y == Math.Floor(y) && x >= 1 && y >= 1) {
                        int nx = (int)x, ny = (int)y;
                        double gx = 1, gy = 1, gxy = 1;
                        for (int i = 2; i < nx; i++) gx *= i;
                        for (int i = 2; i < ny; i++) gy *= i;
                        for (int i = 2; i < nx + ny; i++) gxy *= i;
                        return (gx * gy) / gxy;
                    }
                    return double.NaN; // Requer função Gamma completa
                }
            },

            new Formula
            {
                Id = "v2_sp04", Nome = "Polinômio de Legendre P₀,P₁,P₂",
                Categoria = "Vol2: Funções Especiais", SubCategoria = "Polinômios de Legendre",
                Expressao = "P₀(x)=1; P₁(x)=x; P₂(x)=(3x²-1)/2",
                ExprTexto = "P₀=1, P₁=x, P₂=(3x²-1)/2, P₃=(5x³-3x)/2",
                Icone = "P",
                Descricao = "Os polinômios de Legendre são ortogonais em [-1,1] e aparecem em expansões de potenciais, mecânica quântica e métodos numéricos. Satisfazem a equação de Legendre e fórmula de Rodrigues.",
                Criador = "Adrien-Marie Legendre",
                AnoOrigin = "1782",
                ExemploPratico = "P₀(0.5)=1. P₁(0.5)=0.5. P₂(0.5)=(3·0.25-1)/2=-0.125. P₃(0.5)=(5·0.125-1.5)/2=-0.4375. P₂(1)=1, P₂(-1)=1, P₂(0)=-0.5.",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "n", Descricao = "Ordem do polinômio", ValorPadrao = 2, ValorMin = 0, ValorMax = 3, Unidade = "" },
                    new() { Simbolo = "x", Nome = "x", Descricao = "Argumento", ValorPadrao = 0.5, ValorMin = -1, ValorMax = 1, Unidade = "" },
                ],
                VariavelResultado = "Pₙ(x)",
                UnidadeResultado = "",
                Calcular = vars => {
                    int n = (int)vars["n"];
                    double x = vars["x"];
                    return n switch {
                        0 => 1,
                        1 => x,
                        2 => (3 * x * x - 1) / 2.0,
                        3 => (5 * x * x * x - 3 * x) / 2.0,
                        _ => double.NaN
                    };
                }
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 6. ANÁLISE COMPLEXA COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseComplexaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_ac01", Nome = "Módulo de Número Complexo |z|",
                Categoria = "Vol2: Análise Complexa", SubCategoria = "Números Complexos",
                Expressao = "|z| = √(x² + y²)",
                ExprTexto = "|z| = √(Re(z)² + Im(z)²)",
                Icone = "ℂ",
                Descricao = "O módulo (ou valor absoluto) de z=x+iy é a distância da origem ao ponto (x,y) no plano complexo. Generaliza o valor absoluto real. |z₁·z₂|=|z₁|·|z₂|.",
                Criador = "Matemática complexa clássica",
                AnoOrigin = "~1800",
                ExemploPratico = "|3+4i|=√(9+16)=5. |1+i|=√2≈1.414. |-2+0i|=2. |e^(iπ)|=1 (ponto no círculo unitário). |5-12i|=13.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Re(z)", Descricao = "Parte real", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "y", Nome = "Im(z)", Descricao = "Parte imaginária", ValorPadrao = 4, Unidade = "" },
                ],
                VariavelResultado = "|z|",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"] * vars["x"] + vars["y"] * vars["y"])
            },

            new Formula
            {
                Id = "v2_ac02", Nome = "Argumento de z: arg(z) = arctan(y/x)",
                Categoria = "Vol2: Análise Complexa", SubCategoria = "Números Complexos",
                Expressao = "arg(z) = arctan(Im(z)/Re(z))",
                ExprTexto = "arg(z) = arctan(y/x) (com ajuste de quadrante)",
                Icone = "ℂ",
                Descricao = "O argumento de z é o ângulo θ que o vetor z faz com o eixo real positivo, medido no sentido anti-horário. Normalmente -π < arg(z) ≤ π. arg(z₁·z₂) = arg(z₁) + arg(z₂) (módulo 2π).",
                Criador = "Euler / Forma polar",
                AnoOrigin = "~1750",
                ExemploPratico = "arg(1+i)=π/4=45°. arg(-1)=π=180°. arg(i)=π/2=90°. arg(1)=0. arg(-i)=-π/2=-90°. arg(3+4i)≈0.927 rad≈53.13°.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Re(z)", Descricao = "Parte real", ValorPadrao = 3, Unidade = "" },
                    new() { Simbolo = "y", Nome = "Im(z)", Descricao = "Parte imaginária", ValorPadrao = 4, Unidade = "" },
                ],
                VariavelResultado = "arg(z) [rad]",
                UnidadeResultado = "rad",
                Calcular = vars => Math.Atan2(vars["y"], vars["x"])
            },

            new Formula
            {
                Id = "v2_ac03", Nome = "Fórmula de Euler e^(iθ)",
                Categoria = "Vol2: Análise Complexa", SubCategoria = "Funções Analíticas",
                Expressao = "e^(iθ) = cos(θ) + i·sin(θ)",
                ExprTexto = "e^(iθ) = cos θ + i sin θ",
                Icone = "ℂ",
                Descricao = "A fórmula de Euler conecta a exponencial complexa com funções trigonométricas. É a base da forma polar: z=r·e^(iθ). Caso especial θ=π: e^(iπ)+1=0 (identidade de Euler).",
                Criador = "Leonhard Euler",
                AnoOrigin = "1748",
                ExemploPratico = "e^(iπ)=cos(π)+i·sin(π)=-1+0i=-1. e^(iπ/2)=i. e^(i0)=1. e^(i2π)=1. e^(iπ/4)=(√2/2)(1+i).",
                Variaveis = [
                    new() { Simbolo = "theta", Nome = "θ [rad]", Descricao = "Ângulo em radianos", ValorPadrao = Math.PI / 4, Unidade = "rad" },
                ],
                VariavelResultado = "|e^(iθ)|",
                UnidadeResultado = "",
                Calcular = vars => 1.0 // |e^(iθ)| = 1 sempre
            },

            new Formula
            {
                Id = "v2_ac04", Nome = "Resíduo de Polo Simples",
                Categoria = "Vol2: Análise Complexa", SubCategoria = "Teoria de Resíduos",
                Expressao = "Res(f,a) = lim_{z→a} (z-a)·f(z)",
                ExprTexto = "Res(f,a) = lim_{z→a} [(z-a)·f(z)] (polo simples)",
                Icone = "ℂ",
                Descricao = "O resíduo de f em um polo simples a é o coeficiente a₋₁ na série de Laurent. Teorema dos Resíduos: ∮f(z)dz = 2πi·Σ Res(f,aₖ). Fundamental para calcular integrais reais e complexas.",
                Criador = "Augustin-Louis Cauchy",
                AnoOrigin = "~1825",
                ExemploPratico = "f(z)=1/(z-1) em z=1: Res=1. f(z)=1/z² em z=0: Res=0 (polo duplo). f(z)=e^z/z em z=0: Res=1. f(z)=sin(z)/z em z=0: Res=1.",
                Variaveis = [
                    new() { Simbolo = "A", Nome = "Coef. numerador", Descricao = "Para f(z)=A/(z-a)", ValorPadrao = 1, Unidade = "" },
                ],
                VariavelResultado = "Res(f,a)",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] // Para polo simples f(z)=A/(z-a), resíduo é A
            },
        ]);
    }
}
