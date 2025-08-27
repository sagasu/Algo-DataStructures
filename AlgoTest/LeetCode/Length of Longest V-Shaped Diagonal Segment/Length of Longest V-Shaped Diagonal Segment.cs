using System;

namespace AlgoTest.LeetCode.Length_of_Longest_V_Shaped_Diagonal_Segment;

public class Length_of_Longest_V_Shaped_Diagonal_Segment
{
    private readonly int[][] DIRS =
        new int[][] { new int[] { 1, 1 }, new int[] { 1, -1 },
            new int[] { -1, -1 }, new int[] { -1, 1 } };
    private int[,,,] memo;
    private int[][] grid;
    private int m, n;

    public int LenOfVDiagonal(int[][] grid)
    {
        this.grid = grid;
        m = grid.Length;
        n = grid[0].Length;
        memo = new int[m, n, 4, 2];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < 2; l++)
                    {
                        memo[i, j, k, l] = -1;
                    }
                }
            }
        }

        int res = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    for (int direction = 0; direction < 4; direction++)
                    {
                        res = Math.Max(res, Dfs(i, j, direction, true, 2) + 1);
                    }
                }
            }
        }
        return res;
    }

    private int Dfs(int cx, int cy, int direction, bool turn, int target)
    {
        int nx = cx + DIRS[direction][0];
        int ny = cy + DIRS[direction][1];
        /* If it goes beyond the boundary or the next node's value is not the
         * target value, then return */
        if (nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] != target)
        {
            return 0;
        }

        int turnInt = turn ? 1 : 0;
        if (memo[nx, ny, direction, turnInt] != -1)
        {
            return memo[nx, ny, direction, turnInt];
        }

        int maxStep = Dfs(nx, ny, direction, turn, 2 - target);
        if (turn)
        {
            maxStep = Math.Max(
                maxStep, Dfs(nx, ny, (direction + 1) % 4, false, 2 - target));
        }
        memo[nx, ny, direction, turnInt] = maxStep + 1;
        return maxStep + 1;
    }
}