using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Apply_Operations_to_Maximize_Score;

public class Apply_Operations_to_Maximize_Score
{
    public int MaximumScore(IList<int> nums, int k) {
        var n = nums.Count;
        var numArr = new int[n];
        var maxNum = int.MinValue;
        for (var i = 0; i < n; i++)
        {
            numArr[i] = nums[i];
            maxNum = int.Max(maxNum, nums[i]);
        }
        
        nums.CopyTo(numArr, 0);
        var primeScores = PrimeScoresSieve(maxNum);

        var left = new int[n];
        var right = new int[n];
        var stack = new Stack<int>();

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && primeScores[numArr[stack.Peek()]] < primeScores[numArr[i]])
            {
                stack.Pop();
            }

            left[i] = stack.Count == 0 ? i + 1 : i - stack.Peek();
            stack.Push(i);
        }

        stack.Clear();
        for (var i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && primeScores[numArr[stack.Peek()]] <= primeScores[numArr[i]])
            {
                stack.Pop();
            }

            right[i] = stack.Count == 0 ? n - i : stack.Peek() - i;
            stack.Push(i);
        }

        var freq = new long[n];
        for (var i = 0; i < n; i++)
        {
            freq[i] = (long)left[i] * right[i];
        }

        Array.Sort(numArr, freq, Comparer<int>.Create((a, b) => b.CompareTo(a)));
        var currentIndex = 0;
        var maximumScore = 1;
        while (k > 0)
        {
            maximumScore = (int)((long)maximumScore * ModPow(numArr[currentIndex], long.Min(freq[currentIndex], k), 1000000007) %
                           1000000007);
            k -= (int)long.Min(freq[currentIndex], k);
            currentIndex++;
        }

        return maximumScore;

        int[] PrimeScoresSieve(int num)
        {
            var primeScores = new int[num + 1];

            for (var i = 2; i <= num; i++)
            {
                if (primeScores[i] != 0) continue;
                for (var j = i; j <= num; j += i)
                {
                    primeScores[j]++;
                }
            }

            return primeScores;
        }

        int ModPow(long value, long exponent, int modulus)
        {
            var result = 1L;
            value %= modulus;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = result * value % modulus;
                value = value * value % modulus;
                exponent >>= 1;
            }

            return (int)result;
        }
    }
}