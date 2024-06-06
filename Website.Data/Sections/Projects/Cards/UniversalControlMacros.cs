using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class UniversalControlMacros : ISectionCard
{
    public static string Name { get; } = "Universal Control Macros";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Independent.Name,
        DetailCards = new()
        {
            new TextCard("Desktop automation tool to create programmatic scenes and transitions on PreSonus soundboards"),
            new TextCard("Created a JSON Parser using Python and TypeScript to allow the user to define intricate scenes/transitions and which then run on the soundboard through robotics libraries"),
        }
    };
}
