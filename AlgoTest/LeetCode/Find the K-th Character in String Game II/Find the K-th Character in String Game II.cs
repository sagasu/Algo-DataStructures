using System;

namespace AlgoTest.LeetCode.Find_the_K_th_Character_in_String_Game_II;

public class Find_the_K_th_Character_in_String_Game_II
{
    public char KthCharacter(long k, int[] operations) {
        int ans = 0;
        int t;
        while (k != 1)
        {
            t = (int)Math.Log(k, 2);
            if ((1L << t) == k)
            {
                t--;
            }
            k -= (1L << t);
            if (operations[t] != 0)
            {
                ans++;
            }
        }
        return (char)('a' + (ans % 26));
    }
}