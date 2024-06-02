using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Sections.Skills.Details;
using Website.Shared;
using Website.Shared.Cards.Dashboard;

namespace Website.Data.Sections.Skills;

public static class SkillsSection
{
    public const string ProgrammingLanguages = "Programming Languages";
    public const string GameDevelopmentTools = "Game Development Tools";
    public const string WebFrontend = "Web Frontend";
    public const string Backend = nameof(Backend);
    public const string Cloud = nameof(Cloud);
    public const string Database = nameof(Database);
    public const string DevOps = nameof(DevOps);
    public const string Other = nameof(Other);

    public static Section Skills { get; } = new()
    {
        Name = nameof(Skills),
        DashboardCards =
        {
            ProgrammingLanguagesCards.ProgrammingLanguages,
            GameDevelopmentToolsCards.GameDevelopmentTools,
            new(WebFrontend),
            new(Backend),
            new(Cloud),
            new(Database),
            new(DevOps),
            new(Other),
        }
    };
}
