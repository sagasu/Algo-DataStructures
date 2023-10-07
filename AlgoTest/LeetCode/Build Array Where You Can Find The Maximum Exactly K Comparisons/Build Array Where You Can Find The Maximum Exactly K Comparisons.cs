namespace AlgoTest.LeetCode.Build_Array_Where_You_Can_Find_The_Maximum_Exactly_K_Comparisons;

public class Build_Array_Where_You_Can_Find_The_Maximum_Exactly_K_Comparisons
{
    private const int MOD = 1000000007;

    public int NumOfArrays(int n, int m, int k) {
        var dp = new long[n + 1][][];
        var prefix = new long[n + 1][][];

        for (var i = 0; i <= n; i++) {
            dp[i] = new long[m + 1][];
            prefix[i] = new long[m + 1][];
            for (var j = 0; j <= m; j++) {
                dp[i][j] = new long[k + 1];
                prefix[i][j] = new long[k + 1];
            }
        }

        for (var num = 1; num <= m; num++) {
            dp[1][num][1] = 1;
            prefix[1][num][1] = (prefix[1][num - 1][1] + 1) % MOD;
        }

        for (var i = 1; i <= n; i++) 
            for (var maxNum = 1; maxNum <= m; maxNum++) 
                for (var cost = 1; cost <= k; cost++) {
                    var ans = (maxNum * dp[i - 1][maxNum][cost]) % MOD;
                    ans = (ans + prefix[i - 1][maxNum - 1][cost - 1]) % MOD;

                    dp[i][maxNum][cost] = (dp[i][maxNum][cost] + ans) % MOD;
                    prefix[i][maxNum][cost] = (prefix[i][maxNum - 1][cost] + dp[i][maxNum][cost]) % MOD;
                }
            
        

        return (int) prefix[n][m][k];
    }
}