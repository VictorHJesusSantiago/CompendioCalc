using CompendioCalc.Models;
using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasConsolidadas_GeneticaMedica()
        {
            _formulas.AddRange(new List<Formula>
            {
                new Formula
                {
                    Id = "C5901", Nome = "Frequência Alélica (Hardy-Weinberg)",
                    Categoria = "Genética Médica", SubCategoria = "Genética de Populações",
                    Expressao = "p + q = 1; p² + 2pq + q² = 1",
                    Descricao = "Equilíbrio de Hardy-Weinberg; frequências genotípicas em população em equilíbrio.",
                    Criador = "Hardy GH / Weinberg W", AnoOrigin = "1908",
                    ReferenciaBibliografica = "Hardy GH. Science, 1908.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência do alelo A (p)", Simbolo = "p", Unidade = "", ValorPadrao = 0.7, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => 2 * v["p"] * (1 - v["p"]),
                    VariavelResultado = "Freq. heterozigotos (2pq)", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5902", Nome = "Prevalência de Doença Autossômica Recessiva",
                    Categoria = "Genética Médica", SubCategoria = "Genética de Populações",
                    Expressao = "q² = prevalência; q = sqrt(prevalência); portadores = 2pq",
                    Descricao = "Frequência de portadores saudáveis de doença autossômica recessiva estimada pela prevalência da doença.",
                    Criador = "Hardy GH / Weinberg W", AnoOrigin = "1908",
                    ReferenciaBibliografica = "Nussbaum RL et al. Thompson & Thompson Genetics in Medicine, 8ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Prevalência da doença (q²)", Simbolo = "q2", Unidade = "fração", ValorPadrao = 0.0001, ValorMin = 1e-10, ValorMax = 1 }
                    },
                    Calcular = v => 2 * (1 - Math.Sqrt(v["q2"])) * Math.Sqrt(v["q2"]),
                    VariavelResultado = "Freq. portadores (2pq)", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5903", Nome = "Taxa de Mutação Espontânea",
                    Categoria = "Genética Médica", SubCategoria = "Mutação",
                    Expressao = "μ = taxa de novos casos / 2N (dominantes)",
                    Descricao = "Taxa de mutação por locus por geração; estimada pela incidência de formas dominantes de novo.",
                    Criador = "Haldane JBS", AnoOrigin = "1935",
                    ReferenciaBibliografica = "Haldane JBS. J Genet, 1935.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Novos casos dominantes", Simbolo = "novos", Unidade = "casos", ValorPadrao = 5 },
                        new Variavel { Nome = "Tamanho da população (N)", Simbolo = "N", Unidade = "indivíduos", ValorPadrao = 100000, ValorMin = 1 }
                    },
                    Calcular = v => v["novos"] / (2 * v["N"]),
                    VariavelResultado = "μ", UnidadeResultado = "por geração"
                },
                new Formula
                {
                    Id = "C5904", Nome = "Coeficiente de Consanguinidade (F)",
                    Categoria = "Genética Médica", SubCategoria = "Genética de Populações",
                    Expressao = "F = (1/2)^(L+1) × (1 + FA)",
                    Descricao = "Probabilidade de que os dois alelos de um indivíduo sejam idênticos por descendência; aumenta em casamentos consanguíneos.",
                    Criador = "Wright S", AnoOrigin = "1921",
                    ReferenciaBibliografica = "Wright S. Am Nat, 1921.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de elos na cadeia (L)", Simbolo = "L", Unidade = "", ValorPadrao = 3, ValorMin = 1 },
                        new Variavel { Nome = "Coeficiente F do ancestral comum (FA)", Simbolo = "FA", Unidade = "", ValorPadrao = 0, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => Math.Pow(0.5, v["L"]+1) * (1 + v["FA"]),
                    VariavelResultado = "F", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5905", Nome = "Risco de Herança Autossômica Dominante",
                    Categoria = "Genética Médica", SubCategoria = "Aconselhamento Genético",
                    Expressao = "Risco = 0,50 (50% por progenitor afetado)",
                    Descricao = "Probabilidade de transmissão de doença autossômica dominante com penetrância completa.",
                    Criador = "Mendel GJ", AnoOrigin = "1866",
                    ReferenciaBibliografica = "Nussbaum RL et al. Thompson & Thompson Genetics in Medicine, 8ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Penetrância da doença (%)", Simbolo = "penetrancia", Unidade = "%", ValorPadrao = 100, ValorMin = 0, ValorMax = 100 }
                    },
                    Calcular = v => 50 * v["penetrancia"] / 100,
                    VariavelResultado = "Risco de herança", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5906", Nome = "LOD Score (Análise de Ligação Genética)",
                    Categoria = "Genética Médica", SubCategoria = "Análise de Ligação",
                    Expressao = "Z(θ) = log10[L(θ) / L(0,5)]",
                    Descricao = "Logaritmo da razão de verossimilhanças entre θ (fração de recombinação) e ausência de ligação; Z≥3 confirma ligação.",
                    Criador = "Morton NE", AnoOrigin = "1955",
                    ReferenciaBibliografica = "Morton NE. Am J Hum Genet, 1955.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Verossimilhança com θ [L(θ)]", Simbolo = "L_theta", Unidade = "", ValorPadrao = 1000, ValorMin = 0.001 },
                        new Variavel { Nome = "Verossimilhança sem ligação [L(0,5)]", Simbolo = "L_half", Unidade = "", ValorPadrao = 1, ValorMin = 0.001 }
                    },
                    Calcular = v => Math.Log10(v["L_theta"] / v["L_half"]),
                    VariavelResultado = "Z (LOD Score)", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5907", Nome = "Distância Genética (cMorgans)",
                    Categoria = "Genética Médica", SubCategoria = "Mapeamento Genético",
                    Expressao = "d (cM) ≈ θ × 100 (para θ ≤ 0,10; Haldane: d = -50 × ln(1-2θ))",
                    Descricao = "Distância genética em centimorgans; 1 cM ≈ 1% de recombinação; Haldane corrige para múltiplos crossovers.",
                    Criador = "Morgan TH / Haldane JBS", AnoOrigin = "1911 / 1919",
                    ReferenciaBibliografica = "Nussbaum RL et al. Thompson & Thompson Genetics in Medicine, 8ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Fração de recombinação (θ)", Simbolo = "θ", Unidade = "", ValorPadrao = 0.05, ValorMin = 0, ValorMax = 0.5 }
                    },
                    Calcular = v => -50 * Math.Log(1 - 2*v["θ"]),
                    VariavelResultado = "d", UnidadeResultado = "cM"
                },
                new Formula
                {
                    Id = "C5908", Nome = "GC-Content (Composição de DNA)",
                    Categoria = "Genética Médica", SubCategoria = "Bioinformática / Genômica",
                    Expressao = "GC% = (G + C) / (A + T + G + C) × 100",
                    Descricao = "Percentagem de bases G e C no DNA; influencia temperatura de desnaturação e estabilidade da dupla-fita.",
                    Criador = "Chargaff E", AnoOrigin = "1950",
                    ReferenciaBibliografica = "Chargaff E. Experientia, 1950.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Bases G (count)", Simbolo = "G", Unidade = "", ValorPadrao = 250 },
                        new Variavel { Nome = "Bases C (count)", Simbolo = "C", Unidade = "", ValorPadrao = 250 },
                        new Variavel { Nome = "Bases A (count)", Simbolo = "A", Unidade = "", ValorPadrao = 250 },
                        new Variavel { Nome = "Bases T (count)", Simbolo = "T", Unidade = "", ValorPadrao = 250 }
                    },
                    Calcular = v => (v["G"] + v["C"]) / (v["A"] + v["T"] + v["G"] + v["C"]) * 100,
                    VariavelResultado = "GC%", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5909", Nome = "Temperatura de Melting de DNA (Tm)",
                    Categoria = "Genética Médica", SubCategoria = "Biologia Molecular",
                    Expressao = "Tm = 81,5 + 16,6 × log[Na+] + 0,41 × (%GC) − 675/n",
                    Descricao = "Temperatura de desnaturação de dupla-fita de DNA; crucial para PCR, hibridização e diagnóstico molecular.",
                    Criador = "Marmur J / Doty P", AnoOrigin = "1962",
                    ReferenciaBibliografica = "Marmur J, Doty P. J Mol Biol, 1962.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Concentração de Na+ (mol/L)", Simbolo = "Na", Unidade = "mol/L", ValorPadrao = 0.05, ValorMin = 0.001 },
                        new Variavel { Nome = "%GC do fragmento", Simbolo = "GC_pct", Unidade = "%", ValorPadrao = 50, ValorMin = 0, ValorMax = 100 },
                        new Variavel { Nome = "Comprimento do fragmento (n)", Simbolo = "n", Unidade = "bp", ValorPadrao = 500, ValorMin = 10 }
                    },
                    Calcular = v => 81.5 + 16.6*Math.Log10(v["Na"]) + 0.41*v["GC_pct"] - 675/v["n"],
                    VariavelResultado = "Tm", UnidadeResultado = "°C"
                },
                new Formula
                {
                    Id = "C5910", Nome = "Eficiência de PCR (Amplificação Teórica)",
                    Categoria = "Genética Médica", SubCategoria = "Diagnóstico Molecular",
                    Expressao = "Copias = N0 × (1 + E)^n",
                    Descricao = "Número de cópias após n ciclos de PCR com eficiência E (E=1 = 100% = duplicação perfeita).",
                    Criador = "Mullis KB", AnoOrigin = "1983",
                    ReferenciaBibliografica = "Mullis KB et al. Cold Spring Harb Symp Quant Biol, 1986.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Moléculas iniciais (N0)", Simbolo = "N0", Unidade = "cópias", ValorPadrao = 100 },
                        new Variavel { Nome = "Eficiência (E)", Simbolo = "E", Unidade = "", ValorPadrao = 0.95, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Número de ciclos (n)", Simbolo = "n", Unidade = "ciclos", ValorPadrao = 30, ValorMin = 1 }
                    },
                    Calcular = v => v["N0"] * Math.Pow(1 + v["E"], v["n"]),
                    VariavelResultado = "Cópias", UnidadeResultado = "moléculas"
                },
                new Formula
                {
                    Id = "C5911", Nome = "Penetrância Reduzida — Probabilidade de Expressar",
                    Categoria = "Genética Médica", SubCategoria = "Aconselhamento Genético",
                    Expressao = "P(expressar | genótipo) = penetrância × 100",
                    Descricao = "Probabilidade de manifestar fenótipo dado genótipo com penetrância incompleta; afeta aconselhamento.",
                    Criador = "Lenz W", AnoOrigin = "1963",
                    ReferenciaBibliografica = "Nussbaum RL et al. Thompson & Thompson Genetics in Medicine, 8ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Penetrância da variante (%)", Simbolo = "penetrancia", Unidade = "%", ValorPadrao = 70, ValorMin = 0, ValorMax = 100 }
                    },
                    Calcular = v => v["penetrancia"],
                    VariavelResultado = "P(expressar)", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5912", Nome = "Número de SNPs para Cobertura Genômica",
                    Categoria = "Genética Médica", SubCategoria = "Genômica",
                    Expressao = "n_SNPs = tamanho_genoma / (r² × LD_block)",
                    Descricao = "Estimativa de SNPs necessários para GWAS com cobertura do genoma humano por desequilíbrio de ligação.",
                    Criador = "International HapMap Consortium", AnoOrigin = "2005",
                    ReferenciaBibliografica = "The International HapMap Consortium. Nature, 2005.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tamanho do genoma (Mb)", Simbolo = "genoma", Unidade = "Mb", ValorPadrao = 3000 },
                        new Variavel { Nome = "Tamanho médio de bloco LD (kb)", Simbolo = "LD_block", Unidade = "kb", ValorPadrao = 30, ValorMin = 1 }
                    },
                    Calcular = v => v["genoma"] * 1000 / v["LD_block"],
                    VariavelResultado = "n_SNPs", UnidadeResultado = "SNPs"
                },
                new Formula
                {
                    Id = "C5913", Nome = "Variância Genética Aditiva (h² — Herdabilidade)",
                    Categoria = "Genética Médica", SubCategoria = "Genética Quantitativa",
                    Expressao = "h² = VA / VP",
                    Descricao = "Herdabilidade no sentido estrito; proporção da variância fenotípica devida a efeitos aditivos dos genes.",
                    Criador = "Falconer DS", AnoOrigin = "1960",
                    ReferenciaBibliografica = "Falconer DS, Mackay TFC. Introduction to Quantitative Genetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Variância aditiva (VA)", Simbolo = "VA", Unidade = "", ValorPadrao = 0.4 },
                        new Variavel { Nome = "Variância fenotípica total (VP)", Simbolo = "VP", Unidade = "", ValorPadrao = 1.0, ValorMin = 0.001 }
                    },
                    Calcular = v => v["VA"] / v["VP"],
                    VariavelResultado = "h²", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5914", Nome = "Risco Genômico Poligênico (PRS)",
                    Categoria = "Genética Médica", SubCategoria = "Genômica Clínica",
                    Expressao = "PRS = Σ (β_i × G_i)",
                    Descricao = "Escore de risco poligênico; soma ponderada de variantes genéticas; G_i = número de alelos de risco (0/1/2), β_i = peso.",
                    Criador = "Purcell S et al.", AnoOrigin = "2007",
                    ReferenciaBibliografica = "Purcell S et al. Am J Hum Genet, 2009.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Soma ponderada Σ(β_i × G_i)", Simbolo = "sum_betaG", Unidade = "", ValorPadrao = 1.5 }
                    },
                    Calcular = v => v["sum_betaG"],
                    VariavelResultado = "PRS", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5915", Nome = "Deriva Genética — Tamanho Efetivo da População (Ne)",
                    Categoria = "Genética Médica", SubCategoria = "Genética de Populações",
                    Expressao = "1/Ne = (1/4Nm + 1/4Nf) (sexos separados)",
                    Descricao = "Tamanho efetivo de população: número equivalente de indivíduos em deriva aleatória; menor que N real.",
                    Criador = "Wright S", AnoOrigin = "1931",
                    ReferenciaBibliografica = "Wright S. Genetics, 1931.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de machos reprodutores (Nm)", Simbolo = "Nm", Unidade = "", ValorPadrao = 50, ValorMin = 1 },
                        new Variavel { Nome = "Número de fêmeas reprodutoras (Nf)", Simbolo = "Nf", Unidade = "", ValorPadrao = 200, ValorMin = 1 }
                    },
                    Calcular = v => 4 * v["Nm"] * v["Nf"] / (v["Nm"] + v["Nf"]),
                    VariavelResultado = "Ne", UnidadeResultado = "indivíduos"
                },
                new Formula
                {
                    Id = "C5916", Nome = "Desequilíbrio de Ligação (D')",
                    Categoria = "Genética Médica", SubCategoria = "Análise de Ligação",
                    Expressao = "D = p_AB − p_A × p_B; D' = D / Dmax",
                    Descricao = "Medida normalizada de desequilíbrio de ligação entre dois loci; |D'|=1 = ligação completa.",
                    Criador = "Lewontin RC", AnoOrigin = "1964",
                    ReferenciaBibliografica = "Lewontin RC. Genetics, 1964.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência haplótipo AB (p_AB)", Simbolo = "p_AB", Unidade = "", ValorPadrao = 0.45, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Frequência alelo A (p_A)", Simbolo = "p_A", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Frequência alelo B (p_B)", Simbolo = "p_B", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["p_AB"] - v["p_A"] * v["p_B"],
                    VariavelResultado = "D (desequilíbrio bruto)", UnidadeResultado = "adimensional"
                },
                new Formula
                {
                    Id = "C5917", Nome = "Risco de Recorrência para Doenças Multifatoriais (Falconer)",
                    Categoria = "Genética Médica", SubCategoria = "Aconselhamento Genético",
                    Expressao = "r_parentes = a × h × b",
                    Descricao = "Correlação fenotípica entre parentes de grau a para característica com herdabilidade h²; estimativa do risco de recorrência.",
                    Criador = "Falconer DS", AnoOrigin = "1965",
                    ReferenciaBibliografica = "Falconer DS. Ann Hum Genet, 1965.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Coeficiente de parentesco (r)", Simbolo = "r_coef", Unidade = "", ValorPadrao = 0.5, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Herdabilidade (h²)", Simbolo = "h2", Unidade = "", ValorPadrao = 0.6, ValorMin = 0, ValorMax = 1 },
                        new Variavel { Nome = "Prevalência geral da doença (%)", Simbolo = "prev", Unidade = "%", ValorPadrao = 1 }
                    },
                    Calcular = v => v["prev"] + v["r_coef"] * Math.Sqrt(v["h2"]) * (10 - v["prev"]),
                    VariavelResultado = "Risco em parentes (aprox.)", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5918", Nome = "Número Esperado de Variantes Raras (Exoma)",
                    Categoria = "Genética Médica", SubCategoria = "Genômica",
                    Expressao = "E[var] = 2 × Ne × μ × L",
                    Descricao = "Número esperado de variantes raras em sequenciamento do exoma; Ne = tamanho efetivo, μ = taxa de mutação, L = exoma.",
                    Criador = "Watterson GA", AnoOrigin = "1975",
                    ReferenciaBibliografica = "Watterson GA. Theor Popul Biol, 1975.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Tamanho efetivo (Ne)", Simbolo = "Ne", Unidade = "", ValorPadrao = 10000 },
                        new Variavel { Nome = "Taxa de mutação por pb/geração (μ)", Simbolo = "mu", Unidade = "", ValorPadrao = 1.2e-8, ValorMin = 1e-12 },
                        new Variavel { Nome = "Tamanho do exoma (pb)", Simbolo = "L", Unidade = "pb", ValorPadrao = 3e7 }
                    },
                    Calcular = v => 2 * v["Ne"] * v["mu"] * v["L"],
                    VariavelResultado = "E[variantes raras]", UnidadeResultado = "variantes"
                },
                new Formula
                {
                    Id = "C5919", Nome = "Risco de Transmissão Ligada ao X",
                    Categoria = "Genética Médica", SubCategoria = "Aconselhamento Genético",
                    Expressao = "Filhos afetados: 50% dos filhos XY; Filhas portadoras: 50% das filhas XX",
                    Descricao = "Probabilidade de transmissão de doença ligada ao X recessiva por mãe portadora obrigatória.",
                    Criador = "Mendel GJ / Morgan TH", AnoOrigin = "1866 / 1911",
                    ReferenciaBibliografica = "Nussbaum RL et al. Thompson & Thompson Genetics in Medicine, 8ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Porcentagem de filhos que serão XY (%)", Simbolo = "pct_XY", Unidade = "%", ValorPadrao = 50 }
                    },
                    Calcular = v => v["pct_XY"] / 2,
                    VariavelResultado = "Risco filho afetado", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5920", Nome = "Expressividade — Coeficiente de Variação do Fenótipo",
                    Categoria = "Genética Médica", SubCategoria = "Genética Médica Clínica",
                    Expressao = "CV = (σ_fenotipo / μ_fenotipo) × 100",
                    Descricao = "Coeficiente de variação do fenótipo entre portadores do mesmo genótipo; mede expressividade variável.",
                    Criador = "Prática em genética médica", AnoOrigin = "séc. XX",
                    ReferenciaBibliografica = "Nussbaum RL et al. Thompson & Thompson Genetics in Medicine, 8ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Desvio-padrão do fenótipo (σ)", Simbolo = "σ_fen", Unidade = "unid.", ValorPadrao = 5 },
                        new Variavel { Nome = "Média fenotípica (μ)", Simbolo = "μ_fen", Unidade = "unid.", ValorPadrao = 25, ValorMin = 0.001 }
                    },
                    Calcular = v => v["σ_fen"] / v["μ_fen"] * 100,
                    VariavelResultado = "CV", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5921", Nome = "Sequência de Complementaridade de DNA (Cálculo de Tm para Oligonucleotídeos)",
                    Categoria = "Genética Médica", SubCategoria = "Diagnóstico Molecular",
                    Expressao = "Tm = 2°C × (A+T) + 4°C × (G+C) (regra dos 2-4 para oligonucleotídeos curtos)",
                    Descricao = "Temperatura de melting estimada para oligonucleotídeos ≤ 14 bp; usado no design de primers de PCR.",
                    Criador = "Wallace RB et al.", AnoOrigin = "1979",
                    ReferenciaBibliografica = "Wallace RB et al. Nucleic Acids Res, 1979.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Número de A+T no oligo", Simbolo = "AT", Unidade = "bases", ValorPadrao = 10, ValorMin = 0 },
                        new Variavel { Nome = "Número de G+C no oligo", Simbolo = "GC", Unidade = "bases", ValorPadrao = 10, ValorMin = 0 }
                    },
                    Calcular = v => 2*v["AT"] + 4*v["GC"],
                    VariavelResultado = "Tm (regra 2-4)", UnidadeResultado = "°C"
                },
                new Formula
                {
                    Id = "C5922", Nome = "Razão de Verossimilhança de Teste Genético",
                    Categoria = "Genética Médica", SubCategoria = "Aconselhamento Genético",
                    Expressao = "Odds_pós = Odds_pré × LR",
                    Descricao = "Atualização Bayesiana da probabilidade de diagnóstico genético usando razão de verossimilhança do teste.",
                    Criador = "Bayes T", AnoOrigin = "1763",
                    ReferenciaBibliografica = "Young ID. Introduction to Risk Calculation in Genetic Counselling, 3ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Probabilidade pré-teste (%)", Simbolo = "prob_pre", Unidade = "%", ValorPadrao = 25, ValorMin = 0.001, ValorMax = 99.999 },
                        new Variavel { Nome = "Razão de verossimilhança (LR)", Simbolo = "LR", Unidade = "", ValorPadrao = 9, ValorMin = 0.001 }
                    },
                    Calcular = v => {
                        double p = v["prob_pre"] / 100;
                        double odds_pre = p / (1 - p);
                        double odds_pos = odds_pre * v["LR"];
                        return odds_pos / (1 + odds_pos) * 100;
                    },
                    VariavelResultado = "Prob. pós-teste", UnidadeResultado = "%"
                },
                new Formula
                {
                    Id = "C5923", Nome = "Número de Crossing-Overs Esperados por Cromossomo",
                    Categoria = "Genética Médica", SubCategoria = "Mapeamento Genético",
                    Expressao = "n_CO = comprimento_genético_Morgan / 1",
                    Descricao = "Número esperado de crossing-overs por meiose por cromossomo; 1 Morgan = 1 crossing-over esperado.",
                    Criador = "Morgan TH", AnoOrigin = "1911",
                    ReferenciaBibliografica = "Sturtevant AH. J Exp Zool, 1913.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Comprimento do cromossomo (Morgan)", Simbolo = "L_M", Unidade = "Morgan", ValorPadrao = 1.5 }
                    },
                    Calcular = v => v["L_M"],
                    VariavelResultado = "n_CO esperado", UnidadeResultado = "crossing-overs/meiose"
                },
                new Formula
                {
                    Id = "C5924", Nome = "Homozigosidade Esperada em População (HWE)",
                    Categoria = "Genética Médica", SubCategoria = "Genética de Populações",
                    Expressao = "Hom = Σ pi² (soma das frequências ao quadrado)",
                    Descricao = "Fração esperada de homozigotos em população HWE; útil para calcular risco de doenças recessivas.",
                    Criador = "Hardy GH / Weinberg W", AnoOrigin = "1908",
                    ReferenciaBibliografica = "Hartl DL, Clark AG. Principles of Population Genetics, 4ª ed.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Frequência do alelo mais comum (p)", Simbolo = "p", Unidade = "", ValorPadrao = 0.8, ValorMin = 0, ValorMax = 1 }
                    },
                    Calcular = v => v["p"]*v["p"] + (1-v["p"])*(1-v["p"]),
                    VariavelResultado = "Hom. total esperada", UnidadeResultado = "fração"
                },
                new Formula
                {
                    Id = "C5925", Nome = "Índice de Fixação (Fst) — Diferenciação Genética",
                    Categoria = "Genética Médica", SubCategoria = "Genética de Populações",
                    Expressao = "Fst = (HT − HS) / HT",
                    Descricao = "Grau de diferenciação genética entre subpopulações; Fst=0 (sem diferenciação), Fst=1 (completa).",
                    Criador = "Wright S", AnoOrigin = "1951",
                    ReferenciaBibliografica = "Wright S. Ann Eugen, 1951.",
                    Variaveis = new List<Variavel> {
                        new Variavel { Nome = "Heterozigosidade total (HT)", Simbolo = "HT", Unidade = "", ValorPadrao = 0.5, ValorMin = 0.001 },
                        new Variavel { Nome = "Heterozigosidade média subpopulações (HS)", Simbolo = "HS", Unidade = "", ValorPadrao = 0.4, ValorMin = 0 }
                    },
                    Calcular = v => (v["HT"] - v["HS"]) / v["HT"],
                    VariavelResultado = "Fst", UnidadeResultado = "adimensional"
                }
            });
        }
    }
}
