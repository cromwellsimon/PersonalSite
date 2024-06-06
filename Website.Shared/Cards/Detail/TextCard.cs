using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Shared.Cards.Detail;

public record TextCard : IDetailCard
{
	public string Text { get; set; } = String.Empty;

	public TextCard() { }

	public TextCard(string inText)
	{
		Text = inText;
	}
}
