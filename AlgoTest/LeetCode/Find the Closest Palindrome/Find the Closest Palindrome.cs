using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Closest_Palindrome;

public class Find_the_Closest_Palindrome
{
    public string NearestPalindromic(string n)
    {
        long number = long.Parse(n), closestPalindrome = -1;

        foreach (var candidate in 
                 GetPalindromeCandidates(n).Where(candidate =>
                     Math.Abs(candidate - number) < Math.Abs(closestPalindrome - number) ||
                     (Math.Abs(candidate - number) == Math.Abs(closestPalindrome - number) && candidate < closestPalindrome)))
            closestPalindrome = candidate;

        return closestPalindrome.ToString();
    }

    private HashSet<long> GetPalindromeCandidates(string n)
    {
        var length = n.Length;
        var candidates = new HashSet<long>
        {
            (long)Math.Pow(10, length - 1) - 1,
            (long)Math.Pow(10, length) + 1
        };

        var firstHalf = long.Parse(n[..((length + 1) / 2)]);
        for (var i = firstHalf - 1; i <= firstHalf + 1; ++i)
            candidates.Add(long.Parse(i + new string(i.ToString().Reverse().ToArray()).Substring(length % 2)));

        candidates.Remove(long.Parse(n));

        return candidates;
    }
}