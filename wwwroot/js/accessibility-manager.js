// Accessibility Manager - JavaScript Interop
// Aplica configurações de acessibilidade ao documento

window.accessibilityManager = {
    // Aplica classes CSS ao body
    applyClasses: function(classes) {
        const body = document.body;
        
        // Remove todas as classes de acessibilidade antigas
        body.classList.remove(
            'high-contrast', 'dark-mode', 'light-mode', 'reduce-motion',
            'larger-buttons', 'simplified-mode', 'keyboard-only', 'enhanced-contrast'
        );
        
        // Aplica novas classes
        if (classes) {
            const classList = classes.split(' ').filter(c => c.trim());
            classList.forEach(className => {
                body.classList.add(className);
            });
        }
    },
    
    // Aplica estilos CSS customizados
    applyStyles: function(styles) {
        const body = document.body;
        
        // Parse estilos como "font-size: 16px; color: red"
        if (styles) {
            const styleObj = {};
            styles.split(';').forEach(style => {
                const [key, value] = style.split(':').map(s => s.trim());
                if (key && value) {
                    styleObj[key] = value;
                }
            });
            
            // Aplica cada estilo
            Object.keys(styleObj).forEach(key => {
                body.style.setProperty(key, styleObj[key]);
            });
        }
    },
    
    // Aplica tamanho de fonte
    applyFontSize: function(percentage) {
        const body = document.body;
        const baseFontSize = 16; // 16px base
        const newSize = (baseFontSize * percentage) / 100;
        body.style.fontSize = `${newSize}px`;
    },
    
    // Aplica todas as configurações de uma vez
    applyAll: function(classes, fontSizePercentage) {
        this.applyClasses(classes);
        this.applyFontSize(fontSizePercentage);
    }
};
