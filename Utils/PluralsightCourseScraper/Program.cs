using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PluralsightCourseScraper;

/// <summary>
/// This will take in the contents of PluralsightProfile.html and parse out all of the Completed Courses from it into the Course record as specified in my Website.Shared.
/// The completed file will be called ParsedCourses.txt and it should be good to just Ctrl+A, Ctrl+C, and Ctrl+V.
/// The file gets output to the same folder as your executable. If you are running this in debug, it can be found under bin/Debug/net8.0 at the time of writing since that is where the executable gets placed.
/// </summary>
internal class Program
{
    /// <summary>
    /// The class ID used for the relevant anchor links.
    /// Because Pluralsight uses React.js, a class name is programmatically generated for some queries and CSS isolation.
    /// </summary>
    const string className = "c66719c022472e356045";
    /// <summary>
    /// The path name of the file that contains the saved Pluralsight Profile.
    /// In order to generate this file, all you have to do is go to a Pluralsight profile, expand all of the completed courses, hit F12, go to Elements,
    /// then scroll to the top <html> tag, right-click and select "Edit as HTML", then Ctrl+A, Ctrl+C, Ctrl+V into PluralsightProfile.html.
    /// I tried doing this all through just sending a GET request to the site itself but, after skirting around CORS issues, I was not able to get the info I needed through just that.
    /// </summary>
    static string pluralsightProfilePath = "PluralsightProfile.html";
    const string pluralsightBaseUrl = "https://app.pluralsight.com";
    /// <summary>
    /// The text that the line for the relevant HTML starts with.
    /// XElement obviously can't parse JavaScript or CSS so putting this here is necessary in order to actually find the relevant HTML
    /// </summary>
    const string appStart = """<div id="app">""";
    /// <summary>
    /// The name of the file to put the final list of Courses. This can be anything.
    /// As stated above, this will be found in the same folder as your executable which means that it would be in bin/Debug/net8.0 if running in debug.
    /// </summary>
    static string parsedCoursesPath = "ParsedCourses.txt";

    static void Main(string[] args)
    {
        if (args.Length >= 1)
        {
            pluralsightProfilePath = args[0];
        }
        if (args.Length >= 2)
        {
            parsedCoursesPath = args[1];
        }
        string? pluralsightProfileText = null;
        using (StreamReader pluralsightProfileFile = File.OpenText(pluralsightProfilePath))
        {
            while (string.IsNullOrWhiteSpace(pluralsightProfileText))
            {
                string? line = pluralsightProfileFile.ReadLine();
                if (line != null && line.StartsWith(appStart))
                {
                    pluralsightProfileText = line;
                }
            }
        }
        if (string.IsNullOrWhiteSpace(pluralsightProfileText) )
        {
            Console.WriteLine($"{appStart} could not be found at the start of any lines in {pluralsightProfilePath}. Make sure that it is set properly!");
        }

        XElement pluralsightProfile = XElement.Parse(pluralsightProfileText);
        var validElements = pluralsightProfile.Descendants("a")
            .Where((element) =>
            {
                if (element.Attribute("class") is XAttribute attribute && attribute.Value.StartsWith(className))
                {
                    return true;
                }
                return false;
            });
        
        if (validElements.Any() == false) 
        {
            Console.WriteLine("No elements could be found");
            return;
        }
        StringBuilder pluralsightCourseData = new();
        foreach (XElement element in validElements)
        {
            pluralsightCourseData.AppendLine($@"new(""{element.Value}"", ""{pluralsightBaseUrl}{element.Attribute("href")!.Value}""),");
        }
        File.WriteAllText(parsedCoursesPath, pluralsightCourseData.ToString());
    }
}
