using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Frontend.Card.Dashboard;

public partial class DashboardCard : ComponentBase
{
    public static string TextSize = $"{24}px";

    [Parameter] public required Shared.DashboardCard CardData { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
}
