using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode._4Sum
{
    public class _4Sum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return kSum(nums, 0, 4, target);
        }

        public IList<IList<int>> kSum(int[] nums, int start, int k, int target)
        {
            var len = nums.Length;
            IList<IList<int>> res = new List<IList<int>>();
            if (k == 2)
            {
                int left = start, right = len - 1;
                while (left < right)
                {
                    var sum = nums[left] + nums[right];
                    if (sum == target)
                    {
                        res.Add((new List<int> { nums[left], nums[right] }));
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < target) left++;
                    else right--;
                }
            }
            else
            {
                for (var i = start; i < len - k + 1; i++)
                {
                    while (i > start && i < len - 1 && nums[i] == nums[i - 1]) { i++; };
                    var temp = kSum(nums, i + 1, k - 1, target - nums[i]);
                    foreach (var element in temp)
                    {
                        element.Add(nums[i]);
                    }
                    foreach (var val in temp)
                    {
                        res.Add(val);
                    }
                }
            }

            return res;
        }
	}
}
