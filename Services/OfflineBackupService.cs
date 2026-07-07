using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CompendioCalc.Services;

public sealed record BackupManifest(
    int SchemaVersion,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<string, string> Sha256);

public sealed record BackupPreview(
    BackupManifest Manifest,
    IReadOnlyList<string> Files,
    bool Encrypted);

public sealed class OfflineBackupService
{
    private static readonly HashSet<string> AllowedFiles = new(StringComparer.OrdinalIgnoreCase)
    {
        "personal-data.v1.json", "favoritos.json", "historico.json"
    };
    private static readonly byte[] Magic = "CCBK1"u8.ToArray();

    public byte[] Create(string? password = null)
    {
        using var raw = new MemoryStream();
        var hashes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        using (var archive = new ZipArchive(raw, ZipArchiveMode.Create, true))
        {
            foreach (var name in AllowedFiles)
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, name);
                if (!File.Exists(path)) continue;
                var bytes = File.ReadAllBytes(path);
                hashes[name] = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
                var entry = archive.CreateEntry(name, CompressionLevel.Optimal);
                using var output = entry.Open();
                output.Write(bytes);
            }
            var manifest = new BackupManifest(1, DateTimeOffset.UtcNow, hashes);
            var manifestEntry = archive.CreateEntry("manifest.json", CompressionLevel.Optimal);
            using var writer = new StreamWriter(manifestEntry.Open(), Encoding.UTF8);
            writer.Write(JsonSerializer.Serialize(manifest));
        }
        var payload = raw.ToArray();
        return string.IsNullOrEmpty(password) ? WrapPlain(payload) : Encrypt(payload, password);
    }

    public BackupPreview Preview(byte[] package, string? password = null)
    {
        var (payload, encrypted) = Unwrap(package, password);
        using var archive = new ZipArchive(new MemoryStream(payload), ZipArchiveMode.Read);
        var manifest = ReadManifest(archive);
        return new(manifest, archive.Entries.Where(entry => entry.Name != "manifest.json")
            .Select(entry => entry.Name).ToArray(), encrypted);
    }

    public void Restore(byte[] package, string? password = null, bool merge = false)
    {
        var (payload, _) = Unwrap(package, password);
        using var archive = new ZipArchive(new MemoryStream(payload), ZipArchiveMode.Read);
        var manifest = ReadManifest(archive);
        if (manifest.SchemaVersion != 1) throw new InvalidDataException("Versão de backup incompatível.");
        foreach (var entry in archive.Entries)
        {
            if (entry.Name == "manifest.json") continue;
            if (!AllowedFiles.Contains(entry.Name) || entry.FullName != entry.Name)
                throw new InvalidDataException($"Entrada não permitida no backup: {entry.FullName}");
            if (entry.Length > 64 * 1024 * 1024) throw new InvalidDataException("Arquivo do backup excede o limite.");
            using var input = entry.Open();
            using var memory = new MemoryStream();
            input.CopyTo(memory);
            var bytes = memory.ToArray();
            var hash = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
            if (!manifest.Sha256.TryGetValue(entry.Name, out var expected) ||
                !CryptographicOperations.FixedTimeEquals(Encoding.ASCII.GetBytes(hash), Encoding.ASCII.GetBytes(expected)))
                throw new InvalidDataException($"Hash inválido para {entry.Name}.");
            var destination = Path.Combine(FileSystem.AppDataDirectory, entry.Name);
            if (merge && entry.Name == "personal-data.v1.json" && File.Exists(destination))
            {
                var service = new PersonalDataService();
                service.Load();
                service.ImportJson(Encoding.UTF8.GetString(bytes), true);
                continue;
            }
            var temporary = destination + ".restore";
            File.WriteAllBytes(temporary, bytes);
            File.Move(temporary, destination, true);
        }
    }

    private static BackupManifest ReadManifest(ZipArchive archive)
    {
        var entry = archive.GetEntry("manifest.json") ?? throw new InvalidDataException("Manifesto ausente.");
        using var stream = entry.Open();
        return JsonSerializer.Deserialize<BackupManifest>(stream) ??
               throw new InvalidDataException("Manifesto inválido.");
    }

    private static byte[] WrapPlain(byte[] payload) => [.. Magic, 0, .. payload];

    private static byte[] Encrypt(byte[] payload, string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var nonce = RandomNumberGenerator.GetBytes(12);
        var key = Rfc2898DeriveBytes.Pbkdf2(password, salt, 210_000, HashAlgorithmName.SHA256, 32);
        var cipher = new byte[payload.Length];
        var tag = new byte[16];
        using (var aes = new AesGcm(key, tag.Length)) aes.Encrypt(nonce, payload, cipher, tag, Magic);
        CryptographicOperations.ZeroMemory(key);
        return [.. Magic, 1, .. salt, .. nonce, .. tag, .. cipher];
    }

    private static (byte[] Payload, bool Encrypted) Unwrap(byte[] package, string? password)
    {
        if (package.Length < Magic.Length + 1 || !package.AsSpan(0, Magic.Length).SequenceEqual(Magic))
            throw new InvalidDataException("Formato de backup inválido.");
        var encrypted = package[Magic.Length] == 1;
        if (!encrypted) return (package[(Magic.Length + 1)..], false);
        if (string.IsNullOrEmpty(password)) throw new CryptographicException("Senha obrigatória.");
        if (package.Length < Magic.Length + 1 + 16 + 12 + 16) throw new InvalidDataException("Backup truncado.");
        var offset = Magic.Length + 1;
        var salt = package.AsSpan(offset, 16); offset += 16;
        var nonce = package.AsSpan(offset, 12); offset += 12;
        var tag = package.AsSpan(offset, 16); offset += 16;
        var cipher = package.AsSpan(offset);
        var plain = new byte[cipher.Length];
        var key = Rfc2898DeriveBytes.Pbkdf2(password, salt, 210_000, HashAlgorithmName.SHA256, 32);
        try
        {
            using var aes = new AesGcm(key, tag.Length);
            aes.Decrypt(nonce, cipher, tag, plain, Magic);
            return (plain, true);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(key);
        }
    }
}
