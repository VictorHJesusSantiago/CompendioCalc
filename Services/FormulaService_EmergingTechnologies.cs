using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 7 — PARTE X: TECNOLOGIAS EMERGENTES (22 fórmulas)
    // ═══════════════════════════════════════════════════════════════

    private void AdicionarVol7TechEmergente()
    {
        _formulas.AddRange([
            // ═══ CRIPTOGRAFIA (7 fórmulas) ═══

            new Formula
            {
                Id = "7_crp01", Nome = "Cifra de César (Shift)", Categoria = "Criptografia",
                Expressao = "C = (P + K) mod 26",
                ExprTexto = "Cifrado = (posição_letra + chave) mod 26",
                Icone = "🔐",
                Descricao = "Substituição monoalfabética por deslocamento. Cada letra avança K posições no alfabeto. A=0, B=1,... Z=25. Quebrável por frequência.",
                Criador = "Júlio César (~50 a.C.); K=3 original",
                AnoOrigin = "50 a.C.",
                ExemploPratico = "Letra 'A'(0), K=3: C = (0+3)%26 = 3 = 'D'. \"ATACAR\" → \"DWDFDU\"",
                Variaveis = [
                    new() { Simbolo = "P", Nome = "Posição da letra (0-25)", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "K", Nome = "Chave (deslocamento)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "C (posição cifrada)",
                Calcular = vars => ((int)(vars["P"] + vars["K"]) % 26 + 26) % 26,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_crp02", Nome = "RSA — Exponenciação Modular", Categoria = "Criptografia",
                Expressao = "C = M^e mod n",
                ExprTexto = "Cifrado = mensagem^e mod n  (chave pública)",
                Icone = "RSA",
                Descricao = "Cifração RSA: M = mensagem (número < n), e = expoente público, n = p×q (primos). Decifrar: M = C^d mod n. Segurança: fatorar n é difícil.",
                Criador = "Rivest, Shamir, Adleman (1977)",
                AnoOrigin = "1977",
                ExemploPratico = "M=7, e=3, n=33 (3×11): C = 7³ mod 33 = 343 mod 33 = 13",
                Variaveis = [
                    new() { Simbolo = "M", Nome = "Mensagem (M)", ValorPadrao = 7, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "e", Nome = "Expoente público (e)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "n", Nome = "Módulo (n)", ValorPadrao = 33, ValorMin = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "C (cifrado)",
                Calcular = vars =>
                {
                    long m = (long)vars["M"], exp = (long)vars["e"], mod = (long)vars["n"];
                    long result = 1;
                    m %= mod;
                    for (long i = 0; i < exp; i++) result = (result * m) % mod;
                    return result;
                },
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_crp03", Nome = "Entropia da Senha", Categoria = "Criptografia",
                Expressao = "H = L · log₂(N)",
                ExprTexto = "H = comprimento × log₂(tamanho_alfabeto)",
                Icone = "🔑",
                Descricao = "Entropia em bits de uma senha aleatória. N = nº de caracteres possíveis (26 a-z, 52 +maiúsc., 62 +num., 95 +símb.). H>80 bits = forte.",
                Criador = "Shannon (1948); NIST (diretrizes de senhas)",
                AnoOrigin = "1948",
                ExemploPratico = "Senha 12 chars, a-z+A-Z+0-9 (N=62): H = 12×log₂(62) = 12×5,95 = 71,4 bits",
                Variaveis = [
                    new() { Simbolo = "L", Nome = "Comprimento da senha", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "N", Nome = "Tamanho do alfabeto", ValorPadrao = 62, ValorMin = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "H (bits)",
                UnidadeResultado = "bits",
                Calcular = vars => vars["L"] * Math.Log(vars["N"]) / Math.Log(2),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_crp04", Nome = "Diffie-Hellman (Chave Compartilhada)", Categoria = "Criptografia",
                Expressao = "K = g^ab mod p",
                ExprTexto = "K = g^(a×b) mod p  (demonstração simplificada)",
                Icone = "DH",
                Descricao = "Troca de chaves Diffie-Hellman: Alice e Bob concordam em g e p públicos. Alice envia g^a mod p, Bob envia g^b mod p. Ambos calculam g^ab mod p.",
                Criador = "Diffie & Hellman (1976)",
                AnoOrigin = "1976",
                ExemploPratico = "g=5, p=23, a=6, b=15: g^ab mod p = 5^90 mod 23 = 2 (chave compartilhada)",
                Variaveis = [
                    new() { Simbolo = "g", Nome = "Base (g)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "a", Nome = "Segredo de Alice (a)", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "b", Nome = "Segredo de Bob (b)", ValorPadrao = 15, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "p", Nome = "Primo (p)", ValorPadrao = 23, ValorMin = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "K (chave)",
                Calcular = vars =>
                {
                    long g = (long)vars["g"], p = (long)vars["p"];
                    long ab = (long)(vars["a"] * vars["b"]);
                    long result = 1;
                    g %= p;
                    for (long i = 0; i < ab && i < 10000; i++) result = (result * g) % p;
                    return result;
                },
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_crp05", Nome = "Hash — Paradoxo do Aniversário", Categoria = "Criptografia",
                Expressao = "n ≈ √(π/2 · H)  =  1,177 · √H",
                ExprTexto = "nº tentativas p/ colisão 50% ≈ 1,177 × √(2^bits / 2)",
                Icone = "#",
                Descricao = "Nº de hashes necessários para 50% de chance de colisão. SHA-256 (256 bits): ~2^128 hashes. MD5 (128 bits): ~2^64 (inseguro).",
                Criador = "Von Mises (1939); aplicação em criptanálise",
                AnoOrigin = "1939",
                ExemploPratico = "Hash 128 bits: colisão 50% com 2^64 ≈ 1,84×10¹⁹ hashes",
                Variaveis = [
                    new() { Simbolo = "bits", Nome = "Tamanho do hash (bits)", ValorPadrao = 128, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "log₂(n) tentativas",
                Calcular = vars => vars["bits"] / 2.0,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_crp06", Nome = "One-Time Pad (XOR)", Categoria = "Criptografia",
                Expressao = "C = M ⊕ K",
                ExprTexto = "Cifrado = mensagem XOR chave  (bit a bit)",
                Icone = "⊕",
                Descricao = "Cifração perfeitamente segura (Shannon, 1949): chave aleatória, mesmo tamanho que mensagem, usada uma única vez. Impossível quebrar sem a chave.",
                Criador = "Gilbert Vernam (1917); Shannon provou segurança (1949)",
                AnoOrigin = "1917",
                ExemploPratico = "M=01101 (13), K=10110 (22): C = 11011 (27). D: 27 XOR 22 = 13 ✓",
                Variaveis = [
                    new() { Simbolo = "M", Nome = "Mensagem (inteiro)", ValorPadrao = 13, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "K", Nome = "Chave (inteiro)", ValorPadrao = 22, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "C (cifrado)",
                Calcular = vars => (int)vars["M"] ^ (int)vars["K"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_crp07", Nome = "Curva Elíptica (Soma de Pontos)", Categoria = "Criptografia",
                Expressao = "y² = x³ + ax + b  (mod p)",
                ExprTexto = "ECDSA: inclinação λ = (3x₁²+a)/(2y₁) mod p  (duplicação)",
                Icone = "EC",
                Descricao = "Criptografia de curva elíptica (ECC): nível de segurança de RSA-3072 com chave de 256 bits. Base de Bitcoin (secp256k1), TLS moderno.",
                Criador = "Neal Koblitz & Victor Miller (1985)",
                AnoOrigin = "1985",
                ExemploPratico = "secp256k1: y²=x³+7 (a=0, b=7) mod p grande. Chave: 256 bits ≈ RSA-3072.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Coord. x do ponto", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "a", Nome = "Parâmetro a", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "b", Nome = "Parâmetro b", ValorPadrao = 7, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "y² = x³+ax+b",
                Calcular = vars => vars["x"] * vars["x"] * vars["x"] + vars["a"] * vars["x"] + vars["b"],
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ COMPUTAÇÃO GRÁFICA (3 fórmulas) ═══

            new Formula
            {
                Id = "7_cgr01", Nome = "Modelo de Iluminação (Phong)", Categoria = "Computação Gráfica",
                Expressao = "I = ka·Ia + kd·(L·N)·Id + ks·(R·V)^n·Is",
                ExprTexto = "I = ambiente + difusa(L·N) + especular(R·V)ⁿ",
                Icone = "💡",
                Descricao = "Modelo de iluminação de Phong: ambiente + Lambert difuso + reflexão especular. n = brilho especular (5-500). Base de CG desde 1975.",
                Criador = "Bui Tuong Phong (1975)",
                AnoOrigin = "1975",
                ExemploPratico = "ka=0,1, kd=0,7, L·N=0,8, ks=0,2, R·V=0,9, n=32: I = 0,1+0,7×0,8+0,2×0,9^32 = 0,1+0,56+0,007 = 0,667",
                Variaveis = [
                    new() { Simbolo = "ka", Nome = "Coef. ambiente", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "kd", Nome = "Coef. difuso", ValorPadrao = 0.7, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "LN", Nome = "L·N (cos ângulo luz)", ValorPadrao = 0.8, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "ks", Nome = "Coef. especular", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "RV", Nome = "R·V (cos ângulo reflexão)", ValorPadrao = 0.9, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "n", Nome = "Expoente brilho (n)", ValorPadrao = 32, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "I (intensidade)",
                Calcular = vars => vars["ka"] + vars["kd"] * vars["LN"] + vars["ks"] * Math.Pow(vars["RV"], vars["n"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_cgr02", Nome = "Transformação de Escala 2D", Categoria = "Computação Gráfica",
                Expressao = "P' = S · P  →  x'=sx·x, y'=sy·y",
                ExprTexto = "x' = sx × x,  y' = sy × y",
                Icone = "↔",
                Descricao = "Escala de ponto/objeto 2D por fatores sx e sy. Matriz: [[sx,0],[0,sy]]. Escala uniforme: sx=sy. Reflexão: s=-1.",
                Criador = "Álgebra linear; computação gráfica (Séc. XX)",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Ponto (3,4), escala 2×: x'=6, y'=8. Escala 0,5×: x'=1,5, y'=2.",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Coord. x", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "y", Nome = "Coord. y", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "sx", Nome = "Fator escala x", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "x' (coord. escalada)",
                Calcular = vars => vars["sx"] * vars["x"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_cgr03", Nome = "Interpolação Linear (Lerp)", Categoria = "Computação Gráfica",
                Expressao = "lerp(a,b,t) = a + t·(b−a)",
                ExprTexto = "resultado = a + t × (b − a),  t ∈ [0,1]",
                Icone = "→",
                Descricao = "Interpolação linear entre dois valores. t=0 → a, t=1 → b, t=0,5 → ponto médio. Usada em animação, shaders, cores, UI.",
                Criador = "Matemática fundamental; CG desde anos 1960",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "a=100, b=200, t=0,3: lerp = 100+0,3×100 = 130",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Valor inicial (a)", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "b", Nome = "Valor final (b)", ValorPadrao = 200, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "t", Nome = "Parâmetro t (0 a 1)", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "lerp(a,b,t)",
                Calcular = vars => vars["a"] + vars["t"] * (vars["b"] - vars["a"]),
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ BALÍSTICA (2 fórmulas) ═══

            new Formula
            {
                Id = "7_bal01", Nome = "Alcance Máximo (Projétil)", Categoria = "Balística",
                Expressao = "R = v₀² · sin(2θ) / g",
                ExprTexto = "R = v₀² × sen(2θ) / g",
                Icone = "🎯",
                Descricao = "Alcance de projétil no vácuo (sem arrasto). Máximo em θ=45°. Com arrasto, ângulo ótimo é ~30-35°. g=9,81 m/s².",
                Criador = "Galileu (1638); Tartaglia (1537)",
                AnoOrigin = "1638",
                ExemploPratico = "v₀=800 m/s, θ=45°: R = 640000×1/9,81 = 65.240m ≈ 65 km (no vácuo)",
                Variaveis = [
                    new() { Simbolo = "v0", Nome = "Velocidade inicial (m/s)", ValorPadrao = 800, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "theta", Nome = "Ângulo de lançamento (°)", ValorPadrao = 45, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "R (m)",
                UnidadeResultado = "m",
                Calcular = vars => vars["v0"] * vars["v0"] * Math.Sin(2 * vars["theta"] * Math.PI / 180.0) / 9.80665,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_bal02", Nome = "Coeficiente Balístico", Categoria = "Balística",
                Expressao = "BC = m / (Cd · A)",
                ExprTexto = "BC = massa / (coef_arrasto × área_seção)",
                Icone = "BC",
                Descricao = "Medida de capacidade de penetrar no ar. BC alto = menos desaceleração. Típico: 0,2-0,6 para projéteis de rifle. Unidade variável (lbs/in² ou SI).",
                Criador = "Balística exterior; Siacci (1880s)",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "m=10g=0,01kg, Cd=0,3, A=0,000045m² (cal .308): BC = 0,01/(0,3×4,5e-5) = 741 (SI)",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa (kg)", ValorPadrao = 0.01, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Cd", Nome = "Coef. de arrasto", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "A", Nome = "Área seção (m²)", ValorPadrao = 0.000045, ValorMin = 1e-10, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "BC",
                Calcular = vars => vars["m"] / (vars["Cd"] * vars["A"]),
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ TECNOLOGIAS EMERGENTES (10 fórmulas) ═══

            new Formula
            {
                Id = "7_tem01", Nome = "Lei de Moore (Transistores)", Categoria = "Tecnologias Emergentes",
                Expressao = "N(t) = N₀ · 2^(t/T)",
                ExprTexto = "N(t) = N₀ × 2^(anos/período_duplicação)",
                Icone = "🔬",
                Descricao = "Transistores em chip dobram a cada ~2 anos (T≈2). Moore (1965): previsão que se manteve até ~2020. Atual: desaceleração (limites físicos).",
                Criador = "Gordon Moore (1965)",
                AnoOrigin = "1965",
                ExemploPratico = "2010: 1 bilhão, T=2 anos, t=10 anos → N = 1e9×2^5 = 32 bilhões (2020)",
                Variaveis = [
                    new() { Simbolo = "N0", Nome = "Transistores iniciais", ValorPadrao = 1e9, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "t", Nome = "Anos transcorridos", ValorPadrao = 10, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "T", Nome = "Período de duplicação (anos)", ValorPadrao = 2, ValorMin = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "N(t)",
                Calcular = vars => vars["N0"] * Math.Pow(2, vars["t"] / vars["T"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem02", Nome = "Qubit — Estado de Superposição", Categoria = "Tecnologias Emergentes",
                Expressao = "|ψ⟩ = α|0⟩ + β|1⟩,  |α|²+|β|²=1",
                ExprTexto = "P(0) = |α|²,  P(1) = |β|² = 1 − |α|²",
                Icone = "⟨ψ⟩",
                Descricao = "Estado quântico de um qubit: superposição de |0⟩ e |1⟩. Ao medir, colapsa para 0 com prob. |α|² ou 1 com prob. |β|². N qubits: 2^N estados simultâneos.",
                Criador = "Feynman (1982, comp.quântica); Deutsch (1985)",
                AnoOrigin = "1982",
                ExemploPratico = "α=1/√2, β=1/√2: P(0)=0,5, P(1)=0,5 (máx. superposição = Hadamard gate)",
                Variaveis = [
                    new() { Simbolo = "alpha", Nome = "Amplitude α", Descricao = "|α|²+|β|²=1", ValorPadrao = 0.7071, Unidade = "adim" },
                ],
                VariavelResultado = "P(|0⟩)",
                Calcular = vars => vars["alpha"] * vars["alpha"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem03", Nome = "Latência 5G (URLLC)", Categoria = "Tecnologias Emergentes",
                Expressao = "Latência_total = Latência_ar + Latência_processamento + Latência_backhaul",
                ExprTexto = "Latência = ar + processamento + backhaul (ms)",
                Icone = "5G",
                Descricao = "Latência end-to-end 5G URLLC: alvo <1 ms no ar. eMBB: <10ms. 4G: 30-50ms. Essencial para cirurgia remota, veículos autônomos.",
                Criador = "3GPP Release 15-17 (2018-2022)",
                AnoOrigin = "2018",
                ExemploPratico = "URLLC: ar=0,5ms, proc.=0,3ms, backhaul=0,2ms → 1,0 ms total",
                Variaveis = [
                    new() { Simbolo = "Lar", Nome = "Latência do ar (ms)", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Lproc", Nome = "Latência processamento (ms)", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Lback", Nome = "Latência backhaul (ms)", ValorPadrao = 0.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Latência total (ms)",
                UnidadeResultado = "ms",
                Calcular = vars => vars["Lar"] + vars["Lproc"] + vars["Lback"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem04", Nome = "Eficiência do Painel Solar", Categoria = "Tecnologias Emergentes",
                Expressao = "η = P_saída / (G · A) × 100",
                ExprTexto = "eficiência(%) = potência_saída / (irradiância × área) × 100",
                Icone = "☀",
                Descricao = "Eficiência de conversão fotovoltaica. Silício mono: 20-24%, multi-junção: >47%. G = irradiância solar (STC: 1000 W/m²).",
                Criador = "Bell Labs (1954, primeira célula prática)",
                AnoOrigin = "1954",
                ExemploPratico = "Painel 400W, área 2m², G=1000 W/m²: η = 400/(1000×2)×100 = 20%",
                Variaveis = [
                    new() { Simbolo = "P", Nome = "Potência saída (W)", ValorPadrao = 400, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "G", Nome = "Irradiância (W/m²)", ValorPadrao = 1000, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "A", Nome = "Área do painel (m²)", ValorPadrao = 2, ValorMin = 0.01, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "η (%)",
                UnidadeResultado = "%",
                Calcular = vars => vars["P"] / (vars["G"] * vars["A"]) * 100.0,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem05", Nome = "Capacidade da Bateria (kWh)", Categoria = "Tecnologias Emergentes",
                Expressao = "E = V · Ah / 1000",
                ExprTexto = "kWh = Tensão(V) × Capacidade(Ah) / 1000",
                Icone = "🔋",
                Descricao = "Energia armazenada em bateria. EV típico: 50-100 kWh. Li-ion: 250-300 Wh/kg. Estado sólido promete >400 Wh/kg.",
                Criador = "Eletroquímica; Goodenough/Whittingham/Yoshino (Nobel 2019)",
                AnoOrigin = "1991",
                ExemploPratico = "Tesla Model 3: 400V × 200Ah = 80.000 Wh = 80 kWh",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "Tensão (V)", ValorPadrao = 400, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Ah", Nome = "Capacidade (Ah)", ValorPadrao = 200, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "E (kWh)",
                UnidadeResultado = "kWh",
                Calcular = vars => vars["V"] * vars["Ah"] / 1000.0,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem06", Nome = "Blockchain — Hash Rate e Dificuldade", Categoria = "Tecnologias Emergentes",
                Expressao = "Tempo_bloco ≈ D · 2³² / HashRate",
                ExprTexto = "Tempo médio(s) = Dificuldade × 2³² / HashRate(H/s)",
                Icone = "⛓",
                Descricao = "Tempo médio para minerar bloco Bitcoin. D ajustado a cada 2016 blocos para manter ~10 min. Hash rate da rede: ~500 EH/s (2024).",
                Criador = "Satoshi Nakamoto (2008); protocolo Bitcoin",
                AnoOrigin = "2008",
                ExemploPratico = "D=1 (mínimo), HashRate=10 GH/s: T = 1×4,29e9/1e10 = 0,43s por bloco",
                Variaveis = [
                    new() { Simbolo = "D", Nome = "Dificuldade", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "HR", Nome = "Hash Rate (H/s)", ValorPadrao = 1e10, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Tempo (s)",
                UnidadeResultado = "s",
                Calcular = vars => vars["D"] * Math.Pow(2, 32) / vars["HR"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem07", Nome = "Impressão 3D — Tempo de Impressão", Categoria = "Tecnologias Emergentes",
                Expressao = "T = V_material / (v_extrusão · A_camada)",
                ExprTexto = "Tempo = volume / (velocidade × área_seção_nozzle)",
                Icone = "🖨",
                Descricao = "Estimativa de tempo FDM. Volume total do modelo / taxa volumétrica de extrusão. Adicionar ~20% para deslocamentos e retrações.",
                Criador = "Chuck Hull (1984, SLA); Scott Crump (1989, FDM)",
                AnoOrigin = "1989",
                ExemploPratico = "Peça 50 cm³, nozzle 0,4mm, camada 0,2mm → A=0,08mm², v=60mm/s → T= 50000/4,8 = 10417s ≈ 2,9h",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "Volume do modelo (mm³)", ValorPadrao = 50000, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "v", Nome = "Velocidade extrusão (mm/s)", ValorPadrao = 60, ValorMin = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "A", Nome = "Área seção camada (mm²)", ValorPadrao = 0.08, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Tempo (s)",
                UnidadeResultado = "s",
                Calcular = vars => vars["V"] / (vars["v"] * vars["A"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem08", Nome = "Autonomia de Drone", Categoria = "Tecnologias Emergentes",
                Expressao = "T_voo = E_bateria / P_consumo × 60",
                ExprTexto = "Tempo voo (min) = Energia_bateria(Wh) / Potência(W) × 60",
                Icone = "🚁",
                Descricao = "Tempo de voo hover de multirotor. Consumo típico: 150-300W para drones médios. DJI Mini 3: ~100W, 38min. Peso extra reduz autonomia.",
                Criador = "Engenharia de drones; séc. XXI",
                AnoOrigin = "Séc. XXI",
                ExemploPratico = "Bateria 77 Wh, consumo 150W: T = 77/150×60 = 30,8 min",
                Variaveis = [
                    new() { Simbolo = "E", Nome = "Energia da bateria (Wh)", ValorPadrao = 77, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "P", Nome = "Potência consumida (W)", ValorPadrao = 150, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Tempo de voo (min)",
                UnidadeResultado = "min",
                Calcular = vars => vars["E"] / vars["P"] * 60.0,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem09", Nome = "Limite de Betz (Turbina Eólica)", Categoria = "Tecnologias Emergentes",
                Expressao = "P_max = (16/27) · ½ρAv³",
                ExprTexto = "Pmáx = 0,593 × ½ × ρ × A × v³  (Betz)",
                Icone = "💨",
                Descricao = "Máxima potência extraível do vento: 59,3% (limite de Betz). A = πr² do rotor. Turbinas modernas: 45-50% de eficiência real.",
                Criador = "Albert Betz (1919)",
                AnoOrigin = "1919",
                ExemploPratico = "ρ=1,225 kg/m³, r=50m (A=7854m²), v=12 m/s: P = 0,593×0,5×1,225×7854×1728 = 4,95 MW",
                Variaveis = [
                    new() { Simbolo = "rho", Nome = "Densidade do ar (kg/m³)", ValorPadrao = 1.225, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "A", Nome = "Área do rotor (m²)", ValorPadrao = 7854, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "v", Nome = "Velocidade do vento (m/s)", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "P_max (W)",
                UnidadeResultado = "W",
                Calcular = vars => (16.0 / 27.0) * 0.5 * vars["rho"] * vars["A"] * vars["v"] * vars["v"] * vars["v"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tem10", Nome = "CRISPR — Eficiência de Edição", Categoria = "Tecnologias Emergentes",
                Expressao = "Eficiência(%) = (Células_editadas / Total_células) × 100",
                ExprTexto = "Eficiência = editadas / total × 100 (%)",
                Icone = "🧬",
                Descricao = "Taxa de edição gênica com CRISPR-Cas9. Varia 10-90% conforme alvo, delivery method e tipo celular. HDR (inserção): 5-50%, NHEJ (knockout): 20-90%.",
                Criador = "Doudna & Charpentier (2012, Nobel 2020)",
                AnoOrigin = "2012",
                ExemploPratico = "Editadas: 7000, Total: 10000 → Eficiência = 70% (alta, NHEJ)",
                Variaveis = [
                    new() { Simbolo = "Ed", Nome = "Células editadas", ValorPadrao = 7000, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "N", Nome = "Total de células", ValorPadrao = 10000, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Eficiência (%)",
                UnidadeResultado = "%",
                Calcular = vars => vars["Ed"] / vars["N"] * 100.0,
                SubCategoria = "",
                Unidades = "",
            },
        ]);
    }
}
