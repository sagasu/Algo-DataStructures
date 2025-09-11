using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Sort_Vowels_in_a_String;

public class Sort_Vowels_in_a_String
{
    public string SortVowels(string s) {
        var vowels = new HashSet<char>("aeiouAEIOU");

        var collected = new List<char>();
        foreach (char c in s) {
            if (vowels.Contains(c)) {
                collected.Add(c);
            }
        }

        collected.Sort();

        var result = new StringBuilder();
        var j = 0; 
        foreach (char c in s) {
            if (vowels.Contains(c)) {
                result.Append(collected[j]);
                j++;
            } else {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}