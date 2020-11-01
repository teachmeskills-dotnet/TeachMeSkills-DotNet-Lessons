using System;

namespace TeachMeSkills.DotNet.Lesson3.Test
{
    internal class Parent
    {
        public bool? Gender { get; set; }

        public virtual void GetInfo()
        {
            Console.WriteLine(Gender);
        }
    }
}
