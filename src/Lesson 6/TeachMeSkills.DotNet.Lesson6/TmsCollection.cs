using System;
using System.Collections.Generic;

namespace TeachMeSkills.DotNet.Lesson6
{
    public class SimpleClass
    {
        public int Number { get; set; }
        public string String { get; set; }
    }
    public class TmsCollection
    {
        public void Run()
        {
            List<int> list = new List<int>
            {
                1,
                2,
                3,
            };

            list.Clear();
            var elem = list.Find(x => x == 2);

            List<SimpleClass> simpleList = new List<SimpleClass>
            {
                // добавили элемент в коллекцию - пример 1
                new SimpleClass
                {
                    Number = 1,
                    String = "str"
                }
            };

            // добавили элемент в коллекцию - пример 2
            simpleList.Add(new SimpleClass
            {
                Number = 2,
                String = "str2",
            });
            foreach (var item in simpleList)
            {
                Console.WriteLine(item);
            }

            var findedElement = simpleList.Find(x => x.String == "str2");

            Predicate<SimpleClass> match = x => x.String == "str2";
            Console.WriteLine(match);
            var findedElement1 = simpleList.Find(match);

            Predicate<SimpleClass> predicateMatch =
                delegate (SimpleClass bulka) { return bulka.String == "str2"; };
            var findedElement2 = simpleList.Find(predicateMatch);

            var findedElement3 = simpleList.Find(
                delegate (SimpleClass bulka) { return bulka.String == "str2"; });

            IEnumerable<int> eList = new List<int>();
            //eList.Add(1);

            var listByMethod = GetRandomList();

            //foreach (var item in GetRandomList())
            //{

            //}

            Console.WriteLine();
        }

        private IEnumerable<int> GetRandomList()
        {
            var rand = new Random();
            var list = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(rand.Next(-10, 10));
            }

            return list;
        }
    }
}
