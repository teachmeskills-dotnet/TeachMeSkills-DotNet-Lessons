using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.Lesson5
{
    public class LamdaExample
    {
        //delegate bool GetBalance(int number);
        //Predicate<int> GetPredicateBalance;
        //Func<int, bool> GetFuncBalance;

        public void Run()
        {
            //GetBalance getBalanceDefault = GetBalanceMethod;
            //GetBalance getBalanceAnother = delegate (int number) { return number > 0; };

            //static int GetRandomValueByLocalFunction()
            //{
            //    var random = new Random();
            //    return random.Next(-10, 100);
            //}

            Predicate<int> getBalance = (number) => number > 0;
            Predicate<int> getBalanceDiff = (number) =>
            {
                var getSomeResult = GetRandomValue();
                return number > 0 && number < getSomeResult;
            };

            var userNumber = 10;
            GetUserBalance(userNumber, getBalance);
        }

        private bool GetBalanceMethod(int number)
        {
            return number > 0;
        }

        private int GetRandomValue()
        {
            var random = new Random();
            return random.Next(-10, 100);
        }

        private void GetUserBalance(int number, Predicate<int> predicate)
        {
            var result = predicate(number);
            number = 11;
            predicate = null;
            Console.WriteLine(result);
        }
    }
}
