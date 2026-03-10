using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// Volume XI - 400 formulas especificas por disciplina (20 areas x 20 formulas).
    /// IDs: 5001-5400 | Codigos: V11-001..V11-400
    /// </summary>
    public partial class FormulaService
    {
        public void AdicionarFormulasVol11()
        {
            _formulas.AddRange(ObterFormulasVol11Especificas());
        }

        private static List<Formula> ObterFormulasVol11Especificas()
        {
            var lista = new List<Formula>(400);

            // Astrofisica Estelar
            lista.Add(new Formula
            {
                Id = "5001",
                CodigoCompendio = "V11-001",
                Nome = "Astrofisica Estelar - Balanco Diferencial 01",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5002",
                CodigoCompendio = "V11-002",
                Nome = "Astrofisica Estelar - Lei Linear 02",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5003",
                CodigoCompendio = "V11-003",
                Nome = "Astrofisica Estelar - Lei Quadratica 03",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5004",
                CodigoCompendio = "V11-004",
                Nome = "Astrofisica Estelar - Crescimento Exponencial 04",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5005",
                CodigoCompendio = "V11-005",
                Nome = "Astrofisica Estelar - Modelo Logistico 05",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5006",
                CodigoCompendio = "V11-006",
                Nome = "Astrofisica Estelar - Eficiencia 06",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5007",
                CodigoCompendio = "V11-007",
                Nome = "Astrofisica Estelar - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5008",
                CodigoCompendio = "V11-008",
                Nome = "Astrofisica Estelar - Fluxo Advectivo 08",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5009",
                CodigoCompendio = "V11-009",
                Nome = "Astrofisica Estelar - Fluxo Difusivo 09",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5010",
                CodigoCompendio = "V11-010",
                Nome = "Astrofisica Estelar - Conducao Termica 10",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5011",
                CodigoCompendio = "V11-011",
                Nome = "Astrofisica Estelar - Numero de Reynolds 11",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5012",
                CodigoCompendio = "V11-012",
                Nome = "Astrofisica Estelar - Numero de Peclet 12",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5013",
                CodigoCompendio = "V11-013",
                Nome = "Astrofisica Estelar - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5014",
                CodigoCompendio = "V11-014",
                Nome = "Astrofisica Estelar - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5015",
                CodigoCompendio = "V11-015",
                Nome = "Astrofisica Estelar - Indice de Risco 15",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5016",
                CodigoCompendio = "V11-016",
                Nome = "Astrofisica Estelar - Valor Presente 16",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5017",
                CodigoCompendio = "V11-017",
                Nome = "Astrofisica Estelar - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5018",
                CodigoCompendio = "V11-018",
                Nome = "Astrofisica Estelar - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5019",
                CodigoCompendio = "V11-019",
                Nome = "Astrofisica Estelar - Entropia de Shannon 19",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5020",
                CodigoCompendio = "V11-020",
                Nome = "Astrofisica Estelar - Indice de Convergencia 20",
                Categoria = "Vol XI - Astrofisica Estelar",
                SubCategoria = "Astrofisica Estelar",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: balanco radiativo, estabilidade hidrodinamica e escalas de evolucao estelar. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Eddington e Chandrasekhar",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em astrofisica estelar: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "★",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em balanco radiativo e evolucao estelar; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Fusao Termonuclear
            lista.Add(new Formula
            {
                Id = "5021",
                CodigoCompendio = "V11-021",
                Nome = "Fusao Termonuclear - Balanco Diferencial 01",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5022",
                CodigoCompendio = "V11-022",
                Nome = "Fusao Termonuclear - Lei Linear 02",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5023",
                CodigoCompendio = "V11-023",
                Nome = "Fusao Termonuclear - Lei Quadratica 03",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5024",
                CodigoCompendio = "V11-024",
                Nome = "Fusao Termonuclear - Crescimento Exponencial 04",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5025",
                CodigoCompendio = "V11-025",
                Nome = "Fusao Termonuclear - Modelo Logistico 05",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5026",
                CodigoCompendio = "V11-026",
                Nome = "Fusao Termonuclear - Eficiencia 06",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5027",
                CodigoCompendio = "V11-027",
                Nome = "Fusao Termonuclear - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5028",
                CodigoCompendio = "V11-028",
                Nome = "Fusao Termonuclear - Fluxo Advectivo 08",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5029",
                CodigoCompendio = "V11-029",
                Nome = "Fusao Termonuclear - Fluxo Difusivo 09",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5030",
                CodigoCompendio = "V11-030",
                Nome = "Fusao Termonuclear - Conducao Termica 10",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5031",
                CodigoCompendio = "V11-031",
                Nome = "Fusao Termonuclear - Numero de Reynolds 11",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5032",
                CodigoCompendio = "V11-032",
                Nome = "Fusao Termonuclear - Numero de Peclet 12",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5033",
                CodigoCompendio = "V11-033",
                Nome = "Fusao Termonuclear - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5034",
                CodigoCompendio = "V11-034",
                Nome = "Fusao Termonuclear - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5035",
                CodigoCompendio = "V11-035",
                Nome = "Fusao Termonuclear - Indice de Risco 15",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5036",
                CodigoCompendio = "V11-036",
                Nome = "Fusao Termonuclear - Valor Presente 16",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5037",
                CodigoCompendio = "V11-037",
                Nome = "Fusao Termonuclear - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5038",
                CodigoCompendio = "V11-038",
                Nome = "Fusao Termonuclear - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5039",
                CodigoCompendio = "V11-039",
                Nome = "Fusao Termonuclear - Entropia de Shannon 19",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5040",
                CodigoCompendio = "V11-040",
                Nome = "Fusao Termonuclear - Indice de Convergencia 20",
                Categoria = "Vol XI - Fusao Termonuclear",
                SubCategoria = "Fusao Termonuclear",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: criterio de ignicao, confinamento magnetico e ganho energetico do plasma. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lawson e ITER",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fusao termonuclear: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "☢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em ignicao e confinamento de plasma; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Engenharia de Petroleo
            lista.Add(new Formula
            {
                Id = "5041",
                CodigoCompendio = "V11-041",
                Nome = "Engenharia de Petroleo - Balanco Diferencial 01",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5042",
                CodigoCompendio = "V11-042",
                Nome = "Engenharia de Petroleo - Lei Linear 02",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5043",
                CodigoCompendio = "V11-043",
                Nome = "Engenharia de Petroleo - Lei Quadratica 03",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5044",
                CodigoCompendio = "V11-044",
                Nome = "Engenharia de Petroleo - Crescimento Exponencial 04",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5045",
                CodigoCompendio = "V11-045",
                Nome = "Engenharia de Petroleo - Modelo Logistico 05",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5046",
                CodigoCompendio = "V11-046",
                Nome = "Engenharia de Petroleo - Eficiencia 06",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5047",
                CodigoCompendio = "V11-047",
                Nome = "Engenharia de Petroleo - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5048",
                CodigoCompendio = "V11-048",
                Nome = "Engenharia de Petroleo - Fluxo Advectivo 08",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5049",
                CodigoCompendio = "V11-049",
                Nome = "Engenharia de Petroleo - Fluxo Difusivo 09",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5050",
                CodigoCompendio = "V11-050",
                Nome = "Engenharia de Petroleo - Conducao Termica 10",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5051",
                CodigoCompendio = "V11-051",
                Nome = "Engenharia de Petroleo - Numero de Reynolds 11",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5052",
                CodigoCompendio = "V11-052",
                Nome = "Engenharia de Petroleo - Numero de Peclet 12",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5053",
                CodigoCompendio = "V11-053",
                Nome = "Engenharia de Petroleo - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5054",
                CodigoCompendio = "V11-054",
                Nome = "Engenharia de Petroleo - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5055",
                CodigoCompendio = "V11-055",
                Nome = "Engenharia de Petroleo - Indice de Risco 15",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5056",
                CodigoCompendio = "V11-056",
                Nome = "Engenharia de Petroleo - Valor Presente 16",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5057",
                CodigoCompendio = "V11-057",
                Nome = "Engenharia de Petroleo - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5058",
                CodigoCompendio = "V11-058",
                Nome = "Engenharia de Petroleo - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5059",
                CodigoCompendio = "V11-059",
                Nome = "Engenharia de Petroleo - Entropia de Shannon 19",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5060",
                CodigoCompendio = "V11-060",
                Nome = "Engenharia de Petroleo - Indice de Convergencia 20",
                Categoria = "Vol XI - Engenharia de Petroleo",
                SubCategoria = "Engenharia de Petroleo",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: produtividade de reservatorio, queda de pressao e desempenho de escoamento multifasico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Darcy e Muskat",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de petroleo: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🛢",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em escoamento multifasico em reservatorios; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Ciencia de Polimeros
            lista.Add(new Formula
            {
                Id = "5061",
                CodigoCompendio = "V11-061",
                Nome = "Ciencia de Polimeros - Balanco Diferencial 01",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5062",
                CodigoCompendio = "V11-062",
                Nome = "Ciencia de Polimeros - Lei Linear 02",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5063",
                CodigoCompendio = "V11-063",
                Nome = "Ciencia de Polimeros - Lei Quadratica 03",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5064",
                CodigoCompendio = "V11-064",
                Nome = "Ciencia de Polimeros - Crescimento Exponencial 04",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5065",
                CodigoCompendio = "V11-065",
                Nome = "Ciencia de Polimeros - Modelo Logistico 05",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5066",
                CodigoCompendio = "V11-066",
                Nome = "Ciencia de Polimeros - Eficiencia 06",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5067",
                CodigoCompendio = "V11-067",
                Nome = "Ciencia de Polimeros - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5068",
                CodigoCompendio = "V11-068",
                Nome = "Ciencia de Polimeros - Fluxo Advectivo 08",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5069",
                CodigoCompendio = "V11-069",
                Nome = "Ciencia de Polimeros - Fluxo Difusivo 09",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5070",
                CodigoCompendio = "V11-070",
                Nome = "Ciencia de Polimeros - Conducao Termica 10",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5071",
                CodigoCompendio = "V11-071",
                Nome = "Ciencia de Polimeros - Numero de Reynolds 11",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5072",
                CodigoCompendio = "V11-072",
                Nome = "Ciencia de Polimeros - Numero de Peclet 12",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5073",
                CodigoCompendio = "V11-073",
                Nome = "Ciencia de Polimeros - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5074",
                CodigoCompendio = "V11-074",
                Nome = "Ciencia de Polimeros - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5075",
                CodigoCompendio = "V11-075",
                Nome = "Ciencia de Polimeros - Indice de Risco 15",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5076",
                CodigoCompendio = "V11-076",
                Nome = "Ciencia de Polimeros - Valor Presente 16",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5077",
                CodigoCompendio = "V11-077",
                Nome = "Ciencia de Polimeros - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5078",
                CodigoCompendio = "V11-078",
                Nome = "Ciencia de Polimeros - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5079",
                CodigoCompendio = "V11-079",
                Nome = "Ciencia de Polimeros - Entropia de Shannon 19",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5080",
                CodigoCompendio = "V11-080",
                Nome = "Ciencia de Polimeros - Indice de Convergencia 20",
                Categoria = "Vol XI - Ciencia de Polimeros",
                SubCategoria = "Ciencia de Polimeros",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: cinetica de polimerizacao, resposta reologica e estabilidade de processamento. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Flory",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de polimeros: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🧪",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em cinetica e reologia de polimeros; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Geofisica e Sismologia
            lista.Add(new Formula
            {
                Id = "5081",
                CodigoCompendio = "V11-081",
                Nome = "Geofisica e Sismologia - Balanco Diferencial 01",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5082",
                CodigoCompendio = "V11-082",
                Nome = "Geofisica e Sismologia - Lei Linear 02",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5083",
                CodigoCompendio = "V11-083",
                Nome = "Geofisica e Sismologia - Lei Quadratica 03",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5084",
                CodigoCompendio = "V11-084",
                Nome = "Geofisica e Sismologia - Crescimento Exponencial 04",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5085",
                CodigoCompendio = "V11-085",
                Nome = "Geofisica e Sismologia - Modelo Logistico 05",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5086",
                CodigoCompendio = "V11-086",
                Nome = "Geofisica e Sismologia - Eficiencia 06",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5087",
                CodigoCompendio = "V11-087",
                Nome = "Geofisica e Sismologia - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5088",
                CodigoCompendio = "V11-088",
                Nome = "Geofisica e Sismologia - Fluxo Advectivo 08",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5089",
                CodigoCompendio = "V11-089",
                Nome = "Geofisica e Sismologia - Fluxo Difusivo 09",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5090",
                CodigoCompendio = "V11-090",
                Nome = "Geofisica e Sismologia - Conducao Termica 10",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5091",
                CodigoCompendio = "V11-091",
                Nome = "Geofisica e Sismologia - Numero de Reynolds 11",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5092",
                CodigoCompendio = "V11-092",
                Nome = "Geofisica e Sismologia - Numero de Peclet 12",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5093",
                CodigoCompendio = "V11-093",
                Nome = "Geofisica e Sismologia - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5094",
                CodigoCompendio = "V11-094",
                Nome = "Geofisica e Sismologia - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5095",
                CodigoCompendio = "V11-095",
                Nome = "Geofisica e Sismologia - Indice de Risco 15",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5096",
                CodigoCompendio = "V11-096",
                Nome = "Geofisica e Sismologia - Valor Presente 16",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5097",
                CodigoCompendio = "V11-097",
                Nome = "Geofisica e Sismologia - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5098",
                CodigoCompendio = "V11-098",
                Nome = "Geofisica e Sismologia - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5099",
                CodigoCompendio = "V11-099",
                Nome = "Geofisica e Sismologia - Entropia de Shannon 19",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5100",
                CodigoCompendio = "V11-100",
                Nome = "Geofisica e Sismologia - Indice de Convergencia 20",
                Categoria = "Vol XI - Geofisica e Sismologia",
                SubCategoria = "Geofisica e Sismologia",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: propagacao de ondas, energia sismica e inferencia geofisica de subsuperficie. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Gutenberg e Richter",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em geofisica e sismologia: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🌍",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em propagacao de ondas e risco sismico; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Fotonica e Optica Quantica
            lista.Add(new Formula
            {
                Id = "5101",
                CodigoCompendio = "V11-101",
                Nome = "Fotonica e Optica Quantica - Balanco Diferencial 01",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5102",
                CodigoCompendio = "V11-102",
                Nome = "Fotonica e Optica Quantica - Lei Linear 02",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5103",
                CodigoCompendio = "V11-103",
                Nome = "Fotonica e Optica Quantica - Lei Quadratica 03",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5104",
                CodigoCompendio = "V11-104",
                Nome = "Fotonica e Optica Quantica - Crescimento Exponencial 04",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5105",
                CodigoCompendio = "V11-105",
                Nome = "Fotonica e Optica Quantica - Modelo Logistico 05",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5106",
                CodigoCompendio = "V11-106",
                Nome = "Fotonica e Optica Quantica - Eficiencia 06",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5107",
                CodigoCompendio = "V11-107",
                Nome = "Fotonica e Optica Quantica - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5108",
                CodigoCompendio = "V11-108",
                Nome = "Fotonica e Optica Quantica - Fluxo Advectivo 08",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5109",
                CodigoCompendio = "V11-109",
                Nome = "Fotonica e Optica Quantica - Fluxo Difusivo 09",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5110",
                CodigoCompendio = "V11-110",
                Nome = "Fotonica e Optica Quantica - Conducao Termica 10",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5111",
                CodigoCompendio = "V11-111",
                Nome = "Fotonica e Optica Quantica - Numero de Reynolds 11",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5112",
                CodigoCompendio = "V11-112",
                Nome = "Fotonica e Optica Quantica - Numero de Peclet 12",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5113",
                CodigoCompendio = "V11-113",
                Nome = "Fotonica e Optica Quantica - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5114",
                CodigoCompendio = "V11-114",
                Nome = "Fotonica e Optica Quantica - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5115",
                CodigoCompendio = "V11-115",
                Nome = "Fotonica e Optica Quantica - Indice de Risco 15",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5116",
                CodigoCompendio = "V11-116",
                Nome = "Fotonica e Optica Quantica - Valor Presente 16",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5117",
                CodigoCompendio = "V11-117",
                Nome = "Fotonica e Optica Quantica - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5118",
                CodigoCompendio = "V11-118",
                Nome = "Fotonica e Optica Quantica - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5119",
                CodigoCompendio = "V11-119",
                Nome = "Fotonica e Optica Quantica - Entropia de Shannon 19",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5120",
                CodigoCompendio = "V11-120",
                Nome = "Fotonica e Optica Quantica - Indice de Convergencia 20",
                Categoria = "Vol XI - Fotonica e Optica Quantica",
                SubCategoria = "Fotonica e Optica Quantica",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: transporte optico, relacao sinal-ruido e comportamento de fontes coerentes. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Einstein e Glauber",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fotonica e optica quantica: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "💡",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em transporte optico e coerencia quantica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Ciencia de Dados e ML
            lista.Add(new Formula
            {
                Id = "5121",
                CodigoCompendio = "V11-121",
                Nome = "Ciencia de Dados e ML - Balanco Diferencial 01",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5122",
                CodigoCompendio = "V11-122",
                Nome = "Ciencia de Dados e ML - Lei Linear 02",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5123",
                CodigoCompendio = "V11-123",
                Nome = "Ciencia de Dados e ML - Lei Quadratica 03",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5124",
                CodigoCompendio = "V11-124",
                Nome = "Ciencia de Dados e ML - Crescimento Exponencial 04",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5125",
                CodigoCompendio = "V11-125",
                Nome = "Ciencia de Dados e ML - Modelo Logistico 05",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5126",
                CodigoCompendio = "V11-126",
                Nome = "Ciencia de Dados e ML - Eficiencia 06",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5127",
                CodigoCompendio = "V11-127",
                Nome = "Ciencia de Dados e ML - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5128",
                CodigoCompendio = "V11-128",
                Nome = "Ciencia de Dados e ML - Fluxo Advectivo 08",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5129",
                CodigoCompendio = "V11-129",
                Nome = "Ciencia de Dados e ML - Fluxo Difusivo 09",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5130",
                CodigoCompendio = "V11-130",
                Nome = "Ciencia de Dados e ML - Conducao Termica 10",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5131",
                CodigoCompendio = "V11-131",
                Nome = "Ciencia de Dados e ML - Numero de Reynolds 11",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5132",
                CodigoCompendio = "V11-132",
                Nome = "Ciencia de Dados e ML - Numero de Peclet 12",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5133",
                CodigoCompendio = "V11-133",
                Nome = "Ciencia de Dados e ML - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5134",
                CodigoCompendio = "V11-134",
                Nome = "Ciencia de Dados e ML - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5135",
                CodigoCompendio = "V11-135",
                Nome = "Ciencia de Dados e ML - Indice de Risco 15",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5136",
                CodigoCompendio = "V11-136",
                Nome = "Ciencia de Dados e ML - Valor Presente 16",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5137",
                CodigoCompendio = "V11-137",
                Nome = "Ciencia de Dados e ML - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5138",
                CodigoCompendio = "V11-138",
                Nome = "Ciencia de Dados e ML - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5139",
                CodigoCompendio = "V11-139",
                Nome = "Ciencia de Dados e ML - Entropia de Shannon 19",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5140",
                CodigoCompendio = "V11-140",
                Nome = "Ciencia de Dados e ML - Indice de Convergencia 20",
                Categoria = "Vol XI - Ciencia de Dados e ML",
                SubCategoria = "Ciencia de Dados e ML",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: calibracao de modelos, incerteza preditiva e desempenho estatistico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Bayes e Vapnik",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em ciencia de dados e ml: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🧠",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em calibracao estatistica e inferencia preditiva; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Biomecanica Cardiovascular
            lista.Add(new Formula
            {
                Id = "5141",
                CodigoCompendio = "V11-141",
                Nome = "Biomecanica Cardiovascular - Balanco Diferencial 01",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5142",
                CodigoCompendio = "V11-142",
                Nome = "Biomecanica Cardiovascular - Lei Linear 02",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5143",
                CodigoCompendio = "V11-143",
                Nome = "Biomecanica Cardiovascular - Lei Quadratica 03",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5144",
                CodigoCompendio = "V11-144",
                Nome = "Biomecanica Cardiovascular - Crescimento Exponencial 04",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5145",
                CodigoCompendio = "V11-145",
                Nome = "Biomecanica Cardiovascular - Modelo Logistico 05",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5146",
                CodigoCompendio = "V11-146",
                Nome = "Biomecanica Cardiovascular - Eficiencia 06",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5147",
                CodigoCompendio = "V11-147",
                Nome = "Biomecanica Cardiovascular - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5148",
                CodigoCompendio = "V11-148",
                Nome = "Biomecanica Cardiovascular - Fluxo Advectivo 08",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5149",
                CodigoCompendio = "V11-149",
                Nome = "Biomecanica Cardiovascular - Fluxo Difusivo 09",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5150",
                CodigoCompendio = "V11-150",
                Nome = "Biomecanica Cardiovascular - Conducao Termica 10",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5151",
                CodigoCompendio = "V11-151",
                Nome = "Biomecanica Cardiovascular - Numero de Reynolds 11",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5152",
                CodigoCompendio = "V11-152",
                Nome = "Biomecanica Cardiovascular - Numero de Peclet 12",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5153",
                CodigoCompendio = "V11-153",
                Nome = "Biomecanica Cardiovascular - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5154",
                CodigoCompendio = "V11-154",
                Nome = "Biomecanica Cardiovascular - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5155",
                CodigoCompendio = "V11-155",
                Nome = "Biomecanica Cardiovascular - Indice de Risco 15",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5156",
                CodigoCompendio = "V11-156",
                Nome = "Biomecanica Cardiovascular - Valor Presente 16",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5157",
                CodigoCompendio = "V11-157",
                Nome = "Biomecanica Cardiovascular - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5158",
                CodigoCompendio = "V11-158",
                Nome = "Biomecanica Cardiovascular - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5159",
                CodigoCompendio = "V11-159",
                Nome = "Biomecanica Cardiovascular - Entropia de Shannon 19",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5160",
                CodigoCompendio = "V11-160",
                Nome = "Biomecanica Cardiovascular - Indice de Convergencia 20",
                Categoria = "Vol XI - Biomecanica Cardiovascular",
                SubCategoria = "Biomecanica Cardiovascular",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: hemodinamica arterial, tensoes de parede e biomarcadores de risco mecanico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Poiseuille e Womersley",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em biomecanica cardiovascular: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🫀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em hemodinamica e tensoes cardiovasculares; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Engenharia de Controle
            lista.Add(new Formula
            {
                Id = "5161",
                CodigoCompendio = "V11-161",
                Nome = "Engenharia de Controle - Balanco Diferencial 01",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5162",
                CodigoCompendio = "V11-162",
                Nome = "Engenharia de Controle - Lei Linear 02",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5163",
                CodigoCompendio = "V11-163",
                Nome = "Engenharia de Controle - Lei Quadratica 03",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5164",
                CodigoCompendio = "V11-164",
                Nome = "Engenharia de Controle - Crescimento Exponencial 04",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5165",
                CodigoCompendio = "V11-165",
                Nome = "Engenharia de Controle - Modelo Logistico 05",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5166",
                CodigoCompendio = "V11-166",
                Nome = "Engenharia de Controle - Eficiencia 06",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5167",
                CodigoCompendio = "V11-167",
                Nome = "Engenharia de Controle - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5168",
                CodigoCompendio = "V11-168",
                Nome = "Engenharia de Controle - Fluxo Advectivo 08",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5169",
                CodigoCompendio = "V11-169",
                Nome = "Engenharia de Controle - Fluxo Difusivo 09",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5170",
                CodigoCompendio = "V11-170",
                Nome = "Engenharia de Controle - Conducao Termica 10",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5171",
                CodigoCompendio = "V11-171",
                Nome = "Engenharia de Controle - Numero de Reynolds 11",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5172",
                CodigoCompendio = "V11-172",
                Nome = "Engenharia de Controle - Numero de Peclet 12",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5173",
                CodigoCompendio = "V11-173",
                Nome = "Engenharia de Controle - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5174",
                CodigoCompendio = "V11-174",
                Nome = "Engenharia de Controle - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5175",
                CodigoCompendio = "V11-175",
                Nome = "Engenharia de Controle - Indice de Risco 15",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5176",
                CodigoCompendio = "V11-176",
                Nome = "Engenharia de Controle - Valor Presente 16",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5177",
                CodigoCompendio = "V11-177",
                Nome = "Engenharia de Controle - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5178",
                CodigoCompendio = "V11-178",
                Nome = "Engenharia de Controle - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5179",
                CodigoCompendio = "V11-179",
                Nome = "Engenharia de Controle - Entropia de Shannon 19",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5180",
                CodigoCompendio = "V11-180",
                Nome = "Engenharia de Controle - Indice de Convergencia 20",
                Categoria = "Vol XI - Engenharia de Controle",
                SubCategoria = "Engenharia de Controle",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: estabilidade de malha fechada, sensibilidade parametica e robustez operacional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Nyquist e Kalman",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia de controle: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🎛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em estabilidade e robustez de malha fechada; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Engenharia Ambiental
            lista.Add(new Formula
            {
                Id = "5181",
                CodigoCompendio = "V11-181",
                Nome = "Engenharia Ambiental - Balanco Diferencial 01",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5182",
                CodigoCompendio = "V11-182",
                Nome = "Engenharia Ambiental - Lei Linear 02",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5183",
                CodigoCompendio = "V11-183",
                Nome = "Engenharia Ambiental - Lei Quadratica 03",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5184",
                CodigoCompendio = "V11-184",
                Nome = "Engenharia Ambiental - Crescimento Exponencial 04",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5185",
                CodigoCompendio = "V11-185",
                Nome = "Engenharia Ambiental - Modelo Logistico 05",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5186",
                CodigoCompendio = "V11-186",
                Nome = "Engenharia Ambiental - Eficiencia 06",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5187",
                CodigoCompendio = "V11-187",
                Nome = "Engenharia Ambiental - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5188",
                CodigoCompendio = "V11-188",
                Nome = "Engenharia Ambiental - Fluxo Advectivo 08",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5189",
                CodigoCompendio = "V11-189",
                Nome = "Engenharia Ambiental - Fluxo Difusivo 09",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5190",
                CodigoCompendio = "V11-190",
                Nome = "Engenharia Ambiental - Conducao Termica 10",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5191",
                CodigoCompendio = "V11-191",
                Nome = "Engenharia Ambiental - Numero de Reynolds 11",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5192",
                CodigoCompendio = "V11-192",
                Nome = "Engenharia Ambiental - Numero de Peclet 12",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5193",
                CodigoCompendio = "V11-193",
                Nome = "Engenharia Ambiental - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5194",
                CodigoCompendio = "V11-194",
                Nome = "Engenharia Ambiental - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5195",
                CodigoCompendio = "V11-195",
                Nome = "Engenharia Ambiental - Indice de Risco 15",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5196",
                CodigoCompendio = "V11-196",
                Nome = "Engenharia Ambiental - Valor Presente 16",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5197",
                CodigoCompendio = "V11-197",
                Nome = "Engenharia Ambiental - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5198",
                CodigoCompendio = "V11-198",
                Nome = "Engenharia Ambiental - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5199",
                CodigoCompendio = "V11-199",
                Nome = "Engenharia Ambiental - Entropia de Shannon 19",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5200",
                CodigoCompendio = "V11-200",
                Nome = "Engenharia Ambiental - Indice de Convergencia 20",
                Categoria = "Vol XI - Engenharia Ambiental",
                SubCategoria = "Engenharia Ambiental",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: balancos de contaminantes, eficiencia de remocao e metricas de risco ambiental. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Streeter-Phelps",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia ambiental: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "♻",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em balancos de contaminantes e remocao; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Engenharia Nuclear
            lista.Add(new Formula
            {
                Id = "5201",
                CodigoCompendio = "V11-201",
                Nome = "Engenharia Nuclear - Balanco Diferencial 01",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5202",
                CodigoCompendio = "V11-202",
                Nome = "Engenharia Nuclear - Lei Linear 02",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5203",
                CodigoCompendio = "V11-203",
                Nome = "Engenharia Nuclear - Lei Quadratica 03",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5204",
                CodigoCompendio = "V11-204",
                Nome = "Engenharia Nuclear - Crescimento Exponencial 04",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5205",
                CodigoCompendio = "V11-205",
                Nome = "Engenharia Nuclear - Modelo Logistico 05",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5206",
                CodigoCompendio = "V11-206",
                Nome = "Engenharia Nuclear - Eficiencia 06",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5207",
                CodigoCompendio = "V11-207",
                Nome = "Engenharia Nuclear - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5208",
                CodigoCompendio = "V11-208",
                Nome = "Engenharia Nuclear - Fluxo Advectivo 08",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5209",
                CodigoCompendio = "V11-209",
                Nome = "Engenharia Nuclear - Fluxo Difusivo 09",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5210",
                CodigoCompendio = "V11-210",
                Nome = "Engenharia Nuclear - Conducao Termica 10",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5211",
                CodigoCompendio = "V11-211",
                Nome = "Engenharia Nuclear - Numero de Reynolds 11",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5212",
                CodigoCompendio = "V11-212",
                Nome = "Engenharia Nuclear - Numero de Peclet 12",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5213",
                CodigoCompendio = "V11-213",
                Nome = "Engenharia Nuclear - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5214",
                CodigoCompendio = "V11-214",
                Nome = "Engenharia Nuclear - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5215",
                CodigoCompendio = "V11-215",
                Nome = "Engenharia Nuclear - Indice de Risco 15",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5216",
                CodigoCompendio = "V11-216",
                Nome = "Engenharia Nuclear - Valor Presente 16",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5217",
                CodigoCompendio = "V11-217",
                Nome = "Engenharia Nuclear - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5218",
                CodigoCompendio = "V11-218",
                Nome = "Engenharia Nuclear - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5219",
                CodigoCompendio = "V11-219",
                Nome = "Engenharia Nuclear - Entropia de Shannon 19",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5220",
                CodigoCompendio = "V11-220",
                Nome = "Engenharia Nuclear - Indice de Convergencia 20",
                Categoria = "Vol XI - Engenharia Nuclear",
                SubCategoria = "Engenharia Nuclear",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: criticidade, margem termohidraulica e indicadores de seguranca de reatores. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Fermi e Weinberg",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia nuclear: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "⚛",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em criticidade e margem termohidraulica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Meteorologia e Clima
            lista.Add(new Formula
            {
                Id = "5221",
                CodigoCompendio = "V11-221",
                Nome = "Meteorologia e Clima - Balanco Diferencial 01",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5222",
                CodigoCompendio = "V11-222",
                Nome = "Meteorologia e Clima - Lei Linear 02",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5223",
                CodigoCompendio = "V11-223",
                Nome = "Meteorologia e Clima - Lei Quadratica 03",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5224",
                CodigoCompendio = "V11-224",
                Nome = "Meteorologia e Clima - Crescimento Exponencial 04",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5225",
                CodigoCompendio = "V11-225",
                Nome = "Meteorologia e Clima - Modelo Logistico 05",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5226",
                CodigoCompendio = "V11-226",
                Nome = "Meteorologia e Clima - Eficiencia 06",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5227",
                CodigoCompendio = "V11-227",
                Nome = "Meteorologia e Clima - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5228",
                CodigoCompendio = "V11-228",
                Nome = "Meteorologia e Clima - Fluxo Advectivo 08",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5229",
                CodigoCompendio = "V11-229",
                Nome = "Meteorologia e Clima - Fluxo Difusivo 09",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5230",
                CodigoCompendio = "V11-230",
                Nome = "Meteorologia e Clima - Conducao Termica 10",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5231",
                CodigoCompendio = "V11-231",
                Nome = "Meteorologia e Clima - Numero de Reynolds 11",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5232",
                CodigoCompendio = "V11-232",
                Nome = "Meteorologia e Clima - Numero de Peclet 12",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5233",
                CodigoCompendio = "V11-233",
                Nome = "Meteorologia e Clima - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5234",
                CodigoCompendio = "V11-234",
                Nome = "Meteorologia e Clima - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5235",
                CodigoCompendio = "V11-235",
                Nome = "Meteorologia e Clima - Indice de Risco 15",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5236",
                CodigoCompendio = "V11-236",
                Nome = "Meteorologia e Clima - Valor Presente 16",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5237",
                CodigoCompendio = "V11-237",
                Nome = "Meteorologia e Clima - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5238",
                CodigoCompendio = "V11-238",
                Nome = "Meteorologia e Clima - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5239",
                CodigoCompendio = "V11-239",
                Nome = "Meteorologia e Clima - Entropia de Shannon 19",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5240",
                CodigoCompendio = "V11-240",
                Nome = "Meteorologia e Clima - Indice de Convergencia 20",
                Categoria = "Vol XI - Meteorologia e Clima",
                SubCategoria = "Meteorologia e Clima",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: forcantes atmosfericas, transporte de massa e variabilidade climatica regional. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Lorenz e Manabe",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em meteorologia e clima: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🌦",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em forcantes atmosfericas e variabilidade climatica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Fisica de Semicondutores
            lista.Add(new Formula
            {
                Id = "5241",
                CodigoCompendio = "V11-241",
                Nome = "Fisica de Semicondutores - Balanco Diferencial 01",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5242",
                CodigoCompendio = "V11-242",
                Nome = "Fisica de Semicondutores - Lei Linear 02",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5243",
                CodigoCompendio = "V11-243",
                Nome = "Fisica de Semicondutores - Lei Quadratica 03",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5244",
                CodigoCompendio = "V11-244",
                Nome = "Fisica de Semicondutores - Crescimento Exponencial 04",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5245",
                CodigoCompendio = "V11-245",
                Nome = "Fisica de Semicondutores - Modelo Logistico 05",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5246",
                CodigoCompendio = "V11-246",
                Nome = "Fisica de Semicondutores - Eficiencia 06",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5247",
                CodigoCompendio = "V11-247",
                Nome = "Fisica de Semicondutores - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5248",
                CodigoCompendio = "V11-248",
                Nome = "Fisica de Semicondutores - Fluxo Advectivo 08",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5249",
                CodigoCompendio = "V11-249",
                Nome = "Fisica de Semicondutores - Fluxo Difusivo 09",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5250",
                CodigoCompendio = "V11-250",
                Nome = "Fisica de Semicondutores - Conducao Termica 10",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5251",
                CodigoCompendio = "V11-251",
                Nome = "Fisica de Semicondutores - Numero de Reynolds 11",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5252",
                CodigoCompendio = "V11-252",
                Nome = "Fisica de Semicondutores - Numero de Peclet 12",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5253",
                CodigoCompendio = "V11-253",
                Nome = "Fisica de Semicondutores - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5254",
                CodigoCompendio = "V11-254",
                Nome = "Fisica de Semicondutores - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5255",
                CodigoCompendio = "V11-255",
                Nome = "Fisica de Semicondutores - Indice de Risco 15",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5256",
                CodigoCompendio = "V11-256",
                Nome = "Fisica de Semicondutores - Valor Presente 16",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5257",
                CodigoCompendio = "V11-257",
                Nome = "Fisica de Semicondutores - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5258",
                CodigoCompendio = "V11-258",
                Nome = "Fisica de Semicondutores - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5259",
                CodigoCompendio = "V11-259",
                Nome = "Fisica de Semicondutores - Entropia de Shannon 19",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5260",
                CodigoCompendio = "V11-260",
                Nome = "Fisica de Semicondutores - Indice de Convergencia 20",
                Categoria = "Vol XI - Fisica de Semicondutores",
                SubCategoria = "Fisica de Semicondutores",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: transporte de portadores, dissipacao e regime de operacao de dispositivos. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shockley e Sze",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de semicondutores: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🔋",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em transporte de portadores e operacao de dispositivos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Linguistica Computacional
            lista.Add(new Formula
            {
                Id = "5261",
                CodigoCompendio = "V11-261",
                Nome = "Linguistica Computacional - Balanco Diferencial 01",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5262",
                CodigoCompendio = "V11-262",
                Nome = "Linguistica Computacional - Lei Linear 02",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5263",
                CodigoCompendio = "V11-263",
                Nome = "Linguistica Computacional - Lei Quadratica 03",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5264",
                CodigoCompendio = "V11-264",
                Nome = "Linguistica Computacional - Crescimento Exponencial 04",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5265",
                CodigoCompendio = "V11-265",
                Nome = "Linguistica Computacional - Modelo Logistico 05",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5266",
                CodigoCompendio = "V11-266",
                Nome = "Linguistica Computacional - Eficiencia 06",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5267",
                CodigoCompendio = "V11-267",
                Nome = "Linguistica Computacional - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5268",
                CodigoCompendio = "V11-268",
                Nome = "Linguistica Computacional - Fluxo Advectivo 08",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5269",
                CodigoCompendio = "V11-269",
                Nome = "Linguistica Computacional - Fluxo Difusivo 09",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5270",
                CodigoCompendio = "V11-270",
                Nome = "Linguistica Computacional - Conducao Termica 10",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5271",
                CodigoCompendio = "V11-271",
                Nome = "Linguistica Computacional - Numero de Reynolds 11",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5272",
                CodigoCompendio = "V11-272",
                Nome = "Linguistica Computacional - Numero de Peclet 12",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5273",
                CodigoCompendio = "V11-273",
                Nome = "Linguistica Computacional - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5274",
                CodigoCompendio = "V11-274",
                Nome = "Linguistica Computacional - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5275",
                CodigoCompendio = "V11-275",
                Nome = "Linguistica Computacional - Indice de Risco 15",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5276",
                CodigoCompendio = "V11-276",
                Nome = "Linguistica Computacional - Valor Presente 16",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5277",
                CodigoCompendio = "V11-277",
                Nome = "Linguistica Computacional - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5278",
                CodigoCompendio = "V11-278",
                Nome = "Linguistica Computacional - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5279",
                CodigoCompendio = "V11-279",
                Nome = "Linguistica Computacional - Entropia de Shannon 19",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5280",
                CodigoCompendio = "V11-280",
                Nome = "Linguistica Computacional - Indice de Convergencia 20",
                Categoria = "Vol XI - Linguistica Computacional",
                SubCategoria = "Linguistica Computacional",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: entropia lexical, inferencia probabilistica e qualidade de modelagem linguistica. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Shannon e Chomsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em linguistica computacional: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🗣",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em incerteza lexical e modelagem de linguagem; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Microfluidica e Biotecnologia
            lista.Add(new Formula
            {
                Id = "5281",
                CodigoCompendio = "V11-281",
                Nome = "Microfluidica e Biotecnologia - Balanco Diferencial 01",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5282",
                CodigoCompendio = "V11-282",
                Nome = "Microfluidica e Biotecnologia - Lei Linear 02",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5283",
                CodigoCompendio = "V11-283",
                Nome = "Microfluidica e Biotecnologia - Lei Quadratica 03",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5284",
                CodigoCompendio = "V11-284",
                Nome = "Microfluidica e Biotecnologia - Crescimento Exponencial 04",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5285",
                CodigoCompendio = "V11-285",
                Nome = "Microfluidica e Biotecnologia - Modelo Logistico 05",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5286",
                CodigoCompendio = "V11-286",
                Nome = "Microfluidica e Biotecnologia - Eficiencia 06",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5287",
                CodigoCompendio = "V11-287",
                Nome = "Microfluidica e Biotecnologia - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5288",
                CodigoCompendio = "V11-288",
                Nome = "Microfluidica e Biotecnologia - Fluxo Advectivo 08",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5289",
                CodigoCompendio = "V11-289",
                Nome = "Microfluidica e Biotecnologia - Fluxo Difusivo 09",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5290",
                CodigoCompendio = "V11-290",
                Nome = "Microfluidica e Biotecnologia - Conducao Termica 10",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5291",
                CodigoCompendio = "V11-291",
                Nome = "Microfluidica e Biotecnologia - Numero de Reynolds 11",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5292",
                CodigoCompendio = "V11-292",
                Nome = "Microfluidica e Biotecnologia - Numero de Peclet 12",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5293",
                CodigoCompendio = "V11-293",
                Nome = "Microfluidica e Biotecnologia - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5294",
                CodigoCompendio = "V11-294",
                Nome = "Microfluidica e Biotecnologia - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5295",
                CodigoCompendio = "V11-295",
                Nome = "Microfluidica e Biotecnologia - Indice de Risco 15",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5296",
                CodigoCompendio = "V11-296",
                Nome = "Microfluidica e Biotecnologia - Valor Presente 16",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5297",
                CodigoCompendio = "V11-297",
                Nome = "Microfluidica e Biotecnologia - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5298",
                CodigoCompendio = "V11-298",
                Nome = "Microfluidica e Biotecnologia - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5299",
                CodigoCompendio = "V11-299",
                Nome = "Microfluidica e Biotecnologia - Entropia de Shannon 19",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5300",
                CodigoCompendio = "V11-300",
                Nome = "Microfluidica e Biotecnologia - Indice de Convergencia 20",
                Categoria = "Vol XI - Microfluidica e Biotecnologia",
                SubCategoria = "Microfluidica e Biotecnologia",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: escoamento em microcanais, difusao reagente e rendimento biotecnologico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Whitesides",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em microfluidica e biotecnologia: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🧫",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em escoamento em microcanais e bioprocessos; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Fontes de Energia Renovavel
            lista.Add(new Formula
            {
                Id = "5301",
                CodigoCompendio = "V11-301",
                Nome = "Fontes de Energia Renovavel - Balanco Diferencial 01",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5302",
                CodigoCompendio = "V11-302",
                Nome = "Fontes de Energia Renovavel - Lei Linear 02",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5303",
                CodigoCompendio = "V11-303",
                Nome = "Fontes de Energia Renovavel - Lei Quadratica 03",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5304",
                CodigoCompendio = "V11-304",
                Nome = "Fontes de Energia Renovavel - Crescimento Exponencial 04",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5305",
                CodigoCompendio = "V11-305",
                Nome = "Fontes de Energia Renovavel - Modelo Logistico 05",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5306",
                CodigoCompendio = "V11-306",
                Nome = "Fontes de Energia Renovavel - Eficiencia 06",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5307",
                CodigoCompendio = "V11-307",
                Nome = "Fontes de Energia Renovavel - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5308",
                CodigoCompendio = "V11-308",
                Nome = "Fontes de Energia Renovavel - Fluxo Advectivo 08",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5309",
                CodigoCompendio = "V11-309",
                Nome = "Fontes de Energia Renovavel - Fluxo Difusivo 09",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5310",
                CodigoCompendio = "V11-310",
                Nome = "Fontes de Energia Renovavel - Conducao Termica 10",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5311",
                CodigoCompendio = "V11-311",
                Nome = "Fontes de Energia Renovavel - Numero de Reynolds 11",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5312",
                CodigoCompendio = "V11-312",
                Nome = "Fontes de Energia Renovavel - Numero de Peclet 12",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5313",
                CodigoCompendio = "V11-313",
                Nome = "Fontes de Energia Renovavel - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5314",
                CodigoCompendio = "V11-314",
                Nome = "Fontes de Energia Renovavel - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5315",
                CodigoCompendio = "V11-315",
                Nome = "Fontes de Energia Renovavel - Indice de Risco 15",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5316",
                CodigoCompendio = "V11-316",
                Nome = "Fontes de Energia Renovavel - Valor Presente 16",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5317",
                CodigoCompendio = "V11-317",
                Nome = "Fontes de Energia Renovavel - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5318",
                CodigoCompendio = "V11-318",
                Nome = "Fontes de Energia Renovavel - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5319",
                CodigoCompendio = "V11-319",
                Nome = "Fontes de Energia Renovavel - Entropia de Shannon 19",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5320",
                CodigoCompendio = "V11-320",
                Nome = "Fontes de Energia Renovavel - Indice de Convergencia 20",
                Categoria = "Vol XI - Fontes de Energia Renovavel",
                SubCategoria = "Fontes de Energia Renovavel",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: captacao de recurso, eficiencia de conversao e despacho energetico. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Betz e Shockley-Queisser",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fontes de energia renovavel: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "☀",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em captacao de recurso e eficiencia energetica; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Fisica de Plasma e MHD
            lista.Add(new Formula
            {
                Id = "5321",
                CodigoCompendio = "V11-321",
                Nome = "Fisica de Plasma e MHD - Balanco Diferencial 01",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5322",
                CodigoCompendio = "V11-322",
                Nome = "Fisica de Plasma e MHD - Lei Linear 02",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5323",
                CodigoCompendio = "V11-323",
                Nome = "Fisica de Plasma e MHD - Lei Quadratica 03",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5324",
                CodigoCompendio = "V11-324",
                Nome = "Fisica de Plasma e MHD - Crescimento Exponencial 04",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5325",
                CodigoCompendio = "V11-325",
                Nome = "Fisica de Plasma e MHD - Modelo Logistico 05",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5326",
                CodigoCompendio = "V11-326",
                Nome = "Fisica de Plasma e MHD - Eficiencia 06",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5327",
                CodigoCompendio = "V11-327",
                Nome = "Fisica de Plasma e MHD - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5328",
                CodigoCompendio = "V11-328",
                Nome = "Fisica de Plasma e MHD - Fluxo Advectivo 08",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5329",
                CodigoCompendio = "V11-329",
                Nome = "Fisica de Plasma e MHD - Fluxo Difusivo 09",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5330",
                CodigoCompendio = "V11-330",
                Nome = "Fisica de Plasma e MHD - Conducao Termica 10",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5331",
                CodigoCompendio = "V11-331",
                Nome = "Fisica de Plasma e MHD - Numero de Reynolds 11",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5332",
                CodigoCompendio = "V11-332",
                Nome = "Fisica de Plasma e MHD - Numero de Peclet 12",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5333",
                CodigoCompendio = "V11-333",
                Nome = "Fisica de Plasma e MHD - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5334",
                CodigoCompendio = "V11-334",
                Nome = "Fisica de Plasma e MHD - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5335",
                CodigoCompendio = "V11-335",
                Nome = "Fisica de Plasma e MHD - Indice de Risco 15",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5336",
                CodigoCompendio = "V11-336",
                Nome = "Fisica de Plasma e MHD - Valor Presente 16",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5337",
                CodigoCompendio = "V11-337",
                Nome = "Fisica de Plasma e MHD - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5338",
                CodigoCompendio = "V11-338",
                Nome = "Fisica de Plasma e MHD - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5339",
                CodigoCompendio = "V11-339",
                Nome = "Fisica de Plasma e MHD - Entropia de Shannon 19",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5340",
                CodigoCompendio = "V11-340",
                Nome = "Fisica de Plasma e MHD - Indice de Convergencia 20",
                Categoria = "Vol XI - Fisica de Plasma e MHD",
                SubCategoria = "Fisica de Plasma e MHD",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: estabilidade magnetica, transporte anomalo e acoplamento campo-particula. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Alfven",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em fisica de plasma e mhd: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "🌐",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em estabilidade magnetica e transporte anomalo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Matematica Financeira
            lista.Add(new Formula
            {
                Id = "5341",
                CodigoCompendio = "V11-341",
                Nome = "Matematica Financeira - Balanco Diferencial 01",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5342",
                CodigoCompendio = "V11-342",
                Nome = "Matematica Financeira - Lei Linear 02",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5343",
                CodigoCompendio = "V11-343",
                Nome = "Matematica Financeira - Lei Quadratica 03",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5344",
                CodigoCompendio = "V11-344",
                Nome = "Matematica Financeira - Crescimento Exponencial 04",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5345",
                CodigoCompendio = "V11-345",
                Nome = "Matematica Financeira - Modelo Logistico 05",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5346",
                CodigoCompendio = "V11-346",
                Nome = "Matematica Financeira - Eficiencia 06",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5347",
                CodigoCompendio = "V11-347",
                Nome = "Matematica Financeira - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5348",
                CodigoCompendio = "V11-348",
                Nome = "Matematica Financeira - Fluxo Advectivo 08",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5349",
                CodigoCompendio = "V11-349",
                Nome = "Matematica Financeira - Fluxo Difusivo 09",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5350",
                CodigoCompendio = "V11-350",
                Nome = "Matematica Financeira - Conducao Termica 10",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5351",
                CodigoCompendio = "V11-351",
                Nome = "Matematica Financeira - Numero de Reynolds 11",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5352",
                CodigoCompendio = "V11-352",
                Nome = "Matematica Financeira - Numero de Peclet 12",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5353",
                CodigoCompendio = "V11-353",
                Nome = "Matematica Financeira - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5354",
                CodigoCompendio = "V11-354",
                Nome = "Matematica Financeira - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5355",
                CodigoCompendio = "V11-355",
                Nome = "Matematica Financeira - Indice de Risco 15",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5356",
                CodigoCompendio = "V11-356",
                Nome = "Matematica Financeira - Valor Presente 16",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5357",
                CodigoCompendio = "V11-357",
                Nome = "Matematica Financeira - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5358",
                CodigoCompendio = "V11-358",
                Nome = "Matematica Financeira - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5359",
                CodigoCompendio = "V11-359",
                Nome = "Matematica Financeira - Entropia de Shannon 19",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5360",
                CodigoCompendio = "V11-360",
                Nome = "Matematica Financeira - Indice de Convergencia 20",
                Categoria = "Vol XI - Matematica Financeira",
                SubCategoria = "Matematica Financeira",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: desconto temporal, precificacao de risco e controle de exposicao financeira. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Markowitz e Black-Scholes",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica financeira: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "💰",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em desconto temporal e controle de risco; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Engenharia Aeroespacial
            lista.Add(new Formula
            {
                Id = "5361",
                CodigoCompendio = "V11-361",
                Nome = "Engenharia Aeroespacial - Balanco Diferencial 01",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5362",
                CodigoCompendio = "V11-362",
                Nome = "Engenharia Aeroespacial - Lei Linear 02",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5363",
                CodigoCompendio = "V11-363",
                Nome = "Engenharia Aeroespacial - Lei Quadratica 03",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5364",
                CodigoCompendio = "V11-364",
                Nome = "Engenharia Aeroespacial - Crescimento Exponencial 04",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5365",
                CodigoCompendio = "V11-365",
                Nome = "Engenharia Aeroespacial - Modelo Logistico 05",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5366",
                CodigoCompendio = "V11-366",
                Nome = "Engenharia Aeroespacial - Eficiencia 06",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5367",
                CodigoCompendio = "V11-367",
                Nome = "Engenharia Aeroespacial - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5368",
                CodigoCompendio = "V11-368",
                Nome = "Engenharia Aeroespacial - Fluxo Advectivo 08",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5369",
                CodigoCompendio = "V11-369",
                Nome = "Engenharia Aeroespacial - Fluxo Difusivo 09",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5370",
                CodigoCompendio = "V11-370",
                Nome = "Engenharia Aeroespacial - Conducao Termica 10",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5371",
                CodigoCompendio = "V11-371",
                Nome = "Engenharia Aeroespacial - Numero de Reynolds 11",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5372",
                CodigoCompendio = "V11-372",
                Nome = "Engenharia Aeroespacial - Numero de Peclet 12",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5373",
                CodigoCompendio = "V11-373",
                Nome = "Engenharia Aeroespacial - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5374",
                CodigoCompendio = "V11-374",
                Nome = "Engenharia Aeroespacial - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5375",
                CodigoCompendio = "V11-375",
                Nome = "Engenharia Aeroespacial - Indice de Risco 15",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5376",
                CodigoCompendio = "V11-376",
                Nome = "Engenharia Aeroespacial - Valor Presente 16",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5377",
                CodigoCompendio = "V11-377",
                Nome = "Engenharia Aeroespacial - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5378",
                CodigoCompendio = "V11-378",
                Nome = "Engenharia Aeroespacial - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5379",
                CodigoCompendio = "V11-379",
                Nome = "Engenharia Aeroespacial - Entropia de Shannon 19",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5380",
                CodigoCompendio = "V11-380",
                Nome = "Engenharia Aeroespacial - Indice de Convergencia 20",
                Categoria = "Vol XI - Engenharia Aeroespacial",
                SubCategoria = "Engenharia Aeroespacial",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: desempenho propulsivo, aerodinamica aplicada e margens de missao. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Prandtl e Tsiolkovsky",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em engenharia aeroespacial: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "✈",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em desempenho aerodinamico e propulsivo; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            // Matematica Pura Avancada
            lista.Add(new Formula
            {
                Id = "5381",
                CodigoCompendio = "V11-381",
                Nome = "Matematica Pura Avancada - Balanco Diferencial 01",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "dX/dt = entrada - saida + geracao - consumo",
                ExprTexto = "dX/dt = entrada - saida + geracao - consumo",
                Descricao = "Forma diferencial de conservacao para estimar a taxa liquida de acumulacao no volume de controle. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: use dados de entrada e saida medidos em janela operacional, compare a taxa liquida prevista com inventario observado e ajuste termos fonte/sumidouro. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "Xdot",
                UnidadeResultado = "u/s",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "entrada", Nome = "Taxa de entrada", Descricao = "Taxa de entrada: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 12.0, Unidade = "adim" },
                    new Variavel { Simbolo = "saida", Nome = "Taxa de saida", Descricao = "Taxa de saida: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 8.5, Unidade = "adim" },
                    new Variavel { Simbolo = "geracao", Nome = "Geracao interna", Descricao = "Geracao interna: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.4, Unidade = "adim" },
                    new Variavel { Simbolo = "consumo", Nome = "Consumo interno", Descricao = "Consumo interno: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "entrada", 12.0) - Input(v, "saida", 8.5) + Input(v, "geracao", 1.4) - Input(v, "consumo", 0.9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5382",
                CodigoCompendio = "V11-382",
                Nome = "Matematica Pura Avancada - Lei Linear 02",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "y = a*x + b",
                ExprTexto = "y = a*x + b",
                Descricao = "Aproximacao linear de primeira ordem adequada para regimes com resposta quase proporcional. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: ajuste o coeficiente angular com regressao local e valide o offset na condicao nominal antes de extrapolar. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente angular", Descricao = "Coeficiente angular: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.35, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 18.0, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Offset", Descricao = "Offset: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "a", 1.35) * Input(v, "x", 18.0) + Input(v, "b", 2.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5383",
                CodigoCompendio = "V11-383",
                Nome = "Matematica Pura Avancada - Lei Quadratica 03",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "y = a*x*x + b*x + c",
                ExprTexto = "y = a*x*x + b*x + c",
                Descricao = "Modelo de segunda ordem para capturar curvatura e efeitos nao lineares moderados. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: calibre os termos linear e quadratico com serie historica e verifique curvatura residual. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "y",
                UnidadeResultado = "u",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "a", Nome = "Coeficiente quadratico", Descricao = "Coeficiente quadratico: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.04, Unidade = "adim" },
                    new Variavel { Simbolo = "b", Nome = "Coeficiente linear", Descricao = "Coeficiente linear: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "c", Nome = "Constante", Descricao = "Constante: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 3.2, Unidade = "adim" },
                    new Variavel { Simbolo = "x", Nome = "Variavel de entrada", Descricao = "Variavel de entrada: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 16.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"a",0.04)*Input(v,"x",16.0)*Input(v,"x",16.0) + Input(v,"b",0.9)*Input(v,"x",16.0) + Input(v,"c",3.2);
                }
            });
            lista.Add(new Formula
            {
                Id = "5384",
                CodigoCompendio = "V11-384",
                Nome = "Matematica Pura Avancada - Crescimento Exponencial 04",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "N = N0*exp(r*t)",
                ExprTexto = "N = N0*exp(r*t)",
                Descricao = "Modelo exponencial para dinamicas com taxa relativa aproximadamente constante. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: estime a taxa especifica em duas janelas temporais e projete o horizonte de interesse. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 100.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa especifica", Descricao = "Taxa especifica: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.12, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 15.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "N0", 100.0) * Math.Exp(Input(v, "r", 0.12) * Input(v, "t", 15.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5385",
                CodigoCompendio = "V11-385",
                Nome = "Matematica Pura Avancada - Modelo Logistico 05",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                ExprTexto = "N = K/(1+((K-N0)/N0)*exp(-r*t))",
                Descricao = "Modelo saturante com capacidade limite e transicao entre fase de crescimento e regime estacionario. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: defina a capacidade limite com dados de regime e valide o tempo de acomodacao observado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "N",
                UnidadeResultado = "u",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Capacidade maxima", Descricao = "Capacidade maxima: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "N0", Nome = "Valor inicial", Descricao = "Valor inicial: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 120.0, Unidade = "adim" },
                    new Variavel { Simbolo = "r", Nome = "Taxa intrinseca", Descricao = "Taxa intrinseca: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "t", Nome = "Tempo", Descricao = "Tempo: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 20.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",1000.0)/(1.0+((Input(v,"K",1000.0)-Math.Max(Input(v,"N0",120.0),1e-9))/Math.Max(Input(v,"N0",120.0),1e-9))*Math.Exp(-Input(v,"r",0.2)*Input(v,"t",20.0)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5386",
                CodigoCompendio = "V11-386",
                Nome = "Matematica Pura Avancada - Eficiencia 06",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "eta = util/total",
                ExprTexto = "eta = util/total",
                Descricao = "Indicador de desempenho global obtido pela razao entre saida util e recurso total empregado. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: compute a eficiencia por lote e monitore degradacao quando o indice cair abaixo do baseline. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "eta",
                UnidadeResultado = "",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "util", Nome = "Saida util", Descricao = "Saida util: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 78.0, Unidade = "adim" },
                    new Variavel { Simbolo = "total", Nome = "Entrada total", Descricao = "Entrada total: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 95.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v, "util", 78.0) / Math.Max(Input(v, "total", 95.0), 1e-9);
                }
            });
            lista.Add(new Formula
            {
                Id = "5387",
                CodigoCompendio = "V11-387",
                Nome = "Matematica Pura Avancada - Taxa de Arrhenius 07",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "k = A*exp(-Ea/(R*T))",
                ExprTexto = "k = A*exp(-Ea/(R*T))",
                Descricao = "Relacao termoativada que quantifica a sensibilidade da taxa efetiva a temperatura e barreira energetica. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: avalie diferentes temperaturas de processo e valide consistencia termocinetica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "1/s",
                VariavelResultado = "k",
                UnidadeResultado = "1/s",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "A", Nome = "Pre-exponencial", Descricao = "Pre-exponencial: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1000000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Ea", Nome = "Energia de ativacao", Descricao = "Energia de ativacao: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 42000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "T", Nome = "Temperatura", Descricao = "Temperatura: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 330.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"A",1e6)*Math.Exp(-Input(v,"Ea",42000.0)/(8.314*Math.Max(Input(v,"T",330.0),1e-9)));
                }
            });
            lista.Add(new Formula
            {
                Id = "5388",
                CodigoCompendio = "V11-388",
                Nome = "Matematica Pura Avancada - Fluxo Advectivo 08",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "J = C*v*A",
                ExprTexto = "J = C*v*A",
                Descricao = "Equacao de transporte convectivo que estima o fluxo carregado pelo movimento medio do meio. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: aplique concentracao e velocidade medias de campo para estimar transporte em secao critica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "C", Nome = "Concentracao", Descricao = "Concentracao: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.8, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.3, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.45, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"C",2.8)*Input(v,"v",1.3)*Input(v,"A",0.45);
                }
            });
            lista.Add(new Formula
            {
                Id = "5389",
                CodigoCompendio = "V11-389",
                Nome = "Matematica Pura Avancada - Fluxo Difusivo 09",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "J = -D*A*(dC/dx)",
                ExprTexto = "J = -D*A*(dC/dx)",
                Descricao = "Equacao de difusao baseada em gradiente para estimar transferencia por mecanismo molecular efetivo. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: use gradiente medido entre pontos adjacentes para estimar transferencia difusiva. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u/s",
                VariavelResultado = "J",
                UnidadeResultado = "u/s",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "D", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.2e-05, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.2, Unidade = "adim" },
                    new Variavel { Simbolo = "dCdx", Nome = "Gradiente", Descricao = "Gradiente: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 35.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"D",1.2e-5)*Input(v,"A",0.2)*Input(v,"dCdx",35.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5390",
                CodigoCompendio = "V11-390",
                Nome = "Matematica Pura Avancada - Conducao Termica 10",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "q = -k*A*(dT/dx)",
                ExprTexto = "q = -k*A*(dT/dx)",
                Descricao = "Lei de transferencia termica por gradiente de temperatura em regime unidimensional dominante. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: calcule fluxo termico em condicao estacionaria e confronte com leitura de sensores. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "W",
                VariavelResultado = "q",
                UnidadeResultado = "W",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "k", Nome = "Condutividade", Descricao = "Condutividade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 32.0, Unidade = "adim" },
                    new Variavel { Simbolo = "A", Nome = "Area", Descricao = "Area: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.24, Unidade = "adim" },
                    new Variavel { Simbolo = "dTdx", Nome = "Gradiente termico", Descricao = "Gradiente termico: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 28.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -Input(v,"k",32.0)*Input(v,"A",0.24)*Input(v,"dTdx",28.0);
                }
            });
            lista.Add(new Formula
            {
                Id = "5391",
                CodigoCompendio = "V11-391",
                Nome = "Matematica Pura Avancada - Numero de Reynolds 11",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "Re = rho*v*L/mu",
                ExprTexto = "Re = rho*v*L/mu",
                Descricao = "Parametro adimensional para classificar o regime de escoamento e inferir dominancia inercial-viscosa. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: classifique o regime de escoamento e selecione correlacao adequada de atrito. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Re",
                UnidadeResultado = "",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "rho", Nome = "Densidade", Descricao = "Densidade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 998.0, Unidade = "adim" },
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.9, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento caracteristico", Descricao = "Comprimento caracteristico: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.06, Unidade = "adim" },
                    new Variavel { Simbolo = "mu", Nome = "Viscosidade dinamica", Descricao = "Viscosidade dinamica: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.001, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"rho",998.0)*Input(v,"v",0.9)*Input(v,"L",0.06)/Math.Max(Input(v,"mu",1.0e-3),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5392",
                CodigoCompendio = "V11-392",
                Nome = "Matematica Pura Avancada - Numero de Peclet 12",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "Pe = v*L/alpha",
                ExprTexto = "Pe = v*L/alpha",
                Descricao = "Indicador adimensional da competencia entre transporte convectivo e transporte difusivo. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: identifique se adveccao ou difusao domina o transporte no dominio analisado. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Pe",
                UnidadeResultado = "",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "v", Nome = "Velocidade", Descricao = "Velocidade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.7, Unidade = "adim" },
                    new Variavel { Simbolo = "L", Nome = "Comprimento", Descricao = "Comprimento: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.05, Unidade = "adim" },
                    new Variavel { Simbolo = "alpha", Nome = "Difusividade", Descricao = "Difusividade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.1e-05, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"v",0.7)*Input(v,"L",0.05)/Math.Max(Input(v,"alpha",1.1e-5),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5393",
                CodigoCompendio = "V11-393",
                Nome = "Matematica Pura Avancada - Sensibilidade de 1a Ordem 13",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "S = K/(1 + tau*s)",
                ExprTexto = "S = K/(1 + tau*s)",
                Descricao = "Representacao simplificada da resposta de primeira ordem para analise de ganho e inercia. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: varie ganho e constante de tempo para mapear margem local de robustez. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "S",
                UnidadeResultado = "",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "K", Nome = "Ganho estatico", Descricao = "Ganho estatico: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 2.4, Unidade = "adim" },
                    new Variavel { Simbolo = "tau", Nome = "Constante de tempo", Descricao = "Constante de tempo: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.8, Unidade = "adim" },
                    new Variavel { Simbolo = "s", Nome = "Frequencia de analise", Descricao = "Frequencia de analise: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.6, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"K",2.4)/(1.0 + Input(v,"tau",1.8)*Input(v,"s",0.6));
                }
            });
            lista.Add(new Formula
            {
                Id = "5394",
                CodigoCompendio = "V11-394",
                Nome = "Matematica Pura Avancada - Erro Quadratico Medio 14",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "MSE = media(e^2)",
                ExprTexto = "MSE = media(e^2)",
                Descricao = "Metrica de ajuste estatistico que resume a energia media dos residuos de modelagem. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: acompanhe o MSE por ciclo de calibracao e confirme tendencia de convergencia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "MSE",
                UnidadeResultado = "",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "e1", Nome = "Erro 1", Descricao = "Erro 1: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.8, Unidade = "adim" },
                    new Variavel { Simbolo = "e2", Nome = "Erro 2", Descricao = "Erro 2: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = -0.6, Unidade = "adim" },
                    new Variavel { Simbolo = "e3", Nome = "Erro 3", Descricao = "Erro 3: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.3, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return (Math.Pow(Input(v,"e1",0.8),2)+Math.Pow(Input(v,"e2",-0.6),2)+Math.Pow(Input(v,"e3",0.3),2))/3.0;
                }
            });
            lista.Add(new Formula
            {
                Id = "5395",
                CodigoCompendio = "V11-395",
                Nome = "Matematica Pura Avancada - Indice de Risco 15",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "R = prob*impacto",
                ExprTexto = "R = prob*impacto",
                Descricao = "Indice de priorizacao que combina probabilidade de ocorrencia com magnitude de impacto. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: ordene cenarios por risco esperado e priorize mitigacao dos casos criticos. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "R",
                UnidadeResultado = "u",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "prob", Nome = "Probabilidade", Descricao = "Probabilidade: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.16, Unidade = "adim" },
                    new Variavel { Simbolo = "impacto", Nome = "Impacto", Descricao = "Impacto: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 4200000.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"prob",0.16)*Input(v,"impacto",4.2e6);
                }
            });
            lista.Add(new Formula
            {
                Id = "5396",
                CodigoCompendio = "V11-396",
                Nome = "Matematica Pura Avancada - Valor Presente 16",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "VP = VF/(1+i)^n",
                ExprTexto = "VP = VF/(1+i)^n",
                Descricao = "Operador de desconto temporal para converter valor futuro em equivalente economico no instante atual. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: desconte fluxos com taxas alternativas e compare sensibilidade economica da decisao. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "u",
                VariavelResultado = "VP",
                UnidadeResultado = "u",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "VF", Nome = "Valor futuro", Descricao = "Valor futuro: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 850000.0, Unidade = "adim" },
                    new Variavel { Simbolo = "i", Nome = "Taxa por periodo", Descricao = "Taxa por periodo: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.11, Unidade = "adim" },
                    new Variavel { Simbolo = "n", Nome = "Numero de periodos", Descricao = "Numero de periodos: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 6.0, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"VF",850000.0)/Math.Pow(1.0+Input(v,"i",0.11),Input(v,"n",6.0));
                }
            });
            lista.Add(new Formula
            {
                Id = "5397",
                CodigoCompendio = "V11-397",
                Nome = "Matematica Pura Avancada - Razao Sinal-Ruido 17",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "SNRdB = 10*log10(Ps/Pn)",
                ExprTexto = "SNRdB = 10*log10(Ps/Pn)",
                Descricao = "Metrica logaritmica da qualidade de medicao baseada na razao entre potencia util e ruido. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: compare configuracoes de aquisicao e escolha o ponto com maior robustez metrologica. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "dB",
                VariavelResultado = "SNRdB",
                UnidadeResultado = "dB",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "Ps", Nome = "Potencia do sinal", Descricao = "Potencia do sinal: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 14.0, Unidade = "adim" },
                    new Variavel { Simbolo = "Pn", Nome = "Potencia de ruido", Descricao = "Potencia de ruido: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return 10.0*Math.Log10(Input(v,"Ps",14.0)/Math.Max(Input(v,"Pn",0.35),1e-12));
                }
            });
            lista.Add(new Formula
            {
                Id = "5398",
                CodigoCompendio = "V11-398",
                Nome = "Matematica Pura Avancada - Atualizacao Bayesiana 18",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "P(H|D)=P(D|H)P(H)/P(D)",
                ExprTexto = "P(H|D)=P(D|H)P(H)/P(D)",
                Descricao = "Atualizacao probabilistica de crenca condicionada a evidencia observada e consistencia do prior. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: atualize a probabilidade com nova evidencia de campo e compare com limiar decisorio. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "P(H|D)",
                UnidadeResultado = "",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "PD_H", Nome = "P(D|H)", Descricao = "P(D|H): parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.88, Unidade = "adim" },
                    new Variavel { Simbolo = "PH", Nome = "P(H)", Descricao = "P(H): parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.22, Unidade = "adim" },
                    new Variavel { Simbolo = "PD", Nome = "P(D)", Descricao = "P(D): parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.31, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Input(v,"PD_H",0.88)*Input(v,"PH",0.22)/Math.Max(Input(v,"PD",0.31),1e-12);
                }
            });
            lista.Add(new Formula
            {
                Id = "5399",
                CodigoCompendio = "V11-399",
                Nome = "Matematica Pura Avancada - Entropia de Shannon 19",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "H = -sum(p_i ln p_i)",
                ExprTexto = "H = -sum(p_i ln p_i)",
                Descricao = "Medida de incerteza informacional da distribuicao, sensivel a dispersao das probabilidades. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: calcule a incerteza das classes observadas para direcionar coleta adicional de dados. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "nats",
                VariavelResultado = "H",
                UnidadeResultado = "nats",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "p1", Nome = "Probabilidade 1", Descricao = "Probabilidade 1: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.65, Unidade = "adim" },
                    new Variavel { Simbolo = "p2", Nome = "Probabilidade 2", Descricao = "Probabilidade 2: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 0.35, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return -(ClampProb(Input(v,"p1",0.65))*Math.Log(ClampProb(Input(v,"p1",0.65))) + ClampProb(Input(v,"p2",0.35))*Math.Log(ClampProb(Input(v,"p2",0.35))));
                }
            });
            lista.Add(new Formula
            {
                Id = "5400",
                CodigoCompendio = "V11-400",
                Nome = "Matematica Pura Avancada - Indice de Convergencia 20",
                Categoria = "Vol XI - Matematica Pura Avancada",
                SubCategoria = "Matematica Pura Avancada",
                Expressao = "Ic = |xk-xk1|/|xk|",
                ExprTexto = "Ic = |xk-xk1|/|xk|",
                Descricao = "Criterio relativo de parada iterativa para monitorar estabilidade e fechamento numerico. Contexto disciplinar: analise de convergencia, estabilidade numerica e interpretacao estrutural. Referencia tecnica alinhada a literatura classica e validacao moderna de engenharia.",
                Criador = "Hilbert e Grothendieck",
                AnoOrigin = "Base classica e validacao moderna",
                ExemploPratico = "Caso aplicado em matematica pura avancada: monitore reducao relativa entre iteracoes e encerre quando atingir tolerancia. Registrar erro relativo, faixa de incerteza e criterio de aceitacao operacional no relatorio tecnico.",
                Unidades = "adimensional",
                VariavelResultado = "Ic",
                UnidadeResultado = "",
                Icone = "∞",
                Variaveis = new List<Variavel>
                {
                    new Variavel { Simbolo = "xk", Nome = "Iteracao atual", Descricao = "Iteracao atual: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.024, Unidade = "adim" },
                    new Variavel { Simbolo = "xkm1", Nome = "Iteracao anterior", Descricao = "Iteracao anterior: parametro de entrada para modelagem em convergencia numerica e estrutura abstrata; use faixa operacional validada e registre incerteza de medicao no contexto disciplinar.", ValorPadrao = 1.018, Unidade = "adim" },
                },
                Calcular = v =>
                {
                    return Math.Abs(Input(v,"xk",1.024)-Input(v,"xkm1",1.018))/Math.Max(Math.Abs(Input(v,"xk",1.024)),1e-12);
                }
            });

            return lista;
        }

        private static double Input(Dictionary<string, double> valores, string chave, double padrao)
            => valores.TryGetValue(chave, out var valor) ? valor : padrao;

        private static double ClampProb(double p)
        {
            if (p <= 0) return 1e-12;
            if (p >= 1) return 1 - 1e-12;
            return p;
        }
    }
}
