using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Smallest_K_Length_Subsequence_With_Occurrences_of_a_Letter;

public class Smallest_K_Length_Subsequence_With_Occurrences_of_a_Letter
{
    public string SmallestSubsequence(string s, int k, char letter, int repetition) 
    {
        var wantedRemained = s.Count(letter.Equals);
        Stack<char> stack = new();
        var numberOfWanted = 0;
        for (var i = 0; i < s.Length; ++i) 
        {
            while (stack.Any() && stack.Peek() > s[i] && 
                   numberOfWanted + wantedRemained - NumberOfWanted(stack.Peek()) >= repetition &&
                   stack.Count() + s.Length - i > k) 
                numberOfWanted -= NumberOfWanted(stack.Pop());
            
            if (s[i] == letter) --wantedRemained;
            
            if (stack.Count >= k || (s[i] != letter && repetition - numberOfWanted >= k - stack.Count())) continue;
			
            stack.Push(s[i]);
            if (s[i] == letter) ++numberOfWanted;
        }
        return string.Concat(stack.Reverse());
        
        int NumberOfWanted(char c) => c == letter ? 1 : 0;
    }
}