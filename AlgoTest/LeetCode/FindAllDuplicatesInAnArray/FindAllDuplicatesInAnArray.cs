using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.FindAllDuplicatesInAnArray
{
    //Could you do it without extra space and in O(n) runtime?
    // notice that 1 ≤ a[i] ≤ n (n = size of array) int this problem
    class FindAllDuplicatesInAnArray
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var duplicates = new List<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                    duplicates.Add(Math.Abs(nums[i]));
                nums[index] = -nums[index];
            }

            return duplicates;
        }
    }
}
