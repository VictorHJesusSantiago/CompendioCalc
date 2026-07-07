using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace CompendioCalc.Services;

public sealed record DiagnosticCheck(string Name, string Status, string Detail);
public sealed record DiagnosticReport(
    DateTimeOffset GeneratedAt,
    string AppVersion,
    string Runtime,
    string Platform,
    string CatalogHash,
    long AppDataBytes,
    IReadOnlyList<DiagnosticCheck> Checks);

public sealed class OfflineDiagnosticService
{
    private readonly FormulaService _formulas;
    private readonly OfflineMathService _math;
    private readonly UnitConversionService _units;
    private readonly OfflinePackService _packs;

    public OfflineDiagnosticService(FormulaService formulas, OfflineMathService math,
        UnitConversionService units, OfflinePackService packs)
    {
        _formulas = formulas;
        _math = math;
        _units = units;
        _packs = packs;
    }

    public DiagnosticReport Run()
    {
        var checks = new List<DiagnosticCheck>();
        RunCheck(checks, "Motor matemático", () =>
            Math.Abs(_math.Evaluate("sqrt(81)+2^3") - 17) < 1e-12 ? "Operacional" : throw new ArithmeticException());
        RunCheck(checks, "Conversor", () =>
            Math.Abs(_units.Convert(1, "km", "m").Output - 1000) < 1e-12 ? "Operacional" : throw new ArithmeticException());
        RunCheck(checks, "Catálogo", () => _formulas.ObterTotalFormulas() > 0
            ? $"{_formulas.ObterTotalFormulas()} registros acessíveis" : throw new InvalidDataException());
        RunCheck(checks, "Packs", () => $"{_packs.ListInstalled().Count} pack(s) instalado(s)");
        RunCheck(checks, "Diretório de dados", () =>
        {
            Directory.CreateDirectory(FileSystem.AppDataDirectory);
            var probe = Path.Combine(FileSystem.AppDataDirectory, ".write-probe");
            File.WriteAllText(probe, "ok");
            File.Delete(probe);
            return "Leitura e escrita operacionais";
        });
        return new(DateTimeOffset.UtcNow,
            Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "desconhecida",
            RuntimeInformation.FrameworkDescription, RuntimeInformation.OSDescription,
            ComputeCatalogHash(), DirectorySize(FileSystem.AppDataDirectory), checks);
    }

    public string ToText(DiagnosticReport report)
    {
        var builder = new StringBuilder()
            .AppendLine("CompendioCalc — Diagnóstico offline")
            .AppendLine($"Gerado: {report.GeneratedAt:O}")
            .AppendLine($"Aplicativo: {report.AppVersion}")
            .AppendLine($"Runtime: {report.Runtime}")
            .AppendLine($"Plataforma: {report.Platform}")
            .AppendLine($"Hash do catálogo: {report.CatalogHash}")
            .AppendLine($"Dados locais: {report.AppDataBytes} bytes");
        foreach (var check in report.Checks)
            builder.AppendLine($"[{check.Status}] {check.Name}: {check.Detail}");
        return builder.ToString();
    }

    private string ComputeCatalogHash()
    {
        using var hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
        foreach (var formula in _formulas.ObterTodas().OrderBy(formula => formula.Id, StringComparer.OrdinalIgnoreCase))
        {
            var line = $"{formula.Id}\u001f{formula.Expressao}\u001f{formula.Metadata.Versao}\n";
            hash.AppendData(Encoding.UTF8.GetBytes(line));
        }
        return Convert.ToHexString(hash.GetHashAndReset()).ToLowerInvariant();
    }

    private static long DirectorySize(string path)
    {
        if (!Directory.Exists(path)) return 0;
        return Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
            .Sum(file => { try { return new FileInfo(file).Length; } catch { return 0; } });
    }

    private static void RunCheck(List<DiagnosticCheck> checks, string name, Func<string> action)
    {
        try { checks.Add(new(name, "OK", action())); }
        catch (Exception ex) { checks.Add(new(name, "FALHA", ex.GetType().Name + ": " + ex.Message)); }
    }
}
