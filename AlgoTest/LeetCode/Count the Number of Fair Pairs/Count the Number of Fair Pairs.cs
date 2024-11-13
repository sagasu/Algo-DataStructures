using System;

namespace AlgoTest.LeetCode.Count_the_Number_of_Fair_Pairs;

public class Count_the_Number_of_Fair_Pairs
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        var result = 0L;
        Array.Sort(nums);

        for (var i = 0; i < nums.Length; i++)
        {
            var j_beg = FindIndex(nums, i, num => num + nums[i] >= lower);
            var j_end = FindIndex(nums, i, num => num + nums[i] > upper);
            result += j_end - j_beg;
        }

        return result;
    }

    public int FindIndex(int[] nums, int i, Predicate<int> predicate)
    {
        var left = i + 1;
        var right = nums.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (predicate(nums[mid]))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}