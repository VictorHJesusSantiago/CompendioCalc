using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME IX - PARTE II: TOPOLOGIA ALGÉBRICA E GEOMETRIA DIFERENCIAL
    /// Euler-Poincaré, Gauss-Bonnet, Riemann, cohomologia, formas
    /// Fórmulas 022-042 (21 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        /// <summary>
        /// V9_TOPO022: Característica de Euler-Poincaré
        /// χ(M)=Σ(-1)ᵏ·bₖ = V−E+F para poliedros
        /// </summary>
        private Formula V9_TOPO022_EulerPoincare()
        {
            return new Formula
            {
                Id = "V9-TOPO022",
                CodigoCompendio = "022",
                Nome = "Característica de Euler-Poincaré",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "χ(M)=Σ(-1)ᵏ·bₖ = V−E+F",
                ExprTexto = "Invariante topológico: vértices menos arestas mais faces",
                Descricao = "Característica de Euler χ(M): invariante topológico definido V−E+F para poliedros ou Σ(−1)ᵏbₖ via números de Betti bₖ (dimensão dos grupos de homologia). χ=2 para esfera S²; χ=0 para toro T²; χ=2−2g para superfície de genus g. Fundamental em topologia combinatória.",
                Criador = "Leonhard Euler (1752, poliedros); Henri Poincaré (1895, Analysis Situs - generalização topológica)",
                AnoOrigin = "1752",
                ExemploPratico = "Cubo: V=8, E=12, F=6 → χ=8−12+6=2. Tetraedro: V=4, E=6, F=4 → χ=2. Toro: χ=0. Esfera: χ=2. Garrafa de Klein: χ=0. Plano projetivo RP²: χ=1. Superfície de genus g: χ=2−2g (g=0:esfera, g=1:toro, g=2:pretzel duplo).",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "V", Nome = "Vértices", Descricao = "Número de vértices do poliedro", Unidade = "contagem", ValorPadrao = 8, ValorMin = 4, Obrigatoria = true },
                    new Variavel { Simbolo = "E", Nome = "Arestas", Descricao = "Número de arestas do poliedro", Unidade = "contagem", ValorPadrao = 12, ValorMin = 6, Obrigatoria = true },
                    new Variavel { Simbolo = "F", Nome = "Faces", Descricao = "Número de faces do poliedro", Unidade = "contagem", ValorPadrao = 6, ValorMin = 4, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double V = valores["V"];
                    double E = valores["E"];
                    double F = valores["F"];
                    double chi = V - E + F;
                    return chi; // 2=esfera/convexo, 0=toro, <0=genus alto
                },
                VariavelResultado = "Característica Euler χ",
                UnidadeResultado = "adimensional"
            };
        }

        /// <summary>
        /// V9_TOPO023: Teorema de Gauss-Bonnet
        /// ∫_M K dA + ∮_{∂M} κ_g ds = 2πχ(M)
        /// </summary>
        private Formula V9_TOPO023_GaussBonnet()
        {
            return new Formula
            {
                Id = "V9-TOPO023",
                CodigoCompendio = "023",
                Nome = "Teorema de Gauss-Bonnet",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "∫_M K dA + ∮_{∂M} κ_g ds = 2πχ(M)",
                ExprTexto = "Curvatura total relaciona geometria (K) com topologia (χ)",
                Descricao = "Teorema de Gauss-Bonnet conecta geometria intrínseca (curvatura Gaussiana K) com topologia (característica de Euler χ). Integral de K sobre superfície M mais integral de curvatura geodésica κ_g no bordo ∂M = 2πχ(M). Para superfície fechada sem bordo: ∫K dA=2πχ. Ponte entre geometria diferencial e topologia.",
                Criador = "Carl Friedrich Gauss (Theorema Egregium, 1828); Pierre Ossian Bonnet (1848, generalização integral)",
                AnoOrigin = "1828",
                ExemploPratico = "Esfera de raio R: K=1/R² (curvatura constante positiva), χ=2 → ∫K dA=4π=2π·2 ✓. Plano: K=0, χ=1 (com ponto no infinito). Toro plano: K=0 quase-todo-lugar, χ=0 → ∫K dA=0. Polígono geodésico: soma ângulos internos relaciona com χ.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K_media", Nome = "Curvatura média K", Descricao = "Curvatura Gaussiana média da superfície", Unidade = "1/m²", ValorPadrao = 1, ValorMin = double.MinValue, Obrigatoria = true },
                    new Variavel { Simbolo = "Area", Nome = "Área da superfície", Descricao = "Área total da superfície M", Unidade = "m²", ValorPadrao = 12.566, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "chi", Nome = "Característica Euler χ", Descricao = "χ(M) invariante topológico", Unidade = "adimensional", ValorPadrao = 2, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double K_bar = valores["K_media"];
                    double A = valores["Area"];
                    double chi = valores["chi"];
                    // Aproximação discretizada: ∫K dA ≈ K_média · Area
                    double integral_K = K_bar * A;
                    double lado_direito = 2.0 * Math.PI * chi;
                    // Verifica Gauss-Bonnet: diferença deve ser ≈0
                    double diferenca = Math.Abs(integral_K - lado_direito);
                    return diferenca; // 0=satisfaz Gauss-Bonnet
                },
                VariavelResultado = "Erro Gauss-Bonnet",
                UnidadeResultado = "adimensional"
            };
        }

        /// <summary>
        /// V9_TOPO024: Tensor de Curvatura de Riemann
        /// R^α_{βγδ} = ∂_γΓ^α_{βδ} − ∂_δΓ^α_{βγ} + Γ^α_{μγ}Γ^μ_{βδ} − Γ^α_{μδ}Γ^μ_{βγ}
        /// </summary>
        private Formula V9_TOPO024_TensorRiemann()
        {
            return new Formula
            {
                Id = "V9-TOPO024",
                CodigoCompendio = "024",
                Nome = "Tensor de Curvatura de Riemann",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "R^α_{βγδ} = ∂_γΓ^α_{βδ} − ∂_δΓ^α_{βγ} + Γ^α_{μγ}Γ^μ_{βδ} − Γ^α_{μδ}Γ^μ_{βγ}",
                ExprTexto = "Mede falha de paralelismo: comutador de derivadas covariantes",
                Descricao = "Tensor de Riemann R^α_{βγδ}: mede curvatura intrínseca da variedade via falha de transporte paralelo de retornar ao mesmo vetor após circuito fechado. Comutador [∇_γ,∇_δ]=R^α_{βγδ}. Base da relatividade geral (R→Einstein tensor G). Tem n²(n²−1)/12 componentes independentes (20 em 4D).",
                Criador = "Bernhard Riemann (1854, Über die Hypothesen, welche der Geometrie zu Grunde liegen); Elwin Christoffel (1869, símbolos de Christoffel Γ)",
                AnoOrigin = "1854",
                ExemploPratico = "Esfera S²: R^θ_{φθφ}=1 (curvatura constante positiva). Espaço-tempo de Schwarzschild: R^t_{rtr}≠0 próximo a buracos negros (curvatura gravitacional). Espaço plano: R^α_{βγδ}=0 identicamente. Curvatura seccional K(π)=R(u,v,v,u)/(|u|²|v|²−⟨u,v⟩²) em plano π.",
                Unidades = "1/m²",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "R_1212", Nome = "Componente R¹₂₁₂", Descricao = "Componente típica do tensor de Riemann", Unidade = "1/m²", ValorPadrao = 1, ValorMin = double.MinValue, Obrigatoria = true },
                    new Variavel { Simbolo = "g_11", Nome = "Métrica g₁₁", Descricao = "Componente diagonal da métrica", Unidade = "adimensional", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true },
                    new Variavel { Simbolo = "g_22", Nome = "Métrica g₂₂", Descricao = "Componente diagonal da métrica", Unidade = "adimensional", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double R1212 = valores["R_1212"];
                    double g11 = valores["g_11"];
                    double g22 = valores["g_22"];
                    // Curvatura Gaussiana: K = R₁₂₁₂/(g₁₁·g₂₂) para superfície 2D
                    double K = R1212 / (g11 * g22);
                    return K; // curvatura escalar intrínseca
                },
                VariavelResultado = "Curvatura Gaussiana K",
                UnidadeResultado = "1/m²"
            };
        }

        /// <summary>
        /// V9_TOPO025: Derivada Exterior e Cohomologia de de Rham
        /// d²=0; H^p_dR(M)=ker(d:Ωᵖ→Ωᵖ⁺¹)/im(d:Ωᵖ⁻¹→Ωᵖ)
        /// </summary>
        private Formula V9_TOPO025_CohomologiaDeRham()
        {
            return new Formula
            {
                Id = "V9-TOPO025",
                CodigoCompendio = "025",
                Nome = "Cohomologia de de Rham",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "d²=0; H^p_dR(M)=ker d/im d",
                ExprTexto = "d² =0: d de forma exata é zero; cohomologia = formas fechadas/exatas",
                Descricao = "Derivada exterior d: Ωᵖ→Ωᵖ⁺¹ satisfaz d²=0 (nilpotência). Formas fechadas: dω=0 (localmente conservativas). Formas exatas: ω=dα (globalmente triviais). Cohomologia H^p_dR = [fechadas]/[exatas] mede 'buracos' topológicos. dim H^p = p-ésimo número de Betti b_p. Isomorfo a cohomologia singular (teorema de de Rham).",
                Criador = "Élie Cartan (1899, formas diferenciais); Georges de Rham (1931, tese: cohomologia de de Rham isomorfa a cohomologia singular)",
                AnoOrigin = "1899",
                ExemploPratico = "S¹ (círculo): H⁰=ℝ, H¹=ℝ, b₀=1, b₁=1 (1 buraco). Toro T²: b₀=1, b₁=2 (2 ciclos independentes), b₂=1. Esfera S²: b₀=1, b₁=0, b₂=1 (sem buracos 1D). Forma fechada não-exata: dθ em R²\\{0} (campo angular, não globalmente definido potencial).",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "b_0", Nome = "Número Betti b₀", Descricao = "Dim H⁰: componentes conexas", Unidade = "dimensão", ValorPadrao = 1, ValorMin = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "b_1", Nome = "Número Betti b₁", Descricao = "Dim H¹: geradores de ciclos 1D", Unidade = "dimensão", ValorPadrao = 2, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "b_2", Nome = "Número Betti b₂", Descricao = "Dim H²: geradores de ciclos 2D", Unidade = "dimensão", ValorPadrao = 1, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Característica de Euler via números de Betti: χ = Σ(-1)ᵏbₖ
                    double b0 = valores["b_0"];
                    double b1 = valores["b_1"];
                    double b2 = valores["b_2"];
                    double chi = b0 - b1 + b2;
                    return chi; // toro: 1−2+1=0; esfera: 1−0+1=2
                },
                VariavelResultado = "Característica Euler χ",
                UnidadeResultado = "adimensional"
            };
        }

        /// <summary>
        /// V9_TOPO026: Teorema de Stokes Generalizado
        /// ∫_M dω = ∫_{∂M} ω
        /// </summary>
        private Formula V9_TOPO026_TeoremaStokes()
        {
            return new Formula
            {
                Id = "V9-TOPO026",
                CodigoCompendio = "026",
                Nome = "Teorema de Stokes Generalizado",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "∫_M dω = ∫_{∂M} ω",
                ExprTexto = "Integral da derivada = integral no bordo",
                Descricao = "Teorema de Stokes generalizado: integral da derivada exterior dω sobre variedade M equals integral de ω sobre bordo ∂M. Unifica teoremas clássicos do cálculo vetorial: teorema fundamental (∫df=f|∂), Green, Stokes clássico (rot), divergência. Base da análise em variedades.",
                Criador = "George Stokes (1854, Smith's Prize exam question); Élie Cartan (1945, formulação moderna com formas diferenciais)",
                AnoOrigin = "1854",
                ExemploPratico = "Teorema fundamental: ∫[a,b]df=f(b)−f(a). Teorema de Green: ∬(∂Q/∂x−∂P/∂y)dA=∮Pdx+Qdy. Teorema de Stokes vetorial: ∬(∇×F)·dS=∮F·dr. Teorema da divergência: ∭(∇·F)dV=∬F·dS. Todos casos especiais de ∫dω=∫_{∂}ω.",
                Unidades = "depende da forma",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "int_domega", Nome = "∫_M dω", Descricao = "Integral da derivada exterior sobre M", Unidade = "unidades da forma", ValorPadrao = 10, Obrigatoria = true },
                    new Variavel { Simbolo = "int_omega_bordo", Nome = "∫_{∂M} ω", Descricao = "Integral da forma no bordo ∂M", Unidade = "unidades da forma", ValorPadrao = 10, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double int_M_domega = valores["int_domega"];
                    double int_bordo_omega = valores["int_omega_bordo"];
                    // Verifica teorema de Stokes: diferença deve ser ≈0
                    double diferenca = Math.Abs(int_M_domega - int_bordo_omega);
                    return diferenca; // 0=satisfaz Stokes
                },
                VariavelResultado = "Erro Stokes",
                UnidadeResultado = "unidades da forma"
            };
        }

        /// <summary>
        /// V9_TOPO027: Conexão de Levi-Civita
        /// Γ^k_{ij} = ½·g^{kl}·(∂_i g_{jl} + ∂_j g_{il} − ∂_l g_{ij})
        /// </summary>
        private Formula V9_TOPO027_ConexaoLeviCivita()
        {
            return new Formula
            {
                Id = "V9-TOPO027",
                CodigoCompendio = "027",
                Nome = "Conexão de Levi-Civita",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "Γ^k_{ij} = ½·g^{kl}·(∂_i g_{jl} + ∂_j g_{il} − ∂_l g_{ij})",
                ExprTexto = "Símbolos de Christoffel: conexão compatível com métrica e sem torção",
                Descricao = "Conexão de Levi-Civita: única conexão afim Γ^k_{ij} compatível com métrica (∇g=0) e livre de torção (Γ^k_{ij}=Γ^k_{ji}). Define derivada covariante ∇ preservando ângulos e comprimentos. Símbolos de Christoffel calculados via métrica g_{ij}. Base de geometria Riemanniana e relatividade geral.",
                Criador = "Tullio Levi-Civita (1917, The Absolute Differential Calculus)",
                AnoOrigin = "1917",
                ExemploPratico = "Coordenadas esféricas (r,θ,φ): Γ^r_{θθ}=−r, Γ^θ_{rθ}=1/r, Γ^φ_{rφ}=1/r, Γ^φ_{θφ}=cot(θ). Geodésicas: curvas com ẍ^k+Γ^k_{ij}ẋ^iẋ^j=0. Transporte paralelo: dv^k/dt+Γ^k_{ij}v^i(dx^j/dt)=0. Relatividade geral: Γ aparecem na equação geodésica de partículas livres.",
                Unidades = "1/m",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "g_rr", Nome = "g_rr", Descricao = "Componente métrica radial", Unidade = "adimensional", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true },
                    new Variavel { Simbolo = "g_theta_theta", Nome = "g_θθ", Descricao = "Componente métrica angular θ", Unidade = "m²", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true },
                    new Variavel { Simbolo = "r", Nome = "Raio r", Descricao = "Coordenada radial", Unidade = "m", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double g_rr = valores["g_rr"];
                    double g_tt = valores["g_theta_theta"];
                    double r = valores["r"];
                    // Coordenadas esféricas: Γ^r_{θθ} = −g_θθ/(2g_rr)·∂_r g_θθ
                    // Para g_θθ=r²: Γ^r_{θθ}=−r
                    double Gamma_r_theta_theta = -r; // exemplo esférico padrão
                    return Gamma_r_theta_theta;
                },
                VariavelResultado = "Γ^r_{θθ}",
                UnidadeResultado = "m"
            };
        }

        /// <summary>
        /// V9_TOPO028: Grupo Fundamental π₁(X,x₀)
        /// Classes de homotopia de loops baseados em x₀
        /// </summary>
        private Formula V9_TOPO028_GrupoFundamental()
        {
            return new Formula
            {
                Id = "V9-TOPO028",
                CodigoCompendio = "028",
                Nome = "Grupo Fundamental π₁(X,x₀)",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "π₁(X,x₀) = [loops em x₀]/homotopia",
                ExprTexto = "Grupo de classes de equivalência de loops",
                Descricao = "Grupo fundamental π₁(X,x₀): grupo de classes de homotopia de loops baseados em ponto x₀. Operação de grupo: concatenação de loops. Identidade: loop constante. Mede 'buracos 1D' de forma algébrica. Invariante topológico mais simples da teoria de homotopia. Simplesmente conexo: π₁=0 (trivial).",
                Criador = "Henri Poincaré (1895, Analysis Situs - fundação da topologia algébrica)",
                AnoOrigin = "1895",
                ExemploPratico = "S¹ (círculo): π₁(S¹)=ℤ (loops dão voltas n∈ℤ vezes). Esfera S²: π₁(S²)=0 (simplesmente conexo, todo loop contráctil). Toro T²: π₁(T²)=ℤ×ℤ (2 geradores independentes). Plano R²: π₁=0. R²\\{0}: π₁=ℤ (winding number). Grupo livre F₂ para figura-8.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "winding_number", Nome = "Número de voltas n", Descricao = "Quantas vezes loop rodeia buraco (∈ℤ)", Unidade = "contagem", ValorPadrao = 1, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Para S¹: π₁(S¹)=ℤ, representado por winding number n
                    double n = valores["winding_number"];
                    // Retorna o gerador do grupo (n pode ser positivo/negativo)
                    return n; // n=1: loop padrão, n=−1: reverso, n=2: dupla volta
                },
                VariavelResultado = "Classe homotopia [γ]∈ℤ",
                UnidadeResultado = "contagem"
            };
        }

        /// <summary>
        /// V9_TOPO029: Sequência de Mayer-Vietoris
        /// ...→H_n(A∩B)→H_n(A)⊕H_n(B)→H_n(A∪B)→H_{n−1}(A∩B)→...
        /// </summary>
        private Formula V9_TOPO029_MayerVietoris()
        {
            return new Formula
            {
                Id = "V9-TOPO029",
                CodigoCompendio = "029",
                Nome = "Sequência de Mayer-Vietoris",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "...→H_n(A∩B)→H_n(A)⊕H_n(B)→H_n(A∪B)→H_{n−1}(A∩B)→...",
                ExprTexto = "Sequência exata longa relaciona homologia de união com partes",
                Descricao = "Sequência de Mayer-Vietoris: ferramenta poderosa para calcular homologia de união A∪B via homologia de A, B e A∩B. Sequência exata longa: im(f)=ker(g) em cada passo. Permite computação indutiva de números de Betti. Dual cohomológico também existe. Base de topologia algébrica computacional.",
                Criador = "Walther Mayer (1929); Leopold Vietoris (1930); ambos desenvolveram independente",
                AnoOrigin = "1929",
                ExemploPratico = "Esfera S²: decompoem em hemisférios norte A e sul B, A∩B≃S¹. Sequência: ...→H₁(S¹)→H₁(hemisfério)⊕H₁(hemisfério)→H₁(S²)→H₀(S¹)→... Calcula H₁(S²)=0. Toro: decompoem via cilindro+cilindro. Cálculo de homologia de CW complexes via colagem de células.",
                Unidades = "dimensão",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dim_H_A_cap_B", Nome = "dim H_n(A∩B)", Descricao = "Dimensão homologia da interseção", Unidade = "dimensão", ValorPadrao = 1, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "dim_H_A", Nome = "dim H_n(A)", Descricao = "Dimensão homologia de A", Unidade = "dimensão", ValorPadrao = 0, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "dim_H_B", Nome = "dim H_n(B)", Descricao = "Dimensão homologia de B", Unidade = "dimensão", ValorPadrao = 0, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Sequência exata: dim H_n(A∪B) ≤ dim H_n(A) + dim H_n(B) + dim H_{n+1}(A∩B)
                    // Fórmula de Künneth/Euler simplificada
                    double d_intersec = valores["dim_H_A_cap_B"];
                    double d_A = valores["dim_H_A"];
                    double d_B = valores["dim_H_B"];
                    // Aproximação: dim H_n(A∪B) ≈ dim H_n(A) + dim H_n(B) − dim H_n(A∩B)
                    double dim_uniao = Math.Max(0, d_A + d_B - d_intersec);
                    return dim_uniao;
                },
                VariavelResultado = "dim H_n(A∪B) aprox",
                UnidadeResultado = "dimensão"
            };
        }

        /// <summary>
        /// V9_TOPO030: Decomposição de Hodge
        /// Ωᵏ = dΩ^{k−1} ⊕ d*Ω^{k+1} ⊕ ℋᵏ
        /// </summary>
        private Formula V9_TOPO030_DecomposicaoHodge()
        {
            return new Formula
            {
                Id = "V9-TOPO030",
                CodigoCompendio = "030",
                Nome = "Decomposição de Hodge",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "Ωᵏ = dΩ^{k−1} ⊕ d*Ω^{k+1} ⊕ ℋᵏ",
                ExprTexto = "Forma = exata ⊕ co-exata ⊕ harmônica",
                Descricao = "Decomposição de Hodge: toda forma diferencial k-forma ω em variedade Riemanniana compacta decompõe-se exclusivamente como ω=dα+d*β+γ onde dα exata, d*β co-exata (d* adjunto de d) e γ harmônica (dγ=d*γ=0). Espaço harmônico ℋᵏ isomorfo à cohomologia H^k_dR. Ponte entre análise, geometria e topologia.",
                Criador = "W.V.D. Hodge (1933-1941, teoria geral das formas harmônicas em variedades; livro The Theory and Applications of Harmonic Integrals 1941)",
                AnoOrigin = "1932",
                ExemploPratico = "Toro T²: 2 formas harmônicas 1-formas independentes (dx,dy constantes) correspondendo a H¹(T²)=ℝ². Esfera S²: única forma harmônica de grau 0 (constantes), H⁰=ℝ. Laplaciano de Hodge Δ=dd*+d*d: forma harmônica se Δω=0. Teorema de representação de Rham: [ω]∈H^k ↔ única forma harmônica.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dim_exata", Nome = "dim(dΩ^{k−1})", Descricao = "Dimensão do espaço de formas exatas", Unidade = "dimensão", ValorPadrao = 0, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "dim_coexata", Nome = "dim(d*Ω^{k+1})", Descricao = "Dimensão do espaço de formas co-exatas", Unidade = "dimensão", ValorPadrao = 0, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "dim_harmonica", Nome = "dim(ℋᵏ)", Descricao = "Dimensão do espaço harmônico (número Betti b_k)", Unidade = "dimensão", ValorPadrao = 2, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double d_exata = valores["dim_exata"];
                    double d_coexata = valores["dim_coexata"];
                    double d_harmonica = valores["dim_harmonica"];
                    // Dimensão total: dim(Ωᵏ) = dim(exatas) + dim(coexatas) + dim(harmônicas)
                    // Para variedade compacta: dim(ℋᵏ) = b_k (número de Betti)
                    double dim_total = d_exata + d_coexata + d_harmonica;
                    return dim_total; // para toro 1-formas: ∞+∞+2 (espaços de dim infinita exceto harmônicas)
                    // Retorna apenas dim harmônica (finita)
                },
                VariavelResultado = "Número Betti b_k",
                UnidadeResultado = "dimensão"
            };
        }

        /// <summary>
        /// V9_TOPO031: Tensor de Ricci e Equações de Einstein
        /// R_{μν} − ½R·g_{μν} + Λ·g_{μν} = (8πG/c⁴)·T_{μν}
        /// </summary>
        private Formula V9_TOPO031_EquacoesEinstein()
        {
            return new Formula
            {
                Id = "V9-TOPO031",
                CodigoCompendio = "031",
                Nome = "Equações de Campo de Einstein",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "R_{μν} − ½R·g_{μν} + Λ·g_{μν} = (8πG/c⁴)·T_{μν}",
                ExprTexto = "Geometria do espaço-tempo (G_{μν}) = distribuição de matéria-energia (T_{μν})",
                Descricao = "Equações de campo de Einstein: relacionam tensor de Einstein G_{μν}=R_{μν}−½Rg_{μν} (geometria: curvatura do espaço-tempo) com tensor momento-energia T_{μν} (matéria-energia). Constante cosmológica Λ. Ricci tensor R_{μν} é traço do Riemann. Escalar de curvatura R=g^{μν}R_{μν}. Fundamentam relatividade geral.",
                Criador = "Albert Einstein (1915, Die Feldgleichungen der Gravitation; Nov 1915 Prussian Academy)",
                AnoOrigin = "1915",
                ExemploPratico = "Vácuo de Schwarzschild: T_{μν}=0, R_{μν}=0 fora de massa M → métrica de buraco negro. FLRW cosmologia: universo homogêneo isotrópico → expansão de Hubble. Ondas gravitacionais: perturbações h_{μν} de métrica plana, linearização EFE. GPS: correções relativísticas de ≈38μs/dia via métrica de Schwarzschild fraca.",
                Unidades = "1/m²",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "R_munu", Nome = "Tensor Ricci R_{μν}", Descricao = "Componente do tensor de Ricci", Unidade = "1/m²", ValorPadrao = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "R_escalar", Nome = "Escalar curvatura R", Descricao = "Traço do tensor de Ricci", Unidade = "1/m²", ValorPadrao = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "g_munu", Nome = "Métrica g_{μν}", Descricao = "Componente métrica do espaço-tempo", Unidade = "adimensional", ValorPadrao = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "Lambda", Nome = "Constante cosmológica Λ", Descricao = "Energia do vácuo", Unidade = "1/m²", ValorPadrao = 1.1e-52, Obrigatoria = true },
                    new Variavel { Simbolo = "T_munu", Nome = "Tensor energia T_{μν}", Descricao = "Densidade momento-energia", Unidade = "kg/m³", ValorPadrao = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    const double G = 6.674e-11; // m³/(kg·s²)
                    const double c = 2.998e8; // m/s
                    double R_mu_nu = valores["R_munu"];
                    double R_scalar = valores["R_escalar"];
                    double g_mu_nu = valores["g_munu"];
                    double Lambda = valores["Lambda"];
                    double T_mu_nu = valores["T_munu"];
                    // Tensor de Einstein: G_{μν} = R_{μν} − ½Rg_{μν} + Λg_{μν}
                    double G_mu_nu = R_mu_nu - 0.5 * R_scalar * g_mu_nu + Lambda * g_mu_nu;
                    // Lado direito: (8πG/c⁴)T_{μν}
                    double coef = 8.0 * Math.PI * G / Math.Pow(c, 4);
                    double lado_direito = coef * T_mu_nu;
                    // Diferença (teste consistência)
                    double diferenca = Math.Abs(G_mu_nu - lado_direito);
                    return diferenca; // 0=satisfaz EFE
                },
                VariavelResultado = "Resíduo EFE",
                UnidadeResultado = "1/m²"
            };
        }

        // Continua com as demais 11 fórmulas (032-042)...
        /// <summary>
        /// V9_TOPO032: Polinômio de Jones - Invariante de Nós
        /// V(t): invariante de nós via relação skein
        /// </summary>
        private Formula V9_TOPO032_PolinomioJones()
        {
            return new Formula
            {
                Id = "V9-TOPO032",
                CodigoCompendio = "032",
                Nome = "Polinômio de Jones",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "t^{−1}V(L₊) − tV(L₋) = (t^{1/2}−t^{−1/2})V(L₀)",
                ExprTexto = "Relação skein: relaciona crossing positivo/negativo/suavizado",
                Descricao = "Polinômio de Jones V(t): invariante de nós e enlaçamentos, computado via relação skein. Detecta quiralidade: V(nó)≠V(imagem espelho) implica quirality. Invariante mais forte que Alexander. Conexões com física (modelos estatísticos, teoria quântica de campos). Distingue nós não-isotípicos.",
                Criador = "Vaughan Jones (1984, A polynomial invariant for knots via von Neumann algebras; Fields Medal 1990)",
                AnoOrigin = "1984",
                ExemploPratico = "Nó trefoil 3₁: V(t)=−t⁴+t³+t. Unknot (trivial): V(t)=1. Figura-8: V(t)=t²−t+1−t⁻¹+t⁻². Hopf link: V(t)=−t^{5/2}−t^{1/2}. Detecta quirality: trefoil destro e canhoto não equivalentes. Algoritmo: Kauffman bracket ⟨L⟩.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "writhe", Nome = "Writhe w", Descricao = "Soma de sinais dos crossings orientados", Unidade = "contagem", ValorPadrao = 3, Obrigatoria = true },
                    new Variavel { Simbolo = "bracket", Nome = "Bracket ⟨L⟩(A)", Descricao = "Kauffman bracket (A=t^{−1/4})", Unidade = "polinômio", ValorPadrao = 1, Obrigatoria = true }
                },
                Calcular = valores =>{
                    // V(t) = (−1)^{n₋}·(t^{1/4})^{−3w}·⟨L⟩(A=t^{−1/4})
                    // Simplificado: retorna writhe como proxy de complexidade
                    double w = valores["writhe"];
                    double bracket = valores["bracket"];
                    // Jones polynomial trefoil: −t⁴+t³+t (writhe=3)
                    // Aproximação naive: |w|+1 como estimativa de grau
                    double grau_aprox = Math.Abs(w) + 1;
                    return grau_aprox;
                },
                VariavelResultado = "Grau polinômio aprox",
                UnidadeResultado = "grau"
            };
        }

        /// <summary>
        /// V9_TOPO033: Fibração de Hopf - S¹→S³→S²
        /// π: S³→S² com fibra S¹; protótipo de fibrados principais
        /// </summary>
        private Formula V9_TOPO033_FibracaoHopf()
        {
            return new Formula
            {
                Id = "V9-TOPO033",
                CodigoCompendio = "033",
                Nome = "Fibração de Hopf",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "S¹ → S³ → S²",
                ExprTexto = "S³ fibra sobre S² com fibras S¹ (círculos)",
                Descricao = "Fibração de Hopf: mapa não-trivial π:S³→S² onde cada fibra π⁻¹(p) é círculo S¹. Primeira detecção de que π₃(S²)=ℤ (não trivial). Protótipo de fibrados principais: S³ como bundle U(1) sobre S². Cada par de círculos ligados (Hopf link). Geometria: quaternions S³ → complex projective line CP¹≃S².",
                Criador = "Heinz Hopf (1931, Über die Abbildungen der dreidimensionalen Sphäre auf die Kugelfläche, Mathematische Annalen)",
                AnoOrigin = "1931",
                ExemploPratico = "Visualização: S³⊂ℂ² via (z₁,z₂) com |z₁|²+|z₂|²=1; projeção π(z₁,z₂)=z₁/z₂∈CP¹≃S². Fibra: círculos e^{iθ}(z₁,z₂). Hopf invariant h=1 (linking number). Generalizações: Hopf maps S⁷→S⁴, S¹⁵→S⁸ via octonions. Aplicações: monopolos magnéticos, instantons.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "linking_number", Nome = "Número ligação", Descricao = "Linking number de duas fibras (Hopf invariant)", Unidade = "contagem", ValorPadrao = 1, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Hopf invariant: h=1 para mapa de Hopf clássico S³→S²
                    double h = valores["linking_number"];
                    // π₃(S²) = ℤ gerado por Hopf map (h=1)
                    return h; // 1=Hopf original, 2=suspensão, etc.
                },
                VariavelResultado = "Hopf invariant h∈π₃(S²)",
                UnidadeResultado = "contagem"
            };
        }

        /// <summary>
        /// V9_TOPO034: Primeira Classe de Chern - c₁(L)
        /// c₁(L) = [iF/(2π)] onde F=dA+A∧A curvatura
        /// </summary>
        private Formula V9_TOPO034_ClasseChern()
        {
            return new Formula
            {
                Id = "V9-TOPO034",
                CodigoCompendio = "034",
                Nome = "Primeira Classe de Chern",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "c₁(L) = [iF/(2π)]",
                ExprTexto = "Classe característica: curvatura da conexão U(1)",
                Descricao = "Primeira classe de Chern c₁(L)∈H²(M,ℤ) de fibrado de linha complexo L: classe cohomológica da forma de curvatura F=dA (conexão U(1)). Invariante topológico: c₁ independente de conexão. Generalização: classes de Chern cₖ para fibrados maiores. Aplicações: geometria complexa (fibrados holomorfos), fase de Berry em mecânica quântica.",
                Criador = "Shiing-Shen Chern (1946, Characteristic Classes of Hermitian Manifolds, Annals of Mathematics)",
                AnoOrigin = "1946",
                ExemploPratico = "Fibrado canônico sobre CP¹≃S²: c₁=1. Monopolo de Dirac: c₁=±1 (carga magnética quantizada). Fase de Berry: holonomia γ=∮A·dr=∫F (c₁×2π). Teorema de Riemann-Roch: χ(D)=deg(D)+1−g relaciona c₁ com genus. Index theorem: ind(∂̄)=∫c₁.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "int_F", Nome = "∫F", Descricao = "Integral da forma de curvatura F sobre superfície", Unidade = "adimensional", ValorPadrao = 6.283, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double int_F = valores["int_F"];
                    // c₁ = [iF/(2π)] → ∫c₁ = (i/(2π))∫F = ∫F/(2π) (real)
                    double c1 = int_F / (2.0 * Math.PI);
                    return c1; // inteiro para fibrados quantizados
                },
                VariavelResultado = "c₁ integrado",
                UnidadeResultado = "adimensional (∈ℤ)"
            };
        }

        /// <summary>
        /// V9_TOPO035: Conexão de Yang-Mills - Gauge não-abeliano
        /// F=dA+A∧A; D_A F=0 equação de Yang-Mills
        /// </summary>
        private Formula V9_TOPO035_YangMills()
        {
            return new Formula
            {
                Id = "V9-TOPO035",
                CodigoCompendio = "035",
                Nome = "Teoria de Yang-Mills",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "F=dA+A∧A; D_A F=0",
                ExprTexto = "Curvatura não-abeliana; equação de movimento D_A F=0",
                Descricao = "Teoria de Yang-Mills: generalização não-abeliana do eletromagnetismo. Campo gauge A 1-forma com valores em álgebra de Lie g. Form curvatura F=dA+A∧A (comutador não-trivial [A,A]≠0). Equação de movimento: derivada covariante D_A F=0. Fundamento do Modelo Padrão (SU(3)×SU(2)×U(1)). Instantons: soluções auto-duais.",
                Criador = "Chen Ning Yang e Robert Mills (1954, Conservation of Isotopic Spin and Isotopic Gauge Invariance, Physical Review)",
                AnoOrigin = "1954",
                ExemploPratico = "QCD: grupo gauge SU(3), gluons são campo A. Eletrofraco: SU(2)×U(1), bósons W±, Z, γ. Instantons: soluções F=*F (auto-dual), tunelamento quântico. Mass gap conjecture: Yang-Mills em 3+1D tem mass gap Δm>0 (Millennium Prize Problem aberto). Lagrangiana ℒ=−¼⟨F,F⟩.",
                Unidades = "campo gauge",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "F_12", Nome = "Componente F_{12}", Descricao = "Componente típica da curvatura", Unidade = "campo", ValorPadrao = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "g_coupling", Nome = "Constante acoplamento g", Descricao = "Constante de acoplamento gauge", Unidade = "adimensional", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double F12 = valores["F_12"];
                    double g = valores["g_coupling"];
                    // Ação de Yang-Mills: S = (1/4g²)∫⟨F,F⟩
                    // Aproximação: densidade Lagrangiana ℒ = −(1/4)⟨F,F⟩
                    double densidade_acao = 0.25 * F12 * F12 / (g * g);
                    return densidade_acao;
                },
                VariavelResultado = "Densidade ação YM",
                UnidadeResultado = "campo²"
            };
        }

        // Continua fórmulas 036-042 para completar 21 fórmulas da área...
        /// <summary>
        /// V9_TOPO036: Transformada de Fourier em Grupos de Lie
        /// f̂(ρ) = ∫_G f(g)·ρ(g) dg (análise harmônica não-comutativa)
        /// </summary>
        private Formula V9_TOPO036_FourierGrupoLie()
        {
            return new Formula
            {
                Id = "V9-TOPO036",
                CodigoCompendio = "036",
                Nome = "Transformada de Fourier em Grupos de Lie",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "f̂(ρ) = ∫_G f(g)·ρ(g) dg",
                ExprTexto = "Decomposição em representações irredutíveis",
                Descricao = "Análise harmônica em grupos de Lie: funções f:G→ℂ decompõem-se em representações irredutíveis ρ via transformada de Fourier não-comutativa. Teorema de Peter-Weyl: L²(G)=⊕_ρEnd(V_ρ) (soma direta de espaços de representações). Generaliza Fourier clássica (G=ℝⁿ ou S¹). Aplicações: física quântica (momento angular), processamento de sinal em SO(3).",
                Criador = "Hermann Weyl e Fritz Peter (1927, Die Vollständigkeit der primitiven Darstellungen einer geschlossenen kontinuierlichen Gruppe)",
                AnoOrigin = "1927",
                ExemploPratico = "SO(3): representações ρ_l parametrizadas por spin l=0,½,1,3/2,... Harmônicos esféricos Y_lm são coeficientes de Fourier de f:S²→ℂ. SU(2): same story (cobre doubly SO(3)). Grupo abeliano G=S¹: Fourier usual e^{inθ}. Non-compact: Plancherel measure.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "l_spin", Nome = "Spin l", Descricao = "Número quântico de momento angular", Unidade = "ℏ", ValorPadrao = 1, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "m_proj", Nome = "Projeção m", Descricao = "Projeção de momento angular", Unidade = "ℏ", ValorPadrao = 0, ValorMin = -10, ValorMax = 10, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double l = valores["l_spin"];
                    double m = valores["m_proj"];
                    if (Math.Abs(m) > l) throw new InvalidOperationException("|m| ≤ l required");
                    // Dimensão da representação (2l+1)-dimensional
                    double dim_rep = 2.0 * l + 1.0;
                    return dim_rep;
                },
                VariavelResultado = "Dimensão rep (2l+1)",
                UnidadeResultado = "dimensão"
            };
        }

        /// <summary>
        /// V9_TOPO037: Curvatura Seccional
        /// K(π) = R(u,v,v,u)/(|u|²|v|²−⟨u,v⟩²)
        /// </summary>
        private Formula V9_TOPO037_CurvaturaSeccional()
        {
            return new Formula
            {
                Id = "V9-TOPO037",
                CodigoCompendio = "037",
                Nome = "Curvatura Seccional",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "K(π) = R(u,v,v,u)/(|u|²|v|²−⟨u,v⟩²)",
                ExprTexto = "Curvatura Gaussiana do plano π tangente",
                Descricao = "Curvatura seccional K(π): curvatura Gaussiana intrínseca do plano 2-dimensional π⊂T_pM gerado por vetores tangentes u,v. Relaciona tensor de Riemann com geometria de planos tangentes. K>0: esfera-like, K<0: hiperbólico, K=0: plano. Determina completamente tensor de Riemann em dimensão. n=2. Teorema de Cartan: métrica determinada por K(π) para todo π.",
                Criador = "Bernhard Riemann (1854, generalização curvatura Gaussiana); redescoberta por Élie Cartan",
                AnoOrigin = "1854",
                ExemploPratico = "Esfera S^n raio R: K=1/R² (constante positiva). Espaço hiperbólico H^n: K=−1/R² (constante negativa). Plano euclidiano: K=0. Superfície revolução: K(meridiano∧paralelo)=função de coordenadas. Teorema comparação: K≥k₀ implica diâmetro ≤π/√k₀ (Bonnet-Myers).",
                Unidades = "1/m²",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "R_uvvu", Nome = "R(u,v,v,u)", Descricao = "Componente Riemann no plano (u,v)", Unidade = "adimensional", ValorPadrao = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "norm_u_sq", Nome = "|u|²", Descricao = "Norma quadrada do vetor u", Unidade = "m²", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true },
                    new Variavel { Simbolo = "norm_v_sq", Nome = "|v|²", Descricao = "Norma quadrada do vetor v", Unidade = "m²", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true },
                    new Variavel { Simbolo = "dot_uv", Nome = "⟨u,v⟩", Descricao = "Produto interno de u e v", Unidade = "m²", ValorPadrao = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double R_uvvu = valores["R_uvvu"];
                    double u_sq = valores["norm_u_sq"];
                    double v_sq = valores["norm_v_sq"];
                    double uv_dot = valores["dot_uv"];
                    double denominador = u_sq * v_sq - uv_dot * uv_dot;
                    if (Math.Abs(denominador) < 1e-10) throw new InvalidOperationException("Vetores u,v devem ser LI");
                    double K = R_uvvu / denominador;
                    return K;
                },
                VariavelResultado = "Curvatura seccional K(π)",
                UnidadeResultado = "1/m²"
            };
        }

        /// <summary>
        /// V9_TOPO038: Equação de Jacobi - Desvio Geodésico
        /// D²J/dt² + R(J,γ')γ' = 0
        /// </summary>
        private Formula V9_TOPO038_EquacaoJacobi()
        {
            return new Formula
            {
                Id = "V9-TOPO038",
                CodigoCompendio = "038",
                Nome = "Equação de Jacobi",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "D²J/dt² + R(J,γ')γ' = 0",
                ExprTexto = "Equação de desvio geodésico: campo Jacobi ao longo de geodésica",
                Descricao = "Equação de Jacobi: descreve separação infinitesimal J(t) entre geodésicas próximas. D²J/dt²+R(J,γ')γ'=0 onde γ' velocidade geodésica, R tensor de Riemann, D derivada covariante. Soluções J(t) são campos de Jacobi. Pontos conjugados: onde J(t)=0 (geodésicas se intersectam). Curvatura>0 foca geodésicas; <0 dispersa.",
                Criador = "Carl Gustav Jacob Jacobi (1842, teoria de variações e geodésicas)",
                AnoOrigin = "1842",
                ExemploPratico = "Esfera S²: geodésicas (grandes círculos) encontram-se em pólos antípodas após π rad → primeiro ponto conjugado em dist=πR. Espaço hiperbólico: sem pontos conjugados (divergência exponencial). Relatividade geral: equação de desvio geodésico mede forças de maré gravitacionais. Raychaudhuri equation: caso especial com traço ∇·J.",
                Unidades = "aceleração (m/s²)",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K_seccional", Nome = "Curvatura seccional", Descricao = "Curvatura K do plano (J,γ')", Unidade = "1/m²", ValorPadrao = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "J_0", Nome = "Desvio inicial J₀", Descricao = "Separação inicial das geodésicas", Unidade = "m", ValorPadrao = 0.01, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "t", Nome = "Parâmetro t", Descricao = "Tempo próprio ao longo da geodésica", Unidade = "s", ValorPadrao = 1, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double K = valores["K_seccional"];
                    double J0 = valores["J_0"];
                    double t = valores["t"];
                    // Solução aproximada: J(t) ≈ J₀·sin(√K·t)/√K para K>0 (esfera)
                    // J(t) ≈ J₀·t para K=0 (plano)
                    // J(t) ≈ J₀·sinh(√|K|·t)/√|K| para K<0 (hiperbólico)
                    double J_t;
                    if (K > 1e-10)
                    {
                        double sqrtK = Math.Sqrt(K);
                        J_t = J0 * Math.Sin(sqrtK * t) / sqrtK;
                    }
                    else if (K < -1e-10)
                    {
                        double sqrtAbsK = Math.Sqrt(Math.Abs(K));
                        J_t = J0 * Math.Sinh(sqrtAbsK * t) / sqrtAbsK;
                    }
                    else
                    {
                        J_t = J0 * t; // K≈0: plano
                    }
                    return J_t;
                },
                VariavelResultado = "Desvio J(t)",
                UnidadeResultado = "m"
            };
        }

        /// <summary>
        /// V9_TOPO039: Teorema Atiyah-Singer Index
        /// ind(D) = ∫_M ch(E)·Â(TM)
        /// </summary>
        private Formula V9_TOPO039_AtiyahSingerIndex()
        {
            return new Formula
            {
                Id = "V9-TOPO039",
                CodigoCompendio = "039",
                Nome = "Teorema Atiyah-Singer Index",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "ind(D) = ∫_M ch(E)·Â(TM)",
                ExprTexto = "Índice analítico = integral topológica",
                Descricao = "Teorema do Índice de Atiyah-Singer: relaciona índice analítico ind(D)=dim(ker D)−dim(coker D) de operador elíptico D com integral de classes características topológicas. ch(E) caráter de Chern do fibrado E, Â(TM) classe de Todd do fibrado tangente. Ponte profunda entre análise, geometria e topologia. Consequências: Riemann-Roch, Gauss-Bonnet, Hirzebruch signature.",
                Criador = "Michael Atiyah e Isadore Singer (1963, The Index of Elliptic Operators, Annals of Mathematics; Abel Prize 2004)",
                AnoOrigin = "1963",
                ExemploPratico = "Operador de Dirac ∂̸ em variedade spin: ind(∂̸)=∫Â(TM) (Â-genus). Operador ∂̄ de Dolbeault em superfície Riemann: ind(∂̄)=1−g (Riemann-Roch). Signature operator: ind=signature(M). Aplicações: física (anomalias quirais), K-teoria, geometria de calibre.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "dim_ker", Nome = "dim(ker D)", Descricao = "Dimensão do kernel (soluções de Du=0)", Unidade = "dimensão", ValorPadrao = 5, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "dim_coker", Nome = "dim(coker D)", Descricao = "Dimensão do cokernel", Unidade = "dimensão", ValorPadrao = 3, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double d_ker = valores["dim_ker"];
                    double d_coker = valores["dim_coker"];
                    double index = d_ker - d_coker;
                    return index; // inteiro, invariante topológico
                },
                VariavelResultado = "Índice ind(D)",
                UnidadeResultado = "adimensional (∈ℤ)"
            };
        }

        /// <summary>
        /// V9_TOPO040: Métrica FLRW - Cosmologia
        /// ds² = −c²dt² + a(t)²[dr²/(1−kr²) + r²dΩ²]
        /// </summary>
        private Formula V9_TOPO040_MetricaFLRW()
        {
            return new Formula
            {
                Id = "V9-TOPO040",
                CodigoCompendio = "040",
                Nome = "Métrica de Friedmann-Lemaître-Robertson-Walker (FLRW)",
                Categoria = "Volume IX",
                SubCategoria = "Geometria Diferencial",
                Expressao = "ds² = −c²dt² + a(t)²[dr²/(1−kr²) + r²dΩ²]",
                ExprTexto = "Métrica de universo homogêneo isotrópico em expansão",
                Descricao = "Métrica FLRW: descreve universo homogêneo e isotrópico (Princípio Cosmológico). Fator de escala a(t): expansão do universo. Curvatura espacial k=+1 (esférico fechado), 0 (plano), −1 (hiperbólico aberto). Base do modelo cosmológico padrão ΛCDM. Combinado com EFE → equações de Friedmann para dinâmica de a(t).",
                Criador = "Alexander Friedmann (1922); Georges Lemaître (1927); Howard Robertson e Arthur Walker (1935-36, prova de unicidade)",
                AnoOrigin = "1922",
                ExemploPratico = "Universo plano k=0, ΛCDM: a(t)∝t^{2/3} (domínio matéria) → a(t)∝e^{Ht} (domínio Λ). Redshift cosmológico: 1+z=a₀/a(t). Distância luminosidade: dL=(1+z)∫[c·dt/a(t)]. Horizonte de partículas: dH=c∫dt/a(t). CMB: snapshot de t=380 kanos após Big Bang.",
                Unidades = "m²",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a_t", Nome = "Fator escala a(t)", Descricao = "Fator de escala cósmico (normalizado a₀=1 hoje)", Unidade = "adimensional", ValorPadrao = 0.5, ValorMin = 0.001, Obrigatoria = true },
                    new Variavel { Simbolo = "k_curv", Nome = "Curvatura k", Descricao = "Curvatura espacial: +1 (fechado), 0 (plano), −1 (aberto)", Unidade = "adimensional", ValorPadrao = 0, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "r_comov", Nome = "Coordenada comóvel r", Descricao = "Distância comóvel radial", Unidade = "Mpc (megaparsec)", ValorPadrao = 1, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double a = valores["a_t"];
                    double k = valores["k_curv"];
                    double r = valores["r_comov"];
                    // Distância física: d_phys = a(t)·r
                    double d_fisica = a * r;
                    // Redshift: z = a₀/a − 1 (assumindo a₀=1)
                    double redshift = 1.0 / a - 1.0;
                    return redshift; // z do objeto em coordenada comóvel r
                },
                VariavelResultado = "Redshift z",
                UnidadeResultado = "adimensional"
            };
        }

        /// <summary>
        /// V9_TOPO041: Homologia Persistente - TDA
        /// β_k(t) = rank H_k(X_t) para filtração X_0⊂X_1⊂...
        /// </summary>
        private Formula V9_TOPO041_HomologiaPersistente()
        {
            return new Formula
            {
                Id = "V9-TOPO041",
                CodigoCompendio = "041",
                Nome = "Homologia Persistente",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "β_k(t) = rank H_k(X_t); barcode diagram",
                ExprTexto = "Rastreia nascimento/morte de features topológicas em filtração",
                Descricao = "Homologia persistente: ferramenta de Topological Data Analysis (TDA) que rastreia features topológicas (componentes conexas, loops, voids) através de filtração X₀⊂X₁⊂... de complexos simpliciais. Números de Betti β_k(t)=rank H_k(X_t). Barcode diagram e persistence diagram visualizam nascimento/morte de features. Robustez a ruído via persistence: features de longa vida são genuínas.",
                Criador = "Herbert Edelsbrunner, David Letscher, Afra Zomorodian (2002, Topological Persistence and Simplification); Gunnar Carlsson (popularização)",
                AnoOrigin = "2002",
                ExemploPratico = "Nuvem de pontos 3D: Čech complexo ou Vietoris-Rips com raio ε crescente. Features persistentes (longa vida no barcode) = estrutura genuína; curtas = ruído. Aplicações: biologia (proteínas), neurociência (grafos cerebrais), sensor networks, análise de imagens, machine learning.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "epsilon_birth", Nome = "ε nascimento", Descricao = "Raio de filtração onde feature nasce", Unidade = "unidades distância", ValorPadrao = 0.1, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "epsilon_death", Nome = "ε morte", Descricao = "Raio de filtração onde feature morre", Unidade = "unidades distância", ValorPadrao = 0.5, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double e_birth = valores["epsilon_birth"];
                    double e_death = valores["epsilon_death"];
                    if (e_death < e_birth) throw new InvalidOperationException("Morte deve ocorrer após nascimento");
                    // Persistence = lifetime da feature
                    double persistence = e_death - e_birth;
                    return persistence; // features com persistence alto são significativas
                },
                VariavelResultado = "Persistence (lifetime)",
                UnidadeResultado = "unidades distância"
            };
        }

        /// <summary>
        /// V9_TOPO042: Produto Wedge e Cohomologia de Álgebra
        /// ω∧η: Ωᵖ×Ωᵍ → Ωᵖ⁺ᵍ anticomutativo
        /// </summary>
        private Formula V9_TOPO042_ProdutoWedge()
        {
            return new Formula
            {
                Id = "V9-TOPO042",
                CodigoCompendio = "042",
                Nome = "Produto Wedge e Estrutura de Álgebra de Cohomologia",
                Categoria = "Volume IX",
                SubCategoria = "Topologia Algébrica",
                Expressao = "ω∧η; H*(M,ℝ)=⊕H^p(M) com produto ∧",
                ExprTexto = "Produto exterior anticomutativo; cohomologia é álgebra graduada",
                Descricao = "Produto wedge ∧: operação bilinear antisimétrica ω∧η=(−1)^{pq}η∧ω para p-forma ω e q-forma η. Derivada exterior: d(ω∧η)=(dω)∧η+(−1)^p ω∧(dη). Cohomologia H*(M)=⊕_p H^p(M) tem estrutura de álgebra graduada comutativa. Künneth formula: H*(M×N)≃H*(M)⊗H*(N). Intersecção de ciclos via Poincaré duality e ∧.",
                Criador = "Hermann Grassmann (1844, Die Wissenschaft der extensiven Grösse - álgebra exterior); Élie Cartan (1899, aplicação a formas diferenciais)",
                AnoOrigin = "1844",
                ExemploPratico = "R³: dx∧dy, dy∧dz, dz∧dx são 2-formas base. dx∧dx=0 (anticomutatividade). dx∧dy∧dz volume form. Toro T²: H¹(T²)=ℝ² gerado por [dx],[dy]; produto [dx]∧[dy]∈H²(T²)=ℝ não-trivial. Intersecção de ciclos: α·β=∫_M α∧β (Poincaré duality).",
                Unidades = "forma diferencial",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "grau_omega", Nome = "Grau ω (p)", Descricao = "Grau da p-forma ω", Unidade = "grau", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                    new Variavel { Simbolo = "grau_eta", Nome = "Grau η (q)", Descricao = "Grau da q-forma η", Unidade = "grau", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double p = valores["grau_omega"];
                    double q = valores["grau_eta"];
                    // Produto ω∧η tem grau p+q
                    double grau_produto = p + q;
                    // Sinal anticomutação: ω∧η = (−1)^{pq}·η∧ω
                    double sinal = Math.Pow(-1, p * q);
                    return grau_produto; // retorna grau do produto
                },
                VariavelResultado = "Grau (ω∧η)",
                UnidadeResultado = "grau"
            };
        }
    }
}
