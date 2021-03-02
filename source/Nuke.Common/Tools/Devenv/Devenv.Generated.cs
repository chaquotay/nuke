// Generated from https://github.com/chaquotay/nuke/blob/master/build/specifications/Devenv.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Devenv
{
    /// <summary>
    ///   <p>Devenv lets you build projects and deploy projects from the command line. Use these switches to run the IDE from a script or a .bat file (such as a nightly build script).</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DevenvTasks
    {
        /// <summary>
        ///   Path to the Devenv executable.
        /// </summary>
        public static string DevenvPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DEVENV_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> DevenvLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Devenv lets you build projects and deploy projects from the command line. Use these switches to run the IDE from a script or a .bat file (such as a nightly build script).</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Devenv(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, bool? logTimestamp = null, string logFile = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(DevenvPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logTimestamp, logFile, DevenvLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvBuildSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvBuildSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvBuildSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvBuild(DevenvBuildSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DevenvBuildSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvBuildSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvBuildSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvBuildSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvBuild(Configure<DevenvBuildSettings> configurator)
        {
            return DevenvBuild(configurator(new DevenvBuildSettings()));
        }
        /// <summary>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvBuildSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvBuildSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvBuildSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DevenvBuildSettings Settings, IReadOnlyCollection<Output> Output)> DevenvBuild(CombinatorialConfigure<DevenvBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DevenvBuild, DevenvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvRebuildSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvRebuildSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvRebuildSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvRebuild(DevenvRebuildSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DevenvRebuildSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvRebuildSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvRebuildSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvRebuildSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvRebuild(Configure<DevenvRebuildSettings> configurator)
        {
            return DevenvRebuild(configurator(new DevenvRebuildSettings()));
        }
        /// <summary>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvRebuildSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvRebuildSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvRebuildSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DevenvRebuildSettings Settings, IReadOnlyCollection<Output> Output)> DevenvRebuild(CombinatorialConfigure<DevenvRebuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DevenvRebuild, DevenvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvDeploySettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvDeploySettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvDeploySettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvDeploy(DevenvDeploySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DevenvDeploySettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvDeploySettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvDeploySettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvDeploySettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvDeploy(Configure<DevenvDeploySettings> configurator)
        {
            return DevenvDeploy(configurator(new DevenvDeploySettings()));
        }
        /// <summary>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvDeploySettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvDeploySettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvDeploySettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DevenvDeploySettings Settings, IReadOnlyCollection<Output> Output)> DevenvDeploy(CombinatorialConfigure<DevenvDeploySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DevenvDeploy, DevenvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvCleanSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvCleanSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvCleanSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvClean(DevenvCleanSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DevenvCleanSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvCleanSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvCleanSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvCleanSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DevenvClean(Configure<DevenvCleanSettings> configurator)
        {
            return DevenvClean(configurator(new DevenvCleanSettings()));
        }
        /// <summary>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/Out</c> via <see cref="DevenvCleanSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvCleanSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvCleanSettings.ProjectConfig"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DevenvCleanSettings Settings, IReadOnlyCollection<Output> Output)> DevenvClean(CombinatorialConfigure<DevenvCleanSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DevenvClean, DevenvLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DevenvBuildSettings
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DevenvBuildSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Devenv executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => DevenvTasks.DevenvLogger;
        /// <summary>
        ///   Lets you specify a file to receive errors when you build.
        /// </summary>
        public virtual string Logfile { get; internal set; }
        /// <summary>
        ///   The project to build, clean, or deploy.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Specifies the project configuration to build or deploy.
        /// </summary>
        public virtual string ProjectConfig { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("/Build")
              .Add("/Out {value}", Logfile)
              .Add("/Project {value}", Project)
              .Add("/ProjectConfig {value}", ProjectConfig);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DevenvRebuildSettings
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DevenvRebuildSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Devenv executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => DevenvTasks.DevenvLogger;
        /// <summary>
        ///   Lets you specify a file to receive errors when you build.
        /// </summary>
        public virtual string Logfile { get; internal set; }
        /// <summary>
        ///   The project to build, clean, or deploy.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Specifies the project configuration to build or deploy.
        /// </summary>
        public virtual string ProjectConfig { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("/Rebuild")
              .Add("/Out {value}", Logfile)
              .Add("/Project {value}", Project)
              .Add("/ProjectConfig {value}", ProjectConfig);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DevenvDeploySettings
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DevenvDeploySettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Devenv executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => DevenvTasks.DevenvLogger;
        /// <summary>
        ///   Lets you specify a file to receive errors when you build.
        /// </summary>
        public virtual string Logfile { get; internal set; }
        /// <summary>
        ///   The project to build, clean, or deploy.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Specifies the project configuration to build or deploy.
        /// </summary>
        public virtual string ProjectConfig { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("/Deploy")
              .Add("/Out {value}", Logfile)
              .Add("/Project {value}", Project)
              .Add("/ProjectConfig {value}", ProjectConfig);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DevenvCleanSettings
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DevenvCleanSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Devenv executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => DevenvTasks.DevenvLogger;
        /// <summary>
        ///   Lets you specify a file to receive errors when you build.
        /// </summary>
        public virtual string Logfile { get; internal set; }
        /// <summary>
        ///   The project to build, clean, or deploy.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Specifies the project configuration to build or deploy.
        /// </summary>
        public virtual string ProjectConfig { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("/Clean")
              .Add("/Out {value}", Logfile)
              .Add("/Project {value}", Project)
              .Add("/ProjectConfig {value}", ProjectConfig);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DevenvBuildSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DevenvBuildSettingsExtensions
    {
        #region Logfile
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvBuildSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T SetLogfile<T>(this T toolSettings, string logfile) where T : DevenvBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = logfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvBuildSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T ResetLogfile<T>(this T toolSettings) where T : DevenvBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvBuildSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DevenvBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvBuildSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DevenvBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region ProjectConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvBuildSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProjectConfig<T>(this T toolSettings, string projectConfig) where T : DevenvBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = projectConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvBuildSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectConfig<T>(this T toolSettings) where T : DevenvBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DevenvRebuildSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DevenvRebuildSettingsExtensions
    {
        #region Logfile
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvRebuildSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T SetLogfile<T>(this T toolSettings, string logfile) where T : DevenvRebuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = logfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvRebuildSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T ResetLogfile<T>(this T toolSettings) where T : DevenvRebuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvRebuildSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DevenvRebuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvRebuildSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DevenvRebuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region ProjectConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvRebuildSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProjectConfig<T>(this T toolSettings, string projectConfig) where T : DevenvRebuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = projectConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvRebuildSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectConfig<T>(this T toolSettings) where T : DevenvRebuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DevenvDeploySettingsExtensions
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DevenvDeploySettingsExtensions
    {
        #region Logfile
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvDeploySettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T SetLogfile<T>(this T toolSettings, string logfile) where T : DevenvDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = logfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvDeploySettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T ResetLogfile<T>(this T toolSettings) where T : DevenvDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvDeploySettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DevenvDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvDeploySettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DevenvDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region ProjectConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvDeploySettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProjectConfig<T>(this T toolSettings, string projectConfig) where T : DevenvDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = projectConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvDeploySettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectConfig<T>(this T toolSettings) where T : DevenvDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DevenvCleanSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DevenvCleanSettingsExtensions
    {
        #region Logfile
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvCleanSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T SetLogfile<T>(this T toolSettings, string logfile) where T : DevenvCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = logfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvCleanSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T ResetLogfile<T>(this T toolSettings) where T : DevenvCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvCleanSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DevenvCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvCleanSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DevenvCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region ProjectConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvCleanSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProjectConfig<T>(this T toolSettings, string projectConfig) where T : DevenvCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = projectConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvCleanSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectConfig<T>(this T toolSettings) where T : DevenvCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
