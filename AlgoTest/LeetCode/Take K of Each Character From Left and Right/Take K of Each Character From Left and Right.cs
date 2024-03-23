using System;
using System.Linq;

namespace AlgoTest.LeetCode.Take_K_of_Each_Character_From_Left_and_Right;

public class Take_K_of_Each_Character_From_Left_and_Right
{
    public int TakeCharacters(string s, int k) {
        var letters = new int[3];
        foreach (var l in s)
            letters[l - 'a']++;
        if (letters.Any(x => x < k)) return -1;
        int li = 0, hi = 0, res = int.MaxValue;
        while (hi < s.Length) {
            letters[s[hi] - 'a']--;
            while (li <= hi && letters[s[hi] - 'a'] < k)
                letters[s[li++] - 'a']++;
            res = Math.Min(res, s.Length - (hi - li + 1));                
            hi++;
        }
        return res;
    }
}