using System;

namespace TeachMeSkills.DotNet.Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            //var simple = new SimpleDelegate();
            //simple.Run();

            //var action = new ActionDelegate();
            //action.Run();

            var predicate = new PredicateDelegate();
            predicate.Run();

            Console.ReadKey();
        }
    }
}
