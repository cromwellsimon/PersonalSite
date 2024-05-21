using System;
using System.Diagnostics.CodeAnalysis;

namespace Website.Shared;

public record Card
{
    public required string Title { get; init; } = String.Empty;
    public string Subtitle { get; init; } = String.Empty;
	// The Card in Blazor will use the ChildContent in order to display optional content in the center.
	// I was originally thinking of using only an Image but like I did with the UE Mockup but in hindsight,
	// it actually would have made more sense to use a NamedSlot in there because then I could put in anything, not just an image.
	// So, I'm going to do that here instead of having an ImageUrl or anything like that.
    
	public Card() { }

    [SetsRequiredMembers]
	public Card(string inTitle, string? inSubtitle = null)
    {
        Title = inTitle;
        if (inSubtitle != null)
        {
            Subtitle = inSubtitle;
        }
    }
}

public readonly record struct CardAndStyle(Card Card, float XPosition, float ZPosition, int ZIndex);