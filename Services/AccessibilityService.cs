using System.Text.Json;
using System.Diagnostics;

namespace CompendioCalc.Services;

/// <summary>
/// Serviço de gerenciamento de configurações de acessibilidade
/// Suporta: deficiências visuais, auditivas, motoras e cognitivas
/// </summary>
public class AccessibilityService
{
    private const string StorageKey = "accessibility_settings";
    private AccessibilitySettings _settings;
    private readonly string _storageDirectory;

    public event Action? OnSettingsChanged;

    public AccessibilityService()
    {
        _storageDirectory = FileSystem.AppDataDirectory;
        _settings = LoadSettings();
    }

    /// <summary>
    /// Configurações de acessibilidade
    /// </summary>
    public class AccessibilitySettings
    {
        // ==== DEFICIÊNCIA VISUAL ====
        /// <summary>Aumenta tamanho de todas as fontes (em porcentagem: 100, 125, 150, 175, 200)</summary>
        public int FontSizePercentage { get; set; } = 100;

        /// <summary>Ativa modo de alto contraste</summary>
        public bool HighContrast { get; set; } = false;

        /// <summary>Ativa modo escuro</summary>
        public bool DarkMode { get; set; } = false;

        /// <summary>Remove animações e transições (melhor para pessoas com sensibilidade a movimento)</summary>
        public bool ReduceMotion { get; set; } = false;

        /// <summary>Enable screen reader support</summary>
        public bool ScreenReaderEnabled { get; set; } = false;

        /// <summary>Aumenta contraste das cores (adicional ao tema high-contrast)</summary>
        public bool EnhancedContrast { get; set; } = false;

        // ==== DEFICIÊNCIA AUDITIVA ====
        /// <summary>Mostra legendas/avisos visuais para feedback sonoro</summary>
        public bool VisualFeedback { get; set; } = true;

        /// <summary>Pisca a tela em vez de usar som para alertas</summary>
        public bool ScreenFlashAlerts { get; set; } = false;

        /// <summary>Mostra transcrições de áudio/legendas</summary>
        public bool CaptionsEnabled { get; set; } = true;

        // ==== DEFICIÊNCIA MOTORA ====
        /// <summary>Aumenta tamanho dos botões e áreas clicáveis</summary>
        public bool LargerButtons { get; set; } = false;

        /// <summary>Reduz a necessidade de gestos complexos</summary>
        public bool SimplifiedGestures { get; set; } = false;

        /// <summary>Permite navegação apenas por teclado</summary>
        public bool KeyboardNavigationOnly { get; set; } = false;

        /// <summary>Aumenta o tempo limite para interações</summary>
        public int InteractionTimeoutSeconds { get; set; } = 5;

        // ==== DEFICIÊNCIA COGNITIVA ====
        /// <summary>Modo simplificado com menos opções na tela</summary>
        public bool SimplifiedMode { get; set; } = false;

        /// <summary>Mostra instruções passo a passo</summary>
        public bool ShowStepByStepInstructions { get; set; } = false;

        /// <summary>Desabilita notificações automáticas</summary>
        public bool ReduceNotifications { get; set; } = false;

        /// <summary>Usa linguagem mais simples</summary>
        public bool SimplifiedLanguage { get; set; } = false;

        // ==== CONFIGURAÇÕES GERAIS ====
        /// <summary>Prefixo padrão para anúncios de leitura de tela</summary>
        public string ScreenReaderAnnouncementPrefix { get; set; } = "Compêndio Calc:";

        /// <summary>Mostra dicas contextuais e tutoriais</summary>
        public bool ShowHints { get; set; } = true;
    }

    public AccessibilitySettings CurrentSettings => _settings;

    public void UpdateSettings(AccessibilitySettings settings)
    {
        _settings = settings;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void SetFontSize(int percentage)
    {
        if (percentage is >= 100 and <= 200)
        {
            _settings.FontSizePercentage = percentage;
            SaveSettings();
            OnSettingsChanged?.Invoke();
        }
    }

    public void SetHighContrast(bool enabled)
    {
        _settings.HighContrast = enabled;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void SetDarkMode(bool enabled)
    {
        _settings.DarkMode = enabled;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void SetReduceMotion(bool enabled)
    {
        _settings.ReduceMotion = enabled;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void SetScreenReaderEnabled(bool enabled)
    {
        _settings.ScreenReaderEnabled = enabled;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void SetVisualFeedback(bool enabled)
    {
        _settings.VisualFeedback = enabled;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void SetLargerButtons(bool enabled)
    {
        _settings.LargerButtons = enabled;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void SetSimplifiedMode(bool enabled)
    {
        _settings.SimplifiedMode = enabled;
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    public void ResetToDefaults()
    {
        _settings = new AccessibilitySettings();
        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    /// <summary>Aplica preset de configurações rápidas</summary>
    public void ApplyPreset(AccessibilityPreset preset)
    {
        _settings = preset switch
        {
            AccessibilityPreset.VisualImpairment => new AccessibilitySettings
            {
                FontSizePercentage = 150,
                HighContrast = true,
                DarkMode = true,
                ReduceMotion = true,
                ScreenReaderEnabled = true,
                EnhancedContrast = true,
                SimplifiedMode = true,
                ShowStepByStepInstructions = true
            },
            AccessibilityPreset.HearingImpairment => new AccessibilitySettings
            {
                VisualFeedback = true,
                CaptionsEnabled = true,
                ScreenFlashAlerts = true,
                ReduceNotifications = false,
                ShowHints = true
            },
            AccessibilityPreset.MotorImpairment => new AccessibilitySettings
            {
                LargerButtons = true,
                SimplifiedGestures = true,
                KeyboardNavigationOnly = true,
                InteractionTimeoutSeconds = 10,
                ReduceMotion = true,
                FontSizePercentage = 125
            },
            AccessibilityPreset.CognitiveImpairment => new AccessibilitySettings
            {
                SimplifiedMode = true,
                ShowStepByStepInstructions = true,
                SimplifiedLanguage = true,
                ReduceNotifications = true,
                ReduceMotion = true,
                FontSizePercentage = 125,
                ShowHints = true
            },
            AccessibilityPreset.Dyslexia => new AccessibilitySettings
            {
                FontSizePercentage = 125,
                HighContrast = true,
                ReduceMotion = true,
                SimplifiedMode = false,
                ShowHints = true
            },
            _ => new AccessibilitySettings()
        };

        SaveSettings();
        OnSettingsChanged?.Invoke();
    }

    private void SaveSettings()
    {
        try
        {
            var filePath = Path.Combine(_storageDirectory, $"{StorageKey}.json");
            var json = JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao salvar configurações de acessibilidade: {ex.Message}");
        }
    }

    private AccessibilitySettings LoadSettings()
    {
        try
        {
            var filePath = Path.Combine(_storageDirectory, $"{StorageKey}.json");
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var settings = JsonSerializer.Deserialize<AccessibilitySettings>(json) ?? new AccessibilitySettings();
                
                // Força dark mode desligado (correção temporária)
                settings.DarkMode = false;
                
                return settings;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao carregar configurações de acessibilidade: {ex.Message}");
        }

        return new AccessibilitySettings();
    }

    /// <summary>Obtém classe CSS baseado nas configurações atuais</summary>
    public string GetAccessibilityCssClass()
    {
        var classes = new List<string>();

        if (_settings.HighContrast)
            classes.Add("high-contrast");

        if (_settings.DarkMode)
            classes.Add("dark-mode");
        else
            classes.Add("light-mode");

        if (_settings.ReduceMotion)
            classes.Add("reduce-motion");

        if (_settings.LargerButtons)
            classes.Add("larger-buttons");

        if (_settings.SimplifiedMode)
            classes.Add("simplified-mode");

        if (_settings.EnhancedContrast)
            classes.Add("enhanced-contrast");

        if (_settings.KeyboardNavigationOnly)
            classes.Add("keyboard-only");

        return string.Join(" ", classes);
    }

    /// <summary>Obtém estilo CSS inline baseado nas configurações</summary>
    public string GetAccessibilityStyles()
    {
        var fontSize = (_settings.FontSizePercentage / 100.0).ToString("F2");
        return $"font-size-scale: {fontSize};";
    }
}

/// <summary>Presets de configurações rápidas para diferentes deficiências</summary>
public enum AccessibilityPreset
{
    None,
    VisualImpairment,
    HearingImpairment,
    MotorImpairment,
    CognitiveImpairment,
    Dyslexia
}
