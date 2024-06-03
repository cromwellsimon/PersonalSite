using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Data.Sections.ProfessionalExperience;
using Website.Shared;

namespace Website.Data.Sections;

public sealed class ProfessionalExperienceSection : ISectionData
{
    public static Section Data { get; } = new()
    {
        Name = "Professional Experience",
        DashboardCards = new()
        {
            CromwellTechnology.Data,
            ElectricityGuruAndInternetGuru.Data,
            GlowstickEntertainment.Data,
            Polker.Data,
        },
    };
}
