using System;

namespace TeachMeSkills.DotNet.Lesson4.Examples
{
    internal static class OperatorExample
    {
        internal static void Run()
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

            // Локальная функция
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
            string anotherUserName = nameof(Run);
            anotherUserName = "test value";
            Console.WriteLine($"nameof: {anotherUserName}");
        }
    }
}
