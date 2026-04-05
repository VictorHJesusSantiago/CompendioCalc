using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═════════════════════════════════════════════════════════════
    //  VOLUME 2 — PARTE II: FÍSICA AVANÇADA (COMPLETO)
    // ═════════════════════════════════════════════════════════════

    private void AdicionarFisicaAvancada()
    {
        AdicionarMecanicaLagrangianaCompleta();
        AdicionarMecanicaEstatisticaCompleta();
        AdicionarRelatividadeGeralCompleta();
    }

    // ─────────────────────────────────────────────────────
    // 7. MECÂNICA LAGRANGIANA E HAMILTONIANA COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarMecanicaLagrangianaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_ml01", Nome = "Lagrangiano L = T - V",
                Categoria = "Vol2: Mecânica Lagrangiana", SubCategoria = "Formalismo de Lagrange",
                Expressao = "L = T - V",
                ExprTexto = "L = T - V (energia cinética menos potencial)",
                Icone = "ℒ",
                Descricao = "O Lagrangiano é a diferença entre energia cinética T e energia potencial V. É a função fundamental do formalismo lagrangiano. A ação S=∫L dt é minimizada na trajetória real (Princípio de Hamilton).",
                Criador = "Joseph-Louis Lagrange",
                AnoOrigin = "1788",
                ExemploPratico = "Partícula livre: L=½mv² (sem potencial). Oscilador harmônico: L=½mẋ²-½kx². Pêndulo: L=½ml²θ̇²-mgl(1-cosθ). Partícula em campo gravitacional: L=½mv²-mgh.",
                Variaveis = [
                    new() { Simbolo = "T", Nome = "Energia Cinética T", Descricao = "Energia cinética do sistema", ValorPadrao = 10, ValorMin = 0, Unidade = "J" },
                    new() { Simbolo = "V", Nome = "Energia Potencial V", Descricao = "Energia potencial do sistema", ValorPadrao = 5, Unidade = "J" },
                ],
                VariavelResultado = "L",
                UnidadeResultado = "J",
                Calcular = vars => vars["T"] - vars["V"],
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_ml02", Nome = "Energia Cinética T = ½mv²",
                Categoria = "Vol2: Mecânica Lagrangiana", SubCategoria = "Formalismo de Lagrange",
                Expressao = "T = ½m·v²",
                ExprTexto = "T = ½ m v²",
                Icone = "ℒ",
                Descricao = "A energia cinética é a energia associada ao movimento. Para partícula de massa m e velocidade v. Para sistema de partículas: T=Σ½mᵢvᵢ². Em coordenadas generalizadas: T=½Σmᵢ(∂r/∂qⱼ·q̇ⱼ)².",
                Criador = "Gottfried Leibniz / Lagrange",
                AnoOrigin = "~1680",
                ExemploPratico = "Carro 1000 kg a 20 m/s: T=½·1000·400=200000 J=200 kJ. Bala 10 g a 800 m/s: T=½·0.01·640000=3200 J=3.2 kJ. Bola 0.5 kg a 10 m/s: T=25 J.",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa m", Descricao = "Massa da partícula", ValorPadrao = 1, ValorMin = 0.001, Unidade = "kg" },
                    new() { Simbolo = "v", Nome = "Velocidade v", Descricao = "Velocidade da partícula", ValorPadrao = 10, ValorMin = 0, Unidade = "m/s" },
                ],
                VariavelResultado = "T",
                UnidadeResultado = "J",
                Calcular = vars => 0.5 * vars["m"] * vars["v"] * vars["v"],
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_ml03", Nome = "Momento Generalizado pᵢ = ∂L/∂q̇ᵢ",
                Categoria = "Vol2: Mecânica Lagrangiana", SubCategoria = "Formalismo de Lagrange",
                Expressao = "pᵢ = ∂L/∂q̇ᵢ",
                ExprTexto = "pᵢ = ∂L/∂q̇ᵢ",
                Icone = "ℒ",
                Descricao = "O momento generalizado conjugado à coordenada qᵢ é a derivada parcial do Lagrangiano pela velocidade generalizada q̇ᵢ. Se qᵢ é cíclica (∂L/∂qᵢ=0), então pᵢ é conservado.",
                Criador = "Joseph-Louis Lagrange",
                AnoOrigin = "1788",
                ExemploPratico = "Partícula livre L=½mẋ²: p=∂L/∂ẋ=mẋ (momento linear clássico). Pêndulo L=½ml²θ̇²-...: p=ml²θ̇ (momento angular). Partícula em campo EM: p=mṙ+qA (momento canônico).",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa m", Descricao = "Massa", ValorPadrao = 1, ValorMin = 0.001, Unidade = "kg" },
                    new() { Simbolo = "v", Nome = "Velocidade q̇", Descricao = "Velocidade generalizada", ValorPadrao = 5, Unidade = "m/s" },
                ],
                VariavelResultado = "p",
                UnidadeResultado = "kg·m/s",
                Calcular = vars => vars["m"] * vars["v"],
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_mh01", Nome = "Hamiltoniano do Oscilador Harmônico",
                Categoria = "Vol2: Mecânica Lagrangiana", SubCategoria = "Formalismo Hamiltoniano",
                Expressao = "H = p²/(2m) + mω²q²/2",
                ExprTexto = "H = p²/(2m) + ½ mω² q²",
                Icone = "H",
                Descricao = "O Hamiltoniano do oscilador harmônico é a energia total E=T+V. A frequência angular ω=√(k/m) onde k é a constante elástica. Este sistema é fundamental em mecânica quântica e teoria de campos: energia quantizada Eₙ=ℏω(n+½).",
                Criador = "William Rowan Hamilton / Mecânica Quântica",
                AnoOrigin = "1833",
                ExemploPratico = "Massa-mola: m=1 kg, k=100 N/m → ω=10 rad/s. Se q=0.1 m e p=0: H=½·1·100·0.01=0.5 J. Para q=0 e p=1 kg·m/s: H=0.5 J (mesmo!). Mola ideal: E é constante.",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Momento p", Descricao = "Momento conjugado", ValorPadrao = 0, Unidade = "kg·m/s" },
                    new() { Simbolo = "m", Nome = "Massa m", Descricao = "Massa", ValorPadrao = 1, ValorMin = 0.001, Unidade = "kg" },
                    new() { Simbolo = "omega", Nome = "ω (freq. angular)", Descricao = "Frequência angular ω=√(k/m)", ValorPadrao = 10, ValorMin = 0.001, Unidade = "rad/s" },
                    new() { Simbolo = "q", Nome = "Posição q", Descricao = "Coordenada generalizada", ValorPadrao = 0.1, Unidade = "m" },
                ],
                VariavelResultado = "H",
                UnidadeResultado = "J",
                Calcular = vars => {
                    double p = vars["p"], m = vars["m"], omega = vars["omega"], q = vars["q"];
                    return (p * p) / (2 * m) + 0.5 * m * omega * omega * q * q;
                },
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_mh02", Nome = "Colchete de Poisson Canônico {qᵢ,pⱼ} = δᵢⱼ",
                Categoria = "Vol2: Mecânica Lagrangiana", SubCategoria = "Colchetes de Poisson",
                Expressao = "{qᵢ, pⱼ} = δᵢⱼ",
                ExprTexto = "{qᵢ, pⱼ} = δᵢⱼ (delta de Kronecker)",
                Icone = "{,}",
                Descricao = "Os colchetes de Poisson canônicos entre posição e momento são a base da mecânica hamiltoniana clássica. δᵢⱼ=1 se i=j, 0 caso contrário. Ao quantizar, {·,·}→(i/ℏ)[·,·] dá as relações de comutação quânticas.",
                Criador = "Siméon Denis Poisson",
                AnoOrigin = "1809",
                ExemploPratico = "{q,p}=1. {q,q}=0. {p,p}=0. Para momento angular: {Lₓ,Lᵧ}=Lᵧ. Quantização: [x̂,p̂]=iℏ (Heisenberg). Base da mecânica quântica.",
                Variaveis = [
                    new() { Simbolo = "i", Nome = "Índice i", Descricao = "Índice da coord. i", ValorPadrao = 1, ValorMin = 1, ValorMax = 3, Unidade = "" },
                    new() { Simbolo = "j", Nome = "Índice j", Descricao = "Índice do momento j", ValorPadrao = 1, ValorMin = 1, ValorMax = 3, Unidade = "" },
                ],
                VariavelResultado = "δᵢⱼ",
                UnidadeResultado = "",
                Calcular = vars => ((int)vars["i"] == (int)vars["j"]) ? 1.0 : 0.0,
                Unidades = "",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 8. MECÂNICA ESTATÍSTICA COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarMecanicaEstatisticaCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_me01", Nome = "Entropia de Boltzmann S = kB ln Ω",
                Categoria = "Vol2: Mecânica Estatística", SubCategoria = "Ensembles Estatísticos",
                Expressao = "S = kB · ln(Ω)",
                ExprTexto = "S = kB ln Ω",
                Icone = "S",
                Descricao = "A entropia de Boltzmann relaciona entropia termodinâmica S com o número de microestados Ω acessíveis ao sistema. kB=1.380649×10⁻²³ J/K é a constante de Boltzmann. Esculpida no túmulo de Boltzmann.",
                Criador = "Ludwig Boltzmann / Max Planck",
                AnoOrigin = "1877 / Formulação moderna 1900",
                ExemploPratico = "Sistema com 2 estados (Ω=2): S=kB·ln(2)≈0.96×10⁻²³ J/K. Sistema com 10²³ estados: S≈23kB≈32×10⁻²³ J/K. Gás ideal: Ω∝V^N → S aumenta com volume.",
                Variaveis = [
                    new() { Simbolo = "Omega", Nome = "Ω (microestados)", Descricao = "Número de microestados", ValorPadrao = 2, ValorMin = 1, Unidade = "" },
                    new() { Simbolo = "kB", Nome = "kB", Descricao = "Constante de Boltzmann", ValorPadrao = 1.380649e-23, Obrigatoria = false, Unidade = "J/K" },
                ],
                VariavelResultado = "S",
                UnidadeResultado = "J/K",
                Calcular = vars => vars["kB"] * Math.Log(vars["Omega"]),
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_me02", Nome = "Energia Livre de Helmholtz F = -kBT ln Z",
                Categoria = "Vol2: Mecânica Estatística", SubCategoria = "Ensembles Estatísticos",
                Expressao = "F = -kB·T · ln(Z)",
                ExprTexto = "F = -kB T ln Z",
                Icone = "F",
                Descricao = "A energia livre de Helmholtz F=E-TS é calculada da função de partição canônica Z. Sistemas em equilíbrio térmico minimizam F. Todas as propriedades termodinâmicas derivam de F(T,V,N).",
                Criador = "Hermann von Helmholtz",
                AnoOrigin = "1882",
                ExemploPratico = "Oscilador quântico: Z=1/(1-e^(-ℏω/(kBT))), F=-kBT·ln(Z)=kBT·ln(1-e^(-ℏω/(kBT)))+const. Gás ideal: F=-NkBT[ln(V/N)+3/2·ln(2πmkBT/h²)+1].",
                Variaveis = [
                    new() { Simbolo = "kB", Nome = "kB", Descricao = "Constante Boltzmann", ValorPadrao = 1.380649e-23, Unidade = "J/K" },
                    new() { Simbolo = "T", Nome = "Temperatura T", Descricao = "Temperatura absoluta", ValorPadrao = 300, ValorMin = 0.001, Unidade = "K" },
                    new() { Simbolo = "Z", Nome = "Z (função partição)", Descricao = "Função de partição canônica", ValorPadrao = 100, ValorMin = 1, Unidade = "" },
                ],
                VariavelResultado = "F",
                UnidadeResultado = "J",
                Calcular = vars => -vars["kB"] * vars["T"] * Math.Log(vars["Z"]),
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_me03", Nome = "Energia Média ⟨E⟩ = -∂ln(Z)/∂β",
                Categoria = "Vol2: Mecânica Estatística", SubCategoria = "Ensembles Estatísticos",
                Expressao = "⟨E⟩ = -∂ln(Z) / ∂β",
                ExprTexto = "⟨E⟩ = -∂ln(Z)/∂β, onde β=1/(kBT)",
                Icone = "⟨E⟩",
                Descricao = "A energia média é calculada da função de partição Z=Σexp(-βEᵢ) derivando em relação a β=1/(kBT). Equivalente a ⟨E⟩=ΣEᵢ·P(Eᵢ) onde P(Eᵢ)=e^(-βEᵢ)/Z (distribuição de Boltzmann).",
                Criador = "Josiah Willard Gibbs / Boltzmann",
                AnoOrigin = "~1880",
                ExemploPratico = "Sistema de 2 níveis (0 e ε): Z=1+e^(-βε). ⟨E⟩=ε/(e^(βε)+1). T→0: ⟨E⟩→0 (estado fundamental). T→∞: ⟨E⟩→ε/2 (energia média). T=ε/kB: ⟨E⟩≈0.27ε.",
                Variaveis = [
                    new() { Simbolo = "eps", Nome = "ε (energia nível)", Descricao = "Diferença de energia", ValorPadrao = 1e-20, ValorMin = 0.001, Unidade = "J" },
                    new() { Simbolo = "kB", Nome = "kB", Descricao = "Constante Boltzmann", ValorPadrao = 1.380649e-23, Unidade = "J/K" },
                    new() { Simbolo = "T", Nome = "Temperatura T", Descricao = "Temperatura", ValorPadrao = 300, ValorMin = 0.001, Unidade = "K" },
                ],
                VariavelResultado = "⟨E⟩",
                UnidadeResultado = "J",
                Calcular = vars => {
                    double eps = vars["eps"], beta = 1.0 / (vars["kB"] * vars["T"]);
                    return eps / (Math.Exp(beta * eps) + 1);
                },
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_me04", Nome = "Distribuição de Fermi-Dirac",
                Categoria = "Vol2: Mecânica Estatística", SubCategoria = "Estatísticas Quânticas",
                Expressao = "⟨nₛ⟩ = 1 / (e^(β(εₛ-μ)) + 1)",
                ExprTexto = "⟨nₛ⟩ = 1/(exp(β(εₛ-μ)) + 1)",
                Icone = "FD",
                Descricao = "A estatística de Fermi-Dirac descreve partículas de spin semi-inteiro (férmions: elétrons, prótons, neutrons). Princípio de exclusão de Pauli: máximo 1 partícula por estado. μ é o potencial químico, εₛ a energia do estado s.",
                Criador = "Enrico Fermi / Paul Dirac",
                AnoOrigin = "1926",
                ExemploPratico = "T=0: ⟨n⟩=1 se ε<μ, 0 se ε>μ (mar de Fermi). T>0: transição suave em ε≈μ. Metal a T ambiente: μ≈EF≈5 eV, kBT≈0.025 eV → distribuição quase degrau. Semicondutores: ocupação da banda de condução.",
                Variaveis = [
                    new() { Simbolo = "eps", Nome = "εₛ (energia estado)", Descricao = "Energia do estado s", ValorPadrao = 1e-19, Unidade = "J" },
                    new() { Simbolo = "mu", Nome = "μ (potencial químico)", Descricao = "Potencial químico (energia de Fermi)", ValorPadrao = 0.8e-19, Unidade = "J" },
                    new() { Simbolo = "kB", Nome = "kB", Descricao = "Constante Boltzmann", ValorPadrao = 1.380649e-23, Unidade = "J/K" },
                    new() { Simbolo = "T", Nome = "Temperatura T", Descricao = "Temperatura", ValorPadrao = 300, ValorMin = 0.001, Unidade = "K" },
                ],
                VariavelResultado = "⟨nₛ⟩",
                UnidadeResultado = "",
                Calcular = vars => {
                    double beta = 1.0 / (vars["kB"] * vars["T"]);
                    double exponent = beta * (vars["eps"] - vars["mu"]);
                    return 1.0 / (Math.Exp(exponent) + 1);
                },
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_me05", Nome = "Distribuição de Bose-Einstein",
                Categoria = "Vol2: Mecânica Estatística", SubCategoria = "Estatísticas Quânticas",
                Expressao = "⟨nₛ⟩ = 1 / (e^(β(εₛ-μ)) - 1)",
                ExprTexto = "⟨nₛ⟩ = 1/(exp(β(εₛ-μ)) - 1)",
                Icone = "BE",
                Descricao = "A estatística de Bose-Einstein descreve partículas de spin inteiro (bósons: fótons, fônons, átomos de He-4). Múltiplas partículas podem ocupar o mesmo estado. μ<min(εₛ) para evitar ocupação negativa. Condensação de Bose-Einstein ocorre quando μ→ε₀.",
                Criador = "Satyendra Nath Bose / Albert Einstein",
                AnoOrigin = "1924",
                ExemploPratico = "Fótons (μ=0, radiação corpo negro): ⟨n⟩=1/(e^(ℏω/(kBT))-1) (Planck). Fônons: calor específico de Debye. He-4 líquido <2.17 K: condensado de BE, superfluido. Lasers: ocupação macroscópica de estado único.",
                Variaveis = [
                    new() { Simbolo = "eps", Nome = "εₛ (energia estado)", Descricao = "Energia do estado s", ValorPadrao = 1e-20, Unidade = "J" },
                    new() { Simbolo = "mu", Nome = "μ (potencial químico)", Descricao = "Potencial químico", ValorPadrao = 0, Unidade = "J" },
                    new() { Simbolo = "kB", Nome = "kB", Descricao = "Constante Boltzmann", ValorPadrao = 1.380649e-23, Unidade = "J/K" },
                    new() { Simbolo = "T", Nome = "Temperatura T", Descricao = "Temperatura", ValorPadrao = 300, ValorMin = 0.001, Unidade = "K" },
                ],
                VariavelResultado = "⟨nₛ⟩",
                UnidadeResultado = "",
                Calcular = vars => {
                    double beta = 1.0 / (vars["kB"] * vars["T"]);
                    double exponent = beta * (vars["eps"] - vars["mu"]);
                    double denom = Math.Exp(exponent) - 1;
                    if (denom <= 0) return double.PositiveInfinity;
                    return 1.0 / denom;
                },
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_me06", Nome = "Energia de Fermi EF (gás de elétrons)",
                Categoria = "Vol2: Mecânica Estatística", SubCategoria = "Gás de Férmions",
                Expressao = "EF = (ℏ²/2m) · (3π²n)^(2/3)",
                ExprTexto = "EF = (ℏ²/2m)(3π²n)^(2/3)",
                Icone = "EF",
                Descricao = "A energia de Fermi é a energia do maior nível ocupado a T=0 K em um gás degenerado de férmions. n=N/V é a densidade. Todos os estados com E<EF estão ocupados, E>EF vazios. Fundamental em física de metais e matéria degenerada (anãs brancas).",
                Criador = "Enrico Fermi / Sommerfeld",
                AnoOrigin = "~1926",
                ExemploPratico = "Cu (n≈8.5×10²⁸ e⁻/m³): EF≈7 eV≈1.1×10⁻¹⁸ J. vF≈1.6×10⁶ m/s (velocidade de Fermi). TF=EF/kB≈81000 K (temperatura de Fermi). Anã branca: EF≈1 MeV (relativístico).",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "n (densidade)", Descricao = "Densidade eletrônica (elétrons/m³)", ValorPadrao = 8.5e28, ValorMin = 1e20, Unidade = "1/m³" },
                    new() { Simbolo = "hbar", Nome = "ℏ", Descricao = "Constante de Planck reduzida", ValorPadrao = 1.054571817e-34, Obrigatoria = false, Unidade = "J·s" },
                    new() { Simbolo = "m", Nome = "m (massa)", Descricao = "Massa do elétron", ValorPadrao = 9.1093837015e-31, Obrigatoria = false, Unidade = "kg" },
                ],
                VariavelResultado = "EF",
                UnidadeResultado = "J",
                Calcular = vars => {
                    double hbar = vars["hbar"], m = vars["m"], n = vars["n"];
                    return (hbar * hbar / (2 * m)) * Math.Pow(3 * Math.PI * Math.PI * n, 2.0 / 3.0);
                },
                Unidades = "",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 10. RELATIVIDADE GERAL COMPLETA
    // ─────────────────────────────────────────────────────
    private void AdicionarRelatividadeGeralCompleta()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "v2_rg01", Nome = "Raio de Schwarzschild rs = 2GM/c²",
                Categoria = "Vol2: Relatividade Geral", SubCategoria = "Buracos Negros",
                Expressao = "rs = 2GM / c²",
                ExprTexto = "rs = 2GM/c²",
                Icone = "⚫",
                Descricao = "O raio de Schwarzschild define o horizonte de eventos de um buraco negro esférico não-rotacionante. Dentro de rs, nada pode escapar, nem mesmo luz. Para M☉ (massa solar): rs≈3 km. Para Terra: rs≈9 mm (hipotético).",
                Criador = "Karl Schwarzschild",
                AnoOrigin = "1916",
                ExemploPratico = "Sol (M=1.989×10³⁰ kg): rs=2·6.674×10⁻¹¹·1.989×10³⁰/(9×10¹⁶)≈2953 m≈3 km. Terra: rs≈8.9 mm. M87* (buraco negro supermassivo, ~6.5×10⁹ M☉): rs≈19.2 bilhões km≈128 UA.",
                Variaveis = [
                    new() { Simbolo = "M", Nome = "Massa M", Descricao = "Massa do objeto", ValorPadrao = 1.989e30, ValorMin = 1, Unidade = "kg" },
                    new() { Simbolo = "G", Nome = "G", Descricao = "Constante gravitacional", ValorPadrao = 6.67430e-11, Obrigatoria = false, Unidade = "m³/(kg·s²)" },
                    new() { Simbolo = "c", Nome = "c", Descricao = "Velocidade da luz", ValorPadrao = 299792458, Obrigatoria = false, Unidade = "m/s" },
                ],
                VariavelResultado = "rs",
                UnidadeResultado = "m",
                Calcular = vars => 2 * vars["G"] * vars["M"] / (vars["c"] * vars["c"]),
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_rg02", Nome = "Temperatura de Hawking TH",
                Categoria = "Vol2: Relatividade Geral", SubCategoria = "Radiação de Hawking",
                Expressao = "TH = ℏc³ / (8πGMkB)",
                ExprTexto = "TH = ℏc³/(8πGMkB)",
                Icone = "⚫",
                Descricao = "Buracos negros não são completamente negros: emitem radiação térmica (radiação de Hawking) com temperatura TH. Quanto menor o buraco negro, maior a temperatura. Buracos negros estelares: TH≈10⁻⁷ K. Micro buracos negros: podem evaporar explosivamente.",
                Criador = "Stephen Hawking",
                AnoOrigin = "1974",
                ExemploPratico = "M☉: TH≈6.2×10⁻⁸ K (extremamente frio!). M = 10⁶ kg (hipotético pequeno): TH≈1.2×10¹¹ K. Tempo de evaporação: t∝M³, então BN estelares levam 10⁶⁷ anos para evaporar (>>>idade do universo).",
                Variaveis = [
                    new() { Simbolo = "M", Nome = "Massa M", Descricao = "Massa do buraco negro", ValorPadrao = 1.989e30, ValorMin = 1, Unidade = "kg" },
                    new() { Simbolo = "hbar", Nome = "ℏ", Descricao = "Constante de Planck reduzida", ValorPadrao = 1.054571817e-34, Obrigatoria = false, Unidade = "J·s" },
                    new() { Simbolo = "c", Nome = "c", Descricao = "Velocidade da luz", ValorPadrao = 299792458, Obrigatoria = false, Unidade = "m/s" },
                    new() { Simbolo = "G", Nome = "G", Descricao = "Constante gravitacional", ValorPadrao = 6.67430e-11, Obrigatoria = false, Unidade = "m³/(kg·s²)" },
                    new() { Simbolo = "kB", Nome = "kB", Descricao = "Constante de Boltzmann", ValorPadrao = 1.380649e-23, Obrigatoria = false, Unidade = "J/K" },
                ],
                VariavelResultado = "TH",
                UnidadeResultado = "K",
                Calcular = vars => {
                    double hbar = vars["hbar"], c = vars["c"], G = vars["G"], M = vars["M"], kB = vars["kB"];
                    return (hbar * c * c * c) / (8 * Math.PI * G * M * kB);
                },
                Unidades = "",
            },

            new Formula
            {
                Id = "v2_rg03", Nome = "Desvio para o Vermelho Gravitacional z",
                Categoria = "Vol2: Relatividade Geral", SubCategoria = "Efeitos Gravitacionais",
                Expressao = "νobs / νemit = √(1 - 2GM/(rc²))",
                ExprTexto = "ν_obs/ν_emit = √(1 - rs/r)",
                Icone = "⚫",
                Descricao = "Luz escapando de campo gravitacional perde energia (redshift gravitacional). Relógios em potencial gravitacional mais profundo correm mais devagar (dilatação temporal gravitacional). GPS corrige este efeito (+45.9 μs/dia na Terra).",
                Criador = "Albert Einstein / Robert Pound & Glen Rebka (confirmação)",
                AnoOrigin = "1915 (teoria) / 1959 (experimento Pound-Rebka)",
                ExemploPratico = "Na superfície da Terra (r=R_Terra, M=M_Terra): Δν/ν≈GM/(r c²)≈7×10⁻¹⁰ (pequeno). Anã branca: z≈10⁻⁴. Perto de BN (r=2rs): z→∞ (redshift infinito no horizonte).",
                Variaveis = [
                    new() { Simbolo = "M", Nome = "Massa M", Descricao = "Massa do objeto", ValorPadrao = 5.972e24, Unidade = "kg" },
                    new() { Simbolo = "r", Nome = "r (distância)", Descricao = "Distância do centro", ValorPadrao = 6.371e6, ValorMin = 1, Unidade = "m" },
                    new() { Simbolo = "G", Nome = "G", Descricao = "Constante gravitacional", ValorPadrao = 6.67430e-11, Obrigatoria = false, Unidade = "m³/(kg·s²)" },
                    new() { Simbolo = "c", Nome = "c", Descricao = "Velocidade da luz", ValorPadrao = 299792458, Obrigatoria = false, Unidade = "m/s" },
                ],
                VariavelResultado = "ν_obs/ν_emit",
                UnidadeResultado = "",
                Calcular = vars => {
                    double rs = 2 * vars["G"] * vars["M"] / (vars["c"] * vars["c"]);
                    if (vars["r"] <= rs) return 0; // Dentro do horizonte
                    return Math.Sqrt(1 - rs / vars["r"]);
                },
                Unidades = "",
            },
        ]);
    }
}
