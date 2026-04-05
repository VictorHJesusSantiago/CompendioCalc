namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol16Parte2 = """
Neurociencia Computacional e Redes Neurais Biologicas
Modelos de Neuronio
041
Equacao de FitzHugh-Nagumo
INTERMEDIARIO
dv_dt = v - v^3/3 - w + I; dw_dt = epsilon*(v+a-b*w)
Modelo reduzido de excitabilidade neuronal.
ORIGEM FitzHugh, 1961; Nagumo, 1962
▶ Reproduz disparos e oscilacoes
042
Leaky Integrate-and-Fire
FUNDAMENTAL
tau_m*dV_dt = -(V-V_rest)+R_m*I
Neurônio de disparo por limiar com vazamento.
ORIGEM Lapicque, 1907
▶ Spike quando V>=V_th
043
Regra de Hebb
FUNDAMENTAL
delta_w = eta*x_i*x_j
Plasticidade sinaptica correlacional.
ORIGEM Hebb, 1949
▶ Base de memoria associativa
044
STDP
AVANCADO
delta_w = A_plus*exp(-delta_t/tau_plus)
Plasticidade dependente da ordem temporal pre-pos.
ORIGEM Markram et al., 1997
▶ LTP para delta_t positivo
045
Capacidade de Hopfield
INTERMEDIARIO
C = 0.14*N
Capacidade aproximada de armazenamento.
ORIGEM Hopfield, 1982
▶ Limite para recuperacao robusta
046
Wilson-Cowan
AVANCADO
dE_dt = (-E + S(aEE*E-aEI*I+P))/tauE; dI_dt = (-I + S(aIE*E-aII*I+Q))/tauI
Dinamica de populacoes excitatoria/inibitoria.
ORIGEM Wilson & Cowan, 1972
▶ Oscilacoes de rede E-I
047
Difusao de Neurotransmissor
AVANCADO
dc_dt = D*lap_c - k*c
Difusao e decaimento na fenda sinaptica.
ORIGEM Biofisica sinaptica
▶ Escala temporal sub-milisegundo
048
Kuramoto
AVANCADO
dtheta_i_dt = omega_i + (K/N)*sum_sin_delta
Sincronizacao de osciladores acoplados.
ORIGEM Kuramoto, 1975
▶ Transicao de fase para K critico
049
Kalman para Decodificacao Neural
INTERMEDIARIO
x_hat = x_pred + K_k*(z_k - H*x_pred)
Estimacao de estado motor a partir de spikes.
ORIGEM Kalman, 1960
▶ Uso em interfaces cerebro-computador
050
Informacao Mutua Neural
AVANCADO
I_SR = sum_p_sr*log(p_sr/(p_s*p_r))
Informacao transmitida por respostas neurais.
ORIGEM Shannon, 1948
▶ Bits por spike
051
PSD por FFT
FUNDAMENTAL
PSD = abs(FFT_x)^2/N
Densidade espectral de potencia para EEG.
ORIGEM Welch, 1967
▶ Analise de bandas delta-theta-alpha
052
Conectividade BOLD
FUNDAMENTAL
FC = corr(BOLD_i,BOLD_j)
Correlacao funcional entre regioes.
ORIGEM Biswal et al., 1995
▶ Redes de repouso
053
Causalidade de Granger
AVANCADO
GC = ln(var_eps_y/var_eps_yx)
Direcionalidade de informacao temporal.
ORIGEM Granger, 1969
▶ Fluxo funcional dirigido
054
Filtro de Gabor
AVANCADO
g_xy = exp(-(x_p^2+gamma^2*y_p^2)/(2*sigma^2))*cos(2*pi*x_p/lambda+psi)
Modelo de campo receptivo em V1.
ORIGEM Daugman, 1985
▶ Sensivel a orientacao/frequencia
055
Frequencia de Ressonancia Neuronal
AVANCADO
f_res = sqrt(max(gh/(C_m*g_l),0))/(2*pi)
Aproximacao da ressonancia subthreshold.
ORIGEM Hutcheon & Yarom, 2000
▶ Banda theta no hipocampo
056
Esparsidade de Treves-Rolls
AVANCADO
S = (1-((sum_r/N)^2/(sum_r2/N)))/(1-1/N)
Indice de codigo esparso.
ORIGEM Treves & Rolls, 1991
▶ S proximo de 1 indica alta esparsidade
057
Equacao de Goldman-Hodgkin-Katz
INTERMEDIARIO
V_m = (R*T/F)*ln((P_K*K_o+P_Na*Na_o+P_Cl*Cl_i)/(P_K*K_i+P_Na*Na_i+P_Cl*Cl_o))
Potencial de membrana com multiplos ions.
ORIGEM Goldman, 1943; Hodgkin & Katz, 1949
▶ Vm de repouso negativo
058
Small World
INTERMEDIARIO
sigma_sw = (C/C_rand)/(L/L_rand)
Indice small-world em conectomas.
ORIGEM Watts & Strogatz, 1998
▶ sigma maior que 1
059
Hipotese do Cerebro Bayesiano
AVANCADO
p_posterior = p_likelihood*p_prior
Inferencia probabilistica de causas sensoriais.
ORIGEM Helmholtz; Knill & Pouget
▶ Priors afetam percepcao
060
Integral de Caminho para Inferencia
AVANCADO
P_x_given_y = integral_likelihood_prior
Inferencia de trajetorias latentes em modelos de estado.
ORIGEM State-space models
▶ Aproximacoes por filtros

Engenharia Termica e Sistemas de Resfriamento
Conducao de Calor
061
Lei de Fourier
FUNDAMENTAL
q = -k*A*dT_dx
Fluxo de calor por conducao.
ORIGEM Fourier, 1822
▶ Materiais com k alto conduzem melhor
062
Coeficiente Global U
FUNDAMENTAL
U = 1/(1_h1 + sum_e_over_k + 1_h2 + R_fouling)
Resistencia termica global em trocadores.
ORIGEM McAdams, 1954
▶ Fouling reduz U
063
LMTD
FUNDAMENTAL
LMTD = (dT1-dT2)/ln(dT1/dT2)
Diferenca media logaritmica de temperatura.
ORIGEM Transferencia de calor classica
▶ Base para Q=U*A*LMTD
064
Stefan-Boltzmann
FUNDAMENTAL
q_rad = epsilon*sigma*A*T^4
Radiacao termica de corpo cinza.
ORIGEM Stefan, 1879; Boltzmann, 1884
▶ Cresce com T^4
065
Dittus-Boelter
INTERMEDIARIO
Nu = 0.023*Re^0.8*Pr^n
Correlacao de conveccao forcada turbulenta.
ORIGEM Dittus & Boelter, 1930
▶ h elevado em altos Re
066
Eficiencia de Aleta
INTERMEDIARIO
eta_aleta = tanh(m*L)/(m*L)
Eficiencia de transferencia em aletas.
ORIGEM Schmidt, 1926
▶ eta reduz para aletas longas/com h alto
067
COP de Carnot
FUNDAMENTAL
COP = T_frio/(T_quente-T_frio)
Limite superior de refrigeracao.
ORIGEM Carnot, 1824
▶ COP real abaixo do ideal
068
Resistencia Termica de Juncao
FUNDAMENTAL
T_j = T_amb + Pd*(Rjc+Rcs+Rsa)
Temperatura de juncao em eletronica.
ORIGEM MIL-HDBK-251
▶ Controle termico de chips
069
Limite Capilar de Heat Pipe
AVANCADO
Q_max = cap_term*(cap_press-gravity_term)
Capacidade maxima por limitacao capilar.
ORIGEM Grover, 1963
▶ Projeto de pipes para eletronica
070
Numero de Biot
FUNDAMENTAL
Bi = h*L_c/k
Compara resistencias interna e externa.
ORIGEM Biot, 1804
▶ Bi<0.1: modelo concentrado
071
Modulo Peltier
INTERMEDIARIO
Q_cold = alpha*I*T_c - I^2*R/2 - K*dT
Capacidade de remocao em TEC.
ORIGEM Peltier, 1834
▶ COP depende de dT
072
Rohsenow para Ebuliacao
AVANCADO
q_pp = C_rohsenow*deltaT_e^3
Correlacao de ebulicao nucleada.
ORIGEM Rohsenow, 1952
▶ Alto fluxo em superaqueecimento moderado
073
Armazenamento por PCM
FUNDAMENTAL
Q_pcm = m*(cp_s*(Tm-Ti)+h_lat+cp_l*(Tf-Tm))
Energia sensivel + latente em PCM.
ORIGEM Telkes, 1952
▶ Alta densidade energetica
074
Difusividade Termica
FUNDAMENTAL
alpha_th = k/(rho*cp)
Velocidade de propagacao de calor.
ORIGEM Fourier, 1822
▶ Materiais leves condutivos tem alpha alto
075
Efeito Chamine
INTERMEDIARIO
Q = Cd*A*sqrt(2*g*H*(Ti-Te)/Ti)
Vazao por ventilacao natural.
ORIGEM ASHRAE
▶ Diferenca termica aumenta fluxo
076
NTU-efetividade
INTERMEDIARIO
NTU = U*A/C_min; epsilon = eps_ntu
Metodo para trocadores com saida desconhecida.
ORIGEM Kays & London, 1950
▶ Evita iteracao LMTD
077
Escoamento Interno Aquecido
INTERMEDIARIO
q_pp = Q/(pi*D*L)
Fluxo termico uniforme em tubos.
ORIGEM Conveccao interna classica
▶ Projeto de aquecedores lineares
078
Churchill-Chu
AVANCADO
Nu = (0.825+0.387*Ra^(1.0/6)/((1+(0.492/Pr)^(9.0/16))^(8.0/27)))^2
Conveccao natural em placa vertical.
ORIGEM Churchill & Chu, 1975
▶ h moderado sem ventilacao forcada
079
Torre de Resfriamento Adiabatica
AVANCADO
T_saida = T_bs - (T_bs-T_bu)*(1-exp(-NTU_tower))
Aproximacao de saida em torres.
ORIGEM Merkel, 1926
▶ T_saida se aproxima do bulbo umido
080
Geracao de Entropia
INTERMEDIARIO
Sdot_gen = Qdot/T_boundary - Qdot/T_source
Medida de irreversibilidade termodinamica.
ORIGEM Clausius, 1865
▶ Minimizacao reduz destruicao de exergia

""";
    }
}
