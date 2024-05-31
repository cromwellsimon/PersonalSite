using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Frontend.Card;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Frontend;

public partial class Dashboard : ComponentBase
{
	[Parameter] public required Shared.Dashboard DashboardData { get; set; }

    private ElementReference contentDiv;

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

        DashboardCard? selectedDashboardCard = DashboardData.SelectedSection?.SelectedCard;
        IDetailCard? selectedDetailCard = selectedDashboardCard?.SelectedDetailCard;

        switch (e.Key)
        {
            case "ArrowUp":
                if (selectedDetailCard == null)
				{
					DashboardData.Up();
				}
                break;
            case "ArrowDown":
                if (selectedDetailCard == null)
				{
					DashboardData.Down();
				}
                break;
            case "ArrowLeft":
                if (selectedDetailCard == null)
				{
					DashboardData.SelectedSection?.Left();
				}
                else
                {
                    selectedDashboardCard!.Left();
                }
                break;
            case "ArrowRight":
                if (selectedDetailCard == null)
				{
					DashboardData.SelectedSection?.Right();
				}
                else
                {
                    selectedDashboardCard!.Right();
                }
                break;
            case "Enter":
                if (selectedDashboardCard != null && selectedDetailCard == null)
                {
                    selectedDashboardCard.SelectedCardIndex = 0;
                }
                break;
            case "Backspace":
                if (selectedDashboardCard != null)
                {
                    selectedDashboardCard.SelectedCardIndex = null;
                }
                break;
        }
	}
}
