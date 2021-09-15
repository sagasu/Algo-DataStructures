using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Longest_Turbulent_Subarray
{
    class Longest_Turbulent_Subarray
    {
        public int MaxTurbulenceSize(int[] arr)
        {
            int start = 0, end = 0, ret = 1;
            while (++end < arr.Length)
            {
                var c = arr[end - 1].CompareTo(arr[end]);
                if (c == 0)
                    start = end;
                else if (end == arr.Length - 1 || c * arr[end].CompareTo(arr[end + 1]) != -1)
                {
                    ret = Math.Max(ret, end - start + 1);
                    start = end;
                }
            }
            return ret;
        }
    }
}
