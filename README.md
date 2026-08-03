# HyRest.FileTypeMapping

File type mapping utility library for converting between file extensions, MIME types, and Hyland File Types.

## Overview

HyRest.FileTypeMapping provides convenient utilities for mapping file extensions and MIME types to their corresponding Hyland File Type enumerations, and vice versa. This simplifies file type handling when working with Hyland OnBase systems. Additionally, Hyland doesn't always use common MIME types, even in the REST API which creates difficulties determining the correct file extension for content.

## Features

- Map file extensions to Hyland File Types
- Map MIME types to Hyland File Types
- Reverse lookup from Hyland File Types to extensions/MIME types
- Comprehensive file type enumeration
- Falls back to the popular library 'MimeTypeMapOfficial'

## Usage

```csharp
using HyRest.FileTypeMapping;

// Map MimeType from File Type Id
var mimeType = FileTypeMapping.GetMimeType(16);

// Map MimeType from Extension
var mimeType = FileTypeMapping.GetMimeType("pdf");

// Map Extension from File Type Id
var extension = FileTypeMapping.GetExtension(16);

// Map Extension from MimeType
var extension = FileTypeMapping.GetExtension("application/pdf");

// Map from extension to file type
var fileType = FileTypeMapping.GetFileTypeFromExtension("pdf");

// Map from MIME type to file type
var fileType = FileTypeMapping.GetFileTypeFromMimeType("application/pdf");

```

## Core Types

- `FileTypes` - Enumeration of supported Hyland file types
- `FileTypeMapping` - Utility class for mapping operations
- `FileTypeMappingUtility` - Custom querable collection. 

## License
Free and Open Source Software (FOSS) - Feel free to include this in any projects, no citations or credit needed.

[LICENSE](./LICENSE)
