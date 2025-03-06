using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_Missing_and_Repeated_Values;

public class Find_Missing_and_Repeated_Values
{
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        var set = new HashSet<int>();
        var res = new int[2];
        int rows = grid.Length, cols = rows;
        for(int r=0;r<rows;r++){
            for(int c=0;c<cols;c++){
                if(set.Contains(grid[r][c])){
                    res[0] = grid[r][c];
                }
                set.Add(grid[r][c]);
            }
        }
        for(int i=1;i<=rows*rows;i++){
            if(!set.Contains(i)){
                res[1]=i;
                break;
            }
        }
        return res;
    }
}