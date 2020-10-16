using System;

namespace TeachMeSkills.DotNet.Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Atm atm = new Atm();
            atm.BalanceHandler += GetInfo;
            atm.BalanceHandler += GetInfo;
            atm.BalanceHandler += GetInfo;
            atm.BalanceHandler += GetInfo;

            

            //atm.BalanceHandler += (amount, operation) => Console.WriteLine($"Operation {operation}. Current balance: {amount}");
            atm.PutMoney(10M);
            atm.GetMoney(5M);
            atm.ShowInfo();

            Console.ReadKey();
        }

        public static void GetInfo(decimal amount, string operation)
        {
            Console.WriteLine($"Operation {operation}. Current balance: {amount}");
        }
    }
}
