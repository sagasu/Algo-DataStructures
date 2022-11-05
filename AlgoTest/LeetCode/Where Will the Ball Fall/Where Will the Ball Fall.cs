public class Solution {
    public int[] FindBall(int[][] grid)
    {

        var row = grid.Length;
        var col = grid[0].Length;
        bool ballstuck = false;
        List<int> res = new List<int>();

        for (int i = 0; i < col; i++)
        {
            int k = i;
            for (int j = 0; j < row; j++)
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