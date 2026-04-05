namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol17Parte4 = """
Sistemas de Energia Eletrica
Potencia e Distribuicao
241
Potencia Aparente e Fator de Potencia
FUNDAMENTAL
cos_phi = P_real / sqrt(P_real^2 + Q_react^2)
Fator de potencia; P=potencia ativa (W); Q=reativa (VAR); S=aparente (VA); fp=P/S; banco de capacitores corrige fp para minimizar perdas na rede.
ORIGEM Steinmetz, 1888; IEC 60038; ISO 50001
▶ Motor de 10 kW com fp=0,8: S=12,5 kVA; I=S/V=54,3 A (vs 43,5 A com fp=1); mais perdas na linha

242
Transferencia Maxima de Potencia em Linha
INTERMEDIARIO
P_max = abs_V1 * abs_V2 * sin(delta_angle) / X_line
Potencia ativa maxima em linha com reatancia X; delta=angulo de carga; delta_max=90 (limite estatico); base de analise de estabilidade de sistemas eletricos.
ORIGEM Stevenson, 1982 - Elements of Power System Analysis
▶ Linha de 230 kV, X=50 ohm, V1=V2=230 kV: P_max=230^2/50=1058 MW a delta=90 graus

243
Custo Marginal de Despacho Economico
INTERMEDIARIO
lambda_MC = dC1_dP1
Lambda=custo marginal igualado entre todas as usinas; despacho economico minimiza custo total sujeito a restricoes de balanco de potencia; base de mercados de energia.
ORIGEM Wood & Wollenberg, 1996 - Power Generation, Operation and Control
▶ Termoeletrica linear: C=a+b*P; lambda=b=custo marginal; igualado entre usinas pelo ODE (operador)

244
Regulacao de Frequencia (Droop)
FUNDAMENTAL
delta_f = -R_droop * delta_P
Queda de frequencia por desvio de carga; R_droop=coeficiente de droop (1-5%); regulacao primaria mantém frequencia; complementada por regulacao secundaria (AGC).
ORIGEM Illic & Zaborzsky, 2000; NERC PRC-024
▶ Sistema de 60 Hz; R=4%; delta_P=0,1 pu; delta_f=-0,04*0,1*60=-0,24 Hz; retorna a 59,76 Hz

245
Custo Nivelado de Energia (LCOE)
INTERMEDIARIO
LCOE = (CAPEX + OPEX_total) / E_lifetime
Custo nivelado de energia; CAPEX=investimento inicial; OPEX=custo operacional; E=energia gerada na vida util; base de comparacao entre tecnologias energeticas.
ORIGEM IEA, IRENA, NREL - calculo de LCOE por tecnologia
▶ Solar fotovoltaico utilidade: LCOE=20-40 USD/MWh (2023); gas natural: 40-80 USD/MWh; eolico: 25-50

246
Potencia de Turbina Eolica (Betz)
FUNDAMENTAL
P_wind = 0.5 * rho_air * A_rotor * v_wind^3 * Cp_betz
Potencia extraida do vento; Cp_betz<0.593 (limite de Betz); turbinas modernas: Cp=0,45; base de dimensionamento de parques eolicos.
ORIGEM A. Betz, 1920 - Das Maximum der theoretisch möglichen Ausnutzung (Nobel Fisica 1961 Betz nao)
▶ Turbina de 5 MW: D=126 m, A=12469 m2, v=12 m/s, rho=1,2; Cp=0,45: P=0,5*1,2*12469*12^3*0,45=5,8 MW

247
Estado de Carga de Bateria (SoC)
FUNDAMENTAL
SoC = SoC0 + eta_ch * I_batt * dt / C_nom
SoC de bateria por integracao de corrente (Coulomb counting); eta_ch=eficiencia de carregamento; C_nom=capacidade nominal; complementado por EKF para precisao.
ORIGEM Plett, 2004 - Journal of Power Sources; BMS de veiculos eletricos
▶ Bateria NMC 100 Ah; carregando a 50 A por 1 h com eta=0,98: delta_SoC=0,98*50*1/100=0,49 (49%)

248
Eficiencia de Transformador com Perdas
INTERMEDIARIO
eta_transf = P_out / (P_out + P_Fe + k_load^2 * P_Cu)
Eficiencia de transformador; P_Fe=perdas no ferro (constante); P_Cu=perdas no cobre a plena carga; k_load=fracao de carga; maxima eficiencia: k_load=sqrt(P_Fe/P_Cu).
ORIGEM Chapman, 2005 - Electric Machinery Fundamentals; ABNT NBR 5356
▶ Trafo 100 kVA: P_Fe=300W, P_Cu=2000W; maxima eta em k=sqrt(300/2000)=0,387=38,7% de carga

249
Queda de Tensao em Linha de Distribuicao
FUNDAMENTAL
delta_V_pct = (P_load * R_line + Q_load * X_line) / V_nom^2 * 100
Queda de tensao percentual; limite tipico: 5% (ANEEL REN 505); base de dimensionamento de condutores e localizacao de bancos de capacitores.
ORIGEM ANEEL PRODIST Modulo 8; IEC 60364-5-52
▶ Feeder de 4 km, R=0,25 ohm/km, P=500 kW, Q=250 kVAR, V=13,8 kV: delta_V=2,8% (aceitavel)

250
Corrente de Curto-Circuito (Thevenin)
INTERMEDIARIO
I_cc = V_pre / Z_Thevenin
Corrente de curto-circuito de Thevenin; V_pre=tensao pre-falta; Z_Thevenin=impedancia de Thevenin; base de dimensionamento de disjuntores e SCF em SEP.
ORIGEM Stevenson, 1982; IEC 60909
▶ Barramento de 13,8 kV; Z_th=0,5+j2 ohm: I_cc=7967/(2,06)=3867 A; disjuntor de 5 kA necessario

Genetica Molecular e Genomica
Tecnicas Moleculares
251
Amplificacao por PCR (Quantificacao)
FUNDAMENTAL
N_PCR = N0 * (1 + E_pcr)^n_cycles
Numero de copias apos n ciclos; E_pcr=eficiencia (0 a 1); PCR ideal E=1: duplica a cada ciclo; quantificacao por qPCR via curva threshold.
ORIGEM K.B. Mullis, 1983 (Nobel 1993) - Science; qPCR: Higuchi et al., 1993
▶ PCR ideal com 30 ciclos: N=N0*2^30=1e9 copias; qPCR: Ct determina concentracao inicial

252
Profundidade de Sequenciamento (Coverage)
INTERMEDIARIO
Cov = L_read * N_reads / G_genome
Cobertura media de sequenciamento; 30x: genomica padrao; 100x: cancer; L_read=150bp (Illumina), G_genome=3e9bp humano; N_reads para 30x: 600e6 reads.
ORIGEM Lander & Waterman, 1988 - Genomics; Illumina HiSeq, 2010
▶ Genoma humano 30x: L=150bp, N=600e6; Cov=150*600e6/3e9=30x; maior coverage reduz erros

253
Fold-Change de Expressao Genica (Log2FC)
FUNDAMENTAL
log2FC = log(TPM_treat / TPM_ctrl) / log(2)
Log2 fold-change de expressao; log2FC>1: 2x upregulado; log2FC<-1: 2x downregulado; com p-adj<0,05 e |log2FC|>1: gene diferencialmente expresso.
ORIGEM DESeq2 (Love et al., 2014); edgeR (Robinson et al., 2010)
▶ TP53 em celulas cancerosas vs normais: log2FC=-2,5; 5,7x subexpressado; oncogenese

254
Eficiencia de Edicao por CRISPR-Cas9
INTERMEDIARIO
Eff_edit = Eff_NHEJ + Eff_HDR
Eficiencia total de edicao; NHEJ (reparacao nao-homologa): maior eficiencia (~50%); HDR (reparo diretivo): menor eficiencia (~15% com template); base de terapias genicas.
ORIGEM Jinek et al., 2012 - Science; Zhang Lab, Broad Institute
▶ NHEJ knock-out: Eff=30-50%; HDR para precisa correcao: Eff=5-20%; celulas de divisao lenta (neuronios): menor HDR

255
Frequencias de Hardy-Weinberg
FUNDAMENTAL
freq_AA = p_HW^2
Frequencia de genotipo AA em populacao em equilíbrio; p_HW=frequencia allelica A; (p+q)^2=p^2+2pq+q^2=1; base de genetica populacional e triagem de portadores.
ORIGEM Hardy, 1908 - Science; Weinberg, 1908 - Jahreshefte des Vereins fur vaterlandische Naturkunde
▶ Alelo recessivo q=0,01 (1%): portadores 2pq=0,0198 (1,98%); afetados q^2=0,0001 (1 em 10000)

256
Escore de Risco Poligenico (PRS)
AVANCADO
PRS = beta1_snp * G1_snp + beta2_snp * G2_snp
Escore poligenico; beta_i=efeito do SNP i do GWAS; G_i=genotipos 0,1 ou 2; PRS prediz risco de doenca complexa (DCV, diabetes, cancer); precisao limitada por ancenstralidade.
ORIGEM Purcell et al., 2009 - PLINK; Polygenic Risk Score Consortium
▶ PRS de DCV: decil superior tem risco 3-5x maior que decil inferior; base de medicina de precisao

257
Distancia de Jukes-Cantor (Evolucao Molecular)
INTERMEDIARIO
d_JC = -3 / 4 * ln(1 - 4 * p_dist / 3)
Distancia genetica de Jukes-Cantor corrigindo para substituicoes multiplas; p_dist=proporcao de sitios diferentes; base de reconstrucao de arvores filogeneticas.
ORIGEM Jukes & Cantor, 1969 - Mammalian Protein Metabolism
▶ Dois genes com 20% de diferenca: p=0,2; d=-0,75*ln(1-4*0,2/3)=0,75*ln(0,733)=0,232

258
Desequilíbrio de Ligacao (r2)
INTERMEDIARIO
r2_LD = D_LD^2 / (p_A * q_A * p_B * q_B)
r2 de desequilíbrio de ligacao entre variantes A e B; r2=1: associacao perfeita (em bloco haplotipico); r2<0,3: independente; base de GWAS e imputacao genotipica.
ORIGEM Hill & Robertson, 1968 - Theoretical and Applied Genetics; HapMap Project
▶ Dois SNPs em desequilíbrio r2=0,8: um pode ser proxy do outro em GWAS; base de chips de genotipagem

259
Taxa de Sinonimos/Nao-Sinonimos (dN/dS)
INTERMEDIARIO
omega_dNdS = dN / dS
Razao de substituicoes nao-sinonimas/sinonimas; omega<1: selecao purificadora; omega=1: neutra; omega>1: selecao positiva; detecta proteinas em evolucao adaptativa.
ORIGEM Nei & Gojobori, 1986 - Molecular Biology and Evolution; Yang & Nielsen, 2000
▶ Gene de cepa viral nova: omega=3,5 (selecao positiva intensa); gene essencial conservado: omega=0,05

260
Indice de Uso Preferencial de Codons (CAI)
AVANCADO
CAI = w_codon^(1 / L_seq)
Indice de adaptacao de codons; w_codon=frequencia relativa de sinonimo; CAI de 0 a 1; CAI alto = gene translacionalmente otimizado; base de design de sequencias para expressao.
ORIGEM Sharp & Li, 1987 - Nucleic Acids Research
▶ CAI de genes ribossomicos de E.coli: CAI=0,95; genes raros: CAI=0,2; expressao heterologa otimizada

Termodinamica e Fluidos em Processos Quimicos
Transferencia de Calor e Processos
261
Media Logaritmica de Diferenca de Temperatura (LMTD)
FUNDAMENTAL
LMTD = (dT1 - dT2) / ln(dT1 / dT2)
dT1 e dT2=diferencas de temperatura nas extremidades; Q=U*A*LMTD; base de especificacao de area de trocadores de calor; valida para contracorrente e cocorrente.
ORIGEM Nusselt, 1911; trocadores de calor tubulares e de placas
▶ Agua quente 80->50C resfriando oleo 20->40C (contracorrente): dT1=60C, dT2=30C; LMTD=43,3C

262
Coeficiente Global de Transferencia de Calor
INTERMEDIARIO
U_overall = 1 / (1/h1 + Rf1 + e_wall/k_wall + Rf2 + 1/h2)
U consolidado de resistencias em serie; h1,h2=coeficientes convectivos; Rf=incrustacao; e/k=parede; tipico: U=500-2000 W/(m2*K) em trocadores de liquido-liquido.
ORIGEM Bergman et al., 2011 - Fundamentals of Heat and Mass Transfer
▶ Trocador agua-agua: h1=h2=5000 W/(m2.K); parede de aco 3mm; U=2326 W/(m2.K) sem incrustacao

263
Numero de Unidades de Transferencia (NTU)
INTERMEDIARIO
NTU = U * A_HE / C_min
Efetividade epsilon=(1-exp(-NTU))/(1+C_min/C_max) para paralelo; base de dimensionamento de trocadores compactos; epsilon aumenta assintoticamente com NTU.
ORIGEM Kays & London, 1984 - Compact Heat Exchangers
▶ HE com NTU=3, C_r=0,5 (contracorrente): epsilon=0,86; recupera 86% da energia disponivel

264
Transferencia de Calor por Radiacao
FUNDAMENTAL
q_rad = epsilon_r * sigma_SB * A_rad * (T1^4 - T2^4)
Lei de Stefan-Boltzmann; epsilon_r=emissividade (1 para corpo negro); sigma_SB=5,67e-8 W/(m2*K4); dominante em fornos e foguetes (alta temperatura).
ORIGEM J. Stefan, 1879; L. Boltzmann, 1884
▶ Corpo negro a 1000K: q/A=5,67e-8*1000^4=56700 W/m2; aco oxidado a 900K: epsilon=0,8; q=33300 W/m2

265
Pressao de Vapor - Equacao de Antoine
FUNDAMENTAL
log(P_vap) = A_ant - B_ant / (C_ant + T)
Pressao de vapor por Antoine; coefficients de NIST; P em kPa ou mmHg; base de calculo de equilíbrio vapor-liquido e destilacao.
ORIGEM C. Antoine, 1888 - Comptes Rendus; NIST Webbook
▶ Agua: A=8,07, B=1730, C=233; T=100C: log(P)=8,07-1730/333=2,87; P=741 mmHg=98,8 kPa (aprox 1 atm)

266
Eficiencia de Turbina a Vapor Isentropica
FUNDAMENTAL
eta_turb = (h1 - h2) / (h1 - h2s)
Eficiencia isentropica da turbina; h2s=entalpia a saida ideal isentropica; tipicamente 0,85-0,92 para turbinas de vapor de alta pressao; base de analise de ciclos Rankine.
ORIGEM Cengel & Boles, 2014 - Thermodynamics: An Engineering Approach
▶ Turbina de 10 MPa a 600C com saida a 10 kPa: h1=3625, h2s=2099, h2=2313 kJ/kg; eta=0,85

267
Coeficiente de Performance (COP) de Refrigerador
FUNDAMENTAL
COP_ref = T_L / (T_H - T_L)
COP ideal de Carnot para refrigeracao; T_L=temperatura da fonte fria, T_H=quente (Kelvin); COP real de arco-condicionado: 2-5; COP de bomba de calor=COP+1.
ORIGEM N.L.S. Carnot, 1824; Clausius, 1850
▶ Refrigerador de -20C (253K) a 30C (303K): COP_Carnot=253/50=5,06; COP real (65% Carnot)=3,3

268
Numero de Rayleigh (Conveccao Natural)
INTERMEDIARIO
Ra = g_grav * beta_exp * delta_T * L^3 / (nu_kin * alpha_therm)
Numero de Rayleigh; Ra>10^9: turbulencia na camada limite natural; h=0,59*k/L*Ra^0.25 (regime laminar); base de resfriamento passivo de paineis e eletronicos.
ORIGEM Lord Rayleigh, 1916; Churchill & Chu, 1975
▶ Painel de 1m vertical com delta_T=50C: Ra=9,8*0,0033*50*1/(1,6e-5*2,2e-5)=4,6e9; conveccao turbulenta

269
Metodo de McCabe-Thiele (Destilacao)
INTERMEDIARIO
y_op = (L_ref / V_ref) * x_op + (D_ref / V_ref) * x_D
Linha de operacao por balanco de massa em destilacao; L_ref,V_ref=vazoes internas; x_D=composicao do destilado; numero de pratos por construcao grafica.
ORIGEM Warren McCabe & Ernest Thiele, 1925 - Industrial Engineering Chemistry
▶ Destilacao de etanol-agua: R_min=0,77; pratos teoricos: 30 para 95% de pueza; eficiencia de prato: 65%

270
Eficiencia de Bomba Hidraulica
FUNDAMENTAL
eta_pump = rho_f * g_grav * H_pump * Q_flow / P_shaft
Eficiencia de bomba centrifuga; tipicamente 0,7-0,9; cuva caracteristica H-Q; potencia no eixo P_shaft da motor eletrico; base de selecao por curvas do fabricante.
ORIGEM Kaplan, 1917; Hydraulic Institute Standards; ISO 9906
▶ Bomba de 300 L/min, H=50m, eta=0,75; P_shaft=1000*9,81*50*0,005/0,75=3270 W=3,3 kW

Quimica Analitica e Espectroscopia
Tecnicas Analíticas
271
Lei de Beer-Lambert (Absorbancia)
FUNDAMENTAL
A_abs = epsilon_ext * c_conc * l_path
Absorbancia; epsilon_ext=absortividade molar (M-1.cm-1); c_conc=concentracao (M); l_path=caminho otico (cm); base de espectroscopia UV-VIS, ELISA e LOD.
ORIGEM Beer, 1852; Lambert, 1760; IUPAC recomendacoes
▶ ELISA: A450nm de HRP vs concentracao linear; LOD de 1 ng/mL por calibracao com curva padrao

272
Deslocamento Quimico em RMN (NMR)
FUNDAMENTAL
delta_NMR = (nu_sample - nu_TMS) / nu_spectro * 1000000
Deslocamento quimico em partes por milhao (ppm) vs TMS; 1H-RMN: carbonil em ~200ppm (13C); aromatic em 7-8ppm; base de elucidacao estrutural de moleculas organicas.
ORIGEM E.M. Purcell & F. Bloch, 1946 (Nobel 1952) - Physical Review; RMN multidimensional: Jeener, 1971
▶ Benzeno: delta_H=7,27 ppm; acetona carbonil: delta_C=207 ppm; NMR identifica funcionalidades quimicas

273
Numero de Pratos em HPLC (Eficiencia Cromatografica)
FUNDAMENTAL
N_HPLC = 16 * (tR / w_base)^2
Eficiencia de coluna HPLC; tR=tempo de retencao; w_base=largura da base do pico; N>10000 para separacao de compostos similares; base de validacao de metodos.
ORIGEM Martin & Synge, 1941 (Nobel 1952); van Deemter, 1956
▶ Coluna Zorbax C18 de 25cm*4,6mm: N=15000; resolucao Rs>1,5 entre picos adjacentes

274
Potencial de Nernst (Eletrodo)
FUNDAMENTAL
E_Nernst = E0_elec - R_gas * T / (n_elec * F_faraday) * ln(Q_rxn)
Potencial de eletroodo por atividades das especies; E0_elec=potencial padrao; F_faraday=96485 C/mol; base de potenciometria e ISE de ions especificos.
ORIGEM W. Nernst, 1889 (Nobel 1920) - Zeitschrift für Physikalische Chemie
▶ Eletrodo de Ag/AgCl a 25C: E=0,222-0,0257*ln([Cl-]); ISE de fluoreto mede F- em rejeito industrial

275
Limite de Deteccao (LOD)
FUNDAMENTAL
LOD = 3 * sigma_blank / S_sens
LOD=3 sigma do branco dividido pela sensibilidade da calibracao; LOQ=10*sigma/S; parametro de validacao de metodo analitico segundo IUPAC e FDA.
ORIGEM IUPAC Analytical Chemistry Division; FDA Guidance, 2018
▶ Metodo de Pb2+ por AAS: sigma_blank=0,005 absorbancia; S=0,1/ppm; LOD=0,15 ppb Pb

276
Espectrometria de Massa - Razao m/z
FUNDAMENTAL
mz_ratio = M_mol / (z_charge * m_proton)
Razao massa/carga; m_proton=1,00728 Da; [M+H]+: m/z=(M+1,008)/1; base de identificacao de compostos por ESI-MS e MALDI em proteomics e metabolomics.
ORIGEM JJ Thomson, 1913 (Nobel 1906); ESI: Fenn (Nobel 2002); MALDI: Karas et al., 1985
▶ Proteina de 12000 Da com z=10: m/z=1201,07; espectro de ESI-MS mostra envelope de cargas multiplas

277
Calorimetria Diferencial de Varredura (DSC)
INTERMEDIARIO
delta_H_DSC = area_peak * scan_rate
Entalpia de transicao por integracao do pico de DSC; delta_H de fusao ou desnaturacao proteica medido em J/g ou J/mol; base de analise termica de polimeros e farmacos.
ORIGEM Watson & O'Neill, 1966 - Analytical Chemistry; TA Instruments DSC Q2000
▶ Proteina terapeutica: Tm=72C (pico endotermico); delta_H=300 J/g; relevante para estabilidade de biofarmacos

278
Analise Termogravimetrica (TGA) - Perda de Massa
FUNDAMENTAL
delta_m_pct = (m0 - m_T) / m0 * 100
Perda de massa percentual na TGA; temperatura de decomposicao (Td); base de analise de pureza de polimeros, carbonizacao e estabilidade termica de materiais.
ORIGEM Duval, 1953; Coats & Redfern, 1964 - Nature
▶ Nanocomposito de grafeno em PET: TGA mostra silica a 800C; teor de grafeno calculado por subtracao

279
Resolucao Cromatografica (Rs)
FUNDAMENTAL
Rs_chrom = 2 * (tR2 - tR1) / (w1 + w2)
Resolucao cromatografica; Rs>1,5: separacao completa (baseline); Rs=1,0: 98% separado; Rs<0,6: picos sobrepostos; impacta pureza em producao de farmacos.
ORIGEM Snyder, Kirkland & Dolan, 2010 - Introduction to Modern Liquid Chromatography
▶ Dois enantiomeros em coluna quiral: Rs=1,8; separa farmaco ativo de enantiomero inativo

280
Rendimento Quantico de Fluorescencia
INTERMEDIARIO
Phi_F = k_radiative / (k_radiative + k_nonrad)
Rendimento quantico de fluorescencia; k_radiative=taxa radiativa; k_nonrad=taxa nao radiativa; fluorescencia ideal: Phi=1,0; FITC: Phi=0,92; base de microscopia de fluorescencia.
ORIGEM Weber, 1949; Lakowicz, 2006 - Principles of Fluorescence Spectroscopy
▶ GFP: Phi=0,79; cy3: Phi=0,15; base de escolha de corante para microscopias de superresolucao

Modelagem Climatica e Geoprocessamento
Sensoriamento Remoto e SIG
281
Forcante Radiativa Atmosferica (Geoprocessamento)
INTERMEDIARIO
dF_atm = 5.35 * ln(C_atm / C_preindustrial)
Forcante radiativa aplicada em modelos de SIG para calculao de anomalia de calor regional; base de downscaling de modelos climaticos.
ORIGEM Myhre et al., 1998; aplicado em modelos de downscaling regional
▶ Downscaling de forcante de CO2 para celula de grade de 1km: base de modelos regionais de clima

282
Temperatura de Equilíbrio por SIG
INTERMEDIARIO
T_equil = ((1 - alpha_SIG) * S0_SIG / (4 * eps_SIG * sigma_SB))^0.25
Temperatura de equilíbrio calculada por SIG para cada pixel de imagem de satelite; base de analise de ilhas de calor urbanas.
ORIGEM MODIS land surface temperature; Wan & Dozier, 1996
▶ LST de MODIS: pixel de floresta 28C; pixel urbano 38C; ilha de calor de 10C em sao paulo

283
Indice NDVI (Vegetacao por Satelite)
FUNDAMENTAL
NDVI = (NIR_band - Red_band) / (NIR_band + Red_band)
Indice de diferenca normalizada de vegetacao; NDVI=(-1,1); floresta densa: 0,7-0,9; area urbana: 0,1-0,2; solo nu: -0,1; base de monitoramento de biomassa.
ORIGEM Rouse et al., 1974 - Third ERTS Symposium; MODIS NDVI dataset
▶ Desmatamento na Amazonia: NDVI cai de 0,8 para 0,2; monitorado por PRODES (INPE) em 30m resolucao

284
Sensibilidade Climatica por Feedback de SIG
INTERMEDIARIO
ECS_grid = dF_2xCO2_grid / lambda_fb_grid
Sensibilidade climatica de equilibrio calculada por celula de grade em modelos regionais; base de mapas de vulnerabilidade a mudanca climatica.
ORIGEM CORDEX Regional Climate Models; IPCC AR6 Chapter 10
▶ Nordeste brasileiro: ECS regional = 3,5C por 2xCO2; seca mais intensa que media global

285
Numero de Rossby (Dinamica Atmosferica)
INTERMEDIARIO
Ro_Rossby = U_flow / (f_coriolis * L_scale)
Razao de forca inercial/Coriolis; Ro<<1: rotacao domina (ciclones); Ro~1: transicao; Ro>>1: dinamica nao rotacional (tornados e granizo).
ORIGEM C.G. Rossby, 1939 - Journal of Marine Research
▶ Ciclone tropical: U=50m/s, f=1e-4/s, L=200km: Ro=50/(1e-4*2e5)=2,5; transicao para nao-geostrofico

286
CAPE (Energia Potencial Convectiva Disponivel)
AVANCADO
CAPE = g_grav * delta_z * (T_parcel - T_env) / T_env
CAPE por camada simplificada; CAPE>1000 J/kg: severamente instavel; base de previsao de tempestades severas, tornados e granizo.
ORIGEM Doswell & Rasmussen, 1994 - Weather and Forecasting
▶ CAPE=3000 J/kg: supercell thunderstorm potencial; CAPE=0: atmosfera estavel sem conveccao profunda

287
Variograma Geoestatistico
AVANCADO
gamma_var = 0.5 * mean((Z_h - Z_0)^2)
Variograma experimental; gamma(h) = 0,5 * variancia de pares separados por lag h; base de krigagem para interpol. de dados ambientais esparsos.
ORIGEM D.G. Krige, 1951 - Journal Chemical Mining Society; Matheron, 1963
▶ Mapa de concentracao de nitratos em aquifero: krigagem por variograma reduz incerteza de mapa vs IDW

288
Contribuicao de Geleiras ao SLR por Regiao
INTERMEDIARIO
SLR_reg = SLR_steric + SLR_GIS + SLR_AIS + SLR_glac
Elevacao regional do nivel do mar por componentes; steric (termica), GIS (Groelandia), AIS (Antartica), glaciares; distribuido por fingerprint gravitacional.
ORIGEM Bamber et al., 2019 - Nature; IPCC SROCC, 2019
▶ Costa leste dos EUA: SLR 30% acima da media global por degelo da Groelandia (gravidade) e ajuste glacial isostatico

289
Indice de Oscilacao do Sul (SOI) por SIG
FUNDAMENTAL
SOI_idx = (P_Tahiti - P_Darwin) / sigma_SOI
SOI mede pressao diferencial no Pacifico; SOI negativo: El Nino; positivo: La Nina; influencia precipitacao global via teleconexoes atmosfericas.
ORIGEM Walker & Bliss, 1932 - Memoirs of the Royal Meteorological Society
▶ SOI=-20 (1997-98): super El Nino; seca no Nordeste do Brasil; chuvas excessivas no Pacifico equatorial

290
Temperatura de Superfície Terrestre (LST) por Satelite
INTERMEDIARIO
LST = T_bright / (1 + lambda_TIR * T_bright / rho_c * ln(epsilon_surf))
LST por inversao radiometrica de satelite termal; epsilon_surf=emissividade; T_bright=temperatura de brilho; base de mapas de ilhas de calor e stress hidrico.
ORIGEM Wan & Dozier, 1996 - IEEE TGRS; MODIS-LST Product MOD11
▶ LST urbana vs rural por MODIS: delta_LST=10-15C em sao paulo; relevante para saude publica e energia

Manufatura Avancada e Engenharia de Qualidade
Processos de Fabricacao
291
Taxa de Remocao de Material (MRR) em Usinagem
FUNDAMENTAL
MRR_cut = v_c * f_adv * a_p
Taxa de remocao de material; v_c=velocidade de corte (m/min), f_adv=avanco (mm/volta), a_p=profundidade de corte (mm); base de selecao de condicoes de usinagem.
ORIGEM Taylor, 1907 - ASME Trans.; ISO 3685 - Duracao de ferramenta
▶ Torneamento de aco: v_c=200m/min, f=0,3mm, a_p=2mm: MRR=200*0,3*2=120 cm3/min; rugosidade Ra<1,6um

292
Vida de Ferramenta - Equacao de Taylor
INTERMEDIARIO
T_tool = (C_taylor / v_c)^(1/n_taylor)
Vida de ferramenta de Taylor; n_taylor=0,1-0,4 para ferramentas de HSS; n_taylor=0,4-0,6 para ceramica; C_taylor=constante da ferramenta-material; base ISO 3685.
ORIGEM F.W. Taylor, 1907 - ASME Trans. (On the Art of Cutting Metals)
▶ Fresa de TiAlN; n=0,3; C=500; v_c=200 m/min: T=500/200)^3,33=2,8 min; troca a cada 2,8 min

293
Indice de Capacidade de Processo (Cpk)
FUNDAMENTAL
Cpk = min((USL - mu_proc) / (3 * sigma_proc), (mu_proc - LSL) / (3 * sigma_proc))
Cpk mede alinhamento e variabilidade; Cpk>1,33: processo capaz (6 sigma=1e-9 ppm); Cpk<1,0: processo incapaz; padrao em QMS automotivo (IATF 16949).
ORIGEM Kane, 1986 - Journal of Quality Technology; ISO/TS 16949
▶ Furo de tolerancia +-25um, mu=+5um, sigma=10um: Cpk=min(20/30,30/30)=0,67 (incapaz; precisa de melhoria)

294
Eficiencia Global do Equipamento (OEE)
FUNDAMENTAL
OEE = A_avail * P_perf * Q_qual
OEE=disponibilidade*desempenho*qualidade; OEE>85%: classe mundial; base de TPM e lean manufacturing; perdas de startup, paradas e rejeicoes.
ORIGEM Nakajima, 1988 - Introduction to TPM
▶ A=0,90, P=0,95, Q=0,98: OEE=0,84 (84%); gap para 85%: reduzir paradas nao planejadas

295
Tempo de Ciclo por Demanda de Cliente (Takt Time)
FUNDAMENTAL
Takt = T_available / D_demand
Takt time em segundos/peca; ritmo de demanda do cliente; balanceia celulas de producao; Takt=60s: 1 peca/minuto; base de balanceamento de linha.
ORIGEM Dennis, 2002 - Lean Production Simplified; Toyota Production System
▶ Linha de montagem: T=500 min/dia; demanda=300 pecas/dia; Takt=100 s/peca; cada estacao<=100s

296
Taxa de Construcao em Manufatura Aditiva
INTERMEDIARIO
t_build = V_part / (v_print * h_layer * w_track)
Tempo de construcao em impressao 3D FFF; V_part=volume da peca; v_print=velocidade de impressao; h_layer=espessura de camada; w_track=largura de extrusao.
ORIGEM Gibson, Rosen & Stucker, 2014 - Additive Manufacturing Technologies; ASTM F42
▶ Peca de 5 cm3; v=50mm/s; h=0,2mm; w=0,4mm: t=5000/(50*0,2*0,4)=1250s=20,8 min

297
Numero de Prioridade de Risco (FMEA - RPN)
FUNDAMENTAL
RPN = S_sev * O_occ * D_det
Numero de prioridade de risco em FMEA; S=severidade (1-10), O=ocorrencia (1-10), D=deteccao (inverso: 1=facil); RPN>100: acao prioritaria.
ORIGEM MIL-STD-1629A, 1977; AIAG FMEA-4, 2008; AIAG/VDA FMEA, 2019
▶ Modos de falha de freio: S=9, O=2, D=3; RPN=54 (acao corretiva para S>=8); reduzir O ou D

298
Rugosidade de Superficie em Usinagem (Ra calc)
FUNDAMENTAL
Ra_rug = f_feed^2 / (8 * R_nose)
Ra teorica de torneamento; f_feed=avanco; R_nose=raio do bico da ferramenta; Ra real aprox 1,5-2x maior por vibracoes e desgaste de ferramenta.
ORIGEM Shaw, 2005 - Metal Cutting Principles; ISO 4287
▶ f=0,2mm/rev; R_nose=0,8mm: Ra_th=0,2^2/(8*0,8)=0,0063 mm=6,3 um; Ra real aprox 10 um

299
Disponibilidade de Equipamento (A)
FUNDAMENTAL
A_avail = MTBF / (MTBF + MTTR)
Disponibilidade baseada no MTBF e MTTR; metas: A>0,95 para equipamento critico; base de manutencao centrada em confiabilidade (RCM) e monitoramento preditivo.
ORIGEM Blanchard & Fabrycky, 2011 - Systems Engineering and Analysis; IEC 60300-3-11
▶ CNC com MTBF=500h, MTTR=5h: A=500/505=0,990=99%; parada nao planejada: production loss

300
Forca de Puncionamento em Estamparia
FUNDAMENTAL
F_punch = pi * D_hole * t_sheet * sigma_u * C_shear
Forca de puncionamento; C_shear=coeficiente de cisalhamento (0,6-0,8); sigma_u=resistencia ultima; base de selecao de prensas e projeto de ferramentas de estamparia.
ORIGEM Lange, 1985 - Handbook of Metal Forming; SME Tool and Manufacturing Engineers
▶ Furo de 20mm em chapa de 3mm (sigma_u=400MPa, C=0,7): F=pi*20*3*400*0,7=52,8 kN; prensa de 100 kN

Imunologia Quantitativa e Vacinologia
Imunizacao e Eficacia de Vacinas
301
Limiar de Imunidade de Rebanho
FUNDAMENTAL
p_herd = 1 - 1 / R0
Fracao imune minima para imunidade de rebanho; R0=numero de reproducao basico; sarampo R0=15: p_herd=93%; COVID-19 R0=2,5: p_herd=60%.
ORIGEM Dietz, 1975 - Journal of Royal Statistical Society; SEIR models
▶ Sarampo: R0=15; p_herd=93%; com eficacia de 95%: cobertura vacinal necessaria de 97,9%

302
Eficacia de Vacina (RRR e ARR)
FUNDAMENTAL
VE = 1 - RR
Eficacia de vacina; RR=razao de riscos; VE=(ARV-ARnV)/ARnV onde ARV=incidencia nos vacinados, ARnV=nao vacinados; base de ensaios clinicos fase III.
ORIGEM Farrington, 1992 - Statistics in Medicine; Polack et al., 2020 (BioNTech-Pfizer)
▶ BNT162b2 (Pfizer): ARV=0,035%, ARnV=0,35%; VE=1-0,035/0,35=90% em prevencao de COVID-19

303
Curva de Neutralizacao de Anticorpos (IC50)
INTERMEDIARIO
neutr_pct = 100 / (1 + (IC50_Ab / Ab_conc)^n_hill_Ab)
Percentual de neutralizacao; IC50_Ab=concentracao de anticorpos com 50% de neutralizacao; correlacao de protecao (CoP) usa IC50 como marcador surrogado.
ORIGEM Plotkin, 2010 - Clinical Infectious Diseases; correlates of protection
▶ Soro pos-vacinal com IC50=1:100: protecao estimada de >80% se CoP=IC50; base de aprovacao de vacinas

304
Expansao de Celulas T (Cinetica Clonal)
INTERMEDIARIO
N_Tcell = N0_T * 2^(t_div / tau_div)
Expansao clonal de celulas T apos estimulacao antigenica; tau_div=tempo de divisao (~12h); pico em 7 dias; contracao por apoptose; celulas de memoria persistem.
ORIGEM Murali-Krishna et al., 1998 - Immunity; imunodinâmica
▶ CD8 T especifico: expande de 1 em 1e5 para 1 em 100 celulas do sangue em 7 dias pos-infeccao

305
Eficiencia de Encapsulamento de mRNA (nanoparticula)
INTERMEDIARIO
EE_mRNA = (RNA_total - RNA_free) / RNA_total * 100
Eficiencia de encapsulacao de mRNA em lipid nanoparticle (LNP); EE>90% necessario para vacinas de mRNA; medido por acessibilidade de RiboGreen em surface.
ORIGEM Semple et al., 2010 - Nature Biotechnology; mRNA vacinas COVID-19: Moderna, Pfizer
▶ LNP de mRNA de COVID-19: EE=95%; tamanho hidrodinamico=100 nm; PDI<0,2; estavel a -20C por 6 meses

306
Selecao In Vitro de Anticorpos (SELEX/Phage Display)
AVANCADO
enrich = (Kd_init / Kd_final)^n_rounds
Enriquecimento de anticorpo por rounds de selecao; Kd melhora de uM para pM em 5-10 ciclos; base de desenvolvimento de anticorpos monoclonais terapeuticos.
ORIGEM Smith, 1985 - phage display (Science); SELEX: Ellington & Szostak, 1990
▶ Anticorpo anti-HER2: Kd inicial=1 uM; apos 8 rounds: Kd=0,5 nM (enriquecimento 2000x)

307
Valor Preditivo Positivo (VPP) de Teste de Vacina
INTERMEDIARIO
VPP = sens * prev / (sens * prev + (1 - espec) * (1 - prev))
VPP de teste diagnostico; depende de prevalencia; VPP alto requer especificidade alta em baixa prevalencia; base de avaliacao de testes de immunogenicidade.
ORIGEM Bayes, 1763; Sackett et al., 1985 - Clinical Epidemiology
▶ ELISA de anticorpos com sens=0,99 espec=0,99 a prevalencia=0,01: VPP=0,5 (50% falso positivos)

308
Taxa de Waning de Protecao Vacinal
INTERMEDIARIO
VE_t = VE0 * exp(-k_wane * t_months)
Decaimento de eficacia vacinal ao longo do tempo; k_wane constante de decaimento; BNT162b2: VE cai de 90% para 47% em 6 meses sem reforco.
ORIGEM Tartof et al., 2021 - Lancet; datos de eficacia em mundo real
▶ ChAdOx1: VE0=76%; waning k=0,1/mes; 6 meses: VE=76%*exp(-0,6)=41%; reforco necessario

309
Predicao de Epitopo por HLA (MHC Binding)
AVANCADO
binding_score = K_HLA / (K_HLA + IC50_HLA)
Estimativa de apresentacao de peptideo por MHC; IC50_HLA=concentracao de peptideo com 50% de deslocamento; alelo HLA-A*02:01 apresenta epitopos de influenza e SARS.
ORIGEM Sette & Sidney, 1999 - Immunogenetics; NetMHCpan-4.1
▶ Peptideo GILGFVFTL: IC50=1 nM HLA-A*02:01; forte binder; epIt-opo imunodominante de influenza

310
Citotoxicidade de Celulas CAR-T
INTERMEDIARIO
lise_pct = 100 / (1 + (ET_50 / ET_ratio)^n_car)
Lise de celulas alvo por CAR-T; ET_50=razao E:T com 50% de lise; n_car=coopetividade; CAR-T CD19 CAR: ET50=1:1 em linfoma; base de ensaios de citotoxicidade.
ORIGEM June & Sadelain, 2018 - New England Journal Medicine; CAR-T (Nobel?), 2018
▶ Tisagenlecleucel (Kymriah) CAR-T anti-CD19: 83% de remissao em LLA; ET50 baixo indica alta potencia

Algoritmos e Ciencia da Computacao
Complexidade e Algoritmos Fundamentais
311
Complexidade de Mergesort
FUNDAMENTAL
ops_sort = n_elem * log(n_elem) / log(2)
Mergesort e O(n log n) por divisao recursiva e merge ordenado; ótimo para comparacao de elementos quando ordem e arbitraria; quicksort O(n log n) medio.
ORIGEM J. von Neumann, 1945 - EDVAC Report; Knuth, 1998 - The Art of Computer Programming
▶ Mergesort de 1e6 elementos: ~20e6 comparacoes; bubble sort: 5e11; speedup de 25000x

312
Teorema CAP (Sistemas Distribuidos)
AVANCADO
C_score = C_consist * P_partition
Consistencia x particao: em falha de rede cai-se Consistencia (CP: MongoDB, HBase) ou Disponibilidade (AP: Cassandra, Dynamo); nunca ambos.
ORIGEM E. Brewer, 2000 (PODC); Gilbert & Lynch, 2002 (formal proof)
▶ Dynamo (Amazon): AP system; Cassandra: tune-able entre CP e AP; cassandra com quorum: CP

313
Entropia de Shannon e Codigo de Huffman
FUNDAMENTAL
L_Huffman = sum(p_i * l_code_i)
Comprimento medio de codigo Huffman; minimo quando l_i=-log2(p_i); compressao otima de codigo prefixo; base de JPEG, DEFLATE e GZIP.
ORIGEM C.E. Shannon, 1948 - Bell System; Huffman, 1952 - IRE Proceedings
▶ Texto ingles: H=4,7 bits/char; Huffman atinge 4,8; LZW/DEFLATE: 3,0 (usa contexto)

314
Algoritmo de Dijkstra (Menor Caminho)
FUNDAMENTAL
d_new = d_curr + w_edge
Relaxamento de aresta em Dijkstra; complexidade O((V+E) log V) com heap; garante menor caminho em grafos com arestas positivas; base de GPS e roteamento IP.
ORIGEM E.W. Dijkstra, 1959 - Numerische Mathematik
▶ Grafo de 1000 nos e 5000 arestas: Dijkstra em 30ms; A* com heuristica: 5ms para GPS em cidade

315
Criptografia RSA (Chave Publica)
AVANCADO
c_RSA = m_msg^e_enc
Cifragem RSA: c = m^e mod n; seguranca baseada em dificuldade de fatoracao de n=p*q; RSA-2048: 600 digitos; quebrado por computador quantico de ~4000 qubits logicos.
ORIGEM Rivest, Shamir & Adleman, 1978 - Communications of ACM (RSA); Diffie & Hellman, 1976
▶ RSA-2048: seguro contra classico ate 2030+; pos-quantico: CRYSTALS-Kyber (NIST PQC 2022)

316
Busca Binaria (Algoritmo de Pesquisa)
FUNDAMENTAL
steps_binary = ceil(log(n_db) / log(2))
Numero de passos de busca binaria; O(log n); lista de 1 bilhao: 30 passos vs 1 bilhao (linear); requer lista ordenada; base de indices de banco de dados B-tree.
ORIGEM Kiefer, 1953 - Proceedings American Mathematical Society; Knuth, 1997
▶ Banco de dados de 1e9 registros: busca binaria em 30 comparacoes; base de queries em < 1 ms

317
Complexidade de NP vs P (Conjectura)
AVANCADO
T_SAT = 2^n_vars
Tempo exponencial no pior caso do SAT sem algoritmo polinomial conhecido; P=NP aberto; supoe-se P ne NP; base de criptografia moderna e protecao de dados.
ORIGEM Cook, 1971 - STOC; Karp, 1972 - 21 NP-completos; Clay Millennium Problem
▶ SAT com n=300 variaveis: 2^300=2e90 operacoes; inatacavel por forca bruta; base de criptografia de chave simetrica

318
Hashing Consistente (Sistemas Distribuidos)
INTERMEDIARIO
remap_frac = 1 / n_servers
Fracao de chaves remapeadas ao adicionar 1 servidor ao hashing consistente; vs hashing modular: n/(n+1) das chaves remapeadas; base de CDN e caches distribuidos.
ORIGEM Karger et al., 1997 - STOC; implementado em Akamai, Dynamo, Cassandra
▶ CDN com 1000 servidores: adicionar 1 -> 0,1% de chaves migradas; vs hash modulo: 99,9% migradas

319
Teorema Master (Recorrencias de Algoritmos)
INTERMEDIARIO
T_recurrence = n^log_b_a
Solucao do teorema master para T(n)=a*T(n/b)+f(n); caso 1: f=O(n^log_b_a - eps): T=theta(n^log_b_a); base de analise de algoritmos recursivos divide-e-conquista.
ORIGEM Bentley, Haken & Saxe, 1980; Cormen et al., 2009 - CLRS Introduction to Algorithms
▶ Mergesort: a=2, b=2, f=O(n): caso 2: T=theta(n log n); FFT: a=b=2, f=O(n): T=theta(n log n)

320
Isomorfismo de Grafos (GI)
FUNDAMENTAL
GI_ops = exp((log(n_vertices))^c_const)
Complexidade de GI de Babai quasi-polinomial; c_const=1; antes: exp(sqrt(n)); matematicamente prove-se solucao quasi-polinomial por Babai (2015); GI provavelmente em P.
ORIGEM P. Erdos & A. Renyi, 1963; Graph Isomorphism problem; L. Babai, 2015 - STOC
▶ GI solucao para grafos de 10^3 nos: Babai quasipoly; aplicacao em quimica computacional e CAD

""";
    }
}
