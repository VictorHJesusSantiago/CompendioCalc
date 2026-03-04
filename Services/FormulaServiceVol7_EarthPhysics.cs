using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 7 — PARTE VI: CIÊNCIAS DA TERRA E FÍSICA (39 fórmulas)
    // ═══════════════════════════════════════════════════════════════

    private void AdicionarVol7TerraFisica()
    {
        _formulas.AddRange([
            // ═══ QUÍMICA ANALÍTICA (4 fórmulas) ═══

            new Formula
            {
                Id = "7_qan01", Nome = "Lei de Beer-Lambert", Categoria = "Química Analítica",
                Expressao = "A = ε · b · c",
                ExprTexto = "A = ε × b × c  (absorbância)",
                Icone = "A",
                Descricao = "Absorbância = absortividade molar × caminho óptico × concentração. Base da espectrofotometria UV-Vis para análise quantitativa.",
                Criador = "Beer (1852) / Lambert (1760) / Bouguer (1729)",
                AnoOrigin = "1852",
                ExemploPratico = "ε=15.000 L/(mol·cm), b=1cm, c=2×10⁻⁵ mol/L: A = 0,3",
                Variaveis = [
                    new() { Simbolo = "eps", Nome = "Absortividade molar ε (L/mol·cm)", ValorPadrao = 15000 },
                    new() { Simbolo = "b", Nome = "Caminho óptico (cm)", ValorPadrao = 1 },
                    new() { Simbolo = "c", Nome = "Concentração (mol/L)", ValorPadrao = 0.00002 },
                ],
                VariavelResultado = "A (absorbância)",
                Calcular = vars => vars["eps"] * vars["b"] * vars["c"]
            },
            new Formula
            {
                Id = "7_qan02", Nome = "Equação de Henderson-Hasselbalch", Categoria = "Química Analítica",
                Expressao = "pH = pKa + log([A⁻]/[HA])",
                ExprTexto = "pH = pKa + log₁₀(base conjugada / ácido)",
                Icone = "pH",
                Descricao = "pH de solução tampão em função do pKa e razão [base conjugada]/[ácido]. Fundamental para preparo de tampões em laboratório.",
                Criador = "Henderson (1908) / Hasselbalch (1917)",
                AnoOrigin = "1917",
                ExemploPratico = "Tampão acético: pKa=4,75, [Ac⁻]/[HAc]=2: pH = 4,75+log(2) = 5,05",
                Variaveis = [
                    new() { Simbolo = "pKa", Nome = "pKa do ácido", ValorPadrao = 4.75 },
                    new() { Simbolo = "A", Nome = "[Base conjugada] (mol/L)", ValorPadrao = 0.2 },
                    new() { Simbolo = "HA", Nome = "[Ácido] (mol/L)", ValorPadrao = 0.1, ValorMin = 0.0001 },
                ],
                VariavelResultado = "pH",
                Calcular = vars => vars["pKa"] + Math.Log10(vars["A"] / vars["HA"])
            },
            new Formula
            {
                Id = "7_qan03", Nome = "Limite de Detecção (3σ)", Categoria = "Química Analítica",
                Expressao = "LOD = 3 · σ / S",
                ExprTexto = "LOD = 3σ / S  (sensibilidade da curva)",
                Icone = "LOD",
                Descricao = "Menor concentração detectável com 99,7% de confiança. σ = desvio padrão do branco, S = inclinação da curva analítica.",
                Criador = "IUPAC; Kaiser (1947)",
                AnoOrigin = "1947",
                ExemploPratico = "σ=0,005 abs, S=25.000 abs/(mol/L): LOD = 3×0,005/25000 = 6×10⁻⁷ mol/L",
                Variaveis = [
                    new() { Simbolo = "sigma", Nome = "Desvio padrão do branco (σ)", ValorPadrao = 0.005 },
                    new() { Simbolo = "S", Nome = "Inclinação curva analítica (S)", ValorPadrao = 25000, ValorMin = 0.001 },
                ],
                VariavelResultado = "LOD",
                Calcular = vars => 3 * vars["sigma"] / vars["S"]
            },
            new Formula
            {
                Id = "7_qan04", Nome = "Titulação Ácido-Base", Categoria = "Química Analítica",
                Expressao = "Ca · Va = Cb · Vb",
                ExprTexto = "Ca × Va = Cb × Vb  (ponto de equivalência)",
                Icone = "🧪",
                Descricao = "No ponto de equivalência, mols de ácido = mols de base. Ca, Cb = concentrações; Va, Vb = volumes. Para monopróticos 1:1.",
                Criador = "Gay-Lussac (volumetria, 1828)",
                AnoOrigin = "1828",
                ExemploPratico = "HCl 0,1M, 25mL + NaOH 0,1M: Vb = 0,1×25/0,1 = 25 mL",
                Variaveis = [
                    new() { Simbolo = "Ca", Nome = "Conc. ácido (mol/L)", ValorPadrao = 0.1 },
                    new() { Simbolo = "Va", Nome = "Volume ácido (mL)", ValorPadrao = 25 },
                    new() { Simbolo = "Cb", Nome = "Conc. base (mol/L)", ValorPadrao = 0.1, ValorMin = 0.0001 },
                ],
                VariavelResultado = "Vb (mL)",
                UnidadeResultado = "mL",
                Calcular = vars => vars["Ca"] * vars["Va"] / vars["Cb"]
            },

            // ═══ GEODÉSIA E TOPOGRAFIA (4 fórmulas) ═══

            new Formula
            {
                Id = "7_geo01", Nome = "Distância por Fórmula de Haversine", Categoria = "Geodésia e Topografia",
                Expressao = "d = 2R · arcsin(√(sin²((φ₂−φ₁)/2) + cos(φ₁)cos(φ₂)sin²((λ₂−λ₁)/2)))",
                ExprTexto = "d = 2R × arcsin(√(a))  em km",
                Icone = "🗺",
                Descricao = "Distância do grande círculo entre dois pontos na esfera terrestre. R ≈ 6.371 km. Precisão ~0,5% (Terra é elipsoide).",
                Criador = "James Andrew (1805); fórmula de Haversine",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "São Paulo (−23,5°,−46,6°) a Rio (−22,9°,−43,2°): d ≈ 358 km",
                Variaveis = [
                    new() { Simbolo = "lat1", Nome = "Latitude 1 (graus)", ValorPadrao = -23.5 },
                    new() { Simbolo = "lon1", Nome = "Longitude 1 (graus)", ValorPadrao = -46.6 },
                    new() { Simbolo = "lat2", Nome = "Latitude 2 (graus)", ValorPadrao = -22.9 },
                    new() { Simbolo = "lon2", Nome = "Longitude 2 (graus)", ValorPadrao = -43.2 },
                ],
                VariavelResultado = "d (km)",
                UnidadeResultado = "km",
                Calcular = vars =>
                {
                    double R = 6371.0;
                    double φ1 = vars["lat1"] * Math.PI / 180, φ2 = vars["lat2"] * Math.PI / 180;
                    double Δφ = (vars["lat2"] - vars["lat1"]) * Math.PI / 180;
                    double Δλ = (vars["lon2"] - vars["lon1"]) * Math.PI / 180;
                    double a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) + Math.Cos(φ1) * Math.Cos(φ2) * Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
                    return 2 * R * Math.Asin(Math.Sqrt(a));
                }
            },
            new Formula
            {
                Id = "7_geo02", Nome = "Área por Coordenadas (Gauss/Shoelace)", Categoria = "Geodésia e Topografia",
                Expressao = "A = 0.5 · |Σ(xᵢyᵢ₊₁ − xᵢ₊₁yᵢ)|",
                ExprTexto = "A = ½ |x₁(y₂−y₃) + x₂(y₃−y₁) + x₃(y₁−y₂)|  (triângulo)",
                Icone = "📐",
                Descricao = "Área de polígono por coordenadas (fórmula do cadarço/Shoelace). Para triângulo: simplificação com 3 pontos.",
                Criador = "Carl Friedrich Gauss; fórmula do Shoelace",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "Triângulo (0,0),(4,0),(2,3): A = ½|0×0−4×0 + 4×3−2×0 + 2×0−0×3| = 6 m²",
                Variaveis = [
                    new() { Simbolo = "x1", Nome = "x₁", ValorPadrao = 0 },
                    new() { Simbolo = "y1", Nome = "y₁", ValorPadrao = 0 },
                    new() { Simbolo = "x2", Nome = "x₂", ValorPadrao = 4 },
                    new() { Simbolo = "y2", Nome = "y₂", ValorPadrao = 0 },
                    new() { Simbolo = "x3", Nome = "x₃", ValorPadrao = 2 },
                    new() { Simbolo = "y3", Nome = "y₃", ValorPadrao = 3 },
                ],
                VariavelResultado = "Área",
                UnidadeResultado = "m²",
                Calcular = vars => 0.5 * Math.Abs(vars["x1"] * (vars["y2"] - vars["y3"]) + vars["x2"] * (vars["y3"] - vars["y1"]) + vars["x3"] * (vars["y1"] - vars["y2"]))
            },
            new Formula
            {
                Id = "7_geo03", Nome = "Nivelamento Geométrico", Categoria = "Geodésia e Topografia",
                Expressao = "H_B = H_A + (Leitura_ré − Leitura_vante)",
                ExprTexto = "HB = HA + ré − vante",
                Icone = "📏",
                Descricao = "Altitude de um ponto a partir de nivelamento com nível óptico. Ré = mira na referência, Vante = mira no ponto a determinar.",
                Criador = "Topografia clássica; nivelamento geométrico",
                AnoOrigin = "Séc. XVIII",
                ExemploPratico = "HA=100m, ré=1,523m, vante=0,847m: HB = 100+1,523−0,847 = 100,676 m",
                Variaveis = [
                    new() { Simbolo = "HA", Nome = "Altitude A (m)", ValorPadrao = 100 },
                    new() { Simbolo = "re", Nome = "Leitura ré (m)", ValorPadrao = 1.523 },
                    new() { Simbolo = "vante", Nome = "Leitura vante (m)", ValorPadrao = 0.847 },
                ],
                VariavelResultado = "HB (m)",
                UnidadeResultado = "m",
                Calcular = vars => vars["HA"] + vars["re"] - vars["vante"]
            },
            new Formula
            {
                Id = "7_geo04", Nome = "Correção de Curvatura e Refração", Categoria = "Geodésia e Topografia",
                Expressao = "c = 0.0675 · d²",
                ExprTexto = "c = 0,0675 × d²  (metros, com d em km)",
                Icone = "🌍",
                Descricao = "Correção de curvatura terrestre e refração atmosférica para nivelamento. Para longas visadas (>300m), deve-se corrigir a leitura.",
                Criador = "Geodésia; correção combinada curvatura+refração",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "Visada de 2 km: c = 0,0675×4 = 0,27 m de correção",
                Variaveis = [
                    new() { Simbolo = "d", Nome = "Distância (km)", ValorPadrao = 2 },
                ],
                VariavelResultado = "c (m)",
                UnidadeResultado = "m",
                Calcular = vars => 0.0675 * vars["d"] * vars["d"]
            },

            // ═══ ACÚSTICA (3 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_acu01", Nome = "Nível de Pressão Sonora (dB SPL)", Categoria = "Acústica e Vibroacústica",
                Expressao = "L_p = 20 · log₁₀(p / p₀)",
                ExprTexto = "Lp = 20 × log(p/p₀)  em dB, p₀ = 20 μPa",
                Icone = "dB",
                Descricao = "Nível sonoro em decibéis referenciado à pressão limiar de audição (20 μPa). 0 dB = limiar, 120 dB = limiar de dor.",
                Criador = "Alexander Graham Bell (conceito); escala dB",
                AnoOrigin = "1924",
                ExemploPratico = "Conversa normal p=0,02 Pa: Lp = 20×log(0,02/0,00002) = 60 dB",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Pressão sonora (Pa)", ValorPadrao = 0.02 },
                ],
                VariavelResultado = "Lp (dB SPL)",
                UnidadeResultado = "dB",
                Calcular = vars => 20 * Math.Log10(vars["p"] / 0.00002)
            },
            new Formula
            {
                Id = "7_acu02", Nome = "Velocidade do Som no Ar", Categoria = "Acústica e Vibroacústica",
                Expressao = "v = 331.3 + 0.606 · T",
                ExprTexto = "v = 331,3 + 0,606 × T  (°C)",
                Icone = "v_som",
                Descricao = "Velocidade do som no ar em função da temperatura. A 20°C: ~343 m/s. Para gases: v = √(γRT/M).",
                Criador = "Pierre-Simon Laplace (1816); Isaac Newton (primeira estimativa)",
                AnoOrigin = "1816",
                ExemploPratico = "T=25°C: v = 331,3+0,606×25 = 346,5 m/s",
                Variaveis = [
                    new() { Simbolo = "T", Nome = "Temperatura (°C)", ValorPadrao = 25 },
                ],
                VariavelResultado = "v (m/s)",
                UnidadeResultado = "m/s",
                Calcular = vars => 331.3 + 0.606 * vars["T"]
            },
            new Formula
            {
                Id = "7_acu03", Nome = "Lei do Inverso do Quadrado (Som)", Categoria = "Acústica e Vibroacústica",
                Expressao = "L₂ = L₁ − 20·log₁₀(r₂/r₁)",
                ExprTexto = "L₂ = L₁ − 20log(r₂/r₁)  (campo livre)",
                Icone = "1/r²",
                Descricao = "Atenuação sonora com a distância em campo livre: −6 dB por duplicação de distância. Fonte pontual isotrópica.",
                Criador = "Acústica; lei do inverso do quadrado",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "80 dB a 1m → a 4m: L₂ = 80−20log(4) = 80−12 = 68 dB",
                Variaveis = [
                    new() { Simbolo = "L1", Nome = "Nível na dist. r₁ (dB)", ValorPadrao = 80 },
                    new() { Simbolo = "r1", Nome = "Distância r₁ (m)", ValorPadrao = 1, ValorMin = 0.01 },
                    new() { Simbolo = "r2", Nome = "Distância r₂ (m)", ValorPadrao = 4, ValorMin = 0.01 },
                ],
                VariavelResultado = "L₂ (dB)",
                UnidadeResultado = "dB",
                Calcular = vars => vars["L1"] - 20 * Math.Log10(vars["r2"] / vars["r1"])
            },

            // ═══ ASTRONOMIA (7 fórmulas) ═══

            new Formula
            {
                Id = "7_ast01", Nome = "Terceira Lei de Kepler", Categoria = "Astronomia",
                Expressao = "T² = (4π²/GM) · a³",
                ExprTexto = "T² = 4π²a³ / (GM)",
                Icone = "🪐",
                Descricao = "Período orbital ao quadrado proporcional ao cubo do semieixo maior. G = 6,674×10⁻¹¹, M = massa central.",
                Criador = "Johannes Kepler (1619); Newton (generalização, 1687)",
                AnoOrigin = "1619",
                ExemploPratico = "Terra: a=1,496×10¹¹m, M_sol=1,989×10³⁰kg: T² → T ≈ 365,25 dias",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Semieixo maior (m)", ValorPadrao = 1.496e11 },
                    new() { Simbolo = "M", Nome = "Massa central (kg)", ValorPadrao = 1.989e30 },
                ],
                VariavelResultado = "T (s)",
                UnidadeResultado = "s",
                Calcular = vars => Math.Sqrt(4 * Math.PI * Math.PI * Math.Pow(vars["a"], 3) / (6.674e-11 * vars["M"]))
            },
            new Formula
            {
                Id = "7_ast02", Nome = "Lei de Hubble", Categoria = "Astronomia",
                Expressao = "v = H₀ · d",
                ExprTexto = "v = H₀ × d  (km/s)",
                Icone = "H₀",
                Descricao = "Velocidade de recessão das galáxias proporcional à distância. H₀ ≈ 70 km/s/Mpc. Evidência da expansão do Universo.",
                Criador = "Edwin Hubble (1929); Georges Lemaître (1927)",
                AnoOrigin = "1929",
                ExemploPratico = "Galáxia a 100 Mpc: v = 70×100 = 7.000 km/s",
                Variaveis = [
                    new() { Simbolo = "H0", Nome = "Constante de Hubble (km/s/Mpc)", ValorPadrao = 70 },
                    new() { Simbolo = "d", Nome = "Distância (Mpc)", ValorPadrao = 100 },
                ],
                VariavelResultado = "v (km/s)",
                UnidadeResultado = "km/s",
                Calcular = vars => vars["H0"] * vars["d"]
            },
            new Formula
            {
                Id = "7_ast03", Nome = "Magnitude Aparente e Absoluta", Categoria = "Astronomia",
                Expressao = "m − M = 5·log₁₀(d/10)",
                ExprTexto = "m − M = 5 × log(d/10)  (d em parsec)",
                Icone = "⭐",
                Descricao = "Módulo de distância: relação entre magnitude aparente (m), absoluta (M) e distância. M = brilho a 10 parsec de distância.",
                Criador = "Pogson (escala, 1856); paralaxe estelar",
                AnoOrigin = "1856",
                ExemploPratico = "Sol: m=−26,74, d=4,85×10⁻⁶ pc → M ≈ 4,83",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Magnitude aparente (m)", ValorPadrao = -26.74 },
                    new() { Simbolo = "d", Nome = "Distância (parsec)", ValorPadrao = 4.85e-6, ValorMin = 1e-10 },
                ],
                VariavelResultado = "M (magnitude absoluta)",
                Calcular = vars => vars["m"] - 5 * Math.Log10(vars["d"] / 10.0)
            },
            new Formula
            {
                Id = "7_ast04", Nome = "Lei de Stefan-Boltzmann (Estrelas)", Categoria = "Astronomia",
                Expressao = "L = 4π·R²·σ·T⁴",
                ExprTexto = "L = 4πR²σT⁴  (luminosidade)",
                Icone = "L☀",
                Descricao = "Luminosidade total de uma estrela: proporcional à área superficial × T⁴. σ = 5,67×10⁻⁸. Diagrama HR usa L vs T.",
                Criador = "Stefan (1879) / Boltzmann (1884)",
                AnoOrigin = "1884",
                ExemploPratico = "Sol: R=6,96×10⁸m, T=5778K: L = 4π×(6,96e8)²×5,67e-8×5778⁴ ≈ 3,85×10²⁶ W",
                Variaveis = [
                    new() { Simbolo = "R", Nome = "Raio da estrela (m)", ValorPadrao = 6.96e8 },
                    new() { Simbolo = "T", Nome = "Temperatura superficial (K)", ValorPadrao = 5778 },
                ],
                VariavelResultado = "L (W)",
                UnidadeResultado = "W",
                Calcular = vars => 4 * Math.PI * vars["R"] * vars["R"] * 5.670374419e-8 * Math.Pow(vars["T"], 4)
            },
            new Formula
            {
                Id = "7_ast05", Nome = "Velocidade de Escape", Categoria = "Astronomia",
                Expressao = "v_esc = √(2GM/r)",
                ExprTexto = "vesc = √(2GM/r)",
                Icone = "v_esc",
                Descricao = "Velocidade mínima para escapar do campo gravitacional. Terra: 11,2 km/s, Sol: 617 km/s, Buraco negro: c.",
                Criador = "Newton (gravitação); formalizado séc. XVIII",
                AnoOrigin = "1687",
                ExemploPratico = "Terra: M=5,97×10²⁴kg, r=6,37×10⁶m: vesc = √(2×6,674e-11×5,97e24/6,37e6) = 11.186 m/s",
                Variaveis = [
                    new() { Simbolo = "M", Nome = "Massa do corpo (kg)", ValorPadrao = 5.97e24 },
                    new() { Simbolo = "r", Nome = "Raio (m)", ValorPadrao = 6.37e6, ValorMin = 1 },
                ],
                VariavelResultado = "v_esc (m/s)",
                UnidadeResultado = "m/s",
                Calcular = vars => Math.Sqrt(2 * 6.674e-11 * vars["M"] / vars["r"])
            },
            new Formula
            {
                Id = "7_ast06", Nome = "Paralaxe Estelar", Categoria = "Astronomia",
                Expressao = "d = 1 / p",
                ExprTexto = "d = 1/p  (d em parsec, p em segundos de arco)",
                Icone = "📡",
                Descricao = "Distância a estrelas próximas pela paralaxe trigonométrica. 1 parsec = 3,26 anos-luz. Funciona para estrelas até ~1000 pc (Gaia).",
                Criador = "Friedrich Bessel (1838, primeira medição: 61 Cygni)",
                AnoOrigin = "1838",
                ExemploPratico = "Próxima Centauri: p=0,7687″ → d = 1/0,7687 = 1,30 pc = 4,24 anos-luz",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Paralaxe (segundos de arco)", ValorPadrao = 0.7687, ValorMin = 0.0001 },
                ],
                VariavelResultado = "d (parsec)",
                UnidadeResultado = "pc",
                Calcular = vars => 1.0 / vars["p"]
            },
            new Formula
            {
                Id = "7_ast07", Nome = "Lei de Wien (Pico de Emissão)", Categoria = "Astronomia",
                Expressao = "λ_max = b / T",
                ExprTexto = "λmax = 2,898×10⁶ nm·K / T",
                Icone = "λ_max",
                Descricao = "Comprimento de onda do pico de emissão de corpo negro. b = 2,898×10⁶ nm·K. Estrelas quentes → azul, frias → vermelha.",
                Criador = "Wilhelm Wien (1893)",
                AnoOrigin = "1893",
                ExemploPratico = "Sol T=5778K: λmax = 2.898.000/5778 = 501 nm (verde-amarelo)",
                Variaveis = [
                    new() { Simbolo = "T", Nome = "Temperatura (K)", ValorPadrao = 5778, ValorMin = 1 },
                ],
                VariavelResultado = "λ_max (nm)",
                UnidadeResultado = "nm",
                Calcular = vars => 2898000.0 / vars["T"]
            },

            // ═══ GEOFÍSICA (4 fórmulas) ═══

            new Formula
            {
                Id = "7_gfis01", Nome = "Escala de Magnitude (Richter)", Categoria = "Geofísica",
                Expressao = "M_L = log₁₀(A) − log₁₀(A₀(δ))",
                ExprTexto = "ML = log₁₀(A/A₀)  amplitude em µm",
                Icone = "🌋",
                Descricao = "Magnitude sísmica local (Richter): logaritmo da amplitude máxima normalizada. Cada unidade = 10× mais amplitude, 31,6× mais energia.",
                Criador = "Charles Richter (1935)",
                AnoOrigin = "1935",
                ExemploPratico = "A=10.000 µm, A₀=1 µm: ML = log(10000) = 4,0",
                Variaveis = [
                    new() { Simbolo = "A", Nome = "Amplitude (µm)", ValorPadrao = 10000, ValorMin = 0.001 },
                    new() { Simbolo = "A0", Nome = "Amplitude ref. A₀ (µm)", ValorPadrao = 1, ValorMin = 0.001 },
                ],
                VariavelResultado = "ML",
                Calcular = vars => Math.Log10(vars["A"] / vars["A0"])
            },
            new Formula
            {
                Id = "7_gfis02", Nome = "Anomalia Gravitacional de Bouguer", Categoria = "Geofísica",
                Expressao = "Δg_B = g_obs − g_teórica + CF − 2πGρh",
                ExprTexto = "ΔgB = gobs − gteórica + corr.ar_livre − corr.Bouguer",
                Icone = "Δg",
                Descricao = "Anomalia de Bouguer: diferença entre gravidade observada e teórica após correções de elevação e massa intermediária.",
                Criador = "Pierre Bouguer (1749); gravimetria",
                AnoOrigin = "1749",
                ExemploPratico = "gobs=9,7895, gteor=9,8065, h=500m, ρ=2670: ΔgB (com correções) ≈ −30 mGal",
                Variaveis = [
                    new() { Simbolo = "gobs", Nome = "Gravidade observada (m/s²)", ValorPadrao = 9.7895 },
                    new() { Simbolo = "gteor", Nome = "Gravidade teórica (m/s²)", ValorPadrao = 9.8065 },
                    new() { Simbolo = "h", Nome = "Elevação (m)", ValorPadrao = 500 },
                    new() { Simbolo = "rho", Nome = "Densidade (kg/m³)", ValorPadrao = 2670 },
                ],
                VariavelResultado = "Δg_B (m/s²)",
                UnidadeResultado = "m/s²",
                Calcular = vars => vars["gobs"] - vars["gteor"] + 0.3086e-3 * vars["h"] - 2 * Math.PI * 6.674e-11 * vars["rho"] * vars["h"]
            },
            new Formula
            {
                Id = "7_gfis03", Nome = "Fluxo de Calor Geotérmico", Categoria = "Geofísica",
                Expressao = "q = k · (dT/dz)",
                ExprTexto = "q = k × gradiente geotérmico",
                Icone = "🌡",
                Descricao = "Fluxo de calor da Terra: condutividade × gradiente térmico. Gradiente médio: ~25°C/km. Fluxo médio: ~65 mW/m².",
                Criador = "Fourier (condução); geotermia moderna",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "k=3 W/mK, gradiente=30°C/km=0,03°C/m: q = 3×0,03 = 0,09 W/m² = 90 mW/m²",
                Variaveis = [
                    new() { Simbolo = "k", Nome = "Condutividade (W/m·K)", ValorPadrao = 3 },
                    new() { Simbolo = "dTdz", Nome = "Gradiente (°C/m)", ValorPadrao = 0.03 },
                ],
                VariavelResultado = "q (W/m²)",
                UnidadeResultado = "W/m²",
                Calcular = vars => vars["k"] * vars["dTdz"]
            },
            new Formula
            {
                Id = "7_gfis04", Nome = "Velocidade de Onda Sísmica", Categoria = "Geofísica",
                Expressao = "Vp = √((K + 4G/3) / ρ)",
                ExprTexto = "Vp = √((K + 4G/3) / ρ)  onda P",
                Icone = "Vp",
                Descricao = "Velocidade de onda compressional (P). K = módulo de incompressibilidade, G = módulo de cisalhamento. Vp > Vs sempre.",
                Criador = "Poisson / Stokes; sismologia moderna (Séc. XX)",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Granito: K=50 GPa, G=30 GPa, ρ=2700: Vp = √((50e9+40e9)/2700) = 5744 m/s",
                Variaveis = [
                    new() { Simbolo = "K", Nome = "Módulo de compressibilidade K (Pa)", ValorPadrao = 50e9 },
                    new() { Simbolo = "G", Nome = "Módulo de cisalhamento G (Pa)", ValorPadrao = 30e9 },
                    new() { Simbolo = "rho", Nome = "Densidade (kg/m³)", ValorPadrao = 2700, ValorMin = 1 },
                ],
                VariavelResultado = "Vp (m/s)",
                UnidadeResultado = "m/s",
                Calcular = vars => Math.Sqrt((vars["K"] + 4.0 * vars["G"] / 3.0) / vars["rho"])
            },

            // ═══ GEOQUÍMICA (1 fórmula) ═══

            new Formula
            {
                Id = "7_gqm01", Nome = "Datação Radiométrica", Categoria = "Geoquímica",
                Expressao = "t = (1/λ) · ln(1 + D/P)",
                ExprTexto = "t = ln(1 + D/P) / λ",
                Icone = "⏳",
                Descricao = "Idade de rocha/mineral por decaimento radioativo. D = átomos filhos, P = átomos pais, λ = constante de decaimento. ¹⁴C: t½=5730 anos.",
                Criador = "Ernest Rutherford (1905); Boltwood (1907)",
                AnoOrigin = "1905",
                ExemploPratico = "¹⁴C: D/P=0,5, λ=1,21×10⁻⁴/ano: t = ln(1,5)/1,21e-4 = 3352 anos",
                Variaveis = [
                    new() { Simbolo = "D", Nome = "Razão D (filhos)", ValorPadrao = 0.5 },
                    new() { Simbolo = "P", Nome = "Razão P (pais)", ValorPadrao = 1, ValorMin = 0.001 },
                    new() { Simbolo = "lambda", Nome = "Constante de decaimento λ (/ano)", ValorPadrao = 1.21e-4, ValorMin = 1e-20 },
                ],
                VariavelResultado = "t (anos)",
                UnidadeResultado = "anos",
                Calcular = vars => Math.Log(1 + vars["D"] / vars["P"]) / vars["lambda"]
            },

            // ═══ OCEANOGRAFIA (2 fórmulas) ═══

            new Formula
            {
                Id = "7_ocn01", Nome = "Equação de Estado da Água do Mar", Categoria = "Oceanografia",
                Expressao = "ρ = ρ₀ + α·S − β·T",
                ExprTexto = "ρ ≈ ρ₀ + α×Salinidade − β×Temperatura  (simplificada)",
                Icone = "🌊",
                Descricao = "Densidade da água do mar depende de temperatura, salinidade e pressão. Forma simplificada linear. EOS-80 e TEOS-10 são versões completas.",
                Criador = "UNESCO/IOC; TEOS-10 (2010)",
                AnoOrigin = "2010",
                ExemploPratico = "ρ₀=1000, S=35 PSU, T=15°C, α=0,8, β=0,2: ρ = 1000+28−3 = 1025 kg/m³",
                Variaveis = [
                    new() { Simbolo = "rho0", Nome = "Densidade referência (kg/m³)", ValorPadrao = 1000 },
                    new() { Simbolo = "alpha", Nome = "Coef. salinidade α", ValorPadrao = 0.8 },
                    new() { Simbolo = "S", Nome = "Salinidade (PSU)", ValorPadrao = 35 },
                    new() { Simbolo = "beta", Nome = "Coef. temperatura β", ValorPadrao = 0.2 },
                    new() { Simbolo = "T", Nome = "Temperatura (°C)", ValorPadrao = 15 },
                ],
                VariavelResultado = "ρ (kg/m³)",
                UnidadeResultado = "kg/m³",
                Calcular = vars => vars["rho0"] + vars["alpha"] * vars["S"] - vars["beta"] * vars["T"]
            },
            new Formula
            {
                Id = "7_ocn02", Nome = "Velocidade de Onda Oceânica", Categoria = "Oceanografia",
                Expressao = "c = √(g · h)  (águas rasas)",
                ExprTexto = "c = √(g × h)  para ondas longas/tsunami",
                Icone = "🌊",
                Descricao = "Velocidade de fase de onda em águas rasas (L >> h). Para tsunami: h oceânico ~4000m → c ≈ 200 m/s = 720 km/h.",
                Criador = "Lagrange (1788); teoria de ondas de longo período",
                AnoOrigin = "1788",
                ExemploPratico = "Tsunami em oceano profundo h=4000m: c = √(9,81×4000) = 198 m/s = 713 km/h",
                Variaveis = [
                    new() { Simbolo = "h", Nome = "Profundidade (m)", ValorPadrao = 4000 },
                ],
                VariavelResultado = "c (m/s)",
                UnidadeResultado = "m/s",
                Calcular = vars => Math.Sqrt(9.80665 * vars["h"])
            },

            // ═══ FÍSICA NUCLEAR (3 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_fnc01", Nome = "Equação de Decaimento Radioativo", Categoria = "Física Nuclear",
                Expressao = "N(t) = N₀ · e^(−λt)",
                ExprTexto = "N(t) = N₀ × e^(−λt)  ou N₀ × (½)^(t/t½)",
                Icone = "☢",
                Descricao = "Número de átomos que restam após tempo t. λ = ln(2)/t½. Cada meia-vida reduz N pela metade.",
                Criador = "Ernest Rutherford & Frederick Soddy (1902)",
                AnoOrigin = "1902",
                ExemploPratico = "¹³¹I: t½=8 dias, N₀=10⁶, t=24 dias: N = 10⁶×e^(−0,0866×24) = 125.000",
                Variaveis = [
                    new() { Simbolo = "N0", Nome = "Quantidade inicial (N₀)", ValorPadrao = 1000000 },
                    new() { Simbolo = "lambda", Nome = "Constante de decaimento λ", ValorPadrao = 0.0866 },
                    new() { Simbolo = "t", Nome = "Tempo (t)", ValorPadrao = 24 },
                ],
                VariavelResultado = "N(t)",
                Calcular = vars => vars["N0"] * Math.Exp(-vars["lambda"] * vars["t"])
            },
            new Formula
            {
                Id = "7_fnc02", Nome = "Equivalência Massa-Energia", Categoria = "Física Nuclear",
                Expressao = "E = Δm · c²",
                ExprTexto = "E = Δm × c²  (c = 3×10⁸ m/s)",
                Icone = "E=mc²",
                Descricao = "Energia liberada na conversão de massa em energia. Base da fissão e fusão nuclear. 1 u (u.m.a.) = 931,5 MeV.",
                Criador = "Albert Einstein (1905)",
                AnoOrigin = "1905",
                ExemploPratico = "Fissão U-235: Δm ≈ 0,186 u: E = 0,186×931,5 = 173 MeV por fissão",
                Variaveis = [
                    new() { Simbolo = "dm", Nome = "Defeito de massa (kg)", ValorPadrao = 3.09e-28 },
                ],
                VariavelResultado = "E (J)",
                UnidadeResultado = "J",
                Calcular = vars => vars["dm"] * 2.998e8 * 2.998e8
            },
            new Formula
            {
                Id = "7_fnc03", Nome = "Seção de Choque Nuclear", Categoria = "Física Nuclear",
                Expressao = "R = σ · Φ · N",
                ExprTexto = "R = σ × Φ × N  (taxa de reação)",
                Icone = "σ_n",
                Descricao = "Taxa de reação nuclear: σ = seção de choque (barn = 10⁻²⁸ m²), Φ = fluxo de nêutrons, N = número de átomos alvo.",
                Criador = "Enrico Fermi (1930s); física de reatores",
                AnoOrigin = "1930s",
                ExemploPratico = "σ=585 barn, Φ=10¹⁴ n/cm²s, N=10²⁴: R = 585e-24×10¹⁴×10²⁴ = 5,85×10¹⁶ fissões/s",
                Variaveis = [
                    new() { Simbolo = "sigma", Nome = "Seção de choque (m²)", ValorPadrao = 585e-28 },
                    new() { Simbolo = "Phi", Nome = "Fluxo de nêutrons (n/m²s)", ValorPadrao = 1e18 },
                    new() { Simbolo = "N", Nome = "Número de átomos alvo", ValorPadrao = 1e24 },
                ],
                VariavelResultado = "R (reações/s)",
                UnidadeResultado = "reações/s",
                Calcular = vars => vars["sigma"] * vars["Phi"] * vars["N"]
            },

            // ═══ FÍSICA DE PLASMAS (2 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_fpl01", Nome = "Frequência de Plasma", Categoria = "Física de Plasmas",
                Expressao = "ωp = √(n_e · e² / (ε₀ · mₑ))",
                ExprTexto = "ωp = √(ne × e² / (ε₀ × me))",
                Icone = "ωp",
                Descricao = "Frequência natural de oscilação dos elétrons no plasma. Ondas EM com ω < ωp não se propagam no plasma.",
                Criador = "Irving Langmuir (1928); Tonks & Langmuir",
                AnoOrigin = "1928",
                ExemploPratico = "Ionosfera ne=10¹² m⁻³: ωp = √(10¹²×(1,6e-19)²/(8,85e-12×9,1e-31)) ≈ 56 MHz",
                Variaveis = [
                    new() { Simbolo = "ne", Nome = "Densidade eletrônica (m⁻³)", ValorPadrao = 1e12 },
                ],
                VariavelResultado = "ωp (rad/s)",
                UnidadeResultado = "rad/s",
                Calcular = vars => Math.Sqrt(vars["ne"] * 1.602e-19 * 1.602e-19 / (8.854e-12 * 9.109e-31))
            },
            new Formula
            {
                Id = "7_fpl02", Nome = "Comprimento de Debye", Categoria = "Física de Plasmas",
                Expressao = "λ_D = √(ε₀·kT / (n_e·e²))",
                ExprTexto = "λD = √(ε₀kT / nee²)",
                Icone = "λD",
                Descricao = "Escala de blindagem eletrostática no plasma. Para distâncias > λD, o campo é blindado. Plasma: λD << dimensões do sistema.",
                Criador = "Peter Debye (1923); teoria de Debye-Hückel",
                AnoOrigin = "1923",
                ExemploPratico = "Tokamak: T=10⁸K, ne=10²⁰m⁻³: λD ≈ 7×10⁻⁵ m = 0,07 mm",
                Variaveis = [
                    new() { Simbolo = "T", Nome = "Temperatura (K)", ValorPadrao = 1e8 },
                    new() { Simbolo = "ne", Nome = "Densidade eletrônica (m⁻³)", ValorPadrao = 1e20, ValorMin = 1 },
                ],
                VariavelResultado = "λD (m)",
                UnidadeResultado = "m",
                Calcular = vars => Math.Sqrt(8.854e-12 * 1.381e-23 * vars["T"] / (vars["ne"] * 1.602e-19 * 1.602e-19))
            },

            // ═══ ELETROQUÍMICA (1 fórmula) ═══

            new Formula
            {
                Id = "7_elq01", Nome = "Equação de Nernst", Categoria = "Eletroquímica",
                Expressao = "E = E° − (RT/nF) · ln(Q)",
                ExprTexto = "E = E° − (0,0257/n)×ln(Q)  a 25°C",
                Icone = "E°",
                Descricao = "Potencial de célula eletroquímica fora do equilíbrio. E° = potencial padrão, Q = quociente de reação, n = elétrons, F = 96485 C/mol.",
                Criador = "Walther Nernst (1889)",
                AnoOrigin = "1889",
                ExemploPratico = "Pilha Daniell: E°=1,10V, n=2, Q=0,1: E = 1,10−(0,0257/2)×ln(0,1) = 1,13V",
                Variaveis = [
                    new() { Simbolo = "E0", Nome = "Potencial padrão E° (V)", ValorPadrao = 1.10 },
                    new() { Simbolo = "n", Nome = "Nº de elétrons", ValorPadrao = 2, ValorMin = 1 },
                    new() { Simbolo = "Q", Nome = "Quociente de reação (Q)", ValorPadrao = 0.1, ValorMin = 1e-20 },
                    new() { Simbolo = "T", Nome = "Temperatura (K)", ValorPadrao = 298.15 },
                ],
                VariavelResultado = "E (V)",
                UnidadeResultado = "V",
                Calcular = vars => vars["E0"] - (8.314 * vars["T"] / (vars["n"] * 96485)) * Math.Log(vars["Q"])
            },

            // ═══ SEMICONDUTORES (1 fórmula) — adicionada à categoria existente ═══

            new Formula
            {
                Id = "7_sem01", Nome = "Equação de Shockley (Diodo)", Categoria = "Dispositivos Semicondutores",
                Expressao = "I = Is · (e^(V/nVT) − 1)",
                ExprTexto = "I = Is × (e^(V/(nVT)) − 1)",
                Icone = "🔌",
                Descricao = "Corrente em diodo semicondutor. Is = corrente de saturação reversa, VT = kT/q ≈ 26mV a 300K, n = fator de idealidade (1-2).",
                Criador = "William Shockley (1949)",
                AnoOrigin = "1949",
                ExemploPratico = "Si: Is=10⁻¹² A, V=0,7V, n=1, VT=0,026V: I = 10⁻¹²×(e²⁶·⁹−1) ≈ 0,5 A",
                Variaveis = [
                    new() { Simbolo = "Is", Nome = "Corrente de saturação (A)", ValorPadrao = 1e-12 },
                    new() { Simbolo = "V", Nome = "Tensão aplicada (V)", ValorPadrao = 0.7 },
                    new() { Simbolo = "n", Nome = "Fator de idealidade", ValorPadrao = 1 },
                    new() { Simbolo = "VT", Nome = "Tensão térmica VT (V)", ValorPadrao = 0.026, ValorMin = 0.001 },
                ],
                VariavelResultado = "I (A)",
                UnidadeResultado = "A",
                Calcular = vars => vars["Is"] * (Math.Exp(vars["V"] / (vars["n"] * vars["VT"])) - 1)
            },

            // ═══ CIÊNCIA DOS MATERIAIS (4 fórmulas) ═══

            new Formula
            {
                Id = "7_cmt01", Nome = "Equação de Hall-Petch", Categoria = "Ciência dos Materiais",
                Expressao = "σ_y = σ₀ + k / √d",
                ExprTexto = "σy = σ₀ + k / √d",
                Icone = "σ_y",
                Descricao = "Limite de escoamento aumenta com a redução do tamanho de grão. σ₀ = tensão de atrito da rede, k = constante, d = diâmetro de grão.",
                Criador = "E.O. Hall (1951) / N.J. Petch (1953)",
                AnoOrigin = "1951",
                ExemploPratico = "Aço: σ₀=70 MPa, k=0,74 MPa·m½, d=50 µm: σy = 70+0,74/√(5e-5) = 70+105 = 175 MPa",
                Variaveis = [
                    new() { Simbolo = "s0", Nome = "Tensão base σ₀ (MPa)", ValorPadrao = 70 },
                    new() { Simbolo = "k", Nome = "Constante k (MPa·m^½)", ValorPadrao = 0.74 },
                    new() { Simbolo = "d", Nome = "Tamanho de grão (m)", ValorPadrao = 50e-6, ValorMin = 1e-9 },
                ],
                VariavelResultado = "σ_y (MPa)",
                UnidadeResultado = "MPa",
                Calcular = vars => vars["s0"] + vars["k"] / Math.Sqrt(vars["d"])
            },
            new Formula
            {
                Id = "7_cmt02", Nome = "Difusão (Arrhenius de Difusão)", Categoria = "Ciência dos Materiais",
                Expressao = "D = D₀ · e^(−Q/(R·T))",
                ExprTexto = "D = D₀ × e^(−Q/RT)",
                Icone = "D",
                Descricao = "Coeficiente de difusão tipo Arrhenius. D₀ = fator pré-exponencial, Q = energia de ativação, R = 8,314 J/(mol·K).",
                Criador = "Arrhenius / Fick; materiais: Kirkendall (1947)",
                AnoOrigin = "1855",
                ExemploPratico = "C em Fe-γ: D₀=2,3×10⁻⁵m²/s, Q=148 kJ/mol, T=1273K: D ≈ 2,1×10⁻¹¹ m²/s",
                Variaveis = [
                    new() { Simbolo = "D0", Nome = "Fator D₀ (m²/s)", ValorPadrao = 2.3e-5 },
                    new() { Simbolo = "Q", Nome = "Energia de ativação (J/mol)", ValorPadrao = 148000 },
                    new() { Simbolo = "T", Nome = "Temperatura (K)", ValorPadrao = 1273, ValorMin = 1 },
                ],
                VariavelResultado = "D (m²/s)",
                UnidadeResultado = "m²/s",
                Calcular = vars => vars["D0"] * Math.Exp(-vars["Q"] / (8.314 * vars["T"]))
            },
            new Formula
            {
                Id = "7_cmt03", Nome = "Tensão de Orowan (Endurecimento por Precipitação)", Categoria = "Ciência dos Materiais",
                Expressao = "Δσ = M · G · b / λ",
                ExprTexto = "Δσ = M × G × b / λ  (espaçamento entre precipitados)",
                Icone = "Orowan",
                Descricao = "Incremento de tensão por obstáculo a discordâncias. M = fator de Taylor (~3,06), G = módulo, b = vetor de Burgers, λ = espaçamento.",
                Criador = "Egon Orowan (1948)",
                AnoOrigin = "1948",
                ExemploPratico = "Al: M=3,06, G=26 GPa, b=0,286nm, λ=50nm: Δσ = 3,06×26e9×0,286e-9/50e-9 = 456 MPa",
                Variaveis = [
                    new() { Simbolo = "Mf", Nome = "Fator de Taylor (M)", ValorPadrao = 3.06 },
                    new() { Simbolo = "G", Nome = "Módulo de cisalhamento (Pa)", ValorPadrao = 26e9 },
                    new() { Simbolo = "b", Nome = "Vetor de Burgers (m)", ValorPadrao = 0.286e-9 },
                    new() { Simbolo = "lam", Nome = "Espaçamento λ (m)", ValorPadrao = 50e-9, ValorMin = 1e-12 },
                ],
                VariavelResultado = "Δσ (Pa)",
                UnidadeResultado = "Pa",
                Calcular = vars => vars["Mf"] * vars["G"] * vars["b"] / vars["lam"]
            },
            new Formula
            {
                Id = "7_cmt04", Nome = "Fração Transformada (Avrami)", Categoria = "Ciência dos Materiais",
                Expressao = "X(t) = 1 − e^(−k·tⁿ)",
                ExprTexto = "X(t) = 1 − e^(−ktⁿ)  (JMAK)",
                Icone = "JMAK",
                Descricao = "Cinética de transformação de fase (Johnson-Mehl-Avrami-Kolmogorov). k = taxa, n = expoente de Avrami (tipo de nucleação e crescimento).",
                Criador = "Johnson & Mehl (1939) / Avrami (1939-1941)",
                AnoOrigin = "1939",
                ExemploPratico = "k=0,001, n=3, t=10: X = 1−e^(−0,001×1000) = 1−e⁻¹ = 0,632 (63,2%)",
                Variaveis = [
                    new() { Simbolo = "k", Nome = "Constante k", ValorPadrao = 0.001 },
                    new() { Simbolo = "nExp", Nome = "Expoente de Avrami (n)", ValorPadrao = 3 },
                    new() { Simbolo = "t", Nome = "Tempo (t)", ValorPadrao = 10 },
                ],
                VariavelResultado = "X(t)",
                Calcular = vars => 1.0 - Math.Exp(-vars["k"] * Math.Pow(vars["t"], vars["nExp"]))
            },

            // ═══ COSMOLOGIA (1 fórmula) — adicionada à categoria existente ═══

            new Formula
            {
                Id = "7_cos01", Nome = "Equação de Friedmann", Categoria = "Cosmologia Inflacionária",
                Expressao = "H² = (8πG/3)ρ − kc²/a²",
                ExprTexto = "H² = (8πG/3)ρ − kc²/a²  (dinâmica do universo)",
                Icone = "H²",
                Descricao = "Equação que governa a expansão do universo. H = parâmetro de Hubble, ρ = densidade total, k = curvatura, a = fator de escala.",
                Criador = "Alexander Friedmann (1922); Georges Lemaître (1927)",
                AnoOrigin = "1922",
                ExemploPratico = "Universo plano (k=0): H² = 8πG×ρcr/3 → ρcr = 3H²/(8πG) ≈ 9,5×10⁻²⁷ kg/m³",
                Variaveis = [
                    new() { Simbolo = "rho", Nome = "Densidade ρ (kg/m³)", ValorPadrao = 9.5e-27 },
                ],
                VariavelResultado = "H (1/s)",
                UnidadeResultado = "1/s",
                Calcular = vars => Math.Sqrt(8 * Math.PI * 6.674e-11 / 3.0 * vars["rho"])
            },

            // ═══ ANÁLISE HARMÔNICA (2 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_ahr01", Nome = "Série de Fourier (Coeficientes)", Categoria = "Análise Harmônica",
                Expressao = "f(t) = a₀/2 + Σ[aₙcos(nωt) + bₙsin(nωt)]",
                ExprTexto = "f(t) = a₀/2 + Σ aₙcos(nωt) + bₙsin(nωt)",
                Icone = "∿",
                Descricao = "Decomposição de f(t) periódica em senos e cossenos. aₙ e bₙ calculados por integrais no período. Base de análise espectral.",
                Criador = "Joseph Fourier (1822)",
                AnoOrigin = "1822",
                ExemploPratico = "Onda quadrada: a₀=0, aₙ=0, bₙ=(4/nπ) para n ímpar → harmonicas ímpares",
                Variaveis = [
                    new() { Simbolo = "a0", Nome = "Coef. a₀ (DC)", ValorPadrao = 0 },
                    new() { Simbolo = "a1", Nome = "Coef. a₁ (cos)", ValorPadrao = 0 },
                    new() { Simbolo = "b1", Nome = "Coef. b₁ (sin)", ValorPadrao = 1.273 },
                    new() { Simbolo = "omega", Nome = "Frequência ω (rad/s)", ValorPadrao = 6.283 },
                    new() { Simbolo = "t", Nome = "Tempo (s)", ValorPadrao = 0.25 },
                ],
                VariavelResultado = "f(t) (1ª harmônica)",
                Calcular = vars => vars["a0"] / 2 + vars["a1"] * Math.Cos(vars["omega"] * vars["t"]) + vars["b1"] * Math.Sin(vars["omega"] * vars["t"])
            },
            new Formula
            {
                Id = "7_ahr02", Nome = "Transformada de Fourier (DFT)", Categoria = "Análise Harmônica",
                Expressao = "X[k] = Σ x[n]·e^(−j2πkn/N)",
                ExprTexto = "X[k] = Σ x[n] × e^(−j2πkn/N)  para n=0..N−1",
                Icone = "FFT",
                Descricao = "DFT converte sinal discreto do domínio do tempo para o domínio da frequência. FFT (Cooley-Tukey) calcula em O(N log N).",
                Criador = "Cooley & Tukey (FFT, 1965); base: Gauss (~1805)",
                AnoOrigin = "1965",
                ExemploPratico = "N=4, x=[1,0,−1,0]: X[0]=0, X[1]=2, X[2]=0, X[3]=2 → frequência fundamental",
                Variaveis = [
                    new() { Simbolo = "N", Nome = "Número de pontos", ValorPadrao = 1024 },
                    new() { Simbolo = "fs", Nome = "Frequência de amostragem (Hz)", ValorPadrao = 44100 },
                ],
                VariavelResultado = "Δf (resolução em freq., Hz)",
                UnidadeResultado = "Hz",
                Calcular = vars => vars["fs"] / vars["N"]
            },
        ]);
    }
}
