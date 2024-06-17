using System;

namespace AlgoTest.LeetCode.Sum_of_Square_Numbers;

public class Sum_of_Square_Numbers_New
{
    public bool JudgeSquareSum(int c) {
        for (long a = 0; a * a <= c; a++) {
            var b = Math.Sqrt(c - a * a);
            if (b == (int)b)
                return true;
        }
        
        return false;
    }
}