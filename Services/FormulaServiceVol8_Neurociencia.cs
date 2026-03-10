using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE III: NEUROCIÊNCIA COMPUTACIONAL E NEURODINÂMICA
    // Modelos de neurônios, sinapse, redes neurais biológicas
    // 21 fórmulas (043-063)
    // ========================================

    public static Formula V8_NC043_HodgkinHuxley()
    {
        return new Formula
        {
            Id = "V8-NC043",
            CodigoCompendio = "043",
            Nome = "Modelo Hodgkin-Huxley — Potencial de Ação",
            Categoria = "Neurociência",
            SubCategoria = "Neurodinâmica",
            Expressao = "C*dV/dt = gNa*m³*h*(ENa-V) + gK*n⁴*(EK-V) + gL*(EL-V) + I",
            ExprTexto = "Potencial de membrana neural",
            Descricao = "Modelo clássico de potencial de ação. m,h,n=variáveis de ativação/inativação.",
            Criador = "Hodgkin e Huxley",
            AnoOrigin = "1952",
            ExemploPratico = "gNa=120mS/cm², gK=36mS/cm², gL=0,3mS/cm². Nobel 1963. Base de neurociência computacional",
            Unidades = "mV",
            VariavelResultado = "dV_dt",
            UnidadeResultado = "mV/ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "C", Nome = "Capacitância", Descricao = "Capacitância membrana", Unidade = "µF/cm²", ValorPadrao = 1, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "gNa", Nome = "Condutância Na⁺", Descricao = "gNa", Unidade = "mS/cm²", ValorPadrao = 120, ValorMin = 0, ValorMax = 200, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "Ativação Na⁺", Descricao = "m gate", Unidade = "", ValorPadrao = 0.05, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Inativação Na⁺", Descricao = "h gate", Unidade = "", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "ENa", Nome = "Potencial reversão Na⁺", Descricao = "ENa", Unidade = "mV", ValorPadrao = 50, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "V", Nome = "Potencial membrana", Descricao = "V(t)", Unidade = "mV", ValorPadrao = -70, ValorMin = -100, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "gK", Nome = "Condutância K⁺", Descricao = "gK", Unidade = "mS/cm²", ValorPadrao = 36, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "n", Nome = "Ativação K⁺", Descricao = "n gate", Unidade = "", ValorPadrao = 0.32, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "EK", Nome = "Potencial reversão K⁺", Descricao = "EK", Unidade = "mV", ValorPadrao = -77, ValorMin = -100, ValorMax = 0, Obrigatoria = true },
                new() { Simbolo = "gL", Nome = "Condutância leak", Descricao = "gL", Unidade = "mS/cm²", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "EL", Nome = "Potencial reversão leak", Descricao = "EL", Unidade = "mV", ValorPadrao = -54.4, ValorMin = -100, ValorMax = 0, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente injetada", Descricao = "I", Unidade = "µA/cm²", ValorPadrao = 10, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double C = inputs["C"];
                double gNa = inputs["gNa"];
                double m = inputs["m"];
                double h = inputs["h"];
                double ENa = inputs["ENa"];
                double V = inputs["V"];
                double gK = inputs["gK"];
                double n = inputs["n"];
                double EK = inputs["EK"];
                double gL = inputs["gL"];
                double EL = inputs["EL"];
                double I = inputs["I"];
                
                double INa = gNa * Math.Pow(m, 3) * h * (ENa - V);
                double IK = gK * Math.Pow(n, 4) * (EK - V);
                double IL = gL * (EL - V);
                
                return (INa + IK + IL + I) / C;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC044_FitzHughNagumo()
    {
        return new Formula
        {
            Id = "V8-NC044",
            CodigoCompendio = "044",
            Nome = "Modelo FitzHugh-Nagumo",
            Categoria = "Neurociência",
            SubCategoria = "Neurodinâmica",
            Expressao = "dv/dt = v - v³/3 - w + I; dw/dt = ε*(v + a - b*w)",
            ExprTexto = "Modelo simplificado de neurônio",
            Descricao = "Simplificação de Hodgkin-Huxley: v=voltagem, w=recuperação. Bifurcação em I.",
            Criador = "FitzHugh, Nagumo",
            AnoOrigin = "1961",
            ExemploPratico = "a=0,7; b=0,8; ε=0,08. Exibe oscilões e excitabilidade. Base de análise dinâmica neural",
            Unidades = "adimensional",
            VariavelResultado = "dv_dt",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v", Nome = "Variável rápida", Descricao = "Voltagem adimensional", Unidade = "", ValorPadrao = 0, ValorMin = -3, ValorMax = 3, Obrigatoria = true },
                new() { Simbolo = "w", Nome = "Variável lenta", Descricao = "Recuperação", Unidade = "", ValorPadrao = 0, ValorMin = -3, ValorMax = 3, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente", Descricao = "I aplicado", Unidade = "", ValorPadrao = 0.5, ValorMin = -2, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Parâmetro a", Descricao = "a", Unidade = "", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Parâmetro b", Descricao = "b", Unidade = "", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "epsilon", Nome = "Escala temporal", Descricao = "ε", Unidade = "", ValorPadrao = 0.08, ValorMin = 0.001, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v = inputs["v"];
                double w = inputs["w"];
                double I = inputs["I"];
                return v - Math.Pow(v, 3) / 3 - w + I;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC045_IzhikevichNeuron()
    {
        return new Formula
        {
            Id = "V8-NC045",
            CodigoCompendio = "045",
            Nome = "Modelo de Izhikevich",
            Categoria = "Neurociência",
            SubCategoria = "Neurodinâmica",
            Expressao = "dv/dt = 0,04*v² + 5*v + 140 - u + I; du/dt = a*(b*v - u)",
            ExprTexto = "Neurônio com burst",
            Descricao = "v(t)≥30mV → reset: v=c, u=u+d. Simula 20+ tipos de neurônios (regular, burst, chattering).",
            Criador = "Eugene Izhikevich",
            AnoOrigin = "2003",
            ExemploPratico = "Regular spiking: a=0,02; b=0,2; c=-65; d=8. Fast spiking: a=0,1; b=0,2; c=-65; d=2",
            Unidades = "mV/ms",
            VariavelResultado = "dv_dt",
            UnidadeResultado = "mV/ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v", Nome = "Potencial membrana", Descricao = "v(t)", Unidade = "mV", ValorPadrao = -70, ValorMin = -100, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "u", Nome = "Variável recuperação", Descricao = "u(t)", Unidade = "mV", ValorPadrao = -14, ValorMin = -30, ValorMax = 30, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente sináptica", Descricao = "I", Unidade = "pA", ValorPadrao = 10, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "a", Nome = "Parâmetro a", Descricao = "Escala temporal u", Unidade = "", ValorPadrao = 0.02, ValorMin = 0.001, ValorMax = 0.2, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Parâmetro b", Descricao = "Sensibilidade u a v", Unidade = "", ValorPadrao = 0.2, ValorMin = 0.1, ValorMax = 0.3, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v = inputs["v"];
                double u = inputs["u"];
                double I = inputs["I"];
                return 0.04 * v * v + 5 * v + 140 - u + I;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC046_LeakyIntegrate()
    {
        return new Formula
        {
            Id = "V8-NC046",
            CodigoCompendio = "046",
            Nome = "Leaky Integrate-and-Fire (LIF)",
            Categoria = "Neurociência",
            SubCategoria = "Neurodinâmica",
            Expressao = "τ*dV/dt = -(V - Vrest) + R*I",
            ExprTexto = "Modelo LIF",
            Descricao = "V≥Vthreshold → spike e reset para Vreset. τ=tempo de membrana.",
            Criador = "Lapicque",
            AnoOrigin = "1907",
            ExemploPratico = "τ=20ms, Vthreshold=-50mV, Vrest=-70mV. Base de redes de neurônios artificiais spiking",
            Unidades = "mV/ms",
            VariavelResultado = "dV_dt",
            UnidadeResultado = "mV/ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "tau", Nome = "Constante temporal", Descricao = "τ membrana", Unidade = "ms", ValorPadrao = 20, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "V", Nome = "Potencial membrana", Descricao = "V(t)", Unidade = "mV", ValorPadrao = -65, ValorMin = -100, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "Vrest", Nome = "Potencial repouso", Descricao = "Vrest", Unidade = "mV", ValorPadrao = -70, ValorMin = -100, ValorMax = -50, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Resistência", Descricao = "R da membrana", Unidade = "MΩ", ValorPadrao = 10, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente", Descricao = "I injetada", Unidade = "nA", ValorPadrao = 2, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double tau = inputs["tau"];
                double V = inputs["V"];
                double Vrest = inputs["Vrest"];
                double R = inputs["R"];
                double I = inputs["I"];
                return (-(V - Vrest) + R * I) / tau;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC047_FrequenciaSpike()
    {
        return new Formula
        {
            Id = "V8-NC047",
            CodigoCompendio = "047",
            Nome = "Frequência de Disparo (FI Curve)",
            Categoria = "Neurociência",
            SubCategoria = "Neurodinâmica",
            Expressao = "f = 1/(τ*ln((R*I - (Vthreshold - Vrest))/(R*I - (Vreset - Vrest))))",
            ExprTexto = "Curva FI do LIF",
            Descricao = "Frequência-Intensidade: relação input-output de neurônio. Ganho neuronal.",
            Criador = "Derivação analítica LIF",
            AnoOrigin = "~1950",
            ExemploPratico = "I>Ithreshold=(Vthreshold-Vrest)/R. Íon=1nA, R=10MΩ → Ithreshold=2nA",
            Unidades = "Hz",
            VariavelResultado = "f",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "tau", Nome = "Constante temporal", Descricao = "τ", Unidade = "ms", ValorPadrao = 20, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Resistência", Descricao = "R", Unidade = "MΩ", ValorPadrao = 10, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "Corrente", Descricao = "I", Unidade = "nA", ValorPadrao = 3, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "Vthreshold", Nome = "Limiar", Descricao = "Vthreshold", Unidade = "mV", ValorPadrao = -50, ValorMin = -60, ValorMax = -40, Obrigatoria = true },
                new() { Simbolo = "Vrest", Nome = "Repouso", Descricao = "Vrest", Unidade = "mV", ValorPadrao = -70, ValorMin = -80, ValorMax = -60, Obrigatoria = true },
                new() { Simbolo = "Vreset", Nome = "Reset", Descricao = "Vreset", Unidade = "mV", ValorPadrao = -70, ValorMin = -80, ValorMax = -60, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double tau = inputs["tau"];
                double R = inputs["R"];
                double I = inputs["I"];
                double Vthreshold = inputs["Vthreshold"];
                double Vrest = inputs["Vrest"];
                double Vreset = inputs["Vreset"];
                
                double numerador = R * I - (Vthreshold - Vrest);
                double denominador = R * I - (Vreset - Vrest);
                
                if (numerador <= 0 || denominador <= 0) return 0;
                
                return 1000.0 / (tau * Math.Log(numerador / denominador)); // 1000 para converter ms -> Hz
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC048_SinapseCorrentes()
    {
        return new Formula
        {
            Id = "V8-NC048",
            CodigoCompendio = "048",
            Nome = "Corrente Sináptica Exponencial",
            Categoria = "Neurociência",
            SubCategoria = "Sinapse",
            Expressao = "Isyn(t) = g*exp(-t/τ)*(Vpost - Esyn)",
            ExprTexto = "Corrente pós-sináptica",
            Descricao = "Decaimento exponencial da condutância sináptica. Esyn: 0mV (AMPA), -70mV (GABA).",
            Criador = "Rall",
            AnoOrigin = "1967",
            ExemploPratico = "AMPA: τ=5ms, g=1nS. GABA: τ=10ms. Simulações de redes neurais",
            Unidades = "pA",
            VariavelResultado = "Isyn",
            UnidadeResultado = "pA",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "g", Nome = "Condutância sináptica", Descricao = "g pico", Unidade = "nS", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "t após spike", Unidade = "ms", ValorPadrao = 5, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "tau", Nome = "Constante temporal", Descricao = "τ sinapse", Unidade = "ms", ValorPadrao = 5, ValorMin = 1, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "Vpost", Nome = "Potencial pós-sináptico", Descricao = "Vpost", Unidade = "mV", ValorPadrao = -65, ValorMin = -100, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "Esyn", Nome = "Potencial reversão", Descricao = "Esyn", Unidade = "mV", ValorPadrao = 0, ValorMin = -80, ValorMax = 20, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double g = inputs["g"];
                double t = inputs["t"];
                double tau = inputs["tau"];
                double Vpost = inputs["Vpost"];
                double Esyn = inputs["Esyn"];
                return g * Math.Exp(-t / tau) * (Vpost - Esyn);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC049_STDP()
    {
        return new Formula
        {
            Id = "V8-NC049",
            CodigoCompendio = "049",
            Nome = "STDP — Spike-Timing Dependent Plasticity",
            Categoria = "Neurociência",
            SubCategoria = "Plasticidade Sináptica",
            Expressao = "Δw = A*exp(-|Δt|/τ)*sign(Δt)",
            ExprTexto = "Mudança de peso sináptico",
            Descricao = "Δt>0 (pré antes de pós): LTP (w↑). Δt<0: LTD (w↓). Base de aprendizado hebbiano temporal.",
            Criador = "Markram, Bi, Poo",
            AnoOrigin = "1997",
            ExemploPratico = "τ=20ms, A=0,01. Δt=+10ms → Δw=+0,006 (reforço). Janela temporal ±50ms",
            Unidades = "adimensional",
            VariavelResultado = "Δw",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "A", Nome = "Amplitude", Descricao = "A máximo", Unidade = "", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "Delta_t", Nome = "Diferença temporal", Descricao = "Δt = tpost - tpre", Unidade = "ms", ValorPadrao = 10, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "tau", Nome = "Constante temporal", Descricao = "τ STDP", Unidade = "ms", ValorPadrao = 20, ValorMin = 5, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double A = inputs["A"];
                double Delta_t = inputs["Delta_t"];
                double tau = inputs["tau"];
                return A * Math.Exp(-Math.Abs(Delta_t) / tau) * Math.Sign(Delta_t);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC050_HebbianRule()
    {
        return new Formula
        {
            Id = "V8-NC050",
            CodigoCompendio = "050",
            Nome = "Regra de Hebb — Plasticidade Sináptica",
            Categoria = "Neurociência",
            SubCategoria = "Aprendizado Neural",
            Expressao = "Δwij = η*xi*yj",
            ExprTexto = "Mudança de peso hebbiano",
            Descricao = "Neurons that fire together wire together. Base de redes de Hopfield e aprendizado não-supervisionado.",
            Criador = "Donald Hebb",
            AnoOrigin = "1949",
            ExemploPratico = "η=0,01, xi=1, yj=0,8 → Δwij=0,008. Forma padrões atratores. BCM rule: extensão com limiar móvel",
            Unidades = "adimensional",
            VariavelResultado = "Δw",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "eta", Nome = "Taxa de aprendizado", Descricao = "η", Unidade = "", ValorPadrao = 0.01, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "xi", Nome = "Atividade pré-sináptica", Descricao = "xi", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "yj", Nome = "Atividade pós-sináptica", Descricao = "yj", Unidade = "", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double eta = inputs["eta"];
                double xi = inputs["xi"];
                double yj = inputs["yj"];
                return eta * xi * yj;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC051_RateModel()
    {
        return new Formula
        {
            Id = "V8-NC051",
            CodigoCompendio = "051",
            Nome = "Rate Model — Taxa de Disparo",
            Categoria = "Neurociência",
            SubCategoria = "Redes Neurais",
            Expressao = "τ*dr/dt = -r + F(Σ wij*rj + I)",
            ExprTexto = "Dinâmica de taxa de disparo",
            Descricao = "F=função de ativação (sigmoide, tanh, ReLU). Base de modelos de taxa contínuos.",
            Criador = "Wilson, Cowan",
            AnoOrigin = "1972",
            ExemploPratico = "F(x)=(1+exp(-x))⁻¹. Modelo de campo médio: r=frequência média de população",
            Unidades = "Hz/ms",
            VariavelResultado = "dr_dt",
            UnidadeResultado = "Hz/ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "tau", Nome = "Constante temporal", Descricao = "τ", Unidade = "ms", ValorPadrao = 10, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Taxa atual", Descricao = "r(t)", Unidade = "Hz", ValorPadrao = 10, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "F_input", Nome = "Input total", Descricao = "Σ wij*rj + I", Unidade = "", ValorPadrao = 15, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double tau = inputs["tau"];
                double r = inputs["r"];
                double F_input = inputs["F_input"];
                
                // F = sigmoide
                double F = 1.0 / (1.0 + Math.Exp(-F_input));
                
                return (-r + F) / tau;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC052_OsciladorWilsonCowan()
    {
        return new Formula
        {
            Id = "V8-NC052",
            CodigoCompendio = "052",
            Nome = "Modelo Wilson-Cowan — População Neural",
            Categoria = "Neurociência",
            SubCategoria = "Redes Neurais",
            Expressao = "dE/dt = -E + Se(c1*E - c2*I + P); dI/dt = -I + Si(c3*E - c4*I + Q)",
            ExprTexto = "Dinâmica excitatória-inibitória",
            Descricao = "E=excitatória, I=inibitória. Oscilações gama: 30-80Hz. Base de modelos de córtex.",
            Criador = "Wilson e Cowan",
            AnoOrigin = "1972",
            ExemploPratico = "c1=16, c2=12, c3=15, c4=3. Exibe oscilações, biestabilidade, sincronização",
            Unidades = "adimensional",
            VariavelResultado = "dE_dt",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "E", Nome = "População excitatória", Descricao = "E(t)", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "I", Nome = "População inibitória", Descricao = "I(t)", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "c1", Nome = "Peso E→E", Descricao = "c1", Unidade = "", ValorPadrao = 16, ValorMin = 0, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "c2", Nome = "Peso I→E", Descricao = "c2", Unidade = "", ValorPadrao = 12, ValorMin = 0, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "c3", Nome = "Peso E→I", Descricao = "c3", Unidade = "", ValorPadrao = 15, ValorMin = 0, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "P", Nome = "Input excitatório", Descricao = "P", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double E = inputs["E"];
                double I = inputs["I"];
                double c1 = inputs["c1"];
                double c2 = inputs["c2"];
                double c3 = inputs["c3"];
                double P = inputs["P"];
                
                double input_E = c1 * E - c2 * I + P;
                double Se = 1.0 / (1.0 + Math.Exp(-input_E));
                
                return -E + Se;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC053_ConstanteCableDendrite()
    {
        return new Formula
        {
            Id = "V8-NC053",
            CodigoCompendio = "053",
            Nome = "Constante de Espaço (Cable Theory)",
            Categoria = "Neurociência",
            SubCategoria = "Teoria de Cabos",
            Expressao = "λ = sqrt(rm/(ra + re))",
            ExprTexto = "Constante de espaço",
            Descricao = "Distância de decaimento eletrotônico. λ típico: 0,5-1mm. Determina integração dendrítica.",
            Criador = "Rall",
            AnoOrigin = "1959",
            ExemploPratico = "rm=20kΩ·cm, ra=70Ω·cm → λ=530µm. Decaimento V(x)=V₀·exp(-x/λ)",
            Unidades = "µm",
            VariavelResultado = "λ",
            UnidadeResultado = "µm",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "rm", Nome = "Resistência membrana", Descricao = "rm (específica)", Unidade = "kΩ·cm", ValorPadrao = 20, ValorMin = 1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "ra", Nome = "Resistência axial", Descricao = "ra (citoplasma)", Unidade = "Ω·cm", ValorPadrao = 70, ValorMin = 10, ValorMax = 200, Obrigatoria = true },
                new() { Simbolo = "re", Nome = "Resistência extracelular", Descricao = "re", Unidade = "Ω·cm", ValorPadrao = 0, ValorMin = 0, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double rm = inputs["rm"] * 1000; // kΩ→Ω
                double ra = inputs["ra"];
                double re = inputs["re"];
                return Math.Sqrt(rm / (ra + re)) * 10000; // cm→µm
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC054_PopulationCoding()
    {
        return new Formula
        {
            Id = "V8-NC054",
            CodigoCompendio = "054",
            Nome = "Código de População (Population Vector)",
            Categoria = "Neurociência",
            SubCategoria = "Codificação Neural",
            Expressao = "θ_population = atan2(Σ ri*sin(θi), Σ ri*cos(θi))",
            ExprTexto = "Direção estimada por população",
            Descricao = "Estimativa de parâmetro por voto da população. Usado em córtex motor para direção de movimento.",
            Criador = "Georgopoulos",
            AnoOrigin = "1986",
            ExemploPratico = "Neurônio 1: r₁=30Hz, θ₁=0°. Neurônio 2: r₂=20Hz, θ₂=90° → θ_pop≈37°",
            Unidades = "graus",
            VariavelResultado = "θ_pop",
            UnidadeResultado = "°",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "r1", Nome = "Taxa neurônio 1", Descricao = "r₁", Unidade = "Hz", ValorPadrao = 30, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "theta1", Nome = "Direção preferida 1", Descricao = "θ₁", Unidade = "graus", ValorPadrao = 0, ValorMin = 0, ValorMax = 360, Obrigatoria = true },
                new() { Simbolo = "r2", Nome = "Taxa neurônio 2", Descricao = "r₂", Unidade = "Hz", ValorPadrao = 20, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "theta2", Nome = "Direção preferida 2", Descricao = "θ₂", Unidade = "graus", ValorPadrao = 90, ValorMin = 0, ValorMax = 360, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double r1 = inputs["r1"];
                double theta1 = inputs["theta1"] * Math.PI / 180;
                double r2 = inputs["r2"];
                double theta2 = inputs["theta2"] * Math.PI / 180;
                
                double sum_sin = r1 * Math.Sin(theta1) + r2 * Math.Sin(theta2);
                double sum_cos = r1 * Math.Cos(theta1) + r2 * Math.Cos(theta2);
                
                return Math.Atan2(sum_sin, sum_cos) * 180 / Math.PI;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC055_TuningCurve()
    {
        return new Formula
        {
            Id = "V8-NC055",
            CodigoCompendio = "055",
            Nome = "Curva de Sintonia Neuronal (Tuning Curve)",
            Categoria = "Neurociência",
            SubCategoria = "Codificação Neural",
            Expressao = "r(θ) = r0 + rmax*exp(κ*(cos(θ-θ_pref)-1))",
            ExprTexto = "Taxa de disparo vs estímulo",
            Descricao = "Função de von Mises. κ=largura da sintonia (κ alto: seletivo). Usado em V1, MT, córtex motor.",
            Criador = "Amirikian, Georgopoulos",
            AnoOrigin = "2000",
            ExemploPratico = "θ_pref=90°, κ=2, rmax=50Hz → r(90°)=r0+50Hz. κ=0,5: tuning largo (não-seletivo)",
            Unidades = "Hz",
            VariavelResultado = "r",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "r0", Nome = "Taxa basal", Descricao = "r₀", Unidade = "Hz", ValorPadrao = 5, ValorMin = 0, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "rmax", Nome = "Resposta máxima", Descricao = "rmax", Unidade = "Hz", ValorPadrao = 50, ValorMin = 0, ValorMax = 200, Obrigatoria = true },
                new() { Simbolo = "kappa", Nome = "Largura sintonia", Descricao = "κ", Unidade = "", ValorPadrao = 2, ValorMin = 0.1, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "theta", Nome = "Ângulo estímulo", Descricao = "θ", Unidade = "graus", ValorPadrao = 90, ValorMin = 0, ValorMax = 360, Obrigatoria = true },
                new() { Simbolo = "theta_pref", Nome = "Ângulo preferido", Descricao = "θ_pref", Unidade = "graus", ValorPadrao = 90, ValorMin = 0, ValorMax = 360, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double r0 = inputs["r0"];
                double rmax = inputs["rmax"];
                double kappa = inputs["kappa"];
                double theta = inputs["theta"] * Math.PI / 180;
                double theta_pref = inputs["theta_pref"] * Math.PI / 180;
                
                return r0 + rmax * Math.Exp(kappa * (Math.Cos(theta - theta_pref) - 1));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC056_InformacaoMutua()
    {
        return new Formula
        {
            Id = "V8-NC056",
            CodigoCompendio = "056",
            Nome = "Informação Mútua — Neurônio-Estímulo",
            Categoria = "Neurociência",
            SubCategoria = "Teoria da Informação Neural",
            Expressao = "I(S;R) = Σ p(s)*p(r|s)*log2(p(r|s)/p(r))",
            ExprTexto = "Informação transmitida (bits)",
            Descricao = "Quantifica informação do estímulo S na resposta R. Usado em análise de código neural.",
            Criador = "Shannon aplicado a neurônios",
            AnoOrigin = "1959 (Barlow)",
            ExemploPratico = "Neurônio V1: I≈2-3 bits/spike sobre orientação. Retina: 1-2 bits/spike (eficiente)",
            Unidades = "bits",
            VariavelResultado = "I_mutual",
            UnidadeResultado = "bits",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "p_s", Nome = "Probabilidade estímulo", Descricao = "p(s)", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "p_r_given_s", Nome = "Prob. resposta | estímulo", Descricao = "p(r|s)", Unidade = "", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "p_r", Nome = "Prob. resposta", Descricao = "p(r)", Unidade = "", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double p_s = inputs["p_s"];
                double p_r_given_s = inputs["p_r_given_s"];
                double p_r = inputs["p_r"];
                
                if (p_r == 0) return 0;
                
                return p_s * p_r_given_s * Math.Log(p_r_given_s / p_r, 2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC057_FanoFactor()
    {
        return new Formula
        {
            Id = "V8-NC057",
            CodigoCompendio = "057",
            Nome = "Fator de Fano — Variabilidade Spike",
            Categoria = "Neurociência",
            SubCategoria = "Estatística Neural",
            Expressao = "FF = Var(n) / E[n]",
            ExprTexto = "Variância / Média",
            Descricao = "Poisson: FF=1. FF<1: sub-Poisson (regular). FF>1: super-Poisson (burst).",
            Criador = "Fano",
            AnoOrigin = "1947",
            ExemploPratico = "Córtex: FF≈1,5 (variável). Cerebelo: FF≈0,3 (regular). Quantifica ruído neural",
            Unidades = "adimensional",
            VariavelResultado = "FF",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Var_n", Nome = "Variância contagem", Descricao = "Var(n)", Unidade = "", ValorPadrao = 15, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "E_n", Nome = "Média contagem", Descricao = "E[n]", Unidade = "", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Var_n = inputs["Var_n"];
                double E_n = inputs["E_n"];
                return Var_n / E_n;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC058_CoeficienteVariacao()
    {
        return new Formula
        {
            Id = "V8-NC058",
            CodigoCompendio = "058",
            Nome = "Coeficiente de Variação (CV ISI)",
            Categoria = "Neurociência",
            SubCategoria = "Estatística Neural",
            Expressao = "CV = σ(ISI) / μ(ISI)",
            ExprTexto = "Variabilidade inter-spike",
            Descricao = "Poisson: CV=1. Relógio: CV≈0. Burst: CV>1.",
            Criador = "Softky, Koch",
            AnoOrigin = "1993",
            ExemploPratico = "Córtex in vivo: CV≈0,8-1,5 (alta variabilidade, controverso). Clock neuronal: CV<0,3",
            Unidades = "adimensional",
            VariavelResultado = "CV",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sigma_ISI", Nome = "Desvio padrão ISI", Descricao = "σ(ISI)", Unidade = "ms", ValorPadrao = 15, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "mu_ISI", Nome = "Média ISI", Descricao = "μ(ISI)", Unidade = "ms", ValorPadrao = 20, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sigma_ISI = inputs["sigma_ISI"];
                double mu_ISI = inputs["mu_ISI"];
                return sigma_ISI / mu_ISI;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC059_CorrelacaoCruzada()
    {
        return new Formula
        {
            Id = "V8-NC059",
            CodigoCompendio = "059",
            Nome = "Correlação Cruzada (Spike Trains)",
            Categoria = "Neurociência",
            SubCategoria = "Sincronização Neural",
            Expressao = "CCG(τ) = Σ sp1(t)*sp2(t+τ) / sqrt(N1*N2)",
            ExprTexto = "Correlação com lag τ",
            Descricao = "Pico em τ=0: sincronização. τ≠0: propagação de atividade.",
            Criador = "Perkel et al.",
            AnoOrigin = "1967",
            ExemploPratico = "Oscilações gama: pico em CCG a cada 12-30ms. Detecta assemblies celulares funcionais",
            Unidades = "spikes/bin",
            VariavelResultado = "CCG",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sum_sp1_sp2", Nome = "Soma de coincidências", Descricao = "Σ sp1(t)·sp2(t+τ)", Unidade = "", ValorPadrao = 50, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "N1", Nome = "Total spikes neurônio 1", Descricao = "N1", Unidade = "", ValorPadrao = 200, ValorMin = 1, ValorMax = 100000, Obrigatoria = true },
                new() { Simbolo = "N2", Nome = "Total spikes neurônio 2", Descricao = "N2", Unidade = "", ValorPadrao = 250, ValorMin = 1, ValorMax = 100000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sum_sp1_sp2 = inputs["sum_sp1_sp2"];
                double N1 = inputs["N1"];
                double N2 = inputs["N2"];
                return sum_sp1_sp2 / Math.Sqrt(N1 * N2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC060_PhaseLockedValue()
    {
        return new Formula
        {
            Id = "V8-NC060",
            CodigoCompendio = "060",
            Nome = "Phase Locking Value (PLV)",
            Categoria = "Neurociência",
            SubCategoria = "Sincronização Neural",
            Expressao = "PLV = |1/N * Σ exp(i*Δφ(t))|",
            ExprTexto = "Índice de travamento de fase",
            Descricao = "PLV=1: fase travada. PLV=0: não-sincronizado. Usado em LFP, EEG.",
            Criador = "Lachaux et al.",
            AnoOrigin = "1999",
            ExemploPratico = "Oscilações teta-gama: PLV≈0,7 durante memória de trabalho. Análise de coerência neural",
            Unidades = "adimensional",
            VariavelResultado = "PLV",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "sum_cos_phi", Nome = "Σ cos(Δφ)", Descricao = "Soma cossenos", Unidade = "", ValorPadrao = 0.7, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "sum_sin_phi", Nome = "Σ sin(Δφ)", Descricao = "Soma senos", Unidade = "", ValorPadrao = 0, ValorMin = -1, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double sum_cos_phi = inputs["sum_cos_phi"];
                double sum_sin_phi = inputs["sum_sin_phi"];
                return Math.Sqrt(sum_cos_phi * sum_cos_phi + sum_sin_phi * sum_sin_phi);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC061_SpikeDensityFunction()
    {
        return new Formula
        {
            Id = "V8-NC061",
            CodigoCompendio = "061",
            Nome = "Spike Density Function (SDF)",
            Categoria = "Neurociência",
            SubCategoria = "Análise de Spike Trains",
            Expressao = "SDF(t) = Σ G(t - ti, σ)",
            ExprTexto = "Densidade suavizada de spikes",
            Descricao = "Convolução com kernel gaussiano G(t,σ). σ=5-15ms (típico). PSTH suavizado.",
            Criador = "Richmond, Optican",
            AnoOrigin = "1987",
            ExemploPratico = "σ=10ms → janela de suavização. Análise de respostas peri-estímulo (PSTH)",
            Unidades = "Hz",
            VariavelResultado = "SDF",
            UnidadeResultado = "Hz",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "spike_count", Nome = "Número de spikes", Descricao = "Na janela", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "sigma", Nome = "Largura kernel", Descricao = "σ gaussiano", Unidade = "ms", ValorPadrao = 10, ValorMin = 1, ValorMax = 50, Obrigatoria = true },
                new() { Simbolo = "window", Nome = "Janela temporal", Descricao = "Duração", Unidade = "ms", ValorPadrao = 100, ValorMin = 10, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double spike_count = inputs["spike_count"];
                double sigma = inputs["sigma"];
                double window = inputs["window"];
                
                // Taxa média (spikes/ms → Hz)
                return (spike_count / window) * 1000;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC062_BurstIndex()
    {
        return new Formula
        {
            Id = "V8-NC062",
            CodigoCompendio = "062",
            Nome = "Índice de Burst",
            Categoria = "Neurociência",
            SubCategoria = "Padrões de Disparo",
            Expressao = "BI = (ISI_mean - ISI_mode) / ISI_SD",
            ExprTexto = "Quantifica tendência a burst",
            Descricao = "BI>1: neurônio burst. BI<0,5: tônico. Identifica padrões de disparo.",
            Criador = "Legendy, Salcman",
            AnoOrigin = "1985",
            ExemploPratico = "Neurônio talâmico: BI≈2 (burst). Interneurônio FS: BI≈0,3 (tônico, regular)",
            Unidades = "adimensional",
            VariavelResultado = "BI",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "ISI_mean", Nome = "ISI médio", Descricao = "Média", Unidade = "ms", ValorPadrao = 50, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "ISI_mode", Nome = "ISI moda", Descricao = "Valor mais frequente", Unidade = "ms", ValorPadrao = 20, ValorMin = 1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "ISI_SD", Nome = "Desvio padrão ISI", Descricao = "σ(ISI)", Unidade = "ms", ValorPadrao = 15, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double ISI_mean = inputs["ISI_mean"];
                double ISI_mode = inputs["ISI_mode"];
                double ISI_SD = inputs["ISI_SD"];
                return (ISI_mean - ISI_mode) / ISI_SD;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_NC063_MembraneTimeConstant()
    {
        return new Formula
        {
            Id = "V8-NC063",
            CodigoCompendio = "063",
            Nome = "Constante de Tempo da Membrana",
            Categoria = "Neurociência",
            SubCategoria = "Propriedades Passivas",
            Expressao = "τm = Rm * Cm",
            ExprTexto = "Tempo de carga da membrana",
            Descricao = "τm=tempo para V(t)=0,63·Vfinal. Tipicamente 10-30ms. Determina integração temporal.",
            Criador = "Teoria RC",
            AnoOrigin = "~1900s",
            ExemploPratico = "Rm=100MΩ, Cm=100pF → τm=10ms. Rápido: τm<5ms (interneurônio). Lento: τm>30ms (piramidal)",
            Unidades = "ms",
            VariavelResultado = "τm",
            UnidadeResultado = "ms",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Rm", Nome = "Resistência membrana", Descricao = "Rm", Unidade = "MΩ", ValorPadrao = 100, ValorMin = 10, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "Cm", Nome = "Capacitância membrana", Descricao = "Cm", Unidade = "pF", ValorPadrao = 100, ValorMin = 10, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Rm = inputs["Rm"];
                double Cm = inputs["Cm"];
                return Rm * Cm / 1000; // MΩ*pF = ns → ms
            },
            Icone = "∑",
        };
    }
}
