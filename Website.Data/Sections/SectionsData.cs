using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Sections.Skills;
using Website.Shared;

namespace Website.Data.Sections;

public static class SectionsData
{
    public const string Skills = nameof(Skills);
    public const string ProfessionalExperience = "Professional Experience";
    public const string Projects = nameof(Projects);
    public const string Courses = nameof(Courses);
    public const string Other = nameof(Other);
    public static List<Section> Sections { get; } = new()
    {
        new()
        {
            Name = Other,
            DashboardCards =
            {
                new() { Title = "test" },
            }
        },
        new()
        {
            Name = Courses,
            DashboardCards =
            {
                new() { Title = StringLibrary.CourseSites.Pluralsight },
                new() { Title = StringLibrary.CourseSites.Udemy },
                new() { Title = StringLibrary.CourseSites.GameDevTv },
            }
        },
        new()
        {
            Name = Projects,
            DashboardCards =
            {
                new() { Title = StringLibrary.Projects.PtForPc, Subtitle = StringLibrary.Companies.Independent },
                new() { Title = StringLibrary.Projects.LaRueCountyTreasuryWebsite, Subtitle = StringLibrary.Companies.Independent },
                new() { Title = StringLibrary.Projects.ElevatorUnity, Subtitle = StringLibrary.Companies.Independent },
                new() { Title = StringLibrary.Projects.PolkerGame, Subtitle = StringLibrary.Companies.Polker },
                new() { Title = StringLibrary.Projects.DarkDeception, Subtitle = StringLibrary.Companies.GlowstickEntertainment },
                new() { Title = StringLibrary.Projects.MonstersAndMortals, Subtitle = StringLibrary.Companies.GlowstickEntertainment },
                new() { Title = StringLibrary.Projects.GdSuite, Subtitle = StringLibrary.Companies.Independent },
                new() { Title = StringLibrary.Projects.CommissionSystem, Subtitle = StringLibrary.Companies.ElectricityGuruAndInternetGuru },
                new() { Title = StringLibrary.Projects.SilentHillRemake, Subtitle = StringLibrary.Companies.Independent },
                new() { Title = StringLibrary.Projects.UniversalControlMacros, Subtitle = StringLibrary.Companies.LaRueCountyBand },
                new() { Title = StringLibrary.Projects.CtCore, Subtitle = StringLibrary.Companies.CromwellTechnology },
                new() { Title = StringLibrary.Projects.CaravanPositioner, Subtitle = StringLibrary.Companies.Independent },
                new() { Title = StringLibrary.Projects.Website, Subtitle = StringLibrary.Companies.Independent },
            }
        },
        new()
        {
            Name = ProfessionalExperience,
            DashboardCards =
            {
                new() { Title = StringLibrary.JobTitles.SoftwareEngineer, Subtitle = StringLibrary.Companies.GlowstickEntertainment },
                new() { Title = StringLibrary.JobTitles.FullStackDeveloper, Subtitle = StringLibrary.Companies.Polker },
                new() { Title = StringLibrary.JobTitles.FullStackDeveloper, Subtitle = StringLibrary.Companies.ElectricityGuruAndInternetGuru },
                new() { Title = StringLibrary.JobTitles.FullStackDeveloper, Subtitle = StringLibrary.Companies.CromwellTechnology },
            }
        },
        SkillsSection.Skills,
    };
}
