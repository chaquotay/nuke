// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static partial class CompressionTasks
    {
        public static void Compress(string directory, string archiveFile, Predicate<FileInfo> filter = null)
        {
            Compress(s => s
                .SetArchiveFile(archiveFile)
                .AddFiles(directory, filter));
        }

        public static void Compress(Configure<CompressSettings> configure)
        {
            var settings = configure.InvokeSafe(new CompressSettings());
            Compress(settings);
        }

        public static void Compress(CompressSettings settings)
        {
            settings ??= new CompressSettings();

            var archiveFile = settings.ArchiveFile;

            if (archiveFile.EndsWithAny(".zip"))
                CompressZip(settings);
            else if (archiveFile.EndsWithAny(".tar.gz", ".tgz"))
                CompressTarGZip(settings);
            else if (archiveFile.EndsWithAny(".tar.bz2", ".tbz2", ".tbz"))
                CompressTarBZip2(settings);
            else
                ControlFlow.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");
        }

        public static void Uncompress(string archiveFile, string directory)
        {
            if (archiveFile.EndsWithAny(".zip"))
                UncompressZip(archiveFile, directory);
            else if (archiveFile.EndsWithAny(".tar.gz", ".tgz"))
                UncompressTarGZip(archiveFile, directory);
            else if (archiveFile.EndsWithAny(".tar.bz2", ".tbz2", ".tbz"))
                UncompressTarBZip2(archiveFile, directory);
            else
                ControlFlow.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");
        }

        private static bool EndsWithAny(this string fileName, params string[] extensions)
        {
            return extensions.Any(fileName.EndsWithOrdinalIgnoreCase);
        }
    }
}
