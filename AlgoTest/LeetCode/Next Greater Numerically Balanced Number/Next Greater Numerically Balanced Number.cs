using System;

namespace AlgoTest.LeetCode.Next_Greater_Numerically_Balanced_Number;

public class Next_Greater_Numerically_Balanced_Number
{
    public long Generate(long n, long current, long remaining, long[] count) {
        if (remaining == 0) {
            if (current > n) {
                for (int d = 1; d <= 9; d++) {
                    if (count[d] > 0 && count[d] != d) return 0;
                }
                return current;
            }
            return 0;
        }

        long result = 0;
        for (int d = 1; d <= 9 && result == 0; d++) {
            if (count[d] < d && d - count[d] <= remaining) {
                count[d]++;
                result = Generate(n, current * 10 + d, remaining - 1, count);
                count[d]--;
            }
        }
        return result;
    }

    public int NextBeautifulNumber(int n) {
        string num = n.ToString();
        long length = num.Length;
        long[] count = new long[10];

        long result = Generate(n, 0, length, count);
        Array.Fill(count, 0);
        long nextLenResult = Generate(0, 0, length + 1, count);
        if (result == 0) result = nextLenResult;
        return (int)result;
    }
}