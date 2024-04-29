using System.Linq;
using System.Numerics;

namespace AlgoTest.LeetCode.Minimum_Number_of_Operations_to_Make_Array_XOR_Equal_to_K;

public class Minimum_Number_of_Operations_to_Make_Array_XOR_Equal_to_K
{
    public int MinOperations(int[] nums, int k) {
        return BitOperations.PopCount((uint) nums.Aggregate(k, (current, num) => current ^ num));
    }
}