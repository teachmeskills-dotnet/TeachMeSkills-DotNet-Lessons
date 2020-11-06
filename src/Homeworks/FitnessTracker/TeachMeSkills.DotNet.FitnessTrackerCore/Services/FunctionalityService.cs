using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeachMeSkills.DotNet.FitnessTrackerCore.Interfaces;
using TeachMeSkills.DotNet.FitnessTrackerCore.Models;

namespace TeachMeSkills.DotNet.FitnessTrackerCore.Services
{
    public class FunctionalityService : IFunctionalityService
    {
        public event Action<string, DateTime> Notification;

        public DateTime Execute(string message)
        {
            var currentTime = DateTime.Now;
            Notification?.Invoke(message, currentTime);
            return currentTime;
        }

        public void ShowExercises(User user)
        {
            foreach (var run in user.Exercises)
            {
                Console.WriteLine($"{run.Name}, {run.End - run.Start}");
            }
        }

        public void ShowRuns(User user)
        {
            foreach (var run in user.Runs)
            {
                Console.WriteLine($"{run.Name}, {run.End - run.Start}");
            }
        }

        public void ShowAll(User user)
        {
            var activities = user.Runs
                .Select(x => new
                {
                    x.Name,
                    Data = $"{x.Data} - {x.Speed}",
                    Date = x.Start,
                })
                .Concat(user.Exercises
                    .Select(x => new
                    {
                        x.Name,
                        Data = $"{x.Data} - {x.Count}",
                        Date = x.Start,
                    }))
                .OrderBy(x => x.Date);

            foreach (var activity in activities)
            {
                Console.WriteLine($"{activity.Name}, {activity.Date}: {activity.Data}");
            }
        }

        
    }
}
