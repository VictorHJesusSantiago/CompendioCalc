using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 5 — PARTE VI: BIOLOGIA COMPUTACIONAL (Seções 18-19)
    // ═══════════════════════════════════════════════════════════════

    // ─────────────────────────────────────────────────────
    // 18. GENÉTICA QUANTITATIVA
    // ─────────────────────────────────────────────────────
    private void AdicionarGeneticaQuantitativa()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_gq01", Nome = "Equação do Criador", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "R = h²·S;  R=resposta, h²=herdabilidade, S=diferencial de seleção",
                ExprTexto = "R = h²·S (equação do criador)",
                Icone = "R",
                Descricao = "Equação do criador (Breeder's equation): resposta à seleção = herdabilidade × diferencial de seleção. Fundamental em genética quantitativa e melhoramento.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "h²", Nome = "h²", ValorPadrao = 5 }, new() { Simbolo = "S", Nome = "S", ValorPadrao = 3 } ],
                VariavelResultado = "R",
                UnidadeResultado = "",
                Calcular = vars => vars["h²"] * vars["S"]
            },
            new Formula
            {
                Id = "5_gq02", Nome = "Herdabilidade (h²)", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "h² = Vₐ/Vₚ = Vₐ/(Vₐ + Vd + Ve)",
                ExprTexto = "h² = Va/Vp (herdabilidade sentido estrito)",
                Icone = "h²",
                Descricao = "Herdabilidade no sentido estrito: fração da variância fenotípica devida à variância genética aditiva. Indica potencial de resposta à seleção.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "Va", Nome = "Va", ValorPadrao = 10 }, new() { Simbolo = "Vp", Nome = "Vp", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "h²",
                UnidadeResultado = "",
                Calcular = vars => vars["Va"] / vars["Vp"]
            },
            new Formula
            {
                Id = "5_gq03", Nome = "Equação de Lande (Multivariada)", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "Δz̄ = G·P⁻¹·S = G·β;  G=matriz genética, β=gradiente de seleção",
                ExprTexto = "Δz̄ = G·β (Lande multivariada)",
                Icone = "Gβ",
                Descricao = "Equação de Lande: generalização multivariada. G=matriz de covariância genética aditiva, β=gradiente de seleção. Evolução de múltiplos caracteres correlacionados.",
                Criador = "Russell Lande",
                AnoOrigin = "1979",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "5_gq04", Nome = "Equilíbrio Hardy-Weinberg", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "p² + 2pq + q² = 1;  p + q = 1",
                ExprTexto = "p² + 2pq + q² = 1 (HW)",
                Icone = "HW",
                Descricao = "Equilíbrio de Hardy-Weinberg: frequências genotípicas em população grande sem seleção, mutação, migração ou drift. Referência de expectativa nula.",
                Criador = "Hardy / Weinberg",
                AnoOrigin = "1908",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "5_gq05", Nome = "Deriva Genética (Wright-Fisher)", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "Var(p') = p(1-p)/(2Ne);  Ne=tamanho efetivo",
                ExprTexto = "Var(p')=p(1-p)/(2Ne)",
                Icone = "Ne",
                Descricao = "Deriva genética no modelo Wright-Fisher: variância da frequência alélica inversamente proporcional ao tamanho efetivo da população. Processo estocástico neutro.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "5_gq06", Nome = "Fixação Neutra (Kimura)", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "P(fixação) = 1/(2N) para alelo neutro;  taxa de substituição = μ",
                ExprTexto = "P(fix)=1/(2N); taxa subst=μ",
                Icone = "Km",
                Descricao = "Teoria neutra de Kimura: probabilidade de fixação de alelo neutro = frequência inicial. Taxa de substituição neutra = taxa de mutação μ, independente de N.",
                Criador = "Motoo Kimura",
                AnoOrigin = "1968",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "5_gq07", Nome = "QTL Mapping (LOD score)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "LOD = log₁₀(L(θ̂)/L(θ=0.5));  LOD ≥ 3 significativo",
                ExprTexto = "LOD = log₁₀[L(θ̂)/L(0.5)]",
                Icone = "LOD",
                Descricao = "LOD score para mapeamento de QTL: razão de verossimilhança em log₁₀. LOD≥3 indica ligação significativa entre marcador e locus de caráter quantitativo.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Valor x", ValorPadrao = 10, ValorMin = 0.001 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => Math.Log(vars["x"])
            },
            new Formula
            {
                Id = "5_gq08", Nome = "GWAS (Genômica)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "yi = μ + βxi + εi;  teste em ~10⁶ SNPs;  p < 5×10⁻⁸",
                ExprTexto = "GWAS: regressão por SNP, p<5e-8",
                Icone = "GW",
                Descricao = "GWAS: associação genômica ampla. Testa cada SNP contra fenótipo. Limiar genômico p<5×10⁻⁸ (Bonferroni para ~1M testes). Identifica variantes associadas.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "5_gq09", Nome = "BLUP (Valor Genético)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "û = G·Z'·V⁻¹·(y - Xβ̂);  V = ZGZ' + R",
                ExprTexto = "BLUP: û = GZ'V⁻¹(y-Xβ̂)",
                Icone = "BL",
                Descricao = "BLUP (Best Linear Unbiased Prediction): predição de valores genéticos em modelo misto. Usado em melhoramento animal/vegetal e genômica. Henderson's equations.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "5_gq10", Nome = "Seleção Genômica (GS)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "GEBV = Σ x_j·β̂_j (soma de efeitos de marcadores)",
                ExprTexto = "GEBV = Σ xj·β̂j (todos marcadores)",
                Icone = "GS",
                Descricao = "Seleção genômica: predição de valor genético usando todos os marcadores simultaneamente. GBLUP, BayesA/B/C/R. Revolucionou melhoramento genético.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "N", Nome = "N (população)", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "r", Nome = "r (taxa)", ValorPadrao = 0.1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["N"] * vars["r"]
            },
            new Formula
            {
                Id = "5_gq11", Nome = "Coalescente (Kingman)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "T(k) ~ Exp(k(k-1)/(4Ne));  E[TMRCA] = 4Ne(1-1/n)",
                ExprTexto = "T(k)~Exp(k(k-1)/(4Ne))",
                Icone = "Co",
                Descricao = "Coalescente de Kingman: modelo retrospectivo de ancestralidade. Tempo entre coalescências exponencial. Simulação e inferência populacional. TMRCA = ancestral comum mais recente.",
                Criador = "John Kingman",
                AnoOrigin = "1982",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Expoente x", ValorPadrao = 1 }, new() { Simbolo = "A", Nome = "Amplitude A", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = vars => vars["A"] * Math.Exp(vars["x"])
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 19. IMUNOLOGIA COMPUTACIONAL
    // ─────────────────────────────────────────────────────
    private void AdicionarImunologiaComputacional()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_im01", Nome = "Modelo SIR", Categoria = "Imunologia Computacional", SubCategoria = "Epidemiologia Matemática",
                Expressao = "dS/dt = -βSI;  dI/dt = βSI - γI;  dR/dt = γI",
                ExprTexto = "S'=-βSI; I'=βSI-γI; R'=γI",
                Icone = "SIR",
                Descricao = "Modelo SIR: Suscetível→Infectado→Recuperado. β=taxa de contato efetivo, γ = taxa de recuperação. R₀=β/γ. Se R₀>1, epidemia cresce.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Entrada principal x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Entrada secundária y", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = CalculoPadrao
            },
            new Formula
            {
                Id = "5_im02", Nome = "Número Reprodutivo Básico (R₀)", Categoria = "Imunologia Computacional", SubCategoria = "Epidemiologia Matemática",
                Expressao = "R₀ = β/γ;  limiar epidêmico: R₀ > 1",
                ExprTexto = "R₀ = β/γ; epidemia se R₀>1",
                Icone = "R₀",
                Descricao = "R₀: número médio de casos secundários por caso primário em população totalmente suscetível. Limiar fundamental para controle epidemiológico.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "β", Nome = "β", ValorPadrao = 10 }, new() { Simbolo = "γ", Nome = "γ", ValorPadrao = 2, ValorMin = 0.001 } ],
                VariavelResultado = "R₀",
                UnidadeResultado = "",
                Calcular = vars => vars["β"] / vars["γ"]
            },
            new Formula
            {
                Id = "5_im03", Nome = "Imunidade de Rebanho", Categoria = "Imunologia Computacional", SubCategoria = "Epidemiologia Matemática",
                Expressao = "pc = 1 - 1/R₀;  fração a vacinar para controle",
                ExprTexto = "pc = 1 - 1/R₀ (herd immunity)",
                Icone = "HI",
                Descricao = "Limiar de imunidade coletiva: fração mínima da população imune para prevenir epidemia. Para sarampo (R₀~15), pc≈93%. COVID (R₀~3), pc≈67%.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "1", Nome = "1", ValorPadrao = 10 }, new() { Simbolo = "1", Nome = "1", ValorPadrao = 5 } ],
                VariavelResultado = "pc",
                UnidadeResultado = "",
                Calcular = vars => vars["1"] - vars["1"]
            },
            new Formula
            {
                Id = "5_im04", Nome = "Dinâmica Vírus-Imune", Categoria = "Imunologia Computacional", SubCategoria = "Dinâmica Imune",
                Expressao = "dV/dt = rV(1-V/K) - kVT;  dT/dt = s + pTV/(V+h) - dT",
                ExprTexto = "V'=rV(1-V/K)-kVT; T'=s+pTV/(V+h)-dT",
                Icone = "VT",
                Descricao = "Modelo vírus-CTL: vírus V cresce logisticamente, eliminado por células T. T prolifera em resposta ao antígeno. Equilíbrio entre carga viral e resposta imune.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Entrada principal x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Entrada secundária y", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = CalculoPadrao
            },
            new Formula
            {
                Id = "5_im05", Nome = "Seleção Clonal (Burnet)", Categoria = "Imunologia Computacional", SubCategoria = "Dinâmica Imune",
                Expressao = "Antígeno → seleciona clone → expansão → memória",
                ExprTexto = "Ag seleciona clone → expansão → memória",
                Icone = "SC",
                Descricao = "Teoria da seleção clonal: antígeno seleciona linfócitos com receptor complementar, que se expandem clonalmente. Gera memória imunológica. Base da vacinação.",
                Criador = "Frank Macfarlane Burnet",
                AnoOrigin = "1957",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Entrada principal x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Entrada secundária y", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = CalculoPadrao
            },
            new Formula
            {
                Id = "5_im06", Nome = "Rede Imune (Jerne)", Categoria = "Imunologia Computacional", SubCategoria = "Dinâmica Imune",
                Expressao = "Anticorpo → anti-anticorpo (idiotipo-anti-idiotipo)",
                ExprTexto = "Ab₁ → Ab₂ (anti-idiotipo) → ...",
                Icone = "JN",
                Descricao = "Teoria da rede imune de Jerne: anticorpos reconhecem idiotipos de outros anticorpos, formando rede de regulação. Modelo matemático de equilíbrio imunológico.",
                Criador = "Niels Jerne",
                AnoOrigin = "1974",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Entrada principal x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Entrada secundária y", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = CalculoPadrao
            },
            new Formula
            {
                Id = "5_im07", Nome = "Afinidade de Ligação (Kd)", Categoria = "Imunologia Computacional", SubCategoria = "Dinâmica Imune",
                Expressao = "Kd = [Ab][Ag]/[Ab·Ag];  menor Kd = maior afinidade",
                ExprTexto = "Kd = [Ab][Ag]/[AbAg]",
                Icone = "Kd",
                Descricao = "Constante de dissociação: mede afinidade anticorpo-antígeno. Menor Kd = maior afinidade. Maturação de afinidade: hipermutação somática + seleção.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Entrada principal x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Entrada secundária y", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = CalculoPadrao
            },
            new Formula
            {
                Id = "5_im08", Nome = "NetMHC (Predição de Epítopos)", Categoria = "Imunologia Computacional", SubCategoria = "Bioinformática Imune",
                Expressao = "Score = f(sequência peptídeo, alelo HLA);  IC₅₀ < 500 nM → ligação",
                ExprTexto = "NetMHC: score(peptídeo,HLA); IC₅₀<500nM",
                Icone = "MHC",
                Descricao = "Predição de ligação MHC: redes neurais prevêem afinidade peptídeo-MHC. IC₅₀<500nM = ligante. Usado em design de vacinas e imunoterapia de câncer.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Entrada principal x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Entrada secundária y", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = CalculoPadrao
            },
            new Formula
            {
                Id = "5_im09", Nome = "Diversidade de Receptores (V(D)J)", Categoria = "Imunologia Computacional", SubCategoria = "Bioinformática Imune",
                Expressao = "Diversidade ≈ V×D×J × junções ≈ 10¹¹ receptores",
                ExprTexto = "V×D×J×junções ≈ 10¹¹ TCR/BCR",
                Icone = "VDJ",
                Descricao = "Recombinação V(D)J: gera diversidade de receptores de células T e B por recombinação de segmentos gênicos. ~10¹¹ receptores possíveis. Diversidade combinatorial + juncional.",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "x", Nome = "Entrada principal x", ValorPadrao = 1 }, new() { Simbolo = "y", Nome = "Entrada secundária y", ValorPadrao = 1 } ],
                VariavelResultado = "Valor calculado",
                UnidadeResultado = "",
                Calcular = CalculoPadrao
            },
            new Formula
            {
                Id = "5_im10", Nome = "Clonotype Analysis (Repertório)", Categoria = "Imunologia Computacional", SubCategoria = "Bioinformática Imune",
                Expressao = "Diversidade (Shannon) H = -Σ pi·ln(pi);  Clonalidade = 1-H/ln(N)",
                ExprTexto = "H = -Σpi·ln(pi); Clonalidade=1-H/lnN",
                Icone = "Rp",
                Descricao = "Análise de repertório imune: sequenciamento de TCR/BCR. Shannon diversity mede uniformidade. Alta clonalidade = expansão de poucos clones (resposta/doença).",
                ExemploPratico = "Exemplo: com os valores padrão definidos abaixo, calcule o valor da expressão e interprete no contexto da fórmula.",
                Variaveis = [ new() { Simbolo = "1", Nome = "1", ValorPadrao = 10 }, new() { Simbolo = "H", Nome = "H", ValorPadrao = 5 } ],
                VariavelResultado = "Clonalidade",
                UnidadeResultado = "",
                Calcular = vars => vars["1"] - vars["H"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 18.2 GENÉTICA QUANTITATIVA - Avançada (LD, PGS, Epistasis)
    // ─────────────────────────────────────────────────────
    private void AdicionarGeneticaQuantitativaAvancada()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_gq12", Nome = "Linkage Disequilibrium (r²)", Categoria = "Genética Quantitativa", SubCategoria = "Estrutura de Populações",
                Expressao = "r² = D²/(pApBpapb);  D = pAB - pA·pB",
                ExprTexto = "r² = D²/(pA·pB·pa·pb) (LD)",
                Icone = "LD",
                Descricao = "Linkage disequilibrium: medida de associação não-aleatória entre alelos em loci diferentes. r²=1 perfeito LD, r²=0 equilíbrio. Decai por recombinação. Crucial para GWAS e mapeamento.",
                ExemploPratico = "Com haplótipo AB com freq pAB=0.5, alelos A (pA=0.6) e B (pB=0.7), calcule LD.",
                Variaveis = [ new() { Simbolo = "pAB", Nome = "Freq haplotipo pAB", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "pA", Nome = "Freq alelo A", ValorPadrao = 0.6, ValorMin = 0.001, ValorMax = 0.999 }, new() { Simbolo = "pB", Nome = "Freq alelo B", ValorPadrao = 0.7, ValorMin = 0.001, ValorMax = 0.999 } ],
                VariavelResultado = "r²",
                UnidadeResultado = "",
                Calcular = vars => {
                    double D = vars["pAB"] - vars["pA"] * vars["pB"];
                    double denom = vars["pA"] * (1 - vars["pA"]) * vars["pB"] * (1 - vars["pB"]);
                    return denom > 0 ? (D * D) / denom : 0;
                }
            },
            new Formula
            {
                Id = "5_gq13", Nome = "Polygenic Score (PGS)", Categoria = "Genética Quantitativa", SubCategoria = "Predição Genômica",
                Expressao = "PGS = Σᵢ βᵢ·Gᵢ;  G=genótipo {0,1,2}, β=efeito GWAS",
                ExprTexto = "PGS = Σ β·G (polygenic score)",
                Icone = "PGS",
                Descricao = "Polygenic score: soma ponderada de genótipos usando efeitos de GWAS. Prediz risco/fenótipo. Usado em medicina de precisão. Acurácia depende de tamanho do GWAS e ancestralidade.",
                ExemploPratico = "Com genótipos G=[2,1,0] e efeitos β=[0.1,0.2,0.15], PGS = 2×0.1 + 1×0.2 + 0×0.15 = 0.4.",
                Variaveis = [ new() { Simbolo = "G1", Nome = "Genótipo 1", ValorPadrao = 2, ValorMin = 0, ValorMax = 2 }, new() { Simbolo = "β1", Nome = "Efeito β1", ValorPadrao = 0.1 }, new() { Simbolo = "G2", Nome = "Genótipo 2", ValorPadrao = 1, ValorMin = 0, ValorMax = 2 }, new() { Simbolo = "β2", Nome = "Efeito β2", ValorPadrao = 0.2 }, new() { Simbolo = "G3", Nome = "Genótipo 3", ValorPadrao = 0, ValorMin = 0, ValorMax = 2 }, new() { Simbolo = "β3", Nome = "Efeito β3", ValorPadrao = 0.15 } ],
                VariavelResultado = "PGS",
                UnidadeResultado = "",
                Calcular = vars => vars["G1"] * vars["β1"] + vars["G2"] * vars["β2"] + vars["G3"] * vars["β3"]
            },
            new Formula
            {
                Id = "5_gq14", Nome = "LD Score Regression (Herdabilidade SNP)", Categoria = "Genética Quantitativa", SubCategoria = "Predição Genômica",
                Expressao = "E[χ²ⱼ] = 1 + Na·h²·ℓⱼ/M;  ℓⱼ=LD score",
                ExprTexto = "LDSC: E[χ²] = 1 + N·h²·ℓ/M",
                Icone = "LDSC",
                Descricao = "LD score regression: estima herdabilidade SNP e correlação genética a partir de summary statistics de GWAS. Controla para inflação por estrutura de população. Método Bulik-Sullivan.",
                Criador = "Bulik-Sullivan et al",
                AnoOrigin = "2015",
                ExemploPratico = "Com sample N=10000, h²=0.5, LD score ℓ=30, M=1M SNPs, calcule E[χ²].",
                Variaveis = [ new() { Simbolo = "N", Nome = "Sample size N", ValorPadrao = 10000, ValorMin = 1 }, new() { Simbolo = "h²", Nome = "Herdabilidade h²", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "ℓ", Nome = "LD score ℓ", ValorPadrao = 30, ValorMin = 0 }, new() { Simbolo = "M", Nome = "Num SNPs M", ValorPadrao = 1000000, ValorMin = 1 } ],
                VariavelResultado = "E[χ²]",
                UnidadeResultado = "",
                Calcular = vars => 1 + vars["N"] * vars["h²"] * vars["ℓ"] / vars["M"]
            },
            new Formula
            {
                Id = "5_gq15", Nome = "Epistasis (Interação Genética)", Categoria = "Genética Quantitativa", SubCategoria = "Variância Genética",
                Expressao = "Vepist = Var[E(Y|gi,gj)] não aditivo;  modelos NOIA",
                ExprTexto = "Vepist = variância interação (não-aditiva)",
                Icone = "Epi",
                Descricao = "Epistasis: efeito de interação entre loci. Variância epistática dificulta predição aditiva. Detectável via regressão de dois loci ou métodos de ML. Natural Orthogonal Interaction Analysis (NOIA).",
                ExemploPratico = "Interação genética: efeito conjunto de alelos ≠ soma de efeitos individuais. Ex: dois loci com efeito conjunto amplificado.",
                Variaveis = [ new() { Simbolo = "βAA", Nome = "Efeito aditivo βAA", ValorPadrao = 0.5 }, new() { Simbolo = "βBB", Nome = "Efeito aditivo βBB", ValorPadrao = 0.6 }, new() { Simbolo = "βAB", Nome = "Efeito interação βAB", ValorPadrao = 0.3 } ],
                VariavelResultado = "Efeito total (com epistasis)",
                UnidadeResultado = "",
                Calcular = vars => vars["βAA"] + vars["βBB"] + vars["βAB"]
            },
            new Formula
            {
                Id = "5_gq16", Nome = "Pedigree Analysis (IBD)", Categoria = "Genética Quantitativa", SubCategoria = "Compartilhamento Genético",
                Expressao = "P(IBD=0,1,2) para pares de parentes;  sibs: (1/4,1/2,1/4)",
                ExprTexto = "IBD: P(0,1,2) para sibs = (1/4,1/2,1/4)",
                Icone = "IBD",
                Descricao = "Identity by descent: probabilidade de pares de parentes compartilharem 0, 1 ou 2 alelos idênticos por descendência comum. Siblings full: (1/4,1/2,1/4). Base de linkage analysis.",
                ExemploPratico = "Siblings compartilham em média 1 alelo IBD (prob 50% de 1, 25% de 2, 25% de 0).",
                Variaveis = [ new() { Simbolo = "k0", Nome = "Prob IBD=0", ValorPadrao = 0.25, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "k1", Nome = "Prob IBD=1", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }, new() { Simbolo = "k2", Nome = "Prob IBD=2", ValorPadrao = 0.25, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Compartilhamento médio (alelos)",
                UnidadeResultado = "alelos",
                Calcular = vars => 0 * vars["k0"] + 1 * vars["k1"] + 2 * vars["k2"]
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    // 19.2 IMUNOLOGIA COMPUTACIONAL - Avançada (Escape, Vacinação)
    // ─────────────────────────────────────────────────────
    private void AdicionarImunologiaAvancada()
    {
        _formulas.AddRange([
            new Formula
            {
                Id = "5_im11", Nome = "Escape Viral (Mutação Imune)", Categoria = "Imunologia Computacional", SubCategoria = "Evolução Viral",
                Expressao = "dV/dt = rV(1-V/K) - δVE;  mutante escapa se fitness > wild-type",
                ExprTexto = "Escape: mutante evade resposta imune",
                Icone = "Esc",
                Descricao = "Escape viral: mutações permitem vírus evadir resposta imune. Trade-off entre fitness viral e fuga imunológica. Driving force da evolução de HIV, influenza. Modelo de Wright-Fisher com seleção.",
                ExemploPratico = "Vírus com taxa de mutação μ=10⁻⁵ por replicação, pressão imune seleciona variantes escapadoras.",
                Variaveis = [ new() { Simbolo = "r", Nome = "Taxa crescimento r", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "V", Nome = "Carga viral V", ValorPadrao = 1000, ValorMin = 0  }, new() { Simbolo = "K", Nome = "Capacidade K", ValorPadrao = 10000, ValorMin = 1 }, new() { Simbolo = "δ", Nome = "Taxa morte δ", ValorPadrao = 0.0001, ValorMin = 0 }, new() { Simbolo = "E", Nome = "Efeito imune E", ValorPadrao = 100, ValorMin = 0 } ],
                VariavelResultado = "dV/dt (dinâmica escape)",
                UnidadeResultado = "virions/dia",
                Calcular = vars => vars["r"] * vars["V"] * (1 - vars["V"] / vars["K"]) - vars["δ"] * vars["V"] * vars["E"]
            },
            new Formula
            {
                Id = "5_im12", Nome = "Limiar de Imunidade de Rebanho", Categoria = "Imunologia Computacional", SubCategoria = "Vacinação",
                Expressao = "pc = 1 - 1/R₀;  fração vacinada necessária para bloqueio",
                ExprTexto = "pc = 1-1/R₀ (herd immunity)",
                Icone = "Herd",
                Descricao = "Limiar de imunidade de rebanho: fração da população que precisa ser imune (vacinada/recuperada) para bloquear transmissão. R₀ alto → pc alto. Sarampo (R₀≈15) requer ~93%.",
                ExemploPratico = "Para COVID-19 com R₀=3, limiar pc = 1-1/3 ≈ 67% da população precisa ser imune.",
                Variaveis = [ new() { Simbolo = "R₀", Nome = "Número reprodutivo R₀", ValorPadrao = 3, ValorMin = 1.001 } ],
                VariavelResultado = "Limiar de imunidade pc",
                UnidadeResultado = "",
                Calcular = vars => 1 - 1 / vars["R₀"]
            },
            new Formula
            {
                Id = "5_im13", Nome = "Competição de Clone (Seleção Clonal)", Categoria = "Imunologia Computacional", SubCategoria = "Dinâmica de Repertório",
                Expressao = "dCᵢ/dt = rᵢCᵢ(1 - ΣCⱼ/K) - δCᵢ;  competição por recursos",
                ExprTexto = "Competição: clone mais fit domina repertório",
                Icone = "Clon",
                Descricao = "Seleção clonal: clones de alta afinidade proliferam preferencialmente. Competição por recursos (IL-2, espaço). Gera oligoclonalidade em resposta imune. Modelo Lotka-Volterra.",
                Criador = "Burnet",
                AnoOrigin = "1957",
                ExemploPratico = "Clone com taxa r=0.8, população C=100, capacidade K=1000, morte δ=0.1, calcule dC/dt.",
                Variaveis = [ new() { Simbolo = "r", Nome = "Taxa proliferação r", ValorPadrao = 0.8, ValorMin = 0 }, new() { Simbolo = "C", Nome = "População clone C", ValorPadrao = 100, ValorMin = 0 }, new() { Simbolo = "K", Nome = "Capacidade total K", ValorPadrao = 1000, ValorMin = 1 }, new() { Simbolo = "δ", Nome = "Taxa morte δ", ValorPadrao = 0.1, ValorMin = 0 } ],
                VariavelResultado = "dC/dt (dinâmica clonal)",
                UnidadeResultado = "células/dia",
                Calcular = vars => vars["r"] * vars["C"] * (1 - vars["C"] / vars["K"]) - vars["δ"] * vars["C"]
            },
            new Formula
            {
                Id = "5_im14", Nome = "Formação de Repertório TCR/BCR", Categoria = "Imunologia Computacional", SubCategoria = "Desenvolvimento Imune",
                Expressao = "Seleção tímica: positiva (MHC) + negativa (auto);  ~5% sobrevive",
                ExprTexto = "Seleção tímica: ~95% apoptose, 5% emigra",
                Icone = "Sel",
                Descricao = "Desenvolvimento de células T: seleção positiva (reconhece MHC próprio) e negativa (deleta autorreativos). ~95% de timócitos sofrem morte por neglect ou deleção. Evita autoimunidade.",
                ExemploPratico = "De 100 timócitos, ~5 passam seleção positiva e negativa, emigram como células T naive maduras.",
                Variaveis = [ new() { Simbolo = "N₀", Nome = "Timócitos iniciais N₀", ValorPadrao = 100, ValorMin = 1 }, new() { Simbolo = "f", Nome = "Fração sobrevivente f", ValorPadrao = 0.05, ValorMin = 0, ValorMax = 1 } ],
                VariavelResultado = "Células T emigrantes",
                UnidadeResultado = "células",
                Calcular = vars => vars["N₀"] * vars["f"]
            },
            new Formula
            {
                Id = "5_im15", Nome = "Polarização Th1/Th2 (Citocinas)", Categoria = "Imunologia Computacional", SubCategoria = "Resposta Adaptativa",
                Expressao = "IFN-γ → Th1 (intracelular);  IL-4 → Th2 (extracelular);  cross-inibição",
                ExprTexto = "Th1 ⊣ Th2;  Th2 ⊣ Th1 (mutual antagonism)",
                Icone = "Pol",
                Descricao = "Polarização de células T helper: Th1 (IFN-γ) para patógenos intracelulares, Th2 (IL-4) para extracelulares/parasitas. Cross-regulação: Th1 inibe Th2 e vice-versa. Modelo de switch bistável.",
                ExemploPratico = "Razão IFN-γ / IL-4 determina polarização: > 1 → Th1, < 1 → Th2. Feedback positivo.",
                Variaveis = [ new() { Simbolo = "IFNγ", Nome = "Nível IFN-γ", ValorPadrao = 10, ValorMin = 0 }, new() { Simbolo = "IL4", Nome = "Nível IL-4", ValorPadrao = 5, ValorMin = 0.01 } ],
                VariavelResultado = "Razão Th1/Th2",
                UnidadeResultado = "",
                Calcular = vars => vars["IFNγ"] / vars["IL4"]
            },
            new Formula
            {
                Id = "5_im16", Nome = "Células Treg (Supressão)", Categoria = "Imunologia Computacional", SubCategoria = "Regulação Imune",
                Expressao = "dE/dt = rE(1-E/K) - aTregE;  Treg suprime efetoras",
                ExprTexto = "Treg suprime: -αTregE (regulação negativa)",
                Icone = "Treg",
                Descricao = "Células T reguladoras (Foxp3+): suprimem resposta imune, mantêm homeostase, previnem autoimunidade. Modelo de predador-presa: Treg controlam efetoras. Defeito → autoimunidade (IPEX).",
                ExemploPratico = "Efetoras E=1000, Tregs T=100, supressão α=0.001, calcule dE/dt com K=10000, r=0.5.",
                Variaveis = [ new() { Simbolo = "r", Nome = "Taxa proliferação r", ValorPadrao = 0.5, ValorMin = 0 }, new() { Simbolo = "E", Nome = "Células efetoras E", ValorPadrao = 1000, ValorMin = 0 }, new() { Simbolo = "K", Nome = "Capacidade K", ValorPadrao = 10000, ValorMin = 1 }, new() { Simbolo = "α", Nome = "Taxa supressão α", ValorPadrao = 0.001, ValorMin = 0 }, new() { Simbolo = "Treg", Nome = "Células Treg", ValorPadrao = 100, ValorMin = 0 } ],
                VariavelResultado = "dE/dt (efeito Treg)",
                UnidadeResultado = "células/dia",
                Calcular = vars => vars["r"] * vars["E"] * (1 - vars["E"] / vars["K"]) - vars["α"] * vars["Treg"] * vars["E"]
            },
        ]);
    }
}
