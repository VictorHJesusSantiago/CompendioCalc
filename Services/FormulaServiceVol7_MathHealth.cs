using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    // ═══════════════════════════════════════════════════════════════
    //  VOLUME 7 — PARTE I: MATEMÁTICA ELEMENTAR (11 fórmulas)
    //  VOLUME 7 — PARTE II: CIÊNCIAS DA SAÚDE (26 fórmulas)
    // ═══════════════════════════════════════════════════════════════

    private void AdicionarVol7MatematicaElementar()
    {
        _formulas.AddRange([
            // ── 001 Regra de Três Simples ──
            new Formula
            {
                Id = "7_mel01", Nome = "Regra de Três Simples", Categoria = "Matemática Elementar",
                Expressao = "x = (b · c) / a",
                ExprTexto = "x = (b × c) / a",
                Icone = "×",
                Descricao = "Resolve proporções diretas: se a está para b, assim como c está para x. Fundamento de cálculos proporcionais em todas as ciências aplicadas.",
                Criador = "Conhecimento antigo; formalizado na matemática indiana e árabe",
                AnoOrigin = "Antiguidade",
                ExemploPratico = "Se 5 kg custam R$20, quanto custam 8 kg? x = (20×8)/5 = R$32",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Valor de referência (a)", Descricao = "Grandeza conhecida 1", ValorPadrao = 5, Unidade = "adim" },
                    new() { Simbolo = "b", Nome = "Valor correspondente (b)", Descricao = "Grandeza conhecida 2", ValorPadrao = 20, Unidade = "adim" },
                    new() { Simbolo = "c", Nome = "Valor buscado (c)", Descricao = "Grandeza conhecida 3", ValorPadrao = 8, Unidade = "adim" },
                ],
                VariavelResultado = "x",
                Calcular = vars => (vars["b"] * vars["c"]) / vars["a"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 002 Porcentagem ──
            new Formula
            {
                Id = "7_mel02", Nome = "Porcentagem", Categoria = "Matemática Elementar",
                Expressao = "P = (V · p) / 100",
                ExprTexto = "P = (V × p) / 100",
                Icone = "%",
                Descricao = "Calcula p% de um valor V. Base para descontos, juros, estatísticas e análises proporcionais.",
                Criador = "Matemática comercial medieval; símbolo % surgiu no séc. XV",
                AnoOrigin = "Séc. XV",
                ExemploPratico = "15% de R$200: P = (200×15)/100 = R$30",
                Variaveis = [
                    new() { Simbolo = "V", Nome = "Valor total (V)", Descricao = "Valor base", ValorPadrao = 200, Unidade = "adim" },
                    new() { Simbolo = "p", Nome = "Porcentagem (p)", Descricao = "Percentual desejado", ValorPadrao = 15, Unidade = "adim" },
                ],
                VariavelResultado = "P",
                Calcular = vars => (vars["V"] * vars["p"]) / 100.0,
                SubCategoria = "",
                Unidades = "",
            },
            // ── 003 Média Aritmética Simples ──
            new Formula
            {
                Id = "7_mel03", Nome = "Média Aritmética Simples", Categoria = "Matemática Elementar",
                Expressao = "x̄ = (x₁ + x₂ + ... + xₙ) / n",
                ExprTexto = "x̄ = Σxᵢ / n",
                Icone = "x̄",
                Descricao = "Soma de todos os valores dividida pelo número de observações. Medida de tendência central mais utilizada em estatística descritiva.",
                Criador = "Conceito atribuído a Gauss e Legendre (séc. XVIII-XIX)",
                AnoOrigin = "Séc. XVIII",
                ExemploPratico = "Notas: 7, 8, 6, 9 → x̄ = (7+8+6+9)/4 = 7,5",
                Variaveis = [
                    new() { Simbolo = "soma", Nome = "Soma dos valores (Σx)", Descricao = "Soma de todos os valores", ValorPadrao = 30, Unidade = "adim" },
                    new() { Simbolo = "n", Nome = "Número de valores (n)", Descricao = "Quantidade de observações", ValorPadrao = 4, ValorMin = 1, Unidade = "adim" },
                ],
                VariavelResultado = "x̄",
                Calcular = vars => vars["soma"] / vars["n"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 004 Média Ponderada ──
            new Formula
            {
                Id = "7_mel04", Nome = "Média Ponderada", Categoria = "Matemática Elementar",
                Expressao = "x̄ₚ = Σ(xᵢ·wᵢ) / Σwᵢ",
                ExprTexto = "x̄ₚ = Σ(xᵢ × wᵢ) / Σwᵢ",
                Icone = "x̄w",
                Descricao = "Média em que cada valor tem um peso associado. Utilizada em notas escolares com pesos, índices econômicos e análise de investimentos.",
                Criador = "Conceito de ponderação; formalizado no séc. XIX",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "Notas 8(peso3), 6(peso2), 9(peso5): x̄ₚ = (8×3+6×2+9×5)/(3+2+5) = 81/10 = 8,1",
                Variaveis = [
                    new() { Simbolo = "somaXW", Nome = "Soma ponderada (Σxᵢwᵢ)", Descricao = "Soma dos produtos valor × peso", ValorPadrao = 81, Unidade = "adim" },
                    new() { Simbolo = "somaW", Nome = "Soma dos pesos (Σwᵢ)", Descricao = "Soma de todos os pesos", ValorPadrao = 10, ValorMin = 0.001, Unidade = "adim" },
                ],
                VariavelResultado = "x̄ₚ",
                Calcular = vars => vars["somaXW"] / vars["somaW"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 005 Desvio Padrão Amostral ──
            new Formula
            {
                Id = "7_mel05", Nome = "Desvio Padrão Amostral", Categoria = "Matemática Elementar",
                Expressao = "s = √(Σ(xᵢ - x̄)² / (n - 1))",
                ExprTexto = "s = √[Σ(xᵢ − x̄)² / (n − 1)]",
                Icone = "s",
                Descricao = "Mede a dispersão dos dados em relação à média. Usa n−1 (correção de Bessel) para amostras. Quanto maior s, mais dispersos os dados.",
                Criador = "Karl Pearson (1894); correção de Bessel (1838)",
                AnoOrigin = "1894",
                ExemploPratico = "Dados: 4,7,13,16. Média=10. s = √[(36+9+9+36)/3] = √30 ≈ 5,48",
                Variaveis = [
                    new() { Simbolo = "somaDesvQ", Nome = "Σ(xᵢ − x̄)²", Descricao = "Soma dos desvios quadráticos", ValorPadrao = 90, Unidade = "adim" },
                    new() { Simbolo = "n", Nome = "Número de dados (n)", Descricao = "Tamanho da amostra", ValorPadrao = 4, ValorMin = 2, Unidade = "adim" },
                ],
                VariavelResultado = "s",
                Calcular = vars => Math.Sqrt(vars["somaDesvQ"] / (vars["n"] - 1)),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 006 Teorema de Pitágoras ──
            new Formula
            {
                Id = "7_mel06", Nome = "Teorema de Pitágoras", Categoria = "Matemática Elementar",
                Expressao = "c = √(a² + b²)",
                ExprTexto = "c = √(a² + b²)",
                Icone = "△",
                Descricao = "Em um triângulo retângulo, o quadrado da hipotenusa é igual à soma dos quadrados dos catetos. Fundamento da geometria euclidiana.",
                Criador = "Pitágoras de Samos (~570–495 a.C.); conhecimento anterior babilônico",
                AnoOrigin = "~500 a.C.",
                ExemploPratico = "Catetos 3 e 4: c = √(9+16) = √25 = 5",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Cateto a", Descricao = "Primeiro cateto", ValorPadrao = 3, Unidade = "adim" },
                    new() { Simbolo = "b", Nome = "Cateto b", Descricao = "Segundo cateto", ValorPadrao = 4, Unidade = "adim" },
                ],
                VariavelResultado = "c (hipotenusa)",
                Calcular = vars => Math.Sqrt(vars["a"] * vars["a"] + vars["b"] * vars["b"]),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 007 Área do Círculo ──
            new Formula
            {
                Id = "7_mel07", Nome = "Área do Círculo", Categoria = "Matemática Elementar",
                Expressao = "A = π · r²",
                ExprTexto = "A = π × r²",
                Icone = "○",
                Descricao = "Área delimitada por uma circunferência de raio r. Pi (π ≈ 3,14159) é a razão entre o perímetro e o diâmetro de qualquer círculo.",
                Criador = "Arquimedes de Siracusa (~287–212 a.C.)",
                AnoOrigin = "~250 a.C.",
                ExemploPratico = "Raio 5 m: A = π×25 ≈ 78,54 m²",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Raio (r)", Descricao = "Raio do círculo", ValorPadrao = 5, Unidade = "adim" },
                ],
                VariavelResultado = "A",
                UnidadeResultado = "m²",
                Calcular = vars => Math.PI * vars["r"] * vars["r"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 008 Volume do Cilindro ──
            new Formula
            {
                Id = "7_mel08", Nome = "Volume do Cilindro", Categoria = "Matemática Elementar",
                Expressao = "V = π · r² · h",
                ExprTexto = "V = π × r² × h",
                Icone = "⌓",
                Descricao = "Volume de um cilindro circular reto: produto da área da base circular pela altura. Aplicado em reservatórios, silos e tubulações.",
                Criador = "Arquimedes; sistematização na geometria grega",
                AnoOrigin = "~250 a.C.",
                ExemploPratico = "Tanque r=2m, h=5m: V = π×4×5 ≈ 62,83 m³",
                Variaveis = [
                    new() { Simbolo = "r", Nome = "Raio (r)", Descricao = "Raio da base", ValorPadrao = 2, Unidade = "adim" },
                    new() { Simbolo = "h", Nome = "Altura (h)", Descricao = "Altura do cilindro", ValorPadrao = 5, Unidade = "adim" },
                ],
                VariavelResultado = "V",
                UnidadeResultado = "m³",
                Calcular = vars => Math.PI * vars["r"] * vars["r"] * vars["h"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 009 Conversão Celsius → Fahrenheit ──
            new Formula
            {
                Id = "7_mel09", Nome = "Conversão Celsius → Fahrenheit", Categoria = "Matemática Elementar",
                Expressao = "F = (9/5)·C + 32",
                ExprTexto = "F = (9/5) × C + 32",
                Icone = "°F",
                Descricao = "Converte temperatura de graus Celsius para Fahrenheit. Pontos de referência: 0°C=32°F (congelamento da água), 100°C=212°F (ebulição).",
                Criador = "Daniel Gabriel Fahrenheit (1724)",
                AnoOrigin = "1724",
                ExemploPratico = "37°C (febre): F = (9/5)×37+32 = 98,6°F",
                Variaveis = [
                    new() { Simbolo = "C", Nome = "Temperatura (°C)", Descricao = "Temperatura em Celsius", ValorPadrao = 37, Unidade = "adim" },
                ],
                VariavelResultado = "F (°Fahrenheit)",
                UnidadeResultado = "°F",
                Calcular = vars => (9.0 / 5.0) * vars["C"] + 32,
                SubCategoria = "",
                Unidades = "",
            },
            // ── 010 Velocidade Média ──
            new Formula
            {
                Id = "7_mel10", Nome = "Velocidade Média", Categoria = "Matemática Elementar",
                Expressao = "v = d / t",
                ExprTexto = "v = d / t",
                Icone = "v",
                Descricao = "Razão entre distância percorrida e tempo gasto. Conceito fundamental da cinemática escalar, base para cálculos de deslocamento.",
                Criador = "Galileu Galilei; conceito formalizado na mecânica clássica",
                AnoOrigin = "Séc. XVII",
                ExemploPratico = "360 km em 4 horas: v = 360/4 = 90 km/h",
                Variaveis = [
                    new() { Simbolo = "d", Nome = "Distância (d)", Descricao = "Distância percorrida", ValorPadrao = 360, Unidade = "adim" },
                    new() { Simbolo = "t", Nome = "Tempo (t)", Descricao = "Tempo gasto", ValorPadrao = 4, ValorMin = 0.001, Unidade = "adim" },
                ],
                VariavelResultado = "v",
                UnidadeResultado = "km/h",
                Calcular = vars => vars["d"] / vars["t"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 011 Densidade ──
            new Formula
            {
                Id = "7_mel11", Nome = "Densidade", Categoria = "Matemática Elementar",
                Expressao = "ρ = m / V",
                ExprTexto = "ρ = m / V",
                Icone = "ρ",
                Descricao = "Razão entre massa e volume de um corpo. Propriedade intensiva fundamental para identificação de materiais e cálculos de engenharia.",
                Criador = "Arquimedes (princípio da coroa de ouro, ~250 a.C.)",
                AnoOrigin = "~250 a.C.",
                ExemploPratico = "Bloco de 500g e 200cm³: ρ = 500/200 = 2,5 g/cm³ (alumínio)",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa (m)", Descricao = "Massa do corpo", ValorPadrao = 500, Unidade = "adim" },
                    new() { Simbolo = "V", Nome = "Volume (V)", Descricao = "Volume do corpo", ValorPadrao = 200, ValorMin = 0.001, Unidade = "adim" },
                ],
                VariavelResultado = "ρ",
                UnidadeResultado = "g/cm³",
                Calcular = vars => vars["m"] / vars["V"],
                SubCategoria = "",
                Unidades = "",
            },
        ]);
    }

    // ─────────────────────────────────────────────────────
    //  PARTE II: CIÊNCIAS DA SAÚDE
    // ─────────────────────────────────────────────────────
    private void AdicionarVol7Saude()
    {
        _formulas.AddRange([
            // ═══ FARMÁCIA (6 fórmulas) ═══

            // ── 012 Concentração Molar ──
            new Formula
            {
                Id = "7_far01", Nome = "Concentração Molar", Categoria = "Farmácia",
                Expressao = "C = n / V",
                ExprTexto = "C = n / V  (mol/L)",
                Icone = "M",
                Descricao = "Molaridade: número de mols de soluto por litro de solução. Fundamental para preparação de soluções farmacêuticas e cálculos de dosagem.",
                Criador = "Wilhelm Ostwald; padronização IUPAC",
                AnoOrigin = "Séc. XIX",
                ExemploPratico = "0,5 mol de NaCl em 250 mL: C = 0,5/0,25 = 2 mol/L",
                Variaveis = [
                    new() { Simbolo = "n", Nome = "Mols de soluto (n)", Descricao = "Quantidade de substância em mol", ValorPadrao = 0.5, Unidade = "adim" },
                    new() { Simbolo = "V", Nome = "Volume da solução (V)", Descricao = "Volume em litros", ValorPadrao = 0.25, ValorMin = 0.001, Unidade = "adim" },
                ],
                VariavelResultado = "C (mol/L)",
                UnidadeResultado = "mol/L",
                Calcular = vars => vars["n"] / vars["V"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 013 Diluição ──
            new Formula
            {
                Id = "7_far02", Nome = "Equação de Diluição", Categoria = "Farmácia",
                Expressao = "C₁·V₁ = C₂·V₂",
                ExprTexto = "C₁ × V₁ = C₂ × V₂ → V₂ = C₁V₁/C₂",
                Icone = "dil",
                Descricao = "Conservação da quantidade de soluto durante diluição. Permite calcular o volume final ou a concentração final ao adicionar solvente.",
                Criador = "Princípio de conservação de massa; química analítica",
                AnoOrigin = "Séc. XVIII",
                ExemploPratico = "Diluir 50mL de solução 2M para 0,5M: V₂ = (2×50)/0,5 = 200 mL",
                Variaveis = [
                    new() { Simbolo = "C1", Nome = "Concentração inicial (C₁)", Descricao = "Concentração antes da diluição", ValorPadrao = 2, Unidade = "adim" },
                    new() { Simbolo = "V1", Nome = "Volume inicial (V₁)", Descricao = "Volume antes da diluição", ValorPadrao = 50, Unidade = "adim" },
                    new() { Simbolo = "C2", Nome = "Concentração final (C₂)", Descricao = "Concentração desejada", ValorPadrao = 0.5, ValorMin = 0.001, Unidade = "adim" },
                ],
                VariavelResultado = "V₂ (volume final)",
                UnidadeResultado = "mL",
                Calcular = vars => (vars["C1"] * vars["V1"]) / vars["C2"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 014 Biodisponibilidade ──
            new Formula
            {
                Id = "7_far03", Nome = "Biodisponibilidade", Categoria = "Farmácia",
                Expressao = "F = (AUC_oral / AUC_iv) × 100",
                ExprTexto = "F = (AUC oral / AUC intravenosa) × 100%",
                Icone = "F%",
                Descricao = "Fração do fármaco que atinge a circulação sistêmica inalterada após administração oral. AUC = área sob a curva concentração-tempo.",
                Criador = "Farmacocinética clínica moderna; FDA guidelines",
                AnoOrigin = "1960s",
                ExemploPratico = "AUC oral=80, AUC iv=100: F = (80/100)×100 = 80%",
                Variaveis = [
                    new() { Simbolo = "AUC_oral", Nome = "AUC via oral", Descricao = "Área sob a curva - administração oral", ValorPadrao = 80, Unidade = "adim" },
                    new() { Simbolo = "AUC_iv", Nome = "AUC intravenosa", Descricao = "Área sob a curva - administração IV", ValorPadrao = 100, ValorMin = 0.001, Unidade = "adim" },
                ],
                VariavelResultado = "F (%)",
                UnidadeResultado = "%",
                Calcular = vars => (vars["AUC_oral"] / vars["AUC_iv"]) * 100,
                SubCategoria = "",
                Unidades = "",
            },
            // ── 015 Meia-Vida de Eliminação ──
            new Formula
            {
                Id = "7_far04", Nome = "Meia-Vida de Eliminação", Categoria = "Farmácia",
                Expressao = "t₁/₂ = ln(2) / k_e ≈ 0.693 / k_e",
                ExprTexto = "t½ = 0,693 / kₑ",
                Icone = "t½",
                Descricao = "Tempo necessário para a concentração plasmática do fármaco diminuir pela metade. Determina intervalo de dosagem.",
                Criador = "Farmacocinética; Teorell (1937)",
                AnoOrigin = "1937",
                ExemploPratico = "kₑ = 0,1 h⁻¹: t½ = 0,693/0,1 = 6,93 horas",
                Variaveis = [
                    new() { Simbolo = "ke", Nome = "Constante de eliminação (kₑ)", Descricao = "Taxa de eliminação em h⁻¹", ValorPadrao = 0.1, ValorMin = 0.0001, Unidade = "adim" },
                ],
                VariavelResultado = "t½ (horas)",
                UnidadeResultado = "h",
                Calcular = vars => Math.Log(2) / vars["ke"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 016 Clearance Renal ──
            new Formula
            {
                Id = "7_far05", Nome = "Clearance Renal (Cockcroft-Gault)", Categoria = "Farmácia",
                Expressao = "ClCr = ((140−idade)·peso) / (72·Cr)",
                ExprTexto = "ClCr = [(140 − idade) × peso] / (72 × creatinina sérica)",
                Icone = "Cl",
                Descricao = "Estima a taxa de filtração glomerular a partir de creatinina sérica. Essencial para ajuste de dose de fármacos eliminados por via renal.",
                Criador = "Cockcroft & Gault (1976)",
                AnoOrigin = "1976",
                ExemploPratico = "Paciente 60 anos, 70 kg, Cr=1,2: ClCr = (80×70)/(72×1,2) = 64,8 mL/min",
                Variaveis = [
                    new() { Simbolo = "idade", Nome = "Idade (anos)", Descricao = "Idade do paciente", ValorPadrao = 60, Unidade = "adim" },
                    new() { Simbolo = "peso", Nome = "Peso (kg)", Descricao = "Peso corporal em kg", ValorPadrao = 70, Unidade = "adim" },
                    new() { Simbolo = "Cr", Nome = "Creatinina sérica (mg/dL)", Descricao = "Nível de creatinina no soro", ValorPadrao = 1.2, ValorMin = 0.1, Unidade = "adim" },
                ],
                VariavelResultado = "ClCr",
                UnidadeResultado = "mL/min",
                Calcular = vars => ((140 - vars["idade"]) * vars["peso"]) / (72 * vars["Cr"]),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 017 Equação de Henderson-Hasselbalch ──
            new Formula
            {
                Id = "7_far06", Nome = "Equação de Henderson-Hasselbalch", Categoria = "Farmácia",
                Expressao = "pH = pKa + log([A⁻]/[HA])",
                ExprTexto = "pH = pKa + log₁₀([A⁻] / [HA])",
                Icone = "pH",
                Descricao = "Relaciona pH, pKa e razão entre formas ionizada e não-ionizada de um fármaco. Fundamental para prever absorção transmembrana de fármacos.",
                Criador = "Lawrence Henderson (1908) / Karl Hasselbalch (1917)",
                AnoOrigin = "1917",
                ExemploPratico = "pKa=4,5, razão [A⁻]/[HA]=10: pH = 4,5+log(10) = 5,5",
                Variaveis = [
                    new() { Simbolo = "pKa", Nome = "pKa do fármaco", Descricao = "Constante de dissociação ácida", ValorPadrao = 4.5, Unidade = "adim" },
                    new() { Simbolo = "ratio", Nome = "[A⁻]/[HA]", Descricao = "Razão base conjugada / ácido", ValorPadrao = 10, ValorMin = 0.0001, Unidade = "adim" },
                ],
                VariavelResultado = "pH",
                Calcular = vars => vars["pKa"] + Math.Log10(vars["ratio"]),
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ MEDICINA (8 fórmulas) ═══

            // ── 018 Índice de Massa Corporal ──
            new Formula
            {
                Id = "7_med01", Nome = "Índice de Massa Corporal (IMC)", Categoria = "Medicina",
                Expressao = "IMC = m / h²",
                ExprTexto = "IMC = massa / altura²",
                Icone = "IMC",
                Descricao = "Indicador antropométrico que relaciona peso e altura. Classificação OMS: <18,5 abaixo do peso, 18,5-24,9 normal, 25-29,9 sobrepeso, ≥30 obesidade.",
                Criador = "Adolphe Quetelet (1832)",
                AnoOrigin = "1832",
                ExemploPratico = "Pessoa de 75 kg e 1,75 m: IMC = 75/1,75² = 24,5 (normal)",
                Variaveis = [
                    new() { Simbolo = "m", Nome = "Massa (kg)", Descricao = "Peso corporal em kg", ValorPadrao = 75, Unidade = "adim" },
                    new() { Simbolo = "h", Nome = "Altura (m)", Descricao = "Altura em metros", ValorPadrao = 1.75, ValorMin = 0.5, Unidade = "adim" },
                ],
                VariavelResultado = "IMC",
                UnidadeResultado = "kg/m²",
                Calcular = vars => vars["m"] / (vars["h"] * vars["h"]),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 019 Área de Superfície Corporal (Du Bois) ──
            new Formula
            {
                Id = "7_med02", Nome = "Superfície Corporal (Du Bois)", Categoria = "Medicina",
                Expressao = "BSA = 0.007184 · h^0.725 · m^0.425",
                ExprTexto = "BSA = 0,007184 × h⁰·⁷²⁵ × m⁰·⁴²⁵",
                Icone = "BSA",
                Descricao = "Estima a área de superfície corporal total. Usada para dosagem de quimioterápicos, cálculo de débito cardíaco e ajuste de doses em pediatria.",
                Criador = "Du Bois & Du Bois (1916)",
                AnoOrigin = "1916",
                ExemploPratico = "h=170 cm, m=70 kg: BSA = 0,007184×170⁰·⁷²⁵×70⁰·⁴²⁵ ≈ 1,82 m²",
                Variaveis = [
                    new() { Simbolo = "h", Nome = "Altura (cm)", Descricao = "Altura em centímetros", ValorPadrao = 170, Unidade = "adim" },
                    new() { Simbolo = "m", Nome = "Massa (kg)", Descricao = "Peso em kg", ValorPadrao = 70, Unidade = "adim" },
                ],
                VariavelResultado = "BSA",
                UnidadeResultado = "m²",
                Calcular = vars => 0.007184 * Math.Pow(vars["h"], 0.725) * Math.Pow(vars["m"], 0.425),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 020 Fórmula de Parkland (Queimaduras) ──
            new Formula
            {
                Id = "7_med03", Nome = "Fórmula de Parkland", Categoria = "Medicina",
                Expressao = "V = 4 · peso · %SCQ",
                ExprTexto = "Volume (mL) = 4 × peso (kg) × %SCQ",
                Icone = "🔥",
                Descricao = "Estimativa de reposição volêmica nas primeiras 24h de grandes queimados. SCQ = superfície corporal queimada. Metade do volume nas primeiras 8h.",
                Criador = "Charles Baxter (Parkland Hospital, 1968)",
                AnoOrigin = "1968",
                ExemploPratico = "Paciente 70 kg, 30% SCQ: V = 4×70×30 = 8400 mL em 24h",
                Variaveis = [
                    new() { Simbolo = "peso", Nome = "Peso (kg)", ValorPadrao = 70, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "SCQ", Nome = "% Superfície Queimada", Descricao = "Percentual da superfície corporal queimada", ValorPadrao = 30, Unidade = "adim" },
                ],
                VariavelResultado = "Volume (mL/24h)",
                UnidadeResultado = "mL",
                Calcular = vars => 4 * vars["peso"] * vars["SCQ"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 021 Pressão Arterial Média ──
            new Formula
            {
                Id = "7_med04", Nome = "Pressão Arterial Média (PAM)", Categoria = "Medicina",
                Expressao = "PAM = PAD + (PAS - PAD) / 3",
                ExprTexto = "PAM = PAD + (PAS − PAD) / 3",
                Icone = "♥",
                Descricao = "Pressão arterial média durante um ciclo cardíaco. Representa a pressão de perfusão dos órgãos. Normal: 70-100 mmHg.",
                Criador = "Fisiologia cardiovascular; uso clínico generalizado",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "PA 120/80: PAM = 80 + (120-80)/3 = 93,3 mmHg",
                Variaveis = [
                    new() { Simbolo = "PAS", Nome = "Pressão Sistólica", Descricao = "Pressão arterial sistólica em mmHg", ValorPadrao = 120, Unidade = "adim" },
                    new() { Simbolo = "PAD", Nome = "Pressão Diastólica", Descricao = "Pressão arterial diastólica em mmHg", ValorPadrao = 80, Unidade = "adim" },
                ],
                VariavelResultado = "PAM",
                UnidadeResultado = "mmHg",
                Calcular = vars => vars["PAD"] + (vars["PAS"] - vars["PAD"]) / 3.0,
                SubCategoria = "",
                Unidades = "",
            },
            // ── 022 Gap Aniônico ──
            new Formula
            {
                Id = "7_med05", Nome = "Gap Aniônico", Categoria = "Medicina",
                Expressao = "AG = Na⁺ - (Cl⁻ + HCO₃⁻)",
                ExprTexto = "AG = Na⁺ − (Cl⁻ + HCO₃⁻)",
                Icone = "AG",
                Descricao = "Diferença entre os principais cátions e ânions medidos. Normal: 8-12 mEq/L. Elevado em cetoacidose diabética, intoxicação por metanol, uremia.",
                Criador = "Bioquímica clínica; Emmett & Narins (1977)",
                AnoOrigin = "1977",
                ExemploPratico = "Na⁺=140, Cl⁻=105, HCO₃⁻=24: AG = 140-(105+24) = 11 mEq/L (normal)",
                Variaveis = [
                    new() { Simbolo = "Na", Nome = "Sódio (Na⁺)", Descricao = "Concentração de sódio em mEq/L", ValorPadrao = 140, Unidade = "adim" },
                    new() { Simbolo = "Cl", Nome = "Cloro (Cl⁻)", Descricao = "Concentração de cloro em mEq/L", ValorPadrao = 105, Unidade = "adim" },
                    new() { Simbolo = "HCO3", Nome = "Bicarbonato (HCO₃⁻)", Descricao = "Concentração de bicarbonato em mEq/L", ValorPadrao = 24, Unidade = "adim" },
                ],
                VariavelResultado = "AG",
                UnidadeResultado = "mEq/L",
                Calcular = vars => vars["Na"] - (vars["Cl"] + vars["HCO3"]),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 023 Equação de Fick (Débito Cardíaco) ──
            new Formula
            {
                Id = "7_med06", Nome = "Equação de Fick (Débito Cardíaco)", Categoria = "Medicina",
                Expressao = "CO = VO₂ / (CaO₂ - CvO₂)",
                ExprTexto = "DC = VO₂ / (CaO₂ − CvO₂)",
                Icone = "DC",
                Descricao = "Calcula débito cardíaco pelo princípio de Fick: consumo de O₂ dividido pela diferença arteriovenosa de O₂. Padrão-ouro invasivo.",
                Criador = "Adolf Fick (1870)",
                AnoOrigin = "1870",
                ExemploPratico = "VO₂=250 mL/min, CaO₂=200, CvO₂=150 mL/L: CO = 250/50 = 5 L/min",
                Variaveis = [
                    new() { Simbolo = "VO2", Nome = "Consumo de O₂ (mL/min)", ValorPadrao = 250, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "CaO2", Nome = "Conteúdo arterial de O₂", Descricao = "mL O₂/L de sangue", ValorPadrao = 200, Unidade = "adim" },
                    new() { Simbolo = "CvO2", Nome = "Conteúdo venoso de O₂", Descricao = "mL O₂/L de sangue", ValorPadrao = 150, Unidade = "adim" },
                ],
                VariavelResultado = "DC (L/min)",
                UnidadeResultado = "L/min",
                Calcular = vars => vars["VO2"] / (vars["CaO2"] - vars["CvO2"]),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 024 Osmolaridade Sérica ──
            new Formula
            {
                Id = "7_med07", Nome = "Osmolaridade Sérica Calculada", Categoria = "Medicina",
                Expressao = "Osm = 2·Na + Glicose/18 + Ureia/6",
                ExprTexto = "Osmolaridade = 2×Na + Glicose/18 + Ureia/6",
                Icone = "Osm",
                Descricao = "Estima a osmolaridade plasmática. Normal: 275-295 mOsm/L. Gap osmolar (medida−estimada) > 10 sugere substâncias osmoticamente ativas.",
                Criador = "Bioquímica clínica; Dorwart & Chalmers (1975)",
                AnoOrigin = "1975",
                ExemploPratico = "Na=140, Glicose=90, Ureia=30: Osm = 280+5+5 = 290 mOsm/L",
                Variaveis = [
                    new() { Simbolo = "Na", Nome = "Sódio (mEq/L)", ValorPadrao = 140, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Glic", Nome = "Glicose (mg/dL)", ValorPadrao = 90, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "Ureia", Nome = "Ureia (mg/dL)", ValorPadrao = 30, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "Osmolaridade",
                UnidadeResultado = "mOsm/L",
                Calcular = vars => 2 * vars["Na"] + vars["Glic"] / 18.0 + vars["Ureia"] / 6.0,
                SubCategoria = "",
                Unidades = "",
            },
            // ── 025 Taxa de Filtração Glomerular (CKD-EPI) ──
            new Formula
            {
                Id = "7_med08", Nome = "TFG estimada (CKD-EPI simplificada)", Categoria = "Medicina",
                Expressao = "TFG = 141 · min(Cr/κ,1)^α · max(Cr/κ,1)^(-1.209) · 0.993^idade",
                ExprTexto = "TFG ≈ 141 × (Cr/κ)^α × 0,993^idade  (κ,α dependem do sexo)",
                Icone = "TFG",
                Descricao = "Estima a função renal. Valores normais >90 mL/min/1,73m². Versão simplificada: usa creatinina, idade. CKD-EPI é mais precisa que MDRD.",
                Criador = "CKD-EPI Collaboration (Levey et al., 2009)",
                AnoOrigin = "2009",
                ExemploPratico = "Mulher 55 anos, Cr=0,8: TFG ≈ 85 mL/min/1,73m² (normal)",
                Variaveis = [
                    new() { Simbolo = "Cr", Nome = "Creatinina sérica (mg/dL)", ValorPadrao = 0.8, ValorMin = 0.1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "idade", Nome = "Idade (anos)", ValorPadrao = 55, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "kappa", Nome = "κ (0.7 fem, 0.9 masc)", Descricao = "Constante por sexo", ValorPadrao = 0.7, Unidade = "adim" },
                    new() { Simbolo = "alpha", Nome = "α (-0.329 fem, -0.411 masc)", Descricao = "Expoente por sexo", ValorPadrao = -0.329, Unidade = "adim" },
                ],
                VariavelResultado = "TFG",
                UnidadeResultado = "mL/min/1,73m²",
                Calcular = vars => {
                    double cr = vars["Cr"], k = vars["kappa"], a = vars["alpha"], age = vars["idade"];
                    double minVal = Math.Min(cr / k, 1.0);
                    double maxVal = Math.Max(cr / k, 1.0);
                    return 141 * Math.Pow(minVal, a) * Math.Pow(maxVal, -1.209) * Math.Pow(0.993, age);
                },
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ MEDICINA VETERINÁRIA (2 fórmulas) ═══

            // ── 026 Dose por Peso Animal ──
            new Formula
            {
                Id = "7_vet01", Nome = "Dose por Peso Animal", Categoria = "Medicina Veterinária",
                Expressao = "D = dose_kg · peso",
                ExprTexto = "Dose total = dose por kg × peso do animal",
                Icone = "🐾",
                Descricao = "Cálculo de dosagem medicamentosa veterinária baseada no peso corporal. Essencial para posologia em diferentes espécies animais.",
                Criador = "Farmacologia veterinária; Riviere & Papich",
                AnoOrigin = "Séc. XX",
                ExemploPratico = "Amoxicilina 20 mg/kg para cão de 15 kg: D = 20×15 = 300 mg",
                Variaveis = [
                    new() { Simbolo = "dose_kg", Nome = "Dose por kg (mg/kg)", Descricao = "Dosagem unitária por kg", ValorPadrao = 20, Unidade = "adim" },
                    new() { Simbolo = "peso", Nome = "Peso do animal (kg)", ValorPadrao = 15, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "D (mg)",
                UnidadeResultado = "mg",
                Calcular = vars => vars["dose_kg"] * vars["peso"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 027 Escala Alométrica Veterinária ──
            new Formula
            {
                Id = "7_vet02", Nome = "Escala Alométrica Veterinária", Categoria = "Medicina Veterinária",
                Expressao = "Dose = a · M^b",
                ExprTexto = "Dose = a × Massa^b  (escala alométrica)",
                Icone = "M^b",
                Descricao = "Ajuste de dose entre espécies usando relação alométrica. O expoente b ≈ 0,75 (taxa metabólica) ou 1,0 (volume de distribuição).",
                Criador = "Kleiber (1932); adaptação veterinária por Mordenti (1986)",
                AnoOrigin = "1986",
                ExemploPratico = "a=10, b=0.75, M=25 kg: Dose = 10×25⁰·⁷⁵ = 10×11,18 = 111,8 mg",
                Variaveis = [
                    new() { Simbolo = "a", Nome = "Coeficiente (a)", Descricao = "Constante específica do fármaco", ValorPadrao = 10, Unidade = "adim" },
                    new() { Simbolo = "M", Nome = "Massa corporal (kg)", ValorPadrao = 25, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "b", Nome = "Expoente alométrico (b)", Descricao = "~0,75 para metabolismo", ValorPadrao = 0.75, Unidade = "adim" },
                ],
                VariavelResultado = "Dose (mg)",
                UnidadeResultado = "mg",
                Calcular = vars => vars["a"] * Math.Pow(vars["M"], vars["b"]),
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ NUTRIÇÃO (4 fórmulas) ═══

            // ── 028 Harris-Benedict (Taxa Metabólica Basal) ──
            new Formula
            {
                Id = "7_nut01", Nome = "Harris-Benedict (TMB Homem)", Categoria = "Nutrição",
                Expressao = "TMB = 88.362 + 13.397·P + 4.799·A − 5.677·I",
                ExprTexto = "TMB = 88,362 + 13,397×Peso + 4,799×Altura − 5,677×Idade",
                Icone = "🔥",
                Descricao = "Estima o gasto energético basal (kcal/dia) em homens. Revisada por Roza & Shizgal (1984). Base para cálculo de necessidades nutricionais.",
                Criador = "Harris & Benedict (1918); revisada por Roza & Shizgal (1984)",
                AnoOrigin = "1918",
                ExemploPratico = "Homem 30 anos, 75 kg, 175 cm: TMB = 88,36+1004,78+839,83-170,31 = 1762,66 kcal/dia",
                Variaveis = [
                    new() { Simbolo = "P", Nome = "Peso (kg)", ValorPadrao = 75, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "A", Nome = "Altura (cm)", ValorPadrao = 175, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "I", Nome = "Idade (anos)", ValorPadrao = 30, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "TMB",
                UnidadeResultado = "kcal/dia",
                Calcular = vars => 88.362 + 13.397 * vars["P"] + 4.799 * vars["A"] - 5.677 * vars["I"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 029 Gasto Energético Total ──
            new Formula
            {
                Id = "7_nut02", Nome = "Gasto Energético Total (GET)", Categoria = "Nutrição",
                Expressao = "GET = TMB × FA",
                ExprTexto = "GET = TMB × Fator de Atividade",
                Icone = "🏃",
                Descricao = "Gasto calórico diário total = TMB multiplicada pelo fator de atividade. FA: 1,2 (sedentário), 1,375 (leve), 1,55 (moderada), 1,725 (intensa), 1,9 (muito intensa).",
                Criador = "FAO/OMS; guidelines nutricionais",
                AnoOrigin = "1985",
                ExemploPratico = "TMB=1750 kcal, atividade moderada (1,55): GET = 1750×1,55 = 2712,5 kcal/dia",
                Variaveis = [
                    new() { Simbolo = "TMB", Nome = "Taxa Metab. Basal (kcal)", ValorPadrao = 1750, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "FA", Nome = "Fator de Atividade", Descricao = "1,2 a 1,9", ValorPadrao = 1.55, Unidade = "adim" },
                ],
                VariavelResultado = "GET",
                UnidadeResultado = "kcal/dia",
                Calcular = vars => vars["TMB"] * vars["FA"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 030 Cálculo de Macronutrientes ──
            new Formula
            {
                Id = "7_nut03", Nome = "Calorias de Macronutrientes", Categoria = "Nutrição",
                Expressao = "E = 4·P + 4·C + 9·G",
                ExprTexto = "Energia = 4×Proteínas + 4×Carboidratos + 9×Gorduras",
                Icone = "🍎",
                Descricao = "Energia total dos macronutrientes: proteínas e carboidratos = 4 kcal/g, gorduras = 9 kcal/g. Base da contagem calórica alimentar.",
                Criador = "Wilbur Atwater (1896); fatores de Atwater",
                AnoOrigin = "1896",
                ExemploPratico = "50g proteína, 250g carb, 60g gordura: E = 200+1000+540 = 1740 kcal",
                Variaveis = [
                    new() { Simbolo = "P", Nome = "Proteínas (g)", ValorPadrao = 50, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "C", Nome = "Carboidratos (g)", ValorPadrao = 250, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "G", Nome = "Gorduras (g)", ValorPadrao = 60, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "E (kcal)",
                UnidadeResultado = "kcal",
                Calcular = vars => 4 * vars["P"] + 4 * vars["C"] + 9 * vars["G"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 031 Necessidade Hídrica ──
            new Formula
            {
                Id = "7_nut04", Nome = "Necessidade Hídrica (Holiday-Segar)", Categoria = "Nutrição",
                Expressao = "Vol = 100·min(P,10) + 50·min(max(P-10,0),10) + 20·max(P-20,0)",
                ExprTexto = "Primeiros 10kg: 100mL/kg; 10-20kg: 50mL/kg; >20kg: 20mL/kg",
                Icone = "💧",
                Descricao = "Cálculo de necessidade hídrica diária pediátrica e adulta pela fórmula de Holiday-Segar. Usada para prescrição de soroterapia IV.",
                Criador = "Holiday & Segar (1957)",
                AnoOrigin = "1957",
                ExemploPratico = "Criança de 25 kg: 100×10 + 50×10 + 20×5 = 1000+500+100 = 1600 mL/dia",
                Variaveis = [
                    new() { Simbolo = "P", Nome = "Peso (kg)", Descricao = "Peso corporal", ValorPadrao = 25, Unidade = "adim" },
                ],
                VariavelResultado = "Volume (mL/dia)",
                UnidadeResultado = "mL/dia",
                Calcular = vars => {
                    double p = vars["P"];
                    double v = 100 * Math.Min(p, 10);
                    if (p > 10) v += 50 * Math.Min(p - 10, 10);
                    if (p > 20) v += 20 * (p - 20);
                    return v;
                },
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ FÍSICA MÉDICA (3 fórmulas) ═══

            // ── 032 Dose Absorvida de Radiação ──
            new Formula
            {
                Id = "7_fme01", Nome = "Dose Absorvida de Radiação", Categoria = "Física Médica",
                Expressao = "D = E / m",
                ExprTexto = "D = Energia absorvida / massa do tecido",
                Icone = "Gy",
                Descricao = "Dose absorvida (Gray): energia depositada por unidade de massa de tecido. 1 Gy = 1 J/kg. Fundamental em radioterapia e proteção radiológica.",
                Criador = "Louis Harold Gray; ICRU",
                AnoOrigin = "1940s",
                ExemploPratico = "2 J absorvidos em 1 kg de tecido: D = 2/1 = 2 Gy",
                Variaveis = [
                    new() { Simbolo = "E", Nome = "Energia absorvida (J)", ValorPadrao = 2, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "m", Nome = "Massa do tecido (kg)", ValorPadrao = 1, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "D",
                UnidadeResultado = "Gy",
                Calcular = vars => vars["E"] / vars["m"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 033 Lei do Inverso do Quadrado (Radiação) ──
            new Formula
            {
                Id = "7_fme02", Nome = "Lei do Inverso do Quadrado", Categoria = "Física Médica",
                Expressao = "I₂ = I₁ · (d₁/d₂)²",
                ExprTexto = "I₂ = I₁ × (d₁ / d₂)²",
                Icone = "1/r²",
                Descricao = "Intensidade de radiação diminui com o quadrado da distância. Fundamental para proteção radiológica e planejamento de radioterapia.",
                Criador = "Johannes Kepler; generalização da lei do inverso do quadrado",
                AnoOrigin = "1604",
                ExemploPratico = "Intensidade a 1m = 100 mR/h. A 3m: I = 100×(1/3)² = 11,1 mR/h",
                Variaveis = [
                    new() { Simbolo = "I1", Nome = "Intensidade inicial (I₁)", ValorPadrao = 100, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "d1", Nome = "Distância inicial (d₁)", ValorPadrao = 1, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "d2", Nome = "Distância final (d₂)", ValorPadrao = 3, ValorMin = 0.001, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "I₂",
                Calcular = vars => vars["I1"] * Math.Pow(vars["d1"] / vars["d2"], 2),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 034 Decaimento Radioativo ──
            new Formula
            {
                Id = "7_fme03", Nome = "Decaimento Radioativo", Categoria = "Física Médica",
                Expressao = "A(t) = A₀ · e^(−λ·t)",
                ExprTexto = "A(t) = A₀ × e^(−λt)",
                Icone = "☢",
                Descricao = "Atividade radioativa em função do tempo. λ = ln(2)/t½. Usado para calcular atividade residual de radiofármacos em medicina nuclear.",
                Criador = "Ernest Rutherford & Frederick Soddy (1902)",
                AnoOrigin = "1902",
                ExemploPratico = "Tc-99m: t½=6h, A₀=740 MBq. Após 12h: A = 740×e^(−0.1155×12) = 185 MBq",
                Variaveis = [
                    new() { Simbolo = "A0", Nome = "Atividade inicial (A₀)", ValorPadrao = 740, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "lambda", Nome = "Const. de decaimento (λ)", Descricao = "λ = ln(2)/t½ em h⁻¹", ValorPadrao = 0.1155, Unidade = "adim" },
                    new() { Simbolo = "t", Nome = "Tempo (h)", ValorPadrao = 12, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                ],
                VariavelResultado = "A(t)",
                UnidadeResultado = "MBq",
                Calcular = vars => vars["A0"] * Math.Exp(-vars["lambda"] * vars["t"]),
                SubCategoria = "",
                Unidades = "",
            },

            // ═══ IMAGIOLOGIA (3 fórmulas) ═══

            // ── 035 Número CT (Hounsfield) ──
            new Formula
            {
                Id = "7_img01", Nome = "Número de Hounsfield (CT)", Categoria = "Imagiologia",
                Expressao = "HU = 1000 · (μ − μ_água) / (μ_água − μ_ar)",
                ExprTexto = "HU = 1000 × (μ − μ_água) / (μ_água − μ_ar)",
                Icone = "CT",
                Descricao = "Escala Hounsfield: quantifica atenuação de raios X. HU(água)=0, HU(ar)=-1000, HU(osso)≈+1000. Base da tomografia computadorizada.",
                Criador = "Godfrey Hounsfield (1971); Nobel em 1979",
                AnoOrigin = "1971",
                ExemploPratico = "Tecido com μ=0,022, μ_água=0,020, μ_ar=0: HU = 1000×(0,022-0,020)/(0,020-0) = 100 HU",
                Variaveis = [
                    new() { Simbolo = "mu", Nome = "μ do tecido", Descricao = "Coef. de atenuação linear do tecido", ValorPadrao = 0.022, Unidade = "adim" },
                    new() { Simbolo = "mu_agua", Nome = "μ da água", Descricao = "Coef. de atenuação da água", ValorPadrao = 0.020, Unidade = "adim" },
                    new() { Simbolo = "mu_ar", Nome = "μ do ar", Descricao = "Coef. de atenuação do ar", ValorPadrao = 0, Unidade = "adim" },
                ],
                VariavelResultado = "HU",
                UnidadeResultado = "HU",
                Calcular = vars => 1000 * (vars["mu"] - vars["mu_agua"]) / (vars["mu_agua"] - vars["mu_ar"]),
                SubCategoria = "",
                Unidades = "",
            },
            // ── 036 Equação de Larmor (Ressonância Magnética) ──
            new Formula
            {
                Id = "7_img02", Nome = "Equação de Larmor (RM)", Categoria = "Imagiologia",
                Expressao = "f = γ · B₀",
                ExprTexto = "f = γ × B₀  (frequência de precessão)",
                Icone = "🧲",
                Descricao = "Frequência de precessão dos spins nucleares em campo magnético. Para ¹H: γ=42,58 MHz/T. Base da ressonância magnética nuclear.",
                Criador = "Joseph Larmor (1897); Felix Bloch & Edward Purcell (NMR, 1946)",
                AnoOrigin = "1897",
                ExemploPratico = "Hidrogênio a 1,5T: f = 42,58×1,5 = 63,87 MHz",
                Variaveis = [
                    new() { Simbolo = "gamma", Nome = "Razão giromagnética (γ)", Descricao = "MHz/T (42,58 para ¹H)", ValorPadrao = 42.58, Unidade = "adim" },
                    new() { Simbolo = "B0", Nome = "Campo magnético (B₀)", Descricao = "Em Tesla", ValorPadrao = 1.5, Unidade = "adim" },
                ],
                VariavelResultado = "f (MHz)",
                UnidadeResultado = "MHz",
                Calcular = vars => vars["gamma"] * vars["B0"],
                SubCategoria = "",
                Unidades = "",
            },
            // ── 037 Coeficiente de Atenuação Linear ──
            new Formula
            {
                Id = "7_img03", Nome = "Atenuação de Fótons (Beer-Lambert)", Categoria = "Imagiologia",
                Expressao = "I = I₀ · e^(−μ·x)",
                ExprTexto = "I = I₀ × e^(−μx)",
                Icone = "I/I₀",
                Descricao = "Atenuação exponencial de fótons ao atravessar matéria. μ = coeficiente de atenuação linear. Base da radiografia, CT e medicina nuclear.",
                Criador = "Beer (1852) / Lambert (1760); aplicação em radiologia",
                AnoOrigin = "1852",
                ExemploPratico = "I₀=1000, μ=0,2 cm⁻¹, x=5 cm: I = 1000×e^(−1) = 368 fótons",
                Variaveis = [
                    new() { Simbolo = "I0", Nome = "Intensidade inicial (I₀)", ValorPadrao = 1000, Descricao = "Parâmetro de entrada.", Unidade = "adim" },
                    new() { Simbolo = "mu", Nome = "Coef. atenuação (μ)", Descricao = "cm⁻¹", ValorPadrao = 0.2, Unidade = "adim" },
                    new() { Simbolo = "x", Nome = "Espessura (x)", Descricao = "Em cm", ValorPadrao = 5, Unidade = "adim" },
                ],
                VariavelResultado = "I",
                Calcular = vars => vars["I0"] * Math.Exp(-vars["mu"] * vars["x"]),
                SubCategoria = "",
                Unidades = "",
            },
        ]);
    }
}
