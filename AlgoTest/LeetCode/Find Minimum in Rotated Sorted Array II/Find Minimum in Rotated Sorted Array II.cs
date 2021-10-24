using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Find_Minimum_in_Rotated_Sorted_Array_II
{
    class Find_Minimum_in_Rotated_Sorted_Array_II
    {
        public int FindMin(int[] arr)
        {
            // Pick the first one as pivot.
            var minSoFar = arr[0];
            var l = 0;
            var r = arr.Length - 1;
            while (l <= r)
            {
                var mid = (l + r) / 2;

                if (arr[mid] < minSoFar)
                {
                    minSoFar = arr[mid];
                }

                // If the value is the same you can only move one. 
                if (arr[mid] == arr[r])
                {
                    r = r - 1;
                }
                else
                    // Look for rotation
                if (arr[mid] < arr[r])
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return minSoFar;
        }
    }
}
