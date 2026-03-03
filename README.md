# Compêndio de Equações — Volume I
### Aplicativo Calculadora Científica em .NET MAUI Blazor Hybrid

---

## Visão Geral

Aplicativo **cross-platform** que funciona em:
- 📱 **Android**
- 🖥️ **Windows** (desktop)

**Tecnologia:** .NET 10 + MAUI Blazor Hybrid

**Conteúdo:** Volume I do Compêndio — 50+ fórmulas fundamentais em 16 categorias com calculadora interativa para cada uma.

---

## Pré-requisitos

### 1. Instalar o .NET 10 SDK
Baixe em: https://dotnet.microsoft.com/download/dotnet/10.0

Verifique:
```bash
dotnet --list-sdks
# deve aparecer 10.x.xxx
```

### 2. Instalar o workload MAUI
```bash
dotnet workload install maui
```

### 3. (Apenas Android) Android SDK
Instale o [Android Studio](https://developer.android.com/studio) e configure um emulador AVD, ou conecte um dispositivo físico via USB com depuração ativada.

---

## Como Rodar

### Windows
No **PowerShell** (não Git Bash):
```powershell
cd "C:\caminho\para\CompendioCalc"
dotnet run -f net10.0-windows10.0.19041.0
```

Ou pelo VS Code: pressione **F5** (requer a extensão `.NET MAUI` instalada).

### Android
```bash
dotnet run -f net10.0-android
```

---

## Estrutura do Projeto

```
CompendioCalc/
├── CompendioCalc.csproj      ← Project file MAUI
├── MauiProgram.cs            ← DI e configuração
├── App.xaml / App.xaml.cs    ← MAUI Application
├── MainPage.xaml             ← Host BlazorWebView
│
├── Models/
│   └── Formula.cs            ← Modelos Formula, Variavel, CategoriaInfo
│
├── Services/
│   ├── FormulaService.cs     ← 50+ fórmulas do Volume I
│   └── CalculadoraService.cs ← Histórico de cálculos
│
├── Components/
│   ├── App.razor             ← Raiz Blazor
│   ├── Routes.razor          ← Roteamento
│   ├── _Imports.razor        ← Using globais
│   ├── Layout/
│   │   └── MainLayout.razor  ← Shell com navegação inferior
│   └── Pages/
│       ├── Home.razor        ← Dashboard
│       ├── Categorias.razor  ← Grid de categorias e listas
│       ├── Buscar.razor      ← Busca em tempo real
│       ├── Favoritos.razor   ← Fórmulas favoritadas
│       ├── Historico.razor   ← Histórico de cálculos
│       └── FormulaCalc.razor ← Calculadora completa por fórmula
│
├── Platforms/
│   ├── Android/
│   │   ├── AndroidManifest.xml
│   │   └── MainActivity.cs
│   └── Windows/
│       ├── App.xaml          ← Entry point WinUI
│       ├── App.xaml.cs
│       └── Package.appxmanifest
│
├── Resources/
│   ├── AppIcon/
│   │   ├── appicon.svg
│   │   └── appiconfg.svg
│   ├── Splash/
│   │   └── splash.svg
│   └── Styles/
│       ├── Colors.xaml
│       └── Styles.xaml
│
└── wwwroot/
    ├── index.html            ← HTML host
    └── css/
        └── app.css           ← Design system completo
```

---

## Categorias Incluídas (Volume I)

| # | Categoria | Fórmulas |
|---|-----------|----------|
| 1 | Álgebra | Bhaskara, PA, PG, Juros Compostos, Binômio de Newton |
| 2 | Geometria | Pitágoras, Heron, Círculo, Esfera, Circunferência, Distância |
| 3 | Trigonometria | Lei dos Cossenos, Lei dos Senos, Identidade Fundamental, Euler |
| 4 | Cálculo | Derivada, Regra da Cadeia, Integral, Taylor, L'Hôpital, Gradiente |
| 5 | Álgebra Linear | Produto Escalar, Determinante, Norma, Autovalores |
| 6 | Equações Diferenciais | Exponencial, Oscilador Harmônico, Difusão, Logística |
| 7 | Probabilidade | Bayes, Normal, Poisson, Valor Esperado |
| 8 | Estatística | Média/Variância, Pearson, Intervalo de Confiança |
| 9 | Mecânica Clássica | Newton F=ma, Cinética, Gravitação, Conservação, Cinemática |
| 10| Termodinâmica | 1ª Lei, Entropia, Stefan-Boltzmann, Carnot, Gás Ideal |
| 11| Eletromagnetismo | Coulomb, Lei de Ohm, Potência, Faraday |
| 12| Óptica | Snell, Equação de Gauss |
| 13| Mecânica dos Fluidos | Bernoulli, Continuidade |
| 14| Engenharia | Lei de Hooke, Tensão Normal, Transformadores |
| 15| Biologia Matemática | Lotka-Volterra, Michaelis-Menten, Hodgkin-Huxley |
| 16| Computação | Complexidade O(log n), Entropia de Shannon, DFT/FFT, Perceptron |

---

## Adicionar Novas Fórmulas

Em [Services/FormulaService.cs](Services/FormulaService.cs), adicione na categoria apropriada:

```csharp
new Formula
{
    Id = "cat001",           // único
    Nome = "Nome da Fórmula",
    Categoria = "Álgebra",   // deve existir em InicializarCategorias()
    Expressao = "f(x) = ...",
    ExprTexto = "f(x) = ...",
    Icone = "f",
    Descricao = "O que é...",
    Criador = "Quem criou (ano)",
    AnoOrigin = "1850",
    ExemploPratico = "Exemplo do mundo real...",
    Variaveis = [
        new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 1 },
    ],
    VariavelResultado = "f(x)",
    Calcular = vars => Math.Sqrt(vars["x"])
}
```

---

## Licença

MIT — use livremente para fins educacionais e comerciais.


---

## Visão Geral

Aplicativo **cross-platform** que funciona em:
- 📱 **Android** (Google Play Store)
- 🍎 **iOS** (App Store)
- 🖥️ **Windows** (Microsoft Store / desktop)
- 🍏 **macOS** (Mac Catalyst)
- 🌐 **Web** (Blazor Server/WASM — deployment separado)

**Tecnologia:** .NET 9 + MAUI Blazor Hybrid

**Conteúdo:** Volume I do Compêndio — 50+ fórmulas fundamentais em 16 categorias com calculadora interativa para cada uma.

---

## Pré-requisitos

```bash
# 1. .NET 9 SDK
dotnet --version  # deve ser 9.x

# 2. Workloads MAUI
dotnet workload install maui
dotnet workload install android ios maccatalyst

# 3. Android: JDK 17 + Android SDK (via Android Studio)
# 4. iOS/macOS: Xcode 15+ (apenas em Mac)
# 5. Windows: Visual Studio 2022 v17.8+ com workload .NET MAUI
```

---

## Como Rodar

### Android (emulador ou físico)
```bash
cd CompendioCalc
dotnet build -f net9.0-android
dotnet run -f net9.0-android
```

### Windows
```bash
dotnet run -f net9.0-windows10.0.19041.0
```

### Via Visual Studio 2022
1. Abrir `CompendioCalc.csproj`
2. Selecionar target no dropdown (Android, iOS, Windows, Mac)
3. Pressionar F5

---

## Publicar para a Play Store

```bash
# Gerar release APK assinado
dotnet publish -f net9.0-android -c Release \
  /p:AndroidSigningKeyStore=mykey.keystore \
  /p:AndroidSigningKeyAlias=myalias \
  /p:AndroidSigningKeyPass=mypassword \
  /p:AndroidSigningStorePass=mystorepassword

# AAB (recomendado para Play Store)
dotnet publish -f net9.0-android -c Release \
  /p:AndroidPackageFormat=aab \
  /p:AndroidSigningKeyStore=mykey.keystore ...
```

### Criar keystore (se não tiver):
```bash
keytool -genkey -v -keystore mykey.keystore -alias myalias \
        -keyalg RSA -keysize 2048 -validity 10000
```

Depois upload o `.aab` no **Google Play Console** → Criar app → Upload bundle.

---

## Publicar como Website (Blazor Server)

Crie um segundo projeto Blazor Server que compartilha os mesmos componentes:

```bash
dotnet new blazorserver -o CompendioWeb
# Copie Components/, Models/, Services/ para o novo projeto
# Ajuste Program.cs para registrar os serviços
dotnet publish -c Release -o ./publish
```

Ou converta para **Blazor WebAssembly** (totalmente no browser, sem servidor).

---

## Estrutura do Projeto

```
CompendioCalc/
├── CompendioCalc.csproj      ← Project file MAUI
├── MauiProgram.cs            ← DI e configuração
├── App.xaml                  ← MAUI App
├── MainPage.xaml             ← Host BlazorWebView
│
├── Models/
│   └── Formula.cs            ← Modelos Formula, Variavel, CategoriaInfo
│
├── Services/
│   ├── FormulaService.cs     ← 50+ fórmulas do Volume I
│   └── CalculadoraService.cs ← Histórico de cálculos
│
├── Components/
│   ├── App.razor             ← Raiz Blazor
│   ├── Routes.razor          ← Roteamento
│   ├── _Imports.razor        ← Using globais
│   ├── Layout/
│   │   └── MainLayout.razor  ← Shell com navegação inferior
│   └── Pages/
│       ├── Home.razor        ← Dashboard
│       ├── Categorias.razor  ← Grid de categorias e listas
│       ├── Buscar.razor      ← Busca em tempo real
│       ├── Favoritos.razor   ← Fórmulas favoritadas
│       ├── Historico.razor   ← Histórico de cálculos
│       └── FormulaCalc.razor ← Calculadora completa por fórmula
│
├── Platforms/
│   └── Android/
│       ├── AndroidManifest.xml
│       └── MainActivity.cs
│
└── wwwroot/
    ├── index.html            ← HTML host
    └── css/
        └── app.css           ← Design system completo
```

---

## Categorias Incluídas (Volume I)

| # | Categoria | Fórmulas |
|---|-----------|----------|
| 1 | Álgebra | Bhaskara, PA, PG, Juros Compostos, Binômio de Newton |
| 2 | Geometria | Pitágoras, Heron, Círculo, Esfera, Circunferência, Distância |
| 3 | Trigonometria | Lei dos Cossenos, Lei dos Senos, Identidade Fundamental, Euler |
| 4 | Cálculo | Derivada, Regra da Cadeia, Integral, Taylor, L'Hôpital, Gradiente |
| 5 | Álgebra Linear | Produto Escalar, Determinante, Norma, Autovalores |
| 6 | Equações Diferenciais | Exponencial, Oscilador Harmônico, Difusão, Logística |
| 7 | Probabilidade | Bayes, Normal, Poisson, Valor Esperado |
| 8 | Estatística | Média/Variância, Pearson, Intervalo de Confiança |
| 9 | Mecânica Clássica | Newton F=ma, Cinética, Gravitação, Conservação, Cinemática |
| 10| Termodinâmica | 1ª Lei, Entropia, Stefan-Boltzmann, Carnot, Gás Ideal |
| 11| Eletromagnetismo | Coulomb, Lei de Ohm, Potência, Faraday |
| 12| Óptica | Snell, Equação de Gauss |
| 13| Mecânica dos Fluidos | Bernoulli, Continuidade |
| 14| Engenharia | Lei de Hooke, Tensão Normal, Transformadores |
| 15| Biologia Matemática | Lotka-Volterra, Michaelis-Menten, Hodgkin-Huxley |
| 16| Computação | Complexidade O(log n), Entropia de Shannon, DFT/FFT, Perceptron |

---

## Adicionar Novas Fórmulas

Em `Services/FormulaService.cs`, adicione na categoria apropriada:

```csharp
new Formula
{
    Id = "cat001",           // único
    Nome = "Nome da Fórmula",
    Categoria = "Álgebra",   // deve existir
    Expressao = "f(x) = ...",
    ExprTexto = "f(x) = ...", // versão renderizável
    Icone = "f",
    Descricao = "O que é...",
    Criador = "Quem criou (ano)",
    AnoOrigin = "1850",
    ExemploPratico = "Exemplo do mundo real...",
    Variaveis = [
        new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 1 },
    ],
    VariavelResultado = "f(x)",
    Calcular = vars => /* expressão C# */ Math.Sqrt(vars["x"])
}
```

---

## Design System

- **Tema:** Escuro · "Observatório Científico"
- **Fundo:** `#0D1117` (deep navy)
- **Acento Principal:** `#D4A64A` (âmbar dourado)
- **Acento Secundário:** `#3DD6C0` (teal)
- **Fonte Título:** Cormorant Garamond (serif elegante)
- **Fonte UI:** DM Sans
- **Fonte Equações:** JetBrains Mono

---

## Licença

MIT — use livremente para fins educacionais e comerciais.
