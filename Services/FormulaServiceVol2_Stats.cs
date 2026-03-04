using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═════════════════════════════════════════════════════════════
    //  VOLUME 2 — PARTE III: ESTATÍSTICA E PROCESSOS ESTOCÁSTICOS
    // ═════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 11. SÉRIES TEMPORAIS
    // ─────────────────────────────────────────────────────
    private void AdicionarSeriesTemporais()
    {
        _formulas.AddRange([
            // 11.1 Processos e Estacionariedade
            new Formula { Id = "st_01", Nome = "Processo Estocástico {Xₜ}", Categoria = "Séries Temporais", SubCategoria = "Fundamentos",
                Expressao = "{Xₜ : t∈T}: família de variáveis aleatórias", ExprTexto = "{Xₜ : t ∈ T} = família indexada de v.a.", Icone = "Xₜ",
                Descricao = "Série temporal: sequência de observações ordenadas no tempo. Processo estocástico: modelo probabilístico para séries temporais." },
            new Formula { Id = "st_02", Nome = "Estacionariedade Fraca", Categoria = "Séries Temporais", SubCategoria = "Fundamentos",
                Expressao = "E[Xₜ]=μ const; Cov(Xₜ,Xₜ₊ₕ)=γ(h)", ExprTexto = "E[Xₜ]=μ (const); γ(h)=Cov(Xₜ,Xₜ₊ₕ) depende só de h", Icone = "Xₜ",
                Descricao = "Estacionariedade de segunda ordem: média constante e autocovariância depende apenas do lag h. Base para análise de séries temporais." },
            new Formula { Id = "st_03", Nome = "Função de Autocorrelação ρ(h)", Categoria = "Séries Temporais", SubCategoria = "Fundamentos",
                Expressao = "ρ(h) = γ(h)/γ(0)", ExprTexto = "ρ(h) = γ(h)/γ(0) = Corr(Xₜ, Xₜ₊ₕ)", Icone = "Xₜ",
                Descricao = "ACF: autocorrelação normalizada no lag h. ρ(0)=1, |ρ(h)|≤1. Ferramenta fundamental para identificação de modelos." },
            new Formula { Id = "st_04", Nome = "Ruído Branco εₜ", Categoria = "Séries Temporais", SubCategoria = "Fundamentos",
                Expressao = "E[εₜ]=0; Var(εₜ)=σ²; Cov(εₜ,εₛ)=0 (t≠s)", ExprTexto = "εₜ ~ WN(0,σ²): E=0, Var=σ², Cov=0 (t≠s)", Icone = "Xₜ",
                Descricao = "Ruído branco: processo não correlacionado com média zero e variância constante. Componente de inovação em modelos ARMA/ARIMA." },
            new Formula { Id = "st_05", Nome = "Passeio Aleatório", Categoria = "Séries Temporais", SubCategoria = "Fundamentos",
                Expressao = "Xₜ = Xₜ₋₁ + εₜ", ExprTexto = "Xₜ = Xₜ₋₁ + εₜ (random walk)", Icone = "Xₜ",
                Descricao = "Passeio aleatório: acumula choques aleatórios. Não estacionário (variância cresce com t). Hipótese de mercado eficiente." },
            new Formula { Id = "st_06", Nome = "Operador de Atraso B", Categoria = "Séries Temporais", SubCategoria = "Fundamentos",
                Expressao = "BXₜ = Xₜ₋₁; B²Xₜ = Xₜ₋₂; (1-B)Xₜ = ΔXₜ", ExprTexto = "BXₜ = Xₜ₋₁; (1−B)Xₜ = ΔXₜ (diferenciação)", Icone = "Xₜ",
                Descricao = "Operador backshift B: simplifica notação de modelos. ΔXₜ = (1-B)Xₜ = Xₜ-Xₜ₋₁ (primeira diferença)." },

            // 11.2 Modelos ARMA e ARIMA
            new Formula { Id = "st_07", Nome = "Modelo AR(p)", Categoria = "Séries Temporais", SubCategoria = "ARIMA",
                Expressao = "Xₜ = c + φ₁Xₜ₋₁ + ... + φₚXₜ₋ₚ + εₜ", ExprTexto = "Xₜ = c + Σᵢ₌₁ᵖ φᵢXₜ₋ᵢ + εₜ", Icone = "Xₜ",
                Descricao = "Autoregressivo de ordem p: valor atual depende linearmente dos p valores anteriores mais inovação. ACF decai exponencialmente." },
            new Formula { Id = "st_08", Nome = "Modelo MA(q)", Categoria = "Séries Temporais", SubCategoria = "ARIMA",
                Expressao = "Xₜ = μ + εₜ + θ₁εₜ₋₁ + ... + θqεₜ₋q", ExprTexto = "Xₜ = μ + εₜ + Σⱼ₌₁ᵍ θⱼεₜ₋ⱼ", Icone = "Xₜ",
                Descricao = "Média Móvel de ordem q: valor atual é combinação linear dos q últimos erros. ACF trunca em lag q." },
            new Formula { Id = "st_09", Nome = "Modelo ARMA(p,q)", Categoria = "Séries Temporais", SubCategoria = "ARIMA",
                Expressao = "φ(B)Xₜ = θ(B)εₜ", ExprTexto = "(1−φ₁B−...−φₚBᵖ)Xₜ = (1+θ₁B+...+θqBᵍ)εₜ", Icone = "Xₜ",
                Descricao = "Combina AR(p) e MA(q): modelo parcimonioso para séries estacionárias. Identificação via ACF e PACF.",
                Criador = "Box / Jenkins", AnoOrigin = "1970" },
            new Formula { Id = "st_10", Nome = "Modelo ARIMA(p,d,q)", Categoria = "Séries Temporais", SubCategoria = "ARIMA",
                Expressao = "φ(B)(1-B)ᵈXₜ = θ(B)εₜ", ExprTexto = "φ(B)(1−B)ᵈXₜ = θ(B)εₜ", Icone = "Xₜ",
                Descricao = "ARIMA: ARMA aplicado à série diferenciada d vezes. d=ordem de integração (diferenciação para estacionariedade).",
                Criador = "Box / Jenkins", AnoOrigin = "1970" },
            new Formula { Id = "st_11", Nome = "Modelo SARIMA", Categoria = "Séries Temporais", SubCategoria = "ARIMA",
                Expressao = "ARIMA(p,d,q)×(P,D,Q)_s", ExprTexto = "φ(B)Φ(Bˢ)(1−B)ᵈ(1−Bˢ)ᴰ Xₜ = θ(B)Θ(Bˢ)εₜ", Icone = "Xₜ",
                Descricao = "SARIMA: ARIMA com componente sazonal de período s. Captura padrões que se repetem periodicamente." },
            new Formula { Id = "st_12", Nome = "AIC/BIC (Critérios de Seleção)", Categoria = "Séries Temporais", SubCategoria = "ARIMA",
                Expressao = "AIC = -2 ln L + 2k; BIC = -2 ln L + k ln n", ExprTexto = "AIC = −2 ln L + 2k; BIC = −2 ln L + k ln n", Icone = "Xₜ",
                Descricao = "Critérios de informação para seleção de modelos: balanceiam ajuste (-2 ln L) com complexidade (k parâmetros). Menor = melhor.",
                Criador = "Akaike / Schwarz", AnoOrigin = "1974/1978" },

            // 11.3 Modelos de Volatilidade e Previsão
            new Formula { Id = "st_13", Nome = "Modelo ARCH(q)", Categoria = "Séries Temporais", SubCategoria = "Volatilidade",
                Expressao = "σₜ² = ω + α₁ε²ₜ₋₁ + ... + αqε²ₜ₋q", ExprTexto = "σₜ² = ω + Σᵢ₌₁ᵍ αᵢ εₜ₋ᵢ²", Icone = "Xₜ",
                Descricao = "ARCH: variância condicional depende de erros passados quadrados. Captura volatilidade variante no tempo.",
                Criador = "Robert Engle", AnoOrigin = "1982" },
            new Formula { Id = "st_14", Nome = "Modelo GARCH(p,q)", Categoria = "Séries Temporais", SubCategoria = "Volatilidade",
                Expressao = "σₜ² = ω + Σαᵢε²ₜ₋ᵢ + Σβⱼσ²ₜ₋ⱼ", ExprTexto = "σₜ² = ω + Σαᵢεₜ₋ᵢ² + Σβⱼσₜ₋ⱼ²", Icone = "Xₜ",
                Descricao = "GARCH: generalização de ARCH. Variância depende de erros passados E variâncias passadas. GARCH(1,1) é o mais usado em finanças.",
                Criador = "Tim Bollerslev", AnoOrigin = "1986" },
            new Formula { Id = "st_15", Nome = "Previsão (Erro Quadrático Mínimo)", Categoria = "Séries Temporais", SubCategoria = "Volatilidade",
                Expressao = "X̂ₜ₊ₕ = E[Xₜ₊ₕ | Xₜ, Xₜ₋₁, ...]", ExprTexto = "X̂ₜ₊ₕ = E[Xₜ₊ₕ | Fₜ] (previsão ótima)", Icone = "Xₜ",
                Descricao = "Previsão h passos à frente: esperança condicional dada a história. Minimiza erro quadrático médio." },
            new Formula { Id = "st_16", Nome = "Decomposição STL (Sazonal+Tendência)", Categoria = "Séries Temporais", SubCategoria = "Volatilidade",
                Expressao = "Xₜ = Tₜ + Sₜ + Rₜ", ExprTexto = "Xₜ = Tendência + Sazonalidade + Resíduo", Icone = "Xₜ",
                Descricao = "Decomposição aditiva: série = tendência + componente sazonal + resíduo aleatório. STL usa LOESS para decomposição robusta." },
            new Formula { Id = "st_17", Nome = "Alisamento Exponencial (ETS)", Categoria = "Séries Temporais", SubCategoria = "Volatilidade",
                Expressao = "X̂ₜ₊₁ = αXₜ + (1-α)X̂ₜ", ExprTexto = "X̂ₜ₊₁ = αXₜ + (1−α)X̂ₜ  (0<α<1)", Icone = "Xₜ",
                Descricao = "Alisamento exponencial simples: previsão é média ponderada da observação atual e previsão anterior. Holt-Winters: inclui tendência e sazonalidade.",
                Variaveis = [
                    new() { Simbolo = "Xt", Nome = "Xₜ (observação atual)", ValorPadrao = 100 },
                    new() { Simbolo = "Ft", Nome = "X̂ₜ (previsão anterior)", ValorPadrao = 95 },
                    new() { Simbolo = "alpha", Nome = "α (suavização)", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 },
                ],
                VariavelResultado = "X̂ₜ₊₁",
                Calcular = vars => vars["alpha"]*vars["Xt"] + (1-vars["alpha"])*vars["Ft"] },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 12. ANÁLISE MULTIVARIADA
    // ─────────────────────────────────────────────────────
    private void AdicionarAnaliseMultivariada()
    {
        _formulas.AddRange([
            // 12.1 PCA
            new Formula { Id = "mv_pca01", Nome = "Componentes Principais (PCA)", Categoria = "Análise Multivariada", SubCategoria = "PCA",
                Expressao = "Σw = λw (autovalores da matriz de covariância)", ExprTexto = "Σw = λw; PC₁ maximiza variância projetada", Icone = "Σ",
                Descricao = "PCA: encontra direções de máxima variância nos dados. Autovalores de Σ (covariância) dão variância em cada componente.",
                Criador = "Karl Pearson / Harold Hotelling", AnoOrigin = "1901/1933" },
            new Formula { Id = "mv_pca02", Nome = "Variância Explicada", Categoria = "Análise Multivariada", SubCategoria = "PCA",
                Expressao = "Var. explicada por PCk = λₖ / Σλᵢ", ExprTexto = "Proporção da variância = λₖ / Σᵢ λᵢ", Icone = "Σ",
                Descricao = "Fração da variância total capturada pela k-ésima componente principal. Soma das proporções = 1.",
                Variaveis = [
                    new() { Simbolo = "lk", Nome = "λₖ (autovalor k)", ValorPadrao = 5 },
                    new() { Simbolo = "sL", Nome = "Σλᵢ (soma dos autovalores)", ValorPadrao = 20 },
                ],
                VariavelResultado = "Proporção da variância",
                Calcular = vars => vars["lk"] / vars["sL"] },
            new Formula { Id = "mv_pca03", Nome = "Decomposição Espectral de Σ", Categoria = "Análise Multivariada", SubCategoria = "PCA",
                Expressao = "Σ = PΛPᵀ", ExprTexto = "Σ = PΛPᵀ (P = autovetores, Λ = diag(λ₁,...,λₚ))", Icone = "Σ",
                Descricao = "Matriz de covariância decomposta em autovetores (P) e autovalores (Λ). Muda de base para componentes principais." },
            new Formula { Id = "mv_pca04", Nome = "Scores z = Pᵀ(x - μ)", Categoria = "Análise Multivariada", SubCategoria = "PCA",
                Expressao = "z = Pᵀ(x - μ)", ExprTexto = "zᵢ = wᵢᵀ(x − μ) (score da i-ésima PC)", Icone = "Σ",
                Descricao = "Scores: projeção dos dados centralizados nas componentes principais. Dados transformados são não-correlacionados." },
            new Formula { Id = "mv_pca05", Nome = "Biplot PCA", Categoria = "Análise Multivariada", SubCategoria = "PCA",
                Expressao = "X ≈ UΛ½Pᵀ (SVD truncada)", ExprTexto = "X ≈ U_q Λ_q^{1/2} P_q^T (q primeiras PCs)", Icone = "Σ",
                Descricao = "Biplot: representação 2D de observações (scores) e variáveis (loadings) simultaneamente. Usa SVD truncada da matriz de dados." },
            new Formula { Id = "mv_pca06", Nome = "Kernel PCA", Categoria = "Análise Multivariada", SubCategoria = "PCA",
                Expressao = "PCA em espaço de features φ(x) via kernel K", ExprTexto = "Autoproblema: KΑ = λnΑ (K: matriz kernel)", Icone = "Σ",
                Descricao = "PCA não-linear: usa kernel trick para PCA em espaço de features de alta dimensão sem calcular φ(x) explicitamente." },

            // 12.2 Análise Discriminante
            new Formula { Id = "mv_lda01", Nome = "Análise Discriminante Linear (LDA)", Categoria = "Análise Multivariada", SubCategoria = "Discriminante",
                Expressao = "max w: wᵀSBw / wᵀSWw (Fisher)", ExprTexto = "max_w  wᵀ S_B w / wᵀ S_W w (critério de Fisher)", Icone = "Σ",
                Descricao = "LDA de Fisher: encontra projeção que maximiza separação entre classes relativa à dispersão dentro das classes.",
                Criador = "Ronald Fisher", AnoOrigin = "1936" },
            new Formula { Id = "mv_lda02", Nome = "Scatter Between-Class SB", Categoria = "Análise Multivariada", SubCategoria = "Discriminante",
                Expressao = "SB = Σₖ nₖ(μₖ-μ)(μₖ-μ)ᵀ", ExprTexto = "S_B = Σₖ nₖ(μₖ−μ̄)(μₖ−μ̄)ᵀ", Icone = "Σ",
                Descricao = "Matriz scatter entre classes: mede a dispersão dos centróides das classes. nₖ = tamanho da classe k." },
            new Formula { Id = "mv_lda03", Nome = "Scatter Within-Class SW", Categoria = "Análise Multivariada", SubCategoria = "Discriminante",
                Expressao = "SW = Σₖ Σ_{x∈Cₖ} (x-μₖ)(x-μₖ)ᵀ", ExprTexto = "S_W = Σₖ Σ_{x∈Cₖ} (x−μₖ)(x−μₖ)ᵀ", Icone = "Σ",
                Descricao = "Matriz scatter dentro das classes: mede a variabilidade interna de cada classe." },
            new Formula { Id = "mv_lda04", Nome = "QDA (Quadrática)", Categoria = "Análise Multivariada", SubCategoria = "Discriminante",
                Expressao = "δₖ(x) = -½ln|Σₖ| - ½(x-μₖ)ᵀΣₖ⁻¹(x-μₖ) + ln πₖ", ExprTexto = "δₖ quadrático: cada classe com covariância própria Σₖ", Icone = "Σ",
                Descricao = "QDA: análise discriminante quadrática. Cada classe tem covariância diferente → fronteira de decisão quadrática." },

            // 12.3 Análise Fatorial e Clustering
            new Formula { Id = "mv_fa01", Nome = "Modelo Fatorial X = Λf + ε", Categoria = "Análise Multivariada", SubCategoria = "Fatorial/Clustering",
                Expressao = "X = μ + Λf + ε", ExprTexto = "X = μ + Λf + ε (f: fatores latentes, Λ: loadings)", Icone = "Σ",
                Descricao = "Análise fatorial: variáveis observadas X explicadas por poucos fatores latentes f. Λ=matriz de loadings, ε=erros específicos." },
            new Formula { Id = "mv_fa02", Nome = "Σ = ΛΛᵀ + Ψ", Categoria = "Análise Multivariada", SubCategoria = "Fatorial/Clustering",
                Expressao = "Σ = ΛΛᵀ + Ψ", ExprTexto = "Σ = ΛΛᵀ + Ψ (Ψ diagonal: variâncias específicas)", Icone = "Σ",
                Descricao = "Covariância no modelo fatorial: parte comum (ΛΛᵀ) + parte específica (Ψ diagonal). Comunalidade de xₖ: Σⱼλₖⱼ²." },
            new Formula { Id = "mv_fa03", Nome = "Rotação Varimax", Categoria = "Análise Multivariada", SubCategoria = "Fatorial/Clustering",
                Expressao = "Rotação ortogonal que maximiza simplicidade dos loadings", ExprTexto = "Varimax: maximiza Σᵢ Var(λᵢⱼ² / hᵢ²)", Icone = "Σ",
                Descricao = "Rotação Varimax: rotaciona fatores para obter loadings mais 'simples' (próximos de 0 ou ±1). Facilita interpretação.",
                Criador = "Henry Kaiser", AnoOrigin = "1958" },
            new Formula { Id = "mv_cl01", Nome = "K-Means", Categoria = "Análise Multivariada", SubCategoria = "Fatorial/Clustering",
                Expressao = "min Σₖ Σ_{x∈Cₖ} ||x-μₖ||²", ExprTexto = "min Σₖ Σ_{x∈Cₖ} ‖x − μₖ‖²", Icone = "Σ",
                Descricao = "K-Means: particiona n observações em K clusters minimizando variância intra-cluster. Convergência garantida (mínimo local).",
                Criador = "Stuart Lloyd / MacQueen", AnoOrigin = "1957/1967" },
            new Formula { Id = "mv_cl02", Nome = "Clustering Hierárquico", Categoria = "Análise Multivariada", SubCategoria = "Fatorial/Clustering",
                Expressao = "Aglomerativo: une clusters mais próximos iterativamente", ExprTexto = "D(Cᵢ,Cⱼ): single/complete/average linkage", Icone = "Σ",
                Descricao = "Clustering hierárquico: cria dendrograma. Linkages: single (mín dist), complete (máx dist), average (média), Ward (variância)." },
            new Formula { Id = "mv_cl03", Nome = "Índice Silhouette", Categoria = "Análise Multivariada", SubCategoria = "Fatorial/Clustering",
                Expressao = "s(i) = (b(i)-a(i))/max(a(i),b(i))", ExprTexto = "s(i) = (b(i)−a(i)) / max(a(i),b(i))", Icone = "Σ",
                Descricao = "Silhouette: avalia qualidade de clustering. a(i)=distância média intra-cluster, b(i)=distância ao cluster mais próximo. s∈[-1,1], maior=melhor.",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "a(i) (dist intra-cluster)", ValorPadrao = 2 },
                    new() { Simbolo = "b", Nome = "b(i) (dist inter-cluster)", ValorPadrao = 5 },
                ],
                VariavelResultado = "s(i)",
                Calcular = vars => (vars["b"]-vars["a"])/Math.Max(vars["a"],vars["b"]) },
            new Formula { Id = "mv_cl04", Nome = "Distância de Mahalanobis", Categoria = "Análise Multivariada", SubCategoria = "Fatorial/Clustering",
                Expressao = "D²(x) = (x-μ)ᵀΣ⁻¹(x-μ)", ExprTexto = "D²_M(x) = (x−μ)ᵀ Σ⁻¹ (x−μ)", Icone = "Σ",
                Descricao = "Distância que leva em conta a covariância dos dados. Independe da escala das variáveis. Para Σ=I, reduz-se à euclidiana.",
                Criador = "P.C. Mahalanobis", AnoOrigin = "1936" },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 13. ESTATÍSTICA BAYESIANA E PROCESSOS ESTOCÁSTICOS
    // ─────────────────────────────────────────────────────
    private void AdicionarEstatisticaBayesiana()
    {
        _formulas.AddRange([
            // 13.1 Inferência Bayesiana
            new Formula { Id = "by_01", Nome = "Teorema de Bayes", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "P(θ|D) = P(D|θ)·P(θ) / P(D)", ExprTexto = "P(θ|D) = P(D|θ)P(θ) / P(D)", Icone = "θ",
                Descricao = "Posterior ∝ verossimilhança × priori. Atualização bayesiana: dados D atualizam crença sobre parâmetro θ.",
                Criador = "Thomas Bayes / Pierre-Simon Laplace", AnoOrigin = "1763/1812" },
            new Formula { Id = "by_02", Nome = "Posterior ∝ Likelihood × Prior", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "π(θ|x) ∝ L(x|θ)·π(θ)", ExprTexto = "π(θ|x) ∝ L(x|θ) · π(θ)", Icone = "θ",
                Descricao = "Forma proporcional do teorema de Bayes: ignora constante de normalização P(D). Posterior é determinada a menos de constante." },
            new Formula { Id = "by_03", Nome = "Priori Conjugada", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "Priori conjugada → posterior mesma família", ExprTexto = "Se priori é conjugada ao likelihood, posterior tem mesma família", Icone = "θ",
                Descricao = "Priori conjugada: posterior pertence à mesma família distribucional. Ex: Beta-Binomial, Normal-Normal, Gamma-Poisson." },
            new Formula { Id = "by_04", Nome = "Estimador MAP", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "θ̂_MAP = argmax π(θ|x)", ExprTexto = "θ̂_MAP = argmax_θ π(θ|x) = argmax [ln L + ln π]", Icone = "θ",
                Descricao = "Maximum A Posteriori: moda da distribuição posterior. Com priori uniforme, coincide com MLE." },
            new Formula { Id = "by_05", Nome = "Estimador Bayesiano (Média Posterior)", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "θ̂_Bayes = E[θ|x] = ∫θ·π(θ|x)dθ", ExprTexto = "θ̂_Bayes = E[θ|x] = ∫ θ π(θ|x) dθ", Icone = "θ",
                Descricao = "Média da posterior: minimiza perda quadrática esperada. Estimador bayesiano ótimo sob perda quadrática." },
            new Formula { Id = "by_06", Nome = "Intervalo de Credibilidade", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "P(a < θ < b | x) = 1 - α", ExprTexto = "P(a < θ < b | x) = 1 − α (95% se α=0.05)", Icone = "θ",
                Descricao = "Intervalo bayesiano: probabilidade posterior de θ estar no intervalo. Interpretação direta (diferente do intervalo de confiança frequentista)." },
            new Formula { Id = "by_07", Nome = "Fator de Bayes BF₁₂", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "BF₁₂ = P(D|M₁)/P(D|M₂)", ExprTexto = "BF₁₂ = P(D|M₁) / P(D|M₂) = ∫L₁π₁dθ / ∫L₂π₂dθ", Icone = "θ",
                Descricao = "Fator de Bayes: razão de evidências marginais entre dois modelos. BF>10: evidência forte para M₁. Alternativa bayesiana ao p-valor." },
            new Formula { Id = "by_08", Nome = "Prior Não-Informativa de Jeffreys", Categoria = "Estatística Bayesiana", SubCategoria = "Inferência Bayesiana",
                Expressao = "π(θ) ∝ √det(I(θ))", ExprTexto = "π(θ) ∝ √det(I(θ)) (I = informação de Fisher)", Icone = "θ",
                Descricao = "Prior de Jeffreys: invariante sob reparametrização. Proporcional à raiz do determinante da informação de Fisher.",
                Criador = "Harold Jeffreys", AnoOrigin = "1946" },

            // 13.2 Métodos computacionais
            new Formula { Id = "by_mc01", Nome = "Monte Carlo via Cadeia de Markov (MCMC)", Categoria = "Estatística Bayesiana", SubCategoria = "Métodos MCMC",
                Expressao = "θ⁽ⁱ⁾ ~ π(θ|x) via cadeia de Markov", ExprTexto = "Gera amostras θ⁽¹⁾, θ⁽²⁾, ... da posterior via cadeia de Markov", Icone = "θ",
                Descricao = "MCMC: método computacional para amostrar de distribuições posteriores complexas. Cadeia converge para a distribuição alvo.",
                Criador = "Metropolis et al.", AnoOrigin = "1953" },
            new Formula { Id = "by_mc02", Nome = "Algoritmo de Metropolis-Hastings", Categoria = "Estatística Bayesiana", SubCategoria = "Métodos MCMC",
                Expressao = "α = min(1, π(θ*)q(θ|θ*) / π(θ)q(θ*|θ))", ExprTexto = "α = min(1, [π(θ*)q(θ|θ*)] / [π(θ)q(θ*|θ)])", Icone = "θ",
                Descricao = "Metropolis-Hastings: propõe θ* da proposta q, aceita com probabilidade α. Aceitar sempre que posterior aumenta.",
                Criador = "Metropolis / Hastings", AnoOrigin = "1953/1970" },
            new Formula { Id = "by_mc03", Nome = "Gibbs Sampling", Categoria = "Estatística Bayesiana", SubCategoria = "Métodos MCMC",
                Expressao = "θᵢ⁽ᵗ⁺¹⁾ ~ π(θᵢ | θ₋ᵢ⁽ᵗ⁾, x)", ExprTexto = "θᵢ^(t+1) ~ π(θᵢ | θ₋ᵢ^(t), x) para cada i", Icone = "θ",
                Descricao = "Gibbs: caso especial de MH onde cada componente é amostrada da condicional completa. Sem taxa de rejeição.",
                Criador = "Geman & Geman", AnoOrigin = "1984" },
            new Formula { Id = "by_mc04", Nome = "Hamiltonian Monte Carlo (HMC)", Categoria = "Estatística Bayesiana", SubCategoria = "Métodos MCMC",
                Expressao = "Usa gradiente ∇log π(θ) para propostas eficientes", ExprTexto = "Dinâmica hamiltoniana: simula (θ,p) com H = −log π(θ) + ½pᵀp", Icone = "θ",
                Descricao = "HMC: usa gradiente da posterior para fazer propostas distantes mas com alta taxa de aceitação. Base do Stan.",
                Criador = "Duane / Neal", AnoOrigin = "1987/2011" },
            new Formula { Id = "by_mc05", Nome = "Diagnóstico R̂ (Gelman-Rubin)", Categoria = "Estatística Bayesiana", SubCategoria = "Métodos MCMC",
                Expressao = "R̂ = √((n-1)/n + B/(nW))", ExprTexto = "R̂ ≈ √(Var_estimada / W) → 1 indica convergência", Icone = "θ",
                Descricao = "R̂: compara variância entre/dentro de cadeias MCMC. R̂<1.1 sugere convergência. Usar múltiplas cadeias com inicializações distintas.",
                Criador = "Gelman / Rubin", AnoOrigin = "1992" },

            // 13.3 Cadeias de Markov
            new Formula { Id = "by_mk01", Nome = "Cadeia de Markov (Propriedade)", Categoria = "Estatística Bayesiana", SubCategoria = "Cadeias de Markov",
                Expressao = "P(Xₜ₊₁|Xₜ,...,X₀) = P(Xₜ₊₁|Xₜ)", ExprTexto = "P(Xₜ₊₁ = j | Xₜ = i, ...) = P(Xₜ₊₁ = j | Xₜ = i)", Icone = "θ",
                Descricao = "Propriedade de Markov: futuro depende apenas do presente, não do passado. Define cadeias de Markov.",
                Criador = "Andrey Markov", AnoOrigin = "1906" },
            new Formula { Id = "by_mk02", Nome = "Matriz de Transição P", Categoria = "Estatística Bayesiana", SubCategoria = "Cadeias de Markov",
                Expressao = "Pᵢⱼ = P(Xₜ₊₁=j|Xₜ=i); ΣⱼPᵢⱼ=1", ExprTexto = "P = [Pᵢⱼ]: Pᵢⱼ ≥ 0, Σⱼ Pᵢⱼ = 1", Icone = "θ",
                Descricao = "Matriz estocástica: cada linha soma 1. Pᵢⱼ = probabilidade de transição do estado i para j em um passo." },
            new Formula { Id = "by_mk03", Nome = "Dist. Estacionária π = πP", Categoria = "Estatística Bayesiana", SubCategoria = "Cadeias de Markov",
                Expressao = "πP = π; Σᵢπᵢ = 1", ExprTexto = "πP = π (distribuição estacionária); Σᵢ πᵢ = 1", Icone = "θ",
                Descricao = "Distribuição estacionária: vetor π invariante pela transição. Para cadeias ergódicas, πⱼ = lim P(Xₜ=j) independente da inicial." },
            new Formula { Id = "by_mk04", Nome = "Chapman-Kolmogorov", Categoria = "Estatística Bayesiana", SubCategoria = "Cadeias de Markov",
                Expressao = "P⁽ⁿ⁺ᵐ⁾ = P⁽ⁿ⁾·P⁽ᵐ⁾", ExprTexto = "P^(n+m) = P^(n) · P^(m)", Icone = "θ",
                Descricao = "Equação de Chapman-Kolmogorov: probabilidade de transição em n+m passos = produto das matrizes de n e m passos." },
            new Formula { Id = "by_mk05", Nome = "Ergodicidade / Convergência", Categoria = "Estatística Bayesiana", SubCategoria = "Cadeias de Markov",
                Expressao = "Irredutível + aperiódica → ergódica → π única", ExprTexto = "Irredutível + aperiódica → ergódica (converge a π)", Icone = "θ",
                Descricao = "Cadeia ergódica: irredutível (todos estados comunicam) e aperiódica. Garante convergência para distribuição estacionária única." },

            // 13.4 Movimento Browniano
            new Formula { Id = "by_mb01", Nome = "Movimento Browniano W(t)", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "W(t)-W(s) ~ N(0, t-s); W(0)=0", ExprTexto = "W(t)−W(s) ~ N(0, t−s); incrementos independentes", Icone = "θ",
                Descricao = "Movimento browniano (processo de Wiener): incrementos independentes, gaussianos, variância proporcional ao tempo.",
                Criador = "Robert Brown / Norbert Wiener", AnoOrigin = "1827/1923" },
            new Formula { Id = "by_mb02", Nome = "Propriedades do Browniano", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "E[W(t)]=0; Cov(W(s),W(t))=min(s,t)", ExprTexto = "E[W(t)]=0; Cov(W(s),W(t)) = min(s,t)", Icone = "θ",
                Descricao = "Média zero, covariância = mínimo dos tempos. Trajetórias contínuas mas em nenhum ponto diferenciáveis." },
            new Formula { Id = "by_mb03", Nome = "Browniano Geométrico (GBM)", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "dS = μS dt + σS dW", ExprTexto = "dS = μS dt + σS dW → S(t) = S₀ exp((μ−σ²/2)t + σW(t))", Icone = "θ",
                Descricao = "GBM: modelo fundamental de preços de ativos financeiros. Solução: S(t) log-normal. Base do modelo Black-Scholes." },
            new Formula { Id = "by_mb04", Nome = "Fórmula de Black-Scholes", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "C = SN(d₁) - Ke^(-rT)N(d₂)", ExprTexto = "C = S₀·N(d₁) − K·e^(−rT)·N(d₂)", Icone = "θ",
                Descricao = "Preço de opção de compra europeia. d₁ = [ln(S/K)+(r+σ²/2)T]/(σ√T), d₂ = d₁−σ√T.",
                Criador = "Black / Scholes / Merton", AnoOrigin = "1973" },
            new Formula { Id = "by_mb05", Nome = "Equação de Itô (SDE Geral)", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "dX = a(X,t)dt + b(X,t)dW", ExprTexto = "dXₜ = a(Xₜ,t)dt + b(Xₜ,t)dWₜ", Icone = "θ",
                Descricao = "Equação diferencial estocástica (SDE) na forma de Itô. a = drift, b = difusão. Generaliza EDOs para processos aleatórios.",
                Criador = "Kiyosi Itô", AnoOrigin = "1944" },
            new Formula { Id = "by_mb06", Nome = "Lema de Itô", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "df = (∂f/∂t + a∂f/∂x + ½b²∂²f/∂x²)dt + b∂f/∂x dW", ExprTexto = "df = (fₜ + a·fₓ + ½b²fₓₓ)dt + b·fₓ dW", Icone = "θ",
                Descricao = "Lema de Itô: regra da cadeia para cálculo estocástico. Aparece o termo extra ½b²∂²f/∂x² (não presente em EDOs determinísticas).",
                Criador = "Kiyosi Itô", AnoOrigin = "1944" },
            new Formula { Id = "by_mb07", Nome = "Processo de Ornstein-Uhlenbeck", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "dX = θ(μ-X)dt + σdW", ExprTexto = "dXₜ = θ(μ − Xₜ)dt + σ dWₜ (reversão à média)", Icone = "θ",
                Descricao = "Processo com reversão à média μ. θ>0 controla velocidade de reversão. Usado em modelagem de taxas de juros.",
                Criador = "Uhlenbeck / Ornstein", AnoOrigin = "1930" },
            new Formula { Id = "by_mb08", Nome = "Processo de Poisson", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "P(N(t)=k) = (λt)ᵏe^(-λt)/k!", ExprTexto = "P(N(t) = k) = (λt)ᵏ e^(−λt) / k!", Icone = "θ",
                Descricao = "Processo de contagem com taxa λ: incrementos independentes, intervalo entre eventos ~ Exponencial(λ). E[N(t)]=Var[N(t)]=λt.",
                Criador = "Siméon Denis Poisson", AnoOrigin = "1837",
                Variaveis = [
                    new() { Simbolo = "lam", Nome = "λ (taxa)", ValorPadrao = 3 },
                    new() { Simbolo = "t", Nome = "t (tempo)", ValorPadrao = 2 },
                    new() { Simbolo = "k", Nome = "k (eventos)", ValorPadrao = 5, ValorMin = 0 },
                ],
                VariavelResultado = "P(N(t)=k)",
                Calcular = vars => { double lt=vars["lam"]*vars["t"]; int k=(int)vars["k"]; return Math.Pow(lt,k)*Math.Exp(-lt)/Fatorial(k); } },
            new Formula { Id = "by_mb09", Nome = "Equação de Fokker-Planck", Categoria = "Estatística Bayesiana", SubCategoria = "Processos Contínuos",
                Expressao = "∂p/∂t = -∂(a·p)/∂x + ½∂²(b²p)/∂x²", ExprTexto = "∂p/∂t = −∂(ap)/∂x + ½ ∂²(b²p)/∂x²", Icone = "θ",
                Descricao = "Equação de Fokker-Planck: EDP para a densidade de probabilidade p(x,t) de um processo de difusão dX=a dt+b dW. Dual de Itô." },
        ]);
    }
}
