using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class LockExample
    {
        private int x = 0;
        private readonly object locker = new object();

        public void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                var myThread = new Thread(Count)
                {
                    Name = "Поток " + i.ToString()
                };

                myThread.Start();
            }
        }

        private void Count()
        {
            lock (locker)
            {
                x = 1;

                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
