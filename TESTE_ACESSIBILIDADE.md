# 🧪 GUIA DE TESTE - Sistema de Acessibilidade

## ✅ Como Testar se a Acessibilidade Está Funcionando

### Método 1: Teste Visual Direto (MAIS FÁCIL)

1. **Execute o aplicativo:**
   ```bash
   dotnet run -f net10.0-windows10.0.19041.0
   ```

2. **Teste o botão de tema:**
   - Olhe no canto superior direito da tela
   - Você verá um botão com ☀️ (sol) ou 🌙 (lua)
   - **Clique nele**
   
3. **O que DEVE acontecer:**
   - ✅ O fundo da tela muda IMEDIATAMENTE
   - ✅ Modo escuro (padrão): fundo quase preto (#0D1117)
   - ✅ Modo claro: fundo branco (#FFFFFF)
   - ✅ O ícone do botão muda (sol ↔ lua)
   - ✅ Uma notificação dourada aparece embaixo: "Modo claro ativado" ou "Modo escuro ativado"

4. **Se NÃO funcionar:**
   - Significa que o JavaScript não está aplicando as classes ao `<body>`
   - Continue para o Método 2 (Debug)

### Método 2: Teste das Configurações Completas

1. **Abra as configurações de acessibilidade:**
   - Clique no botão ♿ no canto superior direito
   - OU pressione `Alt + Shift + A` no teclado

2. **Teste os Presets:**
   - Clique em "👁️ Visão"
   - **O que DEVE acontecer:**
     - ✅ Texto fica MAIOR (150%)
     - ✅ Contraste aumenta
     - ✅ Cores ficam mais fortes
     - ✅ Notificação amarela aparece

3. **Teste o tamanho de fonte:**
   - Clique nos botões: 100%, 125%, 150%, 175%, 200%
   - **O que DEVE acontecer:**
     - ✅ TODO o texto do app aumenta proporcionalmente
     - ✅ Botão clicado fica dourado (ativo)
     - ✅ Notificação mostra "Tamanho de fonte: X%"

4. **Teste o alto contraste:**
   - Ative a caixa "Alto Contraste"
   - **O que DEVE acontecer:**
     - ✅ Bordas ficam mais grossas
     - ✅ Cores ficam mais saturadas
     - ✅ Diferença entre elementos aumenta

### Método 3: Debug com DevTools (Para Desenvolvedores)

#### A. Verificar se o JavaScript está carregado

1. **Abra o DevTools:**
   - No aplicativo, pressione `F12` (se disponível no MAUI)
   - OU use inspeção remota: https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview?view=net-maui-8.0#enable-debugging

2. **No console JavaScript, execute:**
   ```javascript
   window.accessibilityManager
   ```
   
   **Resultado esperado:**
   ```javascript
   {
     isReady: ƒ (),
     applyClasses: ƒ (),
     applyFontSize: ƒ (),
     applyAll: ƒ ()
   }
   ```

3. **Teste manualmente:**
   ```javascript
   window.accessibilityManager.applyAll("dark-mode high-contrast", 150)
   ```
   
   **Resultado esperado:**
   - ✅ Fundo fica escuro
   - ✅ Contraste aumenta
   - ✅ Fonte fica maior
   - ✅ Console mostra logs: `[Accessibility] ========== APPLY ALL ==========`

#### B. Verificar classes CSS no body

1. **No console JavaScript:**
   ```javascript
   document.body.className
   ```
   
   **Resultado esperado (modo escuro padrão):**
   ```
   "dark-mode"
   ```

2. **Após clicar no botão de tema:**
   ```javascript
   document.body.className
   ```
   
   **Resultado esperado (modo claro):**
   ```
   "light-mode"
   ```

3. **Com alto contraste ativado:**
   ```javascript
   document.body.className
   ```
   
   **Resultado esperado:**
   ```
   "dark-mode high-contrast"
   ```

#### C. Verificar tamanho de fonte

1. **No console JavaScript:**
   ```javascript
   document.body.style.fontSize
   ```
   
   **Resultado esperado (100%):**
   ```
   "16px"
   ```

2. **Após mudar para 150%:**
   ```javascript
   document.body.style.fontSize
   ```
   
   **Resultado esperado:**
   ```
   "24px"
   ```

#### D. Verificar logs do C#

Como o MAUI Blazor não mostra logs no console padrão, procure por:

- **Visual Studio**: janela "Output" → filtro "Debug"
- **Rider**: janela "Run" → aba "Console"
- **VS Code**: Terminal de debug (se configurado)

**Logs esperados:**
```
[Accessibility] Inicializando accessibility-manager.js
[Accessibility] window.accessibilityManager criado e pronto!
[Accessibility] DOM já está pronto
[Accessibility] dark-mode aplicado imediatamente
[Accessibility] JavaScript pronto! Aplicando configurações...
[Accessibility] ===== APLICANDO CONFIGURAÇÕES =====
[Accessibility] Classes: dark-mode
[Accessibility] FontSize: 100%
[Accessibility] Configurações aplicadas com sucesso!
```

### Método 4: Teste com Inspetor de Elementos

1. **Se o DevTools estiver disponível:**
   - Clique com botão direito em qualquer lugar do app
   - Selecione "Inspecionar elemento" (se disponível)

2. **Encontre o elemento `<body>`:**
   ```html
   <body class="dark-mode">
     ...
   </body>
   ```

3. **Após clicar no botão de tema, deve mudar para:**
   ```html
   <body class="light-mode" style="font-size: 16px;">
     ...
   </body>
   ```

## 🐛 Problemas Comuns e Soluções

### Problema 1: Nada acontece ao clicar no botão de tema

**Causa provável:** JavaScript não está carregado ou há erro silencioso

**Solução:**
1. Verifique se os arquivos JS existem:
   ```
   wwwroot/js/accessibility-manager.js
   wwwroot/js/accessibility.js
   ```

2. Verifique se estão carregados no `index.html`:
   ```html
   <script src="js/accessibility-manager.js"></script>
   <script src="js/accessibility.js"></script>
   ```

3. Recompile o projeto:
   ```bash
   dotnet clean
   dotnet build -f net10.0-windows10.0.19041.0
   ```

### Problema 2: Tema muda mas fonte não

**Causa provável:** `applyFontSize()` não está sendo executado

**Solução:**
1. Verifique no console JavaScript:
   ```javascript
   window.accessibilityManager.applyFontSize(150)
   ```

2. Verifique se `document.body.style.fontSize` está sendo setado

### Problema 3: Notificações não aparecem

**Causa provável:** `AccessibilityNotification` component não está no MainLayout

**Solução:**
1. Verifique `Components/Layout/MainLayout.razor`:
   ```razor
   <AccessibilityRenderer />
   <AccessibilityNotification />
   ```

2. Recompile e rode novamente

### Problema 4: Configurações não persistem ao fechar o app

**Causa provável:** Arquivo JSON não está sendo salvo

**Solução:**
1. Verifique se a pasta existe:
   ```
   %LOCALAPPDATA%\CompendioCalc\
   ```

2. Procure pelo arquivo:
   ```
   accessibility_settings.json
   ```

3. Se não existir, verifique permissões de escrita

## 📊 Checklist de Funcionalidades

Marque cada item após testar:

### Tema e Cores
- [ ] Botão sol/lua visível no canto superior direito
- [ ] Clicar no botão muda o tema imediatamente
- [ ] Fundo muda de escuro para claro (ou vice-versa)
- [ ] Ícone do botão muda (sol ↔ lua)
- [ ] Notificação aparece: "Modo claro/escuro ativado"

### Tamanho de Fonte
- [ ] Botões 100% - 200% estão visíveis
- [ ] Clicar em qualquer botão muda o tamanho do texto
- [ ] Botão ativo fica dourado
- [ ] Notificação mostra: "Tamanho de fonte: X%"
- [ ] Todo o texto do app aumenta proporcionalmente

### Alto Contraste
- [ ] Checkbox "Alto Contraste" funciona
- [ ] Ativ ar aumenta contraste visual
- [ ] Bordas ficam mais grossas
- [ ] Cores ficam mais saturadas

### Presets
- [ ] 5 botões de preset visíveis (Visão, Audição, Motora, Cognitiva, Dislexia)
- [ ] Clicar em qualquer preset aplica múltiplas configurações
- [ ] Preset ativo fica destacado em dourado
- [ ] Notificação aparece ao aplicar preset

### Notificações
- [ ] Notificação aparece na parte inferior da tela
- [ ] Fundo dourado, texto escuro, ícone de check ✓
- [ ] Auto-oculta após 3 segundos
- [ ] Animação suave de entrada/saída

### Persistência
- [ ] Fechar e abrir o app mantém as configurações
- [ ] Arquivo JSON é criado em %LOCALAPPDATA%\CompendioCalc\
- [ ] Botão "Restaurar Padrões" reseta tudo

## 🎯 Teste de Aceitação Final

**Execute este teste completo:**

1. Abra o app → fundo DEVE ser escuro
2. Clique no botão ☀️ → fundo DEVE mudar para claro
3. Clique no botão ♿ → abre configurações
4. Clique em "👁️ Visão" → texto DEVE ficar maior + contraste alto
5. Clique em 200% → texto DEVE ficar MUITO maior
6. Ative "Alto Contraste" → bordas DEVEM ficar grossas
7. Feche o app
8. Abra novamente → configurações DEVEM estar mantidas
9. Clique em "🔄 Restaurar Padrões" → tudo DEVE voltar ao normal

**Se TODOS os itens funcionarem: ✅ Sistema 100% operacional!**

**Se ALGUM item falhar: 🐛 Continue debugando com este guia**

## 📞 Suporte Adicional

Se nada funcionar após seguir este guia:

1. **Verifique versões:**
   ```bash
   dotnet --version  # Deve ser .NET 10
   ```

2. **Limpe e recompile:**
   ```bash
   dotnet clean
   dotnet build -f net10.0-windows10.0.19041.0
   ```

3. **Delete a pasta bin/obj:**
   ```bash
   rm -rf bin obj
   dotnet build -f net10.0-windows10.0.19041.0
   ```

4. **Verifique se não há erros de compilação:**
   ```bash
   dotnet build -f net10.0-windows10.0.19041.0 /p:TreatWarningsAsErrors=true
   ```

---

**Última atualização:** 2026-03-07
**Versão do guia:** 1.0
**Status esperado:** ✅ TUDO FUNCIONANDO
