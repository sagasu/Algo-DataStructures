namespace AlgoTest.LeetCode.Minimum_Swaps_to_Arrange_a_Binary_Grid;

public class Minimum_Swaps_to_Arrange_a_Binary_Grid
{
    public int MinSwaps(int[][] grid)
    {
        int n = grid.Length;
        int[] zeroCounts = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            int count = 0;

            for (int j = n - 1; j >= 0 && grid[i][j] == 0; j--)
                count++;
            
            zeroCounts[i] = count;
        }
        
        int swaps = 0;
        
        for (int i = 0; i < n; i++)
        {
            int target = n - 1 - i;
            int j = i;
            
            while (j < n && zeroCounts[j] < target)
                j++;
            
            if (j == n) 
                return -1;
            
            swaps += j - i;

            int temp = zeroCounts[j];

            for (int k = j; k > i; k--) {
                zeroCounts[k] = zeroCounts[k - 1];
            }
            
            zeroCounts[i] = temp;
        }
        
        return swaps;
    }
}