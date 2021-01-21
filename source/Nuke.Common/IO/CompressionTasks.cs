// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO.CompressionFormat;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class CompressionTasks
    {
        private static readonly Zip s_zip = new Zip();
        private static readonly Tar.Gz s_tarGzFormat = new Tar.Gz();
        private static readonly Tar.BZip2 s_tarBzip2Format = new Tar.BZip2();

        private static ICompressedArchiveFileFormat GetCompressedArchiveFileFormat(string archiveFile)
        {
            ICompressedArchiveFileFormat format = null;

            if (archiveFile.EndsWithAny(".zip"))
                format = s_zip;
            else if (archiveFile.EndsWithAny(".tar.gz", ".tgz"))
                format = s_tarGzFormat;
            else if (archiveFile.EndsWithAny(".tar.bz2", ".tbz2", ".tbz"))
                format = s_tarBzip2Format;

            return format;
        }

        public static void Compress(string directory, string archiveFile, Predicate<FileInfo> filter = null)
        {
            var format = GetCompressedArchiveFileFormat(archiveFile);

            if(format == null)
                ControlFlow.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");

            var settings = new CompressSettings()
                .SetArchiveFile(archiveFile)
                .AddFiles(directory, filter);

            format.Compress(settings);
        }

        public static void Uncompress(string archiveFile, string directory)
        {
            var format = GetCompressedArchiveFileFormat(archiveFile);

            if (format == null)
                ControlFlow.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");

            format.Uncompress(archiveFile, directory);
        }

        public static void CompressZip(Configure<CompressSettings> configure)
        {
            var settings = configure.InvokeSafe(new CompressSettings());

            s_zip.Compress(settings);
        }

        public static void CompressZip(
            string directory,
            string archiveFile,
            Predicate<FileInfo> filter = null,
            CompressionLevel compressionLevel = CompressionLevel.Optimal,
            FileMode fileMode = FileMode.CreateNew)
        {
            CompressZip(s => s
                .SetArchiveFile(archiveFile)
                .SetCompressionLevel(compressionLevel)
                .SetFileMode(fileMode)
                .AddFiles(directory, filter));
        }

        public static void UncompressZip(string archiveFile, string directory)
        {
            s_zip.Uncompress(archiveFile, directory);
        }

        public static void CompressTarGZip(Configure<CompressSettings> configure)
        {
            var settings = configure.InvokeSafe(new CompressSettings());

            s_tarGzFormat.Compress(settings);
        }

        public static void CompressTarGZip(
            string directory,
            string archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            CompressTarGZip(s => s
                .SetArchiveFile(archiveFile)
                .SetFileMode(fileMode)
                .AddFiles(directory, filter));
        }

        public static void CompressTarBZip2(Configure<CompressSettings> configure)
        {
            var settings = configure.InvokeSafe(new CompressSettings());

            s_tarBzip2Format.Compress(settings);
        }

        public static void CompressTarBZip2(
            string directory,
            string archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            CompressTarBZip2(s => s
                .SetArchiveFile(archiveFile)
                .SetFileMode(fileMode)
                .AddFiles(directory, filter));
        }

        public static void UncompressTarGZip(string archiveFile, string directory)
        {
            s_tarGzFormat.Uncompress(archiveFile, directory);
        }

        public static void UncompressTarBZip2(string archiveFile, string directory)
        {
            s_tarBzip2Format.Uncompress(archiveFile, directory);
        }

        private static bool EndsWithAny(this string fileName, params string[] extensions)
        {
            return extensions.Any(fileName.EndsWithOrdinalIgnoreCase);
        }
    }
}
