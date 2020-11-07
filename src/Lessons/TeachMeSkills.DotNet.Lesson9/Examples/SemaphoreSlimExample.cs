using System;
using System.Threading;
using System.Threading.Tasks;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class SemaphoreSlimExample
    {
        private SemaphoreSlim semaphore;
        private readonly Random _random = new Random();

        public void Run()
        {
            semaphore = new SemaphoreSlim(0, 3);
            Console.WriteLine($"{semaphore.CurrentCount} задач в семафоре..");
            Task[] tasks = new Task[20];

            // Создаем и запускаем пять пронумерованных задач.
            for (int i = 0; i <= 19; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    // Каждая задача начинается с запроса семафора.
                    Console.WriteLine($"Задача {Task.CurrentId} начинается и ожидает семафор.");
                    semaphore.Wait();

                    int semaphoreCount;

                    try
                    {
                        Console.WriteLine("Задача {0} входит в семафор.", Task.CurrentId);
                        Thread.Sleep(_random.Next(1000, 2000));
                    }
                    finally
                    {
                        semaphoreCount = semaphore.Release();
                    }

                    Console.WriteLine($"Задача {Task.CurrentId} освобождает семафор; предыдущий счетчик: {semaphoreCount}.");
                });
            }

            // Ждем 2 секунды, чтобы все задачи запустились и заблокировались.
            Thread.Sleep(2000);

            Console.WriteLine("Основной поток вызывает Release(3) --->");
            semaphore.Release(3);

            // Основной поток ожидает завершения задач.
            Task.WaitAll(tasks);

            Console.WriteLine("Основной поток завершается.");
        }
    }
}
