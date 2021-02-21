﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using Nuke.Components;

partial class Build
{
    static Dictionary<string, string> CustomNames =
        new Dictionary<string, string>
        {
            { nameof(ICompile.Compile), "⚙️" },
            { nameof(ITest.Test), "🚦" },
            { nameof(IPack.Pack), "📦" },
            { nameof(IReportTestCoverage.ReportTestCoverage), "📊" },
            { nameof(IReportCodeDuplicates.ReportCodeDuplicates), "🎭" },
            { nameof(IReportCodeIssues.ReportCodeIssues), "💣" },
            { nameof(IPublish.Publish), "🚚" },
            { nameof(Announce), "🗣" }
        };
}
