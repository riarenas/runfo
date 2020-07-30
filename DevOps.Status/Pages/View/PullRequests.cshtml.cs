﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevOps.Util;
using DevOps.Util.DotNet;
using DevOps.Util.Triage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Octokit;

namespace DevOps.Status.Pages.View
{
    public class PullRequestsModel : PageModel
    {
        public sealed class PullRequestBuildInfo
        {
            public string? BuildUri { get; set; }
            public int BuildNumber { get; set; }
            public BuildResult Result { get; set; }
            public string? DefinitionName { get; set; }
            public string? DefinitionUri { get; set; }
        }

        public TriageContext TriageContext { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Number { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Repository { get; set; }

        public string? PullRequestHtmlUri { get; set; }

        public List<PullRequestBuildInfo> Builds { get; set; } = new List<PullRequestBuildInfo>();

        public PullRequestsModel(TriageContext triageContext)
        {
            TriageContext = triageContext;
        }

        public async Task OnGet()
        {
            if (Number is null || string.IsNullOrEmpty(Repository))
            {
                return;
            }

            PullRequestHtmlUri = GitHubPullRequestKey.GetPullRequestUri(
                DotNetUtil.GitHubOrganization,
                Repository,
                Number.Value);
            var builds = await TriageContext
                .ModelBuilds
                .Include(x => x.ModelBuildDefinition)
                .Where(x =>
                    x.GitHubOrganization == DotNetUtil.GitHubOrganization &&
                    x.GitHubRepository == Repository &&
                    x.PullRequestNumber == Number)
                .OrderByDescending(x => x.BuildNumber)
                .ToListAsync();
            Builds = builds
                .Select(b => new PullRequestBuildInfo()
                {
                    BuildUri = TriageContextUtil.GetBuildInfo(b).BuildUri,
                    BuildNumber = b.BuildNumber,
                    Result = b.BuildResult ?? BuildResult.None,
                    DefinitionUri = TriageContextUtil.GetBuildDefinitionInfo(b.ModelBuildDefinition).DefinitionUri,
                    DefinitionName = b.ModelBuildDefinition.DefinitionName,
                })
                .ToList();
        }
    }
}