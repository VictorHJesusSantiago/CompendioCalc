/**
 * Accessibility Shortcuts and Functions JavaScript
 * Adiciona atalhos de teclado e melhorias de acessibilidade
 */

// ========== CORE FUNCTION ==========
/**
 * Aplica as configurações de acessibilidade ao documento
 * Chamado via JSInterop do C#
 */
window.applyAccessibilitySettings = function(settings) {
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

    if (settings.enhancedContrast && settings.highContrast) {
        body.classList.add('enhanced-contrast');
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

    if (settings.keyboardNavigationOnly) {
        body.classList.add('keyboard-only');
    }

    // Aplicar escala de fonte
    const fontScale = (settings.fontSizePercentage || 100) / 100;
    document.documentElement.style.fontSize = `${16 * fontScale}px`;
    document.documentElement.style.setProperty('--font-scale-factor', fontScale);

    // Se leitor de tela está ativo
    if (settings.screenReaderEnabled) {
        body.setAttribute('aria-live', 'polite');
        ensureLiveRegion();
    } else {
        body.removeAttribute('aria-live');
    }

    console.log('✓ Accessibility settings applied:', settings);
};

// ========== VISUAL FEEDBACK  ==========
/**
 * Mostra feedback visual para ação (para deficiência auditiva)
 */
window.showVisualFeedback = function(message, type = 'info') {
    const colors = {
        info: '#74C0FC',
        success: '#51CF66',
        error: '#FF6B6B',
        warning: '#FFA94D'
    };

    const notification = document.createElement('div');
    notification.style.cssText = `
        position: fixed;
        top: 20px;
        left: 50%;
        transform: translateX(-50%) translateY(-20px);
        background: ${colors[type] || colors.info};
        color: white;
        padding: 16px 24px;
        border-radius: 8px;
        font-weight: 600;
        font-size: 16px;
        box-shadow: 0 4px 16px rgba(0,0,0,0.3);
        z-index: 99999;
        opacity: 0;
        transition: all 0.3s ease;
        max-width: 90%;
        text-align: center;
    `;
    notification.textContent = message;
    document.body.appendChild(notification);

    // Animar entrada
    setTimeout(() => {
        notification.style.opacity = '1';
        notification.style.transform = 'translateX(-50%) translateY(0)';
    }, 10);

    // Remover após 3 segundos
    setTimeout(() => {
        notification.style.opacity = '0';
        notification.style.transform = 'translateX(-50%) translateY(-20px)';
        setTimeout(() => {
            if (document.body.contains(notification)) {
                document.body.removeChild(notification);
            }
        }, 300);
    }, 3000);
};

// ========== SCREEN FLASH ALERT ==========
/**
 * Flash de tela para alertas (para deficiência auditiva)
 */
window.screenFlashAlert = function(duration = 300, color = '#FFA94D') {
    const overlay = document.createElement('div');
    overlay.style.cssText = `
        position: fixed;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background: ${color};
        opacity: 0;
        z-index: 99999;
        pointer-events: none;
        transition: opacity 0.1s;
    `;
    document.body.appendChild(overlay);

    // Fade in
    setTimeout(() => {
        overlay.style.opacity = '0.6';
    }, 10);

    // Fade out
    setTimeout(() => {
        overlay.style.opacity = '0';
        setTimeout(() => {
            if (document.body.contains(overlay)) {
                document.body.removeChild(overlay);
            }
        }, 100);
    }, duration / 2);
};

// ========== SCREEN READER ANNOUNCEMENTS ==========
/**
 * Garante que a região ARIA live existe
 */
function ensureLiveRegion() {
    if (!document.getElementById('sr-live-region')) {
        const liveRegion = document.createElement('div');
        liveRegion.id = 'sr-live-region';
        liveRegion.setAttribute('role', 'status');
        liveRegion.setAttribute('aria-live', 'polite');
        liveRegion.setAttribute('aria-atomic', 'true');
        liveRegion.style.cssText = `
            position: absolute;
            left: -10000px;
            width: 1px;
            height: 1px;
            overflow: hidden;
        `;
        document.body.appendChild(liveRegion);
    }
}

/**
 * Anuncia mensagem para leitores de tela
 */
window.announceToScreenReader = function (message) {
    ensureLiveRegion();
    const liveRegion = document.getElementById('sr-live-region');
    if (liveRegion) {
        liveRegion.textContent = message;

        // Limpar após 2 segundos
        setTimeout(() => {
            liveRegion.textContent = '';
        }, 2000);
    }
};

// ========== KEYBOARD SHORTCUTS ==========

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
