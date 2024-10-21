using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Split_a_String_Into_the_Max_Number_of_Unique_Substrings;

public class Split_a_String_Into_the_Max_Number_of_Unique_Substrings
{
    public int MaxUniqueSplit(string s) => MaxUniqueSplit(s, 0, new HashSet<string>());

    private int MaxUniqueSplit(string s, int startChar, HashSet<string> seenStrings) {
        if (startChar >= s.Length) return 0;
        var maxSplit = -1;

        for(var endChar = startChar; endChar < s.Length; endChar++) 
        {
            var subString = s.Substring(startChar, endChar - startChar + 1);
            if (seenStrings.Contains(subString)) 
                continue;

            seenStrings.Add(subString);
            var remainingSplit = MaxUniqueSplit(s, endChar + 1, seenStrings);
            if (remainingSplit != -1) 
                maxSplit = Math.Max(maxSplit, 1 + remainingSplit);

            seenStrings.Remove(subString);
        }

        return maxSplit;
    }
}