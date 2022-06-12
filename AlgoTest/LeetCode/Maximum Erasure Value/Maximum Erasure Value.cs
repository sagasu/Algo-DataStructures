using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Erasure_Value
{
    internal class Maximum_Erasure_Value
    {
        public int MaximumUniqueSubarray(int[] nums)
        {

            var max = 0;
            var sum = 0;
            var start = 0;
            var seen = new HashSet<int>();
            var i = 0;

            while (i < nums.Length)
            {

                if (seen.Contains(nums[i]))
                {
                    seen.Remove(nums[start]);
                    sum -= nums[start++];
                }
                else
                {
                    seen.Add(nums[i]);
                    sum += nums[i++];
                    max = Math.Max(sum, max);
                }
            }
            return max;
        }
    }
}
