using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class CommissionSystem : ISectionCard
{
    public static string Name { get; } = "Commission System";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.ElectricityGuruAndInternetGuru.Name,
        DetailCards = new()
        {
            new TextCard("Created CRM software with SplendidCRM base to automate commissions for their agents and referral partners imported from data given by their accountants’ spreadsheets"),
            new TextCard("Built with Class-based and Functional React frontend with Bootstrap for styling"),
            new TextCard("Developed commission functionality using ASP.NET Core backend and further ran those computations in parallel in order to increase the speed of the calculations by several orders of magnitude"),
            new TextCard("Used SQL Server for datastore and generated data-driven UI using SQL Views and Stored Procedures"),
            new TextCard("Integrated with QuickBooks Online to allow for automatic exporting and paying out of commissions to their sales agents and referral partners"),
            new TextCard("Developed CI/CD for project in Azure DevOps’ Pipelines to auto-deploy to Azure App Services and automatically generate the schemas and initial data in Azure SQL DB"),
        }
    };
}
