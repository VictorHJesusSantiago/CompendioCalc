using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using CompendioCalc.Models;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private sealed record Vol15Spec(
            string Codigo,
            string Nome,
            string Expressao,
            string Descricao,
            string Origem,
            string Exemplo,
            string Categoria,
            string SubCategoria);

        private sealed record Vol15Override(
            string Expressao,
            string VariavelResultado,
            string UnidadeResultado,
            List<Variavel> Variaveis,
            Func<Dictionary<string, double>, double>? Calculadora = null);

        private static readonly Regex Vol15SimboloRegex = new(@"[A-Za-z_][A-Za-z0-9_]*", RegexOptions.Compiled);
        private static readonly HashSet<string> Vol15Ignorar = new(StringComparer.OrdinalIgnoreCase)
        {
            "resultado", "sin", "cos", "tan", "asin", "acos", "atan", "sqrt", "log", "log2", "ln", "exp", "abs", "min", "max", "pow", "erfc", "qfunc", "pi", "e"
        };

        private static readonly Dictionary<string, Vol15Override> Vol15Overrides = new(StringComparer.Ordinal)
        {
            ["005"] = new(
                "sqrt(1.5)*sqrt(sum_lambda_dev2)/sqrt(sum_lambda2)",
                "FA",
                "adim",
                [
                    NovaVariavelVol15("sum_lambda_dev2", "Soma dos desvios quadráticos", "Somatório de (lambda_i - lambda_med)^2 da decomposição tensorial."),
                    NovaVariavelVol15("sum_lambda2", "Soma dos autovalores ao quadrado", "Somatório de lambda_i^2 do tensor de difusão.")
                ]),
            ["006"] = new(
                "c_beta_hat/sqrt(c_xtx_inv_ct*sigma2)",
                "t",
                "adim",
                [
                    NovaVariavelVol15("c_beta_hat", "Contraste estimado", "Produto do contraste c pelo vetor beta estimado."),
                    NovaVariavelVol15("c_xtx_inv_ct", "Variância do contraste", "Termo c(X'X)^-1 c' do GLM fMRI."),
                    NovaVariavelVol15("sigma2", "Variância residual", "Estimativa da variância residual sigma^2 do modelo.")
                ]),
            ["008"] = new(
                "(ct_cp_ratio-v0)/int_cp_over_cp",
                "Ki",
                "adim",
                [
                    NovaVariavelVol15("ct_cp_ratio", "Razão C_t/C_p", "Razão instantânea entre a concentração tecidual e a plasmática."),
                    NovaVariavelVol15("v0", "Intercepto V0", "Volume aparente de distribuição do ajuste de Patlak."),
                    NovaVariavelVol15("int_cp_over_cp", "Integral normalizada", "Termo integral_0^t C_p(tau) dt dividido por C_p(t).")
                ]),
            ["009"] = new(
                "0.5*ln((1+r)/(1-r))",
                "Z",
                "adim",
                [
                    NovaVariavelVol15("r", "Correlação de Pearson", "Correlação funcional entre duas séries temporais de ROIs.")
                ]),
            ["010"] = new(
                "p_proj/(4*pi*sigma*r^2)",
                "V",
                "V",
                [
                    NovaVariavelVol15("p_proj", "Momento dipolar projetado", "Componente do dipolo neuronal projetada na direção do sensor EEG."),
                    NovaVariavelVol15("sigma", "Condutividade", "Condutividade efetiva do meio intracraniano.", "S/m", 0.33),
                    NovaVariavelVol15("r", "Distância fonte-sensor", "Distância efetiva entre a fonte dipolar e o eletrodo.", "m", 0.05)
                ]),
            ["011"] = new(
                "mu0*m_cross/(4*pi*r^2)",
                "B",
                "T",
                [
                    NovaVariavelVol15("mu0", "Permeabilidade do vácuo", "Constante magnética mu0.", "H/m", 1.25663706212e-6),
                    NovaVariavelVol15("m_cross", "Momento dipolar transversal", "Componente transversal efetiva do dipolo neuronal para o sensor MEG."),
                    NovaVariavelVol15("r", "Distância fonte-sensor", "Distância efetiva entre a fonte dipolar e o sensor MEG.", "m", 0.05)
                ]),
            ["012"] = new(
                "s1",
                "s1",
                "adim",
                [
                    NovaVariavelVol15("w11", "Peso ICA 1", "Peso do primeiro voxel/sinal na componente independente estimada.", valorPadrao: 0.8),
                    NovaVariavelVol15("x1", "Sinal observado 1", "Primeira entrada observada do vetor X.", valorPadrao: 1),
                    NovaVariavelVol15("w12", "Peso ICA 2", "Peso do segundo voxel/sinal na componente independente estimada.", valorPadrao: -0.3),
                    NovaVariavelVol15("x2", "Sinal observado 2", "Segunda entrada observada do vetor X.", valorPadrao: 0.5),
                    NovaVariavelVol15("w13", "Peso ICA 3", "Peso do terceiro voxel/sinal na componente independente estimada.", valorPadrao: 0.2),
                    NovaVariavelVol15("x3", "Sinal observado 3", "Terceira entrada observada do vetor X.", valorPadrao: 0.2),
                    NovaVariavelVol15("w14", "Peso ICA 4", "Peso do quarto voxel/sinal na componente independente estimada.", valorPadrao: -0.1),
                    NovaVariavelVol15("x4", "Sinal observado 4", "Quarta entrada observada do vetor X.", valorPadrao: 0.1)
                ],
                vars =>
                    ValorVariavelVol15(vars, "w11", 0.8) * ValorVariavelVol15(vars, "x1", 1)
                    + ValorVariavelVol15(vars, "w12", -0.3) * ValorVariavelVol15(vars, "x2", 0.5)
                    + ValorVariavelVol15(vars, "w13", 0.2) * ValorVariavelVol15(vars, "x3", 0.2)
                    + ValorVariavelVol15(vars, "w14", -0.1) * ValorVariavelVol15(vars, "x4", 0.1)),
            ["015"] = new(
                "path_probability",
                "P",
                "adim",
                [
                    NovaVariavelVol15("path_probability", "Probabilidade do trajeto", "Probabilidade total acumulada do caminho na tractografia probabilística.")
                ]),
            ["018"] = new(
                "sqrt(sum_cos^2+sum_sin^2)/n",
                "PLV",
                "adim",
                [
                    NovaVariavelVol15("sum_cos", "Soma das componentes cossenoidais", "Somatório de cos(delta_phi(t)) sobre a janela temporal."),
                    NovaVariavelVol15("sum_sin", "Soma das componentes seno", "Somatório de sin(delta_phi(t)) sobre a janela temporal."),
                    NovaVariavelVol15("n", "Número de amostras", "Quantidade de instantes usados no cálculo do phase locking value.")
                ]),
            ["053"] = new(
                "exp(-(w1*aa1+w2*aa2+w3*aa3+w4*aa4+w5*aa5+w6*aa6+w7*aa7+w8*aa8+w9*aa9))",
                "IC50_MHC",
                "nM",
                [
                    NovaVariavelVol15("w1", "Peso posição 1", "Peso da matriz posicional para o primeiro aminoácido.", valorPadrao: 0.35),
                    NovaVariavelVol15("aa1", "Score AA 1", "Contribuição do aminoácido na posição 1.", valorPadrao: 1),
                    NovaVariavelVol15("w2", "Peso posição 2", "Peso da matriz posicional para a posição 2.", valorPadrao: 0.22),
                    NovaVariavelVol15("aa2", "Score AA 2", "Contribuição do aminoácido na posição 2.", valorPadrao: 0.8),
                    NovaVariavelVol15("w3", "Peso posição 3", "Peso da matriz posicional para a posição 3.", valorPadrao: 0.30),
                    NovaVariavelVol15("aa3", "Score AA 3", "Contribuição do aminoácido na posição 3.", valorPadrao: 1.2),
                    NovaVariavelVol15("w4", "Peso posição 4", "Peso da matriz posicional para a posição 4.", valorPadrao: 0.28),
                    NovaVariavelVol15("aa4", "Score AA 4", "Contribuição do aminoácido na posição 4.", valorPadrao: 1),
                    NovaVariavelVol15("w5", "Peso posição 5", "Peso da matriz posicional para a posição 5.", valorPadrao: 0.40),
                    NovaVariavelVol15("aa5", "Score AA 5", "Contribuição do aminoácido na posição 5.", valorPadrao: 1),
                    NovaVariavelVol15("w6", "Peso posição 6", "Peso da matriz posicional para a posição 6.", valorPadrao: 0.18),
                    NovaVariavelVol15("aa6", "Score AA 6", "Contribuição do aminoácido na posição 6.", valorPadrao: 0.9),
                    NovaVariavelVol15("w7", "Peso posição 7", "Peso da matriz posicional para a posição 7.", valorPadrao: 0.25),
                    NovaVariavelVol15("aa7", "Score AA 7", "Contribuição do aminoácido na posição 7.", valorPadrao: 1),
                    NovaVariavelVol15("w8", "Peso posição 8", "Peso da matriz posicional para a posição 8.", valorPadrao: 0.20),
                    NovaVariavelVol15("aa8", "Score AA 8", "Contribuição do aminoácido na posição 8.", valorPadrao: 0.85),
                    NovaVariavelVol15("w9", "Peso posição 9", "Peso da matriz posicional para a posição 9.", valorPadrao: 0.26),
                    NovaVariavelVol15("aa9", "Score AA 9", "Contribuição do aminoácido na posição 9.", valorPadrao: 1.1)
                ]),
            ["059"] = new(
                "1+((n1*2^1+n2*2^2+n3*2^3+n4*2^4)/n0)",
                "PI",
                "adim",
                [
                    NovaVariavelVol15("n0", "Células sem divisão", "Número de células na geração inicial (sem divisão).", valorPadrao: 1000),
                    NovaVariavelVol15("n1", "Células divisão 1", "Número de células na primeira divisão.", valorPadrao: 400),
                    NovaVariavelVol15("n2", "Células divisão 2", "Número de células na segunda divisão.", valorPadrao: 250),
                    NovaVariavelVol15("n3", "Células divisão 3", "Número de células na terceira divisão.", valorPadrao: 140),
                    NovaVariavelVol15("n4", "Células divisão 4", "Número de células na quarta divisão.", valorPadrao: 70)
                ]),
            ["060"] = new(
                "max(0,1-(p1+p2+p3+p4))",
                "P_escape",
                "adim",
                [
                    NovaVariavelVol15("p1", "Neutralização variante 1", "Probabilidade de neutralização da primeira variante monitorada.", valorPadrao: 0.15),
                    NovaVariavelVol15("p2", "Neutralização variante 2", "Probabilidade de neutralização da segunda variante monitorada.", valorPadrao: 0.20),
                    NovaVariavelVol15("p3", "Neutralização variante 3", "Probabilidade de neutralização da terceira variante monitorada.", valorPadrao: 0.18),
                    NovaVariavelVol15("p4", "Neutralização variante 4", "Probabilidade de neutralização da quarta variante monitorada.", valorPadrao: 0.17)
                ]),
            ["063"] = new(
                "xg1+xg2+xg3+xg4+xg5",
                "xG",
                "gols",
                [
                    NovaVariavelVol15("xg1", "xG chance 1", "Probabilidade de gol da primeira finalização.", valorPadrao: 0.25),
                    NovaVariavelVol15("xg2", "xG chance 2", "Probabilidade de gol da segunda finalização.", valorPadrao: 0.12),
                    NovaVariavelVol15("xg3", "xG chance 3", "Probabilidade de gol da terceira finalização.", valorPadrao: 0.08),
                    NovaVariavelVol15("xg4", "xG chance 4", "Probabilidade de gol da quarta finalização.", valorPadrao: 0.32),
                    NovaVariavelVol15("xg5", "xG chance 5", "Probabilidade de gol da quinta finalização.", valorPadrao: 0.10)
                ]),
            ["065"] = new(
                "p0+k1*g-k2*h",
                "p",
                "adim",
                [
                    NovaVariavelVol15("p0", "Desempenho basal", "Nível basal de desempenho do atleta.", valorPadrao: 50),
                    NovaVariavelVol15("k1", "Ganho de fitness", "Coeficiente de contribuição do estado de forma.", valorPadrao: 1.2),
                    NovaVariavelVol15("g", "Componente fitness", "Componente acumulada de forma derivada dos TRIMPs recentes.", valorPadrao: 22),
                    NovaVariavelVol15("k2", "Ganho de fadiga", "Coeficiente de contribuição da fadiga.", valorPadrao: 0.9),
                    NovaVariavelVol15("h", "Componente fadiga", "Componente acumulada de fadiga de curto prazo.", valorPadrao: 12)
                ]),
            ["075"] = new(
                "d1*v1+d2*v2+d3*v3+d4*v4+Ligacoes+Bonus",
                "Dscore",
                "pontos",
                [
                    NovaVariavelVol15("d1", "Dificuldade 1", "Dificuldade do primeiro elemento da rotina.", valorPadrao: 0.7),
                    NovaVariavelVol15("v1", "Valor 1", "Peso efetivo do primeiro elemento.", valorPadrao: 1),
                    NovaVariavelVol15("d2", "Dificuldade 2", "Dificuldade do segundo elemento da rotina.", valorPadrao: 0.8),
                    NovaVariavelVol15("v2", "Valor 2", "Peso efetivo do segundo elemento.", valorPadrao: 1),
                    NovaVariavelVol15("d3", "Dificuldade 3", "Dificuldade do terceiro elemento da rotina.", valorPadrao: 0.9),
                    NovaVariavelVol15("v3", "Valor 3", "Peso efetivo do terceiro elemento.", valorPadrao: 1),
                    NovaVariavelVol15("d4", "Dificuldade 4", "Dificuldade do quarto elemento da rotina.", valorPadrao: 1.0),
                    NovaVariavelVol15("v4", "Valor 4", "Peso efetivo do quarto elemento.", valorPadrao: 1),
                    NovaVariavelVol15("Ligacoes", "Bônus de ligação", "Bônus por conexões válidas entre elementos.", valorPadrao: 0.6),
                    NovaVariavelVol15("Bonus", "Bônus adicional", "Bônus adicionais previstos no código de pontos.", valorPadrao: 0.3)
                ]),
            ["086"] = new(
                "sqrt((a/sqrt(E))^2+(b/E)^2+c^2)",
                "sigma_E_rel",
                "adim",
                [
                    NovaVariavelVol15("a", "Termo estocástico", "Contribuição estatística que escala com 1/sqrt(E)."),
                    NovaVariavelVol15("b", "Termo de ruído", "Contribuição eletrônica ou instrumental que escala com 1/E."),
                    NovaVariavelVol15("c", "Termo constante", "Contribuição sistemática residual da resolução."),
                    NovaVariavelVol15("E", "Energia", "Energia depositada ou reconstruída no calorímetro.")
                ]),
            ["088"] = new(
                "acos(1/(beta*n))",
                "theta_c",
                "rad",
                [
                    NovaVariavelVol15("beta", "Velocidade normalizada", "Razão v/c da partícula incidente."),
                    NovaVariavelVol15("n", "Índice de refração", "Índice de refração do meio onde ocorre a emissão Cherenkov.")
                ]),
            ["095"] = new(
                "S/sqrt(S+B)",
                "Z",
                "adim",
                [
                    NovaVariavelVol15("S", "Sinal esperado", "Contagem ou rendimento esperado do sinal."),
                    NovaVariavelVol15("B", "Fundo esperado", "Contagem ou rendimento esperado do fundo.")
                ]),
            ["213"] = new(
                "sqrt(sum_delta_b2)",
                "deltaV",
                "adim",
                [
                    NovaVariavelVol15("sum_delta_b2", "Soma das diferenças quadráticas", "Somatório de (b_i_t1 - b_i_t2)^2 entre as bandas comparadas."),
                    NovaVariavelVol15("delta_b1", "Diferença na banda 1", "Diferença espectral da primeira banda usada para o ângulo de mudança."),
                    NovaVariavelVol15("delta_b2", "Diferença na banda 2", "Diferença espectral da segunda banda usada para o ângulo de mudança.")
                ]),
            ["203"] = new(
                "sqrt(sum_cos^2+sum_sin^2)",
                "F_mag",
                "adim",
                [
                    NovaVariavelVol15("sum_cos", "Soma da componente cosseno", "Somatório real ponderado da FFT 2D para o par (u,v)."),
                    NovaVariavelVol15("sum_sin", "Soma da componente seno", "Somatório imaginário ponderado da FFT 2D para o par (u,v).")
                ]),
            ["204"] = new(
                "w_dot_x+b",
                "f",
                "adim",
                [
                    NovaVariavelVol15("w_dot_x", "Produto interno w.x", "Produto interno entre o vetor de pesos e o vetor de atributos do pixel."),
                    NovaVariavelVol15("b", "Bias", "Intercepto do hiperplano separador.")
                ]),
            ["206"] = new(
                "(rho_toa/t_down-t_up-rho_path)/(t_up*t_down+s*(rho_path-rho_toa/t_down))",
                "rho_superficie",
                "adim",
                [
                    NovaVariavelVol15("rho_toa", "Reflectância TOA", "Reflectância no topo da atmosfera."),
                    NovaVariavelVol15("t_down", "Transmitância descendente", "Transmitância atmosférica no caminho Sol-superfície.", "adim", 1),
                    NovaVariavelVol15("t_up", "Transmitância ascendente", "Transmitância atmosférica no caminho superfície-sensor.", "adim", 1),
                    NovaVariavelVol15("rho_path", "Reflectância de caminho", "Termo de espalhamento atmosférico no caminho óptico."),
                    NovaVariavelVol15("s", "Albedo esférico", "Parâmetro de múltiplo espalhamento do modelo 6S.")
                ]),
            ["211"] = new(
                "C0+C*(1-exp(-3*h/a))",
                "gamma_h",
                "adim",
                [
                    NovaVariavelVol15("C0", "Pepita", "Efeito pepita do semivariograma."),
                    NovaVariavelVol15("C", "Patamar estrutural", "Contribuição estrutural da variância espacial."),
                    NovaVariavelVol15("h", "Distância", "Lag espacial entre amostras."),
                    NovaVariavelVol15("a", "Alcance", "Parâmetro de alcance do modelo exponencial.")
                ]),
            ["216"] = new(
                "a*(CHM_mean^b)*(Densidade_pulsos^c)",
                "AGB",
                "Mg/ha",
                [
                    NovaVariavelVol15("a", "Coeficiente a", "Coeficiente de calibração alométrica do bioma."),
                    NovaVariavelVol15("CHM_mean", "Altura média do dossel", "Canopy Height Model médio da área.", "m", 25),
                    NovaVariavelVol15("b", "Expoente b", "Expoente alométrico da altura do dossel."),
                    NovaVariavelVol15("Densidade_pulsos", "Densidade de pulsos", "Densidade LiDAR em pulsos por metro quadrado.", "pts/m2", 10),
                    NovaVariavelVol15("c", "Expoente c", "Expoente associado à densidade de pulsos.")
                ]),
            ["217"] = new(
                "BT/(1+((lambda*BT)/rho)*ln(epsilon))",
                "LST",
                "K",
                [
                    NovaVariavelVol15("BT", "Temperatura de brilho", "Brightness temperature da banda térmica.", "K", 300),
                    NovaVariavelVol15("lambda", "Comprimento de onda", "Comprimento de onda efetivo da banda térmica.", "um", 10.9),
                    NovaVariavelVol15("rho", "Constante radiométrica", "Constante hc/kB do modelo simplificado.", "um*K", 14380),
                    NovaVariavelVol15("epsilon", "Emissividade", "Emissividade de superfície.", "adim", 0.98)
                ]),
            ["223"] = new(
                "I_xy",
                "I_xy",
                "bits",
                [
                    NovaVariavelVol15("p11", "P(X1,Y1)", "Probabilidade conjunta da primeira combinação de símbolos.", valorPadrao: 0.4),
                    NovaVariavelVol15("p12", "P(X1,Y2)", "Probabilidade conjunta da segunda combinação de símbolos.", valorPadrao: 0.1),
                    NovaVariavelVol15("p21", "P(X2,Y1)", "Probabilidade conjunta da terceira combinação de símbolos.", valorPadrao: 0.1),
                    NovaVariavelVol15("p22", "P(X2,Y2)", "Probabilidade conjunta da quarta combinação de símbolos.", valorPadrao: 0.4)
                ],
                vars =>
                {
                    var p11 = ValorVariavelVol15(vars, "p11", 0.4);
                    var p12 = ValorVariavelVol15(vars, "p12", 0.1);
                    var p21 = ValorVariavelVol15(vars, "p21", 0.1);
                    var p22 = ValorVariavelVol15(vars, "p22", 0.4);
                    var px1 = p11 + p12;
                    var px2 = p21 + p22;
                    var py1 = p11 + p21;
                    var py2 = p12 + p22;
                    return MutualInformationTermVol15(p11, px1, py1)
                        + MutualInformationTermVol15(p12, px1, py2)
                        + MutualInformationTermVol15(p21, px2, py1)
                        + MutualInformationTermVol15(p22, px2, py2);
                }),
            ["224"] = new(
                "L_Huffman",
                "L_Huffman",
                "bits/simbolo",
                [
                    NovaVariavelVol15("p1", "Probabilidade símbolo 1", "Probabilidade do primeiro símbolo.", valorPadrao: 0.4),
                    NovaVariavelVol15("l1", "Comprimento código 1", "Comprimento do código de Huffman do primeiro símbolo.", valorPadrao: 1),
                    NovaVariavelVol15("p2", "Probabilidade símbolo 2", "Probabilidade do segundo símbolo.", valorPadrao: 0.3),
                    NovaVariavelVol15("l2", "Comprimento código 2", "Comprimento do código de Huffman do segundo símbolo.", valorPadrao: 2),
                    NovaVariavelVol15("p3", "Probabilidade símbolo 3", "Probabilidade do terceiro símbolo.", valorPadrao: 0.2),
                    NovaVariavelVol15("l3", "Comprimento código 3", "Comprimento do código de Huffman do terceiro símbolo.", valorPadrao: 3),
                    NovaVariavelVol15("p4", "Probabilidade símbolo 4", "Probabilidade do quarto símbolo.", valorPadrao: 0.1),
                    NovaVariavelVol15("l4", "Comprimento código 4", "Comprimento do código de Huffman do quarto símbolo.", valorPadrao: 3)
                ],
                vars =>
                    ValorVariavelVol15(vars, "p1", 0.4) * ValorVariavelVol15(vars, "l1", 1)
                    + ValorVariavelVol15(vars, "p2", 0.3) * ValorVariavelVol15(vars, "l2", 2)
                    + ValorVariavelVol15(vars, "p3", 0.2) * ValorVariavelVol15(vars, "l3", 3)
                    + ValorVariavelVol15(vars, "p4", 0.1) * ValorVariavelVol15(vars, "l4", 3)),
            ["225"] = new(
                "(2^m-1-m)/(2^m-1)",
                "taxa",
                "adim",
                [
                    NovaVariavelVol15("m", "Bits de paridade", "Número de bits de paridade do código de Hamming.", valorPadrao: 3)
                ]),
            ["226"] = new(
                "C_ergodic",
                "C_ergodic",
                "bps/Hz",
                [
                    NovaVariavelVol15("SNR", "Razão sinal-ruído média", "SNR linear média do canal com fading.", valorPadrao: 10),
                    NovaVariavelVol15("h1_sq", "|h1|²", "Primeira realização do ganho instantâneo do canal ao quadrado.", valorPadrao: 0.3),
                    NovaVariavelVol15("h2_sq", "|h2|²", "Segunda realização do ganho instantâneo do canal ao quadrado.", valorPadrao: 0.8),
                    NovaVariavelVol15("h3_sq", "|h3|²", "Terceira realização do ganho instantâneo do canal ao quadrado.", valorPadrao: 1.2),
                    NovaVariavelVol15("h4_sq", "|h4|²", "Quarta realização do ganho instantâneo do canal ao quadrado.", valorPadrao: 2.0)
                ],
                vars =>
                {
                    var snr = Math.Max(ValorVariavelVol15(vars, "SNR", 10), 0);
                    return (Math.Log2(1 + snr * Math.Max(ValorVariavelVol15(vars, "h1_sq", 0.3), 0))
                        + Math.Log2(1 + snr * Math.Max(ValorVariavelVol15(vars, "h2_sq", 0.8), 0))
                        + Math.Log2(1 + snr * Math.Max(ValorVariavelVol15(vars, "h3_sq", 1.2), 0))
                        + Math.Log2(1 + snr * Math.Max(ValorVariavelVol15(vars, "h4_sq", 2.0), 0))) / 4.0;
                }),
            ["228"] = new(
                "DKL",
                "DKL",
                "nats",
                [
                    NovaVariavelVol15("p1", "P1", "Probabilidade da distribuição P para o primeiro símbolo.", valorPadrao: 0.4),
                    NovaVariavelVol15("q1", "Q1", "Probabilidade da distribuição Q para o primeiro símbolo.", valorPadrao: 0.3),
                    NovaVariavelVol15("p2", "P2", "Probabilidade da distribuição P para o segundo símbolo.", valorPadrao: 0.3),
                    NovaVariavelVol15("q2", "Q2", "Probabilidade da distribuição Q para o segundo símbolo.", valorPadrao: 0.3),
                    NovaVariavelVol15("p3", "P3", "Probabilidade da distribuição P para o terceiro símbolo.", valorPadrao: 0.2),
                    NovaVariavelVol15("q3", "Q3", "Probabilidade da distribuição Q para o terceiro símbolo.", valorPadrao: 0.25),
                    NovaVariavelVol15("p4", "P4", "Probabilidade da distribuição P para o quarto símbolo.", valorPadrao: 0.1),
                    NovaVariavelVol15("q4", "Q4", "Probabilidade da distribuição Q para o quarto símbolo.", valorPadrao: 0.15)
                ],
                vars => RelativeEntropyTermVol15(ValorVariavelVol15(vars, "p1", 0.4), ValorVariavelVol15(vars, "q1", 0.3))
                    + RelativeEntropyTermVol15(ValorVariavelVol15(vars, "p2", 0.3), ValorVariavelVol15(vars, "q2", 0.3))
                    + RelativeEntropyTermVol15(ValorVariavelVol15(vars, "p3", 0.2), ValorVariavelVol15(vars, "q3", 0.25))
                    + RelativeEntropyTermVol15(ValorVariavelVol15(vars, "p4", 0.1), ValorVariavelVol15(vars, "q4", 0.15))),
            ["229"] = new(
                "parity_ok",
                "parity_ok",
                "adim",
                [
                    NovaVariavelVol15("c1", "Bit 1", "Primeiro bit do código transmitido.", valorPadrao: 1),
                    NovaVariavelVol15("c2", "Bit 2", "Segundo bit do código transmitido.", valorPadrao: 0),
                    NovaVariavelVol15("c3", "Bit 3", "Terceiro bit do código transmitido.", valorPadrao: 1),
                    NovaVariavelVol15("c4", "Bit 4", "Quarto bit do código transmitido.", valorPadrao: 1),
                    NovaVariavelVol15("c5", "Bit 5", "Quinto bit do código transmitido.", valorPadrao: 0),
                    NovaVariavelVol15("c6", "Bit 6", "Sexto bit do código transmitido.", valorPadrao: 1)
                ],
                vars =>
                {
                    var s1 = BitVol15(vars, "c1") ^ BitVol15(vars, "c2") ^ BitVol15(vars, "c4");
                    var s2 = BitVol15(vars, "c2") ^ BitVol15(vars, "c3") ^ BitVol15(vars, "c5");
                    var s3 = BitVol15(vars, "c1") ^ BitVol15(vars, "c3") ^ BitVol15(vars, "c6");
                    return (s1 | s2 | s3) == 0 ? 1d : 0d;
                }),
            ["230"] = new(
                "t",
                "t",
                "simbolos",
                [
                    NovaVariavelVol15("n", "Comprimento do código", "Número total de símbolos do código Reed-Solomon.", valorPadrao: 255),
                    NovaVariavelVol15("k", "Símbolos de dados", "Número de símbolos de informação do código Reed-Solomon.", valorPadrao: 223)
                ],
                vars =>
                {
                    var n = Math.Round(ValorVariavelVol15(vars, "n", 255));
                    var k = Math.Round(ValorVariavelVol15(vars, "k", 223));
                    return Math.Max(0, (n - k) / 2.0);
                }),
            ["239"] = new(
                "dH",
                "dH",
                "bits",
                [
                    NovaVariavelVol15("x1", "Bit x1", "Primeiro bit da palavra x.", valorPadrao: 1),
                    NovaVariavelVol15("y1", "Bit y1", "Primeiro bit da palavra y.", valorPadrao: 1),
                    NovaVariavelVol15("x2", "Bit x2", "Segundo bit da palavra x.", valorPadrao: 0),
                    NovaVariavelVol15("y2", "Bit y2", "Segundo bit da palavra y.", valorPadrao: 1),
                    NovaVariavelVol15("x3", "Bit x3", "Terceiro bit da palavra x.", valorPadrao: 1),
                    NovaVariavelVol15("y3", "Bit y3", "Terceiro bit da palavra y.", valorPadrao: 1),
                    NovaVariavelVol15("x4", "Bit x4", "Quarto bit da palavra x.", valorPadrao: 0),
                    NovaVariavelVol15("y4", "Bit y4", "Quarto bit da palavra y.", valorPadrao: 0),
                    NovaVariavelVol15("x5", "Bit x5", "Quinto bit da palavra x.", valorPadrao: 1),
                    NovaVariavelVol15("y5", "Bit y5", "Quinto bit da palavra y.", valorPadrao: 1),
                    NovaVariavelVol15("x6", "Bit x6", "Sexto bit da palavra x.", valorPadrao: 0),
                    NovaVariavelVol15("y6", "Bit y6", "Sexto bit da palavra y.", valorPadrao: 0),
                    NovaVariavelVol15("x7", "Bit x7", "Sétimo bit da palavra x.", valorPadrao: 1),
                    NovaVariavelVol15("y7", "Bit y7", "Sétimo bit da palavra y.", valorPadrao: 1)
                ],
                vars => HammingDistanceVol15(vars,
                    ("x1", "y1"), ("x2", "y2"), ("x3", "y3"), ("x4", "y4"),
                    ("x5", "y5"), ("x6", "y6"), ("x7", "y7"))),
            ["233"] = new(
                "0.5*erfc(sqrt(eb_n0))",
                "Pb",
                "adim",
                [
                    NovaVariavelVol15("eb_n0", "Razão Eb/N0", "Razão energia por bit sobre densidade espectral de ruído em escala linear.")
                ]),
            ["231"] = new(
                "(2/N)*Cu*Cv*sum_weighted_cos",
                "F_uv",
                "adim",
                [
                    NovaVariavelVol15("N", "Tamanho do bloco", "Dimensão do bloco da DCT 2D.", "adim", 8),
                    NovaVariavelVol15("Cu", "Coeficiente de normalização u", "Fator de normalização do índice u.", "adim", 1),
                    NovaVariavelVol15("Cv", "Coeficiente de normalização v", "Fator de normalização do índice v.", "adim", 1),
                    NovaVariavelVol15("sum_weighted_cos", "Somatório ponderado", "Somatório dos pixels ponderados pelos cossenos da DCT 2D.")
                ]),
            ["234"] = new(
                "log2(1+SNR*lambda1^2/Nt)+log2(1+SNR*lambda2^2/Nt)+log2(1+SNR*lambda3^2/Nt)+log2(1+SNR*lambda4^2/Nt)",
                "C_MIMO",
                "bps/Hz",
                [
                    NovaVariavelVol15("SNR", "Razão sinal-ruído", "SNR linear por stream espacial.", "adim", 100),
                    NovaVariavelVol15("Nt", "Número de antenas transmissoras", "Quantidade de antenas na transmissão.", "adim", 4),
                    NovaVariavelVol15("lambda1", "Valor singular 1", "Primeiro valor singular do canal.", "adim", 1),
                    NovaVariavelVol15("lambda2", "Valor singular 2", "Segundo valor singular do canal.", "adim", 1),
                    NovaVariavelVol15("lambda3", "Valor singular 3", "Terceiro valor singular do canal.", "adim", 0),
                    NovaVariavelVol15("lambda4", "Valor singular 4", "Quarto valor singular do canal.", "adim", 0)
                ]),
            ["235"] = new(
                "0.5*log2(2*pi*e*sigma^2)",
                "h",
                "bits",
                [
                    NovaVariavelVol15("sigma", "Desvio padrão", "Desvio padrão da variável gaussiana contínua.")
                ]),
            ["312"] = new(
                "dGvdW+dGhbond+dGelec+dGsolv+dGtor",
                "dGbind",
                "kcal/mol",
                [
                    NovaVariavelVol15("dGvdW", "Termo van der Waals", "Contribuição de van der Waals para a energia de docking."),
                    NovaVariavelVol15("dGhbond", "Termo de ligações de hidrogênio", "Contribuição de H-bonds para a energia de docking."),
                    NovaVariavelVol15("dGelec", "Termo eletrostático", "Contribuição eletrostática para a energia de docking."),
                    NovaVariavelVol15("dGsolv", "Termo de solvatação", "Contribuição de solvatação/desolvatação."),
                    NovaVariavelVol15("dGtor", "Termo torsional", "Penalidade conformacional torsional.")
                ]),
            ["313"] = new(
                "exp(dGbind/(R*T))",
                "Ki",
                "adim",
                [
                    NovaVariavelVol15("dGbind", "Energia de ligação", "Energia livre de ligação estimada.", "kcal/mol", -9),
                    NovaVariavelVol15("R", "Constante dos gases", "Constante universal em kcal/mol/K.", "kcal/mol/K", 0.00198720425864083),
                    NovaVariavelVol15("T", "Temperatura absoluta", "Temperatura absoluta do ensaio.", "K", 298.15)
                ]),
            ["311"] = new(
                "RMSD",
                "RMSD",
                "A",
                [
                    NovaVariavelVol15("m1", "Massa átomo 1", "Peso atômico ou peso unitário do primeiro átomo alinhado.", valorPadrao: 12),
                    NovaVariavelVol15("dr2_1", "Desvio quadrático 1", "Quadrado do deslocamento do primeiro átomo após superposição.", "A^2", 0.5),
                    NovaVariavelVol15("m2", "Massa átomo 2", "Peso atômico ou peso unitário do segundo átomo alinhado.", valorPadrao: 12),
                    NovaVariavelVol15("dr2_2", "Desvio quadrático 2", "Quadrado do deslocamento do segundo átomo após superposição.", "A^2", 1.0),
                    NovaVariavelVol15("m3", "Massa átomo 3", "Peso atômico ou peso unitário do terceiro átomo alinhado.", valorPadrao: 14),
                    NovaVariavelVol15("dr2_3", "Desvio quadrático 3", "Quadrado do deslocamento do terceiro átomo após superposição.", "A^2", 0.8),
                    NovaVariavelVol15("m4", "Massa átomo 4", "Peso atômico ou peso unitário do quarto átomo alinhado.", valorPadrao: 16),
                    NovaVariavelVol15("dr2_4", "Desvio quadrático 4", "Quadrado do deslocamento do quarto átomo após superposição.", "A^2", 0.6)
                ],
                vars =>
                {
                    var somaPesos = ValorVariavelVol15(vars, "m1", 12)
                        + ValorVariavelVol15(vars, "m2", 12)
                        + ValorVariavelVol15(vars, "m3", 14)
                        + ValorVariavelVol15(vars, "m4", 16);
                    var somaPonderada = ValorVariavelVol15(vars, "m1", 12) * ValorVariavelVol15(vars, "dr2_1", 0.5)
                        + ValorVariavelVol15(vars, "m2", 12) * ValorVariavelVol15(vars, "dr2_2", 1.0)
                        + ValorVariavelVol15(vars, "m3", 14) * ValorVariavelVol15(vars, "dr2_3", 0.8)
                        + ValorVariavelVol15(vars, "m4", 16) * ValorVariavelVol15(vars, "dr2_4", 0.6);
                    return somaPesos <= 0 ? 0 : Math.Sqrt(somaPonderada / somaPesos);
                }),
            ["314"] = new(
                "E",
                "E",
                "adim",
                [
                    NovaVariavelVol15("s1", "Score posição 1", "Contribuição BLOSUM62 da primeira posição alinhada.", valorPadrao: 4),
                    NovaVariavelVol15("s2", "Score posição 2", "Contribuição BLOSUM62 da segunda posição alinhada.", valorPadrao: 5),
                    NovaVariavelVol15("s3", "Score posição 3", "Contribuição BLOSUM62 da terceira posição alinhada.", valorPadrao: 4),
                    NovaVariavelVol15("s4", "Score posição 4", "Contribuição BLOSUM62 da quarta posição alinhada.", valorPadrao: 6),
                    NovaVariavelVol15("s5", "Score posição 5", "Contribuição BLOSUM62 da quinta posição alinhada.", valorPadrao: 5),
                    NovaVariavelVol15("s6", "Score posição 6", "Contribuição BLOSUM62 da sexta posição alinhada.", valorPadrao: 4),
                    NovaVariavelVol15("K", "Constante K", "Parâmetro estatístico de Karlin-Altschul.", valorPadrao: 0.13),
                    NovaVariavelVol15("M", "Comprimento consulta", "Comprimento da sequência de consulta.", valorPadrao: 300),
                    NovaVariavelVol15("N", "Comprimento banco", "Comprimento efetivo do banco ou sequência alvo.", valorPadrao: 1000),
                    NovaVariavelVol15("lambda", "Constante lambda", "Parâmetro lambda de Karlin-Altschul.", valorPadrao: 0.318)
                ],
                vars =>
                {
                    var score = ValorVariavelVol15(vars, "s1", 4)
                        + ValorVariavelVol15(vars, "s2", 5)
                        + ValorVariavelVol15(vars, "s3", 4)
                        + ValorVariavelVol15(vars, "s4", 6)
                        + ValorVariavelVol15(vars, "s5", 5)
                        + ValorVariavelVol15(vars, "s6", 4);
                    return ValorVariavelVol15(vars, "K", 0.13)
                        * ValorVariavelVol15(vars, "M", 300)
                        * ValorVariavelVol15(vars, "N", 1000)
                        * Math.Exp(-ValorVariavelVol15(vars, "lambda", 0.318) * score);
                }),
            ["284"] = new(
                "F",
                "F",
                "adim",
                [
                    NovaVariavelVol15("psi_i0", "Amplitude ideal |0>", "Amplitude ideal da componente |0> do estado alvo.", valorPadrao: 0.70710678),
                    NovaVariavelVol15("psi_i1", "Amplitude ideal |1>", "Amplitude ideal da componente |1> do estado alvo.", valorPadrao: 0.70710678),
                    NovaVariavelVol15("psi_r0", "Amplitude real |0>", "Amplitude real da componente |0> do estado após a porta.", valorPadrao: 0.71),
                    NovaVariavelVol15("psi_r1", "Amplitude real |1>", "Amplitude real da componente |1> do estado após a porta.", valorPadrao: 0.70)
                ],
                vars => FidelityVol15(
                    ValorVariavelVol15(vars, "psi_i0", 0.70710678),
                    ValorVariavelVol15(vars, "psi_i1", 0.70710678),
                    ValorVariavelVol15(vars, "psi_r0", 0.71),
                    ValorVariavelVol15(vars, "psi_r1", 0.70))),
            ["287"] = new(
                "rho_off0*exp(-t/T2)",
                "rho_off",
                "adim",
                [
                    NovaVariavelVol15("rho_off0", "Coerencia inicial", "Elemento fora da diagonal inicial da matriz densidade.", valorPadrao: 1),
                    NovaVariavelVol15("t", "Tempo", "Tempo decorrido desde a preparação do estado.", "s", 1e-4),
                    NovaVariavelVol15("T2", "Tempo de decoerencia", "Constante de tempo T2 do qubit.", "s", 1e-3)
                ]),
            ["288"] = new(
                "G0*(T1+T2+T3+T4)",
                "G",
                "S",
                [
                    NovaVariavelVol15("G0", "Condutancia quântica", "Valor da condutância quântica fundamental.", "S", 7.75e-5),
                    NovaVariavelVol15("T1", "Transmissão canal 1", "Probabilidade de transmissão do primeiro canal quântico.", valorPadrao: 1),
                    NovaVariavelVol15("T2", "Transmissão canal 2", "Probabilidade de transmissão do segundo canal quântico.", valorPadrao: 0),
                    NovaVariavelVol15("T3", "Transmissão canal 3", "Probabilidade de transmissão do terceiro canal quântico.", valorPadrao: 0),
                    NovaVariavelVol15("T4", "Transmissão canal 4", "Probabilidade de transmissão do quarto canal quântico.", valorPadrao: 0)
                ]),
            ["291"] = new(
                "Pm*(I/Im)*exp(1-I/Im)",
                "P",
                "mgC/m3/h",
                [
                    NovaVariavelVol15("Pm", "Producao maxima", "Taxa máxima de produção primária fitoplanctônica.", "mgC/m3/h", 5),
                    NovaVariavelVol15("I", "Irradiancia", "Irradiância incidente na profundidade considerada.", "W/m2", 80),
                    NovaVariavelVol15("Im", "Irradiancia otima", "Irradiância ótima do ajuste de Steele.", "W/m2", 100)
                ]),
            ["293"] = new(
                "u_star^3/b_flux",
                "Hmix",
                "m",
                [
                    NovaVariavelVol15("u_star", "Velocidade de friccao", "Velocidade de fricção turbulenta na superfície do oceano.", "m/s", 0.01),
                    NovaVariavelVol15("b_flux", "Fluxo de flutuabilidade", "Fluxo de flutuabilidade efetivo da camada superficial.", "m2/s3", 1e-8)
                ]),
            ["299"] = new(
                "(Ca*CO3)/Ksp_aragonita",
                "Omega_arag",
                "adim",
                [
                    NovaVariavelVol15("Ca", "[Ca2+]", "Concentração molar efetiva de cálcio dissolvido.", "mol/kg", 0.0103),
                    NovaVariavelVol15("CO3", "[CO3 2-]", "Concentração molar efetiva de carbonato dissolvido.", "mol/kg", 2.5e-4),
                    NovaVariavelVol15("Ksp_aragonita", "Ksp da aragonita", "Produto de solubilidade da aragonita na água do mar.", "mol2/kg2", 6.5e-7)
                ]),
            ["300"] = new(
                "M_seco/V_agua_filtrada",
                "Biomassa",
                "mg/m3",
                [
                    NovaVariavelVol15("M_seco", "Massa seca", "Massa seca coletada no arrasto de rede.", "mg", 500),
                    NovaVariavelVol15("V_agua_filtrada", "Volume filtrado", "Volume efetivo de água filtrada pela rede.", "m3", 2)
                ]),
            ["154"] = new(
                "r*L*(1-L/K)*fT*fU",
                "dL_dt",
                "m/dia",
                [
                    NovaVariavelVol15("r", "Taxa intrínseca", "Taxa intrínseca de crescimento radicular.", "1/dia", 0.08),
                    NovaVariavelVol15("L", "Comprimento atual", "Comprimento atual do sistema radicular.", "m", 0.6),
                    NovaVariavelVol15("K", "Capacidade de suporte", "Comprimento máximo suportado pelas condições de solo.", "m", 1.4),
                    NovaVariavelVol15("fT", "Fator térmico", "Fator de modulação por temperatura do solo.", "adim", 0.9),
                    NovaVariavelVol15("fU", "Fator de umidade", "Fator de modulação por umidade do solo.", "adim", 0.85)
                ]),
            ["159"] = new(
                "N1/1+N2/2+N3/3+N4/4+N5/5",
                "IVE",
                "adim",
                [
                    NovaVariavelVol15("N1", "Plântulas dia 1", "Número de plântulas emergidas no primeiro dia.", valorPadrao: 20),
                    NovaVariavelVol15("N2", "Plântulas dia 2", "Número de plântulas emergidas no segundo dia.", valorPadrao: 35),
                    NovaVariavelVol15("N3", "Plântulas dia 3", "Número de plântulas emergidas no terceiro dia.", valorPadrao: 25),
                    NovaVariavelVol15("N4", "Plântulas dia 4", "Número de plântulas emergidas no quarto dia.", valorPadrao: 12),
                    NovaVariavelVol15("N5", "Plântulas dia 5", "Número de plântulas emergidas no quinto dia.", valorPadrao: 8)
                ]),
            ["241"] = new(
                "A1*exp(-lambda1*(t-t1))*H1+A2*exp(-lambda2*(t-t2))*H2+A3*exp(-lambda3*(t-t3))*H3",
                "C",
                "adim",
                [
                    NovaVariavelVol15("A1", "Amplitude pulso 1", "Amplitude do primeiro pulso hormonal estimado.", valorPadrao: 12),
                    NovaVariavelVol15("lambda1", "Decaimento pulso 1", "Constante de decaimento do primeiro pulso.", "1/h", 0.4),
                    NovaVariavelVol15("t", "Tempo atual", "Instante de avaliação da concentração hormonal.", "h", 8),
                    NovaVariavelVol15("t1", "Tempo pulso 1", "Instante de início do primeiro pulso.", "h", 6),
                    NovaVariavelVol15("H1", "Heaviside 1", "Indicador de ativação do primeiro pulso (0 ou 1).", valorPadrao: 1),
                    NovaVariavelVol15("A2", "Amplitude pulso 2", "Amplitude do segundo pulso hormonal estimado.", valorPadrao: 9),
                    NovaVariavelVol15("lambda2", "Decaimento pulso 2", "Constante de decaimento do segundo pulso.", "1/h", 0.5),
                    NovaVariavelVol15("t2", "Tempo pulso 2", "Instante de início do segundo pulso.", "h", 7),
                    NovaVariavelVol15("H2", "Heaviside 2", "Indicador de ativação do segundo pulso (0 ou 1).", valorPadrao: 1),
                    NovaVariavelVol15("A3", "Amplitude pulso 3", "Amplitude do terceiro pulso hormonal estimado.", valorPadrao: 6),
                    NovaVariavelVol15("lambda3", "Decaimento pulso 3", "Constante de decaimento do terceiro pulso.", "1/h", 0.6),
                    NovaVariavelVol15("t3", "Tempo pulso 3", "Instante de início do terceiro pulso.", "h", 9),
                    NovaVariavelVol15("H3", "Heaviside 3", "Indicador de ativação do terceiro pulso (0 ou 1).", valorPadrao: 0)
                ]),
            ["255"] = new(
                "soma_Ti/(n_estacoes*TC)",
                "eta_linha",
                "adim",
                [
                    NovaVariavelVol15("soma_Ti", "Soma dos tempos de tarefa", "Somatório dos tempos de todas as tarefas da linha.", "s", 140),
                    NovaVariavelVol15("n_estacoes", "Número de estações", "Número de estações de trabalho na linha.", valorPadrao: 5),
                    NovaVariavelVol15("TC", "Tempo de ciclo", "Tempo de ciclo planejado para atender à demanda.", "s", 30)
                ]),
            ["271"] = new(
                "P_i",
                "P_i",
                "pu",
                [
                    NovaVariavelVol15("Vi", "Tensão barra i", "Magnitude de tensão da barra i.", "pu", 1.0),
                    NovaVariavelVol15("V1", "Tensão barra 1", "Magnitude de tensão da barra vizinha 1.", "pu", 1.02),
                    NovaVariavelVol15("V2", "Tensão barra 2", "Magnitude de tensão da barra vizinha 2.", "pu", 0.99),
                    NovaVariavelVol15("V3", "Tensão barra 3", "Magnitude de tensão da barra vizinha 3.", "pu", 1.01),
                    NovaVariavelVol15("G1", "Condutância i1", "Condutância entre as barras i e 1.", "pu", 0.02),
                    NovaVariavelVol15("B1", "Susceptância i1", "Susceptância entre as barras i e 1.", "pu", -0.1),
                    NovaVariavelVol15("d1", "Delta i1", "Diferença angular entre barras i e 1 em radianos.", "rad", 0.04),
                    NovaVariavelVol15("G2", "Condutância i2", "Condutância entre as barras i e 2.", "pu", 0.03),
                    NovaVariavelVol15("B2", "Susceptância i2", "Susceptância entre as barras i e 2.", "pu", -0.12),
                    NovaVariavelVol15("d2", "Delta i2", "Diferença angular entre barras i e 2 em radianos.", "rad", -0.03),
                    NovaVariavelVol15("G3", "Condutância i3", "Condutância entre as barras i e 3.", "pu", 0.01),
                    NovaVariavelVol15("B3", "Susceptância i3", "Susceptância entre as barras i e 3.", "pu", -0.08),
                    NovaVariavelVol15("d3", "Delta i3", "Diferença angular entre barras i e 3 em radianos.", "rad", 0.02)
                ],
                vars =>
                {
                    var vi = ValorVariavelVol15(vars, "Vi", 1.0);
                    var p1 = vi * ValorVariavelVol15(vars, "V1", 1.02)
                        * (ValorVariavelVol15(vars, "G1", 0.02) * Math.Cos(ValorVariavelVol15(vars, "d1", 0.04))
                        + ValorVariavelVol15(vars, "B1", -0.1) * Math.Sin(ValorVariavelVol15(vars, "d1", 0.04)));
                    var p2 = vi * ValorVariavelVol15(vars, "V2", 0.99)
                        * (ValorVariavelVol15(vars, "G2", 0.03) * Math.Cos(ValorVariavelVol15(vars, "d2", -0.03))
                        + ValorVariavelVol15(vars, "B2", -0.12) * Math.Sin(ValorVariavelVol15(vars, "d2", -0.03)));
                    var p3 = vi * ValorVariavelVol15(vars, "V3", 1.01)
                        * (ValorVariavelVol15(vars, "G3", 0.01) * Math.Cos(ValorVariavelVol15(vars, "d3", 0.02))
                        + ValorVariavelVol15(vars, "B3", -0.08) * Math.Sin(ValorVariavelVol15(vars, "d3", 0.02)));
                    return p1 + p2 + p3;
                }),
            ["302"] = new(
                "(DDOC1+DDOC2+DDOC3)*exp(-k*t)",
                "DDOC_m",
                "t",
                [
                    NovaVariavelVol15("DDOC1", "Parcela DDOC 1", "Contribuição degradável da primeira fração de resíduo.", "t", 120),
                    NovaVariavelVol15("DDOC2", "Parcela DDOC 2", "Contribuição degradável da segunda fração de resíduo.", "t", 80),
                    NovaVariavelVol15("DDOC3", "Parcela DDOC 3", "Contribuição degradável da terceira fração de resíduo.", "t", 60),
                    NovaVariavelVol15("k", "Constante de decaimento", "Constante de decaimento de primeira ordem do aterro.", "1/ano", 0.08),
                    NovaVariavelVol15("t", "Tempo", "Tempo transcorrido desde a disposição do resíduo.", "ano", 5)
                ]),
            ["306"] = new(
                "f1*PCI1+f2*PCI2+f3*PCI3+f4*PCI4",
                "PCI_RSU",
                "MJ/kg",
                [
                    NovaVariavelVol15("f1", "Fração 1", "Fração mássica da componente 1 do RSU.", valorPadrao: 0.3),
                    NovaVariavelVol15("PCI1", "PCI componente 1", "Poder calorífico inferior da componente 1.", "MJ/kg", 16),
                    NovaVariavelVol15("f2", "Fração 2", "Fração mássica da componente 2 do RSU.", valorPadrao: 0.25),
                    NovaVariavelVol15("PCI2", "PCI componente 2", "Poder calorífico inferior da componente 2.", "MJ/kg", 8),
                    NovaVariavelVol15("f3", "Fração 3", "Fração mássica da componente 3 do RSU.", valorPadrao: 0.2),
                    NovaVariavelVol15("PCI3", "PCI componente 3", "Poder calorífico inferior da componente 3.", "MJ/kg", 5),
                    NovaVariavelVol15("f4", "Fração 4", "Fração mássica da componente 4 do RSU.", valorPadrao: 0.25),
                    NovaVariavelVol15("PCI4", "PCI componente 4", "Poder calorífico inferior da componente 4.", "MJ/kg", 12)
                ]),
            ["309"] = new(
                "m1*EF1+m2*EF2+m3*EF3+m4*EF4",
                "GWP",
                "kgCO2eq",
                [
                    NovaVariavelVol15("m1", "Massa material 1", "Massa da primeira fração/material do produto analisado.", "kg", 0.5),
                    NovaVariavelVol15("EF1", "Fator emissão 1", "Fator de emissão da primeira fração/material.", "kgCO2eq/kg", 2.4),
                    NovaVariavelVol15("m2", "Massa material 2", "Massa da segunda fração/material do produto analisado.", "kg", 0.2),
                    NovaVariavelVol15("EF2", "Fator emissão 2", "Fator de emissão da segunda fração/material.", "kgCO2eq/kg", 1.1),
                    NovaVariavelVol15("m3", "Massa material 3", "Massa da terceira fração/material do produto analisado.", "kg", 0.1),
                    NovaVariavelVol15("EF3", "Fator emissão 3", "Fator de emissão da terceira fração/material.", "kgCO2eq/kg", 0.8),
                    NovaVariavelVol15("m4", "Massa material 4", "Massa da quarta fração/material do produto analisado.", "kg", 0.05),
                    NovaVariavelVol15("EF4", "Fator emissão 4", "Fator de emissão da quarta fração/material.", "kgCO2eq/kg", 3.0)
                ]),
            ["317"] = new(
                "Eb+Etheta+Ephi+E_vdW+E_elec",
                "E_total",
                "kcal/mol",
                [
                    NovaVariavelVol15("Eb", "Energia de ligação", "Contribuição de energia de ligação do campo de força.", "kcal/mol", 35),
                    NovaVariavelVol15("Etheta", "Energia angular", "Contribuição de energia de ângulos de ligação.", "kcal/mol", 22),
                    NovaVariavelVol15("Ephi", "Energia torsional", "Contribuição de energia torsional.", "kcal/mol", 18),
                    NovaVariavelVol15("E_vdW", "Energia van der Waals", "Contribuição de interações de van der Waals.", "kcal/mol", -28),
                    NovaVariavelVol15("E_elec", "Energia eletrostática", "Contribuição das interações eletrostáticas.", "kcal/mol", -42)
                ])
        };

        public void AdicionarFormulasVol15()
        {
            foreach (var spec in ObterSpecsLiteraisVol15())
            {
                _formulas.Add(CriarFormulaVol15(spec));
            }
        }

        private static Formula CriarFormulaVol15(Vol15Spec spec)
        {
            var codigoNumerico = int.TryParse(spec.Codigo, out var codigo) ? codigo : 0;
            var overrideFormula = Vol15Overrides.TryGetValue(spec.Codigo, out var formulaOverride) ? formulaOverride : null;
            var expressaoCalculavel = overrideFormula?.Expressao ?? NormalizarExpressaoCalculavelVol15(spec.Expressao);
            var variavelResultado = overrideFormula?.VariavelResultado ?? ExtrairVariavelResultadoVol15(spec.Expressao);
            var unidadeResultado = overrideFormula?.UnidadeResultado ?? "adim";
            var variaveis = overrideFormula is null
                ? ExtrairVariaveisVol15(expressaoCalculavel, spec.Descricao)
                : ClonarVariaveisVol15(overrideFormula.Variaveis);

            return new Formula
            {
                Id = $"v15_{codigoNumerico:000}",
                CodigoCompendio = $"V15-{codigoNumerico:000}",
                Nome = spec.Nome,
                Categoria = spec.Categoria,
                SubCategoria = spec.SubCategoria,
                Expressao = expressaoCalculavel,
                ExprTexto = spec.Expressao,
                Descricao = spec.Descricao,
                Criador = spec.Origem,
                AnoOrigin = "2026",
                ExemploPratico = spec.Exemplo,
                Unidades = "Consistentes com as variaveis de entrada.",
                VariavelResultado = variavelResultado,
                UnidadeResultado = unidadeResultado,
                Icone = "Fx",
                Variaveis = variaveis,
                Calcular = overrideFormula?.Calculadora is null
                    ? vars => CalcularExpressaoVol15(expressaoCalculavel, variaveis, vars)
                    : vars => overrideFormula.Calculadora(vars)
            };
        }

        private static Variavel NovaVariavelVol15(string simbolo, string nome, string descricao, string unidade = "adim", double valorPadrao = 1)
            => new()
            {
                Simbolo = simbolo,
                Nome = nome,
                Descricao = descricao,
                Unidade = unidade,
                ValorPadrao = valorPadrao
            };

        private static List<Variavel> ClonarVariaveisVol15(IEnumerable<Variavel> variaveis)
            => variaveis
                .Select(v => new Variavel
                {
                    Simbolo = v.Simbolo,
                    Nome = v.Nome,
                    Descricao = v.Descricao,
                    Unidade = v.Unidade,
                    ValorPadrao = v.ValorPadrao,
                    ValorMin = v.ValorMin,
                    ValorMax = v.ValorMax,
                    Obrigatoria = v.Obrigatoria
                })
                .ToList();

        private static double ValorVariavelVol15(Dictionary<string, double> vars, string simbolo, double padrao = 0)
            => vars.TryGetValue(simbolo, out var valor) ? valor : padrao;

        private static int BitVol15(Dictionary<string, double> vars, string simbolo)
            => Math.Abs((int)Math.Round(ValorVariavelVol15(vars, simbolo, 0))) % 2;

        private static double MutualInformationTermVol15(double joint, double px, double py)
            => joint > 0 && px > 0 && py > 0 ? joint * Math.Log2(joint / (px * py)) : 0;

        private static double RelativeEntropyTermVol15(double p, double q)
            => p > 0 && q > 0 ? p * Math.Log(p / q) : 0;

        private static double FidelityVol15(double psiIdeal0, double psiIdeal1, double psiReal0, double psiReal1)
        {
            var normaIdeal = psiIdeal0 * psiIdeal0 + psiIdeal1 * psiIdeal1;
            var normaReal = psiReal0 * psiReal0 + psiReal1 * psiReal1;
            if (normaIdeal <= 0 || normaReal <= 0)
            {
                return 0;
            }

            var overlap = psiIdeal0 * psiReal0 + psiIdeal1 * psiReal1;
            return (overlap * overlap) / (normaIdeal * normaReal);
        }

        private static double HammingDistanceVol15(Dictionary<string, double> vars, params (string X, string Y)[] pares)
            => pares.Count(par => BitVol15(vars, par.X) != BitVol15(vars, par.Y));

        private static List<Variavel> ExtrairVariaveisVol15(string expressao, string descricao)
        {
            var mapaDescricoes = ExtrairMapaVariaveisDaDescricao(descricao);

            return Vol15SimboloRegex
                .Matches(expressao)
                .Select(m => m.Value)
                .Where(v => !Vol15Ignorar.Contains(v))
                .Distinct(StringComparer.Ordinal)
                .Select(v => new Variavel
                {
                    Simbolo = v,
                    Nome = mapaDescricoes.TryGetValue(v, out var texto) ? texto : $"Variavel {v}",
                    Descricao = mapaDescricoes.TryGetValue(v, out var descricaoVariavel) ? descricaoVariavel : $"Parametro {v} da formula.",
                    Unidade = "adim",
                    ValorPadrao = 1
                })
                .ToList();
        }

        private static string ObterLadoDireitoVol15(string expressao)
        {
            var idx = expressao.IndexOf('=');
            return idx >= 0 ? expressao[(idx + 1)..].Trim() : expressao.Trim();
        }

        private static string ExtrairVariavelResultadoVol15(string expressao)
        {
            var idx = expressao.IndexOf('=');
            if (idx < 0)
            {
                return "resultado";
            }

            var lhs = NormalizarExpressao(expressao[..idx]);
            var simbolo = Vol15SimboloRegex.Match(lhs).Value;
            return string.IsNullOrWhiteSpace(simbolo) ? "resultado" : simbolo;
        }

        private static string NormalizarExpressaoCalculavelVol15(string expressao)
        {
            var primaria = expressao.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).FirstOrDefault() ?? expressao;
            var rhs = ObterLadoDireitoVol15(primaria);
            rhs = ExpandirSomaQuadratica(rhs);
            rhs = Regex.Replace(rhs, @"([A-Za-z_][A-Za-z0-9_]*)\(([^()]*)\)", match =>
            {
                var nome = match.Groups[1].Value;
                if (EhFuncao(nome))
                {
                    return match.Value;
                }

                var argumentos = match.Groups[2].Value
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(NormalizarExpressao)
                    .Where(s => !string.IsNullOrWhiteSpace(s));

                return string.Join("_", new[] { nome }.Concat(argumentos));
            });

            return NormalizarExpressao(rhs);
        }

        private static Dictionary<string, string> ExtrairMapaVariaveisDaDescricao(string descricao)
        {
            var mapa = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var normalizada = NormalizarExpressao(descricao);
            foreach (Match match in Regex.Matches(normalizada, @"\b([A-Za-z_][A-Za-z0-9_]*)\s*=\s*([^,.;]+)"))
            {
                var simbolo = match.Groups[1].Value;
                var texto = match.Groups[2].Value.Trim();
                if (!Vol15Ignorar.Contains(simbolo) && !mapa.ContainsKey(simbolo))
                {
                    mapa[simbolo] = texto;
                }
            }

            return mapa;
        }

        private static double CalcularExpressaoVol15(string expressao, List<Variavel> variaveis, Dictionary<string, double> vars)
        {
            if (vars.TryGetValue("resultado", out var resultado))
            {
                return resultado;
            }

            var rhs = ObterLadoDireitoVol15(expressao);
            if (TryAvaliar(rhs, vars, out var valor))
            {
                return valor;
            }

            if (variaveis.Count > 0 && vars.TryGetValue(variaveis[0].Simbolo, out var fallback))
            {
                return fallback;
            }

            return 0;
        }

        private static bool TryAvaliar(string expr, Dictionary<string, double> vars, out double resultado)
        {
            resultado = 0;
            var norm = NormalizarExpressao(expr);
            if (string.IsNullOrWhiteSpace(norm))
            {
                return false;
            }

            try
            {
                var rpn = ParaRpn(Tokenizar(norm));
                var pilha = new Stack<double>();

                foreach (var t in rpn)
                {
                    if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out var num))
                    {
                        pilha.Push(num);
                        continue;
                    }

                    if (EhOperador(t))
                    {
                        if (pilha.Count < 2)
                        {
                            return false;
                        }

                        var b = pilha.Pop();
                        var a = pilha.Pop();
                        pilha.Push(t switch
                        {
                            "+" => a + b,
                            "-" => a - b,
                            "*" => a * b,
                            "/" => Math.Abs(b) < 1e-12 ? 0 : a / b,
                            "^" => Math.Pow(a, b),
                            _ => 0
                        });
                        continue;
                    }

                    if (EhFuncao(t))
                    {
                        if (!AplicarFuncao(t, pilha))
                        {
                            return false;
                        }
                        continue;
                    }

                    if (string.Equals(t, "pi", StringComparison.OrdinalIgnoreCase))
                    {
                        pilha.Push(Math.PI);
                        continue;
                    }

                    if (string.Equals(t, "e", StringComparison.OrdinalIgnoreCase))
                    {
                        pilha.Push(Math.E);
                        continue;
                    }

                    pilha.Push(vars.TryGetValue(t, out var v) ? v : 1);
                }

                if (pilha.Count != 1)
                {
                    return false;
                }

                resultado = pilha.Pop();
                return !double.IsNaN(resultado) && !double.IsInfinity(resultado);
            }
            catch
            {
                return false;
            }
        }

        private static bool AplicarFuncao(string funcao, Stack<double> pilha)
        {
            switch (funcao.ToLowerInvariant())
            {
                case "sin":
                case "cos":
                case "tan":
                case "asin":
                case "acos":
                case "atan":
                case "sqrt":
                case "log":
                case "log2":
                case "ln":
                case "exp":
                case "abs":
                case "erfc":
                case "qfunc":
                    if (pilha.Count < 1) return false;
                    var a = pilha.Pop();
                    pilha.Push(funcao.ToLowerInvariant() switch
                    {
                        "sin" => Math.Sin(a),
                        "cos" => Math.Cos(a),
                        "tan" => Math.Tan(a),
                        "asin" => Math.Asin(a),
                        "acos" => Math.Acos(a),
                        "atan" => Math.Atan(a),
                        "sqrt" => a < 0 ? 0 : Math.Sqrt(a),
                        "log" => a <= 0 ? 0 : Math.Log10(a),
                        "log2" => a <= 0 ? 0 : Math.Log2(a),
                        "ln" => a <= 0 ? 0 : Math.Log(a),
                        "exp" => Math.Exp(a),
                        "abs" => Math.Abs(a),
                        "erfc" => Erfc(a),
                        "qfunc" => 0.5 * Erfc(a / Math.Sqrt(2)),
                        _ => 0
                    });
                    return true;
                case "min":
                case "max":
                case "pow":
                    if (pilha.Count < 2) return false;
                    var b = pilha.Pop();
                    var x = pilha.Pop();
                    pilha.Push(funcao.ToLowerInvariant() switch
                    {
                        "min" => Math.Min(x, b),
                        "max" => Math.Max(x, b),
                        "pow" => Math.Pow(x, b),
                        _ => 0
                    });
                    return true;
                default:
                    return false;
            }
        }

        private static string NormalizarExpressao(string expr)
        {
            var s = expr
                .Replace("√", "sqrt")
                .Replace("×", "*")
                .Replace("·", "*")
                .Replace("−", "-")
                .Replace("–", "-")
                .Replace("÷", "/")
                .Replace("≈", "")
                .Replace("⊕", "⊕")
                .Replace(";", "")
                .Replace("[", "(")
                .Replace("]", ")")
                .Replace("σ", "sigma")
                .Replace("Δ", "d")
                .Replace("θ", "theta")
                .Replace("λ", "lambda")
                .Replace("ω", "omega")
                .Replace("μ", "mu")
                .Replace("ρ", "rho")
                .Replace("φ", "phi")
                .Replace("γ", "gamma")
                .Replace("π", "pi")
                .Replace("ℏ", "hbar")
                .Replace("₀", "0")
                .Replace("₁", "1")
                .Replace("₂", "2")
                .Replace("₃", "3")
                .Replace("₄", "4")
                .Replace("₅", "5")
                .Replace("₆", "6")
                .Replace("₇", "7")
                .Replace("₈", "8")
                .Replace("₉", "9")
                .Replace("⁰", "^0")
                .Replace("¹", "^1")
                .Replace("²", "^2")
                .Replace("³", "^3")
                .Replace("⁴", "^4")
                .Replace("⁵", "^5")
                .Replace("⁶", "^6")
                .Replace("⁷", "^7")
                .Replace("⁸", "^8")
                .Replace("⁹", "^9")
                .Replace("⁻", "-");

            s = s.Replace("arctan", "atan", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("arcsin", "asin", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("arccos", "acos", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("log₂", "log2", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("log2", "log2", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("Q(", "qfunc(", StringComparison.OrdinalIgnoreCase);
            s = Regex.Replace(s, @"\|([^|]+)\|", "abs($1)");

            s = Regex.Replace(s, @"[^A-Za-z0-9_+\-*/^()., ⊕]", " ");
            s = Regex.Replace(s, @"\s+", " ").Trim();
            return s;
        }

        private static List<string> Tokenizar(string expr)
        {
            var tokens = new List<string>();
            var i = 0;
            while (i < expr.Length)
            {
                var c = expr[i];
                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                if (char.IsDigit(c) || c == '.')
                {
                    var j = i;
                    while (j < expr.Length && (char.IsDigit(expr[j]) || expr[j] == '.')) j++;
                    tokens.Add(expr[i..j]);
                    i = j;
                    continue;
                }

                if (char.IsLetter(c) || c == '_')
                {
                    var j = i;
                    while (j < expr.Length && (char.IsLetterOrDigit(expr[j]) || expr[j] == '_')) j++;
                    tokens.Add(expr[i..j]);
                    i = j;
                    continue;
                }

                if (",()+-*/^".Contains(c))
                {
                    tokens.Add(c.ToString());
                    i++;
                    continue;
                }

                i++;
            }

            return AjustarUnario(InserirMultiplicacaoImplicita(tokens));
        }

        private static List<string> InserirMultiplicacaoImplicita(List<string> tokens)
        {
            if (tokens.Count < 2)
            {
                return tokens;
            }

            var resultado = new List<string>(tokens.Count * 2);
            for (var i = 0; i < tokens.Count; i++)
            {
                var atual = tokens[i];
                resultado.Add(atual);

                if (i == tokens.Count - 1)
                {
                    continue;
                }

                var proximo = tokens[i + 1];
                if (PrecisaMultiplicacaoImplicita(atual, proximo))
                {
                    resultado.Add("*");
                }
            }

            return resultado;
        }

        private static bool PrecisaMultiplicacaoImplicita(string atual, string proximo)
        {
            if (EhFuncao(atual) && proximo == "(")
            {
                return false;
            }

            return EhOperandoParaMultiplicacao(atual) && EhOperandoParaMultiplicacaoDireita(proximo);
        }

        private static bool EhOperandoParaMultiplicacao(string token)
            => double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _)
               || EhVariavelOuConstante(token)
               || token == ")";

        private static bool EhOperandoParaMultiplicacaoDireita(string token)
            => double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _)
               || EhVariavelOuConstante(token)
               || token == "(";

        private static List<string> AjustarUnario(List<string> tokens)
        {
            var outTokens = new List<string>();
            for (var i = 0; i < tokens.Count; i++)
            {
                var t = tokens[i];
                if (t == "-" && (i == 0 || tokens[i - 1] == "(" || EhOperador(tokens[i - 1]) || tokens[i - 1] == ","))
                {
                    outTokens.Add("0");
                }
                outTokens.Add(t);
            }

            return outTokens;
        }

        private static Queue<string> ParaRpn(List<string> tokens)
        {
            var saida = new Queue<string>();
            var ops = new Stack<string>();

            for (var i = 0; i < tokens.Count; i++)
            {
                var t = tokens[i];
                if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out _) || EhVariavelOuConstante(t))
                {
                    if (EhFuncao(t) && i + 1 < tokens.Count && tokens[i + 1] == "(")
                    {
                        ops.Push(t);
                    }
                    else
                    {
                        saida.Enqueue(t);
                    }
                    continue;
                }

                if (t == ",")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        saida.Enqueue(ops.Pop());
                    }
                    continue;
                }

                if (EhOperador(t))
                {
                    while (ops.Count > 0 && EhOperador(ops.Peek()) &&
                           ((AssociatividadeEsquerda(t) && Precedencia(t) <= Precedencia(ops.Peek())) ||
                            (!AssociatividadeEsquerda(t) && Precedencia(t) < Precedencia(ops.Peek()))))
                    {
                        saida.Enqueue(ops.Pop());
                    }
                    ops.Push(t);
                    continue;
                }

                if (t == "(")
                {
                    ops.Push(t);
                    continue;
                }

                if (t == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        saida.Enqueue(ops.Pop());
                    }
                    if (ops.Count > 0 && ops.Peek() == "(")
                    {
                        ops.Pop();
                    }
                    if (ops.Count > 0 && EhFuncao(ops.Peek()))
                    {
                        saida.Enqueue(ops.Pop());
                    }
                }
            }

            while (ops.Count > 0)
            {
                saida.Enqueue(ops.Pop());
            }

            return saida;
        }

        private static bool EhVariavelOuConstante(string t)
            => Regex.IsMatch(t, @"^[A-Za-z_][A-Za-z0-9_]*$");

        private static bool EhOperador(string t)
            => t is "+" or "-" or "*" or "/" or "^";

        private static int Precedencia(string op)
            => op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "^" => 3,
                _ => 0
            };

        private static bool AssociatividadeEsquerda(string op) => op != "^";

        private static bool EhFuncao(string t)
            => t.Equals("sin", StringComparison.OrdinalIgnoreCase)
                || t.Equals("cos", StringComparison.OrdinalIgnoreCase)
                || t.Equals("tan", StringComparison.OrdinalIgnoreCase)
                || t.Equals("asin", StringComparison.OrdinalIgnoreCase)
                || t.Equals("acos", StringComparison.OrdinalIgnoreCase)
                || t.Equals("atan", StringComparison.OrdinalIgnoreCase)
                || t.Equals("sqrt", StringComparison.OrdinalIgnoreCase)
                || t.Equals("log", StringComparison.OrdinalIgnoreCase)
                || t.Equals("log2", StringComparison.OrdinalIgnoreCase)
                || t.Equals("ln", StringComparison.OrdinalIgnoreCase)
                || t.Equals("exp", StringComparison.OrdinalIgnoreCase)
                || t.Equals("abs", StringComparison.OrdinalIgnoreCase)
                || t.Equals("erfc", StringComparison.OrdinalIgnoreCase)
                || t.Equals("qfunc", StringComparison.OrdinalIgnoreCase)
                || t.Equals("min", StringComparison.OrdinalIgnoreCase)
                || t.Equals("max", StringComparison.OrdinalIgnoreCase)
                || t.Equals("pow", StringComparison.OrdinalIgnoreCase);

        private static string ExpandirSomaQuadratica(string expressao)
        {
            if (!expressao.Contains('⊕'))
            {
                return expressao;
            }

            var termos = expressao
                .Split('⊕', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(t => $"({t.Trim()})^2");

            return $"sqrt({string.Join("+", termos)})";
        }

        private static double Erfc(double x)
        {
            var z = Math.Abs(x);
            var t = 1.0 / (1.0 + 0.5 * z);
            var r = t * Math.Exp(-z * z - 1.26551223 +
                                 t * (1.00002368 +
                                 t * (0.37409196 +
                                 t * (0.09678418 +
                                 t * (-0.18628806 +
                                 t * (0.27886807 +
                                 t * (-1.13520398 +
                                 t * (1.48851587 +
                                 t * (-0.82215223 +
                                 t * 0.17087277)))))))));

            return x >= 0 ? r : 2 - r;
        }

        private static List<Vol15Spec> ObterSpecsLiteraisVol15()
        {
            var bruto = string.Join("\n", ObterBlocosLiteraisVol15());
            return ParsearSpecsVol15(bruto);
        }

        private static IEnumerable<string> ObterBlocosLiteraisVol15()
        {
            yield return Vol15Parte1;
            yield return Vol15Parte2;
            yield return Vol15Parte3;
            yield return Vol15Parte4;
        }

        private static List<Vol15Spec> ParsearSpecsVol15(string bruto)
        {
            var linhas = bruto.Split('\n').Select(l => l.Trim()).ToList();
            var specs = new List<Vol15Spec>(320);
            string categoria = string.Empty;
            string subCategoria = string.Empty;

            for (var i = 0; i < linhas.Count; i++)
            {
                var linha = linhas[i];
                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue;
                }

                if (Regex.IsMatch(linha, @"^\d{3}$"))
                {
                    var codigo = linha;
                    var nome = ProximaLinhaNaoVazia(linhas, ref i);
                    var nivel = ProximaLinhaNaoVazia(linhas, ref i);
                    _ = nivel;
                    var expressao = ProximaLinhaNaoVazia(linhas, ref i);
                    var descricao = ColetarAtePrefixo(linhas, ref i, "ORIGEM");
                    var origemLinha = ProximaLinhaNaoVazia(linhas, ref i);
                    var origem = origemLinha.StartsWith("ORIGEM", StringComparison.OrdinalIgnoreCase)
                        ? origemLinha[6..].Trim()
                        : origemLinha;
                    var exemplo = ColetarExemplo(linhas, ref i);

                    specs.Add(new Vol15Spec(codigo, nome, expressao, descricao, origem, exemplo, categoria, subCategoria));
                    continue;
                }

                if (i + 1 < linhas.Count && !Regex.IsMatch(linha, @"^\d{3}$") && !Regex.IsMatch(linhas[i + 1], @"^\d{3}$"))
                {
                    categoria = linha;
                    subCategoria = linhas[++i];
                }
            }

            return specs;
        }

        private static string ProximaLinhaNaoVazia(List<string> linhas, ref int indice)
        {
            while (++indice < linhas.Count)
            {
                if (!string.IsNullOrWhiteSpace(linhas[indice]))
                {
                    return linhas[indice];
                }
            }

            return string.Empty;
        }

        private static string ColetarAtePrefixo(List<string> linhas, ref int indice, string prefixo)
        {
            var partes = new List<string>();
            while (indice + 1 < linhas.Count)
            {
                var proxima = linhas[indice + 1];
                if (string.IsNullOrWhiteSpace(proxima))
                {
                    indice++;
                    continue;
                }

                if (proxima.StartsWith(prefixo, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                indice++;
                partes.Add(proxima);
            }

            return string.Join(" ", partes);
        }

        private static string ColetarExemplo(List<string> linhas, ref int indice)
        {
            while (indice + 1 < linhas.Count)
            {
                var proxima = linhas[indice + 1];
                if (string.IsNullOrWhiteSpace(proxima))
                {
                    indice++;
                    continue;
                }

                if (proxima.StartsWith("▶", StringComparison.Ordinal))
                {
                    indice++;
                    return proxima[1..].Trim();
                }

                break;
            }

            return string.Empty;
        }
    }
}
