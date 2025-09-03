using System;

namespace AlgoTest.LeetCode.Find_the_Number_of_Ways_to_Place_People_II;

public class Find_the_Number_of_Ways_to_Place_People_II
{
    public int NumberOfPairs(int[][] points) {
        Array.Sort(points, (a, b) => {
            if (a[0] == b[0]) return b[1].CompareTo(a[1]);
            return a[0].CompareTo(b[0]);
        });

        int n = points.Length;
        int result = 0;

        for (int i = 0; i < n; i++) {
            int top = points[i][1];
            int bot = int.MinValue;

            for (int j = i + 1; j < n; j++) {
                int y = points[j][1];
                if (bot < y && y <= top) {
                    result++;
                    bot = y;
                    if (top == bot) break;
                }
            }
        }

        return result;
    }
}