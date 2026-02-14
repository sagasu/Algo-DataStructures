using System;

namespace AlgoTest.LeetCode.Longest_Balanced_Substring_II;

public class Longest_Balanced_Substring_II
{
    public int LongestBalanced(string s) {
        int n = s.Length;
        int ans = 0;
        
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                int[] freq = new int[3]; // a, b, c
                
                for (int k = i; k <= j; k++) {
                    if (s[k] == 'a') freq[0]++;
                    else if (s[k] == 'b') freq[1]++;
                    else if (s[k] == 'c') freq[2]++;
                }
                
                var counts = new System.Collections.Generic.List<int>();
                foreach (int count in freq) {
                    if (count > 0) counts.Add(count);
                }
                
                if (counts.Count > 0) {
                    bool allSame = true;
                    int first = counts[0];
                    foreach (int count in counts) {
                        if (count != first) {
                            allSame = false;
                            break;
                        }
                    }
                    if (allSame) {
                        ans = Math.Max(ans, j - i + 1);
                    }
                }
            }
        }
        return ans;
    }
}