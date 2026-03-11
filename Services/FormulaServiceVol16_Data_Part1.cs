namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol16Parte1 = """
COMPENDIO GERAL DE EQUACOES
VOLUME XVI
Horizontes do Conhecimento - Ciencias Integradas
Fórmulas inéditas ausentes dos Volumes I a XV - Edicao 2026

Robotica Avancada e Controle de Robos
Cinematica
001
Cinematica Direta de Denavit-Hartenberg
AVANCADO
T_i = Rot_z(theta_i)*Trans_z(d_i)*Trans_x(a_i)*Rot_x(alpha_i)
Matriz de transformacao homogenea entre elos consecutivos; theta=angulo de junta, d=offset, a=comprimento, alpha=torcao.
ORIGEM J. Denavit & R.S. Hartenberg, 1955
▶ Robo de 6 DOF: produto de 6 matrizes T1...T6 da pose do efetuador
002
Jacobiano de Robo Manipulador
AVANCADO
x_dot = J(q)*q_dot; J = dx/dq
Relacao entre velocidades de junta q_dot e velocidade cartesiana x_dot; J singular implica perda de DOF.
ORIGEM Teoria de robotica - Spong, Hutchinson & Vidyasagar
▶ Singularidade de cotovelo: J perde rank
003
Dinamica de Euler-Lagrange de Robo
AVANCADO
tau = M(q)*q_ddot + C(q,q_dot)*q_dot + G(q)
Equacoes de movimento de manipuladores; M=inercia, C=termos de Coriolis/centrifugos, G=gravidade.
ORIGEM Lagrange, 1788
▶ Controle por torque computado
004
Controle PID de Junta Robotica
FUNDAMENTAL
tau = Kp*e + Ki*integral_e + Kd*e_dot; e = q_d - q
PID de posicao de junta com ganhos Kp, Ki e Kd.
ORIGEM Ziegler & Nichols, 1942
▶ Controle de 6 juntas em alta frequencia
005
Cinematica Inversa por Jacobiano Amortecido
AVANCADO
Delta_q = J_T*inv(J*J_T + lambda^2*I)*Delta_x
IK iterativa com amortecimento Levenberg-Marquardt para evitar singularidades.
ORIGEM Wampler, 1986
▶ lambda pequeno estabiliza pseudoinversa
006
Forca de Contato em Controle Forca-Posicao
INTERMEDIARIO
F_contact = Ke*(x_env - x_robot); tau = J_T*F_contact
Modelo de ambiente elastico em controle de impedancia.
ORIGEM N. Hogan, 1985
▶ Limita forca de contato em tarefas sensiveis
007
Modelo Cinematico de Robo Movel Diferencial
FUNDAMENTAL
x_dot=v*cos(theta); y_dot=v*sin(theta); theta_dot=omega; v=(vR+vL)/2; omega=(vR-vL)/L
Modelo uniciclo de duas rodas.
ORIGEM Robotica movel classica
▶ Rotacao no lugar quando vR=-vL
008
Localizacao por Filtro de Particulas
AVANCADO
w_i = p(z|x_i); x_i = p(x|u,x_i_prev)
MCL com particulas e reamostragem por pesos.
ORIGEM Dellaert et al., 1999
▶ AMCL em navegacao 2D
009
Planejamento de Trajetoria Trapezoidal
INTERMEDIARIO
q(t) = q0 + v_max*t - v_max^2/(2*a_max)
Perfil trapezoidal de velocidade para trajetorias suaves.
ORIGEM Robotica industrial
▶ Pick and place com limites de aceleracao
010
RRT* Custo de Reconexao
AVANCADO
Custo(v)=min_u(Custo(u)+d(u,v))
RRT* reconecta pelo menor custo e converge para trajetoria otima.
ORIGEM Karaman & Frazzoli, 2011
▶ Melhor custo com mais amostras
011
Modelo de Camera Pinhole
INTERMEDIARIO
[u,v,1]_T = K*[R|t]*[X,Y,Z,1]_T
Projecao de ponto 3D para pixel.
ORIGEM Modelo projetivo de camera
▶ Calibracao estima matriz K
012
LQR e Equacao de Riccati
AVANCADO
K = inv(R)*B_T*P; P*A + A_T*P - P*B*inv(R)*B_T*P + Q = 0
Controle linear quadratico regulador.
ORIGEM Kalman, 1960
▶ Balanceamento de pendulo invertido
013
Torque Gravitacional de Manipulador
INTERMEDIARIO
G(q)=dPE/dq; PE=sum(m_i*g*h_i(q))
Componente gravitacional da dinamica.
ORIGEM Dinamica de manipuladores
▶ Feedforward gravitacional melhora seguimento
014
Potencia de Atuador de Robo
FUNDAMENTAL
P=tau*q_dot; P_max=V*I_max
Potencia mecanica e limite eletrico de motor.
ORIGEM Acionamento de robos industriais
▶ Verificacao de ciclo termico
015
Erro de Repetibilidade de Robo Industrial
INTERMEDIARIO
R = t95*s/sqrt(n) + bias
Repetibilidade estatistica conforme ISO 9283.
ORIGEM ISO 9283
▶ Classe A com repetibilidade baixa
016
Friccao de Stribeck
AVANCADO
F_fr=(Fc+(Fs-Fc)*exp(-(v/vs)^2))*sign(v)+B*v
Modelo de atrito com regime estatico, Coulomb e viscoso.
ORIGEM R. Stribeck, 1902
▶ Compensacao melhora inversao de direcao
017
Pressao de Garra de Vacuo
FUNDAMENTAL
F_hold=n*(P_atm-P_vacuo)*A_ventosa
Forca de retencao em sistemas de vacuo.
ORIGEM Engenharia de grippers a vacuo
▶ Fator de seguranca acima da carga nominal
018
Cobertura de Area por Robo
FUNDAMENTAL
T_cobertura=A_total/(v*w*eta)
Tempo de cobertura considerando eficiencia de sobreposicao.
ORIGEM Zelinsky, 1993
▶ Robot de limpeza e mapeamento
019
Deformacao Elastica de Elo
INTERMEDIARIO
delta_tip = F*L^3/(3*E*I) + tau*L/(G*J)
Deflexao de ponta por flexao e torcao.
ORIGEM Resistencia dos materiais
▶ Relevante em bracos longos de precisao
020
Manipulabilidade de Yoshikawa
AVANCADO
w = sqrt(det(J*J_T))
Indice de manipulabilidade; zero em singularidade.
ORIGEM Yoshikawa, 1985
▶ Planejamento evita regioes mal condicionadas

Fisica Computacional e Metodos Numericos
Integracao Numerica
021
Metodo de Runge-Kutta de 4 Ordem
INTERMEDIARIO
y_next = y + (k1+2*k2+2*k3+k4)*h/6
Integrador de quarta ordem para EDOs.
ORIGEM Runge, 1895; Kutta, 1901
▶ Boa precisao para simulacao orbital
022
Laplaciano por Diferencas Finitas 2D
INTERMEDIARIO
lap_u = (u_ip1j+u_im1j+u_ijp1+u_ijm1-4*u_ij)/h^2
Aproximacao discreta do Laplaciano.
ORIGEM Diferencas finitas classicas
▶ Base de Poisson e calor
023
Poisson por Elementos Finitos
AVANCADO
K*u=f
Formula fraca de Galerkin para Poisson.
ORIGEM Turner et al., 1956
▶ Uso em elasticidade e eletrostatica
024
Estabilidade de von Neumann
INTERMEDIARIO
r = D*dt/dx^2
Condicao de estabilidade para esquema explicito do calor.
ORIGEM von Neumann & Richtmyer, 1950
▶ r acima do limite gera instabilidade
025
Transformada Rapida de Fourier
FUNDAMENTAL
X_k = sum(x_n*exp(-2*pi*i*n*k/N))
FFT reduz custo para O(N log N).
ORIGEM Cooley & Tukey, 1965
▶ Processamento de sinais em grande escala
026
Integral por Monte Carlo
FUNDAMENTAL
integral = (b-a)/N * sum_f
Integracao estocastica com erro proporcional a 1/sqrt(N).
ORIGEM Ulam & von Neumann, 1947
▶ Eficiente em alta dimensionalidade
027
Integrador de Verlet
INTERMEDIARIO
r_tdt = 2*r_t - r_tmdt + (F/m)*dt^2
Passo temporal para dinamica molecular.
ORIGEM Verlet, 1967
▶ Conserva energia melhor que Euler
028
Potencial de Lennard-Jones
INTERMEDIARIO
V = 4*epsilon*((sigma/r)^12 - (sigma/r)^6)
Interacao repulsiva-atrativa entre atomos.
ORIGEM Lennard-Jones, 1924
▶ Minimo em r=2^(1/6)*sigma
029
Gradiente Conjugado
AVANCADO
alpha_k = (r_k_T*r_k)/(p_k_T*A*p_k); r_next=r_k-alpha_k*A*p_k
Solver iterativo para sistemas SPD.
ORIGEM Hestenes & Stiefel, 1952
▶ Muito usado em FEM grande
030
Crank-Nicolson
AVANCADO
(u_next-u)/dt = 0.5*(L_u + L_u_next)
Esquema implicito de segunda ordem no tempo.
ORIGEM Crank & Nicolson, 1947
▶ Estavel para difusao
031
Algoritmo de Metropolis
INTERMEDIARIO
P_accept=min(1,exp(-(E_next-E)/(k*T)))
Regra de aceitacao para amostragem de Boltzmann.
ORIGEM Metropolis et al., 1953
▶ Simulacao do modelo de Ising
032
Multiplicadores de Lagrange em FEM
AVANCADO
[K B_T; B 0]*[u;lambda]=[f;g]
Imposicao de restricoes por multiplicadores.
ORIGEM Lagrange, 1788
▶ Condicoes de contorno por vinculos
033
Numero de Courant
INTERMEDIARIO
C = u*dt/dx
Condicao CFL para metodos explicitos.
ORIGEM Courant, Friedrichs & Lewy, 1928
▶ Controle de passo temporal em CFD
034
Decomposicao QR
INTERMEDIARIO
A=Q*R
Fatoracao para minimos quadrados e autovalores.
ORIGEM Givens, 1954; Householder, 1958
▶ Resolve sistemas sobredeterminados
035
Amortecimento de Rayleigh
AVANCADO
C = alpha*M + beta*K
Amortecimento proporcional em analise dinamica.
ORIGEM Lord Rayleigh, 1877
▶ Calibrado por dois modos
036
Suavizador de Jacobi
AVANCADO
x_i_next=(b_i-sum_jneqi(A_ij*x_j))/A_ii
Iteracao usada como suavizador multigrid.
ORIGEM Jacobi, 1845
▶ Remove erro de alta frequencia
037
PPPM PME Forca de Longo Alcance
AVANCADO
F_long = scale_pme*sum_k_term
Termo de longo alcance no metodo PME.
ORIGEM Ewald, 1921; Hockney & Eastwood, 1981
▶ O(N log N) em sistemas periodicos
038
Quadratura de Gauss-Legendre
INTERMEDIARIO
integral = sum(w_i*f(x_i))
Quadratura exata para polinomios ate grau 2n-1.
ORIGEM Gauss, 1814
▶ Maior eficiencia que Newton-Cotes
039
Decomposicao em Valores Singulares
INTERMEDIARIO
A=U*Sigma*V_T
Base de PCA, compressao e pseudoinversa.
ORIGEM Beltrami, 1873; Jordan, 1874
▶ Rank dado por valores singulares nao nulos
040
Erro de Truncamento
INTERMEDIARIO
E_trunc = h^p
Erro local/global conforme ordem do metodo.
ORIGEM Lax, 1956
▶ Consistencia + estabilidade implica convergencia

""";
    }
}
