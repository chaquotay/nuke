using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Devenv
{
    partial class DevenvTasks
    {
        private static string GetToolPath()
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
