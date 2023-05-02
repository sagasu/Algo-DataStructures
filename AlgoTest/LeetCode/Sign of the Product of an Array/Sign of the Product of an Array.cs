using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Sign_of_the_Product_of_an_Array
{
    internal class Sign_of_the_Product_of_an_Array
    {
        public int ArraySign(int[] nums)
        {
            var isPositive = 1;
            foreach (var num in nums)
            {
                if (num == 0) return 0;
                if (num < 0) isPositive *= -1;
            }
            return isPositive;
        }
    }
}
