using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Frontend;

public partial class Dashboard : ComponentBase
{
	[Parameter] public required Shared.Dashboard Data { get; set; }

    private ElementReference contentDiv;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await contentDiv.FocusAsync();
        }
    }

    //https://stackoverflow.com/a/66710146
    public void Test(KeyboardEventArgs e)
	{
		Console.WriteLine(e.Key);
	}
}
