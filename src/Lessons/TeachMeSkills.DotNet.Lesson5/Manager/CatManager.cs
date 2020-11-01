using System;
using TeachMeSkills.DotNet.Lesson5.Enums;
using TeachMeSkills.DotNet.Lesson5.Models;

namespace TeachMeSkills.DotNet.Lesson5.Manager
{
    internal class CatManager
    {
        public void Run()
        {
            var cat1 = new Cat()
            {
                //Age = 1,
                //Color = Color.Black,
                //FullName = "Lord Wiskas"
                FullName = "Cat1"
            };
            //cat.SetBrand("British");

            var cat2 = new Cat()
            {
                FullName = "Cat2"
            };

            cat1.Sleep();
            cat1.Play();
            cat2.Play();
            cat1.WakeUp();
            cat1.Play();
        }

        public void RunWithTryCatch()
        {
            Cat cat;
            try
            {
                cat = new Cat("");
            }
            catch (Exception ex)
            {
                cat = new Cat();
                Console.WriteLine(ex.Message);
            }

            cat.Age = 1;
            //cat.SetBrand("British");
            GetCatInfo(cat);
            cat.Color = Color.Gray;
            cat.FullName = "Lord Wiskas";
            GetCatInfo(cat);
        }

        private void GetCatInfo(Cat cat)
        {
            Console.WriteLine("---");
            Console.WriteLine($"{nameof(cat.FullName)}: {cat.FullName}");
            cat.GetBrand();
            Console.WriteLine(cat.Age);
            Console.WriteLine(cat.Color);
            Console.WriteLine("---");
        }
    }
}
