using System;

namespace TeachMeSkills.DotNet.Lesson5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var simple = new SimpleDelegate();
            //simple.Run();

            //var action = new ActionDelegate();
            //action.Run();

            //var predicate = new PredicateDelegate();
            //predicate.Run();

            //var func = new FuncDelegate();
            //func.Run();

            //var lamda = new LamdaExample();
            //lamda.Run();

            var eventExample = new EventExample();
            eventExample.Notify += DisplayMessage;
            eventExample.Notify += DisplayAnotherMessage;
            eventExample.Send(10);
            eventExample.Notify -= DisplayAnotherMessage;
            eventExample.Send(10);

            Console.ReadKey();
        }

        private static void DisplayMessage(string str)
        {
            Console.WriteLine(str);
        }

        private static void DisplayAnotherMessage(string str)
        {
            Console.WriteLine(str + "SUPER");
        }
    }
}
