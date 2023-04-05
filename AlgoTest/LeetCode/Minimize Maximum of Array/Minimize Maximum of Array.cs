using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimize_Maximum_of_Array
{
    public class Minimize_Maximum_of_Array
    {
        public int MinimizeArrayValue(int[] nums)
        {
            long answer = 0, prefixSum = 0;
            
            for (var i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];
                answer = Math.Max(answer, (prefixSum + i) / (i + 1));
            }

            return (int)answer;
        }
    }
}
