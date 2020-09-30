using System;

namespace TeachMeSkills.DotNet.Lesson3
{
    /// <summary>
    /// Car.
    /// </summary>
    public class Car
    {
        // ctor
        // prop
        // cursor on Car -> Alt + Enter -> menu with Generate constructor

        private readonly int _speedUp;
        private int _speed;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Car()
        {
            Console.WriteLine("Default");
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="speedUp">Speed up.</param>
        public Car(int speedUp)
        {
            _speedUp = speedUp;
        }

        /// <summary>
        /// Model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Size.
        /// </summary>
        public Size Size { get; set; } = new Size();

        /// <summary>
        /// Start.
        /// </summary>
        public void Start()
        {
            for (int i = 0; i < _speedUp; i++)
            {
                _speed += 100 / _speedUp;
                GetCurrentSpeed();
            }
        }

        /// <summary>
        /// Stop.
        /// </summary>
        public void Stop()
        {
            for (int i = 0; i < _speedUp; i++)
            {
                _speed -= 100 / _speedUp;
                GetCurrentSpeed();
            }
        }

        /// <summary>
        /// Get current speed.
        /// </summary>
        public void GetCurrentSpeed()
        {
            Console.WriteLine($"Current speed: {_speed}");
        }
    }
}
