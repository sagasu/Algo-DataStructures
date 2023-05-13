using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Count_Ways_To_Build_Good_Strings
{
    internal class Count_Ways_To_Build_Good_Strings
    {
        public int CountGoodStrings(int low, int high, int zero, int one)
        {
            var dp = new int[high + 1];
            var res = 0;
            var mod = 1000000007;
            dp[0] = 1;
            
            for (var i = 1; i <= high; ++i)
            {
                if (i >= zero) dp[i] = (dp[i] + dp[i - zero]) % mod;
                if (i >= one) dp[i] = (dp[i] + dp[i - one]) % mod;
                if (i >= low) res = (res + dp[i]) % mod;
            }

            return res;
        }
    }
}
