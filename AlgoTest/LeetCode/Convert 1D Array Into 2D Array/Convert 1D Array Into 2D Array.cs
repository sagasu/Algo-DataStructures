using System.Linq;

namespace AlgoTest.LeetCode.Convert_1D_Array_Into_2D_Array;

public class Convert_1D_Array_Into_2D_Array
{
    public int[][] Construct2DArray(int[] original, int m, int n) => m * n != original.Length ? new int[0][] : original.Chunk(n).Select(c => c.ToArray()).ToArray();

}