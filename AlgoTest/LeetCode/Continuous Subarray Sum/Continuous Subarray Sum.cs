using System.Collections.Generic;

namespace AlgoTest.LeetCode
{
    public class Solution3
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            var dict = new Dictionary<int, int> { [0] = -1 };
            var sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (dict.ContainsKey(sum % k))
                {
                    if (i - dict[sum % k] >= 2)
                    {
                        return true;
                    }
                }
                else
                {
                    dict[sum % k] = i;
                }
            }

            return false;
        }
    }
}