using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Shared;

public class Dashboard
{
    public List<Section> Sections { get; init; } = new();

    private int selectedSectionIndex = 0;
    public int SelectedSectionIndex
    {
        get => selectedSectionIndex;
        set => selectedSectionIndex = Math.Clamp(value, 0, Sections.Count);
    }

    public Section? SelectedSection
    {
        get
        {
            if (Sections.Count == 0)
            {
                return null;
            }
            else
            {
                return Sections[SelectedSectionIndex];
            }
        }
    }

    public Section? Up()
    {
        Section? section = this.PeekUp();
        if (section != null)
        {
            SelectedSectionIndex = Sections.IndexOf(section);
        }
        return section;
    }
    public Section? Down()
    {
        Section? section = this.PeekDown();
        if (section != null)
        {
            SelectedSectionIndex = Sections.IndexOf(section);
        }
        return section;
    }

    public Section? this[int key]
    {
        get => Sections[key];
        set
        {
            if (value != null)
            {
                Sections[key] = value;
            }
        }
    }
}

public static class DashboardStatics
{
    public static Section? PeekUp(this Dashboard inDashboard)
    {
        if (inDashboard.Sections.Count == 0)
        {
            return null;
        }
        return inDashboard.Sections.Rotate(inDashboard.SelectedSectionIndex, -1).First();
    }

    public static Section? PeekDown(this Dashboard inDashboard)
    {
        if (inDashboard.Sections.Count == 0)
        {
            return null;
        }
        return inDashboard.Sections.Rotate(inDashboard.SelectedSectionIndex, 1).First();
    }

    public static SectionAndStyle[] GetSectionsToDisplay(this Dashboard inDashboard, int numberOfSections = 5)
    {
        int fontSize = 32;
        float opacity = 1.0f;
        SectionAndStyle[] sectionStyles = new SectionAndStyle[numberOfSections];
        Section[] sections = inDashboard.Sections.Rotate(inDashboard.SelectedSectionIndex, -1).Take(numberOfSections - 1).ToArray();
        sectionStyles[0] = new()
        {
            Section = inDashboard.SelectedSection!,
            FontSize = fontSize,
            Opacity = opacity
        };
        for (int i = 0; i < sections.Length; i++)
        {
            fontSize -= 2;
            opacity -= 1.0f / numberOfSections;
            sectionStyles[i + 1] = new()
            {
                Section = sections[i],
                FontSize = fontSize,
                Opacity = opacity
            };
        }
        return sectionStyles;
    }
}