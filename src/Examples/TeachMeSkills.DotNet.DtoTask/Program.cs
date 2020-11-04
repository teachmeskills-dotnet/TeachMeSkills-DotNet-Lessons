using System;
using System.Collections.Generic;
using System.Linq;
using TeachMeSkills.DotNet.DtoTask.Examples;

namespace TeachMeSkills.DotNet.DtoTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //var user = new User();
            //user.MyProperty.Add(new SmallClass
            //{
            //    MyProperty = 1
            //});

            //var user1 = new User();
            //user1.MyProperty.Add(new SmallClass
            //{
            //    MyProperty = 111
            //});
            //user1.MyProperty.Add(new SmallClass
            //{
            //    MyProperty = 222
            //});

            var bigClass = new BigClass
            {
                One = 1,
                Two = 1.0M,
                Three = "1",
                Four = 0,
                Five = 2,
            };

            var smallClass = new SmallClass
            {
                MyProperty = 1
            };

            var anonObject = new AnonymousObjectsExample();
            var dtoObject1 = new DataTransferObject
            {
                Value = bigClass.Two,
                Type = bigClass.GetType(),
            };
            var dtoObject2 = new DataTransferObject
            {
                Value = smallClass.MyProperty,
                Type = smallClass.GetType(),
            };

            // Огромные вычисления :)
            var anonObject3 = new
            {
                Value = bigClass.Two,
                Type = bigClass.GetType(),
            };
            var dtoObject3ByAnonObject = new DataTransferObject
            {
                Value = anonObject3.Value,
                Type = anonObject3.Type,
            };

            Console.WriteLine(anonObject3.GetType());
            Console.WriteLine(dtoObject3ByAnonObject.GetType());

            anonObject.Show(dtoObject3ByAnonObject);
            anonObject.Show(dtoObject1);
            anonObject.Show(dtoObject2);

            var listWithValues = new List<int>
            {
                0,
                1,
                2,
                3,
                0,
                4,
                0,
                5,
                0,
            };

            var resultValue1 = new List<ResultObject>();
            var resultValue2 = new List<ResultObject>();
            var resultValue3 = new List<ResultObject>();

            foreach (var item in listWithValues)
            {
                var newTempObject = new ResultObject
                {
                    Value = item,
                    Result = CheckUp(item)
                };

                resultValue1.Add(newTempObject);
            }

            static ResultObject selector(int x) => new ResultObject
            {
                Value = x,
                Result = x == 0
            };

            resultValue2 = listWithValues
                .Select(selector)
                .ToList();

            resultValue3 = listWithValues.IsThisValue(x => x == 1).ToList();

            Console.ReadKey();
        }

        private static bool CheckUp(int val1) => val1 == 0;
    }
}
