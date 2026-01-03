namespace AlgoTest.LeetCode.Number_of_Ways_to_Paint_N___3_Grid;

public class Number_of_Ways_to_Paint_N___3_Grid
{
    const int MOD = (int)1e9 + 7;
    int Rec(int row, int prev1, int prev2, int prev3, int[,,,] dp){
        if(row < 0) return 1;
        if(dp[row, prev1, prev2, prev3] != 0) return dp[row, prev1, prev2, prev3];
        int count = 0;
        for(int i = 1; i <= 3; i++){
            if(i == prev1) continue;
            for(int j = 1; j <= 3; j++){
                if(j == i || j == prev2) continue;
                for(int k = 1; k <= 3; k++){
                    if(k == j || k == prev3) continue;
                    count = (count + Rec(row - 1, i, j, k, dp) % MOD) % MOD;
                }
            }
        }
        return dp[row, prev1, prev2, prev3] = count;
    }
    public int NumOfWays(int n) {
        int[,,,] dp = new int[n, 4, 4, 4];
        return Rec(n - 1, 0, 0, 0, dp);
    }
}