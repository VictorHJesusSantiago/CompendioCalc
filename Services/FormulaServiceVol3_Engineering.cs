using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 3 — PARTE IV: ENGENHARIA AVANÇADA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 15. MECÂNICA DA FRATURA
    // ─────────────────────────────────────────────────────
    private void AdicionarMecanicaFratura()
    {
        _formulas.AddRange([
            // 15.1 LEFM
            new Formula
            {
                Id = "3_mf01", Nome = "Fator de Intensidade de Tensão (SIF)", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "K_I = σ√(πa)·Y",
                ExprTexto = "KI = σ√(πa)·Y",
                Icone = "KI",
                Descricao = "Fator de intensidade de tensão em modo I (abertura). σ=tensão remota, a=meia-trinca, Y=fator geométrico (~1 para placa infinita). Governa campo de tensões na ponta da trinca.",
                Criador = "George Irwin",
                AnoOrigin = "1957",
                Variaveis = [
                    new() { Simbolo = "sigma", Nome = "σ (MPa)", ValorPadrao = 100, ValorMin = 0 },
                    new() { Simbolo = "a", Nome = "a (m)", Descricao = "Meia-trinca", ValorPadrao = 0.01, ValorMin = 0 },
                    new() { Simbolo = "Y", Nome = "Y (fator geométrico)", ValorPadrao = 1 },
                ],
                VariavelResultado = "KI (MPa√m)",
                UnidadeResultado = "MPa√m",
                Calcular = v => v["sigma"] * Math.Sqrt(Math.PI * v["a"]) * v["Y"]
            },
            new Formula
            {
                Id = "3_mf02", Nome = "Critério de Fratura (KIC)", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "K_I ≥ K_IC  ⟹  fratura",
                ExprTexto = "KI ≥ KIC ⟹ fratura",
                Icone = "KIC",
                Descricao = "KIC = tenacidade à fratura: propriedade do material (ex.: aço 50-200, alumínio 20-45, cerâmica 1-5 MPa√m). Quando KI atinge KIC, a trinca propaga catastroficamente.",
                Criador = "George Irwin",
                AnoOrigin = "1957",
            },
            new Formula
            {
                Id = "3_mf03", Nome = "Taxa de Liberação de Energia G", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "G = K²/E'  (E'=E p/ tensão plana; E'=E/(1-ν²) deformação plana)",
                ExprTexto = "G = KI²/E'",
                Icone = "G",
                Descricao = "Energia disponível por unidade de área para propagar a trinca. G=GIC é critério equivalente a K=KIC. Relação entre Irwin (K) e Griffith (G).",
                Criador = "A.A. Griffith / G. Irwin",
                AnoOrigin = "1921/1957",
                Variaveis = [
                    new() { Simbolo = "KI", Nome = "KI (MPa√m)", ValorPadrao = 50 },
                    new() { Simbolo = "E", Nome = "E (GPa)", ValorPadrao = 200 },
                ],
                VariavelResultado = "G (kJ/m²)",
                UnidadeResultado = "kJ/m²",
                Calcular = v => (v["KI"] * v["KI"]) / (v["E"] * 1000) // KI² / E  (MPa²·m / GPa = kJ/m²)
            },
            new Formula
            {
                Id = "3_mf04", Nome = "Critério de Griffith", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "σ_crit = √(2Eγs/(πa))",
                ExprTexto = "σ_fratura = √(2Eγs/(πa))",
                Icone = "σf",
                Descricao = "Tensão crítica de Griffith: equilíbrio entre energia elástica liberada e energia de superfície criada. Balanço energético da fratura frágil.",
                Criador = "Alan Arnold Griffith",
                AnoOrigin = "1921",
            },
            new Formula
            {
                Id = "3_mf05", Nome = "Integral J", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "J = ∫_Γ (W dy - T·∂u/∂x ds)",
                ExprTexto = "J = ∫_Γ (Wdy − T⃗·∂u⃗/∂x ds)",
                Icone = "J",
                Descricao = "Generalização de G para elastoplasticidade. Independente do caminho Γ. J=G no caso elástico linear; J=JIC define início de crescimento na fratura dúctil.",
                Criador = "James R. Rice",
                AnoOrigin = "1968",
            },
            new Formula
            {
                Id = "3_mf06", Nome = "Campo na Ponta da Trinca (HRR)", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "σᵢⱼ = σ₀(J/(ασ₀ε₀Iₙr))^(1/(n+1)) σ̃ᵢⱼ(θ,n)",
                ExprTexto = "σᵢⱼ ∼ (J/(r))^(1/(n+1)) · f(θ)",
                Icone = "HRR",
                Descricao = "Solução de Hutchinson-Rice-Rosengren para ponta de trinca elastoplástica (lei de potência). Singularidade r^(-1/(n+1)) mais fraca que elástica r^(-1/2).",
                Criador = "Hutchinson / Rice & Rosengren",
                AnoOrigin = "1968",
            },
            new Formula
            {
                Id = "3_mf07", Nome = "CTOD (Abertura de Ponta de Trinca)", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "δ = K²/(σY·E)  ou  δ = J/σY",
                ExprTexto = "δ = KI²/(σY·E)  ≈  J/σY",
                Icone = "δ",
                Descricao = "Abertura da trinca na ponta: parâmetro alternativo a K ou J. Diretamente mensurável. δ_c = CTOD crítico para início de fratura.",
                Criador = "Alan Wells",
                AnoOrigin = "1961",
            },
            new Formula
            {
                Id = "3_mf08", Nome = "Zona Plástica (Irwin)", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "r_p = (1/2π)(K/σY)² (tensão plana); r_p = (1/6π)(K/σY)² (deformação plana)",
                ExprTexto = "rp = (KI/σY)²/(2π) (tensão plana)",
                Icone = "rp",
                Descricao = "Tamanho estimado da zona de deformação plástica na ponta da trinca. LEFM válida quando rp ≪ a (trinca total). Caso contrário → EPFM (Integral J).",
                Criador = "George Irwin",
                AnoOrigin = "1961",
            },
            new Formula
            {
                Id = "3_mf09", Nome = "Limite de Validade da LEFM", Categoria = "Mecânica da Fratura", SubCategoria = "LEFM",
                Expressao = "a, B, W-a ≥ 2.5(K_IC/σ_Y)²",
                ExprTexto = "a, B, W−a ≥ 2.5(KIC/σY)²",
                Icone = "✓",
                Descricao = "Condição para que KIC seja propriedade do material (estado plano de deformação). B=espessura, W-a=ligamento. ASTM E399.",
                Criador = "ASTM E399",
            },
            // 15.2 Fadiga
            new Formula
            {
                Id = "3_fd01", Nome = "Curva S-N (Wöhler)", Categoria = "Mecânica da Fratura", SubCategoria = "Fadiga",
                Expressao = "S = A·N^(-b)  ou  log N = C - m·log S",
                ExprTexto = "S = A·Nᵇ⁻  (σ vs ciclos)",
                Icone = "S-N",
                Descricao = "Relação tensão-vida: quanto maior S, menor N (ciclos até falha). Aço tem limite de fadiga (~10⁷ ciclos). Alumínio não (sempre falha).",
                Criador = "August Wöhler",
                AnoOrigin = "1860",
            },
            new Formula
            {
                Id = "3_fd02", Nome = "Diagrama de Goodman", Categoria = "Mecânica da Fratura", SubCategoria = "Fadiga",
                Expressao = "σa/Se + σm/Su = 1",
                ExprTexto = "σa/Se + σm/Su = 1",
                Icone = "GMa",
                Descricao = "Combinação de tensão alternada σa e tensão média σm. Dentro da linha → seguro. Se=limite de fadiga, Su=resistência última. Conservador e muito usado.",
                Criador = "John Goodman",
                AnoOrigin = "1899",
                Variaveis = [
                    new() { Simbolo = "sigma_a", Nome = "σa (MPa)", ValorPadrao = 200 },
                    new() { Simbolo = "Se", Nome = "Se (MPa)", Descricao = "Limite de fadiga", ValorPadrao = 400 },
                    new() { Simbolo = "sigma_m", Nome = "σm (MPa)", Descricao = "Tensão média", ValorPadrao = 100 },
                    new() { Simbolo = "Su", Nome = "Su (MPa)", Descricao = "Resistência última", ValorPadrao = 800 },
                ],
                VariavelResultado = "Fator de segurança",
                Calcular = v => 1.0 / (v["sigma_a"] / v["Se"] + v["sigma_m"] / v["Su"])
            },
            new Formula
            {
                Id = "3_fd03", Nome = "Lei de Paris (Propagação de Trinca)", Categoria = "Mecânica da Fratura", SubCategoria = "Fadiga",
                Expressao = "da/dN = C·(ΔK)^m",
                ExprTexto = "da/dN = C·(ΔK)ᵐ",
                Icone = "da/dN",
                Descricao = "Taxa de crescimento de trinca por fadiga. C e m são constantes do material (m≈2-4 para aço). Região linear no log-log entre ΔKth e KIC.",
                Criador = "Paul Paris / Fazil Erdogan",
                AnoOrigin = "1963",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "C (constante)", ValorPadrao = 1e-12 },
                    new() { Simbolo = "DeltaK", Nome = "ΔK (MPa√m)", ValorPadrao = 20 },
                    new() { Simbolo = "m", Nome = "m (expoente)", ValorPadrao = 3 },
                ],
                VariavelResultado = "da/dN (m/ciclo)",
                UnidadeResultado = "m/ciclo",
                Calcular = v => v["C"] * Math.Pow(v["DeltaK"], v["m"])
            },
            new Formula
            {
                Id = "3_fd04", Nome = "Vida Residual (Integração de Paris)", Categoria = "Mecânica da Fratura", SubCategoria = "Fadiga",
                Expressao = "N = ∫ₐᵢ^ₐf da/(C(ΔK(a))^m)",
                ExprTexto = "N = ∫_{aᵢ}^{af} da/(C·(ΔK)ᵐ)",
                Icone = "Nf",
                Descricao = "Número de ciclos para a trinca crescer de aᵢ (inicial) a af (crítica, quando K=KIC). Integração numérica de Paris. Base de manutenção por inspeção (damage tolerance).",
                Criador = "Mecânica de fratura aplicada",
            },
            new Formula
            {
                Id = "3_fd05", Nome = "Regra de Miner (Dano Cumulativo)", Categoria = "Mecânica da Fratura", SubCategoria = "Fadiga",
                Expressao = "D = Σ nᵢ/Nᵢ;  D ≥ 1 ⟹ falha",
                ExprTexto = "D = Σ nᵢ/Nᵢ;  D≥1 → falha",
                Icone = "D",
                Descricao = "Dano cumulativo linear: cada bloco de nᵢ ciclos a σᵢ contribui nᵢ/Nᵢ do dano. Falha quando D=1. Simples mas ignora sequência de carregamento.",
                Criador = "Milton A. Miner",
                AnoOrigin = "1945",
            },
            new Formula
            {
                Id = "3_fd06", Nome = "Rainflow Counting", Categoria = "Mecânica da Fratura", SubCategoria = "Fadiga",
                Expressao = "Extrai ciclos fechados de histórico de tensão irregular",
                ExprTexto = "Extração de ciclos (Σσa, σm) de sinal irregular",
                Icone = "🔄",
                Descricao = "Algoritmo para decompor histórico de carregamento aleatório em ciclos individuais com amplitude e média definidas. Essencial para análise de fadiga em campo.",
                Criador = "Tatsuo Endo / Matsuishi",
                AnoOrigin = "1968",
            },
            new Formula
            {
                Id = "3_fd07", Nome = "Limiar de Propagação ΔKth", Categoria = "Mecânica da Fratura", SubCategoria = "Fadiga",
                Expressao = "da/dN → 0 quando ΔK ≤ ΔK_th",
                ExprTexto = "ΔK ≤ ΔKth ⟹ da/dN ≈ 0",
                Icone = "ΔKth",
                Descricao = "Abaixo de ΔKth, a trinca não propaga (ou cresce desprezavelmente). Valores típicos: aço 2-10 MPa√m, alumínio 1-3 MPa√m.",
                Criador = "Mecânica da fratura por fadiga",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 16. CFD E TURBULÊNCIA
    // ─────────────────────────────────────────────────────
    private void AdicionarCFDTurbulencia()
    {
        _formulas.AddRange([
            // 16.1 Navier-Stokes e adimensionais
            new Formula
            {
                Id = "3_ns01", Nome = "Equações de Navier-Stokes (Incompressível)", Categoria = "CFD e Turbulência", SubCategoria = "Navier-Stokes",
                Expressao = "ρ(∂v/∂t + v·∇v) = -∇p + μ∇²v + f;  ∇·v=0",
                ExprTexto = "ρ(∂v⃗/∂t + v⃗·∇v⃗) = −∇p + μ∇²v⃗ + f⃗;  ∇·v⃗=0",
                Icone = "NS",
                Descricao = "Equações fundamentais da mecânica dos fluidos: conservação de momento + incompressibilidade. Existência e suavidade em 3D é um dos Problemas do Milênio (Clay $1M).",
                Criador = "Claude-Louis Navier / George Stokes",
                AnoOrigin = "1822/1845",
            },
            new Formula
            {
                Id = "3_ns02", Nome = "Número de Reynolds", Categoria = "CFD e Turbulência", SubCategoria = "Navier-Stokes",
                Expressao = "Re = ρUL/μ = UL/ν",
                ExprTexto = "Re = ρUL/μ",
                Icone = "Re",
                Descricao = "Razão entre forças inerciais e viscosas. Re baixo → laminar; Re alto → turbulento. Re_crit~2300 para tubo; ~5×10⁵ para placa plana.",
                Criador = "Osborne Reynolds",
                AnoOrigin = "1883",
                Variaveis = [
                    new() { Simbolo = "rho", Nome = "ρ (kg/m³)", ValorPadrao = 1.225 },
                    new() { Simbolo = "U", Nome = "U (m/s)", ValorPadrao = 10 },
                    new() { Simbolo = "L", Nome = "L (m)", ValorPadrao = 1 },
                    new() { Simbolo = "mu", Nome = "μ (Pa·s)", ValorPadrao = 1.81e-5 },
                ],
                VariavelResultado = "Re",
                Calcular = v => v["rho"] * v["U"] * v["L"] / v["mu"]
            },
            new Formula
            {
                Id = "3_ns03", Nome = "Número de Prandtl", Categoria = "CFD e Turbulência", SubCategoria = "Navier-Stokes",
                Expressao = "Pr = ν/α = μcp/k",
                ExprTexto = "Pr = ν/α = μcₚ/k",
                Icone = "Pr",
                Descricao = "Razão entre difusividade de momento e térmica. Pr≈0.7 gases; Pr≈7 água; Pr~100-1000 óleos. Controla espessura relativa das camadas limite térmica e hidrodinâmica.",
                Criador = "Ludwig Prandtl",
                AnoOrigin = "~1910",
                Variaveis = [
                    new() { Simbolo = "mu", Nome = "μ (Pa·s)", ValorPadrao = 1.81e-5 },
                    new() { Simbolo = "cp", Nome = "cₚ (J/(kg·K))", ValorPadrao = 1005 },
                    new() { Simbolo = "k", Nome = "k (W/(m·K))", ValorPadrao = 0.026 },
                ],
                VariavelResultado = "Pr",
                Calcular = v => v["mu"] * v["cp"] / v["k"]
            },
            new Formula
            {
                Id = "3_ns04", Nome = "Número de Nusselt", Categoria = "CFD e Turbulência", SubCategoria = "Navier-Stokes",
                Expressao = "Nu = hL/k",
                ExprTexto = "Nu = hL/k",
                Icone = "Nu",
                Descricao = "Razão entre convecção e condução. Nu=1 pura condução. Correlações: Nu=f(Re,Pr). Ex.: Dittus-Boelter Nu=0.023·Re^0.8·Pr^0.4 para turbulento em tubo.",
                Criador = "Wilhelm Nusselt",
                AnoOrigin = "1915",
                Variaveis = [
                    new() { Simbolo = "h", Nome = "h (W/(m²·K))", ValorPadrao = 50 },
                    new() { Simbolo = "L", Nome = "L (m)", ValorPadrao = 0.05 },
                    new() { Simbolo = "k", Nome = "k (W/(m·K))", ValorPadrao = 0.026 },
                ],
                VariavelResultado = "Nu",
                Calcular = v => v["h"] * v["L"] / v["k"]
            },
            new Formula
            {
                Id = "3_ns05", Nome = "Vorticidade", Categoria = "CFD e Turbulência", SubCategoria = "Navier-Stokes",
                Expressao = "ω = ∇×v;  Dω/Dt = (ω·∇)v + ν∇²ω",
                ExprTexto = "ω⃗ = ∇×v⃗;  Dω⃗/Dt = (ω⃗·∇)v⃗ + ν∇²ω⃗",
                Icone = "ω",
                Descricao = "Medida local de rotação do fluido. Equação de transporte: estiramento de vórtice (ω·∇)v tridimensional + difusão viscosa ν∇²ω.",
                Criador = "Hermann von Helmholtz / N-S",
            },
            // 16.2 Turbulência (RANS, LES)
            new Formula
            {
                Id = "3_tb01", Nome = "Decomposição de Reynolds", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "u = ū + u';  ⟨u'⟩ = 0",
                ExprTexto = "u = ū + u';  ⟨u'⟩ = 0",
                Icone = "RANS",
                Descricao = "Velocidade = média temporal + flutuação. Aplicando à N-S e tirando média → equações RANS. Surge o tensor de Reynolds ⟨u'ᵢu'ⱼ⟩ (problema de fechamento).",
                Criador = "Osborne Reynolds",
                AnoOrigin = "1895",
            },
            new Formula
            {
                Id = "3_tb02", Nome = "Equações RANS", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "ρ(ū·∇ū) = -∇p̄ + μ∇²ū - ρ∇·⟨u'u'⟩",
                ExprTexto = "ρ(ū·∇ū) = −∇p̄ + μ∇²ū − ρ∇·⟨u'ᵢu'ⱼ⟩",
                Icone = "RANS",
                Descricao = "Navier-Stokes médias: 6 incógnitas extras (tensor de Reynolds). Precisa de modelo de turbulência para fechar (k-ε, k-ω, SST, etc.).",
                Criador = "Reynolds / Modelos de turbulência",
            },
            new Formula
            {
                Id = "3_tb03", Nome = "Hipótese de Boussinesq", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "-ρ⟨u'ᵢu'ⱼ⟩ = μt(∂ūᵢ/∂xⱼ + ∂ūⱼ/∂xᵢ) - (2/3)ρkδᵢⱼ",
                ExprTexto = "−ρ⟨u'ᵢu'ⱼ⟩ = μt(∂ūᵢ/∂xⱼ+∂ūⱼ/∂xᵢ) − ⅔ρkδᵢⱼ",
                Icone = "μt",
                Descricao = "Tensor de Reynolds proporcional à taxa de deformação média via viscosidade turbulenta μt (analógica à Lei de Newton para viscosidade). Base de modelos k-ε e k-ω.",
                Criador = "Joseph Boussinesq",
                AnoOrigin = "1877",
            },
            new Formula
            {
                Id = "3_tb04", Nome = "Modelo k-ε Padrão", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "μt = ρCμk²/ε;  Cμ=0.09",
                ExprTexto = "μt = ρCμk²/ε;  Cμ=0.09",
                Icone = "k-ε",
                Descricao = "k=energia cinética turbulenta, ε=dissipação. Duas equações de transporte adicionais. Robusto e amplamente usado. Fraco para separação de fluxo e relaminarização.",
                Criador = "Brian Launder / Dudley Spalding",
                AnoOrigin = "1972",
            },
            new Formula
            {
                Id = "3_tb05", Nome = "Modelo k-ω SST", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "k-ω perto da parede ↔ k-ε longe;  blending function F₁",
                ExprTexto = "SST: k-ω (parede) ↔ k-ε (longe)",
                Icone = "SST",
                Descricao = "Menter SST: melhor de k-ω (camada limite) e k-ε (campo livre) via funções de blending. Padrão industrial para aeronáutica, turbomáquinas. Melhor tratamento de fluxos adversos.",
                Criador = "Florian Menter",
                AnoOrigin = "1994",
            },
            new Formula
            {
                Id = "3_tb06", Nome = "LES (Large Eddy Simulation)", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "Resolver grandes escalas; modelar sub-grid (SGS)",
                ExprTexto = "ũᵢ filtrado; τᵢⱼˢᵍˢ modelado",
                Icone = "LES",
                Descricao = "Resolve diretamente vórtices maiores que a malha; modela os menores (sub-grid). Mais preciso que RANS para fluxos transientes. Custo: entre RANS e DNS.",
                Criador = "Joseph Smagorinsky / James Deardorff",
                AnoOrigin = "1963/1970",
            },
            new Formula
            {
                Id = "3_tb07", Nome = "Modelo de Smagorinsky (SGS)", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "μ_sgs = ρ(CsΔ)²|S̄|;  Cs≈0.1-0.2",
                ExprTexto = "μsgs = ρ(CsΔ)²|S̄|",
                Icone = "SGS",
                Descricao = "Viscosidade sub-grid proporcional ao tamanho de malha Δ e taxa de deformação |S̄|. Modelo mais simples para LES. Cs calibrado para turbulência isotrópica.",
                Criador = "Joseph Smagorinsky",
                AnoOrigin = "1963",
            },
            new Formula
            {
                Id = "3_tb08", Nome = "Cascata de Kolmogorov", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "E(k) = Cε^(2/3)k^(-5/3)  (região inercial)",
                ExprTexto = "E(k) = Cε²ᐟ³k⁻⁵ᐟ³",
                Icone = "-5/3",
                Descricao = "Energia cinética turbulenta é transferida de grandes para pequenas escalas sem dissipação (cascata de energia). Lei -5/3 na região inercial: resultado universal.",
                Criador = "Andrey Kolmogorov",
                AnoOrigin = "1941",
            },
            new Formula
            {
                Id = "3_tb09", Nome = "Escala de Kolmogorov", Categoria = "CFD e Turbulência", SubCategoria = "Turbulência",
                Expressao = "η = (ν³/ε)^(1/4);  τ_η = (ν/ε)^(1/2);  v_η = (νε)^(1/4)",
                ExprTexto = "η = (ν³/ε)^(1/4)",
                Icone = "η",
                Descricao = "Menor escala da turbulência: onde dissipação viscosa absorve a energia. η decresce com Re. Relação: L/η ~ Re^(3/4). DNS deve resolver até η.",
                Criador = "Andrey Kolmogorov",
                AnoOrigin = "1941",
            },
            // 16.3 FVM e Esquemas Numéricos
            new Formula
            {
                Id = "3_cf01", Nome = "Forma Integral (FVM)", Categoria = "CFD e Turbulência", SubCategoria = "Métodos Numéricos CFD",
                Expressao = "∂/∂t∫_V ρφ dV + ∮_S ρφv·dA = ∮_S Γ∇φ·dA + ∫_V Sφ dV",
                ExprTexto = "∂/∂t∫ρφdV + ∮ρφv⃗·dA⃗ = ∮Γ∇φ·dA⃗ + ∫SφdV",
                Icone = "FVM",
                Descricao = "Equação de transporte escalar em forma integral. Base do método de volumes finitos: conservação garantida em cada volume de controle.",
                Criador = "S.V. Patankar / Base de CFD moderno",
                AnoOrigin = "~1972",
            },
            new Formula
            {
                Id = "3_cf02", Nome = "Esquema Upwind", Categoria = "CFD e Turbulência", SubCategoria = "Métodos Numéricos CFD",
                Expressao = "φf = φP (se v·n>0);  φf = φN (se v·n<0)",
                ExprTexto = "φf = φP ou φN (direção do fluxo)",
                Icone = "↑",
                Descricao = "Valor na face = valor do centro a montante. Estável mas difusivo (1ª ordem). Esquemas de 2ª ordem (MUSCL, QUICK) melhoram precisão com limitadores de fluxo.",
                Criador = "Prática CFD",
            },
            new Formula
            {
                Id = "3_cf03", Nome = "Algoritmo SIMPLE", Categoria = "CFD e Turbulência", SubCategoria = "Métodos Numéricos CFD",
                Expressao = "Predictor-corrector: v* → p' → v'=v*+v'; p=p*+αp'",
                ExprTexto = "SIMPLE: v* → p' correção → v corrigido",
                Icone = "SIMPLE",
                Descricao = "Semi-Implicit Method for Pressure-Linked Equations. Resolve acoplamento velocidade-pressão iterativamente. Variantes: SIMPLEC, PISO para transiente.",
                Criador = "S.V. Patankar / D.B. Spalding",
                AnoOrigin = "1972",
            },
            new Formula
            {
                Id = "3_cf04", Nome = "Número de Courant (CFL)", Categoria = "CFD e Turbulência", SubCategoria = "Métodos Numéricos CFD",
                Expressao = "CFL = u·Δt/Δx ≤ 1  (condição de estabilidade)",
                ExprTexto = "CFL = uΔt/Δx ≤ 1",
                Icone = "CFL",
                Descricao = "Courant-Friedrichs-Lewy: esquemas explícitos requerem CFL≤1 (informação não pode viajar mais que uma célula por passo de tempo). Implícitos são incondicionalmente estáveis.",
                Criador = "Courant, Friedrichs, Lewy",
                AnoOrigin = "1928",
                Variaveis = [
                    new() { Simbolo = "u", Nome = "u (m/s)", ValorPadrao = 10 },
                    new() { Simbolo = "dt", Nome = "Δt (s)", ValorPadrao = 0.001 },
                    new() { Simbolo = "dx", Nome = "Δx (m)", ValorPadrao = 0.01 },
                ],
                VariavelResultado = "CFL",
                Calcular = v => v["u"] * v["dt"] / v["dx"]
            },
            new Formula
            {
                Id = "3_cf05", Nome = "Convergência de Malha (GCI)", Categoria = "CFD e Turbulência", SubCategoria = "Métodos Numéricos CFD",
                Expressao = "GCI = Fs|ε|/(r^p - 1);  p = ordem de convergência",
                ExprTexto = "GCI = Fs·|ε|/(rᵖ−1)",
                Icone = "GCI",
                Descricao = "Grid Convergence Index: estimativa do erro de discretização usando 3 malhas. Fs=1.25 (3 malhas), r=razão de refinamento, p estimado por Richardson. Padrão ASME V&V 20.",
                Criador = "Patrick Roache",
                AnoOrigin = "1994",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 17. ROBÓTICA
    // ─────────────────────────────────────────────────────
    private void AdicionarRobotica()
    {
        _formulas.AddRange([
            // 17.1 Cinemática
            new Formula
            {
                Id = "3_rb01", Nome = "Matriz de Transformação Homogênea", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "T = [R d; 0 1] ∈ SE(3)",
                ExprTexto = "T = [R d; 0 1] ∈ SE(3)",
                Icone = "T",
                Descricao = "Matriz 4×4 que combina rotação R (3×3) e translação d (3×1). Composição: T₀₂ = T₀₁·T₁₂. Grupo especial euclidiano SE(3).",
                Criador = "Robótica / Geometria",
            },
            new Formula
            {
                Id = "3_rb02", Nome = "Parâmetros de Denavit-Hartenberg", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "Tᵢ = Rot_z(θᵢ)·Trans_z(dᵢ)·Trans_x(aᵢ)·Rot_x(αᵢ)",
                ExprTexto = "Tᵢ = Rz(θᵢ)·Tz(dᵢ)·Tx(aᵢ)·Rx(αᵢ)",
                Icone = "DH",
                Descricao = "Convenção DH: 4 parâmetros por junta descrevem geometria do link. Produto T₀ₙ = T₁·T₂·...·Tₙ dá cinemática direta. θᵢ variável para junta revoluta.",
                Criador = "Jacques Denavit / Richard Hartenberg",
                AnoOrigin = "1955",
            },
            new Formula
            {
                Id = "3_rb03", Nome = "Cinemática Direta", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "T₀ₙ = ∏ᵢ₌₁ⁿ Aᵢ(qᵢ);  x = f(q)",
                ExprTexto = "x = f(q₁,q₂,...,qₙ)",
                Icone = "FK",
                Descricao = "Dado vetor de juntas q, calcula posição/orientação do efetuador. Multiplicação de matrizes DH. Sempre tem solução única. Computacionalmente trivial.",
                Criador = "Robótica clássica",
            },
            new Formula
            {
                Id = "3_rb04", Nome = "Jacobiano do Robô", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "ẋ = J(q)·q̇;  J ∈ ℝ^(6×n)",
                ExprTexto = "ẋ = J(q)·q̇",
                Icone = "J",
                Descricao = "Relaciona velocidades de junta com velocidades cartesianas do efetuador. 6×n para 6 DOF cartesianos. Singularidades: det(J)=0 → perda de mobilidade.",
                Criador = "Robótica / Análise diferencial",
            },
            new Formula
            {
                Id = "3_rb05", Nome = "Cinemática Inversa", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "q = f⁻¹(x);  múltiplas soluções possíveis",
                ExprTexto = "q = f⁻¹(x) (múltiplas soluções)",
                Icone = "IK",
                Descricao = "Dada posição desejada do efetuador, encontrar ângulos das juntas. Geralmente não-linear, múltiplas soluções. Métodos: analítico (6R), numérico (Newton-Raphson via J).",
                Criador = "Robótica",
            },
            new Formula
            {
                Id = "3_rb06", Nome = "IK por Jacobiano Inverso (Iterativo)", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "Δq = J⁻¹·Δx;  q ← q + αΔq",
                ExprTexto = "Δq = J⁻¹(q)·Δx;  repetir",
                Icone = "J⁻¹",
                Descricao = "Método iterativo: linearizar via Jacobiano, dar passo em q, recalcular erro. J⁻¹ ou pseudoinversa (J†) para redundância. Convergência depende de inicialização.",
                Criador = "Robótica numérica",
            },
            new Formula
            {
                Id = "3_rb07", Nome = "Singularidades do Manipulador", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "det(J) = 0 ⟹ singularidade (perda de DOF)",
                ExprTexto = "det(J)=0 → singularidade",
                Icone = "⚠",
                Descricao = "Na singularidade, o robô perde graus de liberdade em certas direções (velocidade infinita das juntas para velocidade finita do efetuador). Evitar por planejamento de trajetória.",
                Criador = "Teoria de robótica",
            },
            // 17.2 Dinâmica
            new Formula
            {
                Id = "3_rb08", Nome = "Euler-Lagrange para Robôs", Categoria = "Robótica", SubCategoria = "Dinâmica",
                Expressao = "M(q)q̈ + C(q,q̇)q̇ + g(q) = τ",
                ExprTexto = "M(q)q̈ + C(q,q̇)q̇ + g(q) = τ",
                Icone = "τ",
                Descricao = "Equação do movimento: M=matriz de inércia, C=Coriolis/centrípeta, g=gravidade, τ=torques. Base para controle dinâmico. M é simétrica e definida positiva.",
                Criador = "Lagrange / Robótica",
            },
            new Formula
            {
                Id = "3_rb09", Nome = "Energia Cinética do Manipulador", Categoria = "Robótica", SubCategoria = "Dinâmica",
                Expressao = "T = ½q̇ᵀM(q)q̇",
                ExprTexto = "T = ½q̇ᵀM(q)q̇",
                Icone = "T",
                Descricao = "Energia cinética total é forma quadrática em velocidades de junta. M(q) depende da configuração. Usado para derivar equações de Lagrange: L=T-V.",
                Criador = "Mecânica Lagrangiana",
            },
            new Formula
            {
                Id = "3_rb10", Nome = "Torque Computado (CTC)", Categoria = "Robótica", SubCategoria = "Dinâmica",
                Expressao = "τ = M(q)(q̈d + Kv·ė + Kp·e) + C(q,q̇)q̇ + g(q)",
                ExprTexto = "τ = M(q̈d+Kv·ė+Kp·e) + C·q̇ + g",
                Icone = "CTC",
                Descricao = "Controle por modelo inverso: cancela não-linearidades (M, C, g) e impõe dinâmica de erro linear (PD). Precisa de modelo preciso; adaptativo se incerto.",
                Criador = "Robótica de controle",
            },
            new Formula
            {
                Id = "3_rb11", Nome = "Newton-Euler Recursivo", Categoria = "Robótica", SubCategoria = "Dinâmica",
                Expressao = "Forward: velocidades/acelerações → base para ponta; Backward: forças/torques ← ponta para base",
                ExprTexto = "Forward: v,ω → ; Backward: F,τ ←",
                Icone = "N-E",
                Descricao = "Algoritmo O(n) para dinâmica de robôs. Propaga velocidades/acelerações da base para o efetuador, depois forças/torques do efetuador para a base. Mais eficiente que Lagrange.",
                Criador = "John Y.S. Luh / Walker & Orin",
                AnoOrigin = "1980",
            },
            new Formula
            {
                Id = "3_rb12", Nome = "Espaço de Trabalho", Categoria = "Robótica", SubCategoria = "Cinemática",
                Expressao = "W = {x ∈ ℝ³ : ∃q tal que FK(q)=x}",
                ExprTexto = "W = {x : ∃q, x=FK(q)}",
                Icone = "W",
                Descricao = "Conjunto de posições alcançáveis pelo efetuador. Dexterous workspace (todas as orientações) ⊂ Reachable workspace (pelo menos uma orientação). Determinado por geometria e limites de junta.",
                Criador = "Robótica",
            },
            new Formula
            {
                Id = "3_rb13", Nome = "Controle PD no Espaço de Juntas", Categoria = "Robótica", SubCategoria = "Dinâmica",
                Expressao = "τ = Kp(qd-q) + Kv(q̇d-q̇) + g(q)",
                ExprTexto = "τ = Kp·e + Kv·ė + g(q)",
                Icone = "PD",
                Descricao = "Controle proporcional-derivativo com compensação de gravidade. Estável globalmente por Lyapunov. Simples e eficaz para regulação (ponto a ponto). Base para controle de robôs.",
                Criador = "Robótica de controle",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 18. SISTEMAS DE POTÊNCIA ELÉTRICA
    // ─────────────────────────────────────────────────────
    private void AdicionarSistemasPotencia()
    {
        _formulas.AddRange([
            // 18.1 Fluxo de Potência
            new Formula
            {
                Id = "3_sp01", Nome = "Equações de Fluxo de Potência", Categoria = "Sistemas de Potência", SubCategoria = "Fluxo de Potência",
                Expressao = "Pᵢ = Σⱼ |Vᵢ||Vⱼ||Yᵢⱼ|cos(θᵢⱼ-δᵢ+δⱼ);  analogamente Qᵢ",
                ExprTexto = "Pᵢ = Σⱼ |Vᵢ||Vⱼ||Yᵢⱼ|cos(θᵢⱼ−δᵢ+δⱼ)",
                Icone = "PF",
                Descricao = "Potência ativa e reativa em cada barra como função das tensões e ângulos de todas as barras. Sistema não-linear 2n (n barras). Base da operação do SEP.",
                Criador = "Engenharia de potência",
            },
            new Formula
            {
                Id = "3_sp02", Nome = "Fluxo de Potência (Sᵢⱼ)", Categoria = "Sistemas de Potência", SubCategoria = "Fluxo de Potência",
                Expressao = "Sᵢⱼ = Vᵢ·(Vᵢ*-Vⱼ*)/zᵢⱼ*  ↔  Pᵢⱼ + jQᵢⱼ",
                ExprTexto = "Pᵢⱼ + jQᵢⱼ = Vᵢ(Vᵢ−Vⱼ)*/z*ᵢⱼ",
                Icone = "Sᵢⱼ",
                Descricao = "Potência complexa do nó i para nó j pela linha com impedância z. Pᵢⱼ controla ativo (ângulos), Qᵢⱼ modula reativo (tensões).",
                Criador = "Engenharia de potência",
            },
            new Formula
            {
                Id = "3_sp03", Nome = "Newton-Raphson (Fluxo de Potência)", Categoria = "Sistemas de Potência", SubCategoria = "Fluxo de Potência",
                Expressao = "[ΔP/ΔQ] = J · [Δδ/Δ|V|]  (iterativo)",
                ExprTexto = "[ΔP;ΔQ] = J·[Δδ;Δ|V|]",
                Icone = "N-R",
                Descricao = "Método padrão para resolver fluxo de potência. Jacobiano J: ∂(P,Q)/∂(δ,|V|). Convergência quadrática (3-5 iterações). Sistemas de milhares de barras.",
                Criador = "William Tinney / Computação de potência",
                AnoOrigin = "~1967",
            },
            new Formula
            {
                Id = "3_sp04", Nome = "Potência Ativa = f(δ)", Categoria = "Sistemas de Potência", SubCategoria = "Fluxo de Potência",
                Expressao = "P₁₂ = (|V₁||V₂|/X)sin(δ₁-δ₂)",
                ExprTexto = "P₁₂ = |V₁||V₂|sin(δ₁₂)/X",
                Icone = "P",
                Descricao = "Potência ativa numa linha sem resistência: proporcional ao seno da diferença angular. Máximo em δ=90° (limite de estabilidade estática). Base de sistemas interligados.",
                Criador = "Engenharia de sistemas de potência",
                Variaveis = [
                    new() { Simbolo = "V1", Nome = "|V₁| (pu)", ValorPadrao = 1.0 },
                    new() { Simbolo = "V2", Nome = "|V₂| (pu)", ValorPadrao = 1.0 },
                    new() { Simbolo = "X", Nome = "X (pu)", Descricao = "Reatância da linha", ValorPadrao = 0.1 },
                    new() { Simbolo = "delta", Nome = "δ₁₂ (graus)", ValorPadrao = 30 },
                ],
                VariavelResultado = "P₁₂ (pu)",
                UnidadeResultado = "pu",
                Calcular = v => v["V1"] * v["V2"] * Math.Sin(v["delta"] * Math.PI / 180) / v["X"]
            },
            new Formula
            {
                Id = "3_sp05", Nome = "Perdas na Transmissão", Categoria = "Sistemas de Potência", SubCategoria = "Fluxo de Potência",
                Expressao = "P_loss = I²R = (P²+Q²)R/V²",
                ExprTexto = "Ploss = I²R;  I² ∝ (P²+Q²)/V²",
                Icone = "Ploss",
                Descricao = "Perdas ôhmicas proporcional ao quadrado da corrente. Motivação para alta tensão de transmissão: dobrar V → perda 1/4. Fator de potência alto reduz Q e perdas.",
                Criador = "Engenharia elétrica clássica",
            },
            // 18.2 Estabilidade e Curto-Circuito
            new Formula
            {
                Id = "3_sp06", Nome = "Corrente de Curto-Circuito Trifásico", Categoria = "Sistemas de Potência", SubCategoria = "Curto-Circuito",
                Expressao = "Icc = V/(Z_th);  Scc = V²/Z_th",
                ExprTexto = "Icc = V/Zth;  Scc = V²/Zth",
                Icone = "Icc",
                Descricao = "Corrente no ponto de falta = tensão pré-falta / impedância de Thevenin. Critério para dimensionamento de disjuntores e proteção. Curto trifásico: mais severo e simétrico.",
                Criador = "Engenharia de proteção",
            },
            new Formula
            {
                Id = "3_sp07", Nome = "Componentes Simétricas", Categoria = "Sistemas de Potência", SubCategoria = "Curto-Circuito",
                Expressao = "[V₀;V₁;V₂] = (1/3)[1 1 1; 1 a a²; 1 a² a][Vₐ;Vᵦ;Vc]  (a=e^(j2π/3))",
                ExprTexto = "[V₀;V₁;V₂] = A⁻¹·[Va;Vb;Vc]",
                Icone = "012",
                Descricao = "Fortescue: decompõe sistema desequilibrado trifásico em 3 sistemas equilibrados (seq. positiva, negativa, zero). Simplifica análise de faltas assimétricas.",
                Criador = "Charles Fortescue",
                AnoOrigin = "1918",
            },
            new Formula
            {
                Id = "3_sp08", Nome = "Equação Swing do Gerador", Categoria = "Sistemas de Potência", SubCategoria = "Estabilidade",
                Expressao = "M·d²δ/dt² = Pm - Pe(δ) = Pm - Pmax·sin(δ)",
                ExprTexto = "M·d²δ/dt² = Pm − Pmax·sin(δ)",
                Icone = "δ(t)",
                Descricao = "Equação diferencial que governa a dinâmica do rotor. M=constante de inércia, Pm=potência mecânica, Pe=elétrica. Equilíbrio: Pm=Pe. Análise de estabilidade transitória.",
                Criador = "Engenharia de sistemas de potência",
            },
            new Formula
            {
                Id = "3_sp09", Nome = "Critério de Áreas Iguais", Categoria = "Sistemas de Potência", SubCategoria = "Estabilidade",
                Expressao = "A_acel = A_desacel ⟹ estável",
                ExprTexto = "∫(Pm−Pe)dδ aceleração = ∫(Pe−Pm)dδ desaceleração",
                Icone = "EAC",
                Descricao = "Para sistema de 2 máquinas: se a área de aceleração (Pm>Pe) pode ser compensada pela área de desaceleração disponível, o sistema é transitoriamente estável.",
                Criador = "Análise de estabilidade de potência",
            },
            new Formula
            {
                Id = "3_sp10", Nome = "Constante de Inércia H", Categoria = "Sistemas de Potência", SubCategoria = "Estabilidade",
                Expressao = "H = Energia_cinética/S_base = ½Jω²/S_base  (segundos)",
                ExprTexto = "H = ½Jω²/Sbase [s]",
                Icone = "H",
                Descricao = "Energia cinética armazenada no rotor dividida pela potência nominal. Típico: H=2-6s para geradores convencionais. H alto → mais inércia → mais estável.",
                Criador = "Engenharia de máquinas elétricas",
                Variaveis = [
                    new() { Simbolo = "J", Nome = "J (kg·m²)", Descricao = "Momento de inércia", ValorPadrao = 5000 },
                    new() { Simbolo = "omega", Nome = "ω (rad/s)", ValorPadrao = 376.99 },
                    new() { Simbolo = "Sbase", Nome = "S_base (VA)", ValorPadrao = 100e6 },
                ],
                VariavelResultado = "H (s)",
                UnidadeResultado = "s",
                Calcular = v => 0.5 * v["J"] * v["omega"] * v["omega"] / v["Sbase"]
            },
        ]);
    }
}
