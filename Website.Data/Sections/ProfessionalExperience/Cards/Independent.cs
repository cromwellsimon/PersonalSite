using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;

namespace Website.Data.Sections.ProfessionalExperience;

public sealed class Independent : ISectionCard
{
    public static string Name { get; } = nameof(Independent);

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = "2016 - present",
        DetailCards = new()
        {

        }
    };
}
