using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills;

public sealed class Backend : ISectionCard
{
    public static string Name { get; } = "Backend";

    public const string AspNetCore = "ASP.NET Core";
    public const string NetCore = ".NET Core";
    public const string NodeJs = "Node.js";
    public const string Sql = "SQL";

    public static DashboardCard Data { get; } = new(Name)
    {
        DetailCards = new()
        {
            new TextCard() { Title = AspNetCore },
            new TextCard() { Title = NetCore },
            new TextCard() { Title = NodeJs },
            new TextCard() { Title = Sql },
        }
    };
}
