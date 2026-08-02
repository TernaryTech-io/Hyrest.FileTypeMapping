using HeyRed.Mime;

namespace HyRest.FileTypeMapping
{
    public static class FileTypeMap
    {
        private static readonly FileTypeEntryCollection _entries = FileTypeMappingUtility.GetEntries();

        public static string? GetMimeType(long fileTypeId) =>
            TryGetMimeType(fileTypeId, out string mime) ? mime : null;

        public static string? GetMimeType(string extension)
            => TryGetMimeType(extension, out string ext) ? ext : null;       
        public static string? GetExtension(long fileTypeId) =>
            TryGetExtension(fileTypeId, out string ext) ? ext : null;

        public static string? GetExtension(string mimetype)
            => TryGetExtension(mimetype, out string ext) ? ext : null;         

        public static long? GetFileTypeFromMimeType(string mimetype) =>
            TryGetFileTypeFromMimeType(mimetype, out long id) ? id : null;

        public static long? GetFileTypeFromExtension(string extension) =>
            TryGetFileTypeFromExtension(extension, out long id) ? id : null;

        public static bool TryGetMimeType(long fileTypeId, out string mimetype)
        {
            mimetype = string.Empty;
            if (_entries.TryGetByFileTypeId(fileTypeId, out var e))
            {
                mimetype = e.MimeType;
                return true;
            }
            return false;
        }

        public static bool TryGetMimeType(string extension, out string mimetype)
        {
            mimetype = string.Empty;
            extension = extension.Replace(".", "");
            if (_entries.TryGetByExtension(extension, out var e))
            {
                mimetype = e.MimeType;
                return true;
            }
            else
            {
                var fallback = MimeTypesMap.GetMimeType(extension);
                if (fallback != null)            
                {
                    mimetype = fallback;
                    return true;
                }                
            }
            return false;
        }

        public static bool TryGetExtension(long fileTypeId, out string extension)
        {
            extension = string.Empty;
            if (_entries.TryGetByFileTypeId(fileTypeId, out var e))
            {
                extension = e.Extension;
                return true;
            }
            return false;
        }

        public static bool TryGetExtension(string mimeType, out string extension)
        {
            extension = string.Empty;
            if (_entries.TryGetByMimeType(mimeType, out var e))
            {
                extension = e.Extension;
                return true;
            }
            else
            {
                var fallback = MimeTypesMap.GetExtension(mimeType);
                if(fallback != null)
                {
                    extension = fallback;
                    return true;
                }
            }
            return false;
        }

        public static bool TryGetFileTypeFromMimeType(string mimeType, out long fileTypeId)
        {
            fileTypeId = -1;
            if (_entries.TryGetByMimeType(mimeType, out var e))
            {
                fileTypeId = e.FileTypeId;
                return true;
            }
            return false;
        }

        public static bool TryGetFileTypeFromExtension(string extension, out long fileTypeId)
        {
            fileTypeId = -1;
            extension = extension.Replace(".", "");
            if (_entries.TryGetByExtension(extension, out var e))
            {
                fileTypeId = e.FileTypeId;
                return true;
            }
            return false;
        }
    }
}