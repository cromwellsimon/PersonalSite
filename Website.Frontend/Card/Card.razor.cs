using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Frontend.Card;

public partial class Card : ComponentBase
{
    public static string TextSize = $"{24}px";

    [Parameter] public required Shared.Card CardData { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
}
