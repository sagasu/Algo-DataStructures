using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Number_of_Equivalent_Domino_Pairs;

public class Number_of_Equivalent_Domino_Pairs
{
    public int NumEquivDominoPairs(int[][] dominoes) {
        var ans = 0;
        var count = new Dictionary<int, int>();

        foreach (var domino in dominoes) {
            int key = Math.Min(domino[0], domino[1]) * 10 + Math.Max(domino[0], domino[1]);

            if (count.ContainsKey(key)) {
                ans += count[key];
                count[key]++;
            } else {
                count[key] = 1;
            }
        }

        return ans;
    }
}