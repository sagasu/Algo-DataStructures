using System.Linq;

namespace AlgoTest.LeetCode.pecial_Array_I;

public class pecial_Array_I
{
    public bool IsArraySpecial(int[] nums) => nums.Zip(nums.Skip(1), (a, b) => (a % 2) != (b % 2)).All(x => x);
}