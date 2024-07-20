using System;

namespace AlgoTest.LeetCode.Find_Valid_Matrix_Given_Row_and_Column_Sums;

public class Find_Valid_Matrix_Given_Row_and_Column_Sums
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        var res = new int[rowSum.Length][];
        for(var i =0; i<res.Length; i++){
            var temp = new int[colSum.Length];
            for(var j = 0; j<temp.Length; j++){
                temp[j] = Math.Min(rowSum[i], colSum[j]);
                rowSum[i] -= temp[j];
                colSum[j] -= temp[j];
            }
            res[i] = temp;
        }
        return res;
    }
}