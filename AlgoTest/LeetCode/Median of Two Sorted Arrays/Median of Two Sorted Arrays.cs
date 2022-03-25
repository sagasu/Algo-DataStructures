using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Median_of_Two_Sorted_Arrays
{
    internal class Median_of_Two_Sorted_Arrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var lst = new List<int>();
            lst.AddRange(nums1);
            lst.AddRange(nums2);
            lst.Sort();
            if (lst.Count % 2 == 0) return (lst[lst.Count / 2] + lst[(lst.Count / 2) - 1]) / 2.0;
            else return lst[(lst.Count / 2)];
            
        }
    }
}
