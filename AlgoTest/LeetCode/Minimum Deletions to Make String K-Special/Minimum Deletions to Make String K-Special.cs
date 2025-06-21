using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Deletions_to_Make_String_K_Special;

public class Minimum_Deletions_to_Make_String_K_Special
{
    public int MinimumDeletions(string word, int k) {
        // Step 1: Frequency count
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in word) {
            if (!freq.ContainsKey(c))
                freq[c] = 0;
            freq[c]++;
        }

        // Step 2: Get sorted list of frequencies
        List<int> freqList = freq.Values.ToList();
        freqList.Sort();

        int minDeletions = int.MaxValue;
        int n = freqList.Count;

        for (int i = 0; i < n; i++) {
            int baseFreq = freqList[i];
            int deletions = 0;

            // Delete all chars with freq less than baseFreq
            for (int j = 0; j < i; j++) {
                deletions += freqList[j];
            }

            // Delete extra from chars with freq > baseFreq + k
            for (int j = i; j < n; j++) {
                if (freqList[j] > baseFreq + k) {
                    deletions += freqList[j] - (baseFreq + k);
                }
            }

            minDeletions = Math.Min(minDeletions, deletions);
        }

        return minDeletions;
    }
}