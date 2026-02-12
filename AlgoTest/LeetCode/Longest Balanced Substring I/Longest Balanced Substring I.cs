using System;

namespace AlgoTest.LeetCode.Longest_Balanced_Substring_I;

public class Longest_Balanced_Substring_I
{
    public int LongestBalanced(string s) {
        int n = s.Length;
        int maxLen = 0;

        for (int i = 0; i < n; i++) {
            int[] freq = new int[26];
            for (int j = i; j < n; j++) {
                freq[s[j] - 'a']++;

                int minFreq = int.MaxValue;
                int maxFreq = 0;
                int distinct = 0;

                for (int k = 0; k < 26; k++){
                    if (freq[k] > 0) {
                        distinct++;
                        minFreq = Math.Min(minFreq, freq[k]);
                        maxFreq = Math.Max(maxFreq, freq[k]);
                    }
                }

                if (distinct > 0 && minFreq == maxFreq) {
                    maxLen = Math.Max(maxLen, j - i + 1);
                }
            }
        }

        return maxLen;
    }
}