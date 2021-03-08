using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Remove_Palindromic_Subsequences
{
    public class Remove_Palindromic_Subsequences
    {
        // Trick is to notice that there are only 'a' and 'b' values in string, so if we remove first 'a' substring (subsequence) and then 'b' then there is nothing left. So the worst case scenario is 2. And 0 is when a string is empty.
        // So the question is when do we have 1. We have 1 only when s is a palindrome itself. So we just solve that problem here.
        public int RemovePalindromeSub(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            // costly way of implementing check if s is palindrome but hay, let's have some one-liner fun :)
            if (s.SequenceEqual(s.Reverse())) return 1;

            return 2;
        }
    }
}
