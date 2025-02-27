using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Length_of_Longest_Fibonacci_Subsequence;

public class Length_of_Longest_Fibonacci_Subsequence
{
    public int LenLongestFibSubseq(int[] arr)
    {
        var n = arr.Length;
        
        var indexMap = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            indexMap[arr[i]] = i;
        }

        int maxLength = 0;
        int[,] dp = new int[n, n];

        for (int j = 0; j < n; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                int expected = arr[j] + arr[k];
                if (indexMap.ContainsKey(expected))
                {
                    int i = indexMap[expected];
                    if (i > k)
                    {
                        dp[k, i] = dp[j, k] + 1;
                        maxLength = Math.Max(maxLength, dp[k, i] + 2); 
                    }
                }
            }
        }

        return maxLength >= 3 ? maxLength : 0; 
    }
}