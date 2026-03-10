using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ========================================
    // VOLUME VIII - PARTE VIII: METEOROLOGIA E CIÊNCIAS ATMOSFÉRICAS
    // Atmosfera, pressão, umidade, ventos, termodinâmica atmosférica
    // 20 fórmulas (145-164)
    // ========================================

    public static Formula V8_MET145_PressaoBarometrica()
    {
        return new Formula
        {
            Id = "V8-MET145",
            CodigoCompendio = "145",
            Nome = "Fórmula Barométrica — Pressão com Altitude",
            Categoria = "Meteorologia",
            SubCategoria = "Atmosfera",
            Expressao = "P = P0 * exp(-M*g*h / (R*T))",
            ExprTexto = "Pressão atmosférica",
            Descricao = "P0=pressão nível mar (Pa), M=massa molar ar (0,029kg/mol), g=9,81m/s², h=altitude (m), R=8,314J/mol/K, T=temp (K).",
            Criador = "Equação barométrica",
            AnoOrigin = "~1700s",
            ExemploPratico = "h=1000m, T=288K → P≈89,9kPa (vs 101,3kPa nível mar). Everest: ~33kPa",
            Unidades = "Pa",
            VariavelResultado = "P",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "P0", Nome = "Pressão nível mar", Descricao = "P0", Unidade = "Pa", ValorPadrao = 101325, ValorMin = 80000, ValorMax = 110000, Obrigatoria = true },
                new() { Simbolo = "M", Nome = "Massa molar ar", Descricao = "M", Unidade = "kg/mol", ValorPadrao = 0.029, ValorMin = 0.029, ValorMax = 0.029, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "h", Nome = "Altitude", Descricao = "h", Unidade = "m", ValorPadrao = 1000, ValorMin = 0, ValorMax = 20000, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Const. gases", Descricao = "R", Unidade = "J/mol/K", ValorPadrao = 8.314, ValorMin = 8.314, ValorMax = 8.314, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "K", ValorPadrao = 288, ValorMin = 200, ValorMax = 320, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double P0 = inputs["P0"];
                double M = inputs["M"];
                double g = inputs["g"];
                double h = inputs["h"];
                double R = inputs["R"];
                double T = inputs["T"];
                
                return P0 * Math.Exp(-M * g * h / (R * T));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET146_PressaoVaporAgua()
    {
        return new Formula
        {
            Id = "V8-MET146",
            CodigoCompendio = "146",
            Nome = "Pressão de Vapor Saturado — Clausius-Clapeyron (empírica)",
            Categoria = "Meteorologia",
            SubCategoria = "Umidade",
            Expressao = "es = 611 * exp((17,27 * T) / (T + 237,3))",
            ExprTexto = "Pressão vapor saturado",
            Descricao = "es=pressão vapor saturado (Pa), T=temp (°C). Equação de Tetens (aproximação).",
            Criador = "Tetens",
            AnoOrigin = "1930",
            ExemploPratico = "T=20°C → es≈2338Pa. T=0°C → es≈611Pa. Umidade relativa: RH=e/es",
            Unidades = "Pa",
            VariavelResultado = "es",
            UnidadeResultado = "Pa",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "°C", ValorPadrao = 20, ValorMin = -40, ValorMax = 50, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T = inputs["T"];
                
                return 611 * Math.Exp((17.27 * T) / (T + 237.3));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET147_UmidadeRelativa()
    {
        return new Formula
        {
            Id = "V8-MET147",
            CodigoCompendio = "147",
            Nome = "Umidade Relativa",
            Categoria = "Meteorologia",
            SubCategoria = "Umidade",
            Expressao = "RH = (e / es) * 100%",
            ExprTexto = "Umidade relativa",
            Descricao = "e=pressão vapor real (Pa), es=pressão vapor saturado (Pa). RH=100%: saturado.",
            Criador = "Meteorologia clássica",
            AnoOrigin = "~1800s",
            ExemploPratico = "e=1500Pa, es=2338Pa (20°C) → RH≈64%. Comfort zone: 40-60%",
            Unidades = "%",
            VariavelResultado = "RH",
            UnidadeResultado = "%",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "e", Nome = "Pressão vapor real", Descricao = "e", Unidade = "Pa", ValorPadrao = 1500, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "es", Nome = "Pressão vapor saturado", Descricao = "es", Unidade = "Pa", ValorPadrao = 2338, ValorMin = 100, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double e = inputs["e"];
                double es = inputs["es"];
                
                return (e / es) * 100;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET148_PontoOrvalho()
    {
        return new Formula
        {
            Id = "V8-MET148",
            CodigoCompendio = "148",
            Nome = "Temperatura do Ponto de Orvalho",
            Categoria = "Meteorologia",
            SubCategoria = "Umidade",
            Expressao = "Td = (237,3 * ln(e/611)) / (17,27 - ln(e/611))",
            ExprTexto = "Ponto de orvalho",
            Descricao = "Td=temp. orvalho (°C), e=pressão vapor real (Pa). Inversa de Tetens.",
            Criador = "Tetens (inversa)",
            AnoOrigin = "~1930",
            ExemploPratico = "e=1500Pa → Td≈13,9°C. Condensação ocorre se T cair para Td",
            Unidades = "°C",
            VariavelResultado = "Td",
            UnidadeResultado = "°C",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "e", Nome = "Pressão vapor real", Descricao = "e", Unidade = "Pa", ValorPadrao = 1500, ValorMin = 100, ValorMax = 10000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double e = inputs["e"];
                
                double ln_e_611 = Math.Log(e / 611);
                
                return (237.3 * ln_e_611) / (17.27 - ln_e_611);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET149_RazaoMistura()
    {
        return new Formula
        {
            Id = "V8-MET149",
            CodigoCompendio = "149",
            Nome = "Razão de Mistura de Vapor d'Água",
            Categoria = "Meteorologia",
            SubCategoria = "Umidade",
            Expressao = "w = 0,622 * (e / (P - e))",
            ExprTexto = "Razão de mistura",
            Descricao = "w=razão mistura (kg/kg), e=pressão vapor (Pa), P=pressão total (Pa). 0,622=Mw/Md.",
            Criador = "Termodinâmica atmosférica",
            AnoOrigin = "~1900s",
            ExemploPratico = "e=1500Pa, P=101325Pa → w≈0,00931 kg/kg (9,31g/kg ar seco)",
            Unidades = "kg/kg",
            VariavelResultado = "w",
            UnidadeResultado = "kg/kg",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "e", Nome = "Pressão vapor", Descricao = "e", Unidade = "Pa", ValorPadrao = 1500, ValorMin = 0, ValorMax = 10000, Obrigatoria = true },
                new() { Simbolo = "P", Nome = "Pressão total", Descricao = "P", Unidade = "Pa", ValorPadrao = 101325, ValorMin = 50000, ValorMax = 110000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double e = inputs["e"];
                double P = inputs["P"];
                
                return 0.622 * (e / (P - e));
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET150_TemperaturaPotencial()
    {
        return new Formula
        {
            Id = "V8-MET150",
            CodigoCompendio = "150",
            Nome = "Temperatura Potencial — θ",
            Categoria = "Meteorologia",
            SubCategoria = "Termodinâmica Atmosférica",
            Expressao = "θ = T * (P0 / P)^(R/cp)",
            ExprTexto = "Temperatura potencial",
            Descricao = "θ=temp. potencial (K), T=temp (K), P0=1000hPa, P=pressão (hPa). R/cp≈0,286 (ar seco).",
            Criador = "Termodinâmica atmosférica",
            AnoOrigin = "~1900s",
            ExemploPratico = "T=280K, P=850hPa → θ≈295K. Conservada em processo adiabático seco",
            Unidades = "K",
            VariavelResultado = "theta",
            UnidadeResultado = "K",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "K", ValorPadrao = 280, ValorMin = 200, ValorMax = 320, Obrigatoria = true },
                new() { Simbolo = "P0", Nome = "Pressão referência", Descricao = "P0", Unidade = "hPa", ValorPadrao = 1000, ValorMin = 1000, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "P", Nome = "Pressão", Descricao = "P", Unidade = "hPa", ValorPadrao = 850, ValorMin = 100, ValorMax = 1100, Obrigatoria = true },
                new() { Simbolo = "kappa", Nome = "R/cp", Descricao = "κ", Unidade = "", ValorPadrao = 0.286, ValorMin = 0.286, ValorMax = 0.286, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double T = inputs["T"];
                double P0 = inputs["P0"];
                double P = inputs["P"];
                double kappa = inputs["kappa"];
                
                return T * Math.Pow(P0 / P, kappa);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET151_GradienteAdiabaticoSeco()
    {
        return new Formula
        {
            Id = "V8-MET151",
            CodigoCompendio = "151",
            Nome = "Gradiente Adiabático Seco — Γd",
            Categoria = "Meteorologia",
            SubCategoria = "Termodinâmica Atmosférica",
            Expressao = "Γd = g / cp",
            ExprTexto = "Gradiente adiabático seco",
            Descricao = "Γd=gradiente (K/m), g=9,81m/s², cp=1005J/kg/K (ar seco). Γd≈9,8K/km.",
            Criador = "Termodinâmica",
            AnoOrigin = "~1800s",
            ExemploPratico = "Γd≈9,8°C/km. Parcela ar seco subindo: esfria 9,8°C a cada km. Saturado: Γs≈6°C/km",
            Unidades = "K/m",
            VariavelResultado = "Gamma_d",
            UnidadeResultado = "K/m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "cp", Nome = "Calor específico ar", Descricao = "cp", Unidade = "J/kg/K", ValorPadrao = 1005, ValorMin = 1005, ValorMax = 1005, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double g = inputs["g"];
                double cp = inputs["cp"];
                
                return g / cp;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET152_VelocidadeVentoGeostrofico()
    {
        return new Formula
        {
            Id = "V8-MET152",
            CodigoCompendio = "152",
            Nome = "Vento Geostrófico",
            Categoria = "Meteorologia",
            SubCategoria = "Dinâmica Atmosférica",
            Expressao = "Vg = (1 / (f * ρ)) * (dP/dn)",
            ExprTexto = "Velocidade geostrófica",
            Descricao = "f=Coriolis (2Ωsinφ), ρ=densidade ar (kg/m³), dP/dn=gradiente pressão normal (Pa/m). Equilíbrio Coriolis-gradiente.",
            Criador = "Dinâmica atmosférica",
            AnoOrigin = "~1900s",
            ExemploPratico = "dP/dn=1Pa/km, f=1e-4s⁻¹, ρ=1,2kg/m³ → Vg≈8,3m/s. Alto: paralelo a isobars",
            Unidades = "m/s",
            VariavelResultado = "Vg",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "f", Nome = "Parâmetro Coriolis", Descricao = "f", Unidade = "s⁻¹", ValorPadrao = 1e-4, ValorMin = -2e-4, ValorMax = 2e-4, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade ar", Descricao = "ρ", Unidade = "kg/m³", ValorPadrao = 1.2, ValorMin = 0.5, ValorMax = 1.5, Obrigatoria = true },
                new() { Simbolo = "dP_dn", Nome = "Gradiente pressão", Descricao = "dP/dn", Unidade = "Pa/m", ValorPadrao = 0.001, ValorMin = -0.1, ValorMax = 0.1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double f = inputs["f"];
                double rho = inputs["rho"];
                double dP_dn = inputs["dP_dn"];
                
                if (Math.Abs(f * rho) < 1e-10) return 0;
                
                return (1 / (f * rho)) * dP_dn;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET153_ParametroCoriolis()
    {
        return new Formula
        {
            Id = "V8-MET153",
            CodigoCompendio = "153",
            Nome = "Parâmetro de Coriolis — f",
            Categoria = "Meteorologia",
            SubCategoria = "Dinâmica Atmosférica",
            Expressao = "f = 2 * Ω * sin(φ)",
            ExprTexto = "Coriolis",
            Descricao = "Ω=7,292e-5rad/s (rotação Terra), φ=latitude (rad). f>0: hemisfério norte. f<0: sul.",
            Criador = "Gaspard-Gustave de Coriolis",
            AnoOrigin = "1835",
            ExemploPratico = "φ=45° → f≈1,03e-4s⁻¹. Equador: f=0. Pólos: f=±1,46e-4s⁻¹",
            Unidades = "s⁻¹",
            VariavelResultado = "f",
            UnidadeResultado = "s⁻¹",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "Omega", Nome = "Ω Terra", Descricao = "Ω", Unidade = "rad/s", ValorPadrao = 7.292e-5, ValorMin = 7.292e-5, ValorMax = 7.292e-5, Obrigatoria = true },
                new() { Simbolo = "phi", Nome = "Latitude", Descricao = "φ", Unidade = "rad", ValorPadrao = 0.785, ValorMin = -1.571, ValorMax = 1.571, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double Omega = inputs["Omega"];
                double phi = inputs["phi"];
                
                return 2 * Omega * Math.Sin(phi);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET154_NumeroRossby()
    {
        return new Formula
        {
            Id = "V8-MET154",
            CodigoCompendio = "154",
            Nome = "Número de Rossby — Ro",
            Categoria = "Meteorologia",
            SubCategoria = "Dinâmica Atmosférica",
            Expressao = "Ro = U / (f * L)",
            ExprTexto = "Rossby",
            Descricao = "U=velocidade característica (m/s), f=Coriolis (s⁻¹), L=escala espacial (m). Ro<<1: geostrófico.",
            Criador = "Carl-Gustaf Rossby",
            AnoOrigin = "~1940",
            ExemploPratico = "U=10m/s, f=1e-4s⁻¹, L=1000km → Ro=0,1 (quasi-geostrófico). Tornado: Ro~1",
            Unidades = "adimensional",
            VariavelResultado = "Ro",
            UnidadeResultado = "",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "U", Nome = "Velocidade", Descricao = "U", Unidade = "m/s", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 100, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "Coriolis", Descricao = "f", Unidade = "s⁻¹", ValorPadrao = 1e-4, ValorMin = 1e-10, ValorMax = 2e-4, Obrigatoria = true },
                new() { Simbolo = "L", Nome = "Escala espacial", Descricao = "L", Unidade = "m", ValorPadrao = 1000000, ValorMin = 1000, ValorMax = 1e7, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double U = inputs["U"];
                double f = inputs["f"];
                double L = inputs["L"];
                
                return U / (f * L);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET155_VelocidadeRaioTrovao()
    {
        return new Formula
        {
            Id = "V8-MET155",
            CodigoCompendio = "155",
            Nome = "Distância de Trovoada — Luz-Som",
            Categoria = "Meteorologia",
            SubCategoria = "Fenômenos",
            Expressao = "d = v_som * Δt",
            ExprTexto = "Distância tempestade",
            Descricao = "d=distância (m), v_som≈343m/s (20°C), Δt=atraso som após relâmpago (s). Luz: instantâneo.",
            Criador = "Física básica",
            AnoOrigin = "~1600s",
            ExemploPratico = "Δt=5s → d≈1,7km. Regra prática: 3s≈1km. Trovão >30s: tempestade longe",
            Unidades = "m",
            VariavelResultado = "d",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "v_som", Nome = "Velocidade som", Descricao = "v_som", Unidade = "m/s", ValorPadrao = 343, ValorMin = 300, ValorMax = 350, Obrigatoria = true },
                new() { Simbolo = "delta_t", Nome = "Atraso tempo", Descricao = "Δt", Unidade = "s", ValorPadrao = 5, ValorMin = 0, ValorMax = 60, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double v_som = inputs["v_som"];
                double delta_t = inputs["delta_t"];
                
                return v_som * delta_t;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET156_EstabilidadeAtmosferica()
    {
        return new Formula
        {
            Id = "V8-MET156",
            CodigoCompendio = "156",
            Nome = "Estabilidade Atmosférica — dθ/dz",
            Categoria = "Meteorologia",
            SubCategoria = "Termodinâmica Atmosférica",
            Expressao = "S = dθ/dz",
            ExprTexto = "Estabilidade",
            Descricao = "S>0: estável (inversão). S=0: neutro. S<0: instável. θ=temp. potencial.",
            Criador = "Termodinâmica atmosférica",
            AnoOrigin = "~1900s",
            ExemploPratico = "dθ/dz=+0,005K/m: estável (suprime convecção). dθ/dz=-0,001K/m: instável (tempestades)",
            Unidades = "K/m",
            VariavelResultado = "S",
            UnidadeResultado = "K/m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "dtheta_dz", Nome = "dθ/dz", Descricao = "Gradiente θ", Unidade = "K/m", ValorPadrao = 0.005, ValorMin = -0.02, ValorMax = 0.02, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                return inputs["dtheta_dz"];
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET157_CAPE()
    {
        return new Formula
        {
            Id = "V8-MET157",
            CodigoCompendio = "157",
            Nome = "CAPE — Energia Potencial Convectiva Disponível",
            Categoria = "Meteorologia",
            SubCategoria = "Convecção",
            Expressao = "CAPE = g * ∫(Tparcel - Tenv) / Tenv * dz",
            ExprTexto = "Energia convectiva (simplificado)",
            Descricao = "CAPE=integral empuxo positivo (J/kg). Alto CAPE: tempestades severas. >2000J/kg: severo.",
            Criador = "Meteorologia de tempestades",
            AnoOrigin = "~1960s",
            ExemploPratico = "CAPE=3000J/kg: severo. Updraft max: w≈√(2·CAPE)≈77m/s. Supercélulas, tornados",
            Unidades = "J/kg",
            VariavelResultado = "CAPE_approx",
            UnidadeResultado = "J/kg",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "delta_T_avg", Nome = "ΔT médio", Descricao = "(Tparcel-Tenv)/Tenv", Unidade = "", ValorPadrao = 0.03, ValorMin = 0, ValorMax = 0.1, Obrigatoria = true },
                new() { Simbolo = "delta_z", Nome = "Δz convect", Descricao = "Altura convecção", Unidade = "m", ValorPadrao = 10000, ValorMin = 1000, ValorMax = 20000, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double g = inputs["g"];
                double delta_T_avg = inputs["delta_T_avg"];
                double delta_z = inputs["delta_z"];
                
                return g * delta_T_avg * delta_z;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET158_IntensidadePrecipitacao()
    {
        return new Formula
        {
            Id = "V8-MET158",
            CodigoCompendio = "158",
            Nome = "Taxa de Precipitação — mm/h",
            Categoria = "Meteorologia",
            SubCategoria = "Precipitação",
            Expressao = "R = h / t",
            ExprTexto = "Intensidade chuva",
            Descricao = "R=taxa (mm/h), h=altura acumulada (mm), t=tempo (h). >50mm/h: forte. >100mm/h: extrema.",
            Criador = "Meteorologia observacional",
            AnoOrigin = "~1800s",
            ExemploPratico = "20mm em 30min → R=40mm/h (chuva forte). <2,5mm/h: leve. 10-50mm/h: moderada-forte",
            Unidades = "mm/h",
            VariavelResultado = "R",
            UnidadeResultado = "mm/h",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "h", Nome = "Altura chuva", Descricao = "h", Unidade = "mm", ValorPadrao = 20, ValorMin = 0, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "t", Nome = "Tempo", Descricao = "t", Unidade = "h", ValorPadrao = 0.5, ValorMin = 0.01, ValorMax = 24, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double h = inputs["h"];
                double t = inputs["t"];
                
                return h / t;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET159_RefletividadeRadar()
    {
        return new Formula
        {
            Id = "V8-MET159",
            CodigoCompendio = "159",
            Nome = "Refletividade de Radar — Z-R Relation",
            Categoria = "Meteorologia",
            SubCategoria = "Radar Meteorológico",
            Expressao = "Z = a * R^b",
            ExprTexto = "Refletividade",
            Descricao = "Z=reflectivity (mm⁶/m³), R=rain rate (mm/h). Marshall-Palmer: a=200, b=1,6.",
            Criador = "Marshall e Palmer",
            AnoOrigin = "1948",
            ExemploPratico = "R=10mm/h → Z≈398mm⁶/m³. dBZ=10log₁₀(Z). Z=400 → 26dBZ. Convectivo: a=300, b=1,4",
            Unidades = "mm⁶/m³",
            VariavelResultado = "Z",
            UnidadeResultado = "mm⁶/m³",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "a", Nome = "Coef. a", Descricao = "a", Unidade = "", ValorPadrao = 200, ValorMin = 100, ValorMax = 500, Obrigatoria = true },
                new() { Simbolo = "R", Nome = "Taxa chuva", Descricao = "R", Unidade = "mm/h", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 200, Obrigatoria = true },
                new() { Simbolo = "b", Nome = "Expoente b", Descricao = "b", Unidade = "", ValorPadrao = 1.6, ValorMin = 1, ValorMax = 2, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double a = inputs["a"];
                double R = inputs["R"];
                double b = inputs["b"];
                
                return a * Math.Pow(R, b);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET160_AlturaCamadaLimite()
    {
        return new Formula
        {
            Id = "V8-MET160",
            CodigoCompendio = "160",
            Nome = "Altura da Camada Limite Atmosférica — zi",
            Categoria = "Meteorologia",
            SubCategoria = "Camada Limite",
            Expressao = "zi = k * u_star / f",
            ExprTexto = "Altura CLA",
            Descricao = "k~0,3-0,4, u*=velocidade fricção (m/s), f=Coriolis (s⁻¹). Convectiva: zi~1-2km. Noturna: ~100m.",
            Criador = "Teoria camada limite",
            AnoOrigin = "~1960s",
            ExemploPratico = "u*=0,3m/s, f=1e-4s⁻¹, k=0,35 → zi≈1050m. Dia: convecção aumenta zi",
            Unidades = "m",
            VariavelResultado = "zi",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "k", Nome = "Constante k", Descricao = "k", Unidade = "", ValorPadrao = 0.35, ValorMin = 0.2, ValorMax = 0.5, Obrigatoria = true },
                new() { Simbolo = "u_star", Nome = "Velocidade fricção", Descricao = "u*", Unidade = "m/s", ValorPadrao = 0.3, ValorMin = 0.01, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "f", Nome = "Coriolis", Descricao = "f", Unidade = "s⁻¹", ValorPadrao = 1e-4, ValorMin = 1e-6, ValorMax = 2e-4, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double k = inputs["k"];
                double u_star = inputs["u_star"];
                double f = inputs["f"];
                
                return k * u_star / f;
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET161_ComprimentoMoninObukhov()
    {
        return new Formula
        {
            Id = "V8-MET161",
            CodigoCompendio = "161",
            Nome = "Comprimento de Monin-Obukhov — L",
            Categoria = "Meteorologia",
            SubCategoria = "Camada Limite",
            Expressao = "L = -(u_star³ * T) / (k * g * H0)",
            ExprTexto = "Escala estabilidade",
            Descricao = "u*=fricção (m/s), T=temp (K), k=0,4 (von Kármán), g=9,81m/s², H0=flux calor sensível (K·m/s).",
            Criador = "Monin e Obukhov",
            AnoOrigin = "1954",
            ExemploPratico = "H0>0 (dia): L<0 (instável). H0<0 (noite): L>0 (estável). |L|→∞: neutro",
            Unidades = "m",
            VariavelResultado = "L",
            UnidadeResultado = "m",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "u_star", Nome = "u*", Descricao = "u*", Unidade = "m/s", ValorPadrao = 0.3, ValorMin = 0.01, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "T", Nome = "Temperatura", Descricao = "T", Unidade = "K", ValorPadrao = 288, ValorMin = 250, ValorMax = 320, Obrigatoria = true },
                new() { Simbolo = "k_vonKarman", Nome = "k von Kármán", Descricao = "k", Unidade = "", ValorPadrao = 0.4, ValorMin = 0.4, ValorMax = 0.4, Obrigatoria = true },
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "H0", Nome = "Flux calor sensível", Descricao = "H0", Unidade = "K·m/s", ValorPadrao = 0.1, ValorMin = -1, ValorMax = 1, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double u_star = inputs["u_star"];
                double T = inputs["T"];
                double k_vonKarman = inputs["k_vonKarman"];
                double g = inputs["g"];
                double H0 = inputs["H0"];
                
                if (Math.Abs(H0) < 1e-10) return double.PositiveInfinity; // Neutro
                
                return -(u_star * u_star * u_star * T) / (k_vonKarman * g * H0);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET162_VelocidadeFriccao()
    {
        return new Formula
        {
            Id = "V8-MET162",
            CodigoCompendio = "162",
            Nome = "Velocidade de Fricção — u*",
            Categoria = "Meteorologia",
            SubCategoria = "Camada Limite",
            Expressao = "u_star = sqrt(τ0 / ρ)",
            ExprTexto = "u*",
            Descricao = "τ0=tensão cisalhamento superfície (Pa), ρ=densidade ar (kg/m³). Caracteriza turbulência.",
            Criador = "Camada limite turbulenta",
            AnoOrigin = "~1930s",
            ExemploPratico = "τ0=0,1Pa, ρ=1,2kg/m³ → u*≈0,29m/s. Perfil vento: u(z)=(u*/k)·ln(z/z0)",
            Unidades = "m/s",
            VariavelResultado = "u_star",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "tau_0", Nome = "Tensão superficial", Descricao = "τ0", Unidade = "Pa", ValorPadrao = 0.1, ValorMin = 0.001, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "rho", Nome = "Densidade ar", Descricao = "ρ", Unidade = "kg/m³", ValorPadrao = 1.2, ValorMin = 0.5, ValorMax = 1.5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double tau_0 = inputs["tau_0"];
                double rho = inputs["rho"];
                
                return Math.Sqrt(tau_0 / rho);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET163_PerfilVentoLogaritmico()
    {
        return new Formula
        {
            Id = "V8-MET163",
            CodigoCompendio = "163",
            Nome = "Perfil de Vento Logarítmico",
            Categoria = "Meteorologia",
            SubCategoria = "Camada Limite",
            Expressao = "u(z) = (u_star / k) * ln(z / z0)",
            ExprTexto = "Velocidade em z",
            Descricao = "u*=fricção (m/s), k=0,4, z=altura (m), z0=rugosidade (m). Neutro, ln válido para z>z0.",
            Criador = "Prandtl",
            AnoOrigin = "~1930",
            ExemploPratico = "u*=0,3m/s, k=0,4, z=10m, z0=0,1m (grama) → u≈3,5m/s. Cidade: z0~1m. Mar: z 0~0,001m",
            Unidades = "m/s",
            VariavelResultado = "u",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "u_star", Nome = "u*", Descricao = "u*", Unidade = "m/s", ValorPadrao = 0.3, ValorMin = 0.01, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "k", Nome = "k von Kármán", Descricao = "k", Unidade = "", ValorPadrao = 0.4, ValorMin = 0.4, ValorMax = 0.4, Obrigatoria = true },
                new() { Simbolo = "z", Nome = "Altura", Descricao = "z", Unidade = "m", ValorPadrao = 10, ValorMin = 0.1, ValorMax = 1000, Obrigatoria = true },
                new() { Simbolo = "z0", Nome = "Rugosidade", Descricao = "z0", Unidade = "m", ValorPadrao = 0.1, ValorMin = 0.0001, ValorMax = 10, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double u_star = inputs["u_star"];
                double k = inputs["k"];
                double z = inputs["z"];
                double z0 = inputs["z0"];
                
                if (z <= z0) return 0;
                
                return (u_star / k) * Math.Log(z / z0);
            },
            Icone = "∑",
        };
    }

    public static Formula V8_MET164_VelocidadeTerminalGota()
    {
        return new Formula
        {
            Id = "V8-MET164",
            CodigoCompendio = "164",
            Nome = "Velocidade Terminal de Gota de Chuva",
            Categoria = "Meteorologia",
            SubCategoria = "Microfísica de Nuvens",
            Expressao = "Vt = sqrt((4 * g * r * Δρ) / (3 * Cd * ρ_air))",
            ExprTexto = "Velocidade queda (simplificado)",
            Descricao = "g=9,81m/s², r=raio (m), Δρ=ρ_water-ρ_air (kg/m³), Cd=coef. arrasto (~0,5-1), ρ_air=1,2kg/m³.",
            Criador = "Mecânica dos fluidos",
            AnoOrigin = "~1900s",
            ExemploPratico = "r=1mm, Δρ≈1000kg/m³, Cd=0,6 → Vt≈6,5m/s. Gotas pequenas: Stokes. Grandes: fragmentam",
            Unidades = "m/s",
            VariavelResultado = "Vt",
            UnidadeResultado = "m/s",
            Variaveis = new List<Variavel>
            {
                new() { Simbolo = "g", Nome = "Gravidade", Descricao = "g", Unidade = "m/s²", ValorPadrao = 9.81, ValorMin = 9.7, ValorMax = 10, Obrigatoria = true },
                new() { Simbolo = "r", Nome = "Raio gota", Descricao = "r", Unidade = "m", ValorPadrao = 0.001, ValorMin = 1e-6, ValorMax = 0.005, Obrigatoria = true },
                new() { Simbolo = "delta_rho", Nome = "Δρ", Descricao = "ρ_water-ρ_air", Unidade = "kg/m³", ValorPadrao = 1000, ValorMin = 500, ValorMax = 1500, Obrigatoria = true },
                new() { Simbolo = "Cd", Nome = "Coef. arrasto", Descricao = "Cd", Unidade = "", ValorPadrao = 0.6, ValorMin = 0.1, ValorMax = 2, Obrigatoria = true },
                new() { Simbolo = "rho_air", Nome = "Densidade ar", Descricao = "ρ_air", Unidade = "kg/m³", ValorPadrao = 1.2, ValorMin = 0.5, ValorMax = 1.5, Obrigatoria = true }
            },
            Calcular = inputs =>
            {
                double g = inputs["g"];
                double r = inputs["r"];
                double delta_rho = inputs["delta_rho"];
                double Cd = inputs["Cd"];
                double rho_air = inputs["rho_air"];
                
                return Math.Sqrt((4 * g * r * delta_rho) / (3 * Cd * rho_air));
            },
            Icone = "∑",
        };
    }
}
