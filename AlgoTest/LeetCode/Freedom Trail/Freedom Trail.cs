using System;

namespace AlgoTest.LeetCode.Freedom_Trail;

public class Freedom_Trail
{
    private int MinDistance(int a, int b, int size)
    {
        var min = Math.Min(a, b);
        var max = Math.Max(a, b);
        return Math.Min(max - min, min + size - max);
    }
    private int Solve(string ring, string key, int index, int letter, int[][] memo)
    {
        if (letter >= key.Length)
            return 0;
        if (memo[index][letter] >= 0)
            return memo[index][letter];
        var min = int.MaxValue;
        for (var i = 0; i < ring.Length; i += 1)
        {
            if (ring[i] != key[letter])
                continue;
            var distance = MinDistance(index, i, ring.Length) + 1;
            min = Math.Min(min, Solve(ring, key, i, letter + 1, memo) + distance);
        }
        memo[index][letter] = min;
        return min;
    }
    public int FindRotateSteps(string ring, string key) {
        var memo = new int[ring.Length][];
        for (var i = 0; i < memo.Length; i += 1)
        {
            memo[i] = new int[key.Length];
            Array.Fill(memo[i], -1);
        }
        return Solve(ring, key, 0, 0, memo);
    }
}