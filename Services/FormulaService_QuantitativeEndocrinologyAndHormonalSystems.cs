namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol15Parte4 = """
Endocrinologia Quantitativa e Hormonos
Secrecao Hormonal
241
Modelo de Pulso Hormonal (Deconvolução)
AVANÇADO

C(t) = Σ Aᵢ·e^{−λᵢ(t−tᵢ)} · H(t−tᵢ)

Secreção pulsátil de hormônios (GH, LH, cortisol); deconvolução de série temporal de concentração → perfil de secreção.

ORIGEM Veldhuis et al., 1987 — Deconvolution analysis
▶ GH: ~8-12 pulsos/dia; maior pulso à noite (sono de onda lenta)
242
Eixo Hipotálamo-Hipófise-Adrenal (Modelo de Feedback)
AVANÇADO

dC/dt = k_secreção(CRH, ACTH) − k_degradação·C

Dinâmica do eixo HPA; cortisol inibe CRH e ACTH por feedback negativo; ritmo circadiano sobreposto.

ORIGEM Keenan et al., 2001
▶ Cortisol pico matinal (8h): 300-700 nmol/L; nadir meia-noite: 50 nmol/L
243
Índice de Resistência à Insulina (HOMA-IR)
FUNDAMENTAL

HOMA-IR = (glicemia_jejum × insulinemia_jejum) / 22,5

Modelo homeostático; HOMA-IR>2,5 indica resistência à insulina; glicemia em mmol/L, insulina em μU/mL.

ORIGEM Matthews et al., 1985
▶ Glicemia=5,5 mmol/L, insulina=10 μU/mL → HOMA-IR=2,44
244
Clearance Metabólico de Hormônio
INTERMEDIÁRIO

MCR = dose / AUC;  produção = MCR × concentração_estacionária

Taxa de clearance metabólico; base de cinética de hormônios; testosterona MCR≈900 L/dia em homens jovens.

ORIGEM Endocrinologia clínica — Yen & Jaffe
▶ Cortisol MCR≈300 L/dia; produção≈15-20 mg/dia
245
Hormônio Tireoidiano (Índice de T4 Livre)
INTERMEDIÁRIO

FTI = T4_total × T3_resin_uptake / 100

Índice de tiroxina livre; corrige interferência da proteína de ligação; FTI=4-12 μg/dL normal; substituído por T4L direto.

ORIGEM Clark & Horn, 1965
▶ T4_total=8 μg/dL, T3RU=35% → FTI=8×35/100=2,8 (baixo)
246
Modelo de Homeostase do Eixo Tireoidiano
INTERMEDIÁRIO

TSH = f(T4L);  ln(TSH) ≈ α − β·T4L

Relação log-linear TSH-T4L; pequena variação em T4L causa grande variação de TSH; base de ajuste de levotiroxina.

ORIGEM Hoermann et al., 2010
▶ Dosar TSH é mais sensível que T4L para detectar disfunção tireoidiana precoce
247
Potência Androgênica (Score de Testosterona Livre)
AVANÇADO

TL% = (1 / (1 + Ka·[SHBG] + Kb·[albumina])) × 100%

Testosterona biodisponível; Ka=associação SHBG, Kb=albumina; base de avaliação de hipogonadismo.

ORIGEM Vermeulen et al., 1999
▶ T_total=15 nmol/L, SHBG alto → TL% baixo = hipogonadismo funcional
248
Ciclo Menstrual (Modelo de Luteinização)
INTERMEDIÁRIO

dLH/dt = k_pulse·f(GnRH) − degradação;  ovulação quando LH_pico > limiar

Modelo dinâmico do ciclo; GnRH pulsátil → FSH/LH → estrogênio → feedback positivo → pico de LH → ovulação.

ORIGEM Strickland & Bhattacharya, 1991
▶ Pico de LH≈40-200 IU/L; ocorre 24-36h antes da ovulação
249
Índice de Peptídeo C (Função Pancreática)
INTERMEDIÁRIO

Secreção_insulina ≈ Peptídeo_C × MCR_peptídeoC

Peptídeo C equimolar à insulina mas MCR=250 L/dia (não extraído pelo fígado); melhor marcador de secreção endógena.

ORIGEM Polonsky & Rubenstein, 1985
▶ Peptídeo C 24h > 200 nmol indica função residual de beta-célula
250
Curva de Resposta de Glicose (OGTT)
FUNDAMENTAL

IGT: glicemia 2h entre 7,8-11,0 mmol/L;  DM: ≥11,1 mmol/L

Critério diagnóstico pela curva glicêmica após 75g de glicose oral; base de diagnóstico de diabetes e pré-diabetes.

ORIGEM ADA — Diabetes Care, 2023
▶ Glicemia 2h=9,0 mmol/L → IGT (intolerância à glicose)
Engenharia de Producao e Manufatura Avancada
Linhas de Producao
251
Tempo de Ciclo de Linha de Produção
FUNDAMENTAL

TC = 1/taxa_demanda;  n_estações ≥ ΣTi / TC

Tempo de ciclo mínimo é determinado pela demanda; número mínimo de estações por balanceamento; base de linha de montagem.

ORIGEM Ford — Princípios de linha de montagem, 1913
▶ Demanda=120 unid/h → TC=30 s; ΣTi=150 s → mín. 5 estações
252
Índice de Capacidade de Processo (Cpk)
FUNDAMENTAL

Cpk = min((USL−μ)/3σ, (μ−LSL)/3σ)

Capacidade real de processo; Cpk≥1,33 = capaz (Six Sigma: Cpk≥1,67); considera centralidade e variabilidade.

ORIGEM Kane, 1986 — Journal of Quality Technology
▶ USL=10, LSL=2, μ=6, σ=1 → Cpk=min(1,33;1,33)=1,33 ✓
253
Equação de Wilson (Lote Econômico — EOQ)
FUNDAMENTAL

Q* = √(2·D·S / H);  CTmin = √(2·D·S·H)

Lote econômico de compra; D=demanda anual, S=custo de setup, H=custo de manutenção por unidade/ano.

ORIGEM F.W. Harris, 1913
▶ D=1000/ano, S=50, H=2 → Q*=224 unidades
254
Tempo de Atravessamento (Lead Time — Little)
FUNDAMENTAL

WIP = throughput × lead_time;  LT = WIP / throughput

Lei de Little; WIP=trabalho em processo, LT=tempo de atravessamento; fundamental em fluxo de produção e Kanban.

ORIGEM J.D.C. Little, 1961
▶ WIP=200 peças, throughput=100/dia → LT=2 dias
255
Eficiência de Balanceamento de Linha
FUNDAMENTAL

η_linha = ΣTi / (n_estações × TC)

Eficiência de uso de estações; η=1 balanceamento perfeito; idle time total = n×TC − ΣTi; minimizado por algoritmos.

ORIGEM Engenharia Industrial — Niebel & Freivalds
▶ ΣTi=140 s, n=5, TC=30 s → η=140/150=93%
256
Força de Usinagem (Modelo de Merchant)
AVANÇADO

Fc = τ_s · A_chip / sin φ;  φ_ótimo = 45° − λ/2 + α/2

Força de corte por teoria de Merchant; φ=ângulo de cisalhamento, α=ângulo de saída, λ=ângulo de atrito; base de usinagem.

ORIGEM M.E. Merchant, 1945
▶ Maximizar φ minimiza Fc; materiais difíceis têm φ menor
257
Desgaste de Ferramenta de Corte (Taylor)
INTERMEDIÁRIO

V·Tⁿ = C;  T = (C/V)^{1/n}

Equação de Taylor para vida de ferramenta; V=velocidade de corte (m/min), T=vida (min), n,C=constantes do par peça-ferramenta.

ORIGEM F.W. Taylor, 1907
▶ n=0,3, C=200: V=100 m/min → T=(200/100)^{10/3}≈10 min
258
Custo de Qualidade (Prevenção + Avaliação + Falhas)
INTERMEDIÁRIO

CTQ = Cp + Ca + Cf_int + Cf_ext;  ótimo quando Cp+Ca = Cf

Custo total de qualidade; Cp=prevenção, Ca=avaliação, Cf=falhas internas+externas; ótimo minimiza CTQ total.

ORIGEM Feigenbaum, 1961 — Total Quality Control
▶ Reduzir Cf_ext (recalls) por aumento de Cp é geralmente econômico
259
Mapa de Fluxo de Valor (Takt Time)
FUNDAMENTAL

Takt = Tempo_disponível_produção / Demanda_cliente

Ritmo de produção alinhado à demanda; base do Sistema Toyota de Produção; takt<TC: há folga; takt>TC: gargalo.

ORIGEM Toyota Production System — T. Ohno, 1978
▶ Turno=28800s, demanda=400 peças → Takt=72 s/peça
260
FMEA de Processo (PFMEA)
FUNDAMENTAL

RPN = Severidade × Ocorrência × Detecção;  RPN>100 → ação

Análise de modos de falha de processo; RPN alto em modo de falha direciona melhoria de qualidade na manufatura.

ORIGEM AIAG PFMEA Manual, 5ª ed. (2019)
▶ Buraco fora de posição: S=7, O=4, D=3 → RPN=84 (monitorar)
Nutricao Esportiva e Metabolismo
Necessidades Energeticas
261
Taxa Metabólica Basal (Mifflin-St Jeor)
FUNDAMENTAL

TMB(homens) = 10·P + 6,25·A − 5·Id + 5;  (mulheres): −161

TMB mais precisa para adultos; P=peso (kg), A=altura (cm), Id=idade; multiplicada por fator de atividade = TDEE.

ORIGEM Mifflin et al., 1990
▶ Homem, 75 kg, 175 cm, 30 anos → TMB=1748 kcal/dia
262
Oxidação de Substratos (Calorimetria Indireta)
INTERMEDIÁRIO

Oxidação_CHO=4,585·VCO₂−3,226·VO₂;  Gordura=1,695·VO₂−1,701·VCO₂  [g/min]

Taxa de oxidação de carboidratos e gorduras a partir de VO₂ e VCO₂; QR=VCO₂/VO₂ (0,7=gordura, 1,0=CHO).

ORIGEM Frayn, 1983
▶ QR=0,85: oxidação mista; exercício aeróbio intenso: QR→1,0
263
Glicogênio Muscular e Fadiga (Bergström)
INTERMEDIÁRIO

[Glicogênio]_final ≈ [Glicogênio]_inicial − Utilização;  fadiga quando [Glicogênio]<50 mmol/kg

Glicogênio muscular determina duração de exercício de alta intensidade; esvaziamento correlaciona com fadiga.

ORIGEM Bergström et al., 1967
▶ Maratonista: glicogênio inicial≈600 mmol/kg, esgota em ~28-32 km
264
Necessidade Proteica para Síntese Muscular
FUNDAMENTAL

N_proteína = 1,6-2,2 g/kg/dia (atleta força);  MPS ∝ [leucina]_plasma

Síntese de proteína muscular (MPS) estimulada por leucina; dose de proteína por refeição≈0,3-0,4 g/kg; base de nutrição esportiva.

ORIGEM Morton et al., 2018 — British Journal of Sports Medicine
▶ Atleta de 80 kg: 128-176 g de proteína/dia; priorizar distribuição equitativa
265
Índice Glicêmico e Carga Glicêmica
FUNDAMENTAL

CG = (IG × CHO_disponível) / 100

Carga glicêmica; CG alta (>20) eleva glicemia; base de timing nutricional pré/pós-treino.

ORIGEM Foster-Powell et al., 2002 — AJCN
▶ Arroz branco: IG=72, CHO=45g → CG=32 (alta); quinoa: CG=13
266
Balanço de Nitrogênio
INTERMEDIÁRIO

BN = Ingestão_N − (N_urinário + N_fecal + N_suor + N_outros)

BN positivo = anabolismo proteico; BN negativo = catabolismo; atleta em treinamento deve manter BN≥0.

ORIGEM Nutrição esportiva — Burke & Deakin, 2015
▶ BN=+2 g N/dia ≈ +12,5 g de proteína corporal/dia
267
Hidratação — Perda de Suor (Sweat Rate)
FUNDAMENTAL

SR = (Ppré − Ppós + ingestão − urina) / tempo  [L/h]

Taxa de suor em exercício; SR>1,5 L/h em clima quente; perda de 2% do peso corporal compromete desempenho.

ORIGEM ACSM Position Stand on Hydration, 2007
▶ Ciclista: SR=1,2 L/h, 2h → perda=2,4 L; necessidade de reidratação
268
Composição Corporal por DEXA
FUNDAMENTAL

%BF = Fat_mass / (Fat_mass + Lean_mass + BMC) × 100%

DEXA é padrão-ouro; BMC=mineral ósseo; %BF normal: homens 10-20%, mulheres 18-28%; atleta elite homem <10%.

ORIGEM DEXA — Hologic/GE Lunar
▶ Atleta de 80 kg, fat=8 kg, lean=68 kg, BMC=4 kg → %BF=10%
269
Critério de Hidratação (USG — Gravidade Urinária)
FUNDAMENTAL

USG = ρ_urina / ρ_água;  euidratado: USG<1.020

Gravidade específica urinária; USG>1.025 = desidratação significante; base de monitoramento de hidratação.

ORIGEM ACSM Guidelines — Fluid Replacement
▶ Atleta com USG=1.028 pre-treino: iniciar hidratação antes do exercício
270
Equilíbrio Energético e Alteração de Peso Corporal
FUNDAMENTAL

ΔPeso (kg) ≈ Δenergia_acumulada / 7700 kcal/kg

Déficit/excesso calórico e variação de peso; 1 kg de tecido adiposo≈7700 kcal; base de programas de emagrecimento.

ORIGEM Hall et al., 2012 — Lancet
▶ Déficit de 500 kcal/dia × 7 dias = 3500 kcal ≈ 0,45 kg de gordura/semana
Engenharia Eletrica de Potencia e Smart Grid
Analise de Sistemas de Potencia
271
Fluxo de Potência (Equações de Carga — AC)
AVANÇADO

Pᵢ = Σⱼ Vᵢ·Vⱼ·(Gᵢⱼcos δᵢⱼ + Bᵢⱼsin δᵢⱼ);  Qᵢ = Σⱼ Vᵢ·Vⱼ·(Gᵢⱼsin δᵢⱼ − Bᵢⱼcos δᵢⱼ)

Equações de injeção de potência ativa P e reativa Q em barra i; Gᵢⱼ,Bᵢⱼ=condutância e susceptância da linha; base de despacho.

ORIGEM Glover, Sarma & Overbye — Power Systems Analysis
▶ Base de solução de fluxo de carga Newton-Raphson para sistemas de 500+ barras
272
Impedância de Linha de Transmissão
AVANÇADO

Z = R + jωL;  γ = √(ZY);  Zc = √(Z/Y)

Constante de propagação γ e impedância característica Zc; Y=G+jωC (admitância shunt); base de análise de linhas longas.

ORIGEM Teoria de linhas de transmissão
▶ Linha de 500 kV: Zc≈300 Ω; γ complexa para análise de longa distância
273
Curtose de Carga Elétrica (Peak Factor)
FUNDAMENTAL

FK = P_pico / P_media;  FP = P_ativa / P_aparente = cos φ

Fator de forma e fator de potência; cos φ baixo aumenta corrente reativa; FP<0,92 gera multa nas concessionárias.

ORIGEM PRODIST — ANEEL — Módulo 8
▶ Indústria com FP=0,85 paga multa; FP=0,98 c/banco de capacitor
274
Corrente de Curto-Circuito (Thévenin)
INTERMEDIÁRIO

Icc = V_Thévenin / Z_Thévenin;  Icc3F = V_LN / Z₁

Corrente de curto trifásico (3F); Z₁=impedância de sequência positiva; base de dimensionamento de disjuntores.

ORIGEM Análise de curto-circuito — IEC 60909
▶ V_LN=13,8 kV, Z₁=0,5 Ω → Icc3F=27,6 kA
275
Potência Máxima de Transferência
INTERMEDIÁRIO

P_max = V²/(4·R_Th);  Z_carga_ótima = Z_Th*  (conjugado)

Máxima transferência de potência quando Z_carga=Z_Th*; em CA inclui cancelamento de reatância; base de otimização de geração.

ORIGEM Engenharia elétrica — Thévenin
▶ Em redes de transmissão: P_max depende de ângulo de carga e tensão
276
Regulação de Frequência (Droop Control)
INTERMEDIÁRIO

Δf = −R·ΔP;  R = Δf_nom / ΔP_nom [Hz/MW]

Controle primário de frequência; R=droop (3-5% típico); queda de 1 Hz demanda resposta de ΔP=1/R MW por gerador.

ORIGEM IEEE Power Engineering Society — Grid Control
▶ R=5%: queda de 0,25 Hz → gerador aumenta 5% da potência nominal
277
Transformador — Equação de Tensão e Relação de Espiras
FUNDAMENTAL

V₁/V₂ = N₁/N₂ = I₂/I₁;  S = V₁I₁ = V₂I₂

Relações de transformador ideal; N=espiras; potência conservada; base de projeto de transformadores de potência.

ORIGEM Eletromagnetismo — Faraday/Maxwell
▶ Transformador 13,8/0,22 kV: relação de espiras=62,7
278
Perda de Potência em Linha (Joule)
FUNDAMENTAL

P_perda = I²·R = (P²+Q²)·R/V²

Perdas ôhmicas em linha de transmissão; dependem de corrente quadrática; compensação reativa Q reduz perdas; base do despacho ótimo.

ORIGEM Engenharia de sistemas de potência
▶ I=1000 A, R=0,1 Ω/km, L=100 km → P_perda=10 MW
279
Critério N-1 de Segurança (Fluxo de Carga)
INTERMEDIÁRIO

Para todo contingência simples: |Pᵢⱼ| ≤ Pᵢⱼ_max

Critério de segurança N-1: sistema opera normalmente com perda de qualquer elemento; base do planejamento de sistemas elétricos.

ORIGEM NERC Reliability Standards TPL-001
▶ Perda de linha de transmissão: redistribuição de fluxo deve manter limites térmicos
280
Previsão de Demanda Elétrica (Modelo Horário)
INTERMEDIÁRIO

D(t) = D_base(t) + ΔD_tempo(t) + ΔD_dia(t) + residuo(t)

Decomposição de série temporal de demanda; componentes de tendência, sazonalidade diária/semanal; base de despacho e mercado.

ORIGEM Weron, 2006 — Electricity Price Forecasting
▶ Pico de demanda no sistema SE brasileiro: 18h em dias úteis de inverno
Mecanica Quantica Aplicada e Dispositivos
Fundamentos QM
281
Equação de Schrödinger Dependente do Tempo
AVANÇADO

iℏ ∂ψ/∂t = Ĥψ = [−ℏ²/(2m)·∇² + V(r,t)]ψ

Equação fundamental da MQ; solução ψ(r,t)=função de onda; |ψ|²=densidade de probabilidade; base de todos os dispositivos quânticos.

ORIGEM E. Schrödinger, 1926 (Nobel 1933)
▶ Poço quântico de GaAs/AlGaAs: equação de Schrödinger 1D com V por partes
282
Tunelamento Quântico (Efeito de Barreira)
AVANÇADO

T ≈ e^{−2κL};  κ = √(2m(V₀−E))/ℏ

Transmissividade de barreira retangular; κ=vetor de onda evanescente, L=espessura; fundamental em STM, diodos túnel, Flash.

ORIGEM G. Gamow, 1928
▶ L=1 nm, κ=10⁹ m⁻¹ → T≈e⁻²⁰≈2×10⁻⁹ (muito sensível a L)
283
Níveis de Energia de Poço Quântico
INTERMEDIÁRIO

En = n²ℏ²π²/(2mL²);  n=1,2,3,...

Energia discreta de poço 1D infinito; L=largura do poço; discretização = base de lasers de poço quântico (QW).

ORIGEM Solução de Schrödinger — poço infinito
▶ GaAs (m*=0,067me), L=10 nm → E₁=56 meV
284
Spin Qubit — Fidelidade de Porta
AVANÇADO

F = |⟨ψ_ideal|ψ_real⟩|²;  F > 0,999 para quantum error correction

Fidelidade de operações em qubits; erros de dephasamento e relaxamento; T₂>T₁; base de computação quântica tolerante a falhas.

ORIGEM Nielsen & Chuang — Quantum Computation, 2000
▶ Qubit de spin em silício: T₂>1 ms; fidelidade de porta>99,9%
285
Efeito Josephson AC
AVANÇADO

V = (ℏ/2e)·dφ/dt = (Φ₀/2π)·dφ/dt;  f = 2eV/h = V/Φ₀

Oscilação de frequência f pelo efeito Josephson AC; Φ₀=fluxo quântico=2×10⁻¹⁵ Wb; base de padrão de tensão quântico.

ORIGEM B.D. Josephson, 1962 (Nobel 1973)
▶ V=1 mV → f=483,6 GHz; padrão de tensão: precisão de 10⁻¹⁰
286
Princípio de Heisenberg (Posição-Momento)
FUNDAMENTAL

ΔxΔpx ≥ ℏ/2;  ΔEΔt ≥ ℏ/2

Limite fundamental de medição simultânea; Δx·Δp≥ℏ/2; largura de linha espectral: ΔE=ℏ/τ_vida.

ORIGEM W. Heisenberg, 1927 (Nobel 1932)
▶ Elétron localizado em 1 Å: Δp≥5×10⁻²⁵ kg·m/s → E_cin≥0,95 eV
287
Coerência Quântica e Decoerência (T₂)
AVANÇADO

ρ_off(t) = ρ_off(0)·e^{−t/T₂};  T₂* = (1/T₂ + 1/T₂_inhomo)⁻¹

Decoerência de superposição; T₂=tempo de decoerência; limitante para circuitos quânticos; criogenia mantém T₂>>T_porta.

ORIGEM Bloch, 1946 — aplicado a qubits
▶ Superconducting qubit (IBM): T₂~100 μs; spin qubit Si: T₂~1 ms
288
Condutância Quântica de Contato Pontual
AVANÇADO

G = G₀·Σ Tₙ = (2e²/h)·Σ Tₙ;  G₀=7,75×10⁻⁵ S

Condutância quantizada em múltiplos de G₀; Tₙ=transmissividade de canal n; base de nanoeletrônica e STM.

ORIGEM Landauer, 1957; van Wees et al., 1988
▶ Contato de ouro de 1 átomo: G=G₀≈77,5 μS
289
Força de Casimir
AVANÇADO

F/A = −ℏcπ²/(240 d⁴)

Força atrativa entre placas condutoras paralelas no vácuo; surge de flutuações de ponto zero; relevante em MEMS nanométricos.

ORIGEM H.B.G. Casimir, 1948
▶ Placas a d=100 nm: F/A≈0,013 Pa; a 10 nm: F/A≈1,3 kPa
290
Efeito Hall Quântico de Integer
AVANÇADO

Rxy = h/(νe²) = 25812,8/ν  Ω;  ν=inteiro

Resistência Hall quantizada; Rxy depende apenas de h/e² independente do material; padrão de resistência quântico.

ORIGEM K. von Klitzing, 1980 (Nobel 1985)
▶ ν=1: Rxy=25812,8 Ω = R_K (padrão internacional de resistência)
Biologia Marinha e Oceanografia Biologica
Producao Primaria
291
Produtividade Primária Oceânica (Steele)
INTERMEDIÁRIO

P = Pm · (I/Im) · e^{1−I/Im}

Fotossíntese fitoplanctônica; Pm=produção máxima, Im=irradiância ótima; inibição por luz excessiva (foto-inibição).

ORIGEM J.H. Steele, 1962
▶ Pm=5 mgC/m³/h, Im=100 W/m²; pico em 50-100 m de profundidade em tropical
292
Equação de Estado do Oceano (TEOS-10)
INTERMEDIÁRIO

ρ = ρ(S_A, T, P);  SA=Salinidade_Absoluta em g/kg

Equação de estado termodinâmica TEOS-10; ρ=densidade em kg/m³; base de modelos oceânicos CMIP6.

ORIGEM IOC/SCOR/IAPSO — TEOS-10, 2010
▶ T=25°C, SA=35 g/kg, P=0 → ρ=1023,3 kg/m³
293
Camada de Mistura Oceânica (Obukhov)
AVANÇADO

Hmix ∝ u*³/b_flux;  b_flux = g·(α·Q_heat)/(ρ·cp)

Profundidade de camada de mistura; u*=velocidade de fricção, b_flux=fluxo de flutuabilidade; base de modelos oceânicos de 1 camada.

ORIGEM Monin & Obukhov, 1954 — aplicado ao oceano
▶ Tropical: Hmix=20-50 m; polar no inverno: Hmix>1000 m
294
Stokes Drift (Transporte por Ondas)
AVANÇADO

Ud = ω·k·a²·e^{2kz}

Velocidade de deriva média de Stokes; a=amplitude, k=número de onda, ω=frequência; acumula plástico e larvas na superfície.

ORIGEM G.G. Stokes, 1847
▶ Ondas de 2m, T=10s: Ud≈0,1 m/s na superfície
295
Carbono Azul (Sequestro em Manguezais)
INTERMEDIÁRIO

Estoque_C = densidade_raiz · profundidade · C% · ρ_solo

Carbono orgânico em solo de manguezal/marisma; manguezais estocam 300-700 tC/ha; base de créditos de carbono azul.

ORIGEM McLeod et al., 2011 — Nature Geoscience
▶ Manguezal Indo-Pacífico: 1000 tC/ha (maior que floresta tropical)
296
Mortalidade de Estoque Pesqueiro (Modelo de Beverton-Holt)
INTERMEDIÁRIO

Z = F + M;  R = α·S/(1 + β·S)

Mortalidade total Z = pesca F + natural M; recrutamento de Beverton-Holt; base do manejo pesqueiro MSY.

ORIGEM Beverton & Holt, 1957
▶ Z=0,4/ano, M=0,2 → F=0,2; F=F_MSY para maximizar captura
297
Máximo Rendimento Sustentável (MSY)
INTERMEDIÁRIO

MSY = r·K/4;  B_MSY = K/2  (modelo logístico)

Máximo rendimento sustentável; r=taxa de crescimento intrínseca, K=capacidade de suporte; pesca a B_MSY=K/2.

ORIGEM Schaefer, 1954
▶ Atum com r=0,5/ano, K=10⁶ t → MSY=125000 t/ano a B=500000 t
298
Dispersão de Larvas Marinhas (Difusão + Advecção)
AVANÇADO

∂C/∂t + u·∇C = K·∇²C + S(x,t)

Equação de advecção-difusão para dispersão larval; u=correntes, K=difusividade oceânica; base de modelos de conectividade.

ORIGEM Oceanografia biológica — Cowen & Sponaugle, 2009
▶ Larvas de coral: dispersão de 100-300 km em 30 dias de PLD
299
Índice de Acidificação Oceânica (Ω_aragonita)
INTERMEDIÁRIO

Ω_arag = [Ca²⁺][CO₃²⁻] / Ksp_aragonita

Saturação de aragonita; Ω>1 favorece calcificação de corais; Ω<1 corrosivo; oceano superficial caiu de 3,5 para 2,8 desde 1850.

ORIGEM Orr et al., 2005 — Nature
▶ Ω=1,5 em águas polares já corrói conchas de pterópodos
300
Biomassa de Zooplâncton (Método de Filtragem)
FUNDAMENTAL

Biomassa (mg/m³) = M_seco / V_água_filtrada

Concentração de zooplâncton por arrasto de rede; calcula abundância de copépodes, krill; base de cadeias tróficas oceânicas.

ORIGEM Métodos oceanográficos — Longhurst, 1976
▶ Zona de afloramento costeiro: 200-2000 mg/m³; giro subtropical: 5-20 mg/m³
Engenharia de Residuos Solidos
Caracterizacao de Residuos
301
Geração Per Capita de Resíduos Sólidos
FUNDAMENTAL

GPC = m_RSU / (n_habitantes × período)  [kg/hab/dia]

Taxa de geração per capita; Brasil≈1,07 kg/hab/dia; relaciona com PIB e urbanização; base de planejamento de gestão.

ORIGEM ABRELPE — Panorama dos Resíduos Sólidos, 2022
▶ São Paulo: 1,3 kg/hab/dia; Manaus: 0,8 kg/hab/dia
302
Aterro Sanitário — Produção de Biogás (IPCC)
AVANÇADO

DDOC_m = (Σ DDOC_a,T,j) × e^{−k_j·t}

Matéria orgânica degradável dissolvida; k=taxa de degradação (0,05-0,4/ano); CH₄=DDOC_m×F×16/12×MCF.

ORIGEM IPCC 2006 GL — Waste Sector
▶ Aterro de 1000 t/ano de RSU gera ≈100-200 Nm³ CH₄/t RSU
303
Recalque de Aterro Sanitário
INTERMEDIÁRIO

s = Cc·H/(1+e₀)·log(σ'f/σ'i) + Creep_secundário

Recalque combinado por consolidação de lixo + fluência (degradação); RSU: Cc≈0,5-1,5; monitora-se a superfície.

ORIGEM Geotecnia de aterros sanitários
▶ Aterro de 20m: recalque de 1-3m em 10 anos por degradação orgânica
304
Lixiviado — Carga Poluidora
INTERMEDIÁRIO

C_lixiviado = C_resíduo × Fator_lixiviação × (P−ET)

Produção de lixiviado: chuva infiltrada lixivia contaminantes; C_res=concentração no resíduo; base de sistema de tratamento.

ORIGEM EPA Guidance Manual — Leachate
▶ Aterro de 10 ha, P−ET=500 mm/ano → Q_lixiv≈50000 m³/ano
305
Eficiência de Coleta Seletiva (Desvio de Aterro)
FUNDAMENTAL

Taxa_desvio = (m_reciclável + m_compostável) / m_total × 100%

Percentual de resíduos desviados do aterro; meta europeia 70%; Brasil≈4%; correlaciona com custo de aterramento.

ORIGEM PNRS — Lei 12305/2010; EU Waste Framework Directive
▶ País com taxa_desvio=60%: prolonga vida útil de aterros 2,5×
306
Poder Calorífico de RSU (Método de Dulong Modificado)
INTERMEDIÁRIO

PCI_RSU = Σ fᵢ·PCIᵢ  (aditivo por fração)

PCI médio de RSU≈8-12 MJ/kg (úmido); segregação de orgânicos e úmidos aumenta PCI da fração seca para incineração.

ORIGEM Tchobanoglous et al. — Integrated Solid Waste Management
▶ RSU sem orgânicos: PCI≈15-20 MJ/kg; viável para WtE
307
Tempo de Retenção em Compostagem
FUNDAMENTAL

HRT ≥ 55°C por 3 dias (pilha) ou ≥ 55°C por 15 dias (windrow)

Critério de higienização de composto; temperatura termofílica elimina patógenos; base da norma de composto maduro.

ORIGEM EPA 503 / USEPA Biosolids
▶ Composto com HRT=21 dias a 60°C: classe A (uso irrestrito)
308
Modelo de Decaimento de Primeiro Ordem (Aterro)
INTERMEDIÁRIO

C_t = C_0 · e^{−k·t};  t₁/₂ = 0,693/k

Decaimento de matéria orgânica em aterro; k=0,02-0,1 ano⁻¹; base de projeção de produção de biogás e recalque.

ORIGEM IPCC Waste Model — First Order Decay
▶ k=0,05/ano: t₁/₂=14 anos; produção de gás cessa após ~50 anos
309
Análise do Ciclo de Vida — Impacto de Embalagem
INTERMEDIÁRIO

GWP = Σ mᵢ × EFᵢ  [kg CO₂eq]

Potencial de aquecimento global de produto; EF=fator de emissão de kg CO₂eq por kg de material; base de ecodesign.

ORIGEM ISO 14040/44 — LCA Methodology
▶ Garrafa PET 500mL: GWP≈0,12 kg CO₂eq; vidro: 0,22 kg CO₂eq
310
Taxa de Recuperação de Materiais (TMR)
FUNDAMENTAL

TMR = m_recuperado / m_total_entrada × 100%

Eficiência de estação de triagem; TMR≈60-80% para papel, 50-70% para plástico; base de contrato de concessão de coleta seletiva.

ORIGEM ABRELPE — Manual de Gestão Integrada de RSU
▶ Central de triagem processa 100 t/dia: recupera 65 t (TMR=65%)
Bioinformatica Estrutural e Docking Molecular
Analise Estrutural
311
RMSD de Estruturas Proteicas
FUNDAMENTAL

RMSD = √(Σᵢ mᵢ·|rᵢ−r'ᵢ|² / Σmᵢ)

Desvio quadrático médio de posições atômicas entre duas estruturas; RMSD<2 Å indica conformações similares; base de avaliação de modelagem.

ORIGEM Estrutura proteica — Kabsch, 1976
▶ Homologia >30%: RMSD<2 Å frequentemente; modelo de AlphaFold: RMSD médio≈1,5 Å
312
Energia de Docking (Função de Score de AutoDock)
AVANÇADO

ΔGbind = ΔGvdW + ΔGhbond + ΔGelec + ΔGsolv + ΔGtor

Energia de ligação predita; termos de van der Waals, H-bond, eletrostática, solvatação, entropia conformacional.

ORIGEM Morris et al., 1998 — AutoDock
▶ ΔGbind=−9 kcal/mol → Ki≈200 nM (inibidor potente)
313
Constante de Dissociação de Ligação (Ki por Score)
INTERMEDIÁRIO

Ki = e^{ΔGbind/(RT)};  ΔGbind = RT·ln(Ki)

Relação termodinâmica; ΔGbind=−9 kcal/mol → Ki=240 nM; cada −1,36 kcal/mol corresponde a 10× em afinidade.

ORIGEM Termodinâmica de ligação
▶ ΔGbind=−12 kcal/mol → Ki≈1 pM (fármaco muito potente)
314
Score de Conservação de Sequência (BLOSUM62)
INTERMEDIÁRIO

Score = Σᵢ BLOSUM62(aᵢ,bᵢ);  E = KMN·e^{−λS}

Alinhamento de sequência com BLOSUM62; e-value E estima acaso; E<10⁻³ indica homologia significativa.

ORIGEM Henikoff & Henikoff, 1992
▶ Alinhamento com Score=200 → E<10⁻⁴⁰: homólogo evidente
315
Energia Livre de Solvatação (Born-Hückel)
AVANÇADO

ΔGsolv = −q²/(2r)·(1/εin − 1/εout)

Energia de solvatação eletrostática de íon; εin=diélétrico da proteína≈4, εout=água=80; base de cálculos MM-PBSA.

ORIGEM M. Born, 1920 — aplicado a biofísica
▶ Aminoácido carregado saindo de proteína para água: ΔGsolv favorável (estabiliza)
316
Predição de Estrutura (pLDDT de AlphaFold)
FUNDAMENTAL

pLDDT ∈ [0,100];  pLDDT>90=alta confiança; <50=desordenado

Score de confiança por resíduo do AlphaFold2; correlaciona com B-factor cristalográfico; base de uso de estruturas preditas.

ORIGEM AlphaFold2 — Jumper et al., 2021 (Nature)
▶ pLDDT=95 para domínio globular; pLDDT=30 para região IDR
317
Equação de AMBER/CHARMM (Campo de Força)
AVANÇADO

E_total = ΣEb + ΣEθ + ΣEφ + ΣE_vdW + ΣE_elec

Campo de força atomístico; Eb=ligação, Eθ=ângulo, Eφ=torção, LJ=vdW, Coulomb=elétrico; base de MD proteica.

ORIGEM AMBER — Cornell et al., 1995; CHARMM — Brooks et al., 1983
▶ MD de 1 μs de proteína de 100 kDa: ~10⁶ passos de 1 fs
318
Pressão de Steered MD (Constant Force Pulling)
AVANÇADO

F = k·(vt − Δx);  W = ∫F·dx;  ΔG = W − W_irreversivel

MD por steering (SMD); força puxa ligante para fora do sítio; ΔG por Jarzynski ou estimativa de barreira de energia.

ORIGEM Jarzynski, 1997; SMD — Izrailev et al., 1997
▶ Ligante em sítio ativo: barreira de saída ΔG‡≈10-30 kBT
319
B-Factor Cristalográfico (Fator de Temperatura)
INTERMEDIÁRIO

f(T) = f₀·e^{−B·sin²θ/λ²};  B = 8π²<u²>

Parâmetro de temperatura atômico; <u²>=deslocamento quadrático médio; B alto = região flexível ou desordenada.

ORIGEM X-ray crystallography
▶ B-factor médio<20 Å² = estrutura bem ordenada; >40 Å² = região flexível
320
Índice de Druggability (Score de Hot Spot)
AVANÇADO

ΔGhot_spot = ΔGwt − ΔGala_scan;  druggable se ΔGhs>2 kcal/mol

Residuos hot spot por varredura de alanina; contribuição desproporcional para ligação; Sítio druggable se tem hot spots concentrados.

ORIGEM Clackson & Wells, 1995 — Alanine scanning
▶ Interface PPI com 3 hot spots: druggable por fármaco de pequena molécula
""";
    }
}
