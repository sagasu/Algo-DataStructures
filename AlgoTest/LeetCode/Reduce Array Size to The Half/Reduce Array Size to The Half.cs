using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Reduce_Array_Size_to_The_Half
{
    internal class Reduce_Array_Size_to_The_Half
    {
        public int MinSetSize(int[] arr)
        {
            var freq = arr
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            var counts = 0;
            return freq
                .Keys
                .OrderByDescending(x => freq[x])
                .TakeWhile(x => {
                    counts += freq[x];
                    return counts < arr.Length / 2;
                })
                .Count() + 1;
        }
    }
}
