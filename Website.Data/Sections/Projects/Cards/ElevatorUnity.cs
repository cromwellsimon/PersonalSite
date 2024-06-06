using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class ElevatorUnity : ISectionCard
{
    public static string Name { get; } = "Elevator: Unity";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Independent.Name,
        DetailCards = new()
        {
            new TextCard("Developed all models, entirely based on real-world reference and measurements, using Blender"),
            new TextCard("Created all textures using my own procedural shaders in Blender baked into seamless textures"),
            new TextCard("Used Unity tooling tools to build all the VFX, post-processing, audio reverb/effects, and HDRP shaders"),
            new TextCard("Programmed all game functionality including player control and interactions, AI, scene sequences, VR functionality, etc. in C#"),
        }
    };
}
