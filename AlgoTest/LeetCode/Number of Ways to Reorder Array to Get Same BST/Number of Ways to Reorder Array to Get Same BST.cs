using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Ways_to_Reorder_Array_to_Get_Same_BST
{
    internal class Number_of_Ways_to_Reorder_Array_to_Get_Same_BST
    {
        public int NumOfWays(int[] nums) => (int)(GetNumOfWays(nums) % (1_000_000_007)) - 1;
        
        BigInteger GetNumOfWays(int[] nums)
        {
            if (nums.Length < 3) return 1;

            var root = nums[0];
            var left = nums.Where(p => p < root).ToArray();
            var right = nums.Where(p => p > root).ToArray();

            return Combine(right.Length + left.Length, right.Length) * GetNumOfWays(left) * GetNumOfWays(right);
        }

        BigInteger Combine(BigInteger n, BigInteger k) => n < 2 ? 1 : Factorial(n) / Factorial(n - k) / Factorial(k);
        
        BigInteger Factorial(BigInteger n) => n < 2 ? 1L : n * Factorial(n - 1);
        
    }
}
