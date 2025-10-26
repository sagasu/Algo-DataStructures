using System;

namespace AlgoTest.LeetCode.Find_the_Minimum_Amount_of_Time_to_Brew_Potions;

public class Find_the_Minimum_Amount_of_Time_to_Brew_Potions
{
    public long MinTime(int[] skill, int[] mana) {
        int n = skill.Length;
        int m = mana.Length;
        long[] done = new long[n + 1];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++)
                done[j + 1] = Math.Max(done[j + 1], done[j]) + (long)mana[i] * skill[j];

            for (int k = n - 1; k > 0; k--)
                done[k] = done[k + 1] - (long)mana[i] * skill[k];
        }

        return done[n];
    }
}