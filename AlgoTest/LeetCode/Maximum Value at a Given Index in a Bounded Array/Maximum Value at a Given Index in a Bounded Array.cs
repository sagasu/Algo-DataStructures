using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Value_at_a_Given_Index_in_a_Bounded_Array
{
    internal class Maximum_Value_at_a_Given_Index_in_a_Bounded_Array
    {
        public int MaxValue(int n, int index, int maxSum)
        {
            if (n == 1) return maxSum;

            if (n == maxSum) return 1;

            var left = (int)Math.Ceiling((double)maxSum / n);
            var right = (int)Math.Ceiling((double)maxSum / 2);

            while (left < right)
            {
                var mid = (left + right + 1) / 2;
                var curSum = GetCurrentSum(mid, index, n);
                if (curSum <= (long)maxSum)
                    left = mid;
                else
                    right = mid - 1;
            }

            return left;
        }

        private long GetCurrentSum(int curVal, int index, int n)
        {
            long curSum;
            
            if (curVal <= index)
                curSum = ((curVal) * (long)(curVal + 1) / 2) + index - curVal + 1;
            else
                curSum = (long)(2 * curVal - index) * (index + 1) / 2;
            
            if (curVal < n - index)
                curSum += ((curVal) * (long)(curVal + 1) / 2) + n - index - curVal;
            else
                curSum += (long)(2 * curVal - n + 1 + index) * (n - index) / 2;
            
            return curSum - curVal;
        }
    }
}
