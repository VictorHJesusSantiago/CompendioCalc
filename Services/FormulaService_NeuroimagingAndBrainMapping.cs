namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol15Parte1 = """
Neuroimagem e Mapeamento Cerebral
fMRI e BOLD
001
Equação de Bloch (IRM Funcional)
AVANÇADO

dM/dt = M×γB − R₂·Mx·x̂ − R₂·My·ŷ − R₁·(Mz−M₀)·ẑ

Equações de Bloch para magnetização nuclear; R₁=1/T₁ (relaxação longitudinal), R₂=1/T₂ (transversal); base do fMRI.

ORIGEM F. Bloch, 1946 (Nobel 1952)
▶ T₁ matéria cinzenta≈1,3 s; T₂≈90 ms a 3 T
002
Sinal BOLD (Blood Oxygen Level Dependent)
AVANÇADO

ΔS/S ≈ −ΔR₂* · TE = TE · Δχ · ω₀ · ΔY · CBV

Sinal fMRI-BOLD; ΔY=variação de desoxihemoglobina, CBV=volume sanguíneo cerebral, TE=tempo de eco, ω₀=frequência de Larmor.

ORIGEM Ogawa et al., 1990
▶ ΔS/S≈1-5% durante ativação cognitiva a 3 T
003
Modelo Hemodinâmico de Balloon (Buxton)
AVANÇADO

dq/dt = fin·f(fin,E) − fout(v)·q/v;  dv/dt = (fin − fout(v))/τ

Modelo de Buxton-Balloon para resposta hemodinâmica; q=deoxihemoglobina, v=volume vascular; base do GLM de fMRI.

ORIGEM Buxton et al., 1998
▶ Tempo ao pico da HRF: 4-6 s após estímulo
004
Coeficiente de Difusão Aparente (DWI/DTI)
INTERMEDIÁRIO

S = S₀ · e^{−b·ADC};  b = γ²G²δ²(Δ−δ/3)

Difusão aparente de água em tecido; b-value codifica sensibilidade à difusão; ADC reduzido em isquemia aguda.

ORIGEM Stejskal & Tanner, 1965
▶ ADC água livre≈3×10⁻³ mm²/s; matéria branca≈0,7×10⁻³ mm²/s
005
Anisotropia Fracional (FA — DTI)
INTERMEDIÁRIO

FA = √(3/2) · √(Σ(λᵢ−λ̄)²) / √(Σλᵢ²)

FA mede direcionalidade da difusão; FA=0 isotrópico; FA=1 anisotrópico puro; FA>0,4 em tratos mielinizados saudáveis.

ORIGEM Basser & Pierpaoli, 1996
▶ Corpo caloso: FA≈0,7-0,8; cortex: FA≈0,2
006
Modelo Linear Geral (GLM) de fMRI
AVANÇADO

Y = Xβ + ε;  β̂ = (X'X)⁻¹X'Y;  t = cβ̂ / √(c(X'X)⁻¹c'·σ²)

Modelo de análise de fMRI; Y=série temporal, X=matriz de design, β=coeficientes de ativação, c=contraste.

ORIGEM Friston et al., 1994 — SPM
▶ t>3,1 (p<0,001) como limiar de ativação em análise univariada
007
Resposta Hemodinâmica (HRF — Função Gama)
AVANÇADO

HRF(t) = (t/d)^a · e^{−(t−d)/b} − c·(t/d')^a' · e^{−(t−d')/b'}

Função de resposta hemodinâmica canônica SPM; diferença de duas funções gama; pico≈5s, undershoot≈15s.

ORIGEM Friston et al., 1998 — SPM canonical HRF
▶ Convolução de HRF com o vetor de estímulo = regressor de design
008
Tomografia por Emissão de Pósitrons (PET — Patlak)
AVANÇADO

C_t(t)/C_p(t) = Ki·∫₀ᵗ C_p(τ)dτ/C_p(t) + V₀

Análise gráfica de Patlak; Ki=taxa de captação irreversível; slope do gráfico linearizado = fluxo metabólico.

ORIGEM Patlak et al., 1983
▶ Ki de FDG em glicólise cerebral≈0,06 mL/g/min
009
Conectividade Funcional (Correlação de Pearson)
INTERMEDIÁRIO

r(A,B) = Cov(A,B) / (σA·σB);  Z = 0,5·ln((1+r)/(1−r))

Correlação de séries temporais de ROIs; transformação Z de Fisher para comparação estatística de conectividade.

ORIGEM Biswal et al., 1995 — resting-state fMRI
▶ r>0,3 considerado conectividade funcional significativa
010
EEG — Potencial de Superfície
AVANÇADO

V(r) = (1/4πσ)·Σ Jₛ·(r−r')/(|r−r'|³) dV'

Potencial EEG na superfície; Jₛ=densidade de corrente de dipolo, σ=condutividade; base do problema direto em EEG.

ORIGEM Poisson — aplicado a EEG
▶ Resolução espacial de EEG≈1-2 cm; alta resolução temporal (<1 ms)
011
MEG — Equação de Maxwell Simplificada
AVANÇADO

B(r) = (μ₀/4π)·Σ Jₛ×(r−r')/(|r−r'|³) dV'

Campo magnético MEG; Jₛ=corrente de dipolo neuronal; MEG insensível a correntes radiais; complementar ao EEG.

ORIGEM Lei de Biot-Savart — aplicado a MEG
▶ MEG mede campos cerebrais de 10-1000 fT (femtotesla)
012
Análise de Componentes Independentes (ICA) de fMRI
AVANÇADO

X = AS;  S = WX  (W=A⁻¹);  max I(sᵢ)

ICA decompõe fMRI em componentes independentes; separa artefatos de redes em repouso; base da análise dual-regression.

ORIGEM Bell & Sejnowski, 1995; Beckmann & Smith, 2004
▶ ICA identifica 15-70 redes funcionais em fMRI de repouso
013
Espectroscopia de Próton (¹H-MRS) — Creatina
INTERMEDIÁRIO

[Metabólito] ≈ (Area_pico / Area_Cr) × [Cr]_referência

Quantificação por razão ao pico de creatina (Cr) a 3,0 ppm; NAA↓ indica dano neuronal; Cho↑ indica desmielinização.

ORIGEM Proton MRS — Saunders & Bhakoo, 1995
▶ NAA/Cr normal≈1,4-1,6; <1,2 indica patologia
014
Volume Cerebral Normalizado (nBV)
FUNDAMENTAL

nBV = Volume_cerebral / Volume_intracraniano_total × 100%

Atrofia cerebral normalizada pelo volume intracraniano; nBV reduz 0,2-0,5%/ano no envelhecimento normal; maior em demência.

ORIGEM Neuroimagem morfométrica
▶ Alzheimer: perda de 1-3%/ano; controles saudáveis: 0,2-0,4%/ano
015
Morphometric Brain Analysis (VBM — SPM)
INTERMEDIÁRIO

GM_densidade(x) = segmentação × suavização_gaussiana × normalização

VBM analisa diferenças de densidade de matéria cinzenta voxel-a-voxel; base de estudos de envelhecimento e doenças.

ORIGEM Ashburner & Friston, 2000
▶ Redução de GM em hipocampo = marcador precoce de Alzheimer
016
Probabilidade de Tractografia (Fibras de Balle)
AVANÇADO

P(path) = Π P(θᵢ | f̂ᵢ)  (probabilistic tractography)

Tractografia probabilística; P(θ)=probabilidade de orientação de fibra baseada em CSD/FOD; gera distribuição de tratos.

ORIGEM Behrens et al., 2003 — FSL probtrackx
▶ Tractografia do fórnix: conecta hipocampo ao septo
017
Índice de Perfusão Cerebral (ASL)
AVANÇADO

CBF = (ΔM/M₀) · λ/(2αT₁blood) · e^{TI/T₁blood}

Fluxo sanguíneo cerebral por Arterial Spin Labeling; λ=coeficiente de partição sangue/tecido, α=eficiência de marcação.

ORIGEM Detre & Alsop, 1999
▶ CBF cortical normal≈60 mL/100g/min; isquemia: <20 mL/100g/min
018
Potencial Evocado (ERP — N200)
INTERMEDIÁRIO

Amplitude_N200 = V(t=200ms) − V_baseline;  Latência = argmin V(t)

Componente ERP negativo a 200 ms; N200 reflete discriminação e inibição de resposta; amplitude e latência são biomarcadores.

ORIGEM Näätänen & Gaillard, 1983
▶ N200 maior em tarefa de Go/No-Go em estudo de impulsividade
019
Sincronização Oscilatória (PLV — Phase Locking Value)
AVANÇADO

PLV = |n⁻¹·Σₜ e^{i·Δφ(t)}|

Phase Locking Value entre dois sinais EEG; PLV=1 perfeitamente sincronizados; PLV=0 sem acoplamento; banda gama (30-100 Hz).

ORIGEM Lachaux et al., 1999
▶ PLV gama corticais alto durante ligação de objeto visual
020
Índice de Lateralização (LI) Funcional
FUNDAMENTAL

LI = (A_esquerda − A_direita) / (A_esquerda + A_direita)

Lateralização de ativação; LI=+1 totalmente esquerda; LI=−1 totalmente direita; linguagem: LI>0,2 = dominância esquerda.

ORIGEM Seghier, 2008 — LI toolbox SPM
▶ LI=0,7 no giro frontal inferior esquerdo = dominância de linguagem
Engenharia de Pontes e Estruturas Especiais
Estabilidade Estrutural
021
Equação de Euler (Flambagem de Coluna)
FUNDAMENTAL

Pcr = π²EI / (KL)²

Carga crítica de flambagem; K=fator de comprimento efetivo (1=articulado-articulado, 0,5=engastado-engastado); E=módulo, I=inércia.

ORIGEM L. Euler, 1744
▶ Pilar de aço: E=200 GPa, I=10⁻⁴ m⁴, L=5m, K=1 → Pcr≈7896 kN
022
Momento de Inércia de Viga Mista (Steiner)
FUNDAMENTAL

I_total = Σ(Iᵢ + Aᵢ·dᵢ²)

Teorema de Steiner; dᵢ=distância do centroide da parte i ao eixo neutro global; fundamental em vigas mistas aço-concreto.

ORIGEM J. Steiner — Teorema dos eixos paralelos
▶ Viga T: flange contribui com Aᵢ·dᵢ² dominante
023
Equação de Linha de Influência (Müller-Breslau)
INTERMEDIÁRIO

η(x) = deslocamento/deformação_unitária_no_ponto_de_ação

Linha de influência por princípio de Müller-Breslau; forma da deflexão para carga unitária móvel; dimensiona pontes para convóis.

ORIGEM H. Müller-Breslau, 1886
▶ Momento máximo em viga simplesmente apoiada: carga na posição com η máximo
024
Equação do Cabo Parabólico (Pontes Suspensas)
FUNDAMENTAL

y = wx²/(2H);  H = wL²/(8f)

Forma parabólica do cabo; w=carga distribuída, H=tração horizontal, f=flecha, L=vão; base de pontes pênseis.

ORIGEM Mecânica de cabos
▶ Golden Gate: L=1280 m, f=144 m → H=wL²/(8×144)
025
Tração no Cabo Principal de Ponte Pênsil
INTERMEDIÁRIO

T = H/cos θ = √(H² + (wx)²)

Tração no cabo inclinado; varia ao longo do comprimento; máxima nos pylôns; base do dimensionamento de cabos de aço.

ORIGEM Análise de pontes suspensas
▶ Vão de 500 m, f=50 m: T_max≈1,1×H no pylôn
026
Método de Cross (Distribuição de Momentos)
INTERMEDIÁRIO

MDF = FEM + Σ carreamentos;  k = EI/L;  DF = k/Σk

Método de Cross (moment distribution); FEM=momento fixo, DF=fator de distribuição; resolve pórticos hiperestáticos.

ORIGEM H. Cross, 1932
▶ Pórtico de 3 pavimentos resolvido iterativamente com convergência em 3-4 ciclos
027
Coeficiente de Impacto para Pontes Rodoviárias
FUNDAMENTAL

CImpacto = 1 + 40/(L + 150)  (DNIT)

Fator de amplificação dinâmica; L=vão em metros; pontes curtas (L<5m): CI≈1,25; grandes vãos: CI→1.

ORIGEM DNIT — Manual de Projeto de Obras de Arte Especiais
▶ Vão de 10 m: CI=1+40/160=1,25; vão de 40 m: CI=1,21
028
Rigidez de Mola de Apoio (Neoprene)
INTERMEDIÁRIO

K_neoprene = G·A / t

Rigidez de aparelho de apoio em neoprene; G=módulo de cisalhamento≈1-2 MPa, A=área, t=espessura total; controla expansão térmica.

ORIGEM ABNT NBR 9452 — Inspeção de pontes
▶ G=1 MPa, A=0,04 m², t=0,04 m → K=1 MN/m
029
Frequência Natural de Ponte (1° Modo)
INTERMEDIÁRIO

f₁ = (π²/2π L²) · √(EI/m)  = π/(2L²) · √(EI/m)

Frequência fundamental de ponte como viga; m=massa por unidade de comprimento; f₁>3 Hz evita ressonância com pedestre.

ORIGEM Vibração de vigas
▶ Passarela L=30 m, EI=10⁸ N·m², m=2000 kg/m → f₁≈2,5 Hz
030
Resistência à Torção de Seção Fechada (Bredt)
AVANÇADO

T = 2·A_enclosed · q;  τ_max = T/(2·A_enclosed·t_min)

Fórmula de Bredt para torção em seções fechadas (caixão); A_enclosed=área fechada da seção, t=espessura da parede.

ORIGEM R. Bredt, 1896
▶ Seção caixão de ponte: τ_max<0,06fck (cisalhamento de torção)
031
Escorregamento de Cabo de Protensão (Perdas)
AVANÇADO

ΔP_atrito = P₀·(1 − e^{−μα − kx})

Perda de protensão por atrito; μ=coeficiente de atrito (bainha), α=ângulo acumulado, k=desvio ondulatório, x=comprimento.

ORIGEM ABNT NBR 6118 — Concreto protendido
▶ Cabo com μ=0,2, α=π/2 → perda=1−e⁻⁰˙³¹≈27%
032
Flecha por Fluência e Retração (NBR 6118)
INTERMEDIÁRIO

α_f,tot = α_imediata · (1 + φ)

Flecha total inclui fluência (coeficiente φ); φ depende de umidade, espessura equivalente e tempo; φ≈1,5-4 para concreto.

ORIGEM ABNT NBR 6118:2014 — item 17
▶ Flecha imediata=10 mm, φ=2,5 → flecha total=35 mm
033
Carga de Vento em Estrutura Esbelta (ABNT NBR 6123)
FUNDAMENTAL

F_w = Ca · q · A;  q = 0,613·V_k²  [Pa]

Pressão dinâmica de vento; Ca=coeficiente aerodinâmico, Vk=velocidade característica (m/s); fundamental para torres e pontes.

ORIGEM ABNT NBR 6123:1988
▶ Vk=45 m/s → q=1243 Pa≈1,24 kPa na região
034
Pontes Estaiadas — Inclinação de Estai
INTERMEDIÁRIO

T_estai = N_tabuleiro / cos θ;  V_estai = T_estai · sin θ

Equilíbrio no ponto de ancoragem de estai; θ=ângulo do estai com a horizontal; estais mais inclinados eficientes em rigidez.

ORIGEM Análise de pontes estaiadas
▶ Ponte Octavio Frias: θ≈60°; T_estai≈2×força horizontal do tabuleiro
035
Índice de Dano Estrutural de Miner
INTERMEDIÁRIO

D = Σ (nᵢ / Nᵢ);  falha quando D=1

Regra de dano de Miner para fadiga; nᵢ=ciclos aplicados, Nᵢ=ciclos de ruptura; linear, conservador para cargas variáveis.

ORIGEM M.A. Miner, 1945
▶ Viga metálica de ponte: D acumulado dimensiona vida de fadiga
036
Deflexão de Viga (EI) — Método da Carga Conjugada
FUNDAMENTAL

δ_max = 5·w·L⁴ / (384·EI)  (viga simplesmente apoiada, carga uniforme)

Flecha máxima de viga com carga distribuída; EI=rigidez à flexão; controla L/400 em pontes rodoviárias.

ORIGEM Resistência dos materiais
▶ Viga I: EI=4×10¹¹ N·mm², L=10m, w=20 kN/m → δ_max=12 mm
037
Módulo de Reação Horizontal de Cortina
AVANÇADO

K_h = n_h · z  (solo granular);  E_h = K_h · δ_h

Pressão horizontal de solo por modelo de Winkler; n_h=coeficiente de variação, z=profundidade; base de parede de contenção.

ORIGEM Terzaghi & Peck, 1967
▶ Areia densa: n_h=80 MN/m³; areia fofa: n_h=6 MN/m³
038
Força de Frenagem em Pontes (NBR 7188)
FUNDAMENTAL

F_frenagem = 0,30·P_eixo  (caminhão padrão TB-450)

Força horizontal de frenagem/aceleração; 30% do carregamento de eixo; transmitida ao tabuleiro e aos pilares.

ORIGEM ABNT NBR 7188:2013
▶ TB-450: força de frenagem=0,30×450=135 kN por faixa
039
Rigidez de Placa Ortotrópica
AVANÇADO

Dx = Ex·h³/(12(1−νxy·νyx));  Dy = Ey·h³/(12(1−νxy·νyx))

Rigidez de placa com propriedades ortogonais diferentes; tabuleiros de pontes metálicas frequentemente ortotrópicos.

ORIGEM Teoria de placas — Timoshenko & Woinowsky-Krieger
▶ Tabuleiro ortotrópico: Dx≠Dy pela presença de vigas longitudinais
040
Pressão de Serviço em Ancoragem de Estai
INTERMEDIÁRIO

σ_estai = P/(Ac);  σ_adm = 0,45·fpu  (AASHTO)

Tensão de serviço em estai de pontes; fpu=resistência última do cabo; limite de 45% fpu garante margem de segurança.

ORIGEM AASHTO Guide Spec. for Design of Cable-Stayed Bridges
▶ Estai de aço fpu=1860 MPa → σ_adm=837 MPa
Imunologia Quantitativa e Vacinas
Imunidade de Rebanho
041
Número Básico de Reprodução (R₀) com Vacinação
FUNDAMENTAL

R_ef = R₀·(1−p);  cobertura para imunidade de rebanho: p_c = 1 − 1/R₀

Imunidade de rebanho; p=fração vacinada; R_ef<1 → controle; cobertura crítica para sarampo (R₀=15): pc=93%.

ORIGEM Anderson & May, 1991
▶ COVID-19 (R₀=3): pc=1−1/3=67%; variante Delta (R₀=6): pc=83%
042
Cinética de Anticorpos (Modelo Bifásico)
AVANÇADO

Ab(t) = A·e^{−α·t} + B·e^{−β·t}

Decaimento bifásico de anticorpos; fase rápida α (células plasmáticas de vida curta), lenta β (células de vida longa); base de vacinologia.

ORIGEM Slifka & Ahmed, 1998
▶ IgG pós-vacinação: fase rápida t₁/₂≈30 dias; lenta t₁/₂≈200 dias
043
Afinidade de Anticorpo-Antígeno (Ka)
INTERMEDIÁRIO

Ka = [AbAg]/([Ab][Ag]) = kon/koff  [M⁻¹]

Constante de associação; Ka>10⁹ M⁻¹ = alta afinidade; base de maturação de afinidade em centros germinativos.

ORIGEM Imunoquímica — Eisen & Siskind, 1964
▶ Anticorpo terapêutico: Ka=10¹⁰ M⁻¹ (Kd=0,1 nM)
044
ELISA — Curva Padrão (4PL)
INTERMEDIÁRIO

y = D + (A−D)/(1+(x/C)^B)

Ajuste de 4 parâmetros logísticos; A=mínima assíntota, D=máxima, C=EC₅₀, B=inclinação; padrão em ELISA quantitativo.

ORIGEM Rodbard et al., 1978
▶ ELISA de IgG: C=1 μg/mL; faixa linear entre 0,1-10 μg/mL
045
Eficácia de Vacina (Redução de Risco Relativo)
FUNDAMENTAL

VE = 1 − RR = 1 − (AR_vacinados / AR_não-vacinados)

Eficácia de vacina; AR=ataque rate; VE=90% significa 90% de redução de risco de infecção; padrão regulatório FDA/EMA.

ORIGEM Regulatory guidance — FDA, 2020
▶ mRNA-COVID: 95 infectados/placebo, 5/vacinados → VE=95%
046
Modelo de Dinâmica de Células T (Effector-Memory)
AVANÇADO

dE/dt = αN − δE·E;  dM/dt = βE − δM·M

Modelo dinâmico de expansão clonal e formação de memória; α=expansão, β=conversão, δ=mortalidade; base de vacinação.

ORIGEM Antia et al., 2005
▶ Resposta primária: pico de Cells T a 7 dias; memória persiste décadas
047
Complemento — Via Clássica (C1q Binding)
INTERMEDIÁRIO

Rate_ativação ∝ [C1q]·[IgG]ₙ;  n≥2 IgGs necessários

Ativação da via clássica do complemento; mínimo 2 IgGs próximas; base de citotoxicidade dependente do complemento (CDC).

ORIGEM Müller-Eberhard, 1988
▶ IgG1 e IgG3 ativam complemento; IgG4 não ativa
048
Limiar de Soroconversão (Seroconversion)
FUNDAMENTAL

Soroconversão = Ab_pós/Ab_pré ≥ 4×  ou  Ab_pós ≥ título_limiar

Critério de soroconversão; aumento de 4× no título ou atingir título limiar protetivo; padrão de avaliação vacinal.

ORIGEM WHO guidelines for vaccine evaluation
▶ Influenza: título HI≥1:40 considerado protetor (50% redução)
049
Parâmetro de Breadth Imunológico
INTERMEDIÁRIO

Breadth = n_epítopos_reconhecidos / n_epítopos_testados

Amplitude de resposta imune; breadth alta = proteção cruzada; fundamental em vacinas de influenza e HIV pan-específicas.

ORIGEM Imunologia de vacinas
▶ Vacina de HIV de alta breadth reconhece 70% de cepas circulantes
050
Modelo de Seleção de Células B em Centro Germinal
AVANÇADO

dA/dt = (1−μ)·A·r_B(A) − dA;  seleção por afinidade

Maturação de afinidade; mutação somática + seleção por antígeno; Ka aumenta 100-1000× após vacinação de reforço.

ORIGEM Kepler & Perelson, 1993
▶ 3ª dose de vacina mRNA: anticorpos com Ka 10× maior que após 2ª dose
051
Índice de Adequação de Adjuvante (VAI)
INTERMEDIÁRIO

VAI = razão_Th1/Th2 = IFNγ/IL-4

Razão de citocinas IFNγ (Th1) e IL-4 (Th2); adjuvantes de alumínio: Th2; MPL/AS01: Th1; direciona tipo de proteção.

ORIGEM Vacinologia de sistemas
▶ Adjuvante AS01B (RTS,S/malária): VAI alto → Th1 dominante
052
Neutralização — EC₅₀ de Anticorpo
INTERMEDIÁRIO

Y = Ymin + (Ymax−Ymin)/(1+(EC₅₀/C)^n)

Concentração de anticorpo que neutraliza 50% de vírus; curva sigmoidal; EC₅₀ baixa = anticorpo potente.

ORIGEM Ensaio de neutralização por redução de placa (PRNT)
▶ Anticorpo monoclonal anti-SARS-CoV-2: EC₅₀=0,1 ng/mL = potente
053
Imunogênicidade Preditiva (Immunoinformatics — MHC Binding)
AVANÇADO

IC₅₀_MHC = e^{−Σ wᵢ·AAᵢ}  (matriz posicional ponderada)

Predição de ligação peptídeo-MHC; IC₅₀<50 nM = forte ligação; base de design de vacinas por epitopes.

ORIGEM NetMHCpan — Lund et al., 2004
▶ Epítopo SARS-CoV-2 Spike com IC₅₀=10 nM → alta imunogenicidade prevista
054
Proteção Correlata (Correlate of Protection)
AVANÇADO

log(P_proteção) = β₀ + β₁·log(Ab_titer)

Modelo logístico de proteção em função de título de anticorpo; β₁=declive; base regulatória para correlatos imunes.

ORIGEM Plotkin & Gilbert, 2012
▶ Sarampo: título IgG>120 mIU/mL → >95% de proteção
055
Número de Doenças Evitadas (NNV)
FUNDAMENTAL

NNV = 1 / (AR_controle − AR_vacinado) = 1/(AR·VE)

Número necessário a vacinar para evitar um caso; NNV baixo = vacina custo-efetiva; base de análises de saúde pública.

ORIGEM Farrington, 1993
▶ VE=90%, AR=10% → NNV=1/(0,1×0,9)≈11 pessoas por caso evitado
056
Cinética de Decaimento de IgG (Mecanicista)
FUNDAMENTAL

IgG(t) = IgG₀ · exp(−ln2·t / t₁/₂_IgG);  t₁/₂≈21 dias

Meia-vida de IgG catabolismo; t₁/₂≈21 dias sem célula de memória; células plasmáticas de vida longa mantêm níveis.

ORIGEM Janeway et al. — Immunobiology, 9ª ed.
▶ IgG1 t₁/₂≈21 dias; IgA secretória ≈5-6 dias
057
Dissociação Antígeno-Anticorpo (Sensoramento SPR)
AVANÇADO

koff = −dRU/dt / RU  (fase de dissociação)

Constante de dissociação por Ressonância Plasmônica de Superfície (Biacore); Kd=koff/kon; mede afinidade de anticorpos.

ORIGEM SPR — Karlsson & Larsson, 2004
▶ Anticorpo terapêutico: Kd<1 nM (koff<0,001 s⁻¹)
058
Score ELISPOT (Células Secretoras)
INTERMEDIÁRIO

SFU = n_spots · fator_diluição / n_células_semeadas

Spot-Forming Units por 10⁶ PBMCs; mede resposta de células T específicas; SFU>50 indica resposta celular robusta.

ORIGEM Czerkinsky et al., 1983 — ELISpot
▶ Vacina BCG: SFU>200 indica forte resposta anti-tuberculose
059
Índice de Proliferação Linfocitária (CFSE)
INTERMEDIÁRIO

PI = 1 + Σ (n_células_divisão_k × 2^k) / n_células_divisão_0

Índice de proliferação por diluição de CFSE; PI>2 indica proliferação significante em resposta a antígeno.

ORIGEM Lyons & Parish, 1994 — CFSE dilution
▶ PI=4 em teste de linfoproliferação a PPD: forte resposta à TB
060
Taxa de Escape de Variante Viral
AVANÇADO

P_escape = 1 − Σ P(neutralização | variante_j)

Probabilidade de escape imunológico de variante viral; soma sobre epítopos; base do monitoramento de variantes SARS-CoV-2.

ORIGEM Imunologia evolutiva viral
▶ Variante Omicron: escape de 60-80% de anticorpos de vacinação primária
Ciencias do Esporte e Analise de Desempenho
Aerodinamica Esportiva
061
Potência de Saída Ciclismo (Modelo Aerodinâmico)
AVANÇADO

P_total = P_ar + P_atrito + P_grav + P_inercia

Componentes de potência; P_ar=(1/2)·ρ·CdA·v³, P_grav=M·g·G·v, P_atrito=Crr·M·g·v; base de otimização em ciclismo.

ORIGEM Martin et al., 1998 — cycling power model
▶ Ciclista 75 kg, v=10 m/s, G=0, CdA=0,3 → P_ar≈440 W
062
Índice de Desenvolvimento de Lance (Basquete)
FUNDAMENTAL

EFF = (Pts + Reb + Ast + Stl + Blk − Turnovers − ((FGA−FGM)+(FTA−FTM))

Eficiência de jogador de basquete por jogo; métrica de desempenho simplificada da NBA; normalizada por minutos jogados.

ORIGEM NBA Advanced Stats
▶ Jogador com 25 Pts, 10 Reb, 7 Ast, 1 Stl → EFF≈40
063
Expected Goals (xG) — Futebol
INTERMEDIÁRIO

xG = Σ P_gol(posição, tipo, pressão)

Gols esperados por oportunidade; P derivada de modelo logístico com distância, ângulo, tipo de chute; base de análise tática.

ORIGEM Modelos de xG — StatsBomb, Opta
▶ Chute a 15m, ângulo central, sem marcação: xG≈0,35
064
TRIMP — Treinamento de Impulso (Banister)
INTERMEDIÁRIO

TRIMP = t·HR_ratio·e^{1,92·HR_ratio};  HR_ratio=(HRex−HRrest)/(HRmax−HRrest)

Carga interna de treino; t=duração em min; integral ponderada pela FC; base do modelo de desempenho de Banister.

ORIGEM Banister et al., 1975
▶ Corrida de 60 min a HR_ratio=0,7 → TRIMP≈120 unidades
065
Modelo de Desempenho de Banister (Fitness-Fatigue)
AVANÇADO

p(t) = p₀ + k₁·g(t) − k₂·h(t);  g(t)=Σ TRIMP·e^{−(t−n)/τ₁}

Performance = forma (fitness g) − fadiga (h); τ₁≈45 dias, τ₂≈15 dias; otimiza periodização de treinamento.

ORIGEM Banister, 1982; Morton, 1991
▶ Pico de performance previsto 7-14 dias após taper
066
Índice de Variabilidade de Ritmo (CV de Pace)
FUNDAMENTAL

CV_pace = σ_pace / mean_pace × 100%

Variabilidade de ritmo em corrida; CV baixo = corrida uniforme (estratégia negativa eficaz); CV alto = irregular.

ORIGEM Análise de desempenho em corridas de fundo
▶ Elite maratonista: CV_pace<1%; corredor amador: 3-8%
067
Eficiência de Nado (SWOLF)
FUNDAMENTAL

SWOLF = tempo_por_comprimento + braçadas_por_comprimento

Índice de eficiência de nado; menor SWOLF = mais eficiente; correlaciona com velocidade e técnica.

ORIGEM Análise de desempenho em natação
▶ Elite 100m livre: SWOLF≈25-30; iniciante: SWOLF>50
068
Zona de Velocidade Crítica de Golfe (Smash Factor)
FUNDAMENTAL

Smash = Ball_speed / Club_head_speed;  otimum=1,48-1,50

Razão de transferência de velocidade bola/tacada; smash factor>1,50 indica puro contato; base de análise de golf.

ORIGEM TrackMan Golf Analytics
▶ Tiger Woods em peak: smash factor=1,49-1,50 em driver
069
Coeficiente de Restituição em Impactos Esportivos
INTERMEDIÁRIO

e = v₂_relativa / v₁_relativa = (v₂A − v₂B)/(v₁B − v₁A)

Elasticidade do impacto; e=1 perfeitamente elástico; e=0 perfeitamente inelástico; bola de tênis: e≈0,73; squash: e≈0,8.

ORIGEM Mecânica do impacto esportivo
▶ Bola de basquete NBA: e≈0,76 (bounce height 75% da drop height)
070
Índice de Velocidade do Serviço de Tênis
AVANÇADO

Drag = 0,5·Cd·ρ·A·v²;  v_final = v_inicial · e^{−(Cd·ρ·A/2m)·d}

Desaceleração da bola por arrasto; Cd≈0,6 para bola de tênis; v cai de 200 para ~100 km/h entre saque e quadra.

ORIGEM Biomecânica do tênis — Elliott, 2003
▶ Saque de 220 km/h → chega à linha de saque a ≈180 km/h
071
Modelos de Ranking (Elo Rating)
FUNDAMENTAL

R'_A = R_A + K·(S_A − E_A);  E_A = 1/(1+10^{(R_B−R_A)/400})

Sistema Elo de ranking; K=fator de ajuste, S=resultado real (1,0,0,5), E=resultado esperado; base de ranking de xadrez, tênis.

ORIGEM A.E. Elo, 1978
▶ Diferença de 200 Elo → E_A=0,76 (76% de vitórias esperadas)
072
Coeficiente de Arrasto de Projétil Esportivo
INTERMEDIÁRIO

Fd = 0,5·ρ·v²·Cd·A;  Cd = f(Re, spin_rate)

Força de arrasto em bola ou projétil esportivo; Re=Reynolds; spin gera efeito Magnus; base de trajetória de futebol e beisebol.

ORIGEM Aerodinâmica de bolas esportivas
▶ Bola de futebol (Re=10⁵): Cd varia de 0,1 a 0,5 com superfície
073
Aceleração Angular de Saque (Tênis)
INTERMEDIÁRIO

α = τ / I_raquete;  v_cabeça = α · r_empunhadura

Aceleração angular da raquete; torque muscular τ e inércia I determinam velocidade de cabeça da raquete.

ORIGEM Biomecânica do tênis — Elliott et al., 2003
▶ v_raquete=30 m/s × Smash factor=1,3 → v_bola≈39 m/s
074
Potência Específica em Remo (Pace vs Power)
FUNDAMENTAL

P = (2,80 / Pace)³ × 270  [Watts]

Relação potência-ritmo em remoergômetro Concept2; Pace em min/500m; fundamental para prescrição de treino.

ORIGEM Concept2 Rowing Calculator
▶ Pace=2:00/500m → P=(2,80/2)³×270≈(1,4)³×270≈744 W
075
Density Score de Composição Esportiva
FUNDAMENTAL

Dscore = Σ (Dificuldade_elementoi × valor_i) + Ligações + Bônus

Score de Dificuldade em ginástica artística; soma de dificuldades dos elementos conectados com bônus de ligação.

ORIGEM FIG Code of Points 2022-2024
▶ Rotina de barra fixa de elite: D-score≈6,5-7,0
076
Índice de Carga Interna (RPE-ACWR)
INTERMEDIÁRIO

ACWR = Carga_semanal_aguda / Carga_média_4semanas_crônica

Razão carga aguda/crônica; ACWR 0,8-1,3 = zona segura; ACWR>1,5 = risco elevado de lesão muscular.

ORIGEM Gabbett, 2016 — British Journal of Sports Medicine
▶ ACWR=1,7 em pré-temporada: risco 2× maior de lesão
077
Efeito Magnus em Bola de Futebol
INTERMEDIÁRIO

F_Magnus = ρ·Γ·v·L = ρ·π·r²·ω·v·L

Força de Magnus por spin; Γ=circulação, ω=velocidade angular; deflexão lateral de chutes com efeito.

ORIGEM G. Magnus, 1853
▶ Chute com efeito: ω=60 rad/s, v=25 m/s → deflexão≈2-3 m em 30 m
078
Zona de Frequência Cardíaca (5 Zonas)
FUNDAMENTAL

Z1:<60%; Z2:60-70%; Z3:70-80%; Z4:80-90%; Z5:>90% de FCmáx

Classificação de intensidade por FC; Z2=base aeróbia (80% do volume elite); Z4-5=intensidade limiar e VO₂máx.

ORIGEM Costill & Wilmore, 1994 — Exercise Physiology
▶ 80% do treino de elite em Z1-Z2 (polarized training)
079
Índice de Saltabilidade (RSI — Reactive Strength)
INTERMEDIÁRIO

RSI = altura_salto / tempo_contato_solo  [m/s]

Índice de força reativa; mede elasticidade e stiffness muscular; RSI>3 m/s = atleta élite em esportes de salto.

ORIGEM McClymont, 2003 — Reactive Strength Index
▶ Saltador élite: altura=0,5 m, tempo contato=0,15 s → RSI=3,3 m/s
080
Eficiência de Pedalada (Torque Efetivo)
INTERMEDIÁRIO

η_pedal = T_efetivo / T_aplicado = cos(θ_pedalada)

Componente efetiva de força de pedalada; ângulo 90° é ótimo; pedômetro mede eficiência direta.

ORIGEM Biomecânica do ciclismo
▶ Ciclista amador: η≈50-60%; profissional: η≈75-80%
""";
    }
}
