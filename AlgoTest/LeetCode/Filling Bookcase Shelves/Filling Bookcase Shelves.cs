using System;

namespace AlgoTest.LeetCode.Filling_Bookcase_Shelves;

public class Filling_Bookcase_Shelves
{
    public int MinHeightShelves(int[][] books, int shelfWidth) {
        var n = books.Length;
        var dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (var i = 1; i <= n; i++) {
            int width = 0, height = 0;
            for (var j = i; j > 0; j--) {
                width += books[j - 1][0];
                if (width > shelfWidth) break;
                height = Math.Max(height, books[j - 1][1]);
                dp[i] = Math.Min(dp[i], dp[j - 1] + height);
            }
        }

        return dp[n];
    }
}