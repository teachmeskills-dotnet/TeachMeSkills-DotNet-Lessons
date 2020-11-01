using System;
using TeachMeSkills.DotNet.Lesson7.Examples;

namespace TeachMeSkills.DotNet.Lesson7.Manager
{
    internal class EventManager
    {
        public void Run()
        {
            var eventExample = new EventExample();

            eventExample.Notify += DisplayMessage;
            eventExample.Notify += DisplayAnotherMessage;
            eventExample.Send(10);

            eventExample.Notify -= DisplayAnotherMessage;
            eventExample.Send(10);
        }

        private void DisplayMessage(string str)
        {
            Console.WriteLine(str);
        }

        private void DisplayAnotherMessage(string str)
        {
            Console.WriteLine(str + "SUPER");
        }
    }
}
