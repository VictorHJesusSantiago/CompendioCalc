using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE III
    /// ENGENHARIA DE SOFTWARE E COMPLEXIDADE COMPUTACIONAL
    /// Fórmulas V10-042 a V10-061 (20 fórmulas)
    /// Métricas de software, complexidade de algoritmos e análise de desempenho
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_SoftwareEngineering()
        {
            _formulas.AddRange(new List<Formula>
            {
                // V10-042: Complexidade Ciclomática
                new Formula
                {
                    Id = "3630",
                    CodigoCompendio = "V10-042",
                    Nome = "Complexidade Ciclomática de McCabe",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Métricas de Código",
                    Expressao = @"CC = E − N + 2P",
                    Descricao = "Métrica de complexidade estrutural. E: arestas do grafo de fluxo. N: nós. P: componentes conectados (geralmente 1). CC>10: código complexo (difícil testar). CC>20: alto risco.",
                    ExemploPratico = "Método com 3 ifs e 1 for: CC≈5 (baixo). Função com 15 branches: CC=16 (refatorar). SonarQube usa CC para qualidade.",
                    Criador = "McCabe (1976, IEEE Trans. Soft. Eng.)",
                    AnoOrigin = "1976",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Arestas E", Simbolo = "E", Unidade = "", ValorPadrao = 15, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Nós N", Simbolo = "N", Unidade = "", ValorPadrao = 12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Componentes P", Simbolo = "P", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E = inputs["Arestas E"];
                        double N = inputs["Nós N"];
                        double P = inputs["Componentes P"];
                        
                        // Complexidade Ciclomática
                        double CC = E - N + 2 * P;
                        
                        // Thresholds de qualidade
                        double threshold_baixo = 10;
                        double threshold_alto = 20;
                        
                        // Nível de risco
                        string risco = CC <= threshold_baixo ? "Baixo" :
                                      CC <= threshold_alto ? "Médio" : "Alto";
                        
                        // Número de caminhos independentes (aproximado)
                        double caminhos_teste = CC;
                        
                        // Esforço de teste (relativo)
                        double esforco_teste = CC * CC * 0.1;
                        
                        return CC;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-043: Lei de Halstead
                new Formula
                {
                    Id = "3631",
                    CodigoCompendio = "V10-043",
                    Nome = "Métricas de Halstead — Volume e Dificuldade",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Complexidade de Código",
                    Expressao = @"V = N·log₂(η); D = (η₁/2)·(N₂/η₂)",
                    Descricao = "Volume V: tamanho do programa. η=η₁+η₂: vocabulário (operadores+operandos). D: dificuldade. Esforço E=D·V. Tempo programação T=E/18 (stroud number).",
                    ExemploPratico = "Código com η=50, N=500: V≈2800. D≈10: E=28000. T≈1500s≈26min. Predição de bugs: B=V/3000. Alta dificuldade → mais erros.",
                    Criador = "Halstead (1977, Elements of Software Science)",
                    AnoOrigin = "1977",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Operadores únicos η₁", Simbolo = "η₁", Unidade = "", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Operandos únicos η₂", Simbolo = "η₂", Unidade = "", ValorPadrao = 30, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Total operadores N₁", Simbolo = "N₁", Unidade = "", ValorPadrao = 200, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Total operandos N₂", Simbolo = "N₂", Unidade = "", ValorPadrao = 300, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double eta1 = inputs["Operadores únicos η₁"];
                        double eta2 = inputs["Operandos únicos η₂"];
                        double N1 = inputs["Total operadores N₁"];
                        double N2 = inputs["Total operandos N₂"];
                        
                        // Vocabulário e comprimento
                        double eta = eta1 + eta2;
                        double N = N1 + N2;
                        
                        // Volume
                        double V = N * Math.Log(eta, 2);
                        
                        // Dificuldade
                        double D = (eta1 / 2.0) * (N2 / Math.Max(eta2, 1));
                        
                        // Esforço
                        double E = D * V;
                        
                        // Tempo (segundos, stroud number = 18)
                        double T_sec = E / 18.0;
                        double T_min = T_sec / 60.0;
                        
                        // Predição de bugs
                        double B = V / 3000.0;
                        
                        return V;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-044: Lei de Amdahl
                new Formula
                {
                    Id = "3632",
                    CodigoCompendio = "V10-044",
                    Nome = "Lei de Amdahl — Speedup de Paralelização",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Computação Paralela",
                    Expressao = @"S(N) = 1/(s + p/N)",
                    Descricao = "Speedup máximo ao paralelizar. s: fração serial. p: fração paralela (s+p=1). N: núcleos. Limite: S_max=1/s. Mesmo com N→∞, parte serial limita ganho.",
                    ExemploPratico = "s=10%, p=90%, N=4: S≈3.1× (não 4×). s=50%: S_max=2× independente de N. Web scraping (s<5%): escala bem. Banco de dados (s~30%): escala mal.",
                    Criador = "Amdahl (1967, AFIPS Conference)",
                    AnoOrigin = "1967",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Fração serial s (%)", Simbolo = "s", Unidade = "%", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Número de processadores N", Simbolo = "N", Unidade = "", ValorPadrao = 8, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double s_percent = inputs["Fração serial s (%)"];
                        double N = inputs["Número de processadores N"];
                        
                        double s = s_percent / 100.0;
                        double p = 1.0 - s;
                        
                        // Speedup
                        double S = 1.0 / (s + p / N);
                        
                        // Speedup máximo (N→∞)
                        double S_max = 1.0 / s;
                        
                        // Eficiência
                        double E = S / N;
                        
                        // Speedup ideal (linear)
                        double S_ideal = N;
                        
                        // Perda de desempenho
                        double perda = (S_ideal - S) / S_ideal * 100;
                        
                        return S;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-045: Notação Big O — Complexidade Temporal
                new Formula
                {
                    Id = "3633",
                    CodigoCompendio = "V10-045",
                    Nome = "Análise Assintótica — Big O",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Complexidade de Algoritmos",
                    Expressao = @"T(n) = O(f(n)): ∃c,n₀: T(n) ≤ c·f(n) ∀n>n₀",
                    Descricao = "Limite superior assintótico. T(n): tempo real. f(n): função dominante. Classes comuns: O(1), O(log n), O(n), O(n log n), O(n²), O(2ⁿ).",
                    ExemploPratico = "Binary search: O(log n). Merge sort: O(n log n). Bubble sort: O(n²). n=10^6: O(n) → 1s, O(n²) → 11 dias. Escolha de algoritmo crítica.",
                    Criador = "Knuth (1976, Big O notation popularizada na ciência da computação)",
                    AnoOrigin = "1976",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tamanho entrada n", Simbolo = "n", Unidade = "", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tipo complexidade (1-6)", Simbolo = "tipo", Unidade = "", ValorPadrao = 3, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double n = inputs["Tamanho entrada n"];
                        double tipo = inputs["Tipo complexidade (1-6)"];
                        
                        // Tipos: 1=O(1), 2=O(log n), 3=O(n), 4=O(n log n), 5=O(n²), 6=O(2^n)
                        int t = Math.Max(1, Math.Min(6, (int)Math.Round(tipo)));
                        
                        double operacoes = 0;
                        string nome = "";
                        
                        switch (t)
                        {
                            case 1: operacoes = 1; nome = "O(1)"; break;
                            case 2: operacoes = Math.Log(n, 2); nome = "O(log n)"; break;
                            case 3: operacoes = n; nome = "O(n)"; break;
                            case 4: operacoes = n * Math.Log(n, 2); nome = "O(n log n)"; break;
                            case 5: operacoes = n * n; nome = "O(n²)"; break;
                            case 6: operacoes = Math.Min(Math.Pow(2, Math.Min(n, 30)), 1e15); nome = "O(2^n)"; break;
                        }
                        
                        // Tempo estimado (assumindo 1 op = 1ns)
                        double tempo_ns = operacoes;
                        double tempo_ms = tempo_ns / 1e6;
                        double tempo_s = tempo_ns / 1e9;
                        
                        return operacoes;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-046: COCOMO — Estimativa de Esforço
                new Formula
                {
                    Id = "3634",
                    CodigoCompendio = "V10-046",
                    Nome = "COCOMO — Estimativa de Esforço de Projeto",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Gerenciamento de Projetos",
                    Expressao = @"E = a·(KLOC)^b; T = c·E^d",
                    Descricao = "Constructive Cost Model. E: pessoa-mês. KLOC: milhares de linhas de código. Modo orgânico (a=2.4,b=1.05), semi-destacado (3.0,1.12), embutido (3.6,1.20). T: tempo em meses.",
                    ExemploPratico = "Projeto 50 KLOC, orgânico: E≈128 pessoa-mês, T≈14 meses. Embutido (crítico): E≈209, T≈16. COCOMO II ajusta com fatores de custo.",
                    Criador = "Boehm (1981, Software Engineering Economics)",
                    AnoOrigin = "1981",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "KLOC (milhares linhas)", Simbolo = "KLOC", Unidade = "", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Modo (1=org,2=semi,3=emb)", Simbolo = "modo", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double KLOC = inputs["KLOC (milhares linhas)"];
                        double modo_val = inputs["Modo (1=org,2=semi,3=emb)"];
                        
                        int modo = Math.Max(1, Math.Min(3, (int)Math.Round(modo_val)));
                        
                        //Parâmetros COCOMO
                        double a = 0, b = 0, c = 0, d = 0;
                        
                        switch (modo)
                        {
                            case 1: // Orgânico
                                a = 2.4; b = 1.05; c = 2.5; d = 0.38;
                                break;
                            case 2: // Semi-destacado
                                a = 3.0; b = 1.12; c = 2.5; d = 0.35;
                                break;
                            case 3: // Embutido
                                a = 3.6; b = 1.20; c = 2.5; d = 0.32;
                                break;
                        }
                        
                        // Esforço (pessoa-mês)
                        double E = a * Math.Pow(KLOC, b);
                        
                        // Tempo (meses)
                        double T = c * Math.Pow(E, d);
                        
                        // Pessoas médias
                        double P = E / T;
                        
                        // Produtividade (LOC/pessoa-mês)
                        double prod = (KLOC * 1000) / E;
                        
                        return E;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-047: Análise de Performance — Latência vs Throughput
                new Formula
                {
                    Id = "3635",
                    CodigoCompendio = "V10-047",
                    Nome = "Análise de Performance — Latência vs Throughput",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Desempenho de Sistemas",
                    Expressao = @"Throughput = 1/Latência (banda serial); = N/Latência (paralelo)",
                    Descricao = "Latência: tempo para completar uma operação. Throughput: operações/segundo. Pipeline aumenta throughput sem reduzir latência. Trade-off: buffering aumenta latência mas melhora throughput.",
                    ExemploPratico = "API latência 100ms: throughput serial = 10req/s. Com 50 threads: ~500req/s (se I/O-bound). Database: latência 5ms, batch 100 queries → throughput 20k ops/s.",
                    Criador = "Hennessy & Patterson (1990, arquitetura de comp utadores)",
                    AnoOrigin = "1990",
                    VariavelResultado = "throughput",
                    UnidadeResultado = "ops/s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Latência (ms)", Simbolo = "L", Unidade = "ms", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Paralelismo N", Simbolo = "N", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double latencia_ms = inputs["Latência (ms)"];
                        double N = inputs["Paralelismo N"];
                        
                        double latencia_s = latencia_ms / 1000.0;
                        
                        // Throughput serial
                        double throughput_serial = 1.0 / latencia_s;
                        
                        // Throughput paralelo (ideal)
                        double throughput_paralelo = N / latencia_s;
                        
                        return throughput_paralelo;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-048: Lei de Little
                new Formula
                {
                    Id = "3636",
                    CodigoCompendio = "V10-048",
                    Nome = "Lei de Little — Sistemas de Filas",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Teoria de Filas",
                    Expressao = @"L = λ·W",
                    Descricao = "L: número médio de itens no sistema. λ: taxa de chegada (items/s). W: tempo médio no sistema (s). Vale para qualquer sistema em estado estável. Fundamental para dimensionamento.",
                    ExemploPratico = "API recebe 100req/s, tempo resposta 200ms: L=100×0.2=20 requisições simultâneas. Fila Kafka: λ=1000msg/s, W=5s → 5000 mensagens em buffer.",
                    Criador = "Little (1961, Operations Research)",
                    AnoOrigin = "1961",
                    VariavelResultado = "L",
                    UnidadeResultado = "itens",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Taxa chegada λ (itens/s)", Simbolo = "λ", Unidade = "itens/s", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tempo sistema W (ms)", Simbolo = "W", Unidade = "ms", ValorPadrao = 200, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["Taxa chegada λ (itens/s)"];
                        double W_ms = inputs["Tempo sistema W (ms)"];
                        
                        double W_s = W_ms / 1000.0;
                        double L = lambda * W_s;
                        
                        return L;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-049: Cache Hit Rate e Miss Penalty
                new Formula
                {
                    Id = "3637",
                    CodigoCompendio = "V10-049",
                    Nome = "Cache Hit Rate e Miss Penalty",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Otimização de Performance",
                    Expressao = @"T_avg = T_hit + (1−h)·T_miss",
                    Descricao = "h: hit rate (0 a 1). T_hit: tempo em cache. T_miss: tempo sem cache. Melhoria: 10× mais rápido com h=90% vs 50%. LRU, LFU, Redis são estratégias.",
                    ExemploPratico = "Redis: T_hit=1ms, DB: T_miss=50ms. h=95%: T_avg=1+0.05×50=3.5ms (14× melhor que DB direto). h=80%: T_avg=11ms.",
                    Criador = "Wilkes (1965, primeira cache em ATLAS)",
                    AnoOrigin = "1965",
                    VariavelResultado = "T_avg",
                    UnidadeResultado = "ms",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Hit rate h (%)", Simbolo = "h", Unidade = "%", ValorPadrao = 95, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tempo hit (ms)", Simbolo = "T_hit", Unidade = "ms", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tempo miss (ms)", Simbolo = "T_miss", Unidade = "ms", ValorPadrao = 50, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double h_percent = inputs["Hit rate h (%)"];
                        double T_hit = inputs["Tempo hit (ms)"];
                        double T_miss = inputs["Tempo miss (ms)"];
                        
                        double h = h_percent / 100.0;
                        double T_avg = T_hit + (1 - h) * T_miss;
                        
                        return T_avg;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-050: Fator de Acoplamento
                new Formula
                {
                    Id = "3638",
                    CodigoCompendio = "V10-050",
                    Nome = "Fator de Acoplamento (Coupling)",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Design de Software",
                    Expressao = @"CF = C/(m²−m); C: conexões reais",
                    Descricao = "CF: coupling factor (0 a 1). m: número de classes. C: conexões (dependências) entre classes. CF baixo (<0.1): bom design. CF alto (>0.3): refatorar.",
                    ExemploPratico = "10 classes, 15 dependências: CF=15/(100-10)=0.167 (aceitável). 90 conexões: CF=1 (grafo completo, péssimo). Microservices: CF baixo entre serviços.",
                    Criador = "Myers (1978, Composite/Structured Design); Chidamber-Kemerer (1994, métricas OO)",
                    AnoOrigin = "1978",
                    VariavelResultado = "CF",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Número de classes m", Simbolo = "m", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Conexões reais C", Simbolo = "C", Unidade = "", ValorPadrao = 15, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double m = inputs["Número de classes m"];
                        double C = inputs["Conexões reais C"];
                        
                        if (m <= 1) return 0;
                        
                        double max_conexoes = m * m - m;
                        double CF = C / max_conexoes;
                        
                        return CF;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-051: Coesão de Módulo
                new Formula
                {
                    Id = "3639",
                    CodigoCompendio = "V10-051",
                    Nome = "Coesão de Módulo (LCOM)",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Design OO",
                    Expressao = @"LCOM = (P−Q)/max(P,Q); P: pares não-coesos, Q: coesos",
                    Descricao = "Lack of Cohesion in Methods. LCOM=0: máxima coesão (todos métodos usam todos atributos). LCOM>0.5: classe faz coisas demais (Single Responsibility Principle violado).",
                    ExemploPratico = "Classe com métodos compartilhando atributos: LCOM baixo (bom). Classe com 2 grupos distintos: LCOM alto → dividir em 2 classes. SRP: cada classe 1 responsabilidade.",
                    Criador = "Chidamber e Kemerer (1994, IEEE Trans. Soft. Eng., métricas CK)",
                    AnoOrigin = "1994",
                    VariavelResultado = "LCOM",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Pares não-coesos P", Simbolo = "P", Unidade = "", ValorPadrao = 30, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Pares coesos Q", Simbolo = "Q", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double P = inputs["Pares não-coesos P"];
                        double Q = inputs["Pares coesos Q"];
                        
                        double max_val = Math.Max(P, Q);
                        if (max_val == 0) return 0;
                        
                        double LCOM = (P - Q) / max_val;
                        LCOM = Math.Max(0, LCOM); // LCOM não pode ser negativo
                        
                        return LCOM;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-052: Profund idade de Herança (DIT)
                new Formula
                {
                    Id = "3640",
                    CodigoCompendio = "V10-052",
                    Nome = "Profundidade de Herança (DIT)",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Métricas OO",
                    Expressao = @"DIT = max depth na árvore de herança",
                    Descricao = "Depth of Inheritance Tree. DIT alto: mais reuso, mas complexidade. DIT>5: difícil entender. Java: Object é raiz (profundidade 0). Trade-off: herança profunda vs composição.",
                    ExemploPratico = "Classe herda 3 níveis: DIT=3. Framework MVC: Controller→BaseController→AbstractController→MyController (DIT=3). Pattern: prefer composition over inheritance.",
                    Criador = "Chidamber-Kemerer (1994, métricas CK)",
                    AnoOrigin = "1994",
                    VariavelResultado = "complexidade",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Profundidade DIT", Simbolo = "DIT", Unidade = "", ValorPadrao = 3, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double DIT = inputs["Profundidade DIT"];
                        
                        // Complexidade aumenta exponencialmente
                        double complexidade = Math.Pow(1.5, DIT);
                        
                        return complexidade;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-053: Número de Métodos Ponderados (WMC)
                new Formula
                {
                    Id = "3641",
                    CodigoCompendio = "V10-053",
                    Nome = "Número de Métodos Ponderados (WMC)",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Complexidade de Classe",
                    Expressao = @"WMC = Σᵢ CC(i); CC: complexidade ciclomática",
                    Descricao = "Weighted Methods per Class. Soma da complexidade de todos métodos. WMC alto: classe difícil de testar. Threshold: WMC<50 (bom), <100 (aceitável), >100 (refatorar).",
                    ExemploPratico = "Classe 10 métodos, CC médio=5: WMC=50. Classe 'Deus' 50 métodos, CC=3: WMC=150 (ruim). Separar responsabilidades reduz WMC.",
                    Criador = "Chidamber-Kemerer (1994)",
                    AnoOrigin = "1994",
                    VariavelResultado = "WMC",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Número métodos N", Simbolo = "N", Unidade = "", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "CC médio", Simbolo = "CC_avg", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["Número métodos N"];
                        double CC_avg = inputs["CC médio"];
                        
                        double WMC = N * CC_avg;
                        
                        return WMC;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-054: Lack of Cohesion (LCOM4)
                new Formula
                {
                    Id = "3642",
                    CodigoCompendio = "V10-054",
                    Nome = "LCOM4 — Componentes Desconexos",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Coesão",
                    Expressao = @"LCOM4 = número de componentes conexos no grafo método-atributo",
                    Descricao = "LCOM4=1: coesão perfeita (todos métodos conectados). LCOM4>1: classe tem partes independentes → dividir em múltiplas classes.",
                    ExemploPratico = "Classe com 2 grupos métodos independentes: LCOM4=2 → criar 2 classes. Logger+Validator na mesma classe: LCOM4=2 (separar). SRP: LCOM4 deve ser 1.",
                    Criador = "Hitz-Montazeri (1995, extensão LCOM original)",
                    AnoOrigin = "1995",
                    VariavelResultado = "LCOM4",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Componentes conexos", Simbolo = "C", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double C = inputs["Componentes conexos"];
                        return C;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-055: Technical Debt Ratio
                new Formula
                {
                    Id = "3643",
                    CodigoCompendio = "V10-055",
                    Nome = "Technical Debt Ratio",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Qualidade de Código",
                    Expressao = @"TDR = (Custo remediar)/(Custo desenvolver) × 100%",
                    Descricao = "TDR<5%: excelente. 5-10%: bom. 10-20%: gerenciar. >20%: crítico (risco de projeto). SonarQube mede TDR via issues (bugs, code smells, vulnerabilities).",
                    ExemploPratico = "Projeto 1000h desenvolvimento, 50h dívida: TDR=5% (ok). 300h dívida: TDR=30% (bloqueia features). Refactoring contínuo mantém TDR baixo.",
                    Criador = "Cunningham (1992, conceito debt); SonarSource (2010s, métrica TDR)",
                    AnoOrigin = "1992",
                    VariavelResultado = "TDR",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Custo remediar (h)", Simbolo = "C_remediar", Unidade = "h", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Custo desenvolver (h)", Simbolo = "C_dev", Unidade = "h", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double C_remediar = inputs["Custo remediar (h)"];
                        double C_dev = inputs["Custo desenvolver (h)"];
                        
                        if (C_dev == 0) return 0;
                        
                        double TDR = (C_remediar / C_dev) * 100;
                        
                        return TDR;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-056: Code Churn
                new Formula
                {
                    Id = "3644",
                    CodigoCompendio = "V10-056",
                    Nome = "Code Churn — Taxa de Mudança",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Estabilidade de Código",
                    Expressao = @"Churn = (Linhas Add + Linhas Mod + Linhas Del)/Total Linhas",
                    Descricao = "Churn alto: código instável (muitas mudanças). Correlaciona com bugs. Churn>50%/sprint: código experimental ou mal projetado. Refatoração planejada tem churn alto mas reduz bugs.",
                    ExemploPratico = "Módulo 1000 LOC, sprint: +200, −150, ~100 modificadas: Churn=450/1000=45%. Módulo estável: churn<10%/sprint. Hotspots: alto churn + alta complexidade.",
                    Criador = "Nagappan-Ball (2007, Microsoft Research, code churn e qualidade)",
                    AnoOrigin = "2007",
                    VariavelResultado = "churn",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Linhas adicionadas", Simbolo = "Add", Unidade = "", ValorPadrao = 200, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Linhas deletadas", Simbolo = "Del", Unidade = "", ValorPadrao = 150, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Linhas modificadas", Simbolo = "Mod", Unidade = "", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Total linhas", Simbolo = "Total", Unidade = "", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Add = inputs["Linhas adicionadas"];
                        double Del = inputs["Linhas deletadas"];
                        double Mod = inputs["Linhas modificadas"];
                        double Total = inputs["Total linhas"];
                        
                        if (Total == 0) return 0;
                        
                        double churn = ((Add + Del + Mod) / Total) * 100;
                        
                        return churn;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-057: Defect Density
                new Formula
                {
                    Id = "3645",
                    CodigoCompendio = "V10-057",
                    Nome = "Defect Density — Densidade de Defeitos",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Qualidade",
                    Expressao = @"DD = Defeitos/KLOC",
                    Descricao = "Defeitos por mil linhas de código. Indústria: DD<1 (bom), 1-5 (médio), >5 (ruim). Software crítico (aviação): DD<0.1. Microsoft Windows: DD≈0.5.",
                    ExemploPratico = "Projeto 50 KLOC, 30 bugs: DD=0.6 (bom). 200 bugs: DD=4 (médio). Testes automatizados reduzem DD. Code review: detecta ~60% defeitos antes produção.",
                    Criador = "IEEE Std 982.1 (1988, software metrics)",
                    AnoOrigin = "1988",
                    VariavelResultado = "DD",
                    UnidadeResultado = "defeitos/KLOC",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Número defeitos", Simbolo = "D", Unidade = "", ValorPadrao = 30, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "KLOC", Simbolo = "KLOC", Unidade = "", ValorPadrao = 50, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double D = inputs["Número defeitos"];
                        double KLOC = inputs["KLOC"];
                        
                        if (KLOC == 0) return 0;
                        
                        double DD = D / KLOC;
                        
                        return DD;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-058: Mean Time to Failure (MTTF)
                new Formula
                {
                    Id = "3646",
                    CodigoCompendio = "V10-058",
                    Nome = "Mean Time to Failure (MTTF)",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Confiabilidade",
                    Expressao = @"MTTF = Tempo total operação/Número de falhas",
                    Descricao = "Tempo médio até falha. MTTF alto: sistema confiável. Sistemas críticos: MTTF>10,000h. MTBF (Between Failures) para sistemas reparáveis: MTBF=MTTF+MTTR.",
                    ExemploPratico = "Servidor 8760h/ano (1 ano), 3 crashes: MTTF=2920h≈4 meses. 99.9% uptime → MTTF~700h entre failures. Cloud providers: MTTF>50,000h.",
                    Criador = "Teoria de confiabilidade (anos 1950s, engenharia); aplicado software (1970s)",
                    AnoOrigin = "1970",
                    VariavelResultado = "MTTF",
                    UnidadeResultado = "h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tempo operação (h)", Simbolo = "T", Unidade = "h", ValorPadrao = 8760, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Número falhas", Simbolo = "F", Unidade = "", ValorPadrao = 3, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double T = inputs["Tempo operação (h)"];
                        double F = inputs["Número falhas"];
                        
                        if (F == 0) return double.PositiveInfinity;
                        
                        double MTTF = T / F;
                        
                        return MTTF;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-059: Availability (SLA)
                new Formula
                {
                    Id = "3647",
                    CodigoCompendio = "V10-059",
                    Nome = "Availability — Disponibilidade (SLA)",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "SLA",
                    Expressao = @"A = Uptime/(Uptime + Downtime) × 100%",
                    Descricao = "Disponibilidade percentual. 99% (2 nines): 3.65d downtime/ano. 99.9% (3 nines): 8.76h/ano. 99.99% (4 nines): 52min/ano. 99.999% (5 nines): 5.26min/ano. Cloud SLA típico: 99.95%.",
                    ExemploPratico = "Sistema 43,800min uptime, 24min downtime (mês): A=99.95%. AWS S3: 99.99%. Downtime planejado: excluir do cálculo. Redundância aumenta A.",
                    Criador = "Teoria de confiabilidade; SLA formalizados em cloud computing (2000s)",
                    AnoOrigin = "2000",
                    VariavelResultado = "A",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Uptime (min)", Simbolo = "U", Unidade = "min", ValorPadrao = 43800, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Downtime (min)", Simbolo = "D", Unidade = "min", ValorPadrao = 24, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double U = inputs["Uptime (min)"];
                        double D = inputs["Downtime (min)"];
                        
                        double total = U + D;
                        if (total == 0) return 0;
                        
                        double A = (U / total) * 100;
                        
                        return A;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-060: Response Time Percentiles
                new Formula
                {
                    Id = "3648",
                    CodigoCompendio = "V10-060",
                    Nome = "Response Time Percentiles",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Métricas de Performance",
                    Expressao = @"p50 (mediana), p95, p99, p99.9 (tail latency)",
                    Descricao = "Percentis de latência. p50 (mediana): 50% requests mais rápidos. p99: 1% mais lentos (tail latency). SLO típico: p50<100ms, p99<500ms. Mean esconde outliers!",
                    ExemploPratico = "API: p50=50ms, p95=200ms, p99=800ms → usuário típico 50ms, 1% espera 800ms. Otimizar p99 importante (long tail). Async processing reduz p99.",
                    Criador = "Estatística descritiva; popularizado por Latency SLOs (Google SRE, 2010s)",
                    AnoOrigin = "2010",
                    VariavelResultado = "slowdown",
                    UnidadeResultado = "x",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "p50 mediana (ms)", Simbolo = "p50", Unidade = "ms", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "p99 tail (ms)", Simbolo = "p99", Unidade = "ms", ValorPadrao = 800, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double p50 = inputs["p50 mediana (ms)"];
                        double p99 = inputs["p99 tail (ms)"];
                        
                        if (p50 == 0) return 0;
                        
                        // Razão p99/p50 (tail slowdown)
                        double slowdown = p99 / p50;
                        
                        return slowdown;
                    },
                    Icone = "💻",
                    Unidades = "",
                },

                // V10-061: Resource Utilization Law
                new Formula
                {
                    Id = "3649",
                    CodigoCompendio = "V10-061",
                    Nome = "Resource Utilization Law",
                    Categoria = "Engenharia de Software",
                    SubCategoria = "Capacity Planning",
                    Expressao = @"U = λ·S; U: utilização, λ: throughput, S: tempo serviço",
                    Descricao = "Lei operacional. U=utilização do recurso (0 a 1). U>0.8: alto risco contention. U>0.9: saturation (latência cresce exponencialmente). Auto-scaling: alvo U=0.7.",
                    ExemploPratico = "CPU processa 100req/s, cada req usa 5ms CPU: U=100×0.005=0.5 (50%). 150req/s: U=0.75 (ok). 180req/s: U=0.9 (saturação → adicionar CPUs).",
                    Criador = "Denning-Buzen (1978, operational analysis)",
                    AnoOrigin = "1978",
                    VariavelResultado = "U",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Throughput λ (req/s)", Simbolo = "λ", Unidade = "req/s", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tempo serviço S (ms)", Simbolo = "S", Unidade = "ms", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["Throughput λ (req/s)"];
                        double S_ms = inputs["Tempo serviço S (ms)"];
                        
                        double S_s = S_ms / 1000.0;
                        double U = lambda * S_s;
                        
                        // Convert to percent
                        double U_percent = U * 100;
                        
                        // Clamp to reasonable range
                        U_percent = Math.Min(U_percent, 100);
                        
                        return U_percent;
                    },
                    Icone = "💻",
                    Unidades = "",
                }
            });
        }
    }
}
