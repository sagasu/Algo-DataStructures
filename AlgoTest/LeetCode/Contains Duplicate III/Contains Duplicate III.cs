using System.Collections.Generic;

namespace AlgoTest.LeetCode.Contains_Duplicate_III;

public class Contains_Duplicate_III
{
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        if (t < 0) return false;
        var n = nums.Length;
        var sortedSet = new SortedSet<long>();
        for (var i = 0; i < n; i++) {
            if (sortedSet.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Count > 0) return true;
            sortedSet.Add(nums[i]);
            if (i >= k) sortedSet.Remove(nums[i - k]);
        }
        return false;
    }
}