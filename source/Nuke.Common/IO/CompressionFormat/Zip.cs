// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.IO.Compression;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;

namespace Nuke.Common.IO.CompressionFormat
{
    internal class Zip : ICompressedArchiveFileFormat
    {
        public void Uncompress(string archiveFile, string directory)
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

        public void Compress(CompressSettings settings)
        {
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
    }
}
