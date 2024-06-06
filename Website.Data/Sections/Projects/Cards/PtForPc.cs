using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class PtForPc : ISectionCard
{
    public static string Name { get; } = "P.T. for P.C.";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Independent.Name,
        DetailCards = new()
        {
            new TextCard("Fully playable remake of a Silent Hill game in Unreal Engine made while I was still in high school"),
            new TextCard("I re-programmed all the functionality from the original 1.5 hour-long game and re-implemented all shaders, VFX, post-processing, SFX, music, puzzles, enemy AI, and added VR support"),
            new TextCard("Received a great deal of press, getting covered in Polygon, Eurogamer, GameSpot, vg247, PC Gamer, and got a shoutout by Hideo Kojima, the director of the original game and the acclaimed Metal Gear Solid franchise"),
            new TextCard("Reached out to by Konami after a lot of publicity on the game and was flown out to Japan for an internship, followed by a job offer in Japan (which later turned into my time at Glowstick Entertainment due to COVID-19 travel restrictions)"),
        }
    };
}
