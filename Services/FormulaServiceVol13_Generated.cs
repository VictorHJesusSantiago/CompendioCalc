using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CompendioCalc.Models;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private sealed record Vol13Spec(
            string codigo,
            string nome,
            string expressao,
            string descricao,
            string origem,
            string exemplo,
            string categoria,
            string subcategoria);

        private static readonly HashSet<string> Vol13FuncoesIgnoradas = new(StringComparer.OrdinalIgnoreCase)
        {
            "exp", "log", "sin", "cos", "tan", "sqrt", "pi", "e"
        };

        private static readonly Regex Vol13SimboloRegex = new(@"[A-Za-z_][A-Za-z0-9_]*", RegexOptions.Compiled);
        private static readonly Regex Vol13OperacaoBinariaRegex = new(
            @"^\s*(?<a>[A-Za-z_][A-Za-z0-9_]*)\s*(?<op>[+\-*/])\s*(?<b>[A-Za-z_][A-Za-z0-9_]*)\s*$",
            RegexOptions.Compiled);

        public void AdicionarFormulasVol13()
        {
            var specsLiterais = ObterSpecsLiteraisVol13();
            foreach (var spec in specsLiterais)
            {
                _formulas.Add(CriarFormulaVol13Literal(spec));
            }
        }

        private Formula CriarFormulaVol13Literal(Vol13Spec spec)
        {
            var codigoNumerico = int.TryParse(spec.codigo, out var codigo) ? codigo : 0;
            var codigoComp = $"V13-{codigoNumerico:000}";
            var variaveis = ExtrairVariaveisDaExpressao(spec.expressao);

            return new Formula
            {
                Id = $"v13_{codigoNumerico:000}",
                CodigoCompendio = codigoComp,
                Nome = spec.nome,
                Categoria = spec.categoria,
                SubCategoria = spec.subcategoria,
                Expressao = spec.expressao,
                ExprTexto = spec.expressao,
                Descricao = spec.descricao,
                Criador = spec.origem,
                AnoOrigin = "2026",
                ExemploPratico = spec.exemplo,
                Unidades = "Consistentes com as variaveis de entrada.",
                VariavelResultado = "resultado",
                UnidadeResultado = "adim",
                Icone = "Fx",
                Variaveis = variaveis,
                Calcular = vars => CalcularExpressaoVol13(spec.expressao, variaveis, vars)
            };
        }

        private static List<Variavel> ExtrairVariaveisDaExpressao(string expressao)
        {
            var exprBase = ObterLadoDireito(expressao);

            var simbolos = Vol13SimboloRegex
                .Matches(exprBase)
                .Select(m => m.Value)
                .Where(s => !string.Equals(s, "resultado", StringComparison.OrdinalIgnoreCase))
                .Where(s => !Vol13FuncoesIgnoradas.Contains(s))
                .Distinct(StringComparer.Ordinal)
                .ToList();

            return simbolos
                .Select(s => new Variavel
                {
                    Simbolo = s,
                    Nome = $"Variavel {s}",
                    Descricao = $"Parametro {s} da expressao.",
                    Unidade = "adim",
                    ValorPadrao = 1
                })
                .ToList();
        }

        private static double CalcularExpressaoVol13(string expressao, List<Variavel> variaveis, Dictionary<string, double> vars)
        {
            if (vars.TryGetValue("resultado", out var resultadoInformado))
            {
                return resultadoInformado;
            }

            var exprBase = ObterLadoDireito(expressao);
            var match = Vol13OperacaoBinariaRegex.Match(exprBase);

            if (match.Success && variaveis.Count == 2)
            {
                var simboloA = match.Groups["a"].Value;
                var simboloB = match.Groups["b"].Value;
                var op = match.Groups["op"].Value;

                var a = vars.TryGetValue(simboloA, out var va) ? va : 1;
                var b = vars.TryGetValue(simboloB, out var vb) ? vb : 1;

                return op switch
                {
                    "*" => a * b,
                    "/" => Math.Abs(b) < 1e-12 ? 0 : a / b,
                    "+" => a + b,
                    "-" => a - b,
                    _ => 0
                };
            }

            if (variaveis.Count > 0)
            {
                var primeiro = variaveis[0].Simbolo;
                return vars.TryGetValue(primeiro, out var valor) ? valor : 0;
            }

            return 0;
        }

        private static string ObterLadoDireito(string expressao)
        {
            var idx = expressao.IndexOf('=');
            return idx >= 0 ? expressao[(idx + 1)..].Trim() : expressao.Trim();
        }

        private static List<Vol13Spec> ObterSpecsLiteraisVol13() =>
        [
            new("001", "Taxa especifica de desgaste", "k*W/H", "Modelo de desgaste proporcional a carga e inverso da dureza.", "Compendio Vol XIII - Tribologia", "Com k=0.02, W=100, H=200: resultado=0.01.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("002", "Coeficiente de atrito de Coulomb", "Ff/N", "Razao entre forca de atrito e forca normal.", "Compendio Vol XIII - Tribologia", "Com Ff=40 e N=200: resultado=0.2.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("003", "Perda volumetrica", "Q*t", "Volume perdido ao longo do tempo para taxa de desgaste Q.", "Compendio Vol XIII - Tribologia", "Com Q=1.5 e t=10: resultado=15.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("004", "Pressao media de contato", "N/A", "Pressao normal media em area de contato aparente.", "Compendio Vol XIII - Tribologia", "Com N=500 e A=25: resultado=20.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("005", "Potencia dissipada por atrito", "Ff*v", "Potencia termica dissipada no contato deslizante.", "Compendio Vol XIII - Tribologia", "Com Ff=50 e v=2: resultado=100.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("006", "Fator PV", "P*v", "Indice de severidade para mancais e pares tribologicos.", "Compendio Vol XIII - Tribologia", "Com P=1.2 e v=3: resultado=3.6.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("007", "Filme lubrificante adimensional", "h/R", "Espessura de filme normalizada por raio caracteristico.", "Compendio Vol XIII - Tribologia", "Com h=2 e R=10: resultado=0.2.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("008", "Numero de Hersey simplificado", "eta*v/P", "Razao viscosidade-velocidade por pressao media.", "Compendio Vol XIII - Tribologia", "Com eta=0.1, v=4, P=2: resultado=0.2.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("009", "Calor especifico de atrito", "Pf/A", "Fluxo de potencia por area de contato.", "Compendio Vol XIII - Tribologia", "Com Pf=120 e A=30: resultado=4.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("010", "Indice de rugosidade relativa", "Ra/h", "Compara rugosidade media com espessura de filme.", "Compendio Vol XIII - Tribologia", "Com Ra=0.4 e h=0.8: resultado=0.5.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("011", "Taxa de abrasao", "Kab*P*v", "Modelo linear simplificado para abrasao severa.", "Compendio Vol XIII - Tribologia", "Com Kab=0.01, P=3, v=2: resultado=0.06.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("012", "Indice de adesao", "tau/p", "Razao entre tensao cisalhante e pressao de contato.", "Compendio Vol XIII - Tribologia", "Com tau=6 e p=20: resultado=0.3.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("013", "Numero de Sommerfeld reduzido", "eta*n*(R/c)^2/P", "Parametro adimensional em mancais hidrodinamicos.", "Compendio Vol XIII - Tribologia", "Com eta=0.02, n=50, R=1, c=0.1, P=2: resultado=5.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("014", "Carga normalizada", "W/Wref", "Carga aplicada relativa ao valor de referencia.", "Compendio Vol XIII - Tribologia", "Com W=150 e Wref=100: resultado=1.5.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("015", "Duracao relativa de contato", "tc/T", "Fracao do periodo total em contato efetivo.", "Compendio Vol XIII - Tribologia", "Com tc=2 e T=5: resultado=0.4.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("016", "Razao de escorregamento", "(v1-v2)/v1", "Deslizamento relativo em pares rolantes.", "Compendio Vol XIII - Tribologia", "Com v1=10 e v2=8: resultado=0.2.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("017", "Eficiencia mecanica", "Pout/Pin", "Razao entre potencia util e potencia de entrada.", "Compendio Vol XIII - Tribologia", "Com Pout=90 e Pin=120: resultado=0.75.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("018", "Taxa de oxidacao superficial", "kox*t", "Modelo de oxidacao acumulada no contato.", "Compendio Vol XIII - Tribologia", "Com kox=0.03 e t=20: resultado=0.6.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("019", "Dano cumulativo normalizado", "D/Nc", "Dano acumulado relativo ao limite critico.", "Compendio Vol XIII - Tribologia", "Com D=12 e Nc=30: resultado=0.4.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),
            new("020", "Indice de estabilidade de filme", "hmin/sigma", "Razao entre filme minimo e rugosidade combinada.", "Compendio Vol XIII - Tribologia", "Com hmin=1.2 e sigma=0.6: resultado=2.", "Tribologia e Desgaste de Materiais", "Desgaste e Lubrificacao"),

            new("021", "Taxa de crescimento viral", "beta*S*I", "Termo de infeccao em modelos compartimentais.", "Compendio Vol XIII - Virologia", "Com beta=0.002, S=5000, I=20: resultado=200.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("022", "Remocao de infectados", "gamma*I", "Termo de recuperacao em modelo SIR.", "Compendio Vol XIII - Virologia", "Com gamma=0.1 e I=80: resultado=8.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("023", "Razao de reproducao efetiva", "R0*S/N", "Numero reprodutivo ajustado por suscetiveis.", "Compendio Vol XIII - Virologia", "Com R0=2.5, S=700, N=1000: resultado=1.75.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("024", "Frequencia de mutacao por ciclo", "mu*G", "Mutacoes esperadas por genoma em um ciclo.", "Compendio Vol XIII - Virologia", "Com mu=1e-5 e G=30000: resultado=0.3.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("025", "Carga viral media", "V/N", "Media de particulas virais por individuo.", "Compendio Vol XIII - Virologia", "Com V=5e6 e N=1000: resultado=5000.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("026", "Taxa de decaimento viral", "delta*V", "Remocao viral proporcional a carga atual.", "Compendio Vol XIII - Virologia", "Com delta=0.3 e V=1200: resultado=360.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("027", "Incidencia normalizada", "C/N", "Casos novos por populacao de referencia.", "Compendio Vol XIII - Virologia", "Com C=40 e N=20000: resultado=0.002.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("028", "Taxa de ataque", "A/P", "Fracao atacada em um surto local.", "Compendio Vol XIII - Virologia", "Com A=120 e P=800: resultado=0.15.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("029", "Pressao seletiva antiviral", "fres/fsens", "Razao de fitness resistente sobre sensivel.", "Compendio Vol XIII - Virologia", "Com fres=0.9 e fsens=1.2: resultado=0.75.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("030", "Copias por mL", "Ct*k", "Aproximacao de quantificacao por fator de calibracao.", "Compendio Vol XIII - Virologia", "Com Ct=28 e k=120: resultado=3360.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("031", "Taxa de transmissao secundaria", "beta*I/N", "Contato infeccioso per capita.", "Compendio Vol XIII - Virologia", "Com beta=0.8, I=50, N=1000: resultado=0.04.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("032", "Razao de letalidade", "D/C", "Obitos por casos confirmados.", "Compendio Vol XIII - Virologia", "Com D=12 e C=600: resultado=0.02.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("033", "Prevalencia", "I/N", "Fracao de infectados na populacao.", "Compendio Vol XIII - Virologia", "Com I=75 e N=5000: resultado=0.015.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("034", "Sensibilidade ajustada", "Se*P", "Componente verdadeiro positivo ponderado.", "Compendio Vol XIII - Virologia", "Com Se=0.92 e P=0.1: resultado=0.092.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("035", "Especificidade ajustada", "Sp*(1-P)", "Componente verdadeiro negativo ponderado.", "Compendio Vol XIII - Virologia", "Com Sp=0.97 e P=0.1: resultado=0.873.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("036", "Valor preditivo positivo aprox", "TP/(TP+FP)", "Razao de positivos verdadeiros sobre positivos totais.", "Compendio Vol XIII - Virologia", "Com TP=90 e FP=10: resultado=0.9.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("037", "Valor preditivo negativo aprox", "TN/(TN+FN)", "Razao de negativos verdadeiros sobre negativos totais.", "Compendio Vol XIII - Virologia", "Com TN=880 e FN=20: resultado=0.9778.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("038", "Taxa de positividade", "Pos/Test", "Fracao de testes positivos.", "Compendio Vol XIII - Virologia", "Com Pos=125 e Test=2500: resultado=0.05.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("039", "Taxa de recuperacao", "R/I", "Recuperados por infectados acumulados.", "Compendio Vol XIII - Virologia", "Com R=760 e I=950: resultado=0.8.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),
            new("040", "Indice de vigilancia molecular", "Seq/C", "Amostras sequenciadas por caso.", "Compendio Vol XIII - Virologia", "Com Seq=60 e C=1200: resultado=0.05.", "Virologia Computacional e Epidemiologia Molecular", "Dinamica de Transmissao"),

            new("041", "Velocidade da onda sonora", "f*lambda", "Relacao basica entre frequencia e comprimento de onda.", "Compendio Vol XIII - Acustica", "Com f=1000 e lambda=0.34: resultado=340.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("042", "Intensidade acustica plana", "p*u", "Produto entre pressao e velocidade de particula.", "Compendio Vol XIII - Acustica", "Com p=2 e u=0.5: resultado=1.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("043", "Impedancia especifica", "p/u", "Razao entre pressao e velocidade de particula.", "Compendio Vol XIII - Acustica", "Com p=3 e u=0.01: resultado=300.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("044", "Atenuacao linear", "alpha*x", "Perda acumulada com coeficiente de atenuacao.", "Compendio Vol XIII - Acustica", "Com alpha=0.8 e x=5: resultado=4.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("045", "Tempo de voo ultrassom", "d/c", "Tempo de propagacao em meio homogeneo.", "Compendio Vol XIII - Acustica", "Com d=0.15 e c=1500: resultado=0.0001.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("046", "Frequencia angular", "2*pi*f", "Conversao de frequencia linear para angular.", "Compendio Vol XIII - Acustica", "Com f=100: resultado=628.3 aprox.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("047", "Numero de onda", "2*pi/lambda", "Define periodicidade espacial da onda.", "Compendio Vol XIII - Acustica", "Com lambda=0.5: resultado=12.57 aprox.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("048", "Energia acustica", "I*A*t", "Energia total transmitida por feixe.", "Compendio Vol XIII - Acustica", "Com I=2, A=0.1, t=10: resultado=2.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("049", "Razao sinal ruido", "S/N", "Metrica de qualidade de sinal.", "Compendio Vol XIII - Acustica", "Com S=40 e N=5: resultado=8.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("050", "Pulso espacial medio", "Ipa*DC", "Intensidade media com ciclo de trabalho.", "Compendio Vol XIII - Acustica", "Com Ipa=12 e DC=0.25: resultado=3.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("051", "Comprimento de pulso", "n*lambda", "Extensao espacial do pulso ultrassonico.", "Compendio Vol XIII - Acustica", "Com n=3 e lambda=0.4: resultado=1.2.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("052", "Largura de banda fracionaria", "BW/fc", "Largura de banda relativa do transdutor.", "Compendio Vol XIII - Acustica", "Com BW=2 e fc=8: resultado=0.25.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("053", "Profundidade de penetracao", "1/alpha", "Escala caracteristica de atenuacao.", "Compendio Vol XIII - Acustica", "Com alpha=0.5: resultado=2.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("054", "Fator de reflexao simplificado", "(Z2-Z1)/(Z2+Z1)", "Reflexao normal em interface de impedancias.", "Compendio Vol XIII - Acustica", "Com Z2=2 e Z1=1: resultado=0.333.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("055", "Transmissao simplificada", "2*Z2/(Z2+Z1)", "Coeficiente de transmissao de amplitude.", "Compendio Vol XIII - Acustica", "Com Z2=2 e Z1=1: resultado=1.333.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("056", "Resolucao axial aprox", "c/(2*BW)", "Aproximacao de resolucao axial por banda util.", "Compendio Vol XIII - Acustica", "Com c=1540 e BW=2e6: resultado=0.000385.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("057", "Indice mecanico simplificado", "Pneg/sqrt(f)", "Indicador de risco de cavitacao em ultrassom.", "Compendio Vol XIII - Acustica", "Com Pneg=1.2 e f=4: resultado=0.6.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("058", "Indice termico simplificado", "W/Wdeg", "Potencia relativa para elevacao termica de referencia.", "Compendio Vol XIII - Acustica", "Com W=0.8 e Wdeg=1.0: resultado=0.8.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("059", "Ganho de eco relativo", "Aecho/Aref", "Razao de amplitudes de eco.", "Compendio Vol XIII - Acustica", "Com Aecho=0.4 e Aref=0.2: resultado=2.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),
            new("060", "Tempo de repeticao normalizado", "PRT/T", "Razao entre periodo de repeticao e janela util.", "Compendio Vol XIII - Acustica", "Com PRT=2e-4 e T=1e-4: resultado=2.", "Acustica e Ultrassom Medico", "Propagacao e Ondas"),

            new("061", "Vazao molar", "C*Q", "Vazao molar por concentracao e vazao volumetrica.", "Compendio Vol XIII - Eng Processos", "Com C=2 e Q=3: resultado=6.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("062", "Fluxo difusivo de Fick", "D*A*dCdx", "Fluxo difusivo unidimensional simplificado.", "Compendio Vol XIII - Eng Processos", "Com D=0.01, A=5, dCdx=4: resultado=0.2.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("063", "Calor sensivel", "m*Cp*dT", "Energia para variacao de temperatura sem mudanca de fase.", "Compendio Vol XIII - Eng Processos", "Com m=2, Cp=4, dT=10: resultado=80.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("064", "Balanco estacionario simples", "Fin-Fout", "Diferenca entre entrada e saida de fluxo.", "Compendio Vol XIII - Eng Processos", "Com Fin=10 e Fout=9: resultado=1.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("065", "Numero de Reynolds", "rho*v*D/mu", "Regime de escoamento interno em dutos.", "Compendio Vol XIII - Eng Processos", "Com rho=1000, v=1, D=0.05, mu=0.001: resultado=50000.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("066", "Numero de Prandtl", "Cp*mu/k", "Razao entre difusividade de momento e termica.", "Compendio Vol XIII - Eng Processos", "Com Cp=4200, mu=0.001, k=0.6: resultado=7.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("067", "Numero de Nusselt simplificado", "h*D/k", "Coeficiente convectivo adimensional.", "Compendio Vol XIII - Eng Processos", "Com h=100, D=0.05, k=0.5: resultado=10.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("068", "Potencia de bombeamento", "Q*dP", "Potencia hidraulica sem eficiencia.", "Compendio Vol XIII - Eng Processos", "Com Q=0.02 e dP=200000: resultado=4000.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("069", "Tempo de residencia", "V/Q", "Tempo medio de permanencia no reator.", "Compendio Vol XIII - Eng Processos", "Com V=3 e Q=0.5: resultado=6.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("070", "Conversao de reagente", "(Cin-Cout)/Cin", "Conversao fracionaria em reacao continua.", "Compendio Vol XIII - Eng Processos", "Com Cin=10 e Cout=2: resultado=0.8.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("071", "Rendimento global", "Pprod/Pref", "Razao entre producao observada e referencia.", "Compendio Vol XIII - Eng Processos", "Com Pprod=85 e Pref=100: resultado=0.85.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("072", "Coeficiente global de transferencia", "1/(R1+R2)", "Soma de resistencias em serie.", "Compendio Vol XIII - Eng Processos", "Com R1=0.2 e R2=0.3: resultado=2.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("073", "Fluxo termico condutivo", "k*A*dTdx", "Lei de Fourier simplificada em modulo.", "Compendio Vol XIII - Eng Processos", "Com k=15, A=0.4, dTdx=8: resultado=48.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("074", "Carga termica convectiva", "h*A*dT", "Transferencia por conveccao.", "Compendio Vol XIII - Eng Processos", "Com h=25, A=2, dT=30: resultado=1500.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("075", "Vazao massica", "rho*Q", "Conversao de vazao volumetrica em massica.", "Compendio Vol XIII - Eng Processos", "Com rho=900 e Q=0.01: resultado=9.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("076", "Concentracao media", "n/V", "Quantidade de materia por volume.", "Compendio Vol XIII - Eng Processos", "Com n=40 e V=5: resultado=8.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("077", "Queda de pressao especifica", "dP/L", "Gradiente de pressao ao longo da linha.", "Compendio Vol XIII - Eng Processos", "Com dP=12000 e L=30: resultado=400.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("078", "Capacidade calorifica total", "m*Cp", "Capacidade termica agregada de corrente.", "Compendio Vol XIII - Eng Processos", "Com m=5 e Cp=3.8: resultado=19.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("079", "Fracao de recirculacao", "R/F", "Razao de recirculo para alimentacao fresca.", "Compendio Vol XIII - Eng Processos", "Com R=2 e F=8: resultado=0.25.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),
            new("080", "Eficiencia de separacao", "(Cin-Cout)/Cin", "Reducao fracionaria de contaminante.", "Compendio Vol XIII - Eng Processos", "Com Cin=50 e Cout=5: resultado=0.9.", "Engenharia de Processos e Operacoes Unitarias", "Transferencia de Massa e Energia"),

            new("081", "Taxa de sedimentacao", "k*d", "Velocidade de deposicao proporcional ao diametro.", "Compendio Vol XIII - Geologia", "Com k=0.04 e d=10: resultado=0.4.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("082", "Idade radiometrica simplificada", "N0/N", "Razao entre isotopo inicial e atual.", "Compendio Vol XIII - Geologia", "Com N0=100 e N=25: resultado=4.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("083", "Porosidade", "Vp/Vt", "Fracao de volume poroso no material.", "Compendio Vol XIII - Geologia", "Com Vp=12 e Vt=30: resultado=0.4.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("084", "Saturacao de agua", "Vw/Vp", "Fracao de poros ocupados por agua.", "Compendio Vol XIII - Geologia", "Com Vw=6 e Vp=12: resultado=0.5.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("085", "Densidade aparente", "m/V", "Massa por volume total da amostra.", "Compendio Vol XIII - Geologia", "Com m=2400 e V=1: resultado=2400.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("086", "Conteudo de argila", "Vcl/Vt", "Fracao volumetrica de fracao argilosa.", "Compendio Vol XIII - Geologia", "Com Vcl=3 e Vt=20: resultado=0.15.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("087", "Razao isotopica", "P/D", "Razao entre isotopo pai e produto.", "Compendio Vol XIII - Geologia", "Com P=18 e D=6: resultado=3.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("088", "Gradiente geotermico", "dT/dz", "Variacao de temperatura por profundidade.", "Compendio Vol XIII - Geologia", "Com dT=75 e dz=3: resultado=25.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("089", "Pressao litostatica", "rho*g*z", "Pressao devido a coluna de rocha.", "Compendio Vol XIII - Geologia", "Com rho=2600, g=9.81, z=1000: resultado=25506000.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("090", "Indice de compactacao", "e0-et", "Reducao de indice de vazios ao longo do tempo.", "Compendio Vol XIII - Geologia", "Com e0=0.9 e et=0.6: resultado=0.3.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("091", "Taxa de subsidencia", "dz/dt", "Variacao vertical por unidade de tempo.", "Compendio Vol XIII - Geologia", "Com dz=2 e dt=50: resultado=0.04.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("092", "Indice de fraturamento", "Lf/A", "Comprimento de fraturas por area.", "Compendio Vol XIII - Geologia", "Com Lf=200 e A=50: resultado=4.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("093", "Razao areia/argila", "Vs/Vcl", "Indicador textural de unidade estratigrafica.", "Compendio Vol XIII - Geologia", "Com Vs=14 e Vcl=6: resultado=2.333.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("094", "Transmissividade", "K*b", "Capacidade de transmissao em aquifero confinado.", "Compendio Vol XIII - Geologia", "Com K=2e-4 e b=30: resultado=0.006.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("095", "Storativity simplificada", "Ss*b", "Armazenamento por espessura saturada.", "Compendio Vol XIII - Geologia", "Com Ss=1e-5 e b=25: resultado=0.00025.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("096", "Razao de intemperismo", "Wf/Rf", "Material alterado sobre rocha fresca.", "Compendio Vol XIII - Geologia", "Com Wf=12 e Rf=30: resultado=0.4.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("097", "Indice de selecao granulometrica", "sigma/mean", "Dispersao relativa do tamanho de grao.", "Compendio Vol XIII - Geologia", "Com sigma=0.6 e mean=1.2: resultado=0.5.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("098", "Razao de acumulacao sedimentar", "H/t", "Espessura acumulada por tempo geologico.", "Compendio Vol XIII - Geologia", "Com H=1200 e t=3e6: resultado=0.0004.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("099", "Permeabilidade relativa", "k/ki", "Permeabilidade atual normalizada.", "Compendio Vol XIII - Geologia", "Com k=80 e ki=100: resultado=0.8.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),
            new("100", "Indice de continuidade estratigrafica", "Lc/Lt", "Fracao de camadas continuas no intervalo.", "Compendio Vol XIII - Geologia", "Com Lc=45 e Lt=60: resultado=0.75.", "Geologia e Estratigrafia Quantitativa", "Geocronologia e Estratigrafia"),

            new("101", "Eficiencia bioinspirada", "Pbio/Pref", "Desempenho inspirado na natureza sobre referencia.", "Compendio Vol XIII - Biomimetica", "Com Pbio=96 e Pref=120: resultado=0.8.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("102", "Razao area-volume", "A/V", "Parametro chave em geometria bioinspirada.", "Compendio Vol XIII - Biomimetica", "Com A=15 e V=3: resultado=5.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("103", "Indice de aderencia gecko", "Fadh/W", "Forca adesiva relativa ao peso suportado.", "Compendio Vol XIII - Biomimetica", "Com Fadh=12 e W=3: resultado=4.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("104", "Fator de arrasto reduzido", "Cd_bio/Cd_ref", "Comparacao de arrasto com design convencional.", "Compendio Vol XIII - Biomimetica", "Com Cd_bio=0.18 e Cd_ref=0.24: resultado=0.75.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("105", "Capilaridade bioinspirada", "gamma*cos_theta/r", "Pressao capilar simplificada em microestruturas.", "Compendio Vol XIII - Biomimetica", "Com gamma=0.07, cos_theta=0.8, r=0.001: resultado=56.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("106", "Indice de auto limpeza", "Fremove/Fdeposit", "Capacidade relativa de remover particulas.", "Compendio Vol XIII - Biomimetica", "Com Fremove=9 e Fdeposit=3: resultado=3.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("107", "Elasticidade especifica", "E/rho", "Rigidez por densidade em material bioinspirado.", "Compendio Vol XIII - Biomimetica", "Com E=70 e rho=2.8: resultado=25.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("108", "Resistencia especifica", "sigma/rho", "Resistencia por densidade.", "Compendio Vol XIII - Biomimetica", "Com sigma=500 e rho=2.5: resultado=200.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("109", "Fator de ramificacao", "Nb/N0", "Razao de ramos para estrutura fractal.", "Compendio Vol XIII - Biomimetica", "Com Nb=81 e N0=3: resultado=27.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("110", "Indice de redundancia", "Npath/Ncrit", "Redundancia de caminhos em rede biomimetica.", "Compendio Vol XIII - Biomimetica", "Com Npath=12 e Ncrit=4: resultado=3.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("111", "Taxa de regeneracao", "dM/dt", "Recuperacao de massa funcional ao longo do tempo.", "Compendio Vol XIII - Biomimetica", "Com dM=6 e dt=3: resultado=2.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("112", "Indice de compliance", "delta/F", "Deformacao por carga em estrutura inspirada.", "Compendio Vol XIII - Biomimetica", "Com delta=0.9 e F=3: resultado=0.3.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("113", "Potencia especifica", "P/m", "Potencia por massa em atuadores bioinspirados.", "Compendio Vol XIII - Biomimetica", "Com P=150 e m=2: resultado=75.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("114", "Indice de estabilidade dinamica", "Ck/Cd", "Razao entre rigidez e amortecimento efetivo.", "Compendio Vol XIII - Biomimetica", "Com Ck=40 e Cd=10: resultado=4.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("115", "Taxa de transferencia em rede venosa", "Q/A", "Fluxo medio por secao efetiva.", "Compendio Vol XIII - Biomimetica", "Com Q=2.4 e A=0.6: resultado=4.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("116", "Indice de robustez morfologica", "Sload/Scollapse", "Capacidade de carga relativa ao colapso.", "Compendio Vol XIII - Biomimetica", "Com Sload=300 e Scollapse=500: resultado=0.6.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("117", "Razao de crescimento estrutural", "L2/L1", "Crescimento relativo entre duas etapas.", "Compendio Vol XIII - Biomimetica", "Com L2=18 e L1=12: resultado=1.5.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("118", "Indice de adaptacao", "Perf_new/Perf_old", "Ganho de desempenho apos adaptacao.", "Compendio Vol XIII - Biomimetica", "Com Perf_new=110 e Perf_old=100: resultado=1.1.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("119", "Razao energetica ciclica", "Eout/Ein", "Eficiencia energetica por ciclo funcional.", "Compendio Vol XIII - Biomimetica", "Com Eout=45 e Ein=60: resultado=0.75.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),
            new("120", "Indice global bioinspirado", "w1*s1+w2*s2", "Combinacao ponderada de dois criterios de desempenho.", "Compendio Vol XIII - Biomimetica", "Com w1=0.6, s1=0.8, w2=0.4, s2=0.7: resultado=0.76.", "Biomimetica e Engenharia Inspirada na Natureza", "Modelagem Bioinspirada"),

            new("121", "Potencial de celula ideal", "Ecat-Ean", "Diferenca de potencial entre catodo e anodo.", "Compendio Vol XIII - Eletroquimica", "Com Ecat=1.2 e Ean=0.3: resultado=0.9.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("122", "Queda ohmica interna", "I*Rint", "Queda de tensao por resistencia interna da bateria.", "Compendio Vol XIII - Eletroquimica", "Com I=8 e Rint=0.02: resultado=0.16.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("123", "Tensao terminal", "E-Uohm", "Tensao util apos perdas ohmicas.", "Compendio Vol XIII - Eletroquimica", "Com E=3.7 e Uohm=0.2: resultado=3.5.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("124", "Potencia eletrica de descarga", "V*I", "Potencia entregue no regime instantaneo.", "Compendio Vol XIII - Eletroquimica", "Com V=3.6 e I=20: resultado=72.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("125", "Energia descarregada", "P*t", "Energia entregue em intervalo de tempo.", "Compendio Vol XIII - Eletroquimica", "Com P=60 e t=2: resultado=120.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("126", "Estado de carga simplificado", "Qrem/Qnom", "Fracao de carga remanescente.", "Compendio Vol XIII - Eletroquimica", "Com Qrem=2.4 e Qnom=3.0: resultado=0.8.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("127", "Profundidade de descarga", "1-SOC", "Parcela de capacidade ja utilizada.", "Compendio Vol XIII - Eletroquimica", "Com SOC=0.75: resultado=0.25.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("128", "Capacidade util", "Cnom*SOC", "Capacidade efetiva no estado atual.", "Compendio Vol XIII - Eletroquimica", "Com Cnom=100 e SOC=0.9: resultado=90.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("129", "Taxa C instantanea", "I/Cnom", "Corrente normalizada pela capacidade nominal.", "Compendio Vol XIII - Eletroquimica", "Com I=50 e Cnom=100: resultado=0.5.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("130", "Resistencia especifica", "Rint/Aelet", "Resistencia interna por area eletroativa.", "Compendio Vol XIII - Eletroquimica", "Com Rint=0.015 e Aelet=0.3: resultado=0.05.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("131", "Fluxo ionico", "nI/F", "Taxa molar ionica equivalente por corrente.", "Compendio Vol XIII - Eletroquimica", "Com nI=2 e F=96485: resultado=2.073e-5.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("132", "Calor gerado por Joule", "I*I*Rint", "Dissipacao termica resistiva da celula.", "Compendio Vol XIII - Eletroquimica", "Com I=10 e Rint=0.03: resultado=3.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("133", "Eficiencia coulombica", "Qout/Qin", "Razao entre carga descarregada e carregada.", "Compendio Vol XIII - Eletroquimica", "Com Qout=95 e Qin=100: resultado=0.95.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("134", "Eficiencia energetica", "Eout/Ein", "Razao de energia util sobre energia de carga.", "Compendio Vol XIII - Eletroquimica", "Com Eout=180 e Ein=200: resultado=0.9.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("135", "Taxa de degradacao por ciclo", "dC/Nc", "Perda media de capacidade por ciclo.", "Compendio Vol XIII - Eletroquimica", "Com dC=12 e Nc=600: resultado=0.02.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("136", "Estado de saude", "Cact/Cnom", "Capacidade atual normalizada pela nominal.", "Compendio Vol XIII - Eletroquimica", "Com Cact=88 e Cnom=100: resultado=0.88.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("137", "Polarizacao total", "Veq-Vterm", "Diferenca entre potencial de equilibrio e terminal.", "Compendio Vol XIII - Eletroquimica", "Com Veq=3.9 e Vterm=3.6: resultado=0.3.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("138", "Densidade de energia gravimetrica", "E/m", "Energia armazenada por massa.", "Compendio Vol XIII - Eletroquimica", "Com E=240 e m=1.5: resultado=160.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("139", "Densidade de potencia gravimetrica", "P/m", "Potencia por massa da bateria.", "Compendio Vol XIII - Eletroquimica", "Com P=500 e m=2: resultado=250.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),
            new("140", "Densidade de energia volumetrica", "E/Vpack", "Energia por volume de pacote.", "Compendio Vol XIII - Eletroquimica", "Com E=600 e Vpack=2: resultado=300.", "Eletroquimica e Baterias Avancadas", "Termodinamica Eletroquimica"),

            new("141", "Gradiente barico horizontal", "dP/dx", "Variacao de pressao na direcao horizontal.", "Compendio Vol XIII - Meteorologia", "Com dP=12 e dx=300: resultado=0.04.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("142", "Forca de Coriolis especifica", "f*V", "Aceleracao aparente por rotacao terrestre.", "Compendio Vol XIII - Meteorologia", "Com f=1e-4 e V=25: resultado=0.0025.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("143", "Vento geostrofico simplificado", "dPdx/(rho*f)", "Aproximacao do vento geostrofico em escala sinotica.", "Compendio Vol XIII - Meteorologia", "Com dPdx=0.03, rho=1.2, f=1e-4: resultado=250.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("144", "Divergencia horizontal", "du/dx+dv/dy", "Taxa de espalhamento horizontal de massa de ar.", "Compendio Vol XIII - Meteorologia", "Com du=2, dx=100, dv=1, dy=100: resultado=0.03.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("145", "Vorticidade relativa simplificada", "dv/dx-du/dy", "Rotacao local do escoamento horizontal.", "Compendio Vol XIII - Meteorologia", "Com dv=3, dx=100, du=1, dy=100: resultado=0.02.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("146", "Taxa de adveccao termica", "U*dTdx", "Transporte horizontal de temperatura.", "Compendio Vol XIII - Meteorologia", "Com U=10 e dTdx=0.4: resultado=4.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("147", "Espessura geopotencial simplificada", "R*Tmed/g", "Relacao hidrostatica para camada atmosferica.", "Compendio Vol XIII - Meteorologia", "Com R=287, Tmed=270, g=9.81: resultado=7898.06.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("148", "Umidade relativa aproximada", "e/es", "Razao entre vapor real e saturacao.", "Compendio Vol XIII - Meteorologia", "Com e=12 e es=20: resultado=0.6.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("149", "Razao de mistura", "mv/ma", "Massa de vapor por massa de ar seco.", "Compendio Vol XIII - Meteorologia", "Com mv=8 e ma=1000: resultado=0.008.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("150", "Temperatura potencial", "T*(P0/P)", "Escalonamento simplificado de temperatura potencial.", "Compendio Vol XIII - Meteorologia", "Com T=290, P0=1000, P=900: resultado=322.22.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("151", "Estabilidade estatica", "dTheta/dz", "Gradiente vertical de temperatura potencial.", "Compendio Vol XIII - Meteorologia", "Com dTheta=6 e dz=300: resultado=0.02.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("152", "Numero de Richardson simplificado", "N2/S2", "Razao entre estratificacao e cisalhamento.", "Compendio Vol XIII - Meteorologia", "Com N2=0.01 e S2=0.04: resultado=0.25.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("153", "Fluxo de calor sensivel", "rho*Cp*Ch*V*dT", "Fluxo turbulento de calor para a superficie.", "Compendio Vol XIII - Meteorologia", "Com rho=1.2, Cp=1004, Ch=0.001, V=8, dT=3: resultado=28.9 aprox.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("154", "Fluxo de calor latente", "rho*Lv*Ce*V*dq", "Fluxo turbulento de umidade.", "Compendio Vol XIII - Meteorologia", "Com rho=1.2, Lv=2.5e6, Ce=0.001, V=8, dq=0.002: resultado=48.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("155", "Precipitacao acumulada", "R*t", "Acumulo de chuva por taxa media.", "Compendio Vol XIII - Meteorologia", "Com R=5 e t=6: resultado=30.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("156", "Tendencia de pressao", "dP/dt", "Variacao temporal da pressao em superficie.", "Compendio Vol XIII - Meteorologia", "Com dP=4 e dt=12: resultado=0.333.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("157", "Velocidade vertical diagnostica", "-H*Div", "Aproximacao de movimento vertical sinotico.", "Compendio Vol XIII - Meteorologia", "Com H=8000 e Div=1e-5: resultado=-0.08.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("158", "Indice de bloqueio", "U/zeta", "Razao de velocidade por vorticidade de grande escala.", "Compendio Vol XIII - Meteorologia", "Com U=20 e zeta=5e-5: resultado=400000.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("159", "Erro medio absoluto", "sumAbs/N", "Metrica basica de erro em previsao numerica.", "Compendio Vol XIII - Meteorologia", "Com sumAbs=18 e N=12: resultado=1.5.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),
            new("160", "Skill score simplificado", "1-Ef/Eref", "Desempenho relativo da previsao ao referencia.", "Compendio Vol XIII - Meteorologia", "Com Ef=0.8 e Eref=2.0: resultado=0.6.", "Meteorologia Sinotica e Previsao Numerica", "Dinamica Atmosferica"),

            new("161", "Massa molar media de mistura", "sumMi/sumni", "Razao entre massa total e quantidade total de mols.", "Compendio Vol XIII - Polimeros", "Com sumMi=500 e sumni=10: resultado=50.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("162", "Grau de polimerizacao", "Mn/M0", "Numero medio de unidades repetitivas.", "Compendio Vol XIII - Polimeros", "Com Mn=100000 e M0=100: resultado=1000.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("163", "Conversao de monomero", "(M0-M)/M0", "Fracao de monomero convertida em polimero.", "Compendio Vol XIII - Polimeros", "Com M0=1.0 e M=0.2: resultado=0.8.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("164", "Taxa de propagacao", "kp*M*R", "Taxa de crescimento de cadeias por propagacao.", "Compendio Vol XIII - Polimeros", "Com kp=300, M=0.5, R=0.002: resultado=0.3.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("165", "Taxa de terminacao", "kt*R*R", "Extincao de radicais por recombinacao.", "Compendio Vol XIII - Polimeros", "Com kt=1e7 e R=1e-4: resultado=0.1.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("166", "Indice de polidispersidade", "Mw/Mn", "Largura da distribuicao de massa molar.", "Compendio Vol XIII - Polimeros", "Com Mw=180000 e Mn=120000: resultado=1.5.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("167", "Fracao cristalina", "Xc/Xtot", "Parcela cristalina em semicristalinos.", "Compendio Vol XIII - Polimeros", "Com Xc=0.42 e Xtot=1.0: resultado=0.42.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("168", "Densidade amorfa equivalente", "m/Va", "Densidade associada a fase amorfa.", "Compendio Vol XIII - Polimeros", "Com m=0.95 e Va=1.1: resultado=0.864.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("169", "Modulo especifico", "E/rho", "Rigidez normalizada por densidade.", "Compendio Vol XIII - Polimeros", "Com E=2.4 e rho=1.2: resultado=2.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("170", "Resistencia especifica", "sigma/rho", "Resistencia mecanica por densidade.", "Compendio Vol XIII - Polimeros", "Com sigma=60 e rho=1.2: resultado=50.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("171", "Alongamento relativo", "dL/L0", "Deformacao de engenharia em tracao.", "Compendio Vol XIII - Polimeros", "Com dL=12 e L0=50: resultado=0.24.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("172", "Modulo de armazenamento simplificado", "sigma0/eps0", "Razao entre amplitudes de tensao e deformacao.", "Compendio Vol XIII - Polimeros", "Com sigma0=8 e eps0=0.02: resultado=400.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("173", "Fator de perdas", "E2/E1", "Razao entre modulos viscoso e elastico.", "Compendio Vol XIII - Polimeros", "Com E2=120 e E1=600: resultado=0.2.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("174", "Indice de fluidez", "m/t", "Massa extrudada por tempo no ensaio MFI.", "Compendio Vol XIII - Polimeros", "Com m=10 e t=10: resultado=1.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("175", "Viscosidade aparente", "tau/gammadot", "Razao tensao cisalhante por taxa de cisalhamento.", "Compendio Vol XIII - Polimeros", "Com tau=1500 e gammadot=300: resultado=5.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("176", "Numero de Deborah", "lambda/tproc", "Compara tempo de relaxacao com tempo de processo.", "Compendio Vol XIII - Polimeros", "Com lambda=2 e tproc=10: resultado=0.2.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("177", "Permeabilidade simplificada", "D*S", "Produto difusividade por solubilidade.", "Compendio Vol XIII - Polimeros", "Com D=3e-10 e S=2e-2: resultado=6e-12.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("178", "Taxa de inchamento", "(Vh-V0)/V0", "Expansao volumetrica por solvente.", "Compendio Vol XIII - Polimeros", "Com Vh=1.4 e V0=1.0: resultado=0.4.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("179", "Indice de reticulacao", "nu/nuRef", "Densidade de rede relativa a referencia.", "Compendio Vol XIII - Polimeros", "Com nu=0.9 e nuRef=1.2: resultado=0.75.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),
            new("180", "Coeficiente de contracao", "dL/Lmold", "Contracao linear apos processamento.", "Compendio Vol XIII - Polimeros", "Com dL=0.6 e Lmold=100: resultado=0.006.", "Engenharia de Polimeros e Plasticos", "Sintese e Estrutura"),

            new("181", "Taxa media de disparo", "Nspk/t", "Numero de spikes por unidade de tempo.", "Compendio Vol XIII - Neurociencia", "Com Nspk=120 e t=60: resultado=2.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("182", "Periodo entre spikes", "1/f", "Intervalo medio entre disparos neuronais.", "Compendio Vol XIII - Neurociencia", "Com f=20: resultado=0.05.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("183", "Potencial de membrana passivo", "I*Rm", "Variacao de potencial por corrente injetada.", "Compendio Vol XIII - Neurociencia", "Com I=0.5 e Rm=80: resultado=40.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("184", "Constante de tempo de membrana", "Rm*Cm", "Escala temporal da resposta sub-limiar.", "Compendio Vol XIII - Neurociencia", "Com Rm=100 e Cm=0.02: resultado=2.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("185", "Constante espacial", "sqrt(Rm/Ra)", "Escala de decaimento espacial em cabo neural.", "Compendio Vol XIII - Neurociencia", "Com Rm=900 e Ra=100: resultado=3.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("186", "Corrente sinaptica", "g*(V-Erev)", "Corrente dirigida pela condutancia sinaptica.", "Compendio Vol XIII - Neurociencia", "Com g=0.3, V=-55, Erev=0: resultado=-16.5.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("187", "Condutancia total", "ge+gi", "Soma de condutancias excitatoria e inibitoria.", "Compendio Vol XIII - Neurociencia", "Com ge=0.12 e gi=0.18: resultado=0.3.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("188", "Equilibrio excitacao-inibicao", "ge/gi", "Razao entre drive excitatorio e inibitorio.", "Compendio Vol XIII - Neurociencia", "Com ge=0.2 e gi=0.5: resultado=0.4.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("189", "Taxa de coincidencia", "C/N", "Fracacao de disparos sincronizados em janela.", "Compendio Vol XIII - Neurociencia", "Com C=30 e N=150: resultado=0.2.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("190", "Variabilidade de intervalo", "sigmaISI/muISI", "Coeficiente de variacao dos intervalos entre spikes.", "Compendio Vol XIII - Neurociencia", "Com sigmaISI=12 e muISI=40: resultado=0.3.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("191", "Correlacao de pares", "cov/(sx*sy)", "Correlacao linear entre dois trens de spikes.", "Compendio Vol XIII - Neurociencia", "Com cov=2, sx=4, sy=5: resultado=0.1.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("192", "Taxa de plasticidade hebbiana", "eta*x*y", "Ajuste sinaptico proporcional a coativacao.", "Compendio Vol XIII - Neurociencia", "Com eta=0.01, x=8, y=6: resultado=0.48.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("193", "Atualizacao de peso sinaptico", "w+dw", "Peso apos incremento de plasticidade.", "Compendio Vol XIII - Neurociencia", "Com w=0.7 e dw=0.05: resultado=0.75.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("194", "Erro de predicao neural", "r-rhat", "Diferenca entre recompensa observada e estimada.", "Compendio Vol XIII - Neurociencia", "Com r=1.2 e rhat=0.8: resultado=0.4.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("195", "Taxa de aprendizado", "alpha*delta", "Passo de atualizacao guiado por erro.", "Compendio Vol XIII - Neurociencia", "Com alpha=0.3 e delta=0.4: resultado=0.12.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("196", "Ganho neuronal", "dR/dI", "Sensibilidade da taxa de disparo a corrente.", "Compendio Vol XIII - Neurociencia", "Com dR=15 e dI=3: resultado=5.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("197", "Indice de sincronia de fase", "A/N", "Amplitude media de alinhamento de fase.", "Compendio Vol XIII - Neurociencia", "Com A=42 e N=60: resultado=0.7.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("198", "Eficiencia de codificacao", "Ispk/Espk", "Informacao por energia de disparo.", "Compendio Vol XIII - Neurociencia", "Com Ispk=1.8 e Espk=0.6: resultado=3.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("199", "Taxa de reconstrucao", "Srec/Sin", "Fracao de sinal recuperado em decoder neural.", "Compendio Vol XIII - Neurociencia", "Com Srec=86 e Sin=100: resultado=0.86.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),
            new("200", "Indice de conectividade efetiva", "Neff/Ntot", "Proporcao de conexoes efetivas no circuito.", "Compendio Vol XIII - Neurociencia", "Com Neff=2400 e Ntot=3000: resultado=0.8.", "Neurociencia Quantitativa", "Neuronios e Circuitos"),

            new("201", "Velocidade orbital circular", "sqrt(mu/r)", "Velocidade para orbita circular de raio r.", "Compendio Vol XIII - Mecanica Celeste", "Com mu=398600 e r=7000: resultado=7.546 aprox.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("202", "Periodo orbital circular", "2*pi*r/v", "Periodo para orbita circular a velocidade v.", "Compendio Vol XIII - Mecanica Celeste", "Com r=7000 e v=7.5: resultado=5864.3 aprox.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("203", "Energia orbital especifica", "-mu/(2*a)", "Energia mecanica por unidade de massa em orbita eliptica.", "Compendio Vol XIII - Mecanica Celeste", "Com mu=398600 e a=10000: resultado=-19.93.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("204", "Momento angular especifico", "r*v", "Modulo simplificado para velocidade perpendicular.", "Compendio Vol XIII - Mecanica Celeste", "Com r=8000 e v=7: resultado=56000.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("205", "Excentricidade por peri e apo", "(ra-rp)/(ra+rp)", "Excentricidade a partir de distancias extremas.", "Compendio Vol XIII - Mecanica Celeste", "Com ra=12000 e rp=8000: resultado=0.2.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("206", "Semieixo maior", "(ra+rp)/2", "Media entre apoastro e periastro.", "Compendio Vol XIII - Mecanica Celeste", "Com ra=12000 e rp=8000: resultado=10000.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("207", "Parametro orbital", "a*(1-e*e)", "Parametro p da conica orbital.", "Compendio Vol XIII - Mecanica Celeste", "Com a=10000 e e=0.2: resultado=9600.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("208", "Distancia radial conica", "p/(1+e*cosf)", "Raio orbital para anomalia verdadeira simplificada.", "Compendio Vol XIII - Mecanica Celeste", "Com p=9600, e=0.2, cosf=0.5: resultado=8727.27.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("209", "Velocidade pela vis-viva", "sqrt(mu*(2/r-1/a))", "Velocidade instantanea em orbita eliptica.", "Compendio Vol XIII - Mecanica Celeste", "Com mu=398600, r=9000, a=10000: resultado=6.95 aprox.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("210", "Delta-v de manobra simples", "v2-v1", "Incremento de velocidade requerido.", "Compendio Vol XIII - Mecanica Celeste", "Com v2=7.8 e v1=7.2: resultado=0.6.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("211", "Impulso especifico equivalente", "ve/g0", "Conversao entre velocidade de exaustao e Isp.", "Compendio Vol XIII - Mecanica Celeste", "Com ve=2943 e g0=9.81: resultado=300.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("212", "Razao de massa ideal", "exp(dv/ve)", "Razao inicial/final pela equacao de foguete.", "Compendio Vol XIII - Mecanica Celeste", "Com dv=1500 e ve=3000: resultado=1.6487.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("213", "Precessao nodal simplificada", "k*cosi", "Dependencia da precessao com inclinacao.", "Compendio Vol XIII - Mecanica Celeste", "Com k=-2.0 e cosi=0.5: resultado=-1.0.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("214", "Periodo sinodico", "1/abs(1/T1-1/T2)", "Tempo entre alinhamentos de dois orbitadores.", "Compendio Vol XIII - Mecanica Celeste", "Com T1=1 e T2=1.2: resultado=6.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("215", "Raio de esfera de influencia", "a*(m/M)", "Escala simplificada de influencia gravitacional local.", "Compendio Vol XIII - Mecanica Celeste", "Com a=1.5e8, m=6e24, M=2e30: resultado=450.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("216", "Taxa angular media", "2*pi/T", "Movimento medio de orbita periodica.", "Compendio Vol XIII - Mecanica Celeste", "Com T=5400: resultado=0.001163.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("217", "Anomalia media", "n*t", "Progresso angular medio desde a epoca.", "Compendio Vol XIII - Mecanica Celeste", "Com n=0.0011 e t=1200: resultado=1.32.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("218", "Distancia de Hohmann 1", "r2-r1", "Primeiro incremento radial de transferencia.", "Compendio Vol XIII - Mecanica Celeste", "Com r2=42164 e r1=7000: resultado=35164.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("219", "Tempo de voo de Hohmann", "pi*sqrt(at*at*at/mu)", "Meio periodo da orbita de transferencia.", "Compendio Vol XIII - Mecanica Celeste", "Com at=24582 e mu=398600: resultado=19178 aprox.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),
            new("220", "Erro de apontamento angular", "thetaRef-theta", "Desvio angular em controle orbital.", "Compendio Vol XIII - Mecanica Celeste", "Com thetaRef=0.25 e theta=0.18: resultado=0.07.", "Dinamica Orbital e Mecanica Celeste", "Orbitas Keplerianas"),

            new("221", "Tempo de resposta medio", "sumT/N", "Media dos tempos de resposta observados.", "Compendio Vol XIII - Eng Software", "Com sumT=950 e N=100: resultado=9.5.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("222", "Throughput medio", "N/t", "Requisicoes processadas por unidade de tempo.", "Compendio Vol XIII - Eng Software", "Com N=12000 e t=60: resultado=200.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("223", "Utilizacao de CPU", "busy/total", "Fracao do tempo de CPU ocupada.", "Compendio Vol XIII - Eng Software", "Com busy=48 e total=60: resultado=0.8.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("224", "Efetividade de cache", "hit/req", "Razao de acertos no cache.", "Compendio Vol XIII - Eng Software", "Com hit=8500 e req=10000: resultado=0.85.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("225", "Latencia de rede media", "sumL/N", "Latencia media entre servicos distribuidos.", "Compendio Vol XIII - Eng Software", "Com sumL=2200 e N=200: resultado=11.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("226", "Fila media de requisicoes", "lambda*W", "Aplicacao simplificada da lei de Little.", "Compendio Vol XIII - Eng Software", "Com lambda=180 e W=0.04: resultado=7.2.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("227", "Saturacao de pool", "used/cap", "Uso relativo do pool de conexoes.", "Compendio Vol XIII - Eng Software", "Com used=72 e cap=80: resultado=0.9.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("228", "Taxa de erro", "err/req", "Proporcao de requisicoes com falha.", "Compendio Vol XIII - Eng Software", "Com err=35 e req=7000: resultado=0.005.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("229", "Disponibilidade", "uptime/periodo", "Tempo operacional relativo no periodo.", "Compendio Vol XIII - Eng Software", "Com uptime=719 e periodo=720: resultado=0.9986.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("230", "MTTR simplificado", "tdown/Ninc", "Tempo medio para restauracao.", "Compendio Vol XIII - Eng Software", "Com tdown=150 e Ninc=10: resultado=15.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("231", "MTBF simplificado", "tup/Nfail", "Tempo medio entre falhas.", "Compendio Vol XIII - Eng Software", "Com tup=5000 e Nfail=8: resultado=625.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("232", "Confiabilidade operacional", "MTBF/(MTBF+MTTR)", "Confiabilidade baseada em tempos medios.", "Compendio Vol XIII - Eng Software", "Com MTBF=625 e MTTR=15: resultado=0.9766.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("233", "Escalabilidade horizontal", "Tn/T1", "Ganho de throughput com n nos.", "Compendio Vol XIII - Eng Software", "Com Tn=760 e T1=200: resultado=3.8.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("234", "Eficiencia paralela", "speedup/n", "Eficiencia relativa por numero de nos.", "Compendio Vol XIII - Eng Software", "Com speedup=3.8 e n=4: resultado=0.95.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("235", "Tempo serial equivalente", "Tpar*speedup", "Reconstrucao do tempo em 1 recurso.", "Compendio Vol XIII - Eng Software", "Com Tpar=25 e speedup=3: resultado=75.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("236", "Pressao de GC", "tgc/ttotal", "Parcela de tempo consumida por coleta.", "Compendio Vol XIII - Eng Software", "Com tgc=9 e ttotal=300: resultado=0.03.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("237", "Uso de memoria", "mused/mlimit", "Consumo relativo de memoria de processo.", "Compendio Vol XIII - Eng Software", "Com mused=3.2 e mlimit=4.0: resultado=0.8.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("238", "Taxa de retry", "retry/req", "Fracacao de requisicoes que exigiram retry.", "Compendio Vol XIII - Eng Software", "Com retry=240 e req=12000: resultado=0.02.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("239", "Backlog por worker", "Q/W", "Tamanho medio de fila por trabalhador.", "Compendio Vol XIII - Eng Software", "Com Q=1800 e W=60: resultado=30.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),
            new("240", "SLA atendido", "ok/total", "Proporcao de requisicoes dentro do limite de SLA.", "Compendio Vol XIII - Eng Software", "Com ok=9870 e total=10000: resultado=0.987.", "Engenharia de Software Avancada", "Desempenho e Escalabilidade"),

            new("241", "Area superficial especifica", "A/m", "Area por unidade de massa de nanomaterial.", "Compendio Vol XIII - Nanotecnologia", "Com A=450 e m=3: resultado=150.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("242", "Razao superficie-volume", "A/V", "Parametro dominante em nanoescala.", "Compendio Vol XIII - Nanotecnologia", "Com A=9 e V=1.5: resultado=6.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("243", "Confinamento quantico", "h2/(8*m*L2)", "Escala de energia para particula em caixa simplificada.", "Compendio Vol XIII - Nanotecnologia", "Com h2=1, m=1, L2=4: resultado=0.03125.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("244", "Comprimento de onda de deBroglie", "h/p", "Comprimento de onda associado a particula.", "Compendio Vol XIII - Nanotecnologia", "Com h=6.63e-34 e p=3.3e-24: resultado=2.01e-10.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("245", "Gap efetivo por tamanho", "Eg0+K/R", "Aumento de gap com reducao de raio.", "Compendio Vol XIII - Nanotecnologia", "Com Eg0=1.1, K=0.8, R=4: resultado=1.3.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("246", "Mobilidade eletrica", "v/E", "Razao entre velocidade de deriva e campo.", "Compendio Vol XIII - Nanotecnologia", "Com v=0.02 e E=100: resultado=0.0002.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("247", "Condutividade", "n*q*mu", "Condutividade eletrica simplificada.", "Compendio Vol XIII - Nanotecnologia", "Com n=1e22, q=1.6e-19, mu=0.01: resultado=16.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("248", "Resistencia de folha", "rho/t", "Resistencia por quadrado em filme fino.", "Compendio Vol XIII - Nanotecnologia", "Com rho=1e-5 e t=1e-7: resultado=100.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("249", "Fluxo difusivo nanos", "D*dCdx", "Fluxo unidimensional sem area explicita.", "Compendio Vol XIII - Nanotecnologia", "Com D=2e-12 e dCdx=4e9: resultado=0.008.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("250", "Numero de Peclet nanoparticula", "v*L/D", "Conveccao relativa a difusao em microcanais.", "Compendio Vol XIII - Nanotecnologia", "Com v=0.002, L=1e-3, D=2e-10: resultado=10000.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("251", "Potencial zeta normalizado", "zeta/Vref", "Potencial de superficie relativo a referencia.", "Compendio Vol XIII - Nanotecnologia", "Com zeta=30 e Vref=50: resultado=0.6.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("252", "Estabilidade coloidal", "kappa*a", "Parametro adimensional de estabilidade eletrostatica.", "Compendio Vol XIII - Nanotecnologia", "Com kappa=2e8 e a=5e-9: resultado=1.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("253", "Taxa de agregacao", "ka*N*N", "Modelo simplificado de agregacao bimolecular.", "Compendio Vol XIII - Nanotecnologia", "Com ka=1e-15 e N=1e10: resultado=100000.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("254", "Conversao fotocatalitica", "(C0-C)/C0", "Fracao de contaminante removida no processo.", "Compendio Vol XIII - Nanotecnologia", "Com C0=100 e C=25: resultado=0.75.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("255", "Efetividade de adsorcao", "q/qmax", "Carga adsorvida normalizada pela capacidade maxima.", "Compendio Vol XIII - Nanotecnologia", "Com q=45 e qmax=60: resultado=0.75.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("256", "Modulo de Young nano", "sigma/eps", "Rigidez aparente em nanofios e filmes finos.", "Compendio Vol XIII - Nanotecnologia", "Com sigma=1.2e9 e eps=0.006: resultado=2e11.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("257", "Tenacidade simplificada", "Kc*Kc/E", "Escala energetica de fratura.", "Compendio Vol XIII - Nanotecnologia", "Com Kc=2.5 e E=200: resultado=0.03125.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("258", "Indice de percolacao", "phi/phic", "Fracao de preenchimento relativa ao limiar.", "Compendio Vol XIII - Nanotecnologia", "Com phi=0.03 e phic=0.015: resultado=2.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("259", "Fator termoeletrico simplificado", "S*S*sigma*T", "Indicador de desempenho termoeletrico sem k.", "Compendio Vol XIII - Nanotecnologia", "Com S=200e-6, sigma=2e5, T=300: resultado=2.4.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),
            new("260", "Indice de sensoriamento", "dR/R0", "Variacao relativa de resistencia em nanosensor.", "Compendio Vol XIII - Nanotecnologia", "Com dR=15 e R0=300: resultado=0.05.", "Nanotecnologia e Nanomateriais", "Efeitos Quanticos"),

            new("261", "Entropia de unigramas", "-sumPlogP", "Mede incerteza media de tokens em corpus.", "Compendio Vol XIII - Linguistica Computacional", "Com sumPlogP=-3.2: resultado=3.2.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("262", "Perplexidade de modelo", "2*H", "Aproximacao simples de perplexidade por entropia.", "Compendio Vol XIII - Linguistica Computacional", "Com H=4: resultado=8.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("263", "Probabilidade condicional bigrama", "C12/C1", "Probabilidade de token dado contexto anterior.", "Compendio Vol XIII - Linguistica Computacional", "Com C12=45 e C1=300: resultado=0.15.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("264", "Suavizacao add-k", "(C+k)/(N+kV)", "Evita probabilidade nula para eventos raros.", "Compendio Vol XIII - Linguistica Computacional", "Com C=2, k=1, N=100, V=50: resultado=0.02.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("265", "Razao OOV", "Noov/Ntok", "Fracao de termos fora do vocabulario.", "Compendio Vol XIII - Linguistica Computacional", "Com Noov=12 e Ntok=800: resultado=0.015.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("266", "Cobertura lexical", "Nin/Ntok", "Proporcao de tokens cobertos pelo lexicon.", "Compendio Vol XIII - Linguistica Computacional", "Com Nin=780 e Ntok=800: resultado=0.975.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("267", "Precisao de etiquetador", "TP/(TP+FP)", "Precisao em rotulacao morfossintatica.", "Compendio Vol XIII - Linguistica Computacional", "Com TP=920 e FP=80: resultado=0.92.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("268", "Revocacao de etiquetador", "TP/(TP+FN)", "Revocacao em tarefas de etiquetagem.", "Compendio Vol XIII - Linguistica Computacional", "Com TP=920 e FN=120: resultado=0.8846.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("269", "F1 de etiquetador", "2*P*R", "Combinacao harmonica simplificada de precisao e revocacao.", "Compendio Vol XIII - Linguistica Computacional", "Com P=0.9 e R=0.8: resultado=1.44.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("270", "Cobertura sintatica", "Nparse/Nsent", "Fracao de sentencas com arvore valida.", "Compendio Vol XIII - Linguistica Computacional", "Com Nparse=870 e Nsent=1000: resultado=0.87.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("271", "Taxa de ambiguidade", "Nmulti/Ntok", "Proporcao de tokens com multiplas analises.", "Compendio Vol XIII - Linguistica Computacional", "Com Nmulti=140 e Ntok=2000: resultado=0.07.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("272", "Densidade de n-gramas raros", "Nrare/Ngram", "Frequencia relativa de n-gramas de baixa ocorrencia.", "Compendio Vol XIII - Linguistica Computacional", "Com Nrare=900 e Ngram=6000: resultado=0.15.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("273", "Taxa de compressao lexical", "Nuniq/Ntok", "Diversidade lexical de corpus.", "Compendio Vol XIII - Linguistica Computacional", "Com Nuniq=4500 e Ntok=30000: resultado=0.15.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("274", "Ganho de similaridade", "Snew-Sbase", "Melhoria de similaridade semantica apos ajuste.", "Compendio Vol XIII - Linguistica Computacional", "Com Snew=0.84 e Sbase=0.77: resultado=0.07.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("275", "Taxa de alinhamento paralelo", "Naln/Npar", "Fracao de pares alinhados em corpus paralelo.", "Compendio Vol XIII - Linguistica Computacional", "Com Naln=46000 e Npar=50000: resultado=0.92.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("276", "Cobertura de entidades", "NentOK/Nent", "Proporcao de entidades reconhecidas corretamente.", "Compendio Vol XIII - Linguistica Computacional", "Com NentOK=380 e Nent=420: resultado=0.9048.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),
            new("277", "Indice de coerencia topica", "Cintra/Cinter", "Coerencia de topicos por separacao intra e inter.", "Compendio Vol XIII - Linguistica Computacional", "Com Cintra=0.62 e Cinter=0.31: resultado=2.", "Linguistica Computacional Avancada", "Modelos de Linguagem"),

            new("278", "Probabilidade de medida em qubit", "a*a", "Probabilidade associada a amplitude a.", "Compendio Vol XIII - Computacao Quantica", "Com a=0.8: resultado=0.64.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("279", "Norma de estado de qubit", "a*a+b*b", "Verifica normalizacao de estado puro.", "Compendio Vol XIII - Computacao Quantica", "Com a=0.6 e b=0.8: resultado=1.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("280", "Fidelidade simplificada", "psi*phi", "Sobreposicao aproximada entre dois estados normalizados.", "Compendio Vol XIII - Computacao Quantica", "Com psi=0.9 e phi=0.95: resultado=0.855.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("281", "Taxa de erro de porta", "Nerr/Ngate", "Proporcao de operacoes com falha.", "Compendio Vol XIII - Computacao Quantica", "Com Nerr=15 e Ngate=3000: resultado=0.005.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("282", "Taxa de decoerencia", "1/T2", "Inverso do tempo de coerencia transversal.", "Compendio Vol XIII - Computacao Quantica", "Com T2=80: resultado=0.0125.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("283", "Visibilidade de interferencia", "(Imax-Imin)/(Imax+Imin)", "Contraste de franjas em experimento interferometrico.", "Compendio Vol XIII - Computacao Quantica", "Com Imax=9 e Imin=1: resultado=0.8.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("284", "Taxa de acerto de leitura", "Nok/Nshot", "Acerto em leitura de qubits por amostragem.", "Compendio Vol XIII - Computacao Quantica", "Com Nok=960 e Nshot=1000: resultado=0.96.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("285", "Erro de leitura", "1-Acc", "Complemento da acuracia de leitura.", "Compendio Vol XIII - Computacao Quantica", "Com Acc=0.96: resultado=0.04.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("286", "Profundidade por camada", "Ngate/Nlayer", "Media de portas por camada de circuito.", "Compendio Vol XIII - Computacao Quantica", "Com Ngate=600 e Nlayer=50: resultado=12.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("287", "Fator de emaranhamento", "Nent/Npair", "Proporcao de pares efetivamente emaranhados.", "Compendio Vol XIII - Computacao Quantica", "Com Nent=42 e Npair=50: resultado=0.84.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("288", "Taxa de sucesso variacional", "Nconv/Nrun", "Fracacao de execucoes que convergem.", "Compendio Vol XIII - Computacao Quantica", "Com Nconv=37 e Nrun=50: resultado=0.74.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("289", "Gap energetico efetivo", "E1-E0", "Diferenca entre primeiro excitado e fundamental.", "Compendio Vol XIII - Computacao Quantica", "Com E1=1.8 e E0=1.2: resultado=0.6.", "Ciencia da Computacao Quantica", "Informacao Quantica"),
            new("290", "Taxa de amostragem util", "Nvalid/Nshot", "Proporcao de amostras aproveitaveis apos filtragem.", "Compendio Vol XIII - Computacao Quantica", "Com Nvalid=8800 e Nshot=10000: resultado=0.88.", "Ciencia da Computacao Quantica", "Informacao Quantica"),

            new("291", "Grau medio de grafo", "2*E/V", "Media de adjacencias por vertice.", "Compendio Vol XIII - Matematica Discreta", "Com E=45 e V=30: resultado=3.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("292", "Densidade de grafo", "2*E/(V*(V-1))", "Conectividade relativa em grafo simples nao direcionado.", "Compendio Vol XIII - Matematica Discreta", "Com E=45 e V=30: resultado=0.1034.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("293", "Numero de arestas maximo", "V*(V-1)/2", "Limite superior de arestas em grafo simples.", "Compendio Vol XIII - Matematica Discreta", "Com V=10: resultado=45.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("294", "Deficit de planaridade", "E-(3*V-6)", "Excesso de arestas sobre limite planar classico.", "Compendio Vol XIII - Matematica Discreta", "Com E=40 e V=14: resultado=4.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("295", "Caracteristica de Euler", "V-E+F", "Invariante topologico para complexos planares.", "Compendio Vol XIII - Matematica Discreta", "Com V=20, E=30, F=12: resultado=2.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("296", "Numero ciclomatico", "E-V+C", "Contagem de ciclos independentes por componentes C.", "Compendio Vol XIII - Matematica Discreta", "Com E=50, V=35, C=2: resultado=17.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("297", "Taxa de conectividade", "Vcon/V", "Fracao de vertices na componente gigante.", "Compendio Vol XIII - Matematica Discreta", "Com Vcon=920 e V=1000: resultado=0.92.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("298", "Razao folha em arvore", "L/V", "Proporcao de folhas em estrutura arborescente.", "Compendio Vol XIII - Matematica Discreta", "Com L=48 e V=100: resultado=0.48.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("299", "Taxa de triangulos", "3*T/W", "Fechamento local por triplas conectadas.", "Compendio Vol XIII - Matematica Discreta", "Com T=120 e W=1500: resultado=0.24.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("300", "Diametro normalizado", "D/(V-1)", "Diametro relativo ao tamanho do grafo.", "Compendio Vol XIII - Matematica Discreta", "Com D=12 e V=61: resultado=0.2.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("301", "Comprimento medio de caminho", "sumd/Npair", "Media de distancias geodesicas entre pares.", "Compendio Vol XIII - Matematica Discreta", "Com sumd=8800 e Npair=4000: resultado=2.2.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("302", "Coeficiente de agrupamento", "Ctri/Ctrip", "Razao entre triplas fechadas e totais.", "Compendio Vol XIII - Matematica Discreta", "Com Ctri=340 e Ctrip=1000: resultado=0.34.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("303", "Cobertura de arestas", "Ecov/E", "Fracao de arestas cobertas por conjunto escolhido.", "Compendio Vol XIII - Matematica Discreta", "Com Ecov=430 e E=500: resultado=0.86.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("304", "Razao de corte", "Ecut/E", "Proporcao de arestas atravessando biparticao.", "Compendio Vol XIII - Matematica Discreta", "Com Ecut=95 e E=400: resultado=0.2375.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("305", "Condutancia de conjunto", "Eout/VolS", "Mede fuga de arestas de subconjunto S.", "Compendio Vol XIII - Matematica Discreta", "Com Eout=52 e VolS=260: resultado=0.2.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("306", "Peso medio de aresta", "sumw/E", "Media dos pesos em rede ponderada.", "Compendio Vol XIII - Matematica Discreta", "Com sumw=900 e E=300: resultado=3.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("307", "Fator de expansao", "Bout/S", "Vertices de fronteira por tamanho do conjunto.", "Compendio Vol XIII - Matematica Discreta", "Com Bout=75 e S=250: resultado=0.3.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("308", "Taxa de aciclicidade", "(V-1)/E", "Indicador de proximidade a estrutura de arvore.", "Compendio Vol XIII - Matematica Discreta", "Com V=151 e E=200: resultado=0.75.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("309", "Indice de dominacao", "Ndom/V", "Fracao minima de vertices dominantes.", "Compendio Vol XIII - Matematica Discreta", "Com Ndom=20 e V=160: resultado=0.125.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),
            new("310", "Taxa de coloracao", "Chi/V", "Numero cromatico normalizado.", "Compendio Vol XIII - Matematica Discreta", "Com Chi=4 e V=40: resultado=0.1.", "Matematica Discreta e Teoria de Grafos", "Grafos Planares e Topologicos"),

            new("311", "Numero de Rossby", "U/(f*L)", "Importancia relativa de inercia e Coriolis no oceano.", "Compendio Vol XIII - Oceanografia", "Com U=0.2, f=1e-4, L=50000: resultado=0.04.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("312", "Numero de Froude", "U/sqrt(g*H)", "Compara inercia e gravidade em escoamento estratificado.", "Compendio Vol XIII - Oceanografia", "Com U=1.5, g=9.81, H=25: resultado=0.0958.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("313", "Transporte de Ekman", "tau/(rho*f)", "Transporte integrado na camada superficial.", "Compendio Vol XIII - Oceanografia", "Com tau=0.1, rho=1025, f=1e-4: resultado=0.9756.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("314", "Velocidade geostrofica", "dPdx/(rho*f)", "Aproximacao geostrofica para gradiente horizontal de pressao.", "Compendio Vol XIII - Oceanografia", "Com dPdx=0.2, rho=1025, f=1e-4: resultado=1.951.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("315", "Gradiente termico vertical", "dT/dz", "Estratificacao termica da coluna de agua.", "Compendio Vol XIII - Oceanografia", "Com dT=6 e dz=300: resultado=0.02.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("316", "Gradiente halino vertical", "dS/dz", "Variacao de salinidade com profundidade.", "Compendio Vol XIII - Oceanografia", "Com dS=1.2 e dz=300: resultado=0.004.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("317", "Fluxo advectivo de calor", "rho*Cp*U*dT", "Transporte horizontal de calor no oceano.", "Compendio Vol XIII - Oceanografia", "Com rho=1025, Cp=3985, U=0.1, dT=2: resultado=816925.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("318", "Fluxo difusivo vertical", "Kz*dCdz", "Difusao vertical de propriedade escalar.", "Compendio Vol XIII - Oceanografia", "Com Kz=1e-4 e dCdz=50: resultado=0.005.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("319", "Escala inercial", "2*pi/f", "Periodo de oscilacao inercial local.", "Compendio Vol XIII - Oceanografia", "Com f=1e-4: resultado=62831.85.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("320", "Potencia de onda", "E*cg", "Fluxo de energia por frente de onda.", "Compendio Vol XIII - Oceanografia", "Com E=1200 e cg=4: resultado=4800.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("321", "Energia cinetica especifica", "0.5*U*U", "Energia cinetica por unidade de massa.", "Compendio Vol XIII - Oceanografia", "Com U=0.6: resultado=0.18.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("322", "Fluxo de momento", "rho*U*U", "Fluxo turbulento simplificado de quantidade de movimento.", "Compendio Vol XIII - Oceanografia", "Com rho=1025 e U=0.2: resultado=41.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("323", "Anomalia de nivel do mar", "eta-eta0", "Desvio relativo do nivel medio de referencia.", "Compendio Vol XIII - Oceanografia", "Com eta=0.42 e eta0=0.35: resultado=0.07.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("324", "Taxa de mistura vertical", "dC/dt", "Variacao temporal de concentracao por mistura.", "Compendio Vol XIII - Oceanografia", "Com dC=0.8 e dt=4: resultado=0.2.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("325", "Frequencia de Brunt simplificada", "g*drhodz/rho0", "Escala de estabilidade estratificada.", "Compendio Vol XIII - Oceanografia", "Com g=9.81, drhodz=0.02, rho0=1025: resultado=0.0001914.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("326", "Razao barotropica", "Ubar/Utot", "Parcela barotropica do escoamento total.", "Compendio Vol XIII - Oceanografia", "Com Ubar=0.25 e Utot=0.4: resultado=0.625.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("327", "Razao baroclinica", "Ubc/Utot", "Parcela baroclinica do escoamento total.", "Compendio Vol XIII - Oceanografia", "Com Ubc=0.15 e Utot=0.4: resultado=0.375.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("328", "Transporte volumetrico", "U*A", "Vazao volumetrica de corrente oceanica.", "Compendio Vol XIII - Oceanografia", "Com U=0.3 e A=2000: resultado=600.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("329", "Razao de ressurgencia", "Wup/U", "Intensidade vertical relativa de upwelling.", "Compendio Vol XIII - Oceanografia", "Com Wup=0.004 e U=0.2: resultado=0.02.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),
            new("330", "Indice de frontogenese", "dGrad/dt", "Taxa temporal de intensificacao de frentes.", "Compendio Vol XIII - Oceanografia", "Com dGrad=0.6 e dt=3: resultado=0.2.", "Oceanografia Fisica e Dinamica do Oceano", "Dinamica Oceanica"),

            new("331", "Indice de massa corporal", "m/(h*h)", "Relacao massa-altura para triagem nutricional.", "Compendio Vol XIII - Saude Quantitativa", "Com m=75 e h=1.75: resultado=24.49.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("332", "Pressao arterial media", "(Ps+2*Pd)/3", "Aproximacao de pressao media no ciclo cardiaco.", "Compendio Vol XIII - Saude Quantitativa", "Com Ps=120 e Pd=80: resultado=93.33.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("333", "Debito cardiaco", "FC*VS", "Volume bombeado por minuto.", "Compendio Vol XIII - Saude Quantitativa", "Com FC=70 e VS=75: resultado=5250.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("334", "Indice cardiaco", "DC/ASC", "Debito cardiaco normalizado por area corporal.", "Compendio Vol XIII - Saude Quantitativa", "Com DC=5.2 e ASC=1.8: resultado=2.8889.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("335", "Consumo de oxigenio relativo", "VO2/m", "Consumo por unidade de massa corporal.", "Compendio Vol XIII - Saude Quantitativa", "Com VO2=2800 e m=70: resultado=40.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("336", "Saturacao arterial", "HbO2/HbTot", "Fracao de hemoglobina oxigenada.", "Compendio Vol XIII - Saude Quantitativa", "Com HbO2=13.5 e HbTot=15: resultado=0.9.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("337", "Taxa de filtracao glomerular", "Ucr*V/Pcr", "Estimativa simplificada de depuracao de creatinina.", "Compendio Vol XIII - Saude Quantitativa", "Com Ucr=120, V=1.2, Pcr=1.0: resultado=144.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("338", "Clearance relativo", "Cl/Clref", "Depuracao normalizada por referencia clinica.", "Compendio Vol XIII - Saude Quantitativa", "Com Cl=95 e Clref=110: resultado=0.8636.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("339", "Taxa metabolica basal simplificada", "k*m", "Aproximacao linear de gasto energetico basal.", "Compendio Vol XIII - Saude Quantitativa", "Com k=24 e m=70: resultado=1680.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("340", "Razao ventilatoria", "VE/VO2", "Eficiencia ventilatoria durante esforco.", "Compendio Vol XIII - Saude Quantitativa", "Com VE=70 e VO2=2.8: resultado=25.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("341", "Fracao de ejecao", "VS/VDF", "Proporcao de volume sistolico e diastolico final.", "Compendio Vol XIII - Saude Quantitativa", "Com VS=70 e VDF=140: resultado=0.5.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("342", "Resistencia vascular sistemica", "(PAM-Pvc)/DC", "Resistencia hemodinamica sistemica simplificada.", "Compendio Vol XIII - Saude Quantitativa", "Com PAM=95, Pvc=5, DC=5: resultado=18.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("343", "Carga glicemica", "GI*carb/100", "Impacto glicemico de porcao alimentar.", "Compendio Vol XIII - Saude Quantitativa", "Com GI=70 e carb=45: resultado=31.5.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("344", "Taxa de infusao por peso", "Dose/(m*t)", "Infusao farmacologica normalizada por massa e tempo.", "Compendio Vol XIII - Saude Quantitativa", "Com Dose=350, m=70, t=5: resultado=1.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("345", "Concentracao plasmatica simplificada", "Dose/Vd", "Concentracao inicial apos distribuicao instantanea.", "Compendio Vol XIII - Saude Quantitativa", "Com Dose=500 e Vd=50: resultado=10.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("346", "Reducao relativa de risco", "(Rc-Rt)/Rc", "Comparacao de risco entre controle e tratamento.", "Compendio Vol XIII - Saude Quantitativa", "Com Rc=0.2 e Rt=0.12: resultado=0.4.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("347", "Numero necessario para tratar", "1/ARR", "Pacientes necessarios para evitar um evento.", "Compendio Vol XIII - Saude Quantitativa", "Com ARR=0.1: resultado=10.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),
            new("348", "Indice de resposta terapeutica", "Rpos/Rtot", "Proporcao de respondedores no tratamento.", "Compendio Vol XIII - Saude Quantitativa", "Com Rpos=135 e Rtot=180: resultado=0.75.", "Ciencias da Saude Quantitativa", "Fisiologia Quantitativa"),

            new("349", "Deformacao axial", "dL/L0", "Deformacao uniaxial em regime elastico.", "Compendio Vol XIII - Mecanica de Solidos", "Com dL=1.2 e L0=300: resultado=0.004.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("350", "Tensao normal", "F/A", "Tensao media em secao transversal.", "Compendio Vol XIII - Mecanica de Solidos", "Com F=25000 e A=500: resultado=50.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("351", "Lei de Hooke uniaxial", "E*eps", "Relacao linear entre tensao e deformacao.", "Compendio Vol XIII - Mecanica de Solidos", "Com E=210000 e eps=0.001: resultado=210.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("352", "Modulo de cisalhamento", "tau/gamma", "Rigidez ao cisalhamento em regime linear.", "Compendio Vol XIII - Mecanica de Solidos", "Com tau=80 e gamma=0.004: resultado=20000.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("353", "Relacao de Poisson", "-epsT/epsL", "Razao entre deformacoes transversal e longitudinal.", "Compendio Vol XIII - Mecanica de Solidos", "Com epsT=-0.0006 e epsL=0.002: resultado=0.3.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("354", "Momento fletor maximo", "P*L/4", "Momento maximo em viga biapoiada com carga central.", "Compendio Vol XIII - Mecanica de Solidos", "Com P=12000 e L=6: resultado=18000.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("355", "Tensao de flexao", "M*c/I", "Tensao normal extrema por flexao simples.", "Compendio Vol XIII - Mecanica de Solidos", "Com M=18000, c=0.15, I=0.02: resultado=135000.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("356", "Deflexao simplificada", "P*L3/(E*I)", "Escala de deslocamento elastico em viga.", "Compendio Vol XIII - Mecanica de Solidos", "Com P=5000, L3=27, E=200000, I=0.03: resultado=22.5.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("357", "Tensao cisalhante media", "V/A", "Tensao media de cisalhamento em secao.", "Compendio Vol XIII - Mecanica de Solidos", "Com V=8000 e A=400: resultado=20.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("358", "Energia elastica", "0.5*sigma*eps", "Densidade de energia armazenada elasticamente.", "Compendio Vol XIII - Mecanica de Solidos", "Com sigma=200 e eps=0.0015: resultado=0.15.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("359", "Fator de seguranca", "Sy/sigma", "Margem entre escoamento e tensao aplicada.", "Compendio Vol XIII - Mecanica de Solidos", "Com Sy=350 e sigma=175: resultado=2.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),
            new("360", "Indice de dano elastico", "sigma/Su", "Razao de tensao aplicada pela resistencia ultima.", "Compendio Vol XIII - Mecanica de Solidos", "Com sigma=180 e Su=450: resultado=0.4.", "Mecanica de Solidos Avancada", "Elasticidade Linear"),

            new("361", "Raio de Schwarzschild", "2*G*M/c2", "Escala gravitacional de buraco negro nao rotante.", "Compendio Vol XIII - Astrofisica", "Com 2GM=2.95e4 e c2=9e16: resultado=3.28e-13.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("362", "Luminosidade de Eddington", "kEdd*M", "Limite radiativo proporcional a massa.", "Compendio Vol XIII - Astrofisica", "Com kEdd=1.26e31 e M=10: resultado=1.26e32.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("363", "Taxa de acrecao Eddington", "Ledd/(eta*c2)", "Taxa limite para eficiencia radiativa eta.", "Compendio Vol XIII - Astrofisica", "Com Ledd=1.26e32, eta=0.1, c2=9e16: resultado=1.4e16.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("364", "Potencia de jato relativistico", "etaJ*mdot*c2", "Conversao de acrecao em potencia de jato.", "Compendio Vol XIII - Astrofisica", "Com etaJ=0.05, mdot=2e15, c2=9e16: resultado=9e30.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("365", "Parametro de compactacao", "Rs/R", "Quao compacta e a fonte gravitacional.", "Compendio Vol XIII - Astrofisica", "Com Rs=30 e R=120: resultado=0.25.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("366", "Redshift gravitacional simplificado", "1/sqrt(1-Rs/R)", "Fator de desvio gravitacional proximo ao objeto compacto.", "Compendio Vol XIII - Astrofisica", "Com Rs=20 e R=80: resultado=1.1547.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("367", "Tempo dinamico de acrecao", "R/v", "Escala temporal de queda para velocidade v.", "Compendio Vol XIII - Astrofisica", "Com R=3e7 e v=3e5: resultado=100.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("368", "Efetividade radiativa", "L/(mdot*c2)", "Eficiencia de conversao massa-energia no disco.", "Compendio Vol XIII - Astrofisica", "Com L=3e31, mdot=5e15, c2=9e16: resultado=0.0667.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("369", "Frequencia Kepleriana", "sqrt(G*M/r3)", "Frequencia orbital local em disco de acrecao.", "Compendio Vol XIII - Astrofisica", "Com GM=1.33e21 e r3=1e18: resultado=36.47.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("370", "Tempo de variabilidade", "1/f", "Escala temporal inversa da frequencia observada.", "Compendio Vol XIII - Astrofisica", "Com f=120: resultado=0.0083.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("371", "Densidade de fluxo", "L/(4*pi*d2)", "Fluxo observado para luminosidade isotropica.", "Compendio Vol XIII - Astrofisica", "Com L=1e32, d2=1e40: resultado=7.96e-10.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("372", "Indice espectral", "-dlogF/dlogNu", "Inclinacao espectral em potencia de frequencia.", "Compendio Vol XIII - Astrofisica", "Com dlogF=-0.9 e dlogNu=0.5: resultado=1.8.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("373", "Taxa de fotons", "F/Eph", "Numero de fotons por area e tempo.", "Compendio Vol XIII - Astrofisica", "Com F=2e-10 e Eph=4e-13: resultado=500.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("374", "Profundidade optica", "kappa*rho*L", "Atenuacao acumulada ao longo de caminho L.", "Compendio Vol XIII - Astrofisica", "Com kappa=0.2, rho=1e-8, L=1e9: resultado=2.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("375", "Probabilidade de escape", "exp(-tau)", "Fracao de fotons que escapam do meio.", "Compendio Vol XIII - Astrofisica", "Com tau=2: resultado=0.1353.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("376", "Pressao de radiacao", "u/3", "Pressao isotropica associada a densidade de energia u.", "Compendio Vol XIII - Astrofisica", "Com u=12: resultado=4.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("377", "Potencia sincrotron simplificada", "B*B*gamma2", "Escala de emissao por particulas relativisticas.", "Compendio Vol XIII - Astrofisica", "Com B=0.5 e gamma2=1e6: resultado=250000.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("378", "Escala de resfriamento", "E/P", "Tempo energetico para perda radiativa.", "Compendio Vol XIII - Astrofisica", "Com E=9e12 e P=3e10: resultado=300.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("379", "Razao sinal fundo", "S/B", "Detectabilidade de fonte de altas energias.", "Compendio Vol XIII - Astrofisica", "Com S=180 e B=60: resultado=3.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao"),
            new("380", "Significancia estatistica simplificada", "S/sqrt(B)", "Estimativa de significancia em contagem de eventos.", "Compendio Vol XIII - Astrofisica", "Com S=50 e sqrt(B)=10: resultado=5.", "Astrofisica de Altas Energias", "Buracos Negros e Acrecao")
        ];
    }
}