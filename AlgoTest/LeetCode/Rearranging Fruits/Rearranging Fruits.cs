using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Rearranging_Fruits;

public class Rearranging_Fruits
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        var numFreq = new Dictionary<int, int>();
        var result = 0L;
        var min = int.MaxValue;

        for (var i = 0; i < basket1.Length; i++)
        {
            if (!numFreq.ContainsKey(basket1[i]))
                numFreq[basket1[i]] = 1;
            else
                numFreq[basket1[i]]++;

            if (!numFreq.ContainsKey(basket2[i]))
                numFreq[basket2[i]] = -1;
            else
                numFreq[basket2[i]]--;
        }

        var moveList = new List<int>();

        foreach (var num in numFreq)
        {
            var n = num.Key;
            var freq = num.Value;

            if (freq % 2 != 0)
                return -1;

            for (var i = 0; i < Math.Abs(freq) / 2; i++)
            {
                moveList.Add(n);
            }

            min = Math.Min(min, n);
        }

        moveList.Sort();

        for (var i = 0; i < moveList.Count / 2; i++)
        {
            result += Math.Min(moveList[i], min * 2);
        }

        return result;
    }
}