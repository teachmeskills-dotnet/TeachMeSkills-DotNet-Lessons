using System;

namespace TeachMeSkills.DotNet.Lesson4
{
    public class SimpleGeneric<T, V>
    {
        private const double coef = 1.2;

        public T Calories { get; set; }

        public V CalculationCalories()
        {
            dynamic calories = Calories; // Но так делать нельзя :)
            return (calories * coef).ToString();
        }
    }
}
