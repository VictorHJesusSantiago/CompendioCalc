# CompendioCalc

<p align="center">
  <b>Calculadora científica multiplataforma com .NET MAUI Blazor Hybrid</b><br/>
  <sub>Android · iOS · macOS (Mac Catalyst) · Windows</sub>
</p>

<p align="center">
  <img alt=".NET 10" src="https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img alt="MAUI" src="https://img.shields.io/badge/MAUI-Blazor%20Hybrid-0EA5E9?style=for-the-badge" />
  <img alt="Razor" src="https://img.shields.io/badge/UI-Razor-2563EB?style=for-the-badge" />
  <img alt="License" src="https://img.shields.io/badge/License-MIT-16A34A?style=for-the-badge" />
  <img alt="Fórmulas" src="https://img.shields.io/badge/Fórmulas-4703%2B-F59E0B?style=for-the-badge" />
</p>

---

### Idioma / Language / Idioma

[English](README.md) · **[Português](README_PT.md)** · [Español](README_ES.md)

---

## Visão Geral

O CompendioCalc é um aplicativo cross-platform com objetivo de reunir **mais de 10.000 fórmulas e equações** de todas as áreas do conhecimento que utilizam cálculos matemáticos — das ciências exatas às ciências sociais, saúde, artes e além. O usuário pode:

- **Calcular** qualquer fórmula inserindo os valores das variáveis
- **Navegar** por área, categoria ou subcategoria
- **Ler** descrições com contexto histórico e atribuição do criador
- **Buscar** em tempo real em todo o compêndio
- **Salvar** favoritos e revisar o histórico de cálculos

---

## Estado Atual

| Métrica | Valor |
|---|---|
| **Total de fórmulas / equações** | **4.703+** |
| **Áreas do conhecimento** | **56** |
| **Meta** | **10.000+** |
| **Plataformas** | Windows, Android, iOS, macOS |
| **Framework** | .NET 10 · MAUI Blazor Hybrid |

---

## Áreas do Conhecimento

O compêndio cobre atualmente **56 áreas distintas**:

| Física | Química | Matemática | Biologia | Engenharia |
|---|---|---|---|---|
| Estatística | Economia | Medicina | Geografia | Filosofia |
| Sociologia | Psicologia | Artes | Farmácia | Nutrição |
| Veterinária | Epidemiologia | Genética Médica | Neurociências | Saúde Pública |
| Oceanografia | Astrofísica | Astronomia | Bioinformática | Biotecnologia |
| Ciência de Dados | Segurança da Informação | Esportes | Inovação Tecnológica | Computação |
| Computação Quântica | Comunicação | Direito | Administração | Educação |
| Meio Ambiente | Antropologia | Música / Acústica | Eng. Civil | Eng. Elétrica |
| Eng. Química | Eng. Biomédica | Ciência dos Materiais | Eng. de Computação | Eng. de Petróleo |
| Eng. de Produção | Eng. Mecânica | Eng. Ambiental | Eng. de Materiais | Geofísica |
| Paleontologia | Robótica | Visão Computacional | Inteligência Artificial | Sustentabilidade |
| Química Analítica | — | — | — | — |

---

## Destaques de Conteúdo

<details>
<summary><b>Física — mecânica clássica, quântica, termodinâmica, eletromagnetismo, óptica, fluidos</b></summary>

Leis de Newton, conservação de energia, equação de Schrödinger, equações de Maxwell, equação de Fourier, Navier-Stokes, Bernoulli, lei de Snell, radiação de Planck, relatividade especial e geral.

</details>

<details>
<summary><b>Ciências da Saúde — farmacocinética, epidemiologia, genética, neurociência, nutrição, saúde pública</b></summary>

Henderson-Hasselbalch (pH = pKa + log[A⁻/HA]), Cockcroft-Gault (TFG), modelos SIR/R₀, Hardy-Weinberg, potencial de Nernst, Goldman-Hodgkin-Katz, IMC, Harris-Benedict (TMB), QALY, DALYs, CMI, Esperança de Vida (e₀), TFT.

</details>

<details>
<summary><b>Engenharias — civil, elétrica, mecânica, química, biomédica, ambiental</b></summary>

Flambagem de Euler, critério de Mohr-Coulomb, controlador PID, condução de calor de Fourier, balanço de massa em CSTR, número de Reynolds, Darcy-Weisbach, equação de transformadores, ciclo de Rankine, arrasto de Stokes.

</details>

<details>
<summary><b>Computação e Segurança — algoritmos, ML, teoria da informação, criptografia, computação quântica</b></summary>

Entropia de Shannon, segurança de chaves RSA, paradoxo do aniversário, equação de Bellman (Q-learning), gradiente descendente, atenção (QKV), aceleração de Grover O(√N), algoritmo de Shor.

</details>

<details>
<summary><b>Música / Acústica</b></summary>

Temperamento igual fn = f₀ × 2^(n/12), cents (1200 × log₂(f₂/f₁)), corda vibrante de Mersenne, tempo de reverberação de Sabine T60 = 0,161V/A, NPS em dB, ressonador de Helmholtz, efeito Doppler, teorema de Nyquist.

</details>

---

## Modelo de Dados

```csharp
public class Formula {
    public string Id { get; set; }
    public string CodigoCompendio { get; set; }   // Códigos oficiais 001–387
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public string SubCategoria { get; set; }
    public string Expressao { get; set; }          // Expressão simbólica
    public string Descricao { get; set; }
    public string Criador { get; set; }
    public string AnoOrigin { get; set; }
    public string ReferenciaBibliografica { get; set; }
    public List<Variavel> Variaveis { get; set; }
    public Func<Dictionary<string, double>, double>? Calcular { get; set; }
    public string VariavelResultado { get; set; }
    public string UnidadeResultado { get; set; }
}
```

---

## Stack Tecnológico

| Componente | Tecnologia |
|---|---|
| Framework | .NET 10 + .NET MAUI |
| UI | Blazor Hybrid (componentes Razor) |
| Linguagem | C# |
| Windows | `net10.0-windows10.0.19041.0` |
| Android | `net10.0-android` |
| iOS | `net10.0-ios` |
| macOS | `net10.0-maccatalyst` |

---

## Pré-requisitos

1. **.NET 10 SDK** — [dotnet.microsoft.com/download/dotnet/10.0](https://dotnet.microsoft.com/download/dotnet/10.0)
2. **Workload MAUI** — `dotnet workload install maui`
3. **Android Studio + SDK** — para target Android
4. **Xcode** — para iOS / macOS (apenas macOS)

---

## Como Rodar

```powershell
# Windows
dotnet run -f net10.0-windows10.0.19041.0

# Android
dotnet run -f net10.0-android

# iOS
dotnet run -f net10.0-ios

# macOS
dotnet run -f net10.0-maccatalyst
```

---

## Estrutura do Projeto

```
CompendioCalc/
├── Models/
│   └── Formula.cs
├── Services/
│   ├── FormulaService.cs
│   ├── FormulaService.CompendioAudit.cs
│   ├── FormulaService_ConsolidatedAreasCatalogLoader.cs
│   ├── FormulaService_Vol*.cs                   ← Volumes I–IX
│   └── FormulaServiceConsolidadas_[Area].cs      ← 56 arquivos por área
└── Components/Pages/
    ├── Home.razor · Categorias.razor · Buscar.razor
    ├── Favoritos.razor · Historico.razor · FormulaCalc.razor
```

---

## Volumes e Áreas Consolidadas

| Volume | Foco | Fórmulas |
|---|---|---|
| I | Fundamentos (álgebra, cálculo, física, estatística) | ~130 |
| II | Bases avançadas e modelagem (TQC, deep learning, topologia) | ~603 |
| III | Intermediário-superior aplicado | ~532 |
| IV | Fronteira teórica e IA moderna | ~532 |
| V | Ciências naturais, computação, economia quantitativa | ~399 |
| VI | Matemática aplicada de ponta | ~442 |
| VII | Fronteiras do conhecimento | ~249 |
| IX | Compêndio Geral: teoria dos jogos → relatividade geral | ~360 |
| **Áreas Consolidadas (56 arquivos)** | Todos os domínios | **1.456+** |
| **TOTAL** | | **4.703+** |

---

## Como Adicionar Fórmulas

Cada área possui o arquivo `Services/FormulaServiceConsolidadas_[Area].cs`:

```csharp
private void AdicionarFormulasConsolidadas_[Area]()
{
    _formulas.AddRange(new List<Formula>
    {
        new Formula {
            Id = "C####",
            Nome = "Nome da Fórmula",
            Categoria = "Categoria",
            SubCategoria = "Subcategoria",
            Expressao = "f(x) = ...",
            Descricao = "Descrição com contexto histórico e aplicações.",
            Criador = "Nome do Criador",
            AnoOrigin = "ano",
            Variaveis = new List<Variavel> {
                new Variavel {
                    Simbolo = "x", Nome = "Nome da variável",
                    Unidade = "unidade", ValorPadrao = 1.0, ValorMin = 0
                }
            },
            Calcular = v => v["x"] * Math.Sqrt(v["x"]),
            VariavelResultado = "resultado",
            UnidadeResultado = "unidade"
        }
    });
}
```

O orquestrador em `FormulaService_ConsolidatedAreasCatalogLoader.cs` chama todos os 56 métodos de área na inicialização.

---

## Comandos Úteis

```powershell
dotnet restore
dotnet build -f net10.0-windows10.0.19041.0
dotnet clean

# Contar fórmulas no código-fonte
(Select-String -Path "Services\*.cs" -Pattern "new Formula\b" | Measure-Object).Count
```

---

## Licença

[MIT License](LICENSE) — livre para usar, modificar e distribuir.
