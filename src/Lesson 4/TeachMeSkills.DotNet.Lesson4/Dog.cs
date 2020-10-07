using System;

namespace TeachMeSkills.DotNet.Lesson4
{
    public class Dog : AnimalBase, IVoice, IMove
    {
        public int Go(int speed)
        {
            return 2 * speed;
        }

        public void Say()
        {
            Console.WriteLine($"{Name}, Gav!");
        }
    }
}
