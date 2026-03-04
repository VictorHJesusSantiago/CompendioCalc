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
            },
            new Formula
            {
                Id = "5_gq02", Nome = "Herdabilidade (h²)", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "h² = Vₐ/Vₚ = Vₐ/(Vₐ + Vd + Ve)",
                ExprTexto = "h² = Va/Vp (herdabilidade sentido estrito)",
                Icone = "h²",
                Descricao = "Herdabilidade no sentido estrito: fração da variância fenotípica devida à variância genética aditiva. Indica potencial de resposta à seleção.",
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
            },
            new Formula
            {
                Id = "5_gq05", Nome = "Deriva Genética (Wright-Fisher)", Categoria = "Genética Quantitativa", SubCategoria = "Seleção e Herança",
                Expressao = "Var(p') = p(1-p)/(2Ne);  Ne=tamanho efetivo",
                ExprTexto = "Var(p')=p(1-p)/(2Ne)",
                Icone = "Ne",
                Descricao = "Deriva genética no modelo Wright-Fisher: variância da frequência alélica inversamente proporcional ao tamanho efetivo da população. Processo estocástico neutro.",
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
            },
            new Formula
            {
                Id = "5_gq07", Nome = "QTL Mapping (LOD score)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "LOD = log₁₀(L(θ̂)/L(θ=0.5));  LOD ≥ 3 significativo",
                ExprTexto = "LOD = log₁₀[L(θ̂)/L(0.5)]",
                Icone = "LOD",
                Descricao = "LOD score para mapeamento de QTL: razão de verossimilhança em log₁₀. LOD≥3 indica ligação significativa entre marcador e locus de caráter quantitativo.",
            },
            new Formula
            {
                Id = "5_gq08", Nome = "GWAS (Genômica)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "yi = μ + βxi + εi;  teste em ~10⁶ SNPs;  p < 5×10⁻⁸",
                ExprTexto = "GWAS: regressão por SNP, p<5e-8",
                Icone = "GW",
                Descricao = "GWAS: associação genômica ampla. Testa cada SNP contra fenótipo. Limiar genômico p<5×10⁻⁸ (Bonferroni para ~1M testes). Identifica variantes associadas.",
            },
            new Formula
            {
                Id = "5_gq09", Nome = "BLUP (Valor Genético)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "û = G·Z'·V⁻¹·(y - Xβ̂);  V = ZGZ' + R",
                ExprTexto = "BLUP: û = GZ'V⁻¹(y-Xβ̂)",
                Icone = "BL",
                Descricao = "BLUP (Best Linear Unbiased Prediction): predição de valores genéticos em modelo misto. Usado em melhoramento animal/vegetal e genômica. Henderson's equations.",
            },
            new Formula
            {
                Id = "5_gq10", Nome = "Seleção Genômica (GS)", Categoria = "Genética Quantitativa", SubCategoria = "Mapeamento Genético",
                Expressao = "GEBV = Σ x_j·β̂_j (soma de efeitos de marcadores)",
                ExprTexto = "GEBV = Σ xj·β̂j (todos marcadores)",
                Icone = "GS",
                Descricao = "Seleção genômica: predição de valor genético usando todos os marcadores simultaneamente. GBLUP, BayesA/B/C/R. Revolucionou melhoramento genético.",
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
            },
            new Formula
            {
                Id = "5_im02", Nome = "Número Reprodutivo Básico (R₀)", Categoria = "Imunologia Computacional", SubCategoria = "Epidemiologia Matemática",
                Expressao = "R₀ = β/γ;  limiar epidêmico: R₀ > 1",
                ExprTexto = "R₀ = β/γ; epidemia se R₀>1",
                Icone = "R₀",
                Descricao = "R₀: número médio de casos secundários por caso primário em população totalmente suscetível. Limiar fundamental para controle epidemiológico.",
            },
            new Formula
            {
                Id = "5_im03", Nome = "Imunidade de Rebanho", Categoria = "Imunologia Computacional", SubCategoria = "Epidemiologia Matemática",
                Expressao = "pc = 1 - 1/R₀;  fração a vacinar para controle",
                ExprTexto = "pc = 1 - 1/R₀ (herd immunity)",
                Icone = "HI",
                Descricao = "Limiar de imunidade coletiva: fração mínima da população imune para prevenir epidemia. Para sarampo (R₀~15), pc≈93%. COVID (R₀~3), pc≈67%.",
            },
            new Formula
            {
                Id = "5_im04", Nome = "Dinâmica Vírus-Imune", Categoria = "Imunologia Computacional", SubCategoria = "Dinâmica Imune",
                Expressao = "dV/dt = rV(1-V/K) - kVT;  dT/dt = s + pTV/(V+h) - dT",
                ExprTexto = "V'=rV(1-V/K)-kVT; T'=s+pTV/(V+h)-dT",
                Icone = "VT",
                Descricao = "Modelo vírus-CTL: vírus V cresce logisticamente, eliminado por células T. T prolifera em resposta ao antígeno. Equilíbrio entre carga viral e resposta imune.",
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
            },
            new Formula
            {
                Id = "5_im07", Nome = "Afinidade de Ligação (Kd)", Categoria = "Imunologia Computacional", SubCategoria = "Dinâmica Imune",
                Expressao = "Kd = [Ab][Ag]/[Ab·Ag];  menor Kd = maior afinidade",
                ExprTexto = "Kd = [Ab][Ag]/[AbAg]",
                Icone = "Kd",
                Descricao = "Constante de dissociação: mede afinidade anticorpo-antígeno. Menor Kd = maior afinidade. Maturação de afinidade: hipermutação somática + seleção.",
            },
            new Formula
            {
                Id = "5_im08", Nome = "NetMHC (Predição de Epítopos)", Categoria = "Imunologia Computacional", SubCategoria = "Bioinformática Imune",
                Expressao = "Score = f(sequência peptídeo, alelo HLA);  IC₅₀ < 500 nM → ligação",
                ExprTexto = "NetMHC: score(peptídeo,HLA); IC₅₀<500nM",
                Icone = "MHC",
                Descricao = "Predição de ligação MHC: redes neurais prevêem afinidade peptídeo-MHC. IC₅₀<500nM = ligante. Usado em design de vacinas e imunoterapia de câncer.",
            },
            new Formula
            {
                Id = "5_im09", Nome = "Diversidade de Receptores (V(D)J)", Categoria = "Imunologia Computacional", SubCategoria = "Bioinformática Imune",
                Expressao = "Diversidade ≈ V×D×J × junções ≈ 10¹¹ receptores",
                ExprTexto = "V×D×J×junções ≈ 10¹¹ TCR/BCR",
                Icone = "VDJ",
                Descricao = "Recombinação V(D)J: gera diversidade de receptores de células T e B por recombinação de segmentos gênicos. ~10¹¹ receptores possíveis. Diversidade combinatorial + juncional.",
            },
            new Formula
            {
                Id = "5_im10", Nome = "Clonotype Analysis (Repertório)", Categoria = "Imunologia Computacional", SubCategoria = "Bioinformática Imune",
                Expressao = "Diversidade (Shannon) H = -Σ pi·ln(pi);  Clonalidade = 1-H/ln(N)",
                ExprTexto = "H = -Σpi·ln(pi); Clonalidade=1-H/lnN",
                Icone = "Rp",
                Descricao = "Análise de repertório imune: sequenciamento de TCR/BCR. Shannon diversity mede uniformidade. Alta clonalidade = expansão de poucos clones (resposta/doença).",
            },
        ]);
    }
}
