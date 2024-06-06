using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class GdSuite : ISectionCard
{
    public static string Name { get; } = nameof(GdSuite);

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Independent.Name,
        DetailCards = new()
        {
            new TextCard("Suite of desktop and webapplications made using Godot with GDScript/Python"),
            new TextCard("Created CI/CD for project using GitHub Actions to auto-deploy to a website with each commit"),
        }
    };
}
