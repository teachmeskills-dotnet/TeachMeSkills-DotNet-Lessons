using System;

namespace TeachMeSkills.DotNet.ZooManagement.Models
{
    public class Bird : AnimalBase<int>
    {
        public void Fly()
        {
            Console.WriteLine("I belive I can fly");
        }
    }
}
