using System;

namespace AlgoTest.LeetCode.Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram;

public class Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram
{
    public int MinSteps(string s, string t) {
        var count = new int[26];
        
        for (var i = 0; i < s.Length; i++) {
            count[t[i] - 'a']++;
            count[s[i] - 'a']--;
        }

        var ans = 0;
        for (var i = 0; i < 26; i++)
            ans += Math.Max(0, count[i]);
        
        return ans;
    }
}