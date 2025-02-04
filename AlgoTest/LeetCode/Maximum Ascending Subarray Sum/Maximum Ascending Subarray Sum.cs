using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Ascending_Subarray_Sum;

public class Maximum_Ascending_Subarray_Sum
{
    public int MaxAscendingSum(int[] nums) =>
        nums.Aggregate(
            (Max: 0, Sum: 0, Previous: 0),
            (a, n) => n > a.Previous
                ? (Math.Max(a.Max, a.Sum + n), a.Sum + n, n)
                : (Math.Max(a.Max, n), n, n),
            a => a.Max
        );
}