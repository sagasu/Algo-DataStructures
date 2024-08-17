using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Number_of_Points_with_Cost;

public class Maximum_Number_of_Points_with_Cost
{
    public long MaxPoints(int[][] points)
    {
        var discussed = points[0].Select(f => (long)f).ToArray();
        var discussing = new long[points[0].Length];

        for (int i = 1; i < points.Length; i++)
        {
            var actual = points[i];

            var currentVal = 0L;
            for (int j = 0; j < discussing.Length; j++)
            {
                currentVal = Math.Max(currentVal, discussed[j]);
                discussing[j] = Math.Max(discussing[j], currentVal-- + actual[j]);
            }

            currentVal = 0L;
            for (int j = discussing.Length - 1; j >= 0; j--)
            {
                currentVal = Math.Max(currentVal, discussed[j]);
                discussing[j] = Math.Max(discussing[j], currentVal-- + actual[j]);
            }

            (discussed, discussing) = (discussing, discussed);
            for (int j = 0; j < discussing.Length; j++)
                discussing[j] = 0;
        }

        return discussed.Max();
    }
}