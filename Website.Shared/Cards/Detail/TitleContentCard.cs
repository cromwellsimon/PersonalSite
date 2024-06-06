using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Shared.Cards.Detail;

public record TitleContentCard : IDetailCard
{
	public string Title { get; set; } = String.Empty;
	public string Content { get; set; } = String.Empty;

	public TitleContentCard() { }

	public TitleContentCard(string inTitle, string inContent)
	{
		Title = inTitle;
		Content = inContent;
	}
}
