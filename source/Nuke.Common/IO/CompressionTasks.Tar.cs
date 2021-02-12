using System;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    public static partial class CompressionTasks
    {
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

        public static void CompressTarBZip2(Configure<CompressSettings> configure)
        {
            var settings = configure.InvokeSafe(new CompressSettings());
            CompressTarBZip2(settings);
        }

        public static void CompressTarBZip2(CompressSettings settings)
        {
            CompressTar(settings, x => new BZip2OutputStream(x));
        }

        public static void UncompressTarBZip2(string archiveFile, string directory)
        {
            UncompressTar(archiveFile, directory, x => new BZip2InputStream(x));
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

        public static void CompressTarGZip(Configure<CompressSettings> configure)
        {
            var settings = configure.InvokeSafe(new CompressSettings());
            CompressTarGZip(settings);
        }

        public static void CompressTarGZip(CompressSettings settings)
        {
            CompressTar(settings, x => new GZipOutputStream(x));
        }

        public static void UncompressTarGZip(string archiveFile, string directory)
        {
            UncompressTar(archiveFile, directory, x => new GZipInputStream(x));
        }

        private static void CompressTar(CompressSettings settings, Func<Stream, Stream> outputStreamFactory)
        {
            settings ??= new CompressSettings();

            FileSystemTasks.EnsureExistingParentDirectory(settings.ArchiveFile);

            using (var fileStream = File.Open(settings.ArchiveFile, settings.FileMode, FileAccess.ReadWrite))
            using (var outputStream = outputStreamFactory(fileStream))
            using (var tarArchive = TarArchive.CreateOutputTarArchive(outputStream))
            {
                foreach (var file in settings.Files)
                {
                    var relativePath = file.Key;
                    var entry = TarEntry.CreateEntryFromFile(file.Value);
                    entry.Name = PathConstruction.NormalizePath(relativePath, separator: '/');

                    tarArchive.WriteEntry(entry, recurse: false);
                }
            }

            Logger.Info($"Compressed content to '{Path.GetFileName(settings.ArchiveFile)}'.");
        }

        private static void UncompressTar(string archiveFile, string directory, Func<Stream, Stream> inputStreamFactory)
        {
            using (var fileStream = File.OpenRead(archiveFile))
            using (var inputStream = inputStreamFactory(fileStream))
            using (var tarArchive = TarArchive.CreateInputTarArchive(inputStream))
            {
                FileSystemTasks.EnsureExistingDirectory(directory);

                tarArchive.ExtractContents(directory);
            }

            Logger.Info($"Uncompressed '{archiveFile}' to '{directory}'.");
        }
    }
}
