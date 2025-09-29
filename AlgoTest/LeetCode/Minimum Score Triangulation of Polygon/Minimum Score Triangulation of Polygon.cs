using System;

namespace AlgoTest.LeetCode.Minimum_Score_Triangulation_of_Polygon;

public class Minimum_Score_Triangulation_of_Polygon
{
    public int MinScoreTriangulation(int[] values) {
        int n = values.Length;
        int[,] dp = new int[n, n];

        for (int gap = 2; gap < n; gap++) {
            for (int i = 0; i + gap < n; i++) {
                int j = i + gap;
                dp[i, j] = int.MaxValue;

                for (int k = i + 1; k < j; k++) {
                    int score = dp[i, k] + dp[k, j] + values[i] * values[k] * values[j];
                    dp[i, j] = Math.Min(dp[i, j], score);
                }
            }
        }

        return dp[0, n - 1];
    }
}