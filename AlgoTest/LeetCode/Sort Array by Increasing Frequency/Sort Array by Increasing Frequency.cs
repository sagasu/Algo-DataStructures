using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Sort_Array_by_Increasing_Frequency;

public class Sort_Array_by_Increasing_Frequency
{
    public int[] FrequencySort(int[] nums) 
    {
        var rets = new List<int>();

        var groups = nums.GroupBy(x => x).OrderBy(x => x.Count()).ThenByDescending(x => x.Key).ToList();
        var keys = groups.Select(x => x.Key).ToList();

        foreach (var group in keys.Select(key => groups.Single(g => g.Key == key)))
            rets.AddRange(group.ToList());
        
        return rets.ToArray();
    }
}