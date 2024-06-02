using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills.Details;

public static class GameDevelopmentToolsCards
{
    public const string Unreal = nameof(Unreal);
    public const string Unity = nameof(Unity);
    public const string Godot = nameof(Godot);
    public const string Stride = nameof(Stride);
    public const string Blender = nameof(Blender);

    public static DashboardCard GameDevelopmentTools { get; } = new(SkillsSection.GameDevelopmentTools)
    {
        DetailCards = new()
        {
            new TextCard() { Title = Unreal },
            new TextCard() { Title = Unity },
            new TextCard() { Title = Godot },
            new TextCard() { Title = Stride },
            new TextCard() { Title = Blender },
        }
    };
}
