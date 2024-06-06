using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class PersonalWebsite : ISectionCard
{
    public static string Name { get; } = "Personal Website (the one you're on now!)";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Independent.Name,
        DetailCards = new()
        {
            new TextCard("Inspired by Xbox 360 NXE UI just to invoke some nostalgia for late 2000s, early 2010s gamers to stand out"),
            new TextCard("Created website using C# and Blazor WebAssembly on the frontend"),
            new TextCard("Created a mockup in Unreal Engine 5 using UMG and nearly entirely C++"),
            new TextCard("Setup CI/CD through GitHub Actions to automate deployment of website"),
        }
    };
}
