using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Count_Vowel_Strings_in_Ranges;

public class Count_Vowel_Strings_in_Ranges
{
    public int[] VowelStrings(string[] words, int[][] queries) {
        var vowels = new HashSet<char>() {'e','u','i','o','a'};

        var prefix = new int[words.Length + 1];        
        for (int i = 1; i <= words.Length; i++) {
            var startWithVowel = vowels.Contains(words[i - 1][0]);
            var endWithVowel = vowels.Contains(words[i - 1][words[i - 1].Length - 1]);
            prefix[i] = prefix[i - 1] + (startWithVowel && endWithVowel ? 1 : 0);
        }
        
        return queries.Select(x => prefix[x[1] + 1] - prefix[x[0]]).ToArray();
    }
}