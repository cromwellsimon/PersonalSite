using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Tests;

// I do not like using things like bUnit and other frontend-testing frameworks for unit testing, they're way too fragile and verbose for my liking.
// No disrespect to them though, it's just not my cup of tea (I don't like tea either though...).
// As I've explained probably several other times in this, I prefer working with POCOs and then making wrappers around them for the UI.
// I can know that the functionality for everything works as expected through the unit tests and the UI wrappers are purely visualizers essentially, nothing more.
// This is my preferred way working with nearly everything at this point. It's somewhat similar to how MVC works but for even projects that have no backend server of any kind.
public class DashboardTest
{
    public static Dashboard GetSampleDashboard()
    {
        return new()
        {
            Sections =
            {
                new()
                {
                    Name = "Section 1",
                    Cards =
                    {
                        new() { Title = "Card 1" },
                        new() { Title = "Card 2" },
                    }
                },
                new()
                {
                    Name = "Section 2",
                    Cards =
                    {
                        new() { Title = "Card 1" },
                    }
                },
                new()
                {
                    Name = "Section 3",
                    Cards =
                    {
                        new() { Title = "Card 1" },
                        new() { Title = "Card 2" },
                        new() { Title = "Card 3" },
                    },
                    SelectedCardIndex = 1
                }
            },
            SelectedSectionIndex = 1
        };
    }

    [Fact]
    public void Up_GetsUpwardSection()
    {
        Dashboard dashboard = GetSampleDashboard();
        Assert.Equal(dashboard.Sections[0], dashboard.Up());
    }

    [Fact]
    public void Down_GetsDownwardSection()
    {
        Dashboard dashboard = GetSampleDashboard();
        Assert.Equal(dashboard.Sections[^1], dashboard.Down());
    }

    [Fact]
    public void PeekUp_PeeksUpwardSection()
    {
        Dashboard dashboard = GetSampleDashboard();
        Assert.Equal(dashboard.Sections[0], dashboard.PeekUp());
        Assert.Equal(dashboard.Sections[1], dashboard.SelectedSection);
    }

    [Fact]
    public void PeekDown_PeeksDownwardSection()
    {
        Dashboard dashboard = GetSampleDashboard();
        Assert.Equal(dashboard.Sections[2], dashboard.PeekDown());
        Assert.Equal(dashboard.Sections[1], dashboard.SelectedSection);
    }

    [Fact]
    public void Up_RotatesToOtherEnd()
    {
        Dashboard dashboard = GetSampleDashboard();
        dashboard.Up();
        Assert.Equal(dashboard.Sections[^1], dashboard.Up());
    }

    [Fact]
    public void Down_RotatesToOtherEnd()
    {
        Dashboard dashboard = GetSampleDashboard();
        dashboard.Down();
        Assert.Equal(dashboard.Sections[0], dashboard.Down());
    }

    [Fact]
    public void PeekUp_RotatesToOtherEnd()
    {
        Dashboard dashboard = GetSampleDashboard();
        dashboard.Up();
        Assert.Equal(dashboard.Sections[^1], dashboard.PeekUp());
    }

    [Fact]
    public void PeekDown_RotatesToOtherEnd()
    {
        Dashboard dashboard = GetSampleDashboard();
        dashboard.Down();
        Assert.Equal(dashboard.Sections[0], dashboard.PeekDown());
    }

    [Fact]
    public void GetSectionsToDisplay_ReturnsSectionsAndStyles()
    {
        Dashboard dashboard = GetSampleDashboard();
        SectionAndStyle[] sections = dashboard.GetSectionsToDisplay();
        Assert.Equal(new List<int> { 32, 30, 28, 26, 24 }, sections.Select((section) => section.FontSize));
        Assert.Equal(new List<float> { 1.0f, 0.8f, 0.6f, 0.4f, 0.2f }, sections.Select((section) => float.Round(section.Opacity, 1)));
        Assert.Equal(new List<Section> { dashboard[1]!, dashboard[0]!, dashboard[2]!, dashboard[1]!, dashboard[0]! }, sections.Select((section) => section.Section));
    }
}
