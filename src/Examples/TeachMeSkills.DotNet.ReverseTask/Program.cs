using System;
using System.Linq;

namespace TeachMeSkills.DotNet.ReverseTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var arrayLength = array.Length;

            // variant 1
            var reverseArray1 = array.Reverse();

            // variant 2
            var reverseArray2 = new int[arrayLength];

            int j = 0;
            for (int i = arrayLength - 1; i >= 0; i--)
            {
                reverseArray2[j] = array[i];
                j++;
            }

            // variant 3
            var copyArray = new int[] { 1, 2, 3, 4, 5 };
            var newArray = array
                .Concat(copyArray)
                .ToArray();

            var maxLength = arrayLength * 2 - 1;

            for (int i = 0; i < arrayLength; i++)
            {
                newArray[maxLength] = newArray[i];
                maxLength--;
            }

            var reverseArray3 = newArray
                .TakeLast(arrayLength)
                .ToArray();

            // variant 4
            var middleOfArray = 0;
            if (arrayLength % 2 == 0)
            {
                middleOfArray = arrayLength / 2;
            }
            else
            {
                middleOfArray = (arrayLength - 1) / 2;
            }

            var arrayLastIndex = arrayLength - 1;
            var temp = 0;
            for (int i = 0; i <= middleOfArray; i++)
            {
                temp = array[i];
                array[i] = array[arrayLastIndex];
                array[arrayLastIndex] = temp;
                arrayLastIndex--;
            }

            Console.WriteLine();
            Console.WriteLine(reverseArray1);
            Console.WriteLine(reverseArray2);
            Console.WriteLine(reverseArray3);
            Console.WriteLine(array);

            Console.ReadKey();
        }
    }
}
