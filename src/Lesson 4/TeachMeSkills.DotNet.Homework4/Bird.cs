using System;

namespace TeachMeSkills.DotNet.Homework4
{
    public class Bird : AnimalBase<int>
    {
        public void Fly()
        {
            Console.WriteLine("I belive I can fly");
        }
    }
}
