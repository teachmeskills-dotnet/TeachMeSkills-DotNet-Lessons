using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class MutexExample
    {
        private readonly Mutex mutexObj = new Mutex();
        private int x = 0;

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

        private void Count()
        {
            mutexObj.WaitOne();
            x = 1;

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }

            mutexObj.ReleaseMutex();
        }
    }
}
