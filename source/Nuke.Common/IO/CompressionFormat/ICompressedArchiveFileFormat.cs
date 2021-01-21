// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common.IO.CompressionFormat
{
    internal interface ICompressedArchiveFileFormat
    {
        void Uncompress(string archiveFile, string directory);

        void Compress(CompressSettings settings);
    }
}
