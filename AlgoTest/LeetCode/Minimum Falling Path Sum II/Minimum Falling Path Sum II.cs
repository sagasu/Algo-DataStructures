using System;

namespace AlgoTest.LeetCode.Minimum_Falling_Path_Sum_II;

public class Minimum_Falling_Path_Sum_II
{
    public int MinFallingPathSum(int[][] grid) {
        int r=grid.Length;

        if(r==1)
            return grid[0][0];
            
        int min=Int32.MaxValue;

        for(int i=r-2;i>=0;i--)
        {
            for(int j=0;j<r;j++)
            {
                int minPath=Int32.MaxValue;
                for(int k=0;k<r;k++)
                {
                    if(k==j)
                        continue;
                    
                    minPath=Math.Min(minPath, grid[i+1][k]);
                }

                grid[i][j]+=minPath;

                if(i==0)
                    min=Math.Min(min, grid[i][j]);
            }
        }

        return min;
    }
}