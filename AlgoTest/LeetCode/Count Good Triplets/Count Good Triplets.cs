using System;

namespace AlgoTest.LeetCode.Count_Good_Triplets;

public class Count_Good_Triplets
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c) {
        var count = 0;
        var n = arr.Length;

        for (var i = 0; i < n - 2; i++) {
            for (var j = i + 1; j < n - 1; j++) {
                if (Math.Abs(arr[i] - arr[j]) > a) continue;

                for (var k = j + 1; k < n; k++) {
                    if (Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c) {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}