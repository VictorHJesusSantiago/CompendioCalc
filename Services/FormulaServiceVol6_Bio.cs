using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 6 — PARTE V: BIOLOGIA & NEUROCIÊNCIA (Seções 16-17)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 16. BIOLOGIA SINTÉTICA, scRNA-seq E DOCKING MOLECULAR
    // ─────────────────────────────────────────────────────
    private void AdicionarBiologiaSintetica()
    {
        _formulas.AddRange([
            // 16.1 Biologia Sintética
            new Formula
            {
                Id = "6_bs01", Nome = "Repressilador (Toggle Switch)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Biologia Sintética",
                Expressao = "dm_i/dt = α/(1+(p_j/K)^n) - δ_m m_i;  dp_i/dt = β m_i - δ_p p_i",
                ExprTexto = "Repressilador: dm/dt = α/(1+(p/K)ⁿ) − δm; 3 genes em anel de repressão",
                Icone = "⟳",
                Descricao = "Repressilador: circuito sintético com 3 repressores em anel → oscilações. Hill function α/(1+(p/K)^n) modela repressão cooperativa. Base da biologia sintética.",
                Criador = "Michael Elowitz / Stanislas Leibler",
                AnoOrigin = "2000",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_bs02", Nome = "Toggle Switch Genético", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Biologia Sintética",
                Expressao = "du/dt = α₁/(1+v^β) - u;  dv/dt = α₂/(1+u^γ) - v",
                ExprTexto = "Toggle: du/dt = α₁/(1+v^β)−u; dv/dt = α₂/(1+u^γ)−v; biestável",
                Icone = "⇌",
                Descricao = "Toggle switch genético: dois genes mutuamente repressivos criam biestabilidade. Chave booleana fundamental em circuitos genéticos sintéticos. Controle externo por indutor.",
                Criador = "Timothy Gardner / Charles Cantor / James Collins",
                AnoOrigin = "2000",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_bs03", Nome = "Função de Hill (Gene Regulation)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Biologia Sintética",
                Expressao = "f(x) = x^n/(K^n + x^n) (ativação);  f(x) = K^n/(K^n+x^n) (repressão)",
                ExprTexto = "Hill: f = xⁿ/(Kⁿ+xⁿ); n = cooperatividade, K = EC50",
                Icone = "Kd",
                Descricao = "Função de Hill: modela regulação gênica cooperativa. n = coeficiente de Hill (cooperatividade), K = concentração de meia-ativação. Base de circuitos genetic logic.",
                Criador = "Archibald Hill",
                AnoOrigin = "1910",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_bs04", Nome = "CRISPR Kinetics", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Biologia Sintética",
                Expressao = "dI/dt = k_on·Cas9·gRNA - k_off·I;  dE/dt = k_cut·I - k_rep·E",
                ExprTexto = "CRISPR: dI/dt = kon·Cas9·gRNA−koff·I; edição com taxa kcut",
                Icone = "Cas",
                Descricao = "Cinética de CRISPR-Cas9: formação do complexo (kon/koff), corte do DNA (kcut) e reparo (krep). Eficiência depende de concentração, afinidade do gRNA e acessibilidade do locus.",
                Criador = "Jennifer Doudna / Emmanuelle Charpentier / Feng Zhang",
                AnoOrigin = "2012",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "kon", Nome = "kon", ValorPadrao = 2 }, new() { Simbolo = "Cas9", Nome = "Cas9", ValorPadrao = 3 }, new() { Simbolo = "gRNA", Nome = "gRNA", ValorPadrao = 4 } ],
                VariavelResultado = "dt",
                UnidadeResultado = "",
                Calcular = vars => vars["kon"] * vars["Cas9"] * vars["gRNA"]
            },
            new Formula
            {
                Id = "6_bs05", Nome = "Gibson Assembly (Recombinação)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Biologia Sintética",
                Expressao = "Eficiência ∝ overlap^n / (1 + e^{-k(T-Tm)});  overlap ≥ 20bp",
                ExprTexto = "Gibson: eficiência ∝ tamanho overlap / Tm matching; assembly isotérmico",
                Icone = "GA",
                Descricao = "Gibson Assembly: montagem isotérmica de fragmentos de DNA com overhangs. Combina exonuclease + polimerase + ligase. Eficiência depende de overlap (≥20bp) e Tm.",
                Criador = "Daniel Gibson",
                AnoOrigin = "2009",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_bs06", Nome = "Stochastic Gene Expression (Gillespie)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Biologia Sintética",
                Expressao = "τ = -ln(r₁)/a₀;  j: min j t.q. Σᵢ₌₁ʲ aᵢ > r₂·a₀",
                ExprTexto = "Gillespie SSA: τ = −ln(r₁)/a₀; escolhe reação j por r₂·a₀",
                Icone = "SSA",
                Descricao = "Algoritmo de Gillespie (SSA): simula master equation estocástica exatamente. Tempo até próxima reação exponencial, tipo de reação proporcional à propensidade. Ruído gênico.",
                Criador = "Daniel Gillespie",
                AnoOrigin = "1977",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },

            // 16.2 scRNA-seq
            new Formula
            {
                Id = "6_sc01", Nome = "Normalização por Profundidade (CPM)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "CPM_ij = (x_ij / Σ_g x_gj) × 10⁶;  normaliza por biblioteca",
                ExprTexto = "CPM: contagens por milhão = (xij/total_j)·10⁶",
                Icone = "CPM",
                Descricao = "Counts per million: normalização básica de scRNA-seq dividindo contagens pelo total da célula. Remove viés de profundidade de sequenciamento. Aplicado antes de log-transform.",
                Criador = "Comunidade bioinformática",
                AnoOrigin = "2014",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_sc02", Nome = "SCTransform (Pearson Residuals)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "z_ij = (x_ij - μ_ij)/σ_ij;  log μ = β₀ + β₁ log(n_j) (GLM NB)",
                ExprTexto = "SCTransform: Pearson residuals de GLM Neg-Binomial; estabiliza variância",
                Icone = "SC",
                Descricao = "SCTransform: regulariza scRNA-seq via GLM Negative Binomial regredido em profundidade. Pearson residuals estabilizam variância. Melhor que log(CPM+1) para PCA/clustering.",
                Criador = "Christoph Hafemeister / Rahul Satija",
                AnoOrigin = "2019",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_sc03", Nome = "UMAP (Dimensionality Reduction)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "L = Σ_{e} [w_h log(w_h/w_l) + (1-w_h)log((1-w_h)/(1-w_l))]",
                ExprTexto = "UMAP: CE entre grafo high-dim (wh) e low-dim (wl); preserva topologia",
                Icone = "U",
                Descricao = "UMAP: redução de dimensionalidade via cross-entropy fuzzy-simplicial. Preserva estrutura local e global de single-cell data. Mais rápido que tSNE, diferenciável.",
                Criador = "Leland McInnes / John Healy / James Melville",
                AnoOrigin = "2018",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "6_sc04", Nome = "Leiden Clustering", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "Q = (1/2m) Σ_{ij}[A_ij - k_ik_j/(2m)] δ(c_i,c_j);  max Q",
                ExprTexto = "Leiden: maximiza modularidade Q no grafo kNN das células",
                Icone = "Q",
                Descricao = "Algoritmo de Leiden: clustering por maximização de modularidade em grafo kNN. Melhoria do Louvain com garantia de comunidades conexas. Padrão em single-cell.",
                Criador = "V.A. Traag / L. Waltman / N.J. van Eck",
                AnoOrigin = "2019",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_sc05", Nome = "RNA Velocity", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "ds/dt = α - βs;  du/dt = βs - γu;  velocity = du/dt",
                ExprTexto = "Velocity: ds/dt = α−βs (spliced); du/dt = βs−γu (unspliced)",
                Icone = "→",
                Descricao = "RNA velocity: infere direção de diferenciação celular pela razão spliced/unspliced mRNA. Estima derivada temporal da expressão. Visualiza trajetórias em UMAP.",
                Criador = "Gioele La Manno / Velocyto team",
                AnoOrigin = "2018",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "α", Nome = "α", ValorPadrao = 10 }, new() { Simbolo = "βs", Nome = "βs", ValorPadrao = 5 } ],
                VariavelResultado = "dt",
                UnidadeResultado = "",
                Calcular = vars => vars["α"] - vars["βs"]
            },
            new Formula
            {
                Id = "6_sc06", Nome = "Diffusion Pseudotime", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "DPT(x,y) = ‖ψ(x)-ψ(y)‖;  ψ = eigvecs do kernel de difusão",
                ExprTexto = "DPT: distância de difusão ‖ψ(x)−ψ(y)‖; ordena células por pseudotime",
                Icone = "ψ",
                Descricao = "Diffusion pseudotime: ordena células ao longo de trajetórias de diferenciação usando distância de difusão no espaço de expressão. Baseado em eigenvectors do grafo.",
                Criador = "Laleh Haghverdi / Maren Büttner / Fabian Theis",
                AnoOrigin = "2016",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_sc07", Nome = "Cell-Cell Communication (CellChat)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "P_ij = √(L_i · R_j · Co_j) / (K_h + √(L_i · R_j · Co_j))",
                ExprTexto = "CellChat: P = √(L·R·Co)/(Kh+√(L·R·Co)); probabilidade de comunicação",
                Icone = "📡",
                Descricao = "CellChat: infere comunicação célula-célula de scRNA-seq via expressão de ligante L, receptor R e co-fatores. Probabilidade segue Hill function. Network de sinalização.",
                Criador = "Suoqin Jin / Qing Nie",
                AnoOrigin = "2021",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "6_sc08", Nome = "Doublet Detection (Scrublet)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "scRNA-seq",
                Expressao = "score_d = k_sim/(k_sim+k_obs);  simulados = soma aleatória de 2 células",
                ExprTexto = "Scrublet: score = kNN_simulados/(kNN_sim+kNN_obs); detecta multiplets",
                Icone = "2x",
                Descricao = "Scrublet: detecta doublets simulando combinações e comparando vizinhanças kNN. Score alto = célula provavelmente é doublet artificial. QC essencial em scRNA-seq.",
                Criador = "Samuel Wolock / Romain Lopez / Allon Klein",
                AnoOrigin = "2019",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },

            // 16.3 Docking Molecular
            new Formula
            {
                Id = "6_dk01", Nome = "Scoring Function (AutoDock)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Docking Molecular",
                Expressao = "ΔG = ΔG_vdW + ΔG_hbond + ΔG_elec + ΔG_desolv + ΔG_tors",
                ExprTexto = "AutoDock: ΔG = vdW + H-bond + eletrostático + dessolvatação + torsional",
                Icone = "ΔG",
                Descricao = "Scoring function de docking: estima energia livre de ligação como soma de termos van der Waals, hydrogen bonds, eletrostática, dessolvatação e entropia torsional.",
                Criador = "Arthur Olson / Garrett Morris",
                AnoOrigin = "1998",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "vdW", Nome = "vdW", ValorPadrao = 10 }, new() { Simbolo = "H", Nome = "H", ValorPadrao = 5 } ],
                VariavelResultado = "ΔG",
                UnidadeResultado = "",
                Calcular = vars => vars["vdW"] + vars["H"]
            },
            new Formula
            {
                Id = "6_dk02", Nome = "RMSD de Pose (Docking)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Docking Molecular",
                Expressao = "RMSD = √((1/N)Σᵢ|rᵢ_pred - rᵢ_ref|²);  sucesso se RMSD < 2Å",
                ExprTexto = "RMSD = √(Σ|ri_pred−ri_ref|²/N); pose correta se < 2Å",
                Icone = "Å",
                Descricao = "RMSD de pose: mede qualidade do docking molecular comparando posição atômica predita vs cristalográfica. RMSD<2Å = pose correta. Métrica padrão de validação.",
                Criador = "Comunidade de docking molecular",
                AnoOrigin = "2000",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 4, ValorMin = 0 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => Math.Sqrt(vars["x"])
            },
            new Formula
            {
                Id = "6_dk03", Nome = "Lennard-Jones (Interação VdW)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Docking Molecular",
                Expressao = "V(r) = 4ε[(σ/r)^12 - (σ/r)^6];  r_min = 2^{1/6}σ",
                ExprTexto = "LJ: V = 4ε·[(σ/r)¹² − (σ/r)⁶]; repulsão r⁻¹² + atração r⁻⁶",
                Icone = "LJ",
                Descricao = "Potencial de Lennard-Jones: modela interação van der Waals (atração r⁻⁶) e repulsão de Pauli (r⁻¹²). ε = profundidade do poço, σ = diâmetro efetivo. Base de MD e docking.",
                Criador = "John Lennard-Jones",
                AnoOrigin = "1924",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_dk04", Nome = "Constante de Inibição (Ki)", Categoria = "Biologia Sintética e scRNA-seq", SubCategoria = "Docking Molecular",
                Expressao = "Ki = exp(ΔG/(RT));  IC₅₀ ≈ Ki(1+[S]/Km) (Cheng-Prusoff)",
                ExprTexto = "Ki = exp(ΔG/RT); IC₅₀ ≈ Ki·(1+[S]/Km) relação Cheng-Prusoff",
                Icone = "Ki",
                Descricao = "Constante de inibição Ki: derivada da energia livre de ligação. Equação de Cheng-Prusoff relaciona IC₅₀ experimental ao Ki. Menor Ki = maior afinidade do inibidor.",
                Criador = "Yung-Chi Cheng / William Prusoff",
                AnoOrigin = "1973",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 17. RADIOBIOLOGIA, fMRI E CRONOBIOLOGIA
    // ─────────────────────────────────────────────────────
    private void AdicionarRadiobiologiaFMRI()
    {
        _formulas.AddRange([
            // 17.1 Radiobiologia
            new Formula
            {
                Id = "6_rb01", Nome = "Modelo Linear-Quadrático (LQ)", Categoria = "Radiobiologia e fMRI", SubCategoria = "Radiobiologia",
                Expressao = "S = exp(-αD - βD²);  α/β típico: 10 Gy (tumor), 3 Gy (tecido tardio)",
                ExprTexto = "LQ: S = exp(−αD−βD²); sobrevivência celular após dose D",
                Icone = "LQ",
                Descricao = "Modelo LQ de radiobiologia: fração de sobrevivência celular após dose D de radiação. α = dano letal simples, β = dano subletal reparável. Base do fracionamento.",
                Criador = "Douglas Lea / K.H. Chadwick / H.P. Leenhouts",
                AnoOrigin = "1946",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            new Formula
            {
                Id = "6_rb02", Nome = "BED (Biological Effective Dose)", Categoria = "Radiobiologia e fMRI", SubCategoria = "Radiobiologia",
                Expressao = "BED = nd(1 + d/(α/β));  EQD2 = BED/(1+2/(α/β))",
                ExprTexto = "BED = n·d·(1+d/(α/β)); dose biológica efetiva para n frações de dose d",
                Icone = "BED",
                Descricao = "Dose biológica efetiva: compara esquemas de fracionamento. n frações de dose d. EQD2 converte para equivalente em 2Gy/fração. Planejamento de radioterapia.",
                Criador = "Jack Fowler",
                AnoOrigin = "1989",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "n", Nome = "n", ValorPadrao = 5 }, new() { Simbolo = "d", Nome = "d", ValorPadrao = 3 } ],
                VariavelResultado = "BED",
                UnidadeResultado = "",
                Calcular = vars => vars["n"] * vars["d"]
            },
            new Formula
            {
                Id = "6_rb03", Nome = "TCP (Tumor Control Probability)", Categoria = "Radiobiologia e fMRI", SubCategoria = "Radiobiologia",
                Expressao = "TCP = exp(-N₀·S(D)) = exp(-N₀·exp(-αD-βD²))",
                ExprTexto = "TCP = exp(−N₀·exp(−αD−βD²)); probabilidade de controle tumoral",
                Icone = "TCP",
                Descricao = "TCP: probabilidade de que nenhuma célula tumoral sobreviva. Modelo Poissoniano: N₀ células iniciais × sobrevivência S(D). Objetivo: TCP>90% com dose tolerável.",
                Criador = "Jack Fowler / Søren Bentzen",
                AnoOrigin = "1992",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
            new Formula
            {
                Id = "6_rb04", Nome = "NTCP (Normal Tissue Complication)", Categoria = "Radiobiologia e fMRI", SubCategoria = "Radiobiologia",
                Expressao = "NTCP = (1/√2π)∫_{-∞}^t exp(-x²/2)dx;  t = (D-TD₅₀)/(m·TD₅₀)",
                ExprTexto = "NTCP = Φ((D−TD₅₀)/(m·TD₅₀)); complicação tecido normal sigmoidal",
                Icone = "NTCP",
                Descricao = "NTCP Lyman: probabilidade de complicação em tecido normal. Sigmoidal centrada em TD₅₀ (dose 50% complicação). Parâmetro m = inclinação. Limita dose de tratamento.",
                Criador = "John Lyman",
                AnoOrigin = "1985",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_rb05", Nome = "Fórmula dos 4 Rs da Radiobiologia", Categoria = "Radiobiologia e fMRI", SubCategoria = "Radiobiologia",
                Expressao = "Reparo: S_f = 1-(1-exp(-αD))(1-exp(-β_eff D²));  Reoxigenação: OER ≈ 2.5-3.0",
                ExprTexto = "4Rs: Reparo, Redistribuição, Reoxigenação, Repopulação; OER ≈ 2.5–3",
                Icone = "4R",
                Descricao = "4Rs da radioterapia fracionada: Reparo (dano subletal entre frações), Redistribuição (células em fases sensíveis), Reoxigenação (tumor reoxigena), Repopulação (tumor cresce).",
                Criador = "H.R. Withers",
                AnoOrigin = "1975",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },

            // 17.2 fMRI e Neuroimagem
            new Formula
            {
                Id = "6_fi01", Nome = "Sinal BOLD (fMRI)", Categoria = "Radiobiologia e fMRI", SubCategoria = "fMRI e Neuroimagem",
                Expressao = "ΔS/S ≈ TE·Δ(1/T₂*);  T₂* ∝ 1/(1-Y) com Y = fração oxi-Hb",
                ExprTexto = "BOLD: ΔS/S ∝ TE·Δ(1/T₂*); T₂* aumenta com oxigenação Y",
                Icone = "fMRI",
                Descricao = "Sinal BOLD: atividade neural → aumento de fluxo sanguíneo → mais oxi-Hb → aumento de T₂* → sinal MRI mais brilhante. Efeito indireto de ~1-5% ΔS/S a 3T.",
                Criador = "Seiji Ogawa",
                AnoOrigin = "1990",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_fi02", Nome = "Hemodynamic Response Function (HRF)", Categoria = "Radiobiologia e fMRI", SubCategoria = "fMRI e Neuroimagem",
                Expressao = "h(t) = (t/τ₁)^a₁ exp(-t/τ₁)/Γ(a₁) - c(t/τ₂)^a₂ exp(-t/τ₂)/Γ(a₂)",
                ExprTexto = "HRF: double-gamma h(t) = pico ~6s + undershoot ~16s",
                Icone = "h(t)",
                Descricao = "HRF canonical: modela resposta BOLD como double-gamma. Pico em ~5-6s, undershoot em ~15-16s. Convolução com estímulo para modelar sinal BOLD esperado (GLM).",
                Criador = "Gary Glover / Karl Friston / SPM",
                AnoOrigin = "1999",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_fi03", Nome = "GLM do fMRI", Categoria = "Radiobiologia e fMRI", SubCategoria = "fMRI e Neuroimagem",
                Expressao = "Y = Xβ + ε;  X = convol(estímulos, HRF);  t = cᵀβ̂/√(cᵀ(XᵀX)⁻¹cσ̂²)",
                ExprTexto = "GLM: Y = Xβ+ε; X = estímulos⊗HRF; estatística t = cᵀβ̂/se",
                Icone = "GLM",
                Descricao = "GLM de fMRI: modelo linear geral com design matrix X = estímulos convoluídos com HRF. Inferência sobre contraste cᵀβ por estatística t. Correção FWE/FDR para múltiplas comparações.",
                Criador = "Karl Friston / Keith Worsley",
                AnoOrigin = "1995",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "Xβ", Nome = "Xβ", ValorPadrao = 10 }, new() { Simbolo = "ε", Nome = "ε", ValorPadrao = 5 } ],
                VariavelResultado = "Y",
                UnidadeResultado = "",
                Calcular = vars => vars["Xβ"] + vars["ε"]
            },
            new Formula
            {
                Id = "6_fi04", Nome = "DCM (Dynamic Causal Modeling)", Categoria = "Radiobiologia e fMRI", SubCategoria = "fMRI e Neuroimagem",
                Expressao = "dz/dt = (A + Σⱼ u_j B_j)z + Cu;  y = λ(z) + ε",
                ExprTexto = "DCM: dz/dt = (A+Σ uj·Bj)·z + C·u; conectividade efetiva entre regiões",
                Icone = "DCM",
                Descricao = "DCM: modela conectividade efetiva entre regiões cerebrais. A = conectividade fixa, Bj = modulação por tarefa, C = input externo. Estimado por variational Bayes.",
                Criador = "Karl Friston / Lee Harrison / Will Penny",
                AnoOrigin = "2003",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_fi05", Nome = "Equação de Bloch (MRI Básico)", Categoria = "Radiobiologia e fMRI", SubCategoria = "fMRI e Neuroimagem",
                Expressao = "dM/dt = γM×B - (Mx x̂+My ŷ)/T₂ - (Mz-M₀)ẑ/T₁",
                ExprTexto = "Bloch: dM/dt = γM×B − Mxy/T₂ − (Mz−M₀)/T₁; precessão + relaxação",
                Icone = "M",
                Descricao = "Equação de Bloch: dinâmica da magnetização nuclear em MRI. Precessão em B₀+gradientes, relaxação T₁ (spin-lattice) e T₂ (spin-spin). Gera contraste de tecidos.",
                Criador = "Felix Bloch",
                AnoOrigin = "1946",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "γM", Nome = "γM", ValorPadrao = 5 }, new() { Simbolo = "B", Nome = "B", ValorPadrao = 3 } ],
                VariavelResultado = "dt",
                UnidadeResultado = "",
                Calcular = vars => vars["γM"] * vars["B"]
            },
            new Formula
            {
                Id = "6_fi06", Nome = "DTI (Diffusion Tensor Imaging)", Categoria = "Radiobiologia e fMRI", SubCategoria = "fMRI e Neuroimagem",
                Expressao = "S = S₀ exp(-b·gᵀDg);  D = [Dxx Dxy Dxz; ... ];  FA = √(3/2)·‖D-⟨D⟩I‖/‖D‖",
                ExprTexto = "DTI: S = S₀·exp(−b·gᵀDg); FA = anisotropia fracionária de D",
                Icone = "FA",
                Descricao = "DTI: mede difusão direcional da água no cérebro. Tensor D (6 componentes). FA = anisotropia fracionária (0=isotrópico, 1=anisotrópico). Rastreia tratos de substância branca.",
                Criador = "Peter Basser / James Mattiello / Denis Le Bihan",
                AnoOrigin = "1994",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "S₀", Nome = "S₀", ValorPadrao = 5 }, new() { Simbolo = "exp", Nome = "exp", ValorPadrao = 3 } ],
                VariavelResultado = "S",
                UnidadeResultado = "",
                Calcular = vars => vars["S₀"] * vars["exp"]
            },

            // 17.3 Cronobiologia
            new Formula
            {
                Id = "6_cb01", Nome = "Oscilador Circadiano (Goodwin)", Categoria = "Radiobiologia e fMRI", SubCategoria = "Cronobiologia",
                Expressao = "dX/dt = v₁K^n/(K^n+Z^n) - v₂X/(K₂+X);  dY/dt = k₃X - v₄Y/(K₄+Y);  dZ/dt = k₅Y - v₆Z/(K₆+Z)",
                ExprTexto = "Goodwin: 3 variáveis com feedback negativo → oscilação ~24h",
                Icone = "☾",
                Descricao = "Modelo de Goodwin: circuito de feedback negativo com 3 variáveis (mRNA, proteína, repressor). Gera oscilações quando cooperatividade n≥8. Modelo mínimo de ritmo circadiano.",
                Criador = "Brian Goodwin",
                AnoOrigin = "1965",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_cb02", Nome = "Phase Response Curve (PRC)", Categoria = "Radiobiologia e fMRI", SubCategoria = "Cronobiologia",
                Expressao = "Δφ = PRC(φ_estímulo);  avanço (Δφ>0) ou atraso (Δφ<0) de fase",
                ExprTexto = "PRC: Δφ = f(φ_estímulo); resposta de fase a estímulo luminoso",
                Icone = "PRC",
                Descricao = "PRC: curva que mapeia quando um estímulo (luz, fármaco) adianta ou atrasa o relógio circadiano. Tipo 0 (forte) vs Tipo 1 (fraco). Essencial para tratar jet lag.",
                Criador = "Colin Pittendrigh",
                AnoOrigin = "1960",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "6_cb03", Nome = "Zeitgeber Strength K", Categoria = "Radiobiologia e fMRI", SubCategoria = "Cronobiologia",
                Expressao = "dφ/dt = ω + K·sin(Ω t - φ);  ω = freq. natural, Ω = zeitgeber",
                ExprTexto = "Entrainment: dφ/dt = ω + K·sin(Ωt−φ); K = força do zeitgeber",
                Icone = "K",
                Descricao = "Modelo de entrainment: oscilador circadiano (ω) se sincroniza ao zeitgeber externo (Ω) se K suficiente e |ω−Ω| pequeno. Região de Arnold tongue para captura de fase.",
                Criador = "Arthur Winfree / Steven Strogatz",
                AnoOrigin = "1980",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "ω", Nome = "ω", ValorPadrao = 10 }, new() { Simbolo = "K", Nome = "K", ValorPadrao = 5 } ],
                VariavelResultado = "dt",
                UnidadeResultado = "",
                Calcular = vars => vars["ω"] + vars["K"]
            },
            new Formula
            {
                Id = "6_cb04", Nome = "Modelo de 2 Processos do Sono", Categoria = "Radiobiologia e fMRI", SubCategoria = "Cronobiologia",
                Expressao = "S(t) = S₀ exp(-t/τ_w) (vigília);  S(t) = S_∞ + (S₀-S_∞)exp(-t/τ_s) (sono)",
                ExprTexto = "Borbély: S cresce exponencial na vigília, decai no sono; portão C circadiano",
                Icone = "💤",
                Descricao = "Modelo de Borbély: processo S (homeostático) acumula pressão de sono na vigília e decai no sono. Processo C (circadiano) modula limiar. Sono ocorre quando S>C.",
                Criador = "Alexander Borbély",
                AnoOrigin = "1982",
                ExemploPratico = "Utilize os valores padrão para calcular o resultado.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Resultado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
        ]);
    }
}
