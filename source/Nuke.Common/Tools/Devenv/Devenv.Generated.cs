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
        ///   <p>Devenv lets you build projects and deploy projects from the command line. Use these switches to run the IDE from a script or a .bat file (such as a nightly build script).</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;buildConfig&gt;</c> via <see cref="DevenvSettings.BuildConfig"/></li>
        ///     <li><c>&lt;cleanConfig&gt;</c> via <see cref="DevenvSettings.CleanConfig"/></li>
        ///     <li><c>&lt;deployConfig&gt;</c> via <see cref="DevenvSettings.DeployConfig"/></li>
        ///     <li><c>&lt;rebuildConfig&gt;</c> via <see cref="DevenvSettings.RebuildConfig"/></li>
        ///     <li><c>&lt;solution&gt;</c> via <see cref="DevenvSettings.Solution"/></li>
        ///     <li><c>/Build</c> via <see cref="DevenvSettings.Build"/></li>
        ///     <li><c>/Clean</c> via <see cref="DevenvSettings.Clean"/></li>
        ///     <li><c>/Deploy</c> via <see cref="DevenvSettings.Deploy"/></li>
        ///     <li><c>/Out</c> via <see cref="DevenvSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvSettings.ProjectConfig"/></li>
        ///     <li><c>/Rebuild</c> via <see cref="DevenvSettings.Rebuild"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Devenv(DevenvSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DevenvSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Devenv lets you build projects and deploy projects from the command line. Use these switches to run the IDE from a script or a .bat file (such as a nightly build script).</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;buildConfig&gt;</c> via <see cref="DevenvSettings.BuildConfig"/></li>
        ///     <li><c>&lt;cleanConfig&gt;</c> via <see cref="DevenvSettings.CleanConfig"/></li>
        ///     <li><c>&lt;deployConfig&gt;</c> via <see cref="DevenvSettings.DeployConfig"/></li>
        ///     <li><c>&lt;rebuildConfig&gt;</c> via <see cref="DevenvSettings.RebuildConfig"/></li>
        ///     <li><c>&lt;solution&gt;</c> via <see cref="DevenvSettings.Solution"/></li>
        ///     <li><c>/Build</c> via <see cref="DevenvSettings.Build"/></li>
        ///     <li><c>/Clean</c> via <see cref="DevenvSettings.Clean"/></li>
        ///     <li><c>/Deploy</c> via <see cref="DevenvSettings.Deploy"/></li>
        ///     <li><c>/Out</c> via <see cref="DevenvSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvSettings.ProjectConfig"/></li>
        ///     <li><c>/Rebuild</c> via <see cref="DevenvSettings.Rebuild"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Devenv(Configure<DevenvSettings> configurator)
        {
            return Devenv(configurator(new DevenvSettings()));
        }
        /// <summary>
        ///   <p>Devenv lets you build projects and deploy projects from the command line. Use these switches to run the IDE from a script or a .bat file (such as a nightly build script).</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/ide/reference/devenv-command-line-switches">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;buildConfig&gt;</c> via <see cref="DevenvSettings.BuildConfig"/></li>
        ///     <li><c>&lt;cleanConfig&gt;</c> via <see cref="DevenvSettings.CleanConfig"/></li>
        ///     <li><c>&lt;deployConfig&gt;</c> via <see cref="DevenvSettings.DeployConfig"/></li>
        ///     <li><c>&lt;rebuildConfig&gt;</c> via <see cref="DevenvSettings.RebuildConfig"/></li>
        ///     <li><c>&lt;solution&gt;</c> via <see cref="DevenvSettings.Solution"/></li>
        ///     <li><c>/Build</c> via <see cref="DevenvSettings.Build"/></li>
        ///     <li><c>/Clean</c> via <see cref="DevenvSettings.Clean"/></li>
        ///     <li><c>/Deploy</c> via <see cref="DevenvSettings.Deploy"/></li>
        ///     <li><c>/Out</c> via <see cref="DevenvSettings.Logfile"/></li>
        ///     <li><c>/Project</c> via <see cref="DevenvSettings.Project"/></li>
        ///     <li><c>/ProjectConfig</c> via <see cref="DevenvSettings.ProjectConfig"/></li>
        ///     <li><c>/Rebuild</c> via <see cref="DevenvSettings.Rebuild"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DevenvSettings Settings, IReadOnlyCollection<Output> Output)> Devenv(CombinatorialConfigure<DevenvSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Devenv, DevenvLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DevenvSettings
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DevenvSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Devenv executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => DevenvTasks.DevenvLogger;
        /// <summary>
        ///   Specifies the solution.
        /// </summary>
        public virtual string Solution { get; internal set; }
        /// <summary>
        ///   Builds the specified solution or project according to the configuration of the specified solution.
        /// </summary>
        public virtual bool? Build { get; internal set; }
        /// <summary>
        ///   Specifies the build configuration.
        /// </summary>
        public virtual string BuildConfig { get; internal set; }
        /// <summary>
        ///   Cleans and then builds the specified solution or project according to the configuration of the specified solution.
        /// </summary>
        public virtual bool? Rebuild { get; internal set; }
        /// <summary>
        ///   Specifies the rebuild configuration.
        /// </summary>
        public virtual string RebuildConfig { get; internal set; }
        /// <summary>
        ///   Builds the solution, along with files necessary for deployment, according to the solution's configuration.
        /// </summary>
        public virtual bool? Deploy { get; internal set; }
        /// <summary>
        ///   Specifies the deploy configuration.
        /// </summary>
        public virtual string DeployConfig { get; internal set; }
        /// <summary>
        ///   Deletes any files created by the build command, without affecting source files.
        /// </summary>
        public virtual bool? Clean { get; internal set; }
        /// <summary>
        ///   Specifies the clean configuration.
        /// </summary>
        public virtual string CleanConfig { get; internal set; }
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
              .Add("{value}", Solution)
              .Add("/Build", Build)
              .Add("{value}", BuildConfig)
              .Add("/Rebuild", Rebuild)
              .Add("{value}", RebuildConfig)
              .Add("/Deploy", Deploy)
              .Add("{value}", DeployConfig)
              .Add("/Clean", Clean)
              .Add("{value}", CleanConfig)
              .Add("/Out {value}", Logfile)
              .Add("/Project {value}", Project)
              .Add("/ProjectConfig {value}", ProjectConfig);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DevenvSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DevenvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DevenvSettingsExtensions
    {
        #region Solution
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.Solution"/></em></p>
        ///   <p>Specifies the solution.</p>
        /// </summary>
        [Pure]
        public static T SetSolution<T>(this T toolSettings, string solution) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Solution = solution;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.Solution"/></em></p>
        ///   <p>Specifies the solution.</p>
        /// </summary>
        [Pure]
        public static T ResetSolution<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Solution = null;
            return toolSettings;
        }
        #endregion
        #region Build
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.Build"/></em></p>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T SetBuild<T>(this T toolSettings, bool? build) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = build;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.Build"/></em></p>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T ResetBuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DevenvSettings.Build"/></em></p>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T EnableBuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DevenvSettings.Build"/></em></p>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T DisableBuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DevenvSettings.Build"/></em></p>
        ///   <p>Builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T ToggleBuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = !toolSettings.Build;
            return toolSettings;
        }
        #endregion
        #region BuildConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.BuildConfig"/></em></p>
        ///   <p>Specifies the build configuration.</p>
        /// </summary>
        [Pure]
        public static T SetBuildConfig<T>(this T toolSettings, string buildConfig) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildConfig = buildConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.BuildConfig"/></em></p>
        ///   <p>Specifies the build configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildConfig<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildConfig = null;
            return toolSettings;
        }
        #endregion
        #region Rebuild
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.Rebuild"/></em></p>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T SetRebuild<T>(this T toolSettings, bool? rebuild) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rebuild = rebuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.Rebuild"/></em></p>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T ResetRebuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rebuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DevenvSettings.Rebuild"/></em></p>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T EnableRebuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rebuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DevenvSettings.Rebuild"/></em></p>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T DisableRebuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rebuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DevenvSettings.Rebuild"/></em></p>
        ///   <p>Cleans and then builds the specified solution or project according to the configuration of the specified solution.</p>
        /// </summary>
        [Pure]
        public static T ToggleRebuild<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Rebuild = !toolSettings.Rebuild;
            return toolSettings;
        }
        #endregion
        #region RebuildConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.RebuildConfig"/></em></p>
        ///   <p>Specifies the rebuild configuration.</p>
        /// </summary>
        [Pure]
        public static T SetRebuildConfig<T>(this T toolSettings, string rebuildConfig) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RebuildConfig = rebuildConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.RebuildConfig"/></em></p>
        ///   <p>Specifies the rebuild configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetRebuildConfig<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RebuildConfig = null;
            return toolSettings;
        }
        #endregion
        #region Deploy
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.Deploy"/></em></p>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        /// </summary>
        [Pure]
        public static T SetDeploy<T>(this T toolSettings, bool? deploy) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deploy = deploy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.Deploy"/></em></p>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetDeploy<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deploy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DevenvSettings.Deploy"/></em></p>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        /// </summary>
        [Pure]
        public static T EnableDeploy<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deploy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DevenvSettings.Deploy"/></em></p>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        /// </summary>
        [Pure]
        public static T DisableDeploy<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deploy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DevenvSettings.Deploy"/></em></p>
        ///   <p>Builds the solution, along with files necessary for deployment, according to the solution's configuration.</p>
        /// </summary>
        [Pure]
        public static T ToggleDeploy<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deploy = !toolSettings.Deploy;
            return toolSettings;
        }
        #endregion
        #region DeployConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.DeployConfig"/></em></p>
        ///   <p>Specifies the deploy configuration.</p>
        /// </summary>
        [Pure]
        public static T SetDeployConfig<T>(this T toolSettings, string deployConfig) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployConfig = deployConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.DeployConfig"/></em></p>
        ///   <p>Specifies the deploy configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetDeployConfig<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployConfig = null;
            return toolSettings;
        }
        #endregion
        #region Clean
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.Clean"/></em></p>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        /// </summary>
        [Pure]
        public static T SetClean<T>(this T toolSettings, bool? clean) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Clean = clean;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.Clean"/></em></p>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        /// </summary>
        [Pure]
        public static T ResetClean<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Clean = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DevenvSettings.Clean"/></em></p>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        /// </summary>
        [Pure]
        public static T EnableClean<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Clean = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DevenvSettings.Clean"/></em></p>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        /// </summary>
        [Pure]
        public static T DisableClean<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Clean = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DevenvSettings.Clean"/></em></p>
        ///   <p>Deletes any files created by the build command, without affecting source files.</p>
        /// </summary>
        [Pure]
        public static T ToggleClean<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Clean = !toolSettings.Clean;
            return toolSettings;
        }
        #endregion
        #region CleanConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.CleanConfig"/></em></p>
        ///   <p>Specifies the clean configuration.</p>
        /// </summary>
        [Pure]
        public static T SetCleanConfig<T>(this T toolSettings, string cleanConfig) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanConfig = cleanConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.CleanConfig"/></em></p>
        ///   <p>Specifies the clean configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetCleanConfig<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanConfig = null;
            return toolSettings;
        }
        #endregion
        #region Logfile
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T SetLogfile<T>(this T toolSettings, string logfile) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = logfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.Logfile"/></em></p>
        ///   <p>Lets you specify a file to receive errors when you build.</p>
        /// </summary>
        [Pure]
        public static T ResetLogfile<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logfile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.Project"/></em></p>
        ///   <p>The project to build, clean, or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region ProjectConfig
        /// <summary>
        ///   <p><em>Sets <see cref="DevenvSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T SetProjectConfig<T>(this T toolSettings, string projectConfig) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = projectConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DevenvSettings.ProjectConfig"/></em></p>
        ///   <p>Specifies the project configuration to build or deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectConfig<T>(this T toolSettings) where T : DevenvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectConfig = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
