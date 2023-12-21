using System.Linq;

namespace AlgoTest.LeetCode.Widest_Vertical_Area_Between_Two_Points_Containing_No_Points;

public class Widest_Vertical_Area_Between_Two_Points_Containing_No_Points
{
    public int MaxWidthOfVerticalArea(int[][] points) {
        var ordered = points
            .Select(p => p[0])
            .OrderBy(p => p);
        return ordered
            .SkipLast(1)
            .Zip(ordered.Skip(1), (a, b) => b - a)
            .Max();
    }
}