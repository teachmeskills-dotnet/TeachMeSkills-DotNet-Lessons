using System;
using System.Threading;

namespace TeachMeSkills.DotNet.Lesson9.Examples
{
    internal class CurrentThreadExample
    {
        public void Run()
        {
            Thread t = Thread.CurrentThread;

            Console.WriteLine($"Имя потока: {t.Name}");
            t.Name = Guid.NewGuid().ToString();
            Console.WriteLine($"Имя потока: {t.Name}");

            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");

            Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");

            Console.ReadLine();
        }
    }
}
