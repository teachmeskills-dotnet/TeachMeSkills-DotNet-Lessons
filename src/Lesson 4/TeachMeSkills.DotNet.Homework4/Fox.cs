using System;

namespace TeachMeSkills.DotNet.Homework4
{
    public class Fox : AnimalBase<int>
    {
        public void Say()
        {
            Console.WriteLine("What does the fox say?");
        }
    }
}
