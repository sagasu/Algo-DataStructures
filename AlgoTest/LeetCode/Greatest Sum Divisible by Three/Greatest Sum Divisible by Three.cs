using System;

namespace AlgoTest.LeetCode.Greatest_Sum_Divisible_by_Three;

public class Greatest_Sum_Divisible_by_Three
{
    public int MaxSumDivThree(int[] nums) {
        int sum = 0;

        int m1a = int.MaxValue, m1b = int.MaxValue;
        int m2a = int.MaxValue, m2b = int.MaxValue;

        foreach (int x in nums) {
            sum += x;
            int r = x % 3;

            if (r == 1) {
                if (x < m1a) { m1b = m1a; m1a = x; }
                else if (x < m1b) m1b = x;
            }
            else if (r == 2) {
                if (x < m2a) { m2b = m2a; m2a = x; }
                else if (x < m2b) m2b = x;
            }
        }

        int rem = sum % 3;
        if (rem == 0) return sum;

        int remove = int.MaxValue;

        if (rem == 1) {
            int option1 = m1a;
            int option2 = (m2b < int.MaxValue) ? m2a + m2b : int.MaxValue;
            remove = Math.Min(option1, option2);
        } else {
            int option1 = m2a;
            int option2 = (m1b < int.MaxValue) ? m1a + m1b : int.MaxValue;
            remove = Math.Min(option1, option2);
        }

        if (remove == int.MaxValue) return 0;
        return sum - remove;
    }
}