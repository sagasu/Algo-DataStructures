using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Partition_to_K_Equal_Sum_Subsets
{
    class Partition_to_K_Equal_Sum_Subsets
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            nums = nums.OrderByDescending(x => x).ToArray();
            var sum = nums.Sum();
            if (sum % k != 0) return false;
            var dividedSum = sum / k;
            if (dividedSum < nums.Max()) return false;

            return Helper(nums, 0, 0, dividedSum, k, new HashSet<int>());
        }

        private bool Helper(int[] nums, int startIdx, int sum, int target, int k, HashSet<int> visitedIdx)
        {
            if (k == 1) return true;

            if (sum > target) return false;

            if (sum == target)
            {
                return Helper(nums, 0, 0, target, k - 1, visitedIdx);
            }

            for (var i = startIdx; i < nums.Length; i++)
            {
                if (visitedIdx.Contains(i)) continue;

                visitedIdx.Add(i);
                if (Helper(nums, i + 1, sum + nums[i], target, k, visitedIdx))
                {
                    return true;
                }
                visitedIdx.Remove(i);

                while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                    i++;
            }

            return false;
        }
    }
}
