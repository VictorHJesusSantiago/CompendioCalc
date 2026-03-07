using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // VOLUME 1: FUNDAMENTOS
    // 16 categorias: Álgebra, Geometria, Trigonometria, Cálculo, Álgebra Linear,
    // Equações Diferenciais, Probabilidade, Estatística, Mecânica Clássica,
    // Termodinâmica, Eletromagnetismo, Óptica, Mecânica dos Fluidos,
    // Engenharia, Biologia Matemática, Computação
    
    // ========================================
    // CATEGORIA 1: ÁLGEBRA (5 fórmulas)
    // ========================================
    
    public static Formula V1_ALG001_QuadraticFormula()
    {
        return new Formula
        {
            Id = "V1-ALG001",
            CodigoCompendio = "001",
            Nome = "Fórmula de Bhaskara",
            Categoria = "Álgebra",
            SubCategoria = "Equações Quadráticas",
            Expressao = "x = (-b ± √(b²-4ac)) / 2a",
            ExprTexto = "Raízes de equação do segundo grau",
            Descricao = "Determina as raízes de uma equação quadrática ax² + bx + c = 0. O discriminante Δ = b²-4ac indica: Δ>0 duas raízes reais distintas, Δ=0 uma raiz real dupla, Δ<0 raízes complexas conjugadas.",
            Criador = "Bhaskara II",
            AnoOrigin = "1150",
            ExemploPratico = "Para x² - 5x + 6 = 0, temos a=1, b=-5, c=6. Δ=25-24=1, então x = (5±1)/2, resultando em x=3 ou x=2.",
            Unidades = "",
            VariavelResultado = "x",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Coeficiente quadrático", Descricao = "Coeficiente de x²", Unidade = "", ValorPadrao = 1, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente de x", Unidade = "", ValorPadrao = -5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Termo independente", Descricao = "Termo constante", Unidade = "", ValorPadrao = 6, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double c = inputs["c"];
                double discriminant = b * b - 4 * a * c;
                if (discriminant < 0) return double.NaN;
                return (-b + Math.Sqrt(discriminant)) / (2 * a);
            }
        };
    }
    
    public static Formula V1_ALG002_BinomialTheorem()
    {
        return new Formula
        {
            Id = "V1-ALG002",
            CodigoCompendio = "002",
            Nome = "Binômio de Newton",
            Categoria = "Álgebra",
            SubCategoria = "Expansões Polinomiais",
            Expressao = "(a+b)^n = Σ C(n,k) * a^(n-k) * b^k",
            ExprTexto = "Expansão de potência de binômio",
            Descricao = "Expande (a+b)^n em soma de termos usando coeficientes binomiais C(n,k) = n!/(k!(n-k)!). Fundamental para álgebra e probabilidade.",
            Criador = "Isaac Newton",
            AnoOrigin = "1665",
            ExemploPratico = "Para (a+b)³, temos: 1a³ + 3a²b + 3ab² + 1b³. Com a=2, b=1: 8 + 12 + 6 + 1 = 27 = 3³.",
            Unidades = "",
            VariavelResultado = "resultado",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Primeiro termo", Descricao = "Valor do primeiro termo", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Segundo termo", Descricao = "Valor do segundo termo", Unidade = "", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Expoente", Descricao = "Potência do binômio", Unidade = "", ValorPadrao = 3, ValorMin = 0, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                int n = (int)inputs["n"];
                return Math.Pow(a + b, n);
            }
        };
    }
    
    public static Formula V1_ALG003_ArithmeticSeries()
    {
        return new Formula
        {
            Id = "V1-ALG003",
            CodigoCompendio = "003",
            Nome = "Soma de Progressão Aritmética",
            Categoria = "Álgebra",
            SubCategoria = "Sequências e Séries",
            Expressao = "Sn = n(a1 + an)/2",
            ExprTexto = "Soma dos n primeiros termos de PA",
            Descricao = "Calcula a soma dos n primeiros termos de uma progressão aritmética onde a1 é o primeiro termo e an = a1 + (n-1)r é o último termo (r é a razão).",
            Criador = "Carl Friedrich Gauss",
            AnoOrigin = "1786",
            ExemploPratico = "Soma de 1+2+3+...+100: a1=1, an=100, n=100. Sn = 100(1+100)/2 = 5050.",
            Unidades = "",
            VariavelResultado = "Sn",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Número de termos", Descricao = "Quantidade de termos na PA", Unidade = "", ValorPadrao = 100, ValorMin = 1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "a1", Nome = "Primeiro termo", Descricao = "Valor do primeiro termo", Unidade = "", ValorPadrao = 1, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "an", Nome = "Último termo", Descricao = "Valor do último termo", Unidade = "", ValorPadrao = 100, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double a1 = inputs["a1"];
                double an = inputs["an"];
                return n * (a1 + an) / 2;
            }
        };
    }
    
    public static Formula V1_ALG004_GeometricSeries()
    {
        return new Formula
        {
            Id = "V1-ALG004",
            CodigoCompendio = "004",
            Nome = "Soma de Progressão Geométrica",
            Categoria = "Álgebra",
            SubCategoria = "Sequências e Séries",
            Expressao = "Sn = a1(1-q^n)/(1-q)",
            ExprTexto = "Soma dos n primeiros termos de PG",
            Descricao = "Calcula a soma dos n primeiros termos de uma progressão geométrica onde a1 é o primeiro termo e q é a razão (q≠1). Para |q|<1 e n→∞, S∞ = a1/(1-q).",
            Criador = "Euclides",
            AnoOrigin = "300 a.C.",
            ExemploPratico = "Soma 1+2+4+8+...+512: a1=1, q=2, n=10. Sn = 1(1-2^10)/(1-2) = 1023.",
            Unidades = "",
            VariavelResultado = "Sn",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a1", Nome = "Primeiro termo", Descricao = "Valor do primeiro termo", Unidade = "", ValorPadrao = 1, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "q", Nome = "Razão", Descricao = "Razão da PG", Unidade = "", ValorPadrao = 2, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Número de termos", Descricao = "Quantidade de termos na PG", Unidade = "", ValorPadrao = 10, ValorMin = 1, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a1 = inputs["a1"];
                double q = inputs["q"];
                double n = inputs["n"];
                if (Math.Abs(q - 1) < 1e-10) return a1 * n;
                return a1 * (1 - Math.Pow(q, n)) / (1 - q);
            }
        };
    }
    
    public static Formula V1_ALG005_LinearEquation()
    {
        return new Formula
        {
            Id = "V1-ALG005",
            CodigoCompendio = "005",
            Nome = "Equação Linear",
            Categoria = "Álgebra",
            SubCategoria = "Equações de Primeiro Grau",
            Expressao = "x = (c - b) / a",
            ExprTexto = "Solução de ax + b = c",
            Descricao = "Resolve equações lineares da forma ax + b = c, isolando x. Válida para a≠0. Fundamental para modelagem matemática básica.",
            Criador = "Al-Khwarizmi",
            AnoOrigin = "820",
            ExemploPratico = "Para 3x + 5 = 20, temos a=3, b=5, c=20. Logo x = (20-5)/3 = 5.",
            Unidades = "",
            VariavelResultado = "x",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Coeficiente de x", Descricao = "Multiplicador de x", Unidade = "", ValorPadrao = 3, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Termo constante (esquerda)", Descricao = "Constante do lado esquerdo", Unidade = "", ValorPadrao = 5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Termo constante (direita)", Descricao = "Constante do lado direito", Unidade = "", ValorPadrao = 20, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double c = inputs["c"];
                if (Math.Abs(a) < 1e-10) return double.NaN;
                return (c - b) / a;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 2: GEOMETRIA (5 fórmulas)
    // ========================================
    
    public static Formula V1_GEO001_PythagoreanTheorem()
    {
        return new Formula
        {
            Id = "V1-GEO001",
            CodigoCompendio = "006",
            Nome = "Teorema de Pitágoras",
            Categoria = "Geometria",
            SubCategoria = "Triângulos Retângulos",
            Expressao = "c = √(a² + b²)",
            ExprTexto = "Hipotenusa de triângulo retângulo",
            Descricao = "Em um triângulo retângulo, o quadrado da hipotenusa (c) é igual à soma dos quadrados dos catetos (a e b). Base da geometria euclidiana.",
            Criador = "Pitágoras",
            AnoOrigin = "500 a.C.",
            ExemploPratico = "Triângulo com catetos a=3 e b=4: c = √(9+16) = √25 = 5.",
            Unidades = "mesmo",
            VariavelResultado = "c",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Cateto 1", Descricao = "Primeiro cateto", Unidade = "m", ValorPadrao = 3, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Cateto 2", Descricao = "Segundo cateto", Unidade = "m", ValorPadrao = 4, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                return Math.Sqrt(a * a + b * b);
            }
        };
    }
    
    public static Formula V1_GEO002_CircleArea()
    {
        return new Formula
        {
            Id = "V1-GEO002",
            CodigoCompendio = "007",
            Nome = "Área do Círculo",
            Categoria = "Geometria",
            SubCategoria = "Figuras Planas",
            Expressao = "A = πr²",
            ExprTexto = "Área de círculo",
            Descricao = "Calcula a área de um círculo com raio r. π≈3.14159 é a razão entre circunferência e diâmetro.",
            Criador = "Arquimedes",
            AnoOrigin = "250 a.C.",
            ExemploPratico = "Círculo com raio r=5m: A = π×25 ≈ 78.54 m².",
            Unidades = "m²",
            VariavelResultado = "A",
            UnidadeResultado = "m²",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "r", Nome = "Raio", Descricao = "Raio do círculo", Unidade = "m", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double r = inputs["r"];
                return Math.PI * r * r;
            }
        };
    }
    
    public static Formula V1_GEO003_SphereVolume()
    {
        return new Formula
        {
            Id = "V1-GEO003",
            CodigoCompendio = "008",
            Nome = "Volume da Esfera",
            Categoria = "Geometria",
            SubCategoria = "Sólidos Geométricos",
            Expressao = "V = (4/3)πr³",
            ExprTexto = "Volume de esfera",
            Descricao = "Calcula o volume de uma esfera com raio r. Derivado por Arquimedes usando método de exaustão.",
            Criador = "Arquimedes",
            AnoOrigin = "250 a.C.",
            ExemploPratico = "Esfera com raio r=3m: V = (4/3)π×27 ≈ 113.10 m³.",
            Unidades = "m³",
            VariavelResultado = "V",
            UnidadeResultado = "m³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "r", Nome = "Raio", Descricao = "Raio da esfera", Unidade = "m", ValorPadrao = 3, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double r = inputs["r"];
                return (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);
            }
        };
    }
    
    public static Formula V1_GEO004_TriangleArea()
    {
        return new Formula
        {
            Id = "V1-GEO004",
            CodigoCompendio = "009",
            Nome = "Área do Triângulo",
            Categoria = "Geometria",
            SubCategoria = "Figuras Planas",
            Expressao = "A = (b × h) / 2",
            ExprTexto = "Área de triângulo por base e altura",
            Descricao = "Calcula a área de um triângulo conhecendo a base b e a altura h perpendicular a ela. Fórmula fundamental da geometria plana.",
            Criador = "Euclides",
            AnoOrigin = "300 a.C.",
            ExemploPratico = "Triângulo com base b=10cm e altura h=6cm: A = (10×6)/2 = 30 cm².",
            Unidades = "m²",
            VariavelResultado = "A",
            UnidadeResultado = "m²",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "b", Nome = "Base", Descricao = "Comprimento da base", Unidade = "m", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Altura", Descricao = "Altura perpendicular à base", Unidade = "m", ValorPadrao = 6, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double b = inputs["b"];
                double h = inputs["h"];
                return (b * h) / 2;
            }
        };
    }
    
    public static Formula V1_GEO005_CylinderVolume()
    {
        return new Formula
        {
            Id = "V1-GEO005",
            CodigoCompendio = "010",
            Nome = "Volume do Cilindro",
            Categoria = "Geometria",
            SubCategoria = "Sólidos Geométricos",
            Expressao = "V = πr²h",
            ExprTexto = "Volume de cilindro",
            Descricao = "Calcula o volume de um cilindro com raio da base r e altura h. Equivale à área da base multiplicada pela altura.",
            Criador = "Arquimedes",
            AnoOrigin = "250 a.C.",
            ExemploPratico = "Cilindro com raio r=2m e altura h=5m: V = π×4×5 ≈ 62.83 m³.",
            Unidades = "m³",
            VariavelResultado = "V",
            UnidadeResultado = "m³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "r", Nome = "Raio", Descricao = "Raio da base", Unidade = "m", ValorPadrao = 2, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Altura", Descricao = "Altura do cilindro", Unidade = "m", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double r = inputs["r"];
                double h = inputs["h"];
                return Math.PI * r * r * h;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 3: TRIGONOMETRIA (4 fórmulas)
    // ========================================
    
    public static Formula V1_TRIG001_SineLaw()
    {
        return new Formula
        {
            Id = "V1-TRIG001",
            CodigoCompendio = "011",
            Nome = "Lei dos Senos",
            Categoria = "Trigonometria",
            SubCategoria = "Relações em Triângulos",
            Expressao = "a/sin(A) = b/sin(B) = c/sin(C)",
            ExprTexto = "Razão entre lados e senos dos ângulos opostos",
            Descricao = "Em qualquer triângulo, a razão entre um lado e o seno do ângulo oposto é constante. Permite resolver triângulos conhecendo 2 lados e 1 ângulo ou 1 lado e 2 ângulos.",
            Criador = "Al-Biruni",
            AnoOrigin = "1000",
            ExemploPratico = "Triângulo com a=10, A=30°, B=45°: b = a×sin(B)/sin(A) = 10×sin(45°)/sin(30°) ≈ 14.14.",
            Unidades = "mesmo",
            VariavelResultado = "b",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Lado a", Descricao = "Comprimento do lado a", Unidade = "m", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "A", Nome = "Ângulo A", Descricao = "Ângulo oposto ao lado a", Unidade = "graus", ValorPadrao = 30, ValorMin = 0, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Ângulo B", Descricao = "Ângulo oposto ao lado b", Unidade = "graus", ValorPadrao = 45, ValorMin = 0, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double A = inputs["A"] * Math.PI / 180;
                double B = inputs["B"] * Math.PI / 180;
                return a * Math.Sin(B) / Math.Sin(A);
            }
        };
    }
    
    public static Formula V1_TRIG002_CosineLaw()
    {
        return new Formula
        {
            Id = "V1-TRIG002",
            CodigoCompendio = "012",
            Nome = "Lei dos Cossenos",
            Categoria = "Trigonometria",
            SubCategoria = "Relações em Triângulos",
            Expressao = "c² = a² + b² - 2ab×cos(C)",
            ExprTexto = "Relação entre lados e cosseno do ângulo oposto",
            Descricao = "Generaliza o Teorema de Pitágoras para triângulos não-retângulos. Permite calcular o terceiro lado conhecendo dois lados e o ângulo entre eles.",
            Criador = "Al-Kashi",
            AnoOrigin = "1427",
            ExemploPratico = "Triângulo com a=5, b=7, C=60°: c² = 25 + 49 - 2×5×7×cos(60°) = 74 - 35 = 39, logo c ≈ 6.24.",
            Unidades = "m",
            VariavelResultado = "c",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Lado a", Descricao = "Comprimento do lado a", Unidade = "m", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Lado b", Descricao = "Comprimento do lado b", Unidade = "m", ValorPadrao = 7, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "C", Nome = "Ângulo C", Descricao = "Ângulo entre os lados a e b", Unidade = "graus", ValorPadrao = 60, ValorMin = 0, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double C = inputs["C"] * Math.PI / 180;
                double c2 = a * a + b * b - 2 * a * b * Math.Cos(C);
                return Math.Sqrt(Math.Max(0, c2));
            }
        };
    }
    
    public static Formula V1_TRIG003_PythagoreanIdentity()
    {
        return new Formula
        {
            Id = "V1-TRIG003",
            CodigoCompendio = "013",
            Nome = "Identidade Pitagórica",
            Categoria = "Trigonometria",
            SubCategoria = "Identidades Fundamentais",
            Expressao = "sin²(θ) + cos²(θ) = 1",
            ExprTexto = "Soma dos quadrados de seno e cosseno",
            Descricao = "Identidade trigonométrica fundamental derivada do Teorema de Pitágoras no círculo unitário. Válida para qualquer ângulo θ.",
            Criador = "Hiparco",
            AnoOrigin = "150 a.C.",
            ExemploPratico = "Para θ=30°: sin²(30°) + cos²(30°) = (0.5)² + (0.866)² = 0.25 + 0.75 = 1.",
            Unidades = "",
            VariavelResultado = "resultado",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "theta", Nome = "Ângulo θ", Descricao = "Ângulo em graus", Unidade = "graus", ValorPadrao = 30, ValorMin = -360, ValorMax = 360, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double theta = inputs["theta"] * Math.PI / 180;
                double sin = Math.Sin(theta);
                double cos = Math.Cos(theta);
                return sin * sin + cos * cos;
            }
        };
    }
    
    public static Formula V1_TRIG004_TangentDefinition()
    {
        return new Formula
        {
            Id = "V1-TRIG004",
            CodigoCompendio = "014",
            Nome = "Definição de Tangente",
            Categoria = "Trigonometria",
            SubCategoria = "Funções Trigonométricas",
            Expressao = "tan(θ) = sin(θ) / cos(θ)",
            ExprTexto = "Tangente como razão seno/cosseno",
            Descricao = "Define a função tangente como a razão entre seno e cosseno. Indefinida quando cos(θ)=0 (múltiplos ímpares de 90°).",
            Criador = "Hiparco",
            AnoOrigin = "150 a.C.",
            ExemploPratico = "Para θ=45°: tan(45°) = sin(45°)/cos(45°) = (√2/2)/(√2/2) = 1.",
            Unidades = "",
            VariavelResultado = "tan_theta",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "theta", Nome = "Ângulo θ", Descricao = "Ângulo em graus", Unidade = "graus", ValorPadrao = 45, ValorMin = -360, ValorMax = 360, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double theta = inputs["theta"] * Math.PI / 180;
                return Math.Tan(theta);
            }
        };
    }
    
    // ========================================
    // CATEGORIA 4: CÁLCULO (5 fórmulas)
    // ========================================
    
    public static Formula V1_CALC001_PowerRule()
    {
        return new Formula
        {
            Id = "V1-CALC001",
            CodigoCompendio = "015",
            Nome = "Regra da Potência (Derivada)",
            Categoria = "Cálculo",
            SubCategoria = "Derivação",
            Expressao = "d/dx(x^n) = n×x^(n-1)",
            ExprTexto = "Derivada de potência",
            Descricao = "Regra fundamental para derivar funções potência. Válida para qualquer expoente real n.",
            Criador = "Isaac Newton / Gottfried Leibniz",
            AnoOrigin = "1665",
            ExemploPratico = "Para f(x) = x³, temos f'(x) = 3x². Em x=2: f'(2) = 3×4 = 12.",
            Unidades = "",
            VariavelResultado = "derivada",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Expoente", Descricao = "Expoente da potência", Unidade = "", ValorPadrao = 3, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "x", Nome = "Ponto de avaliação", Descricao = "Valor de x para avaliar derivada", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double x = inputs["x"];
                if (Math.Abs(x) < 1e-10 && n < 1) return double.PositiveInfinity;
                return n * Math.Pow(x, n - 1);
            }
        };
    }
    
    public static Formula V1_CALC002_ChainRule()
    {
        return new Formula
        {
            Id = "V1-CALC002",
            CodigoCompendio = "016",
            Nome = "Regra da Cadeia",
            Categoria = "Cálculo",
            SubCategoria = "Derivação",
            Expressao = "d/dx[f(g(x))] = f'(g(x)) × g'(x)",
            ExprTexto = "Derivada de função composta",
            Descricao = "Permite derivar composições de funções. A derivada do 'exterior' vezes a derivada do 'interior'.",
            Criador = "Gottfried Leibniz",
            AnoOrigin = "1676",
            ExemploPratico = "Para h(x) = (2x+1)³, temos f(u)=u³ e g(x)=2x+1. Logo h'(x) = 3(2x+1)² × 2 = 6(2x+1)².",
            Unidades = "",
            VariavelResultado = "derivada",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Coef. interno", Descricao = "Coeficiente linear da função interna", Unidade = "", ValorPadrao = 2, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Termo interno", Descricao = "Termo constante da função interna", Unidade = "", ValorPadrao = 1, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Expoente externo", Descricao = "Expoente da função externa", Unidade = "", ValorPadrao = 3, ValorMin = 1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "x", Nome = "Ponto de avaliação", Descricao = "Valor de x", Unidade = "", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double n = inputs["n"];
                double x = inputs["x"];
                double inner = a * x + b;
                return n * Math.Pow(inner, n - 1) * a;
            }
        };
    }
    
    public static Formula V1_CALC003_FundamentalTheorem()
    {
        return new Formula
        {
            Id = "V1-CALC003",
            CodigoCompendio = "017",
            Nome = "Teorema Fundamental do Cálculo",
            Categoria = "Cálculo",
            SubCategoria = "Integração",
            Expressao = "∫[a,b] f'(x)dx = f(b) - f(a)",
            ExprTexto = "Integral definida via antiderivada",
            Descricao = "Conecta derivação e integração: a integral definida de f'(x) de a até b é igual à diferença dos valores de f nos extremos.",
            Criador = "Isaac Newton / Gottfried Leibniz",
            AnoOrigin = "1669",
            ExemploPratico = "Para f(x)=x², ∫[0,3] 2x dx = [x²]₀³ = 9 - 0 = 9.",
            Unidades = "",
            VariavelResultado = "integral",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Limite inferior", Descricao = "Limite inferior de integração", Unidade = "", ValorPadrao = 0, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Limite superior", Descricao = "Limite superior de integração", Unidade = "", ValorPadrao = 3, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Expoente (n+1)", Descricao = "Para integral de x^n", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double n = inputs["n"];
                double nPlus1 = n + 1;
                return (Math.Pow(b, nPlus1) - Math.Pow(a, nPlus1)) / nPlus1;
            }
        };
    }
    
    public static Formula V1_CALC004_TaylorSeries()
    {
        return new Formula
        {
            Id = "V1-CALC004",
            CodigoCompendio = "018",
            Nome = "Série de Taylor",
            Categoria = "Cálculo",
            SubCategoria = "Séries e Aproximações",
            Expressao = "f(x) = Σ f^(n)(a)/n! × (x-a)^n",
            ExprTexto = "Expansão de função em série de potências",
            Descricao = "Aproxima funções suaves por polinômios infinitos. Para a=0, chama-se série de Maclaurin. Fundamental para análise numérica.",
            Criador = "Brook Taylor",
            AnoOrigin = "1715",
            ExemploPratico = "e^x ≈ 1 + x + x²/2 + x³/6 + ... Para x=1: e ≈ 1 + 1 + 0.5 + 0.167 ≈ 2.667.",
            Unidades = "",
            VariavelResultado = "aproximacao",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Ponto de avaliação", Descricao = "Valor de x para aproximar e^x", Unidade = "", ValorPadrao = 1, ValorMin = -5, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Número de termos", Descricao = "Ordem da aproximação", Unidade = "", ValorPadrao = 5, ValorMin = 1, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                int n = (int)inputs["n"];
                double sum = 0;
                double term = 1;
                for (int i = 0; i < n; i++)
                {
                    sum += term;
                    term *= x / (i + 1);
                }
                return sum;
            }
        };
    }
    
    public static Formula V1_CALC005_LHospitalRule()
    {
        return new Formula
        {
            Id = "V1-CALC005",
            CodigoCompendio = "019",
            Nome = "Regra de L'Hôpital",
            Categoria = "Cálculo",
            SubCategoria = "Limites",
            Expressao = "lim[x→a] f(x)/g(x) = lim[x→a] f'(x)/g'(x)",
            ExprTexto = "Limite de razão via derivadas",
            Descricao = "Para formas indeterminadas 0/0 ou ∞/∞, o limite da razão é igual ao limite da razão das derivadas. Aplicável repetidamente se necessário.",
            Criador = "Guillaume de l'Hôpital",
            AnoOrigin = "1696",
            ExemploPratico = "lim[x→0] sin(x)/x = lim[x→0] cos(x)/1 = 1.",
            Unidades = "",
            VariavelResultado = "limite",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Ponto próximo a 0", Descricao = "Valor próximo de zero para sin(x)/x", Unidade = "", ValorPadrao = 0.01, ValorMin = -1, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                if (Math.Abs(x) < 1e-10) return 1.0;
                return Math.Sin(x) / x;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 5: ÁLGEBRA LINEAR (4 fórmulas)
    // ========================================
    
    public static Formula V1_ALG_LIN001_DotProduct()
    {
        return new Formula
        {
            Id = "V1-ALG_LIN001",
            CodigoCompendio = "020",
            Nome = "Produto Escalar",
            Categoria = "Álgebra Linear",
            SubCategoria = "Operações com Vetores",
            Expressao = "u·v = |u||v|cos(θ)",
            ExprTexto = "Produto interno de vetores",
            Descricao = "Produto escalar de dois vetores u e v. Também pode ser calculado como soma dos produtos das componentes: u·v = u₁v₁ + u₂v₂ + u₃v₃.",
            Criador = "Hermann Grassmann",
            AnoOrigin = "1844",
            ExemploPratico = "Vetores u=(3,4) e v=(1,2): u·v = 3×1 + 4×2 = 11.",
            Unidades = "",
            VariavelResultado = "produto",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "u1", Nome = "Componente u₁", Descricao = "Primeira componente de u", Unidade = "", ValorPadrao = 3, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "u2", Nome = "Componente u₂", Descricao = "Segunda componente de u", Unidade = "", ValorPadrao = 4, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "v1", Nome = "Componente v₁", Descricao = "Primeira componente de v", Unidade = "", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "v2", Nome = "Componente v₂", Descricao = "Segunda componente de v", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double u1 = inputs["u1"];
                double u2 = inputs["u2"];
                double v1 = inputs["v1"];
                double v2 = inputs["v2"];
                return u1 * v1 + u2 * v2;
            }
        };
    }
    
    public static Formula V1_ALG_LIN002_Determinant2x2()
    {
        return new Formula
        {
            Id = "V1-ALG_LIN002",
            CodigoCompendio = "021",
            Nome = "Determinante 2×2",
            Categoria = "Álgebra Linear",
            SubCategoria = "Determinantes",
            Expressao = "det(A) = ad - bc",
            ExprTexto = "Determinante de matriz 2×2",
            Descricao = "Calcula o determinante de uma matriz 2×2: [[a,b],[c,d]]. Representa a área com sinal do paralelogramo formado pelas colunas.",
            Criador = "Gottfried Leibniz",
            AnoOrigin = "1693",
            ExemploPratico = "Para matriz [[3,1],[2,4]]: det = 3×4 - 1×2 = 10.",
            Unidades = "",
            VariavelResultado = "det",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Elemento a₁₁", Descricao = "Entrada (1,1)", Unidade = "", ValorPadrao = 3, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Elemento a₁₂", Descricao = "Entrada (1,2)", Unidade = "", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Elemento a₂₁", Descricao = "Entrada (2,1)", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Elemento a₂₂", Descricao = "Entrada (2,2)", Unidade = "", ValorPadrao = 4, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double c = inputs["c"];
                double d = inputs["d"];
                return a * d - b * c;
            }
        };
    }
    
    public static Formula V1_ALG_LIN003_MatrixMultiplication()
    {
        return new Formula
        {
            Id = "V1-ALG_LIN003",
            CodigoCompendio = "022",
            Nome = "Multiplicação de Matrizes",
            Categoria = "Álgebra Linear",
            SubCategoria = "Operações Matriciais",
            Expressao = "(AB)ᵢⱼ = Σₖ Aᵢₖ Bₖⱼ",
            ExprTexto = "Produto de matrizes",
            Descricao = "Multiplica matrizes A(m×n) e B(n×p) resultando em C(m×p). O elemento Cᵢⱼ é o produto escalar da i-ésima linha de A com a j-ésima coluna de B.",
            Criador = "Arthur Cayley",
            AnoOrigin = "1858",
            ExemploPratico = "[[1,2],[3,4]] × [[5,6],[7,8]] = [[19,22],[43,50]].",
            Unidades = "",
            VariavelResultado = "c11",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a11", Nome = "A₁₁", Descricao = "Elemento (1,1) de A", Unidade = "", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "a12", Nome = "A₁₂", Descricao = "Elemento (1,2) de A", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "b11", Nome = "B₁₁", Descricao = "Elemento (1,1) de B", Unidade = "", ValorPadrao = 5, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "b21", Nome = "B₂₁", Descricao = "Elemento (2,1) de B", Unidade = "", ValorPadrao = 7, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a11 = inputs["a11"];
                double a12 = inputs["a12"];
                double b11 = inputs["b11"];
                double b21 = inputs["b21"];
                return a11 * b11 + a12 * b21;
            }
        };
    }
    
    public static Formula V1_ALG_LIN004_EigenvalueSimple()
    {
        return new Formula
        {
            Id = "V1-ALG_LIN004",
            CodigoCompendio = "023",
            Nome = "Autovalor (Equação Característica)",
            Categoria = "Álgebra Linear",
            SubCategoria = "Autovalores e Autovetores",
            Expressao = "det(A - λI) = 0",
            ExprTexto = "Equação para autovalores",
            Descricao = "Para matriz 2×2, a equação característica é λ² - tr(A)λ + det(A) = 0, onde tr é o traço (soma diagonal) e det é o determinante.",
            Criador = "Augustin-Louis Cauchy",
            AnoOrigin = "1826",
            ExemploPratico = "Para A=[[3,1],[1,3]]: λ² - 6λ + 8 = 0, logo λ=4 ou λ=2.",
            Unidades = "",
            VariavelResultado = "lambda1",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Elemento a₁₁", Descricao = "Diagonal (1,1)", Unidade = "", ValorPadrao = 3, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Elemento a₁₂", Descricao = "Fora da diagonal", Unidade = "", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Elemento a₂₂", Descricao = "Diagonal (2,2)", Unidade = "", ValorPadrao = 3, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double b = inputs["b"];
                double d = inputs["d"];
                double trace = a + d;
                double det = a * d - b * b;
                double disc = trace * trace - 4 * det;
                if (disc < 0) return double.NaN;
                return (trace + Math.Sqrt(disc)) / 2;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 6: EQUAÇÕES DIFERENCIAIS (3 fórmulas)
    // ========================================
    
    public static Formula V1_EQD001_ExponentialGrowth()
    {
        return new Formula
        {
            Id = "V1-EQD001",
            CodigoCompendio = "024",
            Nome = "Crescimento Exponencial",
            Categoria = "Equações Diferenciais",
            SubCategoria = "EDOs de Primeira Ordem",
            Expressao = "N(t) = N₀ e^(rt)",
            ExprTexto = "Solução de dN/dt = rN",
            Descricao = "Modelo exponencial para crescimento ou decaimento. Solução da EDO linear de primeira ordem dN/dt = rN. Base para modelos populacionais e decaimento radioativo.",
            Criador = "Thomas Malthus",
            AnoOrigin = "1798",
            ExemploPratico = "População inicial N₀=1000, taxa r=0.05/ano, após t=10 anos: N=1000×e^0.5 ≈ 1649.",
            Unidades = "variável",
            VariavelResultado = "N",
            UnidadeResultado = "unidades",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "N0", Nome = "População inicial", Descricao = "Valor inicial N₀", Unidade = "unidades", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Taxa de crescimento", Descricao = "Taxa r (positiva=crescimento, negativa=decaimento)", Unidade = "1/tempo", ValorPadrao = 0.05, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo decorrido", Unidade = "tempo", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double N0 = inputs["N0"];
                double r = inputs["r"];
                double t = inputs["t"];
                return N0 * Math.Exp(r * t);
            }
        };
    }
    
    public static Formula V1_EQD002_LogisticEquation()
    {
        return new Formula
        {
            Id = "V1-EQD002",
            CodigoCompendio = "025",
            Nome = "Equação Logística",
            Categoria = "Equações Diferenciais",
            SubCategoria = "EDOs Não-Lineares",
            Expressao = "N(t) = K / (1 + (K/N₀-1)e^(-rt))",
            ExprTexto = "Crescimento com capacidade limite",
            Descricao = "Modelo de crescimento populacional com capacidade de carga K. Solução da EDO dN/dt = rN(1-N/K). Converge para K quando t→∞.",
            Criador = "Pierre François Verhulst",
            AnoOrigin = "1838",
            ExemploPratico = "N₀=100, r=0.1, K=1000, t=50: N ≈ 731. Cresce exponencialmente no início e satura próximo de K.",
            Unidades = "unidades",
            VariavelResultado = "N",
            UnidadeResultado = "unidades",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "N0", Nome = "População inicial", Descricao = "Valor inicial N₀", Unidade = "unidades", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Taxa de crescimento", Descricao = "Taxa intrínseca r", Unidade = "1/tempo", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "K", Nome = "Capacidade de carga", Descricao = "População máxima K", Unidade = "unidades", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo decorrido", Unidade = "tempo", ValorPadrao = 50, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double N0 = inputs["N0"];
                double r = inputs["r"];
                double K = inputs["K"];
                double t = inputs["t"];
                double ratio = K / N0 - 1;
                return K / (1 + ratio * Math.Exp(-r * t));
            }
        };
    }
    
    public static Formula V1_EQD003_HarmonicOscillator()
    {
        return new Formula
        {
            Id = "V1-EQD003",
            CodigoCompendio = "026",
            Nome = "Oscilador Harmônico Simples",
            Categoria = "Equações Diferenciais",
            SubCategoria = "EDOs de Segunda Ordem",
            Expressao = "x(t) = A cos(ωt + φ)",
            ExprTexto = "Solução de d²x/dt² + ω²x = 0",
            Descricao = "Movimento harmônico simples: oscilação senoidal com frequência angular ω. Solução da EDO linear de segunda ordem com coeficientes constantes.",
            Criador = "Christiaan Huygens",
            AnoOrigin = "1673",
            ExemploPratico = "Massa em mola com amplitude A=0.1m, frequência ω=2π rad/s, fase φ=0: x(1) = 0.1×cos(2π) = 0.1m.",
            Unidades = "m",
            VariavelResultado = "x",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "Amplitude", Descricao = "Amplitude de oscilação", Unidade = "m", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "omega", Nome = "Frequência angular", Descricao = "ω = 2πf", Unidade = "rad/s", ValorPadrao = 6.283, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "phi", Nome = "Fase", Descricao = "Fase inicial φ", Unidade = "rad", ValorPadrao = 0, ValorMin = -Math.PI, ValorMax = Math.PI, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo decorrido", Unidade = "s", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double omega = inputs["omega"];
                double phi = inputs["phi"];
                double t = inputs["t"];
                return A * Math.Cos(omega * t + phi);
            }
        };
    }
    
    // ========================================
    // CATEGORIA 7: PROBABILIDADE (4 fórmulas)
    // ========================================
    
    public static Formula V1_PROB001_ClassicalProbability()
    {
        return new Formula
        {
            Id = "V1-PROB001",
            CodigoCompendio = "027",
            Nome = "Probabilidade Clássica",
            Categoria = "Probabilidade",
            SubCategoria = "Definições Fundamentais",
            Expressao = "P(A) = número de casos favoráveis / número total de casos",
            ExprTexto = "Definição clássica de probabilidade",
            Descricao = "Probabilidade de um evento A em espaço amostral finito e equiprovável. Base da teoria de probabilidade de Laplace.",
            Criador = "Pierre-Simon Laplace",
            AnoOrigin = "1812",
            ExemploPratico = "Probabilidade de tirar um ás de baralho: P(ás) = 4/52 = 1/13 ≈ 0.077.",
            Unidades = "",
            VariavelResultado = "P",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "favoraveis", Nome = "Casos favoráveis", Descricao = "Número de resultados favoráveis", Unidade = "", ValorPadrao = 4, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "total", Nome = "Total de casos", Descricao = "Número total de resultados possíveis", Unidade = "", ValorPadrao = 52, ValorMin = 1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double favoraveis = inputs["favoraveis"];
                double total = inputs["total"];
                return favoraveis / total;
            }
        };
    }
    
    public static Formula V1_PROB002_BayesTheorem()
    {
        return new Formula
        {
            Id = "V1-PROB002",
            CodigoCompendio = "028",
            Nome = "Teorema de Bayes",
            Categoria = "Probabilidade",
            SubCategoria = "Probabilidade Condicional",
            Expressao = "P(A|B) = P(B|A) × P(A) / P(B)",
            ExprTexto = "Atualização de probabilidades",
            Descricao = "Relaciona probabilidades condicionais inversas. Fundamental para inferência bayesiana: atualiza crença em A dado evidência B.",
            Criador = "Thomas Bayes",
            AnoOrigin = "1763",
            ExemploPratico = "Teste com sensibilidade 0.95, especificidade 0.90, doença prevalência 0.01. P(doente|positivo) = 0.95×0.01/(0.95×0.01+0.10×0.99) ≈ 0.087.",
            Unidades = "",
            VariavelResultado = "P_A_dado_B",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P_B_dado_A", Nome = "P(B|A)", Descricao = "Probabilidade de B dado A", Unidade = "", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "P_A", Nome = "P(A)", Descricao = "Probabilidade a priori de A", Unidade = "", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "P_B", Nome = "P(B)", Descricao = "Probabilidade total de B", Unidade = "", ValorPadrao = 0.1085, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P_B_dado_A = inputs["P_B_dado_A"];
                double P_A = inputs["P_A"];
                double P_B = inputs["P_B"];
                if (P_B < 1e-10) return double.NaN;
                return (P_B_dado_A * P_A) / P_B;
            }
        };
    }
    
    public static Formula V1_PROB003_BinomialDistribution()
    {
        return new Formula
        {
            Id = "V1-PROB003",
            CodigoCompendio = "029",
            Nome = "Distribuição Binomial",
            Categoria = "Probabilidade",
            SubCategoria = "Distribuições Discretas",
            Expressao = "P(X=k) = C(n,k) × p^k × (1-p)^(n-k)",
            ExprTexto = "Probabilidade de k sucessos em n tentativas",
            Descricao = "Número de sucessos em n ensaios de Bernoulli independentes com probabilidade p. C(n,k) é o coeficiente binomial.",
            Criador = "Jakob Bernoulli",
            AnoOrigin = "1713",
            ExemploPratico = "Lançar moeda 10 vezes, probabilidade de 3 caras: P(X=3) = C(10,3) × 0.5³ × 0.5⁷ ≈ 0.117.",
            Unidades = "",
            VariavelResultado = "P_X_igual_k",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Número de tentativas", Descricao = "Total de ensaios", Unidade = "", ValorPadrao = 10, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Sucessos", Descricao = "Número de sucessos desejados", Unidade = "", ValorPadrao = 3, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "p", Nome = "Probabilidade de sucesso", Descricao = "Probabilidade em cada tentativa", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                int n = (int)inputs["n"];
                int k = (int)inputs["k"];
                double p = inputs["p"];
                
                double binomCoeff = 1;
                for (int i = 0; i < k; i++)
                {
                    binomCoeff *= (n - i) / (double)(i + 1);
                }
                
                return binomCoeff * Math.Pow(p, k) * Math.Pow(1 - p, n - k);
            }
        };
    }
    
    public static Formula V1_PROB004_PoissonDistribution()
    {
        return new Formula
        {
            Id = "V1-PROB004",
            CodigoCompendio = "030",
            Nome = "Distribuição de Poisson",
            Categoria = "Probabilidade",
            SubCategoria = "Distribuições Discretas",
            Expressao = "P(X=k) = (λ^k × e^(-λ)) / k!",
            ExprTexto = "Eventos raros em intervalo fixo",
            Descricao = "Número de eventos em intervalo de tempo/espaço quando ocorrem com taxa média λ. Limite da binomial quando n→∞ e p→0 com np=λ.",
            Criador = "Siméon Denis Poisson",
            AnoOrigin = "1837",
            ExemploPratico = "Chamadas telefônicas com média λ=3 por hora. P(5 chamadas) = 3⁵×e^(-3)/5! ≈ 0.101.",
            Unidades = "",
            VariavelResultado = "P_X_igual_k",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lambda", Nome = "Taxa média", Descricao = "Número médio de eventos λ", Unidade = "eventos", ValorPadrao = 3, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Número de eventos", Descricao = "Eventos observados", Unidade = "", ValorPadrao = 5, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lambda = inputs["lambda"];
                int k = (int)inputs["k"];
                
                double factorial = 1;
                for (int i = 2; i <= k; i++)
                {
                    factorial *= i;
                }
                
                return Math.Pow(lambda, k) * Math.Exp(-lambda) / factorial;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 8: ESTATÍSTICA (4 fórmulas)
    // ========================================
    
    public static Formula V1_STAT001_Mean()
    {
        return new Formula
        {
            Id = "V1-STAT001",
            CodigoCompendio = "031",
            Nome = "Média Aritmética",
            Categoria = "Estatística",
            SubCategoria = "Medidas de Tendência Central",
            Expressao = "μ = (Σ xᵢ) / n",
            ExprTexto = "Média de conjunto de dados",
            Descricao = "Soma de todos os valores dividida pelo número de observações. Medida central mais comum, sensível a outliers.",
            Criador = "Conceito antigo",
            AnoOrigin = "300 a.C.",
            ExemploPratico = "Valores [2, 4, 6, 8, 10]: média = (2+4+6+8+10)/5 = 30/5 = 6.",
            Unidades = "mesma dos dados",
            VariavelResultado = "media",
            UnidadeResultado = "unidades",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "soma", Nome = "Soma dos valores", Descricao = "Σ xᵢ", Unidade = "unidades", ValorPadrao = 30, ValorMin = -1e9, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Número de observações", Descricao = "Tamanho amostral", Unidade = "", ValorPadrao = 5, ValorMin = 1, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double soma = inputs["soma"];
                double n = inputs["n"];
                return soma / n;
            }
        };
    }
    
    public static Formula V1_STAT002_Variance()
    {
        return new Formula
        {
            Id = "V1-STAT002",
            CodigoCompendio = "032",
            Nome = "Variância",
            Categoria = "Estatística",
            SubCategoria = "Medidas de Dispersão",
            Expressao = "σ² = Σ(xᵢ - μ)² / n",
            ExprTexto = "Dispersão em torno da média",
            Descricao = "Média dos quadrados dos desvios em relação à média. Mede a variabilidade dos dados. Para amostra, divide-se por (n-1).",
            Criador = "Ronald Fisher",
            AnoOrigin = "1918",
            ExemploPratico = "Dados [2, 4, 6], média=4: var = [(2-4)²+(4-4)²+(6-4)²]/3 = [4+0+4]/3 = 2.67.",
            Unidades = "unidades²",
            VariavelResultado = "variancia",
            UnidadeResultado = "unidades²",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "soma_quad_desvios", Nome = "Σ(xᵢ-μ)²", Descricao = "Soma dos quadrados dos desvios", Unidade = "unidades²", ValorPadrao = 8, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Número de observações", Descricao = "Tamanho populacional", Unidade = "", ValorPadrao = 3, ValorMin = 1, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double soma_quad_desvios = inputs["soma_quad_desvios"];
                double n = inputs["n"];
                return soma_quad_desvios / n;
            }
        };
    }
    
    public static Formula V1_STAT003_StandardDeviation()
    {
        return new Formula
        {
            Id = "V1-STAT003",
            CodigoCompendio = "033",
            Nome = "Desvio Padrão",
            Categoria = "Estatística",
            SubCategoria = "Medidas de Dispersão",
            Expressao = "σ = √[Σ(xᵢ - μ)² / n]",
            ExprTexto = "Raiz quadrada da variância",
            Descricao = "Medida de dispersão na mesma unidade dos dados. σ pequeno indica dados concentrados, σ grande indica dados dispersos.",
            Criador = "Karl Pearson",
            AnoOrigin = "1894",
            ExemploPratico = "Variância σ²=4: desvio padrão σ = √4 = 2.",
            Unidades = "mesma dos dados",
            VariavelResultado = "desvio_padrao",
            UnidadeResultado = "unidades",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "variancia", Nome = "Variância", Descricao = "σ²", Unidade = "unidades²", ValorPadrao = 4, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double variancia = inputs["variancia"];
                return Math.Sqrt(variancia);
            }
        };
    }
    
    public static Formula V1_STAT004_CorrelationCoefficient()
    {
        return new Formula
        {
            Id = "V1-STAT004",
            CodigoCompendio = "034",
            Nome = "Coeficiente de Correlação de Pearson",
            Categoria = "Estatística",
            SubCategoria = "Relações entre Variáveis",
            Expressao = "r = Σ[(xᵢ-x̄)(yᵢ-ȳ)] / √[Σ(xᵢ-x̄)² Σ(yᵢ-ȳ)²]",
            ExprTexto = "Correlação linear entre X e Y",
            Descricao = "Mede a força e direção da relação linear entre duas variáveis. Varia de -1 (correlação negativa perfeita) a +1 (correlação positiva perfeita). r=0 indica ausência de relação linear.",
            Criador = "Karl Pearson",
            AnoOrigin = "1895",
            ExemploPratico = "Para covariância=20, σₓ=5, σᵧ=4: r = 20/(5×4) = 1.0 (correlação perfeita).",
            Unidades = "",
            VariavelResultado = "r",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "cov_xy", Nome = "Covariância", Descricao = "Cov(X,Y)", Unidade = "", ValorPadrao = 20, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "sigma_x", Nome = "Desvio padrão X", Descricao = "σₓ", Unidade = "", ValorPadrao = 5, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "sigma_y", Nome = "Desvio padrão Y", Descricao = "σᵧ", Unidade = "", ValorPadrao = 4, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double cov_xy = inputs["cov_xy"];
                double sigma_x = inputs["sigma_x"];
                double sigma_y = inputs["sigma_y"];
                double denom = sigma_x * sigma_y;
                if (Math.Abs(denom) < 1e-10) return double.NaN;
                return cov_xy / denom;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 9: MECÂNICA CLÁSSICA (5 fórmulas)
    // ========================================
    
    public static Formula V1_MEC001_NewtonSecondLaw()
    {
        return new Formula
        {
            Id = "V1-MEC001",
            CodigoCompendio = "035",
            Nome = "Segunda Lei de Newton",
            Categoria = "Mecânica Clássica",
            SubCategoria = "Leis do Movimento",
            Expressao = "F = ma",
            ExprTexto = "Força é massa vezes aceleração",
            Descricao = "A força resultante sobre um corpo é igual ao produto de sua massa pela aceleração. Princípio fundamental da dinâmica clássica.",
            Criador = "Isaac Newton",
            AnoOrigin = "1687",
            ExemploPratico = "Carro de massa m=1000kg com aceleração a=2m/s²: F = 1000×2 = 2000 N.",
            Unidades = "N",
            VariavelResultado = "F",
            UnidadeResultado = "N",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Massa", Descricao = "Massa do corpo", Unidade = "kg", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Aceleração", Descricao = "Aceleração resultante", Unidade = "m/s²", ValorPadrao = 2, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double a = inputs["a"];
                return m * a;
            }
        };
    }
    
    public static Formula V1_MEC002_KineticEnergy()
    {
        return new Formula
        {
            Id = "V1-MEC002",
            CodigoCompendio = "036",
            Nome = "Energia Cinética",
            Categoria = "Mecânica Clássica",
            SubCategoria = "Energia e Trabalho",
            Expressao = "Ec = ½mv²",
            ExprTexto = "Energia de movimento",
            Descricao = "Energia associada ao movimento de um corpo de massa m com velocidade v. Proporcional ao quadrado da velocidade.",
            Criador = "Gottfried Leibniz",
            AnoOrigin = "1686",
            ExemploPratico = "Carro de m=1000kg a v=20m/s: Ec = 0.5×1000×400 = 200,000 J = 200 kJ.",
            Unidades = "J",
            VariavelResultado = "Ec",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Massa", Descricao = "Massa do corpo", Unidade = "kg", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade do corpo", Unidade = "m/s", ValorPadrao = 20, ValorMin = 0, ValorMax = 3e8, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double v = inputs["v"];
                return 0.5 * m * v * v;
            }
        };
    }
    
    public static Formula V1_MEC003_PotentialEnergy()
    {
        return new Formula
        {
            Id = "V1-MEC003",
            CodigoCompendio = "037",
            Nome = "Energia Potencial Gravitacional",
            Categoria = "Mecânica Clássica",
            SubCategoria = "Energia e Trabalho",
            Expressao = "Ep = mgh",
            ExprTexto = "Energia de posição",
            Descricao = "Energia potencial gravitacional de um corpo de massa m a altura h. Referencial geralmente no solo (h=0).",
            Criador = "Isaac Newton",
            AnoOrigin = "1687",
            ExemploPratico = "Pedra de m=2kg a h=10m: Ep = 2×9.8×10 = 196 J.",
            Unidades = "J",
            VariavelResultado = "Ep",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Massa", Descricao = "Massa do corpo", Unidade = "kg", ValorPadrao = 2, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "Aceleração da gravidade", Unidade = "m/s²", ValorPadrao = 9.8, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Altura", Descricao = "Altura em relação ao referencial", Unidade = "m", ValorPadrao = 10, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double g = inputs["g"];
                double h = inputs["h"];
                return m * g * h;
            }
        };
    }
    
    public static Formula V1_MEC004_Momentum()
    {
        return new Formula
        {
            Id = "V1-MEC004",
            CodigoCompendio = "038",
            Nome = "Quantidade de Movimento",
            Categoria = "Mecânica Clássica",
            SubCategoria = "Momento Linear",
            Expressao = "p = mv",
            ExprTexto = "Momento linear",
            Descricao = "Quantidade de movimento (momento linear) de um corpo. Grandeza vetorial conservada em sistemas isolados.",
            Criador = "Isaac Newton",
            AnoOrigin = "1687",
            ExemploPratico = "Bola de m=0.5kg com v=10m/s: p = 0.5×10 = 5 kg·m/s.",
            Unidades = "kg·m/s",
            VariavelResultado = "p",
            UnidadeResultado = "kg·m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Massa", Descricao = "Massa do corpo", Unidade = "kg", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade do corpo", Unidade = "m/s", ValorPadrao = 10, ValorMin = -3e8, ValorMax = 3e8, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double v = inputs["v"];
                return m * v;
            }
        };
    }
    
    public static Formula V1_MEC005_UniversalGravitation()
    {
        return new Formula
        {
            Id = "V1-MEC005",
            CodigoCompendio = "039",
            Nome = "Lei da Gravitação Universal",
            Categoria = "Mecânica Clássica",
            SubCategoria = "Gravitação",
            Expressao = "F = G(m₁m₂)/r²",
            ExprTexto = "Força gravitacional entre massas",
            Descricao = "Força de atração gravitacional entre duas massas m₁ e m₂ separadas por distância r. G=6.674×10⁻¹¹ N·m²/kg² é a constante gravitacional.",
            Criador = "Isaac Newton",
            AnoOrigin = "1687",
            ExemploPratico = "Terra (6×10²⁴kg) e Lua (7×10²²kg) a r=384,000km: F ≈ 2×10²⁰ N.",
            Unidades = "N",
            VariavelResultado = "F",
            UnidadeResultado = "N",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "G", Nome = "Constante gravitacional", Descricao = "G = 6.674×10⁻¹¹", Unidade = "N·m²/kg²", ValorPadrao = 6.674e-11, ValorMin = 0, ValorMax = 1e-9, Obrigatoria = true },
                new() { Simbolo = "m1", Nome = "Massa 1", Descricao = "Primeira massa", Unidade = "kg", ValorPadrao = 6e24, ValorMin = 0, ValorMax = 1e30, Obrigatoria = true },
                new() { Simbolo = "m2", Nome = "Massa 2", Descricao = "Segunda massa", Unidade = "kg", ValorPadrao = 7e22, ValorMin = 0, ValorMax = 1e30, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Distância", Descricao = "Distância entre centros", Unidade = "m", ValorPadrao = 3.84e8, ValorMin = 1, ValorMax = 1e15, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double G = inputs["G"];
                double m1 = inputs["m1"];
                double m2 = inputs["m2"];
                double r = inputs["r"];
                return G * m1 * m2 / (r * r);
            }
        };
    }
    
    // ========================================
    // CATEGORIA 10: TERMODINÂMICA (4 fórmulas)
    // ========================================
    
    public static Formula V1_TERMO001_IdealGasLaw()
    {
        return new Formula
        {
            Id = "V1-TERMO001",
            CodigoCompendio = "040",
            Nome = "Lei dos Gases Ideais",
            Categoria = "Termodinâmica",
            SubCategoria = "Gases",
            Expressao = "PV = nRT",
            ExprTexto = "Equação de estado de gás ideal",
            Descricao = "Relaciona pressão P, volume V, quantidade n (mols) e temperatura T de um gás ideal. R=8.314 J/(mol·K) é a constante universal dos gases.",
            Criador = "Émile Clapeyron",
            AnoOrigin = "1834",
            ExemploPratico = "n=1 mol, T=300K, R=8.314: PV = 2494.2 Pa·m³. Se V=0.024m³, então P=103,925 Pa ≈ 1 atm.",
            Unidades = "Pa·m³",
            VariavelResultado = "PV",
            UnidadeResultado = "Pa·m³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Quantidade", Descricao = "Número de mols", Unidade = "mol", ValorPadrao = 1, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Constante dos gases", Descricao = "R = 8.314 J/(mol·K)", Unidade = "J/(mol·K)", ValorPadrao = 8.314, ValorMin = 8.3, ValorMax = 8.4, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura absoluta", Unidade = "K", ValorPadrao = 300, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double R = inputs["R"];
                double T = inputs["T"];
                return n * R * T;
            }
        };
    }
    
    public static Formula V1_TERMO002_FirstLaw()
    {
        return new Formula
        {
            Id = "V1-TERMO002",
            CodigoCompendio = "041",
            Nome = "Primeira Lei da Termodinâmica",
            Categoria = "Termodinâmica",
            SubCategoria = "Leis Fundamentais",
            Expressao = "ΔU = Q - W",
            ExprTexto = "Conservação de energia",
            Descricao = "Variação da energia interna ΔU é igual ao calor Q recebido menos o trabalho W realizado pelo sistema. Princípio de conservação de energia.",
            Criador = "Rudolf Clausius",
            AnoOrigin = "1850",
            ExemploPratico = "Sistema recebe Q=100J e realiza W=30J: ΔU = 100 - 30 = 70 J (aumenta energia interna).",
            Unidades = "J",
            VariavelResultado = "delta_U",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Q", Nome = "Calor", Descricao = "Calor recebido (positivo) ou cedido (negativo)", Unidade = "J", ValorPadrao = 100, ValorMin = -1e9, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "W", Nome = "Trabalho", Descricao = "Trabalho realizado pelo sistema", Unidade = "J", ValorPadrao = 30, ValorMin = -1e9, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Q = inputs["Q"];
                double W = inputs["W"];
                return Q - W;
            }
        };
    }
    
    public static Formula V1_TERMO003_HeatTransfer()
    {
        return new Formula
        {
            Id = "V1-TERMO003",
            CodigoCompendio = "042",
            Nome = "Calor Específico",
            Categoria = "Termodinâmica",
            SubCategoria = "Transferência de Calor",
            Expressao = "Q = mcΔT",
            ExprTexto = "Calor para variar temperatura",
            Descricao = "Calor Q necessário para variar a temperatura de massa m em ΔT. c é o calor específico (J/(kg·K)), propriedade do material.",
            Criador = "Joseph Black",
            AnoOrigin = "1760",
            ExemploPratico = "Aquecer m=2kg de água (c=4186 J/(kg·K)) em ΔT=10K: Q = 2×4186×10 = 83,720 J ≈ 84 kJ.",
            Unidades = "J",
            VariavelResultado = "Q",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Massa", Descricao = "Massa do material", Unidade = "kg", ValorPadrao = 2, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Calor específico", Descricao = "Capacidade térmica específica", Unidade = "J/(kg·K)", ValorPadrao = 4186, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "delta_T", Nome = "Variação de temperatura", Descricao = "ΔT = T_final - T_inicial", Unidade = "K", ValorPadrao = 10, ValorMin = -1000, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double c = inputs["c"];
                double delta_T = inputs["delta_T"];
                return m * c * delta_T;
            }
        };
    }
    
    public static Formula V1_TERMO004_CarnotEfficiency()
    {
        return new Formula
        {
            Id = "V1-TERMO004",
            CodigoCompendio = "043",
            Nome = "Eficiência de Carnot",
            Categoria = "Termodinâmica",
            SubCategoria = "Máquinas Térmicas",
            Expressao = "η = 1 - Tc/Th",
            ExprTexto = "Eficiência máxima teórica",
            Descricao = "Eficiência máxima de uma máquina térmica operando entre reservatórios a temperaturas Th (quente) e Tc (frio). Limite termodinâmico fundamental.",
            Criador = "Sadi Carnot",
            AnoOrigin = "1824",
            ExemploPratico = "Th=500K, Tc=300K: η = 1 - 300/500 = 0.4 = 40% de eficiência máxima.",
            Unidades = "",
            VariavelResultado = "eta",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Tc", Nome = "Temperatura fria", Descricao = "Temperatura do reservatório frio", Unidade = "K", ValorPadrao = 300, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "Th", Nome = "Temperatura quente", Descricao = "Temperatura do reservatório quente", Unidade = "K", ValorPadrao = 500, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Tc = inputs["Tc"];
                double Th = inputs["Th"];
                if (Th < 1e-10) return double.NaN;
                return 1 - Tc / Th;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 11: ELETROMAGNETISMO (4 fórmulas)
    // ========================================
    
    public static Formula V1_ELETRO001_CoulombsLaw()
    {
        return new Formula
        {
            Id = "V1-ELETRO001",
            CodigoCompendio = "044",
            Nome = "Lei de Coulomb",
            Categoria = "Eletromagnetismo",
            SubCategoria = "Eletrostática",
            Expressao = "F = k(q₁q₂)/r²",
            ExprTexto = "Força entre cargas elétricas",
            Descricao = "Força eletrostática entre duas cargas q₁ e q₂ separadas por distância r. k=8.99×10⁹ N·m²/C² é a constante de Coulomb.",
            Criador = "Charles-Augustin de Coulomb",
            AnoOrigin = "1785",
            ExemploPratico = "Duas cargas q₁=q₂=1μC a r=0.1m: F = 8.99×10⁹×10⁻¹²/0.01 = 0.899 N (repulsiva).",
            Unidades = "N",
            VariavelResultado = "F",
            UnidadeResultado = "N",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Constante de Coulomb", Descricao = "k = 8.99×10⁹ N·m²/C²", Unidade = "N·m²/C²", ValorPadrao = 8.99e9, ValorMin = 8e9, ValorMax = 9e9, Obrigatoria = true },
                new() { Simbolo = "q1", Nome = "Carga 1", Descricao = "Primeira carga elétrica", Unidade = "C", ValorPadrao = 1e-6, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "q2", Nome = "Carga 2", Descricao = "Segunda carga elétrica", Unidade = "C", ValorPadrao = 1e-6, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Distância", Descricao = "Distância entre cargas", Unidade = "m", ValorPadrao = 0.1, ValorMin = 1e-15, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double q1 = inputs["q1"];
                double q2 = inputs["q2"];
                double r = inputs["r"];
                return k * q1 * q2 / (r * r);
            }
        };
    }
    
    public static Formula V1_ELETRO002_OhmsLaw()
    {
        return new Formula
        {
            Id = "V1-ELETRO002",
            CodigoCompendio = "045",
            Nome = "Lei de Ohm",
            Categoria = "Eletromagnetismo",
            SubCategoria = "Circuitos Elétricos",
            Expressao = "V = RI",
            ExprTexto = "Relação tensão-corrente-resistência",
            Descricao = "Tensão V em um condutor ôhmico é proporcional à corrente I, sendo R a resistência. Fundamental para análise de circuitos elétricos.",
            Criador = "Georg Simon Ohm",
            AnoOrigin = "1827",
            ExemploPratico = "Resistor R=100Ω com corrente I=0.5A: V = 100×0.5 = 50 V.",
            Unidades = "V",
            VariavelResultado = "V",
            UnidadeResultado = "V",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "R", Nome = "Resistência", Descricao = "Resistência elétrica", Unidade = "Ω", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente", Descricao = "Corrente elétrica", Unidade = "A", ValorPadrao = 0.5, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double R = inputs["R"];
                double I = inputs["I"];
                return R * I;
            }
        };
    }
    
    public static Formula V1_ELETRO003_ElectricPower()
    {
        return new Formula
        {
            Id = "V1-ELETRO003",
            CodigoCompendio = "046",
            Nome = "Potência Elétrica",
            Categoria = "Eletromagnetismo",
            SubCategoria = "Circuitos Elétricos",
            Expressao = "P = VI",
            ExprTexto = "Potência dissipada ou fornecida",
            Descricao = "Potência elétrica é o produto da tensão V pela corrente I. Também pode ser expressa como P=RI² ou P=V²/R usando a Lei de Ohm.",
            Criador = "James Prescott Joule",
            AnoOrigin = "1840",
            ExemploPratico = "Lâmpada com V=120V e I=0.5A: P = 120×0.5 = 60 W.",
            Unidades = "W",
            VariavelResultado = "P",
            UnidadeResultado = "W",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "V", Nome = "Tensão", Descricao = "Tensão elétrica", Unidade = "V", ValorPadrao = 120, ValorMin = -1e9, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente", Descricao = "Corrente elétrica", Unidade = "A", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double V = inputs["V"];
                double I = inputs["I"];
                return V * I;
            }
        };
    }
    
    public static Formula V1_ELETRO004_MagneticForce()
    {
        return new Formula
        {
            Id = "V1-ELETRO004",
            CodigoCompendio = "047",
            Nome = "Força Magnética em Carga",
            Categoria = "Eletromagnetismo",
            SubCategoria = "Magnetismo",
            Expressao = "F = qvB sin(θ)",
            ExprTexto = "Força de Lorentz (componente magnética)",
            Descricao = "Força magnética sobre carga q movendo-se com velocidade v em campo magnético B. Máxima quando v⊥B (θ=90°), nula quando v∥B (θ=0°).",
            Criador = "Hendrik Lorentz",
            AnoOrigin = "1895",
            ExemploPratico = "Elétron (q=1.6×10⁻¹⁹C) a v=10⁶m/s perpendicular a B=0.1T: F = 1.6×10⁻¹⁴ N.",
            Unidades = "N",
            VariavelResultado = "F",
            UnidadeResultado = "N",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "q", Nome = "Carga", Descricao = "Carga elétrica", Unidade = "C", ValorPadrao = 1.6e-19, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade da carga", Unidade = "m/s", ValorPadrao = 1e6, ValorMin = 0, ValorMax = 3e8, Obrigatoria = true },
                new() { Simbolo = "B", Nome = "Campo magnético", Descricao = "Intensidade do campo B", Unidade = "T", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "theta", Nome = "Ângulo", Descricao = "Ângulo entre v e B", Unidade = "graus", ValorPadrao = 90, ValorMin = 0, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double q = inputs["q"];
                double v = inputs["v"];
                double B = inputs["B"];
                double theta = inputs["theta"] * Math.PI / 180;
                return q * v * B * Math.Sin(theta);
            }
        };
    }
    
    // ========================================
    // CATEGORIA 12: ÓPTICA (4 fórmulas)
    // ========================================
    
    public static Formula V1_OPTICA001_SnellsLaw()
    {
        return new Formula
        {
            Id = "V1-OPTICA001",
            CodigoCompendio = "048",
            Nome = "Lei de Snell",
            Categoria = "Óptica",
            SubCategoria = "Refração",
            Expressao = "n₁ sin(θ₁) = n₂ sin(θ₂)",
            ExprTexto = "Refração da luz",
            Descricao = "Relaciona ângulos de incidência θ₁ e refração θ₂ quando luz passa entre meios com índices de refração n₁ e n₂.",
            Criador = "Willebrord Snellius",
            AnoOrigin = "1621",
            ExemploPratico = "Luz do ar (n₁=1) para água (n₂=1.33) a θ₁=45°: sin(θ₂) = sin(45°)/1.33 ≈ 0.531, θ₂ ≈ 32°.",
            Unidades = "",
            VariavelResultado = "theta2",
            UnidadeResultado = "graus",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n1", Nome = "Índice n₁", Descricao = "Índice de refração do meio 1", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 3, Obrigatoria = true },
                new() { Simbolo = "theta1", Nome = "Ângulo θ₁", Descricao = "Ângulo de incidência", Unidade = "graus", ValorPadrao = 45, ValorMin = 0, ValorMax = 90, Obrigatoria = true },
                new() { Simbolo = "n2", Nome = "Índice n₂", Descricao = "Índice de refração do meio 2", Unidade = "", ValorPadrao = 1.33, ValorMin = 1, ValorMax = 3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n1 = inputs["n1"];
                double theta1 = inputs["theta1"] * Math.PI / 180;
                double n2 = inputs["n2"];
                double sinTheta2 = (n1 / n2) * Math.Sin(theta1);
                if (sinTheta2 > 1) return double.NaN; // Reflexão total interna
                return Math.Asin(sinTheta2) * 180 / Math.PI;
            }
        };
    }
    
    public static Formula V1_OPTICA002_ThinLensEquation()
    {
        return new Formula
        {
            Id = "V1-OPTICA002",
            CodigoCompendio = "049",
            Nome = "Equação de Lentes Delgadas",
            Categoria = "Óptica",
            SubCategoria = "Lentes e Espelhos",
            Expressao = "1/f = 1/do + 1/di",
            ExprTexto = "Relação objeto-imagem-foco",
            Descricao = "Relaciona distância focal f, distância do objeto do e distância da imagem di. Válida para lentes e espelhos esféricos delgados.",
            Criador = "Isaac Barrow",
            AnoOrigin = "1669",
            ExemploPratico = "Lente f=10cm, objeto a do=30cm: 1/10 = 1/30 + 1/di → di = 15cm (imagem real).",
            Unidades = "cm",
            VariavelResultado = "di",
            UnidadeResultado = "cm",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f", Nome = "Distância focal", Descricao = "Foco da lente", Unidade = "cm", ValorPadrao = 10, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "do", Nome = "Distância do objeto", Descricao = "Distância objeto-lente", Unidade = "cm", ValorPadrao = 30, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f = inputs["f"];
                double do_obj = inputs["do"];
                if (Math.Abs(do_obj) < 1e-10) return double.PositiveInfinity;
                double one_over_di = 1 / f - 1 / do_obj;
                if (Math.Abs(one_over_di) < 1e-10) return double.PositiveInfinity;
                return 1 / one_over_di;
            }
        };
    }
    
    public static Formula V1_OPTICA003_Magnification()
    {
        return new Formula
        {
            Id = "V1-OPTICA003",
            CodigoCompendio = "050",
            Nome = "Ampliação Linear",
            Categoria = "Óptica",
            SubCategoria = "Lentes e Espelhos",
            Expressao = "M = -di/do = hi/ho",
            ExprTexto = "Razão de tamanhos imagem/objeto",
            Descricao = "Ampliação linear transversal. M>0 imagem direita, M<0 imagem invertida. |M|>1 ampliada, |M|<1 reduzida.",
            Criador = "Conceito clássico",
            AnoOrigin = "1600",
            ExemploPratico = "Objeto a do=20cm, imagem a di=40cm: M = -40/20 = -2 (invertida e 2× maior).",
            Unidades = "",
            VariavelResultado = "M",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "di", Nome = "Distância da imagem", Descricao = "Distância imagem-lente", Unidade = "cm", ValorPadrao = 40, ValorMin = -1e6, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "do", Nome = "Distância do objeto", Descricao = "Distância objeto-lente", Unidade = "cm", ValorPadrao = 20, ValorMin = 1e-10, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double di = inputs["di"];
                double do_obj = inputs["do"];
                if (Math.Abs(do_obj) < 1e-10) return double.PositiveInfinity;
                return -di / do_obj;
            }
        };
    }
    
    public static Formula V1_OPTICA004_DiffractionGrating()
    {
        return new Formula
        {
            Id = "V1-OPTICA004",
            CodigoCompendio = "051",
            Nome = "Rede de Difração",
            Categoria = "Óptica",
            SubCategoria = "Difração e Interferência",
            Expressao = "d sin(θ) = mλ",
            ExprTexto = "Máximos de interferência",
            Descricao = "Condição para máximos de interferência construtiva em rede de difração. d é o espaçamento entre fendas, m é a ordem (0,±1,±2,...), λ é o comprimento de onda.",
            Criador = "Joseph von Fraunhofer",
            AnoOrigin = "1821",
            ExemploPratico = "Luz λ=500nm, rede d=2μm, 1ª ordem (m=1): sin(θ) = 500×10⁻⁹/(2×10⁻⁶) = 0.25, θ ≈ 14.5°.",
            Unidades = "",
            VariavelResultado = "theta",
            UnidadeResultado = "graus",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "d", Nome = "Espaçamento", Descricao = "Distância entre fendas", Unidade = "m", ValorPadrao = 2e-6, ValorMin = 1e-9, ValorMax = 1e-3, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "Ordem", Descricao = "Ordem do máximo (inteiro)", Unidade = "", ValorPadrao = 1, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "lambda", Nome = "Comprimento de onda", Descricao = "λ da luz", Unidade = "m", ValorPadrao = 500e-9, ValorMin = 1e-9, ValorMax = 1e-3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double d = inputs["d"];
                double m = inputs["m"];
                double lambda = inputs["lambda"];
                double sinTheta = m * lambda / d;
                if (Math.Abs(sinTheta) > 1) return double.NaN;
                return Math.Asin(sinTheta) * 180 / Math.PI;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 13: MECÂNICA DOS FLUIDOS (4 fórmulas)
    // ========================================
    
    public static Formula V1_FLUIDO001_BernoulliEquation()
    {
        return new Formula
        {
            Id = "V1-FLUIDO001",
            CodigoCompendio = "052",
            Nome = "Equação de Bernoulli",
            Categoria = "Mecânica dos Fluidos",
            SubCategoria = "Dinâmica de Fluidos",
            Expressao = "P + ½ρv² + ρgh = constante",
            ExprTexto = "Conservação de energia em fluido",
            Descricao = "Ao longo de uma linha de corrente, a soma das pressão P, energia cinética por volume (½ρv²) e energia potencial por volume (ρgh) é constante.",
            Criador = "Daniel Bernoulli",
            AnoOrigin = "1738",
            ExemploPratico = "Água (ρ=1000kg/m³) a v=5m/s, h=2m, P=101,325Pa: Total = 101,325 + 12,500 + 19,600 = 133,425 Pa.",
            Unidades = "Pa",
            VariavelResultado = "total",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P", Nome = "Pressão", Descricao = "Pressão estática", Unidade = "Pa", ValorPadrao = 101325, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade do fluido ρ", Unidade = "kg/m³", ValorPadrao = 1000, ValorMin = 0, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade de escoamento", Unidade = "m/s", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "Aceleração g", Unidade = "m/s²", ValorPadrao = 9.8, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Altura", Descricao = "Altura em relação ao referencial", Unidade = "m", ValorPadrao = 2, ValorMin = -1000, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P = inputs["P"];
                double rho = inputs["rho"];
                double v = inputs["v"];
                double g = inputs["g"];
                double h = inputs["h"];
                return P + 0.5 * rho * v * v + rho * g * h;
            }
        };
    }
    
    public static Formula V1_FLUIDO002_ContinuityEquation()
    {
        return new Formula
        {
            Id = "V1-FLUIDO002",
            CodigoCompendio = "053",
            Nome = "Equação da Continuidade",
            Categoria = "Mecânica dos Fluidos",
            SubCategoria = "Conservação de Massa",
            Expressao = "A₁v₁ = A₂v₂",
            ExprTexto = "Vazão constante em tubo",
            Descricao = "Em escoamento incompressível, o produto da área da seção transversal A pela velocidade v é constante (vazão volumétrica Q=Av).",
            Criador = "Leonhard Euler",
            AnoOrigin = "1757",
            ExemploPratico = "Tubo de A₁=10cm² a v₁=2m/s entra em seção A₂=5cm²: v₂ = A₁v₁/A₂ = 10×2/5 = 4 m/s.",
            Unidades = "m/s",
            VariavelResultado = "v2",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A1", Nome = "Área 1", Descricao = "Área da seção 1", Unidade = "m²", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "v1", Nome = "Velocidade 1", Descricao = "Velocidade na seção 1", Unidade = "m/s", ValorPadrao = 2, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "A2", Nome = "Área 2", Descricao = "Área da seção 2", Unidade = "m²", ValorPadrao = 0.0005, ValorMin = 1e-10, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A1 = inputs["A1"];
                double v1 = inputs["v1"];
                double A2 = inputs["A2"];
                if (Math.Abs(A2) < 1e-10) return double.PositiveInfinity;
                return A1 * v1 / A2;
            }
        };
    }
    
    public static Formula V1_FLUIDO003_ReynoldsNumber()
    {
        return new Formula
        {
            Id = "V1-FLUIDO003",
            CodigoCompendio = "054",
            Nome = "Número de Reynolds",
            Categoria = "Mecânica dos Fluidos",
            SubCategoria = "Adimensionais",
            Expressao = "Re = ρvL/μ",
            ExprTexto = "Razão forças inerciais/viscosas",
            Descricao = "Número adimensional que caracteriza o regime de escoamento. Re<2300 laminar, 2300<Re<4000 transição, Re>4000 turbulento (em tubos).",
            Criador = "Osborne Reynolds",
            AnoOrigin = "1883",
            ExemploPratico = "Água (ρ=1000, μ=0.001Pa·s) a v=1m/s em tubo D=0.05m: Re = 1000×1×0.05/0.001 = 50,000 (turbulento).",
            Unidades = "",
            VariavelResultado = "Re",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade ρ", Unidade = "kg/m³", ValorPadrao = 1000, ValorMin = 0, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade característica", Unidade = "m/s", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento característico (ex: diâmetro)", Unidade = "m", ValorPadrao = 0.05, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "mu", Nome = "Viscosidade", Descricao = "Viscosidade dinâmica μ", Unidade = "Pa·s", ValorPadrao = 0.001, ValorMin = 1e-10, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double rho = inputs["rho"];
                double v = inputs["v"];
                double L = inputs["L"];
                double mu = inputs["mu"];
                if (Math.Abs(mu) < 1e-10) return double.PositiveInfinity;
                return rho * v * L / mu;
            }
        };
    }
    
    public static Formula V1_FLUIDO004_PressureDepth()
    {
        return new Formula
        {
            Id = "V1-FLUIDO004",
            CodigoCompendio = "055",
            Nome = "Pressão Hidrostática",
            Categoria = "Mecânica dos Fluidos",
            SubCategoria = "Hidrostática",
            Expressao = "P = P₀ + ρgh",
            ExprTexto = "Pressão em profundidade",
            Descricao = "Pressão a profundidade h em fluido de densidade ρ. P₀ é a pressão na superfície (geralmente atmosférica).",
            Criador = "Blaise Pascal",
            AnoOrigin = "1648",
            ExemploPratico = "Água a h=10m (P₀=101,325Pa, ρ=1000kg/m³): P = 101,325 + 1000×9.8×10 = 199,325 Pa ≈ 2 atm.",
            Unidades = "Pa",
            VariavelResultado = "P",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P0", Nome = "Pressão superfície", Descricao = "Pressão na superfície P₀", Unidade = "Pa", ValorPadrao = 101325, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade do fluido ρ", Unidade = "kg/m³", ValorPadrao = 1000, ValorMin = 0, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "Aceleração g", Unidade = "m/s²", ValorPadrao = 9.8, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Profundidade", Descricao = "Profundidade h", Unidade = "m", ValorPadrao = 10, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P0 = inputs["P0"];
                double rho = inputs["rho"];
                double g = inputs["g"];
                double h = inputs["h"];
                return P0 + rho * g * h;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 14: ENGENHARIA (4 fórmulas)
    // ========================================
    
    public static Formula V1_ENG001_HookesLaw()
    {
        return new Formula
        {
            Id = "V1-ENG001",
            CodigoCompendio = "056",
            Nome = "Lei de Hooke",
            Categoria = "Engenharia",
            SubCategoria = "Mecânica dos Materiais",
            Expressao = "F = -kx",
            ExprTexto = "Força restauradora elástica",
            Descricao = "Força restauradora em mola ou material elástico é proporcional à deformação x. k é a constante elástica (rigidez). Sinal negativo indica oposição à deformação.",
            Criador = "Robert Hooke",
            AnoOrigin = "1660",
            ExemploPratico = "Mola k=100N/m esticada x=0.2m: F = -100×0.2 = -20 N (força restauradora de 20N).",
            Unidades = "N",
            VariavelResultado = "F",
            UnidadeResultado = "N",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Constante elástica", Descricao = "Rigidez da mola", Unidade = "N/m", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "x", Nome = "Deformação", Descricao = "Alongamento ou compressão", Unidade = "m", ValorPadrao = 0.2, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double x = inputs["x"];
                return -k * x;
            }
        };
    }
    
    public static Formula V1_ENG002_StressStrain()
    {
        return new Formula
        {
            Id = "V1-ENG002",
            CodigoCompendio = "057",
            Nome = "Tensão e Deformação",
            Categoria = "Engenharia",
            SubCategoria = "Mecânica dos Materiais",
            Expressao = "σ = Eε",
            ExprTexto = "Lei de Hooke para materiais",
            Descricao = "Tensão σ (força/área) é proporcional à deformação ε (variação/comprimento) no regime elástico. E é o módulo de Young (elasticidade).",
            Criador = "Thomas Young",
            AnoOrigin = "1807",
            ExemploPratico = "Aço (E=200GPa) com deformação ε=0.001: σ = 200×10⁹×0.001 = 200 MPa.",
            Unidades = "Pa",
            VariavelResultado = "sigma",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E", Nome = "Módulo de Young", Descricao = "Módulo de elasticidade", Unidade = "Pa", ValorPadrao = 200e9, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "epsilon", Nome = "Deformação", Descricao = "Deformação relativa ε", Unidade = "", ValorPadrao = 0.001, ValorMin = -1, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E = inputs["E"];
                double epsilon = inputs["epsilon"];
                return E * epsilon;
            }
        };
    }
    
    public static Formula V1_ENG003_BeamBending()
    {
        return new Formula
        {
            Id = "V1-ENG003",
            CodigoCompendio = "058",
            Nome = "Deflexão de Viga",
            Categoria = "Engenharia",
            SubCategoria = "Estruturas",
            Expressao = "δ = (FL³) / (3EI)",
            ExprTexto = "Deflexão máxima de viga engastada",
            Descricao = "Deflexão δ no extremo livre de viga engastada com carga concentrada F. L é o comprimento, E módulo de Young, I momento de inércia da seção.",
            Criador = "Leonhard Euler",
            AnoOrigin = "1750",
            ExemploPratico = "Viga L=2m, F=1000N, E=200GPa, I=1×10⁻⁶m⁴: δ = 1000×8/(3×200×10⁹×10⁻⁶) = 0.0133m = 13.3mm.",
            Unidades = "m",
            VariavelResultado = "delta",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "F", Nome = "Força", Descricao = "Carga aplicada", Unidade = "N", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento da viga", Unidade = "m", ValorPadrao = 2, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "E", Nome = "Módulo de Young", Descricao = "Módulo de elasticidade", Unidade = "Pa", ValorPadrao = 200e9, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Momento de inércia", Descricao = "Momento de área I", Unidade = "m⁴", ValorPadrao = 1e-6, ValorMin = 1e-12, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double F = inputs["F"];
                double L = inputs["L"];
                double E = inputs["E"];
                double I = inputs["I"];
                if (Math.Abs(E * I) < 1e-100) return double.PositiveInfinity;
                return (F * Math.Pow(L, 3)) / (3 * E * I);
            }
        };
    }
    
    public static Formula V1_ENG004_KirchhoffVoltage()
    {
        return new Formula
        {
            Id = "V1-ENG004",
            CodigoCompendio = "059",
            Nome = "Lei de Kirchhoff das Tensões",
            Categoria = "Engenharia",
            SubCategoria = "Circuitos Elétricos",
            Expressao = "Σ V = 0",
            ExprTexto = "Soma de tensões em malha",
            Descricao = "Em qualquer malha fechada de um circuito, a soma algébrica das tensões é zero. Consequência da conservação de energia.",
            Criador = "Gustav Kirchhoff",
            AnoOrigin = "1845",
            ExemploPratico = "Malha com fonte V₁=12V e resistores com quedas V₂=5V, V₃=7V: 12 - 5 - 7 = 0.",
            Unidades = "V",
            VariavelResultado = "soma",
            UnidadeResultado = "V",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "V1", Nome = "Tensão 1", Descricao = "Primeira tensão (fonte positiva)", Unidade = "V", ValorPadrao = 12, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "V2", Nome = "Tensão 2", Descricao = "Segunda tensão (queda)", Unidade = "V", ValorPadrao = 5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "V3", Nome = "Tensão 3", Descricao = "Terceira tensão (queda)", Unidade = "V", ValorPadrao = 7, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double V1 = inputs["V1"];
                double V2 = inputs["V2"];
                double V3 = inputs["V3"];
                return V1 - V2 - V3;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 15: BIOLOGIA MATEMÁTICA (3 fórmulas)
    // ========================================
    
    public static Formula V1_BIO001_ExponentialGrowthBio()
    {
        return new Formula
        {
            Id = "V1-BIO001",
            CodigoCompendio = "060",
            Nome = "Modelo Malthusiano",
            Categoria = "Biologia Matemática",
            SubCategoria = "Dinâmica Populacional",
            Expressao = "N(t) = N₀ e^(rt)",
            ExprTexto = "Crescimento exponencial",
            Descricao = "População cresce exponencialmente com taxa r constante. Modelo simples sem limitação de recursos.",
            Criador = "Thomas Malthus",
            AnoOrigin = "1798",
            ExemploPratico = "Bactérias N₀=100, r=0.3/h, após t=5h: N = 100×e^1.5 ≈ 448.",
            Unidades = "indivíduos",
            VariavelResultado = "N",
            UnidadeResultado = "indivíduos",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "N0", Nome = "População inicial", Descricao = "N₀", Unidade = "indivíduos", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Taxa de crescimento", Descricao = "Taxa per capita r", Unidade = "1/tempo", ValorPadrao = 0.3, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo decorrido", Unidade = "tempo", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double N0 = inputs["N0"];
                double r = inputs["r"];
                double t = inputs["t"];
                return N0 * Math.Exp(r * t);
            }
        };
    }
    
    public static Formula V1_BIO002_LogisticGrowthBio()
    {
        return new Formula
        {
            Id = "V1-BIO002",
            CodigoCompendio = "061",
            Nome = "Crescimento Logístico Populacional",
            Categoria = "Biologia Matemática",
            SubCategoria = "Dinâmica Populacional",
            Expressao = "N(t) = K / (1 + (K/N₀-1)e^(-rt))",
            ExprTexto = "Modelo de Verhulst",
            Descricao = "População cresce até capacidade de carga K. Mais realista que modelo exponencial. Forma sigmoidal (curva S).",
            Criador = "Pierre François Verhulst",
            AnoOrigin = "1838",
            ExemploPratico = "N₀=50, K=5000, r=0.5, t=10: N ≈ 4950 (próximo da saturação).",
            Unidades = "indivíduos",
            VariavelResultado = "N",
            UnidadeResultado = "indivíduos",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "N0", Nome = "População inicial", Descricao = "N₀", Unidade = "indivíduos", ValorPadrao = 50, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "K", Nome = "Capacidade de carga", Descricao = "População máxima suportável", Unidade = "indivíduos", ValorPadrao = 5000, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Taxa de crescimento", Descricao = "Taxa intrínseca r", Unidade = "1/tempo", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo decorrido", Unidade = "tempo", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double N0 = inputs["N0"];
                double K = inputs["K"];
                double r = inputs["r"];
                double t = inputs["t"];
                double ratio = K / N0 - 1;
                return K / (1 + ratio * Math.Exp(-r * t));
            }
        };
    }
    
    public static Formula V1_BIO003_SIRModel()
    {
        return new Formula
        {
            Id = "V1-BIO003",
            CodigoCompendio = "062",
            Nome = "Taxa de Infecção SIR",
            Categoria = "Biologia Matemática",
            SubCategoria = "Epidemiologia",
            Expressao = "dI/dt = βSI - γI",
            ExprTexto = "Dinâmica de infectados",
            Descricao = "Modelo SIR básico: taxa de variação de infectados I. β é taxa de transmissão, γ é taxa de recuperação. S são suscetíveis.",
            Criador = "Kermack e McKendrick",
            AnoOrigin = "1927",
            ExemploPratico = "S=900, I=100, β=0.001, γ=0.1: dI/dt = 0.001×900×100 - 0.1×100 = 90 - 10 = 80 novos casos/dia.",
            Unidades = "indivíduos/tempo",
            VariavelResultado = "dI_dt",
            UnidadeResultado = "indivíduos/tempo",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "beta", Nome = "Taxa de transmissão", Descricao = "β (contatos×probabilidade)", Unidade = "1/(indivíduos·tempo)", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "S", Nome = "Suscetíveis", Descricao = "População suscetível", Unidade = "indivíduos", ValorPadrao = 900, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Infectados", Descricao = "População infectada", Unidade = "indivíduos", ValorPadrao = 100, ValorMin = 0, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "gamma", Nome = "Taxa de recuperação", Descricao = "γ (1/período_infeccioso)", Unidade = "1/tempo", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double beta = inputs["beta"];
                double S = inputs["S"];
                double I = inputs["I"];
                double gamma = inputs["gamma"];
                return beta * S * I - gamma * I;
            }
        };
    }
    
    // ========================================
    // CATEGORIA 16: COMPUTAÇÃO (3 fórmulas)
    // ========================================
    
    public static Formula V1_COMP001_BigO()
    {
        return new Formula
        {
            Id = "V1-COMP001",
            CodigoCompendio = "063",
            Nome = "Complexidade O(n²)",
            Categoria = "Computação",
            SubCategoria = "Análise de Complexidade",
            Expressao = "T(n) = an² + bn + c",
            ExprTexto = "Tempo quadrático",
            Descricao = "Algoritmos quadráticos: tempo cresce com o quadrado do tamanho da entrada. Comum em algoritmos de ordenação simples (bubble sort) e loops aninhados.",
            Criador = "Donald Knuth",
            AnoOrigin = "1976",
            ExemploPratico = "n=1000 elementos, a=0.001ms, b=0.01ms, c=1ms: T = 0.001×10⁶ + 10 + 1 ≈ 1011ms ≈ 1s.",
            Unidades = "ms",
            VariavelResultado = "T",
            UnidadeResultado = "ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Tamanho entrada", Descricao = "Número de elementos", Unidade = "elementos", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Coeficiente quadrático", Descricao = "Termo n²", Unidade = "ms", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Termo n", Unidade = "ms", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "c", Nome = "Termo constante", Descricao = "Overhead fixo", Unidade = "ms", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double a = inputs["a"];
                double b = inputs["b"];
                double c = inputs["c"];
                return a * n * n + b * n + c;
            }
        };
    }
    
    public static Formula V1_COMP002_BinarySearchComplexity()
    {
        return new Formula
        {
            Id = "V1-COMP002",
            CodigoCompendio = "064",
            Nome = "Complexidade O(log n)",
            Categoria = "Computação",
            SubCategoria = "Análise de Complexidade",
            Expressao = "T(n) = a log₂(n) + b",
            ExprTexto = "Tempo logarítmico",
            Descricao = "Algoritmos logarítmicos: tempo cresce com o logaritmo da entrada. Característico de busca binária e árvores balanceadas. Muito eficiente.",
            Criador = "Donald Knuth",
            AnoOrigin = "1976",
            ExemploPratico = "n=1,000,000 elementos, a=0.1ms, b=0.5ms: T = 0.1×log₂(10⁶) + 0.5 ≈ 0.1×19.93 + 0.5 ≈ 2.5ms.",
            Unidades = "ms",
            VariavelResultado = "T",
            UnidadeResultado = "ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Tamanho entrada", Descricao = "Número de elementos", Unidade = "elementos", ValorPadrao = 1000000, ValorMin = 1, ValorMax = 1e12, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Coeficiente log", Descricao = "Termo log₂(n)", Unidade = "ms", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Termo constante", Descricao = "Overhead fixo", Unidade = "ms", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                double a = inputs["a"];
                double b = inputs["b"];
                return a * Math.Log2(n) + b;
            }
        };
    }
    
    public static Formula V1_COMP003_RecurrenceRelation()
    {
        return new Formula
        {
            Id = "V1-COMP003",
            CodigoCompendio = "065",
            Nome = "Relação de Recorrência (Merge Sort)",
            Categoria = "Computação",
            SubCategoria = "Algoritmos de Ordenação",
            Expressao = "T(n) = 2T(n/2) + n",
            ExprTexto = "Divisão e conquista",
            Descricao = "Padrão divide-and-conquer: divide problema em 2 metades (2T(n/2)) e combina linearmente (+n). Solução: T(n) = O(n log n). Base do merge sort.",
            Criador = "John von Neumann",
            AnoOrigin = "1945",
            ExemploPratico = "Merge sort com n=1024: profundidade = log₂(1024) = 10, trabalho total ≈ 10×1024 = 10,240 operações.",
            Unidades = "operações",
            VariavelResultado = "T",
            UnidadeResultado = "operações",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "n", Nome = "Tamanho entrada", Descricao = "Número de elementos", Unidade = "elementos", ValorPadrao = 1024, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double n = inputs["n"];
                if (n <= 1) return 1;
                return n * Math.Log2(n);
            }
        };
    }
}
