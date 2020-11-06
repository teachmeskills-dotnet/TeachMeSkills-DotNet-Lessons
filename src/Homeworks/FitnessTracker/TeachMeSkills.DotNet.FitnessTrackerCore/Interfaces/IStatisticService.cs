using System;
using System.Collections.Generic;
using System.Text;
using TeachMeSkills.DotNet.FitnessTrackerCore.Models;

namespace TeachMeSkills.DotNet.FitnessTrackerCore.Interfaces
{
    public interface IStatisticService
    {
        Statistic Get(User user, IEnumerable<int> data);
    }
}
