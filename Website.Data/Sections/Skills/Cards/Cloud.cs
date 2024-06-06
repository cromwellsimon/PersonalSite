using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills;

public sealed class Cloud : ISectionCard
{
    public static string Name { get; } = "Cloud";

    public const string Aws = "AWS";
    public const string Azure = nameof(Azure);
    public const string Eos = "EOS";
    public const string Steamworks = nameof(Steamworks);

    public static DashboardCard Data { get; } = new(Name)
    {
        DetailCards = new()
        {
            new TitleContentCard() { Title = Aws },
            new TitleContentCard() { Title = Azure },
            new TitleContentCard() { Title = Eos },
            new TitleContentCard() { Title = Steamworks },
        }
    };
}
