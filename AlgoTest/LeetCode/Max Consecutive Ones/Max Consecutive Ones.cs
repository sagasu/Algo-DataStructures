using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.MaxCosecutiveOnes
{
    internal class MaxCosecutiveOnes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var s = 0;
            var maxCon = -1;
            for (var e = 0; e < nums.Length; e++)
            {
                if (nums[e] == 0) { s = e + 1; }
                maxCon = Math.Max(maxCon, e - s + 1);
            }
            return maxCon;
        }
    }
}
