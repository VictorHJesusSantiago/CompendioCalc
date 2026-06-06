using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Epidemiologia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5801", Nome = "Incidência Acumulada",
                    Categoria = "Epidemiologia", SubCategoria = "Medidas de Frequência",
                    Expressao = "IC = novos_casos / população_em_risco",
                    Descricao = "Proporção de pessoas que desenvolveram a doença em período definido; estima risco individual.",
                    Criador = "Greenwood M", AnoOrigin = "1926",
                    ReferenciaBibliografica = "Rothman KJ. Epidemiology: An Introduction, 2ª ed. Oxford, 2012.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Novos casos", Simbolo = "casos", Unidade = "casos", ValorPadrao = 50 },
                        new Variavel { Nome = "População em risco", Simbolo = "pop", Unidade = "pessoas", ValorPadrao = 10000, ValorMin = 1 }
                    },
                    Calcular = v => v["casos"] / v["pop"],
                    VariavelResultado = "IC", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5802", Nome = "Taxa de Incidência (Densidade de Incidência)",
                    Categoria = "Epidemiologia", SubCategoria = "Medidas de Frequência",
                    Expressao = "TI = novos_casos / (Σ pessoas-tempo em risco)",
                    Descricao = "Taxa de ocorrência de novos casos por unidade de pessoa-tempo; preferida quando o seguimento varia.",
                    Criador = "Merrell M", AnoOrigin = "1955",
                    ReferenciaBibliografica = "Rothman KJ. Epidemiology: An Introduction, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Novos casos", Simbolo = "casos", Unidade = "casos", ValorPadrao = 20 },
                        new Variavel { Nome = "Pessoas-ano em risco", Simbolo = "pt", Unidade = "pessoas-ano", ValorPadrao = 5000, ValorMin = 0.001 }
                    },
                    Calcular = v => v["casos"] / v["pt"],
                    VariavelResultado = "TI", UnidadeResultado = "casos/pessoa-ano"
                },
                new Formula
                {
                    Id = "C5803", Nome = "Prevalência Pontual",
                    Categoria = "Epidemiologia", SubCategoria = "Medidas de Frequência",
                    Expressao = "P = casos_existentes / total_examinados",
                    Descricao = "Proporção de indivíduos com a doença em um único ponto no tempo; mede carga de doença.",
                    Criador = "Sydenstrycker VP", AnoOrigin = "1933",
                    ReferenciaBibliografica = "Rothman KJ. Epidemiology: An Introduction, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Casos existentes", Simbolo = "casos", Unidade = "casos", ValorPadrao = 200 },
                        new Variavel { Nome = "Total examinados", Simbolo = "total", Unidade = "pessoas", ValorPadrao = 1000, ValorMin = 1 }
                    },
                    Calcular = v => v["casos"] / v["total"],
                    VariavelResultado = "P", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5804", Nome = "Risco Relativo (RR)",
                    Categoria = "Epidemiologia", SubCategoria = "Medidas de Associação",
                    Expressao = "RR = IC_expostos / IC_não_expostos",
                    Descricao = "Razão entre incidência acumulada em expostos e não-expostos; mede força da associação causal.",
                    Criador = "Cornfield J", AnoOrigin = "1951",
                    ReferenciaBibliografica = "Rothman KJ. Epidemiology: An Introduction, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Incidência nos expostos (IC_e)", Simbolo = "IC_e", Unidade = "fração", ValorPadrao = 0.15, ValorMin = 0 },
                        new Variavel { Nome = "Incidência nos não-expostos (IC_ne)", Simbolo = "IC_ne", Unidade = "fração", ValorPadrao = 0.05, ValorMin = 0.001 }
                    },
                    Calcular = v => v["IC_e"] / v["IC_ne"],
                    VariavelResultado = "RR", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5805", Nome = "Odds Ratio (OR)",
                    Categoria = "Epidemiologia", SubCategoria = "Medidas de Associação",
                    Expressao = "OR = (a × d) / (b × c)",
                    Descricao = "Razão de chances; usada em estudos de caso-controle; OR≈RR quando doença é rara (P<5%).",
                    Criador = "Cornfield J", AnoOrigin = "1951",
                    ReferenciaBibliografica = "Schlesselman JJ. Case-Control Studies. Oxford, 1982.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Casos expostos (a)", Simbolo = "a", Unidade = "", ValorPadrao = 30 },
                        new Variavel { Nome = "Controles expostos (b)", Simbolo = "b", Unidade = "", ValorPadrao = 20 },
                        new Variavel { Nome = "Casos não-expostos (c)", Simbolo = "c", Unidade = "", ValorPadrao = 10 },
                        new Variavel { Nome = "Controles não-expostos (d)", Simbolo = "d", Unidade = "", ValorPadrao = 40 }
                    },
                    Calcular = v => (v["a"] * v["d"]) / (v["b"] * v["c"]),
                    VariavelResultado = "OR", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5806", Nome = "Número Básico de Reprodução (R0)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia de Doenças Infecciosas",
                    Expressao = "R0 = β × D × S0",
                    Descricao = "Número médio de casos secundários gerados por caso primário em população totalmente suscetível.",
                    Criador = "Kermack WO, McKendrick AG", AnoOrigin = "1927",
                    ReferenciaBibliografica = "Kermack WO, McKendrick AG. Proc R Soc London A, 1927.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Taxa de transmissão (β)", Simbolo = "β", Unidade = "contatos/dia", ValorPadrao = 0.3 },
                        new Variavel { Nome = "Duração infecciosa (D)", Simbolo = "D", Unidade = "dias", ValorPadrao = 7 },
                        new Variavel { Nome = "Fração suscetível (S0)", Simbolo = "S0", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["β"] * v["D"] * v["S0"],
                    VariavelResultado = "R0", UnidadeResultado = "casos/caso"
                },
                new Formula
                {
                    Id = "C5807", Nome = "Número de Reprodução Efetivo (Re ou Rt)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia de Doenças Infecciosas",
                    Expressao = "Re = R0 × S(t)",
                    Descricao = "Transmissibilidade em tempo real considerando fração suscetível S(t) e medidas de controle; Re<1 indica declínio da epidemia.",
                    Criador = "Heesterbeek JAP", AnoOrigin = "2000",
                    ReferenciaBibliografica = "Heesterbeek JAP. Acta Biotheor, 2002.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "R0 da doença", Simbolo = "R0", Unidade = "", ValorPadrao = 3, ValorMin = 0 },
                        new Variavel { Nome = "Fração suscetível atual S(t)", Simbolo = "S_t", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["R0"] * v["S_t"],
                    VariavelResultado = "Re", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5808", Nome = "Cobertura Vacinal para Imunidade de Rebanho",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia de Doenças Infecciosas",
                    Expressao = "p_c = 1 − (1/R0)",
                    Descricao = "Cobertura mínima de vacinação para controle da doença na população (imunidade de rebanho).",
                    Criador = "Fine PEM", AnoOrigin = "1993",
                    ReferenciaBibliografica = "Fine PEM. Am J Epidemiol, 1993.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "R0 da doença", Simbolo = "R0", Unidade = "", ValorPadrao = 5, ValorMin = 1.001 }
                    },
                    Calcular = v => (1 - 1.0/v["R0"]) * 100,
                    VariavelResultado = "p_c", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5809", Nome = "Risco Atribuível (RA) — Diferença de Riscos",
                    Categoria = "Epidemiologia", SubCategoria = "Medidas de Impacto",
                    Expressao = "RA = IC_expostos − IC_não_expostos",
                    Descricao = "Excesso de risco associado à exposição; indica magnitude do risco extra na população exposta.",
                    Criador = "Levin ML", AnoOrigin = "1953",
                    ReferenciaBibliografica = "Rothman KJ. Epidemiology: An Introduction, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Incidência nos expostos", Simbolo = "IC_e", Unidade = "fração", ValorPadrao = 0.20 },
                        new Variavel { Nome = "Incidência nos não-expostos", Simbolo = "IC_ne", Unidade = "fração", ValorPadrao = 0.05 }
                    },
                    Calcular = v => v["IC_e"] - v["IC_ne"],
                    VariavelResultado = "RA", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5810", Nome = "Fração Atribuível Populacional (FAP)",
                    Categoria = "Epidemiologia", SubCategoria = "Medidas de Impacto",
                    Expressao = "FAP = Pe × (RR−1) / [Pe × (RR−1) + 1]",
                    Descricao = "Proporção de casos da doença na população total que seria eliminada se a exposição fosse removida.",
                    Criador = "Levin ML", AnoOrigin = "1953",
                    ReferenciaBibliografica = "Levin ML. Acta Unio Int Contra Cancrum, 1953.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Prevalência da exposição (Pe)", Simbolo = "Pe", Unidade = "fração", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Risco relativo (RR)", Simbolo = "RR", Unidade = "", ValorPadrao = 3, ValorMin = 0 }
                    },
                    Calcular = v => v["Pe"] * (v["RR"]-1) / (v["Pe"] * (v["RR"]-1) + 1),
                    VariavelResultado = "FAP", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5811", Nome = "Sensibilidade de Teste Diagnóstico",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Clínica",
                    Expressao = "Sens = VP / (VP + FN)",
                    Descricao = "Capacidade do teste de identificar corretamente os doentes; fundamental para triagem de doenças graves.",
                    Criador = "Yerushalmy J", AnoOrigin = "1947",
                    ReferenciaBibliografica = "Yerushalmy J. Am J Public Health, 1947.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Verdadeiros positivos (VP)", Simbolo = "VP", Unidade = "", ValorPadrao = 90 },
                        new Variavel { Nome = "Falsos negativos (FN)", Simbolo = "FN", Unidade = "", ValorPadrao = 10, ValorMin = 0 }
                    },
                    Calcular = v => v["VP"] / (v["VP"] + v["FN"]),
                    VariavelResultado = "Sensibilidade", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5812", Nome = "Especificidade de Teste Diagnóstico",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Clínica",
                    Expressao = "Espec = VN / (VN + FP)",
                    Descricao = "Capacidade do teste de identificar corretamente os não-doentes; crucial para evitar excesso de diagnósticos.",
                    Criador = "Yerushalmy J", AnoOrigin = "1947",
                    ReferenciaBibliografica = "Yerushalmy J. Am J Public Health, 1947.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Verdadeiros negativos (VN)", Simbolo = "VN", Unidade = "", ValorPadrao = 850 },
                        new Variavel { Nome = "Falsos positivos (FP)", Simbolo = "FP", Unidade = "", ValorPadrao = 50, ValorMin = 0 }
                    },
                    Calcular = v => v["VN"] / (v["VN"] + v["FP"]),
                    VariavelResultado = "Especificidade", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5813", Nome = "Valor Preditivo Positivo (VPP)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Clínica",
                    Expressao = "VPP = VP / (VP + FP)",
                    Descricao = "Probabilidade de doença dado resultado positivo; depende da prevalência na população testada.",
                    Criador = "Bayes T / Feinstein AR", AnoOrigin = "1763 / 1967",
                    ReferenciaBibliografica = "Feinstein AR. Clinical Epidemiology. Saunders, 1985.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Verdadeiros positivos (VP)", Simbolo = "VP", Unidade = "", ValorPadrao = 90 },
                        new Variavel { Nome = "Falsos positivos (FP)", Simbolo = "FP", Unidade = "", ValorPadrao = 50, ValorMin = 0 }
                    },
                    Calcular = v => v["VP"] / (v["VP"] + v["FP"]),
                    VariavelResultado = "VPP", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5814", Nome = "Razão de Verossimilhança Positiva (LR+)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Clínica",
                    Expressao = "LR+ = Sensibilidade / (1 − Especificidade)",
                    Descricao = "Quanto um resultado positivo aumenta a probabilidade pré-teste de doença; LR+>10 é altamente diagnóstico.",
                    Criador = "Fagan TJ", AnoOrigin = "1975",
                    ReferenciaBibliografica = "Sackett DL et al. Evidence-Based Medicine. Churchill, 2000.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Sensibilidade", Simbolo = "Sens", Unidade = "", ValorPadrao = 0.90, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Especificidade", Simbolo = "Espec", Unidade = "", ValorPadrao = 0.85, ValorMin = 0, ValorMax = 0.999 }
                    },
                    Calcular = v => v["Sens"] / (1 - v["Espec"]),
                    VariavelResultado = "LR+", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5815", Nome = "Número Necessário para Tratar (NNT)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Clínica",
                    Expressao = "NNT = 1 / RA",
                    Descricao = "Número de pacientes a tratar para evitar um evento; quanto menor o NNT, maior o benefício da intervenção.",
                    Criador = "Laupacis A et al.", AnoOrigin = "1988",
                    ReferenciaBibliografica = "Laupacis A et al. N Engl J Med, 1988.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Risco atribuível (RA = diferença de riscos)", Simbolo = "RA", Unidade = "fração", ValorPadrao = 0.05, ValorMin = 0.001 }
                    },
                    Calcular = v => 1.0 / v["RA"],
                    VariavelResultado = "NNT", UnidadeResultado = "pacientes"
                },
                new Formula
                {
                    Id = "C5816", Nome = "Taxa de Mortalidade Padronizada (TMP) por Idade",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Descritiva",
                    Expressao = "TMP = Σ(taxa_especifica × pop_padrão) / pop_padrão_total",
                    Descricao = "Taxa de mortalidade ajustada por idade pelo método direto; permite comparações entre populações.",
                    Criador = "Farr W", AnoOrigin = "1841",
                    ReferenciaBibliografica = "Szklo M, Nieto FJ. Epidemiology: Beyond the Basics, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Taxa específica por idade (média)", Simbolo = "taxa_media", Unidade = "por 100.000", ValorPadrao = 150 },
                        new Variavel { Nome = "Fator de ajuste etário", Simbolo = "fator_etario", Unidade = "", ValorPadrao = 0.85, ValorMin = 0.01 }
                    },
                    Calcular = v => v["taxa_media"] * v["fator_etario"],
                    VariavelResultado = "TMP", UnidadeResultado = "por 100.000 hab."
                },
                new Formula
                {
                    Id = "C5817", Nome = "Anos de Vida Perdidos (AVP)",
                    Categoria = "Epidemiologia", SubCategoria = "Carga de Doença",
                    Expressao = "AVP = n_mortes × (esperança_vida − idade_morte)",
                    Descricao = "Medida de impacto de mortalidade prematura; componente de DALY (Disability-Adjusted Life Year).",
                    Criador = "Murray CJL", AnoOrigin = "1994",
                    ReferenciaBibliografica = "Murray CJL. Bull World Health Organ, 1994.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de mortes", Simbolo = "n_mortes", Unidade = "óbitos", ValorPadrao = 100 },
                        new Variavel { Nome = "Esperança de vida (anos)", Simbolo = "ev", Unidade = "anos", ValorPadrao = 75 },
                        new Variavel { Nome = "Idade média da morte", Simbolo = "idade_morte", Unidade = "anos", ValorPadrao = 45 }
                    },
                    Calcular = v => v["n_mortes"] * Math.Max(0, v["ev"] - v["idade_morte"]),
                    VariavelResultado = "AVP", UnidadeResultado = "anos de vida perdidos"
                },
                new Formula
                {
                    Id = "C5818", Nome = "DALYs (Disability-Adjusted Life Years)",
                    Categoria = "Epidemiologia", SubCategoria = "Carga de Doença",
                    Expressao = "DALY = AVP + AVP_incapacidade",
                    Descricao = "Carga total de doença combinando mortalidade prematura (AVP) e morbidade/incapacidade (YLD).",
                    Criador = "Murray CJL / Lopez AD", AnoOrigin = "1994",
                    ReferenciaBibliografica = "Murray CJL, Lopez AD. Lancet, 1997.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Anos de vida perdidos por morte (AVP)", Simbolo = "AVP", Unidade = "anos", ValorPadrao = 2000 },
                        new Variavel { Nome = "Anos de vida com incapacidade (YLD)", Simbolo = "YLD", Unidade = "anos", ValorPadrao = 500 }
                    },
                    Calcular = v => v["AVP"] + v["YLD"],
                    VariavelResultado = "DALYs", UnidadeResultado = "anos"
                },
                new Formula
                {
                    Id = "C5819", Nome = "Taxa de Ataque (Surto Alimentar)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia de Campo",
                    Expressao = "TA = doentes / total_expostos × 100",
                    Descricao = "Taxa de ataque em surto; compara expostos que adoeceram vs total de expostos ao fator de risco.",
                    Criador = "Prática de epidemiologia de campo", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Gregg MB. Field Epidemiology, 3ª ed. Oxford, 2008.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Doentes expostos", Simbolo = "doentes", Unidade = "casos", ValorPadrao = 30 },
                        new Variavel { Nome = "Total expostos", Simbolo = "expostos", Unidade = "pessoas", ValorPadrao = 80, ValorMin = 1 }
                    },
                    Calcular = v => v["doentes"] / v["expostos"] * 100,
                    VariavelResultado = "TA", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5820", Nome = "Coeficiente de Correlação Ecológica (Estudo Ecológico)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Analítica",
                    Expressao = "r_eco = Cov(exposição, doença) / (sd_expo × sd_doença)",
                    Descricao = "Correlação entre taxas de exposição e doença em nível agregado (populações); sujeita à falácia ecológica.",
                    Criador = "Robinson WS", AnoOrigin = "1950",
                    ReferenciaBibliografica = "Robinson WS. Am Sociol Rev, 1950.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Covariância exposição-doença", Simbolo = "Cov", Unidade = "", ValorPadrao = 15 },
                        new Variavel { Nome = "DP da exposição", Simbolo = "sd_expo", Unidade = "", ValorPadrao = 5, ValorMin = 0.001 },
                        new Variavel { Nome = "DP da doença", Simbolo = "sd_doenca", Unidade = "", ValorPadrao = 6, ValorMin = 0.001 }
                    },
                    Calcular = v => v["Cov"] / (v["sd_expo"] * v["sd_doenca"]),
                    VariavelResultado = "r_eco", UnidadeResultado = "adimensional (-1 a 1)"
                },
                new Formula
                {
                    Id = "C5821", Nome = "Tamanho Amostral para Estudo de Coorte",
                    Categoria = "Epidemiologia", SubCategoria = "Metodologia Epidemiológica",
                    Expressao = "n = (Zα + Zβ)² × [P1(1−P1) + P2(1−P2)] / (P1−P2)²",
                    Descricao = "Tamanho amostral mínimo para detectar diferença entre proporções P1 e P2 com poder Zβ e nível Zα.",
                    Criador = "Fleiss JL", AnoOrigin = "1981",
                    ReferenciaBibliografica = "Fleiss JL. Statistical Methods for Rates and Proportions, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Zα (1,96 para α=5%)", Simbolo = "Za", Unidade = "", ValorPadrao = 1.96 },
                        new Variavel { Nome = "Zβ (0,84 para poder=80%)", Simbolo = "Zb", Unidade = "", ValorPadrao = 0.84 },
                        new Variavel { Nome = "Proporção grupo 1 (P1)", Simbolo = "P1", Unidade = "", ValorPadrao = 0.20, ValorMin = 0.001, ValorMax = 0.999 },
                        new Variavel { Nome = "Proporção grupo 2 (P2)", Simbolo = "P2", Unidade = "", ValorPadrao = 0.10, ValorMin = 0.001, ValorMax = 0.999 }
                    },
                    Calcular = v => {
                        double Zab2 = Math.Pow(v["Za"] + v["Zb"], 2);
                        double P1 = v["P1"]; double P2 = v["P2"];
                        double diff2 = Math.Pow(P1 - P2, 2);
                        if (diff2 < 1e-10) return double.PositiveInfinity;
                        return Zab2 * (P1*(1-P1) + P2*(1-P2)) / diff2;
                    },
                    VariavelResultado = "n (por grupo)", UnidadeResultado = "participantes"
                },
                new Formula
                {
                    Id = "C5822", Nome = "Curva Epidêmica — Pico pelo Modelo SIR",
                    Categoria = "Epidemiologia", SubCategoria = "Modelagem Epidemiológica",
                    Expressao = "I_pico = N − (γ/β) × (1 + ln(β × S0 / (γ × N)))",
                    Descricao = "Pico de infectados no modelo SIR; β = taxa de transmissão, γ = taxa de recuperação.",
                    Criador = "Kermack WO, McKendrick AG", AnoOrigin = "1927",
                    ReferenciaBibliografica = "Anderson RM, May RM. Infectious Diseases of Humans. Oxford, 1991.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "População total (N)", Simbolo = "N", Unidade = "pessoas", ValorPadrao = 100000, ValorMin = 1 },
                        new Variavel { Nome = "Taxa de transmissão (β)", Simbolo = "β", Unidade = "por dia", ValorPadrao = 0.3, ValorMin = 0.001 },
                        new Variavel { Nome = "Taxa de recuperação (γ)", Simbolo = "γ", Unidade = "por dia", ValorPadrao = 0.1, ValorMin = 0.001 },
                        new Variavel { Nome = "Suscetíveis iniciais (S0)", Simbolo = "S0", Unidade = "pessoas", ValorPadrao = 99999, ValorMin = 1 }
                    },
                    Calcular = v => v["N"] - (v["γ"]/v["β"]) * (1 + Math.Log(v["β"]*v["S0"]/(v["γ"]*v["N"]))),
                    VariavelResultado = "I_pico", UnidadeResultado = "pessoas"
                },
                new Formula
                {
                    Id = "C5823", Nome = "Razão Padronizada de Mortalidade (SMR)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia Ocupacional",
                    Expressao = "SMR = Óbitos_observados / Óbitos_esperados",
                    Descricao = "Razão entre mortes observadas e esperadas em coorte ocupacional; SMR>1 indica excesso de risco.",
                    Criador = "Standardisation methods", AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Checkoway H et al. Research Methods in Occupational Epidemiology, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Óbitos observados", Simbolo = "obs", Unidade = "óbitos", ValorPadrao = 45 },
                        new Variavel { Nome = "Óbitos esperados", Simbolo = "esp", Unidade = "óbitos", ValorPadrao = 30, ValorMin = 0.001 }
                    },
                    Calcular = v => v["obs"] / v["esp"],
                    VariavelResultado = "SMR", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5824", Nome = "Tempo de Geração de Surto (Serial Interval)",
                    Categoria = "Epidemiologia", SubCategoria = "Epidemiologia de Doenças Infecciosas",
                    Expressao = "SI = média do intervalo entre datas de sintomas de pares caso-contato",
                    Descricao = "Tempo médio entre adoecimento de caso primário e caso secundário; estima velocidade de progressão do surto.",
                    Criador = "Fine PEM", AnoOrigin = "2003",
                    ReferenciaBibliografica = "Fine PEM. Am J Epidemiol, 2003.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma dos intervalos seriais (dias)", Simbolo = "soma_SI", Unidade = "dias", ValorPadrao = 35 },
                        new Variavel { Nome = "Número de pares observados", Simbolo = "n_pares", Unidade = "pares", ValorPadrao = 5, ValorMin = 1 }
                    },
                    Calcular = v => v["soma_SI"] / v["n_pares"],
                    VariavelResultado = "SI", UnidadeResultado = "dias"
                },
                new Formula
                {
                    Id = "C5825", Nome = "Índice de Saúde — DALY Ponderado por Incapacidade (YLD)",
                    Categoria = "Epidemiologia", SubCategoria = "Carga de Doença",
                    Expressao = "YLD = n_casos_incidentes × DW × duração",
                    Descricao = "Anos de vida vividos com incapacidade; DW = peso de incapacidade (0-1) × duração da doença.",
                    Criador = "Murray CJL", AnoOrigin = "1994",
                    ReferenciaBibliografica = "Murray CJL, Lopez AD. Lancet, 1997.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Casos incidentes", Simbolo = "casos", Unidade = "casos", ValorPadrao = 1000 },
                        new Variavel { Nome = "Peso de incapacidade (DW)", Simbolo = "DW", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Duração da doença (anos)", Simbolo = "dur", Unidade = "anos", ValorPadrao = 5 }
                    },
                    Calcular = v => v["casos"] * v["DW"] * v["dur"],
                    VariavelResultado = "YLD", UnidadeResultado = "anos"
                }
            });
        }
    }
}
