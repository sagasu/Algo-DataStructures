using System;

public class Solution19 {
    public int GetLengthOfOptimalCompression(string s, int k) {
        var memo = new int[s.Length, k + 1];
        return Helper(s, 0, k, memo);
    }
    
    private int Helper(string s, int start, int k, int[,] memo){
        if(start >= s.Length || s.Length - start <= k)
            return 0;
        if(memo[start, k] != 0)
            return memo[start, k];
        
        var freq = new int[26];
        var maxFreq = 0;
        var ans = s.Length;
        
        for(var i = start;i < s.Length;i++){
            freq[s[i] - 'a'] += 1;
            maxFreq = Math.Max(maxFreq, freq[s[i] - 'a']);
            var len = 1 + (maxFreq > 1 ? maxFreq.ToString().Length : 0);
            if(k >= i - start + 1 - maxFreq)
                ans = Math.Min(ans, len + Helper(s, i + 1, k - (i - start + 1 - maxFreq), memo));
            
        }
        
        memo[start, k] = ans;
        return ans;
    }
}