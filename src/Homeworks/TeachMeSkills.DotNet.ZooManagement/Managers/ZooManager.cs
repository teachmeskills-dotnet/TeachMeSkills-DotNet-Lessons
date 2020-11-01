using System;
using System.Collections.Generic;
using TeachMeSkills.DotNet.ZooManagement.Interfaces;
using TeachMeSkills.DotNet.ZooManagement.Models;

namespace TeachMeSkills.DotNet.ZooManagement.Managers
{
    public class ZooManager : IZooManager, ICanInteract
    {
        public List<AnimalBase<int>> Animals { get; set; } = new List<AnimalBase<int>>();

        public void Show()
        {
            foreach (var animal in Animals)
            {
                Console.WriteLine($"Animal: {animal.Name}, {animal.Age}");
            }
        }

        public void YouCanInteractWithIt()
        {
            Animals.Add(new Fox
            {
                Name = "test",
                Age = 1,
            });

            Show();

            Console.WriteLine("Now you can!");
        }
    }
}
