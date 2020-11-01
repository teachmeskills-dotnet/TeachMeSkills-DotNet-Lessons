using System;
using TeachMeSkills.DotNet.ZooManagement.Interfaces;
using TeachMeSkills.DotNet.ZooManagement.Managers;
using TeachMeSkills.DotNet.ZooManagement.Models;

namespace TeachMeSkills.DotNet.ZooManagement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fox = new Fox
            {
                Name = "Fox",
                Age = 1,
            };

            var bird = new Bird
            {
                Name = "Bird",
                Age = 2,
            };

            IZooManager zooManager = new ZooManager();
            zooManager.Animals.Add(fox);
            zooManager.Animals.Add(bird);

            fox.Say();
            bird.Fly();

            zooManager.Show();

            ICanInteract canInteract = new ZooManager();
            canInteract.YouCanInteractWithIt();

            Console.ReadKey();
        }
    }
}
