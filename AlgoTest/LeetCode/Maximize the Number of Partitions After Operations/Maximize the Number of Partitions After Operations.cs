using System;
using System.Collections.Generic;
using System.Numerics;

namespace AlgoTest.LeetCode.Maximize_the_Number_of_Partitions_After_Operations;

public class Maximize_the_Number_of_Partitions_After_Operations
{
    private Dictionary<long, int> memo = new Dictionary<long, int>();

    private int Dfs(int index, string s, int charMask, bool canChange, int k) {
        if (index == s.Length) return 0;

        long key = ((long)index << 27) | ((long)charMask << 1) | (canChange ? 1L : 0L);
        if (memo.ContainsKey(key)) return memo[key];

        int currentBit = 1 << (s[index] - 'a');
        int updatedMask = charMask | currentBit;
        int maxPartitions;

        if (BitOperations.PopCount((uint)updatedMask) > k)
            maxPartitions = 1 + Dfs(index + 1, s, currentBit, canChange, k);
        else
            maxPartitions = Dfs(index + 1, s, updatedMask, canChange, k);

        if (canChange) {
            for (int c = 0; c < 26; c++) {
                int newBit = 1 << c;
                int newMask = charMask | newBit;
                int partitions;
                if (BitOperations.PopCount((uint)newMask) > k)
                    partitions = 1 + Dfs(index + 1, s, newBit, false, k);
                else
                    partitions = Dfs(index + 1, s, newMask, false, k);
                maxPartitions = Math.Max(maxPartitions, partitions);
            }
        }

        memo[key] = maxPartitions;
        return maxPartitions;
    }

    public int MaxPartitionsAfterOperations(string s, int k) {
        return 1 + Dfs(0, s, 0, true, k);
    }
}