using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills;

public sealed class DevOps : ISectionCard
{
    public static string Name { get; } = "DevOps";

    public const string Git = nameof(Git);
    public const string GitHub = nameof(GitHub);
    public const string PlasticScm = "PlasticSCM";
    public const string Slack = nameof(Slack);
    public const string Teams = nameof(Teams);
    public const string GitHubActions = "GitHub Actions";
    public const string Jenkins = nameof(Jenkins);
    public const string AzureDevOps = "Azure DevOps";
    public const string Jira = nameof(Jira);
    public const string Trello = nameof(Trello);
    public const string Confluence = nameof(Confluence);
    public const string Terraform = nameof(Terraform);
    public const string XUnit = "xUnit";

    public static DashboardCard Data { get; } = new(Name)
    {
        DetailCards = new()
        {
            new TextCard() { Title = Git },
            new TextCard() { Title = GitHub },
            new TextCard() { Title = PlasticScm },
            new TextCard() { Title = Slack },
            new TextCard() { Title = Teams },
            new TextCard() { Title = GitHubActions },
            new TextCard() { Title = Jenkins },
            new TextCard() { Title = AzureDevOps },
            new TextCard() { Title = Jira },
            new TextCard() { Title = Trello },
            new TextCard() { Title = Confluence },
            new TextCard() { Title = Terraform },
            new TextCard() { Title = XUnit },
        }
    };
}
