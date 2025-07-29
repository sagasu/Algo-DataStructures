using System;
using System.Linq;

namespace AlgoTest.LeetCode.Smallest_Subarrays_With_Maximum_Bitwise_OR;

public class Smallest_Subarrays_With_Maximum_Bitwise_OR
{
    public int[] SmallestSubarrays(int[] nums) {
        int n = nums.Length;
        int maxElement = nums.Max();

        int bits = maxElement == 0 ? 0 : 1 + (int) Math.Log(maxElement, 2);

        int[] nearestSetBit = new int[bits];

        Array.Fill(nearestSetBit, n);

        int[] res = new int[n];

        for(int i = n - 1; i >= 0; --i){
            int nearest = i;

            for(int j = 0; j < bits; ++j){
                if((nums[i]&(1 << j)) != 0){
                    nearestSetBit[j] = i;
                }

                if(nearestSetBit[j] != n){
                    nearest = Math.Max(nearest, nearestSetBit[j]);
                }
            }

            res[i] = nearest - i + 1;
        }

        return res;
    }
}