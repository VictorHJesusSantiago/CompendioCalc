using Microsoft.Extensions.Logging;
using CompendioCalc.Services;

namespace CompendioCalc;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<FormulaService>();
        builder.Services.AddSingleton<AccessibilityService>();
        builder.Services.AddSingleton<OfflineMathService>();
        builder.Services.AddSingleton<AdvancedNumericsService>();
        builder.Services.AddSingleton<LinearAlgebraService>();
        builder.Services.AddSingleton<SymbolicMathService>();
        builder.Services.AddSingleton<OfflineChartService>();
        builder.Services.AddSingleton<MathematicalRecognitionService>();
        builder.Services.AddSingleton<LocalSpeechService>();
        builder.Services.AddSingleton<UnitConversionService>();
        builder.Services.AddSingleton<BibliographyService>();
        builder.Services.AddSingleton<CatalogHealthService>();
        builder.Services.AddSingleton<AdvancedSearchService>();
        builder.Services.AddSingleton<OfflineExportService>();
        builder.Services.AddSingleton<OfflineBackupService>();
        builder.Services.AddSingleton<OfflinePackService>();
        builder.Services.AddSingleton<LocalAssistantService>();
        builder.Services.AddSingleton<OfflineDiagnosticService>();
        builder.Services.AddSingleton<EducationService>(sp =>
        {
            var service = new EducationService();
            service.Load();
            return service;
        });
        builder.Services.AddSingleton<PersonalDataService>(sp =>
        {
            var service = new PersonalDataService();
            service.Load();
            return service;
        });
        builder.Services.AddSingleton<CalculadoraService>(sp =>
        {
            var calc = new CalculadoraService();
            calc.CarregarHistorico();
            return calc;
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
