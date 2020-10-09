using System;

namespace TeachMeSkills.DotNet.Lesson4
{
    public class Dog : AnimalBase, IVoice, IMove, IGo
    {
        public void Say()
        {
            Console.WriteLine($"{Name}, Gav!");
        }

        int IMove.Go(int speed)
        {
            return 5 * speed;
        }

        int IGo.Go(int speed)
        {
            return 2 * speed;
        }
    }
}
