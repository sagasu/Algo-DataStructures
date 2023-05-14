using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximize_Score_After_N_Operations
{
    internal class Maximize_Score_After_N_Operations
    {
        public int MaxScore(int[] nums)
        {
            int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

            var n = nums.Length;
            var gcdVal = new Dictionary<int, int>();

            for (var i = 0; i < n; ++i)
            for (var j = i + 1; j < n; ++j)
                gcdVal.Add((1 << i) + (1 << j), GCD(nums[i], nums[j]));
            
            var dp = new int[1 << n];

            for (var i = 0; i < 1 << n; ++i)
            {
                var bits = System.Numerics.BitOperations.PopCount((uint)i);
                if (bits % 2 != 0) continue;
                
                foreach (var (k, v) in gcdVal)
                {
                    if ((k & i) != 0) continue;
                    
                    dp[i ^ k] = Math.Max(dp[i ^ k], dp[i] + v * (bits / 2 + 1));
                }
            }

            return dp[(1 << n) - 1];
        }
    }
}
