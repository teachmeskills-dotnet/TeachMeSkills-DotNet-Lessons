using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9
{
    internal static class Helper
    {
        public static void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"Второй поток: {i * i}");
                Thread.Sleep(400);
            }
        }

        public static void Count(object obj)
        {
            for (int i = 1; i < 9; i++)
            {
                var counter = (Counter)obj;
                Console.WriteLine($"Второй поток: {i * counter.X * counter.Y}");
                Thread.Sleep(400);
            }
        }
    }
}
