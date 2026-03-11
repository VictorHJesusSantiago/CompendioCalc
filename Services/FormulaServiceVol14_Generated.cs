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
        private sealed record Vol14Spec(
            string Codigo,
            string Nome,
            string Expressao,
            string Descricao,
            string Origem,
            string Exemplo,
            string Categoria,
            string SubCategoria);

        private sealed record Vol14Override(
            string Expressao,
            string VariavelResultado,
            string UnidadeResultado,
            List<Variavel> Variaveis,
            Func<Dictionary<string, double>, double>? Calculadora = null);

        private static readonly Regex Vol14SimboloRegex = new(@"[A-Za-z_][A-Za-z0-9_]*", RegexOptions.Compiled);
        private static readonly HashSet<string> Vol14Ignorar = new(StringComparer.OrdinalIgnoreCase)
        {
            "resultado", "sin", "cos", "tan", "asin", "acos", "atan", "sqrt", "log", "log10", "log2", "ln",
            "exp", "abs", "min", "max", "pow", "pi", "e"
        };

        private static readonly Dictionary<string, Vol14Override> Vol14Overrides = new(StringComparer.Ordinal)
        {
            ["031"] = new(
                "d_prime",
                "d_prime",
                "adim",
                [
                    NovaVariavelVol14("H", "Taxa de acertos", "Probabilidade de hits na tarefa de reconhecimento.", valorPadrao: 0.85),
                    NovaVariavelVol14("FA", "Taxa de falsos alarmes", "Probabilidade de falsos alarmes na mesma tarefa.", valorPadrao: 0.15)
                ],
                vars => InverseNormalCdf(ValorVariavel(vars, "H", 0.85)) - InverseNormalCdf(ValorVariavel(vars, "FA", 0.15))),
            ["039"] = new(
                "H",
                "H",
                "bits",
                [
                    NovaVariavelVol14("p1", "Frequencia alelica 1", "Probabilidade do primeiro alelo observado no locus STR.", valorPadrao: 0.2),
                    NovaVariavelVol14("p2", "Frequencia alelica 2", "Probabilidade do segundo alelo observado no locus STR.", valorPadrao: 0.2),
                    NovaVariavelVol14("p3", "Frequencia alelica 3", "Probabilidade do terceiro alelo observado no locus STR.", valorPadrao: 0.2),
                    NovaVariavelVol14("p4", "Frequencia alelica 4", "Probabilidade do quarto alelo observado no locus STR.", valorPadrao: 0.2),
                    NovaVariavelVol14("p5", "Frequencia alelica 5", "Probabilidade do quinto alelo observado no locus STR.", valorPadrao: 0.2)
                ],
                vars => ShannonEntropyVol14(true,
                    ValorVariavel(vars, "p1", 0.2),
                    ValorVariavel(vars, "p2", 0.2),
                    ValorVariavel(vars, "p3", 0.2),
                    ValorVariavel(vars, "p4", 0.2),
                    ValorVariavel(vars, "p5", 0.2))),
            ["105"] = new(
                "H",
                "H",
                "nats",
                [
                    NovaVariavelVol14("p1", "Proporcao ceramica 1", "Frequencia relativa do primeiro tipo ceramico.", valorPadrao: 0.2),
                    NovaVariavelVol14("p2", "Proporcao ceramica 2", "Frequencia relativa do segundo tipo ceramico.", valorPadrao: 0.2),
                    NovaVariavelVol14("p3", "Proporcao ceramica 3", "Frequencia relativa do terceiro tipo ceramico.", valorPadrao: 0.2),
                    NovaVariavelVol14("p4", "Proporcao ceramica 4", "Frequencia relativa do quarto tipo ceramico.", valorPadrao: 0.2),
                    NovaVariavelVol14("p5", "Proporcao ceramica 5", "Frequencia relativa do quinto tipo ceramico.", valorPadrao: 0.2)
                ],
                vars => ShannonEntropyVol14(false,
                    ValorVariavel(vars, "p1", 0.2),
                    ValorVariavel(vars, "p2", 0.2),
                    ValorVariavel(vars, "p3", 0.2),
                    ValorVariavel(vars, "p4", 0.2),
                    ValorVariavel(vars, "p5", 0.2))),
            ["107"] = new(
                "(abs_d1+abs_d2+abs_d3+abs_d4+abs_d5)/n",
                "Ra",
                "um",
                [
                    NovaVariavelVol14("abs_d1", "Desvio absoluto 1", "Desvio absoluto do primeiro ponto do perfil em relação à linha média.", "um", 0.8),
                    NovaVariavelVol14("abs_d2", "Desvio absoluto 2", "Desvio absoluto do segundo ponto do perfil em relação à linha média.", "um", 1.1),
                    NovaVariavelVol14("abs_d3", "Desvio absoluto 3", "Desvio absoluto do terceiro ponto do perfil em relação à linha média.", "um", 0.9),
                    NovaVariavelVol14("abs_d4", "Desvio absoluto 4", "Desvio absoluto do quarto ponto do perfil em relação à linha média.", "um", 1.2),
                    NovaVariavelVol14("abs_d5", "Desvio absoluto 5", "Desvio absoluto do quinto ponto do perfil em relação à linha média.", "um", 1.0),
                    NovaVariavelVol14("n", "Numero de amostras", "Quantidade de pontos ou janelas usadas no perfil de rugosidade.", valorPadrao: 5)
                ]),
            ["109"] = new(
                "MNI",
                "MNI",
                "adim",
                [
                    NovaVariavelVol14("freq_direito", "Frequencia lado direito", "Maior contagem de um elemento anatômico no lado direito.", valorPadrao: 12),
                    NovaVariavelVol14("freq_esquerdo", "Frequencia lado esquerdo", "Maior contagem do mesmo elemento no lado esquerdo.", valorPadrao: 10),
                    NovaVariavelVol14("freq_superior", "Frequencia superior", "Contagem máxima do elemento na porção superior.", valorPadrao: 8),
                    NovaVariavelVol14("freq_inferior", "Frequencia inferior", "Contagem máxima do elemento na porção inferior.", valorPadrao: 7)
                ],
                vars => new[]
                {
                    ValorVariavel(vars, "freq_direito", 12),
                    ValorVariavel(vars, "freq_esquerdo", 10),
                    ValorVariavel(vars, "freq_superior", 8),
                    ValorVariavel(vars, "freq_inferior", 7)
                }.Max()),
            ["115"] = new(
                "(w1*c1+w2*c2+w3*c3+w4*c4)/(w1+w2+w3+w4)",
                "SPI",
                "adim",
                [
                    NovaVariavelVol14("c1", "Criterio 1", "Critério espacial ou ambiental do modelo preditivo.", valorPadrao: 0.8),
                    NovaVariavelVol14("w1", "Peso 1", "Peso atribuído ao critério 1.", valorPadrao: 0.35),
                    NovaVariavelVol14("c2", "Criterio 2", "Segundo critério do modelo preditivo.", valorPadrao: 0.7),
                    NovaVariavelVol14("w2", "Peso 2", "Peso atribuído ao critério 2.", valorPadrao: 0.25),
                    NovaVariavelVol14("c3", "Criterio 3", "Terceiro critério do modelo preditivo.", valorPadrao: 0.9),
                    NovaVariavelVol14("w3", "Peso 3", "Peso atribuído ao critério 3.", valorPadrao: 0.25),
                    NovaVariavelVol14("c4", "Criterio 4", "Quarto critério do modelo preditivo.", valorPadrao: 0.6),
                    NovaVariavelVol14("w4", "Peso 4", "Peso atribuído ao critério 4.", valorPadrao: 0.15)
                ]),
            ["112"] = new(
                "chi2",
                "chi2",
                "adim",
                [
                    NovaVariavelVol14("O11", "Observado 11", "Frequência observada na célula 1,1 da tabela de correspondência.", valorPadrao: 20),
                    NovaVariavelVol14("E11", "Esperado 11", "Frequência esperada na célula 1,1 sob independência.", valorPadrao: 18),
                    NovaVariavelVol14("O12", "Observado 12", "Frequência observada na célula 1,2 da tabela de correspondência.", valorPadrao: 15),
                    NovaVariavelVol14("E12", "Esperado 12", "Frequência esperada na célula 1,2 sob independência.", valorPadrao: 17),
                    NovaVariavelVol14("O21", "Observado 21", "Frequência observada na célula 2,1 da tabela de correspondência.", valorPadrao: 12),
                    NovaVariavelVol14("E21", "Esperado 21", "Frequência esperada na célula 2,1 sob independência.", valorPadrao: 14),
                    NovaVariavelVol14("O22", "Observado 22", "Frequência observada na célula 2,2 da tabela de correspondência.", valorPadrao: 18),
                    NovaVariavelVol14("E22", "Esperado 22", "Frequência esperada na célula 2,2 sob independência.", valorPadrao: 16)
                ],
                vars =>
                    ChiQuadradoTermoVol14(ValorVariavel(vars, "O11", 20), ValorVariavel(vars, "E11", 18))
                    + ChiQuadradoTermoVol14(ValorVariavel(vars, "O12", 15), ValorVariavel(vars, "E12", 17))
                    + ChiQuadradoTermoVol14(ValorVariavel(vars, "O21", 12), ValorVariavel(vars, "E21", 14))
                    + ChiQuadradoTermoVol14(ValorVariavel(vars, "O22", 18), ValorVariavel(vars, "E22", 16))),
            ["147"] = new(
                "T_bs*atan(0.151977*sqrt(RH+8.313659))+atan(T_bs+RH)-atan(RH-1.676331)+0.00391838*RH^1.5*atan(0.023101*RH)-4.686035",
                "T_bu",
                "C",
                [
                    NovaVariavelVol14("T_bs", "Temperatura de bulbo seco", "Temperatura do ar em graus Celsius.", "C", 30),
                    NovaVariavelVol14("RH", "Umidade relativa", "Umidade relativa do ar em porcentagem.", "%", 70)
                ]),
            ["151"] = new(
                "(ssta_mes1+ssta_mes2+ssta_mes3)/3",
                "ONI",
                "C",
                [
                    NovaVariavelVol14("ssta_mes1", "Anomalia do mes 1", "Primeira anomalia mensal de SST na regiao Nino 3.4.", "C", 0),
                    NovaVariavelVol14("ssta_mes2", "Anomalia do mes 2", "Segunda anomalia mensal de SST na regiao Nino 3.4.", "C", 0),
                    NovaVariavelVol14("ssta_mes3", "Anomalia do mes 3", "Terceira anomalia mensal de SST na regiao Nino 3.4.", "C", 0)
                ]),
            ["163"] = new(
                "MTTF",
                "MTTF",
                "h",
                [
                    NovaVariavelVol14("eta", "Escala Weibull", "Vida caracteristica do componente.", "h", 5000),
                    NovaVariavelVol14("beta", "Forma Weibull", "Parametro de forma da distribuicao de Weibull.", "adim", 2)
                ],
                vars => ValorVariavel(vars, "eta", 5000) * GammaFunction(1 + 1 / Math.Max(ValorVariavel(vars, "beta", 2), 1e-9))),
            ["169"] = new(
                "f_evento",
                "f_evento",
                "1/ano",
                [
                    NovaVariavelVol14("f_iniciador", "Frequencia iniciadora", "Frequência anual do evento iniciador.", "1/ano", 0.1),
                    NovaVariavelVol14("PFD1", "PFD camada 1", "Probabilidade de falha sob demanda da primeira camada independente.", valorPadrao: 0.01),
                    NovaVariavelVol14("PFD2", "PFD camada 2", "Probabilidade de falha sob demanda da segunda camada independente.", valorPadrao: 0.01),
                    NovaVariavelVol14("PFD3", "PFD camada 3", "Probabilidade de falha sob demanda de uma terceira camada opcional.", valorPadrao: 0),
                    NovaVariavelVol14("M1", "Modificador 1", "Primeiro modificador de exposição ou ocupação.", valorPadrao: 1),
                    NovaVariavelVol14("M2", "Modificador 2", "Segundo modificador de consequência ou ignição.", valorPadrao: 1)
                ],
                vars =>
                {
                    var pfd1 = Math.Clamp(ValorVariavel(vars, "PFD1", 0.01), 0, 1);
                    var pfd2 = Math.Clamp(ValorVariavel(vars, "PFD2", 0.01), 0, 1);
                    var pfd3 = Math.Clamp(ValorVariavel(vars, "PFD3", 0), 0, 1);
                    return ValorVariavel(vars, "f_iniciador", 0.1)
                        * ProdutoValoresVol14(1 - pfd1, 1 - pfd2, 1 - pfd3)
                        * ProdutoValoresVol14(ValorVariavel(vars, "M1", 1), ValorVariavel(vars, "M2", 1));
                }),
            ["171"] = new(
                "P_k",
                "P_k",
                "adim",
                [
                    NovaVariavelVol14("lambda", "Taxa media", "Numero medio esperado de ocorrencias no intervalo.", "adim", 0.1),
                    NovaVariavelVol14("k", "Numero de eventos", "Quantidade inteira de eventos observados.", "adim", 0)
                ],
                vars =>
                {
                    var lambda = Math.Max(ValorVariavel(vars, "lambda", 0.1), 0);
                    var k = Math.Max(0, (int)Math.Round(ValorVariavel(vars, "k", 0)));
                    return Math.Pow(lambda, k) * Math.Exp(-lambda) / Factorial(k);
                }),
            ["172"] = new(
                "MTBF_sistema",
                "MTBF_sistema",
                "h",
                [
                    NovaVariavelVol14("MTBF1", "MTBF componente 1", "Tempo médio entre falhas do primeiro componente em série.", "h", 1000),
                    NovaVariavelVol14("MTBF2", "MTBF componente 2", "Tempo médio entre falhas do segundo componente em série.", "h", 1000),
                    NovaVariavelVol14("MTBF3", "MTBF componente 3", "Tempo médio entre falhas do terceiro componente em série.", "h", 1000)
                ],
                vars =>
                {
                    var somaTaxas = 1 / Math.Max(ValorVariavel(vars, "MTBF1", 1000), 1e-9)
                        + 1 / Math.Max(ValorVariavel(vars, "MTBF2", 1000), 1e-9)
                        + 1 / Math.Max(ValorVariavel(vars, "MTBF3", 1000), 1e-9);
                    return somaTaxas <= 0 ? 0 : 1 / somaTaxas;
                }),
            ["175"] = new(
                "P_f",
                "P_f",
                "adim",
                [
                    NovaVariavelVol14("beta", "Indice de confiabilidade", "Indice beta de Hasofer-Lind.", "adim", 3.5)
                ],
                vars => NormalCdf(-ValorVariavel(vars, "beta", 3.5))),
            ["178"] = new(
                "(beta1/eta1)*(t/eta1)^(beta1-1)+(beta2/eta2)*(t/eta2)^(beta2-1)",
                "h",
                "1/h",
                [
                    NovaVariavelVol14("beta1", "Forma inicial", "Parametro de forma para falha precoce.", "adim", 0.5),
                    NovaVariavelVol14("eta1", "Escala inicial", "Escala da fase de falha precoce.", "h", 1000),
                    NovaVariavelVol14("beta2", "Forma de desgaste", "Parametro de forma para desgaste.", "adim", 3),
                    NovaVariavelVol14("eta2", "Escala de desgaste", "Escala da fase de desgaste.", "h", 5000),
                    NovaVariavelVol14("t", "Tempo", "Tempo de operacao avaliado.", "h", 1000)
                ]),
            ["179"] = new(
                "Risco_coletivo",
                "Risco_coletivo",
                "fatalidades/ano",
                [
                    NovaVariavelVol14("f1", "Frequencia cenario 1", "Frequência anual do primeiro cenário acidental.", "1/ano", 1e-4),
                    NovaVariavelVol14("n1", "Consequencia 1", "Fatalidades esperadas no primeiro cenário.", valorPadrao: 5),
                    NovaVariavelVol14("f2", "Frequencia cenario 2", "Frequência anual do segundo cenário acidental.", "1/ano", 5e-5),
                    NovaVariavelVol14("n2", "Consequencia 2", "Fatalidades esperadas no segundo cenário.", valorPadrao: 12),
                    NovaVariavelVol14("f3", "Frequencia cenario 3", "Frequência anual do terceiro cenário acidental.", "1/ano", 2e-5),
                    NovaVariavelVol14("n3", "Consequencia 3", "Fatalidades esperadas no terceiro cenário.", valorPadrao: 20),
                    NovaVariavelVol14("f4", "Frequencia cenario 4", "Frequência anual do quarto cenário acidental.", "1/ano", 1e-5),
                    NovaVariavelVol14("n4", "Consequencia 4", "Fatalidades esperadas no quarto cenário.", valorPadrao: 40)
                ],
                vars =>
                    ValorVariavel(vars, "f1", 1e-4) * ValorVariavel(vars, "n1", 5)
                    + ValorVariavel(vars, "f2", 5e-5) * ValorVariavel(vars, "n2", 12)
                    + ValorVariavel(vars, "f3", 2e-5) * ValorVariavel(vars, "n3", 20)
                    + ValorVariavel(vars, "f4", 1e-5) * ValorVariavel(vars, "n4", 40)),
            ["180"] = new(
                "R1*(1-(1-R2)*(1-R3))*R4",
                "R_sistema",
                "adim",
                [
                    NovaVariavelVol14("R1", "Confiabilidade do bloco 1", "Confiabilidade do primeiro bloco em série.", valorPadrao: 0.99),
                    NovaVariavelVol14("R2", "Confiabilidade do bloco 2", "Confiabilidade do primeiro bloco do ramo paralelo.", valorPadrao: 0.96),
                    NovaVariavelVol14("R3", "Confiabilidade do bloco 3", "Confiabilidade do segundo bloco do ramo paralelo.", valorPadrao: 0.95),
                    NovaVariavelVol14("R4", "Confiabilidade do bloco 4", "Confiabilidade do bloco final em série.", valorPadrao: 0.98)
                ]),
            ["203"] = new(
                "lambda1*Z1+lambda2*Z2+lambda3*Z3+lambda4*Z4",
                "Z_estrela",
                "adim",
                [
                    NovaVariavelVol14("lambda1", "Peso kriging 1", "Peso associado à primeira amostra vizinha.", valorPadrao: 0.35),
                    NovaVariavelVol14("Z1", "Teor amostra 1", "Valor medido da primeira amostra vizinha.", valorPadrao: 1.2),
                    NovaVariavelVol14("lambda2", "Peso kriging 2", "Peso associado à segunda amostra vizinha.", valorPadrao: 0.25),
                    NovaVariavelVol14("Z2", "Teor amostra 2", "Valor medido da segunda amostra vizinha.", valorPadrao: 0.9),
                    NovaVariavelVol14("lambda3", "Peso kriging 3", "Peso associado à terceira amostra vizinha.", valorPadrao: 0.2),
                    NovaVariavelVol14("Z3", "Teor amostra 3", "Valor medido da terceira amostra vizinha.", valorPadrao: 1.4),
                    NovaVariavelVol14("lambda4", "Peso kriging 4", "Peso associado à quarta amostra vizinha.", valorPadrao: 0.2),
                    NovaVariavelVol14("Z4", "Teor amostra 4", "Valor medido da quarta amostra vizinha.", valorPadrao: 1.1)
                ]),
            ["209"] = new(
                "(res1+res2+res3)/(sol1+sol2+sol3)",
                "FS",
                "adim",
                [
                    NovaVariavelVol14("res1", "Resistencia fatia 1", "Contribuição resistente da primeira fatia do talude.", valorPadrao: 120),
                    NovaVariavelVol14("res2", "Resistencia fatia 2", "Contribuição resistente da segunda fatia do talude.", valorPadrao: 115),
                    NovaVariavelVol14("res3", "Resistencia fatia 3", "Contribuição resistente da terceira fatia do talude.", valorPadrao: 110),
                    NovaVariavelVol14("sol1", "Solicitacao fatia 1", "Momento ou força solicitante da primeira fatia.", valorPadrao: 80),
                    NovaVariavelVol14("sol2", "Solicitacao fatia 2", "Momento ou força solicitante da segunda fatia.", valorPadrao: 75),
                    NovaVariavelVol14("sol3", "Solicitacao fatia 3", "Momento ou força solicitante da terceira fatia.", valorPadrao: 70)
                ]),
            ["218"] = new(
                "(CF1/(1+r)^1)+(CF2/(1+r)^2)+(CF3/(1+r)^3)+(CF4/(1+r)^4)-Investimento",
                "NPV",
                "moeda",
                [
                    NovaVariavelVol14("CF1", "Fluxo de caixa ano 1", "Fluxo de caixa líquido esperado no primeiro ano.", "moeda", 500000),
                    NovaVariavelVol14("CF2", "Fluxo de caixa ano 2", "Fluxo de caixa líquido esperado no segundo ano.", "moeda", 600000),
                    NovaVariavelVol14("CF3", "Fluxo de caixa ano 3", "Fluxo de caixa líquido esperado no terceiro ano.", "moeda", 700000),
                    NovaVariavelVol14("CF4", "Fluxo de caixa ano 4", "Fluxo de caixa líquido esperado no quarto ano.", "moeda", 800000),
                    NovaVariavelVol14("r", "Taxa de desconto", "Taxa anual de desconto do projeto de mineração.", "adim", 0.12),
                    NovaVariavelVol14("Investimento", "Investimento inicial", "Capital inicial total para implantação do projeto.", "moeda", 1800000)
                ]),
            ["219"] = new(
                "(soma_fragmentos_maiores_10cm/comprimento_total_testemunho)*100",
                "RQD",
                "%",
                [
                    NovaVariavelVol14("soma_fragmentos_maiores_10cm", "Soma de fragmentos >10 cm", "Comprimento acumulado de fragmentos de testemunho maiores que 10 cm.", "cm", 65),
                    NovaVariavelVol14("comprimento_total_testemunho", "Comprimento total do testemunho", "Comprimento total do testemunho analisado.", "cm", 100)
                ]),
            ["230"] = new(
                "soma_abs_Deltaz/L",
                "IRI",
                "m/km",
                [
                    NovaVariavelVol14("soma_abs_Deltaz", "Soma dos desvios absolutos", "Somatório dos desvios absolutos do perfil longitudinal.", "m", 1500),
                    NovaVariavelVol14("L", "Extensão avaliada", "Extensão total do trecho avaliado.", "km", 1000)
                ]),
            ["233"] = new(
                "IC+soma_MC_t_descontado+soma_RC_t_descontado+VR_descontado",
                "LCC",
                "moeda",
                [
                    NovaVariavelVol14("IC", "Custo inicial", "Investimento inicial de implantação do pavimento.", "moeda", 1000000),
                    NovaVariavelVol14("soma_MC_t_descontado", "Manutenção descontada", "Somatório dos custos de manutenção descontados ao valor presente.", "moeda", 250000),
                    NovaVariavelVol14("soma_RC_t_descontado", "Reabilitação descontada", "Somatório dos custos de reabilitação descontados ao valor presente.", "moeda", 300000),
                    NovaVariavelVol14("VR_descontado", "Valor residual descontado", "Valor residual no fim do horizonte já convertido a valor presente.", "moeda", -120000)
                ]),
            ["246"] = new(
                "(pi/4)*soma_DAP2/A_parcela",
                "G",
                "m2/ha",
                [
                    NovaVariavelVol14("soma_DAP2", "Soma de DAP ao quadrado", "Somatório dos diâmetros à altura do peito ao quadrado das árvores da parcela.", "cm2", 120000),
                    NovaVariavelVol14("A_parcela", "Área da parcela", "Área total da parcela de inventário florestal.", "m2", 400)
                ]),
            ["248"] = new(
                "(K1*H)/(1-K2*H)+K3*H",
                "UE",
                "%",
                [
                    NovaVariavelVol14("H", "Umidade relativa", "Umidade relativa do ar em fração decimal.", "adim", 0.65),
                    NovaVariavelVol14("K1", "Constante K1", "Constante empírica da equação de Hailwood-Horrobin.", "adim", 0.805),
                    NovaVariavelVol14("K2", "Constante K2", "Constante empírica da equação de Hailwood-Horrobin.", "adim", 0.55),
                    NovaVariavelVol14("K3", "Constante K3", "Termo linear complementar da equação de umidade de equilíbrio.", "adim", 0.12)
                ]),
            ["288"] = new(
                "R1+R2+R3+R4",
                "R_tecido",
                "m2K/W",
                [
                    NovaVariavelVol14("R1", "Resistência camada 1", "Resistência térmica da primeira camada do vestuário.", "m2K/W", 0.20),
                    NovaVariavelVol14("R2", "Resistência camada 2", "Resistência térmica da segunda camada do vestuário.", "m2K/W", 0.18),
                    NovaVariavelVol14("R3", "Resistência camada 3", "Resistência térmica da terceira camada do vestuário.", "m2K/W", 0.15),
                    NovaVariavelVol14("R4", "Resistência camada 4", "Resistência térmica da quarta camada do vestuário.", "m2K/W", 0.12)
                ]),
            ["289"] = new(
                "1-(8/pi^2)*(exp(-D*t/r^2)+exp(-9*D*t/r^2)/9+exp(-25*D*t/r^2)/25)",
                "Mt_Minf",
                "adim",
                [
                    NovaVariavelVol14("D", "Coeficiente de difusão", "Coeficiente efetivo de difusão do corante na fibra.", "m2/s", 1e-12),
                    NovaVariavelVol14("t", "Tempo de tingimento", "Tempo decorrido de difusão.", "s", 3600),
                    NovaVariavelVol14("r", "Raio da fibra", "Raio característico da fibra cilíndrica.", "m", 8e-6)
                ]),
            ["293"] = new(
                "soma_abs_Deltaf/soma_f",
                "ACI",
                "adim",
                [
                    NovaVariavelVol14("soma_abs_Deltaf", "Soma de variações absolutas", "Somatório das diferenças absolutas entre bandas/frequências adjacentes.", valorPadrao: 1500),
                    NovaVariavelVol14("soma_f", "Soma espectral", "Somatório total da energia espectral na janela analisada.", valorPadrao: 1000)
                ]),
            ["309"] = new(
                "integral_RF_x/integral_RF_CO2",
                "GWP_x",
                "adim",
                [
                    NovaVariavelVol14("integral_RF_x", "Integral de RF do gás x", "Integral temporal do forçamento radiativo do gás analisado.", "Wm-2*ano", 280),
                    NovaVariavelVol14("integral_RF_CO2", "Integral de RF do CO2", "Integral temporal do forçamento radiativo de referência do CO2.", "Wm-2*ano", 10)
                ]),
            ["252"] = new(
                "(k/(k-1))*(1-soma_sigma2_i/sigma2_total)",
                "alpha",
                "adim",
                [
                    NovaVariavelVol14("k", "Numero de itens", "Quantidade de itens do instrumento.", "adim", 10),
                    NovaVariavelVol14("soma_sigma2_i", "Soma das variancias dos itens", "Somatorio das variancias individuais dos itens.", "adim", 12),
                    NovaVariavelVol14("sigma2_total", "Variancia total", "Variancia total do escore composto.", "adim", 20)
                ]),
            ["297"] = new(
                "Hs",
                "Hs",
                "bits",
                [
                    NovaVariavelVol14("p1", "Energia relativa faixa 1", "Proporção espectral da primeira faixa de frequência.", valorPadrao: 0.2),
                    NovaVariavelVol14("p2", "Energia relativa faixa 2", "Proporção espectral da segunda faixa de frequência.", valorPadrao: 0.2),
                    NovaVariavelVol14("p3", "Energia relativa faixa 3", "Proporção espectral da terceira faixa de frequência.", valorPadrao: 0.2),
                    NovaVariavelVol14("p4", "Energia relativa faixa 4", "Proporção espectral da quarta faixa de frequência.", valorPadrao: 0.2),
                    NovaVariavelVol14("p5", "Energia relativa faixa 5", "Proporção espectral da quinta faixa de frequência.", valorPadrao: 0.2)
                ],
                vars => ShannonEntropyVol14(true,
                    ValorVariavel(vars, "p1", 0.2),
                    ValorVariavel(vars, "p2", 0.2),
                    ValorVariavel(vars, "p3", 0.2),
                    ValorVariavel(vars, "p4", 0.2),
                    ValorVariavel(vars, "p5", 0.2)))
        };

        public void AdicionarFormulasVol14()
        {
            foreach (var spec in ObterSpecsLiteraisVol14())
            {
                _formulas.Add(CriarFormulaVol14(spec));
            }
        }

        private static Formula CriarFormulaVol14(Vol14Spec spec)
        {
            var codigoNumerico = int.TryParse(spec.Codigo, out var codigo) ? codigo : 0;
            var overrideFormula = Vol14Overrides.TryGetValue(spec.Codigo, out var formulaOverride) ? formulaOverride : null;
            var expressaoCalculavel = overrideFormula?.Expressao ?? NormalizarExpressaoCalculavelVol14(spec.Expressao);
            var variavelResultado = overrideFormula?.VariavelResultado ?? ExtrairVariavelResultadoVol14(spec.Expressao);
            var unidadeResultado = overrideFormula?.UnidadeResultado ?? "adim";
            var variaveis = overrideFormula is null
                ? ExtrairVariaveisVol14(expressaoCalculavel, spec.Descricao)
                : ClonarVariaveisVol14(overrideFormula.Variaveis);

            return new Formula
            {
                Id = $"v14_{codigoNumerico:000}",
                CodigoCompendio = $"V14-{codigoNumerico:000}",
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
                    ? vars => CalcularExpressaoVol14(expressaoCalculavel, variaveis, vars)
                    : vars => overrideFormula.Calculadora(vars)
            };
        }

        private static Variavel NovaVariavelVol14(string simbolo, string nome, string descricao, string unidade = "adim", double valorPadrao = 1)
            => new()
            {
                Simbolo = simbolo,
                Nome = nome,
                Descricao = descricao,
                Unidade = unidade,
                ValorPadrao = valorPadrao
            };

        private static List<Variavel> ClonarVariaveisVol14(IEnumerable<Variavel> variaveis)
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

        private static List<Variavel> ExtrairVariaveisVol14(string expressao, string descricao)
        {
            var mapaDescricoes = ExtrairMapaVariaveisDaDescricaoVol14(descricao);

            return Vol14SimboloRegex
                .Matches(expressao)
                .Select(m => m.Value)
                .Where(v => !Vol14Ignorar.Contains(v))
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

        private static Dictionary<string, string> ExtrairMapaVariaveisDaDescricaoVol14(string descricao)
        {
            var mapa = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var normalizada = NormalizarExpressaoVol14(descricao);

            foreach (Match match in Regex.Matches(normalizada, @"\b([A-Za-z_][A-Za-z0-9_]*)\s*=\s*([^,.;]+)"))
            {
                var simbolo = match.Groups[1].Value;
                var texto = match.Groups[2].Value.Trim();
                if (!Vol14Ignorar.Contains(simbolo) && !mapa.ContainsKey(simbolo))
                {
                    mapa[simbolo] = texto;
                }
            }

            return mapa;
        }

        private static double CalcularExpressaoVol14(string expressao, List<Variavel> variaveis, Dictionary<string, double> vars)
        {
            if (vars.TryGetValue("resultado", out var resultado))
            {
                return resultado;
            }

            var rhs = ObterLadoDireitoVol14(expressao);
            if (TryAvaliarVol14(rhs, vars, out var valor))
            {
                return valor;
            }

            if (variaveis.Count > 0 && vars.TryGetValue(variaveis[0].Simbolo, out var fallback))
            {
                return fallback;
            }

            return 0;
        }

        private static bool TryAvaliarVol14(string expr, Dictionary<string, double> vars, out double resultado)
        {
            resultado = 0;
            var norm = NormalizarExpressaoVol14(expr);
            if (string.IsNullOrWhiteSpace(norm))
            {
                return false;
            }

            try
            {
                var rpn = ParaRpnVol14(TokenizarVol14(norm));
                var pilha = new Stack<double>();

                foreach (var token in rpn)
                {
                    if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out var numero))
                    {
                        pilha.Push(numero);
                        continue;
                    }

                    if (EhOperadorVol14(token))
                    {
                        if (pilha.Count < 2)
                        {
                            return false;
                        }

                        var b = pilha.Pop();
                        var a = pilha.Pop();
                        pilha.Push(token switch
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

                    if (EhFuncaoVol14(token))
                    {
                        if (!AplicarFuncaoVol14(token, pilha))
                        {
                            return false;
                        }
                        continue;
                    }

                    if (string.Equals(token, "pi", StringComparison.OrdinalIgnoreCase))
                    {
                        pilha.Push(Math.PI);
                        continue;
                    }

                    if (string.Equals(token, "e", StringComparison.OrdinalIgnoreCase))
                    {
                        pilha.Push(Math.E);
                        continue;
                    }

                    pilha.Push(vars.TryGetValue(token, out var valorVariavel) ? valorVariavel : 1);
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

        private static bool AplicarFuncaoVol14(string funcao, Stack<double> pilha)
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
                case "log10":
                case "log2":
                case "ln":
                case "exp":
                case "abs":
                    if (pilha.Count < 1)
                    {
                        return false;
                    }

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
                        "log" or "log10" => a <= 0 ? 0 : Math.Log10(a),
                        "log2" => a <= 0 ? 0 : Math.Log2(a),
                        "ln" => a <= 0 ? 0 : Math.Log(a),
                        "exp" => Math.Exp(a),
                        "abs" => Math.Abs(a),
                        _ => 0
                    });
                    return true;

                case "min":
                case "max":
                case "pow":
                    if (pilha.Count < 2)
                    {
                        return false;
                    }

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

        private static string ObterLadoDireitoVol14(string expressao)
        {
            var idxIgual = expressao.IndexOf('=');
            if (idxIgual >= 0)
            {
                return expressao[(idxIgual + 1)..].Trim();
            }

            var idxAprox = expressao.IndexOf('≈');
            return idxAprox >= 0 ? expressao[(idxAprox + 1)..].Trim() : expressao.Trim();
        }

        private static string ExtrairVariavelResultadoVol14(string expressao)
        {
            var idx = expressao.IndexOf('=');
            if (idx < 0)
            {
                idx = expressao.IndexOf('≈');
            }

            if (idx < 0)
            {
                return "resultado";
            }

            var lhs = NormalizarExpressaoVol14(expressao[..idx]);
            var simbolo = Vol14SimboloRegex.Match(lhs).Value;
            return string.IsNullOrWhiteSpace(simbolo) ? "resultado" : simbolo;
        }

        private static string NormalizarExpressaoCalculavelVol14(string expressao)
        {
            var primaria = expressao.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).FirstOrDefault() ?? expressao;
            var rhs = ObterLadoDireitoVol14(primaria);
            rhs = Regex.Replace(rhs, @"\s{2,}\[[^\]]+\]\s*$", string.Empty);
            rhs = SanitizarNotacaoQuimicaVol14(rhs);
            rhs = Regex.Replace(rhs, @"([A-Za-z_][A-Za-z0-9_]*)\(([^()]*)\)", match =>
            {
                var nome = match.Groups[1].Value;
                if (EhFuncaoVol14(nome))
                {
                    return match.Value;
                }

                var argumentos = match.Groups[2].Value
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(SanitizarSimboloVol14)
                    .Where(s => !string.IsNullOrWhiteSpace(s));

                return string.Join("_", new[] { nome }.Concat(argumentos));
            });

            return NormalizarExpressaoVol14(rhs);
        }

        private static string SanitizarNotacaoQuimicaVol14(string expressao)
        {
            return Regex.Replace(expressao, @"\[([^\]]+)\](?:_([A-Za-z0-9]+))?", match =>
            {
                var baseSimbolo = SanitizarSimboloVol14(match.Groups[1].Value);
                if (match.Groups[2].Success)
                {
                    baseSimbolo = $"{baseSimbolo}_{SanitizarSimboloVol14(match.Groups[2].Value)}";
                }

                return baseSimbolo;
            });
        }

        private static string SanitizarSimboloVol14(string valor)
        {
            var texto = valor.Trim();
            texto = texto.Replace("+", "_pos", StringComparison.Ordinal)
                         .Replace("-", "_neg", StringComparison.Ordinal)
                         .Replace("*", "_star", StringComparison.Ordinal)
                         .Replace("/", "_div", StringComparison.Ordinal)
                         .Replace("%", "_pct", StringComparison.Ordinal)
                         .Replace("'", string.Empty, StringComparison.Ordinal);
            texto = NormalizarExpressaoVol14(texto);
            texto = texto.Replace("(", string.Empty, StringComparison.Ordinal)
                         .Replace(")", string.Empty, StringComparison.Ordinal)
                         .Replace(" ", "_", StringComparison.Ordinal);
            texto = Regex.Replace(texto, @"[^A-Za-z0-9_]", string.Empty);
            texto = texto.Trim('_');
            if (string.IsNullOrWhiteSpace(texto))
            {
                return "valor";
            }

            return char.IsLetter(texto[0]) || texto[0] == '_' ? texto : $"v_{texto}";
        }

        private static string NormalizarExpressaoVol14(string expr)
        {
            var s = Regex.Replace(expr, @"(?<=\d),(?=\d)", ".")
                .Replace("√", "sqrt")
                .Replace("×", "*")
                .Replace("·", "*")
                .Replace("−", "-")
                .Replace("–", "-")
                .Replace("÷", "/")
                .Replace("≈", "=")
                .Replace("θ", "theta")
                .Replace("λ", "lambda")
                .Replace("ω", "omega")
                .Replace("μ", "mu")
                .Replace("ρ", "rho")
                .Replace("φ", "phi")
                .Replace("γ", "gamma")
                .Replace("π", "pi")
                .Replace("δ", "delta")
                .Replace("Δ", "Delta")
                .Replace("σ", "sigma")
                .Replace("η", "eta")
                .Replace("τ", "tau")
                .Replace("ε", "epsilon")
                .Replace("χ", "chi")
                .Replace("α", "alpha")
                .Replace("β", "beta")
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
                .Replace("⁻", "-")
                .Replace("°", string.Empty)
                .Replace("[", string.Empty)
                .Replace("]", string.Empty);

            s = s.Replace("log₁₀", "log10", StringComparison.OrdinalIgnoreCase);
            s = s.Replace("log₂", "log2", StringComparison.OrdinalIgnoreCase);
            s = Regex.Replace(s, @"(?<=\d)\s*%", string.Empty);
            s = Regex.Replace(s, @"([A-Za-z_][A-Za-z0-9_]*)%", "$1_pct");
            s = Regex.Replace(s, @"[^A-Za-z0-9_+\-*/^().,= ]", " ");
            s = Regex.Replace(s, @"\s+", " ").Trim();
            return s;
        }

        private static List<string> TokenizarVol14(string expr)
        {
            var tokens = new List<string>();
            var i = 0;
            while (i < expr.Length)
            {
                var c = expr[i];
                if (char.IsWhiteSpace(c) || c == '=')
                {
                    i++;
                    continue;
                }

                if (char.IsDigit(c) || c == '.')
                {
                    var j = i;
                    while (j < expr.Length && (char.IsDigit(expr[j]) || expr[j] == '.'))
                    {
                        j++;
                    }

                    tokens.Add(expr[i..j]);
                    i = j;
                    continue;
                }

                if (char.IsLetter(c) || c == '_')
                {
                    var j = i;
                    while (j < expr.Length && (char.IsLetterOrDigit(expr[j]) || expr[j] == '_'))
                    {
                        j++;
                    }

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

            return AjustarUnarioVol14(InserirMultiplicacaoImplicitaVol14(tokens));
        }

        private static List<string> InserirMultiplicacaoImplicitaVol14(List<string> tokens)
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
                if (PrecisaMultiplicacaoImplicitaVol14(atual, proximo))
                {
                    resultado.Add("*");
                }
            }

            return resultado;
        }

        private static bool PrecisaMultiplicacaoImplicitaVol14(string atual, string proximo)
        {
            if (EhFuncaoVol14(atual) && proximo == "(")
            {
                return false;
            }

            return EhOperandoEsquerdaVol14(atual) && EhOperandoDireitaVol14(proximo);
        }

        private static bool EhOperandoEsquerdaVol14(string token)
            => double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _)
               || EhVariavelOuConstanteVol14(token)
               || token == ")";

        private static bool EhOperandoDireitaVol14(string token)
            => double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _)
               || EhVariavelOuConstanteVol14(token)
               || token == "(";

        private static List<string> AjustarUnarioVol14(List<string> tokens)
        {
            var saida = new List<string>();
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                if (token == "-" && (i == 0 || tokens[i - 1] == "(" || EhOperadorVol14(tokens[i - 1]) || tokens[i - 1] == ","))
                {
                    saida.Add("0");
                }

                saida.Add(token);
            }

            return saida;
        }

        private static Queue<string> ParaRpnVol14(List<string> tokens)
        {
            var saida = new Queue<string>();
            var ops = new Stack<string>();

            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _) || EhVariavelOuConstanteVol14(token))
                {
                    if (EhFuncaoVol14(token) && i + 1 < tokens.Count && tokens[i + 1] == "(")
                    {
                        ops.Push(token);
                    }
                    else
                    {
                        saida.Enqueue(token);
                    }

                    continue;
                }

                if (token == ",")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        saida.Enqueue(ops.Pop());
                    }

                    continue;
                }

                if (EhOperadorVol14(token))
                {
                    while (ops.Count > 0 && EhOperadorVol14(ops.Peek()) &&
                           ((AssociatividadeEsquerdaVol14(token) && PrecedenciaVol14(token) <= PrecedenciaVol14(ops.Peek())) ||
                            (!AssociatividadeEsquerdaVol14(token) && PrecedenciaVol14(token) < PrecedenciaVol14(ops.Peek()))))
                    {
                        saida.Enqueue(ops.Pop());
                    }

                    ops.Push(token);
                    continue;
                }

                if (token == "(")
                {
                    ops.Push(token);
                    continue;
                }

                if (token == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        saida.Enqueue(ops.Pop());
                    }

                    if (ops.Count > 0 && ops.Peek() == "(")
                    {
                        ops.Pop();
                    }

                    if (ops.Count > 0 && EhFuncaoVol14(ops.Peek()))
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

        private static bool EhVariavelOuConstanteVol14(string token)
            => Regex.IsMatch(token, @"^[A-Za-z_][A-Za-z0-9_]*$");

        private static bool EhOperadorVol14(string token)
            => token is "+" or "-" or "*" or "/" or "^";

        private static int PrecedenciaVol14(string op)
            => op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "^" => 3,
                _ => 0
            };

        private static bool AssociatividadeEsquerdaVol14(string op) => op != "^";

        private static bool EhFuncaoVol14(string token)
            => token.Equals("sin", StringComparison.OrdinalIgnoreCase)
                || token.Equals("cos", StringComparison.OrdinalIgnoreCase)
                || token.Equals("tan", StringComparison.OrdinalIgnoreCase)
                || token.Equals("asin", StringComparison.OrdinalIgnoreCase)
                || token.Equals("acos", StringComparison.OrdinalIgnoreCase)
                || token.Equals("atan", StringComparison.OrdinalIgnoreCase)
                || token.Equals("sqrt", StringComparison.OrdinalIgnoreCase)
                || token.Equals("log", StringComparison.OrdinalIgnoreCase)
                || token.Equals("log10", StringComparison.OrdinalIgnoreCase)
                || token.Equals("log2", StringComparison.OrdinalIgnoreCase)
                || token.Equals("ln", StringComparison.OrdinalIgnoreCase)
                || token.Equals("exp", StringComparison.OrdinalIgnoreCase)
                || token.Equals("abs", StringComparison.OrdinalIgnoreCase)
                || token.Equals("min", StringComparison.OrdinalIgnoreCase)
                || token.Equals("max", StringComparison.OrdinalIgnoreCase)
                || token.Equals("pow", StringComparison.OrdinalIgnoreCase);

        private static double ValorVariavel(Dictionary<string, double> vars, string simbolo, double padrao = 0)
            => vars.TryGetValue(simbolo, out var valor) ? valor : padrao;

        private static double ProdutoValoresVol14(params double[] valores)
            => valores.Aggregate(1d, (acumulado, valor) => acumulado * valor);

        private static double ChiQuadradoTermoVol14(double observado, double esperado)
            => esperado <= 0 ? 0 : Math.Pow(observado - esperado, 2) / esperado;

        private static double ShannonEntropyVol14(bool base2, params double[] probabilidades)
            => probabilidades
                .Where(p => p > 0)
                .Select(p => -p * (base2 ? Math.Log2(p) : Math.Log(p)))
                .Sum();

        private static double Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            double resultado = 1;
            for (var i = 2; i <= n; i++)
            {
                resultado *= i;
            }

            return resultado;
        }

        private static double GammaFunction(double z)
        {
            double[] coeficientes =
            [
                676.5203681218851,
                -1259.1392167224028,
                771.32342877765313,
                -176.61502916214059,
                12.507343278686905,
                -0.13857109526572012,
                9.9843695780195716e-6,
                1.5056327351493116e-7
            ];

            if (z < 0.5)
            {
                return Math.PI / (Math.Sin(Math.PI * z) * GammaFunction(1 - z));
            }

            z -= 1;
            var x = 0.99999999999980993;
            for (var i = 0; i < coeficientes.Length; i++)
            {
                x += coeficientes[i] / (z + i + 1);
            }

            var t = z + coeficientes.Length - 0.5;
            return Math.Sqrt(2 * Math.PI) * Math.Pow(t, z + 0.5) * Math.Exp(-t) * x;
        }

        private static double NormalCdf(double x)
            => 0.5 * (1 + Erf(x / Math.Sqrt(2)));

        private static double InverseNormalCdf(double p)
        {
            p = Math.Clamp(p, 1e-10, 1 - 1e-10);

            double[] a =
            [
                -3.969683028665376e+01,
                2.209460984245205e+02,
                -2.759285104469687e+02,
                1.383577518672690e+02,
                -3.066479806614716e+01,
                2.506628277459239e+00
            ];
            double[] b =
            [
                -5.447609879822406e+01,
                1.615858368580409e+02,
                -1.556989798598866e+02,
                6.680131188771972e+01,
                -1.328068155288572e+01
            ];
            double[] c =
            [
                -7.784894002430293e-03,
                -3.223964580411365e-01,
                -2.400758277161838e+00,
                -2.549732539343734e+00,
                4.374664141464968e+00,
                2.938163982698783e+00
            ];
            double[] d =
            [
                7.784695709041462e-03,
                3.224671290700398e-01,
                2.445134137142996e+00,
                3.754408661907416e+00
            ];

            const double pBaixo = 0.02425;
            const double pAlto = 1 - pBaixo;

            if (p < pBaixo)
            {
                var q = Math.Sqrt(-2 * Math.Log(p));
                return (((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                       ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }

            if (p > pAlto)
            {
                var q = Math.Sqrt(-2 * Math.Log(1 - p));
                return -(((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                        ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
            }

            var r = p - 0.5;
            var s = r * r;
            return (((((a[0] * s + a[1]) * s + a[2]) * s + a[3]) * s + a[4]) * s + a[5]) * r /
                   (((((b[0] * s + b[1]) * s + b[2]) * s + b[3]) * s + b[4]) * s + 1);
        }

        private static List<Vol14Spec> ObterSpecsLiteraisVol14()
        {
            var bruto = string.Join("\n", ObterBlocosLiteraisVol14());
            return ParsearSpecsVol14(bruto);
        }

        private static IEnumerable<string> ObterBlocosLiteraisVol14()
        {
            yield return Vol14Parte1;
            yield return Vol14Parte2;
            yield return Vol14Parte3;
            yield return Vol14Parte4;
        }

        private static List<Vol14Spec> ParsearSpecsVol14(string bruto)
        {
            var linhas = bruto.Split('\n').Select(l => l.Trim()).ToList();
            var specs = new List<Vol14Spec>(320);
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
                    var nome = ProximaLinhaNaoVaziaVol14(linhas, ref i);
                    var nivel = ProximaLinhaNaoVaziaVol14(linhas, ref i);
                    _ = nivel;
                    var expressao = ProximaLinhaNaoVaziaVol14(linhas, ref i);
                    var descricao = ColetarAtePrefixoVol14(linhas, ref i, "ORIGEM");
                    var origemLinha = ProximaLinhaNaoVaziaVol14(linhas, ref i);
                    var origem = origemLinha.StartsWith("ORIGEM", StringComparison.OrdinalIgnoreCase)
                        ? origemLinha[6..].Trim()
                        : origemLinha;
                    var exemplo = ColetarExemploVol14(linhas, ref i);

                    specs.Add(new Vol14Spec(codigo, nome, expressao, descricao, origem, exemplo, categoria, subCategoria));
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

        private static string ProximaLinhaNaoVaziaVol14(List<string> linhas, ref int indice)
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

        private static string ColetarAtePrefixoVol14(List<string> linhas, ref int indice, string prefixo)
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

        private static string ColetarExemploVol14(List<string> linhas, ref int indice)
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

                if (Regex.IsMatch(proxima, @"^\d{3}$"))
                {
                    break;
                }

                indice++;
            }

            return string.Empty;
        }
    }
}
