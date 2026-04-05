namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol14Parte1 = """
Farmacologia e Farmacocinetica
Cinetica Enzimatica
001
Equacao de Michaelis-Menten
FUNDAMENTAL
v = Vmax·[S] / (Km + [S])
Velocidade de reacao enzimatica; Vmax=velocidade maxima, Km=constante de Michaelis, [S]=concentracao de substrato.
ORIGEM L. Michaelis & M. Menten, 1913
▶ Vmax=100 uM/s, Km=5 mM, [S]=5 mM -> v=50 uM/s
002
Depuracao Plasmatica (Clearance)
FUNDAMENTAL
CL = Vd · ke = Dose / AUC
Clearance total; Vd=volume de distribuicao, ke=constante de eliminacao, AUC=area sob a curva concentracao-tempo.
ORIGEM Farmacocinetica classica
▶ Dose=500 mg, AUC=100 mg·h/L -> CL=5 L/h
003
Meia-Vida de Eliminacao
FUNDAMENTAL
t1/2 = 0,693 / ke = 0,693·Vd / CL
Tempo para reduzir concentracao plasmatica a metade; ke=constante de eliminacao de primeira ordem.
ORIGEM Farmacocinetica classica
▶ ke=0,1 h^-1 -> t1/2=6,93 h
004
Modelo de um Compartimento (IV)
INTERMEDIARIO
C(t) = C0·exp(−ke·t)
Concentracao plasmatica apos bolus IV; C0=concentracao inicial=Dose/Vd.
ORIGEM Farmacocinetica de 1 compartimento
▶ C0=10 mg/L, ke=0,2 h^-1, t=3 h -> C=5,49 mg/L
005
Equacao de Hill (Resposta Sigmoide)
INTERMEDIARIO
E = Emax·Cn / (EC50n + Cn)
Relacao dose-resposta sigmoide; n=coeficiente de Hill, EC50=concentracao com 50% do efeito maximo.
ORIGEM A.V. Hill, 1910
▶ n=2, C=EC50 -> E=Emax/2
006
Indice Terapeutico
FUNDAMENTAL
IT = DL50 / DE50
Razao entre dose letal mediana e dose efetiva mediana; quanto maior IT, mais seguro o farmaco.
ORIGEM Toxicologia farmacologica
▶ DL50=1000 mg/kg, DE50=10 mg/kg -> IT=100
007
Biodisponibilidade Oral
FUNDAMENTAL
F = AUC_oral / AUC_IV · (Dose_IV / Dose_oral)
Fracao de farmaco que atinge circulacao sistemica por via oral; F=1 para IV.
ORIGEM Farmacocinetica comparativa
▶ AUC_oral=80, AUC_IV=100, mesma dose -> F=0,80
008
Equacao de Noyes-Whitney (Dissolucao)
INTERMEDIARIO
dC/dt = k·A·(Cs − C)
Taxa de dissolucao de solido; k=constante de dissolucao, A=area superficial, Cs=solubilidade, C=concentracao atual.
ORIGEM A.A. Noyes & W.R. Whitney, 1897
▶ Aumento de A por micronizacao acelera dissolucao de farmacos pouco soluveis
009
Equacao de Henderson-Hasselbalch (Ionizacao)
FUNDAMENTAL
pH = pKa + log([A−]/[HA])
Grau de ionizacao de farmaco acido/base fraco; ionizacao afeta absorcao e distribuicao tecidual.
ORIGEM L.J. Henderson & K.A. Hasselbalch, 1908
▶ pKa=4,8, pH=7,4 -> 99,6% ionizado (acido fraco)
010
Taxa de Infusao em Estado Estacionario
INTERMEDIARIO
R0 = Css · CL
Taxa de infusao IV continua para manter concentracao em estado estacionario Css.
ORIGEM Farmacocinetica de infusao
▶ Css=10 mg/L, CL=5 L/h -> R0=50 mg/h
011
Dose de Ataque
INTERMEDIARIO
DL = Css · Vd
Dose inicial para atingir rapidamente concentracao terapeutica; seguida de dose de manutencao.
ORIGEM Farmacocinetica clinica
▶ Css=15 mg/L, Vd=40 L -> DL=600 mg
012
Acumulacao em Doses Multiplas
INTERMEDIARIO
Racc = 1 / (1 − e^(−ke·tau))
Fator de acumulacao apos doses repetidas com intervalo tau; ke=constante de eliminacao.
ORIGEM Farmacocinetica de multiplas doses
▶ t1/2=8 h, tau=12 h -> Racc≈1,64
013
Equacao de Kety (Fluxo Cerebral)
AVANCADO
dq/dt = F·(Ca − Cv) = F·Ca − k2·q
Modelo de captacao de farmaco por tecido; F=fluxo sanguineo, Ca,Cv=concentracoes arterial/venosa, k2=taxa de saida.
ORIGEM S.S. Kety, 1951
▶ Usado em PET para medir metabolismo cerebral de glicose
014
Interacao Farmaco-Receptor (Receptor Ocupado)
INTERMEDIARIO
DR/R_total = D / (KD + D)
Fracao de receptores ocupados; KD=constante de dissociacao; base da teoria de receptores de Clark.
ORIGEM A.J. Clark, 1926
▶ D=KD -> 50% de receptores ocupados
015
pA2 de Schild (Antagonismo Competitivo)
AVANCADO
log(r−1) = log(B) − pA2
Parametro de afinidade de antagonista; r=razao de concentracao equipotente, B=concentracao de antagonista.
ORIGEM H.O. Schild, 1949
▶ Grafico de Schild: inclinacao=1, intercepto=pA2
016
Modelo de Dois Compartimentos (IV)
AVANCADO
C(t) = A·e^(−alpha·t) + B·e^(−beta·t)
Concentracao plasmatica biexponencial; A,B=amplitudes, alpha>beta=constantes de disposicao rapida e lenta.
ORIGEM Farmacocinetica multicompartimental
▶ Farmacos lipossoluveis: fase alpha rapida de distribuicao, beta lenta de eliminacao
017
Cmax e Tmax (Via Oral, 1 Compartimento)
AVANCADO
Tmax = ln(ka/ke)/(ka−ke); Cmax = (F·D/Vd)·(ke/(ka−ke))·(e^(−ke·Tmax)−e^(−ka·Tmax))
Concentracao e tempo de pico apos absorcao oral; ka=constante de absorcao.
ORIGEM Farmacocinetica oral de 1 compartimento
▶ Determina quando medir nivel serico de pico
018
Coeficiente de Particao Octanol-Agua (logP)
FUNDAMENTAL
logP = log(farmaco_octanol / farmaco_agua)
Lipofilicidade; logP alto favorece absorcao GI e passagem barreira hematoencefalica; regra de Lipinski: logP<=5.
ORIGEM Regra de Lipinski dos 5
▶ Aspirina: logP=1,2; Amiodarona: logP=7
019
Equacao de Renkin-Crone (Extracao Capilar)
AVANCADO
E = 1 − e^(−PS/F)
Extracao fracional em leito capilar; P=permeabilidade, S=area de superficie, F=fluxo sanguineo.
ORIGEM E.M. Renkin, 1959; C.C. Crone, 1963
▶ PS/F>>1 -> E≈1; PS/F<<1 -> E≈PS/F
020
Indice de Risco Teratogenico (TDI)
INTERMEDIARIO
TDI = NOAEL / (MF × SF)
Ingestao diaria toleravel; NOAEL=nivel sem efeito adverso observavel, MF=fator de modelagem, SF=fator de seguranca.
ORIGEM Toxicologia regulatoria — ECHA/FDA
▶ NOAEL=10 mg/kg/d, SF=100 -> TDI=0,1 mg/kg/d
Ciencias Forenses e Quimica Forense
Metodos Analiticos
021
Lei de Lambert-Beer (Espectrofotometria Forense)
FUNDAMENTAL
A = epsilon·c·l
Absorbancia A; epsilon=absortividade molar, c=concentracao, l=caminho optico; base da analise espectroscopica forense.
ORIGEM J.H. Lambert, 1760; A. Beer, 1852
▶ Dosagem de alcool em sangue por espectrofotometria
022
Estimativa do Intervalo Post-Mortem (Algor Mortis)
FUNDAMENTAL
T_morte ≈ (T_retal − T_ambiente) / 1,5
Estimativa grosseira do tempo de morte por resfriamento corporal; taxa de 1,5 °C/h em ambiente tipico.
ORIGEM Tanatologia forense
▶ T_retal=30C, T_amb=20C -> tempo≈6,7 h post-mortem
023
Formula de Henssge (Nomograma de Henssge)
AVANCADO
T_pm = 1,11·(TRetal−TAmbiente) / (37−TAmbiente)
Estimativa de intervalo post-mortem mais precisa; usa peso corporal e temperatura retal/ambiente; nomograma completo.
ORIGEM C. Henssge, 1988
▶ Padrao ouro em medicina legal para estimar hora da morte
024
Calculo de BAC (Formula de Widmark)
FUNDAMENTAL
BAC = A / (r · W) − beta·t
Concentracao de alcool no sangue; A=alcool ingerido (g), r=0,68 (homem)/0,55 (mulher), W=peso(kg), beta≈0,15 g/L/h.
ORIGEM E.M.P. Widmark, 1932
▶ 50 g de alcool, 70 kg homem -> BAC0≈1,04 g/L
025
DNA Fingerprinting — LOD Score
AVANCADO
LOD = log10(P_dados_ligacao_theta / P_dados_nao_ligacao)
Escore de probabilidade para analise de ligacao genetica; LOD>3 sugere ligacao; base da identificacao por DNA.
ORIGEM N.E. Morton, 1955
▶ LOD=3,5 -> probabilidade de ligacao 3162x maior que nao-ligacao
026
Probabilidade de Paternidade (W de Essen-Moller)
INTERMEDIARIO
W = PI / (PI + 1)
Probabilidade de paternidade W a partir do indice de paternidade PI; W>0,99 e padrao forense.
ORIGEM E. Essen-Moller, 1938
▶ PI=9999 -> W=0,9999
027
Trajetoria de Projetil Balistico
FUNDAMENTAL
R = v0^2·sin(2·theta) / g; H = v0^2·sin^2(theta) / (2·g)
Alcance R e altura maxima H de projetil; v0=velocidade inicial, theta=angulo; usado em analise de cena de crime.
ORIGEM Balistica forense
▶ v0=300 m/s, theta=30° -> R≈7955 m
028
Analise de Residuos de Disparo (GSR — EDX)
INTERMEDIARIO
C_GSR = I_amostra / I_padrao · C_padrao
Quantificacao de elementos caracteristicos de GSR (Pb, Ba, Sb) por EDX; C proporcional a intensidade de raios-X.
ORIGEM Analise forense de GSR
▶ Deteccao de particulas de chumbo/bario/antimonio em maos de suspeito
029
Cromatografia Gasosa — Indice de Retencao de Kovats
INTERMEDIARIO
RI = 100·n + 100·(log(tx) − log(tn)) / (log(tn+1) − log(tn))
Indice de retencao de Kovats para identificar compostos por GC; tx=tempo retido do composto, tn e tn+1=alcanos flanqueadores.
ORIGEM E. Kovats, 1958
▶ Identifica compostos em acelerantes de incendio em analise forense
030
Estimativa de Estatura por Ossos Longos
FUNDAMENTAL
Estatura = a·comprimento_femur + b
Regressao linear para estimar estatura de ossos; coeficientes variam por sexo/populacao; EP=erro padrao≈±3–4 cm.
ORIGEM Anthropologia forense — Trotter & Gleser, 1952
▶ Femur=45 cm, masculino -> estatura≈170 cm
031
Indice de Credibilidade de Testemunha Ocular (Signal Detection)
AVANCADO
d_prime = Z(H) − Z(FA)
Sensibilidade perceptual; H=taxa de acertos, FA=falsos alarmes; d'>2 indica boa discriminacao.
ORIGEM Teoria de Deteccao de Sinal — J.A. Swets, 1964
▶ H=0,85, FA=0,15 -> d'≈2
032
Lei de Zipf Forense (Analise de Frequencia de Palavras)
INTERMEDIARIO
f(r) ≈ C / r^s
Frequencia de palavra de rank r; usado em analise de autoria de documentos; s≈1 para texto natural.
ORIGEM G.K. Zipf, 1935
▶ Comparacao de estilo em analise forense de documentos
033
Espectrometria de Massa — Resolucao de Massa
INTERMEDIARIO
R = m / delta_m
Poder de resolucao de espectrometro; m=massa nominal, delta_m=diferenca entre dois picos resolviveis; base da confirmacao forense.
ORIGEM Espectrometria de massa
▶ R=10000 em HRMS permite identificacao inequivoca de drogas
034
Tempo de Formacao de Rigor Mortis
INTERMEDIARIO
t_rigor ≈ k / ATP0 · (T − Tref)
Rigor mortis correlaciona com deplecao de ATP e temperatura; inicia 2-6 h, maximo 12 h, desaparece 48 h post-mortem.
ORIGEM Tanatologia forense
▶ Temperaturas altas aceleram rigor; frio retarda
035
Indice de Decomposicao Total (TBS)
AVANCADO
TBS = sum_temperatura_diaria_excedente
Graus-dia acumulados acima de limiar (0-10C); correlaciona com estagio de decomposicao cadaverica.
ORIGEM Tanatologia forense — Bass, 1987
▶ TBS=400 ADD corresponde a determinado estagio em clima temperado
036
Probabilidade de Mistura de DNA
AVANCADO
P_E_Hd = sum_prob_genotipo_mistura
Probabilidade de observar evidencia de DNA misto dado suspeito como colaborador; base da interpretacao forense de mistura.
ORIGEM NRC II Report, 1996
▶ Interpretacao de misturas de DNA por probabilidade bayesiana
037
Analise de Pegada Plantar
FUNDAMENTAL
Indice_pe = largura_pe / comprimento_pe × 100
Classifica tipo de pe (plano, normal, cavo); usado em analise de pegadas para identificacao forense.
ORIGEM Antropologia forense
▶ Indice>40 = pe plano; 30-40 = normal; <30 = cavo
038
Voltametria de Stripping (LOD)
INTERMEDIARIO
LOD = 3·sigma_branco / S
Limite de deteccao; sigma_branco=desvio padrao do branco, S=sensibilidade (slope da curva de calibracao); fundamental em toxicologia.
ORIGEM Analise eletroquimica
▶ Deteccao de metais pesados em amostras biologicas forenses
039
Entropia de Shannon para Analise de Perfil de DNA
AVANCADO
H = −sum_pi_log2_pi
Entropia de informacao; mede diversidade alelica num locus STR; alta entropia = maior poder discriminatorio forense.
ORIGEM C.E. Shannon, 1948
▶ Locus com 10 alelos equifrequentes: H=log2(10)≈3,32 bits
040
Indice de Refracao (Vidros Forenses)
FUNDAMENTAL
n = sin(theta_i) / sin(theta_r)
Indice de refracao de fragmento de vidro; variacoes de n na 4a casa decimal distinguem fontes diferentes.
ORIGEM Lei de Snell-Descartes
▶ Vidro float: n≈1,517; vidro borossilicato: n≈1,474
Fisiologia do Exercicio e Biomecanica Esportiva
Consumo de Oxigenio
041
VO2max — Equacao de Fick
FUNDAMENTAL
VO2 = Q · (CaO2 − CvO2)
Consumo maximo de oxigenio; Q=debito cardiaco (L/min), CaO2−CvO2=diferenca arteriovenosa de O2.
ORIGEM A. Fick, 1870
▶ Q=25 L/min, diferenca a-v=15 mL/dL -> VO2=3,75 L/min
042
Frequencia Cardiaca Maxima
FUNDAMENTAL
FCmax = 220 − idade; FCmax_tanaka = 208 − 0,7·idade
Estimativa da FCmax; formula de Tanaka mais precisa para adultos; base da prescricao de exercicio por zonas.
ORIGEM Fox et al., 1971; Tanaka et al., 2001
▶ Individuo de 40 anos: Fox->180 bpm; Tanaka->180 bpm
043
Gasto Energetico — MET
FUNDAMENTAL
EE = MET · peso_kg
Gasto energetico a partir do equivalente metabolico; caminhada leve=3 MET, corrida=8-12 MET.
ORIGEM Compendio de Atividades Fisicas — Ainsworth et al.
▶ 70 kg, corrida (10 MET) por 1 h -> 700 kcal
044
Potencia Anaerobia (Wingate)
INTERMEDIARIO
Ppico = F_pico · v_pico
Potencia de pico no teste de Wingate; carga=resistencia (kgf), rotacoes em 5 s de maxima intensidade.
ORIGEM Instituto Wingate, Israel
▶ Atleta 75 kg, carga=4,5 kgf, 8 rot/5s -> Ppico≈858 W
045
Indice de Fadiga (Wingate)
INTERMEDIARIO
IF = (Ppico − Pminima) / Ppico × 100
Percentual de queda de potencia durante teste de Wingate (30 s); IF alto indica baixa resistencia anaerobia.
ORIGEM Testes de Wingate
▶ Ppico=900W, Pminima=400W -> IF=44,4%
046
Eficiencia Mecanica de Corrida
INTERMEDIARIO
eta = Potencia_externa / Potencia_metabolica × 100
Eficiencia de conversao energetica; corredores de elite: eta≈35-45%; inclui trabalho contra gravidade e inercia.
ORIGEM Biomecanica da corrida
▶ Atleta com 200 W externos e 600 W metabolicos -> eta=33%
047
Forca de Reacao ao Solo (GRF)
FUNDAMENTAL
GRF_pico ≈ 2,5·BW
Forca de reacao ao solo durante corrida; pico ~2,5-3x peso corporal; importante para analise de lesoes.
ORIGEM Biomecanica da corrida — Cavanagh & Lafortune, 1980
▶ Corredor de 70 kg: GRF_pico≈175-210 kgf
048
Torque Articular
FUNDAMENTAL
tau = r × F · sin(theta)
Torque produzido por forca muscular F a distancia r do eixo articular, com angulo theta; fundamental em ergonomia e reabilitacao.
ORIGEM Biomecanica articular
▶ Quadriceps: F=500 N, r=0,05 m, theta=90° -> tau=25 N·m
049
Indice de Massa Corporal Muscular (FFMI)
FUNDAMENTAL
FFMI = FFM / altura^2; FFM = peso·(1 − BF/100)
Indice de massa livre de gordura; FFMI>25 associado ao uso de anabolizantes em estudos populacionais.
ORIGEM Kouri et al., 1995
▶ 70 kg, 15% BF, 1,75 m -> FFM=59,5 kg, FFMI=19,4
050
Equacao de Pollock (VO2max pela corrida)
FUNDAMENTAL
VO2max = 3,5 + velocidade_kmh·3,5
Estimativa de VO2max por velocidade de corrida sustentada; versao simplificada do ACSM.
ORIGEM ACSM — American College of Sports Medicine
▶ Velocidade=12 km/h -> VO2max≈42 mL/kg/min
051
Equacao de ACSM para Corrida
INTERMEDIARIO
VO2 = 0,2·v + 0,9·v·G + 3,5
Consumo de oxigenio para corrida; v=velocidade (m/min), G=inclinacao decimal; 3,5=componente de repouso.
ORIGEM ACSM Guidelines, 2010
▶ v=150 m/min, G=0 -> VO2=33,5 mL/kg/min
052
Percentual de Gordura (Siri)
INTERMEDIARIO
BF = (4,95/D − 4,50) × 100
Equacao de Siri para estimativa de gordura corporal a partir da densidade corporal D (g/mL).
ORIGEM W.E. Siri, 1956
▶ D=1,06 g/mL -> BF≈16,6%
053
Potencia de Ciclismo (Modelo de Potencia Critica)
AVANCADO
T(P) = W_linha / (P − CP); W = W_linha + CP·t
Modelo hiperbolico de resistencia a fadiga; CP=potencia critica sustentavel, W'=capacidade anaerobia.
ORIGEM Monod & Scherrer, 1965; Moritani et al., 1981
▶ CP=250 W, W'=20 kJ -> esforco a 300 W dura 400 s
054
Equacao de Lactato e Limiar Anaerobio
INTERMEDIARIO
La_corrida = La_repouso · e^(k·v)
Exponencial do lactato sanguineo com a velocidade; limiar anaerobio ≈ 4 mmol/L (OBLA); base da prescricao de treinamento.
ORIGEM Mader et al., 1976; Sjodin & Jacobs, 1981
▶ Velocidade no limiar (4 mmol/L) = velocidade de prova de meia maratona
055
Fator de Potencia de Ciclismo (FTP)
FUNDAMENTAL
FTP ≈ 0,95 × potencia_media_20min
Potencia de limiar funcional; usada para zonas de treinamento; equivale a potencia sustentavel por 1 hora.
ORIGEM Hunter Allen & Andrew Coggan, 2010
▶ Potencia media 20 min=280 W -> FTP=266 W
056
Cadencia Otima de Corrida
FUNDAMENTAL
Cadencia ≈ 180
Relacao inversa entre cadencia e tempo de contato com o solo; baixa cadencia (<160) associa-se a lesoes.
ORIGEM Jack Daniels, 1998
▶ Aumentar cadencia 5-10% reduz impacto articular
057
Equacao de Estimativa de 1RM (Brzycki)
FUNDAMENTAL
RM1 = carga / (1,0278 − 0,0278 × reps)
Estimativa da carga maxima (1 repeticao maxima) a partir de repeticoes submaximas; valido para reps<=10.
ORIGEM M. Brzycki, 1993
▶ 80 kg por 6 reps -> 1RM≈91 kg
058
Potencia de Salto (Lewis)
INTERMEDIARIO
P = 4,9·m·sqrt(h)
Potencia media de salto vertical; m=massa (kg), h=altura de salto (m); forma util e calculavel da formula de Lewis.
ORIGEM Lewis, apud Harman, 1991
▶ 70 kg, h=0,40 m -> P≈216,9 W
059
Indice de Qualidade de Movimento (FMS Score)
FUNDAMENTAL
Score_FMS = sum_score_i
Sistema de triagem de movimento funcional; 7 padroes, 0-3 pontos cada; score<14 indica disfuncao de movimento.
ORIGEM Gray Cook & Lee Burton, 1995
▶ Atleta com score=12: risco elevado de lesao
060
Indice de Forca Relativa
FUNDAMENTAL
IFR = RM1 / peso_corporal
Forca maxima normalizada pelo peso corporal; IFR>2 no agachamento classifica o atleta como avancado.
ORIGEM Biomecanica do treinamento de forca
▶ 1RM_agacha=150 kg, peso=75 kg -> IFR=2,0
Engenharia de Alimentos e Tecnologia de Processos
Conservacao de Alimentos
061
Atividade de Agua (aw)
FUNDAMENTAL
aw = p / p0 = ERH / 100
Razao entre pressao de vapor do alimento e da agua pura; aw<0,6 previne crescimento microbiano; controla vida util.
ORIGEM Scott, 1957 — microbiologia de alimentos
▶ Mel: aw≈0,6; leite em po: aw≈0,2; carne fresca: aw≈0,99
062
Valor D de Esterilizacao
FUNDAMENTAL
D = t / log(N0/N)
Tempo (min) para reduzir populacao microbiana a 1/10 a temperatura T; D121C para esporos de Clostridium botulinum≈0,25 min.
ORIGEM Microbiologia de processos termicos
▶ N0=10^6, N=10^3, t=3 min -> D=1 min
063
Valor Z de Resistencia Termica
INTERMEDIARIO
z = (T2 − T1) / log(D1/D2)
Variacao de temperatura (°C) que causa mudanca de 10x no valor D; z de C. botulinum≈10C.
ORIGEM Termoprocessamento de alimentos
▶ D121=0,25 min, D111=2,5 min -> z=10C
064
Valor F0 de Esterilizacao
INTERMEDIARIO
F0 = D121 · log(N0/N_final)
Valor letal equivalente em minutos a 121C; F0=3 min (processo minimo para alimentos enlatados de baixa acidez).
ORIGEM FDA/USDA — 21 CFR 113
▶ C. botulinum: 12-D process -> F0=3 min
065
Equacao de Arrhenius (Deterioracao de Alimentos)
INTERMEDIARIO
k = A · e^(−Ea/(R·T))
Constante de velocidade de reacao de deterioracao; Ea=energia de ativacao; base de prateleira acelerada.
ORIGEM S. Arrhenius, 1889
▶ Ea=80 kJ/mol -> aumento de 10C dobra velocidade
066
Equacao de Fick (Secagem de Alimentos)
AVANCADO
dC/dt = D_ef · laplaciano_C
Difusividade efetiva de umidade; D_ef determina velocidade de secagem; varia com temperatura e teor de umidade.
ORIGEM A. Fick, 1855 — aplicado a alimentos
▶ D_ef para amido a 60C≈10^-10 m2/s
067
Teor de Umidade em Base Seca
FUNDAMENTAL
U_bs = (m_umido − m_seco) / m_seco × 100
Base seca padrao em alimentos; facilita calculos de balanco de massa em secagem e mistura.
ORIGEM Tecnologia de alimentos
▶ 100 g alimento com 75 g agua, 25 g solidos -> U_bs=300%
068
Viscosidade Aparente (Fluido Nao-Newtoniano)
INTERMEDIARIO
tau = K · gamma_dot^n
Lei de potencia de Ostwald-de Waele; K=indice de consistencia, n<1=pseudoplastico (iogurte), n>1=dilatante.
ORIGEM Reologia de alimentos
▶ Ketchup: n≈0,27
069
Tensao de Escoamento (Bingham)
INTERMEDIARIO
tau = tau0 + eta_pl · gamma_dot
Fluido de Bingham: necessita de tensao minima tau0 para escoar; maionese, margarina se comportam assim.
ORIGEM E.C. Bingham, 1916
▶ Maionese: tau0≈30-100 Pa
070
Temperatura de Transicao Vitrea (Tg)
AVANCADO
Tg = Tg_seco − k·U
Temperatura de transicao vitrea de matriz solida de alimento; abaixo de Tg, alimento esta vitreo e estavel.
ORIGEM Teoria de estado vitreo de alimentos — Slade & Levine, 1988
▶ Acucar amorfo: Tg≈62C seco; umidade alta reduz Tg
071
Numero de Nusselt (Conveccao em Processamento)
INTERMEDIARIO
Nu = h·L / k_fluido
Adimensional de transferencia de calor convectivo; h=coeficiente convectivo, L=comprimento caracteristico, k=condutividade.
ORIGEM W. Nusselt, 1909
▶ Nu=100, k=0,6 W/mK, L=0,1 m -> h=600 W/m2K
072
Eficiencia de Extrusao (SME)
INTERMEDIARIO
SME = (P_motor × eta) / m_dot
Energia mecanica especifica na extrusao de alimentos; SME influencia textura, gelatinizacao e reacoes de Maillard.
ORIGEM Engenharia de extrusao de alimentos
▶ Extrusao de amido de milho: SME tipico=100-400 kJ/kg
073
Coeficiente de Difusao de Solutos (Stokes-Einstein)
AVANCADO
D = kB·T / (6·pi·eta·r)
Difusividade de soluto esferico de raio r em solvente de viscosidade eta; importante para sal/acucar em alimentos.
ORIGEM A. Einstein, 1905
▶ Sacarose em agua a 25C -> D≈5x10^-10 m2/s
074
Reacao de Maillard (Cinetica)
AVANCADO
dP/dt = k·A·G; k = A_pre · e^(−Ea/(R·T))
Cinetica de segunda ordem para reacao de Maillard entre aminoacido A e acucar redutor G; Ea≈100-130 kJ/mol.
ORIGEM L.C. Maillard, 1912 — cinetica revisada
▶ Assamento a 180C: cor marrom em minutos vs horas a 100C
075
Indice de Gelatinizacao (DSC)
AVANCADO
DG = (deltaH_amostra − deltaH_cozida) / deltaH_nativa × 100
Grau de gelatinizacao de amido por calorimetria diferencial de varredura; importante para digestibilidade e textura.
ORIGEM Analise termica de amidos
▶ Amido de trigo: entalpia de gelatinizacao≈8-12 J/g
076
Eficiencia de Pasteurizacao (HTST)
INTERMEDIARIO
DeltaL = Delta_t · e^((T−T_ref)/z)
Lethality rate em HTST; z=8-10C para microrganismos entericos; integracao ao longo da curva de temperatura.
ORIGEM FDA Pasteurized Milk Ordinance
▶ HTST: 72C por 15 s -> equivalente ao efeito requerido
077
Isoterma de BET (Adsorcao de Umidade)
AVANCADO
aw / (W·(1−aw)) = 1/(Wm·C) + (C−1)·aw/(Wm·C)
Isoterma de adsorcao BET para alimentos; Wm=umidade monocamada, C=constante BET; usada para embalagem.
ORIGEM Brunauer, Emmett & Teller, 1938
▶ Wm de leite em po≈0,04 g/g; aw<0,3 para estabilidade
078
Rendimento de Extracao (Processo de Prensagem)
FUNDAMENTAL
eta_ext = m_oleo_extraido / m_oleo_total × 100
Eficiencia de extracao de oleo por prensagem ou solvente; prensagem a frio: 65-70%; extracao por solvente: >95%.
ORIGEM Tecnologia de oleos e gorduras
▶ Soja com 20% oleo, extracao 98% -> 19,6 g oleo/100g
079
Numero de Reynolds em Tubulacao Alimentar
FUNDAMENTAL
Re = rho·v·D / eta
Regime de escoamento em processamento; Re<2100=laminar; Re>4000=turbulento.
ORIGEM O. Reynolds, 1883 — aplicado a alimentos
▶ Fluido viscoso, v=1 m/s, D=0,05 m, rho=1000 -> Re=500
080
Balanco de Energia em Evaporador
INTERMEDIARIO
Q = m_dot_vapor · lambda_vapor = m_dot_alimento · (h_saida − h_entrada)
Balanco de entalpia em evaporacao; lambda=calor latente de vaporizacao da agua; dimensiona evaporadores.
ORIGEM Operacoes unitarias em alimentos — McCabe & Smith
▶ Concentracao de suco: evaporar 1 kg/s agua -> Q≈2260 kW
""";
    }
}
