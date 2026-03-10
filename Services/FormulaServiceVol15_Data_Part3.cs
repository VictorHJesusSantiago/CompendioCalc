namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol15Parte3 = """
Acustica Arquitetonica e Conforto Ambiental
Acustica de Salas
161
Tempo de Reverberação (Fórmula de Sabine)
FUNDAMENTAL

RT₆₀ = 0,161 · V / A;  A = Σ αᵢ · Sᵢ  [m² Sabine]

Tempo para decaimento de 60 dB; V=volume da sala (m³), A=absorção total; RT₆₀ ótimo: música≈2s, fala≈0,8s.

ORIGEM W.C. Sabine, 1900
▶ Sala 200 m³, A=50 Sabines → RT₆₀=0,644 s
162
Tempo de Reverberação de Eyring
INTERMEDIÁRIO

RT₆₀ = −0,161·V / (S·ln(1−ᾱ))

Fórmula de Eyring para salas com alta absorção; ᾱ=absorção média; mais precisa que Sabine para ᾱ>0,3.

ORIGEM C.F. Eyring, 1930
▶ ᾱ=0,5, V=500 m³, S=200 m² → RT₆₀=1,16 s
163
Nível de Pressão Sonora (SPL)
FUNDAMENTAL

SPL = 20·log₁₀(P_rms/P_ref)  [dB];  P_ref=20 μPa

Escala logarítmica de pressão; +6 dB=dobra da pressão; +10 dB≈percepção de dobra de loudness; limiar da dor=130 dB.

ORIGEM ANSI S1.1 — Acústica
▶ Conversa normal: 60 dB; motor de avião: 140 dB
164
Isolamento Acústico (TL — Transmission Loss)
INTERMEDIÁRIO

TL = SPL_emissor − SPL_receptor − 10·log₁₀(S/A)

Isolamento de parede entre dois ambientes; S=área da parede, A=absorção no receptor; índice Rw caracteriza parede.

ORIGEM ISO 140/717
▶ Parede dupla de tijolo: Rw≈55 dB; alvenaria simples: Rw≈45 dB
165
Lei de Massa (Isolamento Acústico)
FUNDAMENTAL

TL = 20·log₁₀(m·f) − 47  [dB]  (ar)

Isolamento de parede simples; m=massa superficial (kg/m²), f=frequência; dobrar m aumenta TL em 6 dB.

ORIGEM Bergmann, 1954 — Mass Law
▶ Parede 200 kg/m², f=500 Hz → TL≈46 dB
166
Critério de Ruído Ocupacional (NR-15)
FUNDAMENTAL

Dose = Σ (tᵢ / Tmáx,i) ≤ 1,0

Dose de ruído diária; tᵢ=tempo exposto, Tmáx,i=tempo máximo (85 dB→8h, 88→4h etc.); dose>1 exige EPIs.

ORIGEM NR-15 — Portaria MTE 3214/78; OSHA 29 CFR 1910.95
▶ 4h a 88 dB + 4h a 85 dB → Dose=1,0 (no limite)
167
Frequência Própria de Sala (Modos Axiais)
INTERMEDIÁRIO

f = c/(2L)·n;  fn,m,p = (c/2)·√((n/Lx)²+(m/Ly)²+(p/Lz)²)

Modos de ressonância em sala retangular; abaixo de 300 Hz dominam modos axiais; controla coloração sonora.

ORIGEM Teoria de salas retangulares
▶ Sala 5×4×3 m: primeiro modo axial em x: f=34 Hz
168
Inteligibilidade da Fala (STI)
INTERMEDIÁRIO

STI = Σ wₖ·MTIₖ;  MTIₖ = 10·log₁₀(SNRₖ)/15 + 1/2

Índice de transmissão de fala; STI>0,75 excelente; STI<0,45 ruim; base de projeto de sistemas de PA e salas de aula.

ORIGEM Houtgast & Steeneken, 1985 — IEC 60268-16
▶ STI=0,85: sala de conferência bem projetada
169
Índice de Conforto Térmico (PMV — Fanger)
AVANÇADO

PMV = f(M, W, Icl, ta, tr, var, pa)  (equação de Fanger)

Voto médio predito; PMV de −3 (frio) a +3 (quente); PMV=0 neutro; ISO 7730: PMV entre −0,5 e +0,5.

ORIGEM P.O. Fanger, 1970
▶ Escritório: M=1,2 met, Icl=0,5 clo, ta=23°C → PMV≈0
170
Frequência de Corte de Sala (Schroeder)
INTERMEDIÁRIO

f_Schroeder = 2000 · √(RT₆₀/V)  [Hz]

Acima de f_S há modos densos e comportamento difuso; abaixo de f_S modos discretos; base de difusores e absorvedores.

ORIGEM M.R. Schroeder, 1962
▶ Sala 500 m³, RT₆₀=1 s → f_S=63 Hz
171
Iluminância Natural (Fator de Luz Diurna — FLD)
FUNDAMENTAL

FLD = Eᵢ / Ee × 100%

Fator de luz diurna; Eᵢ=iluminância interior, Ee=exterior difusa; FLD>2% recomendado para atividades de escritório.

ORIGEM ABNT NBR 15215 — Iluminação natural
▶ FLD=5% a 3m de uma janela em dia nublado padrão
172
Índice de Reprodução de Cor (IRC/CRI)
FUNDAMENTAL

CRI = 100 − 4,6 · √(Σᵢ ΔEᵢ²)

Fidelidade de cor de fonte luminosa; CRI=100 luz natural; CRI>80 recomendado para escritórios; CRI>90 para museus.

ORIGEM CIE 13.3 — Método de IRC
▶ LED de qualidade: CRI=95; lâmpada sódio: CRI=25
173
Nível de Impacto de Piso (L'nT,w)
INTERMEDIÁRIO

L'nT,w = Ln,w − ΔLw;  L'nT = Ln + 10·log₁₀(T/0,5)

Isolamento ao ruído de impacto; L'nT,w≤58 dB (NBR 15575 para quarto de dormir); quanto menor, melhor.

ORIGEM ISO 140-7 / ABNT NBR 15575
▶ Piso com laje dupla + flutuante: L'nT,w≈45 dB
174
Atenuação de Barreira Acústica (Maekawa)
INTERMEDIÁRIO

ΔL = 10·log₁₀(3 + 20N);  N = 2·(A+B−D)/λ

Atenuação por barreira; N=número de Fresnel, A+B=caminho difratado, D=caminho direto, λ=comprimento de onda.

ORIGEM Z. Maekawa, 1968
▶ N=5: ΔL=10·log₁₀(103)≈20 dB
175
Critério de Ruído Urbano (Lden)
INTERMEDIÁRIO

Lden = 10·log(12/24·10^{Ld/10} + 4/24·10^{(Le+5)/10} + 8/24·10^{(Ln+10)/10})

Nível dia-entardecer-noite; ponderação por período; meta da UE: Lden<55 dB em áreas residenciais.

ORIGEM Diretiva Europeia 2002/49/EC — END
▶ Lden=63 dB em beira de rodovia → necessita medidas de mitigação
176
Índice de Eficiência Energética de Fachada
FUNDAMENTAL

U_fachada = Σ (Uᵢ·Aᵢ) / A_total  [W/m²K]

Transmitância térmica média de fachada; U baixo = melhor desempenho térmico; ABNT NBR 15575: U<3,7 W/m²K (zona 1-3).

ORIGEM ABNT NBR 15575 — Edificações habitacionais
▶ Fachada com janela U=3 e parede U=2: U_médio depende das proporções
177
Critério de Glare (UGR — Unified Glare Rating)
AVANÇADO

UGR = 8·log(0,25/Lb · Σ(L²ω/p²))

Índice de ofuscamento; Lb=luminância de fundo, L=luminância da fonte, ω=ângulo sólido, p=índice de Guth; UGR<19 escritórios.

ORIGEM CIE 117 — Discomfort Glare
▶ UGR=16 em escritório bem iluminado: conforto visual aceitável
178
Temperatura de Globo Negro (MRT)
INTERMEDIÁRIO

MRT⁴ = t_globo_K⁴ + (h_c/εσ)·(t_globo − ta)

Temperatura média radiante; h_c=coeficiente convectivo, ε=emissividade, σ=Stefan-Boltzmann; base de conforto térmico.

ORIGEM Bedford, 1936 — Globe thermometer
▶ MRT alta em sala com paredes quentes→ sensação de calor mesmo com ta ameno
179
Coeficiente de Absorção Sonora (α)
FUNDAMENTAL

α = 1 − (Intensidade_refletida / Intensidade_incidente)

α=0 reflexão total; α=1 absorção total; espuma de poliuretano 50 mm: α_500Hz≈0,8; concreto liso: α≈0,02.

ORIGEM ASTM C423 — Absorption Coefficient
▶ Sala de concerto: painéis com α médio≈0,3-0,5 para RT₆₀ alvo
180
Velocidade de Som em Ar (Temperatura)
FUNDAMENTAL

c = 331,3 · √(1 + T_C/273,15) ≈ 331,3 + 0,606·T_C  [m/s]

Velocidade de som em ar seco; a 20°C: c≈343 m/s; temperatura afeta comprimento de onda e frequência de modos.

ORIGEM Acústica física
▶ T=30°C → c≈349 m/s; T=0°C → c≈331 m/s
Engenharia de Fundacoes e Estacas
Capacidade de Carga
181
Capacidade de Carga de Estaca (Aoki-Velloso)
INTERMEDIÁRIO

R = rp·Ap + rl·Σ(fsi·Asi);  rp,rl = fatores do método

Método de Aoki-Velloso para capacidade de carga de estaca por SPT; rp=coeficiente de ponta, rl=fuste; base de projeto no Brasil.

ORIGEM Aoki & Velloso, 1975
▶ Estaca pré-moldada em areia média: capacidade calculada por SPT ao longo do fuste
182
Recalque de Fundação (Teoria de Terzaghi)
INTERMEDIÁRIO

s = Cc·H/(1+e₀)·log(σ'f/σ'i)  (argila normalmente consolidada)

Recalque de consolidação; Cc=índice de compressão, H=espessura da camada, e₀=índice de vazios inicial.

ORIGEM K. Terzaghi, 1925
▶ Argila mole, H=5m, Cc=0,4, e₀=1,2, σ'f/σ'i=1,5 → s=22 cm
183
Grau de Consolidação (Terzaghi)
AVANÇADO

Uz = 1 − Σ (2/M²)·e^{−M²Tv};  M=(2m+1)π/2;  Tv=cv·t/H²

Fator tempo de consolidação; Tv=0,197 → Uz=50%; Tv=0,848 → Uz=90%; cv=coeficiente de adensamento.

ORIGEM K. Terzaghi, 1925
▶ cv=10⁻⁷ m²/s, H=2m, t=1 ano → Tv=0,79 → Uz≈90%
184
Pressão de Pré-Adensamento (Cc vs Cs)
AVANÇADO

s = Cs·H/(1+e₀)·log(σ'p/σ'i) + Cc·H/(1+e₀)·log(σ'f/σ'p)

Recalque diferenciado: compressão elástica (Cs) até tensão de pré-adensamento σ'p, depois virgem (Cc).

ORIGEM Terzaghi, 1943 — Soil Mechanics
▶ Solo levemente pré-adensado: Cs≈0,05, Cc≈0,35; menor recalque que NC
185
Resistência ao Cisalhamento (Mohr-Coulomb)
FUNDAMENTAL

τ_f = c' + σ'·tan φ'

Envoltória de Mohr-Coulomb; c'=coesão efetiva, φ'=ângulo de atrito efetivo; base de todos os problemas de estabilidade.

ORIGEM C.-A. Coulomb, 1776; O. Mohr, 1900
▶ Areia: c'=0, φ'=32° → τ_f=σ'·tan32°=0,625σ'
186
Capacidade de Carga de Sapata (Terzaghi)
INTERMEDIÁRIO

qult = c·Nc + q·Nq + 0,5·γ·B·Nγ

Capacidade última de sapata rasa; Nc, Nq, Nγ=fatores de capacidade de carga de Terzaghi (função de φ'); FS=3 usual.

ORIGEM K. Terzaghi, 1943
▶ φ=30°: Nc=30,1; Nq=18,4; Nγ=22,4
187
Permeabilidade de Kozeny-Carman
AVANÇADO

k = d²·e³ / [180·(1+e)] · (γw/μ)

Permeabilidade hidráulica do solo; d=diâmetro representativo, e=índice de vazios; base de análise de fluxo de água.

ORIGEM Kozeny, 1927; Carman, 1937
▶ Areia fina (d=0,1mm, e=0,7): k≈10⁻⁵ m/s
188
Comprimento de Transferência de Carga de Estaca
FUNDAMENTAL

Lt ≈ 3-5 × diâmetro  (transferência de ponta)

Comprimento crítico em que 95% da carga é transferida; abaixo disso estaca é flutuante; base de espaçamento em grupo.

ORIGEM Mecânica de fundações
▶ Estaca D=0,5m: Lt≈1,5-2,5m de transferência de ponta
189
Fórmula de Osterberg (Prova de Carga Bidireccional)
INTERMEDIÁRIO

Carga_total = 2 × leitura_célula_Osterberg  (aproximação simétrica)

Prova de carga bidirecional em estaca; célula hidráulica no meio da estaca; mede fuste inferior e ponta vs fuste superior.

ORIGEM J.O. Osterberg, 1989
▶ Célula Osterberg mede até 300 MN em estacas de fundação de pontes
190
Empuxo de Terra Ativo (Rankine)
FUNDAMENTAL

Ka = tan²(45° − φ/2) = (1−sinφ)/(1+sinφ);  σh = Ka·σv + Ka·q

Coeficiente de empuxo ativo; pressão horizontal em muro de arrimo; base do projeto de contenções.

ORIGEM W.J.M. Rankine, 1857
▶ φ=30°: Ka=1/3; pressão horizontal = 1/3 da vertical
191
Resistência SPT-N (Correlação com φ)
INTERMEDIÁRIO

φ' ≈ 27,1 + 0,3·N₆₀ − 0,00054·N₆₀²  (Peck et al.)

Ângulo de atrito estimado pelo SPT para areias; N₆₀=SPT corrigido por energia de 60%; aproximação para projetos preliminares.

ORIGEM Peck, Hanson & Thornburn, 1974
▶ N₆₀=20 → φ'≈27,1+6−0,22=32,9°
192
Carga Admissível de Fundação (FS)
FUNDAMENTAL

q_adm = q_ult / FS;  FS ≥ 3 (sapatas)  FS ≥ 2 (estacas)

Fator de segurança global aplicado à capacidade última; FS=3 para sapatas normais; incorpora incertezas de ensaios e modelos.

ORIGEM ABNT NBR 6122 — Fundações
▶ q_ult=600 kPa, FS=3 → q_adm=200 kPa para sapata isolada
193
Adensamento Secundário (Fluência de Solo)
AVANÇADO

Sα = Cα·H·log(t₂/t₁)/(1+e_EOP)

Recalque pós-adensamento primário; Cα=índice de fluência; argilas orgânicas: Cα≈0,03-0,06; importante em fundações de edifícios altos.

ORIGEM Mesri & Godlewski, 1977
▶ Argila orgânica, H=5m, Cα=0,04: fluência de 10 anos→ 15 anos = 5 cm adicional
194
Pressão de Poros em Solo Saturado (Skempton)
AVANÇADO

Δu = B·[Δσ₃ + A·(Δσ₁ − Δσ₃)]

Parâmetros de pressão de poros A e B de Skempton; B=1 para solo saturado; A varia de −0,5 a 1 (−0,5 a 0 = solo muito dilatante).

ORIGEM A.W. Skempton, 1954
▶ Argila normalmente consolidada: A=0,5-1,0 na ruptura
195
Efeito de Grupo de Estacas (Eficiência)
INTERMEDIÁRIO

Eg = qg / (n · q_estaca_individual)

Eficiência de grupo; qg=capacidade do grupo, n=número de estacas; Eg<1 em solo coesivo; Eg≈1 em solo granular.

ORIGEM Converse-Labarre (empírico)
▶ 9 estacas em argila: Eg≈0,7 → capacidade do grupo = 6,3 × individual
196
Recalque Diferencial Admissível
FUNDAMENTAL

δ_adm = δmax/L_vão ≤ 1/300 (estrutura corrente)

Recalque diferencial relativo admissível; 1/500 para pórticos sensíveis; 1/150 para estruturas simples; base NBR 6118.

ORIGEM ABNT NBR 6122; Meyerhof, 1956
▶ Vão de 6m: recalque diferencial admissível≤20 mm
197
Coeficiente de Reação Horizontal (Winkler)
AVANÇADO

Es = ks · δh  (reação de solo por mola de Winkler)

Módulo de reação horizontal; ks = Es_solo / D; base de análise de estacas e cortinas submetidas a cargas laterais.

ORIGEM Winkler, 1867 — aplicado a fundações
▶ Areia densa: ks≈50-150 MN/m³; argila rígida: ks≈12-25 MN/m³
198
Resistência de Atrito Lateral de Estaca (α-method)
INTERMEDIÁRIO

fs = α · Su  (argila)

Resistência lateral unitária em argila; α=0,5-1,0 (diminui com Su); método α clássico de Tomlinson; base de cálculo de fuste.

ORIGEM Tomlinson, 1957
▶ Su=100 kPa, α=0,6 → fs=60 kPa
199
Módulo de Young de Solo (Correlação)
INTERMEDIÁRIO

Es ≈ 400 · Su  (argila); Es ≈ 700·N₆₀  [kPa] (areia)

Estimativa de módulo de deformabilidade do solo; Su=resistência não-drenada; N=SPT; base de cálculo de recalque imediato.

ORIGEM Correlações geotécnicas — Bowles, 1988
▶ Argila com Su=80 kPa → Es≈32 MPa; areia N=20 → Es≈14 MPa
200
Solução de Boussinesq (Pressão sob Sapata)
INTERMEDIÁRIO

σz = (3q·z³)/(2π·(r²+z²)^{5/2})  (carga pontual)

Tensão vertical em ponto a profundidade z e distância r; integra-se para cargas distribuídas; base de recalque elástico.

ORIGEM J. Boussinesq, 1885
▶ Carga de 100 kN, z=1m, r=0 → σz=47,7 kPa
Ciencia de Dados Espaciais e Sensoriamento Remoto
Radar e SAR
201
Equação de Radar (SAR)
AVANÇADO

Pr = (Pt·G²·λ²·σ) / ((4π)³·R⁴·L)

Equação do radar; Pt=potência transmitida, G=ganho de antena, σ=seção de retorno, R=distância, L=perdas do sistema.

ORIGEM Radar equation — Skolnik, 2001
▶ SAR Sentinel-1: λ=5,6 cm (banda C), R=700 km
202
Resolução Espacial de Satélite (Rayleigh)
FUNDAMENTAL

δ = 1,22·λ·f/D  [m];  GSD = altitude·pix_size/focal_length

Resolução angular e tamanho de pixel no solo; GSD=Ground Sample Distance; Sentinel-2: GSD=10m (banda 2-4-8).

ORIGEM Lord Rayleigh, 1879 — aplicado a satélites
▶ WorldView-3: altitude=617 km, focal=8,8m, pixel=8 μm → GSD=0,31m
203
Transformada de Fourier em Imagem (FFT)
AVANÇADO

F(u,v) = Σ Σ f(x,y)·e^{−2πi(ux/M+vy/N)}

Transformada bidimensional; F(u,v)=espectro de frequências espaciais; base de filtragem, compressão e análise de texturas.

ORIGEM J.B. Fourier, 1822 — FFT por Cooley & Tukey, 1965
▶ Padrão periódico em imagem agrícola: pico no espectro 2D
204
Classificação de Imagem (SVM — Hiperespaço)
AVANÇADO

min(||w||²/2) s.t. yᵢ(w·xᵢ+b)≥1−ξᵢ;  f(x)=sgn(w·x+b)

Máquina de vetores de suporte para classificação de pixels; hyperplane ótimo entre classes; kernel RBF para não-linear.

ORIGEM Vapnik & Cortes, 1995
▶ Classificação de uso do solo: SVM com kernel RBF → acurácia>90%
205
Índice de Área Queimada (NBR)
INTERMEDIÁRIO

NBR = (NIR − SWIR₂) / (NIR + SWIR₂);  dNBR = NBR_pré − NBR_pós

Índice de queima; dNBR>0,1 indica área queimada; dNBR>0,6 = severidade alta; bandas Landsat/Sentinel.

ORIGEM Key & Benson, 2006 — USFS
▶ dNBR=0,3: cicatriz de incêndio de severidade moderada
206
Correção Atmosférica (6S-2)
AVANÇADO

ρ_superfície = (ρ_TOA/T↓ − T↑ − ρ_path) / (T↑·T↓ + S·(ρ_path − ρ_TOA/T↓))

Transferência radiativa para correção atmosférica; 6S=Second Simulation of the Satellite Signal in the Solar Spectrum.

ORIGEM Vermote et al., 1997 — 6S Model
▶ Bandas ópticas de Landsat/Sentinel corrigidas para análises de séries temporais
207
Altitude de Satélite em Órbita Circular
FUNDAMENTAL

v = √(GM_T/r);  T = 2πr/v = 2π√(r³/GM_T)

Velocidade orbital e período; r=R_Terra+altitude; Landsat-8: altitude=705 km, T=99 min; GPS: altitude=20200 km.

ORIGEM Newton — lei da gravitação universal
▶ Sentinel-2: altitude=786 km → v=7,46 km/s, T=100 min
208
Banda de Frequência de Radar (Penetração)
INTERMEDIÁRIO

δ_penetração ∝ λ / (σ_condutividade)^{0,5}  (skin depth)

Penetração de radar em vegetação/solo; banda P (70cm) penetra floresta; banda X (3cm) superficial; base de SAR arqueológico.

ORIGEM Física de ondas eletromagnéticas — SAR
▶ Banda L (25cm): penetra 2-3m em floresta tropical
209
Acurácia de Classificação (Kappa de Cohen)
FUNDAMENTAL

κ = (P_o − P_e) / (1 − P_e)

Concordância além do acaso; κ>0,8 excelente; κ=0,6-0,8 bom; base de validação de mapas de uso do solo.

ORIGEM J. Cohen, 1960
▶ P_o=0,85, P_e=0,3 → κ=0,79 (bom acordo)
210
Índice de Urbanização (NDBI)
FUNDAMENTAL

NDBI = (SWIR − NIR) / (SWIR + NIR)

Índice de área construída; NDBI>0 indica área urbana; oposto de NDVI; base de monitoramento de expansão urbana.

ORIGEM Zha et al., 2003
▶ Centro urbano denso: NDBI≈0,2-0,4; área verde: NDBI≈−0,3
211
Kriging Espacial (Semivariograma)
AVANÇADO

γ(h) = 0,5·Var[Z(x+h) − Z(x)] = C₀ + C·(1 − e^{−3h/a})

Semivariograma exponencial; C₀=pepita, C=patamar, a=alcance; base de krigagem para interpolação de dados ambientais.

ORIGEM Matheron, 1963 — Geostatistics
▶ Temperatura do ar: alcance de autocorrelação≈50-200 km
212
Erro de Georeferenciamento (RMSE)
FUNDAMENTAL

RMSE = √(Σ((xᵢ−x'ᵢ)²+(yᵢ−y'ᵢ)²)/n)  [pixels]

Erro de posicionamento de pontos de controle; RMSE<0,5 pixels excelente; padrão de qualidade de ortorretificação.

ORIGEM Padrão de acurácia cartográfica — PEC
▶ RMSE=0,3 pixels para ortofoto de 0,5m → erro posicional≈15 cm
213
Detecção de Mudança Temporal (CVA — Change Vector Analysis)
INTERMEDIÁRIO

|ΔV| = √(Σ(bᵢ_t1 − bᵢ_t2)²);  θ = arctan(Δb₂/Δb₁)

Magnitude e direção de mudança multibanda; |ΔV| grande = mudança significativa; θ indica tipo de mudança.

ORIGEM Malila, 1980
▶ Desmatamento: |ΔV|>50 DN e θ indica perda de NIR
214
Equação de Precipitação Estimada por Radar (Z-R)
INTERMEDIÁRIO

Z = a·R^b  (Marshall-Palmer: a=200, b=1,6)

Relação refletividade Z (dBZ) e taxa de precipitação R (mm/h); base do radar meteorológico.

ORIGEM Marshall & Palmer, 1948
▶ Z=40 dBZ → R=(10⁴/200)^{1/1,6}≈9 mm/h
215
Modelo Digital de Elevação — Erro de Sombra SAR
AVANÇADO

Shadow: θ_incidência < arctan(h/d);  Layover: θ < arctan(h_slope/d)

Geometria de distorção em SAR; shadow=sem retorno em encostas afastadas; layover=encostas para frente; afeta DEM de radar.

ORIGEM SAR Geometry — Richards, 2009
▶ SRTM (θ=54°): shadow mínimo mas layover em terrenos íngremes
216
Cálculo de Biomassa Florestal por LiDAR
AVANÇADO

AGB = a·(CHM_mean)^b · (Densidade_pulsos)^c

Biomassa aérea por LiDAR; CHM=Canopy Height Model; coeficientes calibrados por bioma; precisão±20% vs campo.

ORIGEM Asner et al., 2012 — CAO
▶ CHM_mean=25m em Amazônia → AGB≈250-350 Mg/ha
217
Temperatura de Superfície por Satélite (LST)
AVANÇADO

LST = BT / (1 + (λ·BT/ρ)·ln ε);  ρ=hc/kB

Temperatura superficial pela radiância térmica; BT=temperatura de brilho, ε=emissividade, λ=comprimento de onda.

ORIGEM Qin et al., 2001 — Landsat TIR
▶ Landsat 8 banda 10 (10,9 μm): LST com erro≈1-2°C
218
Índice de Umidade do Solo (LSWI)
FUNDAMENTAL

LSWI = (NIR − SWIR₁) / (NIR + SWIR₁)

Land Surface Water Index; LSWI≈0 solo seco; LSWI≈0,5 solo muito úmido; usado em monitoramento de inundações.

ORIGEM Xiao et al., 2004
▶ LSWI>0,1 indica condições de inundação em áreas de planície
219
Densidade de Pontos LiDAR (GSD Efetivo)
FUNDAMENTAL

Dp = n_pulsos / A_varrimento;  GSD ≈ 1/√Dp  [m]

Densidade de pontos por m²; LiDAR aerotransportado: 5-50 pontos/m²; GSD efetivo determina resolução de DTM.

ORIGEM LiDAR — ASPRS Standards
▶ Dp=10 pts/m² → GSD efetivo≈0,32 m; vegetação filtrável
220
Precisão de GPS/GNSS (PDOP)
FUNDAMENTAL

σ_3D = PDOP · UERE;  UERE ≈ 3-5 m (GPS civil sem SBAS)

Geometria de satélites GNSS; PDOP baixo = satélites bem distribuídos; PDOP×UERE = erro de posição 3D.

ORIGEM GPS — Misra & Enge, 2006
▶ PDOP=2, UERE=3m → σ_3D=6 m; RTK: UERE<0,02m
Teoria da Informacao e Codificacao
Teoria da Informacao
221
Entropia de Shannon
FUNDAMENTAL

H(X) = −Σᵢ p(xᵢ)·log₂ p(xᵢ)  [bits]

Entropia de informação; máxima para distribuição uniforme; H=0 para variável certa; base de toda teoria da informação.

ORIGEM C.E. Shannon, 1948
▶ Bit justo: H=1 bit; dado justo: H=log₂6=2,58 bits
222
Capacidade de Canal de Shannon
FUNDAMENTAL

C = B·log₂(1 + SNR)  [bps]

Capacidade máxima de canal de Gaussian com largura de banda B e SNR; limite teórico absoluto para comunicações confiáveis.

ORIGEM C.E. Shannon, 1948
▶ B=10 kHz, SNR=100 (20 dB) → C=66,4 kbps
223
Informação Mútua
INTERMEDIÁRIO

I(X;Y) = H(X) − H(X|Y) = Σ p(x,y)·log(p(x,y)/(p(x)·p(y)))

Informação compartilhada; I(X;Y)=0 variáveis independentes; I(X;Y)=H(X) = transmissão perfeita; base de compressão.

ORIGEM C.E. Shannon, 1948
▶ I(X;Y) maximizada = capacidade de canal de Shannon
224
Codificação de Huffman (Código Ótimo)
INTERMEDIÁRIO

L_Huffman = Σ p(xᵢ)·lᵢ ≥ H(X)  (lᵢ=comprimento do código)

Comprimento médio ótimo de código; Huffman atinge o limite de Shannon; base de compressão sem perdas.

ORIGEM D.A. Huffman, 1952
▶ Texto inglês: H≈4,5 bits; Huffman L≈4,6 bits por símbolo
225
Código de Hamming (Correção de Erro)
INTERMEDIÁRIO

(n,k) = (2^m−1, 2^m−1−m);  d_min=3 → corrige 1 erro

Código de Hamming (7,4): 4 bits info, 3 de paridade, distância mínima=3; corrige 1 bit errado.

ORIGEM R.W. Hamming, 1950
▶ (7,4) Hamming: taxa=4/7=0,571; detecta 2 erros, corrige 1
226
Capacidade de Canal com Fading (Ergódico)
AVANÇADO

C_ergodic = E[log₂(1 + SNR·|h|²)]  [bps/Hz]

Capacidade em canal com desvanecimento; |h|²=ganho aleatório do canal; média sobre realizações do canal.

ORIGEM Goldsmith & Varaiya, 1997
▶ Canal Rayleigh: C_ergodic < capacidade AWGN para o mesmo SNR médio
227
Taxa de Compressão (Huffman vs Aritmética)
FUNDAMENTAL

η = H(X) / L_médio × 100%  [%]

Eficiência de codificação; aritmética: L→H(X) exatamente; Huffman pode ter L até H(X)+1 bit.

ORIGEM Teoria da codificação
▶ Texto com H=4,5 bits, L_Huffman=4,65 bits → η=96,8%
228
Divergência de Kullback-Leibler
AVANÇADO

DKL(P||Q) = Σ P(x)·log(P(x)/Q(x))

Divergência de KL; DKL≥0 sempre; DKL=0 se P=Q; mede diferença entre distribuições; base de ML e teoria de informação.

ORIGEM Kullback & Leibler, 1951
▶ DKL entre P e Q normal: DKL=0,5·[(μP−μQ)²/σQ²+σP²/σQ²−1−log(σP²/σQ²)]
229
Código LDPC (Low-Density Parity Check)
AVANÇADO

H·c = 0  (mod 2);  trellis_decoding,  Σ verificações_paridade

Código LDPC: matriz de paridade esparsa; decodificação por passagem de mensagens (belief propagation); próximo do limite de Shannon.

ORIGEM R. Gallager, 1963 — redescoberto 1995
▶ LDPC usado em Wi-Fi (802.11n), DVB-S2, 5G; taxa 0,8 a 0,4 bits/Hz
230
Código de Reed-Solomon (RS)
INTERMEDIÁRIO

RS(n,k): n=q−1, d_min=n−k+1;  corrige t=(d_min−1)/2 erros

Código RS; k=símbolos de dados, n−k=paridade; Reed-Solomon usado em CD, DVD, RAID-6, QR code.

ORIGEM Reed & Solomon, 1960
▶ RS(255,223): corrige 16 bytes errados em bloco de 255 bytes
231
Compressão JPEG (DCT)
AVANÇADO

F(u,v) = (2/N)·Cu·Cv·Σ f(x,y)·cos(π(2x+1)u/2N)·cos(π(2y+1)v/2N)

Transformada de cosseno discreta 2D para compressão JPEG; blocos 8×8; quantização de coeficientes; ratio 10-100:1.

ORIGEM JPEG — Wallace, 1991
▶ Fator de qualidade 75: razão de compressão≈15:1 sem artefatos visíveis
232
Modulação OFDM (Eficiência Espectral)
AVANÇADO

η = k·log₂M·(1−overhead) / (1+CP_ratio)  [bps/Hz]

Eficiência de OFDM; k=bits/subportadora, M=ordem QAM, CP=prefixo cíclico; LTE: 5 bps/Hz; 5G NR: até 9 bps/Hz.

ORIGEM Chang, 1966 — OFDM; padronizado em IEEE 802.11a
▶ Wi-Fi 5 (VHT80, 256-QAM, 3/4): η≈8·0,75/(1+0,08)≈5,6 bps/Hz
233
Probabilidade de Erro em BPSK
INTERMEDIÁRIO

Pb = Q(√(2Eb/N₀)) = 0,5·erfc(√(Eb/N₀))

BER de BPSK em canal AWGN; Q=função Q; para BER=10⁻⁵: Eb/N₀≈9,6 dB; base de comparação de modulações.

ORIGEM Comunicações digitais — Proakis, 2001
▶ Eb/N₀=10 dB → Pb=Q(√20)≈3,9×10⁻⁵
234
Capacidade MIMO (Bell Labs Theorem)
AVANÇADO

C_MIMO = Σᵢ log₂(1 + SNR·λᵢ²/Nt)  [bps/Hz]

Capacidade de sistema MIMO; λᵢ=valores singulares do canal; Nr×Nt antenas multiplica capacidade por min(Nr,Nt).

ORIGEM Foschini & Gans, 1998; Telatar, 1999
▶ 4×4 MIMO, SNR=20 dB → C≈4×5=20 bps/Hz (vs 5 bps/Hz em SISO)
235
Entropia Diferencial de Distribuição Gaussiana
INTERMEDIÁRIO

h(X) = 0,5·log₂(2πeσ²)  [bits]

Entropia diferencial de variável contínua gaussiana; máxima para variância fixa; base de taxas de informação contínuas.

ORIGEM C.E. Shannon, 1948
▶ σ=1: h(X)=0,5·log₂(2πe)≈2,05 bits
236
Redundância e Rate de Código
FUNDAMENTAL

R = k/n;  redundância = 1 − R = (n−k)/n

Taxa de código; R=1 = sem redundância; R=0 = só paridade; troca entre proteção e throughput.

ORIGEM Teoria de códigos
▶ Turbo code 3G: R=1/3; código convolucionais 4G: R=1/2 com puncturing
237
Janela de Congestão TCP (Cubic/AIMD)
INTERMEDIÁRIO

cwnd_AIMD: cwnd+=1/cwnd (AI);  cwnd/=2 quando perda (MD)

Controle de congestionamento TCP; CUBIC: cwnd cresce como cúbico; base de throughput de Internet.

ORIGEM TCP Reno — Jacobson, 1988; TCP CUBIC, 2008
▶ Throughput TCP ≈ MSS · 0,75 / (RTT · √(loss_rate))
238
Teorema de Nyquist-Shannon (Amostragem)
FUNDAMENTAL

fs ≥ 2·fmax  (condição de Nyquist)

Taxa de amostragem mínima para reconstrução sem aliasing; amostragem abaixo de 2fmax cria aliasing.

ORIGEM H. Nyquist, 1928; C.E. Shannon, 1949
▶ Áudio 20 kHz: fs≥40 kHz; CD usa 44,1 kHz
239
Distância de Hamming entre Palavras
FUNDAMENTAL

dH(x,y) = |{i: xᵢ ≠ yᵢ}|  (n posições)

Número de posições diferentes; distância mínima d_min do código determina capacidade de detecção/correção.

ORIGEM R.W. Hamming, 1950
▶ dH(101,111)=1; dH(000,111)=3; d_min=3: corrige 1 erro
240
Protocolo de Retransmissão ARQ (Stop-and-Wait)
INTERMEDIÁRIO

η_SAW = 1/(1 + 2a);  a = t_prop/t_transmissão = TP/L·R

Eficiência de Stop-and-Wait ARQ; a=razão propagação/transmissão; para a>>1 usar go-back-N ou selective repeat.

ORIGEM ARQ — Berlekamp, 1980
▶ a=10: η_SAW=1/21≈4,8%; Window=N≥2a+1 para η→1
""";
    }
}
