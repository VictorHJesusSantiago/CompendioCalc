using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 4 — PARTE II: FÍSICA TEÓRICA DE FRONTEIRA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 6. TQC AVANÇADA: RENORMALIZAÇÃO E SUPERSIMETRIA
    // ─────────────────────────────────────────────────────
    private void AdicionarRenormalizacaoSUSY()
    {
        _formulas.AddRange([
            // 6.1 Renormalização
            new Formula
            {
                Id = "4_rn01", Nome = "Regularização Dimensional", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "d = 4 - ε;  ∫ d^dk → μ^ε ∫ d^dk",
                ExprTexto = "d=4−ε; ∫dᵈk → μᵋ∫dᵈk",
                Icone = "ε",
                Descricao = "Calcula integrais divergentes em d=4-ε dimensões, isola divergências como polos 1/ε. Preserva invariância de gauge. μ = escala de massa introduzida.",
                Criador = "Gerard 't Hooft / Martinus Veltman",
                AnoOrigin = "1972",
            },
            new Formula
            {
                Id = "4_rn02", Nome = "Esquema MS-bar", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "Subtrai 1/ε + ln(4π) - γ_E",
                ExprTexto = "MS̄: subtrai 1/ε−γ_E+ln4π",
                Icone = "MS̄",
                Descricao = "Subtração mínima modificada: remove polo 1/ε mais constantes universais. Esquema mais usado em QCD. Parâmetros dependem da escala μ.",
            },
            new Formula
            {
                Id = "4_rn03", Nome = "Equação de Callan-Symanzik", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "[μ∂/∂μ + β(g)∂/∂g + nγ(g)]G⁽ⁿ⁾=0",
                ExprTexto = "[μ∂μ+β∂g+nγ]G⁽ⁿ⁾=0",
                Icone = "CS",
                Descricao = "Equação do grupo de renormalização: funções de Green G(n) satisfazem esta equação. β controla evolução da constante de acoplamento, γ a dimensão anômala.",
                Criador = "Curtis Callan / Kurt Symanzik",
                AnoOrigin = "1970",
            },
            new Formula
            {
                Id = "4_rn04", Nome = "Função Beta da QED", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "β(e) = e³/(12π²) + O(e⁵)  (1 loop)",
                ExprTexto = "β_QED = e³/12π² + O(e⁵)",
                Icone = "β_e",
                Descricao = "β>0: constante de acoplamento da QED cresce com a energia (liberdade assintótica inversa). Polo de Landau em energia exponencialmente alta.",
                Criador = "Murray Gell-Mann / Francis Low",
                AnoOrigin = "1954",
            },
            new Formula
            {
                Id = "4_rn05", Nome = "Função Beta da QCD", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "β(g) = -g³/(16π²)(11-2Nf/3) + ...",
                ExprTexto = "β_QCD = −g³(11−2Nf/3)/16π²",
                Icone = "β_s",
                Descricao = "β<0 para Nf<33/2: liberdade assintótica! Constante forte αs diminui em altas energias. Descoberta central da QCD (Nobel 2004).",
                Criador = "David Gross / Frank Wilczek / David Politzer",
                AnoOrigin = "1973",
            },
            new Formula
            {
                Id = "4_rn06", Nome = "Running Coupling (QCD)", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "αₛ(Q²) = αₛ(μ²)/[1 + (β₀αₛ/2π)ln(Q²/μ²)]",
                ExprTexto = "αₛ(Q²) ≈ 2π/[β₀·ln(Q²/Λ²)]",
                Icone = "αₛ",
                Descricao = "Evolução da constante de acoplamento forte com a energia Q. β₀=(33-2Nf)/6π. Λ_QCD ≈ 200 MeV define a escala de confinamento.",
            },
            new Formula
            {
                Id = "4_rn07", Nome = "Dimensão Anômala", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "γ(g) = μ ∂/∂μ ln Z",
                ExprTexto = "γ(g) = μ∂μ ln Z",
                Icone = "γ",
                Descricao = "Desvio da dimensão clássica (engenharia) de um operador/campo. Resultado quântico: operadores adquirem dimensões fracionárias. [O] = Δ_cl + γ.",
            },
            new Formula
            {
                Id = "4_rn08", Nome = "Contratermo", Categoria = "Renormalização e SUSY", SubCategoria = "Renormalização",
                Expressao = "L_CT = (Z-1)·L_bare = Σ δZᵢ·Oᵢ",
                ExprTexto = "ℒ_CT = (Z−1)ℒ_bare",
                Icone = "CT",
                Descricao = "Contratemos absorvem divergências: adicionados à Lagrangiana para cancelar infinitos. Teoria renormalizável: número finito de contratermos.",
            },
            // 6.2 Grupo de Renormalização
            new Formula
            {
                Id = "4_rg01", Nome = "Transformação do GR (Wilson)", Categoria = "Renormalização e SUSY", SubCategoria = "Grupo de Renormalização",
                Expressao = "Integrar modos com Λ/b < k < Λ; reescalar",
                ExprTexto = "Integra modos altos; reescala → fluxo no espaço de teorias",
                Icone = "RG",
                Descricao = "Ideia de Wilson: integra graus de liberdade de alta energia iterativamente, obtendo teoria efetiva em escala mais baixa. Fluxo no espaço infinito-dimensional de acoplamentos.",
                Criador = "Kenneth Wilson",
                AnoOrigin = "1971",
            },
            new Formula
            {
                Id = "4_rg02", Nome = "Ponto Fixo do GR", Categoria = "Renormalização e SUSY", SubCategoria = "Grupo de Renormalização",
                Expressao = "β(g*) = 0; fluxo para em g*",
                ExprTexto = "β(g*) = 0 → ponto fixo",
                Icone = "g*",
                Descricao = "Teoria no ponto fixo é invariante de escala (conforme). UV fixo: teoria bem definida em todas escalas (safety). IR fixo: comportamento de longo alcance universal.",
            },
            new Formula
            {
                Id = "4_rg03", Nome = "Operador Relevante", Categoria = "Renormalização e SUSY", SubCategoria = "Grupo de Renormalização",
                Expressao = "dim[O] < d ⟹ cresce no IR;  relevante",
                ExprTexto = "Δ < d: relevante (cresce no IR)",
                Icone = "rel",
                Descricao = "Operador com dimensão < d (dimensão do espaço-tempo): sua perturbação cresce em baixas energias. Massa é relevante (Δ=2<4). Determina universalidade.",
            },
            new Formula
            {
                Id = "4_rg04", Nome = "Operador Irrelevante", Categoria = "Renormalização e SUSY", SubCategoria = "Grupo de Renormalização",
                Expressao = "dim[O] > d ⟹ decresce no IR;  irrelevante",
                ExprTexto = "Δ > d: irrelevante (decresce no IR)",
                Icone = "irr",
                Descricao = "Operador com dimensão > d: perturbação decresce em baixas energias. Teorias efetivas: operadores de dimensão >4 são suprimidos por potências de Λ.",
            },
            new Formula
            {
                Id = "4_rg05", Nome = "Operador Marginal", Categoria = "Renormalização e SUSY", SubCategoria = "Grupo de Renormalização",
                Expressao = "dim[O] = d;  marginalmente relevante/irrelevante",
                ExprTexto = "Δ = d: marginal (correções quânticas decidem)",
                Icone = "mar",
                Descricao = "Dimensão = d: comportamento determinado por correções quânticas (dimensões anômalas). QCD: gluon é marginal mas marginalmente irrelevante (liberdade assintótica).",
            },
            new Formula
            {
                Id = "4_rg06", Nome = "Universalidade", Categoria = "Renormalização e SUSY", SubCategoria = "Grupo de Renormalização",
                Expressao = "Só operadores relevantes importam → mesmos expoentes críticos",
                ExprTexto = "Universalidade: expoentes dependem só de d, N, simetria",
                Icone = "univ",
                Descricao = "Sistemas diferentes com mesma dimensão, simetria e tipo de parâmetro de ordem pertencem à mesma classe de universalidade. Expoentes críticos idênticos (ex.: água e imã Ising 3D).",
            },
            // 6.3 Supersimetria
            new Formula
            {
                Id = "4_sy01", Nome = "Álgebra de Supersimetria (N=1)", Categoria = "Renormalização e SUSY", SubCategoria = "Supersimetria",
                Expressao = "{Qα, Q̄_β̇} = 2σ^μ_{αβ̇} Pμ",
                ExprTexto = "{Qα,Q̄β̇} = 2σᵘαβ̇Pμ",
                Icone = "Q",
                Descricao = "Anticomutador dos geradores SUSY dá o operador de translação. Conecta bósons e férmions: Q|boson⟩=|fermion⟩. Única extensão não-trivial do grupo de Poincaré.",
                Criador = "Julius Wess / Bruno Zumino",
                AnoOrigin = "1974",
            },
            new Formula
            {
                Id = "4_sy02", Nome = "Supercampo Quiral", Categoria = "Renormalização e SUSY", SubCategoria = "Supersimetria",
                Expressao = "Φ(y,θ) = φ(y) + √2 θψ(y) + θ²F(y)",
                ExprTexto = "Φ = φ + √2θψ + θ²F",
                Icone = "Φ",
                Descricao = "Supercampo que satisfaz D̄Φ=0. Componentes: escalar φ, férmion ψ (parceiro SUSY), campo auxiliar F (sem dinâmica). y=x+iθσθ̄.",
            },
            new Formula
            {
                Id = "4_sy03", Nome = "Superpotencial", Categoria = "Renormalização e SUSY", SubCategoria = "Supersimetria",
                Expressao = "W(Φ) = mΦ² + λΦ³  (holomorfo em Φ)",
                ExprTexto = "W(Φ) = mΦ²+λΦ³",
                Icone = "W",
                Descricao = "Função holomorfa dos supercampos quirais. Não recebe correções radiativas perturbativas (teorema de não-renormalização). Determina o potencial escalar e acoplamentos de Yukawa.",
            },
            new Formula
            {
                Id = "4_sy04", Nome = "Potencial Escalar SUSY", Categoria = "Renormalização e SUSY", SubCategoria = "Supersimetria",
                Expressao = "V = Σᵢ|∂W/∂φᵢ|² + ½Σₐ Dₐ²",
                ExprTexto = "V = Σ|∂W/∂φᵢ|² + ½ΣDₐ²",
                Icone = "V",
                Descricao = "Potencial escalar = termos F (derivadas do superpotencial) + termos D (auxiliares de gauge). SUSY não-quebrada ⟹ V=0 ⟹ ∂W/∂φᵢ=0 e Dₐ=0.",
            },
            new Formula
            {
                Id = "4_sy05", Nome = "Quebra Suave de SUSY", Categoria = "Renormalização e SUSY", SubCategoria = "Supersimetria",
                Expressao = "L_soft = m_scalar² |φ|² + M_gaugino λλ + ...",
                ExprTexto = "ℒ_soft: massas de escalares, gauginos, termos A,B",
                Icone = "soft",
                Descricao = "SUSY deve ser quebrada (parceiros não observados). Termos suaves mantêm cancelamento de divergências quadráticas (solução do problema de hierarquia). Massas ~TeV.",
            },
            new Formula
            {
                Id = "4_sy06", Nome = "Unificação de Gauge (MSSM)", Categoria = "Renormalização e SUSY", SubCategoria = "Supersimetria",
                Expressao = "α₁(M_GUT) = α₂(M_GUT) = α₃(M_GUT);  M_GUT~10¹⁶ GeV",
                ExprTexto = "α₁=α₂=α₃ em M_GUT≈10¹⁶GeV (MSSM)",
                Icone = "GUT",
                Descricao = "No MSSM (modelo padrão SUSY mínimo), as três constantes de acoplamento convergem precisamente em ~10¹⁶ GeV. No SM sem SUSY, não convergem. Evidência indireta para SUSY.",
            },
            new Formula
            {
                Id = "4_sy07", Nome = "Teorema de Não-Renormalização", Categoria = "Renormalização e SUSY", SubCategoria = "Supersimetria",
                Expressao = "W não recebe correções perturbativas além de 1-loop",
                ExprTexto = "δW_pert = 0 (Seiberg/holomorfismo)",
                Icone = "NR",
                Descricao = "O superpotencial não é renormalizado perturbativamente (holomorfia + simetria R + limite fraco). Correções não-perturbativas (instantons) podem contribuir. Holomorfismo é poderoso.",
                Criador = "Nathan Seiberg",
                AnoOrigin = "1993",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 7. AdS/CFT E HOLOGRAFIA
    // ─────────────────────────────────────────────────────
    private void AdicionarAdSCFT()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "4_ac01", Nome = "Correspondência AdS/CFT", Categoria = "AdS/CFT e Holografia", SubCategoria = "Dualidade Holográfica",
                Expressao = "Gravidade em AdS_{d+1} ↔ CFT em ∂(AdS) = ℝ^{d-1,1}",
                ExprTexto = "Grav. AdS_{d+1} ↔ CFT_d no bordo",
                Icone = "AdS",
                Descricao = "Conjectura de Maldacena: teoria de gravidade quântica (cordas) em espaço anti-de Sitter é dual a teoria conforme de campos no bordo. Dualidade forte-fraco.",
                Criador = "Juan Maldacena",
                AnoOrigin = "1997",
            },
            new Formula
            {
                Id = "4_ac02", Nome = "Caso Canônico", Categoria = "AdS/CFT e Holografia", SubCategoria = "Dualidade Holográfica",
                Expressao = "IIB em AdS₅×S⁵ ↔ N=4 SYM em 4D, SU(N)",
                ExprTexto = "IIB/AdS₅×S⁵ ↔ 𝒩=4 SYM SU(N)",
                Icone = "N=4",
                Descricao = "Caso mais estudado: cordas tipo IIB em AdS₅×S⁵ ↔ teoria N=4 Super Yang-Mills em 4D com grupo SU(N). N grande ↔ gravidade clássica. λ grande ↔ supergravidade.",
            },
            new Formula
            {
                Id = "4_ac03", Nome = "Dicionário AdS/CFT", Categoria = "AdS/CFT e Holografia", SubCategoria = "Dualidade Holográfica",
                Expressao = "⟨e^{∫ φ₀ O}⟩_CFT = Z_grav[φ→φ₀ no bordo]",
                ExprTexto = "⟨e^{∫φ₀𝒪}⟩_CFT = Z_grav[φ|∂=φ₀]",
                Icone = "dict",
                Descricao = "O gerador de funções de correlação na CFT = função de partição gravitacional com condições de bordo. Campo bulk φ ↔ operador O na CFT. Massa no bulk → dimensão conforme Δ.",
            },
            new Formula
            {
                Id = "4_ac04", Nome = "Relação Massa-Dimensão", Categoria = "AdS/CFT e Holografia", SubCategoria = "Dualidade Holográfica",
                Expressao = "Δ(Δ-d) = m²L²  (escalar em AdS_{d+1})",
                ExprTexto = "Δ(Δ−d) = m²L²",
                Icone = "Δ",
                Descricao = "Massa do campo escalar no bulk ↔ dimensão conforme na CFT. L = raio de AdS. Forma: Δ = d/2 + √(d²/4 + m²L²). m²<0 permitido (bound de BF).",
            },
            new Formula
            {
                Id = "4_ac05", Nome = "Métrica de AdS_{d+1}", Categoria = "AdS/CFT e Holografia", SubCategoria = "Dualidade Holográfica",
                Expressao = "ds² = (L/z)²(dz² + ημν dxμdxν);  z>0",
                ExprTexto = "ds² = (L/z)²(dz²+ημνdxᵘdxᵛ)",
                Icone = "ds²",
                Descricao = "Coordenadas de Poincaré: bordo em z→0, horizonte em z→∞. L = raio de curvatura. Espaço de curvatura constante negativa, maximalmente simétrico.",
            },
            new Formula
            {
                Id = "4_ac06", Nome = "Limite de N Grande", Categoria = "AdS/CFT e Holografia", SubCategoria = "Dualidade Holográfica",
                Expressao = "N→∞, λ=g²N fixo → diagramas planares dominam",
                ExprTexto = "N→∞, λ=g²N fixo (limite 't Hooft)",
                Icone = "N→∞",
                Descricao = "No limite de N grande (muitas cores): teoria de gauge simplifica (diagramas planares). Dual gravitacional torna-se clássico. 1/N² ↔ correções de loops em gravidade.",
                Criador = "Gerard 't Hooft",
                AnoOrigin = "1974",
            },
            new Formula
            {
                Id = "4_ac07", Nome = "Fórmula de Ryu-Takayanagi", Categoria = "AdS/CFT e Holografia", SubCategoria = "Entropia e Informação",
                Expressao = "S(A) = Area(γ_A)/(4G_N)",
                ExprTexto = "S(A) = Área(γ_A)/4Gₙ",
                Icone = "S_EE",
                Descricao = "Entropia de emaranhamento de região A na CFT = área da superfície mínima γ_A no bulk que ancora em ∂A. Generaliza Bekenstein-Hawking. (Nobel-adjacent, Fields 2022 context).",
                Criador = "Shinsei Ryu / Tadashi Takayanagi",
                AnoOrigin = "2006",
            },
            new Formula
            {
                Id = "4_ac08", Nome = "Entropia de Bekenstein-Hawking", Categoria = "AdS/CFT e Holografia", SubCategoria = "Entropia e Informação",
                Expressao = "S_BH = A/(4ℏG)",
                ExprTexto = "S_BH = A/4ℏG",
                Icone = "S_BH",
                Descricao = "Entropia de buraco negro proporcional à área do horizonte (não volume!). Princípio holográfico: graus de liberdade gravitacionais vivem na fronteira. Base da holografia.",
                Criador = "Jacob Bekenstein / Stephen Hawking",
                AnoOrigin = "1973/1975",
            },
            new Formula
            {
                Id = "4_ac09", Nome = "ER = EPR", Categoria = "AdS/CFT e Holografia", SubCategoria = "Entropia e Informação",
                Expressao = "Ponte de Einstein-Rosen ↔ Par Einstein-Podolsky-Rosen",
                ExprTexto = "Wormhole ↔ Emaranhamento",
                Icone = "ER=EPR",
                Descricao = "Conjectura de Maldacena-Susskind: emaranhamento quântico (EPR) é geometricamente dual a wormholes (pontes ER). Conecta informação quântica à geometria do espaço-tempo.",
                Criador = "Juan Maldacena / Leonard Susskind",
                AnoOrigin = "2013",
            },
            new Formula
            {
                Id = "4_ac10", Nome = "Complexidade = Volume", Categoria = "AdS/CFT e Holografia", SubCategoria = "Entropia e Informação",
                Expressao = "C ∝ V(Σ)/(G_N L)",
                ExprTexto = "C ∝ Vol(Σ)/GₙL",
                Icone = "C=V",
                Descricao = "Complexidade computacional do estado na CFT ∝ volume da fatia maximal no bulk. Captura informação além da entropia: continua crescendo após termalização.",
            },
            new Formula
            {
                Id = "4_ac11", Nome = "Complexidade = Ação", Categoria = "AdS/CFT e Holografia", SubCategoria = "Entropia e Informação",
                Expressao = "C = I_WDW/(πℏ)  (ação na Wheeler-DeWitt patch)",
                ExprTexto = "C = I_WDW/πℏ",
                Icone = "C=A",
                Descricao = "Proposta alternativa: complexidade = ação gravitacional na Wheeler-DeWitt patch. Satisfaz bound de Lloyd: dC/dt ≤ 2E/πℏ.",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 8. COSMOLOGIA INFLACIONÁRIA E ALÉM DO MODELO PADRÃO
    // ─────────────────────────────────────────────────────
    private void AdicionarCosmologiaInflacionaria()
    {
        _formulas.AddRange([
            // 8.1 Inflação
            new Formula
            {
                Id = "4_ci01", Nome = "Campo Inflaton", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "φ̈ + 3Hφ̇ + V'(φ) = 0",
                ExprTexto = "φ̈+3Hφ̇+V'(φ)=0",
                Icone = "φ",
                Descricao = "Equação de Klein-Gordon para campo escalar em FRW. Termo 3Hφ̇ = 'atrito' Hubble. Inflação ocorre quando V domina sobre energia cinética: slow-roll.",
            },
            new Formula
            {
                Id = "4_ci02", Nome = "Equação de Friedmann (com inflaton)", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "H² = (8πG/3)(½φ̇² + V(φ))",
                ExprTexto = "H² = 8πG(½φ̇²+V)/3",
                Icone = "H²",
                Descricao = "Taxa de expansão Hubble determinada pela densidade de energia do inflaton. Durante slow-roll: H² ≈ 8πGV/3 (quase constante → expansão exponencial).",
            },
            new Formula
            {
                Id = "4_ci03", Nome = "Parâmetros de Slow-Roll", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "ε = (M_P²/2)(V'/V)²; η = M_P² V''/V;  ε,|η|≪1",
                ExprTexto = "ε=(Mₚ²/2)(V'/V)²; η=Mₚ²V''/V; ε,|η|≪1",
                Icone = "ε,η",
                Descricao = "Condições para inflação: potencial plano (V' pequeno) e pouco curvado (V'' pequeno). Inflação termina quando ε~1. ε controla razão tensor/escalar r=16ε.",
            },
            new Formula
            {
                Id = "4_ci04", Nome = "Número de e-folds", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "N = ∫ H dt ≈ ∫ V/(M_P²V') dφ;  N ≳ 60",
                ExprTexto = "N = ∫Hdt ≈ ∫V/(Mₚ²V')dφ ≳ 60",
                Icone = "N",
                Descricao = "Fator de expansão durante inflação: a(t_f)/a(t_i) = e^N. N≳60 necessário para resolver problemas do horizonte e planura. a expande por fator ~10²⁶.",
            },
            new Formula
            {
                Id = "4_ci05", Nome = "Espectro de Potência Escalar", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "P_s(k) = H²/(8π²ε M_P²)|_{k=aH}",
                ExprTexto = "Pₛ(k) = H²/8π²εMₚ² |_{k=aH}",
                Icone = "Pₛ",
                Descricao = "Flutuações quânticas do inflaton geram perturbações de densidade. Avaliado no horizon crossing k=aH. Pₛ ≈ 2.1×10⁻⁹ (observado por Planck/WMAP).",
            },
            new Formula
            {
                Id = "4_ci06", Nome = "Índice Espectral", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "nₛ = 1 - 6ε + 2η ≈ 0.965",
                ExprTexto = "nₛ = 1−6ε+2η ≈ 0.965",
                Icone = "nₛ",
                Descricao = "Desvio de escala-invariância (nₛ=1). nₛ<1 (red tilt) observado por Planck: confirma slow-roll. Discrimina modelos de inflação.",
            },
            new Formula
            {
                Id = "4_ci07", Nome = "Razão Tensor/Escalar", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "r = P_T/P_S = 16ε",
                ExprTexto = "r = P_T/P_S = 16ε",
                Icone = "r",
                Descricao = "Amplitude relativa de ondas gravitacionais primordiais. r<0.036 (Planck+BICEP). Modelos de campo grande: r~0.01; campo pequeno: r muito menor.",
            },
            new Formula
            {
                Id = "4_ci08", Nome = "Relação de Consistência", Categoria = "Cosmologia Inflacionária", SubCategoria = "Inflação",
                Expressao = "nₜ = -r/8  (previsão de single-field slow-roll)",
                ExprTexto = "nₜ = −r/8",
                Icone = "nₜ",
                Descricao = "Inclinação do espectro tensorial ligada a r. Previsão robusta de inflação de campo único. Violação indicaria multi-campo ou física exótica.",
            },
            // 8.2 Além do Modelo Padrão
            new Formula
            {
                Id = "4_bs01", Nome = "Densidade Relíquia de WIMP", Categoria = "Cosmologia Inflacionária", SubCategoria = "Além do Modelo Padrão",
                Expressao = "Ωh² ≈ 3×10⁻²⁷ cm³s⁻¹/⟨σv⟩",
                ExprTexto = "Ωh² ≈ 3×10⁻²⁷/⟨σv⟩",
                Icone = "Ω_DM",
                Descricao = "WIMP miracle: partícula com σ~escala fraca dá Ω~0.1 (observado!). Freeze-out quando taxa de aniquilação < expansão. ⟨σv⟩ ≈ 3×10⁻²⁶ cm³/s para Ωh²≈0.12.",
            },
            new Formula
            {
                Id = "4_bs02", Nome = "Massa de Axion", Categoria = "Cosmologia Inflacionária", SubCategoria = "Além do Modelo Padrão",
                Expressao = "mₐ ≈ 6 μeV (10¹²GeV/fₐ)",
                ExprTexto = "mₐ ≈ 6μeV·(10¹²GeV/fₐ)",
                Icone = "axion",
                Descricao = "Pseudo-bóson de Goldstone associado à simetria PQ. Resolve o problema CP forte. Candidato a matéria escura. fₐ = escala de quebra PQ (10⁹-10¹² GeV).",
                Criador = "Roberto Peccei / Helen Quinn / Steven Weinberg / Frank Wilczek",
                AnoOrigin = "1977/1978",
            },
            new Formula
            {
                Id = "4_bs03", Nome = "Equação de Estado da Energia Escura", Categoria = "Cosmologia Inflacionária", SubCategoria = "Além do Modelo Padrão",
                Expressao = "p = wρ;  w = -1 (Λ cosmológica)",
                ExprTexto = "p=wρ; w=−1 (Λ); w(a)=w₀+wₐ(1−a)",
                Icone = "w",
                Descricao = "w=-1: constante cosmológica (energia do vácuo). w≠-1: quintessência ou energia escura dinâmica. Parametrização CPL: w(a)=w₀+wₐ(1-a). Planck: w₀≈-1.03±0.03.",
            },
            new Formula
            {
                Id = "4_bs04", Nome = "Mecanismo de Seesaw", Categoria = "Cosmologia Inflacionária", SubCategoria = "Além do Modelo Padrão",
                Expressao = "mν ≈ m_D²/M_R;  (M_R ≫ m_D)",
                ExprTexto = "mν ≈ m_D²/M_R (seesaw tipo I)",
                Icone = "seesaw",
                Descricao = "Explica pequenez das massas de neutrinos: mν ~ (v_EW)²/M_R. Se M_R~10¹⁴ GeV → mν~0.01 eV (observado). Requer neutrino de Majorana pesado.",
                Criador = "Peter Minkowski / Tsutomu Yanagida / Murray Gell-Mann / Rabindra Mohapatra / Goran Senjanović",
            },
            new Formula
            {
                Id = "4_bs05", Nome = "Unificação SU(5) (Georgi-Glashow)", Categoria = "Cosmologia Inflacionária", SubCategoria = "Além do Modelo Padrão",
                Expressao = "SU(5) ⊃ SU(3)×SU(2)×U(1); quarks e léptons na mesma rep.",
                ExprTexto = "SU(5) → SU(3)×SU(2)×U(1)",
                Icone = "SU5",
                Descricao = "GUT mais simples: unifica QCD+eletrofraca em SU(5). Representações 5̄+10 contêm quarks e léptons. Prevê decaimento do próton (τ~10³⁴ anos). Mínimo descartado mas extensões viáveis.",
                Criador = "Howard Georgi / Sheldon Glashow",
                AnoOrigin = "1974",
            },
            new Formula
            {
                Id = "4_bs06", Nome = "Decaimento do Próton (GUT)", Categoria = "Cosmologia Inflacionária", SubCategoria = "Além do Modelo Padrão",
                Expressao = "τ_p ~ M_GUT⁴/(m_p⁵ α²);  τ_p > 10³⁴ anos (exp.)",
                ExprTexto = "τₚ ~ M_GUT⁴/mₚ⁵α²; τₚ>10³⁴ anos",
                Icone = "p→",
                Descricao = "GUTs preveem que p→e⁺π⁰ (violação de número bariônico). Limite experimental (Super-Kamiokande): τ>10³⁴ anos. Exclui GUT SU(5) mínimo mas permite extensões SUSY.",
            },
            new Formula
            {
                Id = "4_bs07", Nome = "Bariogênese (Condições de Sakharov)", Categoria = "Cosmologia Inflacionária", SubCategoria = "Além do Modelo Padrão",
                Expressao = "1) Violação B; 2) Violação C e CP; 3) Fora do equilíbrio",
                ExprTexto = "Sakharov: ΔB≠0, C/CP violados, fora equil.",
                Icone = "B",
                Descricao = "Três condições necessárias para gerar a assimetria matéria-antimatéria observada (η~6×10⁻¹⁰). SM satisfaz 1-2 mas 3 é marginal. BSM necessário.",
                Criador = "Andrei Sakharov",
                AnoOrigin = "1967",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 9. GRAVIDADE QUÂNTICA EM LOOP E CORDAS
    // ─────────────────────────────────────────────────────
    private void AdicionarGravidadeQuanticaCordas()
    {
        _formulas.AddRange([
            // 9.1 Gravidade Quântica em Loop (LQG)
            new Formula
            {
                Id = "4_lq01", Nome = "Variáveis de Ashtekar", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "Aᵢₐ = Γᵢₐ + γKᵢₐ;  Ẽᵃᵢ = √det(q)eᵃᵢ",
                ExprTexto = "A=Γ+γK; Ẽ=√q·e",
                Icone = "A,Ẽ",
                Descricao = "Reformulação da RG como teoria de gauge SU(2): conexão A (posição) e tríade densitizada Ẽ (momento). γ = parâmetro de Barbero-Immirzi. Base da LQG.",
                Criador = "Abhay Ashtekar",
                AnoOrigin = "1986",
            },
            new Formula
            {
                Id = "4_lq02", Nome = "Holonomia (LQG)", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "hₑ(A) = P exp(∫ₑ A);  elemento de SU(2)",
                ExprTexto = "hₑ = 𝒫exp(∫ₑA) ∈ SU(2)",
                Icone = "hₑ",
                Descricao = "Transporte paralelo ao longo de aresta e: variável quântica fundamental em LQG (substituindo A(x)). Espaço de Hilbert construído sobre grafos/spin networks.",
            },
            new Formula
            {
                Id = "4_lq03", Nome = "Spin Network", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "|Γ,jₑ,iᵥ⟩: grafo + spins nas arestas + intertwiners nos vértices",
                ExprTexto = "|Γ,jₑ,iᵥ⟩",
                Icone = "spin",
                Descricao = "Base do espaço de Hilbert cinemático da LQG. Grafo Γ com representações jₑ∈½ℕ nas arestas e intertwiners iᵥ nos vértices. 'Átomos de espaço'.",
                Criador = "Roger Penrose (conceito) / Carlo Rovelli / Lee Smolin (LQG)",
                AnoOrigin = "1971/1995",
            },
            new Formula
            {
                Id = "4_lq04", Nome = "Espectro de Área (LQG)", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "A = 8πγl²_P Σₑ √(jₑ(jₑ+1))",
                ExprTexto = "A = 8πγl²ₚ Σ√(j(j+1))",
                Icone = "Â",
                Descricao = "Área é quantizada! Espectro discreto: menor área não-nula = 4√3 πγl²_P (j=½). l_P = comprimento de Planck ≈ 10⁻³⁵m. Previsão central da LQG.",
            },
            new Formula
            {
                Id = "4_lq05", Nome = "Espectro de Volume (LQG)", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "V = l³_P Σᵥ √|q̂ᵥ|;  espectro discreto",
                ExprTexto = "V̂ = l³ₚ Σᵥ√|q̂ᵥ|",
                Icone = "V̂",
                Descricao = "Volume também é quantizado com espectro discreto. Volume reside nos vértices do spin network (arestas = área, vértices = volume). Espaço é granular na escala de Planck.",
            },
            new Formula
            {
                Id = "4_lq06", Nome = "Vínculo Hamiltoniano", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "Ĥ|ψ⟩ = 0  (equação de Wheeler-DeWitt)",
                ExprTexto = "Ĥ|ψ⟩ = 0",
                Icone = "Ĥ",
                Descricao = "Versão quântica: sem evolução temporal (problema do tempo). Dinâmica codificada nos vínculos. Implementação por Thiemann usando holonomias.",
            },
            new Formula
            {
                Id = "4_lq07", Nome = "Entropia de BN em LQG", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "S = A/(4l²_P) → fixa γ = 0.2375...",
                ExprTexto = "S_BH = A/4l²ₚ → γ≈0.2375",
                Icone = "S_LQG",
                Descricao = "Contagem de micro-estados de spin networks perfurando o horizonte reproduz Bekenstein-Hawking S=A/4G se γ≈0.2375 (fixa parâmetro de Barbero-Immirzi).",
            },
            new Formula
            {
                Id = "4_lq08", Nome = "Loop Quantum Cosmology (LQC)", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "H² = (8πG/3)ρ(1 - ρ/ρ_c);  ρ_c ~ ρ_Planck",
                ExprTexto = "H²=8πGρ(1−ρ/ρc)/3; ρc~ρPlanck",
                Icone = "LQC",
                Descricao = "Equação de Friedmann modificada: quando ρ→ρ_c, H=0 e o universo 'quica' (Big Bounce ao invés de singularidade). Resolve singularidade do Big Bang.",
            },
            new Formula
            {
                Id = "4_lq09", Nome = "Spin Foam", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "LQG",
                Expressao = "Z = Σ_{espumas} ∏_f A_f ∏_e A_e ∏_v A_v",
                ExprTexto = "Z = Σ ∏A_f·∏A_e·∏A_v",
                Icone = "foam",
                Descricao = "Integral de caminho para LQG: soma sobre histórias de spin networks (2-complexos). Faces=representações, arestas=intertwiners. Modelo EPRL é o mais estudado.",
            },
            // 9.2 Teoria de Cordas
            new Formula
            {
                Id = "4_st01", Nome = "Ação de Nambu-Goto", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "S = -T ∫ dA = -(1/2πα') ∫ d²σ √(-det hₐᵦ)",
                ExprTexto = "S = −T∫dA = −(2πα')⁻¹∫√(−det h)d²σ",
                Icone = "NG",
                Descricao = "Ação proporcional à área da worldsheet (folha-mundo). T = 1/(2πα') = tensão da corda. Generaliza ação de partícula pontual (comprimento da worldline).",
                Criador = "Yoichiro Nambu / Tetsuo Goto",
                AnoOrigin = "1970",
            },
            new Formula
            {
                Id = "4_st02", Nome = "Ação de Polyakov", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "S = -(T/2)∫ d²σ √(-γ) γᵃᵇ∂ₐXᵘ∂ᵦXᵘ",
                ExprTexto = "S = −(T/2)∫d²σ√(−γ)γᵃᵇ∂ₐXᵘ∂ᵦXᵘ",
                Icone = "Poly",
                Descricao = "Formulação com métrica auxiliar γ na worldsheet (mais fácil de quantizar). Classicamente equivalente a Nambu-Goto. Simetria conforme na worldsheet → dimensão crítica.",
                Criador = "Alexander Polyakov / Lars Brink / Paolo Di Vecchia / Paul Howe",
                AnoOrigin = "1981",
            },
            new Formula
            {
                Id = "4_st03", Nome = "Dimensão Crítica", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "d = 26 (bosônica); d = 10 (supercordas)",
                ExprTexto = "d=26 (bosônica); d=10 (super)",
                Icone = "d=10",
                Descricao = "Anomalia conforme cancela apenas em d=26 (bosônica) ou d=10 (supersimétrica). 6 dimensões extras devem ser compactificadas (Calabi-Yau, etc.).",
            },
            new Formula
            {
                Id = "4_st04", Nome = "Espectro de Massa (Corda Aberta)", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "M² = (N-1)/α'  (N = nível de excitação)",
                ExprTexto = "M² = (N−1)/α'",
                Icone = "M²",
                Descricao = "N=0: tachyon (instabilidade, ausente em supercordas). N=1: massless (fóton, graviton). N>1: torre de Regge de estados massivos. α' = (comprimento da corda)².",
            },
            new Formula
            {
                Id = "4_st05", Nome = "Álgebra de Virasoro", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "[Lₘ,Lₙ] = (m-n)Lₘ₊ₙ + (c/12)(m³-m)δₘ₊ₙ,₀",
                ExprTexto = "[Lₘ,Lₙ]=(m−n)Lₘ₊ₙ+(c/12)(m³−m)δₘ₊ₙ",
                Icone = "Vir",
                Descricao = "Álgebra de Lie dos geradores conformes na worldsheet. Carga central c determina anomalia conforme. c=d para d bósons livres. Requer d=26 para consistência.",
            },
            new Formula
            {
                Id = "4_st06", Nome = "T-Dualidade", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "R ↔ α'/R;  (compactificação em círculo)",
                ExprTexto = "R ↔ α'/R",
                Icone = "T",
                Descricao = "Cordas em círculo de raio R são equivalentes a raio α'/R. Troca modos de momento ↔ winding. Implica distância mínima ~√α'. Não existe em partículas pontuais.",
            },
            new Formula
            {
                Id = "4_st07", Nome = "S-Dualidade", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "g_s ↔ 1/g_s  (acoplamento forte ↔ fraco)",
                ExprTexto = "gₛ ↔ 1/gₛ",
                Icone = "S",
                Descricao = "Dualidade forte-fraco: física em acoplamento forte de uma teoria = acoplamento fraco de outra. Conecta tipo I ↔ SO(32) heterótica, tipo IIB consigo mesma.",
            },
            new Formula
            {
                Id = "4_st08", Nome = "D-Branas", Categoria = "Gravidade Quântica e Cordas", SubCategoria = "Cordas",
                Expressao = "Dp-brana: objeto (p+1)-dim; cordas abertas terminam nela",
                ExprTexto = "Dp-brana: dim p+1; condição Dirichlet",
                Icone = "Dp",
                Descricao = "Objetos extendidos onde cordas abertas podem terminar (condição de bordo de Dirichlet). Carregam carga de Ramond-Ramond. Fundamentais para holografia e compactificação.",
                Criador = "Joseph Polchinski",
                AnoOrigin = "1995",
            },
        ]);
    }
}
