using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Frontend.Card.Detail;

public partial class DetailCard : ComponentBase
{
	[Parameter] public RenderFragment? ChildContent { get; set; }
}
