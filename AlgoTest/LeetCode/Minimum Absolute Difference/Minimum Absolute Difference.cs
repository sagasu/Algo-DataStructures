using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Absolute_Difference;

public class Minimum_Absolute_Difference
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        Array.Sort(arr);
        IList<IList<int>> res = new List<IList<int>>();
        int minDiff = int.MaxValue;

        for (int i = 0; i < arr.Length - 1; i++) {
            int diff = arr[i + 1] - arr[i];
            if (diff < minDiff) {
                minDiff = diff;
                res.Clear();
                res.Add(new List<int> { arr[i], arr[i + 1] });
            } else if (diff == minDiff) {
                res.Add(new List<int> { arr[i], arr[i + 1] });
            }
        }

        return res;
    }
}