using System;

namespace AlgoTest.LeetCode.Magnetic_Force_Between_Two_Balls;

public class Magnetic_Force_Between_Two_Balls
{
    public int MaxDistance(int[] position, int m) {
        Array.Sort(position);
        int low = 0, high = position[^1] - position[0], ans = 0;
        while(low <= high) {
            int mid = low + (high - low) / 2;
            if(IsPossible(position, m - 1, mid)) {
                ans = Math.Max(ans, mid);
                low = mid + 1;
            }
            else
                high = mid - 1;
        }

        return ans;
    }

    private bool IsPossible(int[] position, int m, int mid) {
        int pos = 1, prev = 0;
        while(pos < position.Length && m > 0) {
            if(position[pos] - position[prev] >= mid) {
                prev = pos;
                m--;
            }

            pos++;
        }

        return m == 0;
    }
}