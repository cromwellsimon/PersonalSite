using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class CaravanPositioner : ISectionCard
{
    public static string Name { get; } = "Caravan Positioner";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Independent.Name,
        DetailCards = new()
        {
            new TextCard("Procedural terrain generator and pathfinding project inspired by RimWorld"),
            new TextCard("Made with the Stride Engine, a purely-C# ECS engine like Unity"),
            new TextCard("Strong use of POCOs to create backing logic which is easily scalable and xUnit-testable"),
        }
    };
}
