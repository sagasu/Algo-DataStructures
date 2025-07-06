using System.Collections.Generic;

namespace AlgoTest.LeetCode.FindSumPairs;

public class FindSumPairs
{
    private Dictionary<int, int> nums1Count = new Dictionary<int, int>();
    private Dictionary<int, int> nums2Count = new Dictionary<int, int>();
    private int[] nums1;
    private int[] nums2;

    public FindSumPairs(int[] nums1, int[] nums2)
    {
        this.nums1 = nums1;
        this.nums2 = nums2;

        foreach (var num in nums1)
        {
            if (nums1Count.ContainsKey(num))
                nums1Count[num]++;
            else
                nums1Count[num] = 1;
        }
        foreach (var num in nums2)
        {
            if (nums2Count.ContainsKey(num))
                nums2Count[num]++;
            else
                nums2Count[num] = 1;
        }
    }

    public void Add(int index, int val)
    {
        var oldVal = nums2[index];
        nums2[index] += val;
        var newVal = nums2[index];
        nums2Count[oldVal]--;
        if (nums2Count[oldVal] == 0)
        {
            nums2Count.Remove(oldVal);
        }
        if (nums2Count.ContainsKey(newVal))
        {
            nums2Count[newVal]++;
        }
        else
        {
            nums2Count.Add(newVal, 1);
        }
    }

    public int Count(int tot)
    {
        var result = 0;

        foreach (var num1 in nums1Count.Keys)
        {
            var complement = tot - num1;
            if (nums2Count.ContainsKey(complement))
            {
                result += nums1Count[num1] * nums2Count[complement];
            }
        }

        return result;
    }
}