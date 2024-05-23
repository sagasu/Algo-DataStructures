using System.Collections.Generic;

namespace AlgoTest.LeetCode.The_Number_of_Beautiful_Subsets;

public class The_Number_of_Beautiful_Subsets
{
    public int BeautifulSubsets(int[] nums, int k) {
        var res = 0;
        DFS(nums, 0, new List<int>(), ref res, k);
        return res;
    }

    void DFS(int[] nums, int index, List<int> list, ref int res, int k) {
        if (index == nums.Length) {
            if (list.Count > 0) {
                res++;
            }
            return;
        }

        DFS(nums, index + 1, list, ref res, k);
        if (list.Count == 0 || (!list.Contains(nums[index] - k) && !list.Contains(nums[index] + k))) {
            list.Add(nums[index]);
            DFS(nums, index + 1, list, ref res, k);
            list.RemoveAt(list.Count - 1);
        }
    }
}