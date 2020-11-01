using System;

namespace TeachMeSkills.DotNet.Lesson4.Examples
{
    internal static class MethodExample
    {
        private static int _classScopeValue = 10;
        private static int MyProperty { get; set; }

        internal static void Run()
        {
            ShowMessage();
            UseParams();
        }

        private static void UseParams()
        {
            var a = nameof(SumArray);
            var b = 2;
            var c = 3;
            var d = 4;

            var arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = { 1, 2, 3 };

            SumArray(a, new int[] { 1, 2, 3 });
            SumArray(a, arr1);
            SumArray(a, arr2);
            SumArray(a, b, c, d);
        }

        private static void SumArray(string a, params int[] array)
        {
            _classScopeValue = 123;
            int scopeValue = 1;
            Console.WriteLine(scopeValue);
            Console.WriteLine($"{a} Method");
            Console.WriteLine($"{nameof(array.Length)} " + array.Length);
            foreach (var item in array)
            {
                _classScopeValue = 123;
                var anotherScopeValue = 2;
                Console.WriteLine(anotherScopeValue);
                Console.WriteLine(_classScopeValue);
                Console.WriteLine(item);
            }
        }

        private static void ShowMessage()
        {
            //int x = GetValue(y: "123", x: 90);
            int val1 = 90;
            string val2 = "123";
            (bool operationResult, int sum) = GetValue(val1, val2);
            Console.WriteLine(operationResult + " " + sum);
            Console.WriteLine(val1);
        }

        private static (bool operationResult, int sum) GetValue(int x, string y, int z = 10)
        {
            x++;
            Console.WriteLine($"y = {y}");
            var p = x + z; // 101
            return (p > 100, p);
        }
    }
}
