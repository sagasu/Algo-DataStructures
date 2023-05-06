using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Subsequences_That_Satisfy_the_Given_Sum_Condition
{
    internal class Number_of_Subsequences_That_Satisfy_the_Given_Sum_Condition
    {
        public int NumSubseq(int[] nums, int target)
        {
            Array.Sort(nums);
            var ans = 0;
            var mod = 1_000_000_007;
            var b = 0;
            var l = nums.Length - 1;
            var pows = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++)
                pows[i] = i != 0 ? pows[i - 1] * 2 % mod : 1;
            
            while (b <= l)
                if (nums[b] + nums[l] > target) l--;
                else ans = (ans + pows[l - b++]) % mod;
            
            return ans;
        }
    }
}
