using System.Linq;

namespace AlgoTest.LeetCode.Check_if_Array_Is_Sorted_and_Rotated;

public class Check_if_Array_Is_Sorted_and_Rotated
{
    public bool Check(int[] nums) => nums.Where((t, i) => t > nums[(i + 1) % nums.Length]).Count() <= 1;
}