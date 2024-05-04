using System;

namespace AlgoTest.LeetCode.Find_a_Peak_Element_II;

public class Find_a_Peak_Element_II
{
    public int[] FindPeakGrid(int[][] mat) {
        var m = mat.Length;
        var n = mat[0].Length;
        var left = 0;
        var right = n - 1;
        while(left <= right) {
            var mid = left + (right - left) / 2;
            var index = 0;
            for(int i = 0; i < m; i++)
                if(mat[i][mid] > mat[index][mid]) index = i;
            
            
            var leftVal = mid - 1 > 0 ? mat[index][mid - 1] : -1;
            var rightVal = mid + 1 < n ? mat[index][mid + 1] : -1;

            if(mat[index][mid] > leftVal && mat[index][mid] > rightVal) 
                return new int[2] {index, mid};
            

            if (mat[index][mid] < leftVal) 
                right = mid - 1;
            else 
                left = mid + 1;
        }

        return Array.Empty<int>();
    }
}