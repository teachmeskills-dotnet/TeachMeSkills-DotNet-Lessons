using System;

namespace TeachMeSkills.DotNet.Lesson7
{
    public static class CommonMethods
    {
        public static void GoodMorning()
        {
            Console.WriteLine("Good morning!");
        }

        public static void GoodMorningWithName(string name)
        {
            Console.WriteLine($"Good morning, {name}!");
        }

        public static void GoodMorningWithNameAndAge(string name, int age)
        {
            Console.WriteLine($"Good morning, {name} {age}!");
        }

        public static bool CompareWithValue(int val)
        {
            return val > 10;
        }
    }
}
