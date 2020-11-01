using System;

namespace TeachMeSkills.DotNet.Lesson6.Examples
{
    internal class SimpleGeneric<T, V>
    {
        private const double coef = 1.2;

        public T Calories { get; set; }

        public V CalculationCalories()
        {
            dynamic calories = Calories; // Но так делать нельзя :)
            return (calories * coef).ToString();
        }
    }

    internal class GenericExample
    {
        public void Run()
        {
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
        }
    }
}
