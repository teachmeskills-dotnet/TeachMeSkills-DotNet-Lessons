using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.DotNet.DtoTask.Examples
{
    public static class ExtensionMethodExample
    {
        public static IEnumerable<ResultObject> IsThisValue(this List<int> list, Predicate<int> predicate)
        {
            var checkedList = new List<ResultObject>();
            foreach (var item in list)
            {
                checkedList.Add(new ResultObject
                {
                    Value = item,
                    Result = predicate(item)
                });
            }

            return checkedList;
        }
    }

    public class ResultObject
    {
        public int Value { get; set; }
        public bool Result { get; set; }
    }
}
