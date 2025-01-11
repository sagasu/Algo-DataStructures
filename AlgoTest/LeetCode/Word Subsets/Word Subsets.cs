using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Word_Subsets;

public class Word_Subsets
{
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        var wordsMaps = new List<int[]>();
        foreach (var word in words1) {
            wordsMaps.Add(GetWordMap(word));
        }

        var summaryMap = new int[26];
        foreach (var word in words2) {
            var wordMap = GetWordMap(word);
            for (int i = 0; i < 26; i++) {
                summaryMap[i] = Math.Max(wordMap[i], summaryMap[i]);
            }
        }

        var result = new List<string>();
        for (int j = 0; j < wordsMaps.Count; j++) {
            bool accepted = true;
            var wordMap = wordsMaps[j];
            for (int i = 0; i < 26; i++) {
                if (summaryMap[i] > wordMap[i]) {
                    accepted = false;
                    break;
                }
            }

            if (accepted) {
                result.Add(words1[j]);
            }
        }

        return result;
    }

    private int[] GetWordMap(string word) {
        var wordMap = new int[26];
        foreach (var symbol in word) {
            wordMap[symbol - 'a']++;
        }

        return wordMap;
    }
}