using System;

namespace TeachMeSkills.DotNet.Lesson4.Examples
{
    internal static class StringExample
    {
        internal static void Run()
        {
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
        }
    }
}
