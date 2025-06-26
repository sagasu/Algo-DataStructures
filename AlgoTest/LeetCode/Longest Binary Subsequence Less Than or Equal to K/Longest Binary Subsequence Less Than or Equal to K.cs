namespace AlgoTest.LeetCode.Longest_Binary_Subsequence_Less_Than_or_Equal_to_K;

public class Longest_Binary_Subsequence_Less_Than_or_Equal_to_K
{
    public int LongestSubsequence(string s, int k) {
        int count = 0;
        int zeros = 0;
        long value = 0;
        int power = 0;

        foreach (char ch in s)
            if (ch == '0') zeros++;

        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '1') {
                if (power < 32 && value + (1L << power) <= k) {
                    value += (1L << power);
                    count++;
                    power++;
                } else {
                    power++;
                }
            } else {
                power++;
            }
        }

        return count + zeros;
    }
}