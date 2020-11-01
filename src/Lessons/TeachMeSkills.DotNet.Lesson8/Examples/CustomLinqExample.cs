using System;
using System.Collections.Generic;

namespace TeachMeSkills.DotNet.Lesson8.Examples
{
    public static class CustomLinqExample
    {
        public static int[] SkipWhileWithTake(this int[] value, Predicate<int> predicate, int count)
        {
            var state = true;
            var collection = new List<int>();

            foreach (var item in value)
            {
                if (predicate(item) && count != 0 && state) // x == 3
                {
                    continue;
                }

                if (count != 0)
                {
                    state = false;
                    count--;
                    collection.Add(item);
                    continue;
                }
            }

            return collection.ToArray();
        }
    }
}
