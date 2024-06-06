using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Shared;

namespace Website.Data.Sections;

public static class SectionsData
{
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
        ProjectsSection.Data,
        ProfessionalExperienceSection.Data,
        SkillsSection.Data,
    };
}
