using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 7 — PARTE VII: BIO-COMP-IA (33 fórmulas)
    // ═══════════════════════════════════════════════════════════════

    private void AdicionarVol7BioCompIA()
    {
        _formulas.AddRange([
            // ═══ CIÊNCIAS ESPORTIVAS (3 fórmulas) ═══

            new Formula
            {
                Id = "7_esp01", Nome = "VO₂máx Estimado (Cooper)", Categoria = "Ciências Esportivas",
                Expressao = "VO₂máx = (d − 504.9) / 44.73",
                ExprTexto = "VO₂máx = (distância_12min − 504,9) / 44,73",
                Icone = "🏃",
                Descricao = "Estimativa de consumo máximo de oxigênio pelo teste de Cooper (12 min). d = distância percorrida em metros.",
                Criador = "Kenneth Cooper (1968)",
                AnoOrigin = "1968",
                ExemploPratico = "Atleta: 2800m em 12min: VO₂máx = (2800−504,9)/44,73 = 51,3 mL/kg/min (bom)",
                Variaveis = [
                    new() { Simbolo = "d", Nome = "Distância em 12 min (m)", ValorPadrao = 2800 },
                ],
                VariavelResultado = "VO₂máx (mL/kg/min)",
                UnidadeResultado = "mL/kg/min",
                Calcular = vars => (vars["d"] - 504.9) / 44.73
            },
            new Formula
            {
                Id = "7_esp02", Nome = "Gasto Energético (MET)", Categoria = "Ciências Esportivas",
                Expressao = "kcal = MET · peso · tempo / 60",
                ExprTexto = "kcal = MET × peso(kg) × tempo(min) / 60",
                Icone = "🔥",
                Descricao = "Gasto calórico de atividade física. 1 MET = 3,5 mL O₂/kg/min. Caminhada ~3 METs, corrida ~8-12 METs.",
                Criador = "Ainsworth et al. (Compêndio de atividades, 1993)",
                AnoOrigin = "1993",
                ExemploPratico = "Corrida 8 METs, 70 kg, 45 min: kcal = 8×70×45/60 = 420 kcal",
                Variaveis = [
                    new() { Simbolo = "MET", Nome = "METs da atividade", ValorPadrao = 8 },
                    new() { Simbolo = "peso", Nome = "Peso corporal (kg)", ValorPadrao = 70 },
                    new() { Simbolo = "t", Nome = "Tempo (min)", ValorPadrao = 45 },
                ],
                VariavelResultado = "kcal",
                UnidadeResultado = "kcal",
                Calcular = vars => vars["MET"] * vars["peso"] * vars["t"] / 60.0
            },
            new Formula
            {
                Id = "7_esp03", Nome = "Frequência Cardíaca Alvo (Karvonen)", Categoria = "Ciências Esportivas",
                Expressao = "FC_alvo = FC_rep + %Int · (FC_max − FC_rep)",
                ExprTexto = "FCalvo = FCrepouso + intensidade × (FCmáx − FCrepouso)",
                Icone = "❤",
                Descricao = "Zona de treino pela reserva cardíaca. FCmáx ≈ 220−idade. Intensidade: 50-60% (leve), 60-70% (moderada), 70-85% (vigorosa).",
                Criador = "Martti Karvonen (1957)",
                AnoOrigin = "1957",
                ExemploPratico = "Idade 30, FCrep=60, intensidade 70%: FCmáx=190, FCalvo = 60+0,7×130 = 151 bpm",
                Variaveis = [
                    new() { Simbolo = "FCrep", Nome = "FC repouso (bpm)", ValorPadrao = 60 },
                    new() { Simbolo = "FCmax", Nome = "FC máxima (bpm)", ValorPadrao = 190 },
                    new() { Simbolo = "pInt", Nome = "Intensidade (0-1)", Descricao = "Ex: 0,70 para 70%", ValorPadrao = 0.70 },
                ],
                VariavelResultado = "FC alvo (bpm)",
                UnidadeResultado = "bpm",
                Calcular = vars => vars["FCrep"] + vars["pInt"] * (vars["FCmax"] - vars["FCrep"])
            },

            // ═══ BIOMECÂNICA (3 fórmulas) ═══

            new Formula
            {
                Id = "7_bio01", Nome = "Momento Articular", Categoria = "Biomecânica",
                Expressao = "M = F · d · sin(θ)",
                ExprTexto = "M = Força muscular × braço de alavanca × sen(θ)",
                Icone = "🦴",
                Descricao = "Torque articular: força muscular multiplicada pelo braço de momento e ângulo de inserção. Define capacidade de movimento articular.",
                Criador = "Giovanni Borelli (1680); biomecânica moderna (Séc. XX)",
                AnoOrigin = "1680",
                ExemploPratico = "Bíceps: F=500N, d=0,05m, θ=80°: M = 500×0,05×sin(80°) = 24,6 N·m",
                Variaveis = [
                    new() { Simbolo = "F", Nome = "Força muscular (N)", ValorPadrao = 500 },
                    new() { Simbolo = "d", Nome = "Braço de alavanca (m)", ValorPadrao = 0.05 },
                    new() { Simbolo = "theta", Nome = "Ângulo de inserção (graus)", ValorPadrao = 80 },
                ],
                VariavelResultado = "M (N·m)",
                UnidadeResultado = "N·m",
                Calcular = vars => vars["F"] * vars["d"] * Math.Sin(vars["theta"] * Math.PI / 180.0)
            },
            new Formula
            {
                Id = "7_bio02", Nome = "Força de Reação do Solo (Salto)", Categoria = "Biomecânica",
                Expressao = "F_pico = m · (g + v²/(2·h))",
                ExprTexto = "Fpico = m × (g + v²/(2h))  (aterrissagem)",
                Icone = "GRF",
                Descricao = "Força pico na aterrissagem de salto. v = velocidade no contato, h = deslocamento do centro de massa durante frenagem.",
                Criador = "Biomecânica esportiva; análise de plataforma de força",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "m=70 kg, v=3 m/s, h=0,3m: F = 70×(9,81+9/0,6) = 70×24,81 = 1737 N ≈ 2,5× peso corpo",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa (kg)", ValorPadrao = 70 },
                    new() { Simbolo = "v", Nome = "Velocidade no contato (m/s)", ValorPadrao = 3 },
                    new() { Simbolo = "h", Nome = "Deslocamento frenagem (m)", ValorPadrao = 0.3, ValorMin = 0.01 },
                ],
                VariavelResultado = "F_pico (N)",
                UnidadeResultado = "N",
                Calcular = vars => vars["m"] * (9.80665 + vars["v"] * vars["v"] / (2 * vars["h"]))
            },
            new Formula
            {
                Id = "7_bio03", Nome = "Centro de Massa (Segmental)", Categoria = "Biomecânica",
                Expressao = "X_cm = Σ(mᵢ · xᵢ) / Σmᵢ",
                ExprTexto = "Xcm = (m₁x₁ + m₂x₂) / (m₁ + m₂)",
                Icone = "CM",
                Descricao = "Posição do centro de massa de sistema de segmentos corporais. Base da análise de equilíbrio e locomoção.",
                Criador = "Dempster (1955); tabelas segmentais",
                AnoOrigin = "1955",
                ExemploPratico = "Tronco: m₁=30kg, x₁=0,5m; Pernas: m₂=20kg, x₂=0,3m: Xcm = (15+6)/50 = 0,42m",
                Variaveis = [
                    new() { Simbolo = "m1", Nome = "Massa segmento 1 (kg)", ValorPadrao = 30 },
                    new() { Simbolo = "x1", Nome = "Posição segmento 1 (m)", ValorPadrao = 0.5 },
                    new() { Simbolo = "m2", Nome = "Massa segmento 2 (kg)", ValorPadrao = 20 },
                    new() { Simbolo = "x2", Nome = "Posição segmento 2 (m)", ValorPadrao = 0.3 },
                ],
                VariavelResultado = "X_cm (m)",
                UnidadeResultado = "m",
                Calcular = vars => (vars["m1"] * vars["x1"] + vars["m2"] * vars["x2"]) / (vars["m1"] + vars["m2"])
            },

            // ═══ BIOESTATÍSTICA (2 fórmulas) ═══

            new Formula
            {
                Id = "7_bes01", Nome = "Odds Ratio (Razão de Chances)", Categoria = "Bioestatística",
                Expressao = "OR = (a·d) / (b·c)",
                ExprTexto = "OR = (a × d) / (b × c)  da tabela 2×2",
                Icone = "OR",
                Descricao = "Medida de associação em estudos caso-controle. OR>1: exposição é fator de risco, OR<1: fator protetor, OR=1: sem associação.",
                Criador = "Cornfield (1951); epidemiologia analítica",
                AnoOrigin = "1951",
                ExemploPratico = "Tabela: a=30(caso+exp), b=10(caso−exp), c=20(ctrl+exp), d=40(ctrl−exp): OR = 1200/200 = 6,0",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Casos expostos (a)", ValorPadrao = 30 },
                    new() { Simbolo = "b", Nome = "Casos não-expostos (b)", ValorPadrao = 10, ValorMin = 1 },
                    new() { Simbolo = "c", Nome = "Controles expostos (c)", ValorPadrao = 20, ValorMin = 1 },
                    new() { Simbolo = "d", Nome = "Controles não-expostos (d)", ValorPadrao = 40 },
                ],
                VariavelResultado = "OR",
                Calcular = vars => (vars["a"] * vars["d"]) / (vars["b"] * vars["c"])
            },
            new Formula
            {
                Id = "7_bes02", Nome = "Tamanho Amostral (Proporção)", Categoria = "Bioestatística",
                Expressao = "n = Z² · p(1−p) / e²",
                ExprTexto = "n = Z² × p(1−p) / e²",
                Icone = "n",
                Descricao = "Tamanho de amostra para estimar proporção com margem de erro e. Z=1,96 para 95% de confiança.",
                Criador = "Estatística de amostragem; Cochran (1977)",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "p=0,5 (máx.), e=0,05 (5%), Z=1,96: n = 3,8416×0,25/0,0025 = 384",
                Variaveis = [
                    new() { Simbolo = "Z", Nome = "Valor Z (1,96 para 95%)", ValorPadrao = 1.96 },
                    new() { Simbolo = "p", Nome = "Proporção estimada", ValorPadrao = 0.5 },
                    new() { Simbolo = "e", Nome = "Margem de erro", ValorPadrao = 0.05, ValorMin = 0.001 },
                ],
                VariavelResultado = "n (tamanho amostral)",
                Calcular = vars => vars["Z"] * vars["Z"] * vars["p"] * (1 - vars["p"]) / (vars["e"] * vars["e"])
            },

            // ═══ ECOLOGIA (2 fórmulas) ═══

            new Formula
            {
                Id = "7_ecl01", Nome = "Índice de Shannon (Diversidade)", Categoria = "Ecologia",
                Expressao = "H' = −Σ pᵢ · ln(pᵢ)",
                ExprTexto = "H' = −Σ pᵢ × ln(pᵢ)  (diversidade de espécies)",
                Icone = "H'",
                Descricao = "Diversidade de Shannon-Wiener: mede riqueza e equitabilidade. pᵢ = proporção da espécie i. H'=0 (1 espécie), H'máx = ln(S).",
                Criador = "Claude Shannon (1948); aplicado em ecologia por MacArthur (1955)",
                AnoOrigin = "1948",
                ExemploPratico = "3 espécies iguais (p=0,333): H' = −3×(0,333×ln0,333) = 1,099 = ln(3)",
                Variaveis = [
                    new() { Simbolo = "p1", Nome = "Proporção espécie 1", ValorPadrao = 0.333 },
                    new() { Simbolo = "p2", Nome = "Proporção espécie 2", ValorPadrao = 0.333 },
                    new() { Simbolo = "p3", Nome = "Proporção espécie 3", ValorPadrao = 0.334 },
                ],
                VariavelResultado = "H'",
                Calcular = vars =>
                {
                    double h = 0;
                    foreach (var kv in vars)
                        if (kv.Value > 0) h -= kv.Value * Math.Log(kv.Value);
                    return h;
                }
            },
            new Formula
            {
                Id = "7_ecl02", Nome = "Modelo de Lotka-Volterra (Predador-Presa)", Categoria = "Ecologia",
                Expressao = "dN/dt = rN − aNP;  dP/dt = baNP − mP",
                ExprTexto = "Taxa crescimento presa = rN − aNP",
                Icone = "🐺🐰",
                Descricao = "Sistema clássico predador-presa: N=presas, P=predadores. r=cresc.presa, a=taxa predação, b=eficiência, m=mortalidade predador.",
                Criador = "Alfred Lotka (1925) / Vito Volterra (1926)",
                AnoOrigin = "1925",
                ExemploPratico = "N=1000, P=50, r=0,1, a=0,01: dN/dt = 0,1×1000 − 0,01×1000×50 = 100−500 = −400 (declínio)",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Taxa cresc. presa (r)", ValorPadrao = 0.1 },
                    new() { Simbolo = "N", Nome = "Nº de presas (N)", ValorPadrao = 1000 },
                    new() { Simbolo = "a", Nome = "Taxa de predação (a)", ValorPadrao = 0.01 },
                    new() { Simbolo = "P", Nome = "Nº de predadores (P)", ValorPadrao = 50 },
                ],
                VariavelResultado = "dN/dt (taxa crescimento presas)",
                Calcular = vars => vars["r"] * vars["N"] - vars["a"] * vars["N"] * vars["P"]
            },

            // ═══ TEORIA DAS REDES (2 fórmulas) ═══

            new Formula
            {
                Id = "7_trd01", Nome = "Coeficiente de Agrupamento", Categoria = "Teoria das Redes",
                Expressao = "C = 2·E_tri / (k·(k−1))",
                ExprTexto = "C = 2 × triângulos / (k × (k−1))  (local)",
                Icone = "🕸",
                Descricao = "Medida de quão conectados estão os vizinhos de um nó. C=1: todos conectados (clique). Redes sociais: C alto (mundos pequenos).",
                Criador = "Duncan Watts & Steven Strogatz (1998)",
                AnoOrigin = "1998",
                ExemploPratico = "Nó com k=5 vizinhos, 4 triângulos: C = 2×4/(5×4) = 0,4",
                Variaveis = [
                    new() { Simbolo = "E_tri", Nome = "Nº de triângulos", ValorPadrao = 4 },
                    new() { Simbolo = "k", Nome = "Grau do nó (k)", ValorPadrao = 5, ValorMin = 2 },
                ],
                VariavelResultado = "C",
                Calcular = vars => 2 * vars["E_tri"] / (vars["k"] * (vars["k"] - 1))
            },
            new Formula
            {
                Id = "7_trd02", Nome = "Modelo de Barabási-Albert (Grau Esperado)", Categoria = "Teoria das Redes",
                Expressao = "P(k) ~ k^(−γ), γ ≈ 3",
                ExprTexto = "Grau médio nó novo: ⟨k⟩ = 2m  (m = arestas por nó novo)",
                Icone = "BA",
                Descricao = "Rede livre de escala com ligação preferencial. Distribuição de grau segue lei de potência P(k)~k⁻³. Robusta a falhas aleatórias.",
                Criador = "Albert-László Barabási & Réka Albert (1999)",
                AnoOrigin = "1999",
                ExemploPratico = "Rede BA com m=3 e N=1000: grau médio ⟨k⟩ = 2×3 = 6",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Arestas por nó novo (m)", ValorPadrao = 3 },
                    new() { Simbolo = "N", Nome = "Nº total de nós (N)", ValorPadrao = 1000 },
                ],
                VariavelResultado = "⟨k⟩ (grau médio)",
                Calcular = vars => 2 * vars["m"]
            },

            // ═══ GENÉTICA QUANTITATIVA (2 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_gqu01", Nome = "Equilíbrio de Hardy-Weinberg", Categoria = "Genética Quantitativa",
                Expressao = "p² + 2pq + q² = 1",
                ExprTexto = "Freq. genótipos: AA=p², Aa=2pq, aa=q²",
                Icone = "HW",
                Descricao = "Em população grande, sem seleção/mutação/migração/deriva: frequências alélicas e genotípicas são constantes entre gerações.",
                Criador = "G.H. Hardy & Wilhelm Weinberg (1908)",
                AnoOrigin = "1908",
                ExemploPratico = "Alelo A: p=0,7, a: q=0,3: AA=0,49, Aa=0,42, aa=0,09",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Freq. alelo dominante (p)", ValorPadrao = 0.7 },
                ],
                VariavelResultado = "Freq. heterozigotos (2pq)",
                Calcular = vars => 2 * vars["p"] * (1 - vars["p"])
            },
            new Formula
            {
                Id = "7_gqu02", Nome = "Resposta à Seleção (Breeder's Eq.)", Categoria = "Genética Quantitativa",
                Expressao = "R = h² · S",
                ExprTexto = "R = h² × S  (R = resposta, h² = herdabilidade, S = diferencial de seleção)",
                Icone = "R",
                Descricao = "Equação do melhorista: ganho genético por geração = herdabilidade × diferencial de seleção. Base do melhoramento genético animal e vegetal.",
                Criador = "Jay Lush (1937); Sewall Wright",
                AnoOrigin = "1937",
                ExemploPratico = "Leite: h²=0,25, S=800 kg/lactação: R = 0,25×800 = 200 kg/geração",
                Variaveis = [
                    new() { Simbolo = "h2", Nome = "Herdabilidade (h²)", Descricao = "0 a 1", ValorPadrao = 0.25 },
                    new() { Simbolo = "S", Nome = "Diferencial de seleção (S)", ValorPadrao = 800 },
                ],
                VariavelResultado = "R (ganho por geração)",
                Calcular = vars => vars["h2"] * vars["S"]
            },

            // ═══ SÉRIES TEMPORAIS (2 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_ste01", Nome = "Média Móvel Exponencial (EMA)", Categoria = "Séries Temporais",
                Expressao = "EMA_t = α·x_t + (1−α)·EMA_{t−1}",
                ExprTexto = "EMAt = α × xt + (1−α) × EMAt−1",
                Icone = "EMA",
                Descricao = "Suavização exponencial: peso decresce exponencialmente para observações antigas. α = 2/(n+1) para janela equivalente a n períodos.",
                Criador = "Robert Goodell Brown (1956); alisamento exponencial",
                AnoOrigin = "1956",
                ExemploPratico = "α=0,2, xt=110, EMA_{t-1}=100: EMAt = 0,2×110+0,8×100 = 102",
                Variaveis = [
                    new() { Simbolo = "alpha", Nome = "Fator de suavização (α)", Descricao = "0 a 1", ValorPadrao = 0.2 },
                    new() { Simbolo = "xt", Nome = "Valor atual (xt)", ValorPadrao = 110 },
                    new() { Simbolo = "EMAprev", Nome = "EMA anterior", ValorPadrao = 100 },
                ],
                VariavelResultado = "EMA_t",
                Calcular = vars => vars["alpha"] * vars["xt"] + (1 - vars["alpha"]) * vars["EMAprev"]
            },
            new Formula
            {
                Id = "7_ste02", Nome = "Autocorrelação (lag k)", Categoria = "Séries Temporais",
                Expressao = "ρ(k) = γ(k) / γ(0)",
                ExprTexto = "ρ(k) = covariância(lag k) / variância",
                Icone = "ρ(k)",
                Descricao = "Correlação da série consigo mesma defasada k períodos. ρ(0)=1 sempre. Decaimento rápido → estacionária. Lento → tendência.",
                Criador = "Box & Jenkins (1970); análise de séries temporais",
                AnoOrigin = "1970",
                ExemploPratico = "γ(0)=100, γ(1)=80: ρ(1) = 80/100 = 0,80 (alta autocorrelação)",
                Variaveis = [
                    new() { Simbolo = "gk", Nome = "Autocovariância γ(k)", ValorPadrao = 80 },
                    new() { Simbolo = "g0", Nome = "Variância γ(0)", ValorPadrao = 100, ValorMin = 0.001 },
                ],
                VariavelResultado = "ρ(k)",
                Calcular = vars => vars["gk"] / vars["g0"]
            },

            // ═══ PROCESSAMENTO DE SINAIS (3 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_psi01", Nome = "Teorema de Nyquist-Shannon", Categoria = "Processamento de Sinais",
                Expressao = "fs ≥ 2 · f_max",
                ExprTexto = "fs ≥ 2 × fmáx  (taxa de amostragem mínima)",
                Icone = "fs",
                Descricao = "Para reconstruir perfeitamente um sinal, a taxa de amostragem deve ser pelo menos o dobro da maior frequência. CD: 44,1kHz para 22kHz.",
                Criador = "Harry Nyquist (1928) / Claude Shannon (1949)",
                AnoOrigin = "1949",
                ExemploPratico = "Áudio: fmax=20 kHz → fs ≥ 40 kHz (CD usa 44.100 Hz com margem)",
                Variaveis = [
                    new() { Simbolo = "fmax", Nome = "Frequência máxima (Hz)", ValorPadrao = 20000 },
                ],
                VariavelResultado = "fs mínima (Hz)",
                UnidadeResultado = "Hz",
                Calcular = vars => 2 * vars["fmax"]
            },
            new Formula
            {
                Id = "7_psi02", Nome = "SNR (Relação Sinal-Ruído)", Categoria = "Processamento de Sinais",
                Expressao = "SNR_dB = 10 · log₁₀(P_sinal / P_ruído)",
                ExprTexto = "SNR = 10 × log₁₀(Psinal/Pruído)  em dB",
                Icone = "SNR",
                Descricao = "Razão sinal-ruído em decibéis. SNR > 30 dB: sinal limpo. Para tensões: SNR = 20·log(Vs/Vn).",
                Criador = "Engenharia de comunicações; Shannon (teoria da informação)",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Psinal=1 mW, Pruído=0,001 mW: SNR = 10×log(1000) = 30 dB",
                Variaveis = [
                    new() { Simbolo = "Ps", Nome = "Potência do sinal", ValorPadrao = 1 },
                    new() { Simbolo = "Pn", Nome = "Potência do ruído", ValorPadrao = 0.001, ValorMin = 1e-20 },
                ],
                VariavelResultado = "SNR (dB)",
                UnidadeResultado = "dB",
                Calcular = vars => 10 * Math.Log10(vars["Ps"] / vars["Pn"])
            },
            new Formula
            {
                Id = "7_psi03", Nome = "Filtro Digital (IIR 1ª Ordem)", Categoria = "Processamento de Sinais",
                Expressao = "y[n] = (1−α)·y[n−1] + α·x[n]",
                ExprTexto = "y[n] = (1−α)×y[n−1] + α×x[n]",
                Icone = "IIR",
                Descricao = "Filtro passa-baixas IIR de 1ª ordem. α perto de 1 → pouca filtragem, α perto de 0 → muita suavização. Equivalente digital do RC.",
                Criador = "Teoria de filtros digitais; Oppenheim & Schafer",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "α=0,1, x[n]=100, y[n-1]=90: y = 0,9×90+0,1×100 = 91",
                Variaveis = [
                    new() { Simbolo = "alpha", Nome = "Coef. α (0 a 1)", ValorPadrao = 0.1 },
                    new() { Simbolo = "xn", Nome = "Entrada x[n]", ValorPadrao = 100 },
                    new() { Simbolo = "yn1", Nome = "Saída anterior y[n−1]", ValorPadrao = 90 },
                ],
                VariavelResultado = "y[n]",
                Calcular = vars => (1 - vars["alpha"]) * vars["yn1"] + vars["alpha"] * vars["xn"]
            },

            // ═══ INTELIGÊNCIA ARTIFICIAL (4 fórmulas) ═══

            new Formula
            {
                Id = "7_iaa01", Nome = "Função Sigmóide (Logística)", Categoria = "Inteligência Artificial",
                Expressao = "σ(x) = 1 / (1 + e^(−x))",
                ExprTexto = "σ(x) = 1 / (1 + e⁻ˣ)",
                Icone = "σ",
                Descricao = "Função de ativação clássica em redes neurais. Mapeia ℝ → (0,1). Derivada: σ'(x) = σ(x)(1−σ(x)). Usada em regressão logística e classificação.",
                Criador = "Verhulst (1838, logística); McCulloch & Pitts (neurônio, 1943)",
                AnoOrigin = "1943",
                ExemploPratico = "x=2: σ(2) = 1/(1+e⁻²) = 1/1,135 = 0,881",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Entrada (x)", ValorPadrao = 2 },
                ],
                VariavelResultado = "σ(x)",
                Calcular = vars => 1.0 / (1.0 + Math.Exp(-vars["x"]))
            },
            new Formula
            {
                Id = "7_iaa02", Nome = "Entropia Cruzada (Cross-Entropy Loss)", Categoria = "Inteligência Artificial",
                Expressao = "L = −[y·ln(ŷ) + (1−y)·ln(1−ŷ)]",
                ExprTexto = "L = −[y×ln(ŷ) + (1−y)×ln(1−ŷ)]",
                Icone = "CE",
                Descricao = "Função de perda para classificação binária. y=rótulo real (0/1), ŷ=probabilidade prevista. Penaliza previsões confiantes e erradas.",
                Criador = "Shannon (entropia, 1948); redes neurais (backprop, 1986)",
                AnoOrigin = "1948",
                ExemploPratico = "y=1, ŷ=0,9: L = −[1×ln(0,9)+0×ln(0,1)] = −(−0,105) = 0,105 (baixa perda)",
                Variaveis = [
                    new() { Simbolo = "y", Nome = "Rótulo real (0 ou 1)", ValorPadrao = 1 },
                    new() { Simbolo = "yhat", Nome = "Probabilidade prevista (ŷ)", Descricao = "0 a 1", ValorPadrao = 0.9, ValorMin = 0.0001 },
                ],
                VariavelResultado = "L (perda)",
                Calcular = vars =>
                {
                    double yh = Math.Max(0.0001, Math.Min(0.9999, vars["yhat"]));
                    return -(vars["y"] * Math.Log(yh) + (1 - vars["y"]) * Math.Log(1 - yh));
                }
            },
            new Formula
            {
                Id = "7_iaa03", Nome = "Descida de Gradiente (SGD)", Categoria = "Inteligência Artificial",
                Expressao = "θ_{t+1} = θ_t − η · ∂L/∂θ",
                ExprTexto = "θnovo = θatual − η × gradiente",
                Icone = "∇",
                Descricao = "Atualização de parâmetros em aprendizado de máquina. η = taxa de aprendizado (learning rate). Fundamental para treino de redes neurais.",
                Criador = "Cauchy (1847); Robbins & Monro (SGD, 1951)",
                AnoOrigin = "1951",
                ExemploPratico = "θ=5, η=0,01, ∂L/∂θ=−20: θnovo = 5−0,01×(−20) = 5,2",
                Variaveis = [
                    new() { Simbolo = "theta", Nome = "Parâmetro atual (θ)", ValorPadrao = 5 },
                    new() { Simbolo = "eta", Nome = "Taxa de aprendizado (η)", ValorPadrao = 0.01 },
                    new() { Simbolo = "grad", Nome = "Gradiente (∂L/∂θ)", ValorPadrao = -20 },
                ],
                VariavelResultado = "θ_novo",
                Calcular = vars => vars["theta"] - vars["eta"] * vars["grad"]
            },
            new Formula
            {
                Id = "7_iaa04", Nome = "Softmax", Categoria = "Inteligência Artificial",
                Expressao = "softmax(zᵢ) = e^zᵢ / Σe^zⱼ",
                ExprTexto = "P(classe i) = e^zi / (e^z₁ + e^z₂ + e^z₃)",
                Icone = "softmax",
                Descricao = "Normaliza vetor de scores em probabilidades (somam 1). Usada na camada de saída para classificação multiclasse.",
                Criador = "John Bridle (1990, softmax); Boltzmann (distribuição)",
                AnoOrigin = "1990",
                ExemploPratico = "z=[2,1,0]: e^z=[7.39,2.72,1]: P=[0,67, 0,24, 0,09]",
                Variaveis = [
                    new() { Simbolo = "z1", Nome = "Score classe 1", ValorPadrao = 2 },
                    new() { Simbolo = "z2", Nome = "Score classe 2", ValorPadrao = 1 },
                    new() { Simbolo = "z3", Nome = "Score classe 3", ValorPadrao = 0 },
                ],
                VariavelResultado = "P(classe 1)",
                Calcular = vars =>
                {
                    double e1 = Math.Exp(vars["z1"]), e2 = Math.Exp(vars["z2"]), e3 = Math.Exp(vars["z3"]);
                    return e1 / (e1 + e2 + e3);
                }
            },

            // ═══ PSICOMETRIA (3 fórmulas) — adicionadas à categoria existente ═══

            new Formula
            {
                Id = "7_pmt01", Nome = "Alfa de Cronbach", Categoria = "Psicometria e IRT",
                Expressao = "α = (k/(k−1)) · (1 − Σσ²ᵢ/σ²total)",
                ExprTexto = "α = (k/(k−1)) × (1 − Σσ²itens / σ²total)",
                Icone = "α",
                Descricao = "Coeficiente de consistência interna. α>0,7: aceitável, α>0,8: bom, α>0,9: excelente. k = nº de itens.",
                Criador = "Lee Cronbach (1951)",
                AnoOrigin = "1951",
                ExemploPratico = "k=10, Σσ²itens=5, σ²total=20: α = (10/9)×(1−5/20) = 1,111×0,75 = 0,833 (bom)",
                Variaveis = [
                    new() { Simbolo = "k", Nome = "Nº de itens", ValorPadrao = 10, ValorMin = 2 },
                    new() { Simbolo = "sItens", Nome = "Σσ² dos itens", ValorPadrao = 5 },
                    new() { Simbolo = "sTotal", Nome = "σ² total do teste", ValorPadrao = 20, ValorMin = 0.01 },
                ],
                VariavelResultado = "α",
                Calcular = vars => (vars["k"] / (vars["k"] - 1)) * (1 - vars["sItens"] / vars["sTotal"])
            },
            new Formula
            {
                Id = "7_pmt02", Nome = "Modelo de Rasch (1PL-IRT)", Categoria = "Psicometria e IRT",
                Expressao = "P(X=1) = e^(θ−b) / (1 + e^(θ−b))",
                ExprTexto = "P(acerto) = e^(θ−b) / (1 + e^(θ−b))",
                Icone = "IRT",
                Descricao = "Probabilidade de acerto no modelo de Rasch: θ = habilidade, b = dificuldade. Quando θ=b: P=0,50. Modelo mais parcimonioso da TRI.",
                Criador = "Georg Rasch (1960)",
                AnoOrigin = "1960",
                ExemploPratico = "θ=1,5 (habilidade), b=1,0 (dificuldade): P = e^0,5/(1+e^0,5) = 0,622",
                Variaveis = [
                    new() { Simbolo = "theta", Nome = "Habilidade (θ)", ValorPadrao = 1.5 },
                    new() { Simbolo = "b", Nome = "Dificuldade (b)", ValorPadrao = 1.0 },
                ],
                VariavelResultado = "P(acerto)",
                Calcular = vars =>
                {
                    double x = vars["theta"] - vars["b"];
                    return Math.Exp(x) / (1 + Math.Exp(x));
                }
            },
            new Formula
            {
                Id = "7_pmt03", Nome = "Escore Padronizado (Z-Score)", Categoria = "Psicometria e IRT",
                Expressao = "z = (X − μ) / σ",
                ExprTexto = "z = (escore − média) / desvio padrão",
                Icone = "z",
                Descricao = "Padronização: quantos desvios padrão acima/abaixo da média. z=0: na média. |z|>2: incomum. Base de QI, SAT, ENEM (com transformação).",
                Criador = "Karl Pearson; teoria da normal",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "QI: X=130, μ=100, σ=15: z = (130−100)/15 = 2,0 (2 DP acima)",
                Variaveis = [
                    new() { Simbolo = "X", Nome = "Escore bruto (X)", ValorPadrao = 130 },
                    new() { Simbolo = "mu", Nome = "Média (μ)", ValorPadrao = 100 },
                    new() { Simbolo = "sigma", Nome = "Desvio padrão (σ)", ValorPadrao = 15, ValorMin = 0.01 },
                ],
                VariavelResultado = "z",
                Calcular = vars => (vars["X"] - vars["mu"]) / vars["sigma"]
            },

            // ═══ PSICOFÍSICA (2 fórmulas) ═══

            new Formula
            {
                Id = "7_psf01", Nome = "Lei de Weber-Fechner", Categoria = "Psicofísica",
                Expressao = "S = k · ln(I/I₀)",
                ExprTexto = "S = k × ln(I/I₀)  (sensação = k × log do estímulo)",
                Icone = "ψ",
                Descricao = "Sensação subjetiva é logarítmica ao estímulo físico. Weber: ΔI/I = constante. Fechner: integrou para obter a lei logarítmica.",
                Criador = "Ernst Weber (1834) / Gustav Fechner (1860)",
                AnoOrigin = "1860",
                ExemploPratico = "Som: k=10, I=100 W/m², I₀=10⁻¹² W/m²: S = 10×ln(10¹⁴) = 322",
                Variaveis = [
                    new() { Simbolo = "k", Nome = "Constante k", ValorPadrao = 10 },
                    new() { Simbolo = "I", Nome = "Intensidade do estímulo", ValorPadrao = 100 },
                    new() { Simbolo = "I0", Nome = "Limiar de percepção (I₀)", ValorPadrao = 1e-12, ValorMin = 1e-20 },
                ],
                VariavelResultado = "S (sensação)",
                Calcular = vars => vars["k"] * Math.Log(vars["I"] / vars["I0"])
            },
            new Formula
            {
                Id = "7_psf02", Nome = "Lei de Stevens (Potência)", Categoria = "Psicofísica",
                Expressao = "S = k · I^n",
                ExprTexto = "S = k × Iⁿ  (expoente n depende da modalidade)",
                Icone = "Sⁿ",
                Descricao = "Lei de Stevens (1957): relação de potência entre estímulo e sensação. n=0,33 (brilho), n=1,0 (comprimento), n=3,5 (choque elétrico).",
                Criador = "S.S. Stevens (1957)",
                AnoOrigin = "1957",
                ExemploPratico = "Brilho: k=1, I=100 cd, n=0,33: S = 100^0,33 = 4,64 (compressão)",
                Variaveis = [
                    new() { Simbolo = "k", Nome = "Constante k", ValorPadrao = 1 },
                    new() { Simbolo = "I", Nome = "Intensidade do estímulo", ValorPadrao = 100 },
                    new() { Simbolo = "n", Nome = "Expoente n", Descricao = "Depende da modalidade sensorial", ValorPadrao = 0.33 },
                ],
                VariavelResultado = "S (sensação)",
                Calcular = vars => vars["k"] * Math.Pow(vars["I"], vars["n"])
            },

            // ═══ METROLOGIA (2 fórmulas) ═══

            new Formula
            {
                Id = "7_met01", Nome = "Incerteza Combinada (GUM)", Categoria = "Metrologia",
                Expressao = "u_c = √(Σ (cᵢ·uᵢ)²)",
                ExprTexto = "uc = √(c₁²u₁² + c₂²u₂²)  (propagação)",
                Icone = "U",
                Descricao = "Incerteza combinada por propagação quadrática (GUM, ISO). cᵢ = coeficientes de sensibilidade, uᵢ = incertezas padrão dos componentes.",
                Criador = "ISO GUM (1993); BIPM",
                AnoOrigin = "1993",
                ExemploPratico = "u₁=0,5mm (c₁=1), u₂=0,3mm (c₂=1): uc = √(0,25+0,09) = 0,583 mm",
                Variaveis = [
                    new() { Simbolo = "c1", Nome = "Coef. sensibilidade c₁", ValorPadrao = 1 },
                    new() { Simbolo = "u1", Nome = "Incerteza u₁", ValorPadrao = 0.5 },
                    new() { Simbolo = "c2", Nome = "Coef. sensibilidade c₂", ValorPadrao = 1 },
                    new() { Simbolo = "u2", Nome = "Incerteza u₂", ValorPadrao = 0.3 },
                ],
                VariavelResultado = "uc",
                Calcular = vars => Math.Sqrt(Math.Pow(vars["c1"] * vars["u1"], 2) + Math.Pow(vars["c2"] * vars["u2"], 2))
            },
            new Formula
            {
                Id = "7_met02", Nome = "Incerteza Expandida (k=2)", Categoria = "Metrologia",
                Expressao = "U = k · uc",
                ExprTexto = "U = k × uc  (k=2 → 95% de confiança)",
                Icone = "U95",
                Descricao = "Incerteza expandida para intervalo de confiança. k=2 para 95%, k=3 para 99,7% (normal). Resultado: valor ± U.",
                Criador = "ISO GUM (1993); BIPM",
                AnoOrigin = "1993",
                ExemploPratico = "uc=0,583 mm, k=2: U = 2×0,583 = 1,166 mm → (10,000 ± 1,17) mm",
                Variaveis = [
                    new() { Simbolo = "uc", Nome = "Incerteza combinada (uc)", ValorPadrao = 0.583 },
                    new() { Simbolo = "k", Nome = "Fator de abrangência (k)", ValorPadrao = 2 },
                ],
                VariavelResultado = "U",
                Calcular = vars => vars["k"] * vars["uc"]
            },

            // ═══ SISTEMAS COMPLEXOS (3 fórmulas) ═══

            new Formula
            {
                Id = "7_scx01", Nome = "Mapa Logístico", Categoria = "Sistemas Complexos",
                Expressao = "x_{n+1} = r · xₙ · (1 − xₙ)",
                ExprTexto = "xn+1 = r × xn × (1 − xn)",
                Icone = "🔄",
                Descricao = "Sistema dinâmico discreto que exibe caos para r > 3,57. Bifurcação em período-2 para r=3, período-4 para r≈3,45. Rota para o caos.",
                Criador = "Robert May (1976); Feigenbaum (constantes, 1978)",
                AnoOrigin = "1976",
                ExemploPratico = "r=3,8, x₀=0,4: x₁=3,8×0,4×0,6=0,912, x₂=3,8×0,912×0,088=0,305 (caótico)",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Parâmetro r", Descricao = "0 a 4", ValorPadrao = 3.8 },
                    new() { Simbolo = "xn", Nome = "Valor atual (xn)", Descricao = "0 a 1", ValorPadrao = 0.4 },
                ],
                VariavelResultado = "x_{n+1}",
                Calcular = vars => vars["r"] * vars["xn"] * (1 - vars["xn"])
            },
            new Formula
            {
                Id = "7_scx02", Nome = "Expoente de Lyapunov", Categoria = "Sistemas Complexos",
                Expressao = "λ = lim(N→∞) (1/N) Σ ln|f'(xₙ)|",
                ExprTexto = "Para mapa logístico: λ = (1/N) Σ ln|r(1−2xn)|",
                Icone = "λ_L",
                Descricao = "Mede taxa de divergência de trajetórias próximas. λ>0: caos (divergência exponencial). λ<0: atrator estável. λ=0: ponto de bifurcação.",
                Criador = "Aleksandr Lyapunov (1892)",
                AnoOrigin = "1892",
                ExemploPratico = "Mapa logístico r=4: λ = ln(2) ≈ 0,693 (máximo caos)",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Parâmetro r", ValorPadrao = 4 },
                    new() { Simbolo = "xn", Nome = "Ponto atual (xn)", ValorPadrao = 0.5 },
                ],
                VariavelResultado = "λ (instantâneo)",
                Calcular = vars => Math.Log(Math.Abs(vars["r"] * (1 - 2 * vars["xn"])))
            },
            new Formula
            {
                Id = "7_scx03", Nome = "Dimensão Fractal (Box-Counting)", Categoria = "Sistemas Complexos",
                Expressao = "D = lim(ε→0) ln(N(ε)) / ln(1/ε)",
                ExprTexto = "D = ln(N) / ln(1/ε)  (estimativa)",
                Icone = "D_f",
                Descricao = "Dimensão fractal por box-counting: N(ε) = nº de caixas de tamanho ε para cobrir o objeto. Curva de Koch: D=ln4/ln3≈1,26.",
                Criador = "Benoît Mandelbrot (1975); Hausdorff-Besicovitch",
                AnoOrigin = "1975",
                ExemploPratico = "Curva de Koch: N=4, fator=3: D = ln(4)/ln(3) = 1,262",
                Variaveis = [
                    new() { Simbolo = "N", Nome = "Nº de caixas N(ε)", ValorPadrao = 4 },
                    new() { Simbolo = "eps", Nome = "Fator 1/ε", ValorPadrao = 3, ValorMin = 1.01 },
                ],
                VariavelResultado = "D (dimensão fractal)",
                Calcular = vars => Math.Log(vars["N"]) / Math.Log(vars["eps"])
            },
        ]);
    }
}
