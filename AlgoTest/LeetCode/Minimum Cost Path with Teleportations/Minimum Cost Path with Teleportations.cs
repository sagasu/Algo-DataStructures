namespace AlgoTest.LeetCode.Minimum_Cost_Path_with_Teleportations;

public class Minimum_Cost_Path_with_Teleportations
{
    public int MinCost(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int maxVal = 0;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (grid[i][j] > maxVal)
                    maxVal = grid[i][j];

        const int INF = int.MaxValue >> 1;

        int[,] dp = new int[m, n];
        int[] best = new int[maxVal + 1];
        int[] prefix = new int[maxVal + 1];

        for (int i = 0; i <= maxVal; i++)
            best[i] = INF;

        dp[m - 1, n - 1] = 0;
        best[grid[m - 1][n - 1]] = 0;

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (i == m - 1 && j == n - 1) continue;

                int cost = INF;
                if (i + 1 < m)
                    cost = dp[i + 1, j] + grid[i + 1][j];
                if (j + 1 < n)
                {
                    int right = dp[i, j + 1] + grid[i][j + 1];
                    if (right < cost) cost = right;
                }

                dp[i, j] = cost;

                int v = grid[i][j];
                if (cost < best[v]) best[v] = cost;
            }
        }

        while (k-- > 0)
        {
            int min = best[0];
            prefix[0] = min;
            for (int v = 1; v <= maxVal; v++)
            {
                if (best[v] < min) min = best[v];
                prefix[v] = min;
            }

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == m - 1 && j == n - 1) continue;

                    int walk = INF;
                    if (i + 1 < m)
                        walk = dp[i + 1, j] + grid[i + 1][j];
                    if (j + 1 < n)
                    {
                        int right = dp[i, j + 1] + grid[i][j + 1];
                        if (right < walk) walk = right;
                    }

                    int val = grid[i][j];
                    int tele = prefix[val];

                    int res = walk < tele ? walk : tele;
                    dp[i, j] = res;

                    if (res < best[val]) best[val] = res;
                }
            }
        }

        return dp[0, 0];
    }
}