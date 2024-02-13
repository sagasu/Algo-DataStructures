using System.Linq;

namespace AlgoTest.LeetCode.Find_First_Palindromic_String_in_the_Array;

public class Find_First_Palindromic_String_in_the_Array
{
    public string FirstPalindrome(string[] words) {
        foreach (var word in words)
        {
            var reversed = word.Reverse();
            if (reversed.SequenceEqual(word)) 
                return word;
        }

        return "";
    }
}