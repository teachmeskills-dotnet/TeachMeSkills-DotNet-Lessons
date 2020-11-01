using System;

namespace TeachMeSkills.DotNet.Lesson5.Examples
{
    internal class DateTimeExample
    {
        public void Add()
        {
            var date1 = new DateTime(1985, 10, 30);
            var date2 = DateTime.Now;

            Console.WriteLine(date1);
            Console.WriteLine(date2);

            var timeSpan1 = new TimeSpan(date2.Ticks);
            Console.WriteLine(timeSpan1);

            var add = date1.Add(timeSpan1);
            Console.WriteLine(add);
        }

        public void Sub()
        {
            var date1 = new DateTime(2000, 01, 01);
            var date2 = DateTime.Now;

            Console.WriteLine(date1);
            Console.WriteLine(date2);

            var sub = date2.Subtract(date1);
            var date3 = new DateTime(sub.Ticks);
            Console.WriteLine(date3.AddYears(-1));
        }
    }
}
