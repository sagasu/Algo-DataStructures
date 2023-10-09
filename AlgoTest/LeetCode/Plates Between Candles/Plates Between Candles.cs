using System.Collections.Generic;

namespace AlgoTest.LeetCode.Plates_Between_Candles;

public class Plates_Between_Candles
{
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        var candles = new List<int>(s.Length);

        for (var i = 0; i < s.Length; ++i)
            if (s[i] == '|') 
                candles.Add(i);

        var result = new int[queries.Length];

        for (var i = 0; i < queries.Length; ++i) {
            var left = candles.BinarySearch(queries[i][0]);

            if (left < 0)
                left = ~left;

            var right = candles.BinarySearch(queries[i][1]);

            if (right < 0)
                right = ~right - 1;

            if (left < right)
                result[i] = candles[right] - candles[left] - (right - left);
        }

        return result;
    }
}