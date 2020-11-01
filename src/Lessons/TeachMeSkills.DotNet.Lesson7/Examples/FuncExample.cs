using System;

namespace TeachMeSkills.DotNet.Lesson7.Examples
{
    internal class FuncExample
    {
        private delegate string FuncTest(string str);

        private Func<Guid, string> funcNameLamda = guid => guid.ToString();
        private Func<Guid, string> funcName = delegate (Guid guid) { return guid.ToString(); };
        private Func<Guid, int, string> funcMethod;

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
