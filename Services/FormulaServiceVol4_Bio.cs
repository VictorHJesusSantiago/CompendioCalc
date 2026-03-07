using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 4 — PARTE V: BIOLOGIA, MEDICINA E PSICOMETRIA
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 19. MORFOGÊNESE, PADRÕES DE TURING E REDES NEURAIS BIOLÓGICAS
    // ─────────────────────────────────────────────────────
    private void AdicionarMorfogeneseTuring()
    {
        _formulas.AddRange([
            // 19.1 Padrões de Turing
            new Formula
            {
                Id = "4_tu01", Nome = "Reação-Difusão (Geral)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = D_u∇²u + f(u,v);  ∂v/∂t = D_v∇²v + g(u,v)",
                ExprTexto = "∂u/∂t=Du∇²u+f(u,v); ∂v/∂t=Dv∇²v+g(u,v)",
                Icone = "RD",
                Descricao = "Sistema de reação-difusão com dois morfogênios u (ativador) e v (inibidor). Turing: se Dv≫Du, estado homogêneo pode ser instável → formação espontânea de padrões.",
                Criador = "Alan Turing",
                AnoOrigin = "1952",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Du", Nome = "Difusividade Du", ValorPadrao = 0.01, ValorMin = 0 }, new() { Simbolo = "lapU", Nome = "Laplaciano de u", ValorPadrao = -0.3 }, new() { Simbolo = "f", Nome = "Reacao f(u,v)", ValorPadrao = 0.2 } ],
                VariavelResultado = "∂u/∂t",
                UnidadeResultado = "",
                Calcular = vars => vars["Du"] * vars["lapU"] + vars["f"]
            },
            new Formula
            {
                Id = "4_tu02", Nome = "Condição de Instabilidade de Turing", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "fu+gv < 0, fu·gv-fg·gu > 0, Dv·fu+Du·gv > 0",
                ExprTexto = "tr(J)<0,det(J)>0, Dv·fu+Du·gv>0",
                Icone = "ins",
                Descricao = "Estado homogêneo localmente estável (traço<0, det>0), mas difusão desestabiliza: existe k² tal que Re(λ(k²))>0. Requer Dv/Du > limiar crítico (razão de difusividade).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Dv", Nome = "Difusividade Dv", ValorPadrao = 10, ValorMin = 0 }, new() { Simbolo = "Du", Nome = "Difusividade Du", ValorPadrao = 1, ValorMin = 0.0001 }, new() { Simbolo = "fu", Nome = "Derivada fu", ValorPadrao = 0.8 }, new() { Simbolo = "gv", Nome = "Derivada gv", ValorPadrao = -0.2 } ],
                VariavelResultado = "Dv·fu+Du·gv",
                UnidadeResultado = "",
                Calcular = vars => vars["Dv"] * vars["fu"] + vars["Du"] * vars["gv"]
            },
            new Formula
            {
                Id = "4_tu03", Nome = "Modelo de Gierer-Meinhardt", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂a/∂t = Da∇²a + ρ(a²/h) - μa + ρ₀;  ∂h/∂t = Dh∇²h + ρ'a² - νh",
                ExprTexto = "ȧ=Da∇²a+ρa²/h−μa; ḣ=Dh∇²h+ρ'a²−νh",
                Icone = "GM",
                Descricao = "Ativador-Inibidor: a = ativador (autocatálise a²), h = inibidor (longo alcance, Dh≫Da). Gera manchas, listras (zebra, leopardo). Modelo seminal em biologia do desenvolvimento.",
                Criador = "Alfred Gierer / Hans Meinhardt",
                AnoOrigin = "1972",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Da", Nome = "Da", ValorPadrao = 0.01, ValorMin = 0 }, new() { Simbolo = "lapA", Nome = "Laplaciano de a", ValorPadrao = -0.2 }, new() { Simbolo = "rho", Nome = "rho", ValorPadrao = 1 }, new() { Simbolo = "a", Nome = "a", ValorPadrao = 1.1 }, new() { Simbolo = "h", Nome = "h", ValorPadrao = 0.8, ValorMin = 0.0001 }, new() { Simbolo = "mu", Nome = "μ", ValorPadrao = 0.4 }, new() { Simbolo = "rho0", Nome = "ρ0", ValorPadrao = 0.1 } ],
                VariavelResultado = "∂a/∂t",
                UnidadeResultado = "",
                Calcular = vars => vars["Da"] * vars["lapA"] + vars["rho"] * vars["a"] * vars["a"] / vars["h"] - vars["mu"] * vars["a"] + vars["rho0"]
            },
            new Formula
            {
                Id = "4_tu04", Nome = "Modelo de Gray-Scott", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = Du∇²u - uv² + F(1-u);  ∂v/∂t = Dv∇²v + uv² - (F+k)v",
                ExprTexto = "u̇=Du∇²u−uv²+F(1−u); v̇=Dv∇²v+uv²−(F+k)v",
                Icone = "GS",
                Descricao = "Modelo com cinética autocatalítica cúbica. Riquíssima variedade de padrões: manchas, listras, labirintos, solitons, caos espaço-temporal. F = taxa de alimentação, k = taxa de remoção.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Du", Nome = "Du", ValorPadrao = 0.01, ValorMin = 0 }, new() { Simbolo = "lapU", Nome = "Laplaciano de u", ValorPadrao = -0.1 }, new() { Simbolo = "u", Nome = "u", ValorPadrao = 1.2 }, new() { Simbolo = "v", Nome = "v", ValorPadrao = 0.7 }, new() { Simbolo = "F", Nome = "F", ValorPadrao = 0.04 } ],
                VariavelResultado = "∂u/∂t",
                UnidadeResultado = "",
                Calcular = vars => vars["Du"] * vars["lapU"] - vars["u"] * vars["v"] * vars["v"] + vars["F"] * (1 - vars["u"])
            },
            new Formula
            {
                Id = "4_tu05", Nome = "Equação de Swift-Hohenberg", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = εu - (1+∇²)²u - u³",
                ExprTexto = "u̇ = εu−(1+∇²)²u−u³",
                Icone = "SH",
                Descricao = "Modelo canônico para formação de padrões com comprimento de onda preferencial k=1. Bifurcação em ε=0. Usado em convecção de Rayleigh-Bénard, cristais líquidos, óptica.",
                Criador = "Jack Swift / Pierre Hohenberg",
                AnoOrigin = "1977",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "u", Nome = "u", ValorPadrao = 0.8 }, new() { Simbolo = "epsilon", Nome = "ε", ValorPadrao = 0.3 }, new() { Simbolo = "k4u", Nome = "(1+∇²)^2u", ValorPadrao = 0.6 } ],
                VariavelResultado = "∂u/∂t",
                UnidadeResultado = "",
                Calcular = vars => vars["epsilon"] * vars["u"] - vars["k4u"] - vars["u"] * vars["u"] * vars["u"]
            },
            new Formula
            {
                Id = "4_tu06", Nome = "Equação de Cahn-Hilliard", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂c/∂t = M∇²(∂F/∂c - κ∇²c);  F = ¼(c²-1)²",
                ExprTexto = "∂c/∂t = M∇²(δF/δc); F=free energy",
                Icone = "CH",
                Descricao = "Separação de fases com conservação de massa: c = concentração, F = energia livre de Ginzburg-Landau, κ = rigidez da interface. Decomposição espinodal, coalescência de domínios.",
                Criador = "John Cahn / John Hilliard",
                AnoOrigin = "1958",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "M", Nome = "Mobilidade M", ValorPadrao = 0.2, ValorMin = 0 }, new() { Simbolo = "dFdc", Nome = "∂F/∂c", ValorPadrao = 0.5 }, new() { Simbolo = "kappa", Nome = "κ", ValorPadrao = 0.1, ValorMin = 0 }, new() { Simbolo = "lapC", Nome = "∇²c", ValorPadrao = -0.3 } ],
                VariavelResultado = "∂c/∂t",
                UnidadeResultado = "",
                Calcular = vars => vars["M"] * (vars["dFdc"] - vars["kappa"] * vars["lapC"])
            },
            new Formula
            {
                Id = "4_tu07", Nome = "Quimiotaxia (Keller-Segel)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂ρ/∂t = D∇²ρ - χ∇·(ρ∇c);  ∂c/∂t = Dc∇²c + αρ - βc",
                ExprTexto = "ρ̇=D∇²ρ−χ∇·(ρ∇c); ċ=Dc∇²c+αρ−βc",
                Icone = "KS",
                Descricao = "Células ρ migram em direção ao gradiente do quimioatrativo c (χ>0). Agregação pode levar a blow-up em tempo finito (2D: se massa > 8π/χ). Modelo de Dictyostelium, angiogênese.",
                Criador = "Evelyn Keller / Lee Segel",
                AnoOrigin = "1970",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "D", Nome = "D", ValorPadrao = 0.8, ValorMin = 0 }, new() { Simbolo = "lapRho", Nome = "∇²ρ", ValorPadrao = -0.2 }, new() { Simbolo = "chi", Nome = "χ", ValorPadrao = 0.5 }, new() { Simbolo = "rho", Nome = "ρ", ValorPadrao = 1.2 }, new() { Simbolo = "grad", Nome = "∇·(ρ∇c)", ValorPadrao = 0.4 } ],
                VariavelResultado = "∂ρ/∂t",
                UnidadeResultado = "",
                Calcular = vars => vars["D"] * vars["lapRho"] - vars["chi"] * vars["grad"]
            },
            new Formula
            {
                Id = "4_tu08", Nome = "Onda de Propagação (Fisher-KPP)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "∂u/∂t = D∇²u + ru(1-u);  velocidade mínima c* = 2√(rD)",
                ExprTexto = "u̇=D∇²u+ru(1−u); c*=2√(rD)",
                Icone = "KPP",
                Descricao = "Frente de onda viajante em reação-difusão logística. c* = velocidade mínima de propagação: selecionada para condições iniciais compactas. Invasão de espécies, propagação de genes.",
                Criador = "Fisher / Kolmogorov-Petrovsky-Piskunov",
                AnoOrigin = "1937",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "r", Nome = "Taxa de crescimento r", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "D", Nome = "Difusividade D", ValorPadrao = 1.2, ValorMin = 0 } ],
                VariavelResultado = "c*",
                UnidadeResultado = "",
                Calcular = vars => 2 * Math.Sqrt(vars["r"] * vars["D"])
            },
            new Formula
            {
                Id = "4_tu09", Nome = "Difusão Relativa", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "R_D = Dv/Du",
                ExprTexto = "RD = Dv/Du",
                Icone = "RD",
                Descricao = "Razão de difusão entre inibidor e ativador; valores altos favorecem padrões de Turing.",
                ExemploPratico = "Exemplo: Dv=10 e Du=1 => RD=10.",
                Variaveis = [ new() { Simbolo = "Dv", Nome = "Difusão do inibidor Dv", ValorPadrao = 10, ValorMin = 0.0001 }, new() { Simbolo = "Du", Nome = "Difusão do ativador Du", ValorPadrao = 1, ValorMin = 0.0001 } ],
                VariavelResultado = "R_D",
                UnidadeResultado = "",
                Calcular = vars => vars["Dv"] / vars["Du"]
            },
            new Formula
            {
                Id = "4_tu10", Nome = "Termo de Reação f(u,v)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "f(u,v)=αu-βv+u²v",
                ExprTexto = "f = alpha*u - beta*v + u^2*v",
                Icone = "f",
                Descricao = "Função de reação do morfogênio ativador no sistema reação-difusão.",
                ExemploPratico = "Exemplo: u=1.1, v=0.6, α=0.8, β=0.3.",
                Variaveis = [ new() { Simbolo = "u", Nome = "Ativador u", ValorPadrao = 1.1 }, new() { Simbolo = "v", Nome = "Inibidor v", ValorPadrao = 0.6 }, new() { Simbolo = "α", Nome = "Parâmetro α", ValorPadrao = 0.8 }, new() { Simbolo = "β", Nome = "Parâmetro β", ValorPadrao = 0.3 } ],
                VariavelResultado = "f(u,v)",
                UnidadeResultado = "",
                Calcular = vars => vars["α"] * vars["u"] - vars["β"] * vars["v"] + vars["u"] * vars["u"] * vars["v"]
            },
            new Formula
            {
                Id = "4_tu11", Nome = "Termo de Reação g(u,v)", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "g(u,v)=γu-δv-u²v",
                ExprTexto = "g = gamma*u - delta*v - u^2*v",
                Icone = "g",
                Descricao = "Função de reação do inibidor no sistema reação-difusão.",
                ExemploPratico = "Exemplo: u=1.1, v=0.6, γ=0.5, δ=0.2.",
                Variaveis = [ new() { Simbolo = "u", Nome = "Ativador u", ValorPadrao = 1.1 }, new() { Simbolo = "v", Nome = "Inibidor v", ValorPadrao = 0.6 }, new() { Simbolo = "γ", Nome = "Parâmetro γ", ValorPadrao = 0.5 }, new() { Simbolo = "δ", Nome = "Parâmetro δ", ValorPadrao = 0.2 } ],
                VariavelResultado = "g(u,v)",
                UnidadeResultado = "",
                Calcular = vars => vars["γ"] * vars["u"] - vars["δ"] * vars["v"] - vars["u"] * vars["u"] * vars["v"]
            },
            new Formula
            {
                Id = "4_tu12", Nome = "Número de Onda Crítico", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "k_c = \u221a((Dv·fu+Du·gv)/(2DuDv))",
                ExprTexto = "kc = sqrt((Dv*fu + Du*gv)/(2*Du*Dv))",
                Icone = "kc",
                Descricao = "Escala espacial dominante do padrão gerado por instabilidade de Turing.",
                ExemploPratico = "Exemplo: Dv=12, Du=1, fu=0.9, gv=-0.1.",
                Variaveis = [ new() { Simbolo = "Dv", Nome = "Dv", ValorPadrao = 12, ValorMin = 0.0001 }, new() { Simbolo = "Du", Nome = "Du", ValorPadrao = 1, ValorMin = 0.0001 }, new() { Simbolo = "fu", Nome = "Derivada fu", ValorPadrao = 0.9 }, new() { Simbolo = "gv", Nome = "Derivada gv", ValorPadrao = -0.1 } ],
                VariavelResultado = "k_c",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(Math.Abs((vars["Dv"] * vars["fu"] + vars["Du"] * vars["gv"]) / (2 * vars["Du"] * vars["Dv"])))
            },
            new Formula
            {
                Id = "4_tu13", Nome = "Comprimento de Onda do Padrão", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "λ = 2π/k_c",
                ExprTexto = "lambda = 2*pi/kc",
                Icone = "λ",
                Descricao = "Escala espacial típica de manchas/listras produzidas pelo modo mais instável.",
                ExemploPratico = "Exemplo: kc=0.8 => λ≈7.85.",
                Variaveis = [ new() { Simbolo = "k", Nome = "Número de onda k", ValorPadrao = 0.8, ValorMin = 0.0001 } ],
                VariavelResultado = "λ",
                UnidadeResultado = "",
                Calcular = vars => 2 * Math.PI / vars["k"]
            },
            new Formula
            {
                Id = "4_tu14", Nome = "Crescimento Linear de Perturbação", Categoria = "Morfogênese e Turing", SubCategoria = "Padrões de Turing",
                Expressao = "δ(t)=δ₀e^{σt}",
                ExprTexto = "delta(t)=delta0*exp(sigma*t)",
                Icone = "σ",
                Descricao = "Taxa de crescimento inicial de um modo perturbado; σ>0 indica instabilidade.",
                ExemploPratico = "Exemplo: δ0=0.01, σ=0.4, t=5 => δ≈0.0739.",
                Variaveis = [ new() { Simbolo = "δ0", Nome = "Perturbação inicial", ValorPadrao = 0.01, ValorMin = 0 }, new() { Simbolo = "σ", Nome = "Taxa σ", ValorPadrao = 0.4 }, new() { Simbolo = "t", Nome = "Tempo t", ValorPadrao = 5, ValorMin = 0 } ],
                VariavelResultado = "δ(t)",
                UnidadeResultado = "",
                Calcular = vars => vars["δ0"] * Math.Exp(vars["σ"] * vars["t"])
            },
            // 19.2 Redes Neurais Biológicas
            new Formula
            {
                Id = "4_wc01", Nome = "Modelo de Wilson-Cowan", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "τₑĖ = -E + Sₑ(wₑₑE - wₑᵢI + Iₑₓₜ)",
                ExprTexto = "τeĖ = −E+Se(weeE−weiI+Iext)",
                Icone = "WC",
                Descricao = "Taxa de disparo da população excitatória E. Se = sigmoide. wee = peso E→E, wei = peso I→E. Base de modelos de campo médio cortical: gera oscilações, bifurcações.",
                Criador = "Hugh Wilson / Jack Cowan",
                AnoOrigin = "1972",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "τ", Nome = "Constante de tempo τe", ValorPadrao = 10, ValorMin = 0.001 }, new() { Simbolo = "E", Nome = "Atividade E", ValorPadrao = 0.4 }, new() { Simbolo = "I", Nome = "Atividade I", ValorPadrao = 0.3 }, new() { Simbolo = "wEE", Nome = "Peso wEE", ValorPadrao = 1.5 }, new() { Simbolo = "wEI", Nome = "Peso wEI", ValorPadrao = 1.1 }, new() { Simbolo = "Iext", Nome = "Entrada externa", ValorPadrao = 0.2 } ],
                VariavelResultado = "Ė",
                UnidadeResultado = "",
                Calcular = vars => (-vars["E"] + 1.0 / (1.0 + Math.Exp(-(vars["wEE"] * vars["E"] - vars["wEI"] * vars["I"] + vars["Iext"])))) / vars["τ"]
            },
            new Formula
            {
                Id = "4_wc02", Nome = "Wilson-Cowan (Inibitória)", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "τᵢİ = -I + Sᵢ(wᵢₑE - wᵢᵢI + Iᵢₑₓₜ)",
                ExprTexto = "τiİ = −I+Si(wieE−wiiI+Iiext)",
                Icone = "WCi",
                Descricao = "População inibitória I recebe excitação de E (wie) e auto-inibição (wii). Balanço E/I crucial: desequilíbrio → epilepsia (excesso E) ou coma (excesso I).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "τ", Nome = "Constante de tempo τi", ValorPadrao = 12, ValorMin = 0.001 }, new() { Simbolo = "E", Nome = "Atividade E", ValorPadrao = 0.4 }, new() { Simbolo = "I", Nome = "Atividade I", ValorPadrao = 0.3 }, new() { Simbolo = "wIE", Nome = "Peso wIE", ValorPadrao = 1.2 }, new() { Simbolo = "wII", Nome = "Peso wII", ValorPadrao = 0.8 }, new() { Simbolo = "Iext", Nome = "Entrada externa", ValorPadrao = 0.1 } ],
                VariavelResultado = "İ",
                UnidadeResultado = "",
                Calcular = vars => (-vars["I"] + 1.0 / (1.0 + Math.Exp(-(vars["wIE"] * vars["E"] - vars["wII"] * vars["I"] + vars["Iext"])))) / vars["τ"]
            },
            new Formula
            {
                Id = "4_wc03", Nome = "Bifurcação de Hopf (Oscilações)", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "tr(J)=0 → ciclo limite;  ω = √(det J) no limiar",
                ExprTexto = "tr(J)=0: Hopf → oscilações com ω=√detJ",
                Icone = "Hopf",
                Descricao = "Transição de ponto fixo estável para ciclo limite: par de autovalores complexos cruza eixo imaginário. Gera ritmos cerebrais (α~10Hz, γ~40Hz). Supercrítica = suave, subcrítica = abrupta.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "detJ", Nome = "Determinante de J", ValorPadrao = 9, ValorMin = 0 } ],
                VariavelResultado = "ω",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["detJ"])
            },
            new Formula
            {
                Id = "4_wc04", Nome = "Neural Field Equation", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "τ∂u/∂t = -u + ∫w(x-x')S(u(x'))dx' + I(x)",
                ExprTexto = "τu̇ = −u+∫w(x−x')S(u)dx'+I",
                Icone = "NFE",
                Descricao = "Teoria de campo neural (Amari/Wilson-Cowan contínuo): w = kernel de conectividade (Mexican hat: excitação local, inibição lateral). Gera bumps de atividade (memória de trabalho), ondas.",
                Criador = "Shun-ichi Amari",
                AnoOrigin = "1977",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "τ", Nome = "Constante τ", ValorPadrao = 10, ValorMin = 0.001 }, new() { Simbolo = "u", Nome = "Estado u", ValorPadrao = 0.5 }, new() { Simbolo = "wS", Nome = "Termo integral", ValorPadrao = 0.9 }, new() { Simbolo = "I", Nome = "Entrada I", ValorPadrao = 0.2 } ],
                VariavelResultado = "∂u/∂t",
                UnidadeResultado = "",
                Calcular = vars => (-vars["u"] + vars["wS"] + vars["I"]) / vars["τ"]
            },
            new Formula
            {
                Id = "4_wc05", Nome = "FitzHugh-Nagumo", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "v̇ = v - v³/3 - w + I;  ẇ = ε(v + a - bw)",
                ExprTexto = "v̇=v−v³/3−w+I; ẇ=ε(v+a−bw)",
                Icone = "FHN",
                Descricao = "Simplificação de Hodgkin-Huxley para 2D: v = voltagem (rápida), w = recuperação (lenta, ε≪1). Excitabilidade, oscilações, bistabilidade dependendo de parâmetros a,b,I.",
                Criador = "Richard FitzHugh / Jinichi Nagumo",
                AnoOrigin = "1961",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "v", Nome = "v", ValorPadrao = 0.7 }, new() { Simbolo = "w", Nome = "w", ValorPadrao = 0.3 }, new() { Simbolo = "I", Nome = "Corrente I", ValorPadrao = 0.5 } ],
                VariavelResultado = "v̇",
                UnidadeResultado = "",
                Calcular = vars => vars["v"] - vars["v"] * vars["v"] * vars["v"] / 3.0 - vars["w"] + vars["I"]
            },
            new Formula
            {
                Id = "4_wc06", Nome = "Izhikevich (Neurônio)", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "v̇ = 0.04v² + 5v + 140 - u + I;  u̇ = a(bv-u); if v≥30: v→c, u→u+d",
                ExprTexto = "v̇=0.04v²+5v+140−u+I; u̇=a(bv−u)",
                Icone = "Izh",
                Descricao = "Modelo de neurônio computacionalmente eficiente (2 variáveis + reset) que reproduz ~20 padrões de disparo biológicos variando a,b,c,d. Simula redes de 10⁶ neurônios em tempo real.",
                Criador = "Eugene Izhikevich",
                AnoOrigin = "2003",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "v", Nome = "v", ValorPadrao = -60 }, new() { Simbolo = "u", Nome = "u", ValorPadrao = -12 }, new() { Simbolo = "I", Nome = "Corrente I", ValorPadrao = 10 } ],
                VariavelResultado = "v̇",
                UnidadeResultado = "",
                Calcular = vars => 0.04 * vars["v"] * vars["v"] + 5 * vars["v"] + 140 - vars["u"] + vars["I"]
            },
            new Formula
            {
                Id = "4_wc07", Nome = "Wilson-Cowan em Equilíbrio", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "E*=Sₑ(wₑₑE*−wₑᵢI*+Iₑₓₜ), I*=Sᵢ(wᵢₑE*−wᵢᵢI*+Iᵢₑₓₜ)",
                ExprTexto = "E*=Se(...), I*=Si(...)",
                Icone = "Eq",
                Descricao = "Ponto fixo populacional para as taxas de excitação/inibição.",
                ExemploPratico = "Exemplo: E*=0.55 e I*=0.35 => balanço EI=0.20.",
                Variaveis = [ new() { Simbolo = "E", Nome = "Atividade excitatória E", ValorPadrao = 0.55, ValorMin = 0 }, new() { Simbolo = "I", Nome = "Atividade inibitória I", ValorPadrao = 0.35, ValorMin = 0 } ],
                VariavelResultado = "E-I",
                UnidadeResultado = "",
                Calcular = vars => vars["E"] - vars["I"]
            },
            new Formula
            {
                Id = "4_wc08", Nome = "Constante de Tempo Efetiva", Categoria = "Morfogênese e Turing", SubCategoria = "Redes Neurais Biológicas",
                Expressao = "τ_eff = 1/(1/τₑ + wₑₑ - wₑᵢ)",
                ExprTexto = "tau_eff = 1/(1/tau + wee - wei)",
                Icone = "τ",
                Descricao = "Escala temporal efetiva após realimentação recorrente na dinâmica de E.",
                ExemploPratico = "Exemplo: τ=10, wee=0.25, wei=0.1 => τeff≈4.",
                Variaveis = [ new() { Simbolo = "τ", Nome = "Constante de tempo τ", ValorPadrao = 10, ValorMin = 0.001 }, new() { Simbolo = "wEE", Nome = "Peso excitatório wEE", ValorPadrao = 0.25 }, new() { Simbolo = "wEI", Nome = "Peso inibitório wEI", ValorPadrao = 0.1 } ],
                VariavelResultado = "τ_eff",
                UnidadeResultado = "",
                Calcular = vars => 1.0 / ((1.0 / vars["τ"]) + vars["wEE"] - vars["wEI"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 20. RECONSTRUÇÃO DE IMAGEM MÉDICA
    // ─────────────────────────────────────────────────────
    private void AdicionarImagemMedica()
    {
        _formulas.AddRange([
            // 20.1 Tomografia Computadorizada
            new Formula
            {
                Id = "4_ct01", Nome = "Transformada de Radon", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "Rf(θ,s) = ∫∫ f(x,y)δ(xcosθ+ysinθ-s)dxdy",
                ExprTexto = "Rf(θ,s) = ∫f·δ(xcosθ+ysinθ−s)dA",
                Icone = "R",
                Descricao = "Integral de f ao longo da reta xcosθ+ysinθ=s: projeção no ângulo θ. CT coleta projeções em muitos ângulos. Problema inverso: reconstruir f a partir de Rf.",
                Criador = "Johann Radon",
                AnoOrigin = "1917",
                ExemploPratico = "Exemplo: Para 100 subdivisões entre 0 e 1: Δ = 1/100 = 0.01 (comprimento de linha por subdivisão)",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior", ValorPadrao = 1 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Δ_linha",
                UnidadeResultado = "",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
            new Formula
            {
                Id = "4_ct02", Nome = "Teorema da Fatia de Fourier", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "F₁D{Rf(θ,·)}(ω) = F₂D{f}(ωcosθ, ωsinθ)",
                ExprTexto = "FT(projeção θ) = FT₂D ao longo de θ",
                Icone = "FST",
                Descricao = "Transformada de Fourier 1D da projeção no ângulo θ = fatia da TF 2D de f na mesma direção. Base teórica de todos os métodos de reconstrução tomográfica.",
                ExemploPratico = "Exemplo: Componente FT=5.0 no ângulo θ=30° → FT_2D = 5.0 (componente da transformada 2D)",
                Variaveis = [ new() { Simbolo = "FT", Nome = "Componente FT 1D", ValorPadrao = 5.0 }, new() { Simbolo = "theta", Nome = "Ângulo θ (graus)", ValorPadrao = 30 } ],
                VariavelResultado = "FT_2D",
                UnidadeResultado = "",
                Calcular = vars => vars["FT"]
            },
            new Formula
            {
                Id = "4_ct03", Nome = "Retroprojeção Filtrada (FBP)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "f(x,y) = ∫₀^π [p_θ * h](xcosθ+ysinθ) dθ",
                ExprTexto = "f = ∫₀^π (pθ*h)(xcosθ+ysinθ)dθ",
                Icone = "FBP",
                Descricao = "Algoritmo padrão de CT: filtrar projeções com kernel rampa (|ω|) e retroprojetar. O(N³) para imagem N×N. Rápido e robusto. Usado em scanners clínicos desde anos 1970.",
                ExemploPratico = "Exemplo: Integral de 0 a π com 100 subdivisões: Δθ = π/100 ≈ 0.0314 rad/passo",
                Variaveis = [ new() { Simbolo = "a", Nome = "Limite inferior", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "Limite superior (π)", ValorPadrao = 3.14159 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 100, ValorMin = 1 } ],
                VariavelResultado = "Δθ",
                UnidadeResultado = "rad",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
            new Formula
            {
                Id = "4_ct04", Nome = "Reconstrução Iterativa (MBIR)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "x̂ = argmin_x ‖Ax-b‖² + λR(x)",
                ExprTexto = "x̂ = argmin ‖Ax−b‖²+λR(x)",
                Icone = "MBIR",
                Descricao = "Reconstrução model-based: A = operador de projeção, b = sinograma medido, R = regularização (TV, wavelets). Superior a FBP para dose baixa e dados incompletos. Custo: iterações O(N²) de projeção.",
                ExemploPratico = "Exemplo: Imagem x com norma ‖Ax-b‖²=10.5 e regularização λR=2.0 → custo total = 12.5",
                Variaveis = [ new() { Simbolo = "norm", Nome = "‖Ax-b‖²", ValorPadrao = 10.5, ValorMin = 0 }, new() { Simbolo = "reg", Nome = "λR(x)", ValorPadrao = 2.0, ValorMin = 0 } ],
                VariavelResultado = "Custo total",
                UnidadeResultado = "",
                Calcular = vars => vars["norm"] + vars["reg"]
            },
            new Formula
            {
                Id = "4_ct05", Nome = "Número de CT (Hounsfield)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "HU = 1000·(μ-μ_água)/μ_água",
                ExprTexto = "HU = 1000(μ−μágua)/μágua",
                Icone = "HU",
                Descricao = "Escala padronizada: ar = -1000 HU, água = 0 HU, osso = +1000 HU. μ = coeficiente de atenuação linear. Janela/nível: soft tissue ~40/400, pulmão ~-600/1500.",
                Criador = "Godfrey Hounsfield",
                AnoOrigin = "1971",
                ExemploPratico = "Exemplo: Tecido com μ=0.22 cm⁻¹, água μ=0.20 cm⁻¹ → HU = 1000×(0.22-0.20)/0.20 = 100 HU",
                Variaveis = [ new() { Simbolo = "mu", Nome = "μ tecido (cm⁻¹)", ValorPadrao = 0.22, ValorMin = 0 }, new() { Simbolo = "mu_w", Nome = "μ água (cm⁻¹)", ValorPadrao = 0.20, ValorMin = 0.0001 } ],
                VariavelResultado = "HU",
                UnidadeResultado = "HU",
                Calcular = vars => 1000 * (vars["mu"] - vars["mu_w"]) / vars["mu_w"]
            },
            new Formula
            {
                Id = "4_ct06", Nome = "Dose de Radiação (CTDI)", Categoria = "Imagem Médica", SubCategoria = "Tomografia Computadorizada",
                Expressao = "CTDI = (1/nT)∫D(z)dz;  DLP = CTDI×L",
                ExprTexto = "CTDI = (1/nT)∫D(z)dz; DLP=CTDI·L",
                Icone = "CTDI",
                Descricao = "CT Dose Index: dose média de um corte. DLP = Dose Length Product = CTDI × comprimento scan. Dose efetiva E = k·DLP (k~0.015 mSv/mGy·cm para abdômen). Princípio ALARA.",
                ExemploPratico = "Exemplo: Integral de dose ao longo de 10 cm com 50 subdivisões: Δz = 10/50 = 0.2 cm/amostra",
                Variaveis = [ new() { Simbolo = "a", Nome = "z inicial (cm)", ValorPadrao = 0 }, new() { Simbolo = "b", Nome = "z final (cm)", ValorPadrao = 10 }, new() { Simbolo = "n", Nome = "Subdivisões", ValorPadrao = 50, ValorMin = 1 } ],
                VariavelResultado = "Δz",
                UnidadeResultado = "cm",
                Calcular = vars => (vars["b"] - vars["a"]) / vars["n"]
            },
            // 20.2 PET/SPECT
            new Formula
            {
                Id = "4_pt01", Nome = "Modelo PET de Emissão", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "λᵢ = Σⱼ aᵢⱼ xⱼ + rᵢ + sᵢ (contagens esperadas na LOR i)",
                ExprTexto = "λᵢ = Σⱼaᵢⱼxⱼ+rᵢ+sᵢ",
                Icone = "PET",
                Descricao = "Modelo linear de emissão/detecção: x = atividade no voxel j, a = system matrix (geometria+atenuação+PSF), r = randoms, s = scatter. Estatística Poisson: Yi ~ Poisson(λi).",
                ExemploPratico = "Exemplo: Contagens esperadas na LOR i: Σ_j(a_ij×x_j)=50, randoms=5, scatter=3 → λ_i=58",
                Variaveis = [ new() { Simbolo = "emis", Nome = "Σ_j(a_ij×x_j)", ValorPadrao = 50, ValorMin = 0 }, new() { Simbolo = "r", Nome = "Randoms r_i", ValorPadrao = 5, ValorMin = 0 }, new() { Simbolo = "s", Nome = "Scatter s_i", ValorPadrao = 3, ValorMin = 0 } ],
                VariavelResultado = "λ_i",
                UnidadeResultado = "",
                Calcular = vars => vars["emis"] + vars["r"] + vars["s"]
            },
            new Formula
            {
                Id = "4_pt02", Nome = "MLEM (ML-EM)", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "xⱼ^{k+1} = (xⱼ^k / Σᵢaᵢⱼ) Σᵢ aᵢⱼ yᵢ/(Σₘ aᵢₘ xₘ^k)",
                ExprTexto = "xⱼ^{n+1} = xⱼⁿ/(Σaᵢⱼ)·Σ aᵢⱼyᵢ/(Axⁿ)ᵢ",
                Icone = "MLEM",
                Descricao = "Maximum Likelihood - Expectation Maximization: algoritmo iterativo para reconstrução PET. Preserva positividade, monotonicamente aumenta likelihood. Convergência lenta → ruidoso.",
                Criador = "Shepp / Vardi",
                AnoOrigin = "1982",
                ExemploPratico = "Exemplo: 1 iteração com normalização Σ_i(a_ij)=12.0 e update ratio=0.85 → fator = 0.85/12 ≈ 0.071",
                Variaveis = [ new() { Simbolo = "norm", Nome = "Normalização Σa_ij", ValorPadrao = 12.0, ValorMin = 0.0001 }, new() { Simbolo = "ratio", Nome = "Ratio de update", ValorPadrao = 0.85 } ],
                VariavelResultado = "Fator update",
                UnidadeResultado = "",
                Calcular = vars => vars["ratio"] / vars["norm"]
            },
            new Formula
            {
                Id = "4_pt03", Nome = "OSEM", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "MLEM com subsets: 1 iteração OSEM = S sub-iterações (S subsets)",
                ExprTexto = "OSEM: MLEM com S subsets → S× mais rápido",
                Icone = "OSEM",
                Descricao = "Ordered Subsets EM: divide projeções em S subsets e atualiza imagem a cada subset. ~S× aceleração vs MLEM. Padrão clínico (2-3 iterações × 21 subsets). Não converge exatamente.",
                Criador = "Hudson / Larkin",
                AnoOrigin = "1994",
                ExemploPratico = "Exemplo: OSEM com S=21 subsets acelera convergência por fator ≈ 21× vs MLEM padrão",
                Variaveis = [ new() { Simbolo = "S", Nome = "Número de subsets S", ValorPadrao = 21, ValorMin = 1 } ],
                VariavelResultado = "Aceleração",
                UnidadeResultado = "×",
                Calcular = vars => vars["S"]
            },
            new Formula
            {
                Id = "4_pt04", Nome = "SUV (Standardized Uptake Value)", Categoria = "Imagem Médica", SubCategoria = "PET/SPECT",
                Expressao = "SUV = C_tissue / (D_inj/W)",
                ExprTexto = "SUV = Ctissue/(Dinj/W)",
                Icone = "SUV",
                Descricao = "PET semi-quantitativo: concentração no tecido normalizada por dose injetada/peso. SUV=1 → captação média. Tumores: SUV>2.5 suspeito de malignidade. Usado em oncologia/estadiamento.",
                ExemploPratico = "Exemplo: C_tissue=3.5 kBq/mL, D_inj=400 MBq, W=70 kg → SUV = 3.5/(400000/70) ≈ 0.61",
                Variaveis = [ new() { Simbolo = "C_tissue", Nome = "Conc. tecido (kBq/mL)", ValorPadrao = 3.5, ValorMin = 0 }, new() { Simbolo = "D_inj", Nome = "Dose injetada (MBq)", ValorPadrao = 400, ValorMin = 0.001 }, new() { Simbolo = "W", Nome = "Peso paciente (kg)", ValorPadrao = 70, ValorMin = 1 } ],
                VariavelResultado = "SUV",
                UnidadeResultado = "",
                Calcular = vars => vars["C_tissue"] / ((vars["D_inj"] * 1000) / vars["W"])
            },
            // 20.3 Formulações gerais de imagem médica
            new Formula
            {
                Id = "4_im01", Nome = "Atenuação de Beer-Lambert", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral",
                Expressao = "I = I₀e^{-μx}",
                ExprTexto = "I=I0*exp(-mu*x)",
                Icone = "I",
                Descricao = "Lei de atenuação da intensidade em meios absorventes.",
                ExemploPratico = "Exemplo: I0=100, μ=0.2, x=3 => I≈54.88.",
                Variaveis = [ new() { Simbolo = "I0", Nome = "Intensidade inicial I0", ValorPadrao = 100, ValorMin = 0 }, new() { Simbolo = "μ", Nome = "Coeficiente de atenuação μ", ValorPadrao = 0.2, ValorMin = 0 }, new() { Simbolo = "x", Nome = "Espessura x", ValorPadrao = 3, ValorMin = 0 } ],
                VariavelResultado = "I",
                UnidadeResultado = "",
                Calcular = vars => vars["I0"] * Math.Exp(-vars["μ"] * vars["x"])
            },
            new Formula { Id = "4_im02", Nome = "Contraste de Intensidade", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "C=(Imax-Imin)/(Imax+Imin)", ExprTexto = "C=(Imax-Imin)/(Imax+Imin)", Icone = "C", Descricao = "Métrica simples de contraste entre tecidos.", ExemploPratico = "Exemplo: Imax=180 e Imin=60 => C=0.5.", Variaveis = [ new() { Simbolo = "Imax", Nome = "Intensidade máxima", ValorPadrao = 180, ValorMin = 0 }, new() { Simbolo = "Imin", Nome = "Intensidade mínima", ValorPadrao = 60, ValorMin = 0 } ], VariavelResultado = "C", UnidadeResultado = "", Calcular = vars => (vars["Imax"] - vars["Imin"]) / (vars["Imax"] + vars["Imin"]) },
            new Formula { Id = "4_im03", Nome = "SNR", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "SNR=μ_sinal/σ_ruído", ExprTexto = "snr=mu/ sigma", Icone = "SNR", Descricao = "Relação sinal-ruído de imagem.", ExemploPratico = "Exemplo: μ=120 e σ=15 => SNR=8.", Variaveis = [ new() { Simbolo = "μ", Nome = "Média do sinal", ValorPadrao = 120, ValorMin = 0 }, new() { Simbolo = "σ", Nome = "Desvio do ruído", ValorPadrao = 15, ValorMin = 0.0001 } ], VariavelResultado = "SNR", UnidadeResultado = "", Calcular = vars => vars["μ"] / vars["σ"] },
            new Formula { Id = "4_im04", Nome = "PSNR", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "PSNR=20log10(Imax)-10log10(MSE)", ExprTexto = "psnr=20log10(Imax)-10log10(mse)", Icone = "PSNR", Descricao = "Qualidade de reconstrução por erro quadrático médio.", ExemploPratico = "Exemplo: Imax=4095 e MSE=25.", Variaveis = [ new() { Simbolo = "Imax", Nome = "Pico de intensidade", ValorPadrao = 4095, ValorMin = 1 }, new() { Simbolo = "MSE", Nome = "Erro quadrático médio", ValorPadrao = 25, ValorMin = 0.0001 } ], VariavelResultado = "PSNR", UnidadeResultado = "dB", Calcular = vars => 20 * Math.Log10(vars["Imax"]) - 10 * Math.Log10(vars["MSE"]) },
            new Formula { Id = "4_im05", Nome = "RMSE", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "RMSE=\u221a(MSE)", ExprTexto = "rmse=sqrt(mse)", Icone = "RMSE", Descricao = "Raiz do erro quadrático médio entre imagem reconstruída e referência.", ExemploPratico = "Exemplo: MSE=9 => RMSE=3.", Variaveis = [ new() { Simbolo = "MSE", Nome = "Erro quadrático médio", ValorPadrao = 9, ValorMin = 0 } ], VariavelResultado = "RMSE", UnidadeResultado = "", Calcular = vars => Math.Sqrt(vars["MSE"]) },
            new Formula { Id = "4_im06", Nome = "Amostragem em k-space", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "Δx=1/(N·Δk)", ExprTexto = "dx=1/(N*dk)", Icone = "k", Descricao = "Relação entre passo em frequência espacial e resolução de pixel em MRI.", ExemploPratico = "Exemplo: N=256, Δk=0.5 => Δx=0.0078125.", Variaveis = [ new() { Simbolo = "N", Nome = "Número de amostras N", ValorPadrao = 256, ValorMin = 1 }, new() { Simbolo = "Δk", Nome = "Passo em k-space", ValorPadrao = 0.5, ValorMin = 0.0001 } ], VariavelResultado = "Δx", UnidadeResultado = "", Calcular = vars => 1.0 / (vars["N"] * vars["Δk"]) },
            new Formula { Id = "4_im07", Nome = "Extensão de Campo de Visão", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "FOV=1/Δk", ExprTexto = "fov=1/dk", Icone = "FOV", Descricao = "Campo de visão determinado pela amostragem em k-space.", ExemploPratico = "Exemplo: Δk=0.4 => FOV=2.5.", Variaveis = [ new() { Simbolo = "Δk", Nome = "Passo em k-space", ValorPadrao = 0.4, ValorMin = 0.0001 } ], VariavelResultado = "FOV", UnidadeResultado = "", Calcular = vars => 1.0 / vars["Δk"] },
            new Formula { Id = "4_im08", Nome = "Sinal MRI (T1/T2)", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "S=M0(1-e^{-TR/T1})e^{-TE/T2}", ExprTexto = "S=M0*(1-exp(-TR/T1))*exp(-TE/T2)", Icone = "MRI", Descricao = "Modelo simplificado do sinal de spin-echo em MRI.", ExemploPratico = "Exemplo: M0=1000, TR=2000, T1=1000, TE=80, T2=100.", Variaveis = [ new() { Simbolo = "M0", Nome = "Magnetização M0", ValorPadrao = 1000, ValorMin = 0 }, new() { Simbolo = "TR", Nome = "Tempo de repetição TR", ValorPadrao = 2000, ValorMin = 0.001 }, new() { Simbolo = "T1", Nome = "Constante T1", ValorPadrao = 1000, ValorMin = 0.001 }, new() { Simbolo = "TE", Nome = "Tempo de eco TE", ValorPadrao = 80, ValorMin = 0.001 }, new() { Simbolo = "T2", Nome = "Constante T2", ValorPadrao = 100, ValorMin = 0.001 } ], VariavelResultado = "S", UnidadeResultado = "", Calcular = vars => vars["M0"] * (1 - Math.Exp(-vars["TR"] / vars["T1"])) * Math.Exp(-vars["TE"] / vars["T2"]) },
            new Formula { Id = "4_im09", Nome = "Tempo de Relaxamento Longitudinal", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "Mz(t)=M0(1-e^{-t/T1})", ExprTexto = "Mz=M0*(1-exp(-t/T1))", Icone = "T1", Descricao = "Recuperação da magnetização longitudinal em MRI.", ExemploPratico = "Exemplo: M0=1, t=1000, T1=800.", Variaveis = [ new() { Simbolo = "M0", Nome = "Magnetização de equilíbrio", ValorPadrao = 1 }, new() { Simbolo = "t", Nome = "Tempo t", ValorPadrao = 1000, ValorMin = 0 }, new() { Simbolo = "T1", Nome = "Constante T1", ValorPadrao = 800, ValorMin = 0.001 } ], VariavelResultado = "Mz", UnidadeResultado = "", Calcular = vars => vars["M0"] * (1 - Math.Exp(-vars["t"] / vars["T1"])) },
            new Formula { Id = "4_im10", Nome = "Tempo de Relaxamento Transversal", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "Mxy(t)=Mxy0e^{-t/T2}", ExprTexto = "Mxy=Mxy0*exp(-t/T2)", Icone = "T2", Descricao = "Decaimento da magnetização transversal em MRI.", ExemploPratico = "Exemplo: Mxy0=1, t=120, T2=90.", Variaveis = [ new() { Simbolo = "Mxy0", Nome = "Magnetização inicial", ValorPadrao = 1 }, new() { Simbolo = "t", Nome = "Tempo t", ValorPadrao = 120, ValorMin = 0 }, new() { Simbolo = "T2", Nome = "Constante T2", ValorPadrao = 90, ValorMin = 0.001 } ], VariavelResultado = "Mxy", UnidadeResultado = "", Calcular = vars => vars["Mxy0"] * Math.Exp(-vars["t"] / vars["T2"]) },
            new Formula { Id = "4_im11", Nome = "Resolução Espacial", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "Res=FOV/N", ExprTexto = "res=fov/N", Icone = "Res", Descricao = "Tamanho de voxel/pixel aproximado em uma dimensão.", ExemploPratico = "Exemplo: FOV=240, N=512 => 0.469.", Variaveis = [ new() { Simbolo = "FOV", Nome = "Campo de visão", ValorPadrao = 240, ValorMin = 0.001 }, new() { Simbolo = "N", Nome = "Número de amostras", ValorPadrao = 512, ValorMin = 1 } ], VariavelResultado = "Res", UnidadeResultado = "", Calcular = vars => vars["FOV"] / vars["N"] },
            new Formula { Id = "4_im12", Nome = "Janela de Intensidade", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "Iclip=min(max(I,L-W/2),L+W/2)", ExprTexto = "Iclip=clip(I,L-W/2,L+W/2)", Icone = "Win", Descricao = "Window/Level para visualização de tecidos em CT/MRI.", ExemploPratico = "Exemplo: I=250, L=100, W=300 => Iclip=250.", Variaveis = [ new() { Simbolo = "I", Nome = "Intensidade I", ValorPadrao = 250 }, new() { Simbolo = "L", Nome = "Nível L", ValorPadrao = 100 }, new() { Simbolo = "W", Nome = "Largura W", ValorPadrao = 300, ValorMin = 0.001 } ], VariavelResultado = "Iclip", UnidadeResultado = "", Calcular = vars => Math.Min(Math.Max(vars["I"], vars["L"] - vars["W"] / 2.0), vars["L"] + vars["W"] / 2.0) },
            new Formula { Id = "4_im13", Nome = "Coeficiente de Dice", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "Dice=2|A∩B|/(|A|+|B|)", ExprTexto = "dice=2*inter/(A+B)", Icone = "Dice", Descricao = "Métrica de sobreposição para segmentação médica.", ExemploPratico = "Exemplo: inter=80, A=100, B=90 => Dice≈0.842.", Variaveis = [ new() { Simbolo = "I", Nome = "Interseção |A∩B|", ValorPadrao = 80, ValorMin = 0 }, new() { Simbolo = "A", Nome = "Volume A", ValorPadrao = 100, ValorMin = 0.001 }, new() { Simbolo = "B", Nome = "Volume B", ValorPadrao = 90, ValorMin = 0.001 } ], VariavelResultado = "Dice", UnidadeResultado = "", Calcular = vars => 2 * vars["I"] / (vars["A"] + vars["B"]) },
            new Formula { Id = "4_im14", Nome = "Erro de Reconstrução", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "E=‖Irec-Iref‖₂/‖Iref‖₂", ExprTexto = "E=norm(Irec-Iref)/norm(Iref)", Icone = "Err", Descricao = "Erro relativo de reconstrução de imagem.", ExemploPratico = "Exemplo: num=12, den=80 => E=0.15.", Variaveis = [ new() { Simbolo = "num", Nome = "Norma do erro", ValorPadrao = 12, ValorMin = 0 }, new() { Simbolo = "den", Nome = "Norma de referência", ValorPadrao = 80, ValorMin = 0.0001 } ], VariavelResultado = "E", UnidadeResultado = "", Calcular = vars => vars["num"] / vars["den"] },
            new Formula { Id = "4_im15", Nome = "Tempo de Aquisição", Categoria = "Imagem Médica", SubCategoria = "Imagem Médica Geral", Expressao = "Tacq=TR·Nphase·NEX", ExprTexto = "Tacq=TR*Nphase*NEX", Icone = "Tacq", Descricao = "Estimativa de tempo de aquisição em sequências MRI.", ExemploPratico = "Exemplo: TR=0.6s, Nphase=256, NEX=2 => 307.2s.", Variaveis = [ new() { Simbolo = "TR", Nome = "TR (s)", ValorPadrao = 0.6, ValorMin = 0.0001 }, new() { Simbolo = "Nph", Nome = "Linhas de fase", ValorPadrao = 256, ValorMin = 1 }, new() { Simbolo = "NEX", Nome = "Médias NEX", ValorPadrao = 2, ValorMin = 1 } ], VariavelResultado = "Tacq", UnidadeResultado = "s", Calcular = vars => vars["TR"] * vars["Nph"] * vars["NEX"] },
            // 20.3 Biomecânica / Imagem Funcional
            new Formula
            {
                Id = "4_bm01", Nome = "Hiperelasticidade (Geral)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "S = ∂W/∂E;  P = ∂W/∂F (S=2°PK, P=1°PK)",
                ExprTexto = "S = ∂W/∂E; P = ∂W/∂F (tensores de PK)",
                Icone = "W",
                Descricao = "Materiais hiperelásticos: tensão derivada de potencial de energia de deformação W. S = 2º Piola-Kirchhoff, P = 1º PK, F = gradiente de deformação. Tecidos biológicos, elastômeros.",
                ExemploPratico = "Exemplo: Tensão S=100 MPa e energia de deformação W=50 MJ/m³ → qualidade ajuste ≈ 2.0 (adimensional)",
                Variaveis = [ new() { Simbolo = "S", Nome = "Tensão S (MPa)", ValorPadrao = 100 }, new() { Simbolo = "W", Nome = "Energia W (MJ/m³)", ValorPadrao = 50, ValorMin = 0.001 } ],
                VariavelResultado = "S/W",
                UnidadeResultado = "",
                Calcular = vars => vars["S"] / vars["W"]
            },
            new Formula
            {
                Id = "4_bm02", Nome = "Neo-Hookean", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "W = (μ/2)(I₁-3) + (κ/2)(J-1)²",
                ExprTexto = "W = (μ/2)(I₁−3)+(κ/2)(J−1)²",
                Icone = "NH",
                Descricao = "Modelo hiperelástico mais simples: μ = módulo de cisalhamento, κ = bulk modulus, I₁ = primeiro invariante de C, J = det(F). Boa para deformações ~30%. Base para modelos mais complexos.",
                ExemploPratico = "Exemplo: μ=0.5 MPa, I₁=5.0, κ=10 MPa, J=1.02 → W = 0.5×(5-3)/2 + 10×(1.02-1)²/2 ≈ 0.502 MJ/m³",
                Variaveis = [ new() { Simbolo = "μ", Nome = "Módulo cisalhamento μ (MPa)", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "I1", Nome = "1º invariante I₁", ValorPadrao = 5.0 }, new() { Simbolo = "κ", Nome = "Bulk modulus κ (MPa)", ValorPadrao = 10, ValorMin = 0.001 }, new() { Simbolo = "J", Nome = "det(F)=J", ValorPadrao = 1.02 } ],
                VariavelResultado = "W",
                UnidadeResultado = "MJ/m³",
                Calcular = vars => (vars["μ"] / 2.0) * (vars["I1"] - 3.0) + (vars["κ"] / 2.0) * Math.Pow(vars["J"] - 1.0, 2)
            },
            new Formula
            {
                Id = "4_bm03", Nome = "Mooney-Rivlin", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "W = C₁₀(I₁-3) + C₀₁(I₂-3)",
                ExprTexto = "W = C₁₀(Ī₁−3)+C₀₁(Ī₂−3)",
                Icone = "MR",
                Descricao = "Extensão de Neo-Hookean com segundo invariante I₂. Dois parâmetros materiais. Melhor ajuste para borrachas e tecidos moles para deformações moderadas (~100%).",
                Criador = "Melvin Mooney / Ronald Rivlin",
                ExemploPratico = "Exemplo: C₁₀=0.3 MPa, C₀₁=0.1 MPa, Ī₁=5.2, Ī₂=4.8 → W = 0.3×(5.2-3)+0.1×(4.8-3) = 0.84 MJ/m³",
                Variaveis = [ new() { Simbolo = "C10", Nome = "Parâmetro C₁₀ (MPa)", ValorPadrao = 0.3, ValorMin = 0 }, new() { Simbolo = "C01", Nome = "Parâmetro C₀₁ (MPa)", ValorPadrao = 0.1, ValorMin = 0 }, new() { Simbolo = "I1", Nome = "Invariante Ī₁", ValorPadrao = 5.2 }, new() { Simbolo = "I2", Nome = "Invariante Ī₂", ValorPadrao = 4.8 } ],
                VariavelResultado = "W",
                UnidadeResultado = "MJ/m³",
                Calcular = vars => vars["C10"] * (vars["I1"] - 3.0) + vars["C01"] * (vars["I2"] - 3.0)
            },
            new Formula
            {
                Id = "4_bm04", Nome = "Modelo de Ogden", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "W = Σₚ (μₚ/αₚ)(λ₁^αₚ + λ₂^αₚ + λ₃^αₚ - 3)",
                ExprTexto = "W = Σₚ(μₚ/αₚ)(λ₁^αₚ+λ₂^αₚ+λ₃^αₚ−3)",
                Icone = "Ogden",
                Descricao = "Modelo generalizado com N termos, cada um com (μₚ,αₚ). Ajusta bem dados experimentais de borracha até 700% deformação. Usual: N=3 (6 parâmetros).",
                Criador = "Raymond Ogden",
                AnoOrigin = "1972",
                ExemploPratico = "Exemplo: μ₁=1.2 MPa, α₁=2.5, λ₁=1.15, λ₂=0.95, λ₃=1.05 → W=1.2/2.5×((1.15^2.5+0.95^2.5+1.05^2.5)-3)≈0.18 MJ/m³",
                Variaveis = [ new() { Simbolo = "μ1", Nome = "Parâmetro μ₁ (MPa)", ValorPadrao = 1.2, ValorMin = 0 }, new() { Simbolo = "α1", Nome = "Expoente α₁", ValorPadrao = 2.5, ValorMin = 0.001 }, new() { Simbolo = "λ1", Nome = "Stretch λ₁", ValorPadrao = 1.15, ValorMin = 0.01 }, new() { Simbolo = "λ2", Nome = "Stretch λ₂", ValorPadrao = 0.95, ValorMin = 0.01 }, new() { Simbolo = "λ3", Nome = "Stretch λ₃", ValorPadrao = 1.05, ValorMin = 0.01 } ],
                VariavelResultado = "W",
                UnidadeResultado = "MJ/m³",
                Calcular = vars => (vars["μ1"] / vars["α1"]) * (Math.Pow(vars["λ1"], vars["α1"]) + Math.Pow(vars["λ2"], vars["α1"]) + Math.Pow(vars["λ3"], vars["α1"]) - 3.0)
            },
            new Formula
            {
                Id = "4_bm05", Nome = "Viscoelasticidade (Maxwell)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "σ + (η/E)σ̇ = η·ε̇  (série: mola+amortecedor)",
                ExprTexto = "σ+(η/E)σ̇ = ηε̇ (Maxwell)",
                Icone = "Mx",
                Descricao = "Material viscoelástico: relaxação exponencial σ(t)=σ₀e^{-t/τ}, τ=η/E. Fluido sob carga constante (creep ilimitado). Série de Maxwell: espectro de relaxação.",
                ExemploPratico = "Exemplo: E=50 MPa, η=10 MPa·s, ε̇=0.02 s⁻¹; tempo rel. τ=η/E=10/50=0.2 s",
                Variaveis = [ new() { Simbolo = "E", Nome = "Módulo elástico E (MPa)", ValorPadrao = 50, ValorMin = 0.001 }, new() { Simbolo = "η", Nome = "Viscosidade η (MPa·s)", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "τ",
                UnidadeResultado = "s",
                Calcular = vars => vars["η"] / vars["E"]
            },
            new Formula
            {
                Id = "4_bm06", Nome = "Viscoelasticidade (Kelvin-Voigt)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "σ = Eε + ηε̇  (paralelo: mola + amortecedor)",
                ExprTexto = "σ = Eε+ηε̇ (Kelvin-Voigt)",
                Icone = "KV",
                Descricao = "Sólido viscoelástico: creep limitado ε(t)=(σ₀/E)(1-e^{-t/τ}). Não relaxa tensão sob deformação constante. Modelo de tecidos biológicos sob carga cíclica.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Eε", Nome = "Eε", ValorPadrao = 10 }, new() { Simbolo = "ηε", Nome = "ηε", ValorPadrao = 5 } ],
                VariavelResultado = "σ",
                UnidadeResultado = "",
                Calcular = vars => vars["Eε"] + vars["ηε"]
            },
            new Formula
            {
                Id = "4_bm07", Nome = "Elastografia (Onda de Cisalhamento)", Categoria = "Imagem Médica", SubCategoria = "Biomecânica",
                Expressao = "E ≈ 3ρv²_s  (módulo de Young ≈ 3ρ·(vel. cisalhamento)²)",
                ExprTexto = "E ≈ 3ρvs²",
                Icone = "SWE",
                Descricao = "Imagem de rigidez tecidual via ultrassom: mede velocidade de onda de cisalhamento vs. E~3ρvs² (tecido mole ~incompressível). Fibrose hepática: F0~5kPa, F4~25kPa. Não-invasivo.",
                ExemploPratico = "Exemplo: Onda de cisalhamento vs=2.5 m/s, densidade ρ=1050 kg/m³ → E ≈ 3×1050×2.5² ≈ 19.7 kPa",
                Variaveis = [ new() { Simbolo = "ρ", Nome = "Densidade ρ (kg/m³)", ValorPadrao = 1050, ValorMin = 10 }, new() { Simbolo = "vs", Nome = "Velocidade vs (m/s)", ValorPadrao = 2.5, ValorMin = 0.1 } ],
                VariavelResultado = "E",
                UnidadeResultado = "kPa",
                Calcular = vars => 3.0 * vars["ρ"] * vars["vs"] * vars["vs"] / 1000.0
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 21. PSICOMETRIA E IRT
    // ─────────────────────────────────────────────────────
    private void AdicionarPsicometriaIRT()
    {
        _formulas.AddRange([
            // 21.1 Teoria da Resposta ao Item (IRT)
            new Formula
            {
                Id = "4_ir01", Nome = "Modelo Rasch (1PL)", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = e^{θ-b} / (1+e^{θ-b})",
                ExprTexto = "P(X=1|θ) = exp(θ−b)/(1+exp(θ−b))",
                Icone = "1PL",
                Descricao = "Modelo com um parâmetro: b = dificuldade do item. P=50% quando θ=b. Todos os itens igualmente discriminantes. Objetividade específica: comparação de pessoas independe dos itens.",
                Criador = "Georg Rasch",
                AnoOrigin = "1960",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade θ", ValorPadrao = 0.8 }, new() { Simbolo = "b", Nome = "Dificuldade b", ValorPadrao = 0.5 } ],
                VariavelResultado = "P(X=1|θ)",
                UnidadeResultado = "",
                Calcular = vars => 1.0 / (1.0 + Math.Exp(-(vars["θ"] - vars["b"])))
            },
            new Formula
            {
                Id = "4_ir02", Nome = "Modelo 2PL", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = 1 / (1+e^{-a(θ-b)})",
                ExprTexto = "P = 1/(1+exp(−a(θ−b)))",
                Icone = "2PL",
                Descricao = "Dois parâmetros: a = discriminação (inclinação), b = dificuldade. a alto → curva mais íngreme → item discrimina melhor entre θ vizinhos. Lord & Novick (1968).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade θ", ValorPadrao = 0.8 }, new() { Simbolo = "a", Nome = "Discriminação a", ValorPadrao = 1.2, ValorMin = 0.0001 }, new() { Simbolo = "b", Nome = "Dificuldade b", ValorPadrao = 0.5 } ],
                VariavelResultado = "P(X=1|θ)",
                UnidadeResultado = "",
                Calcular = vars => 1.0 / (1.0 + Math.Exp(-vars["a"] * (vars["θ"] - vars["b"])))
            },
            new Formula
            {
                Id = "4_ir03", Nome = "Modelo 3PL", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = c + (1-c) / (1+e^{-a(θ-b)})",
                ExprTexto = "P = c+(1−c)/(1+exp(−a(θ−b)))",
                Icone = "3PL",
                Descricao = "Três parâmetros: + c = pseudo-adivinhação (assíntota inferior). Para itens de múltipla escolha com k opções, c~1/k. Usado em testes adaptativos (CAT) e vestibulares.",
                Criador = "Allan Birnbaum",
                AnoOrigin = "1968",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade θ", ValorPadrao = 0.8 }, new() { Simbolo = "a", Nome = "Discriminação a", ValorPadrao = 1.2, ValorMin = 0.0001 }, new() { Simbolo = "b", Nome = "Dificuldade b", ValorPadrao = 0.5 }, new() { Simbolo = "c", Nome = "Pseudo-adivinhação c", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "P(X=1|θ)",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] + (1 - vars["c"]) / (1.0 + Math.Exp(-vars["a"] * (vars["θ"] - vars["b"])))
            },
            new Formula
            {
                Id = "4_ir04", Nome = "Modelo 4PL", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "P(X=1|θ) = c + (d-c) / (1+e^{-a(θ-b)})",
                ExprTexto = "P = c+(d−c)/(1+exp(−a(θ−b)))",
                Icone = "4PL",
                Descricao = "Quatro parâmetros: + d = assíntota superior (d<1: desatenção/erro em θ alto). Raramente usado na prática (sobreparametrizado). Modela comportamento de respondentes descuidados.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade θ", ValorPadrao = 0.8 }, new() { Simbolo = "a", Nome = "Discriminação a", ValorPadrao = 1.2, ValorMin = 0.0001 }, new() { Simbolo = "b", Nome = "Dificuldade b", ValorPadrao = 0.5 }, new() { Simbolo = "c", Nome = "Pseudo-adivinhação c", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "d", Nome = "Assíntota superior d", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "P(X=1|θ)",
                UnidadeResultado = "",
                Calcular = vars => vars["c"] + (vars["d"] - vars["c"]) / (1.0 + Math.Exp(-vars["a"] * (vars["θ"] - vars["b"])))
            },
            new Formula
            {
                Id = "4_ir05", Nome = "Função de Informação do Item", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "I(θ) = [P'(θ)]² / [P(θ)(1-P(θ))]",
                ExprTexto = "I(θ) = [P'(θ)]²/[P(θ)(1−P(θ))]",
                Icone = "I(θ)",
                Descricao = "Informação de Fisher para um item: quanta informação sobre θ o item fornece. Máxima em θ≈b. Para 2PL: I_max=a²/4 em θ=b. Base para seleção de itens em CAT.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "a", Nome = "Discriminação a", ValorPadrao = 1.3, ValorMin = 0.0001 }, new() { Simbolo = "P", Nome = "Probabilidade P", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "I(θ)",
                UnidadeResultado = "",
                Calcular = vars => vars["a"] * vars["a"] * vars["P"] * (1 - vars["P"])
            },
            new Formula
            {
                Id = "4_ir06", Nome = "Informação do Teste", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "I_test(θ) = Σᵢ Iᵢ(θ);  SE(θ) = 1/√I_test(θ)",
                ExprTexto = "Itest = ΣIᵢ(θ); SE=1/√Itest",
                Icone = "SE",
                Descricao = "Soma das informações dos itens (independência local). SE = erro padrão de medida: diminui com mais itens informativos naquele θ. Design de teste: maximizar I na faixa de θ desejada.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Itest", Nome = "Informação total", ValorPadrao = 16, ValorMin = 0.0001 } ],
                VariavelResultado = "SE(θ)",
                UnidadeResultado = "",
                Calcular = vars => 1.0 / Math.Sqrt(vars["Itest"])
            },
            new Formula
            {
                Id = "4_ir07", Nome = "Estimação MLE (θ̂)", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "θ̂ = argmax_θ Πᵢ Pᵢ(θ)^xᵢ (1-Pᵢ(θ))^{1-xᵢ}",
                ExprTexto = "θ̂ = argmax Π Pᵢ^xᵢ(1−Pᵢ)^{1−xᵢ}",
                Icone = "MLE",
                Descricao = "Máxima verossimilhança para estimar habilidade. Resolve ∂logL/∂θ=0 (Newton-Raphson). Não definido para scores perfeitos (0 ou n). Alternativa: EAP (Bayes com prior).",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade atual", ValorPadrao = 0.4 }, new() { Simbolo = "U", Nome = "Score U(θ)", ValorPadrao = 0.9 }, new() { Simbolo = "I", Nome = "Informação I(θ)", ValorPadrao = 6, ValorMin = 0.0001 } ],
                VariavelResultado = "θ̂_new",
                UnidadeResultado = "",
                Calcular = vars => vars["θ"] + vars["U"] / vars["I"]
            },
            new Formula
            {
                Id = "4_ir08", Nome = "DIF (Differential Item Functioning)", Categoria = "Psicometria e IRT", SubCategoria = "IRT",
                Expressao = "DIF: P(X=1|θ,grupo) ≠ P(X=1|θ)  (viés do item)",
                ExprTexto = "DIF: P(X=1|θ,g₁) ≠ P(X=1|θ,g₂)",
                Icone = "DIF",
                Descricao = "Item funciona diferentemente em grupos (sexo, etnia, etc.) controlando por θ. Uniforme (b difere) ou não-uniforme (a difere). Métodos: Mantel-Haenszel, logistic regression, LR IRT.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "P1", Nome = "P(X=1|θ,grupo1)", ValorPadrao = 0.72, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "P2", Nome = "P(X=1|θ,grupo2)", ValorPadrao = 0.61, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "|ΔP|",
                UnidadeResultado = "",
                Calcular = vars => Math.Abs(vars["P1"] - vars["P2"])
            },
            // 21.2 Psicometria (formas canônicas)
            new Formula { Id = "4_ps01", Nome = "Função Logística IRT", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "P(θ)=1/(1+e^{-a(θ-b)})", ExprTexto = "P=1/(1+exp(-a*(theta-b)))", Icone = "PS", Descricao = "Probabilidade de acerto com habilidade θ, discriminação a e dificuldade b.", ExemploPratico = "Exemplo: θ=0.8, a=1.2, b=0.5.", Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade θ", ValorPadrao = 0.8 }, new() { Simbolo = "a", Nome = "Discriminação a", ValorPadrao = 1.2, ValorMin = 0.001 }, new() { Simbolo = "b", Nome = "Dificuldade b", ValorPadrao = 0.5 } ], VariavelResultado = "P(θ)", UnidadeResultado = "", Calcular = vars => 1.0 / (1.0 + Math.Exp(-vars["a"] * (vars["θ"] - vars["b"]))) },
            new Formula { Id = "4_ps02", Nome = "Inclinação no Ponto b", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "P'(b)=a/4", ExprTexto = "dPdb = a/4", Icone = "a", Descricao = "No modelo 2PL, a inclinação máxima da curva logística é a/4.", ExemploPratico = "Exemplo: a=1.6 => 0.4.", Variaveis = [ new() { Simbolo = "a", Nome = "Discriminação a", ValorPadrao = 1.6, ValorMin = 0.001 } ], VariavelResultado = "P'(b)", UnidadeResultado = "", Calcular = vars => vars["a"] / 4.0 },
            new Formula { Id = "4_ps03", Nome = "Efeito de Dificuldade", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "ΔP≈a·Δθ/4 em θ≈b", ExprTexto = "dP approx a*dtheta/4", Icone = "b", Descricao = "Aproximação local do impacto de mudanças de habilidade perto de b.", ExemploPratico = "Exemplo: a=1.2 e Δθ=0.5 => ΔP≈0.15.", Variaveis = [ new() { Simbolo = "a", Nome = "a", ValorPadrao = 1.2 }, new() { Simbolo = "Δθ", Nome = "Variação de habilidade", ValorPadrao = 0.5 } ], VariavelResultado = "ΔP", UnidadeResultado = "", Calcular = vars => vars["a"] * vars["Δθ"] / 4.0 },
            new Formula { Id = "4_ps04", Nome = "Informação do Item (2PL)", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "I(θ)=a²P(1-P)", ExprTexto = "I=a^2*P*(1-P)", Icone = "Iθ", Descricao = "Informação de Fisher de um item no 2PL.", ExemploPratico = "Exemplo: a=1.3, P=0.7 => I≈0.355.", Variaveis = [ new() { Simbolo = "a", Nome = "a", ValorPadrao = 1.3 }, new() { Simbolo = "P", Nome = "Probabilidade P", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1 } ], VariavelResultado = "I(θ)", UnidadeResultado = "", Calcular = vars => vars["a"] * vars["a"] * vars["P"] * (1 - vars["P"]) },
            new Formula { Id = "4_ps05", Nome = "Erro Padrão da Habilidade", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "SE(θ)=1/\u221aI_test(θ)", ExprTexto = "SE=1/sqrt(Itest)", Icone = "SE", Descricao = "Erro padrão associado à estimativa de habilidade.", ExemploPratico = "Exemplo: Itest=16 => SE=0.25.", Variaveis = [ new() { Simbolo = "I", Nome = "Informação total", ValorPadrao = 16, ValorMin = 0.0001 } ], VariavelResultado = "SE", UnidadeResultado = "", Calcular = vars => 1.0 / Math.Sqrt(vars["I"]) },
            new Formula { Id = "4_ps06", Nome = "Atualização de Newton para θ", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "θ_{new}=θ+U(θ)/I(θ)", ExprTexto = "theta_new=theta+U/I", Icone = "NR", Descricao = "Passo de Newton-Raphson para MLE de habilidade.", ExemploPratico = "Exemplo: θ=0.4, U=0.9, I=6 => 0.55.", Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade atual", ValorPadrao = 0.4 }, new() { Simbolo = "U", Nome = "Score U(θ)", ValorPadrao = 0.9 }, new() { Simbolo = "I", Nome = "Informação I(θ)", ValorPadrao = 6, ValorMin = 0.0001 } ], VariavelResultado = "θ_new", UnidadeResultado = "", Calcular = vars => vars["θ"] + vars["U"] / vars["I"] },
            new Formula { Id = "4_ps07", Nome = "Índice de Dificuldade Médio", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "b̄=(1/m)Σb_i", ExprTexto = "bbar = mean(bi)", Icone = "b̄", Descricao = "Resumo da dificuldade global de um banco de itens.", ExemploPratico = "Exemplo: soma b=24 em m=30 itens => 0.8.", Variaveis = [ new() { Simbolo = "Σb", Nome = "Soma das dificuldades", ValorPadrao = 24 }, new() { Simbolo = "m", Nome = "Número de itens", ValorPadrao = 30, ValorMin = 1 } ], VariavelResultado = "b̄", UnidadeResultado = "", Calcular = vars => vars["Σb"] / vars["m"] },
            new Formula { Id = "4_ps08", Nome = "Discriminação Média", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "ā=(1/m)Σa_i", ExprTexto = "abar = mean(ai)", Icone = "ā", Descricao = "Resumo da capacidade de discriminação dos itens.", ExemploPratico = "Exemplo: Σa=42 em m=30 => 1.4.", Variaveis = [ new() { Simbolo = "Σa", Nome = "Soma das discriminações", ValorPadrao = 42 }, new() { Simbolo = "m", Nome = "Número de itens", ValorPadrao = 30, ValorMin = 1 } ], VariavelResultado = "ā", UnidadeResultado = "", Calcular = vars => vars["Σa"] / vars["m"] },
            new Formula { Id = "4_ps09", Nome = "Diferença de Habilidade (ITE Psic.)", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "ITE_i=Y_i(1)-Y_i(0)", ExprTexto = "ITE = Y1 - Y0", Icone = "ITE", Descricao = "Efeito individual (análogo causal) para mudança de intervenção educacional.", ExemploPratico = "Exemplo: Y1=0.82, Y0=0.65 => 0.17.", Variaveis = [ new() { Simbolo = "Y1", Nome = "Resultado com intervenção", ValorPadrao = 0.82 }, new() { Simbolo = "Y0", Nome = "Resultado sem intervenção", ValorPadrao = 0.65 } ], VariavelResultado = "ITE", UnidadeResultado = "", Calcular = vars => vars["Y1"] - vars["Y0"] },
            new Formula { Id = "4_ps10", Nome = "Efeito Médio (ATE Psic.)", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "ATE=(1/n)ΣITE_i", ExprTexto = "ATE = mean(ITE)", Icone = "ATE", Descricao = "Efeito médio da intervenção no desempenho psicométrico.", ExemploPratico = "Exemplo: soma ITE=12 com n=80 => 0.15.", Variaveis = [ new() { Simbolo = "ΣITE", Nome = "Soma dos ITE", ValorPadrao = 12 }, new() { Simbolo = "n", Nome = "Amostra n", ValorPadrao = 80, ValorMin = 1 } ], VariavelResultado = "ATE", UnidadeResultado = "", Calcular = vars => vars["ΣITE"] / vars["n"] },
            new Formula { Id = "4_ps11", Nome = "Parâmetro de Habilidade Padronizado", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "z=(θ-μ_θ)/σ_θ", ExprTexto = "z=(theta-mu)/sigma", Icone = "z", Descricao = "Padronização da habilidade para comparação entre grupos.", ExemploPratico = "Exemplo: θ=0.9, μ=0.5, σ=0.2 => z=2.", Variaveis = [ new() { Simbolo = "θ", Nome = "Habilidade θ", ValorPadrao = 0.9 }, new() { Simbolo = "μ", Nome = "Média μθ", ValorPadrao = 0.5 }, new() { Simbolo = "σ", Nome = "Desvio σθ", ValorPadrao = 0.2, ValorMin = 0.0001 } ], VariavelResultado = "z", UnidadeResultado = "", Calcular = vars => (vars["θ"] - vars["μ"]) / vars["σ"] },
            new Formula { Id = "4_ps12", Nome = "Função de Informação Agregada", Categoria = "Psicometria e IRT", SubCategoria = "Psicometria", Expressao = "I_total(θ)=Σ_j a_j²P_j(1-P_j)", ExprTexto = "Itotal=sum aj^2*Pj*(1-Pj)", Icone = "It", Descricao = "Resumo final da precisão do teste para um valor de θ.", ExemploPratico = "Exemplo: m=30, info média item=0.35 => Itotal=10.5.", Variaveis = [ new() { Simbolo = "m", Nome = "Número de itens", ValorPadrao = 30, ValorMin = 1 }, new() { Simbolo = "Ī", Nome = "Informação média por item", ValorPadrao = 0.35, ValorMin = 0 } ], VariavelResultado = "I_total", UnidadeResultado = "", Calcular = vars => vars["m"] * vars["Ī"] },
            // 21.2 SEM (Modelagem de Equações Estruturais)
            new Formula
            {
                Id = "4_sm01", Nome = "CFA (Análise Fatorial Confirmatória)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "x = Λξ + δ;  Σ = ΛΦΛ' + Θ",
                ExprTexto = "x=Λξ+δ; Σ=ΛΦΛ'+Θ",
                Icone = "CFA",
                Descricao = "Modelo de medida: x = indicadores observados, ξ = fatores latentes, Λ = cargas fatoriais, Φ = covariância entre fatores, Θ = variância dos erros. Confirma estrutura teórica.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Λξ", Nome = "Λξ", ValorPadrao = 10 }, new() { Simbolo = "δ", Nome = "δ", ValorPadrao = 5 } ],
                VariavelResultado = "x",
                UnidadeResultado = "",
                Calcular = vars => vars["Λξ"] + vars["δ"]
            },
            new Formula
            {
                Id = "4_sm02", Nome = "Modelo Estrutural (SEM)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "η = Bη + Γξ + ζ  (variáveis latentes endógenas)",
                ExprTexto = "η = Bη+Γξ+ζ",
                Icone = "SEM",
                Descricao = "Equações estruturais entre variáveis latentes: η = endógenas, ξ = exógenas, B = efeitos entre endógenas, Γ = efeitos de exógenas, ζ = distúrbios. Path analysis com latentes.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Bη", Nome = "Bη", ValorPadrao = 10 }, new() { Simbolo = "Γξ", Nome = "Γξ", ValorPadrao = 5 } ],
                VariavelResultado = "η",
                UnidadeResultado = "",
                Calcular = vars => vars["Bη"] + vars["Γξ"]
            },
            new Formula
            {
                Id = "4_sm03", Nome = "Equações de Medida (Completo)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "x = Λₓξ + δ  (exógenas);  y = Λᵧη + ε  (endógenas)",
                ExprTexto = "x=Λxξ+δ; y=Λyη+ε",
                Icone = "meas",
                Descricao = "Modelo completo LISREL: dois modelos de medida (x→ξ, y→η) + modelo estrutural (ξ→η). Estimação: ML, WLS, DWLS. Identificação: regra 3-indicadores ou marker variable.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "Λxξ", Nome = "Λxξ", ValorPadrao = 10 }, new() { Simbolo = "δ", Nome = "δ", ValorPadrao = 5 } ],
                VariavelResultado = "x",
                UnidadeResultado = "",
                Calcular = vars => vars["Λxξ"] + vars["δ"]
            },
            new Formula
            {
                Id = "4_sm04", Nome = "Índices de Ajuste (SEM)", Categoria = "Psicometria e IRT", SubCategoria = "SEM",
                Expressao = "CFI = 1-(χ²_m-df_m)/(χ²_0-df_0);  RMSEA = √((χ²/df-1)/N)",
                ExprTexto = "CFI, RMSEA, TLI, SRMR",
                Icone = "fit",
                Descricao = "CFI≥0.95 (comparativo), RMSEA≤0.06 (aproximação), SRMR≤0.08 (resíduos), TLI≥0.95. χ² = discrepância modelo vs dados. Hu & Bentler (1999): cutoffs combinados.",
                ExemploPratico = "Exemplo: substitua as variáveis pelos valores do seu cenário para obter o resultado numérico desta fórmula.",
                Variaveis = [ new() { Simbolo = "CFI", Nome = "CFI", ValorPadrao = 1 }, new() { Simbolo = "TLI", Nome = "TLI", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["CFI"] + vars["TLI"]
            },
        ]);
    }
}
