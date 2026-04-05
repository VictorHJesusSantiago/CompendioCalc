namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol17Parte1 = """
COMPENDIO GERAL DE EQUACOES
VOLUME XVII
Atlas Cientifico - Fundamentos e Fronteiras
Formulas ineditas ausentes dos Volumes I a XVI - Edicao 2026

Tribologia e Engenharia de Superficies
Atrito e Desgaste
001
Lei de Amonton-Coulomb (Atrito Seco)
FUNDAMENTAL
F_atrito = mu * N
Forca de atrito proporcional a carga normal N; mu=coeficiente de atrito (0,1-0,8 para metais); independente da area aparente de contato.
ORIGEM G. Amontons, 1699; C.A. Coulomb, 1781
▶ Aco sobre aco seco: mu=0,6; F=0,6*100N=60N; com lubrificante mu=0,1; F=10N

002
Area Real de Contato (Greenwood-Williamson)
AVANCADO
A_real = pi * eta_asp * beta_r * sigma_r * A_aparente * Ph
Contato real ocorre em asperezas; A_real muito menor que A_aparente; eta_asp=densidade de asperezas, beta_r=raio medio, sigma_r=rugosidade, Ph=probabilidade de Hertz.
ORIGEM Greenwood & Williamson, 1966
▶ Metais polidos: A_real entre 0,01% e 0,1% de A_aparente; controla atrito e desgaste reais

003
Lei de Desgaste de Archard
FUNDAMENTAL
W = k * F * L / H
Volume desgastado W; k=coeficiente de desgaste adimensional (1e-8 a 1e-3), F=carga normal, L=distancia deslizada, H=dureza do material macio.
ORIGEM J.F. Archard, 1953
▶ Aco endurecido k=1e-6, F=100N, L=1000m, H=7e9 Pa: W=1e-6*100*1000/7e9=0,014 mm3

004
Numero de Sommerfeld (Lubrificacao)
INTERMEDIARIO
S = (mu * N_rot / P_load) * (R_jou / c_jou)^2
Regime de lubrificacao; S alto indica filme completo hidrodinamico; mu=viscosidade dinamica, N_rot=rotacao (rev/s), P_load=pressao media, c_jou=folga radial.
ORIGEM A. Sommerfeld, 1904
▶ Mancal projetado para S>0,1 (lubrificacao hidrodinamica completa); S=0,5: regime seguro

005
Equacao de Reynolds (Filme Lubrificante Simplificada)
INTERMEDIARIO
dp_dx = 6 * mu_oil * U_surf * dh_dx / h_film^3
Gradiente de pressao no filme lubrificante 1D; h_film=espessura local, U_surf=velocidade relativa de superficies; governa capacidade de carga de mancais.
ORIGEM O. Reynolds, 1886
▶ Motor automotivo: pressao de filme ate 50 MPa a alta carga; h_film tipicamente 1-30 um

006
Contato de Hertz (Esfera em Plano)
INTERMEDIARIO
a_hertz = (3 * F * R_hertz / (4 * E_star))^(1/3)
Raio de area de contato Hertziano; E_star=modulo reduzido=E/(2*(1-nu^2)); p_max=3F/(2*pi*a^2); base de projeto de rolamentos e engrenagens.
ORIGEM H. Hertz, 1882
▶ Esfera aco D=10mm, F=100N, E_star=110GPa: a=0,21mm; p_max=1,08 GPa

007
Parametro de Lubrificacao de Stribeck
FUNDAMENTAL
lambda_film = h_min / sigma_comp
Razao de espessura de filme; sigma_comp=rugosidade composta=sqrt(Ra1^2+Ra2^2); lambda>3: lubrificacao completa; lambda<1: contato limite.
ORIGEM R. Stribeck, 1902; Johnson & Spence, 1991
▶ Motor combustao interna: diferentes regimes da curva de Stribeck ao longo do ciclo

008
Rugosidade Media Aritmetica Ra
FUNDAMENTAL
Ra = sum_abs_z / n_points
Ra=rugosidade media aritmetica; sum_abs_z=soma dos desvios absolutos do perfil; n_points=numero de pontos; Ra de torneamento: 0,8-3,2 um.
ORIGEM ISO 4287:1997 - rugosidade de superficie
▶ Ra=0,4 um: superficie retificada fina; Ra=12 um: fundição bruta; lapidada: Ra<0,025 um

009
Taxa de Desgaste por Fadiga de Contato (RCF)
AVANCADO
N_fadiga = C_rfc / tau_max^n_rfc
Vida em fadiga de contato de rolamento; tau_max=tensao maxima de cisalhamento subsuperficial; C_rfc e n_rfc=constantes do material; base da norma ISO 281.
ORIGEM Lundberg & Palmgren, 1947; ISO 281
▶ Rolamento FAG 6210: C=35kN, P=5kN; L10=(35/5)^3=343 Mrev

010
Viscosidade de Oleo - Equacao de Walther (ASTM D341)
INTERMEDIARIO
log_log_v = A_walt - B_walt * log(T_kelvin)
Relacao de Walther; log(log(v+0,7))=A-B*log(T); A_walt e B_walt=constantes do oleo; governa indice de viscosidade e selecao de lubrificantes.
ORIGEM C. Walther, 1931; ASTM D341
▶ SAE 10W-40: v=100 mm2/s a 40C; v=14 mm2/s a 100C; indice de viscosidade VI=155

011
Espessura de Filme EHL (Dowson-Higginson)
AVANCADO
h_min = 2.65 * R_ehl * (alpha_pv * E_star * U_ehl)^0.54 * (eta0 * U_ehl / (E_star * R_ehl))^0.7 * (F_ehl / (E_star * R_ehl^2))^(-0.13)
Espessura de filme elastohidrodinamico; alpha_pv=coeficiente pressao-viscosidade, eta0=viscosidade a pressao zero, U_ehl=velocidade de entrainment; garante separacao em engrenagens.
ORIGEM Dowson & Higginson, 1959
▶ Engrenagem de aco com oleo VG 100: h_min entre 0,5 e 2 um; razao de filme lambda=h_min/sigma

012
Desgaste Corrosivo - Tribocorossao
INTERMEDIARIO
W_total = W_mec + W_corro + dW_sin
Sinergismo entre desgaste mecanico e corrosao; dW_sin=componente sinergica (50-90% do total); relevante em bioengenharia (implantes metalicos) e mineracao.
ORIGEM Mischler, 2008 - Tribocorrosion
▶ Implante de quadril CoCr: tribocorrosao produz ions Co e Cr toxicos; W_mec=0,1, W_corro=0,1, dW_sin=0,4: W_total=0,6 mm3/a

013
Dureza e Resistencia ao Desgaste
FUNDAMENTAL
k_desgaste = C_kd * H^(-2.3)
Correlacao empirica; maior dureza H = menor coeficiente de desgaste k; endurecimento superficial por nitretacao, cementacao ou carbonitretacao aumenta vida.
ORIGEM Zum Gahr, 1987 - Microstructure and Wear of Materials
▶ Aco tratado H=700HV tem vida de desgaste 10-50x maior que H=200HV (k reducao ~8x)

014
Coeficiente de Tracao EHL
AVANCADO
mu_EHL = tau_lim / p_hertz
Atrito em contato elastohidrodinamico; tau_lim=tensao limitante do filme de oleo; mu_EHL tipicamente 0,04-0,08 para oleos minerais; governa CVTs.
ORIGEM Johnson & Cameron, 1967
▶ Transmissao Torotrak: mu_EHL=0,07; transmite torque por filme de oleo de alta pressao

015
Vida de Rolamento - ISO 281
FUNDAMENTAL
L10 = (C / P)^p_exp
Vida nominal de 90% dos rolamentos em Mrevolucoes; C=carga dinamica basica, P=carga equivalente; p_exp=3 para esferas, p_exp=3.333 para rolos.
ORIGEM ISO 281:2007 - Rolling bearings
▶ Rolamento 6205: C=14kN, P=2kN; L10=(14/2)^3=343 Mrevo; a 1000rpm=5716h

016
Coeficientes de Atrito Estatico e Cinetico
FUNDAMENTAL
F_estatico = mu_s * N
Atrito estatico (mu_s) maior que cinetico (mu_c); diferenca causa instabilidade stick-slip; mu_s>mu_c em todos os materiais tribologicos.
ORIGEM C.A. Coulomb, 1781 - Mecanique
▶ Aco-aco: mu_s=0,78; mu_c=0,42; diferenca de 0,36 causa rangido e chatter em maquinas

017
Angulo de Contato de Gota (Eq. de Young)
FUNDAMENTAL
cos_theta_Y = (gamma_SV - gamma_SL) / gamma_LV
Molhabilidade de superficie; theta<90: hidrofilica; theta>90: hidrofobica; theta>150: superidrofobica (efeito lotus).
ORIGEM T. Young, 1805
▶ Superficie de lotus: theta=160 (superidrofobica por micro-nanotextura); Teflon: theta=115

018
Pressao de Contato Elastico (Boussinesq)
AVANCADO
p0_bous = E_star * a_cont / (pi * R_sph)
Pressao maxima de contato Boussinesq; a_cont=raio de contato; R_sph=raio da esfera; base de analise de nanoindentacao (metodo Oliver-Pharr).
ORIGEM J. Boussinesq, 1885
▶ Nanoindentacao: curva P-h fornece modulo E e dureza H de filmes finos e revestimentos

019
Desgaste por Abrasao (Lei de Preston)
INTERMEDIARIO
MRR_pres = k_Preston * P_press * v_rel
Taxa de remocao de material (MRR); k_Preston=constante do processo; P_press=pressao de contato; v_rel=velocidade relativa; usada em CMP de chips.
ORIGEM F. Preston, 1927
▶ CMP de wafer de Si: k_Preston ajustado para planarizar a 200-400nm/min por controle de P e v

020
Tensao de Von Mises em Contato Hertziano
INTERMEDIARIO
sigma_VM_hertz = 0.31 * p_max_h
Tensao de Von Mises maxima sob superficie; ocorre a z=0,48a; exceder sigma_y do material causa deformacao plastica e spalling de rolamentos.
ORIGEM Von Mises, 1913; Johnson, 1985 - Contact Mechanics
▶ p_max=2GPa em rolamento de aco: sigma_VM=0,31*2000=620 MPa; deve ser menor que sigma_y

Fisica de Particulas e Aceleradores
Relatividade Especial e Modelo Padrao
021
Energia Total Relativistica de Einstein
FUNDAMENTAL
E_total = gamma_rel * m0 * c^2
Energia cinetica relativistica; gamma_rel=1/sqrt(1-beta^2), beta=v/c; proton: E0=938 MeV; eletron: E0=0,511 MeV; base de aceleradores de particulas.
ORIGEM A. Einstein, 1905 - Annalen der Physik
▶ LHC: protons com gamma=7460; E_total=7000 GeV por proton a 7 TeV; energia de 2 protones=14 TeV

022
Equacao de Dirac (Fermion de Spin 1/2)
AVANCADO
E_dirac = sqrt((m0 * c^2)^2 + (p_mom * c)^2)
Relacao de dispersao relativistica; equivalente a equacao de Dirac para energia-momento de fermion; previu antimateria e base da QED.
ORIGEM P.A.M. Dirac, 1928 (Nobel 1933)
▶ Eletron em repouso: E=0,511 MeV; em p=1 MeV/c: E=sqrt(0,511^2+1^2)=1,122 MeV

023
Formula de Bethe-Bloch (Perda de Energia)
AVANCADO
dE_dx = (4 * pi * e4_cgs * z_part^2 * N_av * Z_mat) / (m_e * v_part^2 * A_mat) * ln(2 * m_e * v_part^2 / I_mean)
Perda de energia ionizante por unidade de comprimento; I_mean=potencial de ionizacao medio; base de detectores de particulas e radioterapia protonica.
ORIGEM H. Bethe, 1930; F. Bloch, 1933
▶ Proton de 1 GeV em agua: dE/dx=3 MeV*cm2/g; pico de Bragg concentra dose no tumor

024
Largura de Decaimento e Tempo de Vida
INTERMEDIARIO
Gamma_dec = hbar_nat / tau_life
Largura de decaimento Gamma inversamente proporcional ao tempo de vida tau; Boson W: Gamma=2,085 GeV, tau=3e-25 s; razao de ramificacao BR_i=Gamma_i/Gamma_total.
ORIGEM PDG - Particle Data Group, 2024
▶ Muon: tau=2,197 us; Gamma=3e-19 eV; decai em eletron+neutrinos com BR=100%

025
Secao de Choque de Rutherford
INTERMEDIARIO
d_sigma_Omega = (Z1 * Z2 * e2_cgs / (4 * E_kin))^2 / sin(theta_sc/2)^4
Espalhamento coulombiano diferencial; Z1,Z2=numeros atomicos; E_kin=energia cinetica; validado por experimento de Rutherford (1911) descobrindo o nucleo atomico.
ORIGEM E. Rutherford, 1911 - Phil. Mag.
▶ Alfa em Au a 5,5 MeV, theta=150: d_sigma/d_Omega=5,2e-26 cm2/sr; confirmou nucleo compacto

026
Formula de Breit-Wigner (Ressonancia Nuclear)
INTERMEDIARIO
sigma_BW = sigma_max * (Gamma^2 / 4) / ((E_cm - E0_res)^2 + Gamma^2/4)
Secao de choque de ressonancia; E0_res=energia de ressonancia, Gamma=largura total; sigma_max=4*(2J+1)*pi/k^2; base de espectroscopia nuclear e de particulas.
ORIGEM G. Breit & E. Wigner, 1936
▶ Ressonancia Delta(1232) em pi-p: E0=1232 MeV, Gamma=120 MeV; sigma_max=150 mb

027
Comprimento de Radiacao em Materia
AVANCADO
X0 = 716.4 * A_mass / (Z_at^2 * ln(287 / sqrt(Z_at)))
Comprimento de radiacao (g/cm2); eletrons perdem 63% da energia em X0 por radiacao; base de projeto de calorímetros eletromagneticos em detectores.
ORIGEM Tsai, 1974 - Rev. Mod. Phys.
▶ Chumbo: X0=5,6 g/cm2 (0,56cm); agua: X0=36,1 g/cm2 (36 cm); calorímetro LHC usa Pb

028
Frequencia e Raio de Cicloton em Acelerador
INTERMEDIARIO
f_cyclotron = q_part * B_field / (2 * pi * m_part)
Frequencia de cicloton; r_cycl=m_part*v/(q_part*B_field); aceleradores circulares usam campo B para guiar particulas; base do LHC e ciclotrons medicos.
ORIGEM E.O. Lawrence, 1930 (Nobel 1939)
▶ LHC: B=8,3T (magnetos NbTi supercondutores); raio=2804m para protons a 7 TeV

029
Massa do Boson de Higgs e VEV
AVANCADO
m_H = sqrt(2 * lambda_higgs) * v_vev
Massa do Higgs; v_vev=valor esperado no vacuo=246 GeV; lambda_higgs=auto-acoplamento; m_H medido=125,25 GeV por ATLAS+CMS (2012).
ORIGEM Higgs, Brout & Englert, 1964; Nobel 2013
▶ m_H=125,25 GeV; decaimentos principais: H->bb (58%), H->WW* (21%), H->tau-tau (6%)

030
Luminosidade de Colisao em Acelerador
INTERMEDIARIO
L_lum = N1 * N2 * f_rev * n_bunch / (4 * pi * sigma_x * sigma_y)
Luminosidade L (cm-2s-1); governa taxa de eventos: N_ev=L*sigma; sigma_x,y=tamanho transversal do feixe; LHC record: L=2e34 cm-2s-1.
ORIGEM Aceleradores de particulas - Wilson, 1987
▶ LHC Run 3: L_pico=2e34 cm-2s-1; taxa de colisoes pp=1e9/s; 3000 fb-1 para HL-LHC

031
Invariante de Lorentz - Energia de Centro de Massa
AVANCADO
s_inv = 2 * m_p^2 * c^4 + 2 * E1 * E2 - 2 * p1 * p2 * c^2
Invariante s=energia de centro de massa ao quadrado; governa energia disponivel para producao de novas particulas em colisores de alta energia.
ORIGEM Cinematica relativistica - algebra de quadri-vetores
▶ LHC pp a 14 TeV: sqrt_s=14 TeV; disponivel para criar particulas de ate 14 TeV de massa

032
Invariante de Jarlskog (Violacao de CP)
AVANCADO
J_jarlskog = Im_part * Vus * Vcb * V_ub_conj * V_cs_conj
Invariante de Jarlskog mede violacao de CP na matriz CKM; J=3e-5; J diferente de zero e essencial para assimetria materia-antimateria no Universo.
ORIGEM C. Jarlskog, 1985
▶ Violacao de CP em B-mesons medida em BaBar e Belle com precisao de 1%; sin(2*beta)=0,69

033
Angulo de Weinberg (Mistura Eletrofraca)
AVANCADO
sin2_theta_W = 1 - (m_W / m_Z)^2
Angulo de mistura eletrofraco; sin2_theta_W=0,2312 medido com alta precisao em LEP/SLD; unifica eletromagnetismo e forca fraca no Modelo Padrao.
ORIGEM S. Weinberg & A. Salam, 1967 (Nobel 1979)
▶ M_Z=91,187 GeV; M_W=m_Z*sqrt(1-sin2_theta_W)=80,4 GeV; verificado experimentalmente

034
Decaimento Beta e Matriz CKM
INTERMEDIARIO
amplitude_beta = V_ud * G_F / sqrt(2)
Decaimento beta controlado por V_ud=0,9737 da matriz CKM; G_F=constante de Fermi=1,17e-5 GeV-2; unitariedade CKM testada a 0,1%.
ORIGEM Cabibbo, 1963; Kobayashi & Maskawa, 1973 (Nobel 2008)
▶ Neutron: n->p+e+anti-nu com tau=879s; V_ud=0,9737 determina taxa de decaimento

035
QCD - Acoplamento Forte com Liberdade Assintotica
AVANCADO
alpha_s_Q = 12 * pi / ((33 - 2 * n_f) * ln(Q^2 / Lambda_QCD^2))
Liberdade assintotica: alpha_s diminui com Q; Lambda_QCD=200 MeV; confinamento a baixo Q; Nobel 2004 (Gross, Politzer, Wilczek).
ORIGEM Gross & Wilczek; Politzer, 1973 (Nobel 2004)
▶ alpha_s(M_Z)=0,1185; alpha_s(1GeV)=0,5 (perturbatividade perdida; confinamento de quarks)

036
Emitancia de Feixe em Acelerador
AVANCADO
epsilon_beam = beta_rel * gamma_rel * sigma_x^2 / beta_x
Emitancia normalizada (m.rad); conservada sem perdas (Liouville); menor emitancia = feixe mais focado = maior luminosidade; reducao no HL-LHC.
ORIGEM Liouville, 1838; aplicado a aceleradores de particulas
▶ LHC: epsilon_n=3,75 um.rad; HL-LHC meta: 2,5 um.rad para dobrar luminosidade

037
Momento Magnetico Anomalo do Eletron (g-2)
AVANCADO
a_e = alpha_fs / (2 * pi)
Anomalia g-2 a ordem mais baixa; a_e=alpha/(2*pi)+...; calculado em QED com precisao de 1e-12 (maior precisao da fisica); discrepancia do muon: tensao de 4,2 sigma.
ORIGEM J. Schwinger, 1948; Dehmelt (Nobel 1989); Fermilab g-2, 2021
▶ a_e (teo)=0,001159652181643; a_e (exp)=0,00115965218073; acordo a 1e-11

038
Comprimento de Onda de de Broglie (Relativístico)
FUNDAMENTAL
lambda_dB = h_planck / (gamma_rel * m0 * v_part)
Comprimento de onda de particula relativistica; h=6,626e-34 Js; proton de 1 GeV/c: lambda=1,24 fm; sondeia estrutura nuclear e subnuclear.
ORIGEM L. de Broglie, 1924 (Nobel 1929)
▶ Eletron de 1 MeV: lambda=0,87 pm; sondeia estrutura atomica; eletron de 100 GeV: lambda=12 am

039
Limite de Unitariedade de Onda Parcial
AVANCADO
sigma_unitary = 4 * pi * (2 * J_spin + 1) / k_mom^2
Limite superior de secao de choque por onda parcial J; k_mom=momento da particula; violacao sem Higgs a 1,2 TeV motivou busca pelo Higgs no LHC.
ORIGEM Unitariedade da matriz-S; Lee, Quigg & Thacker, 1977
▶ Sem Higgs: WW scattering viola unitariedade a 1,2 TeV; Higgs restaura unitariedade

040
Amplitude de Feynman em QED
AVANCADO
M_QED = e_charge * ubar * gamma_mu * u_spinor * g_muv / q_mom^2
Amplitude de espalhamento eletron-eletron (Moller) a 1-loop; regras de Feynman traduzem diagrama em expressao matematica; base de calculos perturbativos em QFT.
ORIGEM R.P. Feynman, 1949 (Nobel 1965)
▶ Secao de choque de Compton calculada por diagrama de Feynman: formula de Klein-Nishina

Engenharia de Controle e Robotica
Controle Classico
041
Funcao de Transferencia (Dominio de Laplace)
FUNDAMENTAL
G_static = K_tf / (tau_m + 1)
Resposta estatica de sistema de 1a ordem; G(s)=K/(tau*s+1); polos determinam estabilidade; ganho DC = K_tf.
ORIGEM P.S. Laplace, 1820; aplicado a controle automatico
▶ Motor CC: G(s)=K_m/(tau_m*s+1); tau_m=J/B=constante de tempo mecanica; ganho DC=K_m

042
Controlador PID
FUNDAMENTAL
u_PID = Kp * e_err + Ki * integral_e + Kd * e_dot
Controlador Proporcional-Integral-Derivativo; Kp reduz erro, Ki elimina offset, Kd amorte transitorio; mais de 90% dos controladores industriais sao PID.
ORIGEM Callender, Hartree & Porter, 1936; Ziegler & Nichols, 1942
▶ Ziegler-Nichols: Ku=ganho ultimo; Tu=periodo; Kp=0,6*Ku; Ti=Tu/2; Td=Tu/8

043
Criterio de Estabilidade de Routh-Hurwitz
INTERMEDIARIO
R_H_test = a1 * a2 - a0 * a3
Criterio de 3a ordem: estavel se todos ai>0 e a1*a2>a0*a3; n mudancas de sinal na coluna 1 da tabela = n raizes no semiplano direito.
ORIGEM E.J. Routh, 1877; A. Hurwitz, 1895
▶ 3a ordem: a0=1,a1=6,a2=11,a3=6: R_H=6*11-1*6=60>0 e todos ai>0: estavel

044
Margem de Fase e Ganho (Criterio de Bode)
INTERMEDIARIO
PM = 180 + phi_gc
Margem de fase PM em graus; phi_gc=angulo de G(jw) na frequencia de cruzamento de ganho; PM>45 e GM>6dB indicam sistema robusto a variacoes de parametros.
ORIGEM H.W. Bode, 1940 - Network Analysis and Feedback Amplifier Design
▶ PM=60 graus e GM=10dB: sistema robusto; PM<20 graus: sistema oscilatorio perigoso

045
Equacao de Estado (Espaco de Estados)
FUNDAMENTAL
y_ss = C_mat * x_ss + D_mat * u_ss
Saida em estado estacionario; A=matriz de dinamica, B=controle, C_mat=saida; completamente observavel e controlavel.
ORIGEM R.E. Kalman, 1960 - Journal of Basic Engineering
▶ Sistema de 2a ordem: estados x1=posicao, x2=velocidade; A=[0,1;-wn^2,-2*zeta*wn]

046
Regulador Linear Quadratico (LQR)
AVANCADO
J_lqr = Q_lqr * x^2 + R_lqr * u^2
Custo quadratico de LQR para sistema escalar simplificado; minimizado por u*= -K*x onde K=R^-1*Bt*P, P=solucao de Ricatti; padrao em aerospace e robotica.
ORIGEM R.E. Kalman, 1960 - Contributions to the Theory of Optimal Control
▶ Estabilizacao de foguete: LQR minimiza desvio de trajetoria e esforco de controle

047
Filtro de Kalman
AVANCADO
K_kalman = P_prior * H_obs / (H_obs * P_prior * H_obs + R_noise)
Ganho de Kalman; estimacao otima de estado com ruido; minimiza erro quadratico medio; base de navegacao inercial, GPS/IMU e visao computacional.
ORIGEM R.E. Kalman, 1960 - A New Approach to Linear Filtering
▶ GPS+IMU: Kalman funde medidas ruidosas para navegacao de precisao; variancia minima

048
Cinematica de Denavit-Hartenberg
INTERMEDIARIO
T_DH = cos(theta_i) - sin(theta_i) * cos(alpha_i)
Elemento (1,1) da matriz de transformacao DH; 4 parametros (theta,d,a,alpha) descrevem cada junta; produto de 6 matrizes da pose do efetuador.
ORIGEM J. Denavit & R.S. Hartenberg, 1955
▶ PUMA 560: 6 juntas rotativas; T_0_6=T1*T2*T3*T4*T5*T6 (pose completa do efetuador)

049
Jacobiano de Robo Manipulador
INTERMEDIARIO
v_tip = J11 * q1_dot + J12 * q2_dot
Relacao entre velocidades de juntas e velocidade cartesiana do efetuador; J=matriz Jacobiana 6xn; singularidades quando det(J)=0.
ORIGEM Robotica - Paul, 1981; Spong & Vidyasagar, 1989
▶ Singularidade de cotovelo do PUMA: configuracao especifica onde Jacobiano perde rango

050
Dinamica de Manipulador (Euler-Lagrange)
AVANCADO
tau = M_iner * q_ddot + C_cor * q_dot + G_grav
Equacao geral de movimento; M_iner=matriz de inercia, C_cor=Coriolis/centrifuga, G_grav=gravidade, tau=torques de juntas; base de controle dinamico.
ORIGEM Euler-Lagrange; Luh, Walker & Paul, 1980 - IEEE Trans. Autom. Control
▶ Braco robotico de 2 elos: M 2x2 simetrico, C e G computados por algoritmo recursivo Newton-Euler

051
Controle por Modos Deslizantes (SMC)
AVANCADO
sigma_SMC = s_smc * x_state
Superficie de deslizamento sigma=s*x=0; controle u=u_eq+u_sw garante alcance da superficie; robusto a incertezas e perturbacoes limitadas.
ORIGEM V.I. Utkin, 1977 - IEEE Trans. Autom. Control
▶ Robo com carga variavel: SMC mantem precisao de posicionamento sem retuning de ganhos

052
Planejamento de Trajetoria Trapezoidal
FUNDAMENTAL
x_trap = v_max^2 / (2 * a_max)
Distancia de aceleracao no perfil trapezoidal; completa com fase constante e desaceleracao simetrica; limita aceleracao e jerk em CNC e robos industriais.
ORIGEM Engenharia de robotica - Siciliano, 2010
▶ Move de 100mm em 0,5s com a_max=1m/s2: v_max=0,5m/s; x_acl=0,125m; perfil simetrico

053
Controle Preditivo Baseado em Modelo (MPC)
AVANCADO
J_mpc = Q_mpc * (x_mpc - r_ref)^2 + R_mpc * u_mpc^2
Custo MPC escalar por horizonte; minimizado com restricoes de estado e entrada; padrao em processos quimicos, redes de energia e veiculos autonomos.
ORIGEM Cutler & Ramaker, 1979; Garcia & Morshedi, 1989
▶ Tesla Autopilot usa MPC para seguimento de trajetoria com restricoes de faixa de pista

054
Odometria de Robo Diferencial
INTERMEDIARIO
x_next = x_curr + (d_r + d_l) / 2 * cos(phi_curr)
Estimacao de posicao por odometria de encoders; acumulacao de erros cresce com distancia; corrigido por SLAM ou fusao com sensores externos.
ORIGEM Robotica movel - Siegwart & Nourbakhsh, 2004
▶ Robo diferencial com encoders de 1000 pulsos/rev; drift de posicao cresce com distancia percorrida

055
Teoria de Passividade (Controle de Energia)
AVANCADO
V_pass = 0.5 * m_sys * v_sys^2 + 0.5 * k_sys * x_sys^2
Funcao de Lyapunov de energia cinetica+potencial; sistema e passivo se V_dot<=u^T*y; garante estabilidade de robo colaborativo com humano.
ORIGEM J.C. Willems, 1972 - Archive for Rational Mechanics; N. Hogan, 1985
▶ Controle de impedancia: robo colaborativo cede elasticamente quando operador empurra

056
Cinematica Inversa por Pseudo-Inversa
AVANCADO
q_dot_IK = J_pseudo * x_dot_target
J_pseudo=Jt*(J*Jt)^-1 (pseudo-inversa direita); solucao de minima norma para q_dot; projecao (I-J+J)*z para tarefas secundarias.
ORIGEM Whitney, 1969 - Journal of Dynamic Systems; Nakamura & Hanafusa, 1986
▶ Robo de 7 DOF redundante: grau extra usado para evitar obstaculos enquanto rastreia trajetoria

057
Criterio de Nyquist (Estabilidade de Malha Fechada)
INTERMEDIARIO
N_encircle = Z_right - P_ol
Numero de encirculamentos do ponto (-1,0) no plano de Nyquist; Z_right=zeros no SPD da malha fechada, P_ol=polos no SPD da malha aberta; N=0 e P=0: estavel.
ORIGEM H. Nyquist, 1932 - Bell System Technical Journal
▶ Grafico de Nyquist que nao encircunda (-1,0): sistema em malha fechada garantidamente estavel

058
SLAM por Pose Graph (Factor Graph)
AVANCADO
x_star = sum((f_ij_xi_xj - z_ij)^2 / omega_ij)
Minimizacao de erros de restricoes de pose; resolvido por Gauss-Newton ou Levenberg-Marquardt; base de robotica de entrega e veiculo autonomo.
ORIGEM Lu & Milios, 1997; Grisetti et al., 2010 (g2o)
▶ Robo de entrega autonomo: SLAM constroi mapa e localiza simultaneamente em ambiente desconhecido

059
Controle Adaptativo MRAC (Regra MIT)
AVANCADO
theta_dot = -Gamma_adapt * e_mrac * phi_mrac
Lei de adaptacao MIT; theta=parametros adaptaveis; Gamma_adapt=taxa de adaptacao; garante convergencia de e para zero seguindo modelo de referencia.
ORIGEM Whitaker, Yamron & Kezer, 1958 - MIT Rule
▶ Aeronave com mudanca de massa de combustivel: MRAC mantem desempenho de resposta

060
Estabilidade de Lyapunov
FUNDAMENTAL
V_lyap = 0.5 * m_sys * v_sys^2 + 0.5 * k_sys * x_sys^2
Funcao candidata de energia; V>0, V(0)=0 e V_dot<=0 garantem estabilidade do equilíbrio; base de controle nao-linear.
ORIGEM A.M. Lyapunov, 1892 - Probleme General de la Stabilite du Mouvement
▶ Sistema massa-mola-amortecedor: V=0,5*m*v^2+0,5*k*x^2; V_dot=-b*v^2 menor ou igual a 0

Geoquimica e Geocronologia
Geocronologia Isotopica
061
Datacao Rb-Sr (Isocrana Isotopica)
INTERMEDIARIO
Sr87_Sr86 = Sr87_Sr86_0 + Rb87_Sr86 * (exp(lambda_Rb * t) - 1)
Isocrana Rb-Sr; lambda_Rb=1,42e-11 a-1; t1/2=48,8 Ga; data rochas igneas e metamorficas de idade maior que 100 Ma.
ORIGEM Nicolaysen, 1961 - isocrana Rb-Sr
▶ Granito de 2 Ga enriquecido em Sr87/Sr86 vs valor inicial por acumulacao de Sr87 radiogenico

062
Datacao U-Pb (Concordia de Wetherill)
INTERMEDIARIO
Pb206_U238 = exp(lambda238 * t) - 1
Razao Pb206/U238; segunda equacao: Pb207/U235=exp(lambda235*t)-1; concordia: acordo entre dois cronometros confirma idades de fechamento isotopico.
ORIGEM C.C. Patterson, 1956 - idade da Terra; Wetherill, 1956
▶ Zircao de Jack Hills (Austrália): 4,404 Ga - mineral mais antigo da Terra conhecido

063
Temperatura de Fechamento Isotopico (Dodson)
AVANCADO
Tc_dod = E_a / (R_gas * ln(A_freq * R_gas * D0 / (a_diff^2 * E_a / dT_dt_cool)))
Temperatura de fechamento de sistema isotopico; hornblenda Tc=500C (Ar-Ar); apatita Tc=110C (fissao/U-He); base de termocronologia crustal.
ORIGEM M.H. Dodson, 1973 - Contributions to Mineralogy and Petrology
▶ Trilha de fissao em apatita: Tc=110C revela historia termal de soerguimento crustal

064
Coeficiente de Particao de Elementos Traco
INTERMEDIARIO
D_part = C_mineral / C_melt
Coeficiente de particao mineral/fundido; D>>1: elemento compativel (concentra em mineral); D<<1: incompativel (concentra no fundido); base de petrogênese.
ORIGEM Shaw, 1970 - Geochimica et Cosmochimica Acta
▶ Ba: D_feldspato=2-10 (compativel); Nb: D_cpx=0,01 (incompativel); governa magmatismo

065
Modelo de Fusao em Lote (Batch Melting)
INTERMEDIARIO
C_L = C0_melt / (D_part + F_melt * (1 - D_part))
Concentracao no liquido de fusao em lote; F_melt=fracao fundida; elemento incompativel (D->0): C_L/C0=1/F; grandes enriquecimentos a baixo F.
ORIGEM Shaw, 1970 - Geochimica et Cosmochimica Acta 34
▶ F=1%: elemento com D=0,01 concentrado 99x no liquido; fonte de magmas OIB enriquecidos

066
Serie de Reacao de Bowen (Estabilidade de Silicatos)
FUNDAMENTAL
T_cryst = T_olivina - n_step * 50
Temperatura de cristalizacao aproximada em serie de Bowen; olivina (~1300C) a quartzo (~600C); governa sequencia de minerais em rochas igneas resfriando.
ORIGEM N.L. Bowen, 1928 - The Evolution of Igneous Rocks
▶ Basalto resfriando: olivina -> cpx -> plagioclasio calcico -> mais sodico -> biotita -> feldspato K

067
Inclinacao de Reacao de Metamorfismo (Clapeyron)
AVANCADO
dP_dT_metam = dS_rxn / dV_rxn
Inclinacao de curva de reacao em P-T por equacao de Clapeyron; base de calculo de P-T de formacao de rochas metamorficas; dP/dT negativo: eclogito de alta pressao.
ORIGEM E. Clapeyron, 1834; termodinamica de metamorfismo
▶ Reacao jadeita+quartzo=albita: dP/dT negativo e inclinado e evidencia de alta pressao

068
Isótopo Estavel delta18O (Paleoclima)
INTERMEDIARIO
delta18O = (R_sample_O / R_VSMOW - 1) * 1000
Fraccionamento de O18/O16 vs padrao VSMOW; glaciacoes reduzem delta18O no oceano; calibrado por equacao de Epstein para paleotemperatura oceanica.
ORIGEM H.C. Urey, 1947; Emiliani, 1955 - paleoceanografia
▶ Glacial maximo: delta18O de foraminifera +1 por mil; oceano mais frio em 4C por glaciacao

069
Condutividade Eletrica de Rocha Porosa (Lei de Archie)
INTERMEDIARIO
sigma_rock = sigma0 * phi_ar^m_arch
Lei de Archie para rocha porosa saturada; m_arch=expoente de cimentacao (1,5-2,5); sigma crustal medida por sondagem magnetotelurica.
ORIGEM G.E. Archie, 1942 - Trans. AIME
▶ Crosta granitica seca: sigma=1e-5 S/m; com fluido salino a phi=0,05: sigma=0,01 S/m

070
Entalpia de Fusao de Rocha (Geoquimica)
AVANCADO
H_fus_rock = Cp_rock * dT_melt + dH_L
Calor necessario para fundir rocha; Cp_rock=calor especifico medio; dH_L=entalpia de fusao latente; basalto: H_fus=400-500 J/g; base de modelagem de vulcanismo.
ORIGEM Carmichael, 1977 - Geotermia magmatica; Annual Review of Earth Sciences
▶ Camara magmatica de 10 km3 ao cristalizar libera 1e19 J; equivale a 1e4 bombas atomicas

071
Datacao por Trilhas de Fissao
AVANCADO
rho_ratio = (lambda_f / lambda_D) * (exp(lambda_D * t_fiss) - 1) / (zeta_ft * rho_d)
Razao de densidades de trilhas; lambda_f=constante de fissao de U238; Tc=110C para apatita; base de termocronologia de soerguimento crustal.
ORIGEM Price & Walker, 1963 - Science; Wagner, 1968
▶ Apatita em embasamento: idade de trilha de fissao de 20 Ma indica erosao de 10 km de crosta

072
Anomalia Geoquimica de Iridio (Fronteira K-Pg)
FUNDAMENTAL
Ir_enrichment = Ir_KPg / Ir_crustal
Fator de enriquecimento de Ir; Ir_KPg=40 ppb, Ir_crustal=0,02 ppb; fator=2000; assinatura de impacto meteorico; confirmou hipotese de Alvarez (1980).
ORIGEM L. Alvarez et al., 1980 - Science
▶ Camada K-Pg em Gubbio (Italia): Ir=40 ppb; confirma impacto de asteróide de 10 km

073
Gradiente Geotermico Continental
FUNDAMENTAL
T_z = T_sup + G_geot * z
Temperatura crustal; G_geot=gradiente geotermico (25-30 C/km continental, >50 C/km em riftes); governa janela de petroleo e recursos geotermicos.
ORIGEM Chapman, 1986 - Review of Geophysics
▶ Janela de petroleo: 60-120C; profundidade 2-4 km em bacia sedimentar tipica (G=30 C/km)

074
Padrao de Terras Raras Normalizado
INTERMEDIARIO
REE_norm = REE_sample / REE_chondrite
Padrao de REE normalizado por condrito; anomalia de Eu indica fracionamento de feldspato; base de discriminacao de proveniencia sedimentar e petrologica.
ORIGEM Sun & McDonough, 1989 - Chemical Society Publication
▶ MORB: padrao plano; OIB: enriquecido em LREE; sedimento crustal: anomalia Eu negativa forte

075
Isocrana Lu-Hf (Petrogenese Metamorfica)
AVANCADO
Hf176_Hf177 = Hf176_Hf177_0 + Lu176_Hf177 * (exp(lambda_Lu * t_LuHf) - 1)
lambda_Lu=1,867e-11 a-1; Lu-Hf robusta em sistemas metamorficos de alta pressao; complementa Sm-Nd; data pico metamorfico de granada.
ORIGEM Scherer et al., 2001 - Earth and Planetary Science Letters
▶ Eclogito de crosta oceanica subductada: Lu-Hf data pico metamorfico a 2-4 GPa

076
Temperatura de Liquidus de Silicato
INTERMEDIARIO
T_liq = T_liq0 - k_H2O * H2O_pct
Temperatura de liquidus diminui com adicao de H2O; k_H2O aprox 25 C/% H2O; governa profundidade de fusao parcial e cristalizacao de magmas.
ORIGEM Kushiro, 1969 - American Journal of Science
▶ MORB seco: T_liq=1250C; adicao de 1% H2O reduz T_liq em 25C; H2O fluidifica magma

077
Velocidade Sismica e Composicao (Lei de Birch)
AVANCADO
Vp_birch = a_birch * rho_mat + b_birch * M_bar
Vp proporcional a densidade rho e massa media M_bar; base de determinacao de composicao do manto por sismologia global; Vp manto superior: 7,9-8,2 km/s.
ORIGEM F. Birch, 1961 - Geophysical Journal
▶ Vp=8,1 km/s no manto superior corresponde a olivina com rho=3,3 g/cm3 (a_birch=3,16)

078
Isótopo de Carbono delta13C em Materia Organica
FUNDAMENTAL
delta13C = (R13C_sample / R13C_VPDB - 1) * 1000
Fraccionamento isotopico por fotossintese; plantas C3: delta13C=-25 a -30 por mil; C4: -12 a -16 por mil; base de paleodieta e rastreamento de carbono.
ORIGEM Craig, 1953 - Geochimica et Cosmochimica Acta
▶ Dente humano pre-historico vs moderno: delta13C rastreia mudanca para dieta de milho (C4)

079
Ponto Critico do CO2 Supercritico
FUNDAMENTAL
P_crit_CO2 = 7.39
Pressao critica do CO2 em MPa; T_crit=304,25 K (31,1 C); acima do ponto critico: fluido supercritico com propriedades intermediarias entre liquido e gas.
ORIGEM Termodinamica de fluidos supercriticos - Andrews, 1869
▶ Sequestro de CO2 em aquiferos a >800m: P>7,4 MPa e T>31C: CO2 supercritico e denso

080
Razao Sm-Nd e Epsilon-Nd (Manto vs Crosta)
INTERMEDIARIO
eps_Nd = ((Nd143_Nd144_s / Nd143_Nd144_CHUR) - 1) * 10000
Epsilon-Nd positivo: fonte de manto empobrecido (MORB); negativo: crosta antiga ou manto enriquecido; traça mistura manto-crosta em magmas.
ORIGEM DePaolo & Wasserburg, 1976 - Geophysical Research Letters
▶ MORB: eps_Nd=+10; granito crustal antigo: eps_Nd=-10 a -20; mistura rastreavel

""";
    }
}
