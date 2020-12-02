using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.BL
{
    public class Helper
    {
        public virtual (double a, double b) GetRandomNumbers()
        {
            var random = new Random();
            return (random.NextDouble(), random.NextDouble());
        }
    }
}
