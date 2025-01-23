namespace AlgoTest.LeetCode.Count_Servers_that_Communicate;

public class Count_Servers_that_Communicate
{
    public int CountServers(int[][] grid) {
        int result = 0;
        int[] rows = new int[grid.Length], cols = new int[grid[0].Length];

        for(int i = 0; i < grid.Length; i++)
            for(int j = 0; j < grid[0].Length; j++)
                if(grid[i][j] == 1)
                {
                    rows[i]++;
                    cols[j]++;
                }

        for(int i = 0; i < grid.Length; i++)
            for(int j = 0; j < grid[0].Length; j++)
                if(grid[i][j] == 1 && (rows[i] > 1 || cols[j] > 1))
                    result++;

        return result;
    }
}