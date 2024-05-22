using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Website.Shared;

public record DashboardCard
{
    public required string Title { get; init; } = String.Empty;
    public string Subtitle { get; init; } = String.Empty;
    // The Card in Blazor will use the ChildContent in order to display optional content in the center.
    // I was originally thinking of using only an Image but like I did with the UE Mockup but in hindsight,
    // it actually would have made more sense to use a NamedSlot in there because then I could put in anything, not just an image.
    // So, I'm going to do that here instead of having an ImageUrl or anything like that.

    public Func<RenderFragment>? Content { get; init; }
    public List<DetailCard> DetailCards { get; init; } = new();
    
	public DashboardCard() { }

    [SetsRequiredMembers]
	public DashboardCard(string inTitle, string? inSubtitle = null, Func<RenderFragment>? inContent = null, List<DetailCard>? inDetailCards = null)
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