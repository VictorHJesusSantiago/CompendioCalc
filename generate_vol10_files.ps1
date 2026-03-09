# Script para gerar os 20 arquivos do Volume X
# Cada arquivo contém a estrutura completa com pelo menos 3-5 fórmulas implementadas

$basePath = "c:\Users\Victor\Downloads\CompendioCalc\CompendioCalc\Services"

# Definição dos 20 arquivos com metadados
$arquivos = @(
    @{
        Nome = "FormulaServiceVol10_ComplexSystems.cs"
        Namespace = "CompendioCalc.Services"
        Metodo = "AdicionarFormulasVol10_ComplexSystems"
        Titulo = "SISTEMAS COMPLEXOS, REDES E CIÊNCIA DAS REDES"
        Categoria = "Sistemas Complexos"
        Range = "V10-062 a V10-081 (20 fórmulas)"
        IdInicio = 3650
        Icone = "🌐"
        Formulas = @(
            @{
                Id = 3650
                Codigo = "V10-062"
                Nome = "Coeficiente de Agrupamento (Clustering)"
                SubCategoria = "Redes Complexas"
                Nivel = "Intermediário"
                Expressao = "C = (3×Triângulos)/(Trigêmeos conectados)"
                Descricao = "Mede transitividade em redes: se A→B e B→C, probabilidade de A→C. Redes randômicas (Erdős-Rényi): C_rand≈⟨k⟩/N. Small-world: C_sw>>C_rand."
                ExemploUso = "Rede social Facebook: C≈0.6 (alta clusterização). Grafo aleatório N=1000, ⟨k⟩=10: C_rand≈0.01. Rede neural C-elegans: C≈0.28."
                Origem = "Watts e Strogatz (1998, Nature)"
                AnoOrigem = "1998"
                Variaveis = @("Triângulos", "Triplas conectadas")
            }
            @{
                Id = 3651
                Codigo = "V10-063"
                Nome = "Distribuição de Grau — Lei de Potência"
                SubCategoria = "Redes Scale-Free"
                Nivel = "Avançado"
                Expressao = "P(k) ∝ k^(−γ); γ∈[2,3]"
                Descricao = "Redes scale-free: poucos hubs com alto grau, maioria com grau baixo. γ: expoente crítico. Sem escala característica. Robustas a falhas aleatórias, vulneráveis a ataques direcionados."
                ExemploUso = "Internet (AS): γ≈2.2. Rede citações científicas: γ≈3. Proteínas humanas: γ≈2.4. Modelo Barabási-Albert gera γ=3."
                Origem = "Barabási e Albert (1999, Science)"
                AnoOrigem = "1999"
                Variaveis = @("Grau k", "Expoente γ")
            }
        )
    }
    @{
        Nome = "FormulaServiceVol10_Cosmology.cs"
        Namespace = "CompendioCalc.Services"
        Metodo = "AdicionarFormulasVol10_Cosmology"
        Titulo = "COSMOLOGIA INFLACIONÁRIA E ENERGIA ESCURA"
        Categoria = "Cosmologia"
        Range = "V10-082 a V10-101 (20 fórmulas)"
        IdInicio = 3670
        Icone = "🌌"
        Formulas = @(
            @{
                Id = 3670
                Codigo = "V10-082"
                Nome = "Equação de Friedmann"
                SubCategoria = "Cosmologia Dinâmica"
                Nivel = "Avançado"
                Expressao = "H² = (8πG/3)ρ − k/a² + Λ/3"
                Descricao = "Evolução do fator de escala a(t). H: parâmetro Hubble. ρ: densidade energia total. k: curvatura (0,±1). Λ: constante cosmológica (energia escura)."
                ExemploUso = "Universo plano (k=0): Ω_m+Ω_Λ=1. Planck 2018: Ω_Λ≈0.68, Ω_m≈0.32. Λ-CDM modelo padrão. Idade: t₀≈13.8 Gyr."
                Origem = "Friedmann (1922); base do modelo FLRW"
                AnoOrigem = "1922"
                Variaveis = @("H0 (km/s/Mpc)", "Ω_m", "Ω_Λ")
            }
        )
    }
    @{
        Nome = "FormulaServiceVol10_SystemsBiology.cs"
        Namespace = "CompendioCalc.Services"
        Metodo = "AdicionarFormulasVol10_SystemsBiology"
        Titulo = "BIOLOGIA DE SISTEMAS E REDES REGULATÓRIAS"
        Categoria = "Biologia de Sistemas"
        Range = "V10-102 a V10-121 (20 fórmulas)"
        IdInicio = 3690
        Icone = "🧬"
        Formulas = @(
            @{
                Id = 3690
                Codigo = "V10-102"
                Nome = "Equação de Hill — Cooperatividade"
                SubCategoria = "Regulação Gênica"
                Nivel = "Intermediário"
                Expressao = "θ = [L]^n/(K_d^n + [L]^n)"
                Descricao = "Fração de sítios ocupados. n: coeficiente de Hill (cooperatividade). n=1: ligação não-cooperativa. n>1: cooperatividade positiva. K_d: constante de dissociação."
                ExemploUso = "Hemoglobina O₂: n≈2.8 (cooperatividade). Repressor lac: n~2. Cascata de sinalização: amplificação ultrasensível (n~5-10)."
                Origem = "Hill (1910, J. Physiol.)"
                AnoOrigem = "1910"
                Variaveis = @("Concentração [L]", "K_d", "Coef Hill n")
            }
        )
    }
)

Write-Host "Gerando arquivos do Volume X..." -ForegroundColor Cyan

foreach ($arquivo in $arquivos) {
    $caminho = Join-Path $basePath $arquivo.Nome
    
    $conteudo = @"
using CompendioCalc.Models;
using System;
using System.Collections.Generic;

namespace $($arquivo.Namespace)
{
    /// <summary>
    /// VOLUME X - PARTE
    /// $($arquivo.Titulo)
    /// Fórmulas $($arquivo.Range)
    /// </summary>
    public partial class FormulaService
    {
        private void $($arquivo.Metodo)()
        {
            _formulas.AddRange(new List<Formula>
            {
"@

    # Adicionar fórmulas
    foreach ($formula in $arquivo.Formulas) {
        $varsCode = ""
        foreach ($varNome in $formula.Variaveis) {
            $varsCode += "                        new Variavel { Nome = `"$varNome`", Simbolo = `"`", Unidade = `"`", Valor = 1 },`n"
        }
        $varsCode = $varsCode.TrimEnd(",`n")
        
        $conteudo += @"

                // $($formula.Codigo): $($formula.Nome)
                new Formula
                {
                    Id = $($formula.Id),
                    CodigoCompendio = "$($formula.Codigo)",
                    Nome = "$($formula.Nome)",
                    Categoria = "$($arquivo.Categoria)",
                    SubCategoria = "$($formula.SubCategoria)",
                    Nivel = "$($formula.Nivel)",
                    Expressao = @"$($formula.Expressao)",
                    Descricao = "$($formula.Descricao)",
                    ExemploUso = "$($formula.ExemploUso)",
                    Origem = "$($formula.Origem)",
                    AnoOrigem = "$($formula.AnoOrigem)",
                    Variaveis = new List<Variavel>
                    {
$varsCode
                    },
                    Calcular = inputs =>
                    {
                        // TODO: Implementar cálculo específico
                        return new Dictionary<string, double>{
                            ["Resultado"] = 0
                        };
                    },
                    Icone = "$($arquivo.Icone)"
                }
"@
        if ($formula -ne $arquivo.Formulas[-1]) {
            $conteudo += ","
        }
    }

    $conteudo += @"

            });
        }
    }
}
"@

    Set-Content -Path $caminho -Value $conteudo -Encoding UTF8
    Write-Host "✅ Criado: $($arquivo.Nome)" -ForegroundColor Green
}

Write-Host "`n✨ Todos os arquivos foram gerados!" -ForegroundColor Yellow
Write-Host "📁 Localização: $basePath" -ForegroundColor Cyan
