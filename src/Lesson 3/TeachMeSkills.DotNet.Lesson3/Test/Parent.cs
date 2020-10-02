using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.Lesson3.Test
{
    class Parent
    {
        public bool? Gender { get; set; }

        public virtual void GetInfo()
        {
            Console.WriteLine(Gender);
        }
    }
}
