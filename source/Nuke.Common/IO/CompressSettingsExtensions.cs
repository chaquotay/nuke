// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using GlobExpressions;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class CompressSettingsExtensions
    {
        public static CompressSettings SetArchiveFile(this CompressSettings settings, string archiveFile)
        {
            settings = settings.NewInstance();
            settings.ArchiveFile = archiveFile;
            return settings;
        }

        public static CompressSettings ResetArchiveFile(this CompressSettings settings)
        {
            settings = settings.NewInstance();
            settings.ArchiveFile = null;
            return settings;
        }

        public static CompressSettings SetCompressionLevel(this CompressSettings settings, CompressionLevel compressionLevel)
        {
            settings = settings.NewInstance();
            settings.CompressionLevel = compressionLevel;
            return settings;
        }

        public static CompressSettings ResetCompressionLevel(this CompressSettings settings)
        {
            settings = settings.NewInstance();
            settings.CompressionLevel = CompressionLevel.Optimal;
            return settings;
        }

        public static CompressSettings SetFileMode(this CompressSettings settings, FileMode fileMode)
        {
            settings = settings.NewInstance();
            settings.FileMode = fileMode;
            return settings;
        }

        public static CompressSettings ResetFileMode(this CompressSettings settings)
        {
            settings = settings.NewInstance();
            settings.FileMode = FileMode.CreateNew;
            return settings;
        }

        public static CompressSettings SetFiles(this CompressSettings settings, Dictionary<string, string> files)
        {
            settings = settings.NewInstance();
            settings.Files = files!=null ? new Dictionary<string, string>(files) : new Dictionary<string, string>();
            return settings;
        }

        public static CompressSettings ResetFiles(this CompressSettings settings)
        {
            settings = settings.NewInstance();
            settings.Files = new Dictionary<string, string>();
            return settings;
        }

        public static CompressSettings AddFiles(this CompressSettings settings, string directory, string globPattern, bool overwrite = true, string prefix = null)
        {
            settings = settings.NewInstance();

            var files = Glob.Files(directory, globPattern);
            var entries = files
                .Select(file => (RelativePath: PathConstruction.GetRelativePath(directory, file), File: file))
                .ToDictionary(x => x.RelativePath, x => x.File);

            var prefixPath = string.IsNullOrEmpty(prefix) ? null : (RelativePath) prefix;

            foreach (var entry in entries)
            {
                var pathInArchive = prefixPath != null ? prefixPath / entry.Key : entry.Key;
                if (overwrite || !settings.Files.ContainsKey(entry.Key))
                {
                    settings.Files[pathInArchive] = entry.Value;
                }
            }

            return settings;
        }

        public static CompressSettings AddFiles(this CompressSettings settings, string directory, Predicate<FileInfo> filter = null, bool overwrite = true, string prefix = null)
        {
            var files = GetFiles(directory, filter);
            var entries = files
                .Select(file => (RelativePath: PathConstruction.GetRelativePath(directory, file), File: file))
                .ToDictionary(x => x.RelativePath, x => x.File);

            var prefixPath = string.IsNullOrEmpty(prefix) ? null : (RelativePath)prefix;

            foreach (var entry in entries)
            {
                var pathInArchive = prefixPath != null ? prefixPath / entry.Key : entry.Key;
                if (overwrite || !settings.Files.ContainsKey(entry.Key))
                {
                    settings.Files[pathInArchive] = entry.Value;
                }
            }

            return settings;
        }

        public static CompressSettings RemoveFiles(this CompressSettings settings, string globPattern)
        {
            settings = settings.NewInstance();

            var matchingFiles = settings
                .Files
                .Where(entry => Glob.IsMatch(entry.Key, globPattern, GlobOptions.Compiled));

            foreach (var file in matchingFiles)
            {
                settings.Files.Remove(file.Key);
            }

            return settings;
        }
        public static CompressSettings RemoveFiles(this CompressSettings settings, Predicate<string> filter)
        {
            settings = settings.NewInstance();

            var matchingFiles = settings
                .Files
                .Where(entry => filter.Invoke(entry.Key));

            foreach (var file in matchingFiles)
            {
                settings.Files.Remove(file.Key);
            }

            return settings;
        }

        public static CompressSettings RemoveSourceFiles(this CompressSettings settings, Predicate<FileInfo> filter)
        {
            var matchingFiles = settings
                .Files
                .Where(entry => filter.Invoke(new FileInfo(entry.Value)));

            settings = settings.NewInstance();
            foreach (var file in matchingFiles)
            {
                settings.Files.Remove(file.Key);
            }

            return settings;
        }

        private static List<string> GetFiles(string directory, [CanBeNull] Predicate<FileInfo> filter)
        {
            return Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                .Where(x => filter == null || filter(new FileInfo(x)))
                .OrderBy(x => x)
                .ToList();
        }

    }
}
