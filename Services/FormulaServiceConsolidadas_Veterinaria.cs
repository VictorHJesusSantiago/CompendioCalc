using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Veterinaria()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5701", Nome = "Dose Veterinária por Peso (Alométrica)",
                    Categoria = "Veterinária", SubCategoria = "Farmacologia Veterinária",
                    Expressao = "D = d × PC^0,75",
                    Descricao = "Dose alométrica baseada no peso metabólico (PC^0,75); usada para extrapolar doses entre espécies.",
                    Criador = "Kleiber M", AnoOrigin = "1932",
                    ReferenciaBibliografica = "Kleiber M. Hilgardia, 1932.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Dose por kg^0,75 (d)", Simbolo = "d", Unidade = "mg/kg^0,75", ValorPadrao = 2 },
                        new Variavel { Nome = "Peso corporal (PC)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 30, ValorMin = 0.001 }
                    },
                    Calcular = v => v["d"] * Math.Pow(v["PC"], 0.75),
                    VariavelResultado = "D", UnidadeResultado = "mg"
                },
                new Formula
                {
                    Id = "C5702", Nome = "Taxa Metabólica Basal (Kleiber)",
                    Categoria = "Veterinária", SubCategoria = "Fisiologia Animal",
                    Expressao = "TMB = 70 × PC^0,75",
                    Descricao = "Metabolismo basal em animais em função do peso vivo; lei metabólica de Kleiber universal entre mamíferos.",
                    Criador = "Kleiber M", AnoOrigin = "1932",
                    ReferenciaBibliografica = "Kleiber M. Hilgardia, 1932.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal (PC)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 30, ValorMin = 0.001 }
                    },
                    Calcular = v => 70 * Math.Pow(v["PC"], 0.75),
                    VariavelResultado = "TMB", UnidadeResultado = "kcal/dia"
                },
                new Formula
                {
                    Id = "C5703", Nome = "Necessidade Hídrica de Manutenção (Cão/Gato)",
                    Categoria = "Veterinária", SubCategoria = "Clínica de Pequenos Animais",
                    Expressao = "Vol = 50 × PC + 500 (cão); 30 × PC + 70 (gato)",
                    Descricao = "Volume hídrico de manutenção diária para cão (>2 kg) e gato baseado no peso corporal.",
                    Criador = "DiBartola SP", AnoOrigin = "2012",
                    ReferenciaBibliografica = "DiBartola SP. Fluid, Electrolyte, and Acid-Base Disorders in Small Animal Practice, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal (PC)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 10, ValorMin = 0.5 }
                    },
                    Calcular = v => 50 * v["PC"] + 500,
                    VariavelResultado = "Vol (cão)", UnidadeResultado = "mL/dia"
                },
                new Formula
                {
                    Id = "C5704", Nome = "Escore de Condição Corporal (BCS) — Estimativa de Peso Ideal",
                    Categoria = "Veterinária", SubCategoria = "Nutrição Animal",
                    Expressao = "PC_ideal = PC_atual / (1 + 0,05 × (BCS − BCS_ideal))",
                    Descricao = "Estimativa de peso corporal ideal ajustado pelo escore de condição corporal (escala 1-9).",
                    Criador = "Laflamme D", AnoOrigin = "1997",
                    ReferenciaBibliografica = "Laflamme D. Compend Contin Educ Pract Vet, 1997.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal atual (PC)", Simbolo = "PC_atual", Unidade = "kg", ValorPadrao = 12 },
                        new Variavel { Nome = "BCS atual (1-9)", Simbolo = "BCS", Unidade = "", ValorPadrao = 7, ValorMin = 1, ValorMax = 9 },
                        new Variavel { Nome = "BCS ideal (geralmente 5)", Simbolo = "BCS_ideal", Unidade = "", ValorPadrao = 5, ValorMin = 1, ValorMax = 9 }
                    },
                    Calcular = v => v["PC_atual"] / (1 + 0.05 * (v["BCS"] - v["BCS_ideal"])),
                    VariavelResultado = "PC_ideal", UnidadeResultado = "kg"
                },
                new Formula
                {
                    Id = "C5705", Nome = "Necessidade Calórica em Repouso (RER)",
                    Categoria = "Veterinária", SubCategoria = "Nutrição Animal",
                    Expressao = "RER = 70 × PC^0,75",
                    Descricao = "Necessidade energética em repouso para cões e gatos; multiplicada por fator de atividade/doença (1,0–2,5) para NEM.",
                    Criador = "National Research Council", AnoOrigin = "2006",
                    ReferenciaBibliografica = "NRC. Nutrient Requirements of Dogs and Cats. NAP, 2006.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso metabólico (PC)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 20, ValorMin = 0.1 }
                    },
                    Calcular = v => 70 * Math.Pow(v["PC"], 0.75),
                    VariavelResultado = "RER", UnidadeResultado = "kcal/dia"
                },
                new Formula
                {
                    Id = "C5706", Nome = "Taxa de Glomerular Filtração Estimada (eGFR) — SDMA",
                    Categoria = "Veterinária", SubCategoria = "Nefrologia Veterinária",
                    Expressao = "SDMA correlaciona: cada 1 μg/dL acima do normal = ~1 mL/min/kg de perda de TFG",
                    Descricao = "SDMA (dimetil-arginina simétrica) é biomarcador renal em cães e gatos; detecta doença renal mais precocemente que creatinina.",
                    Criador = "Relford R et al.", AnoOrigin = "2016",
                    ReferenciaBibliografica = "Relford R et al. Vet Clin North Am Small Anim Pract, 2016.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "SDMA (μg/dL)", Simbolo = "SDMA", Unidade = "μg/dL", ValorPadrao = 14, ValorMin = 0 },
                        new Variavel { Nome = "Limite superior normal (μg/dL)", Simbolo = "SDMA_normal", Unidade = "μg/dL", ValorPadrao = 14, ValorMin = 0 }
                    },
                    Calcular = v => Math.Max(0, v["SDMA"] - v["SDMA_normal"]),
                    VariavelResultado = "Excesso SDMA", UnidadeResultado = "μg/dL"
                },
                new Formula
                {
                    Id = "C5707", Nome = "Pressão Oncótica do Plasma (Proteínas Totais)",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Emergência Veterinária",
                    Expressao = "COP ≈ 2,1 × PT + 0,16 × PT² + 0,009 × PT³",
                    Descricao = "Pressão oncótica coloidal estimada pelas proteínas totais plasmáticas em cães (Cockroft).",
                    Criador = "Landis EM / Pappenheimer JR", AnoOrigin = "1963",
                    ReferenciaBibliografica = "Haskins SC. Vet Clin North Am Small Anim Pract, 1992.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Proteínas totais (PT)", Simbolo = "PT", Unidade = "g/dL", ValorPadrao = 6.5, ValorMin = 0.1 }
                    },
                    Calcular = v => 2.1*v["PT"] + 0.16*v["PT"]*v["PT"] + 0.009*v["PT"]*v["PT"]*v["PT"],
                    VariavelResultado = "COP", UnidadeResultado = "mmHg"
                },
                new Formula
                {
                    Id = "C5708", Nome = "Dose de Reposição de Fluidos (Déficit Hídrico)",
                    Categoria = "Veterinária", SubCategoria = "Clínica de Pequenos Animais",
                    Expressao = "V_déficit = PC × (%desidratação / 100) × 1000",
                    Descricao = "Volume de fluido a repor em animal desidratado; desidratação estimada clinicamente (5-15% do PC).",
                    Criador = "DiBartola SP", AnoOrigin = "2012",
                    ReferenciaBibliografica = "DiBartola SP. Fluid, Electrolyte, and Acid-Base Disorders, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal (PC)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 10, ValorMin = 0.1 },
                        new Variavel { Nome = "Grau de desidratação (%)", Simbolo = "desid", Unidade = "%", ValorPadrao = 8, ValorMin = 0, ValorMax = 15 }
                    },
                    Calcular = v => v["PC"] * (v["desid"] / 100) * 1000,
                    VariavelResultado = "V_déficit", UnidadeResultado = "mL"
                },
                new Formula
                {
                    Id = "C5709", Nome = "Velocidade de Infusão de Fluidos (Taxa CRI)",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Emergência Veterinária",
                    Expressao = "Taxa = Dose × PC × 1000 / (Concentração × 60)",
                    Descricao = "Taxa de infusão contínua (CRI) de fármaco ou fluido em mL/h; padrão em terapia intensiva veterinária.",
                    Criador = "Prática clínica veterinária", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Plumb DC. Veterinary Drug Handbook, 9ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Dose (μg/kg/min)", Simbolo = "Dose", Unidade = "μg/kg/min", ValorPadrao = 5 },
                        new Variavel { Nome = "Peso corporal (PC)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 10, ValorMin = 0.1 },
                        new Variavel { Nome = "Concentração do fármaco (μg/mL)", Simbolo = "Conc", Unidade = "μg/mL", ValorPadrao = 50, ValorMin = 0.001 }
                    },
                    Calcular = v => v["Dose"] * v["PC"] * 60 / v["Conc"],
                    VariavelResultado = "Taxa", UnidadeResultado = "mL/h"
                },
                new Formula
                {
                    Id = "C5710", Nome = "Osmolaridade Plasmática Veterinária",
                    Categoria = "Veterinária", SubCategoria = "Nefrologia Veterinária",
                    Expressao = "Osm = 2 × Na + (Glicose/18) + (BUN/2,8)",
                    Descricao = "Estimativa da osmolaridade plasmática; hiperosmolaridade (>330 mOsm/kg) indica desidratação hipertônica.",
                    Criador = "Edelman IS et al.", AnoOrigin = "1958",
                    ReferenciaBibliografica = "DiBartola SP. Fluid, Electrolyte, and Acid-Base Disorders, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Sódio sérico (Na)", Simbolo = "Na", Unidade = "mEq/L", ValorPadrao = 145 },
                        new Variavel { Nome = "Glicose (mg/dL)", Simbolo = "Glicose", Unidade = "mg/dL", ValorPadrao = 90 },
                        new Variavel { Nome = "Ureia (BUN, mg/dL)", Simbolo = "BUN", Unidade = "mg/dL", ValorPadrao = 20 }
                    },
                    Calcular = v => 2*v["Na"] + v["Glicose"]/18 + v["BUN"]/2.8,
                    VariavelResultado = "Osm", UnidadeResultado = "mOsm/kg"
                },
                new Formula
                {
                    Id = "C5711", Nome = "Produção Leiteira Ajustada (305 dias)",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Bovinos",
                    Expressao = "Produção_305 = produção_parcial × fator_ajuste",
                    Descricao = "Ajusta produção de leite para base padronizada de 305 dias, duas ordenhas, vaca adulta; para comparação genética.",
                    Criador = "USDA/DHIA", AnoOrigin = "1930",
                    ReferenciaBibliografica = "Wiggans GR. J Dairy Sci, 1986.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Produção parcial (dias n)", Simbolo = "prod_parcial", Unidade = "kg", ValorPadrao = 4000 },
                        new Variavel { Nome = "Fator de ajuste", Simbolo = "fator", Unidade = "", ValorPadrao = 1.05, ValorMin = 0.5 }
                    },
                    Calcular = v => v["prod_parcial"] * v["fator"],
                    VariavelResultado = "Produção_305", UnidadeResultado = "kg"
                },
                new Formula
                {
                    Id = "C5712", Nome = "Índice de Desconforto Térmico para Bovinos (THI)",
                    Categoria = "Veterinária", SubCategoria = "Bem-Estar Animal",
                    Expressao = "THI = Tbs − (0,31 − 0,31 × UR/100) × (Tbs − 14,4)",
                    Descricao = "Índice temperatura-umidade para bovinos; THI>72 reduz produção, THI>80 causa estresse térmico grave.",
                    Criador = "Thom EC", AnoOrigin = "1958",
                    ReferenciaBibliografica = "Thom EC. Weather Bur, 1958.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura de bulbo seco (Tbs)", Simbolo = "Tbs", Unidade = "°C", ValorPadrao = 28 },
                        new Variavel { Nome = "Umidade relativa (UR)", Simbolo = "UR", Unidade = "%", ValorPadrao = 70, ValorMin = 0, ValorMax = 100 }
                    },
                    Calcular = v => v["Tbs"] - (0.31 - 0.31*v["UR"]/100)*(v["Tbs"] - 14.4),
                    VariavelResultado = "THI", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5713", Nome = "Filtração Glomerular Estimada em Cão (Creatinina)",
                    Categoria = "Veterinária", SubCategoria = "Nefrologia Veterinária",
                    Expressao = "TFG ≈ 90 × (1,73 / Creatinina_sérica) (aproximação canina)",
                    Descricao = "Estimativa simplificada da taxa de filtração glomerular em cão baseada na creatinina sérica.",
                    Criador = "Heiene R, Moe L", AnoOrigin = "1998",
                    ReferenciaBibliografica = "Heiene R, Moe L. J Vet Intern Med, 1998.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Creatinina sérica (mg/dL)", Simbolo = "Cr", Unidade = "mg/dL", ValorPadrao = 1.0, ValorMin = 0.1 }
                    },
                    Calcular = v => 90 * (1.73 / v["Cr"]),
                    VariavelResultado = "TFG (aprox.)", UnidadeResultado = "mL/min/1,73m²"
                },
                new Formula
                {
                    Id = "C5714", Nome = "Estimativa de Idade Dentária — Bovinos",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Bovinos",
                    Expressao = "Idade ≈ 2 × n_pares_permanentes (anos) + 1,5",
                    Descricao = "Estimativa de idade de bovinos pela erupção de dentes incisivos permanentes (pares de 0 a 4).",
                    Criador = "Prática veterinária", AnoOrigin = "séc. XIX",
                    ReferenciaBibliografica = "Radostits OM et al. Veterinary Medicine, 10ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Pares de incisivos permanentes (0-4)", Simbolo = "n_pares", Unidade = "pares", ValorPadrao = 2, ValorMin = 0, ValorMax = 4 }
                    },
                    Calcular = v => 2 * v["n_pares"] + 1.5,
                    VariavelResultado = "Idade aprox.", UnidadeResultado = "anos"
                },
                new Formula
                {
                    Id = "C5715", Nome = "Volume Globular (Hematócrito)",
                    Categoria = "Veterinária", SubCategoria = "Hematologia Veterinária",
                    Expressao = "VG = (Hb × 3)",
                    Descricao = "Estimativa do volume globular (hematócrito) a partir da hemoglobina; regra dos 3 para triagem hematológica.",
                    Criador = "Prática clínica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Thrall MA et al. Veterinary Hematology and Clinical Chemistry, 2ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Hemoglobina (Hb)", Simbolo = "Hb", Unidade = "g/dL", ValorPadrao = 14, ValorMin = 0 }
                    },
                    Calcular = v => v["Hb"] * 3,
                    VariavelResultado = "VG estimado", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5716", Nome = "Cálculo de Anion Gap Veterinário",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Emergência Veterinária",
                    Expressao = "AG = (Na + K) − (Cl + HCO3)",
                    Descricao = "Ânion gap plasmático; valor elevado indica acidose metabólica de alta brecha; normal cão: 12–24 mEq/L.",
                    Criador = "Emmett M, Narins RG", AnoOrigin = "1977",
                    ReferenciaBibliografica = "DiBartola SP. Fluid, Electrolyte, and Acid-Base Disorders, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Sódio (Na)", Simbolo = "Na", Unidade = "mEq/L", ValorPadrao = 145 },
                        new Variavel { Nome = "Potássio (K)", Simbolo = "K", Unidade = "mEq/L", ValorPadrao = 4.5 },
                        new Variavel { Nome = "Cloro (Cl)", Simbolo = "Cl", Unidade = "mEq/L", ValorPadrao = 110 },
                        new Variavel { Nome = "Bicarbonato (HCO3)", Simbolo = "HCO3", Unidade = "mEq/L", ValorPadrao = 20 }
                    },
                    Calcular = v => (v["Na"] + v["K"]) - (v["Cl"] + v["HCO3"]),
                    VariavelResultado = "AG", UnidadeResultado = "mEq/L"
                },
                new Formula
                {
                    Id = "C5717", Nome = "Dose de Anestésico Inalatório (CAM)",
                    Categoria = "Veterinária", SubCategoria = "Anestesiologia Veterinária",
                    Expressao = "CAM = concentração alveolar mínima (espécie-específica)",
                    Descricao = "CAM é a concentração alveolar mínima de anestésico que impede movimento em 50% dos pacientes; isoflurano cão ≈ 1,28%.",
                    Criador = "Eger EI", AnoOrigin = "1963",
                    ReferenciaBibliografica = "Eger EI et al. Anesthesiology, 1965.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "CAM da espécie (%)", Simbolo = "CAM", Unidade = "%", ValorPadrao = 1.28 },
                        new Variavel { Nome = "Múltiplo de CAM desejado", Simbolo = "mult", Unidade = "", ValorPadrao = 1.5, ValorMin = 0.1 }
                    },
                    Calcular = v => v["CAM"] * v["mult"],
                    VariavelResultado = "Concentração alvo", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5718", Nome = "Diagnóstico Genético — Frequência Alélica (Hardy-Weinberg em Populações Animais)",
                    Categoria = "Veterinária", SubCategoria = "Genética Veterinária",
                    Expressao = "p² + 2pq + q² = 1",
                    Descricao = "Equilíbrio de Hardy-Weinberg; prevalência de genótipos AA (p²), Aa (2pq), aa (q²) em população panmítica.",
                    Criador = "Hardy GH / Weinberg W", AnoOrigin = "1908",
                    ReferenciaBibliografica = "Hardy GH. Science, 1908; Weinberg W. Jahreshefte Ver Vaterl Naturkd, 1908.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência alelo A (p)", Simbolo = "p", Unidade = "", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => 2 * v["p"] * (1 - v["p"]),
                    VariavelResultado = "Freq. heterozigotos (2pq)", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5719", Nome = "Tamanho de Turma de Vacinação (Rebanho)",
                    Categoria = "Veterinária", SubCategoria = "Epidemiologia Veterinária",
                    Expressao = "Cobertura_necessária = 1 − (1/R0)",
                    Descricao = "Cobertura vacinal mínima para imunidade de rebanho; R0 = número básico de reprodução da doença.",
                    Criador = "Kermack WO, McKendrick AG", AnoOrigin = "1927",
                    ReferenciaBibliografica = "Anderson RM, May RM. Infectious Diseases of Humans. Oxford, 1991.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número básico de reprodução (R0)", Simbolo = "R0", Unidade = "", ValorPadrao = 5, ValorMin = 1.001 }
                    },
                    Calcular = v => (1 - 1.0/v["R0"]) * 100,
                    VariavelResultado = "Cobertura", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5720", Nome = "Ganho de Peso Médio Diário (GMPD)",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Produção",
                    Expressao = "GMPD = (Peso_final − Peso_inicial) / n_dias",
                    Descricao = "Indicador de desempenho zootécnico; avalia eficiência de crescimento de bovinos, suínos e aves.",
                    Criador = "Prática zootécnica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Radostits OM et al. Veterinary Medicine, 10ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso final (kg)", Simbolo = "Peso_final", Unidade = "kg", ValorPadrao = 400 },
                        new Variavel { Nome = "Peso inicial (kg)", Simbolo = "Peso_inicial", Unidade = "kg", ValorPadrao = 250 },
                        new Variavel { Nome = "Número de dias", Simbolo = "n_dias", Unidade = "dias", ValorPadrao = 120, ValorMin = 1 }
                    },
                    Calcular = v => (v["Peso_final"] - v["Peso_inicial"]) / v["n_dias"],
                    VariavelResultado = "GMPD", UnidadeResultado = "kg/dia"
                },
                new Formula
                {
                    Id = "C5721", Nome = "Conversão Alimentar (CA)",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Produção",
                    Expressao = "CA = Alimento_consumido / Ganho_de_peso",
                    Descricao = "Quantidade de alimento necessária para cada kg de ganho de peso; indicador de eficiência produtiva.",
                    Criador = "Prática zootécnica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Rostagno HS et al. Tabelas Brasileiras para Aves e Suínos, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Alimento consumido (kg)", Simbolo = "alim", Unidade = "kg", ValorPadrao = 600 },
                        new Variavel { Nome = "Ganho de peso (kg)", Simbolo = "ganho", Unidade = "kg", ValorPadrao = 150, ValorMin = 0.001 }
                    },
                    Calcular = v => v["alim"] / v["ganho"],
                    VariavelResultado = "CA", UnidadeResultado = "kg alimento/kg ganho"
                },
                new Formula
                {
                    Id = "C5722", Nome = "Eficiência Reprodutiva — Taxa de Concepção ao Primeiro Serviço",
                    Categoria = "Veterinária", SubCategoria = "Reprodução Animal",
                    Expressao = "TC1 = (prenhez_1°serviço / total_servidas) × 100",
                    Descricao = "Indicador de eficiência reprodutiva; valores aceitáveis: bovinos de leite 40-55%, corte 60-70%.",
                    Criador = "Prática de reprodução animal", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Hafez ESE. Reproduction in Farm Animals, 7ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Prenhezes no 1° serviço", Simbolo = "prenhez_1", Unidade = "animais", ValorPadrao = 45 },
                        new Variavel { Nome = "Total servidas", Simbolo = "total", Unidade = "animais", ValorPadrao = 100, ValorMin = 1 }
                    },
                    Calcular = v => v["prenhez_1"] / v["total"] * 100,
                    VariavelResultado = "TC1", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5723", Nome = "Volume de Diluição de Sêmen (Inseminação Artificial)",
                    Categoria = "Veterinária", SubCategoria = "Reprodução Animal",
                    Expressao = "V_diluído = (V_ejaculado × conc_inicial) / conc_desejada",
                    Descricao = "Volume total após diluição de sêmen para concentração alvo em inseminação artificial.",
                    Criador = "Prática de reprodução animal", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Hafez ESE. Reproduction in Farm Animals, 7ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Volume do ejaculado (mL)", Simbolo = "V_ejac", Unidade = "mL", ValorPadrao = 5 },
                        new Variavel { Nome = "Concentração inicial (×10⁶/mL)", Simbolo = "conc_ini", Unidade = "×10⁶/mL", ValorPadrao = 2000 },
                        new Variavel { Nome = "Concentração desejada (×10⁶/mL)", Simbolo = "conc_desej", Unidade = "×10⁶/mL", ValorPadrao = 20, ValorMin = 0.001 }
                    },
                    Calcular = v => v["V_ejac"] * v["conc_ini"] / v["conc_desej"],
                    VariavelResultado = "V_diluído", UnidadeResultado = "mL"
                },
                new Formula
                {
                    Id = "C5724", Nome = "Índice de Mortalidade de Lote (Aves)",
                    Categoria = "Veterinária", SubCategoria = "Medicina de Aves",
                    Expressao = "Mortalidade = (n_mortos / n_inicial) × 100",
                    Descricao = "Percentagem de mortalidade acumulada no lote de aves; alerta para problemas sanitários quando >5%.",
                    Criador = "Prática avícola", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Calnek BW et al. Diseases of Poultry, 11ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de mortos", Simbolo = "mortos", Unidade = "aves", ValorPadrao = 50 },
                        new Variavel { Nome = "Número inicial", Simbolo = "inicial", Unidade = "aves", ValorPadrao = 20000, ValorMin = 1 }
                    },
                    Calcular = v => v["mortos"] / v["inicial"] * 100,
                    VariavelResultado = "Mortalidade", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5725", Nome = "Pressão de Perfusão de Membro (Doppler Veterinário)",
                    Categoria = "Veterinária", SubCategoria = "Cardiologia Veterinária",
                    Expressao = "índice tornozelo-braquial (ITB) = PAS_distal / PAS_proximal",
                    Descricao = "ITB para avaliação de perfusão periférica em cães; <0,9 sugere doença arterial periférica.",
                    Criador = "Yao ST et al.", AnoOrigin = "1969",
                    ReferenciaBibliografica = "Yao ST et al. Surgery, 1969.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "PAS distal (mmHg)", Simbolo = "PAS_distal", Unidade = "mmHg", ValorPadrao = 110 },
                        new Variavel { Nome = "PAS proximal/braquial (mmHg)", Simbolo = "PAS_prox", Unidade = "mmHg", ValorPadrao = 120, ValorMin = 1 }
                    },
                    Calcular = v => v["PAS_distal"] / v["PAS_prox"],
                    VariavelResultado = "ITB", UnidadeResultado = "adimensional"
                }
            });
        }
    }
}
