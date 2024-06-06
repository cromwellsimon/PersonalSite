using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills;

public sealed class WebFrontend : ISectionCard
{
    public static string Name { get; } = "Web Frontend";

    public const string Html = "HTML";
    public const string Css = "CSS";
    public const string ReactJs = "React.js";
    public const string Razor = nameof(Razor);
    public const string Blazor = nameof(Blazor);
    public const string Bootstrap = nameof(Bootstrap);

    public static DashboardCard Data { get; } = new(Name)
    {
        DetailCards = new()
        {
            new TitleContentCard() { Title = Html },
            new TitleContentCard() { Title = Css },
            new TitleContentCard() { Title = ReactJs },
            new TitleContentCard() { Title = Razor },
            new TitleContentCard() { Title = Blazor },
            new TitleContentCard() { Title = Bootstrap },
        }
    };
}
