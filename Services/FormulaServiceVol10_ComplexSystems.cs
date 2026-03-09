using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE IV
    /// SISTEMAS COMPLEXOS, REDES E CIÊNCIA DAS REDES
    /// Fórmulas V10-062 a V10-081 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_ComplexSystems()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3650",
                    CodigoCompendio = "V10-062",
                    Nome = "Coeficiente de Agrupamento (Clustering)",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Redes Complexas",
                    Expressao = @"C = (3×Triângulos)/(Tripletas conectadas)",
                    Descricao = "Mede transitividade em redes: se A→B e B→C, probabilidade de A→C. Redes randômicas: C_rand≈⟨k⟩/N. Small-world: C_sw>>C_rand.",
                    ExemploPratico = "Facebook: C≈0.6. Grafo aleatório N=1000, ⟨k⟩=10: C_rand≈0.01. C-elegans: C≈0.28.",
                    Criador = "Watts e Strogatz (1998, Nature)",
                    AnoOrigin = "1998",
                    VariavelResultado = "coef_clustering",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Triângulos", Simbolo = "T", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Tripletas conectadas", Simbolo = "Tr", Unidade = "", ValorPadrao = 500 }
                    },
                    Calcular = inputs =>
                    {
                        double triangulos = inputs["Triângulos"];
                        double tripletas = inputs["Tripletas conectadas"];
                        double C = (3 * triangulos) / Math.Max(tripletas, 1);
                        return C;
                    },
                    Icone = "🌐"
                },

                // V10-063: Distância Característica (Small-World)
                new Formula
                {
                    Id = "3651",
                    CodigoCompendio = "V10-063",
                    Nome = "Distância Característica — Average Path Length",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Small-World Networks",
                    Expressao = @"L = (1/(N(N−1)))·Σᵢⱼ d(i,j)",
                    Descricao = "Média de distâncias entre todos pares de nós. Small-world: L~log(N). Scale-free: L~log(log(N)). Internet: L≈19 (bilhões de nós). Erdős número: L≈5.",
                    ExemploPratico = "Facebook (1 bi usuários): L≈4.7 ('six degrees of separation'). Rede aleatória N=1000, ⟨k⟩=10: L≈log(N)/log(⟨k⟩)≈3. C-elegans: L≈2.65.",
                    Criador = "Watts-Strogatz (1998); Milgram (1967, experimento 'small world')",
                    AnoOrigin = "1998",
                    VariavelResultado = "L",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Soma distâncias", Simbolo = "sum_d", Unidade = "", ValorPadrao = 5000 },
                        new Variavel { Nome = "N nós", Simbolo = "N", Unidade = "", ValorPadrao = 100 }
                    },
                    Calcular = inputs =>
                    {
                        double sum_d = inputs["Soma distâncias"];
                        double N = inputs["N nós"];
                        if (N <= 1) return 0;
                        double L = sum_d / (N * (N - 1));
                        return L;
                    },
                    Icone = "🌐"
                },

                // V10-064: Distribuição de Grau — Scale-Free
                new Formula
                {
                    Id = "3652",
                    CodigoCompendio = "V10-064",
                    Nome = "Distribuição Scale-Free — Lei de Potência",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Redes Scale-Free",
                    Expressao = @"P(k) = Ck^−γ; γ: expoente",
                    Descricao = "Redes scale-free: poucos hubs (alto grau), muitos nós com baixo grau. γ entre 2 e 3 típico. Internet AS-level: γ≈2.2. WWW: γ≈2.1 (in-degree), γ≈2.7 (out).",
                    ExemploPratico = "Barabási-Albert: γ=3 (preferential attachment). Citações científicas: γ≈3. Proteínas: γ≈2.5. γ>3: menos hubs, γ<2: impossível normalizar.",
                    Criador = "Barabási e Albert (1999, Science)",
                    AnoOrigin = "1999",
                    VariavelResultado = "P_k",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Grau k", Simbolo = "k", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "Expoente γ", Simbolo = "γ", Unidade = "", ValorPadrao = 2.5 },
                        new Variavel { Nome = "Constante C", Simbolo = "C", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double k = inputs["Grau k"];
                        double gamma = inputs["Expoente γ"];
                        double C = inputs["Constante C"];
                        if (k <= 0) return 0;
                        double P_k = C * Math.Pow(k, -gamma);
                        return P_k;
                    },
                    Icone = "🌐"
                },

                // V10-065: PageRank
                new Formula
                {
                    Id = "3653",
                    CodigoCompendio = "V10-065",
                    Nome = "PageRank — Importância de Nó",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Centralidade",
                    Expressao = @"PR(i) = (1−d)/N + d·Σⱼ PR(j)/L(j)",
                    Descricao = "Algoritmo Google. d: damping factor (~0.85). L(j): out-links do nó j. PR alto: nó importante. Eigenvector centrality: PR é autovetor da matriz de adjacência.",
                    ExemploPratico = "Página com 1000 links de páginas PR alto: PR alta. Página isolada: PR=(1−d)/N≈0.15/N. Wikipedia: páginas centrais têm PR~100× páginas periféricas.",
                    Criador = "Page e Brin (1998, Google)",
                    AnoOrigin = "1998",
                    VariavelResultado = "PR",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Damping d", Simbolo = "d", Unidade = "", ValorPadrao = 0.85 },
                        new Variavel { Nome = "N total nós", Simbolo = "N", Unidade = "", ValorPadrao = 1000 },
                        new Variavel { Nome = "Soma PR_entrada", Simbolo = "sum_PR", Unidade = "", ValorPadrao = 5 }
                    },
                    Calcular = inputs =>
                    {
                        double d = inputs["Damping d"];
                        double N = inputs["N total nós"];
                        double sum_PR = inputs["Soma PR_entrada"];
                        if (N == 0) return 0;
                        double PR = (1 - d) / N + d * sum_PR;
                        return PR;
                    },
                    Icone = "🌐"
                },

                // V10-066: Betweenness Centrality
                new Formula
                {
                    Id = "3654",
                    CodigoCompendio = "V10-066",
                    Nome = "Betweenness Centrality — Intermediação",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Centralidade",
                    Expressao = @"BC(v) = Σₛₜ (σₛₜ(v)/σₛₜ)",
                    Descricao = "Quantifica quão frequente nó v está em caminhos mínimos. σₛₜ: número de caminhos mínimos s→t. σₛₜ(v): desses, quantos passam por v. BC alto: ponte crítica.",
                    ExemploPratico = "Aeroporto hub (Atlanta): BC alto (muitas conexões passam por ele). Pontes em rede social: removê-las fragmenta rede. Ataques direcionados: remover nós alto BC eficaz.",
                    Criador = "Freeman (1977, Sociometry)",
                    AnoOrigin = "1977",
                    VariavelResultado = "BC",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Caminhos por v", Simbolo = "sigma_v", Unidade = "", ValorPadrao = 300 },
                        new Variavel { Nome = "Caminhos totais", Simbolo = "sigma_total", Unidade = "", ValorPadrao = 1000 }
                    },
                    Calcular = inputs =>
                    {
                        double sigma_v = inputs["Caminhos por v"];
                        double sigma_total = inputs["Caminhos totais"];
                        if (sigma_total == 0) return 0;
                        double BC = sigma_v / sigma_total;
                        return BC;
                    },
                    Icone = "🌐"
                },

                // V10-067: Limiar de Percolação
                new Formula
                {
                    Id = "3655",
                    CodigoCompendio = "V10-067",
                    Nome = "Limiar de Percolação — Transição de Fase",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Percolação",
                    Expressao = @"p_c = ⟨k⟩/(⟨k²⟩−⟨k⟩); p>p_c: componente gigante",
                    Descricao = "Probabilidade crítica p_c: rede aleatória forma componente gigante. p<p_c: clusters pequenos. p>p_c: maioria nós conectados. Transição de fase de segunda ordem.",
                    ExemploPratico = "Rede aleatória ⟨k⟩=2: p_c=1/⟨k⟩=0.5. Scale-free (γ<3): p_c→0 (sempre percolam). Epidemias: R₀>1 análogo a p>p_c.",
                    Criador = "Erdős-Rényi (1960); Molloy-Reed (1995, critério generalizado)",
                    AnoOrigin = "1960",
                    VariavelResultado = "p_c",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Grau médio ⟨k⟩", Simbolo = "k_avg", Unidade = "", ValorPadrao = 2 },
                        new Variavel { Nome = "Momento ⟨k²⟩", Simbolo = "k2_avg", Unidade = "", ValorPadrao = 6 }
                    },
                    Calcular = inputs =>
                    {
                        double k_avg = inputs["Grau médio ⟨k⟩"];
                        double k2_avg = inputs["Momento ⟨k²⟩"];
                        double denom = k2_avg - k_avg;
                        if (denom <= 0) return 1;
                        double p_c = k_avg / denom;
                        return Math.Min(p_c, 1);
                    },
                    Icone = "🌐"
                },

                // V10-068: Modularidade (Comunidades)
                new Formula
                {
                    Id = "3656",
                    CodigoCompendio = "V10-068",
                    Nome = "Modularidade — Detecção de Comunidades",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Estrutura de Comunidades",
                    Expressao = @"Q = (1/(2m))·Σᵢⱼ[Aᵢⱼ − kᵢkⱼ/(2m)]·δ(cᵢ,cⱼ)",
                    Descricao = "Q mede quão bem rede é dividida em comunidades. Q>0.3: estrutura comunitária forte. m: número de arestas. δ(cᵢ,cⱼ)=1 se i,j mesma comunidade.",
                    ExemploPratico = "Rede social: Q≈0.4 (grupos amigos). Louvain algorithm maximiza Q. Rede aleatória: Q≈0. Zachary's Karate Club: Q=0.42 (2 comunidades).",
                    Criador = "Newman (2006, PNAS)",
                    AnoOrigin = "2006",
                    VariavelResultado = "Q",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Arestas intra-comunidade", Simbolo = "e_dentro", Unidade = "", ValorPadrao = 80 },
                        new Variavel { Nome = "Arestas totais", Simbolo = "m", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Fração esperada", Simbolo = "f_esp", Unidade = "", ValorPadrao = 0.25 }
                    },
                    Calcular = inputs =>
                    {
                        double e_dentro = inputs["Arestas intra-comunidade"];
                        double m = inputs["Arestas totais"];
                        double f_esp = inputs["Fração esperada"];
                        if (m == 0) return 0;
                        double Q = (e_dentro / m) - f_esp;
                        return Q;
                    },
                    Icone = "🌐"
                },

                // V10-069: Resiliência de Rede
                new Formula
                {
                    Id = "3657",
                    CodigoCompendio = "V10-069",
                    Nome = "Resiliência — Robustez a Ataques",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Robustez",
                    Expressao = @"R = S(f)/S₀; S(f): componente gigante após remover fração f",
                    Descricao = "Resiliência: fração do componente gigare after node removal. Scale-free: vulnerável a ataques direcionados (alto grau), robusto a falhas aleatórias. Random: similar para ambos.",
                    ExemploPratico = "Internet: remover 5% hubs → R≈0.4 (colapso). Remover 5% aleatório: R≈0.95 (resiliente). Power grid: híbrido (γ~4) → vulnerável a ambos.",
                    Criador = "Albert-Jeong-Barabási (2000, Nature)",
                    AnoOrigin = "2000",
                    VariavelResultado = "R",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tamanho após remoção (%)", Simbolo = "S_f", Unidade = "%", ValorPadrao = 70 },
                        new Variavel { Nome = "Tamanho original (%)", Simbolo = "S_0", Unidade = "%", ValorPadrao = 100 }
                    },
                    Calcular = inputs =>
                    {
                        double S_f = inputs["Tamanho após remoção (%)"];
                        double S_0 = inputs["Tamanho original (%)"];
                        if (S_0 == 0) return 0;
                        double R = S_f / S_0;
                        return R;
                    },
                    Icone = "🌐"
                },

                // V10-070: Assortatividade
                new Formula
                {
                    Id = "3658",
                    CodigoCompendio = "V10-070",
                    Nome = "Assortatividade — Homofilia de Grau",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Correlação de Grau",
                    Expressao = @"r = (Σⱼₖkⱼkₖ(eⱼₖ−qⱼqₖ))/σq²",
                    Descricao = "r: coeficiente de correlação de Pearson entre graus de nós conectados. r>0: assortativo (hubs conectam hubs). r<0: disassortativo. r≈0: sem correlação.",
                    ExemploPratico = "Redes sociais: r>0 (ricos conectam ricos). Internet: r≈−0.2 (hubs conectam nós baixo grau, eficiência). Proteínas: r<0.",
                    Criador = "Newman (2002, Phys. Rev. Lett.)",
                    AnoOrigin = "2002",
                    VariavelResultado = "r",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Covariância graus", Simbolo = "cov", Unidade = "", ValorPadrao = 5 },
                        new Variavel { Nome = "Variância graus", Simbolo = "var", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double cov = inputs["Covariância graus"];
                        double var = inputs["Variância graus"];
                        if (var == 0) return 0;
                        double r = cov / var;
                        return r;
                    },
                    Icone = "🌐"
                },

                // V10-071: Eficiência Global
                new Formula
                {
                    Id = "3659",
                    CodigoCompendio = "V10-071",
                    Nome = "Eficiência Global — Network Efficiency",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Eficiência",
                    Expressao = @"E_glob = (1/(N(N−1)))·Σᵢⱼ 1/d(i,j)",
                    Descricao = "Eficiência: média do inverso das distâncias. E_glob=1: grafo completo. E_glob→0: desconexo. Mede quão eficientemente info flui na rede.",
                    ExemploPratico = "Cérebro: E_glob≈0.4 (balance integração/segregação). Small-world: alto E_glob + alto clustering. Stroke: E_glob diminui.",
                    Criador = "Latora e Marchiori (2001, Phys. Rev. Lett.)",
                    AnoOrigin = "2001",
                    VariavelResultado = "E_glob",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Soma 1/d(i,j)", Simbolo = "sum_inv_d", Unidade = "", ValorPadrao = 4000 },
                        new Variavel { Nome = "N nós", Simbolo = "N", Unidade = "", ValorPadrao = 100 }
                    },
                    Calcular = inputs =>
                    {
                        double sum_inv_d = inputs["Soma 1/d(i,j)"];
                        double N = inputs["N nós"];
                        if (N <= 1) return 0;
                        double E_glob = sum_inv_d / (N * (N - 1));
                        return E_glob;
                    },
                    Icone = "🌐"
                },

                // V10-072: Rich-Club Coefficient
                new Formula
                {
                    Id = "3660",
                    CodigoCompendio = "V10-072",
                    Nome = "Rich-Club Coefficient",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Topologia",
                    Expressao = @"φ(k) = 2E>k/(N>k(N>k−1))",
                    Descricao = "Mede se hubs (grau >k) conectam entre si ('rich club'). φ alto: elite densamente conectada. φ(k)/φ_null>1: rich-club ordering.",
                    ExemploPratico = "Internet AS: φ>1 (ISPs top tier interconectados). Cérebro: hubs conectam fortemente (rich-club). Aeroportos: hubs (NY, Londres) conectados.",
                    Criador = "Colizza-Flammini-Serrano-Vespignani (2006, Nature Physics)",
                    AnoOrigin = "2006",
                    VariavelResultado = "φ",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Arestas entre hubs E>k", Simbolo = "E", Unidade = "", ValorPadrao = 30 },
                        new Variavel { Nome = "Número hubs N>k", Simbolo = "N_hub", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double E = inputs["Arestas entre hubs E>k"];
                        double N_hub = inputs["Número hubs N>k"];
                        if (N_hub <= 1) return 0;
                        double phi = (2 * E) / (N_hub * (N_hub - 1));
                        return phi;
                    },
                    Icone = "🌐"
                },

                // V10-073: Entropia de Rótulos (Label Entropy)
                new Formula
                {
                    Id = "3661",
                    CodigoCompendio = "V10-073",
                    Nome = "Entropia de Rótulos — Information theoretic",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Teoria da Informação",
                    Expressao = @"H = −Σᵢ pᵢ·log₂(pᵢ)",
                    Descricao = "Entropia de Shannon aplicada a distribuições em redes. Mede diversidade/incerteza. H=0: todos nós mesma classe. H=log₂(N): uniforme.",
                    ExemploPratico = "Comunidades: baixa entropia dentro, alta entre. Rede com 4 comunidades iguais: H=log₂(4)=2 bits. Classificação nós: H mede pureza.",
                    Criador = "Shannon (1948, teoria da informação); aplicado redes (2000s)",
                    AnoOrigin = "1948",
                    VariavelResultado = "H",
                    UnidadeResultado = "bits",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Probabilidade p1", Simbolo = "p1", Unidade = "", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Probabilidade p2", Simbolo = "p2", Unidade = "", ValorPadrao = 0.3 },
                        new Variavel { Nome = "Probabilidade p3", Simbolo = "p3", Unidade = "", ValorPadrao = 0.2 }
                    },
                    Calcular = inputs =>
                    {
                        double p1 = inputs["Probabilidade p1"];
                        double p2 = inputs["Probabilidade p2"];
                        double p3 = inputs["Probabilidade p3"];
                        
                        double H = 0;
                        if (p1 > 0) H -= p1 * Math.Log(p1, 2);
                        if (p2 > 0) H -= p2 * Math.Log(p2, 2);
                        if (p3 > 0) H -= p3 * Math.Log(p3, 2);
                        
                        return H;
                    },
                    Icone = "🌐"
                },

                // V10-074: Motifs — Subgrafos frequentes
                new Formula
                {
                    Id = "3662",
                    CodigoCompendio = "V10-074",
                    Nome = "Network Motifs — Padrões Locais",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Motifs",
                    Expressao = @"Z-score = (N_real − ⟨N_rand⟩)/σ_rand",
                    Descricao = "Motifs: subgrafos sobre-representados (Z>2). Feed-forward loop, bi-fan em redes genéticas. Z<−2: subgrafo evitado. Assinatura funcional da rede.",
                    ExemploPratico = "E.coli: feed-forward loop Z≈5 (motif regulatório). Redes sociais: triângulos Z>0 (transitividade). WWW: bi-parallel Z>0.",
                    Criador = "Milo-Shen-Itzkovitz-Kashtan-Alon (2002, Science)",
                    AnoOrigin = "2002",
                    VariavelResultado = "Z",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Contagem real", Simbolo = "N_real", Unidade = "", ValorPadrao = 50 },
                        new Variavel { Nome = "Média aleatória", Simbolo = "N_rand", Unidade = "", ValorPadrao = 30 },
                        new Variavel { Nome = "Desvio padrão", Simbolo = "σ", Unidade = "", ValorPadrao = 5 }
                    },
                    Calcular = inputs =>
                    {
                        double N_real = inputs["Contagem real"];
                        double N_rand = inputs["Média aleatória"];
                        double sigma = inputs["Desvio padrão"];
                        if (sigma == 0) return 0;
                        double Z = (N_real - N_rand) / sigma;
                        return Z;
                    },
                    Icone = "🌐"
                },

                // V10-075: Processo de Ramificação (Epidemias)
                new Formula
                {
                    Id = "3663",
                    CodigoCompendio = "V10-075",
                    Nome = "Processo de Ramificação — Número Reprodutivo",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Epidemias em Redes",
                    Expressao = @"R₀ = β·⟨k²⟩/(γ·⟨k⟩); β: taxa transmissão, γ: recuperação",
                    Descricao = "R₀: número médio de infectados por 1 caso. R₀>1: epidemia cresce. R₀<1: morre. Redes scale-free: sempre epidemia (⟨k²⟩→∞).",
                    ExemploPratico = "COVID-19 R₀≈3. Gripe R₀≈1.3. Sarampo R₀≈15. Vacinar fração f>1−1/R₀ elimina doença. Rede hub facilita spread.",
                    Criador = "Pastor-Satorras e Vespignani (2001, Phys. Rev. Lett.)",
                    AnoOrigin = "2001",
                    VariavelResultado = "R0",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Taxa transmissão β", Simbolo = "β", Unidade = "", ValorPadrao = 0.2 },
                        new Variavel { Nome = "Taxa recuperação γ", Simbolo = "γ", Unidade = "", ValorPadrao = 0.1 },
                        new Variavel { Nome = "Momento ⟨k²⟩", Simbolo = "k2", Unidade = "", ValorPadrao = 20 },
                        new Variavel { Nome = "Grau médio ⟨k⟩", Simbolo = "k", Unidade = "", ValorPadrao = 4 }
                    },
                    Calcular = inputs =>
                    {
                        double beta = inputs["Taxa transmissão β"];
                        double gamma = inputs["Taxa recuperação γ"];
                        double k2 = inputs["Momento ⟨k²⟩"];
                        double k = inputs["Grau médio ⟨k⟩"];
                        if (gamma == 0 || k == 0) return 0;
                        double R0 = (beta * k2) / (gamma * k);
                        return R0;
                    },
                    Icone = "🌐"
                },

                // V10-076: Cascading Failures
                new Formula
                {
                    Id = "3664",
                    CodigoCompendio = "V10-076",
                    Nome = "Cascading Failures — Falhas em Cascata",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Dinâmica de Falhas",
                    Expressao = @"L_fail = L₀·(1 + α)^n; n: iterações cascata",
                    Descricao = "Falha inicial sobrecarga vizinhos (carga redistribuída). α: fator sobrecarga. n iterações até estabilizar ou colapso total. Power grids, internet vulneráveis.",
                    ExemploPratico = "Blackout 2003 (EUA-Canadá): 1 linha → cascata 265 usinas, 50M pessoas. α≈0.2 típico. n=5 iterações: L_fail=2.5×L₀. Redundância previne.",
                    Criador = "Motter-Lai (2002, Phys. Rev. E)",
                    AnoOrigin = "2002",
                    VariavelResultado = "L_fail",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Carga inicial L₀", Simbolo = "L0", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Fator sobrecarga α", Simbolo = "α", Unidade = "", ValorPadrao = 0.2 },
                        new Variavel { Nome = "Número iterações n", Simbolo = "n", Unidade = "", ValorPadrao = 5 }
                    },
                    Calcular = inputs =>
                    {
                        double L0 = inputs["Carga inicial L₀"];
                        double alpha = inputs["Fator sobrecarga α"];
                        double n = inputs["Número iterações n"];
                        
                        double L_fail = L0 * Math.Pow(1 + alpha, n);
                        return L_fail;
                    },
                    Icone = "🌐"
                },

                // V10-077: Synchronization — Acoplamento Kuramoto
                new Formula
                {
                    Id = "3665",
                    CodigoCompendio = "V10-077",
                    Nome = "Modelo de Kuramoto — Sincronização",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Dinâmica Coletiva",
                    Expressao = @"dθᵢ/dt = ωᵢ + (K/N)·Σⱼ sin(θⱼ−θᵢ)",
                    Descricao = "Osciladores acoplados. K>K_c: sincronização espontânea. K_c depende de network topology. Parâmetro de ordem r: r→1 (síncrono), r→0 (assíncrono).",
                    ExemploPratico = "Fireflies: sincronizam piscadas (K alto). Power grid: frequência 60Hz síncrona (K>K_c). Neurônios: epilepsia é sincronização patológica.",
                    Criador = "Kuramoto (1975, International Symposium on Mathematical Problems)",
                    AnoOrigin = "1975",
                    VariavelResultado = "r",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Acoplamento K", Simbolo = "K", Unidade = "", ValorPadrao = 2 },
                        new Variavel { Nome = "K crítico K_c", Simbolo = "K_c", Unidade = "", ValorPadrao = 1 }
                    },
                    Calcular = inputs =>
                    {
                        double K = inputs["Acoplamento K"];
                        double K_c = inputs["K crítico K_c"];
                        
                        // Parâmetro de ordem simplificado
                        double r = K > K_c ? Math.Sqrt((K - K_c) / K) : 0;
                        return r;
                    },
                    Icone = "🌐"
                },

                // V10-078: Voter Model — Dinâmica de Opinião
                new Formula
                {
                    Id = "3666",
                    CodigoCompendio = "V10-078",
                    Nome = "Voter Model — Consenso de Opinião",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Dinâmica Social",
                    Expressao = @"T_consensus ~ N·log(N); N: tamanho rede",
                    Descricao = "Cada agente adota opinião de vizinho aleatório. Tempo até consenso T~N (completo), ~N² (lattice). Redes scale-free: consenso mais rápido (hubs dominam).",
                    ExemploPratico = "Rede 1000 nós: T~7000 passos em grafo completo. Lattice 2D: T~10⁶. Twitter: hubs (influencers) aceleram consenso.",
                    Criador = "Clifford-Sudbury (1973, bioestatística); Holley-Liggett (1975, teoria)",
                    AnoOrigin = "1973",
                    VariavelResultado = "T",
                    UnidadeResultado = "passos",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tamanho rede N", Simbolo = "N", Unidade = "", ValorPadrao = 1000 }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["Tamanho rede N"];
                        if (N <= 1) return 0;
                        double T = N * Math.Log(N);
                        return T;
                    },
                    Icone = "🌐"
                },

                // V10-079: Modelo SIS — Epidemia Endêmica
                new Formula
                {
                    Id = "3667",
                    CodigoCompendio = "V10-079",
                    Nome = "Modelo SIS — Estado Endêmico",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Epidemiologia em Redes",
                    Expressao = @"i_∞ = 1 − 1/R₀; fração infectados steady-state",
                    Descricao = "SIS: Susceptible-Infected-Susceptible (sem imunidade). R₀>1: equilíbrio endêmico i_∞>0. R₀<1: doença morre (i_∞=0). STIs típicos modelos SIS.",
                    ExemploPratico = "Gripe sazonal (R₀≈1.3): i_∞≈23%. Herpes (R₀≈2): i_∞≈50%. Vacinação reduz R₀ efetivo. Rede densa aumenta R₀.",
                    Criador = "Kermack-McKendrick (1927, SIR original); Pastor-Satorras (2001, redes)",
                    AnoOrigin = "1927",
                    VariavelResultado = "i_inf",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "R₀", Simbolo = "R0", Unidade = "", ValorPadrao = 2 }
                    },
                    Calcular = inputs =>
                    {
                        double R0 = inputs["R₀"];
                        if (R0 <= 1) return 0;
                        double i_inf = (1 - 1.0 / R0) * 100;
                        return i_inf;
                    },
                    Icone = "🌐"
                },

                // V10-080: Grau de Separação Médio (Diameter)
                new Formula
                {
                    Id = "3668",
                    CodigoCompendio = "V10-080",
                    Nome = "Diâmetro da Rede — Máxima Distância",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Topologia",
                    Expressao = @"D = max{d(i,j)}; maior distância geodésica",
                    Descricao = "D: maior caminho mínimo entre 2 nós. Small-world: D~log(N). Scale-free: D~log(log(N)). D alto: info propaga lentamente.",
                    ExemploPratico = "Internet: D≈19. Facebook: D≈5. C-elegans: D=5. Lattice 2D N=10000: D≈200. Rede random N=10⁶: D~log(10⁶)/log(⟨k⟩)≈15.",
                    Criador = "Teoria de grafos clássica; Watts-Strogatz (1998, aplicado redes reais)",
                    AnoOrigin = "1998",
                    VariavelResultado = "D",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "N nós", Simbolo = "N", Unidade = "", ValorPadrao = 1000 },
                        new Variavel { Nome = "Grau médio ⟨k⟩", Simbolo = "k", Unidade = "", ValorPadrao = 10 }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["N nós"];
                        double k = inputs["Grau médio ⟨k⟩"];
                        if (k <= 1) return N;
                        
                        // Aproximação small-world
                        double D = Math.Log(N) / Math.Log(k);
                        return D;
                    },
                    Icone = "🌐"
                },

                // V10-081: Hierarquia — Hierarchical Coefficient
                new Formula
                {
                    Id = "3669",
                    CodigoCompendio = "V10-081",
                    Nome = "Coeficiente Hierárquico",
                    Categoria = "Sistemas Complexos",
                    SubCategoria = "Estrutura Hierárquica",
                    Expressao = @"C(k) ~ k^−β; β>0: hierarquia (C diminui com k)",
                    Descricao = "Relação clustering vs grau. β>0: hubs têm baixo clustering (papel intermediação). β≈0: sem hierarquia. Redes metabólicas: β≈1.",
                    ExemploPratico = "Internet: hubs (ISPs) conectam regiões (baixo C), usuários alta transitividade (alto C). Proteínas: β≈0.7. Redes sociais: β close to 0.",
                    Criador = "Ravasz-Barabási (2003, Phys. Rev. E)",
                    AnoOrigin = "2003",
                    VariavelResultado = "β",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Log(C) alto grau", Simbolo = "log_C_high", Unidade = "", ValorPadrao = -2 },
                        new Variavel { Nome = "Log(C) baixo grau", Simbolo = "log_C_low", Unidade = "", ValorPadrao = -0.5 },
                        new Variavel { Nome = "Log(k_high/k_low)", Simbolo = "log_k_ratio", Unidade = "", ValorPadrao = 1.5 }
                    },
                    Calcular = inputs =>
                    {
                        double log_C_high = inputs["Log(C) alto grau"];
                        double log_C_low = inputs["Log(C) baixo grau"];
                        double log_k_ratio = inputs["Log(k_high/k_low)"];
                        
                        if (log_k_ratio == 0) return 0;
                        
                        // β = -(ΔlogC / Δlogk)
                        double beta = -(log_C_high - log_C_low) / log_k_ratio;
                        return beta;
                    },
                    Icone = "🌐"
                }
            });
        }
    }
}
