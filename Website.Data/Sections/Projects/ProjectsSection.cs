using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Data.Sections.ProfessionalExperience;
using Website.Data.Sections.Projects;
using Website.Shared;

namespace Website.Data.Sections;

public sealed class ProjectsSection : ISectionData
{
    public static Section Data { get; } = new()
    {
        Name = nameof(Projects),
        DashboardCards =
        {
            CtCore.Data,
            CommissionSystem.Data,
            DarkDeception.Data,
            MonstersAndMortals.Data,
            PolkerGame.Data,
            SilentHillRemake.Data,
            PersonalWebsite.Data,
            CaravanPositioner.Data,
            UniversalControlMacros.Data,
            GdSuite.Data,
            ElevatorUnity.Data,
            PtForPc.Data,
        },
    };
}
