using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Two_Sum_II___Input_Array_Is_Sorted
{
    internal class Two_Sum_II___Input_Array_Is_Sorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var n = numbers.Length;
            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                var result = numbers[left] + numbers[right];
                if (result == target)
                    return new int[] { left + 1, right + 1 };
               
                if (result < target) left++;
                else right--;
            }
            return null;
        }
    }
}
