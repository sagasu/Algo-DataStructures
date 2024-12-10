using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_Longest_Special_Substring_That_Occurs_Thrice_I;

public class Find_Longest_Special_Substring_That_Occurs_Thrice_I
{
    public int MaximumLength(string s) {
        var counts = new Dictionary<string, int>();

        var longest = 0;

        var prevChar = '0';
        var currentConsecutive = 0;

        foreach (var t in s)
        {
            if(t == prevChar) currentConsecutive++;
            else currentConsecutive = 1;
            prevChar = t;

            for(int j = Math.Max(currentConsecutive - 2, 1); j <= currentConsecutive; j++) 
            {
                if(!counts.ContainsKey(t+j.ToString())) counts[t+j.ToString()]  = 0;

                counts[t+j.ToString()] += 1;
                if(counts[t+j.ToString()] >= 3) longest = Math.Max(longest, j);
            }
        }

        return longest == 0? -1 : longest;
    }
}