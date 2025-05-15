using System.Collections.Generic;

namespace AlgoTest.LeetCode.Longest_Unequal_Adjacent_Groups_Subsequence_I;

public class Longest_Unequal_Adjacent_Groups_Subsequence_I
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        var result = new List<string>();
        var prev = groups[0];
        result.Add(words[0]);
        for (var i = 1; i < words.Length; i++)
        {
            if(prev != groups[i])
            {
                result.Add(words[i]);
                prev = groups[i];
            }
        }
        
        return result;
    }
}