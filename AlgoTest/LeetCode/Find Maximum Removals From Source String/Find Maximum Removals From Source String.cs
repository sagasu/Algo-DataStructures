using System;

namespace AlgoTest.LeetCode.Find_Maximum_Removals_From_Source_String;

public class Find_Maximum_Removals_From_Source_String
{
    public int MaxRemovals(string source, string pattern, int[] targetIndices) {
        int a = source.Length, b = pattern.Length, c = targetIndices.Length;
        int[] dp = new int[a + 1];
        for(int j = b - 1; j > -1; j--) {
            int[] dp2 = new int[a + 1];
            dp2[a] = 10000;
            for(int i = a - 1, k = c - 1; i > -1; i--) {
                if(source[i] == pattern[j]) {
                    while(k > -1 && targetIndices[k] > i) {
                        k--;
                    }
                    if(k > -1 && targetIndices[k] == i) {
                        dp2[i] = Math.Min(1 + dp[i+1], dp2[i+1]);
                    } else {
                        dp2[i] = dp[i+1];
                    }
                } else {
                    dp2[i] = dp2[i+1];
                }
            }
            dp = dp2;
        }
        return c - dp[0];
    }
}