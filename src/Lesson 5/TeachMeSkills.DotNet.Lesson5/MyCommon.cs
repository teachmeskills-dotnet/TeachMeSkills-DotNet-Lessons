using System;

namespace TeachMeSkills.DotNet.Lesson5
{
    public static class MyCommon
    {
        public static void GoodMorning()
        {
            Console.WriteLine("Good morning!");
        }

        public static void GoodMorningWithName(string name)
        {
            Console.WriteLine($"Good morning, {name}!");
        }

        public static void GoodMorningWithNameAndAge(string name, int ages)
        {
            Console.WriteLine($"Good morning, {name} {age}!");
        }
    }
}
