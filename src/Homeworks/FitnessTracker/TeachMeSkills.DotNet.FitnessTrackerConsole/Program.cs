using System;
using System.Threading;
using TeachMeSkills.DotNet.FitnessTrackerCore.Enums;
using TeachMeSkills.DotNet.FitnessTrackerCore.Interfaces;
using TeachMeSkills.DotNet.FitnessTrackerCore.Manager;
using TeachMeSkills.DotNet.FitnessTrackerCore.Models;
using TeachMeSkills.DotNet.FitnessTrackerCore.Services;

namespace TeachMeSkills.DotNet.FitnessTrackerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // user input
            IStatisticService statisticService = new StatisticService();
            IFunctionalityService functionalityService = new FunctionalityService();
            functionalityService.Notification += NotificationManager.Show;
            var user = new User("Name", 70.1, 160, 20, Gender.Male);

            // user input by while
            var run = new Run
            {
                Name = "Minsk Marathon",
                Speed = 10.2
            };
            var time1 = 4000; // 4000 ms = 4 sec
            run.Start = functionalityService.Execute($"Start {run.Name}: ");
            Thread.Sleep(time1);
            run.End = functionalityService.Execute($"End {run.Name}: ");
            run.Data = (decimal)(time1 * run.Speed);

            user.Runs.Add(run);

            functionalityService.ShowRuns(user);

            var exercise = new Exercise
            {
                Name = "Jump",
                Count = 200,
            };

            var time2 = 5000;
            exercise.Start = functionalityService.Execute($"Start {exercise.Name}: ");
            Thread.Sleep(time2);
            exercise.End = functionalityService.Execute($"End {exercise.Name}: ");
            exercise.Data = ((double)exercise.Count / time2) * 1000;

            user.Exercises.Add(exercise);

            Console.WriteLine("\n=======\n");

            functionalityService.ShowAll(user);

            Console.WriteLine("\n=======\n");

            var bioTrackerData = functionalityService.BioTrackerPpg();
            foreach (var val in bioTrackerData)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("\n=======\n");

            var statistic = statisticService.Get(user, bioTrackerData);

            Console.ReadKey();
        }
    }
}
