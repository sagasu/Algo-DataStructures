using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.MergeTwoSortedArrays
{
    public class MergeTwoSortedArrays
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var index1 = m-1;
            var index2 = n-1;
            var endIndex = nums1.Length - 1;

            while (true)
            {
                if (index1 < 0 && index2 < 0)
                    break;



                if (index2 < 0 || index1 >= 0 && nums1[index1] > nums2[index2])
                {
                    nums1[endIndex] = nums1[index1];
                    endIndex -= 1;
                    index1 -= 1;
                }
                else
                {
                    nums1[endIndex] = nums2[index2];
                    endIndex -= 1;
                    index2 -= 1;
                }
            }
        }
    }
}
