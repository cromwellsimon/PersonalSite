using System.Collections.Generic;
using System.Linq;

namespace Website.Tests;

public class SectionTest
{
    public static List<int> GetSampleInts()
    {
        List<int> sampleInts = new();
        for (int i = 0; i < 10; i++)
        {
            sampleInts.Add(i);
        }
        return sampleInts;
    }

    [Fact]
    public void RotatingForward_RotatesForward()
    {
        List<int> sampleInts = GetSampleInts();
        List<int> newInts = sampleInts.Rotate(4, 1).Take(10).ToList();
        Assert.Equal(new List<int> { 5, 6, 7, 8, 9, 0, 1, 2, 3, 4 }, newInts);
    }

    [Fact]
    public void RotatingBackward_RotatesBackward()
    {
        List<int> sampleInts = GetSampleInts();
        List<int> newInts = sampleInts.Rotate(4, -1).Take(10).ToList();
        Assert.Equal(new List<int> { 3, 2, 1, 0, 9, 8, 7, 6, 5, 4 }, newInts);
    }

    public static Section GetSampleSection()
    {
        return new()
        {
            Name = "Sample Section",
            DashboardCards =
            {
                new() { Title = "Card 1" },
                new() { Title = "Card 2" },
                new() { Title = "Card 3" }
            },
            SelectedCardIndex = 1
        };
    }

    [Fact]
    public void PeekLeft_ReturnsCardToLeft()
    {
        Section section = GetSampleSection();
        Assert.Equal(section.DashboardCards[0], section.PeekLeft());
        Assert.Equal(1, section.SelectedCardIndex);
    }

    [Fact]
    public void PeekRight_ReturnsCardToRight()
    {
        Section section = GetSampleSection();
        Assert.Equal(section.DashboardCards[^1], section.PeekRight());
        Assert.Equal(1, section.SelectedCardIndex);
    }

    [Fact]
    public void Left_SetsToLeftCard()
    {
        Section section = GetSampleSection();
        section.Left();
        Assert.Equal(section.DashboardCards[0], section.SelectedCard);
    }

    [Fact]
    public void Right_SetsToRightCard()
    {
        Section section = GetSampleSection();
        section.Right();
        Assert.Equal(section.DashboardCards[^1], section.SelectedCard);
    }

    [Fact]
    public void Left_AtEnd_ReturnsLeftmostCard()
    {
        Section section = GetSampleSection();
        section.Left();
        Assert.Equal(section.DashboardCards[0], section.Left());
    }

    [Fact]
    public void Right_AtEnd_ReturnsRightmostCard()
    {
        Section section = GetSampleSection();
        section.Right();
        Assert.Equal(section.DashboardCards[^1], section.Right());
    }

    [Fact]
    public void PeekLeft_ReturnsNullWhenOutOfRange()
    {
        Section section = GetSampleSection();
        section.Left();
        Assert.Null(section.PeekLeft());
    }

    [Fact]
    public void PeekRight_ReturnsNullWhenOutOfRange()
    {
        Section section = GetSampleSection();
        section.Right();
        Assert.Null(section.PeekRight());
    }
}