using System.Linq;

namespace AlgoTest.LeetCode.Majority_Element;

public class Majority_Element
{
    public int MajorityElement(int[] nums) {
        if(nums.Length == 0) return 0;
        
        var maxCount = nums.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).MaxBy(x => x.Count);

        return maxCount.Count > nums.Length / 2 ? maxCount.Key : 0;
    }
}