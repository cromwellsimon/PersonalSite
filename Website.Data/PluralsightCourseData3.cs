using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Website.Shared;

namespace Website.Data;

public static class PluralsightCourseData3
{
    // Is making an ImmutableArray readonly redundant?
    public static readonly Lazy<ImmutableArray<Course>> Courses = new(() => new()
    {
    });
}
