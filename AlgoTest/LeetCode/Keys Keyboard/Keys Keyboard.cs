using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Keys_Keyboard;

//2 Keys Keyboard
public class Keys_Keyboard
{
    private readonly List<int> dp = new List<int>{0,0};

    public int MinSteps(int n) {
        for (var num = dp.Count; num <= n; num++) {
            dp.Add(num);
            for (var x = 2; x < num / 2; x++) {
                if (num % x != 0) continue;
                dp[num] = Math.Min(dp[num], dp[num / x] + x);
                break;
            }
        }
        return dp[n];
    }
}