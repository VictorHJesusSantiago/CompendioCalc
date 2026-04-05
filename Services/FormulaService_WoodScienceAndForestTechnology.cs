namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol14Parte4 = """
Ciencia da Madeira e Tecnologia Florestal
Propriedades Mecanicas
241
Modulo de Elasticidade da Madeira
FUNDAMENTAL
E = sigma / epsilon = (F·L) / (A·delta)
Modulo de Young da madeira; varia com especie e direcao.
ORIGEM Mecanica dos solidos — aplicado a madeira
▶ Pinus elliottii: E≈13 GPa na direcao longitudinal
242
Teor de Umidade da Madeira
FUNDAMENTAL
U = (m_umida − m_seca) / m_seca × 100
Umidade base seca; PSF≈25-30%.
ORIGEM ABNT NBR 7190 — Projeto de estruturas de madeira
▶ Madeira verde: U≈80-150%
243
Retracao da Madeira (Shrinkage)
FUNDAMENTAL
S = (d_verde − d_seca) / d_verde × 100
Retracao tangencial, radial e longitudinal; anisotropia causa empenamento.
ORIGEM Wood science — U.S. Forest Products Lab
▶ Eucalipto: retração tangencial≈8%, radial≈4%
244
Equacao de Sauerbeck (Crescimento Florestal)
INTERMEDIARIO
IMA = (DAP^2 × h × ff) / (4 × idade)
Incremento medio anual de volume.
ORIGEM Dendrometria florestal
▶ Eucalipto 7 anos, DAP=15 cm, h=25 m -> IMA≈40 m3/ha/ano
245
Formula de Schumacher-Hall (Volume)
INTERMEDIARIO
lnV = b0 + b1·ln(DAP) + b2·ln(H)
Equacao de volume de arvore; coeficientes calibrados por especie e regiao.
ORIGEM Schumacher & Hall, 1933
▶ DAP=20 cm, H=18 m, b0=−9,5 -> V≈0,18 m3
246
Area Basal de Floresta
FUNDAMENTAL
G = soma_pi_quarto_DAP2 / A_parcela
Area basal por hectare; indicador de densidade florestal.
ORIGEM Inventario florestal
▶ G=30 m2/ha indica floresta bem desenvolvida
247
Indice de Sitio (IS) Florestal
INTERMEDIARIO
IS = H_dom / f_idade
Qualidade produtiva do sitio pela altura dominante a uma idade de referencia.
ORIGEM Husch, Beers & Kershaw — Forest Mensuration
▶ IS=32 a 7 anos: sitio excelente
248
Umidade de Equilibrio (Hailwood-Horrobin)
AVANCADO
UE = termo_K1K2 + termo_K3
Umidade de equilibrio da madeira em funcao da umidade relativa H.
ORIGEM Hailwood & Horrobin, 1946
▶ H=65%, T=20C -> UE≈12%
249
Resistencia a Compressao Paralela (NBR 7190)
INTERMEDIARIO
f_c0_k = f_c0_m · (1 − 1,645·CV) · k_mod
Resistencia caracteristica de compressao da madeira.
ORIGEM ABNT NBR 7190:1997
▶ Eucalipto: f_c0_k≈35-50 MPa
250
Taxa de Sequestro de Carbono
FUNDAMENTAL
C_floresta = B × 0,5; B = V × densidade_basica
Biomassa seca B × 0,5 = carbono armazenado.
ORIGEM IPCC Guidelines for National GHG Inventories, 2006
▶ Floresta tropical: 150-200 tC/ha
Psicologia Quantitativa e Psicometria
Teoria dos Testes
251
Teoria Classica dos Testes (TCT) — Confiabilidade
INTERMEDIARIO
rXX = sigma2_T / sigma2_X = 1 − sigma2_e / sigma2_X
Confiabilidade de teste; rXX>=0,8 para uso clinico.
ORIGEM Spearman, 1904; Lord & Novick, 1968
▶ Alfa de Cronbach=0,85
252
Alfa de Cronbach
FUNDAMENTAL
alpha = (k/(k−1)) · (1 − soma_sigma2_i / sigma2_total)
Consistencia interna; alpha>=0,7 aceitavel.
ORIGEM L.J. Cronbach, 1951
▶ 10 itens, variancia total=20, soma=12 -> alpha=0,9
253
Tamanho de Efeito de Cohen (d)
FUNDAMENTAL
d = (mu1 − mu2) / sigma_pooled
Diferenca padronizada entre medias; d=0,2 pequeno; 0,8 grande.
ORIGEM J. Cohen, 1969
▶ mu1=50, mu2=45, sigma=10 -> d=0,5
254
Modelo de Rasch (IRT)
AVANCADO
P = e^(theta−beta_i) / (1 + e^(theta−beta_i))
Probabilidade de acertar item i; theta=habilidade, beta_i=dificuldade.
ORIGEM G. Rasch, 1960
▶ theta=0, beta_i=0 -> P=0,5
255
Indice de Discriminacao de Item
FUNDAMENTAL
D = (n_acertos_superior − n_acertos_inferior) / n_grupo
Discriminacao de item entre grupos de alto e baixo desempenho.
ORIGEM Psicometria classica
▶ D=0,40: bom poder discriminatorio
256
Erro Padrao de Medida
INTERMEDIARIO
EPM = sigma_x · sqrt(1 − rXX)
Incerteza de medida individual; intervalo de confianca: escore ± 1,96·EPM.
ORIGEM TCT — Lord & Novick, 1968
▶ sigma=10, rXX=0,84 -> EPM=4
257
Validade de Constructo (Convergente — HTMT)
AVANCADO
HTMT = razao_media_correlacoes_heterotraito_monotraito
Razao HTMT para validade convergente; HTMT<0,85 indica discriminacao de constructos.
ORIGEM Henseler et al., 2015
▶ HTMT=0,70
258
Tamanho Amostral (Analise de Potencia)
INTERMEDIARIO
n = (z_alpha_2 + z_beta)^2 · 2·sigma^2 / delta^2
Amostra para teste t bicaudal.
ORIGEM Cohen, 1969; formulacao estatistica
▶ sigma=10, delta=5 -> n≈63 por grupo
259
Correlacao Intraclasse (ICC)
INTERMEDIARIO
ICC = (MSB − MSW) / (MSB + (k−1)·MSW)
Concordancia entre avaliadores; ICC>0,75 excelente.
ORIGEM Shrout & Fleiss, 1979
▶ ICC=0,90 entre dois raters
260
Analise Fatorial Confirmatoria (CFI)
AVANCADO
CFI = 1 − (chi2_modelo − df_modelo) / (chi2_nulo − df_nulo)
Indice de ajuste comparativo; CFI>0,95 excelente ajuste.
ORIGEM Bentler, 1990 — SEM
▶ CFI=0,96, RMSEA=0,05
Engenharia Biomedica e Bioeletronica
Eletrofisiologia
261
Equacao de Hodgkin-Huxley
AVANCADO
Cm·dV/dt = −gNa·m^3·h·(V−ENa) − gK·n^4·(V−EK) − gL·(V−EL) + I_ext
Modelo de potencial de acao neuronal; m,h,n=variaveis de gating.
ORIGEM A.L. Hodgkin & A.F. Huxley, 1952
▶ Potencial de acao: pico de +40 mV
262
Impedancia de Eletrodo-Tecido
AVANCADO
Z = Rct + 1/(j·omega·Cdl) + Rsol
Circuito equivalente de eletrodo implantavel.
ORIGEM Engenharia de interfaces bioeletronicas
▶ Eletrodo neural: |Z|=10-100 kOhm a 1 kHz
263
Equacao de Nernst (Potencial de Equilibrio)
INTERMEDIARIO
E_Nernst = (R·T/(z·F)) · ln(ion_e / ion_i)
Potencial de equilibrio eletroquimico.
ORIGEM W. Nernst, 1889
▶ K+: ion_e=4 mM, ion_i=140 mM -> E_K=−94 mV
264
Indice de Pressao-Fluxo de Stent
INTERMEDIARIO
FFR = P_distal / P_aorta
Reserva de fluxo fracional; FFR<0,80 indica estenose significativa.
ORIGEM Pijls et al., 1996
▶ FFR=0,75
265
Corrente de Marca-Passo (Limiar de Estimulacao)
AVANCADO
I_th = I_reobase / (1 − e^(−tp/tau))
Limiar de estimulacao; tau=cronaxia do tecido.
ORIGEM Lapicque, 1909 — aplicado a marca-passos
▶ Cronaxia de miocardio≈0,3 ms
266
Oximetria de Pulso (Lei de Beer-Lambert)
FUNDAMENTAL
SpO2 = HbO2 / (HbO2 + Hb) × 100
Saturacao de oxigenio por absorbancia diferencial.
ORIGEM Takuo Aoyagi, 1974
▶ SpO2<90%: hipoxemia
267
ECG — Duracao de Intervalo QT Corrigido
FUNDAMENTAL
QTc = QT / sqrt(RR)
Correcao de QT para frequencia cardiaca; QTc>0,45 s em homens indica risco.
ORIGEM H.C. Bazett, 1920
▶ QT=0,40 s, RR=0,80 s -> QTc=0,447 s
268
Pressao Arterial Media (PAM)
FUNDAMENTAL
PAM = PAD + (PAS − PAD)/3
Pressao arterial media hemodinamica; normal: 70-100 mmHg.
ORIGEM Fisiologia cardiovascular
▶ PAS=120, PAD=80 -> PAM=93 mmHg
269
Equacao de Windkessel (Modelo de Dois Elementos)
AVANCADO
C·dP/dt + P/R = Q(t)
Modelo de pos-carga arterial; C=complacencia arterial, R=resistencia vascular.
ORIGEM S. Hales, 1733; Otto Frank, 1899
▶ Hipertensao sistolica isolada: R normal, C reduzida
270
Dose de Desfibrilacao (Bifasico)
AVANCADO
E = C · V1^2 · (1 − e^(−T/tau)) · e^(−T/tau)
Energia de choque de desfibrilador bifasico; E tipico=150-200 J.
ORIGEM Zipes et al., 1975 — AHA Guidelines
▶ Desfibrilacao de FV: choque bifasico 200 J
Cosmoquimica e Geoquimica Isotopica
Isotopos Estaveis
271
Fracionamento de Isotopos Estaveis (Equilibrio)
INTERMEDIARIO
alpha_A_B = R_A / R_B; epsilon = (alpha−1)×1000
Fator de fracionamento entre fases A e B.
ORIGEM Urey, 1947
▶ Evaporacao de agua: 18O se concentra no liquido
272
Datacao U-Pb (Concordia de Wetherill)
AVANCADO
Pb206_U238 = e^(lambda238·t)−1; Pb207_U235 = e^(lambda235·t)−1
Datacao U-Pb; concordancia de dois sistemas = confiabilidade maxima.
ORIGEM G.W. Wetherill, 1956
▶ Zircon concordante: mesmo t pelos dois sistemas
273
Anomalia de Europio (Eu/Eu*)
AVANCADO
Eu_Eu_estrela = Eu_N / sqrt(Sm_N · Gd_N)
Anomalia de Eu normalizada ao condrito.
ORIGEM Geoquimica de REE — Taylor & McLennan, 1985
▶ Granito anorogenico: Eu/Eu*=0,3-0,5
274
Normalizacao ao Condrito (Spider Diagram)
INTERMEDIARIO
Elemento_N = Elemento_amostra / Elemento_condrito
Padrao normalizado ao condrito CI.
ORIGEM Sun & McDonough, 1989
▶ Padrao MORB: enriquecimento em HREE
275
Temperatura de Oxigenacao por DeltaFMQ
AVANCADO
DeltaFMQ = log_fO2 − log_fO2_FMQ
Fugacidade de oxigenio relativa ao tampao FMQ.
ORIGEM Geoquimica do manto
▶ DeltaFMQ=+2: oxidado
276
Razao Inicial de Sr Isotopico
AVANCADO
Sr87_Sr86_i = Sr87_Sr86_medido − Rb87_Sr86·(e^(lambda·t)−1)
Razao inicial indica fonte mantelica vs crustal.
ORIGEM Geocronologia Rb-Sr
▶ Magma com 87Sr/86Sr_i=0,730 indica contribuicao crustal
277
Temperatura de Fechamento (Dodson)
AVANCADO
Tc = E / (R · ln_argumento_dodson)
Temperatura de fechamento de sistema geocronologico.
ORIGEM M.H. Dodson, 1973
▶ Tc(zircao U-Pb)≈900C
278
Composicao Solar (Proto-Solar)
INTERMEDIARIO
log_NX_NH_sol = log_NX_NH_CI + Delta_volatilidade
Composicao solar derivada do condrito CI corrigida por volatilidade.
ORIGEM Palme & Jones, 2003; Lodders, 2003
▶ Abundancia solar de Fe: 7,50 na escala de 12=H
279
Temperatura de Condensacao (Cosmoquimica)
AVANCADO
T_cond = f_fO2_pressao_composicao_solar
Temperatura em que mineral condensa da nebulosa solar.
ORIGEM Grossman, 1972
▶ Corindo condensa a 1758 K
280
Isotopo de Osmium (187Os/188Os)
AVANCADO
Os187_Os188_manto = 0,1270
Razao de Re-Os; impactitos e meteoritos tem assinatura distinta do manto.
ORIGEM Meisel et al., 2001
▶ Anomalias no K-Pg confirmam impacto de meteorito
Engenharia Textil e Ciencia de Fibras
Propriedades de Fibras
281
Titulo (Finura) de Fibra — Tex
FUNDAMENTAL
Tt = m / L; Ne = 590,5 / Tt
Titulo de fibra; 1 tex=1 g/km.
ORIGEM ISO 1144 — sistema de titulos
▶ Fio de 20 tex -> Ne≈29,5
282
Resistencia a Tracao de Fio
FUNDAMENTAL
Tenacidade = Forca_ruptura / Titulo
Tenacidade normalizada pelo titulo.
ORIGEM ABNT NBR ISO 2062
▶ Fio de 20 tex com ruptura a 500 cN -> 25 cN/tex
283
Torcao de Fio (Torque)
INTERMEDIARIO
T = t_m × sqrt(Tt)
Torcao e coeficiente de torcao; torcao alta aumenta resistencia.
ORIGEM Engenharia textil
▶ Fio cardado Ne 30: 750 t/m
284
Cobertura de Tecido
INTERMEDIARIO
K = d_fio / e_tecido × 100
Percentagem de cobertura; K>100% indica sobreposicao de fios.
ORIGEM Geometria de tecidos — Peirce, 1937
▶ Tecido liso: K_teia=70%, K_trama=70%
285
Absortividade de Umidade (Regain)
FUNDAMENTAL
R = (m_umida − m_seca) / m_seca × 100
Regain padrao de fibras.
ORIGEM ASTM D2495
▶ La a 65% UR: regain≈16%
286
Modulo de Young de Fibra Textil
FUNDAMENTAL
E = sigma/epsilon = (F/A) / (DeltaL/L0)
Modulo de elasticidade.
ORIGEM Mecanica de fibras
▶ Fibra de carbono: E≈230-600 GPa
287
Gramatura de Tecido
FUNDAMENTAL
G = m / A
Massa por unidade de area; base de especificacao e custo textil.
ORIGEM ABNT NBR ISO 3801
▶ Tecido de 200 g/m2 em 1,5 m largura -> 300 g por metro linear
288
Resistencia Termica de Tecido (CLO)
INTERMEDIARIO
R_tecido = soma_R_camadas
Isolamento termico de vestuario; 1 CLO = 0,155 m2·K/W.
ORIGEM Gagge et al., 1941 — ASTM F1291
▶ Roupa de inverno: 2-3 CLO
289
Modelo de Dyeing (Difusao de Corante em Fibra)
AVANCADO
Mt_Minf = 1 − serie_exponencial_difusao
Difusao de corante em fibra cilindrica.
ORIGEM Crank, 1956 — The Mathematics of Diffusion
▶ Poliester: D≈10^-12 m2/s a 130C
290
Indice de Amarelecimento (YI)
INTERMEDIARIO
YI = 100·(C·X − C·Z) / C·Y
Amarelecimento de texteis brancos; X,Y,Z=valores triestimulos CIE.
ORIGEM ASTM D1925 / D6290
▶ Poliester irradiado: YI aumenta com exposicao UV
Bioacustica e Comunicacao Animal
Ecolocalizacao
291
Equacao de Sonar Ativo (Cetaceos)
AVANCADO
SNR = SL − 2·TL + TS − NL + DI
Equacao do sonar: SL=fonte, TL=perda, TS=alvo, NL=ruido, DI=ganho.
ORIGEM Sonar equation — Urick, 1975
▶ Boto com SL=220 dB: detecta peixe a dezenas de metros
292
Frequencia Fundamental e Harmonicos (Birdsong)
INTERMEDIARIO
fn = n · f1; f1 = c / (2·L)
Frequencia fundamental de canto de passaro.
ORIGEM Bioacustica de aves — Nowicki, 1987
▶ Canario com f1=2 kHz -> harmonicos a 4, 6, 8 kHz
293
Indice Acustico de Biodiversidade (ACI)
INTERMEDIARIO
ACI = soma_abs_Deltaf / soma_f
Indice de complexidade acustica; alta diversidade biologica -> alto ACI.
ORIGEM Pieretti et al., 2011
▶ Floresta tropical: ACI≈1500
294
Perda de Transmissao de Som em Agua
INTERMEDIARIO
TL = 20·log10(r) + alpha·r
Atenuacao esferica + absorcao.
ORIGEM Acustica subaquatica — Urick, 1975
▶ 100 Hz em agua do mar: alcance de centenas de km
295
Sensibilidade Auditiva (Limiar de Audicao)
FUNDAMENTAL
SPL_limiar = P_rms / P_ref
Nivel de pressao sonora minimo detectavel; especie-especifico.
ORIGEM Bioacustica comparativa
▶ Morcego: melhor sensibilidade≈20 kHz
296
Resolucao Temporal de Ecolocalizacao
AVANCADO
Delta_t_min = 1 / BW; d_min = c · Delta_t_min / 2
Resolucao temporal de pulso; BW=largura de banda.
ORIGEM Ecolocalizacao — Simmons, 1979
▶ Morcego distingue alvos separados por 3,4 mm
297
Indice de Entropia Espectral (H) para Birdsong
INTERMEDIARIO
Hs = −sum_pi_log2_pi
Entropia espectral de vocalizacao; Hs baixa=tonal, Hs alta=ruido.
ORIGEM Depraetere et al., 2012
▶ Canto tonal de tentilhao: Hs≈0,1
298
Dominancia Vocal (Intersong Interval)
FUNDAMENTAL
Ocupacao = T_canto / (T_canto + T_silencio)
Fracao do tempo em vocalizacao; base de monitoramento.
ORIGEM Ecologia comportamental
▶ Passaro canta 40 s/min -> ocupacao=67%
299
Modelo de Lombard (Ajuste Vocal ao Ruido)
INTERMEDIARIO
DeltaAmplitude_vocal = k · DeltaSNR_ambiente
Efeito Lombard: animais aumentam amplitude vocal com ruido ambiental.
ORIGEM Lombard, 1911 — aplicado a fauna
▶ Baleia jubarte: aumento de 1 dB na voz por 1 dB de ruido nautico
300
Proporcao de Harmonico-Ruido (HNR)
INTERMEDIARIO
HNR = 10·log10(E_harmonico / E_ruido)
Qualidade de vocalizacao; HNR alto=canto puro e saudavel.
ORIGEM Analise de voz — Boersma, 1993
▶ Canto saudavel de passaro: HNR>20 dB
Engenharia Ambiental e Controle de Emissoes
Qualidade da Agua
301
DBO5 — Demanda Bioquimica de Oxigenio
FUNDAMENTAL
DBO5 = (OD_inicial − OD_final) × fator_diluicao
Oxigenio consumido por degradacao biologica em 5 dias a 20C.
ORIGEM APHA — Standard Methods, 23a ed.
▶ Efluente industrial: DBO5=500 mg/L
302
DQO — Demanda Quimica de Oxigenio
INTERMEDIARIO
DQO = (B−V1)·M·8000 / V_amostra
Oxidacao quimica total por dicromato; relacao DQO/DBO5 indica tratabilidade.
ORIGEM APHA Standard Methods 5220
▶ DQO=1000 e DBO5=400 -> razao=2,5
303
Equacao de Streeter-Phelps (Autodepuracao)
AVANCADO
D(t) = kd·La/(kr−kd)·(e^(−kd·t)−e^(−kr·t)) + D0·e^(−kr·t)
Deficit de oxigenio em rio apos lancamento de efluente.
ORIGEM Streeter & Phelps, 1925
▶ Determina distancia para atingir OD minimo
304
Eficiencia de Tratamento Biologico (von Monod)
INTERMEDIARIO
mu = mu_max · S / (Ks + S)
Taxa de crescimento microbiano; base do dimensionamento de biorreatores.
ORIGEM J. Monod, 1949
▶ Lodo ativado: mu_max=0,5 d^-1
305
Fator de Emissao de GEE
FUNDAMENTAL
E = AD × EF × (1 − ER/100)
Emissao de GEE; base de inventarios.
ORIGEM IPCC 2006 GL for NGHGI; Protocolo de Kyoto
▶ Queima de gas natural: EF=56,1 kg CO2/GJ
306
Concentracao de Poluentes Atmosfericos (Gaussiana)
AVANCADO
C = Q/(2·pi·u·sigma_y·sigma_z)·exp(−y^2/(2·sigma_y^2))·exp(−(z−H)^2/(2·sigma_z^2))
Pluma gaussiana; Q=taxa de emissao, u=vento.
ORIGEM Pasquill-Gifford, 1961
▶ Dimensiona afastamento de chamines industriais
307
Eficiencia de Precipitador Eletrostatico
INTERMEDIARIO
eta = 1 − e^(−w·A/Q)
Eficiencia de remocao de material particulado; equacao de Deutsch.
ORIGEM W. Deutsch, 1922
▶ w=0,1 m/s, A/Q=50 s/m -> eta=99,3%
308
Indice de Qualidade do Ar (IQA — CONAMA)
FUNDAMENTAL
IQA = c × (IQ_sup − IQ_inf)/(c_sup − c_inf) + IQ_inf
Interpolacao linear para IQA por poluente.
ORIGEM CONAMA 491/2018; US-EPA AQI
▶ PM2,5=25 ug/m3 -> IQA≈70
309
Potencial de Aquecimento Global (GWP)
FUNDAMENTAL
GWP_x = integral_RF_x / integral_RF_CO2
GWP de gas x relativo ao CO2 em horizonte T.
ORIGEM IPCC AR5, 2013
▶ CH4: GWP100=28
310
Capacidade de Suporte de Ecossistema (K)
FUNDAMENTAL
dN/dt = rN·(1−N/K)
Capacidade de suporte K do ambiente; modelo logistico.
ORIGEM Verhulst, 1838
▶ Determinacao de K para pesca sustentavel
Tecnologia de Biomassa e Bioenergia
Combustao de Biomassa
311
Poder Calorifico Superior (PCS) de Biomassa
INTERMEDIARIO
PCS = 19,2·C + 68,0·(H−O/8) + 10,5·S
Calor de combustao por formula de Dulong.
ORIGEM P.L. Dulong, 1843
▶ Madeira seca: PCS≈18,8 MJ/kg
312
Poder Calorifico Inferior (PCI)
FUNDAMENTAL
PCI = PCS − 2,441 · w_H2O_formada
PCI desconta calor latente da agua formada por combustao.
ORIGEM Termodinamica de combustao
▶ Madeira: PCI≈17,5 MJ/kg
313
Eficiencia de Conversao de Biogas (Rendimento de Metano)
INTERMEDIARIO
eta_CH4 = V_CH4 / V_CH4_teorico × 100
Rendimento de metano; teórico depende de DQO.
ORIGEM Biodigestao anaerobia — Buswell & Mueller, 1952
▶ Digestao anaerobia: eta≈60-80%
314
Equacao de Buswell (Biogas Teorico)
AVANCADO
biomassa + agua -> CH4 + CO2 + NH3 + H2S
Estequiometria de biogas a partir da formula molecular de biomassa.
ORIGEM Buswell & Mueller, 1952
▶ Celulose: 3CH4 + 3CO2
315
Balanco de Energia de Usina de Bioetanol
INTERMEDIARIO
TEP_produto = TEP_biomassa · eta_total; eta_total = eta_fermentacao · eta_destilacao
Eficiencia total de conversao da biomassa em bioetanol.
ORIGEM NIPE/UNICAMP — Balanco energetico da cana
▶ 1 t cana -> 85 L etanol + 280 kg bagaco
316
Equacao de Monod (Fermentacao)
INTERMEDIARIO
dX/dt = mu_max·S/(Ks+S)·X
Cinetica de crescimento microbiano em fermentacao.
ORIGEM J. Monod, 1949
▶ Saccharomyces: mu_max=0,3-0,5 h^-1
317
Balanco de Carbono da Combustao de Biomassa
FUNDAMENTAL
C_emitido = massa_biomassa · C_pct · (44/12); C_fixado = producao · C_pct · (44/12)
Neutralidade de carbono em biomassa sustentavel.
ORIGEM IPCC Guidelines — bioenergy carbon accounting
▶ Biomassa sustentavel: balanco liquido≈0
318
Coeficiente de Transferencia de Massa (kLa)
AVANCADO
kLa = −ln((O_estrela−O)/(O_estrela−O0)) / t
Coeficiente volumetrico de transferencia de O2.
ORIGEM Engenharia de biorreatores
▶ Fermentador aerado: kLa=50-200 h^-1
319
Razao de Reciclagem em Fermentador Continuo (Dilution Rate)
INTERMEDIARIO
D = F/V
Taxa de diluicao; washout ocorre quando D>mu_max.
ORIGEM Monod, 1949; Herbert, Elsworth & Telling, 1956
▶ D=0,2 h^-1, V=1000 L -> F=200 L/h
320
Indice de Produtividade Energetica de Biodiesel
INTERMEDIARIO
EP = energia_biodiesel / (energia_insumos + energia_processo)
Razao de energia; quanto maior EP, mais eficiente a cadeia de producao.
ORIGEM Analise de ciclo de vida de biodiesel — EMBRAPA
▶ Palma: EP=4
""";
    }
}
