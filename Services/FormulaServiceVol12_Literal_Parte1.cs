using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasVol12_Literal_Parte1()
        {
            AdicionarPacoteVol12Detalhado(
                "Engenharia de Telecomunicações e Antenas",
                "Propagação e Enlace",
                21,
                new List<Vol12FormulaSpec>
                {
                    new("Equação de Friis (Enlace de Rádio)", "Pr/Pt = Gt·Gr·(λ/4πd)²", "Potência recebida Pr em função de Pt transmitida, ganhos Gt,Gr, distância d e comprimento de onda λ.", "H.T. Friis", "1946", "d=1 km, f=2,4 GHz, Gt=Gr=1: perda de percurso≈80 dB"),
                    new("Capacidade de Shannon", "C = B·log₂(1 + SNR)", "Capacidade máxima C (bps) de canal com banda B (Hz) e relação sinal-ruído SNR.", "C.E. Shannon", "1948", "B=20 MHz, SNR=100: C≈133 Mbps"),
                    new("Ganho de Antena de Abertura", "G = η·4πA/λ²", "Ganho de antena de área efetiva A; η=eficiência de abertura (0,5–0,75); A=área física.", "Teoria de antenas clássica", "Séc. XX", "Prato 1 m², f=10 GHz, η=0,6: G≈39 dBi"),
                    new("Largura de Feixe de Meia Potência (HPBW)", "HPBW ≈ 70°·λ/D", "Largura angular −3 dB do feixe principal de antena de abertura D.", "Teoria de difração de Fraunhofer", "Séc. XX", "D=2 m, λ=3 cm (10 GHz): HPBW≈1,05°"),
                    new("Relação Frequência-Comprimento de Onda", "λ = c/f", "λ=comprimento de onda, c=3×10⁸ m/s, f=frequência.", "Eletromagnetismo clássico (Maxwell)", "Séc. XIX", "f=2,4 GHz → λ=12,5 cm; f=60 GHz → λ=5 mm"),
                    new("Equação de Radar", "Pr = (Pt·Gt·Gr·σ·λ²) / [(4π)³·R⁴]", "Potência de retorno de radar; σ=seção reta de radar (RCS), R=distância.", "Equação fundamental de radar", "Séc. XX", "R_max determinado quando Pr=sensibilidade do receptor"),
                    new("Ruído Térmico de Johnson-Nyquist", "Pn = kTB", "Potência de ruído disponível em resistor a temperatura T em banda B; k=1,38×10⁻²³ J/K.", "J.B. Johnson; H. Nyquist", "1928", "T=290 K, B=1 MHz: Pn=−114 dBm"),
                    new("Figura de Ruído em Cascata (Friis)", "F_total = F₁ + (F₂−1)/G₁ + (F₃−1)/(G₁G₂) + …", "Figura de ruído total de cadeia de amplificadores; F=fator de ruído, G=ganho de potência.", "H.T. Friis", "1944", "LNA define ruído do receptor quando G₁ alto"),
                    new("Índice de Modulação FM", "β = Δf / fm", "Índice de modulação FM; Δf=desvio de frequência máximo, fm=frequência modulante.", "E.H. Armstrong", "1933", "Rádio FM: Δf=75 kHz, fm=15 kHz → β=5"),
                    new("Regra de Carson (Largura de Banda FM)", "BW_FM ≈ 2(Δf + fm) = 2·fm·(β+1)", "Banda necessária para FM com desvio Δf e frequência modulante fm.", "J.R. Carson", "1922", "Rádio FM: BW≈180 kHz"),
                    new("Eficiência Espectral de M-QAM", "η = log₂(M) bit/s/Hz", "Eficiência espectral de M-QAM sem codificação; 64-QAM→6 b/s/Hz.", "Teoria de comunicações digitais", "Séc. XX", "LTE 256-QAM: η=8 b/s/Hz"),
                    new("Perda em Espaço Livre (FSPL)", "FSPL(dB) = 20 log(d) + 20 log(f) + 20 log(4π/c)", "Perda de percurso no espaço livre em dB; d em metros, f em Hz.", "Friis", "1946", "d=1 km, f=1 GHz: FSPL≈92,4 dB"),
                    new("Impedância de Espaço Livre", "η₀ = sqrt(μ₀/ε₀) ≈ 377 Ω", "Impedância intrínseca do vácuo; relação E/H para onda plana.", "Eletromagnetismo (Maxwell)", "Séc. XIX", "Dipolo de meia onda: Zin≈73 Ω; adaptação minimiza reflexões"),
                    new("Dipolo de Meia Onda", "L = λ/2 ≈ c/(2f)", "Comprimento do dipolo ressonante de meia onda; ganho≈2,15 dBi.", "H. Hertz", "1888", "f=2,4 GHz: L=6,25 cm; f=433 MHz: L≈34,6 cm"),
                    new("Taxa de Nyquist (Canal Sem Ruído)", "C_Nyquist = 2B·log₂(M)", "Taxa máxima em canal sem ruído com banda B e M níveis de sinal.", "H. Nyquist", "1924", "B=3 kHz, M=8: C=18 kbps"),
                    new("VSWR e Coeficiente de Reflexão", "VSWR = (1+|Γ|)/(1−|Γ|);  Γ = (ZL−Z₀)/(ZL+Z₀)", "Relação de onda estacionária de tensão; ZL=carga, Z₀=impedância da linha.", "Teoria de linhas de transmissão", "Séc. XX", "ZL=75 Ω, Z₀=50 Ω: Γ=0,2 → VSWR=1,5"),
                    new("Constante de Propagação em Linha com Perdas", "γ = α + jβ = sqrt[(R+jωL)(G+jωC)]", "α=atenuação, β=fase; R,L,G,C por unidade de comprimento da linha.", "Heaviside", "1887", "Cabo coaxial RG58 a 100 MHz: α≈0,22 dB/m"),
                    new("EIRP (Potência Isotrópica Radiada Equivalente)", "EIRP(dBm) = Pt(dBm) + Gt(dBi) − L_cabo(dB)", "Potência aparente na direção de maior ganho, incluindo perdas de cabo.", "Normas ITU e ANATEL", "Séc. XX", "Pt=23 dBm, Gt=15 dBi, L=2 dB: EIRP=36 dBm"),
                    new("Ganho de Antena Yagi-Uda", "G ≈ 10·log₁₀(0,8·n_e) dBd", "Ganho aproximado de Yagi com n_e elementos; dBd=dB relativo ao dipolo de referência.", "H. Yagi, S. Uda", "1926", "Yagi 5 elementos: G≈6 dBd≈8,15 dBi"),
                    new("Capacidade MIMO (múltiplas antenas)", "C = B·Σᵢ log₂(1 + λᵢ·SNR/N_t)", "Capacidade de sistema MIMO com N_t transmissores; λᵢ=autovalores da matriz de canal normalizado.", "Telatar; Foschini & Gans", "1998-1999", "MIMO 4×4: capacidade até 4× maior que SISO em canal ideal")
                });

            AdicionarPacoteVol12Detalhado(
                "Mecânica dos Fluidos Computacional (CFD)",
                "Equações Governantes",
                41,
                new List<Vol12FormulaSpec>
                {
                    new("Equações de Navier-Stokes", "∂(ρu)/∂t + ∇·(ρuu) = −∇p + μ∇²u + ρg", "Conservação de momento para fluido Newtoniano compressível; base de todo software CFD.", "C.L. Navier; G.G. Stokes", "1822-1845", "Base de OpenFOAM, ANSYS Fluent, StarCCM+"),
                    new("Número de Reynolds", "Re = ρuL/μ = uL/ν", "Razão entre forças inerciais e viscosas; Re<2300 (laminar), Re>4000 (turbulento) em tubo.", "O. Reynolds", "1883", "Água a 20°C, u=1 m/s, L=0,05 m: Re=50000 (turbulento)"),
                    new("Equação de Continuidade", "∂ρ/∂t + ∇·(ρu) = 0", "Conservação de massa em forma diferencial; para incompressível: ∇·u=0.", "Mecânica dos Fluidos clássica", "Séc. XIX", "Em CFD incompressível, ∇·u=0 é imposta a cada passo de tempo"),
                    new("Equação de Bernoulli", "p + ½ρu² + ρgz = const", "Conservação de energia mecânica para escoamento estacionário, incompressível e irrotacional.", "D. Bernoulli", "1738", "Tubo de Venturi: pressão cai onde velocidade aumenta"),
                    new("Modelo de Turbulência k-ε", "Dk/Dt = ∇·[(μ+μt/σk)∇k] + Pk − ε;  μt = ρCμk²/ε", "Modelo de turbulência de duas equações; k=energia cinética turbulenta, ε=taxa de dissipação.", "Launder & Spalding", "1974", "Constantes padrão: Cμ=0,09, C₁ε=1,44, C₂ε=1,92"),
                    new("Critério de Estabilidade CFL", "CFL = u·Δt/Δx ≤ 1", "Número de Courant-Friedrichs-Lewy; condição de estabilidade para esquemas explícitos.", "R. Courant, K. Friedrichs, H. Lewy", "1928", "u=10 m/s, Δx=0,01 m → Δt≤0,001 s"),
                    new("Coeficiente de Arrasto", "CD = 2FD / (ρu²A)", "Coeficiente adimensional de arrasto; FD=força de arrasto, A=área de referência.", "Aerodinâmica clássica", "Séc. XX", "Esfera em Re≈10⁵: CD≈0,47; após transição: CD≈0,1"),
                    new("Lei da Parede Logarítmica", "u⁺ = (1/κ)·ln(y⁺) + B;  κ=0,41, B≈5,5", "Perfil de velocidade na região logarítmica de camada limite turbulenta; u⁺=u/u_τ, y⁺=yu_τ/ν.", "T. von Kármán", "1930", "Válida para 30<y⁺<300; usada para wall functions em CFD"),
                    new("Equação de Pressão de Poisson (CFD)", "∇²p = −ρ ∇·(u·∇u)", "Equação elíptica para pressão derivada da condição ∇·u=0; resolvida a cada iteração no método de projeção.", "A.J. Chorin", "1968", "Solver SIMPLE/PISO resolve esta equação iterativamente"),
                    new("Número de Mach", "Ma = u/a;  a = sqrt(γRT)", "Razão velocidade de escoamento / velocidade do som; γ=razão de calores específicos.", "E. Mach", "1887", "Ma<0,3 incompressível; Ma>1 supersônico; Ma>5 hipersônico"),
                    new("Relações de Rankine-Hugoniot", "ρ₁u₁=ρ₂u₂;  p₁+ρ₁u₁²=p₂+ρ₂u₂²;  h₁+u₁²/2=h₂+u₂²/2", "Conservação através de onda de choque normal; índices 1,2=antes/após choque.", "W.J.M. Rankine; P.H. Hugoniot", "1870-1889", "Em choque forte Ma→∞: ρ₂/ρ₁→(γ+1)/(γ−1)=6 para ar"),
                    new("Equação de Darcy-Weisbach", "Δp = f·(L/D)·(ρu²/2)", "Perda de carga em tubo; f=fator de atrito de Darcy, L=comprimento, D=diâmetro.", "H. Darcy; J. Weisbach", "1845-1857", "L=100 m, D=0,1 m, u=2 m/s, f=0,02: Δp=4 kPa"),
                    new("Equação de Colebrook-White", "1/sqrt(f) = −2 log(ε/(3,7D) + 2,51/(Re·sqrt(f)))", "Equação implícita para fator de atrito em tubo rugoso; ε=rugosidade absoluta.", "C.F. Colebrook; C.M. White", "1939", "Aço comercial: ε≈0,046 mm; solução por diagrama de Moody"),
                    new("Modelo SST k-ω (Menter)", "μt = ρk/max(ω, S·F₂/a₁);  F₁,F₂=funções de mistura", "Combina k-ω perto da parede e k-ε longe dela via funções de mistura F₁, F₂.", "F.R. Menter", "1994", "Padrão industrial em aeronáutica e turbomáquinas"),
                    new("Coeficiente de Sustentação (Lift)", "CL = 2FL / (ρu²S)", "Coeficiente de sustentação aerodinâmica; FL=força de sustentação, S=área alar de referência.", "Kutta-Joukowski", "1902-1906", "Aerofólio NACA 2412 a α=5°: CL≈0,55"),
                    new("Número de Strouhal", "St = f·D/U", "Frequência adimensional de desprendimento de vórtice; f=frequência, D=diâmetro, U=velocidade.", "V. Strouhal", "1878", "Cilindro a Re≈10³–10⁵: St≈0,2"),
                    new("Equação da Camada Limite de Prandtl", "u·∂u/∂x + v·∂u/∂y = ν·∂²u/∂y²", "Equação simplificada para camada limite laminar em placa plana; solução exata de Blasius.", "L. Prandtl", "1904", "Solução de Blasius: δ≈5x/sqrt(Re_x)"),
                    new("Viscosidade de Smagorinsky (LES)", "μt = (Cs·Δ)²·|S̄|;  Cs≈0,1–0,2", "Modelo de subgrade LES; Δ=tamanho do filtro de malha, S̄=tensor de deformação filtrado.", "J. Smagorinsky", "1963", "LES resolve grandes escalas; SGS captura pequenas"),
                    new("Número de Nusselt", "Nu = hL/k", "Razão convecção/condução; h=coeficiente de convecção, L=comprimento, k=condutividade.", "W. Nusselt", "1909", "Nu=100 implica convecção 100× mais eficiente que condução"),
                    new("Espessura de Deslocamento da Camada Limite", "δ* = ∫₀^∞ (1 − u/U∞) dy", "Espessura de deslocamento; medida do deslocamento do escoamento externo pela camada viscosa.", "L. Prandtl", "1904", "Placa plana: δ*≈1,72x/sqrt(Re_x)")
                });

            AdicionarPacoteVol12Detalhado(
                "Ciência Cognitiva e Modelagem Neural",
                "Neurônios e Circuitos",
                61,
                new List<Vol12FormulaSpec>
                {
                    new("Modelo de Hodgkin-Huxley", "C dV/dt = −gNam³h(V−ENa) − gKn⁴(V−EK) − gL(V−EL) + I", "Modelo biofísico de potencial de ação; m,h,n=variáveis de portão, C=capacitância de membrana.", "A.L. Hodgkin, A.F. Huxley", "1952", "Disparo neuronal: pico de +40 mV em ~1 ms; repolarização por K⁺"),
                    new("Neurônio de Integra-e-Dispara (LIF)", "τm dV/dt = −V + R·I;  se V≥Vth → disparo e reset", "Modelo simplificado de neurônio; τm=constante de tempo, R=resistência, Vth=limiar.", "L. Lapicque", "1907", "τm=20 ms, R=100 MΩ, I=0,15 nA: taxa≈20 Hz"),
                    new("Lei de Hebb (Aprendizado Sináptico)", "Δwᵢⱼ = η·xᵢ·xⱼ", "Fortalecimento sináptico quando pré- e pós-sináptico disparam conjuntamente; base do aprendizado associativo.", "D.O. Hebb", "1949", "Base de redes de Hopfield e aprendizado por correlação"),
                    new("Capacidade de Hopfield", "p_max ≈ 0,138·N", "Número máximo de padrões armazenáveis em rede de Hopfield de N neurônios.", "J.J. Hopfield", "1982", "N=1000 neurônios: armazena até ≈138 padrões"),
                    new("Backpropagation (Regra Delta)", "δₗ = (Wₗ₊₁ᵀ δₗ₊₁) ⊙ σ'(zₗ);  ∂L/∂Wₗ = δₗ aₗ₋₁ᵀ", "Gradiente de perda em camada l por regra da cadeia; base do treinamento de redes profundas.", "Rumelhart, Hinton, Williams", "1986", "Base de todo framework de deep learning moderno"),
                    new("Função Softmax", "σ(z)ᵢ = exp(zᵢ) / Σⱼ exp(zⱼ)", "Converte vetor de scores em distribuição de probabilidade; usada na camada de saída para classificação.", "Boltzmann, adaptado para DL", "Séc. XX", "z=[2,1,0,3] → σ≈[0,24; 0,09; 0,03; 0,64]"),
                    new("Entropia de Shannon", "H(X) = −Σᵢ p(xᵢ)·log₂ p(xᵢ)", "Medida de incerteza/informação; H máxima para distribuição uniforme.", "C.E. Shannon", "1948", "Moeda justa: H=1 bit; dado justo: H=log₂6≈2,58 bits"),
                    new("Princípio de Energia Livre de Friston", "F = E_q[ln q(s) − ln p(o,s)] ≥ −ln p(o)", "Cérebro minimiza energia livre variacional F; unifica percepção, aprendizado e controle.", "K. Friston", "2010", "Base do 'Free Energy Principle'; explica ação e percepção como minimização de surpresa"),
                    new("STDP (Plasticidade por Tempo de Disparo)", "Δw = A₊ exp(−Δt/τ₊) se Δt>0;  −A₋ exp(Δt/τ₋) se Δt<0", "Spike-Timing Dependent Plasticity: potencia/deprime sinapse conforme ordem temporal de disparos.", "Markram et al.; Bi & Poo", "1997-1998", "Janela temporal ±20 ms; base neural de memória sequencial"),
                    new("Curva de Tuning Gaussiana (Codificação Neuronal)", "r(θ) = r_max·exp(−(θ−θ_pref)²/(2σ²))", "Taxa de disparo r em função do estímulo θ; base da codificação populacional.", "Georgopoulos et al.", "1986", "Neurônios motores codificam direção do movimento em 360°"),
                    new("Lei de Fitts", "MT = a + b·log₂(2D/W)", "Tempo de movimento MT para alvo a distância D e largura W; base de ergonomia de interface.", "P.M. Fitts", "1954", "D=30 cm, W=1 cm: ID≈5,9 bits; fundamental para design de UI"),
                    new("Lei de Hick (Tempo de Reação)", "RT = a + b·log₂(n)", "Tempo de reação RT aumenta logaritmicamente com n escolhas; lei fundamental de HCI.", "W.E. Hick", "1952", "2 escolhas: RT≈280 ms; 8 escolhas: RT≈500 ms"),
                    new("Equação do Cabo Neural (Rall)", "λ²·∂²V/∂x² = τm·∂V/∂t + V;  λ = sqrt(r_m/r_a)", "Equação do cabo para neurônio passivo; λ=constante de espaço, τm=constante de tempo.", "W. Rall", "1959", "Axônio mielinizado: λ≈1–2 mm; desmielinizado: ≈0,1 mm"),
                    new("Complexidade de Lempel-Ziv (EEG)", "C(n) = número de frases distintas na decomposição LZ", "LZC mede imprevisibilidade de EEG; maior C = mais consciente; usado em anestesia e sono.", "Lempel & Ziv; Casali et al.", "1976-2013", "LZC EEG em sono NREM < vigília; correlaciona com nível de consciência"),
                    new("Teoria de Integração de Informação (Φ)", "Φ = min_{bipartição} D(p(X) ‖ p(X₁)p(X₂))", "Informação integrada acima das partes; Φ>0 necessário para consciência segundo IIT de Tononi.", "G. Tononi", "2004", "Córtex tem Φ alto; cerebelo tem Φ baixo apesar de muitos neurônios"),
                    new("Modelo de Rescorla-Wagner", "ΔVcs = α·β·(λ − ΣV)", "Mudança em força associativa; α=saliência do CS, β=taxa de aprendizado, λ=assíntota, ΣV=predição atual.", "R.A. Rescorla, A.R. Wagner", "1972", "Base do aprendizado por diferença temporal (TD) em RL"),
                    new("Correlação Cruzada Neural", "CCF(τ) = <r₁(t)·r₂(t+τ)> / (σ₁σ₂)", "Correlação temporal entre disparos de dois neurônios; τ=atraso; pico em τ=0 indica sincronização.", "Neurociência de sistemas", "Séc. XX", "Sincronização gama (30–80 Hz) associada a binding perceptual"),
                    new("Sparse Coding (Codificação Esparsa)", "min ||x − Ds||² + λ||s||₁", "Representação eficiente: reconstruir x com poucas ativações no dicionário D; λ=esparsidade.", "Olshausen & Field", "1996", "Neurônios V1 codificam bordas de forma esparsa; base de autoencoders"),
                    new("Wilson-Cowan (Populações Neurais)", "τe dE/dt = −E + (1−E)·F(aE·E − aI·I + Pe)", "Equações de campo médio para populações excitatória E e inibitória I; modelam oscilações neurais.", "H.R. Wilson, J.D. Cowan", "1972", "Modelam oscilações alfa, gama e crises epilépticas"),
                    new("Regra de Aprendizado do Perceptron", "w ← w + η·(y−ŷ)·x", "Atualização de pesos quando previsão ŷ≠rótulo y; converge se dados linearmente separáveis.", "F. Rosenblatt", "1958", "Convergência garantida pelo teorema de convergência do perceptron")
                });

            AdicionarPacoteVol12Detalhado(
                "Engenharia Biomédica e Dispositivos Médicos",
                "Eletrofisiologia",
                81,
                new List<Vol12FormulaSpec>
                {
                    new("Equação de Nernst (Eletrofisiologia)", "E = (RT/zF)·ln([ion]_ext/[ion]_int)", "Potencial de equilíbrio para íon de valência z; base da eletrofisiologia celular.", "W. Nernst", "1888", "K⁺ em neurônio: E_K≈−90 mV; Na⁺: E_Na≈+60 mV"),
                    new("Fórmula de Goldman (Potencial de Membrana)", "Vm = (RT/F)·ln[(PK[K]o+PNa[Na]o+PCl[Cl]i)/(PK[K]i+PNa[Na]i+PCl[Cl]o)]", "Potencial de membrana em repouso considerando permeabilidades de K⁺, Na⁺, Cl⁻.", "D. Goldman; Hodgkin & Katz", "1943-1949", "Neurônio em repouso: Vm≈−70 mV (K⁺ dominante)"),
                    new("Dose Absorvida de Radiação", "D = dE/dm  [Gy = J/kg]", "Energia ionizante depositada por unidade de massa; 1 Gray=1 J/kg; 1 rad=0,01 Gy.", "Física médica; ICRU", "Séc. XX", "CT torácico≈7 mGy; radioterapia fracionada: 2 Gy/sessão"),
                    new("Modelo Linear-Quadrático (Sobrevivência Celular)", "S(D) = exp(−αD − βD²)", "Fração de sobrevivência celular a dose D; α/β≈10 Gy para tumores, ≈3 Gy para tecidos tardios.", "Douglas & Fowler", "1976", "D=2 Gy, α=0,3, β=0,03: S≈0,487"),
                    new("Lei de Poiseuille (Vasos Sanguíneos)", "Q = πr⁴Δp / (8μL)", "Fluxo volumétrico Q em tubo de raio r, comprimento L, viscosidade μ, gradiente Δp.", "J.L.M. Poiseuille", "1840", "Estenose 50% raio: fluxo cai para (0,5)⁴=6,25% do original"),
                    new("Lei de Frank-Starling", "SV ∝ EDV (pré-carga)", "Volume sistólico SV aumenta com volume diastólico final EDV até ponto ótimo de estiramento miocárdico.", "O. Frank; E.H. Starling", "1895-1918", "Exercício: EDV↑→SV↑; insuficiência cardíaca: curva deslocada"),
                    new("Princípio de Fick (Débito Cardíaco)", "CO = VO₂ / (CaO₂ − CvO₂)", "Débito cardíaco CO por consumo de O₂; VO₂=consumo, CaO₂,CvO₂=conteúdo arterial/venoso.", "A. Fick", "1870", "Repouso: VO₂=250 mL/min, ΔC=5 mL/dL → CO=5 L/min"),
                    new("Impedância Bioelétrica (BIA)", "Z = sqrt(R² + Xc²);  Xc = 1/(2πfC)", "Impedância elétrica do corpo; R=resistência, Xc=reatância por membranas celulares; f=50 kHz típico.", "H. Thomasset", "1962", "Correlaciona com água corporal total e massa magra"),
                    new("Equação de Bloch (MRI)", "dM/dt = γ(M×B) − (Mx i+My j)/T2 − (Mz−M₀)k/T1", "Evolução da magnetização nuclear M; T1=relaxação longitudinal, T2=transversal; γ=razão giromagnética.", "F. Bloch", "1946", "T1 gordura≈260 ms, T2≈85 ms em 1,5 T; base do contraste MRI"),
                    new("Lei de Beer-Lambert (Oximetria)", "A = ε·c·l = log₁₀(I₀/I)", "Absorbância A em função de concentração c e caminho óptico l; ε=coeficiente de extinção molar.", "A. Beer; J.H. Lambert", "1760-1852", "Oxímetro usa λ=660 nm e 940 nm para calcular SpO₂"),
                    new("Número de Womersley", "Wo = R·sqrt(ω/ν)", "Parâmetro de fluxo pulsátil em vasos; R=raio, ω=frequência angular, ν=viscosidade cinemática.", "J.R. Womersley", "1955", "Aorta: Wo≈20 (perfil plano); vasos periféricos: Wo<2 (Poiseuille válido)"),
                    new("Modelo de SLS para Tecido Viscoelástico", "σ + (η₁/E₁)dσ/dt = E₂ε + η₁(1+E₂/E₁)dε/dt", "Standard Linear Solid para tecido viscoelástico; E₁,E₂=módulos, η₁=viscosidade.", "Lord Kelvin", "1875", "Cartilagem, tendão e vasos modelados como SLS para impacto"),
                    new("Energia por Pulso de Marcapasso", "E = V²·tp / (2·R_eletrodo)", "Energia por pulso; V=amplitude, tp=largura de pulso, R=impedância do eletrodo.", "Engenharia de dispositivos cardíacos", "Séc. XX", "V=2,5 V, tp=0,4 ms, R=500 Ω: E≈1,25 μJ por pulso"),
                    new("Limiar de Weiss (Cronaxia)", "I_th = I_rh·(1 + tc/tp)", "Corrente limiar de estimulação neural; I_rh=reobase, tc=cronaxia, tp=largura de pulso.", "G. Weiss", "1901", "Nervo motor: cronaxia≈0,1 ms; músculo cardíaco: ≈2 ms"),
                    new("Equação de Starling Transcapilar", "Jv = Lp·[(Pc−Pi) − σ(πc−πi)]", "Fluxo de fluido transcapilar; Lp=condutividade hidráulica, P=pressões hidrostáticas, π=oncóticas, σ=reflexão.", "E.H. Starling", "1896", "Edema quando Pc↑ ou πc↓; base da fisiologia microcirculatória"),
                    new("Índice de Massa Corporal (IMC)", "IMC = m/h²  [kg/m²]", "Índice de referência nutricional; m=massa em kg, h=altura em metros.", "A. Quetelet", "1832", "IMC 18,5–24,9: normal; ≥30: obeso; <18,5: baixo peso (OMS)"),
                    new("Resolução Axial de Ultrassom", "Δz = c/(2f·B)", "Resolução axial de ultrassom médico; c=velocidade do som no tecido, f=frequência central, B=largura de banda.", "Ultrassonografia diagnóstica", "Séc. XX", "f=5 MHz, c=1540 m/s: Δz≈0,15 mm"),
                    new("Equação de Pennes (Bioheat)", "dT/dt = α∇²T + ωb·cb·(Tart−T)/ρc + Qmet/ρc", "Transferência de calor em tecido biológico; ωb=perfusão, cb=calor do sangue, Qmet=calor metabólico.", "H.H. Pennes", "1948", "Base de hipertermia oncológica e ablação por radiofrequência"),
                    new("Pressão de Pulso e Complacência Arterial", "C = ΔV/ΔP;  PP = PAS − PAD", "Complacência arterial C; pressão de pulso PP=sistólica−diastólica; C↓ com envelhecimento e arteriosclerose.", "Hemodinâmica clínica", "Séc. XX", "Adulto jovem: PP≈40 mmHg; PP>60 mmHg indica rigidez arterial"),
                    new("Resolução de Ressonância Magnética (k-space)", "Δx = 1/(N·Δk);  Δk = γG·Δt/(2π)", "Resolução espacial MRI; N=pontos de amostragem, G=gradiente, γ=razão giromagnética, Δt=passo de tempo.", "P. Lauterbur, P. Mansfield", "2003", "FOV=24 cm, N=256: Δx≈0,94 mm de resolução nominal")
                });
        }
    }
}