using System.Collections.Generic;

namespace AlgoTest.LeetCode.Construct_the_Minimum_Bitwise_Array_II;

public class Construct_the_Minimum_Bitwise_Array_II
{
    public int[] MinBitwiseArray(IList<int> nums) {
        int[] result = new int[nums.Count];
        for (int i = 0; i < nums.Count; i++) {
            if (nums[i] == 2) {
                result[i] = -1;
            } else {
                result[i] = Calc(nums[i]);
            }
        }
        return result;
    }

    static int Calc(int value) {
        int bitsOnRight = 0;
        int v = value;
        while ((v & 1) > 0) {
            bitsOnRight++;
            v >>= 1;
        }
        if (bitsOnRight == 1) {
            return value - 1;
        }
        int woBitsOnRight = value ^ ((1 << bitsOnRight) - 1);
        int ans = woBitsOnRight | ((1 << (bitsOnRight - 1)) - 1);
        return ans;
    }
}