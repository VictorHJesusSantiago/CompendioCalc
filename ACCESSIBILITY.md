# ♿ Acessibilidade - CompendioCalc

CompendioCalc é uma calculadora científica completamente acessível, projetada para servir pessoas com diversas necessidades de acessibilidade, incluindo deficiências visuais, auditivas, motoras e cognitivas.

## 📋 Índice

- [Visão Geral](#visão-geral)
- [Recursos Implementados](#recursos-implementados)
- [Como Usar](#como-usar)
- [Atalhos de Teclado](#atalhos-de-teclado)
- [Configurações por Deficiência](#configurações-por-deficiência)
- [Detalhes Técnicos](#detalhes-técnicos)

## 🎯 Visão Geral

CompendioCalc oferece suporte total a acessibilidade através de:
- **Configurações rápidas (Presets)** pré-configuradas para diferentes tipos de deficiências
- **Personalizações granulares** para controlar cada aspecto da experiência
- **Atalhos de teclado** para navegação rápida
- **Suporte a leitores de tela** (NVDA, JAWS, etc)
- **Alto contraste e modo escuro** para conforto visual
- **Feedback visual** para usuários surdos
- **Navegação simplificada** para usuários com necessidades cognitivas

## 🚀 Recursos Implementados

### 👁️ Para Deficiência Visual

#### Tamanho de Fonte
- **Controle de zoom**: 100%, 125%, 150%, 175%, 200%
- Aumenta todas as fontes da aplicação proporcionalmente
- Mantém a usabilidade em todas as configurações

#### Modo Escuro / Claro
- Alterna entre tema escuro (padrão) e tema claro
- Reduz fadiga ocular em diferentes ambientes
- Cores otimizadas para cada modo

#### Alto Contraste
- Aumenta drasticamente o contraste entre cores
- Cores de fundo preto com texto branco
- Bordas mais visíveis e acentos amarelos intensos

#### Contraste Reforçado
- Adicional ao Alto Contraste
- Aumenta peso das fontes
- Aumenta espessura de bordas

#### Leitor de Tela
- Ativa suporte completo para leitores de tela
- Inclui ARIA labels e roles apropriados
- Anúncios para ações importantes
- Compatível com NVDA, JAWS, VoiceOver (macOS/iOS)

#### Reduzir Movimento
- Remove animações e transições
- Essencial para pessoas com sensibilidade a movimento
- Respeita preferência `prefers-reduced-motion` do sistema

### 👂 Para Deficiência Auditiva

#### Feedback Visual
- Mostra avisos e notificações visualmente
- Bordas piscantes para alertas visuais
- Ícones informativos para todas as ações

#### Legendas e Transcrições
- Qualquer conteúdo de áudio tem legendas
- Descrições textuais de eventos sonoros
- Suporte a legendas em vídeos

#### Flash de Tela para Alertas
- A tela pisca quando há alertas críticos
- Alternativa visual para sons de alerta
- Configurável para frequência

### 🖐️ Para Deficiência Motora

#### Botões Maiores
- Aumenta tamanho de todos os botões para 48x48px mínimo
- Aumenta espaçamento entre elementos
- Reduz necessidade de precisão ao clicar

#### Navegação Apenas por Teclado
- Usa TAB para navegar entre elementos
- ENTER para ativar botões
- Setas para navegação em menus
- Não requer mouse

#### Gestos Simplificados
- Remove gestos complexos (arrastar, pinçar, swipe)
- Apenas cliques/taps simples e navegação por teclado
- Ideal para quem tem limitações de movimento

#### Tempo Limite Aumentado
- Configurável de 2 a 15 segundos
- Dá mais tempo para confirmar ações
- Útil para quem lê lentamente ou tem tremores

### 🧠 Para Deficiência Cognitiva

#### Modo Simplificado
- Remove opções avançadas
- Mostra apenas features essenciais
- Interface menos congestionada
- Reduz sobrecarga cognitiva

#### Instruções Passo a Passo
- Guia detalhado de como usar cada funcionalidade
- Dicas contextuais ao usar o app
- Não assume conhecimento prévio

#### Linguagem Simplificada
- Mensagens usando palavras comuns
- Frases curtas e diretas
- Evita jargão técnico

#### Reduzir Notificações
- Mostra apenas notificações essenciais
- Evita distrações desnecessárias
- Menos alertas sonoros/visuais

#### Mostrar Dicas
- Exibe ajuda contextual
- Tutoriais interativos
- Atalhos sugeridos

### 📖 Para Dislexia

Preset especializado que combina:
- Fonte maior (125%)
- Alto contraste
- Sem animações
- Sem modo simplificado (interface normal)
- Dicas sempre visíveis

## 📖 Como Usar

### 1️⃣ Acessar Configurações de Acessibilidade

**Opção A - Pelo App:**
- Clique no botão ♿ na barra superior
- Ou navegue para `/acessibilidade`

**Opção B - Atalho de Teclado:**
- Pressione `Alt + Shift + A` para abrir configurações

### 2️⃣ Usar Presets Rápidos

Clique em um dos presets para aplicar configurações imediatas:

| Preset | Ideal Para | Configurações |
|--------|-----------|----------------|
| 👁️ Visão | Deficiência Visual | Alto Contraste + Fonte Grande + Leitor de Tela |
| 👂 Audição | Deficiência Auditiva | Feedback Visual + Legendas + Flash de Alerta |
| 🖐️ Motora | Deficiência Motora | Botões Maiores + Navegação por Teclado |
| 🧠 Cognitiva | Deficiência Cognitiva | Modo Simplificado + Instruções Passo a Passo |
| 📖 Dislexia | Dislexia | Font + Alto Contraste + Sem Animações |

### 3️⃣ Personalizar Configurações

Cada configuração pode ser ajustada individualmente:

```
🎥 Deficiência Visual
├─ Tamanho de Fonte: 100% → 200%
├─ Alto Contraste: On/Off
├─ Contraste Reforçado: On/Off
├─ Modo Escuro: On/Off
├─ Leitor de Tela: On/Off
└─ Reduzir Movimento: On/Off

👂 Deficiência Auditiva
├─ Feedback Visual: On/Off
├─ Legendas: On/Off
└─ Flash de Alerta: On/Off

🖐️ Deficiência Motora
├─ Botões Maiores: On/Off
├─ Navegação por Teclado: On/Off
├─ Gestos Simplificados: On/Off
└─ Tempo Limite: 2-15 segundos

🧠 Deficiência Cognitiva
├─ Modo Simplificado: On/Off
├─ Instruções Passo a Passo: On/Off
├─ Linguagem Simplificada: On/Off
├─ Reduzir Notificações: On/Off
└─ Mostrar Dicas: On/Off
```

### 4️⃣ Restaurar Padrões

Clique em "🔄 Restaurar Padrões" para voltar às configurações originais.

## ⌨️ Atalhos de Teclado

CompendioCalc oferece atalhos rápidos para navegação:

| Atalho | Ação |
|--------|------|
| `Alt + Shift + A` | Abrir Configurações de Acessibilidade |
| `Alt + 1` | Ir para Tela Inicial |
| `Alt + 2` | Ir para Categorias |
| `Alt + 3` | Ir para Buscar |
| `Alt + 4` | Ir para Favoritos |
| `Alt + 5` | Ir para Histórico |
| `Alt + H` | Mostrar Ajuda de Atalhos |
| `Tab` | Navegar entre Botões e Links |
| `Shift + Tab` | Navegar para Trás |
| `Enter` / `Espaço` | Ativar Botão Focado |
| `Setas` | Navegar em Menus (se habilitado) |

**Dica**: Pressione `Alt + H` em qualquer momento para ver todos os atalhos!

## 🎯 Configurações por Deficiência

### Deficiência Visual

**Recomendações:**
1. Use o preset "👁️ Visão" para começar
2. Ajuste o tamanho de fonte conforme necessário
3. Ative Alto Contraste se ainda tiver dificuldades
4. Ative Leitor de Tela para navegação por áudio

**Dica**: Se usar lentes de aumento, mantenha o zoom em 100% no navegador.

### Deficiência Auditiva

**Recomendações:**
1. Use o preset "👂 Audição" para começar
2. Ative Feedback Visual para receber avisos visuais
3. Ative Legendas para qualquer conteúdo de áudio
4. Ative Flash de Alerta para notificações críticas

**Dica**: O vibração do dispositivo também fornece feedback quando disponível.

### Deficiência Motora

**Recomendações:**
1. Use o preset "🖐️ Motora" para começar
2. Ative Navegação por Teclado se não usar mouse
3. Ative Botões Maiores para alvo mais fácil
4. Aumente o Tempo Limite se precisar de mais tempo

**Teclado:**
- Pressione `Tab` para mover o foco
- Pressione `Enter` ou `Espaço` para ativar
- Use `Setas` para navegar em menus

**Mouse/Touchpad:**
- Clique no botão focado para ativar

### Deficiência Cognitiva

**Recomendações:**
1. Use o preset "🧠 Cognitiva" para começar
2. Ative Modo Simplificado para menos distrações
3. Deixe Instruções Passo a Passo ativas
4. Deixe Mostrar Dicas ativa para ajuda contextual

**Dica**: Use Linguagem Simplificada se tiver dificuldade com termos técnicos.

### Dislexia

**Recomendações:**
1. Use o preset "📖 Dislexia" para começar
2. Font aumentada ajuda na leitura
3. Alto Contraste reduz cansaço ocular
4. Sem animações para melhor concentração

## 🔧 Detalhes Técnicos

### Arquitetura

CompendioCalc usa um sistema de acessibilidade modular:

```
AccessibilityService.cs
├─ Gerencia configurações
├─ Persistência em arquivo
├─ Presets de acessibilidade
└─ Notificações de mudanças

AccessibilitySettings.razor
├─ UI de configurações
├─ Controles interativos
└─ Presets rápidos visuais

accessibility.css
├─ Estilos base
├─ Temas por classe CSS
├─ Media queries (sistema)
└─ Classes ARIA

accessibility.js
├─ Atalhos de teclado
├─ Detecção de sistema
├─ Anúncios para leitor de tela
└─ Sync de localStorage
```

### Armazenamento de Configurações

As configurações são salvas localmente em:
- **Arquivo**: `AppData/local/accessibility_settings.json`
- **LocalStorage**: localStorage (web)

Isso permite que as preferências persistam entre sessões.

### Conformidade com Padrões

CompendioCalc segue:
- **WCAG 2.1** (Web Content Accessibility Guidelines)
- **ARIA** (Accessible Rich Internet Applications)
- **WAI** (Web Accessibility Initiative)
- **AODA** (Accessibility for Ontarians with Disabilities Act)

### Suporte a Leitores de Tela

Testado e compatível com:
- **NVDA** (Windows) - Gratuito, open-source
- **JAWS** (Windows)
- **VoiceOver** (macOS, iOS)
- **TalkBack** (Android)
- **Narrator** (Windows)

### Media Queries Suportadas

CompendioCalc respeita as preferências do sistema:

```css
@media (prefers-color-scheme: dark) { }    /* Modo escuro */
@media (prefers-color-scheme: light) { }   /* Modo claro */
@media (prefers-contrast: more) { }        /* Alto contraste */
@media (prefers-reduced-motion: reduce) {} /* Menos movimento */
```

## 💡 Dicas Úteis

### Para Usuários Novos
1. Comece com um preset que se adeque à sua necessidade
2. Ajuste configurações individuais conforme necessário
3. Use `Alt + H` para aprender atalhos de teclado
4. Salve suas preferências (feito automaticamente)

### Para Poder de Fogo
1. Combine múltiplas configurações para sua necessidade específica
2. Use atalhos de teclado para maior produtividade
3. Customize o Tempo Limite conforme sua velocidade de resposta
4. Explore todas as opções na Páginas de Acessibilidade

### Para Assistentes Técnicos
1. Sempre comece com presets (menos risco de configuração errada)
2. Combine Alto Contraste + Modo Escuro para melhor visibilidade
3. Use Leitor de Tela + Modo Simplificado para melhores resultados
4. Teste com leitores de tela reais (NVDA é gratuito)

## 📞 Suporte

Se tiver problemas ou sugestões de acessibilidade:
1. Abra a Página de Acessibilidade (`Alt + Shift + A`)
2. Procure a opção relevante na sua categoria
3. Teste diferentes combinações de configurações

## 📚 Recursos Adicionais

- **WCAG 2.1**: https://www.w3.org/WAI/WCAG21/quickref/
- **ARIA Practices**: https://www.w3.org/WAI/ARIA/apg/
- **NVDA (Leitor de Tela Gratuito)**: https://www.nvaccess.org/
- **Color Contrast Analyzer**: https://www.tpgi.com/color-contrast-checker/

---

**CompendioCalc** - Matemática sem barreiras ♿
