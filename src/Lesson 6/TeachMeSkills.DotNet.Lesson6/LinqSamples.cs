using System;
using System.Collections.Generic;
using System.Linq;

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

            Console.WriteLine("\n\n---\n\n");

            int[] defaultArray = { 10, 9, 11, 11 };

            Console.WriteLine($"Average: {defaultArray.Average()}");
            Console.WriteLine($"Count: {defaultArray.Count()}");
            Console.WriteLine($"Max: {defaultArray.Max()}");
            Console.WriteLine($"Min: {defaultArray.Min()}");
            Console.WriteLine($"Sum: {defaultArray.Sum()}");

            var listInt = new List<int>
            {
                1,
                2,
                3,
            };

            var asEnumerableResultList = listInt.AsEnumerable();
            var asEnumerableResult = defaultArray.AsEnumerable();
            defaultArray[3] = 10;

            var listDouble = listInt.Cast<string>();

            object[] objects = { "Thomas", 31, 5.02, null, "Joey" };
            var resultOfType = objects.OfType<string>();

            var resultArray = listInt.ToArray();

            English2German[] english2German =
            {
                new English2German { EnglishSalute = "Good morning", GermanSalute = "Guten Morgen" },
                new English2German { EnglishSalute = "Good day", GermanSalute = "Guten Tag" },
                new English2German { EnglishSalute = "Good evening", GermanSalute = "Guten Abend" },
            };

            var resultToDictionary = english2German.ToDictionary(k => k.EnglishSalute, v => v.GermanSalute);
            var resultToDictionaryWithCond = english2German
                .ToDictionary(
                    k => k.EnglishSalute,
                    v => v.GermanSalute.Count() > 9 
                        ? "Odd" 
                        : "Even");

            var toLookup = defaultArray.ToLookup(n => n > 10);
            Console.WriteLine($"ToLookup: {toLookup}");

            var resultElementAt = asEnumerableResult.ElementAt(1); // defaultArray[1]
            var resultElementAtOrDefault = asEnumerableResult.ElementAtOrDefault(100);

            var resultFirst = asEnumerableResult.First();
            var resultFirstOrDefault = asEnumerableResult.FirstOrDefault();
            var resultFirstOrDefaultCond = asEnumerableResult.FirstOrDefault(x => x % 2 == 1);

            //var resultSingOrDefault1 = asEnumerableResult.Single(x => x == 12); // error
            //var resultSingOrDefault2 = asEnumerableResult.Single(x => x == 10); // error
            //var resultSingOrDefault3 = asEnumerableResult.Single(); // error
            var resultSingle4 = asEnumerableResult.Single(x => x == 9);

            var resultSingOrDefault1 = asEnumerableResult.SingleOrDefault(x => x == 12);
            //var resultSingOrDefault2 = asEnumerableResult.SingleOrDefault(x => x == 10); // error
            //var resultSingOrDefault3 = asEnumerableResult.SingleOrDefault(); // error
            var resultSingOrDefault4 = asEnumerableResult.SingleOrDefault(x => x == 9);

            var resultDefaultIfEmpty = asEnumerableResult.DefaultIfEmpty();
            var resultDefaultIfEmptyWithValue = asEnumerableResult.DefaultIfEmpty(5);

            var defaultList = new List<int>();
            IEnumerable<int> defaultEnumerableList = new List<int>();
            var defaultEnumerable = Enumerable.Empty<int>();

            var defaultArrayInt = new int[1];
            var enumerableArray = Array.Empty<int>();

            var enumerableRange = Enumerable.Range(0, 10);
            var enumerableRepeat = Enumerable.Repeat("Hello", 5);
        }
    }

    class English2German
    {
        public string EnglishSalute { get; set; }
        public string GermanSalute { get; set; }
    }
}
