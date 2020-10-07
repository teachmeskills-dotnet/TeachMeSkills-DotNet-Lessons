using System;

namespace TeachMeSkills.DotNet.Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog
            {
                Name = "Dog1",
                Age = 1,
            };

            var sg = new SimpleGeneric<int, string>
            {
                Calories = 1,
            };

            var sgNew = new SimpleGeneric<double, string>
            {
                Calories = 1.123,
            };

            Console.WriteLine(sg.CalculationCalories());
            Console.WriteLine(sgNew.CalculationCalories());

            Console.ReadKey();
        }
    }
}
