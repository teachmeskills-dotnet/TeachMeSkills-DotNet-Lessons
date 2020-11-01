using System;

namespace TeachMeSkills.DotNet.Lesson7.Examples
{
    internal class ActionExample
    {
        //delegate void Message();
        private Action action;

        private Action<string> actionString;
        private Action<string, int> actionNew;

        public void Run()
        {
            //Action message = MyCommon.GoodMorning;
            //message();

            action = CommonMethods.GoodMorning;
            action();

            //var name = Guid.NewGuid().ToString();
            actionString = CommonMethods.GoodMorningWithName;
            actionString += CommonMethods.GoodMorningWithName;

            actionString("name");
            actionString("name1");

            actionNew = CommonMethods.GoodMorningWithNameAndAge;
            //actionNew += MyCommon.GoodMorningWithName;
            actionNew("Name", 1);
        }
    }
}
