using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Obstacle_Removal_to_Reach_Corner;

public class Minimum_Obstacle_Removal_to_Reach_Corner
{
    public int MinimumObstacles(int[][] grid)
    {
        var pq = new PriorityQueue<(int row, int col, int obstacles), int>();
        var ob = 0;
        if (grid[0][0] == 1)
            ob = 1;
        
        pq.Enqueue((0, 0, ob), ob);
        grid[0][0] = int.MaxValue;

        while (pq.Count > 0)
        {
            var pp = pq.Dequeue();

            if (pp.row == grid.Length - 1 && pp.col == grid[pp.row].Length - 1)
                return pp.obstacles;
            
            CheckAndAddNeighbours(grid, pp.row + 1, pp.col, pp.obstacles, pq);
            CheckAndAddNeighbours(grid, pp.row - 1, pp.col, pp.obstacles, pq);
            CheckAndAddNeighbours(grid, pp.row, pp.col + 1, pp.obstacles, pq);
            CheckAndAddNeighbours(grid, pp.row, pp.col - 1, pp.obstacles, pq);
        }

        return grid.Length * grid[0].Length;
    }

    private static void CheckAndAddNeighbours(int[][] grid, int row, int col, int obstacles, PriorityQueue<(int row, int col, int obstacles), int> pq)
    {
        if (row < 0 || col < 0 || row == grid.Length || col == grid[row].Length || grid[row][col] == int.MaxValue)
            return;

        if (grid[row][col] == 1)
            obstacles = obstacles + 1;
        
        grid[row][col] = int.MaxValue;
        pq.Enqueue((row, col, obstacles), obstacles);
    }
}