/**
 * Accessibility Shortcuts JavaScript
 * Adiciona atalhos de teclado e melhorias de acessibilidade
 */

// Atalho: Alt+Shift+A para abrir acessibilidade
document.addEventListener('keydown', function(event) {
    // Alt + Shift + A
    if (event.altKey && event.shiftKey && event.key === 'A') {
        event.preventDefault();
        // Navega para página de acessibilidade
        window.location.href = '/acessibilidade';
    }

    // Alt+1 para Início
    else if (event.altKey && event.key === '1') {
        event.preventDefault();
        window.location.href = '/';
    }

    // Alt+2 para Categorias
    else if (event.altKey && event.key === '2') {
        event.preventDefault();
        window.location.href = '/categorias';
    }

    // Alt+3 para Buscar
    else if (event.altKey && event.key === '3') {
        event.preventDefault();
        window.location.href = '/buscar';
    }

    // Alt+4 para Favoritos
    else if (event.altKey && event.key === '4') {
        event.preventDefault();
        window.location.href = '/favoritos';
    }

    // Alt+5 para Histórico
    else if (event.altKey && event.key === '5') {
        event.preventDefault();
        window.location.href = '/historico';
    }

    // Alt+H para mostrar ajuda
    else if (event.altKey && event.key === 'H') {
        event.preventDefault();
        showAccessibilityHelp();
    }
});

/**
 * Mostra uma caixa de diálogo com atalhos de teclado disponíveis
 */
function showAccessibilityHelp() {
    const help = `
╔════════════════════════════════════════════════════════════╗
║          ATALHOS DE TECLADO - COMPÊNDIO CALC               ║
╠════════════════════════════════════════════════════════════╣
║ Alt + Shift + A    👉 Abrir Configurações de Acessibilidade║
║ Alt + 1            👉 Ir para Tela Inicial                 ║
║ Alt + 2            👉 Ir para Categorias                   ║
║ Alt + 3            👉 Ir para Buscar                       ║
║ Alt + 4            👉 Ir para Favoritos                    ║
║ Alt + 5            👉 Ir para Histórico                    ║
║ Alt + H            👉 Mostrar Esta Ajuda                   ║
║ Tab                👉 Navegar entre Botões e Links        ║
║ Enter / Espaço     👉 Ativar Botão Focado                 ║
║ Setas              👉 Navegar em Menus (se habilitado)    ║
╠════════════════════════════════════════════════════════════╣
║ CONFIGURAÇÕES DE ACESSIBILIDADE DISPONÍVEIS:              ║
║ • Alto Contraste e Modo Escuro                            ║
║ • Aumento de Tamanho de Fonte (até 200%)                  ║
║ • Leitor de Tela (Screen Reader)                          ║
║ • Redução de Movimentos e Animações                       ║
║ • Botões Maiores para Fácil Clique                        ║
║ • Navegação Simplificada                                   ║
║ • Modo Simplificado para Menos Distrações                 ║
║ • Feedback Visual para Deficientes Auditivos              ║
╚════════════════════════════════════════════════════════════╝
    `;
    alert(help);
}

/**
 * Carrega as configurações de acessibilidade e aplica ao documento
 */
function loadAccessibilitySettings() {
    try {
        const settingsJson = localStorage.getItem('accessibility_settings');
        if (settingsJson) {
            const settings = JSON.parse(settingsJson);
            applyAccessibilitySettings(settings);
        }
    } catch (e) {
        console.warn('Erro ao carregar configurações de acessibilidade:', e);
    }
}

/**
 * Aplica as configurações de acessibilidade ao documento
 * @param {Object} settings - Objeto com as configurações
 */
function applyAccessibilitySettings(settings) {
    // Aplicar classes CSS
    const body = document.body;
    
    // Remover classes anteriores
    body.classList.remove(
        'high-contrast', 'dark-mode', 'light-mode', 'reduce-motion',
        'larger-buttons', 'simplified-mode', 'keyboard-only', 'enhanced-contrast'
    );

    // Aplicar novas classes
    if (settings.highContrast) {
        body.classList.add('high-contrast');
    }

    if (settings.darkMode) {
        body.classList.add('dark-mode');
    } else {
        body.classList.add('light-mode');
    }

    if (settings.reduceMotion) {
        body.classList.add('reduce-motion');
    }

    if (settings.largerButtons) {
        body.classList.add('larger-buttons');
    }

    if (settings.simplifiedMode) {
        body.classList.add('simplified-mode');
    }

    if (settings.enhancedContrast && settings.highContrast) {
        body.classList.add('enhanced-contrast');
    }

    if (settings.keyboardNavigationOnly) {
        body.classList.add('keyboard-only');
    }

    // Aplicar escala de fonte
    const fontScale = (settings.fontSizePercentage || 100) / 100;
    document.documentElement.style.setProperty('--font-scale-factor', fontScale);

    // Se leitor de tela está ativo, adicionar atributo
    if (settings.screenReaderEnabled) {
        body.setAttribute('aria-live-polite', 'true');
    }
}

/**
 * Detecta e ativa configurações baseadas em preferências do sistema
 */
function detectSystemPreferences() {
    // Respeitar preferências de contraste
    if (window.matchMedia('(prefers-contrast: more)').matches) {
        document.body.classList.add('high-contrast');
    }

    // Respeitar preferências de esquema de cores
    if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
        document.body.classList.add('dark-mode');
    } else {
        document.body.classList.add('light-mode');
    }

    // Respeitar preferências de movimento reduzido
    if (window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
        document.body.classList.add('reduce-motion');
    }
}

/**
 * Inicializa as melhorias de acessibilidade ao carregar a página
 */
document.addEventListener('DOMContentLoaded', function() {
    detectSystemPreferences();
    loadAccessibilitySettings();

    // Adicionar skip link se não existir
    if (!document.querySelector('.skip-to-main')) {
        const skipLink = document.createElement('a');
        skipLink.href = '#app';
        skipLink.textContent = 'Pular para conteúdo principal';
        skipLink.className = 'skip-to-main';
        skipLink.setAttribute('aria-label', 'Pular para conteúdo principal');
        document.body.insertBefore(skipLink, document.body.firstChild);
    }

    // Melhorar acessibilidade de todos os links
    document.querySelectorAll('a').forEach(link => {
        if (!link.textContent.trim()) {
            link.setAttribute('aria-label', 'Link sem rótulo');
        }
    });

    // Melhorar acessibilidade de botões sem rótulo
    document.querySelectorAll('button').forEach(button => {
        // Se o botão não tem aria-label e não tem texto meaningfulk
        if (!button.getAttribute('aria-label') && !button.textContent.trim()) {
            button.setAttribute('aria-label', 'Botão sem rótulo');
        }
    });
});

/**
 * Monitorar mudanças de tema do sistema em tempo real
 */
window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (e) => {
    if (e.matches) {
        document.body.classList.remove('light-mode');
        document.body.classList.add('dark-mode');
    } else {
        document.body.classList.remove('dark-mode');
        document.body.classList.add('light-mode');
    }
});

/**
 * Monitorar mudanças de preferência de contraste
 */
window.matchMedia('(prefers-contrast: more)').addEventListener('change', (e) => {
    if (e.matches) {
        document.body.classList.add('high-contrast');
    } else {
        document.body.classList.remove('high-contrast');
    }
});

/**
 * Monitorar mudanças de preferência de movimento reduzido
 */
window.matchMedia('(prefers-reduced-motion: reduce)').addEventListener('change', (e) => {
    if (e.matches) {
        document.body.classList.add('reduce-motion');
    } else {
        document.body.classList.remove('reduce-motion');
    }
});

/**
 * Notifica o user sobre mudanças de acessibilidade (para screen readers)
 */
function announceToScreenReader(message) {
    const announcement = document.createElement('div');
    announcement.setAttribute('role', 'status');
    announcement.setAttribute('aria-live', 'polite');
    announcement.setAttribute('aria-atomic', 'true');
    announcement.className = 'sr-only';
    announcement.textContent = message;
    document.body.appendChild(announcement);

    // Remover após 2 segundos
    setTimeout(() => announcement.remove(), 2000);
}
