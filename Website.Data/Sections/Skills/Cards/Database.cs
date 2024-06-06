using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Skills;

public sealed class Database : ISectionCard
{
    public static string Name { get; } = "Database";

    public const string SqlServer = "SQL Server";
    public const string AzureSql = "Azure SQL";
    public const string MySql = "MySQL";
    public const string CosmosDb = "CosmosDB";
    public const string MongoDb = "MongoDB";

    public static DashboardCard Data { get; } = new(Name)
    {
        DetailCards = new()
        {
            new TitleContentCard() { Title = SqlServer },
            new TitleContentCard() { Title = AzureSql },
            new TitleContentCard() { Title = MySql },
            new TitleContentCard() { Title = CosmosDb },
            new TitleContentCard() { Title = MongoDb },
        }
    };
}
