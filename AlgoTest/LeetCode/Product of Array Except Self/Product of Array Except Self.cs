using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Product_of_Array_Except_Self
{
    class Product_of_Array_Except_Self
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i];
            }

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                result[i] = result[i] * result[i + 1];
            }

            for (var i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i - 1];
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var left = 1;
                var right = 1;
                if (i + 1 < nums.Length)
                {
                    right = result[i + 1];
                }

                if (i - 1 >= 0)
                {
                    left = nums[i - 1];
                }

                result[i] = left * right;
            }

            return result;
        }
    }
}
