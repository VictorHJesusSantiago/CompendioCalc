# CompendioCalc

<p align="center">
  <b>Calculadora científica multiplataforma con .NET MAUI Blazor Hybrid</b><br/>
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

[English](README.md) · [Português](README_PT.md) · **[Español](README_ES.md)**

---

## Descripción General

CompendioCalc es una aplicación multiplataforma con el objetivo de reunir **más de 10.000 fórmulas y ecuaciones** de todas las áreas del conocimiento que utilizan cálculos matemáticos — desde las ciencias exactas hasta las ciencias sociales, salud, artes y más. El usuario puede:

- **Calcular** cualquier fórmula ingresando los valores de las variables
- **Explorar** fórmulas por área, categoría o subcategoría
- **Leer** descripciones con contexto histórico y atribución del creador
- **Buscar** en tiempo real en todo el compendio
- **Guardar** favoritos y revisar el historial de cálculos

---

## Estado Actual

| Métrica | Valor |
|---|---|
| **Total de fórmulas / ecuaciones** | **4.703+** |
| **Áreas del conocimiento** | **56** |
| **Meta** | **10.000+** |
| **Plataformas** | Windows, Android, iOS, macOS |
| **Framework** | .NET 10 · MAUI Blazor Hybrid |

---

## Áreas del Conocimiento

El compendio cubre actualmente **56 áreas distintas**:

| Física | Química | Matemáticas | Biología | Ingeniería |
|---|---|---|---|---|
| Estadística | Economía | Medicina | Geografía | Filosofía |
| Sociología | Psicología | Artes | Farmacia | Nutrición |
| Medicina Veterinaria | Epidemiología | Genética Médica | Neurociencias | Salud Pública |
| Oceanografía | Astrofísica | Astronomía | Bioinformática | Biotecnología |
| Ciencia de Datos | Seguridad Informática | Ciencias del Deporte | Innovación Tecnológica | Computación |
| Computación Cuántica | Comunicación | Derecho | Administración | Educación |
| Medio Ambiente | Antropología | Música / Acústica | Ing. Civil | Ing. Eléctrica |
| Ing. Química | Ing. Biomédica | Ciencia de Materiales | Ing. de Computación | Ing. de Petróleo |
| Ing. de Producción | Ing. Mecánica | Ing. Ambiental | Ing. de Materiales | Geofísica |
| Paleontología | Robótica | Visión por Computadora | Inteligencia Artificial | Sostenibilidad |
| Química Analítica | — | — | — | — |

---

## Contenido Destacado

<details>
<summary><b>Física — mecánica clásica, cuántica, termodinámica, electromagnetismo, óptica, fluidos</b></summary>

Leyes de Newton, conservación de energía, ecuación de Schrödinger, ecuaciones de Maxwell, ecuación de Fourier, Navier-Stokes, Bernoulli, ley de Snell, radiación de Planck, relatividad especial y general.

</details>

<details>
<summary><b>Ciencias de la Salud — farmacocinética, epidemiología, genética, neurociencia, nutrición, salud pública</b></summary>

Henderson-Hasselbalch (pH = pKa + log[A⁻/HA]), Cockcroft-Gault (TFG), modelos SIR/R₀, Hardy-Weinberg, potencial de Nernst, Goldman-Hodgkin-Katz, IMC, Harris-Benedict (TMB), QALY, DALYs.

</details>

<details>
<summary><b>Ingeniería — civil, eléctrica, mecánica, química, biomédica, ambiental</b></summary>

Pandeo de Euler, criterio de Mohr-Coulomb, controlador PID, conducción de calor de Fourier, balance de masa CSTR, número de Reynolds, Darcy-Weisbach, ecuación de transformadores, ciclo de Rankine, arrastre de Stokes.

</details>

<details>
<summary><b>Computación y Seguridad — algoritmos, ML, teoría de la información, criptografía, computación cuántica</b></summary>

Entropía de Shannon, seguridad de claves RSA, paradoja del cumpleaños, ecuación de Bellman (Q-learning), descenso de gradiente, atención (QKV), aceleración de Grover O(√N), algoritmo de Shor.

</details>

<details>
<summary><b>Música / Acústica</b></summary>

Temperamento igual fn = f₀ × 2^(n/12), cents (1200 × log₂(f₂/f₁)), cuerda vibrante de Mersenne, tiempo de reverberación de Sabine T60 = 0,161V/A, NPS en dB, resonador de Helmholtz, efecto Doppler, teorema de Nyquist.

</details>

---

## Modelo de Datos

```csharp
public class Formula {
    public string Id { get; set; }
    public string CodigoCompendio { get; set; }   // Códigos oficiales 001–387
    public string Nome { get; set; }              // Nombre
    public string Categoria { get; set; }
    public string SubCategoria { get; set; }
    public string Expressao { get; set; }         // Expresión simbólica
    public string Descricao { get; set; }         // Descripción
    public string Criador { get; set; }           // Creador
    public string AnoOrigin { get; set; }         // Año de origen
    public List<Variavel> Variaveis { get; set; }
    public Func<Dictionary<string, double>, double>? Calcular { get; set; }
    public string VariavelResultado { get; set; }
    public string UnidadeResultado { get; set; }
}
```

---

## Stack Tecnológico

| Componente | Tecnología |
|---|---|
| Framework | .NET 10 + .NET MAUI |
| UI | Blazor Hybrid (componentes Razor) |
| Lenguaje | C# |
| Windows | `net10.0-windows10.0.19041.0` |
| Android | `net10.0-android` |
| iOS | `net10.0-ios` |
| macOS | `net10.0-maccatalyst` |

---

## Requisitos Previos

1. **.NET 10 SDK** — [dotnet.microsoft.com/download/dotnet/10.0](https://dotnet.microsoft.com/download/dotnet/10.0)
2. **Workload MAUI** — `dotnet workload install maui`
3. **Android Studio + SDK** — para target Android
4. **Xcode** — para iOS / macOS (solo macOS)

---

## Cómo Ejecutar

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

## Estructura del Proyecto

```
CompendioCalc/
├── Models/
│   └── Formula.cs
├── Services/
│   ├── FormulaService.cs
│   ├── FormulaService.CompendioAudit.cs
│   ├── FormulaService_ConsolidatedAreasCatalogLoader.cs
│   ├── FormulaService_Vol*.cs                    ← Volúmenes I–IX
│   └── FormulaServiceConsolidadas_[Area].cs       ← 56 archivos por área
└── Components/Pages/
    ├── Home.razor · Categorias.razor · Buscar.razor
    ├── Favoritos.razor · Historico.razor · FormulaCalc.razor
```

---

## Volúmenes y Áreas Consolidadas

| Volumen | Enfoque | Fórmulas |
|---|---|---|
| I | Fundamentos (álgebra, cálculo, física, estadística) | ~130 |
| II | Bases avanzadas y modelado (TCC, deep learning, topología) | ~603 |
| III | Intermedio-superior aplicado | ~532 |
| IV | Frontera teórica e IA moderna | ~532 |
| V | Ciencias naturales, computación, economía cuantitativa | ~399 |
| VI | Matemática aplicada de vanguardia | ~442 |
| VII | Fronteras del conocimiento | ~249 |
| IX | Compendio General: teoría de juegos → relatividad general | ~360 |
| **Áreas Consolidadas (56 archivos)** | Todos los dominios | **1.456+** |
| **TOTAL** | | **4.703+** |

---

## Agregar Nuevas Fórmulas

Cada área tiene su propio archivo `Services/FormulaServiceConsolidadas_[Area].cs`:

```csharp
private void AdicionarFormulasConsolidadas_[Area]()
{
    _formulas.AddRange(new List<Formula>
    {
        new Formula {
            Id = "C####",
            Nome = "Nombre de la Fórmula",
            Categoria = "Categoría",
            SubCategoria = "Subcategoría",
            Expressao = "f(x) = ...",
            Descricao = "Descripción con contexto histórico y aplicaciones.",
            Criador = "Nombre del Creador",
            AnoOrigin = "año",
            Variaveis = new List<Variavel> {
                new Variavel {
                    Simbolo = "x", Nome = "Nombre de variable",
                    Unidade = "unidad", ValorPadrao = 1.0, ValorMin = 0
                }
            },
            Calcular = v => v["x"] * Math.Sqrt(v["x"]),
            VariavelResultado = "resultado",
            UnidadeResultado = "unidad"
        }
    });
}
```

El orquestador en `FormulaService_ConsolidatedAreasCatalogLoader.cs` llama a los 56 métodos de área al iniciar.

---

## Comandos Útiles

```powershell
dotnet restore
dotnet build -f net10.0-windows10.0.19041.0
dotnet clean

# Contar fórmulas en el código fuente
(Select-String -Path "Services\*.cs" -Pattern "new Formula\b" | Measure-Object).Count
```

---

## Licencia

[MIT License](LICENSE) — libre para usar, modificar y distribuir.
