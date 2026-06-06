using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Farmacia()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C2501", Nome = "Dose por Peso Corporal",
                    Categoria = "Farmácia", SubCategoria = "Farmacologia Clínica",
                    Expressao = "D = PC × d",
                    Descricao = "Dose total calculada a partir do peso corporal e dose-alvo por kg.",
                    Criador = "Prática clínica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Goodman & Gilman's Pharmacological Basis of Therapeutics, 13ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso corporal", Simbolo = "PC", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Dose por kg", Simbolo = "d", Unidade = "mg/kg", ValorPadrao = 2 }
                    },
                    Calcular = v => v["PC"] * v["d"],
                    VariavelResultado = "D", UnidadeResultado = "mg"
                },
                new Formula
                {
                    Id = "C2502", Nome = "Meia-Vida de Eliminação",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "t½ = 0,693 / ke",
                    Descricao = "Tempo necessário para a concentração plasmática reduzir à metade; ke é a constante de eliminação de primeira ordem.",
                    Criador = "Teorema farmacocinético clássico", AnoOrigin = "1930",
                    ReferenciaBibliografica = "Rowland M, Tozer TN. Clinical Pharmacokinetics, 4ª ed. 2011.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de eliminação", Simbolo = "ke", Unidade = "h⁻¹", ValorPadrao = 0.1, ValorMin = 0.001 }
                    },
                    Calcular = v => 0.693 / v["ke"],
                    VariavelResultado = "t½", UnidadeResultado = "h"
                },
                new Formula
                {
                    Id = "C2503", Nome = "Volume de Distribuição",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "Vd = Dose / C0",
                    Descricao = "Volume aparente no qual o fármaco se distribui para atingir a concentração plasmática inicial C0.",
                    Criador = "Teorema farmacocinético", AnoOrigin = "1937",
                    ReferenciaBibliografica = "Shargel L et al. Applied Biopharmaceutics & Pharmacokinetics, 7ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Dose IV", Simbolo = "Dose", Unidade = "mg", ValorPadrao = 100 },
                        new Variavel { Nome = "Concentração inicial", Simbolo = "C0", Unidade = "mg/L", ValorPadrao = 2, ValorMin = 0.001 }
                    },
                    Calcular = v => v["Dose"] / v["C0"],
                    VariavelResultado = "Vd", UnidadeResultado = "L"
                },
                new Formula
                {
                    Id = "C2504", Nome = "Clearance Total",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "CL = ke × Vd",
                    Descricao = "Volume de plasma depurado do fármaco por unidade de tempo.",
                    Criador = "Teorema farmacocinético", AnoOrigin = "1950",
                    ReferenciaBibliografica = "Rowland M, Tozer TN. Clinical Pharmacokinetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de eliminação", Simbolo = "ke", Unidade = "h⁻¹", ValorPadrao = 0.1, ValorMin = 0.001 },
                        new Variavel { Nome = "Volume de distribuição", Simbolo = "Vd", Unidade = "L", ValorPadrao = 50 }
                    },
                    Calcular = v => v["ke"] * v["Vd"],
                    VariavelResultado = "CL", UnidadeResultado = "L/h"
                },
                new Formula
                {
                    Id = "C2505", Nome = "Biodisponibilidade Oral",
                    Categoria = "Farmácia", SubCategoria = "Biofarmácia",
                    Expressao = "F = (AUCoral / AUCiv) × 100",
                    Descricao = "Fração da dose oral que atinge a circulação sistêmica, expressa em porcentagem.",
                    Criador = "Prática farmacológica", AnoOrigin = "1960",
                    ReferenciaBibliografica = "Shargel L et al. Applied Biopharmaceutics & Pharmacokinetics, 7ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "AUC oral", Simbolo = "AUCoral", Unidade = "mg·h/L", ValorPadrao = 80 },
                        new Variavel { Nome = "AUC intravenosa", Simbolo = "AUCiv", Unidade = "mg·h/L", ValorPadrao = 100, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["AUCoral"] / v["AUCiv"]) * 100,
                    VariavelResultado = "F", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C2506", Nome = "Concentração em Estado Estacionário",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "Css = R0 / CL",
                    Descricao = "Concentração plasmática constante durante infusão contínua quando entrada = saída.",
                    Criador = "Sawchuk & Zaske", AnoOrigin = "1976",
                    ReferenciaBibliografica = "Rowland M, Tozer TN. Clinical Pharmacokinetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Taxa de infusão", Simbolo = "R0", Unidade = "mg/h", ValorPadrao = 10 },
                        new Variavel { Nome = "Clearance", Simbolo = "CL", Unidade = "L/h", ValorPadrao = 5, ValorMin = 0.001 }
                    },
                    Calcular = v => v["R0"] / v["CL"],
                    VariavelResultado = "Css", UnidadeResultado = "mg/L"
                },
                new Formula
                {
                    Id = "C2507", Nome = "Dose de Ataque (Loading Dose)",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "LD = Css × Vd",
                    Descricao = "Dose inicial elevada para atingir rapidamente a concentração alvo em estado estacionário.",
                    Criador = "Prática clínica", AnoOrigin = "1970",
                    ReferenciaBibliografica = "Katzung BG. Basic and Clinical Pharmacology, 14ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Concentração alvo (Css)", Simbolo = "Css", Unidade = "mg/L", ValorPadrao = 5 },
                        new Variavel { Nome = "Volume de distribuição", Simbolo = "Vd", Unidade = "L", ValorPadrao = 50 }
                    },
                    Calcular = v => v["Css"] * v["Vd"],
                    VariavelResultado = "LD", UnidadeResultado = "mg"
                },
                new Formula
                {
                    Id = "C2508", Nome = "Dose de Manutenção",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "MD = Css × CL × τ",
                    Descricao = "Dose periódica necessária para manter a concentração plasmática no estado estacionário.",
                    Criador = "Prática clínica", AnoOrigin = "1970",
                    ReferenciaBibliografica = "Rowland M, Tozer TN. Clinical Pharmacokinetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Concentração alvo", Simbolo = "Css", Unidade = "mg/L", ValorPadrao = 5 },
                        new Variavel { Nome = "Clearance", Simbolo = "CL", Unidade = "L/h", ValorPadrao = 5 },
                        new Variavel { Nome = "Intervalo de dose (τ)", Simbolo = "τ", Unidade = "h", ValorPadrao = 8 }
                    },
                    Calcular = v => v["Css"] * v["CL"] * v["τ"],
                    VariavelResultado = "MD", UnidadeResultado = "mg"
                },
                new Formula
                {
                    Id = "C2509", Nome = "Índice Terapêutico",
                    Categoria = "Farmácia", SubCategoria = "Toxicologia",
                    Expressao = "IT = DL50 / DE50",
                    Descricao = "Relação entre dose letal mediana e dose eficaz mediana; indica margem de segurança do fármaco.",
                    Criador = "Trevan JW", AnoOrigin = "1927",
                    ReferenciaBibliografica = "Trevan JW. Proc R Soc London B, 1927.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Dose letal 50%", Simbolo = "DL50", Unidade = "mg/kg", ValorPadrao = 1000 },
                        new Variavel { Nome = "Dose eficaz 50%", Simbolo = "DE50", Unidade = "mg/kg", ValorPadrao = 100, ValorMin = 0.001 }
                    },
                    Calcular = v => v["DL50"] / v["DE50"],
                    VariavelResultado = "IT", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C2510", Nome = "Equação de Henderson-Hasselbalch",
                    Categoria = "Farmácia", SubCategoria = "Físico-Química Farmacêutica",
                    Expressao = "pH = pKa + log([A⁻] / [HA])",
                    Descricao = "Determina o grau de ionização de fármacos ácidos/básicos fraco em função do pH; essencial para absorção.",
                    Criador = "Henderson LJ / Hasselbalch KA", AnoOrigin = "1908 / 1916",
                    ReferenciaBibliografica = "Henderson LJ. Am J Physiol, 1908; Hasselbalch KA. Biochem Z, 1916.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "pKa do fármaco", Simbolo = "pKa", Unidade = "", ValorPadrao = 4.5 },
                        new Variavel { Nome = "Concentração base conjugada [A⁻]", Simbolo = "A", Unidade = "mol/L", ValorPadrao = 0.1 },
                        new Variavel { Nome = "Concentração ácido [HA]", Simbolo = "HA", Unidade = "mol/L", ValorPadrao = 0.1, ValorMin = 1e-10 }
                    },
                    Calcular = v => v["pKa"] + Math.Log10(v["A"] / v["HA"]),
                    VariavelResultado = "pH", UnidadeResultado = ""
                },
                new Formula
                {
                    Id = "C2511", Nome = "Velocidade de Michaelis-Menten (Metabolismo)",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética Não-Linear",
                    Expressao = "v = Vmax × [C] / (Km + [C])",
                    Descricao = "Descreve cinética de saturação enzimática no metabolismo hepático de fármacos.",
                    Criador = "Michaelis L, Menten ML", AnoOrigin = "1913",
                    ReferenciaBibliografica = "Michaelis L, Menten ML. Biochem Z, 1913.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade máxima", Simbolo = "Vmax", Unidade = "mg/h", ValorPadrao = 100 },
                        new Variavel { Nome = "Concentração", Simbolo = "C", Unidade = "mg/L", ValorPadrao = 10 },
                        new Variavel { Nome = "Constante Michaelis (Km)", Simbolo = "Km", Unidade = "mg/L", ValorPadrao = 5, ValorMin = 0.001 }
                    },
                    Calcular = v => v["Vmax"] * v["C"] / (v["Km"] + v["C"]),
                    VariavelResultado = "v", UnidadeResultado = "mg/h"
                },
                new Formula
                {
                    Id = "C2512", Nome = "Clearance Hepático",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "CLh = Q × E",
                    Descricao = "Clearance hepático baseado no fluxo sanguíneo hepático e na razão de extração.",
                    Criador = "Wilkinson GR, Shand DG", AnoOrigin = "1975",
                    ReferenciaBibliografica = "Wilkinson GR, Shand DG. Clin Pharmacol Ther, 1975.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Fluxo sanguíneo hepático (Q)", Simbolo = "Q", Unidade = "L/h", ValorPadrao = 90 },
                        new Variavel { Nome = "Razão de extração (E)", Simbolo = "E", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["Q"] * v["E"],
                    VariavelResultado = "CLh", UnidadeResultado = "L/h"
                },
                new Formula
                {
                    Id = "C2513", Nome = "Clearance Renal",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "CLr = fe × CL",
                    Descricao = "Fração do clearance total devida à excreção renal inalterada.",
                    Criador = "Prática clínica", AnoOrigin = "1970",
                    ReferenciaBibliografica = "Rowland M, Tozer TN. Clinical Pharmacokinetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Fração excretada inalterada (fe)", Simbolo = "fe", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Clearance total", Simbolo = "CL", Unidade = "L/h", ValorPadrao = 10 }
                    },
                    Calcular = v => v["fe"] * v["CL"],
                    VariavelResultado = "CLr", UnidadeResultado = "L/h"
                },
                new Formula
                {
                    Id = "C2514", Nome = "AUC pelo Método Trapezoidal",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "AUC(t1→t2) = (C1 + C2) / 2 × (t2 - t1)",
                    Descricao = "Área sob a curva concentração-tempo entre dois pontos; estimativa de exposição sistêmica.",
                    Criador = "Método numérico clássico", AnoOrigin = "1950",
                    ReferenciaBibliografica = "Gibaldi M, Perrier D. Pharmacokinetics, 2ª ed. 1982.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Concentração em t1", Simbolo = "C1", Unidade = "mg/L", ValorPadrao = 10 },
                        new Variavel { Nome = "Concentração em t2", Simbolo = "C2", Unidade = "mg/L", ValorPadrao = 5 },
                        new Variavel { Nome = "Tempo t1", Simbolo = "t1", Unidade = "h", ValorPadrao = 1 },
                        new Variavel { Nome = "Tempo t2", Simbolo = "t2", Unidade = "h", ValorPadrao = 3 }
                    },
                    Calcular = v => (v["C1"] + v["C2"]) / 2.0 * (v["t2"] - v["t1"]),
                    VariavelResultado = "AUC", UnidadeResultado = "mg·h/L"
                },
                new Formula
                {
                    Id = "C2515", Nome = "Equação de Cockcroft-Gault (TFG)",
                    Categoria = "Farmácia", SubCategoria = "Farmacologia Clínica",
                    Expressao = "TFG = [(140 - Idade) × Peso] / (72 × Cr) × (0,85 se mulher)",
                    Descricao = "Estima a taxa de filtração glomerular para ajuste de dose de fármacos de excreção renal.",
                    Criador = "Cockcroft DW, Gault MH", AnoOrigin = "1976",
                    ReferenciaBibliografica = "Cockcroft DW, Gault MH. Nephron, 1976.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Idade", Simbolo = "Idade", Unidade = "anos", ValorPadrao = 50 },
                        new Variavel { Nome = "Peso", Simbolo = "Peso", Unidade = "kg", ValorPadrao = 70 },
                        new Variavel { Nome = "Creatinina sérica", Simbolo = "Cr", Unidade = "mg/dL", ValorPadrao = 1.0, ValorMin = 0.1 },
                        new Variavel { Nome = "Fator sexo (1=masc, 0,85=fem)", Simbolo = "Fsexo", Unidade = "", ValorPadrao = 1.0 }
                    },
                    Calcular = v => ((140 - v["Idade"]) * v["Peso"]) / (72 * v["Cr"]) * v["Fsexo"],
                    VariavelResultado = "TFG", UnidadeResultado = "mL/min"
                },
                new Formula
                {
                    Id = "C2516", Nome = "Número de Doses para Estado Estacionário",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "n = log(1 - 0,99) / log(1 - e^(-ke×τ))",
                    Descricao = "Número de doses para atingir 99% do estado estacionário em regime de doses múltiplas.",
                    Criador = "Prática clínica", AnoOrigin = "1960",
                    ReferenciaBibliografica = "Rowland M, Tozer TN. Clinical Pharmacokinetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de eliminação", Simbolo = "ke", Unidade = "h⁻¹", ValorPadrao = 0.1, ValorMin = 0.001 },
                        new Variavel { Nome = "Intervalo de dose (τ)", Simbolo = "τ", Unidade = "h", ValorPadrao = 8 }
                    },
                    Calcular = v => Math.Log(0.01) / Math.Log(1 - Math.Exp(-v["ke"] * v["τ"])),
                    VariavelResultado = "n", UnidadeResultado = "doses"
                },
                new Formula
                {
                    Id = "C2517", Nome = "Potência Relativa de Fármaco",
                    Categoria = "Farmácia", SubCategoria = "Farmacodinâmica",
                    Expressao = "PR = DE50(referência) / DE50(teste)",
                    Descricao = "Razão entre doses eficazes medianas de fármaco de referência e teste para o mesmo efeito.",
                    Criador = "Prática farmacodinâmica", AnoOrigin = "1950",
                    ReferenciaBibliografica = "Katzung BG. Basic and Clinical Pharmacology, 14ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "DE50 referência", Simbolo = "DE50ref", Unidade = "mg/kg", ValorPadrao = 10 },
                        new Variavel { Nome = "DE50 teste", Simbolo = "DE50teste", Unidade = "mg/kg", ValorPadrao = 5, ValorMin = 0.001 }
                    },
                    Calcular = v => v["DE50ref"] / v["DE50teste"],
                    VariavelResultado = "PR", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C2518", Nome = "Concentração Inibitória Mínima (CIM)",
                    Categoria = "Farmácia", SubCategoria = "Microbiologia Farmacêutica",
                    Expressao = "Índice PK/PD: AUC24h / CIM",
                    Descricao = "Razão AUC/CIM; índice que prediz eficácia de antibióticos concentração-dependentes.",
                    Criador = "Craig WA", AnoOrigin = "1998",
                    ReferenciaBibliografica = "Craig WA. Clin Infect Dis, 1998.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "AUC 24 horas", Simbolo = "AUC24h", Unidade = "mg·h/L", ValorPadrao = 100 },
                        new Variavel { Nome = "Concentração inibitória mínima", Simbolo = "CIM", Unidade = "mg/L", ValorPadrao = 1, ValorMin = 0.001 }
                    },
                    Calcular = v => v["AUC24h"] / v["CIM"],
                    VariavelResultado = "AUC/CIM", UnidadeResultado = "h"
                },
                new Formula
                {
                    Id = "C2519", Nome = "Grau de Ionização (Ácido Fraco)",
                    Categoria = "Farmácia", SubCategoria = "Físico-Química Farmacêutica",
                    Expressao = "% ionizado = 100 / (1 + 10^(pKa - pH))",
                    Descricao = "Percentagem do fármaco ácido fraco na forma ionizada em dado pH; influencia absorção e distribuição.",
                    Criador = "Henderson-Hasselbalch", AnoOrigin = "1916",
                    ReferenciaBibliografica = "Florence AT, Attwood D. Physicochemical Principles of Pharmacy, 5ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "pKa do fármaco", Simbolo = "pKa", Unidade = "", ValorPadrao = 4.5 },
                        new Variavel { Nome = "pH do meio", Simbolo = "pH", Unidade = "", ValorPadrao = 7.4 }
                    },
                    Calcular = v => 100.0 / (1 + Math.Pow(10, v["pKa"] - v["pH"])),
                    VariavelResultado = "% ionizado", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C2520", Nome = "Efeito de Primeira Passagem",
                    Categoria = "Farmácia", SubCategoria = "Biofarmácia",
                    Expressao = "F = (1 - EH)",
                    Descricao = "Biodisponibilidade limitada pelo metabolismo hepático de primeira passagem; EH = razão de extração hepática.",
                    Criador = "Prática clínica", AnoOrigin = "1970",
                    ReferenciaBibliografica = "Katzung BG. Basic and Clinical Pharmacology, 14ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Razão de extração hepática (EH)", Simbolo = "EH", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => 1 - v["EH"],
                    VariavelResultado = "F", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C2521", Nome = "Taxa de Dissolução (Lei de Noyes-Whitney)",
                    Categoria = "Farmácia", SubCategoria = "Biofarmácia",
                    Expressao = "dM/dt = D × A × (Cs - C) / h",
                    Descricao = "Velocidade de dissolução de sólido farmacêutico proporcional à área superficial e gradiente de concentração.",
                    Criador = "Noyes AA, Whitney WR", AnoOrigin = "1897",
                    ReferenciaBibliografica = "Noyes AA, Whitney WR. J Am Chem Soc, 1897.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Coeficiente de difusão (D)", Simbolo = "D", Unidade = "cm²/s", ValorPadrao = 1e-5 },
                        new Variavel { Nome = "Área superficial (A)", Simbolo = "A", Unidade = "cm²", ValorPadrao = 10 },
                        new Variavel { Nome = "Concentração de saturação (Cs)", Simbolo = "Cs", Unidade = "mg/mL", ValorPadrao = 5 },
                        new Variavel { Nome = "Concentração no meio (C)", Simbolo = "C", Unidade = "mg/mL", ValorPadrao = 0.1 },
                        new Variavel { Nome = "Espessura da camada de difusão (h)", Simbolo = "h", Unidade = "cm", ValorPadrao = 0.001, ValorMin = 1e-6 }
                    },
                    Calcular = v => v["D"] * v["A"] * (v["Cs"] - v["C"]) / v["h"],
                    VariavelResultado = "dM/dt", UnidadeResultado = "mg/s"
                },
                new Formula
                {
                    Id = "C2522", Nome = "Lei de Beer-Lambert (Espectrofotometria)",
                    Categoria = "Farmácia", SubCategoria = "Análise Farmacêutica",
                    Expressao = "A = ε × c × l",
                    Descricao = "Relação entre absorbância, concentração e caminho óptico; base da quantificação espectrofotométrica.",
                    Criador = "Beer A / Lambert JH", AnoOrigin = "1852",
                    ReferenciaBibliografica = "Skoog DA et al. Principles of Instrumental Analysis, 7ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Absortividade molar (ε)", Simbolo = "ε", Unidade = "L/(mol·cm)", ValorPadrao = 10000 },
                        new Variavel { Nome = "Concentração (c)", Simbolo = "c", Unidade = "mol/L", ValorPadrao = 0.001 },
                        new Variavel { Nome = "Caminho óptico (l)", Simbolo = "l", Unidade = "cm", ValorPadrao = 1 }
                    },
                    Calcular = v => v["ε"] * v["c"] * v["l"],
                    VariavelResultado = "A", UnidadeResultado = "UA (absorbância)"
                },
                new Formula
                {
                    Id = "C2523", Nome = "Fórmula de Young (Dose Pediátrica)",
                    Categoria = "Farmácia", SubCategoria = "Farmacologia Clínica",
                    Expressao = "Dose criança = (Idade / (Idade + 12)) × Dose adulto",
                    Descricao = "Estimativa de dose pediátrica baseada na idade; uso como guia inicial, não substitui cálculo pelo peso.",
                    Criador = "Young T", AnoOrigin = "c. 1813",
                    ReferenciaBibliografica = "Young T. An Introduction to Medical Literature. London, 1813.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Idade da criança", Simbolo = "Idade", Unidade = "anos", ValorPadrao = 5, ValorMin = 0 },
                        new Variavel { Nome = "Dose adulto", Simbolo = "Dose adulto", Unidade = "mg", ValorPadrao = 500 }
                    },
                    Calcular = v => (v["Idade"] / (v["Idade"] + 12)) * v["Dose adulto"],
                    VariavelResultado = "Dose criança", UnidadeResultado = "mg"
                },
                new Formula
                {
                    Id = "C2524", Nome = "Equação de Stokes-Einstein (Difusão Molecular)",
                    Categoria = "Farmácia", SubCategoria = "Físico-Química Farmacêutica",
                    Expressao = "D = kB × T / (6π × η × r)",
                    Descricao = "Coeficiente de difusão de partícula esférica em solução; relevante para liberação de fármacos.",
                    Criador = "Einstein A / Stokes GG", AnoOrigin = "1905",
                    ReferenciaBibliografica = "Einstein A. Ann Phys, 1905.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura (T)", Simbolo = "T", Unidade = "K", ValorPadrao = 310 },
                        new Variavel { Nome = "Viscosidade dinâmica (η)", Simbolo = "η", Unidade = "Pa·s", ValorPadrao = 0.001, ValorMin = 1e-10 },
                        new Variavel { Nome = "Raio hidrodinâmico (r)", Simbolo = "r", Unidade = "m", ValorPadrao = 1e-9, ValorMin = 1e-15 }
                    },
                    Calcular = v => 1.380649e-23 * v["T"] / (6 * Math.PI * v["η"] * v["r"]),
                    VariavelResultado = "D", UnidadeResultado = "m²/s"
                },
                new Formula
                {
                    Id = "C2525", Nome = "Fator de Acumulação (Doses Múltiplas)",
                    Categoria = "Farmácia", SubCategoria = "Farmacocinética",
                    Expressao = "R = 1 / (1 - e^(-ke × τ))",
                    Descricao = "Razão entre concentração no estado estacionário e após primeira dose; indica acumulação do fármaco.",
                    Criador = "Prática clínica", AnoOrigin = "1970",
                    ReferenciaBibliografica = "Rowland M, Tozer TN. Clinical Pharmacokinetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Constante de eliminação", Simbolo = "ke", Unidade = "h⁻¹", ValorPadrao = 0.1, ValorMin = 0.001 },
                        new Variavel { Nome = "Intervalo de dose (τ)", Simbolo = "τ", Unidade = "h", ValorPadrao = 8 }
                    },
                    Calcular = v => 1.0 / (1 - Math.Exp(-v["ke"] * v["τ"])),
                    VariavelResultado = "R", UnidadeResultado = "adimensional"
                }
            });
        }
    }
}
