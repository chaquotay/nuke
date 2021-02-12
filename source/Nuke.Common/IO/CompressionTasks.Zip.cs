using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    public static partial class CompressionTasks
    {
        public static void CompressZip(Configure<CompressSettings> configure)
        {
            var settings = configure.InvokeSafe(new CompressSettings());

            CompressZip(settings);
        }

        private static void CompressZip(CompressSettings settings)
        {
            settings ??= new CompressSettings();

            FileSystemTasks.EnsureExistingParentDirectory(settings.ArchiveFile);

            using (var fileStream = File.Open(settings.ArchiveFile, settings.FileMode, FileAccess.ReadWrite))
            using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            {
                // zipStream.SetLevel(1);

                foreach (var file in settings.Files)
                {
                    var relativePath = file.Key;
                    var entryName = ZipEntry.CleanName(relativePath);
                    zipArchive.CreateEntryFromFile(file.Value, entryName, settings.CompressionLevel);
                }
            }

            Logger.Info($"Compressed content to '{Path.GetFileName(settings.ArchiveFile)}'.");
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
            using (var fileStream = File.OpenRead(archiveFile))
            using (var zipFile = new ICSharpCode.SharpZipLib.Zip.ZipFile(fileStream))
            {
                var entries = zipFile.Cast<ZipEntry>().Where(x => !x.IsDirectory);
                foreach (var entry in entries)
                {
                    var file = PathConstruction.Combine(directory, entry.Name);
                    FileSystemTasks.EnsureExistingParentDirectory(file);

                    using var entryStream = zipFile.GetInputStream(entry);
                    using var outputStream = File.Open(file, FileMode.Create);
                    entryStream.CopyTo(outputStream);
                }
            }

            Logger.Info($"Uncompressed '{archiveFile}' to '{directory}'.");
        }

    }
}
