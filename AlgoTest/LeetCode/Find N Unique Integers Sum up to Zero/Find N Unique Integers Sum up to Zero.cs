using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_N_Unique_Integers_Sum_up_to_Zero;

public class Find_N_Unique_Integers_Sum_up_to_Zero
{
    public int[] SumZero(int n) {
        List<int> l = new List<int>();
        int pair = n / 2 + 1;

        for (int i = 1; i < pair; i++) {
            l.Add(i);
            l.Add(-i);
        }

        if (n % 2 != 0) {
            l.Add(0);
        }

        return l.ToArray();
    }
}