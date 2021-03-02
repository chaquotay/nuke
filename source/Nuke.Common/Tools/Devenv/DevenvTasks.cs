// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Devenv
{
    partial class DevenvTasks
    {
        internal static string GetToolPath()
        {
            var vswhere = ToolPathResolver.GetPackageExecutable("vswhere", "vswhere.exe");
            var process = ProcessTasks.StartProcess(vswhere, @"-find **\devenv.exe -latest");
            return process
                .AssertZeroExitCode()
                .Output
                .EnsureOnlyStd()
                .Single()
                .Text;
        }
    }
}
