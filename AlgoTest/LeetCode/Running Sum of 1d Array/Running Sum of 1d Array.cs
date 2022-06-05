using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Running_Sum_of_1d_Array
{
    internal class Running_Sum_of_1d_Array
    {
        public int[] RunningSum(int[] nums) => nums.Select((num, i) => i is 0 ? num : nums[i] += nums[i - 1]).ToArray();
    }
}
