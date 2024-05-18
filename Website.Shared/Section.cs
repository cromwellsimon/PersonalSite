using System;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Website.Shared;

public readonly record struct SectionName(string Value)
{
    public static implicit operator SectionName(string inString) => new(inString);
}

public class Section
{
    public required SectionName Name { get; init; }
    public List<Card> Cards { get; init; } = new();

    private int selectedCardIndex = 0;
    public int SelectedCardIndex
    {
        get => selectedCardIndex;
        set => selectedCardIndex = Math.Clamp(value, 0, Cards.Count - 1);
    }

    public Card? SelectedCard
    {
        get
        {
            if (Cards.Count == 0)
            {
                return null;
            }
            else
            {
                return Cards[SelectedCardIndex];
            }
        }
    }

    public Card? Left()
    {
        if (Cards.Count == 0)
        {
            return null;
        }
        SelectedCardIndex -= 1;
        return Cards[SelectedCardIndex];
    }

    public Card? Right()
    {
        if (Cards.Count == 0)
        {
            return null;
        }
        SelectedCardIndex += 1;
        return Cards[SelectedCardIndex];
    }

    public Card? this[int key]
    {
        get => Cards[key];
        set
        {
            if (value != null)
            {
                Cards[key] = value;
            }
        }
    }
}

public readonly record struct SectionAndStyle(Section Section, float Opacity, int FontSize);

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

    // This function won't actually be necessary for what I'm doing since I only need it my sections to ever go backwards
    public static IEnumerable<T> Roulette<T>(this IList<T> inList, int inStartingPosition, int inBackwardPadding, int inForwardPadding)
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

    public static string GetCountText(this Section inSection)
    {
        return $"{inSection.SelectedCardIndex + 1} of {inSection.Cards.Count}";
    }

    public static Card? PeekLeft(this Section inSection)
    {
        if (inSection.Cards.Count == 0 || inSection.SelectedCardIndex - 1 < 0)
        {
            return null;
        }
        return inSection.Cards[Math.Clamp(inSection.SelectedCardIndex - 1, 0, inSection.Cards.Count - 1)];
    }

    public static Card? PeekRight(this Section inSection)
    {
        if (inSection.Cards.Count == 0 || inSection.SelectedCardIndex + 1 >= inSection.Cards.Count)
        {
            return null;
        }
        return inSection.Cards[Math.Clamp(inSection.SelectedCardIndex + 1, 0, inSection.Cards.Count - 1)];
    }
}