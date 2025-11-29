using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Make_Array_Sum_Divisible_by_K;

public class Minimum_Operations_to_Make_Array_Sum_Divisible_by_K
{
    public int MinOperations(int[] nums, int k) => nums.Sum() % k;
}