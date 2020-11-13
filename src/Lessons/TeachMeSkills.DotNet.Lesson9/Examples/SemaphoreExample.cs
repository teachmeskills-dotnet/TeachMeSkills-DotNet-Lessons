using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class SemaphoreExample
    {
        private Semaphore _pool;
        private readonly Random _random = new Random();

        public void Run()
        {
            // Создаем семафор, который может работать сразу с тремя
            // одновременными запросами. Используем начальный счет 0,
            // так что изначально все семафоры
            // принадлежит основному потоку программы.
            _pool = new Semaphore(0, 3);

            // Создаем и запускаем 20 пронумерованных потоков.
            for (int i = 1; i <= 20; i++)
            {
                var t = new Thread(new ParameterizedThreadStart(Worker));
                t.Start(i);
            }

            Thread.Sleep(2000);

            Console.WriteLine("Основной поток вызывает Release(3).");
            _pool.Release(3);

            Console.WriteLine("Основной поток завершается.");
        }

        private void Worker(object num)
        {
            // Каждый рабочий поток начинается с запроса семафора.
            Console.WriteLine($"Поток {num} стартует и ожидает семафор.");
            _pool.WaitOne();

            Console.WriteLine("Поток {0} входит в семафор.", num);
            Thread.Sleep(_random.Next(1000, 2000));

            Console.WriteLine("Поток {0} освобождает семафор.", num);
            Console.WriteLine("Предыдущее количество семафоров в потоке {0}: {1}",
                num, _pool.Release());
        }
    }
}
