using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace HyRest.FileTypeMapping;

internal record FileTypeEntry(long FileTypeId, string Extension, string MimeType);

internal sealed class FileTypeEntryCollection : IEnumerable<FileTypeEntry>
{
    private readonly FileTypeEntry[] _entries;
    private readonly Dictionary<string, FileTypeEntry> _byExtension;
    private readonly Dictionary<long, FileTypeEntry> _byFileTypeId;
    private readonly Dictionary<string, FileTypeEntry> _byMimeType;

    // entries: extension-keyed mappings; canonical: display ext/mime per file type (for fileTypeId lookups)
    internal FileTypeEntryCollection(FileTypeEntry[] entries, FileTypeEntry[] canonical)
    {
        _entries = entries;
        _byExtension = new(StringComparer.OrdinalIgnoreCase);
        _byMimeType = new(StringComparer.OrdinalIgnoreCase);
        foreach (var e in entries)
        {
            _byExtension.TryAdd(e.Extension, e);
            _byMimeType.TryAdd(e.MimeType, e);
        }
        _byFileTypeId = new();
        foreach (var e in canonical)
        {
            _byFileTypeId.TryAdd(e.FileTypeId, e);
            _byMimeType.TryAdd(e.MimeType, e);
        }
        foreach (var e in entries)
            _byFileTypeId.TryAdd(e.FileTypeId, e);
    }

    internal bool TryGetByExtension(string extension, [MaybeNullWhen(false)] out FileTypeEntry entry) =>
        _byExtension.TryGetValue(extension, out entry);

    internal bool TryGetByFileTypeId(long fileTypeId, [MaybeNullWhen(false)] out FileTypeEntry entry) =>
        _byFileTypeId.TryGetValue(fileTypeId, out entry);

    internal bool TryGetByMimeType(string mimeType, [MaybeNullWhen(false)] out FileTypeEntry entry) =>
        _byMimeType.TryGetValue(mimeType, out entry);

    public IEnumerator<FileTypeEntry> GetEnumerator() => ((IEnumerable<FileTypeEntry>)_entries).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _entries.GetEnumerator();
}