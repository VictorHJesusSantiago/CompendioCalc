using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE IV: ROBÓTICA E MECATRÔNICA
    // Cinemática, dinâmica, controle e planejamento
    // 20 fórmulas (064-083)
    // ========================================

    public static Formula V8_ROB064_CinematicaDireta2D()
    {
        return new Formula
        {
            Id = "V8-ROB064",
            CodigoCompendio = "064",
            Nome = "Cinemática Direta 2D — Robô Planar",
            Categoria = "Robótica",
            SubCategoria = "Cinemática",
            Expressao = "x = L1*cos(θ1) + L2*cos(θ1+θ2); y = L1*sin(θ1) + L2*sin(θ1+θ2)",
            ExprTexto = "Posição do efetuador",
            Descricao = "Robô planar 2R: dois elos rotativos. θ1, θ2=ângulos das juntas.",
            Criador = "Denavit-Hartenberg",
            AnoOrigin = "1955",
            ExemploPratico = "L1=0,5m, L2=0,3m, θ1=45°, θ2=30° → x≈0,68m, y≈0,568m. Base de SCARA, manipuladores",
            Unidades = "m",
            VariavelResultado = "x",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L1", Nome = "Comprimento elo 1", Descricao = "L1", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "L2", Nome = "Comprimento elo 2", Descricao = "L2", Unidade = "m", ValorPadrao = 0.3, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "theta1", Nome = "Ângulo junta 1", Descricao = "θ1", Unidade = "graus", ValorPadrao = 45, ValorMin = -180, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "theta2", Nome = "Ângulo junta 2", Descricao = "θ2", Unidade = "graus", ValorPadrao = 30, ValorMin = -180, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L1 = inputs["L1"];
                double L2 = inputs["L2"];
                double theta1 = inputs["theta1"] * Math.PI / 180;
                double theta2 = inputs["theta2"] * Math.PI / 180;
                
                return L1 * Math.Cos(theta1) + L2 * Math.Cos(theta1 + theta2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB065_CinematicaInversa2D()
    {
        return new Formula
        {
            Id = "V8-ROB065",
            CodigoCompendio = "065",
            Nome = "Cinemática Inversa 2D — Solução Geométrica",
            Categoria = "Robótica",
            SubCategoria = "Cinemática",
            Expressao = "θ2 = ±acos((x²+y²-L1²-L2²)/(2*L1*L2))",
            ExprTexto = "Ângulo junta 2",
            Descricao = "Solução geométrica para 2R. ±: cotovelo para cima/baixo. Singularidade: braço estendido.",
            Criador = "Paul",
            AnoOrigin = "1981",
            ExemploPratico = "x=0,6m, y=0,4m → θ2=±36,9°. Duas soluções: escolhe conforme obstáculos",
            Unidades = "graus",
            VariavelResultado = "θ2",
            UnidadeResultado = "°",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Posição x desejada", Descricao = "x", Unidade = "m", ValorPadrao = 0.6, ValorMin = -5, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "y", Nome = "Posição y desejada", Descricao = "y", Unidade = "m", ValorPadrao = 0.4, ValorMin = -5, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "L1", Nome = "Comprimento elo 1", Descricao = "L1", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "L2", Nome = "Comprimento elo 2", Descricao = "L2", Unidade = "m", ValorPadrao = 0.3, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double y = inputs["y"];
                double L1 = inputs["L1"];
                double L2 = inputs["L2"];
                
                double cos_theta2 = (x * x + y * y - L1 * L1 - L2 * L2) / (2 * L1 * L2);
                cos_theta2 = Math.Max(-1, Math.Min(1, cos_theta2)); // Clamping para evitar erro em acos
                
                return Math.Acos(cos_theta2) * 180 / Math.PI;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB066_Jacobiano2D()
    {
        return new Formula
        {
            Id = "V8-ROB066",
            CodigoCompendio = "066",
            Nome = "Jacobiano 2D — Velocidade do Efetuador",
            Categoria = "Robótica",
            SubCategoria = "Cinemática Diferencial",
            Expressao = "v = J * θ̇; J11 = -L1*sin(θ1) - L2*sin(θ1+θ2)",
            ExprTexto = "Velocidade linear",
            Descricao = "J: Jacobiano 2×2. v=[vx,vy]ᵀ, θ̇=[θ̇1,θ̇2]ᵀ. Singularidade: det(J)=0.",
            Criador = "Whitney",
            AnoOrigin = "1969",
            ExemploPratico = "θ̇1=0,5rad/s → vx depende de J. Controle resolvido: θ̇=J⁻¹·v_des",
            Unidades = "m/s",
            VariavelResultado = "vx",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L1", Nome = "Comprimento elo 1", Descricao = "L1", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "L2", Nome = "Comprimento elo 2", Descricao = "L2", Unidade = "m", ValorPadrao = 0.3, ValorMin = 0.1, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "theta1", Nome = "Ângulo junta 1", Descricao = "θ1", Unidade = "graus", ValorPadrao = 45, ValorMin = -180, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "theta2", Nome = "Ângulo junta 2", Descricao = "θ2", Unidade = "graus", ValorPadrao = 30, ValorMin = -180, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "dtheta1", Nome = "Velocidade junta 1", Descricao = "θ̇1", Unidade = "rad/s", ValorPadrao = 0.5, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "dtheta2", Nome = "Velocidade junta 2", Descricao = "θ̇2", Unidade = "rad/s", ValorPadrao = 0.3, ValorMin = -10, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L1 = inputs["L1"];
                double L2 = inputs["L2"];
                double theta1 = inputs["theta1"] * Math.PI / 180;
                double theta2 = inputs["theta2"] * Math.PI / 180;
                double dtheta1 = inputs["dtheta1"];
                double dtheta2 = inputs["dtheta2"];
                
                double J11 = -L1 * Math.Sin(theta1) - L2 * Math.Sin(theta1 + theta2);
                double J12 = -L2 * Math.Sin(theta1 + theta2);
                
                return J11 * dtheta1 + J12 * dtheta2;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB067_DinRotacional()
    {
        return new Formula
        {
            Id = "V8-ROB067",
            CodigoCompendio = "067",
            Nome = "Dinâmica de Junta — Torque Requerido",
            Categoria = "Robótica",
            SubCategoria = "Dinâmica",
            Expressao = "τ = I*α + b*ω + g(θ)",
            ExprTexto = "Torque da junta",
            Descricao = "I=inércia, α=aceleração angular, b=atrito viscoso, g=compensação gravidade.",
            Criador = "Euler-Lagrange",
            AnoOrigin = "~1750",
            ExemploPratico = "I=0,1kg·m², α=2rad/s², b=0,05, ω=1rad/s → τ=0,25N·m. Controle de torque",
            Unidades = "N·m",
            VariavelResultado = "τ",
            UnidadeResultado = "N·m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "I", Nome = "Inércia junta", Descricao = "I", Unidade = "kg·m²", ValorPadrao = 0.1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "alpha", Nome = "Aceleração angular", Descricao = "α", Unidade = "rad/s²", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Coef. atrito viscoso", Descricao = "b", Unidade = "N·m·s/rad", ValorPadrao = 0.05, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "omega", Nome = "Velocidade angular", Descricao = "ω", Unidade = "rad/s", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "g_theta", Nome = "Torque gravitacional", Descricao = "g(θ)", Unidade = "N·m", ValorPadrao = 0.2, ValorMin = -50, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double I = inputs["I"];
                double alpha = inputs["alpha"];
                double b = inputs["b"];
                double omega = inputs["omega"];
                double g_theta = inputs["g_theta"];
                
                return I * alpha + b * omega + g_theta;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB068_ControladorPID()
    {
        return new Formula
        {
            Id = "V8-ROB068",
            CodigoCompendio = "068",
            Nome = "Controlador PID",
            Categoria = "Robótica",
            SubCategoria = "Controle",
            Expressao = "u(t) = Kp*e + Ki*∫e*dt + Kd*de/dt",
            ExprTexto = "Sinal de controle PID",
            Descricao = "e=erro. Kp: ganho proporcional. Ki: integral. Kd: derivativo. Ziegler-Nichols: sintonia.",
            Criador = "PID clássico",
            AnoOrigin = "~1940s",
            ExemploPratico = "Kp=10, Ki=1, Kd=0,5, e=0,1rad → u depende de ∫e e ė. Controle de posição de juntas",
            Unidades = "unidade_controle",
            VariavelResultado = "u",
            UnidadeResultado = "u",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Kp", Nome = "Ganho proporcional", Descricao = "Kp", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "e", Nome = "Erro atual", Descricao = "e(t)", Unidade = "rad", ValorPadrao = 0.1, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "Ki", Nome = "Ganho integral", Descricao = "Ki", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "integral_e", Nome = "Integral do erro", Descricao = "∫e·dt", Unidade = "rad·s", ValorPadrao = 0.05, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "Kd", Nome = "Ganho derivativo", Descricao = "Kd", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "de_dt", Nome = "Derivada do erro", Descricao = "de/dt", Unidade = "rad/s", ValorPadrao = 0.2, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Kp = inputs["Kp"];
                double e = inputs["e"];
                double Ki = inputs["Ki"];
                double integral_e = inputs["integral_e"];
                double Kd = inputs["Kd"];
                double de_dt = inputs["de_dt"];
                
                return Kp * e + Ki * integral_e + Kd * de_dt;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB069_TrajetoriaPolinomial()
    {
        return new Formula
        {
            Id = "V8-ROB069",
            CodigoCompendio = "069",
            Nome = "Trajetória Polinomial — Interpolação Cúbica",
            Categoria = "Robótica",
            SubCategoria = "Planejamento de Trajetória",
            Expressao = "θ(t) = a0 + a1*t + a2*t² + a3*t³",
            ExprTexto = "Posição interpolada",
            Descricao = "Condições: θ(0)=θ0, θ(T)=θf, θ̇(0)=0, θ̇(T)=0. Suave para robôs.",
            Criador = "Interpolação polinomial",
            AnoOrigin = "~1970s",
            ExemploPratico = "θ0=0°, θf=90°, T=2s → trajetória suave. Quintic (5° grau): adiciona condições de aceleração",
            Unidades = "rad",
            VariavelResultado = "θ",
            UnidadeResultado = "rad",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a0", Nome = "Coef. a0", Descricao = "a0", Unidade = "rad", ValorPadrao = 0, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "a1", Nome = "Coef. a1", Descricao = "a1", Unidade = "rad/s", ValorPadrao = 0, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "a2", Nome = "Coef. a2", Descricao = "a2", Unidade = "rad/s²", ValorPadrao = 1.5, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "a3", Nome = "Coef. a3", Descricao = "a3", Unidade = "rad/s³", ValorPadrao = -0.5, ValorMin = -10, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "t", Unidade = "s", ValorPadrao = 1, ValorMin = 0, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a0 = inputs["a0"];
                double a1 = inputs["a1"];
                double a2 = inputs["a2"];
                double a3 = inputs["a3"];
                double t = inputs["t"];
                
                return a0 + a1 * t + a2 * t * t + a3 * t * t * t;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB070_EspacoConfiguracoes()
    {
        return new Formula
        {
            Id = "V8-ROB070",
            CodigoCompendio = "070",
            Nome = "Distância no C-Space",
            Categoria = "Robótica",
            SubCategoria = "Planejamento de Movimento",
            Expressao = "d = sqrt(Σ(θi - θi')²)",
            ExprTexto = "Distância euclidiana no espaço de configurações",
            Descricao = "C-space: espaço de todas as configurações. Usado em RRT, PRM.",
            Criador = "Lozano-Pérez",
            AnoOrigin = "1983",
            ExemploPratico = "θ=[0,45°], θ'=[30,60°] → d≈33,5°. Planejamento livre de colisões",
            Unidades = "graus",
            VariavelResultado = "d",
            UnidadeResultado = "°",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "theta1", Nome = "Config. atual θ1", Descricao = "θ1", Unidade = "graus", ValorPadrao = 0, ValorMin = -180, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "theta2", Nome = "Config. atual θ2", Descricao = "θ2", Unidade = "graus", ValorPadrao = 45, ValorMin = -180, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "theta1_prime", Nome = "Config. alvo θ1'", Descricao = "θ1'", Unidade = "graus", ValorPadrao = 30, ValorMin = -180, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "theta2_prime", Nome = "Config. alvo θ2'", Descricao = "θ2'", Unidade = "graus", ValorPadrao = 60, ValorMin = -180, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double theta1 = inputs["theta1"];
                double theta2 = inputs["theta2"];
                double theta1_prime = inputs["theta1_prime"];
                double theta2_prime = inputs["theta2_prime"];
                
                double diff1 = theta1 - theta1_prime;
                double diff2 = theta2 - theta2_prime;
                
                return Math.Sqrt(diff1 * diff1 + diff2 * diff2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB071_ModeloAckermann()
    {
        return new Formula
        {
            Id = "V8-ROB071",
            CodigoCompendio = "071",
            Nome = "Modelo de Ackermann — Veículo com Esterçamento",
            Categoria = "Robótica",
            SubCategoria = "Robôs Móveis",
            Expressao = "R = L / tan(δ)",
            ExprTexto = "Raio de curvatura",
            Descricao = "L=distância entre eixos. δ=ângulo de esterçamento. Base de carros autônomos.",
            Criador = "Rudolph Ackermann",
            AnoOrigin = "1818",
            ExemploPratico = "L=2,5m, δ=15° → R=9,33m. Ackermann real: roda interna>externa (evita deslize)",
            Unidades = "m",
            VariavelResultado = "R",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "L", Nome = "Distância entre eixos", Descricao = "L", Unidade = "m", ValorPadrao = 2.5, ValorMin = 0.5, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "delta", Nome = "Ângulo de esterçamento", Descricao = "δ", Unidade = "graus", ValorPadrao = 15, ValorMin = -45, ValorMax = 45, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double L = inputs["L"];
                double delta = inputs["delta"] * Math.PI / 180;
                
                if (Math.Abs(delta) < 0.001) return double.PositiveInfinity; // Aproximadamente reto
                
                return L / Math.Tan(delta);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB072_ModeloDiferencial()
    {
        return new Formula
        {
            Id = "V8-ROB072",
            CodigoCompendio = "072",
            Nome = "Modelo Diferencial — Robô de Rodas",
            Categoria = "Robótica",
            SubCategoria = "Robôs Móveis",
            Expressao = "v = (vR + vL)/2; ω = (vR - vL)/b",
            ExprTexto = "Velocidade linear e angular",
            Descricao = "vR, vL=velocidades das rodas. b=distância entre rodas. Base de iRobots, TurtleBot.",
            Criador = "Modelo cinemático",
            AnoOrigin = "~1980s",
            ExemploPratico = "vR=0,2m/s, vL=0,1m/s, b=0,3m → v=0,15m/s, ω=0,33rad/s (giro à esquerda)",
            Unidades = "m/s",
            VariavelResultado = "v",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "vR", Nome = "Velocidade roda direita", Descricao = "vR", Unidade = "m/s", ValorPadrao = 0.2, ValorMin = -5, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "vL", Nome = "Velocidade roda esquerda", Descricao = "vL", Unidade = "m/s", ValorPadrao = 0.1, ValorMin = -5, ValorMax = 5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double vR = inputs["vR"];
                double vL = inputs["vL"];
                
                return (vR + vL) / 2;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB073_OdometriaPosicao()
    {
        return new Formula
        {
            Id = "V8-ROB073",
            CodigoCompendio = "073",
            Nome = "Odometria — Atualização de Posição",
            Categoria = "Robótica",
            SubCategoria = "Localização",
            Expressao = "x_new = x + Δs * cos(θ + Δθ/2)",
            ExprTexto = "Posição x atualizada",
            Descricao = "Δs=distância percorrida, Δθ=mudança de orientação. Acumula erro (drift).",
            Criador = "Integration dead reckoning",
            AnoOrigin = "~1990s",
            ExemploPratico = "Δs=1m, θ=0°, Δθ=10° → x_new=x+0,996m. Erro acumulado: +SLAM, filtro de Kalman",
            Unidades = "m",
            VariavelResultado = "x_new",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Posição x atual", Descricao = "x", Unidade = "m", ValorPadrao = 0, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "Delta_s", Nome = "Distância percorrida", Descricao = "Δs", Unidade = "m", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "theta", Nome = "Orientação atual", Descricao = "θ", Unidade = "graus", ValorPadrao = 0, ValorMin = -180, ValorMax = 180, Obrigatoria = true },
                new() { Simbolo = "Delta_theta", Nome = "Mudança de orientação", Descricao = "Δθ", Unidade = "graus", ValorPadrao = 10, ValorMin = -180, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double Delta_s = inputs["Delta_s"];
                double theta = inputs["theta"] * Math.PI / 180;
                double Delta_theta = inputs["Delta_theta"] * Math.PI / 180;
                
                return x + Delta_s * Math.Cos(theta + Delta_theta / 2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB074_PotencialAtrativo()
    {
        return new Formula
        {
            Id = "V8-ROB074",
            CodigoCompendio = "074",
            Nome = "Campo Potencial Atrativo (APF)",
            Categoria = "Robótica",
            SubCategoria = "Planejamento de Movimento",
            Expressao = "U_att = 0,5 * k_att * d²",
            ExprTexto = "Potencial atrativo",
            Descricao = "d=distância ao objetivo. k_att=ganho. APF: atração + repulsão de obstáculos.",
            Criador = "Khatib",
            AnoOrigin = "1986",
            ExemploPratico = "d=5m, k_att=1 → U_att=12,5. Força F=-∇U. Problema: mínimos locais",
            Unidades = "J",
            VariavelResultado = "U_att",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k_att", Nome = "Ganho atrativo", Descricao = "k_att", Unidade = "", ValorPadrao = 1, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Distância ao objetivo", Descricao = "d", Unidade = "m", ValorPadrao = 5, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k_att = inputs["k_att"];
                double d = inputs["d"];
                
                return 0.5 * k_att * d * d;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB075_PotencialRepulsivo()
    {
        return new Formula
        {
            Id = "V8-ROB075",
            CodigoCompendio = "075",
            Nome = "Campo Potencial Repulsivo (APF)",
            Categoria = "Robótica",
            SubCategoria = "Planejamento de Movimento",
            Expressao = "U_rep = 0,5 * k_rep * (1/d - 1/d0)² if d<d0 else 0",
            ExprTexto = "Potencial repulsivo",
            Descricao = "d=distância ao obstáculo. d0=raio de influência. Repele robô de obstáculos.",
            Criador = "Khatib",
            AnoOrigin = "1986",
            ExemploPratico = "d=0,5m, d0=1m, k_rep=10 → U_rep=5J. d>d0: sem repulsão",
            Unidades = "J",
            VariavelResultado = "U_rep",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k_rep", Nome = "Ganho repulsivo", Descricao = "k_rep", Unidade = "", ValorPadrao = 10, ValorMin = 0, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "d", Nome = "Distância ao obstáculo", Descricao = "d", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "d0", Nome = "Raio de influência", Descricao = "d0", Unidade = "m", ValorPadrao = 1, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k_rep = inputs["k_rep"];
                double d = inputs["d"];
                double d0 = inputs["d0"];
                
                if (d >= d0) return 0;
                
                double term = 1.0 / d - 1.0 / d0;
                return 0.5 * k_rep * term * term;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB076_DistanciaManhattan()
    {
        return new Formula
        {
            Id = "V8-ROB076",
            CodigoCompendio = "076",
            Nome = "Distância de Manhattan (Heurística A*)",
            Categoria = "Robótica",
            SubCategoria = "Planejamento de Caminho",
            Expressao = "h = |x1-x2| + |y1-y2|",
            ExprTexto = "Heurística Manhattan",
            Descricao = "Usado em grids 2D. A*: f=g+h. Admissível para movimento 4-conectado.",
            Criador = "Hart, Nilsson, Raphael",
            AnoOrigin = "1968",
            ExemploPratico = "(0,0)→(10,5): h=15. Euclidiana≈11,2 (subestima, mais eficiente mas não admissível 4-conn)",
            Unidades = "células",
            VariavelResultado = "h",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x1", Nome = "Coordenada x1", Descricao = "x1", Unidade = "", ValorPadrao = 0, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "y1", Nome = "Coordenada y1", Descricao = "y1", Unidade = "", ValorPadrao = 0, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "x2", Nome = "Coordenada x2", Descricao = "x2", Unidade = "", ValorPadrao = 10, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "y2", Nome = "Coordenada y2", Descricao = "y2", Unidade = "", ValorPadrao = 5, ValorMin = -1000, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x1 = inputs["x1"];
                double y1 = inputs["y1"];
                double x2 = inputs["x2"];
                double y2 = inputs["y2"];
                
                return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB077_QuaternioNormalizacao()
    {
        return new Formula
        {
            Id = "V8-ROB077",
            CodigoCompendio = "077",
            Nome = "Normalização de Quaternion",
            Categoria = "Robótica",
            SubCategoria = "Orientação 3D",
            Expressao = "q_norm = q / ||q||; ||q|| = sqrt(w²+x²+y²+z²)",
            ExprTexto = "Quaternion unitário",
            Descricao = "q=[w,x,y,z]. Evita gimbal lock. Interpolação: SLERP.",
            Criador = "Hamilton",
            AnoOrigin = "1843",
            ExemploPratico = "q=[0,7; 0,5; 0,3; 0,2] → ||q||=0,905 → q_norm=[0,773; 0,553; 0,331; 0,221]",
            Unidades = "adimensional",
            VariavelResultado = "norm",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "w", Nome = "Componente w", Descricao = "w", Unidade = "", ValorPadrao = 0.7, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "x", Nome = "Componente x", Descricao = "x", Unidade = "", ValorPadrao = 0.5, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "y", Nome = "Componente y", Descricao = "y", Unidade = "", ValorPadrao = 0.3, ValorMin = -1, ValorMax = 1, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "Componente z", Descricao = "z", Unidade = "", ValorPadrao = 0.2, ValorMin = -1, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double w = inputs["w"];
                double x = inputs["x"];
                double y = inputs["y"];
                double z = inputs["z"];
                
                return Math.Sqrt(w * w + x * x + y * y + z * z);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB078_TransformacaoHomogenea()
    {
        return new Formula
        {
            Id = "V8-ROB078",
            CodigoCompendio = "078",
            Nome = "Coordenadas Homogêneas — Translação",
            Categoria = "Robótica",
            SubCategoria = "Transformações",
            Expressao = "x' = R*x + t",
            ExprTexto = "Transformação rígida",
            Descricao = "R=matriz rotação 3×3, t=vetor translação. Matriz 4×4: [R|t; 0|1].",
            Criador = "Roberts, Denavit-Hartenberg",
            AnoOrigin = "1965",
            ExemploPratico = "x=[1,0,0], t=[2,3,0] → x'=[3,3,0]. Composição: T12·T23=T13 (cadeia cinemática)",
            Unidades = "m",
            VariavelResultado = "x_prime",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "x", Nome = "Coordenada x", Descricao = "x", Unidade = "m", ValorPadrao = 1, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "tx", Nome = "Translação x", Descricao = "tx", Unidade = "m", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double x = inputs["x"];
                double tx = inputs["tx"];
                
                // Simplificado: apenas translação (sem rotação)
                return x + tx;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB079_ManipulabilidadeYoshikawa()
    {
        return new Formula
        {
            Id = "V8-ROB079",
            CodigoCompendio = "079",
            Nome = "Índice de Manipulabilidade (Yoshikawa)",
            Categoria = "Robótica",
            SubCategoria = "Desempenho",
            Expressao = "w = sqrt(det(J*J^T))",
            ExprTexto = "Manipulabilidade",
            Descricao = "w=0: singularidade. w máximo: configuração ótima. Medida de destreza do robô.",
            Criador = "Yoshikawa",
            AnoOrigin = "1985",
            ExemploPratico = "J: 2×2 → det(JJ^T)=4 → w=2. Otimização de trajetória para manter w alto",
            Unidades = "adimensional",
            VariavelResultado = "w",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "det_JJT", Nome = "Determinante JJ^T", Descricao = "det(JJ^T)", Unidade = "", ValorPadrao = 4, ValorMin = 0, ValorMax = 1000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double det_JJT = inputs["det_JJT"];
                
                return Math.Sqrt(Math.Max(0, det_JJT));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB080_TorqueDueToGravity()
    {
        return new Formula
        {
            Id = "V8-ROB080",
            CodigoCompendio = "080",
            Nome = "Torque Gravitacional — Elo Simples",
            Categoria = "Robótica",
            SubCategoria = "Dinâmica",
            Expressao = "τ_g = m * g * r * cos(θ)",
            ExprTexto = "Torque devido à gravidade",
            Descricao = "m=massa do elo, r=distância do centro de massa à junta. Compensação de gravidade.",
            Criador = "Mecânica clássica",
            AnoOrigin = "Newton",
            ExemploPratico = "m=5kg, r=0,3m, θ=45° → τ_g=10,4N·m. θ=0°: τ_g max. θ=90°: τ_g=0",
            Unidades = "N·m",
            VariavelResultado = "τ_g",
            UnidadeResultado = "N·m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "m", Nome = "Massa do elo", Descricao = "m", Unidade = "kg", ValorPadrao = 5, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Aceleração gravitacional", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 0, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Distância CM-junta", Descricao = "r", Unidade = "m", ValorPadrao = 0.3, ValorMin = 0.01, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "theta", Nome = "Ângulo da junta", Descricao = "θ", Unidade = "graus", ValorPadrao = 45, ValorMin = -180, ValorMax = 180, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double m = inputs["m"];
                double g = inputs["g"];
                double r = inputs["r"];
                double theta = inputs["theta"] * Math.PI / 180;
                
                return m * g * r * Math.Cos(theta);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB081_EnergiaTotal()
    {
        return new Formula
        {
            Id = "V8-ROB081",
            CodigoCompendio = "081",
            Nome = "Energia Total do Robô",
            Categoria = "Robótica",
            SubCategoria = "Dinâmica",
            Expressao = "E = 0,5*I*ω² + m*g*h",
            ExprTexto = "Energia cinética + potencial",
            Descricao = "I=inércia, ω=vel. angular, h=altura. Lagrangiano: L=T-V (Euler-Lagrange).",
            Criador = "Lagrange",
            AnoOrigin = "1788",
            ExemploPratico = "I=0,1kg·m², ω=2rad/s, m=5kg, h=0,5m → E=0,2+24,5=24,7J. Conservação em movimento livre",
            Unidades = "J",
            VariavelResultado = "E",
            UnidadeResultado = "J",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "I", Nome = "Inércia", Descricao = "I", Unidade = "kg·m²", ValorPadrao = 0.1, ValorMin = 0.001, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "omega", Nome = "Velocidade angular", Descricao = "ω", Unidade = "rad/s", ValorPadrao = 2, ValorMin = 0, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "m", Nome = "Massa", Descricao = "m", Unidade = "kg", ValorPadrao = 5, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Aceleração gravitacional", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 0, ValorMax = 20, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Altura", Descricao = "h", Unidade = "m", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double I = inputs["I"];
                double omega = inputs["omega"];
                double m = inputs["m"];
                double g = inputs["g"];
                double h = inputs["h"];
                
                return 0.5 * I * omega * omega + m * g * h;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB082_ResolvedRateControl()
    {
        return new Formula
        {
            Id = "V8-ROB082",
            CodigoCompendio = "082",
            Nome = "Controle Resolvido em Taxa",
            Categoria = "Robótica",
            SubCategoria = "Controle",
            Expressao = "θ̇ = J^(-1) * v_des",
            ExprTexto = "Velocidades de junta desejadas",
            Descricao = "v_des=velocidade desejada do efetuador. Singularidade: usar pseudo-inversa J†.",
            Criador = "Whitney",
            AnoOrigin = "1969",
            ExemploPratico = "v_des=[0,1; 0]m/s → calcula θ̇ via J⁻¹. Damped least squares: (J^T·J + λI)⁻¹·J^T",
            Unidades = "rad/s",
            VariavelResultado = "theta_dot_estimated",
            UnidadeResultado = "rad/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v_des_x", Nome = "Velocidade desejada x", Descricao = "vx", Unidade = "m/s", ValorPadrao = 0.1, ValorMin = -5, ValorMax = 5, Obrigatoria = true },
                new() { Simbolo = "J_inv", Nome = "Inversa do Jacobiano (aprox)", Descricao = "Elemento J⁻¹", Unidade = "", ValorPadrao = 2, ValorMin = -100, ValorMax = 100, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v_des_x = inputs["v_des_x"];
                double J_inv = inputs["J_inv"];
                
                // Simplificado: escalar (na prática é produto matricial)
                return J_inv * v_des_x;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_ROB083_ForcaContato()
    {
        return new Formula
        {
            Id = "V8-ROB083",
            CodigoCompendio = "083",
            Nome = "Força de Contato — Interação",
            Categoria = "Robótica",
            SubCategoria = "Controle de Força",
            Expressao = "F = J^T * τ",
            ExprTexto = "Força no efetuador",
            Descricao = "τ=torques nas juntas. J^T: mapeia torques→força. Controle híbrido: posição+força.",
            Criador = "Mason",
            AnoOrigin = "1981",
            ExemploPratico = "τ=[5; 3]N·m → F depende de J^T. Polimento, montagem: controle de força adaptativa",
            Unidades = "N",
            VariavelResultado = "F",
            UnidadeResultado = "N",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "tau1", Nome = "Torque junta 1", Descricao = "τ1", Unidade = "N·m", ValorPadrao = 5, ValorMin = -100, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "JT_element", Nome = "Elemento J^T (aprox)", Descricao = "J^T elemento", Unidade = "", ValorPadrao = 0.5, ValorMin = -10, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double tau1 = inputs["tau1"];
                double JT_element = inputs["JT_element"];
                
                // Simplificado: escalar
                return JT_element * tau1;
            },
            Icone = "∑",
        };
    }
}
