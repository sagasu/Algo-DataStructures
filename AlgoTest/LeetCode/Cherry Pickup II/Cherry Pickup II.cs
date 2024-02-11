using System;

namespace AlgoTest.LeetCode.Cherry_Pickup_II;

public class Cherry_Pickup_II
{
    public int CherryPickup(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var dp = new int[cols][];
        for (var i = 0; i < cols; i++)
            dp[i] = new int[cols];
        

        for (var i = rows - 1; i >= 0; i--) {
            var nextDp = new int[cols][];
            
            for (var j = 0; j < cols; j++)
                nextDp[j] = new int[cols];
            
            for (var j1 = 0; j1 < cols; j1++) {
                for (var j2 = 0; j2 < cols; j2++) {
                    var cherries = grid[i][j1] + (j1 != j2 ? grid[i][j2] : 0);
                    var maxNext = 0;

                    for (var k1 = j1 - 1; k1 <= j1 + 1; k1++) 
                        for (var k2 = j2 - 1; k2 <= j2 + 1; k2++) 
                            if (k1 >= 0 && k1 < cols && k2 >= 0 && k2 < cols) 
                                maxNext = Math.Max(maxNext, dp[k1][k2]);
                    
                    nextDp[j1][j2] = cherries + maxNext;
                }
            }

            dp = nextDp;
        }

        return dp[0][cols - 1];
    }
}