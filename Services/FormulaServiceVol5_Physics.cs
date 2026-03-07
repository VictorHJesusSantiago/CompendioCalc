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
                ExemploPratico = "Exemplo: H0=10, ε=0.02 e H1=3 -> H = 10 + 0.02*3 = 10.06.",
                Variaveis = [ new() { Simbolo = "H0", Nome = "Parte integrável H0(I)", ValorPadrao = 10 }, new() { Simbolo = "eps", Nome = "Perturbação ε", ValorPadrao = 0.02, ValorMin = 0 }, new() { Simbolo = "H1", Nome = "Termo perturbativo H1(I,θ,t)", ValorPadrao = 3 } ],
                VariavelResultado = "H",
                UnidadeResultado = "",
                Calcular = v => v["H0"] + v["eps"] * v["H1"]
            },
            new Formula
            {
                Id = "5_mc02", Nome = "Perturbação de 1ª Ordem", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "dIⱼ/dt = -ε∂H₁/∂θⱼ;  dθⱼ/dt = ∂H₀/∂Iⱼ",
                ExprTexto = "dI/dt=-ε∂H₁/∂θ; dθ/dt=∂H₀/∂I",
                Icone = "ε",
                Descricao = "Equações de 1ª ordem: as ações variam lentamente (~ε) enquanto os ângulos rodam com frequências ω=∂H₀/∂I. Média secular elimina oscilações rápidas.",
                ExemploPratico = "Exemplo: ε=0.01 e ∂H1/∂θ=4 -> dI/dt = -0.04.",
                Variaveis = [ new() { Simbolo = "eps", Nome = "Perturbação ε", ValorPadrao = 0.01, ValorMin = 0 }, new() { Simbolo = "dH1dTheta", Nome = "Derivada ∂H1/∂θ", ValorPadrao = 4 } ],
                VariavelResultado = "dI/dt",
                UnidadeResultado = "",
                Calcular = v => -v["eps"] * v["dH1dTheta"]
            },
            new Formula
            {
                Id = "5_mc03", Nome = "Problema de Denominadores Pequenos", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "Divergência quando ω·k ≈ 0;  k ∈ ℤⁿ\\{0}",
                ExprTexto = "Diverge se ω·k≈0, k∈ℤⁿ",
                Icone = "0",
                Descricao = "Denominadores pequenos: séries perturbativas divergem nas ressonâncias ω·k≈0. Problema central desde Poincaré. Resolvido pelo teorema KAM.",
                ExemploPratico = "Exemplo: ω=(1.5,2.1) e k=(2,-1) -> |ω·k|=|3.0-2.1|=0.9.",
                Variaveis = [ new() { Simbolo = "omega1", Nome = "Componente ω1", ValorPadrao = 1.5 }, new() { Simbolo = "omega2", Nome = "Componente ω2", ValorPadrao = 2.1 }, new() { Simbolo = "k1", Nome = "Inteiro k1", ValorPadrao = 2 }, new() { Simbolo = "k2", Nome = "Inteiro k2", ValorPadrao = -1 } ],
                VariavelResultado = "|ω·k|",
                UnidadeResultado = "",
                Calcular = v => Math.Abs(v["omega1"] * v["k1"] + v["omega2"] * v["k2"])
            },
            new Formula
            {
                Id = "5_mc04", Nome = "Condição Diofantina", Categoria = "Mecânica Celeste", SubCategoria = "Perturbações e 3 Corpos",
                Expressao = "|ω·k| ≥ γ/|k|^τ  ∀k ≠ 0",
                ExprTexto = "|ω·k| ≥ γ/|k|^τ",
                Icone = "γ",
                Descricao = "Condição diofantina: frequências suficientemente irracionais evitam ressonâncias. Conjunto de medida plena satisfaz esta condição para τ>n-1.",
                ExemploPratico = "Exemplo: |ω·k|=0.30, γ=0.5, |k|=3 e τ=2 -> limite=0.5/9≈0.0556, margem≈0.2444.",
                Variaveis = [ new() { Simbolo = "omegaDotK", Nome = "|ω·k|", ValorPadrao = 0.30, ValorMin = 0 }, new() { Simbolo = "gamma", Nome = "γ", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "kNorm", Nome = "|k|", ValorPadrao = 3, ValorMin = 1 }, new() { Simbolo = "tau", Nome = "τ", ValorPadrao = 2, ValorMin = 0 } ],
                VariavelResultado = "Margem |ω·k| - γ/|k|^τ",
                UnidadeResultado = "",
                Calcular = v => v["omegaDotK"] - v["gamma"] / Math.Pow(v["kNorm"], v["tau"])
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
                ExemploPratico = "Exemplo: ε=0.005 e limiar ε_crit=0.02 -> margem positiva (0.015), indicando regime KAM preservado.",
                Variaveis = [ new() { Simbolo = "eps", Nome = "Perturbação ε", ValorPadrao = 0.005, ValorMin = 0 }, new() { Simbolo = "epsCrit", Nome = "Limiar ε_crit", ValorPadrao = 0.02, ValorMin = 0 } ],
                VariavelResultado = "Margem ε_crit-ε",
                UnidadeResultado = "",
                Calcular = v => v["epsCrit"] - v["eps"]
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
                ExemploPratico = "Exemplo simplificado: m=(1,2,3), v=(1.0,0.8,0.5), r12=2, r13=3, r23=2.5 e G=1 -> H=T-U.",
                Variaveis = [ new() { Simbolo = "G", Nome = "Constante gravitacional G (normalizada)", ValorPadrao = 1, ValorMin = 0 }, new() { Simbolo = "m1", Nome = "Massa m1", ValorPadrao = 1, ValorMin = 0.001 }, new() { Simbolo = "m2", Nome = "Massa m2", ValorPadrao = 2, ValorMin = 0.001 }, new() { Simbolo = "m3", Nome = "Massa m3", ValorPadrao = 3, ValorMin = 0.001 }, new() { Simbolo = "v1", Nome = "Velocidade v1", ValorPadrao = 1.0, ValorMin = 0 }, new() { Simbolo = "v2", Nome = "Velocidade v2", ValorPadrao = 0.8, ValorMin = 0 }, new() { Simbolo = "v3", Nome = "Velocidade v3", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "r12", Nome = "Distância r12", ValorPadrao = 2, ValorMin = 0.001 }, new() { Simbolo = "r13", Nome = "Distância r13", ValorPadrao = 3, ValorMin = 0.001 }, new() { Simbolo = "r23", Nome = "Distância r23", ValorPadrao = 2.5, ValorMin = 0.001 } ],
                VariavelResultado = "H = T-U",
                UnidadeResultado = "",
                Calcular = v => {
                    var t = 0.5 * v["m1"] * v["v1"] * v["v1"] + 0.5 * v["m2"] * v["v2"] * v["v2"] + 0.5 * v["m3"] * v["v3"] * v["v3"];
                    var u = v["G"] * (v["m1"] * v["m2"] / v["r12"] + v["m1"] * v["m3"] / v["r13"] + v["m2"] * v["m3"] / v["r23"]);
                    return t - u;
                }
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
                ExemploPratico = "Exemplo: 10^(8*10^6) termos -> log10(N)=8,000,000, evidenciando impraticabilidade numérica.",
                Variaveis = [ new() { Simbolo = "coef", Nome = "Coeficiente no expoente", ValorPadrao = 8, ValorMin = 1 }, new() { Simbolo = "escala", Nome = "Escala decimal", ValorPadrao = 1000000, ValorMin = 1 } ],
                VariavelResultado = "log10(N_termos)",
                UnidadeResultado = "",
                Calcular = v => v["coef"] * v["escala"]
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
                ExemploPratico = "Exemplo: com a_J=5.2 AU e a_ast=2.5 AU, a razão n_ast/n_J=(a_J/a_ast)^(3/2)≈3, próxima da ressonância 3:1.",
                Variaveis = [ new() { Simbolo = "aJ", Nome = "Semi-eixo de Júpiter (AU)", ValorPadrao = 5.2, ValorMin = 0.1 }, new() { Simbolo = "aAst", Nome = "Semi-eixo do asteroide (AU)", ValorPadrao = 2.5, ValorMin = 0.1 } ],
                VariavelResultado = "n_ast/n_J",
                UnidadeResultado = "",
                Calcular = v => Math.Pow(v["aJ"] / v["aAst"], 1.5)
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
                ExemploPratico = "Exemplo: a=1 AU, e=0.2 e ν=60° -> r=1*(1-0.04)/(1+0.2*cos60)=0.96/1.1≈0.873 AU.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Semi-eixo maior a", ValorPadrao = 1, ValorMin = 0.001 }, new() { Simbolo = "e", Nome = "Excentricidade e", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 0.999 }, new() { Simbolo = "nuDeg", Nome = "Anomalia verdadeira ν (graus)", ValorPadrao = 60 } ],
                VariavelResultado = "r",
                UnidadeResultado = "",
                Calcular = v => {
                    var nu = Math.PI * v["nuDeg"] / 180.0;
                    return v["a"] * (1 - v["e"] * v["e"]) / (1 + v["e"] * Math.Cos(nu));
                }
            },
            new Formula
            {
                Id = "5_mc10", Nome = "Velocidade de Escape", Categoria = "Mecânica Celeste", SubCategoria = "Mecânica Orbital",
                Expressao = "v_e = √(2μ/r);  μ = GM",
                ExprTexto = "v_e = √(2GM/r)",
                Icone = "v_e",
                Descricao = "Velocidade mínima para escapar de campo gravitacional a partir de distância r. Independe da direção do lançamento.",
                ExemploPratico = "Exemplo: μ=398600 km^3/s^2 e r=6378 km -> v_e=sqrt(2*398600/6378)≈11.2 km/s.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "Parâmetro gravitacional μ", ValorPadrao = 398600, ValorMin = 0.001 }, new() { Simbolo = "r", Nome = "Raio r", ValorPadrao = 6378, ValorMin = 0.001 } ],
                VariavelResultado = "v_e",
                UnidadeResultado = "",
                Calcular = v => Math.Sqrt(2 * v["mu"] / v["r"])
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
                ExemploPratico = "Exemplo: μ=398600, r1=7000 km e r2=42164 km -> calcula Δv1 de injeção na órbita de transferência.",
                Variaveis = [ new() { Simbolo = "mu", Nome = "Parâmetro gravitacional μ", ValorPadrao = 398600, ValorMin = 0.001 }, new() { Simbolo = "r1", Nome = "Raio órbita inicial r1", ValorPadrao = 7000, ValorMin = 0.001 }, new() { Simbolo = "r2", Nome = "Raio órbita final r2", ValorPadrao = 42164, ValorMin = 0.001 } ],
                VariavelResultado = "Δv1",
                UnidadeResultado = "",
                Calcular = v => Math.Sqrt(v["mu"] / v["r1"]) * (Math.Sqrt((2 * v["r2"]) / (v["r1"] + v["r2"])) - 1)
            },
            new Formula
            {
                Id = "5_mc12", Nome = "Equação de Gauss (Perturbações)", Categoria = "Mecânica Celeste", SubCategoria = "Mecânica Orbital",
                Expressao = "da/dt, de/dt, di/dt, ... = f(a,e,i,...,F_R,F_S,F_W)",
                ExprTexto = "Variação de elementos orbitais por forças perturbativas",
                Icone = "G",
                Descricao = "Equações de variação dos elementos orbitais de Gauss: descrevem como a,e,i,Ω,ω,M mudam sob forças perturbativas (drag, J₂, 3º corpo).",
                ExemploPratico = "Exemplo: FR=1e-6, FS=2e-6 e FW=0.5e-6 km/s^2 -> aceleração perturbativa total = sqrt(FR^2+FS^2+FW^2).",
                Variaveis = [ new() { Simbolo = "FR", Nome = "Componente radial FR", ValorPadrao = 1e-6 }, new() { Simbolo = "FS", Nome = "Componente transversal FS", ValorPadrao = 2e-6 }, new() { Simbolo = "FW", Nome = "Componente normal FW", ValorPadrao = 0.5e-6 } ],
                VariavelResultado = "|F_pert|",
                UnidadeResultado = "",
                Calcular = v => Math.Sqrt(v["FR"] * v["FR"] + v["FS"] * v["FS"] + v["FW"] * v["FW"])
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
                ExemploPratico = "Exemplo: para Sol-Júpiter, m1/m2~1047 e a estabilidade de L4/L5 é satisfeita com ampla margem.",
                Variaveis = [ new() { Simbolo = "m1", Nome = "Massa principal m1", ValorPadrao = 1047, ValorMin = 0.001 }, new() { Simbolo = "m2", Nome = "Massa secundária m2", ValorPadrao = 1, ValorMin = 0.001 } ],
                VariavelResultado = "Margem de estabilidade m1/m2-24.96",
                UnidadeResultado = "",
                Calcular = v => v["m1"] / v["m2"] - 24.96
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
                ExemploPratico = "Exemplo: NμB=2.0, J=0.5 e BJ=0.8 -> M = 2.0*0.5*0.8 = 0.8.",
                Variaveis = [ new() { Simbolo = "NmuB", Nome = "Fator NμB", ValorPadrao = 2.0, ValorMin = 0 }, new() { Simbolo = "J", Nome = "Momento total J", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "BJ", Nome = "Função de Brillouin BJ", ValorPadrao = 0.8 } ],
                VariavelResultado = "M",
                UnidadeResultado = "",
                Calcular = vars => vars["NmuB"] * vars["J"] * vars["BJ"]
            },
            new Formula
            {
                Id = "5_mg02", Nome = "Campo Médio Magnético", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "H_eff = H + λM;  Tc = λNμ²/(3kB)",
                ExprTexto = "Heff=H+λM; Tc=λNμ²/3kB",
                Icone = "Tc",
                Descricao = "Teoria de campo médio: campo efetivo = externo + proporcional à magnetização. Tc = temperatura de Curie (transição ferro → para).",
                ExemploPratico = "Exemplo: H=0.3 T, λ=1.2 e M=0.4 -> H_eff = 0.3 + 1.2*0.4 = 0.78 T.",
                Variaveis = [ new() { Simbolo = "H", Nome = "Campo externo H", ValorPadrao = 0.3 }, new() { Simbolo = "lambda", Nome = "Acoplamento λ", ValorPadrao = 1.2 }, new() { Simbolo = "M", Nome = "Magnetização M", ValorPadrao = 0.4 } ],
                VariavelResultado = "Heff",
                UnidadeResultado = "",
                Calcular = vars => vars["H"] + vars["lambda"] * vars["M"]
            },
            new Formula
            {
                Id = "5_mg03", Nome = "Susceptibilidade de Curie-Weiss", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "χ = C/(T - Tc);  C = Nμ²/(3kB)",
                ExprTexto = "χ = C/(T-Tc)",
                Icone = "χ",
                Descricao = "Lei de Curie-Weiss: susceptibilidade diverge em Tc (transição de fase). Acima de Tc: paramagneto. Abaixo: ferromagneto ordenado.",
                ExemploPratico = "Exemplo: C=1.5, T=320 K e Tc=300 K -> χ = 1.5/(20)=0.075.",
                Variaveis = [ new() { Simbolo = "C", Nome = "Constante de Curie C", ValorPadrao = 1.5, ValorMin = 0.001 }, new() { Simbolo = "T", Nome = "Temperatura T", ValorPadrao = 320 }, new() { Simbolo = "Tc", Nome = "Temperatura de Curie Tc", ValorPadrao = 300 } ],
                VariavelResultado = "χ",
                UnidadeResultado = "",
                Calcular = vars => vars["C"] / Math.Max(1e-9, vars["T"] - vars["Tc"])
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
                ExemploPratico = "Exemplo simplificado para 1 par de spins: J=1.1 e S1·S2=0.5 -> H_troca = -J(S1·S2)=-0.55.",
                Variaveis = [ new() { Simbolo = "J", Nome = "Constante de troca J", ValorPadrao = 1.1 }, new() { Simbolo = "Sdot", Nome = "Produto escalar S1·S2", ValorPadrao = 0.5 } ],
                VariavelResultado = "H_troca",
                UnidadeResultado = "",
                Calcular = vars => -vars["J"] * vars["Sdot"]
            },
            new Formula
            {
                Id = "5_mg05", Nome = "Relação de Dispersão de Magnons", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "E_k = 2JS(1 - cos(k·a))",
                ExprTexto = "Ek = 2JS(1-cos ka)",
                Icone = "ω",
                Descricao = "Magnons: quasepartículas de excitação de spin em magnetos ordenados. Gap se anisotropia presente. Dispersão quadrática em k→0 para FM.",
                ExemploPratico = "Exemplo: J=1.0, S=0.5 e ka=1.2 -> Ek=2*1*0.5*(1-cos(1.2))≈0.638.",
                Variaveis = [ new() { Simbolo = "J", Nome = "Acoplamento J", ValorPadrao = 1.0 }, new() { Simbolo = "S", Nome = "Spin S", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "ka", Nome = "Produto ka", ValorPadrao = 1.2 } ],
                VariavelResultado = "E_k",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["J"] * vars["S"] * (1 - Math.Cos(vars["ka"]))
            },
            new Formula
            {
                Id = "5_mg06", Nome = "Expoente Magnético β", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "M(T) ~ (Tc - T)^β;  β ≈ 0.326 (3D Heisenberg)",
                ExprTexto = "M ~ (Tc-T)^β; β≈0.326",
                Icone = "β",
                Descricao = "Expoente crítico da magnetização: M vai a zero como lei de potência perto de Tc. β depende da universalidade (Ising≈0.326, MF=0.5).",
                ExemploPratico = "Exemplo: Tc=300 K, T=295 K e β=0.326 -> M_rel=(5)^0.326≈1.689 (escala relativa).",
                Variaveis = [ new() { Simbolo = "Tc", Nome = "Temperatura crítica Tc", ValorPadrao = 300 }, new() { Simbolo = "T", Nome = "Temperatura T", ValorPadrao = 295 }, new() { Simbolo = "beta", Nome = "Expoente β", ValorPadrao = 0.326, ValorMin = 0.001 } ],
                VariavelResultado = "M_rel",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(Math.Max(0, vars["Tc"] - vars["T"]), vars["beta"])
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
                ExemploPratico = "Exemplo: J=0.9 e ρ(EF)=1.4 -> Jρ=1.26 (>1), favorece ferromagnetismo itinerante.",
                Variaveis = [ new() { Simbolo = "J", Nome = "Interação de troca J", ValorPadrao = 0.9 }, new() { Simbolo = "rhoEF", Nome = "Densidade de estados ρ(EF)", ValorPadrao = 1.4, ValorMin = 0 } ],
                VariavelResultado = "Jρ(EF)",
                UnidadeResultado = "",
                Calcular = vars => vars["J"] * vars["rhoEF"]
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
                ExemploPratico = "Exemplo: Ic=10 μA e φ=30° -> I = 10*sin(30°)=5 μA.",
                Variaveis = [ new() { Simbolo = "Ic", Nome = "Corrente crítica Ic", ValorPadrao = 10, ValorMin = 0 }, new() { Simbolo = "phiDeg", Nome = "Fase φ (graus)", ValorPadrao = 30 } ],
                VariavelResultado = "I",
                UnidadeResultado = "",
                Calcular = vars => vars["Ic"] * Math.Sin(Math.PI * vars["phiDeg"] / 180.0)
            },
            new Formula
            {
                Id = "5_mg09", Nome = "Efeito Josephson AC", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "V = ℏφ̇/2e;  f_J = 2eV/h ≈ 484 MHz/μV",
                ExprTexto = "V=ℏdφ/dt/2e; fJ≈484 MHz/μV",
                Icone = "AC",
                Descricao = "Efeito Josephson AC: tensão DC gera corrente oscilante. Frequência 2eV/h extremamente precisa. Base do padrão de tensão Josephson.",
                ExemploPratico = "Exemplo: V=5 μV -> fJ ≈ 484*5 = 2420 MHz.",
                Variaveis = [ new() { Simbolo = "V_uV", Nome = "Tensão V (μV)", ValorPadrao = 5, ValorMin = 0 } ],
                VariavelResultado = "fJ (MHz)",
                UnidadeResultado = "",
                Calcular = vars => 484.0 * vars["V_uV"]
            },
            new Formula
            {
                Id = "5_mg10", Nome = "SQUID", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Magnetismo",
                Expressao = "Ic(Φ) = 2Ic₀|cos(πΦ/Φ₀)|;  sensíssimo a Φ",
                ExprTexto = "Ic(Φ)=2Ic₀|cos(πΦ/Φ₀)|",
                Icone = "SQ",
                Descricao = "SQUID: dispositivo supercondutor com 2 junções Josephson. Mede campos magnéticos com resolução ~fT. Modulação da corrente crítica com fluxo Φ.",
                ExemploPratico = "Exemplo: Ic0=8 μA e Φ/Φ0=0.25 -> Ic=2*8*|cos(π/4)|≈11.31 μA.",
                Variaveis = [ new() { Simbolo = "Ic0", Nome = "Corrente crítica de cada junção Ic0", ValorPadrao = 8, ValorMin = 0 }, new() { Simbolo = "phiOverPhi0", Nome = "Razão Φ/Φ0", ValorPadrao = 0.25 } ],
                VariavelResultado = "Ic(Φ)",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["Ic0"] * Math.Abs(Math.Cos(Math.PI * vars["phiOverPhi0"]))
            },

            // 7.2 Polímeros e Matéria Mole
            new Formula
            {
                Id = "5_pm01", Nome = "Raio de Giro (Cadeia Gaussiana)", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "⟨R²⟩ = Nb²/6",
                ExprTexto = "⟨R²⟩ = Nb²/6",
                Icone = "Rg",
                Descricao = "Raio de giro de cadeia ideal gaussiana: N elos de comprimento b. R²_giro = R²_end-to-end / 6. Cadeia ideal = random walk.",
                ExemploPratico = "Exemplo: N=1000 e b=0.5 nm -> <R^2>=1000*0.25/6≈41.67 nm^2.",
                Variaveis = [ new() { Simbolo = "N", Nome = "Número de elos N", ValorPadrao = 1000, ValorMin = 1 }, new() { Simbolo = "b", Nome = "Comprimento do elo b", ValorPadrao = 0.5, ValorMin = 0.001 } ],
                VariavelResultado = "<R^2>",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["b"] * vars["b"] / 6.0
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
                ExemploPratico = "Exemplo: N=1000 e ν=0.588 -> R_rel ~ N^ν ≈ 57.54 (unidades relativas).",
                Variaveis = [ new() { Simbolo = "N", Nome = "Número de monômeros N", ValorPadrao = 1000, ValorMin = 1 }, new() { Simbolo = "nu", Nome = "Expoente de Flory ν", ValorPadrao = 0.588, ValorMin = 0.001 } ],
                VariavelResultado = "R_rel",
                UnidadeResultado = "",
                Calcular = vars => Math.Pow(vars["N"], vars["nu"])
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
                ExemploPratico = "Exemplo: ξ=1, b=0.5, N=200, T=300 e p=1 -> τp≈6.76 (escala reduzida com kB=1).",
                Variaveis = [ new() { Simbolo = "xi", Nome = "Coeficiente de atrito ξ", ValorPadrao = 1, ValorMin = 0.001 }, new() { Simbolo = "b", Nome = "Comprimento b", ValorPadrao = 0.5, ValorMin = 0.001 }, new() { Simbolo = "N", Nome = "Número de elos N", ValorPadrao = 200, ValorMin = 1 }, new() { Simbolo = "T", Nome = "Temperatura T", ValorPadrao = 300, ValorMin = 0.001 }, new() { Simbolo = "p", Nome = "Modo p", ValorPadrao = 1, ValorMin = 1 } ],
                VariavelResultado = "τ_p",
                UnidadeResultado = "",
                Calcular = vars => vars["xi"] * vars["b"] * vars["b"] * vars["N"] * vars["N"] / (3 * Math.PI * Math.PI * vars["T"] * vars["p"] * vars["p"])
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
                ExemploPratico = "Exemplo: D0=1e-9 m^2/s e N=100 -> D = 1e-9/100^2 = 1e-13 m^2/s.",
                Variaveis = [ new() { Simbolo = "D0", Nome = "Constante D0", ValorPadrao = 1e-9, ValorMin = 1e-15 }, new() { Simbolo = "N", Nome = "Grau de polimerização N", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "D",
                UnidadeResultado = "",
                Calcular = vars => vars["D0"] / (vars["N"] * vars["N"])
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
                ExemploPratico = "Exemplo: K1=10, K2=8, K3=12 pN, com splay=0.2, twist=0.15, bend=0.1 e V=1 -> F≈0.353 (u.a.).",
                Variaveis = [ new() { Simbolo = "K1", Nome = "Constante K1 (splay)", ValorPadrao = 10 }, new() { Simbolo = "K2", Nome = "Constante K2 (twist)", ValorPadrao = 8 }, new() { Simbolo = "K3", Nome = "Constante K3 (bend)", ValorPadrao = 12 }, new() { Simbolo = "splay", Nome = "(∇·n)", ValorPadrao = 0.2 }, new() { Simbolo = "twist", Nome = "(n·∇×n)", ValorPadrao = 0.15 }, new() { Simbolo = "bend", Nome = "|n×∇×n|", ValorPadrao = 0.1 }, new() { Simbolo = "V", Nome = "Volume efetivo", ValorPadrao = 1, ValorMin = 0.001 } ],
                VariavelResultado = "F",
                UnidadeResultado = "",
                Calcular = vars => 0.5 * vars["V"] * (vars["K1"] * vars["splay"] * vars["splay"] + vars["K2"] * vars["twist"] * vars["twist"] + vars["K3"] * vars["bend"] * vars["bend"])
            },
            new Formula
            {
                Id = "5_pm06", Nome = "Fases Líquido-Cristalinas", Categoria = "Magnetismo e Matéria Mole", SubCategoria = "Polímeros e Matéria Mole",
                Expressao = "nemático → esmético → colestérico",
                ExprTexto = "nemático→esmético→colestérico",
                Icone = "LC",
                Descricao = "Fases de cristais líquidos: nemático (ordem orientacional), esmético (camadas), colestérico (hélice). Transições com temperatura/concentração.",
                ExemploPratico = "Exemplo simplificado: índice de ordem orientacional S entre 0 e 1. S=0.65 indica fase orientada (nemática/esmética).",
                Variaveis = [ new() { Simbolo = "S", Nome = "Parâmetro de ordem orientacional S", ValorPadrao = 0.65, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "S",
                UnidadeResultado = "",
                Calcular = vars => vars["S"]
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
                ExemploPratico = "Exemplo: L=100 nm e D=2 nm -> v_excl = π*L^2*D/4 ≈ 15708 nm^3.",
                Variaveis = [ new() { Simbolo = "L", Nome = "Comprimento L do bastão", ValorPadrao = 100, ValorMin = 0.001 }, new() { Simbolo = "D", Nome = "Diâmetro D do bastão", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "v_excl",
                UnidadeResultado = "",
                Calcular = vars => Math.PI * vars["L"] * vars["L"] * vars["D"] / 4.0
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
                ExemploPratico = "Exemplo: 14 redes distribuídas em 7 sistemas -> média de 2 redes por sistema (indicador pedagógico).",
                Variaveis = [ new() { Simbolo = "nRedes", Nome = "Número de redes de Bravais", ValorPadrao = 14, ValorMin = 1 }, new() { Simbolo = "nSistemas", Nome = "Número de sistemas cristalinos", ValorPadrao = 7, ValorMin = 1 } ],
                VariavelResultado = "Redes por sistema (média)",
                UnidadeResultado = "",
                Calcular = vars => vars["nRedes"] / vars["nSistemas"]
            },
            new Formula
            {
                Id = "5_cr02", Nome = "Grupos Espaciais", Categoria = "Cristalografia", SubCategoria = "Simetria Cristalina",
                Expressao = "230 grupos espaciais em 3D;  translação + operações pontuais",
                ExprTexto = "230 grupos espaciais em 3D",
                Icone = "G",
                Descricao = "Grupos espaciais: simetria completa de cristais incluindo translações, rotações, reflexões, eixos helicoidais e planos deslizantes. 230 em 3D.",
                ExemploPratico = "Exemplo: fração acumulada de grupos até um subconjunto Nclass=46 -> 46/230=0.2 (20%).",
                Variaveis = [ new() { Simbolo = "Nclass", Nome = "Quantidade em uma classe/subconjunto", ValorPadrao = 46, ValorMin = 0 }, new() { Simbolo = "Ntotal", Nome = "Total de grupos espaciais", ValorPadrao = 230, ValorMin = 1 } ],
                VariavelResultado = "Fração Nclass/Ntotal",
                UnidadeResultado = "",
                Calcular = vars => vars["Nclass"] / vars["Ntotal"]
            },
            new Formula
            {
                Id = "5_cr03", Nome = "Rede Recíproca", Categoria = "Cristalografia", SubCategoria = "Simetria Cristalina",
                Expressao = "b₁ = 2π(a₂×a₃)/(a₁·a₂×a₃);  idem b₂,b₃",
                ExprTexto = "bᵢ = 2π(aⱼ×aₖ)/(a₁·a₂×a₃)",
                Icone = "b",
                Descricao = "Vetores da rede recíproca: duais aos vetores primitivos da rede direta. aᵢ·bⱼ = 2πδᵢⱼ. Espaço de ondas e difração.",
                ExemploPratico = "Exemplo: para cúbica simples com a=2 A, |b|=2π/a≈3.1416 A^-1.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Parâmetro de rede a", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "|b|",
                UnidadeResultado = "",
                Calcular = vars => 2 * Math.PI / vars["a"]
            },
            new Formula
            {
                Id = "5_cr04", Nome = "Vetor de Rede Recíproca (Miller)", Categoria = "Cristalografia", SubCategoria = "Simetria Cristalina",
                Expressao = "G = h·b₁ + k·b₂ + l·b₃;  h,k,l = índices de Miller",
                ExprTexto = "G = hb₁+kb₂+lb₃",
                Icone = "G",
                Descricao = "Vetor de rede recíproca indexado por inteiros de Miller (hkl). Perpendicular ao plano cristalográfico (hkl). |G| = 2π/d_{hkl}.",
                ExemploPratico = "Exemplo: em cúbica com a=2 A e (hkl)=(1,1,1), |G|=(2π/a)*sqrt(3)≈5.441 A^-1.",
                Variaveis = [ new() { Simbolo = "h", Nome = "Índice de Miller h", ValorPadrao = 1 }, new() { Simbolo = "k", Nome = "Índice de Miller k", ValorPadrao = 1 }, new() { Simbolo = "l", Nome = "Índice de Miller l", ValorPadrao = 1 }, new() { Simbolo = "a", Nome = "Parâmetro de rede a", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "G",
                UnidadeResultado = "",
                Calcular = vars => (2 * Math.PI / vars["a"]) * Math.Sqrt(vars["h"] * vars["h"] + vars["k"] * vars["k"] + vars["l"] * vars["l"])
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
                ExemploPratico = "Exemplo: d=2 A, θ=30° e n=1 -> λ=2*d*sinθ=2 A.",
                Variaveis = [ new() { Simbolo = "d", Nome = "Espaçamento interplanar d", ValorPadrao = 2, ValorMin = 0.001 }, new() { Simbolo = "thetaDeg", Nome = "Ângulo θ (graus)", ValorPadrao = 30 }, new() { Simbolo = "n", Nome = "Ordem n", ValorPadrao = 1, ValorMin = 1 } ],
                VariavelResultado = "λ",
                UnidadeResultado = "",
                Calcular = vars => 2 * vars["d"] * Math.Sin(Math.PI * vars["thetaDeg"] / 180.0) / vars["n"]
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
                ExemploPratico = "Exemplo: kf=(4,1,0), ki=(1,1,0) -> |Δk|=|(3,0,0)|=3.",
                Variaveis = [ new() { Simbolo = "dKx", Nome = "Componente Δkx", ValorPadrao = 3 }, new() { Simbolo = "dKy", Nome = "Componente Δky", ValorPadrao = 0 }, new() { Simbolo = "dKz", Nome = "Componente Δkz", ValorPadrao = 0 } ],
                VariavelResultado = "|Δk|",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["dKx"] * vars["dKx"] + vars["dKy"] * vars["dKy"] + vars["dKz"] * vars["dKz"])
            },
            new Formula
            {
                Id = "5_cr07", Nome = "Fator de Estrutura", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "F(hkl) = Σⱼ fⱼ·exp(2πi(hxⱼ+kyⱼ+lzⱼ))",
                ExprTexto = "F(hkl)=Σ fⱼ exp(2πi(hxⱼ+kyⱼ+lzⱼ))",
                Icone = "F",
                Descricao = "Fator de estrutura: amplitude de espalhamento de uma reflexão (hkl). fⱼ = fator de espalhamento atômico, (xⱼ,yⱼ,zⱼ) = posições na célula.",
                ExemploPratico = "Exemplo simplificado (2 átomos): F=f1*cos(phi1)+f2*cos(phi2) com f1=10, f2=8, phi1=0 e phi2=π -> F=2.",
                Variaveis = [ new() { Simbolo = "f1", Nome = "Fator atômico f1", ValorPadrao = 10 }, new() { Simbolo = "f2", Nome = "Fator atômico f2", ValorPadrao = 8 }, new() { Simbolo = "phi1", Nome = "Fase φ1 (rad)", ValorPadrao = 0 }, new() { Simbolo = "phi2", Nome = "Fase φ2 (rad)", ValorPadrao = 3.1415926535 } ],
                VariavelResultado = "F_re (parte real simplificada)",
                UnidadeResultado = "",
                Calcular = vars => vars["f1"] * Math.Cos(vars["phi1"]) + vars["f2"] * Math.Cos(vars["phi2"])
            },
            new Formula
            {
                Id = "5_cr08", Nome = "Extinções Sistemáticas", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "F(hkl) = 0 para certas reflexões por simetria",
                ExprTexto = "F=0 em reflexões proibidas por simetria",
                Icone = "0",
                Descricao = "Extinções sistemáticas: certas reflexões têm F=0 devido a simetrias (centragem, eixos helicoidais, planos deslizantes). Revelam o grupo espacial.",
                ExemploPratico = "Exemplo para rede de corpo centrado (I): reflexão permitida se h+k+l é par; para (1,1,1), soma=3 (ímpar) -> extinta.",
                Variaveis = [ new() { Simbolo = "h", Nome = "Índice h", ValorPadrao = 1 }, new() { Simbolo = "k", Nome = "Índice k", ValorPadrao = 1 }, new() { Simbolo = "l", Nome = "Índice l", ValorPadrao = 1 } ],
                VariavelResultado = "Permitida? (1 sim, 0 não)",
                UnidadeResultado = "",
                Calcular = vars => (((int)(vars["h"] + vars["k"] + vars["l"])) % 2 == 0) ? 1 : 0
            },
            new Formula
            {
                Id = "5_cr09", Nome = "Intensidade de Difração", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "I(hkl) ∝ |F(hkl)|² · LP · A · ...",
                ExprTexto = "I ∝ |F|²·LP·A",
                Icone = "I",
                Descricao = "Intensidade observada: proporcional a |F|² vezes fatores de correção: Lorentz-polarização (LP), absorção (A), multiplicidade, etc.",
                ExemploPratico = "Exemplo: |F|=5, LP=0.8 e A=0.9 -> I ~ 5^2*0.8*0.9 = 18.",
                Variaveis = [ new() { Simbolo = "Fabs", Nome = "|F(hkl)|", ValorPadrao = 5, ValorMin = 0 }, new() { Simbolo = "LP", Nome = "Fator Lorentz-polarização", ValorPadrao = 0.8, ValorMin = 0 }, new() { Simbolo = "A", Nome = "Fator de absorção", ValorPadrao = 0.9, ValorMin = 0 } ],
                VariavelResultado = "I (proporcional)",
                UnidadeResultado = "",
                Calcular = vars => vars["Fabs"] * vars["Fabs"] * vars["LP"] * vars["A"]
            },
            new Formula
            {
                Id = "5_cr10", Nome = "Fator de Debye-Waller", Categoria = "Cristalografia", SubCategoria = "Difração",
                Expressao = "fⱼ → fⱼ·exp(-B·sin²θ/λ²)  (vibrações térmicas)",
                ExprTexto = "f→f·exp(-B sin²θ/λ²)",
                Icone = "B",
                Descricao = "Fator de Debye-Waller: atenuação da difração por vibrações térmicas dos átomos. B = 8π²⟨u²⟩ (deslocamento quadrático médio).",
                Criador = "Peter Debye / Ivar Waller",
                ExemploPratico = "Exemplo: B=1.2, θ=30° e λ=1.54 A -> fator=exp(-B sin^2θ/λ^2)≈0.881.",
                Variaveis = [ new() { Simbolo = "B", Nome = "Parâmetro térmico B", ValorPadrao = 1.2, ValorMin = 0 }, new() { Simbolo = "thetaDeg", Nome = "Ângulo θ (graus)", ValorPadrao = 30 }, new() { Simbolo = "lambda", Nome = "Comprimento de onda λ", ValorPadrao = 1.54, ValorMin = 0.001 }, new() { Simbolo = "f0", Nome = "Amplitude sem atenuação f0", ValorPadrao = 1 } ],
                VariavelResultado = "f_atenuado",
                UnidadeResultado = "",
                Calcular = vars => {
                    var s = Math.Sin(Math.PI * vars["thetaDeg"] / 180.0);
                    return vars["f0"] * Math.Exp(-vars["B"] * s * s / (vars["lambda"] * vars["lambda"]));
                }
            },
        ]);
    }
}
