using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachMeSkills.DotNet.Lesson6
{
    public class LinqSamples
    {
        public void Run()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var strings = new string[] { "dog", "cat", "wolf", "cat", "bird", "snake", "deer", "WOLF", "bear", "opossum", "dog", "squirrel", "WOLF", "raccoon", "dog", "boar", "bacon", "А если так?", "Dog" };

            var resultAggregate2 = strings.Aggregate("Seed", (current, next) => current + " " + next).ToUpper();
            var resultAggregate3 = strings.Aggregate("Super", (current, next) => string.Concat(current, " ", next));
            var resultAggregate = strings.Aggregate("10", (current, next) => $"{current} {next}");

            var result = numbers.Aggregate((current, next) =>
            {
                return current * next;
            });

            Console.WriteLine(resultAggregate);
            Console.WriteLine(resultAggregate2);
            Console.WriteLine(resultAggregate3);
            Console.WriteLine("\n\n");

            var resultAggregateSeed = strings
                .Aggregate(
                    "dog",
                    (current, next) =>
                    {
                        if (next == "dog")
                        {
                            next = string.Empty;
                        };

                        current = current.Replace(current, current + "Johan");
                        current = current.Replace("o", "+ +");

                        current = current + DateTime.Now.AddDays(-7).ToString() + "\a";

                        if (next.Count() == 4)
                        {
                            var nextList = Enumerable.Repeat(next, 5);
                            next = string.Concat(nextList);
                        }

                        return current + next;
                    })
                .ToUpper()
                .Trim();

            Console.WriteLine(resultAggregateSeed);
        }
    }
}
