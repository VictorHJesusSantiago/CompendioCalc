using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Nutricao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C6001", Nome = "Índice de Massa Corporal (IMC)",
                    Categoria = "Nutrição", SubCategoria = "Avaliação Nutricional",
                    Expressao = "IMC = Peso / Altura²",
                    Descricao = "Índice de triagem de estado nutricional; OMS: <18,5 (magreza), 18,5-24,9 (normal), 25-29,9 (sobrepeso), ≥30 (obesidade).",
                    Criador = "Quetelet LÀJ", AnoOrigin = "1832",
                    ReferenciaBibliografica = "WHO. Obesity: Preventing and Managing the Global Epidemic. Geneva, 2000.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso (kg)", Simbolo = "Peso", Unidade = "kg", ValorPadrao = 70, ValorMin = 0.1 },
                        new Variavel { Nome = "Altura (m)", Simbolo = "Altura", Unidade = "m", ValorPadrao = 1.70, ValorMin = 0.3 }
                    },
                    Calcular = v => v["Peso"] / (v["Altura"] * v["Altura"]),
                    VariavelResultado = "IMC", UnidadeResultado = "kg/m²"
                },
                new Formula
                {
                    Id = "C6002", Nome = "Taxa Metabólica Basal — Equação de Harris-Benedict (revisada)",
                    Categoria = "Nutrição", SubCategoria = "Metabolismo Energético",
                    Expressao = "TMB_h = 88,362 + 13,397P + 4,799A − 5,677I (homens)",
                    Descricao = "Gasto energético basal de homens; equação revisada por Roza & Shizgal (1984), base para cálculo de necessidades calóricas.",
                    Criador = "Harris JA, Benedict FG", AnoOrigin = "1919",
                    ReferenciaBibliografica = "Roza AM, Shizgal HM. Am J Clin Nutr, 1984.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso (kg)", Simbolo = "P", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Altura (cm)", Simbolo = "A", Unidade = "cm", ValorPadrao = 175 },
                        new Variavel { Nome = "Idade (anos)", Simbolo = "I", Unidade = "anos", ValorPadrao = 30 }
                    },
                    Calcular = v => 88.362 + 13.397*v["P"] + 4.799*v["A"] - 5.677*v["I"],
                    VariavelResultado = "TMB (homem)", UnidadeResultado = "kcal/dia"
                },
                new Formula
                {
                    Id = "C6003", Nome = "TMB — Harris-Benedict Mulher (revisada)",
                    Categoria = "Nutrição", SubCategoria = "Metabolismo Energético",
                    Expressao = "TMB_m = 447,593 + 9,247P + 3,098A − 4,330I",
                    Descricao = "Gasto energético basal de mulheres; equação revisada; multiplicar por fator de atividade para GET.",
                    Criador = "Harris JA, Benedict FG", AnoOrigin = "1919",
                    ReferenciaBibliografica = "Roza AM, Shizgal HM. Am J Clin Nutr, 1984.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso (kg)", Simbolo = "P", Unidade = "kg", ValorPadrao = 60 },
                        new Variavel { Nome = "Altura (cm)", Simbolo = "A", Unidade = "cm", ValorPadrao = 165 },
                        new Variavel { Nome = "Idade (anos)", Simbolo = "I", Unidade = "anos", ValorPadrao = 30 }
                    },
                    Calcular = v => 447.593 + 9.247*v["P"] + 3.098*v["A"] - 4.330*v["I"],
                    VariavelResultado = "TMB (mulher)", UnidadeResultado = "kcal/dia"
                },
                new Formula
                {
                    Id = "C6004", Nome = "Gasto Energético Total (GET)",
                    Categoria = "Nutrição", SubCategoria = "Metabolismo Energético",
                    Expressao = "GET = TMB × NAF",
                    Descricao = "Gasto energético total diário multiplicando TMB pelo Nível de Atividade Física (sedentário 1,2; muito ativo 1,9).",
                    Criador = "FAO/OMS/ONU", AnoOrigin = "1985",
                    ReferenciaBibliografica = "FAO/WHO/UNU. Human Energy Requirements. Rome, 2001.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "TMB (kcal/dia)", Simbolo = "TMB", Unidade = "kcal/dia", ValorPadrao = 1700 },
                        new Variavel { Nome = "Nível de Atividade Física (NAF)", Simbolo = "NAF", Unidade = "", ValorPadrao = 1.55, ValorMin = 1.0 }
                    },
                    Calcular = v => v["TMB"] * v["NAF"],
                    VariavelResultado = "GET", UnidadeResultado = "kcal/dia"
                },
                new Formula
                {
                    Id = "C6005", Nome = "Necessidade Proteica Diária",
                    Categoria = "Nutrição", SubCategoria = "Proteínas",
                    Expressao = "Proteína_g = PC × g_proteína/kg",
                    Descricao = "Ingestão proteica diária recomendada; adultos saudáveis: 0,8-1,0 g/kg; atletas: 1,2-2,0 g/kg.",
                    Criador = "DRI / Institute of Medicine", AnoOrigin = "2002",
                    ReferenciaBibliografica = "IOM. Dietary Reference Intakes for Energy, Carbohydrate... NAP, 2002.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal (kg)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 70, ValorMin = 1 },
                        new Variavel { Nome = "Proteína por kg", Simbolo = "g_prot_kg", Unidade = "g/kg", ValorPadrao = 1.0, ValorMin = 0 }
                    },
                    Calcular = v => v["PC"] * v["g_prot_kg"],
                    VariavelResultado = "Proteína", UnidadeResultado = "g/dia"
                },
                new Formula
                {
                    Id = "C6006", Nome = "Valor Calórico de Macronutrientes (Atwater)",
                    Categoria = "Nutrição", SubCategoria = "Energia Alimentar",
                    Expressao = "Cal = 4 × CHO + 4 × PTN + 9 × LIP",
                    Descricao = "Cálculo de calorias totais por fatores de Atwater: carboidratos e proteínas 4 kcal/g, lipídeos 9 kcal/g.",
                    Criador = "Atwater WO", AnoOrigin = "1887",
                    ReferenciaBibliografica = "Atwater WO, Woods CD. US Dept Agriculture Bulletin, 1896.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Carboidratos (g)", Simbolo = "CHO", Unidade = "g", ValorPadrao = 50, ValorMin = 0 },
                        new Variavel { Nome = "Proteínas (g)", Simbolo = "PTN", Unidade = "g", ValorPadrao = 30, ValorMin = 0 },
                        new Variavel { Nome = "Lipídeos (g)", Simbolo = "LIP", Unidade = "g", ValorPadrao = 15, ValorMin = 0 }
                    },
                    Calcular = v => 4*v["CHO"] + 4*v["PTN"] + 9*v["LIP"],
                    VariavelResultado = "Calorias", UnidadeResultado = "kcal"
                },
                new Formula
                {
                    Id = "C6007", Nome = "Peso Corporal Ideal (Devine)",
                    Categoria = "Nutrição", SubCategoria = "Avaliação Nutricional",
                    Expressao = "PCI_h = 50 + 2,3 × (Altura_in − 60)",
                    Descricao = "Peso ideal para homens pela fórmula de Devine; para mulheres: 45,5 + 2,3 × (polegadas − 60).",
                    Criador = "Devine BJ", AnoOrigin = "1974",
                    ReferenciaBibliografica = "Devine BJ. Drug Intell Clin Pharm, 1974.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Altura (polegadas)", Simbolo = "H_in", Unidade = "in", ValorPadrao = 70, ValorMin = 60 }
                    },
                    Calcular = v => 50 + 2.3 * (v["H_in"] - 60),
                    VariavelResultado = "PCI (homem)", UnidadeResultado = "kg"
                },
                new Formula
                {
                    Id = "C6008", Nome = "Taxa de Filtragem Metabólica — Mifflin-St Jeor (TMB)",
                    Categoria = "Nutrição", SubCategoria = "Metabolismo Energético",
                    Expressao = "TMB = 10P + 6,25A − 5I + s (s=5 H; s=−161 M)",
                    Descricao = "Equação de Mifflin-St Jeor para TMB; considerada mais precisa que Harris-Benedict para populações contemporâneas.",
                    Criador = "Mifflin MD, St Jeor ST", AnoOrigin = "1990",
                    ReferenciaBibliografica = "Mifflin MD et al. Am J Clin Nutr, 1990.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso (kg)", Simbolo = "P", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Altura (cm)", Simbolo = "A", Unidade = "cm", ValorPadrao = 175 },
                        new Variavel { Nome = "Idade (anos)", Simbolo = "I", Unidade = "anos", ValorPadrao = 30 },
                        new Variavel { Nome = "Sexo (5=H, -161=M)", Simbolo = "s", Unidade = "", ValorPadrao = 5 }
                    },
                    Calcular = v => 10*v["P"] + 6.25*v["A"] - 5*v["I"] + v["s"],
                    VariavelResultado = "TMB", UnidadeResultado = "kcal/dia"
                },
                new Formula
                {
                    Id = "C6009", Nome = "Percentual de Gordura Corporal (Equação de Deurenberg)",
                    Categoria = "Nutrição", SubCategoria = "Composição Corporal",
                    Expressao = "%GC = 1,20 × IMC + 0,23 × Idade − 10,8 × Sexo − 5,4",
                    Descricao = "Estimativa do percentual de gordura corporal a partir do IMC, idade e sexo (Sexo: 1=M, 0=F).",
                    Criador = "Deurenberg P et al.", AnoOrigin = "1991",
                    ReferenciaBibliografica = "Deurenberg P et al. Br J Nutr, 1991.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "IMC (kg/m²)", Simbolo = "IMC", Unidade = "kg/m²", ValorPadrao = 25 },
                        new Variavel { Nome = "Idade (anos)", Simbolo = "Idade", Unidade = "anos", ValorPadrao = 35 },
                        new Variavel { Nome = "Sexo (1=M, 0=F)", Simbolo = "Sexo", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => 1.20*v["IMC"] + 0.23*v["Idade"] - 10.8*v["Sexo"] - 5.4,
                    VariavelResultado = "%GC", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6010", Nome = "Razão Cintura-Quadril (RCQ)",
                    Categoria = "Nutrição", SubCategoria = "Avaliação Nutricional",
                    Expressao = "RCQ = Cintura / Quadril",
                    Descricao = "Indicador de distribuição de gordura corporal; homens ≥0,90 e mulheres ≥0,85 indicam risco cardiovascular aumentado.",
                    Criador = "WHO", AnoOrigin = "1995",
                    ReferenciaBibliografica = "WHO. Physical Status: The Use and Interpretation of Anthropometry. Geneva, 1995.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Circunferência da cintura (cm)", Simbolo = "Cintura", Unidade = "cm", ValorPadrao = 88 },
                        new Variavel { Nome = "Circunferência do quadril (cm)", Simbolo = "Quadril", Unidade = "cm", ValorPadrao = 98, ValorMin = 1 }
                    },
                    Calcular = v => v["Cintura"] / v["Quadril"],
                    VariavelResultado = "RCQ", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C6011", Nome = "Densidade Óssea Estimada por Z-Score (DXA)",
                    Categoria = "Nutrição", SubCategoria = "Nutrição e Osso",
                    Expressao = "T-score = (DMO_paciente − DMO_adulto_jovem) / DP",
                    Descricao = "T-score de densitometria óssea; osteopenia: entre -1,0 e -2,5; osteoporose: ≤-2,5 (OMS).",
                    Criador = "Kanis JA / WHO", AnoOrigin = "1994",
                    ReferenciaBibliografica = "WHO. Assessment of Fracture Risk. Geneva, 1994.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "DMO do paciente (g/cm²)", Simbolo = "DMO_pac", Unidade = "g/cm²", ValorPadrao = 0.85 },
                        new Variavel { Nome = "DMO adulto jovem (g/cm²)", Simbolo = "DMO_ref", Unidade = "g/cm²", ValorPadrao = 1.0 },
                        new Variavel { Nome = "DP do adulto jovem (g/cm²)", Simbolo = "DP", Unidade = "g/cm²", ValorPadrao = 0.12, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["DMO_pac"] - v["DMO_ref"]) / v["DP"],
                    VariavelResultado = "T-score", UnidadeResultado = "DP"
                },
                new Formula
                {
                    Id = "C6012", Nome = "Índice Glicêmico × Carga Glicêmica",
                    Categoria = "Nutrição", SubCategoria = "Carboidratos",
                    Expressao = "CG = IG × CHO_disp / 100",
                    Descricao = "Carga glicêmica: produto do IG pelo conteúdo de carboidratos disponíveis por porção; CG<10 baixa, >20 alta.",
                    Criador = "Salmeron J et al.", AnoOrigin = "1997",
                    ReferenciaBibliografica = "Salmeron J et al. JAMA, 1997.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Índice glicêmico (IG)", Simbolo = "IG", Unidade = "", ValorPadrao = 70, ValorMin = 1 },
                        new Variavel { Nome = "CHO disponível por porção (g)", Simbolo = "CHO_disp", Unidade = "g", ValorPadrao = 30, ValorMin = 0 }
                    },
                    Calcular = v => v["IG"] * v["CHO_disp"] / 100,
                    VariavelResultado = "CG", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C6013", Nome = "Velocidade de Esvaziamento Gástrico",
                    Categoria = "Nutrição", SubCategoria = "Fisiologia Digestiva",
                    Expressao = "T_1/2 = 0,693 / k (modelo exponencial)",
                    Descricao = "Meia-vida de esvaziamento gástrico; k = constante de velocidade; normalmente 1-2h para sólidos.",
                    Criador = "Ghoos YF et al.", AnoOrigin = "1993",
                    ReferenciaBibliografica = "Ghoos YF et al. Gastroenterology, 1993.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de velocidade (k)", Simbolo = "k", Unidade = "h⁻¹", ValorPadrao = 0.5, ValorMin = 0.001 }
                    },
                    Calcular = v => 0.693 / v["k"],
                    VariavelResultado = "T½ esvaziamento", UnidadeResultado = "h"
                },
                new Formula
                {
                    Id = "C6014", Nome = "Necessidade Hídrica Diária",
                    Categoria = "Nutrição", SubCategoria = "Hidratação",
                    Expressao = "H2O = 35 mL/kg (adultos); ou: 1 mL/kcal GET",
                    Descricao = "Ingestão hídrica diária recomendada baseada no peso corporal ou no gasto energético.",
                    Criador = "IOM", AnoOrigin = "2004",
                    ReferenciaBibliografica = "IOM. Dietary Reference Intakes for Water, Potassium... NAP, 2004.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal (kg)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "mL por kg", Simbolo = "mL_kg", Unidade = "mL/kg", ValorPadrao = 35, ValorMin = 1 }
                    },
                    Calcular = v => v["PC"] * v["mL_kg"],
                    VariavelResultado = "H2O", UnidadeResultado = "mL/dia"
                },
                new Formula
                {
                    Id = "C6015", Nome = "Índice de Adequação de Micronutriente (% VD)",
                    Categoria = "Nutrição", SubCategoria = "Micronutrientes",
                    Expressao = "% VD = (ingestão / VD) × 100",
                    Descricao = "Percentagem do Valor Diário de Referência de micronutriente atingida pelo consumo; base para rotulagem nutricional.",
                    Criador = "FDA / ANVISA", AnoOrigin = "1994",
                    ReferenciaBibliografica = "ANVISA. RDC 429/2020. Brasil.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Ingestão do nutriente", Simbolo = "ingestao", Unidade = "unid.", ValorPadrao = 800 },
                        new Variavel { Nome = "Valor diário (VD)", Simbolo = "VD", Unidade = "unid.", ValorPadrao = 1000, ValorMin = 0.001 }
                    },
                    Calcular = v => v["ingestao"] / v["VD"] * 100,
                    VariavelResultado = "% VD", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6016", Nome = "Taxa de Catabolismo Proteico (PCR — Protein Catabolic Rate)",
                    Categoria = "Nutrição", SubCategoria = "Nutrição Clínica",
                    Expressao = "nPCR = (6,25 × UN + 4) / PC (g/kg/dia)",
                    Descricao = "Taxa de catabolismo proteico normalizada; UN = ureia nitrogenada urinária; usada em hemodiálise.",
                    Criador = "Borah MF et al.", AnoOrigin = "1978",
                    ReferenciaBibliografica = "Borah MF et al. Kidney Int, 1978.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Ureia nitrogênio urinária 24h (g/dia)", Simbolo = "UN", Unidade = "g/dia", ValorPadrao = 7 },
                        new Variavel { Nome = "Peso corporal (kg)", Simbolo = "PC", Unidade = "kg", ValorPadrao = 70, ValorMin = 1 }
                    },
                    Calcular = v => (6.25 * v["UN"] + 4) / v["PC"],
                    VariavelResultado = "nPCR", UnidadeResultado = "g/kg/dia"
                },
                new Formula
                {
                    Id = "C6017", Nome = "Escore de Triagem Nutricional (NRS-2002 — Pontuação Final)",
                    Categoria = "Nutrição", SubCategoria = "Triagem Nutricional",
                    Expressao = "NRS = escore_doença + escore_nutricional + 1 (se ≥70 anos)",
                    Descricao = "Ferramenta de triagem nutricional hospitalar; NRS≥3 indica risco nutricional e necessidade de intervenção.",
                    Criador = "Kondrup J et al.", AnoOrigin = "2002",
                    ReferenciaBibliografica = "Kondrup J et al. Clin Nutr, 2003.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Escore de doença (0-3)", Simbolo = "E_doenca", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 3 },
                        new Variavel { Nome = "Escore nutricional (0-3)", Simbolo = "E_nutric", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 3 },
                        new Variavel { Nome = "Ajuste por idade ≥70 anos (0 ou 1)", Simbolo = "E_idade", Unidade = "", ValorPadrao = 0, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["E_doenca"] + v["E_nutric"] + v["E_idade"],
                    VariavelResultado = "NRS-2002", UnidadeResultado = "pontos"
                },
                new Formula
                {
                    Id = "C6018", Nome = "Balanço Nitrogenado",
                    Categoria = "Nutrição", SubCategoria = "Metabolismo Proteico",
                    Expressao = "BN = (Proteína_ingerida / 6,25) − (UUN + 4)",
                    Descricao = "Balanço entre nitrogênio ingerido e excretado; BN>0 indica anabolismo, BN<0 catabolismo (UUN = N ureico urinário).",
                    Criador = "Cuthbertson DP", AnoOrigin = "1930",
                    ReferenciaBibliografica = "Blackburn GL et al. JPEN J Parenter Enteral Nutr, 1977.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Proteína ingerida (g/dia)", Simbolo = "Prot_ing", Unidade = "g/dia", ValorPadrao = 80 },
                        new Variavel { Nome = "Ureia nitrogenada urinária (g/dia)", Simbolo = "UUN", Unidade = "g/dia", ValorPadrao = 10 }
                    },
                    Calcular = v => (v["Prot_ing"] / 6.25) - (v["UUN"] + 4),
                    VariavelResultado = "BN", UnidadeResultado = "g N/dia"
                },
                new Formula
                {
                    Id = "C6019", Nome = "Percentual de Perda de Peso Involuntária",
                    Categoria = "Nutrição", SubCategoria = "Avaliação Nutricional",
                    Expressao = "%PP = [(PC_usual − PC_atual) / PC_usual] × 100",
                    Descricao = "Grau de perda de peso; >5% em 1 mês ou >10% em 6 meses são clinicamente significativos.",
                    Criador = "Blackburn GL", AnoOrigin = "1977",
                    ReferenciaBibliografica = "Blackburn GL et al. JPEN J Parenter Enteral Nutr, 1977.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso usual (kg)", Simbolo = "PC_usual", Unidade = "kg", ValorPadrao = 75, ValorMin = 0.1 },
                        new Variavel { Nome = "Peso atual (kg)", Simbolo = "PC_atual", Unidade = "kg", ValorPadrao = 68 }
                    },
                    Calcular = v => (v["PC_usual"] - v["PC_atual"]) / v["PC_usual"] * 100,
                    VariavelResultado = "%PP", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6020", Nome = "Circunferência Muscular do Braço (CMB)",
                    Categoria = "Nutrição", SubCategoria = "Avaliação Nutricional Antropométrica",
                    Expressao = "CMB = CB − (π × DCT)",
                    Descricao = "Estimativa de massa muscular do braço; CB = circunferência do braço; DCT = dobra cutânea tricipital.",
                    Criador = "Frisancho AR", AnoOrigin = "1981",
                    ReferenciaBibliografica = "Frisancho AR. Am J Clin Nutr, 1981.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Circunferência do braço (cm)", Simbolo = "CB", Unidade = "cm", ValorPadrao = 28 },
                        new Variavel { Nome = "Dobra cutânea tricipital (cm)", Simbolo = "DCT", Unidade = "cm", ValorPadrao = 1.5, ValorMin = 0 }
                    },
                    Calcular = v => v["CB"] - Math.PI * v["DCT"],
                    VariavelResultado = "CMB", UnidadeResultado = "cm"
                },
                new Formula
                {
                    Id = "C6021", Nome = "Estimativa de Peso por Dobras Cutâneas (Durnin & Womersley)",
                    Categoria = "Nutrição", SubCategoria = "Composição Corporal",
                    Expressao = "D = c − m × log(Σ4dobras)  →  %GC = (4,95/D − 4,50) × 100",
                    Descricao = "Equação de Durnin-Womersley para estimativa de densidade corporal por 4 dobras (bíceps, tríceps, subescapular, supra-ilíaca).",
                    Criador = "Durnin JVGA, Womersley J", AnoOrigin = "1974",
                    ReferenciaBibliografica = "Durnin JVGA, Womersley J. Br J Nutr, 1974.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma das 4 dobras (mm)", Simbolo = "SD4", Unidade = "mm", ValorPadrao = 60, ValorMin = 1 },
                        new Variavel { Nome = "Constante c (homem 17-29: 1,1631)", Simbolo = "c", Unidade = "", ValorPadrao = 1.1631 },
                        new Variavel { Nome = "Constante m (homem 17-29: 0,0632)", Simbolo = "m", Unidade = "", ValorPadrao = 0.0632 }
                    },
                    Calcular = v => { double D = v["c"] - v["m"]*Math.Log10(v["SD4"]); return (4.95/D - 4.50)*100; },
                    VariavelResultado = "%GC", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C6022", Nome = "Recomendação de Fibra Alimentar",
                    Categoria = "Nutrição", SubCategoria = "Fibras",
                    Expressao = "Fibra_g = 14 × (GET_kcal / 1000)",
                    Descricao = "Meta de fibra alimentar baseada no GET; 14g por 1000 kcal consumidas (DRI 2002).",
                    Criador = "IOM", AnoOrigin = "2002",
                    ReferenciaBibliografica = "IOM. Dietary Reference Intakes for Energy, Carbohydrate... NAP, 2002.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Gasto energético total (kcal)", Simbolo = "GET", Unidade = "kcal/dia", ValorPadrao = 2000, ValorMin = 100 }
                    },
                    Calcular = v => 14 * v["GET"] / 1000,
                    VariavelResultado = "Fibra", UnidadeResultado = "g/dia"
                },
                new Formula
                {
                    Id = "C6023", Nome = "Índice de Qualidade da Dieta (HEI-2015, componente simplificado)",
                    Categoria = "Nutrição", SubCategoria = "Qualidade da Dieta",
                    Expressao = "HEI_componente = (ingestao / padrão) × pontuação_max",
                    Descricao = "Pontuação de componente do Healthy Eating Index; ingestão normalizada pelo padrão de referência.",
                    Criador = "USDA / HHS", AnoOrigin = "2015",
                    ReferenciaBibliografica = "Krebs-Smith SM et al. J Acad Nutr Diet, 2018.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Ingestão observada", Simbolo = "ingest", Unidade = "unid.", ValorPadrao = 3 },
                        new Variavel { Nome = "Padrão de referência", Simbolo = "padrao", Unidade = "unid.", ValorPadrao = 5, ValorMin = 0.001 },
                        new Variavel { Nome = "Pontuação máxima do componente", Simbolo = "max_pts", Unidade = "pts", ValorPadrao = 10 }
                    },
                    Calcular = v => Math.Min(v["max_pts"], v["ingest"] / v["padrao"] * v["max_pts"]),
                    VariavelResultado = "Score HEI", UnidadeResultado = "pontos"
                },
                new Formula
                {
                    Id = "C6024", Nome = "Peso Ajustado (Paciente Obeso — Dosagem Nutricional)",
                    Categoria = "Nutrição", SubCategoria = "Nutrição Clínica",
                    Expressao = "PA = PCI + 0,25 × (PC_atual − PCI)",
                    Descricao = "Peso ajustado para pacientes obesos; usado para calcular necessidades nutricionais e dosagem de medicamentos.",
                    Criador = "Saltzman E, Mason JB", AnoOrigin = "1995",
                    ReferenciaBibliografica = "Malone A. Nutr Clin Pract, 2003.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal ideal (PCI)", Simbolo = "PCI", Unidade = "kg", ValorPadrao = 60 },
                        new Variavel { Nome = "Peso corporal atual (PC)", Simbolo = "PC_atual", Unidade = "kg", ValorPadrao = 90 }
                    },
                    Calcular = v => v["PCI"] + 0.25 * (v["PC_atual"] - v["PCI"]),
                    VariavelResultado = "PA", UnidadeResultado = "kg"
                },
                new Formula
                {
                    Id = "C6025", Nome = "Estimativa de Altura por Altura do Joelho",
                    Categoria = "Nutrição", SubCategoria = "Avaliação Nutricional Antropométrica",
                    Expressao = "Altura_H = 64,19 − 0,04 × Idade + 2,02 × AJ",
                    Descricao = "Estimativa de estatura de homens a partir da altura do joelho; útil em idosos acamados (Chumlea).",
                    Criador = "Chumlea WC et al.", AnoOrigin = "1985",
                    ReferenciaBibliografica = "Chumlea WC et al. J Am Diet Assoc, 1985.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Idade (anos)", Simbolo = "Idade", Unidade = "anos", ValorPadrao = 65 },
                        new Variavel { Nome = "Altura do joelho (cm)", Simbolo = "AJ", Unidade = "cm", ValorPadrao = 54 }
                    },
                    Calcular = v => 64.19 - 0.04*v["Idade"] + 2.02*v["AJ"],
                    VariavelResultado = "Altura estimada (H)", UnidadeResultado = "cm"
                }
            });
        }
    }
}
