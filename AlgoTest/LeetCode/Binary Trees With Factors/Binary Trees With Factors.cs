using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Binary_Trees_With_Factors
{
    internal class Binary_Trees_With_Factors
    {
        public int NumFactoredBinaryTrees(int[] arr)
        {
            long mod = 1000000007;
            Array.Sort(arr);
            var dp = new Dictionary<int, long>();

            for (var i = 0; i < arr.Length; ++i)
            {
                dp[arr[i]] = 1;
                for (var j = 0; j < i; ++j)
                    if (arr[i] % arr[j] == 0 && dp.ContainsKey(arr[i] / arr[j]))
                        dp[arr[i]] += (dp[arr[j]] * dp[arr[i] / arr[j]]) % mod;
                    
                
            }

            long res = 0;
            foreach (var a in dp)
                res += a.Value;
            
            var ans = res % mod;
            return (int)ans;
        }
    }
}
