using System;
using TeachMeSkills.DotNet.Lesson6.Interfaces;
using TeachMeSkills.DotNet.Lesson6.Models;

namespace TeachMeSkills.DotNet.Lesson6.Examples
{
    internal class ClassExample
    {
        public void Run()
        {
            var dog = new Dog
            {
                Name = "Dog1",
                Age = 1,
            };

            Console.WriteLine(((IGo)dog).Go(1));
            Console.WriteLine(((IMove)dog).Go(1));
        }
    }
}
