using System;

namespace TeachMeSkills.DotNet.Lesson3
{
    /// <summary>
    /// Cat class.
    /// </summary>
    public class Cat
    {
        //public int MyField; // Поле
        //public int MyProperty { get; set; } // Свойство

        /// <summary>
        /// Brand.
        /// </summary>
        private string _brand = default; // string.Empty, ""

        private readonly DateTime _createdOn = DateTime.Now;

        private bool _isSleep;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Cat()
        {
            Console.WriteLine(_createdOn);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="brand">Brand.</param>
        public Cat(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentException($"error message: {nameof(brand)}");
            }

            _brand = brand;
            Console.WriteLine(_createdOn);
        }

        /// <summary>
        /// Name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Color.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Age.
        /// </summary>
        public int Age { get; set; }

        public void SetBrand(string name)
        {
            _brand = name;
        }

        public void GetBrand()
        {
            Console.WriteLine($"Brand: {_brand}");
        }

        public void Sleep()
        {
            _isSleep = true;
            Console.WriteLine("Sleep");
        }

        public void WakeUp()
        {
            _isSleep = false;
            Console.WriteLine("WakeUp");
        }

        public void Eat()
        {
            var state = CheckState();
            if (state)
            {
                return;
            }

            Console.WriteLine("Eat");
        }

        public void Play()
        {
            var state = CheckState();
            if (state)
            {
                return;
            }

            Console.WriteLine($"Play with {FullName}");
        }

        private bool CheckState()
        {
            if (_isSleep)
            {
                Console.WriteLine("Now sleep");
                return true;
            }

            return false;
        }
    }
}
