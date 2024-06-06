using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class SilentHillRemake : ISectionCard
{
    public static string Name { get; } = "Silent Hill Remake";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Independent.Name,
        DetailCards = new()
        {
            new TextCard("Lead developer and producer on full, independent remake of Silent Hill 1"),
            new TextCard("Using Azure DevOps to manage a group of people in development of the project by creating and assigning tasks, providing training, establishing guidelines, and reviewing the work done on those tasks"),
            new TextCard("Developed map, inventory, combat, saving, traversal, enemy AI, localization, all puzzles, and interaction systems with the corresponding UI for each of those systems. Most of these systems are genericized out in such a way to allow them to be usable across any C#-supported environment -- not just competing game engines -- and, more importantly, allows them to be fully unit testable"),
            new TextCard("Created Godot and Visual Studio tools to improve refactorability of projects by making it simpler to read .tscn and .tres files from Visual Studio as well as reparenting and renaming nodes/variables"),
            new TextCard("Datamined many assets from the original PS1 game and created tools in Blender and Godot in order to automate fixing up faults with models/textures in the import process"),
        }
    };
}
