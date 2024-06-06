using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills;

public sealed class ProgrammingLanguages : ISectionCard
{
    public static string Name { get; } = "Programming Languages";

    public const string Cs = "C#";
    public const string Cpp = "C++";
    public const string TypeScript = nameof(TypeScript);
    public const string JavaScript = nameof(JavaScript);
    public const string Python = nameof(Python);
    public const string Java = nameof(Java);
    public const string UnrealBlueprint = "Unreal Blueprint";
    public const string GdScript = "GDScript";
    public const string Lua = nameof(Lua);

    public static DashboardCard Data { get; } = new(Name)
    {
        DetailCards = new()
        {
            new TitleContentCard() { Title = Cs },
            new TitleContentCard() { Title = Cpp },
            new TitleContentCard() { Title = TypeScript },
            new TitleContentCard() { Title = JavaScript },
            new TitleContentCard() { Title = Python },
            new TitleContentCard() { Title = Java },
            new TitleContentCard() { Title = UnrealBlueprint },
            new TitleContentCard() { Title = GdScript },
            new TitleContentCard() { Title = Lua },
        }
    };
}
