namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol16Parte3 = """
Economia Comportamental e Financas Quanticas
Teoria da Perspectiva
081
Funcao Valor de Prospect Theory
FUNDAMENTAL
V = x^alpha
Modelo de ganho da teoria da perspectiva (ramo positivo).
ORIGEM Kahneman & Tversky, 1979
▶ Curvatura reflete sensibilidade decrescente
082
Ponderacao de Probabilidade
INTERMEDIARIO
w_p = p^gamma/((p^gamma+(1-p)^gamma)^(1/gamma))
Transformacao nao linear de probabilidades.
ORIGEM Tversky-Kahneman; Prelec
▶ Eventos raros ficam sobreponderados
083
Desconto Hiperbolico
FUNDAMENTAL
U_t = V/(1+k*t)
Preferencia temporal inconsistente.
ORIGEM Ainslie, 1975
▶ Valor presente cai mais no curto prazo
084
Ancoragem de WTP
INTERMEDIARIO
WTP = WTP_base + beta*(ancora-WTP_base)
Heuristica de ancoragem em decisao.
ORIGEM Tversky & Kahneman, 1974
▶ Valor inicial desloca estimativa
085
Lance Otimo Primeiro Preco
AVANCADO
b_star = v - integral_term/F_v_pow
Estrutura de shading em leiloes de primeiro preco.
ORIGEM Nash; Vickrey
▶ Lances abaixo do valor privado
086
Modelo de Nudge
FUNDAMENTAL
Delta_participacao = efeito_default + saliencia + timing
Representacao agregada de arquitetura de escolha.
ORIGEM Thaler & Sunstein, 2008
▶ Defaults mudam adesao fortemente
087
Bayes em Financas Comportamentais
INTERMEDIARIO
P_bull_given_r = P_r_given_bull*P_bull
Atualizacao bayesiana de regime de mercado.
ORIGEM Bayes, 1763
▶ Desvio comportamental gera vies
088
Processo Dual
FUNDAMENTAL
Decisao = alpha*S1 + (1-alpha)*S2
Combinacao entre processamento intuitivo e deliberativo.
ORIGEM Kahneman, 2011
▶ Carga cognitiva eleva peso de S1
089
SDF de Consumo
AVANCADO
m = beta*(C_next/C_now)^(-gamma)
Fator de desconto estocastico.
ORIGEM Hansen & Singleton, 1983
▶ Precificacao por E[mR]=1
090
Indice de Sentimento
AVANCADO
Sentimento = PC1_proxies
Primeiro componente principal de proxies de sentimento.
ORIGEM Baker & Wurgler, 2006
▶ Reversao em ativos especulativos
091
Miscalibracao de Confianca
INTERMEDIARIO
Calibracao = p_acerto_conf - nivel_conf
Excesso de confianca em previsoes.
ORIGEM Lichtenstein & Fischhoff, 1977
▶ Sobreconfianca induz overtrading
092
Q-Learning Financeiro
AVANCADO
Q = Q + alpha*(r + gamma*Q_max_next - Q)
Atualizacao de valor-acao em trading.
ORIGEM Watkins, 1989
▶ Politica melhora com experiencia
093
Mercados Adaptativos
INTERMEDIARIO
alpha_t = dlog_preco_dinfo*regime_t
Sensibilidade de mercado dependente de regime.
ORIGEM A.W. Lo, 2004
▶ Estrategias mudam com ciclo
094
Hamiltoniano de Precos
AVANCADO
H_psi = kinetic_term + V_x*psi
Analogia quantica para dinamica de precos.
ORIGEM Baaquie, 2004
▶ Formalismo inspirado em Schrodinger
095
Entropia de Tsallis
AVANCADO
S_q = k*(1-sum_pq)/(q-1)
Entropia nao extensiva para caudas pesadas.
ORIGEM Tsallis, 1988
▶ q>1 ajusta distribuicoes financeiras
096
Status Quo Bias
FUNDAMENTAL
P_default = P_base + beta_default
Tendencia a manter opcao padrao.
ORIGEM Samuelson & Zeckhauser, 1988
▶ Inercia decisoria elevada
097
VPL de Capital Humano
FUNDAMENTAL
VPL_educacao = sum_delta_w_t_descontado - C_educacao
Retorno liquido de investimento educacional.
ORIGEM Becker, 1964
▶ Diferencial salarial de longo prazo
098
Regret Theory
AVANCADO
V = sum_p_i*(u_x_i + R_regret)
Utilidade com termo de arrependimento antecipado.
ORIGEM Loomes & Sugden, 1982
▶ Explica reversoes de preferencia
099
Fehr-Schmidt
INTERMEDIARIO
U_i = pi_i - alpha*max(pi_j-pi_i,0) - beta*max(pi_i-pi_j,0)
Preferencias sociais com aversao a inequidade.
ORIGEM Fehr & Schmidt, 1999
▶ Rejeicao de ofertas injustas
100
Iliquidez de Amihud
INTERMEDIARIO
lambda = spread/(2*V^0.3)
Medida de custo de transacao e liquidez.
ORIGEM Amihud, 2002
▶ lambda alto implica premio de liquidez

Epidemiologia Genetica e Genomica de Populacoes
Genetica de Populacoes
101
Hardy-Weinberg
FUNDAMENTAL
p^2 + 2*p*q + q^2 = 1
Equilibrio genotipico em populacao ideal.
ORIGEM Hardy & Weinberg, 1908
▶ Desvio sugere forcas evolutivas
102
Desequilibrio de Ligacao
INTERMEDIARIO
D = p_AB - p_A*p_B; r2 = D^2/(p_A*(1-p_A)*p_B*(1-p_B))
Associacao entre loci.
ORIGEM Lewontin, 1964
▶ r2 alto facilita tag SNP
103
Herdabilidade de Falconer
INTERMEDIARIO
h2 = 2*(r_MZ-r_DZ)
Estimativa de componente genetica por gemeos.
ORIGEM Falconer, 1960
▶ h2 elevado indica forte heranca
104
Score Poligenico
INTERMEDIARIO
PRS = sum(beta_j*G_j)
Risco genetico agregado por variantes.
ORIGEM Purcell et al., 2009
▶ Estratificacao de risco populacional
105
Deriva e Tamanho Efetivo
INTERMEDIARIO
Var_dp = p*q/(2*Ne)
Flutuacao alelica por deriva genetica.
ORIGEM Wright, 1931
▶ Ne menor acelera fixacao/perda
106
Selecao em Wright-Fisher
INTERMEDIARIO
p_next = p*W_A/W_bar
Atualizacao de frequencia por aptidao relativa.
ORIGEM Fisher; Wright
▶ Selecoes fracas acumulam no tempo
107
Limiar de GWAS
FUNDAMENTAL
p_threshold = 5e-8
Criterio de significancia genômica ampla.
ORIGEM Risch & Merikangas, 1996
▶ Controle de testes multiplos
108
Herdabilidade SNP GCTA
AVANCADO
h2_snp = Var_genomica/Var_fenotipica
Fração explicada por SNPs comuns.
ORIGEM Yang et al., 2010
▶ Gap de herdabilidade permanece
109
Ancestralidade por Mistura
AVANCADO
Q_i = argmax_logL
Proporcoes ancestrais por maximizacao.
ORIGEM Pritchard et al., 2000
▶ Ajuste de estratificacao em GWAS
110
Odds Ratio de SNP
FUNDAMENTAL
OR = (caso_A/caso_a)/(ctrl_A/ctrl_a)
Associacao caso-controle de variante.
ORIGEM Epidemiologia genetica
▶ OR maior que 1 indica risco
111
Equacao de Breeder
FUNDAMENTAL
R = h2*S
Resposta esperada a selecao.
ORIGEM Galton; Falconer
▶ Melhoramento genetico
112
Diversidade Nucleotidica
INTERMEDIARIO
pi = sum(x_i*x_j*d_ij)
Diferenca media por pares de sequencias.
ORIGEM Nei & Li, 1979
▶ Medida de variabilidade molecular
113
Fst
FUNDAMENTAL
Fst = (H_T - H_S)/H_T
Diferenciacao genetica entre populacoes.
ORIGEM Wright, 1951
▶ Valores moderados em humanos
114
Mendelian Randomization
AVANCADO
beta_IV = beta_ZY/beta_ZX
Estimador causal por instrumento genetico.
ORIGEM Davey Smith & Ebrahim, 2003
▶ Alternativa a estudo randomizado
115
Efeito Fundador
INTERMEDIARIO
H_t = H0*(1-1/(2*Ne))^t
Perda de heterozigosidade por gargalo.
ORIGEM Wright, 1931
▶ Populacoes pequenas perdem diversidade
116
Distancia de Kimura
AVANCADO
K = -(3/4)*ln(1-(4/3)*p)
Correcao de multiplas substituicoes.
ORIGEM Kimura, 1980
▶ Usada em filogenia molecular
117
Imputacao Bayesiana
AVANCADO
P_g = P_obs_given_g*P_g_ref
Inferencia de genotipos faltantes.
ORIGEM Howie et al., 2009
▶ Amplia cobertura de SNPs
118
IBD
INTERMEDIARIO
IBD2 = P_ambos_alelos_ibd
Parentesco por descendencia comum.
ORIGEM Thompson, 1975
▶ Triagem de parentes em coortes
119
Idade de Alelo
AVANCADO
E_t = 2*Ne*ln(2*Ne/(2*Ne-i))
Aproximacao de idade media de alelo.
ORIGEM Kimura & Ohta, 1973
▶ Alelos raros tendem a ser mais jovens
120
Meta-analise de GWAS
INTERMEDIARIO
beta_meta = sum(beta_i/SE_i^2)/sum(1/SE_i^2)
Combinacao de efeitos por peso inverso da variancia.
ORIGEM Cochran, 1954
▶ Aumento de poder estatistico

Processos Estocasticos e Financas Matematicas
Calculo Estocastico
121
Movimento Browniano
FUNDAMENTAL
dW = epsilon*sqrt(dt)
Processo de Wiener com incrementos gaussianos.
ORIGEM Wiener, 1923
▶ Base de modelos de ativos
122
Lema de Ito
AVANCADO
df = f_x*dX + 0.5*f_xx*sigma^2*dt
Regra da cadeia para processos estocasticos.
ORIGEM Ito, 1944
▶ Termo extra de segunda ordem
123
EDP de Black-Scholes
AVANCADO
dV_dt + 0.5*sigma^2*S^2*d2V_dS2 + r*S*dV_dS - r*V = 0
Precificacao neutra ao risco de opcoes.
ORIGEM Black, Scholes, Merton, 1973
▶ Solucao fechada para call europeia
124
Heston
AVANCADO
dS = mu*S*dt + sqrt(v)*S*dW1; dv = kappa*(theta-v)*dt + xi*sqrt(v)*dW2
Volatilidade estocastica com reversao a media.
ORIGEM Heston, 1993
▶ Captura smile implicita
125
VaR
FUNDAMENTAL
VaR_alpha = -quantile_alpha(deltaP)
Perda limite para nivel de confianca.
ORIGEM RiskMetrics, 1994
▶ Medida regulatoria de risco
126
Expected Shortfall
INTERMEDIARIO
ES_alpha = -E_deltaP_cond_tail
Perda media na cauda alem do VaR.
ORIGEM Artzner et al., 1999
▶ Coerente e sensivel a eventos extremos
127
Ornstein-Uhlenbeck
INTERMEDIARIO
dX = kappa*(theta-X)*dt + sigma*dW
Reversao a media em tempo continuo.
ORIGEM Ornstein & Uhlenbeck, 1930
▶ Modelo de taxa curta
128
Copula Gaussiana
AVANCADO
C = Phi2(Phi_inv_u,Phi_inv_v,rho)
Dependencia entre distribuicoes marginais.
ORIGEM Li, 2000
▶ Aplicacoes em credito estruturado
129
Duracao de Macaulay
INTERMEDIARIO
D = sum(t_i*PV_i)/P
Sensibilidade de preco de titulo a juros.
ORIGEM Macaulay, 1938
▶ Aproximacao de variação de preco
130
Girsanov
AVANCADO
dQ_dP = exp(-int_theta_dW - 0.5*int_theta2_dt)
Mudanca de medida para mundo neutro ao risco.
ORIGEM Girsanov, 1960
▶ Deriva vira taxa livre de risco
131
CIR
AVANCADO
dr = kappa*(theta-r)*dt + sigma*sqrt(r)*dW
Modelo de juros positivos por difusao raiz.
ORIGEM Cox, Ingersoll & Ross, 1985
▶ Precificacao de bonds
132
Delta de Opcao
INTERMEDIARIO
Delta = dC_dS
Sensibilidade de preco da opcao ao ativo.
ORIGEM Greeks de Black-Scholes
▶ Base de hedge delta-neutral
133
Gamma de Opcao
AVANCADO
Gamma = d2C_dS2
Curvatura da exposicao da opcao.
ORIGEM Greeks de Black-Scholes
▶ ATM possui gamma elevado
134
Paridade Put-Call
FUNDAMENTAL
C - P = S - K*exp(-r*T)
Relacao de nao-arbitragem entre calls e puts.
ORIGEM Stoll, 1969
▶ Violacao abre arbitragem
135
Kelly
FUNDAMENTAL
f_star = (b*p-q)/b
Fracao de capital para crescimento logaritmico.
ORIGEM Kelly, 1956
▶ Uso conservador com fracao de Kelly
136
Fisher
FUNDAMENTAL
1+r_nom = (1+r_real)*(1+pi)
Relacao entre juros nominais, reais e inflacao.
ORIGEM Fisher, 1930
▶ Aproximacao r_nom~r_real+pi
137
Monte Carlo para Ativo
INTERMEDIARIO
S_T = S0*exp((r-sigma^2/2)*T + sigma*Z*sqrt(T))
Simulacao lognormal de preco terminal.
ORIGEM Boyle, 1977
▶ Opções exoticas por amostragem
138
Regime Switching Markov
AVANCADO
P_state_next = P_transition*P_state
Dinamica de regimes bull/bear por cadeia de Markov.
ORIGEM Hamilton, 1989
▶ Parametros mudam por estado
139
GARCH
INTERMEDIARIO
sigma2_t = omega + alpha*eps2_prev + beta*sigma2_prev
Volatilidade condicional com clustering.
ORIGEM Engle, 1982; Bollerslev, 1986
▶ Persistencia quando alpha+beta alto
140
Cost of Carry
FUNDAMENTAL
F0 = S0*exp((r+c-y)*T)
Preco teorico de futuros.
ORIGEM Hull
▶ Backwardation para y alto

""";
    }
}
