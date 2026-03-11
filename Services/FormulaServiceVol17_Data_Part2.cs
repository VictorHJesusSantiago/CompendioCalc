namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol17Parte2 = """
Meios Porosos e Transporte em Geologia
Fluxo e Transporte em Meios Heterogeneos
081
Permeabilidade de Kozeny-Carman
INTERMEDIARIO
k_KC = phi_por^3 * d_p^2 / (180 * (1 - phi_por)^2)
Permeabilidade k em m2 em funcao da porosidade phi e diametro de particula d_p; valida para meios granulares; base de projeto de filtros e caracterizacao de reservatorios.
ORIGEM Kozeny, 1927; Carman, 1937 - Transactions of the Institution of Chemical Engineers
▶ Areia media phi=0,35, d_p=0,5mm: k=3,5e-11 m2=35 Darcy; shale: k<1e-21 m2 (nano-Darcy)

082
Equacao de Richards (Fluxo em Solo Nao Saturado)
AVANCADO
d_theta_dt = C_capil * dP_c_dt - dKh_dx - dKh_dy
Equacao de Richards para transporte de agua no solo; theta=conteudo volumetrico de agua; C_capil=capacidade capilar; K_h=condutividade hidraulica nao saturada.
ORIGEM L.A. Richards, 1931 - Physics
▶ Infiltracao apos chuva: frente de molhamento satura solo; modelagem de recarga de aquifero

083
Dispersividade em Transporte de Contaminante
INTERMEDIARIO
D_L = alpha_L * v_poro + D_m * tau_tor
Coeficiente de dispersao longitudinal; alpha_L=dispersividade longitudinal; v_poro=velocidade de poros=v_darcy/phi; D_m=difusao molecular; tau_tor=tortuosidade.
ORIGEM Bear, 1972 - Dynamics of Fluids in Porous Media
▶ Pluma de benzeno em aquifero: D_L=1e-4 m2/s; espalhamento da frente de contaminacao

084
Isoterma de Freundlich (Adsorcao em Solo)
INTERMEDIARIO
q_e = K_F * Ce^(1/n_fr)
Adsorcao nao linear; K_F=capacidade de Freundlich; 1/n_fr=expoente (0,3-0,9); competicao com outros solutos; base de remediacao de solo contaminado.
ORIGEM Freundlich, 1907 - Kapillarchemie
▶ Atrazina em solo agricola: K_F=0,15; 1/n=0,7; Ce=1 ug/L; q_e=0,12 ug/g

085
Equacao de Adveccao-Dispersao-Reacao (ADR)
INTERMEDIARIO
dC_dt = D_L * d2C_dx2 - v_poro * dC_dx - lambda_d * C
Transporte de soluto em aquifero 1D; lambda_d=taxa de decaimento de 1a ordem; base de modelagem de contaminacao de aquifero e remediacoes pump-and-treat.
ORIGEM Ogata & Banks, 1961 - USGS Professional Paper
▶ Atrazina em aquifero (lambda=0,01/d): frente de contaminacao calculada por solucao analitica de Ogata-Banks

086
Percolacao - Limiar de Conectividade
FUNDAMENTAL
phi_c = 0.31
Limiar de percolacao em rede cúbica 3D; phi>phi_c: caminhos de fluxo percolam; phi<phi_c: fluxo bloqueado; relevante em polimeros condutores e rochas.
ORIGEM Ziman, 1979 - Models of Disorder; Sahimi, 1994
▶ Rocha reservatório: phi>0,05 tipicamente necessario para permeabilidade economica; argila: phi>0,3 porém k muito baixo (microporos)

087
Capilaridade - Equacao de Lucas-Washburn
INTERMEDIARIO
L_tube = sqrt(r_tube * gamma_cap * cos_theta_cap / (2 * eta_cap) * t)
Comprimento de ascensao capilar vs tempo em tubo; r_tube=raio; gamma_cap=tensao superficial; eta_cap=viscosidade; base de imbibicao espontanea em rocha.
ORIGEM Lucas, 1918; Washburn, 1921 - Physical Review
▶ Agua em capilar de vidro (r=1 um): L=sqrt(1e-6*0,07*1/(2*1e-3)*t)=sqrt(35*t) mm

088
Condutividade Hidraulica de Van Genuchten-Mualem
AVANCADO
K_VGM = K_sat * Se_vgm^0.5 * (1 - (1 - Se_vgm^(1/m_vgm))^m_vgm)^2
Funcao de condutividade nao saturada; Se_vgm=saturacao efetiva; m_vgm=1-1/n_vgm; parametros ajustados por curva de retencao de agua no solo.
ORIGEM Van Genuchten, 1980 - Soil Science Society of America Journal
▶ Solo argiloso: K_sat=1e-7 m/s; a theta=0,15: K=1e-10 m/s (reduzida 1000x vs saturada)

089
Numero de Peclet em Meios Porosos
FUNDAMENTAL
Pe_porous = v_poro * L_scale / D_L
Numero de Peclet do meio poroso; Pe<1: difusao domina; Pe>10: adveccao domina; critico para projeto de remediacoes de aquifero.
ORIGEM Johnston, 1991 - Water Resources Research
▶ Pe=100: perfil de concentracao quase pistao; Pe=0,1: dispersao difusiva domina na coluna de solo

090
Gradiente de Pressao Efetiva (Terzaghi)
INTERMEDIARIO
sigma_eff = sigma_total - alpha_b * p_pore
Principio de Terzaghi: tensao efetiva controla comportamento geomecanico; alpha_b=coeficiente de Biot=1 para solo; base de consolidacao e compactacao de reservatorio.
ORIGEM K. Terzaghi, 1943 - Theoretical Soil Mechanics
▶ Subsidencia de reservatorio: producao de oleo reduz p_pore, aumenta sigma_eff e compacta rocha

091
Fluxo em Fratura Plana (Cubic Law)
INTERMEDIARIO
Q_frac = w_frac^3 * b_frac * dP_dx_fr / (12 * eta_fr)
Fluxo em fratura de abertura w_frac por largura b_frac; proporcional a w^3 (cubic law); fraturas dominam fluxo em rochas cristalinas.
ORIGEM Louis, 1969; Snow, 1969 - fratura hidraulica
▶ Fratura de 0,1 mm aberta: Q 1000x maior que fratura de 0,01 mm; fraturas naturais dominam produtividade de pocos em reservatorios fraturados

092
Difusao de Drug de Higuchi em Matrix
INTERMEDIARIO
Q_drug = sqrt(D_drug * (2 * A_load - Cs_drug) * Cs_drug * t)
Liberacao cumulativa de farmaco de matrix porosa; A_load=carga total, Cs_drug=solubilidade; valida quando A>>Cs; base de formulacoes de liberacao sustentada.
ORIGEM T. Higuchi, 1961 - Journal of Pharmaceutical Sciences
▶ Comprimido de liberacao sustentada: Higuchi preve perfil de liberacao em funcao de raiz de t

093
Evaporacao de Solo de Penman-Monteith (Simplificado)
INTERMEDIARIO
E_vapor = D_vap * (rho_sat_T - rho_air) / delta_z
Fluxo de vapor simplificado; D_vap=difusividade de vapor; delta_z=espessura de camada limite; calibrado contra evaporimetros de Piche.
ORIGEM Penman, 1948; Monteith, 1965 - Symposia Society Experimental Biology
▶ Solo saturado em dia quente: E=5mm/dia; solo com baixa umidade: E reducao 10x por resistencia estomatica

094
Equacao de Filtro Cake (Darcy-Ruth)
AVANCADO
dP_filter = mu_f * R_m * v_f / A_f + mu_f * alpha_c * c_conc * v_f^2 / A_f^2
Pressao de filtracao; R_m=resistencia da membrana; alpha_c=resistencia especifica do cake; base de projeto de filtros-prensa e processos de separacao liquido-solido.
ORIGEM Ruth, 1935 - Industrial Engineering Chemistry; ISO 11500
▶ Filtracao de lama: R_m=1e12 m-1; alpha_c=1e13 m/kg; pressao cresce com tempo de filtracao

095
Difusividade Efetiva em Catalisador Poroso
INTERMEDIARIO
D_eff_cat = D_bulk * phi_cat / tau_tort
Difusividade efetiva em catalisador; phi_cat=porosidade intraparticular; tau_tort=tortuosidade (2-10); limita taxa de reacao em catalisadores industriais.
ORIGEM Satterfield, 1970 - Mass Transfer in Heterogeneous Catalysis
▶ Zeolita ZSM-5: phi=0,33, tau=3; D_eff=D_bulk/9; difusao controla conversao em reator de leito fixo

096
Modelo MIM (Mobile-Imobile) de Transporte
AVANCADO
dC_m_dt = D_L * d2C_m_dx2 - v_poro * dC_m_dx - omega_mim * (C_m - C_im)
Transporte em dominio movel/imovel; omega_mim=coeficiente de troca; captura efeito de tailing em brechas em curvas de breakthrough.
ORIGEM Coats & Smith, 1964 - Society of Petroleum Engineers
▶ Curva de breakthrough de tracer em aquifero heterogeneo: cauda longa explicada por adsorcao reversivel lenta

097
Escoamento Potencial em Meio Poroso
FUNDAMENTAL
v_pot = phi_vel / r_flow
Velocidade de escoamento potencial; nabla^2_phi=0; satisfeita antes do equilíbrio de Darcy; base de analise de acoes em barragens e secagens.
ORIGEM Redes de fluxo - Dupuit-Forchheimer, 1863
▶ Barreira de argila (phi reduzida): escoamento potencial mapeia linhas de fluxo e equipotenciais

098
Cinetica de Langmuir-Hinshelwood (Catalise)
INTERMEDIARIO
r_LH = k_cat * K_A * C_A * K_B * C_B / (1 + K_A * C_A + K_B * C_B)^2
Taxa de reacao bimolecular em superficie catalitica; K_A e K_B=constantes de equilibrio de adsorcao de A e B; maxima taxa com K_A*C_A=K_B*C_B=1.
ORIGEM Langmuir, 1916; Hinshelwood, 1926 - Nobel 1956
▶ Oxidacao de CO em catalisador de Pt: taxa limitada por adsorcao de O2; base de catalisadores de automovel

099
Retencao de Agua em Solo de Van Genuchten
INTERMEDIARIO
Se_VG = (1 + (alpha_VG * abs_h)^n_VG)^(-m_VG)
Saturacao efetiva em funcao da pressao matricial h; m_VG=1-1/n_VG; ajustada ao solo especifico; entrada para calculo de condutividade nao saturada.
ORIGEM Van Genuchten, 1980 - Soil Science Society of America Journal
▶ Solo arenoso: alpha=0,05/cm, n=2,2; curva de retencao ajustada por tensiometros

100
Fator de Atrito de Blasius em Escoamento Poroso
FUNDAMENTAL
f_Blasius = 0.3164 / Re_por^0.25
Fator de atrito de Blasius para numero de Reynolds em meio granular; valido 4000<Re<100000; base de dimensionamento de quedas de pressao em leitos.
ORIGEM Blasius, 1913 - Forschungsarbeiten; Ergun, 1952
▶ Leito fluidizado de FCC: queda de pressao calculada por Ergun-Blasius; base de reatores de petroleo

Endocrinologia e Metabolismo Hormonal
Farmacocinetica e Dinamica Hormonal
101
Farmacocinetica de Dois Compartimentos
INTERMEDIARIO
C_pk = A_pk * exp(-alpha_pk * t) + B_pk * exp(-beta_pk * t)
Concentracao plasmatica biexponencial; alfa_pk>beta_pk; fase alfa=distribuicao rapida; fase beta=eliminacao; relevante para hormônios polipeptidicos como insulina.
ORIGEM Teorell, 1937; Riggs, 1963 - Pharmacokinetics
▶ Insulina iv: alfa_pk=8/h (distribuicao); beta_pk=0,7/h (eliminacao); C0=0,1 nmol/L

102
Receptor Hormonal - Fracao de Ocupacao
FUNDAMENTAL
HR_frac = H_conc / (H_conc + Kd_recep)
Fracao de receptor ocupado; Kd_recep=constante de dissociacao; EC50=Kd para resposta linear; base de farmacologia de agonistas hormonais.
ORIGEM A.V. Hill, 1910; Clark, 1933 - The Mode of Action of Drugs on Cells
▶ T3 no receptor tiroideo: Kd=1e-11 M; em T3=1e-10 M: HR_frac=0,91 (90% de receptores ocupados)

103
Pulsatilidade de GnRH e LH
INTERMEDIARIO
LH_pulse_rate = freq_GnRH / freq_ref
Razao de pulsatilidade; GnRH pulsatil a 1 pulso/h estimula LH; continuo suprime LH (base de agonistas de GnRH em cancer de prostata).
ORIGEM G.D. Knobil, 1980 - Science; base de agonistas de GnRH (leuprolide)
▶ Puberdade: aumento de pulsos de GnRH inicia maturacao gonadal; agonistas continuos: castração química

104
Resposta Emax Sigmoidea (Eficacia Hormonal)
INTERMEDIARIO
E_emax = E_maximum * H_conc^n_hill / (EC50_h^n_hill + H_conc^n_hill)
Eficacia maxima E_maximum com sigmoidicidade n_hill (coopetividade); alvo de calibracao de dose-resposta de hormônios polipeptidicos e esteroides.
ORIGEM A.V. Hill, 1910; DeLean et al., 1978 - Mol. Pharmacol.
▶ Cortisol no cortex adrenal: n_hill=1,5; EC50=10 nM; resposta sigmoidal a ACTH

105
Eixo HPA - Modelo de Feedback de Estresse
AVANCADO
dCRH_dt = f_stress - k1_hpa * CRH - k2_hpa * CRH * ACTH
Dinamica simplificada de CRH no eixo hipotalamo-pituitaria-adrenal; feedback negativo de cortisol suprime CRH; disrupcao em depressao e TEPT.
ORIGEM Keller-Wood & Dallman, 1984 - Endocrine Reviews; modelo HPA
▶ Perturbacao de estresse: pico de cortisol em 15-30 min; retorno ao baseline em 60-90 min

106
Resistencia a Insulina - Indice HOMA-IR
FUNDAMENTAL
HOMA_IR = Insulina_uU_mL * Glicemia_mmol_L / 22.5
Indice de resistencia a insulina HOMA-IR; >2,5: resistencia significativa; >5: resistencia severa; calculado em jejum.
ORIGEM Matthews et al., 1985 - Diabetologia
▶ Paciente com diabetes T2: insulina=25 uU/mL, glicemia=8 mmol/L; HOMA-IR=25*8/22,5=8,9 (severo)

107
Modelo Minimal de Bergman (Controle Glicemico)
AVANCADO
dG_berg_dt = p1_berg * (Gb_berg - G_berg) - X_berg * G_berg
Modelo minimal de dinamica de glicose; X_berg=acao de insulina no espaco remoto; p1_berg=taxa de uptake basal; base da clamp hiperinsulinemica.
ORIGEM Bergman et al., 1979 - Journal of Clinical Investigation
▶ Usado para quantificar sensibilidade a insulina SI em estudos clinicos; SI=3 (DM2) vs 10 (normal)

108
Funcao Tireoidiana - Eutireoidismo
FUNDAMENTAL
fT4_index = fT4_meas / T_ref_range
Indice de fT4 livre; eutireoidismo: fT4=12-22 pmol/L; TSH=0,5-4 mUI/L; alvo de ajuste de levotiroxina.
ORIGEM NHANES III; American Thyroid Association Guidelines 2014
▶ TSH=0,1 mUI/L + fT4 alto: hipertireoidismo; TSH=10 mUI/L + fT4 baixo: hipotireoidismo primario

109
Esteroideogenese - Conversao de Colesterol
AVANCADO
E_esteroid = C_chol * k_StAR * k_P450scc
Fluxo de esteroidogenese; colesterol -> pregnenolona via P450scc; regulado por StAR (Steroidogenic Acute Regulatory protein); ACTH e LH estimulam StAR.
ORIGEM Miller & Auchus, 2011 - Endocrine Reviews
▶ Cortisol produzido: ~10-20 mg/dia; DHEA: ~30-50 mg/dia; aldosterona: ~100 ug/dia

110
Cascata de AMPc (Via de Adenilil Ciclase)
INTERMEDIARIO
AMPc_conc = V_AC * ATP / (Km_AC + ATP)
Formacao de AMP ciclico por adenilil ciclase ativada por Gs; AMPc ativa PKA; base de via de sinalização de glucagon, FSH, ACTH e epinefrina.
ORIGEM Sutherland & Rall, 1958 (Nobel 1971) - Journal of Biological Chemistry
▶ Glucagon ativa AC hepatica: AMPc aumenta 10-100x em segundos; ativa fosforilase de glicogenio

111
Sintese de Vitamina D Ativa (1,25-dihidroxi)
AVANCADO
Calcitriol = D25_OH * k_1alpha / (1 + k_fdb * D25_OH)
Ativacao de 25-OH-D3 para calcitriol; regulada por PTH (estimula) e FGF23 (inibe); calcitriol promove absorcao intestinal de Ca e P.
ORIGEM DeLuca, 1988 - FASEB Journal; vitamin D receptor - Norman, 1998
▶ Deficiencia de vitamina D (<20 ng/mL de 25-OH-D): hiperPTH secundario; risco de osteoporose

112
Regulacao do Calcio Ionico Plasmatico
INTERMEDIARIO
Ca2_plasma = Ca_ref + (PTH - PTH_ref) * k_PTH - CT * k_CT
Calcio ionico regulado por PTH (aumento Ca) e calcitonina CT (reducao Ca); alvo: 1,1-1,3 mmol/L; desregulado em hiperparatireoidismo.
ORIGEM Potts & Gardella, 2007 - Annals of the New York Academy
▶ HPT primario: PTH elevado -> hipercalcemia; Ca>3 mmol/L: crise hipercalcemica cirurgica

113
Indice de Androgênios Livres (FAI)
INTERMEDIARIO
FAI = Testosterona_total * 100 / SHBG
Indice de androgenios livres; SHBG alta (gestação, hepatopatia) reduz FAI; FAI>30% em mulheres: hiperandrogenismo (SOP).
ORIGEM Vermeulen et al., 1999 - Journal of Clinical Endocrinology
▶ SOP: testosterona=3 nmol/L; SHBG=20 nmol/L; FAI=15 (elevado para mulheres, norm <5)

114
Secrecao Circadiana de Melatonina
FUNDAMENTAL
melatonin_t = M0 * exp(-k_mela * (t - t_peak)^2)
Perfil gaussiano de melatonina; pico entre 2-4h; suprimida por luz azul (480 nm); base de tratamento de jet lag e disturbios do ciclo circadiano.
ORIGEM Axelrod, 1974 (Nobel 1970) - Science; entrained circadian rhythm
▶ Melatonina pico: 100-200 pg/mL; fotossupressao por luz de 100 lux em 30 min; relevante para saude de trabalhadores noturnos

115
Indice de Massa Corporal (IMC)
FUNDAMENTAL
IMC = massa_kg / altura_m^2
Classificacao: <18,5=abaixo; 18,5-24,9=normal; 25-29,9=sobrepeso; >=30=obesidade; preditor de risco cardiometabolico e criterio de tratamento endocrinologico.
ORIGEM L.A.J. Quetelet, 1832; WHO, 1997
▶ Paciente 80 kg, 1,70 m: IMC=80/2,89=27,7; sobrepeso; criterio de intervencao dietetica

116
Pulso Hormonal Gonadotrofico
INTERMEDIARIO
I_pulse = I_basal + A_pulse * sin(2 * pi * t / T_pulse)
Modelagem simplificada de pulso hormonal; LH/FSH pulsam com T~90...120 min; GnRH agonista continuo suprime gonadotrofinas; agonistas no cancer de prostata.
ORIGEM Crowley et al., 1985 - Neuroendocrinology; GnRH pulse generator
▶ H de 30 anos: LH pulsa a ~1h; amp=10 IU/L; frequencia alterada com idade e ciclo menstrual

117
Perfil Lipidico - Formula de Friedewald
FUNDAMENTAL
LDL = CT - HDL - TG / 5
LDL calculado por formula de Friedewald (mg/dL); valida para TG<400 mg/dL; erro sistematico corrigido por formula de Martin-Hopkins.
ORIGEM Friedewald, Levy & Fredrickson, 1972 - Clinical Chemistry
▶ CT=240, HDL=50, TG=150 mg/dL: LDL=240-50-30=160 mg/dL (alto risco cardiovascular)

118
Sistema Renina-Angiotensina-Aldosterona (SRAA)
INTERMEDIARIO
Ang2 = Renina * AGT_conc * k_ECA
Angiotensina II proporcional a renina e substrato AGT mediada por enzima conversora (ECA); alvo de IECAs e BRAs anti-hipertensivos.
ORIGEM Tigerstedt & Bergman, 1898; iECA introduzido em 1977
▶ IECAs (captopril, enalapril): bloqueiam conversao de Ang I para Ang II; reducao de PA de 10-15 mmHg

119
Resistencia a Insulina - Indice HOMA-Beta
INTERMEDIARIO
HOMA_beta = 20 * Insulina_uU_mL / (Glicemia_mmol_L - 3.5)
Funcao de celulas beta pancreaticas; HOMA-beta>100%: funcao normal; <40%: disfuncao de celula beta; base de estadiamento de DM2.
ORIGEM Matthews et al., 1985 - Diabetologia; UKPDS
▶ Pre-DM2: HOMA-beta=80%; DM2 estabelecido: 50%; falencia de celula beta avancada: <20%

120
Eixo GH-IGF-1 (Somatotrofico)
INTERMEDIARIO
IGF1 = GH_level * k_liver_GH / (1 + k_fdb_GH * GH_level)
IGF-1 produzido no figado em resposta a GH; retroalimentacao negativa hipotalamo-hipofisaria; IGF-1 medeia efeitos anabolicos e de crescimento do GH.
ORIGEM Salmon & Daughaday, 1957; Green et al., 1985 - Science
▶ Acromegalia: GH cronicamente elevado; IGF-1>400 ng/mL; tratamento: octreotida suprime GH

Fotonica e Optica Nao Linear
Lasers e Propagacao de Luz
121
Limiar de Ganho em Laser (Condicao de Threshold)
AVANCADO
g_th_laser = log(1 / (R1 * R2)) / (2 * L_cav) + alpha_int
Ganho de threshold de laser; R1,R2=refletividades dos espelhos; L_cav=comprimento da cavidade; alpha_int=perda interna; base de projeto de lasers.
ORIGEM Maiman, 1960 (Nobel 1964) - primeiro laser; Yariv, 1975 - Quantum Electronics
▶ Laser de diodo: R1=0,32, R2=0,95, L=300 um, alpha_int=5/cm; g_th=60/cm

122
Ganho de Laser e Inversao de Populacao
FUNDAMENTAL
g_gain = sigma_v * delta_N_inv
Ganho optico proporcional ao produto secao transversal de emissao sigma e inversao de populacao delta_N; condição para lasing: g*L > perdas totais.
ORIGEM Einstein, 1917 (emissão estimulada); operacional em 1960 por Maiman
▶ Nd:YAG: sigma=2,8e-23 m2; delta_N=1e18/cm3; g=28/cm; amplificacao de 20 dB em 1 cm

123
Emissao de Laser de Diodo - Comprimento de Onda
FUNDAMENTAL
lambda_diode = h_planck * c_light / E_gap
Comprimento de onda determinado pelo bandgap; InGaAs: E_gap=0,73 eV -> lambda=1310 nm; ajustado por composicao ternaria e temperatura.
ORIGEM Alferov & Kroemer, 1963 (Nobel 2000); InGaAs lasers de telecomunicacoes
▶ InGaAsP: lambda=1550 nm (janela de minima perda de fibra); GaN: lambda=450 nm (azul)

124
Equacao Nao Linear de Schrodinger (Propagacao em Fibra)
AVANCADO
A_out = A_in * exp(-alpha_fib * L_fib / 2)
Amplitude de campo apos propagacao com atenuacao; equacao completa inclui dipersao de 2a ordem e efeito Kerr; simplificado para atenuacao pura.
ORIGEM Hasegawa & Tappert, 1973 - solítons em fibras; Agrawal, 2007 - Nonlinear Fiber Optics
▶ Fibra SMF-28: alpha=0,2 dB/km; em 50 km: A_out=A_in*exp(-0,023)=0,977*A_in (atenuacao 4,6 dB)

125
Largura de Linha de Laser de Schawlow-Townes
AVANCADO
delta_nu = 2 * pi * h_planck * nu0 * delta_nu_c^2 / P_out
Largura de linha de laser quântico; delta_nu_c=largura de linha da cavidade vazia; P_out=potencia de saida; lasers de DFB: delta_nu<100 kHz.
ORIGEM Schawlow & Townes, 1958 - Physical Review; Nobel 1981 (Schawlow)
▶ Laser de DFB para LIDAR: delta_nu=10 kHz; coerencia de 10 km; base de LIDARs de alta precisao

126
Potencia de Saturacao em Amplificador EDFA
AVANCADO
P_sat = A_eff_edfa * h_planck * nu / ((sigma_a + sigma_e) * tau_EDFA)
Potencia de saturacao de amplificador EDFA; A_eff_edfa=area efetiva do modo; tau_EDFA=tempo de vida de Er3+; base de projeto de amplificadores de WDM.
ORIGEM Mears et al., 1987 - Electronics Letters; EDFA em comercializacao desde 1993
▶ EDFA tipico: P_sat=10 mW (10 dBm); ganho de 30 dB; ruido de figura NF=4 dB

127
Comprimento de Rayleigh e Cintura do Feixe Gaussiano
FUNDAMENTAL
z_R = pi * w0_beam^2 / lambda_beam
Comprimento de Rayleigh; w0_beam=cintura do feixe; angulo de divergencia theta=lambda/(pi*w0); base de focalizacao de laser em material.
ORIGEM ABCD matrix formalism; Born & Wolf - Principles of Optics
▶ Laser de CO2 (lambda=10,6 um), w0=50 um: z_R=0,74 mm; focalizacao para corte de material

128
Fase de Gouy
AVANCADO
phi_Gouy = -atan(z_beam / z_R)
Desvio de fase de feixe gaussiano passando pelo foco; phi varia de -pi/2 a +pi/2; critico em interferometria e medidas de fase com feixes gaussianos.
ORIGEM Gouy, 1890; Siegman, 1986 - Lasers
▶ Interferometro de feixes gaussianos: fase de Gouy causa erro sistematico se nao corrigido

129
Taxa de Extincao de Modulacao (ER)
FUNDAMENTAL
ER_dB = 10 * log(P_on / P_off)
Razao entre potencia em bit '1' e bit '0'; ER>10 dB necessario para link sem erros; moduladores de LiNbO3: ER=20 dB; eletroabsorcao: ER=10-15 dB.
ORIGEM Payne & Gambling, 1975; ITU-T G.957
▶ Modulador MZI: ER=20 dB; penalidade de recepcao: quanto menor ER maior o BER

130
Geracao de Segundo Harmonico (SHG)
AVANCADO
P_2omega = d_eff^2 * L_cryst^2 * P_omega^2 / (A_eff_nl * lambda^2)
Potencia de segundo harmonico; d_eff=coeficiente nao linear efetivo; base de laser verde (532 nm) a partir de Nd:YAG (1064 nm) por KTP ou BBO.
ORIGEM Franken et al., 1961 - Physical Review Letters (primeiro SHG)
▶ d_eff(KTP)=3,3 pm/V; L=10 mm; pode converter 40-70% de 1064 nm para 532 nm com phase-match

131
Comprimento de Coerencia
FUNDAMENTAL
l_c = lambda^2 / delta_lambda
Comprimento de coerencia de fonte de luz; laser monomodo: l_c=metros; LED: l_c=micrometros; base de interferometria OCT e holografia.
ORIGEM Born & Wolf, 1959 - Principles of Optics; OCT de Huang et al., 1991
▶ Diodo superluminescente (SLD): delta_lambda=50 nm em 800 nm; l_c=12 um; resolucao de OCT

132
Parametro de Dispersao em Fibra Otica
AVANCADO
D_chrom = -lambda / c_light * beta2_fiber
Dispersao cromatica em ps/(nm.km); SMF-28: D=17 ps/(nm.km) a 1550 nm; zero em 1310 nm; compensada por fibra DCF ou grades de Bragg para WDM.
ORIGEM Gloge, 1971; Mollenauer et al., 1980 - solítons em fibra
▶ Link de 100 km WDM: dispersao acumulada=1700 ps/nm; compensada por DCF de 20 km

133
Pulso de Laser Q-Switched
INTERMEDIARIO
t_pulse = tau_fluor / ln(G0_laser)
Duracao de pulso Q-switched; G0_laser=ganho small signal; potencia de pico elevada para aplicacoes de ablacao e sensing; Nd:YAG: pulsos de 1-50 ns.
ORIGEM McClung & Helwarth, 1962; Koechner, 1976 - Solid State Laser Engineering
▶ Nd:YAG Q-sw: t_pulse=10 ns; pico de 10 MW de energia de 100 mJ; ablacao de metais a 10^13 W/cm2

134
Capacidade de Canal Otico (Shannon-Nyquist)
INTERMEDIARIO
C_channel = B_bps * log(1 + SNR_ch) / log(2)
Capacidade de canal de Shannon em bits/s; SNR em faixa de Nyquist B; fibra com EDFA: SNR=20-30 dB; limite de ~10 bit/s/Hz por modulacao avancada.
ORIGEM C.E. Shannon, 1948 - Bell System Technical Journal
▶ 400G otico: 4 portadoras x 100 Gbps; SE=8 b/s/Hz por DP-64QAM; proximo de limite de Shannon

135
Potencia de Auto-Focalizacao (Soliton de Kerr)
AVANCADO
P_cr_soliton = lambda^2 / (2 * pi * n0 * n2_kerr)
Potencia critica de auto-focalizacao por efeito Kerr; n2_kerr=indice nao linear; acima de P_cr: efeito de lente Kerr focaliza e pode causar dano ao cristal.
ORIGEM Chiao, Garmire & Townes, 1964; Kelley, 1965 - Physical Review Letters
▶ Vidro de silica: n2=2,7e-20 m2/W; lambda=1 um; P_cr=1,5 MW; relevante em pulsos ultrarapidos

136
Modo de Propagacao em Guia de Ondas Planar
AVANCADO
E_guide = sum(a_m * phi_m * exp(i * beta_m * z))
Campo como superposicao de modos; beta_m=constante de propagacao do modo m; guias de onda em fotonica integrada e amplificadores planares.
ORIGEM Marcuse, 1974 - Theory of Dielectric Optical Waveguides
▶ Guia de Si3N4: indices efetivos distintos por modo; base de multiplexacao de modos para comunicacoes oticas

137
Limite de Diffracao de Abbe
FUNDAMENTAL
d_min = 0.61 * lambda / NA_lens
Resolucao minima optica; NA_lens=abertura numerica; microscopio de luz: d=0,2 um; STED quebra o limite; base de microscopias de superresolucao.
ORIGEM E. Abbe, 1873 - Jenaische Zeitschrift; Nobel (Hell, Moerner, Betzig, 2014)
▶ Microscopio de fluorescencia: lambda=500 nm, NA=1,4; d_min=220 nm; STED: d<50 nm

138
Probabilidade de Erro de Bit em FOC (BER)
FUNDAMENTAL
BER = 0.5 * erfc(Q_factor / sqrt(2))
Taxa de erro de bit; Q_factor>6: BER<1e-9 (telecomunicacoes); base de projeto de receptores e de criterio de qualidade de link otico.
ORIGEM Personick, 1973 - Bell System Technical Journal; ITU-T G.976
▶ Q=7: BER=1,3e-12; Q=6: BER=1e-9; target de BER em link de 100G

139
Ganho Raman em Fibra
AVANCADO
g_Raman = g_R0 * exp(-((nu_s - nu_p - nu_shift)^2) / (2 * dnu_R^2))
Ganho Raman estimulado em fibra de vidro; maximo a 13,2 THz de deslocamento da bomba; base de amplificadores Raman de longa distancia.
ORIGEM Stolen & Ippen, 1973 - Applied Physics Letters; amplificador Raman de 2001
▶ Bomba de 1450 nm amplifica sinal de 1550 nm; ganho de 15 dB em 100 km de fibra de alta eficiencia

140
Modulador de Mach-Zehnder Eletro-Optico
INTERMEDIARIO
I_MZI_out = I_in * (cos(pi * V_mod / (2 * V_pi_MZI)))^2
Transmissao do modulador MZI; V_pi=tensao de semi-onda; ponto de quadratura em V=V_pi/2; modulacao de amplitude em sistemas WDM 400G e alem.
ORIGEM Alferness, 1082 - IEEE Journal of Quantum Electronics; LiNbO3 modulators
▶ LiNbO3: V_pi=5V; largura de banda eletrica>40 GHz; base de moduladores de datacenter

Bioprocessos e Engenharia Bioquimica
Biorreatores e Fermentacao
141
Cinetica de Monod (Crescimento Microbiano)
FUNDAMENTAL
mu_Monod = mu_max * S / (Ks + S)
Taxa especifica de crescimento de microrganismo em funcao de substrato limitante S; Ks=constante de meia saturacao; identica a Michaelis-Menten.
ORIGEM J. Monod, 1942 - Recherches sur la Croissance des Cultures Bacteriennes (Nobel 1965)
▶ E.coli: mu_max=1,5/h; Ks=0,01 g/L; S=1 g/L: mu=1,5*1/(0,01+1)=1,49/h (praticamente max)

142
Equacao de Balanco de Massa em Biorreator CSTR
INTERMEDIARIO
dX_dt = mu_Monod * X_bm - D_dil * X_bm
Biomassa X em quemostato; D_dil=F/V=taxa de diluicao; estado estacionario quando mu=D_dil; washout quando D_dil>mu_max; base de fermentadores continuos.
ORIGEM Herbert, Elsworth & Telling, 1956; Pirt, 1975 - Principles of Microbe and Cell Cultivation
▶ Producao de antibiotic em quemostato: D_dil otimizado para maximizar produtividade volumetrica D*X

143
Fator de Rendimento Biomassa/Substrato
FUNDAMENTAL
YX_S = delta_X / delta_S
Rendimento de conversao de substrato em biomassa; YX_S=0,4-0,5 g_biomassa/g_glicose (aerobico); YX_S=0,1 (anaerobico); base de dimensionamento de biorreatores.
ORIGEM Pirt, 1975 - Principles of Microbe and Cell Cultivation
▶ Fermentador de levedura aerobico: YX_S=0,5; 100 kg de glicose -> 50 kg de biomassa seca

144
Transferencia de Oxigenio em Biorreator (kLa)
INTERMEDIARIO
dC_O2_dt = kLa * (C_star_O2 - C_O2) - qO2 * X_bm
Balanco de oxigenio em biorreator; kLa=coeficiente volumetrico; C_star=saturacao; qO2=taxa especifica de consumo; kLa target: >200/h em aplicacoes intensivas.
ORIGEM Perez et al., 2006 - Biochemical Engineering Journal; kLa em biorreatores
▶ Fermentador de 10 m3: kLa=150/h com agitacao de 3 W/L; O2 suprido por borbulhamento de ar

145
Producao de Produto Acoplada / Nao Acoplada a Crescimento
INTERMEDIARIO
dP_dt = alpha_lp * dX_dt + beta_lp * X_bm
Modelo de Luedeking-Piret; alfa_lp=coeficiente acoplado a crescimento, beta_lp=nao acoplado; acido lactico: alfa alto; penicilina: alfa=0, beta>0.
ORIGEM Luedeking & Piret, 1959 - Journal of Biochemical and Microbiological Technology
▶ Producao de penicilina: correlacao com fase estacionaria de crescimento; base de estrategia de fed-batch

146
Coeficiente de Manutencao Microbiana
INTERMEDIARIO
ms_m = mu_Monod / YX_S_max + m_maint
Taxa especifica de consumo de substrato para manutencao; m_maint=0,01-0,1 g_subst/(g_bm*h); relevante a baixas mu (biorreatores de longa operacao).
ORIGEM Pirt, 1965 - Proceedings of the Royal Society London
▶ E.coli a mu=0,05/h: 30-50% do substrato para manutencao; afeta rendimento YX_S observado

147
Consumo de Potencia em Biorreator Aerado
AVANCADO
P_V = N_imp^3 * D_imp^5 * rho_broth / V_react
Potencia de agitacao por volume; tipicamente 1-5 kW/m3 em fermentadores aerobios; trade-off entre kLa e stress mecanico de celulas de mamifero.
ORIGEM Rushton, Costich & Everett, 1950 - Chemical Engineering Progress
▶ Biorreator de 10 L, N=300 rpm com impedor Rushton: P/V=2 kW/m3; kLa=180/h

148
pH e Tampao em Biorreatores (Henderson-Hasselbalch)
FUNDAMENTAL
pH_buf = pKa_buf + log(A_buf / HA_buf)
Equacao de Henderson-Hasselbalch para tampao; pKa de fosfato=7,2; CO2/bicarbonato tampona meios de celulas de mamifero; ajuste por adicao de NH4OH/HCl.
ORIGEM Henderson, 1908; Hasselbalch, 1916 - Biochemische Zeitschrift
▶ Biorreator CHO: pH controlado em 7,0-7,4 por adicao de CO2 e base; afeta produtividade e glicosilacao de anticorpos

149
Esterilizacao de Biorreator (Criterio de Nabla)
INTERMEDIARIO
nabla_ster = sum(k_ster * exp(-E_a_ster / (R_gas * T)) * dt)
Criterio de esterilizacao nabla (Del); nabla=12 corresponde a probabilidade de sobrevivencia de 1e-12; base de validacao de ciclos de esterilizacao CIP/SIP.
ORIGEM Del, 1949; Deindorfer & Humphrey, 1959 - Industrial Engineering Chemistry
▶ Biorreator farmaceutico: nabla=12 garante nivel de asseguracao de esterilidade SAL=1e-6

150
Inibicao de Produto em Fermentacao (Andrew)
INTERMEDIARIO
mu_inh = mu_max * S / (Ks + S) * (1 - P_prod / P_max)^n_inh
Inibicao de produto por Andrew; P_max=concentracao maxima tolerada; fermentacao de etanol: P_max=100 g/L; inibicao relevante em producao de bioetanol.
ORIGEM Andrews, 1968; inhibition de P em fermentacao de etanol
▶ Levadura industrial: P_max=110 g/L; mu reduzida 50% a P=55 g/L; limite de producao de bioetanol

Engenharia de Downstream e Bioprocessamento
Separacao e Purificacao
151
Retencao de Membrana de Ultrafiltracao
INTERMEDIARIO
R_memb = 1 - C_perm / C_feed
Rejeicao de membrana; R=0,9: 90% de retencao; alvos: >0,99 para IgG em UF/DF; base de dimensionamento de cassetes de membrana.
ORIGEM Michaels, 1968; Porter, 1972 - Membrane filtration
▶ Membrana de 30 kDa retendo IgG (150 kDa): R=0,99; passagem de solucao tampao para diafiltração

152
Balanco de Massa de Produto em Biorreator
INTERMEDIARIO
QP_prod = mu_Monod * X_bm * YP_X
Produtividade volumetrica de produto; YP_X=rendimento produto/biomassa; maximizada pelo ponto em estrategia de fed-batch otimizado.
ORIGEM Nielsen & Villadsen, 1994 - Bioreaction Engineering Principles
▶ CHO para anticorpo: X=5e6 celulas/mL; q_P=20 pg/(celula*dia); QP=100 mg/(L*dia)

153
Concentracao Critica de Oxigenio Dissolvido
FUNDAMENTAL
C_star_O2 = K_H * p_O2
Solubilidade de O2 por lei de Henry; K_H(agua)=1,26 mmol/(L.atm) a 37C; pO2=0,21 atm: C_star=0,26 mmol/L; DO critico para metabolismo aerobico: >20%.
ORIGEM Wileman et al., 1991 - Biotechnology and Bioengineering
▶ Celulas CHO: DO critico=10-20% saturacao; abaixo disso: metabolismo anaerobico e lactato acumula

154
Cinetica de Haldane (Inibicao por Substrato)
AVANCADO
mu_Haldane = mu_max * S / (Ks + S + S^2 / Ki_sub)
Inibicao por alto substrato; Ki_sub=constante de inibicao; relevante para fenol, tolueno, amonia; mu maxima em S_opt=sqrt(Ks*Ki_sub).
ORIGEM Andrews, 1968 - Biotechnology and Bioengineering
▶ Degradacao de fenol: Ki=150 mg/L; S_opt=15 mg/L; acima disso mu cai; base de biorreatores de remediacão

155
Pressao Osmotica e Tonicicidade
INTERMEDIARIO
pi_osm = i_vant * c_mol * R_gas * T
Pressao osmotica; i_vant=fator de dissociacao (NaCl=2); solucao fisiologica 0,9% NaCl: pi=7,6 atm=290 mOsm; afeta viabilidade celular em bioprocessamento.
ORIGEM van't Hoff, 1887 (Nobel 1901) - Zeitschrift für Physikalische Chemie
▶ Hiperosmolaridade (>350 mOsm): estresse celular em CHO; pode aumentar produtividade mas reduz viabilidade

156
Estabilidade de Enzima - Inativacao Termica
INTERMEDIARIO
E_t = E0_enz * exp(-k_d_enz * t)
Inativacao enzimatica de 1a ordem; k_d_enz dobra a cada 8-12C (regra de Arrhenius); base de projeto de temperatura otima de bioprocesso e shelf-life.
ORIGEM Segel, 1975 - Enzyme Kinetics; estabilidade de lisozima
▶ Pectinase a 55C: k_d=0,02/h; t1/2=35h; ajuste de temperatura para processo de 8h com retencao de 90%

157
Numero de Pratos Teoricos em Cromatografia
FUNDAMENTAL
N_plat = 16 * (tR / w_peak)^2
Eficiencia cromatografica; tR=tempo de retencao; w_peak=largura do pico; HPLC analitica: N>10000; purificacao por proteina A: N=500-2000.
ORIGEM Martin & Synge, 1941 (Nobel 1952) - Biochemical Journal
▶ Coluna HPLC C18 de 15 cm: N=12000; resolucao Rs>1,5 para anticorpos monoclonais

158
Equacao de Van Deemter (Altura de Prato)
INTERMEDIARIO
H_VD = A_ED + B_ED / u_vel + C_ED * u_vel
Altura equivalente de prato teorico; A_ED=difusao en espiral, B_ED=difusao longitudinal, C_ED=transferencia de massa; u_vel otima minimiza H.
ORIGEM Van Deemter, Zuiderweg & Klinkenberg, 1956 - Chemical Engineering Science
▶ Coluna de proteina A: H minima a u=0,5 mL/min; acima: transferencia de massa limita N

159
Fed-Batch Exponencial
INTERMEDIARIO
F_fed = mu_set * X0_bm * V0_bm * exp(mu_set * t) / (YX_S_fb * S_feed)
Vazao de alimentacao exponencial; mu_set=taxa de crescimento definida; YX_S_fb=rendimento; S_feed=concentracao do feed; maximiza producao de produto.
ORIGEM Reuveny, 1989 - Biotechnology and Bioengineering; fed-batch em CHO
▶ Producao em CHO: mu_set=0,03/h; crescimento controlado ate 10e6 celulas/mL em 10 dias

160
Equilibrio de Particao (Extracao Aquosa Bifasica)
INTERMEDIARIO
K_ATPS = C_top / C_bottom
Coeficiente de particao de proteina em sistema biifasico PEG-sal; K>10: concentracao na fase superior; otimizado por tipo de PEG e concentracao de sulfato.
ORIGEM Albertsson, 1960 - Partition of Cell Particles and Macromolecules
▶ IgG em PEG-6000/sulfato: K=15; pureza >90% em passo unico; escalonavel ate 10 m3

""";
    }
}
