using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Website.Shared.Cards.Detail;
using static System.Collections.Specialized.BitVector32;

namespace Website.Shared.Cards;

public record DashboardCard
{
    public required string Title { get; init; } = string.Empty;
    public string Subtitle { get; init; } = string.Empty;
    // The Card in Blazor will use the ChildContent in order to display optional content in the center.
    // I was originally thinking of using only an Image but like I did with the UE Mockup but in hindsight,
    // it actually would have made more sense to use a NamedSlot in there because then I could put in anything, not just an image.
    // So, I'm going to do that here instead of having an ImageUrl or anything like that.

    public Func<RenderFragment>? Content { get; init; }
    public List<IDetailCard> DetailCards { get; init; } = new();

    private int? selectedCardIndex = null;
	public int? SelectedCardIndex
	{
		get => selectedCardIndex;
		set => selectedCardIndex = value.HasValue ? Math.Clamp(value.Value, 0, DetailCards.Count - 1) : null;
	}
	public IDetailCard? SelectedDetailCard
	{
		get => selectedCardIndex.HasValue ? DetailCards[selectedCardIndex.Value] : null;
	}

	public DashboardCard() { }

    [SetsRequiredMembers]
    public DashboardCard(string inTitle, string? inSubtitle = null, Func<RenderFragment>? inContent = null, List<IDetailCard>? inDetailCards = null)
    {
        Title = inTitle;
        if (inSubtitle != null)
        {
            Subtitle = inSubtitle;
        }
        if (inContent != null)
        {
            Content = inContent;
        }
        if (inDetailCards != null)
        {
            DetailCards = inDetailCards;
        }
    }
}

public readonly record struct DashboardCardAndStyle(DashboardCard Card, float XPosition, float ZPosition, int ZIndex);