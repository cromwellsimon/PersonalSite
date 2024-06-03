using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Data.Sections.Skills;
using Website.Shared;
using Website.Shared.Cards.Dashboard;

namespace Website.Data.Sections;

public sealed class SkillsSection : ISectionData
{
    public static Section Data { get; } = new()
    {
        Name = nameof(Skills),
        DashboardCards =
        {
            ProgrammingLanguages.Data,
            GameDevelopment.Data,
            WebFrontend.Data,
            Backend.Data,
            Cloud.Data,
            Database.Data,
            DevOps.Data,
            Other.Data,
        }
    };
}
