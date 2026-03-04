using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 5 — PARTE II: FÍSICA (Seções 6-8)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 6. MECÂNICA CELESTE AVANÇADA E TEOREMA KAM
    // ─────────────────────────────────────────────────────
    private void AdicionarMecanicaCeleste()
    {
        _formulas.AddRange([
            // 6.1 Perturbações e Problema dos 3 Corpos
            new Formula
            {
                Id = "5_mc01", Nome = "Hamiltoniano Perturbado", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "H = H₀(I) + εH₁(I,θ,t)",
                ExprTexto = "H = H₀(I) + εH₁(I,θ,t)",
                Icone = "H",
                Descricao = "Hamiltoniano decomposto em parte integrável H₀ (depende só das ações I) mais perturbação εH₁. Base da teoria perturbativa em mecânica celeste.",
            },
            new Formula
            {
                Id = "5_mc02", Nome = "Perturbação de 1ª Ordem", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "dIⱼ/dt = -ε∂H₁/∂θⱼ;  dθⱼ/dt = ∂H₀/∂Iⱼ",
                ExprTexto = "dI/dt=-ε∂H₁/∂θ; dθ/dt=∂H₀/∂I",
                Icone = "ε",
                Descricao = "Equações de 1ª ordem: as ações variam lentamente (~ε) enquanto os ângulos rodam com frequências ω=∂H₀/∂I. Média secular elimina oscilações rápidas.",
            },
            new Formula
            {
                Id = "5_mc03", Nome = "Problema de Denominadores Pequenos", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "Divergência quando ω·k ≈ 0;  k ∈ ℤⁿ\\{0}",
                ExprTexto = "Diverge se ω·k≈0, k∈ℤⁿ",
                Icone = "0",
                Descricao = "Denominadores pequenos: séries perturbativas divergem nas ressonâncias ω·k≈0. Problema central desde Poincaré. Resolvido pelo teorema KAM.",
            },
            new Formula
            {
                Id = "5_mc04", Nome = "Condição Diofantina", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "|ω·k| ≥ γ/|k|^τ  ∀k ≠ 0",
                ExprTexto = "|ω·k| ≥ γ/|k|^τ",
                Icone = "γ",
                Descricao = "Condição diofantina: frequências suficientemente irracionais evitam ressonâncias. Conjunto de medida plena satisfaz esta condição para τ>n-1.",
            },
            new Formula
            {
                Id = "5_mc05", Nome = "Teorema KAM", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "H₀ não-degenerado, ε pequeno → maioria dos toros invariantes sobrevive",
                ExprTexto = "KAM: toros diofantinos persistem se ε≪1",
                Icone = "KAM",
                Descricao = "Teorema de Kolmogorov-Arnold-Moser: sob perturbação pequena, toros com frequências diofantinas sobrevivem. Estabilidade quase-global do sistema solar.",
                Criador = "Kolmogorov / Arnold / Moser",
                AnoOrigin = "1954",
            },
            new Formula
            {
                Id = "5_mc06", Nome = "Problema dos 3 Corpos", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "H = Σᵢ pᵢ²/2mᵢ - G·Σ_{i<j} mᵢmⱼ/|rᵢ-rⱼ|",
                ExprTexto = "H = ΣT - GΣmᵢmⱼ/rᵢⱼ",
                Icone = "3B",
                Descricao = "Hamiltoniano do problema de 3 corpos gravitacional. Não-integrável em geral (Poincaré). Caótico, mas com soluções periódicas especiais.",
                Criador = "Henri Poincaré",
                AnoOrigin = "1890",
            },
            new Formula
            {
                Id = "5_mc07", Nome = "Série de Sundman", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "Série convergente para 3 corpos, mas impraticável",
                ExprTexto = "Sundman: solução analítica convergente (10^(8·10⁶) termos)",
                Icone = "∞",
                Descricao = "Karl Sundman mostrou que o problema de 3 corpos admite solução em série convergente (1912). Contudo, convergência tão lenta que é impraticável.",
                Criador = "Karl F. Sundman",
                AnoOrigin = "1912",
            },
            new Formula
            {
                Id = "5_mc08", Nome = "Ressonâncias de Kirkwood", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "Lacunas em a ≈ 2.5, 2.82, 2.95 AU  (ressonâncias 4:1, 3:1, 2:1)",
                ExprTexto = "Kirkwood gaps: 4:1(2.06), 3:1(2.5), 5:2(2.82), 2:1(3.28) AU",
                Icone = "⊘",
                Descricao = "Lacunas de Kirkwood no cinturão de asteroides: regiões com poucos asteroides devido a ressonâncias orbitais com Júpiter.",
                Criador = "Daniel Kirkwood",
                AnoOrigin = "1866",
            },

            // 6.2 Leis de Kepler Generalizadas e Mecânica Orbital
            new Formula
            {
                Id = "5_mc09", Nome = "Equação de Órbita", Categoria = "Mecânica Celeste", SubCategoria = "Mecânica Orbital",
                Expressao = "r = p/(1 + e·cosν);  p = a(1-e²)",
                ExprTexto = "r = a(1-e²)/(1+e·cosν)",
                Icone = "r",
                Descricao = "Equação da órbita cônica. ν=anomalia verdadeira, e=excentricidade, a=semi-eixo maior, p=semi-latus rectum. Elipse (e<1), parábola (e=1), hipérbole (e>1).",
                Criador = "Johannes Kepler",
            },
            new Formula
            {
                Id = "5_mc10", Nome = "Velocidade de Escape", Categoria = "Mecânica Celeste", SubCategoria = "Mecânica Orbital",
                Expressao = "v_e = √(2μ/r);  μ = GM",
                ExprTexto = "v_e = √(2GM/r)",
                Icone = "v_e",
                Descricao = "Velocidade mínima para escapar de campo gravitacional a partir de distância r. Independe da direção do lançamento.",
            },
            new Formula
            {
                Id = "5_mc11", Nome = "Transferência de Hohmann", Categoria = "Mecânica Celeste", SubCategoria = "Mecânica Orbital",
                Expressao = "Δv₁ = √(μ/r₁)·(√(2r₂/(r₁+r₂)) - 1)",
                ExprTexto = "Δv₁ = √(μ/r₁)(√(2r₂/(r₁+r₂))-1)",
                Icone = "Δv",
                Descricao = "Transferência de Hohmann: manobra orbital mais eficiente entre duas órbitas circulares coplanares. Usa elipse tangente a ambas as órbitas.",
                Criador = "Walter Hohmann",
                AnoOrigin = "1925",
            },
            new Formula
            {
                Id = "5_mc12", Nome = "Equação de Gauss (Perturbações)", Categoria = "Mecânica Celeste", SubCategoria = "Mecânica Orbital",
                Expressao = "da/dt, de/dt, di/dt, ... = f(a,e,i,...,F_R,F_S,F_W)",
                ExprTexto = "Variação de elementos orbitais por forças perturbativas",
                Icone = "G",
                Descricao = "Equações de variação dos elementos orbitais de Gauss: descrevem como a,e,i,Ω,ω,M mudam sob forças perturbativas (drag, J₂, 3º corpo).",
            },
            new Formula
            {
                Id = "5_mc13", Nome = "Pontos de Lagrange", Categoria = "Mecânica Celeste", SubCategoria = "Mecânica Orbital",
                Expressao = "L₁-L₅;  L₄,L₅ estáveis se m₁/m₂ > 24.96",
                ExprTexto = "L₁-L₅; L₄,L₅ estáveis se m₁/m₂>24.96",
                Icone = "L",
                Descricao = "Pontos de Lagrange: 5 pontos de equilíbrio no problema restrito de 3 corpos. L₁,L₂,L₃ instáveis (colineares); L₄,L₅ estáveis (triângulos equiláteros).",
                Criador = "Joseph-Louis Lagrange",
                AnoOrigin = "1772",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 7. MAGNETISMO, POLÍMEROS E MATÉRIA MOLE
    // ─────────────────────────────────────────────────────
    private void AdicionarMagnetismoMateriaMole()
    {
        _formulas.AddRange([
            // 7.1 Magnetismo
            new Formula
            {
                Id = "5_mg01", Nome = "Ferromagnetismo de Weiss", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "M = Nμ_B J B_J(x);  x = gJμBJB/(kBT)",
                ExprTexto = "M = NμB·J·BJ(gJμBJB/kBT)",
                Icone = "M",
                Descricao = "Modelo de campo médio de Weiss: magnetização dada pela função de Brillouin BJ com campo efetivo incluindo interação de troca λM.",
                Criador = "Pierre-Ernest Weiss",
                AnoOrigin = "1907",
            },
            new Formula
            {
                Id = "5_mg02", Nome = "Campo Médio Magnético", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "H_eff = H + λM;  Tc = λNμ²/(3kB)",
                ExprTexto = "Heff=H+λM; Tc=λNμ²/3kB",
                Icone = "Tc",
                Descricao = "Teoria de campo médio: campo efetivo = externo + proporcional à magnetização. Tc = temperatura de Curie (transição ferro → para).",
            },
            new Formula
            {
                Id = "5_mg03", Nome = "Susceptibilidade de Curie-Weiss", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "χ = C/(T - Tc);  C = Nμ²/(3kB)",
                ExprTexto = "χ = C/(T-Tc)",
                Icone = "χ",
                Descricao = "Lei de Curie-Weiss: susceptibilidade diverge em Tc (transição de fase). Acima de Tc: paramagneto. Abaixo: ferromagneto ordenado.",
            },
            new Formula
            {
                Id = "5_mg04", Nome = "Modelo de Heisenberg", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "H = -J Σ_{⟨ij⟩} Sᵢ·Sⱼ - gμB Σ Sᵢ·B",
                ExprTexto = "H = -JΣ Sᵢ·Sⱼ - gμBΣSᵢ·B",
                Icone = "H",
                Descricao = "Modelo de Heisenberg: interação de troca isotrópica entre spins vizinhos. J>0 ferromagnético, J<0 antiferromagnético.",
                Criador = "Werner Heisenberg",
                AnoOrigin = "1928",
            },
            new Formula
            {
                Id = "5_mg05", Nome = "Relação de Dispersão de Magnons", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "E_k = 2JS(1 - cos(k·a))",
                ExprTexto = "Ek = 2JS(1-cos ka)",
                Icone = "ω",
                Descricao = "Magnons: quasepartículas de excitação de spin em magnetos ordenados. Gap se anisotropia presente. Dispersão quadrática em k→0 para FM.",
            },
            new Formula
            {
                Id = "5_mg06", Nome = "Expoente Magnético β", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "M(T) ~ (Tc - T)^β;  β ≈ 0.326 (3D Heisenberg)",
                ExprTexto = "M ~ (Tc-T)^β; β≈0.326",
                Icone = "β",
                Descricao = "Expoente crítico da magnetização: M vai a zero como lei de potência perto de Tc. β depende da universalidade (Ising≈0.326, MF=0.5).",
            },
            new Formula
            {
                Id = "5_mg07", Nome = "Critério de Stoner", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "Jρ(E_F) > 1  (ferromagnetismo itinerante)",
                ExprTexto = "Jρ(EF) > 1 → ferromagneto",
                Icone = "S",
                Descricao = "Critério de Stoner: ferromagnetismo de banda (itinerante). Ocorre quando interação de troca J vezes densidade de estados ρ(EF) excede 1.",
                Criador = "Edmund Stoner",
                AnoOrigin = "1938",
            },
            new Formula
            {
                Id = "5_mg08", Nome = "Efeito Josephson DC", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "I = Ic · sin(φ)",
                ExprTexto = "I = Ic·sinφ",
                Icone = "Ic",
                Descricao = "Efeito Josephson DC: supercorrente flui entre dois supercondutores separados por barreira fina. I depende da diferença de fase φ.",
                Criador = "Brian Josephson",
                AnoOrigin = "1962",
            },
            new Formula
            {
                Id = "5_mg09", Nome = "Efeito Josephson AC", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "V = ℏφ̇/2e;  f_J = 2eV/h ≈ 484 MHz/μV",
                ExprTexto = "V=ℏdφ/dt/2e; fJ≈484 MHz/μV",
                Icone = "AC",
                Descricao = "Efeito Josephson AC: tensão DC gera corrente oscilante. Frequência 2eV/h extremamente precisa. Base do padrão de tensão Josephson.",
            },
            new Formula
            {
                Id = "5_mg10", Nome = "SQUID", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "Ic(Φ) = 2Ic₀|cos(πΦ/Φ₀)|;  sensíssimo a Φ",
                ExprTexto = "Ic(Φ)=2Ic₀|cos(πΦ/Φ₀)|",
                Icone = "SQ",
                Descricao = "SQUID: dispositivo supercondutor com 2 junções Josephson. Mede campos magnéticos com resolução ~fT. Modulação da corrente crítica com fluxo Φ.",
            },

            // 7.2 Polímeros e Matéria Mole
            new Formula
            {
                Id = "5_pm01", Nome = "Raio de Giro (Cadeia Gaussiana)", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "⟨R²⟩ = Nb²/6",
                ExprTexto = "⟨R²⟩ = Nb²/6",
                Icone = "Rg",
                Descricao = "Raio de giro de cadeia ideal gaussiana: N elos de comprimento b. R²_giro = R²_end-to-end / 6. Cadeia ideal = random walk.",
            },
            new Formula
            {
                Id = "5_pm02", Nome = "Expoente de Flory", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "⟨R²⟩^{1/2} ~ N^ν;  ν = 3/(d+2) bom solvente;  ν = 1/2 theta",
                ExprTexto = "R ~ N^ν; ν=3/(d+2) bom; ν=0.5 theta",
                Icone = "ν",
                Descricao = "Expoente de Flory: dimensão fractal do polímero depende do solvente. Bom solvente (ν≈0.588 em 3D): cadeia inchada. Theta: cadeia ideal.",
                Criador = "Paul Flory",
                AnoOrigin = "1953",
            },
            new Formula
            {
                Id = "5_pm03", Nome = "Modelo de Rouse", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "τ_p = ξb²N²/(3π²kBT·p²);  p = modo normal",
                ExprTexto = "τp = ξb²N²/(3π²kBTp²)",
                Icone = "τ",
                Descricao = "Modelo de Rouse: dinâmica de polímero sem emaranhamentos. Modos normais com tempos de relaxação τ_p ~ N²/p². Difusão D ~ 1/N.",
                Criador = "Prince E. Rouse",
                AnoOrigin = "1953",
            },
            new Formula
            {
                Id = "5_pm04", Nome = "Reptação (de Gennes)", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "D ~ N⁻²;  τ_rep ~ N³",
                ExprTexto = "D~N⁻²; τrep~N³",
                Icone = "🐍",
                Descricao = "Reptação: polímero longo move-se como cobra em tubo formado por emaranhamentos. Difusão D~N⁻² e tempo τ~N³ (experimentalmente ~N^3.4).",
                Criador = "Pierre-Gilles de Gennes",
                AnoOrigin = "1971",
            },
            new Formula
            {
                Id = "5_pm05", Nome = "Elástica de Frank", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "F = ½∫[K₁(∇·n)² + K₂(n·∇×n)² + K₃(n×∇×n)²] dV",
                ExprTexto = "F = ½∫(K₁(∇·n)²+K₂(n·∇×n)²+K₃|n×∇×n|²)dV",
                Icone = "K",
                Descricao = "Energia livre elástica de Frank-Oseen para cristais líquidos: K₁ (splay), K₂ (twist), K₃ (bend). n = diretor (campo de orientação).",
                Criador = "Frederick Charles Frank",
                AnoOrigin = "1958",
            },
            new Formula
            {
                Id = "5_pm06", Nome = "Fases Líquido-Cristalinas", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "nemático → esmético → colestérico",
                ExprTexto = "nemático→esmético→colestérico",
                Icone = "LC",
                Descricao = "Fases de cristais líquidos: nemático (ordem orientacional), esmético (camadas), colestérico (hélice). Transições com temperatura/concentração.",
            },
            new Formula
            {
                Id = "5_pm07", Nome = "Transição Isótropo-Nemático (Onsager)", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "v_excl = πL²D/4  (volume excluído; transição por concentração)",
                ExprTexto = "vexcl = πL²D/4",
                Icone = "IN",
                Descricao = "Teoria de Onsager: bastões longos (L≫D) sofrem transição isótropo-nemático por volume excluído. Concentração crítica ~ D/L.",
                Criador = "Lars Onsager",
                AnoOrigin = "1949",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 8. CRISTALOGRAFIA E DIFRAÇÃO
    // ─────────────────────────────────────────────────────
    private void AdicionarCristalografia()
    {
        _formulas.AddRange([
            // 8.1 Simetria Cristalina
            new Formula
            {
                Id = "5_cr01", Nome = "Redes de Bravais", Categoria = "Cristalografia", SubCategoria = "Simetria Cristalina",
                Expressao = "14 tipos em 3D;  7 sistemas cristalinos",
                ExprTexto = "14 redes de Bravais, 7 sistemas",
                Icone = "B",
                Descricao = "Redes de Bravais: 14 tipos de redes translacionais em 3D agrupadas em 7 sistemas (cúbico, tetragonal, ortorrômbico, monoclínico, triclínico, hexagonal, romboédrico).",
                Criador = "Auguste Bravais",
                AnoOrigin = "1850",
            },
            new Formula
            {
                Id = "5_cr02", Nome = "Grupos Espaciais", Categoria = "Cristalografia", SubCategoria = "Simetria Cristalina",
                Expressao = "230 grupos espaciais em 3D;  translação + operações pontuais",
                ExprTexto = "230 grupos espaciais em 3D",
                Icone = "G",
                Descricao = "Grupos espaciais: simetria completa de cristais incluindo translações, rotações, reflexões, eixos helicoidais e planos deslizantes. 230 em 3D.",
            },
            new Formula
            {
                Id = "5_cr03", Nome = "Rede Recíproca", Categoria = "Cristalografia", SubCategoria = "Simetria Cristalina",
                Expressao = "b₁ = 2π(a₂×a₃)/(a₁·a₂×a₃);  idem b₂,b₃",
                ExprTexto = "bᵢ = 2π(aⱼ×aₖ)/(a₁·a₂×a₃)",
                Icone = "b",
                Descricao = "Vetores da rede recíproca: duais aos vetores primitivos da rede direta. aᵢ·bⱼ = 2πδᵢⱼ. Espaço de ondas e difração.",
            },
            new Formula
            {
                Id = "5_cr04", Nome = "Vetor de Rede Recíproca (Miller)", Categoria = "Cristalografia", SubCategoria = "Simetria Cristalina",
                Expressao = "G = h·b₁ + k·b₂ + l·b₃;  h,k,l = índices de Miller",
                ExprTexto = "G = hb₁+kb₂+lb₃",
                Icone = "G",
                Descricao = "Vetor de rede recíproca indexado por inteiros de Miller (hkl). Perpendicular ao plano cristalográfico (hkl). |G| = 2π/d_{hkl}.",
            },

            // 8.2 Difração
            new Formula
            {
                Id = "5_cr05", Nome = "Lei de Bragg", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "2d·sinθ = nλ",
                ExprTexto = "2d sinθ = nλ",
                Icone = "θ",
                Descricao = "Lei de Bragg: condição para reflexão construtiva de raios X por planos cristalinos. d=espaçamento interplanar, θ=ângulo de incidência, n=ordem.",
                Criador = "W.H. Bragg / W.L. Bragg",
                AnoOrigin = "1913",
            },
            new Formula
            {
                Id = "5_cr06", Nome = "Condição de Laue", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "Δk = G;  k_f - k_i = G",
                ExprTexto = "k_f - k_i = G (transferência=rede recíproca)",
                Icone = "Δk",
                Descricao = "Condição de Laue: difração ocorre quando a transferência de momento é um vetor da rede recíproca. Equivalente à lei de Bragg.",
                Criador = "Max von Laue",
                AnoOrigin = "1912",
            },
            new Formula
            {
                Id = "5_cr07", Nome = "Fator de Estrutura", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "F(hkl) = Σⱼ fⱼ·exp(2πi(hxⱼ+kyⱼ+lzⱼ))",
                ExprTexto = "F(hkl)=Σ fⱼ exp(2πi(hxⱼ+kyⱼ+lzⱼ))",
                Icone = "F",
                Descricao = "Fator de estrutura: amplitude de espalhamento de uma reflexão (hkl). fⱼ = fator de espalhamento atômico, (xⱼ,yⱼ,zⱼ) = posições na célula.",
            },
            new Formula
            {
                Id = "5_cr08", Nome = "Extinções Sistemáticas", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "F(hkl) = 0 para certas reflexões por simetria",
                ExprTexto = "F=0 em reflexões proibidas por simetria",
                Icone = "0",
                Descricao = "Extinções sistemáticas: certas reflexões têm F=0 devido a simetrias (centragem, eixos helicoidais, planos deslizantes). Revelam o grupo espacial.",
            },
            new Formula
            {
                Id = "5_cr09", Nome = "Intensidade de Difração", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "I(hkl) ∝ |F(hkl)|² · LP · A · ...",
                ExprTexto = "I ∝ |F|²·LP·A",
                Icone = "I",
                Descricao = "Intensidade observada: proporcional a |F|² vezes fatores de correção: Lorentz-polarização (LP), absorção (A), multiplicidade, etc.",
            },
            new Formula
            {
                Id = "5_cr10", Nome = "Fator de Debye-Waller", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "fⱼ → fⱼ·exp(-B·sin²θ/λ²)  (vibrações térmicas)",
                ExprTexto = "f→f·exp(-B sin²θ/λ²)",
                Icone = "B",
                Descricao = "Fator de Debye-Waller: atenuação da difração por vibrações térmicas dos átomos. B = 8π²⟨u²⟩ (deslocamento quadrático médio).",
                Criador = "Peter Debye / Ivar Waller",
            },
        ]);
    }
}
