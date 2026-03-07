using CompendioCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompendioCalc.Services
{
    /// <summary>
    /// COMPÊNDIO GERAL DE EQUAÇÕES - VOLUME V - EDIÇÃO FINAL EXAUSTIVA
    /// Matemática · Física · Estatística · Computação · Ciências Sociais · Biologia · Novas Fronteiras
    /// Mais de 300 equações avançadas implementadas com estrutura correta
    /// </summary>
    public partial class FormulaService
    {
        #region PARTE I - MATEMÁTICA PURA

        #region 1. TEORIA DE LIE E REPRESENTAÇÕES

        // [LI1] Identidade de Jacobi
        public static Formula V5_LI1_Jacobi()
        {
            return new Formula
            {
                Id = "V5-LI1", CodigoCompendio = "166",
                Nome = "Identidade de Jacobi",
                Categoria = "Matemática Pura",
                SubCategoria = "Teoria de Lie",
                Expressao = "[[x,y],z] + [[y,z],x] + [[z,x],y] = 0",
                ExprTexto = "Identidade de Jacobi para comutadores",
                Descricao = "Verifica a identidade fundamental [[x,y],z]+[[y,z],x]+[[z,x],y]=0 para comutadores de Lie. Axioma que define álgebras de Lie.",
                Criador = "Sophus Lie",
                AnoOrigin = "1880",
                ExemploPratico = "Álgebra sl(2): matrizes 2×2 traço zero. Álgebra so(3): matrizes antissimétricas. Mecânica quântica: comutadores [x,p]=iℏ. Simetrias de Lie em física teórica.",
                Unidades = "",
                VariavelResultado = "jacobiana",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "a", Nome = "a", Descricao = "Primeira matriz/vetor da álgebra", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "b", Nome = "b", Descricao = "Segunda matriz/vetor da álgebra", Unidade = "", ValorPadrao = 2 },
                    new() { Simbolo = "c", Nome = "c", Descricao = "Terceira matriz/vetor da álgebra", Unidade = "", ValorPadrao = 3 }
                },
                Calcular = inputs =>
                {
                    double a = inputs["a"];
                    double b = inputs["b"];
                    double c = inputs["c"];
                    // Comutador simplificado [a,b] = a*b - b*a
                    double comm_ab = a * b - b * a;
                    double comm_bc = b * c - c * b;
                    double comm_ca = c * a - a * c;
                    // [[a,b],c] + [[b,c],a] + [[c,a],b]
                    double term1 = comm_ab * c - c * comm_ab;
                    double term2 = comm_bc * a - a * comm_bc;
                    double term3 = comm_ca * b - b * comm_ca;
                    return term1 + term2 + term3; // Deve ser ≈0
                }
            };
        }

        // [LI2] Forma de Killing
        public static Formula V5_LI2_Killing()
        {
            return new Formula
            {
                Id = "V5-LI2", CodigoCompendio = "167",
                Nome = "Forma de Killing",
                Categoria = "Matemática Pura",
                SubCategoria = "Teoria de Lie",
                Expressao = "B(x,y) = tr(ad_x ∘ ad_y)",
                ExprTexto = "Forma bilinear de Killing",
                Descricao = "Forma bilinear simétrica B(x,y)=tr(ad(x)·ad(y)) onde ad(x)(z)=[x,z]. Não-degenerações caracterizam álgebras semissimples (critério de Cartan).",
                Criador = "Wilhelm Killing",
                AnoOrigin = "1888",
                ExemploPratico = "sl(2): Killing não-degenerada → semisimples. Álgebra nilpotente: B≡0. Classificação de álgebras de Lie simples (An, Bn, Cn, Dn, E6, E7, E8, F4, G2).",
                Unidades = "",
                VariavelResultado = "killing_form",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "x11", Nome = "x₁₁", Descricao = "Elemento (1,1) da matriz x", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "x12", Nome = "x₁₂", Descricao = "Elemento (1,2) da matriz x", Unidade = "", ValorPadrao = 0 },
                    new() { Simbolo = "y11", Nome = "y₁₁", Descricao = "Elemento (1,1) da matriz y", Unidade = "", ValorPadrao = 0 },
                    new() { Simbolo = "y12", Nome = "y₁₂", Descricao = "Elemento (1,2) da matriz y", Unidade = "", ValorPadrao = 1 }
                },
                Calcular = inputs =>
                {
                    // Forma de Killing simplificada 2×2
                    double x11 = inputs["x11"];
                    double x12 = inputs["x12"];
                    double y11 = inputs["y11"];
                    double y12 = inputs["y12"];
                    // B(x,y) ≈ tr(ad_x · ad_y) para matrizes 2×2 traço zero
                    return 2 * (x11 * y11 + x12 * y12); // Simplificação
                }
            };
        }

        // [LI12] Fórmula de Weyl para Dimensão
        public static Formula V5_LI12_WeylDimension()
        {
            return new Formula
            {
                Id = "V5-LI12", CodigoCompendio = "168",
                Nome = "Fórmula de Weyl para Dimensão",
                Categoria = "Matemática Pura",
                SubCategoria = "Teoria de Lie",
                Expressao = "dim V(λ) = ∏_{α>0} (⟨λ+ρ,α⟩ / ⟨ρ,α⟩)",
                ExprTexto = "Dimensão de representação irredutível",
                Descricao = "dim V(λ) = Π_{α>0}(⟨λ+ρ,α⟩/⟨ρ,α⟩) onde ρ=½Σα>0. Calcula dimensão de representações irredutíveis de álgebras de Lie semissimples.",
                Criador = "Hermann Weyl",
                AnoOrigin = "1926",
                ExemploPratico = "su(2): peso λ → dimensão 2λ+1. su(3): representações fundamentais 3, 3̄, 8 (adjunta). sl(n): aplicações em teoria de quarks e modelo padrão.",
                Unidades = "",
                VariavelResultado = "dimensao",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "lambda", Nome = "λ", Descricao = "Peso dominante da representação", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "rank", Nome = "rank", Descricao = "Rank da álgebra de Lie", Unidade = "", ValorPadrao = 2 }
                },
                Calcular = inputs =>
                {
                    double lambda = inputs["lambda"];
                    double rank = inputs["rank"];
                    // Para su(2): dim = 2λ + 1
                    if (rank == 1) return 2 * lambda + 1;
                    // Aproximação geral
                    double rho = rank / 2.0;
                    double prod = 1;
                    for (int i = 1; i <= rank; i++)
                        prod *= (lambda + rho) / rho;
                    return Math.Round(prod);
                }
            };
        }

        // [TR3] Ortogonalidade de Caracteres
        public static Formula V5_TR3_CharacterOrthogonality()
        {
            return new Formula
            {
                Id = "V5-TR3", CodigoCompendio = "169",
                Nome = "Ortogonalidade de Caracteres",
                Categoria = "Matemática Pura",
                SubCategoria = "Teoria de Representações",
                Expressao = "⟨χ_ρ, χ_σ⟩ = (1/|G|) Σ_g χ_ρ(g)χ̄_σ(g) = δ_ρσ",
                ExprTexto = "Ortogonalidade de caracteres de grupo",
                Descricao = "Caracteres de representações irredutíveis inequivalentes são ortogonais. Produto interno ⟨χρ,χσ⟩=(1/|G|)Σg χρ(g)χσ*(g)=δρσ.",
                Criador = "Ferdinand Georg Frobenius",
                AnoOrigin = "1896",
                ExemploPratico = "Grupo simétrico S3: 3 representações irredutíveis (trivial, sinal, 2D). Decomposição de representações redutíveis. Tabelas de caracteres.",
                Unidades = "",
                VariavelResultado = "produto_interno",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "chi1_g1", Nome = "χ₁(g₁)", Descricao = "Caráter 1 no elemento g₁", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "chi1_g2", Nome = "χ₁(g₂)", Descricao = "Caráter 1 no elemento g₂", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "chi2_g1", Nome = "χ₂(g₁)", Descricao = "Caráter 2 no elemento g₁", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "chi2_g2", Nome = "χ₂(g₂)", Descricao = "Caráter 2 no elemento g₂", Unidade = "", ValorPadrao = -1 },
                    new() { Simbolo = "ordem", Nome = "|G|", Descricao = "Ordem do grupo", Unidade = "", ValorPadrao = 2 }
                },
                Calcular = inputs =>
                {
                    double chi1_g1 = inputs["chi1_g1"];
                    double chi1_g2 = inputs["chi1_g2"];
                    double chi2_g1 = inputs["chi2_g1"];
                    double chi2_g2 = inputs["chi2_g2"];
                    double ordem = inputs["ordem"];
                    // ⟨χ₁,χ₂⟩ = (1/|G|) Σ χ₁(g)χ̄₂(g)
                    double soma = chi1_g1 * chi2_g1 + chi1_g2 * chi2_g2;
                    return soma / ordem; // = 0 se inequivalentes, 1 se equivalentes
                }
            };
        }

        // [TR4] Relação de Completude
        public static Formula V5_TR4_CompletenessRelation()
        {
            return new Formula
            {
                Id = "V5-TR4", CodigoCompendio = "170",
                Nome = "Relação de Completude",
                Categoria = "Matemática Pura",
                SubCategoria = "Teoria de Representações",
                Expressao = "Σ_i (dim ρ_i)² = |G|",
                ExprTexto = "Completude de representações",
                Descricao = "Para grupos finitos, soma dos quadrados das dimensões das representações irredutíveis iguala a ordem do grupo: Σ(dim ρᵢ)²=|G|.",
                Criador = "Ferdinand Georg Frobenius",
                AnoOrigin = "1896",
                ExemploPratico = "S3: 1²+1²+2²=6. D4 (diedro): 1²+1²+1²+1²+2²=8. Verificação de tabelas de caracteres completas.",
                Unidades = "",
                VariavelResultado = "soma_quadrados",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "dim1", Nome = "dim(ρ₁)", Descricao = "Dimensão da 1ª representação", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "dim2", Nome = "dim(ρ₂)", Descricao = "Dimensão da 2ª representação", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "dim3", Nome = "dim(ρ₃)", Descricao = "Dimensão da 3ª representação", Unidade = "", ValorPadrao = 2 }
                },
                Calcular = inputs =>
                {
                    double dim1 = inputs["dim1"];
                    double dim2 = inputs["dim2"];
                    double dim3 = inputs["dim3"];
                    return dim1 * dim1 + dim2 * dim2 + dim3 * dim3;
                }
            };
        }

        #endregion

        #region 2. TEORIA ALGÉBRICA DOS NÚMEROS

        // [NA10] Reciprocidade Quadrática
        public static Formula V5_NA10_QuadraticReciprocity()
        {
            return new Formula
            {
                Id = "V5-NA10", CodigoCompendio = "171",
                Nome = "Lei da Reciprocidade Quadrática",
                Categoria = "Matemática Pura",
                SubCategoria = "Teoria Algébrica dos Números",
                Expressao = "(p/q)(q/p) = (-1)^((p-1)(q-1)/4)",
                ExprTexto = "Reciprocidade quadrática de Gauss",
                Descricao = "Para p,q primos ímpares distintos: (p/q)(q/p)=(-1)^((p-1)(q-1)/4). Relaciona símbolos de Legendre (a/p) que indicam se a é resíduo quadrático mod p.",
                Criador = "Carl Friedrich Gauss",
                AnoOrigin = "1796",
                ExemploPratico = "(3/7)(7/3)=(-1)^((3-1)(7-1)/4)=(-1)³=-1. Determina se x²≡a(mod p) tem solução. Aplicações em criptografia (RSA, curvas elípticas).",
                Unidades = "",
                VariavelResultado = "reciprocidade",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "p", Nome = "p", Descricao = "Primeiro primo ímpar", Unidade = "", ValorPadrao = 3 },
                    new() { Simbolo = "q", Nome = "q", Descricao = "Segundo primo ímpar", Unidade = "", ValorPadrao = 7 }
                },
                Calcular = inputs =>
                {
                    int p = (int)inputs["p"];
                    int q = (int)inputs["q"];
                    int exponent = ((p - 1) * (q - 1)) / 4;
                    return Math.Pow(-1, exponent);
                }
            };
        }

        // [NA11] Símbolo de Legendre
        public static Formula V5_NA11_LegendreSymbol()
        {
            return new Formula
            {
                Id = "V5-NA11", CodigoCompendio = "172",
                Nome = "Símbolo de Legendre",
                Categoria = "Matemática Pura",
                SubCategoria = "Teoria Algébrica dos Números",
                Expressao = "(a/p) = a^((p-1)/2) mod p",
                ExprTexto = "Símbolo de Legendre",
                Descricao = "Para p primo ímpar: (a/p)=a^((p-1)/2) mod p. Resultado: +1 se a é resíduo quadrático mod p, -1 se não é, 0 se p|a.",
                Criador = "Adrien-Marie Legendre",
                AnoOrigin = "1798",
                ExemploPratico = "(2/7)=2⁶mod7=64mod7=1 → 2 é resíduo quadrático mod 7 (de fato, 3²=9≡2 mod 7). (3/7)=3³mod7=27mod7=-1 → 3 não é QR mod 7.",
                Unidades = "",
                VariavelResultado = "legendre",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "a", Nome = "a", Descricao = "Número inteiro", Unidade = "", ValorPadrao = 2 },
                    new() { Simbolo = "p", Nome = "p", Descricao = "Primo ímpar", Unidade = "", ValorPadrao = 7 }
                },
                Calcular = inputs =>
                {
                    int a = (int)inputs["a"];
                    int p = (int)inputs["p"];
                    if (a % p == 0) return 0;
                    long result = ModPow(a, (p - 1) / 2, p);
                    return result == p - 1 ? -1 : result;
                }
            };
        }

        #endregion

        #endregion

        #region PARTE II - FÍSICA

        #region 5. MECÂNICA CELESTE

        // [MC5] Teorema KAM
        public static Formula V5_MC5_KAMTheorem()
        {
            return new Formula
            {
                Id = "V5-MC5", CodigoCompendio = "173",
                Nome = "Teorema KAM (Kolmogorov-Arnold-Moser)",
                Categoria = "Física",
                SubCategoria = "Mecânica Celeste",
                Expressao = "H = H₀(I) + εH₁(I,θ)",
                ExprTexto = "Persistência de toros invariantes",
                Descricao = "Sistemas quase-integráveis perturbados H=H₀(I)+εH₁(I,θ) preservam toros invariantes sob perturbações pequenas (ε), exceto onde frequências são ressonantes.",
                Criador = "Andrey Kolmogorov, Vladimir Arnold, Jürgen Moser",
                AnoOrigin = "1954-1963",
                ExemploPratico = "Estabilidade do sistema solar: órbitas planetárias persistem sob perturbações mútuas. Aceleradores de partículas: confinamento de feixes. Caos vs ordem em dinâmica.",
                Unidades = "Joule",
                VariavelResultado = "hamiltoniano_perturbado",
                UnidadeResultado = "J",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "H0", Nome = "H₀", Descricao = "Hamiltoniano não-perturbado", Unidade = "J", ValorPadrao = 100 },
                    new() { Simbolo = "epsilon", Nome = "ε", Descricao = "Parâmetro de perturbação (pequeno)", Unidade = "", ValorPadrao = 0.01 },
                    new() { Simbolo = "H1", Nome = "H₁", Descricao = "Perturbação hamiltoniana", Unidade = "J", ValorPadrao = 10 }
                },
                Calcular = inputs =>
                {
                    double H0 = inputs["H0"];
                    double epsilon = inputs["epsilon"];
                    double H1 = inputs["H1"];
                    return H0 + epsilon * H1;
                }
            };
        }

        // [MC9] Equação da Órbita de Kepler
        public static Formula V5_MC9_KeplerOrbit()
        {
            return new Formula
            {
                Id = "V5-MC9", CodigoCompendio = "174",
                Nome = "Equação da Órbita de Kepler",
                Categoria = "Física",
                SubCategoria = "Mecânica Celeste",
                Expressao = "r = a(1-e²) / (1 + e·cos(θ))",
                ExprTexto = "Raio orbital em função do ângulo",
                Descricao = "Descreve órbitas elípticas em termos do semi-eixo maior a, excentricidade e, e anomalia verdadeira θ. Solução do problema de Kepler para força 1/r².",
                Criador = "Johannes Kepler",
                AnoOrigin = "1609",
                ExemploPratico = "Terra: a=1UA, e≈0.017 → órbita quase circular. Halley: e=0.967 → órbita muito elíptica. Satélites geoestacionários: órbitas circulares (e=0).",
                Unidades = "m",
                VariavelResultado = "raio",
                UnidadeResultado = "m",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "a", Nome = "a", Descricao = "Semi-eixo maior", Unidade = "m", ValorPadrao = 1.496e11 },
                    new() { Simbolo = "e", Nome = "e", Descricao = "Excentricidade", Unidade = "", ValorPadrao = 0.0167, ValorMin = 0, ValorMax = 1 },
                    new() { Simbolo = "theta", Nome = "θ", Descricao = "Anomalia verdadeira", Unidade = "rad", ValorPadrao = 0 }
                },
                Calcular = inputs =>
                {
                    double a = inputs["a"];
                    double e = inputs["e"];
                    double theta = inputs["theta"];
                    return a * (1 - e * e) / (1 + e * Math.Cos(theta));
                }
            };
        }

        // [MC10] Velocidade de Escape
        public static Formula V5_MC10_EscapeVelocity()
        {
            return new Formula
            {
                Id = "V5-MC10", CodigoCompendio = "175",
                Nome = "Velocidade de Escape",
                Categoria = "Física",
                SubCategoria = "Mecânica Celeste",
                Expressao = "v_esc = √(2GM/R)",
                ExprTexto = "Velocidade de escape gravitacional",
                Descricao = "Velocidade mínima para um objeto escapar da gravidade de um corpo celeste sem propulsão adicional.",
                Criador = "Isaac Newton",
                AnoOrigin = "1687",
                ExemploPratico = "Terra: v_esc≈11.2 km/s. Lua: 2.4 km/s. Sol (na superfície): 618 km/s. Usada para projetar missões espaciais interplanetárias.",
                Unidades = "m/s",
                VariavelResultado = "v_escape",
                UnidadeResultado = "m/s",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "G", Nome = "G", Descricao = "Constante gravitacional", Unidade = "m³/(kg·s²)", ValorPadrao = 6.674e-11 },
                    new() { Simbolo = "M", Nome = "M", Descricao = "Massa do corpo celeste", Unidade = "kg", ValorPadrao = 5.972e24 },
                    new() { Simbolo = "R", Nome = "R", Descricao = "Raio do corpo celeste", Unidade = "m", ValorPadrao = 6.371e6 }
                },
                Calcular = inputs =>
                {
                    double G = inputs["G"];
                    double M = inputs["M"];
                    double R = inputs["R"];
                    return Math.Sqrt(2 * G * M / R);
                }
            };
        }

        #endregion

        #region 6. FÍSICA DE MATÉRIA CONDENSADA - MAGNETISMO

        // [MG3] Suscetibilidade de Curie-Weiss
        public static Formula V5_MG3_CurieWeissSusceptibility()
        {
            return new Formula
            {
                Id = "V5-MG3", CodigoCompendio = "176",
                Nome = "Suscetibilidade de Curie-Weiss",
                Categoria = "Física",
                SubCategoria = "Magnetismo",
                Expressao = "χ = C / (T - T_c)",
                ExprTexto = "Suscetibilidade magnética perto de T_c",
                Descricao = "Suscetibilidade magnética χ diverge perto da temperatura crítica Tc. C é constante de Curie. Descreve transição ferro-paramagnética.",
                Criador = "Pierre Curie e Pierre-Ernest Weiss",
                AnoOrigin = "1907",
                ExemploPratico = "Ferro: Tc=1043K. Níquel: 627K. Cobalto: 1388K. Usado para determinar temperaturas de Curie experimentalmente. Materiais magnéticos moles.",
                Unidades = "m³/kg",
                VariavelResultado = "susceptibilidade",
                UnidadeResultado = "m³/kg",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "C", Nome = "C", Descricao = "Constante de Curie", Unidade = "K·m³/kg", ValorPadrao = 1 },
                    new() { Simbolo = "T", Nome = "T", Descricao = "Temperatura", Unidade = "K", ValorPadrao = 300 },
                    new() { Simbolo = "Tc", Nome = "T_c", Descricao = "Temperatura crítica (Curie)", Unidade = "K", ValorPadrao = 293 }
                },
                Calcular = inputs =>
                {
                    double C = inputs["C"];
                    double T = inputs["T"];
                    double Tc = inputs["Tc"];
                    if (Math.Abs(T - Tc) < 0.01) return double.PositiveInfinity;
                    return C / (T - Tc);
                }
            };
        }

        #endregion

        #endregion

        #region PARTE III - ESTATÍSTICA E DADOS

        #region 8. PROCESSOS GAUSSIANOS E MODELOS NÃO-PARAMÉTRICOS

        // [GP3] Predição Posterior de GP
        public static Formula V5_GP3_GPPosterior()
        {
            return new Formula
            {
                Id = "V5-GP3", CodigoCompendio = "177",
                Nome = "Predição Posterior de Processo Gaussiano",
                Categoria = "Estatística e Dados",
                SubCategoria = "Processos Gaussianos",
                Expressao = "μ* = K*ᵀ(K+σ²I)⁻¹y",
                ExprTexto = "Média posterior GP",
                Descricao = "Predição da média posterior μ* em novos pontos dado dados observados y. K é matriz de covariância, K* covariância entre treino e teste, σ² ruído.",
                Criador = "Carl Edward Rasmussen e Christopher K. I. Williams",
                AnoOrigin = "2006",
                ExemploPratico = "Modelagem de superfícies de resposta em otimização bayesiana. Previsão de séries temporais financeiras. Modelagem de terreno em robótica. Calibração de simuladores.",
                Unidades = "",
                VariavelResultado = "media_posterior",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "k_star", Nome = "K*", Descricao = "Covariância treino-teste", Unidade = "", ValorPadrao = 0.8 },
                    new() { Simbolo = "k_train", Nome = "K", Descricao = "Covariância treino-treino", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "sigma2", Nome = "σ²", Descricao = "Variância do ruído", Unidade = "", ValorPadrao = 0.1 },
                    new() { Simbolo = "y", Nome = "y", Descricao = "Observação de treino", Unidade = "", ValorPadrao = 1.5 }
                },
                Calcular = inputs =>
                {
                    double k_star = inputs["k_star"];
                    double k_train = inputs["k_train"];
                    double sigma2 = inputs["sigma2"];
                    double y = inputs["y"];
                    // Simplificação 1D: μ* = k*/(k+σ²) · y
                    return k_star / (k_train + sigma2) * y;
                }
            };
        }

        // [GP6] Kernel RBF (Radial Basis Function)
        public static Formula V5_GP6_RBFKernel()
        {
            return new Formula
            {
                Id = "V5-GP6", CodigoCompendio = "178",
                Nome = "Kernel RBF (Gaussiano)",
                Categoria = "Estatística e Dados",
                SubCategoria = "Processos Gaussianos",
                Expressao = "k(x,x') = σ²·exp(-‖x-x'‖²/(2ℓ²))",
                ExprTexto = "Kernel de base radial",
                Descricao = "Kernel RBF/Gaussiano: k(x,x')=σ²exp(-‖x-x'‖²/(2ℓ²)). σ² é variância de sinal, ℓ é comprimento de escala. Kernel infinitamente diferenciável.",
                Criador = "Mercer (base), uso moderno em GP",
                AnoOrigin = "~1990",
                ExemploPratico = "Regressão GP: funções suaves. SVM: kernel padrão. ℓ grande → funções variam devagar. ℓ pequeno → funções variam rapidamente.",
                Unidades = "",
                VariavelResultado = "kernel",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "x1", Nome = "x₁", Descricao = "Primeira coordenada", Unidade = "", ValorPadrao = 0 },
                    new() { Simbolo = "x2", Nome = "x₂", Descricao = "Segunda coordenada", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "sigma2", Nome = "σ²", Descricao = "Variância de sinal", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "length_scale", Nome = "ℓ", Descricao = "Comprimento de escala", Unidade = "", ValorPadrao = 1 }
                },
                Calcular = inputs =>
                {
                    double x1 = inputs["x1"];
                    double x2 = inputs["x2"];
                    double sigma2 = inputs["sigma2"];
                    double length_scale = inputs["length_scale"];
                    double dist_sq = (x1 - x2) * (x1 - x2);
                    return sigma2 * Math.Exp(-dist_sq / (2 * length_scale * length_scale));
                }
            };
        }

        #endregion

        #region 11. OTIMIZAÇÃO CONVEXA E NÃO-CONVEXA

        // [OC13] Aceleração de Nesterov
        public static Formula V5_OC13_NesterovAcceleration()
        {
            return new Formula
            {
                Id = "V5-OC13", CodigoCompendio = "179",
                Nome = "Aceleração de Nesterov (Momentum)",
                Categoria = "Estatística e Dados",
                SubCategoria = "Otimização",
                Expressao = "x_{k+1} = y_k - α∇f(y_k), y_{k+1} = x_{k+1} + β(x_{k+1}-x_k)",
                ExprTexto = "Método do Gradiente Acelerado",
                Descricao = "Método de Nesterov com momentum: y_k é ponto 'lookahead', β é coeficiente de momentum. Convergência O(1/k²) vs O(1/k) do gradiente descendente.",
                Criador = "Yurii Nesterov",
                AnoOrigin = "1983",
                ExemploPratico = "Treinamento de redes neurais: acelera convergência em vales estreitos. Otimização em aprendizado profundo. Adam optimizer usa variante.",
                Unidades = "",
                VariavelResultado = "x_next",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "x_k", Nome = "x_k", Descricao = "Iteração atual", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "grad_f", Nome = "∇f", Descricao = "Gradiente da função", Unidade = "", ValorPadrao = 0.5 },
                    new() { Simbolo = "alpha", Nome = "α", Descricao = "Taxa de aprendizado", Unidade = "", ValorPadrao = 0.01 },
                    new() { Simbolo = "beta", Nome = "β", Descricao = "Coeficiente momentum", Unidade = "", ValorPadrao = 0.9 },
                    new() { Simbolo = "x_prev", Nome = "x_{k-1}", Descricao = "Iteração anterior", Unidade = "", ValorPadrao = 0.95 }
                },
                Calcular = inputs =>
                {
                    double x_k = inputs["x_k"];
                    double grad_f = inputs["grad_f"];
                    double alpha = inputs["alpha"];
                    double beta = inputs["beta"];
                    double x_prev = inputs["x_prev"];
                    // y_k = x_k + β(x_k - x_{k-1})
                    double y_k = x_k + beta * (x_k - x_prev);
                    // x_{k+1} = y_k - α·∇f(y_k)
                    return y_k - alpha * grad_f;
                }
            };
        }

        #endregion

        #endregion

        #region PARTE IV - CIÊNCIAS DA COMPUTAÇÃO

        #region 13. ALGORITMOS DE APROXIMAÇÃO

        // [AP2] Aproximação de Set Cover
        public static Formula V5_AP2_SetCoverApproximation()
        {
            return new Formula
            {
                Id = "V5-AP2", CodigoCompendio = "180",
                Nome = "Aproximação de Set Cover",
                Categoria = "Ciências da Computação",
                SubCategoria = "Algoritmos de Aproximação",
                Expressao = "custo ≤ H_n·OPT onde H_n = Σ_{i=1}^n 1/i ≈ ln(n)",
                ExprTexto = "Algoritmo guloso para Set Cover",
                Descricao = "Algoritmo guloso para Set Cover garante aproximação H_n (n-ésimo número harmônico ≈ln n) do ótimo. NP-difícil encontrar solução ótima.",
                Criador = "David S. Johnson, Lovász",
                AnoOrigin = "1974",
                ExemploPratico = "Cobertura de vértices por arestas. Seleção de sensores para cobertura de área. Problemas de roteamento. Seleção de features em ML.",
                Unidades = "",
                VariavelResultado = "razao_aproximacao",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "n", Nome = "n", Descricao = "Tamanho do universo", Unidade = "", ValorPadrao = 100 }
                },
                Calcular = inputs =>
                {
                    int n = (int)inputs["n"];
                    // H_n = Σ 1/i ≈ ln(n) + γ (constante de Euler)
                    double harmonic = 0;
                    for (int i = 1; i <= n; i++)
                        harmonic += 1.0 / i;
                    return harmonic; // Razão de aproximação
                }
            };
        }

        // [PA2] Lei de Amdahl
        public static Formula V5_PA2_AmdahlsLaw()
        {
            return new Formula
            {
                Id = "V5-PA2", CodigoCompendio = "181",
                Nome = "Lei de Amdahl",
                Categoria = "Ciências da Computação",
                SubCategoria = "Computação Paralela",
                Expressao = "Speedup = 1 / ((1-p) + p/N)",
                ExprTexto = "Speedup máximo em paralelização",
                Descricao = "Speedup máximo de um programa ao paralelizar parte p com N processadores. (1-p) é fração sequencial. Limita ganhos de paralelização.",
                Criador = "Gene Amdahl",
                AnoOrigin = "1967",
                ExemploPratico = "p=90%, N=10: speedup≈5.3 (não linear). p=50%, N=infinito: speedup≤2. Projeta arquiteturas paralelas. GPUs: alto speedup em workloads paralelos.",
                Unidades = "",
                VariavelResultado = "speedup",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "p", Nome = "p", Descricao = "Fração paralelizável (0-1)", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1 },
                    new() { Simbolo = "N", Nome = "N", Descricao = "Número de processadores", Unidade = "", ValorPadrao = 10, ValorMin = 1 }
                },
                Calcular = inputs =>
                {
                    double p = inputs["p"];
                    double N = inputs["N"];
                    return 1.0 / ((1 - p) + p / N);
                }
            };
        }

        #endregion

        #endregion

        #region PARTE V - CIÊNCIAS SOCIAIS E ECONÔMICAS

        #region 17. MODELOS MACROECONÔMICOS DSGE (NOVO-KEYNESIANOS)

        // [NK1] Curva IS Dinâmica
        public static Formula V5_NK1_DynamicIS()
        {
            return new Formula
            {
                Id = "V5-NK1", CodigoCompendio = "182",
                Nome = "Curva IS Dinâmica (Novo-Keynesiana)",
                Categoria = "Ciências Sociais e Econômicas",
                SubCategoria = "Macroeconomia DSGE",
                Expressao = "x_t = E_t[x_{t+1}] - σ(i_t - E_t[π_{t+1}] - r_t^n)",
                ExprTexto = "Equação de Euler agregada",
                Descricao = "Relaciona output gap (xt) esperado com taxa de juros real (it-πt+1) e taxa natural rtn. σ é elasticidade de substituição intertemporal.",
                Criador = "Clarida, Galí, Gertler",
                AnoOrigin = "1999",
                ExemploPratico = "Política monetária: juros reais altos reduzem demanda. Modelos DSGE: previsão de inflação e output. Bancos centrais (Fed, BCE): calibração de modelos.",
                Unidades = "%",
                VariavelResultado = "output_gap",
                UnidadeResultado = "%",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "x_lead", Nome = "E_t[x_{t+1}]", Descricao = "Output gap esperado futuro", Unidade = "%", ValorPadrao = 0 },
                    new() { Simbolo = "sigma", Nome = "σ", Descricao = "Elasticidade intertemporal", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "i_t", Nome = "i_t", Descricao = "Taxa de juros nominal", Unidade = "%", ValorPadrao = 2 },
                    new() { Simbolo = "pi_lead", Nome = "E_t[π_{t+1}]", Descricao = "Inflação esperada", Unidade = "%", ValorPadrao = 2 },
                    new() { Simbolo = "r_n", Nome = "r_t^n", Descricao = "Taxa natural de juros", Unidade = "%", ValorPadrao = 0.5 }
                },
                Calcular = inputs =>
                {
                    double x_lead = inputs["x_lead"];
                    double sigma = inputs["sigma"];
                    double i_t = inputs["i_t"];
                    double pi_lead = inputs["pi_lead"];
                    double r_n = inputs["r_n"];
                    return x_lead - sigma * (i_t - pi_lead - r_n);
                }
            };
        }

        // [NK2] Curva de Phillips Novo-Keynesiana
        public static Formula V5_NK2_NewKeynesianPhillipsCurve()
        {
            return new Formula
            {
                Id = "V5-NK2", CodigoCompendio = "183",
                Nome = "Curva de Phillips Novo-Keynesiana",
                Categoria = "Ciências Sociais e Econômicas",
                SubCategoria = "Macroeconomia DSGE",
                Expressao = "π_t = βE_t[π_{t+1}] + κx_t",
                ExprTexto = "Inflação forward-looking",
                Descricao = "Inflação πt depende de expectativas futuras βE[πt+1] e output gap κxt. κ=(1-θ)(1-βθ)/θ onde θ é probabilidade de não reajuste à Calvo.",
                Criador = "Guillermo Calvo",
                AnoOrigin = "1983",
                ExemploPratico = "Política de metas de inflação: expectativas ancoradas reduzem inflação. Rigidez de preços: θ alto → κ baixo → inflação inercial. Comunicação de BC.",
                Unidades = "%",
                VariavelResultado = "inflacao",
                UnidadeResultado = "%",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "beta", Nome = "β", Descricao = "Fator de desconto", Unidade = "", ValorPadrao = 0.99 },
                    new() { Simbolo = "pi_lead", Nome = "E_t[π_{t+1}]", Descricao = "Inflação esperada", Unidade = "%", ValorPadrao = 2 },
                    new() { Simbolo = "kappa", Nome = "κ", Descricao = "Inclinação de Phillips", Unidade = "", ValorPadrao = 0.1 },
                    new() { Simbolo = "x_t", Nome = "x_t", Descricao = "Output gap", Unidade = "%", ValorPadrao = 1 }
                },
                Calcular = inputs =>
                {
                    double beta = inputs["beta"];
                    double pi_lead = inputs["pi_lead"];
                    double kappa = inputs["kappa"];
                    double x_t = inputs["x_t"];
                    return beta * pi_lead + kappa * x_t;
                }
            };
        }

        // [NK4] Regra de Taylor
        public static Formula V5_NK4_TaylorRule()
        {
            return new Formula
            {
                Id = "V5-NK4", CodigoCompendio = "184",
                Nome = "Regra de Taylor",
                Categoria = "Ciências Sociais e Econômicas",
                SubCategoria = "Macroeconomia DSGE",
                Expressao = "i_t = r* + π_t + φ_π(π_t - π*) + φ_x·x_t",
                ExprTexto = "Regra de política monetária",
                Descricao = "Taxa de juros nominal it ajustada por inflação πt e output gap xt. φπ>1 (Princípio de Taylor) garante estabilidade. r* taxa natural, π* meta.",
                Criador = "John B. Taylor",
                AnoOrigin = "1993",
                ExemploPratico = "Fed: φπ≈1.5, φx≈0.5. BCE: ênfase em inflação (φπ alto). Bancos centrais usam variações. Previsão de juros em mercados financeiros.",
                Unidades = "%",
                VariavelResultado = "taxa_juros",
                UnidadeResultado = "%",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "r_star", Nome = "r*", Descricao = "Taxa natural de juros", Unidade = "%", ValorPadrao = 2 },
                    new() { Simbolo = "pi_t", Nome = "π_t", Descricao = "Inflação corrente", Unidade = "%", ValorPadrao = 3 },
                    new() { Simbolo = "pi_star", Nome = "π*", Descricao = "Meta de inflação", Unidade = "%", ValorPadrao = 2 },
                    new() { Simbolo = "phi_pi", Nome = "φ_π", Descricao = "Coeficiente de resposta à inflação", Unidade = "", ValorPadrao = 1.5 },
                    new() { Simbolo = "phi_x", Nome = "φ_x", Descricao = "Coeficiente de resposta ao output gap", Unidade = "", ValorPadrao = 0.5 },
                    new() { Simbolo = "x_t", Nome = "x_t", Descricao = "Output gap", Unidade = "%", ValorPadrao = 1 }
                },
                Calcular = inputs =>
                {
                    double r_star = inputs["r_star"];
                    double pi_t = inputs["pi_t"];
                    double pi_star = inputs["pi_star"];
                    double phi_pi = inputs["phi_pi"];
                    double phi_x = inputs["phi_x"];
                    double x_t = inputs["x_t"];
                    return r_star + pi_t + phi_pi * (pi_t - pi_star) + phi_x * x_t;
                }
            };
        }

        #endregion

        #region 19. ECONOFÍSICA

        // [EF1] Distribuição de Pareto (Riqueza)
        public static Formula V5_EF1_ParetoDistribution()
        {
            return new Formula
            {
                Id = "V5-EF1", CodigoCompendio = "185",
                Nome = "Distribuição de Pareto (Riqueza)",
                Categoria = "Ciências Sociais e Econômicas",
                SubCategoria = "Econofísica",
                Expressao = "P(x) = αx_m^α / x^(α+1) para x ≥ x_m",
                ExprTexto = "Lei de potência para riqueza",
                Descricao = "Distribuição de Pareto: P(x)∝x^-(α+1) para x≥xm. α é índice de Pareto (α≈1.5 em riqueza). Cauda pesada: poucos muito ricos, many pobres.",
                Criador = "Vilfredo Pareto",
                AnoOrigin = "1896",
                ExemploPratico = "80-20 rule: 20% possuem 80% da riqueza. Distribuições de renda globais. Fenômenos de lei de potência: terremotos, citações, cidades.",
                Unidades = "",
                VariavelResultado = "probabilidade",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "alpha", Nome = "α", Descricao = "Índice de Pareto", Unidade = "", ValorPadrao = 1.5 },
                    new() { Simbolo = "x_m", Nome = "x_m", Descricao = "Riqueza mínima", Unidade = "$", ValorPadrao = 10000 },
                    new() { Simbolo = "x", Nome = "x", Descricao = "Riqueza", Unidade = "$", ValorPadrao = 50000 }
                },
                Calcular = inputs =>
                {
                    double alpha = inputs["alpha"];
                    double x_m = inputs["x_m"];
                    double x = inputs["x"];
                    if (x < x_m) return 0;
                    return alpha * Math.Pow(x_m, alpha) / Math.Pow(x, alpha + 1);
                }
            };
        }

        // [SF3] Modelo de Difusão de Bass
        public static Formula V5_SF3_BassDiffusionModel()
        {
            return new Formula
            {
                Id = "V5-SF3", CodigoCompendio = "186",
                Nome = "Modelo de Difusão de Bass",
                Categoria = "Ciências Sociais e Econômicas",
                SubCategoria = "Sociofísica",
                Expressao = "dN/dt = (p + q·N(t)/m)·(m - N(t))",
                ExprTexto = "Difusão de inovações",
                Descricao = "Taxa de adoção dN/dt de inovação: p=coeficiente de inovação (externos), q=imitação (internos), m=mercado potencial. Curva S de adoção.",
                Criador = "Frank Bass",
                AnoOrigin = "1969",
                ExemploPratico = "Adoção de smartphones, TVs, internet. Marketing: previsão de vendas. p baixo, q alto → adoção lenta inicial, explosão posterior (word-of-mouth).",
                Unidades = "adoções/dia",
                VariavelResultado = "taxa_adocao",
                UnidadeResultado = "adoções/dia",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "p", Nome = "p", Descricao = "Coeficiente de inovação", Unidade = "1/dia", ValorPadrao = 0.03 },
                    new() { Simbolo = "q", Nome = "q", Descricao = "Coeficiente de imitação", Unidade = "1/dia", ValorPadrao = 0.38 },
                    new() { Simbolo = "N_t", Nome = "N(t)", Descricao = "Adotantes acumulados", Unidade = "", ValorPadrao = 100 },
                    new() { Simbolo = "m", Nome = "m", Descricao = "Mercado potencial", Unidade = "", ValorPadrao = 1000 }
                },
                Calcular = inputs =>
                {
                    double p = inputs["p"];
                    double q = inputs["q"];
                    double N_t = inputs["N_t"];
                    double m = inputs["m"];
                    return (p + q * N_t / m) * (m - N_t);
                }
            };
        }

        #endregion

        #endregion

        #region PARTE VI - BIOLOGIA E MEDICINA

        #region 21. GENÉTICA QUANTITATIVA

        // [GQ4] Equação do Criador (Breeder's Equation)
        public static Formula V5_GQ4_BreedersEquation()
        {
            return new Formula
            {
                Id = "V5-GQ4", CodigoCompendio = "187",
                Nome = "Equação do Criador (Breeder's Equation)",
                Categoria = "Biologia e Medicina",
                SubCategoria = "Genética Quantitativa",
                Expressao = "R = h²·S",
                ExprTexto = "Resposta à seleção",
                Descricao = "Resposta R à seleção: R=h²S onde h²=herdabilidade (VA/VP) e S=diferencial de seleção (média selecionados - geral). Prediz ganho genético.",
                Criador = "R. A. Fisher, Sewall Wright",
                AnoOrigin = "~1920",
                ExemploPratico = "Melhoramento animal: seleção para produção de leite. Plantas: resistência a doenças. h²≈0.5 para altura humana → metade da variação é genética.",
                Unidades = "unidades de fenótipo",
                VariavelResultado = "resposta",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "h2", Nome = "h²", Descricao = "Herdabilidade (0-1)", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 },
                    new() { Simbolo = "S", Nome = "S", Descricao = "Diferencial de seleção", Unidade = "", ValorPadrao = 10 }
                },
                Calcular = inputs =>
                {
                    double h2 = inputs["h2"];
                    double S = inputs["S"];
                    return h2 * S;
                }
            };
        }

        // [GW5] Escore Poligênico (PGS)
        public static Formula V5_GW5_PolygenicScore()
        {
            return new Formula
            {
                Id = "V5-GW5", CodigoCompendio = "188",
                Nome = "Escore Poligênico (PGS / PRS)",
                Categoria = "Biologia e Medicina",
                SubCategoria = "Genética Quantitativa",
                Expressao = "PGS_i = Σ_j β_j·g_ij",
                ExprTexto = "Soma ponderada de alelos de risco",
                Descricao = "Escore poligênico: PGS_i=Σj βj·gij onde βj=efeito do SNP j (de GWAS), gij=dosagem alélica (0,1,2). Prediz risco de doenças complexas.",
                Criador = "Estudos GWAS modernos",
                AnoOrigin = "2009+",
                ExemploPratico = "Diabetes tipo 2: PGS prevê risco. Doença cardíaca coronária: estratificação de risco. Altura: R²≈20-40%. Limitações: ancestralidade, interações.",
                Unidades = "",
                VariavelResultado = "PGS",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "beta1", Nome = "β₁", Descricao = "Efeito estimado SNP 1", Unidade = "", ValorPadrao = 0.1 },
                    new() { Simbolo = "g1", Nome = "g₁", Descricao = "Dosagem alélica SNP 1 (0/1/2)", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 2 },
                    new() { Simbolo = "beta2", Nome = "β₂", Descricao = "Efeito estimado SNP 2", Unidade = "", ValorPadrao = 0.05 },
                    new() { Simbolo = "g2", Nome = "g₂", Descricao = "Dosagem alélica SNP 2", Unidade = "", ValorPadrao = 2, ValorMin = 0, ValorMax = 2 }
                },
                Calcular = inputs =>
                {
                    double beta1 = inputs["beta1"];
                    double g1 = inputs["g1"];
                    double beta2 = inputs["beta2"];
                    double g2 = inputs["g2"];
                    return beta1 * g1 + beta2 * g2;
                }
            };
        }

        #endregion

        #endregion

        #region PARTE VII - NOVAS FRONTEIRAS

        #region 23. PRIVACIDADE DIFERENCIAL E APRENDIZADO FEDERADO

        // [DP1] Privacidade Diferencial (ε-DP)
        public static Formula V5_DP1_DifferentialPrivacy()
        {
            return new Formula
            {
                Id = "V5-DP1", CodigoCompendio = "189",
                Nome = "Privacidade Diferencial (ε-DP)",
                Categoria = "Novas Fronteiras",
                SubCategoria = "Privacidade Diferencial",
                Expressao = "P(M(D)) ≤ e^ε · P(M(D')) para D ≈ D'",
                ExprTexto = "Garantia formal de privacidade",
                Descricao = "Mecanismo M é ε-diferencialmente privado se outputs têm probabilidades semelhantes em datasets vizinhos D,D'(diferem em 1 registro). ε=budget de privacidade.",
                Criador = "Cynthia Dwork",
                AnoOrigin = "2006",
                ExemploPratico = "Censo dos EUA 2020: DP protege dados individuais. Google/Apple: telemetria com DP. ε≈1 (forte), ε≈10 (fraco). Trade-off privacidade-utilidade.",
                Unidades = "",
                VariavelResultado = "razao_probabilidade",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "epsilon", Nome = "ε", Descricao = "Budget de privacidade", Unidade = "", ValorPadrao = 1 }
                },
                Calcular = inputs =>
                {
                    double epsilon = inputs["epsilon"];
                    return Math.Exp(epsilon); // Razão máxima de probabilidades
                }
            };
        }

        // [DP3] Mecanismo de Laplace
        public static Formula V5_DP3_LaplaceMechanism()
        {
            return new Formula
            {
                Id = "V5-DP3", CodigoCompendio = "190",
                Nome = "Mecanismo de Laplace",
                Categoria = "Novas Fronteiras",
                SubCategoria = "Privacidade Diferencial",
                Expressao = "M(D) = f(D) + Lap(Δf/ε)",
                ExprTexto = "Adição de ruído Laplaciano",
                Descricao = "Adiciona ruído Laplaciano com escala Δf/ε à consulta f(D). Δf=sensibilidade global (máxima mudança em f ao alterar 1 registro). Garante ε-DP.",
                Criador = "Cynthia Dwork et al.",
                AnoOrigin = "2006",
                ExemploPratico = "Contagens de usuários: f(D)=count(users satisfazendo query), Δf=1. Médias: Δf depende de range. Histogramas privativos. ML: DP-SGD.",
                Unidades = "",
                VariavelResultado = "resultado_privado",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "f_D", Nome = "f(D)", Descricao = "Resultado verdadeiro da consulta", Unidade = "", ValorPadrao = 100 },
                    new() { Simbolo = "delta_f", Nome = "Δf", Descricao = "Sensibilidade da consulta", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "epsilon", Nome = "ε", Descricao = "Budget de privacidade", Unidade = "", ValorPadrao = 1 },
                    new() { Simbolo = "ruido", Nome = "Lap(0,b)", Descricao = "Ruído Laplaciano (sim", Unidade = "", ValorPadrao = 0 }
                },
                Calcular = inputs =>
                {
                    double f_D = inputs["f_D"];
                    double delta_f = inputs["delta_f"];
                    double epsilon = inputs["epsilon"];
                    double ruido = inputs["ruido"];
                    double b = delta_f / epsilon;
                    // Simplificação: aceita ruído como entrada (em real, seria sample de Lap(0,b))
                    return f_D + ruido;
                }
            };
        }

        // [FL1] Federated Averaging (FedAvg)
        public static Formula V5_FL1_FederatedAveraging()
        {
            return new Formula
            {
                Id = "V5-FL1", CodigoCompendio = "191",
                Nome = "Federated Averaging (FedAvg)",
                Categoria = "Novas Fronteiras",
                SubCategoria = "Aprendizado Federado",
                Expressao = "w_{t+1} = Σ_k (n_k/n)·w_{t+1}^k",
                ExprTexto = "Agregação de modelos federados",
                Descricao = "Servidor agrega modelos locais w^k ponderados por tamanho de dataset nk. FedAvg: clientes treinam localmente, servidor faz média ponderada.",
                Criador = "H. Brendan McMahan et al. (Google)",
                AnoOrigin = "2016",
                ExemploPratico = "Gboard (Google): predição de texto sem enviar dados. Saúde: hospitais colaboram sem compartilhar dados de pacientes. IoT: dispositivos edge.",
                Unidades = "",
                VariavelResultado = "peso_agregado",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "w1", Nome = "w₁", Descricao = "Peso do cliente 1", Unidade = "", ValorPadrao = 1.5 },
                    new() { Simbolo = "n1", Nome = "n₁", Descricao = "Tamanho dataset cliente 1", Unidade = "", ValorPadrao = 100 },
                    new() { Simbolo = "w2", Nome = "w₂", Descricao = "Peso do cliente 2", Unidade = "", ValorPadrao = 2.0 },
                    new() { Simbolo = "n2", Nome = "n₂", Descricao = "Tamanho dataset cliente 2", Unidade = "", ValorPadrao = 200 }
                },
                Calcular = inputs =>
                {
                    double w1 = inputs["w1"];
                    double n1 = inputs["n1"];
                    double w2 = inputs["w2"];
                    double n2 = inputs["n2"];
                    double n_total = n1 + n2;
                    return (n1 / n_total) * w1 + (n2 / n_total) * w2;
                }
            };
        }

        #endregion

        #region 24. BLOCKCHAIN E CRIPTOGRAFIA MODERNA

        // [BC1] Proof-of-Work (Blockchain)
        public static Formula V5_BC1_ProofOfWork()
        {
            return new Formula
            {
                Id = "V5-BC1", CodigoCompendio = "192",
                Nome = "Proof-of-Work (PoW)",
                Categoria = "Novas Fronteiras",
                SubCategoria = "Blockchain",
                Expressao = "H(block_header || nonce) < target",
                ExprTexto = "Prova criptográfica de trabalho",
                Descricao = "Mineiro encontra nonce tal que hash do bloco < target. Dificuldade ∝ 1/target. Impossível prever nonce, requer tentativas iterativas (força bruta).",
                Criador = "Satoshi Nakamoto (Bitcoin)",
                AnoOrigin = "2008",
                ExemploPratico = "Bitcoin: SHA-256, difficulty adjust a cada 2016 blocos (~2 semanas). Ethereum (até merge): Ethash. Consumo energético: crítica ao PoW.",
                Unidades = "",
                VariavelResultado = "tentativas_esperadas",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "difficulty", Nome = "Dificuldade", Descricao = "Dificuldade da rede", Unidade = "", ValorPadrao = 1e12 }
                },
                Calcular = inputs =>
                {
                    double difficulty = inputs["difficulty"];
                    // Número esperado de hashes = difficulty * 2³²
                    return difficulty * Math.Pow(2, 32);
                }
            };
        }

        #endregion

        #region 26. IA EXPLICÁVEL (XAI)

        // [XA1] SHAP Values (SHapley Additive exPlanations)
        public static Formula V5_XA1_SHAPValues()
        {
            return new Formula
            {
                Id = "V5-XA1", CodigoCompendio = "193",
                Nome = "SHAP Values",
                Categoria = "Novas Fronteiras",
                SubCategoria = "IA Explicável (XAI)",
                Expressao = "φ_i = Σ_S [(|S|!(|F|-|S|-1)!)/|F|!]·[f(S∪{i})-f(S)]",
                ExprTexto = "Valores de Shapley para features",
                Descricao = "SHAP atribui contribuição φi de cada feature i à predição usando valores de Shapley de teoria dos jogos. Média sobre todas coalizões S⊆F\\{i}.",
                Criador = "Scott Lundberg e Su-In Lee",
                AnoOrigin = "2017",
                ExemploPratico = "Explica predições de ML: SHAP=+5 para idade, -2 para renda → contribuições individuais. LIME, DeepLIFT: métodos relacionados. Medicina: explicar diagnósticos.",
                Unidades = "",
                VariavelResultado = "shap_value",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "f_with", Nome = "f(S∪{i})", Descricao = "Predição com feature i", Unidade = "", ValorPadrao = 0.8 },
                    new() { Simbolo = "f_without", Nome = "f(S)", Descricao = "Predição sem feature i", Unidade = "", ValorPadrao = 0.5 },
                    new() { Simbolo = "weight", Nome = "Peso de Shapley", Descricao = "Ponderação combinatória", Unidade = "", ValorPadrao = 1 }
                },
                Calcular = inputs =>
                {
                    double f_with = inputs["f_with"];
                    double f_without = inputs["f_without"];
                    double weight = inputs["weight"];
                    // Simplificação: φ ≈ weight · (f_with - f_without)
                    return weight * (f_with - f_without);
                }
            };
        }

        // [XA8] Grad-CAM (Gradient-weighted Class Activation Mapping)
        public static Formula V5_XA8_GradCAM()
        {
            return new Formula
            {
                Id = "V5-XA8", CodigoCompendio = "194",
                Nome = "Grad-CAM",
                Categoria = "Novas Fronteiras",
                SubCategoria = "IA Explicável (XAI)",
                Expressao = "L_c = ReLU(Σ_k α_k^c·A_k) onde α_k^c = (1/Z)Σ_i Σ_j (∂y^c/∂A_k^ij)",
                ExprTexto = "Mapa de ativação de classe",
                Descricao = "Grad-CAM produz mapa de calor visual para CNNs: pesos αkc=gradiente da classe c em relação a mapa de features Ak. Destaca regiões importantes.",
                Criador = "Ramprasaath R. Selvaraju et al.",
                AnoOrigin = "2017",
                ExemploPratico = "Classificação de imagens: visualiza onde CNN olha para decidir 'gato'. Diagnóstico médico: mapas de calor em raios-X. Debugging de modelos.",
                Unidades = "",
                VariavelResultado = "intensidade_gradcam",
                UnidadeResultado = "",
                Variaveis = new List<Variavel>
                {
                    new() { Simbolo = "alpha", Nome = "α^c", Descricao = "Peso do gradiente (classe c)", Unidade = "", ValorPadrao = 0.8 },
                    new() { Simbolo = "A", Nome = "A_k", Descricao = "Mapa de ativação", Unidade = "", ValorPadrao = 1.5 }
                },
                Calcular = inputs =>
                {
                    double alpha = inputs["alpha"];
                    double A = inputs["A"];
                    double linear_combination = alpha * A;
                    // ReLU
                    return linear_combination > 0 ? linear_combination : 0;
                }
            };
        }

        #endregion

        #endregion

        #region Funções Auxiliares

        // Função auxiliar: Exponenciação modular rápida
        private static long ModPow(long baseNum, long exponent, long modulus)
        {
            long result = 1;
            baseNum %= modulus;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = (result * baseNum) % modulus;
                exponent >>= 1;
                baseNum = (baseNum * baseNum) % modulus;
            }
            return result;
        }

        #endregion
    }
}
