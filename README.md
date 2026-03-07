# :sparkles: Compêndio de Equações

<p align="center">
  <b>Calculadora científica multiplataforma com .NET MAUI Blazor Hybrid</b><br/>
  <sub>Android | iOS | macOS (Mac Catalyst) | Windows</sub>
</p>

<p align="center">
  <img alt=".NET 10" src="https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img alt="MAUI" src="https://img.shields.io/badge/MAUI-Blazor%20Hybrid-0EA5E9?style=for-the-badge" />
  <img alt="Razor" src="https://img.shields.io/badge/UI-Razor-2563EB?style=for-the-badge" />
  <img alt="License" src="https://img.shields.io/badge/License-MIT-16A34A?style=for-the-badge" />
  <img alt="Status" src="https://img.shields.io/badge/Status-Ativo-F59E0B?style=for-the-badge" />
</p>

<p align="center">
  <a href="#rocket-visão-geral">Visão Geral</a> |
  <a href="#compass-atalhos-rápidos">Atalhos</a> |
  <a href="#gear-stack-e-plataformas">Stack</a> |
  <a href="#runner-como-rodar">Como Rodar</a> |
  <a href="#building_construction-estrutura-do-projeto">Estrutura</a> |
  <a href="#abacus-conteúdo-matemático">Conteúdo</a> |
  <a href="#heavy_plus_sign-como-adicionar-fórmulas">Adicionar Fórmulas</a>
</p>

---

## :compass: Atalhos Rápidos

- [:rocket: Visão Geral](#rocket-visão-geral)
- [:dart: Objetivos do Projeto](#dart-objetivos-do-projeto)
- [:gear: Stack e Plataformas](#gear-stack-e-plataformas)
- [:clipboard: Pré-requisitos](#clipboard-pré-requisitos)
- [:runner: Como Rodar](#runner-como-rodar)
- [:hammer_and_wrench: Comandos Úteis](#hammer_and_wrench-comandos-úteis)
- [:building_construction: Estrutura do Projeto](#building_construction-estrutura-do-projeto)
- [:abacus: Conteúdo Matemático](#abacus-conteúdo-matemático)
- [:heavy_plus_sign: Como Adicionar Fórmulas](#heavy_plus_sign-como-adicionar-fórmulas)
- [:art: Design System](#art-design-system)
- [:wheelchair: Acessibilidade](#wheelchair-acessibilidade)
- [:package: Build e Publicação](#package-build-e-publicação)
- [:test_tube: Troubleshooting](#test_tube-troubleshooting)
- [:handshake: Contribuição](#handshake-contribuição)
- [:page_facing_up: Licença](#page_facing_up-licença)

---

## :rocket: Visão Geral

> [!IMPORTANT]
> Aplicativo cross-platform para estudo, consulta e cálculo de fórmulas de matemática, física, estatística, engenharia, computação e áreas aplicadas.

### :dart: Objetivos do Projeto

- Consolidar um compêndio robusto de fórmulas em um único app.
- Permitir cálculo rápido por variáveis com exemplos de uso real.
- Organizar conhecimento por categorias e volumes para evolução contínua.
- Oferecer UX moderna com foco em legibilidade e produtividade.

### :star2: O que o app entrega hoje

- 2.887 fórmulas/equações distribuídas por domínios e subdomínios.
- Busca em tempo real, favoritos e histórico de cálculos.
- Arquitetura modular por serviços (`FormulaServiceVolX_*.cs`).
- Estrutura preparada para crescimento de conteúdo e melhoria de UX.

---

## :gear: Stack e Plataformas

### Stack principal

- `.NET 10`
- `.NET MAUI`
- `Blazor Hybrid`
- `C#` e `Razor`

### Target frameworks do projeto

- `net10.0-android`
- `net10.0-ios`
- `net10.0-maccatalyst`
- `net10.0-windows10.0.19041.0`

### Pacotes centrais

- `Microsoft.Maui.Controls`
- `Microsoft.AspNetCore.Components.WebView.Maui`
- `Microsoft.Extensions.Logging.Debug`

---

## :clipboard: Pré-requisitos

### 1) .NET 10 SDK

Download: <https://dotnet.microsoft.com/download/dotnet/10.0>

```bash
dotnet --list-sdks
# esperado: 10.x.x
```

### 2) Workloads MAUI

```bash
dotnet workload install maui
```

### 3) Android (para executar e testar)

- Android Studio
- Android SDK
- Emulador AVD ou dispositivo físico com depuração USB

### 4) iOS/macOS (ambiente Apple)

- Xcode compatível
- Ferramentas de build para iOS e Mac Catalyst

---

## :runner: Como Rodar

> [!TIP]
> Em Windows, prefira PowerShell para execução local.

### Windows

```powershell
cd "C:\caminho\para\CompendioCalc"
dotnet run -f net10.0-windows10.0.19041.0
```

### Android

```bash
dotnet run -f net10.0-android
```

### iOS

```bash
dotnet run -f net10.0-ios
```

### macOS (Mac Catalyst)

```bash
dotnet run -f net10.0-maccatalyst
```

### VS Code

- Abra a pasta do projeto.
- Use a task `Rodar CompendioCalc (Windows)`.
- Alternativamente, rode com F5 (com ambiente MAUI configurado).

---

## :hammer_and_wrench: Comandos Úteis

```bash
# restaurar dependências
dotnet restore

# build Windows
dotnet build -f net10.0-windows10.0.19041.0

# build Android
dotnet build -f net10.0-android

# limpar artefatos
dotnet clean
```

---

## :building_construction: Estrutura do Projeto

```text
CompendioCalc/
|-- CompendioCalc.csproj
|-- MauiProgram.cs
|-- App.xaml
|-- App.xaml.cs
|-- MainPage.xaml
|-- MainPage.xaml.cs
|
|-- Models/
|   |-- Formula.cs
|   `-- CompendioRelatorio.cs
|
|-- Services/
|   |-- CalculadoraService.cs
|   |-- FormulaService.cs
|   |-- FormulaService.CompendioAudit.cs
|   |-- FormulaServiceVol1_Complete.cs
|   |-- FormulaServiceVol2_*.cs
|   |-- FormulaServiceVol3_*.cs
|   |-- FormulaServiceVol4_*.cs
|   |-- FormulaServiceVol5_*.cs
|   |-- FormulaServiceVol6_*.cs
|   `-- FormulaServiceVol7_*.cs
|
|-- Components/
|   |-- App.razor
|   |-- Routes.razor
|   |-- _Imports.razor
|   |-- Layout/
|   |   `-- MainLayout.razor
|   `-- Pages/
|       |-- Home.razor
|       |-- Categorias.razor
|       |-- Buscar.razor
|       |-- Favoritos.razor
|       |-- Historico.razor
|       `-- FormulaCalc.razor
|
|-- Platforms/
|   |-- Android/
|   `-- Windows/
|
|-- Resources/
|   |-- AppIcon/
|   |-- Splash/
|   `-- Styles/
|
`-- wwwroot/
    `-- index.html
```

---

## :abacus: Conteúdo Matemático

> [!IMPORTANT]
> Abaixo está o mapa curricular do compêndio, organizado por volume, categoria e exemplos de tópicos, seguido da listagem integral de todas as **2.887 fórmulas/equações** cadastradas no projeto.

### :bookmark_tabs: Visão geral por volume

| Volume | Total de fórmulas | Perfil |
|---|---:|---|
| I | 130 | Fundamentos e núcleo formativo |
| II | 603 | Bases avançadas e modelagem |
| III | 532 | Intermediário-superior aplicado |
| IV | 532 | Fronteira teórica e IA moderna |
| V | 399 | Ciências naturais, computação e economia quantitativa |
| VI | 442 | Matemática aplicada de ponta |
| VII | 249 | Fronteiras do conhecimento |

### :one: Volume I (fundamentos por categoria)

| # | Categoria | Exemplos |
|---|---|---|
| 1 | Álgebra | Bhaskara, PA, PG, juros compostos, binômio de Newton |
| 2 | Geometria | Pitágoras, Heron, área e volume |
| 3 | Trigonometria | Leis dos senos/cossenos, identidade de Euler |
| 4 | Cálculo | Derivada, integral, Taylor, gradiente |
| 5 | Álgebra Linear | Determinante, norma, autovalores |
| 6 | Equações Diferenciais | Soluções exponenciais, oscilador, logística |
| 7 | Probabilidade | Bayes, normal, Poisson |
| 8 | Estatística | Média, variância, correlação, IC |
| 9 | Mecânica Clássica | F=ma, gravidade, energia |
| 10 | Termodinâmica | 1ª lei, entropia, Carnot |
| 11 | Eletromagnetismo | Coulomb, Ohm, potência, Faraday |
| 12 | Óptica | Snell, equação de Gauss |
| 13 | Mecânica dos Fluidos | Bernoulli, continuidade |
| 14 | Engenharia | Hooke, tensão, transformadores |
| 15 | Biologia Matemática | Lotka-Volterra, Michaelis-Menten |
| 16 | Computação | Complexidade, Shannon, FFT, perceptron |

### :two: Volume II (bases avançadas e modelagem)

| # | Categoria | Exemplos |
|---|---|---|
| 1 | Matemática Pura Avançada | Álgebra abstrata, topologia, geometria diferencial, cálculo de variações |
| 2 | Física Avançada | Mecânica analítica, mecânica estatística, relatividade geral, TQC |
| 3 | Estatística e Dados | Séries temporais, análise multivariada, estatística bayesiana |
| 4 | Computação e Sinais | Teoria de grafos, processamento de sinais, processamento de imagem |
| 5 | IA e Aprendizado | Deep learning, otimização, redes e representações |
| 6 | Engenharia de Controle | Controle automático, dinâmica de sistemas, telecom |
| 7 | Biociências Quantitativas | Epidemiologia, farmacocinética, neurociência computacional |

### :three: Volume III (intermediário-superior aplicado)

| # | Categoria | Exemplos |
|---|---|---|
| 1 | Matemática Avançada | Análise funcional, teoria da medida, teoria das categorias |
| 2 | Física de Sistemas Complexos | Matéria condensada, caos e fractais, física de plasmas |
| 3 | Estatística Especializada | Análise de sobrevivência, valores extremos, geoestatística |
| 4 | Engenharia Computacional | Mecânica da fratura, CFD/turbulência, robótica |
| 5 | Aplicações Quantitativas | Finanças quantitativas, pesquisa operacional, ciências do clima |
| 6 | Bio e Acústica Aplicada | Bioinformática, modelagem biológica, acústica computacional |

### :four: Volume IV (fronteira teórica e IA moderna)

| # | Categoria | Exemplos |
|---|---|---|
| 1 | Matemática Estrutural | Geometria simplética, topologia algébrica avançada, formas modulares |
| 2 | Física Teórica | Renormalização, AdS/CFT, cosmologia inflacionária, gravidade quântica |
| 3 | IA e Ciência de Dados | Aprendizado por reforço, GNN, inferência causal, alta dimensionalidade |
| 4 | Engenharia Avançada | Controle não linear/ótimo, semicondutores, codificação e comunicações |
| 5 | Bio e Médica | Morfogênese, imagem médica, biomatemática aplicada |
| 6 | Fronteiras Interdisciplinares | Teoria dos jogos, redes complexas, criptografia pós-quântica |

### :five: Volume V (ciências naturais, computação e economia quantitativa)

| # | Categoria | Exemplos |
|---|---|---|
| 1 | Matemática Pura | Teoria de Lie, números algébricos, geometria riemanniana |
| 2 | Física e Matéria | Mecânica celeste, cristalografia, magnetismo e matéria mole |
| 3 | Estatística e ML | Processos gaussianos, ICA, otimização convexa |
| 4 | Computação Avançada | Algoritmos de aproximação, redes, compiladores, computação paralela |
| 5 | Economia e Sociofísica | DSGE, macroeconomia, microeconomia avançada, econofísica |
| 6 | Bio e Imunologia | Genética quantitativa, imunologia computacional, bioquímica estrutural |
| 7 | Fronteiras Tecnológicas | Privacidade diferencial, aprendizado federado, blockchain, IA explicável |

### :six: Volume VI (matemática aplicada de ponta)

| # | Categoria | Exemplos |
|---|---|---|
| 1 | Matemática Profunda | Sistemas integráveis, geometria tropical, Sobolev e distribuições |
| 2 | Física Avançada | Transporte quântico topológico, óptica não linear, plasma tokamak |
| 3 | IA de Nova Geração | Normalizing flows, flow matching, meta-learning, info bottleneck |
| 4 | Engenharia e Instrumentação | Fotônica, MEMS, modelagem de tráfego/radiativa |
| 5 | Bio e Neurociência | Biologia sintética, radiobiologia, fMRI quantitativo |
| 6 | Ciências Sociais Formais | Design de mecanismos, active inference, geodesia aplicada |
| 7 | Fronteiras Multidisciplinares | Visão computacional, verificação formal, computação quântica avançada |

### :seven: Volume VII (fronteiras do conhecimento)

| # | Categoria | Exemplos |
|---|---|---|
| 1 | Matemática e Saúde | Biomatemática, epidemiologia avançada, modelagem clínica |
| 2 | Engenharia de Sistemas | Sistemas complexos, otimização de infraestrutura, robustez |
| 3 | Economia e Finanças | Econometria moderna, risco, modelos de mercado |
| 4 | Terra e Física | Geofísica, dinâmica terrestre, modelagem ambiental |
| 5 | BioComp e IA | Biologia computacional, IA para ciências da vida |
| 6 | Agro e Ambiente | Modelagem agroambiental, sustentabilidade, previsão ecossistêmica |
| 7 | Artes, Ofícios e Tecnologia | Design computacional, manufatura e inovação aplicada |
| 8 | Tecnologias Emergentes | Sistemas híbridos, tecnologias de ruptura, convergência digital |

### :bar_chart: Classificação global por eixo

| Eixo | Volumes com maior foco |
|---|---|
| Matemática pura e aplicada | I, II, III, IV, V, VI |
| Física teórica e experimental | I, II, III, IV, V, VI, VII |
| Estatística, dados e ML | I, II, III, IV, V, VI, VII |
| Engenharia e computação | I, II, III, IV, V, VI, VII |
| Bio, saúde e ciências interdisciplinares | I, II, III, IV, V, VI, VII |
| Economia, redes e sistemas sociais | III, IV, V, VI, VII |

### :open_file_folder: Listagem integral (2.887 fórmulas/equações)

> [!TIP]
> A listagem está organizada em blocos recolhíveis por volume e categoria para facilitar navegação no GitHub.

<details>
<summary><b>Volume I — 130 fórmulas</b></summary>

#### Categorias
- Biologia Matemática (6)
- Computação (7)
- Cálculo (11)
- Eletromagnetismo (8)
- Engenharia (7)
- Equações Diferenciais (7)
- Estatística (7)
- Geometria (11)
- Mecânica Clássica (10)
- Mecânica dos Fluidos (6)
- Probabilidade (8)
- Termodinâmica (9)
- Trigonometria (8)
- Álgebra (11)
- Álgebra Linear (8)
- Óptica (6)

#### Biologia Matemática

| ID | Fórmula/Equação |
|---|---|
| `bio001` | Modelo de Lotka-Volterra (Predador-Presa) |
| `bio002` | Modelo de Michaelis-Menten (Enzimas) |
| `bio003` | Modelo de Hodgkin-Huxley (Neurônio) |
| `V1-BIO001` | Modelo Malthusiano |
| `V1-BIO002` | Crescimento Logístico Populacional |
| `V1-BIO003` | Taxa de Infecção SIR |

#### Computação

| ID | Fórmula/Equação |
|---|---|
| `comp001` | Complexidade — Logaritmo Binário (Binary Search) |
| `comp002` | Entropia de Shannon (Informação) |
| `comp003` | Transformada de Fourier Discreta (DFT) |
| `comp004` | Perceptron (Neurônio Artificial) |
| `V1-COMP001` | Complexidade O(n²) |
| `V1-COMP002` | Complexidade O(log n) |
| `V1-COMP003` | Relação de Recorrência (Merge Sort) |

#### Cálculo

| ID | Fórmula/Equação |
|---|---|
| `cal001` | Definição de Derivada (Limite) |
| `cal002` | Regra da Cadeia |
| `cal003` | Integral Definida (Teorema Fundamental) |
| `cal004` | Série de Taylor |
| `cal005` | Regra de L'Hôpital |
| `cal006` | Gradiente e Laplaciano |
| `V1-CALC001` | Regra da Potência (Derivada) |
| `V1-CALC002` | Regra da Cadeia |
| `V1-CALC003` | Teorema Fundamental do Cálculo |
| `V1-CALC004` | Série de Taylor |
| `V1-CALC005` | Regra de L'Hôpital |

#### Eletromagnetismo

| ID | Fórmula/Equação |
|---|---|
| `elet001` | Lei de Coulomb |
| `elet002` | Lei de Ohm |
| `elet003` | Potência Elétrica |
| `elet004` | Lei de Faraday — Indução Eletromagnética |
| `V1-ELETRO001` | Lei de Coulomb |
| `V1-ELETRO002` | Lei de Ohm |
| `V1-ELETRO003` | Potência Elétrica |
| `V1-ELETRO004` | Força Magnética em Carga |

#### Engenharia

| ID | Fórmula/Equação |
|---|---|
| `eng001` | Lei de Hooke (Mola) |
| `eng002` | Resistência de Materiais — Tensão Normal |
| `eng003` | Equação de Transformadores |
| `V1-ENG001` | Lei de Hooke |
| `V1-ENG002` | Tensão e Deformação |
| `V1-ENG003` | Deflexão de Viga |
| `V1-ENG004` | Lei de Kirchhoff das Tensões |

#### Equações Diferenciais

| ID | Fórmula/Equação |
|---|---|
| `ode001` | Equação de Crescimento/Decaimento Exponencial |
| `ode002` | Oscilador Harmônico Simples |
| `ode003` | Equação de Difusão (Calor) |
| `ode004` | Equação Logística (Verhulst) |
| `V1-EQD001` | Crescimento Exponencial |
| `V1-EQD002` | Equação Logística |
| `V1-EQD003` | Oscilador Harmônico Simples |

#### Estatística

| ID | Fórmula/Equação |
|---|---|
| `est001` | Média, Variância e Desvio Padrão |
| `est002` | Coeficiente de Correlação de Pearson |
| `est003` | Intervalo de Confiança para Média |
| `V1-STAT001` | Média Aritmética |
| `V1-STAT002` | Variância |
| `V1-STAT003` | Desvio Padrão |
| `V1-STAT004` | Coeficiente de Correlação de Pearson |

#### Geometria

| ID | Fórmula/Equação |
|---|---|
| `geo001` | Teorema de Pitágoras |
| `geo002` | Área do Triângulo (Heron) |
| `geo003` | Área do Círculo |
| `geo004` | Volume da Esfera |
| `geo005` | Equação Geral da Circunferência |
| `geo006` | Distância entre Dois Pontos |
| `V1-GEO001` | Teorema de Pitágoras |
| `V1-GEO002` | Área do Círculo |
| `V1-GEO003` | Volume da Esfera |
| `V1-GEO004` | Área do Triângulo |
| `V1-GEO005` | Volume do Cilindro |

#### Mecânica Clássica

| ID | Fórmula/Equação |
|---|---|
| `mec001` | Segunda Lei de Newton |
| `mec002` | Energia Cinética |
| `mec003` | Lei da Gravitação Universal |
| `mec004` | Conservação de Energia Mecânica |
| `mec005` | Equações de Cinemática (MRUV) |
| `V1-MEC001` | Segunda Lei de Newton |
| `V1-MEC002` | Energia Cinética |
| `V1-MEC003` | Energia Potencial Gravitacional |
| `V1-MEC004` | Quantidade de Movimento |
| `V1-MEC005` | Lei da Gravitação Universal |

#### Mecânica dos Fluidos

| ID | Fórmula/Equação |
|---|---|
| `flu001` | Equação de Bernoulli |
| `flu002` | Equação de Continuidade |
| `V1-FLUIDO001` | Equação de Bernoulli |
| `V1-FLUIDO002` | Equação da Continuidade |
| `V1-FLUIDO003` | Número de Reynolds |
| `V1-FLUIDO004` | Pressão Hidrostática |

#### Probabilidade

| ID | Fórmula/Equação |
|---|---|
| `prob001` | Teorema de Bayes |
| `prob002` | Distribuição Normal — Função de Densidade |
| `prob003` | Distribuição de Poisson |
| `prob004` | Valor Esperado e Variância |
| `V1-PROB001` | Probabilidade Clássica |
| `V1-PROB002` | Teorema de Bayes |
| `V1-PROB003` | Distribuição Binomial |
| `V1-PROB004` | Distribuição de Poisson |

#### Termodinâmica

| ID | Fórmula/Equação |
|---|---|
| `termo001` | Primeira Lei da Termodinâmica |
| `termo002` | Entropia — 2ª Lei da Termodinâmica |
| `termo003` | Lei de Stefan-Boltzmann |
| `termo004` | Eficiência de Carnot |
| `termo005` | Equação de Estado Gás Ideal |
| `V1-TERMO001` | Lei dos Gases Ideais |
| `V1-TERMO002` | Primeira Lei da Termodinâmica |
| `V1-TERMO003` | Calor Específico |
| `V1-TERMO004` | Eficiência de Carnot |

#### Trigonometria

| ID | Fórmula/Equação |
|---|---|
| `trig001` | Lei dos Cossenos |
| `trig002` | Lei dos Senos |
| `trig003` | Identidade Fundamental de Pitágoras |
| `trig004` | Fórmula de Euler |
| `V1-TRIG001` | Lei dos Senos |
| `V1-TRIG002` | Lei dos Cossenos |
| `V1-TRIG003` | Identidade Pitagórica |
| `V1-TRIG004` | Definição de Tangente |

#### Álgebra

| ID | Fórmula/Equação |
|---|---|
| `alg001` | Equação do 2º Grau (Fórmula de Bhaskara) |
| `alg002` | Progressão Aritmética — Termo Geral |
| `alg003` | Progressão Aritmética — Soma |
| `alg004` | Progressão Geométrica — Termo Geral |
| `alg005` | Juros Compostos |
| `alg006` | Binômio de Newton — Coeficiente |
| `V1-ALG001` | Fórmula de Bhaskara |
| `V1-ALG002` | Binômio de Newton |
| `V1-ALG003` | Soma de Progressão Aritmética |
| `V1-ALG004` | Soma de Progressão Geométrica |
| `V1-ALG005` | Equação Linear |

#### Álgebra Linear

| ID | Fórmula/Equação |
|---|---|
| `lin001` | Produto Escalar (Dot Product) |
| `lin002` | Determinante 2×2 |
| `lin003` | Norma de Vetor (Euclidiana) |
| `lin004` | Equação de Autovalores |
| `V1-ALG_LIN001` | Produto Escalar |
| `V1-ALG_LIN002` | Determinante 2×2 |
| `V1-ALG_LIN003` | Multiplicação de Matrizes |
| `V1-ALG_LIN004` | Autovalor (Equação Característica) |

#### Óptica

| ID | Fórmula/Equação |
|---|---|
| `opt001` | Lei de Snell-Descartes (Refração) |
| `opt002` | Equação de Gauss para Lentes Delgadas |
| `V1-OPTICA001` | Lei de Snell |
| `V1-OPTICA002` | Equação de Lentes Delgadas |
| `V1-OPTICA003` | Ampliação Linear |
| `V1-OPTICA004` | Rede de Difração |

</details>

<details>
<summary><b>Volume II — 603 fórmulas</b></summary>

#### Categorias
- Antenas e Telecom (17)
- Análise Complexa (20)
- Análise Multivariada (17)
- Computação Quântica (26)
- Controle Automático (20)
- Cálculo de Variações (19)
- Deep Learning (33)
- Epidemiologia (18)
- Estatística Bayesiana (27)
- Farmacocinética (14)
- Funções Especiais (32)
- Geometria Diferencial (31)
- Mecânica Analítica (25)
- Mecânica Estatística (20)
- Neurociência Computacional (18)
- Processamento de Imagem (18)
- Processamento de Sinais (16)
- Relatividade Geral (20)
- Séries Temporais (17)
- Teoria dos Grafos (22)
- Teoria Quântica de Campos (24)
- Topologia (28)
- Vol2: Antenas e Propagação (3)
- Vol2: Análise Complexa (4)
- Vol2: Análise Multivariada (2)
- Vol2: Biologia Matemática (4)
- Vol2: Computação Quântica (4)
- Vol2: Controle Automático (3)
- Vol2: Cálculo de Variações (2)
- Vol2: Deep Learning (8)
- Vol2: Estatística Bayesiana (1)
- Vol2: Farmacoc inética (1)
- Vol2: Farmacocinética (2)
- Vol2: Funções Especiais (4)
- Vol2: Geometria Diferencial (4)
- Vol2: Mecânica Estatística (6)
- Vol2: Mecânica Lagrangiana (5)
- Vol2: Neurociência (2)
- Vol2: Processamento de Imagem (2)
- Vol2: Processamento de Sinais (2)
- Vol2: Relatividade Geral (3)
- Vol2: Séries Temporais (2)
- Vol2: Teoria dos Grafos (5)
- Vol2: Topologia (4)
- Vol2: Álgebra Abstrata (5)
- Álgebra Abstrata (43)

#### Antenas e Telecom

| ID | Fórmula/Equação |
|---|---|
| `ant_01` | Comprimento de Onda λ |
| `ant_02` | Equação de Friis (Link Budget) |
| `ant_03` | Ganho de Antena (dBi) |
| `ant_04` | Diagrama de Radiação (Dipolo) |
| `ant_05` | Abertura e Largura de Feixe |
| `ant_06` | EIRP (Potência Isotrópica Efetiva) |
| `ant_07` | Impedância de Antena |
| `ant_08` | Coeficiente de Reflexão Γ |
| `ant_09` | Array Linear de Antenas |
| `lt_01` | Capacidade de Shannon |
| `lt_02` | Eb/N₀ e BER |
| `lt_03` | Modulação QAM (M-QAM) |
| `lt_04` | OFDM (Orthogonal FDM) |
| `lt_05` | MIMO — Capacidade |
| `lt_06` | Equação de Radar |
| `lt_07` | Fórmula de Erlang B |
| `lt_08` | 5G NR — Numerologia |

#### Análise Complexa

| ID | Fórmula/Equação |
|---|---|
| `ac_01` | Número Complexo z |
| `ac_02` | Conjugado z̄ |
| `ac_03` | Fórmula de Euler |
| `ac_04` | Identidade de Euler |
| `ac_05` | Equações de Cauchy-Riemann |
| `ac_06` | Derivada Complexa |
| `ac_07` | Equação de Laplace (harmônica) |
| `ac_08` | Teorema de Cauchy-Goursat |
| `ac_09` | Fórmula Integral de Cauchy |
| `ac_10` | Fórmula de Cauchy para Derivadas |
| `ac_11` | Teorema de Liouville |
| `ac_12` | Teorema Fundamental da Álgebra |
| `ac_13` | Série de Laurent |
| `ac_14` | Coeficientes de Laurent |
| `ac_15` | Resíduo Res(f,a) |
| `ac_16` | Resíduo de Polo Simples |
| `ac_17` | Resíduo de Polo de Ordem m |
| `ac_18` | Teorema dos Resíduos |
| `ac_19` | Integral Real via Resíduos |
| `ac_20` | Integral de Mellin-Barnes |

#### Análise Multivariada

| ID | Fórmula/Equação |
|---|---|
| `mv_cl01` | K-Means |
| `mv_cl02` | Clustering Hierárquico |
| `mv_cl03` | Índice Silhouette |
| `mv_cl04` | Distância de Mahalanobis |
| `mv_fa01` | Modelo Fatorial X = Λf + ε |
| `mv_fa02` | Σ = ΛΛᵀ + Ψ |
| `mv_fa03` | Rotação Varimax |
| `mv_lda01` | Análise Discriminante Linear (LDA) |
| `mv_lda02` | Scatter Between-Class SB |
| `mv_lda03` | Scatter Within-Class SW |
| `mv_lda04` | QDA (Quadrática) |
| `mv_pca01` | Componentes Principais (PCA) |
| `mv_pca02` | Variância Explicada |
| `mv_pca03` | Decomposição Espectral de Σ |
| `mv_pca04` | Scores z = Pᵀ(x - μ) |
| `mv_pca05` | Biplot PCA |
| `mv_pca06` | Kernel PCA |

#### Computação Quântica

| ID | Fórmula/Equação |
|---|---|
| `qc_01` | Qubit \|ψ⟩ = α\|0⟩ + β\|1⟩ |
| `qc_02` | Esfera de Bloch |
| `qc_03` | Porta Hadamard H |
| `qc_04` | Portas de Pauli X, Y, Z |
| `qc_05` | Porta CNOT |
| `qc_06` | Estado de Bell \|Φ⁺⟩ |
| `qc_07` | Porta Toffoli (CCNOT) |
| `qc_08` | Porta de Fase S e T |
| `qc_09` | Oráculo Quântico |
| `qc_10` | Algoritmo de Deutsch-Jozsa |
| `qc_11` | Algoritmo de Grover (Busca) |
| `qc_12` | QFT (Transformada de Fourier Quântica) |
| `qc_13` | Algoritmo de Shor (Fatoração) |
| `qc_14` | VQE (Variational Quantum Eigensolver) |
| `qc_15` | QAOA |
| `qc_16` | Entropia de von Neumann |
| `qc_17` | Fidelidade F(ρ,σ) |
| `qc_18` | Desigualdade de Bell (CHSH) |
| `qc_19` | Teletransporte Quântico |
| `qc_20` | Teorema No-Cloning |
| `qc_21` | Código de Correção de Erro Quântico |
| `qc_22` | Classe BQP |
| `qc_23` | Supremacia/Vantagem Quântica |
| `qc_24` | Teorema de Solovay-Kitaev |
| `qc_25` | Limite de Holevo |
| `qc_26` | Simulação Quântica |

#### Controle Automático

| ID | Fórmula/Equação |
|---|---|
| `ca_01` | Função de Transferência G(s) |
| `ca_02` | Espaço de Estados |
| `ca_03` | Resposta ao Degrau (2ª ordem) |
| `ca_04` | Overshoot e Tempo de Acomodação |
| `ca_05` | Critério de Estabilidade de Routh-Hurwitz |
| `ca_06` | Critério de Nyquist |
| `ca_07` | Margem de Ganho e Fase |
| `ca_08` | Lugar das Raízes |
| `ca_pid01` | Controlador PID |
| `ca_pid02` | PID no Domínio s |
| `ca_pid03` | Ziegler-Nichols (Sintonia) |
| `ca_pid04` | Anti-Windup (Saturação Integrador) |
| `ca_pid05` | Erro em Regime Permanente |
| `ca_st01` | Controlabilidade (Matriz C) |
| `ca_st02` | Observabilidade (Matriz O) |
| `ca_st03` | Realimentação de Estado u = -Kx |
| `ca_st04` | Observador de Luenberger |
| `ca_st05` | LQR (Regulador Linear Quadrático) |
| `ca_st06` | Equação de Riccati |
| `ca_st07` | Filtro de Kalman |

#### Cálculo de Variações

| ID | Fórmula/Equação |
|---|---|
| `cv_01` | Funcional J[y] |
| `cv_02` | Condição de Extremo δJ=0 |
| `cv_03` | Equação de Euler-Lagrange |
| `cv_04` | Geodésica Plana (comprimento de arco) |
| `cv_05` | Braquistócrona (ciclóide) |
| `cv_06` | Funcional Multivariável |
| `cv_07` | EL para Múltiplas Variáveis |
| `cv_08` | Lagrangiano com Restrição (multiplicadores) |
| `cv_09` | Condição de Legendre |
| `cv_10` | Condição de Weierstrass |
| `cv_11` | Ação S |
| `cv_12` | Princípio de Hamilton |
| `cv_13` | Equação de Lagrange (Mecânica) |
| `cv_14` | L = T - V |
| `cv_15` | Hamiltoniano H (Legendre) |
| `cv_16` | Equações de Hamilton |
| `cv_17` | Colchete de Poisson |
| `cv_18` | Teorema de Noether |
| `cv_19` | Relações Canônicas de Poisson |

#### Deep Learning

| ID | Fórmula/Equação |
|---|---|
| `dl_01` | Neurônio Artificial |
| `dl_02` | Função Sigmoide |
| `dl_03` | ReLU |
| `dl_04` | Softmax |
| `dl_05` | Cross-Entropy Loss |
| `dl_06` | Backpropagation (Regra da Cadeia) |
| `dl_07` | SGD (Gradient Descent Estocástico) |
| `dl_08` | Adam Optimizer |
| `dl_cnn01` | Convolução 2D |
| `dl_cnn02` | Dimensão de Saída (Conv) |
| `dl_cnn03` | Max Pooling |
| `dl_cnn04` | Batch Normalization |
| `dl_cnn05` | Dropout |
| `dl_gan01` | GAN — Jogo Min-Max |
| `dl_gan02` | Wasserstein GAN (WGAN) |
| `dl_gan03` | VAE — ELBO |
| `dl_gan04` | Divergência KL |
| `dl_gan05` | Diffusion Model (DDPM) |
| `dl_gan06` | Score Matching ∇ₓ log p(x) |
| `dl_lstm01` | LSTM — Forget Gate |
| `dl_lstm02` | LSTM — Input Gate |
| `dl_lstm03` | LSTM — Cell Update |
| `dl_lstm04` | LSTM — Output Gate |
| `dl_lstm05` | GRU (Gated Recurrent Unit) |
| `dl_lstm06` | Seq2Seq com Atenção |
| `dl_rnn01` | RNN (Recorrente) |
| `dl_rnn02` | BPTT (Backprop Through Time) |
| `dl_tr01` | Self-Attention (QKV) |
| `dl_tr02` | Multi-Head Attention |
| `dl_tr03` | Positional Encoding |
| `dl_tr04` | Layer Normalization |
| `dl_tr05` | Feed-Forward Network (FFN) |
| `dl_tr06` | Masked Self-Attention (Causal) |

#### Epidemiologia

| ID | Fórmula/Equação |
|---|---|
| `ep_lv01` | Crescimento Exponencial |
| `ep_lv02` | Crescimento Logístico |
| `ep_lv03` | Lotka-Volterra (Predador-Presa) |
| `ep_lv04` | Competição de Lotka-Volterra |
| `ep_lv05` | Equação de Fisher-KPP |
| `ep_lv06` | Matriz de Leslie (Pop. Estruturada) |
| `ep_lv07` | Mapa Logístico (Caos) |
| `ep_lv08` | Expoente de Lyapunov |
| `ep_sir01` | Modelo SIR |
| `ep_sir02` | R₀ (Número Básico de Reprodução) |
| `ep_sir03` | Limiar de Imunidade de Rebanho |
| `ep_sir04` | Modelo SEIR |
| `ep_sir05` | Modelo SIS (Sem Imunidade) |
| `ep_sir06` | Taxa de Ataque Final (SIR) |
| `ep_sir07` | Rₜ (Número Efetivo de Reprodução) |
| `ep_sir08` | Geração Serial e Tempo de Duplicação |
| `ep_sir09` | Modelo em Rede (Network Epidemic) |
| `ep_sir10` | Matriz de Próxima Geração |

#### Estatística Bayesiana

| ID | Fórmula/Equação |
|---|---|
| `by_01` | Teorema de Bayes |
| `by_02` | Posterior ∝ Likelihood × Prior |
| `by_03` | Priori Conjugada |
| `by_04` | Estimador MAP |
| `by_05` | Estimador Bayesiano (Média Posterior) |
| `by_06` | Intervalo de Credibilidade |
| `by_07` | Fator de Bayes BF₁₂ |
| `by_08` | Prior Não-Informativa de Jeffreys |
| `by_mb01` | Movimento Browniano W(t) |
| `by_mb02` | Propriedades do Browniano |
| `by_mb03` | Browniano Geométrico (GBM) |
| `by_mb04` | Fórmula de Black-Scholes |
| `by_mb05` | Equação de Itô (SDE Geral) |
| `by_mb06` | Lema de Itô |
| `by_mb07` | Processo de Ornstein-Uhlenbeck |
| `by_mb08` | Processo de Poisson |
| `by_mb09` | Equação de Fokker-Planck |
| `by_mc01` | Monte Carlo via Cadeia de Markov (MCMC) |
| `by_mc02` | Algoritmo de Metropolis-Hastings |
| `by_mc03` | Gibbs Sampling |
| `by_mc04` | Hamiltonian Monte Carlo (HMC) |
| `by_mc05` | Diagnóstico R̂ (Gelman-Rubin) |
| `by_mk01` | Cadeia de Markov (Propriedade) |
| `by_mk02` | Matriz de Transição P |
| `by_mk03` | Dist. Estacionária π = πP |
| `by_mk04` | Chapman-Kolmogorov |
| `by_mk05` | Ergodicidade / Convergência |

#### Farmacocinética

| ID | Fórmula/Equação |
|---|---|
| `fk_01` | Cinética de 1ª Ordem (Eliminação) |
| `fk_02` | Meia-Vida (t₁/₂) |
| `fk_03` | Volume de Distribuição (Vd) |
| `fk_04` | Clearance (CL) |
| `fk_05` | AUC (Área Sob a Curva) |
| `fk_06` | Biodisponibilidade F |
| `fk_07` | Estado Estacionário (Css) em Dose Repetida |
| `fk_08` | Dose de Carga |
| `fk_09` | Cinética de Michaelis-Menten (Saturação) |
| `fk_fd01` | Modelo Emax (Farmacodinâmica) |
| `fk_fd02` | Índice Terapêutico (TI) |
| `fk_fd03` | PK/PD Link Model |
| `fk_fd04` | Fator de Acumulação |
| `fk_fd05` | Janela Terapêutica |

#### Funções Especiais

| ID | Fórmula/Equação |
|---|---|
| `fe_bs01` | Equação de Bessel |
| `fe_bs02` | Bessel 1ª Espécie Jᵥ(x) |
| `fe_bs03` | J_{-n}(x) = (-1)ⁿJₙ(x) |
| `fe_bs04` | Bessel 2ª Espécie Yᵥ (Neumann) |
| `fe_bs05` | Funções de Hankel |
| `fe_bs06` | Recorrência de Bessel |
| `fe_bs07` | Ortogonalidade de Bessel |
| `fe_bs08` | Valores Especiais J₀, J₁ |
| `fe_hm01` | Equação de Hermite |
| `fe_hm02` | Rodrigues para Hermite |
| `fe_hm03` | Primeiros Polinômios de Hermite |
| `fe_hm04` | Recorrência de Hermite |
| `fe_hm05` | Ortogonalidade de Hermite |
| `fe_la01` | Equação de Laguerre |
| `fe_la02` | Rodrigues para Laguerre |
| `fe_la03` | Primeiros Polinômios de Laguerre |
| `fe_lg01` | Equação de Legendre |
| `fe_lg02` | Fórmula de Rodrigues (Legendre) |
| `fe_lg03` | Primeiros Polinômios de Legendre |
| `fe_lg04` | Recorrência de Bonnet |
| `fe_lg05` | Ortogonalidade de Legendre |
| `fe_lg06` | Valores Especiais de Pₙ |
| `fe_lg07` | Funções Associadas de Legendre |
| `fe_lg08` | Harmônicos Esféricos Yₗᵐ |
| `fe_sp01` | Função Gamma Γ(z) |
| `fe_sp02` | Γ(n+1) = n! |
| `fe_sp03` | Recorrência Γ(z+1) = z·Γ(z) |
| `fe_sp04` | Γ(1/2) = √π |
| `fe_sp05` | Fórmula de Reflexão de Euler |
| `fe_sp06` | Fórmula de Stirling |
| `fe_sp07` | Função Beta B(x,y) |
| `fe_sp08` | Simetria B(x,y) = B(y,x) |

#### Geometria Diferencial

| ID | Fórmula/Equação |
|---|---|
| `gd_c01` | Parametrização por Comprimento de Arco |
| `gd_c02` | Curvatura κ |
| `gd_c03` | Vetor Tangente T |
| `gd_c04` | Vetor Normal Principal N |
| `gd_c05` | Vetor Binormal B |
| `gd_c06` | Fórmulas de Frenet-Serret |
| `gd_c07` | Torção τ |
| `gd_s01` | Parametrização de Superfície |
| `gd_s02` | Coeficientes da 1ª Forma Fundamental |
| `gd_s03` | 1ª Forma Fundamental (Métrica) |
| `gd_s04` | Elemento de Área dA |
| `gd_s05` | Normal Unitária n̂ |
| `gd_s06` | Coeficientes da 2ª Forma Fundamental |
| `gd_s07` | 2ª Forma Fundamental |
| `gd_s08` | Curvaturas Principais κ₁, κ₂ |
| `gd_s09` | Curvatura de Gauss K |
| `gd_s10` | Curvatura Média H |
| `gd_s11` | Superfície Mínima (H=0) |
| `gd_s12` | Theorema Egregium de Gauss |
| `gd_v01` | Variedade Diferencial M^n |
| `gd_v02` | Tensor Métrico gᵢⱼ |
| `gd_v03` | Símbolo de Christoffel (Levi-Civita) |
| `gd_v04` | Derivada Covariante |
| `gd_v05` | Equação da Geodésica |
| `gd_v06` | Tensor de Riemann |
| `gd_v07` | Tensor de Ricci |
| `gd_v08` | Escalar de Ricci R |
| `gd_v09` | Teorema de Gauss-Bonnet |
| `gd_v10` | Forma Diferencial (1-forma) |
| `gd_v11` | Derivada Exterior |
| `gd_v12` | Teorema de Stokes Geral |

#### Mecânica Analítica

| ID | Fórmula/Equação |
|---|---|
| `ma_h01` | Hamiltoniano H = Σpᵢq̇ᵢ - L |
| `ma_h02` | Equações de Hamilton |
| `ma_h03` | Colchete de Poisson |
| `ma_h04` | Evolução Temporal df/dt |
| `ma_h05` | Relações Canônicas |
| `ma_h06` | Transformação Canônica |
| `ma_h07` | Equação de Hamilton-Jacobi |
| `ma_h08` | Teorema de Liouville (Fase) |
| `ma_h09` | Variáveis de Ação-Ângulo |
| `ma_l01` | Lagrangiano L = T - V |
| `ma_l02` | Equações de Euler-Lagrange (Mecânica) |
| `ma_l03` | Momento Generalizado pᵢ |
| `ma_l04` | Coordenada Cíclica |
| `ma_l05` | Lagrangiano para N partículas |
| `ma_l06` | Pêndulo Simples (Lagrangiano) |
| `ma_l07` | Função de Energia de Jacobi h |
| `ma_l08` | Forças Generalizadas |
| `ma_l09` | Multiplicadores de Lagrange (Vínculos) |
| `ma_l10` | Princípio de d'Alembert |
| `ma_s01` | Princípio de Hamilton |
| `ma_s02` | Princípio de Maupertuis |
| `ma_s03` | Teorema de Noether |
| `ma_s04` | Espaço de Fase |
| `ma_s05` | Forma Simplética ω |
| `ma_s06` | Teorema KAM |

#### Mecânica Estatística

| ID | Fórmula/Equação |
|---|---|
| `me_01` | Entropia de Boltzmann S=kB ln Ω |
| `me_02` | Entropia de Gibbs S = -kB Σ pᵢ ln pᵢ |
| `me_03` | Distribuição de Boltzmann |
| `me_04` | Função de Partição Canônica Z |
| `me_05` | Energia Livre de Helmholtz F |
| `me_06` | ⟨E⟩ = -∂lnZ/∂β |
| `me_07` | Flutuação de Energia ΔE² |
| `me_08` | Ensemble Microcanônico |
| `me_09` | Ensemble Gran-Canônico |
| `me_10` | Potencial Gran-Canônico Ω_G |
| `me_11` | Distribuição de Fermi-Dirac |
| `me_12` | Distribuição de Bose-Einstein |
| `me_13` | Lei de Planck (Corpo Negro) |
| `me_14` | Lei de Stefan-Boltzmann |
| `me_15` | Equipartição de Energia |
| `me_16` | Modelo de Ising (1D) |
| `me_17` | Magnetização Média (Ising) |
| `me_18` | Temperatura Crítica (Ising 2D) |
| `me_19` | Expoentes Críticos |
| `me_20` | Teoria de Campo Médio (Landau) |

#### Neurociência Computacional

| ID | Fórmula/Equação |
|---|---|
| `nc_hh01` | Modelo de Hodgkin-Huxley |
| `nc_hh02` | Equação de Nernst |
| `nc_hh03` | Equação de Goldman-Hodgkin-Katz |
| `nc_hh04` | Gating Variable m(V) |
| `nc_hh05` | Corrente Sináptica (AMPA/NMDA) |
| `nc_hh06` | Equação do Cabo (Cable Equation) |
| `nc_hh07` | Velocidade de Condução do Potencial de Ação |
| `nc_if01` | Integrate-and-Fire (LIF) |
| `nc_if02` | Izhikevich (Modelo de 2 Variáveis) |
| `nc_if03` | Taxa de Disparo (f-I Curve) |
| `nc_if04` | Modelo de FitzHugh-Nagumo |
| `nc_nn01` | Aprendizado Hebbiano |
| `nc_nn02` | STDP (Plasticidade Dependente de Timing) |
| `nc_nn03` | Equação de Wilson-Cowan |
| `nc_nn04` | Rede de Hopfield |
| `nc_nn05` | Teoria da Informação Neural |
| `nc_nn06` | Teoria do Coding Eficiente |
| `nc_nn07` | Codificação por Taxa vs Temporal |

#### Processamento de Imagem

| ID | Fórmula/Equação |
|---|---|
| `pi_01` | Representação Digital de Imagem |
| `pi_02` | Filtro de Convolução Espacial |
| `pi_03` | Filtro Gaussiano |
| `pi_04` | Filtro de Sobel (Bordas) |
| `pi_05` | Detector de Canny |
| `pi_06` | Histograma e Equalização |
| `pi_07` | Transformada de Hough (Retas) |
| `pi_08` | Limiarização de Otsu |
| `pi_09` | Morfologia Matemática (Erosão/Dilatação) |
| `pi_10` | PSNR (Qualidade de Imagem) |
| `pi_11` | SSIM (Similaridade Estrutural) |
| `pi_12` | Transformação Afim |
| `pi_13` | Homografia (Perspectiva) |
| `pi_14` | Descritor SIFT |
| `pi_15` | Optical Flow (Lucas-Kanade) |
| `pi_16` | Segmentação por Watershed |
| `pi_17` | GrabCut (Segmentação Interativa) |
| `pi_18` | IoU (Intersection over Union) |

#### Processamento de Sinais

| ID | Fórmula/Equação |
|---|---|
| `dsp_01` | Transformada de Fourier Contínua (FT) |
| `dsp_02` | DFT (Transformada Discreta) |
| `dsp_03` | FFT (Fast Fourier Transform) |
| `dsp_04` | Teorema de Nyquist-Shannon |
| `dsp_05` | Convolução (Domínio do Tempo) |
| `dsp_06` | Teorema da Convolução |
| `dsp_07` | Transformada Z |
| `dsp_08` | Relação de Parseval |
| `dsp_09` | Filtro FIR |
| `dsp_10` | Filtro IIR |
| `dsp_11` | Função de Transferência H(z) |
| `dsp_12` | Resposta em Frequência H(e^jω) |
| `dsp_13` | Densidade Espectral de Potência (PSD) |
| `dsp_14` | Transformada Wavelet |
| `dsp_15` | Filtro de Wiener |
| `dsp_16` | Filtro Adaptativo LMS |

#### Relatividade Geral

| ID | Fórmula/Equação |
|---|---|
| `rg_01` | Intervalo Espaço-Temporal |
| `rg_02` | Transformação de Lorentz |
| `rg_03` | E = mc² |
| `rg_04` | Relação Energia-Momento |
| `rg_05` | Quadrivetor Energia-Momento |
| `rg_06` | Métrica de Espaço-Tempo Geral |
| `rg_07` | Equações de Campo de Einstein |
| `rg_08` | Tensor Energia-Momento Tμν |
| `rg_09` | Equação Geodésica |
| `rg_10` | Princípio de Equivalência |
| `rg_11` | Identidade de Bianchi |
| `rg_12` | Métrica de Schwarzschild |
| `rg_13` | Raio de Schwarzschild |
| `rg_14` | Desvio Gravitacional da Luz |
| `rg_15` | Dilatação Gravitacional do Tempo |
| `rg_16` | Redshift Gravitacional |
| `rg_17` | Métrica FLRW (Cosmologia) |
| `rg_18` | Equação de Friedmann |
| `rg_19` | Lei de Hubble-Lemaître |
| `rg_20` | Radiação de Hawking |

#### Séries Temporais

| ID | Fórmula/Equação |
|---|---|
| `st_01` | Processo Estocástico {Xₜ} |
| `st_02` | Estacionariedade Fraca |
| `st_03` | Função de Autocorrelação ρ(h) |
| `st_04` | Ruído Branco εₜ |
| `st_05` | Passeio Aleatório |
| `st_06` | Operador de Atraso B |
| `st_07` | Modelo AR(p) |
| `st_08` | Modelo MA(q) |
| `st_09` | Modelo ARMA(p,q) |
| `st_10` | Modelo ARIMA(p,d,q) |
| `st_11` | Modelo SARIMA |
| `st_12` | AIC/BIC (Critérios de Seleção) |
| `st_13` | Modelo ARCH(q) |
| `st_14` | Modelo GARCH(p,q) |
| `st_15` | Previsão (Erro Quadrático Mínimo) |
| `st_16` | Decomposição STL (Sazonal+Tendência) |
| `st_17` | Alisamento Exponencial (ETS) |

#### Teoria dos Grafos

| ID | Fórmula/Equação |
|---|---|
| `tg_01` | Grau de Vértice |
| `tg_02` | Lema do Aperto de Mãos |
| `tg_03` | Fórmula de Euler (Planar) |
| `tg_04` | Árvore: \|E\| = \|V\|-1 |
| `tg_05` | Fórmula de Cayley (Árvores Rotuladas) |
| `tg_06` | Número Cromático χ(G) |
| `tg_07` | Teorema das 4 Cores |
| `tg_08` | Dijkstra (Caminho Mínimo) |
| `tg_09` | Bellman-Ford |
| `tg_10` | Floyd-Warshall (Todos os Pares) |
| `tg_11` | Fluxo Máximo (Ford-Fulkerson) |
| `tg_12` | MST — Kruskal / Prim |
| `tg_13` | Componentes Fortemente Conexas |
| `tg_14` | Circuito Euleriano |
| `tg_15` | Caminho Hamiltoniano (NP-completo) |
| `tg_16` | Grafo Bipartido (Matching) |
| `tg_17` | PageRank |
| `tg_18` | Centralidade de Betweenness |
| `tg_19` | Coeficiente de Clustering |
| `tg_20` | Grafo Aleatório Erdős-Rényi |
| `tg_21` | Rede Small-World (Watts-Strogatz) |
| `tg_22` | Rede Scale-Free (Barabási-Albert) |

#### Teoria Quântica de Campos

| ID | Fórmula/Equação |
|---|---|
| `qft_01` | Ação de Klein-Gordon |
| `qft_02` | Equação de Klein-Gordon |
| `qft_03` | Equação de Dirac |
| `qft_04` | Lagrangiana de Dirac |
| `qft_05` | Propagador de Feynman (Escalar) |
| `qft_06` | Quantização de Campo Escalar |
| `qft_07` | Relação de Anticomutação (Férmions) |
| `qft_08` | Regras de Feynman (Diagramas) |
| `qft_09` | Seção de Choque σ |
| `qft_10` | Renormalização: Equação do Grupo de Renorm. |
| `qft_qcd01` | Lagrangiana QCD |
| `qft_qcd02` | Tensor Gluônico |
| `qft_qcd03` | Liberdade Assintótica |
| `qft_qcd04` | Confinamento de Quarks |
| `qft_qcd05` | Modelo Padrão: Grupo de Gauge |
| `qft_qcd06` | Mecanismo de Higgs |
| `qft_qcd07` | Massa de Higgs mH |
| `qft_qed01` | Lagrangiana QED |
| `qft_qed02` | Tensor Eletromagnético Fμν |
| `qft_qed03` | Propagador do Fóton |
| `qft_qed04` | Secção de Choque de Compton |
| `qft_qed05` | Momento Magnético Anômalo |
| `qft_qed06` | Constante de Estrutura Fina α |
| `qft_qed07` | Invariância de Gauge U(1) |

#### Topologia

| ID | Fórmula/Equação |
|---|---|
| `top_b01` | Teorema do Ponto Fixo de Brouwer |
| `top_b02` | Teorema de Borsuk-Ulam |
| `top_b03` | Invariância de Domínio |
| `top_b04` | Teorema da Curva de Jordan |
| `top_b05` | Teorema de Extensão de Tietze |
| `top_b06` | Lema de Urysohn |
| `top_b07` | Teorema de Seifert-Van Kampen |
| `top_m01` | Axiomas de Métrica |
| `top_m02` | Distância Euclidiana |
| `top_m03` | Distância do Supremo d∞ |
| `top_m04` | Distância de Manhattan d₁ |
| `top_m05` | Bola Aberta B(x,r) |
| `top_m06` | Sequência de Cauchy |
| `top_m07` | Completude |
| `top_m08` | Teorema do Ponto Fixo de Banach |
| `top_m09` | Compacidade |
| `top_m10` | Teorema de Heine-Cantor |
| `top_p01` | Axiomas de Topologia |
| `top_p02` | Espaço de Hausdorff (T₂) |
| `top_p03` | Homeomorfismo |
| `top_p04` | Invariante Topológica |
| `top_p05` | Conexidade |
| `top_p06` | Grupo Fundamental π₁(X,x₀) |
| `top_p07` | π₁(S¹) = ℤ, π₁(Sⁿ) = 0 |
| `top_p08` | π₁(T²) = ℤ×ℤ |
| `top_p09` | Homologia Hₙ(X) |
| `top_p10` | Característica de Euler χ(X) |
| `top_p11` | χ de Superfícies |

#### Vol2: Antenas e Propagação

| ID | Fórmula/Equação |
|---|---|
| `v2_ant01` | Equação de Friis Pr = Pt·Gt·Gr·(λ/4πd)² |
| `v2_ant02` | Perda de Espaço Livre (FSPL) dB |
| `v2_ant03` | Ganho de Antena G = 4πA/λ² |

#### Vol2: Análise Complexa

| ID | Fórmula/Equação |
|---|---|
| `v2_ac01` | Módulo de Número Complexo \|z\| |
| `v2_ac02` | Argumento de z: arg(z) = arctan(y/x) |
| `v2_ac03` | Fórmula de Euler e^(iθ) |
| `v2_ac04` | Resíduo de Polo Simples |

#### Vol2: Análise Multivariada

| ID | Fórmula/Equação |
|---|---|
| `v2_cl01` | Distância de Mahalanobis |
| `v2_pca01` | Variância Explicada por Componente Principal |

#### Vol2: Biologia Matemática

| ID | Fórmula/Equação |
|---|---|
| `v2_pop01` | Crescimento Malthusiano N(t) = N₀e^(rt) |
| `v2_pop02` | Modelo Logístico N(t) = K/(1+(K/N₀-1)e^(-rt)) |
| `v2_sir01` | Número Básico de Reprodução R₀ = β/γ |
| `v2_sir02` | Limiar de Imunidade de Rebanho 1 - 1/R₀ |

#### Vol2: Computação Quântica

| ID | Fórmula/Equação |
|---|---|
| `v2_qc01` | Qubit: \|ψ⟩ = α\|0⟩ + β\|1⟩ |
| `v2_qc02` | Porta Hadamard H |
| `v2_qc03` | Emaranhamento (Entrelaçamento) Quântico |
| `v2_qc04` | Algoritmo de Grover: Speedup O(√N) |

#### Vol2: Controle Automático

| ID | Fórmula/Equação |
|---|---|
| `v2_ca01` | Controlador PID: u(t) = Kp·e + Ki·∫e + Kd·ė |
| `v2_ca02` | Tempo de Acomodação ts ≈ 4/(ζωn) |
| `v2_ca03` | Overshoot Percentual %OS |

#### Vol2: Cálculo de Variações

| ID | Fórmula/Equação |
|---|---|
| `v2_cv01` | Funcional de Comprimento de Arco |
| `v2_cv02` | Hamiltoniano H = Σpᵢq̇ᵢ - L |

#### Vol2: Deep Learning

| ID | Fórmula/Equação |
|---|---|
| `v2_dl01` | Função de Ativação ReLU f(x) = max(0,x) |
| `v2_dl02` | Função Sigmoid σ(x) = 1/(1+e^(-x)) |
| `v2_dl03` | Tanh tanh(x) = (e^x - e^(-x))/(e^x + e^(-x)) |
| `v2_dl04` | Erro Quadrático Médio (MSE) |
| `v2_dl05` | Entropia Cruzada H(p,q) = -Σ pᵢ log(qᵢ) |
| `v2_dl06` | Gradiente Descendente θ ← θ - η·∇L |
| `v2_dl07` | Momentum v ← βv + ∇L; θ ← θ - ηv |
| `v2_dl08` | Dropout: Regularização Probabilística |

#### Vol2: Estatística Bayesiana

| ID | Fórmula/Equação |
|---|---|
| `v2_bay01` | Teorema de Bayes p(θ\|x) ∝ p(x\|θ)p(θ) |

#### Vol2: Farmacoc inética

| ID | Fórmula/Equação |
|---|---|
| `v2_fk01` | Meia-Vida t₁/₂ = ln(2)/K |

#### Vol2: Farmacocinética

| ID | Fórmula/Equação |
|---|---|
| `v2_fk02` | Clearance Cl = K·Vd |
| `v2_fk03` | Concentração após Dose IV Bolus C(t) = C₀·e^(-Kt) |

#### Vol2: Funções Especiais

| ID | Fórmula/Equação |
|---|---|
| `v2_sp01` | Função Gamma Γ(n+1) = n! |
| `v2_sp02` | Fórmula de Stirling para n! |
| `v2_sp03` | Função Beta B(x,y) |
| `v2_sp04` | Polinômio de Legendre P₀,P₁,P₂ |

#### Vol2: Geometria Diferencial

| ID | Fórmula/Equação |
|---|---|
| `v2_gd01` | Curvatura κ de Curva Parametrizada |
| `v2_gd02` | Curvatura de Gauss K |
| `v2_gd03` | Curvatura Média H |
| `v2_gd04` | Teorema de Gauss-Bonnet |

#### Vol2: Mecânica Estatística

| ID | Fórmula/Equação |
|---|---|
| `v2_me01` | Entropia de Boltzmann S = kB ln Ω |
| `v2_me02` | Energia Livre de Helmholtz F = -kBT ln Z |
| `v2_me03` | Energia Média ⟨E⟩ = -∂ln(Z)/∂β |
| `v2_me04` | Distribuição de Fermi-Dirac |
| `v2_me05` | Distribuição de Bose-Einstein |
| `v2_me06` | Energia de Fermi EF (gás de elétrons) |

#### Vol2: Mecânica Lagrangiana

| ID | Fórmula/Equação |
|---|---|
| `v2_mh01` | Hamiltoniano do Oscilador Harmônico |
| `v2_mh02` | Colchete de Poisson Canônico {qᵢ,pⱼ} = δᵢⱼ |
| `v2_ml01` | Lagrangiano L = T - V |
| `v2_ml02` | Energia Cinética T = ½mv² |
| `v2_ml03` | Momento Generalizado pᵢ = ∂L/∂q̇ᵢ |

#### Vol2: Neurociência

| ID | Fórmula/Equação |
|---|---|
| `v2_hh01` | Potencial de Nernst E = (RT/zF)·ln([X]out/[X]in) |
| `v2_hh02` | Tempo de Subida do Potencial de Ação |

#### Vol2: Processamento de Imagem

| ID | Fórmula/Equação |
|---|---|
| `v2_img01` | Kernel Gaussiano 2D para Blur |
| `v2_img02` | Filtro Sobel para Detecção de Bordas |

#### Vol2: Processamento de Sinais

| ID | Fórmula/Equação |
|---|---|
| `v2_dsp01` | Teorema de Nyquist fs ≥ 2fmax |
| `v2_dsp02` | Frequência de Nyquist fN = fs/2 |

#### Vol2: Relatividade Geral

| ID | Fórmula/Equação |
|---|---|
| `v2_rg01` | Raio de Schwarzschild rs = 2GM/c² |
| `v2_rg02` | Temperatura de Hawking TH |
| `v2_rg03` | Desvio para o Vermelho Gravitacional z |

#### Vol2: Séries Temporais

| ID | Fórmula/Equação |
|---|---|
| `v2_st01` | AIC (Critério de Informação de Akaike) |
| `v2_st02` | BIC (Critério Bayesiano de Schwarz) |

#### Vol2: Teoria dos Grafos

| ID | Fórmula/Equação |
|---|---|
| `v2_tg01` | Handshaking Lemma: Σ deg(v) = 2m |
| `v2_tg02` | Número de Arestas em Grafo Completo Kₙ |
| `v2_tg03` | Fórmula de Euler Planar: V - E + F = 2 |
| `v2_tg04` | Árvore: m = n - 1 |
| `v2_tg05` | Fórmula de Cayley: nⁿ⁻² árvores |

#### Vol2: Topologia

| ID | Fórmula/Equação |
|---|---|
| `v2_top01` | Distância Euclidiana em ℝⁿ |
| `v2_top02` | Distância de Manhattan (d₁) |
| `v2_top03` | Distância de Chebyshev (d_∞) |
| `v2_top04` | Característica de Euler χ (Superfície) |

#### Vol2: Álgebra Abstrata

| ID | Fórmula/Equação |
|---|---|
| `v2_f01` | Ordem de Corpo Finito de Galois 𝔽_q |
| `v2_f02` | Grau de Extensão de Corpos [E:F] |
| `v2_g01` | Ordem de Elemento em Grupo Cíclico ℤₙ |
| `v2_g02` | Índice de Subgrupo [G:H] = \|G\|/\|H\| |
| `v2_g03` | Ordem do Produto Direto \|G×H\| |

#### Álgebra Abstrata

| ID | Fórmula/Equação |
|---|---|
| `aa_f01` | Definição de Corpo |
| `aa_f02` | Característica de um Corpo |
| `aa_f03` | Corpo Finito de Galois 𝔽_q |
| `aa_f04` | Corpo Primo 𝔽_p = ℤ/pℤ |
| `aa_f05` | Grau de Extensão [E:F] |
| `aa_f06` | Teorema do Elemento Primitivo |
| `aa_f07` | Grupo de Galois |
| `aa_f08` | \|Gal(E/F)\| = [E:F] |
| `aa_f09` | Teorema Fundamental de Galois |
| `aa_f10` | Critério de Eisenstein |
| `aa_g01` | Axiomas de Grupo (G,·) |
| `aa_g02` | Ordem do Grupo \|G\| |
| `aa_g03` | Ordem de um Elemento |
| `aa_g04` | Teorema de Lagrange |
| `aa_g05` | Índice de Subgrupo [G:H] |
| `aa_g06` | Grupo Quociente G/N |
| `aa_g07` | 1º Teorema do Isomorfismo |
| `aa_g08` | Teorema de Cayley |
| `aa_g09` | Grupo Cíclico |
| `aa_g10` | Grupo Abeliano |
| `aa_g11` | Produto Direto G×H |
| `aa_g12` | Teorema de Sylow |
| `aa_g13` | Grupos Simples |
| `aa_g14` | GL(n,F) e SL(n,F) |
| `aa_h01` | Homomorfismo |
| `aa_h02` | Isomorfismo |
| `aa_h03` | Automorfismo |
| `aa_h04` | Kernel (Núcleo) |
| `aa_h05` | Imagem Im(φ) |
| `aa_h06` | Módulo sobre Anel |
| `aa_h07` | Álgebra sobre Corpo |
| `aa_h08` | Álgebra de Lie |
| `aa_h09` | Identidade de Jacobi |
| `aa_r01` | Axiomas de Anel |
| `aa_r02` | Domínio Integral |
| `aa_r03` | Ideal de um Anel |
| `aa_r04` | Ideal Primo |
| `aa_r05` | Ideal Maximal |
| `aa_r06` | Anel Quociente R/I |
| `aa_r07` | Anel de Polinômios R[x] |
| `aa_r08` | Domínio de Fatoração Única (DFU) |
| `aa_r09` | Algoritmo da Divisão em R[x] |
| `aa_r10` | Teorema do Isomorfismo de Anéis |

</details>

<details>
<summary><b>Volume III — 532 fórmulas</b></summary>

#### Categorias
- Acústica e Vibroacústica (18)
- Análise de Sobrevivência (14)
- Análise Funcional (31)
- Análise Numérica (25)
- Bioinformática (21)
- Caos e Fractais (21)
- CFD e Turbulência (19)
- Ciências do Clima (17)
- Finanças Quantitativas (18)
- Física de Plasmas (12)
- Física Nuclear (11)
- Geoestatística (11)
- Geometria Algébrica (16)
- Lógica Matemática (10)
- Matéria Condensada (23)
- Mecânica da Fratura (16)
- Pesquisa Operacional (15)
- Robótica (13)
- Sistemas de Potência (10)
- Teoria da Medida (19)
- Teoria das Categorias (12)
- Valores Extremos e Cópulas (11)
- Vol3: Acustica e Vibroacustica (8)
- Vol3: Analise de Sobrevivencia (8)
- Vol3: Analise Funcional (11)
- Vol3: Analise Numerica (10)
- Vol3: Bioinformatica (9)
- Vol3: Caos e Fractais (6)
- Vol3: CFD e Turbulencia (6)
- Vol3: Ciencias do Clima (7)
- Vol3: Financas Quantitativas (10)
- Vol3: Fisica de Plasmas (5)
- Vol3: Fisica Nuclear (5)
- Vol3: Geoestatistica (6)
- Vol3: Geometria Algebrica (6)
- Vol3: Logica Matematica (4)
- Vol3: Materia Condensada (8)
- Vol3: Mecanica da Fratura (6)
- Vol3: Optica Quantica (5)
- Vol3: Pesquisa Operacional (6)
- Vol3: Robotica (5)
- Vol3: Sistemas de Potencia (6)
- Vol3: Teoria da Medida (8)
- Vol3: Teoria das Categorias (4)
- Vol3: Valores Extremos e Copulas (6)
- Óptica Quântica (14)

#### Acústica e Vibroacústica

| ID | Fórmula/Equação |
|---|---|
| `3_ac01` | Equação da Onda Acústica |
| `3_ac02` | Velocidade do Som (Gás Ideal) |
| `3_ac03` | Impedância Acústica |
| `3_ac04` | Nível de Pressão Sonora (SPL) |
| `3_ac05` | Nível de Potência Sonora |
| `3_ac06` | Lei do Inverso do Quadrado |
| `3_ac07` | Soma de Níveis de Pressão Sonora |
| `3_ac08` | Ponderação A (dBA) |
| `3_ac09` | Tempo de Reverberação (Sabine) |
| `3_ac10` | Fórmula de Eyring |
| `3_ac11` | Distância Crítica |
| `3_ac12` | Inteligibilidade STI |
| `3_vb01` | SDOF: Oscilador Amortecido |
| `3_vb02` | Frequência Natural |
| `3_vb03` | Fator de Amplificação (Ressonância) |
| `3_vb04` | MDOF: Autovalores |
| `3_vb05` | Transferência Vibroacústica (FRF) |
| `3_vb06` | Potência Sonora Radiada |

#### Análise de Sobrevivência

| ID | Fórmula/Equação |
|---|---|
| `3_sv01` | Função de Sobrevivência |
| `3_sv02` | Função de Hazard (Taxa Instantânea) |
| `3_sv03` | Hazard Cumulativo |
| `3_sv04` | Modelo Exponencial |
| `3_sv05` | Modelo de Weibull |
| `3_sv06` | Estimador de Kaplan-Meier |
| `3_sv07` | Erro Padrão de Greenwood |
| `3_sv08` | Teste Log-Rank |
| `3_sv09` | Censura à Direita |
| `3_sv10` | Modelo de Riscos Proporcionais de Cox |
| `3_sv11` | Verossimilhança Parcial de Cox |
| `3_sv12` | Hazard Ratio |
| `3_sv13` | Nelson-Aalen |
| `3_sv14` | Tempo de Vida Médio Restrito (RMST) |

#### Análise Funcional

| ID | Fórmula/Equação |
|---|---|
| `3_af01` | Axiomas de Norma |
| `3_af02` | Espaço de Banach (Definição) |
| `3_af03` | Norma ℓᵖ |
| `3_af04` | Norma Sup (ℓ∞) |
| `3_af05` | Espaço Lᵖ(Ω) |
| `3_af06` | Desigualdade de Hölder |
| `3_af07` | Desigualdade de Minkowski |
| `3_af08` | Teorema de Hahn-Banach |
| `3_af09` | Teorema do Ponto Fixo de Schauder |
| `3_af10` | Princípio da Limitação Uniforme (Banach-Steinhaus) |
| `3_af11` | Teorema da Aplicação Aberta |
| `3_af12` | Teorema do Gráfico Fechado |
| `3_ah01` | Produto Interno — Axiomas |
| `3_ah02` | Norma Induzida pelo Produto Interno |
| `3_ah03` | Desigualdade de Cauchy-Schwarz |
| `3_ah04` | Lei do Paralelogramo |
| `3_ah05` | Ortogonalidade |
| `3_ah06` | Projeção Ortogonal |
| `3_ah07` | Teorema da Representação de Riesz |
| `3_ah08` | Base Ortonormal |
| `3_ah09` | Expansão de Fourier Generalizada |
| `3_ah10` | Identidade de Parseval |
| `3_ah11` | Espaço L²(a,b) |
| `3_te01` | Operador Autoadjunto |
| `3_te02` | Espectro de um Operador |
| `3_te03` | Espectro Pontual (Autovalores) |
| `3_te04` | Espectro Contínuo e Residual |
| `3_te05` | Teorema Espectral |
| `3_te06` | Operador Compacto |
| `3_te07` | Norma de Hilbert-Schmidt |
| `3_te08` | Alternativa de Fredholm |

#### Análise Numérica

| ID | Fórmula/Equação |
|---|---|
| `3_an01` | Interpolação de Lagrange |
| `3_an02` | Erro da Interpolação Polinomial |
| `3_an03` | Diferenças Divididas de Newton |
| `3_an04` | Spline Cúbica |
| `3_an05` | Nós de Chebyshev |
| `3_an06` | Mínimos Quadrados (Eq. Normais) |
| `3_an07` | Regra do Trapézio |
| `3_an08` | Erro do Trapézio |
| `3_an09` | Regra de Simpson 1/3 |
| `3_an10` | Erro de Simpson |
| `3_an11` | Quadratura de Gauss-Legendre |
| `3_an12` | Extrapolação de Romberg |
| `3_an13` | Método de Euler Explícito |
| `3_an14` | Runge-Kutta 4ª Ordem (RK4) |
| `3_an15` | RK4 — Etapas k₁ e k₂ |
| `3_an16` | RK4 — Etapas k₃ e k₄ |
| `3_an17` | RK4 — Fórmula de Atualização |
| `3_an18` | Adams-Bashforth 4 Passos |
| `3_an19` | Estabilidade Absoluta |
| `3_an20` | Gradiente Conjugado |
| `3_an21` | GMRES |
| `3_an22` | Número de Condição |
| `3_an23` | Formulação Fraca (FEM) |
| `3_an24` | Método de Galerkin |
| `3_an25` | Estimativa de Erro FEM |

#### Bioinformática

| ID | Fórmula/Equação |
|---|---|
| `3_bi01` | Needleman-Wunsch (Global) |
| `3_bi02` | Smith-Waterman (Local) |
| `3_bi03` | BLAST (Heurístico) |
| `3_bi04` | E-value (BLAST) |
| `3_bi05` | Matriz de Substituição BLOSUM62 |
| `3_bi06` | Gap Afim |
| `3_bi07` | Alinhamento Múltiplo (MSA) |
| `3_bi08` | Modelo de Jukes-Cantor |
| `3_bi09` | Neighbor-Joining |
| `3_bi10` | Máxima Verossimilhança (Filogenética) |
| `3_bi11` | Bootstrap Filogenético |
| `3_bs01` | Flux Balance Analysis (FBA) |
| `3_bs02` | Modelo de Lotka-Volterra |
| `3_bs03` | Equação de Hill (Cooperatividade) |
| `3_bs04` | Bistabilidade (Toggle Switch) |
| `3_ev01` | Equação do Replicador |
| `3_ev02` | Equação de Fisher (Genética) |
| `3_ev03` | Equação de Price |
| `3_ev04` | Equilíbrio de Hardy-Weinberg |
| `3_ev05` | Deriva Genética (Modelo de Wright-Fisher) |
| `3_ev06` | Relógio Molecular |

#### Caos e Fractais

| ID | Fórmula/Equação |
|---|---|
| `3_ca01` | Sistema Dinâmico Autônomo |
| `3_ca02` | Ponto de Equilíbrio |
| `3_ca03` | Análise de Estabilidade Linear |
| `3_ca04` | Classificação por Autovalores |
| `3_ca05` | Bifurcação de Hopf |
| `3_ca06` | Bifurcação Pitchfork |
| `3_ca07` | Mapa Logístico |
| `3_ca08` | Diagrama de Bifurcação |
| `3_fr01` | Dimensão de Hausdorff |
| `3_fr02` | Conjunto de Cantor |
| `3_fr03` | Curva de Koch |
| `3_fr04` | Triângulo de Sierpinski |
| `3_fr05` | Conjunto de Mandelbrot |
| `3_fr06` | Autossimilaridade (IFS) |
| `3_lz01` | Lorenz — Equação para x |
| `3_lz02` | Lorenz — Equação para y |
| `3_lz03` | Lorenz — Equação para z |
| `3_lz04` | Sensibilidade às Condições Iniciais |
| `3_lz05` | Expoente de Lyapunov |
| `3_lz06` | Espectro de Lyapunov (Lorenz) |
| `3_lz07` | Dimensão de Kaplan-Yorke |

#### CFD e Turbulência

| ID | Fórmula/Equação |
|---|---|
| `3_cf01` | Forma Integral (FVM) |
| `3_cf02` | Esquema Upwind |
| `3_cf03` | Algoritmo SIMPLE |
| `3_cf04` | Número de Courant (CFL) |
| `3_cf05` | Convergência de Malha (GCI) |
| `3_ns01` | Equações de Navier-Stokes (Incompressível) |
| `3_ns02` | Número de Reynolds |
| `3_ns03` | Número de Prandtl |
| `3_ns04` | Número de Nusselt |
| `3_ns05` | Vorticidade |
| `3_tb01` | Decomposição de Reynolds |
| `3_tb02` | Equações RANS |
| `3_tb03` | Hipótese de Boussinesq |
| `3_tb04` | Modelo k-ε Padrão |
| `3_tb05` | Modelo k-ω SST |
| `3_tb06` | LES (Large Eddy Simulation) |
| `3_tb07` | Modelo de Smagorinsky (SGS) |
| `3_tb08` | Cascata de Kolmogorov |
| `3_tb09` | Escala de Kolmogorov |

#### Ciências do Clima

| ID | Fórmula/Equação |
|---|---|
| `3_cl01` | Equações Primitivas |
| `3_cl02` | Parâmetro de Coriolis |
| `3_cl03` | Vento Geostrófico |
| `3_cl04` | Equação da Vorticidade |
| `3_cl05` | Vorticidade Potencial de Ertel |
| `3_cl06` | Número de Rossby |
| `3_cl07` | Equação Hidrostática |
| `3_cl08` | Vento Térmico |
| `3_cl09` | Balanço Energético Global |
| `3_cl10` | Sensibilidade Climática |
| `3_cl11` | Forçante por CO₂ |
| `3_cl12` | Feedback Fator de Ganho |
| `3_cl13` | Lei de Stefan-Boltzmann (Emissão) |
| `3_cl14` | Efeito Estufa |
| `3_cl15` | Ondas de Rossby (Planetárias) |
| `3_cl16` | Ondas de Kelvin Equatoriais |
| `3_cl17` | ENSO (Índice ONI) |

#### Finanças Quantitativas

| ID | Fórmula/Equação |
|---|---|
| `3_gr01` | Black-Scholes (Call Europeia) |
| `3_gr02` | d₁ e d₂ (Black-Scholes) |
| `3_gr03` | Delta (Δ) |
| `3_gr04` | Gamma (Γ) |
| `3_gr05` | Theta (Θ) |
| `3_gr06` | Vega (ν) |
| `3_gr07` | Rho (ρ) |
| `3_gr08` | Paridade Put-Call |
| `3_mk01` | Retorno Esperado da Carteira |
| `3_mk02` | Variância da Carteira |
| `3_mk03` | Índice de Sharpe |
| `3_mk04` | Fronteira Eficiente |
| `3_mk05` | CAPM (Capital Asset Pricing Model) |
| `3_mk06` | APT (Arbitrage Pricing Theory) |
| `3_ri01` | Value at Risk (VaR) |
| `3_ri02` | VaR Paramétrico (Normal) |
| `3_ri03` | Expected Shortfall (ES/CVaR) |
| `3_ri04` | CVA (Credit Valuation Adjustment) |

#### Física de Plasmas

| ID | Fórmula/Equação |
|---|---|
| `3_mh01` | Continuidade (MHD) |
| `3_mh02` | Momento (MHD) |
| `3_mh03` | Indução Magnética (MHD) |
| `3_mh04` | Lei de Ampère (MHD) |
| `3_mh05` | Velocidade de Alfvén |
| `3_mh06` | Número de Lundquist |
| `3_mh07` | Beta do Plasma |
| `3_pl01` | Comprimento de Debye |
| `3_pl02` | Parâmetro de Plasma |
| `3_pl03` | Frequência de Plasma |
| `3_pl04` | Condições de Plasma |
| `3_pl05` | Equação de Vlasov |

#### Física Nuclear

| ID | Fórmula/Equação |
|---|---|
| `3_nu01` | Raio Nuclear |
| `3_nu02` | Fórmula de Bethe-Weizsäcker (Semi-empírica) |
| `3_nu03` | Termos da Fórmula de Massa |
| `3_nu04` | Termo de Emparelhamento δ |
| `3_nu05` | Energia de Ligação por Nucleon |
| `3_nu06` | Q-Valor de Reação |
| `3_nu07` | Fissão Nuclear (²³⁵U) |
| `3_nu08` | Fusão D-T |
| `3_nu09` | Seção de Choque |
| `3_nu10` | Fator de Gamow (Tunelamento) |
| `3_nu11` | Equação de Criticidade (Reator) |

#### Geoestatística

| ID | Fórmula/Equação |
|---|---|
| `3_ge01` | Semivariograma Experimental |
| `3_ge02` | Efeito Pepita (Nugget) |
| `3_ge03` | Modelo Esférico |
| `3_ge04` | Modelo Exponencial |
| `3_ge05` | Modelo Gaussiano |
| `3_ge06` | Kriging Ordinário (Preditor) |
| `3_ge07` | Sistema de Kriging |
| `3_ge08` | Variância de Kriging |
| `3_ge09` | Kriging Universal |
| `3_ge10` | Validação Cruzada |
| `3_ge11` | Cokriging |

#### Geometria Algébrica

| ID | Fórmula/Equação |
|---|---|
| `3_ce01` | Curva Elíptica — Forma de Weierstrass |
| `3_ce02` | Discriminante de Curva Elíptica |
| `3_ce03` | Adição em Curva Elíptica |
| `3_ce04` | Inclinação da Corda (P≠Q) |
| `3_ce05` | Inclinação da Tangente (P=Q) |
| `3_ce06` | Coordenadas do Ponto Soma |
| `3_ce07` | Grupo E(k) |
| `3_ce08` | Teorema de Mordell-Weil |
| `3_ce09` | Rank de Curva Elíptica |
| `3_ce10` | ECDLP — Problema do Log Discreto Elíptico |
| `3_ga01` | Variedade Afim |
| `3_ga02` | Ideal de Variedade |
| `3_ga03` | Nullstellensatz de Hilbert |
| `3_ga04` | Dimensão de Variedade |
| `3_ga05` | Teorema de Bézout |
| `3_ga06` | Gênero de Curva Plana Lisa |

#### Lógica Matemática

| ID | Fórmula/Equação |
|---|---|
| `3_gd01` | 1º Teorema de Incompletude de Gödel |
| `3_gd02` | 2º Teorema de Incompletude de Gödel |
| `3_gd03` | Número de Gödel |
| `3_gd04` | Sentença de Gödel (Auto-referência) |
| `3_gd05` | Teorema de Tarski (Indefinibilidade da Verdade) |
| `3_lm01` | Sintaxe da Lógica de 1ª Ordem |
| `3_lm02` | Semântica (Satisfação) |
| `3_lm03` | Completude de Gödel |
| `3_lm04` | Compacidade |
| `3_lm05` | Löwenheim-Skolem |

#### Matéria Condensada

| ID | Fórmula/Equação |
|---|---|
| `3_mc01` | Teorema de Bloch |
| `3_mc02` | Periodicidade de Banda |
| `3_mc03` | Dispersão de Elétron Livre |
| `3_mc04` | Massa Efetiva |
| `3_mc05` | Densidade de Estados 3D |
| `3_mc06` | Zona de Brillouin |
| `3_mc07` | Modelo de Drude (DC) |
| `3_mc08` | Drude AC |
| `3_mc09` | Coeficiente de Hall |
| `3_mc10` | Efeito Hall Quântico Inteiro (IQHE) |
| `3_mc11` | Fator de Preenchimento |
| `3_ph01` | Modelo de Einstein (Calor Específico) |
| `3_ph02` | Modelo de Debye (Calor Específico) |
| `3_ph03` | Temperatura de Debye |
| `3_ph04` | Lei T³ de Debye |
| `3_sc01` | Temperatura Crítica BCS |
| `3_sc02` | Gap BCS |
| `3_sc03` | Par de Cooper |
| `3_sc04` | Equações de London |
| `3_sc05` | Comprimento de Penetração de London |
| `3_sc06` | Comprimento de Coerência |
| `3_sc07` | Quantum de Fluxo (Fluxóide) |
| `3_sc08` | Equação de Ginzburg-Landau |

#### Mecânica da Fratura

| ID | Fórmula/Equação |
|---|---|
| `3_fd01` | Curva S-N (Wöhler) |
| `3_fd02` | Diagrama de Goodman |
| `3_fd03` | Lei de Paris (Propagação de Trinca) |
| `3_fd04` | Vida Residual (Integração de Paris) |
| `3_fd05` | Regra de Miner (Dano Cumulativo) |
| `3_fd06` | Rainflow Counting |
| `3_fd07` | Limiar de Propagação ΔKth |
| `3_mf01` | Fator de Intensidade de Tensão (SIF) |
| `3_mf02` | Critério de Fratura (KIC) |
| `3_mf03` | Taxa de Liberação de Energia G |
| `3_mf04` | Critério de Griffith |
| `3_mf05` | Integral J |
| `3_mf06` | Campo na Ponta da Trinca (HRR) |
| `3_mf07` | CTOD (Abertura de Ponta de Trinca) |
| `3_mf08` | Zona Plástica (Irwin) |
| `3_mf09` | Limite de Validade da LEFM |

#### Pesquisa Operacional

| ID | Fórmula/Equação |
|---|---|
| `3_po01` | Problema de Programação Linear (PL) |
| `3_po02` | Dual do PL |
| `3_po03` | Método Simplex |
| `3_po04` | Condições KKT |
| `3_po05` | Método de Pontos Interiores |
| `3_po06` | Programação Inteira (IP) |
| `3_po07` | Programação Dinâmica (Princípio de Bellman) |
| `3_po08` | Problema do Caixeiro Viajante (TSP) |
| `3_po09` | Problema da Mochila |
| `3_po10` | Relaxação Lagrangiana |
| `3_tf01` | Fila M/M/1 |
| `3_tf02` | Lei de Little |
| `3_tf03` | Tempo Médio no Sistema M/M/1 |
| `3_tf04` | Fila M/M/c |
| `3_tf05` | Fórmula de Erlang-B (Bloqueio) |

#### Robótica

| ID | Fórmula/Equação |
|---|---|
| `3_rb01` | Matriz de Transformação Homogênea |
| `3_rb02` | Parâmetros de Denavit-Hartenberg |
| `3_rb03` | Cinemática Direta |
| `3_rb04` | Jacobiano do Robô |
| `3_rb05` | Cinemática Inversa |
| `3_rb06` | IK por Jacobiano Inverso (Iterativo) |
| `3_rb07` | Singularidades do Manipulador |
| `3_rb08` | Euler-Lagrange para Robôs |
| `3_rb09` | Energia Cinética do Manipulador |
| `3_rb10` | Torque Computado (CTC) |
| `3_rb11` | Newton-Euler Recursivo |
| `3_rb12` | Espaço de Trabalho |
| `3_rb13` | Controle PD no Espaço de Juntas |

#### Sistemas de Potência

| ID | Fórmula/Equação |
|---|---|
| `3_sp01` | Equações de Fluxo de Potência |
| `3_sp02` | Fluxo de Potência (Sᵢⱼ) |
| `3_sp03` | Newton-Raphson (Fluxo de Potência) |
| `3_sp04` | Potência Ativa = f(δ) |
| `3_sp05` | Perdas na Transmissão |
| `3_sp06` | Corrente de Curto-Circuito Trifásico |
| `3_sp07` | Componentes Simétricas |
| `3_sp08` | Equação Swing do Gerador |
| `3_sp09` | Critério de Áreas Iguais |
| `3_sp10` | Constante de Inércia H |

#### Teoria da Medida

| ID | Fórmula/Equação |
|---|---|
| `3_il01` | Integral de Lebesgue — Definição (f≥0) |
| `3_il02` | Integral de Lebesgue — Geral |
| `3_il03` | Teorema da Convergência Monótona (Beppo-Levi) |
| `3_il04` | Teorema da Convergência Dominada (Lebesgue) |
| `3_il05` | Lema de Fatou |
| `3_il06` | Teorema de Fubini |
| `3_il07` | Teorema de Tonelli |
| `3_rn01` | Continuidade Absoluta (ν≪μ) |
| `3_rn02` | Teorema de Radon-Nikodym |
| `3_rn03` | Decomposição de Lebesgue |
| `3_rn04` | Espaço Dual de Lᵖ |
| `3_tm01` | σ-Álgebra — Axiomas |
| `3_tm02` | Medida — Axiomas |
| `3_tm03` | Espaço de Medida (Ω,F,μ) |
| `3_tm04` | Medida de Lebesgue em ℝ |
| `3_tm05` | Medida de Borel |
| `3_tm06` | Medida de Contagem |
| `3_tm07` | Continuidade por cima |
| `3_tm08` | Continuidade por baixo |

#### Teoria das Categorias

| ID | Fórmula/Equação |
|---|---|
| `3_tc01` | Categoria — Definição |
| `3_tc02` | Funtor |
| `3_tc03` | Funtor Covariante vs Contravariante |
| `3_tc04` | Transformação Natural |
| `3_tc05` | Isomorfismo Natural |
| `3_tc06` | Produto Categórico |
| `3_tc07` | Coproduto (Soma) |
| `3_tc08` | Limite |
| `3_tc09` | Colimite |
| `3_tc10` | Adjunção (F⊣G) |
| `3_tc11` | Lema de Yoneda |
| `3_tc12` | Topos |

#### Valores Extremos e Cópulas

| ID | Fórmula/Equação |
|---|---|
| `3_co01` | Teorema de Sklar |
| `3_co02` | Densidade da Cópula |
| `3_co03` | Cópula Gaussiana |
| `3_co04` | Cópula de Clayton |
| `3_co05` | Cópula de Gumbel |
| `3_co06` | Tau de Kendall vs Cópula |
| `3_ve01` | Teorema de Fisher-Tippett-Gnedenko |
| `3_ve02` | CDF da GEV |
| `3_ve03` | Distribuição de Pareto Generalizada (GPD) |
| `3_ve04` | Valor em Risco Extremo (VaR-EVT) |
| `3_ve05` | Expected Shortfall (CVaR) |

#### Vol3: Acustica e Vibroacustica

| ID | Fórmula/Equação |
|---|---|
| `v3_ac01` | Velocidade do som no ar |
| `v3_ac02` | SPL |
| `v3_ac03` | Sabine TR60 |
| `v3_vb01` | Frequencia natural SDOF |
| `v3x_ac04` | Modo de sala retangular |
| `v3x_ac05` | Intensidade acustica |
| `v3z_ac07` | AC7 Nivel de intensidade sonora |
| `v3z_vb02` | VB2 Frequencia amortecida |

#### Vol3: Analise de Sobrevivencia

| ID | Fórmula/Equação |
|---|---|
| `v3_sv01` | Sobrevivencia complementar |
| `v3_sv02` | Hazard acumulado |
| `v3_sv03` | Modelo de Cox (HR) |
| `v3x_sv04` | Hazard Weibull |
| `v3x_sv05` | Kaplan-Meier (um evento) |
| `v3x_sv06` | Greenwood (incremento) |
| `v3x_sv07` | Log-rank (estatistica) |
| `v3z_sv06` | SV6 Sobrevivencia Weibull |

#### Vol3: Analise Funcional

| ID | Fórmula/Equação |
|---|---|
| `v3_af01` | Norma lp (2D) |
| `v3_af02` | Norma sup |
| `v3_af03` | Holder (limite superior) |
| `v3_ah01` | Norma induzida por produto interno |
| `v3_ah02` | Cauchy-Schwarz (limite) |
| `v3_te01` | Norma Hilbert-Schmidt (2 vetores) |
| `v3x_af04` | Lei do paralelogramo (lado esquerdo) |
| `v3x_te02` | Espectro de matriz diagonal 2x2 (autovalores) |
| `v3z_af06` | AF6 Holder - cota do produto integral |
| `v3z_af07` | AF7 Minkowski - lado direito |
| `v3z_ah10` | AH10 Parseval (soma de coeficientes) |

#### Vol3: Analise Numerica

| ID | Fórmula/Equação |
|---|---|
| `v3_an01` | Interpolacao linear |
| `v3_an02` | Regra do trapezio simples |
| `v3_an03` | Simpson 1/3 |
| `v3_an04` | Euler explicito |
| `v3_an05` | Numero de condicao |
| `v3x_an06` | Runge-Kutta 4 (um passo) |
| `v3x_an07` | Conjugado gradiente (alpha) |
| `v3z_an08` | AN8 Erro trapezio (modulo) |
| `v3z_an10` | AN10 Erro Simpson (modulo) |
| `v3z_an18` | AN18 Adams-Bashforth 4 passos |

#### Vol3: Bioinformatica

| ID | Fórmula/Equação |
|---|---|
| `v3_bi01` | Needleman-Wunsch (passo local) |
| `v3_bi02` | Distancia de Jukes-Cantor |
| `v3_bs01` | FBA objetivo linear |
| `v3_ev01` | Equacao do replicador |
| `v3x_bi03` | Hardy-Weinberg (heterozigoto) |
| `v3x_bi04` | BLAST E-value |
| `v3x_ev02` | Equacao de Price (termo de selecao) |
| `v3z_bi06` | BI6 BLAST E-value |
| `v3z_bs04` | BS4 Hill (cooperatividade) |

#### Vol3: Caos e Fractais

| ID | Fórmula/Equação |
|---|---|
| `v3_ca01` | Mapa logistico (1 passo) |
| `v3_fr01` | Dimensao fractal autossimilar |
| `v3_lz01` | Divergencia de trajetorias |
| `v3x_ca02` | Bifurcacao pitchfork normal |
| `v3x_fr02` | Mandelbrot (1 iteracao) |
| `v3z_lz07` | LZ7 Dimensao Kaplan-Yorke |

#### Vol3: CFD e Turbulencia

| ID | Fórmula/Equação |
|---|---|
| `v3_cf01` | CFL |
| `v3_ns01` | Numero de Reynolds |
| `v3_tb01` | Viscosidade turbulenta k-epsilon |
| `v3x_ns02` | Numero de Prandtl |
| `v3x_ns03` | Numero de Nusselt |
| `v3z_tb09` | TB9 Smagorinsky nu_sgs |

#### Vol3: Ciencias do Clima

| ID | Fórmula/Equação |
|---|---|
| `v3_cl01` | Parametro de Coriolis |
| `v3_cl02` | EBM 0D (taxa de aquecimento) |
| `v3_cl03` | Sensibilidade climatica ECS |
| `v3x_cl04` | Vento geostrofico (ug) |
| `v3x_cl05` | Relacao de dispersao de Rossby |
| `v3x_cl06` | Oscilador ENSO atrasado |
| `v3z_cl12` | CL12 Forcamento 2xCO2 |

#### Vol3: Financas Quantitativas

| ID | Fórmula/Equação |
|---|---|
| `v3_capm01` | CAPM |
| `v3_gr01` | Black-Scholes Call |
| `v3_mk01` | Retorno esperado da carteira (2 ativos) |
| `v3_mk02` | Sharpe ratio |
| `v3_ri01` | VaR parametrico |
| `v3x_fn02` | APT 2 fatores |
| `v3x_gr02` | Delta de call (Black-Scholes) |
| `v3x_gr03` | Paridade put-call |
| `v3z_gr04` | GR4 Vega |
| `v3z_ri02` | RI2 Expected Shortfall discreto |

#### Vol3: Fisica de Plasmas

| ID | Fórmula/Equação |
|---|---|
| `v3_mh01` | Velocidade de Alfven |
| `v3_pl01` | Comprimento de Debye |
| `v3_pl02` | Frequencia de plasma |
| `v3x_pl03` | Beta de plasma |
| `v3z_pl04` | PL4 Criterio de plasma (Lambda) |

#### Vol3: Fisica Nuclear

| ID | Fórmula/Equação |
|---|---|
| `v3_nu01` | Raio nuclear |
| `v3_nu02` | Q-valor |
| `v3_nu03` | Secao de choque |
| `v3x_nu04` | Energia de ligacao por nucleon |
| `v3z_nu10` | NU10 Taxa de reacoes por secao de choque |

#### Vol3: Geoestatistica

| ID | Fórmula/Equação |
|---|---|
| `v3_ge01` | Semivariograma |
| `v3_ge02` | Covariancia exponencial |
| `v3_ge03` | Kriging ordinario (estimador linear) |
| `v3x_ge04` | Nugget (efeito pepita) |
| `v3x_ge05` | Variancia de kriging |
| `v3z_ge10` | GE10 Variancia de kriging (forma linear) |

#### Vol3: Geometria Algebrica

| ID | Fórmula/Equação |
|---|---|
| `v3_ce01` | Discriminante de Weierstrass |
| `v3_ce02` | Soma de pontos - inclinacao secante |
| `v3_ga01` | Genero de curva plana lisa |
| `v3x_ce03` | Curva eliptica - inclinacao tangente |
| `v3z_ce10` | CE10 Dificuldade ECDLP (bits) |
| `v3z_ga05` | GA5 Bezout (contagem teorica) |

#### Vol3: Logica Matematica

| ID | Fórmula/Equação |
|---|---|
| `v3_gd01` | Codificacao de Godel simplificada |
| `v3_lm01` | Avaliacao de implicacao |
| `v3x_lm02` | Formula booleana de compacidade (toy) |
| `v3z_g1` | G1 Incompletude (indicador toy) |

#### Vol3: Materia Condensada

| ID | Fórmula/Equação |
|---|---|
| `v3_fn01` | Lei T^3 de Debye (aprox) |
| `v3_mc01` | Dispersao eletron livre |
| `v3_mc02` | Condutividade de Drude |
| `v3_sc01` | Quantum de fluxo |
| `v3x_mc03` | Coeficiente Hall classico |
| `v3x_sc02` | Comprimento de penetracao de London |
| `v3z_fn02` | FN2 Debye integral (aprox discreta) |
| `v3z_sc01` | SC1 Temperatura critica BCS |

#### Vol3: Mecanica da Fratura

| ID | Fórmula/Equação |
|---|---|
| `v3_fd01` | Lei de Paris |
| `v3_fd02` | Dano acumulado de Miner |
| `v3_mf01` | Fator de intensidade KI |
| `v3x_fd03` | Criterio de Goodman |
| `v3x_mf03` | Taxa de liberacao de energia |
| `v3z_fd02` | FD2 Limite de fadiga corrigido |

#### Vol3: Optica Quantica

| ID | Fórmula/Equação |
|---|---|
| `v3_oq01` | Energia de modo quantizado |
| `v3_oq02` | Media de fotons em estado coerente |
| `v3_oq03` | CHSH maximo quantico |
| `v3x_oq04` | Poisson de estado coerente |
| `v3z_oq10` | OQ10 Ganho saturado do laser |

#### Vol3: Pesquisa Operacional

| ID | Fórmula/Equação |
|---|---|
| `v3_po01` | Valor objetivo linear |
| `v3_po02` | M/M/1 - numero medio no sistema |
| `v3_po03` | Lei de Little |
| `v3x_po04` | Knapsack 0-1 (2 itens) |
| `v3z_po08` | PO8 Bellman (passo) |
| `v3z_tf04` | TF4 M/G/1 Pollaczek-Khinchine |

#### Vol3: Robotica

| ID | Fórmula/Equação |
|---|---|
| `v3_rb01` | Jacobiano planar 2R (det) |
| `v3_rb02` | Controle PD (1 junta) |
| `v3x_rb03` | Cinematica direta 2R (x) |
| `v3x_rb04` | Indicador de singularidade Jacobiana |
| `v3z_rb13` | RB13 Torque computado (1 GDL) |

#### Vol3: Sistemas de Potencia

| ID | Fórmula/Equação |
|---|---|
| `v3_sp01` | Corrente de curto trifasico |
| `v3_sp02` | Equacao swing (aceleracao) |
| `v3_sp03` | Fluxo de carga DC |
| `v3x_sp04` | Potencia eletrica da maquina sincrona |
| `v3x_sp05` | Passo Newton-Raphson (escalar) |
| `v3z_sp07` | SP7 Potencia de curto em base |

#### Vol3: Teoria da Medida

| ID | Fórmula/Equação |
|---|---|
| `v3_il01` | Integral de funcao constante |
| `v3_rn01` | Derivada de Radon-Nikodym (densidade) |
| `v3_tm01` | Medida de Lebesgue em intervalo |
| `v3x_il02` | Fatou (limite inferior comparativo) |
| `v3x_tm02` | Medida de contar em conjunto finito |
| `v3z_il06` | IL6 Fubini (soma separavel) |
| `v3z_rn04` | RN4 Dual Lp-Lq (funcional) |
| `v3z_tm07` | TM7 Continuidade por cima (delta) |

#### Vol3: Teoria das Categorias

| ID | Fórmula/Equação |
|---|---|
| `v3_tc01` | Cardinalidade do produto cartesiano |
| `v3_tc02` | Cardinalidade do coproduto disjunto |
| `v3x_tc03` | Adjuncao em Set (contagem simplificada) |
| `v3z_tc11` | TC11 Yoneda (contagem em Set) |

#### Vol3: Valores Extremos e Copulas

| ID | Fórmula/Equação |
|---|---|
| `v3_co01` | Copula de Clayton |
| `v3_ve01` | Gumbel CDF |
| `v3_ve02` | VaR normal |
| `v3x_co02` | Copula de Gumbel |
| `v3x_ve03` | CVaR normal (aprox) |
| `v3z_ve07` | VE7 Value at Risk por quantil |

#### Óptica Quântica

| ID | Fórmula/Equação |
|---|---|
| `3_oq01` | Campo Elétrico Quantizado |
| `3_oq02` | Relações de Comutação Bosônicas |
| `3_oq03` | Hamiltoniano do Campo EM |
| `3_oq04` | Estados de Fock \|n⟩ |
| `3_oq05` | Estado Coerente \|α⟩ |
| `3_oq06` | Estatísticas do Estado Coerente |
| `3_oq07` | Equações de Taxa do Laser (N₂) |
| `3_oq08` | Equações de Taxa do Laser (fótons) |
| `3_oq09` | Inversão de População (Condição Laser) |
| `3_oq10` | Perfil de Ganho do Laser |
| `3_oq11` | Estado de Bell Óptico |
| `3_oq12` | Desigualdade CHSH (Bell) |
| `3_oq13` | Violação Quântica (Bound de Tsirelson) |
| `3_oq14` | Teleportação Quântica |

</details>

<details>
<summary><b>Volume IV — 532 fórmulas</b></summary>

#### Categorias
- AdS/CFT e Holografia (11)
- Alta Dimensionalidade (18)
- Análise p-Ádica (23)
- Aprendizado por Reforço (21)
- Codificação e Comunicações (13)
- Controle Não-Linear e Ótimo (17)
- Cosmologia Inflacionária (22)
- Criptografia Pós-Quântica (31)
- Dispositivos Semicondutores (14)
- Formas Modulares (23)
- Geometria Simplética (20)
- GNN e Geometria Profunda (17)
- Gravidade Quântica e Cordas (29)
- Hidrologia e Combustão (17)
- Imagem Médica (32)
- Inferência Causal (17)
- Informação Quântica Avançada (13)
- Morfogênese e Turing (22)
- Psicometria e IRT (24)
- Redes Complexas (22)
- Renormalização e SUSY (21)
- Teoria dos Jogos (18)
- Teoria Ergódica (19)
- Topologia Algébrica Avançada (38)
- Transporte Ótimo e TDA (30)

#### AdS/CFT e Holografia

| ID | Fórmula/Equação |
|---|---|
| `4_ac01` | Correspondência AdS/CFT |
| `4_ac02` | Caso Canônico |
| `4_ac03` | Dicionário AdS/CFT |
| `4_ac04` | Relação Massa-Dimensão |
| `4_ac05` | Métrica de AdS_{d+1} |
| `4_ac06` | Limite de N Grande |
| `4_ac07` | Fórmula de Ryu-Takayanagi |
| `4_ac08` | Entropia de Bekenstein-Hawking |
| `4_ac09` | ER = EPR |
| `4_ac10` | Complexidade = Volume |
| `4_ac11` | Complexidade = Ação |

#### Alta Dimensionalidade

| ID | Fórmula/Equação |
|---|---|
| `4_hd01` | Ridge Regression |
| `4_hd02` | LASSO |
| `4_hd03` | Elastic Net |
| `4_hd04` | Oracle Inequality (LASSO) |
| `4_hd05` | Compressed Sensing (RIP) |
| `4_hd06` | Dantzig Selector |
| `4_hd07` | Group LASSO |
| `4_hd08` | Taxa Minimax Esparsa |
| `4_hd09` | Correção de Múltiplos Testes (BH) |
| `4_hd10` | Debiased LASSO |
| `4_hd11` | Sinal-Ruído Efetivo |
| `4_hd12` | Desvio de Generalização |
| `4_rm01` | Ensemble GOE |
| `4_rm02` | Ensemble GUE |
| `4_rm03` | Lei do Semicírculo de Wigner |
| `4_rm04` | Lei de Marchenko-Pastur |
| `4_rm05` | Distribuição de Tracy-Widom |
| `4_rm06` | Spike Model (BBP Transition) |

#### Análise p-Ádica

| ID | Fórmula/Equação |
|---|---|
| `4_ap01` | Norma p-Ádica |
| `4_ap02` | Ultramétrica |
| `4_ap03` | Série Geométrica p-Ádica |
| `4_ap04` | Distância p-Ádica |
| `4_ap05` | Bola p-Ádica |
| `4_ap06` | Inteiros p-Ádicos |
| `4_ap07` | Unidades p-Ádicas |
| `4_ap08` | Lema de Hensel (passo) |
| `4_ap09` | Medida de Haar em Z_p |
| `4_ap10` | Transformada de Mahler |
| `4_ap11` | Log p-Ádico |
| `4_ap12` | Exp p-Ádica |
| `4_ap13` | Medida de Valoração |
| `4_ap14` | Série de Laurent p-Ádica |
| `4_ap15` | Módulo p-Ádico de Diferença |
| `4_pa01` | Valor Absoluto p-Ádico |
| `4_pa02` | Desigualdade Ultramétrica |
| `4_pa03` | Corpo ℚₚ |
| `4_pa04` | Inteiros p-Ádicos |
| `4_pa05` | Expansão p-Ádica |
| `4_pa06` | Fórmula do Produto de Ostrowski |
| `4_pa07` | Lema de Hensel |
| `4_pa08` | Função Zeta p-Ádica |

#### Aprendizado por Reforço

| ID | Fórmula/Equação |
|---|---|
| `4_rl01` | Processo de Decisão de Markov (MDP) |
| `4_rl02` | Retorno Descontado |
| `4_rl03` | Função Valor-Estado V(s) |
| `4_rl04` | Função Valor-Ação Q(s,a) |
| `4_rl05` | Equação de Bellman (V) |
| `4_rl06` | Equação de Optimalidade de Bellman |
| `4_rl07` | Temporal Difference TD(0) |
| `4_rl08` | SARSA |
| `4_rl09` | Q-Learning |
| `4_rl10` | DQN (Deep Q-Network) |
| `4_rl11` | Double DQN |
| `4_rl12` | Policy Gradient (REINFORCE) |
| `4_rl13` | REINFORCE com Baseline |
| `4_rl14` | Função Vantagem |
| `4_rl15` | Actor-Critic (A2C) |
| `4_rl16` | A3C |
| `4_rl17` | PPO (Proximal Policy Optimization) |
| `4_rl18` | TRPO (Trust Region Policy Opt.) |
| `4_rl19` | SAC (Soft Actor-Critic) |
| `4_rl20` | Generalized Advantage Estimation (GAE) |
| `4_rl21` | RLHF (RL from Human Feedback) |

#### Codificação e Comunicações

| ID | Fórmula/Equação |
|---|---|
| `4_cd01` | Capacidade do Canal AWGN |
| `4_cd02` | Distância de Hamming |
| `4_cd03` | Bound de Singleton |
| `4_cd04` | Códigos LDPC |
| `4_cd05` | Códigos Turbo |
| `4_cd06` | Códigos Polares |
| `4_cd07` | Capacidade MIMO |
| `4_cd08` | Fórmula de Alamouti (STBC) |
| `4_of01` | OFDM (Orthogonal FDM) |
| `4_of02` | Prefixo Cíclico |
| `4_of03` | PAPR (Peak-to-Average Power Ratio) |
| `4_of04` | Equalização de Canal OFDM |
| `4_of05` | QAM (Modulação) |

#### Controle Não-Linear e Ótimo

| ID | Fórmula/Equação |
|---|---|
| `4_nl01` | Linearização por Realimentação |
| `4_nl02` | Derivada de Lie |
| `4_nl03` | Backstepping |
| `4_nl04` | Sliding Mode Control (SMC) |
| `4_nl05` | MRAC (Controle Adaptativo) |
| `4_nl06` | Estabilidade de Lyapunov (Revisitada) |
| `4_nl07` | CLF (Control Lyapunov Function) |
| `4_nl08` | CBF (Control Barrier Function) |
| `4_nl09` | Passividade |
| `4_nl10` | Gain Scheduling |
| `4_oc01` | Princípio Máximo de Pontryagin |
| `4_oc02` | Regulador Linear Quadrático (LQR) |
| `4_oc03` | Equação de Riccati (Algébrica) |
| `4_oc04` | Equação de Hamilton-Jacobi-Bellman |
| `4_oc05` | Controle Bang-Bang |
| `4_oc06` | Model Predictive Control (MPC) |
| `4_oc07` | Programação Dinâmica (Bellman) |

#### Cosmologia Inflacionária

| ID | Fórmula/Equação |
|---|---|
| `4_bsm01` | Densidade Relíquia de WIMP |
| `4_bsm02` | Massa de Axion |
| `4_bsm03` | Equação de Estado da Energia Escura |
| `4_bsm04` | Mecanismo de Seesaw |
| `4_bsm05` | Unificação SU(5) (Georgi-Glashow) |
| `4_bsm06` | Decaimento do Próton (GUT) |
| `4_bsm07` | Bariogênese (Condições de Sakharov) |
| `4_ci01` | Campo Inflaton |
| `4_ci02` | Equação de Friedmann (com inflaton) |
| `4_ci03` | Parâmetros de Slow-Roll |
| `4_ci04` | Número de e-folds |
| `4_ci05` | Espectro de Potência Escalar |
| `4_ci06` | Índice Espectral |
| `4_ci07` | Razão Tensor/Escalar |
| `4_ci08` | Relação de Consistência |
| `4_ci09` | Parâmetro Hubble Inflacionário |
| `4_ci10` | Energia do Inflaton |
| `4_ci11` | Pressão do Inflaton |
| `4_ci12` | Equação de Estado do Inflaton |
| `4_ci13` | Potencial Quadrático |
| `4_ci14` | Potencial de Higgs-like |
| `4_ci15` | Escala de Energia Inflacionária |

#### Criptografia Pós-Quântica

| ID | Fórmula/Equação |
|---|---|
| `4_cp01` | Parâmetro de Módulo |
| `4_cp02` | Dimensão do Reticulado |
| `4_cp03` | Magnitude do Erro |
| `4_cp04` | Nível de Segurança |
| `4_cp05` | Relação Segurança-Módulo |
| `4_cp06` | Razão q/n |
| `4_cp07` | Sinal sobre Erro |
| `4_cp08` | Margem de Decodificação |
| `4_cp09` | Custo de Chave Pública |
| `4_cp10` | Custo de Cifra |
| `4_cp11` | Custo de Multiplicação Polinomial |
| `4_cp12` | Complexidade de Ataque BKZ |
| `4_cp13` | Nível NIST Aproximado |
| `4_cp14` | Erro Relativo |
| `4_cp15` | Orçamento de Segurança |
| `4_cp16` | Probabilidade de Falha |
| `4_cp17` | Score de Segurança Composto |
| `4_lt01` | Reticulado (Definição) |
| `4_lt02` | SVP (Shortest Vector Problem) |
| `4_lt03` | CVP (Closest Vector Problem) |
| `4_lt04` | LWE (Learning with Errors) |
| `4_lt05` | Ring-LWE |
| `4_lt06` | SIS (Short Integer Solution) |
| `4_lt07` | Redução de Base LLL |
| `4_pq01` | CRYSTALS-Kyber (ML-KEM) |
| `4_pq02` | CRYSTALS-Dilithium (ML-DSA) |
| `4_pq03` | FALCON |
| `4_pq04` | SPHINCS+ (SLH-DSA) |
| `4_pq05` | McEliece (Cód. Corretores) |
| `4_pq06` | Algoritmo de Shor |
| `4_pq07` | Complexidade de Grover (Busca) |

#### Dispositivos Semicondutores

| ID | Fórmula/Equação |
|---|---|
| `4_sc01` | Equação de Poisson (Semicondutor) |
| `4_sc02` | Equação de Continuidade (Elétrons) |
| `4_sc03` | Corrente Drift-Diffusion |
| `4_sc04` | Relação de Einstein |
| `4_sc05` | Recombinação SRH |
| `4_sc06` | Equação do Diodo de Shockley |
| `4_sc07` | Largura da Região de Depleção |
| `4_sc08` | Potencial Built-in |
| `4_sc09` | Corrente de Saturação |
| `4_sc10` | MOSFET (Corrente Triodo) |
| `4_sc11` | MOSFET (Corrente Saturação) |
| `4_sc12` | Tensão de Threshold |
| `4_sc13` | BJT (Corrente IC) |
| `4_sc14` | Corrente de Tunelamento (FN) |

#### Formas Modulares

| ID | Fórmula/Equação |
|---|---|
| `4_fl01` | Função Zeta de Riemann |
| `4_fl02` | Equação Funcional de ζ |
| `4_fl03` | Zeros Triviais de ζ |
| `4_fl04` | Hipótese de Riemann |
| `4_fl05` | Função L de Dirichlet |
| `4_fl06` | Teorema de Dirichlet (Primos em PA) |
| `4_fl07` | Função L de Forma Modular |
| `4_fl08` | Conjectura de Birch e Swinnerton-Dyer |
| `4_fm01` | Grupo Modular SL₂(ℤ) |
| `4_fm02` | Ação do Grupo Modular |
| `4_fm03` | Forma Modular de Peso k |
| `4_fm04` | Expansão de Fourier (q-expansão) |
| `4_fm05` | Séries de Eisenstein |
| `4_fm06` | G₄ e G₆ Normalizadas |
| `4_fm07` | Discriminante Modular Δ |
| `4_fm08` | j-Invariante |
| `4_fm09` | Operadores de Hecke |
| `4_fm10` | Forma Cúspide |
| `4_fm11` | Parâmetro Modular |
| `4_fm12` | q-Expansão Truncada |
| `4_fm13` | Série de Eisenstein E_k |
| `4_fm14` | Discriminante Δ(τ) |
| `4_fm15` | j-Invariante Aproximado |

#### Geometria Simplética

| ID | Fórmula/Equação |
|---|---|
| `4_gs01` | Forma Simplética |
| `4_gs02` | Condições Simplética |
| `4_gs03` | Forma Canônica de Darboux |
| `4_gs04` | Teorema de Darboux |
| `4_gs05` | Campo Hamiltoniano |
| `4_gs06` | Estrutura Quase-Complexa Canônica |
| `4_gs07` | Teorema de Liouville (Simplético) |
| `4_gs08` | Volume de Liouville |
| `4_gs09` | Redução Simplética (Marsden-Weinstein) |
| `4_gs10` | Mapa Momento |
| `4_po01` | Colchete de Poisson |
| `4_po02` | Tensor de Poisson |
| `4_po03` | Condição de Jacobi (Poisson) |
| `4_po04` | Simplético como Poisson Não-Degenerado |
| `4_po05` | Folheação Simplética |
| `4_qg01` | Pré-Quantização (Fibrado de Linha) |
| `4_qg02` | Operador de Pré-Quantização |
| `4_qg03` | Polarização |
| `4_qg04` | Polarização Vertical |
| `4_qg05` | Correção Metaplética |

#### GNN e Geometria Profunda

| ID | Fórmula/Equação |
|---|---|
| `4_ge01` | Equivariância E(n) |
| `4_ge02` | EGNN (E(n) Equivariant GNN) |
| `4_ge03` | SE(3)-Transformer |
| `4_ge04` | AlphaFold2 (Evoformer) |
| `4_ge05` | Harmônicos Esféricos |
| `4_gi01` | Métrica de Fisher |
| `4_gi02` | Natural Gradient |
| `4_gi03` | α-Conexão de Amari |
| `4_gi04` | Divergência de Bregman |
| `4_gi05` | Curvatura de Fisher do Modelo Normal |
| `4_gi06` | Distância de Wasserstein (Info-Geom) |
| `4_gn01` | GCN (Graph Convolutional Network) |
| `4_gn02` | GAT (Graph Attention Network) |
| `4_gn03` | GraphSAGE |
| `4_gn04` | Message Passing Neural Network (MPNN) |
| `4_gn05` | GIN (Graph Isomorphism Network) |
| `4_gn06` | Readout Global (Graph-Level) |

#### Gravidade Quântica e Cordas

| ID | Fórmula/Equação |
|---|---|
| `4_gq01` | Comprimento de Planck |
| `4_gq02` | Área de Planck |
| `4_gq03` | Entropia de Bekenstein-Hawking |
| `4_gq04` | Número de Microestados |
| `4_gq05` | Ação de Einstein-Hilbert |
| `4_gq06` | Partição Quântica |
| `4_gq07` | Escala de Curvatura |
| `4_gq08` | Critério Semiclássico |
| `4_gq09` | Quanta de Área |
| `4_gq10` | Densidade de Estados |
| `4_lq01` | Variáveis de Ashtekar |
| `4_lq02` | Holonomia (LQG) |
| `4_lq03` | Spin Network |
| `4_lq04` | Espectro de Área (LQG) |
| `4_lq05` | Espectro de Volume (LQG) |
| `4_lq06` | Vínculo Hamiltoniano |
| `4_lq07` | Entropia de BN em LQG |
| `4_lq08` | Loop Quantum Cosmology (LQC) |
| `4_lq09` | Spin Foam |
| `4_st01` | Ação de Nambu-Goto |
| `4_st02` | Ação de Polyakov |
| `4_st03` | Dimensão Crítica |
| `4_st04` | Espectro de Massa (Corda Aberta) |
| `4_st05` | Álgebra de Virasoro |
| `4_st06` | T-Dualidade |
| `4_st07` | S-Dualidade |
| `4_st08` | D-Branas |
| `4_st09` | Acoplamento de Corda |
| `4_st10` | Massa de Corda Fundamental |

#### Hidrologia e Combustão

| ID | Fórmula/Equação |
|---|---|
| `4_cb01` | Número de Damköhler |
| `4_cb02` | Mecanismo de Zeldovich (NOx) |
| `4_cb03` | Velocidade de Chama Laminar |
| `4_cb04` | Taxa de Arrhenius |
| `4_cb05` | Espessura de Chama |
| `4_hy01` | Equações de Saint-Venant |
| `4_hy02` | Velocidade de Manning |
| `4_hy03` | Lei de Darcy |
| `4_hy04` | Equação de Richards |
| `4_hy05` | Modelo de van Genuchten |
| `4_hy06` | Equação de Advecção-Dispersão |
| `4_pl01` | Critério de von Mises |
| `4_pl02` | Critério de Tresca |
| `4_pl03` | Lei de Fluxo Associada |
| `4_pl04` | Endurecimento Isotrópico |
| `4_pl05` | Endurecimento Cinemático |
| `4_pl06` | Critério de Drucker-Prager |

#### Imagem Médica

| ID | Fórmula/Equação |
|---|---|
| `4_bm01` | Hiperelasticidade (Geral) |
| `4_bm02` | Neo-Hookean |
| `4_bm03` | Mooney-Rivlin |
| `4_bm04` | Modelo de Ogden |
| `4_bm05` | Viscoelasticidade (Maxwell) |
| `4_bm06` | Viscoelasticidade (Kelvin-Voigt) |
| `4_bm07` | Elastografia (Onda de Cisalhamento) |
| `4_ct01` | Transformada de Radon |
| `4_ct02` | Teorema da Fatia de Fourier |
| `4_ct03` | Retroprojeção Filtrada (FBP) |
| `4_ct04` | Reconstrução Iterativa (MBIR) |
| `4_ct05` | Número de CT (Hounsfield) |
| `4_ct06` | Dose de Radiação (CTDI) |
| `4_im01` | Atenuação de Beer-Lambert |
| `4_im02` | Contraste de Intensidade |
| `4_im03` | SNR |
| `4_im04` | PSNR |
| `4_im05` | RMSE |
| `4_im06` | Amostragem em k-space |
| `4_im07` | Extensão de Campo de Visão |
| `4_im08` | Sinal MRI (T1/T2) |
| `4_im09` | Tempo de Relaxamento Longitudinal |
| `4_im10` | Tempo de Relaxamento Transversal |
| `4_im11` | Resolução Espacial |
| `4_im12` | Janela de Intensidade |
| `4_im13` | Coeficiente de Dice |
| `4_im14` | Erro de Reconstrução |
| `4_im15` | Tempo de Aquisição |
| `4_pt01` | Modelo PET de Emissão |
| `4_pt02` | MLEM (ML-EM) |
| `4_pt03` | OSEM |
| `4_pt04` | SUV (Standardized Uptake Value) |

#### Inferência Causal

| ID | Fórmula/Equação |
|---|---|
| `4_ec01` | Variáveis Instrumentais (IV) |
| `4_ec02` | GMM (Método Generalizado de Momentos) |
| `4_ec03` | Efeitos Fixos (Painel) |
| `4_ec04` | Efeitos Aleatórios (Painel) |
| `4_ec05` | Teste de Hausman |
| `4_ec06` | Diferença-em-Diferenças (DiD) |
| `4_ec07` | Regressão Descontínua (RDD) |
| `4_ec08` | Controle Sintético |
| `4_ic01` | Operador do (Pearl) |
| `4_ic02` | Fórmula de Ajuste (Backdoor) |
| `4_ic03` | Efeito Causal Médio (ATE) |
| `4_ic04` | Efeito Local (LATE/CATE) |
| `4_ic05` | Fórmula do Frontdoor |
| `4_ic06` | do-Calculus (3 Regras) |
| `4_ic07` | SCM (Structural Causal Model) |
| `4_ic08` | Propensity Score |
| `4_ic09` | Double Machine Learning |

#### Informação Quântica Avançada

| ID | Fórmula/Equação |
|---|---|
| `4_qi01` | Operadores de Kraus |
| `4_qi02` | Canal Despolarizante |
| `4_qi03` | Canal de Amortecimento de Amplitude |
| `4_qi04` | Canal de Defasamento (Dephasing) |
| `4_qi05` | Capacidade de Holevo |
| `4_qi06` | Informação Coerente |
| `4_qi07` | Código Estabilizador |
| `4_qi08` | Código de Superfície |
| `4_qi09` | Código Tórico |
| `4_qi10` | Threshold Theorem (FT) |
| `4_qi11` | Emaranhamento Multipartido (GHZ) |
| `4_qi12` | Entropia de Emaranhamento |
| `4_qi13` | Distilação de Emaranhamento |

#### Morfogênese e Turing

| ID | Fórmula/Equação |
|---|---|
| `4_tu01` | Reação-Difusão (Geral) |
| `4_tu02` | Condição de Instabilidade de Turing |
| `4_tu03` | Modelo de Gierer-Meinhardt |
| `4_tu04` | Modelo de Gray-Scott |
| `4_tu05` | Equação de Swift-Hohenberg |
| `4_tu06` | Equação de Cahn-Hilliard |
| `4_tu07` | Quimiotaxia (Keller-Segel) |
| `4_tu08` | Onda de Propagação (Fisher-KPP) |
| `4_tu09` | Difusão Relativa |
| `4_tu10` | Termo de Reação f(u,v) |
| `4_tu11` | Termo de Reação g(u,v) |
| `4_tu12` | Número de Onda Crítico |
| `4_tu13` | Comprimento de Onda do Padrão |
| `4_tu14` | Crescimento Linear de Perturbação |
| `4_wc01` | Modelo de Wilson-Cowan |
| `4_wc02` | Wilson-Cowan (Inibitória) |
| `4_wc03` | Bifurcação de Hopf (Oscilações) |
| `4_wc04` | Neural Field Equation |
| `4_wc05` | FitzHugh-Nagumo |
| `4_wc06` | Izhikevich (Neurônio) |
| `4_wc07` | Wilson-Cowan em Equilíbrio |
| `4_wc08` | Constante de Tempo Efetiva |

#### Psicometria e IRT

| ID | Fórmula/Equação |
|---|---|
| `4_ir01` | Modelo Rasch (1PL) |
| `4_ir02` | Modelo 2PL |
| `4_ir03` | Modelo 3PL |
| `4_ir04` | Modelo 4PL |
| `4_ir05` | Função de Informação do Item |
| `4_ir06` | Informação do Teste |
| `4_ir07` | Estimação MLE (θ̂) |
| `4_ir08` | DIF (Differential Item Functioning) |
| `4_ps01` | Função Logística IRT |
| `4_ps02` | Inclinação no Ponto b |
| `4_ps03` | Efeito de Dificuldade |
| `4_ps04` | Informação do Item (2PL) |
| `4_ps05` | Erro Padrão da Habilidade |
| `4_ps06` | Atualização de Newton para θ |
| `4_ps07` | Índice de Dificuldade Médio |
| `4_ps08` | Discriminação Média |
| `4_ps09` | Diferença de Habilidade (ITE Psic.) |
| `4_ps10` | Efeito Médio (ATE Psic.) |
| `4_ps11` | Parâmetro de Habilidade Padronizado |
| `4_ps12` | Função de Informação Agregada |
| `4_sm01` | CFA (Análise Fatorial Confirmatória) |
| `4_sm02` | Modelo Estrutural (SEM) |
| `4_sm03` | Equações de Medida (Completo) |
| `4_sm04` | Índices de Ajuste (SEM) |

#### Redes Complexas

| ID | Fórmula/Equação |
|---|---|
| `4_rc01` | Distribuição de Grau |
| `4_rc02` | Rede Scale-Free (Lei de Potência) |
| `4_rc03` | Propriedade Small-World |
| `4_rc04` | Coeficiente de Clustering |
| `4_rc05` | Centralidade de Betweenness |
| `4_rc06` | PageRank |
| `4_rc07` | Modularidade (Newman-Girvan) |
| `4_rc08` | Modelo Erdős-Rényi |
| `4_rc09` | Modelo Barabási-Albert (Preferential Attachment) |
| `4_rc10` | Stochastic Block Model (SBM) |
| `4_rc11` | Percolação em Redes |
| `4_rc12` | Modelo SIR em Redes |
| `4_rc13` | Modelo de Cascatas (Watts) |
| `4_rc14` | Rede Multiplex |
| `4_rc15` | Grafo Bipartido / Projeção |
| `4_rc16` | Assortativity (Correlação de Grau) |
| `4_rc17` | Espectro do Laplaciano |
| `4_rc18` | Grau Médio |
| `4_rc19` | Clustering Médio |
| `4_rc20` | Comprimento Médio de Caminho |
| `4_rc21` | Raio Espectral |
| `4_rc22` | Limiar Epidêmico em Rede |

#### Renormalização e SUSY

| ID | Fórmula/Equação |
|---|---|
| `4_rg01` | Transformação do GR (Wilson) |
| `4_rg02` | Ponto Fixo do GR |
| `4_rg03` | Operador Relevante |
| `4_rg04` | Operador Irrelevante |
| `4_rg05` | Operador Marginal |
| `4_rg06` | Universalidade |
| `4_rn01` | Regularização Dimensional |
| `4_rn02` | Esquema MS-bar |
| `4_rn03` | Equação de Callan-Symanzik |
| `4_rn04` | Função Beta da QED |
| `4_rn05` | Função Beta da QCD |
| `4_rn06` | Running Coupling (QCD) |
| `4_rn07` | Dimensão Anômala |
| `4_rn08` | Contratermo |
| `4_sy01` | Álgebra de Supersimetria (N=1) |
| `4_sy02` | Supercampo Quiral |
| `4_sy03` | Superpotencial |
| `4_sy04` | Potencial Escalar SUSY |
| `4_sy05` | Quebra Suave de SUSY |
| `4_sy06` | Unificação de Gauge (MSSM) |
| `4_sy07` | Teorema de Não-Renormalização |

#### Teoria dos Jogos

| ID | Fórmula/Equação |
|---|---|
| `4_tj01` | Equilíbrio de Nash |
| `4_tj02` | Estratégias Mistas |
| `4_tj03` | Teorema Minimax |
| `4_tj04` | Equilíbrio Perfeito em Subjogos (SPE) |
| `4_tj05` | Equilíbrio Bayesiano de Nash (BNE) |
| `4_tj06` | Leilão de Vickrey (Segundo Preço) |
| `4_tj07` | Mecanismo VCG |
| `4_tj08` | Teorema da Revelação |
| `4_tj09` | Receita Esperada (Equivalência) |
| `4_tj10` | Dinâmica do Replicador |
| `4_tj11` | ESS (Estratégia Evolutivamente Estável) |
| `4_tj12` | Valor de Shapley |
| `4_tj13` | Core (Núcleo) |
| `4_tj14` | Negociação de Nash |
| `4_tj15` | Dilema do Prisioneiro (Iterado) |
| `4_tj16` | Folk Theorem |
| `4_tj17` | Equilíbrio Correlacionado |
| `4_tj18` | Leilão de Myerson (Ótimo) |

#### Teoria Ergódica

| ID | Fórmula/Equação |
|---|---|
| `4_er01` | Sistema Dinâmico Medido |
| `4_er02` | Ergodicidade |
| `4_er03` | Teorema Ergódico de Birkhoff |
| `4_er04` | Teorema Ergódico de von Neumann |
| `4_er05` | Mixing Forte |
| `4_er06` | Entropia de Kolmogorov-Sinai |
| `4_er07` | Entropia de Partição |
| `4_er08` | Teorema de Ornstein |
| `4_er09` | Princípio Variacional (Entropia Topológica) |
| `4_te01` | Sistema Medido |
| `4_te02` | Invariância de Medida |
| `4_te03` | Média Temporal |
| `4_te04` | Média Espacial |
| `4_te05` | Critério de Ergodicidade |
| `4_te06` | Mixing |
| `4_te07` | Entropia Métrica |
| `4_te08` | Entropia de Partição |
| `4_te09` | Correlações Temporais |
| `4_te10` | Expoente de Lyapunov Médio |

#### Topologia Algébrica Avançada

| ID | Fórmula/Equação |
|---|---|
| `4_ah01` | Complexo de Cadeia |
| `4_ah02` | Grupo de Homologia |
| `4_ah03` | Resolução Projetiva |
| `4_ah04` | Funtor Tor |
| `4_ah05` | Funtor Ext |
| `4_ah06` | Sequência Exata Longa (Tor) |
| `4_ah07` | Lema da Serpente |
| `4_ah08` | Fórmula de Künneth |
| `4_kt01` | K⁰(X) — Grupo de Grothendieck |
| `4_kt02` | K-Teoria Reduzida |
| `4_kt03` | Periodicidade de Bott |
| `4_kt04` | Sequência Exata de K-Teoria |
| `4_kt05` | Teorema do Índice (Atiyah-Singer) |
| `4_kt06` | Classe Â (A-hat) |
| `4_kt07` | Caractere de Chern |
| `4_se01` | Sequência Espectral |
| `4_se02` | Página Sucessiva |
| `4_se03` | Sequência Espectral de Serre |
| `4_se04` | Leray-Hirsch |
| `4_se05` | Sequência Espectral de Adams |
| `4_ta01` | Grupo de Homologia H_n |
| `4_ta02` | Números de Betti |
| `4_ta03` | Características de Euler |
| `4_ta04` | Cohomologia H^n |
| `4_ta05` | Produto Cup |
| `4_ta06` | Dualidade de Poincare |
| `4_ta07` | Sequência de Mayer-Vietoris |
| `4_ta08` | Teorema de Hurewicz |
| `4_ta09` | Teorema Universal de Coeficientes |
| `4_ta10` | Classe de Chern c1 |
| `4_ta11` | Classe de Stiefel-Whitney |
| `4_ta12` | Classe de Pontryagin |
| `4_ta13` | Nervo de Cobertura |
| `4_ta14` | Dualidade de Alexander |
| `4_ta15` | Par de Espaços |
| `4_ta16` | Colchete de Whitehead |
| `4_ta17` | Homotopia Estável |
| `4_ta18` | Classe Fundamental |

#### Transporte Ótimo e TDA

| ID | Fórmula/Equação |
|---|---|
| `4_td01` | Complexo de Vietoris-Rips |
| `4_td02` | Complexo de Čech |
| `4_td03` | Homologia Persistente |
| `4_td04` | Diagrama de Persistência |
| `4_td05` | Distância de Bottleneck |
| `4_td06` | Teorema de Estabilidade (TDA) |
| `4_td07` | Paisagem de Persistência |
| `4_td08` | Algoritmo Mapper |
| `4_to01` | Problema de Monge |
| `4_to02` | Problema de Kantorovich (Relaxação) |
| `4_to03` | Distância de Wasserstein-p |
| `4_to04` | Sinkhorn (OT Regularizado) |
| `4_to05` | Mapa de Brenier |
| `4_to06` | Equação de Monge-Ampère |
| `4_to07` | Dualidade de Kantorovich-Rubinstein |
| `4_to08` | Custo Esperado de Transporte |
| `4_to09` | Restrições de Marginais |
| `4_to10` | Distância de Wasserstein-1 |
| `4_to11` | Distância de Wasserstein-2 |
| `4_to12` | Sinkhorn Divergence |
| `4_to13` | Barycenter de Wasserstein |
| `4_to14` | Fluxo de Gradiente em Wasserstein |
| `4_to15` | Custo Regularizado por Entropia |
| `4_wv01` | Transformada Wavelet Contínua (CWT) |
| `4_wv02` | Transformada Wavelet Discreta (DWT) |
| `4_wv03` | Multirresolução (MRA) |
| `4_wv04` | Wavelet de Haar |
| `4_wv05` | Wavelets de Daubechies |
| `4_wv06` | Compressão Wavelet |
| `4_wv07` | Scattering Transform |

</details>

<details>
<summary><b>Volume V — 399 fórmulas</b></summary>

#### Categorias
- Algoritmos de Aproximação (15)
- Análise Harmônica (9)
- Aprendizado Federado (5)
- Biologia e Medicina (2)
- Bioquímica Estrutural (11)
- Blockchain e Consenso (12)
- Ciências da Computação (2)
- Ciências Sociais e Econômicas (5)
- Compiladores e Autômatos (12)
- Computação DNA e Neuromórfica (10)
- Computação Paralela (14)
- Computação Quântica Topológica (10)
- Cristalografia (10)
- Econofísica (11)
- Estatística e Dados (3)
- Física (4)
- Genética Quantitativa (16)
- Geometria Não-Comutativa (12)
- Geometria Riemanniana (10)
- Hopfield e Ecologia (11)
- IA Explicável (10)
- ICA e Misturas (16)
- Imunologia Computacional (16)
- Macroeconomia DSGE (17)
- Magnetismo e Matéria Mole (17)
- Matemática Pura (7)
- Mecânica Celeste (13)
- Microeconomia Avançada (6)
- Novas Fronteiras (6)
- Otimização Convexa (13)
- Privacidade Diferencial (11)
- Processos Gaussianos (23)
- Redes de Computadores (11)
- Sociofísica (6)
- Teoria de Hodge (7)
- Teoria de Lie (21)
- Teoria dos Números Algébricos (15)

#### Algoritmos de Aproximação

| ID | Fórmula/Equação |
|---|---|
| `5_ap01` | Razão de Aproximação |
| `5_ap02` | Vertex Cover (2-aprox.) |
| `5_ap03` | TSP Métrico (Christofides) |
| `5_ap04` | Set Cover (ln n) |
| `5_ap05` | FPTAS (Knapsack) |
| `5_ap06` | Relaxação LP + Arredondamento |
| `5_ap07` | Inaprogramabilidade (PCP) |
| `5_ap08` | Unique Games Conjecture |
| `5_cc01` | Circuito Booleano |
| `5_cc02` | P/poly |
| `5_cc03` | Limiar de Shannon |
| `5_cc04` | AC⁰ e Paridade |
| `5_cc05` | Classe NC |
| `5_cc06` | Fórmula vs Circuito |
| `5_cc07` | Comunicação e Circuitos |

#### Análise Harmônica

| ID | Fórmula/Equação |
|---|---|
| `5_ah01` | Medida de Haar |
| `5_ah02` | Unicidade da Haar |
| `5_ah03` | Função Modular |
| `5_ah04` | Convolução em Grupo |
| `5_ah05` | Fourier em Grupo Abeliano |
| `5_ah06` | Inversão de Fourier |
| `5_ah07` | Parseval |
| `5_ah08` | Dualidade de Pontryagin |
| `5_ah09` | Convolução vira Produto |

#### Aprendizado Federado

| ID | Fórmula/Equação |
|---|---|
| `5_fl01` | FedAvg (Agregação Federada) |
| `5_fl02` | Client Drift (Heterogeneidade) |
| `5_fl03` | FedProx (Regularização Proximal) |
| `5_fl04` | DP-FedAvg (FL com Privacidade) |
| `5_fl05` | Comunicação Eficiente (Quantização) |

#### Biologia e Medicina

| ID | Fórmula/Equação |
|---|---|
| `V5-GQ4` | Equação do Criador (Breeder's Equation) |
| `V5-GW5` | Escore Poligênico (PGS / PRS) |

#### Bioquímica Estrutural

| ID | Fórmula/Equação |
|---|---|
| `5_bq01` | Michaelis-Menten |
| `5_bq02` | Equação de Hill |
| `5_bq03` | Lei de Bragg (Cristalografia) |
| `5_bq04` | Fator de Estrutura |
| `5_bq05` | Ramachandran Plot |
| `5_bq06` | AlphaFold (Predição de Estrutura) |
| `5_bq07` | RMSD (Comparação Estrutural) |
| `5_bq08` | Energia Livre de Ligação |
| `5_bq09` | Potencial de Lennard-Jones |
| `5_bq10` | Campo de Força (MD) |
| `5_bq11` | Equação de Henderson-Hasselbalch |

#### Blockchain e Consenso

| ID | Fórmula/Equação |
|---|---|
| `5_bc01` | Hash Criptográfico |
| `5_bc02` | Merkle Tree |
| `5_bc03` | Proof of Work (PoW) |
| `5_bc04` | Proof of Stake (PoS) |
| `5_bc05` | Generais Bizantinos (BFT) |
| `5_bc06` | Protocolo Nakamoto |
| `5_bc07` | Smart Contract (Gas) |
| `5_bc08` | Token ERC-20 |
| `5_bc09` | Algoritmo de Seleção de UTXO |
| `5_bc10` | Consenso Avalanche |
| `5_bc11` | Merkle Proof (Prova de Inclusão) |
| `5_bc12` | ZK-SNARK (Zero-Knowledge Succinct) |

#### Ciências da Computação

| ID | Fórmula/Equação |
|---|---|
| `V5-AP2` | Aproximação de Set Cover |
| `V5-PA2` | Lei de Amdahl |

#### Ciências Sociais e Econômicas

| ID | Fórmula/Equação |
|---|---|
| `V5-EF1` | Distribuição de Pareto (Riqueza) |
| `V5-NK1` | Curva IS Dinâmica (Novo-Keynesiana) |
| `V5-NK2` | Curva de Phillips Novo-Keynesiana |
| `V5-NK4` | Regra de Taylor |
| `V5-SF3` | Modelo de Difusão de Bass |

#### Compiladores e Autômatos

| ID | Fórmula/Equação |
|---|---|
| `5_ch01` | Hierarquia de Chomsky |
| `5_ch02` | AFD (Autômato Finito Determinístico) |
| `5_ch03` | Lema do Bombeamento (Regulares) |
| `5_ch04` | Autômato de Pilha (PDA) |
| `5_ch05` | Gramática Livre de Contexto (CFG) |
| `5_ch06` | CYK (Parsing) |
| `5_ch07` | Análise Léxica (Scanner) |
| `5_ch08` | Parser LL(1) |
| `5_ch09` | Parser LR(1) |
| `5_ch10` | SSA (Static Single Assignment) |
| `5_ch11` | Alocação de Registradores (Graph Coloring) |
| `5_ch12` | Fases do Compilador |

#### Computação DNA e Neuromórfica

| ID | Fórmula/Equação |
|---|---|
| `5_dn01` | DNA Computing (Adleman) |
| `5_dn02` | DNA Storage |
| `5_dn03` | Strand Displacement |
| `5_dn04` | DNA Origami |
| `5_dn05` | CRISPR como Computação |
| `5_dn06` | Neurônio LIF (Leaky Integrate-and-Fire) |
| `5_dn07` | STDP (Spike-Timing Dependent Plasticity) |
| `5_dn08` | SNN (Spiking Neural Network) |
| `5_dn09` | Memristor |
| `5_dn10` | Eficiência Energética Neuromórfica |

#### Computação Paralela

| ID | Fórmula/Equação |
|---|---|
| `5_pa01` | Lei de Amdahl |
| `5_pa02` | Lei de Gustafson |
| `5_pa03` | Eficiência Paralela |
| `5_pa04` | Work-Span (Brent) |
| `5_pa05` | BSP (Bulk Synchronous Parallel) |
| `5_pa06` | PRAM |
| `5_pa07` | MapReduce |
| `5_pa08` | Complexidade de Comunicação |
| `5_pa09` | Consenso (FLP) |
| `5_pa10` | Paxos |
| `5_pa11` | Raft |
| `5_pa12` | Relógios de Lamport |
| `5_pa13` | Relógios Vetoriais |
| `5_pa14` | Teorema CAP |

#### Computação Quântica Topológica

| ID | Fórmula/Equação |
|---|---|
| `5_qt01` | Anyon |
| `5_qt02` | Grupo de Braid |
| `5_qt03` | Fibonacci Anyons |
| `5_qt04` | Código Tórico (Kitaev) |
| `5_qt05` | Código de Superfície |
| `5_qt06` | Proteção Topológica |
| `5_qt07` | Invariante de Jones (TQFT) |
| `5_qt08` | Modelo de Levin-Wen |
| `5_qt09` | Twist de Anyon (Topological Spin) |
| `5_qt10` | Capacidade Quântica Topológica |

#### Cristalografia

| ID | Fórmula/Equação |
|---|---|
| `5_cr01` | Redes de Bravais |
| `5_cr02` | Grupos Espaciais |
| `5_cr03` | Rede Recíproca |
| `5_cr04` | Vetor de Rede Recíproca (Miller) |
| `5_cr05` | Lei de Bragg |
| `5_cr06` | Condição de Laue |
| `5_cr07` | Fator de Estrutura |
| `5_cr08` | Extinções Sistemáticas |
| `5_cr09` | Intensidade de Difração |
| `5_cr10` | Fator de Debye-Waller |

#### Econofísica

| ID | Fórmula/Equação |
|---|---|
| `5_ef01` | Modelo de Ising (Mercados) |
| `5_ef02` | Lei de Potência (Retornos) |
| `5_ef03` | Volatility Clustering |
| `5_ef04` | Modelo de Minority Game |
| `5_ef05` | Random Matrix Theory (Finanças) |
| `5_ef06` | Modelo de Percolação (Default) |
| `5_ef07` | Hurst Exponent |
| `5_ef08` | Multifractal (MMAR) |
| `5_ef09` | Zipf (Tamanho de Firmas) |
| `5_ef10` | Pareto (Renda) |
| `5_ef11` | Modelo de Boltzmann-Gibbs (Economia) |

#### Estatística e Dados

| ID | Fórmula/Equação |
|---|---|
| `V5-GP3` | Predição Posterior de Processo Gaussiano |
| `V5-GP6` | Kernel RBF (Gaussiano) |
| `V5-OC13` | Aceleração de Nesterov (Momentum) |

#### Física

| ID | Fórmula/Equação |
|---|---|
| `V5-MC10` | Velocidade de Escape |
| `V5-MC5` | Teorema KAM (Kolmogorov-Arnold-Moser) |
| `V5-MC9` | Equação da Órbita de Kepler |
| `V5-MG3` | Suscetibilidade de Curie-Weiss |

#### Genética Quantitativa

| ID | Fórmula/Equação |
|---|---|
| `5_gq01` | Equação do Criador |
| `5_gq02` | Herdabilidade (h²) |
| `5_gq03` | Equação de Lande (Multivariada) |
| `5_gq04` | Equilíbrio Hardy-Weinberg |
| `5_gq05` | Deriva Genética (Wright-Fisher) |
| `5_gq06` | Fixação Neutra (Kimura) |
| `5_gq07` | QTL Mapping (LOD score) |
| `5_gq08` | GWAS (Genômica) |
| `5_gq09` | BLUP (Valor Genético) |
| `5_gq10` | Seleção Genômica (GS) |
| `5_gq11` | Coalescente (Kingman) |
| `5_gq12` | Linkage Disequilibrium (r²) |
| `5_gq13` | Polygenic Score (PGS) |
| `5_gq14` | LD Score Regression (Herdabilidade SNP) |
| `5_gq15` | Epistasis (Interação Genética) |
| `5_gq16` | Pedigree Analysis (IBD) |

#### Geometria Não-Comutativa

| ID | Fórmula/Equação |
|---|---|
| `5_ca01` | Identidade C* |
| `5_ca02` | Exemplos de C*-Álgebras |
| `5_ca03` | Espectro e Raio Espectral |
| `5_ca04` | Teorema de Gelfand |
| `5_ca05` | Representação GNS |
| `5_ca06` | Álgebra de von Neumann |
| `5_ca07` | Fatores Tipo I/II/III |
| `5_nc01` | Produto de Moyal |
| `5_nc02` | Comutação de Coordenadas |
| `5_nc03` | Plano de Moyal |
| `5_nc04` | Tripla Espectral |
| `5_nc05` | Distância de Connes |

#### Geometria Riemanniana

| ID | Fórmula/Equação |
|---|---|
| `5_gr01` | Curvatura Seccional |
| `5_gr02` | Curvatura de Ricci |
| `5_gr03` | Curvatura Escalar |
| `5_gr04` | Equação de Jacobi |
| `5_gr05` | Bonnet-Myers (Cota de Diâmetro) |
| `5_gr06` | Comparação de Bishop (Volume) |
| `5_gr07` | Hadamard-Cartan |
| `5_gr08` | Tensor de Weyl (Modelo) |
| `5_gr09` | Variedade Einstein |
| `5_gr10` | Fluxo de Ricci |

#### Hopfield e Ecologia

| ID | Fórmula/Equação |
|---|---|
| `5_ec01` | Equação Logística |
| `5_ec02` | Lotka-Volterra (Predador-Presa) |
| `5_ec03` | Competição (Lotka-Volterra) |
| `5_ec04` | Metapopulação (Levins) |
| `5_ec05` | Diversidade de Shannon (Ecologia) |
| `5_ec06` | Espécie-Área (SAR) |
| `5_hp01` | Rede de Hopfield |
| `5_hp02` | Energia de Hopfield |
| `5_hp03` | Modern Hopfield (Attention) |
| `5_hp04` | Máquina de Boltzmann |
| `5_hp05` | Hopfield Moderno (Capacidade Exponencial) |

#### IA Explicável

| ID | Fórmula/Equação |
|---|---|
| `5_xa01` | LIME |
| `5_xa02` | SHAP (Shapley Additive) |
| `5_xa03` | Contrafactuais |
| `5_xa04` | Grad-CAM |
| `5_xa05` | Attention Rollout |
| `5_xa06` | Integrated Gradients |
| `5_xa07` | Faithfulness (Métrica) |
| `5_xa08` | Concept Bottleneck Model |
| `5_xa09` | Integrated Gradients |
| `5_xa10` | Partial Dependence Plot (PDP) |

#### ICA e Misturas

| ID | Fórmula/Equação |
|---|---|
| `5_gm01` | Modelo de Mistura Gaussiana (GMM) |
| `5_gm02` | E-Step (EM) |
| `5_gm03` | M-Step (EM) |
| `5_gm04` | Log-Verossimilhança (GMM) |
| `5_gm05` | Seleção de K (BIC/AIC) |
| `5_ic01` | Modelo ICA |
| `5_ic02` | Critério de Não-Gaussianidade |
| `5_ic03` | Aproximação da Neguentropia |
| `5_ic04` | FastICA |
| `5_ic05` | Infomax (Bell-Sejnowski) |
| `5_ic06` | Ambiguidades ICA |
| `5_kd01` | Estimador de Parzen-Rosenblatt (KDE) |
| `5_kd02` | Kernel Gaussiano |
| `5_kd03` | Kernel de Epanechnikov |
| `5_kd04` | Bandwidth Ótimo (Silverman) |
| `5_kd05` | MISE |

#### Imunologia Computacional

| ID | Fórmula/Equação |
|---|---|
| `5_im01` | Modelo SIR |
| `5_im02` | Número Reprodutivo Básico (R₀) |
| `5_im03` | Imunidade de Rebanho |
| `5_im04` | Dinâmica Vírus-Imune |
| `5_im05` | Seleção Clonal (Burnet) |
| `5_im06` | Rede Imune (Jerne) |
| `5_im07` | Afinidade de Ligação (Kd) |
| `5_im08` | NetMHC (Predição de Epítopos) |
| `5_im09` | Diversidade de Receptores (V(D)J) |
| `5_im10` | Clonotype Analysis (Repertório) |
| `5_im11` | Escape Viral (Mutação Imune) |
| `5_im12` | Limiar de Imunidade de Rebanho |
| `5_im13` | Competição de Clone (Seleção Clonal) |
| `5_im14` | Formação de Repertório TCR/BCR |
| `5_im15` | Polarização Th1/Th2 (Citocinas) |
| `5_im16` | Células Treg (Supressão) |

#### Macroeconomia DSGE

| ID | Fórmula/Equação |
|---|---|
| `5_ds01` | Equação de Euler do Consumo |
| `5_ds02` | Curva de Phillips Nova-Keynesiana |
| `5_ds03` | Regra de Taylor |
| `5_ds04` | Modelo RBC (Real Business Cycle) |
| `5_ds05` | Preço de Calvo |
| `5_ds06` | Equação IS (NK) |
| `5_ds07` | Equação de Bellman |
| `5_ds08` | Log-linearização |
| `5_ds09` | Restrição Orçamentária do Governo |
| `5_ds10` | Equação de Fisher |
| `5_ds11` | Teoria Quantitativa da Moeda |
| `5_ds12` | Modelo de Solow (Crescimento) |
| `5_ds13` | Acelerador Financeiro (BGG) |
| `5_ds14` | Mundell-Fleming DSGE |
| `5_ds15` | Curva de Phillips Híbrida |
| `5_ds16` | Loss Function (Política Monetária) |
| `5_ds17` | DSGE-VAR (Estimação Bayesiana) |

#### Magnetismo e Matéria Mole

| ID | Fórmula/Equação |
|---|---|
| `5_mg01` | Ferromagnetismo de Weiss |
| `5_mg02` | Campo Médio Magnético |
| `5_mg03` | Susceptibilidade de Curie-Weiss |
| `5_mg04` | Modelo de Heisenberg |
| `5_mg05` | Relação de Dispersão de Magnons |
| `5_mg06` | Expoente Magnético β |
| `5_mg07` | Critério de Stoner |
| `5_mg08` | Efeito Josephson DC |
| `5_mg09` | Efeito Josephson AC |
| `5_mg10` | SQUID |
| `5_pm01` | Raio de Giro (Cadeia Gaussiana) |
| `5_pm02` | Expoente de Flory |
| `5_pm03` | Modelo de Rouse |
| `5_pm04` | Reptação (de Gennes) |
| `5_pm05` | Elástica de Frank |
| `5_pm06` | Fases Líquido-Cristalinas |
| `5_pm07` | Transição Isótropo-Nemático (Onsager) |

#### Matemática Pura

| ID | Fórmula/Equação |
|---|---|
| `V5-LI1` | Identidade de Jacobi |
| `V5-LI12` | Fórmula de Weyl para Dimensão |
| `V5-LI2` | Forma de Killing |
| `V5-NA10` | Lei da Reciprocidade Quadrática |
| `V5-NA11` | Símbolo de Legendre |
| `V5-TR3` | Ortogonalidade de Caracteres |
| `V5-TR4` | Relação de Completude |

#### Mecânica Celeste

| ID | Fórmula/Equação |
|---|---|
| `5_mc01` | Hamiltoniano Perturbado |
| `5_mc02` | Perturbação de 1ª Ordem |
| `5_mc03` | Problema de Denominadores Pequenos |
| `5_mc04` | Condição Diofantina |
| `5_mc05` | Teorema KAM |
| `5_mc06` | Problema dos 3 Corpos |
| `5_mc07` | Série de Sundman |
| `5_mc08` | Ressonâncias de Kirkwood |
| `5_mc09` | Equação de Órbita |
| `5_mc10` | Velocidade de Escape |
| `5_mc11` | Transferência de Hohmann |
| `5_mc12` | Equação de Gauss (Perturbações) |
| `5_mc13` | Pontos de Lagrange |

#### Microeconomia Avançada

| ID | Fórmula/Equação |
|---|---|
| `5_me01` | Equilíbrio de Nash |
| `5_me02` | Backward Induction (Jogos Sequenciais) |
| `5_me03` | Revelation Principle |
| `5_me04` | Leilão de Vickrey (2º Preço) |
| `5_me05` | Screening vs Signaling |
| `5_me06` | Hold-Up Problem (Investimentos Específicos) |

#### Novas Fronteiras

| ID | Fórmula/Equação |
|---|---|
| `V5-BC1` | Proof-of-Work (PoW) |
| `V5-DP1` | Privacidade Diferencial (ε-DP) |
| `V5-DP3` | Mecanismo de Laplace |
| `V5-FL1` | Federated Averaging (FedAvg) |
| `V5-XA1` | SHAP Values |
| `V5-XA8` | Grad-CAM |

#### Otimização Convexa

| ID | Fórmula/Equação |
|---|---|
| `5_oc01` | Função Convexa |
| `5_oc02` | Conjugada de Fenchel |
| `5_oc03` | Biconjugada f** = f |
| `5_oc04` | Subgradiente |
| `5_oc05` | Condições KKT |
| `5_oc06` | Dualidade Forte (Slater) |
| `5_oc07` | Gradiente Projetado |
| `5_oc08` | Método do Subgradiente |
| `5_oc09` | ADMM |
| `5_oc10` | Ponto Interior (Barreira) |
| `5_oc11` | Programação Semidefinida (SDP) |
| `5_oc12` | Programação Cônica (SOCP) |
| `5_oc13` | Aceleração de Nesterov |

#### Privacidade Diferencial

| ID | Fórmula/Equação |
|---|---|
| `5_dp01` | Definição ε-DP |
| `5_dp02` | Mecanismo de Laplace |
| `5_dp03` | Mecanismo Gaussiano |
| `5_dp04` | Composição Sequencial |
| `5_dp05` | Composição Avançada |
| `5_dp06` | Mecanismo Exponencial |
| `5_dp07` | DP-SGD |
| `5_dp08` | Rényi DP (RDP) |
| `5_dp09` | Local DP (LDP) |
| `5_dp10` | Randomized Response |
| `5_dp11` | Privacidade e Utilidade (Tradeoff) |

#### Processos Gaussianos

| ID | Fórmula/Equação |
|---|---|
| `5_bp01` | Bootstrap |
| `5_bp02` | Variância Bootstrap |
| `5_bp03` | IC Bootstrap Percentil |
| `5_bp04` | IC Bootstrap BCa |
| `5_bp05` | Jackknife |
| `5_bp06` | Teste de Wilcoxon (Signed-Rank) |
| `5_bp07` | Teste de Mann-Whitney |
| `5_bp08` | Teste de Kolmogorov-Smirnov |
| `5_ga01` | Modelo Aditivo Generalizado (GAM) |
| `5_ga02` | Spline Cúbica Natural |
| `5_ga03` | P-Spline |
| `5_ga04` | LOESS |
| `5_ga05` | Graus de Liberdade Efetivos |
| `5_ga06` | GCV (Validação Cruzada Generalizada) |
| `5_gp01` | Definição de GP |
| `5_gp02` | Modelo de Observações |
| `5_gp03` | Distribuição Posterior GP |
| `5_gp04` | Média Posterior GP |
| `5_gp05` | Covariância Posterior GP |
| `5_gp06` | Kernel RBF |
| `5_gp07` | Kernel Matérn 5/2 |
| `5_gp08` | Log-Verossimilhança Marginal |
| `5_gp09` | Expected Improvement (BO) |

#### Redes de Computadores

| ID | Fórmula/Equação |
|---|---|
| `5_rc01` | Modelo OSI (7 Camadas) |
| `5_rc02` | TCP/IP (4 Camadas) |
| `5_rc03` | Lei de Shannon (Canal) |
| `5_rc04` | Throughput e Latência |
| `5_rc05` | CSMA/CD |
| `5_rc06` | Algoritmo de Dijkstra (OSPF) |
| `5_rc07` | Controle de Congestionamento TCP |
| `5_rc08` | Slow Start |
| `5_rc09` | Throughput TCP (Mathis) |
| `5_rc10` | TCP Fast Retransmit |
| `5_rc11` | BBR |

#### Sociofísica

| ID | Fórmula/Equação |
|---|---|
| `5_sf01` | Voter Model |
| `5_sf02` | Modelo de Schelling (Segregação) |
| `5_sf03` | Modelo de Barabási-Albert |
| `5_sf04` | Modelo de Watts-Strogatz (Pequeno Mundo) |
| `5_sf05` | Modelo SIS/SIR (Epidemiologia em Redes) |
| `5_sf06` | Deffuant Model (Bounded Confidence) |

#### Teoria de Hodge

| ID | Fórmula/Equação |
|---|---|
| `5_th01` | Operador de Hodge * |
| `5_th02` | Coderivada δ |
| `5_th03` | Laplaciano de Hodge |
| `5_th04` | Decomposição de Hodge |
| `5_th05` | Isomorfismo Hodge-de Rham |
| `5_th06` | Identidades de Kähler |
| `5_th07` | Lema ∂∂̄ |

#### Teoria de Lie

| ID | Fórmula/Equação |
|---|---|
| `5_li01` | Identidade de Jacobi |
| `5_li02` | Forma de Killing |
| `5_li03` | Critério de Cartan |
| `5_li04` | Subálgebra de Cartan |
| `5_li05` | Decomposição de Raízes |
| `5_li06` | Sistema de Raízes Φ |
| `5_li07` | Raízes Simples Δ |
| `5_li08` | Matriz de Cartan A |
| `5_li09` | Diagrama de Dynkin |
| `5_li10` | sl(2,ℂ) Protótipo |
| `5_li11` | Grupo de Weyl W |
| `5_li12` | Fórmula de Dimensão de Weyl |
| `5_tr01` | Representação de Grupo ρ |
| `5_tr02` | Caractere χ |
| `5_tr03` | Ortogonalidade de Caracteres |
| `5_tr04` | Completude de Caracteres |
| `5_tr05` | Lema de Schur |
| `5_tr06` | Decomposição em Irredutíveis |
| `5_tr07` | Reciprocidade de Frobenius |
| `5_tr08` | Teorema de Peter-Weyl |
| `5_tr09` | Fourier Não-Comutativo |

#### Teoria dos Números Algébricos

| ID | Fórmula/Equação |
|---|---|
| `5_na01` | Extensão de Corpo de Números K/ℚ |
| `5_na02` | Discriminante disc(K) |
| `5_na03` | Fatoração de Ideais |
| `5_na04` | Fórmula efg=[K:ℚ] |
| `5_na05` | Grupo de Classes Cl(K) |
| `5_na06` | Cota de Minkowski |
| `5_na07` | Teorema das Unidades de Dirichlet |
| `5_na08` | Norma N_{K/ℚ}(α) |
| `5_na09` | Traço tr_{K/ℚ}(α) |
| `5_na10` | Reciprocidade Quadrática (Legendre) |
| `5_na11` | Símbolo de Legendre (a/p) |
| `5_na12` | Símbolo de Jacobi (a/n) |
| `5_na13` | Reciprocidade de Artin (Teoria de Corpo de Classes) |
| `5_na14` | Mapa de Artin (Frobenius) |
| `5_na15` | Cohomologia de Galois H¹ |

</details>

<details>
<summary><b>Volume VI — 442 fórmulas</b></summary>

#### Categorias
- Active Inference e Cognição (17)
- Astrofísica e Gravitação Numérica (19)
- Biologia Sintética e scRNA-seq (18)
- Computação Quântica Avançada v2 (12)
- Design de Mecanismos (14)
- Flow Matching e Meta-Learning (19)
- Fotônica e MEMS (18)
- Geodesia e Ciências da Terra (18)
- Geometria Tropical e Nós (23)
- Information Bottleneck e Kernels (14)
- Lógica Modal e Computabilidade (20)
- Normalizing Flows e Neural ODEs (20)
- Plasma e Tokamak (10)
- Radiobiologia e fMRI (15)
- Reologia e Biofísica de Membranas (20)
- Sistemas Integráveis e TQFTs (17)
- Sobolev e Distribuições (21)
- Sísmica e Eletroquímica (17)
- Teoria Conforme e SLE (17)
- Transporte Quântico e Topologia (23)
- Tráfego e Transferência Radiativa (17)
- Verificação Formal e CPS (16)
- Visão Computacional e SLAM (14)
- Óptica Não-Linear e Atômica (21)
- ∞-Categorias e Teoria de Tipos (22)

#### Active Inference e Cognição

| ID | Fórmula/Equação |
|---|---|
| `6_ai01` | Free Energy (Variational) |
| `6_ai02` | Expected Free Energy (EFE) |
| `6_ai03` | Predictive Coding |
| `6_ai04` | Modelo Generativo POMDP |
| `6_ai05` | Precision Weighting |
| `6_ai06` | Allostasis e Interoceptive Inference |
| `6_dd01` | Drift-Diffusion Model (DDM) |
| `6_dd02` | Rescorla-Wagner (Aprendizagem) |
| `6_dd03` | Prospect Theory (Kahneman-Tversky) |
| `6_dd04` | Softmax (Choice Rule) |
| `6_dd05` | Temporal Discounting Hiperbólico |
| `6_dd06` | Signal Detection Theory (d') |
| `6_lc01` | Surprisal (Teoria da Informação Linguística) |
| `6_lc02` | Perplexidade de Modelo de Linguagem |
| `6_lc03` | Zipf's Law |
| `6_lc04` | Pointwise Mutual Information (PMI) |
| `6_lc05` | BPE (Byte Pair Encoding) |

#### Astrofísica e Gravitação Numérica

| ID | Fórmula/Equação |
|---|---|
| `6_cm01` | Perturbação Secular |
| `6_cm02` | Mecanismo de Kozai-Lidov |
| `6_cm03` | Ressonância de Movimento Médio |
| `6_cm04` | Problema de N-Corpos (Integradores Simpléticos) |
| `6_cm05` | Migração Planetária Tipo I |
| `6_cm06` | Esfera de Hill |
| `6_ne01` | Equação TOV |
| `6_ne02` | Limite de Massa de Chandrasekhar |
| `6_ne03` | Equação de Estado Nuclear |
| `6_ne04` | Frequência de Pulsar |
| `6_ne05` | Glitch de Pulsar |
| `6_ne06` | Ondas Gravitacionais de Merger |
| `6_ne07` | Efeito Shapiro (Atraso Gravitacional) |
| `6_nr01` | Formalismo ADM 3+1 |
| `6_nr02` | Equação de Evolução BSSN |
| `6_nr03` | Gauge 1+log e Gamma-Freezing |
| `6_nr04` | Horizon Finder (Superfície Aparente) |
| `6_nr05` | Extração de Ondas Gravitacionais (ψ₄) |
| `6_nr06` | Puncture (Buraco Negro Móvel) |

#### Biologia Sintética e scRNA-seq

| ID | Fórmula/Equação |
|---|---|
| `6_bs01` | Repressilador (Toggle Switch) |
| `6_bs02` | Toggle Switch Genético |
| `6_bs03` | Função de Hill (Gene Regulation) |
| `6_bs04` | CRISPR Kinetics |
| `6_bs05` | Gibson Assembly (Recombinação) |
| `6_bs06` | Stochastic Gene Expression (Gillespie) |
| `6_dk01` | Scoring Function (AutoDock) |
| `6_dk02` | RMSD de Pose (Docking) |
| `6_dk03` | Lennard-Jones (Interação VdW) |
| `6_dk04` | Constante de Inibição (Ki) |
| `6_sc01` | Normalização por Profundidade (CPM) |
| `6_sc02` | SCTransform (Pearson Residuals) |
| `6_sc03` | UMAP (Dimensionality Reduction) |
| `6_sc04` | Leiden Clustering |
| `6_sc05` | RNA Velocity |
| `6_sc06` | Diffusion Pseudotime |
| `6_sc07` | Cell-Cell Communication (CellChat) |
| `6_sc08` | Doublet Detection (Scrublet) |

#### Computação Quântica Avançada v2

| ID | Fórmula/Equação |
|---|---|
| `6_qcx01` | BQP (Bounded-Error Quantum Poly) |
| `6_qcx02` | BQP vs PH (Oracular) |
| `6_qcx03` | Query Complexity Quântica |
| `6_qcx04` | Adversary Method (Lower Bound) |
| `6_qcx05` | Random Circuit Sampling (Sycamore) |
| `6_qcx06` | Boson Sampling |
| `6_qml01` | Quantum Kernel |
| `6_qml02` | PQC (Parameterized Quantum Circuit) |
| `6_qml03` | Parameter Shift Rule |
| `6_qml04` | Barren Plateaus |
| `6_qml05` | Síntese de Circuitos (ZX-calculus) |
| `6_qml06` | Limite de Landauer |

#### Design de Mecanismos

| ID | Fórmula/Equação |
|---|---|
| `6_gs01` | Leilão de Vickrey (Segundo Preço) |
| `6_gs02` | Mecanismo VCG |
| `6_gs03` | Revenue Equivalence Theorem |
| `6_gs04` | Leilão de Primeiro Preço (BNE) |
| `6_gs05` | Leilão Ótimo de Myerson |
| `6_my01` | Lemma de Myerson (Payoff Equivalence) |
| `6_my02` | Princípio de Revelação |
| `6_my03` | AGV Mechanism (Expected Externality) |
| `6_my04` | Teorema de Myerson-Satterthwaite |
| `6_sd01` | Algoritmo Gale-Shapley |
| `6_sd02` | Teorema da Impossibilidade de Arrow |
| `6_sd03` | Teorema de Gibbard-Satterthwaite |
| `6_sd04` | Valor de Shapley |
| `6_sd05` | Índice de Poder de Banzhaf |

#### Flow Matching e Meta-Learning

| ID | Fórmula/Equação |
|---|---|
| `6_fm01` | Conditional Flow Matching |
| `6_fm02` | Optimal Transport CFM |
| `6_fm03` | Rectified Flow |
| `6_fm04` | Stochastic Interpolant |
| `6_fm05` | Consistency Model |
| `6_fm06` | Guided Flow / Classifier-Free Guidance |
| `6_ka01` | Kolmogorov-Arnold Network (KAN) |
| `6_ka02` | Teorema de Kolmogorov-Arnold |
| `6_ml01` | MAML (Meta-Learning) |
| `6_ml02` | Prototypical Networks |
| `6_ml03` | Reptile |
| `6_ml04` | In-Context Learning (ICL) |
| `6_ml05` | RLHF (PPO para LLMs) |
| `6_ml06` | DPO (Direct Preference Optimization) |
| `6_ml07` | Constitutional AI (RLAIF) |
| `6_rc01` | Echo State Network (ESN) |
| `6_rc02` | Echo State Property |
| `6_rc03` | Liquid State Machine |
| `6_rc04` | Next Generation Reservoir Computing |

#### Fotônica e MEMS

| ID | Fórmula/Equação |
|---|---|
| `6_fo01` | Guia de Onda (Modo Fundamental) |
| `6_fo02` | Acoplador Direcional |
| `6_fo03` | Ressonador em Anel |
| `6_fo04` | Modulador Mach-Zehnder |
| `6_fo05` | Cristal Fotônico (Banda Gap) |
| `6_fo06` | Fibra de Cristal Fotônico (PCF) |
| `6_fo07` | Plasmon de Superfície (SPP) |
| `6_me01` | Frequência de Ressonância MEMS |
| `6_me02` | Atuação Eletrostática (Pull-in) |
| `6_me03` | Thermoelastic Damping (Q-TED) |
| `6_me04` | Acelerômetro Capacitivo MEMS |
| `6_me05` | Giroscópio MEMS (Coriolis) |
| `6_me06` | NEMS Mass Sensor |
| `6_tb01` | Lei de Archard (Desgaste) |
| `6_tb02` | Contato Hertziano |
| `6_tb03` | Equação de Reynolds (Lubrificação) |
| `6_tb04` | Número de Sommerfeld |
| `6_tb05` | Modelo JKR (Adesão) |

#### Geodesia e Ciências da Terra

| ID | Fórmula/Equação |
|---|---|
| `6_ac01` | Lei de Henry (Solubilidade de Gás) |
| `6_ac02` | Chapman Cycle (Ozônio) |
| `6_ac03` | Forçamento Radiativo (CO₂) |
| `6_ac04` | Potencial de Aquecimento Global (GWP) |
| `6_ac05` | Deposição Ácida (pH de Chuva) |
| `6_ac06` | Tempo de Residência Atmosférico |
| `6_gd01` | Geoide e Anomalia de Gravidade |
| `6_gd02` | Harmônicos Esféricos (Potencial) |
| `6_gd03` | Fórmula de Vincenty (Distância Geodésica) |
| `6_gd04` | Projeção UTM |
| `6_gd05` | GNSS Pseudorange |
| `6_gd06` | Isostasia de Airy |
| `6_mn01` | Lei de Bragg (Difração de Raios-X) |
| `6_mn02` | Mohs → Vickers (Dureza) |
| `6_mn03` | Equação de Estado da Água do Mar (TEOS-10) |
| `6_ow01` | Ondas de Gravidade de Superfície |
| `6_ow02` | Circulação Termohalina (Sverdrup) |
| `6_ow03` | Espiral de Ekman |

#### Geometria Tropical e Nós

| ID | Fórmula/Equação |
|---|---|
| `6_ca01` | Matróide |
| `6_ca02` | Polinômio Cromático |
| `6_ca03` | Polinômio de Tutte |
| `6_ca04` | Funções de Schur |
| `6_ca05` | Regra de Littlewood-Richardson |
| `6_ca06` | Álgebra de Hopf Combinatória |
| `6_ca07` | Fórmula de Hook-Length |
| `6_ca08` | Polinômio de Kazhdan-Lusztig |
| `6_ca09` | Conjectura de Rota (Log-Concavidade) |
| `6_kn01` | Polinômio de Alexander |
| `6_kn02` | Polinômio de Jones |
| `6_kn03` | Invariante HOMFLY-PT |
| `6_kn04` | Número de Cruzamento e Writhe |
| `6_kn05` | Bracket de Kauffman |
| `6_kn06` | Grupo do Nó |
| `6_kn07` | Homologia de Khovanov |
| `6_tr01` | Semianél Tropical |
| `6_tr02` | Curva Tropical |
| `6_tr03` | Teorema de Correspondência de Mikhalkin |
| `6_tr04` | Politopo de Newton Tropical |
| `6_tr05` | Grassmanniana Tropical |
| `6_tr06` | Fórmula de Gênero Tropical |
| `6_tr07` | Variedade Tropical de Bergman |

#### Information Bottleneck e Kernels

| ID | Fórmula/Equação |
|---|---|
| `6_ib01` | Information Bottleneck |
| `6_ib02` | Deep Information Bottleneck |
| `6_ib03` | Curva de Informação |
| `6_ib04` | IB como Rate-Distortion |
| `6_km01` | Neural Tangent Kernel (NTK) |
| `6_km02` | Kernel de Processo Gaussiano Neural |
| `6_km03` | Random Fourier Features |
| `6_km04` | Kernel Mean Embedding |
| `6_km05` | RKHS e Teorema do Representante |
| `6_km06` | Sparse GP (Inducing Points) |
| `6_pb01` | Bound PAC-Bayes (McAllester) |
| `6_pb02` | PAC-Bayes-kl (Catoni/Maurer) |
| `6_pb03` | PAC-Bayes com Ruído Gaussiano |
| `6_pb04` | Generalização via Flatness (PAC-Bayes) |

#### Lógica Modal e Computabilidade

| ID | Fórmula/Equação |
|---|---|
| `6_lm01` | Axioma K (Distribuição) |
| `6_lm02` | Axioma T (Reflexividade) |
| `6_lm03` | Axioma S4 (Transitividade) |
| `6_lm04` | Axioma S5 (Equivalência) |
| `6_lm05` | Semântica de Kripke |
| `6_lm06` | Lógica Temporal LTL |
| `6_lm07` | Lógica Epistêmica |
| `6_tu01` | Graus de Turing |
| `6_tu02` | Salto de Turing |
| `6_tu03` | Hierarquia Aritmética |
| `6_tu04` | Teorema de Post |
| `6_tu05` | Teorema de Rice |
| `6_tu06` | Complexidade de Kolmogorov |
| `6_zf01` | Axiomas ZFC |
| `6_zf02` | Hipótese do Contínuo |
| `6_zf03` | Forcing de Cohen |
| `6_zf04` | Grandes Cardinais (Inacessível) |
| `6_zf05` | Axioma de Determinação (AD) |
| `6_zf06` | Universo Construtível L |
| `6_zf07` | Ordinais e Indução Transfinita |

#### Normalizing Flows e Neural ODEs

| ID | Fórmula/Equação |
|---|---|
| `6_eb01` | Energy-Based Model (EBM) |
| `6_eb02` | Score Matching |
| `6_eb03` | Langevin Dynamics (Amostragem) |
| `6_eb04` | Contrastive Divergence |
| `6_nf01` | Change of Variables (Flow) |
| `6_nf02` | RealNVP |
| `6_nf03` | GLOW (1×1 Convolution) |
| `6_nf04` | Continuous Normalizing Flow (CNF) |
| `6_nf05` | Estimador de Hutchinson (Traço) |
| `6_nf06` | Neural Spline Flow |
| `6_nf07` | Variational Dequantization |
| `6_no01` | Neural ODE |
| `6_no02` | Método Adjunto (Neural ODE) |
| `6_no03` | Augmented Neural ODE |
| `6_no04` | Latent ODE |
| `6_no05` | Neural SDE |
| `6_no06` | Neural CDE (Controlled DE) |
| `6_ss01` | State Space Model (S4) |
| `6_ss02` | Mamba (Selective SSM) |
| `6_ss03` | Discretização ZOH do SSM |

#### Plasma e Tokamak

| ID | Fórmula/Equação |
|---|---|
| `6_tk01` | Equação de Grad-Shafranov |
| `6_tk02` | Operador Δ* (Grad-Shafranov) |
| `6_tk03` | Safety Factor q |
| `6_tk04` | Fator de Amplificação Q |
| `6_tk05` | Critério de Lawson |
| `6_tk06` | Modo de Tearing |
| `6_tk07` | Parâmetro Δ' (Tearing) |
| `6_tk08` | NTM (Neoclassical Tearing Mode) |
| `6_tk09` | ELMs (Edge Localized Modes) |
| `6_tk10` | Disruption (Tokamak) |

#### Radiobiologia e fMRI

| ID | Fórmula/Equação |
|---|---|
| `6_cb01` | Oscilador Circadiano (Goodwin) |
| `6_cb02` | Phase Response Curve (PRC) |
| `6_cb03` | Zeitgeber Strength K |
| `6_cb04` | Modelo de 2 Processos do Sono |
| `6_fi01` | Sinal BOLD (fMRI) |
| `6_fi02` | Hemodynamic Response Function (HRF) |
| `6_fi03` | GLM do fMRI |
| `6_fi04` | DCM (Dynamic Causal Modeling) |
| `6_fi05` | Equação de Bloch (MRI Básico) |
| `6_fi06` | DTI (Diffusion Tensor Imaging) |
| `6_rb01` | Modelo Linear-Quadrático (LQ) |
| `6_rb02` | BED (Biological Effective Dose) |
| `6_rb03` | TCP (Tumor Control Probability) |
| `6_rb04` | NTCP (Normal Tissue Complication) |
| `6_rb05` | Fórmula dos 4 Rs da Radiobiologia |

#### Reologia e Biofísica de Membranas

| ID | Fórmula/Equação |
|---|---|
| `6_bm01` | Energia de Curvatura de Helfrich |
| `6_bm02` | Equação de Forma da Vesícula |
| `6_bm03` | Espectro de Flutuações Térmicas |
| `6_bm04` | Equação de Saffman-Delbrück |
| `6_bm05` | Modelo de Singer-Nicolson |
| `6_bm06` | Transição de Fase Lipídica |
| `6_em01` | Modelo de Drude |
| `6_em02` | Oscilador de Lorentz |
| `6_em03` | Relações de Kramers-Kronig |
| `6_em04` | Ressonância de Plasmon de Superfície |
| `6_em05` | Metamaterial (Índice Negativo) |
| `6_em06` | Fórmula de Clausius-Mossotti |
| `6_em07` | Efeito Casimir |
| `6_rh01` | Fluido Newtoniano |
| `6_rh02` | Modelo de Maxwell |
| `6_rh03` | Modelo de Kelvin-Voigt |
| `6_rh04` | Lei de Potência (Power Law) |
| `6_rh05` | Equação de Cross |
| `6_rh06` | Módulos G' e G'' |
| `6_rh07` | Equação Constitutiva de Oldroyd-B |

#### Sistemas Integráveis e TQFTs

| ID | Fórmula/Equação |
|---|---|
| `6_si01` | Equação KdV |
| `6_si02` | Par de Lax |
| `6_si03` | Inverse Scattering Transform |
| `6_si04` | Sóliton de N-corpos |
| `6_si05` | Sistema de Toda |
| `6_si06` | Equação Sine-Gordon |
| `6_si07` | Equação NLS |
| `6_si08` | Hierarquia KP |
| `6_si09` | Equações de Yang-Baxter |
| `6_si10` | Teorema de Liouville-Arnold |
| `6_tf01` | TQFT de Atiyah |
| `6_tf02` | Invariante de Chern-Simons |
| `6_tf03` | Invariante de Witten-Reshetikhin-Turaev |
| `6_tf04` | Polinômio de Jones via TQFT |
| `6_tf05` | Modelo de Turaev-Viro |
| `6_tf06` | 2d TQFT e Álgebras de Frobenius |
| `6_tf07` | Cobordismo Estendido (Hipótese de Baez-Dolan) |

#### Sobolev e Distribuições

| ID | Fórmula/Equação |
|---|---|
| `6_ds01` | Distribuição (Funcional Generalizada) |
| `6_ds02` | Delta de Dirac |
| `6_ds03` | Derivada Distribucional |
| `6_ds04` | Espaço de Schwartz S |
| `6_ds05` | Transformada de Fourier em S' |
| `6_ds06` | Solução Fundamental (Função de Green) |
| `6_ds07` | Teorema do Núcleo de Schwartz |
| `6_na01` | Ultrapotência *ℝ |
| `6_na02` | Princípio de Transferência |
| `6_na03` | Infinitesimal e Mônada |
| `6_na04` | Parte Standard |
| `6_na05` | Derivada via Infinitesimais |
| `6_na06` | Integral via Soma Hiperfinita |
| `6_so01` | Espaço de Sobolev W^{k,p} |
| `6_so02` | Imersão de Sobolev |
| `6_so03` | Desigualdade de Poincaré |
| `6_so04` | Teorema de Traços |
| `6_so05` | Imersão Compacta de Rellich-Kondrachov |
| `6_so06` | Desigualdade de Gagliardo-Nirenberg |
| `6_so07` | Espaço H^s (Sobolev Fracionário) |
| `6_so08` | Teorema de Lax-Milgram |

#### Sísmica e Eletroquímica

| ID | Fórmula/Equação |
|---|---|
| `6_cr01` | Função de Confiabilidade |
| `6_cr02` | Distribuição de Weibull |
| `6_cr03` | MTTF / MTBF |
| `6_cr04` | Sistema Série/Paralelo |
| `6_cr05` | Árvore de Falhas (FTA) |
| `6_cr06` | Processo de Poisson (Falhas) |
| `6_ec01` | Equação de Nernst |
| `6_ec02` | Equação de Butler-Volmer |
| `6_ec03` | Equação de Tafel |
| `6_ec04` | Lei de Faraday (Eletrólise) |
| `6_ec05` | Impedância de Nyquist (EIS) |
| `6_ec06` | Equação de Warburg (Difusão) |
| `6_se01` | Espectro de Resposta (Sísmica) |
| `6_se02` | Análise Modal (Superposição) |
| `6_se03` | Fator de Comportamento (q-factor) |
| `6_se04` | Isolamento de Base (Período Alvo) |
| `6_se05` | Magnitude-Momento (Mw) |

#### Teoria Conforme e SLE

| ID | Fórmula/Equação |
|---|---|
| `6_cft01` | Álgebra de Virasoro |
| `6_cft02` | Tensor Energia-Momento em CFT |
| `6_cft03` | OPE (Operator Product Expansion) |
| `6_cft04` | Correspondência Estado-Operador |
| `6_cft05` | Função de Partição CFT |
| `6_cft06` | Bootstrap Conforme |
| `6_cft07` | Modelo de Ising CFT (c=1/2) |
| `6_gdg01` | Empacotamento de Esferas em ℝ² |
| `6_gdg02` | Conjectura de Kepler (Hales) |
| `6_gdg03` | Bound de Hamming (Esferas) |
| `6_gdg04` | Teorema de Minkowski (Lattice) |
| `6_gdg05` | Politopos Regulares |
| `6_sle01` | SLE_κ (Equação de Loewner) |
| `6_sle02` | Fases de SLE por κ |
| `6_sle03` | Percolação Crítica (SLE₆) |
| `6_sle04` | Ising Crítico 2D (SLE₃) |
| `6_sle05` | LERW e Spanning Tree (SLE₂, SLE₈) |

#### Transporte Quântico e Topologia

| ID | Fórmula/Equação |
|---|---|
| `6_po01` | Polâron de Fröhlich |
| `6_po02` | Energia do Polâron (Acoplamento Fraco) |
| `6_po03` | Polâron de Holstein |
| `6_po04` | Polâron de Pekar (Acoplamento Forte) |
| `6_po05` | Bipolâron |
| `6_qh01` | Efeito Hall Quântico Inteiro (IQHE) |
| `6_qh02` | Número de Chern (TKNN) |
| `6_qh03` | Efeito Hall Quântico Fracionário |
| `6_qh04` | Função de Onda de Laughlin |
| `6_qh05` | Estados de Borda (Bulk-Edge) |
| `6_qt01` | Fórmula de Landauer |
| `6_qt02` | Fórmula de Landauer-Büttiker |
| `6_qt03` | Condutância Quantizada em QPC |
| `6_qt04` | Fórmula de Kubo (Condutividade) |
| `6_qt05` | Efeito Aharonov-Bohm |
| `6_qt06` | Localização de Anderson |
| `6_to01` | Invariante Z₂ (2D) |
| `6_to02` | Modelo de Kane-Mele |
| `6_to03` | Isolante Topológico 3D |
| `6_to04` | Hamiltoniano de Superfície do IT |
| `6_to05` | Classificação de Altland-Zirnbauer |
| `6_to06` | Modelo de Haldane |
| `6_to07` | Semimetal de Weyl |

#### Tráfego e Transferência Radiativa

| ID | Fórmula/Equação |
|---|---|
| `6_ct01` | Tristimulus XYZ (CIE 1931) |
| `6_ct02` | Cromaticidade xy e Iluminante D65 |
| `6_ct03` | Diferença de Cor CIEDE2000 |
| `6_ct04` | Rendering Equation (Iluminação) |
| `6_et01` | Modelo LWR (Lighthill-Whitham-Richards) |
| `6_et02` | Modelo de Greenshields |
| `6_et03` | Fórmula de Webster (Semáforo) |
| `6_et04` | Modelo do Car-Following (IDM) |
| `6_et05` | Equilíbrio de Wardrop |
| `6_et06` | Diagrama Fundamental (Flow-Density) |
| `6_rt01` | Equação de Transferência Radiativa (RTE) |
| `6_rt02` | Lei de Beer-Lambert |
| `6_rt03` | Função de Fase de Henyey-Greenstein |
| `6_rt04` | Aproximação de Difusão Radiativa |
| `6_rt05` | Monte Carlo Radiativo |
| `6_rt06` | Lei de Kirchhoff (Emissividade) |
| `6_rt07` | View Factor (Fator de Forma) |

#### Verificação Formal e CPS

| ID | Fórmula/Equação |
|---|---|
| `6_cps01` | Autômato Híbrido |
| `6_cps02` | Condição de Zeno |
| `6_cps03` | Barrier Certificate |
| `6_cps04` | Control Barrier Function (CBF) |
| `6_cps05` | CLF+CBF QP (Safety-Critical) |
| `6_rts01` | Rate Monotonic (RM) |
| `6_rts02` | Earliest Deadline First (EDF) |
| `6_rts03` | WCET (Worst-Case Execution Time) |
| `6_rts04` | Análise de Tempo de Resposta (TDA) |
| `6_vf01` | CTL Model Checking |
| `6_vf02` | EF φ (Eventualmente) |
| `6_vf03` | AG φ (Sempre em Todos) |
| `6_vf04` | CEGAR (Abstraction-Refinement) |
| `6_vf05` | Bounded Model Checking (CBMC) |
| `6_vf06` | Especificação Z |
| `6_vf07` | CSP (Process Algebra) |

#### Visão Computacional e SLAM

| ID | Fórmula/Equação |
|---|---|
| `6_slam01` | EKF-SLAM (Estado) |
| `6_slam02` | Predição EKF-SLAM |
| `6_slam03` | Atualização EKF-SLAM |
| `6_slam04` | FastSLAM (Particle Filter) |
| `6_slam05` | Bundle Adjustment |
| `6_slam06` | Levenberg-Marquardt para BA |
| `6_slam07` | Graph-SLAM |
| `6_vc01` | Modelo Pinhole (Projeção) |
| `6_vc02` | Matriz Intrínseca K |
| `6_vc03` | Distorção Radial |
| `6_vc04` | Calibração de Zhang |
| `6_vc05` | Matriz Essencial E |
| `6_vc06` | Matriz Fundamental F |
| `6_vc07` | Homografia H (4 pontos) |

#### Óptica Não-Linear e Atômica

| ID | Fórmula/Equação |
|---|---|
| `6_at01` | Resfriamento Doppler |
| `6_at02` | Armadilha Magneto-Óptica (MOT) |
| `6_at03` | Condensado de Bose-Einstein (BEC) |
| `6_at04` | Equação de Gross-Pitaevskii |
| `6_at05` | Rede Óptica |
| `6_at06` | Ressonância de Feshbach |
| `6_at07` | Limite de Recoil e Resfriamento Sub-Doppler |
| `6_nl01` | Polarização Não-Linear |
| `6_nl02` | Geração de Segundo Harmônico |
| `6_nl03` | Efeito Kerr Óptico |
| `6_nl04` | Automodulação de Fase (SPM) |
| `6_nl05` | Sóliton Óptico |
| `6_nl06` | Mistura de Quatro Ondas (FWM) |
| `6_nl07` | Oscilação Paramétrica Óptica |
| `6_nl08` | Geração de Altos Harmônicos (HHG) |
| `6_sf01` | Adsorção de Langmuir |
| `6_sf02` | Isoterma BET |
| `6_sf03` | Difração LEED |
| `6_sf04` | STM (Microscópio de Tunelamento) |
| `6_sf05` | Energia de Superfície |
| `6_sf06` | XPS (Espectroscopia de Fotoelétrons) |

#### ∞-Categorias e Teoria de Tipos

| ID | Fórmula/Equação |
|---|---|
| `6_der01` | Categoria Derivada D(A) |
| `6_der02` | Triângulo Distinto |
| `6_der03` | Functor Derivado Rf |
| `6_der04` | Sequência Espectral de Grothendieck |
| `6_der05` | Complexo de Koszul |
| `6_der06` | D^b(Coh X) e Reconstrução |
| `6_der07` | Equivalência de Morita Derivada |
| `6_der08` | t-Estrutura |
| `6_ht01` | Tipo Identidade |
| `6_ht02` | Universo Tipo U |
| `6_ht03` | Axioma de Univalência |
| `6_ht04` | Higher Inductive Type |
| `6_ht05` | Fibração via Tipos Dependentes |
| `6_ht06` | π₁(S¹) = ℤ |
| `6_ht07` | Truncação n-Tipos |
| `6_inf01` | Quasicategoria |
| `6_inf02` | Espaço de Mapeamento |
| `6_inf03` | Limite e Colimite ∞-Categóricos |
| `6_inf04` | Adjunção ∞-Categórica |
| `6_inf05` | Localização de Dwyer-Kan |
| `6_inf06` | ∞-Topos |
| `6_inf07` | Lema de Yoneda ∞-Categórico |

</details>

<details>
<summary><b>Volume VII — 249 fórmulas</b></summary>

#### Categorias
- Acústica e Vibroacústica (3)
- Agronomia (5)
- Análise Harmônica (2)
- Artesanato e Ofícios (16)
- Astronomia (7)
- Balística (2)
- Bioestatística (2)
- Biomecânica (3)
- Ciência Atuarial (2)
- Ciência dos Materiais (4)
- Ciências Esportivas (3)
- Ciências Florestais (7)
- Computação Gráfica (3)
- Cosmologia Inflacionária (1)
- Criptografia (7)
- Dispositivos Semicondutores (1)
- Ecologia (2)
- Economia (4)
- Eletroquímica (1)
- Energia Renovável (5)
- Engenharia Aeroespacial (4)
- Engenharia Ambiental (8)
- Engenharia Civil (6)
- Engenharia de Controle (5)
- Engenharia Elétrica (5)
- Engenharia Mecânica (6)
- Engenharia Naval (2)
- Engenharia Química (7)
- Epidemiologia (6)
- Farmácia (6)
- Fenômenos de Transporte (4)
- Fotografia (4)
- Física de Plasmas (2)
- Física Médica (3)
- Física Nuclear (3)
- Genética Quantitativa (2)
- Geodésia e Topografia (4)
- Geofísica (4)
- Geoquímica (1)
- Imagiologia (3)
- Inteligência Artificial (4)
- Jogos e Recreação (10)
- Macroeconomia (1)
- Matemática Elementar (11)
- Mecânica das Vibrações (2)
- Medicina (8)
- Medicina Veterinária (2)
- Metrologia (2)
- Microeconomia (2)
- Nutrição (4)
- Oceanografia (2)
- Pesquisa Operacional (4)
- Processamento de Sinais (3)
- Psicofísica (2)
- Psicometria e IRT (3)
- Química Analítica (4)
- Sistemas Complexos (3)
- Séries Temporais (2)
- Tecnologias Emergentes (10)
- Teoria das Redes (2)
- Teoria dos Jogos (3)

#### Acústica e Vibroacústica

| ID | Fórmula/Equação |
|---|---|
| `7_acu01` | Nível de Pressão Sonora (dB SPL) |
| `7_acu02` | Velocidade do Som no Ar |
| `7_acu03` | Lei do Inverso do Quadrado (Som) |

#### Agronomia

| ID | Fórmula/Equação |
|---|---|
| `7_agr01` | Evapotranspiração de Referência (ET₀) |
| `7_agr02` | Produtividade da Água (WP) |
| `7_agr03` | Necessidade de Calagem |
| `7_agr04` | Perda de Solo (USLE) |
| `7_agr05` | Graus-Dia Acumulados |

#### Análise Harmônica

| ID | Fórmula/Equação |
|---|---|
| `7_ahr01` | Série de Fourier (Coeficientes) |
| `7_ahr02` | Transformada de Fourier (DFT) |

#### Artesanato e Ofícios

| ID | Fórmula/Equação |
|---|---|
| `7_art01` | Comprimento de Tecido para Saia Godê |
| `7_art02` | Margem de Costura |
| `7_art03` | Volume de Madeira (Tábuas) |
| `7_art04` | Ângulo de Junta (Meia-Esquadria) |
| `7_art05` | Retração da Argila (%) |
| `7_art06` | Escalonamento de Receita |
| `7_art07` | Conversão Celsius → Fahrenheit |
| `7_art08` | Volume de Substrato (Canteiro) |
| `7_art09` | Rendimento de Tinta |
| `7_art10` | Amostra de Tricô (Gauge) |
| `7_art11` | Índice de Saponificação (NaOH) |
| `7_art12` | Comprimento de Fio para Anel |
| `7_art13` | Espessura da Lombada (Livro) |
| `7_art14` | Coeficiente de Expansão Térmica (Vidro) |
| `7_art15` | Cálculo de Urdidura (Tecelagem) |
| `7_art16` | Lado Mínimo (Origami Modular) |

#### Astronomia

| ID | Fórmula/Equação |
|---|---|
| `7_ast01` | Terceira Lei de Kepler |
| `7_ast02` | Lei de Hubble |
| `7_ast03` | Magnitude Aparente e Absoluta |
| `7_ast04` | Lei de Stefan-Boltzmann (Estrelas) |
| `7_ast05` | Velocidade de Escape |
| `7_ast06` | Paralaxe Estelar |
| `7_ast07` | Lei de Wien (Pico de Emissão) |

#### Balística

| ID | Fórmula/Equação |
|---|---|
| `7_bal01` | Alcance Máximo (Projétil) |
| `7_bal02` | Coeficiente Balístico |

#### Bioestatística

| ID | Fórmula/Equação |
|---|---|
| `7_bes01` | Odds Ratio (Razão de Chances) |
| `7_bes02` | Tamanho Amostral (Proporção) |

#### Biomecânica

| ID | Fórmula/Equação |
|---|---|
| `7_bio01` | Momento Articular |
| `7_bio02` | Força de Reação do Solo (Salto) |
| `7_bio03` | Centro de Massa (Segmental) |

#### Ciência Atuarial

| ID | Fórmula/Equação |
|---|---|
| `7_cat01` | Valor Presente Atuarial (Anuidade Vitalícia) |
| `7_cat02` | Prêmio Puro de Seguro de Vida |

#### Ciência dos Materiais

| ID | Fórmula/Equação |
|---|---|
| `7_cmt01` | Equação de Hall-Petch |
| `7_cmt02` | Difusão (Arrhenius de Difusão) |
| `7_cmt03` | Tensão de Orowan (Endurecimento por Precipitação) |
| `7_cmt04` | Fração Transformada (Avrami) |

#### Ciências Esportivas

| ID | Fórmula/Equação |
|---|---|
| `7_esp01` | VO₂máx Estimado (Cooper) |
| `7_esp02` | Gasto Energético (MET) |
| `7_esp03` | Frequência Cardíaca Alvo (Karvonen) |

#### Ciências Florestais

| ID | Fórmula/Equação |
|---|---|
| `7_flo01` | DAP a partir da Circunferência |
| `7_flo02` | Área Basal de Árvore |
| `7_flo03` | Volume de Árvore (Huber) |
| `7_flo04` | Índice de Sítio (Chapman-Richards) |
| `7_flo05` | Incremento Médio Anual (IMA) |
| `7_flo06` | Índice de Shannon-Wiener |
| `7_flo07` | Fator de Forma |

#### Computação Gráfica

| ID | Fórmula/Equação |
|---|---|
| `7_cgr01` | Modelo de Iluminação (Phong) |
| `7_cgr02` | Transformação de Escala 2D |
| `7_cgr03` | Interpolação Linear (Lerp) |

#### Cosmologia Inflacionária

| ID | Fórmula/Equação |
|---|---|
| `7_cos01` | Equação de Friedmann |

#### Criptografia

| ID | Fórmula/Equação |
|---|---|
| `7_crp01` | Cifra de César (Shift) |
| `7_crp02` | RSA — Exponenciação Modular |
| `7_crp03` | Entropia da Senha |
| `7_crp04` | Diffie-Hellman (Chave Compartilhada) |
| `7_crp05` | Hash — Paradoxo do Aniversário |
| `7_crp06` | One-Time Pad (XOR) |
| `7_crp07` | Curva Elíptica (Soma de Pontos) |

#### Dispositivos Semicondutores

| ID | Fórmula/Equação |
|---|---|
| `7_sem01` | Equação de Shockley (Diodo) |

#### Ecologia

| ID | Fórmula/Equação |
|---|---|
| `7_ecl01` | Índice de Shannon (Diversidade) |
| `7_ecl02` | Modelo de Lotka-Volterra (Predador-Presa) |

#### Economia

| ID | Fórmula/Equação |
|---|---|
| `7_eco01` | PIB pela Ótica da Despesa |
| `7_eco02` | Taxa de Inflação (IPC) |
| `7_eco03` | Equação de Fisher |
| `7_eco04` | Multiplicador Keynesiano |

#### Eletroquímica

| ID | Fórmula/Equação |
|---|---|
| `7_elq01` | Equação de Nernst |

#### Energia Renovável

| ID | Fórmula/Equação |
|---|---|
| `7_enr01` | Potência Solar Fotovoltaica |
| `7_enr02` | Potência Eólica (Betz) |
| `7_enr03` | Potência Hidrelétrica |
| `7_enr04` | Energia de Biomassa (PCI) |
| `7_enr05` | Fator de Capacidade |

#### Engenharia Aeroespacial

| ID | Fórmula/Equação |
|---|---|
| `7_eae01` | Sustentação Aeronáutica |
| `7_eae02` | Equação de Tsiolkovsky |
| `7_eae03` | Número de Mach |
| `7_eae04` | Impulso Específico |

#### Engenharia Ambiental

| ID | Fórmula/Equação |
|---|---|
| `7_eam01` | DBO Residual (Streeter-Phelps) |
| `7_eam02` | Déficit de OD (Streeter-Phelps) |
| `7_eam03` | Índice de Qualidade da Água (IQA) |
| `7_eam04` | Equação de Manning |
| `7_eam05` | Tempo de Detenção Hidráulico |
| `7_eam06` | Eficiência de Remoção |
| `7_eam07` | Dispersão Gaussiana de Poluentes |
| `7_eam08` | Pegada de Carbono |

#### Engenharia Civil

| ID | Fórmula/Equação |
|---|---|
| `7_ecv01` | Tensão Normal (σ = F/A) |
| `7_ecv02` | Momento Fletor Máximo (Viga Biapoiada) |
| `7_ecv03` | Lei de Hooke |
| `7_ecv04` | Capacidade de Carga (Terzaghi) |
| `7_ecv05` | Dosagem de Concreto (fck) |
| `7_ecv06` | Flecha Máxima (Viga Biapoiada) |

#### Engenharia de Controle

| ID | Fórmula/Equação |
|---|---|
| `7_ect01` | Controlador PID |
| `7_ect02` | Função de Transferência 1ª Ordem |
| `7_ect03` | Critério de Estabilidade (Routh) |
| `7_ect04` | Margem de Ganho e Fase |
| `7_ect05` | Erro em Regime Permanente |

#### Engenharia Elétrica

| ID | Fórmula/Equação |
|---|---|
| `7_eel01` | Lei de Ohm |
| `7_eel02` | Potência Elétrica |
| `7_eel03` | Impedância RL/RC |
| `7_eel04` | Transformador Ideal |
| `7_eel05` | Rendimento de Motor Elétrico |

#### Engenharia Mecânica

| ID | Fórmula/Equação |
|---|---|
| `7_emc01` | Tensão de Cisalhamento |
| `7_emc02` | Torque |
| `7_emc03` | Potência Mecânica Rotacional |
| `7_emc04` | Rendimento de Carnot |
| `7_emc05` | Coeficiente de Segurança |
| `7_emc06` | Vida em Fadiga (S-N) |

#### Engenharia Naval

| ID | Fórmula/Equação |
|---|---|
| `7_env01` | Princípio de Arquimedes (Empuxo) |
| `7_env02` | Número de Froude |

#### Engenharia Química

| ID | Fórmula/Equação |
|---|---|
| `7_eqm01` | Equação de Arrhenius |
| `7_eqm02` | Balanço de Massa (CSTR) |
| `7_eqm03` | Número de Reynolds |
| `7_eqm04` | Lei de Raoult |
| `7_eqm05` | Equação de Clausius-Clapeyron |
| `7_eqm06` | Número de Pratos Teóricos (McCabe-Thiele) |
| `7_eqm07` | Coeficiente Global de Troca Térmica |

#### Epidemiologia

| ID | Fórmula/Equação |
|---|---|
| `7_epi01` | Modelo SIR (Equações) |
| `7_epi02` | Número Reprodutivo Básico (R₀) |
| `7_epi03` | Equilíbrio de Hardy-Weinberg |
| `7_epi04` | Taxa de Incidência |
| `7_epi05` | Taxa de Prevalência |
| `7_epi06` | Odds Ratio (OR) |

#### Farmácia

| ID | Fórmula/Equação |
|---|---|
| `7_far01` | Concentração Molar |
| `7_far02` | Equação de Diluição |
| `7_far03` | Biodisponibilidade |
| `7_far04` | Meia-Vida de Eliminação |
| `7_far05` | Clearance Renal (Cockcroft-Gault) |
| `7_far06` | Equação de Henderson-Hasselbalch |

#### Fenômenos de Transporte

| ID | Fórmula/Equação |
|---|---|
| `7_ftr01` | Lei de Fourier (Condução Térmica) |
| `7_ftr02` | Lei de Fick (Difusão) |
| `7_ftr03` | Lei de Newton (Resfriamento convectivo) |
| `7_ftr04` | Lei de Stefan-Boltzmann (Radiação) |

#### Fotografia

| ID | Fórmula/Equação |
|---|---|
| `7_fot01` | Profundidade de Campo (DoF) |
| `7_fot02` | Regra Sunny f/16 |
| `7_fot03` | Distância Hiperfocal |
| `7_fot04` | Exposição (EV) |

#### Física de Plasmas

| ID | Fórmula/Equação |
|---|---|
| `7_fpl01` | Frequência de Plasma |
| `7_fpl02` | Comprimento de Debye |

#### Física Médica

| ID | Fórmula/Equação |
|---|---|
| `7_fme01` | Dose Absorvida de Radiação |
| `7_fme02` | Lei do Inverso do Quadrado |
| `7_fme03` | Decaimento Radioativo |

#### Física Nuclear

| ID | Fórmula/Equação |
|---|---|
| `7_fnc01` | Equação de Decaimento Radioativo |
| `7_fnc02` | Equivalência Massa-Energia |
| `7_fnc03` | Seção de Choque Nuclear |

#### Genética Quantitativa

| ID | Fórmula/Equação |
|---|---|
| `7_gqu01` | Equilíbrio de Hardy-Weinberg |
| `7_gqu02` | Resposta à Seleção (Breeder's Eq.) |

#### Geodésia e Topografia

| ID | Fórmula/Equação |
|---|---|
| `7_geo01` | Distância por Fórmula de Haversine |
| `7_geo02` | Área por Coordenadas (Gauss/Shoelace) |
| `7_geo03` | Nivelamento Geométrico |
| `7_geo04` | Correção de Curvatura e Refração |

#### Geofísica

| ID | Fórmula/Equação |
|---|---|
| `7_gfis01` | Escala de Magnitude (Richter) |
| `7_gfis02` | Anomalia Gravitacional de Bouguer |
| `7_gfis03` | Fluxo de Calor Geotérmico |
| `7_gfis04` | Velocidade de Onda Sísmica |

#### Geoquímica

| ID | Fórmula/Equação |
|---|---|
| `7_gqm01` | Datação Radiométrica |

#### Imagiologia

| ID | Fórmula/Equação |
|---|---|
| `7_img01` | Número de Hounsfield (CT) |
| `7_img02` | Equação de Larmor (RM) |
| `7_img03` | Atenuação de Fótons (Beer-Lambert) |

#### Inteligência Artificial

| ID | Fórmula/Equação |
|---|---|
| `7_iaa01` | Função Sigmóide (Logística) |
| `7_iaa02` | Entropia Cruzada (Cross-Entropy Loss) |
| `7_iaa03` | Descida de Gradiente (SGD) |
| `7_iaa04` | Softmax |

#### Jogos e Recreação

| ID | Fórmula/Equação |
|---|---|
| `7_jog01` | Probabilidade de Dado Justo |
| `7_jog02` | Valor Esperado (Aposta) |
| `7_jog03` | Rating Elo (Xadrez) |
| `7_jog04` | Combinações (Loterias) |
| `7_jog05` | Distância de Dardo ao Alvo |
| `7_jog06` | Velocidade do Projétil (Paintball/Airsoft) |
| `7_jog07` | Handicap de Golfe (Diferencial) |
| `7_jog08` | Partida de Pontos (Bridge/Rummy) |
| `7_jog09` | Tempo de Puzzles (Speedcubing) |
| `7_jog10` | Rating Glicko (Intervalo de Confiança) |

#### Macroeconomia

| ID | Fórmula/Equação |
|---|---|
| `7_mac01` | Equação Quantitativa da Moeda |

#### Matemática Elementar

| ID | Fórmula/Equação |
|---|---|
| `7_mel01` | Regra de Três Simples |
| `7_mel02` | Porcentagem |
| `7_mel03` | Média Aritmética Simples |
| `7_mel04` | Média Ponderada |
| `7_mel05` | Desvio Padrão Amostral |
| `7_mel06` | Teorema de Pitágoras |
| `7_mel07` | Área do Círculo |
| `7_mel08` | Volume do Cilindro |
| `7_mel09` | Conversão Celsius → Fahrenheit |
| `7_mel10` | Velocidade Média |
| `7_mel11` | Densidade |

#### Mecânica das Vibrações

| ID | Fórmula/Equação |
|---|---|
| `7_mvb01` | Frequência Natural (Massa-Mola) |
| `7_mvb02` | Fator de Amortecimento |

#### Medicina

| ID | Fórmula/Equação |
|---|---|
| `7_med01` | Índice de Massa Corporal (IMC) |
| `7_med02` | Superfície Corporal (Du Bois) |
| `7_med03` | Fórmula de Parkland |
| `7_med04` | Pressão Arterial Média (PAM) |
| `7_med05` | Gap Aniônico |
| `7_med06` | Equação de Fick (Débito Cardíaco) |
| `7_med07` | Osmolaridade Sérica Calculada |
| `7_med08` | TFG estimada (CKD-EPI simplificada) |

#### Medicina Veterinária

| ID | Fórmula/Equação |
|---|---|
| `7_vet01` | Dose por Peso Animal |
| `7_vet02` | Escala Alométrica Veterinária |

#### Metrologia

| ID | Fórmula/Equação |
|---|---|
| `7_met01` | Incerteza Combinada (GUM) |
| `7_met02` | Incerteza Expandida (k=2) |

#### Microeconomia

| ID | Fórmula/Equação |
|---|---|
| `7_mic01` | Elasticidade-Preço da Demanda |
| `7_mic02` | Excedente do Consumidor |

#### Nutrição

| ID | Fórmula/Equação |
|---|---|
| `7_nut01` | Harris-Benedict (TMB Homem) |
| `7_nut02` | Gasto Energético Total (GET) |
| `7_nut03` | Calorias de Macronutrientes |
| `7_nut04` | Necessidade Hídrica (Holiday-Segar) |

#### Oceanografia

| ID | Fórmula/Equação |
|---|---|
| `7_ocn01` | Equação de Estado da Água do Mar |
| `7_ocn02` | Velocidade de Onda Oceânica |

#### Pesquisa Operacional

| ID | Fórmula/Equação |
|---|---|
| `7_pop01` | Programação Linear (Função Objetivo) |
| `7_pop02` | Fila M/M/1 (Tempo Médio) |
| `7_pop03` | Modelo EOQ (Lote Econômico) |
| `7_pop04` | Caminho Crítico (CPM/PERT) |

#### Processamento de Sinais

| ID | Fórmula/Equação |
|---|---|
| `7_psi01` | Teorema de Nyquist-Shannon |
| `7_psi02` | SNR (Relação Sinal-Ruído) |
| `7_psi03` | Filtro Digital (IIR 1ª Ordem) |

#### Psicofísica

| ID | Fórmula/Equação |
|---|---|
| `7_psf01` | Lei de Weber-Fechner |
| `7_psf02` | Lei de Stevens (Potência) |

#### Psicometria e IRT

| ID | Fórmula/Equação |
|---|---|
| `7_pmt01` | Alfa de Cronbach |
| `7_pmt02` | Modelo de Rasch (1PL-IRT) |
| `7_pmt03` | Escore Padronizado (Z-Score) |

#### Química Analítica

| ID | Fórmula/Equação |
|---|---|
| `7_qan01` | Lei de Beer-Lambert |
| `7_qan02` | Equação de Henderson-Hasselbalch |
| `7_qan03` | Limite de Detecção (3σ) |
| `7_qan04` | Titulação Ácido-Base |

#### Sistemas Complexos

| ID | Fórmula/Equação |
|---|---|
| `7_scx01` | Mapa Logístico |
| `7_scx02` | Expoente de Lyapunov |
| `7_scx03` | Dimensão Fractal (Box-Counting) |

#### Séries Temporais

| ID | Fórmula/Equação |
|---|---|
| `7_ste01` | Média Móvel Exponencial (EMA) |
| `7_ste02` | Autocorrelação (lag k) |

#### Tecnologias Emergentes

| ID | Fórmula/Equação |
|---|---|
| `7_tem01` | Lei de Moore (Transistores) |
| `7_tem02` | Qubit — Estado de Superposição |
| `7_tem03` | Latência 5G (URLLC) |
| `7_tem04` | Eficiência do Painel Solar |
| `7_tem05` | Capacidade da Bateria (kWh) |
| `7_tem06` | Blockchain — Hash Rate e Dificuldade |
| `7_tem07` | Impressão 3D — Tempo de Impressão |
| `7_tem08` | Autonomia de Drone |
| `7_tem09` | Limite de Betz (Turbina Eólica) |
| `7_tem10` | CRISPR — Eficiência de Edição |

#### Teoria das Redes

| ID | Fórmula/Equação |
|---|---|
| `7_trd01` | Coeficiente de Agrupamento |
| `7_trd02` | Modelo de Barabási-Albert (Grau Esperado) |

#### Teoria dos Jogos

| ID | Fórmula/Equação |
|---|---|
| `7_tjo01` | Equilíbrio de Nash (Estratégia Mista) |
| `7_tjo02` | Valor de Shapley |
| `7_tjo03` | Leilão de Vickrey (Segundo Preço) |

</details>

---
## :heavy_plus_sign: Como Adicionar Fórmulas

Adicione no serviço apropriado em `Services/` mantendo padronização de IDs, categoria e qualidade didática.

```csharp
new Formula
{
    Id = "cat001",
    Nome = "Nome da Fórmula",
    Categoria = "Álgebra",
    Expressao = "f(x) = ...",
    ExprTexto = "f(x) = ...",
    Icone = "f",
    Descricao = "Descrição curta e objetiva",
    Criador = "Autor",
    AnoOrigin = "1850",
    ExemploPratico = "Cenário real de uso",
    Variaveis =
    [
        new() { Simbolo = "x", Nome = "Variável x", ValorPadrao = 1 }
    ],
    VariavelResultado = "f(x)",
    Calcular = vars => Math.Sqrt(vars["x"])
}
```

### Checklist de qualidade

- ID único e estável.
- Categoria válida e consistente.
- Expressão simbólica + texto explicativo (`Expressao` e `ExprTexto`).
- Contexto histórico/autor quando aplicável.
- Exemplo prático claro.
- Validação de domínio matemático no `Calcular`.

---

## :art: Design System

> [!NOTE]
> Identidade visual inspirada em observatório científico: contraste alto, foco em leitura e hierarquia clara.

### Cores principais

- Fundo principal: `#0D1117`
- Acento principal: `#D4A64A`
- Acento secundário: `#3DD6C0`

### Tipografia

- Títulos: `Cormorant Garamond`
- Interface: `DM Sans`
- Equações/monospace: `JetBrains Mono`

### Diretrizes de UX

- Evitar blocos longos sem respiro visual.
- Priorizar contraste e tamanho de fonte legível.
- Exibir contexto didático junto de cada fórmula.

---

## :wheelchair: Acessibilidade

> [!TIP]
> Recomendado para evolução contínua do projeto.

- Alto contraste e tema com boa razão de legibilidade.
- Tamanho de fonte ajustável no app.
- Labels descritivos para botões e campos de variáveis.
- Navegação por teclado e foco visível em componentes interativos.
- Evitar dependência exclusiva de cor para estado/feedback.
- Conteúdo textual equivalente para ícones e sinais visuais.

---

## :package: Build e Publicação

### Build local

```bash
dotnet build -f net10.0-windows10.0.19041.0
dotnet build -f net10.0-android
```

### Publicação Android (exemplo)

```bash
dotnet publish -f net10.0-android -c Release
```

> [!WARNING]
> Keystore, alias e senhas devem ser protegidos com variáveis de ambiente e/ou pipeline de CI.

---

## :test_tube: Troubleshooting

### Erro de workload MAUI

```bash
dotnet workload restore
dotnet workload install maui
```

### Erro de SDK Android

- Verifique Android Studio e Android SDK instalados.
- Confira a variável de ambiente ou caminho do SDK.

### App não inicia em Windows

- Confirme `net10.0-windows10.0.19041.0` no comando.
- Rode `dotnet clean` seguido de `dotnet build`.

---

## :handshake: Contribuição

Contribuições são bem-vindas.

Fluxo recomendado:

1. Crie uma branch de trabalho.
2. Implemente a melhoria com commits descritivos.
3. Rode build e validações locais.
4. Abra PR com contexto técnico e impacto.

---

## :page_facing_up: Licença

Este projeto está sob a licença **MIT**.
Uso livre para fins educacionais e comerciais, conforme os termos da licença.

---

<p align="center">
  Feito com :orange_heart: para estudo, engenharia e ciência aplicada.
</p>
