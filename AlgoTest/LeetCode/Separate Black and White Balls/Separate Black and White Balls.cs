using System.Linq;

namespace AlgoTest.LeetCode.Separate_Black_and_White_Balls;

public class Separate_Black_and_White_Balls
{
    public long MinimumSteps(string s) => s.Aggregate(
        (BlackBalls: 0, Steps: 0L),
        (t, c) => c == '0'
            ? (t.BlackBalls, t.Steps + t.BlackBalls)
            : (t.BlackBalls + 1, t.Steps),
        t => t.Steps);
}