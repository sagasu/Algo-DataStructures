using System.Linq;

namespace AlgoTest.LeetCode.Count_Number_of_Bad_Pairs;

public class Count_Number_of_Bad_Pairs
{
    public long CountBadPairs(int[] nums) => nums.Length * (nums.Length - 1L) / 2 - nums
        .Select((value, index) => value - index)
        .GroupBy(item => item)
        .Sum(group => group.Count() * (group.Count() - 1L) / 2);
}