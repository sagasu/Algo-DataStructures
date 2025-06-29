using System.Collections.Generic;

namespace AlgoTest.LeetCode.Longest_Subsequence_Repeated_k_Times;

public class Longest_Subsequence_Repeated_k_Times
{
    public string LongestSubsequenceRepeatedK(string s, int k) {
        bool IsValid(string sub) {
            string target = "";
            for (int i = 0; i < k; i++) target += sub;
            int j = 0;
            foreach (char c in s) {
                if (c == target[j]) j++;
                if (j == target.Length) return true;
            }
            return false;
        }

        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in s) {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]++;
        }

        List<char> candidates = new List<char>();
        foreach (var pair in freq) {
            if (pair.Value >= k)
                candidates.Add(pair.Key);
        }

        candidates.Sort((a, b) => b.CompareTo(a));

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("");
        string result = "";

        while (queue.Count > 0) {
            string curr = queue.Dequeue();
            foreach (char c in candidates) {
                string next = curr + c;
                if (IsValid(next)) {
                    queue.Enqueue(next);
                    if (next.Length > result.Length || 
                        (next.Length == result.Length && string.Compare(next, result) > 0)) {
                        result = next;
                    }
                }
            }
        }

        return result;
    }
}