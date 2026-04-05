using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XI
    /// MEDICINA NUCLEAR E RADIOTERAPIA
    /// Fórmulas V10-201 a V10-219 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_NuclearMedicine()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3789",
                    CodigoCompendio = "V10-201",
                    Nome = "Decaimento Radioativo — Atividade",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Dosimetria",
                    Expressao = @"A(t) = A₀·e^(−λt); T₁/₂=ln(2)/λ",
                    Descricao = "Atividade radioativa diminui exponencialmente. λ: constante de decaimento. T₁/₂: meia-vida.",
                    ExemploPratico = "Tc-99m (meia-vida 6h): após 24h, atividade reduz a 6.25%. F-18 FDG (T₁/₂=110min): PET scan.",
                    Criador = "Rutherford e Soddy (1902, lei do decaimento radioativo)",
                    AnoOrigin = "1902",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Atividade inicial A₀ (MBq)", Simbolo = "A₀", Unidade = "MBq", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Meia-vida T₁/₂ (h)", Simbolo = "T₁/₂", Unidade = "h", ValorPadrao = 6, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tempo t (h)", Simbolo = "t", Unidade = "h", ValorPadrao = 12, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double A0 = inputs["Atividade inicial A₀ (MBq)"];
                        double T_half = inputs["Meia-vida T₁/₂ (h)"];
                        double t = inputs["Tempo t (h)"];
                        
                        if (T_half == 0) return 0;
                        double lambda = Math.Log(2) / T_half;
                        double A_t = A0 * Math.Exp(-lambda * t);
                        return A_t;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-202: Dose Absorvida (Gray)
                new Formula
                {
                    Id = "3790",
                    CodigoCompendio = "V10-202",
                    Nome = "Dose Absorvida D (Gray)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Dosimetria",
                    Expressao = @"D = E/m (J/kg); 1 Gy = 1 J/kg = 100 rad",
                    Descricao = "Energia depositada por massa. Gray: unidade SI. rad: unidade antiga. Dose letal LD50≈4-5 Gy (todo corpo). Radioterapia: 50-70 Gy fracionado.",
                    ExemploPratico = "Tumor: 60 Gy em 30 frações→2 Gy/dia (standard). 10 MeV depositado em 1g tecido→D=10 MeV/g≈1.6×10^-9 Gy (1 partícula, insignificante).",
                    Criador = "SI (1975, adotado Gray); rad (radiation absorbed dose, 1918)",
                    AnoOrigin = "1975",
                    VariavelResultado = "D",
                    UnidadeResultado = "Gy",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Energia E (J)", Simbolo = "E", Unidade = "J", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Massa m (kg)", Simbolo = "m", Unidade = "kg", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E = inputs["Energia E (J)"];
                        double m = inputs["Massa m (kg)"];
                        
                        if (m == 0) return 0;
                        double D = E / m;
                        return D;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-203: Dose Equivalente (Sievert)
                new Formula
                {
                    Id = "3791",
                    CodigoCompendio = "V10-203",
                    Nome = "Dose Equivalente H (Sievert)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Proteção Radiológica",
                    Expressao = @"H = D × w_R (Sv); w_R: fator qualidade radiação",
                    Descricao = "w_R: fótons/elétrons=1, prótons=2, α/núcleos=20. Dose biológica. Limite ocupacional: 20 mSv/ano. Público: 1 mSv/ano.",
                    ExemploPratico = "α: w_R=20. D=0.1 Gy→H=2 Sv (letal!). Raios-X: w_R=1, D=H. Fundo natural: ~2.4 mSv/ano. CT scan: ~10 mSv. Fukushima workers: some >100 mSv.",
                    Criador = "ICRP (International Commission on Radiological Protection, anos 1950s-1970s); Sievert (1977)",
                    AnoOrigin = "1977",
                    VariavelResultado = "H",
                    UnidadeResultado = "Sv",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Dose D (Gy)", Simbolo = "D", Unidade = "Gy", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tipo (1=γ/X,2=p,3=α)", Simbolo = "tipo", Unidade = "", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double D = inputs["Dose D (Gy)"];
                        int tipo = (int)inputs["Tipo (1=γ/X,2=p,3=α)"];
                        
                        double w_R = 1;
                        switch (tipo)
                        {
                            case 1: w_R = 1; break;   // γ/X
                            case 2: w_R = 2; break;   // prótons
                            case 3: w_R = 20; break;  // α
                        }
                        
                        double H = D * w_R;
                        return H;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-204: SUV (Standard Uptake Value) — PET
                new Formula
                {
                    Id = "3792",
                    CodigoCompendio = "V10-204",
                    Nome = "SUV — Standard Uptake Value (PET)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "PET Imaging",
                    Expressao = @"SUV = (Atividade/mL tecido)/(Dose injetada/Peso paciente)",
                    Descricao = "FDG-PET: SUV quantifica uptake glicose. Tumor: SUV>2.5 suspeito. Inflamação: SUV alto. Lean body mass: SUV_LBM mais preciso.",
                    ExemploPratico = "PET: lesão 10 kBq/mL, dose 400 MBq, paciente 70 kg→SUV=10/(400/70)≈1.75 (benigno?). Tumor agressivo: SUV>5. Liver: SUV~2 (baseline).",
                    Criador = "Phelps et al. (anos 1970s-1980s, padronização PET)",
                    AnoOrigin = "1980",
                    VariavelResultado = "SUV",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Atividade tecido (kBq/mL)", Simbolo = "A_tec", Unidade = "kBq/mL", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Dose injetada (MBq)", Simbolo = "Dose", Unidade = "MBq", ValorPadrao = 400, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Peso paciente (kg)", Simbolo = "peso", Unidade = "kg", ValorPadrao = 70, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double A_tec = inputs["Atividade tecido (kBq/mL)"];
                        double Dose = inputs["Dose injetada (MBq)"];
                        double peso = inputs["Peso paciente (kg)"];
                        
                        if (peso == 0 || Dose == 0) return 0;
                        
                        double A_tec_MBq = A_tec / 1000; // kBq -> MBq
                        double SUV = A_tec_MBq / (Dose / peso);
                        return SUV;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-205: Resolução Espacial SPECT
                new Formula
                {
                    Id = "3793",
                    CodigoCompendio = "V10-205",
                    Nome = "Resolução Espacial SPECT",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "SPECT Imaging",
                    Expressao = @"R_c = d·(b+f)/b (colimador)",
                    Descricao = "d: diâmetro furo, b: distância furo, f: distância fonte-colimador. Trade-off: sensibilidade vs resolução. LEHR (Low Energy High Resolution).",
                    ExemploPratico = "LEHR: d=1.5mm, b=25mm, f=100mm→R_c=1.5·(25+100)/25=7.5mm. Próximo: better (~5mm). Longe: worse (~15mm). PET: ~5mm (superior).",
                    Criador = "Anger (1958, Anger camera, fundação SPECT)",
                    AnoOrigin = "1958",
                    VariavelResultado = "R_c",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "d diâm furo (mm)", Simbolo = "d", Unidade = "mm", ValorPadrao = 1.5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "b distância furo (mm)", Simbolo = "b", Unidade = "mm", ValorPadrao = 25, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f dist fonte (mm)", Simbolo = "f", Unidade = "mm", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double d = inputs["d diâm furo (mm)"];
                        double b = inputs["b distância furo (mm)"];
                        double f = inputs["f dist fonte (mm)"];
                        
                        if (b == 0) return 0;
                        double R_c = d * (b + f) / b;
                        return R_c;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-206: Fator de Acumulação (Buildup)
                new Formula
                {
                    Id = "3794",
                    CodigoCompendio = "V10-206",
                    Nome = "Fator de Buildup B(x)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Blindagem",
                    Expressao = @"I = I₀·e^(-μx)·B(x); B≥1 (scattering)",
                    Descricao = "B: contabiliza fótons espalhados. Beam narrow: B=1. Beam broad: B>1. Berger-Taylor tables. Material/energia dependent.",
                    ExemploPratico = "Co-60 (1.25 MeV), concrete 30cm: μ=0.05/cm, μx=1.5→e^-μx=0.22. B≈2.5→I/I₀=0.56 (vs 0.22 sem buildup). XCOM database (NIST).",
                    Criador = "Fano (1954, buildup factors); Berger (1968, tabelas)",
                    AnoOrigin = "1954",
                    VariavelResultado = "I_relativo",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "μ (1/cm)", Simbolo = "mu", Unidade = "1/cm", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "x espessura (cm)", Simbolo = "x", Unidade = "cm", ValorPadrao = 30, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "B buildup", Simbolo = "B", Unidade = "", ValorPadrao = 2.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double mu = inputs["μ (1/cm)"];
                        double x = inputs["x espessura (cm)"];
                        double B = inputs["B buildup"];
                        
                        double I_rel = Math.Exp(-mu * x) * B;
                        return I_rel;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-207: Tempo de Trânsito (Renograma)
                new Formula
                {
                    Id = "3795",
                    CodigoCompendio = "V10-207",
                    Nome = "Tempo de Trânsito Renal (MTT)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Medicina Nuclear Funcional",
                    Expressao = @"MTT = ∫t·C(t)dt / ∫C(t)dt",
                    Descricao = "C(t): curva atividade-tempo (renograma). MTT: mean transit time. Tc-99m MAG3/DTPA. Obstrução: MTT prolongado.",
                    ExemploPratico = "Rim normal: MTT≈3-5min. Obstrução: MTT>10min. Split function: kidney 1 vs 2 (normalizado). Lasix: diurético→distingue obstrução de dilatação.",
                    Criador = "Sapirstein (1958, indicador-dilution); renografia nuclear (anos 1960s)",
                    AnoOrigin = "1960",
                    VariavelResultado = "MTT",
                    UnidadeResultado = "min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "∫tC(t) (counts·min)", Simbolo = "integ_tC", Unidade = "counts·min", ValorPadrao = 5000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "∫C(t) (counts)", Simbolo = "integ_C", Unidade = "counts", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double integ_tC = inputs["∫tC(t) (counts·min)"];
                        double integ_C = inputs["∫C(t) (counts)"];
                        
                        if (integ_C == 0) return 0;
                        double MTT = integ_tC / integ_C;
                        return MTT;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-208: Clearance Renal (GFR)
                new Formula
                {
                    Id = "3796",
                    CodigoCompendio = "V10-208",
                    Nome = "Taxa de Filtração Glomerular (GFR)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Função Renal",
                    Expressao = @"GFR = (Dose − resíduo)/(AUC × peso)",
                    Descricao = "AUC: area under curve (plasma clearance). Tc-99m DTPA. GFR normal: 90-120 mL/min/1.73m². Chronic kidney disease: GFR<60.",
                    ExemploPratico = "Dose 100 MBq DTPA, resíduo seringa 5 MBq, AUC=1000 (MBq·min/L), peso 70kg→GFR≈1.36 mL/min/kg≈95 mL/min/1.73m² (normal).",
                    Criador = "Gates (1982, método Gates GFR simples); Russell (1985, plasma sample method)",
                    AnoOrigin = "1982",
                    VariavelResultado = "GFR",
                    UnidadeResultado = "mL/min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Dose (MBq)", Simbolo = "dose", Unidade = "MBq", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Resíduo (MBq)", Simbolo = "res", Unidade = "MBq", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "AUC (MBq·min/L)", Simbolo = "AUC", Unidade = "MBq·min/L", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Peso (kg)", Simbolo = "peso", Unidade = "kg", ValorPadrao = 70, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double dose = inputs["Dose (MBq)"];
                        double res = inputs["Resíduo (MBq)"];
                        double AUC = inputs["AUC (MBq·min/L)"];
                        double peso = inputs["Peso (kg)"];
                        
                        if (AUC ==0 || peso == 0) return 0;
                        
                        double dose_efetiva = dose - res;
                        double GFR = (dose_efetiva / AUC) * 1000 / peso; // mL/min/kg
                        GFR *= peso / 70 * 1.73; // normalize to 1.73 m²
                        return GFR;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-209: Fração de Ejeção Cardíaca (LVEF)
                new Formula
                {
                    Id = "3797",
                    CodigoCompendio = "V10-209",
                    Nome = "Fração de Ejeção Ventricular Esquerda (LVEF)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Cardiologia Nuclear",
                    Expressao = @"LVEF = (EDC − ESC)/EDC × 100%",
                    Descricao = "EDC: end-diastolic counts, ESC: end-systolic. Gated SPECT/PET. LVEF normal: >50%. HF: <40%. Tc-99m sestamibi.",
                    ExemploPratico = "MUGA scan: EDC=10000 counts, ESC=4000→LVEF=60% (normal). LVEF=25%: severe heart failure (transplant candidate). LAD infarct: regional wall motion.",
                    Criador = "Strauss et al. (1971, radionuclide ventriculography); gated SPECT (1980s)",
                    AnoOrigin = "1971",
                    VariavelResultado = "LVEF",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "EDC (counts)", Simbolo = "EDC", Unidade = "counts", ValorPadrao = 10000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ESC (counts)", Simbolo = "ESC", Unidade = "counts", ValorPadrao = 4000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double EDC = inputs["EDC (counts)"];
                        double ESC = inputs["ESC (counts)"];
                        
                        if (EDC == 0) return 0;
                        double LVEF = ((EDC - ESC) / EDC) * 100;
                        return LVEF;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-210: Modelo de Compartimentos (Farmacocinética)
                new Formula
                {
                    Id = "3798",
                    CodigoCompendio = "V10-210",
                    Nome = "Modelo Monocompartimental C(t)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Farmacocinética Radiotraçadores",
                    Expressao = @"C(t) = C₀·e^(-kt); t₁/₂=ln(2)/k",
                    Descricao = "Clearance exponencial. Volume distribuição V_d=Dose/C₀. Clearance Cl=k·V_d. Model bicompartimental: α+β phases.",
                    ExemploPratico = "FDG: C₀=10 kBq/mL, k=0.01/min→t₁/₂≈69min. 3h: C≈5.5 kBq/mL. Liver uptake: bicompartimental (fast blood→slow hepatocytes).",
                    Criador = "Teorell (1937, modelo compartimentos); Widmark (1919, farmacocinética álcool)",
                    AnoOrigin = "1937",
                    VariavelResultado = "C_t",
                    UnidadeResultado = "kBq/mL",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "C₀ (kBq/mL)", Simbolo = "C0", Unidade = "kBq/mL", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k (1/min)", Simbolo = "k", Unidade = "1/min", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t (min)", Simbolo = "t", Unidade = "min", ValorPadrao = 180, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double C0 = inputs["C₀ (kBq/mL)"];
                        double k = inputs["k (1/min)"];
                        double t = inputs["t (min)"];
                        
                        double C_t = C0 * Math.Exp(-k * t);
                        return C_t;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-211: Sensibilidade PET
                new Formula
                {
                    Id = "3799",
                    CodigoCompendio = "V10-211",
                    Nome = "Sensibilidade PET (cps/Bq/mL)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "PET Performance",
                    Expressao = @"Sens = (Counts/s)/Concentração",
                    Descricao = "NEMA NU 2 protocol. Sensibilidade típica: 5-10 cps/(kBq/mL). TOF-PET: melhor SNR (~2×). Digital PET (SiPM): sensitivity×2-3.",
                    ExemploPratico = "Scanner: 10000 cps, phantom 20 kBq/mL→Sens=10000/20=500 cps/(kBq/mL)=5 cps/(Bq/mL). BGO: ~5 cps/kBq/mL. LSO: ~8 (better). Biograph Vision: ~16 (SOTA).",
                    Criador = "NEMA (National Electrical Manufacturers Association, anos 1990s, PET standards)",
                    AnoOrigin = "1994",
                    VariavelResultado = "Sens",
                    UnidadeResultado = "cps/(kBq/mL)",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Counts/s (cps)", Simbolo = "cps", Unidade = "cps", ValorPadrao = 10000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Concentração (kBq/mL)", Simbolo = "conc", Unidade = "kBq/mL", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double cps = inputs["Counts/s (cps)"];
                        double conc = inputs["Concentração (kBq/mL)"];
                        
                        if (conc == 0) return 0;
                        double Sens = cps / conc;
                        return Sens;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-212: Índice de Extração Hepática
                new Formula
                {
                    Id = "3800",
                    CodigoCompendio = "V10-212",
                    Nome = "Fração de Extração Hepática (HEF)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Função Hepática",
                    Expressao = @"HEF = (Cin − Cout)/Cin",
                    Descricao = "Cin: arterial, Cout: venoso hepático. Tc-99m IDA analogs (hepatobiliary). Clearance hepatocyte→bile. Colestase: HEF reduzido.",
                    ExemploPratico = "Normal: HEF>0.9 (>90% extraído). Cirrose: HEF=0.5 (50%). IDA scan: visualiza excreção biliar. Biliary atresia: não excreção duodeno.",
                    Criador = "Krishnamurthy et al. (1983, hepatobiliary scintigraphy)",
                    AnoOrigin = "1983",
                    VariavelResultado = "HEF",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Cin (kBq/mL)", Simbolo = "Cin", Unidade = "kBq/mL", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Cout (kBq/mL)", Simbolo = "Cout", Unidade = "kBq/mL", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Cin = inputs["Cin (kBq/mL)"];
                        double Cout = inputs["Cout (kBq/mL)"];
                        
                        if (Cin == 0) return 0;
                        double HEF = (Cin - Cout) / Cin;
                        return HEF;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-213: Fração de Shunt Pulmonar
                new Formula
                {
                    Id = "3801",
                    CodigoCompendio = "V10-213",
                    Nome = "Fração de Shunt Pulmonar (Hepatic Arterial Embolization)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Terapia Radioisotópica",
                    Expressao = @"LSF = Lung/(Lung+Liver)",
                    Descricao = "Radioembolização Y-90 (THERAsphere/SIR-Spheres). LSF>20%: contraindicação. MAA scan pré-tratamento prediz shunt.",
                    ExemploPratico = "Tc-99m MAA: liver uptake 800k counts, lung 200k→LSF=200/(200+800)=0.2 (20% borderline). LSF<10%: safe. Dose lung=LSF×dose total.",
                    Criador = "Ho et al. (1996, Y-90 microspheres liver cancer); Andrews et al. (1994)",
                    AnoOrigin = "1996",
                    VariavelResultado = "LSF",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Lung counts", Simbolo = "lung", Unidade = "counts", ValorPadrao = 200000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Liver counts", Simbolo = "liver", Unidade = "counts", ValorPadrao = 800000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lung = inputs["Lung counts"];
                        double liver = inputs["Liver counts"];
                        
                        double total = lung + liver;
                        if (total == 0) return 0;
                        
                        double LSF = (lung / total) * 100;
                        return LSF;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-214: Dose de Radiofármaco
                new Formula
                {
                    Id = "3802",
                    CodigoCompendio = "V10-214",
                    Nome = "Dose de Radiofármaco (Tamanho/Idade)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Pediatria",
                    Expressao = @"Dose_child = Dose_adult × √(Age/Age+1)",
                    Descricao = "Fórmula Webster. Alternativa: peso (dose∝kg) or BSA. EANM: pediatric dose card. ALARA: mínimo justificado.",
                    ExemploPratico = "Tc-99m MDP adulto: 740 MBq. Criança 5 anos→Dose=740×√(5/6)≈674 MBq. Infant 1yr: 740×√(1/2)≈523 MBq. FDG: 5.18 MBq/kg (EANM).",
                    Criador = "Webster (1977, pediatric dosing); Clark (1953, body surface rule); Young (1890, Young's rule)",
                    AnoOrigin = "1977",
                    VariavelResultado = "Dose_child",
                    UnidadeResultado = "MBq",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Dose adulto (MBq)", Simbolo = "adult", Unidade = "MBq", ValorPadrao = 740, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Idade (anos)", Simbolo = "age", Unidade = "anos", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double adult = inputs["Dose adulto (MBq)"];
                        double age = inputs["Idade (anos)"];
                        
                        double Dose_child = adult * Math.Sqrt(age / (age + 1));
                        return Dose_child;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-215: Cintigrafia Óssea — Razão Lesão/Background
                new Formula
                {
                    Id = "3803",
                    CodigoCompendio = "V10-215",
                    Nome = "Razão Lesão/Background (Bone Scan)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Oncologia",
                    Expressao = @"L/B = (Counts_lesion − BG)/(Counts_normal − BG)",
                    Descricao = "Tc-99m MDP. Metástase óssea: L/B>1.5. L/B>2: highly suspicious. Flare phenomenon: aumento uptake pós-quimio (healing, not progression).",
                    ExemploPratico = "Vértebra com lesão: 5000 counts, normal adjacente: 2000, BG: 500→L/B=(5000−500)/(2000−500)=3.0 (metástase provável). Paget: L/B>5.",
                    Criador = "Subramanian et al. (1971, Tc-99m MDP); Fleming et al. (1974, quantificação)",
                    AnoOrigin = "1974",
                    VariavelResultado = "L_B",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Counts lesão", Simbolo = "lesion", Unidade = "counts", ValorPadrao = 5000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Counts normal", Simbolo = "normal", Unidade = "counts", ValorPadrao = 2000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Background", Simbolo = "BG", Unidade = "counts", ValorPadrao = 500, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lesion = inputs["Counts lesão"];
                        double normal = inputs["Counts normal"];
                        double BG = inputs["Background"];
                        
                        double denom = normal - BG;
                        if (denom <= 0) return 0;
                        
                        double L_B = (lesion - BG) / denom;
                        return L_B;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-216: Tempo de Duplicação Tumoral
                new Formula
                {
                    Id = "3804",
                    CodigoCompendio = "V10-216",
                    Nome = "Tempo de Duplicação Tumoral (Doubling Time)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Oncologia Quantitativa",
                    Expressao = @"T_d = (t₂−t₁)·ln(2)/ln(V₂/V₁)",
                    Descricao = "Crescimento exponencial. V: volume (PET/CT). T_d<30 dias: agressivo. T_d>400: indolente. PSA doubling time (próstata): análogo.",
                    ExemploPratico = "Nódulo pulmonar: scan 1: V₁=1 cm³, scan 2 (6 meses): V₂=1.4 cm³→T_d=180·ln(2)/ln(1.4)≈347 dias (slow-growing, possibly benign).",
                    Criador = "Collins et al. (1956, tumor growth kinetics); Schwartz (1961, doubling time)",
                    AnoOrigin = "1961",
                    VariavelResultado = "T_d",
                    UnidadeResultado = "dias",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "V₁ (cm³)", Simbolo = "V1", Unidade = "cm³", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "V₂ (cm³)", Simbolo = "V2", Unidade = "cm³", ValorPadrao = 1.4, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Δt (dias)", Simbolo = "dt", Unidade = "dias", ValorPadrao = 180, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double V1 = inputs["V₁ (cm³)"];
                        double V2 = inputs["V₂ (cm³)"];
                        double dt = inputs["Δt (dias)"];
                        
                        if (V2 <= V1 || V1 == 0) return double.PositiveInfinity;
                        
                        double T_d = dt * Math.Log(2) / Math.Log(V2 / V1);
                        return T_d;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-217: Correção de Atenuação (Chang)
                new Formula
                {
                    Id = "3805",
                    CodigoCompendio = "V10-217",
                    Nome = "Correção de Atenuação Chang",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Reconstrução de Imagem",
                    Expressao = @"CF = exp(μ·d/2) (aproximação uniforme)",
                    Descricao = "μ: coeficiente atenuação, d: profundidade. Método simples SPECT. Iterativo (OSEM): melhor. PET: CT-based AC (transmission scan).",
                    ExemploPratico = "Myocardium: μ=0.15/cm (Tc-99m 140keV), d=10cm→CF=exp(0.15·10/2)≈2.1 (correção ×2). Sem AC: anterior wall brighter (artifact).",
                    Criador = "Chang (1978, attenuation correction method)",
                    AnoOrigin = "1978",
                    VariavelResultado = "CF",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "μ (1/cm)", Simbolo = "mu", Unidade = "1/cm", ValorPadrao = 0.15, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "d profundidade (cm)", Simbolo = "d", Unidade = "cm", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double mu = inputs["μ (1/cm)"];
                        double d = inputs["d profundidade (cm)"];
                        
                        double CF = Math.Exp(mu * d / 2);
                        return CF;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-218: Dose Efetiva (mSv)
                new Formula
                {
                    Id = "3806",
                    CodigoCompendio = "V10-218",
                    Nome = "Dose Efetiva E (mSv)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Dosimetria e Proteção",
                    Expressao = @"E = Σ(w_T·H_T); w_T: fator ponderação tecido",
                    Descricao = "Risco câncer. w_T: gônadas=0.08, medula=0.12, mama=0.12, etc. Typical: FDG-PET ~5-7 mSv. Bone scan: ~4-6 mSv. CT: ~5-15 mSv.",
                    ExemploPratico = "FDG 370 MBq: E≈7 mSv (todo corpo). CT abdomen: ~10 mSv. Risco: ~0.05%/Sv câncer fatal→7 mSv≈0.035% risco incremental. Natural background: 2.4 mSv/ano.",
                    Criador = "ICRP 60 (1990, dose efetiva); ICRP 103 (2007, w_T updated)",
                    AnoOrigin = "1990",
                    VariavelResultado = "E",
                    UnidadeResultado = "mSv",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ΣwH (mSv)", Simbolo = "sum_wH", Unidade = "mSv", ValorPadrao = 7, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double E = inputs["ΣwH (mSv)"];
                        return E;
                    },
                    Icone = "☢️",
                    Unidades = "",
                },

                // V10-219: Sensibilidade Diagnóstica
                new Formula
                {
                    Id = "3807",
                    CodigoCompendio = "V10-219",
                    Nome = "Sensibilidade e Especificidade (Diagnóstico)",
                    Categoria = "Medicina Nuclear",
                    SubCategoria = "Estatística Diagnóstica",
                    Expressao = @"Sens = TP/(TP+FN); Spec = TN/(TN+FP)",
                    Descricao = "TP: true positive, FN: false negative. ROC curve: Sens vs (1−Spec). AUC: area under ROC (0.5=random, 1.0=perfect).",
                    ExemploPratico = "PET câncer pulmão: 100 casos, 80 TP, 5 FN, 10 TN, 5 FP→Sens=80/85≈94%, Spec=10/15≈67%. PPV=80/85≈94%. AUC PET~0.9 (excellent).",
                    Criador = "Conceitos estatística clássica (anos 1950s); ROC (Peterson-Birdsall 1954, signal detection)",
                    AnoOrigin = "1954",
                    VariavelResultado = "Sens",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "TP", Simbolo = "TP", Unidade = "", ValorPadrao = 80, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "FN", Simbolo = "FN", Unidade = "", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double TP = inputs["TP"];
                        double FN = inputs["FN"];
                        
                        double total_pos = TP + FN;
                        if (total_pos == 0) return 0;
                        
                        double Sens = (TP / total_pos) * 100;
                        return Sens;
                    },
                    Icone = "☢️",
                    Unidades = "",
                }
            });
        }
    }
}
