// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
using Xunit;
using Xunit.Abstractions;

namespace Nuke.Common.Tests
{
    public class CompressionTasksTest : FileSystemDependentTest
    {
        public CompressionTasksTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Theory]
        [InlineData("archive.zip")]
        [InlineData("archive.tar.gz")]
        [InlineData("archive.tar.bz2")]
        public void Test(string archiveFile)
        {
            var rootFile = Path.Combine(TestTempDirectory, "rootfile.txt");
            var nestedFile = Path.Combine(TestTempDirectory, "a", "b", "c", "nestedfile.txt");

            TextTasks.WriteAllText(rootFile, "root");
            TextTasks.WriteAllText(nestedFile, "nested");

            var archive = Path.Combine(TestTempDirectory, archiveFile);
            CompressionTasks.Compress(TestTempDirectory, archive);
            File.Exists(archive).Should().BeTrue();

            File.Delete(rootFile);
            File.Delete(nestedFile);
            Directory.GetFiles(TestTempDirectory, "*").Should().HaveCount(1);

            CompressionTasks.Uncompress(archive, TestTempDirectory);
            File.Exists(rootFile).Should().BeTrue();
            File.ReadAllText(rootFile).Should().Be("root");
            File.Exists(nestedFile).Should().BeTrue();
            File.ReadAllText(nestedFile).Should().Be("nested");
        }

        [Theory]
        [InlineData("archive.zip")]
        [InlineData("archive.tar.gz")]
        [InlineData("archive.tar.bz2")]
        public void TestWithConfigure(string archiveFile)
        {
            var rootFile = Path.Combine(TestTempDirectory, "rootfile.txt");
            var nestedFile = Path.Combine(TestTempDirectory, "a", "b", "c", "nestedfile.txt");

            TextTasks.WriteAllText(rootFile, "root");
            TextTasks.WriteAllText(nestedFile, "nested");

            var archive = Path.Combine(TestTempDirectory, archiveFile);
            CompressionTasks.Compress(s => s
                .AddFiles(TestTempDirectory)
                .SetArchiveFile(archive));
            File.Exists(archive).Should().BeTrue();

            File.Delete(rootFile);
            File.Delete(nestedFile);
            Directory.GetFiles(TestTempDirectory, "*").Should().HaveCount(1);

            CompressionTasks.Uncompress(archive, TestTempDirectory);
            File.Exists(rootFile).Should().BeTrue();
            File.ReadAllText(rootFile).Should().Be("root");
            File.Exists(nestedFile).Should().BeTrue();
            File.ReadAllText(nestedFile).Should().Be("nested");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("subdir")]
        public void TestAddFiles(string prefix)
        {
            var relativePath = Path.Combine("a", "b", "c", "nestedfile.txt");
            var nestedFile = Path.Combine(TestTempDirectory, relativePath);

            TextTasks.WriteAllText(nestedFile, "nested");

            var settings = new CompressSettings()
                .AddFiles(TestTempDirectory, "**/c/*", prefix: prefix);

            var pathInArchive = relativePath;
            if (!string.IsNullOrEmpty(prefix))
            {
                pathInArchive = Path.Combine(prefix, pathInArchive);
            }

            settings.Files.Should().HaveCount(1).And.Contain(pathInArchive, nestedFile);
        }
    }
}
