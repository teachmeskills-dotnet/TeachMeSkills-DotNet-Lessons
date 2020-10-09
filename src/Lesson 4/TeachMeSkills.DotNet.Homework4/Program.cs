using System;
using System.Collections.Generic;

namespace TeachMeSkills.DotNet.Homework4
{
    class Program
    {
        static void Main(string[] args)
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
