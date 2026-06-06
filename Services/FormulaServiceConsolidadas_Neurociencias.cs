using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_Neurociencias()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5601", Nome = "Equação de Nernst (Potencial de Equilíbrio Iônico)",
                    Categoria = "Neurociências", SubCategoria = "Neurofisiologia",
                    Expressao = "E_ion = (RT / zF) × ln([ion]out / [ion]in)",
                    Descricao = "Potencial de equilíbrio eletroquímico de íon específico; base para potenciais de repouso e de ação neuronal.",
                    Criador = "Nernst WH", AnoOrigin = "1888",
                    ReferenciaBibliografica = "Nernst WH. Z Phys Chem, 1888.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Temperatura (T)", Simbolo = "T", Unidade = "K", ValorPadrao = 310 },
                        new Variavel { Nome = "Valência iônica (z)", Simbolo = "z", Unidade = "", ValorPadrao = 1, ValorMin = -10, ValorMax = 10 },
                        new Variavel { Nome = "Concentração extracelular", Simbolo = "C_out", Unidade = "mM", ValorPadrao = 145, ValorMin = 0.001 },
                        new Variavel { Nome = "Concentração intracelular", Simbolo = "C_in", Unidade = "mM", ValorPadrao = 15, ValorMin = 0.001 }
                    },
                    Calcular = v => (8.314 * v["T"]) / (v["z"] * 96485) * Math.Log(v["C_out"] / v["C_in"]) * 1000,
                    VariavelResultado = "E_ion", UnidadeResultado = "mV"
                },
                new Formula
                {
                    Id = "C5602", Nome = "Equação de Goldman-Hodgkin-Katz (Potencial de Membrana)",
                    Categoria = "Neurociências", SubCategoria = "Neurofisiologia",
                    Expressao = "Vm = (RT/F) × ln[(PK[K+]o + PNa[Na+]o + PCl[Cl−]i) / (PK[K+]i + PNa[Na+]i + PCl[Cl−]o)]",
                    Descricao = "Potencial de membrana em repouso considerando múltiplos íons e suas permeabilidades relativas.",
                    Criador = "Goldman DE / Hodgkin AL / Katz B", AnoOrigin = "1943 / 1949",
                    ReferenciaBibliografica = "Goldman DE. J Gen Physiol, 1943; Hodgkin AL, Katz B. J Physiol, 1949.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "PK × [K+]out", Simbolo = "PK_out", Unidade = "mM", ValorPadrao = 5 },
                        new Variavel { Nome = "PNa × [Na+]out", Simbolo = "PNa_out", Unidade = "mM", ValorPadrao = 14.5 },
                        new Variavel { Nome = "PCl × [Cl−]in", Simbolo = "PCl_in", Unidade = "mM", ValorPadrao = 11 },
                        new Variavel { Nome = "PK × [K+]in", Simbolo = "PK_in", Unidade = "mM", ValorPadrao = 140, ValorMin = 0.001 },
                        new Variavel { Nome = "PNa × [Na+]in", Simbolo = "PNa_in", Unidade = "mM", ValorPadrao = 1.5, ValorMin = 0.001 },
                        new Variavel { Nome = "PCl × [Cl−]out", Simbolo = "PCl_out", Unidade = "mM", ValorPadrao = 120, ValorMin = 0.001 }
                    },
                    Calcular = v => (8.314*310/96485)*Math.Log((v["PK_out"]+v["PNa_out"]+v["PCl_in"])/(v["PK_in"]+v["PNa_in"]+v["PCl_out"]))*1000,
                    VariavelResultado = "Vm", UnidadeResultado = "mV"
                },
                new Formula
                {
                    Id = "C5603", Nome = "Modelo de Leaky Integrate-and-Fire (Potencial de Membrana)",
                    Categoria = "Neurociências", SubCategoria = "Neurociência Computacional",
                    Expressao = "τm × dV/dt = −(V − Vl) + R × I(t)",
                    Descricao = "Modelo simples de neurônio; integra corrente de entrada com vazamento passivo de membrana.",
                    Criador = "Lapicque L", AnoOrigin = "1907",
                    ReferenciaBibliografica = "Lapicque L. J Physiol Pathol Gen, 1907.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Corrente de entrada (I)", Simbolo = "I", Unidade = "nA", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Resistência de membrana (R)", Simbolo = "R", Unidade = "MΩ", ValorPadrao = 100 },
                        new Variavel { Nome = "Potencial de vazamento (Vl)", Simbolo = "Vl", Unidade = "mV", ValorPadrao = -65 }
                    },
                    Calcular = v => v["Vl"] + v["R"] * v["I"],
                    VariavelResultado = "V_ss (estado estacionário)", UnidadeResultado = "mV"
                },
                new Formula
                {
                    Id = "C5604", Nome = "Constante de Tempo de Membrana",
                    Categoria = "Neurociências", SubCategoria = "Biofísica Neuronal",
                    Expressao = "τm = Rm × Cm",
                    Descricao = "Constante de tempo de carregamento/descarga da membrana neuronal; determina integração temporal do neurônio.",
                    Criador = "Cole KS", AnoOrigin = "1940",
                    ReferenciaBibliografica = "Koch C. Biophysics of Computation. Oxford, 1999.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Resistência de membrana (Rm)", Simbolo = "Rm", Unidade = "MΩ", ValorPadrao = 100, ValorMin = 0.001 },
                        new Variavel { Nome = "Capacitância de membrana (Cm)", Simbolo = "Cm", Unidade = "pF", ValorPadrao = 100 }
                    },
                    Calcular = v => v["Rm"] * v["Cm"] / 1000,
                    VariavelResultado = "τm", UnidadeResultado = "ms"
                },
                new Formula
                {
                    Id = "C5605", Nome = "Lei de Ohm Neuronal (Corrente de Membrana)",
                    Categoria = "Neurociências", SubCategoria = "Biofísica Neuronal",
                    Expressao = "I = g × (V − Erev)",
                    Descricao = "Corrente iônica de canal com condutância g e potencial de reversão Erev; base dos modelos de Hodgkin-Huxley.",
                    Criador = "Hodgkin AL, Huxley AF", AnoOrigin = "1952",
                    ReferenciaBibliografica = "Hodgkin AL, Huxley AF. J Physiol, 1952.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Condutância (g)", Simbolo = "g", Unidade = "nS", ValorPadrao = 10 },
                        new Variavel { Nome = "Potencial de membrana (V)", Simbolo = "V", Unidade = "mV", ValorPadrao = -50 },
                        new Variavel { Nome = "Potencial de reversão (Erev)", Simbolo = "Erev", Unidade = "mV", ValorPadrao = -65 }
                    },
                    Calcular = v => v["g"] * (v["V"] - v["Erev"]),
                    VariavelResultado = "I", UnidadeResultado = "pA"
                },
                new Formula
                {
                    Id = "C5606", Nome = "Velocidade de Condução do Impulso Nervoso",
                    Categoria = "Neurociências", SubCategoria = "Neurofisiologia",
                    Expressao = "v ∝ sqrt(d)  (axônio mielinizado: v ≈ 6 × d)",
                    Descricao = "Velocidade de propagação de potencial de ação proporcional à raiz do diâmetro axonal (desmielinizado) ou ao diâmetro (mielinizado).",
                    Criador = "Hursh JB", AnoOrigin = "1939",
                    ReferenciaBibliografica = "Hursh JB. Am J Physiol, 1939.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Diâmetro do axônio (d)", Simbolo = "d", Unidade = "μm", ValorPadrao = 10, ValorMin = 0.1 },
                        new Variavel { Nome = "Constante (6 se mielinizado, 1 se não)", Simbolo = "k", Unidade = "", ValorPadrao = 6 }
                    },
                    Calcular = v => v["k"] * v["d"],
                    VariavelResultado = "v", UnidadeResultado = "m/s"
                },
                new Formula
                {
                    Id = "C5607", Nome = "Constante de Comprimento de Cabo Neuronal",
                    Categoria = "Neurociências", SubCategoria = "Teoria do Cabo",
                    Expressao = "λ = sqrt(rm / ri)",
                    Descricao = "Comprimento eletrônico ao longo do dendrito; indica até onde sinal se propaga passivamente.",
                    Criador = "Wilfrid Rall", AnoOrigin = "1959",
                    ReferenciaBibliografica = "Rall W. Biophys J, 1959.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Resistência transversal de membrana (rm)", Simbolo = "rm", Unidade = "Ω·m", ValorPadrao = 10000, ValorMin = 1 },
                        new Variavel { Nome = "Resistência longitudinal axoplasma (ri)", Simbolo = "ri", Unidade = "Ω/m", ValorPadrao = 1000, ValorMin = 1 }
                    },
                    Calcular = v => Math.Sqrt(v["rm"] / v["ri"]) * 1000,
                    VariavelResultado = "λ", UnidadeResultado = "mm"
                },
                new Formula
                {
                    Id = "C5608", Nome = "Taxa de Disparo Neuronal (Frequência de Spike)",
                    Categoria = "Neurociências", SubCategoria = "Neurofisiologia",
                    Expressao = "f = n_spikes / Δt",
                    Descricao = "Frequência de disparos de um neurônio em janela temporal Δt; codificação de intensidade de estímulo por frequência.",
                    Criador = "Adrian ED", AnoOrigin = "1926",
                    ReferenciaBibliografica = "Adrian ED. J Physiol, 1926.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de spikes (n)", Simbolo = "n_spikes", Unidade = "", ValorPadrao = 50, ValorMin = 0 },
                        new Variavel { Nome = "Janela temporal (Δt)", Simbolo = "Δt", Unidade = "s", ValorPadrao = 1, ValorMin = 0.001 }
                    },
                    Calcular = v => v["n_spikes"] / v["Δt"],
                    VariavelResultado = "f", UnidadeResultado = "Hz (spikes/s)"
                },
                new Formula
                {
                    Id = "C5609", Nome = "Função de Transferência de Sinapses (Modelo Hill)",
                    Categoria = "Neurociências", SubCategoria = "Neurotransmissão",
                    Expressao = "r = rmax × [NT]^n / (K_d^n + [NT]^n)",
                    Descricao = "Taxa de resposta de receptor pós-sináptico ao neurotransmissor [NT]; modelo cooperativo de Hill.",
                    Criador = "Hill AV", AnoOrigin = "1910",
                    ReferenciaBibliografica = "Hill AV. J Physiol, 1910.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Taxa máxima (rmax)", Simbolo = "rmax", Unidade = "Hz", ValorPadrao = 100 },
                        new Variavel { Nome = "Concentração de NT [NT]", Simbolo = "NT", Unidade = "μM", ValorPadrao = 10, ValorMin = 0 },
                        new Variavel { Nome = "Constante de dissociação (Kd)", Simbolo = "Kd", Unidade = "μM", ValorPadrao = 5, ValorMin = 0.001 },
                        new Variavel { Nome = "Coeficiente de Hill (n)", Simbolo = "n", Unidade = "", ValorPadrao = 2, ValorMin = 0.1 }
                    },
                    Calcular = v => v["rmax"] * Math.Pow(v["NT"],v["n"]) / (Math.Pow(v["Kd"],v["n"]) + Math.Pow(v["NT"],v["n"])),
                    VariavelResultado = "r", UnidadeResultado = "Hz"
                },
                new Formula
                {
                    Id = "C5610", Nome = "Potencial Pós-Sináptico (EPSP Simples)",
                    Categoria = "Neurociências", SubCategoria = "Neurotransmissão",
                    Expressao = "V(t) = (Q/C) × (e^(−t/τ_decay) − e^(−t/τ_rise))",
                    Descricao = "Perfil temporal de EPSP (potencial pós-sináptico excitatório) com constantes de subida e decaimento.",
                    Criador = "Jack JJB et al.", AnoOrigin = "1975",
                    ReferenciaBibliografica = "Jack JJB et al. Electric Current Flow in Excitable Cells. Oxford, 1975.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Carga total (Q)", Simbolo = "Q", Unidade = "pC", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Capacitância (C)", Simbolo = "C", Unidade = "pF", ValorPadrao = 100, ValorMin = 0.001 },
                        new Variavel { Nome = "Tempo (t)", Simbolo = "t", Unidade = "ms", ValorPadrao = 5, ValorMin = 0 },
                        new Variavel { Nome = "Constante de decaimento (τ_decay)", Simbolo = "τ_decay", Unidade = "ms", ValorPadrao = 20, ValorMin = 0.001 },
                        new Variavel { Nome = "Constante de subida (τ_rise)", Simbolo = "τ_rise", Unidade = "ms", ValorPadrao = 2, ValorMin = 0.001 }
                    },
                    Calcular = v => (v["Q"]/v["C"]) * (Math.Exp(-v["t"]/v["τ_decay"]) - Math.Exp(-v["t"]/v["τ_rise"])),
                    VariavelResultado = "V(t)", UnidadeResultado = "mV"
                },
                new Formula
                {
                    Id = "C5611", Nome = "Eficácia Sináptica (Potenciação de Longa Duração — LTP)",
                    Categoria = "Neurociências", SubCategoria = "Plasticidade Sináptica",
                    Expressao = "w(t+1) = w(t) + η × pre × post",
                    Descricao = "Regra de Hebb para plasticidade: peso sináptico aumenta quando pré e pós-sináptico são co-ativos.",
                    Criador = "Hebb DO", AnoOrigin = "1949",
                    ReferenciaBibliografica = "Hebb DO. The Organization of Behavior. Wiley, 1949.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Peso sináptico atual (w)", Simbolo = "w", Unidade = "adim.", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Taxa de aprendizagem (η)", Simbolo = "η", Unidade = "", ValorPadrao = 0.01, ValorMin = 0 },
                        new Variavel { Nome = "Atividade pré-sináptica (pre)", Simbolo = "pre", Unidade = "Hz", ValorPadrao = 50 },
                        new Variavel { Nome = "Atividade pós-sináptica (post)", Simbolo = "post", Unidade = "Hz", ValorPadrao = 60 }
                    },
                    Calcular = v => v["w"] + v["η"] * v["pre"] * v["post"],
                    VariavelResultado = "w(t+1)", UnidadeResultado = "adim."
                },
                new Formula
                {
                    Id = "C5612", Nome = "Volume Intracraniano (VIC) e Pressão",
                    Categoria = "Neurociências", SubCategoria = "Neurologia Clínica",
                    Expressao = "VIC = V_cérebro + V_LCR + V_sangue (Doutrina de Monro-Kellie)",
                    Descricao = "O volume intracraniano total é fixo; aumento de um componente exige redução de outro para manter PIC normal.",
                    Criador = "Monro A / Kellie G", AnoOrigin = "1783 / 1824",
                    ReferenciaBibliografica = "Monro A. Observations on the Structure and Functions of the Nervous System, 1783.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Volume cerebral (V_cer)", Simbolo = "V_cer", Unidade = "mL", ValorPadrao = 1400 },
                        new Variavel { Nome = "Volume de LCR (V_LCR)", Simbolo = "V_LCR", Unidade = "mL", ValorPadrao = 150 },
                        new Variavel { Nome = "Volume sanguíneo (V_sg)", Simbolo = "V_sg", Unidade = "mL", ValorPadrao = 150 }
                    },
                    Calcular = v => v["V_cer"] + v["V_LCR"] + v["V_sg"],
                    VariavelResultado = "VIC", UnidadeResultado = "mL"
                },
                new Formula
                {
                    Id = "C5613", Nome = "Pressão de Perfusão Cerebral (PPC)",
                    Categoria = "Neurociências", SubCategoria = "Neurologia Clínica",
                    Expressao = "PPC = PAM − PIC",
                    Descricao = "Pressão efetiva que impulsiona sangue pelo cérebro; PPC normal 60–100 mmHg; abaixo de 50 mmHg há risco de isquemia.",
                    Criador = "Rosner MJ", AnoOrigin = "1986",
                    ReferenciaBibliografica = "Rosner MJ, Coley IB. J Neurosurg, 1986.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Pressão arterial média (PAM)", Simbolo = "PAM", Unidade = "mmHg", ValorPadrao = 90 },
                        new Variavel { Nome = "Pressão intracraniana (PIC)", Simbolo = "PIC", Unidade = "mmHg", ValorPadrao = 15 }
                    },
                    Calcular = v => v["PAM"] - v["PIC"],
                    VariavelResultado = "PPC", UnidadeResultado = "mmHg"
                },
                new Formula
                {
                    Id = "C5614", Nome = "Fluxo Sanguíneo Cerebral (FSC)",
                    Categoria = "Neurociências", SubCategoria = "Neurologia Clínica",
                    Expressao = "FSC = PPC / RVC",
                    Descricao = "Fluxo sanguíneo cerebral (Kety-Schmidt); RVC = resistência vascular cerebral; normal ~50 mL/100g/min.",
                    Criador = "Kety SS, Schmidt CF", AnoOrigin = "1948",
                    ReferenciaBibliografica = "Kety SS, Schmidt CF. J Clin Invest, 1948.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "PPC (mmHg)", Simbolo = "PPC", Unidade = "mmHg", ValorPadrao = 75 },
                        new Variavel { Nome = "Resistência vascular cerebral (RVC)", Simbolo = "RVC", Unidade = "mmHg/(mL/100g/min)", ValorPadrao = 1.5, ValorMin = 0.001 }
                    },
                    Calcular = v => v["PPC"] / v["RVC"],
                    VariavelResultado = "FSC", UnidadeResultado = "mL/100g/min"
                },
                new Formula
                {
                    Id = "C5615", Nome = "Índice de Bispectral (BIS) — Profundidade de Anestesia",
                    Categoria = "Neurociências", SubCategoria = "Neurofisiologia Clínica",
                    Expressao = "BIS = 100 (acordado) → 0 (EEG suprimido)",
                    Descricao = "Score derivado do EEG para monitorar nível de consciência; 40–60 = anestesia adequada.",
                    Criador = "Aspect Medical Systems", AnoOrigin = "1992",
                    ReferenciaBibliografica = "Sigl JC, Chamoun NG. J Clin Monit, 1994.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Potência beta EEG (%)", Simbolo = "beta_pct", Unidade = "%", ValorPadrao = 30, ValorMin = 0, ValorMax = 100 },
                        new Variavel { Nome = "Supressão de burst (%)", Simbolo = "burst_supp", Unidade = "%", ValorPadrao = 0, ValorMin = 0, ValorMax = 100 }
                    },
                    Calcular = v => 100 - v["burst_supp"] - v["beta_pct"] * 0.5,
                    VariavelResultado = "BIS (aprox.)", UnidadeResultado = "adim. (0-100)"
                },
                new Formula
                {
                    Id = "C5616", Nome = "Escala de Coma de Glasgow (GCS)",
                    Categoria = "Neurociências", SubCategoria = "Neurologia Clínica",
                    Expressao = "GCS = E + V + M",
                    Descricao = "Avaliação do nível de consciência; E=abertura ocular (1-4), V=resposta verbal (1-5), M=resposta motora (1-6). GCS ≤ 8 = coma.",
                    Criador = "Teasdale G, Jennett B", AnoOrigin = "1974",
                    ReferenciaBibliografica = "Teasdale G, Jennett B. Lancet, 1974.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Abertura ocular (E)", Simbolo = "E", Unidade = "", ValorPadrao = 4, ValorMin = 1, ValorMax = 4 },
                        new Variavel { Nome = "Resposta verbal (V)", Simbolo = "V", Unidade = "", ValorPadrao = 5, ValorMin = 1, ValorMax = 5 },
                        new Variavel { Nome = "Resposta motora (M)", Simbolo = "M", Unidade = "", ValorPadrao = 6, ValorMin = 1, ValorMax = 6 }
                    },
                    Calcular = v => v["E"] + v["V"] + v["M"],
                    VariavelResultado = "GCS", UnidadeResultado = "pontos (3-15)"
                },
                new Formula
                {
                    Id = "C5617", Nome = "Número de Neurônios Estimado (Método Fraccionator)",
                    Categoria = "Neurociências", SubCategoria = "Neuroanatomia Quantitativa",
                    Expressao = "N = CE × ΣQ / (ssf × asf × tsf)",
                    Descricao = "Estimativa estereológica do número total de neurônios via fraccionator; ssf=fração de seção, asf=fração de área, tsf=fração de espessura.",
                    Criador = "West MJ et al.", AnoOrigin = "1991",
                    ReferenciaBibliografica = "West MJ et al. Anat Rec, 1991.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma de neurônios contados (ΣQ)", Simbolo = "sum_Q", Unidade = "", ValorPadrao = 500 },
                        new Variavel { Nome = "Fração de seção amostrada (ssf)", Simbolo = "ssf", Unidade = "", ValorPadrao = 0.1, ValorMin = 0.001 },
                        new Variavel { Nome = "Fração de área amostrada (asf)", Simbolo = "asf", Unidade = "", ValorPadrao = 0.05, ValorMin = 0.001 },
                        new Variavel { Nome = "Fração de espessura amostrada (tsf)", Simbolo = "tsf", Unidade = "", ValorPadrao = 0.8, ValorMin = 0.001 }
                    },
                    Calcular = v => v["sum_Q"] / (v["ssf"] * v["asf"] * v["tsf"]),
                    VariavelResultado = "N", UnidadeResultado = "neurônios"
                },
                new Formula
                {
                    Id = "C5618", Nome = "BOLD Signal fMRI (Modelo Balão)",
                    Categoria = "Neurociências", SubCategoria = "Neuroimagem",
                    Expressao = "BOLD ∝ ΔoxyHb − k × ΔdeoxyHb",
                    Descricao = "Sinal de fMRI BOLD relaciona aumento de oxiemoglobina e redução de deoxiemoglobina por hiperemia neurovascular.",
                    Criador = "Ogawa S et al.", AnoOrigin = "1990",
                    ReferenciaBibliografica = "Ogawa S et al. Proc Natl Acad Sci, 1990.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Variação de oxiHb (ΔoxyHb)", Simbolo = "Δoxy", Unidade = "%", ValorPadrao = 3 },
                        new Variavel { Nome = "Variação de deoxiHb (ΔdeoxyHb)", Simbolo = "Δdeoxy", Unidade = "%", ValorPadrao = 1 },
                        new Variavel { Nome = "Constante de ponderação (k)", Simbolo = "k", Unidade = "", ValorPadrao = 2 }
                    },
                    Calcular = v => v["Δoxy"] - v["k"] * v["Δdeoxy"],
                    VariavelResultado = "BOLD (aprox.)", UnidadeResultado = "% de variação"
                },
                new Formula
                {
                    Id = "C5619", Nome = "Equação de Fick para Consumo de O2 Cerebral (CMRO2)",
                    Categoria = "Neurociências", SubCategoria = "Neurometabolismo",
                    Expressao = "CMRO2 = FSC × AVDO2",
                    Descricao = "Taxa metabólica cerebral de oxigênio; produto do fluxo sanguíneo cerebral pela diferença arteriovenosa de O2.",
                    Criador = "Fick A", AnoOrigin = "1870",
                    ReferenciaBibliografica = "Kety SS, Schmidt CF. J Clin Invest, 1948.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Fluxo sanguíneo cerebral (FSC)", Simbolo = "FSC", Unidade = "mL/100g/min", ValorPadrao = 50 },
                        new Variavel { Nome = "Diferença arteriovenosa de O2 (AVDO2)", Simbolo = "AVDO2", Unidade = "mL O2/100mL", ValorPadrao = 6.3 }
                    },
                    Calcular = v => v["FSC"] * v["AVDO2"] / 100,
                    VariavelResultado = "CMRO2", UnidadeResultado = "mL O2/100g/min"
                },
                new Formula
                {
                    Id = "C5620", Nome = "Limiar de Rheobase e Cronaxia",
                    Categoria = "Neurociências", SubCategoria = "Excitabilidade Neuronal",
                    Expressao = "I_threshold = Irh × (1 + C/t)",
                    Descricao = "Corrente de limiar de excitação; Irh = rheobase (corrente mínima), C = cronaxia (tempo ao dobro da rheobase).",
                    Criador = "Lapicque L", AnoOrigin = "1909",
                    ReferenciaBibliografica = "Lapicque L. J Physiol Pathol Gen, 1909.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Rheobase (Irh)", Simbolo = "Irh", Unidade = "nA", ValorPadrao = 1 },
                        new Variavel { Nome = "Cronaxia (C)", Simbolo = "C", Unidade = "ms", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Duração do pulso (t)", Simbolo = "t", Unidade = "ms", ValorPadrao = 1, ValorMin = 0.001 }
                    },
                    Calcular = v => v["Irh"] * (1 + v["C"] / v["t"]),
                    VariavelResultado = "I_threshold", UnidadeResultado = "nA"
                },
                new Formula
                {
                    Id = "C5621", Nome = "Gradiente Eletroquímico de Íon",
                    Categoria = "Neurociências", SubCategoria = "Biofísica Neuronal",
                    Expressao = "Δμ = z × F × ΔV + RT × ln([C_in]/[C_out])",
                    Descricao = "Força eletroquímica total sobre um íon; combinação do gradiente elétrico e de concentração.",
                    Criador = "Gibbs JW / Nernst WH", AnoOrigin = "1876 / 1888",
                    ReferenciaBibliografica = "Koch C. Biophysics of Computation. Oxford, 1999.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Valência (z)", Simbolo = "z", Unidade = "", ValorPadrao = 1 },
                        new Variavel { Nome = "Diferença de potencial (ΔV)", Simbolo = "ΔV", Unidade = "V", ValorPadrao = -0.065 },
                        new Variavel { Nome = "Temperatura (T)", Simbolo = "T", Unidade = "K", ValorPadrao = 310 },
                        new Variavel { Nome = "[C_in]", Simbolo = "C_in", Unidade = "mM", ValorPadrao = 140, ValorMin = 0.001 },
                        new Variavel { Nome = "[C_out]", Simbolo = "C_out", Unidade = "mM", ValorPadrao = 5, ValorMin = 0.001 }
                    },
                    Calcular = v => v["z"]*96485*v["ΔV"] + 8.314*v["T"]*Math.Log(v["C_in"]/v["C_out"]),
                    VariavelResultado = "Δμ", UnidadeResultado = "J/mol"
                },
                new Formula
                {
                    Id = "C5622", Nome = "Atenuação de Potencial em Dendrito (Decaimento Passivo)",
                    Categoria = "Neurociências", SubCategoria = "Teoria do Cabo",
                    Expressao = "V(x) = V0 × e^(−x/λ)",
                    Descricao = "Decaimento exponencial de potencial ao longo de dendrito passivo com constante de comprimento λ.",
                    Criador = "Rall W", AnoOrigin = "1959",
                    ReferenciaBibliografica = "Rall W. Biophys J, 1959.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Potencial na origem (V0)", Simbolo = "V0", Unidade = "mV", ValorPadrao = 10 },
                        new Variavel { Nome = "Distância (x)", Simbolo = "x", Unidade = "mm", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Constante de comprimento (λ)", Simbolo = "λ", Unidade = "mm", ValorPadrao = 1.0, ValorMin = 0.001 }
                    },
                    Calcular = v => v["V0"] * Math.Exp(-v["x"] / v["λ"]),
                    VariavelResultado = "V(x)", UnidadeResultado = "mV"
                },
                new Formula
                {
                    Id = "C5623", Nome = "Poder Espectral de EEG por Banda",
                    Categoria = "Neurociências", SubCategoria = "Eletroencefalografia",
                    Expressao = "P_banda = Σ |X(f)|² / N (f dentro da banda)",
                    Descricao = "Potência do EEG em banda de frequência específica (δ: 0,5-4Hz, θ: 4-8Hz, α: 8-13Hz, β: 13-30Hz, γ: >30Hz).",
                    Criador = "Berger H / Cooley-Tukey (FFT)", AnoOrigin = "1929 / 1965",
                    ReferenciaBibliografica = "Niedermeyer E, Lopes da Silva F. Electroencephalography, 5ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Amplitude média do EEG na banda (A)", Simbolo = "A", Unidade = "μV", ValorPadrao = 20 },
                        new Variavel { Nome = "Número de componentes na banda (N)", Simbolo = "N", Unidade = "", ValorPadrao = 9, ValorMin = 1 }
                    },
                    Calcular = v => v["A"]*v["A"] / v["N"],
                    VariavelResultado = "P_banda", UnidadeResultado = "μV²"
                },
                new Formula
                {
                    Id = "C5624", Nome = "Taxa de Síntese de Neurotransmissor (Km de Tirosina Hidroxilase)",
                    Categoria = "Neurociências", SubCategoria = "Neuroquímica",
                    Expressao = "v = Vmax × [S] / (Km + [S])",
                    Descricao = "Síntese de dopamina/noradrenalina via tirosina-hidroxilase; modelo de Michaelis-Menten.",
                    Criador = "Nagatsu T et al.", AnoOrigin = "1964",
                    ReferenciaBibliografica = "Nagatsu T et al. Biochemistry, 1964.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Velocidade máxima (Vmax)", Simbolo = "Vmax", Unidade = "nmol/min/mg", ValorPadrao = 5 },
                        new Variavel { Nome = "Concentração de tirosina [S]", Simbolo = "S", Unidade = "μM", ValorPadrao = 50, ValorMin = 0 },
                        new Variavel { Nome = "Km da tirosina hidroxilase", Simbolo = "Km", Unidade = "μM", ValorPadrao = 40, ValorMin = 0.001 }
                    },
                    Calcular = v => v["Vmax"] * v["S"] / (v["Km"] + v["S"]),
                    VariavelResultado = "v", UnidadeResultado = "nmol/min/mg"
                },
                new Formula
                {
                    Id = "C5625", Nome = "Índice de Lateralização de Linguagem (fMRI)",
                    Categoria = "Neurociências", SubCategoria = "Neuroimagem",
                    Expressao = "LI = (L − R) / (L + R)",
                    Descricao = "Lateralização hemisférica de ativação linguística; LI > 0,2 = dominância esquerda, < -0,2 = direita.",
                    Criador = "Springer JA et al.", AnoOrigin = "1999",
                    ReferenciaBibliografica = "Springer JA et al. Brain, 1999.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Ativação no hemisfério esquerdo (L)", Simbolo = "L", Unidade = "voxels", ValorPadrao = 200, ValorMin = 0 },
                        new Variavel { Nome = "Ativação no hemisfério direito (R)", Simbolo = "R", Unidade = "voxels", ValorPadrao = 80, ValorMin = 0 }
                    },
                    Calcular = v => (v["L"] - v["R"]) / Math.Max(v["L"] + v["R"], 0.001),
                    VariavelResultado = "LI", UnidadeResultado = "adimensional (-1 a +1)"
                }
            });
        }
    }
}
