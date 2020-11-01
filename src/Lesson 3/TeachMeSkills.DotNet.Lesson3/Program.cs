using System;
using TeachMeSkills.DotNet.Lesson3.Basic;
using TeachMeSkills.DotNet.Lesson3.Test;

namespace TeachMeSkills.DotNet.Lesson3
{
    internal class Program
    {
        

        

        

        

        

        

        private static void Main(string[] args)
        {
            //TryCatchFinally();
            //SumDateTime();
            //SubDate();
            //WorkWithCatClass();
            //CatWithState();

            

            //var animal = new Animal();

            //var dog = new Dog();
            //dog.SayHello();
            //dog.SayBye();

            var children = new Children(true, "MyName");
            children.GetInfo();

            Console.WriteLine("Main method");
            Console.ReadKey();
        }
    }
}
