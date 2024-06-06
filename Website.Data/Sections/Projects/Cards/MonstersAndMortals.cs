using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class MonstersAndMortals : ISectionCard
{
    public static string Name { get; } = "Monsters and Mortals";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.GlowstickEntertainment.Name,
        DetailCards = new()
        {
            new TextCard("Handled all C++ development that happened in the company, including online connectivity in games, porting projects to other platforms using their C++ SDKs, and running performance-intensive game processing"),
            new TextCard("Worked on porting library of games to other consoles (PS4, PS5, Nintendo Switch), operating systems, stores (Epic Games Store, Playstation Store and Nintendo eShop), and backends (EOS, PSN, NSO)"),
            new TextCard("Migrated multiplayer from ‘P2P’ to dedicated servers using AWS GameLift and EC2 which allowed for 50% more players in lobbies and drastically reduced pings and improved player experiences universally"),
            new TextCard("Created serverless backend with Python on AWS Lambda to auto-scale EC2 server instances based on load"),
            new TextCard("Managed all of the company’s AWS services, handled all of the branches and pull requests on our PlasticSCM repos, and ran all Epic Games and Steamworks services and releases by the company"),
            new TextCard("Diagnosed areas in game to optimize and roughly doubled GPU performance across all titles"),
            new TextCard("Diagnosed and fixed bugs in Unreal Engine source code which prohibited cross-play between platforms and broke AI on specific platforms"),
        }
    };
}
