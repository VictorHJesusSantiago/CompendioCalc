using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 6 — PARTE IV: ENGENHARIA AVANÇADA (Seções 13-15)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 13. FOTÔNICA INTEGRADA, MEMS/NEMS E TRIBOLOGIA
    // ─────────────────────────────────────────────────────
    private void AdicionarFotonicaMEMS()
    {
        _formulas.AddRange([
            // 13.1 Fotônica Integrada
            new Formula
            {
                Id = "6_fo01", Nome = "Guia de Onda (Modo Fundamental)", Categoria = "Fotônica e MEMS", SubCategoria = "Fotônica Integrada",
                Expressao = "β² = n_eff² k₀²;  V = (πd/λ)√(n₁²-n₂²)",
                ExprTexto = "β² = neff²·k₀²; V = (πd/λ)·√(n₁²−n₂²); número V do guia",
                Icone = "β",
                Descricao = "Constante de propagação β e número V de um guia de onda dielétrico. V<2.405 → single-mode. Base de fotônica integrada (SOI, SiN, InP).",
                Criador = "Amnon Yariv",
                AnoOrigin = "1973",
            },
            new Formula
            {
                Id = "6_fo02", Nome = "Acoplador Direcional", Categoria = "Fotônica e MEMS", SubCategoria = "Fotônica Integrada",
                Expressao = "P₂/P₁ = sin²(κL);  L_c = π/(2κ)",
                ExprTexto = "Acoplador: P₂/P₁ = sin²(κL); comprimento de acoplamento Lc = π/(2κ)",
                Icone = "κ",
                Descricao = "Acoplador direcional: dois guias próximos trocam potência com período 2Lc. κ = coeficiente de acoplamento. Splitters, switches e filtros integrados.",
                Criador = "Amnon Yariv",
                AnoOrigin = "1973",
            },
            new Formula
            {
                Id = "6_fo03", Nome = "Ressonador em Anel", Categoria = "Fotônica e MEMS", SubCategoria = "Fotônica Integrada",
                Expressao = "T = (a - t·e^{iφ})/(1 - a·t·e^{iφ});  FSR = λ²/(n_g·L)",
                ExprTexto = "Ring: T = (a−t·e^{iφ})/(1−at·e^{iφ}); FSR = λ²/(ng·L)",
                Icone = "◯",
                Descricao = "Ressonador em anel: filtro óptico integrado com FSR e finesse controláveis. Ressonância quando φ=2πm. Usado em WDM, sensores e moduladores.",
                Criador = "B.E. Little / S.T. Chu / H.A. Haus",
                AnoOrigin = "1997",
            },
            new Formula
            {
                Id = "6_fo04", Nome = "Modulador Mach-Zehnder", Categoria = "Fotônica e MEMS", SubCategoria = "Fotônica Integrada",
                Expressao = "I_out = I_in cos²(πV/(2V_π));  V_π = λd/(n³r₃₃L)",
                ExprTexto = "MZM: Iout = Iin·cos²(πV/(2Vπ)); Vπ = tensão de meia onda",
                Icone = "MZ",
                Descricao = "Modulador Mach-Zehnder: modula intensidade via diferença de fase eletro-óptica. Vπ = tensão para extinção. Chave em comunicações ópticas de alta velocidade.",
                Criador = "Various / LiNbO₃ standard",
                AnoOrigin = "1980",
            },
            new Formula
            {
                Id = "6_fo05", Nome = "Cristal Fotônico (Banda Gap)", Categoria = "Fotônica e MEMS", SubCategoria = "Fotônica Integrada",
                Expressao = "∇×(1/ε(r) ∇×H) = (ω/c)²H;  banda proibida fotônica",
                ExprTexto = "Maxwell em meio periódico: eigenproblem → band gap fotônico",
                Icone = "PC",
                Descricao = "Cristal fotônico: estrutura dielétrica periódica cria band gap para fótons. Análogo ao potencial periódico de Bloch. Cavidades, guias e slow light.",
                Criador = "Eli Yablonovitch / Sajeev John",
                AnoOrigin = "1987",
            },
            new Formula
            {
                Id = "6_fo06", Nome = "Fibra de Cristal Fotônico (PCF)", Categoria = "Fotônica e MEMS", SubCategoria = "Fotônica Integrada",
                Expressao = "GVD = -(λ/c) d²n_eff/dλ²;  dispersão controlada por geometria",
                ExprTexto = "PCF: GVD = −(λ/c)·d²neff/dλ²; geometria controla dispersão",
                Icone = "PCF",
                Descricao = "Fibra de cristal fotônico: casca com furos de ar cria guiamento por band gap ou TIR modificada. Engenharia de dispersão e alta não-linearidade.",
                Criador = "Philip Russell",
                AnoOrigin = "1996",
            },
            new Formula
            {
                Id = "6_fo07", Nome = "Plasmon de Superfície (SPP)", Categoria = "Fotônica e MEMS", SubCategoria = "Fotônica Integrada",
                Expressao = "k_SPP = (ω/c)√(ε_m ε_d/(ε_m+ε_d));  confinamento sub-λ",
                ExprTexto = "SPP: kSPP = (ω/c)·√(εmεd/(εm+εd)); plasmônica sub-comprimento de onda",
                Icone = "SPP",
                Descricao = "Plasmon polariton de superfície: onda EM na interface metal-dielétrico. Confinamento sub-λ para nano-fotônica. Sensores LSPR e circuitos plasmônicos.",
                Criador = "Ritchie (teoria) / Raether (experimental)",
                AnoOrigin = "1957",
            },

            // 13.2 MEMS e NEMS
            new Formula
            {
                Id = "6_me01", Nome = "Frequência de Ressonância MEMS", Categoria = "Fotônica e MEMS", SubCategoria = "MEMS/NEMS",
                Expressao = "f₀ = (1/2π)√(k/m);  k = Ewt³/(4L³) (cantilever)",
                ExprTexto = "f₀ = (1/2π)·√(k/m); k = Ewt³/(4L³) para cantilever",
                Icone = "f₀",
                Descricao = "Frequência de ressonância de cantilever MEMS: depende da rigidez k (material, geometria) e massa m. Base de sensores, filtros RF e giroscópios.",
                Criador = "Kurt Petersen",
                AnoOrigin = "1982",
            },
            new Formula
            {
                Id = "6_me02", Nome = "Atuação Eletrostática (Pull-in)", Categoria = "Fotônica e MEMS", SubCategoria = "MEMS/NEMS",
                Expressao = "V_PI = √(8k g₀³/(27εA));  instabilidade em g = 2g₀/3",
                ExprTexto = "Pull-in: VPI = √(8k·g₀³/(27ε₀A)); colapso em 2/3 do gap",
                Icone = "PI",
                Descricao = "Voltagem de pull-in: quando V>VPI, a força eletrostática supera a restauração elástica → colapso do gap. Limitação fundamental de atuadores MEMS.",
                Criador = "Hal Nathanson / William Newell / Robert Wickstrom / Jerry Davis",
                AnoOrigin = "1967",
            },
            new Formula
            {
                Id = "6_me03", Nome = "Thermoelastic Damping (Q-TED)", Categoria = "Fotônica e MEMS", SubCategoria = "MEMS/NEMS",
                Expressao = "Q_TED⁻¹ = (Eα²T₀)/(ρCₚ) · Ωτ/(1+Ω²τ²);  τ=t²/(π²κ)",
                ExprTexto = "1/QTED = (Eα²T₀/ρCp)·Ωτ/(1+Ω²τ²); amortecimento termoelástico",
                Icone = "Q",
                Descricao = "Amortecimento termoelástico (Zener): limite fundamental de Q em ressonadores MEMS. Fluxo de calor por gradientes de deformação dissipa energia. Pico quando Ωτ≈1.",
                Criador = "Clarence Zener / Ron Lifshitz / Michael Roukes",
                AnoOrigin = "1937",
            },
            new Formula
            {
                Id = "6_me04", Nome = "Acelerômetro Capacitivo MEMS", Categoria = "Fotônica e MEMS", SubCategoria = "MEMS/NEMS",
                Expressao = "ΔC/C = x/g₀;  x = ma/k;  sensibilidade = εA/(k g₀²)",
                ExprTexto = "ΔC = εAx/g₀²; x = ma/k; sensibilidade ∝ m/(k·g₀²)",
                Icone = "a",
                Descricao = "Acelerômetro MEMS capacitivo: massa de prova desloca sob aceleração → variação de capacitância. Em smartphones, carros, inerciais. Resolução ~µg possível.",
                Criador = "Analog Devices (ADXL50) / L. Roylance / J. Angell",
                AnoOrigin = "1979",
            },
            new Formula
            {
                Id = "6_me05", Nome = "Giroscópio MEMS (Coriolis)", Categoria = "Fotônica e MEMS", SubCategoria = "MEMS/NEMS",
                Expressao = "F_Cor = -2m(Ω × v);  Δy = 2mΩv_x/(k_y − mω²_drive)",
                ExprTexto = "Coriolis: F = −2m(Ω×v); deslocamento ∝ Ω no eixo de sense",
                Icone = "Ω",
                Descricao = "Giroscópio MEMS: massa vibra no eixo drive; rotação Ω gera força de Coriolis no eixo sense. Detecta taxa angular. Usado em IMUs, drones, carros.",
                Criador = "Najafi / Ayazi / Clark",
                AnoOrigin = "1998",
            },
            new Formula
            {
                Id = "6_me06", Nome = "NEMS Mass Sensor", Categoria = "Fotônica e MEMS", SubCategoria = "MEMS/NEMS",
                Expressao = "Δm = -2m_eff Δf/f₀;  resolução ∝ m_eff/(Q·f₀)",
                ExprTexto = "NEMS: Δm = −2meff·Δf/f₀; detecção de massa em atogramas",
                Icone = "δm",
                Descricao = "Sensor de massa NEMS: adição de massa desloca frequência de ressonância. Resolução de atogramas (10⁻¹⁸ g). Conta moléculas individuais em vácuo.",
                Criador = "Michael Roukes",
                AnoOrigin = "2004",
            },

            // 13.3 Tribologia
            new Formula
            {
                Id = "6_tb01", Nome = "Lei de Archard (Desgaste)", Categoria = "Fotônica e MEMS", SubCategoria = "Tribologia",
                Expressao = "V = K·F·s/H;  V=volume desgastado, K=coef. desgaste",
                ExprTexto = "Archard: V = K·F·s/H; volume desgastado ∝ carga·distância/dureza",
                Icone = "V",
                Descricao = "Lei de Archard: volume de desgaste proporcional à carga normal F, distância de deslizamento s e inversamente à dureza H. K adimensional caracteriza par tribológico.",
                Criador = "John Frederick Archard",
                AnoOrigin = "1953",
            },
            new Formula
            {
                Id = "6_tb02", Nome = "Contato Hertziano", Categoria = "Fotônica e MEMS", SubCategoria = "Tribologia",
                Expressao = "a = (3FR/(4E*))^{1/3};  p₀ = (6FE*²/(π³R²))^{1/3}",
                ExprTexto = "Hertz: a = (3FR/(4E*))^{1/3}; pressão máxima p₀ = 3F/(2πa²)",
                Icone = "Hz",
                Descricao = "Contato hertziano: solução elástica para contato esfera-plano. Raio de contato a e pressão principal p₀. Base da mecânica de contato em tribologia.",
                Criador = "Heinrich Hertz",
                AnoOrigin = "1882",
            },
            new Formula
            {
                Id = "6_tb03", Nome = "Equação de Reynolds (Lubrificação)", Categoria = "Fotônica e MEMS", SubCategoria = "Tribologia",
                Expressao = "∂/∂x(h³/12μ ∂p/∂x) + ∂/∂y(h³/12μ ∂p/∂y) = U/2 · ∂h/∂x + ∂h/∂t",
                ExprTexto = "Reynolds: ∇·(h³∇p/(12μ)) = U·∂h/∂x/2 + ∂h/∂t",
                Icone = "Re",
                Descricao = "Equação de Reynolds: governa distribuição de pressão em filme lubrificante fino. Lado esquerdo = fluxo de Poiseuille; direito = cunha + squeeze. Lubrificação hidrodinâmica.",
                Criador = "Osborne Reynolds",
                AnoOrigin = "1886",
            },
            new Formula
            {
                Id = "6_tb04", Nome = "Número de Sommerfeld", Categoria = "Fotônica e MEMS", SubCategoria = "Tribologia",
                Expressao = "S = (r/c)² · μN/P;  r=raio, c=folga, N=rotação",
                ExprTexto = "Sommerfeld: S = (r/c)²·μN/P; número adimensional de mancal",
                Icone = "S",
                Descricao = "Número de Sommerfeld: parâmetro adimensional de mancais hidrodinâmicos. Relaciona viscosidade, velocidade, carga e geometria. Define regime de lubrificação na curva de Stribeck.",
                Criador = "Arnold Sommerfeld",
                AnoOrigin = "1904",
            },
            new Formula
            {
                Id = "6_tb05", Nome = "Modelo JKR (Adesão)", Categoria = "Fotônica e MEMS", SubCategoria = "Tribologia",
                Expressao = "F_pull-off = -(3/2)πRΔγ;  a³ = (R/K)(F+3πRΔγ+√(6πRΔγF+(3πRΔγ)²))",
                ExprTexto = "JKR: F_pulloff = −(3/2)πRΔγ; contato com adesão",
                Icone = "JKR",
                Descricao = "Modelo JKR: contato hertziano com adesão (energia de superfície Δγ). Força de pull-off proporcional a R·Δγ. Importante em MEMS, nanoindentação e biologia.",
                Criador = "Johnson / Kendall / Roberts",
                AnoOrigin = "1971",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 14. TRÁFEGO, TRANSFERÊNCIA RADIATIVA E COLORIMETRIA
    // ─────────────────────────────────────────────────────
    private void AdicionarTrafegoRadiativa()
    {
        _formulas.AddRange([
            // 14.1 Engenharia de Tráfego
            new Formula
            {
                Id = "6_et01", Nome = "Modelo LWR (Lighthill-Whitham-Richards)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Engenharia de Tráfego",
                Expressao = "∂ρ/∂t + ∂(ρv(ρ))/∂x = 0;  q = ρ·v(ρ)",
                ExprTexto = "LWR: ∂ρ/∂t + ∂q/∂x = 0; conservação de veículos, q = ρ·v(ρ)",
                Icone = "ρ",
                Descricao = "Modelo LWR: lei de conservação macroscópica para fluxo de tráfego. Densidade ρ, velocidade v(ρ) decrescente. Ondas de choque e rarefação. Diagrama fundamental.",
                Criador = "M.J. Lighthill / G.B. Whitham / Paul Richards",
                AnoOrigin = "1955",
            },
            new Formula
            {
                Id = "6_et02", Nome = "Modelo de Greenshields", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Engenharia de Tráfego",
                Expressao = "v(ρ) = v_f(1 - ρ/ρ_j);  q_max = v_f ρ_j / 4",
                ExprTexto = "Greenshields: v = vf·(1−ρ/ρj); fluxo máximo qmax = vf·ρj/4",
                Icone = "vf",
                Descricao = "Modelo de Greenshields: relação linear velocidade-densidade. vf = velocidade de fluxo livre, ρj = densidade de congestionamento. Modelo mais simples para diagrama fundamental.",
                Criador = "Bruce Greenshields",
                AnoOrigin = "1935",
            },
            new Formula
            {
                Id = "6_et03", Nome = "Fórmula de Webster (Semáforo)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Engenharia de Tráfego",
                Expressao = "C₀ = (1.5L + 5)/(1 - Σyᵢ);  d = C(1-λ)²/(2(1-λx)) + x²/(2q(1-x))",
                ExprTexto = "Webster: ciclo ótimo C₀ = (1.5L+5)/(1−Σyi); atraso = f(C,λ,x,q)",
                Icone = "C₀",
                Descricao = "Fórmula de Webster: ciclo ótimo de semáforo que minimiza atraso total. L = tempo perdido, yi = razão de fluxo. Segunda fórmula dá atraso médio por veículo.",
                Criador = "Frederick Webster",
                AnoOrigin = "1958",
            },
            new Formula
            {
                Id = "6_et04", Nome = "Modelo do Car-Following (IDM)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Engenharia de Tráfego",
                Expressao = "dv/dt = a[1 - (v/v₀)^δ - (s*(v,Δv)/s)²]",
                ExprTexto = "IDM: dv/dt = a·[1−(v/v₀)^δ−(s*/s)²]; modelo de seguimento",
                Icone = "IDM",
                Descricao = "Intelligent Driver Model: cada veículo acelera/freia segundo velocidade relativa e gap. Reproduz formação de congestionamento, stop-and-go e capacidade. Microscópico.",
                Criador = "Martin Treiber / Ansgar Hennecke / Dirk Helbing",
                AnoOrigin = "2000",
            },
            new Formula
            {
                Id = "6_et05", Nome = "Equilíbrio de Wardrop", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Engenharia de Tráfego",
                Expressao = "c_r(f*) ≤ c_s(f*)  ∀r com f*_r > 0, s alternativa (UE)",
                ExprTexto = "Wardrop UE: tempos de viagem iguais em rotas usadas, menores em não-usadas",
                Icone = "UE",
                Descricao = "Equilíbrio de Wardrop: nenhum motorista pode reduzir unilateralmente seu tempo mudando de rota. Programa de otimização convexa. Base de modelos de atribuição de tráfego.",
                Criador = "John Glen Wardrop",
                AnoOrigin = "1952",
            },
            new Formula
            {
                Id = "6_et06", Nome = "Diagrama Fundamental (Flow-Density)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Engenharia de Tráfego",
                Expressao = "q = ρ·v;  q_max em ρ_c;  onda de choque: w = Δq/Δρ",
                ExprTexto = "Diagrama: q = ρ·v; velocidade de onda wshock = Δq/Δρ",
                Icone = "FD",
                Descricao = "Diagrama fundamental de tráfego: relação q(ρ) em forma de parábola invertida. ρc = densidade crítica, qmax = capacidade. Velocidade de onda de choque = Δq/Δρ.",
                Criador = "Greenshields / Greenberg / Daganzo",
                AnoOrigin = "1935",
            },

            // 14.2 Transferência Radiativa
            new Formula
            {
                Id = "6_rt01", Nome = "Equação de Transferência Radiativa (RTE)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Transferência Radiativa",
                Expressao = "dI/ds = -κ_a I - κ_s I + κ_a B(T) + (κ_s/4π)∫ p(Ω',Ω)I dΩ'",
                ExprTexto = "RTE: dI/ds = −(κa+κs)I + κaB(T) + (κs/4π)∫ p·I dΩ'",
                Icone = "I",
                Descricao = "Equação de transferência radiativa: governa intensidade I ao longo de raio em meio absorvente/espalhante. Absorção κa, espalhamento κs, função de fase p, emissão B(T).",
                Criador = "Subrahmanyan Chandrasekhar",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_rt02", Nome = "Lei de Beer-Lambert", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Transferência Radiativa",
                Expressao = "I(s) = I₀ exp(-∫₀ˢ κ(s') ds');  τ = ∫ κ ds (profundidade óptica)",
                ExprTexto = "Beer-Lambert: I = I₀·exp(−τ); τ = ∫κ ds profundidade óptica",
                Icone = "τ",
                Descricao = "Lei de Beer-Lambert: atenuação exponencial de radiação em meio absorvente. Profundidade óptica τ integra coeficiente de extinção. Base de espectroscopia e sensoriamento remoto.",
                Criador = "Pierre Bouguer / Johann Lambert / August Beer",
                AnoOrigin = "1852",
            },
            new Formula
            {
                Id = "6_rt03", Nome = "Função de Fase de Henyey-Greenstein", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Transferência Radiativa",
                Expressao = "p(cos θ) = (1-g²)/(1+g²-2g cos θ)^{3/2}",
                ExprTexto = "HG: p(cosθ) = (1−g²)/(1+g²−2g·cosθ)^{3/2}; g=⟨cosθ⟩",
                Icone = "HG",
                Descricao = "Função de fase de Henyey-Greenstein: parametriza anisotropia de espalhamento por g∈[-1,1]. g>0 forward, g<0 backward. Usada em atmosferas, tecidos biológicos.",
                Criador = "Louis Henyey / Jesse Greenstein",
                AnoOrigin = "1941",
            },
            new Formula
            {
                Id = "6_rt04", Nome = "Aproximação de Difusão Radiativa", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Transferência Radiativa",
                Expressao = "-∇·(D∇φ) + κ_a φ = S;  D = 1/(3(κ_a+κ_s'))",
                ExprTexto = "Difusão: −∇·(D∇φ) + κa·φ = S; D = 1/(3(κa+κs(1−g)))",
                Icone = "D",
                Descricao = "Aproximação de difusão: válida quando espalhamento domina (τ≫1, g≈1). Reduz RTE a equação de difusão para fluência φ. Usada em tecidos biológicos e nuvens.",
                Criador = "Subrahmanyan Chandrasekhar",
                AnoOrigin = "1950",
            },
            new Formula
            {
                Id = "6_rt05", Nome = "Monte Carlo Radiativo", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Transferência Radiativa",
                Expressao = "s = -ln(ξ)/κ_t;  absorção: ξ < κ_a/κ_t;  θ via CDF de p",
                ExprTexto = "MC: livre caminho s = −ln(ξ)/κt; tipo de evento por ξ < κa/κt",
                Icone = "MC",
                Descricao = "Monte Carlo radiativo: amostra fótons individuais. Livre caminho exponencial, decisão absorção/espalhamento por κa/κt, novo ângulo pela função de fase. Referência em validação.",
                Criador = "John Howell / Modest",
                AnoOrigin = "1960",
            },
            new Formula
            {
                Id = "6_rt06", Nome = "Lei de Kirchhoff (Emissividade)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Transferência Radiativa",
                Expressao = "ε(λ,θ) = α(λ,θ);  emissividade = absortância em equilíbrio",
                ExprTexto = "Kirchhoff: ε(λ,θ) = α(λ,θ); emissividade = absortância",
                Icone = "ε",
                Descricao = "Lei de Kirchhoff: em equilíbrio térmico, emissividade espectral direcional iguala absortância. Relaciona propriedades de superfície. Base de engenharia térmica radiativa.",
                Criador = "Gustav Kirchhoff",
                AnoOrigin = "1860",
            },
            new Formula
            {
                Id = "6_rt07", Nome = "View Factor (Fator de Forma)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Transferência Radiativa",
                Expressao = "F_{12} = (1/A₁) ∫∫ (cos θ₁ cos θ₂)/(πr²) dA₁ dA₂",
                ExprTexto = "View factor: F12 = (1/A₁)∬(cosθ₁·cosθ₂/(πr²)) dA₁dA₂",
                Icone = "F₁₂",
                Descricao = "Fator de forma radiativo: fração de radiação que sai de A₁ e atinge A₂. Puramente geométrico. Propriedade de reciprocidade: A₁F₁₂=A₂F₂₁.",
                Criador = "Hoyt Hottel",
                AnoOrigin = "1954",
            },

            // 14.3 Colorimetria e Iluminação
            new Formula
            {
                Id = "6_ct01", Nome = "Tristimulus XYZ (CIE 1931)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Colorimetria e Iluminação",
                Expressao = "X = ∫ S(λ)x̄(λ)dλ;  Y = ∫ S(λ)ȳ(λ)dλ;  Z = ∫ S(λ)z̄(λ)dλ",
                ExprTexto = "CIE: X=∫S·x̄dλ, Y=∫S·ȳdλ, Z=∫S·z̄dλ; coordenadas de cor",
                Icone = "XYZ",
                Descricao = "Sistema CIE 1931 XYZ: coordenadas de cor obtidas pela integração do espectro S(λ) com funções de matching x̄,ȳ,z̄. Y = luminância. Base de toda colorimetria.",
                Criador = "CIE (Commission Internationale de l'Éclairage)",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "6_ct02", Nome = "Cromaticidade xy e Iluminante D65", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Colorimetria e Iluminação",
                Expressao = "x = X/(X+Y+Z);  y = Y/(X+Y+Z);  diagrama de cromaticidade",
                ExprTexto = "Cromaticidade: x=X/(X+Y+Z), y=Y/(X+Y+Z); projeção normalizada",
                Icone = "xy",
                Descricao = "Diagrama de cromaticidade CIE xy: projeção normalizada do XYZ. Todas as cores visíveis dentro do locus espectral. D65 = iluminante padrão luz do dia (6504K).",
                Criador = "CIE",
                AnoOrigin = "1931",
            },
            new Formula
            {
                Id = "6_ct03", Nome = "Diferença de Cor CIEDE2000", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Colorimetria e Iluminação",
                Expressao = "ΔE₀₀ = √((ΔL'/kLSL)²+(ΔC'/kCSC)²+(ΔH'/kHSH)²+RT(ΔC'/kCSC)(ΔH'/kHSH))",
                ExprTexto = "CIEDE2000: ΔE = f(ΔL',ΔC',ΔH',RT); diferença perceptual de cor",
                Icone = "ΔE",
                Descricao = "CIEDE2000: fórmula de diferença de cor perceptualmente uniforme. Inclui correções de luminosidade, croma, hue e termo de rotação RT. ΔE<1 imperceptível.",
                Criador = "CIE / Gaurav Sharma / Wencheng Wu / Edul Dalal",
                AnoOrigin = "2000",
            },
            new Formula
            {
                Id = "6_ct04", Nome = "Rendering Equation (Iluminação)", Categoria = "Tráfego e Transferência Radiativa", SubCategoria = "Colorimetria e Iluminação",
                Expressao = "L_o(x,ω_o) = L_e(x,ω_o) + ∫_Ω f_r(x,ω_i,ω_o) L_i(x,ω_i)(ω_i·n) dω_i",
                ExprTexto = "Rendering: Lo = Le + ∫ fr·Li·cosθ dω; equação de renderização",
                Icone = "Lo",
                Descricao = "Equação de rendering de Kajiya: radiância de saída = emissão + integral da BRDF × radiância incidente × cosseno. Base de ray tracing, path tracing e radiosity.",
                Criador = "James Kajiya",
                AnoOrigin = "1986",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 15. SÍSMICA, ELETROQUÍMICA E CONFIABILIDADE
    // ─────────────────────────────────────────────────────
    private void AdicionarSismicaEletroquimica()
    {
        _formulas.AddRange([
            // 15.1 Engenharia Sísmica
            new Formula
            {
                Id = "6_se01", Nome = "Espectro de Resposta (Sísmica)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Engenharia Sísmica",
                Expressao = "S_a(T,ξ) = max|ü+2ξω_n u̇+ω_n²u|;  ω_n=2π/T",
                ExprTexto = "Sa(T,ξ): máxima aceleração de oscilador 1DOF com período T e amortecimento ξ",
                Icone = "Sa",
                Descricao = "Espectro de resposta sísmica: máxima resposta de osciladores de 1 grau de liberdade em função do período T e amortecimento ξ. Base do projeto sísmico em normas.",
                Criador = "Maurice Biot / George Housner",
                AnoOrigin = "1941",
            },
            new Formula
            {
                Id = "6_se02", Nome = "Análise Modal (Superposição)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Engenharia Sísmica",
                Expressao = "u(t) = Σ φₙ qₙ(t);  q̈ₙ+2ξₙωₙq̇ₙ+ωₙ²qₙ = -Γₙ üg",
                ExprTexto = "Modal: u = Σφₙqₙ; qₙ(t) = resposta do modo n ao sismo",
                Icone = "φ",
                Descricao = "Análise modal: decompõe resposta estrutural em modos naturais φₙ. Cada modo é oscilador 1DOF independente. Γₙ = fator de participação modal. Base da análise sísmica.",
                Criador = "Ray Clough / Joseph Penzien",
                AnoOrigin = "1975",
            },
            new Formula
            {
                Id = "6_se03", Nome = "Fator de Comportamento (q-factor)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Engenharia Sísmica",
                Expressao = "V_d = V_e / q;  q = (μ·R_Ω·R_ρ);  μ = ductilidade",
                ExprTexto = "q-factor: Vd = Ve/q; reduz força sísmica pela ductilidade da estrutura",
                Icone = "q",
                Descricao = "Fator de comportamento q: reduz forças sísmicas elásticas para projeto em regime inelástico. Depende de ductilidade μ, sobrerresistência e redundância. Eurocode 8.",
                Criador = "CEN (Eurocode 8) / ATC (R-factor)",
                AnoOrigin = "1978",
            },
            new Formula
            {
                Id = "6_se04", Nome = "Isolamento de Base (Período Alvo)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Engenharia Sísmica",
                Expressao = "T_iso = 2π√(M/K_iso);  Sd(T_iso) = Sd_max platô → reduz Sa",
                ExprTexto = "Tiso = 2π√(M/Kiso); alonga período para reduzir aceleração espectral",
                Icone = "iso",
                Descricao = "Isolamento sísmico de base: apoios flexíveis aumentam período natural para fora do platô espectral. Reduz acelerações em 60-80%. Edifícios e pontes críticas.",
                Criador = "James Kelly / Ivan Skinner",
                AnoOrigin = "1980",
            },
            new Formula
            {
                Id = "6_se05", Nome = "Magnitude-Momento (Mw)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Engenharia Sísmica",
                Expressao = "M_w = (2/3)(log₁₀ M₀ - 9.1);  M₀ = μ·A·D",
                ExprTexto = "Mw = (2/3)(log M₀−9.1); M₀ = rigidez·área·deslizamento",
                Icone = "Mw",
                Descricao = "Magnitude-momento: escala sísmica baseada no momento sísmico M₀. μ = rigidez da rocha, A = área de ruptura, D = deslizamento médio. Não satura como Richter.",
                Criador = "Hiroo Kanamori",
                AnoOrigin = "1977",
            },

            // 15.2 Eletroquímica
            new Formula
            {
                Id = "6_ec01", Nome = "Equação de Nernst", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Eletroquímica",
                Expressao = "E = E⁰ - (RT/nF)ln(Q);  Q = [Red]/[Ox]",
                ExprTexto = "Nernst: E = E⁰ − (RT/(nF))·ln(Q); potencial de eletrodo",
                Icone = "E",
                Descricao = "Equação de Nernst: relaciona potencial de eletrodo E à atividade dos reagentes. E⁰ = potencial padrão, n = elétrons transferidos. Fundamental em baterias e sensores.",
                Criador = "Walther Nernst",
                AnoOrigin = "1889",
            },
            new Formula
            {
                Id = "6_ec02", Nome = "Equação de Butler-Volmer", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Eletroquímica",
                Expressao = "j = j₀[exp(αₐFη/RT) - exp(-αcFη/RT)]",
                ExprTexto = "Butler-Volmer: j = j₀·[exp(αaFη/RT)−exp(−αcFη/RT)]",
                Icone = "j₀",
                Descricao = "Butler-Volmer: densidade de corrente em função do sobrepotencial η. j₀ = corrente de troca, αa,αc = coeficientes de transferência. Cinética eletroquímica fundamental.",
                Criador = "John Butler / Max Volmer",
                AnoOrigin = "1924",
            },
            new Formula
            {
                Id = "6_ec03", Nome = "Equação de Tafel", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Eletroquímica",
                Expressao = "η = a + b·log|j|;  b = 2.303RT/(αnF) (inclinação de Tafel)",
                ExprTexto = "Tafel: η = a + b·log|j|; caso limite de Butler-Volmer, |η|>>RT/F",
                Icone = "b",
                Descricao = "Equação de Tafel: aproximação de Butler-Volmer para altos sobrepotenciais. Relação linear η vs log|j|. Inclinação b revela mecanismo da reação (α). Corrosão e eletrocatálise.",
                Criador = "Julius Tafel",
                AnoOrigin = "1905",
            },
            new Formula
            {
                Id = "6_ec04", Nome = "Lei de Faraday (Eletrólise)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Eletroquímica",
                Expressao = "m = MIt/(nF);  m = massa depositada, I = corrente",
                ExprTexto = "Faraday: m = M·I·t/(n·F); massa ∝ carga passada",
                Icone = "F",
                Descricao = "Lei de Faraday da eletrólise: massa depositada proporcional à carga total (I·t = Q) e peso equivalente M/n. F = 96485 C/mol. Base de eletrodeposição industrial.",
                Criador = "Michael Faraday",
                AnoOrigin = "1834",
            },
            new Formula
            {
                Id = "6_ec05", Nome = "Impedância de Nyquist (EIS)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Eletroquímica",
                Expressao = "Z(ω) = R_s + R_ct/(1+(jωR_ct C_dl));  semicírculo em plano Z",
                ExprTexto = "EIS Randles: Z = Rs + Rct/(1+jωRctCdl); semicírculo no diagrama de Nyquist",
                Icone = "Z",
                Descricao = "Espectroscopia de impedância eletroquímica: circuito Randles com Rs (solução), Rct (transferência de carga), Cdl (dupla camada). Diagnóstico de baterias e corrosão.",
                Criador = "John Randles",
                AnoOrigin = "1947",
            },
            new Formula
            {
                Id = "6_ec06", Nome = "Equação de Warburg (Difusão)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Eletroquímica",
                Expressao = "Z_W = σ/√ω · (1-j);  σ = RT/(n²F²A√2)(1/(√D_O C_O)+1/(√D_R C_R))",
                ExprTexto = "Warburg: ZW = σ·(1−j)/√ω; impedância de difusão ~1/√ω",
                Icone = "W",
                Descricao = "Impedância de Warburg: contribuição difusional à impedância eletroquímica. Reta a 45° no diagrama de Nyquist. Dominante em baixas frequências. σ = coeficiente de Warburg.",
                Criador = "Emil Warburg",
                AnoOrigin = "1899",
            },

            // 15.3 Confiabilidade
            new Formula
            {
                Id = "6_cr01", Nome = "Função de Confiabilidade", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Confiabilidade",
                Expressao = "R(t) = P(T>t) = 1-F(t) = exp(-∫₀ᵗ λ(s) ds)",
                ExprTexto = "R(t) = exp(−∫λ(s)ds); prob. de sobrevivência até t",
                Icone = "R",
                Descricao = "Função de confiabilidade (sobrevivência): probabilidade de funcionar sem falha até t. λ(t) = taxa de falha (hazard rate). R(t) decrescente de 1 a 0.",
                Criador = "Erich Pieruschka / Waloddi Weibull",
                AnoOrigin = "1951",
            },
            new Formula
            {
                Id = "6_cr02", Nome = "Distribuição de Weibull", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Confiabilidade",
                Expressao = "f(t) = (β/η)(t/η)^{β-1} exp(-(t/η)^β);  MTTF = η·Γ(1+1/β)",
                ExprTexto = "Weibull: f(t) = (β/η)(t/η)^{β−1}·exp(−(t/η)^β); MTTF = η·Γ(1+1/β)",
                Icone = "β",
                Descricao = "Distribuição de Weibull: β<1 mortalidade infantil, β=1 exponencial, β>1 desgaste. η = vida característica. Modelo mais usado em confiabilidade de equipamentos.",
                Criador = "Waloddi Weibull",
                AnoOrigin = "1951",
            },
            new Formula
            {
                Id = "6_cr03", Nome = "MTTF / MTBF", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Confiabilidade",
                Expressao = "MTTF = ∫₀^∞ R(t) dt;  MTBF = MTTF + MTTR (reparável)",
                ExprTexto = "MTTF = ∫R(t)dt; MTBF = MTTF+MTTR para sistemas reparáveis",
                Icone = "MT",
                Descricao = "MTTF: tempo médio até falha (não reparável). MTBF: tempo médio entre falhas (reparável) = MTTF + tempo de reparo MTTR. Métricas fundamentais de confiabilidade.",
                Criador = "US Military (MIL-HDBK-217)",
                AnoOrigin = "1962",
            },
            new Formula
            {
                Id = "6_cr04", Nome = "Sistema Série/Paralelo", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Confiabilidade",
                Expressao = "R_série = Π Rᵢ;  R_paralelo = 1 - Π(1-Rᵢ)",
                ExprTexto = "Série: R = ΠRi; Paralelo: R = 1−Π(1−Ri); redundância melhora R",
                Icone = "Σ",
                Descricao = "Confiabilidade série (todos devem funcionar): R = ΠRi. Paralelo (ao menos um): R = 1−Π(1−Ri). Redundância paralela aumenta confiabilidade.",
                Criador = "Barlow / Proschan",
                AnoOrigin = "1965",
            },
            new Formula
            {
                Id = "6_cr05", Nome = "Árvore de Falhas (FTA)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Confiabilidade",
                Expressao = "P(topo) = f(P₁,...,Pₙ, portas AND/OR);  MCS = cortes mínimos",
                ExprTexto = "FTA: P(topo) via portas AND/OR; minimal cut sets determinam vulnerabilidades",
                Icone = "FT",
                Descricao = "Fault Tree Analysis: diagrama lógico top-down de como eventos básicos combinam (AND/OR) para causar falha do sistema. MCS = conjuntos mínimos de corte.",
                Criador = "H.A. Watson / Bell Labs para USAF",
                AnoOrigin = "1962",
            },
            new Formula
            {
                Id = "6_cr06", Nome = "Processo de Poisson (Falhas)", Categoria = "Sísmica e Eletroquímica", SubCategoria = "Confiabilidade",
                Expressao = "P(N(t)=k) = (λt)^k e^{-λt}/k!;  E[N]=λt, taxa constante",
                ExprTexto = "Poisson: P(k falhas em t) = (λt)^k·exp(−λt)/k!; taxa λ constante",
                Icone = "λ",
                Descricao = "Processo de Poisson homogêneo: falhas aleatórias independentes com taxa constante λ. Tempos entre falhas exponenciais. Modelo da fase de vida útil (bathtub curve).",
                Criador = "Siméon Denis Poisson",
                AnoOrigin = "1837",
            },
        ]);
    }
}
