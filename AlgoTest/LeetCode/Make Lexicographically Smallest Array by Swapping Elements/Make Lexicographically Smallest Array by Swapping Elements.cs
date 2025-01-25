using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Make_Lexicographically_Smallest_Array_by_Swapping_Elements;

public class Make_Lexicographically_Smallest_Array_by_Swapping_Elements
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        
        if(nums.Length == 1) return nums;

        var sortNums = new int[nums.Length];
        sortNums = nums.ToArray();
        Array.Sort(sortNums);
    
        var indStart = new List<int>();

        var numsGroup = new Dictionary<int, int>();
    
        numsGroup.Add(sortNums[0], 0);

        indStart.Add(0);

        for(int i = 1; i < sortNums.Length; i++)
        {
            if(sortNums[i] - sortNums[i - 1] > limit) indStart.Add(i);  
            if(numsGroup.ContainsKey(sortNums[i]) == false)  numsGroup.Add(sortNums[i], indStart.Count - 1);
        }

        for(int i = 0; i < nums.Length; i++)
        {    
            nums[i] = sortNums[indStart[numsGroup[nums[i]]]];
            indStart[numsGroup[nums[i]]]++;
        }

        return nums;
    }
}