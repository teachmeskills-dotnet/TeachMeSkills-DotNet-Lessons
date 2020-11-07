using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class ThreadStartExample
    {
        public void Run()
        {
            var myThread = new Thread(new ThreadStart(Helper.Count));
            myThread.Start();

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"Главный поток: {i * i}");
                Thread.Sleep(300);
            }
        }
    }
}
