// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common.Tools.Devenv
{
    public partial class DevenvRebuildSettings
    {
        private string GetProcessToolPath()
        {
            return DevenvTasks.GetToolPath();
        }
    }
}
