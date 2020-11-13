using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ContainsDuplicateElement
{
    class ContainsDuplicateElement
    {
        public bool ContainsDuplicate(int[] nums)
        {
            IDictionary<int,int> dupsCount = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dupsCount.Keys.Contains(num))
                    return true;
                dupsCount.Add(num, 1);
            }

            return false;
        }
    }
}
