using System;

namespace TeachMeSkills.DotNet.ZooManagement.Models
{
    public class Fox : AnimalBase<int>
    {
        public void Say()
        {
            Console.WriteLine("What does the fox say?");
        }
    }
}
