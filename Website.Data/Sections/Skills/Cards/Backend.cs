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
            new TitleContentCard()
            {
                Title = AspNetCore,
                Content = "Microsoft's web development framework primarily for C# and .NET developers",
            },
            new TitleContentCard()
            {
                Title = NetCore,
                Content = "Microsoft's multi-platform runtime environment for languages such as C#, F#, and Visual Basic",
            },
            new TitleContentCard()
            {
                Title = NodeJs,
                Content = "Standalone V8 engine wrapper designed to allow JavaScript run without a browser and with access to OS-level functionality such as the file system",
            },
            new TitleContentCard()
            {
                Title = Sql,
                Content = "Data query language used in relational databases including SQL Server and MySQL",
            },
        }
    };
}
