using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE II
    /// NANOTECNOLOGIA E MICRO/NANOELETRÔNICA
    /// Fórmulas V10-022 a V10-041 (20 fórmulas)
    /// Efeitos quânticos em nanoscala, dispositivos nanoeletrônicos e materiais
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_Nanotechnology()
        {
            _formulas.AddRange(new List<Formula>
            {
                // V10-022: Tunelamento Quântico
                new Formula
                {
                    Id = "3610",
                    CodigoCompendio = "V10-022",
                    Nome = "Probabilidade de Tunelamento Quântico",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Efeitos Quânticos",
                    Expressao = @"T ≈ exp(−2κa); κ = √(2m(V−E))/ℏ",
                    Descricao = "Coeficiente de transmissão através de barreira potencial. κ: parâmetro de decaimento. Transistor de tunelamento (RTD) usa este efeito. STM (microscópio tunelamento) mede corrente dependente de T.",
                    ExemploPratico = "Barreira 1nm, V−E=1eV: T≈e^−10≈4×10^−5. Flash memory: tunelamento através de óxido fino. Josephson junction: par Cooper tunela, supercondutividade.",
                    Criador = "Equação de Schrödinger; Fowler-Nordheim (1928, field emission)",
                    AnoOrigin = "1928",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Largura barreira a (nm)", Simbolo = "a", Unidade = "nm", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Altura barreira V-E (eV)", Simbolo = "ΔV", Unidade = "eV", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Massa efetiva/m_e", Simbolo = "m/m_e", Unidade = "", ValorPadrao = 0.067, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double a_nm = inputs["Largura barreira a (nm)"];
                        double deltaV_eV = inputs["Altura barreira V-E (eV)"];
                        double massa_rel = inputs["Massa efetiva/m_e"];
                        
                        // Constantes
                        double hbar = 1.054571817e-34; // J·s
                        double m_e = 9.1093837015e-31; // kg
                        double eV = 1.602176634e-19; // J
                        
                        // Converter unidades
                        double a_m = a_nm * 1e-9;
                        double deltaV_J = deltaV_eV * eV;
                        double massa = massa_rel * m_e;
                        
                        // Parâmetro de decaimento κ
                        double kappa = Math.Sqrt(2 * massa * deltaV_J) / hbar;
                        
                        // Coeficiente de transmissão (aproximação WKB)
                        double expoente = -2 * kappa * a_m;
                        double T = Math.Exp(Math.Max(expoente, -100)); // Limitar para evitar underflow
                        
                        // Corrente de tunelamento proporcional a T
                        double corrente_relativa = T;
                        
                        return T;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-023: Comprimento de Penetração de London
                new Formula
                {
                    Id = "3611",
                    CodigoCompendio = "V10-023",
                    Nome = "Comprimento de Penetração de London",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Supercondutividade",
                    Expressao = @"λ_L = √(m/(μ₀n_s e²))",
                    Descricao = "Profundidade de penetração de campo magnético em supercondutor. n_s: densidade de pares Cooper. Para Nb (nióbio): λ_L≈40nm a T=0. Efeito Meissner expulsa campo além de λ_L.",
                    ExemploPratico = "Filme fino Nb (<40nm): não supercondutor eficaz. SQUID (magnetômetro): usa junções Josephson com λ_L~50nm. Qubits supercondutores: geometria controla acoplamento via λ_L.",
                    Criador = "London e London (1935, Proc. Royal Soc.)",
                    AnoOrigin = "1935",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Densidade Cooper n_s (m^-3)", Simbolo = "n_s", Unidade = "m^-3", ValorPadrao = 1e28, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Massa efetiva/m_e", Simbolo = "m*", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double ns = inputs["Densidade Cooper n_s (m^-3)"];
                        double massa_rel = inputs["Massa efetiva/m_e"];
                        
                        // Constantes
                        double mu0 = 4 * Math.PI * 1e-7; // H/m
                        double e = 1.602176634e-19; // C
                        double m_e = 9.1093837015e-31; // kg
                        double massa = massa_rel * m_e;
                        
                        // Comprimento de London
                        double lambda_L = Math.Sqrt(massa / (mu0 * ns * e * e));
                        
                        // Coerência length (típico)
                        double xi = 40e-9; // 40nm para Nb
                        
                        // Razão κ = λ/ξ (tipo I se <1/√2, tipo II se >1/√2)
                        double kappa = lambda_L / xi;
                        double threshold_tipo = 1.0 / Math.Sqrt(2);
                        
                        return lambda_L * 1e9;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-024: Quantização de Condutância
                new Formula
                {
                    Id = "3612",
                    CodigoCompendio = "V10-024",
                    Nome = "Quantização de Condutância",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Transporte Quântico",
                    Expressao = @"G = (2e²/h)·N = G₀·N",
                    Descricao = "Condutância em nanocontatos é quantizada em múltiplos de G₀=2e²/h≈77.5μS. N: número de canais de transmissão. Fator 2: spin up/down. Landauer formula: G=G₀Σᵢ Tᵢ.",
                    ExemploPratico = "Fio atômico ouro: platôs em 1G₀, 2G₀, 3G₀ ao esticar. Nanotubo carbono: 4 canais → G=4G₀. Grafeno: sem gap → alta condutância.",
                    Criador = "Landauer (1957, IBM); van Wees et al. (1988, experimento)",
                    AnoOrigin = "1957",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Número de canais N", Simbolo = "N", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Transmissão média T", Simbolo = "T", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["Número de canais N"];
                        double T = inputs["Transmissão média T"];
                        
                        // Quantum de condutância
                        double e = 1.602176634e-19; // C
                        double h = 6.62607015e-34; // J·s
                        double G0 = 2 * e * e / h; // S (Siemens)
                        
                        // Condutância total
                        double G = G0 * N * T;
                        
                        // Resistência
                        double R = 1.0 / Math.Max(G, 1e-15);
                        
                        // Quantum de resistência
                        double R_K = h / (e * e); // von Klitzing constant
                        
                        return G;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-025: Densidade de Estados 1D
                new Formula
                {
                    Id = "3613",
                    CodigoCompendio = "V10-025",
                    Nome = "Densidade de Estados em Nanofio 1D",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Física de Baixa Dimensão",
                    Expressao = @"ρ₁D(E) = (1/(πℏ))·√(2m/E)",
                    Descricao = "Densidade de estados (DOS) em sistema 1D. Singularidade em E→0 (van Hove). Nanotubo carbono metálico: DOS cerca de nível Fermi → alta condutividade.",
                    ExemploPratico = "Nanofio Si: confinamento quântico altera DOS. Grafeno nanoribbon: 1D-like com gaps. Medida via STM: dI/dV ∝ DOS.",
                    Criador = "Teoria de estados eletrônicos; van Hove (1953, singularidades)",
                    AnoOrigin = "1953",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Energia E (eV)", Simbolo = "E", Unidade = "eV", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Massa efetiva/m_e", Simbolo = "m*", Unidade = "", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E_eV = inputs["Energia E (eV)"];
                        double massa_rel = inputs["Massa efetiva/m_e"];
                        
                        if (E_eV <= 0) E_eV = 0.001;
                        
                        // Constantes
                        double hbar = 1.054571817e-34; // J·s
                        double m_e = 9.1093837015e-31; // kg
                        double eV = 1.602176634e-19; // J
                        double massa = massa_rel * m_e;
                        double E_J = E_eV * eV;
                        
                        // DOS 1D: ρ(E) = (1/(πℏ))·√(2m/E)
                        double rho_1D = (1.0 / (Math.PI * hbar)) * Math.Sqrt(2 * massa / E_J);
                        
                        // Para comparação: DOS 2D é constante, DOS 3D ∝ √E
                        double rho_2D = massa / (Math.PI * hbar * hbar);
                        double rho_3D = (massa / (Math.PI * Math.PI * hbar * hbar * hbar)) * Math.Sqrt(2 * massa * E_J);
                        
                        return rho_1D;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // Mais 16 fórmulas de nanotecnologia...
                // Continuando com exemplos representativos

                // V10-026: Escala de Comprimento Quantum
                new Formula
                {
                    Id = "3614",
                    CodigoCompendio = "V10-026",
                    Nome = "Comprimento de Onda de de Broglie",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Efeitos Quânticos",
                    Expressao = @"λ_dB = h/(m·v) = h/p",
                    Descricao = "Comprimento de onda associado a partícula com momento p. Quando λ_dB ≳ dimensões do sistema, efeitos quânticos dominam. Base do confinamento quântico em nanoestruturas.",
                    ExemploPratico = "Elétron a 300K (E_th=kT): λ_dB≈7nm. Quantum dot <10nm: níveis discretos. Poço quântico GaAs/AlGaAs: λ_dB≈5nm determina subbandas.",
                    Criador = "de Broglie (1924, tese PhD, Nobel 1929)",
                    AnoOrigin = "1924",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Energia cinética (eV)", Simbolo = "E", Unidade = "eV", ValorPadrao = 0.026, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Massa efetiva/m_e", Simbolo = "m*", Unidade = "", ValorPadrao = 0.067, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E_eV = inputs["Energia cinética (eV)"];
                        double massa_rel = inputs["Massa efetiva/m_e"];
                        
                        // Constantes
                        double h = 6.62607015e-34; // J·s
                        double m_e = 9.1093837015e-31; // kg
                        double eV = 1.602176634e-19; // J
                        double massa = massa_rel * m_e;
                        double E_J = E_eV * eV;
                        
                        // Momento: p = √(2mE)
                        double p = Math.Sqrt(2 * massa * E_J);
                        
                        // Comprimento de onda de de Broglie
                        double lambda_dB = h / p;
                        
                        // Velocidade
                        double v = p / massa;
                        
                        // Temperatura térmica equivalente
                        double kB = 1.380649e-23; // J/K
                        double T_equiv = E_J / kB;
                        
                        return lambda_dB * 1e9;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-027: Coulomb Blockade
                new Formula
                {
                    Id = "3615",
                    CodigoCompendio = "V10-027",
                    Nome = "Coulomb Blockade — Bloqueio de Condução",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Transporte Eletrônico",
                    Expressao = @"E_C = e²/(2C); Δμ > E_C para condução",
                    Descricao = "Em quantum dots ou ilhas metálicas pequenas, o custo energético para adicionar um elétron é E_C. C: capacitância total. Se Δμ<E_C, não há corrente → Coulomb blockade. Oscilações periódicas com gate voltage.",
                    ExemploPratico = "Quantum dot C=1aF (10^−18F): E_C=e²/(2C)≈80meV (300K → kT=26meV, então blockade visível a T<100K). Single electron transistor (SET) opera via controle de E_C.",
                    Criador = "Gorter (1951, conceito); Fulton & Dolan (1987, experimento)",
                    AnoOrigin = "1987",
                    VariavelResultado = "E_C",
                    UnidadeResultado = "eV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Capacitância C (aF)", Simbolo = "C", Unidade = "aF", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double C_aF = inputs["Capacitância C (aF)"];
                        double e = 1.602176634e-19; // C
                        double C_F = C_aF * 1e-18; // convert aF to F
                        double EC_J = (e * e) / (2 * C_F);
                        double EC_eV = EC_J / e;
                        
                        // Temperatura correspondente
                        double kB = 1.380649e-23; // J/K
                        double T_equiv = EC_J / kB;
                        
                        return EC_eV;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-028: Quantum Dot Energy Levels
                new Formula
                {
                    Id = "3616",
                    CodigoCompendio = "V10-028",
                    Nome = "Níveis de Energia em Quantum Dot",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Confinamento Quântico",
                    Expressao = @"E_n = n²·(h²)/(8m*L²); n=1,2,3...",
                    Descricao = "Elétron confinado em caixa 1D de tamanho L: níveis discretos. m*: massa efetiva. QD 3D: E_nlm com três números quânticos. Gap fundamental: ΔE = E₂−E₁ = 3h²/(8m*L²).",
                    ExemploPratico = "QD CdSe L=3nm, m*≈0.13m_e: E₁≈0.35eV. Para L=6nm: E₁≈0.09eV. Cor emissão sintonizável por tamanho (verde→vermelho).",
                    Criador = "Partícula em caixa (Schrödinger 1926); QD coloidais (Ekimov 1981)",
                    AnoOrigin = "1981",
                    VariavelResultado = "E_1",
                    UnidadeResultado = "eV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tamanho L (nm)", Simbolo = "L", Unidade = "nm", ValorPadrao = 3, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Massa efetiva/m_e", Simbolo = "m*", Unidade = "", ValorPadrao = 0.13, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Número quântico n", Simbolo = "n", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double L_nm = inputs["Tamanho L (nm)"];
                        double massa_rel = inputs["Massa efetiva/m_e"];
                        double n = inputs["Número quântico n"];
                        
                        double h = 6.62607015e-34; // J·s
                        double m_e = 9.1093837015e-31; // kg
                        double eV = 1.602176634e-19; // J
                        double L_m = L_nm * 1e-9;
                        double massa = massa_rel * m_e;
                        
                        // Energia do nível n
                        double E_J = (n * n * h * h) / (8 * massa * L_m * L_m);
                        double E_eV = E_J / eV;
                        
                        return E_eV;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-029: Exciton Binding Energy
                new Formula
                {
                    Id = "3617",
                    CodigoCompendio = "V10-029",
                    Nome = "Energia de Ligação do Éxciton",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Opto-eletrônica",
                    Expressao = @"E_b = (μ/m_e)·(ε_r)^−2·13.6eV",
                    Descricao = "Éxciton: par elétron-buraco ligado. μ: massa reduzida. ε_r: permissividade relativa. E_b~meV em semicondutores bulk, mas aumenta em QDs (confinamento).",
                    ExemploPratico = "GaAs bulk: μ≈0.05m_e, ε_r=12.9 → E_b≈4meV. QD CdSe: confinamento forte → E_b>100meV. Temperatura deconfinamento: T>E_b/kB.",
                    Criador = "Wannier (1937, éxciton de Wannier); Frenkel (1931, tipo Frenkel em orgânicos)",
                    AnoOrigin = "1931",
                    VariavelResultado = "E_b",
                    UnidadeResultado = "meV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Massa reduzida μ/m_e", Simbolo = "μ", Unidade = "", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Permissividade ε_r", Simbolo = "ε_r", Unidade = "", ValorPadrao = 12.9, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double mu_rel = inputs["Massa reduzida μ/m_e"];
                        double epsilon_r = inputs["Permissividade ε_r"];
                        
                        // Energia de ligação (Rydberg modificado)
                        double Ry = 13.6; // eV
                        double E_b_eV = (mu_rel / (epsilon_r * epsilon_r)) * Ry;
                        double E_b_meV = E_b_eV * 1000;
                        
                        // Raio de Bohr do éxciton
                        double a0 = 0.0529; // nm
                        double a_exc = (epsilon_r / mu_rel) * a0;
                        
                        return E_b_meV;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-030: Surface Plasmon Resonance
                new Formula
                {
                    Id = "3618",
                    CodigoCompendio = "V10-030",
                    Nome = "Ressonância de Plasmons Superficiais",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Nanofotônica",
                    Expressao = @"λ_SPR = λ_p·√(1 + 2ε_m); λ_p = 2πc/ω_p",
                    Descricao = "Nanopartículas metálicas: oscilação coletiva de elétrons livres. ω_p: frequência de plasma. ε_m: constante dielétrica do meio. Ouro: λ_SPR≈520nm (verde).",
                    ExemploPratico = "Nanopartícula Au 50nm em água (ε_m≈1.77): λ_SPR≈530nm. Sensores SPR detectam mudanças em ε_m (biomoléculas adsorvidas). Copo de Lycurgus (Romano, 400DC): Au/Ag NPs.",
                    Criador = "Mie (1908, teoria espalhamento); Kretschmann-Raether (1968, configuração)",
                    AnoOrigin = "1908",
                    VariavelResultado = "λ_SPR",
                    UnidadeResultado = "nm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Frequência plasma ω_p (rad/s)", Simbolo = "ω_p", Unidade = "rad/s", ValorPadrao = 1.37e16, Descricao = "Parâmetro de entrada." }, // Au
                        new Variavel { Nome = "Constante dielétrica ε_m", Simbolo = "ε_m", Unidade = "", ValorPadrao = 1.77, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double omega_p = inputs["Frequência plasma ω_p (rad/s)"];
                        double epsilon_m = inputs["Constante dielétrica ε_m"];
                        
                        double c = 2.998e8; // m/s
                        
                        // Comprimento de onda de plasma
                        double lambda_p = (2 * Math.PI * c) / omega_p;
                        
                        // Ressonância de plasmons (Mie theory simplificada)
                        double lambda_SPR = lambda_p * Math.Sqrt(1 + 2 * epsilon_m);
                        
                        return lambda_SPR * 1e9; // convert to nm
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-031: Casimir Force
                new Formula
                {
                    Id = "3619",
                    CodigoCompendio = "V10-031",
                    Nome = "Força de Casimir",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Fenômenos Quânticos de Vácuo",
                    Expressao = @"F/A = −π²ℏc/(240d⁴)",
                    Descricao = "Atração entre placas condutoras no vácuo devido a flutuações quânticas. F/A: pressão (negativa → atração). d: distância. MEMS: Calogero~10nm → F significante.",
                    ExemploPratico = "d=1μm: F/A≈−1.3×10^−3 Pa. d=100nm: F/A≈−13Pa (0.13atm!). MEMS podem colapsar se d<50nm. Medida verificada por Lamoreaux (1997).",
                    Criador = "Casimir (1948, Philips); Lamoreaux (1997, medida precisa)",
                    AnoOrigin = "1948",
                    VariavelResultado = "pressão",
                    UnidadeResultado = "Pa",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Distância d (nm)", Simbolo = "d", Unidade = "nm", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double d_nm = inputs["Distância d (nm)"];
                        double hbar = 1.054571817e-34; // J·s
                        double c = 2.998e8; // m/s
                        double d_m = d_nm * 1e-9;
                        
                        // Força de Casimir por área
                        double F_over_A = -(Math.PI * Math.PI * hbar * c) / (240 * Math.Pow(d_m, 4));
                        
                        // Valor absoluto para clareza
                        double magnitude = Math.Abs(F_over_A);
                        
                        return F_over_A;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-032: Fermi Velocity in Graphene
                new Formula
                {
                    Id = "3620",
                    CodigoCompendio = "V10-032",
                    Nome = "Velocidade de Fermi no Grafeno",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Grafeno",
                    Expressao = @"v_F ≈ 10⁶ m/s ≈ c/300",
                    Descricao = "Grafeno: relação linear E=ℏv_F·k (Dirac cone). v_F independente de energia! Elétrons comportam-se como férmions de Dirac sem massa. Mobilidade altíssima.",
                    ExemploPratico = "v_F=1.1×10⁶m/s (300× menor que c). Mobilidade μ>200,000cm²/V·s a T=300K. FET de grafeno: frequências THz possíveis.",
                    Criador = "Wallace (1947, estrutura banda); Geim & Novoselov (2004, isolamento, Nobel 2010)",
                    AnoOrigin = "2004",
                    VariavelResultado = "v_F",
                    UnidadeResultado = "m/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Parâmetro hopping t (eV)", Simbolo = "t", Unidade = "eV", ValorPadrao = 2.8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Perímetro lattice a (nm)", Simbolo = "a", Unidade = "nm", ValorPadrao = 0.246, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double t_eV = inputs["Parâmetro hopping t (eV)"];
                        double a_nm = inputs["Perímetro lattice a (nm)"];
                        
                        double hbar = 1.054571817e-34; // J·s
                        double eV = 1.602176634e-19; // J
                        double t_J = t_eV * eV;
                        double a_m = a_nm * 1e-9;
                        
                        // Velocidade de Fermi: v_F ≈ 3ta/(2ℏ)
                        double v_F = (3 * t_J * a_m) / (2 * hbar);
                        
                        // Razão com velocidade da luz
                        double c = 2.998e8;
                        double ratio = v_F / c;
                        
                        return v_F;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-033: Landau Levels
                new Formula
                {
                    Id = "3621",
                    CodigoCompendio = "V10-033",
                    Nome = "Níveis de Landau",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Campo Magnético",
                    Expressao = @"E_n = (n + 1/2)·ℏω_c; ω_c = eB/m*",
                    Descricao = "Elétron 2D em campo magnético B: órbitas ciclotrônicas quantizadas. ω_c: frequência ciclotrônica. Grafeno: E_n ∝ √n (cone de Dirac). Transições ópticas permitidas Δn=±1.",
                    ExemploPratico = "GaAs 2DEG B=10T, m*=0.067m_e: ω_c≈1.7×10¹³rad/s, E₁≈11meV. Grafeno B=10T: separação ~√B (regime Hall quântico).",
                    Criador = "Landau (1930, física de campos); von Klitzing (1980, efeito Hall quântico, Nobel 1985)",
                    AnoOrigin = "1930",
                    VariavelResultado = "E_1",
                    UnidadeResultado = "meV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Campo magnético B (T)", Simbolo = "B", Unidade = "T", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Massa efetiva/m_e", Simbolo = "m*", Unidade = "", ValorPadrao = 0.067, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Número quântico n", Simbolo = "n", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double B = inputs["Campo magnético B (T)"];
                        double massa_rel = inputs["Massa efetiva/m_e"];
                        double n = inputs["Número quântico n"];
                        
                        double e = 1.602176634e-19; // C
                        double m_e = 9.1093837015e-31; // kg
                        double hbar = 1.054571817e-34; // J·s
                        double eV_J = 1.602176634e-19;
                        double massa = massa_rel * m_e;
                        
                        // Frequência ciclotrônica
                        double omega_c = (e * B) / massa;
                        
                        // Energia do nível n
                        double E_J = (n + 0.5) * hbar * omega_c;
                        double E_eV = E_J / eV_J;
                        double E_meV = E_eV * 1000;
                        
                        return E_meV;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-034: Carbon Nanotube Band Structure
                new Formula
                {
                    Id = "3622",
                    CodigoCompendio = "V10-034",
                    Nome = "Estrutura de Bandas de Nanotubo de Carbono",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Nanomateriais",
                    Expressao = @"Metálico se (n−m) mod 3 = 0; senão semicondutor",
                    Descricao = "CNT (n,m): índices quiralidade. Armchair (n,n): sempre metálico. Zigzag (n,0): metálico se n mod 3=0. Gap semicondutor: E_g ≈ 0.8eV·(a/d), d: diâmetro.",
                    ExemploPratico = "CNT (10,10): metálico, d≈1.4nm. CNT (17,0): n=17, 17 mod 3≠0 → semicondutor, E_g≈0.5eV. CNT (9,0): metálico (9 mod 3=0).",
                    Criador = "Iijima (1991, Nature CNT descoberta); Hamada et al. (1992, teoria)",
                    AnoOrigin = "1991",
                    VariavelResultado = "tipo",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Índice n", Simbolo = "n", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Índice m", Simbolo = "m", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double n = inputs["Índice n"];
                        double m = inputs["Índice m"];
                        
                        // Checar se metálico: (n-m) mod 3 = 0
                        int diff = (int)(n - m);
                        bool metalico = (diff % 3) == 0;
                        
                        // Diâmetro aproximado: d = a/π · √(n²+nm+m²), a≈0.246nm
                        double a = 0.246; // nm
                        double d = (a / Math.PI) * Math.Sqrt(n * n + n * m + m * m);
                        
                        // Gap semicondutor aproximado
                        double E_g = metalico ? 0 : (0.8 * a / d);
                        
                        // Tipo
                        string tipo_str = metalico ? "Metálico" : "Semicondutor";
                        bool armchair = (n == m);
                        bool zigzag = (m == 0);
                        
                        return metalico ? 1.0 : 0.0;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-035: Quantum Hall Effect
                new Formula
                {
                    Id = "3623",
                    CodigoCompendio = "V10-035",
                    Nome = "Efeito Hall Quântico",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Transporte Quântico",
                    Expressao = @"R_H = h/(νe²) = R_K/ν",
                    Descricao = "2DEG em campo B alto: resistência Hall quantizada em platôs R_H=h/(νe²). ν: fator de preenchimento (inteiro no QHE, fracionário no FQHE). R_K=h/e²≈25.8kΩ.",
                    ExemploPratico = "ν=1: R_H≈25.8kΩ. ν=1/3: FQHE (Tsui, Störmer, Laughlin 1982, Nobel 1998). Padrão resistência metrológico: precisão ~10^−9.",
                    Criador = "von Klitzing (1980, QHE, Nobel 1985); Tsui-Störmer-Laughlin (1982, FQHE)",
                    AnoOrigin = "1980",
                    VariavelResultado = "R_H",
                    UnidadeResultado = "kΩ",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Fator preenchimento ν", Simbolo = "ν", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double nu = inputs["Fator preenchimento ν"];
                        
                        double h = 6.62607015e-34; // J·s
                        double e = 1.602176634e-19; // C
                        
                        // von Klitzing constant
                        double R_K = h / (e * e); // Ω
                        
                        // Resistência Hall
                        double R_H = R_K / nu;
                        
                        return R_H / 1000; // convert to kΩ
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-036: Single Electron Transistor (SET)
                new Formula
                {
                    Id = "3624",
                    CodigoCompendio = "V10-036",
                    Nome = "Single Electron Transistor (SET)",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Nanoeletrônica",
                    Expressao = @"I_pk ≈ e·Γ; Γ = (h/e²R_t)·exp(−E_C/kT)",
                    Descricao = "SET: ilha metálica com capacitância~aF conectada por tunelamento. Corrente controlada por gate com periodicidade e. Γ: taxa tunelamento. Opera a T<E_C/k.",
                    ExemploPratico = "E_C=50meV → T<580K viável. R_t=100kΩ, T=100mK: Γ~10⁹Hz → I_pk~160pA. Aplicação: eletrômetro ultra-sensível (resolução <0.01e).",
                    Criador = "Fulton & Dolan (1987, Bell Labs, primeiro SET)",
                    AnoOrigin = "1987",
                    VariavelResultado = "I_pk",
                    UnidadeResultado = "pA",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Energia Coulomb E_C (meV)", Simbolo = "E_C", Unidade = "meV", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Resistência tunelamento (kΩ)", Simbolo = "R_t", Unidade = "kΩ", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Temperatura (mK)", Simbolo = "T", Unidade = "mK", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double EC_meV = inputs["Energia Coulomb E_C (meV)"];
                        double Rt_kohm = inputs["Resistência tunelamento (kΩ)"];
                        double T_mK = inputs["Temperatura (mK)"];
                        
                        double e = 1.602176634e-19; // C
                        double h = 6.62607015e-34; // J·s
                        double kB = 1.380649e-23; // J/K
                        double eV_J = 1.602176634e-19;
                        
                        double EC_J = EC_meV * 1e-3 * eV_J;
                        double Rt_ohm = Rt_kohm * 1e3;
                        double T_K = T_mK * 1e-3;
                        
                        // Taxa tunelamento (aproximação)
                        double Gamma = (h / (e * e * Rt_ohm)) * Math.Exp(-EC_J / (kB * T_K));
                        
                        // Corrente pico
                        double I_pk = e * Gamma; // A
                        double I_pk_pA = I_pk * 1e12; // convert to pA
                        
                        return I_pk_pA;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-037: Molecular Conductance
                new Formula
                {
                    Id = "3625",
                    CodigoCompendio = "V10-037",
                    Nome = "Condutância Molecular",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Eletrônica Molecular",
                    Expressao = @"G = G₀·|t|²/(|ε−ε_0|² + Γ²/4)",
                    Descricao = "Molécula entre eletrodos: Breit-Wigner formula. t: acoplamento eletrodo-molécula. ε₀: nível HOMO/LUMO. Γ: largura nível. Ressonância quando ε≈ε₀ → G máximo.",
                    ExemploPratico = "Benzeno-dithiol: G≈0.01G₀. OPE-3 (oligofenileno): G≈0.001G₀. Alcanotiois: G decai exponencialmente com n_CH2 (β≈0.9/CH2).",
                    Criador = "Aviram-Ratner (1974, conceito); Reed et al. (1997, medida molecular)",
                    AnoOrigin = "1997",
                    VariavelResultado = "G/G₀",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Acoplamento |t|²", Simbolo = "|t|²", Unidade = "", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Desalinhamento |ε−ε₀| (eV)", Simbolo = "Δε", Unidade = "eV", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Largura Γ (eV)", Simbolo = "Γ", Unidade = "eV", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double t_sq = inputs["Acoplamento |t|²"];
                        double delta_eps = inputs["Desalinhamento |ε−ε₀| (eV)"];
                        double Gamma = inputs["Largura Γ (eV)"];
                        
                        // Breit-Wigner formula
                        double denom = delta_eps * delta_eps + (Gamma * Gamma / 4);
                        double G_ratio = t_sq / denom;
                        
                        return G_ratio;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-038: Spin-Orbit Coupling
                new Formula
                {
                    Id = "3626",
                    CodigoCompendio = "V10-038",
                    Nome = "Acoplamento Spin-Órbita",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Spintrônica",
                    Expressao = @"H_SO = (ℏ/4m²c²)·(1/r)(dV/dr)·(L·S)",
                    Descricao = "Spin do elétron acopla com momento orbital em campo elétrico. Essencial em spintrônica: quebra degenerescência spin. Rashba effect: E externo induz splitting.",
                    ExemploPratico = "InAs/GaSb: λ_SO≈50meV·nm → manipulação spin elétrica. Topological insulators: banda de superfície protegida por spin-órbita (Bi₂Se₃). Spin Hall effect.",
                    Criador = "Thomas (1926, precessão); Rashba-Bychkov (1984, efeito Rashba)",
                    AnoOrigin = "1984",
                    VariavelResultado = "α_R",
                    UnidadeResultado = "eV·Å",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Campo elétrico (V/nm)", Simbolo = "E", Unidade = "V/nm", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Parâmetro material", Simbolo = "γ", Unidade = "eV·Å²", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E_field = inputs["Campo elétrico (V/nm)"];
                        double gamma = inputs["Parâmetro material"];
                        
                        // Parâmetro Rashba α_R ∝ E·γ
                        double alpha_R = E_field * gamma / 10; // eV·Å (conversão aproximada)
                        
                        double eV_J = 1.602176634e-19;
                        double alpha_R_SI = alpha_R * eV_J * 1e-10; // J·m
                        
                        return alpha_R;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-039: Rashba Effect
                new Formula
                {
                    Id = "3627",
                    CodigoCompendio = "V10-039",
                    Nome = "Efeito Rashba",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Spintrônica",
                    Expressao = @"E_±(k) = (ℏ²k²)/(2m) ± α_R·k",
                    Descricao = "Asymmetria estrutural + spin-órbita → splitting de bandas. α_R: parâmetro Rashba. Manipulação spin sem campo magnético (gate voltage controla α_R).",
                    ExemploPratico = "InAs 2DEG: α_R≈5.5×10^−12eV·m. BiTeI bulk: α_R≈3.8eV·Å (gigante!). Spin-FET (Datta-Das 1990): controle elétrico de corrente spin.",
                    Criador = "Rashba-Bychkov (1984, 2DEG assimétrico)",
                    AnoOrigin = "1984",
                    VariavelResultado = "ΔE",
                    UnidadeResultado = "meV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Vetor k (nm^-1)", Simbolo = "k", Unidade = "nm^-1", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Parâmetro Rashba (eV·Å)", Simbolo = "α_R", Unidade = "eV·Å", ValorPadrao = 0.55, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double k_invnm = inputs["Vetor k (nm^-1)"];
                        double alpha_R = inputs["Parâmetro Rashba (eV·Å)"];
                        
                        double k_invm = k_invnm * 1e9; // convert to m^-1
                        double alpha_R_SI = alpha_R * 1.602176634e-19 * 1e-10; // J·m
                        
                        // Splitting energético
                        double delta_E_J = 2 * alpha_R_SI * k_invm;
                        double delta_E_eV = delta_E_J / 1.602176634e-19;
                        double delta_E_meV = delta_E_eV * 1000;
                        
                        return delta_E_meV;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-040: Quantum Capacitance
                new Formula
                {
                    Id = "3628",
                    CodigoCompendio = "V10-040",
                    Nome = "Capacitância Quântica",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Nanoeletrônica",
                    Expressao = @"C_Q = e²·(dN/dμ) = e²·DOS(E_F)",
                    Descricao = "Em sistemas de baixa dimensão, capacitância total C_total^−1 = C_geom^−1 + C_Q^−1. C_Q limitado por DOS. Grafeno: C_Q ∝ √n (baixo perto do ponto de Dirac).",
                    ExemploPratico = "Grafeno n=10¹²cm^−2: C_Q≈2μF/cm². CNT: C_Q≈4aF/nm. FET com canal 2D: C_Q reduz transcondutância a alta densidade.",
                    Criador = "Luryi (1988, conceito); John et al. (2004, grafeno)",
                    AnoOrigin = "1988",
                    VariavelResultado = "C_Q",
                    UnidadeResultado = "μF/cm²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "DOS no Fermi (estados/eV/cm²)", Simbolo = "DOS", Unidade = "estados/eV/cm²", ValorPadrao = 1e13, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double DOS_per_eV_cm2 = inputs["DOS no Fermi (estados/eV/cm²)"];
                        
                        double e = 1.602176634e-19; // C
                        double eV_J = 1.602176634e-19;
                        
                        // Converter DOS para SI (estados/J/m²)
                        double DOS_SI = DOS_per_eV_cm2 * 1e4 / eV_J;
                        
                        // Capacitância quântica
                        double C_Q_SI = e * e * DOS_SI; // F/m²
                        double C_Q_uF_cm2 = C_Q_SI * 1e2; // convert to μF/cm²
                        
                        return C_Q_uF_cm2;
                    },
                    Icone = "🔬",
                    Unidades = "",
                },

                // V10-041: Phonon Dispersion in Nanowire
                new Formula
                {
                    Id = "3629",
                    CodigoCompendio = "V10-041",
                    Nome = "Dispersão de Fônons em Nanofio",
                    Categoria = "Nanotecnologia",
                    SubCategoria = "Transporte Térmico",
                    Expressao = @"ω_ph = v_s·k; v_s = √(E/ρ)",
                    Descricao = "Fônons acústicos em nanofio: ω linear em k (longa wave). v_s: velocidade som. Confinamento quântico → modos discretos. Condutividade térmica reduzida (vantagem termoelétrico).",
                    ExemploPratico = "Si nanowire d=50nm: κ~10W/m·K (bulk Si: 150W/m·K). Efeito de superfície espalha fônons. ZT termoelétrico: ZT=(S²σ/κ)T melhora.",
                    Criador = "Debye (1912, fônons); Hochbaum et al. (2008, Si nanowire termoelétrico)",
                    AnoOrigin = "2008",
                    VariavelResultado = "v_s",
                    UnidadeResultado = "m/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Módulo Young E (GPa)", Simbolo = "E", Unidade = "GPa", ValorPadrao = 130, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Densidade ρ (g/cm³)", Simbolo = "ρ", Unidade = "g/cm³", ValorPadrao = 2.33, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E_GPa = inputs["Módulo Young E (GPa)"];
                        double rho_g_cm3 = inputs["Densidade ρ (g/cm³)"];
                        
                        double E_Pa = E_GPa * 1e9; // convert to Pa
                        double rho_kg_m3 = rho_g_cm3 * 1000; // convert to kg/m³
                        
                        // Velocidade do som
                        double v_s = Math.Sqrt(E_Pa / rho_kg_m3);
                        
                        // Frequência Debye típica
                        double k_Debye = 2 * Math.PI / (5e-9); // ~1/5nm para Si
                        double omega_Debye = v_s * k_Debye;
                        double f_Debye = omega_Debye / (2 * Math.PI);
                        
                        return v_s;
                    },
                    Icone = "🔬",
                    Unidades = "",
                }
            });
        }
    }
}
