using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE XII: NLP (Processamento de Linguagem Natural)
    // TF-IDF, Word2Vec, Attention, BLEU, Perplexidade, Edit Distance
    // 21 fórmulas (223-243)
    // ========================================

    public static Formula V8_NLP223_TFIDF()
    {
        return new Formula
        {
            Id = "V8-NLP223",
            CodigoCompendio = "223",
            Nome = "TF-IDF — Term Frequency-Inverse Document Frequency",
            Categoria = "NLP",
            SubCategoria = "Representação de Texto",
            Expressao = "TF-IDF = TF * IDF = (f_{t,d} / Σf_{t',d}) * log(N / df_t)",
            ExprTexto = "TF-IDF",
            Descricao = "f_{t,d}=freq termo t em doc d, N=docs totais, df_t=docs contendo t. Peso importância termo.",
            Criador = "Karen Spärck Jones, Gerard Salton",
            AnoOrigin = "1972",
            ExemploPratico = "TF=10/100=0,1, N=1000, df_t=10 → IDF=log(100)≈2 → TF-IDF≈0,2. Termos raros: alto IDF",
            Unidades = "adimensional",
            VariavelResultado = "TFIDF",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "TF", Nome = "TF", Descricao = "Term frequency", Unidade = "", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "N", Nome = "N", Descricao = "Total documentos", Unidade = "", ValorPadrao = 1000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "df_t", Nome = "df_t", Descricao = "Docs contendo termo", Unidade = "", ValorPadrao = 10, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double TF = inputs["TF"];
                double N = inputs["N"];
                double df_t = inputs["df_t"];
                
                double IDF = Math.Log(N / df_t);
                
                return TF * IDF;
            }
        };
    }

    public static Formula V8_NLP224_EditDistance_Levenshtein()
    {
        return new Formula
        {
            Id = "V8-NLP224",
            CodigoCompendio = "224",
            Nome = "Distância de Edição — Levenshtein (simplificado)",
            Categoria = "NLP",
            SubCategoria = "Similaridade de Texto",
            Expressao = "d(s1, s2) = min(insert, delete, substitute)",
            ExprTexto = "Levenshtein distance",
            Descricao = "Número mínimo edições (inserção, deleção, substituição) transformar s1→s2. Programação dinâmica.",
            Criador = "Vladimir Levenshtein",
            AnoOrigin = "1965",
            ExemploPratico = "\"casa\"→\"cama\": 1 substituição (s→m). \"gato\"→\"pato\": 1 subst. d(\"kitten\",\"sitting\")=3",
            Unidades = "edições",
            VariavelResultado = "distance_approx",
            UnidadeResultado = "edições",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "len1", Nome = "len(s1)", Descricao = "Comprimento s1", Unidade = "", ValorPadrao = 5, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "len2", Nome = "len(s2)", Descricao = "Comprimento s2", Unidade = "", ValorPadrao = 5, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "edits", Nome = "Edições", Descricao = "Operações mínimas", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                // Simplificação: retornar diferença comprimentos + edições estimadas
                double len1 = inputs["len1"];
                double len2 = inputs["len2"];
                double edits = inputs["edits"];
                
                return Math.Max(Math.Abs(len1 - len2), edits);
            }
        };
    }

    public static Formula V8_NLP225_CosineSimilarity()
    {
        return new Formula
        {
            Id = "V8-NLP225",
            CodigoCompendio = "225",
            Nome = "Similaridade de Cosseno",
            Categoria = "NLP",
            SubCategoria = "Similaridade de Texto",
            Expressao = "cos(θ) = (A · B) / (||A|| * ||B||)",
            ExprTexto = "Cosine similarity",
            Descricao = "A,B=vetores (TF-IDF, embeddings). cos(θ)∈[-1,1]. 1=idênticos, 0=ortogonais, -1=opostos.",
            Criador = "Geometria vetorial / IR",
            AnoOrigin = "~1970s",
            ExemploPratico = "A=[3,4], B=[4,3] → A·B=24, ||A||=5, ||B||=5 → cos(θ)=0,96 (muito similar)",
            Unidades = "adimensional",
            VariavelResultado = "cos_theta",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "dot_product", Nome = "A · B", Descricao = "Produto escalar", Unidade = "", ValorPadrao = 24, ValorMin = -1e10, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "norm_A", Nome = "||A||", Descricao = "Norma A", Unidade = "", ValorPadrao = 5, ValorMin = 0.001, ValorMax = 1e10, Obrigatoria = true },
                new() { Simbolo = "norm_B", Nome = "||B||", Descricao = "Norma B", Unidade = "", ValorPadrao = 5, ValorMin = 0.001, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double dot_product = inputs["dot_product"];
                double norm_A = inputs["norm_A"];
                double norm_B = inputs["norm_B"];
                
                return dot_product / (norm_A * norm_B);
            }
        };
    }

    public static Formula V8_NLP226_Word2Vec_SkipGram_Loss()
    {
        return new Formula
        {
            Id = "V8-NLP226",
            CodigoCompendio = "226",
            Nome = "Word2Vec Skip-Gram — Log Likelihood (simplificado)",
            Categoria = "NLP",
            SubCategoria = "Word Embeddings",
            Expressao = "L = Σ log P(w_context | w_target) = Σ log(exp(v'·v) / Σexp)",
            ExprTexto = "Skip-gram loss",
            Descricao = "w_target→w_context. v,v'=embeddings. Softmax. Prevê contexto dado palavra central. Mikolov 2013.",
            Criador = "Tomas Mikolov et al.",
            AnoOrigin = "2013",
            ExemploPratico = "\"The cat sat\" → target=\"cat\", context={\"The\",\"sat\"}. Treina v_cat para prever contexto",
            Unidades = "adimensional",
            VariavelResultado = "prob_approx",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v_dot_v_prime", Nome = "v·v'", Descricao = "Produto escalar embeddings", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "Z", Nome = "Z", Descricao = "Soma normalização", Unidade = "", ValorPadrao = 10, ValorMin = 0.01, ValorMax = 1e10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v_dot = inputs["v_dot_v_prime"];
                double Z = inputs["Z"];
                
                return Math.Exp(v_dot) / Z; // Softmax simplificado
            }
        };
    }

    public static Formula V8_NLP227_Attention_ScaledDotProduct()
    {
        return new Formula
        {
            Id = "V8-NLP227",
            CodigoCompendio = "227",
            Nome = "Scaled Dot-Product Attention",
            Categoria = "NLP",
            SubCategoria = "Transformers",
            Expressao = "Attention(Q, K, V) = softmax(Q*K^T / sqrt(d_k)) * V",
            ExprTexto = "Scaled attention",
            Descricao = "Q=query, K=key, V=value, d_k=dimensão key. Escalamento 1/√d_k estabiliza gradientes. Vaswani 2017.",
            Criador = "Vaswani et al. (Google Brain/Research)",
            AnoOrigin = "2017",
            ExemploPratico = "d_k=64 → 1/√64=0,125. Q*K^T escalado → softmax → pesos atenção aplicados a V",
            Unidades = "adimensional",
            VariavelResultado = "scale_factor",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "d_k", Nome = "d_k", Descricao = "Dimensão key", Unidade = "", ValorPadrao = 64, ValorMin = 1, ValorMax = 1024, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double d_k = inputs["d_k"];
                
                return 1.0 / Math.Sqrt(d_k);
            }
        };
    }

    public static Formula V8_NLP228_Attention_MultiHead()
    {
        return new Formula
        {
            Id = "V8-NLP228",
            CodigoCompendio = "228",
            Nome = "Multi-Head Attention — Número de Cabeças",
            Categoria = "NLP",
            SubCategoria = "Transformers",
            Expressao = "MultiHead(Q, K, V) = Concat(head_1, ..., head_h) * W^O",
            ExprTexto = "Multi-head",
            Descricao = "h=número cabeças. Cada head: atenção independente. Concat→projeção linear W^O. Vaswani 2017.",
            Criador = "Vaswani et al.",
            AnoOrigin = "2017",
            ExemploPratico = "h=8, d_model=512 → d_k=d_v=512/8=64 por head. BERT: 12 heads. GPT-3: 96 heads",
            Unidades = "adimensional",
            VariavelResultado = "d_k_per_head",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "d_model", Nome = "d_model", Descricao = "Dimensão modelo", Unidade = "", ValorPadrao = 512, ValorMin = 1, ValorMax = 4096, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "h", Descricao = "Número cabeças", Unidade = "", ValorPadrao = 8, ValorMin = 1, ValorMax = 128, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double d_model = inputs["d_model"];
                double h = inputs["h"];
                
                return d_model / h;
            }
        };
    }

    public static Formula V8_NLP229_BLEU_Score()
    {
        return new Formula
        {
            Id = "V8-NLP229",
            CodigoCompendio = "229",
            Nome = "BLEU Score — Tradução Automática (simplificado)",
            Categoria = "NLP",
            SubCategoria = "Avaliação",
            Expressao = "BLEU = BP * exp(Σw_n * log(p_n))",
            ExprTexto = "BLEU",
            Descricao = "p_n=precisão n-gramas, BP=brevity penalty. BLEU∈[0,1]. BLEU>0,4: bom. Papineni 2002.",
            Criador = "Kishore Papineni et al. (IBM)",
            AnoOrigin = "2002",
            ExemploPratico = "p_1=0,8, p_2=0,6, p_3=0,4, p_4=0,2, BP=1 → BLEU≈0,45 (aceitável). BLEU>0,5: excelente",
            Unidades = "adimensional",
            VariavelResultado = "BLEU",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "p1", Nome = "p_1", Descricao = "Precisão unigram", Unidade = "", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "p2", Nome = "p_2", Descricao = "Precisão bigram", Unidade = "", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "p3", Nome = "p_3", Descricao = "Precisão trigram", Unidade = "", ValorPadrao = 0.4, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "p4", Nome = "p_4", Descricao = "Precisão 4-gram", Unidade = "", ValorPadrao = 0.2, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "BP", Nome = "BP", Descricao = "Brevity penalty", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double p1 = inputs["p1"];
                double p2 = inputs["p2"];
                double p3 = inputs["p3"];
                double p4 = inputs["p4"];
                double BP = inputs["BP"];
                
                if (p1 <= 0 || p2 <= 0 || p3 <= 0 || p4 <= 0) return 0;
                
                // BLEU-4: média geométrica
                double geo_mean = Math.Pow(p1 * p2 * p3 * p4, 0.25);
                
                return BP * geo_mean;
            }
        };
    }

    public static Formula V8_NLP230_Perplexidade()
    {
        return new Formula
        {
            Id = "V8-NLP230",
            CodigoCompendio = "230",
            Nome = "Perplexidade — Modelo de Linguagem",
            Categoria = "NLP",
            SubCategoria = "Avaliação",
            Expressao = "PPL = exp(-1/N * Σ log P(w_i | context))",
            ExprTexto = "Perplexity",
            Descricao = "N=palavras, P=probabilidade. PPL baixo: melhor modelo. PPL=branching factor médio.",
            Criador = "Teoria da informação",
            AnoOrigin = "~1970s",
            ExemploPratico = "log P médio=-2,3 → PPL=exp(2,3)≈10 (modelo prevê ~10 palavras equiprováveis). GPT-3: PPL~20",
            Unidades = "adimensional",
            VariavelResultado = "PPL",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "avg_log_prob", Nome = "Média log P", Descricao = "-1/N * Σlog P", Unidade = "", ValorPadrao = -2.3, ValorMin = -20, ValorMax = 0, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double avg_log_prob = inputs["avg_log_prob"];
                
                return Math.Exp(-avg_log_prob);
            }
        };
    }

    public static Formula V8_NLP231_NgramProbabilidade()
    {
        return new Formula
        {
            Id = "V8-NLP231",
            CodigoCompendio = "231",
            Nome = "Probabilidade N-gram — Bigram",
            Categoria = "NLP",
            SubCategoria = "Modelos de Linguagem",
            Expressao = "P(w_i | w_{i-1}) = count(w_{i-1}, w_i) / count(w_{i-1})",
            ExprTexto = "Bigram prob",
            Descricao = "w_{i-1}=palavra anterior. Modelo bigram: cadeia Markov ordem 1. Trigram: ordem 2.",
            Criador = "Modelos estocásticos linguagem",
            AnoOrigin = "~1950s",
            ExemploPratico = "\"cat sat\": count(\"cat\",\"sat\")=10, count(\"cat\")=50 → P(sat|cat)=0,2 (20%)",
            Unidades = "adimensional",
            VariavelResultado = "prob",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "count_bigram", Nome = "count(w_{i-1},w_i)", Descricao = "Ocorrências bigram", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "count_unigram", Nome = "count(w_{i-1})", Descricao = "Ocorrências palavra anterior", Unidade = "", ValorPadrao = 50, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double count_bigram = inputs["count_bigram"];
                double count_unigram = inputs["count_unigram"];
                
                return count_bigram / count_unigram;
            }
        };
    }

    public static Formula V8_NLP232_SuavizacaoLaplace()
    {
        return new Formula
        {
            Id = "V8-NLP232",
            CodigoCompendio = "232",
            Nome = "Suavização Laplace — Add-One Smoothing",
            Categoria = "NLP",
            SubCategoria = "Modelos de Linguagem",
            Expressao = "P_smooth(w_i | w_{i-1}) = (count(w_{i-1}, w_i) + 1) / (count(w_{i-1}) + V)",
            ExprTexto = "Laplace smoothing",
            Descricao = "V=tamanho vocabulário. Adiciona 1 a todos contadores. Evita P=0 para n-gramas não vistos.",
            Criador = "Pierre-Simon Laplace",
            AnoOrigin = "~1800s",
            ExemploPratico = "count(bigram)=0, count(uniigram)=50, V=10000 → P_smooth≈1/10050≈0,0001 (não zero)",
            Unidades = "adimensional",
            VariavelResultado = "P_smooth",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "count_bigram", Nome = "count(bigram)", Descricao = "Ocorrências", Unidade = "", ValorPadrao = 0, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "count_unigram", Nome = "count(unigram)", Descricao = "Ocorrências anterior", Unidade = "", ValorPadrao = 50, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "V", Nome = "V", Descricao = "Vocabulário", Unidade = "", ValorPadrao = 10000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double count_bigram = inputs["count_bigram"];
                double count_unigram = inputs["count_unigram"];
                double V = inputs["V"];
                
                return (count_bigram + 1) / (count_unigram + V);
            }
        };
    }

    public static Formula V8_NLP233_F1Score()
    {
        return new Formula
        {
            Id = "V8-NLP233",
            CodigoCompendio = "233",
            Nome = "F1 Score — Média Harmônica Precisão-Recall",
            Categoria = "NLP",
            SubCategoria = "Avaliação",
            Expressao = "F1 = 2 * (Precision * Recall) / (Precision + Recall)",
            ExprTexto = "F1",
            Descricao = "Precision=TP/(TP+FP), Recall=TP/(TP+FN). F1∈[0,1]. 1=perfeito. Balanceado.",
            Criador = "Métricas classificação",
            AnoOrigin = "~1960s",
            ExemploPratico = "Precision=0,8, Recall=0,6 → F1≈0,686. F1>0,7: bom. F1<0,5: fraco",
            Unidades = "adimensional",
            VariavelResultado = "F1",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Precision", Nome = "Precision", Descricao = "Precisão", Unidade = "", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "Recall", Nome = "Recall", Descricao = "Revocação", Unidade = "", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Precision = inputs["Precision"];
                double Recall = inputs["Recall"];
                
                if (Precision + Recall == 0) return 0;
                
                return 2 * (Precision * Recall) / (Precision + Recall);
            }
        };
    }

    public static Formula V8_NLP234_Accuracy()
    {
        return new Formula
        {
            Id = "V8-NLP234",
            CodigoCompendio = "234",
            Nome = "Acurácia — Classificação",
            Categoria = "NLP",
            SubCategoria = "Avaliação",
            Expressao = "Acc = (TP + TN) / (TP + TN + FP + FN)",
            ExprTexto = "Accuracy",
            Descricao = "TP=verdadeiros positivos, TN=verdadeiros negativos, FP=falsos positivos, FN=falsos negativos.",
            Criador = "Métricas classificação",
            AnoOrigin = "~1950s",
            ExemploPratico = "TP=80, TN=70, FP=10, FN=40 → Acc=150/200=0,75 (75%). Classes desbalanceadas: F1>Acc",
            Unidades = "adimensional",
            VariavelResultado = "Acc",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "TP", Nome = "TP", Descricao = "Verdadeiros positivos", Unidade = "", ValorPadrao = 80, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "TN", Nome = "TN", Descricao = "Verdadeiros negativos", Unidade = "", ValorPadrao = 70, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "FP", Nome = "FP", Descricao = "Falsos positivos", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "FN", Nome = "FN", Descricao = "Falsos negativos", Unidade = "", ValorPadrao = 40, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double TP = inputs["TP"];
                double TN = inputs["TN"];
                double FP = inputs["FP"];
                double FN = inputs["FN"];
                
                double total = TP + TN + FP + FN;
                
                if (total == 0) return 0;
                
                return (TP + TN) / total;
            }
        };
    }

    public static Formula V8_NLP235_CrossEntropyLoss()
    {
        return new Formula
        {
            Id = "V8-NLP235",
            CodigoCompendio = "235",
            Nome = "Cross-Entropy Loss — Classificação",
            Categoria = "NLP",
            SubCategoria = "Funções de Perda",
            Expressao = "L = -Σ y_i * log(p_i)",
            ExprTexto = "Cross-entropy",
            Descricao = "y_i=label verdadeiro (one-hot), p_i=probabilidade predita. Minimiza divergência KL.",
            Criador = "Teoria da informação / Claude Shannon",
            AnoOrigin = "1948",
            ExemploPratico = "y=[1,0,0], p=[0,9,0,05,0,05] → L≈-log(0,9)≈0,105. p_correto alto: L baixo",
            Unidades = "adimensional",
            VariavelResultado = "L",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "p_true_class", Nome = "p_i (verdadeiro)", Descricao = "Prob. classe correta", Unidade = "", ValorPadrao = 0.9, ValorMin = 0.0001, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double p_true_class = inputs["p_true_class"];
                
                return -Math.Log(p_true_class);
            }
        };
    }

    public static Formula V8_NLP236_BPE_TokenizationCompressao()
    {
        return new Formula
        {
            Id = "V8-NLP236",
            CodigoCompendio = "236",
            Nome = "Byte Pair Encoding — Compressão Vocabulário",
            Categoria = "NLP",
            SubCategoria = "Tokenização",
            Expressao = "n_vocab = initial_chars + n_merges",
            ExprTexto = "BPE vocab size",
            Descricao = "BPE: iterativamente mescla pares frequentes. inicial=chars, +merges=subwords. GPT, RoBERTa.",
            Criador = "Philip Gage (compressão), adaptado NLP",
            AnoOrigin = "1994 (compressão), 2016 (NLP)",
            ExemploPratico = "256 chars + 30000 merges → vocab≈30256 tokens. Subwords: \"playing\"→\"play\"+\"ing\"",
            Unidades = "tokens",
            VariavelResultado = "n_vocab",
            UnidadeResultado = "tokens",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "initial_chars", Nome = "Chars iniciais", Descricao = "Alfabeto base", Unidade = "", ValorPadrao = 256, ValorMin = 1, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "n_merges", Nome = "Número merges", Descricao = "Operações BPE", Unidade = "", ValorPadrao = 30000, ValorMin = 0, ValorMax = 100000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double initial_chars = inputs["initial_chars"];
                double n_merges = inputs["n_merges"];
                
                return initial_chars + n_merges;
            }
        };
    }

    public static Formula V8_NLP237_PositionalEncoding()
    {
        return new Formula
        {
            Id = "V8-NLP237",
            CodigoCompendio = "237",
            Nome = "Positional Encoding — Transformers (seno)",
            Categoria = "NLP",
            SubCategoria = "Transformers",
            Expressao = "PE(pos, 2i) = sin(pos / 10000^(2i/d_model))",
            ExprTexto = "PE seno",
            Descricao = "pos=posição token, i=índice dimensão, d_model=dimensão. PE par: sin, ímpar: cos. Vaswani 2017.",
            Criador = "Vaswani et al.",
            AnoOrigin = "2017",
            ExemploPratico = "pos=10, i=0, d_model=512 → PE(10,0)=sin(10/1)≈-0,544. Codifica ordem sequência",
            Unidades = "adimensional",
            VariavelResultado = "PE",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "pos", Nome = "Posição", Descricao = "pos", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "i", Nome = "i", Descricao = "Índice dimensão", Unidade = "", ValorPadrao = 0, ValorMin = 0, ValorMax = 512, Obrigatoria = true },
                new() { Simbolo = "d_model", Nome = "d_model", Descricao = "Dimensão modelo", Unidade = "", ValorPadrao = 512, ValorMin = 1, ValorMax = 4096, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double pos = inputs["pos"];
                double i = inputs["i"];
                double d_model = inputs["d_model"];
                
                double denom = Math.Pow(10000, (2 * i) / d_model);
                
                return Math.Sin(pos / denom);
            }
        };
    }

    public static Formula V8_NLP238_LayerNormalization()
    {
        return new Formula
        {
            Id = "V8-NLP238",
            CodigoCompendio = "238",
            Nome = "Layer Normalization — Normalização Camada",
            Categoria = "NLP",
            SubCategoria = "Transformers",
            Expressao = "LN(x) = γ * ((x - μ) / σ) + β",
            ExprTexto = "LayerNorm",
            Descricao = "μ=média camada, σ=desvio padrão, γ,β=parâmetros treináveis. Estabiliza treinamento. Ba 2016.",
            Criador = "Ba, Kiros, Hinton",
            AnoOrigin = "2016",
            ExemploPratico = "x=5, μ=3, σ=2 → (5-3)/2=1 → γ·1+β. γ=1,β=0: normalização padrão",
            Unidades = "adimensional",
            VariavelResultado = "LN_x",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "x", Descricao = "Valor entrada", Unidade = "", ValorPadrao = 5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "mu", Nome = "μ", Descricao = "Média camada", Unidade = "", ValorPadrao = 3, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "sigma", Nome = "σ", Descricao = "Desvio padrão", Unidade = "", ValorPadrao = 2, ValorMin = 0.001, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "gamma", Nome = "γ", Descricao = "Parâmetro escala", Unidade = "", ValorPadrao = 1, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "beta", Nome = "β", Descricao = "Parâmetro deslocamento", Unidade = "", ValorPadrao = 0, ValorMin = -10, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double mu = inputs["mu"];
                double sigma = inputs["sigma"];
                double gamma = inputs["gamma"];
                double beta = inputs["beta"];
                
                return gamma * ((x - mu) / sigma) + beta;
            }
        };
    }

    public static Formula V8_NLP239_GELU_Ativacao()
    {
        return new Formula
        {
            Id = "V8-NLP239",
            CodigoCompendio = "239",
            Nome = "GELU — Gaussian Error Linear Unit",
            Categoria = "NLP",
            SubCategoria = "Funções de Ativação",
            Expressao = "GELU(x) ≈ 0.5 * x * (1 + tanh(sqrt(2/π) * (x + 0.044715*x³)))",
            ExprTexto = "GELU (aproximação)",
            Descricao = "Smooth ativação. BERT, GPT. GELU(x)=x·Φ(x), Φ=CDF Gaussiana. Hendrycks 2016.",
            Criador = "Dan Hendrycks e Kevin Gimpel",
            AnoOrigin = "2016",
            ExemploPratico = "x=1 → GELU≈0,84. x=-1 → GELU≈-0,16. Suave, não estritamente 0 para x<0",
            Unidades = "adimensional",
            VariavelResultado = "GELU_x",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "x", Descricao = "Entrada", Unidade = "", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                
                double sqrt_2_pi = Math.Sqrt(2.0 / Math.PI);
                double inner = sqrt_2_pi * (x + 0.044715 * Math.Pow(x, 3));
                
                return 0.5 * x * (1 + Math.Tanh(inner));
            }
        };
    }

    public static Formula V8_NLP240_Dropout()
    {
        return new Formula
        {
            Id = "V8-NLP240",
            CodigoCompendio = "240",
            Nome = "Dropout — Regularização",
            Categoria = "NLP",
            SubCategoria = "Regularização",
            Expressao = "y_i = x_i * m_i / (1 - p)",
            ExprTexto = "Dropout (inference scaling)",
            Descricao = "p=taxa dropout (treino), m_i~Bernoulli(1-p). Inferência: escala 1/(1-p). Srivastava 2014.",
            Criador = "Srivastava et al.",
            AnoOrigin = "2014",
            ExemploPratico = "p=0,1 (10% dropout) → escala 1/(1-0,1)≈1,11 inferência. p=0,5: escala 2x",
            Unidades = "adimensional",
            VariavelResultado = "scale_factor",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "p", Nome = "Taxa dropout", Descricao = "p", Unidade = "", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 0.99, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double p = inputs["p"];
                
                return 1.0 / (1 - p);
            }
        };
    }

    public static Formula V8_NLP241_AdamOptimizer_Beta1()
    {
        return new Formula
        {
            Id = "V8-NLP241",
            CodigoCompendio = "241",
            Nome = "Adam Optimizer — Momento β1",
            Categoria = "NLP",
            SubCategoria = "Otimização",
            Expressao = "m_t = β1 * m_{t-1} + (1 - β1) * g_t",
            ExprTexto = "Adam momento",
            Descricao = "m_t=momento primeira ordem (média gradientes), g_t=gradiente, β1≈0,9. Kingma 2015.",
            Criador = "Diederik P. Kingma e Jimmy Ba",
            AnoOrigin = "2015",
            ExemploPratico = "β1=0,9, m_{t-1}=1, g_t=2 → m_t=0,9·1+0,1·2=1,1. Suaviza gradientes",
            Unidades = "adimensional",
            VariavelResultado = "m_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "beta1", Nome = "β1", Descricao = "Coef. momento", Unidade = "", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 0.999, Obrigatoria = true },
                new() { Simbolo = "m_prev", Nome = "m_{t-1}", Descricao = "Momento anterior", Unidade = "", ValorPadrao = 1, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "g_t", Nome = "g_t", Descricao = "Gradiente atual", Unidade = "", ValorPadrao = 2, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double beta1 = inputs["beta1"];
                double m_prev = inputs["m_prev"];
                double g_t = inputs["g_t"];
                
                return beta1 * m_prev + (1 - beta1) * g_t;
            }
        };
    }

    public static Formula V8_NLP242_AdamOptimizer_Beta2()
    {
        return new Formula
        {
            Id = "V8-NLP242",
            CodigoCompendio = "242",
            Nome = "Adam Optimizer — Variância β2",
            Categoria = "NLP",
            SubCategoria = "Otimização",
            Expressao = "v_t = β2 * v_{t-1} + (1 - β2) * g_t²",
            ExprTexto = "Adam variância",
            Descricao = "v_t=momento segunda ordem (variância), g_t²=gradiente ao quadrado, β2≈0,999. Kingma 2015.",
            Criador = "Diederik P. Kingma e Jimmy Ba",
            AnoOrigin = "2015",
            ExemploPratico = "β2=0,999, v_{t-1}=0,5, g_t=0,1 → v_t≈0,999·0,5+0,001·0,01≈0,4995. Adaptativo",
            Unidades = "adimensional",
            VariavelResultado = "v_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "beta2", Nome = "β2", Descricao = "Coef. variância", Unidade = "", ValorPadrao = 0.999, ValorMin = 0, ValorMax = 0.9999, Obrigatoria = true },
                new() { Simbolo = "v_prev", Nome = "v_{t-1}", Descricao = "Variância anterior", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "g_t_sq", Nome = "g_t²", Descricao = "Gradiente²", Unidade = "", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double beta2 = inputs["beta2"];
                double v_prev = inputs["v_prev"];
                double g_t_sq = inputs["g_t_sq"];
                
                return beta2 * v_prev + (1 - beta2) * g_t_sq;
            }
        };
    }

    public static Formula V8_NLP243_LearningRateWarmup()
    {
        return new Formula
        {
            Id = "V8-NLP243",
            CodigoCompendio = "243",
            Nome = "Learning Rate Warmup — Linear",
            Categoria = "NLP",
            SubCategoria = "Otimização",
            Expressao = "lr_t = lr_max * (t / warmup_steps)",
            ExprTexto = "LR warmup",
            Descricao = "t=step atual, warmup_steps=passos aquecimento. lr_t cresce linearmente até lr_max. Goyal 2017.",
            Criador = "Goyal et al. (Facebook AI)",
            AnoOrigin = "2017",
            ExemploPratico = "lr_max=0,001, t=500, warmup=1000 → lr_t=0,0005. t=1000: lr_t=0,001 (máximo)",
            Unidades = "adimensional",
            VariavelResultado = "lr_t",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "lr_max", Nome = "lr_max", Descricao = "LR máximo", Unidade = "", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "t", Descricao = "Step atual", Unidade = "", ValorPadrao = 500, ValorMin = 0, ValorMax = 1e9, Obrigatoria = true },
                new() { Simbolo = "warmup_steps", Nome = "Warmup steps", Descricao = "Passos aquecimento", Unidade = "", ValorPadrao = 1000, ValorMin = 1, ValorMax = 1e9, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double lr_max = inputs["lr_max"];
                double t = inputs["t"];
                double warmup_steps = inputs["warmup_steps"];
                
                if (t >= warmup_steps) return lr_max;
                
                return lr_max * (t / warmup_steps);
            }
        };
    }
}
