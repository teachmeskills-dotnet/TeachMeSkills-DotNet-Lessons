using System;
using System.Collections.Generic;
using System.Linq;

namespace TeachMeSkills.DotNet.Lesson6
{
    public enum MyType
    {
        None = 0,
        Bird = 1,
        Wolf = 2,
    }

    public class WorkWithLinq
    {
        public MyType Type { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class WorkWithLinqDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class Linq
    {
        public void Run()
        {
            var learnLinq = new List<WorkWithLinq>()
            {
                new WorkWithLinq
                {
                    Type = MyType.Wolf,
                    Number = 4,
                    Name = "Vova",
                },
            };

            learnLinq.Add(new WorkWithLinq
            {
                Type = MyType.Bird,
                Number = 4,
                Name = "Vasya",
            });

            learnLinq.Add(new WorkWithLinq
            {
                Type = MyType.Wolf,
                Number = 7,
                Name = "Petya",
            });

            var listOfNames = learnLinq.Select(x => x.Name);

            var aObject = learnLinq.Select(workWithLinq =>
            {
                return new
                {
                    workWithLinq.Number,
                    workWithLinq.Name,
                };
            });

            var newObjects = learnLinq.Select(workWithLinq =>
            {
                return new WorkWithLinqDto
                {
                    Number = workWithLinq.Number,
                    Name = workWithLinq.Name,
                };
            });

            foreach (var item in aObject)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Number);
            }

            var qwe = learnLinq.Select(x => x.Name);
            var grouped = learnLinq.GroupBy(x => x.Number);

            //List<string> names = new List<string>();
            //foreach(var item in learnLinq)
            //{
            //    names.Add(item.Name);
            //}
        }
    }
}
