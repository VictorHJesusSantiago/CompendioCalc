using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 7 — PARTE VIII + IX: ARTES, OFÍCIOS, JOGOS & FOTOGRAFIA (30 fórmulas)
    // ═══════════════════════════════════════════════════════════════

    private void AdicionarVol7Artesanato()
    {
        _formulas.AddRange([
            // ═══ ARTESANATO E OFÍCIOS (16 fórmulas) ═══

            // --- Corte e Costura ---
            new Formula
            {
                Id = "7_art01", Nome = "Comprimento de Tecido para Saia Godê", Categoria = "Artesanato e Ofícios",
                Expressao = "L = 2π · (R + comprimento)",
                ExprTexto = "L = 2π × (R + comp_saia)  onde R = cintura/(2π)",
                Icone = "✂",
                Descricao = "Perímetro do arco externo da saia godê completa (360°). R = raio do círculo da cintura = cintura/(2π). L = comprimento do tecido na barra.",
                Criador = "Modelagem de moda; geometria aplicada",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Cintura 70cm, comprimento 60cm: R=70/(2π)=11,14cm, L=2π×(11,14+60)=447 cm",
                Variaveis = [
                    new() { Simbolo = "cintura", Nome = "Medida da cintura (cm)", ValorPadrao = 70, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "comp", Nome = "Comprimento da saia (cm)", ValorPadrao = 60, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "L (perímetro barra, cm)",
                UnidadeResultado = "cm",
                Calcular = vars =>
                {
                    double r = vars["cintura"] / (2 * Math.PI);
                    return 2 * Math.PI * (r + vars["comp"]);
                },
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_art02", Nome = "Margem de Costura", Categoria = "Artesanato e Ofícios",
                Expressao = "A_tecido = (L + 2m) · (W + 2m)",
                ExprTexto = "Área total = (comprimento + 2×margem) × (largura + 2×margem)",
                Icone = "📐",
                Descricao = "Área total de tecido incluindo margens de costura (m). Margem padrão: 1-1,5 cm para roupas, 2-3 cm para bainhas.",
                Criador = "Técnica de modelagem industrial",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "Peça 50×30cm, margem 1,5cm: A = (50+3)×(30+3) = 53×33 = 1749 cm²",
                Variaveis = [
                    new() { Simbolo = "L", Nome = "Comprimento da peça (cm)", ValorPadrao = 50, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "W", Nome = "Largura da peça (cm)", ValorPadrao = 30, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "m", Nome = "Margem de costura (cm)", ValorPadrao = 1.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Área total (cm²)",
                UnidadeResultado = "cm²",
                Calcular = vars => (vars["L"] + 2 * vars["m"]) * (vars["W"] + 2 * vars["m"]),
                SubCategoria = "",
                Unidades = "",
            },

            // --- Marcenaria ---
            new Formula
            {
                Id = "7_art03", Nome = "Volume de Madeira (Tábuas)", Categoria = "Artesanato e Ofícios",
                Expressao = "V = C · L · E",
                ExprTexto = "V = comprimento × largura × espessura",
                Icone = "🪵",
                Descricao = "Volume de tábua ou peça retangular. Unidades em metros para obter m³. 1 m³ ≈ 424 board feet. Base para orçamento de madeira.",
                Criador = "Carpintaria tradicional",
                AnoOrigin = "Milenar",
                ExemploPratico = "Tábua: 2,5m × 0,3m × 0,025m = 0,01875 m³",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "Comprimento (m)", ValorPadrao = 2.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "L", Nome = "Largura (m)", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "E", Nome = "Espessura (m)", ValorPadrao = 0.025, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Volume (m³)",
                UnidadeResultado = "m³",
                Calcular = vars => vars["C"] * vars["L"] * vars["E"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_art04", Nome = "Ângulo de Junta (Meia-Esquadria)", Categoria = "Artesanato e Ofícios",
                Expressao = "α = 180° / n",
                ExprTexto = "α = 180° / n  (n = número de lados)",
                Icone = "📦",
                Descricao = "Ângulo de corte para juntas de meia-esquadria em polígonos regulares. Caixa quadrada: α=45°, hexagonal: α=30°, octogonal: α=22,5°.",
                Criador = "Geometria aplicada à marcenaria",
                AnoOrigin = "Milenar",
                ExemploPratico = "Moldura octogonal (n=8): α = 180/8 = 22,5° em cada ponta",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Número de lados", ValorPadrao = 8, ValorMin = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "α (graus)",
                UnidadeResultado = "°",
                Calcular = vars => 180.0 / vars["n"],
                SubCategoria = "",
                Unidades = "",
            },

            // --- Cerâmica ---
            new Formula
            {
                Id = "7_art05", Nome = "Retração da Argila (%)", Categoria = "Artesanato e Ofícios",
                Expressao = "%ret = (L_úmido − L_seco) / L_úmido × 100",
                ExprTexto = "% retração = (Lúmido − Lqueimado) / Lúmido × 100",
                Icone = "🏺",
                Descricao = "Retração total da argila (úmido→queimado): 10-15% típico. Essencial para dimensionar peças antes da secagem e queima.",
                Criador = "Cerâmica tradicional; tecnologia cerâmica",
                AnoOrigin = "Milenar",
                ExemploPratico = "L úmido=20cm, L queimado=17cm: retração = (20−17)/20 × 100 = 15%",
                Variaveis = [
                    new() { Simbolo = "Lu", Nome = "Dimensão úmida (cm)", ValorPadrao = 20, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Ls", Nome = "Dimensão após queima (cm)", ValorPadrao = 17, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Retração (%)",
                UnidadeResultado = "%",
                Calcular = vars => (vars["Lu"] - vars["Ls"]) / vars["Lu"] * 100.0,
                SubCategoria = "",
                Unidades = "",
            },

            // --- Culinária ---
            new Formula
            {
                Id = "7_art06", Nome = "Escalonamento de Receita", Categoria = "Artesanato e Ofícios",
                Expressao = "Q_novo = Q_orig · (P_desejado / P_original)",
                ExprTexto = "ingrediente novo = ingrediente original × (porções desejadas / porções originais)",
                Icone = "🍰",
                Descricao = "Regra de três para escalonar receitas. Funciona para ingredientes secos e líquidos. Cuidado com fermentos (não escala linearmente acima de 3×).",
                Criador = "Aritmética culinária básica",
                AnoOrigin = "Milenar",
                ExemploPratico = "Receita p/6: 300g farinha. Para 15: Q = 300×(15/6) = 750g",
                Variaveis = [
                    new() { Simbolo = "Q", Nome = "Quantidade original", ValorPadrao = 300, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Pd", Nome = "Porções desejadas", ValorPadrao = 15, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Po", Nome = "Porções originais", ValorPadrao = 6, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Quantidade ajustada",
                Calcular = vars => vars["Q"] * (vars["Pd"] / vars["Po"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_art07", Nome = "Conversão Celsius → Fahrenheit", Categoria = "Artesanato e Ofícios",
                Expressao = "°F = °C × 9/5 + 32",
                ExprTexto = "°F = °C × 9/5 + 32",
                Icone = "🌡",
                Descricao = "Conversão de temperatura para receitas internacionais. 180°C ≈ 356°F (forno médio). Pontos notáveis: 0°C=32°F, 100°C=212°F.",
                Criador = "Daniel Fahrenheit (1724) / Anders Celsius (1742)",
                AnoOrigin = "1742",
                ExemploPratico = "Forno a 180°C: °F = 180×1,8+32 = 356°F",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "Temperatura (°C)", ValorPadrao = 180, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "°F",
                UnidadeResultado = "°F",
                Calcular = vars => vars["C"] * 9.0 / 5.0 + 32,
                SubCategoria = "",
                Unidades = "",
            },

            // --- Jardinagem ---
            new Formula
            {
                Id = "7_art08", Nome = "Volume de Substrato (Canteiro)", Categoria = "Artesanato e Ofícios",
                Expressao = "V = C · L · H",
                ExprTexto = "V = comprimento × largura × altura (m³)",
                Icone = "🌱",
                Descricao = "Volume de terra/substrato para canteiro retangular. 1 m³ ≈ 1000 litros. Densidade média do substrato: 400-600 kg/m³.",
                Criador = "Horticultura prática",
                AnoOrigin = "Milenar",
                ExemploPratico = "Canteiro 3m × 1,2m × 0,3m = 1,08 m³ ≈ 1080 litros de substrato",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "Comprimento (m)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "L", Nome = "Largura (m)", ValorPadrao = 1.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "H", Nome = "Altura/profundidade (m)", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Volume (m³)",
                UnidadeResultado = "m³",
                Calcular = vars => vars["C"] * vars["L"] * vars["H"],
                SubCategoria = "",
                Unidades = "",
            },

            // --- Pintura ---
            new Formula
            {
                Id = "7_art09", Nome = "Rendimento de Tinta", Categoria = "Artesanato e Ofícios",
                Expressao = "V_tinta = Área / Rendimento × nDemãos",
                ExprTexto = "Litros = (área / rendimento) × nº demãos",
                Icone = "🎨",
                Descricao = "Cálculo de tinta necessária. Rendimento típico: 8-12 m²/L por demão (parede lisa). Mínimo 2 demãos para cobertura uniforme.",
                Criador = "Pintura imobiliária / artesanal",
                AnoOrigin = "Prática",
                ExemploPratico = "Parede 12 m², rendimento 10 m²/L, 2 demãos: V = (12/10)×2 = 2,4 L",
                Variaveis = [
                    new() { Simbolo = "A", Nome = "Área a pintar (m²)", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "R", Nome = "Rendimento (m²/L)", ValorPadrao = 10, ValorMin = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "n", Nome = "Nº de demãos", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Volume de tinta (L)",
                UnidadeResultado = "L",
                Calcular = vars => (vars["A"] / vars["R"]) * vars["n"],
                SubCategoria = "",
                Unidades = "",
            },

            // --- Tricô e Crochê ---
            new Formula
            {
                Id = "7_art10", Nome = "Amostra de Tricô (Gauge)", Categoria = "Artesanato e Ofícios",
                Expressao = "pontos = (largura_desejada / largura_amostra) × pontos_amostra",
                ExprTexto = "pontos necessários = (largura_desejada / largura_amostra) × pontos_amostra",
                Icone = "🧶",
                Descricao = "Cálculo do número de pontos para a peça desejada baseado na amostra (gauge swatch). Amostra padrão: 10×10 cm. Essencial para ajuste de tamanho.",
                Criador = "Técnica de tricô/crochê tradicional",
                AnoOrigin = "Milenar",
                ExemploPratico = "Amostra: 22 pontos em 10 cm. Peça de 50 cm: pontos = (50/10)×22 = 110",
                Variaveis = [
                    new() { Simbolo = "Ld", Nome = "Largura desejada (cm)", ValorPadrao = 50, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "La", Nome = "Largura da amostra (cm)", ValorPadrao = 10, ValorMin = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Pa", Nome = "Pontos na amostra", ValorPadrao = 22, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Pontos necessários",
                Calcular = vars => (vars["Ld"] / vars["La"]) * vars["Pa"],
                SubCategoria = "",
                Unidades = "",
            },

            // --- Saboaria ---
            new Formula
            {
                Id = "7_art11", Nome = "Índice de Saponificação (NaOH)", Categoria = "Artesanato e Ofícios",
                Expressao = "NaOH(g) = Peso_óleo(g) × IS × (1 − %superf)",
                ExprTexto = "NaOH = óleo(g) × índice_saponificação × (1 − superfat)",
                Icone = "🧼",
                Descricao = "Quantidade de NaOH para saponificação. IS varia por óleo: oliva=0,1345, coco=0,1780, palma=0,1410. Superfat 5-8% para hidratação.",
                Criador = "Química de saponificação; tabelas da indústria",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "500g oliva, IS=0,1345, superfat 5%: NaOH = 500×0,1345×0,95 = 63,9g",
                Variaveis = [
                    new() { Simbolo = "W", Nome = "Peso do óleo (g)", ValorPadrao = 500, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "IS", Nome = "Índice saponificação NaOH", ValorPadrao = 0.1345, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "sf", Nome = "Superfat (0-0,1)", Descricao = "Ex: 0,05 p/ 5%", ValorPadrao = 0.05, Unidade = "adim" },
                ],
                VariavelResultado = "NaOH (g)",
                UnidadeResultado = "g",
                Calcular = vars => vars["W"] * vars["IS"] * (1 - vars["sf"]),
                SubCategoria = "",
                Unidades = "",
            },

            // --- Joalheria ---
            new Formula
            {
                Id = "7_art12", Nome = "Comprimento de Fio para Anel", Categoria = "Artesanato e Ofícios",
                Expressao = "L = π · (d_dedo + 2·e_metal)",
                ExprTexto = "L = π × (diâmetro_dedo + 2 × espessura)",
                Icone = "💍",
                Descricao = "Comprimento de fio/chapa para confeccionar anel. d_dedo obtido pela tabela: aro 16 ≈ 16,5mm. Margem para soldagem.",
                Criador = "Ourivesaria tradicional",
                AnoOrigin = "Milenar",
                ExemploPratico = "Dedo: d=16,5mm, espessura 1mm: L = π×(16,5+2) = 58,1 mm",
                Variaveis = [
                    new() { Simbolo = "d", Nome = "Diâmetro do dedo (mm)", ValorPadrao = 16.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "e", Nome = "Espessura do metal (mm)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "L (mm)",
                UnidadeResultado = "mm",
                Calcular = vars => Math.PI * (vars["d"] + 2 * vars["e"]),
                SubCategoria = "",
                Unidades = "",
            },

            // --- Encadernação ---
            new Formula
            {
                Id = "7_art13", Nome = "Espessura da Lombada (Livro)", Categoria = "Artesanato e Ofícios",
                Expressao = "E_lomb = n_folhas × e_folha + 2·e_capa",
                ExprTexto = "Lombada = nº folhas × espessura folha + 2 × espessura capa",
                Icone = "📖",
                Descricao = "Dimensão da lombada para encadernação. Papel 75g/m²: ~0,1mm/folha. Papel 120g: ~0,16mm. Capa dura: ~2-3mm.",
                Criador = "Encadernação artesanal",
                AnoOrigin = "Séc. XV (Gutenberg)",
                ExemploPratico = "200 folhas × 0,1mm + 2×2mm = 20+4 = 24 mm de lombada",
                Variaveis = [
                    new() { Simbolo = "nf", Nome = "Nº de folhas", ValorPadrao = 200, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "ef", Nome = "Espessura da folha (mm)", ValorPadrao = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "ec", Nome = "Espessura da capa (mm)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Lombada (mm)",
                UnidadeResultado = "mm",
                Calcular = vars => vars["nf"] * vars["ef"] + 2 * vars["ec"],
                SubCategoria = "",
                Unidades = "",
            },

            // --- Vidraria ---
            new Formula
            {
                Id = "7_art14", Nome = "Coeficiente de Expansão Térmica (Vidro)", Categoria = "Artesanato e Ofícios",
                Expressao = "ΔL = L₀ · α · ΔT",
                ExprTexto = "ΔL = comprimento × coef.expansão × variação temperatura",
                Icone = "🔥",
                Descricao = "Variação de comprimento por aquecimento. Vidro borossilicato: α≈3,3×10⁻⁶/°C, sodocálcico: α≈8,5×10⁻⁶/°C. Choque térmico: quando ΔL excessivo causa fratura.",
                Criador = "Física dos materiais; vidraria artesanal",
                AnoOrigin = "Séc. XVIII",
                ExemploPratico = "Vidro 30cm, α=8,5e-6, ΔT=500°C: ΔL = 0,3×8,5e-6×500 = 0,00128m = 1,28mm",
                Variaveis = [
                    new() { Simbolo = "L0", Nome = "Comprimento original (m)", ValorPadrao = 0.3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "alpha", Nome = "Coef. expansão (1/°C)", ValorPadrao = 8.5e-6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "dT", Nome = "Variação temperatura (°C)", ValorPadrao = 500, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "ΔL (m)",
                UnidadeResultado = "m",
                Calcular = vars => vars["L0"] * vars["alpha"] * vars["dT"],
                SubCategoria = "",
                Unidades = "",
            },

            // --- Tecelagem ---
            new Formula
            {
                Id = "7_art15", Nome = "Cálculo de Urdidura (Tecelagem)", Categoria = "Artesanato e Ofícios",
                Expressao = "Total_fios = Largura(cm) × DPI + 2·ourela",
                ExprTexto = "Fios totais = largura × fios_por_cm + ourelas",
                Icone = "🧵",
                Descricao = "Nº total de fios de urdidura. DPI (density per inch/cm) depende do fio e pente. Algodão médio: 6-8 fios/cm. Ourela: 4-8 fios extras cada lado.",
                Criador = "Tecelagem artesanal milenar",
                AnoOrigin = "Milenar",
                ExemploPratico = "Tecido 50cm, 8 fios/cm, ourela 6 fios cada: Total = 50×8 + 2×6 = 412 fios",
                Variaveis = [
                    new() { Simbolo = "W", Nome = "Largura do tecido (cm)", ValorPadrao = 50, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "DPI", Nome = "Fios por cm", ValorPadrao = 8, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "ourela", Nome = "Fios de ourela (cada lado)", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Total de fios",
                Calcular = vars => vars["W"] * vars["DPI"] + 2 * vars["ourela"],
                SubCategoria = "",
                Unidades = "",
            },

            // --- Origami ---
            new Formula
            {
                Id = "7_art16", Nome = "Lado Mínimo (Origami Modular)", Categoria = "Artesanato e Ofícios",
                Expressao = "L_base = L_final × 2^dobras",
                ExprTexto = "Lado papel = tamanho final × 2^nº_dobras",
                Icone = "🦢",
                Descricao = "Estimativa do tamanho de papel necessário. Cada dobra reduz dimensão. Tsuru: ~6 dobras → papel 64× o detalhe mais fino.",
                Criador = "Origami japonês; Robert Lang (matemática do origami)",
                AnoOrigin = "Séc. XVII",
                ExemploPratico = "Detalhe final 0,5cm, 6 dobras: L = 0,5×2⁶ = 32 cm de papel",
                Variaveis = [
                    new() { Simbolo = "Lf", Nome = "Tamanho final (cm)", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "d", Nome = "Nº de dobras", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "L papel (cm)",
                UnidadeResultado = "cm",
                Calcular = vars => vars["Lf"] * Math.Pow(2, vars["d"]),
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ JOGOS E RECREAÇÃO (10 fórmulas) ═══

            new Formula
            {
                Id = "7_jog01", Nome = "Probabilidade de Dado Justo", Categoria = "Jogos e Recreação",
                Expressao = "P = casos_favoráveis / casos_possíveis",
                ExprTexto = "P = favoráveis / total",
                Icone = "🎲",
                Descricao = "Probabilidade clássica (equiprovável). 1d6: P(6)=1/6. 2d6: P(7)=6/36=1/6 (mais provável). Base de RPG, jogos de tabuleiro.",
                Criador = "Pascal & Fermat (1654); Laplace (prob. clássica)",
                AnoOrigin = "1654",
                ExemploPratico = "2d6, soma=7: 6 combinações em 36 → P = 6/36 = 0,167 (16,7%)",
                Variaveis = [
                    new() { Simbolo = "fav", Nome = "Casos favoráveis", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "total", Nome = "Casos possíveis", ValorPadrao = 36, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "P",
                Calcular = vars => vars["fav"] / vars["total"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog02", Nome = "Valor Esperado (Aposta)", Categoria = "Jogos e Recreação",
                Expressao = "EV = P_ganho · Ganho + P_perda · (−Perda)",
                ExprTexto = "EV = P(ganho) × ganho − P(perda) × perda",
                Icone = "EV",
                Descricao = "Valor esperado de aposta. EV>0: favorável ao jogador. EV<0: vantagem da casa. Cassinos: EV sempre negativo para o jogador.",
                Criador = "Teoria da probabilidade; Huygens (1657)",
                AnoOrigin = "1657",
                ExemploPratico = "Roleta (vermelho): P=18/38, ganho=1, perda=1: EV = 0,474×1−0,526×1 = −0,053 (−5,3% casa)",
                Variaveis = [
                    new() { Simbolo = "Pg", Nome = "P(ganho)", ValorPadrao = 0.474, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "G", Nome = "Ganho ($)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Pp", Nome = "P(perda)", ValorPadrao = 0.526, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "L", Nome = "Perda ($)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "EV ($)",
                Calcular = vars => vars["Pg"] * vars["G"] - vars["Pp"] * vars["L"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog03", Nome = "Rating Elo (Xadrez)", Categoria = "Jogos e Recreação",
                Expressao = "R_novo = R + K · (S − E)",
                ExprTexto = "Rnovo = Ratual + K × (resultado − esperado)",
                Icone = "♟",
                Descricao = "Sistema de classificação Elo: E = 1/(1+10^((Rb−Ra)/400)). S = resultado (1=vitória, 0,5=empate, 0=derrota). K=20-40 (novatos), 10-16 (mestres).",
                Criador = "Arpad Elo (1960); FIDE (xadrez)",
                AnoOrigin = "1960",
                ExemploPratico = "Ra=1500, Rb=1700, K=20, vitória(S=1): E=1/(1+10^(200/400))=0,24 → Rnovo = 1500+20×0,76 = 1515",
                Variaveis = [
                    new() { Simbolo = "R", Nome = "Rating atual", ValorPadrao = 1500, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "K", Nome = "Fator K", ValorPadrao = 20, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "S", Nome = "Resultado (0, 0.5, 1)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "E", Nome = "Resultado esperado", Descricao = "E = 1/(1+10^((Rb-Ra)/400))", ValorPadrao = 0.24, Unidade = "adim" },
                ],
                VariavelResultado = "R_novo",
                Calcular = vars => vars["R"] + vars["K"] * (vars["S"] - vars["E"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog04", Nome = "Combinações (Loterias)", Categoria = "Jogos e Recreação",
                Expressao = "C(n,k) = n! / (k!(n−k)!)",
                ExprTexto = "C(n,k) = n! / (k! × (n−k)!)",
                Icone = "🎰",
                Descricao = "Número de combinações possíveis. Mega-Sena: C(60,6) = 50.063.860. Quanto maior, menor a probabilidade de acertar.",
                Criador = "Pascal (triângulo, 1654); combinatória",
                AnoOrigin = "1654",
                ExemploPratico = "Mega-Sena: C(60,6) = 50.063.860 → P(acerto) ≈ 1 em 50 milhões",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Total de números", ValorPadrao = 60, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "k", Nome = "Números escolhidos", ValorPadrao = 6, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "C(n,k)",
                Calcular = vars =>
                {
                    int n = (int)vars["n"], k = (int)vars["k"];
                    if (k > n) return 0;
                    if (k > n - k) k = n - k;
                    double r = 1;
                    for (int i = 0; i < k; i++) r = r * (n - i) / (i + 1);
                    return r;
                },
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog05", Nome = "Distância de Dardo ao Alvo", Categoria = "Jogos e Recreação",
                Expressao = "d = √((x−x₀)² + (y−y₀)²)",
                ExprTexto = "d = √((x−x₀)² + (y−y₀)²)  (centro = (0,0))",
                Icone = "🎯",
                Descricao = "Distância euclidiana do ponto de impacto ao centro do alvo. Bull's eye: d < 6,35mm. Triple-20: anel a 99-107mm.",
                Criador = "Geometria euclidiana; regras de dardos (BDO/PDC)",
                AnoOrigin = "Milenar",
                ExemploPratico = "Impacto em (30, 40)mm: d = √(900+1600) = 50 mm do centro",
                Variaveis = [
                    new() { Simbolo = "x", Nome = "Coord. x do impacto (mm)", ValorPadrao = 30, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "y", Nome = "Coord. y do impacto (mm)", ValorPadrao = 40, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "d (mm)",
                UnidadeResultado = "mm",
                Calcular = vars => Math.Sqrt(vars["x"] * vars["x"] + vars["y"] * vars["y"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog06", Nome = "Velocidade do Projétil (Paintball/Airsoft)", Categoria = "Jogos e Recreação",
                Expressao = "E_cin = ½ · m · v²",
                ExprTexto = "E = ½ × massa × velocidade²  (em Joules)",
                Icone = "💥",
                Descricao = "Energia cinética de projétil recreacional. Airsoft: <1,2J (regulamento). Paintball: ~12,5J (300fps, 3g). v usado para regulação de segurança.",
                Criador = "Mecânica newtoniana; regulamentos esportivos",
                AnoOrigin = "Séc. XVII",
                ExemploPratico = "Airsoft: m=0,20g=0,0002kg, v=100m/s: E = 0,5×0,0002×10000 = 1,0 J (dentro do limite)",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa (kg)", ValorPadrao = 0.0002, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "v", Nome = "Velocidade (m/s)", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "E (Joules)",
                UnidadeResultado = "J",
                Calcular = vars => 0.5 * vars["m"] * vars["v"] * vars["v"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog07", Nome = "Handicap de Golfe (Diferencial)", Categoria = "Jogos e Recreação",
                Expressao = "Diferencial = (Score − Rating) × 113 / Slope",
                ExprTexto = "Diferencial = (score − course_rating) × 113 / slope_rating",
                Icone = "⛳",
                Descricao = "Diferencial de handicap USGA. Course rating: dificuldade do campo. Slope: 55-155 (113=neutro). 8 melhores de 20 últimos diferenciais.",
                Criador = "USGA (United States Golf Association)",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Score=85, rating=72, slope=130: Dif = (85−72)×113/130 = 11,3",
                Variaveis = [
                    new() { Simbolo = "S", Nome = "Score (tacadas)", ValorPadrao = 85, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "CR", Nome = "Course Rating", ValorPadrao = 72, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "SR", Nome = "Slope Rating", ValorPadrao = 130, ValorMin = 55, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Diferencial",
                Calcular = vars => (vars["S"] - vars["CR"]) * 113.0 / vars["SR"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog08", Nome = "Partida de Pontos (Bridge/Rummy)", Categoria = "Jogos e Recreação",
                Expressao = "Score_final = Σbaralhos_pontos − penalidades",
                ExprTexto = "Score = pontos_positivos − pontos_restantes_mão",
                Icone = "🃏",
                Descricao = "Pontuação final simples: soma das cartas baixadas menos cartas restantes. Aplicável a Rummy, Canastra, Buraco. Variantes com multiplicadores.",
                Criador = "Jogos de cartas tradicionais",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "Baixados: 150 pts, restante mão: 35 pts: Score = 150 − 35 = 115",
                Variaveis = [
                    new() { Simbolo = "Pos", Nome = "Pontos baixados", ValorPadrao = 150, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Neg", Nome = "Pontos restantes (mão)", ValorPadrao = 35, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Score final",
                Calcular = vars => vars["Pos"] - vars["Neg"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog09", Nome = "Tempo de Puzzles (Speedcubing)", Categoria = "Jogos e Recreação",
                Expressao = "Média_5 = (Σ5 − max − min) / 3",
                ExprTexto = "Average of 5 (Ao5) = (soma5 − melhor − pior) / 3",
                Icone = "🟨",
                Descricao = "Média oficial WCA (Average of 5): descarta melhor e pior tempo, média dos 3 restantes. Recordes: sub-5s (3×3×3).",
                Criador = "WCA (World Cube Association)",
                AnoOrigin = "2003",
                ExemploPratico = "Tempos: 8,2 / 7,5 / 9,1 / 8,8 / 7,9 → descarta 7,5 e 9,1 → Ao5 = (8,2+8,8+7,9)/3 = 8,30s",
                Variaveis = [
                    new() { Simbolo = "t1", Nome = "Tempo 1 (s)", ValorPadrao = 8.2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "t2", Nome = "Tempo 2 (s)", ValorPadrao = 7.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "t3", Nome = "Tempo 3 (s)", ValorPadrao = 9.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "t4", Nome = "Tempo 4 (s)", ValorPadrao = 8.8, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "t5", Nome = "Tempo 5 (s)", ValorPadrao = 7.9, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Ao5 (s)",
                UnidadeResultado = "s",
                Calcular = vars =>
                {
                    double[] t = [vars["t1"], vars["t2"], vars["t3"], vars["t4"], vars["t5"]];
                    Array.Sort(t);
                    return (t[1] + t[2] + t[3]) / 3.0;
                },
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_jog10", Nome = "Rating Glicko (Intervalo de Confiança)", Categoria = "Jogos e Recreação",
                Expressao = "Intervalo = R ± 2·RD",
                ExprTexto = "Intervalo 95% = Rating ± 2 × RD",
                Icone = "📊",
                Descricao = "Sistema Glicko (Mark Glickman): melhoria do Elo com incerteza (RD). RD baixo = rating confiável. RD aumenta com inatividade.",
                Criador = "Mark Glickman (1995)",
                AnoOrigin = "1995",
                ExemploPratico = "R=1500, RD=100: intervalo 95% = [1300, 1700]. Após 30 jogos, RD pode cair para 50 → [1400, 1600]",
                Variaveis = [
                    new() { Simbolo = "R", Nome = "Rating", ValorPadrao = 1500, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "RD", Nome = "Rating Deviation", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Limite superior",
                Calcular = vars => vars["R"] + 2 * vars["RD"],
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ FOTOGRAFIA (4 fórmulas) ═══

            new Formula
            {
                Id = "7_fot01", Nome = "Profundidade de Campo (DoF)", Categoria = "Fotografia",
                Expressao = "DoF ≈ 2·N·c·d²/f²",
                ExprTexto = "DoF ≈ 2 × f_stop × CoC × distância² / focal²",
                Icone = "📸",
                Descricao = "Profundidade de campo (zona nítida). N = abertura (f-stop), c = círculo de confusão (~0,03mm full-frame), d = distância ao sujeito, f = focal.",
                Criador = "Óptica fotográfica; desde séc. XIX",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "f/2,8, c=0,03mm, d=3m, f=50mm: DoF ≈ 2×2,8×0,03×9/2500 = 0,00060m ≈ 0,60m ~ corrigindo unidades ~0,19m",
                Variaveis = [
                    new() { Simbolo = "N", Nome = "Abertura (f-stop)", ValorPadrao = 2.8, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "c", Nome = "Círculo de confusão (mm)", ValorPadrao = 0.03, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "d", Nome = "Distância ao sujeito (m)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "f", Nome = "Dist. focal (mm)", ValorPadrao = 50, ValorMin = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "DoF (m)",
                UnidadeResultado = "m",
                Calcular = vars =>
                {
                    double fM = vars["f"] / 1000.0; // mm -> m
                    double cM = vars["c"] / 1000.0;
                    return 2 * vars["N"] * cM * vars["d"] * vars["d"] / (fM * fM);
                },
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_fot02", Nome = "Regra Sunny f/16", Categoria = "Fotografia",
                Expressao = "Velocidade ≈ 1 / ISO",
                ExprTexto = "Em dia ensolarado: f/16, velocidade = 1/ISO",
                Icone = "☀",
                Descricao = "Em pleno sol: f/16 e velocidade = 1/ISO dá exposição correta. f/11 nublado, f/8 sombra. Base para fotometria manual.",
                Criador = "Regra empírica fotográfica; séc. XX",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "ISO 200, sol: f/16, velocidade 1/200s. ISO 400: 1/400s.",
                Variaveis = [
                    new() { Simbolo = "ISO", Nome = "ISO", ValorPadrao = 200, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Velocidade (1/x seg)",
                Calcular = vars => 1.0 / vars["ISO"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_fot03", Nome = "Distância Hiperfocal", Categoria = "Fotografia",
                Expressao = "H = f² / (N · c)",
                ExprTexto = "H = focal² / (f_stop × CoC)",
                Icone = "∞",
                Descricao = "Distância mínima de foco para nitidez até o infinito. Focando em H, tudo de H/2 ao ∞ é nítido. Essencial para paisagem.",
                Criador = "Óptica fotográfica; Thomas Sutton (1867)",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "f=35mm, f/11, c=0,03mm: H = 35²/(11×0,03) = 1225/0,33 = 3712 mm ≈ 3,7m",
                Variaveis = [
                    new() { Simbolo = "f", Nome = "Dist. focal (mm)", ValorPadrao = 35, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "N", Nome = "Abertura (f-stop)", ValorPadrao = 11, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "c", Nome = "CoC (mm)", ValorPadrao = 0.03, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "H (mm)",
                UnidadeResultado = "mm",
                Calcular = vars => vars["f"] * vars["f"] / (vars["N"] * vars["c"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_fot04", Nome = "Exposição (EV)", Categoria = "Fotografia",
                Expressao = "EV = log₂(N²/t)",
                ExprTexto = "EV = log₂(f_stop² / tempo_exposição)",
                Icone = "EV",
                Descricao = "Valor de exposição: combinação de abertura e velocidade. EV 15 = dia ensolarado. Cada +1 EV = metade da luz. Triângulo de exposição.",
                Criador = "Sistema ASA/DIN; fotometria padrão",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "f/8, 1/250s: EV = log₂(64/0,004) = log₂(16000) ≈ 13,97 (dia nublado brilhante)",
                Variaveis = [
                    new() { Simbolo = "N", Nome = "Abertura (f-stop)", ValorPadrao = 8, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "t", Nome = "Tempo de exposição (s)", ValorPadrao = 0.004, ValorMin = 0.00001, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "EV",
                Calcular = vars => Math.Log(vars["N"] * vars["N"] / vars["t"]) / Math.Log(2),
                SubCategoria = "",
                Unidades = "",
            },
        ]);
    }

    private void AdicionarVol7JogosFoto()
    {
        // Jogos e Fotografia já incluídos em AdicionarVol7Artesanato
        // Este método existe apenas como ponto de chamada alternativo (não usado)
    }
}
