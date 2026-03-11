namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol17Parte3 = """
Dinamica de Fluidos Computacional (CFD)
Metodos Numericos e Simulacao
161
Equacoes de Navier-Stokes (NS Incompressivo)
AVANCADO
a_fluid = (-dP_dx + mu_dyn * d2u_dy2) / rho_fl
Aceleracao de fluido por gradiente de pressao e tensao viscosa (1D simplificada); N-S completas incluem termos inerciais, graviacionais e convectivos.
ORIGEM C.L.M.H. Navier, 1822; G.G. Stokes, 1845 - Transactions Cambridge Phil. Soc.
▶ Escoamento em microcanal: Re<<1 (Stokes); perfil parabolico de Poiseuille calculado por NS

162
Modelo de Turbulencia k-epsilon (k-e)
AVANCADO
dk_dt = nu_t / sigma_k * d2k_dx2 + Pk - epsilon_k
Equacao de transporte de energia cinetica turbulenta k; Pk=producao; epsilon_k=dissipacao; nu_t=C_mu*k^2/epsilon_k; par com equacao de epsilon.
ORIGEM Jones & Launder, 1972 - International Journal Heat Mass Transfer
▶ Escoamento em duto industrial: k-epsilon captura pressao e velocidade media com custo computacional moderado

163
Lei de Parede em Escoamento Turbulento
FUNDAMENTAL
u_plus = (1 / kappa_von) * ln(y_plus) + B_kappa
Perfil de velocidade adimensional; kappa_von=0,41 (constante de Von Karman); B_kappa=5,0; valido para y+=30-300 (lei log); base de modelos de parede em CFD.
ORIGEM Von Karman, 1930; Prandtl, 1925 - ZAMM
▶ Canal em Re=10^6: u+=2,44*ln(y+)+5; skimming layer a y+<5; buffer layer 5-30

164
Metodo de Volumes Finitos (FVM) - Balanco
FUNDAMENTAL
sum_phi_f = sum_Gamma_nabla_phi + S_vol * V_cell
Balanco FVM: soma de fluxos nas faces = soma de difusao + termo fonte; base de OpenFOAM, Fluent e CFX; conservativo por construcao.
ORIGEM Patankar, 1980 - Numerical Heat Transfer and Fluid Flow
▶ CFD industrial: FVM resolve NS em malhas de 1e6 a 1e9 celulas; escalonavel em clusters HPC

165
Numero de Courant-Friedrichs-Lewy (CFL)
FUNDAMENTAL
CFL = u_vel * dt_cfd / dx_mesh
CFL<1: condicao de estabilidade explicita; CFL<0,5: recomendado para simulacoes DNS; solvers implicitos permitem CFL>>1 mas com acuracia temporal limitada.
ORIGEM Courant, Friedrichs & Lewy, 1928 - Mathematische Annalen
▶ DNS de turbulencia: CFL=0,3 necessario; solver implicito PISO: CFL=5-10 aceitavel

166
Espessura de Camada Limite de Blasius (Placa Plana)
FUNDAMENTAL
delta_BL = 5 * x_BL / sqrt(Re_x)
Espessura de camada limite laminar; Re_x=rho*U*x/mu; transicao a Re_x=5e5; base de aerodinamica de asa e projeto de difusores.
ORIGEM H. Blasius, 1908 - Grenzschichten in Flussigkeiten
▶ Asa de aviao: Re_x=1e6 a 1m da LE; delta=5*1/sqrt(1e6)=5mm; transicao a 50-80cm

167
Equacao de Lattice-Boltzmann (LBM)
AVANCADO
f_i_new = f_i_old + (f_i_eq - f_i_old) / tau_lbm
Funcao de distribuicao de populacoes em rede de Boltzmann; tau_lbm=tempo de relaxacao; recupera NS para escoamentos de baixo Mach; paralelizacao GPU eccellente.
ORIGEM McNamara & Zanetti, 1988; Shan & Chen, 1993 - Physical Review
▶ LBM em GPU: simula fluxo em meio poroso 3D com 1e9 nos em tempo real; superior a FVM para geometrias complexas

168
Metodo de Elementos Finitos (FEM) em Fluidos
INTERMEDIARIO
u_FEM = F_ext / K_stiff
Equacao matricial FEM em forma compacta; K_stiff=matriz de rigidez; base do solver de Stokes fraco; COMSOL e FEniCS usam FEM para NS.
ORIGEM Zienkiewicz & Cheung, 1965 - The Engineer; FEM para fluidos desde 1970s
▶ Simulacao de fluxo em valvula cardiaca: FEM com malha adaptatva ao ciclo cardiaco

169
Metodo de Elementos de Contorno (BEM)
AVANCADO
u_BEM = (u_star_f - q_star_u) * A_area
Formulacao BEM em contorno apenas; dimensao reduzida; eficiente para problemas de Stokes e potencial; base de simulacao de microfluidos e acustica.
ORIGEM Brebbia & Walker, 1980 - Boundary Element Techniques
▶ Microfluidos em nanocanais: BEM eficiente por reduzir problema 3D para superficie 2D do canal

170
Modelo de Spalart-Allmaras (Turbulencia 1eq)
AVANCADO
nu_t = Cb1 * S_tilde * nu_til - Cw1 * fw * (nu_til / d_wall)^2
Variavel de trabalho de Spalart-Allmaras; Cb1=0,1355; Cw1=Cb1/kappa^2; simples e robusto para aerodinamica com gradiente de pressao leve.
ORIGEM Spalart & Allmaras, 1992 - AIAA-92-0439
▶ Asa de aviao em cruzeiro: SA modelo padrao em CFD aerodinamico (menor custo que k-epsilon)

171
Algoritmo SIMPLE (Semi-Implicit Pressure-Velocity)
INTERMEDIARIO
p_new = p_old + p_corr
Pressao corrigida por equacao de Poisson de correcao; SIMPLE iterativo ate convergencia de continuidade; base de Fluent e OpenFOAM para NS incompressivel.
ORIGEM Patankar & Spalding, 1972 - International Journal Heat Mass Transfer
▶ Escoamento em curva de tubulacao: SIMPLE converge em 100-500 iteracoes para Re=10^5

172
Numero de Richardson (Estratificacao)
FUNDAMENTAL
Ri = g_grav * drho_dz / (rho_fl * (du_dz)^2)
Ri<1/4: instabilidade de Kelvin-Helmholtz; Ri>>1: estratificacao estavel suprime turbulencia; governa mistura em atmosfera, oceano e reservatorios.
ORIGEM L.F. Richardson, 1920 - Proceedings Royal Society London
▶ Inversao de temperatura: Ri>>1; turbulencia suprimida; poluentes presos na camada limite est.

173
Tensor de Tensoes Sub-Grade (LES-SGS)
AVANCADO
tau_SGS_ij = -2 * nu_t_LES * S_bar_ij
Tensor sub-grade em LES; nu_t_LES=C_s^2*delta^2*|S_bar|; modelo de Smagorinsky; C_s=0,1-0,2; captura grandes escalas e modela escalas menores.
ORIGEM Smagorinsky, 1963 - Monthly Weather Review; Deardorff, 1970
▶ LES de jet turbulento: capta estruturas coerentes; mais preciso que RANS para instabilidades

174
Metodo Multigrid (Convergencia Acelerada)
AVANCADO
T_MG = C_MG / (N_cells * log(N_cells))
Complexidade de multigrid; convergencia em O(N) operacoes vs O(N^2) para metodos diretos; AMG (algebraic multigrid) padrao em CFD de grande escala.
ORIGEM Brandt, 1977 - Mathematics of Computation
▶ Poisson em malha 1024^3: multigrid em 10^9 operacoes; Gauss-Seidel precisaria 10^18

175
Metodo do Gradiente Conjugado (CG Solver)
INTERMEDIARIO
r_k1 = r_k - alpha_cg * A_mat * d_k
Residuo no metodo do gradiente conjugado; alpha_cg=r^T*r/(d^T*A*d); converge em N iteracoes para matriz positiva definida; base de solvers lineares esparsos.
ORIGEM Hestenes & Stiefel, 1952 - Journal of Research NIST
▶ Sistema linear de NS linearizado: CG com precondicionador ILU converge em 50-200 iteracoes

176
Velocidade de Flutter Aeroelastico
AVANCADO
V_flutter = sqrt(omega_bend * omega_tors) * L_span
Velocidade critica de flutter estimada pela raiz dos produtos de frequencias de flexao e torcao; acima de V_flutter: instabilidade aeroelastica de asa.
ORIGEM Theodorsen, 1935 - NACA TR-496; Bisplinghoff & Ashley, 1955
▶ Asa de aviao comercial: V_flutter calcula 15% acima de VD (design dive speed); certifica FAR 25.629

177
Coeficiente de Sustentacao Aerodinamica (Asa Fina)
FUNDAMENTAL
CL = 2 * pi * (alpha_aoa + alpha_L0)
Teoria de asa fina; alpha_aoa=angulo de ataque (rad); alpha_L0=angulo de zero lift; slope=2*pi/rad; base de projeto de perfis e analise linear de asa.
ORIGEM N.E. Joukowski, 1906; Munk & von Karman, 1920
▶ NACA 0012 a alpha=5: CL=2*pi*5*(pi/180)=0,548; comparado com CFD: diferenca <5% para Re>1e6

178
Coeficiente de Arrasto (Formula Polar)
FUNDAMENTAL
CD = CD0_polar + CL^2 / (pi * e_Oswald * AR)
Arrasto induzido por sustentacao; CD0_polar=arrasto de perfil; e_Oswald=eficiencia de Oswald; AR=razao de aspecto; base de performance de aeronaves.
ORIGEM Prandtl, 1918 - teoria de linha sustentadora
▶ Planador de competicao: AR=30; e=0,95; CD_ind=CL^2/(pi*0,95*30); L/D maximo de 50

179
Metodo de Diferencas Finitas (FD) Explicito
FUNDAMENTAL
T_next = T_curr + r_FD * (T_right - 2 * T_curr + T_left)
Equacao de difusao de calor pelo metodo explicito; r_FD=alpha*dt/dx^2; estabilidade requer r_FD<0,5; base de solucoes numericas de EDP de difusao.
ORIGEM Richardson, 1910; Crank & Nicolson, 1947 - Proceedings Cambridge Phil. Soc.
▶ Difusao de calor em aco apos soldagem: FD calcula campo de temperatura e zona afetada pelo calor

180
Norma de Residuo e Convergencia CFD
FUNDAMENTAL
res_norm = sqrt(sum(r_i^2)) / sqrt(sum(r0_i^2))
Norma L2 do residuo relativo ao residuo inicial; convergencia tipica em CFD: res < 1e-4 para campos de velocidade; 1e-6 para temperatura.
ORIGEM Ferziger & Peric, 2002 - Computational Methods for Fluid Dynamics
▶ Solver de NS: residuo cai de 1 para 1e-5 em 500 iteracoes; criterio de convergencia verificado

Climatologia e Ciencias da Atmosfera
Modelagem Climatica
181
Forcante Radiativa de CO2 (IPCC)
FUNDAMENTAL
dF_CO2 = 5.35 * ln(C_CO2 / C0_CO2)
Forcante radiativa de CO2 em W/m2; dobrar CO2 (2xCO2): dF=3,7 W/m2; base de calculo de sensibilidade climatica do IPCC.
ORIGEM Myhre et al., 1998 - Geophysical Research Letters; IPCC AR6, 2021
▶ CO2 de 280 para 420 ppm: dF=5,35*ln(420/280)=5,35*0,405=2,17 W/m2 forcante atual

182
Sensibilidade Climatica de Equilíbrio (ECS)
INTERMEDIARIO
ECS = delta_T_eq / dF_2xCO2
ECS em C por W/m2; dF_2xCO2=3,7 W/m2; ECS=2,5-4C provavel (IPCC AR6); alta ECS implica maior aquecimento para mesmo CO2.
ORIGEM Charney et al., 1979 - Climate Sensitivity; IPCC AR6, 2021
▶ ECS=3C implicano 1,5C de aquecimento adicional com o CO2 atual; meta de Paris: <2C de aquecimento total

183
Temperatura de Equilíbrio Radiativo Planetario
FUNDAMENTAL
T_eq = ((1 - alpha_alb) * S0 / (4 * epsilon_eff * sigma_SB))^0.25
Temperatura de equilíbrio planetario; alpha_alb=albedo medio (0,30 Terra); S0=1361 W/m2; T_eq=255 K sem efeito estufa; T_obs=288 K = +33K de efeito estufa.
ORIGEM Arrhenius, 1896; Stefan-Boltzmann - termodinamica
▶ Marte: alpha=0,25, S0/4=144 W/m2: T_eq=210 K; Vênus: albedo=0,77; T_eq=227 K<732 K (obs)

184
Parametro de Feedback Climatico
AVANCADO
lambda_fb = lambda0 - sum_fi
Parametro de feedback total; lambda0=resposta sem feedback; fi=forcante de cada feedback (vapor d'agua, albedo de gelo, nuvens); lambda negativo = estavel.
ORIGEM Bony et al., 2006 - Journal of Climate; Hansen et al., 1984
▶ Feedback de vapor d'agua: f=1,8 W/(m2*K); albedo de gelo: f=0,3; nuvens: incerto (-0,5 a+0,5)

185
Modelo de Balanco de Energia de 0D
INTERMEDIARIO
C_heat * dT_dt = (1 - alpha_alb) * S0 / 4 - epsilon_eff * sigma_SB * T^4 + dF_CO2
Balanco de energia global simplificado; C_heat=capacidade calorifica do oceano; equilibrio em milanos de anos; perturbado por dF_CO2.
ORIGEM Budyko, 1969; Sellers, 1969 - Journal of Applied Meteorology
▶ T de equilíbrio calculado para dobro de CO2: T_new=T_old+ECS; anos para equilibrio: tau=C_heat/lambda_fb

186
Indice de Oscilacao do Sul (ENSO/ENOS)
FUNDAMENTAL
ONI_index = SST_Nino34 - SST_ref
Indice de Nino3.4 em graus Celsius acima da normal; ONI>0,5 por 5 meses: El Nino; ONI<-0,5: La Nina; ciclicidade de 3-7 anos.
ORIGEM Walker, 1924; Bjerknes, 1969 - ENSO hypothesis
▶ El Nino de 2015-16: ONI pico de +2,5C; seca no Brasil NE; chuvas no Peru; corais branqueados no Pacifico

187
Anomalia de Temperatura Global (SAT)
FUNDAMENTAL
delta_SAT = T_obs_yr - T_baseline_ref
Anomalia de temperatura superficial em relacao ao baseline (pre-industrial 1850-1900); anomalia 2023: +1,48C (record); limiar de Paris: 1,5C.
ORIGEM Hansen et al., 1981 - Science; HadCRUT5; NOAA GlobalTemp
▶ 2023: anomalia global de +1,48C (record absoluto); primeira vez acima de 1,5C em media anual

188
Ciclo de Carbono Atmosferico
INTERMEDIARIO
dC_atm_dt = E_fossil + E_LUC - C_ocean - C_land
Balanco de carbono atmosferico; E_fossil=10 GtC/a (2023); C_ocean=2,7 GtC/a; C_land=3 GtC/a; acumulacao atmosferica=4,3 GtC/a.
ORIGEM Global Carbon Project, 2023; Friedlingstein et al.
▶ CO2 atmosferico: 280 ppm pre-industrial; 421 ppm em 2023; crescendo 2,4 ppm/a desde 2019

189
Elevacao do Nivel do Mar (SLR Global)
INTERMEDIARIO
SLR = delta_steric + delta_Greenland + delta_Antarctica + delta_glaciers
Contribuicoes ao SLR; expansao termica: 1,9mm/a; Groelandia: 0,6mm/a; Antartica: 0,5mm/a; glaciares: 0,6mm/a; total: ~3,6 mm/a (acelerado).
ORIGEM IPCC AR6 Ocean Chapter; Bamber et al., 2019
▶ SLR projetado para 2100: 0,3-1,0 m em cenario moderado; critico para cidades costeiras

190
Espectro de Energia Turbulenta (Kolmogorov)
AVANCADO
E_k = C_K * epsilon_turb^(2/3) * k_turb^(-5/3)
Lei de -5/3 de Kolmogorov; C_K=1,5; epsilon_turb=taxa de dissipacao; escala inercial transfere energia da grande para pequena escala; universal em turbulencia.
ORIGEM A.N. Kolmogorov, 1941 - Doklady Akademii Nauk
▶ Turbulencia atmosferica: escala energetica de km (forcante sinoptica); escala de Kolmogorov: mm; cascata de -5/3

191
Saturacao de Vapor d'Agua (Magnus Formula)
FUNDAMENTAL
e_sat_T = 611 * exp(17.67 * T_celsius / (T_celsius + 243.5))
Pressao de vapor saturado em Pa; T em Celsius; duplica a cada ~10C; base de calculo de umidade relativa, ponto de orvalho e precipitacao.
ORIGEM Magnus, 1844; Murray, 1967 - Journal Applied Meteorology; Bolton, 1980
▶ T=20C: e_sat=2338 Pa; T=30C: e_sat=4243 Pa; UR=90% a 30C: e=3819 Pa e Td=28,3C

192
Orcamento de Carbono Restante (Limite de Paris)
FUNDAMENTAL
CB_remain = 500
Orcamento de carbono restante em GtCO2 para 50% de chance de limitar aquecimento a 1,5C (base 2023); emissoes atuais: 37 GtCO2/a; ~13 anos ao ritmo atual.
ORIGEM IPCC AR6 SPM, 2021; Global Carbon Project
▶ 1,5C (67%): 360 GtCO2; 2,0C (67%): 1150 GtCO2; necessidade de zeragem em 2050 para 1,5C

193
Potencial de Aquecimento Global (GWP)
INTERMEDIARIO
GWP = int_RF_gas / int_RF_CO2
Razao de forcantes radiativas integradas em 100 anos; CH4: GWP100=27; N2O: GWP100=273; HFCs: GWP100>1000; base de reducao de emissoes de gases nao-CO2.
ORIGEM IPCC AR6 WG1 Table 7.15, 2021
▶ CH4: GWP20=81; reduzir metano tem impacto de curto prazo maior que CO2; meta de Iniciativa Global do Metano

194
Espectro de Ondaleta Climatica
AVANCADO
X_spectral = sum(X_nm * Y_nm)
Decomposicao espectral de anomalias climaticas em modos de variabilidade (ENSO, PDO, AMO); Y_nm=funcoes de base esfericas; base de predictibilidade de 10-30 anos.
ORIGEM Torrence & Compo, 1998 - Bulletin American Meteorological Society
▶ PDO (60 anos): modula precipitacao no norte da America; AMO (70 anos): furacoes no Atlantico

195
Temperatura de Bulbo Umido (Steinhart-Hart Simplificado)
FUNDAMENTAL
T_wb = T_dry - (T_dry - T_dew) / 3
Aproximacao de temperatura de bulbo umido; valida para umidade relativa moderada; base de calculo de conforto termico, psicrometria e resfriamento evaporativo.
ORIGEM Davies, 1938; ASHRAE Handbook of Fundamentals
▶ T_dry=35C, T_dew=25C: T_wb=35-(35-25)/3=31,7C; indice de WBGT considera radiacao solar

196
Acidificacao dos Oceanos por CO2
AVANCADO
delta_pH_oc = -delta_pCO2 / (10 * beta_Revelle)
Mudanca de pH com aumento de CO2 na atmosfera; historicamente pH caiu de 8,2 para 8,1 (delta=-0,1); projetado -0,3 unidades ate 2100 em cenario RCP8.5.
ORIGEM Caldeira & Wickett, 2003 - Nature; IPCC SROCC, 2019
▶ pH atual de 8,1 corais dissolve com pH<7,9 (aragonita undersaturado); impacto em recifes

197
Fluxo de CO2 Oceano-Atmosfera
INTERMEDIARIO
F_CO2_oc = k_pist * (pCO2_atm - pCO2_ocean) * K0_sol
Fluxo de carbono oceano-atmosfera; k_pist=coeficiente de piston=velocidade de transferencia de gas; K0_sol=coeficiente de solubilidade de CO2; sumidouro: F<0.
ORIGEM Takahashi et al., 2009 - Deep-Sea Research; SOCAT dataset
▶ Oceano absorve ~2,7 GtC/a; gelo polar derretido e aquecimento oceanico reduzem sumidouro futuro

198
Formula de Arrhenius Climatica (Temperatura vs CO2)
FUNDAMENTAL
delta_T_Arr = 1.6 * ln(C_CO2_new / C0_CO2_ref)
Relacao empirica inicial de Arrhenius; mais precisa com ECS=3C: delta_T=3*ln2/ln2=3C para 2xCO2; base historica da climatologia moderna.
ORIGEM S. Arrhenius, 1896 - London, Edinburgh, and Dublin Phil. Mag.
▶ Arrhenius previu 5C de aquecimento para 2xCO2; valor atual do IPCC: 2,5-4C (concordancia qualitativa)

199
Formula IPAT (Impacto Ambiental)
INTERMEDIARIO
CO2_total = P_pop * G_gdp_cap * E_energy / G_ref * CO2_factor
Identidade de Kaya; CO2 proporcional a populacao x PIB/cap x use de energia x intensidade de carbono; base de metas de decarbonizacao.
ORIGEM Kaya & Yokobori, 1993; IPCC Working Group III
▶ Kaya: reduzir CO2 requer eficiencia energetica, descarbonizacao de energia ou reducao economica

200
Projecao de Temperatura para 2100 (RCP)
FUNDAMENTAL
delta_T_2100 = 4.3
Aquecimento mediano projetado em RCP8.5 (sem medidas) em graus Celsius; RCP4.5: 2,4C; RCP2.6: 1,6C; Paris 1,5C requer zero liquido de emissoes em 2050.
ORIGEM IPCC AR5 SPM Table SPM.2, 2013; atualizado AR6, 2021
▶ RCP8.5 implica aumento de 0,7-1,2 m no nivel medio do mar; 1e6 de especies extintas; risco existencial

Optica Quantica e Informacao Quantica
Fenomenos Quanticos e Computacao
201
Estado de Bell e Emaranhamento Bipartido
AVANCADO
E_Bell = -cos(a_angle - b_angle)
Correlacao de Bell para estado singlet em medidas de spin; viola inequacao de Bell (|S|<=2) pois S_max=2*sqrt(2)=2,83 para estados de Bell.
ORIGEM J.S. Bell, 1964 - Physics; Aspect et al., 1982 - Physical Review Letters
▶ Experimento de Aspect: viola inequacao de Bell por 5 sigma; prova nao-localidade quantica

202
Taxa de Erro Qubit em QKD (QBER)
INTERMEDIARIO
QBER = N_wrong / N_total
Taxa de erro em distribuicao quantica de chave; QBER<11%: protocolo BB84 seguro; QBER>11%: canal comprometido por espionagem; base de criptoanalise quantica.
ORIGEM Bennett & Brassard, 1984 (BB84); Ekert, 1991 (E91)
▶ QKD comercial: QBER<4% em links de fibra de 100 km; distancia record: 500 km com repetidores

203
Frequencia de Rabi em Acoplamento Luz-Materia
INTERMEDIARIO
omega_Rabi = g_JC * sqrt(n_phot + 1)
Frequencia de Rabi em cavidade quantica (Jaynes-Cummings); g_JC=acoplamento vacuo; oscilacoes Rabi entre |e,n> e |g,n+1>; regime de acoplamento forte.
ORIGEM Jaynes & Cummings, 1963 - Proceedings of the IEEE; QED de cavidade, Nobel 2012
▶ QED de circuito: g/2pi=200 MHz; acoplamento forte atingido em microssegundos de coerencia

204
Fidelidade de Estado Quantico
INTERMEDIARIO
F_fid = (psi0_id * psi0_re + psi1_id * psi1_re)^2
Fidelidade de estado puro F=|<psi_ideal|psi_real>|^2; F=1: estado perfeito; F=0,99: erro de ~1%; meta de computadores quanticos falha tolerantes: F>0,999.
ORIGEM Jozsa, 1994 - Journal of Modern Optics
▶ IBM Quantum: fidelidade de porta de 2 qubits: F=0,99 (supercondutores); F=0,999 em traps de ions

205
Porta Hadamard (Superposicao Quantica)
FUNDAMENTAL
amplitude_H = 1 / sqrt(2)
Porta Hadamard cria superposicao; |0>->(|0>+|1>)/sqrt(2); amplitude=1/sqrt(2) para cada estado; base de algoritmos de Grover e de Deutsch.
ORIGEM Hadamard, 1893 (matematica); aplicado a computacao quantica por Deutsch, 1985
▶ Computador quantico de 50 qubits: Hadamard cria superposicao de 2^50 = 10^15 estados simultaneamente

206
Numero de Iteracoes do Algoritmo de Grover
INTERMEDIARIO
N_Grover = pi / 4 * sqrt(N_db)
Numero de iteracoes para amplificar estado alvo em busca nao estruturada; speedup quadratico vs classico (O(N)); N_db=tamanho do banco de dados.
ORIGEM L.K. Grover, 1996 - ACM Symposium on Theory of Computing
▶ N=1e6 entradas: N_Grover=pi/4*1000=785 queries vs 500000 (classico medio); speedup de 637x

207
Codigo de Correcao de Erros de Shor (9 Qubits)
AVANCADO
N_qubits_Shor = 9
Primeiro codigo de correcao de erros quanticos; 1 qubit logico protegido por 9 fisicos; corrige erros de bit e de fase; base de computacao tolerante a falhas.
ORIGEM P.W. Shor, 1995 - Physical Review A
▶ Codigo de superficie (surface code): 100-1000 qubits fisicos por qubit logico; mais pratico para hardware

208
Funcao de Wigner (Estado de Gato de Schrodinger)
AVANCADO
W_neg = -(1 - exp(-2 * abs_alpha^2)) / pi
Funcao de Wigner negativa de estado de gato; negatividade = nao-classicalidade; estados de gato com amplitude alpha; relevante para computacao bosonista.
ORIGEM E.P. Wigner, 1932 - Physical Review; Schrodinger cat: 1935
▶ Estado de gato optico com alpha=2: W negativa em origem; decoerencia destrui gato em microsegundos

209
Emissao Estimulada e Fotonica (Relacao de Einstein)
FUNDAMENTAL
N_stim = B_Einstein * rho_nu * N2_pop
Taxa de emissao estimulada; B_Einstein=coeficiente de Einstein B; rho_nu=densidade espectral de radiacao; N2_pop=populacao do estado excitado; base de laser.
ORIGEM A. Einstein, 1917 - Physikalische Zeitschrift
▶ A/B=8*pi*h*nu^3/c^3; em equilíbrio termico: razao de emissao espont/estimulada governa threshold do laser

210
Teleportacao Quantica (Fidelidade)
AVANCADO
F_teleport = (d_dim + 1) / (d_dim * (d_dim + 1))
Fidelidade media de teleportacao; d_dim=dimensao do sistema (d=2 para qubit); limite classico=2/3; teleportacao quantica supera sempre esse limite; d=2: F_max=5/6.
ORIGEM Bennett et al., 1993 - Physical Review Letters
▶ Experimento de teleportacao em fibra: F=0,87>2/3; record: 1200 km via satelite Micius (2017)

211
Numero Medio de Fotons em Estado Coerente
FUNDAMENTAL
n_photon = abs_alpha_coh^2
Estado coerente gerado por laser; |alpha> autovetor do operador de aniquilacao; n_photon=|alpha|^2=numero medio de fotons; distribuicao de Poisson.
ORIGEM R. Glauber, 1963 (Nobel 2005) - Physical Review
▶ Laser com 1 mW a 1550 nm: n_photon por segundo = 7,8e15; |alpha|=2,8e7 por ns

212
Limite de Ruido de Shot em Sensores Quanticos
FUNDAMENTAL
SNR_shot = sqrt(N_photon)
Razao sinal-ruido limitada por shot noise; SNR cresce como raiz de N; estados espremidos abaixo do shot noise limit; base de interferometria LIGO.
ORIGEM Kelvin, 1982; LIGO Collaboration, 2015 - Physical Review Letters
▶ LIGO: uso de estados de vacio espremidos reduz shot noise; melhora sensibilidade para deteccao de ondas gravitacionais

213
Complexidade de Fatoracao de Shor
AVANCADO
T_Shor = (log(N_int))^3
Complexidade de Shor em portas quanticas; exponencialmente mais rapido que melhor classico (sub-exponencial); RSA-2048 vulneravel a computador quantico de 4000 qubits logicos.
ORIGEM P.W. Shor, 1994 - SIAM Journal on Computing
▶ RSA-2048: computador quantico de 4000 qubits logicos quebraria em horas; motivou PQC (post-quantum criptografia)

214
Tempo de Decoerencia T2 (Coherencia de Fase)
FUNDAMENTAL
T2_phase = 2 * T1_relax
Limite superior de decoerencia de fase; T1=tempo de relaxacao; T2<=2*T1; fonetica de ions em armadilha: T2=10 min; superconductores: T2=100-500 us.
ORIGEM Bloch, 1946 - Physical Review; NMR e computacao quantica
▶ Trap de ions Yb+: T1=10 min, T2=10 s; supercondutores transmon: T1=200 us, T2=100 us

215
Matrix de Divisor de Feixe (Beam Splitter)
INTERMEDIARIO
r_BS = sqrt(R_reflectance)
Coeficiente de reflexao do divisor de feixe; |r|^2=R (refletividade); |t|^2=1-R (transmissividade); base de interferometros Mach-Zehnder e Hong-Ou-Mandel.
ORIGEM Zeilinger, 1981; Hong, Ou & Mandel, 1987
▶ BS de 50:50: r=1/sqrt(2); interferencia HOM perfeita quando fotons identicos: coincidencias=0

216
Representacao de Bloch (Qubit na Esfera de Bloch)
FUNDAMENTAL
amplitude_0 = cos(theta_q / 2)
Amplitude do estado |0> no qubit; |psi>=cos(theta/2)|0>+exp(i*phi_q)*sin(theta/2)|1>; polo norte=|0>; polo sul=|1>; visualizacao geometrica do qubit.
ORIGEM Bloch, 1946; Feynman, Vernon & Hellwarth, 1957
▶ Porta X (NOT) mapeia polo norte para sul; Hadamard: mapeamento para equador da esfera de Bloch

217
Inequacao de CHSH (Nao-Localidade)
FUNDAMENTAL
S_CHSH = 2 * sqrt(2)
Valor maximo quantico de S na inequacao de CHSH; classico: |S|<=2; quantico: |S|<=2*sqrt(2)=2,83; violacao confirma emaranhamento.
ORIGEM Clauser, Horne, Shimony & Holt, 1969 - Physical Review Letters (Nobel 2022)
▶ Experimento do Nobel 2022 (Aspect, Clauser, Zeilinger): S=2,81; viola CHSH com 5+ sigma de significancia

218
Efeito Hong-Ou-Mandel (HOM)
AVANCADO
P_coinc = (1 - V_HOM * cos(omega_freq * delta_tau)) / 2
Probabilidade de coincidencia em interfer. HOM; V_HOM=visibilidade (1 para fotons identicos); delta_tau=atraso; dip de HOM: P_coinc=0 para fotons identicos.
ORIGEM Hong, Ou & Mandel, 1987 - Physical Review Letters
▶ HOM com fotons de telecom: V=0,995; base de repeticadores quanticos e computacao linear de otica

219
Limite de Heisenberg em Sensores
FUNDAMENTAL
delta_phi_H = 1 / N_sensor
Sensibilidade limite de Heisenberg; delta_phi proporcional a 1/N (vs 1/sqrt(N) classico); estado NOON e GHZ atingem este limite.
ORIGEM Giovannetti, Lloyd & Maccone, 2004 - Science; Heisenberg, 1927
▶ Interferometro de Ramsey com 10 ions: delta_phi=0,1 rad (Heisenberg) vs 0,32 (shot noise)

220
Eficiencia de Detector de Foton Unico (SNSPD)
FUNDAMENTAL
eta_det = N_detected / N_incident
Eficiencia de detector de foton unico; SNSPD: eta>95% a 1550 nm; APD: eta~30%; relevante para QKD, LIDAR e experimentos de optica quantica.
ORIGEM Gol'tsman et al., 2001 - Applied Physics Letters; SNSPD by NIST
▶ SNSPD de NbN: eta=98%; jitter=3 ps; dark count<1 Hz; base de QKD de longa distancia

Estruturas Metalicas e Engenharia Estrutural
Analise e Projeto de Estruturas
221
Critenio de Von Mises para Fluencia (Biaxial)
FUNDAMENTAL
sigma_VM = sqrt(sigma1^2 + sigma2^2 - sigma1 * sigma2)
Tensao de Von Mises biaxial; inicio de plasticidade quando sigma_VM = sigma_y; conservador vs Tresca; padrao de projeto de estruturas AISC e Eurocode 3.
ORIGEM R. von Mises, 1913 - Gottinger Nachrichten Mathematik-Physik
▶ Tubulacao pressurizada: sigma1=pR/t (circunferencial), sigma2=pR/(2t) (axial); VM<sigma_y garantido

222
Carga Critica de Flambagem de Euler
FUNDAMENTAL
P_cr = pi^2 * E * I / (K_eff * L)^2
Carga critica de flambagem de coluna; K_eff=fator de comprimento efetivo (1,0 apoiado-apoiado; 0,5 engastado-engastado); base de projeto de elemetos comprimidos.
ORIGEM L. Euler, 1757 - Academie des Sciences Berlin
▶ Pilar HEA300 de aco A36: E=200 GPa, I_y=6310 cm4, L_ef=5 m; P_cr=5000 kN; P_comp<0,5*P_cr tipico

223
Tensao de Flexao em Viga
FUNDAMENTAL
sigma_flex = M_bend * y_dist / I_sec
Tensao de flexao por distancia y da linha neutra; sigma maxima nas fibras extremas; base de projeto de vigas de aco, concreto e madeira.
ORIGEM Bernoulli, 1705; Navier, 1826 - Resumé de Lecons
▶ Viga IPE 300: I=8360 cm4, y=150 mm; M=100 kN.m: sigma=100e6*0,15/8360e-8=179 MPa (<355 MPa)

224
Fator de Amplificacao Dinamica (DAF)
INTERMEDIARIO
DAF = 1 / sqrt((1 - r_ratio^2)^2 + (2 * zeta_dyn * r_ratio)^2)
Amplificacao de resposta dinamica; r_ratio=omega_excit/omega_n; ressonancia em r=1: DAF=1/(2*zeta_dyn); base de projeto de estruturas submetidas a cargas dinamicas.
ORIGEM Den Hartog, 1956 - Mechanical Vibrations
▶ Ponte pedo-viaria: DAF=1,5; pedestres podem excitar a 2 Hz; ponte com wn=2 Hz em risco de ressonancia

225
Curva de Wohler (Fadiga de Aco)
INTERMEDIARIO
N_cycles = C_SN / delta_sigma^m_SN
Vida em fadiga de Wohler; m_SN=3 (aco); C_SN=constante do material; limite de fadiga de aco: 0,4*sigma_u; base de calculo de vida de estruturas ciclicas.
ORIGEM A. Wohler, 1858; Eurocode 3 - Annex D (fadiga)
▶ Delta_sigma=150 MPa em aco S355: N=2e6 ciclos (6,3 anos a 10 ciclos/dia) na curva D de Eurocode

226
Regra de Dano de Miner-Palmgren
FUNDAMENTAL
D_Miner = n1 / N1 + n2 / N2
Dano acumulado por cargas de amplitudes variadas; D>=1: falha; base de analise de fadiga em espectros de carga de pontes, aeronaves e turbinas eolicas.
ORIGEM A. Palmgren, 1924; Miner, 1945 - Journal of Applied Mechanics
▶ Viga de aco: D=(5e5/2e6)+(1e5/5e5)=0,25+0,20=0,45 < 1; vida residual disponivel

227
Coeficiente de Resposta Sísmica (Sa)
FUNDAMENTAL
Sa = ag * S_soil * eta_damp
Aceleracao espectral de projeto; ag=aceleracao de referencia; S_soil=fator de solo; eta_damp=coeficiente de amortecimento; base de ASCE7 e Eurocode 8.
ORIGEM Newmark & Hall, 1982; Eurocode 8 (EN 1998-1)
▶ Sa em Rio de Janeiro: ag=0,15g, S=1,35 (solo B); Sa=0,20g para estrutura convencional zeta=5%

228
Tensao em Solda de Angulo
INTERMEDIARIO
tau_weld = F_weld / (0.707 * a_weld * l_weld)
Tensao de cisalhamento em solda de angulo; a_weld=garganta efetiva; fator de 0,707 para angulo de 45; base de calculo de soldas de AISCy Eurocode 3.
ORIGEM AWS D1.1:2020 - Structural Welding Code
▶ Solda de a=6mm, l=100mm, F=50kN: tau=50e3/(0,707*0,006*0,1)=117 MPa (<0,6*fy=213 MPa)

229
Indice de Esbeltez de Aba de Perfil
FUNDAMENTAL
lambda_slim = b_flange / t_flange
Esbeltez de aba de perfil; lambda<9: classe 1 (plastico); 9<lambda<14: classe 2; 14<lambda<21: classe 3; >21: classe 4 (flambagem local governa).
ORIGEM Eurocode 3 - EN 1993-1-1 Tabela 5.2; AISC 360-22
▶ HEA 400: b/t=7,9 (classe 1); RHS 200x100x6: aba longa b/t=15 (classe 3 para aco S355)

230
Capacidade de Projeto LRFD (Resistencia Fatorada)
FUNDAMENTAL
phi_Rn = phi * Rn
Resistencia fatorada; phi=fator de reducao de resistencia (0,9 para flexao, 0,6 para cisalhamento em chapas); LRFD: phi*Rn >= sum(gamma_i * Q_i).
ORIGEM AISC 360-22 - Specification for Structural Steel Buildings
▶ Viga IPE 360, Mn=150 kN.m: phi*Mn=0,9*150=135 kN.m; carga fatorada deve ser menor que 135 kN.m

231
Momento Critico de Flambagem Lateral de Viga
AVANCADO
M_cr_LTB = pi / L_b * sqrt(E * I_y * G * J + (pi * E / L_b)^2 * I_y * C_w)
Momento critico de flambagem lateral-torsional; L_b=comprimento nao-travado; J=constante de torsao de St-Venant; C_w=constante de empenamento.
ORIGEM Timoshenko, 1905; Bleich, 1952 - Buckling Strength of Metal Structures
▶ IPE 550 com L_b=5 m: M_cr calculado e comparado com M_y para determinar fator de flambagem lateral

232
Flecha Maxima de Viga Uniformemente Carregada
FUNDAMENTAL
delta_max = 5 * w_dist * L_span^4 / (384 * E * I)
Flecha maxima de viga bi-apoiada com carga distribuida uniforme q; limite tipico: L/250 a L/400; governante em projeto de estruturas de piso.
ORIGEM Resistencia dos Materiais - Timoshenko & Gere, 1972
▶ Viga IPE 400, L=8m, E=200GPa, I=23130cm4, w=20kN/m: delta=5*20*8^4/(384*200e9*23130e-8)=18mm

233
Temperatura Critica de Aco em Incendio
FUNDAMENTAL
T_crit_steel = 550
Temperatura critica do aco em graus Celsius; abaixo: reducao de 40% da resistencia; acima de 550C: colapso iminente; base de projeto de protecao passiva ao fogo.
ORIGEM Eurocode 3 - EN 1993-1-2 (Fire); ASTM E119
▶ Incendio padrao ISO 834: 550C atingidos em 15-30 min; protecao por spray, board ou intumescente necesaria

234
Resistencia de Parafuso (Cisalhamento)
FUNDAMENTAL
Vn_bolt = n_sh * Fv * Ab * phi_bolt
Resistencia nominal de parafuso em cisalhamento; n_sh=numero de planos; Fv=tensao nominal (0,45*Fu); Ab=area nominal; phi_bolt=0,75.
ORIGEM AISC 360-22 J3.6; Eurocode 3 EN 1993-1-8
▶ Parafuso A325 de 20mm, 1 plano: Vn=0,75*0,45*825*314e-6=87 kN; juncao tipica de aco

235
Momento Plastico de Secao
FUNDAMENTAL
Mp = Fy * Zx
Momento plastico de secao; Zx=modulo plastico da secao; Mp/My=Zx/Sx=fator de forma; tipo 1 da secao permite redistribuicao de momentos em estruturas.
ORIGEM AISC 360-22 F2; Eurocode 3 EN1993-1-1 6.2.5
▶ IPE 270: Zx=395 cm3; aco S275 (Fy=275 MPa); Mp=0,395*275e3=108,6 kN.m

236
Pressao de Vento por ASCE/SEI 7
FUNDAMENTAL
q_design = 0.613 * Vk^2
Pressao de velocidade em Pa; Vk=velocidade de referencia em m/s; multiplica-se por coeficientes de pressao Cp e fator de exposicao Kz para carregar estrutura.
ORIGEM ASCE/SEI 7-22 Chapter 26-27; ISO 4354
▶ Vento de 60 m/s (Cat 5): q=0,613*60^2=2207 Pa; forca em fachada de edifício com Cp=0,8: p=1766 Pa

237
Efeito de 2a Ordem em Estruturas (P-Delta)
INTERMEDIARIO
M_2nd = M0 * B2_pdelta
B2_pdelta=1/(1-P/P_cr); amplificacao de momento por deslocamento lateral; critico em edificios altos (B2>1,15: analise direta de 2a ordem obrigatoria).
ORIGEM Galambos, 1998; AISC 360-22 Appendix 8
▶ Edificio de 20 andares com P_cr=20000 kN, P=4000 kN: B2=1/(1-0,2)=1,25; M final 25% maior

238
Combinacao de Acoes (ABNT NBR 6118 / ASCE 7)
FUNDAMENTAL
F_comb = 1.2 * D_dead + 1.6 * L_live
Combinacao de carregamento mais critica para projetos de aco e concreto segundo LRFD/NBR; outras: 1,2D+1,6S+1,0L ou 1,2D+1,0L+1,0E.
ORIGEM ASCE/SEI 7-22 Section 2.3; ABNT NBR 7190 (madeira); NBR 6118 (concreto)
▶ D=15 kN/m, L=20 kN/m: F=1,2*15+1,6*20=18+32=50 kN/m (governante vs 0,9D+1,0W para vento)

239
Flambagem Local de Chapa (Timoshenko)
AVANCADO
sigma_cr_plate = k_buck * pi^2 * E / (12 * (1 - nu^2)) * (t_plate / b_plate)^2
Tensao critica de flambagem de chapa; k_buck=coeficiente de flambagem (4 para compressao uniforme com bordas apoiadas); base de resistencia de paredes de reservatorios.
ORIGEM Timoshenko & Gere, 1961 - Theory of Elastic Stability
▶ Chapa de aco t=6mm, b=300mm, E=200GPa: sigma_cr=4*pi^2*200e9/(12*0,91)*(6/300)^2=74 MPa

240
Resistencia de Solda a Penetracao Total (CJP)
FUNDAMENTAL
phi_CJP = phi_weld * Fw * A_weld
Resistencia de solda de penetracao total (CJP); Fw=0,6*FEXX (tensao de tração); baseada na resistencia do metal de solda; governante para juntas de alta carga.
ORIGEM AWS D1.1:2020 Clausula 6.2; AISC 360-22 J2.4
▶ Solda CJP com E71T-1 (FEXX=70ksi=483 MPa): Fw=0,6*483=290 MPa; Rn=290*A_solda

""";
    }
}
