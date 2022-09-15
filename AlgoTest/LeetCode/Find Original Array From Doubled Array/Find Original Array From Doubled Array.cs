using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Find_Original_Array_From_Doubled_Array
{
    internal class Find_Original_Array_From_Doubled_Array
    {
        public int[] FindOriginalArray(int[] changed)
        {
            if (changed.Length % 2 == 1) return new int[] { }; 

            var count = new int[200001];
            foreach (int val in changed) ++count[val];

            List<int> result = new(Enumerable.Repeat(0, count[0] / 2)); 
            for (var val = 1; val <= 100000; ++val)
            {
                if (count[val] == 0) continue;
                count[val * 2] -= count[val];
                if (count[val * 2] < 0) return new int[] { };
                result.AddRange(Enumerable.Repeat(val, count[val]));
            }
            return result.ToArray();
        }
    }
}
