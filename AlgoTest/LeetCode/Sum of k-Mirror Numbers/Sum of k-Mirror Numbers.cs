using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Sum_of_k_Mirror_Numbers;

public class Sum_of_k_Mirror_Numbers
{
    public long KMirror(int k, int n) {
        long total = 0;
        int count = 0;
        int length = 1;

        while (count < n) {
            foreach (long num in GeneratePalindromes(length)) {
                if (IsKPalindrome(num, k)) {
                    total += num;
                    count++;
                    if (count == n) return total;
                }
            }
            length++;
        }

        return total;
    }

    private IEnumerable<long> GeneratePalindromes(int length) {
        int half = (length + 1) / 2;
        long start = (long)Math.Pow(10, half - 1);
        long end = (long)Math.Pow(10, half);

        for (long i = start; i < end; i++) {
            string firstHalf = i.ToString();
            string secondHalf = firstHalf.Substring(0, length % 2 == 0 ? firstHalf.Length : firstHalf.Length - 1);
            char[] reversed = secondHalf.ToCharArray();
            Array.Reverse(reversed);
            string full = firstHalf + new string(reversed);
            yield return long.Parse(full);
        }
    }

    private bool IsKPalindrome(long num, int baseK) {
        List<int> digits = new List<int>();
        while (num > 0) {
            digits.Add((int)(num % baseK));
            num /= baseK;
        }

        int i = 0, j = digits.Count - 1;
        while (i < j) {
            if (digits[i++] != digits[j--]) return false;
        }

        return true;
    }
}