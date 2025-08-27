using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Area_of_Longest_Diagonal_Rectangle;

public class Maximum_Area_of_Longest_Diagonal_Rectangle
{
    public int AreaOfMaxDiagonal(int[][] dimensions) => dimensions.Max(d => (Diagonal: d[0] * d[0] + d[1] * d[1], Area: d[0] * d[1])).Area;
}