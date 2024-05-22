using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Shared;

namespace Website.Frontend.Card.Dashboard;

public partial class DashboardCardCarousel : ComponentBase
{
    [Parameter] public required Section Section { get; set; }
}
