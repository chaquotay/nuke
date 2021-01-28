// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;

namespace Nuke.Common.IO.CompressionFormat
{
    internal class Tar : ICompressedArchiveFileFormat
    {
        public class Gz : Tar
        {
            public Gz()
                : base(x => new GZipInputStream(x), x => new GZipOutputStream(x))
            {
            }
        }
        public class BZip2 : Tar
        {
            public BZip2()
                : base(x => new BZip2InputStream(x), x => new BZip2OutputStream(x))
            {
            }
        }

        private readonly Func<Stream, Stream> _inputStreamFactory;
        private readonly Func<Stream, Stream> _outputStreamFactory;

        protected Tar(Func<Stream, Stream> inputStreamFactory, Func<Stream, Stream> outputStreamFactory)
        {
            _inputStreamFactory = inputStreamFactory;
            _outputStreamFactory = outputStreamFactory;
        }

        public void Uncompress(string archiveFile, string directory)
        {
            using (var fileStream = File.OpenRead(archiveFile))
            using (var inputStream = _inputStreamFactory(fileStream))
            using (var tarArchive = TarArchive.CreateInputTarArchive(inputStream))
            {
                FileSystemTasks.EnsureExistingDirectory(directory);

                tarArchive.ExtractContents(directory);
            }

            Logger.Info($"Uncompressed '{archiveFile}' to '{directory}'.");
        }

        public void Compress(CompressSettings settings)
        {
            FileSystemTasks.EnsureExistingParentDirectory(settings.ArchiveFile);

            using (var fileStream = File.Open(settings.ArchiveFile, settings.FileMode, FileAccess.ReadWrite))
            using (var outputStream = _outputStreamFactory(fileStream))
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
    }
}
