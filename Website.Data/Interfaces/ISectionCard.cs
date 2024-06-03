using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Shared.Cards.Dashboard;
using Website.Shared.Cards.Detail;

namespace Website.Data.Interfaces;

public interface ISectionCard
{
    public abstract static string Name { get; }
    public abstract static DashboardCard Data { get; }
}
