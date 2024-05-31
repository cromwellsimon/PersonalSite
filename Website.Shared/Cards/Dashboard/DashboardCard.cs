using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Website.Shared.Cards.Detail;
using static System.Collections.Specialized.BitVector32;

namespace Website.Shared.Cards.Dashboard;

public record DashboardCard : ICard
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

    public IDetailCard? Right()
    {
        if (SelectedCardIndex.HasValue == false)
        {
            return null;
        }
        SelectedCardIndex += 1;
        return SelectedDetailCard;
    }

    public IDetailCard? Left()
    {
        if (SelectedCardIndex.HasValue == false)
        {
            return null;
        }
        SelectedCardIndex -=  1;
        return SelectedDetailCard;
    }
}

public readonly record struct DashboardCardAndStyle(DashboardCard Card, float XPosition, float ZPosition, int ZIndex);

public static class DashboardCardStatics
{
    public static IDetailCard? EnterDetailView(this DashboardCard inDashboardCard)
    {
        if (inDashboardCard.DetailCards.Count == 0)
        {
            return null;
        }
        inDashboardCard.SelectedCardIndex = 0;
        return inDashboardCard.SelectedDetailCard;
    }

    public static void ExitDetailView(this DashboardCard inDashboardCard)
    {
        inDashboardCard.SelectedCardIndex = null;
    }

	public static IDetailCard? PeekLeft(this DashboardCard inDashboardCard)
	{
		if (inDashboardCard.SelectedCardIndex.HasValue == false || inDashboardCard.SelectedCardIndex - 1 < 0)
		{
			return null;
		}
		return inDashboardCard.DetailCards[Math.Clamp(inDashboardCard.SelectedCardIndex.Value - 1, 0, inDashboardCard.DetailCards.Count - 1)];
	}

	public static IDetailCard? PeekRight(this DashboardCard inDashboardCard)
	{
		if (inDashboardCard.SelectedCardIndex.HasValue == false || inDashboardCard.SelectedCardIndex + 1 >= inDashboardCard.DetailCards.Count)
		{
			return null;
		}
		return inDashboardCard.DetailCards[Math.Clamp(inDashboardCard.SelectedCardIndex.Value + 1, 0, inDashboardCard.DetailCards.Count - 1)];
	}

    public static IEnumerable<CardAndStyle> GetCardsToDisplay(this DashboardCard inDashboardCard)
	{
        if (inDashboardCard.SelectedCardIndex == null)
        {
            return Enumerable.Empty<CardAndStyle>();
        }
        return ICardStatics.GetCardsToDisplay(inDashboardCard.DetailCards, inDashboardCard.SelectedCardIndex.Value);
	}
	public static string GetCountText(this DashboardCard inDashboardCard) => inDashboardCard.DetailCards.GetCountText(inDashboardCard.SelectedCardIndex!.Value);
}