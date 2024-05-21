using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Frontend.Card;

namespace Website.Frontend;

public partial class Dashboard : ComponentBase
{
	[Parameter] public required Shared.Dashboard DashboardData { get; set; }

    private ElementReference contentDiv;
    private CardCarousel? cardCarousel;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await contentDiv.FocusAsync();
        }
    }

    //https://stackoverflow.com/a/66710146
    public void OnInput(KeyboardEventArgs e)
	{
        Console.WriteLine(e.Key);

        switch (e.Key)
        {
            case "ArrowUp":
                DashboardData.Up();
                break;
            case "ArrowDown":
                DashboardData.Down();
                break;
            case "ArrowLeft":
                DashboardData.SelectedSection?.Left();
                break;
            case "ArrowRight":
                DashboardData.SelectedSection?.Right();
                break;
        }
	}
}
