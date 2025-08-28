using System;

namespace AlgoTest.LeetCode.Sort_Matrix_by_Diagonals;

public class Sort_Matrix_by_Diagonals
{
    public int[][] SortMatrix(int[][] grid)
    {
        int length = grid.Length;
        
        Comparison<int> descending = (a, b) => b.CompareTo(a);
        
        int[] temp = new int[length];
        
        for (int i = 0; i < length; i++)
            temp[i] = grid[i][i];

        Array.Sort(temp, descending);
        
        for (int i = 0; i < length; i++)
            grid[i][i] = temp[i];
        
        for (int i = 1; i < length - 1; i++)
        {
            temp = new int[length - i];
            
            for (int j = i; j < length; j++)
                temp[j - i] = grid[j][j - i];
            
            Array.Sort(temp, descending);
            
            for (int j = i; j < length; j++)
                grid[j][j - i] = temp[j - i];

            for (int j = i; j < length; j++)
                temp[j - i] = grid[j - i][j];
            
            Array.Sort(temp);
            
            for (int j = i; j < length; j++)
                grid[j - i][j] = temp[j - i];
        }

        return grid;
    }
}