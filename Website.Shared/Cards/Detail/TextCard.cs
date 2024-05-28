using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Shared.Cards.Detail;

public class TextCard : IDetailCard
{
	public virtual RenderFragment? RenderFragment { get; }
	public string Title { get; set; } = String.Empty;
	public string Content { get; set; } = String.Empty;

	public TextCard() { }

	public TextCard(string inTitle, string inContent)
	{
		Title = inTitle;
		Content = inContent;
	}
}
