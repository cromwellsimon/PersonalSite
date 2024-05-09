using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Website.Shared;

namespace Website.Data;

public static class UdemyCourseData
{
    public static readonly Lazy<ImmutableArray<Course>> Courses = new(() => new()
    {
        new("Complete Blender Creator: Learn 3D Modelling for Beginners", "https://www.udemy.com/course/blendertutorial/")
        {
            Review = "Very solid for all 3 versions of this that I watched. However, if I had to choose a favorite, I think the 2.7 version taught by Michael Bridges would be my preference. I remember it going into procedural shader generation and that was my first time ever getting into that, but it was glossed over on Grant Abbitt's version.",
            GeneralCompletionDate = new(2018, 12, 1),
            Notes = "Finished the original version for 2.7 taught by Mike, the 2.8 version also taught by Mike, and the current version taught by Grant Abbitt",
        },
        new("Discovering Godot", "https://www.udemy.com/course/discovering-godot/")
        {
            Review = "Unfortunately, I don't think I learned anything new as a result of watching this. I think I was too advanced for this course. However, I remember recommending this course to a friend of mine who was wanting to get into computer science prior to me having began to watch it and it was too advanced for him. I wouldn't recommend it to absolute beginners but if you've watched through a course or two, this is probably very good. I also remember Yann being very funny lol",
            GeneralCompletionDate = new(2023, 1, 1),
            Notes = "What is interesting about this course is that it originally was a GameDev.tv course but I guess that Michael Bridges and Yann Burrett broke off from GameDev.tv to make Canopy Games. I was somewhat surprised by this because, as explained in the course, Yann and Ben Tristem were friends for a very long time, seemingly going back since they were both in high school, so I'm curious on what caused the breakup but oh well, just a side rant.",
        },
        new("Complete C# Unity Game Developer 3D", "https://www.udemy.com/course/unitycourse2/"),
        new("How To Get A Job In The Video Game Industry", "https://www.udemy.com/course/gameindustryjobs/")
        {
            Review = """
            Actually gives very solid advice. There are a few pieces of advice that are given by Rick Davidson that I'm a little iffy about, namely creating an "artifact" for each place you apply to while I prefer to do something like that for each place that I hear back from. Also, I used to follow Rick's template for cover letters pretty closely but I found that it didn't really do much for me so I expanded it out to nearly a high-school level essay (an opener, 2-3 body paragraphs, conclusion) and that has been yielding better luck for me I think.
            """,
        },
        new("Blender Environment Artist: Create 3D Worlds", "https://www.udemy.com/course/blenderenvironment/")
        {
            Review = "Very good for both of the versions, however, in contrast to my thoughts in the Complete Blender Creator course, I actually believe that the version by Grant Abbitt was vastly superior. In fast, I'd probably wager that it, so far, has been my most favorite paid Blender course that I have watched thus far. Unfortunately, Grant still doesn't get any into procedural shaders or procedural mesh generation with Geometry Nodes but outside of that, Grant's version made for an extremely good refresher",
            GeneralCompletionDate = new(2018, 12, 15),
            Notes = "Finished the original version for 2.8 taught by Mike and the current version taught by Grant Abbitt",
        },
        new("Unity & Blender Masterclass: Make a 3D Zenda Game!", "https://www.udemy.com/course/build-the-legend-of-zenda-game-in-unity3d-and-blender/"),
        new("Complete C# Unity Game Developer 2D", "https://www.udemy.com/course/unitycourse/"),
        new("Unreal Engine 5 C++ Developer: Learn C++ & Make Video Games", "https://www.udemy.com/course/unrealcourse/")
        {
            Notes = "Finished the original version for Unreal Engine 4 taught by Ben Tristem himself, one of the only courses taught by him, and the current version taught by Sam Pattuzzi",
        },
        new("The Game Design and AI Master Class Beginner to Expert", "https://www.udemy.com/course/become-a-game-designer/"),
        new("Unreal Engine 4 - Learn to Make a Game Prototype in UE4", "https://www.udemy.com/course/unreal-engine-4-learn-to-make-a-game-prototype-in-ue4/"),
        new("Git Smart: Learn Git in Unity, SourceTree, GitHub", "https://www.udemy.com/course/git-smart-learn-git-the-fun-way-with-unity-games/"),
        new("Finish It! Motivation & Processes For Video Game Development", "https://www.udemy.com/course/finish-it/"),
        // The course for Udemy doesn't exist anymore but I watched it on Udemy
        new("Unity 3D Video Game Kit Introduction Online Course", "https://www.gamedev.tv/p/game-kit-3d"),
    });
}
