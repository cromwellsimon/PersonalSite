using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Website.Shared.Cards;
using Website.Shared.Cards.Dashboard;
using static System.Collections.Specialized.BitVector32;

namespace Website.Shared;

public readonly record struct SectionName(string Value)
{
    public static implicit operator SectionName(string inString) => new(inString);
}

public class Section
{
    public required SectionName Name { get; init; }
    public List<DashboardCard> DashboardCards { get; init; } = new();

    private int selectedCardIndex = 0;
    public int SelectedCardIndex
    {
        get => selectedCardIndex;
        set => selectedCardIndex = Math.Clamp(value, 0, DashboardCards.Count - 1);
    }

    public DashboardCard? SelectedCard
    {
        get
        {
            if (DashboardCards.Count == 0)
            {
                return null;
            }
            else
            {
                return DashboardCards[SelectedCardIndex];
            }
        }
    }

    public DashboardCard? Left()
    {
        if (DashboardCards.Count == 0)
        {
            return null;
        }
        SelectedCardIndex -= 1;
        return DashboardCards[SelectedCardIndex];
    }

    public DashboardCard? Right()
    {
        if (DashboardCards.Count == 0)
        {
            return null;
        }
        SelectedCardIndex += 1;
        return DashboardCards[SelectedCardIndex];
    }

    public DashboardCard? this[int key]
    {
        get => DashboardCards[key];
        set
        {
            if (value != null)
            {
                DashboardCards[key] = value;
            }
        }
    }
}

public readonly record struct SectionAndStyle(Section Section, float Opacity, float Ems);

public static class SectionStatics
{
    /// <remarks>
    /// Call this with a .Take() or else you'll cause an infinite loop
    /// </remarks>
    public static IEnumerable<T> Rotate<T>(this IList<T> inList, int inStartingPosition, int inInterval)
    {
        int index = inStartingPosition + inInterval;
        int count = inList.Count;
        while (true)
        {
            if (inInterval > 0 && index >= count)
            {
                index = 0 + (index - count);
                continue;
            }
            else if (inInterval < 0 && index < 0)
            {
                // index is negative here so count + index reduces the number
                index = count + index;
            }
            yield return inList[index];
            index += inInterval;
        }
    }

    // This function won't actually be necessary for what I'm doing since I only need my sections to ever go backwards and my cards don't loop
    public static IEnumerable<T> Carousel<T>(this IList<T> inList, int inStartingPosition, int inBackwardPadding, int inForwardPadding)
    {
        foreach (T element in inList.Rotate(inStartingPosition, -1).Take(inBackwardPadding).Reverse())
        {
            yield return element;
        }

        yield return inList[inStartingPosition];

        foreach (T element in inList.Rotate(inStartingPosition, 1).Take(inForwardPadding))
        {
            yield return element;
        }
    }

    public static string GetCountText(this Section inSection) => inSection.DashboardCards.GetCountText(inSection.SelectedCardIndex);

    public static DashboardCard? PeekLeft(this Section inSection)
    {
        if (inSection.DashboardCards.Count == 0 || inSection.SelectedCardIndex - 1 < 0)
        {
            return null;
        }
        return inSection.DashboardCards[Math.Clamp(inSection.SelectedCardIndex - 1, 0, inSection.DashboardCards.Count - 1)];
    }

    public static DashboardCard? PeekRight(this Section inSection)
    {
        if (inSection.DashboardCards.Count == 0 || inSection.SelectedCardIndex + 1 >= inSection.DashboardCards.Count)
        {
            return null;
        }
        return inSection.DashboardCards[Math.Clamp(inSection.SelectedCardIndex + 1, 0, inSection.DashboardCards.Count - 1)];
    }

    public static IEnumerable<DashboardCardAndStyle> GetCardsToDisplay(this Section inSection)
    {
        return ICardStatics.GetCardsToDisplay(inSection.DashboardCards.Cast<ICard>().ToList(), inSection.SelectedCardIndex)
            .Select((element) => new DashboardCardAndStyle((DashboardCard)element.Card, element.XPosition, element.ZPosition, element.ZIndex));
    }
}