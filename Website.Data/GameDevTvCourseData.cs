using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Website.Shared;

namespace Website.Data;

public static class GameDevTvCourseData
{
    public static readonly Lazy<ImmutableArray<Course>> Courses = new(() => new()
    {
        new("Unreal 4 C++ Multiplayer Master: Intermediate Game Development", "https://www.gamedev.tv/courses/635403"),
        new("Unity 3D Video Game Kit Introduction Online Course", "https://www.gamedev.tv/courses/642029"),
        new("Unreal Engine Cinematic Creator: Video Game Design Course", "https://www.gamedev.tv/courses/648367"),
        new("Unreal VR Dev: Make VR Experiences with Unreal Engine in C++", "https://www.gamedev.tv/courses/635398"),
        new("Math For Video Games: The Fastest Way To Get Smarter At Math", "https://www.gamedev.tv/courses/637024?coupon_code=SPRINGQUEST"),
    });
}
