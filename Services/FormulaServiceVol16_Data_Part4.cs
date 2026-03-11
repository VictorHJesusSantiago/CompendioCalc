namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol16Parte4 = """
Histologia Quantitativa e Biologia Celular
Ciclo e Divisao Celular
141
Duracao do Ciclo Celular
FUNDAMENTAL
T_total = T_G1 + T_S + T_G2 + T_M
Duracao total do ciclo celular por fases.
ORIGEM Howard & Pelc, 1953
▶ Alteracoes em tumores proliferativos
142
Difusao Transmembrana
FUNDAMENTAL
J = -P*(C_i-C_e)
Fluxo por gradiente de concentracao.
ORIGEM Fick, 1855
▶ Dependencia de permeabilidade
143
Nernst
FUNDAMENTAL
E_X = (R*T/(z*F))*ln(X_out/X_in)
Potencial de equilibrio ionico.
ORIGEM Nernst, 1889
▶ Prediz direcao de fluxo ionico
144
Crescimento Exponencial Celular
FUNDAMENTAL
N_t = N0*exp(mu*t)
Crescimento em fase logaritmica.
ORIGEM Microbiologia quantitativa
▶ Tempo de duplicacao ln2/mu
145
Energia de Transporte
INTERMEDIARIO
DeltaG = R*T*ln(X_in/X_out)+z*F*DeltaPsi
Energetica de transporte atraves de membrana.
ORIGEM Bioquimica de membranas
▶ Transporte ativo requer ATP
146
Turnover de Proteina
INTERMEDIARIO
dP_dt = S-k_deg*P
Balanco entre sintese e degradacao.
ORIGEM Schimke & Doyle, 1970
▶ Estado estacionario em S/kdeg
147
Pressao de Turgor
INTERMEDIARIO
Psi_w = Psi_s + Psi_p; P = Psi_p
Mecanica osmotica de celulas vegetais.
ORIGEM Biofisica vegetal
▶ Perda de turgor causa murcha
148
Indice de Apoptose
FUNDAMENTAL
AI = tunel_pos/total*100
Percentual de celulas apoptoticas.
ORIGEM Gavrieli et al., 1992
▶ Monitoramento terapeutico
149
Equilibrio de Donnan
AVANCADO
K_i*Cl_i = K_e*Cl_e
Particao ionica com macromoleculas fixas.
ORIGEM Donnan, 1911
▶ Afeta volume celular
150
Permeabilidade de Lipidios
INTERMEDIARIO
P = D_m*K_m/l
Regra de Overton para passagem por membrana.
ORIGEM Overton, 1895
▶ Moleculas lipofilicas atravessam melhor
151
Henderson-Hasselbalch
FUNDAMENTAL
pH = pKa + log(A_minus/HA)
Relacao acido-base em tampoes.
ORIGEM Henderson; Hasselbalch
▶ Controle de pH fisiologico
152
Dinamica de mRNA
INTERMEDIARIO
dmRNA_dt = k_tx-k_deg*mRNA
Cinética de transcricao e degradacao.
ORIGEM Jacob & Monod, 1961
▶ mRNA instavel responde rapido
153
Difusao Lateral de Receptores
AVANCADO
tau = r^2/(4*D_lat)
Escala temporal de FRAP em membranas.
ORIGEM Saffman & Delbruck, 1975
▶ D_lat em faixa de micrometros quadrados por segundo
154
Mecanotransducao
FUNDAMENTAL
Resposta = E_substrato*sensibilidade
Relacao entre rigidez e fate celular.
ORIGEM Engler et al., 2006
▶ Diferenciacao dependente de kPa
155
Encurtamento de Telomero
INTERMEDIARIO
DeltaL = perda_bp_por_divisao*n_divisoes
Modelo acumulativo de encurtamento telomerico.
ORIGEM Hayflick; Blackburn et al.
▶ Senescencia apos divisões sucessivas
156
Scatchard
INTERMEDIARIO
B_over_F = (Bmax-B)/Kd
Analise de ligacao receptor-ligante.
ORIGEM Scatchard, 1949
▶ Estimativa de afinidade
157
Permeabilidade Relativa de Ions
AVANCADO
Perm_rel = D*beta_m/l
Escala de permeacao iônica em membrana.
ORIGEM Hodgkin & Katz, 1949
▶ Varia com abertura de canais
158
Cavalieri
INTERMEDIARIO
V_obj = sum_A_i*t
Estimativa estereologica de volume.
ORIGEM Cavalieri; Gundersen
▶ Morfometria de estruturas 3D
159
Cole-Cole
AVANCADO
Z = R_inf + (R0-R_inf)/(1+(omega*tau)^(1-alpha))
Impedancia complexa de tecido biologico.
ORIGEM Cole & Cole, 1941
▶ Base de bioimpedancia
160
Escalonamento S/V
FUNDAMENTAL
S_over_V = k_geom/r
Relação superficie-volume e troca com meio.
ORIGEM Galileo
▶ Limita tamanho celular

Engenharia de Petroleo e Reservatorios
Fluxo em Reservatorios
161
Darcy Radial
INTERMEDIARIO
Q = k*A*(P_r-P_wf)/(mu*ln_re_rw)
Fluxo de producao em poço.
ORIGEM Darcy, 1856
▶ Influencia de permeabilidade e viscosidade
162
Bubble Point
INTERMEDIARIO
P_b = corr_standing
Pressao de inicio de liberacao de gas.
ORIGEM Standing, 1952
▶ Define regime monofasico/bifasico
163
Bo
FUNDAMENTAL
Bo = V_res/V_sup
Fator de volume de formacao do oleo.
ORIGEM Analise PVT
▶ Bo maior que 1 em geral
164
Declinio de Arps
INTERMEDIARIO
q_t = q_i*(1+b*D_i*t)^(-1/b)
Curva de declinio de vazao.
ORIGEM Arps, 1945
▶ Base para previsao de reservas
165
Material Balance
AVANCADO
F = N*(Et+m*Eg)+Np*Bo*(1+m)*cf*dP
Balanco para estimar OOIP.
ORIGEM Havlena & Odeh, 1963
▶ Ajuste linear em diagnostico
166
Eficiencia de Varrido
INTERMEDIARIO
E_total = E_areal*E_vertical*E_desloc
Desempenho de recuperacao por injeção.
ORIGEM Craig, 1971
▶ Heterogeneidade reduz eficiencia
167
Razao de Mobilidade
INTERMEDIARIO
M = (krw/mu_w)/(kro/mu_o)
Indicador de fingering em deslocamento.
ORIGEM Peters & Flock, 1981
▶ M elevado piora varrido
168
Porosidade de Neutron
INTERMEDIARIO
phi_N = f_resposta_neutron
Estimativa de porosidade por perfilagem.
ORIGEM Well logging
▶ Requer correcao litologica
169
Skin
INTERMEDIARIO
dP_skin = c_skin*q*B*mu*S/(k*h)
Perda adicional de pressao por dano.
ORIGEM van Everdingen & Hurst
▶ S positivo reduz produtividade
170
Indice de Produtividade
FUNDAMENTAL
IP = q/(P_r-P_wf)
Eficiência de entrega de poço.
ORIGEM Engenharia de reservatorios
▶ Relacao linear no regime simples
171
Pressao de Fratura
AVANCADO
P_fratura = sigma_h_min + T
Limite para iniciar fratura hidraulica.
ORIGEM Hubbert & Willis, 1957
▶ Define janela operacional
172
Volume de Fraturamento
AVANCADO
V_frac = q*t
Volume injetado em tratamento.
ORIGEM Perkins & Kern
▶ Controle de comprimento/largura
173
PTA Horner
AVANCADO
k_h = c_pta*q*B*mu/m
Estimativa de permeabilidade-espessura.
ORIGEM Horner, 1951
▶ Build-up revela skin e pressao
174
Viscosidade de Oleo
INTERMEDIARIO
ln_mu = A + B*T^C
Correlacao empirica de viscosidade.
ORIGEM Beggs & Robinson, 1975
▶ Forte dependencia de temperatura
175
Dupla Porosidade
AVANCADO
dp_f_dt = diffusao_f - transferencia_mf
Modelo fratura-matriz em carbonatos.
ORIGEM Warren & Root, 1963
▶ Resposta de pressao bimodal
176
GOR
FUNDAMENTAL
GOR = q_gas/q_oil
Razao gas-oleo de producao.
ORIGEM Engenharia de petroleo
▶ Indicador de comportamento de reservatorio
177
Swi
INTERMEDIARIO
Swi = func_phi_k_wet
Saturacao de agua irredutivel.
ORIGEM Buckley-Leverett
▶ Impacta kro maximo
178
Buckley-Leverett
AVANCADO
dx_dt_sw = dfw_dSw
Avanco de frente de agua 1D.
ORIGEM Buckley & Leverett, 1942
▶ Choque determina eficiencia
179
Corey
AVANCADO
kro=(1-Sw_star)^n_o; krw=Sw_star^n_w
Curvas de permeabilidade relativa.
ORIGEM Corey, 1954
▶ Parametrizacao em simuladores
180
Fator de Recuperacao
FUNDAMENTAL
RF_total = RF_primary + RF_secondary + RF_tertiary
Acumulado de recuperacao final.
ORIGEM EOR surveys
▶ EOR adiciona ganho incremental

Ciencias da Computacao Aplicadas - Algoritmos e Complexidade
Analise de Algoritmos
181
Notacao O
FUNDAMENTAL
T_n <= c*g_n
Limite assintotico superior de complexidade.
ORIGEM Bachmann; Landau
▶ Compara escalabilidade de algoritmos
182
Master Theorem
INTERMEDIARIO
T_n = a*T_n_b + f_n
Casos para recorrencias divide-and-conquer.
ORIGEM Bentley, Haken & Saxe
▶ Mergesort resulta em nlogn
183
P versus NP
FUNDAMENTAL
P_subset_NP
Base de classes de complexidade.
ORIGEM Cook, 1971
▶ SAT como NP-completo
184
Dijkstra
FUNDAMENTAL
d_v = min(d_v,d_u+w_uv)
Caminho minimo com pesos nao negativos.
ORIGEM Dijkstra, 1959
▶ Uso em roteamento
185
Bellman em DP
INTERMEDIARIO
V_star = max_a(R + gamma*sum_PV)
Otimalidade por subestrutura.
ORIGEM Bellman, 1957
▶ Resolve problemas sequenciais
186
A*
FUNDAMENTAL
f_n = g_n + h_n
Busca informada com heuristica admissivel.
ORIGEM Hart, Nilsson & Raphael
▶ Otima quando h nao superestima
187
Hashing
INTERMEDIARIO
h_k = k mod m
Mapeamento de chave para tabela hash.
ORIGEM Luhn; Morris
▶ Operacoes medias O(1)
188
CAP
FUNDAMENTAL
C_A_P_tradeoff = 1
Impossibilidade de maximizar C,A,P simultaneamente.
ORIGEM Brewer; Gilbert & Lynch
▶ Escolha depende do sistema
189
Tradeoff Tempo-Espaco
AVANCADO
T_n*S_n >= n
Limite inferior em modelos de computacao.
ORIGEM Paterson & Hewitt
▶ Menos memoria pode custar tempo
190
Huffman
FUNDAMENTAL
L_media >= H_X
Compressao otima sem perdas para simbolos iid.
ORIGEM Huffman, 1952
▶ Aproxima entropia de Shannon
191
AVL
INTERMEDIARIO
bf = h_left - h_right
Condicao de balanceamento de BST.
ORIGEM Adelson-Velsky & Landis
▶ Busca O(log n)
192
Kruskal
FUNDAMENTAL
MST = union_find_sorted_edges
Arvore geradora minima gulosa.
ORIGEM Kruskal, 1956
▶ Custo total minimo de conexao
193
FPTAS
AVANCADO
approx_ratio = 1-epsilon
Aproximacao com tempo polinomial em n e 1/epsilon.
ORIGEM Hochbaum
▶ Knapsack admite FPTAS
194
Custo Amortizado
AVANCADO
c_tilde = c + Phi_Di - Phi_Dprev
Analise amortizada por potencial.
ORIGEM Tarjan, 1985
▶ Push com doubling O(1) amortizado
195
Christofides
AVANCADO
ratio <= 1.5
Aproximacao para TSP metrico.
ORIGEM Christofides, 1976
▶ Boa solucao em tempo polinomial
196
Floyd-Warshall
INTERMEDIARIO
d_ij = min(d_ij,d_ik+d_kj)
Menor caminho todos-contra-todos.
ORIGEM Floyd; Warshall, 1962
▶ Complexidade O(n^3)
197
Bloom Filter
INTERMEDIARIO
P_fp = (1-exp(-k*n/m))^k
Estrutura probabilistica de pertinencia.
ORIGEM Bloom, 1970
▶ Sem falso negativo
198
Strassen
INTERMEDIARIO
T_n = n^log2_7
Multiplicacao de matrizes subcubica.
ORIGEM Strassen, 1969
▶ Melhor assintotica que O(n^3)
199
Karger Min-Cut
AVANCADO
P_success >= 1/C_n2
Corte minimo por contracoes aleatorias.
ORIGEM Karger, 1993
▶ Repeticoes elevam confianca
200
Condicionamento de Matriz
INTERMEDIARIO
kappa_A = norm_A*norm_A_inv
Sensibilidade da solucao de sistema linear.
ORIGEM Turing, 1948
▶ kappa alto indica problema mal condicionado

""";
    }
}
