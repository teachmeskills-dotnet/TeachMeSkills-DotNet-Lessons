using System;

namespace TeachMeSkills.DotNet.Lesson3.Test
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
