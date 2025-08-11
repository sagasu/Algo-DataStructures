using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Range_Product_Queries_of_Powers;

public class Range_Product_Queries_of_Powers
{
    static readonly long MOD = 1000000007;
    
    public int[] ProductQueries(int n, int[][] queries) {
        var s = Convert.ToString(n, 2);
        var lst = new List<int>();
        
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '1') {
                int idx = s.Length - i - 1;
                lst.Add((int)((1L << idx) % MOD));
            }
        }
        
        var x = queries.Length;
        var ans = new int[x];
        for (int i = 0; i < x; i++) {
            var start = queries[i][0];
            var end = queries[i][1];
            long res = 1;
            for (int j = start; j <= end; j++) {
                res = (res * lst[j]) % MOD;
            }
            ans[i] = (int)res;
        }
        return ans;
    }
}