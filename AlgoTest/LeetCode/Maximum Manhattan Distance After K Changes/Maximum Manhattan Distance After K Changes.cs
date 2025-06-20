using System;

namespace AlgoTest.LeetCode.Maximum_Manhattan_Distance_After_K_Changes;

public class Maximum_Manhattan_Distance_After_K_Changes
{
    public int MaxDistance(string s, int k)
    {
        int ans = 0;
        int north = 0, south = 0, east = 0, west = 0;
        foreach (char it in s)
        {
            switch (it)
            {
                case 'N':
                    north++;
                    break;
                case 'S':
                    south++;
                    break;
                case 'E':
                    east++;
                    break;
                case 'W':
                    west++;
                    break;
            }
            int times1 = Math.Min(Math.Min(north, south),
                k);  // modification times for N and S
            int times2 =
                Math.Min(Math.Min(east, west),
                    k - times1);  // modification times for E and W
            ans = Math.Max(
                ans, Count(north, south, times1) + Count(east, west, times2));
        }
        return ans;
    }

    private int Count(int drt1, int drt2, int times)
    {
        return Math.Abs(drt1 - drt2) +
               times * 2;  // Calculate modified Manhattan distance
    }
}