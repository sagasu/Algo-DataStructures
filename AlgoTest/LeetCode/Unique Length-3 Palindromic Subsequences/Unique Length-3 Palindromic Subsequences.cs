using System.Collections.Generic;

namespace AlgoTest.LeetCode.Unique_Length_3_Palindromic_Subsequences;

public class Unique_Length_3_Palindromic_Subsequences
{
    public int CountPalindromicSubsequence(string s) {
        var count = 0;
        for(int i = 0; i < 26; i++)
        {
            var currentChar = (char)(i + 97);
            var leftIndex = s.IndexOf(currentChar);
            var rightIndex = s.LastIndexOf(currentChar);

            if(leftIndex >= 0 && rightIndex >= 0 && leftIndex < rightIndex)
                count += new HashSet<char>(s.Substring(leftIndex + 1, rightIndex - leftIndex - 1)).Count;
        }
        return count;
    }
}