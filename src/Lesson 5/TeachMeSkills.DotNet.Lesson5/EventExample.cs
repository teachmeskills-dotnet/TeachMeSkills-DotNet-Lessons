using System;

namespace TeachMeSkills.DotNet.Lesson5
{
    public class EventExample // (Shop)
    {
        //public delegate void GreatActionDefault(string str);
        //public event GreatActionDefault Notify;

        public event Action<string> Notify;

        public void Send(int number)
        {
            Console.WriteLine("Run send Method.");
            Notify?.Invoke($"Test message {number}");
        }
    }
}
