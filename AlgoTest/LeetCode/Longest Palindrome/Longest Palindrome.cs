using System.Linq;

namespace AlgoTest.LeetCode.Longest_Palindrome;

public class Longest_Palindrome
{
    public int LongestPalindrome(string s) {
        var result = s.GroupBy(c => c).Sum(g => g.Count() / 2 * 2);
        return result == s.Length ? result : result + 1;
    }
}