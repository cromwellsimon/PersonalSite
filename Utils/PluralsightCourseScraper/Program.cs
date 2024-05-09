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
        string[] lines = File.ReadAllLines(args[0]);
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
        List<XElement> validElements = foundElements
            .Where((element) =>
            {
                XAttribute attribute = element.Attribute("class");
                return attribute != null && attribute.Value.Contains("c66719c022472e356045");
            })
            .ToList();
        List<Course> courses = new List<Course>();
        foreach (XElement element in validElements)
        {
            Course course = new Course();
            course.name = element.Value;
            course.url = $"https://app.pluralsight.com{element.Attribute("href").Value}";
            courses.Add(course);
        }
        foreach (Course course in courses)
        {
            string finalString = $"{course.name} {course.url}";
        }
    }
}

/// <summary>
/// Funny description here
/// </summary>
public class Course
{
    public string name;
    public string url;

    public void PrintUrl(string newUrl)
    {
        url = newUrl;
        Console.WriteLine(newUrl);
    }

    public string GetName()
    {
        return name;
    }

    // """name,url"""
    public static Course Parse(string course)
    {
        string[] splitCourse = course.Split(',');
        Course newCourse = new Course();
        newCourse.name = splitCourse[0];
        newCourse.url = splitCourse[1];
        return newCourse;
    }
}

public static class CourseExtensions
{
    public static string GetUrl(this Course course)
    {
        return course.url;
    }

    public static bool GetValidAnchors(XElement element)
    {
        XAttribute attribute = element.Attribute("class");
        if (attribute != null && attribute.Value.Contains("c66719c022472e356045"))
        {
            return true;
        }
        return false;
    }
}