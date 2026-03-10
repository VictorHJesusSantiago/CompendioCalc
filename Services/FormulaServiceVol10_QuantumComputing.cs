using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE I  
    /// COMPUTAÇÃO QUÂNTICA E INFORMAÇÃO QUÂNTICA
    /// Fórmulas V10-001 a V10-021 (21 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_QuantumComputing()
        {
            _formulas.AddRange(new List<Formula>
            {
                // V10-001: Estado de Qubit — Superposição
                new Formula
                {
                    Id = "3589",
                    CodigoCompendio = "V10-001",
                    Nome = "Estado de Qubit — Superposição",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Qubits e Portas Quânticas",
                    Expressao = @"|ψ⟩ = α|0⟩ + β|1⟩; |α|² + |β|² = 1",
                    Descricao = "Estado de qubit em superposição. α,β são amplitudes complexas. Ao medir: P(0)=|α|², P(1)=|β|². Representação na esfera de Bloch via ângulos (θ,φ). Base fundamental da computação quântica.",
                    ExemploPratico = "Estado |+⟩=(|0⟩+|1⟩)/√2 tem α=β=1/√2. Estado |−⟩=(|0⟩−|1⟩)/√2 tem α=1/√2, β=−1/√2. Superposição: N qubits geram 2^N estados simultâneos. Para 3 qubits: 8 estados paralelos.",
                    Criador = "Dirac",
                    AnoOrigin = "1939",
                    VariavelResultado = "normalização",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "α_r", Nome = "Alpha real", Unidade = "", ValorPadrao = 0.707, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "α_i", Nome = "Alpha imaginário", Unidade = "", ValorPadrao = 0, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "β_r", Nome = "Beta real", Unidade = "", ValorPadrao = 0.707, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "β_i", Nome = "Beta imaginário", Unidade = "", ValorPadrao = 0, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double alphaR = inputs["Alpha real"];
                        double alphaI = inputs["Alpha imaginário"];
                        double betaR = inputs["Beta real"];
                        double betaI = inputs["Beta imaginário"];
                        double normAlpha2 = alphaR * alphaR + alphaI * alphaI;
                        double normBeta2 = betaR * betaR + betaI * betaI;
                        return normAlpha2 + normBeta2; // Deve ser ≈1
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-002: Porta Hadamard
                new Formula
                {
                    Id = "3590",
                    CodigoCompendio = "V10-002",
                    Nome = "Porta Hadamard",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Portas Quânticas",
                    Expressao = @"H = (1/√2)·[[1,1],[1,−1]]",
                    Descricao = "Matriz de Hadamard cria superposição uniforme. H|0⟩=|+⟩=(|0⟩+|1⟩)/√2, H|1⟩=|−⟩=(|0⟩−|1⟩)/√2. H²=I (involutiva). Fundamental para QFT e Grover.",
                    ExemploPratico = "QFT e Grover usam H em todos qubits. H⊗ⁿ|0⟩ⁿ=(1/√2ⁿ)Σ|x⟩. Para N=3: cria 8 estados com amplitude 1/√8≈0.35 cada.",
                    Criador = "Walsh-Hadamard",
                    AnoOrigin = "1923",
                    VariavelResultado = "amplitude",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "q", Nome = "Estado inicial", Unidade = "", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double q = inputs["Estado inicial"];
                        return 1.0 / Math.Sqrt(2.0); // Amplitude resultante
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-003: Porta CNOT
                new Formula
                {
                    Id = "3591",
                    CodigoCompendio = "V10-003",
                    Nome = "Porta CNOT",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Emaranhamento Quântico",
                    Expressao = @"CNOT|c,t⟩ = |c,c⊕t⟩",
                    Descricao = "Porta Controlled-NOT: inverte target se control=1. Com Hadamard cria estado de Bell: |Φ⁺⟩=(|00⟩+|11⟩)/√2. Fundamental para circuitos universais.",
                    ExemploPratico = "H⊗I seguido de CNOT gera estado de Bell (emaranhamento). Base para teleportação quântica e superdense coding.",
                    Criador = "Base de circuitos quânticos",
                    AnoOrigin = "1995",
                    VariavelResultado = "alvo_saída",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "c", Nome = "Qubit controle", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "t", Nome = "Qubit alvo", Unidade = "", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        int control = (int)Math.Round(inputs["Qubit controle"]);
                        int target = (int)Math.Round(inputs["Qubit alvo"]);
                        return control == 1 ? (target == 0 ? 1.0 : 0.0) : target;
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-004: Estado de Bell
                new Formula
                {
                    Id = "3592",
                    CodigoCompendio = "V10-004",
                    Nome = "Estado de Bell",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Emaranhamento Quântico",
                    Expressao = @"|Φ⁺⟩ = (|00⟩+|11⟩)/√2",
                    Descricao = "Estado de Bell com máximo emaranhamento bipartite. Violação das desigualdades de Bell demonstra não-localidade quântica. Entropia = 1 ebit (máxima para 2 qubits).",
                    ExemploPratico = "S_CHSH=2√2≈2.83 > 2 (limite clássico). Teleportação quântica. Experimentos de Aspect (1982) confirmaram violação.",
                    Criador = "Bell",
                    AnoOrigin = "1964",
                    VariavelResultado = "amplitude",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "θ", Nome = "Ângulo de medição", Unidade = "rad", ValorPadrao = 0, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        return 1.0 / Math.Sqrt(2.0); // Amplitude do estado de Bell
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-005: Algoritmo de Shor
                new Formula
                {
                    Id = "3593",
                    CodigoCompendio = "V10-005",
                    Nome = "Algoritmo de Shor",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Algoritmos Quânticos",
                    Expressao = @"O(log³N · log log N)",
                    Descricao = "Algoritmo quântico para fatoração. Clássico: O(exp((log N)^(1/3))). Shor: polinomial. Quebra RSA-2048 com quantum computer suficiente.",
                    ExemploPratico = "N=2048-bit RSA: clássico ~2^1024 ops → Shor: ~10^9 ops. IBM 127-qubit ainda sem fault-tolerance. Maior fatorado: 21=3×7 (2012).",
                    Criador = "Shor",
                    AnoOrigin = "1994",
                    VariavelResultado = "complexidade",
                    UnidadeResultado = "operações",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "N", Nome = "Número a fatorar", Unidade = "", ValorPadrao = 15, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["Número a fatorar"];
                        double logN = Math.Log(N, 2);
                        double loglogN = Math.Log(logN, 2);
                        return logN * logN * logN * loglogN; // Complexidade Shor
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-006: Algoritmo de Grover
                new Formula
                {
                    Id = "3594",
                    CodigoCompendio = "V10-006",
                    Nome = "Algoritmo de Grover",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Algoritmos Quânticos",
                    Expressao = @"T = π√N/4",
                    Descricao = "Busca quântica em banco desordenado. Clássico: O(N). Grover: O(√N). Speedup quadrático provado ótimo (Bennett, Zalka).",
                    ExemploPratico = "N=10^6: clássico 500k iterações; Grover: 1000. Para N=2^20≈1M: 1024 iterações vs 500k clássicas.",
                    Criador = "Grover",
                    AnoOrigin = "1996",
                    VariavelResultado = "iterações",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "N", Nome = "Tamanho do espaço", Unidade = "", ValorPadrao = 1000000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["Tamanho do espaço"];
                        return Math.PI * Math.Sqrt(N) / 4.0; // Número ótimo de iterações
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-007: Transformada de Fourier Quântica (QFT)
                new Formula
                {
                    Id = "3595",
                    CodigoCompendio = "V10-007",
                    Nome = "QFT — Transformada de Fourier Quântica",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Algoritmos Quânticos",
                    Expressao = @"QFT|x⟩ = (1/√N)Σ_{k=0}^{N-1} e^(2πixk/N)|k⟩",
                    Descricao = "Base do algoritmo de Shor. Clássico: FFT O(N log N). QFT: O(log² N) portas. Speedup exponencial.",
                    ExemploPratico = "N=2^n qubits: QFT usa n² portas vs 2^n operações FFT. Para n=50: QFT=2500 portas, FFT=5.6×10^16 ops.",
                    Criador = "Base do Shor",
                    AnoOrigin = "1994",
                    VariavelResultado = "portas",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "n", Nome = "Número de qubits", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double n = inputs["Número de qubits"];
                        return n * n; // Número de portas QFT
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-008: Fidelidade Quântica
                new Formula
                {
                    Id = "3596",
                    CodigoCompendio = "V10-008",
                    Nome = "Fidelidade Quântica",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Informação Quântica",
                    Expressao = @"F = |⟨ψ|φ⟩|²",
                    Descricao = "Medida de similaridade entre estados quânticos. F=1: estados idênticos. F=0: ortogonais. Métrica fundamental em correção de erros.",
                    ExemploPratico = "Fidelidade mínima para vantagem quântica: >99.9%. IBM Quantum: F≈99.5% (2-qubits), ≈98% (multi-qubits).",
                    Criador = "Jozsa",
                    AnoOrigin = "1994",
                    VariavelResultado = "fidelidade",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "overlap", Nome = "Overlap dos estados", Unidade = "", ValorPadrao = 0.99, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double overlap = inputs["Overlap dos estados"];
                        return overlap * overlap; // Fidelidade = |overlap|²
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-009: Código de Shor (Correção de Erros)
                new Formula
                {
                    Id = "3597",
                    CodigoCompendio = "V10-009",
                    Nome = "Código de Shor — Correção Quântica [[9,1,3]]",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Correção de Erros Quânticos",
                    Expressao = @"[[n,k,d]] = [[9,1,3]]",
                    Descricao = "Primeiro código de correção quântica. Protege 1 qubit lógico usando 9 físicos. Corrige 1 erro arbitrário. Distância d=3.",
                    ExemploPratico = "Shor [[9,1,3]] corrige X,Y,Z em qualquer qubit. Surface code atual: [[n,1,d]] com d≈10-20. Google Sycamore: surface code 54 qubits.",
                    Criador = "Shor",
                    AnoOrigin = "1995",
                    VariavelResultado = "qubits_físicos",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "k", Nome = "Qubits lógicos", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double k = inputs["Qubits lógicos"];
                        return k * 9; // Qubits físicos necessários
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-010: Limite de Heisenberg
                new Formula
                {
                    Id = "3598",
                    CodigoCompendio = "V10-010",
                    Nome = "Limite de Heisenberg",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Limites Fundamentais",
                    Expressao = @"τ ≥ ℏ/(2ΔE)",
                    Descricao = "Tempo mín. para transição quântica. ΔE=diferença energia. Limita velocidade de portas quânticas. Fundamental em algoritmos.",
                    ExemploPratico = "ΔE=1 GHz: τ≥0.08 ns. Portas supercondutoras: ~20-50 ns. Íons: ~μs. Tempo coerência: T2≈100 μs (supercond).",
                    Criador = "Heisenberg",
                    AnoOrigin = "1927",
                    VariavelResultado = "tempo_mínimo",
                    UnidadeResultado = "s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "ΔE", Nome = "Diferença energia", Unidade = "J", ValorPadrao = 1e-25, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double deltaE = inputs["Diferença energia"];
                        double hbar = 1.054571817e-34; // J·s
                        return hbar / (2.0 * deltaE); // Tempo mínimo
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-011: Threshold Theorem (FTQC)
                new Formula
                {
                    Id = "3599",
                    CodigoCompendio = "V10-011",
                    Nome = "Threshold Theorem — Tolerância a Falhas",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Correção de Erros Quânticos",
                    Expressao = @"p < p_th ≈ 10^(-3)",
                    Descricao = "Se erro físico p < threshold p_th, computação quântica arbitrariamente longa viável via correção de erros. Surface code: p_th≈1%.",
                    ExemploPratico = "Google Sycamore: 2-qubit p≈0.6%. Surface [[17,1,3]]: p_th≈1%. Concatenação: 10^6 qubits físicos por lógico.",
                    Criador = "Aharonov-Ben-Or, Kitaev, Preskill-Knill",
                    AnoOrigin = "1996",
                    VariavelResultado = "erro_lógico",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "p", Nome = "Erro físico", Unidade = "", ValorPadrao = 0.001, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "L", Nome = "Nível concatenação", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double p = inputs["Erro físico"];
                        double L = inputs["Nível concatenação"];
                        return Math.Pow(p, Math.Pow(2, L)); // Erro lógico após L níveis
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-012: Critérios de DiVincenzo
                new Formula
                {
                    Id = "3600",
                    CodigoCompendio = "V10-012",
                    Nome = "Critérios de DiVincenzo",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Requisitos Físicos",
                    Expressao = @"T₂/T_gate > 10⁴",
                    Descricao = "5 critérios para QC escalável: (1)qubits escaláveis, (2)inicialização, (3)T₂ longo, (4)portas universais, (5)medição específica.",
                    ExemploPratico = "T_gate≈50 ns, T₂≈100 μs: razão=2000 (insuficiente). T₂≈1 ms necessário. Surface code relaxa para ~10².",
                    Criador = "DiVincenzo",
                    AnoOrigin = "2000",
                    VariavelResultado = "razão_coerência",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "T2", Nome = "Tempo coerência", Unidade = "s", ValorPadrao = 0.0001, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "Tg", Nome = "Tempo porta", Unidade = "s", ValorPadrao = 5e-8, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double T2 = inputs["Tempo coerência"];
                        double Tgate = inputs["Tempo porta"];
                        return T2 / Tgate; // Razão (ideal: >10⁴)
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-013: BB84 — Distribuição Quântica de Chaves
                new Formula
                {
                    Id = "3601",
                    CodigoCompendio = "V10-013",
                    Nome = "Protocolo BB84",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Criptografia Quântica",
                    Expressao = @"Taxa_chave = R(1 - h(Q))",
                    Descricao = "Distribuição quântica de chaves via qubits. Segurança garantida por princípios quânticos. Detecção de espionagem via taxa erro Q.",
                    ExemploPratico = "Q<11%: chave segura. Q>11%: espionagem ou ruído. Implementações: fibra>100km, satélite>1000km (Micius).",
                    Criador = "Bennett-Brassard",
                    AnoOrigin = "1984",
                    VariavelResultado = "taxa_chave",
                    UnidadeResultado = "bits/qubit",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "R", Nome = "Taxa transmissão", Unidade = "bits/s", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "Q", Nome = "Taxa erro (QBER)", Unidade = "", ValorPadrao = 0.05, ValorMax = 0.11, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double R = inputs["Taxa transmissão"];
                        double Q = inputs["Taxa erro (QBER)"];
                        double h = Q > 0 ? -Q * Math.Log(Q, 2) - (1 - Q) * Math.Log(1 - Q, 2) : 0;
                        return R * (1 - h); // Taxa chave segura
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-014: Teorema No-Cloning
                new Formula
                {
                    Id = "3602",
                    CodigoCompendio = "V10-014",
                    Nome = "Teorema No-Cloning",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Informação Quântica",
                    Expressao = @"∄U: U|ψ⟩|0⟩ = |ψ⟩|ψ⟩",
                    Descricao = "Impossível clonar estado quântico desconhecido. Base da segurança QKD. Fidelidade máxima clonagem: F=2/3.",
                    ExemploPratico = "Impossibilidade: espionagem BB84 sempre detectável. Clonagem ótima: F=5/6 para 2 cópias. Amplificação quântica usa medição.",
                    Criador = "Wootters-Zurek, Dieks",
                    AnoOrigin = "1982",
                    VariavelResultado = "fidelidade_clonagem",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "N", Nome = "Número de cópias", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." }
 },
                    Calcular = inputs =>
                    {
                        double N = inputs["Número de cópias"];
                        return 2.0 / (N + 1.0); // Fidelidade ótima
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-015: Classe BQP
                new Formula
                {
                    Id = "3603",
                    CodigoCompendio = "V10-015",
                    Nome = "Classe de Complexidade BQP",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Complexidade Quântica",
                    Expressao = @"BQP ⊇ P; BQP ⊆ PSPACE",
                    Descricao = "BQP: problemas resolvíveis em tempo polinomial por quantum computer com erro ≤1/3. Shor e Grover estão em BQP. Relação com NP: desconhecida.",
                    ExemploPratico = "Fatoração ∈ BQP (Shor). Busca ∈ BQP (Grover). SAT ∈? BQP incerto. [BQP vs NP] = problema aberto central.",
                    Criador = "Bernstein-Vazirani",
                    AnoOrigin = "1993",
                    VariavelResultado = "probabilidade_acerto",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "p_erro", Nome = "Probabilidade erro", Unidade = "", ValorPadrao = 0.33, ValorMax = 0.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double p_erro = inputs["Probabilidade erro"];
                        return 1.0 - p_erro; // Probabilidade acerto (≥2/3)
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-016: Operador de Densidade — Estado Misto
                new Formula
                {
                    Id = "3604",
                    CodigoCompendio = "V10-016",
                    Nome = "Operador de Densidade — Estado Misto",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Formalismo de Densidade",
                    Expressao = @"ρ = Σpᵢ|ψᵢ⟩⟨ψᵢ|; Tr(ρ)=1",
                    Descricao = "Operador de densidade para estados mistos. Tr(ρ²)=1 para estado puro, <1 para misto. Entropia S=−Tr(ρ ln ρ) mede mistura. Essencial para decoerência.",
                    ExemploPratico = "Qubit com decoerência: ρ=diag(p,1−p). Qubit termalizado: ρ=I/2 (maximamente misto). Entropia: S=−p log p−(1−p)log(1−p). Densidade spin-½: S_max=1 bit.",
                    Criador = "von Neumann",
                    AnoOrigin = "1932",
                    VariavelResultado = "pureza",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "p", Nome = "Probabilidade estado |0⟩", Unidade = "", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double p = inputs["Probabilidade estado |0⟩"];
                        double pureza = p * p + (1 - p) * (1 - p); // Tr(ρ²)
                        return pureza; // 1=puro, 0.5=maximamente misto
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-017: Circuito Variacional — VQE
                new Formula
                {
                    Id = "3605",
                    CodigoCompendio = "V10-017",
                    Nome = "Algoritmo VQE — Variational Quantum Eigensolver",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Algoritmos NISQ",
                    Expressao = @"⟨E⟩ = ⟨ψ(θ)|H|ψ(θ)⟩ ≥ E₀",
                    Descricao = "VQE: otimização clássica de parâmetros θ de circuito quântico para minimizar energia. Princípio variacional: ⟨E⟩≥E₀. Aplicação: química quântica, otimização.",
                    ExemploPratico = "Molécula H₂: 4 qubits, 15 parâmetros θ. Otimização BFGS/COBYLA minimiza ⟨H⟩. NISQ: noise-intermediate scale quantum. VQE tolerante a ruído. IBM Quantum.",
                    Criador = "Peruzzo et al.",
                    AnoOrigin = "2014",
                    VariavelResultado = "energia_variacional",
                    UnidadeResultado = "eV",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "E0", Nome = "Energia fundamental", Unidade = "eV", ValorPadrao = -1.137, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "delta", Nome = "Excesso variacional", Unidade = "eV", ValorPadrao = 0.05, ValorMin = 0, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E0 = inputs["Energia fundamental"];
                        double delta = inputs["Excesso variacional"];
                        return E0 + delta; // ⟨E⟩ ≥ E₀
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-018: Vantagem Quântica — Supremacia
                new Formula
                {
                    Id = "3606",
                    CodigoCompendio = "V10-018",
                    Nome = "Vantagem Quântica — Quantum Supremacy",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Marcos Experimentais",
                    Expressao = @"T_clássico/T_quântico > 10⁶",
                    Descricao = "Google Sycamore (2019): amostragem de circuito aleatório em 200s vs ~10.000 anos clássico. Supremacia: tarefa específica, não necessariamente útil. Debate: simulações clássicas melhoradas.",
                    ExemploPratico = "Sycamore: 53 qubits, profundidade 20, 200s. Summit supercomputer: estimado 10.000 anos. Refutado parcialmente: novas simulações em 2.5 dias. Vantagem quântica prática: ainda em aberto.",
                    Criador = "Arute et al. (Google)",
                    AnoOrigin = "2019",
                    VariavelResultado = "razão_speedup",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "T_classico", Nome = "Tempo clássico", Unidade = "s", ValorPadrao = 315360000, Descricao = "Parâmetro de entrada." }, // 10.000 anos
                        new Variavel { Simbolo = "T_quantico", Nome = "Tempo quântico", Unidade = "s", ValorPadrao = 200, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double tClass = inputs["Tempo clássico"];
                        double tQuant = inputs["Tempo quântico"];
                        return tClass / tQuant; // Razão de speedup
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-019: Entropia de Von Neumann
                new Formula
                {
                    Id = "3607",
                    CodigoCompendio = "V10-019",
                    Nome = "Entropia de Von Neumann",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Teoria da Informação Quântica",
                    Expressao = @"S(ρ) = −Tr(ρ log₂ ρ) = −Σλᵢ log₂ λᵢ",
                    Descricao = "S(ρ): entropia de estado quântico ρ. λᵢ são autovalores de ρ. S=0: estado puro. S=log d: maximamente misto (d=dimensão). Emaranhamento: S(subsistema).",
                    ExemploPratico = "Bell state |Φ⁺⟩: sistema total S=0 (puro). Subsistema A: S=1 ebit (máximo para 1 qubit). Emaranhamento medido por S_red=S(Tr_B ρ_AB). Página curve black hole.",
                    Criador = "von Neumann",
                    AnoOrigin = "1932",
                    VariavelResultado = "entropia",
                    UnidadeResultado = "bits",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "lambda1", Nome = "Autovalor λ₁", Unidade = "", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "lambda2", Nome = "Autovalor λ₂", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda1 = inputs["Autovalor λ₁"];
                        double lambda2 = inputs["Autovalor λ₂"];
                        double S = 0;
                        if (lambda1 > 1e-10) S += -lambda1 * Math.Log(lambda1, 2);
                        if (lambda2 > 1e-10) S += -lambda2 * Math.Log(lambda2, 2);
                        return S; // Entropia em bits
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-020: Protocolo de Teleportação Quântica
                new Formula
                {
                    Id = "3608",
                    CodigoCompendio = "V10-020",
                    Nome = "Protocolo de Teleportação Quântica",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Protocolos de Comunicação",
                    Expressao = @"3 qubits: |ψ⟩ + EPR → medida Bell → 2 bits clássicos → Bob recupera |ψ⟩",
                    Descricao = "Teleportação: transmitir estado quântico |ψ⟩ usando par EPR + 2 bits clássicos. NÃO transmite informação superluminal. Fidelidade=1 com estado de Bell perfeito.",
                    ExemploPratico = "Alice mede par Bell em (qubit, EPR_A). Bob aplica operações X,Z condicionadas aos 2 bits clássicos. Resultado: Bob obtém |ψ⟩. 1998: Bouwmeester, experimento fotônico. 2022: Caltech Internet quântica.",
                    Criador = "Bennett et al.",
                    AnoOrigin = "1993",
                    VariavelResultado = "fidelidade_teleportacao",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "F_EPR", Nome = "Fidelidade do par EPR", Unidade = "", ValorPadrao = 0.98, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "eficiencia", Nome = "Eficiência canal", Unidade = "", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double F_EPR = inputs["Fidelidade do par EPR"];
                        double eficiencia = inputs["Eficiência canal"];
                        return F_EPR * eficiencia; // Fidelidade total
                    },
                    Icone = "⚛️",
                    Unidades = "",
                },

                // V10-021: Erro de Decoerência — Lindblad
                new Formula
                {
                    Id = "3609",
                    CodigoCompendio = "V10-021",
                    Nome = "Equação de Lindblad — Master Equation",
                    Categoria = "Computação Quântica",
                    SubCategoria = "Decoerência e Ruído",
                    Expressao = @"dρ/dt = −i/ℏ[H,ρ] + Σγₖ(LₖρLₖ†−½{Lₖ†Lₖ,ρ})",
                    Descricao = "Lindblad: equação mestra para evolução de ρ aberto. Lₖ=operadores de Lindblad (colapso), γₖ=taxas de decoerência. Descreve T₁ (relaxação) e T₂ (defasagem).",
                    ExemploPratico = "T₁ (amplitude damping): L₁=σ₋/√T₁. T₂* (pure dephasing): L₂=σ_z/√(2T₂*). Coerência decai: e^{−t/T₂}. IBM qubit: T₁~100μs, T₂~50μs. Trapped ion: T₁~1h.",
                    Criador = "Lindblad",
                    AnoOrigin = "1976",
                    VariavelResultado = "coerência_remanescente",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Simbolo = "t", Nome = "Tempo", Unidade = "μs", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Simbolo = "T2", Nome = "Tempo T₂", Unidade = "μs", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double t = inputs["Tempo"];
                        double T2 = inputs["Tempo T₂"];
                        return Math.Exp(-t / T2); // Coerência decai exponencialmente
                    },
                    Icone = "⚛️",
                    Unidades = "",
                }
            });
        }
    }
}
