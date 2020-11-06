using System;

namespace TeachMeSkills.DotNet.FitnessTrackerCore.Manager
{
    public static class NotificationManager
    {
        public static void Show(string message, DateTime dateTime)
        {
            Console.WriteLine($"{message} {dateTime}");
        }
    }
}
