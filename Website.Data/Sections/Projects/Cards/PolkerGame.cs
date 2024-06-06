using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Data.Interfaces;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Sections.Projects;

public sealed class PolkerGame : ISectionCard
{
    public static string Name { get; } = "Polker Game";

    public static DashboardCard Data { get; } = new()
    {
        Title = Name,
        Subtitle = ProfessionalExperience.Polker.Name,
        DetailCards = new()
        {
            new TextCard("Fully developed and integrated internal C++ plugins and subsystems used for our AWS and EOS backend"),
            new TextCard("Implemented chat, matchmaking, friends, and VOIP through EOS using both Unreal Engine’s Online Subsystem as well as EOS’ Web API"),
            new TextCard("Used both the Unreal Engine Replication system as well as implementing our custom validation through our Node.js backend to develop the multiplayer"),
            new TextCard("Collaborated with designers to create UI/UX and VFX using UMG and Niagara respectively"),
            new TextCard("Developed CI/CD pipelines with Jenkins to create new client and server-side testing builds hosted on AWS GameLift/EC2 and S3 on commits to our PlasticSCM repo"),
            new TextCard("Helped lead mass migration of project to Unreal Engine 5 to utilize upcoming features such as Lumen and Nanite and led push to AWS to make use of AWS-managed services (S3, Lambda, API Gateway, EC2) to simplify backend maintenance"),
            new TextCard("Organized infrastructure as code (IaC) for our AWS backend using Terraform"),
            new TextCard("Converted all game UI to use MVC pattern to simplify adding compatibility for mobile and VR"),
        }
    };
}
