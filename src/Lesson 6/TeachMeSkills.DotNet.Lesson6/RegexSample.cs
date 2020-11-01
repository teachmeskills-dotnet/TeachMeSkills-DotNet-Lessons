using System;
using System.Text.RegularExpressions;

namespace TeachMeSkills.DotNet.Lesson6
{
    public class RegexSample
    {
        public void Run()
        {
            var strWithSpace = "He11o world";
            var str = "Hello,world";
            var regex = new Regex(@"\w{5}\sworld");

            var match1 = regex.Match(strWithSpace);
            var match2 = regex.Match(str);
            Console.WriteLine(match1.Success);
            Console.WriteLine(match2.Success);

            Console.WriteLine("REGEX PHONE 1");

            var regexPhone1 = new Regex(@"^\+[375]{3}(25|29|33|44)\d{7}");
            var forRegexPhone1_1 = "+375(44)1234567";
            var forRegexPhone1_2 = "+37544123-45-67";
            var forRegexPhone1_3 = "+375111234567";
            var forRegexPhone1_4 = "375441234567";
            var forRegexPhone1_5 = "+375251234567";
            var forRegexPhone1_6 = "+375291234567";
            var forRegexPhone1_7 = "+375331234567";
            var forRegexPhone1_8 = "+375441234567";

            Console.WriteLine(regexPhone1.Match(forRegexPhone1_1).Success);
            Console.WriteLine(regexPhone1.Match(forRegexPhone1_2).Success);
            Console.WriteLine(regexPhone1.Match(forRegexPhone1_3).Success);
            Console.WriteLine(regexPhone1.Match(forRegexPhone1_4).Success);
            Console.WriteLine(regexPhone1.Match(forRegexPhone1_5).Success);
            Console.WriteLine(regexPhone1.Match(forRegexPhone1_6).Success);
            Console.WriteLine(regexPhone1.Match(forRegexPhone1_7).Success);
            Console.WriteLine(regexPhone1.Match(forRegexPhone1_8).Success);

            Console.WriteLine("REGEX PHONE 2");

            var regexPhone2 = new Regex(@"^\+[375]{3}\((25|29|33|44)\)\d{3}-\d{2}-\d{2}");
            var forRegexPhone2_1 = "+37544123-45-67";
            var forRegexPhone2_2 = "+375(11)123-45-67";
            var forRegexPhone2_3 = "+375(44)1234567";
            var forRegexPhone2_4 = "375(44)123-45-67";
            var forRegexPhone2_5 = "+375(25)123-45-67";
            var forRegexPhone2_6 = "+375(29)123-45-67";
            var forRegexPhone2_7 = "+375(33)123-45-67";
            var forRegexPhone2_8 = "+375(44)123-45-67";

            Console.WriteLine(regexPhone2.Match(forRegexPhone2_1).Success);
            Console.WriteLine(regexPhone2.Match(forRegexPhone2_2).Success);
            Console.WriteLine(regexPhone2.Match(forRegexPhone2_3).Success);
            Console.WriteLine(regexPhone2.Match(forRegexPhone2_4).Success);
            Console.WriteLine(regexPhone2.Match(forRegexPhone2_5).Success);
            Console.WriteLine(regexPhone2.Match(forRegexPhone2_6).Success);
            Console.WriteLine(regexPhone2.Match(forRegexPhone2_7).Success);
            Console.WriteLine(regexPhone2.Match(forRegexPhone2_8).Success);
        }
    }
}
