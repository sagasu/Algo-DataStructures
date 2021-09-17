using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Intersection_of_Two_Arrays_II
{
    class Intersection_of_Two_Arrays_II
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var numAndCount1 = new Dictionary<int, int>();

            foreach (var num in nums1)
            {
                if (!numAndCount1.ContainsKey(num)) numAndCount1[num] = 0;

                numAndCount1[num]++;
            }

            var result = new List<int>();

            foreach (var num in nums2)
            {
                if (numAndCount1.ContainsKey(num) && numAndCount1[num] > 0)
                {
                    result.Add(num);

                    numAndCount1[num]--;
                }
            }

            return result.ToArray();
		}
    }
}
