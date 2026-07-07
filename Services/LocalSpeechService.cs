using Microsoft.Maui.Media;

namespace CompendioCalc.Services;

public sealed record LocalVoice(string Name, string Language, string Country, string Id);

public sealed class LocalSpeechService
{
    private CancellationTokenSource? _currentSpeech;
    public async Task<IReadOnlyList<LocalVoice>> GetInstalledVoicesAsync()
    {
        var locales = await TextToSpeech.Default.GetLocalesAsync();
        return locales.Select(locale => new LocalVoice(
            locale.Name ?? locale.Language,
            locale.Language,
            locale.Country ?? "",
            locale.Id ?? $"{locale.Language}-{locale.Country}")).ToArray();
    }

    public async Task SpeakAsync(
        string text,
        string? localeId = null,
        float rate = 1,
        float pitch = 1,
        float volume = 1,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(text)) return;
        Stop();
        var speech = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _currentSpeech = speech;
        var locales = await TextToSpeech.Default.GetLocalesAsync();
        var locale = string.IsNullOrWhiteSpace(localeId)
            ? locales.FirstOrDefault(item => item.Language.StartsWith("pt", StringComparison.OrdinalIgnoreCase))
              ?? locales.FirstOrDefault()
            : locales.FirstOrDefault(item => item.Id == localeId);
        var options = new SpeechOptions
        {
            Locale = locale,
            Pitch = Math.Clamp(pitch, 0, 2),
            Rate = Math.Clamp(rate, 0, 2),
            Volume = Math.Clamp(volume, 0, 1)
        };
        try
        {
            await TextToSpeech.Default.SpeakAsync(text, options, speech.Token);
        }
        finally
        {
            speech.Dispose();
            if (ReferenceEquals(_currentSpeech, speech)) _currentSpeech = null;
        }
    }

    public void Stop()
    {
        _currentSpeech?.Cancel();
        _currentSpeech?.Dispose();
        _currentSpeech = null;
    }

    public static string MathToSpeech(string expression) => expression
        .Replace("√", " raiz quadrada de ")
        .Replace("∑", " somatório de ")
        .Replace("∫", " integral de ")
        .Replace("π", " pi ")
        .Replace("∞", " infinito ")
        .Replace("≤", " menor ou igual a ")
        .Replace("≥", " maior ou igual a ")
        .Replace("≠", " diferente de ")
        .Replace("^2", " ao quadrado ")
        .Replace("^3", " ao cubo ")
        .Replace("*", " vezes ")
        .Replace("/", " dividido por ")
        .Replace("+", " mais ")
        .Replace("-", " menos ")
        .Replace("=", " igual a ");
}
