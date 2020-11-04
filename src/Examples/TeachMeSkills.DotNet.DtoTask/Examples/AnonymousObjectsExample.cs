using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.DtoTask.Examples
{
    class AnonymousObjectsExample
    {
        public void Run()
        {

        }

        public void Show(DataTransferObject dataTransferObject)
        {
            Console.WriteLine(dataTransferObject.Type);
        }
    }

    class BigClass
    {
        public int One { get; set; }
        public decimal Two { get; set; }
        public string Three { get; set; }
        public int Four { get; set; }
        public int Five { get; set; }
    }

    class SmallClass
    {
        public double MyProperty { get; set; }
    }

    class User
    {
        public string Name { get; set; }

        public List<SmallClass> MyProperty { get; set; } = new List<SmallClass>();
    }

    class DataTransferObject
    {
        public object Value { get; set; }
        public Type Type { get; set; }
    }
}
