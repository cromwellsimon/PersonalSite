using System;

namespace Website.Shared;

public record Course(string Name, string Url, string? Review = null, DateOnly? GeneralCompletionDate = null, string? Notes = null);
