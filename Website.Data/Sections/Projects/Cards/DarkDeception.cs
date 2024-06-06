using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class DarkDeception : ISectionCard
{
    public static string Name { get; } = "Dark Deception";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.GlowstickEntertainment.Name,
        DetailCards = new()
        {
            new TextCard("Handled all C++ development that happened in the company, including online connectivity in games, porting projects to other platforms using their C++ SDKs, and running performance-intensive game processing"),
            new TextCard("Worked on porting library of games to other consoles (PS4, PS5, Nintendo Switch), operating systems, stores (Epic Games Store, Playstation Store and Nintendo eShop), and backends (EOS, PSN, NSO)"),
            new TextCard("Managed all of the company’s AWS services, handled all of the branches and pull requests on our PlasticSCM repos, and ran all Epic Games and Steamworks services and releases by the company."),
            new TextCard("Diagnosed areas in game to optimize and roughly doubled GPU performance across all titles")
        }
    };
}
