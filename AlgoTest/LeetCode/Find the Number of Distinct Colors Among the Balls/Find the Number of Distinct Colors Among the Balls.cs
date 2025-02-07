using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_the_Number_of_Distinct_Colors_Among_the_Balls;

public class Find_the_Number_of_Distinct_Colors_Among_the_Balls
{
    public int[] QueryResults(int limit, int[][] queries) {
        var colorByBall = new Dictionary<int, int>();
        var freq = new Dictionary<int, int>();
        var ans = new int[queries.Length];
        var p = 0;
        foreach (var q in queries) {
            var ball = q[0];
            var color = q[1];
            if (!colorByBall.TryAdd(ball, color)) {
                if (--freq[colorByBall[ball]] == 0) {
                    freq.Remove(colorByBall[ball]);
                }
            }
            colorByBall[ball] = color;
            freq.TryAdd(color, 0);
            freq[color]++;
            ans[p++] = freq.Count;
        }
        return ans;
    }
}