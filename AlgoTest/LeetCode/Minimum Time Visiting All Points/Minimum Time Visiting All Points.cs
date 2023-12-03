using System;

namespace AlgoTest.LeetCode.Minimum_Time_Visiting_All_Points;

public class Minimum_Time_Visiting_All_Points
{
    public int MinTimeToVisitAllPoints(int[][] points) {
        var result = 0;
        for (var i = 1; i < points.Length; i++)
        {
            result += Math.Max(
                Math.Abs(points[i - 1][0] - points[i][0]), 
                Math.Abs(points[i - 1][1] - points[i][1]));
        }

        return result;
    }
}