using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimize_the_Maximum_Difference_of_Pairs
{
    internal class Minimize_the_Maximum_Difference_of_Pairs
    {
        public int MinimizeMax(int[] nums, int p)
        {
            Array.Sort(nums);
            int left = 0, right = nums[^1] - nums[0];

            while (left < right)
            {
                var mid = (left + right) / 2;
                var count = 0;
                for (var i = 1; i < nums.Length && count < p; i++)
                {
                    if (nums[i] - nums[i - 1] <= mid)
                    {
                        count++;
                        i++;
                    }
                }

                if (count >= p) right = mid;
                else left = mid + 1;
            }

            return left;
        }
    }
}
