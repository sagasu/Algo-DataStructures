using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Sub_Islands;

public class Count_Sub_Islands
{
    public int CountSubIslands(int[][] grid1, int[][] grid2) {
        if(grid2 == null || grid2.Length == 0 )
            return 0;
        
        int m = grid2.Length, n = grid2[0].Length;
        var res = 0;
        var visited = new HashSet<(int,int)>();
        
        for(var i = 0; i < m; i++)
        {
            for(var j = 0; j < n; j++)
            {
                if(grid2[i][j] == 1 && !visited.Contains((i,j)))
                {
                    if(Dfs(grid1, grid2, i, j, visited))
                        res++;
                }
            }
        }
        
        return res;
    }
    
    private static bool Dfs(int[][] grid1, int[][] grid2, int row, int col, HashSet<(int,int)> visited)
    {
        int m = grid2.Length, n = grid2[0].Length;
        if(row < 0 || row >= m || col < 0 || col >= n || grid2[row][col] == 0 || visited.Contains((row,col)))
            return true;

        if(grid1[row][col] == 0)
            return false;
        
        visited.Add((row,col));
        
        var up = Dfs(grid1, grid2, row - 1, col, visited);
        var down = Dfs(grid1, grid2, row + 1, col, visited);
        var left = Dfs(grid1, grid2, row, col - 1, visited);
        var right = Dfs(grid1, grid2, row, col + 1, visited);
        
        return up && down && left && right;
    }
}