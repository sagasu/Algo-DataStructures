using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.FindtheDuplicateNumber
{
    class FindtheDuplicateNumber
    {
        public int FindDuplicate(int[] nums)
        {
            var hashSet = new HashSet<int>();
            foreach (var num in nums)
            {
                if (hashSet.Contains(num))
                    return num;

                hashSet.Add(num);
            }

            return 0;
        }
    }
}
