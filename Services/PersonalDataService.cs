using System.Text.Json;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public sealed class PersonalDataService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    private readonly object _gate = new();
    private PersonalDataDocument _data = new();
    private string FilePath => Path.Combine(FileSystem.AppDataDirectory, "personal-data.v1.json");

    public event Action? Changed;
    public PersonalDataDocument Snapshot
    {
        get
        {
            lock (_gate)
                return JsonSerializer.Deserialize<PersonalDataDocument>(
                    JsonSerializer.Serialize(_data, JsonOptions), JsonOptions)!;
        }
    }

    public void Load()
    {
        lock (_gate)
        {
            if (!File.Exists(FilePath))
            {
                _data = new();
                return;
            }
            var document = JsonSerializer.Deserialize<PersonalDataDocument>(
                File.ReadAllText(FilePath), JsonOptions) ?? new();
            if (document.SchemaVersion is < 1 or > 1)
                throw new InvalidDataException($"Versão de dados pessoais não suportada: {document.SchemaVersion}.");
            _data = document;
        }
        Changed?.Invoke();
    }

    public FormulaCollection CreateCollection(string name, string description = "")
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("O nome é obrigatório.", nameof(name));
        FormulaCollection collection;
        lock (_gate)
        {
            collection = new() { Name = name.Trim(), Description = description.Trim() };
            _data.Collections.Add(collection);
            SaveUnsafe();
        }
        Changed?.Invoke();
        return collection;
    }

    public void DeleteCollection(string id)
    {
        lock (_gate)
        {
            _data.Collections.RemoveAll(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    public void AddToCollection(string collectionId, string formulaId)
    {
        lock (_gate)
        {
            var collection = _data.Collections.FirstOrDefault(item =>
                item.Id.Equals(collectionId, StringComparison.OrdinalIgnoreCase))
                ?? throw new KeyNotFoundException(collectionId);
            if (!collection.FormulaIds.Contains(formulaId, StringComparer.OrdinalIgnoreCase))
                collection.FormulaIds.Add(formulaId);
            collection.UpdatedAt = DateTimeOffset.UtcNow;
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    public void RemoveFromCollection(string collectionId, string formulaId)
    {
        lock (_gate)
        {
            var collection = _data.Collections.FirstOrDefault(item =>
                item.Id.Equals(collectionId, StringComparison.OrdinalIgnoreCase))
                ?? throw new KeyNotFoundException(collectionId);
            collection.FormulaIds.RemoveAll(id => id.Equals(formulaId, StringComparison.OrdinalIgnoreCase));
            collection.UpdatedAt = DateTimeOffset.UtcNow;
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    public void SaveNote(FormulaNote note)
    {
        if (string.IsNullOrWhiteSpace(note.FormulaId)) throw new ArgumentException("FormulaId é obrigatório.");
        lock (_gate)
        {
            var index = _data.Notes.FindIndex(item =>
                item.FormulaId.Equals(note.FormulaId, StringComparison.OrdinalIgnoreCase));
            note.UpdatedAt = DateTimeOffset.UtcNow;
            if (index < 0) _data.Notes.Add(note);
            else _data.Notes[index] = note;
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    public void SavePreset(CalculationPreset preset)
    {
        if (string.IsNullOrWhiteSpace(preset.FormulaId) || string.IsNullOrWhiteSpace(preset.Name))
            throw new ArgumentException("Fórmula e nome são obrigatórios.");
        lock (_gate)
        {
            var index = _data.Presets.FindIndex(item => item.Id == preset.Id);
            if (index < 0) _data.Presets.Add(preset);
            else _data.Presets[index] = preset;
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    public void SaveSearch(SavedSearch search)
    {
        if (string.IsNullOrWhiteSpace(search.Name)) throw new ArgumentException("O nome é obrigatório.");
        lock (_gate)
        {
            var index = _data.SavedSearches.FindIndex(item => item.Id == search.Id);
            if (index < 0) _data.SavedSearches.Add(search);
            else _data.SavedSearches[index] = search;
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    public void MarkRecent(string formulaId, int limit = 50)
    {
        lock (_gate)
        {
            _data.RecentFormulaIds.RemoveAll(id => id.Equals(formulaId, StringComparison.OrdinalIgnoreCase));
            _data.RecentFormulaIds.Insert(0, formulaId);
            if (_data.RecentFormulaIds.Count > limit)
                _data.RecentFormulaIds.RemoveRange(limit, _data.RecentFormulaIds.Count - limit);
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    public string ExportJson()
    {
        lock (_gate) return JsonSerializer.Serialize(_data, JsonOptions);
    }

    public void ImportJson(string json, bool merge)
    {
        var imported = JsonSerializer.Deserialize<PersonalDataDocument>(json, JsonOptions)
                       ?? throw new InvalidDataException("Documento pessoal inválido.");
        if (imported.SchemaVersion != 1) throw new InvalidDataException("Schema incompatível.");
        lock (_gate)
        {
            if (!merge) _data = imported;
            else MergeUnsafe(imported);
            SaveUnsafe();
        }
        Changed?.Invoke();
    }

    private void MergeUnsafe(PersonalDataDocument imported)
    {
        MergeById(_data.Collections, imported.Collections, item => item.Id);
        MergeById(_data.Presets, imported.Presets, item => item.Id);
        MergeById(_data.SavedSearches, imported.SavedSearches, item => item.Id);
        foreach (var note in imported.Notes) SaveOrReplace(_data.Notes, note, item => item.FormulaId);
        foreach (var id in imported.RecentFormulaIds.AsEnumerable().Reverse())
        {
            _data.RecentFormulaIds.RemoveAll(existing => existing.Equals(id, StringComparison.OrdinalIgnoreCase));
            _data.RecentFormulaIds.Insert(0, id);
        }
        if (_data.RecentFormulaIds.Count > 50) _data.RecentFormulaIds.RemoveRange(50, _data.RecentFormulaIds.Count - 50);
    }

    private static void MergeById<T>(List<T> target, IEnumerable<T> source, Func<T, string> key)
    {
        foreach (var item in source) SaveOrReplace(target, item, key);
    }

    private static void SaveOrReplace<T>(List<T> target, T item, Func<T, string> key)
    {
        var index = target.FindIndex(existing => key(existing).Equals(key(item), StringComparison.OrdinalIgnoreCase));
        if (index < 0) target.Add(item);
        else target[index] = item;
    }

    private void SaveUnsafe()
    {
        var temporary = FilePath + ".tmp";
        File.WriteAllText(temporary, JsonSerializer.Serialize(_data, JsonOptions));
        File.Move(temporary, FilePath, true);
    }
}
