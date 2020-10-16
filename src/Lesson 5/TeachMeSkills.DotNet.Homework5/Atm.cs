using System;
using System.Collections.Generic;

namespace TeachMeSkills.DotNet.Homework5
{
    public class Atm
    {
        public event Action<decimal, string> BalanceHandler;
        private decimal _balance = 0M;

        public void GetMoney(decimal money)
        {
            _balance -= money;
            BalanceHandler?.Invoke(_balance, "get");
        }

        public void PutMoney(decimal money)
        {
            _balance += money;
            BalanceHandler?.Invoke(_balance, "put");
        }

        public void ShowInfo()
        {
            var eventName = "show";
            BalanceHandler?.Invoke(_balance, eventName);

            // Вызов конкретного метода из всего списка подписок
            //var listOfMethods = BalanceHandler?.GetInvocationList();
            //var firstDelegate = listOfMethods[0];
            //var methodName = firstDelegate.Method.Name;
            //List<object> args = new List<object>
            //{
            //    _balance,
            //    eventName
            //};
            //var progClass = new Program();
            //var result = progClass.GetType().GetMethod(methodName).Invoke(this, args.ToArray());
        }
    }
}
