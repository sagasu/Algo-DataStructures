using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Vowel_Spellchecker;

public class Vowel_Spellchecker
{
    private static bool IsVowel(char c) {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    private static string MaskVowels(string s) {
        char[] arr = new char[s.Length];
        for (int i = 0; i < s.Length; i++) {
            char ch = s[i];
            arr[i] = IsVowel(ch) ? 'a' : ch;
        }
        return new string(arr);
    }

    public string[] Spellchecker(string[] wordlist, string[] queries) {
        var exact = new HashSet<string>(wordlist);

        var lowerMap = new Dictionary<string, string>(StringComparer.Ordinal);
        var vowelMap = new Dictionary<string, string>(StringComparer.Ordinal);

        foreach (var w in wordlist) {
            string wl = w.ToLowerInvariant();
            if (!lowerMap.ContainsKey(wl)) {
                lowerMap[wl] = w;
            }
            string masked = MaskVowels(wl);
            if (!vowelMap.ContainsKey(masked)) {
                vowelMap[masked] = w; 
            }
        }

        var ans = new string[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            string q = queries[i];

            if (exact.Contains(q)) {
                ans[i] = q;
                continue;
            }

            string ql = q.ToLowerInvariant();

            if (lowerMap.TryGetValue(ql, out var foundLower)) {
                ans[i] = foundLower;
                continue;
            }

            string qMasked = MaskVowels(ql);
            if (vowelMap.TryGetValue(qMasked, out var foundVowel)) {
                ans[i] = foundVowel;
                continue;
            }

            ans[i] = "";
        }

        return ans;
    }
}