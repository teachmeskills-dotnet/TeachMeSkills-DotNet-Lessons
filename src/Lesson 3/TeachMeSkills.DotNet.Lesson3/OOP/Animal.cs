using System;

namespace TeachMeSkills.DotNet.Lesson3.OOP
{
    public class Animal
    {
        private int Weight { get; set; }
        protected string Brand { get; set; }
        public virtual int Age { get; set; } = 1;

        public readonly int legs = 4;

        public virtual void SayHello()
        {
            Console.WriteLine("Animal");
        }

        public void SayBye()
        {
            Console.WriteLine("Animal");
        }
    }
}
