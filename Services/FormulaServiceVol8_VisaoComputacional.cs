using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE V: VISÃO COMPUTACIONAL E PROCESSAMENTO DE IMAGENS
    // Filtros, descritores, geometria epipolar, deep learning
    // 21 fórmulas (084-104)
    // ========================================

    public static Formula V8_VIS084_ConvolucaoGaussiana()
    {
        return new Formula
        {
            Id = "V8-VIS084",
            CodigoCompendio = "084",
            Nome = "Filtro Gaussiano 2D",
            Categoria = "Visão Computacional",
            SubCategoria = "Processamento de Imagens",
            Expressao = "G(x,y) = (1/(2πσ²)) * exp(-(x²+y²)/(2σ²))",
            ExprTexto = "Kernel gaussiano",
            Descricao = "Suavização de imagem. σ controla blur. Base de SIFT, DoG (Difference of Gaussians).",
            Criador = "Gauss aplicado a imagens",
            AnoOrigin = "~1980s",
            ExemploPratico = "σ=1: blur leve. σ=5: blur forte. Usado em pré-processamento e detecção de bordas (LoG)",
            Unidades = "adimensional",
            VariavelResultado = "G",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Coordenada x", Descricao = "x do kernel", Unidade = "pixels", ValorPadrao = 1, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "y", Nome = "Coordenada y", Descricao = "y do kernel", Unidade = "pixels", ValorPadrao = 1, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "sigma", Nome = "Desvio padrão", Descricao = "σ", Unidade = "pixels", ValorPadrao = 1, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double y = inputs["y"];
                double sigma = inputs["sigma"];
                
                double coef = 1.0 / (2 * Math.PI * sigma * sigma);
                double exponent = -(x * x + y * y) / (2 * sigma * sigma);
                
                return coef * Math.Exp(exponent);
            }
        };
    }

    public static Formula V8_VIS085_FiltroSobel()
    {
        return new Formula
        {
            Id = "V8-VIS085",
            CodigoCompendio = "085",
            Nome = "Gradiente de Sobel — Magnitude",
            Categoria = "Visão Computacional",
            SubCategoria = "Detecção de Bordas",
            Expressao = "mag = sqrt(Gx² + Gy²); θ = atan2(Gy, Gx)",
            ExprTexto = "Magnitude do gradiente",
            Descricao = "Gx, Gy: derivadas parciais (kernels 3×3). Detecta bordas. Canny usa Sobel.",
            Criador = "Irwin Sobel",
            AnoOrigin = "1968",
            ExemploPratico = "Gx=100, Gy=50 → mag≈111,8. θ≈26,6°. Prewitt: similar, menos suavização",
            Unidades = "intensidade",
            VariavelResultado = "mag",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Gx", Nome = "Gradiente x", Descricao = "Gx", Unidade = "", ValorPadrao = 100, ValorMin = -255, ValorMax = 255, Obrigatoria = true },
                new() { Simbolo = "Gy", Nome = "Gradiente y", Descricao = "Gy", Unidade = "", ValorPadrao = 50, ValorMin = -255, ValorMax = 255, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Gx = inputs["Gx"];
                double Gy = inputs["Gy"];
                
                return Math.Sqrt(Gx * Gx + Gy * Gy);
            }
        };
    }

    public static Formula V8_VIS086_HarrisCorner()
    {
        return new Formula
        {
            Id = "V8-VIS086",
            CodigoCompendio = "086",
            Nome = "Detector de Cantos de Harris",
            Categoria = "Visão Computacional",
            SubCategoria = "Detecção de Features",
            Expressao = "R = det(M) - k*trace(M)²",
            ExprTexto = "Resposta de Harris",
            Descricao = "M=matriz estrutura ([ΣIx² ΣIxIy; ΣIxIy ΣIy²]). k≈0,04-0,06. R>threshold: canto.",
            Criador = "Chris Harris, Mike Stephens",
            AnoOrigin = "1988",
            ExemploPratico = "det=1000, trace=50, k=0,04 → R=1000-100=900 (canto forte). Base de tracking",
            Unidades = "adimensional",
            VariavelResultado = "R",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "det_M", Nome = "Determinante M", Descricao = "det(M)", Unidade = "", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "trace_M", Nome = "Traço M", Descricao = "trace(M)", Unidade = "", ValorPadrao = 50, ValorMin = 0, ValorMax = 1e6, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "Constante k", Descricao = "k", Unidade = "", ValorPadrao = 0.04, ValorMin = 0.01, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double det_M = inputs["det_M"];
                double trace_M = inputs["trace_M"];
                double k = inputs["k"];
                
                return det_M - k * trace_M * trace_M;
            }
        };
    }

    public static Formula V8_VIS087_SIFT_DoG()
    {
        return new Formula
        {
            Id = "V8-VIS087",
            CodigoCompendio = "087",
            Nome = "SIFT — Difference of Gaussians",
            Categoria = "Visão Computacional",
            SubCategoria = "Descritores de Features",
            Expressao = "DoG(x,y,σ) = G(x,y,k*σ) - G(x,y,σ)",
            ExprTexto = "Diferença de gaussianas",
            Descricao = "Aproxima LoG (Laplacian of Gaussian). k≈√2. Detecção de blobs invariante a escala.",
            Criador = "David Lowe",
            AnoOrigin = "2004",
            ExemploPratico = "σ=1,6, k=1,6 → pirâmide de escalas. SIFT: 128dim descriptor. Patente expirou 2020",
            Unidades = "intensidade",
            VariavelResultado = "DoG",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "G_k_sigma", Nome = "G(k·σ)", Descricao = "Gaussiana em k·σ", Unidade = "", ValorPadrao = 0.08, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "G_sigma", Nome = "G(σ)", Descricao = "Gaussiana em σ", Unidade = "", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double G_k_sigma = inputs["G_k_sigma"];
                double G_sigma = inputs["G_sigma"];
                
                return G_k_sigma - G_sigma;
            }
        };
    }

    public static Formula V8_VIS088_HOG_Histogram()
    {
        return new Formula
        {
            Id = "V8-VIS088",
            CodigoCompendio = "088",
            Nome = "HOG — Histogram of Oriented Gradients",
            Categoria = "Visão Computacional",
            SubCategoria = "Descritores de Features",
            Expressao = "bin = floor(θ / binWidth); weight = mag",
            ExprTexto = "Histograma de gradientes",
            Descricao = "θ=orientação do gradiente, mag=magnitude. Típico: 9 bins (0-180°). Usado em detecção de pedestres.",
            Criador = "Dalal e Triggs",
            AnoOrigin = "2005",
            ExemploPratico = "θ=45°, binWidth=20° → bin=2. mag=100. SVM + HOG: detecção de objetos",
            Unidades = "bin",
            VariavelResultado = "bin",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "theta", Nome = "Orientação", Descricao = "θ do gradiente", Unidade = "graus", ValorPadrao = 45, ValorMin = 0, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "binWidth", Nome = "Largura do bin", Descricao = "Largura em graus", Unidade = "graus", ValorPadrao = 20, ValorMin = 1, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double theta = inputs["theta"];
                double binWidth = inputs["binWidth"];
                
                return Math.Floor(theta / binWidth);
            }
        };
    }

    public static Formula V8_VIS089_NCC_Matching()
    {
        return new Formula
        {
            Id = "V8-VIS089",
            CodigoCompendio = "089",
            Nome = "NCC — Normalized Cross-Correlation",
            Categoria = "Visão Computacional",
            SubCategoria = "Template Matching",
            Expressao = "NCC = Σ(I-μI)(T-μT) / sqrt(Σ(I-μI)² * Σ(T-μT)²)",
            ExprTexto = "Correlação normalizada",
            Descricao = "I=imagem, T=template, μ=média. NCC∈[-1,1]. 1: perfeito match. Robusto a mudança de iluminação.",
            Criador = "Estatística aplicada a imagens",
            AnoOrigin = "~1970s",
            ExemploPratico = "NCC=0,95: bom match. <0,6: ruim. Usado em tracking, stereo matching",
            Unidades = "adimensional",
            VariavelResultado = "NCC",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sum_IT", Nome = "Σ(I-μI)(T-μT)", Descricao = "Soma produtos", Unidade = "", ValorPadrao = 1000, ValorMin = -1e10, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "sum_I2", Nome = "Σ(I-μI)²", Descricao = "Soma quadrados I", Unidade = "", ValorPadrao = 1200, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "sum_T2", Nome = "Σ(T-μT)²", Descricao = "Soma quadrados T", Unidade = "", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sum_IT = inputs["sum_IT"];
                double sum_I2 = inputs["sum_I2"];
                double sum_T2 = inputs["sum_T2"];
                
                double denom = Math.Sqrt(sum_I2 * sum_T2);
                if (denom == 0) return 0;
                
                return sum_IT / denom;
            }
        };
    }

    public static Formula V8_VIS090_EpipolarLine()
    {
        return new Formula
        {
            Id = "V8-VIS090",
            CodigoCompendio = "090",
            Nome = "Geometria Epipolar — Linha Epipolar",
            Categoria = "Visão Computacional",
            SubCategoria = "Visão Estéreo",
            Expressao = "l' = F * p",
            ExprTexto = "Linha epipolar",
            Descricao = "F=matriz fundamental (3×3). p=[x,y,1]ᵀ ponto na imagem 1 → l' linha na imagem 2.",
            Criador = "Longuet-Higgins",
            AnoOrigin = "1981",
            ExemploPratico = "p=[100,200,1] → l'=[a,b,c]. Restrição: p'ᵀ·F·p=0. 8-point algorithm estima F",
            Unidades = "adimensional",
            VariavelResultado = "l_prime_a",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "F11", Nome = "Elemento F[1,1]", Descricao = "F11", Unidade = "", ValorPadrao = 0.001, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "F12", Nome = "Elemento F[1,2]", Descricao = "F12", Unidade = "", ValorPadrao = -0.002, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "F13", Nome = "Elemento F[1,3]", Descricao = "F13", Unidade = "", ValorPadrao = 0.1, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "x", Nome = "Coordenada x", Descricao = "x", Unidade = "pixels", ValorPadrao = 100, ValorMin = 0, ValorMax = 1920, Obrigatoria = true },
                new() { Simbolo = "y", Nome = "Coordenada y", Descricao = "y", Unidade = "pixels", ValorPadrao = 200, ValorMin = 0, ValorMax = 1080, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double F11 = inputs["F11"];
                double F12 = inputs["F12"];
                double F13 = inputs["F13"];
                double x = inputs["x"];
                double y = inputs["y"];
                
                // l'_a = F11*x + F12*y + F13*1
                return F11 * x + F12 * y + F13;
            }
        };
    }

    public static Formula V8_VIS091_DisparidadeProfundidade()
    {
        return new Formula
        {
            Id = "V8-VIS091",
            CodigoCompendio = "091",
            Nome = "Profundidade de Disparidade Estéreo",
            Categoria = "Visão Computacional",
            SubCategoria = "Visão Estéreo",
            Expressao = "Z = (b * f) / d",
            ExprTexto = "Profundidade",
            Descricao = "b=baseline (distância entre câmeras), f=distância focal, d=disparidade (pixels).",
            Criador = "Geometria estéreo",
            AnoOrigin = "~1960s",
            ExemploPratico = "b=0,1m, f=500px, d=10px → Z=5m. d grande: perto. d pequeno: longe",
            Unidades = "m",
            VariavelResultado = "Z",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "b", Nome = "Baseline", Descricao = "b", Unidade = "m", ValorPadrao = 0.1, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "Distância focal", Descricao = "f", Unidade = "pixels", ValorPadrao = 500, ValorMin = 100, ValorMax = 5000, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Disparidade", Descricao = "d", Unidade = "pixels", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double b = inputs["b"];
                double f = inputs["f"];
                double d = inputs["d"];
                
                return (b * f) / d;
            }
        };
    }

    public static Formula V8_VIS092_HomografiaProjecao()
    {
        return new Formula
        {
            Id = "V8-VIS092",
            CodigoCompendio = "092",
            Nome = "Homografia — Transformação de Plano",
            Categoria = "Visão Computacional",
            SubCategoria = "Geometria de Visão",
            Expressao = "p' = H * p / (H31*x + H32*y + H33)",
            ExprTexto = "Projeção via homografia",
            Descricao = "H: matriz 3×3. Mapeia planos entre duas vistas. RANSAC para estimar H robusto.",
            Criador = "Geometria projetiva",
            AnoOrigin = "~1940s",
            ExemploPratico = "Retificação de imagem, panorama, AR. 4 pontos correspondentes determinam H",
            Unidades = "pixels",
            VariavelResultado = "x_prime",
            UnidadeResultado = "pixels",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "H11", Nome = "H[1,1]", Descricao = "H11", Unidade = "", ValorPadrao = 1, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "H12", Nome = "H[1,2]", Descricao = "H12", Unidade = "", ValorPadrao = 0, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "H13", Nome = "H[1,3]", Descricao = "H13", Unidade = "", ValorPadrao = 0, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "H31", Nome = "H[3,1]", Descricao = "H31", Unidade = "", ValorPadrao = 0, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "H32", Nome = "H[3,2]", Descricao = "H32", Unidade = "", ValorPadrao = 0, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "H33", Nome = "H[3,3]", Descricao = "H33", Unidade = "", ValorPadrao = 1, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "x", Nome = "Coordenada x", Descricao = "x", Unidade = "pixels", ValorPadrao = 100, ValorMin = 0, ValorMax = 1920, Obrigatoria = true },
                new() { Simbolo = "y", Nome = "Coordenada y", Descricao = "y", Unidade = "pixels", ValorPadrao = 200, ValorMin = 0, ValorMax = 1080, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double H11 = inputs["H11"];
                double H12 = inputs["H12"];
                double H13 = inputs["H13"];
                double H31 = inputs["H31"];
                double H32 = inputs["H32"];
                double H33 = inputs["H33"];
                double x = inputs["x"];
                double y = inputs["y"];
                
                double w = H31 * x + H32 * y + H33;
                return (H11 * x + H12 * y + H13) / w;
            }
        };
    }

    public static Formula V8_VIS093_CalibracaoReprojection()
    {
        return new Formula
        {
            Id = "V8-VIS093",
            CodigoCompendio = "093",
            Nome = "Erro de Reprojeção — Calibração",
            Categoria = "Visão Computacional",
            SubCategoria = "Calibração de Câmera",
            Expressao = "e = sqrt((x_obs - x_proj)² + (y_obs - y_proj)²)",
            ExprTexto = "Erro de reprojeção (pixels)",
            Descricao = "Calibração de câmera: minimiza Σe² sobre tabuleiro de xadrez. Zhang's method.",
            Criador = "Tsai, Zhang",
            AnoOrigin = "1987, 2000",
            ExemploPratico = "e<0,5px: boa calibração. e>2px: ruim. Calibra f, cx, cy, distorção k1, k2",
            Unidades = "pixels",
            VariavelResultado = "e",
            UnidadeResultado = "pixels",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x_obs", Nome = "x observado", Descricao = "x observado", Unidade = "pixels", ValorPadrao = 100.5, ValorMin = 0, ValorMax = 1920, Obrigatoria = true },
                new() { Simbolo = "y_obs", Nome = "y observado", Descricao = "y observado", Unidade = "pixels", ValorPadrao = 200.3, ValorMin = 0, ValorMax = 1080, Obrigatoria = true },
                new() { Simbolo = "x_proj", Nome = "x projetado", Descricao = "x projetado", Unidade = "pixels", ValorPadrao = 100.2, ValorMin = 0, ValorMax = 1920, Obrigatoria = true },
                new() { Simbolo = "y_proj", Nome = "y projetado", Descricao = "y projetado", Unidade = "pixels", ValorPadrao = 200.1, ValorMin = 0, ValorMax = 1080, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x_obs = inputs["x_obs"];
                double y_obs = inputs["y_obs"];
                double x_proj = inputs["x_proj"];
                double y_proj = inputs["y_proj"];
                
                double dx = x_obs - x_proj;
                double dy = y_obs - y_proj;
                
                return Math.Sqrt(dx * dx + dy * dy);
            }
        };
    }

    public static Formula V8_VIS094_DistorcaoRadial()
    {
        return new Formula
        {
            Id = "V8-VIS094",
            CodigoCompendio = "094",
            Nome = "Distorção Radial — Brown-Conrady",
            Categoria = "Visão Computacional",
            SubCategoria = "Calibração de Câmera",
            Expressao = "x_corrected = x * (1 + k1*r² + k2*r⁴ + k3*r⁶)",
            ExprTexto = "Correção de distorção",
            Descricao = "r²=x²+y². k1, k2, k3: coefs distorção. k1<0: barrel. k1>0: pincushion.",
            Criador = "Brown",
            AnoOrigin = "1966",
            ExemploPratico = "Wide-angle: k1=-0,2 (barrel). Corrige linhas retas. Tangencial: p1, p2 (descentering)",
            Unidades = "pixels",
            VariavelResultado = "x_corrected",
            UnidadeResultado = "pixels",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Coordenada x normalizada", Descricao = "x", Unidade = "", ValorPadrao = 0.5, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "y", Nome = "Coordenada y normalizada", Descricao = "y", Unidade = "", ValorPadrao = 0.3, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "k1", Nome = "Coef. distorção k1", Descricao = "k1", Unidade = "", ValorPadrao = -0.2, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "k2", Nome = "Coef. distorção k2", Descricao = "k2", Unidade = "", ValorPadrao = 0.05, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "k3", Nome = "Coef. distorção k3", Descricao = "k3", Unidade = "", ValorPadrao = 0, ValorMin = -1, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double y = inputs["y"];
                double k1 = inputs["k1"];
                double k2 = inputs["k2"];
                double k3 = inputs["k3"];
                
                double r2 = x * x + y * y;
                double r4 = r2 * r2;
                double r6 = r2 * r4;
                
                return x * (1 + k1 * r2 + k2 * r4 + k3 * r6);
            }
        };
    }

    public static Formula V8_VIS095_IoU()
    {
        return new Formula
        {
            Id = "V8-VIS095",
            CodigoCompendio = "095",
            Nome = "IoU — Intersection over Union",
            Categoria = "Visão Computacional",
            SubCategoria = "Avaliação de Detecção",
            Expressao = "IoU = Area(intersecção) / Area(união)",
            ExprTexto = "Sobreposição de bounding boxes",
            Descricao = "Métrica de detecção de objetos. IoU>0,5: match. mAP usa IoU 0,5; 0,75; etc.",
            Criador = "Métrica PASCAL VOC",
            AnoOrigin = "2005",
            ExemploPratico = "Pred=[100,100,200,200], GT=[110,105,210,205] → IoU≈0,68. YOLO, Mask R-CNN",
            Unidades = "adimensional",
            VariavelResultado = "IoU",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "area_intersection", Nome = "Área interseção", Descricao = "Área interseção", Unidade = "pixels²", ValorPadrao = 7000, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "area_union", Nome = "Área união", Descricao = "Área união", Unidade = "pixels²", ValorPadrao = 10000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double area_intersection = inputs["area_intersection"];
                double area_union = inputs["area_union"];
                
                return area_intersection / area_union;
            }
        };
    }

    public static Formula V8_VIS096_NonMaxSuppression()
    {
        return new Formula
        {
            Id = "V8-VIS096",
            CodigoCompendio = "096",
            Nome = "Non-Maximum Suppression (NMS)",
            Categoria = "Visão Computacional",
            SubCategoria = "Pós-Processamento",
            Expressao = "keep = (score > threshold) AND (IoU < NMS_threshold)",
            ExprTexto = "Supressão de detecções redundantes",
            Descricao = "Remove bounding boxes sobrepostas. NMS_threshold típico: 0,5. Mantém score mais alto.",
            Criador = "Detecção de objetos clássica",
            AnoOrigin = "~1980s",
            ExemploPratico = "2 boxes: IoU=0,7, NMS_threshold=0,5 → suprime box de score menor. Soft-NMS: decai score",
            Unidades = "bool",
            VariavelResultado = "keep",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "score", Nome = "Score confiança", Descricao = "score", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "threshold", Nome = "Threshold score", Descricao = "threshold", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "IoU", Nome = "IoU com box melhor", Descricao = "IoU", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "NMS_threshold", Nome = "Threshold NMS", Descricao = "NMS_threshold", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double score = inputs["score"];
                double threshold = inputs["threshold"];
                double IoU = inputs["IoU"];
                double NMS_threshold = inputs["NMS_threshold"];
                
                return (score > threshold && IoU < NMS_threshold) ? 1 : 0;
            }
        };
    }

    public static Formula V8_VIS097_OpticalFlowLucasKanade()
    {
        return new Formula
        {
            Id = "V8-VIS097",
            CodigoCompendio = "097",
            Nome = "Fluxo Óptico — Lucas-Kanade",
            Categoria = "Visão Computacional",
            SubCategoria = "Análise de Movimento",
            Expressao = "Ix*u + Iy*v + It = 0",
            ExprTexto = "Equação de fluxo óptico",
            Descricao = "Ix, Iy, It: derivadas espaciais e temporal. u,v: fluxo. Resolve por janela local.",
            Criador = "Lucas e Kanade",
            AnoOrigin = "1981",
            ExemploPratico = "Aperture problem: linha → múltiplas soluções. Horn-Schunck: globalmente suave",
            Unidades = "pixels/frame",
            VariavelResultado = "u",
            UnidadeResultado = "pixels/frame",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "At_A_inv_11", Nome = "(A^T·A)^-1 [1,1]", Descricao = "Elemento inverso", Unidade = "", ValorPadrao = 0.01, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "At_b_1", Nome = "A^T·b [1]", Descricao = "Elemento 1", Unidade = "", ValorPadrao = -5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double At_A_inv_11 = inputs["At_A_inv_11"];
                double At_b_1 = inputs["At_b_1"];
                
                // Simplificado: u ≈ (A^T·A)^-1 · A^T·b
                return At_A_inv_11 * At_b_1;
            }
        };
    }

    public static Formula V8_VIS098_StructureTensor()
    {
        return new Formula
        {
            Id = "V8-VIS098",
            CodigoCompendio = "098",
            Nome = "Tensor de Estrutura Local",
            Categoria = "Visão Computacional",
            SubCategoria = "Análise de Textura",
            Expressao = "J = [ΣIx² ΣIxIy; ΣIxIy ΣIy²]",
            ExprTexto = "Matriz de estrutura",
            Descricao = "Autovalores λ1, λ2: λ1>>λ2: borda. λ1≈λ2: canto. λ1≈λ2≈0: flat.",
            Criador = "Förstner, Harris",
            AnoOrigin = "~1987",
            ExemploPratico = "Σ sobre janela w. Coerência: (λ1-λ2)/(λ1+λ2). Orientação: atan2(2·ΣIxIy, ΣIx²-ΣIy²)",
            Unidades = "adimensional",
            VariavelResultado = "J11",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sum_Ix2", Nome = "ΣIx²", Descricao = "Soma Ix²", Unidade = "", ValorPadrao = 1000, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "sum_IxIy", Nome = "ΣIxIy", Descricao = "Soma IxIy", Unidade = "", ValorPadrao = 200, ValorMin = -1e10, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "sum_Iy2", Nome = "ΣIy²", Descricao = "Soma Iy²", Unidade = "", ValorPadrao = 800, ValorMin = 0, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sum_Ix2 = inputs["sum_Ix2"];
                
                return sum_Ix2; // Retorna J11
            }
        };
    }

    public static Formula V8_VIS099_SSIM()
    {
        return new Formula
        {
            Id = "V8-VIS099",
            CodigoCompendio = "099",
            Nome = "SSIM — Structural Similarity Index",
            Categoria = "Visão Computacional",
            SubCategoria = "Qualidade de Imagem",
            Expressao = "SSIM = ((2*μx*μy + C1)*(2*σxy + C2)) / ((μx²+μy²+C1)*(σx²+σy²+C2))",
            ExprTexto = "Índice de similaridade estrutural",
            Descricao = "μ=média, σ=desvio, σxy=covariância. C1, C2: constantes. SSIM∈[-1,1]. 1: idêntico.",
            Criador = "Wang et al.",
            AnoOrigin = "2004",
            ExemploPratico = "SSIM=0,95: alta qualidade. PSNR: pixel-wise, SSIM: estrutural. MS-SSIM: multi-escala",
            Unidades = "adimensional",
            VariavelResultado = "SSIM",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "mu_x", Nome = "Média x", Descricao = "μx", Unidade = "", ValorPadrao = 128, ValorMin = 0, ValorMax = 255, Obrigatoria = true },
                new() { Simbolo = "mu_y", Nome = "Média y", Descricao = "μy", Unidade = "", ValorPadrao = 130, ValorMin = 0, ValorMax = 255, Obrigatoria = true },
                new() { Simbolo = "sigma_x", Nome = "Desvio x", Descricao = "σx", Unidade = "", ValorPadrao = 20, ValorMin = 0, ValorMax = 255, Obrigatoria = true },
                new() { Simbolo = "sigma_y", Nome = "Desvio y", Descricao = "σy", Unidade = "", ValorPadrao = 22, ValorMin = 0, ValorMax = 255, Obrigatoria = true },
                new() { Simbolo = "sigma_xy", Nome = "Covariância xy", Descricao = "σxy", Unidade = "", ValorPadrao = 400, ValorMin = -65025, ValorMax = 65025, Obrigatoria = true },
                new() { Simbolo = "C1", Nome = "Constante C1", Descricao = "C1", Unidade = "", ValorPadrao = 6.5, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "C2", Nome = "Constante C2", Descricao = "C2", Unidade = "", ValorPadrao = 58.5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double mu_x = inputs["mu_x"];
                double mu_y = inputs["mu_y"];
                double sigma_x = inputs["sigma_x"];
                double sigma_y = inputs["sigma_y"];
                double sigma_xy = inputs["sigma_xy"];
                double C1 = inputs["C1"];
                double C2 = inputs["C2"];
                
                double numerator = (2 * mu_x * mu_y + C1) * (2 * sigma_xy + C2);
                double denominator = (mu_x * mu_x + mu_y * mu_y + C1) * (sigma_x * sigma_x + sigma_y * sigma_y + C2);
                
                return numerator / denominator;
            }
        };
    }

    public static Formula V8_VIS100_PSNR()
    {
        return new Formula
        {
            Id = "V8-VIS100",
            CodigoCompendio = "100",
            Nome = "PSNR — Peak Signal-to-Noise Ratio",
            Categoria = "Visão Computacional",
            SubCategoria = "Qualidade de Imagem",
            Expressao = "PSNR = 10 * log10(MAX² / MSE)",
            ExprTexto = "Relação sinal-ruído",
            Descricao = "MAX=255 (8-bit). MSE=mean squared error. PSNR>40dB: alta qualidade. <30dB: baixa.",
            Criador = "Métrica de compressão",
            AnoOrigin = "~1980s",
            ExemploPratico = "MSE=100 → PSNR=28,1dB (visível). MSE=10 → PSNR=38,1dB (boa). JPEG, H.264",
            Unidades = "dB",
            VariavelResultado = "PSNR",
            UnidadeResultado = "dB",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "MAX", Nome = "Valor máximo pixel", Descricao = "MAX", Unidade = "", ValorPadrao = 255, ValorMin = 1, ValorMax = 65535, Obrigatoria = true },
                new() { Simbolo = "MSE", Nome = "Mean Squared Error", Descricao = "MSE", Unidade = "", ValorPadrao = 100, ValorMin = 0.001, ValorMax = 100000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double MAX = inputs["MAX"];
                double MSE = inputs["MSE"];
                
                return 10 * Math.Log10((MAX * MAX) / MSE);
            }
        };
    }

    public static Formula V8_VIS101_AnchorBox()
    {
        return new Formula
        {
            Id = "V8-VIS101",
            CodigoCompendio = "101",
            Nome = "Anchor Box — Codificação de Offset",
            Categoria = "Visão Computacional",
            SubCategoria = "Detecção de Objetos",
            Expressao = "dx = (x - xa) / wa; dy = (y - ya) / ha",
            ExprTexto = "Offset normalizado",
            Descricao = "xa, ya, wa, ha: anchor. x, y, w, h: ground truth. Faster R-CNN, YOLO usam anchors.",
            Criador = "R-CNN family",
            AnoOrigin = "2015",
            ExemploPratico = "Anchor=[100,100,50,50], GT=[105,110,60,55] → dx=0,1, dy=0,2. Regressão de bbox",
            Unidades = "adimensional",
            VariavelResultado = "dx",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Centro x GT", Descricao = "x", Unidade = "pixels", ValorPadrao = 105, ValorMin = 0, ValorMax = 1920, Obrigatoria = true },
                new() { Simbolo = "xa", Nome = "Centro x anchor", Descricao = "xa", Unidade = "pixels", ValorPadrao = 100, ValorMin = 0, ValorMax = 1920, Obrigatoria = true },
                new() { Simbolo = "wa", Nome = "Largura anchor", Descricao = "wa", Unidade = "pixels", ValorPadrao = 50, ValorMin = 1, ValorMax = 1920, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double xa = inputs["xa"];
                double wa = inputs["wa"];
                
                return (x - xa) / wa;
            }
        };
    }

    public static Formula V8_VIS102_FocalLoss()
    {
        return new Formula
        {
            Id = "V8-VIS102",
            CodigoCompendio = "102",
            Nome = "Focal Loss — RetinaNet",
            Categoria = "Visão Computacional",
            SubCategoria = "Deep Learning",
            Expressao = "FL = -α*(1-pt)^γ * log(pt)",
            ExprTexto = "Perda focal",
            Descricao = "pt=probabilidade predita classe correta. γ=2: foco em exemplos difíceis. α: balanceia classes.",
            Criador = "Lin et al.",
            AnoOrigin = "2017",
            ExemploPratico = "pt=0,9 (fácil): (1-pt)^γ=0,01 → peso baixo. pt=0,3 (difícil): peso alto. Resolve class imbalance",
            Unidades = "adimensional",
            VariavelResultado = "FL",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "alpha", Nome = "Fator α", Descricao = "α", Unidade = "", ValorPadrao = 0.25, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "pt", Nome = "Probabilidade classe correta", Descricao = "pt", Unidade = "", ValorPadrao = 0.8, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "gamma", Nome = "Expoente γ", Descricao = "γ", Unidade = "", ValorPadrao = 2, ValorMin = 0, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double alpha = inputs["alpha"];
                double pt = inputs["pt"];
                double gamma = inputs["gamma"];
                
                return -alpha * Math.Pow(1 - pt, gamma) * Math.Log(pt);
            }
        };
    }

    public static Formula V8_VIS103_AttentionWeight()
    {
        return new Formula
        {
            Id = "V8-VIS103",
            CodigoCompendio = "103",
            Nome = "Attention Weight — Self-Attention",
            Categoria = "Visão Computacional",
            SubCategoria = "Deep Learning",
            Expressao = "α = softmax(Q*K^T / sqrt(dk))",
            ExprTexto = "Peso de atenção",
            Descricao = "Q=query, K=key, dk=dimensão. α: pesos de atenção. Vision Transformer (ViT).",
            Criador = "Vaswani et al. (Transformer)",
            AnoOrigin = "2017",
            ExemploPratico = "Q·K^T: similaridade. /√dk: estabiliza gradiente. α·V: contexto. ViT, DETR, Swin Transformer",
            Unidades = "adimensional",
            VariavelResultado = "score",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "QK_dot", Nome = "Q·K^T", Descricao = "Produto escalar", Unidade = "", ValorPadrao = 50, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "d_k", Nome = "Dimensão dk", Descricao = "dk", Unidade = "", ValorPadrao = 64, ValorMin = 1, ValorMax = 1024, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double QK_dot = inputs["QK_dot"];
                double d_k = inputs["d_k"];
                
                return QK_dot / Math.Sqrt(d_k);
            }
        };
    }

    public static Formula V8_VIS104_ReceptiveField()
    {
        return new Formula
        {
            Id = "V8-VIS104",
            CodigoCompendio = "104",
            Nome = "Receptive Field — CNN",
            Categoria = "Visão Computacional",
            SubCategoria = "Deep Learning",
            Expressao = "RF_out = RF_in + (kernel_size - 1) * stride_product",
            ExprTexto = "Campo receptivo efetivo",
            Descricao = "Área da imagem que influencia um neurônio. Cresce com camadas. Dilated conv: RF sem ↑params.",
            Criador = "Análise de CNN",
            AnoOrigin = "~2010s",
            ExemploPratico = "Conv 3×3, stride=1: +2px/layer. Layer 5: RF≈11×11. ResNet-50 layer final: RF≈483×483",
            Unidades = "pixels",
            VariavelResultado = "RF_out",
            UnidadeResultado = "pixels",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "RF_in", Nome = "RF entrada", Descricao = "RF_in", Unidade = "pixels", ValorPadrao = 1, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "kernel_size", Nome = "Tamanho kernel", Descricao = "kernel_size", Unidade = "pixels", ValorPadrao = 3, ValorMin = 1, ValorMax = 11, Obrigatoria = true },
                new() { Simbolo = "stride_product", Nome = "Produto de strides anteriores", Descricao = "stride_product", Unidade = "", ValorPadrao = 1, ValorMin = 1, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double RF_in = inputs["RF_in"];
                double kernel_size = inputs["kernel_size"];
                double stride_product = inputs["stride_product"];
                
                return RF_in + (kernel_size - 1) * stride_product;
            }
        };
    }
}
