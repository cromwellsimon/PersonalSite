using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Shared;

public record DetailCard
{
    public Func<RenderFragment>? Content { get; init; }
}
