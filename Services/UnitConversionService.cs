namespace CompendioCalc.Services;

public sealed record UnitDefinition(
    string Symbol,
    string Name,
    string Dimension,
    double ScaleToBase,
    double OffsetToBase = 0,
    IReadOnlyList<string>? Aliases = null);

public sealed record ConversionResult(
    double Input,
    string From,
    double Output,
    string To,
    IReadOnlyList<string> Steps);

/// <summary>Conversor dimensional offline com unidades lineares e afins.</summary>
public sealed class UnitConversionService
{
    private readonly Dictionary<string, UnitDefinition> _units =
        new(StringComparer.OrdinalIgnoreCase);

    public UnitConversionService()
    {
        AddDefaults();
    }

    public IReadOnlyCollection<UnitDefinition> Units =>
        _units.Values.DistinctBy(unit => unit.Symbol).OrderBy(unit => unit.Dimension).ThenBy(unit => unit.Symbol).ToArray();

    public void Register(UnitDefinition unit)
    {
        if (string.IsNullOrWhiteSpace(unit.Symbol) || string.IsNullOrWhiteSpace(unit.Dimension))
            throw new ArgumentException("Símbolo e dimensão são obrigatórios.");
        if (!double.IsFinite(unit.ScaleToBase) || unit.ScaleToBase == 0)
            throw new ArgumentException("Escala inválida.");
        _units[unit.Symbol] = unit;
        _units[unit.Name] = unit;
        foreach (var alias in unit.Aliases ?? [])
            _units[alias] = unit;
    }

    public bool AreCompatible(string first, string second) =>
        TryGet(first, out var a) && TryGet(second, out var b) &&
        a.Dimension.Equals(b.Dimension, StringComparison.OrdinalIgnoreCase);

    public ConversionResult Convert(double value, string from, string to)
    {
        var source = Get(from);
        var target = Get(to);
        if (!source.Dimension.Equals(target.Dimension, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException(
                $"Unidades incompatíveis: {source.Symbol} ({source.Dimension}) e {target.Symbol} ({target.Dimension}).");
        var baseValue = (value + source.OffsetToBase) * source.ScaleToBase;
        var result = baseValue / target.ScaleToBase - target.OffsetToBase;
        if (!double.IsFinite(result)) throw new ArithmeticException("Conversão produziu valor não finito.");
        return new(value, source.Symbol, result, target.Symbol,
        [
            $"Converter {source.Symbol} para a unidade-base de {source.Dimension}",
            $"valor-base = ({value:G17} + {source.OffsetToBase:G17}) × {source.ScaleToBase:G17} = {baseValue:G17}",
            $"resultado = {baseValue:G17} ÷ {target.ScaleToBase:G17} − {target.OffsetToBase:G17} = {result:G17} {target.Symbol}"
        ]);
    }

    public IReadOnlyList<UnitDefinition> Search(string query) =>
        Units.Where(unit =>
            unit.Symbol.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            unit.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            unit.Dimension.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            (unit.Aliases?.Any(alias => alias.Contains(query, StringComparison.OrdinalIgnoreCase)) ?? false))
        .ToArray();

    private bool TryGet(string key, out UnitDefinition unit) =>
        _units.TryGetValue(key.Trim(), out unit!);

    private UnitDefinition Get(string key) =>
        TryGet(key, out var unit) ? unit : throw new KeyNotFoundException($"Unidade desconhecida: {key}");

    private void AddDefaults()
    {
        Register(new("m", "metro", "comprimento", 1, Aliases: ["metros"]));
        Register(new("km", "quilômetro", "comprimento", 1000));
        Register(new("cm", "centímetro", "comprimento", 0.01));
        Register(new("mm", "milímetro", "comprimento", 0.001));
        Register(new("µm", "micrômetro", "comprimento", 1e-6, Aliases: ["um"]));
        Register(new("nm", "nanômetro", "comprimento", 1e-9));
        Register(new("in", "polegada", "comprimento", 0.0254, Aliases: ["pol"]));
        Register(new("ft", "pé", "comprimento", 0.3048));
        Register(new("yd", "jarda", "comprimento", 0.9144));
        Register(new("mi", "milha", "comprimento", 1609.344));
        Register(new("nmi", "milha náutica", "comprimento", 1852));
        Register(new("au", "unidade astronômica", "comprimento", 149_597_870_700));
        Register(new("ly", "ano-luz", "comprimento", 9.4607304725808e15));
        Register(new("pc", "parsec", "comprimento", 3.0856775814913673e16));

        Register(new("kg", "quilograma", "massa", 1));
        Register(new("g", "grama", "massa", 0.001));
        Register(new("mg", "miligrama", "massa", 1e-6));
        Register(new("µg", "micrograma", "massa", 1e-9, Aliases: ["ug"]));
        Register(new("lb", "libra", "massa", 0.45359237));
        Register(new("oz", "onça", "massa", 0.028349523125));
        Register(new("t", "tonelada", "massa", 1000));

        Register(new("s", "segundo", "tempo", 1));
        Register(new("ms", "milissegundo", "tempo", 0.001));
        Register(new("min", "minuto", "tempo", 60));
        Register(new("h", "hora", "tempo", 3600));
        Register(new("d", "dia", "tempo", 86400));
        Register(new("ano", "ano juliano", "tempo", 31_557_600));

        Register(new("K", "kelvin", "temperatura", 1));
        Register(new("°C", "grau Celsius", "temperatura", 1, 273.15, ["C", "celsius"]));
        Register(new("°F", "grau Fahrenheit", "temperatura", 5d / 9d, 459.67, ["F", "fahrenheit"]));
        Register(new("°R", "grau Rankine", "temperatura", 5d / 9d, 0, ["R"]));

        Register(new("rad", "radiano", "ângulo", 1));
        Register(new("°", "grau", "ângulo", Math.PI / 180, Aliases: ["deg"]));
        Register(new("gon", "grado", "ângulo", Math.PI / 200));

        Register(new("m/s", "metro por segundo", "velocidade", 1));
        Register(new("km/h", "quilômetro por hora", "velocidade", 1d / 3.6));
        Register(new("mph", "milha por hora", "velocidade", 0.44704));
        Register(new("kn", "nó", "velocidade", 1852d / 3600));

        Register(new("Pa", "pascal", "pressão", 1));
        Register(new("kPa", "quilopascal", "pressão", 1000));
        Register(new("MPa", "megapascal", "pressão", 1e6));
        Register(new("bar", "bar", "pressão", 100_000));
        Register(new("atm", "atmosfera", "pressão", 101_325));
        Register(new("psi", "libra por polegada quadrada", "pressão", 6894.757293168));
        Register(new("mmHg", "milímetro de mercúrio", "pressão", 133.322387415));

        Register(new("J", "joule", "energia", 1));
        Register(new("kJ", "quilojoule", "energia", 1000));
        Register(new("Wh", "watt-hora", "energia", 3600));
        Register(new("kWh", "quilowatt-hora", "energia", 3_600_000));
        Register(new("cal", "caloria", "energia", 4.184));
        Register(new("kcal", "quilocaloria", "energia", 4184));
        Register(new("eV", "elétron-volt", "energia", 1.602176634e-19));

        Register(new("B", "byte", "dados", 1));
        Register(new("kB", "quilobyte", "dados", 1000));
        Register(new("MB", "megabyte", "dados", 1e6));
        Register(new("GB", "gigabyte", "dados", 1e9));
        Register(new("KiB", "kibibyte", "dados", 1024));
        Register(new("MiB", "mebibyte", "dados", 1_048_576));
        Register(new("GiB", "gibibyte", "dados", 1_073_741_824));
    }
}
