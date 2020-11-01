using System;

namespace TeachMeSkills.DotNet.Lesson5.Basics
{
    internal class Children : Parent
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
