using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class CtCore : ISectionCard
{
    public static string Name { get; } = "CT Core";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.CromwellTechnology.Name,
        DetailCards = new()
        {
            new TextCard("Development of general-purpose, highly dynamic commission calculation software for any type of business"),
            new TextCard("Wrote frontend as a SPA using C# in Blazor and custom responsive CSS, making a huge emphasis on following design patterns and writing clean, unit-testable code that’s scalable on desktop and mobile"),
            new TextCard("Used Godot 4.0 to rapidly create prototypes of the software, making a number of FOSS contributions to update packages still on Godot 3.0’s API to Godot 4.0’s API, fixing breaking changes"),
            new TextCard("Helped write backend with ASP.NET Core using Azure as primary cloud hosting platform with Azure Storage for SPA hosting and Azure Functions for serverless calls"),
            new TextCard("Integration support for SQL Server, mySQL, CosmosDB, and MongoDB using an OData parser for universal data querying regardless of database"),
        }
    };
}
