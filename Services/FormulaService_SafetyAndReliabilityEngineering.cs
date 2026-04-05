namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol14Parte3 = """
Engenharia de Seguranca e Confiabilidade de Sistemas
Teoria da Confiabilidade
161
Funcao de Confiabilidade de Weibull
FUNDAMENTAL
R(t) = e^(−(t/eta)^beta)
Confiabilidade no tempo t; eta=escala, beta=forma.
ORIGEM W. Weibull, 1951
▶ Rolamento: beta=2, eta=5000 h -> R(2000)≈0,85
162
Taxa de Falha (Funcao Hazard)
INTERMEDIARIO
h(t) = (beta/eta)·(t/eta)^(beta−1)
Taxa de falha instantanea; curva banheira conforme beta.
ORIGEM Teoria da confiabilidade
▶ beta=1: h constante=1/MTTF
163
MTTF — Tempo Medio ate a Falha
INTERMEDIARIO
MTTF = eta · Gamma(1 + 1/beta)
Vida media de componentes nao-reparaveis.
ORIGEM Teoria da confiabilidade
▶ beta=2, eta=5000 h -> MTTF≈4431 h
164
Confiabilidade de Sistema em Serie
FUNDAMENTAL
R_serie = produto_Ri
Confiabilidade total de componentes em serie.
ORIGEM Teoria da confiabilidade de sistemas
▶ 3 componentes com R=0,9 -> R_serie=0,729
165
Confiabilidade de Sistema em Paralelo
FUNDAMENTAL
R_paralelo = 1 − produto_1_menos_Ri
Redundancia em paralelo; sistema falha somente se todos os componentes falharem.
ORIGEM Teoria da confiabilidade de sistemas
▶ 2 componentes R=0,9 em paralelo -> R=0,99
166
Indice de Risco (FMEA)
FUNDAMENTAL
RPN = Severidade × Ocorrencia × Deteccao
Numero de prioridade de risco (1-1000).
ORIGEM FMEA — MIL-STD-1629A; AIAG FMEA Manual
▶ RPN=8×6×5=240
167
Arvore de Falhas — Probabilidade do Topo
INTERMEDIARIO
P_topo_AND = PA·PB; P_topo_OR = 1−(1−PA)·(1−PB)
Probabilidade de evento-topo em arvore de falhas com portas logicas.
ORIGEM Fault Tree Analysis — Bell Telephone, 1961
▶ A=0,01, B=0,01, AND -> P_topo=0,0001
168
Disponibilidade (Operacional)
FUNDAMENTAL
A = MTBF / (MTBF + MTTR)
Disponibilidade de sistema reparavel.
ORIGEM Teoria de manutencao
▶ MTBF=1000 h, MTTR=10 h -> A=0,99
169
Indice de Probabilidade de Acidentes (LOPA)
AVANCADO
f_evento = f_iniciador × produto_1_menos_PFD_i × produto_modificadores
Camadas de protecao; f=frequencia de evento perigoso.
ORIGEM LOPA — AIChE CCPS, 2001
▶ f_iniciador=0,1/ano, 2 camadas PFD=0,01 -> f_final=10^-5/ano
170
Nivel de Integridade de Seguranca (SIL)
AVANCADO
PFD = soma_lambda_DU_t_div_n
PFD medio para SIL1, SIL2, SIL3 segundo IEC 61511.
ORIGEM IEC 61511 / IEC 61508
▶ SIL2: PFD=10^-2
171
Distribuicao de Poisson (Eventos Raros)
FUNDAMENTAL
P(X=k) = (lambda^k · e^(−lambda)) / k_fatorial
Probabilidade de k ocorrencias de evento raro; lambda=taxa media.
ORIGEM S.D. Poisson, 1837
▶ lambda=0,1/ano: P(zero acidentes)=0,905
172
MTBF de Sistema em Serie
FUNDAMENTAL
1/MTBF_sistema = soma_1_MTBF_i
Taxa de falha total e soma das individuais em serie.
ORIGEM Teoria da confiabilidade
▶ 3 componentes lambda=0,001/h -> MTBF=333 h
173
Indice de Risco Aceitavel (ALARP)
INTERMEDIARIO
Risco_individual = Frequencia_evento × Probabilidade_fatalidade
Risco toleravel por faixa ALARP.
ORIGEM HSE UK — ALARP principle
▶ Planta quimica: risco individual alvo <10^-5/ano
174
Eficiencia de Manutencao Preventiva
INTERMEDIARIO
Custo_total = cM_prev·n_prev + cM_cor·frequencia_falha
Otimizacao do intervalo de manutencao preventiva.
ORIGEM Engenharia de manutencao — RCM
▶ Intervalo otimo encontrado por minimizacao de custo total
175
Indice de Confiabilidade Estrutural (beta de Hasofer-Lind)
AVANCADO
P_f = Phi(−beta)
Indice de confiabilidade beta; Phi=CDF normal padrao.
ORIGEM Hasofer & Lind, 1974
▶ beta=3,5 -> probabilidade de falha ≈2,3×10^-4
176
Coeficiente de Seguranca Parcial (Eurocodigo)
INTERMEDIARIO
Ed = gamma_F · E_k; Rd = R_k / gamma_M
Formato semi-probabilistico; Eurocodigo EN 1990.
ORIGEM Eurocodigo EN 1990
▶ Concreto: gamma_M=1,5; aco: gamma_M=1,15
177
OEE — Eficiencia Global de Equipamento
FUNDAMENTAL
OEE = Disponibilidade × Desempenho × Qualidade
Eficiencia de maquinas industriais.
ORIGEM Seiichi Nakajima — TPM, 1988
▶ OEE=0,9×0,8×0,95=0,684
178
Curva de Banheira (Bathtub Curve)
AVANCADO
h(t) = termo_falha_precoce + termo_desgaste
Superposicao de Weibull beta<1 e beta>1 para descrever curva de banheira.
ORIGEM Engenharia de confiabilidade — Jiang & Murthy, 1995
▶ beta1=0,5 domina inicio; beta2=3 domina fim
179
Risco Coletivo Anual (Instalacao)
INTERMEDIARIO
Risco_coletivo = soma_Frequencia_i_N_i
Numero esperado de fatalidades por ano.
ORIGEM HSE UK — Tolerability of Risk
▶ Refinaria: risco coletivo alvo <10 mortes em 10^4 anos
180
Diagrama de Confiabilidade por Blocos
INTERMEDIARIO
R_sistema = f_topologia_R_blocos
RBD transforma topologia do sistema em expressao analitica de confiabilidade.
ORIGEM MIL-HDBK-338B
▶ Sistema hibrido serie-paralelo: R=R1·[1−(1−R2)(1−R3)]·R4
Sintese Organica e Quimica Medicinal
Planejamento de Farmacos
181
Regra de Lipinski dos Cinco
FUNDAMENTAL
PM<=500; logP<=5; HBD<=5; HBA<=10
Filtro de droga-like oral.
ORIGEM C.A. Lipinski, 1997
▶ Aspirina passa em tudo
182
Rendimento de Reacao
FUNDAMENTAL
Rend = mol_produto_obtido / mol_produto_teorico × 100
Eficiencia de transformacao quimica; multietapa: Rend_total=produto_Rend_etapa.
ORIGEM Quimica sintetica
▶ Sintese de 5 etapas, cada 80% -> Rend_total=32,8%
183
Razao E (Greenness da Reacao — E-factor)
FUNDAMENTAL
E = massa_residuo / massa_produto
Fator E de Sheldon; E=0 ideal.
ORIGEM R.A. Sheldon, 1992
▶ Sintese com E=50: 50 kg de residuo por kg de farmaco
184
Eficiencia Atomica (AE)
FUNDAMENTAL
AE = PM_produto / soma_PM_reagentes × 100
Incorporacao de massa dos reagentes no produto.
ORIGEM B.M. Trost, 1991
▶ Adicao de Diels-Alder: AE=100%
185
Seletividade Quimio/Regio/Estereosseletiva
INTERMEDIARIO
ee = abs(R−S) / (R+S) × 100
Excesso enantiomerico; ee=100% puro.
ORIGEM Estereoquimica — IUPAC
▶ Sharpless epoxidacao: ee≈90-95%
186
Regra de Cahn-Ingold-Prelog (Prioridade CIP)
FUNDAMENTAL
configuracao = R_ou_S_por_CIP
Atribuicao de configuracao absoluta; prioridade por numero atomico.
ORIGEM R.S. Cahn, C.K. Ingold & V. Prelog, 1956
▶ (R)-lactic acid vs (S)-lactic acid
187
Constante de Substituicao de Hammett (sigma)
AVANCADO
log(k/k0) = rho · sigma
Equacao de Hammett; sigma=constante de substituinte, rho=sensibilidade da reacao.
ORIGEM L.P. Hammett, 1935
▶ rho>0: favorecida por retirador
188
Retrossintese (Logica de Corey)
INTERMEDIARIO
alvo = precursor1 + precursor2
Analise retrossintetica: identifica ligacao a quebrar e sintons equivalentes.
ORIGEM E.J. Corey, 1967
▶ Desconexao de amida -> acido carboxilico + amina
189
Reacao de Wittig
INTERMEDIARIO
carbonila + ilida_fosforo -> alceno + Ph3P_O
Formacao de dupla C=C a partir de carbonila.
ORIGEM G. Wittig, 1954
▶ Sintese de vitamina A usa multiplas reacoes de Wittig
190
Relacao Quantitativa Estrutura-Atividade (QSAR — Hansch)
AVANCADO
log(1/C) = a·pi + b·sigma + c·Es + d
QSAR de Hansch; pi=hidrofobicidade, sigma=Hammett, Es=tamanho do substituinte.
ORIGEM C. Hansch & T. Fujita, 1964
▶ Design de anti-hipertensivos por QSAR
191
Acoplamento de Suzuki
INTERMEDIARIO
Ar_X + Ar_B_OH2 -> Ar_Ar_ligado
Acoplamento carbono-carbono catalisado por Pd.
ORIGEM A. Suzuki, 1979
▶ Sintese de analogos biarilicos
192
Hidrolise Alcalina de Ester (Saponificacao)
INTERMEDIARIO
k_obs = kOH·OH
Cinetica de segunda ordem; base de analise de biodegradacao de pro-farmacos tipo ester.
ORIGEM Quimica organica classica
▶ Aspirina: hidrolise em plasma, t1/2≈15 min
193
Indice Molecular de Randic (Topologico)
AVANCADO
chi = soma_ligacoes_graus
Indice de conectividade molecular; correlaciona com solubilidade e atividade biologica.
ORIGEM M. Randic, 1975
▶ Alcanos lineares: chi cresce regularmente com carbono
194
Catalise Acido-Base Geral
AVANCADO
v = k0·S + kA·HA·S + kB·B·S
Velocidade de reacao com catálise acido/base especifica e geral.
ORIGEM Cinetica quimica organica
▶ Hidrolise de amidas: catalisada por OH− e H3O+
195
Solubilidade de Yalkowsky
INTERMEDIARIO
logS = 0,5 − 0,01·(MP − 25) − logP
Solubilidade aquosa S a partir de ponto de fusao MP e logP.
ORIGEM Yalkowsky & Valvani, 1980
▶ Ibuprofeno: logS≈−3,5
196
Analise de Pureza por HPLC (Peak Area %)
FUNDAMENTAL
Pureza = Area_pico / soma_Area_picos × 100
Pureza relativa por area de pico em HPLC.
ORIGEM ICH Q6A Guideline
▶ Pico principal=9850, total=10000 -> pureza=98,5%
197
Deslocamento Quimico em RMN (delta)
FUNDAMENTAL
delta = (nu_amostra − nu_referencia) / nu_espectrometro × 10^6
Deslocamento quimico em ppm; base de caracterizacao estrutural.
ORIGEM RMN — Bloch & Purcell, 1952
▶ TMS = 0 ppm
198
Constante de Inibicao Enzimatica (Ki)
AVANCADO
Ki = IC50 / (1 + S/Km)
Ki de inibidor competitivo a partir de IC50.
ORIGEM Cheng & Prusoff, 1973
▶ IC50=100 nM, S=Km -> Ki=50 nM
199
Regra de Tres Planos (Fsp3)
INTERMEDIARIO
Fsp3 = n_C_sp3 / n_C_total
Fracao de carbonos sp3; tridimensionalidade molecular.
ORIGEM Lovering et al., 2009
▶ Morfina: Fsp3=0,65
200
Numero de Anel de Jorgensen (Naro)
AVANCADO
Naro = n_atomos_aromaticos / n_atomos_pesados
Aromaticidade molecular global; complementa Fsp3 no design.
ORIGEM Jorgensen & Duffy, 2002
▶ Naro ideal para farmacos orais: 0,1-0,5
Engenharia de Minas e Mineracao
Geomecanica de Minas
201
Lei de Deformacao de Hoek-Brown
AVANCADO
sigma1 = sigma3 + sigma_ci·(mb·sigma3/sigma_ci + s)^a
Criterio de ruptura de rocha macica.
ORIGEM E. Hoek & E.T. Brown, 1980
▶ Determina estabilidade de taludes e escavacoes
202
Teor de Corte (Cutoff Grade)
INTERMEDIARIO
g_cutoff = custo_operacional / (preco_metal × recuperacao × fator_diluicao)
Teor minimo economicamente mineravel.
ORIGEM K.F. Lane, 1988
▶ Ouro: g_cutoff≈0,3-0,5 g/t
203
Classificacao de Recursos — Equacao de Kriging
AVANCADO
Z_estrela = soma_lambda_i_Z_xi
Estimativa geoestatistica de teor; pesos lambda_i minimizam variancia.
ORIGEM D.G. Krige, 1951; G. Matheron, 1963
▶ Estimativa de teor de minerio de ferro em blocos 3D
204
Fator de Recuperacao Metalurgica
FUNDAMENTAL
R = metal_concentrado / metal_alimentacao × 100
Eficiencia de recuperacao de metal por flotacao, lixiviacao ou gravimetria.
ORIGEM Tecnologia mineral
▶ Flotacao de cobre: R=90%
205
Indice de Bond de Moagem (Wi)
INTERMEDIARIO
W = Wi · (10/sqrt(P80) − 10/sqrt(F80))
Energia de moagem; dimensiona moinhos.
ORIGEM F.C. Bond, 1952
▶ Minerio de ferro: Wi≈12 kWh/t
206
Equacao de Ventilacao de Minas
INTERMEDIARIO
Q = A · Cd · sqrt(2·DeltaP/rho)
Vazao de ventilacao; A=secao da galeria.
ORIGEM Ventilacao de minas — McPherson, 1993
▶ Galeria 3x3 m, DeltaP=50 Pa -> Q=45 m3/s
207
Produtividade de Perfuracao (Janelski)
INTERMEDIARIO
PR = diametro_furo × RPM × E_penetracao / (60 × sqrt(UCS))
Taxa de penetracao de perfuratriz.
ORIGEM Engenharia de minas — perfuracao e desmonte
▶ UCS alto de granito exige menor PR
208
Equacao de Langefors (Explosivos)
AVANCADO
B = (d/33)·sqrt(rho_rocha/(rho_explosivo·c))
Burden otimo B para bancadas de mina a ceu aberto.
ORIGEM U. Langefors & B. Kihlstrom, 1963
▶ Furo 89 mm em granito -> B≈2,7 m
209
Estabilidade de Taludes (Bishop Simplificado)
AVANCADO
FS = soma_resistencia_dividido_soma_solicitacao
Fator de seguranca de talude; c=coesao, phi=angulo de atrito, u=pressao de poros.
ORIGEM A.W. Bishop, 1955
▶ FS>1,5 requerido para taludes permanentes
210
Custo de Acarretamento (Mineracao)
INTERMEDIARIO
Custo_transporte = distancia_m × t_h × fator_tonelagem × custo_km
Custo de transporte por caminhao ou correia.
ORIGEM Engenharia de lavra
▶ Caminhao 100t, 5 km -> custo≈US$0,30/t·km
211
Reservas Minerais (JORC — Bloco de Minerio)
FUNDAMENTAL
Reserva_metal = Volume_bloco × densidade × teor_medio × recuperacao
Estimativa de metal contido.
ORIGEM JORC Code, 2012
▶ Bloco 10x10x10m, teor=1% Cu -> 2,7 t Cu
212
Indice de Fragmentacao de Kuz-Ram
AVANCADO
X50 = A · (V/Q)^0,8 · Q^(1/6) · (115/E)^(19/30)
Tamanho medio de fragmento por desmonte.
ORIGEM Cunningham, 1983 — modelo Kuz-Ram
▶ X50=300 mm
213
Convergencia de Galeria (Equacao de Kirsch)
AVANCADO
sigma_r = termo_kirsch_circular
Solucao de Kirsch para galeria circular; base de suporte de galerias.
ORIGEM G. Kirsch, 1898
▶ Concentracao de tensao=3P0 nas paredes
214
Balanco Hidrico de Mina
INTERMEDIARIO
Q_bombeamento = Q_entrada − Q_evaporacao − Delta_armazenamento
Balanco hidrico para dimensionamento de bombeamento em minas.
ORIGEM Hidrogeologia de minas
▶ Mina a ceu aberto em regiao tropical: Q_bombeamento pode exceder 1 m3/s
215
Razao de Decapagem (Strip Ratio)
FUNDAMENTAL
SR = volume_esteril / tonelagem_minerio
Relacao esteril/minerio; base da viabilidade de minas a ceu aberto.
ORIGEM Avaliacao economica de minas
▶ SR=4
216
Viscosidade de Polpa de Mineracao
INTERMEDIARIO
mu_polpa = mu_agua · e^(2,5·phi_solidos)
Viscosidade de polpa mineral; alta concentracao afeta transporte.
ORIGEM A. Einstein, 1906 — Roscoe, 1952
▶ phi=0,4 -> mu_polpa≈2,7×mu_agua
217
Flotacao (Equacao de Sutherland)
AVANCADO
P_colisao = 1,5·(d_bolha / d_particula)^2·v_ascensao
Probabilidade de colisao particula-bolha.
ORIGEM K.L. Sutherland, 1948
▶ Particula 100 um, bolha 1 mm -> colisao eficiente
218
NPV de Projeto de Mineracao
FUNDAMENTAL
NPV = soma_CF_t_descontado − Investimento
Valor presente liquido do projeto mineral.
ORIGEM Engenharia economica de mineracao
▶ NPV>0 viavel
219
Indice de Qualidade de Rocha (RQD)
FUNDAMENTAL
RQD = soma_fragmentos_maiores_10cm / comprimento_total_testemunho × 100
Qualidade de macico rochoso; base do sistema RMR e Q de Barton.
ORIGEM D.U. Deere, 1963
▶ Testemunho 1m: 65 cm >10 cm -> RQD=65%
220
Dispersao de Poeira em Minas (Gaussian Plume)
AVANCADO
C = Q/(2·pi·sigma_y·sigma_z·u)·exp(−y^2/(2·sigma_y^2))·(exp(−(z−H)^2/(2·sigma_z^2))+exp(−(z+H)^2/(2·sigma_z^2)))
Dispersao gaussiana de poeira ou gas.
ORIGEM Pasquill-Gifford — dispersao atmosferica
▶ Monitoramento de silica em minas para controle ocupacional
Engenharia de Pavimentos e Infraestrutura
Dimensionamento de Pavimentos
221
Numero Estrutural de Pavimento (CN — AASHTO)
INTERMEDIARIO
SN = a1·D1 + a2·D2·m2 + a3·D3·m3
Capacidade estrutural; padrao AASHTO 1993.
ORIGEM AASHTO Guide for Design of Pavement Structures, 1993
▶ SN=4,5 necessario para rodovia de alto trafego
222
Indice de Servico de Pavimento (PSI — AASHTO)
FUNDAMENTAL
DeltaPSI = log(4,2 − pt) / log(4,2 − 1,5)
Serviceability index; PSI inicial=4,2 para pavimento novo.
ORIGEM AASHO Road Test, 1962
▶ PSI<2,5 indica necessidade de reabilitacao
223
Eixo Padrao Equivalente (ESALF)
INTERMEDIARIO
ESALF = (P/P_padrao)^4 · FE
Fator de equivalencia de carga; base do dimensionamento.
ORIGEM AASHO Road Test, 1962
▶ Eixo de 100 kN -> ESALF≈2,44
224
CBR de Sub-Rasante
FUNDAMENTAL
CBR = carga_ensaio / carga_padrao × 100
California Bearing Ratio; indice de capacidade de suporte.
ORIGEM O.J. Porter — California DOT, 1929
▶ CBR=8%: sub-base adequada
225
Modulo de Resiliencia de Subleito
INTERMEDIARIO
MR = sigma_d / epsilon_r
Rigidez de retorno elastico do solo.
ORIGEM DNIT/AASHTO — ensaio triaxial dinamico
▶ MR = 8 × CBR para solos argilosos
226
Deflexao por Viga Benkelman
FUNDAMENTAL
D = (deflexao_max − deflexao_recuperada) / 2
Deflexao de rebound; base de projetos de reforco.
ORIGEM A.C. Benkelman — HRB, 1954
▶ D=60 adequado; D=120 necessita reforco
227
Penetracao de Asfalto (Grau)
FUNDAMENTAL
Penetracao = profundidade_agulha
Consistencia de ligante asfaltico.
ORIGEM ABNT NBR 6576; ASTM D5
▶ CAP 50/70: penetracao 50-70
228
Modulo de Rigidez do Asfalto (Van der Poel)
AVANCADO
Smix = funcao_rigidez_ligante_e_volumes
Modulo do concreto asfaltico.
ORIGEM Van der Poel, 1954; Bonnaure et al., 1977
▶ Sbit=1 MPa -> Smix≈2000 MPa
229
Teoria de Burmister (Multicamadas Elasticas)
AVANCADO
sigma_z = p·(1 − (z/sqrt(r^2+z^2))^3)
Tensao vertical em pavimento multicamada.
ORIGEM D.M. Burmister, 1945
▶ Base de software Bisar/Elsym5
230
IRI — Indice de Irregularidade Internacional
FUNDAMENTAL
IRI = soma_abs_Deltaz / L
Irregularidade longitudinal de pavimento; IRI<2 excelente.
ORIGEM World Bank — Sayers et al., 1986
▶ Rodovia recem-construida: IRI≈1,5 m/km
231
Fadiga de Pavimento Asfaltico (Modelo de Shift)
AVANCADO
N_fadiga = k1 · (1/epsilon_t)^k2 · (1/E)^k3
Vida de fadiga por deformacao de tracao epsilon_t.
ORIGEM Asphalt Institute — MS-1, 1981
▶ epsilon_t=200 micro -> N≈10^6 repeticoes
232
Deformacao Permanente (Rutting)
AVANCADO
DP = k1 · sigma^k2 · T^k3 · N^k4
Afundamento em trilha de roda.
ORIGEM NCHRP 1-37A — MEPDG
▶ Alta temperatura + carga pesada acelera rutting
233
Custo do Ciclo de Vida de Pavimento (LCC)
INTERMEDIARIO
LCC = IC + soma_MC_t_descontado + soma_RC_t_descontado + VR_descontado
Custo total do ciclo de vida.
ORIGEM FHWA — Life-Cycle Cost Analysis in Pavement Design
▶ LCC de asfalto vs concreto: analise de 30-50 anos
234
Calculo de Lastro Ferroviario
INTERMEDIARIO
p_lastro = P_eixo / (2 · L_dormente · S_dormente · k_lastro)
Pressao no lastro ferroviario.
ORIGEM AREMA Manual for Railway Engineering
▶ Carga de eixo 30 tf -> p_lastro≈250 kPa
235
Raio Minimo de Curva Ferroviaria
INTERMEDIARIO
R_min = V^2 / (127·(e+f))
Raio minimo de curva para velocidade V.
ORIGEM ABNT NBR 7483; UIC Code
▶ V=200 km/h, e=0,15, f=0,10 -> R_min≈1250 m
236
Densidade de Pavimento por Marshall
INTERMEDIARIO
Dm = Wa / (Wa − Ww) × rho_agua
Densidade de corpo de prova asfaltico por pesagem hidrostatica.
ORIGEM Metodo Marshall — Bruce Marshall, 1939
▶ Teor otimo de betume: maxima densidade e estabilidade
237
Calculo de Drenagem de Pavimento
FUNDAMENTAL
Qmax = C · i · A
Vazao de drenagem de pista; dimensiona sarjetas.
ORIGEM Metodo Racional — Kuichling, 1889
▶ Pista 3km×12m, C=0,85, i=80 mm/h -> Q=0,272 m3/s
238
Espessura Minima de Capa de Concreto (PCA)
AVANCADO
D = C · (P / (MR·sqrt(k)))^0,25
Espessura de placa de concreto de cimento Portland.
ORIGEM Portland Cement Association — PCA Method, 1984
▶ MR=4,5 MPa, k=50 -> D≈22 cm
239
Textura de Superficie (Mancha de Areia)
FUNDAMENTAL
MTD = V_areia / A_mancha
Textura media por profundidade de mancha de areia; MTD>0,5 mm garante atrito adequado.
ORIGEM ASTM E965 — Sand Patch Method
▶ MTD=1,0 mm: boa textura
240
Equivalencia Estrutural de Pavimento (RCR)
INTERMEDIARIO
Se_reforco = Se_proj − Se_existente
Capacidade estrutural remanescente; base do projeto de reforco.
ORIGEM DNER PRO 10/79 — Metodo do DNER
▶ Pavimento com 50% de vida consumida -> reforco adicional
""";
    }
}
