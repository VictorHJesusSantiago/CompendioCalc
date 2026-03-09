using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME IX - PARTE III: FÍSICA ESTATÍSTICA E MATÉRIA CONDENSADA
    /// Distribuições quânticas, BEC, supercondutividade, fases da matéria
    /// Fórmulas 043-063 (21 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private Formula V9_PHYS043_DistribuicaoFermiDirac() => new Formula
        {
            Id = "V9-PHYS043", CodigoCompendio = "043", Nome = "Distribuição de Fermi-Dirac",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "f(E) = 1/(exp((E−μ)/(k_B·T)) + 1)",
            ExprTexto = "Ocupação de estados fermiônicos (elétrons, quarks)",
            Descricao = "Estatística de Fermi-Dirac: probabilidade de ocupação de estado de energia E por férmions (spin semi-inteiro, Pauli exclusion). μ potencial químico, k_B constante de Boltzmann. T→0: degrau em E=E_F (nível de Fermi). Explica condutividade metálica, estrelas de nêutrons, degenerescência eletrônica.",
            Criador = "Enrico Fermi (1926, On the Quantization of the Monoatomic Ideal Gas); Paul Dirac (1926, independente)",
            AnoOrigin = "1926",
            ExemploPratico = "Metal a T=300K: E_F≈5eV, k_B T≈0.026eV → transição estreita. Estrela de nêutrons: degenerescência extrema mantém colapso gravitacional. Semicondutores: distribuição controla densidade de portadores n=∫f(E)g(E)dE.",
            Unidades = "probabilidade",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "E", Nome = "Energia", Unidade = "eV", ValorPadrao = 5.0, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "mu", Nome = "Potencial químico μ", Unidade = "eV", ValorPadrao = 4.8, Obrigatoria = true },
                new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300, ValorMin = 0.1, Obrigatoria = true }
            },
            Calcular = v => { const double k_B = 8.617e-5; return 1.0 / (Math.Exp((v["E"] - v["mu"]) / (k_B * v["T"])) + 1.0); },
            VariavelResultado = "f(E)", UnidadeResultado = "probabilidade"
        };

        private Formula V9_PHYS044_DistribuicaoBoseEinstein() => new Formula
        {
            Id = "V9-PHYS044", CodigoCompendio = "044", Nome = "Distribuição de Bose-Einstein",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "n(E) = 1/(exp((E−μ)/(k_B·T)) − 1)",
            ExprTexto = "Ocupação de estados bosônicos (fótons, fonons)",
            Descricao = "Estatística de Bose-Einstein: número médio de bósons (spin inteiro) no estado de energia E. Sem exclusão de Pauli: múltiplos bósons no mesmo estado. μ<E sempre. T→0 e μ→0: condensação de Bose-Einstein (BEC). Descreve radiação térmica, hélio superfluido.",
            Criador = "Satyendra Nath Bose (1924, artigo sobre fótons); Albert Einstein (1924-25, generalização para átomos)",
            AnoOrigin = "1924",
            ExemploPratico = "Fótons (μ=0): distribuição de Planck n(ω)=1/(e^{ℏω/k_B T}−1). Fonons: calor específico Debye. BEC em ^87Rb a T<170nK (Cornell-Wieman 1995 Nobel 2001): macroscopic occupation do ground state.",
            Unidades = "número médio",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "E", Nome = "Energia", Unidade = "eV", ValorPadrao = 0.001, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "mu", Nome = "Potencial químico μ", Unidade = "eV", ValorPadrao = 0, ValorMax = 0.001, Obrigatoria = true },
                new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 1, ValorMin = 0.01, Obrigatoria = true }
            },
            Calcular = v => { const double k_B = 8.617e-5; return 1.0 / (Math.Exp((v["E"] - v["mu"]) / (k_B * v["T"])) - 1.0); },
            VariavelResultado = "n(E)", UnidadeResultado = "número médio"
        };

        private Formula V9_PHYS045_TemperaturaCriticaBEC() => new Formula
        {
            Id = "V9-PHYS045", CodigoCompendio = "045", Nome = "Temperatura Crítica de BEC",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "T_c = (2πℏ²/m·k_B)·(n/ζ(3/2))^(2/3)",
            ExprTexto = "BEC ocorre abaixo de T_c para densidade n",
            Descricao = "Temperatura crítica de condensação de Bose-Einstein: abaixo de T_c, fração macroscópica de bósons ocupa estado fundamental (momento zero). Depende de densidade n e massa m. ζ(3/2)≈2.612 função zeta de Riemann. Fenômeno quântico macroscópico: coerência de fase em escala humana.",
            Criador = "Albert Einstein (1924-25, predição teórica BEC); Cornell-Wieman-Ketterle (1995, observação experimental Nobel 2001)",
            AnoOrigin = "1924",
            ExemploPratico = "^87Rb com n=10^14 cm⁻³, m≈87u: T_c≈170nK. ^23Na: T_c≈2μK. Hélio-4 superfluido: T_λ=2.17K (transição lambda). Átomos ultra-frios: laser cooling + evaporative cooling atingem T<T_c.",
            Unidades = "K",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "n", Nome = "Densidade", Unidade = "m⁻³", ValorPadrao = 1e20, ValorMin = 1e10, Obrigatoria = true },
                new Variavel { Simbolo = "m", Nome = "Massa atômica", Unidade = "kg", ValorPadrao = 1.44e-25, ValorMin = 1e-27, Obrigatoria = true }
            },
            Calcular = v => { const double hbar = 1.055e-34; const double k_B = 1.381e-23; const double zeta = 2.612; return (2 * Math.PI * hbar * hbar / (v["m"] * k_B)) * Math.Pow(v["n"] / zeta, 2.0 / 3.0); },
            VariavelResultado = "T_c", UnidadeResultado = "K"
        };

        private Formula V9_PHYS046_EquacaoGrossPitaevskii() => new Formula
        {
            Id = "V9-PHYS046", CodigoCompendio = "046", Nome = "Equação de Gross-Pitaevskii",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "iℏ∂ψ/∂t = [−ℏ²∇²/(2m) + V + g|ψ|²]ψ",
            ExprTexto = "Equação de Schrödinger não-linear para BEC",
            Descricao = "Equação de Gross-Pitaevskii: descreve dinâmica de condensado de Bose-Einstein via função de onda macroscópica ψ(r,t). Termo não-linear g|ψ|² (mean-field) representa interações entre átomos via scattering length a (g=4πℏ²a/m). Soluções: vórtices, solitons, breathing modes.",
            Criador = "Eugene Gross (1961); Lev Pitaevskii (1961, independente)",
            AnoOrigin = "1961",
            ExemploPratico = "BEC aprisionado: V(r)=½mω²r² (trap harmônico) → perfil Thomas-Fermi |ψ|²∝max(0,μ−V). Vórtices: ψ=f(r)e^{iθ} quantização circulação. Solitons escuros em BEC 1D. g>0: repulsivo (^87Rb); g<0: atrativo (^7Li, instável).",
            Unidades = "ψ tem dim √(densidade)",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "g", Nome = "Parâmetro interação", Unidade = "J·m³", ValorPadrao = 1e-37, Obrigatoria = true },
                new Variavel { Simbolo = "n_peak", Nome = "Densidade pico |ψ|²", Unidade = "m⁻³", ValorPadrao = 1e20, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => v["g"] * v["n_peak"], // energia de interação
            VariavelResultado = "g·n", UnidadeResultado = "J/m³"
        };

        private Formula V9_PHYS047_ModeloIsing() => new Formula
        {
            Id = "V9-PHYS047", CodigoCompendio = "047", Nome = "Modelo de Ising",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "H = −J·Σ_{⟨ij⟩} S_i·S_j − h·Σ_i S_i",
            ExprTexto = "Hamiltoniano de spins S_i=±1 em rede",
            Descricao = "Modelo de Ising: sistema de spins S_i=±1 em rede com acoplamento ferromagnético J>0. H Hamiltoniano, ⟨ij⟩ vizinhos próximos, h campo externo. Transição de fase ferromagnética em T_c. Solução exata 2D (Onsager 1944). Modelo paradigmático de mecânica estatística: universalidade, expoentes críticos.",
            Criador = "Ernst Ising (1925, tese doutorado 1D - sem transição); Lars Onsager (1944, solução exata 2D Nobel 1968)",
            AnoOrigin = "1925",
            ExemploPratico = "Ising 2D: T_c=(2J/k_B)/ln(1+√2)≈2.269J/k_B. Magnetização espontânea M∝(T_c−T)^β com β=1/8. Correlação ξ∝|T−T_c|^{−ν}, ν=1. 3D: simulação Monte Carlo, T_c≈4.51J/k_B. Aplicações: ferromagnetismo, ligas binárias, redes neurais (Hopfield).",
            Unidades = "J (energia)",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "J", Nome = "Acoplamento", Unidade = "J", ValorPadrao = 1e-21, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "N_vizinhos", Nome = "Pares vizinhos alinhados", Unidade = "contagem", ValorPadrao = 100, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "h", Nome = "Campo externo", Unidade = "J", ValorPadrao = 0, Obrigatoria = true },
                new Variavel { Simbolo = "M", Nome = "Magnetização total", Unidade = "spin total", ValorPadrao = 50, Obrigatoria = true }
            },
            Calcular = v => -v["J"] * v["N_vizinhos"] - v["h"] * v["M"],
            VariavelResultado = "Energia H", UnidadeResultado = "J"
        };

        private Formula V9_PHYS048_TeoriaLandau() => new Formula
        {
            Id = "V9-PHYS048", CodigoCompendio = "048", Nome = "Teoria de Landau - Transições de Fase",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "F = a(T−T_c)M² + b·M⁴ − h·M",
            ExprTexto = "Energia livre como função do parâmetro de ordem M",
            Descricao = "Teoria fenomenológica de Landau: energia livre F expandida em potências do parâmetro de ordem M (ex: magnetização). Transição de fase em T_c onde coef a muda sinal. Segunda ordem: mínimo em M≠0 para T<T_c (quebra espontânea de simetria). b>0 estabilidade. h campo conjugado. Universalidade: expoentes críticos independem de detalhes microscópicos.",
            Criador = "Lev Landau (1937, teoria fenomenológica de transições de fase; Nobel Física 1962)",
            AnoOrigin = "1937",
            ExemploPratico = "Ferromagnetismo: M magnetização, T_c Curie. Superfluid He: M parâmetro de ordem complexo. Supercondutividade: teoria Ginzburg-Landau (1950) extensão. Equilíbrio: ∂F/∂M=0 → 2a(T−T_c)M+4bM³−h=0. Transição 1ª ordem: b<0 (descontinuidade em M).",
            Unidades = "J",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "a", Nome = "Coef quadrático", Unidade = "J", ValorPadrao = 1e-3, Obrigatoria = true },
                new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 290, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "T_c", Nome = "Temp crítica", Unidade = "K", ValorPadrao = 300, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "M", Nome = "Parâmetro ordem", Unidade = "adim", ValorPadrao = 0.5, Obrigatoria = true },
                new Variavel { Simbolo = "b", Nome = "Coef quártico", Unidade = "J", ValorPadrao = 1e-2, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "h", Nome = "Campo conjugado", Unidade = "J", ValorPadrao = 0, Obrigatoria = true }
            },
            Calcular = v => v["a"] * (v["T"] - v["T_c"]) * v["M"] * v["M"] + v["b"] * Math.Pow(v["M"], 4) - v["h"] * v["M"],
            VariavelResultado = "Energia livre F", UnidadeResultado = "J"
        };

        // Continua com as fórmulas 049-063 (mais 15 fórmulas)...
        private Formula V9_PHYS049_ExpoentesCriticos() => new Formula
        {
            Id = "V9-PHYS049", CodigoCompendio = "049", Nome = "Expoentes Críticos e Relações de Escala",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "γ = β(δ−1); α+2β+γ=2 (Rushbrooke)",
            ExprTexto = "Relações universais entre expoentes críticos",
            Descricao = "Expoentes críticos: descrevem comportamento de observáveis próximo à transição T_c. α (calor específico), β (parâmetro ordem), γ (susceptibilidade), δ (isoterma crítica), ν (comprimento correlação). Relações de escala (Widom 1965, scaling hypothesis): conectam expoentes, reduzem de 6 a 2 independentes. Universalidade: mesmos expoentes para classes de simetria.",
            Criador = "Benjamin Widom (1965, scaling hypothesis); Leo Kadanoff (1966, block spin); relações Rushbrooke (1963), Griffith, etc.",
            AnoOrigin = "1963",
            ExemploPratico = "Ising 2D: α=0 (log), β=1/8, γ=7/4, δ=15, ν=1. Ising 3D: α≈0.11, β≈0.327, γ≈1.237. Mean-field (d>4): α=0, β=½, γ=1, δ=3 (valores clássicos Landau). Hiperescala: dν=2−α.",
            Unidades = "adimensional",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "beta", Nome = "Expoente β", Unidade = "adim", ValorPadrao = 0.125, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "delta", Nome = "Expoente δ", Unidade = "adim", ValorPadrao = 15, ValorMin = 1, Obrigatoria = true }
            },
            Calcular = v => v["beta"] * (v["delta"] - 1.0), // γ = β(δ−1)
            VariavelResultado = "Expoente γ", UnidadeResultado = "adimensional"
        };

        private Formula V9_PHYS050_GrupoRenormalizacaoWilson() => new Formula
        {
            Id = "V9-PHYS050", CodigoCompendio = "050", Nome = "Grupo de Renormalização de Wilson",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "dg/dl = β(g); ponto fixo β(g*)=0",
            ExprTexto = "Fluxo de constantes de acoplamento com escala",
            Descricao = "Grupo de renormalização (RG): framework de Wilson (1971) para entender transições de fase via transformações de escala. Função β(g) descreve como acoplamento g muda com escala l. Pontos fixos g* (β=0): correspondem a fases ou pontos críticos. Linearização: expoentes críticos de autovalores. ε-expansion: perturbação em d=4−ε dimensões.",
            Criador = "Kenneth Wilson (1971, Renormalization Group and Critical Phenomena; Nobel 1982)",
            AnoOrigin = "1971",
            ExemploPratico = "Modelo φ⁴: β(λ)=(ε/6)λ−(λ²/2) para d=4−ε. Ponto fixo λ*=ε/3 (não-trivial). Expoentes críticos: η=(ε²/54)+O(ε³). Ising em campo: crossover de Ising para mean-field com campo relevante. QCD: freedom assintótica β(g)<0.",
            Unidades = "adimensional",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "epsilon", Nome = "ε = 4−d", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 4, Obrigatoria = true },
                new Variavel { Simbolo = "lambda", Nome = "Acoplamento λ", Unidade = "adim", ValorPadrao = 0.333, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => { double eps = v["epsilon"]; double lam = v["lambda"]; return (eps / 6.0) * lam - (lam * lam) / 2.0; }, // β(λ)
            VariavelResultado = "β(λ)", UnidadeResultado = "adimensional"
        };

        private Formula V9_PHYS051_TeoriaBCS() => new Formula
        {
            Id = "V9-PHYS051", CodigoCompendio = "051", Nome = "Teoria BCS de Supercondutividade",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "Δ = ℏω_D·exp(−1/(N(0)·V)); 2Δ = gap superconductor",
            ExprTexto = "Gap de energia BCS para pares de Cooper",
            Descricao = "Teoria BCS (Bardeen-Cooper-Schrieffer): explicação microscópica da supercondutividade via formação de pares de Cooper (elétrons com momentos opostos ligados por interação fônon-mediada). Gap Δ em densidade de estados, 2Δ energia para quebrar par. N(0) densidade de estados no nível de Fermi, V interação atrativa, ω_D frequência de Debye.",
            Criador = "John Bardeen, Leon Cooper, Robert Schrieffer (1957, Theory of Superconductivity; Nobel 1972)",
            AnoOrigin = "1957",
            ExemploPratico = "Al: T_c=1.2K, 2Δ(0)≈3.5k_B T_c (razão universal BCS). Pb: T_c=7.2K. Relação T_c: k_B T_c≈1.13ℏω_D exp(−1/λ) onde λ=N(0)V. Isotope effect: T_c∝M^{−α}, α≈0.5 confirma mecanismo fônon. Alto-T_c cupratos: mecanismo não-BCS (d-wave pairing).",
            Unidades = "eV",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "hbar_omega_D", Nome = "ℏω_D", Unidade = "eV", ValorPadrao = 0.03, ValorMin = 0.001, Obrigatoria = true },
                new Variavel { Simbolo = "N_0", Nome = "N(0)", Unidade = "estados/eV", ValorPadrao = 1e23, ValorMin = 1e20, Obrigatoria = true },
                new Variavel { Simbolo = "V", Nome = "Interação V", Unidade = "eV", ValorPadrao = 1e-24, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => v["hbar_omega_D"] * Math.Exp(-1.0 / (v["N_0"] * v["V"])),
            VariavelResultado = "Gap Δ", UnidadeResultado = "eV"
        };

        private Formula V9_PHYS052_EfeitoMeissnerLondon() => new Formula
        {
            Id = "V9-PHYS052", CodigoCompendio = "052", Nome = "Efeito Meissner e Equação de London",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "∇²B = B/λ_L²; λ_L = √(m/(μ₀·n_s·e²))",
            ExprTexto = "Expulsão de campo magnético em supercondutor",
            Descricao = "Efeito Meissner: expulsão completa de campo magnético do interior de supercondutor abaixo T_c (diamagnetismo perfeito). Equação de London: penetração exponencial B∝exp(−x/λ_L) com profundidade λ_L (comprimento de penetração de London). n_s densidade de superelétrons. Tipo I: expulsão total; Tipo II: vórtices de Abrikosov para H>H_c1.",
            Criador = "Walther Meissner e Robert Ochsenfeld (1933, descoberta experimental); Fritz e Heinz London (1935, equação fenomenológica)",
            AnoOrigin = "1933",
            ExemploPratico = "Pb: λ_L≈40nm. Nb: λ_L≈50nm. Levitação magnética: repulsão Meissner permite trens maglev supercondutores. SQUID: interferência quântica via loop supercondutor. Tipo II (Nb-Ti, YBCO): rede de vórtices entre H_c1 e H_c2.",
            Unidades = "m",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "m", Nome = "Massa elétron", Unidade = "kg", ValorPadrao = 9.109e-31, Obrigatoria = true },
                new Variavel { Simbolo = "n_s", Nome = "Densidade superelétrons", Unidade = "m⁻³", ValorPadrao = 1e28, ValorMin = 1e25, Obrigatoria = true },
                new Variavel { Simbolo = "e", Nome = "Carga elétron", Unidade = "C", ValorPadrao = 1.602e-19, Obrigatoria = true }
            },
            Calcular = v => { const double mu0 = 1.257e-6; return Math.Sqrt(v["m"] / (mu0 * v["n_s"] * v["e"] * v["e"])); },
            VariavelResultado = "Comprimento London λ_L", UnidadeResultado = "m"
        };

        private Formula V9_PHYS053_EfeitoHallQuantico() => new Formula
        {
            Id = "V9-PHYS053", CodigoCompendio = "053", Nome = "Efeito Hall Quântico",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "R_xy = h/(ν·e²); ν∈ℤ (inteiro) ou fracionário",
            ExprTexto = "Quantização precisa de resistência Hall",
            Descricao = "Efeito Hall quântico inteiro (IQHE): resistência Hall R_xy quantizada em platôs R_K/ν onde R_K=h/e²≈25812.8Ω constante de von Klitzing, ν fator de preenchimento (níveis de Landau). Precisão 10^{−10} define padrão de resistência. Efeito Hall quântico fracionário (FQHE): ν=p/q (Laughlin 1983), quasipartículas anyônicas.",
            Criador = "Klaus von Klitzing (1980, descoberta IQHE; Nobel 1985); Tsui-Störmer-Laughlin (1982 FQHE; Nobel 1998)",
            AnoOrigin = "1980",
            ExemploPratico = "GaAs/AlGaAs heterostructure 2DEG a T<4K, B≈10T: platôs em ν=1,2,3,... Resistência: R_xy(ν=1)=25812.807Ω exatamente. FQHE: ν=1/3, 2/5, 5/2 (estado não-abeliano). Metrologia: R_K define Ohm desde 1990.",
            Unidades = "Ω",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "nu", Nome = "Fator preenchimento ν", Unidade = "adim", ValorPadrao = 1, ValorMin = 0.1, Obrigatoria = true }
            },
            Calcular = v => { const double h = 6.626e-34; const double e = 1.602e-19; return h / (v["nu"] * e * e); },
            VariavelResultado = "Resistência Hall R_xy", UnidadeResultado = "Ω"
        };

        private Formula V9_PHYS054_DiracHamiltonianoGraphene() => new Formula
        {
            Id = "V9-PHYS054", CodigoCompendio = "054", Nome = "Hamiltoniano de Dirac do Grafeno",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "H = ℏv_F(k_x·σ_x + k_y·σ_y); E = ±ℏv_F|k|",
            ExprTexto = "Férmions de Dirac sem massa em grafeno",
            Descricao = "Hamiltoniano efetivo de grafeno próximo aos pontos de Dirac K,K': descreve quasipartículas como férmions de Dirac relativísticos sem massa com velocidade de Fermi v_F≈c/300. σ_x,σ_y matrizes de Pauli (pseudospin de subrede). Dispersão linear E=±ℏv_F|k|. Responsável por propriedades eletrônicas exóticas: condutividade mínima, efeito Klein tunneling.",
            Criador = "P.R. Wallace (1947, cálculo band structure grafite); Novoselov-Geim (2004, isolação grafeno Nobel 2010)",
            AnoOrigin = "1947",
            ExemploPratico = "Mobilidade v_F≈10^6 m/s. Condutividade mínima σ_min≈4e²/(πh)≈4·10^{−5} S mesmo em neutralidade de carga. Klein paradox tunneling: transmissão perfeita através de barreiras. Aplicações: transistores, sensores, eletrônica flexível.",
            Unidades = "eV",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "v_F", Nome = "Velocidade Fermi", Unidade = "m/s", ValorPadrao = 1e6, Obrigatoria = true },
                new Variavel { Simbolo = "k", Nome = "Vetor onda |k|", Unidade = "m⁻¹", ValorPadrao = 1e9, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => { const double hbar = 1.055e-34; const double eV = 1.602e-19; return hbar * v["v_F"] * v["k"] / eV; },
            VariavelResultado = "Energia E", UnidadeResultado = "eV"
        };

        // Fórmulas 055-063 continuam o mesmo padrão...
        private Formula V9_PHYS055_TeoremaBloch() => new Formula
        {
            Id = "V9-PHYS055", CodigoCompendio = "055", Nome = "Teorema de Bloch",
            Categoria = "Volume IX", SubCategoria = "Física do Estado Sólido",
            Expressao = "ψ_{n,k}(r) = e^{ik·r}·u_{n,k}(r)",
            ExprTexto = "Função de onda em cristal = onda plana × função periódica",
            Descricao = "Teorema de Bloch: em potencial periódico V(r+R)=V(r), autofunções têm forma ψ_{n,k}=e^{ik·r}u_{n,k}(r) onde u periódica (mesma periodicidade da rede). k vetor de onda em zona de Brillouin, n banda. Implica estrutura de bandas E_n(k). Base da física do estado sólido.",
            Criador = "Felix Bloch (1929, tese doutorado Über die Quantenmechanik der Elektronen in Kristallgittern; Nobel 1952)",
            AnoOrigin = "1928",
            ExemploPratico = "Elétrons em cristal: bandas E_n(k) separadas por gaps. Metais: banda parcialmente preenchida. Isolantes/semicondutores: gap entre valência e condução. Zona de Brillouin: célula primitiva do espaço recíproco. Velocidade grupo v=∇_k E_n(k)/ℏ.",
            Unidades = "função de onda",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "k", Nome = "Vetor onda", Unidade = "m⁻¹", ValorPadrao = 1e9, Obrigatoria = true },
                new Variavel { Simbolo = "x", Nome = "Posição", Unidade = "m", ValorPadrao = 1e-9, Obrigatoria = true }
            },
            Calcular = v => Math.Cos(v["k"] * v["x"]), // parte real onda plana
            VariavelResultado = "Re[e^{ikx}]", UnidadeResultado = "adimensional"
        };

        private Formula V9_PHYS056_ModeloHubbard() => new Formula
        {
            Id = "V9-PHYS056", CodigoCompendio = "056", Nome = "Modelo de Hubbard",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "H = −t·Σ_{⟨ij⟩,σ}(c†_{iσ}c_{jσ}+h.c.) + U·Σ_i n_{i↑}n_{i↓}",
            ExprTexto = "Hopping cinético (t) + repulsão Coulomb on-site (U)",
            Descricao = "Modelo de Hubbard: modelo minimal de elétrons correlacionados em rede. Termo hopping −t permite saltos entre sítios vizinhos. Termo Hubbard U penaliza dupla ocupação (repulsão Coulomb). Competição t vs U controla transição metal-isolante de Mott. Paradigma para cupratos supercondutores de alto-T_c.",
            Criador = "John Hubbard (1963); Martin Gutzwiller (1963); Junjiro Kanamori (1963) - independentes",
            AnoOrigin = "1963",
            ExemploPratico = "t≫U: metal (elétrons delocalizados). U≫t: isolante de Mott (elétrons localizados, AF). Half-filling: competição cria fase antiferromagnética. Cupratos La₂CuO₄: isolante AF, dopagem → supercondutor. Átomos ultrafrios em optical lattices simulam Hubbard tunável.",
            Unidades = "eV",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "t", Nome = "Hopping t", Unidade = "eV", ValorPadrao = 0.5, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "U", Nome = "Repulsão U", Unidade = "eV", ValorPadrao = 4.0, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "n_hopping", Nome = "Termos hopping", Unidade = "contagem", ValorPadrao = 4, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "n_doubly_occupied", Nome = "Sítios dupla ocupação", Unidade = "contagem", ValorPadrao = 2, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => -v["t"] * v["n_hopping"] + v["U"] * v["n_doubly_occupied"],
            VariavelResultado = "Energia Hubbard", UnidadeResultado = "eV"
        };

        private Formula V9_PHYS057_IsoladorTopologico() => new Formula
        {
            Id = "V9-PHYS057", CodigoCompendio = "057", Nome = "Isolador Topológico - Invariante Z₂",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "ν = 0 (trivial) ou 1 (topológico); estados de superfície protegidos",
            ExprTexto = "Fase topológica com estados metálicos de superfície",
            Descricao = "Isolador topológico: fase isolante no bulk, mas estados metálicos protegidos na superfície/borda devido a topologia não-trivial da estrutura de bandas. Invariante Z₂ ν distingue trivial (0) de topológico (1). Cônico de Dirac na superfície, protegido por simetria time-reversal. Descoberta teórica Kane-Mele 2005, experimental Bi₂Se₃ 2008.",
            Criador = "Kane-Mele (2005, modelo grafeno com SOC); Fu-Kane (2007, classificação Z₂); Zhang grupo (2008, experimental Bi₂Se₃)",
            AnoOrigin = "2005",
            ExemploPratico = "Bi₂Se₃, Bi₂Te₃: isoladores topológicos 3D. Superfície: férmions de Dirac com spin-momentum locking (spin ⊥ momentum). HgTe quantum wells: isolador topológico 2D (QSH). Aplicações: spintrônica, computação quântica topológica (Majorana fermions).",
            Unidades = "adimensional",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "nu", Nome = "Invariante Z₂", Unidade = "adim", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = v => v["nu"], // 0=trivial, 1=topológico
            VariavelResultado = "ν invariante", UnidadeResultado = "Z₂ (0 ou 1)"
        };

        private Formula V9_PHYS058_CalorEspecificoDebye() => new Formula
        {
            Id = "V9-PHYS058", CodigoCompendio = "058", Nome = "Calor Específico de Debye",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "C_V = 9Nk_B(T/T_D)³·∫₀^{T_D/T} (x⁴e^x/(e^x−1)²)dx",
            ExprTexto = "C_V ~ T³ para T≪T_D (baixa temperatura)",
            Descricao = "Modelo de Debye: aproxima espectro de fonons por densidade de estados Debye com frequência limite ω_D. Temperatura de Debye T_D=ℏω_D/k_B caracteriza rigidez da rede. Baixa T: C_V∝T³ (lei T-cubed). Alta T: Dulong-Petit C_V→3Nk_B. Melhor que Einstein para baixas temperaturas.",
            Criador = "Peter Debye (1912, Zur Theorie der spezifischen Wärmen; Nobel Química 1936)",
            AnoOrigin = "1912",
            ExemploPratico = "Diamante: T_D≈2230K (ligações fortes). Pb: T_D≈105K (macio). Limite T→0: C_V=(12π⁴/5)Nk_B(T/T_D)³. Metais: adiciona termo eletrônico γT (Sommerfeld): C_V=γT+βT³.",
            Unidades = "J/K",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "N", Nome = "Número átomos", Unidade = "átomos", ValorPadrao = 1e23, ValorMin = 1, Obrigatoria = true },
                new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 50, ValorMin = 0.1, Obrigatoria = true },
                new Variavel { Simbolo = "T_D", Nome = "Temp Debye", Unidade = "K", ValorPadrao = 300, ValorMin = 10, Obrigatoria = true }
            },
            Calcular = v => { const double k_B = 1.381e-23; double ratio = v["T"] / v["T_D"]; return 12.0 * Math.PI * Math.PI * Math.PI * Math.PI * v["N"] * k_B * ratio * ratio * ratio / 5.0; }, // aproximação T³
            VariavelResultado = "C_V Debye", UnidadeResultado = "J/K"
        };

        private Formula V9_PHYS059_TeoriaWeissCampoMolecular() => new Formula
        {
            Id = "V9-PHYS059", CodigoCompendio = "059", Nome = "Teoria de Weiss - Campo Molecular",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "M = Nμ_B·tanh(μ_B·H_eff/(k_B·T)); H_eff=H+λM",
            ExprTexto = "Magnetização via campo molecular efetivo",
            Descricao = "Teoria de Weiss: aproximação de campo médio para ferromagnetismo. Campo efetivo H_eff=H+λM inclui campo externo H e campo molecular λM proporcional à magnetização. Equação autoconsistente para M. Transição ferromagnética em T_c=Nμ_B²λ/k_B (Curie). Lei de Curie-Weiss χ=C/(T−T_c) acima de T_c.",
            Criador = "Pierre Weiss (1907, L'hypothèse du champ moléculaire et la propriété ferromagnétique)",
            AnoOrigin = "1907",
            ExemploPratico = "Fe: T_c≈1043K, M_sat≈2.2μ_B/atom. Ni: T_c≈627K. Equação M transcendental resolve iterativamente ou graficamente. Acima T_c: susceptibilidade χ=M/H=C/(T−T_c) diverge. Abaixo T_c: magnetização espontânea M₀≠0.",
            Unidades = "A/m",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "N", Nome = "Densidade spins", Unidade = "m⁻³", ValorPadrao = 1e28, ValorMin = 1e20, Obrigatoria = true },
                new Variavel { Simbolo = "mu_B", Nome = "Magneton Bohr", Unidade = "A·m²", ValorPadrao = 9.274e-24, Obrigatoria = true },
                new Variavel { Simbolo = "H", Nome = "Campo externo", Unidade = "A/m", ValorPadrao = 1e5, Obrigatoria = true },
                new Variavel { Simbolo = "lambda", Nome = "Campo molecular λ", Unidade = "adim", ValorPadrao = 1e3, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 300, ValorMin = 0.1, Obrigatoria = true }
            },
            Calcular = v => { const double k_B = 1.381e-23; double M_guess = 1e5; double H_eff = v["H"] + v["lambda"] * M_guess; double M = v["N"] * v["mu_B"] * Math.Tanh(v["mu_B"] * H_eff / (k_B * v["T"])); return M; },
            VariavelResultado = "Magnetização M", UnidadeResultado = "A/m"
        };

        private Formula V9_PHYS060_CalorEspecificoEletronico() => new Formula
        {
            Id = "V9-PHYS060", CodigoCompendio = "060", Nome = "Calor Específico Eletrônico - Sommerfeld",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "C_e = γT; γ = π²k_B²N(E_F)/3",
            ExprTexto = "Contribuição eletrônica ~ T (linear)",
            Descricao = "Modelo de Sommerfeld: gás de elétrons livres com estatística de Fermi. Calor específico eletrônico C_e proporcional a T (linear) devido a excitações próximas ao nível de Fermi. γ coeficiente Sommerfeld, proporcional à densidade de estados no nível de Fermi N(E_F). Muito menor que contribuição fonônica 3Nk_B exceto a baixíssimas T.",
            Criador = "Arnold Sommerfeld (1927, Zur Elektronentheorie der Metalle)",
            AnoOrigin = "1927",
            ExemploPratico = "Cu: γ≈0.695 mJ/(mol·K²). Na: γ≈1.38 mJ/(mol·K²). Baixa T: C_total=γT+βT³ (elétrons+fonons). Plot C/T vs T²: intercepto γ, slope β. Supercondutores: salto em γ na transição T_c (gap Δ).",
            Unidades = "J/K",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "gamma", Nome = "Coef Sommerfeld γ", Unidade = "J/(K²)", ValorPadrao = 0.0007, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 10, ValorMin = 0.1, Obrigatoria = true }
            },
            Calcular = v => v["gamma"] * v["T"],
            VariavelResultado = "C_e eletrônico", UnidadeResultado = "J/K"
        };

        private Formula V9_PHYS061_EquacaoSahaIonizacao() => new Formula
        {
            Id = "V9-PHYS061", CodigoCompendio = "061", Nome = "Equação de Saha - Ionização em Plasmas",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "n_e·n_i/n_a = (2πm_e k_B T/h²)^{3/2}·exp(−χ/(k_B T))",
            ExprTexto = "Equilíbrio ionização térmica em plasma",
            Descricao = "Equação de Saha: relaciona densidades de elétrons n_e, íons n_i e átomos neutros n_a em equilíbrio térmico. χ energia de ionização. Alta T ou baixa densidade favorecem ionização. Fundamental em astrofísica: determina grau de ionização em atmosferas estelares, classifica espectros (Harvard OBAFGKM).",
            Criador = "Meghnad Saha (1920, On a Physical Theory of Stellar Spectra)",
            AnoOrigin = "1920",
            ExemploPratico = "Sol fotosfera T≈5800K: H parcialmente ionizado. Interiores estelares T>10^6K: completamente ionizado (plasma). Nebulosas HII: ionização por radiação UV de estrelas massivas. Tokamaks fusão: plasma completamente ionizado T>10^8K.",
            Unidades = "m⁻⁶",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "T", Nome = "Temperatura", Unidade = "K", ValorPadrao = 10000, ValorMin = 1000, Obrigatoria = true },
                new Variavel { Simbolo = "chi", Nome = "Energia ionização", Unidade = "J", ValorPadrao = 2.18e-18, ValorMin = 0, Obrigatoria = true }
            },
            Calcular = v => { const double m_e = 9.109e-31; const double k_B = 1.381e-23; const double h = 6.626e-34; return Math.Pow(2 * Math.PI * m_e * k_B * v["T"] / (h * h), 1.5) * Math.Exp(-v["chi"] / (k_B * v["T"])); },
            VariavelResultado = "n_e·n_i/n_a", UnidadeResultado = "m⁻⁶"
        };

        private Formula V9_PHYS062_SupercondutividadeAltoTc() => new Formula
        {
            Id = "V9-PHYS062", CodigoCompendio = "062", Nome = "Supercondutividade de Alto-T_c",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "J(ρ=0) se B<H_c e T<T_c; cupratos T_c>77K",
            ExprTexto = "Supercondutor acima de 77K (N₂ líquido), mecanismo não-BCS",
            Descricao = "Supercondutores de alto-T_c: cupratos (óxidos de cobre) com T_c>77K (N₂ líquido), recorde YBCO T_c≈93K (1987), Hg-1223 T_c≈133K (pressão ambiente). Mecanismo não-BCS: pairing via spin fluctuations (?), simetria d-wave (not s-wave). Diagrama de fases complexo: pseudogap, strange metal. Aplicações práticas viáveis (cabos, magnetos).",
            Criador = "Bednorz-Müller (1986, La-Ba-Cu-O T_c≈35K Nobel 1987); Chu-Wu (1987, YBCO T_c≈93K)",
            AnoOrigin = "1986",
            ExemploPratico = "YBa₂Cu₃O₇ (YBCO): T_c≈93K, resfriamento com N₂ líquido barato. Bi-2223 fitas: condutores comerciais para magnetos MRI, geradores. Hidrides sob alta pressão: LaH₁₀ T_c≈250K a 170GPa (2019), mas pressão impraticável. Pesquisa contínua por temperatura ambiente.",
            Unidades = "K",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "T_c", Nome = "Temp crítica", Unidade = "K", ValorPadrao = 93, ValorMin = 77, Obrigatoria = true }
            },
            Calcular = v => v["T_c"],
            VariavelResultado = "T_c alto-T_c", UnidadeResultado = "K"
        };

        private Formula V9_PHYS063_TransicaoMottIsolante() => new Formula
        {
            Id = "V9-PHYS063", CodigoCompendio = "063", Nome = "Transição Metal-Isolante de Mott",
            Categoria = "Volume IX", SubCategoria = "Física Estatística",
            Expressao = "U/W > (U/W)_c ≈ 1 → Isolante de Mott",
            ExprTexto = "Correlações Coulomb (U) superam largura banda (W) → isolante",
            Descricao = "Transição de Mott: material que teoria de banda única (Bloch) prevê metálico torna-se isolante devido a strong on-site Coulomb repulsion U. Critério Mott-Hubbard: U/W>1 (U repulsão, W largura banda). Elétrons localizados, gap de Mott, ordem antiferromagnética. Desafia paradigma de banda, exige tratamento de many-body.",
            Criador = "Nevill Mott (1949, The Basis of the Electron Theory of Metals, with Special Reference to the Transition Metals; Nobel 1977)",
            AnoOrigin = "1949",
            ExemploPratico = "NiO: 3d⁸ deve ser metálico (banda parcialmente preenchida), mas é isolante AF (U≈7eV > W≈4eV). V₂O₃: transição metal-isolante ajustável com pressão/dopagem. Cupratos: dopagem de isolante Mott gera supercondutividade. Computational challenge: DMFT, QMC.",
            Unidades = "adimensional",
            Variaveis = new List<Variavel>
            {
                new Variavel { Simbolo = "U", Nome = "Repulsão Coulomb", Unidade = "eV", ValorPadrao = 7, ValorMin = 0, Obrigatoria = true },
                new Variavel { Simbolo = "W", Nome = "Largura banda", Unidade = "eV", ValorPadrao = 4, ValorMin = 0.1, Obrigatoria = true }
            },
            Calcular = v => { double ratio = v["U"] / v["W"]; return ratio > 1.0 ? 1.0 : 0.0; }, // 1=isolante, 0=metal
            VariavelResultado = "Fase Mott", UnidadeResultado = "bool (1=isolante)"
        };
    }
}
