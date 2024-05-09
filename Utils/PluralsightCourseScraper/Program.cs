using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PluralsightCourseScraper;

// Making this file as a demonstration to a friend of mine, the one that I'll actually use is the version titled "Program2"
internal class Program
{
    static void Main(string[] args)
    {
        List<Course> courses = new List<Course>();
        string[] lines = File.ReadAllLines("PluralsightProfile.html");
        string foundLine = "";
        int index = 0;
        while (index < lines.Length)
        {
            string line = lines[index];
            if (line.StartsWith("""<div id="app">"""))
            {
                foundLine = line;
                break;
            }
            index = index + 1;
        }
        XElement profileElement = XElement.Parse(foundLine);
        var foundElements = profileElement.Descendants("a");
        List<XElement> validElements = new List<XElement>();
        foreach (XElement element in foundElements)
        {
            // Continue from here
        }
    }
}

/// <summary>
/// Funny description here
/// </summary>
public class Course
{
    public string name;
    private string url;

    public void PrintUrl(string newUrl)
    {
        url = newUrl;
        Console.WriteLine(newUrl);
    }
}