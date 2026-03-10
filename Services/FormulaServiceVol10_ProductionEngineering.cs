using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    /// <summary>
    /// VOLUME X - PARTE X
    /// ENGENHARIA DE PRODUÇÃO, LOGÍSTICA E PESQUISA OPERACIONAL
    /// Fórmulas V10-181 a V10-200 (20 fórmulas)
    /// </summary>
    public partial class FormulaService
    {
        private void AdicionarFormulasVol10_ProductionEngineering()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "3769",
                    CodigoCompendio = "V10-181",
                    Nome = "Lote Econômico de Compra (EOQ)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Gestão de Estoques",
                    Expressao = @"Q* = √(2DS/H)",
                    Descricao = "Quantidade ótima de pedido. D: demanda anual. S: custo pedido. H: custo manutenção/unidade/ano. Minimiza custo total.",
                    ExemploPratico = "D=10000 un/ano, S=$50/pedido, H=$5/un/ano: Q*=447. Número pedidos=D/Q*≈22/ano.",
                    Criador = "Wilson (1913, formulação original do EOQ)",
                    AnoOrigin = "1913",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Demanda D (un/ano)", Simbolo = "D", Unidade = "un/ano", ValorPadrao = 10000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Custo pedido S ($)", Simbolo = "S", Unidade = "$", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Custo manutenção H ($/un/ano)", Simbolo = "H", Unidade = "$/un/ano", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double D = inputs["Demanda D (un/ano)"];
                        double S = inputs["Custo pedido S ($)"];
                        double H = inputs["Custo manutenção H ($/un/ano)"];
                        
                        if (H == 0) return 0;
                        double Q_star = Math.Sqrt(2 * D * S / H);
                        return Q_star;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-182: Eficiência Global de Equipamento (OEE)
                new Formula
                {
                    Id = "3770",
                    CodigoCompendio = "V10-182",
                    Nome = "Overall Equipment Effectiveness (OEE)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "TPM — Total Productive Maintenance",
                    Expressao = @"OEE = Disponibilidade × Performance × Qualidade",
                    Descricao = "OEE: métrica chave TPM. Disp=tempo operando/tempo planejado. Perf=produção real/ideal. Qual=boas/total. World-class: OEE>85%.",
                    ExemploPratico = "Linha produção: 8h planejadas, 1h parada (87.5% disp), perf=90% (slow cycles), 5% defeitos (95% qual)→OEE=87.5%×90%×95%≈75% (bom, não world-class).",
                    Criador = "Nakajima (1988, TPM — Total Productive Maintenance)",
                    AnoOrigin = "1988",
                    VariavelResultado = "OEE",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tempo operando (h)", Simbolo = "op", Unidade = "h", ValorPadrao = 7, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tempo planejado (h)", Simbolo = "plan", Unidade = "h", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Produção real", Simbolo = "real", Unidade = "un", ValorPadrao = 900, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Produção ideal", Simbolo = "ideal", Unidade = "un", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Boas", Simbolo = "boas", Unidade = "un", ValorPadrao = 855, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Total produzido", Simbolo = "total", Unidade = "un", ValorPadrao = 900, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double op = inputs["Tempo operando (h)"];
                        double plan = inputs["Tempo planejado (h)"];
                        double real = inputs["Produção real"];
                        double ideal = inputs["Produção ideal"];
                        double boas = inputs["Boas"];
                        double total = inputs["Total produzido"];
                        
                        double disp = (plan > 0) ? op / plan : 0;
                        double perf = (ideal > 0) ? real / ideal : 0;
                        double qual = (total > 0) ? boas / total : 0;
                        
                        double OEE = disp * perf * qual * 100;
                        return OEE;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-183: Takt Time (Produção Lean)
                new Formula
                {
                    Id = "3771",
                    CodigoCompendio = "V10-183",
                    Nome = "Takt Time (Ritmo Cliente)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Lean Manufacturing",
                    Expressao = @"Takt = Tempo disponível/Demanda cliente",
                    Descricao = "Ritmo produção = ritmo demanda. Takt: alemão 'batuta'. Cycle time<Takt: capacidade OK. Lead time: total início-fim.",
                    ExemploPratico = "8h turno (480min), 30min paradas→450min disp. Demanda=100 un/dia→Takt=4.5min/un. Estação 5min: gargalo (cycle>takt).",
                    Criador = "Toyota Production System (Ohno, anos 1950s-1970s); termo alemão adotado",
                    AnoOrigin = "1950",
                    VariavelResultado = "Takt",
                    UnidadeResultado = "min/un",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tempo disponível (min)", Simbolo = "T", Unidade = "min", ValorPadrao = 450, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Demanda (un/dia)", Simbolo = "D", Unidade = "un", ValorPadrao = 100, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double T = inputs["Tempo disponível (min)"];
                        double D = inputs["Demanda (un/dia)"];
                        
                        if (D == 0) return 0;
                        double takt = T / D;
                        return takt;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-184: Capacidade de Processo (Cp, Cpk)
                new Formula
                {
                    Id = "3772",
                    CodigoCompendio = "V10-184",
                    Nome = "Índice Capacidade Processo Cpk",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Six Sigma",
                    Expressao = @"Cpk = min[(USL−μ)/(3σ), (μ−LSL)/(3σ)]",
                    Descricao = "Cpk: capacidade real (considera centramento). Cp=(USL−LSL)/(6σ): potencial. Cpk≥1.33: aceitável. Cpk≥1.67: bom. Six Sigma: Cp=2.",
                    ExemploPratico = "Tolerância: 100±5mm (LSL=95, USL=105). μ=101mm, σ=1.5mm→Cpk=min[(105−101)/(3·1.5), (101−95)/(3·1.5)]=min[0.89, 1.33]=0.89 (insuficiente, ajustar centramento).",
                    Criador = "Juran (anos 1960s, conceito capacidade); Motorola (1986, Six Sigma, Cpk)",
                    AnoOrigin = "1986",
                    VariavelResultado = "Cpk",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "USL (limite superior)", Simbolo = "USL", Unidade = "mm", ValorPadrao = 105, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "LSL (limite inferior)", Simbolo = "LSL", Unidade = "mm", ValorPadrao = 95, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Média μ", Simbolo = "mu", Unidade = "mm", ValorPadrao = 101, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Desvio σ", Simbolo = "sigma", Unidade = "mm", ValorPadrao = 1.5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double USL = inputs["USL (limite superior)"];
                        double LSL = inputs["LSL (limite inferior)"];
                        double mu = inputs["Média μ"];
                        double sigma = inputs["Desvio σ"];
                        
                        if (sigma == 0) return 0;
                        
                        double Cpu = (USL - mu) / (3 * sigma);
                        double Cpl = (mu - LSL) / (3 * sigma);
                        double Cpk = Math.Min(Cpu, Cpl);
                        
                        return Cpk;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-185: Curva ABC (Pareto)
                new Formula
                {
                    Id = "3773",
                    CodigoCompendio = "V10-185",
                    Nome = "Análise ABC (Curva de Pareto)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Gestão de Estoques",
                    Expressao = @"A: 80% valor, 20% itens; B: 15% valor, 30% itens; C: 5% valor, 50% itens",
                    Descricao = "Priorização: foco em itens críticos. Classe A: controle rigoroso. C: revisão periódica. Lei Pareto: 80/20.",
                    ExemploPratico = "1000 SKUs: 200 (classe A, 80% faturamento)→contar diário, EOQ otimizado. 500 (classe C, 5%)→revisão trimestral, estoque segurança alto.",
                    Criador = "Pareto (1896, distribuição riqueza); aplicado estoque (Dickie 1951, GE)",
                    AnoOrigin = "1951",
                    VariavelResultado = "percentil_80",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Num itens total", Simbolo = "N", Unidade = "itens", ValorPadrao = 1000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double N = inputs["Num itens total"];
                        
                        // Classe A: ~20% items, 80% value
                        double N_A = N * 0.20;
                        
                        return N_A;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-186: Ponto de Pedido (Reorder Point)
                new Formula
                {
                    Id = "3774",
                    CodigoCompendio = "V10-186",
                    Nome = "Ponto de Pedido (Reorder Point)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Gestão de Estoques",
                    Expressao = @"ROP = d·L + SS",
                    Descricao = "d: demanda média/dia. L: lead time (dias). SS: estoque segurança. SS=z·σ_L, z: service level (ex: 95%→z=1.65).",
                    ExemploPratico = "d=50 un/dia, L=10 dias, σ_d=10→σ_L=10·√10≈31.6. z=1.65→SS=52. ROP=50·10+52=552 un. Pedido com estoque≤552.",
                    Criador = "Conceito clássico gestão estoques (anos 1950s)",
                    AnoOrigin = "1950",
                    VariavelResultado = "ROP",
                    UnidadeResultado = "un",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Demanda diária d", Simbolo = "d", Unidade = "un/dia", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Lead time L (dias)", Simbolo = "L", Unidade = "dias", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "σ_d desvio demanda", Simbolo = "sigma_d", Unidade = "un", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "z service level", Simbolo = "z", Unidade = "", ValorPadrao = 1.65, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double d = inputs["Demanda diária d"];
                        double L = inputs["Lead time L (dias)"];
                        double sigma_d = inputs["σ_d desvio demanda"];
                        double z = inputs["z service level"];
                        
                        double sigma_L = sigma_d * Math.Sqrt(L);
                        double SS = z * sigma_L;
                        double ROP = d * L + SS;
                        
                        return ROP;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-187: Taxa de Defeitos (PPM)
                new Formula
                {
                    Id = "3775",
                    CodigoCompendio = "V10-187",
                    Nome = "Defeitos por Milhão (PPM)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Controle de Qualidade",
                    Expressao = @"PPM = (Defeitos/Total)×10⁶",
                    Descricao = "Partes Por Milhão. Six Sigma: 3.4 PPM (~99.99966% bons). 3σ: 66807 PPM. DPMO: Defects Per Million Opportunities.",
                    ExemploPratico = "Produção 1M peças, 100 defeitos→100 PPM (99.99%). Automotive: target <50 PPM. Six Sigma assume shift ±1.5σ→3.4 PPM.",
                    Criador = "Motorola (1986, Six Sigma); métrica PPM padrão ISO/TS 16949",
                    AnoOrigin = "1986",
                    VariavelResultado = "PPM",
                    UnidadeResultado = "PPM",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Defeitos", Simbolo = "D", Unidade = "un", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Total produzido", Simbolo = "N", Unidade = "un", ValorPadrao = 1e6, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double D = inputs["Defeitos"];
                        double N = inputs["Total produzido"];
                        
                        if (N == 0) return 0;
                        double PPM = (D / N) * 1e6;
                        return PPM;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-188: Tempo de Ciclo vs Lead Time
                new Formula
                {
                    Id = "3776",
                    CodigoCompendio = "V10-188",
                    Nome = "Lead Time vs Cycle Time",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Métricas de Fluxo",
                    Expressao = @"Lead Time = Σ(Processing + Wait); Cycle=Processing only",
                    Descricao = "Lead Time: total cliente. Cycle Time: tempo valor agregado. Eficiência=Cycle/Lead. Lean objetivo: reduzir wait (muda: waste).",
                    ExemploPratico = "Peça: 10min processamento (cycle), 5h fila→Lead=5h10min. Eficiência=10/310≈3% (97% waiting!). Kaizen: reduzir espera.",
                    Criador = "Lean Manufacturing (Toyota, Ohno 1950s-1970s)",
                    AnoOrigin = "1950",
                    VariavelResultado = "Eficiência",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Cycle time (min)", Simbolo = "cycle", Unidade = "min", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Lead time (min)", Simbolo = "lead", Unidade = "min", ValorPadrao = 310, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double cycle = inputs["Cycle time (min)"];
                        double lead = inputs["Lead time (min)"];
                        
                        if (lead == 0) return 0;
                        double eficiencia = (cycle / lead) * 100;
                        return eficiencia;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-189: Índice de Produtividade
                new Formula
                {
                    Id = "3777",
                    CodigoCompendio = "V10-189",
                    Nome = "Produtividade do Trabalho",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Indicadores de Desempenho",
                    Expressao = @"Produtividade = Output/Input",
                    Descricao = "Output: produção (unidades, $). Input: horas-homem, máquina. Multifator: output/(trabalho+capital+material).",
                    ExemploPratico = "Fábrica: 10000 un/mês, 400 hh/mês→25 un/hh. Automação: +50%→37.5 un/hh. Setor: compare benchmarks (Brasil ~30% USA).",
                    Criador = "Conceito econômico clássico (Adam Smith 1776, divisão trabalho)",
                    AnoOrigin = "1776",
                    VariavelResultado = "Produtividade",
                    UnidadeResultado = "un/hh",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Output (un)", Simbolo = "output", Unidade = "un", ValorPadrao = 10000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Input (hh)", Simbolo = "input", Unidade = "hh", ValorPadrao = 400, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double output = inputs["Output (un)"];
                        double input = inputs["Input (hh)"];
                        
                        if (input == 0) return 0;
                        double produtividade = output / input;
                        return produtividade;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-190: SMED (Single-Minute Exchange of Die)
                new Formula
                {
                    Id = "3778",
                    CodigoCompendio = "V10-190",
                    Nome = "SMED — Redução Setup",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Lean Manufacturing",
                    Expressao = @"Target: Setup < 10 min (single-digit)",
                    Descricao = "Separar setup interno (máquina parada) vs externo (preparar/fora). Converter interno→externo. Quick changeover: flexibilidade.",
                    ExemploPratico = "Troca molde: 4h inicial→SMED: 1h (externo: pré-aquecer, ferramentas prontas). F1 pit stop: 2s (SMED extremo). Lotes menores viáveis.",
                    Criador = "Shingo (Toyota, anos 1950s-1970s, livro 1985)",
                    AnoOrigin = "1985",
                    VariavelResultado = "Setup_reduzido",
                    UnidadeResultado = "min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Setup inicial (min)", Simbolo = "inicial", Unidade = "min", ValorPadrao = 240, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "% redução SMED", Simbolo = "reducao_pct", Unidade = "%", ValorPadrao = 75, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double inicial = inputs["Setup inicial (min)"];
                        double reducao_pct = inputs["% redução SMED"];
                        
                        double setup_reduzido = inicial * (1 - reducao_pct / 100);
                        return setup_reduzido;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-191: Teoria das Restrições (TOC) — Gargalo
                new Formula
                {
                    Id = "3779",
                    CodigoCompendio = "V10-191",
                    Nome = "Theory of Constraints — Throughput",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "TOC",
                    Expressao = @"Throughput sistema = Capacidade gargalo",
                    Descricao = "Goldratt: identificar constraint (bottleneck). Explorar: maximizar uso. Subordinar: ajustar demais ao bottleneck. Elevar: investir se necessário.",
                    ExemploPratico = "Linha 5 estações: 10, 12, 8, 11, 9 un/h→gargalo Estação 3 (8 un/h). Throughput max=8 un/h. Melhorar Estação 1: sem efeito!",
                    Criador = "Goldratt (1984, The Goal — romance sobre TOC)",
                    AnoOrigin = "1984",
                    VariavelResultado = "Throughput",
                    UnidadeResultado = "un/h",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Estação 1 (un/h)", Simbolo = "e1", Unidade = "un/h", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Estação 2 (un/h)", Simbolo = "e2", Unidade = "un/h", ValorPadrao = 12, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Estação 3 (un/h)", Simbolo = "e3", Unidade = "un/h", ValorPadrao = 8, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Estação 4 (un/h)", Simbolo = "e4", Unidade = "un/h", ValorPadrao = 11, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Estação 5 (un/h)", Simbolo = "e5", Unidade = "un/h", ValorPadrao = 9, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double e1 = inputs["Estação 1 (un/h)"];
                        double e2 = inputs["Estação 2 (un/h)"];
                        double e3 = inputs["Estação 3 (un/h)"];
                        double e4 = inputs["Estação 4 (un/h)"];
                        double e5 = inputs["Estação 5 (un/h)"];
                        
                        double throughput = Math.Min(e1, Math.Min(e2, Math.Min(e3, Math.Min(e4, e5))));
                        return throughput;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-192: Custo de Qualidade (COQ)
                new Formula
                {
                    Id = "3780",
                    CodigoCompendio = "V10-192",
                    Nome = "Cost of Quality (COQ)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Gestão da Qualidade",
                    Expressao = @"COQ = Prevenção + Avaliação + Falhas (Internas + Externas)",
                    Descricao = "Prevenção: treinamento, processo. Avaliação: inspeção, testes. Falhas internas: retrabalho, sucata. Externas: garantia, recalls, perda cliente.",
                    ExemploPratico = "Típico: COQ=10-30% vendas. Ideal: prevenção>avaliação>falhas. Falha externa>10×falha interna (custo reputação). Poka-yoke: prevenção design.",
                    Criador = "Juran (1951, Quality Control Handbook); Feigenbaum (1956, Total Quality Control)",
                    AnoOrigin = "1951",
                    VariavelResultado = "COQ_total",
                    UnidadeResultado = "$",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Prevenção ($)", Simbolo = "prev", Unidade = "$", ValorPadrao = 50000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Avaliação ($)", Simbolo = "aval", Unidade = "$", ValorPadrao = 30000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Falhas internas ($)", Simbolo = "fint", Unidade = "$", ValorPadrao = 70000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Falhas externas ($)", Simbolo = "fext", Unidade = "$", ValorPadrao = 100000, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double prev = inputs["Prevenção ($)"];
                        double aval = inputs["Avaliação ($)"];
                        double fint = inputs["Falhas internas ($)"];
                        double fext = inputs["Falhas externas ($)"];
                        
                        double COQ = prev + aval + fint + fext;
                        return COQ;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-193: Ponto de Equilíbrio (Break-Even)
                new Formula
                {
                    Id = "3781",
                    CodigoCompendio = "V10-193",
                    Nome = "Ponto de Equilíbrio (Break-Even Point)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Análise Econômica",
                    Expressao = @"Q_BE = CF/(P − CV)",
                    Descricao = "CF: custo fixo. P: preço venda. CV: custo variável/un. Margem contribuição: P−CV. Acima Q_BE: lucro. Abaixo: prejuízo.",
                    ExemploPratico = "Produto: P=$50, CV=$30, CF=$100k/mês→Q_BE=100k/(50−30)=5000 un/mês. Venda 6000→lucro=$20k. Venda 4000→prejuízo=$20k.",
                    Criador = "Conceito contabilidade gerencial clássico (anos 1920s-1930s)",
                    AnoOrigin = "1920",
                    VariavelResultado = "Q_BE",
                    UnidadeResultado = "un",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Custo fixo CF ($)", Simbolo = "CF", Unidade = "$", ValorPadrao = 100000, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Preço P ($)", Simbolo = "P", Unidade = "$", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Custo variável CV ($)", Simbolo = "CV", Unidade = "$", ValorPadrao = 30, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double CF = inputs["Custo fixo CF ($)"];
                        double P = inputs["Preço P ($)"];
                        double CV = inputs["Custo variável CV ($)"];
                        
                        double mc = P - CV;
                        if (mc <= 0) return double.PositiveInfinity;
                        
                        double Q_BE = CF / mc;
                        return Q_BE;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-194: Tempo Padrão de Operação
                new Formula
                {
                    Id = "3782",
                    CodigoCompendio = "V10-194",
                    Nome = "Tempo Padrão (Standard Time)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Estudo de Tempos",
                    Expressao = @"TS = TN × FR × (1 + TL)",
                    Descricao = "TN: tempo normal (observado). FR: fator ritmo (100%=normal). TL: tolerâncias (fadiga, necessidades, delays). MTM: tempos pré-determinados.",
                    ExemploPratico = "Operação: TN=10min, trabalhador rápido FR=110%→10·1.1=11min. Tolerância 15% (fadiga)→TS=11·1.15=12.65min. Base custeio, balanceamento linha.",
                    Criador = "Taylor (1911, Scientific Management, cronômetro); Gilbreth (therbligs); Maynard (1948, MTM)",
                    AnoOrigin = "1911",
                    VariavelResultado = "TS",
                    UnidadeResultado = "min",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Tempo normal TN (min)", Simbolo = "TN", Unidade = "min", ValorPadrao = 10, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Fator ritmo FR (%)", Simbolo = "FR", Unidade = "%", ValorPadrao = 110, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Tolerância TL (%)", Simbolo = "TL", Unidade = "%", ValorPadrao = 15, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double TN = inputs["Tempo normal TN (min)"];
                        double FR = inputs["Fator ritmo FR (%)"] / 100;
                        double TL = inputs["Tolerância TL (%)"] / 100;
                        
                        double TS = TN * FR * (1 + TL);
                        return TS;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-195: Simulação Monte Carlo (Estoques)
                new Formula
                {
                    Id = "3783",
                    CodigoCompendio = "V10-195",
                    Nome = "Simulação Monte Carlo — Nível de Serviço",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Análise de Risco",
                    Expressao = @"Service Level = P(Demand ≤ Stock)",
                    Descricao = "MC: simular N cenários demanda. Histograma: P(stockout). Complexo para analítico: use simulação. Crystal Ball, @Risk.",
                    ExemploPratico = "Demanda ~N(100,20). Estoque=130→SL=93.3% (analítico). MC: 10k simulações→SL_empirico≈93.2%. Demanda não-normal: MC essencial.",
                    Criador = "Von Neumann-Ulam (1940s, Manhattan Project); finanças/OR (anos 1970s)",
                    AnoOrigin = "1940",
                    VariavelResultado = "SL_estimado",
                    UnidadeResultado = "%",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Demanda média μ", Simbolo = "mu", Unidade = "un", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Desvio σ", Simbolo = "sigma", Unidade = "un", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Estoque", Simbolo = "estoque", Unidade = "un", ValorPadrao = 130, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double mu = inputs["Demanda média μ"];
                        double sigma = inputs["Desvio σ"];
                        double estoque = inputs["Estoque"];
                        
                        // Gaussian approximation
                        double z = (estoque - mu) / sigma;
                        
                        // Approximate CDF (service level)
                        double SL_pct = 50 * (1 + Math.Sign(z) * Math.Sqrt(1 - Math.Exp(-2 * z * z / Math.PI)));
                        
                        return SL_pct;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-196: Análise de Envoltória de Dados (DEA)
                new Formula
                {
                    Id = "3784",
                    CodigoCompendio = "V10-196",
                    Nome = "Data Envelopment Analysis (DEA)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Benchmarking",
                    Expressao = @"Eficiência = Σ(u_i·output_i)/Σ(v_j·input_j)",
                    Descricao = "Linear programming: compare DMUs (Decision Making Units). Fronteira eficiência: score=1. Ineficientes: <1. CCR (constant returns), BCC (variable returns).",
                    ExemploPratico = "5 hospitais: inputs (médicos, leitos), outputs (cirurgias, consultas). Hospital A: efic=0.85→pode reduzir 15% inputs ou aumentar outputs. Best-practice frontier.",
                    Criador = "Charnes-Cooper-Rhodes (1978, CCR model); Banker-Charnes-Cooper (1984, BCC)",
                    AnoOrigin = "1978",
                    VariavelResultado = "Eficiência",
                    UnidadeResultado = "",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "Output ponderado", Simbolo = "output", Unidade = "", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Input ponderado", Simbolo = "input", Unidade = "", ValorPadrao = 120, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double output = inputs["Output ponderado"];
                        double input = inputs["Input ponderado"];
                        
                        if (input == 0) return 0;
                        double eficiencia = output / input;
                        return eficiencia;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-197: Modelo de Filas M/M/1
                new Formula
                {
                    Id = "3785",
                    CodigoCompendio = "V10-197",
                    Nome = "Teoria de Filas M/M/1",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Pesquisa Operacional",
                    Expressao = @"L = ρ/(1−ρ); ρ=λ/μ (utilização)",
                    Descricao = "λ: arrival rate. μ: service rate. L: comprimento médio fila. W=L/λ: tempo espera. M/M/1: Markovian (Poisson/exponencial).",
                    ExemploPratico = "Caixa banco: λ=50 clientes/h, μ=60/h→ρ=0.83, L=5 clientes, W=6min. ρ→1: fila explode! M/M/c: c servidores→Little's Law.",
                    Criador = "Erlang (1909, telefonia); Kendall (1953, notação A/B/c)",
                    AnoOrigin = "1909",
                    VariavelResultado = "L",
                    UnidadeResultado = "clientes",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "λ arrival (clientes/h)", Simbolo = "lambda", Unidade = "clientes/h", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "μ service (clientes/h)", Simbolo = "mu", Unidade = "clientes/h", ValorPadrao = 60, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double lambda = inputs["λ arrival (clientes/h)"];
                        double mu = inputs["μ service (clientes/h)"];
                        
                        if (lambda >= mu) return double.PositiveInfinity; // unstable
                        
                        double rho = lambda / mu;
                        double L = rho / (1 - rho);
                        return L;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-198: Programação Linear — Simplex
                new Formula
                {
                    Id = "3786",
                    CodigoCompendio = "V10-198",
                    Nome = "Programação Linear (Simplex)",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Otimização",
                    Expressao = @"max z = Σ(c_j·x_j); s.t. Σ(a_ij·x_j) ≤ b_i",
                    Descricao = "Otimizar função linear, restrições lineares. Simplex: pivoteia vértices do poliedro viável. Solver Excel, CPLEX, Gurobi.",
                    ExemploPratico = "Produção: max z=50x₁+40x₂ (lucro). Restrições: 2x₁+x₂≤100 (máquina A), x₁+2x₂≤80 (B), x≥0. Solução: x₁=40, x₂=20, z=$2800.",
                    Criador = "Dantzig (1947, Simplex algorithm)",
                    AnoOrigin = "1947",
                    VariavelResultado = "z_max",
                    UnidadeResultado = "$",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x₁ (un)", Simbolo = "x1", Unidade = "un", ValorPadrao = 40, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "x₂ (un)", Simbolo = "x2", Unidade = "un", ValorPadrao = 20, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c₁ lucro/un ($)", Simbolo = "c1", Unidade = "$", ValorPadrao = 50, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c₂ lucro/un ($)", Simbolo = "c2", Unidade = "$", ValorPadrao = 40, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x1 = inputs["x₁ (un)"];
                        double x2 = inputs["x₂ (un)"];
                        double c1 = inputs["c₁ lucro/un ($)"];
                        double c2 = inputs["c₂ lucro/un ($)"];
                        
                        double z = c1 * x1 + c2 * x2;
                        return z;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-199: Modelo de Transporte (Custo Mínimo)
                new Formula
                {
                    Id = "3787",
                    CodigoCompendio = "V10-199",
                    Nome = "Problema de Transporte",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Logística",
                    Expressao = @"min z = ΣΣ(c_ij·x_ij); s.t. Σx_ij=s_i, Σx_ij=d_j",
                    Descricao = "m origens, n destinos. c_ij: custo/un. x_ij: quantidade i→j. Métodos: canto noroeste, custo mínimo, Vogel (VAM), MODI.",
                    ExemploPratico = "3 fábricas (100, 150, 80 un), 4 clientes (90, 70, 60, 110). Matriz custos. Vogel: solução inicial, MODI: otimiza. z_min≈$12000 (otimizado vs $15000 inicial).",
                    Criador = "Hitchcock (1941); Koopmans (1947, Nobel 1975, allocation theory)",
                    AnoOrigin = "1941",
                    VariavelResultado = "z_custo",
                    UnidadeResultado = "$",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "x_ij quantidade", Simbolo = "x", Unidade = "un", ValorPadrao = 100, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "c_ij custo/un ($)", Simbolo = "c", Unidade = "$/un", ValorPadrao = 5, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double x = inputs["x_ij quantidade"];
                        double c = inputs["c_ij custo/un ($)"];
                        
                        double z = c * x;
                        return z;
                    },
                    Icone = "📦",
                    Unidades = "",
                },

                // V10-200: Análise de Decisão — Árvore de Decisão
                new Formula
                {
                    Id = "3788",
                    CodigoCompendio = "V10-200",
                    Nome = "Árvore de Decisão — Valor Esperado",
                    Categoria = "Engenharia de Produção",
                    SubCategoria = "Análise de Decisão",
                    Expressao = @"EV(decisão) = Σ[p_i·payoff_i]",
                    Descricao = "Decisões: quadrados. Eventos: círculos. Backward induction: começa folhas. Escolhe max EV. Análise sensibilidade: varia probabilidades.",
                    ExemploPratico = "Investir máquina $100k. Demanda alta (p=0.6): lucro $200k. Baixa (0.4): $20k. EV=0.6·200+0.4·20=$128k. EV−custo=$28k>0→investir.",
                    Criador = "Raiffa (1968, Decision Analysis); software (TreeAge, PrecisionTree)",
                    AnoOrigin = "1968",
                    VariavelResultado = "EV",
                    UnidadeResultado = "$k",
                    Variaveis = new List<Variavel>
                    {
                        new Variavel { Nome = "p_high", Simbolo = "p_high", Unidade = "", ValorPadrao = 0.6, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Payoff high ($k)", Simbolo = "pay_high", Unidade = "$k", ValorPadrao = 200, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "p_low", Simbolo = "p_low", Unidade = "", ValorPadrao = 0.4, Descricao = "Parâmetro de entrada." },
                        new Variavel { Nome = "Payoff low ($k)", Simbolo = "pay_low", Unidade = "$k", ValorPadrao = 20, Descricao = "Parâmetro de entrada." }
                    },
                    Calcular = inputs =>
                    {
                        double p_high = inputs["p_high"];
                        double pay_high = inputs["Payoff high ($k)"];
                        double p_low = inputs["p_low"];
                        double pay_low = inputs["Payoff low ($k)"];
                        
                        double EV = p_high * pay_high + p_low * pay_low;
                        return EV;
                    },
                    Icone = "📦",
                    Unidades = "",
                }
            });
        }
    }
}
