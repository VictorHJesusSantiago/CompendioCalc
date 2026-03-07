// Accessibility Manager - JavaScript Interop for MAUI Blazor
// Aplica configuraç ões de acessibilidade ao documento

(function() {
    console.log('[Accessibility] Inicializando accessibility-manager.js');
    
    window.accessibilityManager = {
        // Verifica se o manager está pronto
        isReady: function() {
            return true;
        },
        
        // Aplica classes CSS ao body
        applyClasses: function(classes) {
            console.log('[Accessibility] applyClasses chamado com:', classes);
            const body = document.body;
            
            if (!body) {
                console.error('[Accessibility] document.body não encontrado!');
                return;
            }
            
            // Remove todas as classes de acessibilidade antigas
            const oldClasses = ['high-contrast', 'dark-mode', 'light-mode', 'reduce-motion',
                'larger-buttons', 'simplified-mode', 'keyboard-only', 'enhanced-contrast'];
            
            oldClasses.forEach(cls => body.classList.remove(cls));
            console.log('[Accessibility] Classes antigas removidas');
            
            // Aplica novas classes
            if (classes && classes.trim()) {
                const classList = classes.split(' ').filter(c => c.trim());
                classList.forEach(className => {
                    body.classList.add(className);
                    console.log('[Accessibility] Classe adicionada ao body:', className);
                });
            }
            
            console.log('[Accessibility] Classes finais no body:', Array.from(body.classList).join(' '));
        },
        
        // Aplica tamanho de fonte
        applyFontSize: function(percentage) {
            console.log('[Accessibility] applyFontSize chamado com:', percentage);
            const body = document.body;
            
            if (!body) {
                console.error('[Accessibility] document.body não encontrado!');
                return;
            }
            
            const baseFontSize = 16; // 16px base
            const newSize = (baseFontSize * percentage) / 100;
            body.style.fontSize = `${newSize}px`;
            console.log('[Accessibility] Font-size aplicado ao body:', newSize + 'px');
        },
        
        // Aplica todas as configurações de uma vez
        applyAll: function(classes, fontSizePercentage) {
            console.log('[Accessibility] ========== APPLY ALL ==========');
            console.log('[Accessibility] Classes:', classes);
            console.log('[Accessibility] FontSize:', fontSizePercentage + '%');
            
            try {
                this.applyClasses(classes);
                this.applyFontSize(fontSizePercentage);
                console.log('[Accessibility] ========== APLICAÇÃO CONCLUÍDA ==========');
                return true;
            } catch (error) {
                console.error('[Accessibility] ERRO ao aplicar:', error);
                return false;
            }
        }
    };
    
    console.log('[Accessibility] window.accessibilityManager criado e pronto!');
    console.log('[Accessibility] Testando acesso ao body:', document.body ? 'OK' : 'FALHOU');
    
    // Aplica dark-mode inicial quando DOM estiver pronto
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', function() {
            console.log('[Accessibility] DOM carregado via DOMContentLoaded');
            if (document.body) {
                document.body.classList.add('dark-mode');
                console.log('[Accessibility] dark-mode aplicado no DOMContentLoaded');
            }
        });
    } else {
        console.log('[Accessibility] DOM já está pronto');
        if (document.body) {
            document.body.classList.add('dark-mode');
            console.log('[Accessibility] dark-mode aplicado imediatamente');
        } else {
            setTimeout(function() {
                if (document.body) {
                    document.body.classList.add('dark-mode');
                    console.log('[Accessibility] dark-mode aplicado após timeout');
                }
            }, 100);
        }
    }
})();

// Exporta para debug no console
console.log('[Accessibility] Para testar, execute no console: window.accessibilityManager.applyAll("dark-mode high-contrast", 150)');
