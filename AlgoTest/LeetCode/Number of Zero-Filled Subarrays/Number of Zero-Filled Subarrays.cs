using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Zero_Filled_Subarrays
{
    internal class Number_of_Zero_Filled_Subarrays
    {
        public long ZeroFilledSubarray(int[] nums)
        {
            long res = 0;
            long curr = 0;

            foreach (var n in nums)
                if (n == 0) res += ++curr;
                else curr = 0;

            return res;
        }
    }
}
