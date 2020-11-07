using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class MonitorExample
    {
        private int x = 0;
        private readonly object locker = new object();

        public void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count)
                {
                    Name = $"Поток {i}"
                };

                myThread.Start();
            }

            Console.ReadLine();
        }

        public void Count()
        {
            bool acquiredLock = false;

            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }
            finally
            {
                if (acquiredLock) Monitor.Exit(locker);
            }
        }
    }
}
