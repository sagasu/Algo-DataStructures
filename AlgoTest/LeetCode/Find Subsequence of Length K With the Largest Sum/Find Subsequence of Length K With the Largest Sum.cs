using System.Linq;

namespace AlgoTest.LeetCode.Find_Subsequence_of_Length_K_With_the_Largest_Sum;

public class Find_Subsequence_of_Length_K_With_the_Largest_Sum
{
    public int[] MaxSubsequence(int[] nums, int k) => nums.
        Select((m, i) => new { m, i }).
        OrderByDescending(m => m.m).
        Take(k).
        OrderBy(m => m.i).
        Select(m => m.m).
        ToArray();
}