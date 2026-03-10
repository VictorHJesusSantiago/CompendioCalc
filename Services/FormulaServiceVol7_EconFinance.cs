using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 7 — PARTE V: ECONOMIA E FINANÇAS (16 fórmulas)
    // ═══════════════════════════════════════════════════════════════

    private void AdicionarVol7EconFinancas()
    {
        _formulas.AddRange([
            // ═══ ECONOMIA (4 fórmulas) ═══

            new Formula
            {
                Id = "7_eco01", Nome = "PIB pela Ótica da Despesa", Categoria = "Economia",
                Expressao = "PIB = C + I + G + (X − M)",
                ExprTexto = "PIB = Consumo + Investimento + Gastos Gov. + Exportações − Importações",
                Icone = "📊",
                Descricao = "Produto Interno Bruto calculado pela soma das despesas finais. C=consumo, I=investimento, G=gastos governo, X−M=balança comercial.",
                Criador = "Simon Kuznets (1934); formalizado por Keynes",
                AnoOrigin = "1934",
                ExemploPratico = "C=3,5 tri, I=1,0 tri, G=1,2 tri, X=1,5 tri, M=1,0 tri: PIB = 6,2 trilhões",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "Consumo (C)", ValorPadrao = 3500, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "I", Nome = "Investimento (I)", ValorPadrao = 1000, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "G", Nome = "Gastos do governo (G)", ValorPadrao = 1200, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "X", Nome = "Exportações (X)", ValorPadrao = 1500, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "M", Nome = "Importações (M)", ValorPadrao = 1000, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "PIB",
                Calcular = vars => vars["C"] + vars["I"] + vars["G"] + (vars["X"] - vars["M"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_eco02", Nome = "Taxa de Inflação (IPC)", Categoria = "Economia",
                Expressao = "π = (IPC_t − IPC_{t-1}) / IPC_{t-1} × 100",
                ExprTexto = "π = (IPCatual − IPCanterior) / IPCanterior × 100%",
                Icone = "π",
                Descricao = "Taxa de inflação medida pela variação do Índice de Preços ao Consumidor entre dois períodos.",
                Criador = "Estatísticas econômicas; Fischer (1922)",
                AnoOrigin = "1922",
                ExemploPratico = "IPC dez/22=6100, dez/23=6400: π = (6400−6100)/6100×100 = 4,92%",
                Variaveis = [
                    new() { Simbolo = "IPCt", Nome = "IPC atual", ValorPadrao = 6400, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "IPCt1", Nome = "IPC anterior", ValorPadrao = 6100, ValorMin = 0.01, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "π (%)",
                UnidadeResultado = "%",
                Calcular = vars => (vars["IPCt"] - vars["IPCt1"]) / vars["IPCt1"] * 100,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_eco03", Nome = "Equação de Fisher", Categoria = "Economia",
                Expressao = "i ≈ r + π",
                ExprTexto = "Taxa nominal ≈ Taxa real + Inflação esperada",
                Icone = "i=r+π",
                Descricao = "Relação de Fisher: taxa de juros nominal = taxa real + inflação esperada. Forma exata: (1+i) = (1+r)(1+π).",
                Criador = "Irving Fisher (1930)",
                AnoOrigin = "1930",
                ExemploPratico = "r=4%, π=5%: i ≈ 4+5 = 9%. Exata: (1,04)(1,05)−1 = 9,2%",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Taxa real (%)", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "pi", Nome = "Inflação esperada (%)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "i (%)",
                UnidadeResultado = "%",
                Calcular = vars => (1 + vars["r"] / 100) * (1 + vars["pi"] / 100) * 100 - 100,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_eco04", Nome = "Multiplicador Keynesiano", Categoria = "Economia",
                Expressao = "k = 1 / (1 − c)",
                ExprTexto = "k = 1 / (1 − propensão marginal a consumir)",
                Icone = "k",
                Descricao = "Efeito multiplicador: aumento no gasto gera aumento ampliado no PIB. c = propensão marginal a consumir (0 a 1).",
                Criador = "John Maynard Keynes (1936); Richard Kahn",
                AnoOrigin = "1936",
                ExemploPratico = "c=0,8: k = 1/(1−0,8) = 5. Cada R$1 de gasto gera R$5 no PIB.",
                Variaveis = [
                    new() { Simbolo = "c", Nome = "Pr. marginal a consumir (c)", Descricao = "0 a 1", ValorPadrao = 0.8, Unidade = "adim" },
                ],
                VariavelResultado = "k (multiplicador)",
                Calcular = vars => 1.0 / (1.0 - vars["c"]),
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ PESQUISA OPERACIONAL (4 fórmulas) ═══

            new Formula
            {
                Id = "7_pop01", Nome = "Programação Linear (Função Objetivo)", Categoria = "Pesquisa Operacional",
                Expressao = "Max/Min Z = c₁x₁ + c₂x₂ + ... + cₙxₙ",
                ExprTexto = "Z = c₁x₁ + c₂x₂  (caso 2 variáveis)",
                Icone = "Z*",
                Descricao = "Função objetivo de PL: maximizar ou minimizar combinação linear sujeita a restrições. Resolvido pelo método Simplex.",
                Criador = "George Dantzig (Simplex, 1947); Kantorovich (1939)",
                AnoOrigin = "1947",
                ExemploPratico = "Max Z=5x₁+3x₂, com x₁=4, x₂=6: Z = 20+18 = 38",
                Variaveis = [
                    new() { Simbolo = "c1", Nome = "Coef. c₁", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "x1", Nome = "Variável x₁", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "c2", Nome = "Coef. c₂", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "x2", Nome = "Variável x₂", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Z",
                Calcular = vars => vars["c1"] * vars["x1"] + vars["c2"] * vars["x2"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_pop02", Nome = "Fila M/M/1 (Tempo Médio)", Categoria = "Pesquisa Operacional",
                Expressao = "W = 1 / (μ − λ)",
                ExprTexto = "W = 1 / (μ − λ)  (tempo médio no sistema)",
                Icone = "W",
                Descricao = "Tempo médio de permanência no sistema M/M/1. λ = taxa de chegada, μ = taxa de serviço. Requer λ < μ (estabilidade).",
                Criador = "Agner Krarup Erlang (1909); teoria de filas",
                AnoOrigin = "1909",
                ExemploPratico = "λ=8 clientes/h, μ=10: W = 1/(10−8) = 0,5h = 30 min no sistema",
                Variaveis = [
                    new() { Simbolo = "lambda", Nome = "Taxa de chegada λ (/h)", ValorPadrao = 8, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "mu", Nome = "Taxa de serviço μ (/h)", ValorPadrao = 10, ValorMin = 0.01, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "W (h)",
                UnidadeResultado = "h",
                Calcular = vars => 1.0 / (vars["mu"] - vars["lambda"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_pop03", Nome = "Modelo EOQ (Lote Econômico)", Categoria = "Pesquisa Operacional",
                Expressao = "Q* = √(2·D·S / H)",
                ExprTexto = "Q* = √(2DS/H)  lote econômico de compra",
                Icone = "Q*",
                Descricao = "Quantidade ótima de pedido que minimiza custo total (pedido + estoque). D=demanda anual, S=custo por pedido, H=custo de manter estoque/unid/ano.",
                Criador = "Ford Whitman Harris (1913)",
                AnoOrigin = "1913",
                ExemploPratico = "D=10.000/ano, S=R$50/pedido, H=R$2/unid/ano: Q* = √(2×10000×50/2) = 707 unidades",
                Variaveis = [
                    new() { Simbolo = "D", Nome = "Demanda anual", ValorPadrao = 10000, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "S", Nome = "Custo por pedido (R$)", ValorPadrao = 50, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "H", Nome = "Custo estoque/unid/ano (R$)", ValorPadrao = 2, ValorMin = 0.01, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Q*",
                UnidadeResultado = "unidades",
                Calcular = vars => Math.Sqrt(2 * vars["D"] * vars["S"] / vars["H"]),
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_pop04", Nome = "Caminho Crítico (CPM/PERT)", Categoria = "Pesquisa Operacional",
                Expressao = "te = (a + 4m + b) / 6",
                ExprTexto = "te = (otimista + 4×mais provável + pessimista) / 6",
                Icone = "PERT",
                Descricao = "Tempo esperado de atividade (PERT): média ponderada das estimativas otimista (a), mais provável (m) e pessimista (b). Distribuição Beta.",
                Criador = "US Navy / Booz Allen Hamilton (PERT, 1958); DuPont (CPM, 1957)",
                AnoOrigin = "1958",
                ExemploPratico = "a=2 dias, m=5, b=14: te = (2+20+14)/6 = 6 dias",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Tempo otimista (a)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "m", Nome = "Tempo mais provável (m)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "b", Nome = "Tempo pessimista (b)", ValorPadrao = 14, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "te",
                UnidadeResultado = "dias",
                Calcular = vars => (vars["a"] + 4 * vars["m"] + vars["b"]) / 6.0,
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ CIÊNCIA ATUARIAL (2 fórmulas) ═══

            new Formula
            {
                Id = "7_cat01", Nome = "Valor Presente Atuarial (Anuidade Vitalícia)", Categoria = "Ciência Atuarial",
                Expressao = "äx = Σ (v^t · tpx)  para t=0,1,...",
                ExprTexto = "äx = Σ vᵗ × ₜpₓ  (anuidade antecipada)",
                Icone = "äx",
                Descricao = "Valor presente de anuidade vitalícia antecipada de 1 por ano, paga enquanto (x) viver. v=1/(1+i), tpx = probabilidade de sobreviver t anos.",
                Criador = "Edmund Halley (1693); ciência atuarial moderna",
                AnoOrigin = "1693",
                ExemploPratico = "Idade 65, i=5%, expectativa 15 anos: äx ≈ Σ(1/1,05)^t × sobrev ≈ 10,38",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Horizonte (anos)", ValorPadrao = 15, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "i", Nome = "Taxa de juros anual", ValorPadrao = 0.05, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "qx", Nome = "Prob. mortalidade anual (qx)", Descricao = "Ex: 0,02 para 2%", ValorPadrao = 0.02, Unidade = "adim" },
                ],
                VariavelResultado = "äx",
                Calcular = vars =>
                {
                    double soma = 0, px = 1.0;
                    int n = (int)vars["n"];
                    for (int t = 0; t < n; t++)
                    {
                        soma += Math.Pow(1.0 / (1.0 + vars["i"]), t) * px;
                        px *= (1 - vars["qx"]);
                    }
                    return soma;
                },
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_cat02", Nome = "Prêmio Puro de Seguro de Vida", Categoria = "Ciência Atuarial",
                Expressao = "P = Ax / äx",
                ExprTexto = "P = Seguro dotação (Ax) / Anuidade (äx)",
                Icone = "Px",
                Descricao = "Prêmio nivelado anual: razão entre valor presente do benefício (Ax) e anuidade vitalícia (äx). Princípio de equivalência atuarial.",
                Criador = "James Dodson (1756); princípio de equivalência",
                AnoOrigin = "1756",
                ExemploPratico = "Ax=0,35 (seguro vida inteira), äx=10: P = 0,35/10 = 0,035 por unidade/ano",
                Variaveis = [
                    new() { Simbolo = "Ax", Nome = "Valor presente do seguro (Ax)", ValorPadrao = 0.35, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "ax", Nome = "Anuidade vitalícia (äx)", ValorPadrao = 10, ValorMin = 0.01, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "P",
                Calcular = vars => vars["Ax"] / vars["ax"],
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ TEORIA DOS JOGOS (3 fórmulas) ═══

            new Formula
            {
                Id = "7_tjo01", Nome = "Equilíbrio de Nash (Estratégia Mista)", Categoria = "Teoria dos Jogos",
                Expressao = "E[U₁(p,q)] = p·q·a₁₁ + p(1−q)·a₁₂ + (1−p)q·a₂₁ + (1−p)(1−q)·a₂₂",
                ExprTexto = "EU₁ = pqa₁₁ + p(1−q)a₁₂ + (1−p)qa₂₁ + (1−p)(1−q)a₂₂",
                Icone = "Nash",
                Descricao = "Utilidade esperada do jogador 1 em jogo 2×2 com estratégias mistas (p,q). Equilíbrio: cada jogador indiferente entre suas estratégias puras.",
                Criador = "John Nash (1950); prêmio Nobel 1994",
                AnoOrigin = "1950",
                ExemploPratico = "Dilema prisioneiro: a₁₁=3, a₁₂=0, a₂₁=5, a₂₂=1, p=q=0,5: EU = 0,25(3+0+5+1) = 2,25",
                Variaveis = [
                    new() { Simbolo = "p", Nome = "Prob. jogador 1 escolher ação 1", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "q", Nome = "Prob. jogador 2 escolher ação 1", ValorPadrao = 0.5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "a11", Nome = "Payoff (Ação1, Ação1)", ValorPadrao = 3, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "a12", Nome = "Payoff (Ação1, Ação2)", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "a21", Nome = "Payoff (Ação2, Ação1)", ValorPadrao = 5, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "a22", Nome = "Payoff (Ação2, Ação2)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "E[U₁]",
                Calcular = vars =>
                    vars["p"] * vars["q"] * vars["a11"] +
                    vars["p"] * (1 - vars["q"]) * vars["a12"] +
                    (1 - vars["p"]) * vars["q"] * vars["a21"] +
                    (1 - vars["p"]) * (1 - vars["q"]) * vars["a22"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tjo02", Nome = "Valor de Shapley", Categoria = "Teoria dos Jogos",
                Expressao = "φᵢ = Σ [|S|!(n−|S|−1)!/n!] · [v(S∪{i}) − v(S)]",
                ExprTexto = "φᵢ = média ponderada das contribuições marginais",
                Icone = "φᵢ",
                Descricao = "Distribuição justa de valor entre jogadores de jogo cooperativo. φᵢ mede a contribuição média marginal do jogador i em todas as coalizões possíveis.",
                Criador = "Lloyd Shapley (1953); prêmio Nobel 2012",
                AnoOrigin = "1953",
                ExemploPratico = "3 jogadores, v({A})=0, v({B})=0, v({AB})=6, v({ABC})=12: φA ≈ 3",
                Variaveis = [
                    new() { Simbolo = "vAB", Nome = "v({A,B})", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "vABC", Nome = "v({A,B,C})", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "vA", Nome = "v({A})", ValorPadrao = 0, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "vBC", Nome = "v({B,C})", ValorPadrao = 6, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "φ_A (simplificado 3 jogadores)",
                Calcular = vars => (vars["vA"] + (vars["vAB"] - 0) / 2.0 + (vars["vABC"] - vars["vBC"]) / 2.0 + (vars["vABC"] - 0) / 3.0) / 2.0,
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_tjo03", Nome = "Leilão de Vickrey (Segundo Preço)", Categoria = "Teoria dos Jogos",
                Expressao = "Preço pago = 2º maior lance",
                ExprTexto = "Pagamento = segundo maior lance (vencedor paga o lance do 2º colocado)",
                Icone = "🔨",
                Descricao = "Leilão de segundo preço selado: vencedor = maior lance, mas paga o segundo maior. Estratégia dominante: dar lance = valor verdadeiro.",
                Criador = "William Vickrey (1961); prêmio Nobel 1996",
                AnoOrigin = "1961",
                ExemploPratico = "Lances: A=100, B=80, C=60: A vence e paga 80 (2º maior lance)",
                Variaveis = [
                    new() { Simbolo = "b1", Nome = "Maior lance", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "b2", Nome = "Segundo maior lance", ValorPadrao = 80, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Preço pago",
                Calcular = vars => vars["b2"],
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ MICROECONOMIA (2 fórmulas) ═══

            new Formula
            {
                Id = "7_mic01", Nome = "Elasticidade-Preço da Demanda", Categoria = "Microeconomia",
                Expressao = "Ed = (ΔQ/Q) / (ΔP/P)",
                ExprTexto = "Ed = (% variação quantidade) / (% variação preço)",
                Icone = "Ed",
                Descricao = "Mede sensibilidade da demanda ao preço. |Ed|>1: elástica, |Ed|<1: inelástica, |Ed|=1: unitária. Sempre negativa (lei da demanda).",
                Criador = "Alfred Marshall (1890)",
                AnoOrigin = "1890",
                ExemploPratico = "Preço sobe 10%, quantidade cai 20%: Ed = −20/10 = −2 (elástica)",
                Variaveis = [
                    new() { Simbolo = "dQ", Nome = "Variação % quantidade", ValorPadrao = -20, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "dP", Nome = "Variação % preço", ValorPadrao = 10, ValorMin = 0.01, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Ed",
                Calcular = vars => vars["dQ"] / vars["dP"],
                SubCategoria = "",
                Unidades = "",
            },
            new Formula
            {
                Id = "7_mic02", Nome = "Excedente do Consumidor", Categoria = "Microeconomia",
                Expressao = "EC = 0.5 · (P_max − P*) · Q*",
                ExprTexto = "EC = ½ × (Preço máximo − Preço equilíbrio) × Quantidade equilíbrio",
                Icone = "EC",
                Descricao = "Área do triângulo entre a curva de demanda e o preço de mercado. Representa o benefício dos consumidores que pagariam mais.",
                Criador = "Jules Dupuit (1844); Marshall (1890)",
                AnoOrigin = "1844",
                ExemploPratico = "Pmax=100, P*=60, Q*=200: EC = 0,5×40×200 = R$4.000",
                Variaveis = [
                    new() { Simbolo = "Pmax", Nome = "Preço máximo (disposição)", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Peq", Nome = "Preço de equilíbrio", ValorPadrao = 60, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Qeq", Nome = "Quantidade de equilíbrio", ValorPadrao = 200, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "EC (R$)",
                UnidadeResultado = "R$",
                Calcular = vars => 0.5 * (vars["Pmax"] - vars["Peq"]) * vars["Qeq"],
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ MACROECONOMIA (1 fórmula) ═══

            new Formula
            {
                Id = "7_mac01", Nome = "Equação Quantitativa da Moeda", Categoria = "Macroeconomia",
                Expressao = "M · V = P · Y",
                ExprTexto = "M × V = P × Y  (quantidade de moeda × velocidade = nível de preços × PIB real)",
                Icone = "MV",
                Descricao = "Identidade monetária de Fisher: oferta de moeda × velocidade de circulação = produto nominal. Base da teoria monetarista.",
                Criador = "Irving Fisher (1911); Simon Newcomb (1885)",
                AnoOrigin = "1911",
                ExemploPratico = "M=2 tri, V=4: PIB nominal = MV = 8 trilhões",
                Variaveis = [
                    new() { Simbolo = "M", Nome = "Oferta monetária (M)", ValorPadrao = 2000, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "V", Nome = "Velocidade (V)", ValorPadrao = 4, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "PY (PIB nominal)",
                Calcular = vars => vars["M"] * vars["V"],
                SubCategoria = "",
                Unidades = "",
            },
        ]);
    }
}
