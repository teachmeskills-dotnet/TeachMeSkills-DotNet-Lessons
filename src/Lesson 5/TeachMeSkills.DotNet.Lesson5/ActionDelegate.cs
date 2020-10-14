using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.Lesson5
{
    public class ActionDelegate
    {
        //delegate void Message();
        Action action;
        Action<string> actionString;
        Action<string, int> actionNew;

        public void Run()
        {
            //Action message = MyCommon.GoodMorning;
            //message();

            action = MyCommon.GoodMorning;
            action();

            //var name = Guid.NewGuid().ToString();
            actionString = MyCommon.GoodMorningWithName;
            actionString += MyCommon.GoodMorningWithName;
            
            actionString("name");
            actionString("name1");

            actionNew = MyCommon.GoodMorningWithNameAndAge;
            //actionNew += MyCommon.GoodMorningWithName;
            actionNew("Name", 1);
        }


    }
}
