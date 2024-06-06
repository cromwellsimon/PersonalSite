using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class LarueCountyTreasuryWebsite : ISectionCard
{
    public static string Name { get; } = "LaRue County Treasury Website";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.GlowstickEntertainment.Name,
        DetailCards = new()
        {
            new TextCard("Took the designs from the county and their supplied images to make a website for the LaRue County Treasurer as a high school project which was used for the actual website"),
            new TextCard("Ironically, they no longer have a website because I think that they failed to continue paying for the hosting fees"),
        }
    };
}
