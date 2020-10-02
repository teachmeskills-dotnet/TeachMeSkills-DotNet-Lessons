using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.Lesson3.Test
{
    class Children : Parent
    {
        private string _name;
        public Children(bool? gender, string name)
        {
            Gender = gender;
            _name = name;
        }

        public override void GetInfo()
        {
            Console.WriteLine(_name);
            base.GetInfo();
        }
    }
}
