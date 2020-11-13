using System;
using TeachMeSkills.DotNet.Lesson9.Examples;

namespace TeachMeSkills.DotNet.Lesson9
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var currentThreadExample = new CurrentThreadExample();
            //currentThreadExample.Run();

            //var threadStartExample = new ThreadStartExample();
            //threadStartExample.Run();

            //var parameterizedThreadStartExample = new ParameterizedThreadStartExample();
            //parameterizedThreadStartExample.Run();

            //var lockExample = new LockExample();
            //lockExample.Run();

            //var monitor = new MonitorExample();
            //monitor.Run();

            //var mutex = new MutexExample();
            //mutex.Run();

            var semaphoreExample = new SemaphoreExample();
            semaphoreExample.Run();

            //var semaphoreSlimExample = new SemaphoreSlimExample();
            //semaphoreSlimExample.Run();

            Console.ReadKey();
        }
    }
}
