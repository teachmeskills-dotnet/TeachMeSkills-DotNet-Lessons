using System;

namespace TeachMeSkills.DotNet.Lesson5.Basics
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
