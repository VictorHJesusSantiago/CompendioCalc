using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XVII
    /// QUÍMICA VERDE E SUSTENTABILIDADE QUÍMICA
    /// Fórmulas V10-319 a V10-337 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_GreenChemistry()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3907",
                    CodigoCompendio = "V10-319",
                    Nome = "Economia Atômica (Atom Economy)",
                    Categoria = "Química Verde",
                    SubCategoria = "Eficiência de Reação",
                    Expressao = @"AE = (MM_produto)/(ΣMM_reagentes) × 100%",
                    Descricao = "Mede eficiência: quanto da massa de reagentes vira produto desejado. AE=100%: ideal (adição). Reactions com resíduos: AE baixo.",
                    ExemploPratico = "Síntese Diels-Alder: AE~100%. Wittig com subproduto óxido fosfina: AE~50%. Favorece rotas sustentáveis.",
                    Criador = "Trost (1991, Science, conceito de economia atômica)",
                    AnoOrigin = "1991",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "MM produto (g/mol)", Simbolo = "MM_p", Unidade = "g/mol", ValorPadrao = 100 },
                        new Variavel { Nome = "Σ MM reagentes (g/mol)", Simbolo = "MM_r", Unidade = "g/mol", ValorPadrao = 150 }
                    },
                    VariavelResultado = "AE",
                    UnidadeResultado = "%",
                    Calcular = inputs =>
                    {
                        double MM_produto = inputs["MM produto (g/mol)"];
                        double MM_reagentes = inputs["Σ MM reagentes (g/mol)"];
                        
                        double AE = (MM_produto / Math.Max(MM_reagentes, 1)) * 100;
                        return AE;
                    },
                    Icone = "🌱"
                },

                // V10-320: Fator E (Sheldon)
                new Formula
                {
                    Id = "3908",
                    CodigoCompendio = "V10-320",
                    Nome = "Fator E (Sheldon)",
                    Categoria = "Química Verde",
                    SubCategoria = "Métricas de Resíduos",
                    Expressao = @"E = m_resíduo / m_produto",
                    Descricao = "Massa de resíduos por massa produto. Ideal E=0. Petroquímica bulk: E<1. Fine chemicals: E~5-50. Farmacêutica: E~25-100+.",
                    ExemploPratico = "Produção API: 500 kg resíduo, 20 kg produto → E=25 (alto). Processo otimizado: 120/20=6 (melhora 76%).",
                    Criador = "Roger Sheldon (1992, Green Chemistry metrics)",
                    AnoOrigin = "1992",
                    VariavelResultado = "E",
                    UnidadeResultado = "kg/kg",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_resíduo (kg)", Simbolo = "m_r", Unidade = "kg", ValorPadrao = 500 },
                        new Variavel { Nome = "m_produto (kg)", Simbolo = "m_p", Unidade = "kg", ValorPadrao = 20 }
                    },
                    Calcular = inputs =>
                    {
                        double m_r = inputs["m_resíduo (kg)"];
                        double m_p = inputs["m_produto (kg)"];
                        if (m_p <= 0) return 0;
                        return m_r / m_p;
                    },
                    Icone = "🌱"
                },

                // V10-321: PMI Process Mass Intensity
                new Formula
                {
                    Id = "3909",
                    CodigoCompendio = "V10-321",
                    Nome = "PMI — Process Mass Intensity",
                    Categoria = "Química Verde",
                    SubCategoria = "Métricas de Processo",
                    Expressao = @"PMI = m_total_entradas / m_produto",
                    Descricao = "Inclui reagentes, solventes, água, auxiliares. PMI mínimo ideal=1. Relação: PMI=E+1 (sem recuperar solventes).",
                    ExemploPratico = "Entradas totais 1500 kg, produto 50 kg → PMI=30. Meta industrial moderna API: PMI<20.",
                    Criador = "ACS GCI Pharmaceutical Roundtable",
                    AnoOrigin = "2008",
                    VariavelResultado = "PMI",
                    UnidadeResultado = "kg/kg",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_total entradas (kg)", Simbolo = "m_in", Unidade = "kg", ValorPadrao = 1500 },
                        new Variavel { Nome = "m_produto (kg)", Simbolo = "m_p", Unidade = "kg", ValorPadrao = 50 }
                    },
                    Calcular = inputs =>
                    {
                        double m_in = inputs["m_total entradas (kg)"];
                        double m_p = inputs["m_produto (kg)"];
                        if (m_p <= 0) return 0;
                        return m_in / m_p;
                    },
                    Icone = "🌱"
                },

                // V10-322: RME Reaction Mass Efficiency
                new Formula
                {
                    Id = "3910",
                    CodigoCompendio = "V10-322",
                    Nome = "RME — Reaction Mass Efficiency",
                    Categoria = "Química Verde",
                    SubCategoria = "Eficiência de Reação",
                    Expressao = @"RME = (m_produto / Σm_reagentes) × 100%",
                    Descricao = "Combina economia atômica e rendimento real. RME baixa indica perdas estequiométricas + operacionais.",
                    ExemploPratico = "Produto 80 g a partir de 200 g reagentes → RME=40%. Se melhorar rendimento para 120 g, RME=60%.",
                    Criador = "Curzons et al. (Green Chemistry metrics)",
                    AnoOrigin = "2001",
                    VariavelResultado = "RME",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_produto (g)", Simbolo = "m_p", Unidade = "g", ValorPadrao = 80 },
                        new Variavel { Nome = "Σm_reagentes (g)", Simbolo = "m_r", Unidade = "g", ValorPadrao = 200 }
                    },
                    Calcular = inputs =>
                    {
                        double m_p = inputs["m_produto (g)"];
                        double m_r = inputs["Σm_reagentes (g)"];
                        if (m_r <= 0) return 0;
                        return 100 * m_p / m_r;
                    },
                    Icone = "🌱"
                },

                // V10-323: EcoScale
                new Formula
                {
                    Id = "3911",
                    CodigoCompendio = "V10-323",
                    Nome = "EcoScale de Síntese",
                    Categoria = "Química Verde",
                    SubCategoria = "Avaliação Global",
                    Expressao = @"EcoScale = 100 − Σpenalidades",
                    Descricao = "Penalidades por baixo rendimento, reagentes perigosos, solventes tóxicos, energia alta e purificação complexa.",
                    ExemploPratico = "Penalidades totais 28 → EcoScale=72 (aceitável). >75 excelente, 50-75 razoável, <50 ruim.",
                    Criador = "Van Aken, Strekowski, Patiny",
                    AnoOrigin = "2006",
                    VariavelResultado = "EcoScale",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Σ penalidades", Simbolo = "P", Unidade = "", ValorPadrao = 28 }
                    },
                    Calcular = inputs =>
                    {
                        double P = inputs["Σ penalidades"];
                        return Math.Max(0, 100 - P);
                    },
                    Icone = "🌱"
                },

                // V10-324: Eficiência Energética
                new Formula
                {
                    Id = "3912",
                    CodigoCompendio = "V10-324",
                    Nome = "Intensidade Energética do Processo",
                    Categoria = "Química Verde",
                    SubCategoria = "Energia",
                    Expressao = @"EI = E_consumida / m_produto",
                    Descricao = "Energia específica por kg de produto. Reduzir aquecimento/refrigeração e tempo de processo melhora sustentabilidade.",
                    ExemploPratico = "500 kWh para 25 kg de produto → EI=20 kWh/kg. Novo processo contínuo: 9 kWh/kg.",
                    Criador = "Métricas de processo químico",
                    AnoOrigin = "2000",
                    VariavelResultado = "EI",
                    UnidadeResultado = "kWh/kg",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "E consumida (kWh)", Simbolo = "E", Unidade = "kWh", ValorPadrao = 500 },
                        new Variavel { Nome = "m_produto (kg)", Simbolo = "m_p", Unidade = "kg", ValorPadrao = 25 }
                    },
                    Calcular = inputs =>
                    {
                        double E = inputs["E consumida (kWh)"];
                        double m_p = inputs["m_produto (kg)"];
                        if (m_p <= 0) return 0;
                        return E / m_p;
                    },
                    Icone = "🌱"
                },

                // V10-325: Carbon Intensity
                new Formula
                {
                    Id = "3913",
                    CodigoCompendio = "V10-325",
                    Nome = "Intensidade de Carbono",
                    Categoria = "Química Verde",
                    SubCategoria = "Pegada de Carbono",
                    Expressao = @"CI = CO₂e_total / m_produto",
                    Descricao = "Emissões totais normalizadas por massa de produto. Inclui escopos de energia e matérias-primas (LCA simplificado).",
                    ExemploPratico = "Emissões 12 tCO₂e para 4 t produto → CI=3 kgCO₂e/kg. Meta corporativa: <1.5 kgCO₂e/kg.",
                    Criador = "ISO 14067 / GHG Protocol",
                    AnoOrigin = "2013",
                    VariavelResultado = "CI",
                    UnidadeResultado = "kgCO₂e/kg",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "CO₂e total (kg)", Simbolo = "co2", Unidade = "kg", ValorPadrao = 12000 },
                        new Variavel { Nome = "m_produto (kg)", Simbolo = "m_p", Unidade = "kg", ValorPadrao = 4000 }
                    },
                    Calcular = inputs =>
                    {
                        double co2 = inputs["CO₂e total (kg)"];
                        double m_p = inputs["m_produto (kg)"];
                        if (m_p <= 0) return 0;
                        return co2 / m_p;
                    },
                    Icone = "🌱"
                },

                // V10-326: Solvent Intensity
                new Formula
                {
                    Id = "3914",
                    CodigoCompendio = "V10-326",
                    Nome = "Intensidade de Solvente",
                    Categoria = "Química Verde",
                    SubCategoria = "Solventes",
                    Expressao = @"SI = m_solventes / m_produto",
                    Descricao = "Métrica crítica na indústria farmacêutica, onde solventes dominam PMI. Recuperação e troca por solventes verdes reduzem SI.",
                    ExemploPratico = "900 kg solvente para 30 kg API → SI=30 kg/kg. Com reciclo 70%: SI efetivo≈9.",
                    Criador = "ACS GCI solvent metrics",
                    AnoOrigin = "2010",
                    VariavelResultado = "SI",
                    UnidadeResultado = "kg/kg",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_solventes (kg)", Simbolo = "m_s", Unidade = "kg", ValorPadrao = 900 },
                        new Variavel { Nome = "m_produto (kg)", Simbolo = "m_p", Unidade = "kg", ValorPadrao = 30 }
                    },
                    Calcular = inputs =>
                    {
                        double m_s = inputs["m_solventes (kg)"];
                        double m_p = inputs["m_produto (kg)"];
                        if (m_p <= 0) return 0;
                        return m_s / m_p;
                    },
                    Icone = "🌱"
                },

                // V10-327: Recuperação de Solvente
                new Formula
                {
                    Id = "3915",
                    CodigoCompendio = "V10-327",
                    Nome = "Taxa de Recuperação de Solvente",
                    Categoria = "Química Verde",
                    SubCategoria = "Solventes",
                    Expressao = @"Rec (%) = (m_recuperado / m_usado) × 100",
                    Descricao = "Recuperação por destilação/adsorção reduz custo e E-factor. Valores industriais típicos: 60-95% dependendo do sistema.",
                    ExemploPratico = "Usado 500 kg, recuperado 375 kg → 75% recuperação. Perda 125 kg vira resíduo/emissão.",
                    Criador = "Engenharia de processos químicos",
                    AnoOrigin = "1980",
                    VariavelResultado = "Rec",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_recuperado (kg)", Simbolo = "m_rec", Unidade = "kg", ValorPadrao = 375 },
                        new Variavel { Nome = "m_usado (kg)", Simbolo = "m_use", Unidade = "kg", ValorPadrao = 500 }
                    },
                    Calcular = inputs =>
                    {
                        double m_rec = inputs["m_recuperado (kg)"];
                        double m_use = inputs["m_usado (kg)"];
                        if (m_use <= 0) return 0;
                        return 100 * m_rec / m_use;
                    },
                    Icone = "🌱"
                },

                // V10-328: Toxicidade Aguda LD50
                new Formula
                {
                    Id = "3916",
                    CodigoCompendio = "V10-328",
                    Nome = "Índice de Perigo por LD50",
                    Categoria = "Química Verde",
                    SubCategoria = "Toxicologia",
                    Expressao = @"HI = 1 / LD50",
                    Descricao = "Quanto menor LD50 (mg/kg), maior perigo agudo. Métrica simplificada para comparar rotas/reagentes quanto a toxicidade.",
                    ExemploPratico = "Reagente A LD50=50 mg/kg → HI=0.02. Reagente B LD50=500 mg/kg → HI=0.002 (10x menos perigoso).",
                    Criador = "Toxicologia regulatória",
                    AnoOrigin = "1950",
                    VariavelResultado = "HI",
                    UnidadeResultado = "kg/mg",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "LD50 (mg/kg)", Simbolo = "LD50", Unidade = "mg/kg", ValorPadrao = 50 }
                    },
                    Calcular = inputs =>
                    {
                        double ld50 = inputs["LD50 (mg/kg)"];
                        if (ld50 <= 0) return 0;
                        return 1.0 / ld50;
                    },
                    Icone = "🌱"
                },

                // V10-329: Catalytic Efficiency Gain
                new Formula
                {
                    Id = "3917",
                    CodigoCompendio = "V10-329",
                    Nome = "Ganho por Catálise",
                    Categoria = "Química Verde",
                    SubCategoria = "Catálise",
                    Expressao = @"G(%) = ((Y_cat − Y_base)/Y_base) × 100",
                    Descricao = "Catálise aumenta rendimento e seletividade, reduz subprodutos e energia de ativação. Um dos 12 princípios de química verde.",
                    ExemploPratico = "Rota sem catalisador: 62%. Com catalisador: 88% → ganho=41.9%.",
                    Criador = "Princípios de Green Chemistry (Anastas & Warner)",
                    AnoOrigin = "1998",
                    VariavelResultado = "G",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Rendimento base (%)", Simbolo = "Yb", Unidade = "%", ValorPadrao = 62 },
                        new Variavel { Nome = "Rendimento catalítico (%)", Simbolo = "Yc", Unidade = "%", ValorPadrao = 88 }
                    },
                    Calcular = inputs =>
                    {
                        double Yb = inputs["Rendimento base (%)"];
                        double Yc = inputs["Rendimento catalítico (%)"];
                        if (Yb <= 0) return 0;
                        return 100 * (Yc - Yb) / Yb;
                    },
                    Icone = "🌱"
                },

                // V10-330: Renewable Carbon Index
                new Formula
                {
                    Id = "3918",
                    CodigoCompendio = "V10-330",
                    Nome = "Índice de Carbono Renovável",
                    Categoria = "Química Verde",
                    SubCategoria = "Feedstocks Renováveis",
                    Expressao = @"RCI = (C_renovável / C_total) × 100%",
                    Descricao = "Percentual de carbono de origem renovável (biomassa, CO₂ biogênico) na molécula/produto final.",
                    ExemploPratico = "Produto com 12 átomos C, sendo 9 de biomassa → RCI=75%.",
                    Criador = "Métricas de bio-based chemistry",
                    AnoOrigin = "2010",
                    VariavelResultado = "RCI",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "C renovável (mol C)", Simbolo = "Cr", Unidade = "mol", ValorPadrao = 9 },
                        new Variavel { Nome = "C total (mol C)", Simbolo = "Ct", Unidade = "mol", ValorPadrao = 12 }
                    },
                    Calcular = inputs =>
                    {
                        double Cr = inputs["C renovável (mol C)"];
                        double Ct = inputs["C total (mol C)"];
                        if (Ct <= 0) return 0;
                        return 100 * Cr / Ct;
                    },
                    Icone = "🌱"
                },

                // V10-331: Water Intensity
                new Formula
                {
                    Id = "3919",
                    CodigoCompendio = "V10-331",
                    Nome = "Intensidade Hídrica",
                    Categoria = "Química Verde",
                    SubCategoria = "Recursos",
                    Expressao = @"WI = V_água / m_produto",
                    Descricao = "Consumo de água por massa de produto. Considera água de processo, lavagem e utilidades quando aplicável.",
                    ExemploPratico = "Processo usa 120 m³ para 40 t produto → WI=3 m³/t (0.003 m³/kg).",
                    Criador = "Métricas ESG industriais",
                    AnoOrigin = "2015",
                    VariavelResultado = "WI",
                    UnidadeResultado = "m³/t",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "V_água (m³)", Simbolo = "Vw", Unidade = "m³", ValorPadrao = 120 },
                        new Variavel { Nome = "m_produto (t)", Simbolo = "mp", Unidade = "t", ValorPadrao = 40 }
                    },
                    Calcular = inputs =>
                    {
                        double Vw = inputs["V_água (m³)"];
                        double mp = inputs["m_produto (t)"];
                        if (mp <= 0) return 0;
                        return Vw / mp;
                    },
                    Icone = "🌱"
                },

                // V10-332: Biodegradabilidade
                new Formula
                {
                    Id = "3920",
                    CodigoCompendio = "V10-332",
                    Nome = "Índice BOD/COD",
                    Categoria = "Química Verde",
                    SubCategoria = "Impacto Ambiental",
                    Expressao = @"BI = BOD5 / COD",
                    Descricao = "Indicador de biodegradabilidade de efluentes. BI>0.4: boa biodegradabilidade. BI<0.2: recalcitrante.",
                    ExemploPratico = "BOD5=180 mg/L e COD=400 mg/L → BI=0.45 (tratamento biológico favorável).",
                    Criador = "Engenharia sanitária",
                    AnoOrigin = "1970",
                    VariavelResultado = "BI",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "BOD5 (mg/L)", Simbolo = "BOD", Unidade = "mg/L", ValorPadrao = 180 },
                        new Variavel { Nome = "COD (mg/L)", Simbolo = "COD", Unidade = "mg/L", ValorPadrao = 400 }
                    },
                    Calcular = inputs =>
                    {
                        double BOD = inputs["BOD5 (mg/L)"];
                        double COD = inputs["COD (mg/L)"];
                        if (COD <= 0) return 0;
                        return BOD / COD;
                    },
                    Icone = "🌱"
                },

                // V10-333: Yield-Corrected AE
                new Formula
                {
                    Id = "3921",
                    CodigoCompendio = "V10-333",
                    Nome = "Economia Atômica Corrigida por Rendimento",
                    Categoria = "Química Verde",
                    SubCategoria = "Eficiência de Reação",
                    Expressao = @"AE_corr = AE × (Y/100)",
                    Descricao = "Combina desenho estequiométrico (AE) com desempenho prático (rendimento real).",
                    ExemploPratico = "AE=82% e rendimento Y=75% → AE_corr=61.5%.",
                    Criador = "Métricas combinadas em Green Chemistry",
                    AnoOrigin = "2005",
                    VariavelResultado = "AEcorr",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "AE (%)", Simbolo = "AE", Unidade = "%", ValorPadrao = 82 },
                        new Variavel { Nome = "Rendimento Y (%)", Simbolo = "Y", Unidade = "%", ValorPadrao = 75 }
                    },
                    Calcular = inputs =>
                    {
                        double AE = inputs["AE (%)"];
                        double Y = inputs["Rendimento Y (%)"];
                        return AE * (Y / 100.0);
                    },
                    Icone = "🌱"
                },

                // V10-334: Solvent Selection Score
                new Formula
                {
                    Id = "3922",
                    CodigoCompendio = "V10-334",
                    Nome = "Score de Seleção de Solvente",
                    Categoria = "Química Verde",
                    SubCategoria = "Solventes",
                    Expressao = @"SS = w_H·H + w_S·S + w_E·E",
                    Descricao = "Score ponderado de critérios de Saúde (H), Segurança (S) e Ambiente (E). Escalas 0-10; menor é melhor.",
                    ExemploPratico = "H=3, S=2, E=4; pesos 0.4/0.3/0.3 → SS=2.9 (bom). Solvente alternativo com SS=1.8 é preferível.",
                    Criador = "Guias GSK/Pfizer solvent selection",
                    AnoOrigin = "2007",
                    VariavelResultado = "SS",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "H (0-10)", Simbolo = "H", Unidade = "", ValorPadrao = 3 },
                        new Variavel { Nome = "S (0-10)", Simbolo = "S", Unidade = "", ValorPadrao = 2 },
                        new Variavel { Nome = "E (0-10)", Simbolo = "E", Unidade = "", ValorPadrao = 4 },
                        new Variavel { Nome = "w_H", Simbolo = "wH", Unidade = "", ValorPadrao = 0.4 },
                        new Variavel { Nome = "w_S", Simbolo = "wS", Unidade = "", ValorPadrao = 0.3 },
                        new Variavel { Nome = "w_E", Simbolo = "wE", Unidade = "", ValorPadrao = 0.3 }
                    },
                    Calcular = inputs =>
                    {
                        double H = inputs["H (0-10)"];
                        double S = inputs["S (0-10)"];
                        double E = inputs["E (0-10)"];
                        double wH = inputs["w_H"];
                        double wS = inputs["w_S"];
                        double wE = inputs["w_E"];
                        return wH * H + wS * S + wE * E;
                    },
                    Icone = "🌱"
                },

                // V10-335: Environmental Quotient (EQ)
                new Formula
                {
                    Id = "3923",
                    CodigoCompendio = "V10-335",
                    Nome = "Quociente Ambiental (EQ)",
                    Categoria = "Química Verde",
                    SubCategoria = "Métricas de Impacto",
                    Expressao = @"EQ = E-factor × Q",
                    Descricao = "Q representa periculosidade do resíduo (1 baixo, >100 alto). Integra quantidade e qualidade do resíduo.",
                    ExemploPratico = "E=8 e Q=25 → EQ=200. Reduzir solvente tóxico (Q) pode derrubar EQ sem alterar massa total.",
                    Criador = "Sheldon (Environmental Quotient)",
                    AnoOrigin = "1994",
                    VariavelResultado = "EQ",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "E-factor", Simbolo = "E", Unidade = "", ValorPadrao = 8 },
                        new Variavel { Nome = "Q periculosidade", Simbolo = "Q", Unidade = "", ValorPadrao = 25 }
                    },
                    Calcular = inputs =>
                    {
                        double E = inputs["E-factor"];
                        double Q = inputs["Q periculosidade"];
                        return E * Q;
                    },
                    Icone = "🌱"
                },

                // V10-336: Circularity Index
                new Formula
                {
                    Id = "3924",
                    CodigoCompendio = "V10-336",
                    Nome = "Índice de Circularidade",
                    Categoria = "Química Verde",
                    SubCategoria = "Economia Circular",
                    Expressao = @"CI = (m_reuso + m_reciclo) / m_total",
                    Descricao = "Percentual de massa reinserida no processo/cadeia. CI próximo de 1 indica operação circular.",
                    ExemploPratico = "Reuso 300 kg + reciclo 200 kg em fluxo total 800 kg → CI=0.625 (62.5%).",
                    Criador = "Métricas de economia circular",
                    AnoOrigin = "2016",
                    VariavelResultado = "CI",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "m_reuso (kg)", Simbolo = "mr", Unidade = "kg", ValorPadrao = 300 },
                        new Variavel { Nome = "m_reciclo (kg)", Simbolo = "mc", Unidade = "kg", ValorPadrao = 200 },
                        new Variavel { Nome = "m_total (kg)", Simbolo = "mt", Unidade = "kg", ValorPadrao = 800 }
                    },
                    Calcular = inputs =>
                    {
                        double mr = inputs["m_reuso (kg)"];
                        double mc = inputs["m_reciclo (kg)"];
                        double mt = inputs["m_total (kg)"];
                        if (mt <= 0) return 0;
                        return (mr + mc) / mt;
                    },
                    Icone = "🌱"
                },

                // V10-337: Compliance 12 Principles Score
                new Formula
                {
                    Id = "3925",
                    CodigoCompendio = "V10-337",
                    Nome = "Score dos 12 Princípios",
                    Categoria = "Química Verde",
                    SubCategoria = "Governança",
                    Expressao = @"Score = (Σitens_atendidos / 12) × 100%",
                    Descricao = "Avaliação simplificada de aderência aos 12 princípios de Anastas e Warner para rota/processo químico.",
                    ExemploPratico = "Processo atende 9 de 12 princípios → 75% de aderência.",
                    Criador = "Anastas & Warner",
                    AnoOrigin = "1998",
                    VariavelResultado = "Score",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Itens atendidos (0-12)", Simbolo = "n", Unidade = "", ValorPadrao = 9 }
                    },
                    Calcular = inputs =>
                    {
                        double n = inputs["Itens atendidos (0-12)"];
                        if (n < 0) n = 0;
                        if (n > 12) n = 12;
                        return 100 * n / 12.0;
                    },
                    Icone = "🌱"
                }
            });
        }
    }
}
