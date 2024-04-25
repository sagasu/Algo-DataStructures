using System;

namespace AlgoTest.LeetCode.Longest_Ideal_Subsequence;

public class Longest_Ideal_Subsequence
{
    public int LongestIdealString(string s, int k) {
        var lasts = new int[26];
        
        var result = 0;
        
        foreach (var c in s)
        {
            var current = 1;
            
            for (var d = -k; d <= k; ++d) {
                var index = (c - 'a' + d);

                if (index < 0 || index > 25)
                    continue;
                
                current = Math.Max(lasts[index] + 1, current);
            }
            
            result = Math.Max(lasts[c - 'a'] = current, result);
        }
        
        return result;
    }
}