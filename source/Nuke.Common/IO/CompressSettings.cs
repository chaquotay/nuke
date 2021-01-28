using System;
using System.Collections.Generic;
using System.IO;
// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO.Compression;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    [Serializable]
    public class CompressSettings : ISettingsEntity
    {
        private Dictionary<string, string> _files = new Dictionary<string, string>();

        public CompressionLevel CompressionLevel { get; set; } = CompressionLevel.Optimal;

        public string ArchiveFile { get; set; }

        public Dictionary<string, string> Files
        {
            get => _files;
            set => _files = value ?? new Dictionary<string, string>();
        }

        public FileMode FileMode { get; set; } = FileMode.CreateNew;
    }
}
