using System.Linq;

namespace AlgoTest.LeetCode.Keep_Multiplying_Found_Values_by_Two;

public class Keep_Multiplying_Found_Values_by_Two
{
    public int FindFinalValue(int[] nums, int original) {
        while(nums.Contains(original)) {
            original *= 2;
        }
        return original;
    }
}