using System;

namespace AlgoTest.LeetCode.Total_Characters_in_String_After_Transformations_I;

public class Total_Characters_in_String_After_Transformations_I
{
    public int LengthAfterTransformations(string s, int t) {
        const int mod = 1_000_000_007;
        Span<int> map = stackalloc int[26];
        
        foreach (var ch in s.AsSpan())
            map[ch - 'a']++;

        for (var i = 0; i < t; i++)
        {
            var z = map[25];
            for (int j = 25; j > 0; j--) 
                map[j] = map[j - 1];

            map[1] = (map[0] + z) % mod;
            map[0] = z;
        }

        var count = 0;
        foreach (var charCount in map)
            count = (count + charCount) % mod;

        return count;
    }
}