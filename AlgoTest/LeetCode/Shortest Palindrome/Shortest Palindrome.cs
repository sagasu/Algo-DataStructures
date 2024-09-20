using System.Linq;

namespace AlgoTest.LeetCode.Shortest_Palindrome;

public class Shortest_Palindrome
{
    public string ShortestPalindrome(string s) {
        int left = 0;
        for (int right = s.Length - 1; right >= 0; right--)
            if (s[right] == s[left])
                left++;

        if (left == s.Length) return s;

        var remainingString = s.Substring(left);
        var reversedString = string.Join("", remainingString.Reverse());

        var result = reversedString + ShortestPalindrome(s.Substring(0, left))+ remainingString;
        return result;
    }
}