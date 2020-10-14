using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.Lesson5
{
    public class FuncDelegate
    {
        delegate string FuncTest(string str);
        Func<Guid, string> funcNameLamda = guid => guid.ToString();
        Func<Guid, string> funcName = delegate (Guid guid) { return guid.ToString(); };
        Func<Guid, int, string> funcMethod;

        public void Run()
        {
            FuncTest funcTest = ConvertMessage;
            funcTest += ConvertAnotherMessage;
            Console.WriteLine(funcTest("abv"));

            funcMethod = ConvertGuid;
            var resultDel = funcMethod(Guid.NewGuid(), 123);
            Console.WriteLine(resultDel);
        }

        private string ConvertGuid(Guid guid, int val)
        {
            return $"{guid} {val} Super";
        }

        private string ConvertMessage(string val)
        {
            return val + "Super";
        }

        private string ConvertAnotherMessage(string val)
        {
            return val + "VerySuper";
        }
    }
}
