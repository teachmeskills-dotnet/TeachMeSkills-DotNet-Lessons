using System;

namespace TeachMeSkills.DotNet.BL
{
    public class Calc
    {
        private readonly Helper _helper;

        public Calc(Helper helper)
        {
            _helper = helper;
        }

        public double Sum()
        {
            var (a, b) = _helper.GetRandomNumbers();
            return a + b;
        }

        public double Divide()
        {
            var (a, b) = _helper.GetRandomNumbers();
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }
    }
}
