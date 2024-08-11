using System;

namespace AlgoTest.LeetCode.Minimum_Number_of_Days_to_Disconnect_Island;

public class Minimum_Number_of_Days_to_Disconnect_Island
{
    public int MinDays(int[][] grid) {
        Func<int> countIslands = () => {
            int rows = grid.Length;
            int cols = grid[0].Length;
            bool[][] seen = new bool[rows][];
            for (int i = 0; i < rows; i++) {
                seen[i] = new bool[cols];
            }
            int islands = 0;

            Action<int, int> dfs = null;
            dfs = (r, c) => {
                seen[r][c] = true;
                int[][] directions = new int[][] {
                    new int[] {-1, 0}, // up
                    new int[] {1, 0},  // down
                    new int[] {0, -1}, // left
                    new int[] {0, 1}   // right
                };
                foreach (var dir in directions) {
                    int nr = r + dir[0], nc = c + dir[1];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1 && !seen[nr][nc]) {
                        dfs(nr, nc);
                    }
                }
            };

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (grid[i][j] == 1 && !seen[i][j]) {
                        islands++;
                        dfs(i, j);
                    }
                }
            }
            return islands;
        };

        if (countIslands() != 1) return 0;

        foreach (var t in grid)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (t[j] != 1) continue;
                t[j] = 0;
                if (countIslands() != 1) return 1;
                t[j] = 1;
            }
        }

        return 2;
    }
}