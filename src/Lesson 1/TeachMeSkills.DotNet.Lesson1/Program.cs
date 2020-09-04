using System;

namespace TeachMeSkills.DotNet.Lesson1
{
    /// <summary>
    /// XML comment for class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This is my enum.
        /// </summary>
        enum Week
        {
            Mon = 1, // 1
            Tue, // 2
            Wed, // 3
            Thu, // 4
            Fri, // 5
            Sat = 10, // 10
            Sun  // 11
        }

        /// <summary>
        /// XML comment for field.
        /// </summary>
        static string myValue = "My value";

        /// <summary>
        /// XML comment for property.
        /// </summary>
        public int MyProperty { get; set; }

        /// <summary>
        /// XML comment.
        /// </summary>
        /// <param name="args">Agrs.</param>
        private static void Main(string[] args)
        {
            string temp = "Hello TMS!";
            string Temp = "Another TMS value."; // My first comment
            bool b = false; // true
            int i = 0; // 1, 2, 3..
            double d = 1.53; // 2.34, 3.45..
            decimal dec = 1.23M;
            char c = 'a'; // 'b', 'c'..
            string str = "str"; // "qwe"..
            string qwe = null;

            i = (int)d; // 1   (.53)
            Console.WriteLine(i);
            i = 0;
            i = Convert.ToInt32(d); // 1.53 -> 2
            i = 123;

            //Console.Write("Enter some text: ");
            //string userInputString = Console.ReadLine();
            //Console.WriteLine(">> " + userInputString);
            //Console.WriteLine($">> {userInputString}");

            Console.WriteLine(Week.Mon);
            Console.WriteLine((int)Week.Mon);

            object obj = i;
            obj = "sadasd";
            //int test = (int)obj;
            string strTest = (string)obj;

            int? notNullableValue = 1; // 1, 2, 3, null..
            notNullableValue = null;

            string myTempString = "\"qwe123\"";
            var anotherTempString = 123;
            Console.WriteLine(myTempString);

            Console.WriteLine(i);
            Console.WriteLine("Hello World!");
            Console.WriteLine(temp);
            Console.WriteLine(Temp);
            Console.ReadLine();
        }
    }
}
