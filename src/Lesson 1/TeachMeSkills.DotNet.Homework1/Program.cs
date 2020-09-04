using System;

namespace TeachMeSkills.DotNet.Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your date: ");
            string userInput = Console.ReadLine();
            bool result = DateTime.TryParse(userInput, out DateTime date);
            if (result)
            {
                Console.WriteLine(date.DayOfWeek);
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }

            Console.ReadLine();
        }
    }
}
