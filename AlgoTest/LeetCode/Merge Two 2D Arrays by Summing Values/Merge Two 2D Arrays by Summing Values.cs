using System.Collections.Generic;

namespace AlgoTest.LeetCode.Merge_Two_2D_Arrays_by_Summing_Values;

public class Merge_Two_2D_Arrays_by_Summing_Values
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2) {
        var map = new SortedDictionary<int, int>();

        foreach (var pair in nums1) {
            if (!map.ContainsKey(pair[0])) {
                map[pair[0]] = 0;
            }
            map[pair[0]] += pair[1];
        }

        foreach (var pair in nums2) {
            if (!map.ContainsKey(pair[0])) {
                map[pair[0]] = 0;
            }
            map[pair[0]] += pair[1];
        }

        int[][] result = new int[map.Count][];
        int index = 0;
        foreach (var entry in map) {
            result[index++] = new int[] { entry.Key, entry.Value };
        }

        return result;
    }
}