using System;
using System.Collections.Generic;
using System.Linq;

namespace TeachMeSkills.DotNet.Lesson8.Examples
{
    internal class LinqExamples
    {
        public void Run()
        {
            AggregationMethods();
            ConversionMethods();
            ElementMethods();
            GenerationMethods();
            GroupingMethods();
            OrderingMethods();
            OtherMethods();
            PartitioningMethods();
            QuantifierMethods();
            RestrictionMethods();

            CustomLinq();
        }

        private void AggregationMethods()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var result = numbers.Aggregate((current, next) =>
            {
                return current * next;
            });

            var strings = new string[] { "dog", "cat", "wolf", "cat", "bird", "snake", "deer", "WOLF", "bear", "opossum", "dog", "squirrel", "WOLF", "raccoon", "dog", "boar", "bacon", "А если так?", "Dog" };

            var aggregationExample1 = strings.Aggregate("Seed", (current, next) => current + " " + next).ToUpper();
            var aggregationExample2 = strings.Aggregate("Super", (current, next) => string.Concat(current, " ", next));
            var aggregationExample3 = strings.Aggregate("10", (current, next) => $"{current} {next}");

            Console.WriteLine(aggregationExample1);
            Console.WriteLine(aggregationExample2);
            Console.WriteLine(aggregationExample3);
            Console.WriteLine("\n\n");

            var complexAggregateSeed = strings
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

            Console.WriteLine(complexAggregateSeed);

            Console.WriteLine("\n\n---\n\n");

            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine($"Count: {numbers.Count()}");
            Console.WriteLine($"Max: {numbers.Max()}");
            Console.WriteLine($"Min: {numbers.Min()}");
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }

        private void ConversionMethods()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var numbers = new List<int>
            {
                1,
                2,
                3,
            };

            var asEnumerableExample1 = numbers.AsEnumerable();
            var asEnumerableExample2 = array.AsEnumerable();
            array[3] = 10;

            var castExample1 = numbers.Cast<string>();

            object[] objects = { "Thomas", 31, 5.02, null, "Joey" };
            var castExample2 = objects.OfType<string>();

            var arrayExample = numbers.ToArray();

            English2German[] english2German =
            {
                new English2German { EnglishSalute = "Good morning", GermanSalute = "Guten Morgen" },
                new English2German { EnglishSalute = "Good day", GermanSalute = "Guten Tag" },
                new English2German { EnglishSalute = "Good evening", GermanSalute = "Guten Abend" },
            };

            var dictionaryExample = english2German.ToDictionary(k => k.EnglishSalute, v => v.GermanSalute);
            var dictionaryExampleWithСondition = english2German
                .ToDictionary(
                    k => k.EnglishSalute,
                    v => v.GermanSalute.Count() > 9
                        ? "Odd"
                        : "Even");

            var lookupExample = numbers.ToLookup(n => n > 10);
            Console.WriteLine($"ToLookup: {lookupExample}");
        }

        private void ElementMethods()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var elementExample = numbers.ElementAt(1); // numbers[1]
            var elementAtOrDefaultExample = numbers.ElementAtOrDefault(100);

            var firstExample = numbers.First();
            var firstOrDefaultExample = numbers.FirstOrDefault();
            var firstOrDefaultExampleWithСondition = numbers.FirstOrDefault(x => x % 2 == 1);

            //var singleExample1 = numbers.Single(x => x == 12); // error
            //var singleExample2 = numbers.Single(x => x == 10); // error
            //var singleExample3 = numbers.Single(); // error
            var singleExample4 = numbers.Single(x => x == 3);

            var singleOrDefaultExample1 = numbers.SingleOrDefault(x => x == 12);
            //var singleOrDefaultExample2 = numbers.SingleOrDefault(x => x == 10); // error
            //var singleOrDefaultExample3 = numbers.SingleOrDefault(); // error
            var singleOrDefaultExample4 = numbers.SingleOrDefault(x => x == 3);
        }

        private void GenerationMethods()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var defaultIfEmpty = numbers.DefaultIfEmpty();
            var defaultIfEmptyWithValue = numbers.DefaultIfEmpty(5);

            var defaultList = new List<int>();
            IEnumerable<int> enumerableList = new List<int>();
            var enumerableEmptyExample = Enumerable.Empty<int>();

            var defaultArrayInt = new int[1];
            var arrayEmptyExample = Array.Empty<int>();

            var enumerableRangeExample = Enumerable.Range(0, 10);
            var enumerableRepeatExample = Enumerable.Repeat("Hello", 5);
        }

        private void GroupingMethods()
        {
            var english2germanCollection = new List<English2German>
            {
                new English2German
                {
                    EnglishSalute = "Hello",
                    GermanSalute = "qwe"
                },
                new English2German
                {
                    EnglishSalute = "Hi",
                    GermanSalute = "asd"
                },
                new English2German
                {
                    EnglishSalute = "Hello",
                    GermanSalute = "zxc"
                }
            };

            var grouped = english2germanCollection.GroupBy(x => x.EnglishSalute);
            var groupedWithConditionExample = english2germanCollection.GroupBy(x => x.EnglishSalute == "Hi");

            foreach (var item in groupedWithConditionExample)
            {
                Console.WriteLine(item.Key);
                foreach (var anotherItem in item)
                {
                    Console.WriteLine($"Value: {anotherItem.EnglishSalute} {anotherItem.GermanSalute}");
                }
            }

            var dogCollection = new List<Dog>
            {
                new Dog
                {
                    Age = 1,
                    Name = "Alice"
                },
                new Dog
                {
                    Age = 2,
                    Name = "Dog2"
                }
            };

            var catCollection = new List<Cat>
            {
                new Cat
                {
                    Weight = 101,
                    Name = "Alice"
                },
                new Cat
                {
                    Weight = 102,
                    Name = "Barsik"
                }
            };

            var totalCollection = dogCollection
                .Select(dog => new
                {
                    dog.Name,
                    Type = dog.GetType().Name,
                    Table = new
                    {
                        Data = dog.Age,
                        Type = nameof(dog.Age)
                    },
                })
                .Concat(catCollection
                    .Select(cat => new
                    {
                        cat.Name,
                        Type = cat.GetType().Name,
                        Table = new
                        {
                            Data = cat.Weight,
                            Type = nameof(cat.Weight)
                        },
                    }))
                .GroupBy(x => x.Name);
        }

        private void OrderingMethods()
        {
            var dogCollection = new List<Dog>
            {
                new Dog
                {
                    Age = 1,
                    Name = "Alice"
                },
                new Dog
                {
                    Age = 2,
                    Name = "Dog2"
                }
            };

            var catCollection = new List<Cat>
            {
                new Cat
                {
                    Weight = 101,
                    Name = "Alice"
                },
                new Cat
                {
                    Weight = 102,
                    Name = "Barsik"
                }
            };

            var totalCollection = dogCollection
                .Select(dog => new
                {
                    dog.Name,
                    Type = dog.GetType().Name,
                    Table = new
                    {
                        Data = dog.Age,
                        Type = nameof(dog.Age)
                    },
                })
                .Concat(catCollection
                    .Select(cat => new
                    {
                        cat.Name,
                        Type = cat.GetType().Name,
                        Table = new
                        {
                            Data = cat.Weight,
                            Type = nameof(cat.Weight)
                        },
                    }))
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Type.Length)
                .ThenByDescending(x => x.Table.Type);

            var numbers = new int[] { 1, 2, 3, 4, 5 };
            var orderByExample = numbers.OrderBy(x => x);
            var orderByDescendingExample = numbers.OrderByDescending(x => x);
        }

        private void OtherMethods()
        {
            string[] names = { "Name1", "Name2", "Name3" };
            DateTime[] dates = { new DateTime(2000, 10, 30), new DateTime(2001, 1, 1), new DateTime(2002, 1, 1) };

            Func<string, DateTime, string> FuncDelegate = (name, date) => $"Name: {name}, Date: {date}";
            var zipExample = names.Zip(dates, FuncDelegate);
            var zipDateTimeExample = names.Zip(dates);
        }

        private void PartitioningMethods()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var skipExample = numbers.Skip(2);
            var copyDefaultArray = numbers.Take(1)
                .Concat(numbers.Skip(2))
                .ToArray();
        }

        private void QuantifierMethods()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var allExample = numbers.All(x => x == 3);
            var anyExample = numbers.Any(x => x == 3);
            var containExample = numbers.Contains(3);
        }

        private void RestrictionMethods()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var whereExample = numbers.Where(x => x == 3 || x == 7);
        }

        private void CustomLinq()
        {
            int[] customArray = { 3, 3, 3, 4, 7, 8, 9 };
            var result = customArray.SkipWhileWithTake(x => x == 3, 4); // 4,7
        }
    }
}
