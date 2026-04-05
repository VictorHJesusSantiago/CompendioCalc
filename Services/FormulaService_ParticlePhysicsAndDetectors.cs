namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol15Parte2 = """
Fisica de Particulas e Detectores
Ressonancias e Scattering
081
Fórmula de Breit-Wigner (Ressonância)
AVANÇADO

σ(E) = σ₀ · (Γ²/4) / ((E−E₀)² + Γ²/4)

Seção de choque próxima a ressonância; E₀=energia de ressonância, Γ=largura total; Γ=ℏ/τ onde τ=tempo de vida.

ORIGEM G. Breit & E.P. Wigner, 1936
▶ Ressonância Δ(1232): E₀=1232 MeV, Γ≈120 MeV
082
Tempo de Vida de Partícula (Fator de Lorentz)
FUNDAMENTAL

t_lab = γ·τ₀ = τ₀ / √(1−β²)

Dilatação temporal relativística; τ₀=tempo próprio, γ=fator de Lorentz; múon de raio cósmico: τ₀=2,2 μs → sobrevive até solo.

ORIGEM Relatividade especial — Einstein, 1905
▶ Múon com β=0,999: γ=22,4 → t_lab=49 μs
083
Equação de Bethe-Bloch (Perda de Energia)
AVANÇADO

−dE/dx = Kz²Z/A · 1/β² · [0,5ln(2mec²β²γ²Tmax/I²) − β²]

Perda de energia ionizante de partícula carregada em matéria; mínimo ionizante a βγ≈3; fundamental em detectores.

ORIGEM H. Bethe, 1930; F. Bloch, 1933
▶ Próton de 1 GeV em chumbo: −dE/dx≈1,5 MeV·cm²/g
084
Luminosidade de Colisor de Partículas
AVANÇADO

L = n₁·n₂·f · n_b / (4πσxσy)  [cm⁻²s⁻¹]

Luminosidade do colisionador; n_b=número de bunches, n₁,n₂=partículas/bunch, σ=tamanho do feixe; LHC: L≈10³⁴ cm⁻²s⁻¹.

ORIGEM LHC Design Report — CERN
▶ L=10³⁴ cm⁻²s⁻¹, σ(processo)=1 pb → 10⁴ eventos/s por fb⁻¹
085
Resolução de Detector de Silício
INTERMEDIÁRIO

σ_x = pitch / √12  (não-interpolado)

Resolução espacial de detector de faixa de silício; pitch=espaçamento de faixas; com interpolação por cluster: σ<pitch/5.

ORIGEM Detectores de silício — ATLAS, CMS
▶ Pitch=50 μm → σ_x=14,4 μm; com interpolação≈7 μm
086
Resolução de Energia de Detector de Calorímetro
AVANÇADO

σ_E/E = a/√E ⊕ b/E ⊕ c

Resolução de energia; a=termo estocástico (√E), b=ruído, c=constante; CMS ECAL: a≈2,7%, c≈0,55%.

ORIGEM Detecção de energia em ATLAS/CMS
▶ Fóton de 100 GeV no CMS: σ_E/E ≈ 0,55% (dominado por c)
087
Fórmula de Rutherford (Scattering)
INTERMEDIÁRIO

dσ/dΩ = (Z₁Z₂e²/4E_cm)² · 1/sin⁴(θ/2)

Seção de choque diferencial de Rutherford; diverge a pequenos ângulos; histórico: descoberta do núcleo atômico.

ORIGEM E. Rutherford, 1911
▶ Experimento de Geiger-Marsden: α espalhados a ângulos grandes confirmou núcleo
088
Número de Radiação de Cherenkov
AVANÇADO

cos θ_c = c/(n·v) = 1/(βn);  N_fótons = 2παz²L·sin²θ_c·Δ(1/λ)

Ângulo e número de fótons Cherenkov; emitido quando β>1/n; base de detectores RICH (ALICE, LHCb) e neutrinos.

ORIGEM P. Cherenkov, 1934 (Nobel 1958)
▶ Próton ultrarrelativístico em água (n=1,33): θ_c=41°
089
Matriz CKM (Mixing de Quarks)
AVANÇADO

VCKM = [[Vud, Vus, Vub],[Vcd, Vcs, Vcb],[Vtd, Vts, Vtb]]

Matriz de mixing de Cabibbo-Kobayashi-Maskawa; |Vud|≈0,974 domina; fase δ explica violação CP no Modelo Padrão.

ORIGEM N. Cabibbo, 1963; M. Kobayashi & T. Maskawa, 1973 (Nobel 2008)
▶ Decaimento β: n→p+e⁻+ν̄ via troca de quark d→u (Vud)
090
Inversão de Paridade (Oscilação de Neutrinos)
AVANÇADO

P(νμ→νe) ≈ sin²(2θ₁₂)·sin²(Δm²₁₂L/(4E))

Probabilidade de oscilação de neutrino; θ=ângulo de mixing, Δm²=diferença de massa ao quadrado, L=distância, E=energia.

ORIGEM Pontecorvo-Maki-Nakagawa-Sakata (PMNS), 1962
▶ Δm²₂₁=7,5×10⁻⁵ eV², θ₁₂=34°; L/E=600 km/GeV → P≈0,3
091
Emissão de Glúon (Running Coupling αs)
AVANÇADO

αs(μ²) = αs(μ₀²) / (1 + (b₀/2π)·αs(μ₀²)·ln(μ²/μ₀²))

Constante de acoplamento forte dependente de escala; αs diminui com Q² (liberdade assintótica); b₀=(11Nc−2Nf)/3.

ORIGEM D. Gross, F. Wilczek & H.D. Politzer, 1973 (Nobel 2004)
▶ αs(MZ)≈0,118; αs(1 GeV)≈0,4 (acoplamento forte em baixa energia)
092
Assimetria de Violação CP (LHCb)
AVANÇADO

A_CP = (N_B̄→f − N_B→f̄) / (N_B̄→f + N_B→f̄)

Assimetria de violação CP em decaimentos de mésons B; A_CP≠0 indica diferença entre matéria e antimatéria.

ORIGEM Decaimentos de B — LHCb/BaBar/Belle
▶ B⁰→J/ψK⁰: violação CP confirmada a>5σ; A_CP≈0,67
093
Equação de Dirac (Partículas Relativísticas)
AVANÇADO

(iγᵘ∂ᵘ − mc/ℏ)ψ = 0

Equação relativística para partículas de spin-1/2; prediz antimatéria; espinores de 4 componentes; base da QED.

ORIGEM P.A.M. Dirac, 1928 (Nobel 1933)
▶ Solução de Dirac prediz elétron e pósitron (antipartícula)
094
Largura de Decaimento Parcial (Fermi)
AVANÇADO

Γ = (G_F²·m⁵)/(192π³)·|M|²

Taxa de decaimento fraco; G_F=constante de Fermi; m=massa da partícula mãe; base do decaimento de múons e quarks.

ORIGEM E. Fermi, 1934
▶ Múon: τ=2,2 μs; Γ=G_F²m_μ⁵/(192π³)
095
Significância Estatística em Física de Partículas
INTERMEDIÁRIO

Z = S/√(S+B)  (Punzi: Z = S/√B  para B>>S)

Significância; Z≥5σ (p<3×10⁻⁷) para descoberta em HEP; S=sinal esperado, B=fundo esperado.

ORIGEM Convenção de HEP — ATLAS, CMS, LHCb
▶ Higgs discovery: Z=5,9σ (ATLAS) e 5,0σ (CMS) em 2012
096
Radiação de Sincrotron (Perda de Energia)
AVANÇADO

P_sync = C_γ · c · E⁴ / (2π · ρ²);  C_γ=8,85×10⁻⁵ m/GeV³

Perda de energia por radiação de sincrotron em curvas; E=energia, ρ=raio de curvatura; domina em elétrons (não prótons).

ORIGEM J.S. Schwinger, 1949
▶ LEP (E=45 GeV, ρ=3,1 km): perda=125 MeV/volta
097
Distância de Radiação (X₀)
INTERMEDIÁRIO

X₀ = 716 A / (Z(Z+1)·ln(287/√Z))  [g/cm²]

Comprimento de radiação de material; 63% de energia perdida em X₀ por chuva eletromagnética; fundamental em calorimetria.

ORIGEM Bethe & Heitler, 1934
▶ Chumbo: X₀=6,37 g/cm²=0,56 cm; água: X₀=36,1 g/cm²=36 cm
098
Produto de Massa de Higgs (Decaimento H→γγ)
INTERMEDIÁRIO

m_H = √(2·E₁·E₂·(1−cos θ))

Massa invariante de dois fótons do decaimento do Bóson de Higgs; pico a 125 GeV; método de descoberta no LHC.

ORIGEM ATLAS & CMS — H→γγ discovery channel, 2012
▶ Dois fótons com E₁=E₂=62,5 GeV, θ=90° → m_H=88 GeV
099
Mecanismo de Higgs (Massa de Bóson W)
AVANÇADO

m_W = g·v/2;  m_Z = √(g²+g'²)·v/2;  v=246 GeV

Massa de bósons de gauge pela quebra espontânea de simetria eletrofraca; v=VEV do campo de Higgs; predição confirmada.

ORIGEM Brout, Englert & Higgs, 1964 (Nobel 2013)
▶ g≈0,65: m_W=g·246/2≈80 GeV; m_Z≈91 GeV (confirmado)
100
Equação de Propagação em Meio (Muon Tomography)
AVANÇADO

ΔX₀ = ∫(ρ/X₀_material) ds;  <θ²>=2θ₀² · L/X₀

Espalhamento múltiplo de Coulomb em tomografia muônica; variância angular proporcional a L/X₀; detecta materiais densos.

ORIGEM Highland, 1975 — Multiple Coulomb Scattering
▶ Tomografia muônica detecta urânio em contêineres por seu alto Z
Astrobiologia e Origens da Vida
Vida no Universo
101
Equação de Drake (Vida Inteligente)
FUNDAMENTAL

N = R* · fp · ne · fl · fi · fc · L

N=civilizações comunicativas; R*=taxa de formação estelar, fp=estrelas com planetas, ne=planetas habitáveis, fl=vida, fi=inteligência, fc=tecnologia, L=duração.

ORIGEM F. Drake, 1961 — Green Bank Conference
▶ Estimativas variam de N≈1 (Terra única) a N>10⁶ (Galaxy Zoo)
102
Zona Habitável Estelar (Kopparapu)
INTERMEDIÁRIO

d_HZ = √(L/S_eff)  [AU];  S_eff = S_eff,☉ + aT* + bT*² + cT*³ + dT*⁴

Limites interno e externo da zona habitável; S_eff corrige tipo espectral; L/L☉ e T*=temperatura estelar.

ORIGEM Kasting et al., 1993; Kopparapu et al., 2013
▶ Sol: HZ interior=0,99 AU; exterior=1,67 AU
103
Taxa de Mutação e Evolução Molecular (Relógio)
INTERMEDIÁRIO

d = 2μt;  t = d/(2μ)

Distância molecular d; μ=taxa de mutação; relógio molecular calibra divergência de espécies; base de filogenia.

ORIGEM Zuckerkandl & Pauling, 1965
▶ μ=10⁻⁹ substituições/sítio/ano; d=0,02 → t=10 Ma
104
Energia Livre de Gibbs de Reação Prebiótica
FUNDAMENTAL

ΔG = ΔH − TΔS;  ΔG < 0 → espontânea

Espontaneidade de síntese prebiótica; reações que formaram aminoácidos, bases etc. requerem ΔG<0 ou acoplamento energético.

ORIGEM Termodinâmica química — aplicada à origens da vida
▶ Síntese de formamida a partir de HCN+H₂O: ΔG<0 a temperaturas prebióticas
105
Mundo de RNA (Ribozima — Kcat)
AVANÇADO

kcat/Km = (kcat/Km)_RNA ~ 10⁶ M⁻¹s⁻¹

Eficiência catalítica de ribozimas; inferiores a enzimas de proteína (10⁸-10⁹) mas viáveis para origens da vida.

ORIGEM T. Cech & S. Altman, 1982 (Nobel 1989)
▶ Ribozima hammerhead: kcat~1 min⁻¹; vs ribonuclease A: kcat~10⁶ min⁻¹
106
Temperatura de Fusão de DNA (Tm)
INTERMEDIÁRIO

Tm = 81,5 + 16,6·log([Na⁺]) + 0,41·(%GC) − 675/n

Temperatura de desnaturação de DNA; depende de conteúdo GC e comprimento n; base de design de primers e origens da vida.

ORIGEM Marmur & Doty, 1962
▶ dsDNA 100 bp, 50% GC, [Na⁺]=50 mM → Tm≈73°C
107
Fluxo de Fótons de Estrela Tipo K (Zona Habitável)
INTERMEDIÁRIO

Φ_UV = L_UV / (4πd²·hν_UV)  [fótons/cm²/s]

Fluxo de UV na superfície de planeta habitável; estrelas tipo K têm menos UV que Sol → ambiente menos hostil para vida.

ORIGEM Astrobiologia — Segura et al., 2005
▶ Estrela K a 0,4 AU: UV 100× menor que Terra → favorável à vida
108
Concentração de Oxigênio Primordial (Great Oxygenation)
INTERMEDIÁRIO

[O₂] evolui por: dO₂/dt = Produção_fotossíntese − Consumo_geológico

Acumulação de O₂ atmosférico iniciou ~2,4 Ga (GOE); equilíbrio entre produção cianobacteriana e sink geológico.

ORIGEM Holland, 2006 — Great Oxygenation Event
▶ [O₂] de <0,001% pré-GOE para 21% atual em ~2 Ga
109
Critério de Habitabilidade Gelada (Ocean Worlds)
AVANÇADO

q_tidal = (21/2)·(k₂/Q)·(GM_p)^{3/2} · (1/R_s^{2,5}) · e² · m_s

Calor de maré; k₂/Q=fator de dissipação, e=excentricidade; aquece oceanos subsuperficiais em luas como Europa e Encélado.

ORIGEM Yoder, 1979 — Tidal Heating
▶ Europa: q_tidal≈10⁻² W/m² → mantem oceano subsuperficial
110
Complexidade de Shannon de Código Genético
AVANÇADO

H_código = −Σ P(códon)·log₂P(códon)  [bits/códon]

Entropia informacional do código genético; degenerescência reduz H; código real≈3,7 bits/códon vs máximo 6 bits.

ORIGEM Shannon, 1948 — aplicado à biologia molecular
▶ 64 códons, 3 paradas, 61 sentido → H≈5,9 bits (sem degenerescência)
111
Índice de Biossinatura (BSI)
INTERMEDIÁRIO

BSI = [O₂] × [CH₄] / [CO₂]²

Desequilíbrio químico atmosférico como biossinatura; O₂ e CH₄ coexistindo requer fonte biótica contínua (reação exergônica entre si).

ORIGEM Lovelock, 1965 — Biosignatures
▶ Terra: O₂=21%, CH₄=1,8 ppm → BSI enorme; Marte BSI≈0
112
Probabilidade de Panspermia (Litopanspermia)
INTERMEDIÁRIO

P_transfer = f_ejeção × f_sobrevida × f_captura × f_colonização

Probabilidade de transferência de vida via meteoritos; estimativas variam amplamente; frações são muito incertas.

ORIGEM Mileikowsky et al., 2000
▶ Transferência Terra-Marte calculada em P≈10⁻⁸ por evento de impacto
113
Espessura de Gelo de Europa (Modelo de Calor)
AVANÇADO

d_gelo = √(2·k_gelo·ΔT / q_tidal)

Espessura da camada de gelo em Europa; k=condutividade, ΔT=diferença de temperatura entre superfície e oceano, q=calor de maré.

ORIGEM Pappalardo et al., 1999
▶ q=0,05 W/m², k=2 W/mK, ΔT=250 K → d_gelo≈4,5 km
114
Taxa de Entrega de Matéria Orgânica por Meteoritos
INTERMEDIÁRIO

Ṁ_orgânico ≈ Ṁ_total · f_C · f_orgânico · (1−f_destruição)  [kg/ano]

Fluxo de compostos orgânicos extraterrestres; Terra recebe ~10⁸ kg/ano de material carbonáceo, mas destruição por entrada é alta.

ORIGEM Chyba & Sagan, 1992
▶ Terra primitiva: entrega de ~10⁸ kg/a de aminoácidos sobreviventes
115
Índice de Habitabilidade de Planeta (PHI)
INTERMEDIÁRIO

PHI = (ρ_vol · P_chem · P_hydro · P_T)^{1/4}

Índice de habitabilidade de planeta (0-1); ρ_vol=fração de habitat, P=probabilidades de condições químicas, hídricas, térmicas.

ORIGEM Schulze-Makuch et al., 2011
▶ Terra: PHI=1,0; Marte: PHI≈0,1; Europa: PHI≈0,25
116
Razão D/H como Biossinatura de Água
INTERMEDIÁRIO

δD = ((D/H)_amostra / (D/H)_SMOW − 1) × 1000 ‰

Fracionamento de deutério; organismos fracionam D/H diferentemente da abiogênese; δD de Marte vs Terra indica história.

ORIGEM SMOW — Standard Mean Ocean Water
▶ Água de Marte: δD≈+1000‰; Terra: δD≈0‰
117
Cinética de Autorreplicação (Hiperciclo de Eigen)
AVANÇADO

dxᵢ/dt = xᵢ(kᵢxᵢ₋₁ − Φ);  Φ = Σ kⱼxⱼxⱼ₋₁

Hiperciclo catalítico de Eigen; moléculas se catalisam ciclicamente; propõe mecanismo de evolvibilidade no mundo RNA.

ORIGEM M. Eigen, 1971 (Nobel 1967)
▶ Hiperciclo de RNA: mRNA catalisa proteína que catalisa replicação do mRNA
118
Limite de Erro de Replicação de Eigen
AVANÇADO

q_min = e^{−μL} > 1/σ_max;  L_max = ln(σ)/ μ

Comprimento máximo de genoma L com taxa de erro μ por replicação; pré-biótico: μ~1, L_max~100 nucleotídeos.

ORIGEM M. Eigen, 1971 — error threshold
▶ Vírus RNA: L≈10⁴, μ≈10⁻⁴ → q≈0,37 (perto do limiar)
119
Fluxo de Energia em Chemolitos (Hidrotermais)
AVANÇADO

ΔG_rx = ΔG°' + RT·ln Q;  J_energia = Σ |ΔG_rx| · J_electron

Energia livre disponível em fontes hidrotermais; oxidação de H₂, CH₄, Fe²⁺ por SO₄²⁻; sustenta quimiolitotróficos.

ORIGEM McCollom & Shock, 1997
▶ Lost City: H₂+SO₄²⁻ → ΔG≈−38 kJ/mol; sustenta ecossistema
120
Número de Estrelas com Planetas Habitáveis (Estimativa)
FUNDAMENTAL

N_HP = N_estrelas_Galaxia × f_MS × f_HZ × f_rochoso

N estimado de planetas habitáveis; N_estrelas~10¹¹, f_MS~0,7, f_HZ~0,2, f_rochoso~0,3 → N_HP~4×10⁹ na Via Láctea.

ORIGEM Petigura et al., 2013; Howard et al., 2010
▶ ~4 bilhões de planetas rochosos em zona habitável na Via Láctea
Engenharia de Dutos e Transporte de Fluidos
Hidraulica de Dutos
121
Equação de Darcy-Weisbach
FUNDAMENTAL

hf = f · (L/D) · v²/(2g)

Perda de carga por atrito em dutos; f=fator de atrito de Darcy, L=comprimento, D=diâmetro, v=velocidade média.

ORIGEM H. Darcy, 1857; J. Weisbach, 1845
▶ D=0,3m, L=100m, v=2m/s, f=0,02 → hf=1,36 m
122
Fator de Atrito de Colebrook-White
INTERMEDIÁRIO

1/√f = −2·log(ε/(3,7D) + 2,51/(Re·√f))

Equação implícita para f turbulento; ε=rugosidade absoluta, Re=Reynolds; iteração ou aproximação de Swamee-Jain.

ORIGEM C.F. Colebrook & C.M. White, 1939
▶ Re=10⁵, ε/D=0,001 → f≈0,022 por iteração
123
Velocidade de Propagação de Golpe de Aríete
INTERMEDIÁRIO

a = √(K_f/ρ) / √(1 + (K_f·D)/(E·e))

Velocidade de onda de pressão em duto; K_f=bulk modulus do fluido, E=módulo do duto, e=espessura da parede.

ORIGEM N. Joukowski, 1898
▶ Água em duto de aço: a≈1000-1200 m/s
124
Sobrepressão de Joukowski (Golpe de Aríete)
FUNDAMENTAL

ΔP = ρ·a·Δv

Variação de pressão no fechamento rápido de válvula; Δv=variação de velocidade do fluido; ΔP pode ser enorme.

ORIGEM N. Joukowski, 1898
▶ Δv=2 m/s, ρ=1000 kg/m³, a=1200 m/s → ΔP=2,4 MPa (24 bar)
125
Equação de Bernoulli Aplicada (Bombas)
FUNDAMENTAL

z₁ + P₁/(ρg) + v₁²/(2g) + Hb = z₂ + P₂/(ρg) + v₂²/(2g) + hf

Bernoulli com bomba e perdas; Hb=altura manométrica da bomba; dimensiona todo sistema de bombeamento.

ORIGEM D. Bernoulli, 1738 — aplicação a bombas
▶ Hb_necessária = diferença de cotas + perda de carga + pressão dinâmica
126
Potência de Bomba Hidráulica
FUNDAMENTAL

P_hidráulica = ρ·g·Q·Hb;  P_eixo = P_hidráulica / η_bomba

Potência necessária; η_bomba=eficiência (0,7-0,9); determina motor elétrico; base de cálculo de consumo energético.

ORIGEM Hidráulica de bombas
▶ Q=50 L/s, Hb=20 m, η=0,8 → P_eixo=12,3 kW
127
Equação de Transporte de Gás Natural (Panhandle B)
AVANÇADO

Q = 737·E·(T_sc/P_sc)^{1,02}·[((P₁²−P₂²)/G^{0,961}·L·T_avg·Z)]^{0,51}·D^{2,53}

Fluxo de gás em gasoduto; G=gravidade específica, L=comprimento, T=temperatura, Z=fator compressibilidade.

ORIGEM Panhandle Eastern Equations — GPSA, 2004
▶ Dimensiona gasodutos de transmissão (Panhandle B para Re>6000)
128
Deformação de Duto por Pressão Interna (Barlow)
FUNDAMENTAL

e = P·D / (2·σ_adm·FS);  σ_h = P·D/(2e)  (hoop stress)

Tensão circunferencial de duto; e=espessura de parede; FS=fator de segurança; base do dimensionamento de tubulações.

ORIGEM P. Barlow, 1836
▶ P=5 MPa, D=0,5m, σ_adm=200 MPa, FS=1,5 → e=9,4 mm
129
Expansão Térmica de Duto
FUNDAMENTAL

ΔL = α · L · ΔT;  F_térmica = α·ΔT·E·A

Expansão de duto por temperatura; α≈12×10⁻⁶/°C para aço; loops e juntas de expansão absorvem ΔL.

ORIGEM Engenharia de tubulações — ASME B31.3
▶ Duto de 100 m, ΔT=50°C → ΔL=6 cm; força F=α·ΔT·E·A
130
Velocidade Mínima de Escoamento (Autocompensação)
INTERMEDIÁRIO

v_min(sólidos) ≈ 1,5·√(gD·(ρs/ρf−1)·d)

Velocidade mínima para evitar deposição de sólidos em duto; ρs=densidade do sólido, d=tamanho de partícula.

ORIGEM Durand & Condolios, 1952
▶ Areia (ρ=2600 kg/m³) em D=0,2m → v_min≈2,3 m/s
131
Escoamento Bifásico — Correlação de Lockhart-Martinelli
AVANÇADO

X_LM = (dP/dx)_L / (dP/dx)_G;  Φ²_L = 1 + C/X + 1/X²

Correlação Lockhart-Martinelli para queda de pressão em escoamento líquido-gás; C depende do regime de escoamento.

ORIGEM Lockhart & Martinelli, 1949
▶ Escoamento de petróleo-gás em duto submarino: usa correlação de Baker ou Mukherjee
132
Tensão de Corrosão-Fadiga de Duto
AVANÇADO

da/dN = C·(ΔK)^m · E_corrosão  (Paris-Erdogan modificado)

Taxa de crescimento de trinca em ambiente corrosivo; C,m=parâmetros do material+ambiente; acelera fadiga convencional.

ORIGEM ASME FFS-1 / API 579-1
▶ Taxa de crescimento de trinca em duto offshore dobra em ambiente marinho
133
Número de Cavitação (σ)
INTERMEDIÁRIO

σ = (P_local − Pv) / (0,5·ρ·v²)

Adimensional de cavitação; Pv=pressão de vapor; σ baixo → risco de cavitação em bombas e turbinas hidráulicas.

ORIGEM Hidráulica
▶ Bomba centrífuga: NPSH disponível > NPSH requerido para evitar σ crítico
134
Equação de Hazen-Williams (Redes de Água)
FUNDAMENTAL

v = 0,849·C·R^{0,63}·S^{0,54}

Velocidade em condutos cheios; C=coeficiente H-W (130=PVC novo, 100=ferro galvanizado), R=raio hidráulico, S=gradiente.

ORIGEM A. Hazen & G.S. Williams, 1905
▶ D=0,2m, C=130, S=0,005 → v≈1,9 m/s; Q=60 L/s
135
Taxa de Perda por Corrosão (Faraday)
INTERMEDIÁRIO

Ṁ = (I·M) / (n·F·ρ·A)  [mm/ano]

Taxa de corrosão eletroquímica; I=densidade de corrente, M=massa molar, n=elétrons, F=Faraday; base de catódica.

ORIGEM Lei de Faraday — aplicada a corrosão
▶ Aço em solo argiloso: Ṁ≈0,1-1 mm/ano sem proteção catódica
136
Dimensionamento de Compressor (Isentrópico)
INTERMEDIÁRIO

W_isentropico = (n/(n−1))·P₁V₁·[(P₂/P₁)^{(n−1)/n} − 1]

Trabalho de compressão isentrópica; n=expoente politrópico; η_isentrópica=W_is/W_real; base de seleção de compressores.

ORIGEM Termodinâmica de compressores — GPSA Engineering Databook
▶ Ar (n=1,4), P₂/P₁=5, P₁V₁=100 kJ → W_is≈196 kJ (44% de W_real)
137
Velocidade Sônica em Gasoduto
INTERMEDIÁRIO

a = √(γRT/M);  Ma = v/a

Velocidade sônica de gás; γ=razão de calores específicos, M=massa molar; Ma<1 em gasodutos normais (escoamento subsônico).

ORIGEM Acústica de gases — aplicado a gasodutos
▶ Gás natural (M=16,5 g/mol, γ=1,32, T=300K) → a≈414 m/s
138
Análise de Vibração Induzida por Vortex (VIV)
AVANÇADO

f_s = St · v / D;  lock-in quando f_s ≈ fn

Frequência de desprendimento de vórtex (Strouhal); St≈0,2; lock-in com frequência natural causa ressonância em dutos submarinos.

ORIGEM Strouhal, 1878 — aplicado a VIV de riser
▶ Riser D=0,3m, v=0,5m/s → f_s=0,33 Hz; lock-in se fn=0,33 Hz
139
Fator de Escorregamento em Escoamento Bifásico
AVANÇADO

S = v_gás / v_líquido  (hold-up: αL = 1/(1+S·Q_G/Q_L))

Fator de escorregamento entre fases; S>1 (gás mais rápido); hold-up líquido αL determina inventário em duto de petróleo.

ORIGEM Hewitt & Hall-Taylor, 1970
▶ Duto inclinado: S≈1,5-3; αL=0,4-0,7 em escoamento slug
140
Inspeção por PIGs — Resolução de Anomalia
INTERMEDIÁRIO

Tamanho_mínimo_detectável = resolução_sensor × velocidade_PIG × tempo_amostragem

Pig de inspeção inteligente (MFL, UT); resolução mínima de defeito; velocidade ótima 0,5-3 m/s para máxima resolução.

ORIGEM API 1163 — In-Line Inspection Systems
▶ MFL a 1 m/s: detecta anomalias ≥10% de espessura (10 mm em parede 100 mm)
Fisiologia Vegetal e Agronomia Quantitativa
Fotossintese
141
Equação de Farquhar-von Caemmerer-Berry (Fotossíntese)
AVANÇADO

A = min(Av, Aj, Ap) − Rd;  Av = Vcmax·(Ci−Γ*)/(Ci+Kc(1+O/Ko))

Modelo bioquímico de fotossíntese C3; Av=limitação por Rubisco, Aj=por elétrons, Ap=por triosefosfato; Ci=CO₂ interno.

ORIGEM Farquhar et al., 1980
▶ Vcmax=100 μmol/m²/s, Ci=250 ppm → A≈20 μmol CO₂/m²/s
142
Condutância Estomática (Ball-Berry)
AVANÇADO

gs = m·A·h/(Cs) + b

Condutância estomática gs; m≈9 (C3), A=fotossíntese, h=umidade relativa, Cs=CO₂ na superfície; b≈0,01 mol/m²/s.

ORIGEM Ball et al., 1987
▶ A=20 μmol/m²/s, h=0,65, Cs=360 ppm → gs≈0,32 mol/m²/s
143
Índice de Área Foliar (IAF)
FUNDAMENTAL

IAF = área_foliar_total / área_solo_projetada  [m²/m²]

Índice de cobertura foliar; IAF ótimo para culturas: 3-5; base de modelos de interceptação de luz e produtividade.

ORIGEM Watson, 1947
▶ Milho no florescimento: IAF≈4-5; restrição hídrica reduz para 2-3
144
Lei de Beer para Interceptação de Luz (Culturas)
FUNDAMENTAL

I = I₀ · e^{−k·IAF}

Luz transmitida através do dossel; k=coeficiente de extinção (0,4-0,7 para culturas); base do modelo de produção.

ORIGEM Monsi & Saeki, 1953
▶ k=0,5, IAF=4 → I=I₀·e⁻²=0,135·I₀ (86,5% interceptada)
145
Índice de Colheita
FUNDAMENTAL

IC = produção_de_grão / biomassa_total_aérea

Partição de biomassa para órgão de interesse; IC trigo moderno≈0,50; ic soja≈0,48; melhoramento genético aumentou IC.

ORIGEM Donald & Hamblin, 1976
▶ Milho: biomassa total=20 t/ha, IC=0,5 → produção de grão=10 t/ha
146
Potencial Hídrico (Ψ)
INTERMEDIÁRIO

Ψ = Ψs + Ψp + Ψm;  Ψs = −iRTc  (Van't Hoff)

Potencial hídrico total; Ψs=osmótico, Ψp=pressão de turgor, Ψm=matricial; água flui de Ψ alto para baixo.

ORIGEM Slatyer & Taylor, 1960
▶ Célula turgida: Ψs=−1 MPa, Ψp=+1 MPa → Ψ=0 (equilíbrio)
147
Demanda Hídrica de Cultura (FAO Kc)
FUNDAMENTAL

ETc = ETo · Kc;  ETo = Penman-Monteith

Evapotranspiração de cultura; Kc=coeficiente de cultura (Kc_milho_pleno=1,2); ETc base de lâmina de irrigação.

ORIGEM FAO Irrigation Paper 56 — Allen et al., 1998
▶ ETo=6 mm/dia, Kc=1,2 → ETc=7,2 mm/dia (lâmina diária)
148
Eficiência de Uso de Água (WUE)
FUNDAMENTAL

WUE = produção_biomassa / evapotranspiração  [kg/m³]

Produtividade hídrica; trigo: WUE≈1-2 kg/m³; milho irrigado: 1,5-2,5 kg/m³; aumenta com CO₂ elevado.

ORIGEM Agronomia de precisão
▶ WUE=1,8 kg/m³: 556 m³ de água por tonelada de grão
149
Temperatura Base e Graus-Dia de Crescimento
FUNDAMENTAL

GDD = Σ [(Tmax+Tmin)/2 − Tb];  se (Tmax+Tmin)/2 < Tb → GDD=0

Tempo fisiológico acumulado; Tb=temperatura base (10°C milho); GDD para florescimento≈800-1000 (milho).

ORIGEM Arnold, 1959
▶ Milho: Tb=10°C; acumula 2000-2500 GDD do plantio à maturidade
150
Nutrição de Nitrogênio — Dilution Curve
AVANÇADO

Nc% = a · Bm^{−b};  a≈3,6, b≈0,37 (trigo/milho)

Concentração crítica de N em função de biomassa; abaixo da curva = deficiência; base de diagnóstico nutricional.

ORIGEM Lemaire & Gastal, 1997
▶ Biomassa de trigo=5 t/ha → Nc_crit=2,9% → N_requerido=145 kg/ha
151
Produtividade Primária Líquida (NPP)
INTERMEDIÁRIO

NPP = GPP − Ra;  GPP ≈ ε · PAR_abs

Produtividade primária; ε=eficiência de uso de luz (~1,5 g/MJ PAR), PAR_abs=PAR absorvida; Ra=respiração autotrófica.

ORIGEM Monteith, 1977
▶ Soja no Brasil: NPP≈8-12 t MS/ha/ano
152
Dose de Fertilizante Nitrogenado (Recomendação)
FUNDAMENTAL

N_aplicar = (N_alvo − N_solo) / Eficiência_aproveitamento

Cálculo de adubação; N_alvo baseado em produtividade esperada; eficiência 60-80% em cobertura; base de manejo agronômico.

ORIGEM EMBRAPA — Sistemas de Produção
▶ Produção alvo=10 t/ha milho, N_req=200 kg/ha, efic=70% → aplicar 286 kg/ha de N
153
Resistência da Planta à Seca (Índice de Sensibilidade)
INTERMEDIÁRIO

SSI = (1−Yd/Yp) / (1−ETd/ETp)

Índice de sensibilidade hídrica; Yd/Yp=razão de produção seca/potencial; SSI<1 tolerante; SSI>1 sensível.

ORIGEM Fischer & Maurer, 1978
▶ SSI=0,7 indica tolerância moderada à seca
154
Crescimento Logístico de Colônia de Raízes
INTERMEDIÁRIO

dL/dt = r·L·(1 − L/K)·f(T, U)

Crescimento de comprimento radicular; r=taxa de crescimento intrínseca, K=capacidade do solo, f=função de temperatura e umidade.

ORIGEM Modelo de crescimento radicular
▶ Soja: comprimento máximo radicular≈1,2-1,5 m; explorando 2-3 t/ha de solo
155
Índice de Vigor de Semente (IVS)
FUNDAMENTAL

IVS = (Primeira_contagem% + Germinação_final%) / 2

Vigor de lote de sementes; IVS>80% indica lote vigoroso; base de controle de qualidade de sementes.

ORIGEM AOSA Rules for Seed Testing
▶ Soja: IVS>85% para semente de alta qualidade
156
Índice NDVI (Vegetação por Satélite)
FUNDAMENTAL

NDVI = (NIR − Red) / (NIR + Red)

Índice normalizado de vegetação; NDVI próximo a 1 = vegetação densa e ativa; NDVI<0,2 = solo exposto.

ORIGEM Rouse et al., 1974
▶ Cultura de milho saudável em antese: NDVI≈0,85-0,90
157
Balanço de Carbono do Solo (RothC)
AVANÇADO

dC/dt = Entradas_C − k·C·(1−IOM_frac)·modificadores

Modelo RothC de MOS; k=taxa de decomposição, IOM=fração inerte; modificadores de temperatura e umidade do solo.

ORIGEM Jenkinson & Rayner, 1977
▶ Pastagem com 30 t C/ha: ganha 0,5 t C/ha/ano sob cobertura vegetal
158
Eficiência de Fixação Biológica de N₂
INTERMEDIÁRIO

FBN = N_total_planta − N_absorvido_do_solo

N fixado simbioticamente por Rhizobium; soja pode fixar 100-300 kg N/ha/ano; avaliado por método de diluição isotópica.

ORIGEM Hardy et al., 1968 — método de acetileno
▶ Soja inoculada com Bradyrhizobium: FBN média=150 kg N/ha/ciclo
159
Emergência de Sementes (Índice de Velocidade)
FUNDAMENTAL

IVE = Σ (Ni/i)

Índice de velocidade de emergência; Ni=plântulas no dia i; IVE alto = germinação rápida e uniforme; indica vigor.

ORIGEM Maguire, 1962
▶ IVE=15 indica germinação rápida vs IVE=5 em lote de baixo vigor
160
Rendimento de Grão por Componentes (Milho)
FUNDAMENTAL

Prod (t/ha) = populacao × espigas/planta × graos/espiga × PMG × 10⁻⁵

Rendimento de milho por componentes; PMG=peso de mil grãos (g); equação fundamental da agronomia quantitativa.

ORIGEM Componentes de rendimento — Agronomy Journal
▶ 70000 pl/ha, 1 espiga, 600 grãos, PMG=350g → 14,7 t/ha
""";
    }
}
