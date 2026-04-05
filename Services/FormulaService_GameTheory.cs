using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME IX - PARTE I: TEORIA DOS JOGOS E DESIGN DE MECANISMOS
    /// Equilíbrio de Nash, jogos cooperativos, leilões e escolha social
    /// Fórmulas 001-021 (21 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        /// <summary>
        /// V9_GAME001: Equilíbrio de Nash
        /// Condição: ∀i: uᵢ(s*ᵢ,s*₋ᵢ) ≥ uᵢ(sᵢ,s*₋ᵢ)
        /// Nenhum jogador melhora desviando unilateralmente
        /// </summary>
        private Formula V9_GAME001_EquilibrioNash()
        {
            return new Formula
            {
                Id = "V9-GAME001",
                CodigoCompendio = "001",
                Nome = "Equilíbrio de Nash",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "∀i: uᵢ(s*ᵢ,s*₋ᵢ) ≥ uᵢ(sᵢ,s*₋ᵢ)",
                ExprTexto = "Para todo jogador i: utilidade no equilíbrio ≥ utilidade desviando",
                Descricao = "Condição de Equilíbrio de Nash: nenhum jogador pode melhorar sua utilidade desviando unilateralmente da estratégia de equilíbrio. Todo jogo finito tem ao menos um equilíbrio de Nash (puro ou misto). Conceito fundamental em teoria dos jogos.",
                Criador = "John Nash (1950-1951, tese Princeton; Nobel Economia 1994)",
                AnoOrigin = "1950",
                ExemploPratico = "Dilema do Prisioneiro: (Desertar,Desertar) é único Nash puro; ambos jogadores na prisão não melhoram mudando unilateralmente. Batalha dos Sexos: 2 Nash puros + 1 misto. Oligopólio de Cournot: cada firma produz quantidade ótima dada produção das rivais.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "u_i", Nome = "Utilidade jogador i", Descricao = "Payoff do jogador i", Unidade = "utils", ValorMin = double.MinValue, Obrigatoria = true },
                    new Variavel { Simbolo = "s_i_star", Nome = "Estratégia equilíbrio jogador i", Descricao = "Estratégia de i no equilíbrio de Nash", Unidade = "adimensional", ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "s_minus_i_star", Nome = "Estratégia dos outros", Descricao = "Vetor de estratégias dos demais jogadores -i", Unidade = "adimensional", ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Calcula payoff diferencial: se >0, não é Nash (melhor desviar)
                    double u_equilibrio = valores["u_i"];
                    double u_desvio = valores.ContainsKey("u_desvio") ? valores["u_desvio"] : u_equilibrio;
                    double diferencial = u_desvio - u_equilibrio; // se >0: não é Nash
                    return diferencial <= 0 ? 1.0 : 0.0; // 1=é Nash, 0=não é Nash
                },
                VariavelResultado = "Teste Nash",
                UnidadeResultado = "booleano (1=Nash, 0=não-Nash)",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME002: Estratégia Mista de Nash
        /// σ*ᵢ(sᵢ)>0 ⟹ sᵢ∈argmax uᵢ(sᵢ,σ*₋ᵢ)
        /// </summary>
        private Formula V9_GAME002_EstrategiaMista()
        {
            return new Formula
            {
                Id = "V9-GAME002",
                CodigoCompendio = "002",
                Nome = "Estratégia Mista de Nash",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "σ*ᵢ(sᵢ)>0 ⟹ sᵢ∈argmax uᵢ(sᵢ,σ*₋ᵢ)",
                ExprTexto = "Probabilidade positiva apenas em estratégias igualmente ótimas",
                Descricao = "Condição de Nash em estratégias mistas: probabilidade positiva σ*ᵢ(sᵢ)>0 somente para estratégias puras que maximizam utilidade esperada. Estratégias subótimas recebem probabilidade zero. Garante indiferença entre todas estratégias com suporte positivo.",
                Criador = "John Nash (1950, Equilibrium Points in N-Person Games)",
                AnoOrigin = "1950",
                ExemploPratico = "Pedra-Papel-Tesoura: único Nash é mistura uniforme σ=(1/3,1/3,1/3) sobre {Pedra,Papel,Tesoura}. Pênalti de futebol: atacante mistura esquerda/direita com probabilidades dependentes de assimetria de habilidade. Inspeção de qualidade: firma mistura fraude/honestidade.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p_pedra", Nome = "Prob Pedra", Descricao = "Probabilidade estratégia Pedra", Unidade = "probabilidade", ValorPadrao = 0.333, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "p_papel", Nome = "Prob Papel", Descricao = "Probabilidade estratégia Papel", Unidade = "probabilidade", ValorPadrao = 0.333, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "p_tesoura", Nome = "Prob Tesoura", Descricao = "Probabilidade estratégia Tesoura", Unidade = "probabilidade", ValorPadrao = 0.334, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double p1 = valores["p_pedra"];
                    double p2 = valores["p_papel"];
                    double p3 = valores["p_tesoura"];
                    double soma = p1 + p2 + p3;
                    if (Math.Abs(soma - 1.0) > 0.001) throw new InvalidOperationException("Probabilidades devem somar 1");
                    // PPT equilibrio: utilidade esperada = 0 para todas estratégias
                    // Payoff esperado vs pedra adversário: p2*1 + p3*(-1) = 0 => p2=p3
                    // Por simetria: p1=p2=p3=1/3
                    double max_p = Math.Max(p1, Math.Max(p2, p3));
                    double min_p = Math.Min(p1, Math.Min(p2, p3));
                    double diferenca = max_p - min_p; // =0 se uniforme (Nash)
                    return diferenca; // 0=Nash equilibrio, >0=não-Nash
                },
                VariavelResultado = "Desvio uniformidade",
                UnidadeResultado = "diferença probabilidades",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME003: Valor de Shapley
        /// φᵢ(v)=Σ_{S⊆N\i} [|S|!(n−|S|−1)!/n!]·[v(S∪i)−v(S)]
        /// </summary>
        private Formula V9_GAME003_ValorShapley()
        {
            return new Formula
            {
                Id = "V9-GAME003",
                CodigoCompendio = "003",
                Nome = "Valor de Shapley",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "φᵢ(v)=Σ_{S⊆N\\i} [|S|!(n−|S|−1)!/n!]·[v(S∪i)−v(S)]",
                ExprTexto = "Soma ponderada das contribuições marginais em todas ordens",
                Descricao = "Alocação justa em jogo cooperativo: valor de Shapley φᵢ é a contribuição marginal média do jogador i sobre todas as ordens possíveis de formação de coalizão. Pesos são |S|!(n-|S|-1)!/n!. Satisfaz eficiência, simetria, null player e linearidade.",
                Criador = "Lloyd Shapley (1953, A Value for N-Person Games; Nobel Economia 2012)",
                AnoOrigin = "1953",
                ExemploPratico = "Jogo de 3 jogadores: v({1})=0, v({2})=0, v({3})=0, v({1,2})=60, v({1,3})=50, v({2,3})=40, v({1,2,3})=100 → Shapley φ=(40,35,25). Custo de aeroporto: Shapley aloca custo de pista por tipo de avião. Votação: poder de Shapley-Shubik.",
                Unidades = "valor",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v_12", Nome = "Valor coalizão {1,2}", Descricao = "Valor da coalizão de jogadores 1 e 2", Unidade = "valor", ValorPadrao = 60, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_13", Nome = "Valor coalizão {1,3}", Descricao = "Valor da coalizão de jogadores 1 e 3", Unidade = "valor", ValorPadrao = 50, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_23", Nome = "Valor coalizão {2,3}", Descricao = "Valor da coalizão de jogadores 2 e 3", Unidade = "valor", ValorPadrao = 40, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_123", Nome = "Valor grande coalizão", Descricao = "Valor da grande coalizão {1,2,3}", Unidade = "valor", ValorPadrao = 100, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Shapley para jogador 1 em jogo de 3 jogadores
                    // φ₁ = 1/6[(v₁₂₃-v₂₃) + (v₁₂₃-v₂₃) + (v₁₂-0) + (v₁₃-0) + (v₁₂₃-v₂₃) + (v₁₂₃-v₂₃)]
                    // Simplificando: φ₁ = 1/3[(v₁₂₃-v₂₃) + (v₁₂₃-v₂₃)] + 1/6[(v₁₂+v₁₃)]
                    double v12 = valores["v_12"];
                    double v13 = valores["v_13"];
                    double v23 = valores["v_23"];
                    double v123 = valores["v_123"];
                    // Jogador 1: contribuição marginal média
                    // Ordems: 1,2,3 | 1,3,2 | 2,1,3 | 2,3,1 | 3,1,2 | 3,2,1
                    double phi1 = (1.0/6.0) * (
                        v12 + v13 + (v123-v23) + (v123-v23) + (v123-v23) + (v123-v23)
                    );
                    phi1 = (1.0/3.0) * (v12 + v13 + (v123 - v23)); // fórmula simplificada
                    return phi1;
                },
                VariavelResultado = "Shapley jogador 1",
                UnidadeResultado = "valor",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME004: Mecanismo VCG (Vickrey-Clarke-Groves)
        /// t*=argmax Σvᵢ(t); pᵢ=Σⱼ≠ᵢvⱼ(t*₋ᵢ)−Σⱼ≠ᵢvⱼ(t*)
        /// </summary>
        private Formula V9_GAME004_MecanismoVCG()
        {
            return new Formula
            {
                Id = "V9-GAME004",
                CodigoCompendio = "004",
                Nome = "Mecanismo VCG",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "t*=argmax Σvᵢ(t); pᵢ=Σⱼ≠ᵢvⱼ(t*₋ᵢ)−Σⱼ≠ᵢvⱼ(t*)",
                ExprTexto = "Maximiza bem-estar social; pagamento = externalidade causada",
                Descricao = "Mecanismo Vickrey-Clarke-Groves induz revelação verdadeira das valorações como estratégia dominante. Aloca decisão t* que maximiza soma das valorações. Jogador i paga diferença entre bem-estar dos outros sem i (ótimo t*₋ᵢ) e com i (em t*). Base de leilões combinatórios e redes digitais.",
                Criador = "William Vickrey (1961, Nobel 1996); Edward Clarke (1971); Theodore Groves (1973)",
                AnoOrigin = "1961",
                ExemploPratico = "Leilão de segundo preço: caso especial VCG com t∈{vencedor} e valorações vᵢ(ganha)=valoração privada. Pagamento=2° maior lance. Google Ads usa variante generalizada de VCG (GSP). Alocação de espectro de rádio: FCC auctions combinatórias.",
                Unidades = "valor",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v_1", Nome = "Valoração jogador 1", Descricao = "Valoração privada do jogador 1 pelo bem", Unidade = "valor", ValorPadrao = 100, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_2", Nome = "Valoração jogador 2", Descricao = "Valoração privada do jogador 2 pelo bem", Unidade = "valor", ValorPadrao = 80, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_3", Nome = "Valoração jogador 3", Descricao = "Valoração privada do jogador 3 pelo bem", Unidade = "valor", ValorPadrao = 60, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Leilão VCG (2º preço): vencedor = maior valoração, paga 2º maior
                    double v1 = valores["v_1"];
                    double v2 = valores["v_2"];
                    double v3 = valores["v_3"];
                    double max_val = Math.Max(v1, Math.Max(v2, v3));
                    double segundo_maior;
                    if (max_val == v1) segundo_maior = Math.Max(v2, v3);
                    else if (max_val == v2) segundo_maior = Math.Max(v1, v3);
                    else segundo_maior = Math.Max(v1, v2);
                    // Pagamento VCG do vencedor = externalidade = 2º maior lance
                    return segundo_maior;
                },
                VariavelResultado = "Pagamento VCG vencedor",
                UnidadeResultado = "valor",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME005: Leilão de Segundo Preço - Vickrey
        /// Estratégia dominante: lance = valoração verdadeira vᵢ
        /// </summary>
        private Formula V9_GAME005_LeilaoSegundoPreco()
        {
            return new Formula
            {
                Id = "V9-GAME005",
                CodigoCompendio = "005",
                Nome = "Leilão de Segundo Preço - Vickrey",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "lance = v_i (estratégia dominante)",
                ExprTexto = "Revelar valoração verdadeira é dominante",
                Descricao = "No leilão de segundo preço (Vickrey), estratégia dominante é lançar valoração verdadeira vᵢ, independente dos lances rivais. Vencedor paga segundo maior lance. Eficiente (higher valuer ganha) e incentive-compatible. Base de design de mecanismos.",
                Criador = "William Vickrey (1961, Counterspeculation and Competitive Sealed Tenders; Nobel 1996)",
                AnoOrigin = "1961",
                ExemploPratico = "Valoração v=100: lançar 100 é dominante independente de lances alheios. Se lançar >100 e 2º maior entre 100-lance: ganha pagando mais que valoração (prejuízo). Se lançar <100 e 2º maior entre lance-100: perde quando poderia ganhar com lucro. eBay usa variante.",
                Unidades = "valor",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v_verdadeira", Nome = "Valoração verdadeira", Descricao = "Valoração privada do jogador pelo bem", Unidade = "valor", ValorPadrao = 100, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "segundo_maior_lance", Nome = "2º maior lance", Descricao = "Segundo maior lance dos rivais", Unidade = "valor", ValorPadrao = 80, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double v = valores["v_verdadeira"];
                    double segundo = valores["segundo_maior_lance"];
                    // Payoff se ganhar leilão = v - segundo_maior_lance
                    // Só ganha se v > segundo (estratégia dominante é lançar v)
                    double payoff = (v > segundo) ? (v - segundo) : 0.0;
                    return payoff;
                },
                VariavelResultado = "Payoff esperado",
                UnidadeResultado = "valor",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME006: Equilíbrio de Bayes-Nash
        /// sᵢ*(tᵢ)∈argmax Eₜ₋ᵢ[uᵢ(sᵢ,s*₋ᵢ(t₋ᵢ),tᵢ,t₋ᵢ)]
        /// </summary>
        private Formula V9_GAME006_EquilibrioBayesNash()
        {
            return new Formula
            {
                Id = "V9-GAME006",
                CodigoCompendio = "006",
                Nome = "Equilíbrio de Bayes-Nash",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "sᵢ*(tᵢ)∈argmax E[uᵢ(sᵢ,s*₋ᵢ(t₋ᵢ),tᵢ,t₋ᵢ)]",
                ExprTexto = "Maximiza utilidade esperada sobre tipos dos outros",
                Descricao = "Equilíbrio em jogos com informação incompleta (tipos privados tᵢ). Estratégia sᵢ*(tᵢ) maximiza utilidade esperada sobre distribuição de tipos dos rivais. Cada tipo joga melhor resposta em expectativa. Generaliza Nash para jogos bayesianos.",
                Criador = "John Harsanyi (1967-68, Games with Incomplete Information; Nobel 1994)",
                AnoOrigin = "1967",
                ExemploPratico = "Leilão de primeiro preço com valorações privadas uniformes U[0,1]: BNE β(v)=(n-1)/n·v. Com n=2: lance 50% da valoração. Sinalização de Spence: trabalhador habilidoso investe em educação (separating equilibrium). Mercado de limões: Akerlof adverse selection.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v_i", Nome = "Tipo (valoração) jogador i", Descricao = "Tipo privado do jogador i (ex: valoração)", Unidade = "valor", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "n", Nome = "Número de jogadores", Descricao = "Total de jogadores no leilão", Unidade = "jogadores", ValorPadrao = 2, ValorMin = 2, ValorMax = 100, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // BNE leilão 1º preço uniforme: β(v) = (n-1)/n · v
                    double v = valores["v_i"];
                    double n = valores["n"];
                    double lance_equilibrio = ((n - 1.0) / n) * v;
                    return lance_equilibrio;
                },
                VariavelResultado = "Lance BNE",
                UnidadeResultado = "valor",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME007: Minimax de Von Neumann
        /// max_x min_y x'Ay = min_y max_x x'Ay = v*
        /// </summary>
        private Formula V9_GAME007_MinimaxVonNeumann()
        {
            return new Formula
            {
                Id = "V9-GAME007",
                CodigoCompendio = "007",
                Nome = "Minimax de Von Neumann",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "max_x min_y x'Ay = min_y max_x x'Ay = v*",
                ExprTexto = "Valor do jogo em estratégias mistas é único",
                Descricao = "Teorema Minimax: em jogos de soma zero de dois jogadores, existe valor único v* alcançável por estratégias mistas. Jogador 1 maximiza mínimo payoff; jogador 2 minimiza máximo. Garante solução racional em conflitos puros. Base da teoria dos jogos.",
                Criador = "John von Neumann (1928, Zur Theorie der Gesellschaftsspiele); von Neumann e Morgenstern (1944, Theory of Games)",
                AnoOrigin = "1928",
                ExemploPratico = "Poker simplificado: valor v* do jogo. Xadrez: minimax com alpha-beta pruning para busca de árvore de jogo. Guerra fria: estratégia minimax nuclear (MAD). Investidor vs natureza: maximin criterion (Wald).",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a11", Nome = "Payoff (1,1)", Descricao = "Payoff se ambos escolhem estratégia 1", Unidade = "utils", ValorPadrao = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "a12", Nome = "Payoff (1,2)", Descricao = "Payoff se jog1 escolhe 1, jog2 escolhe 2", Unidade = "utils", ValorPadrao = -1, Obrigatoria = true },
                    new Variavel { Simbolo = "a21", Nome = "Payoff (2,1)", Descricao = "Payoff se jog1 escolhe 2, jog2 escolhe 1", Unidade = "utils", ValorPadrao = -1, Obrigatoria = true },
                    new Variavel { Simbolo = "a22", Nome = "Payoff (2,2)", Descricao = "Payoff se ambos escolhem estratégia 2", Unidade = "utils", ValorPadrao = 1, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Jogo 2×2: calcula valor minimax
                    double a11 = valores["a11"];
                    double a12 = valores["a12"];
                    double a21 = valores["a21"];
                    double a22 = valores["a22"];
                    // Jogo matching pennies típico: valor=0
                    // Fórmula geral 2×2: v* = (a11·a22 - a12·a21)/(a11 + a22 - a12 - a21)
                    double numerador = a11 * a22 - a12 * a21;
                    double denominador = a11 + a22 - a12 - a21;
                    if (Math.Abs(denominador) < 1e-10) return 0.0; // jogo degenerado
                    double valor_jogo = numerador / denominador;
                    return valor_jogo;
                },
                VariavelResultado = "Valor minimax v*",
                UnidadeResultado = "utils",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME008: Teorema da Impossibilidade de Arrow
        /// Não existe SWF satisfazendo P, I, U, ND simultaneamente
        /// </summary>
        private Formula V9_GAME008_TeoremaArrow()
        {
            return new Formula
            {
                Id = "V9-GAME008",
                CodigoCompendio = "008",
                Nome = "Teorema da Impossibilidade de Arrow",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "¬∃SWF: Pareto ∧ Independência ∧ Domínio irrestrito ∧ Não-ditadura",
                ExprTexto = "Impossível agregar preferências satisfazendo 4 axiomas",
                Descricao = "Teorema de Arrow: não existe função de bem-estar social (SWF) satisfazendo simultaneamente: (P) Pareto, (I) Independência de alternativas irrelevantes, (U) Domínio irrestrito, (ND) Não-ditadura. Impossibilidade fundamental na escolha social democrática.",
                Criador = "Kenneth Arrow (Social Choice and Individual Values, 1951; Nobel Economia 1972)",
                AnoOrigin = "1951",
                ExemploPratico = "Paradoxo de Condorcet: A>B>C>A em preferências majoritárias (ciclo). Qualquer regra de votação viola algum axioma: maioria simples viola IIA; ditadura viola ND; regra de Borda viola IIA. Implicação: democracia perfeita é logicamente impossível.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "n_votantes", Nome = "Número de votantes", Descricao = "Total de indivíduos votando", Unidade = "pessoas", ValorPadrao = 3, ValorMin = 3, Obrigatoria = true },
                    new Variavel { Simbolo = "n_alternativas", Nome = "Número de alternativas", Descricao = "Total de opções para escolher", Unidade = "alternativas", ValorPadrao = 3, ValorMin = 3, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    // Condição de Arrow: com ≥3 alternativas e ≥2 indivíduos, impossibilidade
                    double n_vot = valores["n_votantes"];
                    double n_alt = valores["n_alternativas"];
                    // Retorna 0 se impossibilidade aplicável, 1 se não (casos triviais)
                    if (n_vot >= 2 && n_alt >= 3) return 0.0; // impossibilidade
                    return 1.0; // casos triviais: n_alt<3 ou n_vot=1 (ditador)
                },
                VariavelResultado = "Possibilidade SWF",
                UnidadeResultado = "booleano (0=impossível, 1=possível)",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME009: Modelo de Hotelling - Diferenciação
        /// p* = c + t·d (preço de equilíbrio)
        /// </summary>
        private Formula V9_GAME009_ModeloHotelling()
        {
            return new Formula
            {
                Id = "V9-GAME009",
                CodigoCompendio = "009",
                Nome = "Modelo de Hotelling - Diferenciação",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "p* = c + t·d",
                ExprTexto = "Preço = custo marginal + custo de transporte × distância",
                Descricao = "Modelo de Hotelling: duopólio em linha com custo de transporte t. Firmas escolhem localização e preço. Princípio da diferenciação mínima: tendência de convergir ao centro (eleitor mediano). Equilíbrio: preço p*=c+t·d onde d=distância entre firmas.",
                Criador = "Harold Hotelling (1929, Stability in Competition, Economic Journal)",
                AnoOrigin = "1929",
                ExemploPratico = "Duas pizzarias em avenida: convergem ao centro da cidade (competição máxima). Partidos políticos: convergem ao eleitor mediano para maximizar votos. Com 3+ firmas: diferenciação ótima para reduzir competição. Supermercados em bairros adjacentes.",
                Unidades = "$/unidade",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "c", Nome = "Custo marginal", Descricao = "Custo marginal de produção", Unidade = "$/unidade", ValorPadrao = 5, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "t", Nome = "Custo transporte", Descricao = "Custo de transporte por unidade de distância", Unidade = "$/km", ValorPadrao = 2, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "d", Nome = "Distância", Descricao = "Distância entre firmas ou ao consumidor", Unidade = "km", ValorPadrao = 3, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double c = valores["c"];
                    double t = valores["t"];
                    double d = valores["d"];
                    double preco_equilibrio = c + t * d;
                    return preco_equilibrio;
                },
                VariavelResultado = "Preço de equilíbrio p*",
                UnidadeResultado = "$/unidade",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME010: Equilíbrio de Stackelberg
        /// qL=(a-c)/(2b); qF=(a-c)/(4b); πL > πCournot
        /// </summary>
        private Formula V9_GAME010_EquilibrioStackelberg()
        {
            return new Formula
            {
                Id = "V9-GAME010",
                CodigoCompendio = "010",
                Nome = "Equilíbrio de Stackelberg",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "qL=(a-c)/(2b); qF=(a-c)/(4b); πL > πCournot",
                ExprTexto = "Líder produz mais, seguidor menos; líder tem maior lucro",
                Descricao = "Duopólio sequencial de Stackelberg: líder move primeiro escolhendo quantidade qL, seguidor observa e reage com qF. Vantagem do primeiro-movedor: líder produz mais e tem lucro maior que no Cournot (simultâneo). Seguidor maximiza dado qL; líder antecipa reação.",
                Criador = "Heinrich von Stackelberg (1934, Marktform und Gleichgewicht)",
                AnoOrigin = "1934",
                ExemploPratico = "Mercado de demanda P=a-b(qL+qF). Líder: qL=(a-c)/(2b). Seguidor: qF=(a-c-bqL)/(2b)=(a-c)/(4b). Lucro líder πL>πCournot por fator 9/8. Política fiscal: governo lidera, setor privado segue. Inovação tecnológica: first-mover advantage.",
                Unidades = "unidades",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Intercepto demanda", Descricao = "Preço de reserva máximo P=a-bQ", Unidade = "$/unidade", ValorPadrao = 100, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "b", Nome = "Inclinação demanda", Descricao = "Sensibilidade de preço à quantidade", Unidade = "$/unidade²", ValorPadrao = 1, ValorMin = 0.001, Obrigatoria = true },
                    new Variavel { Simbolo = "c", Nome = "Custo marginal", Descricao = "Custo marginal uniforme das firmas", Unidade = "$/unidade", ValorPadrao = 10, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double a = valores["a"];
                    double b = valores["b"];
                    double c = valores["c"];
                    double q_lider = (a - c) / (2.0 * b);
                    double q_seguidor = (a - c) / (4.0 * b);
                    double Q_total = q_lider + q_seguidor;
                    double preco = a - b * Q_total;
                    double lucro_lider = (preco - c) * q_lider;
                    return lucro_lider; // retorna lucro do líder
                },
                VariavelResultado = "Lucro do líder πL",
                UnidadeResultado = "$",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME011: Teoria da Sinalização - Spence
        /// Equilíbrio separador: custo sinal c(e,θ) diferenciado por tipo
        /// </summary>
        private Formula V9_GAME011_TeoriaSinalizacao()
        {
            return new Formula
            {
                Id = "V9-GAME011",
                CodigoCompendio = "011",
                Nome = "Teoria da Sinalização - Spence",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "c(e,θ_H) < c(e,θ_L) para equilíbrio separador",
                ExprTexto = "Custo de sinalizar menor para tipo alto",
                Descricao = "Sinalização de Spence: tipo alto (θ_H) separa-se de tipo baixo (θ_L) via sinal custoso (ex: educação e). Equilíbrio separador: tipo alto investe e>e*, tipo baixo não investe. Condição: single-crossing (tipo alto tem custo menor). Educação pode não ter valor produtivo, apenas sinalizador.",
                Criador = "Michael Spence (1973, Job Market Signaling, Quarterly Journal of Economics; Nobel 2001)",
                AnoOrigin = "1973",
                ExemploPratico = "Trabalhador habilidoso investe em diploma universitário (custo e=4 anos), inábil acha custoso demais (desiste). Empregador infere habilidade por diploma: salário alto w_H para diplomados, baixo w_L para não-diplomados. Educação sem valor produtivo: pure signaling. Garantias de produto: sinaliza qualidade.",
                Unidades = "$/tempo",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e", Nome = "Nível de educação", Descricao = "Anos de educação como sinal", Unidade = "anos", ValorPadrao = 4, ValorMin = 0, ValorMax = 10, Obrigatoria = true },
                    new Variavel { Simbolo = "c_H", Nome = "Custo tipo alto", Descricao = "Custo/ano tipo produtivo", Unidade = "$/ano", ValorPadrao = 10000, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "c_L", Nome = "Custo tipo baixo", Descricao = "Custo/ano tipo improdutivo", Unidade = "$/ano", ValorPadrao = 20000, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "w_H", Nome = "Salário alto", Descricao = "Salário para tipo alto", Unidade = "$", ValorPadrao = 80000, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "w_L", Nome = "Salário baixo", Descricao = "Salário para tipo baixo", Unidade = "$", ValorPadrao = 40000, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double e = valores["e"];
                    double c_H = valores["c_H"];
                    double c_L = valores["c_L"];
                    double w_H = valores["w_H"];
                    double w_L = valores["w_L"];
                    // Payoff líquido tipo alto se sinalizar: w_H - c_H*e
                    double payoff_H_sinalizar = w_H - c_H * e;
                    double payoff_H_nao = w_L; // não sinaliza, pooling com tipo baixo
                    // Payoff tipo baixo se tentar sinalizar: w_H - c_L*e
                    double payoff_L_sinalizar = w_H - c_L * e;
                    double payoff_L_nao = w_L;
                    // Equilíbrio separador: H sinaliza, L não
                    // Condição: payoff_H_sinalizar > payoff_H_nao E payoff_L_nao > payoff_L_sinalizar
                    bool separador = (payoff_H_sinalizar > payoff_H_nao) && (payoff_L_nao > payoff_L_sinalizar);
                    return separador ? 1.0 : 0.0; // 1=equilíbrio separador, 0=não
                },
                VariavelResultado = "Equilíbrio separador",
                UnidadeResultado = "booleano (1=sim, 0=não)",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME012: Folk Theorem - Jogos Repetidos
        /// Qualquer v≥v* sustentável como NE se δ≥δ* (jogo infinito)
        /// </summary>
        private Formula V9_GAME012_FolkTheorem()
        {
            return new Formula
            {
                Id = "V9-GAME012",
                CodigoCompendio = "012",
                Nome = "Folk Theorem - Jogos Repetidos",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "v≥v* sustentável se δ≥δ*",
                ExprTexto = "Cooperação emerge com desconto alto via punição",
                Descricao = "Folk Theorem: em jogos infinitamente repetidos com desconto δ, qualquer payoff v acima do minimax v* pode ser sustentado como equilíbrio de Nash se δ≥δ* (desconto suficientemente alto). Estratégias de punição (Grim Trigger, Tit-for-Tat) disciplinam desvios. Cooperação emerge do shadow of the future.",
                Criador = "James Friedman (1971); Drew Fudenberg e Eric Maskin (1986, Folk Theorem for Repeated Games)",
                AnoOrigin = "1971",
                ExemploPratico = "Cartel: δ=0,9, desvio lucrativo 1 período, Grim Trigger pune para sempre. Cooperação sustentável se desconto alto. Dilema do prisioneiro repetido: {Cooperar,Cooperar} sustentável com Tit-for-Tat. Comércio internacional: acordos implícitos sem enforcement. Reputação corporativa.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "delta", Nome = "Fator desconto", Descricao = "Desconto temporal δ∈[0,1]", Unidade = "adimensional", ValorPadrao = 0.9, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "v_coop", Nome = "Payoff cooperação", Descricao = "Payoff por período cooperando", Unidade = "utils", ValorPadrao = 3, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_desvio", Nome = "Ganho desvio", Descricao = "Payoff desviando 1 período", Unidade = "utils", ValorPadrao = 4, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_punicao", Nome = "Payoff punição", Descricao = "Payoff durante punição (minimax)", Unidade = "utils", ValorPadrao = 1, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double delta = valores["delta"];
                    double v_coop = valores["v_coop"];
                    double v_desvio = valores["v_desvio"];
                    double v_punicao = valores["v_punicao"];
                    // Valor presente cooperação: v_coop/(1-δ)
                    double VP_coop = v_coop / (1.0 - delta);
                    // Valor presente desviando: v_desvio + δ·v_punicao/(1-δ) (Grim Trigger)
                    double VP_desvio = v_desvio + (delta / (1.0 - delta)) * v_punicao;
                    // Cooperação sustentável se VP_coop ≥ VP_desvio
                    // Condição crítica: δ ≥ (v_desvio - v_coop)/(v_desvio - v_punicao)
                    double delta_critico = (v_desvio - v_coop) / (v_desvio - v_punicao);
                    bool sustentavel = (delta >= delta_critico);
                    return sustentavel ? 1.0 : 0.0; // 1=cooperação sustentável, 0=não
                },
                VariavelResultado = "Cooperação sustentável",
                UnidadeResultado = "booleano (1=sim, 0=não)",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME013: Mecanismo Ótimo de Myerson
        /// p*(v)=v−(1-F(v))/f(v) (preço virtual)
        /// </summary>
        private Formula V9_GAME013_MecanismoMyerson()
        {
            return new Formula
            {
                Id = "V9-GAME013",
                CodigoCompendio = "013",
                Nome = "Mecanismo Ótimo de Myerson",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "p*(v)=v−(1-F(v))/f(v)",
                ExprTexto = "Preço virtual: valoração menos taxa de hazard inversa",
                Descricao = "Leilão ótimo de Myerson: maximiza receita do vendedor via preço de reserva ótimo r*. Aloca ao maior preço virtual positivo p*(v)=v−(1−F(v))/f(v). Condição: regular (p* crescente). Revenue-maximizing mechanism design. Generaliza leilão de segundo preço.",
                Criador = "Roger Myerson (1981, Optimal Auction Design, Mathematics of Operations Research; Nobel 2007)",
                AnoOrigin = "1981",
                ExemploPratico = "Distribuição uniforme F~U[0,1]: p*(v)=v−(1−v)/1=2v−1. Aloca se p*(v)>0, ou seja, v>1/2. Preço de reserva ótimo r=0,5. Leilão Bayesiano ótimo com players assimétricos. Revenue Equivalence Theorem: todos mecanismos IC têm mesma receita esperada.",
                Unidades = "valor",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Valoração", Descricao = "Valoração do jogador", Unidade = "valor", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "F_v", Nome = "CDF em v", Descricao = "Função distribuição acumulada F(v)", Unidade = "probabilidade", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "f_v", Nome = "PDF em v", Descricao = "Densidade de probabilidade f(v)", Unidade = "1/valor", ValorPadrao = 1.0, ValorMin = 0.001, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double v = valores["v"];
                    double F_v = valores["F_v"];
                    double f_v = valores["f_v"];
                    // Preço virtual de Myerson: p*(v) = v - (1-F(v))/f(v)
                    double preco_virtual = v - (1.0 - F_v) / f_v;
                    return preco_virtual;
                },
                VariavelResultado = "Preço virtual p*(v)",
                UnidadeResultado = "valor",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME014: Equilíbrio Correlacionado de Aumann
        /// Σ μ(sᵢ,s₋ᵢ)·uᵢ(sᵢ,s₋ᵢ) ≥ Σ μ(s'ᵢ,s₋ᵢ)·uᵢ(s'ᵢ,s₋ᵢ)
        /// </summary>
        private Formula V9_GAME014_EquilibrioCorrelacionado()
        {
            return new Formula
            {
                Id = "V9-GAME014",
                CodigoCompendio = "014",
                Nome = "Equilíbrio Correlacionado de Aumann",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "E[u(s)|rec s] ≥ E[u(s')|rec s] ∀s'",
                ExprTexto = "Não compensa desviar dado recomendação",
                Descricao = "Generalização de Nash: correlaciona estratégias via dispositivo público (semáforo, referee). Distribuição μ(s₁,...,sₙ) tal que ninguém desvia após receber recomendação privada sᵢ. Conjunto de equilíbrios correlacionados é convexo e contém todos Nash. Pode ser mais eficiente que Nash.",
                Criador = "Robert Aumann (1974, Subjectivity and Correlation in Randomized Strategies; Nobel 2005)",
                AnoOrigin = "1974",
                ExemploPratico = "Semáforo em interseção: coordena (Verde,Vermelho) e (Vermelho,Verde) com probabilidades correlacionadas, evita colisão. Chicken game: CE permite coordenação eficiente impossível em Nash misto. Extende Nash: todo NE é CE, mas não vice-versa. Computação de CE: programa linear (mais fácil que Nash).",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p_verde_verde", Nome = "Prob (V,V)", Descricao = "Probabilidade ambos recebem verde (colisão)", Unidade = "probabilidade", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "p_verde_vermelho", Nome = "Prob (V,R)", Descricao = "Probabilidade jog1 verde, jog2 vermelho", Unidade = "probabilidade", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "p_vermelho_verde", Nome = "Prob (R,V)", Descricao = "Probabilidade jog1 vermelho, jog2 verde", Unidade = "probabilidade", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "p_vermelho_vermelho", Nome = "Prob (R,R)", Descricao = "Probabilidade ambos vermelho (ineficiente)", Unidade = "probabilidade", ValorPadrao = 0, ValorMin = 0, ValorMax = 1, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double p_vv = valores["p_verde_verde"];
                    double p_vr = valores["p_verde_vermelho"];
                    double p_rv = valores["p_vermelho_verde"];
                    double p_rr = valores["p_vermelho_vermelho"];
                    double soma = p_vv + p_vr + p_rv + p_rr;
                    if (Math.Abs(soma - 1.0) > 0.001) throw new InvalidOperationException("Probabilidades devem somar 1");
                    // Payoffs típicos: (V,V)=-100 (acidente), (V,R)=1, (R,V)=1, (R,R)=0
                    double payoff_esperado = p_vv * (-100) + p_vr * 1 + p_rv * 1 + p_rr * 0;
                    return payoff_esperado; // CE eficiente tem p_vr=p_rv=0.5, p_vv=p_rr=0
                },
                VariavelResultado = "Payoff esperado",
                UnidadeResultado = "utils",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME015: Replicator Dynamics
        /// ẋᵢ = xᵢ·(fᵢ(x)−f̄(x))
        /// </summary>
        private Formula V9_GAME015_ReplicatorDynamics()
        {
            return new Formula
            {
                Id = "V9-GAME015",
                CodigoCompendio = "015",
                Nome = "Replicator Dynamics",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "ẋᵢ = xᵢ·(fᵢ(x)−f̄(x))",
                ExprTexto = "Estratégia acima fitness média cresce",
                Descricao = "Dinâmica evolutiva: fração xᵢ de estratégia i cresce se fitness fᵢ(x) acima da média f̄(x). Equação diferencial modela seleção natural em populações. Estratégias Evolutivamente Estáveis (ESS) são atratores assintoticamente estáveis. Base da teoria dos jogos evolutivos.",
                Criador = "Peter Taylor e Leo Jonker (1978, Evolutionary Stable Strategies and Game Dynamics)",
                AnoOrigin = "1978",
                ExemploPratico = "Falcões e Pombas: equilíbrio estável x*=V/C (V=valor recurso, C=custo luta). Evolução de cooperação: defector domina sem punição; cooperação com reciprocidade. Jogos evolutivos em ecologia, biologia comportamental, economia evolutiva. Aprende estratégias sem racionalidade.",
                Unidades = "1/tempo",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "x_falcao", Nome = "Fração falcões", Descricao = "Proporção da população agressiva (falcões)", Unidade = "fração", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "V", Nome = "Valor do recurso", Descricao = "Payoff por ganhar recurso", Unidade = "fitness", ValorPadrao = 4, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "C", Nome = "Custo da luta", Descricao = "Custo de luta entre falcões", Unidade = "fitness", ValorPadrao = 6, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double x_h = valores["x_falcao"];
                    double x_d = 1.0 - x_h; // fração pombas
                    double V = valores["V"];
                    double C = valores["C"];
                    // Payoff falcão: f_h = x_h*(V-C)/2 + x_d*V
                    double f_h = x_h * (V - C) / 2.0 + x_d * V;
                    // Payoff pomba: f_d = x_h*0 + x_d*V/2
                    double f_d = x_d * V / 2.0;
                    // Fitness média: f̄ = x_h*f_h + x_d*f_d
                    double f_bar = x_h * f_h + x_d * f_d;
                    // dx_h/dt = x_h*(f_h - f̄)
                    double dx_h_dt = x_h * (f_h - f_bar);
                    return dx_h_dt; // >0: falcões crescem; <0: pombas crescem; =0: equilíbrio
                },
                VariavelResultado = "Taxa crescimento falcões",
                UnidadeResultado = "Δfração/tempo",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME016: Estratégia Evolutivamente Estável (ESS)
        /// u(σ*,σ*)>u(σ,σ*) OU [iguais E u(σ*,σ)>u(σ,σ)]
        /// </summary>
        private Formula V9_GAME016_ESS()
        {
            return new Formula
            {
                Id = "V9-GAME016",
                CodigoCompendio = "016",
                Nome = "Estratégia Evolutivamente Estável (ESS)",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "u(σ*,σ*)>u(σ,σ*) OU u(σ*,σ)>u(σ,σ)",
                ExprTexto = "Resiste à invasão por mutantes raros",
                Descricao = "ESS de Maynard Smith: estratégia σ* resiste à invasão por mutantes raros. Condição: (1) u(σ*,σ*)≥u(σ,σ*) para toda σ, e (2) se igualdade, então u(σ*,σ)>u(σ,σ). ESS é subconjunto dos Nash simétricos e pontos estáveis de replicator dynamics. Conceito central em biologia evolutiva.",
                Criador = "John Maynard Smith e George R. Price (1973, The Logic of Animal Conflict, Nature)",
                AnoOrigin = "1973",
                ExemploPratico = "Pombo-Falcão: ESS misto x*=V/C quando C>V. Se C<V: falcão puro é ESS. Cooperação: defecção é ESS sem punição; cooperação com punição (Axelrod Tit-for-Tat) pode ser ESS. Guerra de atrito: ESS misto exponencial. Sinalização honesta: handicap principle de Zahavi.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "u_star_star", Nome = "u(σ*,σ*)", Descricao = "Payoff estratégia candidata vs si mesma", Unidade = "fitness", ValorPadrao = 3, Obrigatoria = true },
                    new Variavel { Simbolo = "u_mutante_star", Nome = "u(σ,σ*)", Descricao = "Payoff mutante vs estratégia incumbente", Unidade = "fitness", ValorPadrao = 2.5, Obrigatoria = true },
                    new Variavel { Simbolo = "u_star_mutante", Nome = "u(σ*,σ)", Descricao = "Payoff incumbente vs mutante", Unidade = "fitness", ValorPadrao = 3.5, Obrigatoria = true },
                    new Variavel { Simbolo = "u_mutante_mutante", Nome = "u(σ,σ)", Descricao = "Payoff mutante vs si mesmo", Unidade = "fitness", ValorPadrao = 2, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double u_ss = valores["u_star_star"];
                    double u_ms = valores["u_mutante_star"];
                    double u_sm = valores["u_star_mutante"];
                    double u_mm = valores["u_mutante_mutante"];
                    // Condição 1: u(σ*,σ*) ≥ u(σ,σ*)
                    bool condicao1 = u_ss >= u_ms;
                    // Condição 2: se igualdade, então u(σ*,σ) > u(σ,σ)
                    bool condicao2 = (Math.Abs(u_ss - u_ms) < 1e-9) ? (u_sm > u_mm) : true;
                    bool eh_ESS = condicao1 && condicao2;
                    return eh_ESS ? 1.0 : 0.0; // 1=é ESS, 0=não é ESS
                },
                VariavelResultado = "É ESS",
                UnidadeResultado = "booleano (1=sim, 0=não)",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME017: Solução de Barganha de Nash
        /// max (u₁−d₁)(u₂−d₂)
        /// </summary>
        private Formula V9_GAME017_BarganhaNash()
        {
            return new Formula
            {
                Id = "V9-GAME017",
                CodigoCompendio = "017",
                Nome = "Solução de Barganha de Nash",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "max (u₁−d₁)(u₂−d₂)",
                ExprTexto = "Produto das utilidades líquidas de desacordo",
                Descricao = "Barganha cooperativa de Nash: maximiza produto (u₁−d₁)(u₂−d₂) onde d=(d₁,d₂) é ponto de desacordo (fallback). Axiomas: simetria, eficiência de Pareto, independência de alternativas irrelevantes (IIA), invariância afim. Solução única dado fronteira de Pareto. Generaliza para n jogadores via n-produto.",
                Criador = "John Nash (1950, The Bargaining Problem, Econometrica)",
                AnoOrigin = "1950",
                ExemploPratico = "Negociação salarial: d=salário mínimo, s=salário máximo. Com poder igual: w*=(d+s)/2. Poder assimétrico: w*=argmax (w−d)^α(s−w)^{1-α} para α∈[0,1]. Divórcio: divisão de ativos via Nash bargaining. Arbitragem comercial: terceira parte aplica solução de Nash.",
                Unidades = "utils",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "u_1", Nome = "Utilidade jogador 1", Descricao = "Utilidade proposta para jogador 1", Unidade = "utils", ValorPadrao = 70, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "u_2", Nome = "Utilidade jogador 2", Descricao = "Utilidade proposta para jogador 2", Unidade = "utils", ValorPadrao = 60, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "d_1", Nome = "Desacordo jogador 1", Descricao = "Payoff de fallback jogador 1", Unidade = "utils", ValorPadrao = 20, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "d_2", Nome = "Desacordo jogador 2", Descricao = "Payoff de fallback jogador 2", Unidade = "utils", ValorPadrao = 10, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double u1 = valores["u_1"];
                    double u2 = valores["u_2"];
                    double d1 = valores["d_1"];
                    double d2 = valores["d_2"];
                    // Produto de Nash: (u₁−d₁)(u₂−d₂)
                    double produto_nash = (u1 - d1) * (u2 - d2);
                    return produto_nash; // maior produto = melhor acordo
                },
                VariavelResultado = "Produto de Nash",
                UnidadeResultado = "utils²",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME018: Desconto Hiperbólico - β-δ Model
        /// U=u₀+β·Σ_{t=1} δᵗ·u_t
        /// </summary>
        private Formula V9_GAME018_DescontoHiperbolico()
        {
            return new Formula
            {
                Id = "V9-GAME018",
                CodigoCompendio = "018",
                Nome = "Desconto Hiperbólico - β-δ Model",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "U=u₀+β·Σ_{t=1} δᵗ·u_t",
                ExprTexto = "β<1: sobrepeso do presente; inconsistência temporal",
                Descricao = "Modelo β-δ de Laibson: captura desconto hiperbólico via parâmetros β (present bias) e δ (desconto padrão). β<1 implica sobrepeso do presente: preferência hoje>amanhã maior que semana-que-vem>daqui-2-semanas. Inconsistência temporal: preferências mudam com passagem do tempo. Base de economia comportamental.",
                Criador = "David Laibson (1997, Golden Eggs and Hyperbolic Discounting); Ted O'Donoghue e Matthew Rabin (1999)",
                AnoOrigin = "1997",
                ExemploPratico = "β=0,7, δ=0,97: prefere 10 hoje a 11 amanhã (β·δ·11=7,37<10), mas prefere 11 daqui-8-dias a 10 daqui-7-dias (δ^7·10=8,1 vs δ^8·11=8,7). Procrastinação: tarefa custosa sempre adiada. Commitment devices: Christmas clubs, automatic savings. Nudges de Thaler.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "beta", Nome = "β present-bias", Descricao = "Fator de present bias β∈(0,1]", Unidade = "adimensional", ValorPadrao = 0.7, ValorMin = 0.01, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "delta", Nome = "δ desconto", Descricao = "Fator de desconto padrão δ∈(0,1)", Unidade = "adimensional", ValorPadrao = 0.97, ValorMin = 0.01, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "u_hoje", Nome = "Utilidade hoje", Descricao = "Payoff imediato u₀", Unidade = "utils", ValorPadrao = 10, Obrigatoria = true },
                    new Variavel { Simbolo = "u_futuro", Nome = "Utilidade futuro", Descricao = "Payoff t=1 (amanhã)", Unidade = "utils", ValorPadrao = 11, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double beta = valores["beta"];
                    double delta = valores["delta"];
                    double u0 = valores["u_hoje"];
                    double u1 = valores["u_futuro"];
                    // Valor presente percebido: U = u₀ + β·δ·u₁
                    double VP_hiperbolico = u0 + beta * delta * u1;
                    return VP_hiperbolico; // comparar opções: maior VP preferido
                },
                VariavelResultado = "Valor presente percebido",
                UnidadeResultado = "utils",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME019: Função de Utilidade Esperada - VNM
        /// U(L)=Σᵢ pᵢ·u(xᵢ)
        /// </summary>
        private Formula V9_GAME019_UtilidadeEsperadaVNM()
        {
            return new Formula
            {
                Id = "V9-GAME019",
                CodigoCompendio = "019",
                Nome = "Função de Utilidade Esperada - VNM",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "U(L)=Σᵢ pᵢ·u(xᵢ)",
                ExprTexto = "Utilidade esperada de loteria",
                Descricao = "Axiomas de von Neumann-Morgenstern: completude, transitividade, continuidade, independência implicam representação de preferências por utilidade esperada. Avesso ao risco: u côncava. Neutro: u linear. Prêmio de risco: π=½σ²(-u''/u'). Base da teoria da decisão sob incerteza.",
                Criador = "John von Neumann e Oskar Morgenstern (1944, Theory of Games and Economic Behavior)",
                AnoOrigin = "1944",
                ExemploPratico = "u(x)=√x: avesso ao risco. Loteria 50-50: {0,100}. U(L)=0,5·√0+0,5·√100=5. Equivalente-certeza CE: u(CE)=5 → CE=25. Prêmio de risco π=50-25=25. Paradoxo de Allais viola independência. Prospect theory de Kahneman-Tversky corrige viés.",
                Unidades = "utils",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p_1", Nome = "Probabilidade resultado 1", Descricao = "Probabilidade do primeiro resultado", Unidade = "probabilidade", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "x_1", Nome = "Resultado 1", Descricao = "Payoff do primeiro resultado", Unidade = "$", ValorPadrao = 0, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "p_2", Nome = "Probabilidade resultado 2", Descricao = "Probabilidade do segundo resultado", Unidade = "probabilidade", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1, Obrigatoria = true },
                    new Variavel { Simbolo = "x_2", Nome = "Resultado 2", Descricao = "Payoff do segundo resultado", Unidade = "$", ValorPadrao = 100, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double p1 = valores["p_1"];
                    double x1 = valores["x_1"];
                    double p2 = valores["p_2"];
                    double x2 = valores["x_2"];
                    if (Math.Abs(p1 + p2 - 1.0) > 0.001) throw new InvalidOperationException("Probabilidades devem somar 1");
                    // Utilidade u(x)=√x (avesso ao risco)
                    double u1 = Math.Sqrt(x1);
                    double u2 = Math.Sqrt(x2);
                    // Utilidade esperada: U(L) = Σ pᵢ·u(xᵢ)
                    double utilidade_esperada = p1 * u1 + p2 * u2;
                    return utilidade_esperada;
                },
                VariavelResultado = "Utilidade esperada U(L)",
                UnidadeResultado = "utils",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME020: Índice de Poder de Votação - Banzhaf
        /// βᵢ = (swings de i)/(total de swings)
        /// </summary>
        private Formula V9_GAME020_PoderBanzhaf()
        {
            return new Formula
            {
                Id = "V9-GAME020",
                CodigoCompendio = "020",
                Nome = "Índice de Poder de Votação - Banzhaf",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "βᵢ = (swings de i)/(total de swings)",
                ExprTexto = "Poder = fração de vezes que voto é pivotal",
                Descricao = "Índice de Banzhaf: poder de votação βᵢ = proporção de coalizões onde jogador i é pivotal (swing vote). Swing: coalizão passa de perdedora para vencedora com inclusão de i. Poder≠peso de voto. Alternativa: Shapley-Shubik (ordem sequencial). Detecta poder desproporcional em conselhos.",
                Criador = "John F. Banzhaf III (1965, Weighted Voting Doesn't Work: A Mathematical Analysis)",
                AnoOrigin = "1965",
                ExemploPratico = "Conselho de Segurança da ONU: P5 (EUA, Rússia, China, França, UK) têm veto. Poder de Banzhaf de cada P5 ≈20% apesar de haver 15 membros. País grande na UE: poder desproporcional ao peso populacional. Nassau County Board caso histórico de desigualdade de voto.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "swings_jogador", Nome = "Swings do jogador", Descricao = "Número de coalizões onde jogador é pivotal", Unidade = "contagem", ValorPadrao = 6, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "total_swings", Nome = "Total de swings", Descricao = "Soma de swings de todos jogadores", Unidade = "contagem", ValorPadrao = 30, ValorMin = 1, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double swings_i = valores["swings_jogador"];
                    double total = valores["total_swings"];
                    double poder_banzhaf = swings_i / total;
                    return poder_banzhaf; // poder normalizado ∈[0,1]
                },
                VariavelResultado = "Poder de Banzhaf βᵢ",
                UnidadeResultado = "fração",
                Icone = "∑",
            };
        }

        /// <summary>
        /// V9_GAME021: Leilão de Clock Ascending - Eficiência
        /// Vencedor=maior valoração; e=1 se sinalização perfeita
        /// </summary>
        private Formula V9_GAME021_LeilaoClockAscending()
        {
            return new Formula
            {
                Id = "V9-GAME021",
                CodigoCompendio = "021",
                Nome = "Leilão de Clock Ascending - Eficiência",
                Categoria = "Volume IX",
                SubCategoria = "Teoria dos Jogos",
                Expressao = "e=1 (eficiente); Vencedor=max vᵢ",
                ExprTexto = "Leilão ascendente revela informação dinamicamente",
                Descricao = "Leilão de relógio ascendente (clock auction): preço sobe continuamente, participantes saem quando preço excede valoração. Último remanescente ganha pagando preço final. Eficiente com valores privados independentes: vencedor=maior valoração. Revela informação gradualmente. Linkage principle de Milgrom-Weber: maior receita com valores correlacionados.",
                Criador = "Paul Milgrom e Robert Weber (1982, A Theory of Auctions and Competitive Bidding, Econometrica)",
                AnoOrigin = "1982",
                ExemploPratico = "Leilão ascendente inglês de arte: comprador vai saindo conforme preço sobe. FCC spectrum auctions: simultaneous ascending auction para alocação de espectro de rádio. Linkage: se valores correlacionados (common value component), leilão ascendente gera mais receita que lacrado por revelar info.",
                Unidades = "adimensional",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v_max", Nome = "Valoração máxima", Descricao = "Maior valoração entre participantes", Unidade = "valor", ValorPadrao = 100, ValorMin = 0, Obrigatoria = true },
                    new Variavel { Simbolo = "v_segundo", Nome = "Segunda valoração", Descricao = "Segunda maior valoração", Unidade = "valor", ValorPadrao = 85, ValorMin = 0, Obrigatoria = true }
                },
                Calcular = valores =>
                {
                    double v_segundo = valores["v_segundo"];
                    // Leilão ascendente: preço sobe até v_segundo (segundo lugar sai)
                    // Vencedor paga aproximadamente v_segundo (preço final)
                    double preco_venda = v_segundo;
                    return preco_venda; // preço de venda ≈ segunda maior valoração
                },
                VariavelResultado = "Preço de venda",
                UnidadeResultado = "valor",
                Icone = "∑",
            };
        }
    }
}
