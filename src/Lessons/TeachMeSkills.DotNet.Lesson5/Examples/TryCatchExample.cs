using System;

namespace TeachMeSkills.DotNet.Lesson5.Examples
{
    internal class TryCatchExample
    {
        public void Run()
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

        private double SafeDivided(double x, double? y)
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
    }
}
