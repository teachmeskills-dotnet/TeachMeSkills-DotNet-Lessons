using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class ParameterizedThreadStartExample
    {
        public void Run()
        {
            var counter = new Counter
            {
                X = 4,
                Y = 5
            };

            var myThread = new Thread(new ParameterizedThreadStart(Helper.Count));
            myThread.Start(counter);

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"Главный поток: {i * i}");
                Thread.Sleep(300);
            }
        }
    }
}
