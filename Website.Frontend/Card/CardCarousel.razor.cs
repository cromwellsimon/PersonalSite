using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Shared;

namespace Website.Frontend.Card;

public partial class CardCarousel : ComponentBase
{
    [Parameter] public required Section Section { get; set; }
}
