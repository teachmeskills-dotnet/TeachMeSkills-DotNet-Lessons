using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.Lesson5
{
    public class PredicateDelegate
    {
        //delegate bool Compare(int val);
        Predicate<int> predicate;
        Predicate<string> comPred = delegate (string x) { return x.Length > 10; };
        //Predicate<string> comPred = x => x.Length > 10;

        public void Run()
        {
            //Compare compare = MyCommon.CompareWithValue;
            predicate = MyCommon.CompareWithValue;
            var r1 = predicate(1);
            predicate += AnotherCompare;
            var r2 = predicate(2);
            predicate += AnotherCompare;

            var result = predicate(int.Parse(Console.ReadLine()));
            Console.WriteLine(result);

            Console.WriteLine(comPred("MySuperString"));

            Predicate<string> comPredSuper = x => x.Length > 11;
            Console.WriteLine(comPredSuper("MyString"));
        }

        private bool AnotherCompare(int val)
        {
            return val < 0;
        }

    }
}
