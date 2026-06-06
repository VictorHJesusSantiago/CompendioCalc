using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_SegurancaInformacao()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5201", Nome = "Entropia de Shannon",
                    Categoria = "Segurança da Informação", SubCategoria = "Teoria da Informação",
                    Expressao = "H = −Σ pi × log2(pi)",
                    Descricao = "Medida de incerteza ou quantidade de informação de uma fonte; base da criptografia e compressão.",
                    Criador = "Shannon CE", AnoOrigin = "1948",
                    ReferenciaBibliografica = "Shannon CE. Bell Syst Tech J, 1948.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Probabilidade do símbolo (p)", Simbolo = "p", Unidade = "", ValorPadrao = 0.5, ValorMin = 1e-15, ValorMax = 1 },
                        new Variavel { Nome = "Número de símbolos equiprováveis (n)", Simbolo = "n", Unidade = "", ValorPadrao = 2, ValorMin = 1 }
                    },
                    Calcular = v => -Math.Log(1.0/v["n"], 2),
                    VariavelResultado = "H (por símbolo equiprovável)", UnidadeResultado = "bits"
                },
                new Formula
                {
                    Id = "C5202", Nome = "Entropia de Senha (Força)",
                    Categoria = "Segurança da Informação", SubCategoria = "Autenticação",
                    Expressao = "H = L × log2(N)",
                    Descricao = "Bits de entropia de senha de comprimento L com N caracteres distintos possíveis; mede força da senha.",
                    Criador = "NIST SP 800-63B", AnoOrigin = "2017",
                    ReferenciaBibliografica = "NIST Special Publication 800-63B, 2017.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Comprimento da senha (L)", Simbolo = "L", Unidade = "caracteres", ValorPadrao = 12, ValorMin = 1 },
                        new Variavel { Nome = "Tamanho do alfabeto (N)", Simbolo = "N", Unidade = "símbolos", ValorPadrao = 94, ValorMin = 2 }
                    },
                    Calcular = v => v["L"] * Math.Log(v["N"], 2),
                    VariavelResultado = "H", UnidadeResultado = "bits"
                },
                new Formula
                {
                    Id = "C5203", Nome = "Tempo de Ataque por Força Bruta",
                    Categoria = "Segurança da Informação", SubCategoria = "Criptoanálise",
                    Expressao = "T = N^L / (2 × taxa)",
                    Descricao = "Tempo médio para quebrar senha por força bruta dado N símbolos, comprimento L e taxa de tentativas.",
                    Criador = "Prática de criptoanálise", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Menezes AJ et al. Handbook of Applied Cryptography, 1996.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tamanho do alfabeto (N)", Simbolo = "N", Unidade = "símbolos", ValorPadrao = 94, ValorMin = 2 },
                        new Variavel { Nome = "Comprimento (L)", Simbolo = "L", Unidade = "chars", ValorPadrao = 8, ValorMin = 1 },
                        new Variavel { Nome = "Taxa de tentativas (taxa)", Simbolo = "taxa", Unidade = "tentativas/s", ValorPadrao = 1e9, ValorMin = 1 }
                    },
                    Calcular = v => Math.Pow(v["N"], v["L"]) / (2 * v["taxa"]),
                    VariavelResultado = "T_médio", UnidadeResultado = "s"
                },
                new Formula
                {
                    Id = "C5204", Nome = "Probabilidade de Colisão de Hash (Paradoxo do Aniversário)",
                    Categoria = "Segurança da Informação", SubCategoria = "Funções de Hash",
                    Expressao = "P(colisão) ≈ 1 − e^(−n² / (2 × N))",
                    Descricao = "Probabilidade de colisão em n tentativas com espaço de N hashes possíveis; limita segurança de hash.",
                    Criador = "Yuval G", AnoOrigin = "1979",
                    ReferenciaBibliografica = "Yuval G. IEEE Trans Inf Theory, 1979.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de tentativas (n)", Simbolo = "n", Unidade = "", ValorPadrao = 1e6 },
                        new Variavel { Nome = "Espaço de hash (N = 2^bits)", Simbolo = "N", Unidade = "", ValorPadrao = 1.8e19, ValorMin = 1 }
                    },
                    Calcular = v => 1 - Math.Exp(-v["n"]*v["n"] / (2*v["N"])),
                    VariavelResultado = "P(colisão)", UnidadeResultado = "probabilidade"
                },
                new Formula
                {
                    Id = "C5205", Nome = "Disponibilidade de Sistema",
                    Categoria = "Segurança da Informação", SubCategoria = "Confiabilidade",
                    Expressao = "A = MTBF / (MTBF + MTTR)",
                    Descricao = "Fração do tempo em que sistema está operacional; base para SLA de disponibilidade (noves de disponibilidade).",
                    Criador = "Shooman ML", AnoOrigin = "1968",
                    ReferenciaBibliografica = "Shooman ML. Probabilistic Reliability. McGraw-Hill, 1968.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "MTBF (tempo médio entre falhas)", Simbolo = "MTBF", Unidade = "h", ValorPadrao = 8760, ValorMin = 0.001 },
                        new Variavel { Nome = "MTTR (tempo médio de recuperação)", Simbolo = "MTTR", Unidade = "h", ValorPadrao = 4, ValorMin = 0 }
                    },
                    Calcular = v => v["MTBF"] / (v["MTBF"] + v["MTTR"]),
                    VariavelResultado = "A", UnidadeResultado = "fração (0-1)"
                },
                new Formula
                {
                    Id = "C5206", Nome = "Risco de Segurança",
                    Categoria = "Segurança da Informação", SubCategoria = "Gestão de Risco",
                    Expressao = "R = P × I",
                    Descricao = "Risco é o produto da probabilidade de ocorrência pela magnitude do impacto; base para análise de risco.",
                    Criador = "ISO/IEC 27005", AnoOrigin = "2011",
                    ReferenciaBibliografica = "ISO/IEC 27005:2011. Information Security Risk Management.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Probabilidade de ocorrência (P)", Simbolo = "P", Unidade = "", ValorPadrao = 0.3, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Impacto (I)", Simbolo = "I", Unidade = "unid.", ValorPadrao = 100000 }
                    },
                    Calcular = v => v["P"] * v["I"],
                    VariavelResultado = "R", UnidadeResultado = "unid. monetária"
                },
                new Formula
                {
                    Id = "C5207", Nome = "Capacidade de Canal Seguro (Shannon)",
                    Categoria = "Segurança da Informação", SubCategoria = "Teoria da Informação",
                    Expressao = "C = B × log2(1 + S/N)",
                    Descricao = "Capacidade máxima de canal ruidoso de largura B e razão sinal-ruído S/N; limita taxa de transmissão segura.",
                    Criador = "Shannon CE", AnoOrigin = "1948",
                    ReferenciaBibliografica = "Shannon CE. Bell Syst Tech J, 1948.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Largura de banda (B)", Simbolo = "B", Unidade = "Hz", ValorPadrao = 1e6 },
                        new Variavel { Nome = "Razão sinal-ruído (S/N)", Simbolo = "SNR", Unidade = "adimensional", ValorPadrao = 100, ValorMin = 0 }
                    },
                    Calcular = v => v["B"] * Math.Log(1 + v["SNR"], 2),
                    VariavelResultado = "C", UnidadeResultado = "bits/s"
                },
                new Formula
                {
                    Id = "C5208", Nome = "Número de Chaves em Criptografia Simétrica (n usuários)",
                    Categoria = "Segurança da Informação", SubCategoria = "Criptografia",
                    Expressao = "K = n × (n−1) / 2",
                    Descricao = "Número de chaves simétricas necessárias para comunicação segura entre n usuários; motivação para PKI.",
                    Criador = "Diffie W / Hellman ME", AnoOrigin = "1976",
                    ReferenciaBibliografica = "Diffie W, Hellman ME. IEEE Trans Inf Theory, 1976.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de usuários (n)", Simbolo = "n", Unidade = "usuários", ValorPadrao = 100, ValorMin = 2 }
                    },
                    Calcular = v => v["n"] * (v["n"] - 1) / 2,
                    VariavelResultado = "K", UnidadeResultado = "chaves"
                },
                new Formula
                {
                    Id = "C5209", Nome = "Taxa de Falsos Positivos (FPR) de IDS",
                    Categoria = "Segurança da Informação", SubCategoria = "Detecção de Intrusão",
                    Expressao = "FPR = FP / (FP + TN)",
                    Descricao = "Fração de tráfego legítimo incorretamente classificado como ataque pelo sistema de detecção de intrusão.",
                    Criador = "Prática de IDS", AnoOrigin = "1990",
                    ReferenciaBibliografica = "Northcutt S, Novak J. Network Intrusion Detection, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Falsos Positivos (FP)", Simbolo = "FP", Unidade = "eventos", ValorPadrao = 50 },
                        new Variavel { Nome = "Verdadeiros Negativos (TN)", Simbolo = "TN", Unidade = "eventos", ValorPadrao = 950, ValorMin = 0 }
                    },
                    Calcular = v => v["FP"] / (v["FP"] + v["TN"]),
                    VariavelResultado = "FPR", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5210", Nome = "Taxa de Detecção de Ataques (TPR / Recall)",
                    Categoria = "Segurança da Informação", SubCategoria = "Detecção de Intrusão",
                    Expressao = "TPR = TP / (TP + FN)",
                    Descricao = "Fração de ataques reais corretamente detectados pelo IDS; também chamada sensibilidade ou recall.",
                    Criador = "Prática de IDS", AnoOrigin = "1990",
                    ReferenciaBibliografica = "Northcutt S, Novak J. Network Intrusion Detection, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Verdadeiros Positivos (TP)", Simbolo = "TP", Unidade = "eventos", ValorPadrao = 90 },
                        new Variavel { Nome = "Falsos Negativos (FN)", Simbolo = "FN", Unidade = "eventos", ValorPadrao = 10, ValorMin = 0 }
                    },
                    Calcular = v => v["TP"] / (v["TP"] + v["FN"]),
                    VariavelResultado = "TPR", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5211", Nome = "Custo Esperado de Violação de Dados",
                    Categoria = "Segurança da Informação", SubCategoria = "Economia de Segurança",
                    Expressao = "Custo_esp = P_violação × Custo_violação",
                    Descricao = "Custo esperado anual de violação de dados; base para decisões de investimento em segurança.",
                    Criador = "Gordon LA, Loeb MP", AnoOrigin = "2002",
                    ReferenciaBibliografica = "Gordon LA, Loeb MP. ACM Trans Inf Syst Secur, 2002.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Probabilidade anual de violação", Simbolo = "P_violacao", Unidade = "", ValorPadrao = 0.1, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Custo de violação ($)", Simbolo = "Custo_violacao", Unidade = "USD", ValorPadrao = 4000000 }
                    },
                    Calcular = v => v["P_violacao"] * v["Custo_violacao"],
                    VariavelResultado = "Custo_esp", UnidadeResultado = "USD/ano"
                },
                new Formula
                {
                    Id = "C5212", Nome = "ROI de Segurança (ROSI)",
                    Categoria = "Segurança da Informação", SubCategoria = "Economia de Segurança",
                    Expressao = "ROSI = (ALE_antes − ALE_depois − Custo_controle) / Custo_controle",
                    Descricao = "Retorno sobre investimento em segurança (ROSI); ALE = perda anual esperada.",
                    Criador = "Sonnenreich W et al.", AnoOrigin = "2006",
                    ReferenciaBibliografica = "Sonnenreich W et al. Proc SPIE Defense and Security Symp, 2006.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "ALE antes do controle", Simbolo = "ALE_antes", Unidade = "USD", ValorPadrao = 500000 },
                        new Variavel { Nome = "ALE depois do controle", Simbolo = "ALE_depois", Unidade = "USD", ValorPadrao = 100000 },
                        new Variavel { Nome = "Custo do controle anual", Simbolo = "Custo_ctrl", Unidade = "USD", ValorPadrao = 50000, ValorMin = 1 }
                    },
                    Calcular = v => (v["ALE_antes"] - v["ALE_depois"] - v["Custo_ctrl"]) / v["Custo_ctrl"],
                    VariavelResultado = "ROSI", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5213", Nome = "Overhead de VPN (Eficiência de Throughput)",
                    Categoria = "Segurança da Informação", SubCategoria = "Redes Seguras",
                    Expressao = "η = Dados_úteis / (Dados_úteis + Overhead_encriptação)",
                    Descricao = "Eficiência de transmissão de VPN; overhead inclui cabeçalhos de encriptação e autenticação.",
                    Criador = "Prática de redes", AnoOrigin = "1990",
                    ReferenciaBibliografica = "Stallings W. Network Security Essentials, 6ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Dados úteis (bytes)", Simbolo = "dados_uteis", Unidade = "bytes", ValorPadrao = 1400 },
                        new Variavel { Nome = "Overhead de encriptação (bytes)", Simbolo = "overhead", Unidade = "bytes", ValorPadrao = 60, ValorMin = 0 }
                    },
                    Calcular = v => v["dados_uteis"] / (v["dados_uteis"] + v["overhead"]),
                    VariavelResultado = "η", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5214", Nome = "CRC-32 (Polinômio de Verificação)",
                    Categoria = "Segurança da Informação", SubCategoria = "Integridade de Dados",
                    Expressao = "Tamanho do CRC = 2^32 valores possíveis",
                    Descricao = "CRC-32 usa polinômio gerador de 32 bits; probabilidade de colisão não-detectada ≈ 1/2³² ≈ 2,3×10⁻¹⁰.",
                    Criador = "Peterson WW, Brown DT", AnoOrigin = "1961",
                    ReferenciaBibliografica = "Peterson WW, Brown DT. Proc IRE, 1961.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Bits do CRC (n)", Simbolo = "n", Unidade = "bits", ValorPadrao = 32, ValorMin = 1 }
                    },
                    Calcular = v => 1.0 / Math.Pow(2, v["n"]),
                    VariavelResultado = "P(colisão não-detectada)", UnidadeResultado = "probabilidade"
                },
                new Formula
                {
                    Id = "C5215", Nome = "Tamanho de Chave RSA vs Segurança Equivalente",
                    Categoria = "Segurança da Informação", SubCategoria = "Criptografia Assimétrica",
                    Expressao = "Segurança_eq ≈ L^(1/3) × (ln L)^(2/3) / 64 (estimativa GNFS)",
                    Descricao = "Estimativa de bits de segurança equivalente de chave RSA de L bits via algoritmo GNFS; RSA-2048 ≈ 112 bits.",
                    Criador = "NIST SP 800-57", AnoOrigin = "2020",
                    ReferenciaBibliografica = "NIST SP 800-57 Part 1 Rev. 5, 2020.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tamanho da chave RSA (L)", Simbolo = "L", Unidade = "bits", ValorPadrao = 2048, ValorMin = 512 }
                    },
                    Calcular = v => Math.Pow(v["L"], 1.0/3) * Math.Pow(Math.Log(v["L"]), 2.0/3) / 64.0 * 20,
                    VariavelResultado = "Segurança_eq (aprox.)", UnidadeResultado = "bits"
                },
                new Formula
                {
                    Id = "C5216", Nome = "Distância de Unicidade (Criptoanálise)",
                    Categoria = "Segurança da Informação", SubCategoria = "Criptoanálise",
                    Expressao = "U = H(K) / D",
                    Descricao = "Número mínimo de caracteres de texto cifrado necessários para quebrar cifra de forma única; D = redundância.",
                    Criador = "Shannon CE", AnoOrigin = "1949",
                    ReferenciaBibliografica = "Shannon CE. Bell Syst Tech J, 1949.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Entropia da chave H(K)", Simbolo = "H_K", Unidade = "bits", ValorPadrao = 128 },
                        new Variavel { Nome = "Redundância da língua (D)", Simbolo = "D", Unidade = "bits/char", ValorPadrao = 3.2, ValorMin = 0.01 }
                    },
                    Calcular = v => v["H_K"] / v["D"],
                    VariavelResultado = "U", UnidadeResultado = "caracteres"
                },
                new Formula
                {
                    Id = "C5217", Nome = "Taxa de Compressão",
                    Categoria = "Segurança da Informação", SubCategoria = "Compressão / Estenografia",
                    Expressao = "CR = Tamanho_original / Tamanho_comprimido",
                    Descricao = "Razão de compressão de dado; pode revelar informação sobre conteúdo via análise de tamanho (oracle).",
                    Criador = "Prática de compressão", AnoOrigin = "1977",
                    ReferenciaBibliografica = "Ziv J, Lempel A. IEEE Trans Inf Theory, 1977.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tamanho original (bytes)", Simbolo = "T_orig", Unidade = "bytes", ValorPadrao = 10000, ValorMin = 1 },
                        new Variavel { Nome = "Tamanho comprimido (bytes)", Simbolo = "T_comp", Unidade = "bytes", ValorPadrao = 3000, ValorMin = 1 }
                    },
                    Calcular = v => v["T_orig"] / v["T_comp"],
                    VariavelResultado = "CR", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5218", Nome = "F1-Score de Detector de Malware",
                    Categoria = "Segurança da Informação", SubCategoria = "Detecção de Malware",
                    Expressao = "F1 = 2 × (P × R) / (P + R)",
                    Descricao = "Média harmônica de precisão (P) e recall (R); métrica balanceada de desempenho de detectores de ameaças.",
                    Criador = "Van Rijsbergen CJ", AnoOrigin = "1979",
                    ReferenciaBibliografica = "Van Rijsbergen CJ. Information Retrieval, 2ª ed. 1979.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Precisão (P)", Simbolo = "P", Unidade = "", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Recall (R)", Simbolo = "R", Unidade = "", ValorPadrao = 0.90, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => 2 * v["P"] * v["R"] / (v["P"] + v["R"]),
                    VariavelResultado = "F1", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5219", Nome = "Perda Anual Esperada (ALE)",
                    Categoria = "Segurança da Informação", SubCategoria = "Gestão de Risco",
                    Expressao = "ALE = ARO × SLE",
                    Descricao = "Perda anual esperada é o produto da frequência anual de ocorrência (ARO) pelo valor de perda por evento (SLE).",
                    Criador = "Prática de análise de risco", AnoOrigin = "1970",
                    ReferenciaBibliografica = "NIST SP 800-30 Rev. 1, 2012.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Taxa anual de ocorrência (ARO)", Simbolo = "ARO", Unidade = "eventos/ano", ValorPadrao = 0.5 },
                        new Variavel { Nome = "Perda por evento (SLE)", Simbolo = "SLE", Unidade = "USD", ValorPadrao = 200000 }
                    },
                    Calcular = v => v["ARO"] * v["SLE"],
                    VariavelResultado = "ALE", UnidadeResultado = "USD/ano"
                },
                new Formula
                {
                    Id = "C5220", Nome = "Tempo Médio para Detectar (MTTD)",
                    Categoria = "Segurança da Informação", SubCategoria = "Resposta a Incidentes",
                    Expressao = "MTTD = Σ(tempo_detecção) / n_incidentes",
                    Descricao = "Tempo médio entre ocorrência do incidente e sua detecção; indicador-chave de maturidade de SOC.",
                    Criador = "MITRE ATT&CK Framework", AnoOrigin = "2013",
                    ReferenciaBibliografica = "IBM Security. Cost of a Data Breach Report, 2023.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma dos tempos de detecção (h)", Simbolo = "sum_t", Unidade = "h", ValorPadrao = 600 },
                        new Variavel { Nome = "Número de incidentes", Simbolo = "n", Unidade = "", ValorPadrao = 10, ValorMin = 1 }
                    },
                    Calcular = v => v["sum_t"] / v["n"],
                    VariavelResultado = "MTTD", UnidadeResultado = "h"
                },
                new Formula
                {
                    Id = "C5221", Nome = "Segurança de Curva Elíptica vs RSA",
                    Categoria = "Segurança da Informação", SubCategoria = "Criptografia",
                    Expressao = "bits_EC_equivalente ≈ bits_RSA / 7,5 (aprox. p/ 128-bit security: ECC-256 ≈ RSA-3072)",
                    Descricao = "Comparação de eficiência: ECC oferece segurança equivalente com chaves muito menores que RSA.",
                    Criador = "Koblitz N / Miller VS", AnoOrigin = "1985",
                    ReferenciaBibliografica = "NIST SP 800-57 Part 1 Rev. 5, 2020.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tamanho de chave RSA equivalente (bits)", Simbolo = "bits_RSA", Unidade = "bits", ValorPadrao = 3072, ValorMin = 512 }
                    },
                    Calcular = v => v["bits_RSA"] / 7.5,
                    VariavelResultado = "bits_ECC_equiv", UnidadeResultado = "bits"
                },
                new Formula
                {
                    Id = "C5222", Nome = "Probabilidade de Sucesso de Ataque de Dicionário",
                    Categoria = "Segurança da Informação", SubCategoria = "Criptoanálise",
                    Expressao = "P = 1 − (1 − p)^n",
                    Descricao = "Probabilidade de encontrar senha em n tentativas dado que cada tentativa tem probabilidade p de sucesso.",
                    Criador = "Prática de criptoanálise", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Florêncio D, Herley C. WWW 2007.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Probabilidade por tentativa (p)", Simbolo = "p", Unidade = "", ValorPadrao = 1e-6, ValorMin = 1e-20, ValorMax = 1 },
                        new Variavel { Nome = "Número de tentativas (n)", Simbolo = "n", Unidade = "", ValorPadrao = 1000000 }
                    },
                    Calcular = v => 1 - Math.Pow(1 - v["p"], v["n"]),
                    VariavelResultado = "P(sucesso)", UnidadeResultado = "probabilidade"
                },
                new Formula
                {
                    Id = "C5223", Nome = "Nível de Conformidade de Controles (Score de Maturidade)",
                    Categoria = "Segurança da Informação", SubCategoria = "Governança",
                    Expressao = "Score = (Controles_implementados / Total_controles) × 100",
                    Descricao = "Percentual de controles de segurança implementados em relação ao framework (ISO 27001, NIST CSF, etc.).",
                    Criador = "ISO/IEC 27001", AnoOrigin = "2005",
                    ReferenciaBibliografica = "ISO/IEC 27001:2022. Information Security Management Systems.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Controles implementados", Simbolo = "C_impl", Unidade = "", ValorPadrao = 80 },
                        new Variavel { Nome = "Total de controles", Simbolo = "C_total", Unidade = "", ValorPadrao = 93, ValorMin = 1 }
                    },
                    Calcular = v => v["C_impl"] / v["C_total"] * 100,
                    VariavelResultado = "Score", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5224", Nome = "Probabilidade de Acesso Não-Autorizado (Bayes)",
                    Categoria = "Segurança da Informação", SubCategoria = "Autenticação",
                    Expressao = "P(fraude|alerta) = P(alerta|fraude) × P(fraude) / P(alerta)",
                    Descricao = "Probabilidade de ser fraude dado alerta do sistema, pelo Teorema de Bayes; base de sistemas anti-fraude.",
                    Criador = "Bayes T / Laplace PS", AnoOrigin = "1763 / 1812",
                    ReferenciaBibliografica = "Bishop CM. Pattern Recognition and Machine Learning. Springer, 2006.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "P(alerta|fraude) - TPR", Simbolo = "P_alerta_fraude", Unidade = "", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "P(fraude) - prevalência", Simbolo = "P_fraude", Unidade = "", ValorPadrao = 0.001, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "P(alerta) - taxa de alertas", Simbolo = "P_alerta", Unidade = "", ValorPadrao = 0.01, ValorMin = 0.001 }
                    },
                    Calcular = v => v["P_alerta_fraude"] * v["P_fraude"] / v["P_alerta"],
                    VariavelResultado = "P(fraude|alerta)", UnidadeResultado = "probabilidade"
                },
                new Formula
                {
                    Id = "C5225", Nome = "Índice de Exposição de Vulnerabilidade (CVSS Base Score)",
                    Categoria = "Segurança da Informação", SubCategoria = "Vulnerabilidades",
                    Expressao = "CVSS ≈ 10 × AV × AC × Au × (C + I + A) / 10 (simplificado v2)",
                    Descricao = "Score de severidade de vulnerabilidade (0-10) baseado em vetores de exploração e impacto (CVSS v2 simplificado).",
                    Criador = "FIRST.org / NVD", AnoOrigin = "2005",
                    ReferenciaBibliografica = "CVSS v2 Guide, NIST NVD, 2007.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Vetor de acesso (AV: 0.395=local, 0.646=adj, 1=remoto)", Simbolo = "AV", Unidade = "", ValorPadrao = 1.0, ValorMin = 0.395, ValorMax = 1.0 },
                        new Variavel { Nome = "Complexidade de acesso (AC: 1=baixa, 0.61=med, 0.35=alta)", Simbolo = "AC", Unidade = "", ValorPadrao = 1.0, ValorMin = 0.35, ValorMax = 1.0 },
                        new Variavel { Nome = "Impacto confidencialidade (0-0.66)", Simbolo = "C", Unidade = "", ValorPadrao = 0.66, ValorMin = 0, ValorMax = 0.66 },
                        new Variavel { Nome = "Impacto integridade (0-0.66)", Simbolo = "I", Unidade = "", ValorPadrao = 0.66, ValorMin = 0, ValorMax = 0.66 },
                        new Variavel { Nome = "Impacto disponibilidade (0-0.66)", Simbolo = "A", Unidade = "", ValorPadrao = 0.66, ValorMin = 0, ValorMax = 0.66 }
                    },
                    Calcular = v => Math.Min(10, 10 * v["AV"] * v["AC"] * (v["C"] + v["I"] + v["A"]) / 10.0),
                    VariavelResultado = "CVSS_base", UnidadeResultado = "score (0-10)"
                }
            });
        }
    }
}
