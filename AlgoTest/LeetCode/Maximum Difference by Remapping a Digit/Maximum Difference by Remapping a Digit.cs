using System;

namespace AlgoTest.LeetCode.Maximum_Difference_by_Remapping_a_Digit;

public class Maximum_Difference_by_Remapping_a_Digit
{
    public int MinMaxDifference(int num) {
        string s = num.ToString();

        int maxVal = int.MinValue;
        int minVal = int.MaxValue;

        for (char digit = '0'; digit <= '9'; digit++) {
            if (!s.Contains(digit)) continue;

            string maxCandidate = s.Replace(digit, '9');
            int maxNum = int.Parse(maxCandidate);
            maxVal = Math.Max(maxVal, maxNum);

            string minCandidate = s.Replace(digit, '0');
            int minNum = int.Parse(minCandidate);
            minVal = Math.Min(minVal, minNum);
        }

        return maxVal - minVal;
    }
}