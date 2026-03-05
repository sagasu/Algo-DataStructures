using System;

namespace AlgoTest.LeetCode.Remove_Adjacent_Almost_Equal_Characters;

public class Remove_Adjacent_Almost_Equal_Characters
{
    public int RemoveAlmostEqualCharacters(string word) {
        var ans = 0;
        for(int i = 1; i < word.Length; i++)
        {
            if(Math.Abs(word[i] - word[i - 1]) <= 1)
            {
                ans++;
                i++;
            }
        }
        
        return ans;
    }
}