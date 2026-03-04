using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 7 — PARTE III: AGRO-AMBIENTE (26 fórmulas)
    //  Agronomia (5), Ciências Florestais (7), Eng. Ambiental (8), Epidemiologia (6)
    // ═══════════════════════════════════════════════════════════════

    private void AdicionarVol7AgroAmbiente()
    {
        _formulas.AddRange([
            // ═══ AGRONOMIA (5 fórmulas) ═══

            // ── 038 Evapotranspiração (Penman-Monteith) ──
            new Formula
            {
                Id = "7_agr01", Nome = "Evapotranspiração de Referência (ET₀)", Categoria = "Agronomia",
                Expressao = "ET₀ = (0.408·Δ·(Rn−G) + γ·(900/(T+273))·u₂·(es−ea)) / (Δ + γ·(1+0.34·u₂))",
                ExprTexto = "ET₀ simplificada: Δ(Rn−G)+γ·900·u₂·deficit / [Δ+γ(1+0,34u₂)]/(T+273)",
                Icone = "ET₀",
                Descricao = "Evapotranspiração de referência (FAO-56 Penman-Monteith). Estima demanda hídrica de cultura hipotética. Base para irrigação.",
                Criador = "FAO-56; Allen, Pereira, Raes & Smith (1998)",
                AnoOrigin = "1998",
                ExemploPratico = "Dia típico tropical: ET₀ ≈ 4-6 mm/dia",
                Variaveis = [
                    new() { Simbolo = "Rn", Nome = "Radiação líquida (MJ/m²/dia)", ValorPadrao = 15 },
                    new() { Simbolo = "T", Nome = "Temperatura média (°C)", ValorPadrao = 25 },
                    new() { Simbolo = "u2", Nome = "Vel. vento a 2m (m/s)", ValorPadrao = 2 },
                    new() { Simbolo = "deficit", Nome = "Déficit pressão vapor (kPa)", Descricao = "eₛ − eₐ", ValorPadrao = 1.5 },
                    new() { Simbolo = "delta", Nome = "Declividade curva pressão (Δ)", Descricao = "kPa/°C", ValorPadrao = 0.189 },
                    new() { Simbolo = "gamma", Nome = "Constante psicrométrica (γ)", Descricao = "kPa/°C", ValorPadrao = 0.067 },
                ],
                VariavelResultado = "ET₀ (mm/dia)",
                UnidadeResultado = "mm/dia",
                Calcular = vars => {
                    double d = vars["delta"], Rn = vars["Rn"], g = vars["gamma"], T = vars["T"];
                    double u2 = vars["u2"], def = vars["deficit"];
                    double num = 0.408 * d * Rn + g * (900.0 / (T + 273)) * u2 * def;
                    double den = d + g * (1 + 0.34 * u2);
                    return num / den;
                }
            },
            // ── 039 Produtividade da Água ──
            new Formula
            {
                Id = "7_agr02", Nome = "Produtividade da Água (WP)", Categoria = "Agronomia",
                Expressao = "WP = Y / ET",
                ExprTexto = "WP = Produtividade / Evapotranspiração",
                Icone = "WP",
                Descricao = "Eficiência do uso da água: produção de biomassa ou grão por unidade de água evapotranspirada. Indicador de sustentabilidade agrícola.",
                Criador = "Conceito FAO; Molden (1997)",
                AnoOrigin = "1997",
                ExemploPratico = "Milho: 8 ton/ha, ET=500 mm: WP = 8000/500 = 16 kg/m³",
                Variaveis = [
                    new() { Simbolo = "Y", Nome = "Produtividade (kg/ha)", ValorPadrao = 8000 },
                    new() { Simbolo = "ET", Nome = "Evapotranspiração (mm)", ValorPadrao = 500, ValorMin = 1 },
                ],
                VariavelResultado = "WP",
                UnidadeResultado = "kg/ha/mm",
                Calcular = vars => vars["Y"] / vars["ET"]
            },
            // ── 040 Necessidade de Calagem (PRNT) ──
            new Formula
            {
                Id = "7_agr03", Nome = "Necessidade de Calagem", Categoria = "Agronomia",
                Expressao = "NC = (V₂ − V₁) · CTC / (10 · PRNT)",
                ExprTexto = "NC (t/ha) = (V₂ − V₁) × CTC / (10 × PRNT)",
                Icone = "pH↑",
                Descricao = "Calcula toneladas de calcário por hectare para elevar a saturação por bases (V%) ao nível desejado. PRNT corrige eficiência do calcário.",
                Criador = "Método da saturação por bases; Raij et al. (1996)",
                AnoOrigin = "1996",
                ExemploPratico = "V₁=40%, V₂=70%, CTC=10 cmolc/dm³, PRNT=80%: NC = (70-40)×10/(10×80) = 0,375 → ~3,75 t/ha",
                Variaveis = [
                    new() { Simbolo = "V2", Nome = "V% desejada", Descricao = "Saturação por bases alvo (%)", ValorPadrao = 70 },
                    new() { Simbolo = "V1", Nome = "V% atual", Descricao = "Saturação por bases atual (%)", ValorPadrao = 40 },
                    new() { Simbolo = "CTC", Nome = "CTC (cmolc/dm³)", Descricao = "Capacidade de troca catiônica", ValorPadrao = 10 },
                    new() { Simbolo = "PRNT", Nome = "PRNT (%)", Descricao = "Poder Relativo Neutralização Total", ValorPadrao = 80, ValorMin = 1 },
                ],
                VariavelResultado = "NC (t/ha)",
                UnidadeResultado = "t/ha",
                Calcular = vars => (vars["V2"] - vars["V1"]) * vars["CTC"] / (10 * vars["PRNT"])
            },
            // ── 041 Equação Universal de Perda de Solo (USLE) ──
            new Formula
            {
                Id = "7_agr04", Nome = "Perda de Solo (USLE)", Categoria = "Agronomia",
                Expressao = "A = R · K · L · S · C · P",
                ExprTexto = "A = R × K × L × S × C × P",
                Icone = "🌱",
                Descricao = "Estima perda média anual de solo por erosão hídrica. R=erosividade da chuva, K=erodibilidade do solo, LS=topográfico, C=cobertura, P=práticas conservacionistas.",
                Criador = "Wischmeier & Smith (1978); USDA",
                AnoOrigin = "1978",
                ExemploPratico = "R=600, K=0,03, LS=2,5, C=0,5, P=0,8: A = 600×0,03×2,5×0,5×0,8 = 18 t/ha/ano",
                Variaveis = [
                    new() { Simbolo = "R", Nome = "Erosividade (R)", Descricao = "MJ·mm/(ha·h·ano)", ValorPadrao = 600 },
                    new() { Simbolo = "K", Nome = "Erodibilidade (K)", Descricao = "t·h/(MJ·mm)", ValorPadrao = 0.03 },
                    new() { Simbolo = "LS", Nome = "Fator topográfico (LS)", ValorPadrao = 2.5 },
                    new() { Simbolo = "C", Nome = "Fator de cobertura (C)", ValorPadrao = 0.5 },
                    new() { Simbolo = "P", Nome = "Fator de práticas (P)", ValorPadrao = 0.8 },
                ],
                VariavelResultado = "A (t/ha/ano)",
                UnidadeResultado = "t/ha/ano",
                Calcular = vars => vars["R"] * vars["K"] * vars["LS"] * vars["C"] * vars["P"]
            },
            // ── 042 Graus-Dia Acumulados ──
            new Formula
            {
                Id = "7_agr05", Nome = "Graus-Dia Acumulados", Categoria = "Agronomia",
                Expressao = "GDD = Σ max((Tmax+Tmin)/2 − Tb, 0)",
                ExprTexto = "GDD = Σ máx[(Tmáx+Tmín)/2 − Tbase, 0]",
                Icone = "GDD",
                Descricao = "Soma térmica para previsão fenológica de culturas. Acumula graus diários acima da temperatura base (Tb) da espécie.",
                Criador = "Réaumur (1735); ampliado por McMaster & Wilhelm (1997)",
                AnoOrigin = "1735",
                ExemploPratico = "Dia: Tmax=30°C, Tmin=18°C, Tb=10°C: GDD = (30+18)/2−10 = 14 graus-dia",
                Variaveis = [
                    new() { Simbolo = "Tmax", Nome = "Temp. máxima (°C)", ValorPadrao = 30 },
                    new() { Simbolo = "Tmin", Nome = "Temp. mínima (°C)", ValorPadrao = 18 },
                    new() { Simbolo = "Tb", Nome = "Temp. base (°C)", Descricao = "Temperatura base da cultura", ValorPadrao = 10 },
                ],
                VariavelResultado = "GDD (graus-dia)",
                UnidadeResultado = "°C·dia",
                Calcular = vars => Math.Max((vars["Tmax"] + vars["Tmin"]) / 2.0 - vars["Tb"], 0)
            },

            // ═══ CIÊNCIAS FLORESTAIS (7 fórmulas) ═══

            // ── 043 DAP a partir da Circunferência ──
            new Formula
            {
                Id = "7_flo01", Nome = "DAP a partir da Circunferência", Categoria = "Ciências Florestais",
                Expressao = "DAP = CAP / π",
                ExprTexto = "DAP = CAP / π",
                Icone = "🌳",
                Descricao = "Diâmetro à Altura do Peito (1,30 m) obtido da circunferência. Parâmetro dendrométrico básico para inventário florestal.",
                Criador = "Dendrometria clássica; normas de inventário florestal",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "CAP = 94,2 cm: DAP = 94,2/π ≈ 30 cm",
                Variaveis = [
                    new() { Simbolo = "CAP", Nome = "Circunf. à Altura do Peito (cm)", ValorPadrao = 94.2 },
                ],
                VariavelResultado = "DAP (cm)",
                UnidadeResultado = "cm",
                Calcular = vars => vars["CAP"] / Math.PI
            },
            // ── 044 Área Basal ──
            new Formula
            {
                Id = "7_flo02", Nome = "Área Basal de Árvore", Categoria = "Ciências Florestais",
                Expressao = "g = π · (DAP/2)² / 10000",
                ExprTexto = "g = π × (DAP/200)² (m²)",
                Icone = "g",
                Descricao = "Seção transversal do tronco a 1,30m de altura. Expressa em m². Somando-se todas as árvores obtém-se a área basal por hectare (G).",
                Criador = "Dendrometria; mensuração florestal",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "DAP=30 cm: g = π×(0,15)² = 0,0707 m²",
                Variaveis = [
                    new() { Simbolo = "DAP", Nome = "DAP (cm)", ValorPadrao = 30 },
                ],
                VariavelResultado = "g (m²)",
                UnidadeResultado = "m²",
                Calcular = vars => Math.PI * Math.Pow(vars["DAP"] / 200.0, 2)
            },
            // ── 045 Volume de Árvore (Huber) ──
            new Formula
            {
                Id = "7_flo03", Nome = "Volume de Árvore (Huber)", Categoria = "Ciências Florestais",
                Expressao = "V = g_m · L",
                ExprTexto = "V = g (seção média) × L (comprimento)",
                Icone = "V🪵",
                Descricao = "Volume de tora pelo método de Huber: área da seção transversal no ponto médio multiplicada pelo comprimento. Simples e prático.",
                Criador = "F.X. Huber (séc. XIX); cubagem de toras",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "Seção média g=0,05 m², L=6 m: V = 0,05×6 = 0,30 m³",
                Variaveis = [
                    new() { Simbolo = "gm", Nome = "Área da seção média (m²)", ValorPadrao = 0.05 },
                    new() { Simbolo = "L", Nome = "Comprimento (m)", ValorPadrao = 6 },
                ],
                VariavelResultado = "V (m³)",
                UnidadeResultado = "m³",
                Calcular = vars => vars["gm"] * vars["L"]
            },
            // ── 046 Índice de Sítio ──
            new Formula
            {
                Id = "7_flo04", Nome = "Índice de Sítio (Chapman-Richards)", Categoria = "Ciências Florestais",
                Expressao = "H = A · (1 − e^(−b·I))^c",
                ExprTexto = "H dominante = A × (1 − e^(−b×Idade))^c",
                Icone = "IS",
                Descricao = "Modelo de crescimento em altura para classificação de sítio florestal. Parâmetros a, b, c ajustados por espécie/região.",
                Criador = "Chapman (1961) / Richards (1959)",
                AnoOrigin = "1959",
                ExemploPratico = "Eucalipto: A=35, b=0,15, c=1,3, I=7 anos: H = 35×(1−e^(−1,05))^1,3 ≈ 22,5 m",
                Variaveis = [
                    new() { Simbolo = "A", Nome = "Assíntota (A)", Descricao = "Altura máxima potencial (m)", ValorPadrao = 35 },
                    new() { Simbolo = "b", Nome = "Parâmetro b", Descricao = "Taxa de crescimento", ValorPadrao = 0.15 },
                    new() { Simbolo = "c", Nome = "Parâmetro c", Descricao = "Forma da curva", ValorPadrao = 1.3 },
                    new() { Simbolo = "I", Nome = "Idade (anos)", ValorPadrao = 7 },
                ],
                VariavelResultado = "H (m)",
                UnidadeResultado = "m",
                Calcular = vars => vars["A"] * Math.Pow(1 - Math.Exp(-vars["b"] * vars["I"]), vars["c"])
            },
            // ── 047 Incremento Médio Anual ──
            new Formula
            {
                Id = "7_flo05", Nome = "Incremento Médio Anual (IMA)", Categoria = "Ciências Florestais",
                Expressao = "IMA = V / I",
                ExprTexto = "IMA = Volume total / Idade",
                Icone = "IMA",
                Descricao = "Volume médio produzido por ano desde o plantio. O ponto de máximo IMA define a rotação técnica ótima.",
                Criador = "Silvicultura clássica; Assmann (1970)",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Eucalipto: 250 m³/ha aos 7 anos: IMA = 250/7 ≈ 35,7 m³/ha/ano",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "Volume total (m³/ha)", ValorPadrao = 250 },
                    new() { Simbolo = "I", Nome = "Idade (anos)", ValorPadrao = 7, ValorMin = 1 },
                ],
                VariavelResultado = "IMA",
                UnidadeResultado = "m³/ha/ano",
                Calcular = vars => vars["V"] / vars["I"]
            },
            // ── 048 Índice de Diversidade de Shannon ──
            new Formula
            {
                Id = "7_flo06", Nome = "Índice de Shannon-Wiener", Categoria = "Ciências Florestais",
                Expressao = "H' = −Σ(pᵢ · ln(pᵢ))",
                ExprTexto = "H' = −Σ(pᵢ × ln pᵢ)",
                Icone = "H'",
                Descricao = "Mede diversidade de espécies numa comunidade. pᵢ = proporção de indivíduos da espécie i. Valores típicos: 1,5-3,5 (florestas tropicais >4).",
                Criador = "Claude Shannon (1948); aplicado à ecologia por MacArthur",
                AnoOrigin = "1948",
                ExemploPratico = "3 espécies com p=0,5; 0,3; 0,2: H' = −(0,5×ln0,5+0,3×ln0,3+0,2×ln0,2) ≈ 1,03",
                Variaveis = [
                    new() { Simbolo = "p1", Nome = "Proporção espécie 1", ValorPadrao = 0.5 },
                    new() { Simbolo = "p2", Nome = "Proporção espécie 2", ValorPadrao = 0.3 },
                    new() { Simbolo = "p3", Nome = "Proporção espécie 3", ValorPadrao = 0.2 },
                ],
                VariavelResultado = "H'",
                Calcular = vars => {
                    double h = 0;
                    foreach (var k in new[] { "p1", "p2", "p3" })
                    {
                        double p = vars.ContainsKey(k) ? vars[k] : 0;
                        if (p > 0) h -= p * Math.Log(p);
                    }
                    return h;
                }
            },
            // ── 049 Fator de Forma ──
            new Formula
            {
                Id = "7_flo07", Nome = "Fator de Forma", Categoria = "Ciências Florestais",
                Expressao = "f = V_real / V_cilindro",
                ExprTexto = "f = Volume real / (g × h)",
                Icone = "f",
                Descricao = "Relação entre volume real da árvore e o volume do cilindro equivalente. Valores típicos: 0,40-0,70. Corrige a conicidade do tronco.",
                Criador = "Dendrometria clássica",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "V real=0,45 m³, g=0,07 m², h=12 m: f = 0,45/(0,07×12) = 0,536",
                Variaveis = [
                    new() { Simbolo = "Vreal", Nome = "Volume real (m³)", ValorPadrao = 0.45 },
                    new() { Simbolo = "g", Nome = "Área basal (m²)", ValorPadrao = 0.07 },
                    new() { Simbolo = "h", Nome = "Altura (m)", ValorPadrao = 12, ValorMin = 0.1 },
                ],
                VariavelResultado = "f",
                Calcular = vars => vars["Vreal"] / (vars["g"] * vars["h"])
            },

            // ═══ ENGENHARIA AMBIENTAL (8 fórmulas) ═══

            // ── 050 DBO (Streeter-Phelps) ──
            new Formula
            {
                Id = "7_eam01", Nome = "DBO Residual (Streeter-Phelps)", Categoria = "Engenharia Ambiental",
                Expressao = "L_t = L₀ · e^(−k₁·t)",
                ExprTexto = "Lt = L₀ × e^(−k₁t)",
                Icone = "DBO",
                Descricao = "Demanda Bioquímica de Oxigênio remanescente após tempo t. k₁ = coef. de desoxigenação. Modela autodepuração de rios.",
                Criador = "Streeter & Phelps (1925)",
                AnoOrigin = "1925",
                ExemploPratico = "L₀=300 mg/L, k₁=0,23 d⁻¹, t=5d: Lt = 300×e^(−1,15) ≈ 95 mg/L",
                Variaveis = [
                    new() { Simbolo = "L0", Nome = "DBO última (L₀, mg/L)", ValorPadrao = 300 },
                    new() { Simbolo = "k1", Nome = "Coef. desoxigenação (k₁)", Descricao = "d⁻¹", ValorPadrao = 0.23 },
                    new() { Simbolo = "t", Nome = "Tempo (dias)", ValorPadrao = 5 },
                ],
                VariavelResultado = "Lt (mg/L)",
                UnidadeResultado = "mg/L",
                Calcular = vars => vars["L0"] * Math.Exp(-vars["k1"] * vars["t"])
            },
            // ── 051 Déficit de Oxigênio ──
            new Formula
            {
                Id = "7_eam02", Nome = "Déficit de OD (Streeter-Phelps)", Categoria = "Engenharia Ambiental",
                Expressao = "D(t) = (k₁·L₀/(k₂−k₁))·(e^(−k₁t)−e^(−k₂t)) + D₀·e^(−k₂t)",
                ExprTexto = "D(t) = k₁L₀/(k₂−k₁)×(e^(−k₁t)−e^(−k₂t)) + D₀e^(−k₂t)",
                Icone = "OD",
                Descricao = "Equação clássica do déficit de oxigênio dissolvido em rios. k₂ = coef. de reaeração. Prevê o ponto crítico de menor OD.",
                Criador = "Streeter & Phelps (1925)",
                AnoOrigin = "1925",
                ExemploPratico = "Ponto crítico: tc = ln(k₂/k₁)/(k₂−k₁) para encontrar o máximo déficit",
                Variaveis = [
                    new() { Simbolo = "k1", Nome = "Coef. desoxigenação (k₁)", ValorPadrao = 0.23 },
                    new() { Simbolo = "k2", Nome = "Coef. reaeração (k₂)", ValorPadrao = 0.46 },
                    new() { Simbolo = "L0", Nome = "DBO última (L₀, mg/L)", ValorPadrao = 300 },
                    new() { Simbolo = "D0", Nome = "Déficit inicial (D₀, mg/L)", ValorPadrao = 2 },
                    new() { Simbolo = "t", Nome = "Tempo (dias)", ValorPadrao = 3 },
                ],
                VariavelResultado = "D(t) (mg/L)",
                UnidadeResultado = "mg/L",
                Calcular = vars => {
                    double k1 = vars["k1"], k2 = vars["k2"], L0 = vars["L0"], D0 = vars["D0"], t = vars["t"];
                    return (k1 * L0 / (k2 - k1)) * (Math.Exp(-k1 * t) - Math.Exp(-k2 * t)) + D0 * Math.Exp(-k2 * t);
                }
            },
            // ── 052 Índice de Qualidade da Água (IQA) ──
            new Formula
            {
                Id = "7_eam03", Nome = "Índice de Qualidade da Água (IQA)", Categoria = "Engenharia Ambiental",
                Expressao = "IQA = Π qᵢ^wᵢ",
                ExprTexto = "IQA = ∏ qᵢ^wᵢ (produtório ponderado)",
                Icone = "IQA",
                Descricao = "Índice multiplicativo de 0 a 100 usando 9 parâmetros (OD, coliformes, pH, DBO, nitrato, fosfato, turbidez, sólidos, temperatura). Pesos wᵢ normalizados.",
                Criador = "National Sanitation Foundation (NSF, 1970); adaptado pela CETESB",
                AnoOrigin = "1970",
                ExemploPratico = "IQA simplificado: q1=80(w=0,17), q2=60(w=0,15), q3=90(w=0,12)... → IQA ≈ 72 (boa)",
                Variaveis = [
                    new() { Simbolo = "q1", Nome = "Qualidade param. 1 (q₁)", ValorPadrao = 80 },
                    new() { Simbolo = "w1", Nome = "Peso param. 1 (w₁)", ValorPadrao = 0.17 },
                    new() { Simbolo = "q2", Nome = "Qualidade param. 2 (q₂)", ValorPadrao = 60 },
                    new() { Simbolo = "w2", Nome = "Peso param. 2 (w₂)", ValorPadrao = 0.15 },
                    new() { Simbolo = "q3", Nome = "Qualidade param. 3 (q₃)", ValorPadrao = 90 },
                    new() { Simbolo = "w3", Nome = "Peso param. 3 (w₃)", ValorPadrao = 0.12 },
                ],
                VariavelResultado = "IQA (parcial)",
                Calcular = vars => Math.Pow(vars["q1"], vars["w1"]) * Math.Pow(vars["q2"], vars["w2"]) * Math.Pow(vars["q3"], vars["w3"])
            },
            // ── 053 Equação de Manning (Escoamento) ──
            new Formula
            {
                Id = "7_eam04", Nome = "Equação de Manning", Categoria = "Engenharia Ambiental",
                Expressao = "Q = (A · R^(2/3) · S^(1/2)) / n",
                ExprTexto = "Q = A × R^(2/3) × S^(1/2) / n",
                Icone = "Q",
                Descricao = "Vazão em canais abertos por Manning. A=área da seção, R=raio hidráulico (A/P), S=declividade, n=rugosidade de Manning.",
                Criador = "Robert Manning (1891); Philippe Gauckler (1867)",
                AnoOrigin = "1891",
                ExemploPratico = "Canal: A=2m², R=0,5m, S=0,001, n=0,013: Q = 2×0,63×0,032/0,013 ≈ 3,06 m³/s",
                Variaveis = [
                    new() { Simbolo = "A", Nome = "Área da seção (m²)", ValorPadrao = 2 },
                    new() { Simbolo = "R", Nome = "Raio hidráulico (m)", ValorPadrao = 0.5 },
                    new() { Simbolo = "S", Nome = "Declividade (m/m)", ValorPadrao = 0.001 },
                    new() { Simbolo = "n", Nome = "Coef. Manning (n)", ValorPadrao = 0.013, ValorMin = 0.001 },
                ],
                VariavelResultado = "Q (m³/s)",
                UnidadeResultado = "m³/s",
                Calcular = vars => (vars["A"] * Math.Pow(vars["R"], 2.0 / 3.0) * Math.Sqrt(vars["S"])) / vars["n"]
            },
            // ── 054 Tempo de Detenção Hidráulico ──
            new Formula
            {
                Id = "7_eam05", Nome = "Tempo de Detenção Hidráulico", Categoria = "Engenharia Ambiental",
                Expressao = "TDH = V / Q",
                ExprTexto = "TDH = Volume / Vazão",
                Icone = "TDH",
                Descricao = "Tempo médio de permanência do líquido em um reator ou lagoa. Parâmetro fundamental no dimensionamento de ETEs.",
                Criador = "Engenharia sanitária; Von Sperling",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Lagoa de 5000 m³, vazão 500 m³/dia: TDH = 5000/500 = 10 dias",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "Volume do reator (m³)", ValorPadrao = 5000 },
                    new() { Simbolo = "Q", Nome = "Vazão (m³/dia)", ValorPadrao = 500, ValorMin = 0.1 },
                ],
                VariavelResultado = "TDH (dias)",
                UnidadeResultado = "dias",
                Calcular = vars => vars["V"] / vars["Q"]
            },
            // ── 055 Eficiência de Remoção ──
            new Formula
            {
                Id = "7_eam06", Nome = "Eficiência de Remoção", Categoria = "Engenharia Ambiental",
                Expressao = "E = (C₀ − Cf) / C₀ × 100",
                ExprTexto = "E (%) = (C₀ − Cf) / C₀ × 100",
                Icone = "E%",
                Descricao = "Percentual de remoção de poluente em um processo de tratamento. C₀ = concentração afluente, Cf = efluente.",
                Criador = "Engenharia sanitária; conceito fundamental de ETE",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "DBO: C₀=300 mg/L, Cf=30 mg/L: E = (300-30)/300×100 = 90%",
                Variaveis = [
                    new() { Simbolo = "C0", Nome = "Concentração afluente (C₀)", ValorPadrao = 300 },
                    new() { Simbolo = "Cf", Nome = "Concentração efluente (Cf)", ValorPadrao = 30 },
                ],
                VariavelResultado = "E (%)",
                UnidadeResultado = "%",
                Calcular = vars => (vars["C0"] - vars["Cf"]) / vars["C0"] * 100
            },
            // ── 056 Dispersão Atmosférica (Gaussiana) ──
            new Formula
            {
                Id = "7_eam07", Nome = "Dispersão Gaussiana de Poluentes", Categoria = "Engenharia Ambiental",
                Expressao = "C = Q/(2π·u·σy·σz) · exp(−y²/(2σy²)) · exp(−(z−H)²/(2σz²))",
                ExprTexto = "Modelo Gaussiano de pluma: C no ponto (x,y,z)",
                Icone = "🏭",
                Descricao = "Concentração de poluente a sotavento de fonte pontual elevada. Modelo de Pasquill-Gifford com parâmetros de dispersão σy e σz.",
                Criador = "Pasquill (1961); Gifford (1961)",
                AnoOrigin = "1961",
                ExemploPratico = "Chaminé H=50m, Q=100 g/s, u=5 m/s, σy=50, σz=30 (x=1km): C no eixo ≈ 21 μg/m³",
                Variaveis = [
                    new() { Simbolo = "Qe", Nome = "Taxa de emissão (g/s)", ValorPadrao = 100 },
                    new() { Simbolo = "u", Nome = "Velocidade do vento (m/s)", ValorPadrao = 5, ValorMin = 0.1 },
                    new() { Simbolo = "sy", Nome = "Dispersão horizontal σy (m)", ValorPadrao = 50 },
                    new() { Simbolo = "sz", Nome = "Dispersão vertical σz (m)", ValorPadrao = 30 },
                    new() { Simbolo = "H", Nome = "Altura efetiva (m)", ValorPadrao = 50 },
                ],
                VariavelResultado = "C (g/m³) no eixo",
                UnidadeResultado = "g/m³",
                Calcular = vars => {
                    double Q = vars["Qe"], u = vars["u"], sy = vars["sy"], sz = vars["sz"], H = vars["H"];
                    return (Q / (2 * Math.PI * u * sy * sz)) * Math.Exp(-H * H / (2 * sz * sz));
                }
            },
            // ── 057 Pegada de Carbono ──
            new Formula
            {
                Id = "7_eam08", Nome = "Pegada de Carbono", Categoria = "Engenharia Ambiental",
                Expressao = "CO₂eq = Σ(Atividade × FE)",
                ExprTexto = "CO₂eq = Σ(Atividade × Fator de Emissão)",
                Icone = "CO₂",
                Descricao = "Emissão total de gases de efeito estufa em CO₂ equivalente. FE = fator de emissão específico da atividade (energia, transporte, etc.).",
                Criador = "IPCC; GHG Protocol",
                AnoOrigin = "1997",
                ExemploPratico = "1000 kWh (FE=0,5 kgCO₂/kWh) + 500 km carro (FE=0,21 kgCO₂/km): CO₂eq = 500+105 = 605 kg",
                Variaveis = [
                    new() { Simbolo = "ativ1", Nome = "Atividade 1 (unidade)", ValorPadrao = 1000 },
                    new() { Simbolo = "FE1", Nome = "Fator de emissão 1", Descricao = "kgCO₂eq/unidade", ValorPadrao = 0.5 },
                    new() { Simbolo = "ativ2", Nome = "Atividade 2 (unidade)", ValorPadrao = 500 },
                    new() { Simbolo = "FE2", Nome = "Fator de emissão 2", ValorPadrao = 0.21 },
                ],
                VariavelResultado = "CO₂eq (kg)",
                UnidadeResultado = "kgCO₂eq",
                Calcular = vars => vars["ativ1"] * vars["FE1"] + vars["ativ2"] * vars["FE2"]
            },

            // ═══ EPIDEMIOLOGIA (6 fórmulas) ═══

            // ── 058 Modelo SIR ──
            new Formula
            {
                Id = "7_epi01", Nome = "Modelo SIR (Equações)", Categoria = "Epidemiologia",
                Expressao = "dS/dt = −β·S·I/N;  dI/dt = β·S·I/N − γ·I;  dR/dt = γ·I",
                ExprTexto = "SIR: β transmissão, γ recuperação, N população",
                Icone = "SIR",
                Descricao = "Modelo compartimental SIR de Kermack-McKendrick. S=suscetíveis, I=infectados, R=recuperados. Fundamento da epidemiologia matemática.",
                Criador = "Kermack & McKendrick (1927)",
                AnoOrigin = "1927",
                ExemploPratico = "N=10000, β=0,3, γ=0,1, I₀=10: dI/dt positivo → epidemia cresce (R₀=3)",
                Variaveis = [
                    new() { Simbolo = "beta", Nome = "Taxa de transmissão (β)", ValorPadrao = 0.3 },
                    new() { Simbolo = "gamma", Nome = "Taxa de recuperação (γ)", ValorPadrao = 0.1 },
                    new() { Simbolo = "S", Nome = "Suscetíveis (S)", ValorPadrao = 9990 },
                    new() { Simbolo = "I", Nome = "Infectados (I)", ValorPadrao = 10 },
                    new() { Simbolo = "N", Nome = "População total (N)", ValorPadrao = 10000, ValorMin = 1 },
                ],
                VariavelResultado = "dI/dt",
                Calcular = vars => vars["beta"] * vars["S"] * vars["I"] / vars["N"] - vars["gamma"] * vars["I"]
            },
            // ── 059 Número Reprodutivo Básico ──
            new Formula
            {
                Id = "7_epi02", Nome = "Número Reprodutivo Básico (R₀)", Categoria = "Epidemiologia",
                Expressao = "R₀ = β / γ",
                ExprTexto = "R₀ = β / γ",
                Icone = "R₀",
                Descricao = "Número médio de infecções secundárias por caso em população suscetível. R₀>1: epidemia cresce; R₀<1: epidemia extingue.",
                Criador = "Kermack & McKendrick; popularizado por Anderson & May",
                AnoOrigin = "1927",
                ExemploPratico = "COVID-19 (cepa original): β≈0,4, γ≈0,14 → R₀ ≈ 2,9",
                Variaveis = [
                    new() { Simbolo = "beta", Nome = "Taxa de transmissão (β)", ValorPadrao = 0.4 },
                    new() { Simbolo = "gamma", Nome = "Taxa de recuperação (γ)", ValorPadrao = 0.14, ValorMin = 0.001 },
                ],
                VariavelResultado = "R₀",
                Calcular = vars => vars["beta"] / vars["gamma"]
            },
            // ── 060 Equilíbrio de Hardy-Weinberg ──
            new Formula
            {
                Id = "7_epi03", Nome = "Equilíbrio de Hardy-Weinberg", Categoria = "Epidemiologia",
                Expressao = "p² + 2pq + q² = 1",
                ExprTexto = "p² + 2pq + q² = 1  (p + q = 1)",
                Icone = "HW",
                Descricao = "Frequências genotípicas em equilíbrio: AA=p², Aa=2pq, aa=q². Premissas: população grande, sem seleção, sem mutação, acasalamento aleatório.",
                Criador = "G. H. Hardy & W. Weinberg (1908)",
                AnoOrigin = "1908",
                ExemploPratico = "Se q=0,3 (alelo recessivo): q²=0,09 (9% homozigotos recessivos), 2pq=0,42 (42% heterozigotos)",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Frequência alelo dominante (p)", ValorPadrao = 0.7 },
                ],
                VariavelResultado = "q² (homozig. recessivos)",
                Calcular = vars => { double q = 1 - vars["p"]; return q * q; }
            },
            // ── 061 Incidência ──
            new Formula
            {
                Id = "7_epi04", Nome = "Taxa de Incidência", Categoria = "Epidemiologia",
                Expressao = "TI = casos novos / (pop. risco × período) × k",
                ExprTexto = "TI = Casos novos / (População em risco × Período) × k",
                Icone = "TI",
                Descricao = "Número de novos casos por população em risco por período de tempo. Mede velocidade de ocorrência de doença. k = multiplicador (100.000 hab.).",
                Criador = "Epidemiologia descritiva; John Snow (1854) pioneiro",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "50 novos casos em 100.000 pessoas/ano: TI = 50/100.000 = 0,05% ou 50 por 100 mil",
                Variaveis = [
                    new() { Simbolo = "casos", Nome = "Casos novos", ValorPadrao = 50 },
                    new() { Simbolo = "pop", Nome = "População em risco", ValorPadrao = 100000, ValorMin = 1 },
                    new() { Simbolo = "k", Nome = "Multiplicador (k)", Descricao = "Ex: 100.000", ValorPadrao = 100000 },
                ],
                VariavelResultado = "TI (por k hab.)",
                Calcular = vars => (vars["casos"] / vars["pop"]) * vars["k"]
            },
            // ── 062 Prevalência ──
            new Formula
            {
                Id = "7_epi05", Nome = "Taxa de Prevalência", Categoria = "Epidemiologia",
                Expressao = "P = casos existentes / população total × k",
                ExprTexto = "Prevalência = Casos existentes / População × k",
                Icone = "Prev",
                Descricao = "Proporção de indivíduos com a doença em dado momento. Difere da incidência por incluir casos novos E antigos.",
                Criador = "Epidemiologia descritiva",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "500 diabéticos em cidade de 20.000: P = 500/20.000×100 = 2,5%",
                Variaveis = [
                    new() { Simbolo = "casos", Nome = "Casos existentes", ValorPadrao = 500 },
                    new() { Simbolo = "pop", Nome = "População total", ValorPadrao = 20000, ValorMin = 1 },
                    new() { Simbolo = "k", Nome = "Multiplicador (k)", ValorPadrao = 100 },
                ],
                VariavelResultado = "P (por k)",
                Calcular = vars => (vars["casos"] / vars["pop"]) * vars["k"]
            },
            // ── 063 Odds Ratio ──
            new Formula
            {
                Id = "7_epi06", Nome = "Odds Ratio (OR)", Categoria = "Epidemiologia",
                Expressao = "OR = (a·d) / (b·c)",
                ExprTexto = "OR = (a × d) / (b × c)",
                Icone = "OR",
                Descricao = "Razão de chances: medida de associação em estudos caso-controle. OR>1: fator de risco; OR<1: fator de proteção; OR=1: sem associação.",
                Criador = "Cornfield (1951); desenvolvimento da epidemiologia analítica",
                AnoOrigin = "1951",
                ExemploPratico = "a=30(caso+expo), b=10(caso−expo), c=20(controle+expo), d=40(controle−expo): OR = (30×40)/(10×20) = 6,0",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Casos expostos (a)", ValorPadrao = 30 },
                    new() { Simbolo = "b", Nome = "Casos não-expostos (b)", ValorPadrao = 10 },
                    new() { Simbolo = "c", Nome = "Controles expostos (c)", ValorPadrao = 20, ValorMin = 1 },
                    new() { Simbolo = "d", Nome = "Controles não-expostos (d)", ValorPadrao = 40 },
                ],
                VariavelResultado = "OR",
                Calcular = vars => (vars["a"] * vars["d"]) / (vars["b"] * vars["c"])
            },
        ]);
    }
}
