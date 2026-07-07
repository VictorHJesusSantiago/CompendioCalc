using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.Json;

namespace CompendioCalc.Services;

public sealed record ContentPackManifest(
    string Id,
    string Name,
    string Version,
    int SchemaVersion,
    string Discipline,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<string, string> Files);

public sealed record InstalledPack(string Id, string Name, string Version, string Path);

public sealed class OfflinePackService
{
    private const long MaxEntryBytes = 64L * 1024 * 1024;
    private const long MaxTotalBytes = 512L * 1024 * 1024;
    private string Root => Path.Combine(FileSystem.AppDataDirectory, "content-packs");

    public InstalledPack Install(byte[] zipBytes, byte[] signature, string publicKeyPem)
    {
        using var rsa = RSA.Create();
        rsa.ImportFromPem(publicKeyPem);
        if (!rsa.VerifyData(zipBytes, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss))
            throw new CryptographicException("Assinatura do pack inválida.");
        using var archive = new ZipArchive(new MemoryStream(zipBytes), ZipArchiveMode.Read);
        var manifestEntry = archive.GetEntry("manifest.json") ?? throw new InvalidDataException("Manifesto ausente.");
        ContentPackManifest manifest;
        using (var stream = manifestEntry.Open())
            manifest = JsonSerializer.Deserialize<ContentPackManifest>(stream)
                       ?? throw new InvalidDataException("Manifesto inválido.");
        ValidateManifest(manifest);
        long total = 0;
        foreach (var entry in archive.Entries)
        {
            if (string.IsNullOrEmpty(entry.Name)) continue;
            if (entry.Length > MaxEntryBytes || (total += entry.Length) > MaxTotalBytes)
                throw new InvalidDataException("Pack excede os limites de tamanho.");
            if (entry.FullName.Contains("..", StringComparison.Ordinal) || Path.IsPathRooted(entry.FullName))
                throw new InvalidDataException("Caminho inseguro no pack.");
        }
        var destination = Path.Combine(Root, SafeSegment(manifest.Id), SafeSegment(manifest.Version));
        var temporary = destination + ".installing-" + Guid.NewGuid().ToString("N");
        Directory.CreateDirectory(temporary);
        try
        {
            foreach (var entry in archive.Entries)
            {
                if (string.IsNullOrEmpty(entry.Name)) continue;
                var path = Path.GetFullPath(Path.Combine(temporary, entry.FullName));
                if (!path.StartsWith(Path.GetFullPath(temporary) + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
                    throw new InvalidDataException("Entrada tenta sair da pasta do pack.");
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                using var input = entry.Open();
                using var output = File.Create(path);
                input.CopyTo(output);
            }
            VerifyFiles(temporary, manifest);
            if (Directory.Exists(destination)) Directory.Delete(destination, true);
            Directory.CreateDirectory(Path.GetDirectoryName(destination)!);
            Directory.Move(temporary, destination);
        }
        catch
        {
            if (Directory.Exists(temporary)) Directory.Delete(temporary, true);
            throw;
        }
        return new(manifest.Id, manifest.Name, manifest.Version, destination);
    }

    public IReadOnlyList<InstalledPack> ListInstalled()
    {
        if (!Directory.Exists(Root)) return [];
        var result = new List<InstalledPack>();
        foreach (var manifestPath in Directory.EnumerateFiles(Root, "manifest.json", SearchOption.AllDirectories))
        {
            try
            {
                var manifest = JsonSerializer.Deserialize<ContentPackManifest>(File.ReadAllText(manifestPath));
                if (manifest is not null) result.Add(new(manifest.Id, manifest.Name, manifest.Version, Path.GetDirectoryName(manifestPath)!));
            }
            catch { /* pack corrompido é ignorado e pode ser removido pelo diagnóstico */ }
        }
        return result;
    }

    public void Remove(string id, string version)
    {
        var path = Path.Combine(Root, SafeSegment(id), SafeSegment(version));
        if (Directory.Exists(path)) Directory.Delete(path, true);
    }

    private static void VerifyFiles(string root, ContentPackManifest manifest)
    {
        foreach (var (relative, expected) in manifest.Files)
        {
            var path = Path.GetFullPath(Path.Combine(root, relative));
            if (!path.StartsWith(Path.GetFullPath(root) + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) ||
                !File.Exists(path)) throw new InvalidDataException($"Arquivo ausente: {relative}");
            using var input = File.OpenRead(path);
            var actual = Convert.ToHexString(SHA256.HashData(input)).ToLowerInvariant();
            if (!actual.Equals(expected, StringComparison.OrdinalIgnoreCase))
                throw new InvalidDataException($"Hash inválido: {relative}");
        }
    }

    private static void ValidateManifest(ContentPackManifest manifest)
    {
        if (manifest.SchemaVersion != 1) throw new InvalidDataException("Schema de pack incompatível.");
        if (string.IsNullOrWhiteSpace(manifest.Id) || string.IsNullOrWhiteSpace(manifest.Version) ||
            manifest.Files.Count == 0) throw new InvalidDataException("Manifesto incompleto.");
    }

    private static string SafeSegment(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Any(character =>
                Path.GetInvalidFileNameChars().Contains(character) || character is '/' or '\\'))
            throw new InvalidDataException("Identificador de pack inválido.");
        return value;
    }
}
