using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills;

public sealed class Other : ISectionCard
{
    public static string Name { get; } = "Other";

    public const string Modeling = "3D Modeling";
    public const string ProceduralTexturing = "Procedural Texturing";
    public const string UvUnwrapping = "UV Unwrapping";
    public const string Lighting = nameof(Lighting);
    public const string Glsl = "GLSL";
    public const string Vfx = "VFX";
    public const string Vr = "VR";
    public const string Mobile = nameof(Mobile);

    public static DashboardCard Data { get; } = new(Name)
    {
        DetailCards = new()
        {
            new TextCard() { Title = Modeling },
            new TextCard() { Title = ProceduralTexturing },
            new TextCard() { Title = UvUnwrapping },
            new TextCard() { Title = Lighting },
            new TextCard() { Title = Glsl },
            new TextCard() { Title = Vfx },
            new TextCard() { Title = Vr },
            new TextCard() { Title = Mobile },
        }
    };
}
