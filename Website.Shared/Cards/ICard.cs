using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Shared.Cards.Dashboard;

namespace Website.Shared.Cards;

public interface ICard
{
}

public readonly record struct CardAndStyle(ICard Card, float XPosition, float ZPosition, int ZIndex);

public static class ICardStatics
{
	public static IEnumerable<CardAndStyle> GetCardsToDisplay(this IEnumerable<ICard> inCards, int inSelectedCardIndex, float inMargin = 0.05f)
	{
		int i = 0;
		foreach (ICard card in inCards)
		{
			// 100% is the size of the card and inMargin is how much margin-right each card has
			float xPosition = inSelectedCardIndex * -((1f + inMargin) * 100);
			float zPosition = i + 1 > inSelectedCardIndex ? -((i - inSelectedCardIndex) * 2) : 20f;
			yield return new(card, xPosition, zPosition, -i);
			i++;
		}
	}

	public static string GetCountText(this IEnumerable<ICard> inCards, int inSelectedCardIndex)
	{
		return $"{inSelectedCardIndex + 1} of {inCards.Count()}";
	}
}