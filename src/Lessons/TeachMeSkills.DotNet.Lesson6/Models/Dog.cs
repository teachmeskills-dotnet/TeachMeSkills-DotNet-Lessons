using System;
using TeachMeSkills.DotNet.Lesson6.Interfaces;

namespace TeachMeSkills.DotNet.Lesson6.Models
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
