public class MinimumASCIIDeleteSumforTwoStrings {
    public int MinimumDeleteSum(string s1, string s2) {
        
        var dp = new int[s1.Length+1, s2.Length+1];
        
        for(var i = 1; i < s1.Length+1; ++i)
            dp[i,0] = dp[i-1,0] + s1[i-1];
        
        for(var i = 1; i < s2.Length+1; ++i)
            dp[0,i] = dp[0,i-1] + s2[i-1];
        
        for(var i = 1; i <= s1.Length; ++i)
            for(var j = 1; j <= s2.Length; ++j)
                dp[i,j] = s1[i-1] == s2[j-1] ? dp[i-1,j-1] :
                                               Math.Min(dp[i-1, j] + s1[i-1], dp[i, j-1] + s2[j-1]);
            
        return dp[s1.Length, s2.Length];
    }
}