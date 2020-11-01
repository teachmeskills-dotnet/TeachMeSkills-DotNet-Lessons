using System;

namespace TeachMeSkills.DotNet.Lesson2
{
    internal class Program
    {
        private static int _classScopeValue = 10;
        private int MyProperty { get; set; }

        private static void Main(string[] args)
        {
            var i = 0; // постфиксный
            Console.WriteLine(i++); // 0
            Console.WriteLine(i); // 1

            var j = 0; // префиксный
            Console.WriteLine(--j); // -1
            Console.WriteLine(j); // -1

            Console.WriteLine(5 % 4); // остаток от деления, 1

            bool passed = false;
            Console.WriteLine(passed); // false
            Console.WriteLine(!passed); // true
            Console.WriteLine(!true); // false

            bool SecondOperand()
            {
                Console.WriteLine("Second operand is evaluated.");
                return true;
            }

            Console.WriteLine(false && SecondOperand()); // false
            Console.WriteLine(true && SecondOperand()); // true

            Console.WriteLine(false || SecondOperand()); // true
            Console.WriteLine(false || false); // false

            int a = 1 + 2 + 3;
            int b = 6;
            Console.WriteLine(a == b); // true
            Console.WriteLine(a != b);  // false

            char c1 = 'a';
            char c2 = 'A';
            Console.WriteLine(c1 == c2); // false
            Console.WriteLine(c1 == char.ToLower(c2)); // true
            Console.WriteLine(c1 != c2); // true

            string s1 = "Hello";
            string s2 = "Hello";
            Console.WriteLine(s1 == s2); // true
            Console.WriteLine(s1 != s2); // false
            Console.WriteLine(s1 != s2.ToLower()); // true

            object o1 = 1;
            object o2 = 1;
            Console.WriteLine(o1 != o2); // true (ссылка)

            var str1 = "Forgot";
            var str2 = "white space";
            var str3 = "With ";
            Console.WriteLine(str1 + str2);
            Console.WriteLine(str3 + str2);
            Console.WriteLine($"{str3.Trim()} {str2}");

            var val1 = 1;
            Console.WriteLine(val1 += 2); // val1 = val1 + 2
            Console.WriteLine(val1 -= 1); // val1 = val1 - 1

            int condOneValue = 1;
            bool cond; // false
            cond = true;

            //if (cond)
            //{
            //    condOneValue = 0;
            //}
            //else
            //{
            //    condOneValue = 2;
            //}
            condOneValue = cond ? 0 : 2;
            Console.WriteLine(condOneValue);

            int def1 = default; // int qwe;
            var def2 = default(decimal);

            var str1234 = "str123";
            Console.WriteLine(str1234);
            string str321 = nameof(str321);
            Console.WriteLine(str321);
            string anotherUserName = nameof(Main);
            anotherUserName = "test value";
            Console.WriteLine($"nameof: {anotherUserName}");

            var array1 = new int[5];
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };
            int[] array3 = { 1, 2, 3, 4, 5, 6 };

            var strVal1 = "qwerty123asd";
            var strVal2 = "123a";

            Console.WriteLine(strVal1.Contains(strVal2)); // true
            Console.WriteLine(string.Concat(strVal1, strVal2));
            Console.WriteLine(strVal1.EndsWith(strVal2)); // false
            Console.WriteLine($"{strVal2} {9090}", strVal1);
            Console.WriteLine(string.Format("{0}{1}", strVal2, strVal2));
            Console.WriteLine(strVal1[3]); // r
            Console.WriteLine(strVal1.Substring(3));
            Console.WriteLine(strVal1.Replace(strVal2, "890"));

            var strForSplit = "qwe rty asd";
            var strArray = strForSplit.Split(' ');
            for (int p = 0; p < strArray.Length; p++)
            {
                Console.WriteLine(strArray[p]);
            }
            foreach (var strItem in strArray)
            {
                Console.WriteLine(strItem);
            }

            ShowMessage();
            UseParams();

            Console.ReadLine();
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
            Console.WriteLine($"{a} Method");
            Console.WriteLine($"{nameof(array.Length)} " + array.Length);
            foreach (var item in array)
            {
                _classScopeValue = 123;
                var anotherScopeValue = 2;
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
