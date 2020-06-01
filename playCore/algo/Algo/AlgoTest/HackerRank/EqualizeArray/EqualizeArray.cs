using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.HackerRank.EqualizeArray
{
    public class EqualizeArray
    {
        static int equalizeArray(int[] arr)
        {
            if (arr.Length == 0)
                return 0;
            IDictionary<int,int> countElements = new Dictionary<int, int>();
            var max = 1;
            foreach (var element in arr)
            {
                if (countElements.ContainsKey(element))
                {
                    countElements[element] += 1;
                    if (countElements[element] > max)
                        max = countElements[element];
                }
                else
                {
                    countElements.Add(element, 1);
                }
            }

            return arr.Length - max;
        }
    }
}
