using System.Collections.Generic;

public class Solution25 {
    public int[] FindBall(int[][] grid)
    {

        var row = grid.Length;
        var col = grid[0].Length;
        var ballstuck = false;
        var res = new List<int>();

        for (var i = 0; i < col; i++)
        {
            int k = i;
            for (var j = 0; j < row; j++)
            {
                // check right
                if (k + 1 <= col - 1 && grid[j][k] == 1 && grid[j][k + 1] == 1)
                { ballstuck = false; k++; continue; }
                // check left
                else if (k - 1 >= 0 && grid[j][k] == -1 && grid[j][k - 1] == -1)
                { ballstuck = false; k--; continue; }
                else
                { ballstuck = true; res.Add(-1); break; }
            }
            if (!ballstuck)
                res.Add(k);
            ballstuck = false;
        }
        return res.ToArray();
    }
}