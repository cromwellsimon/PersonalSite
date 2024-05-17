using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Website.Shared;

namespace Website.Data;

public static class GameDevTvCourseData
{
    // Update the links with the updated gamedev.tv links whenever the site refresh happens.
    // Tbh, I would not be terribly surprised if they were to disable inactive courses over the course of the site swap.
    public static readonly Lazy<ImmutableArray<Course>> Courses = new(() => new()
    {
        new("Unreal 4 C++ Multiplayer Master: Intermediate Game Development", "https://www.gamedev.tv/courses/635403"),
        new("Unreal Engine 5 C++ Multiplayer: Make Your Own Co-Op Game", "https://www.gamedev.tv/courses/2167831"),
        new("Unity Turn Based Strategy: Intermediate C# Coding", "https://www.gamedev.tv/courses/1722359"),
        new("Unity 3rd Person Combat & Traversal", "https://www.gamedev.tv/courses/1676087"),
        new("Unreal Engine 5 Blueprints: First Person Shooter (FPS)", "https://www.gamedev.tv/courses/1641814"),
        new("C++ Fundamentals: Game Programming For Beginners", "https://www.gamedev.tv/courses/1216775"),
        new("Low Poly Characters: Blender Bitesize Course", "https://www.gamedev.tv/courses/1526965"),
        new("Low Poly Landscapes: Blender Bite Sized Course", "https://www.gamedev.tv/courses/1462117"),
        new("Unity Mobile C# Developer Course", "https://www.gamedev.tv/courses/1313665"),
        new("Unity UIToolkit: Introduction To Editor Scripting", "https://www.gamedev.tv/courses/1548858"),
        new("Programming Design Patterns For Unity", "https://www.gamedev.tv/courses/1532483"),
        new("Intro To Data Oriented Tech Stack (DOTS) & ECS In Unity", "https://www.gamedev.tv/courses/1540032"),
        new("Unreal Engine 4 Blueprint Game Developer Online Course", "https://www.gamedev.tv/courses/635498"),
        new("Unreal Engine Cinematic Creator: Video Game Design Course", "https://www.gamedev.tv/courses/648367"),
        new("Unreal VR Dev: Make VR Experiences with Unreal Engine in C++", "https://www.gamedev.tv/courses/635398"),
        new("Math For Video Games: The Fastest Way To Get Smarter At Math", "https://www.gamedev.tv/courses/637024"),
        new("Godot 4 Shaders: Craft Stunning Visuals", "https://www.gamedev.tv/courses/2476576"),
    });
}
