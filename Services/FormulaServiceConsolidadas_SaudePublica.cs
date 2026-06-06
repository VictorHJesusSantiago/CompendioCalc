using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_SaudePublica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C6101", Nome = "Coeficiente de Mortalidade Infantil (CMI)",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores de Saúde",
                    Expressao = "CMI = (óbitos <1 ano / nascidos vivos) × 1000",
                    Descricao = "Número de mortes de crianças com menos de 1 ano por 1000 nascidos vivos; indicador clássico de desenvolvimento.",
                    Criador = "OMS / UNICEF", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "WHO. World Health Statistics. Geneva, 2023.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Óbitos infantis (<1 ano)", Simbolo = "obitos", Unidade = "óbitos", ValorPadrao = 250 },
                        new Variavel { Nome = "Nascidos vivos", Simbolo = "nascidos", Unidade = "nascimentos", ValorPadrao = 100000, ValorMin = 1 }
                    },
                    Calcular = v => v["obitos"] / v["nascidos"] * 1000,
                    VariavelResultado = "CMI", UnidadeResultado = "por 1.000 NV"
                },
                new Formula
                {
                    Id = "C6102", Nome = "Esperança de Vida ao Nascer",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores de Saúde",
                    Expressao = "e0 = Σ L_x / l_0 (tábua de vida)",
                    Descricao = "Número médio de anos de vida esperados ao nascimento; calculado pela tábua de mortalidade.",
                    Criador = "Halley E (pioneiro)", AnoOrigin = "1693",
                    ReferenciaBibliografica = "Preston S et al. Demography: Measuring and Modeling Population Processes. Blackwell, 2001.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma de anos-pessoa vividos (Σ L_x)", Simbolo = "sum_Lx", Unidade = "anos-pessoa", ValorPadrao = 7500000 },
                        new Variavel { Nome = "Coorte de nascimento (l_0)", Simbolo = "l_0", Unidade = "pessoas", ValorPadrao = 100000, ValorMin = 1 }
                    },
                    Calcular = v => v["sum_Lx"] / v["l_0"],
                    VariavelResultado = "e0", UnidadeResultado = "anos"
                },
                new Formula
                {
                    Id = "C6103", Nome = "Taxa de Fecundidade Total (TFT)",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores Demográficos",
                    Expressao = "TFT = Σ (taxa_fecundidade_etaria × 5)",
                    Descricao = "Número médio de filhos que uma mulher teria ao longo da vida se seguisse taxas de fecundidade por idade atuais.",
                    Criador = "Dublin LI / Lotka AJ", AnoOrigin = "1925",
                    ReferenciaBibliografica = "Preston S et al. Demography. Blackwell, 2001.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma das taxas de fecundidade específicas por idade (×5 anos)", Simbolo = "sum_tf", Unidade = "filhos/1000 mulheres", ValorPadrao = 300 }
                    },
                    Calcular = v => v["sum_tf"] / 1000,
                    VariavelResultado = "TFT", UnidadeResultado = "filhos por mulher"
                },
                new Formula
                {
                    Id = "C6104", Nome = "Taxa de Crescimento Populacional",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores Demográficos",
                    Expressao = "r = (TBN − TBM + imigração − emigração) / 10",
                    Descricao = "Taxa de crescimento anual da população (‰); TBN = taxa bruta de natalidade, TBM = taxa bruta de mortalidade.",
                    Criador = "Malthus TR (precursor)", AnoOrigin = "1798",
                    ReferenciaBibliografica = "Preston S et al. Demography. Blackwell, 2001.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "TBN (por 1000 hab)", Simbolo = "TBN", Unidade = "‰", ValorPadrao = 15 },
                        new Variavel { Nome = "TBM (por 1000 hab)", Simbolo = "TBM", Unidade = "‰", ValorPadrao = 7 },
                        new Variavel { Nome = "Saldo migratório (por 1000 hab)", Simbolo = "migr", Unidade = "‰", ValorPadrao = 2 }
                    },
                    Calcular = v => (v["TBN"] - v["TBM"] + v["migr"]) / 10,
                    VariavelResultado = "r", UnidadeResultado = "% ao ano"
                },
                new Formula
                {
                    Id = "C6105", Nome = "Razão de Mortalidade Materna (RMM)",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores de Saúde",
                    Expressao = "RMM = (óbitos maternos / nascidos vivos) × 100.000",
                    Descricao = "Mortes maternas por 100.000 nascidos vivos; meta ODS 3: <70/100.000 até 2030.",
                    Criador = "OMS", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "WHO. Trends in Maternal Mortality. Geneva, 2023.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Óbitos maternos", Simbolo = "obitos_mat", Unidade = "óbitos", ValorPadrao = 50 },
                        new Variavel { Nome = "Nascidos vivos", Simbolo = "nascidos", Unidade = "", ValorPadrao = 100000, ValorMin = 1 }
                    },
                    Calcular = v => v["obitos_mat"] / v["nascidos"] * 100000,
                    VariavelResultado = "RMM", UnidadeResultado = "por 100.000 NV"
                },
                new Formula
                {
                    Id = "C6106", Nome = "Cobertura de Vacinação",
                    Categoria = "Saúde Pública", SubCategoria = "Imunização",
                    Expressao = "Cob_vac = (doses_aplicadas / pop_alvo) × 100",
                    Descricao = "Percentagem da população-alvo que recebeu o esquema vacinal completo; meta de 95% para erradicação.",
                    Criador = "OMS / EPI", AnoOrigin = "1974",
                    ReferenciaBibliografica = "WHO. Global Vaccine Action Plan 2011-2020. Geneva, 2012.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Doses aplicadas", Simbolo = "doses", Unidade = "doses", ValorPadrao = 9500 },
                        new Variavel { Nome = "População alvo", Simbolo = "pop_alvo", Unidade = "pessoas", ValorPadrao = 10000, ValorMin = 1 }
                    },
                    Calcular = v => v["doses"] / v["pop_alvo"] * 100,
                    VariavelResultado = "Cobertura", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6107", Nome = "Custo-Efetividade (ICER)",
                    Categoria = "Saúde Pública", SubCategoria = "Economia da Saúde",
                    Expressao = "ICER = (Custo_novo − Custo_ref) / (Efetividade_novo − Efetividade_ref)",
                    Descricao = "Razão de custo-efetividade incremental; compara custo e benefício de nova intervenção vs referência.",
                    Criador = "Weinstein MC, Stason WB", AnoOrigin = "1977",
                    ReferenciaBibliografica = "Weinstein MC, Stason WB. N Engl J Med, 1977.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Custo intervenção nova (USD)", Simbolo = "C_novo", Unidade = "USD", ValorPadrao = 50000 },
                        new Variavel { Nome = "Custo referência (USD)", Simbolo = "C_ref", Unidade = "USD", ValorPadrao = 30000 },
                        new Variavel { Nome = "Efetividade nova (QALY)", Simbolo = "E_novo", Unidade = "QALY", ValorPadrao = 2.0 },
                        new Variavel { Nome = "Efetividade referência (QALY)", Simbolo = "E_ref", Unidade = "QALY", ValorPadrao = 1.5, ValorMin = 0 }
                    },
                    Calcular = v => (v["C_novo"] - v["C_ref"]) / Math.Max(v["E_novo"] - v["E_ref"], 0.001),
                    VariavelResultado = "ICER", UnidadeResultado = "USD/QALY"
                },
                new Formula
                {
                    Id = "C6108", Nome = "Anos de Vida Ajustados por Qualidade (QALY)",
                    Categoria = "Saúde Pública", SubCategoria = "Economia da Saúde",
                    Expressao = "QALY = Σ (anos_em_estado × utilidade_do_estado)",
                    Descricao = "Medida de benefício em saúde combinando quantidade e qualidade de vida; 1 QALY = 1 ano em saúde perfeita.",
                    Criador = "Torrance GW", AnoOrigin = "1976",
                    ReferenciaBibliografica = "Torrance GW. J Health Econ, 1986.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Anos de vida (A)", Simbolo = "A", Unidade = "anos", ValorPadrao = 10 },
                        new Variavel { Nome = "Utilidade do estado de saúde (U)", Simbolo = "U", Unidade = "", ValorPadrao = 0.75, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["A"] * v["U"],
                    VariavelResultado = "QALY", UnidadeResultado = "anos de vida ajustados por qualidade"
                },
                new Formula
                {
                    Id = "C6109", Nome = "Taxa de Abandono de Tratamento",
                    Categoria = "Saúde Pública", SubCategoria = "Epidemiologia Clínica",
                    Expressao = "TA = (pacientes_que_abandonaram / pacientes_iniciados) × 100",
                    Descricao = "Percentagem de pacientes que não completaram o tratamento; importante em TB, HIV, hipertensão.",
                    Criador = "OMS", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "WHO. Global Tuberculosis Report. Geneva, 2023.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Pacientes que abandonaram", Simbolo = "abandon", Unidade = "pacientes", ValorPadrao = 20 },
                        new Variavel { Nome = "Pacientes iniciados", Simbolo = "iniciados", Unidade = "pacientes", ValorPadrao = 200, ValorMin = 1 }
                    },
                    Calcular = v => v["abandon"] / v["iniciados"] * 100,
                    VariavelResultado = "TA", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6110", Nome = "Índice de Swaroop-Uemura (ISDU)",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores de Saúde",
                    Expressao = "ISDU = (óbitos ≥50 anos / total de óbitos) × 100",
                    Descricao = "Proporção de óbitos em maiores de 50 anos; alto ISDU (>75%) indica mortalidade deslocada para idades tardias = boa saúde.",
                    Criador = "Swaroop S, Uemura K", AnoOrigin = "1957",
                    ReferenciaBibliografica = "Swaroop S, Uemura K. Bull World Health Organ, 1957.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Óbitos ≥50 anos", Simbolo = "obitos_50", Unidade = "óbitos", ValorPadrao = 800 },
                        new Variavel { Nome = "Total de óbitos", Simbolo = "total_obitos", Unidade = "óbitos", ValorPadrao = 1000, ValorMin = 1 }
                    },
                    Calcular = v => v["obitos_50"] / v["total_obitos"] * 100,
                    VariavelResultado = "ISDU", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6111", Nome = "Taxa de Detecção de Tuberculose",
                    Categoria = "Saúde Pública", SubCategoria = "Controle de Doenças",
                    Expressao = "TD = (casos_novos_notificados / estimativa_incidência) × 100",
                    Descricao = "Proporção de casos de tuberculose detectados em relação à estimativa de incidência da OMS.",
                    Criador = "OMS / STOP TB", AnoOrigin = "2001",
                    ReferenciaBibliografica = "WHO. Global Tuberculosis Report. Geneva, 2023.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Casos novos notificados", Simbolo = "casos_noti", Unidade = "casos", ValorPadrao = 7500 },
                        new Variavel { Nome = "Estimativa de incidência (OMS)", Simbolo = "est_incid", Unidade = "casos", ValorPadrao = 10000, ValorMin = 1 }
                    },
                    Calcular = v => v["casos_noti"] / v["est_incid"] * 100,
                    VariavelResultado = "TD", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6112", Nome = "Cobertura de Parto Institucional",
                    Categoria = "Saúde Pública", SubCategoria = "Saúde Materna",
                    Expressao = "Cob_inst = (partos_inst / total_partos) × 100",
                    Descricao = "Percentagem de partos realizados em estabelecimentos de saúde; indicador ODS 3 de saúde materna.",
                    Criador = "OMS", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "WHO. Making Pregnancy Safer. Geneva, 2007.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Partos institucionais", Simbolo = "partos_inst", Unidade = "partos", ValorPadrao = 9200 },
                        new Variavel { Nome = "Total de partos", Simbolo = "total_partos", Unidade = "partos", ValorPadrao = 10000, ValorMin = 1 }
                    },
                    Calcular = v => v["partos_inst"] / v["total_partos"] * 100,
                    VariavelResultado = "Cob_inst", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6113", Nome = "Razão de Dependência Demográfica",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores Demográficos",
                    Expressao = "RD = (pop_0_14 + pop_65+) / pop_15_64 × 100",
                    Descricao = "Razão entre população dependente e economicamente ativa; influencia demandas sobre sistemas de saúde e previdência.",
                    Criador = "ONU", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "UN Population Division. World Population Prospects 2022.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Pop. 0-14 anos", Simbolo = "pop_0_14", Unidade = "pessoas", ValorPadrao = 25000 },
                        new Variavel { Nome = "Pop. 65+ anos", Simbolo = "pop_65", Unidade = "pessoas", ValorPadrao = 15000 },
                        new Variavel { Nome = "Pop. 15-64 anos", Simbolo = "pop_15_64", Unidade = "pessoas", ValorPadrao = 60000, ValorMin = 1 }
                    },
                    Calcular = v => (v["pop_0_14"] + v["pop_65"]) / v["pop_15_64"] * 100,
                    VariavelResultado = "RD", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6114", Nome = "Índice de Desenvolvimento Humano (IDH — componente saúde)",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores Compostos",
                    Expressao = "I_saude = (EV − 20) / (85 − 20)",
                    Descricao = "Dimensão saúde do IDH baseada na esperança de vida; normaliza entre 20 anos (mínimo) e 85 anos (máximo).",
                    Criador = "PNUD / Mahbub ul Haq", AnoOrigin = "1990",
                    ReferenciaBibliografica = "UNDP. Human Development Report 1990. New York.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Esperança de vida (EV)", Simbolo = "EV", Unidade = "anos", ValorPadrao = 75, ValorMin = 20, ValorMax = 85 }
                    },
                    Calcular = v => (v["EV"] - 20) / (85 - 20),
                    VariavelResultado = "I_saude (IDH)", UnidadeResultado = "adimensional (0-1)"
                },
                new Formula
                {
                    Id = "C6115", Nome = "Índice de Gini de Saúde (Concentração de Mortalidade)",
                    Categoria = "Saúde Pública", SubCategoria = "Equidade em Saúde",
                    Expressao = "C = 2 × cov(h, r) / μ_h",
                    Descricao = "Índice de concentração de iniquidade em saúde; C=0 (equidade), C<0 (concentração nos pobres), C>0 (nos ricos).",
                    Criador = "Wagstaff A et al.", AnoOrigin = "1991",
                    ReferenciaBibliografica = "Wagstaff A et al. J Health Econ, 1991.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Covariância entre saúde e rank socioeconômico", Simbolo = "cov_hr", Unidade = "", ValorPadrao = -0.05 },
                        new Variavel { Nome = "Média do indicador de saúde", Simbolo = "μ_h", Unidade = "", ValorPadrao = 0.5, ValorMin = 0.001 }
                    },
                    Calcular = v => 2 * v["cov_hr"] / v["μ_h"],
                    VariavelResultado = "C (índice de concentração)", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C6116", Nome = "Taxa de Incidência de HIV (Estimativa SPECTRUM)",
                    Categoria = "Saúde Pública", SubCategoria = "HIV/AIDS",
                    Expressao = "TI_HIV = novos_HIV / (pop_15_49 - PHIV) × 1000",
                    Descricao = "Taxa de novas infecções por HIV em adultos de 15-49 anos; base para monitoramento dos ODM/ODS.",
                    Criador = "UNAIDS", AnoOrigin = "1994",
                    ReferenciaBibliografica = "UNAIDS. Global AIDS Update. Geneva, 2023.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Novas infecções HIV", Simbolo = "novos_HIV", Unidade = "casos", ValorPadrao = 500 },
                        new Variavel { Nome = "Pop. 15-49 anos", Simbolo = "pop_15_49", Unidade = "pessoas", ValorPadrao = 500000 },
                        new Variavel { Nome = "PHIV — pessoas vivendo com HIV", Simbolo = "PHIV", Unidade = "pessoas", ValorPadrao = 10000 }
                    },
                    Calcular = v => v["novos_HIV"] / (v["pop_15_49"] - v["PHIV"]) * 1000,
                    VariavelResultado = "TI_HIV", UnidadeResultado = "por 1.000 pessoas-ano"
                },
                new Formula
                {
                    Id = "C6117", Nome = "Índice de Cobertura de Atenção Primária",
                    Categoria = "Saúde Pública", SubCategoria = "Sistemas de Saúde",
                    Expressao = "ICAP = (1/N) × Σ cobertura_i",
                    Descricao = "Média de coberturas de serviços essenciais de atenção primária; base para medir progresso rumo à cobertura universal de saúde.",
                    Criador = "OMS/PAHO", AnoOrigin = "2015",
                    ReferenciaBibliografica = "WHO. Tracking Universal Health Coverage. Geneva, 2017.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma das coberturas de serviços (%)", Simbolo = "sum_cob", Unidade = "%", ValorPadrao = 600 },
                        new Variavel { Nome = "Número de serviços avaliados (N)", Simbolo = "N_serv", Unidade = "", ValorPadrao = 8, ValorMin = 1 }
                    },
                    Calcular = v => v["sum_cob"] / v["N_serv"],
                    VariavelResultado = "ICAP", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6118", Nome = "Eficácia Vacinal (Método de Coorte)",
                    Categoria = "Saúde Pública", SubCategoria = "Imunização",
                    Expressao = "EV = (1 − RR) × 100",
                    Descricao = "Eficácia vacinal calculada pela razão de riscos entre vacinados e não-vacinados; EV>90% excelente.",
                    Criador = "Greenwood M", AnoOrigin = "1915",
                    ReferenciaBibliografica = "Orenstein WA et al. Bull World Health Organ, 1988.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Risco nos vacinados (IC_vac)", Simbolo = "IC_vac", Unidade = "fração", ValorPadrao = 0.02, ValorMin = 0 },
                        new Variavel { Nome = "Risco nos não-vacinados (IC_nvac)", Simbolo = "IC_nvac", Unidade = "fração", ValorPadrao = 0.20, ValorMin = 0.001 }
                    },
                    Calcular = v => (1 - v["IC_vac"] / v["IC_nvac"]) * 100,
                    VariavelResultado = "EV", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6119", Nome = "Potencial de Redução de Risco (Avoidable Burden)",
                    Categoria = "Saúde Pública", SubCategoria = "Carga de Doença",
                    Expressao = "Carga_evitável = FAP × DALYs_totais",
                    Descricao = "Fração da carga total de doença que poderia ser evitada eliminando um fator de risco (via fração atribuível populacional).",
                    Criador = "Murray CJL / Ezzati M", AnoOrigin = "2002",
                    ReferenciaBibliografica = "Ezzati M et al. Lancet, 2002.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Fração atribuível ao fator (FAP)", Simbolo = "FAP", Unidade = "fração", ValorPadrao = 0.15, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "DALYs totais da doença", Simbolo = "DALYs", Unidade = "anos", ValorPadrao = 100000 }
                    },
                    Calcular = v => v["FAP"] * v["DALYs"],
                    VariavelResultado = "Carga evitável", UnidadeResultado = "DALYs evitáveis"
                },
                new Formula
                {
                    Id = "C6120", Nome = "Índice de Necessidade de Saúde (INS)",
                    Categoria = "Saúde Pública", SubCategoria = "Equidade em Saúde",
                    Expressao = "INS = (mortalidade_prematura × w1 + morbidade × w2) / pop",
                    Descricao = "Estimativa de necessidade de saúde de população por combinação ponderada de mortalidade prematura e morbidade.",
                    Criador = "Prática de planejamento em saúde", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Navarro V. Med Care, 1978.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Mortalidade prematura (AVP)", Simbolo = "mort_prem", Unidade = "AVP", ValorPadrao = 5000 },
                        new Variavel { Nome = "Peso mortalidade (w1)", Simbolo = "w1", Unidade = "", ValorPadrao = 0.6 },
                        new Variavel { Nome = "Morbidade (anos doença)", Simbolo = "morbidade", Unidade = "anos", ValorPadrao = 10000 },
                        new Variavel { Nome = "Peso morbidade (w2)", Simbolo = "w2", Unidade = "", ValorPadrao = 0.4 },
                        new Variavel { Nome = "População", Simbolo = "pop", Unidade = "pessoas", ValorPadrao = 100000, ValorMin = 1 }
                    },
                    Calcular = v => (v["mort_prem"]*v["w1"] + v["morbidade"]*v["w2"]) / v["pop"],
                    VariavelResultado = "INS", UnidadeResultado = "anos/pessoa"
                },
                new Formula
                {
                    Id = "C6121", Nome = "Coeficiente de Mortalidade por Causas Específicas",
                    Categoria = "Saúde Pública", SubCategoria = "Indicadores de Saúde",
                    Expressao = "CME = (óbitos_causa_específica / pop) × 100.000",
                    Descricao = "Taxa de mortalidade por causa específica por 100.000 habitantes; base para vigilância epidemiológica.",
                    Criador = "Farr W", AnoOrigin = "1841",
                    ReferenciaBibliografica = "Last JM. A Dictionary of Epidemiology, 4ª ed. Oxford, 2001.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Óbitos por causa específica", Simbolo = "obitos_ce", Unidade = "óbitos", ValorPadrao = 200 },
                        new Variavel { Nome = "População", Simbolo = "pop", Unidade = "pessoas", ValorPadrao = 500000, ValorMin = 1 }
                    },
                    Calcular = v => v["obitos_ce"] / v["pop"] * 100000,
                    VariavelResultado = "CME", UnidadeResultado = "por 100.000 hab."
                },
                new Formula
                {
                    Id = "C6122", Nome = "Anos de Vida Perdidos Prematuramente — Limite de 70 Anos",
                    Categoria = "Saúde Pública", SubCategoria = "Carga de Doença",
                    Expressao = "PYLL = Σ (70 − idade_morte) por óbito antes dos 70 anos",
                    Descricao = "Anos potenciais de vida perdidos antes dos 70 anos; indicador de mortalidade prematura evitável.",
                    Criador = "Romeder JM, McWhinnie JR", AnoOrigin = "1977",
                    ReferenciaBibliografica = "Romeder JM, McWhinnie JR. Int J Epidemiol, 1977.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Idade ao óbito (anos)", Simbolo = "idade_obito", Unidade = "anos", ValorPadrao = 45, ValorMin = 0, ValorMax = 69 },
                        new Variavel { Nome = "Número de óbitos nessa idade", Simbolo = "n_obitos", Unidade = "óbitos", ValorPadrao = 10 }
                    },
                    Calcular = v => (70 - v["idade_obito"]) * v["n_obitos"],
                    VariavelResultado = "PYLL", UnidadeResultado = "anos"
                },
                new Formula
                {
                    Id = "C6123", Nome = "Taxa de Internação Hospitalar",
                    Categoria = "Saúde Pública", SubCategoria = "Sistemas de Saúde",
                    Expressao = "TIH = (internações / pop) × 10.000",
                    Descricao = "Número de internações hospitalares por 10.000 habitantes; indicador de utilização de serviços de saúde.",
                    Criador = "Prática de planejamento em saúde", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "DATASUS / Ministério da Saúde.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Internações no período", Simbolo = "internacoes", Unidade = "internações", ValorPadrao = 3000 },
                        new Variavel { Nome = "População", Simbolo = "pop", Unidade = "pessoas", ValorPadrao = 100000, ValorMin = 1 }
                    },
                    Calcular = v => v["internacoes"] / v["pop"] * 10000,
                    VariavelResultado = "TIH", UnidadeResultado = "por 10.000 hab."
                },
                new Formula
                {
                    Id = "C6124", Nome = "Score de Alerta Precoce Nacional (NEWS-2)",
                    Categoria = "Saúde Pública", SubCategoria = "Saúde Pública Clínica",
                    Expressao = "NEWS-2 = Σ pontos dos 7 parâmetros fisiológicos",
                    Descricao = "Escore de deterioração clínica (frequência respiratória, saturação O2, temperatura, PA, FC, consciência, O2 suplementar).",
                    Criador = "Royal College of Physicians", AnoOrigin = "2012",
                    ReferenciaBibliografica = "Royal College of Physicians. National Early Warning Score (NEWS) 2. London, 2017.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma dos pontos dos 7 parâmetros", Simbolo = "sum_pontos", Unidade = "pts", ValorPadrao = 3, ValorMin = 0 }
                    },
                    Calcular = v => v["sum_pontos"],
                    VariavelResultado = "NEWS-2", UnidadeResultado = "pontos"
                },
                new Formula
                {
                    Id = "C6125", Nome = "Índice de Gini de Renda e Saúde",
                    Categoria = "Saúde Pública", SubCategoria = "Determinantes Sociais",
                    Expressao = "Gini = A / (A + B)  [curva de Lorenz]",
                    Descricao = "Coeficiente de Gini de desigualdade; G=0 (igualdade perfeita), G=1 (desigualdade máxima); influencia resultados de saúde.",
                    Criador = "Gini C", AnoOrigin = "1912",
                    ReferenciaBibliografica = "Gini C. Variabilità e mutabilità. Bologna, 1912.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Área entre linha de igualdade e curva de Lorenz (A)", Simbolo = "A", Unidade = "unid.", ValorPadrao = 0.35, ValorMin = 0 },
                        new Variavel { Nome = "Área abaixo da curva de Lorenz (B)", Simbolo = "B", Unidade = "unid.", ValorPadrao = 0.15, ValorMin = 0.001 }
                    },
                    Calcular = v => v["A"] / (v["A"] + v["B"]),
                    VariavelResultado = "Gini", UnidadeResultado = "adimensional (0-1)"
                }
            });
        }
    }
}
