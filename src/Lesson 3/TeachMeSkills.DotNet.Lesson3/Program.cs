using System;
using TeachMeSkills.DotNet.Lesson3.Basic;

namespace TeachMeSkills.DotNet.Lesson3
{

    class Program
    {
        private static double SafeDivided(double x, double? y)
        {
            if (y == null)
            {
                throw new StackOverflowException();
            }

            if (y == 1)
            {
                //return x;
                throw new ArgumentException();
            }

            if (y == 0)
            {
                throw new DivideByZeroException("Our divided exception.");
            }

            return x / y.Value;
        }

        private static void TryCatchFinally()
        {
            double x = 1;
            double? y = 0;
            bool hasError = default;

            try
            {
                var result = SafeDivided(x, y);
                Console.WriteLine(result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(x);
                hasError = true;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                hasError = true;
            }
            catch (Exception ex)
            {
                hasError = true;
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }
            finally
            {
                if (hasError)
                {
                    Console.WriteLine("Finally key");
                }
            }
        }

        private static void SumDateTime()
        {
            var date1 = new DateTime(1985, 10, 30);
            var date2 = DateTime.Now;

            Console.WriteLine(date1);
            Console.WriteLine(date2);

            var timeSpan1 = new TimeSpan(date2.Ticks);
            Console.WriteLine(timeSpan1);

            var sum = date1.Add(timeSpan1);
            Console.WriteLine(sum);
        }

        private static void SubDate()
        {
            var d1 = new DateTime(2000, 01, 01);
            var d2 = DateTime.Now;

            Console.WriteLine(d1);
            Console.WriteLine(d2);

            var sub = d2.Subtract(d1);
            var d3 = new DateTime(sub.Ticks);
            Console.WriteLine(d3.AddYears(-1));
        }

        private static void WorkWithCatClass()
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

        private static void GetCatInfo(Cat cat)
        {
            Console.WriteLine("---");
            Console.WriteLine($"{nameof(cat.FullName)}: {cat.FullName}");
            cat.GetBrand();
            Console.WriteLine(cat.Age);
            Console.WriteLine(cat.Color);
            Console.WriteLine("---");
        }

        private static void CatWithState()
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

        private static void CarWithSpeed(Car car)
        {
            car.GetCurrentSpeed();
            car.Start();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.GetCurrentSpeed();
            car.Stop();
            car.GetCurrentSpeed();
        }

        static void Main(string[] args)
        {
            //TryCatchFinally();
            //SumDateTime();
            //SubDate();
            //WorkWithCatClass();
            //CatWithState();

            var car1 = new Car(100);
            CarWithSpeed(car1);
            Console.WriteLine("-----");
            var car2 = new Car(2);
            CarWithSpeed(car2);
            Console.WriteLine("-----");
            var car3 = new Car(12);
            CarWithSpeed(car3);

            Console.WriteLine("Main method");
            Console.ReadKey();
        }
    }
}
