using System;
using TeachMeSkills.DotNet.Lesson5.Models;

namespace TeachMeSkills.DotNet.Lesson5.Manager
{
    internal class CarManager
    {
        public void Run()
        {
            var car1 = new Car(100);
            Show(car1);
            Console.WriteLine("-----");

            var car2 = new Car(2);
            Show(car2);
            Console.WriteLine("-----");

            var car3 = new Car(12);
            Show(car3);
        }

        private void Show(Car car)
        {
            car.GetCurrentSpeed();
            car.Start();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.Stop();
            car.GetCurrentSpeed();
        }
    }
}
