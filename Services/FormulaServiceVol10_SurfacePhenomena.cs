using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE XV
    /// FENÔMENOS DE SUPERFÍCIE E INTERFACES
    /// Fórmulas V10-280 a V10-299 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_SurfacePhenomena()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3868",
                    CodigoCompendio = "V10-280",
                    Nome = "Equação de Young — Ângulo de Contato",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Tensão Superficial",
                    Expressao = @"γ_SV = γ_SL + γ_LV·cos(θ)",
                    Descricao = "Equilíbrio de tensões superficiais. θ: ângulo de contato. θ<90º: molhável. θ>90º: não-molhável.",
                    ExemploPratico = "Água-vidro: θ≈0º (molha). Mercúrio-vidro: θ≈140º (não molha). Superh hidr ofóbico: θ>150º.",
                    Criador = "Young (1805, Trans. Royal Soc.)",
                    AnoOrigin = "1805",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ_LV (mN/m)", Simbolo = "γ_LV", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Ângulo θ (°)", Simbolo = "θ", Unidade = "°", ValorPadrao = 30, Descricao = "Parâmetro de entrada." }
                    },
                    VariavelResultado = "cos_theta",
                    UnidadeResultado = "",
                    Calcular = inputs =>
                    {
                        double gamma_LV = inputs["γ_LV (mN/m)"];
                        double theta_deg = inputs["Ângulo θ (°)"];
                        double theta_rad = theta_deg * Math.PI / 180;
                        
                        double cos_theta = Math.Cos(theta_rad);
                        return cos_theta;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-281: Pressão de Laplace
                new Formula
                {
                    Id = "3869",
                    CodigoCompendio = "V10-281",
                    Nome = "Pressão de Laplace — Curvatura",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Tensão Superficial",
                    Expressao = @"Δp = γ·(1/R₁ + 1/R₂); curvatura dupla",
                    Descricao = "R₁,R₂: raios principais curvatura. Gota esférica: Δp=2γ/R. Bolha: Δp=4γ/R (2 interfaces). Emulsão: pressão interna maior (Δp∝1/R).",
                    ExemploPratico = "Gota água r=1mm, γ=72 mN/m→Δp=2·72e-3/1e-3=144 Pa (1.4 mbar). Bolha sabão r=1cm→Δp=4·25/0.01=10000 Pa (100 mbar).",
                    Criador = "Laplace (1805, Mécanique Céleste); Young (1805, capilaridade)",
                    AnoOrigin = "1805",
                    VariavelResultado = "delta_p",
                    UnidadeResultado = "Pa",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "R raio (mm)", Simbolo = "R", Unidade = "mm", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tipo (2=gota,4=bolha)", Simbolo = "tipo", Unidade = "", ValorPadrao = 2, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma_mN = inputs["γ (mN/m)"];
                        double R_mm = inputs["R raio (mm)"];
                        double tipo = inputs["Tipo (2=gota,4=bolha)"];
                        
                        double gamma = gamma_mN / 1000; // N/m
                        double R_m = R_mm / 1000;
                        
                        double delta_p = tipo * gamma / R_m;
                        return delta_p;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-282: Ascensão Capilar (Jurin)
                new Formula
                {
                    Id = "3870",
                    CodigoCompendio = "V10-282",
                    Nome = "Lei de Jurin — Capilaridade",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Capilaridade",
                    Expressao = @"h = (2·γ·cos(θ))/(ρ·g·r)",
                    Descricao = "Ascensão líquido em tubo capilar. h∝1/r. θ: ângulo contato. Água: θ≈0°, max ascensão. Mercúrio: θ>90°, depressão.",
                    ExemploPratico = "Água em tubo r=0.5mm, γ=72mN/m, θ=0°, ρ=1000 kg/m³→h=2·0.072·1/(1000·9.8·0.0005)≈29 mm. Suction em plantas, papel absorvente.",
                    Criador = "Jurin (1718, observação capilaridade); Laplace (1805, teoria)",
                    AnoOrigin = "1718",
                    VariavelResultado = "h",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "θ (°)", Simbolo = "theta", Unidade = "°", ValorPadrao = 0, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "r raio (mm)", Simbolo = "r", Unidade = "mm", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ρ (kg/m³)", Simbolo = "rho", Unidade = "kg/m³", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma_mN = inputs["γ (mN/m)"];
                        double theta_deg = inputs["θ (°)"];
                        double r_mm = inputs["r raio (mm)"];
                        double rho = inputs["ρ (kg/m³)"];
                        
                        double gamma = gamma_mN / 1000;
                        double theta_rad = theta_deg * Math.PI / 180;
                        double r_m = r_mm / 1000;
                        double g = 9.8;
                        
                        double h_m = (2 * gamma * Math.Cos(theta_rad)) / (rho * g * r_m);
                        double h_mm = h_m * 1000;
                        return h_mm;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-283: Surfactantes (CMC)
                new Formula
                {
                    Id = "3871",
                    CodigoCompendio = "V10-283",
                    Nome = "CMC — Concentração Micelar Crítica",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Surfactantes",
                    Expressao = @"γ diminui até CMC, depois constante",
                    Descricao = "Abaixo CMC: monômeros adsorvem interface, γ cai. Acima CMC: micelas formam (interior hidrofóbico), γ constante. SDS: CMC≈8 mM. Tween-20: CMC≈0.06 mM.",
                    ExemploPratico = "SDS 0-10 mM: γ água 72→35 mN/m @ CMC≈8mM. >8mM: γ≈35 constante. Emulsificação, detergente, drug delivery. HLB (hydrophile-lipophile balance).",
                    Criador = "Diversos; McBain (1913, micelle concept); Hartley (1936, structure)",
                    AnoOrigin = "1913",
                    VariavelResultado = "gamma",
                    UnidadeResultado = "mN/m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "c concentração (mM)", Simbolo = "c", Unidade = "mM", ValorPadrao = 5, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "CMC (mM)", Simbolo = "CMC", Unidade = "mM", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ₀ água (mN/m)", Simbolo = "gamma0", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ_CMC mín (mN/m)", Simbolo = "gammaCMC", Unidade = "mN/m", ValorPadrao = 35, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double c = inputs["c concentração (mM)"];
                        double CMC = inputs["CMC (mM)"];
                        double gamma0 = inputs["γ₀ água (mN/m)"];
                        double gammaCMC = inputs["γ_CMC mín (mN/m)"];
                        
                        if (c >= CMC)
                            return gammaCMC;
                        
                        // Linear decrescente até CMC
                        double gamma = gamma0 - (gamma0 - gammaCMC) * (c / CMC);
                        return gamma;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-284: Adsorção de Gibbs
                new Formula
                {
                    Id = "3872",
                    CodigoCompendio = "V10-284",
                    Nome = "Equação de Adsorção de Gibbs",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Adsorção",
                    Expressao = @"Γ = −(1/RT)·(dγ/d ln c); Γ: excesso superficial",
                    Descricao = "Relaciona queda γ com adsorção Γ (mol/m²). Surfactantes: −dγ/dlnc grande→Γ alto (adsorção intensa). Gibbs (1878) termodinâmica interfaces.",
                    ExemploPratico = "Surfactante: dγ/dlnc=−10 mN/m, T=298K→Γ=10e-3/(8.314·298)≈4×10^-6 mol/m²≈2.4×10^18 moléculas/m² (monocamada ~2×10^18).",
                    Criador = "Gibbs (1878, On Equilibrium Heterogeneous Substances)",
                    AnoOrigin = "1878",
                    VariavelResultado = "Gamma",
                    UnidadeResultado = "µmol/m²",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "dγ/dlnc (mN/m)", Simbolo = "dgamma_dlnc", Unidade = "mN/m", ValorPadrao = -10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "T (K)", Simbolo = "T", Unidade = "K", ValorPadrao = 298, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double dgamma_dlnc = inputs["dγ/dlnc (mN/m)"];
                        double T = inputs["T (K)"];
                        
                        double R = 8.314; // J/(mol·K)
                        double dgamma = dgamma_dlnc / 1000; // N/m
                        
                        double Gamma_mol = -dgamma / (R * T);
                        double Gamma_umol = Gamma_mol * 1e6;
                        return Gamma_umol;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-285: Isoterma de Langmuir
                new Formula
                {
                    Id = "3873",
                    CodigoCompendio = "V10-285",
                    Nome = "Isoterma de Langmuir — Adsorção",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Adsorção",
                    Expressao = @"θ = (K·p)/(1+K·p); θ: fração cobertura",
                    Descricao = "Monocamada, sítios equivalentes, sem interação. K: constante equilíbrio. θ→1 @ p alto. BET: multicamadas (Brunauer-Emmett-Teller 1938).",
                    ExemploPratico = "CO em Pt: K=10 atm⁻¹, p=0.1 atm→θ=10·0.1/(1+1)=0.5 (50% cobertura). p=10 atm→θ=100/101≈0.99 (saturação). Catalysis.",
                    Criador = "Langmuir (1918, Nobel 1932 surface chemistry)",
                    AnoOrigin = "1918",
                    VariavelResultado = "theta",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "K equilíbrio (1/atm)", Simbolo = "K", Unidade = "1/atm", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "p pressão (atm)", Simbolo = "p", Unidade = "atm", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double K = inputs["K equilíbrio (1/atm)"];
                        double p = inputs["p pressão (atm)"];
                        
                        double theta = (K * p) / (1 + K * p);
                        return theta;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-286: Coeficiente de Espalhamento
                new Formula
                {
                    Id = "3874",
                    CodigoCompendio = "V10-286",
                    Nome = "Coeficiente de Espalhamento",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Wetting Dynamics",
                    Expressao = @"S = γ_SV − (γ_SL + γ_LV); S>0: espalhamento",
                    Descricao = "S>0: líquido espalha espontaneamente (filme). S<0: gota persiste. Óleo água: S<0. Óleo em vidro: S≈0 (espalhamento lento). Harkins (1919).",
                    ExemploPratico = "Água em parafina: γ_SV=25, γ_SL=50, γ_LV=72→S=25−(50+72)=−97 (não espalha, gota). Silicone oil: S>0 (espalha).",
                    Criador = "Harkins (1919, spreading coefficient)",
                    AnoOrigin = "1919",
                    VariavelResultado = "S",
                    UnidadeResultado = "mN/m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ_SV (mN/m)", Simbolo = "gamma_SV", Unidade = "mN/m", ValorPadrao = 25, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ_SL (mN/m)", Simbolo = "gamma_SL", Unidade = "mN/m", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ_LV (mN/m)", Simbolo = "gamma_LV", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma_SV = inputs["γ_SV (mN/m)"];
                        double gamma_SL = inputs["γ_SL (mN/m)"];
                        double gamma_LV = inputs["γ_LV (mN/m)"];
                        
                        double S = gamma_SV - (gamma_SL + gamma_LV);
                        return S;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-287: Dinâmica de Molhamento (Washburn)
                new Formula
                {
                    Id = "3875",
                    CodigoCompendio = "V10-287",
                    Nome = "Equação de Washburn — Penetração Capilar",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Dinâmica de Wetting",
                    Expressao = @"x² = (γ·r·cos(θ)·t)/(2·η); x: distância penetrada",
                    Descricao = "Penetração em poro/canal. x∝√t (difusivo). η: viscosidade. Papel absorvente, tecidos, membranas porosas. Washburn (1921).",
                    ExemploPratico = "Água papel r=10µm, γ=72mN/m, θ=0°, η=1mPa·s, t=1s→x²=(0.072·10e-6·1·1)/(2·0.001)=3.6e-7→x≈0.6mm. Lucas-Washburn.",
                    Criador = "Washburn (1921, capillary penetration); Lucas (1918, independent)",
                    AnoOrigin = "1921",
                    VariavelResultado = "x",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "r raio (µm)", Simbolo = "r", Unidade = "µm", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "θ (°)", Simbolo = "theta", Unidade = "°", ValorPadrao = 0, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "t tempo (s)", Simbolo = "t", Unidade = "s", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "η viscosidade (mPa·s)", Simbolo = "eta", Unidade = "mPa·s", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma_mN = inputs["γ (mN/m)"];
                        double r_um = inputs["r raio (µm)"];
                        double theta_deg = inputs["θ (°)"];
                        double t = inputs["t tempo (s)"];
                        double eta_mPa = inputs["η viscosidade (mPa·s)"];
                        
                        double gamma = gamma_mN / 1000;
                        double r_m = r_um * 1e-6;
                        double theta_rad = theta_deg * Math.PI / 180;
                        double eta = eta_mPa / 1000;
                        
                        double x2 = (gamma * r_m * Math.Cos(theta_rad) * t) / (2 * eta);
                        double x_m = Math.Sqrt(x2);
                        double x_mm = x_m * 1000;
                        return x_mm;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-288: Superhidrofóbico (Cassie-Baxter)
                new Formula
                {
                    Id = "3876",
                    CodigoCompendio = "V10-288",
                    Nome = "Modelo Cassie-Baxter — Superfície Rugosa",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Superhidrofobicidade",
                    Expressao = @"cos(θ*) = f·cos(θ) − (1−f); f: fração sólido-líquido",
                    Descricao = "Rugosidade+ar trapped→θ*>θ. Lotus effect: θ*>150°, low adhesion. f~0.1→cos(θ*)≈−0.9→θ*≈154°. Wenzel: penetra rugosidade (high adhesion).",
                    ExemploPratico = "PTFE θ=110°, f=0.2 (80% ar)→cos(θ*)=0.2·(−0.34)−0.8=−0.87→θ*≈150° (superhidrofóbico). Coating nanoestruturas lotus leaf.",
                    Criador = "Cassie-Baxter (1944, wetting on rough surfaces); Wenzel (1936, alternative model)",
                    AnoOrigin = "1944",
                    VariavelResultado = "theta_star",
                    UnidadeResultado = "°",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "θ intrínseco (°)", Simbolo = "theta", Unidade = "°", ValorPadrao = 110, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "f fração sólido", Simbolo = "f", Unidade = "", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double theta_deg = inputs["θ intrínseco (°)"];
                        double f = inputs["f fração sólido"];
                        
                        double theta_rad = theta_deg * Math.PI / 180;
                        double cos_theta_star = f * Math.Cos(theta_rad) - (1 - f);
                        
                        if (cos_theta_star < -1) cos_theta_star = -1;
                        if (cos_theta_star > 1) cos_theta_star = 1;
                        
                        double theta_star_deg = Math.Acos(cos_theta_star) * 180 / Math.PI;
                        return theta_star_deg;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-289: Histerese de Ângulo de Contato
                new Formula
                {
                    Id = "3877",
                    CodigoCompendio = "V10-289",
                    Nome = "Histerese θ_a − θ_r",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Dinâmica de Contato",
                    Expressao = @"Δθ = θ_a − θ_r; a: avanço, r: recuo",
                    Descricao = "θ_a>θ_r: rugosidade, heterogeneidade química. Superfície ideal: Δθ≈0°. Superhidrofóbico: Δθ<10° (low pinning). Adesão∝Δθ.",
                    ExemploPratico = "Vidro limpo: θ_a≈15°, θ_r≈5°→Δθ=10° (baixo). Polímero: θ_a=95°, θ_r=65°→Δθ=30° (alto pinning). Lotus: Δθ<5° (roll-off easy).",
                    Criador = "Diversos; Johnson-Dettre (1964, contact angle hysteresis)",
                    AnoOrigin = "1964",
                    VariavelResultado = "delta_theta",
                    UnidadeResultado = "°",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "θ_a avanço (°)", Simbolo = "theta_a", Unidade = "°", ValorPadrao = 95, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "θ_r recuo (°)", Simbolo = "theta_r", Unidade = "°", ValorPadrao = 65, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double theta_a = inputs["θ_a avanço (°)"];
                        double theta_r = inputs["θ_r recuo (°)"];
                        
                        double delta_theta = theta_a - theta_r;
                        return delta_theta;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-290: Trabalho de Adesão (Dupré)
                new Formula
                {
                    Id = "3878",
                    CodigoCompendio = "V10-290",
                    Nome = "Trabalho de Adesão (Dupré)",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Adesão",
                    Expressao = @"W_a = γ_SV + γ_LV − γ_SL; Young-Dupré: W_a=γ_LV·(1+cos θ)",
                    Descricao = "Energia separar interface. W_a alto: forte adesão. θ=0°→W_a=2γ_LV (spreading). θ=180°→W_a=0 (não adere). Bioadhesion, coatings.",
                    ExemploPratico = "Água-vidro θ≈0°→W_a≈2·72=144 mN/m (forte). Mercúrio-vidro θ≈140°→W_a=72·(1−0.77)≈17 mN/m (fraco). Gecko: W_a via van der Waals.",
                    Criador = "Dupré (1869, théorie mécanique chaleur); Young-Dupré equation (1805/1869)",
                    AnoOrigin = "1869",
                    VariavelResultado = "W_a",
                    UnidadeResultado = "mN/m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ_LV (mN/m)", Simbolo = "gamma_LV", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "θ (°)", Simbolo = "theta", Unidade = "°", ValorPadrao = 0, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma_LV = inputs["γ_LV (mN/m)"];
                        double theta_deg = inputs["θ (°)"];
                        
                        double theta_rad = theta_deg * Math.PI / 180;
                        double W_a = gamma_LV * (1 + Math.Cos(theta_rad));
                        return W_a;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-291: Tensão Interfacial Líquido-Líquido
                new Formula
                {
                    Id = "3879",
                    CodigoCompendio = "V10-291",
                    Nome = "Tensão Interfacial γ_12",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Interfaces Líquido-Líquido",
                    Expressao = @"γ_12 ≈ √(γ_1·γ_2) (aprox); ou Fowkes γ_12=γ_1+γ_2−2·√(γ_1^d·γ_2^d)",
                    Descricao = "Água-óleo: γ_12≈50 mN/m. Surfactantes reduzem γ_12→emulsificação. Microemulsão: γ_12≈0.01 mN/m (ultralow, spontaneous). Fowkes: componentes dispersivas.",
                    ExemploPratico = "Água (γ=72) - hexano (γ=18)→γ_12≈√(72·18)≈36 mN/m (aproximado). Real≈51 mN/m. Adicionar surfactante→γ_12<1 (emulsão estável).",
                    Criador = "Fowkes (1964, interfacial tension theory); Antonow, Girifalco-Good (aproximações)",
                    AnoOrigin = "1964",
                    VariavelResultado = "gamma_12",
                    UnidadeResultado = "mN/m",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ_1 (mN/m)", Simbolo = "gamma1", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ_2 (mN/m)", Simbolo = "gamma2", Unidade = "mN/m", ValorPadrao = 18, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma1 = inputs["γ_1 (mN/m)"];
                        double gamma2 = inputs["γ_2 (mN/m)"];
                        
                        double gamma_12 = Math.Sqrt(gamma1 * gamma2);
                        return gamma_12;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-292: Número de Weber (Dinâmica Gota)
                new Formula
                {
                    Id = "3880",
                    CodigoCompendio = "V10-292",
                    Nome = "Número de Weber — Dinâmica de Gota",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Dinâmica de Fluidos",
                    Expressao = @"We = ρ·v²·L/γ; inércia vs tensão superficial",
                    Descricao = "We<<1: tensão domina (gota esférica). We>>1: inércia domina (splashing). Spray, inkjet: We~10-100. Weber (1931) breakup.",
                    ExemploPratico = "Gota água v=1 m/s, L=1mm, ρ=1000, γ=72 mN/m→We=1000·1·0.001/0.072≈14 (deformação moderada). Inkjet We≈10 (controle forma).",
                    Criador = "Weber (1931, liquid jet breakup)",
                    AnoOrigin = "1931",
                    VariavelResultado = "We",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "ρ (kg/m³)", Simbolo = "rho", Unidade = "kg/m³", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "v velocidade (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "L dim (mm)", Simbolo = "L", Unidade = "mm", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double rho = inputs["ρ (kg/m³)"];
                        double v = inputs["v velocidade (m/s)"];
                        double L_mm = inputs["L dim (mm)"];
                        double gamma_mN = inputs["γ (mN/m)"];
                        
                        double L_m = L_mm / 1000;
                        double gamma = gamma_mN / 1000;
                        
                        double We = rho * v * v * L_m / gamma;
                        return We;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-293: Número Capilar (Ca)
                new Formula
                {
                    Id = "3881",
                    CodigoCompendio = "V10-293",
                    Nome = "Número Capilar — Ca",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Dinâmica de Menisco",
                    Expressao = @"Ca = η·v/γ; viscoso vs tensão superficial",
                    Descricao = "Ca<<1: quasi-estático (tensão domina). Ca~1: dinâmico. Ca>>1: viscoso domina (menisco plano). Coating, printing, microfluidics.",
                    ExemploPratico = "Óleo η=100 mPa·s, v=0.1 m/s, γ=30 mN/m→Ca=0.1·0.1/0.03≈0.33 (regime dinâmico). Água Ca≈0.001 (quasi-estático). Dip-coating.",
                    Criador = "Diversos; parâmetro adimensional clássico fluidos",
                    AnoOrigin = "1960",
                    VariavelResultado = "Ca",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "η viscosidade (mPa·s)", Simbolo = "eta", Unidade = "mPa·s", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "v velocidade (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 30, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double eta_mPa = inputs["η viscosidade (mPa·s)"];
                        double v = inputs["v velocidade (m/s)"];
                        double gamma_mN = inputs["γ (mN/m)"];
                        
                        double eta = eta_mPa / 1000;
                        double gamma = gamma_mN / 1000;
                        
                        double Ca = eta * v / gamma;
                        return Ca;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-294: Comprimento Capilar
                new Formula
                {
                    Id = "3882",
                    CodigoCompendio = "V10-294",
                    Nome = "Comprimento Capilar κ^(-1)",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Escala Capilar",
                    Expressao = @"κ^(-1) = √(γ/(ρ·g)); escala tensão vs gravidade",
                    Descricao = "Água: κ^-1≈2.7 mm. L<κ^-1: tensão domina (gota esférica). L>κ^-1: gravidade domina (flat puddle). Bolha: Bond number Bo=(L/κ^-1)².",
                    ExemploPratico = "Água γ=72 mN/m, ρ=1000 kg/m³→κ^-1=√(0.072/(1000·9.8))≈2.7 mm. Gota 1mm: esférica. Poça 10cm: flat (gravidade domina).",
                    Criador = "Diversos; escala capilar fundamental física interfaces",
                    AnoOrigin = "1900",
                    VariavelResultado = "kappa_inv",
                    UnidadeResultado = "mm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 72, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ρ (kg/m³)", Simbolo = "rho", Unidade = "kg/m³", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma_mN = inputs["γ (mN/m)"];
                        double rho = inputs["ρ (kg/m³)"];
                        
                        double gamma = gamma_mN / 1000;
                        double g = 9.8;
                        
                        double kappa_inv_m = Math.Sqrt(gamma / (rho * g));
                        double kappa_inv_mm = kappa_inv_m * 1000;
                        return kappa_inv_mm;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-295: Isoterma BET (Adsorção Multicamadas)
                new Formula
                {
                    Id = "3883",
                    CodigoCompendio = "V10-295",
                    Nome = "BET — Brunauer-Emmett-Teller",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Adsorção Multicamadas",
                    Expressao = @"1/[V·(p₀/p−1)] = (C−1)/(V_m·C)·(p/p₀) + 1/(V_m·C)",
                    Descricao = "Multicamadas. V_m: volume monocamada→área BET (m²/g). C: constante relacionada calor adsorção. N₂ @ 77K padrão. ISO 9277.",
                    ExemploPratico = "Catalisador N₂: V_m=100 cm³/g STP→A_BET=V_m·N_A·σ_N₂/22400≈435 m²/g (σ_N₂=16.2 Ų). Zeólitas: 300-1000 m²/g. Grafeno: 2630 m²/g teórico.",
                    Criador = "Brunauer-Emmett-Teller (1938, BET theory)",
                    AnoOrigin = "1938",
                    VariavelResultado = "A_BET",
                    UnidadeResultado = "m²/g",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "V_m monocamada (cm³/g STP)", Simbolo = "Vm", Unidade = "cm³/g", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Vm = inputs["V_m monocamada (cm³/g STP)"];
                        
                        // N₂: σ=16.2 Ų = 16.2e-20 m²
                        double sigma_N2 = 16.2e-20; // m²
                        double N_A = 6.022e23;
                        double volume_molar_STP = 22400; // cm³/mol
                        
                        double A_BET = Vm * N_A * sigma_N2 / volume_molar_STP;
                        return A_BET;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-296: Ângulo de Contato Dinâmico (Cox-Voinov)
                new Formula
                {
                    Id = "3884",
                    CodigoCompendio = "V10-296",
                    Nome = "Cox-Voinov — θ Dinâmico",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Dinâmica de Linha de Contato",
                    Expressao = @"θ_d³ = θ_e³ + 9·Ca·ln(L/l_s); Ca: número capilar",
                    Descricao = "θ_d: dinâmico (avançando/recuando). θ_e: equilíbrio (Young). L: macro, l_s: slip length (nm). Ca>0: avanço θ_d>θ_e. Ca<0: recuo θ_d<θ_e.",
                    ExemploPratico = "θ_e=60°, Ca=0.01, ln(L/l_s)≈10→θ_d³=60³+9·0.01·10·180³/π³≈216000+187000→θ_d≈75° (advancing). Coating speed dependence.",
                    Criador = "Cox (1986); Voinov (1976, hydrodynamic theory moving contact line)",
                    AnoOrigin = "1976",
                    VariavelResultado = "theta_d",
                    UnidadeResultado = "°",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "θ_e equilíbrio (°)", Simbolo = "theta_e", Unidade = "°", ValorPadrao = 60, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Ca número capilar", Simbolo = "Ca", Unidade = "", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double theta_e_deg = inputs["θ_e equilíbrio (°)"];
                        double Ca = inputs["Ca número capilar"];
                        
                        // Assume ln(L/l_s)≈10 típico
                        double ln_ratio = 10;
                        
                        double theta_e_rad = theta_e_deg * Math.PI / 180;
                        double theta_d_rad3 = Math.Pow(theta_e_rad, 3) + 9 * Ca * ln_ratio;
                        
                        if (theta_d_rad3 < 0) theta_d_rad3 = 0;
                        double theta_d_rad = Math.Pow(theta_d_rad3, 1.0 / 3.0);
                        double theta_d_deg = theta_d_rad * 180 / Math.PI;
                        
                        return theta_d_deg;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-297: Emulsões (Tamanho Gota)
                new Formula
                {
                    Id = "3885",
                    CodigoCompendio = "V10-297",
                    Nome = "Tamanho Gota Emulsão — We crítico",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Emulsificação",
                    Expressao = @"d ∝ γ/(ρ·v²); breakup We_crit≈1",
                    Descricao = "Turbulência quebra gotas. d∝γ/(energia dissipação). Surfactante reduz γ→gotas menores. Microemulsão: d<100nm (γ≈0.01 mN/m). Ultrasound: cavitation breakup.",
                    ExemploPratico = "Óleo-água γ=50 mN/m, homogenizer v=10 m/s, ρ=1000→d≈50e-3/(1000·100)≈0.5 µm. CMC surfactante γ=5→d≈0.05 µm (sub-micron).",
                    Criador = "Diversos; Hinze (1955, turbulence breakup); Kolmogorov (1949, cascade)",
                    AnoOrigin = "1949",
                    VariavelResultado = "d",
                    UnidadeResultado = "µm",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "ρ (kg/m³)", Simbolo = "rho", Unidade = "kg/m³", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "v velocidade (m/s)", Simbolo = "v", Unidade = "m/s", ValorPadrao = 10, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double gamma_mN = inputs["γ (mN/m)"];
                        double rho = inputs["ρ (kg/m³)"];
                        double v = inputs["v velocidade (m/s)"];
                        
                        double gamma = gamma_mN / 1000;
                        double d_m = gamma / (rho * v * v);
                        double d_um = d_m * 1e6;
                        return d_um;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-298: Coalescência (Tempo)
                new Formula
                {
                    Id = "3886",
                    CodigoCompendio = "V10-298",
                    Nome = "Tempo de Coalescência",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Estabilidade de Emulsões",
                    Expressao = @"t_coal ∝ η/(γ·R); filme drena antes coalescência",
                    Descricao = "Filme fino entre gotas drena viscosamente. η alto: t_coal grande (estabilidade). Surfactantes: Gibbs-Marangoni effect retarda drainage. DLVO: repulsão eletrostática.",
                    ExemploPratico = "Óleo-água η=1 mPa·s, γ=50 mN/m, R=1 µm→t_coal∝0.001/(0.05·1e-6)≈20 s (rápido). η=100 (polímero)→t_coal≈2000s (estável horas).",
                    Criador = "Diversos; Scheludko (1960s film drainage); DLVO theory (1940s)",
                    AnoOrigin = "1960",
                    VariavelResultado = "t_coal",
                    UnidadeResultado = "s",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "η viscosidade (mPa·s)", Simbolo = "eta", Unidade = "mPa·s", ValorPadrao = 1, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "γ (mN/m)", Simbolo = "gamma", Unidade = "mN/m", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "R raio gota (µm)", Simbolo = "R", Unidade = "µm", ValorPadrao = 1, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double eta_mPa = inputs["η viscosidade (mPa·s)"];
                        double gamma_mN = inputs["γ (mN/m)"];
                        double R_um = inputs["R raio gota (µm)"];
                        
                        double eta = eta_mPa / 1000;
                        double gamma = gamma_mN / 1000;
                        double R_m = R_um * 1e-6;
                        
                        // Aproximação empírica
                        double t_coal = eta / (gamma * R_m);
                        return t_coal;
                    },
                    Icone = "💧",
                    Unidades = "",
                },

                // V10-299: HLB (Hydrophile-Lipophile Balance)
                new Formula
                {
                    Id = "3887",
                    CodigoCompendio = "V10-299",
                    Nome = "HLB — Balanço Hidrófilo-Lipófilo",
                    Categoria = "Fenômenos de Superfície",
                    SubCategoria = "Surfactantes",
                    Expressao = @"HLB = (M_h/M)×20; M_h: massa hidrofílica, M: total",
                    Descricao = "HLB<10: lipofílico (W/O emulsion). HLB>10: hidrofílico (O/W). HLB≈7-9: wetting agent. HLB≈13-15: detergent. Tween-20: HLB≈16.7. Span-80: HLB≈4.3.",
                    ExemploPratico = "Surfactante M=500 g/mol, M_h (PEG chains)=350→HLB=(350/500)×20=14 (O/W emulsifier). Mixing surfactants: HLB_mix=Σ(x_i·HLB_i).",
                    Criador = "Griffin (1949, HLB system); Davies (1957, calculation method)",
                    AnoOrigin = "1949",
                    VariavelResultado = "HLB",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "M_h hidrofílico (g/mol)", Simbolo = "Mh", Unidade = "g/mol", ValorPadrao = 350, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "M total (g/mol)", Simbolo = "M", Unidade = "g/mol", ValorPadrao = 500, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double Mh = inputs["M_h hidrofílico (g/mol)"];
                        double M = inputs["M total (g/mol)"];
                        
                        if (M == 0) return 0;
                        double HLB = (Mh / M) * 20;
                        return HLB;
                    },
                    Icone = "💧",
                    Unidades = "",
                }
            });
        }
    }
}
