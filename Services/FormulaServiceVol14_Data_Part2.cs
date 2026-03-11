namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol14Parte2 = """
Geologia e Estratigrafia Quantitativa
Geocronologia
081
Datacao Radiometrica (Decaimento)
FUNDAMENTAL
N(t) = N0 · e^(−lambda·t); t = (1/lambda)·ln(N0/N)
Datacao por isotopos radioativos; lambda=constante de decaimento=ln2/t1/2; base da geocronologia.
ORIGEM E. Rutherford & F. Soddy, 1902
▶ U-238 data formacao de zircoes e rochas igneas
082
Equacao de Isocrona (Rb-Sr)
AVANCADO
Sr87_Sr86 = Sr87_Sr86_0 + Rb87_Sr86·(e^(lambda·t)−1)
Isocrona Rb-Sr; grafico Sr87/Sr86 vs Rb87/Sr86 de co-geneticas da idade pela inclinacao.
ORIGEM Geocronologia isotopica
▶ Granitoides arqueanos datados com precisao de ±5 Ma por Rb-Sr
083
Lei de Stokes (Sedimentacao)
FUNDAMENTAL
v_s = 2·r^2·(rho_p − rho_f)·g / (9·eta)
Velocidade de sedimentacao de particula esferica; r=raio, rho_p=densidade particula, eta=viscosidade do fluido.
ORIGEM G.G. Stokes, 1851
▶ Argila em agua -> v_s≈0,13 um/s
084
Equacao de Hjulstrom (Transporte de Sedimento)
INTERMEDIARIO
v_erosao ≈ K · d^0,5
Velocidade critica de erosao vs diametro de grao; areia fina mais facilmente erodida que silte ou cascalho.
ORIGEM F. Hjulstrom, 1935
▶ Areia media (0,5 mm): erosao a ≈20 cm/s
085
Pressao de Soterramento (Litostatica)
FUNDAMENTAL
P_lit = rho_rocha · g · h
Pressao de confinamento de rocha a profundidade h; rho_rocha≈2700 kg/m3; aumenta ~27 MPa/km.
ORIGEM Geomecanica e petrologia
▶ h=10 km -> P_lit≈270 MPa
086
Gradiente Geotermal
FUNDAMENTAL
G = dT/dz
Taxa de aumento de temperatura com profundidade; varia de 15C/km a >100C/km.
ORIGEM Geofisica termica — Turcotte & Schubert
▶ Continental medio: 30C/km -> 300C a 10 km
087
Espessura de Camada por Compactacao (Shumway)
INTERMEDIARIO
phi(z) = phi0 · e^(−c·z)
Porosidade phi diminui exponencialmente com soterramento z; c=coeficiente de compactacao.
ORIGEM Compactacao de sedimentos
▶ Argila: phi0=0,6, c=0,5 km^-1, z=2 km -> phi=0,22
088
Equacao de Clauzon (Taxa de Sedimentacao)
FUNDAMENTAL
SR = espessura / tempo_geologico
Taxa de sedimentacao media; bacias costeiras: 10-100 m/Ma; plataforma continental: 10-1000 m/Ma.
ORIGEM Estratigrafia de sequencias
▶ Camada de 500 m depositada em 5 Ma -> SR=100 m/Ma
089
Isostasia de Airy
INTERMEDIARIO
rho_crosta · h_crosta = rho_manto · h_raiz
Equilibrio isostatico; montanha de espessura h_crosta tem raiz crustal h_raiz.
ORIGEM G.B. Airy, 1855
▶ Himalaia (h=8 km): raiz crustal≈47 km
090
Resistividade Eletrica de Rochas (Equacao de Archie)
AVANCADO
rho = a · phi^(−m) · S_w^(−n) · rho_w
Lei de Archie para resistividade; phi=porosidade, S_w=saturacao de agua, m≈2, a≈1.
ORIGEM G.E. Archie, 1942
▶ Determina saturacao de hidrocarbonetos em perfis eletricos de pocos
091
Perfil de Velocidade Sismica (Formula de Gardner)
INTERMEDIARIO
rho = 0,31 · V_p^0,25
Relacao empirica entre velocidade sismica Vp e densidade rho; usada em processamento sismico.
ORIGEM G.H.F. Gardner et al., 1974
▶ V_p=3000 m/s -> rho≈2,24 g/cm3
092
Equacao de Freitas (Subsidencia Tectonica)
AVANCADO
Y(t) = S · (1 − e^(−t/tau))
Subsidencia tectonica exponencial; S=subsidencia total, tau=constante de tempo.
ORIGEM McKenzie, 1978 — modelo de estiramento
▶ Bacia sedimentar: subsidencia maxima em 50-100 Ma
093
Analise de Proveniencia (Maturidade Textural)
FUNDAMENTAL
Indice_maturidade = pct_graos_arredondados / pct_graos_angulares
Razao de arredondamento de graos; alta maturidade = longo transporte.
ORIGEM Folk & Ward, 1957 — sedimentologia
▶ Areia de praia: alta maturidade; turbidito: baixa maturidade
094
Calculo de Paleobatimetria (Foraminiferos)
AVANCADO
Paleobatimetria = f_assembleia_foraminiferos
Reconstituicao de profundidade paleomar por biofacies de foraminiferos.
ORIGEM Paleoceanografia
▶ Associacao de Cibicidoides sugere plataforma externa (200-500 m)
095
Numero de Froude Sedimentar
INTERMEDIARIO
Fr = v / sqrt(g·h)
Adimensional de fluxo sedimentar; Fr<1=subcritico; Fr>1=supercritico.
ORIGEM W. Froude — aplicado a sedimentos
▶ Determina estruturas sedimentares em depositos de turbidito
096
Estimativa de Paleoelevacao (Clumped Isotopes)
AVANCADO
Delta47 = f(T_formacao)
Isotopos agrupados em carbonatos fornecem temperatura de formacao independente do delta13C e delta18O.
ORIGEM Ghosh et al., 2006
▶ Carbonato andino: Delta47 indica T=10C -> elevacao≈3000 m
097
Equacao de Fluxo de Calor Crustal
FUNDAMENTAL
q = −k · dT/dz
Fluxo de calor q; k=condutividade termica da rocha, dT/dz=gradiente geotermico.
ORIGEM Geofisica termica
▶ k=3 W/mK, gradiente=25C/km -> q=75 mW/m2
098
Balanceamento de Secao Estrutural (Retrodeformacao)
AVANCADO
epsilon = (L0−L) / L0
Conservacao de area em secoes geologicas balanceadas; determina quantidade de encurtamento crustal.
ORIGEM Dahlstrom, 1969 — structural geology
▶ Secao dos Andes: encurtamento crustal de 150-300 km
099
Analise de Facies (Phi de Wentworth)
FUNDAMENTAL
phi = −log2(d_mm)
Escala phi de Wentworth; d=diametro em mm; argila: phi>8; areia fina: phi=2-3.
ORIGEM C.K. Wentworth, 1922
▶ d=0,25 mm -> phi=2
100
Espessura Crustal por Gravimetria (Bouguer)
INTERMEDIARIO
Deltag_Bouguer = Deltag_livre_ar − 0,1119·h
Anomalia Bouguer corrige gravidade para topografia; anomalias negativas indicam raiz crustal.
ORIGEM Gravimetria — P. Bouguer, 1749
▶ Plato tibetano: anomalia Bouguer de −400 a −600 mGal
Arqueologia Quantitativa e Datacao
Metodos de Datacao
101
Datacao por Radiocarbono (14C)
FUNDAMENTAL
t = 8267 · ln(A0/A)
Datacao 14C; t1/2=5730 anos; alcance≈50 000 anos.
ORIGEM W.F. Libby, 1949
▶ Atividade=50% de A0 -> t=5730 anos BP
102
Dendrocronologia (Correlacao de Aneis)
FUNDAMENTAL
t_amostra = calendario_absoluto
Datacao absoluta por correlacao de padroes de largura de aneis com cronologias mestras.
ORIGEM A.E. Douglass, 1901
▶ Vigas de madeira medievais datadas com precisao de 1 ano
103
Datacao por Termoluminescencia (TL)
INTERMEDIARIO
t = L_TL / taxa_de_dose
Idade TL de ceramica ou sedimento; L_TL=luminescencia equivalente a dose acumulada.
ORIGEM Aitken, 1985
▶ Ceramica com dose=5 Gy, taxa=1 mGy/a -> t=5000 anos
104
Densidade de Artefatos por m2 (Analise Espacial)
FUNDAMENTAL
D_artefatos = n / A_escavacao
Densidade de artefatos por unidade de area; indicador de intensidade de uso e preservacao arqueologica.
ORIGEM Arqueologia espacial
▶ 100 artefatos em 10 m2 -> D=10/m2
105
Indice de Diversidade de Shannon (Ceramica)
INTERMEDIARIO
H = −sum_pi_ln_pi
Diversidade de tipos ceramicos em sitio; H=0 monotype; H=ln(n) maximo.
ORIGEM C.E. Shannon, 1948 — aplicado a arqueologia
▶ 5 tipos iguais -> H=ln5=1,61
106
Analise de Isotopos de Estroncio (Migracao)
AVANCADO
Sr87_Sr86_osso ≈ Sr87_Sr86_agua_local
Razao de Sr em esmalte dentario reflete geologia local da infancia.
ORIGEM Tracing migration — Price et al., 1994
▶ Sr de mumia andina difere do local de enterramento -> migracao
107
Analise de Tracos de Uso (Microwear)
AVANCADO
Ra = integral_media_absoluta_perfil
Parametro de rugosidade Ra de arestas liticas por microscopia; distingue corte de madeira, carne ou couro.
ORIGEM Keeley, 1980 — use-wear analysis
▶ Silex com Ra alto = uso abrasivo; Ra baixo = corte de planta
108
Formula de Binford (Indice de Utilidade Alimentar)
INTERMEDIARIO
IUA = (g_proteina + g_gordura) / kg_osso
Indice de utilidade alimentar de partes animais; ordena partes por valor alimentar.
ORIGEM L.R. Binford, 1978
▶ Costela tem IUA alto; metapodo baixo
109
NISP e MNI (Quantificacao de Fauna)
FUNDAMENTAL
MNI = max_frequencia_elemento_por_lado
NISP=numero especimes; MNI=numero minimo de individuos; MNI menos afetado por fragmentacao.
ORIGEM Zooarqueologia quantitativa
▶ 20 femures direitos de veado -> MNI=20
110
Datacao por Hidratacao de Obsidiana
INTERMEDIARIO
t = x^2 / k
Camada de hidratacao x^2 proporcional ao tempo; k=taxa de hidratacao dependente da temperatura e composicao.
ORIGEM Friedman & Smith, 1960
▶ Camada=4 um2, k=1 um2/seculo -> t=400 anos
111
Indice de Trocas a Longa Distancia (XTDI)
FUNDAMENTAL
XTDI = n_artefatos_exoticos / n_artefatos_total × 100
Proporcao de artefatos de materia-prima nao-local; XTDI alto indica redes de troca de longa distancia.
ORIGEM Arqueologia de redes — Renfrew, 1975
▶ Sitio com 15% obsidiana de 400 km -> XTDI=15%
112
Analise de Correspondencia (Seriacao)
AVANCADO
chi2 = sum_quiquadrado_ij
Qui-quadrado para analise de correspondencia; ordena sitios por tipos de artefatos.
ORIGEM Ford, 1952 — aplicacao de analise de correspondencia
▶ Seriacao de ceramica organiza sitios em sequencia cronologica
113
Equacao de Hominizacao (Encefalizacao)
AVANCADO
EQ = cerebro_peso / (0,12 · peso_corporal^0,67)
Quociente de encefalizacao; EQ humano≈7,6; primatas nao-humanos≈2-3.
ORIGEM Jerison, 1973 — paleontologia cognitiva
▶ EQ do Homo habilis≈3,3; H. sapiens≈7,6
114
Analise de Fitolitos (Concentracao por g)
INTERMEDIARIO
Fitolitos_por_g = n_contados × fator_de_diluicao
Concentracao de fitolitos em sedimento arqueologico; indica presenca de graminias, palmeiras etc.
ORIGEM Piperno, 1988 — paleoetnobotanica
▶ Alta concentracao de fitolitos de graminias -> uso agricola do sitio
115
Indice de Potencial de Sitio Arqueologico (SPI)
AVANCADO
SPI = soma_ponderada_criterios
Potencial arqueologico ponderado em SIG; orienta prospeccao e gerenciamento de patrimonio.
ORIGEM Predictive modeling — Kvamme, 1988
▶ Areas com SPI>0,7 tem alta probabilidade de conter sitios
116
Datacao por Luminescencia Opticamente Estimulada (OSL)
INTERMEDIARIO
Idade_OSL = dose_equivalente / taxa_de_dose_anual
Data quando sedimento foi por ultimo exposto a luz; ideal para sedimentos eolicos.
ORIGEM Huntley et al., 1985
▶ Duna: dose equiv.=50 Gy, taxa=1 Gy/ka -> Idade=50 000 anos
117
Analise de Cluster Hierarquico (Tipologia)
AVANCADO
d = distancia_euclidiana_total
Distancia euclidiana entre atributos de artefatos; agrupamento hierarquico identifica tipos e subtipos.
ORIGEM Analise multivariada — Ward, 1963
▶ Classificacao de ceramica em 5 grupos tipologicos por cluster
118
Indice de Mobilidade de Cacadores-Coletores
INTERMEDIARIO
IMC = area_exploracao / tamanho_grupo
Km2 per capita explorados anualmente; indicador de estrategia de subsistencia.
ORIGEM Etnografia quantitativa — Kelly, 1995
▶ Aborigenes australianos: IMC≈30 km2/pessoa
119
Analise de Isotopos de Carbono (Dieta)
INTERMEDIARIO
delta13C_colageno = ((R_amostra/R_padrao) − 1) × 1000
Delta13C de colageno osseo reflete dieta: plantas C3 vs C4/milho.
ORIGEM DeNiro & Epstein, 1978
▶ delta13C=−12 em pre-colombiano indica dieta predominantemente de milho
120
Indice de Eficiencia de Forrageamento (OFT)
AVANCADO
e_i = ganho_energetico_i / tempo_total_i
Teoria do forrageamento otimo; preve decisao de incluir/excluir recursos por presa.
ORIGEM Optimal foraging theory — MacArthur & Pianka, 1966
▶ Queda no rank de presa indica diminuicao de recurso primario
Fisica Medica e Radioterapia
Dosimetria Basica
121
Dose Absorvida (Gray)
FUNDAMENTAL
D = E / m
Energia depositada por radiacao por unidade de massa; 1 Gy=1 J/kg.
ORIGEM ICRU Report 85
▶ Dose terapeutica de radioterapia: 60-80 Gy em 30-40 fracoes
122
Dose Equivalente (Sievert)
FUNDAMENTAL
H = D · wR
Dose equivalente; wR=fator de ponderacao de radiacao.
ORIGEM ICRP Publication 103, 2007
▶ 1 Gy de neutrons rapidos -> H=20 Sv
123
Dose Efetiva (ICRP)
INTERMEDIARIO
E = sum_wT_HT
Dose efetiva considerando radiosensibilidade dos orgaos.
ORIGEM ICRP Publication 103, 2007
▶ Tomografia de torax: E≈7 mSv
124
Lei de Atenuacao de Fotons
FUNDAMENTAL
I = I0 · e^(−mu·x)
Atenuacao exponencial de fotons em material de espessura x; mu=coeficiente de atenuacao linear.
ORIGEM Fisica de raios-X
▶ Pb: 1 cm reduz feixe a 60%
125
Camada Semi-Redutora (CSR)
FUNDAMENTAL
CSR = 0,693 / mu
Espessura que reduz intensidade a metade; base do dimensionamento de blindagens.
ORIGEM Dosimetria de protecao radiologica
▶ Pb: mu≈1,5 cm^-1 -> CSR≈0,46 cm
126
Modelo Linear-Quadratico (Radiobiologia)
AVANCADO
S = e^(−(alpha·D + beta·D^2))
Sobrevivencia de celulas irradiadas; alpha=efeito de dose unica, beta=efeito de dose fracionada.
ORIGEM Douglas & Fowler, 1976
▶ alpha/beta alto indica sensibilidade a hiper-fracionamento
127
Dose Biologicamente Efetiva (BED)
AVANCADO
BED = D·(1 + d/(alpha_beta))
Dose biologicamente efetiva; D=dose total, d=dose por fracao.
ORIGEM Fowler, 1989
▶ 60 Gy em 2 Gy/fracao, alpha/beta=10 -> BED=72
128
Atividade Radioativa (Becquerel)
FUNDAMENTAL
A = lambda · N = A0 · e^(−lambda·t)
Atividade em desintegracoes/segundo; fundamental em medicina nuclear.
ORIGEM IAEA Radiation Safety
▶ 131I: t1/2=8 dias
129
Formula de Quetelet para Superficie Corporal
FUNDAMENTAL
SC = sqrt(altura_cm × peso_kg / 3600)
Superficie corporal simplificada; usada para calcular dose de quimioterapicos.
ORIGEM Du Bois & Du Bois, 1916 — Mosteller, 1987
▶ 70 kg, 175 cm -> SC≈1,84 m2
130
Penumbra de Feixe de Radioterapia
INTERMEDIARIO
P = (d80 − d20) / 2
Largura de penumbra entre doses de 80% e 20%; afeta planejamento de margens tumorais.
ORIGEM ICRU Report 50
▶ Feixe de 6 MV: penumbra≈3-4 mm
131
Indice de Conformidade (Radioterapia)
AVANCADO
CI = V_90isodose / V_tumor
Indice de conformidade; CI=1 ideal; CI>1 indica irradiacao de tecido normal.
ORIGEM RTOG 90-05
▶ CI=1,2: 20% a mais de tecido irradiado
132
Eficiencia de Deteccao (DQE)
AVANCADO
DQE = SNR_out^2 / SNR_in^2
Eficiencia quantica de deteccao de detector de imagem medica; DQE=1 ideal.
ORIGEM Fisica de imagem medica
▶ Detector DR plano: DQE≈0,65
133
Resolucao Espacial (MTF)
AVANCADO
MTF = FT_PSF
Funcao de transferencia de modulacao; PSF=funcao de espalhamento pontual.
ORIGEM Teoria de imagem — Goodman, 1968
▶ Fluoroscopia digital: MTF a 2 lp/mm≈0,4
134
Dose em Orgao de Risco (gEUD)
AVANCADO
gEUD = (sum_vi_Di_n)^(1/n)
Dose uniforme generalizada equivalente; n>1=orgao serial; n<1=orgao paralelo.
ORIGEM Niemierko, 1997
▶ Medula espinhal (n=infinito): gEUD=dose maxima
135
Numero de Unidades Hounsfield (CT)
FUNDAMENTAL
HU = 1000 × (mu_tecido − mu_agua) / mu_agua
Escala CT de atenuacao; ar=−1000 HU, agua=0, osso=+500 a +1000.
ORIGEM G.N. Hounsfield, 1972
▶ Gordura≈−100 HU; musculo≈+50 HU
136
Velocidade de Fase de Ondas de Ultrassom
FUNDAMENTAL
c = sqrt(K/rho)
Velocidade de ultrassom em tecido; tecido mole: c≈1540 m/s.
ORIGEM Fisica de ultrassom medico
▶ Figado: c≈1570 m/s
137
Impedancia Acustica (Reflexao de US)
INTERMEDIARIO
Z = rho · c; R = ((Z2−Z1)/(Z2+Z1))^2
Impedancia acustica Z; coeficiente de reflexao R na interface.
ORIGEM Fisica de ultrassom diagnostico
▶ Interface tecido-ar: R≈99%
138
Formula de Larmor (Frequencia de Ressonancia — MRI)
INTERMEDIARIO
f0 = gamma · B0 / (2·pi)
Frequencia de Larmor; base do MRI.
ORIGEM J. Larmor, 1897 — aplicado a MRI
▶ Campo de 1,5 T -> f0=63,87 MHz para 1H
139
Sinal-Ruido em MRI (SNR)
AVANCADO
SNR ∝ B0^(7/4) · sqrt(NEX / BW) · voxel
SNR cresce com B0, medias (NEX), voxel maior e menor largura de banda.
ORIGEM Fisica de MRI
▶ Dobrar B0 de 1,5 para 3 T aumenta SNR≈2,8x
140
Dose de Radiografia de Torax vs Dose de Fundo
FUNDAMENTAL
E_RX_torax ≈ 0,02
Comparacao de doses para comunicacao de risco; dose de fundo≈2,4 mSv/ano.
ORIGEM WHO/UNSCEAR — Radiation Safety in Medicine
▶ TC de abdomen: E≈8 mSv
Climatologia e Paleoclimatologia
Oscilacoes Climaticas
141
Indice de Oscilacao do Atlantico Norte (NAO)
FUNDAMENTAL
NAO = (P_Islandia − P_Acores) / sigma_referencia
Indice padronizado da diferenca de pressao ao nivel do mar.
ORIGEM Walker & Bliss, 1932
▶ NAO>+1: inverno quente e umido no norte da Europa
142
Sensibilidade Climatica (Equilibrio)
FUNDAMENTAL
DeltaT = S · ln(CO2/CO2_ref) / ln2
Aquecimento por dobramento do CO2; S=sensibilidade climatica.
ORIGEM IPCC AR6, 2021
▶ CO2 de 280 para 560 ppm -> DeltaT≈3C
143
Forcamento Radiativo de CO2
FUNDAMENTAL
DeltaF = 5,35 · ln(C/C0)
Forcamento radiativo do CO2; C0=referencia pre-industrial.
ORIGEM Myhre et al., 1998 — IPCC TAR
▶ CO2=420 ppm -> DeltaF≈2,16 W/m2
144
Indice de Aridez de De Martonne
FUNDAMENTAL
IAr = P / (T + 10)
Indice de aridez; P=precipitacao anual, T=temperatura media.
ORIGEM E. De Martonne, 1926
▶ Sahel: P=200 mm, T=28C -> IAr≈5,3
145
Proxy de Temperatura por delta18O
AVANCADO
T = a − b · delta18O_calcita
Termometro de isotopos de oxigenio em foraminiferos.
ORIGEM Epstein et al., 1953 — paleotermometro
▶ Glaciais: delta18O≈+3 mais pesado que interglaciais
146
Ciclos de Milankovitch (Excentricidade)
AVANCADO
e(t) = e0 + soma_Ai_cos
Excentricidade orbital periodica; ciclo de 100 ka domina alternancia glacial-interglacial.
ORIGEM M. Milankovitch, 1941
▶ Ciclos de 100 ka correlacionam com registros de delta18O marinho
147
Temperatura de Bulbo Umido (Aproximacao)
AVANCADO
T_bu = aproximacao_stull(T_bs, RH)
Temperatura de bulbo umido aproximada; importante para estresse termico humano e indice WBGT.
ORIGEM Stull, 2011
▶ T=30C, RH=70% -> T_bu≈25,5C
148
Indice de Seca de Palmer (PDSI)
INTERMEDIARIO
PDSI_t = 0,897 · PDSI_t_1 + Z_t/3
Indice padronizado de seca; Z=indice de anomalia de umidade.
ORIGEM W.C. Palmer, 1965
▶ PDSI=−4 indica seca severa
149
Temperatura Maxima Tolerable (WBGT)
INTERMEDIARIO
WBGT_outdoor = 0,7·T_bu + 0,2·T_globo + 0,1·T_seco
Indice de estresse calorico; WBGT>28C risco a trabalhadores.
ORIGEM Yaglou & Minard, 1957 — ISO 7243
▶ Trabalho pesado ao sol: limite WBGT=25C
150
Equacao de Penman-Monteith (Evapotranspiracao)
AVANCADO
ET0 = (0,408·Delta·(Rn−G) + gamma·(900/(T+273))·u2·(es−ea)) / (Delta + gamma·(1+0,34·u2))
ET de referencia; padrao FAO para estimar demanda de irrigacao.
ORIGEM Penman, 1948; Monteith, 1965; FAO-56
▶ Padrao FAO para estimar demanda de irrigacao
151
Indice de ENSO (ONI)
FUNDAMENTAL
ONI = media_movel_3meses_SSTA_Nino34
Indice de El Nino/La Nina; ONI>=+0,5C=El Nino; <=−0,5C=La Nina.
ORIGEM CPC/NOAA
▶ El Nino 1997-98: ONI atingiu +2,8C
152
Temperatura de Equilibrio Planetario
FUNDAMENTAL
T_eq = (S0·(1−alpha)/(4·sigma))^(1/4)
Temperatura sem efeito estufa; T_eq≈255 K.
ORIGEM Climatologia fisica
▶ Efeito estufa natural eleva de 255K para 288K
153
Precipitacao de Projeto (Chuva Maxima)
INTERMEDIARIO
i = a / (t + b)^c
Curva IDF; a,b,c=parametros regionais, t=duracao, i=intensidade.
ORIGEM Hidrologia aplicada — curvas IDF
▶ Tr=25 anos, t=30 min -> i≈90 mm/h
154
Albedo de Superficie e Retroalimentacao
AVANCADO
DeltaF_albedo = −S0/4·Delta_alpha; DeltaT_albedo = −DeltaF_albedo / lambda
Retroalimentacao de albedo; perda de gelo -> menor albedo -> mais aquecimento.
ORIGEM Budyko, 1969
▶ Perda de 1% de gelo artico -> DeltaF≈+0,34 W/m2
155
Indice de Continentalidade (Gorczynski)
FUNDAMENTAL
K = 1,7·(A/sin(phi)) − 20,4
Continentalidade climatica; A=amplitude anual de temperatura, phi=latitude.
ORIGEM W. Gorczynski, 1920
▶ Moscou: K≈50; Lisboa: K≈15
156
Ponto de Orvalho (Magnus Approximation)
FUNDAMENTAL
Td = b·gamma / (a−gamma); gamma = a·T/(b+T) + ln(RH/100)
Temperatura de ponto de orvalho; a=17,27, b=237,7C.
ORIGEM Magnus, 1844 — Alduchov & Eskridge, 1996
▶ T=30C, RH=70% -> Td≈24C
157
Razao de Precipitacao/Temperatura (Thornthwaite)
AVANCADO
I = soma_Ti_termica; ET_pot = 16·(10·T/I)^a
Indice termico anual de Thornthwaite; classifica climas por eficiencia hidrica.
ORIGEM C.W. Thornthwaite, 1948
▶ Classifica biomas de tundra a floresta tropical
158
Taxa de Lapse Ambiental
FUNDAMENTAL
Gamma = −dT/dz
Gradiente vertical de temperatura na atmosfera; Gamma_adiabatico_seco=9,8C/km.
ORIGEM Meteorologia — termodinamica atmosferica
▶ Montanha de 3000 m: T reduz ≈19,5C na base
159
Indice de Irregularidade de Chuva (Cv)
FUNDAMENTAL
Cv = sigma_P / P_media × 100
Coeficiente de variacao da precipitacao; Cv>30% indica alta variabilidade.
ORIGEM Climatologia estatistica
▶ Semi-arido nordestino: Cv≈40-60%
160
Temperatura do Mar por OISST
FUNDAMENTAL
SSTA = SST − SST_climatologia
Anomalia de temperatura superficial do mar; base de monitoramento de ENSO e MJO.
ORIGEM Reynolds et al., 2007 — NOAA OISST
▶ SSTA>+3C no Atlantico Sul em 2024 bateu recordes
""";
    }
}
