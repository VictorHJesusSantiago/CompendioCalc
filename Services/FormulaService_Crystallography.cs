using System.Collections.Generic;

namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private void AdicionarFormulasVol12_Cristalografia()
        {
            AdicionarPacoteVol12Detalhado(
                "Cristalografia e Difração de Raios-X",
                "Difração e Estrutura",
                1,
                new List<Vol12FormulaSpec>
                {
                    new("Lei de Bragg", "nλ = 2d·sin θ", "Condição de difração construtiva em planos cristalinos espaçados d; n=ordem, λ=comprimento de onda, θ=ângulo de Bragg.", "W.L. Bragg", "1913", "n=1, d=2 Å, λ=1 Å → sinθ=0,25 → θ≈14,5°"),
                    new("Fator de Estrutura", "F(hkl) = Σⱼ fⱼ exp[2πi(hxⱼ+kyⱼ+lzⱼ)]", "Amplitude de difração do plano (hkl); fⱼ=fator atômico de espalhamento, (xⱼ,yⱼ,zⱼ)=coordenadas fracionárias.", "Cristalografia de Raios-X clássica", "Séc. XX", "Estrutura FCC: extinção quando h+k, k+l, h+l não todos pares"),
                    new("Equação de Scherrer", "τ = Kλ / (β cosθ)", "Tamanho médio de cristalito τ; K≈0,89 (constante de Scherrer), β=largura a meia altura do pico em radianos.", "P. Scherrer", "1918", "λ=1,54 Å, β=0,01 rad, θ=20° → τ≈146 Å"),
                    new("Espaçamento Interplanar Cúbico", "1/d²(hkl) = (h²+k²+l²)/a²", "Espaçamento d entre planos (hkl) em sistema cúbico de parâmetro de rede a.", "Cristalografia geométrica", "Séc. XX", "(110) em Fe (a=2,87 Å): d=2,87/√2≈2,03 Å"),
                    new("Fator de Debye-Waller", "I = I₀ exp(−2M);  M = B sin²θ/λ²", "Redução de intensidade de difração por vibrações térmicas; B=8π²<u²>, u=deslocamento médio quadrático.", "P. Debye; I. Waller", "1913-1923", "B=1 Å², θ=30°, λ=1,54 Å → I/I₀≈0,81"),
                    new("Densidade Eletrônica por Fourier", "ρ(xyz) = (1/V) Σ F(hkl) exp[−2πi(hx+ky+lz)]", "Mapa de densidade eletrônica por síntese de Fourier; V=volume da cela unitária.", "Cristalografia de proteínas", "Séc. XX", "Resolução de estruturas proteicas a 2 Å usa milhares de reflexões"),
                    new("Fração de Empacotamento Atômico (APF)", "APF = (n·V_átomo) / V_cela", "Fração do volume da cela ocupada por átomos; n=átomos por cela, V_átomo=4πr³/3.", "Física do estado sólido", "Séc. XX", "FCC: APF=π/(3√2)≈0,74; BCC: APF=π√3/8≈0,68"),
                    new("Intensidade de Difração de Pó", "I(hkl) ∝ p·|F(hkl)|²·LP·A·T", "Intensidade do pico de pó: p=multiplicidade, LP=fator Lorentz-polarização, A=absorção, T=Debye-Waller.", "Rietveld", "1969", "Refinamento Rietveld ajusta todos os parâmetros simultaneamente"),
                    new("Fator de Lorentz-Polarização", "LP = (1 + cos²2θ) / (sin²θ cosθ)", "Correção geométrica e de polarização para intensidade de difração monocromática.", "H.A. Lorentz; J.J. Thomson", "Séc. XX", "Para θ=15°: LP≈14,7; para θ=45°: LP≈2"),
                    new("Tensão Residual por Difração (sin²ψ)", "εφψ = (dφψ−d₀)/d₀ = (1+ν)/E·σφ·sin²ψ − 2ν/E·(σ₁+σ₂)", "Tensão residual superficial por difração de raios-X; ψ=ângulo de inclinação, φ=direção de medida.", "Técnica sin²ψ, ASTM E915", "Séc. XX", "Aço: mede σ até ≈1 GPa com precisão de ±10 MPa"),
                    new("Rede Recíproca", "a* = (b×c)/V;  b* = (c×a)/V;  c* = (a×b)/V", "Vetores da rede recíproca; V=a·(b×c); fundamentais para interpretar padrões de difração.", "Teoria de redes cristalinas", "Séc. XX", "Cúbico: a*=1/a; rede recíproca também é cúbica"),
                    new("Regra de Extinção Sistemática", "F=0 quando condições de centramento violadas", "Reflexões ausentes indicam simetria translacional: FCC exige h,k,l todos pares ou todos ímpares.", "Teoria de grupos espaciais", "Séc. XX", "BCC: extinção quando h+k+l ímpar; FCC: extinção quando h,k,l mistos"),
                    new("Fator R Ponderado de Rietveld (Rwp)", "Rwp = sqrt(Σwᵢ(yᵢ−ŷᵢ)² / Σwᵢyᵢ²)", "Fator R ponderado no refinamento Rietveld; wᵢ=1/yᵢ; valores Rwp<10% indicam bom ajuste.", "H.M. Rietveld", "1969", "Rwp=7% indica excelente ajuste estrutural"),
                    new("Análise de Microdeformação (Williamson-Hall)", "β cosθ = Kλ/τ + 4ε sinθ", "Separa alargamento de pico por tamanho de cristalito τ e microdeformação ε; gráfico β cosθ vs 4 sinθ.", "G.K. Williamson, W.H. Hall", "1953", "Inclinação=ε, intercepto=Kλ/τ; liga deformada tem alta inclinação"),
                    new("Coeficiente de Absorção de Raios-X", "I = I₀ exp(−μx)", "Atenuação exponencial de raios-X em material de espessura x; μ=coeficiente de absorção linear (cm⁻¹).", "Lei de Beer-Lambert para raios-X", "Séc. XIX-XX", "Fe com Mo Kα (μ=370 cm⁻¹): espessura ótima≈27 μm"),
                    new("Condição de Laue", "a·(s−s₀)=hλ;  b·(s−s₀)=kλ;  c·(s−s₀)=lλ", "Três equações de Laue para difração em rede cristalina; s₀, s=direções incidente e difratada.", "M. von Laue", "1912", "Satisfazer as 3 equações simultaneamente define o vetor de difração"),
                    new("Número de Coordenação por Empacotamento", "η_FCC=12;  η_BCC=8;  η_SC=6;  η_HCP=12", "Número de vizinhos mais próximos nos empacotamentos cúbico de face, corpo, simples e hexagonal.", "Cristalografia clássica", "Séc. XX", "Fe-α (BCC): η=8; Fe-γ (FCC): η=12; maior η implica maior densidade"),
                    new("Euler para Poliedros Cristalinos", "V − E + F = 2", "Vértices V, arestas E, faces F de qualquer poliedro convexo (celas cristalinas incluídas).", "L. Euler", "1750", "Cubo: 8−12+6=2; octaedro: 6−12+8=2"),
                    new("Parâmetro de Rede por DRX (indexação)", "a = d(hkl)·sqrt(h²+k²+l²)  (cúbico)", "Determinação do parâmetro de rede a a partir do espaçamento d medido por DRX e índices de Miller.", "Cristalografia clássica", "Séc. XX", "Al: d(111)=2,338 Å, hkl=111 → a=4,049 Å"),
                    new("Coeficiente de Extinção Primária (DRX)", "Eext = [1+(0,2·g·t·F·λ³)/(V²)]^(−1/2)", "Redução de intensidade por extinção dinâmica; g=fator de geometria, t=espessura, F=fator de estrutura, V=volume de cela.", "Zachariasen", "1945", "Cristais de alta perfeição (Si) exigem correção de extinção")
                });
        }
    }
}
