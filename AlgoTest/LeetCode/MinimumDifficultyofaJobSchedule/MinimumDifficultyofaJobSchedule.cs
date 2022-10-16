public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        var len = jobDifficulty.Length;
        if(len < d)
            return -1;
        else if(len == d)
            return jobDifficulty.Sum();
        var dp = new int[len,d+1];
        var sum = 0;
        var maxSofar = 0;
        for(int i = 0;i<len;i++){
            sum += jobDifficulty[i];
            maxSofar = Math.Max(maxSofar,jobDifficulty[i]);
            for(int k = 2;k<=d && k <= i+1;k++){
                
                var v = sum;
                var maxD = jobDifficulty[i];
                
                for(int j = i;j>=0;j--){
                    
                    maxD = Math.Max(maxD,jobDifficulty[j]);
                    
                    if(j < k-1)
                        break;
                    v = Math.Min(v, (j==0 ? 0 : dp[j-1,k-1])+maxD);
                }
                
                dp[i,k] = v;
            }
            
            dp[i,1] = maxSofar;
        }
        
        return dp[len-1,d];
    }
}