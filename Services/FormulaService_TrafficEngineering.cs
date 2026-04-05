using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XIX
    /// ENGENHARIA DE TRÁFEGO E SISTEMAS DE TRANSPORTE
    /// Fórmulas V10-358 a V10-376 (19 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_TrafficEngineering()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3946",
                    CodigoCompendio = "V10-358",
                    Nome = "Equação Fundamental do Tráfego",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Fluxo de Tráfego",
                    Expressao = @"q = k·v",
                    Descricao = "Relação entre fluxo (q, veíc/h), densidade (k, veíc/km) e velocidade média (v, km/h). Fluxo máximo: regime crítico entre livre e congestionado.",
                    ExemploPratico = "Fluxo livre: k=20 veíc/km, v=100 km/h → q=2000 veíc/h. Congestionado: k=100, v=20 → q=2000. Capacidade típica via: 2000-2500 veíc/h/faixa.",
                    Criador = "Greenshields (1935, pioneiro em modelos de tráfego)",
                    AnoOrigin = "1935",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Densidade k (veíc/km)", Simbolo = "k", Unidade = "veíc/km", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Velocidade v (km/h)", Simbolo = "v", Unidade = "km/h", ValorPadrao = 60, Descricao = "Parâmetro de entrada." }
                    },
                    VariavelResultado = "q",
                    UnidadeResultado = "veíc/h",
                    Calcular = inputs =>
                    {
                        double k = inputs["Densidade k (veíc/km)"];
                        double v = inputs["Velocidade v (km/h)"];
                        
                        double q = k * v;
                        return q;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-359: Modelo de Greenshields
                new Formula
                {
                    Id = "3947",
                    CodigoCompendio = "V10-359",
                    Nome = "Modelo de Greenshields",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Modelos Fundamentais",
                    Expressao = @"v = v_f·(1 − k/k_j)",
                    Descricao = "Relação linear velocidade-densidade. Base para diagrama fundamental parabólico de fluxo.",
                    ExemploPratico = "v_f=100 km/h, k_j=150 veíc/km, k=60 → v=60 km/h.",
                    Criador = "Greenshields",
                    AnoOrigin = "1935",
                    VariavelResultado = "v",
                    UnidadeResultado = "km/h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v_f livre (km/h)", Simbolo = "vf", Unidade = "km/h", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k densidade (veíc/km)", Simbolo = "k", Unidade = "veíc/km", ValorPadrao = 60, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k_j jam (veíc/km)", Simbolo = "kj", Unidade = "veíc/km", ValorPadrao = 150, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double vf = inputs["v_f livre (km/h)"];
                        double k = inputs["k densidade (veíc/km)"];
                        double kj = inputs["k_j jam (veíc/km)"];
                        if (kj <= 0) return 0;
                        return vf * (1 - k / kj);
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-360: Fluxo máximo Greenshields
                new Formula
                {
                    Id = "3948",
                    CodigoCompendio = "V10-360",
                    Nome = "Capacidade Máxima (Greenshields)",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Capacidade",
                    Expressao = @"q_max = v_f·k_j/4",
                    Descricao = "No modelo linear, o fluxo máximo ocorre em k_c=k_j/2 e v_c=v_f/2.",
                    ExemploPratico = "v_f=100 km/h, k_j=160 → q_max=4000 veíc/h (ideal teórico agregado).",
                    Criador = "Greenshields",
                    AnoOrigin = "1935",
                    VariavelResultado = "qmax",
                    UnidadeResultado = "veíc/h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v_f (km/h)", Simbolo = "vf", Unidade = "km/h", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k_j (veíc/km)", Simbolo = "kj", Unidade = "veíc/km", ValorPadrao = 160, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["v_f (km/h)"] * inputs["k_j (veíc/km)"] / 4.0,
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-361: Densidade crítica
                new Formula
                {
                    Id = "3949",
                    CodigoCompendio = "V10-361",
                    Nome = "Densidade Crítica",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Capacidade",
                    Expressao = @"k_c = k_j/2",
                    Descricao = "Densidade no ponto de máxima vazão no modelo de Greenshields.",
                    ExemploPratico = "k_j=140 → k_c=70 veíc/km.",
                    Criador = "Greenshields",
                    AnoOrigin = "1935",
                    VariavelResultado = "kc",
                    UnidadeResultado = "veíc/km",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k_j (veíc/km)", Simbolo = "kj", Unidade = "veíc/km", ValorPadrao = 140, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["k_j (veíc/km)"] / 2.0,
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-362: Velocidade crítica
                new Formula
                {
                    Id = "3950",
                    CodigoCompendio = "V10-362",
                    Nome = "Velocidade Crítica",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Capacidade",
                    Expressao = @"v_c = v_f/2",
                    Descricao = "Velocidade no ponto de máxima vazão no modelo de Greenshields.",
                    ExemploPratico = "v_f=90 km/h → v_c=45 km/h.",
                    Criador = "Greenshields",
                    AnoOrigin = "1935",
                    VariavelResultado = "vc",
                    UnidadeResultado = "km/h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v_f (km/h)", Simbolo = "vf", Unidade = "km/h", ValorPadrao = 90, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["v_f (km/h)"] / 2.0,
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-363: Headway temporal
                new Formula
                {
                    Id = "3951",
                    CodigoCompendio = "V10-363",
                    Nome = "Headway Temporal",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Micromodelos",
                    Expressao = @"h_t = 3600/q",
                    Descricao = "Tempo médio entre veículos consecutivos em um ponto.",
                    ExemploPratico = "q=1800 veíc/h → h_t=2.0 s.",
                    Criador = "Teoria de tráfego clássica",
                    AnoOrigin = "1950",
                    VariavelResultado = "ht",
                    UnidadeResultado = "s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "q (veíc/h)", Simbolo = "q", Unidade = "veíc/h", ValorPadrao = 1800, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double q = inputs["q (veíc/h)"];
                        if (q <= 0) return 0;
                        return 3600 / q;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-364: Espaçamento espacial
                new Formula
                {
                    Id = "3952",
                    CodigoCompendio = "V10-364",
                    Nome = "Espaçamento Médio",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Micromodelos",
                    Expressao = @"s = 1000/k",
                    Descricao = "Distância média entre veículos (centro a centro).",
                    ExemploPratico = "k=40 veíc/km → s=25 m/veículo.",
                    Criador = "Teoria de tráfego",
                    AnoOrigin = "1950",
                    VariavelResultado = "s",
                    UnidadeResultado = "m/veíc",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "k (veíc/km)", Simbolo = "k", Unidade = "veíc/km", ValorPadrao = 40, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double k = inputs["k (veíc/km)"];
                        if (k <= 0) return 0;
                        return 1000 / k;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-365: Tempo de viagem
                new Formula
                {
                    Id = "3953",
                    CodigoCompendio = "V10-365",
                    Nome = "Tempo de Viagem",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Desempenho",
                    Expressao = @"T = L/v",
                    Descricao = "Tempo para percorrer segmento de comprimento L.",
                    ExemploPratico = "L=15 km, v=45 km/h → T=0.333 h = 20 min.",
                    Criador = "Cinemática",
                    AnoOrigin = "1700",
                    VariavelResultado = "T",
                    UnidadeResultado = "min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "L (km)", Simbolo = "L", Unidade = "km", ValorPadrao = 15, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "v (km/h)", Simbolo = "v", Unidade = "km/h", ValorPadrao = 45, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double L = inputs["L (km)"];
                        double v = inputs["v (km/h)"];
                        if (v <= 0) return 0;
                        return 60 * L / v;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-366: Atraso de controle
                new Formula
                {
                    Id = "3954",
                    CodigoCompendio = "V10-366",
                    Nome = "Atraso de Controle em Interseção",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Sinalização",
                    Expressao = @"d = c·(1−g/c)^2/(2·(1−x))",
                    Descricao = "Forma simplificada inspirada em Webster para atraso médio de controle.",
                    ExemploPratico = "c=90 s, g=40 s, x=0.75 → d≈62.2 s/veíc.",
                    Criador = "F. V. Webster",
                    AnoOrigin = "1958",
                    VariavelResultado = "d",
                    UnidadeResultado = "s/veíc",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "c ciclo (s)", Simbolo = "c", Unidade = "s", ValorPadrao = 90, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "g verde efetivo (s)", Simbolo = "g", Unidade = "s", ValorPadrao = 40, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "x grau saturação", Simbolo = "x", Unidade = "", ValorPadrao = 0.75, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double c = inputs["c ciclo (s)"];
                        double g = inputs["g verde efetivo (s)"];
                        double x = inputs["x grau saturação"];
                        if (c <= 0 || x >= 1) return 0;
                        double ratio = g / c;
                        return c * Math.Pow(1 - ratio, 2) / (2 * (1 - x));
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-367: Ciclo ótimo de Webster
                new Formula
                {
                    Id = "3955",
                    CodigoCompendio = "V10-367",
                    Nome = "Ciclo Ótimo de Webster",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Sinalização",
                    Expressao = @"C0 = (1.5L + 5)/(1−Y)",
                    Descricao = "L: perdas por ciclo (s). Y: soma das razões de fluxo críticas.",
                    ExemploPratico = "L=12 s, Y=0.75 → C0=(18+5)/0.25=92 s.",
                    Criador = "F. V. Webster",
                    AnoOrigin = "1958",
                    VariavelResultado = "C0",
                    UnidadeResultado = "s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "L perdas (s)", Simbolo = "L", Unidade = "s", ValorPadrao = 12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Y soma fluxos", Simbolo = "Y", Unidade = "", ValorPadrao = 0.75, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double L = inputs["L perdas (s)"];
                        double Y = inputs["Y soma fluxos"];
                        if (Y >= 1) return 0;
                        return (1.5 * L + 5) / (1 - Y);
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-368: Grau de saturação
                new Formula
                {
                    Id = "3956",
                    CodigoCompendio = "V10-368",
                    Nome = "Grau de Saturação",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Sinalização",
                    Expressao = @"x = v/c",
                    Descricao = "Relação demanda/capacidade. x>1 indica super saturação.",
                    ExemploPratico = "v=900 veíc/h, c=1200 veíc/h → x=0.75.",
                    Criador = "HCM",
                    AnoOrigin = "1965",
                    VariavelResultado = "x",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v demanda (veíc/h)", Simbolo = "v", Unidade = "veíc/h", ValorPadrao = 900, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c capacidade (veíc/h)", Simbolo = "c", Unidade = "veíc/h", ValorPadrao = 1200, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double v = inputs["v demanda (veíc/h)"];
                        double c = inputs["c capacidade (veíc/h)"];
                        if (c <= 0) return 0;
                        return v / c;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-369: Choque de tráfego (shockwave)
                new Formula
                {
                    Id = "3957",
                    CodigoCompendio = "V10-369",
                    Nome = "Velocidade de Onda de Choque",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Dinâmica de Congestionamento",
                    Expressao = @"w = (q2−q1)/(k2−k1)",
                    Descricao = "Velocidade de propagação de fronteiras de congestionamento.",
                    ExemploPratico = "(q1,k1)=(1800,30), (q2,k2)=(600,90) → w=(−1200)/60=−20 km/h (onda sobe corrente).",
                    Criador = "Lighthill-Whitham-Richards",
                    AnoOrigin = "1955",
                    VariavelResultado = "w",
                    UnidadeResultado = "km/h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "q1 (veíc/h)", Simbolo = "q1", Unidade = "veíc/h", ValorPadrao = 1800, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k1 (veíc/km)", Simbolo = "k1", Unidade = "veíc/km", ValorPadrao = 30, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "q2 (veíc/h)", Simbolo = "q2", Unidade = "veíc/h", ValorPadrao = 600, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "k2 (veíc/km)", Simbolo = "k2", Unidade = "veíc/km", ValorPadrao = 90, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double q1 = inputs["q1 (veíc/h)"];
                        double k1 = inputs["k1 (veíc/km)"];
                        double q2 = inputs["q2 (veíc/h)"];
                        double k2 = inputs["k2 (veíc/km)"];
                        double den = k2 - k1;
                        if (den == 0) return 0;
                        return (q2 - q1) / den;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-370: Fila média M/M/1
                new Formula
                {
                    Id = "3958",
                    CodigoCompendio = "V10-370",
                    Nome = "Fila M/M/1 — Comprimento Médio",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Teoria de Filas",
                    Expressao = @"L = ρ/(1−ρ), ρ=λ/μ",
                    Descricao = "Modelo de fila simples para pedágios, semáforos e pontos de serviço.",
                    ExemploPratico = "λ=800 veíc/h, μ=1000 veíc/h → ρ=0.8 e L=4 veículos médios no sistema.",
                    Criador = "Teoria de filas",
                    AnoOrigin = "1909",
                    VariavelResultado = "L",
                    UnidadeResultado = "veíc",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "λ chegadas (veíc/h)", Simbolo = "lambda", Unidade = "veíc/h", ValorPadrao = 800, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "μ serviço (veíc/h)", Simbolo = "mu", Unidade = "veíc/h", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["λ chegadas (veíc/h)"];
                        double mu = inputs["μ serviço (veíc/h)"];
                        if (mu <= 0) return 0;
                        double rho = lambda / mu;
                        if (rho >= 1) return 9999;
                        return rho / (1 - rho);
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-371: Tempo médio no sistema M/M/1
                new Formula
                {
                    Id = "3959",
                    CodigoCompendio = "V10-371",
                    Nome = "Fila M/M/1 — Tempo Médio",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Teoria de Filas",
                    Expressao = @"W = 1/(μ−λ)",
                    Descricao = "Tempo médio no sistema (espera + serviço), assumindo chegadas Poisson e serviço exponencial.",
                    ExemploPratico = "λ=700/h, μ=1000/h → W=1/300 h=12 s.",
                    Criador = "Teoria de filas",
                    AnoOrigin = "1909",
                    VariavelResultado = "W",
                    UnidadeResultado = "s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "λ (veíc/h)", Simbolo = "lambda", Unidade = "veíc/h", ValorPadrao = 700, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "μ (veíc/h)", Simbolo = "mu", Unidade = "veíc/h", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["λ (veíc/h)"];
                        double mu = inputs["μ (veíc/h)"];
                        if (mu <= lambda) return 0;
                        double hours = 1.0 / (mu - lambda);
                        return hours * 3600;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-372: LOS por v/c (aprox.)
                new Formula
                {
                    Id = "3960",
                    CodigoCompendio = "V10-372",
                    Nome = "Indicador LOS via v/c",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Nível de Serviço",
                    Expressao = @"LOS_index = v/c",
                    Descricao = "Indicador numérico simples: menor é melhor. Aproximação para triagem operacional.",
                    ExemploPratico = "v/c=0.55 (bom), 0.85 (limite), >1.0 (colapso).",
                    Criador = "HCM simplificado",
                    AnoOrigin = "1965",
                    VariavelResultado = "vc_ratio",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "v (veíc/h)", Simbolo = "v", Unidade = "veíc/h", ValorPadrao = 1100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c (veíc/h)", Simbolo = "c", Unidade = "veíc/h", ValorPadrao = 1400, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double v = inputs["v (veíc/h)"];
                        double c = inputs["c (veíc/h)"];
                        if (c <= 0) return 0;
                        return v / c;
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-373: Saturation flow por faixa
                new Formula
                {
                    Id = "3961",
                    CodigoCompendio = "V10-373",
                    Nome = "Fluxo de Saturação",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Interseções",
                    Expressao = @"s = s0·f_w·f_hv·f_g·...",
                    Descricao = "Capacidade potencial por faixa com fatores de ajuste geométricos e de composição veicular.",
                    ExemploPratico = "s0=1900, f_w=0.95, f_hv=0.9, f_g=0.98 → s≈1592 veíc/h/faixa.",
                    Criador = "HCM",
                    AnoOrigin = "1965",
                    VariavelResultado = "s",
                    UnidadeResultado = "veíc/h/faixa",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "s0 base", Simbolo = "s0", Unidade = "veíc/h/faixa", ValorPadrao = 1900, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f_w", Simbolo = "fw", Unidade = "", ValorPadrao = 0.95, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f_hv", Simbolo = "fhv", Unidade = "", ValorPadrao = 0.9, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f_g", Simbolo = "fg", Unidade = "", ValorPadrao = 0.98, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => inputs["s0 base"] * inputs["f_w"] * inputs["f_hv"] * inputs["f_g"],
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-374: Gap acceptance
                new Formula
                {
                    Id = "3962",
                    CodigoCompendio = "V10-374",
                    Nome = "Probabilidade de Aceitação de Gap",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Interseções sem Sinal",
                    Expressao = @"P = exp(−λ·t_c)",
                    Descricao = "Aproximação para chance de encontrar gap maior que t_c em chegada Poisson no fluxo principal.",
                    ExemploPratico = "λ=0.25 veíc/s, t_c=5 s → P=exp(−1.25)=0.286.",
                    Criador = "Teoria de aceitação de gaps",
                    AnoOrigin = "1960",
                    VariavelResultado = "P",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "λ principal (veíc/s)", Simbolo = "lambda", Unidade = "veíc/s", ValorPadrao = 0.25, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t_c crítico (s)", Simbolo = "tc", Unidade = "s", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs => Math.Exp(-inputs["λ principal (veíc/s)"] * inputs["t_c crítico (s)"]),
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-375: Occupancy aproximada
                new Formula
                {
                    Id = "3963",
                    CodigoCompendio = "V10-375",
                    Nome = "Ocupação de Detector",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Sensoriamento",
                    Expressao = @"Occ ≈ q·(L_eff/v)",
                    Descricao = "Fração de tempo ocupada em laço indutivo (aproximação contínua).",
                    ExemploPratico = "q=1800/h=0.5/s, L_eff=7 m, v=20 m/s → Occ≈0.175 (17.5%).",
                    Criador = "Engenharia de tráfego com sensores",
                    AnoOrigin = "1970",
                    VariavelResultado = "Occ",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "q (veíc/h)", Simbolo = "q", Unidade = "veíc/h", ValorPadrao = 1800, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "L_eff (m)", Simbolo = "Le", Unidade = "m", ValorPadrao = 7, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "v (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double qh = inputs["q (veíc/h)"];
                        double Le = inputs["L_eff (m)"];
                        double v = inputs["v (m/s)"];
                        if (v <= 0) return 0;
                        double qs = qh / 3600.0;
                        return 100 * qs * (Le / v);
                    },
                    Icone = "🚗",
                    Unidades = "",
                },

                // V10-376: ALINEA (ramp metering)
                new Formula
                {
                    Id = "3964",
                    CodigoCompendio = "V10-376",
                    Nome = "ALINEA — Controle de Rampa",
                    Categoria = "Engenharia de Tráfego",
                    SubCategoria = "Controle Inteligente",
                    Expressao = @"r(k)=r(k−1)+K_R·(O_ref−O_out)",
                    Descricao = "Controlador feedback de metering em acessos de autoestrada baseado em ocupação downstream.",
                    ExemploPratico = "r_prev=700, K_R=60, O_ref=0.22, O_out=0.27 → r=697 veíc/h.",
                    Criador = "Papageorgiou et al.",
                    AnoOrigin = "1991",
                    VariavelResultado = "r",
                    UnidadeResultado = "veíc/h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "r_prev (veíc/h)", Simbolo = "rp", Unidade = "veíc/h", ValorPadrao = 700, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "K_R", Simbolo = "KR", Unidade = "", ValorPadrao = 60, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "O_ref", Simbolo = "Or", Unidade = "", ValorPadrao = 0.22, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "O_out", Simbolo = "Oo", Unidade = "", ValorPadrao = 0.27, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        return inputs["r_prev (veíc/h)"] + inputs["K_R"] * (inputs["O_ref"] - inputs["O_out"]);
                    },
                    Icone = "🚗",
                    Unidades = "",
                }
            });
        }
    }
}
