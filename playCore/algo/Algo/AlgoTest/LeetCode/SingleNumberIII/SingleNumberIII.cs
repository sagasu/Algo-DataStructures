using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.SingleNumberIII
{
    class SingleNumberIII
    {
        private HashSet<int> visitedNumbers = new HashSet<int>();

        public int[] SingleNumber(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (visitedNumbers.Contains(num))
                {
                    visitedNumbers.Remove(num);
                }
                else
                {
                    visitedNumbers.Add(num);
                }
            }

            return visitedNumbers.ToArray();
        }
    }
}
