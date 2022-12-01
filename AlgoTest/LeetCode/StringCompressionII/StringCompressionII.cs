using System;

public class Solution19 {
    public int GetLengthOfOptimalCompression(string s, int k) {
        var memo = new int[s.Length, k + 1];
        return Helper(s, 0, k, memo);
    }
    
    private int Helper(string s, int start, int k, int[,] memo){
        if(start >= s.Length || s.Length - start <= k){
            return 0;
        }
        
        // Console.WriteLine($"start : {start}, k : {k}");
        if(memo[start, k] != 0){
            return memo[start, k];
        }
        
        int[] freq = new int[26];
        int maxFreq = 0;
        int ans = s.Length;
        
        for(int i = start;i < s.Length;i++){
            freq[s[i] - 'a'] += 1;
            maxFreq = Math.Max(maxFreq, freq[s[i] - 'a']);
            // we are mot considering maxFreq > 1 i.e. a1 will be a, but aaa will be a3
            int len = 1 + (maxFreq > 1 ? maxFreq.ToString().Length : 0);
            // Console.WriteLine($"i : {i}, len : {len}, k - (i - start + 1 - len) : {k - (i - start + 1 - len)}");
            if(k >= i - start + 1 - maxFreq){
                ans = Math.Min(ans, len + Helper(s, i + 1, k - (i - start + 1 - maxFreq), memo));
            }
        }
        
        memo[start, k] = ans;
        return ans;
    }
}