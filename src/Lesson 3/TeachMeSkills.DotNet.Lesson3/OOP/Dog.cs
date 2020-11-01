using System;

namespace TeachMeSkills.DotNet.Lesson3.OOP
{
    internal class Dog : Animal
    {
        public override int Age { get => base.Age; set => base.Age = value; }

        public void qwe()
        {
        }

        public override void SayHello()
        {
            Console.WriteLine("Gav");
        }

        public new void SayBye()
        {
            Console.WriteLine("Gav-Gav");
            base.SayBye();
        }
    }
}
