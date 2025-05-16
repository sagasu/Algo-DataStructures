using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Longest_Unequal_Adjacent_Groups_Subsequence_II;

public class Longest_Unequal_Adjacent_Groups_Subsequence_II
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups) {
        int n = words.Length;
        int[] dp = new int[n];       // dp[i] = length of longest valid subsequence ending at i
        int[] prev = new int[n];     // prev[i] = index of previous word in the sequence
        Array.Fill(dp, 1);
        Array.Fill(prev, -1);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (groups[i] != groups[j] &&
                    words[i].Length == words[j].Length &&
                    HammingDistance(words[i], words[j]) == 1) {
                    if (dp[j] + 1 > dp[i]) {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }
            }
        }

        // Find the index with the maximum dp value
        int maxLength = 0;
        int endIndex = 0;
        for (int i = 0; i < n; i++) {
            if (dp[i] > maxLength) {
                maxLength = dp[i];
                endIndex = i;
            }
        }

        // Reconstruct the sequence
        List<string> result = new List<string>();
        while (endIndex != -1) {
            result.Add(words[endIndex]);
            endIndex = prev[endIndex];
        }

        result.Reverse();
        return result;
    }

    private int HammingDistance(string a, string b) {
        int count = 0;
        for (int i = 0; i < a.Length; i++) {
            if (a[i] != b[i]) count++;
        }
        return count;
    }
}