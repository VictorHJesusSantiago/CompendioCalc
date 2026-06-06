using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Psicologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5501", Nome = "Quociente de Inteligência (QI Padronizado)",
                    Categoria = "Psicologia", SubCategoria = "Psicometria",
                    Expressao = "QI = 100 + 15 × z",
                    Descricao = "Transformação do escore bruto em QI com média 100 e desvio-padrão 15 (escala de Wechsler).",
                    Criador = "Wechsler D", AnoOrigin = "1939",
                    ReferenciaBibliografica = "Wechsler D. The Measurement of Adult Intelligence. Williams & Wilkins, 1939.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Escore z padronizado", Simbolo = "z", Unidade = "", ValorPadrao = 0 }
                    },
                    Calcular = v => 100 + 15 * v["z"],
                    VariavelResultado = "QI", UnidadeResultado = "pontos"
                },
                new Formula
                {
                    Id = "C5502", Nome = "Alfa de Cronbach (Confiabilidade de Teste)",
                    Categoria = "Psicologia", SubCategoria = "Psicometria",
                    Expressao = "α = (k/(k−1)) × (1 − Σsi² / st²)",
                    Descricao = "Coeficiente de consistência interna de instrumento de medida; α ≥ 0,70 é considerado aceitável.",
                    Criador = "Cronbach LJ", AnoOrigin = "1951",
                    ReferenciaBibliografica = "Cronbach LJ. Psychometrika, 1951.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de itens (k)", Simbolo = "k", Unidade = "", ValorPadrao = 20, ValorMin = 2 },
                        new Variavel { Nome = "Soma das variâncias dos itens (Σsi²)", Simbolo = "sum_si2", Unidade = "", ValorPadrao = 15 },
                        new Variavel { Nome = "Variância total do teste (st²)", Simbolo = "st2", Unidade = "", ValorPadrao = 50, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["k"] / (v["k"] - 1)) * (1 - v["sum_si2"] / v["st2"]),
                    VariavelResultado = "α", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5503", Nome = "d de Cohen (Tamanho de Efeito)",
                    Categoria = "Psicologia", SubCategoria = "Psicologia Experimental",
                    Expressao = "d = (μ1 − μ2) / σ_pooled",
                    Descricao = "Tamanho de efeito padronizado; d=0,2 (pequeno), 0,5 (médio), 0,8 (grande) segundo Cohen.",
                    Criador = "Cohen J", AnoOrigin = "1969",
                    ReferenciaBibliografica = "Cohen J. Statistical Power Analysis for the Behavioral Sciences, 2ª ed. 1988.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Média grupo 1 (μ1)", Simbolo = "μ1", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "Média grupo 2 (μ2)", Simbolo = "μ2", Unidade = "", ValorPadrao = 8 },
                        new Variavel { Nome = "Desvio-padrão combinado (σ_pooled)", Simbolo = "σ_pooled", Unidade = "", ValorPadrao = 2.5, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["μ1"] - v["μ2"]) / v["σ_pooled"],
                    VariavelResultado = "d", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5504", Nome = "Correlação de Pearson",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "r = Σ(xi−x̄)(yi−ȳ) / sqrt[Σ(xi−x̄)² × Σ(yi−ȳ)²]",
                    Descricao = "Coeficiente de correlação linear; indica direção e magnitude da relação entre duas variáveis contínuas.",
                    Criador = "Pearson K", AnoOrigin = "1896",
                    ReferenciaBibliografica = "Pearson K. Philos Trans R Soc London A, 1896.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Covariância (Σ(xi−x̄)(yi−ȳ))", Simbolo = "Cov_xy", Unidade = "", ValorPadrao = 30 },
                        new Variavel { Nome = "Desvio-padrão X (sx)", Simbolo = "sx", Unidade = "", ValorPadrao = 5, ValorMin = 0.001 },
                        new Variavel { Nome = "Desvio-padrão Y (sy)", Simbolo = "sy", Unidade = "", ValorPadrao = 8, ValorMin = 0.001 },
                        new Variavel { Nome = "N amostral", Simbolo = "N", Unidade = "", ValorPadrao = 100, ValorMin = 2 }
                    },
                    Calcular = v => v["Cov_xy"] / ((v["N"]-1) * v["sx"] * v["sy"]) * (v["N"]-1),
                    VariavelResultado = "r", UnidadeResultado = "adimensional (-1 a 1)"
                },
                new Formula
                {
                    Id = "C5505", Nome = "Erro Padrão da Média",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "SEM = σ / sqrt(n)",
                    Descricao = "Precisão com que a média amostral estima a média populacional; base para intervalos de confiança.",
                    Criador = "Gosset WS (Student)", AnoOrigin = "1908",
                    ReferenciaBibliografica = "Student. Biometrika, 1908.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Desvio-padrão (σ)", Simbolo = "σ", Unidade = "", ValorPadrao = 15, ValorMin = 0 },
                        new Variavel { Nome = "Tamanho amostral (n)", Simbolo = "n", Unidade = "", ValorPadrao = 100, ValorMin = 1 }
                    },
                    Calcular = v => v["σ"] / Math.Sqrt(v["n"]),
                    VariavelResultado = "SEM", UnidadeResultado = "mesma unidade que σ"
                },
                new Formula
                {
                    Id = "C5506", Nome = "Fórmula de Spearman-Brown (Projeção de Teste)",
                    Categoria = "Psicologia", SubCategoria = "Psicometria",
                    Expressao = "ρ_n = n × ρ1 / (1 + (n−1) × ρ1)",
                    Descricao = "Prediz a confiabilidade de um teste se seu comprimento for multiplicado por n; base para decisões de extensão de escalas.",
                    Criador = "Spearman C / Brown W", AnoOrigin = "1910",
                    ReferenciaBibliografica = "Spearman C. Brit J Psychol, 1910; Brown W. Brit J Psychol, 1910.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Confiabilidade original (ρ1)", Simbolo = "ρ1", Unidade = "", ValorPadrao = 0.70, ValorMin = 0, ValorMax = 0.999 },
                        new Variavel { Nome = "Fator de extensão (n)", Simbolo = "n", Unidade = "", ValorPadrao = 2, ValorMin = 0.1 }
                    },
                    Calcular = v => v["n"] * v["ρ1"] / (1 + (v["n"] - 1) * v["ρ1"]),
                    VariavelResultado = "ρ_n", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5507", Nome = "Lei de Weber-Fechner",
                    Categoria = "Psicologia", SubCategoria = "Psicofísica",
                    Expressao = "S = k × log(I / I0)",
                    Descricao = "Percepção sensorial (S) cresce logaritmicamente com o estímulo físico (I); primeira lei quantitativa da psicofísica.",
                    Criador = "Weber EH / Fechner GT", AnoOrigin = "1834 / 1860",
                    ReferenciaBibliografica = "Fechner GT. Elemente der Psychophysik. Leipzig, 1860.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de Weber (k)", Simbolo = "k", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Intensidade do estímulo (I)", Simbolo = "I", Unidade = "unid.", ValorPadrao = 100, ValorMin = 0.001 },
                        new Variavel { Nome = "Limiar absoluto (I0)", Simbolo = "I0", Unidade = "unid.", ValorPadrao = 1, ValorMin = 0.001 }
                    },
                    Calcular = v => v["k"] * Math.Log10(v["I"] / v["I0"]),
                    VariavelResultado = "S", UnidadeResultado = "unid. de percepção"
                },
                new Formula
                {
                    Id = "C5508", Nome = "Lei de Potência de Stevens",
                    Categoria = "Psicologia", SubCategoria = "Psicofísica",
                    Expressao = "S = k × I^n",
                    Descricao = "Revisão da lei de Fechner; percepção segue potência do estímulo com expoente n específico por modalidade.",
                    Criador = "Stevens SS", AnoOrigin = "1957",
                    ReferenciaBibliografica = "Stevens SS. Psychol Rev, 1957.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de escala (k)", Simbolo = "k", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Intensidade do estímulo (I)", Simbolo = "I", Unidade = "unid.", ValorPadrao = 10, ValorMin = 0.001 },
                        new Variavel { Nome = "Expoente de modalidade (n)", Simbolo = "n", Unidade = "", ValorPadrao = 0.67 }
                    },
                    Calcular = v => v["k"] * Math.Pow(v["I"], v["n"]),
                    VariavelResultado = "S", UnidadeResultado = "unid. de percepção"
                },
                new Formula
                {
                    Id = "C5509", Nome = "Qui-Quadrado (χ²) de Pearson",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "χ² = Σ (O − E)² / E",
                    Descricao = "Teste de independência de variáveis categóricas; amplamente usado em psicologia e ciências sociais.",
                    Criador = "Pearson K", AnoOrigin = "1900",
                    ReferenciaBibliografica = "Pearson K. Philos Mag, 1900.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Valor observado (O)", Simbolo = "O", Unidade = "freq.", ValorPadrao = 30 },
                        new Variavel { Nome = "Valor esperado (E)", Simbolo = "E", Unidade = "freq.", ValorPadrao = 25, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["O"] - v["E"]) * (v["O"] - v["E"]) / v["E"],
                    VariavelResultado = "χ² (por célula)", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5510", Nome = "Modelo de Rasch (Probabilidade de Acerto)",
                    Categoria = "Psicologia", SubCategoria = "Teoria de Resposta ao Item (TRI)",
                    Expressao = "P(acerto) = exp(θ − b) / (1 + exp(θ − b))",
                    Descricao = "Probabilidade de acerto de item com dificuldade b por respondente com habilidade θ; modelo mais parcimonioso da TRI.",
                    Criador = "Rasch G", AnoOrigin = "1960",
                    ReferenciaBibliografica = "Rasch G. Probabilistic Models for Some Intelligence and Attainment Tests. Copenhagen, 1960.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Habilidade do respondente (θ)", Simbolo = "θ", Unidade = "logit", ValorPadrao = 0 },
                        new Variavel { Nome = "Dificuldade do item (b)", Simbolo = "b", Unidade = "logit", ValorPadrao = 0 }
                    },
                    Calcular = v => Math.Exp(v["θ"] - v["b"]) / (1 + Math.Exp(v["θ"] - v["b"])),
                    VariavelResultado = "P(acerto)", UnidadeResultado = "probabilidade"
                },
                new Formula
                {
                    Id = "C5511", Nome = "Índice de Discriminação de Item",
                    Categoria = "Psicologia", SubCategoria = "Psicometria",
                    Expressao = "D = (P_sup − P_inf)",
                    Descricao = "Diferença de acerto entre grupo superior (27% maiores notas) e inferior; D ≥ 0,30 indica item discriminativo.",
                    Criador = "Kelly TL", AnoOrigin = "1939",
                    ReferenciaBibliografica = "Kelly TL. The Selection of Upper and Lower Groups. J Educ Psychol, 1939.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Proporção de acerto no grupo superior (P_sup)", Simbolo = "P_sup", Unidade = "", ValorPadrao = 0.80, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Proporção de acerto no grupo inferior (P_inf)", Simbolo = "P_inf", Unidade = "", ValorPadrao = 0.40, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["P_sup"] - v["P_inf"],
                    VariavelResultado = "D", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5512", Nome = "Curva Normal — Escore Z",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "z = (x − μ) / σ",
                    Descricao = "Padronização de escores; indica quantos desvios-padrão o valor x está acima ou abaixo da média.",
                    Criador = "Gauss CF / Quetelet L", AnoOrigin = "1809 / 1835",
                    ReferenciaBibliografica = "Gauss CF. Theoria Motus, 1809.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Valor (x)", Simbolo = "x", Unidade = "", ValorPadrao = 120 },
                        new Variavel { Nome = "Média (μ)", Simbolo = "μ", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Desvio-padrão (σ)", Simbolo = "σ", Unidade = "", ValorPadrao = 15, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["x"] - v["μ"]) / v["σ"],
                    VariavelResultado = "z", UnidadeResultado = "desvios-padrão"
                },
                new Formula
                {
                    Id = "C5513", Nome = "Intervalos de Confiança (95%)",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "IC_95% = x̄ ± 1,96 × (σ / sqrt(n))",
                    Descricao = "Intervalo que contém o parâmetro populacional com 95% de confiança; usado em relatórios psicológicos.",
                    Criador = "Neyman J", AnoOrigin = "1937",
                    ReferenciaBibliografica = "Neyman J. Philos Trans R Soc London A, 1937.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Média amostral (x̄)", Simbolo = "x̄", Unidade = "", ValorPadrao = 100 },
                        new Variavel { Nome = "Desvio-padrão (σ)", Simbolo = "σ", Unidade = "", ValorPadrao = 15 },
                        new Variavel { Nome = "Tamanho amostral (n)", Simbolo = "n", Unidade = "", ValorPadrao = 100, ValorMin = 1 }
                    },
                    Calcular = v => 1.96 * v["σ"] / Math.Sqrt(v["n"]),
                    VariavelResultado = "Margem IC_95%", UnidadeResultado = "mesma unidade que x̄"
                },
                new Formula
                {
                    Id = "C5514", Nome = "F de Fisher (ANOVA de Um Fator)",
                    Categoria = "Psicologia", SubCategoria = "Psicologia Experimental",
                    Expressao = "F = QMentre / QMdentro",
                    Descricao = "Razão entre variância entre grupos e variância dentro de grupos; testa igualdade de médias em ANOVA.",
                    Criador = "Fisher RA", AnoOrigin = "1925",
                    ReferenciaBibliografica = "Fisher RA. Statistical Methods for Research Workers, 1925.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Quadrado médio entre grupos (QMentre)", Simbolo = "QMentre", Unidade = "", ValorPadrao = 120 },
                        new Variavel { Nome = "Quadrado médio dentro dos grupos (QMdentro)", Simbolo = "QMdentro", Unidade = "", ValorPadrao = 40, ValorMin = 0.001 }
                    },
                    Calcular = v => v["QMentre"] / v["QMdentro"],
                    VariavelResultado = "F", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5515", Nome = "Regressão Linear Simples",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "ŷ = a + b × x",
                    Descricao = "Predição de variável critério ŷ por variável preditora x via regressão linear; base da análise multivariada em psicologia.",
                    Criador = "Galton F / Pearson K", AnoOrigin = "1886 / 1896",
                    ReferenciaBibliografica = "Galton F. J Anthropol Inst, 1886.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Intercepto (a)", Simbolo = "a", Unidade = "", ValorPadrao = 20 },
                        new Variavel { Nome = "Coeficiente de regressão (b)", Simbolo = "b", Unidade = "", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Variável preditora (x)", Simbolo = "x", Unidade = "", ValorPadrao = 100 }
                    },
                    Calcular = v => v["a"] + v["b"] * v["x"],
                    VariavelResultado = "ŷ", UnidadeResultado = "unid. da variável critério"
                },
                new Formula
                {
                    Id = "C5516", Nome = "Proporção de Variância Explicada (R²)",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "R² = r² (regressão simples)",
                    Descricao = "Fração da variância da variável dependente explicada pelo modelo de regressão; interpretado como tamanho de efeito.",
                    Criador = "Galton F / Pearson K", AnoOrigin = "1896",
                    ReferenciaBibliografica = "Cohen J et al. Applied Multiple Regression/Correlation Analysis, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Correlação de Pearson (r)", Simbolo = "r", Unidade = "", ValorPadrao = 0.6, ValorMin = -1, ValorMax = 1 }
                    },
                    Calcular = v => v["r"] * v["r"],
                    VariavelResultado = "R²", UnidadeResultado = "fração (0-1)"
                },
                new Formula
                {
                    Id = "C5517", Nome = "Modelo Logístico (TRI 2 Parâmetros)",
                    Categoria = "Psicologia", SubCategoria = "Teoria de Resposta ao Item",
                    Expressao = "P(θ) = 1 / (1 + exp(−a(θ − b)))",
                    Descricao = "Probabilidade de acerto no modelo logístico de 2 parâmetros; a = discriminação, b = dificuldade.",
                    Criador = "Birnbaum A", AnoOrigin = "1968",
                    ReferenciaBibliografica = "Birnbaum A. In: Lord FM, Novick MR. Statistical Theories of Mental Test Scores, 1968.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Habilidade (θ)", Simbolo = "θ", Unidade = "logit", ValorPadrao = 0 },
                        new Variavel { Nome = "Discriminação (a)", Simbolo = "a", Unidade = "", ValorPadrao = 1.0, ValorMin = 0 },
                        new Variavel { Nome = "Dificuldade (b)", Simbolo = "b", Unidade = "logit", ValorPadrao = 0 }
                    },
                    Calcular = v => 1.0 / (1 + Math.Exp(-v["a"] * (v["θ"] - v["b"]))),
                    VariavelResultado = "P(θ)", UnidadeResultado = "probabilidade"
                },
                new Formula
                {
                    Id = "C5518", Nome = "Assimetria de Distribuição (Skewness de Fisher)",
                    Categoria = "Psicologia", SubCategoria = "Estatística em Psicologia",
                    Expressao = "g1 = [n/((n−1)(n−2))] × Σ((xi−x̄)/s)³",
                    Descricao = "Medida de assimetria da distribuição; g1>0 (cauda direita), g1<0 (cauda esquerda); importante em psicometria.",
                    Criador = "Fisher RA", AnoOrigin = "1930",
                    ReferenciaBibliografica = "Joanes DN, Gill CA. J R Stat Soc D, 1998.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma do cubo dos z-scores", Simbolo = "sum_z3", Unidade = "", ValorPadrao = 5 },
                        new Variavel { Nome = "Tamanho amostral (n)", Simbolo = "n", Unidade = "", ValorPadrao = 100, ValorMin = 3 }
                    },
                    Calcular = v => (v["n"] / ((v["n"] - 1) * (v["n"] - 2))) * v["sum_z3"],
                    VariavelResultado = "g1", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5519", Nome = "Taxa Base e Poder Preditivo (Valor Preditivo Positivo)",
                    Categoria = "Psicologia", SubCategoria = "Diagnóstico Psicológico",
                    Expressao = "VPP = (Sens × P) / (Sens × P + (1−Espec) × (1−P))",
                    Descricao = "Probabilidade de transtorno dado teste positivo; depende criticamente da prevalência (taxa base) na população.",
                    Criador = "Bayes T / Meehl PE", AnoOrigin = "1763 / 1954",
                    ReferenciaBibliografica = "Meehl PE, Rosen A. Psychol Bull, 1955.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Sensibilidade (Sens)", Simbolo = "Sens", Unidade = "", ValorPadrao = 0.90, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Especificidade (Espec)", Simbolo = "Espec", Unidade = "", ValorPadrao = 0.85, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Prevalência / Taxa base (P)", Simbolo = "P", Unidade = "", ValorPadrao = 0.10, ValorMin = 0.001, ValorMax = 0.999 }
                    },
                    Calcular = v => (v["Sens"]*v["P"]) / (v["Sens"]*v["P"] + (1-v["Espec"])*(1-v["P"])),
                    VariavelResultado = "VPP", UnidadeResultado = "probabilidade"
                },
                new Formula
                {
                    Id = "C5520", Nome = "Validade Incremental (ΔR²)",
                    Categoria = "Psicologia", SubCategoria = "Psicometria",
                    Expressao = "ΔR² = R²_completo − R²_restrito",
                    Descricao = "Variância adicional explicada ao adicionar preditor(es) a um modelo de regressão; teste de validade incremental.",
                    Criador = "Cohen J", AnoOrigin = "1969",
                    ReferenciaBibliografica = "Cohen J et al. Applied Multiple Regression/Correlation Analysis, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "R² modelo completo", Simbolo = "R2_completo", Unidade = "", ValorPadrao = 0.45, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "R² modelo restrito", Simbolo = "R2_restrito", Unidade = "", ValorPadrao = 0.30, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["R2_completo"] - v["R2_restrito"],
                    VariavelResultado = "ΔR²", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5521", Nome = "Limiar Diferencial de Weber (JND)",
                    Categoria = "Psicologia", SubCategoria = "Psicofísica",
                    Expressao = "ΔI / I = k (constante de Weber)",
                    Descricao = "A menor diferença perceptível (JND) é proporção constante do estímulo original; k varia por modalidade sensorial.",
                    Criador = "Weber EH", AnoOrigin = "1834",
                    ReferenciaBibliografica = "Weber EH. De Pulsu, Resorptione, Auditu et Tactu, 1834.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Intensidade do estímulo (I)", Simbolo = "I", Unidade = "unid.", ValorPadrao = 100, ValorMin = 0.001 },
                        new Variavel { Nome = "Constante de Weber (k)", Simbolo = "k", Unidade = "", ValorPadrao = 0.05, ValorMin = 0 }
                    },
                    Calcular = v => v["k"] * v["I"],
                    VariavelResultado = "ΔI (JND)", UnidadeResultado = "mesma unidade que I"
                },
                new Formula
                {
                    Id = "C5522", Nome = "Kappa de Cohen (Concordância entre Juízes)",
                    Categoria = "Psicologia", SubCategoria = "Psicometria",
                    Expressao = "κ = (Po − Pe) / (1 − Pe)",
                    Descricao = "Concordância além do acaso entre dois avaliadores; κ>0,60 adequado, >0,80 excelente.",
                    Criador = "Cohen J", AnoOrigin = "1960",
                    ReferenciaBibliografica = "Cohen J. Educ Psychol Meas, 1960.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Concordância observada (Po)", Simbolo = "Po", Unidade = "", ValorPadrao = 0.80, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Concordância esperada ao acaso (Pe)", Simbolo = "Pe", Unidade = "", ValorPadrao = 0.50, ValorMin = 0, ValorMax = 0.999 }
                    },
                    Calcular = v => (v["Po"] - v["Pe"]) / (1 - v["Pe"]),
                    VariavelResultado = "κ", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5523", Nome = "Curva de Esquecimento de Ebbinghaus",
                    Categoria = "Psicologia", SubCategoria = "Psicologia da Memória",
                    Expressao = "R = e^(−t/S)",
                    Descricao = "Retenção de memória R como função do tempo t e estabilidade S da memória; base das técnicas de repetição espaçada.",
                    Criador = "Ebbinghaus H", AnoOrigin = "1885",
                    ReferenciaBibliografica = "Ebbinghaus H. Über das Gedächtnis, 1885.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tempo decorrido (t)", Simbolo = "t", Unidade = "dias", ValorPadrao = 1, ValorMin = 0 },
                        new Variavel { Nome = "Estabilidade da memória (S)", Simbolo = "S", Unidade = "dias", ValorPadrao = 10, ValorMin = 0.001 }
                    },
                    Calcular = v => Math.Exp(-v["t"] / v["S"]),
                    VariavelResultado = "R", UnidadeResultado = "fração retida (0-1)"
                },
                new Formula
                {
                    Id = "C5524", Nome = "Taxa de Crescimento em Teoria da Detecção do Sinal (d')",
                    Categoria = "Psicologia", SubCategoria = "Psicofísica / Percepção",
                    Expressao = "d' = z(H) − z(FA)",
                    Descricao = "Sensibilidade discriminativa d' (d-prime); separa capacidade perceptiva do viés de resposta na teoria do sinal.",
                    Criador = "Tanner WP, Swets JA", AnoOrigin = "1954",
                    ReferenciaBibliografica = "Tanner WP, Swets JA. Psychol Rev, 1954.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Z-score da taxa de acertos [z(H)]", Simbolo = "z_H", Unidade = "", ValorPadrao = 1.5 },
                        new Variavel { Nome = "Z-score da taxa de alarmes falsos [z(FA)]", Simbolo = "z_FA", Unidade = "", ValorPadrao = 0.5 }
                    },
                    Calcular = v => v["z_H"] - v["z_FA"],
                    VariavelResultado = "d'", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5525", Nome = "Percentil de Distribuição Normal",
                    Categoria = "Psicologia", SubCategoria = "Psicometria",
                    Expressao = "Percentil = Φ(z) × 100  [valor aproximado: P50 = z=0, P84 = z=1, P98 = z=2]",
                    Descricao = "Posição relativa na distribuição normal; interpreta desempenho em testes psicológicos padronizados.",
                    Criador = "Galton F", AnoOrigin = "1885",
                    ReferenciaBibliografica = "Galton F. Natural Inheritance. London, 1889.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Escore z padronizado", Simbolo = "z", Unidade = "", ValorPadrao = 1.0 }
                    },
                    Calcular = v => {
                        double z = v["z"];
                        double p = 0.5 * (1 + Math.Sign(z) * (1 - Math.Exp(-0.7 * z * z)));
                        double t = 1.0 / (1 + 0.2316419 * Math.Abs(z));
                        double poly = t * (0.319381530 + t * (-0.356563782 + t * (1.781477937 + t * (-1.821255978 + t * 1.330274429))));
                        double phi = 1 - (1.0/Math.Sqrt(2*Math.PI)) * Math.Exp(-0.5*z*z) * poly;
                        if (z < 0) phi = 1 - phi;
                        return phi * 100;
                    },
                    VariavelResultado = "Percentil", UnidadeResultado = "%"
                }
            });
        }
    }
}
