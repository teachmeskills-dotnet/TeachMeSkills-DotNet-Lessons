﻿using System;

namespace TeachMeSkills.DotNet.Lesson7.Examples
{
    internal delegate void Message();

    internal class DelegateExample
    {
        public void Run()
        {
            Message message;
            if (DateTime.Now.Hour < 12)
            {
                message = GoodMorning;
            }
            else
            {
                message = GoodEvening;
                message += GoodMorning;
                message += GoodEvening;
            }
            message();
            message -= GoodEvening;
            message = GoodMorning;
            Console.WriteLine();
            message();
        }

        private void GoodMorning()
        {
            Console.WriteLine("Good morning!");
        }

        private void GoodEvening()
        {
            Console.WriteLine("Good evening!");
        }
    }
}
