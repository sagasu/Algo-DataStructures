using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Original_Typed_String_II;

public class Find_the_Original_Typed_String_II
{
    public int PossibleStringCount(string word, int k)
    {
        const int mod = 1_000_000_007;
        var charCnts = new List<int>();
        int charCnt = 1;
        for (int i = 1; i < word.Length; i++)
        {
            if (word[i] == word[i - 1])
            {
                charCnt++;
            }
            else
            {
                charCnts.Add(charCnt);
                charCnt = 1;
            }
        }

        charCnts.Add(charCnt);
        long allStringsCnt = 1;
        foreach (int cnt in charCnts)
        {
            allStringsCnt = allStringsCnt * cnt % mod;
        }

        int n = charCnts.Count;
        if (n >= k)
        {
            return (int)allStringsCnt;
        }

        var dp = new int[k + 1];

        dp[0] = 1;

        var dpPreSum = Enumerable.Repeat(1, k + 2).ToArray();
        dpPreSum[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            dp = new int[k + 1];
            dp[i] = 1;
            for (int j = i + 1; j <= k; j++)
            {
                int minPrePick = Math.Max(i - 1, j - charCnts[i - 1]);

                dp[j] = dpPreSum[j] - dpPreSum[minPrePick];
                dp[j] = (dp[j] + mod) % mod;
            }

            for (int j = 1; j <= k + 1; j++)
            {
                dpPreSum[j] = dpPreSum[j - 1] + dp[j - 1];
                dpPreSum[j] %= mod;
            }
        }

        return (int)(allStringsCnt - dpPreSum[k] + mod) % mod;
    }
}